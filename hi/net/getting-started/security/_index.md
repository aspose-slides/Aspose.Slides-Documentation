---
title: सुरक्षा
type: docs
weight: 160
url: /hi/net/security/
keywords:
- सुरक्षा
- निर्भरताएँ
- तृतीय‑पक्ष घटक
- NuGet
- भेद्यता स्कैनिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "समिक्षा करें कि Aspose.Slides for .NET प्रस्तुतियों को कैसे प्रोसेस करता है, प्रत्येक लक्ष्य फ्रेमवर्क के लिए वह किन NuGet पैकेजों पर निर्भर करता है, और वह कौन से तृतीय‑पक्ष घटक शामिल करता है।"
---
## **Aspose.Slides में सुरक्षा**

Aspose अपने उत्पादों को विकसित करते समय सर्वोत्तम प्रथाओं को अपनाता है।

* Aspose.Slides for .NET का उपयोग प्रस्तुतियों को बदलने और उन्हें अन्य स्वरूपों में बदलने के लिए किया जाता है। यह प्रस्तुतियों में स्क्रिप्ट नहीं चलाता। Aspose.Slides प्रस्तुति संरचना को पार्स करता है और अंतिम उपयोगकर्ता के कोड को ऑब्जेक्ट मॉडल को सुविधाजनक तरीके से संचालित करने देता है।
* Aspose.Slides एक लाइब्रेरी के रूप में कार्य करता है जो दस्तावेज़ों को पार्स और व्याख्या करता है बिना रिमोट कोड को निष्पादित किए। सभी Aspose उत्पाद आपके मशीनों पर चलते हैं। वे Aspose को कोई डेटा नहीं भेजते। एकमात्र अपवाद है एक [metered license](https://purchase.aspose.com/faqs/licensing/metered): यदि आप इसे उपयोग करते हैं, तो केवल आपके API उपयोग जानकारी को प्रोसेस किया जाता है।
* Aspose घटक सामान्य अनुप्रयोगों के समान उपयोगकर्ता संदर्भ में चलते हैं। इसलिए, Aspose घटकों से महत्वपूर्ण सिस्टम संसाधनों को जोखिम नहीं होता। इसके अलावा, जब कोई Aspose घटक दस्तावेज़ खोलता है, तो मैक्रो स्वचालित रूप से नहीं चलते।
* Microsoft Office पैकेज से संबंधित जोखिम Aspose घटकों पर लागू नहीं होते, इसलिए Aspose उत्पाद बहुत सुरक्षित हैं।

## **NuGet निर्भरताएँ**

Aspose.Slides for .NET उन पैकेजों पर निर्भर करता है जो Microsoft NuGet पर प्रकाशित करता है। निर्भरताएँ पैकेज और लक्ष्य फ्रेमवर्क के अनुसार अलग-अलग होती हैं:

| पैकेज | लक्ष्य फ्रेमवर्क | निर्भरताएँ |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

**Dependencies** अनुभाग में [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) और [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) पृष्ठों पर NuGet में प्रत्येक रिलीज़ के लिए प्रत्येक निर्भरता के न्यूनतम संस्करण की सूची दी गई है।

जब आप अपने प्रोजेक्ट में Aspose.Slides जोड़ते हैं, तो NuGet इन पैकेजों की निर्भरताओं को भी पुनर्स्थापित करता है। प्रत्येक पैकेज की सूची, जिसमें ये ट्रांज़िटिव निर्भरताएँ भी शामिल हैं, प्राप्त करने के लिए प्रोजेक्ट फ़ोल्डर में यह कमांड चलाएँ:

```bash
dotnet list package --include-transitive
```

इसी सेट के पैकेजों को ज्ञात कमजोरियों के विरुद्ध जांचने के लिए चलाएँ:

```bash
dotnet list package --vulnerable --include-transitive
```

NuGet पैकेजों की ऑडिटिंग के अन्य तरीकों के लिए देखें [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages)।

## **तृतीय‑पक्ष घटक**

Aspose.Slides में तृतीय‑पक्ष ओपन‑सोर्स घटकों का कोड सम्मिलित है। वे उत्पाद का भाग हैं, अलग NuGet पैकेज नहीं हैं, इसलिए केवल NuGet निर्भरताओं को पढ़ने वाले उपकरण उन्हें सूचीबद्ध नहीं करते। दोनों पैकेजों में फ़ाइल *thirdpartylicenses.Aspose.Slides.for.NET.pdf* होती है, जिसमें घटकों और उनके लाइसेंस की सूची दी गई है:

| घटक | परिचय में उल्लिखित लाइसेंस |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose कोड में कमजोरियों की निगरानी के लिए कौन से सिस्टम उपयोग किए जाते हैं?**

हम प्रत्येक Aspose.Slides रिलीज़ के लिए स्थैतिक कोड विश्लेषण चलाते हैं। हम सुरक्षा रिपोर्ट प्रदान कर सकते हैं जो साबित करती हैं कि Aspose.Slides कोड OWASP टॉप 10 पास करता है।

**क्या Aspose.Slides बाहरी पैकेजों का उपयोग करता है?**

हां। यह [NuGet Dependencies](#nuget-dependencies) में सूचीबद्ध Microsoft NuGet पैकेजों पर निर्भर करता है, और इसमें [Third-Party Components](#third-party-components) में सूचीबद्ध तृतीय‑पक्ष घटक शामिल हैं। दोनों को अपनी सुरक्षा समीक्षा में शामिल करें, और `dotnet list package --vulnerable --include-transitive` का उपयोग करके उन NuGet पैकेजों को जांचें जो आपका प्रोजेक्ट पुनर्स्थापित करता है।