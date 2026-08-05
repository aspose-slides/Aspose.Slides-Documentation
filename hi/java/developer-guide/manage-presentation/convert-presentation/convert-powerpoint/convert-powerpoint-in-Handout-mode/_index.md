---
title: जावा का उपयोग करके हेंडआउट मोड में PowerPoint प्रस्तुतियों को परिवर्तित करें
linktitle: हेंडआउट मोड
type: docs
weight: 150
url: /hi/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- हेंडआउट मोड
- हेंडआउट
- PPT
- PPTX
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा में प्रस्तुतियों को हेंडआउट में परिवर्तित करें। प्रति पृष्ठ स्लाइडों को सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या छवियों में निर्यात करें, साथ में नमूना जावा कोड। मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों को ऐसे आउटपुट प्रारूपों में परिवर्तित करने देता है जो हेंडआउट मोड का समर्थन करते हैं। इस मोड में, कई स्लाइड्स एक ही पृष्ठ पर व्यवस्थित की जाती हैं, जो सम्मेलनों, सेमिनारों और समान आयोजनों के लिए प्रस्तुति सामग्री प्रिंट करने में उपयोगी है।

हेंडआउट मोड को `setSlidesLayoutOptions` मेथड के द्वारा कॉन्फ़िगर किया जाता है, जो [IPdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) में उपलब्ध है। हेंडआउट लेआउट को परिभाषित करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें।

## **हेंडआउट मोड निर्यात**

हेंडआउट मोड में प्रस्तुति को निर्यात करने के लिए, लक्ष्य निर्यात विकल्पों के लिए `setSlidesLayoutOptions` मेथड सेट करें और एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handoutlayoutingoptions/) इंस्टेंस असाइन करें जो प्रति पृष्ठ स्लाइडों की संख्या और संबंधित प्रदर्शन पैरामीटर निर्धारित करता है।

नीचे एक कोड उदाहरण दिया गया है जो दिखाता है कि प्रस्तुति को हेंडआउट मोड में PDF में कैसे परिवर्तित किया जाए।

```java
// प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // निर्यात विकल्प सेट करें।
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // एक पृष्ठ पर क्षैतिज रूप से 4 स्लाइड्स
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // स्लाइड नंबर प्रिंट करें
    slidesLayoutOptions.setPrintFrameSlide(true);                     // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
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
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट प्रारूपों जैसे PDF, HTML, TIFF, और चित्रों के रूप में रेंडरिंग के लिए उपलब्ध है। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**हेंडआउट मोड में प्रति पृष्ठ अधिकतम स्लाइड थंबनेल की संख्या क्या है?**

Aspose.Slides [presets](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handouttype/) का समर्थन करता है जो क्षैतिज या लम्बवत क्रम में प्रति पृष्ठ 9 थंबनेल तक होते हैं: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical), और 9 (horizontal/vertical)।

**क्या मैं कस्टम ग्रिड, जैसे 5 या 8 स्लाइड प्रति पृष्ठ, परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को [HandoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handouttype/) क्लास द्वारा सख्ती से नियंत्रित किया जाता है; मनमाना लेआउट समर्थित नहीं है।

**क्या मैं हेंडआउट आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हाँ। लक्ष्य स्वरूप के निर्यात सेटिंग्स में `setShowHiddenSlides` मेथड को सक्षम करें, जैसे कि [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/)।