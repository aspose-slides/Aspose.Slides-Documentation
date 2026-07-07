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
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET की सिस्टम आवश्यकताओं की खोज करें। Windows, Linux और macOS पर PowerPoint और OpenDocument समर्थन सुनिश्चित करें।"
---
## **परिचय**

Aspose.Slides for .NET को Microsoft PowerPoint स्थापित करने की आवश्यकता नहीं होती क्योंकि Aspose.Slides एक स्वतंत्र Microsoft PowerPoint दस्तावेज़ निर्माण, रूपांतरण, पृष्ठ लेआउट, और रेंडरिंग इंजन है।

## **समर्थित ऑपरेटिंग सिस्टम**

Aspose.Slides for .NET उन सभी 32-बिट या 64-बिट ऑपरेटिंग सिस्टमों को समर्थन देता है जहाँ .NET या Mono फ्रेमवर्क स्थापित है, जिसमें (परंतु सीमित नहीं) शामिल हैं:

### **विंडोज**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **लिनक्स**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, and others)

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
- COM Interop support (COM, C++, VBScript)

### **Mono फ्रेमवर्क**

- MONO Support in MAC and Linux platforms

## **विकास वातावरण**

Aspose.Slides for .NET .NET प्लेटफ़ॉर्म को लक्षित करने वाले किसी भी विकास वातावरण में अनुप्रयोग विकसित करने के लिए उपयोग किया जा सकता है, लेकिन ये वातावरण स्पष्ट रूप से समर्थित हैं:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Aspose.Slides मुख्य बिल्ड्स**

वर्तमान में, Aspose.Slides के दो मुख्य बिल्ड हैं — Aspose.Slides.NET और Aspose.Slides.NET6.CrossPlatform।

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

यह उत्पाद का मुख्य संस्करण है। यह मानक .NET ग्राफ़िक्स इंजन का उपयोग करता है।
- On non-Windows platforms, you may need to install the `libgdiplus` library and its dependencies.
- Prior to version Aspose.Slides 25.3, for non-Windows platforms, it was necessary to use the .NET Standard 2.0 DLL from the Aspose.Slides ZIP package.
- Starting from version Aspose.Slides 25.3, the NuGet package can be used directly even on non-Windows systems.
- When running on non-Windows systems, your application must include the following line at startup:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **Starting from version 25.3, you can use this package on platforms that support .NET, such as Linux aarch64 (ARM64).**

#### **Linux Alpine के लिए अतिरिक्त पैकेज**

जब Aspose.Slides for .NET को एक Alpine Linux कंटेनर में चलाया जाता है, केवल `libgdiplus` स्थापित करना पर्याप्त नहीं हो सकता। Alpine कंटेनर आमतौर पर डिफ़ॉल्ट रूप से फ़ॉन्ट शामिल नहीं करते। यदि कोई फ़ॉन्ट उपलब्ध नहीं है, तो रेंडरिंग या रूपांतरण कार्य समान त्रुटि के साथ विफल हो सकते हैं:

```text
System.ArgumentException: Font '?' cannot be found
```
Alpine पर Aspose.Slides का उपयोग करने के लिए, `libgdiplus` को कम से कम एक फ़ॉन्ट पैकेज के साथ स्थापित करें।

**विकल्प 1: DejaVu फ़ॉन्ट्स**

सिफ़ारिश किया गया विकल्प ttf-dejavu पैकेज स्थापित करना है:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

`ttf-dejavu` पैकेज स्वचालित रूप से आवश्यक फ़ॉन्ट‑संबंधित निर्भरताएँ, जैसे `fontconfig`, `encodings`, `mkfontscale`, और `mkfontdir` स्थापित करता है। अधिकांश उपयोग मामलों के लिए अतिरिक्त फ़ॉन्ट पैकेज आवश्यक नहीं हैं।

**विकल्प 2: Microsoft Core फ़ॉन्ट्स**

यदि आपके प्रस्तुतियों में Microsoft‑विशिष्ट फ़ॉन्ट्स जैसे Arial, Times New Roman, Courier New, या Verdana प्रयुक्त हैं, तो Microsoft Core फ़ॉन्ट्स स्थापित करें:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

यह विकल्प केवल तब उपयोग करें जब प्रसंस्कृत प्रस्तुतियों को Microsoft फ़ॉन्ट्स की आवश्यकता हो। अधिकांश परिदृश्यों में `ttf-dejavu` स्थापित करना सरल और अधिक भरोसेमंद है।

**वैश्वीकरण के लिए अतिरिक्त आवश्यकताएँ**

Alpine पर उचित वैश्वीकरण समर्थन सक्षम करने के लिए, `icu-libs` पैकेज स्थापित करें और invariant mode को निष्क्रिय करें:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

यह Aspose.Slides का वह संस्करण है जो Aspose.Slides टीम द्वारा विकसित एक कस्टम क्रॉस‑प्लेटफ़ॉर्म ग्राफ़िक्स इंजन का उपयोग करता है।  
Non‑Windows प्लेटफ़ॉर्म पर `fontconfig` लाइब्रेरी की आवश्यकता हो सकती है।

**Supported Platforms**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Unsupported Platforms**
- *Windows 11 ARM* (ARM64) — *Not currently under consideration*

{{%  alert  title="Notes"  color="primary"  %}}  
For Linux x64, GLIBC 2.23+ is required; for Linux ARM64, GLIBC 2.39+ is required. Systems such as CentOS 7 (GLIBC 2.14) are not supported. If you need to run Aspose.Slides on CentOS 7 or other incompatible systems (e.g., Alpine), please use the standard package: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे Microsoft PowerPoint स्थापित करने की आवश्यकता है रूपांतरण और रेंडरिंग के लिए?**

नहीं, PowerPoint आवश्यक नहीं है; Aspose.Slides एक स्वतंत्र इंजन है [creating](/slides/hi/net/create-presentation/), modifying, [converting](/slides/hi/net/convert-presentation/), और [rendering](/slides/hi/net/convert-powerpoint-to-png/) प्रस्तुतियों के लिए।

**सही रेंडरिंग के लिए कौन से फ़ॉन्ट्स आवश्यक हैं?**

प्रेज़ेंटेशन में प्रयुक्त फ़ॉन्ट्स, या उपयुक्त विकल्प, ऑपरेटिंग सिस्टम में उपलब्ध होने चाहिए। Linux और macOS पर सामान्य फ़ॉन्ट पैकेज स्थापित करें ताकि निरंतर रेंडरिंग सुनिश्चित हो सके।

Alpine Linux कंटेनरों में, `libgdiplus` के साथ कम से कम एक फ़ॉन्ट पैकेज स्थापित करें। अनुशंसित न्यूनतम सेटअप `libgdiplus` के साथ `ttf-dejavu` है। यदि Arial, Times New Roman, Courier New, या Verdana जैसे Microsoft फ़ॉन्ट्स आवश्यक हैं, तो `msttcorefonts-installer` को `fontconfig` के साथ उपयोग करें।

**Linux पर कस्टम फ़ॉन्ट फ़ॉलबैक या गायब टेक्स्ट क्यों दिखाता है?**

यदि फ़ॉन्ट फ़ाइल में name‑table प्रविष्टियां असंगत या भ्रष्ट हैं, तो Linux फ़ॉन्ट‑मैचिंग स्टैक (FreeType/fontconfig) एक अमान्य रिकॉर्ड चुन सकता है, जिससे फ़ॉन्ट अनसुलझा रह जाता है। सुधारित name‑table वाली फ़ॉन्ट फ़ाइल का उपयोग करना या सुसंगत विकल्प स्थापित करना समस्या को हल करता है।