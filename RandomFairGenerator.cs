using SHA3.Net;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace RickAndMortyGame;

public static class RandomFairGenerator
{
    public static int GenerateFairNumber(int range)
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] key = new byte[32]; 
        rng.GetBytes(key);

        int mortyValue = RandomNumber(rng, range);

        string hmac = ComputeHmacSha3(key, mortyValue.ToString());
        Console.WriteLine($"Morty: HMAC={hmac}");
        Console.WriteLine($"Rick: Enter your secret number (for fair play) between 0 and {range - 1}: ");
        int rickValue = ReadInt(0, range);

        int result = (mortyValue + rickValue) % range;

        Console.WriteLine($"Morty: My value was {mortyValue}");
        Console.WriteLine($"Morty: KEY={BitConverter.ToString(key).Replace("-", "")}");
        Console.WriteLine($"Fair number = ({mortyValue} + {rickValue}) % {range} = {result}");

        return result;
    }

    private static int RandomNumber(RandomNumberGenerator rng, int range)
    {
        byte[] bytes = new byte[4];
        int value;
        do
        {
            rng.GetBytes(bytes);
            value = BitConverter.ToInt32(bytes, 0) & int.MaxValue;
        } while (value >= (int.MaxValue / range) * range);
        return value % range;
    }

    private static string ComputeHmacSha3(byte[] key, string message)
    {
        var hmac = new HMac(new Sha3Digest(256));
        hmac.Init(new KeyParameter(key));

        var data = Encoding.UTF8.GetBytes(message);
        hmac.BlockUpdate(data, 0, data.Length);

        byte[] result = new byte[hmac.GetMacSize()];
        hmac.DoFinal(result, 0);

        return BitConverter.ToString(result).Replace("-", "");
    }
    private static int ReadInt(int min, int max)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int val) && val >= min && val < max)
                return val;
            Console.WriteLine($"Enter a number between {min} and {max - 1}");
        }
    }
}