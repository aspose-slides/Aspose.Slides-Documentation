---
title: PHP का उपयोग करके हैंडआउट मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides for PHP के साथ PDF या इमेज़ में निर्यात करें, नमूना कोड सहित। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों को विभिन्न स्वरूपों में बदलने की सुविधा प्रदान करता है, जिसमें Handout मोड में प्रिंट करने के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको कॉन्फ़्रेंस, सेमिनार और अन्य कार्यक्रमों के लिए उपयोगी बनाते हुए, एक पृष्ठ पर कई स्लाइड्स को कैसे दिखाया जाएगा इसे कॉन्फ़िगर करने की अनुमति देता है। आप इस मोड को `setSlidesLayoutOptions` मेथड को सेट करके सक्रिय कर सकते हैं, जो [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लासेज़ में उपलब्ध है।

निर्यात से पहले हैंडआउट पेज के आयाम और अभिविन्यास सेट करने के लिए, देखें [नोट्स पेज आकार](/slides/hi/php-java/notes-size/)।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी तथा अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि कैसे प्रस्तुति को Handout मोड में PDF में परिवर्तित किया जाए।

```php
// एक प्रस्तुति लोड करें।
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // स्लाइड नंबर प्रिंट करें
$slidesLayoutOptions->setPrintFrameSlide(true);                      // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
$slidesLayoutOptions->setPrintComments(false);                       // कोई टिप्पणी नहीं

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेज़ के रूप में रेंडर किया जाए।
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handouttype/) का समर्थन करता है, जिससे एक पृष्ठ पर अधिकतम 9 थंबनेल क्षैतिज या लंबवत क्रम में रखे जा सकते हैं: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical).

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसी कस्टम ग्रिड परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को पूरी तरह से [HandoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handouttype/) क्लास द्वारा नियंत्रित किया जाता है; मनमाने लेआउट का समर्थन नहीं किया जाता।

**क्या मैं हैंडआउट आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हां। लक्ष्य फ़ॉर्मैट के निर्यात सेटिंग्स में `setShowHiddenSlides` मेथड का उपयोग करके छिपी हुई स्लाइड्स को सक्षम किया जा सकता है, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/).