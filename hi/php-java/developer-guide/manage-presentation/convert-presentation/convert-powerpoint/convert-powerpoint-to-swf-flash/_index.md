---
title: PHP में PowerPoint प्रस्तुतियों को SWF Flash में परिवर्तित करें
linktitle: PowerPoint से SWF
type: docs
weight: 80
url: /hi/php-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से SWF
- प्रस्तुति से SWF
- स्लाइड से SWF
- PPT से SWF
- PPTX से SWF
- PowerPoint से Flash
- प्रस्तुति से Flash
- स्लाइड से Flash
- PPT से Flash
- PPTX से Flash
- PPT को SWF के रूप में सहेजें
- PPTX को SWF के रूप में सहेजें
- PPT को SWF में निर्यात करें
- PPTX को SWF में निर्यात करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में PowerPoint (PPT/PPTX) को SWF Flash में परिवर्तित करें। चरण‑दर‑चरण कोड नमूने, तेज गुणवत्ता आउटपुट, कोई PowerPoint ऑटोमेशन नहीं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को SWF में परिवर्तित करने के तरीके को समझाता है। यह दिखाता है कि प्रस्तुति को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/save/) विधि से SWF फ़ाइल के रूप में कैसे सहेजा जाए और निर्यात को [SwfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/) के साथ कैसे कॉन्फ़िगर किया जाए, जिसमें व्यूअर सेटिंग्स और नोट्स या टिप्पणी लेआउट शामिल हैं।

## **प्रेज़ेंटेशन को फ़्लैश में रूपांतरित करें**

The [save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/save/) method exposed by the [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class can be used to convert the whole presentation into an **SWF** document. The following example shows how to convert a presentation into an **SWF** document by using the options provided by the [SWFOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/) class. You can also include comments in the generated SWF by using the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/notescommentslayoutingoptions/) class.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # प्रस्तुति सहेज रहा है
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **प्रश्नोत्तर**

**क्या मैं SWF में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हां। छिपी स्लाइड्स को सक्षम करने के लिए [setShowHiddenSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/setshowhiddenslides/) विधि को [SwfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/) में उपयोग करें। डिफ़ॉल्ट रूप से, छिपी स्लाइड्स निर्यात नहीं की जाती हैं।

**मैं संपीड़न और अंतिम SWF आकार को कैसे नियंत्रित कर सकूँ?**

[setCompressed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/setcompressed/) विधि और [adjust JPEG quality](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/setjpegquality/) का उपयोग करके फ़ाइल आकार और छवि गुणवत्ता के बीच संतुलन बनाएं।

**'setViewerIncluded' का उद्देश्य क्या है, और मुझे इसे कब अक्षम करना चाहिए?**

[setViewerIncluded](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/setviewerincluded/) एक एम्बेडेड प्लेयर UI (नेविगेशन नियंत्रण, पैनल, खोज) जोड़ता है। यदि आप अपना प्लेयर उपयोग करने की योजना बनाते हैं या UI के बिना शुद्ध SWF फ्रेम चाहते हैं तो इसे अक्षम कर दें।

**यदि निर्यात मशीन पर स्रोत फ़ॉन्ट अनुपलब्ध है तो क्या होता है?**

Aspose.Slides [SwfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/swfoptions/) में [setDefaultRegularFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) द्वारा निर्दिष्ट फ़ॉन्ट को प्रतिस्थापित करेगा ताकि अनपेक्षित फ़ॉन्ट परिवर्तन से बचा जा सके।