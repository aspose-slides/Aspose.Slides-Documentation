---
title: "PHP में प्रस्तुति स्थानीयकरण को स्वचालित करें"
linktitle: "प्रस्तुति स्थानीयकरण"
type: docs
weight: 100
url: /hi/php-java/presentation-localization/
keywords:
  - "भाषा बदलें"
  - "वर्तनी जांच"
  - "वर्तनी जांच को रोकें"
  - "प्रूफ़िंग भाषा"
  - "भाषा आईडी"
  - "बहुभाषी टेक्स्ट"
  - "PowerPoint"
  - "प्रस्तुति"
  - "PHP"
  - "Aspose.Slides"
description: "PHP में Aspose.Slides के साथ PowerPoint और OpenDocument प्रस्तुति टेक्स्ट के लिए प्रूफ़िंग भाषाएँ निर्धारित करें, जिसमें डिफ़ॉल्ट और बहुभाषी पैराग्राफ शामिल हैं।"
---
## **समीक्षा**

Aspose.Slides for PHP via Java आपको व्यक्तिगत टेक्स्ट भागों के लिए प्रूफ़िंग मेटाडेटा कॉन्फ़िगर करने की अनुमति देता है। प्रूफ़िंग भाषा की पहचान करने के लिए [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId), वर्तनी जांच को अनुमति देने या रोकने के लिए [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setSpellCheck), और व्यापक “नो‑प्रूफ़” स्थिति को नियंत्रित करने के लिए [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setProofDisabled) का उपयोग करें। क्योंकि ये सेटिंग्स भाग स्तर पर लागू होती हैं, एक पैराग्राफ में कई भाषाएँ और विभिन्न प्रूफ़िंग नियम हो सकते हैं।

यह लेख बताता है कि विशिष्ट टेक्स्ट को भाषा कैसे सौंपें, नए टेक्स्ट के लिए डिफ़ॉल्ट भाषा को [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) के साथ सेट करें, बहुभाषी पैराग्राफ बनाएं, `SpellCheck` और `ProofDisabled` के बीच चयन करें, और जब [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) का प्रयोग करें तो इच्छित सेटिंग्स को बनाए रखें। ये प्रॉपर्टीज़ प्रेजेंटेशन एप्लिकेशन्स के लिए मेटाडेटा संग्रहीत करती हैं; वे टेक्स्ट का अनुवाद नहीं करतीं, शब्दकोश-आधारित वर्तनी जाँच नहीं करतीं, और गलत शब्दों की सूची नहीं लौटातीं।

## **टेक्स्ट के लिए प्रूफ़िंग भाषा सेट करें**

एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) बनाएं या लोड करें, आवश्यक टेक्स्ट भाग को [Portion::getPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getPortionFormat) के माध्यम से एक्सेस करें, और उसकी भाषा पहचानकर्ता असाइन करें। निम्न उदाहरण एक शेप बनाता है, ब्रिटिश अंग्रेज़ी को प्रूफ़िंग भाषा के रूप में सेट करता है, और परिणाम को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#save) के साथ सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **नए टेक्स्ट के लिए डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके Aspose.Slides द्वारा नए निर्मित टेक्स्ट को सौंपे जाने वाली प्रूफ़िंग भाषा निर्दिष्ट करें। जब प्रेजेंटेशन में अधिकांश या सभी नया टेक्स्ट एक ही भाषा का उपयोग करता है, तो यह सेटिंग उपयोगी होती है। यह उस टेक्स्ट की भाषा मेटाडेटा को नहीं बदलती जिसका पहले से स्पष्ट भाषा निर्धारित है।

निम्न उदाहरण एक प्रेजेंटेशन बनाता है जिसका नया टेक्स्ट जर्मन प्रूफ़िंग नियमों का उपयोग करता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एक पैराग्राफ में कई भाषाओं का उपयोग करें**

[Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) में टेक्स्ट भागों का संग्रह होता है। प्रत्येक भाषा के लिए अलग [Portion](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) बनाएं और उसके `LanguageId` को स्वतंत्र रूप से सेट करें।

यह उदाहरण एक पैराग्राफ बनाता है जिसमें अंग्रेज़ी और फ्रेंच भाग शामिल हैं:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **व्यक्तिगत भागों के लिए वर्तनी जांच को सक्षम या रोकें**

[PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/) सामान्य टेक्स्ट गुणों को विरासत में प्राप्त करता है जो [BasePortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/) द्वारा परिभाषित हैं। एक भाग के फ़ॉर्मेट को [Portion::getPortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/#getPortionFormat) द्वारा एक्सेस करें और [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setSpellCheck) का उपयोग करके निर्धारित करें कि प्रेजेंटेशन एप्लिकेशन उस भाग की वर्तनी जांच कर सके या नहीं। डिफ़ॉल्ट मान `false` है: `true` वर्तनी जांच को अनुमति देता है, जबकि `false` इसे रोकता है।

यह सेटिंग व्यक्तिगत टेक्स्ट भागों पर लागू होती है। एक ही पैराग्राफ में विभिन्न भागों के लिए अलग मान उपयोग किए जा सकते हैं। [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) और `setSpellCheck` पूरक उद्देश्यों के लिए होते हैं: `setLanguageId` प्रूफ़िंग भाषा की पहचान करता है, जबकि `setSpellCheck` निर्धारित करता है कि भाग के लिए वर्तनी जांच की अनुमति है या नहीं।

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setProofDisabled) भी प्रूफ़िंग को नियंत्रित करता है, लेकिन यह व्यापक “do not proof” स्थिति को एक [NullableBool](https://reference.aspose.com/slides/hi/php-java/aspose.slides/nullablebool/) के रूप में दर्शाता है। जब आपको विशेष रूप से वर्तनी जांच के लिए सीधा बूलियन स्विच चाहिए हो तो `setSpellCheck` का उपयोग करें। जब आपको प्रेजेंटेशन की “नो‑प्रूफ़” मेटाडेटा को बनाए रखने या स्पष्ट रूप से नियंत्रित करने की आवश्यकता हो, जिसमें उसका `NotDefined` स्थिति भी शामिल है, तो `setProofDisabled` का उपयोग करें। यदि आप दोनों प्रॉपर्टी सेट करते हैं, तो उनके मान निरंतर रखें; `setSpellCheck(true)` को `setProofDisabled(NullableBool::True)` के साथ न मिलाएँ।

ये प्रॉपर्टीज़ PowerPoint और अन्य प्रेजेंटेशन एप्लिकेशन्स द्वारा उपयोग किए जाने वाले प्रूफ़िंग मेटाडेटा को कॉन्फ़िगर करती हैं। Aspose.Slides इन्हें शब्दकोश-आधारित वर्तनी जांच चलाने या गलत शब्दों की सूची वापस करने के लिए उपयोग नहीं करता।

निम्न पूर्ण उदाहरण एक इनपुट प्रेजेंटेशन बनाता है, उसे लोड करता है, एक ही पैराग्राफ में दो भागों को विभिन्न स्पेल‑चेक सेटिंग्स और प्रूफ़िंग भाषाएँ सौंपता है, परिणाम को सहेजता है, फिर से खोलता है, और संग्रहीत मानों की पुष्टि करता है:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) उन आसन्न भागों को मिलाता है जिनका फ़ॉर्मेट समान होता है। केवल `SpellCheck` में अंतर होने से ऐसे भाग अलग नहीं रहते; जब वे मिलाए जाते हैं, तो परिणामी भाग पहले भाग का `SpellCheck` मान रखता है। यदि भागों को विभिन्न स्पेल‑चेक सेटिंग्स चाहिए हों, तो उन सेटिंग्स को असाइन करने से पहले `joinPortionsWithSameFormatting` को कॉल करें, या परिणामी भाग की सीमाओं की जाँच करें और बाद में सेटिंग्स दोबारा लागू करें। विभिन्न `LanguageId` मान वाले भाग अलग रहेंगे क्योंकि उनका प्रूफ़िंग‑भाषा फ़ॉर्मेट भिन्न होता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा ID टेक्स्ट का अनुवाद करती है?**

नहीं। [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) वर्तनी और व्याकरण के लिए प्रूफ़िंग मेटाडेटा संग्रहीत करता है; यह टेक्स्ट सामग्री को नहीं बदलता। टेक्स्ट को अलग से अनुवादित करें, और फिर प्रत्येक अनूदित भाग के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफ़िंग भाषा फ़ॉन्ट्स, हाइफ़नेशन, या लाइन रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता केवल प्रूफ़िंग के लिए है। टेक्स्ट रेंडरिंग और लेआउट मुख्यतः उपलब्ध [fonts](/slides/hi/php-java/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट‑फ़्रेम सेटिंग्स पर निर्भर करता है। विश्वसनीय रेंडरिंग के लिए आवश्यक फ़ॉन्ट्स प्रदान करें, [font substitution](/slides/hi/php-java/font-substitution/) कॉन्फ़िगर करें, या प्रेजेंटेशन में [embed fonts](/slides/hi/php-java/embedded-font/) को एम्बेड करें।

**क्या एक पैराग्राफ कई प्रूफ़िंग भाषाएँ उपयोग कर सकता है?**

हां। प्रत्येक भाषा को अलग भाग को सौंपें, जैसे बहुभाषी पैराग्राफ उदाहरण में दिखाया गया है।

**मुझे `setDefaultTextLanguage` या `setLanguageId` में से कौन सा उपयोग करना चाहिए?**

जब आप नए निर्मित टेक्स्ट के लिए डिफ़ॉल्ट चाहते हैं तो [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करें। जब किसी विशिष्ट भाग को स्पष्ट प्रूफ़िंग भाषा की आवश्यकता हो या पैराग्राफ में कई भाषाएँ हों, तब [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setLanguageId) का उपयोग करें।