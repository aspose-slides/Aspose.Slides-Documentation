---
title: Java में प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/java/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- वर्तनी जांच दमन
- प्रूफिंग भाषा
- भाषा आईडी
- बहुप्रभाषी पाठ
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java में Aspose.Slides के साथ PowerPoint और OpenDocument प्रस्तुति पाठ के लिए प्रूफिंग भाषाएँ सेट करें, जिसमें डिफ़ॉल्ट और बहुप्रभाषी पैराग्राफ शामिल हैं।"
---
## **अवलोकन**

Aspose.Slides for Java आपको व्यक्तिगत टेक्स्ट भागों के लिए प्रूफिंग मेटाडाटा कॉन्फ़िगर करने की अनुमति देता है। उपयोग करें [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) प्रूफिंग भाषा पहचानने के लिए, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) वर्तनी जांच को अनुमति देने या दमन करने के लिए, और [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) व्यापक “no‑proof” स्थिति को नियंत्रित करने के लिए। चूँकि ये सेटिंग्स भाग स्तर पर लागू होती हैं, एक पैराग्राफ में कई भाषाएँ और विभिन्न प्रूफिंग नियम हो सकते हैं।

यह लेख बताता है कि विशिष्ट टेक्स्ट को भाषा कैसे असाइन करें, नई टेक्स्ट के लिए डिफ़ॉल्ट भाषा कैसे सेट करें [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करके, बहुभाषी पैराग्राफ कैसे बनाएँ, `SpellCheck` और `ProofDisabled` के बीच कैसे चुनें, और [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) का उपयोग करते समय इच्छित सेटिंग्स कैसे संरक्षित रखें। ये प्रॉपर्टी प्रेजेंटेशन अनुप्रयोगों के लिए मेटाडाटा संग्रहीत करती हैं; ये टेक्स्ट का अनुवाद नहीं करतीं, शब्दकोश‑आधारित वर्तनी जांच नहीं करतीं, या गलत लिखे शब्दों की सूची नहीं वापस करतीं।

## **टेक्स्ट के लिए प्रूफिंग भाषा सेट करें**

एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) बनाएँ या लोड करें, आवश्यक टेक्स्ट भाग को [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#getPortionFormat--) के माध्यम से एक्सेस करें, और उसकी भाषा पहचानकर्ता असाइन करें। निम्न उदाहरण एक शैप बनाता है, ब्रिटिश अंग्रेज़ी को प्रूफिंग भाषा के रूप में सेट करता है, और परिणाम को [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) से सहेजता है:

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

नए टेक्स्ट के लिए वह प्रूफिंग भाषा निर्दिष्ट करने के लिए [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) का उपयोग करें जो Aspose.Slides स्वचालित रूप से असाइन करता है। यह सेटिंग तब उपयोगी है जब प्रेज़ेंटेशन में अधिकांश या सभी नया टेक्स्ट एक ही भाषा में हो। यह उस टेक्स्ट की भाषा मेटाडाटा को नहीं बदलती जिनमें पहले से स्पष्ट भाषा निर्धारित है।

निम्न उदाहरण एक प्रेज़ेंटेशन बनाता है जहाँ नया टेक्स्ट जर्मन प्रूफिंग नियमों का उपयोग करता है:

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

एक [IParagraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iparagraph/) में टेक्स्ट भागों का संग्रह होता है। प्रत्येक भाषा के लिए अलग [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/portion/) बनाएँ और उसका `LanguageId` स्वतंत्र रूप से सेट करें।

यह उदाहरण अंग्रेजी और फ्रेंच भागों के साथ एक पैराग्राफ बनाता है:

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

## **व्यक्तिगत भागों के लिए स्पेल चेक को सक्षम या दमन करें**

[IPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportionformat/) [IBasePortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/) द्वारा परिभाषित सामान्य टेक्स्ट प्रॉपर्टी को विरासत में प्राप्त करता है। एक भाग के फॉर्मेट को [IPortion.getPortionFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iportion/#getPortionFormat--) से एक्सेस करें और [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) का उपयोग करके निर्धारित करें कि प्रेज़ेंटेशन ऐप्लिकेशन उस भाग की वर्तनी जांच कर सकता है या नहीं। डिफ़ॉल्ट मान `false` है: `true` वर्तनी जांच की अनुमति देता है, जबकि `false` इसे दमन करता है।

यह सेटिंग व्यक्तिगत टेक्स्ट भागों पर लागू होती है। उसी पैराग्राफ के विभिन्न भाग इसलिए अलग‑अलग मानों का उपयोग कर सकते हैं। [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) और `setSpellCheck` पूरक उद्देश्य रखते हैं: `setLanguageId` प्रूफिंग भाषा को पहचानता है, जबकि `setSpellCheck` निर्धारित करता है कि उस भाग के लिए वर्तनी जांच की अनुमति है या नहीं।

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) भी प्रूफिंग को नियंत्रित करता है, लेकिन यह एक [NullableBool](https://reference.aspose.com/slides/hi/java/com.aspose.slides/nullablebool/) के रूप में व्यापक “do not proof” स्थिति को दर्शाता है। जब आपको केवल वर्तनी जांच के लिए सीधे Boolean स्विच चाहिए, तो `setSpellCheck` उपयोग करें। जब आपको प्रेज़ेंटेशन की “no‑proof” मेटाडाटा, जिसमें `NotDefined` स्थिति भी शामिल है, को संरक्षित या स्पष्ट रूप से नियंत्रित करने की आवश्यकता हो, तो `setProofDisabled` उपयोग करें। यदि आप दोनों प्रॉपर्टी सेट करते हैं, तो उनके मानों को सुसंगत रखें; `setSpellCheck(true)` को `setProofDisabled(NullableBool.True)` के साथ न मिलाएँ।

ये प्रॉपर्टी PowerPoint और अन्य प्रेज़ेंटेशन ऐप्लिकेशन द्वारा उपयोग किए जाने वाले प्रूफिंग मेटाडाटा को कॉन्फ़िगर करती हैं। Aspose.Slides उनका उपयोग शब्दकोश‑आधारित वर्तनी जांच चलाने या गलत लिखे शब्दों की सूची लौटाने के लिए नहीं करती।

निम्न पूर्ण उदाहरण एक इनपुट प्रेज़ेंटेशन बनाता है, उसे लोड करता है, समान पैराग्राफ के दो भागों को विभिन्न स्पेल‑चेक सेटिंग्स और प्रूफिंग भाषाएँ असाइन करता है, परिणाम सहेजता है, उसे पुनः खोलता है, और संग्रहीत मानों को सत्यापित करता है:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) समान फॉर्मेटिंग वाले आसन्न भागों को मिलाता है। केवल `SpellCheck` में अंतर होने से ऐसे भाग अलग नहीं रहते; जब वे जुड़ जाते हैं, तो परिणामी भाग पहले भाग का `SpellCheck` मान रखता है। यदि भागों को विभिन्न स्पेल‑चेक सेटिंग्स की आवश्यकता है, तो उन सेटिंग्स को असाइन करने से पहले `joinPortionsWithSameFormatting` को कॉल करें, या परिणामी भाग की सीमा की जाँच करके बाद में सेटिंग्स पुनः लागू करें। अलग `LanguageId` मान वाले भाग अलग रहते हैं क्योंकि उनका प्रूफिंग‑भाषा फॉर्मेट अलग होता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा ID टेक्स्ट का अनुवाद करती है?**

नहीं। [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) वर्तनी और व्याकरण के लिए प्रूफिंग मेटाडाटा संग्रहीत करती है; यह टेक्स्ट की सामग्री नहीं बदलती। टेक्स्ट को अलग से अनुवाद करें, फिर प्रत्येक अनूदित भाग के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफिंग भाषा फ़ॉन्ट, हाइफ़नेशन या लाइन रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता प्रूफिंग के लिए है। टेक्स्ट रेंडरिंग और लेआउट मुख्यतः उपलब्ध [fonts](/slides/hi/java/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट‑फ़्रेम सेटिंग्स पर निर्भर करता है। विश्वसनीय रेंडरिंग के लिए आवश्यक फ़ॉन्ट प्रदान करें, [font substitution](/slides/hi/java/font-substitution/) कॉन्फ़िगर करें, या प्रेज़ेंटेशन में [embed fonts](/slides/hi/java/embedded-font/) करें।

**क्या एक पैराग्राफ कई प्रूफिंग भाषाएँ उपयोग कर सकता है?**

हां। प्रत्येक भाषा को अलग भाग में असाइन करें, जैसा कि बहुभाषी पैराग्राफ उदाहरण में दिखाया गया है।

**मुझे `setDefaultTextLanguage` या `setLanguageId` में से कौन सा उपयोग करना चाहिए?**

जब आप नए बनाए गए टेक्स्ट के लिए डिफ़ॉल्ट चाहते हैं, तब [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) उपयोग करें। जब किसी विशिष्ट भाग को स्पष्ट प्रूफिंग भाषा की आवश्यकता हो या पैराग्राफ में कई भाषाएँ हों, तब [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) उपयोग करें।