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
- बाहरी थीम
- THMX
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
description: "Aspose.Slides for PHP via Java में मुख्य प्रस्तुति थीम्स बनाना, अनुकूलित करना और PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ परिवर्तित करना।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, फ़िल्स, लाइनों और प्रभावों का समन्वित सेट परिभाषित करती है। थीम-सेनसिटिव वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम बदलने से कई वस्तुएँ एक साथ अपडेट हो सकती हैं।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) के माध्यम से उपलब्ध कराया जाता है। एक प्रस्तुति में नीचे के स्तरों पर भी थीम ओवरराइड्स हो सकते हैं। एक मास्टर अपने प्रदत्त थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterthememanager/) के माध्यम से ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिले थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकता है। व्यावहारिक रूप से, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे आम थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, तथा विरासत और ओवरराइड्स के हल होने के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) वस्तु थीम की रंग योजना, फ़ॉन्ट योजना, और फ़ॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) के माध्यम से उजागर करती है। इन संग्रहों को बदलने से पहले निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और थीम में संग्रहीत पृष्ठभूमि, फ़िल, लाइन और प्रभाव शैलियों की गिनती रिपोर्ट करता है:

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

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह मानना ​​नहीँ चाहिए कि प्रत्येक स्लाइड का वही प्रभावी थीम है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं।

## **थीम रंग बदलें**

थीम‑सेनसिटिव फ़िल्स, लाइन्स, और टेक스트 [SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग का संदर्भ ले रही हैं, नई मान के खिलाफ हल होती हैं। सीधे RGB रंग वाले वस्तुओं को थीम‑रंग अपडेट से नहीं बदला जाता।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति सहेजता है, उसे पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

चूँकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर सीधे रंग के साथ स्कीम रंग को बदल देते हैं, तो बाद में `Accent4` में बदलाव उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करता है, जिससे रंग परिवर्तन लागू होते हैं। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के व गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

इन वैरिएंट्स का आधार थीम रंग ही रहता है। यदि `Accent4` बाद में बदलता है, तो परिवर्तित रंगों को नए `Accent4` मान से पुनः गणना किया जाएगा।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मानचित्रित करें**

[Sche​meColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मानचित्रण निश्चित है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये एक ही थीम स्लॉट के वैकल्पिक नाम हैं; इन्हें एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में हेडिंग के लिए मुख्य फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) विधियाँ इन सेटों को उजागर करती हैं।

PowerPoint‑अनुरुप थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग मुख्य फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। कोई स्पष्ट फ़ॉन्ट नाम वाला टेक्स्ट थीम फ़ॉन्ट योजना बदलने पर स्वचालित रूप से नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों, जैसे सायरिलिक, अरबी, जापानी, जॉर्जियन, और थाना के लिए भी फ़ॉन्ट मैपिंग्स रख सकते हैं। इन्हें निरीक्षण, जोड़ना, बदलना या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/php-java/script-specific-font-mappings/)।

{{% alert color="info" title="युक्ति" %}}

थीम फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint फ़ॉन्ट्स](/slides/hi/php-java/powerpoint-fonts/)।

{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **एक मास्टर की निर्भर स्लाइड्स पर बाहरी थीम लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स को पुनः शैलीबद्ध करना चाहते हों, तो [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) का उपयोग करें। चयनित मास्टर को [Presentation::getMasters](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) संग्रह से चुनें, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) द्वारा प्रतिनिधित्व किया गया है, और मेथड में थीम फ़ाइल पथ पास करें।

मेथड निम्न कार्य करता है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।
1. बाहरी थीम को नए मास्टर पर लागू करता है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर को असाइन करता है।
1. नव निर्मित [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) लौटाता है।

निम्न उदाहरण प्रथम मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति सहेजता है:

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

एक अमान्य, भ्रष्ट, या असमर्थित थीम [PptxReadException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxreadexception/) उत्पन्न कर सकता है। उपयोगकर्ताओं द्वारा प्रदान किए गए पथों को मान्य करें, फ़ाइल‑सिस्टम पहुँच त्रुटियों को संभालें, और थीम सफलतापूर्वक लागू होने के बाद ही प्रस्तुति सहेजें।

केवल चयनित मास्टर पर निर्भर स्लाइड्स को पुनः असाइन किया जाता है। अन्य मास्टर से जुड़ी स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखती हैं। थीम‑सेनसिटिव रंग, फ़ॉन्ट, फ़िल, लाइन, पृष्ठभूमि, और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर के ओवरराइड्स नई मास्टर से विरासत में मिले मानों पर प्राथमिकता ले सकते हैं।

थीम उन फ़ॉन्ट्स का संदर्भ दे सकती है जो रन‑टाइम वातावरण में उपलब्ध नहीं हैं। निरंतर रेंडरिंग और निर्यात के लिये आवश्यक फ़ॉन्ट्स स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोतों](/slides/hi/php-java/custom-font/) के माध्यम से उपलब्ध कराएँ, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/php-java/font-substitution/) को कॉन्फ़िगर करें।

यह एक सीधा मास्टर‑स्तर कार्यप्रवाह है: मेथड एक `.thmx` फ़ाइल पथ को स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर के थीम ओवरराइड बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड के माध्यम से [Slide::getLayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) और [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को सहेजें, क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स से उनके मास्टर खोजता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

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

पहला कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `$firstGroupMaster` पर निर्भर हैं, और दूसरा कॉल केवल उन स्लाइड्स को जो `$secondGroupMaster` पर निर्भर हैं। किसी अन्य मास्टर से जुड़ी स्लाइड्स को फिर से शैलीबद्ध नहीं किया जाता।

### **स्लाइड स्थानांतरित करने पर स्रोत थीम संरक्षित रखें**

यदि आप स्लाइड को अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिजाइन बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर क्लोन किए गए मास्टर के साथ [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) से स्लाइड को क्लोन करें। इससे मास्टर, उसके लेआउट, और सम्बद्ध थीम साथ में चले आते हैं।

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

यह कार्यप्रवाह तब पसंद किया जाता है जब स्रोत स्लाइड को गंतव्य में भी समान दिखना आवश्यक हो। केवल सामग्री को बेमेल गंतव्य मास्टर पर क्लोन करने से थीम‑प्रेरित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूद स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को वर्तमान मास्टर और लेआउट पर ही रखना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड आरंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में लिए गए थीम को बदले बिना उस स्लाइड द्वारा उपयोग किए गए थीम को बदलता है। स्थानीय ओवरराइड को हटाने और विरासत मानों पर लौटने के लिये [OverrideTheme.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि विशेष स्लाइड का अपना ओवरराइड न हो। समान आरंभिक विधियों का उपयोग [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslidethememanager/) के माध्यम से किया जा सकता है:

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

जब कई लेआउट और स्लाइड्स को समान आधार डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम का प्रयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तब लेआउट ओवरराइड, और केवल असाधारण मामलों में स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड्स बाद में ग्लोबली थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि फ़िल्स को [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) में संग्रहीत किया जाता है। PowerPoint उपयोगकर्ता इंटरफ़ेस में इस संग्रह में भौतिक रूप से संग्रहीत फ़िल परिभाषाओं से अधिक पृष्ठभूमि विकल्प प्रस्तुत कर सकता है, क्योंकि UI थीम फ़िल को थीम रंग और अन्य शैली रेफ़रेंसेस के साथ संयोजित कर सकता है।

![प्रस्तुति थीम के लिये PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) को जांचें। शैली इंडेक्स `0` का अर्थ है कोई थीम्ड फ़िल नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैलियों के रेफ़रेंसेस हैं। यह PHP संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह मानना ​​नहीँ चाहिए कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि फ़िल शैली हैं।

निम्न उदाहरण उपलब्ध पृष्ठभूमि फ़िल गिनती रिपोर्ट करता है, प्रथम मास्टर को एक थीम्ड पृष्ठभूमि रेफ़रेंस असाइन करता है, और प्रस्तुति सहेजता है:

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

दिखाया गया परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}

शैली इंडेक्स को शून्य‑आधारित संग्रह इंडेक्स न समझें। किसी फ़ाइल से शैली संख्या हार्ड‑कोड करके दूसरे फ़ाइल में समान रूप मानने से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।

{{% /alert %}}

{{% alert color="info" title="युक्ति" %}}

सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिये देखें [Presentation Background](/slides/hi/php-java/presentation-background/)।

{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट योजना अलग‑अलग फ़िल, लाइन, और प्रभाव शैली संग्रहों को [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) के माध्यम से उजागर करती है। सामान्य ऑफिस थीम में अक्सर तीन प्रमुख शैली प्रविष्टियां होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग के अनुरूप होती हैं, लेकिन कोड को प्रत्येक संग्रह की जांच करनी चाहिए न कि स्थायी गिनती मान लेना चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

PHP में इन संग्रहों तक पहुँचते समय संग्रह इंडेक्स शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकार की शैली‑रेफ़रेंस इंडेक्स एक अलग अवधारणा है, जिसे [ShapeStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को संशोधित करने से उन आकारों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी प्रभाव शैली में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिये, पहली थीम लाइन शैली लाल हो जाएगी, तीसरी थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरी प्रभाव शैली में दूरी 10 पॉइंट का बाहरी शैडो जुड़ जाएगा। अंतिम दृश्य परिणाम इस बात पर भी निर्भर करेगा कि प्रत्येक आकार कौन से स्लॉट संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड कर रही है।

![लाइन, फ़िल, और शैडो सेटिंग्स बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **निर्धारित करें कि कोई प्रभावी सॉलिड फ़िल थीम रंग का उपयोग कर रहा है या नहीं**

फ़िल को सीधे किसी वस्तु पर संग्रहीत किया जा सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या अन्य फ़ॉर्मेटिंग स्तर से विरासत में मिल सकता है। इस पदानुक्रम को अपरिवर्तनीय प्रभावी फ़िल डेटा में हल करने के लिये [FillFormat::getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) को कॉल करें। पहले उसके `getFillType` परिणाम की जाँच करें। केवल जब यह `FillType::Solid` हो तो ही आपको सॉलिड‑फ़िल गुण पढ़ने चाहिए।

सॉलिड फ़िल के लिये, `getSolidFillColor` विरासत, थीम लुक‑अप, और रंग परिवर्तन लागू होने के बाद अंतिम RGB मूल्य लौटाता है। `getSolidFillSchemeColor` संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) स्लॉट, जैसे `Text1` या `Accent6`, लौटाता है। `SchemeColor::NotDefined` का अर्थ है कि प्रभावी सॉलिड फ़िल किसी स्कीम रंग पर आधारित नहीं है। ऐसी कार्यप्रवाह में जहाँ फ़िल या तो थीम रंग या सीधे RGB रंग होते हैं, यह मान सीधे RGB फ़िल की पहचान करता है।

केवल स्थानीय [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorformat/) मान पर निर्भर होकर फ़िल को वर्गीकृत न करें। उदाहरण के लिये, टेक्स्ट भाग में स्थानीय रूप से कोई स्कीम रंग नहीं हो सकता, इसलिए उसकी स्थानीय मान `NotDefined` होगी, जबकि उसका प्रभावी फ़िल थीम रंग विरासत में लेकर `Text1` या `Accent6` में हल हो सकता है। विपरीत रूप से, `getSolidFillSchemeColor` बताता है कि कौन सा तार्किक थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट वस्तु, पैराग्राफ, लेआउट, मास्टर, या किसी अन्य स्तर से आया है।

निम्न उदाहरण प्रस्तुति लोड करता है, दोनों आकार फ़िल और टेक्स्ट‑पोर्टियन फ़िल को ऑडिट करता है, प्रत्येक अंतिम RGB मान और सम्बंधित स्कीम रंग प्रिंट करता है, और उन सॉलिड फ़िल को चिह्नित करता है जो थीम रंग परिवर्तनों को नहीं ट्रैक करेंगे:

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

`NotDefined` शाखा उन सॉलिड फ़िल की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट में परिवर्तन के लिये उत्तरदायी नहीं होंगी। ऐसे वस्तुओं की समीक्षा करें जब प्रस्तुति को नई ब्रांड पैलेट का पालन करना हो। रिपोर्ट किया गया RGB मान अभी भी वर्तमान अभिव्यक्ति दिखाता है, जबकि स्कीम मान बताता है कि वह अभिव्यक्ति थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट वस्तुएँ स्नैपशॉट होती हैं। प्रस्तुति थीम, थीम ओवरराइड, या कोई विरासत फ़ॉर्मेटिंग बदलने के बाद `getEffective` दोबारा कॉल करें और तुलना या रिपोर्ट करने से पहले नया प्रभावी फ़िल डेटा पढ़ें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि स्लाइड या आकार विरासत और स्थानीय ओवरराइड्स हल होने के बाद वास्तव में क्या उपयोग करता है। स्लाइड के लिये, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिये, [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) का उपयोग करें, और फ़िल के लिये, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) का।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और प्रथम आकार फ़िल पढ़ता है:

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

रेंडरिंग निदान, मान्यकरण, और तुलना के लिये प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) का निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को चूक सकते हैं जो अंतिम अभिव्यक्ति को बदलते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर हैं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम बरकरार रखती हैं।

**क्या मैं बिना मास्टर बदले किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम आरंभ करें। बदलाव केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइड्स अपनी मौजूदा थीम विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

स्लाइड को स्थानांतरित करते समय और उसकी स्रोत अभिव्यक्ति संरक्षित रखने के लिये स्रोत मास्टर को गंतव्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) और [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) से क्लोन करें। इससे मास्टर, लेआउट, और थीम एक साथ रखी जाती हैं।

**विरासत और ओवरराइड्स के बाद प्रभावी मान कैसे देख सकते हैं?**

स्लाइड या लेआउट थीम के लिये [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) का उपयोग करें और फ़ॉर्मेट वस्तुओं जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) के सम्बंधित प्रभावी‑डेटा मेथड्स को कॉल करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए हुए मान लौटाते हैं।