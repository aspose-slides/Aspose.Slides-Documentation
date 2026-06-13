---
title: स्थापना
type: docs
weight: 70
url: /hi/net/installation/
keywords:
- इंस्टॉल Aspose.Slides
- डाउनलोड Aspose.Slides
- उपयोग Aspose.Slides
- Aspose.Slides स्थापना
- विंडोज
- लिनक्स
- macOS
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "सिखें कि कैसे तेज़ी से .NET के लिए Aspose.Slides स्थापित किया जाए। चरण-दर-चरण गाइड, सिस्टम आवश्यकताएँ, और कोड उदाहरण — आज ही PowerPoint प्रेजेंटेशन के साथ काम करना शुरू करें!"
---
## **परिचय**

यह लेख समझाता है कि Windows और macOS पर .NET के लिए Aspose.Slides कैसे स्थापित किया जाता है। यह NuGet-आधारित स्थापना पर केंद्रित है और दिखाता है कि Windows पर NuGet पैकेज मैनेजर या पैकेज मैनेजर कंसोल के माध्यम से लाइब्रेरी को Visual Studio प्रोजेक्ट में कैसे जोड़ें। यह बताता है कि पैकेज को कैसे अपडेट करें और आवश्यकता पड़ने पर प्री‑रिलीज़ बिल्ड कैसे स्थापित करें।

## **Windows**
NuGet, PCs पर .NET के लिए Aspose API को डाउनलोड और स्थापित करने का सबसे आसान मार्ग प्रदान करता है। 

### **विधि 1: NuGet पैकेज मैनेजर से Aspose.Slides स्थापित या अपडेट करें**

1. Microsoft Visual Studio खोलें। 
2. एक साधारण कंसोल ऐप बनाएँ या मौज़ूदा प्रोजेक्ट खोलें। 
3. **Tools** > **NuGet package manager** पर जाएँ। 
4. **Browse** में, टेक्स्ट फ़ील्ड में *Aspose Slides* खोजें। 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET** पर क्लिक करें और फिर **Install** पर क्लिक करें। 
   * यदि आप Aspose.Slides को अपडेट करना चाहते हैं—मान लेते हैं कि यह पहले से स्थापित है—तो **Update** पर क्लिक करें। 

चयनित API डाउनलोड होकर आपके प्रोजेक्ट में रेफ़रेंस हो जाता है।

### **विधि 2: पैकेज मैनेजर कंसोल के माध्यम से Aspose.Slides स्थापित या अपडेट करें**

आप पैकेज मैनेजर कंसोल के माध्यम से [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) को इस प्रकार रेफ़रेंस कर सकते हैं:

1. Microsoft Visual Studio खोलें। 
2. एक साधारण कंसोल ऐप बनाएँ या मौज़ूदा प्रोजेक्ट खोलें। 
3. **Tools** > **Library Package Manager** > **Package Manager Console** पर जाएँ। 
![todo:image_alt_text](installation_2.png)
4. इस कमांड को चलाएँ: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
नवीनतम पूर्ण रिलीज आपके एप्लिकेशन में स्थापित हो जाता है। 

* वैकल्पिक रूप से, आप कमांड में `-prerelease` उपसर्ग जोड़कर यह निर्दिष्ट कर सकते हैं कि नवीनतम रिलीज (हॉटफ़िक्स सहित) भी स्थापित हो। 

**Installing Aspose.Slides.NET** टिप विंडो के नीचे दिखाई देती है। 
![todo:image_alt_text](installation_4.png)

डाउनलोड पूर्ण होने के बाद, आपको कुछ पुष्टि संदेश दिखने चाहिए। 

यदि आप [Aspose EULA](https://about.aspose.com/legal/eula) से परिचित नहीं हैं, तो आप URL में संदर्भित लाइसेंस पढ़ना चाहेंगे। 
![todo:image_alt_text](installation_5.png)

आपके एप्लिकेशन में, आपको दिखना चाहिए कि Aspose.Slides सफलतापूर्वक जोड़ा गया है और रेफ़रेंस किया गया है। 
![todo:image_alt_text](installation_6.png)

पैकेज मैनेजर कंसोल में, आप `Update-Package Aspose.Slides.NET` कमांड चलाकर Aspose.Slides पैकेज के अपडेट की जाँच कर सकते हैं। अपडेट (यदि मिले) स्वचालित रूप से स्थापित हो जाते हैं। आप `-prerelease` उपसर्ग का उपयोग करके नवीनतम रिलीज को भी अपडेट कर सकते हैं।

#### **सामायिक सर्वर पर्यावरण में चलाते समय विचार**

हम दृढ़ता से अनुशंसा करते हैं कि आप सभी Aspose .NET घटकों को **Full Trust** परमिशन सेट के साथ चलाएँ क्योंकि Aspose घटकों को कभी‑कभी रजिस्ट्री सेटिंग्स और वर्चुअल डायरेक्ट्री के बाहर स्थित फ़ाइलों तक पहुँच की आवश्यकता होती है—उदाहरण के लिए, जब Aspose घटकों को फ़ॉन्ट पढ़ने होते हैं। 

इसके अतिरिक्त, Aspose.NET घटक कोर .NET सिस्टम क्लासेज़ पर आधारित होते हैं—और उन क्लासेज़ में से कुछ को कुछ मामलों में संचालन के लिए **Full Trust** परमिशन की आवश्यकता होती है। 

इंटरनेट सर्विस प्रोवाइडर्स, जो विभिन्न कंपनियों के कई एप्लिकेशन होस्ट करते हैं, सामान्यतः **Medium Trust** सुरक्षा स्तर लागू करते हैं। .NET 2.0 के मामले में, ऐसा सुरक्षा स्तर ऐसे प्रतिबंधों को जन्म दे सकता है जो Aspose.Slides के संचालन को प्रभावित करते हैं:

- **RegistryPermission** उपलब्ध नहीं है। इसका अर्थ है कि आप रजिस्ट्री तक पहुँच नहीं सकते, जो दस्तावेज़ रेंडर करते समय स्थापित फ़ॉन्ट की सूची बनाने के लिए आवश्यक है। 
- **FileIOPermission** प्रतिबंधित है। इसका अर्थ है कि आप केवल अपने एप्लिकेशन की वर्चुअल डायरेक्ट्री पदानुक्रम में फ़ाइलों तक ही पहुँच सकते हैं। इसका यह भी संभावित अर्थ है कि निर्यात संचालन के दौरान फ़ॉन्ट पढ़े नहीं जा सकते। 

उपरोक्त कारणों से, हम दृढ़ता से अनुशंसा करते हैं कि आप Aspose.Slides को **Full Trust** परमिशन पर चलाएँ। यदि आप **Medium trust** उपयोग करते हैं, तो आप असंगतियों का सामना कर सकते हैं—कुछ लाइब्रेरी सुविधाएँ (जैसे रेंडरिंग) कुछ कार्यों को करने पर काम नहीं कर सकतीं। 

## **macOS**

NuGet, macs पर .NET के लिए Aspose.Slides को डाउनलोड और स्थापित करने का सबसे आसान मार्ग प्रदान करता है। 

**आवश्यकता स्थापित करें**

`System.Drawing` नेमस्पेस macOS में अलग ढंग से कार्य करता है, इसलिए आपको mono-libgdiplus स्थापित करना होगा। 

> .NET 5 और पिछले संस्करणों में, [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet पैकेज Windows, Linux और macOS पर काम करता है। हालांकि, कुछ प्लेटफ़ॉर्म अंतर हैं। Linux और macOS पर, GDI+ कार्यक्षमता को [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) लाइब्रेरी द्वारा लागू किया गया है। यह लाइब्रेरी अधिकांश Linux वितरणों में डिफ़ॉल्ट रूप से नहीं स्थापित होती और Windows और macOS पर GDI+ की सभी कार्यक्षमता का समर्थन नहीं करती। कुछ प्लेटफ़ॉर्म पर libgdiplus बिल्कुल भी उपलब्ध नहीं है। Linux और macOS पर System.Drawing.Common पैकेज के प्रकारों का उपयोग करने के लिए, आपको libgdiplus को अलग से स्थापित करना होगा। अधिक जानकारी के लिए, देखें [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) या [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus)।s

अपने mac पर mono-libgdiplus को अलग से स्थापित करने के लिए, .NET दस्तावेज़ीकरण के [इस लेख](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) को देखें। 

### **Aspose.Slides स्थापित करें**

1. Visual Studio खोलें। 
2. एक साधारण कंसोल ऐप बनाएँ या मौज़ूदा प्रोजेक्ट खोलें। 
3. **Project** > **Manage NuGet Packages...** पर जाएँ। 
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. टेक्स्ट फ़ील्ड में *Aspose.Slides* टाइप करें। 
5. **Aspose.Slides for .NET** पर क्लिक करें और फिर **Add Package** पर क्लिक करें। 
6. एक साधारण कोड स्निपेट जोड़ें। 
   * आप कोड को [this page](/slides/hi/net/create-presentation/) से कॉपी कर सकते हैं। 
7. एप्लिकेशन चलाएँ। 
8. अपने प्रोजेक्ट की *folder/bin/Debug/presentation_file_name* खोलें। 

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कोई मुफ्त संस्करण या ट्रायल सीमा है?**

हाँ, डिफ़ॉल्ट रूप से, Aspose.Slides मूल्यांकन मोड में चलता है, जो वॉटरमार्क लगाता है और अन्य प्रतिबंध हो सकते हैं। प्रतिबंध हटाने के लिए, आपको एक वैध [license](/slides/hi/net/licensing/) लागू करना होगा।