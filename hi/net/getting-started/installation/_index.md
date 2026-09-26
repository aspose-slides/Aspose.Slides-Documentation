---
title: स्थापना
type: docs
weight: 70
url: /hi/net/installation/
keywords:
- Aspose.Slides स्थापित करें
- Aspose.Slides डाउनलोड करें
- Aspose.Slides उपयोग करें
- Aspose.Slides स्थापना
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Windows, Linux और macOS पर NuGet से .NET के लिए Aspose.Slides स्थापित करें: दो पैकेजों में से चुनें, .NET CLI या Visual Studio के साथ एक जोड़ें, और Linux की पूर्वापेक्षाएँ स्थापित करें।"
---
## **अवलोकन**

यह लेख बताता है कि Windows, Linux और macOS पर किसी प्रोजेक्ट में Aspose.Slides for .NET कैसे जोड़ें। Aspose.Slides NuGet के माध्यम से वितरित किया जाता है। आप इसे किसी भी ऑपरेटिंग सिस्टम पर .NET CLI से जोड़ सकते हैं, या Windows पर Visual Studio में NuGet पैकेज मैनेजर या पैकेज मैनेजर कंसोल का उपयोग करके। लेख यह भी बताता है कि दो NuGet पैकेजों में से कौन सा चुनना है और Linux को अतिरिक्त रूप से क्या चाहिए।

इंस्टॉल करने से पहले, समर्थित ऑपरेटिंग सिस्टम, .NET इम्प्लीमेंटेशन और अतिरिक्त निर्भरताओं को [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/) में देखें।

## **पैकेज चुनें**

Aspose.Slides for .NET दो NuGet पैकेज के रूप में प्रकाशित किया गया है। दोनों समान Aspose.Slides नेमस्पेस और क्लासेज प्रदान करते हैं, इसलिए दोनों के बीच स्विच करने पर आपका कोड नहीं बदलता; केवल पैकेज रेफ़रेंस और प्लेटफ़ॉर्म आवश्यकताएँ अलग होती हैं।

| पैकेज | उपयोग हेतु | अतिरिक्त आवश्यकताएँ |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows, और .NET Framework एप्लिकेशन | Linux और macOS पर: `libgdiplus` लाइब्रेरी, और `System.Drawing.EnableUnixSupport` स्विच एप्लिकेशन स्टार्टअप पर सक्षम किया गया |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 या बाद के संस्करण Windows, Linux और macOS पर | Linux पर: `fontconfig` लाइब्रेरी, यदि यह पहले से स्थापित नहीं है |

यदि आप निश्चित नहीं हैं, तो Windows पर Aspose.Slides.NET और Linux तथा macOS पर Aspose.Slides.NET6.CrossPlatform उपयोग करें। Alpine Linux पर, और उन Linux सिस्टम पर जिनकी glibc संस्करण 2.23 (x64) या 2.39 (ARM64) से पुराना है, Aspose.Slides.NET का उपयोग करें। [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/) प्रत्येक पैकेज के समर्थित प्लेटफ़ॉर्म की सूची देती है।

## **.NET CLI से इंस्टॉल करें**

ये चरण Windows, Linux और macOS पर .NET SDK 6 या बाद के संस्करण के साथ काम करते हैं। एक कंसोल एप्लिकेशन बनाएँ:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

फिर अपने प्लेटफ़ॉर्म के लिए पैकेज जोड़ें। प्रोजेक्ट में दो पैकेजों में से केवल एक जोड़ें।

- Windows पर: `dotnet add package Aspose.Slides.NET`
- Linux और macOS पर: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (Linux पर, पहले उसकी पूर्वापेक्षा स्थापित करें; देखें [Linux](#linux))

पैकेज के काम करने की जाँच करने के लिए, *Program.cs* की सामग्री को [प्रेज़ेंटेशन बनाएं](/slides/hi/net/create-presentation/) में पहला उदाहरण से बदलें और `dotnet run` चलाएँ। यह प्रोजेक्ट फ़ोल्डर में *hello.pptx* सहेजता है।

## **विंडोज़**

### **विधि 1: NuGet पैकेज मैनेजर से Aspose.Slides स्थापित या अपडेट करें**

1. Microsoft Visual Studio खोलें।
2. एक कंसोल एप्लिकेशन बनाएँ या मौजूदा प्रोजेक्ट खोलें।
3. **Solution Explorer** में, प्रोजेक्ट पर राइट-क्लिक करें और **Manage NuGet Packages** चुनें (या **Project** > **Manage NuGet Packages** पर जाएँ)।
4. **Browse** के तहत, *Aspose.Slides* खोजें.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET** पर क्लिक करें और फिर **Install** पर क्लिक करें.
   * यदि आप पहले से Aspose.Slides स्थापित कर चुके हैं और इसे अपडेट करना चाहते हैं, तो **Update** पर क्लिक करें.

पैकेज डाउनलोड हो जाता है और आपके प्रोजेक्ट में रेफ़रेंस किया जाता है।

### **विधि 2: पैकेज मैनेजर कंसोल के माध्यम से Aspose.Slides स्थापित या अपडेट करें**

यह है कि आप पैकेज मैनेजर कंसोल के माध्यम से [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) पैकेज को कैसे रेफ़रेंस करते हैं:

1. Microsoft Visual Studio खोलें।
2. एक कंसोल एप्लिकेशन बनाएँ या मौजूदा प्रोजेक्ट खोलें।
3. **Tools** > **NuGet Package Manager** > **Package Manager Console** पर जाएँ.
![पैकेज मैनेजर कंसोल खोलना](installation_2.png)
4. यह कमांड चलाएँ: `Install-Package Aspose.Slides.NET`
![Install-Package कमांड चलाना](installation_3.png)
नवीनतम रिलीज़ आपके प्रोजेक्ट में स्थापित किया जाता है।

**Installing Aspose.Slides.NET** संदेश विंडो के नीचे दिखाई देता है.
![पैकेज मैनेजर कंसोल में इंस्टॉल प्रगति](installation_4.png)

डाउनलोड पूर्ण होने पर, पुष्टि संदेश दिखते हैं। पैकेज [Aspose EULA](https://about.aspose.com/legal/eula) के अंतर्गत वितरित किया गया है.
![इंस्टॉलेशन पुष्टि संदेश](installation_5.png)

Aspose.Slides अब आपके प्रोजेक्ट में जोड़ दिया गया है और रेफ़रेंस किया गया है.
![प्रोजेक्ट में Aspose.Slides रेफ़रेंस किया गया](installation_6.png)

पैकेज को अपडेट करने के लिए, पैकेज मैनेजर कंसोल में `Update-Package Aspose.Slides.NET` चलाएँ।

## **Linux**

उपर्युक्त .NET CLI चरणों का उपयोग करें। पैकेज चुनें और अपने वितरण के पैकेज मैनेजर से उसकी पूर्वापेक्षा स्थापित करें। Debian और Ubuntu पर:

- **Aspose.Slides.NET6.CrossPlatform**: `fontconfig` स्थापित करें.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: `libgdiplus` स्थापित करें, और आपके एप्लिकेशन द्वारा Aspose.Slides इस्तेमाल करने से पहले System.Drawing के लिए Unix सपोर्ट सक्षम करें.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  यह बयान अपने एप्लिकेशन की शुरुआत में, किसी भी Aspose.Slides कॉल से पहले जोड़ें। *Program.cs* में टॉप-लेवल स्टेटमेंट्स के साथ, इसे `using` निर्देशों के बाद रखें:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

Alpine Linux पर, और उन सिस्टम पर जिनकी glibc Aspose.Slides.NET6.CrossPlatform के लिए बहुत पुरानी है, इस पैकेज का उपयोग करें।

आपके प्रेज़ेंटेशन में उपयोग किए गए फ़ॉन्ट, या उपयुक्त विकल्प, टेक्स्ट को सही ढंग से रेंडर करने के लिए सिस्टम पर स्थापित होने चाहिए। [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/) Alpine Linux पर Aspose.Slides.NET को आवश्यक पैकेजों का वर्णन करता है, जिसमें फ़ॉन्ट भी शामिल हैं।

## **macOS**

उपर्युक्त .NET CLI चरणों का उपयोग **Aspose.Slides.NET6.CrossPlatform** पैकेज के साथ करें, जो Intel (x86_64) और Apple silicon (ARM64) दोनों Macs का समर्थन करता है:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कोई मुफ्त संस्करण या ट्रायल प्रतिबंध है?**

हाँ। लाइसेंस के बिना, Aspose.Slides मूल्यांकन मोड में चलता है: यह सहेजे गए प्रत्येक स्लाइड में मूल्यांकन वाटरमार्क जोड़ता है और प्रेज़ेंटेशन से पढ़ा गया टेक्स्ट काट देता है। इन प्रतिबंधों को हटाने के लिए, एक वैध [लाइसेंस](/slides/hi/net/licensing/) लागू करें।