---
title: PHP में प्रस्तुति स्लाइड को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड को SVG में
type: docs
weight: 50
url: /hi/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint को SVG में
- प्रस्तुति को SVG में
- स्लाइड को SVG में
- PPT को SVG में
- PPTX को SVG में
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में PowerPoint स्लाइड को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, पाठ, चित्र, IDs और इवेंट्स को नियंत्रित करें।"
---
## **सारांश**

SVG एक स्केलेबल XML‑आधारित चित्र प्रारूप है जो वेब प्रकाशन, स्लाइड व्यूअर, पहुँचयोग्य कार्य‑प्रवाह और स्वचालित पश्च‑प्रसंस्करण के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल में निर्यात करता है और आपको पाठ, फ़ॉन्ट, चित्र तथा SVG तत्वों को कैसे लिखा जाए, नियंत्रित करने देता है।

जब निर्यातित SVG को संक्षिप्त, ब्राउज़र‑संगत या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तो [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) का उपयोग करें।

## **एक स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाएँ, स्लाइड चुनें, और उसे [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) के साथ स्ट्रीम में लिखें। निम्न उदाहरण प्रस्तुति की प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल के रूप में निर्यात करता है।

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

फ़ाइलनाम [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) का उपयोग करता है, लूप सूचकांक के बजाय। आप किसी विशेष आकृति को भी [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) के साथ निर्यात कर सकते हैं, जब स्लाइड व्यूअर या वेब पृष्ठ को केवल वही आकृति चाहिए।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। पाठ फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) रेंडरिंग क्षेत्र में पाठ फ्रेम को सम्मिलित करता है, तथा [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) निर्धारित करता है कि फ्रेम घुमाव लागू किया जाए या नहीं। जब पाठ को लिगेचर‑रहित रेंडर किया जाना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) को `true` सेट करें।

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

## **तीर‑छोर पर लाइन‑एंड क्रॉपिंग को नियंत्रित करें**

SVG 1.1 में मार्कर इन्सेट सेटिंग नहीं है जिससे यह निर्धारित किया जा सके कि कोई रेखा तीर‑छोर के नीचे कहाँ समाप्त हो। डिफ़ॉल्ट रूप से, Aspose.Slides निर्यातित रेखा को छोटा कर देता है ताकि उसकी स्ट्रोक मार्कर के भीतर न निकलें। इस व्यवहार को बदलने के लिये [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) को `true` सेट करें, जिससे स्ट्रोक मूल अंत बिंदु तक पूरी‑लंबाई तक खींची जाएगी। यह सेटिंग केवल SVG आउटपुट को प्रभावित करती है; स्लाइड में रेखा की स्थिति और लंबाई अपरिवर्तित रहती है।

उदाहरण में त्रिकोण और हीरे के तीर‑छोर 2 तथा 10‑पॉइंट चौड़ी रेखाओं पर दर्शाए गए हैं। यह वही स्लाइड दो बार निर्यात करता है, केवल क्रॉपिंग विकल्प बदलते हुए।

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

तुलना में 10‑पॉइंट रेखा पर त्रिकोणीय तीर‑छोर दिखाया गया है। क्रॉपिंग सक्षम होने पर टिप तेज़ रहती है; अक्षम होने पर स्ट्रोक मार्कर की झुकी भुजाओं में से निकलती है और समतल अंत बन जाता है।

![क्रॉपिंग सक्षम होने पर तेज़ टिप के साथ बड़ा 10‑पॉइंट त्रिकोण और क्रॉपिंग अक्षम होने पर समतल अंत वाला](line-end-cropping.png)

उदाहरण की अन्य रेखाओं में, 2‑पॉइंट त्रिकोण पर निकलती स्ट्रोक कम स्पष्ट होती है। भरा हुआ हीरा दोनों चौड़ाइयों में स्ट्रोक के अंत को कवर करता है।

## **पाठ और फ़ॉन्ट को नियंत्रित करें**

जब स्लाइडों को SVG में निर्यात किया जाता है, तो आप तय कर सकते हैं कि पाठ पाठ के रूप में बना रहे या वेक्टर ग्राफ़िक्स में परिवर्तित हो, तथा बाहरी फ़ॉन्ट कैसे सम्मिलित या संदर्भित हों। नीचे दिए विकल्प आपके निर्यातित SVG में दृश्य स्थिरता, पाठ चयन और फ़ॉन्ट निर्भरताओं के संतुलन में मदद करेंगे।

### **सभी पाठ को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) को `true` सेट करें ताकि सभी स्लाइड पाठ वेक्टर ग्राफ़िक्स के रूप में लिखा जाए। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और विभिन्न ब्राउज़रों में दृश्य परिणाम अधिक स्थिर रहता है, परन्तु पाठ अब SVG पाठ के रूप में चयन योग्य या खोज योग्य नहीं रहता।

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

### **बाहरी फ़ॉन्ट कैसे संभाले जाएँ चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिये [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। `AddLinksToFontFiles` चुनें ताकि अलग‑अलग फ़ॉन्ट फ़ाइलों को संदर्भित किया जा सके, `Embed` चुनें ताकि फ़ॉन्ट डेटा SVG में सम्मिलित हो, या `Vectorize` चुनें ताकि केवल बाहरी फ़ॉन्ट वाले पाठ को ग्राफ़िक्स में परिवर्तित किया जाए। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंस जाँचें।

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

## **एम्बेडेड इमेज आकार कम करें**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) का प्रयोग करके एम्बेडेड चित्रों के रिज़ॉल्यूशन को घटाएँ, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) से क्रॉप किए गये स्रोत क्षेत्रों को हटाएँ, और [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) से JPEG एन्कोडिंग गुणवत्ता नियंत्रित करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं, किंतु चित्र गुणवत्ता या रखी गई डेटा पर प्रभाव पड़ता है।

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

## **मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) मेटाफाइल (EMF या WMF) को SVG निर्यात के दौरान रास्टराइज़ करने की न्यूनतम रिज़ॉल्यूशन सीमा निर्धारित करता है। इसे उपयोग कर आप विवरण और फ़ाइल आकार के बीच संतुलन बना सकते हैं। यह SVG के लिए वैश्विक DPI नहीं तय करता और न ही स्लाइड के प्रत्येक वस्तु को रास्टर चित्र बनाता है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें घनी तिर्यक रेखाएँ वाली EMF छवि है। नीचे दिया उदाहरण [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) के ज़रिए पहली स्लाइड को तीन अलग‑अलग रास्टराइज़ेशन रिज़ॉल्यूशन पर निर्यात करता है। अन्य सभी निर्यात सेटिंग समान रहती हैं ताकि परिणामों की तुलना की जा सके।

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

आउटपुट में, EMF प्रत्येक SVG में एक एम्बेडेड PNG बन गया। नीचे दिए माप आपूर्ति किए गए प्रस्तुतीकरण के लिए हैं; ये DPI को पिक्सेल आयाम में बदलने का सामान्य सूत्र नहीं हैं।

| मेटाफाइल रास्टराइज़ेशन DPI | एम्बेडेड PNG माप | SVG फ़ाइल आकार (बाइट) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे की तुलना समान एम्बेडेड रास्टर क्षेत्र को समान बड़े प्रदर्शन आकार पर दर्शाती है। तिर्यक रेखाएँ 72 DPI पर स्पष्ट पिक्सेलेशन दिखाती हैं, जबकि उच्च रिज़ॉल्यूशन पर किनारे स्मूद होते हैं, और SVG फ़ाइल आकार बढ़ता है। मान बढ़ाने से हर विवरण बेहतर नहीं होता और सभी निर्यातित छवियों में परिवर्तन नहीं आता।

![72, 150 और 300 DPI पर बड़ा विकर्ण‑रेखा विवरण](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) चित्र रिज़ॉल्यूशन कमी को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छुपा सकता है। [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, न कि मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को।

## **आकृतियों और पाठ को स्थिर ID सौंपें**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) को एक फ़ॉर्मेटिंग कॉलबैक प्रदान करें जिससे प्रत्येक SVG आकृति के लिये [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) सेट किया जा सके। कॉलबैक टेक्स्ट `tspan` तत्वों पर भी [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) मान सेट कर सकता है।

PhpJavaBridge `writeAsSvg` के स्ट्रिम मोड में चलने पर PHP कॉलबैक को नहीं बुला पाता। फ़ॉर्मेटिंग लॉजिक को एक छोटे Java हेल्पर क्लास में रखें, उसे कॉम्पाइल करें, और उत्पन्न JAR को पुल ब्रिज क्लासपाथ में जोड़ें। हेल्पर [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) का उपयोग कर सकता है, जो आकृति के आयुष्यमान के लिए स्थिर होता है, तथा उसके टेक्स्ट स्पैन के लिये एक पुनरावृत्त काउंटर रख सकता है। देखें [Java implementation of `StableSvgIdController`](/slides/hi/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) हेल्पर कोड के लिये।

कम्पाइल की गई `com.example.slides.StableSvgIdController` क्लास को पुल ब्रिज क्लासपाथ में जोड़ने के बाद, PHP से उसे इंस्टैंशिएट करें और `SVGOptions` को असाइन करें:

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

फ़ॉर्मेटिंग कॉलबैक में, एक [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) को [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) मान के साथ कॉल करें, ताकि निर्यातित आकृति में JavaScript इवेंट हैंडलर जोड़ा जा सके। कॉलबैक को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) से असाइन करें और पृष्ठ या SVG दस्तावेज़ में वह JavaScript फ़ंक्शन परिभाषित करें जो हैंडलर को संदर्भित करता है।

स्थिर ID की तरह, स्ट्रिम मोड में PhpJavaBridge उपयोग होने पर कॉलबैक को Java हेल्पर में लागू करें। देखें [Java implementation of `SvgEventController`](/slides/hi/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) जो `ActionButton` नाम की आकृति को ID और `OnClick` हैंडलर असाइन करता है। इस हेल्पर को `com.example.slides.SvgEventController` के रूप में कॉम्पाइल करें, पुल ब्रिज क्लासपाथ में जोड़ें, और नीचे दिखाए अनुसार PHP से उपयोग करें:

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

होस्ट पृष्ठ उस JavaScript फ़ंक्शन को परिभाषित कर सकता है जिसका हैंडलर संदर्भित है। ID और इवेंट हैंडलर असाइन करने से स्लाइड व्यूअर, पहुँच‑वृद्धि और अन्य इंटरैक्टिव SVG कार्य‑प्रवाह सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मैं [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) का उपयोग करूँ, तो मैं [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) के बजाय कब चुनूँ?**

जब सभी पाठ को फ़ॉन्ट से स्वतंत्र होना चाहिए, तब [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) उपयोग करें। जब केवल वही पाठ जो बाहरी फ़ॉन्ट उपयोग करता है, उसे ग्राफ़िक्स में बदलना हो, तब [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) चुनें।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

पहले एम्बेडेड चित्रों को संकुचित करें, क्रॉप किए गए छवि क्षेत्रों को हटाएँ, और जब लक्ष्य पर्यावरण लिंक्ड फ़ॉन्ट फ़ाइलें प्रदान कर सके तो `AddLinksToFontFiles` चुनें। परिणाम की जाँच करें क्योंकि कम चित्र रिज़ॉल्यूशन, कम JPEG गुणवत्ता और वेक्टराइज़्ड पाठ प्रत्येक का अलग‑अलग क्वालिटी‑साइज़ ट्रेड‑ऑफ़ है।

**क्या निर्यातित SVG तत्वों को निर्यात के बाद संशोधित किया जा सकता है?**

हां। फ़ॉर्मेटिंग कॉलबैक के माध्यम से ID असाइन करें, फिर अपने पश्च‑प्रसंस्करण टूल या ब्राउज़र स्क्रिप्ट में उन मिलते‑जुलते SVG तत्वों को चुनें।