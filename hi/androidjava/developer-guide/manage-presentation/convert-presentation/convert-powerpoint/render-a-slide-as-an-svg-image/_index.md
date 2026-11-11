---
title: एंड्रॉइड पर प्रेजेंटेशन स्लाइड्स को SVG इमेजेज़ के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रेजेंटेशन से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "एंड्रॉइड पर PowerPoint स्लाइड्स को SVG इमेजेज़ के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, आईडी, और इवेंट को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, एक्सेसेबिलिटी वर्कफ़्लो, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides for Android via Java प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र, और SVG तत्वों को कैसे लिखा जाए, इस पर नियंत्रण देता है।

जब निर्यात किया गया SVG कॉम्पैक्ट, ब्राउज़र में पूर्वानुमेय, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तो [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) का उपयोग करें।

## **स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) बनाएं, स्लाइड चुनें, और उसे [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) के साथ स्ट्रीम में लिखें। नीचे दिया गया उदाहरण एक प्रस्तुति की प्रत्येक स्लाइड को अलग-अलग SVG फ़ाइल के रूप में निर्यात करता है।

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

फ़ाइलनाम लूप इंडेक्स के बजाय [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) का उपयोग करता है। आप व्यक्तिगत आकार को भी [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) के साथ निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वही आकार चाहिए।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) निर्धारित करता है कि फ्रेम रोटेशन लागू किया जाए या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) को `true` सेट करें।

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

## **टेक्स्ट और फ़ॉन्ट को नियंत्रित करें**

स्लाइड को SVG में निर्यात करते समय, आप नियंत्रित कर सकते हैं कि टेक्स्ट टेक्स्ट ही रहे या वेक्टर ग्राफ़िक्स में बदल जाए, और बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित हों। निम्न विकल्प आपको निर्यातित SVG में दृश्य स्थिरता, टेक्स्ट चयन, और फ़ॉन्ट निर्भरताओं के बीच संतुलन स्थापित करने में मदद करेंगे।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) को `true` सेट करें ताकि सभी स्लाइड टेक्स्ट वेक्टर ग्राफ़िक्स के रूप में लिखे जाएँ। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम ब्राउज़र में अधिक सुसंगत बनता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

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

### **बाहरी फ़ॉन्ट को कैसे संभालें चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें, SVG में फ़ॉन्ट डेटा शामिल करने के लिए [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें, या केवल बाहरी फ़ॉन्ट उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें। फ़ॉन्ट को एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

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

## **एम्बेडेड इमेज आकार घटाएँ**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) का उपयोग करके एम्बेडेड चित्रों का रेजॉल्यूशन घटाएँ, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) से क्रॉप किए गए स्रोत क्षेत्रों को छोड़ें, और JPEG एन्कोडिंग क्वालिटी को नियंत्रित करने के लिए [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) का प्रयोग करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज फ़िडेलिटी या रखे गए इमेज डेटा की कीमत पर।

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

## **मेटाफाइल रास्ट्राइजेशन रिज़ॉल्यूशन नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) SVG निर्यात के दौरान मेटाफाइल को रास्टराइज़ करने के लिए निचली रेजॉल्यूशन सीमा निर्धारित करता है। EMF या WMF इमेज को रास्टराइज़ करने पर विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए इसका उपयोग करें। यह SVG के लिए वैश्विक DPI निर्धारित नहीं करता और न ही स्लाइड के प्रत्येक ऑब्जेक्ट को रास्टर इमेज बनाता है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकटता से स्थित विकर्ण लाइनों वाला एक EMF इमेज है। नीचे दिया गया उदाहरण उसकी पहली स्लाइड को तीन रास्ट्राइजेशन रेजॉल्यूशनों के साथ [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) के माध्यम से निर्यात करता है। सभी अन्य निर्यात सेटिंग्स समान रहती हैं ताकि परिणामों की तुलना की जा सके।

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

आउटपुट में, EMF प्रत्येक SVG में एक एम्बेडेड PNG बन गया। नीचे दिए गए माप प्रदान किए गए प्रस्तुतिकरण के लिए हैं; ये DPI को पिक्सेल आयाम में बदलने का सामान्य सूत्र नहीं हैं।

| मेटाफाइल रास्ट्राइजेशन DPI | एम्बेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट्स) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे तुलना दिखाती है कि एम्बेडेड रास्टर का वही क्षेत्र समान बढ़े हुए डिस्प्ले आकार पर कैसे दिखता है। विकर्ण लाइने 72 DPI पर दिखने वाला पिक्सेलेशन और उच्च रेजॉल्यूशन पर स्मूथ किनारे दिखाती हैं, जबकि SVG फ़ाइल आकार बढ़ता है। मान बढ़ाने से हर विवरण आवश्यक रूप से सुधरता नहीं है या प्रत्येक निर्यातित इमेज नहीं बदलती।

![72, 150, और 300 DPI पर बड़ा किया गया विकर्ण-रेखा विवरण](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) इमेज रेजॉल्यूशन कमी को नियंत्रित करता है और मेटाफाइल रास्ट्राइजेशन रेजॉल्यूशन बदलने के प्रभाव को छिपा सकता है। [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) JPEG एन्कोडिंग क्वालिटी को नियंत्रित करता है, न कि मेटाफाइल रास्ट्राइजेशन रेजॉल्यूशन को।

## **शेप और टेक्स्ट को स्थिर IDs असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) मान सेट करने के लिए, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) लागू करें। इन दोनों में से किसी भी कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें।

नीचे दिया गया कंट्रोलर [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) का उपयोग करता है, जो आकार के जीवनकाल के लिए स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक पुनरावृत्त काउंटर। यह उत्पन्न IDs को अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

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

## **SVG इवेंट हैंडलर जोड़ें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) में, निर्यातित आकार में जावास्क्रिप्ट इवेंट हैंडलर जोड़ने के लिए [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) को [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) मान के साथ कॉल करें। कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें और पृष्ठ या SVG दस्तावेज़ में जावास्क्रिप्ट फ़ंक्शन को परिभाषित करें जो परिणाम को होस्ट करता है।

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

होस्ट पेज हैंडलर द्वारा संदर्भित जावास्क्रिप्ट फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर असाइन करने से स्लाइड व्यूअर्स, एक्सेसेबिलिटी सुधार, और अन्य इंटरैक्टिव SVG वर्कफ़्लोज़ सक्षम होते हैं।

## **FAQ**

**कब मैं [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) को [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) के बजाय उपयोग करूँ?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग तब करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) का उपयोग तब करें जब केवल बाहरी फ़ॉन्ट का उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स में बदलना हो।

**SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

पहले एम्बेडेड चित्रों को कम्प्रेस करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएं, और लक्ष्य पर्यावरण द्वारा सर्व किए जा सकने पर लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रेजॉल्यूशन, कम JPEG क्वालिटी, और वेक्टराइज़्ड टेक्स्ट प्रत्येक का गुणवत्ता और आकार पर अलग-अलग प्रभाव होता है।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हाँ। एक फ़ॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते हुए SVG तत्वों को चुनें।