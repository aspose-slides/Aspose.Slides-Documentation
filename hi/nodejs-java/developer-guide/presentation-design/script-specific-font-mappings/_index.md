---
title: JavaScript में स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट्स का प्रबंधन
linktitle: स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट्स
type: docs
weight: 15
url: /hi/nodejs-java/script-specific-font-mappings/
keywords:
- स्क्रिप्ट-विशिष्ट फ़ॉन्ट
- थीम फ़ॉन्ट मैपिंग
- बहुभाषी प्रस्तुति
- लेखन प्रणाली
- सायरिलिक फ़ॉन्ट
- अरबी फ़ॉन्ट
- जापानी फ़ॉन्ट
- जॉर्जियन फ़ॉन्ट
- थााना फ़ॉन्ट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint थीम में Aspose.Slides for Node.js के साथ स्क्रिप्ट-विशिष्ट फ़ॉन्ट मैपिंग्स की जाँच, जोड़ना, बदलना और हटाना।"
---
## **सारांश**

एक प्रस्तुति थीम विभिन्न लेखन प्रणालियों के लिए विभिन्न फ़ॉन्ट फ़ैमिलियों का चयन कर सकती है। यह बहुभाषी पाठ को, जो अभी भी थीम फ़ॉन्ट का उपयोग करता है, एक समन्वित फ़ॉन्ट योजना का पालन करने की अनुमति देता है, जबकि सायरिलिक, अरबी, जापानी, जॉर्जियन, थाना और अन्य लिपियों के लिए उपयुक्त फ़ॉन्ट का उपयोग करता है।

थीम का [FontScheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) एक प्रमुख फ़ॉन्ट संग्रह रखता है, जो आमतौर पर शीर्षकों के लिए उपयोग किया जाता है, और एक गौण फ़ॉन्ट संग्रह, जो आमतौर पर मुख्य पाठ के लिए उपयोग किया जाता है। उनके लैटिन और ईशान्य एशियन फ़ॉन्ट सेटिंग्स के अतिरिक्त, दोनों संग्रह लेखन‑प्रणाली टैग से फ़ॉन्ट फ़ैमिली नामों के बीच मैपिंग को [Fonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/) क्लास के माध्यम से उजागर करते हैं।

यह लेख दिखाता है कि प्रस्तुतिची मास्टर थीम में उन मैपिंग्स की जाँच और संशोधन कैसे किया जाए और यह सत्यापित किया जाए कि परिवर्तन सहेजने‑और‑पुनः‑लोड करने के चक्र में टिके रहें।

## **स्क्रिप्ट टैग समझें**

स्क्रिप्ट फ़ॉन्ट मेथड्स लिखन प्रणाली की पहचान के लिए चार-अक्षरीय BCP 47 स्क्रिप्ट सबटैग्स का उपयोग करती हैं। सामान्य मानों में शामिल हैं:

| स्क्रिप्ट टैग | लेखन प्रणाली |
|---|---|
| `Cyrl` | सायरिलिक |
| `Arab` | अरबी |
| `Hans` | सरलीकृत चीनी |
| `Jpan` | जापानी |
| `Geor` | जॉर्जियन |
| `Thaa` | थाना |

ये मैपिंग्स थीम फ़ॉन्ट योजना से संबंधित हैं, व्यक्तिगत टेक्स्ट भागों से नहीं। एक प्रस्तुति प्रमुख और गौण संग्रहों के लिए अलग‑अलग मैपिंग्स परिभाषित कर सकती है, और कुछ स्क्रिप्ट्स के लिए मैपिंग्स को छोड़ सकती है।

## **स्क्रिप्ट फ़ॉन्ट मैपिंग्स तक पहुँचें और निरीक्षण करें**

प्रेजेंटेशन‑लेवल थीम तक पहुँचने के लिए [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) का उपयोग करें। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontscheme/) मेथड्स दो [Fonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/) संग्रहों को लौटाते हैं।

`[Fonts.getScriptFontMap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/)` को कॉल करके आप किसी संग्रह से सभी मैपिंग्स प्राप्त कर सकते हैं। एक लेखन प्रणाली को देखना हो तो `[Fonts.getScriptFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/)` को उसके स्क्रिप्ट टैग के साथ कॉल करें। `getScriptFont` `null` लौटाता है जब उस संग्रह में अनुरोधित मैपिंग परिभाषित नहीं होती है।

## **मैपिंग्स में संशोधन करें और स्थायित्व सत्यापित करें**

मैपिंग बनाने या वर्तमान फ़ॉन्ट फ़ैमिली को बदलने के लिए [Fonts.setScriptFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/) का उपयोग करें। मैपिंग हटाने के लिए [Fonts.removeScriptFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/) का उपयोग करें।

निम्नलिखित एंड‑टू‑एंड उदाहरण सभी मौजूदा प्रमुख और गौण मैपिंग्स को पढ़ता है, जापानी प्रमुख फ़ॉन्ट को देखता है, सायरिलिक प्रमुख फ़ॉन्ट को बदलता है, थाना गौण मैपिंग को हटाता है, प्रस्तुति को सहेजता है, और दोनों परिवर्तन सत्यापित करने के लिए इसे पुनः खोलता है। हटाने के चरण को प्रारंभिक थीम से स्वतंत्र बनाने के लिए, उदाहरण पहले केवल तब थाना मैपिंग बनाता है जब वह पहले से परिभाषित न हो।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

सत्यापन समान `null` व्यवहार का उपयोग करता है जैसा कि सामान्य लुकअप में होता है: हटाना सहेजने के बाद, `getScriptFont("Thaa")` गौण संग्रह के लिए `null` लौटाता है।

## **थीम मैपिंग्स को अन्य फ़ॉन्ट सेटिंग्स से अलग करें**

स्क्रिप्ट‑विशिष्ट थीम मैपिंग्स फ़ॉन्ट चयन में भाग लेती हैं, लेकिन वे सीधे टेक्स्ट फ़ॉर्मेटिंग, सब्स्टिट्यूशन और फॉलबैक की तुलना में अलग समस्या हल करती हैं:

| मैकेनिज्म | उद्देश्य | थीम मैपिंग बदलने का प्रभाव |
|---|---|---|
| स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट मैपिंग | लेखन प्रणाली के लिए एक प्रमुख या गौण थीम फ़ॉन्ट चुनता है। | जो टेक्स्ट अभी भी संबंधित थीम फ़ॉन्ट का उपयोग करता है, वह नई मैप्ड फ़ैमिली में हल हो सकता है। |
| टेक्स्ट हिस्से को स्पष्ट रूप से असाइन किया गया फ़ॉन्ट | थीम पर निर्भर रहने के बजाय उस हिस्से पर अनुरोधित फ़ॉन्ट फ़ैमिली को फिक्स करता है। | हिस्से में सीधे फ़ॉर्मेटिंग के कारण थीम चयन को ओवरराइड करने से यह बिना बदले रह सकता है। |
| फ़ॉन्ट प्रतिस्थापन | जब अनुरोधित फ़ॉन्ट उपलब्ध नहीं होता या कोई प्रतिस्थापन नियम लागू हो तब उसे बदल देता है। | यह फ़ॉन्ट अनुरोध के बाद काम करता है; यह थीम की स्क्रिप्ट मैपिंग को पुनः परिभाषित नहीं करता। |
| फ़ॉन्ट फ़ॉलबैक | चुने हुए फ़ॉन्ट में न मौजूद ग्लाइफ़ प्रदान करता है, अक्सर विशिष्ट यूनिकोड रेंज के लिए। | यह गायब ग्लाइफ़ को भरता है; यह संग्रहीत थीम मैपिंग को नहीं बदलता। |

अंतिम दो मैकेनिज्म्स के बारे में अधिक जानकारी के लिए देखें [Font Substitution](/slides/hi/nodejs-java/font-substitution/) और [Fallback Fonts](/slides/hi/nodejs-java/fallback-font/)।

[Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getmastertheme/) में मैपिंग बदलने से केवल वही कंटेंट प्रभावित होता है जिसका प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम पर निर्भर है। टेक्स्ट एक मास्टर, लेआउट, या स्लाइड से थीम ओवरराइड को विरासत में ले सकता है, या स्पष्ट रूप से असाइन किए हुए फ़ॉन्ट का उपयोग कर सकता है। जब दृश्य परिणाम प्रेजेंटेशन‑लेवल मैपिंग का पालन नहीं करता, तो इन स्तरों की जाँच करें।

## **मैप्ड फ़ॉन्ट्स उपलब्ध कराएँ और परिणाम सत्यापित करें**

एक स्क्रिप्ट मैपिंग फ़ॉन्ट फ़ैमिली नाम संग्रहीत करती है; यह संबंधित फ़ॉन्ट फ़ाइल को इंस्टॉल या लोड नहीं करती। सुसंगत रेंडरिंग और निर्यात के लिए, प्रत्येक मैप्ड फ़ॉन्ट को पर्यावरण में स्थापित होना चाहिए या Aspose.Slides को एक कस्टम स्रोत जैसे [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) या [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) के माध्यम से प्रदान किया जाना चाहिए। उपलब्ध लोडिंग विकल्पों के लिए देखें [Custom Fonts](/slides/hi/nodejs-java/custom-font/)।

सहेजी गई मैपिंग को सत्यापित करने से केवल यह पुष्टि होती है कि थीम परिभाषा संरक्षित रही। यह यह सिद्ध नहीं करता कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक ग्लाइफ़्स शामिल हैं, या इच्छित लेआउट उत्पन्न करता है। प्रत्येक आवश्यक लेखन प्रणाली के लिए प्रतिनिधिक टेक्स्ट को इमेज या PDF में रेंडर करें और आउटपुट का निरीक्षण करें। इससे प्रस्तुति वितरित करने से पहले गायब फ़ॉन्ट्स, अधूरी ग्लाइफ़ कवरेज, फ़ॉलबैक व्यवहार और लेआउट परिवर्तन पकड़े जा सकते हैं। रेंडरिंग और निर्यात उदाहरणों के लिए देखें [Convert PowerPoint Presentations](/slides/hi/nodejs-java/convert-powerpoint/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब कोई स्क्रिप्ट मैप नहीं होती तो `getScriptFont` क्या लौटाता है?**  
[Fonts.getScriptFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/) `null` लौटाता है जब अनुरोधित स्क्रिप्ट मैपिंग उस प्रमुख या गौण फ़ॉन्ट संग्रह में परिभाषित नहीं होती।

**क्या `setScriptFont` स्क्रिप्ट पहले से मौजूद होने पर दूसरा मैपिंग जोड़ता है?**  
नहीं। [Fonts.setScriptFont](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fonts/) मैपिंग बनाता है जब वह अनुपस्थित हो और जब समान स्क्रिप्ट टैग पहले से मौजूद हो तो मैप्ड फ़ॉन्ट फ़ैमिली को बदल देता है।

**कुछ टेक्स्ट में थीम मैपिंग बदलने के बावजूद परिवर्तन क्यों नहीं दिखा?**  
टेक्स्ट में स्पष्ट रूप से असाइन किया गया फ़ॉन्ट हो सकता है, एक ओवरराइड के माध्यम से अलग थीम को विरासत में ले सकता है, या रेंडरिंग के दौरान प्रतिस्थापन या फ़ॉलबैक से प्रभावित हो सकता है। एक प्रेजेंटेशन‑लेवल स्क्रिप्ट मैपिंग केवल उसी टेक्स्ट को नियंत्रित करती है जिसका प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट संग्रह की ओर इशारा करता है।

**क्या सहेजना और पुनः खोलना बहुभाषी आउटपुट को मान्य करने के लिए पर्याप्त है?**  
नहीं। पुनः खोलना थीम डेटा की स्थायित्व को सत्यापित करता है। साथ ही प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधिक टेक्स्ट को रेंडर करके यह पुष्टि करें कि मैप्ड फ़ॉन्ट उपलब्ध हैं और आवश्यक ग्लाइफ़्स शामिल हैं।