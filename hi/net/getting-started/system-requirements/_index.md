---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 60
url: /hi/net/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- ऑपरेटिंग सिस्टम
- स्थापना
- निर्भरताएँ
- विंडोज
- लिनक्स
- macOS
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET की सिस्टम आवश्यकताओं की खोज करें। विंडोज, लिनक्स और macOS पर सहज PowerPoint और OpenDocument समर्थन सुनिश्चित करें।"
---
## **परिचय**

Aspose.Slides for .NET को Microsoft PowerPoint स्थापित करने की आवश्यकता नहीं है क्योंकि Aspose.Slides एक स्वतंत्र Microsoft PowerPoint दस्तावेज़ निर्माण, रूपांतरण, पेज लेआउट और रेंडरिंग इंजन है।

## **समर्थित ऑपरेटिंग सिस्टम**

Aspose.Slides for .NET किसी भी 32‑bit या 64‑bit ऑपरेटिंग सिस्टम को समर्थन देता है जहाँ .NET या Mono फ्रेमवर्क स्थापित हो, जिसमें (लेकिन इन तक सीमित नहीं) शामिल हैं:

### **विंडोज**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, और अन्य)

### **Mac**

- Mac OS X

## **समर्थित फ्रेमवर्क**

Aspose.Slides for .NET .NET और Mono फ्रेमवर्क को समर्थन देता है:

### **.NET फ्रेमवर्क्स**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM इंटरऑप समर्थन (COM, C++, VBScript)

### **Mono फ्रेमवर्क**

- MAC और Linux प्लेटफ़ॉर्म में MONO समर्थन

## **विकास वातावरण**

Aspose.Slides for .NET को किसी भी विकास वातावरण में उपयोग किया जा सकता है जो .NET प्लेटफ़ॉर्म को लक्ष्य बनाता है, लेकिन नीचे दिए गए वातावरण स्पष्ट रूप से समर्थित हैं:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides मुख्य बिल्ड**

वर्तमान में, Aspose.Slides के दो मुख्य बिल्ड हैं — Aspose.Slides.NET और Aspose.Slides.NET6.CrossPlatform।

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

यह उत्पाद का मुख्य संस्करण है। यह मानक .NET ग्राफ़िक्स इंजन का उपयोग करता है।
- गैर‑Windows प्लेटफ़ॉर्म पर, आपको `libgdiplus` लाइब्रेरी और उसकी निर्भरताएँ स्थापित करनी पड़ सकती हैं।
- Aspose.Slides संस्करण 25.3 से पहले, गैर‑Windows प्लेटफ़ॉर्म के लिए Aspose.Slides ZIP पैकेज से .NET Standard 2.0 DLL का उपयोग आवश्यक था।
- Aspose.Slides संस्करण 25.3 से, NuGet पैकेज को सीधे गैर‑Windows सिस्टम पर भी इस्तेमाल किया जा सकता है।
- गैर‑Windows सिस्टम पर चलाते समय, आपके एप्लिकेशन को स्टार्टअप पर निम्न पंक्ति शामिल करनी होगी:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **संस्करण 25.3 से, आप इस पैकेज को उन प्लेटफ़ॉर्म पर उपयोग कर सकते हैं जो .NET को समर्थन देते हैं, जैसे Linux aarch64 (ARM64)।**

#### **Linux Alpine के लिए अतिरिक्त पैकेज**

जब Aspose.Slides for .NET को Alpine Linux कंटेनर में चलाया जाता है, केवल `libgdiplus` स्थापित करना पर्याप्त नहीं हो सकता। Alpine कंटेनरों में आमतौर पर फ़ॉन्ट शामिल नहीं होते। यदि कोई फ़ॉन्ट उपलब्ध नहीं है, तो रेंडरिंग या रूपांतरण कार्य समान त्रुटि के साथ विफल हो सकते हैं:

```text
System.ArgumentException: Font '?' cannot be found
```
Alpine पर Aspose.Slides उपयोग करने के लिए, `libgdiplus` के साथ कम से कम एक फ़ॉन्ट पैकेज स्थापित करें।

**विकल्प 1: DejaVu फ़ॉन्ट्स**

अनुशंसित विकल्प `ttf-dejavu` पैकेज स्थापित करना है:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` पैकेज स्वचालित रूप से आवश्यक फ़ॉन्ट‑संबंधित निर्भरताएँ स्थापित करता है, जैसे `fontconfig`, `encodings`, `mkfontscale`, और `mkfontdir`। अधिकांश उपयोग मामलों के लिए अतिरिक्त फ़ॉन्ट पैकेज की आवश्यकता नहीं होती।

**विकल्प 2: Microsoft Core फ़ॉन्ट्स**

यदि आपके प्रेजेंटेशन में Microsoft‑विशिष्ट फ़ॉन्ट्स जैसे Arial, Times New Roman, Courier New, या Verdana का उपयोग होता है, तो Microsoft Core फ़ॉन्ट्स स्थापित करें:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

इस विकल्प का उपयोग केवल तब करें जब प्रोसेस किए जा रहे प्रेजेंटेशन को Microsoft फ़ॉन्ट्स की आवश्यकता हो। अधिकांश परिदृश्यों में `ttf-dejavu` स्थापित करना सरल और अधिक भरोसेमंद है।

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

यह Aspose.Slides का वह संस्करण है जो Aspose.Slides टीम द्वारा विकसित एक कस्टम क्रॉस‑प्लेटफ़ॉर्म ग्राफ़िक्स इंजन का उपयोग करता है।  
गैर‑Windows प्लेटफ़ॉर्म पर, `fontconfig` लाइब्रेरी आवश्यक हो सकती है।

**समर्थित प्लेटफ़ॉर्म**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)  
- *macOS*: x86_64, ARM64 (aarch64)

**असमर्थित प्लेटफ़ॉर्म**
- *Windows 11 ARM* (ARM64) — *वर्तमान में विचाराधीन नहीं*

{{%  alert  title="Notes"  color="primary"  %}}  
Linux x64 के लिए GLIBC 2.23+ आवश्यक है; Linux ARM64 के लिए GLIBC 2.39+ आवश्यक है। CentOS 7 (GLIBC 2.14) जैसे सिस्टम समर्थित नहीं हैं। यदि आपको Aspose.Slides को CentOS 7 या अन्य असंगत सिस्टम (जैसे Alpine) पर चलाना है, तो कृपया मानक पैकेज उपयोग करें: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET)।  
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या रूपांतरण और रेंडरिंग के लिए मुझे Microsoft PowerPoint स्थापित करना आवश्यक है?**

नहीं, PowerPoint आवश्यक नहीं है; Aspose.Slides एक स्टैंडअलोन इंजन है जो प्रस्तुतियों को [create](/slides/hi/net/create-presentation/), संशोधित, [convert](/slides/hi/net/convert-presentation/), और [render](/slides/hi/net/convert-powerpoint-to-png/) करता है।

**सही रेंडरिंग के लिए कौन‑से फ़ॉन्ट्स आवश्यक हैं?**

प्रेजेंटेशन में उपयोग किए गए फ़ॉन्ट या उपयुक्त विकल्प ऑपरेटिंग सिस्टम में उपलब्ध होने चाहिए। Linux और macOS पर निरंतर रेंडरिंग सुनिश्चित करने के लिए सामान्य फ़ॉन्ट पैकेज स्थापित करें।

Alpine Linux कंटेनरों के लिए, `libgdiplus` के साथ कम से कम एक फ़ॉन्ट पैकेज स्थापित करें। अनुशंसित न्यूनतम सेटअप `libgdiplus` के साथ `ttf-dejavu` है। यदि Arial, Times New Roman, Courier New, या Verdana जैसे Microsoft फ़ॉन्ट्स आवश्यक हैं, तो `msttcorefonts-installer` को `fontconfig` के साथ उपयोग करें।

**Linux पर कस्टम फ़ॉन्ट फ़ॉलबैक या गायब टेक्स्ट क्यों दिखाता है?**

यदि फ़ॉन्ट फ़ाइल में नाम‑टेबल प्रविष्टियाँ असंगत या भ्रष्ट हों, तो Linux फ़ॉन्ट‑मैचिंग स्टैक (FreeType/fontconfig) अमान्य रिकॉर्ड चुन सकता है, जिससे फ़ॉन्ट अनहेंडल्ड रहता है। सही नाम‑टेबल रिकॉर्ड वाला फ़ॉन्ट संस्करण स्थापित करना या एक सुसंगत प्रतिस्थापन स्थापित करना इस समस्या को हल करता है।