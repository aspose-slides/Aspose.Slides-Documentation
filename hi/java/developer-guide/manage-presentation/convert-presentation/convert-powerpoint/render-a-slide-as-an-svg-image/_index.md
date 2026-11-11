---
title: Java में प्रस्तुति स्लाइड को SVG इमेज के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रेज़ेंटेशन से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरएक्टिव SVG
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Java में PowerPoint स्लाइड को SVG इमेज के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, एक्सेसिबिलिटी कार्यप्रवाह और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र और SVG तत्वों के लिखे जाने के तरीके को नियंत्रित करने की अनुमति देता है।

जब निर्यात किया गया SVG संक्षिप्त, ब्राउज़र‑अनुकूल या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तब **[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/)** का उपयोग करें।

## **स्लाइड को SVG के रूप में निर्यात करें**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाएं, स्लाइड चुनें, और उसे [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) के साथ स्ट्रीम में लिखें। नीचे दिया गया उदाहरण प्रस्तुति की प्रत्येक स्लाइड को अलग SVG फ़ाइल में निर्यात करता है।

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

फ़ाइलनाम लूप इंडेक्स के बजाय [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) का उपयोग करता है। जब स्लाइड व्यूअर या वेब पेज को केवल किसी विशिष्ट आकार की आवश्यकता हो, तो आप [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) के साथ व्यक्तिगत आकार को निर्यात भी कर सकते हैं।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) निर्धारित करता है कि फ्रेम घुमाव लागू हो या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) को `true` सेट करें।

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

## **तीर के सिरों पर लाइन‑एंड क्रॉपिंग को नियंत्रित करें**

SVG 1.1 में मार्कर इनसेट सेटिंग नहीं है जिससे यह निर्धारित किया जा सके कि लाइन तीर के नीचे कहाँ समाप्त हो। डिफ़ॉल्ट रूप से, Aspose.Slides निर्यात की गई लाइन को छोटा कर देता है ताकि उसकी स्ट्रोक मार्कर के भीतर न निकले। इसे रोकने के लिए [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) को `true` करें। यह सेटिंग केवल SVG आउटपुट को प्रभावित करती है; स्लाइड पर लाइन की स्थिति और लंबाई अपरिवर्तित रहती है।

उदाहरण में त्रिकोणीय और हीरे के आकार के तीर सिर 2‑पॉइंट और 10‑पॉइंट लाइनों पर दर्शाए गए हैं। यह वही स्लाइड दो बार निर्यात करता है, केवल क्रॉपिंग विकल्प बदलते हुए।

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

तुलना में 10‑पॉइंट लाइन पर त्रिकोणीय तीर सिर दिखाया गया है। क्रॉपिंग सक्षम होने पर टिप तेज़ रहती है; अक्षम होने पर स्ट्रोक मार्कर के तिरछे किनारों से बाहर निकला हुआ दिखता है और अंत सपाट हो जाता है।

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

उदाहरण की अन्य लाइनों में, 2‑पॉइंट त्रिकोण पर बाहर निकली स्ट्रोक कम दिखती है। भरे हुए हीरे दोनों चौड़ाइयों पर स्ट्रोक के अंत को कवर करते हैं।

## **टेक्स्ट और फ़ॉन्ट को नियंत्रित करें**

जब स्लाइड को SVG में निर्यात किया जाता है, तो आप तय कर सकते हैं कि टेक्स्ट टेक्स्ट रूप में रहे या वेक्टर ग्राफ़िक में बदल दिया जाए, तथा बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित हों। नीचे दिए विकल्प दृश्य सुसंगतता, टेक्स्ट चयन और फ़ॉन्ट निर्भरताओं को संतुलित करने में मदद करते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) को `true` सेट करने से सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक के रूप में लिखा जाता है। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और विभिन्न ब्राउज़रों में दृश्य परिणाम अधिक सुसंगत रहता है, परन्तु टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) मान इस्तेमाल करता है। `AddLinksToFontFiles` चुनें ताकि अलग फ़ॉन्ट फ़ाइलों को संदर्भित किया जा सके, `Embed` चुनें ताकि फ़ॉन्ट डेटा SVG में समाहित हो, या `Vectorize` चुनें ताकि केवल बाहरी फ़ॉन्ट वाले टेक्स्ट को ग्राफ़िक में बदला जाए। फ़ॉन्ट एम्बेड करने से पहले लाइसेंस जाँचें।

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

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) का उपयोग करके एम्बेडेड चित्रों की रिज़ॉल्यूशन घटाएँ, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) से क्रॉप किए गए स्रोत क्षेत्रों को छोड़ें, और [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) से JPEG एन्कोडिंग गुणवत्ता नियंत्रित करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं, पर इमेज फ़िडेलिटी या संग्रहीत इमेज डेटा पर असर पड़ता है।

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

## **मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) SVG निर्यात के दौरान मेटाफाइल को रास्टराइज़ करने की निचली रिज़ॉल्यूशन सीमा निर्धारित करता है। इसका उपयोग EMF या WMF इमेज को रास्टराइज़ करते समय विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए करें। यह SVG के लिए वैश्विक DPI नहीं तय करता और न ही स्लाइड की प्रत्येक वस्तु को रास्टर इमेज में बदलता है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकटस्थ तिरछी लाइनों वाला EMF इमेज है। नीचे दिया गया उदाहरण [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) के माध्यम से उसकी पहली स्लाइड को तीन रास्टराइज़ेशन रिज़ॉल्यूशन पर निर्यात करता है। अन्य सभी निर्यात सेटिंग समान रहती हैं जिससे परिणामों की तुलना संभव हो सके।

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

आउटपुट में EMF प्रत्येक SVG में एक एम्बेडेड PNG बन जाता है। नीचे दी गई मापें प्रदान की गई प्रस्तुति के लिए हैं; ये DPI को पिक्सेल आयाम में बदलने का सामान्य नियम नहीं हैं।

| Metafile rasterization DPI | Embedded PNG dimensions | SVG file size (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे की तुलना समान एम्बेडेड रास्टर क्षेत्र को समान विस्तारित डिस्प्ले आकार में दर्शाती है। 72 DPI पर तिरछी लाइनों में पिक्सेलेशन दिखता है, जबकि उच्च रिज़ॉल्यूशन पर किनारे अधिक स्मूथ होते हैं, और SVG फ़ाइल आकार बढ़ता है। मान बढ़ाना आवश्यक रूप से हर विवरण को बेहतर नहीं करता और न ही हर निर्यातित इमेज को बदलता है।

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) इमेज रिज़ॉल्यूशन को घटाता है और मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छुपा सकता है। [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, रास्टराइज़ेशन रिज़ॉल्यूशन नहीं।

## **आकार और टेक्स्ट को स्थिर IDs असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) सेट करें। टेक्स्ट `tspan` तत्वों पर भी IDs सेट करने के लिए [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) को लागू करने हेतु [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) लागू करें। दोनों में से कोई भी कंट्रोलर [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें।

नीचे दिया गया कंट्रोलर [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) का उपयोग करता है, जो आकार के जीवनकाल में स्थिर रहता है, तथा उसके टेक्स्ट स्पैन के लिए एक पुनरावर्ती काउंटर रखता है। यह उत्पन्न IDs को अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

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

एक [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) में, [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) को एक [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) मान के साथ कॉल करें ताकि निर्यात किए गए आकार में JavaScript इवेंट हैंडलर जोड़ा जा सके। कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें और वह JavaScript फ़ंक्शन पेज या SVG दस्तावेज़ में परिभाषित करें जो परिणाम को होस्ट करता है।

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

होस्ट पेज इवेंट हैंडलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर्स का असाइन करना स्लाइड व्यूअर्स, एक्सेसिबिलिटी सुधार और अन्य इंटरैक्टिव SVG कार्यप्रवाहों को सक्षम बनाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**कब मुझे [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग करना चाहिए बजाय [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना आवश्यक हो, तो [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग करें। जब केवल वह टेक्स्ट जो बाहरी फ़ॉन्ट उपयोग करता है उसे ग्राफ़िक में बदलना हो, तो [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) चुनें।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एम्बेडेड चित्रों को संकुचित करें, क्रॉप किए गए चित्र क्षेत्रों को हटाएँ, और जब लक्षित वातावरण लिंक्ड फ़ॉन्ट फ़ाइलें सर्व कर सकता हो तो फ़ॉन्ट फ़ाइलों को लिंक के रूप में चुनें। परिणाम का परीक्षण करें क्योंकि कम चित्र रिज़ॉल्यूशन, कम JPEG गुणवत्ता और वेक्टराइज़्ड टेक्स्ट प्रत्येक अलग‑अलग गुणवत्ता‑आकार संतुलन लाते हैं।

**क्या निर्यात के बाद SVG तत्वों को संशोधित किया जा सकता है?**

हाँ। एक फ़ॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राज़र स्क्रिप्ट में मिलती‑जुलती SVG तत्वों का चयन करें।