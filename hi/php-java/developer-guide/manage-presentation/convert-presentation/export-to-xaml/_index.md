---
title: PHP में XAML में प्रस्तुतियों का निर्यात
linktitle: प्रस्तुति से XAML
type: docs
weight: 30
url: /hi/php-java/export-to-xaml/
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
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP को Java के माध्यम से उपयोग करके PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें — तेज़, Office‑मुक्त समाधान जो आपके लेआउट को अपरिवर्तित रखता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने के तरीके को बताता है। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुतियों को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन शामिल है, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। लेख कुछ सामान्य प्रश्नों के उत्तर भी देता है, जैसे फॉलबैक फ़ॉन्ट, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार।

## **XAML के बारे में**

XAML एक वर्णनात्मक प्रोग्रामिंग भाषा है जो आपको ऐप्स के लिए उपयोगकर्ता इंटरफ़ेस बनाने या लिखने की अनुमति देती है, विशेष रूप से उन ऐप्स के लिए जो WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin Forms का उपयोग करते हैं।  

XAML, जो XML‑आधारित भाषा है, माइक्रोसॉफ्ट की GUI वर्णन करने वाली प्रजाति है। आप अधिकांश समय XAML फ़ाइलों पर काम करने के लिए एक डिज़ाइनर का उपयोग करेंगे, लेकिन आप अभी भी अपना GUI लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

यह PHP कोड आपको दिखाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे निर्यात किया जाए:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों का निर्यात**

आप [XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) क्लास से विकल्प चुन सकते हैं जो निर्यात प्रक्रिया को नियंत्रित करते हैं और निर्धारित करते हैं कि Aspose.Slides आपकी प्रस्तुति को XAML में कैसे निर्यात करता है।

उदाहरण के लिए, यदि आप Aspose.Slides को निर्यात के दौरान आपकी प्रस्तुति की छिपी स्लाइडें जोड़ना चाहते हैं, तो आप [setExportHiddenSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/setexporthiddenslides/) मेथड को मान `true` के साथ उपयोग कर सकते हैं। इस नमूना PHP कोड को देखें:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं पूर्वनिर्धारित फ़ॉन्ट कैसे सुनिश्चित कर सकता हूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) में [डिफ़ॉल्ट नियमित फ़ॉन्ट](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) सेट करें — यह मूल फ़ॉन्ट अनुपलब्ध होने पर फॉलबैक फ़ॉन्ट के रूप में प्रयोग होता है। यह अनपेक्षित प्रतिस्थापन से बचाता है।

**क्या निर्यात किया गया XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

XAML एक सामान्य UI मार्कअप भाषा है जो WPF, UWP, और Xamarin.Forms में उपयोग होती है। निर्यात का लक्ष्य माइक्रोसॉफ्ट XAML स्टैक्स के साथ संगतता है; सटीक व्यवहार और विशिष्ट संरचनाओं का समर्थन लक्ष्य प्लेटफ़ॉर्म पर निर्भर करता है। अपने परिवेश में मार्कअप का परीक्षण करें।

**क्या छिपी स्लाइडें समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोकें?**

डिफ़ॉल्ट रूप से, छिपी स्लाइडें शामिल नहीं की जातीं। आप इस व्यवहार को [setExportHiddenSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/setexporthiddenslides/) को [XamlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/xamloptions/) में सेट करके नियंत्रित कर सकते हैं — यदि आपको इन्हें निर्यात करने की आवश्यकता नहीं है तो इसे निष्क्रिय रखें।