---
title: PHP में प्रस्तुति थीम का प्रबंधन
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
- बाहरी थीम
- THMX
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में मुख्य प्रस्तुति थीम, PowerPoint फ़ाइलों को लगातार ब्रांडिंग के साथ बनाने, अनुकूलित करने और परिवर्तित करने के लिए।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, फाइल्स, लाइनों और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑अवगत ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करते हैं, इसलिए थीम बदलने पर कई ऑब्जेक्ट्स एक साथ अपडेट हो सकते हैं।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) के माध्यम से उपलब्ध है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड अपनी विरासत प्राप्त थीम को [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकता है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत तथा ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) ऑब्जेक्ट अपने रंग योजना, फ़ॉन्ट योजना, और फ़ॉर्मेट योजना को क्रमशः [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), और [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन कलेक्शन्स का निरीक्षण करना विशेष रूप से उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, फ़िल, लाइन और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल कई मास्टर का उपयोग करती है, तो यह न मानें कि हर स्लाइड की वही प्रभावी थीम है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हों तो बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑अवगत फ़िल, लाइनों, और टेक्स्ट को [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग संदर्भित कर सकता है। जब आप [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित कर रहे हैं, नई मान के अनुसार हल हो जाते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करती है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, फिर से खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

चूँकि आयत अभी भी `Accent4` से जुड़ी है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकृति पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में बदलाव उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पालेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे विविधताएँ उत्पन्न करने के लिए रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे विविधताएँ।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर चमक परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये विविधताएँ थीम रंग पर आधारित रहती हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नई `Accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मानचित्रित करें**

[SchemesColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मानचित्रण स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये एक ही थीम स्लॉट के वैकल्पिक नाम हैं; ये किसी रूपांतरण द्वारा गतिशील रूप से बदलते नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षकों के लिए मुख्य फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) और [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) मेथड्स इन सेट्स को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)
* `+mn‑cs` - बॉडी फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Minor Complex Script Font)
* `+mj‑cs` - हेडिंग फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Major Complex Script Font)

निम्न उदाहरण एक शीर्षक बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग मुख्य फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। उस फ़ॉन्ट का स्पष्ट नाम होने पर वह थीम फ़ॉन्ट योजना बदलने पर स्वतः स्विच नहीं करेगा।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों जैसे साइरिलिक, अरबी, जापानी, जॉर्जियन, और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/php-java/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/php-java/powerpoint-fonts/)।
{{% /alert %}}

### **थीम फ़ॉन्ट संदर्भ हल करें**

टेक्स्ट निरीक्षण करते समय, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) एक थीम संदर्भ जैसे `+mn‑lt` लौटा सकता है, न कि फ़ॉन्ट परिवार नाम। उचित प्रभावी थीम डेटा के साथ [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) को कॉल करके उस संदर्भ को हल करें। `+mj` और `+mn` उपसर्ग मुख्य और गौण फ़ॉन्ट सेट चुनते हैं; `-lt`, `-ea`, और `-cs` प्रत्यय क्रमशः लैटिन, ईस्ट एशियन और कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट चुनते हैं।

उस ऑब्जेक्ट के लिए `[Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)` के माध्यम से प्रभावी थीम प्राप्त करें जिस पर टेक्स्ट स्थित है। सामान्य स्लाइड टेक्स्ट के लिए इस मेथड को स्लाइड पर कॉल करें ताकि संदर्भ में विरासत थीम और स्थानीय ओवरराइड शामिल हों। लेआउट या मास्टर खुद का प्रभावी थीम उपयोग करता है। यह न मानें कि पहले मास्टर की थीम हर स्लाइड पर लागू होती है।

निम्न उदाहरण एक टेक्स्ट भाग बनाता है जो स्पष्ट रूप से गौण लैटिन फ़ॉन्ट को संदर्भित करता है। यह [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) के माध्यम से स्लाइड फ़ॉन्ट योजना को प्रारंभ करता है और मुख्य व गौण लैटिन परिवारों को क्रमशः `Arial` और `Calibri` सेट करता है, जिससे बिना इनपुट फ़ाइल के परिणाम पुनरुत्पादित हो सके।

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

आउटपुट `+mn‑lt -> Calibri` के बाद `Verdana -> Verdana` दिखाता है। संग्रहीत संदर्भ अपरिवर्तित रहता है, जबकि स्पष्ट फ़ॉन्ट नाम जैसा है वैसा ही लौटाया जाता है। यदि भाग `+mj‑lt` उपयोग करता, तो यह इस थीम में `Arial` में हल हो जाता।

थीम संदर्भ को हल करना केवल थीम द्वारा निर्दिष्ट फ़ॉन्ट परिवार देता है। यह फ़ॉन्ट उपलब्धता या रेंडरिंग के दौरान प्रतिस्थापन या ग्लिफ़ फ़ॉलबैक को नहीं जांचता। संबंधित चरणों के लिए देखें [Font Selection Sequence](/slides/hi/php-java/font-selection-sequence/) और [Font Substitution](/slides/hi/php-java/font-substitution/)।

## **थीम कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तो उपयोग करें [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)। चयनित मास्टर को [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) कलेक्शन से प्राप्त करें, जो [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) द्वारा प्रतिनिधित्व किया जाता है, और थीम फ़ाइल पथ को मेथड को पास करें।

यह मेथड निम्न कार्य करता है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।
1. नए मास्टर पर बाहरी थीम लागू करता है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नया मास्टर सौंपता है।
1. नया बनाया गया [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) लौटाता है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति सहेजता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;

    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

एक अमान्य, दूषित, या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथों को मान्य करें, फ़ाइल‑सिस्टम त्रुटियों को संभालें, और केवल तभी प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनः असाइन किया जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों से जुड़ी स्लाइड्स अपनी मौजूदा मास्टर और थीम रखती हैं। थीम‑अवगत रंग, फ़ॉन्ट, फ़िल, लाइन, पृष्ठभूमि, और प्रभाव बाहरी थीम के खिलाफ हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल आदि संभवतः अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नई मास्टर से विरासत मानों पर प्राथमिकता ले सकते हैं।

थीम उन फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम वातावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [custom font sources](/slides/hi/php-java/custom-font/) के माध्यम से उपलब्ध कराएँ, या [font substitution](/slides/hi/php-java/font-substitution/) सेट करें।

यह सीधा मास्टर‑स्तर कार्यप्रवाह है: मेथड `.thmx` फ़ाइल पथ स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब प्रासंगिक मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड से [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) और [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) द्वारा प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भ संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स के मास्टर खोजता है और प्रत्येक समूह पर विभिन्न बाहरी थीम लागू करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;

            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

पहला कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `$firstGroupMaster` पर निर्भर थीं, और दूसरा कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `$secondGroupMaster` पर निर्भर थीं। अन्य किसी भी मास्टर की स्लाइड्स री‑स्टाइल नहीं होतीं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम संरक्षित रखें**

यदि आप एक स्लाइड को अन्य प्रस्तुति में ले जाना चाहते हैं और उसके मूल डिज़ाइन को संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर क्लोन किए गए मास्टर के साथ स्लाइड को [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) से क्लोन करें। इससे मास्टर, उसके लेआउट, और संबद्ध थीम साथ में चली जाती है।

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

यह तब पसंदीदा कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में समान रूप से दिखना चाहिए। केवल सामग्री को असंबंधित लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर रखना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), और [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में प्राप्त थीम को बदले बिना उस स्लाइड द्वारा उपयोग की गई थीम बदल देता है। स्थानीय ओवरराइड हटाकर विरासत मानों पर लौटने के लिए कॉल करें [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। समान प्रारंभिक मेथड्स का उपयोग [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/) के माध्यम से किया जा सकता है:

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

जब कई लेआउट और स्लाइड एक ही बेस डिज़ाइन साझा करनी चाहिए तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड्स बाद की वैश्विक थीम बदलावों को पूर्वानुमानित करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि फ़िल [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) में संग्रहीत होते हैं। PowerPoint UI में थीम फ़िल को थीम रंगों और अन्य शैली संदर्भों के साथ मिलाकर अधिक पृष्ठभूमि विकल्प दिखा सकता है, जबकि संग्रह में शारीरिक रूप से संग्रहीत फ़िल परिभाषाएँ कम हो सकती हैं।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले संग्रहीत कलेक्शन और वर्तमान [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/) का निरीक्षण करें। `0` का शैली सूचकांक मतलब कोई थीम्ड फ़िल नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह PHP कलेक्शन के शून्य‑आधारित इंडेक्सिंग से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि हर प्रस्तुति में पृष्ठभूमि फ़िल शैलियों की संख्या समान है।

निम्न उदाहरण उपलब्ध पृष्ठभूमि फ़िल गिनती रिपोर्ट करता है, पहला मास्टर को थीम्ड पृष्ठभूमि संदर्भ सौंपता है, और प्रस्तुति सहेजता है:

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

दिखाई देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड‑स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। अंतिम पृष्ठभूमि जानने के लिए उपयोग करें [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)।

{{% alert color="warning" title="Warning" %}}
शैली सूचकांक को शून्य‑आधारित कलेक्शन सूचकांक न मानें। किसी एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में समान रूप मानना टालें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/php-java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

थीम फ़ॉर्मेट योजना अलग‑अलग फ़िल, लाइन, और इफ़ेक्ट शैली कलेक्शनों को उजागर करती है, जो क्रमशः [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), और [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) द्वारा एक्सेस किए जाते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग के अनुरूप होती हैं, पर कोड को प्रत्येक कलेक्शन का निरीक्षण करना चाहिए, न कि स्थिर संख्या मानना चाहिए।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

PHP में इन कलेक्शनों को एक्सेस करते समय इंडेक्स शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकृति का शैली‑संदर्भ इंडेक्स अलग अवधारणा है, जिसे [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को बदलने से उन आकृतियों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करती हैं; सीधे फ़ॉर्मेट की गई आकृतियों पर कोई असर नहीं हो सकता।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी छाया सक्रिय करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स के लिए, पहली थीम लाइन शैली लाल हो जाती है, तीसरी थीम फ़िल शैली ठोस फॉरेस्ट ग्रिन, और तीसरी इफ़ेक्ट शैली में 10 पॉइंट दूरी वाली बाहरी छाया जुड़ जाती है। वास्तविक दृश्य परिणाम इस बात पर निर्भर करता है कि कौन‑सी शैली स्लॉट्स प्रत्येक आकृति संदर्भित करती है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **एक आकृति के लिए थीम फ़िल और लाइन शैली चुनें**

एक आकृति [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) और [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex) के माध्यम से अपनी फ़िल और आउटलाइन को स्वतंत्र रूप से चुन सकती है। दोनों मेथड्स में, इंडेक्स `1` संबंधित थीम कलेक्शन की पहली प्रविष्टि (`get_Item(0)`) चुनता है, और इंडेक्स `2` दूसरी (`get_Item(1)`) चुनता है।

निम्न उदाहरण दो फ़िल शैलियों (सोना और आकाश‑नीला) और दो लाइन शैलियों (6 pt पर गहरा नीला और 12 pt पर गहरा लाल) को नई प्रस्तुति की डिफ़ॉल्ट थीम में सेट करता है। इसे तीन चरणों पर स्लाइड सहेजता है ताकि आप PowerPoint में परिणामों की तुलना कर सकें।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| प्रारंभिक शैलियाँ | दाएँ आउटलाइन बदलें | पहली थीम फ़िल संपादित करें |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

विभिन्न लाइन शैली चुनने से केवल दाएँ आयत की आउटलाइन बदलती है। पहली थीम फ़िल को संपादित करने से सभी उस फ़िल का उपयोग करने वाली आकृतियों पर प्रभाव पड़ता है। यहाँ केवल बायाँ आयत हरा हो जाता है।

मौजूदा आकृति पर, स्थानीय फ़िल रंग, लाइन रंग, या लाइन चौड़ाई थीम शैली के उस भाग को ओवरराइड कर सकती है। यदि शैली इंडेक्स बदलने से कोई दृश्य प्रभाव नहीं दिखता, तो आकृति की [direct formatting](/slides/hi/php-java/shape-formatting/) जाँचें।

## **जाँचें कि प्रभावी सॉलिड फ़िल थीम रंग उपयोग करता है या नहीं**

फ़िल ऑब्जेक्ट पर सीधे संग्रहीत या पैराग्राफ, लेआउट, मास्टर, थीम शैली या अन्य फ़ॉर्मेट स्तर से विरासत में प्राप्त हो सकता है। इसे हल करने के लिए कॉल करें [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) ताकि वह पदानुक्रम को अपरिवर्तनीय प्रभावी फ़िल डेटा में बदल दे। पहले `getFillType` परिणाम देखें। केवल जब यह `FillType::Solid` हो, तब ही सॉलिड‑फ़िल गुण पढ़ें।

सॉलिड फ़िल के लिए, `getSolidFillColor` विरासत, थीम लुक‑अप, और रंग रूपांतरण लागू होने के बाद अंतिम आरजीबी मान देता है। `getSolidFillSchemeColor` संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) स्लॉट (जैसे `Text1` या `Accent6`) लौटाता है। `SchemeColor::NotDefined` का मान दर्शाता है कि प्रभावी सॉलिड फ़िल किसी स्कीम रंग पर आधारित नहीं है। यदि कार्यप्रवाह में फ़िल केवल थीम रंग या सीधे RGB रंग होते हैं, तो यह मान सीधे RGB फ़िल को दर्शाता है।

केवल स्थानीय [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) मान का उपयोग करके फ़िल वर्गीकरण न करें। उदाहरण के लिये, किसी टेक्स्ट भाग में स्थानीय रूप से कोई स्कीम रंग नहीं हो सकता, इसलिए उसका स्थानीय मान `NotDefined` हो सकता है, जबकि प्रभावी फ़िल थीम रंग विरासत में लेकर `Text1` या `Accent6` में हल हो सकता है। इसके विपरीत, `getSolidFillSchemeColor` बताता है कि कौन‑सा तार्किक थीम स्लॉट प्रभावी रंग उत्पन्न कर रहा है, पर यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, दोनों आकृति फ़िल और टेक्स्ट‑भाग फ़िल ऑडिट करता है, प्रत्येक अंतिम आरजीबी मान और संबंधित स्कीम रंग प्रिंट करता है, और उन सॉलिड फ़िल को चिन्हित करता है जो थीम रंग परिवर्तन को ट्रैक नहीं करेंगे:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`NotDefined` शाखा उन सॉलिड फ़िल की ऑडिट सूची देती है जो थीम रंग स्लॉट बदलने पर प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नई ब्रांड पैलेट पर ले जाना हो तो इन ऑब्जेक्ट्स की समीक्षा करें। रिपोर्ट किया गया आरजीबी मान अभी भी वर्तमान दृश्य दिखाता है, जबकि स्कीम मान यह बताता है कि वह दृश्य थीम से जुड़ा है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम ओवरराइड, या कोई विरासत फ़ॉर्मेट बदलने के बाद फिर से `getEffective` कॉल करें और नई प्रभावी फ़िल डेटा पढ़ें, फिर तुलना या रिपोर्टिंग करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि स्लाइड या आकृति वास्तव में विरासत और स्थानीय ओवरराइड के बाद क्या उपयोग करती है। स्लाइड के लिए कॉल करें [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). पृष्ठभूमि के लिए उपयोग करें [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), और फ़िल के लिए [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकृति फ़िल पढ़ता है:

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

रेंडरिंग निदान, वैधता, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकृति ओवरराइड को मिस कर सकते हैं जो अंतिम रूप को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर हैं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम बरकरार रखती हैं।

**क्या मैं किसी एकल स्लाइड पर थीम लागू कर सकता हूँ बिना मास्टर बदले?**

हाँ। स्लाइड की [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) का उपयोग करें और उसकी ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में जारी रखती हैं।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को स्थानांतरित कर उसकी स्रोत रूपरेखा बरकरार रखना हो, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उसी मास्टर के साथ स्लाइड को [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) और [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) से क्लोन करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए उपयोग करें [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) और [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।