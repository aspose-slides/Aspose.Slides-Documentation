---
title: हैंडआउट मोड में जावा का उपयोग करके पावरपॉइंट प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- हैंडआउट मोड
- हैंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा में प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइडों की संख्या निर्धारित करें, नोट्स रखें, Aspose.Slides के साथ PDF या इमेज़ में निर्यात करें, साथ में नमूना जावा कोड। इसे मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों को ऐसे आउटपुट फ़ॉर्मेट में बदलने देता है जो हैंडआउट मोड का समर्थन करते हैं। इस मोड में, कई स्लाइडें एक ही पृष्ठ पर व्यवस्थित की जाती हैं, जो सम्मेलनों, सेमिनारों और समान कार्यक्रमों के लिए प्रस्तुति सामग्री प्रिंट करने के लिए उपयोगी है।

हैंडआउट मोड को `setSlidesLayoutOptions` मेथड के माध्यम से कॉन्फ़िगर किया जाता है, जो [IPdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihtmloptions/) और [ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) में उपलब्ध है। हैंडआउट लेआउट को परिभाषित करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें।

एक्सपोर्ट से पहले हैंडआउट पृष्ठ के आयाम और अभिविन्यास सेट करने के लिए, देखें [Notes Page Size](/slides/hi/java/notes-size/)।

## **हैंडआउट मोड निर्यात**

हैंडआउट मोड में एक प्रस्तुति को निर्यात करने के लिए, लक्षित निर्यात विकल्पों के लिए `setSlidesLayoutOptions` मेथड सेट करें और एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handoutlayoutingoptions/) इंस्टेंस असाइन करें जो प्रति पृष्ठ स्लाइडों की संख्या और संबंधित प्रदर्शन पैरामीटर को परिभाषित करता है।

नीचे एक कोड उदाहरण दिया गया है जो दर्शाता है कि कैसे एक प्रस्तुति को हैंडआउट मोड में PDF में परिवर्तित किया जाता है।

```java
import com.aspose.slides.*;

// एक प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // निर्यात विकल्प सेट करें।
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइडें
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // स्लाइड नंबर प्रिंट करें
    slidesLayoutOptions.setPrintFrameSlide(true);                     // स्लाइडों के चारों ओर फ्रेम प्रिंट करें
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
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मेट्स के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और जब इमेज़ के रूप में रेंडर किया जाता है।
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हैंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handouttype/) को समर्थन देता है जो प्रति पृष्ठ अधिकतम 9 थंबनेल तक होते हैं, क्षैतिज या लंबवत क्रम में: 1, 2, 3, 4 (क्षैतिज/लंबवत), 6 (क्षैतिज/लंबवत) और 9 (क्षैतिज/लंबवत)।

**क्या मैं 5 या 8 स्लाइड प्रति पृष्ठ जैसी कस्टम ग्रिड परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को सख्ती से [HandoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handouttype/) क्लास द्वारा नियंत्रित किया जाता है; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं हैंडआउट आउटपुट में छिपी हुई स्लाइडें शामिल कर सकता हूँ?**

हाँ। लक्ष्य फ़ॉर्मेट के निर्यात सेटिंग्स में `setShowHiddenSlides` मेथड का उपयोग करके छुपी हुई स्लाइडें सक्षम करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/)।