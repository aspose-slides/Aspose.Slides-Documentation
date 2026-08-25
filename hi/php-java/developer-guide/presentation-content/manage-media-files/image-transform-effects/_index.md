---
title: PHP के साथ प्रस्तुतियों में इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स का प्रबंधन
linktitle: इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स
type: docs
weight: 11
url: /hi/php-java/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- चित्र प्रभाव
- चमक
- कंट्रास्ट
- ग्रेस्केल
- डुओटोन
- टिंट
- एचएसएल
- रंग प्रतिस्थापन
- ब्लर
- पारदर्शिता
- अल्फा प्रभाव
- इफ़ेक्ट श्रृंखला
- पावरपॉइंट
- प्रस्तुति
- पीएचपी
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ चित्र फ्रेम के लिए इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ और सत्यापित करें।"
---
## **सारांश**

Aspose.Slides चित्र समायोजन को छवि परिवर्तन संचालन के क्रमबद्ध संग्रह के रूप में प्रदर्शित करता है। किसी चित्र फ्रेम के लिए, फ्रेम की [Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picture/) से शुरू करें और [Picture::getImageTransform](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picture/getimagetransform/) का उपयोग करें। लौटाया गया [ImageTransformOperationCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/) आपको प्रभावों को जोड़ने, गिनने, निरीक्षण करने, हटाने और साफ़ करने की सुविधा देता है बिना मूल छवि बाइट्स को पुनर्लिखे।

यह लेख चमक और कंट्रास्ट, रंग रूपांतरण, धुंधलापन, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखलाएं, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण वर्कफ़्लो दर्शाता है।

## **प्रभाव मालिकाना हक और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और उसे प्रदर्शित करने वाली तस्वीर दो अलग-अलग वस्तुएँ हैं:

- [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) प्रस्तुति द्वारा मालिक़े वाली स्रोत छवि डेटा को संग्रहीत या संदर्भित करता है।
- [Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picture/) एक चित्र भराव से संबंधित है और एक छवि संसाधन को संदर्भित करता है, जबकि छवि परिवर्तन संग्रह को संग्रहीत करता है।
- [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) वह स्लाइड आकार है जो संबंधित चित्र भराव, ज्यामिति, क्रॉप सेटिंग्स, और अन्य फ्रेम‑स्तरीय स्वरूपण का स्वामी है।

इसलिए, छवि परिवर्तन संचालन [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) में बाइट्स को संशोधित नहीं करते हैं। जब एक ही `PPImage` को [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addpictureframe/) को एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ्रेम अपना स्वयं का `Picture` और अपना स्वयं का परिवर्तन संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं हो जाते, जबकि सभी एक ही एम्बेडेड छवि संसाधन को पुन: उपयोग करते हैं।

उसी `Picture::getImageTransform` मॉडल का उपयोग अन्य चित्र भराव, जैसे कि आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण चित्र फ्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयों का उपयोग करें**

प्रदर्शित विधियों में निम्न सेमेंटिक रेंज और इकाइयों का उपयोग किया जाता है। इन रेंज में मान रखें भले ही कोई विशिष्ट लाइब्रेरी संस्करण तुरंत सभी आउट‑ऑफ़‑रेंज मानों को न ठुकराए; लक्ष्य प्रस्तुति स्वरूप सहेजने या PowerPoint द्वारा फ़ाइल खोलने के दौरान अमान्य डेटा को सामान्यीकृत, हटाए, या अस्वीकृत कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित छोड़ता है। |
| [addGrayScaleEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [addDuotoneEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | डार्क और लाइट पिक्सेल के लिए दो रंग। `java.awt.Color` में RGB और अल्फा चैनल `0` से `255` तक उपयोग करते हैं। |
| [addTintEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue `0` (समावेशी) से `360` (बहिष्कृत) डिग्री में; amount `-100` से `100` तक, प्रतिशत। |
| [addHSLEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue `0` (समावेशी) से `360` (बहिष्कृत) डिग्री; saturation और luminance `-100` से `100` तक, प्रतिशत। |
| [addColorReplaceEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | प्रतिस्थापन रंग `0` से `255` तक के चैनल मानों का उपयोग करता है। मौजूदा अल्फा मान अपरिवर्तित रहते हैं। |
| [addBlurEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius गैर‑ऋणात्मक है और पॉइंट में मापा जाता है; `grow` एक Boolean है जो नियंत्रित करता है कि धुंधला सामग्री मूल सीमाओं से बाहर विस्तारित हो सकती है या नहीं। |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | गैर‑ऋणात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी है और `100` मौजूदा अल्फा को बनाये रखता है। |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशहोल्ड। इस मान से कम मान पारदर्शी हो जाते हैं; बराबर या उससे अधिक मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता परस्पर पूरक हैं। उदाहरण के लिए, 35% पारदर्शिता का अर्थ 65% अल्फा मॉड्यूलेशन राशि के बराबर होता है।

## **चमक और कंट्रास्ट लागू करें**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) एक [Luminance](https://reference.aspose.com/slides/hi/php-java/aspose.slides/luminance/) ऑपरेशन वापस करता है। इसके स्केलर सेटिंग्स ऑपरेशन बनाते समय प्रदान की जाती हैं। [Luminance::getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/luminance/geteffective/) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिन्हें जांचा या लॉग किया जा सकता है।

निम्न उदाहरण 15% चमक और 20% कंट्रास्ट बढ़ाता है, फिर एम्बेडेड छवि को बदले बिना एक पूर्वावलोकन रेंडर करता है:

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

`Luminance` मानक DrawingML चमक और कंट्रास्ट प्रभाव है। जब इन सेटिंग्स को PPTX राउंड‑ट्रिप के बाद भी संपादनीय रहना आवश्यक हो, तो सहेजी गई प्रस्तुति को पुनः खोलें और ऑपरेशन प्रकार तथा उसके प्रभावी मानों की पुष्टि करें।

## **रंग रूपांतरण लागू करें**

रंग प्रभावों को विभिन्न चित्र फ्रेमों पर स्वतंत्र रूप से लागू किया जा सकता है जो एक ही छवि संसाधन को पुन: उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[Duotone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/duotone/) में दो स्वतंत्र रूप से संपादनीय रंग पैरामीटर होते हैं: `color1` डार्क पिक्सेल को मैप करता है, जबकि `color2` लाइट पिक्सेल को। यह एक ऐसा प्रभाव उदाहरण है जिसका सेटिंग एकल स्केलर मान से अधिक जटिल है।

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

[addColorReplaceEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) प्रत्येक पिक्सेल के रंग को एक स्थिर रंग से बदलता है जबकि अल्फा को बरकरार रखता है। यह [addColorChangeEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और दोनों स्रोत और लक्ष्य रंग स्वरूप प्रदर्शित करता है।

## **धुंधलापन, पारदर्शिता, और अल्फा प्रभाव जोड़ें**

[addBlurEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) सभी रंग चैनलों को प्रभावित करता है, अल्फा सहित। जब धुंधला किनारा मूल चित्र सीमाओं से बाहर विस्तारित हो सकता है, तो `grow` को `true` सेट करें।

समरूप पारदर्शिता के लिए, [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए अंशतः पारदर्शी पिक्सेल अनुपातिक अंतर बनाये रखते हैं। [addAlphaReplaceEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) सभी पिक्सेल को एक ही अल्फा मान असाइन करता है। [addAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में बदलता है।

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

अन्य पैरामीटर‑रहित अल्फा ऑपरेशन्स में [addAlphaCeilingEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/) शामिल है, जो प्रत्येक शून्य‑से‑भिन्न अल्फा को पूरी तरह अपारदर्शी बनाता है; [addAlphaFloorEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/) जो 100% से कम प्रत्येक अल्फा को पूरी तरह पारदर्शी बनाता है; और [addAlphaInverseEffect](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/) जो अल्फा को `100% - alpha` में बदलता है।

## **क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `add...Effect` विधि एक नया ऑपरेशन संग्रह के अंत में जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, और आगे। परिणामस्वरूप, अलग क्रम में वही ऑपरेशन्स अलग छवि उत्पन्न कर सकते हैं।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट पहले रंगीन जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटाता है। इसी प्रकार, अल्फा प्रतिस्थापन पहले के ऑपरेशनों द्वारा गणना किए गए अल्फा मानों को ओवरराइड कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को बरकरार रखता है।

निम्न उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, उसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, दोनों ऑपरेशन प्रकार और क्रम की जाँच करता है, और पुनः खोले गए परिणाम को रेंडर करता है:

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

संग्रह रंग, अल्फा, और धुंधलापन ऑपरेशन्स को अलग‑अलग श्रृंखलाओं में प्रतिबंधित करने वाला संगतता मैट्रिक्स नहीं लगाता। इन्हें संयोजित किया जा सकता है, लेकिन संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटाता है; और अल्फा सीलिंग, फ्लोर, रिप्लेसमेंट, या बाइ‑लेवल ऑपरेशन्स पहले निर्मित अल्फा विवरण को हटा सकते हैं। श्रृंखला को इच्छित पिक्सेल‑प्रसंस्करण क्रम के अनुसार बनाएं, न कि उसके आइटम्स को अनियंत्रित फ़ॉर्मेटिंग फ्लैग मानें।

## **संपादन योग्य और प्रभावी मानों का निरीक्षण करें**

एक संपादन योग्य ऑपरेशन वह वस्तु है जो `Picture::getImageTransform` में संग्रहीत होती है। प्रभाव के आधार पर, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [Blur](https://reference.aspose.com/slides/hi/php-java/aspose.slides/blur/) लिखने योग्य `radius` और `grow` मान दिखाता है, [AlphaModulateFixed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/alphamodulatefixed/) लिखने योग्य `amount` दिखाता है, और [AlphaBiLevel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/alphabilevel/) लिखने योग्य `threshold` दिखाता है। रंग प्रभाव जैसे [Duotone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/duotone/) संशोधनीय [ColorFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorformat/) वस्तुएँ उजागर करता है।

कुछ ऑपरेशन्स, जैसे [Luminance](https://reference.aspose.com/slides/hi/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/hi/php-java/aspose.slides/tint/), और [AlphaReplace](https://reference.aspose.com/slides/hi/php-java/aspose.slides/alphareplace/), अपने निर्माण स्केलर को लिखने योग्य प्रॉपर्टी के रूप में उजागर नहीं करते। उन सेटिंग्स को बदलने के लिए, ऑपरेशन को हटाएँ और आवश्यक स्थिति पर प्रतिस्थापन जोड़ें।

`getEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और केवल‑पढ़ने‑योग्य है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मानों को पढ़ने में उपयोगी है, लेकिन यह कोई अन्य संपादन सतह नहीं है। निम्न उदाहरण श्रृंखला को गिनता है और जहाँ संबंधित API प्रदान करती है, प्रभावी मानों का निरीक्षण करता है:

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

पैरामीटर‑रहित प्रभाव जैसे ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स भी एक प्रभावी‑डेटा वस्तु रखते हैं, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनके अस्तित्व और संग्रह में स्थिति ही महत्वपूर्ण जानकारी है।

## **छवि परिवर्तन हटाएँ या साफ़ करें**

एक ऑपरेशन को इंडेक्स द्वारा हटाने के लिए [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/removeat/) का उपयोग करें। हटाने के बाद इंडेक्स बदलते हैं, इसलिए पहले लक्ष्य खोजें और गिनती के बाद हटाएँ। पूरी श्रृंखला हटाने के लिए [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagetransformoperationcollection/clear/) का उपयोग करें।

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

परिवर्तनों को हटाने या साफ़ करने से केवल चित्र स्वरूपण बदलता है। यह पुनः उपयोग किए गए [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) संसाधन को नहीं हटाता, पुनः संपीड़ित करता, या किसी अन्य तरह बदलता है।

## **प्रस्तुति स्वरूप और निर्यात लक्ष्य पर विचार करें**

छवि परिवर्तन DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिए प्राथमिक संपादनीय स्वरूप है। PPTX के साथ भी, हर ऑपरेशन की पोर्टेबिलिटी समान नहीं होती:

- luminance, grayscale, duotone, tint, HSL, blur, और सामान्य अल्फा ऑपरेशन्स जैसी मानक DrawingML ऑपरेशन्स PPTX राउंड‑ट्रिप में जीवित रहने की सर्वोत्तम संभावना रखते हैं। संरक्षण की आवश्यकता होने पर उत्पन्न फ़ाइल को हमेशा पुनः खोलें और संग्रह की जाँच करें।
- बाइनरी PPT स्वरूप पूर्ण DrawingML प्रभाव मॉडल से पहले आया है। PPT में सहेजने से असमर्थित ऑपरेशन्स को छोड़ दिया जा सकता है, श्रृंखला को समर्थित उपसमूह में घटाया जा सकता है, या उपस्थिति का अनुमान लगाया जा सकता है। जटिल संपादन योग्य श्रृंखला के लिए सत्यापन स्वरूप के रूप में PPT का उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य दृश्य आउटपुट में रेंडरिंग समर्थित श्रृंखला को रेंडर किये हुए रूप पर लागू करती है। इन आउटपुट में संपादनीय `ImageTransformOperationCollection` नहीं होता; रैस्टर स्वरूप परिणाम को पिक्सल में समतल कर देते हैं, और दस्तावेज़ या वेक्टर निर्यात अपनी रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- प्रभाव लिंक्ड छवि को स्व-समावेशी नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिये प्रस्तुति लोड होते समय लिंक्ड संसाधन उपलब्ध होना आवश्यक है।

विभिन्न प्रस्तुति उपभोक्ता किनारे के मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेष रूप से जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन्स संयोजित होते हैं। महत्वपूर्ण आउटपुट के लिये, उत्पादन में उपयोग किए गए समान Aspose.Slides संस्करण के साथ दोनों संपादन योग्य राउंड‑ट्रिप और अंतिम निर्यात स्वरूप का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि परिवर्तन प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। ऑपरेशन चित्र भराव द्वारा उपयोग किए गए `Picture` से संबंधित हैं। अंतर्निहित `PPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम जो एक ही छवि को पुन: उपयोग करते हैं, अपने प्रभाव साझा करेंगे?**

नहीं। `PPImage` को पुन: उपयोग करने से डुप्लिकेट छवि डेटा से बचा जा सकता है, लेकिन प्रत्येक चित्र फ्रेम आमतौर पर अलग `Picture` और छवि परिवर्तन संग्रह रखता है।

**क्या रंग, धुंधलापन, और अल्फा प्रभावों को संयोजित किया जा सकता है?**

हाँ। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। हर ऑपरेशन पिछले के आउटपुट पर क्या प्रभाव डालता है, इस पर विचार करें क्योंकि प्रतिस्थापन और थ्रेशहोल्ड ऑपरेशन्स पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान पढ़ने‑के‑लिए‑ही क्यों हैं?**

प्रभावी डेटा रेंडरिंग के लिए उपयोग किए गए गणना किए गए मानों को दर्शाता है, जिसमें हल किए गए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हैं, उस परिवर्तन संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ एक प्रतिस्थापन जोड़ें।

**मैं कौन सा स्वरूप उपयोग करूँ ताकि परिवर्तन श्रृंखला सुरक्षित रहे?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को प्रस्तुत नहीं कर सकता, और रेंडर किए गए निर्यात स्वरूप केवल रूप को संरक्षित करते हैं न कि संपादनीय परिवर्तन ऑपरेशन्स।