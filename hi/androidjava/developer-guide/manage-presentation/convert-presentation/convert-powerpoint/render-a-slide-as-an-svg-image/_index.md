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
- इंटरएक्टिव SVG
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android पर PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, एक्सेसेबिलिटी कार्यप्रवाह, और स्वचालित पोस्ट-प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides for Android via Java प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको लिखे जाने वाले टेक्स्ट, फ़ॉन्ट, चित्र और SVG घटकों को नियंत्रित करने की अनुमति देता है।

जब निर्यात किया गया SVG कॉम्पैक्ट, ब्राउज़रों में अनुमाननीय, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तब [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) का उपयोग करें।

## **स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) बनाएं, एक स्लाइड चुनें, और इसे [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) का उपयोग करके स्ट्रीम में लिखें। निम्न उदाहरण प्रस्तुति की हर स्लाइड को अलग-अलग SVG फ़ाइल के रूप में निर्यात करता है।

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

फ़ाइलनाम लूप इंडेक्स के बजाय [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) का उपयोग करता है। जब स्लाइड व्यूअर या वेब पेज को केवल वही आकार चाहिए, तो आप [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) से व्यक्तिगत आकार भी निर्यात कर सकते हैं।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ़्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) रेंडरिंग एरिया में टेक्स्ट फ़्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) निर्धारित करता है कि फ्रेम रोटेशन लागू किया जाए या नहीं। जब टेक्स्ट को बिना लिगेचर के रेंडर करना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) को `true` सेट करें।

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

## **तीरमुखों पर लाइन-एंड क्रॉपिंग को नियंत्रित करें**

SVG 1.1 में कोई मार्कर इनसेट सेटिंग नहीं है जो तय करे कि लाइन तीरमुख के नीचे कहाँ रुकनी चाहिए। डिफ़ॉल्ट रूप से, Aspose.Slides निर्यातित लाइन को छोटा कर देता है ताकि उसकी स्ट्रोक मार्कर के माध्यम से बाहर न निकलें। [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) को `true` के साथ कॉल करने से स्ट्रोक को लाइन के मूल अंत बिंदु तक पूरा खींचा जाता है। यह सेटिंग केवल SVG आउटपुट को प्रभावित करती है। लाइन स्लाइड पर अपनी स्थिति और लंबाई बनाए रखती है।

उदाहरण में 2 और 10 पॉइंट चौड़ी लाइनों पर त्रिकोण और हीरे के तीरमुख बनाए जाते हैं। यह समान स्लाइड को दो बार निर्यात करता है, केवल क्रॉपिंग विकल्प को बदलते हुए।

```java
import com.aspose.slides.*;
import android.graphics.Color;
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
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

तुलना 10‑पॉइंट लाइन पर त्रिकोणीय तीरमुख को दिखाती है। क्रॉपिंग सक्षम होने पर नोक तेज़ होती है। क्रॉपिंग अक्षम होने पर स्ट्रोक मार्कर की तिरछी पक्षों से बाहर निकलती है और समतल अंत छोड़ देती है।

![क्रॉपिंग सक्षम होने पर तेज़ नोक वाला बड़ा 10‑पॉइंट त्रिकोण और क्रॉपिंग अक्षम होने पर समतल अंत](line-end-cropping.png)

उदाहरण की अन्य लाइनों में, 2‑पॉइंट त्रिकोण पर बाहर निकलती स्ट्रोक कम दिखाई देती है। भरे हुए हीरे दोनों चौड़ाइयों पर स्ट्रोक के अंत को कवर करते हैं।

## **टेक्स्ट और फ़ॉन्ट को नियंत्रित करें**

स्लाइड को SVG में निर्यात करते समय, आप नियंत्रित कर सकते हैं कि टेक्स्ट टेक्स्ट ही रहे या वेक्टर ग्राफ़िक्स में बदल जाए, और बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित किए जाएँ। निम्न विकल्प आपको निर्यातित SVG में दृश्य स्थिरता, टेक्स्ट चयन, और फ़ॉन्ट निर्भरताओं के बीच संतुलन स्थापित करने में मदद करते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) को `true` पर सेट करें ताकि सभी स्लाइड टेक्स्ट वेक्टर ग्राफ़िक्स के रूप में लिखे जाएँ। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम ब्राउज़रों में अधिक सुसंगत हो जाता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोजने योग्य नहीं रहेगा।

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

### **बाहरी फ़ॉन्ट कैसे संभाले जाएँ चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें, SVG में फ़ॉन्ट डेटा शामिल करने के लिए [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें, या केवल बाहरी फ़ॉन्ट उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) चुनें। फ़ॉन्ट को एम्बेड करने से पहले फ़ॉन्ट लाइसेंस की जाँच करें।

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

## **एम्बेडेड इमेज आकार कम करें**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) का उपयोग करके एम्बेडेड चित्रों का रिज़ॉल्यूशन घटाएँ, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) से क्रॉप किए गए स्रोत क्षेत्रों को छोड़ें, और [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) से JPEG एन्कोडिंग गुणवत्ता नियंत्रित करें। ये सेटिंग्स इमेज की फ़िडेलिटी या रखे गए इमेज डेटा की कीमत पर फ़ाइल आकार घटाती हैं।

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

## **मेटाफ़ाइल रास्टराइज़ेशन रेजोल्यूशन को नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) SVG निर्यात के दौरान मेटाफ़ाइल को रास्टराइज़ करने के लिए न्यूनतम रेजोल्यूशन सीमा निर्धारित करता है। जब EMF या WMF इमेज रास्टराइज़ हो रही हो, तो विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए इसे उपयोग करें। यह SVG के लिए एक ग्लोबल DPI निर्धारित नहीं करता और स्लाइड पर प्रत्येक ऑब्जेक्ट को रास्टर इमेज बनाता नहीं है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकट अंतराल वाली तिरछी लाइनों वाला EMF इमेज है। निम्न उदाहरण अपनी पहली स्लाइड को तीन रास्टराइज़ेशन रेजोल्यूशन पर [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) के माध्यम से निर्यात करता है। सभी अन्य निर्यात सेटिंग्स समान रहती हैं ताकि परिणामों की तुलना की जा सके।

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

आउटपुट में, प्रत्येक SVG में EMF एक एम्बेडेड PNG बन गया। निम्न माप प्रदान किए गए प्रस्तुति के लिए हैं; ये DPI को पिक्सेल आयाम में बदलने का सामान्य सूत्र नहीं हैं।

| मेटाफ़ाइल रास्टराइज़ेशन DPI | एम्बेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट्स) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे की तुलना समान एम्बेडेड रास्टर के क्षेत्र को समान बड़े डिस्प्ले आकार में दिखाती है। तिरछी लाइनों में 72 DPI पर स्पष्ट पिक्सेलेशन और उच्च रेजोल्यूशन पर अधिक सुगम किनारे दिखते हैं, जबकि SVG फ़ाइल आकार बढ़ती है। मान बढ़ाने से आवश्यक नहीं कि हर विवरण में सुधार हो या प्रत्येक निर्यातित इमेज बदल जाए।

![72, 150, और 300 DPI पर बढ़ी हुई तिरछी-लाइन विवरण](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) इमेज रिज़ॉल्यूशन घटाव को नियंत्रित करता है और मेटाफ़ाइल रास्टराइज़ेशन रेजोल्यूशन में परिवर्तन के प्रभाव को छुपा सकता है। [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, मेटाफ़ाइल रास्टराइज़ेशन रेजोल्यूशन को नहीं।

## **आकार और टेक्स्ट को स्थायी IDs असाइन करें**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) का उपयोग करके प्रत्येक SVG आकार के लिए [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) सेट करें। टेक्स्ट `tspan` तत्वों पर भी [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) मान सेट करने के लिए, [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) को लागू करें। दोनों में से किसी एक कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें।

निम्न कंट्रोलर [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) का उपयोग करता है, जो आकार के जीवनकाल के लिए स्थिर होता है, और उसके टेक्स्ट स्पैन्स के लिए एक दोहराने योग्य काउंटर। यह उत्पन्न IDs को अपरिवर्तित प्रस्तुति के बाद-प्रसंस्करण के लिए उपयुक्त बनाता है।

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) में, निर्यातित आकार में JavaScript इवेंट हैंडलर जोड़ने के लिए [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) को एक [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) मान के साथ कॉल करें। कंट्रोलर को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) के साथ असाइन करें और परिणाम को होस्ट करने वाले पृष्ठ या SVG दस्तावेज़ में JavaScript फ़ंक्शन परिभाषित करें।

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

होस्ट पेज हैंडलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर असाइन करने से स्लाइड व्यूअर्स, एक्सेसेबिलिटी सुधार, और अन्य इंटरैक्टिव SVG कार्यप्रवाह सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मुझे कब [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग करना चाहिए बजाय [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) के?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) का उपयोग तब करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) का उपयोग तब करें जब केवल वह टेक्स्ट जो बाहरी फ़ॉन्ट उपयोग करता है, ग्राफ़िक्स में परिवर्तित किया जाना चाहिए।

**SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एम्बेडेड चित्रों को संपीड़ित करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण फ़ॉन्ट फ़ाइलें सर्व कर सके तो लिंक की गई फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट प्रत्येक का अलग गुणवत्ता और आकार का समझौता होता है।

**क्या मैं निर्यात के बाद SVG तत्वों को संशोधित कर सकता हूँ?**

हां। फॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट-प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते हुए SVG तत्वों को चुनें।