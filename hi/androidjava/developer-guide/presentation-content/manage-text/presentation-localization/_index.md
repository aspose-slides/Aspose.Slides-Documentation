---
title: ऑन्ड्रॉइड पर प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/androidjava/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- वर्तनी जांच को दबाएं
- प्रूफिंग भाषा
- भाषा आईडी
- बहुभाषी पाठ
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android पर Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुति पाठ के लिए प्रूफिंग भाषाएँ सेट करें, जिसमें डिफ़ॉल्ट और बहुभाषी पैराग्राफ शामिल हैं।"
---
## **सारांश**

Aspose.Slides for Android via Java आपको व्यक्तिगत टेक्स्ट पोर्शन के लिए प्रूफिंग मेटाडाटा कॉन्फ़िगर करने देता है। उपयोग करें [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ताकि प्रूफिंग भाषा की पहचान की जा सके, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) ताकि वर्तनी जांच को अनुमति दी जा सके या रोक सकें, और [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) ताकि व्यापक “प्रूफ न करें” स्थिति को नियंत्रित किया जा सके। क्योंकि ये सेटिंग्स पोर्शन स्तर पर लागू होती हैं, एक पैराग्राफ में कई भाषाएँ और विभिन्न प्रूफिंग नियम हो सकते हैं।

यह लेख बताता है कि कैसे विशिष्ट टेक्स्ट को एक भाषा सौंपें, [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) के साथ नए टेक्स्ट के लिए डिफ़ॉल्ट भाषा सेट करें, बहुभाषी पैराग्राफ बनाएं, `SpellCheck` और `ProofDisabled` में से चयन करें, और [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) का उपयोग करते समय इच्छित सेटिंग्स को सुरक्षित रखें। यह प्रॉपर्टीज़ प्रेज़ेंटेशन एप्लिकेशन के लिए मेटाडाटा संग्रहीत करती हैं; ये टेक्स्ट का अनुवाद नहीं करतीं, शब्दकोश-आधारित वर्तनी जांच नहीं चलातीं, या गलत शब्दों की सूची नहीं लौटातीं।

## **टेक्स्ट के लिए प्रूफिंग भाषा सेट करें**

एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) बनाएं या लोड करें, आवश्यक टेक्स्ट पोर्शन को [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से एक्सेस करें, और उसकी भाषा पहचानकर्ता असाइन करें। निम्नलिखित उदाहरण एक शेप बनाता है, ब्रिटिश अंग्रेज़ी को प्रूफिंग भाषा के रूप में सेट करता है, और परिणाम को [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) के साथ सहेजता है:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **नए टेक्स्ट के लिए डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके वह प्रूफिंग भाषा निर्दिष्ट करें जो Aspose.Slides नए बनाए गए टेक्स्ट को असाइन करता है। यह सेटिंग तब उपयोगी होती है जब प्रस्तुति में अधिकांश या सभी नया टेक्स्ट समान भाषा का उपयोग करता है। यह उन टेक्स्ट की भाषा मेटाडाटा को नहीं बदलती जिनके पास पहले से ही स्पष्ट भाषा है।

निम्नलिखित उदाहरण एक प्रस्तुति बनाता है जिसमें नया टेक्स्ट जर्मन प्रूफिंग नियमों का उपयोग करता है:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक पैराग्राफ में कई भाषाओं का उपयोग करें**

[IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) में टेक्स्ट पोर्शन का एक संग्रह होता है। प्रत्येक भाषा के लिए एक अलग [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/portion/) बनाएं और उसका `LanguageId` स्वतंत्र रूप से सेट करें।

यह उदाहरण अंग्रेज़ी और फ्रेंच पोर्शन के साथ एक पैराग्राफ बनाता है:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **व्यक्तिगत पोर्शन के लिए वर्तनी जांच को सक्षम या निष्क्रिय करें**

[IPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformat/) [IBasePortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/) द्वारा परिभाषित सामान्य टेक्स्ट प्रॉपर्टीज़ को विरासत में लेता है। किसी पोर्शन के फॉर्मेट को [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से एक्सेस करें और [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) का उपयोग करके नियंत्रित करें कि प्रस्तुति एप्लिकेशन उस पोर्शन के लिए वर्तनी जांच कर सकता है या नहीं। डिफ़ॉल्ट मूल्य `false` है: `true` वर्तनी जांच की अनुमति देता है, जबकि `false` इसे निष्क्रिय करता है।

यह सेटिंग व्यक्तिगत टेक्स्ट पोर्शन पर लागू होती है। समान पैराग्राफ में अलग-अलग पोर्शन इसलिए विभिन्न मानों का उपयोग कर सकते हैं। [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) और `setSpellCheck` परस्परपूरक उद्देश्यों की सेवा करते हैं: `setLanguageId` प्रूफिंग भाषा की पहचान करता है, जबकि `setSpellCheck` निर्धारित करता है कि पोर्शन के लिए वर्तनी जांच की अनुमति है या नहीं।

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) भी प्रूफिंग को नियंत्रित करता है, लेकिन यह व्यापक “प्रूफ न करें” स्थिति को एक [NullableBool](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/nullablebool/) के रूप में दर्शाता है। जब आपको विशेष रूप से वर्तनी जांच के लिए सीधा Boolean स्विच चाहिए हो तो `setSpellCheck` उपयोग करें। जब आपको प्रस्तुति के “नो-प्रूफ” मेटाडाटा को संरक्षित या स्पष्ट रूप से नियंत्रित करने की आवश्यकता हो, जिसमें उसका `NotDefined` स्थिति शामिल है, तो `setProofDisabled` उपयोग करें। यदि आप दोनों प्रॉपर्टीज़ सेट करते हैं, तो उनके मान संगत रखें; `setSpellCheck(true)` को `setProofDisabled(NullableBool.True)` के साथ मिलाकर उपयोग न करें।

ये प्रॉपर्टीज़ PowerPoint और अन्य प्रस्तुति एप्लिकेशन द्वारा उपयोग किए जाने वाले प्रूफ़िंग मेटाडाटा को कॉन्फ़िगर करती हैं। Aspose.Slides इनका उपयोग शब्दकोश-आधारित वर्तनी जांच चलाने या गलत शब्दों की सूची लौटाने के लिए नहीं करती।

निम्नलिखित पूर्ण उदाहरण एक इनपुट प्रस्तुति बनाता है, उसे लोड करता है, समान पैराग्राफ में दो पोर्शन को विभिन्न वर्तनी जांच सेटिंग्स और प्रूफिंग भाषाएं असाइन करता है, परिणाम को सहेजता है, फिर से खोलता है, और संग्रहीत मानों की पुष्टि करता है:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) समान फ़ॉर्मेट वाले क्रमिक पोर्शन को मिलाता है। केवल `SpellCheck` में अंतर होने से ऐसे पोर्शन अलग नहीं रहते; जब वे जुड़ जाते हैं, तो परिणामी पोर्शन पहले पोर्शन का `SpellCheck` मान रखता है। यदि पोर्शन को अलग वर्तनी जांच सेटिंग्स चाहिए, तो इन सेटिंग्स को असाइन करने से पहले `joinPortionsWithSameFormatting` को कॉल करें, या परिणामी पोर्शन की सीमाओं की निरीक्षण करें और बाद में सेटिंग्स फिर से लागू करें। विभिन्न `LanguageId` मानों वाले पोर्शन अलग रहते हैं क्योंकि उनकी प्रूफिंग-भाषा फ़ॉर्मेटिंग अलग होती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा ID टेक्स्ट का अनुवाद करती है?**

नहीं। [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) वर्तनी और व्याकरण के लिए प्रूफिंग मेटाडाटा संग्रहीत करता है; यह टेक्स्ट सामग्री को नहीं बदलता। टेक्स्ट को अलग से अनुवाद करें, और फिर प्रत्येक अनूदित पोर्शन के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफिंग भाषा फॉन्ट्स, हाइफनेशन या लाइन रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता केवल प्रूफिंग के लिए है। टेक्स्ट रेंडरिंग और लेआउट मुख्यतः उपलब्ध [fonts](/slides/hi/androidjava/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट-फ़्रेम सेटिंग्स पर निर्भर करता है। विश्वसनीय रेंडरिंग के लिए, आवश्यक फॉन्ट्स प्रदान करें, [font substitution](/slides/hi/androidjava/font-substitution/) को कॉन्फ़िगर करें, या प्रस्तुति में [embed fonts](/slides/hi/androidjava/embedded-font/) करें।

**क्या एक पैराग्राफ कई प्रूफिंग भाषाओं का उपयोग कर सकता है?**

हां। प्रत्येक भाषा को एक अलग पोर्शन में असाइन करें, जैसा कि बहुभाषी पैराग्राफ उदाहरण में दिखाया गया है।

**क्या मुझे `setDefaultTextLanguage` या `setLanguageId` का उपयोग करना चाहिए?**

नए बनाए गए टेक्स्ट के लिए डिफ़ॉल्ट चाहिए हो तो [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करें। जब किसी विशेष पोर्शन को स्पष्ट प्रूफिंग भाषा चाहिए हो या जब पैराग्राफ में कई भाषाएँ हों तो [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) का उपयोग करें।