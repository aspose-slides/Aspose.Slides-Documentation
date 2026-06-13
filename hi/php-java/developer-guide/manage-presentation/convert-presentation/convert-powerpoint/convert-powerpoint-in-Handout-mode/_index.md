---
title: PHP का उपयोग करके हैंडआउट मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रेज़ेंटेशन को परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "PHP में प्रस्तुतियों को हैंडआउट में परिवर्तित करें। प्रति पृष्ठ स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides for PHP के साथ PDF या इमेज में निर्यात करें, नमूना कोड सहित। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न फ़ॉर्मैट में प्रस्तुतियों को परिवर्तित करने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना शामिल है। यह मोड आपको एक पृष्ठ पर कई स्लाइड्स कैसे दिखें, इसे कॉन्फ़िगर करने की सुविधा देता है, जिससे यह सम्मेलनों, सेमिनारों और अन्य आयोजनों के लिए उपयोगी बनता है। आप इस मोड को `setSlidesLayoutOptions` मेथड को सेट करके सक्षम कर सकते हैं, जैसा कि [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/) क्लास में कर सकते हैं।

## **Handout Mode निर्यात**

Handout मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी और अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि Handout मोड में प्रस्तुति को PDF में कैसे बदलें।

```php
// एक प्रस्तुति लोड करें।
$presentation = new Presentation("sample.pptx");

// निर्यात विकल्प सेट करें।
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // स्लाइड नंबर प्रिंट करें
$slidesLayoutOptions->setPrintFrameSlide(true);                      // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
$slidesLayoutOptions->setPrintComments(false);                       // कोई टिप्पणी नहीं

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// चुने हुए लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 

ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट्स, जैसे PDF, HTML, TIFF, और जब छवियों के रूप में रेंडर किया जाता है, के लिए उपलब्ध है।

{{% /alert %}} 

## **FAQ**

**Handout मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handouttype/) का समर्थन करता है जिनमें अधिकतम 9 थंबनेल प्रति पृष्ठ हो सकते हैं, क्षैतिज या ऊर्ध्वाधर क्रम में: 1, 2, 3, 4 (क्षैतिज/ऊर्ध्वाधर), 6 (क्षैतिज/ऊर्ध्वाधर), और 9 (क्षैतिज/ऊर्ध्वाधर)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसे कस्टम ग्रिड को परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को सख्ती से [HandoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/handouttype/) क्लास द्वारा नियंत्रित किया जाता है; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड्स को शामिल कर सकता हूँ?**

हाँ। लक्ष्य फ़ॉर्मैट के निर्यात सेटिंग्स में, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tiffoptions/), `setShowHiddenSlides` मेथड को सक्षम करके छिपी हुई स्लाइड्स को शामिल करें।