---
title: PHP में प्रस्तुति पृष्ठभूमियों का प्रबंधन
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/php-java/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- ठोस रंग
- ग्रेडिएंट रंग
- छवि पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमियों को सेट करना सीखें, कोड टिप्स के साथ अपनी प्रस्तुतियों को सुदृढ़ बनाएं।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट, और छवियों का अक्सर स्लाइड पृष्ठभूमियों के लिए उपयोग किया जाता है। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइड पर लागू) की पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint पृष्ठभूमि](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में विशिष्ट स्लाइड की पृष्ठभूमि को सॉलिड रंग से सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड उपयोग में हो। यह परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Solid` सेट करें।
4. सॉलिड पृष्ठभूमि रंग निर्दिष्ट करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) पर [getSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/#getSolidFillColor) मेथड का उपयोग करें।
5. परिवर्तित प्रस्तुति को सहेजें।

निम्न PHP उदाहरण दिखाता है कि सामान्य स्लाइड की पृष्ठभूमि को नीला सॉलिड रंग कैसे सेट किया जाए:

```php
// Presentation क्लास की एक इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // स्लाइड की पृष्ठभूमि का रंग नीला सेट करें।
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // प्रस्तुति को डिस्क पर सहेजें।
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **मास्टर स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड की पृष्ठभूमि को सॉलिड रंग से सेट करने की अनुमति देता है। मास्टर स्लाइड सभी स्लाइडों के फ़ॉर्मेटिंग को नियंत्रित करने वाला टेम्प्लेट होता है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो यह प्रत्येक स्लाइड पर लागू हो जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. मास्टर स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/backgroundtype/) (`getMasters` के माध्यम से) को `OwnBackground` सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Solid` सेट करें।
4. सॉलिड पृष्ठभूमि रंग निर्दिष्ट करने के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/#getSolidFillColor) मेथड का उपयोग करें।
5. परिवर्तित प्रस्तुति को सहेजें।

निम्न PHP उदाहरण दिखाता है कि मास्टर स्लाइड की पृष्ठभूमि को हरा सॉलिड रंग कैसे सेट किया जाए:

```php
// Presentation क्लास की एक इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // मास्टर स्लाइड की पृष्ठभूमि का रंग फ़ॉरेस्ट ग्रीन सेट करें।
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // प्रस्तुति को डिस्क पर सहेजें।
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **स्लाइड के लिए ग्रेडिएंट पृष्ठभूमि सेट करें**

ग्रेडिएंट एक ग्राफ़िकल प्रभाव है जो रंग में क्रमिक परिवर्तन द्वारा बनाया जाता है। स्लाइड पृष्ठभूमि के रूप में उपयोग किए जाने पर, ग्रेडिएंट प्रस्तुतियों को अधिक कलात्मक और पेशेवर बनाते हैं। Aspose.Slides आपको स्लाइडों की पृष्ठभूमि को ग्रेडिएंट रंग से सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Gradient` सेट करें।
4. वांछित ग्रेडिएंट सेटिंग्स को कॉन्फ़िगर करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) पर [getGradientFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/#getGradientFormat) मेथड का उपयोग करें।
5. परिवर्तित प्रस्तुति को सहेजें।

निम्न PHP उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि को ग्रेडिएंट रंग कैसे सेट किया जाए:

```php
// Presentation क्लास की एक इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // पृष्ठभूमि पर ग्रेडिएंट प्रभाव लागू करें।
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // प्रस्तुति को डिस्क पर सहेजें।
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फिल्स के अलावा, Aspose.Slides आपको छवियों को स्लाइड पृष्ठभूमि के रूप में उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/backgroundtype/) को `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि के [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) को `Picture` सेट करें।
4. वह छवि लोड करें जिसे आप स्लाइड पृष्ठभूमि के रूप में उपयोग करना चाहते हैं।
5. छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
6. स्लाइड पृष्ठभूमि के रूप में छवि असाइन करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) पर [getPictureFillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/#getPictureFillFormat) मेथड का उपयोग करें।
7. परिवर्तित प्रस्तुति को सहेजें।

निम्न PHP उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि को छवि कैसे सेट किया जाए:

```php
// Presentation क्लास की एक इंस्टेंस बनाएं।
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // पृष्ठभूमि छवि गुण सेट करें।
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // छवि लोड करें।
    $image = Images::fromFile("Tulips.jpg");
    // छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // प्रस्तुति को डिस्क पर सहेजें।
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

निम्न कोड नमूना दिखाता है कि बैकग्राउंड फ़िल टाइप को टाइल्ड पिक्चर पर कैसे सेट किया जाए और टाइलिंग प्रॉपर्टीज़ को संशोधित किया जाए:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // पृष्ठभूमि भराव के लिए उपयोग की गई छवि सेट करें।
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // चित्र भराव मोड को टाइल पर सेट करें और टाइल गुणों को समायोजित करें।
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
और पढ़ें: [**टाइल पिक्चर एज़ टेक्सचर**](/slides/hi/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री अधिक स्पष्ट दिखे। निम्न PHP कोड दिखाता है कि स्लाइड पृष्ठभूमि छवि की पारदर्शिता कैसे बदलें:

```php
$transparencyValue = 30; // उदाहरण के लिए।

// चित्र ट्रांसफ़ॉर्म ऑपरेशनों का संग्रह प्राप्त करें।
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// एक मौजूदा निश्चित प्रतिशत पारदर्शिता प्रभाव खोजें।
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// नया पारदर्शिता मान सेट करें।
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides `BackgroundEffectiveData` क्लास प्रदान करता है जो स्लाइड की प्रभावी पृष्ठभूमि मानों को प्राप्त करने के लिए है। यह क्लास प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) और [EffectFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/effectformat/) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/) क्लास की `getBackground` मेथड का उपयोग करके, आप स्लाइड की प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

निम्न PHP उदाहरण दिखाता है कि स्लाइड की प्रभावी पृष्ठभूमि मान कैसे प्राप्त किया जाए:

```php
// Presentation क्लास की एक इंस्टेंस बनाएं।
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // मास्टर, लेआउट और थीम को ध्यान में रखते हुए प्रभावी पृष्ठभूमि प्राप्त करें।
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कस्टम पृष्ठभूमि रीसेट कर सकता हूँ और थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?**

हाँ। स्लाइड की कस्टम फिल हटाएँ, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/php-java/slide-layout/)/[master](/slides/hi/php-java/slide-master/) स्लाइड से विरासत में मिल जाएगी (अर्थात् [theme background](/slides/hi/php-java/presentation-theme/))।

**यदि मैं बाद में प्रस्तुति के थीम को बदलूँ तो पृष्ठभूमि में क्या परिवर्तन होगा?**

यदि किसी स्लाइड में अपनी स्वयं की फिल है, तो वह बिना बदले रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/php-java/slide-layout/)/[master](/slides/hi/php-java/slide-master/) से विरासत में मिली है, तो वह नई थीम से मेल खाने के लिए अपडेट हो जाएगी।