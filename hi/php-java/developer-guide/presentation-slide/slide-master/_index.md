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
- एकाधिक मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन करें
- मास्टर स्लाइड कॉपी करें
- डुप्लिकेट मास्टर स्लाइड
- अप्रयोगी मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में स्लाइड मास्टर प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुँच, संपादन, क्लोन, तुलना और हटाना।"
---
## **अवलोकन**

**स्लाइड मास्टर** एक समूह स्लाइड्स के लिए साझा डिजाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैलियाँ, थीम सेटिंग्स और फुटर सेटिंग्स शामिल हो सकते हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना प्रस्तुति को समान रखने का सामान्य तरीका है, जिससे हर स्लाइड पर एक ही फॉर्मेटिंग दोहराने की आवश्यकता नहीं पड़ती।

Aspose.Slides for PHP via Java भी यही मॉडल समर्थन करता है। एक प्रेजेंटेशन में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड में कई लेआउट स्लाइड्स हो सकती हैं। सामान्य स्लाइड्स आमतौर पर सीधे मास्टर स्लाइड को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड एक मास्टर स्लाइड से सम्बंधित होती है।

1. **स्लाइड मास्टर** - साझा डिजाइन और थीम को परिभाषित करता है।  
1. **लेआउट स्लाइड** - प्लेसहोल्डर और लेआउट‑स्तरीय फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
1. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।

![मास्टर स्लाइड्स, लेआउट स्लाइड्स, और सामान्य स्लाइड्स की पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, एक स्लाइड मास्टर को [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) क्लास द्वारा दर्शाया जाता है। एक प्रस्तुति में सभी मास्टर स्लाइड्स को [Presentation.getMasters](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getMasters) मेथड के माध्यम से प्राप्त किया जा सकता है, जो एक [MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) ऑब्जेक्ट लौटाता है।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी एक से अधिक स्तर पर परिभाषित होती है, तो अधिक विशिष्ट स्तर की मान्यता होती है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि को परिभाषित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए, देखें [स्लाइड लेआउट लागू करें या बदलें](/slides/hi/php-java/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुँच**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

![PowerPoint व्यू टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुँचने के लिए `getMasters` मेथड का उपयोग करें:

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

आप लेआउट के माध्यम से किसी सामान्य स्लाइड द्वारा उपयोग किए गए मास्टर स्लाइड को भी प्राप्त कर सकते हैं:

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

## **स्लाइड मास्टर में क्या होता है**

मास्टर स्लाइड एक स्लाइड समान वस्तु है। यह [BaseSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/) को विस्तारित करता है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग किए जाने वाले कई समान स्लाइड गुणों को प्रदर्शित करता है। मास्टर‑विशिष्ट सदस्य [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) API पृष्ठ पर सूचीबद्ध हैं।

सामान्य रूप से उपयोग किए जाने वाले मास्टर स्लाइड सदस्य शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `getBackground` | मास्टर‑स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `getShapes` | मास्टर पर रखे गए आकारों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `getLayoutSlides` | मास्टर से संबंधित लेआउट स्लाइड्स को संग्रहीत करता है। |
| `getThemeManager` | मास्टर थीम API तक पहुंच प्रदान करता है। |
| `getHeaderFooterManager` | मास्टर और उसके चाइल्ड लेआउट्स के लिए हैडर, फुटर, तिथियां, और स्लाइड नंबर नियंत्रित करता है। |
| `getDependingSlides` | उन सामान्य स्लाइड्स को लौटाता है जो लेआउट के माध्यम से मास्टर पर निर्भर होती हैं। |

## **स्लाइड मास्टर में छवि जोड़ें**

जब आप एक मास्टर स्लाइड में छवि जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देती है जो उस मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले दृश्य तत्वों के लिए उपयोगी है।

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

अधिक जानकारी के लिए देखें [चित्र फ्रेम](/slides/hi/php-java/picture-frame/)।

## **मास्टर ग्राफ़िक्स की दृश्यता नियंत्रित करें**

इनहेरिटेड मास्टर ग्राफ़िक्स, जैसे लोगो या सजावटी आकारों, को मास्टर से हटाए बिना छुपाने के लिए [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#setShowMasterShapes) का उपयोग करें। उन स्लाइड्स पर जहाँ ये ग्राफ़िक्स नहीं चाहिए, [Slide::setShowMasterShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#setShowMasterShapes) में `false` पास करें और उन स्लाइड्स पर जहाँ दिखाने हैं, `true` रखें।

निम्न स्व‑समावेशी उदाहरण एक मास्टर पर नीला सजावटी बैंड बनाता है और दो स्लाइड्स जो एक ही ब्लैंक लेआउट का उपयोग करती हैं। बैंड पहली स्लाइड पर दिखता है और दूसरी पर छुपा रहता है। कोई इनपुट प्रेजेंटेशन या छवि आवश्यक नहीं है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

उदाहरण नई प्रेजेंटेशन के साथ प्रदान किए गए **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के अपने प्लेसहोल्डर को हटा देता है।

### **सेटिंग की सीमा चुनें**

एक सामान्य स्लाइड अपने मास्टर को [Slide::getLayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getLayoutSlide) और [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#getMasterSlide) के माध्यम से उपयोग करती है। व्यक्तिगत स्लाइड पर प्रॉपर्टी सेट करने से केवल उसी स्लाइड पर प्रभाव पड़ेगा। [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/#setShowMasterShapes) में `false` पास करने से उन स्लाइड्स के लिए मास्टर ग्राफ़िक्स छुप जाते हैं जो उस साझा लेआउट का उपयोग करती हैं, भले ही उनकी अपनी सेटिंग `true` हो। केवल एक स्लाइड पर ग्राफ़िक्स छुपाने के लिए, स्लाइड प्रॉपर्टी बदलें और साझा लेआउट को जैसा है वैसे ही रखें।

यह सेटिंग स्वयं मास्टर स्लाइड पर दृश्यता नियंत्रण के रूप में समर्थित नहीं है। एक मास्टर पर, [getShowMasterShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/#getShowMasterShapes) हमेशा `false` लौटाता है, और [setShowMasterShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/#setShowMasterShapes) में `true` पास करने से अपवाद उत्पन्न होता है। इसे सामान्य स्लाइड या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग करें**

| ऑपरेशन | प्रभाव |
| --- | --- |
| मास्टर ग्राफ़िक्स छुपाएँ | इनहेरिटेड मास्टर आकारों की दृश्यता को नियंत्रित करता है बिना उन्हें हटाए या स्लाइड के अपने आकारों को बदले। |
| स्लाइड पृष्ठभूमि भराव बदलें | पृष्ठभूमि का रंग, ग्रेडिएंट, या छवि बदलता है। मास्टर ग्राफ़िक्स अलग आकार होते हैं और वह पृष्ठभूमि पर दिखते रह सकते हैं। देखें [प्रेजेंटेशन बैकग्राउंड](/slides/hi/php-java/presentation-background/). |
| मास्टर से एक आकार हटाएँ | साझा स्रोत आकार को हटा देता है, जिससे वह किसी भी स्लाइड के लिए उपलब्ध नहीं रहता जो उस मास्टर को उपयोग करती है। |

## **प्लेसहोल्डर्स के साथ काम करें**

प्लेसहोल्डर आमतौर पर लेआउट स्लाइड्स पर परिभाषित होते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करती है जिसे लेआउट्स विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ रखे जाएँगे।

PowerPoint में, प्लेसहोल्डर कमांडस स्लाइड मास्टर दृश्य में उपलब्ध हैं।

![PowerPoint स्लाइड मास्टर दृश्य में इंसर्ट प्लेसहोल्डर कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर जोड़ने के लिए, उस लेआउट स्लाइड के साथ काम करें जो मास्टर से सम्बंधित है:

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

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकारों को भी फॉर्मेट कर सकते हैं। निम्न उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और रैखिक ग्रेडिएंट भराव लागू करता है:

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

![सामान्य स्लाइड्स द्वारा विरासत में मिला स्वरूपित शीर्षक प्लेसहोल्डर](slide-master_8.png)

अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [प्लेसहोल्डर में प्रॉम्प्ट टेक्स्ट सेट करें](/slides/hi/php-java/manage-placeholder/) और [पाठ फ़ॉर्मेटिंग](/slides/hi/php-java/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

एक मास्टर पृष्ठभूमि लेआउट्स और स्लाइड्स द्वारा विरासत में मिलती है जो इसे ओवरराइड नहीं करतीं। निम्न उदाहरण पहले मास्टर स्लाइड के लिए ठोस पृष्ठभूमि रंग सेट करता है:

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

संबंधित विषयों के लिए देखें [प्रेजेंटेशन बैकग्राउंड](/slides/hi/php-java/presentation-background/) और [प्रेजेंटेशन थीम](/slides/hi/php-java/presentation-theme/)।

## **स्लाइड मास्टर को अन्य प्रेजेंटेशन में क्लोन करें**

[MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से `addClone` का उपयोग करके एक मास्टर स्लाइड को अन्य प्रेजेंटेशन में कॉपी करें। कॉपी किया गया मास्टर फिर गंतव्य प्रेजेंटेशन में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

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

यदि आपको उनके मास्टर के साथ सामान्य स्लाइड्स को भी क्लोन करने की आवश्यकता है, तो देखें [स्लाइड्स को क्लोन करें](/slides/hi/php-java/clone-slides/)।

## **एकाधिक स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह तब उपयोगी होता है जब विभिन्न सेक्शन को अलग-अलग ब्रांडिंग, पेज संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को सम्मिलित करने और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

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

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइड्स की तुलना [BaseSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/) से विरासत में मिली `equals` मेथड से की जा सकती है। तुलना संरचना और स्थिर सामग्री जैसे आकार, टेक्स्ट, फॉर्मेटिंग, एनीमेशन और अन्य स्लाइड सेटिंग्स की जाँच करती है। यह अद्वितीय पहचानकर्ताओं जैसे स्लाइड IDs या गतिशील प्लेसहोल्डर मान जैसे वर्तमान तिथि की तुलना नहीं करती।

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

अधिक जानकारी के लिए देखें [प्रेजेंटेशन स्लाइड्स की तुलना करें](/slides/hi/php-java/compare-slides/)।

## **डिफ़ॉल्ट दृश्य के रूप में स्लाइड मास्टर व्यू सेट करें**

[ViewProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/viewproperties/) पर `setLastView` मेथड का उपयोग करके उस व्यू को नियंत्रित करें जो PowerPoint सबसे पहले खोलता है। निम्न उदाहरण प्रस्तुति को स्लाइड मास्टर व्यू में खोलता है:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

अधिक व्यू सेटिंग्स के लिए देखें [प्रेजेंटेशन सहेजें](/slides/hi/php-java/save-presentation/)।

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कभी-कभी प्रेजेंटेशन में ऐसे मास्टर स्लाइड्स होते हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं होते। अप्रयुक्त मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्प्लेट रखरखाव सरल हो जाता है।

[MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से `removeUnused` का उपयोग करके `getMasters` कलेक्शन से अप्रयुक्त मास्टर को हटाएँ:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

आप [Compress](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/) क्लास से लो‑कोड `removeUnusedMasterSlides` मेथड का भी उपयोग कर सकते हैं:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर साझा डिजाइन सेटिंग्स जैसे थीम, पृष्ठभूमि, सामान्य आकार, और टेक्स्ट शैलियों को परिभाषित करता है। लेआउट स्लाइड एक मास्टर स्लाइड से सम्बंधित होती है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है। सामान्य स्लाइड लेआउट स्लाइड का उपयोग करती है, इसलिए वह लेआउट और मास्टर दोनों से विरासत में मिलती है।

**क्या एक प्रेजेंटेशन में कई स्लाइड मास्टर हो सकते हैं?**

हाँ। एक प्रेजेंटेशन में कई स्लाइड मास्टर हो सकते हैं। जब विभिन्न सेक्शन को अलग-अलग विज़ुअल सिस्टम या ब्रांडिंग की आवश्यकता होती है, तो कई मास्टर का उपयोग करें।

**क्या मुझे प्लेसहोल्डर मास्टर स्लाइड में जोड़ना चाहिए या लेआउट स्लाइड में?**

अधिकांश मामलों में, प्लेसहोल्डर लेआउट स्लाइड पर जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मेटिंग मास्टर स्लाइड पर रखें, और सामग्री प्लेसहोल्डर उन लेआउट्स पर रखें जो सामान्य स्लाइड्स उपयोग करेंगे।

**क्या मैं एक उपयोग में चल रही मास्टर स्लाइड को हटा सकता हूँ?**

नहीं। एक ऐसी मास्टर स्लाइड जिसमें निर्भर स्लाइड्स हैं, उसे सीधे सुरक्षित रूप से हटाया नहीं जा सकता। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में स्थानांतरित करें, या एक अनउपयोगी‑मास्टर सफ़ाई विधि का उपयोग करें जो केवल उन मास्टर को हटाए जो उपयोग में नहीं हैं।