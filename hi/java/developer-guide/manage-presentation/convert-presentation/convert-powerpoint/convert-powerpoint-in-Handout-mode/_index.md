---
title: जावा का उपयोग करके हैंडआउट मोड में पावरपॉइंट प्रस्तुतियों को परिवर्तित करें
linktitle: हैंडआउट मोड
type: docs
weight: 150
url: /hi/java/convert-powerpoint-in-Handout-mode/
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
description: "जावा में प्रस्तुतियों को हैंडआउट में बदलें। प्रति पृष्ठ स्लाइड सेट करें, नोट्स रखें, Aspose.Slides के साथ PDF या छवियों में निर्यात करें, सैंपल जावा कोड के साथ। मुफ्त में आज़माएँ।"
---
## **परिचय**

Aspose.Slides आपको प्रस्तुतियों को ऐसे आउटपुट फ़ॉर्मेट में बदलने की अनुमति देता है जो Handout मोड को सपोर्ट करते हैं। इस मोड में, कई स्लाइड्स को एक पृष्ठ पर व्यवस्थित किया जाता है, जो सम्मेलनों, सेमिनारों और समान घटनाओं के लिए प्रस्तुति सामग्री को प्रिंट करने में उपयोगी होता है।

Handout मोड को `setSlidesLayoutOptions` मेथड के माध्यम से कॉन्फ़िगर किया जाता है, जो [IPdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihtmloptions/), और [ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) में उपलब्ध है। Handout लेआउट को परिभाषित करने के लिए, [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handoutlayoutingoptions/) ऑब्जेक्ट का उपयोग करें।

## **हैंडआउट मोड निर्यात**

Handout मोड में एक प्रस्तुति को निर्यात करने के लिए, लक्ष्य निर्यात विकल्पों के लिए `setSlidesLayoutOptions` मेथड सेट करें और एक [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handoutlayoutingoptions/) इंस्टेंस असाइन करें जो प्रति पृष्ठ स्लाइड्स की संख्या और संबंधित डिस्प्ले पैरामीटर को परिभाषित करता है।

नीचे एक कोड उदाहरण दिया गया है जो Handout मोड में प्रस्तुति को PDF में बदलने का तरीका दिखाता है।

```java
// प्रस्तुति लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // निर्यात विकल्प सेट करें।
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 1 पृष्ठ पर क्षैतिज रूप में 4 स्लाइड
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // स्लाइड नंबर प्रिंट करें
    slidesLayoutOptions.setPrintFrameSlide(true);                     // स्लाइड्स के चारों ओर फ्रेम प्रिंट करें
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
ध्यान रखें कि `setSlidesLayoutOptions` मेथड केवल कुछ आउटपुट फ़ॉर्मेट के लिए उपलब्ध है, जैसे PDF, HTML, TIFF, और छवियों के रूप में रेंडरिंग करते समय। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**Handout मोड में प्रति पृष्ठ अधिकतम क्रमिक थंबनेल स्लाइड्स की संख्या क्या है?**

Aspose.Slides [पूर्वनिर्धारित](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handouttype/) को समर्थन देता है, जिसमें अधिकतम 9 थंबनेल प्रति पृष्ठ होते हैं, क्षैतिज या ऊर्ध्वाधर क्रम में: 1, 2, 3, 4 (क्षैतिज/ऊर्ध्वाधर), 6 (क्षैतिज/ऊर्ध्वाधर), और 9 (क्षैतिज/ऊर्ध्वाधर)।

**क्या मैं 5 या 8 स्लाइड्स प्रति पृष्ठ जैसे कस्टम ग्रिड परिभाषित कर सकता हूँ?**

नहीं। थंबनेल की संख्या और क्रम को [HandoutType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/handouttype/) क्लास द्वारा सख्ती से नियंत्रित किया जाता है; मनमाने लेआउट समर्थित नहीं हैं।

**क्या मैं Handout आउटपुट में छिपी हुई स्लाइड्स शामिल कर सकता हूँ?**

हां। लक्ष्य फ़ॉर्मेट के लिए निर्यात सेटिंग्स में `setShowHiddenSlides` मेथड का उपयोग करके छिपी हुई स्लाइड्स को सक्षम करें, जैसे [PdfOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/htmloptions/), या [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/)।