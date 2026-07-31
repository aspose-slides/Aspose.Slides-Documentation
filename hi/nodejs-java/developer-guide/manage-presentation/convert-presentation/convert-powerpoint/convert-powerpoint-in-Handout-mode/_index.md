---
title: Handout मोड में PowerPoint प्रस्तुतियों को JavaScript का उपयोग करके बदलें
linktitle: Handout मोड
type: docs
weight: 150
url: /hi/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- handout मोड
- handout
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड सेट करें, नोट्स रखें, Aspose.Slides for Node.js के साथ PDF या छवियों में निर्यात करें, उदाहरण कोड के साथ। इसे मुफ्त में आज़माएँ।"
---
## **Introduction**

Aspose.Slides प्रस्तुतियों को विभिन्न फ़ॉर्मैट में बदलने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको एक पृष्ठ पर कई स्लाइड्स कैसे दिखें, इसे कॉन्फ़िगर करने की अनुमति देता है, जिससे यह सम्मेलनों, सेमिनारों और अन्य कार्यक्रमों के लिए उपयोगी बनता है। आप `setSlidesLayoutOptions` मेथड को [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लासों में सेट करके इस मोड को सक्षम कर सकते हैं।

## **Handout मोड निर्यात**

Handout मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी और अन्य डिस्प्ले पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो Handout मोड में प्रस्तुति को PDF में बदलने को दर्शाता है।

```js
// एक प्रस्तुति लोड करें।
let presentation = new asposeSlides.Presentation("sample.pptx");

// निर्यात विकल्प सेट करें।
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर 4 स्लाइड क्षैतिज रूप से
slidesLayoutOptions.setPrintSlideNumbers(true);                                // स्लाइड नंबर प्रिंट करें
slidesLayoutOptions.setPrintFrameSlide(true);                                  // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
slidesLayoutOptions.setPrintComments(false);                                   // कोई टिप्पणी नहीं

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट्स जैसे PDF, HTML, TIFF, और छवियों के रूप में रेंडरिंग के लिए ही उपलब्ध है।
{{% /alert %}} 

## **FAQ**

**Handout मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handouttype/) का समर्थन करता है, जिसमें प्रति पृष्ठ अधिकतम 9 थंबनेल क्षैतिज या लंबवत क्रम में हो सकते हैं: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत) और 9 (क्षैतिज/लंबवत)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसे कस्टम ग्रिड को परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम कड़ाई से [HandoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handouttype/) एनीमरेशन द्वारा नियंत्रित होते हैं; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हां। लक्ष्य फ़ॉर्मेट के निर्यात सेटिंग्स में, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/), `setShowHiddenSlides` मेथड का उपयोग करें।