---
title: PHP का उपयोग करके Handout मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: Handout मोड
type: docs
weight: 150
url: /hi/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रेज़ेंटेशन परिवर्तित करें
- Handout मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "PHP में प्रस्तुतियों को हैंडआउट में बदलें। स्लाइड्स प्रति पृष्ठ सेट करें, नोट्स रखें, Aspose.Slides for PHP के साथ PDF या इमेजेज़ में निर्यात करें, नमूना कोड के साथ। मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों को विभिन्न स्वरूपों में परिवर्तित करने की सुविधा प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना शामिल है। यह मोड आपको कॉन्फ़्रेंस, सेमिनार और अन्य आयोजनों के लिए एक ही पृष्ठ पर कई स्लाइड्स कैसे दिखाई दें, इसे कॉन्फ़िगर करने की अनुमति देता है। आप इस मोड को `setSlidesLayoutOptions` मेथड को [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास में सेट करके सक्षम कर सकते हैं।

## **Handout Mode Export**

Handout मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग कर सकते हैं, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी और अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि कैसे प्रस्तुति को Handout मोड में PDF में परिवर्तित किया जाए।

```php
// एक प्रस्तुति लोड करें।
$presentation = new Presentation("sample.pptx");

// निर्यात विकल्प सेट करें।
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // एक पृष्ठ पर 4 स्लाइड्स क्षैतिज रूप में
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // स्लाइड नंबर प्रिंट करें
$slidesLayoutOptions->setPrintFrameSlide(true);                      // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
$slidesLayoutOptions->setPrintComments(false);                       // कोई टिप्पणी नहीं

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// चयनित लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 

ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेजेज़ के रूप में रेंडर किया जाता है।

{{% /alert %}} 

## **FAQ**

**Handout मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल्स की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handouttype/) का समर्थन करता है जो प्रति पृष्ठ अधिकतम 9 थंबनेल्स हो सकते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical)।

**क्या मैं कस्टम ग्रिड, जैसे 5 या 8 स्लाइड्स प्रति पृष्ठ, परिभाषित कर सकता हूँ?**

नहीं। थंबनेल्स की संख्या और क्रम पूरी तरह से [HandoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handouttype/) क्लास द्वारा नियंत्रित होते हैं; मनमाना लेआउट समर्थित नहीं है।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हाँ। लक्षित फ़ॉर्मैट के लिए निर्यात सेटिंग्स में `setShowHiddenSlides` मेथड को सक्षम करें, जैसे [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) में।