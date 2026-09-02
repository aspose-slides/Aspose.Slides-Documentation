---
title: PHP में प्रस्तुति थीम प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/php-java/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुति थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम स्टाइल
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP (Java के माध्यम से) में मुख्य प्रस्तुति थीम, ताकि स्थिर ब्रांडिंग के साथ PowerPoint फ़ाइलें बनाई, अनुकूलित और परिवर्तित की जा सकें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सजग ऑब्जेक्ट इन साझा परिभाषाओं को संदर्भित करते हैं, न कि प्रत्येक दृश्य गुण को स्थायी मान के रूप में संग्रहित करते हैं, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) के माध्यम से उपलब्ध कराया जाता है। प्रस्तुति में निम्न स्तर पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterthememanager/) के माध्यम से ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड अपनी विरासत मिले थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकती है। व्यवहार में, स्लाइड के लिये प्रभावी थीम इस वंशानुक्रम के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैली और प्रभाव](theme-constituents.png)

नीचे दिए गए अनुभाग सबसे सामान्य थीम वर्कफ़्लो दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि एवं प्रभाव शैलियों को अपडेट करना, और विरासत व ओवरराइड हल होने के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) ऑब्जेक्ट थीम की रंग योजना, फ़ॉन्ट योजना और फ़ॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन संग्रहों का निरीक्षण करना खासकर तब उपयोगी होता है जब कोई प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

यदि कोई फ़ाइल कई मास्टर इस्तेमाल करती है, तो यह न मानें कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़ा मास्टर निरीक्षण करें, और बाद में इस लेख में दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं।

## **थीम के रंग बदलें**

थीम‑सजग भराव, रेखाएँ और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग को संदर्भित कर सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नए मान के विरुद्ध हल हो जाते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग प्रिंट करता है:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे रूप बनाता है रंग रूपांतरण लागू करके। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के एवं गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंग से उत्पन्न हल्के एवं गहरे रूप।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ये रूपांतर थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2` और `Background2` का उपयोग करती है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2` और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये गतिशील रूपांतरण वाले मान नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षकों के लिये प्रमुख फ़ॉन्ट सेट और मुख्य पाठ के लिये गौण फ़ॉन्ट सेट शामिल होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) मेथड्स इन सेटों को उजागर करते हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ता को पाठ स्वरूपण में उपयोग किया जा सकता है:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (मेजर लैटिन फ़ॉन्ट)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (मेजर ईस्ट एशियन फ़ॉन्ट)

निम्न उदाहरण एक शीर्षक बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी पंक्ति जो माइनर लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर वह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

शीर्षक प्रमुख फ़ॉन्ट का अनुसरण करता है और बॉडी पाठ माइनर फ़ॉन्ट का। जो पाठ स्पष्ट फ़ॉन्ट नाम के साथ है, वह थीम फ़ॉन्ट योजना बदलने पर स्वतः स्विच नहीं करेगा।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणाली, जैसे सिरिलिक, अरबी, जापानी, जॉर्जियाई और थाना, के लिये फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिये देखें [Script‑Specific Theme Fonts](/slides/hi/php-java/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रस्तुति फ़ॉन्ट के बारे में अधिक जानकारी के लिये देखें [PowerPoint Fonts](/slides/hi/php-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम को कॉपी या लागू करें**

दो सामान्य वर्कफ़्लो हैं, और वे विभिन्न समस्याओं को हल करते हैं।

### **स्लाइड्स को ले जाते समय स्रोत थीम सुरक्षित रखें**

यदि आप स्लाइड को दूसरे प्रस्तुति में ले जाना चाहते हैं और उसका मूल डिजाइन बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर स्लाइड को क्लोन मास्टर के साथ [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) से क्लोन करें। यह मास्टर, उसके लेआउट और संबंधित थीम को एक साथ ले जाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

जब स्रोत स्लाइड को गंतव्य में समान रूप से दिखाना हो, यह पसंदीदा वर्कफ़्लो है। असंबंधित गंतव्य मास्टर पर केवल सामग्री क्लोन करने से थीम‑निर्देशित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर व लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

यह अन्य स्लाइड्स द्वारा विरासत में मिली थीम को बदले बिना केवल उस स्लाइड की थीम बदलता है। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिये [OverrideTheme.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। समान प्रारंभिक मेथड्स को [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

जब कई लेआउट और स्लाइड को समान बेस डिज़ाइन साझा करना हो तो प्रस्तुति‑स्तर या मास्टर थीम का उपयोग करें, एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल असली अपवादों के लिये स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद के वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) में संग्रहीत होती हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है, जबकि संग्रह में शारीरिक रूप से संग्रहीत भरावों की संख्या सीमित है।

![PowerPoint प्रस्तुति थीम के लिये पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) को जांचें। `0` का शैली सूचकांक कोई थीम‑भराव नहीं दर्शाता; धनात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह PHP संग्रह के सीधे इंडेक्सिंग से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम अर्थ रखता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को थीम्ड पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

दृश्य परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने हेतु [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
शैली सूचकांक को शून्य‑आधारित संग्रह सूचकांक न समझें। एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में वही रूप मानने से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि स्वरूपण और पृष्ठभूमि विरासत के लिये देखें [Presentation Background](/slides/hi/php-java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट योजना अलग‑अलग भराव, रेखा और प्रभाव शैली संग्रह को उजागर करती है, क्रमशः [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) के माध्यम से। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियां रखती हैं जो दृश्य रूप से सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए, न कि निश्चित संख्या मान लेना चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम और तीव्र थीम प्रभाव](presentation-design_10.png)

PHP में इन संग्रहों को पहुँचते समय, संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकार की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [ShapeStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapestyle/) के माध्यम से उजागर होती है। थीम शैली में संशोधन उन आकारों को प्रभावित करता है जो उस थीम शैली को संदर्भित करते हैं; सीधे स्वरूपित आकार अनुप्रयुक्त रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, प्रथम रेखा शैली बदलता है, तृतीय भराव शैली बदलता है, तृतीय प्रभाव शैली में बाहरी शैडो को 10 पॉइंट दूरी के साथ सक्षम करता है, और परिणाम सहेजता है:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिये, प्रथम थीम रेखा शैली लाल हो जाती है, तृतीय थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन हो जाती है, और तृतीय प्रभाव शैली में 10‑पॉइंट दूरी वाला बाहरी शैडो जोड़ दिया जाता है। अंतिम दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार कौन से शैली स्लॉट को संदर्भित करता है और क्या सीधे स्वरूपण थीम को ओवरराइड करता है।

![लाइन, भराव और शैडो सेटिंग्स बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्ची थीम ऑब्जेक्ट बताती है कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद कोई स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिये, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिये, [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) और भराव के लिये, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) का उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि और प्रथम आकार भराव पढ़ता है:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

रेंडरिंग निदान, सत्यापन और तुलना के लिये प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम उपस्थिति को बदलता है।

## **FAQ**

**क्या मैं मास्टर को बदले बिना एक ही स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidethememanager/) का उपयोग करके उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेते रहेंगी।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जाकर उसकी मूल उपस्थिति बरकरार रखनी हो, तो स्रोत मास्टर को गंतव्य में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से क्लोन करें और फिर स्लाइड को उसी क्लोन मास्टर के साथ [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) से क्लोन करें। इससे मास्टर, लेआउट और थीम एक साथ रखी जाती है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिये [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) और फॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) तथा [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल हुए मान लौटाते हैं।