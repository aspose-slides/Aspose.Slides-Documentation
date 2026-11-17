---
title: Presentations में PHP के साथ इमेज ट्रांसफ़ॉर्म इफ़ेक्ट प्रबंधित करें
linktitle: इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स
type: docs
weight: 11
url: /hi/php-java/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- चित्र इफ़ेक्ट
- चमक
- कंट्रास्ट
- ग्रेस्केल
- डुओटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- ब्लर
- ट्रांसपैरेंसी
- अल्फा इफ़ेक्ट
- इफ़ेक्ट चेन
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ चित्र फ़्रेम के लिए इमेज ट्रांसफ़ॉर्म इफ़ेक्ट लागू करें, चेन बनाएं, निरीक्षण करें, हटाएं और सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides चित्र समायोजन को इमेज ट्रांसफ़ॉर्म ऑपरेशन्स के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ्रेम के लिए, फ्रेम की [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) से शुरू करें और [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/) तक पहुँचें। लौटाया गया [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) आपको मूल इमेज बाइट्स को दोबारा लिखे बिना इफ़ेक्ट जोड़ने, क्रमबद्ध करने, निरीक्षण करने, हटाने और साफ़ करने की सुविधा देता है।

यह लेख चमक और कंट्रास्ट, रंग परिवर्तन, ब्लर, ट्रांसपैरेंसी, क्रमबद्ध इफ़ेक्ट चेन, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्य‑प्रवाह दर्शाता है।

## **इफ़ेक्ट स्वामित्व और इमेज पुन: उपयोग को समझें**

एक इमेज रिसोर्स और उसे प्रदर्शित करने वाला चित्र दो अलग‑अलग ऑब्जेक्ट होते हैं:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) प्रस्तुति द्वारा स्वामित्व वाले स्रोत इमेज डेटा को संग्रहीत या संदर्भित करता है।
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) चित्र फ़िल भरने से जुड़ा होता है और इमेज रिसोर्स को संदर्भित करता है जबकि इमेज ट्रांसफ़ॉर्म संग्रह को संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) वह स्लाइड आकार है जो संबंधित चित्र फ़िल, ज्योमेट्री, क्रॉप सेटिंग्स और अन्य फ्रेम‑स्तरीय फ़ॉर्मेटिंग का स्वामी होता है।

इसलिए, इमेज ट्रांसफ़ॉर्म ऑपरेशन्स [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) में बाइट्स को नहीं बदलते। जब वही `PPImage` को कई बार [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) में पास किया जाता है, तो प्रत्येक नया चित्र फ्रेम अपना स्वयं का `Picture` और अपना स्वयं का ट्रांसफ़ॉर्म संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करना दूसरे फ़्रेम को ग्रेस्केल नहीं बनाता, भले ही सभी एक ही एम्बेडेड इमेज रिसोर्स का पुन: उपयोग करें।

उसी `Picture::getImageTransform` मॉडल का उपयोग अन्य चित्र फ़िल्स, जैसे शैप या स्लाइड बैकग्राउंड, में भी किया जाता है। नीचे दिए उदाहरण चित्र फ्रेम्स पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयाँ प्रयोग करें**

प्रदर्शित विधियों में निम्नलिखित अर्थपूर्ण रेंज और इकाइयाँ उपयोग की गई हैं। इन रेंजों के भीतर मान रखें, चाहे कोई विशिष्ट लाइब्रेरी संस्करण तुरंत बाहर की रेंज को न खारिज करे; लक्ष्य प्रस्तुति फ़ॉर्मेट सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, छोड़ या खारिज कर सकता है।

| ऑपरेशन | पैरामीटर | वैध सीमा और इकाई |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | गहरे और हल्के पिक्सेल के दो रंग। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक होते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (बहिष्कृत) डिग्री; मात्रा `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | ह्यू `0` से `360` डिग्री; सैचुरेशन और ल्यूमिनेंस `-100` से `100` प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | प्रतिस्थापित रंग के चैनल मान `0` से `255` तक। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | रेडियस गैर‑नकारात्मक और पॉइंट्स में मापा जाता है; `grow` एक Boolean है जो नियंत्रित करता है कि ब्लर किया गया कंटेंट मूल सीमा से बाहर जा सकता है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | गैर‑नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` प्रयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशहोल्ड। इस से नीचे के मान पारदर्शी, बराबर या अधिक के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मोड्यूलेशन में, ट्रांसपैरेंसी और अपारदर्शिता परस्पर पूरक होते हैं। उदाहरण के लिये, 35% ट्रांसपैरेंसी का मतलब 65% अल्फा मोड्यूलेशन मात्रा के बराबर है।

## **चमक और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) एक [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन निर्माण के समय प्रदान की जाती हैं। [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण चमक को 15% और कंट्रास्ट को 20% बढ़ाता है, फिर एंबेडेड इमेज को बदले बिना एक प्रीव्यू रेंडर करता है:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` स्टैंडर्ड DrawingML चमक‑कंट्रास्ट इफ़ेक्ट है। जब इन सेटिंग्स को PPTX राउंड ट्रिप के बाद भी संपादन योग्य रखना हो, तो सहेजी गई प्रस्तुति को पुनः खोलें और ऑपरेशन प्रकार तथा उसके प्रभावी मान दोनों की जाँच करें।

## **रंग परिवर्तन लागू करें**

रंग इफ़ेक्ट्स को अलग‑अलग चित्र फ्रेम्स पर स्वतंत्र रूप से लागू किया जा सकता है जो एक ही इमेज रिसोर्स पुनः उपयोग करते हैं। नीचे दिया उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, तथा रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) दो स्वतंत्र रूप से संपादनीय रंग पैरामीटर रखता है: `color1` गहरे पिक्सेल को मैप करता है, जबकि `color2` तेज़ पिक्सेल को। यह उन इफ़ेक्ट्स में से एक उपयोगी उदाहरण है जिनकी सेटिंग्स एकल स्केलर मान से अधिक जटिल होती हैं।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदलता है जबकि अल्फा को बरकरार रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत तथा लक्ष्य रंग फॉर्मेट दर्शाता है।

### **ल्यूमिनेंस थ्रेशहोल्ड लागू करें**

ल्यूमिनेंस थ्रेशहोल्ड स्कैन की गई पेज पर हल्की निशानियों को पृष्ठभूमि से अलग दिखाने में मदद कर सकता है। [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) मध्यवर्ती ग्रे शेड्स को बरकरार रखता है। [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) ल्यूमिनेंस को काला या सफेद में मैप करता है, जबकि [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) अपारदर्शिता पर थ्रेशहोल्ड लागू करता है।

ल्यूमिनेंस थ्रेशहोल्ड 0% से 100% (समावेशी) तक रहता है। थ्रेशहोल्ड से नीचे के पिक्सेल काले हो जाते हैं। थ्रेशहोल्ड से बराबर या ऊपर के पिक्सेल सफेद हो जाते हैं। थ्रेशहोल्ड बढ़ाने से अधिक शेड्स काले हो जाते हैं क्योंकि अधिक पिक्सेल कटऑफ़ से नीचे गिरते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को PHP स्क्रिप्ट वाले निर्देशिका में डाउनलोड करें। प्रत्येक लेबल मूल ग्रे स्तर को 0‑255 स्केल पर दर्शाता है। उदाहरण मूल को दो प्रतियों के बगल में रखता है और प्रत्येक प्रतिलिपि का थ्रेशहोल्ड प्रस्तुति में सहेजता है।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और तीन फ्रेम की तुलना करें। लेबल 96 वाली स्वैच लगभग 38% ल्यूमिनेंस (96/255) दर्शाती है। यह 20% थ्रेशहोल्ड पर सफेद और 60% थ्रेशहोल्ड पर काला हो जाता है।

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **ब्लर, ट्रांसपैरेंसी, और अल्फा इफ़ेक्ट जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) सभी रंग चैनलों को प्रभावित करता है, जिसमें अल्फा भी शामिल है। जब ब्लर की किनारी मूल चित्र सीमाओं से बाहर जा सकती है, तो `grow` को `true` सेट करें।

समान ट्रांसपैरेंसी के लिये, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) उपयोग करें। यह प्रत्येक मौजूद अल्फा मान को गुणा करता है, इसलिए आंशिक पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) सभी पिक्सेल को एक ही अल्फा मान सौंपता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में परिवर्तित करता है।

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

अन्य पैरामीटर‑रहित अल्फा ऑपरेशन्स में [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/) शामिल है, जो प्रत्येक शून्य‑से‑भिन्न अल्फा को पूरी तरह अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/) जो 100% से कम प्रत्येक अल्फा को पूरी तरह पारदर्शी बनाता है; तथा [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/) जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध इफ़ेक्ट चेन बनाएँ**

प्रत्येक `add...Effect` विधि संग्रह के अंत में नया ऑपरेशन जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 की इनपुट बन जाता है, आदि। इसलिए, समान ऑपरेशन्स का क्रम बदलने से अलग चित्र बन सकता है।

उदाहरण के लिये, ग्रेस्केल के बाद टिंट पहले क्रोमैटिक जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटा देता है। इसी तरह, अल्फा प्रतिस्थापन पहले के ऑपरेशन्स द्वारा गणना किए गए अल्फा मानों को ओवरराइड कर सकता है, जबकि अल्फा मोड्यूलेशन उनके सापेक्ष अंतर को बरकरार रखता है।

निम्न उदाहरण चार‑ऑपरेशन चेन बनाता है, उसे PPTX के रूप में सहेजता है, फिर प्रस्तुति को पुनः खोलता है, ऑपरेशन प्रकार और क्रम दोनों की जाँच करता है, तथा पुनः खुले परिणाम को रेंडर करता है:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

संग्रह कोई संगतता मैट्रिक्स नहीं थोपता जो रंग, अल्फा, और ब्लर ऑपरेशन्स को अलग‑अलग श्रृंखलाओं में सीमित करता हो। इन्हें संयुक्त किया जा सकता है, परंतु सभी संयोजन हमेशा उपयोगी नहीं होते। स्थिर रंग प्रतिस्थापन पहले के रंग इफ़ेक्ट्स द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ्लोर, रिप्लेसमेंट, या बाइ‑लेवल ऑपरेशन्स पहले बनाए गए अल्फा विवरण को हटाकर सकता है। इच्छित पिक्सेल‑प्रोसेसिंग अनुक्रम के अनुसार चेन बनाएँ, न कि आइटम्स को अनऑर्डर्ड फ़ॉर्मेटिंग फ्लैग मानें।

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*इस Aspose.Slides for .NET 26.11 रेंडर में, 220° टिंट 25% पर ग्रेस्केल चित्र को अपरिवर्तित रखता है। वही टिंट को ग्रेस्केल से पहले लागू करने से अलग टोन बनते हैं।*
<!-- visual-explanation:image-transform-effects:end -->

## **संपादनयोग्य और प्रभावी मान निरीक्षण करें**

एक संपादनयोग्य ऑपरेशन वह ऑब्जेक्ट है जो `Picture::getImageTransform` में संग्रहीत होता है। इफ़ेक्ट के अनुसार, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिये, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) लिखने योग्य `radius` और `grow` मान उजागर करता है, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) लिखने योग्य `amount` उजागर करता है, और [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) लिखने योग्य `threshold` उजागर करता है। [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) जैसे रंग इफ़ेक्ट्स परिवर्तनीय [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) ऑब्जेक्ट उजागर करते हैं।

कुछ ऑपरेशन्स, जैसे [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), और [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), अपने निर्माण स्कैलर को लिखने योग्य प्रॉपर्टी के रूप में नहीं उजागर करते। उन सेटिंग्स को बदलने हेतु ऑपरेशन को हटाएँ और वांछित स्थिति में नया ऑपरेशन जोड़ें।

`getEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया हुआ और केवल‑पढ़ने‑योग्य होता है। यह थीम‑निर्भर रंगों को तय करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मान पढ़ने के लिये उपयोगी है, परन्तु यह कोई अतिरिक्त संपादन सतह नहीं है। नीचे का उदाहरण चेन को क्रमबद्ध करता है और जहाँ उपलब्ध हो, प्रभावी मानों को निरीक्षण करता है:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

बिना पैरामीटर वाले इफ़ेक्ट जैसे ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स के भी एक प्रभावी‑डेटा ऑब्जेक्ट होता है, परन्तु प्रिंट करने के लिये कोई स्केलर सेटिंग नहीं होती। उनका अस्तित्व और संग्रह में स्थिति ही महत्वपूर्ण जानकारी होती है।

## **इमेज ट्रांसफ़ॉर्म हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने हेतु [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) का उपयोग करें। हटाने के बाद इंडेक्स बदलते हैं, इसलिए पहले लक्ष्य खोजें और क्रमबद्ध करने के बाद हटाएँ। पूरी चेन को हटाने हेतु [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) का प्रयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

ट्रांसफ़ॉर्म हटाना या साफ़ करना केवल चित्र फ़ॉर्मेटिंग को बदलता है। यह पुनः उपयोग किए गए [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) रिसोर्स को हटाता, पुनः‑संपीड़ित करता या अन्यथा बदलता नहीं है।

## **प्रेजेंटेशन फ़ॉर्मेट और एक्सपोर्ट लक्ष्य पर विचार करें**

इमेज ट्रांसफ़ॉर्म DrawingML में उत्पन्न होते हैं, इसलिए PPTX इफ़ेक्ट चेन के लिये पसंदीदा संपादन योग्य फ़ॉर्मेट है। PPTX के साथ भी सभी ऑपरेशन्स में समान पोर्टेबिलिटी नहीं होती:

- ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन्स जैसे मानक DrawingML ऑपरेशन्स का PPTX राउंड‑ट्रिप में बने रहने की सबसे अधिक संभावना होती है। जब संरक्षण आवश्यक हो तो हमेशा उत्पन्न फ़ाइल को पुनः खोलें और संग्रह का निरीक्षण करें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML इफ़ेक्ट मॉडल से पूर्व है। PPT में सहेजने से असमर्थित ऑपरेशन्स छोड़ दिए जा सकते हैं, चेन को समर्थित उपसमुच्चय में घटा दिया जा सकता है, या रूपरचना का अनुमान लगाया जा सकता है। जटिल संपादन योग्य चेन के लिये PPT को सत्यापन फ़ॉर्मेट के रूप में न उपयोग करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य दृश्य आउटपुट पर रेंडरिंग समर्थनित चेन को रेंडर्ड रूप में लागू करती है। इन आउटपुट में संपादन योग्य `ImageTransformOperationCollection` नहीं होता; रास्टर फ़ॉर्मेट परिणाम को पिक्सेल में फ़्लैटन करता है, और दस्तावेज़ या वेक्टर निर्यात अपना स्वयं का रेंडरिंग प्रतिनिधित्व संग्रहीत करता है।
- इफ़ेक्ट्स लिंक्ड इमेज को स्वंतत्र नहीं बनाते। लिंक्ड चित्र का रेंडरिंग तब भी लिंक्ड रिसोर्स पर निर्भर करता है जब प्रस्तुति लोड की जाती है।

विभिन्न प्रेजेंटेशन उपभोक्ता किनारे के मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेषकर जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन्स संयुक्त हों। महत्वपूर्ण आउटपुट के लिये, संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात फ़ॉर्मेट दोनों का वही Aspose.Slides संस्करण उपयोग करके परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या इमेज ट्रांसफ़ॉर्म इफ़ेक्ट एम्बेडेड इमेज डेटा को बदलते हैं?**

नहीं। ऑपरेशन्स `Picture` से जुड़े होते हैं जो चित्र फ़िल द्वारा उपयोग किया जाता है। आधारभूत `PPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम्स जो एक ही इमेज पुनः उपयोग करते हैं, अपने इफ़ेक्ट्स साझा करते हैं?**

नहीं। `PPImage` को पुनः उपयोग करने से डुप्लिकेट इमेज डेटा बचता है, पर प्रत्येक चित्र फ्रेम सामान्यतः अलग `Picture` और अलग इमेज ट्रांसफ़ॉर्म संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा इफ़ेक्ट्स को संयुक्त किया जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध चेन में स्वीकार करता है। प्रत्येक ऑपरेशन के बाद आउटपुट पर अगले ऑपरेशन का प्रभाव देखें, क्योंकि प्रतिस्थापन और थ्रेशहोल्ड ऑपरेशन्स पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिये उपयोग किए गए गणना किए गए मानों को दर्शाता है, जिसमें हल किए गए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, ट्रांसफ़ॉर्म संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नए निर्माण पैरामीटर के साथ जोड़ें।

**कौन‑सा फ़ॉर्मेट ट्रांसफ़ॉर्म चेन को संरक्षित रखेगा?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगसी PPT पूरी DrawingML इफ़ेक्ट मॉडल को दर्शा नहीं सकता, और रेंडर किए गए एक्सपोर्ट फ़ॉर्मेट केवल उपस्थिति को संरक्षित करता है, न कि संपादन योग्य ट्रांसफ़ॉर्म ऑपरेशन्स को।