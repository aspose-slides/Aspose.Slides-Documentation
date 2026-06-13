---
title: XAML में प्रस्तुतियों को निर्यात करना .NET में
linktitle: प्रस्तुति से XAML
type: docs
weight: 30
url: /hi/net/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- PowerPoint रूपांतरण
- OpenDocument रूपांतरण
- प्रस्तुति रूपांतरण
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT निर्यात XAML में
- PPTX निर्यात XAML में
- ODP निर्यात XAML में
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint और OpenDocument स्लाइड्स को XAML में बदलें—तेज़, Office-मुक्त समाधान जो आपका लेआउट बना रहता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने के तरीके को समझाता है। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन शामिल है, जिसमें छिपी हुई स्लाइड्स का निर्यात भी शामिल है। लेख फॉलबैक फ़ॉन्ट्स, XAML स्टैक संगतता और छिपी स्लाइड निर्यात व्यवहार से जुड़े कुछ सामान्य प्रश्नों के उत्तर भी देता है।

## **XAML के बारे में**

XAML एक वर्णनात्मक प्रोग्रामिंग भाषा है जो आपको ऐप्स के लिए उपयोगकर्ता इंटरफ़ेस बनाने या लिखने की अनुमति देती है, विशेषकर वे जो WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) और Xamarin Forms का उपयोग करते हैं।  

XAML, जो कि XML-आधारित भाषा है, GUI का वर्णन करने के लिए Microsoft का संस्करण है। आप अधिकांश समय XAML फ़ाइलों पर काम करने के लिए एक डिज़ाइनर का उपयोग करेंगे, लेकिन आप अपनी GUI को स्वयं लिख और संपादित भी कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुति निर्यात करना**

यह C# कोड आपको डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में निर्यात करने का तरीका दिखाता है:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **कस्टम विकल्पों के साथ XAML में प्रस्तुति निर्यात करना**

आप [IXamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/ixamloptions) इंटरफ़ेस से विकल्प चुनते हैं जो निर्यात प्रक्रिया को नियंत्रित करते हैं और तय करते हैं कि Aspose.Slides आपकी प्रस्तुति को XAML में कैसे निर्यात करता है।  

उदाहरण के लिए, यदि आप Aspose.Slides को XAML में निर्यात करते समय अपनी प्रस्तुति की छिपी हुई स्लाइड्स जोड़ना चाहते हैं, तो आप [ExportHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) प्रॉपर्टी को true पर सेट कर सकते हैं। इस नमूना C# कोड को देखें:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं पूर्वानुमेय फ़ॉन्ट कैसे सुनिश्चित कर सकता हूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/) में [DefaultRegularFont](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/defaultregularfont/) सेट करें — यह मूल फ़ॉन्ट के अनुपलब्ध होने पर फॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। इससे अप्रत्याशित प्रतिस्थापन से बचा जा सकता है।

**क्या निर्यात किया गया XAML केवल WPF के लिए ही है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

XAML एक सामान्य UI मार्कअप भाषा है जो WPF, UWP और Xamarin.Forms में उपयोग होती है। निर्यात Microsoft XAML स्टैक्स के साथ संगतता को लक्षित करता है; विशिष्ट निर्माणों के लिए सटीक व्यवहार और समर्थन लक्ष्य प्लेटफ़ॉर्म पर निर्भर करता है। अपने वातावरण में मार्कअप का परीक्षण करें।

**क्या छिपी स्लाइड्स समर्थित हैं, और डिफ़ॉल्ट रूप से उनका निर्यात कैसे रोकें?**

डिफ़ॉल्ट रूप से छिपी स्लाइड्स शामिल नहीं होती हैं। आप इसे [XamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/) में [ExportHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) के माध्यम से नियंत्रित कर सकते हैं — यदि आपको उनका निर्यात नहीं चाहिए तो इसे निष्क्रिय रखें।