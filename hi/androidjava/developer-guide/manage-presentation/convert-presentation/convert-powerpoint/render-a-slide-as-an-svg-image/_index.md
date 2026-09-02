---
title: Android पर प्रस्तुति स्लाइड्स को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Android पर PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, छवियां, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब पब्लिशिंग, स्लाइड व्यूअर्स, एक्सेसिबिलिटी वर्कफ़्लो और स्वचालित पोस्ट‑प्रॉसेसिंग के लिए उपयुक्त है। Aspose.Slides for Android via Java प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र और SVG तत्वों को कैसे लिखा जाता है, को नियंत्रित करने की अनुमति देता है।

Use [SVGOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **स्लाइड को SVG के रूप में निर्यात करें**

Create a [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/), select a slide, and write it to a stream with [ISlide.writeAsSvg](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). The following example exports every slide in a presentation as a separate SVG file.

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

The filename uses [ISlide.getSlideNumber](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getSlideNumber--) rather than the loop index. You can also export an individual shape with [IShape.writeAsSvg](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) when a slide viewer or web page needs only that shape.

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) निर्धारित करता है कि फ्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) को `true` सेट करें।

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

## **टेक्स्ट और फ़ॉन्ट्स को नियंत्रित करें**

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) को `true` सेट करें ताकि सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक्स के रूप में लिखा जा सके। इससे फ़ॉन्ट निर्भरताएं समाप्त हो जाती हैं और दृश्य परिणाम विभिन्न ब्राउज़रों में अधिक सुसंगत बनता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

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

### **बाहरी फ़ॉन्ट्स को कैसे संभालें चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) बाहरी रूप से लोड किए गए फ़ॉन्ट्स के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें, SVG में फ़ॉन्ट डेटा को शामिल करने के लिए [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें, या उन टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए जो बाहरी फ़ॉन्ट्स का उपयोग करते हैं, [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

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

## **एंबेडेड इमेज आकार घटाएँ**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) का उपयोग करके एंबेडेड चित्रों का रिज़ॉल्यूशन कम करें, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) से कटे हुए स्रोत क्षेत्रों को हटाएँ, और JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करने हेतु [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) का प्रयोग करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज की फ़िडेलिटी या रखे गए इमेज डेटा की कीमत पर।

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

## **शेप्स और टेक्स्ट को स्थिर IDs असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape.setId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan.setId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) मान सेट करने के लिए, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) को लागू करें। दोनों में से किसी भी कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें।

निम्नलिखित कंट्रोलर [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) का उपयोग करता है, जो आकार के जीवनकाल के लिए स्थिर होता है, और उसके टेक्स्ट स्पैन के लिए एक दोहराने योग्य काउंटर। यह उत्पन्न IDs को अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) में, एक निर्यातित आकार में जावास्क्रिप्ट इवेंट हैंडलर जोड़ने के लिए [ISvgShape.setEventHandler](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) को एक [SvgEvent](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgevent/) मान के साथ कॉल करें। कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें और परिणाम की होस्ट पेज या SVG दस्तावेज़ में जावास्क्रिप्ट फ़ंक्शन 정의 करें।

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

होस्ट पेज हैंडलर द्वारा संदर्भित जावास्क्रिप्ट फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर्स को असाइन करने से स्लाइड व्यूअर्स, एक्सेसिबिलिटी सुधार, और अन्य इंटरैक्टिव SVG वर्कफ़्लो सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कब [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgexternalfontshandling/) के बजाय करना चाहिए?**

[SVGOptions.setVectorizeText] का उपयोग तब करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling.Vectorize] का उपयोग तब करें जब केवल वह टेक्स्ट जिसे बाहरी फ़ॉन्ट्स का उपयोग होता है, ग्राफ़िक्स में परिवर्तित किया जाना चाहिए।

**SVG को छोटा करने का सर्वोत्तम तरीका क्या है?**

पहले एंबेडेड चित्रों को संपीड़ित करें, कटे हुए इमेज क्षेत्रों को हटाएँ, और लक्ष्य वातावरण में प्रदान किए जा सकने पर लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट के अलग‑अलग क्वालिटी और आकार संबंधी ट्रेड‑ऑफ़ होते हैं।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हां। फॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चुनें।