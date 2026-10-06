---
title: "JavaScript का उपयोग करके हैंडआउट मोड में PowerPoint प्रस्तुतियों को रूपांतरित करें"
linktitle: "हैंडआउट मोड"
type: docs
weight: 150
url: /hi/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- "PowerPoint रूपांतरित करें"
- "प्रस्तुति रूपांतरित करें"
- "हैंडआउट मोड"
- "हैंडआउट"
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides for Node.js के साथ PDF या इमेजेज में निर्यात करें, नमूना कोड सहित। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों को विभिन्न स्वरूपों में परिवर्तित करने की सुविधा प्रदान करता है, जिसमें Handout मोड में प्रिंट करने के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको कई स्लाइड्स को एक पृष्ठ पर कैसे दिखाना है, इसे कॉन्फ़िगर करने की अनुमति देता है, जिससे यह सम्मेलन, सेमिनार और अन्य कार्यक्रमों के लिए उपयोगी बनता है। आप इस मोड को `setSlidesLayoutOptions` मेथड को [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/), और [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लासों में सेट करके सक्षम कर सकते हैं।

एक्सपोर्ट से पहले हैंडआउट पेज की आयाम और अभिविन्यास सेट करने के लिए, देखें [Notes Page Size](/slides/hi/nodejs-java/notes-size/).

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड को कॉन्फ़िगर करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी और अन्य डिस्प्ले पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि हैंडआउट मोड में एक प्रस्तुति को PDF में कैसे परिवर्तित किया जाए।

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation. // प्रस्तुति लोड करें.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर 4 स्लाइड्स क्षैतिज रूप से
slidesLayoutOptions.setPrintSlideNumbers(true);                                // स्लाइड नंबर प्रिंट करें
slidesLayoutOptions.setPrintFrameSlide(true);                                  // स्लाइड्स के आसपास फ्रेम प्रिंट करें
slidesLayoutOptions.setPrintComments(false);                                   // कोई टिप्पणी नहीं

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मेट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेजेस के रूप में रेंडर किया जा रहा हो।
{{% /alert %}} 

## **अक्सर पूछे गये प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handouttype/) का समर्थन करता है जो प्रति पृष्ठ अधिकतम 9 थंबनेल तक हैं, हरीफ़़ज़ी या वर्टिकल क्रम में: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसी कस्टम ग्रिड निर्धारित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को [HandoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handouttype/) एन्यूमरेशन द्वारा सख्ती से नियंत्रित किया जाता है; मनमाने लेआउट का समर्थन नहीं किया जाता।

**क्या मैं हैंडआउट आउटपुट में छिपी स्लाइड्स को शामिल कर सकता हूँ?**

हाँ। लक्ष्य फ़ॉर्मेट के एक्सपोर्ट सेटिंग्स में `setShowHiddenSlides` मेथड का उपयोग करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/).