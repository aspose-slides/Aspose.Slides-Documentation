---
title: PHP का उपयोग करके प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: एंबेडेड फ़ॉन्ट्स
type: docs
weight: 40
url: /hi/php-java/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एंबेडेड फ़ॉन्ट प्राप्त करें
- एंबेडेड फ़ॉन्ट जोड़ें
- एंबेडेड फ़ॉन्ट हटाएँ
- एंबेडेड फ़ॉन्ट संकुचित करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides के साथ PowerPoint में एम्बेडेड फ़ॉन्ट्स को प्रबंधित करें। फ़ॉन्ट्स को जोड़ें, पुनः प्राप्त करें, हटाएँ और संकुचित करें ताकि पाठ की उपस्थिति बनी रहे और फ़ाइल आकार कम हो।"
---
## **परिचय**

फ़ॉन्ट एम्बेड करने से फ़ॉन्ट डेटा PowerPoint प्रस्तुति के भीतर संग्रहीत होता है। जब एक दर्शक एम्बेडेड फ़ॉन्ट को समर्थन देता है, तो वह लक्षित सिस्टम पर फ़ॉन्ट स्थापित न होने पर भी उन फ़ॉन्ट का उपयोग करके पाठ प्रदर्शित कर सकता है। यह पंक्तियों के विराम, पाठ के अंतराल, और स्लाइड लेआउट को संरक्षित रखने में मदद करता है।

Aspose.Slides for PHP via Java आपको एम्बेडेड फ़ॉन्ट को पुनः प्राप्त करने, जोड़ने और हटाने की अनुमति देता है, जिससे आप [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/) क्लास के माध्यम से कर सकते हैं, जो कि [Presentation::getFontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getFontsManager) द्वारा लौटाया जाता है। आप प्रस्तुति में प्रयुक्त न होने वाले वर्णों को हटाकर एम्बेडेड फ़ॉन्ट डेटा का आकार भी कम कर सकते हैं।

नीचे दिए गए उदाहरण PPTX फ़ाइलों के साथ काम करते हैं। फ़ॉन्ट को एम्बेड करने से पहले, सुनिश्चित करें कि उसका फ़ॉन्ट डेटा Aspose.Slides के लिए उपलब्ध है और उसका लाइसेंस एम्बेडिंग की अनुमति देता है।

## **एम्बेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

एक प्रस्तुति में संग्रहीत फ़ॉन्ट की सूची प्राप्त करने के लिए [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) का उपयोग करें। एक फ़ॉन्ट को हटाने के लिए, उस सूची से फ़ॉन्ट को [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) में पास करें, और फिर प्रस्तुति को सहेजें।

निम्न उदाहरण `EmbeddedFonts.pptx` में एम्बेडेड फ़ॉन्ट की सूची देता है और यदि मौजूद है तो Calibri को हटाता है:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

एक एम्बेडेड फ़ॉन्ट को हटाने से उसके संग्रहीत फ़ॉन्ट डेटा को हटा दिया जाता है; यह पाठ को सौंपे गए फ़ॉन्ट को नहीं बदलता। यदि फ़ॉन्ट लक्ष्य प्रणाली पर स्थापित है, तो पाठ अभी भी इसका उपयोग कर सकता है। अन्यथा, रेंडरिंग के लिए [font substitution](/slides/hi/php-java/font-substitution/) की आवश्यकता हो सकती है, जो लेआउट को प्रभावित कर सकती है।

## **फ़ॉन्ट डेटा और एम्बेडिंग अनुमतियों का निरीक्षण**

फ़ॉन्ट को एम्बेड करने से पहले निरीक्षण करने के लिए [FontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/) क्लास का उपयोग करें। प्रस्तुति में प्रयुक्त फ़ॉन्ट को प्राप्त करने के लिए आप [FontsManager::getFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getFonts) को कॉल करें। प्रत्येक फ़ॉन्ट के लिए, एक [FontData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontdata/) ऑब्जेक्ट और आवश्यक [FontStyleType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontstyletype/) मान को [FontsManager::getFontBytes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getFontBytes) में पास करें। यह मेथड उस फ़ॉन्ट शैली के लिए बाइनरी डेटा लौटाता है, या जब अनुरोधित फ़ॉन्ट या शैली उपलब्ध नहीं होती है तो `null` लौटाता है। `null` परिणाम को [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) में न पास करें, क्योंकि यह मेथड बाइट एरे की आवश्यकता रखता है।

[EmbeddingLevel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/embeddinglevel/) एक फ़्लैग्स एन्यूमरेशन है जो फ़ॉन्ट में संग्रहीत एम्बेडिंग प्रतिबंधों की रिपोर्ट करता है:
- `Installable` एम्बेडिंग और किसी अन्य सिस्टम पर स्थायी स्थापना की अनुमति देता है, फ़ॉन्ट लाइसेंस के अधीन।
- `Restricted` एम्बेडिंग को रोकता है जब तक फ़ॉन्ट के कानूनी मालिक से अनुमति न ली जाए, यदि यह एकमात्र उपयोग-अनुमति फ़्लैग है।
- `PreviewPrint` दर्शनीय और प्रिंटिंग के लिए अस्थायी उपयोग की अनुमति देता है; फ़ॉन्ट युक्त दस्तावेज़ केवल-रीड होना चाहिए।
- `Editable` अस्थायी उपयोग की अनुमति देता है और दस्तावेज़ को संपादित व सहेजने की सुविधा देता है।
- `NoSubsetting` एक अतिरिक्त प्रतिबंध है जो ग्लीफ्स के केवल उपसमुच्चय को एम्बेड करने से रोकता है। जब यह फ़्लैग मौजूद हो, तो सभी वर्ण एम्बेड करें।
- `BitmapOnly` एक अतिरिक्त प्रतिबंध है जो केवल बिटमैप स्ट्राइक्स को एम्बेड करने की अनुमति देता है, आउटलाइन डेटा नहीं। यदि फ़ॉन्ट में बिटमैप स्ट्राइक्स नहीं हैं, तो इसे एम्बेड नहीं किया जा सकता।

पहले चार मान उपयोग अनुमति का वर्णन करते हैं, जबकि `NoSubsetting` और `BitmapOnly` उन्हें साथ में जोड़े जा सकते हैं। संशोधकों को बिटवाइज़ ऑपरेशंस के साथ जांचें। क्योंकि `Installable` शून्य है, उपयोग-अनुमति बिट्स को मास्क करें और परिणाम की तुलना `Installable` से करें, बजाय इसे फ़्लैग के रूप में जांचने के। वर्तमान फ़ॉन्ट को अधिकतम एक ही उपयोग-अनुमति बिट सेट करना चाहिए। पुराने फ़ॉन्ट जो एक से अधिक सेट करते हैं, उनके साथ संगतता के लिए नीचे दिया गया हेल्पर सबसे कम प्रतिबंधित अनुमति चुनता है: `Editable`, फिर `PreviewPrint`, फिर `Restricted`।

निम्न उदाहरण `FontsManager::getFonts` द्वारा लौटाए गए प्रत्येक फ़ॉन्ट के नियमित, बोल्ड, इटैलिक, और बोल्ड-इटैलिक डेटा का ऑडिट करता है। यह अनुपलब्ध शैलियों, प्रतिबंधित फ़ॉन्ट, केवल-बिटमैप फ़ॉन्ट, प्रीव्यू और प्रिंट तक सीमित फ़ॉन्ट (क्योंकि आउटपुट अभी भी संपादनीय रहता है), और पहले से एम्बेडेड फ़ॉन्ट को छोड़ देता है। यदि कोई उपलब्ध शैली में `NoSubsetting` है, तो वह फ़ॉन्ट परिवार के सभी वर्ण एम्बेड करता है।
```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यह निरीक्षण प्रत्येक फ़ॉन्ट फ़ाइल में एन्कोडेड प्रतिबंधों की रिपोर्ट करता है। यह कोई लाइसेंस नहीं देता, यह प्रमाणित नहीं करता कि आपने फ़ॉन्ट कानूनी रूप से प्राप्त किया है, या एम्बेडेड कॉपी वितरित करने से पहले फ़ॉन्ट लाइसेंस समझौते की जाँच को बदलता नहीं है।

## **एम्बेडेड फ़ॉन्ट जोड़ें**

[FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) का उपयोग करके फ़ॉन्ट को एम्बेड करें। इसके ओवरलोड या तो एक [FontData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontdata/) ऑब्जेक्ट या फ़ॉन्ट डेटा वाला बाइट एरे स्वीकार करते हैं। [EmbedFontCharacters](https://reference.aspose.com/slides/hi/php-java/aspose.slides/embedfontcharacters/) एन्यूमरेशन यह नियंत्रित करती है कि कौन से वर्ण शामिल किए जाएँ:
- [All](https://reference.aspose.com/slides/hi/php-java/aspose.slides/embedfontcharacters/) फ़ॉन्ट में सभी वर्ण एम्बेड करता है। इस विकल्प का उपयोग तब करें जब प्राप्तकर्ता को प्रस्तुति संपादित करनी हो और नया पाठ दर्ज करना हो।
- [OnlyUsed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/embedfontcharacters/) केवल प्रस्तुति में प्रयुक्त वर्णों को एम्बेड करता है ताकि फ़ाइल आकार कम हो। इस विकल्प को देखें जब प्रस्तुति मुख्यतः देखने के लिए बनाई गई हो।

निम्न उदाहरण [FontsManager::getFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getFonts) का उपयोग करके `Fonts.pptx` में प्रयुक्त फ़ॉन्ट को प्राप्त करता है और उन फ़ॉन्ट को एम्बेड करता है जो पहले से एम्बेडेड नहीं हैं। जोड़ने के लिए फ़ॉन्ट कोड चलाने वाली मशीन पर उपलब्ध होना चाहिए। मौजूदा एम्बेडेड फ़ॉन्ट अपने वर्तमान वर्ण सेट को बरकरार रखते हैं।
```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एम्बेडेड फ़ॉन्ट संकुचित करें**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/compress/#compressEmbeddedFonts) अप्रयुक्त वर्णों को हटाकर एम्बेडेड फ़ॉन्ट डेटा को कम करता है। यह पहले से एम्बेडेड फ़ॉन्ट पर काम करता है, इसलिए आकार में कमी इस बात पर निर्भर करती है कि प्रस्तुति में कितना अप्रयुक्त फ़ॉन्ट डेटा मौजूद है।

निम्न उदाहरण `EmbeddedFonts.pptx` में फ़ॉन्ट को संकुचित करता है और परिणाम को एक अलग फ़ाइल के रूप में सहेजता है:
```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

यदि प्राप्तकर्ताओं को बाद में पाठ जोड़ने की आवश्यकता हो तो मूल फ़ाइल रखें। संकुचन के दौरान हटाए गए वर्ण अब एम्बेडेड फ़ॉन्ट से उपलब्ध नहीं होंगे, भले ही आपने मूल रूप से सभी वर्ण एम्बेड किए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जांच सकता हूँ कि एम्बेडेड फ़ॉन्ट रेंडरिंग के दौरान अभी भी प्रतिस्थापित किया जाएगा या नहीं?**  
रेंडरिंग के माहौल में जहाँ आप प्रस्तुति रेंडर करते हैं, वहाँ [FontsManager::getSubstitutions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getSubstitutions) को कॉल करें ताकि देख सकें Aspose.Slides कौन से फ़ॉन्ट को प्रतिस्थापित करेगा। साथ ही [font substitution](/slides/hi/php-java/font-substitution/) सेटिंग्स और [font fallback](/slides/hi/php-java/fallback-font/) नियमों की जाँच करें। फॉलबैक लापता वर्णों को संभालता है, इसलिए फ़ॉन्ट को एम्बेड करने से उन वर्णों का समाधान नहीं होता जो स्वयं फ़ॉन्ट में नहीं होते।

**क्या मुझे Arial और Calibri जैसे सामान्य फ़ॉन्ट एम्बेड करने चाहिए?**  
निर्णय लक्ष्य वातावरण पर आधारित होना चाहिए। यदि आवश्यक फ़ॉन्ट प्रत्येक मशीन पर उपलब्ध हैं जो प्रस्तुति खोलती या रेंडर करती है, तो उन्हें एम्बेड करने से अनावश्यक फ़ाइल आकार बढ़ सकता है। यदि प्राप्तकर्ता या सर्वर इन फ़ॉन्टों के अभाव में हों, तो उन्हें एम्बेड करने से इच्छित दिखावट बनी रहेगी, बशर्ते उनके लाइसेंस इसे अनुमति दें।