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
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP में Java के माध्यम से मुख्य प्रस्तुति थीम बनाकर, अनुकूलित करके और लगातार ब्रांडिंग के साथ PowerPoint फ़ाइलों को परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भराव, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑समझदार ऑब्जेक्ट्स इन साझा परिभाषाओं का संदर्भ लेते हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) के माध्यम से उपलब्ध है। एक प्रस्तुति में निम्न स्तरों पर थीम ओवरराइड भी हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterthememanager/) के माध्यम से ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिले थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकता है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से हल की जाती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्य‑प्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम की कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, तथा विरासत और ओवरराइड हल होने के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) ऑब्जेक्ट थीम की रंग योजना, फ़ॉन्ट योजना और फ़ॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन्हें बदलने से पहले इन संग्रहों की जाँच करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्न उदाहरण मुख्य थीम गुणों को पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर का उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर को निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्य‑प्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑समझदार भराव, रेखा और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration से लॉजिकल रंग का संदर्भ ले सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट जो अभी भी उस थीम रंग का संदर्भ ले रहे हैं, नए मान के विरुद्ध हल हो जाते हैं। जो ऑब्जेक्ट सीधे RGB रंग का उपयोग करते हैं, उन्हें थीम‑रंग अपडेट से बदल नहीं किया जाता।

निम्न संपूर्ण उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, फिर उसे पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

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

चूँकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखने वाला रंग लाल हो जाता है। यदि आप शेड रंग को आकार पर सीधे रंग से बदलते हैं, तो बाद में `Accent4` में किए गए बदलाव उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग पर रंग परिवर्तन लागू करके हल्के और गहरे विकल्प निकालता है। Aspose.Slides इन परिवर्तन को [ColorTransformOperation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे संस्करण।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम को सहेजता है:

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

ये संस्करण अभी भी थीम रंग पर आधारित रहते हैं। यदि `Accent4` बाद में बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2` और `Background2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2` और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये किसी रूप से गतिशील रूपांतरण वाले मान नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए लघु फ़ॉन्ट सेट शामिल होते हैं। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) विधियां इन सेटों को उजागर करती हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो लघु लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट लघु फ़ॉन्ट का। वह टेक्स्ट जिसके पास स्पष्ट फ़ॉन्ट नाम है, न कि थीम पहचानकर्ता, थीम फ़ॉन्ट योजना बदलने पर स्वचालित रूप से नहीं बदलेगा।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/php-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम की कॉपी या लागू करें**

दो सामान्य कार्य‑प्रवाह हैं, और वे अलग‑अलग समस्याओं को हल करते हैं।

### **स्लाइड को ले जा रहे समय स्रोत थीम को संरक्षित रखें**

यदि आप किसी स्लाइड को दूसरी प्रस्तुति में ले जाकर उसकी मूल डिज़ाइन को संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर क्लोन किए हुए मास्टर के साथ स्लाइड को [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) से क्लोन करें। इससे मास्टर, उसके लेआउट और संबंधित थीम एक साथ चले जाते हैं।

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

यह कार्य‑प्रवाह तब पसंदीदा है जब स्रोत स्लाइड को गंतव्य में समान दिखना आवश्यक हो। केवल अनसंबंधित गंतव्य मास्टर पर सामग्री क्लोन करने से थीम‑निर्देशित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर का ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) विधियां तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है बिना अन्य स्लाइडों की विरासत वाली थीम को बदले। स्थानीय ओवरराइड को हटाकर विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर का ओवरराइड उन स्लाइडों पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। वही प्रारंभिक विधियां [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग की जा सकती हैं:

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

जब कई लेआउट और स्लाइड एक ही मूल डिज़ाइन साझा करनी हों तो मास्टर या प्रस्तुति‑स्तर की थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली की आवश्यकता हो तो लेआउट ओवरराइड, और वास्तविक अपवादों के लिए केवल स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में ग्लोबल थीम परिवर्तन को अनुमानित करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भराव [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) में संग्रहीत होते हैं। PowerPoint अपने UI में अधिक पृष्ठभूमि विकल्प प्रस्तुत कर सकता है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint प्रस्तुति थीम के लिए पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) जांचें। `0` शैली सूचक का अर्थ कोई थीम‑भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह PHP संग्रह के सीधे इंडेक्सिंग से अलग है, जहाँ `get_Item(0)` पहले संग्रहीत आइटम को दर्शाता है। यह न मानें कि हर प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियां होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गणना रिपोर्ट करता है, प्रथम मास्टर को थीम‑पृष्ठभूमि संदर्भ सौंपता है, और प्रस्तुति को सहेजता है:

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

दृश्यमान परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) उपयोग करें।

{{% alert color="warning" title="Warning" %}}
शैली सूचक को शून्य‑आधारित संग्रह सूचक मानने से बचें। साथ ही किसी फ़ाइल से शैली संख्या को हार्ड‑कोड न करें और यह न मानें कि वह अन्य फ़ाइलों में समान रूप दिखेगी; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
प्रत्यक्ष पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/php-java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट योजना अलग‑अलग भराव, रेखा और प्रभाव शैली संग्रहों को [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) के माध्यम से उजागर करती है। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियां होती हैं जो दृश्य रूप में सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग के अनुरूप होती हैं, लेकिन कोड को प्रत्येक संग्रह को जांचना चाहिए बजाय निश्चित गणना मान लिये।

![एक ही आकार पर लागू सूक्ष्म, मध्यम और तीव्र थीम प्रभाव](presentation-design_10.png)

PHP में इन संग्रहों तक पहुँचते समय संग्रह सूचक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली और `get_Item(2)` तीसरा। आकार की शैली‑संदर्भ सूचक अलग अवधारणा है, जिसे [ShapeStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली में परिवर्तन उन आकारों को प्रभावित करता है जो उस थीम शैली का संदर्भ लेते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण आवश्यक शैली प्रविष्टियों के अस्तित्व की जांच करता है, पहला रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए, पहला थीम रेखा शैली लाल हो जाता है, तीसरा थीम भराव शैली ठोस फॉरेस्ट ग्रीन, और तीसरी प्रभाव शैली में 10 पॉइंट दूरी के साथ बाहरी छाया जुड़ जाती है। अंतिम दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौन‑से शैली स्लॉट संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, भराव और छाया सेटिंग्स बदलने के बाद थीम प्रभाव शैलियां](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट यह बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद कोई स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) कॉल करें। पृष्ठभूमि के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) और भराव के लिए [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि और पहले आकार भराव को पढ़ता है:

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

रेंडरिंग निदान, वैधता और तुलना के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) को निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम दृश्य को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं बिना मास्टर बदले एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइडें अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जा रहे हों और उसके स्रोत स्वरूप को संरक्षित रखना हो, तो स्रोत मास्टर को लक्ष्य में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से क्लोन करें और फिर उस क्लोन किए हुए मास्टर के साथ स्लाइड को [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) से क्लोन करें। इससे मास्टर, लेआउट और थीम एक साथ रहते हैं।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।