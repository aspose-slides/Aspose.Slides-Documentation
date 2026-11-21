---
title: Android पर Handout मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java में प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड सेट करें, नोट्स रखें, Aspose.Slides for Android के साथ PDF या इमेजेज में निर्यात करें, नमूना कोड के साथ। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides प्रस्तुतियों को विभिन्न फ़ॉर्मैट में परिवर्तित करने की सुविधा प्रदान करता है, जिसमें Handout मोड में प्रिंटिंग के लिए हैंडआउट बनाना भी शामिल है। यह मोड आपको एक पृष्ठ पर कई स्लाइड्स कैसे प्रदर्शित हों, इसे कॉन्फ़िगर करने देता है, जो सम्मेलन, सेमिनार और अन्य घटनाओं के लिए उपयोगी है। आप `setSlidesLayoutOptions` मेथड को [IPdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) इंटरफ़ेसेज़ में सेट करके इस मोड को सक्षम कर सकते हैं।

एक्सपोर्ट के पहले हैंडआउट पेज का आकार और अभिविन्यास सेट करने के लिए, देखें [Notes Page Size](/slides/hi/androidjava/notes-size/)।

## **Handout मोड एक्सपोर्ट**

Handout मोड को कॉन्फ़िगर करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें, जो निर्धारित करता है कि एक पृष्ठ पर कितनी स्लाइड्स रखी जाएँगी और अन्य प्रदर्शन पैरामीटर।

नीचे एक कोड उदाहरण दिया गया है जो Handout मोड में प्रस्तुति को PDF में परिवर्तित करता है।

```java
import com.aspose.slides.*;

// प्रस्तुति लोड करें.
Presentation presentation = new Presentation("sample.pptx");
try {
	// निर्यात विकल्प सेट करें.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर 4 स्लाइड्स क्षैतिज रूप से
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // स्लाइड नंबर प्रिंट करें
	slidesLayoutOptions.setPrintFrameSlide(true);                     // स्लाइड्स के आसपास फ्रेम प्रिंट करें
	slidesLayoutOptions.setPrintComments(false);                      // कोई टिप्पणी नहीं

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// चयनित लेआउट के साथ प्रस्तुति को PDF में निर्यात करें।
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मैट जैसे PDF, HTML, TIFF, तथा इमेज़ रूप में रेंडरिंग के लिए उपलब्ध है।
{{% /alert %}} 

## **FAQ**

**Handout मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handouttype/) को समर्थन देता है, जो प्रति पृष्ठ अधिकतम 9 थंबनेल तक हो सकते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत), और 9 (क्षैतिज/लंबवत)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसी कस्टम ग्रिड परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को केवल [HandoutType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/handouttype/) क्लास द्वारा नियंत्रित किया जाता है; मनमाना लेआउट समर्थित नहीं है।

**क्या मैं Handout आउटपुट में छिपी स्लाइड्स शामिल कर सकता हूँ?**

हाँ। लक्ष्य फ़ॉर्मैट के एक्सपोर्ट सेटिंग्स में `setShowHiddenSlides` मेथड को सक्षम करके छिपी स्लाइड्स को शामिल करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/)।