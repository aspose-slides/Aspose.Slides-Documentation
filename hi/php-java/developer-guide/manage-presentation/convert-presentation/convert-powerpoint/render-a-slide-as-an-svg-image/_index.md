---
title: PHP में प्रस्तुति स्लाइड्स को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/php-java/render-a-slide-as-an-svg-image/
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
- PHP
- Aspose.Slides
description: "PHP में PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, IDs और ईवेंट्स को नियंत्रित करें।"
---
## **Overview**

SVG एक स्केलेबल XML‑आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, एक्सेसिबिलिटी वर्कफ़्लो, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको नियंत्रित करने देता है कि टेक्स्ट, फ़ॉन्ट, चित्र, और SVG तत्व कैसे लिखे जाएँ।

जब निर्यात किया गया SVG कॉम्पैक्ट, ब्राउज़र‑क्रॉस‑प्रेडिक्टेबल, या इंटरैक्टिव उपयोग के लिए तैयार हो, तब [SVGOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/) का उपयोग करें।

## **Export a Slide as SVG**

एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाएँ, एक स्लाइड चुनें, और उसे [Slide.writeAsSvg](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#writeAsSvg) के साथ स्ट्रीम में लिखें। निम्न उदाहरण प्रस्तुति की प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल के रूप में निर्यात करता है।

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

फ़ाइलनाम [Slide.getSlideNumber](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getSlideNumber) का उपयोग करता है, न कि लूप इंडेक्स का। जब स्लाइड व्यूअर या वेब पेज को केवल किसी विशिष्ट शैप की आवश्यकता हो, तब आप [Shape.writeAsSvg](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#writeAsSvg) के साथ व्यक्तिगत शैप भी निर्यात कर सकते हैं।

## **Configure SVG Output**

[SVGOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setUseFrameSize) रेंडरिंग एरिया में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setUseFrameRotation) निर्धारित करता है कि फ्रेम रो्टेशन लागू किया जाए या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) को `true` सेट करें।

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

## **Control Text and Fonts**

### **Vectorize All Text**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setVectorizeText) को `true` सेट करके सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक्स के रूप में लिखा जाता है। यह फ़ॉन्ट निर्भरताओं को हटाता है और दृश्य परिणाम को ब्राउज़र‑क्रॉस‑कंसिस्टेंट बनाता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

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

### **Choose How External Fonts Are Handled**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। `AddLinksToFontFiles` चुनें ताकि अलग‑अलग फ़ॉन्ट फ़ाइलों का रेफ़रेंस हो, `Embed` चुनें ताकि फ़ॉन्ट डेटा SVG में शामिल हो, या `Vectorize` चुनें ताकि बाहरी फ़ॉन्ट वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर किया जाए। फ़ॉन्ट एम्बेड करने से पहले उनके लाइसेंसिंग की जाँच करें।

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

## **Reduce Embedded Image Size**

एम्बेडेड चित्रों के रिज़ॉल्यूशन को घटाने के लिए [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setPicturesCompression) का उपयोग करें, क्रॉप किए गए स्रोत क्षेत्रों को छोड़ने के लिए [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) और JPEG एन्कोडिंग क्वालिटी को नियंत्रित करने के लिए [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setJpegQuality) का उपयोग करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज फ़िडेलिटी या रखे गये इमेज डेटा की कीमत पर आती हैं।

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

## **Assign Stable IDs to Shapes and Text**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setShapeFormattingController) को एक फ़ॉर्मेटिंग कॉलबैक दें ताकि प्रत्येक SVG शैप के लिए [SvgShape.setId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgshape/#setId) सेट किया जा सके। यह कॉलबैक टेक्स्ट `tspan` एलिमेंट्स पर [SvgTSpan.setId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgtspan/#setId) मान भी सेट कर सकता है।

PhpJavaBridge `writeAsSvg` के स्ट्रीम मोड में चलने पर PHP कॉलबैक को नहीं बुला सकता। फ़ॉर्मेटिंग लॉजिक को एक छोटे Java हेल्पर क्लास में रखें, उसे कम्पाइल करें, और परिणामी JAR फ़ाइल को ब्रिज क्लासपाथ में जोड़ें। हेल्पर [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/#getOfficeInteropShapeId) का उपयोग कर सकता है, जो शैप के जीवनकाल के दौरान स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक पुनरावृत्त काउंटर रखता है। हेल्पर कोड के लिए देखें [Java implementation of `StableSvgIdController`](/slides/hi/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)।

कम्पाइल किया गया `com.example.slides.StableSvgIdController` क्लास ब्रिज क्लासपाथ में जोड़ने के बाद, PHP से उसे इंस्टैंशिएट करें और `SVGOptions` को असाइन करें:

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

## **Add SVG Event Handlers**

फ़ॉर्मेटिंग कॉलबैक में, एक [SvgEvent](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgevent/) मान के साथ [SvgShape.setEventHandler](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgshape/#setEventHandler) को कॉल करके निर्यात किए गए शैप में JavaScript इवेंट हैंडलर जोड़ें। कॉलबैक को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setShapeFormattingController) से असाइन करें और पेज या SVG दस्तावेज़ में वह JavaScript फ़ंक्शन परिभाषित करें जो परिणाम को होस्ट करता है।

स्थिर IDs की तरह, जब PhpJavaBridge स्ट्रीम मोड में चल रहा हो, तो कॉलबैक को Java हेल्पर में इम्प्लीमेंट करें। [Java implementation of `SvgEventController`](/slides/hi/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) एक `ActionButton` नामक शैप को ID और `OnClick` हैंडलर असाइन करती है। उस हेल्पर को कम्पाइल करें, उसे ब्रिज क्लासपाथ में `com.example.slides.SvgEventController` के रूप में जोड़ें, और PHP से इस प्रकार उपयोग करें:

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

होस्ट पेज हैंडलर द्वारा रेफ़रenced JavaScript फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर असाइन करने से स्लाइड व्यूअर्स, एक्सेसिबिलिटी एन्हांसमेंट, और अन्य इंटरैक्टिव SVG वर्कफ़्लो सक्षम होते हैं।

## **FAQ**

**When should I use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setVectorizeText) instead of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgexternalfontshandling/)?**

सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र रखना हो तो [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/#setVectorizeText) उपयोग करें। केवल वह टेक्स्ट जो बाहरी फ़ॉन्ट उपयोग करता है, उसे ग्राफ़िक्स में बदलना हो तो [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgexternalfontshandling/) उपयोग करें।

**What is the best way to make an SVG smaller?**

सबसे पहले एम्बेडेड चित्रों को कम्प्रेस करें, क्रॉप्ड इमेज क्षेत्रों को हटाएँ, और जब टार्गेट वातावरण उन्हें सर्व कर सके तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG क्वालिटी, और वेक्टराइज़्ड टेक्स्ट प्रत्येक की गुणवत्ता और आकार में अलग‑अलग ट्रेड‑ऑफ़ लाते हैं।

**Can I modify exported SVG elements after export?**

हाँ। फ़ॉर्मेटिंग कॉलबैक के द्वारा IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG एलिमेंट्स को चुनें।