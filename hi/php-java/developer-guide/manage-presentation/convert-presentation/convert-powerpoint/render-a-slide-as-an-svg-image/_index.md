---
title: PHP में प्रस्तुति स्लाइड्स को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint को SVG
- प्रेजेंटेशन को SVG
- स्लाइड को SVG
- PPT को SVG
- PPTX को SVG
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "PHP में PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML‑आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूयर, एक्सेसेबिलिटी वर्कफ़्लो और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को अलग-अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र और SVG तत्वों की रचना को नियंत्रित करने की अनुमति देता है।

जब निर्यात किया गया SVG संक्षिप्त, विभिन्न ब्राउज़र में पूर्वानुमेय या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तो [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) का प्रयोग करें।

## **एक स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाएं, स्लाइड चुनें, और उसे [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) के द्वारा स्ट्रीम में लिखें। नीचे दिया गया उदाहरण प्रस्तुति की प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल के रूप में निर्यात करता है।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

फ़ाइलनाम बनाते समय लूप इंडेक्स के बजाय [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) का उपयोग किया गया है। आप आवश्यकता अनुसार केवल किसी विशिष्ट आकार को निर्यात करने के लिए [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) का उपयोग कर सकते हैं, जब स्लाइड व्यूयर या वेब पेज को केवल वही आकार चाहिए।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) रेंडरिंग एरिया में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) निर्धारित करता है कि फ्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) को `true` पर सेट करें।

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **टेक्स्ट और फ़ॉन्ट को नियंत्रित करें**

स्लाइड को SVG में निर्यात करते समय आप यह तय कर सकते हैं कि टेक्स्ट टेक्स्ट के रूप में रहे या वेक्टर ग्राफ़िक्स में बदल दिया जाए, तथा बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित हों। नीचे दिए विकल्प दृश्य स्थिरता, टेक्स्ट चयन और फ़ॉन्ट निर्भरताओं को संतुलित करने में मदद करते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) को `true` पर सेट करने से सभी स्लाइड टेक्स्ट वेक्टर ग्राफ़िक्स के रूप में लिखा जाता है। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और विभिन्न ब्राउज़र में दृश्य परिणाम अधिक सुसंगत रहता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **बाहरी फ़ॉन्ट कैसे संभालें चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) मान उपयोग करता है। `AddLinksToFontFiles` चुनें ताकि अलग‑अलग फ़ॉन्ट फ़ाइलों का संदर्भ दिया जाए, `Embed` चुनें ताकि फ़ॉन्ट डेटा SVG में सम्मिलित हो, या `Vectorize` चुनें ताकि बाहरी फ़ॉन्ट का उपयोग करने वाले टेक्स्ट को केवल ग्राफ़िक्स के रूप में रेंडर किया जाए। फ़ॉन्ट को एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करना न भूलें।

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **एम्बेडेड इमेज का आकार घटाएँ**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) का उपयोग करके एम्बेडेड चित्रों का रिज़ॉल्यूशन कम करें, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) से क्रॉप किए गए स्रोत क्षेत्रों को हटाएँ, और [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) से JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं, लेकिन इमेज की स्पष्टता या रखी गई डेटा की कीमत पर।

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **मेटा‑फ़ाइल रास्टराइज़ेशन रिज़ॉल्यूशन नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) SVG निर्यात के दौरान मेटा‑फ़ाइल को रास्टराइज़ करने की निचली रिज़ॉल्यूशन सीमा निर्धारित करता है। इसका उपयोग EMF या WMF चित्र को रास्टराइज़ करते समय विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिये करें। यह SVG के लिए वैश्विक DPI निर्धारित नहीं करता और न ही स्लाइड के प्रत्येक ऑब्जेक्ट को रास्टर इमेज में बदलता है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें; इसमें निकट‑स्थापित तिरछी रेखाओं वाला एक EMF चित्र शामिल है। नीचे दिया गया उदाहरण [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) के माध्यम से पहली स्लाइड को तीन अलग‑अलग रास्टराइज़ेशन रिज़ॉल्यूशन पर निर्यात करता है। अन्य सभी निर्यात सेटिंग समान रहें ताकि परिणामों की तुलना की जा सके।

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

आउटपुट में EMF प्रत्येक SVG में एक एम्बेडेड PNG में बदल गया। नीचे दी गई मापें प्रदान की गई प्रस्तुति के लिए हैं; ये DPI को पिक्सेल आयामों में बदलने के लिये सामान्य सूत्र नहीं हैं।

| Metafile rasterization DPI | Embedded PNG dimensions | SVG file size (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे का तुलना चित्र समान आकार के एम्बेडेड रास्टर को समान बड़े डिस्प्ले आकार पर दिखाता है। तिरछी रेखाएँ 72 DPI पर स्पष्ट पिक्सेलेशन दिखाती हैं और उच्च रिज़ॉल्यूशन पर स्मूथ किनारे दिखाते हैं, जबकि SVG फ़ाइल आकार बढ़ता है। मान बढ़ाना अनिवार्य रूप से हर विवरण को सुधारेगा या हर निर्यातित इमेज को बदल देगा नहीं।

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) चित्र रिज़ॉल्यूशन घटाता है और मेटा‑फ़ाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छुपा सकता है। [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, न कि मेटा‑फ़ाइल रास्टराइज़ेशन रिज़ॉल्यूशन को।

## **आकारों और टेक्स्ट को स्थिर ID असाइन करें**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) को एक फ़ॉर्मेटिंग कॉलबैक प्रदान करें ताकि प्रत्येक SVG आकार के लिए [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) सेट किया जा सके। यह कॉलबैक टेक्स्ट के `tspan` तत्वों पर [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) मान भी सेट कर सकता है।

PhpJavaBridge `writeAsSvg` को स्ट्रीम मोड में चलाते समय PHP कॉलबैक को नहीं बुला सकता। फ़ॉर्मेटिंग लॉजिक को एक छोटे Java हेल्पर क्लास में रखें, उसे कंपाइल करें, और परिणामी JAR फ़ाइल को ब्रिज क्लासपाथ में जोड़ें। हेल्पर [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) का उपयोग कर सकता है, जो आकार के जीवनकाल के लिये स्थिर रहता है, तथा टेक्स्ट स्पैन्स के लिये पुनरावृत्त काउंटर प्रदान करता है। इस हेल्पर कोड के लिये देखें [Java implementation of `StableSvgIdController`](/slides/hi/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)।

कम्पाइल किया हुआ `com.example.slides.StableSvgIdController` क्लास ब्रिज क्लासपाथ में जोड़ने के बाद, PHP से उसे इंस्टैंशिएट करें और `SVGOptions` को असाइन करें:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **SVG इवेंट हैंडलर्स जोड़ें**

फ़ॉर्मेटिंग कॉलबैक में, एक [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) मान के साथ [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) को कॉल करें ताकि निर्यात किए गए आकार में JavaScript इवेंट हैंडलर जोड़ सकें। कॉलबैक को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) के द्वारा असाइन करें और वह JavaScript फ़ंक्शन पेज या SVG दस्तावेज़ में परिभाषित करें जो परिणाम को होस्ट करता है।

स्थिर ID की तरह, जब PhpJavaBridge स्ट्रीम मोड उपयोग करता है तो कॉलबैक को Java हेल्पर में लागू करें। [Java implementation of `SvgEventController`](/slides/hi/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) एक आकार `ActionButton` को ID और `OnClick` हैंडलर असाइन करता है। उस हेल्पर को कंपाइल करें, उसे ब्रिज क्लासपाथ में `com.example.slides.SvgEventController` के रूप में जोड़ें, और PHP से नीचे दिखाए अनुसार उपयोग करें:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

होस्ट पेज वह JavaScript फ़ंक्शन परिभाषित कर सकता है जिसका उल्लेख हैंडलर में है। ID और इवेंट हैंडलर असाइन करने से स्लाइड व्यूअर, एक्सेसेबिलिटी सुधार और अन्य इंटरैक्टिव SVG वर्कफ़्लो सक्षम होते हैं।

## **FAQ**

**कब मुझे [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) का उपयोग करना चाहिए बजाय [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए, तब [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) उपयोग करें। जब केवल बाहरी फ़ॉन्ट वाले टेक्स्ट को ग्राफ़िक्स में बदलना हो, तब [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) उपयोग करें।

**SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एम्बेडेड चित्रों को संपीड़ित करें, क्रॉप किए गए चित्र क्षेत्रों को हटाएँ, और लक्षित वातावरण को यदि फ़ॉन्ट फ़ाइलों को सर्व कर सकता है तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम की जाँच करें क्योंकि कम चित्र रिज़ॉल्यूशन, कम JPEG गुणवत्ता और वेक्टराइज़्ड टेक्स्ट प्रत्येक की अलग‑अलग गुणवत्ता‑आकार संतुलन होती है।

**क्या निर्यात के पश्चात मैं निर्यात किए गए SVG तत्वों को संशोधित कर सकता हूँ?**

हाँ। फ़ॉर्मेटिंग कॉलबैक के द्वारा ID असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चुनें।