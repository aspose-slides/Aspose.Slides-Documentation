---
title: प्रेजेंटेशन में Python के माध्यम से Java का उपयोग करके फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/python-java/font-substitution/
keywords:
- फ़ॉन्ट
- प्रतिस्थापित फ़ॉन्ट
- फ़ॉन्ट प्रतिस्थापन
- फ़ॉन्ट बदलें
- फ़ॉन्ट प्रतिस्थापन
- प्रतिस्थापन नियम
- बदलाव नियम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय Python के माध्यम से Java में Aspose.Slides के लिए फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स की जांच करें।"
---
## **सारांश**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को उपलब्ध फ़ॉन्ट को उस फ़ॉन्ट के स्थान पर उपयोग करने की अनुमति देता है जो प्रस्तुति रेंडर या रूपांतरण के दौरान पहुँच योग्य नहीं है। यह प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति की सामग्री में निर्दिष्ट फ़ॉन्ट को नहीं बदलता है।

आप किसी विशिष्ट फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और आप रेंडरिंग के दौरान Aspose.Slides द्वारा किए जाने वाले प्रतिस्थापनों का निरीक्षण कर सकते हैं। इससे विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट सुसंगत रहता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

फ़ॉन्ट प्रतिस्थापन निर्धारित करने के लिए जब प्रस्तुति रेंडर की जाती है, आप [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getSubstitutions) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट्स लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करते हैं।

निम्नलिखित Python उदाहरण प्रस्तुति के लिए सभी फ़ॉन्ट प्रतिस्थापन सूचीबद्ध करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **चयनित स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

निर्दिष्ट स्लाइड्स को रेंडर करने के लिए आवश्यक प्रतिस्थापनों को केवल निरीक्षण करने हेतु आप [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getSubstitutions) को Java पूर्णांक एरे तर्क के साथ उपयोग कर सकते हैं। यह तब उपयोगी है जब आप प्रस्तुति के एक भाग को रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुति को क्रमिक रूप से जाँच रहे हों, ऐसी स्लाइड्स को खोज रहे हों जिनके लिए अनुपलब्ध फ़ॉन्ट की आवश्यकता है, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या अनासक्त स्लाइड्स को प्रोसेस किए बिना रेंडरिंग अंतर का निदान कर रहे हों।

`slides` एरे में एक-आधारित स्लाइड सूचकांक होते हैं: `1` पहली स्लाइड को दर्शाता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) संग्रह अभिगम शून्य-आधारित अनुक्रमणिका का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` के रूप में पहुँचा जाता है। एरे बनाते समय इस अंतर को ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

आप इस ओवरलोड को [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getFontsManager) मेथड के माध्यम से कॉल करें। यह केवल चयनित स्लाइड्स को रेंडर करते समय निर्धारित प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट पर्यावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [बाहरी रूप से लोड किए गए फ़ॉन्ट](/slides/hi/python-java/custom-font/) को दर्शाता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइड्स के लिए आवश्यक हो सकता है। जब आप फ़ॉन्ट इनवेंटरी या प्री‑फ़्लाइट रिपोर्ट बनाते हैं तो परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अनूठी फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/) क्लास दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | कब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getSubstitutions) बिना तर्क के | जब आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getSubstitutions) Java पूर्णांक एरे के साथ | जब आपको चयनित रेंज, क्रमिक जाँच, या भागीय निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम निर्धारित करें**

जब स्रोत फ़ॉन्ट उपलब्ध न हो तो Aspose.Slides को कौन सा फ़ॉन्ट उपयोग करना चाहिए, इसे निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएं।
3. एक [FontSubstRule](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsubstrule/) को [WhenInaccessible](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) शर्त के साथ बनाएं।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) मेथड का उपयोग करके असाइन करें।
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित Python उदाहरण `SomeRareFont` के अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम सत्यापित करने के लिए पहली स्लाइड को रेंडर करता है। प्रतिस्थापन फ़ॉन्ट को Aspose.Slides के लिए उपलब्ध होना चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
पूरी प्रस्तुति में उपयोग किए गए फ़ॉन्ट को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/python-java/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट के लिए सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग किए जाने वाले मानक फ़ॉन्ट चयन प्रक्रिया का भाग होते हैं। वे सामान्य टेक्स्ट के लिए काम करते हैं जब Aspose.Slides एक अभिगम्य नहीं फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों में अतिरिक्त आवश्यकता होती है। यदि किसी समीकरण में **Cambria Math** का उपयोग होता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडर करने के लिए वही फ़ॉन्ट आवश्यक हो सकता है। कोई नियम जो **STIX Two Math** जैसे अन्य गणित फ़ॉन्ट को प्रतिस्थापित करता है, **Cambria Math** को इस उद्देश्य के लिए नहीं बदल सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकता है कि **Cambria Math** आवश्यक है।

ऐसे प्रस्तुति को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में इंस्टॉल करें या इसे एक [बाहरी फ़ॉन्ट](/slides/hi/python-java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन नियम में क्या अंतर है?**

[Font replacement](/slides/hi/python-java/font-replacement/) पूरे प्रस्तुति में एक फ़ॉन्ट को जानबूझकर दूसरे फ़ॉन्ट से बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब कॉन्फ़िगर की गई शर्त पूरी हो, जैसे मूल फ़ॉन्ट उपलब्ध न हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**

नियम रेंडरिंग और रूपांतरण के दौरान [फ़ॉन्ट चयन अनुक्रम](/slides/hi/python-java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट गायब हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट को चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**

हाँ। आप [बाहरी फ़ॉन्ट लोड](/slides/hi/python-java/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**

हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार अलग होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरे पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को संगत कैसे बनाऊँ?**

हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, आवश्यक बाहरी फ़ॉन्ट लोड करें, और लाइसेंस की अनुमति होने पर फ़ॉन्ट एम्बेड करें। आप निर्यात से पहले अप्रत्याशित प्रतिस्थापनों की पहचान करने के लिए [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getSubstitutions) भी कॉल कर सकते हैं।