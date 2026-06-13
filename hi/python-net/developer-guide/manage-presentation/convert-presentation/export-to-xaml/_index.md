---
title: Python के साथ XAML में प्रस्तुतियों का निर्यात
linktitle: XAML में निर्यात
type: docs
weight: 30
url: /hi/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में PowerPoint और OpenDocument स्लाइड्स को XAML में बदलें—तेज़, Office-रहित समाधान जो आपका लेआउट अपरिवर्तित रखता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने की प्रक्रिया को समझाता है। यह XAML का एक संक्षिप्त परिचय शामिल करता है, दिखाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे सहेजा जाए, और [XamlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/) के माध्यम से निर्यात को कैसे अनुकूलित किया जाए, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। यह लेख फॉलबैक फ़ॉन्ट्स, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी देता है।

## **XAML के बारे में**

XAML एक वर्णनात्मक प्रोग्रामिंग भाषा है जो आपको ऐप्स के लिए उपयोगकर्ता इंटरफ़ेस बनाने या लिखने की अनुमति देती है, विशेष रूप से उन ऐप्स के लिए जो WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin Forms का उपयोग करते हैं।  
XAML, जो एक XML-आधारित भाषा है, माइक्रोसॉफ्ट का GUI वर्णन करने वाला रूपांतर है। आप अधिकांश समय XAML फ़ाइलों पर काम करने के लिए डिज़ाइनर का उपयोग करेंगे, लेकिन आप अभी भी अपना GUI लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

यह Python कोड आपको दिखाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे निर्यात किया जाए:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

आप [XamlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/) क्लास से विकल्प चुन सकते हैं जो निर्यात प्रक्रिया को नियंत्रित करते हैं और निर्धारित करते हैं कि Aspose.Slides आपकी प्रस्तुति को XAML में कैसे निर्यात करता है।  

उदाहरण के लिए, यदि आप चाहते हैं कि Aspose.Slides XAML में निर्यात करते समय आपकी प्रस्तुति से छिपी स्लाइडें जोड़ दे, तो आप [export_hidden_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) प्रॉपर्टी को `True` पर सेट कर सकते हैं। इस उदाहरण Python कोड को देखें:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं पूर्वानुमेय फ़ॉन्ट कैसे सुनिश्चित कर सकता हूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/) में [default_regular_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) को सेट करें — यह मूल फ़ॉन्ट के अनुपलब्ध होने पर फॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। यह अप्रत्याशित प्रतिस्थापन से बचाता है।

**क्या निर्यात किया गया XAML केवल WPF के लिए ही है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

XAML एक सामान्य UI मार्कअप भाषा है जो WPF, UWP, और Xamarin.Forms में उपयोग होती है। निर्यात Microsoft XAML स्टैक्स के साथ संगतता को लक्षित करता है; विशिष्ट व्यवहार और विशिष्ट निर्माणों का समर्थन लक्ष्य प्लेटफ़ॉर्म पर निर्भर करता है। अपने वातावरण में मार्कअप का परीक्षण करें।

**क्या छिपी स्लाइडें समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोक सकता हूँ?**

डिफ़ॉल्ट रूप से, छिपी स्लाइडें शामिल नहीं की जाती हैं। आप इस व्यवहार को [XamlOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/) में [export_hidden_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) के माध्यम से नियंत्रित कर सकते हैं — यदि आपको उनकी निर्यात की आवश्यकता नहीं है तो इसे अक्षम रखें।