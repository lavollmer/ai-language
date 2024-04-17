using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Translation.Text;



namespace translate_text
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Set console encoding to unicode
                Console.InputEncoding = Encoding.Unicode;
                Console.OutputEncoding = Encoding.Unicode;

                // Get config settings from AppSettings
                IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                IConfigurationRoot configuration = builder.Build();
                string translatorRegion = configuration["TranslatorRegion"];
                string translatorKey = configuration["TranslatorKey"];


                // Create client using endpoint and key
                AzureKeyCredential credential = new(translatorKey);
                TextTranslationClient client = new(credential, translatorRegion);


                // Choose target language
                languagesResponse = client.get_languages(scope = "translation")
print("{} languages supported.".format(len(languagesResponse.translation)))
print("(See https://learn.microsoft.com/azure/ai-services/translator/language-support#translation)")
print("Enter a target language code for translation (for example, 'en'):")
targetLanguage = "xx"
supportedLanguage = False
while supportedLanguage == False:
    targetLanguage = input()
    if  targetLanguage in languagesResponse.translation.keys():
        supportedLanguage = True
    else:
        print("{} is not a supported language.".format(targetLanguage))


                // Translate text
string inputText = "";
                while (inputText.ToLower() != "quit")
                {
                    Console.WriteLine("Enter text to translate ('quit' to exit)");
                    inputText = Console.ReadLine();
                    if (inputText.ToLower() != "quit")
                    {
                        Response<IReadOnlyList<TranslatedTextItem>> translationResponse = await client.TranslateAsync(targetLanguage, inputText).ConfigureAwait(false);
                        IReadOnlyList<TranslatedTextItem> translations = translationResponse.Value;
                        TranslatedTextItem translation = translations[0];
                        string sourceLanguage = translation?.DetectedLanguage?.Language;
                        Console.WriteLine($"'{inputText}' translated from {sourceLanguage} to {translation?.Translations[0].To} as '{translation?.Translations?[0]?.Text}'.");
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
