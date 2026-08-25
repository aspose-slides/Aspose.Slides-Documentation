---
title: जावा में स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट प्रबंधित करें
linktitle: स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट
type: docs
weight: 15
url: /hi/java/script-specific-font-mappings/
keywords:
- स्क्रिप्ट-विशिष्ट फ़ॉन्ट
- थीम फ़ॉन्ट मैपिंग
- बहु-भाषी प्रस्तुति
- लेखन प्रणाली
- सिरिलिक फ़ॉन्ट
- अरबी फ़ॉन्ट
- जापानी फ़ॉन्ट
- जॉर्जियन फ़ॉन्ट
- थाना फ़ॉन्ट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "PowerPoint थीम में स्क्रिप्ट-विशिष्ट फ़ॉन्ट मैपिंग को निरीक्षण, जोड़ना, बदलना और हटाना Aspose.Slides for Java के साथ।"
---
## **अवलोकन**

एक प्रस्तुति थीम विभिन्न लेखन प्रणालियों के लिए अलग‑अलग फ़ॉन्ट परिवार चुन सकती है। इससे ऐसी बहुभाषी पाठ्य सामग्री जो अभी भी थीम फ़ॉन्ट का उपयोग करती है, एक समन्वित फ़ॉन्ट योजना का पालन करती है और साथ ही सिरिलिक, अरबी, जापानी, जॉर्जियन, थाना और अन्य लिपियों के लिए उपयुक्त फ़ॉन्ट उपयोग करती है।

थीम का [IFontScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/) आमतौर पर हेडिंग्स के लिए उपयोग होने वाले प्रमुख फ़ॉन्ट संग्रह और बॉडी टेक्स्ट के लिए उपयोग होने वाले गौण फ़ॉन्ट संग्रह को सम्मिलित करता है। लैटिन एवं ईस्ट एशियन फ़ॉन्ट सेटिंग्स के अतिरिक्त, दोनों संग्रह लिखने‑प्रणाली टैग से फ़ॉन्ट परिवार नामों तक का मानचित्रण प्रदान करते हैं जो [IFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifonts/) इंटरफ़ेस के माध्यम से उपलब्ध है।

यह लेख बताता है कि प्रस्तुति के मास्टर थीम में इन मानचित्रणों को कैसे जांचें और संशोधित करें तथा यह पुष्टि कैसे करें कि परिवर्तन सहेजने‑और‑पुनः‑लोड करने के बाद भी बना रहता है।

## **स्क्रिप्ट टैग समझें**

स्क्रिप्ट फ़ॉन्ट मेथड्स लेखन प्रणालियों की पहचान के लिए चार‑अक्षरीय BCP 47 स्क्रिप्ट उप‑टैग का उपयोग करते हैं। सामान्य मान इस प्रकार हैं:

| स्क्रिप्ट टैग | लेखन प्रणाली |
|---|---|
| `Cyrl` | सिरिलिक |
| `Arab` | अरबी |
| `Hans` | सरलीकृत चीनी |
| `Jpan` | जापानी |
| `Geor` | जॉर्जियन |
| `Thaa` | थाना |

ये मानचित्रण थीम फ़ॉन्ट योजना के होते हैं, न कि व्यक्तिगत टेक्स्ट हिस्सों के। एक प्रस्तुति प्रमुख एवं गौण दोनों संग्रहों के लिए अलग‑अलग मानचित्रण परिभाषित कर सकती है, और कुछ लिपियों के लिए मानचित्रण छोड़ भी सकती है।

## **स्क्रिप्ट फ़ॉन्ट मानचित्रण तक पहुँचना और जाँचना**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getMasterTheme--) का उपयोग करके प्रस्तुति‑स्तर की थीम प्राप्त करें। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/#getMajor--) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/#getMinor--) मेथड्स दोनो [IFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifonts/) संग्रह लौटाते हैं।

किसी संग्रह से सभी मानचित्रण प्राप्त करने के लिये [IFonts.getScriptFontMap](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fonts/#getScriptFontMap--) को कॉल करें। किसी एक लेखन प्रणाली को देखना हो तो उसके स्क्रिप्ट टैग के साथ [IFonts.getScriptFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) को कॉल करें। `getScriptFont` तब `null` लौटाता है जब वह संग्रह अनुरोधित मानचित्रण को परिभाषित नहीं करता।

## **मानचित्रण बदलें और स्थायित्व सत्यापित करें**

एक मानचित्रण बनाते या वर्तमान फ़ॉन्ट परिवार को बदलते समय [IFonts.setScriptFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) का प्रयोग करें। किसी मानचित्रण को हटाने के लिये [IFonts.removeScriptFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) का उपयोग करें।

निम्नलिखित अंत‑से‑अंत उदाहरण सभी मौजूदा प्रमुख एवं गौण मानचित्रण को पढ़ता है, जापानी प्रमुख फ़ॉन्ट को देखता है, सिरिलिक प्रमुख फ़ॉन्ट को बदलता है, थाना गौण मानचित्रण को हटाता है, प्रस्तुति को सहेजता है, और फिर दोनों परिवर्तन सत्यापित करने के लिये फिर से खोलता है। हटाने के चरण को प्रारम्भिक थीम से स्वतंत्र बनाने हेतु, उदाहरण केवल तभी थानाअ मानचित्रण बनाता है जब वह पहले से परिभाषित नहीं होता।

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

सत्यापन समान `null` व्यवहार का उपयोग करता है जैसा कि सामान्य लुक‑अप में होता है: हटाने के बाद सहेजे जाने पर `getScriptFont("Thaa")` गौण संग्रह के लिये `null` लौटाता है।

## **थीम मानचित्रण को अन्य फ़ॉन्ट सेटिंग्स से अलग पहचानें**

स्क्रिप्ट‑विशिष्ट थीम मानचित्रण फ़ॉन्ट चयन में भाग लेते हैं, पर वे सीधे टेक्स्ट फ़ॉर्मेटिंग, प्रतिस्थापन और फ़ॉलबैक के समस्या से अलग होते हैं:

| तंत्र | उद्देश्य | थीम मैपिंग बदलने का प्रभाव |
|---|---|---|
| Script-specific theme font mapping | एक लेखन प्रणाली के लिये प्रमुख या गौण थीम फ़ॉन्ट चुनता है। | संबंधित थीम फ़ॉन्ट अभी भी उपयोग करने वाले टेक्स्ट को नया मैप किया गया परिवार प्राप्त हो सकता है। |
| Font assigned explicitly to a text portion | उस हिस्से पर सीधे फ़ॉन्ट परिवार फिक्स कर देता है, बजाय थीम पर निर्भर रहने के। | सीधे फ़ॉर्मेटिंग थीम चयन को ओवरराइड कर सकती है, इसलिए परिवर्तन नहीं दिखेगा। |
| Font substitution | जब अनुरोधित फ़ॉन्ट उपलब्ध नहीं होता या प्रतिस्थापन नियम लागू होता है, तो फ़ॉन्ट बदल देता है। | यह फ़ॉन्ट अनुरोध के बाद कार्य करता है; यह थीम के स्क्रिप्ट मानचित्रण को पुनः परिभाषित नहीं करता। |
| Font fallback | चयनित फ़ॉन्ट में न मौजूद glyphs को अन्य फ़ॉन्ट से प्रदान करता है, अक्सर विशिष्ट Unicode रेंज के लिये। | यह गायब glyph कवरेज को भरता है; यह संग्रहित थीम मानचित्रण को नहीं बदलता। |

इन दो तंत्रों के बारे में अधिक जानकारी के लिये देखें [Font Substitution](/slides/hi/java/font-substitution/) और [Fallback Fonts](/slides/hi/java/fallback-font/)।

[Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getMasterTheme--) में मानचित्रण बदलने से केवल वही सामग्री प्रभावित होती है जो अभी भी प्रभावी फ़ॉर्मेटिंग के माध्यम से उस थीम पर निर्भर है। टेक्स्ट मास्टर, लेआउट या स्लाइड से ओवरराइड थीम विरासत में ले सकता है, या स्पष्ट रूप से असाइन किया गया फ़ॉन्ट उपयोग कर सकता है। जब दृश्यमान परिणाम प्रस्तुति‑स्तर के मानचित्रण से मेल नहीं खाता, तब इन स्तरों को भी जांचें।

## **मैप्ड फ़ॉन्ट उपलब्ध कराएँ और परिणाम सत्यापित करें**

एक स्क्रिप्ट मानचित्र केवल फ़ॉन्ट परिवार नाम संग्रहीत करता है; यह सम्बंधित फ़ॉन्ट फ़ाइल को स्थापित या लोड नहीं करता। सुसंगत रेंडरिंग और निर्यात के लिये, प्रत्येक मैप्ड फ़ॉन्ट को वातावरण में स्थापित होना चाहिए या Aspose.Slides को किसी कस्टम स्रोत के द्वारा प्रदान किया जाना चाहिए, जैसे कि [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) या [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--)। उपलब्ध लोडिंग विकल्पों के लिये देखें [Custom Fonts](/slides/hi/java/custom-font/)।

सहेजे गए मानचित्रण की पुष्टि केवल यह सिद्ध करती है कि थीम परिभाषा संरक्षित रही। यह यह नहीं सिद्ध करती कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक glyphs रखता है, या इच्छित लेआउट उत्पन्न करता है। प्रत्येक आवश्यक लेखन प्रणाली के लिये प्रतिनिधि टेक्स्ट को इमेज या PDF में रेंडर करें और आउटपुट निरीक्षण करें। यह गायब फ़ॉन्ट, अधूरी glyph कवरेज, फ़ॉलबैक व्यवहार, तथा लेआउट परिवर्तन को प्रस्तुति वितरण से पहले पकड़ता है। रेंडरिंग और निर्यात उदाहरणों के लिये देखें [Convert PowerPoint Presentations](/slides/hi/java/convert-powerpoint/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब कोई स्क्रिप्ट मैप नहीं किया गया हो तो `getScriptFont` क्या लौटाता है?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) `null` लौटाता है जब अनुरोधित स्क्रिप्ट मानचित्रण उस प्रमुख या गौण फ़ॉन्ट संग्रह में परिभाषित नहीं है।

**क्या `setScriptFont` मौजूदा स्क्रिप्ट के लिये दूसरा मानचित्रण जोड़ता है?**

नहीं। [IFonts.setScriptFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) तब मानचित्रण बनाता है जब वह अनुपस्थित हो और वही स्क्रिप्ट टैग पहले से मौजूद होने पर मौजूदा फ़ॉन्ट परिवार को बदलता है।

**थीम मानचित्रण बदलने से कुछ टेक्स्ट क्यों नहीं बदला?**

टेक्स्ट के पास स्पष्ट रूप से असाइन किया गया फ़ॉन्ट हो सकता है, वह ओवरराइड के द्वारा किसी अलग थीम को विरासत में ले सकता है, या रेंडरिंग के समय प्रतिस्थापन या फ़ॉलबैक से प्रभावित हो सकता है। प्रस्तुति‑स्तर का स्क्रिप्ट मानचित्रण केवल उन टेक्स्ट पर प्रभाव डालता है जिनकी प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट संग्रह को संदर्भित करती है।

**क्या मल्टी‑लिंगुअल आउटपुट सत्यापित करने के लिये केवल सहेजना‑और‑पुनः‑खोलना पर्याप्त है?**

नहीं। पुनः‑खोलना केवल थीम डेटा की स्थायित्व की पुष्टि करता है। प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधि टेक्स्ट को रेंडर करके यह भी सत्यापित करना आवश्यक है कि मैप्ड फ़ॉन्ट उपलब्ध हैं और आवश्यक glyphs रखते हैं।