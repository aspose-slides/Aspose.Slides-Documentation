---
title: एंड्रॉइड पर स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट प्रबंधित करें
linktitle: स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट
type: docs
weight: 15
url: /hi/androidjava/script-specific-font-mappings/
keywords:
- स्क्रिप्ट-विशिष्ट फ़ॉन्ट
- थीम फ़ॉन्ट मैपिंग
- बहुभाषी प्रस्तुति
- लेखन प्रणाली
- सिरिलिक फ़ॉन्ट
- अरबी फ़ॉन्ट
- जापानी फ़ॉन्ट
- जॉर्जियन फ़ॉन्ट
- थाना फ़ॉन्ट
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "PowerPoint थीम में स्क्रिप्ट-विशिष्ट फ़ॉन्ट मैपिंग को जांचें, जोड़ें, बदलें और हटाएँ, Aspose.Slides के साथ Android के लिए Java के माध्यम से।"
---
## **अवलोकन**

एक प्रेजेंटेशन थीम विभिन्न लेखन प्रणालियों के लिए अलग-अलग फ़ॉन्ट परिवार चुन सकती है। यह बहुभाषी टेक्स्ट को, जो अभी भी थीम फ़ॉन्ट का उपयोग करता है, एक समान फ़ॉन्ट योजना का पालन करने की अनुमति देता है, जबकि सिरिलिक, अरबी, जापानी, जॉर्जियन, थाना और अन्य लिपियों के लिए उपयुक्त फ़ॉन्ट का उपयोग करता है।

थीम का [IFontScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/) में एक प्रमुख फ़ॉन्ट संग्रह होता है, जो आमतौर पर हेडिंग्स के लिए उपयोग किया जाता है, और एक गौण फ़ॉन्ट संग्रह होता है, जो आमतौर पर मुख्य पाठ के लिए उपयोग किया जाता है। लैटिन और ईस्ट एशियन फ़ॉन्ट सेटिंग्स के अलावा, दोनों संग्रह [IFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifonts/) इंटरफ़ेस के माध्यम से लेखन‑प्रणाली टैग्स को फ़ॉन्ट परिवार नामों से मैप करते हैं।

यह लेख दिखाता है कि प्रस्तुति के मास्टर थीम में उन मैपिंग्स को कैसे निरीक्षण और संशोधित किया जाए और यह सत्यापित किया जाए कि परिवर्तन सेव‑और‑रीलोड चक्र में भी बने रहें।

## **स्क्रिप्ट टैग्स को समझें**

स्क्रिप्ट फ़ॉन्ट मेथड्स लेखन प्रणालियों की पहचान के लिए चार-अक्षर वाले BCP 47 स्क्रिप्ट सबटैग्स का उपयोग करती हैं। सामान्य मान नीचे दिए गये हैं:

| स्क्रिप्ट टैग | लेखन प्रणाली |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

## **स्क्रिप्ट फ़ॉन्ट मैपिंग्स तक पहुँचें और निरीक्षण करें**

प्रेजेंटेशन‑लेवल थीम तक पहुँचने के लिए [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getMasterTheme--) का उपयोग करें। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/#getMajor--) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/#getMinor--) मेथड्स दो [IFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifonts/) संग्रह लौटाते हैं।

एक संग्रह से सभी मैपिंग्स प्राप्त करने के लिए [IFonts.getScriptFontMap](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) को कॉल करें। किसी एक लेखन प्रणाली को खोजने के लिए, उसके स्क्रिप्ट टैग के साथ [IFonts.getScriptFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) को कॉल करें। `getScriptFont` `null` लौटाता है जब वह संग्रह अनुरोधित मैपिंग को परिभाषित नहीं करता है।

## **मैपिंग्स को संशोधित करें और स्थायित्व सत्यापित करें**

[IFonts.setScriptFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) का उपयोग करके एक मैपिंग बनाएं या उसकी वर्तमान फ़ॉन्ट परिवार को बदलें। एक मैपिंग को हटाने के लिए [IFonts.removeScriptFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) का उपयोग करें।

निम्नलिखित एंड‑टू‑एंड उदाहरण सभी मौजूद प्रमुख और गौण मैपिंग्स को पढ़ता है, जापानी प्रमुख फ़ॉन्ट को खोजता है, सिरिलिक प्रमुख फ़ॉन्ट को बदलता है, थाना गौण मैपिंग को हटाता है, प्रस्तुति को सहेजता है, और दोनों परिवर्तनों को सत्यापित करने के लिए इसे फिर से खोलता है। हटाने के चरण को प्रारंभिक थीम से स्वतंत्र बनाने के लिए, उदाहरण पहले थाना मैपिंग केवल तब बनाता है जब वह पहले से परिभाषित न हो।

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

सत्यापन सामान्य लुकअप की समान `null` व्यवहार का उपयोग करता है: हटाने को सहेजने के बाद, `getScriptFont("Thaa")` गौण संग्रह के लिए `null` लौटाता है।

## **थीम मैपिंग्स को अन्य फ़ॉन्ट सेटिंग्स से अलग करें**

स्क्रिप्ट‑विशिष्ट थीम मैपिंग्स फ़ॉन्ट चयन में भाग लेती हैं, लेकिन वे सीधे टेक्स्ट फ़ॉर्मेटिंग, प्रतिस्थापन, और फ़ॉलबैक से अलग समस्या का समाधान करती हैं:

| तंत्र | उद्देश्य | थीम मैपिंग बदलने का प्रभाव |
|---|---|---|
| स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट मैपिंग | लेखन प्रणाली के लिए प्रमुख या गौण थीम फ़ॉन्ट चुनता है। | उस टेक्स्ट जो अभी भी संबंधित थीम फ़ॉन्ट का उपयोग करता है, नई मैप्ड फ़ॉन्ट परिवार में बदल सकता है। |
| किसी टेक्स्ट भाग को स्पष्ट रूप से असाइन किया गया फ़ॉन्ट | थीम पर निर्भर रहने के बजाय उस भाग पर अनुरोधित फ़ॉन्ट परिवार को स्थिर करता है। | भाग अपरिवर्तित रह सकता है क्योंकि उसका प्रत्यक्ष फ़ॉर्मेटिंग थीम चयन को ओवरराइड करता है। |
| फ़ॉन्ट प्रतिस्थापन | जब अनुरोधित फ़ॉन्ट उपलब्ध नहीं होता या प्रतिस्थापन नियम लागू होता है, तो फ़ॉन्ट को बदल देता है। | यह फ़ॉन्ट अनुरोधित होने के बाद कार्य करता है; यह थीम के स्क्रिप्ट मैपिंग को पुनः परिभाषित नहीं करता। |
| फ़ॉन्ट फ़ॉलबैक | चुने हुए फ़ॉन्ट में न मौजूद ग्लिफ़ प्रदान करता है, अक्सर विशिष्ट यूनिकोड रेंज के लिए। | यह गायब ग्लिफ़ कवरेज को भरता है; यह संग्रहीत थीम मैपिंग को नहीं बदलता। |

अन्तिम दो तंत्रों के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/androidjava/font-substitution/) और [Fallback Fonts](/slides/hi/androidjava/fallback-font/)।

[Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getMasterTheme--) में एक मैपिंग बदलने से केवल वही सामग्री प्रभावित होती है जिसकी प्रभावी फ़ॉर्मेटिंग अभी भी उसी थीम पर निर्भर करती है। टेक्स्ट इसके बजाय मास्टर, लेआउट, या स्लाइड से थीम ओवरराइड विरासत में ले सकता है, या स्पष्ट रूप से असाइन किए गए फ़ॉन्ट का उपयोग कर सकता है। जब दिखाया गया परिणाम प्रस्तुति‑लेवल मैपिंग का पालन नहीं करता, तो उन स्तरों की जाँच करें।

## **मैप्ड फ़ॉन्ट उपलब्ध कराएँ और परिणाम सत्यापित करें**

स्क्रिप्ट मैपिंग एक फ़ॉन्ट परिवार नाम संग्रहीत करती है; यह संबंधित फ़ॉन्ट फ़ाइल को स्थापित या लोड नहीं करती। स्थिर रेंडरिंग और एक्सपोर्ट के लिए, प्रत्येक मैप्ड फ़ॉन्ट को पर्यावरण में स्थापित होना चाहिए या Aspose.Slides को एक कस्टम स्रोत जैसे [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) या [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) के माध्यम से प्रदान किया जाना चाहिए। उपलब्ध लोडिंग विकल्पों के लिए [Custom Fonts](/slides/hi/androidjava/custom-font/) देखें।

सहेजी गई मैपिंग को सत्यापित करने से केवल यह पुष्टि होती है कि थीम परिभाषा संरक्षित रही। यह यह प्रमाणित नहीं करता कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक ग्लिफ़ शामिल हैं, या वांछित लेआउट उत्पन्न करता है। प्रत्येक आवश्यक लेखन प्रणाली के लिए प्रतिनिधि टेक्स्ट को इमेज या PDF में रेंडर करें और आउटपुट की जाँच करें। इससे प्रस्तुति वितरित करने से पहले गायब फ़ॉन्ट, अधूरी ग्लिफ़ कवरेज, फ़ॉलबैक व्यवहार, और लेआउट परिवर्तन पकड़े जाते हैं। रेंडरिंग और एक्सपोर्ट उदाहरणों के लिए देखें [Convert PowerPoint Presentations](/slides/hi/androidjava/convert-powerpoint/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब कोई स्क्रिप्ट मैप नहीं की गई हो तो `getScriptFont` क्या लौटाता है?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) `null` लौटाता है जब अनुरोधित स्क्रिप्ट मैपिंग उस प्रमुख या गौण फ़ॉन्ट संग्रह में परिभाषित नहीं होती।

**`setScriptFont` क्या वह स्क्रिप्ट पहले से मौजूद होने पर दूसरी मैपिंग जोड़ता है?**

नहीं। [IFonts.setScriptFont](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) मैपिंग बनाता है जब वह अनुपस्थित हो और जब वही स्क्रिप्ट टैग पहले से मौजूद हो तो मैप्ड फ़ॉन्ट परिवार को बदल देता है।

**थीम मैपिंग बदलने से कुछ टेक्स्ट क्यों नहीं बदला?**

टेक्स्ट में स्पष्ट रूप से असाइन किया गया फ़ॉन्ट हो सकता है, ओवरराइड के माध्यम से भिन्न थीम विरासत में ले सकता है, या रेंडरिंग के दौरान प्रतिस्थापन या फ़ॉलबैक से प्रभावित हो सकता है। प्रस्तुति‑लेवल स्क्रिप्ट मैपिंग केवल उन टेक्स्ट को नियंत्रित करती है जिनकी प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट संग्रह का संदर्भ देती है।

**क्या सहेजना और फिर खोलना बहुभाषी आउटपुट को सत्यापित करने के लिए पर्याप्त है?**

नहीं। फिर खोलना थीम डेटा की स्थायित्व को सत्यापित करता है। इसके अलावा प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधि टेक्स्ट को रेंडर करें ताकि यह पुष्टि हो सके कि मैप्ड फ़ॉन्ट उपलब्ध हैं और आवश्यक ग्लिफ़ शामिल हैं।