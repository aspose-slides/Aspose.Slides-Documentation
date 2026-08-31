---
title: इंस्टॉलेशन
type: docs
weight: 70
url: /hi/net/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides इंस्टॉलेशन
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "जाने कैसे जल्दी से .NET के लिए Aspose.Slides स्थापित किया जाए। चरण-दर-चरण गाइड, सिस्टम आवश्यकताएँ, और कोड नमूने — आज ही PowerPoint प्रेजेंटेशन के साथ काम शुरू करें!"
---
## **अवलोकन**

यह लेख बताता है कि Windows, Linux, और macOS पर Aspose.Slides for .NET को कैसे स्थापित करें। यह NuGet-आधारित स्थापना पर केंद्रित है और दिखाता है कि Windows पर NuGet पैकेज मैनेजर या पैकेज मैनेजर कंसोल के माध्यम से लाइब्रेरी कैसे जोड़ें, Linux पर .NET प्रोजेक्ट में, और macOS पर Visual Studio प्रोजेक्ट में। यह पैकेज को अपडेट करने और आवश्यकतानुसार प्री-रिलीज़ बिल्ड्स कैसे स्थापित करें, भी वर्णन करता है।

स्थापना से पहले, समर्थित ऑपरेटिंग सिस्टम, .NET कार्यान्वयन, और अतिरिक्त निर्भरताओं की समीक्षा करें [System Requirements](/slides/hi/net/system-requirements/) में।

## **Windows**
NuGet PCs पर .NET के लिए Aspose APIs को डाउनलोड और स्थापित करने का सबसे आसान मार्ग प्रदान करता है। 

### **विधि 1: NuGet पैकेज मैनेजर से Aspose.Slides स्थापित या अपडेट करें**

1. Microsoft Visual Studio खोलें। 
2. एक साधारण कंसोल ऐप बनाएं या मौजूदा प्रोजेक्ट खोलें। 
3. **Tools** > **NuGet package manager** पर जाएँ। 
4. **Browse** के तहत, टेक्स्ट फ़ील्ड में *Aspose Slides* खोजें। 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET** पर क्लिक करें और फिर **Install** पर क्लिक करें। 
   * यदि आप Aspose.Slides को अपडेट करना चाहते हैं—मान लेते हैं कि आपने इसे पहले ही स्थापित कर लिया है—तो इसके बजाय **Update** पर क्लिक करें। 

चयनित API डाउनलोड हो जाता है और आपके प्रोजेक्ट में संदर्भित हो जाता है।

### **विधि 2: पैकेज मैनेजर कंसोल के माध्यम से Aspose.Slides स्थापित या अपडेट करें**

पैकेज मैनेजर कंसोल के माध्यम से आप [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) को इस प्रकार संदर्भित करते हैं:

1. Microsoft Visual Studio खोलें। 
2. एक साधारण कंसोल ऐप बनाएं या मौजूदा प्रोजेक्ट खोलें। 
3. **Tools** > **Library Package Manager** > **Package Manager Console** पर जाएँ। 
![todo:image_alt_text](installation_2.png)
4. यह कमांड चलाएँ: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
नवीनतम पूर्ण रिलीज़ आपके एप्लिकेशन में स्थापित हो जाता है। 

* वैकल्पिक रूप से, आप कमांड में `-prerelease` उपसर्ग जोड़ सकते हैं ताकि यह निर्दिष्ट हो सके कि नवीनतम रिलीज़ (हॉटफिक्स सहित) भी स्थापित किया जाए।

**Installing Aspose.Slides.NET** टिप विंडो के नीचे के आसपास दिखाई देती है। 
![todo:image_alt_text](installation_4.png)

डाउनलोड पूर्ण होने के बाद, आपको कुछ पुष्टि संदेश दिखने चाहिए। 

यदि आप [Aspose EULA](https://about.aspose.com/legal/eula) से परिचित नहीं हैं, तो आप URL में उल्लिखित लाइसेंस पढ़ना चाह सकते हैं। 
![todo:image_alt_text](installation_5.png)

आपके एप्लिकेशन में, आपको दिखना चाहिए कि Aspose.Slides सफलतापूर्वक जोड़ी गई है और संदर्भित है। 
![todo:image_alt_text](installation_6.png)

Package Manager Console में, आप `Update-Package Aspose.Slides.NET` कमांड चलाकर Aspose.Slides पैकेज के अपडेट की जांच कर सकते हैं। अपडेट (यदि मिलें) स्वत: स्थापित हो जाते हैं। आप नवीनतम रिलीज़ को अपडेट करने के लिए `-prerelease` उपसर्ग भी उपयोग कर सकते हैं।

#### **साझा सर्वर वातावरण में चलाते समय विचार**
हम दृढ़ता से सलाह देते हैं कि आप सभी Aspose .NET घटकों को **Full Trust** अनुमति सेट के साथ चलाएँ क्योंकि Aspose घटकों को कभी-कभी रेजिस्ट्री सेटिंग्स और वर्चुअल डायरेक्टरी के अतिरिक्त स्थानों में स्थित फाइलों तक पहुंच की आवश्यकता होती है—उदाहरण के लिए, जब Aspose घटकों को फोंट पढ़ने होते हैं। 

इसके अतिरिक्त, Aspose.NET घटक कोर .NET सिस्टम क्लासेज़ पर आधारित हैं—और उन क्लासेज़ में से कुछ को कुछ मामलों में ऑपरेशनों के लिए Full Trust अनुमति की आवश्यकता होती है। 

इंटरनेट सर्विस प्रोवाइडर्स, जो विभिन्न कंपनियों के कई एप्लिकेशन होस्ट करते हैं, आमतौर पर Medium Trust सुरक्षा स्तर लागू करते हैं। .NET 2.0 के मामले में, ऐसा सुरक्षा स्तर Aspose.Slides के ऑपरेशनों को प्रभावित करने वाले प्रतिबंध उत्पन्न कर सकता है:

- **RegistryPermission** उपलब्ध नहीं है। इसका मतलब है कि आप रेजिस्ट्री तक पहुंच नहीं सकते, जो दस्तावेज़ रेंडरिंग के दौरान स्थापित फोंट को सूचीबद्ध करने के लिए आवश्यक है। 
- **FileIOPermission** प्रतिबंधित है। इसका मतलब है कि आप केवल अपने एप्लिकेशन की वर्चुअल डायरेक्टरी पदक्रम में फ़ाइलों तक पहुंच सकते हैं। यह संभावित रूप से यह भी अर्थ देता है कि निर्यात ऑपरेशनों के दौरान फोंट पढ़े नहीं जा सकते। 

उपरोक्त कारणों से, हम दृढ़ता से सलाह देते हैं कि आप Aspose.Slides को **Full Trust** अनुमतियों के साथ चलाएँ। यदि आप **Medium trust** का उपयोग करते हैं, तो आप असंगतियों का अनुभव कर सकते हैं—कुछ लाइब्रेरी सुविधाएँ (जैसे रेंडरिंग) कुछ कार्यों को करने पर काम नहीं कर सकतीं। 

## **Linux**

NuGet Linux पर .NET के लिए Aspose.Slides डाउनलोड और स्थापित करने का सबसे आसान मार्ग प्रदान करता है। अपने .NET प्रोजेक्ट में [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) पैकेज जोड़ें।

## **macOS**

NuGet macs पर .NET के लिए Aspose.Slides डाउनलोड और स्थापित करने का सबसे आसान मार्ग प्रदान करता है।

### **Aspose.Slides स्थापित करें**

1. Visual Studio खोलें। 
2. एक साधारण कंसोल ऐप बनाएं या मौजूदा प्रोजेक्ट खोलें। 
3. **Project** > **Manage NuGet Packages...** पर जाएँ। 
![path-to-nuget-macos](path-to-nuget-macos.png)
4. टेक्स्ट फ़ील्ड में *Aspose.Slides* टाइप करें। 
5. **Aspose.Slides for .NET** पर क्लिक करें और फिर **Add Package** पर क्लिक करें। 
6. एक साधारण कोड स्निपेट जोड़ें। 
   * आप कोड को [this page](/slides/hi/net/create-presentation/) से कॉपी कर सकते हैं। 
7. ऐप चलाएँ। 
8. अपने प्रोजेक्ट की *folder/bin/Debug/presentation_file_name* खोलें। 

## **FAQ**

**क्या कोई मुफ्त संस्करण या ट्रायल सीमा है?**

हाँ, डिफ़ॉल्ट रूप से, Aspose.Slides मूल्यांकन मोड में चलती है, जिससे वॉटरमार्क लगते हैं और संभवतः अन्य प्रतिबंध होते हैं। प्रतिबंध हटाने के लिए, आपको एक वैध [license](/slides/hi/net/licensing/) लागू करने की आवश्यकता है।