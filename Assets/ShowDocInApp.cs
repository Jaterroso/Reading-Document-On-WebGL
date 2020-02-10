using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Security.Cryptography;
using System;

public class ShowDocInApp : MonoBehaviour
{
    public InputField urlField;
    private string url;
    public Text optext;

    public void OnClick()
    {
        StartCoroutine(OnShowClicked());
    }

    IEnumerator OnShowClicked()
    {
        url = urlField.text;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            StringBuilder sb = new StringBuilder();

            // Display video URL.
            sb.Append($"<b>URL</b>\n<color=\"white\">{url}</color>\n\n");
            Debug.Log("\'" + sb + "\'");

            // Display MD5 hash of response data.
            string hash = GetMd5Hash(webRequest.downloadHandler.data);
            sb.Append($"<b>MD5 Hash</b>\n<color=\"white\">{hash}</color>\n\n");
            Debug.Log("\'" + sb + "\'");

            // Display response code.
            sb.Append($"<b>Response Code</b>\n<color=\"white\">{webRequest.responseCode}</color>\n\n");
            Debug.Log("\'" + sb + "\'");


            Debug.Log("result data : "+ webRequest.downloadHandler.data);
            Debug.Log("result text : " + webRequest.downloadHandler.text);
            // Display response headers.
            sb.Append("<b>Response Headers</b>\n");
            var responseHeaders = webRequest.GetResponseHeaders();
            Debug.Log("\'" + sb + "\'");
            if (responseHeaders != null)
            {
                foreach (var kvp in responseHeaders)
                {
                    sb.Append($"{kvp.Key}: <color=\"white\">{kvp.Value}</color>\n");
                    Debug.Log(sb);
                }
            }
            Debug.Log("\'"+sb+"\'");

            optext.text = sb.ToString();
        }
    }

    /*
    public static string CreateMD5(ReadOnlySpan<char> input)
    {
        var encoding = System.Text.Encoding.UTF8;
        var inputByteCount = encoding.GetByteCount(input);
        using var md5 = System.Security.Cryptography.MD5.Create();

        Span<byte> bytes = inputByteCount < 1024
            ? stackalloc byte[inputByteCount]
            : new byte[inputByteCount];
        Span<byte> destination = stackalloc byte[md5.HashSize / 8];

        encoding.GetBytes(input, bytes);

        // checking the result is not required because this only returns false if "(destination.Length < HashSizeValue/8)", which is never true in this case
        md5.TryComputeHash(bytes, destination, out int _bytesWritten);

        return BitConverter.ToString(destination.ToArray());
    }

    static string GetMd5Hash(MD5 md5Hash, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    // Verify a hash against a string.
    static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
    {
        // Hash the input.
        string hashOfInput = GetMd5Hash(md5Hash, input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    */

    private static string GetMd5Hash(byte[] bytes)
    {
        StringBuilder sb = new StringBuilder();

        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(bytes);
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
        }
        return sb.ToString();
    }
}
