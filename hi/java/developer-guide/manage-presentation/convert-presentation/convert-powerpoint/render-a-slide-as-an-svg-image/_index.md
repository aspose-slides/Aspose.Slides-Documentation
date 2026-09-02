---
title: जावा में प्रस्तुतिकरण स्लाइड को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रस्तुति से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: जावा में PowerPoint स्लाइड को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट्स, टेक्स्ट, छवियां, IDs, और इवेंट्स को नियंत्रित करें।
---
## **सारांश**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, अभिगम्यता कार्यप्रवाह, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल में निर्यात करता है और आपको यह नियंत्रित करने देता है कि टेक्स्ट, फ़ॉन्ट्स, चित्र, और SVG तत्व कैसे लिखे जाएँ।

उपयोग करें [SVGOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/) जब निर्यात किया गया SVG संक्षिप्त, विभिन्न ब्राउज़रों में पूर्वानुमेय, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए।

## **एक स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) बनाएं, स्लाइड चुनें, और इसे एक स्ट्रीम में [ISlide.writeAsSvg](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) के साथ लिखें। निम्न उदाहरण प्रस्तुति में प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल के रूप में निर्यात करता है।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

फ़ाइलनाम लूप इंडेक्स के बजाय [ISlide.getSlideNumber](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getSlideNumber--) का उपयोग करता है। आप एकल आकार भी [IShape.writeAsSvg](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) के साथ निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वह आकार चाहिए।

## **SVG आउटपुट कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) तय करता है कि फ्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर किया जाना चाहिए, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) को `true` सेट करें।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट और फ़ॉन्ट्स नियंत्रित करें**

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) को `true` सेट करें ताकि सभी स्लाइड टेक्स्ट को वेक्टर ग्राफिक्स के रूप में लिखा जा सके। यह फ़ॉन्ट निर्भरताओं को समाप्त करता है और दृश्य परिणाम को विभिन्न ब्राउज़रों में अधिक संगत बनाता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **बाहरी फ़ॉन्ट्स कैसे संभाले जाएँ चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) बाहरी रूप से लोड किए गए फ़ॉन्ट्स के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। अलग‑अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `AddLinksToFontFiles` चुनें, फ़ॉन्ट डेटा को SVG में शामिल करने के लिए `Embed` चुनें, या बाहरी फ़ॉन्ट्स का उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए `Vectorize` चुनें। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **एम्बेडेड चित्रों का आकार घटाएँ**

एंबेडेड चित्रों का रिज़ॉल्यूशन घटाने के लिए [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) का उपयोग करें, क्रॉप किए गए स्रोत क्षेत्रों को छोड़ने के लिए [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) का उपयोग करें, और JPEG एन्कोडिंग क्वालिटी को नियंत्रित करने के लिए [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) का उपयोग करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं, लेकिन छवि की गुणवत्ता या संग्रहीत चित्र डेटा की कीमत पर।

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **आकृतियों और टेक्स्ट को स्थिर IDs असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape.setId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) सेट करें। टेक्स्ट `tspan` तत्वों के लिए भी [ISvgTSpan.setId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) मान सेट करने के लिए [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) लागू करें। दोनों में से किसी भी कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें।

निम्न कंट्रोलर [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) का उपयोग करता है, जो आकार के जीवनकाल के लिए स्थिर होता है, और उसके टेक्स्ट स्पैन्स के लिए एक दोहराने योग्य काउंटर। यह उत्पन्न IDs को अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **SVG इवेंट हैंडलर्स जोड़ें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgshapeformattingcontroller/) में, निर्यात किए गए आकार में जावास्क्रिप्ट इवेंट हैंडलर जोड़ने के लिए [ISvgShape.setEventHandler](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) को एक [SvgEvent](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgevent/) मान के साथ कॉल करें। कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें और परिणाम को होस्ट करने वाले पेज या SVG दस्तावेज़ में जावास्क्रिप्ट फ़ंक्शन परिभाषित करें।

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

होस्ट पेज हैंडलर द्वारा संदर्भित जावास्क्रिप्ट फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर्स का असाइनमेंट स्लाइड व्यूअर्स, अभिगम्यता सुधार, और अन्य इंटरैक्टिव SVG वर्कफ़्लो को सक्षम करता है।

## **FAQ**

**मैं कब [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgexternalfontshandling/) के बजाय करूँ?**

जब सभी टेक्स्ट को फ़ॉन्ट्स से स्वतंत्र होना चाहिए, तो [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग करें। जब केवल वह टेक्स्ट जिसे बाहरी फ़ॉन्ट्स का उपयोग किया गया है, उसे ग्राफ़िक्स में परिवर्तित करना हो, तो [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgexternalfontshandling/) का उपयोग करें।

**SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

पहले एंबेडेड चित्रों को संकुचित करें, क्रॉप किए गए चित्र क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण उन्हें सर्व कर सके तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम चित्र रिज़ॉल्यूशन, कम JPEG क्वालिटी, और वेक्टराइज़्ड टेक्स्ट प्रत्येक में अलग‑अलग गुणवत्ता और आकार के समझौते होते हैं।

**क्या मैं निर्यात किए गए SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हाँ। फॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों का चयन करें।