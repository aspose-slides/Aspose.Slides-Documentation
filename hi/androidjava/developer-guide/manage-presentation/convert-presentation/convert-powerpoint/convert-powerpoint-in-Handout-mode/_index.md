---
title: Android पर Handout मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: Handout मोड
type: docs
weight: 150
url: /hi/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java में प्रस्तुतियों को हैंडआउट में परिवर्तित करें। प्रति पृष्ठ स्लाइड सेट करें, नोट्स रखें, Aspose.Slides for Android के साथ PDF या इमेज में निर्यात करें, साथ में नमूना कोड। मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides विभिन्न फ़ॉर्मैट में प्रस्तुतियों को कंवर्ट करने की क्षमता प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको एक पेज पर कई स्लाइड्स कैसे दिखाई दें, इसे कॉन्फ़िगर करने देता है, जिससे यह सम्मेलनों, सेमिनारों और अन्य कार्यक्रमों के लिए उपयोगी बन जाता है। आप इस मोड को `setSlidesLayoutOptions` मेथड को सेट करके सक्षम कर सकते हैं, जो कि [IPdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) इंटरफ़ेसेज़ में उपलब्ध है।

## **Handout मोड निर्यात**

Handout मोड को कॉन्फ़िगर करने के लिए, आप [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पेज पर कितनी स्लाइड्स रखी जाएँगी और अन्य डिस्प्ले पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि Handout मोड में प्रस्तुति को PDF में कैसे कंवर्ट किया जाता है।

```java
// प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
	// निर्यात विकल्प सेट करें।
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // स्लाइड नंबर प्रिंट करें
	slidesLayoutOptions.setPrintFrameSlide(true);                     // स्लाइड्स के आसपास एक फ्रेम प्रिंट करें
	slidesLayoutOptions.setPrintComments(false);                      // कोई टिप्पणी नहीं

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// चयनित लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 

ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट जैसे PDF, HTML, TIFF, और जब इमेज के रूप में रेंडर किया जाता है, के लिए उपलब्ध है। 

{{% /alert %}} 

## **प्रायः पूछे जाने वाले प्रश्न**

**Handout मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handouttype/) का समर्थन करता है जो अधिकतम 9 थंबनेल प्रति पृष्ठ प्रदान करते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत) और 9 (क्षैतिज/लंबवत)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पेज जैसी कस्टम ग्रिड परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को सख्ती से [HandoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handouttype/) क्लास द्वारा नियंत्रित किया जाता है; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं Handout आउटपुट में छुपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हां। लक्ष्य फ़ॉर्मैट के निर्यात सेटिंग्स में, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/), `setShowHiddenSlides` मेथड को सक्षम करके छुपी हुई स्लाइड्स को शामिल किया जा सकता है।