---
title: जावास्क्रिप्ट में प्रस्तुति लोकलाइज़ेशन को स्वचालित करें
linktitle: प्रस्तुति लोकलाइज़ेशन
type: docs
weight: 100
url: /hi/nodejs-java/presentation-localization/
keywords:
- भाषा बदलें
- स्पेल चेक
- स्पेल चेक निष्क्रिय करें
- प्रूफिंग भाषा
- भाषा आईडी
- बहुभाषी टेक्स्ट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides के साथ जावास्क्रिप्ट में PowerPoint और OpenDocument प्रस्तुति टेक्स्ट के लिए प्रूफिंग भाषाएँ सेट करें, जिसमें डिफ़ॉल्ट और बहुभाषी पैराग्राफ शामिल हैं।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java आपको व्यक्तिगत टेक्स्ट हिस्सों के लिए प्रूफिंग मेटाडेटा कॉन्फ़िगर करने देता है। प्रूफिंग भाषा की पहचान करने के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) का उपयोग करें, स्पेल चेक को अनुमति देने या रोकने के लिए [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) का उपयोग करें, और व्यापक “no‑proof” स्थिति को नियंत्रित करने के लिए [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) का उपयोग करें। क्योंकि ये सेटिंग्स हिस्से स्तर पर लागू होती हैं, एक पैराग्राफ में कई भाषाएँ और अलग‑अलग प्रूफिंग नियम हो सकते हैं।

यह लेख बताता है कि विशिष्ट टेक्स्ट के लिए भाषा कैसे असाइन करें, नई टेक्स्ट के लिए डिफ़ॉल्ट भाषा को [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) के साथ कैसे सेट करें, बहुभाषी पैराग्राफ कैसे बनाएं, `SpellCheck` और `ProofDisabled` में से कौन‑सा उपयोग करना है, और [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) का उपयोग करते समय इच्छित सेटिंग्स को कैसे बनाए रखें। ये प्रॉपर्टीज़ प्रस्तुति एप्लिकेशन के लिए मेटाडेटा संग्रहीत करती हैं; ये टेक्स्ट का अनुवाद नहीं करतीं, शब्दकोश‑आधारित स्पेल‑चेक नहीं चलातीं, और गलत लिखे शब्दों की सूची नहीं लौटातीं।

## **टेक्स्ट के लिए प्रूफिंग भाषा सेट करना**

[Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) बनाएं या लोड करें, आवश्यक टेक्स्ट हिस्से को [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#getPortionFormat--) के माध्यम से प्राप्त करें, और उसके भाषा पहचानकर्ता को असाइन करें। निम्न उदाहरण एक शेप बनाता है, ब्रिटिश अंग्रेज़ी को प्रूफिंग भाषा के रूप में सेट करता है, और परिणाम को [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) से सहेजता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **नए टेक्स्ट के लिए डिफ़ॉल्ट भाषा सेट करना**

नए बनाए गए टेक्स्ट को Aspose.Slides द्वारा असाइन की गई प्रूफिंग भाषा को निर्दिष्ट करने के लिए [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करें। इस सेटिंग का उपयोग तब उपयोगी होता है जब प्रस्तुति में अधिकांश या सभी नए टेक्स्ट एक ही भाषा का उपयोग करते हों। यह उन टेक्स्ट की भाषा मेटाडेटा को नहीं बदलता जिनमें पहले से स्पष्ट भाषा सेट है।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें नया टेक्स्ट जर्मन प्रूफिंग नियमों का उपयोग करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक पैराग्राफ में कई भाषाओं का उपयोग करना**

[Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) में टेक्स्ट हिस्सों का संग्रह होता है। प्रत्येक भाषा के लिए एक अलग [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) बनाएं और उसका `LanguageId` स्वतंत्र रूप से सेट करें।

यह उदाहरण एक पैराग्राफ बनाता है जिसमें अंग्रेज़ी और फ़्रेंच हिस्से हैं:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत हिस्सों के लिए स्पेल‑चेक सक्षम या निष्क्रिय करना**

[PortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portionformat/) [BasePortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/) द्वारा परिभाषित सामान्य टेक्स्ट प्रॉपर्टीज़ को विरासत में प्राप्त करता है। एक हिस्से का फ़ॉर्मेट [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/#getPortionFormat--) के माध्यम से प्राप्त करें और [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) का उपयोग करके निर्धारित करें कि प्रस्तुति एप्लिकेशन उस हिस्से के लिए स्पेल‑चेक कर सकेगा या नहीं। डिफ़ॉल्ट मान `false` है: `true` स्पेल‑चेक की अनुमति देता है, जबकि `false` इसे निरुद्ध करता है।

यह सेटिंग व्यक्तिगत टेक्स्ट हिस्सों पर लागू होती है। एक ही पैराग्राफ में विभिन्न हिस्से अलग‑अलग मान रख सकते हैं। [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) और `setSpellCheck` पूरक उद्देश्यों के लिए होते हैं: `setLanguageId` प्रूफिंग भाषा निर्धारित करता है, जबकि `setSpellCheck` निर्धारित करता है कि उस हिस्से के लिए स्पेल‑चेक की अनुमति है या नहीं।

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) भी प्रूफिंग को नियंत्रित करता है, लेकिन यह एक [NullableBool](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/nullablebool/) के रूप में व्यापक “do not proof” स्थिति दर्शाता है। जब आपको केवल स्पेल‑चेक के लिए सीधा Boolean स्विच चाहिए, तो `setSpellCheck` उपयोग करें। जब आपको प्रस्तुति की “no‑proof” मेटाडेटा को संरक्षित या स्पष्ट रूप से नियंत्रित करना हो, जिसमें उसका `NotDefined` स्थिति भी शामिल है, तो `setProofDisabled` उपयोग करें। यदि आप दोनों प्रॉपर्टी सेट करते हैं, तो उनके मानों को संगत रखें; `setSpellCheck(true)` को `setProofDisabled(NullableBool.True)` के साथ न मिलाएँ।

ये प्रॉपर्टीज़ PowerPoint और अन्य प्रस्तुति एप्लिकेशन द्वारा उपयोग किए जाने वाले प्रूफिंग मेटाडेटा को कॉन्फ़िगर करती हैं। Aspose.Slides उनका उपयोग शब्दकोश‑आधारित स्पेल‑चेक चलाने या गलत लिखे शब्दों की सूची लौटाने के लिए नहीं करता।

निम्न पूर्ण उदाहरण एक इनपुट प्रस्तुति बनाता है, उसे लोड करता है, समान पैराग्राफ में दो हिस्सों के लिए विभिन्न स्पेल‑चेक सेटिंग्स और प्रूफिंग भाषाएँ असाइन करता है, परिणाम सहेजता है, पुनः खोलता है, और संग्रहीत मानों को सत्यापित करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) समान फ़ॉर्मेटिंग वाले पास‑पास के हिस्सों को जोड़ता है। केवल `SpellCheck` में अंतर होने से ऐसे हिस्से अलग नहीं रहते; जोड़ने के बाद परिणामस्वरूप हिस्सा पहले हिस्से का `SpellCheck` मान बरकरार रखता है। यदि हिस्सों को अलग‑अलग स्पेल‑चेक सेटिंग्स चाहिए, तो इन सेटिंग्स को असाइन करने से पहले `joinPortionsWithSameFormatting` को कॉल करें, या परिणामस्वरूप हिस्से की सीमाओं को जांचें और बाद में सेटिंग्स पुनः लागू करें। विभिन्न `LanguageId` मान वाले हिस्से अलग‑अलग रहते हैं क्योंकि उनका प्रूफिंग‑भाषा फ़ॉर्मेटिंग भिन्न होता है।

## **FAQ**

**क्या भाषा ID टेक्स्ट का अनुवाद करती है?**

नहीं। [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) स्पेलिंग और ग्रामर के लिए प्रूफिंग मेटाडेटा संग्रहीत करता है; यह टेक्स्ट सामग्री को नहीं बदलता। टेक्स्ट को अलग से अनुवादित करें, और फिर प्रत्येक अनूदित हिस्से के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफिंग भाषा फ़ॉन्ट, हाइफ़नेशन या लाइन‑रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता केवल प्रूफिंग के लिए है। टेक्स्ट रेंडरिंग और लेआउट मुख्य रूप से उपलब्ध [फ़ॉन्ट](/slides/hi/nodejs-java/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट‑फ़्रेम सेटिंग्स पर निर्भर करता है। विश्वसनीय रेंडरिंग के लिए आवश्यक फ़ॉन्ट प्रदान करें, [फ़ॉन्ट प्रतिस्थापन](/slides/hi/nodejs-java/font-substitution/) को कॉन्फ़िगर करें, या प्रस्तुति में फ़ॉन्ट को [एम्बेड](/slides/hi/nodejs-java/embedded-font/) करें।

**क्या एक पैराग्राफ कई प्रूफिंग भाषाओं का उपयोग कर सकता है?**

हां। प्रत्येक भाषा को एक अलग हिस्से में असाइन करें, जैसा कि बहुभाषी पैराग्राफ उदाहरण में दिखाया गया है।

**मुझे `setDefaultTextLanguage` या `setLanguageId` में से कौन‑सा उपयोग करना चाहिए?**

जब आप नए बनाए गए टेक्स्ट के लिए डिफ़ॉल्ट सेट करना चाहते हैं तो [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) उपयोग करें। जब किसी विशिष्ट हिस्से को स्पष्ट प्रूफिंग भाषा चाहिए या पैराग्राफ में कई भाषाएँ हों, तो [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) उपयोग करें।