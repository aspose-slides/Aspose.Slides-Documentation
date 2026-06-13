---
title: JavaScript का उपयोग करके Handout मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: Handout मोड
type: docs
weight: 150
url: /hi/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "प्रस्तुतियों को हैंडआउट में परिवर्तित करें। प्रति पृष्ठ स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides for Node.js के साथ PDF या इमेजेज में निर्यात करें, नमूना कोड के साथ। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न प्रारूपों में प्रस्तुतियों को बदलने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको यह कॉन्फ़िगर करने देता है कि कई स्लाइड्स एक पृष्ठ पर कैसे प्रदर्शित होती हैं, जिससे यह सम्मेलनों, सेमिनारों और अन्य कार्यक्रमों के लिए उपयोगी बनता है। आप इस मोड को `setSlidesLayoutOptions` मेथड को सेट करके सक्षम कर सकते हैं, जो [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/) , [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/) , [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) और [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लासेस में उपलब्ध है।

## **हैंडआउट मोड निर्यात**

Handout मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी और अन्य डिस्प्ले पैरामीटर।  

नीचे एक कोड उदाहरण दिया गया है जो Handout मोड में प्रस्तुति को PDF में बदलना दर्शाता है।

```js
// प्रस्तुतीकरण लोड करें।
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
slidesLayoutOptions.setPrintSlideNumbers(true);                                // स्लाइड नंबर प्रिंट करें
slidesLayoutOptions.setPrintFrameSlide(true);                                  // स्लाइड्स के आसपास एक फ्रेम प्रिंट करें
slidesLayoutOptions.setPrintComments(false);                                   // कोई टिप्पणी नहीं

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट्स में उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेज के रूप में रेंडर किया जाता है। 
{{% /alert %}} 

## **सामान्य प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल्स की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handouttype/) के माध्यम से प्रति पृष्ठ अधिकतम 9 थंबनेल्स का समर्थन करता है, जिसमें क्षैतिज या ऊर्ध्वाधर क्रम शामिल हैं: 1, 2, 3, 4 (क्षैतिज/ऊर्ध्वाधर), 6 (क्षैतिज/ऊर्ध्वाधर), और 9 (क्षैतिज/ऊर्ध्वाधर)।  

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसी कस्टम ग्रिड को परिभाषित कर सकता हूँ?**

नहीं। थंबनेल्स की संख्या और क्रम को [HandoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handouttype/) एन्यूमरेशन द्वारा सख्ती से नियंत्रित किया जाता है; मनमाने लेआउट को समर्थन नहीं दिया जाता।  

**क्या मैं Handout आउटपुट में छुपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हां। लक्ष्य फ़ॉर्मैट के निर्यात सेटिंग्स में `setShowHiddenSlides` मेथड का उपयोग करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/) , [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/)।