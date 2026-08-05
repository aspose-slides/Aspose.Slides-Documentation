---
title: Aspose.Slides for .NET 6 क्रॉस‑प्लेटफ़ॉर्म (ZIP पैकेज)
type: docs
weight: 237
url: /hi/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- क्रॉस‑प्लेटफ़ॉर्म
- .NET 6
- GLIBC
- csproj
- लक्ष्य पथ
- निर्भर लाइब्रेरी
- Aspose.Slides.dll
- System.Drawing.Common
- नाम टकराव
- बाह्य उपनाम
- CS0433
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6 का उपयोग करके Windows, Linux, और macOS पर क्रॉस‑प्लेटफ़ॉर्म C# एप्लिकेशन बनाएं, जो PowerPoint PPT, PPTX और ODP फ़ाइलों को निर्माण, संपादन और रूपांतरण कर सकते हैं।"
---
## **परिचय**

यह लेख बताता है कि ZIP पैकेज से Aspose.Slides for .NET 6 Cross-Platform का उपयोग कैसे करें। यह वर्णन करता है कि पैकेज को कैसे डाउनलोड करें, `net6.0/crossplatform` फ़ोल्डर से फ़ाइलों को अनपैक करें, `Aspose.Slides.dll` का संदर्भ जोड़ें, और प्रोजेक्ट फ़ाइल को इस प्रकार कॉन्फ़िगर करें कि आवश्यक निर्भर लाइब्रेरीज़ को एप्लिकेशन आउटपुट डायरेक्टरी में कॉपी किया जाए।

लेख में क्रॉस‑प्लेटफ़ॉर्म पैकेज की सामग्री भी बताई गई है, जिसमें मुख्य Aspose.Slides .NET असेंबली और Windows, Linux, तथा macOS के लिए प्लेटफ़ॉर्म‑विशिष्ट ग्राफ़िक्स सबसिस्टम लाइब्रेरीज़ शामिल हैं।

{{% alert title="ध्यान दें" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform को [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) से भी प्राप्त किया जा सकता है।

{{% /alert %}}

## **ZIP पैकेज से क्रॉस‑प्लेटफ़ॉर्म Aspose.Slides का उपयोग करना**

1. नवीनतम Aspose.Slides का ZIP पैकेज [Release Page](https://releases.aspose.com/slides/hi/net/) से डाउनलोड करें।  

2. *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* से फ़ाइलें अनपैक करें और उन्हें अपने प्रोजेक्ट में निर्भरताओं के लिए उपयोग की जाने वाली फ़ोल्डर में रखें।  

3. Aspose.Slides.dll का एक रेफ़रेंस जोड़ें।

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   हमारे उदाहरण (नीचे) में लाइब्रेरीज़ प्रोजेक्ट फ़ोल्डर में इस पथ के अंतर्गत स्थित हैं: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. शेष फ़ाइलों (जिन पर Aspose.Slides निर्भर करता है) को आउटपुट डायरेक्टरी में रखने के लिए csproj प्रोजेक्ट फ़ाइल में इस प्रकार निर्देश जोड़ें:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. `TargetPath` पर ध्यान दें।

   डिफ़ॉल्ट रूप से, `<CopyToOutputDirectory>` फ़ाइलों को उनकी रिलेटिव पाथ को संरक्षित करते हुए कॉपी करता है, लेकिन हमें निर्भर लाइब्रेरीज़ को उसी फ़ोल्डर में ले जाना है जहाँ आउटपुट उत्पन्न होता है (Aspose.Slides.dll का स्थान)।

## **नोट्स**

### **स्वामित्व ग्राफ़िक्स सबसिस्टम**

Aspose.Slides क्रॉस‑प्लेटफ़ॉर्म निम्नलिखित लाइब्रेरीज़ का संग्रह है:

| Aspose.Slides.dll                                          | मुख्य .NET असेंबली जो सभी Aspose.Slides लॉजिक के लिए जिम्मेदार है |
| ---------------------------------------------------------- | ------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | निर्भरता: Win x64 के लिए ग्राफ़िक्स सबसिस्टम इम्प्लीमेंटेशन       |
| aspose.slides.drawing.capi_vc14x86.dll                     | निर्भरता: Win x64 के लिए ग्राफ़िक्स सबसिस्टम इम्प्लीमेंटेशन       |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | निर्भरता: Linux (x86/x64) के लिए ग्राफ़िक्स सबसिस्टम इम्प्लीमेंटेशन |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | निर्भरता: macOS AMD64 (x86-64/x64) के लिए ग्राफ़िक्स सबसिस्टम इम्प्लीमेंटेशन |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | निर्भरता: macOS ARM64 (AArch64) के लिए ग्राफ़िक्स सबसिस्टम इम्प्लीमेंटेशन |

Aspose.Slides.dll उस लाइब्रेरी का उपयोग करता है जो चल रहे सिस्टम द्वारा आवश्यक होती है। लाइब्रेरीज़ सामान्यतः Aspose.Slides.dll के समान स्थान पर किसी भी फाइल सिस्टम में स्थित होती हैं।

### **ZIP पैकेज संरचना**

ZIP पैकेज में निम्नलिखित फ़ोल्डर संरचना होती है:

Aspose.Slides
├─── net6.0
│   ├─── crossplatform
│   └─── default
├─── net20
├─── net462
└─── netstandard2.0

* प्रत्येक फ़ोल्डर उनकी संबंधित .NET संस्करण के लिए असेंबलीज़ रखता है। net6.0 के लिए दो संस्करण हैं: default और crossplatform। बाद वाला क्रॉस‑प्लेटफ़ॉर्म Aspose.Slides.dll और इसकी सभी निर्भरताएँ शामिल करता है। इस फ़ोल्डर की अनपैक्ड सामग्री को क्रॉस‑प्लेटफ़ॉर्म विकास और अन्य Aspose.Slides उपयोग मामलों के लिए प्रोजेक्ट में निर्भरता के रूप में जोड़ा जा सकता है।

## **संबंधित देखें**

- [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/)