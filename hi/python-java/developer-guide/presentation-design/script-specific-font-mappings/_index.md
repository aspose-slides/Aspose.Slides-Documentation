---
title: Python के माध्यम से Java में स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट प्रबंधित करें
linktitle: स्क्रिप्ट-विशिष्ट थीम फ़ॉन्ट
type: docs
weight: 15
url: /hi/python-java/script-specific-font-mappings/
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
- Python
- Java
- Aspose.Slides
description: "PowerPoint थीम में स्क्रिप्ट-विशिष्ट फ़ॉन्ट मैपिंग को निरीक्षण, जोड़ना, बदलना और हटाना Aspose.Slides के साथ Python के लिए Java के माध्यम से।"
---
## **सारांश**

एक प्रस्तुति थीम विभिन्न लेखन प्रणालियों के लिए अलग-अलग फ़ॉन्ट फ़ैमिली चुन सकती है। यह बहुभाषी पाठ को, जो अभी भी थीम फ़ॉन्ट का उपयोग करता है, एक समन्वित फ़ॉन्ट स्कीम का पालन करने की अनुमति देता है, जबकि सिरिलिक, अरबी, जापानी, जॉर्जियन, थाना और अन्य लिपियों के लिए उपयुक्त फ़ॉन्ट का उपयोग करता है।

थीम का [FontScheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontscheme/) मुख्य फ़ॉन्ट संग्रह शामिल करता है, जिसे आमतौर पर शीर्षकों के लिए उपयोग किया जाता है, और एक गौण फ़ॉन्ट संग्रह, जिसे आमतौर पर मुख्य पाठ के लिए उपयोग किया जाता है। उनके लैटिन और ईस्ट एशियन फ़ॉन्ट सेटिंग्स के अतिरिक्त, दोनों संग्रह [Fonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/) क्लास के माध्यम से लेखन‑प्रणाली टैग को फ़ॉन्ट फ़ैमिली नामों से मैपिंग प्रदर्शित करते हैं।

यह लेख दर्शाता है कि प्रस्तुति के मास्टर थीम में इन मैपिंग्स की जांच और संशोधन कैसे किया जाए और यह सत्यापित किया जाए कि परिवर्तन सहेजने‑और‑पुनःलोड करने के चक्र में टिके रहें।

## **स्क्रिप्ट टैग को समझें**

स्क्रिप्ट फ़ॉन्ट विधियाँ लेखन प्रणालियों की पहचान के लिए चार‑अक्षरीय BCP 47 स्क्रिप्ट सबटैग का उपयोग करती हैं। सामान्य मानों में शामिल हैं:

| स्क्रिप्ट टैग | लेखन प्रणाली |
|---|---|
| `Cyrl` | सिरिलिक |
| `Arab` | अरबी |
| `Hans` | सरलीकृत चीनी |
| `Jpan` | जापानी |
| `Geor` | जॉर्जियन |
| `Thaa` | थाना |

## **स्क्रिप्ट फ़ॉन्ट मैपिंग तक पहुँच और निरीक्षण**

[Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasterTheme) का उपयोग करके प्रस्तुति‑स्तर की थीम तक पहुँचा जा सकता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontscheme/#getMajor) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontscheme/#getMinor) विधियाँ दो [Fonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/) संग्रह लौटाती हैं।

[Fonts.getScriptFontMap](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/#getScriptFontMap) को कॉल करके किसी संग्रह से सभी मैपिंग्स प्राप्त की जा सकती हैं। एक लेखन प्रणाली को खोजने के लिए, उसके स्क्रिप्ट टैग के साथ [Fonts.getScriptFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/#getScriptFont) को कॉल करें। `getScriptFont` तब `None` लौटाता है जब वह संग्रह अनुरोधित मैपिंग को परिभाषित नहीं करता।

## **मैपिंग संशोधित करें और निरंतरता सत्यापित करें**

[Fonts.setScriptFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/#setScriptFont) का उपयोग करके एक मैपिंग बनाई जा सकती है या उसकी वर्तमान फ़ॉन्ट फ़ैमिली को बदल सकते हैं। मैपिंग हटाने के लिए [Fonts.removeScriptFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/#removeScriptFont) का उपयोग करें।

निम्नलिखित अंत‑से‑अंत उदाहरण सभी मौजूदा प्रमुख और गौण मैपिंग्स को पढ़ता है, जापानी प्रमुख फ़ॉन्ट को खोजता है, सिरिलिक प्रमुख फ़ॉन्ट को बदलता है, थाना गौण मैपिंग को हटाता है, प्रस्तुति को सहेजता है, और दोनों परिवर्तनों को सत्यापित करने के लिए पुनः खोलता है। हटाने चरण को प्रारंभिक थीम से स्वतंत्र बनाने के लिए, उदाहरण पहले केवल तब थाना मैपिंग बनाता है जब वह पहले से परिभाषित न हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

सत्यापन एक सामान्य खोज की तरह ही `None` व्यवहार का उपयोग करता है: हटाने के सहेजने के बाद, `getScriptFont("Thaa")` गौण संग्रह के लिए `None` लौटाता है।

## **थीम मैपिंग को अन्य फ़ॉन्ट सेटिंग्स से अलग करें**

स्क्रिप्ट‑विशिष्ट थीम मैपिंग फ़ॉन्ट चयन में भाग लेती हैं, लेकिन वे सीधे टेक्स्ट फ़ॉर्मेटिंग, प्रतिस्थापन और फ़ॉलबैक की समस्या से अलग हल करती हैं:

| तंत्र | उद्देश्य | थीम मैपिंग बदलने का प्रभाव |
|---|---|---|
| स्क्रिप्ट‑विशिष्ट थीम फ़ॉन्ट मैपिंग | लेखन प्रणाली के लिए प्रमुख या गौण थीम फ़ॉन्ट चुनता है। | जो पाठ अभी भी संबंधित थीम फ़ॉन्ट का उपयोग करता है, वह नई मैप्ड फ़ैमिली में बदल सकता है। |
| टेक्स्ट भाग को स्पष्ट रूप से असाइन किया गया फ़ॉन्ट | थीम पर निर्भर रहने के बजाय उस भाग में अनुरोधित फ़ॉन्ट फ़ैमिली को निश्चित करता है। | भाग अपरिवर्तित रह सकता है क्योंकि उसकी प्रत्यक्ष फ़ॉर्मेटिंग थीम चयन को ओवरराइड करती है। |
| फ़ॉन्ट प्रतिस्थापन | जब फ़ॉन्ट उपलब्ध नहीं होता या कोई प्रतिस्थापन नियम लागू होता है, तो अनुरोधित फ़ॉन्ट को बदलता है। | यह फ़ॉन्ट अनुरोध के बाद कार्य करता है; यह थीम की स्क्रिप्ट मैपिंग को पुनः परिभाषित नहीं करता। |
| फ़ॉन्ट फ़ॉलबैक | चुने गए फ़ॉन्ट में न मौजूद glyphs प्रदान करता है, अक्सर विशिष्ट Unicode रेंज के लिए। | यह लापता glyph कवरेज को भरता है; यह संग्रहित थीम मैपिंग को नहीं बदलता। |

अंतिम दो तंत्रों के बारे में अधिक जानकारी के लिए देखें [Font Substitution](/slides/hi/python-java/font-substitution/) और [Fallback Fonts](/slides/hi/python-java/fallback-font/)।

[Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasterTheme) में मैपिंग बदलने से केवल वही सामग्री प्रभावित होती है जिसकी प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम पर निर्भर करती है। टेक्स्ट एक मास्टर, लेआउट या स्लाइड से थीम ओवरराइड विरासत में ले सकता है, या स्पष्ट रूप से असाइन किया गया फ़ॉन्ट उपयोग कर सकता है। जब प्रदर्शित परिणाम प्रस्तुति‑स्तर की मैपिंग का पालन नहीं करता, तो उन स्तरों की जांच करें।

## **मैप्ड फ़ॉन्ट उपलब्ध कराएँ और परिणाम मान्य करें**

स्क्रिप्ट मैपिंग फ़ॉन्ट फ़ैमिली नाम संग्रहीत करती है; यह संबंधित फ़ॉन्ट फ़ाइल को स्थापित या लोड नहीं करती। स्थिर रेंडरिंग और निर्यात के लिए, प्रत्येक मैप्ड फ़ॉन्ट को वातावरण में स्थापित होना चाहिए या Aspose.Slides को एक कस्टम स्रोत जैसे [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#loadExternalFonts) या [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) के माध्यम से देना चाहिए। उपलब्ध लोडिंग विकल्पों के लिए देखें [Custom Fonts](/slides/hi/python-java/custom-font/)।

सहेजी गई मैपिंग का सत्यापन केवल यह पुष्टि करता है कि थीम परिभाषा संरक्षित रही। यह यह सिद्ध नहीं करता कि फ़ॉन्ट उपलब्ध है, सभी आवश्यक glyphs शामिल हैं, या इच्छित लेआउट बनाता है। प्रत्येक आवश्यक लेखन प्रणाली के प्रतिनिधि पाठ को छवि या PDF में रेंडर करें और आउटपुट की जाँच करें। इससे अनुपलब्ध फ़ॉन्ट, अधूरी glyph कवरेज, फ़ॉलबैक व्यवहार, और प्रस्तुति के वितरण से पहले लेआउट परिवर्तन पकड़े जा सकते हैं। रेंडरिंग और निर्यात उदाहरणों के लिए देखें [Convert PowerPoint Presentations](/slides/hi/python-java/convert-powerpoint/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब कोई स्क्रिप्ट मैप नहीं होती तो `getScriptFont` क्या लौटाता है?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/#getScriptFont) तब `None` लौटाता है जब अनुरोधित स्क्रिप्ट मैपिंग उस प्रमुख या गौण फ़ॉन्ट संग्रह में परिभाषित नहीं होती।

**क्या `setScriptFont` स्क्रिप्ट पहले से मौजूद होने पर दूसरी मैपिंग जोड़ता है?**

नहीं। [Fonts.setScriptFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fonts/#setScriptFont) उस समय मैपिंग बनाता है जब वह अनुपस्थित हो और जब वही स्क्रिप्ट टैग पहले से मौजूद हो तो मैप्ड फ़ॉन्ट फ़ैमिली को बदल देता है।

**क्यों थीम मैपिंग बदलने से कुछ पाठ नहीं बदला?**

पाठ में स्पष्ट रूप से असाइन किया गया फ़ॉन्ट हो सकता है, ओवरराइड के माध्यम से अलग थीम विरासत में ले सकता है, या रेंडरिंग के दौरान प्रतिस्थापन या फ़ॉलबैक से प्रभावित हो सकता है। प्रस्तुति‑स्तर की स्क्रिप्ट मैपिंग केवल उन पाठों को नियंत्रित करती है जिनकी प्रभावी फ़ॉर्मेटिंग अभी भी उस थीम फ़ॉन्ट संग्रह की ओर संकेत करती है।

**क्या सहेजना और पुनः खोलना बहुभाषी आउटपुट को मान्य करने के लिए पर्याप्त है?**

नहीं। पुनः खोलना थीम डेटा की निरंतरता की पुष्टि करता है। साथ ही प्रत्येक आवश्यक लेखन प्रणाली से प्रतिनिधि पाठ को रेंडर करें यह सुनिश्चित करने के लिए कि मैप्ड फ़ॉन्ट उपलब्ध हैं और आवश्यक glyphs शामिल हैं।