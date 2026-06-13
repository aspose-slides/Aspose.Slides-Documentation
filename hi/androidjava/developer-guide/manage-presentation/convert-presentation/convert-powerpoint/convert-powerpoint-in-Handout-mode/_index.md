---
title: Android पर Handout मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: Handout मोड
type: docs
weight: 150
url: /hi/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint रूपांतरण
- प्रेजेंटेशन रूपांतरण
- Handout मोड
- Handout
- PPT
- PPTX
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Java में प्रस्तुतियों को Handout में बदलें। पृष्ठ पर स्लाइड्स सेट करें, नोट्स रखें, Aspose.Slides for Android के साथ PDF या छवियों में निर्यात करें, नमूना कोड के साथ। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न फ़ॉर्मैट में प्रस्तुतियों को कनवर्ट करने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना शामिल है। यह मोड आपको कई स्लाइड्स को एक पेज पर कैसे दिखाया जाए, इसे कॉन्फ़िगर करने देता है, जिससे यह सम्मेलन, सेमिनार और अन्य कार्यक्रमों के लिए उपयोगी होता है। आप इस मोड को `setSlidesLayoutOptions` मेथड को सेट करके सक्रिय कर सकते हैं, जो [IPdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihtmloptions/) और [ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) इंटरफ़ेस में है।

## **हैंडआउट मोड निर्यात**

Handout मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग कर सकते हैं, जो निर्धारित करता है कि एक पेज पर कितनी स्लाइड्स रखी जाएँगी और अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि Handout मोड में प्रस्तुति को PDF में कैसे बदलें।

```java
// एक प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
	// निर्यात विकल्प सेट करें।
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // स्लाइड नंबर प्रिंट करें
	slidesLayoutOptions.setPrintFrameSlide(true);                     // स्लाइड्स के चारों ओर एक फ्रेम प्रिंट करें
	slidesLayoutOptions.setPrintComments(false);                      // कोई टिप्पणी नहीं

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// चुने हुए लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब छवियों के रूप में रेंडर किया जाता है। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handouttype/) का समर्थन करता है जो एक पृष्ठ पर अधिकतम 9 थंबनेल तक हो सकते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत), और 9 (क्षैतिज/लंबवत).  

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसी कस्टम ग्रिड निर्धारित कर सकता/सकती हूँ?**

नहीं। थंबनेल की संख्या और क्रम पूरी तरह से [HandoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handouttype/) क्लास द्वारा नियंत्रित होते हैं; मनमाने लेआउट समर्थित नहीं हैं।  

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता/सकती हूँ?**

हाँ। लक्ष्य फ़ॉर्मैट के लिए निर्यात सेटिंग्स में `setShowHiddenSlides` मेथड का उपयोग करके छिपी हुई स्लाइड्स को सक्रिय करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/htmloptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/).