---
title: PHP में प्रस्तुति स्लाइड मास्टर प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 70
url: /hi/php-java/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- कई मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- क्लोन मास्टर स्लाइड
- कॉपी मास्टर स्लाइड
- डुप्लिकेट मास्टर स्लाइड
- अनुपयोगी मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में स्लाइड मास्टर प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुंच, संपादन, क्लोन, तुलना और हटाना।"
---
## **समीक्षा**

एक **slide master** समूह के स्लाइड्स के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फ़ूटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना यह सुनिश्चित करने का सामान्य तरीका है कि प्रस्तुति सुसंगत रहे बिना प्रत्येक स्लाइड पर एक ही फ़ॉर्मेटिंग दोहराए।

Aspose.Slides for PHP via Java भी वही मॉडल समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड्स हो सकती हैं। सामान्य स्लाइड्स आम तौर पर सीधे मास्टर स्लाइड को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड किसी मास्टर स्लाइड से संबंधित होती है।

क्रमानुक्रम इस प्रकार है:

1. **Slide master** – साझा डिज़ाइन और थीम को परिभाषित करता है।  
1. **Layout slide** – प्लेसहोल्डर और लेआउट-स्तरीय फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
1. **Normal slide** – वास्तविक प्रस्तुति सामग्री रखता है और एक लेआउट स्लाइड का उपयोग करता है।

![मास्टर स्लाइड, लेआउट स्लाइड और सामान्य स्लाइड का क्रमानुक्रम](slide-master_2.jpg)

Aspose.Slides में, एक slide master को [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) क्लास द्वारा दर्शाया जाता है। प्रस्तुति में सभी मास्टर स्लाइड्स को [Presentation.getMasters](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getMasters) मेथड के माध्यम से प्राप्त किया जा सकता है, जो एक [MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) ऑब्जेक्ट लौटाता है।

{{% alert color="info" title="विरासत" %}}

जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि को परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट की पृष्ठभूमि को अपनाती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें [Apply or Change Slide Layouts](/slides/hi/php-java/slide-layout/)।

{{% /alert %}}

## **Slide Masters तक पहुंच**

PowerPoint में, आप **View** > **Slide Master** से Slide Master दृश्य खोल सकते हैं।

![PowerPoint View टैब पर Slide Master कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुंचने के लिए `getMasters` मेथड का उपयोग करें:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

आप सामान्य स्लाइड के लेआउट के माध्यम से उपयोग किए गए मास्टर स्लाइड को भी प्राप्त कर सकते हैं:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **एक Slide Master में क्या होता है**

एक मास्टर स्लाइड स्लाइड जैसी वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/) को विस्तारित करता है, इसलिए यह सामान्य और लेआउट स्लाइड्स के समान कई स्लाइड प्रॉपर्टीज़ को उजागर करता है। मास्टर-विशिष्ट सदस्यों की सूची [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) API पेज पर दी गई है।

सामान्यतः उपयोग किए जाने वाले मास्टर स्लाइड सदस्य शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `getBackground` | मास्टर-स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `getShapes` | मास्टर पर रखे गये आकारों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा पाठ। |
| `getLayoutSlides` | उन लेआउट स्लाइड्स को संग्रहीत करता है जो इस मास्टर से संबंधित हैं। |
| `getThemeManager` | मास्टर थीम API तक पहुंच प्रदान करता है। |
| `getHeaderFooterManager` | मास्टर और उसकी चाइल्ड लेआउट्स के लिए हेडर, फुटर, तिथि और स्लाइड नंबर नियंत्रित करता है। |
| `getDependingSlides` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट्स के माध्यम से मास्टर पर निर्भर करती हैं। |

## **Slide Master में छवि जोड़ना**

जब आप किसी मास्टर स्लाइड में छवि जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देती है जो उस मास्टर से लेआउट उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराई जाने वाली दृश्य तत्वों के लिए उपयोगी है।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लोगो जोड़ता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/slides/hi/php-java/picture-frame/)।

## **Placeholders के साथ काम करना**

Placeholders सामान्यतः लेआउट स्लाइड्स पर परिभाषित होते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करता है जिसे लेआउट विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से placeholders उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, placeholder कमांड्स Slide Master दृश्य में उपलब्ध होते हैं।

![PowerPoint Slide Master दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए placeholders जोड़ने के लिए, उस लेआउट स्लाइड के साथ काम करें जो मास्टर से संबंधित है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

आप मास्टर स्लाइड पर पहले से मौजूद placeholder आकारों को भी फ़ॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक placeholder को खोजता है और उसे रैखिक ग्रेडिएंट फ़िल लागू करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![सामान्य स्लाइड्स द्वारा विरासत में मिला फ़ॉर्मेट किया गया शीर्षक placeholder](slide-master_8.png)

अधिक placeholder और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/php-java/manage-placeholder/) और [Text Formatting](/slides/hi/php-java/text-formatting/)।

## **Slide Master पृष्ठभूमि बदलना**

मास्टर पृष्ठभूमि लेआउट्स और उन स्लाइड्स द्वारा विरासत में ली जाती है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/php-java/presentation-background/) और [Presentation Theme](/slides/hi/php-java/presentation-theme/)।

## **एक Slide Master को दूसरी प्रस्तुति में क्लोन करना**

[MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से `addClone` का उपयोग करके किसी मास्टर स्लाइड को किसी अन्य प्रस्तुति में कॉपी किया जा सकता है। कॉपी किया गया मास्टर फिर लक्ष्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

यदि आपको सामान्य स्लाइड्स को उनके मास्टर के साथ क्लोन करना है, तो देखें [Clone Slides](/slides/hi/php-java/clone-slides/)।

## **एकाधिक Slide Masters जोड़ना**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न अनुभागों को अलग‑अलग ब्रांडिंग, पृष्ठ संरचना या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को सम्मिलित और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्न उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के तहत एक लेआउट बनाता है, और उस लेआउट पर आधारित एक नई स्लाइड जोड़ता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Slide Masters की तुलना करना**

मास्टर स्लाइड्स की तुलना `equals` मेथड से की जा सकती है, जो [BaseSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/) से विरासत में मिली है। तुलना संरचना और स्थिर सामग्री जैसे आकार, टेक्स्ट, फ़ॉर्मेटिंग, एनीमेशन और अन्य स्लाइड सेटिंग्स की जाँच करती है। यह विशिष्ट पहचानकर्ता जैसे slide IDs या गतिशील placeholder मान जैसे वर्तमान तिथि की तुलना नहीं करती।

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/php-java/compare-slides/)।

## **डिफ़ॉल्ट दृश्य के रूप में Slide Master दृश्य सेट करना**

PowerPoint के पहले खुले दृश्य को नियंत्रित करने के लिए [ViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/) पर `setLastView` मेथड का उपयोग करें। निम्न उदाहरण प्रस्तुति को Slide Master दृश्य में खोलता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

अधिक दृश्य सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/php-java/save-presentation/)।

## **अव्यवस्थित मास्टर स्लाइड्स को हटाना**

कभी‑कभी प्रस्तुतियों में ऐसे मास्टर स्लाइड्स होते हैं जो अब किसी सामान्य स्लाइड द्वारा उपयोग नहीं होते। उपयोग नहीं किए गए मास्टर को हटाने से फ़ाइल आकार घट सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

`removeUnused` को [MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से उपयोग करके `getMasters` संग्रह से अव्यवस्थित मास्टर को हटाया जा सकता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

आप [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास से low-code `removeUnusedMasterSlides` मेथड भी उपयोग कर सकते हैं:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Slide master और layout slide में क्या अंतर है?**

Slide master थीम, पृष्ठभूमि, सामान्य आकार और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। Layout slide एक मास्टर स्लाइड से संबंधित होती है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है। Normal slide एक layout slide का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से विरासत में लेती है।

**क्या एक प्रस्तुति में कई slide masters हो सकते हैं?**

हां। एक प्रस्तुति में कई slide masters हो सकते हैं। जब विभिन्न अनुभागों को अलग‑अलग दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होती है, तो कई मास्टर का उपयोग करें।

**क्या मुझे placeholders को master slide पर या layout slide पर जोड़ना चाहिए?**

अधिकांश मामलों में placeholders को layout slides पर जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग को master slide पर रखें, फिर सामग्री placeholders को उन लेआउट्स पर रखें जो सामान्य स्लाइड्स उपयोग करेंगे।

**क्या मैं किसी अभी‑उपयोग में रहे master slide को हटा सकता हूँ?**

नहीं। जिस master slide के पास निर्भर स्लाइड्स हैं, उसे सीधे हटाना सुरक्षित नहीं है। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में स्थानांतरित करें, या केवल अनउपयोगी मास्टर को हटाने की सफ़ाई विधि का उपयोग करें।