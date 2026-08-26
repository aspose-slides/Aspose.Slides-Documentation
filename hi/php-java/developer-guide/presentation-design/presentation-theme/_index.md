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
- थीम इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में मास्टर प्रस्तुति थीम, जो निरंतर ब्रांडिंग के साथ PowerPoint फ़ाइलों को बनाने, अनुकूलित करने और परिवर्तित करने में सहायता करती हैं।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट, बैकग्राउंड शैलियों, फिल्स, लाइनों और प्रभावों का समन्वित सेट निर्धारित करती है। थीम-जानकार वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए एक थीम परिवर्तन कई वस्तुओं को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) के माध्यम से उपलब्ध कराया जाता है। एक प्रस्तुति में निम्न स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर अपनी थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterthememanager/) के द्वारा ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपनी विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) के द्वारा ओवरराइड कर सकते हैं। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, बैकग्राउंड स्टाइल और प्रभाव](theme-constituents.png)

नीचे दिए गए अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट शैलियों को अपडेट करना, तथा विरासत और ओवरराइड के बाद प्रभावी मान पढ़ना।

## **एक थीम की जाँच करें**

[MasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) वस्तु अपनी थीम की रंग योजना, फ़ॉन्ट योजना और फ़ॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/mastertheme/) के माध्यम से उजागर करती है। इन संग्रहों की जाँच करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फिल, लाइन, और इफ़ेक्ट शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर का उपयोग करती है, तो यह न मानें कि हर स्लाइड की प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर की जाँच करें, और बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं।

## **थीम के रंग बदलें**

थीम‑जानकार फिल, लाइन और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ ले सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग का संदर्भ ले रही हैं, नया मान प्राप्त कर लेती हैं। जो वस्तुएँ सीधे RGB रंग का उपयोग करती हैं, उन्हें थीम‑रंग अपडेट से नहीं बदला जाता।

निम्न अंत‑से‑अंत उदाहरण एक ऐसा आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, फिर उसे पुनः खोलता है, और प्रभावी फिल रंग को प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस फिल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे संस्करण उत्पन्न करने के लिए रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के तथा गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे संस्करण।

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

ये रूपांतरित रंग थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/colorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये ऐसे मान नहीं हैं जो गतिशील रूप से एक रूप से दूसरे में परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षकों के लिए एक प्रमुख फ़ॉन्ट सेट और शरीर पाठ के लिए एक गौण फ़ॉन्ट सेट होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontscheme/) विधियाँ उन सेटों को उजागर करती हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता पाठ फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक शीर्षक बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी पंक्ति बनाता है जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

शीर्षक प्रमुख फ़ॉन्ट का अनुसरण करता है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। वह टेक्स्ट जिसका स्पष्ट फ़ॉन्ट नाम थीम पहचानकर्ता के बजाय दिया गया है, थीम फ़ॉन्ट योजना बदलने पर स्वतः स्विच नहीं होगा।

प्रमुख और गौण फ़ॉन्ट संग्रहों में व्यक्तिगत लेखन प्रणालियों जैसे सायरिलिक, अरबी, जापानी, जॉर्जियन और थाना के लिए फ़ॉन्ट मैपिंग भी शामिल हो सकते हैं। इन मैपिंग को जाँचने, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/php-java/script-specific-font-mappings/)।

{{% alert color="info" title="सुझाव" %}}
अधिक जानकारी के लिए देखें [PowerPoint फ़ॉन्ट](/slides/hi/php-java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम को कॉपी या लागू करें**

नीचे दिए गए कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **एक मास्टर की निर्भर स्लाइड्स पर बाहरी थीम लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स को पुनः स्टाइल करना चाहते हों, तो [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) का उपयोग करें। चयनित मास्टर को [Presentation::getMasters](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) संग्रह से चुनें, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) द्वारा प्रदर्शित होता है, और विधि को थीम फ़ाइल पथ पास करें।

विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
1. बाहरी थीम को नए मास्टर पर लागू करती है।
1. नए मास्टर को उन सभी स्लाइड्स को सौंपती है जो पहले चयनित मास्टर पर निर्भर थीं।
1. नए निर्मित [MasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) को लौटाती है।

निम्न उदाहरण प्रथम मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

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

अवैध, दूषित, या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxreadexception/) हो सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथों को प्रमाणित करें, फ़ाइल‑सिस्टम पहुँच विफलताओं को संभालें, और केवल तब प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनः नियोजित किया जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर से जुड़े स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखते हैं। थीम‑जानकार रंग, फ़ॉन्ट, फिल, लाइन, बैकग्राउंड और प्रभाव बाहरी थीम के विरुद्ध हल किए जाते हैं। सीधे सौंपे गए रंग, फ़ॉन्ट, फिल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर के ओवरराइड भी नए मास्टर से विरासत में मिली मानों पर प्राथमिकता ले सकते हैं।

थीम उन फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। निरंतर रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/php-java/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/php-java/font-substitution/) कॉन्फ़िगर करें।

यह एक सीधे मास्टर‑स्तर का कार्यप्रवाह है: विधि `.thmx` फ़ाइल पथ स्वीकार करती है और स्लाइड‑स्तर या लेआउट‑स्तर के थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर अग्रिम रूप से ज्ञात नहीं होता, तो इसे प्रतिनिधि स्लाइड से [Slide::getLayoutSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/) और [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslide/) के द्वारा प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को सहेजें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स का उपयोग करके उनके मास्टर खोजता है और प्रत्येक समूह पर एक अलग बाहरी थीम लागू करता है:

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

पहली कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `$firstGroupMaster` पर निर्भर थीं, और दूसरी कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `$secondGroupMaster` पर निर्भर थीं। अन्य किसी मास्टर से जुड़ी स्लाइड्स पुनः स्टाइल नहीं होतीं।

### **स्लाइड्स को перемещая स्रोत थीम को संरक्षित रखें**

यदि आप किसी स्लाइड को दूसरी प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) से क्लोन करें, फिर उस क्लोन किए गए मास्टर के साथ [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) से स्लाइड को क्लोन करें। यह मास्टर, उसके लेआउट और संबद्ध थीम को साथ ले जाता है।

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

यह वह कार्यप्रवाह है जिसे तब पसंद किया जाता है जब स्रोत स्लाइड को गंतव्य में समान रूप से दिखना चाहिए। केवल असंबंधित गंतव्य मास्टर पर सामग्री क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, बैकग्राउंड और प्रभाव बदल सकते हैं।

### **एक मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड आरंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में मिली थीम को बदले बिना केवल उस स्लाइड की थीम बदलता है। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/php-java/aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड की अपनी ओवरराइड न हो। समान आरंभिक विधियों का उपयोग [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/layoutslidethememanager/) के माध्यम से किया जा सकता है:

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

जब कई लेआउट और स्लाइड्स को समान आधार डिज़ाइन साझा करना हो, तो मास्टर या प्रस्तुति‑स्तर की थीम उपयोग करें; जब किसी एक लेआउट परिवार को अलग शैली चाहिए, तो लेआउट ओवरराइड उपयोग करें; और केवल असामान्य मामलों के लिए स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद के वैश्विक थीम बदलावों को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम के बैकग्राउंड फिल्स को [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) में संग्रहीत किया जाता है। PowerPoint UI में अधिक बैकग्राउंड विकल्प दिखा सकता है जितनी फिल परिभाषाएँ इस संग्रह में भौतिक रूप से संग्रहीत हैं, क्योंकि UI थीम फिल को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![प्रेजेंटेशन थीम के लिए PowerPoint बैकग्राउंड शैली गैलरी](presentation-design_8.png)

बैकग्राउंड शैली का उपयोग करने से पहले, संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) को जाँचें। शैली सूचकांक `0` का अर्थ है कोई थीमेड फिल नहीं; सकारात्मक मान थीम बैकग्राउंड‑स्टाइल संदर्भ होते हैं। यह PHP संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि हर प्रस्तुति में समान संख्या में बैकग्राउंड फिल शैलियाँ हों।

निम्न उदाहरण उपलब्ध बैकग्राउंड फिल गणना रिपोर्ट करता है, प्रथम मास्टर को थीम्ड बैकग्राउंड संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

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

दृश्य परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम बैकग्राउंड जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}
शैली सूचकांक को शून्य‑आधारित संग्रह सूचकांक न समझें। किसी फ़ाइल से एक शैली संख्या हार्ड‑कोड करना और इसे दूसरी फ़ाइल में समान उपस्थिति मान लेना भी न करें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="सूचना" %}}
सीधे बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/php-java/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स को अपडेट करें**

एक थीम फ़ॉर्मेट योजना अलग‑अलग फिल, लाइन और इफ़ेक्ट शैली संग्रहों को उजागर करती है, जिन्हें क्रमशः [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/php-java/aspose.slides/formatscheme/) के द्वारा प्राप्त किया जा सकता है। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियों को समाहित करती हैं जो दृश्य रूप से सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, पर कोड को प्रत्येक संग्रह की जाँच करनी चाहिए न कि एक निश्चित गणना मान लेनी चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम और तीव्र थीम इफ़ेक्ट्स](presentation-design_10.png)

जब आप PHP में इन संग्रहों तक पहुँचते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। एक आकार का शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जिसे [ShapeStyle](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को संशोधित करने से उन आकारों पर प्रभाव पड़ता है जो उस थीम शैली का संदर्भ देते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहला लाइन शैली बदलता है, तीसरा फिल शैली बदलता है, तीसरे इफ़ेक्ट शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए पहला थीम लाइन शैली लाल हो जाती है, तीसरा थीम फिल शैली ठोस फ़ॉरेस्ट ग्रीन हो जाता है, और तीसरे इफ़ेक्ट शैली में 10 प्वाइंट दूरी वाली बाहरी छाया जोड़ दी जाती है। अंतिम दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार कौन सा शैली स्लॉट संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, फिल और छाया सेटिंग्स बदलने के बाद थीम इफ़ेक्ट शैलियां](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्ची थीम वस्तुएँ आपको बताती हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान आपको बताते हैं कि कोई स्लाइड या आकार विरासत और स्थानीय ओवरराइड के बाद वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) को कॉल करें। बैकग्राउंड के लिए, [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) उपयोग करें, और फिल के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, बैकग्राउंड, और प्रथम आकार फिल पढ़ता है:

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

रेंडरिंग निदान, सत्यापन और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) को जाँचते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम उपस्थिति को बदलता है।

## **सामान्य प्रश्न (FAQ)**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों का उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम बरकरार रखती हैं।

**क्या मैं बिना मास्टर बदले एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidethememanager/) का उपयोग करें और उसकी ओवरराइड थीम को आरंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपना मौजूदा थीम विरासत में प्राप्त करती रहती हैं।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को स्थानांतरित करते समय उसकी मूल उपस्थिति को संरक्षित करना हो, तो स्रोत मास्टर को गंतव्य में क्लोन करें और उस मास्टर के साथ स्लाइड को क्लोन करें, इसके लिए [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/masterslidecollection/) और [SlideCollection.addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) का उपयोग करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseoverridethememanager/) और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।