---
title: Python के माध्यम से Java का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/python-java/font-substitution/
keywords:
- फ़ॉन्ट
- प्रतिस्थापित फ़ॉन्ट
- फ़ॉन्ट प्रतिस्थापन
- फ़ॉन्ट बदलना
- फ़ॉन्ट प्रतिस्थापन
- प्रतिस्थापन नियम
- प्रतिस्थापन नियम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय Python के माध्यम से Java के द्वारा Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स की जाँच करें।
---
## **अवलोकन**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को रेंडर या रूपांतरित होते समय उस फ़ॉन्ट के स्थान पर उपलब्ध फ़ॉन्ट का उपयोग करने की अनुमति देता है जिसे एक्सेस नहीं किया जा सकता। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति की सामग्री में असाइन किए गए फ़ॉन्ट को नहीं बदलता।

आप किसी विशेष फ़ॉन्ट के अनुपलब्ध होने पर उपयोग करने के लिये फ़ॉन्ट निर्धारित कर सकते हैं, और रेंडरिंग के दौरान Aspose.Slides द्वारा किए गए प्रतिस्थापनों को देख सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत बनाए रखने में मदद करता है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसके पास समर्पित बोल्ड टाइपफ़ेस नहीं है, तो देखें [Handle Fonts Without a Dedicated Bold Typeface](/slides/hi/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग PDF निर्यात के दौरान प्रभावित पाठ को रास्टराइज़ करने और पाठ चयन, खोज और स्केलिंग पर इसके प्रभावों को समझाता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

फ़ॉन्ट प्रतिस्थापन निर्धारित करने के लिये [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) विधि का उपयोग करें जब प्रस्तुति रेंडर की जाती है। यह विधि [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट लौटाती है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करती है।

निम्नलिखित Python उदाहरण एक प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापनों की सूची देता है:

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

## **चयनित स्लाइडों के लिये फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

जावास्क्रिप्ट पूर्णांक सरणी आर्ग्युमेंट के साथ [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) ओवरलोड का उपयोग करके केवल उन स्लाइडों के लिये आवश्यक प्रतिस्थापन देख सकते हैं जिन्हें आप रेंडर करना चाहते हैं। यह तब उपयोगी है जब आप प्रस्तुति के केवल भाग को रेंडर या निर्यात कर रहे हैं, बड़े प्रस्तुति को क्रमिक रूप से जांच रहे हैं, उन स्लाइडों को ढूँढ रहे हैं जिनमें अनुपलब्ध फ़ॉन्ट पर निर्भरता है, सर्वर या कंटेनर के लिये न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हैं, या अनावश्यक स्लाइडों को प्रोसेस किए बिना रेंडरिंग अंतर का निदान कर रहे हैं।

`slides` सरणी में एक‑आधारित स्लाइड सूचकांक होते हैं: `1` पहला स्लाइड दर्शाता है। इसके विपरीत, [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) संग्रह अभिगमकर्ता शून्य‑आधारित सूचकांक का उपयोग करता है, इसलिए वही स्लाइड `presentation.getSlides().get_Item(0)` के रूप में प्राप्त होता है। सरणी बनाते समय इस अंतर को ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

ओवरलोड को [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) विधि के माध्यम से कॉल करें। यह केवल चयनित स्लाइडों के रेंडरिंग के दौरान निर्धारित प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) ऑब्जेक्ट होता है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम होते हैं। परिणाम वर्तमान फ़ॉन्ट पर्यावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, तथा [externally loaded fonts](/slides/hi/python-java/custom-font/) को दर्शाता है।

एक ही प्रतिस्थापन एक से अधिक चयनित स्लाइडों द्वारा आवश्यक हो सकता है। फ़ॉन्ट सूची या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की सॉर्टेड सूची बनाता है:

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

[FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) क्लास दोनों ओवरलोड प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| ओवरलोड | जब उपयोग करें |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) बिना किसी आर्ग्युमेंट के | आपको पूरी प्रस्तुति के लिये प्रतिस्थापन चाहिए। |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) जावा पूर्णांक सरणी के साथ | आपको चयनित रेंज, क्रमिक जाँच, या भागीय निर्यात के लिये प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट उपलब्ध न हो तो Aspose.Slides को उपयोग करने के लिये फ़ॉन्ट निर्दिष्ट करने के लिये:

1. प्रस्तुति लोड करें।
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिये फ़ॉन्ट परिभाषाएँ बनाएँ।
3. [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) शर्त के साथ एक [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) बनाएँ।
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) में जोड़ें।
5. संग्रह को [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) विधि का उपयोग करके असाइन करें।
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित Python उदाहरण `SomeRareFont` के अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर पहले स्लाइड को रेंडर करके परिणाम सत्यापित करता है। प्रतिस्थापित फ़ॉन्ट Aspose.Slides के लिये उपलब्ध होना चाहिए।

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
पूरी प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट में बिना शर्त परिवर्तन के लिये देखें [Font Replacement](/slides/hi/python-java/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट के लिये सीमाएँ**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरित करने के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे सामान्य पाठ के लिये काम करते हैं जब Aspose.Slides नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट के साथ अनुपलब्ध फ़ॉन्ट को बदल सकता है।

Office Math समीकरणों में अतिरिक्त आवश्यकता होती है। यदि कोई समीकरण **Cambria Math** का उपयोग करता है, तो Aspose.Slides को समीकरण लेआउट की गणना और रेंडरिंग के लिये वही फ़ॉन्ट चाहिए हो सकता है। कोई नियम जो **STIX Two Math** जैसे अन्य गणित फ़ॉन्ट को प्रतिस्थापित करता है, वह इस उद्देश्य के लिये **Cambria Math** को बदल नहीं सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिये, **Cambria Math** को Aspose.Slides के लिये उपलब्ध बनाएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या एक [external font](/slides/hi/python-java/custom-font/) के रूप में लोड करें।

यह सीमा केवल समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति पाठ पर अभी भी लागू होते हैं।

## **FAQ**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन के बीच क्या अंतर है?**  
[Font replacement](/slides/hi/python-java/font-replacement/) जानबूझकर प्रस्तुति में एक फ़ॉन्ट को दूसरे से बदलता है। फ़ॉन्ट प्रतिस्थापन रेंडर किए गए आउटपुट के लिये फ़ॉन्ट चुनता है जब निर्धारित शर्त पूरी होती है, जैसे मूल फ़ॉन्ट अनुपलब्ध हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**  
नियम रेंडरिंग और रूपांतरण के दौरान [font selection sequence](/slides/hi/python-java/font-selection-sequence/) में भाग लेते हैं। `WhenInaccessible` के साथ, नियम केवल तब उपयोग किया जाता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं सकता।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़़िगर न हो तो क्या होता है?**  
Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे निकटतम उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम पर्यावरण में उपलब्ध फ़ॉन्टों पर निर्भर करता है।

**क्या मैं बाहर के फ़ॉन्ट लोड करके प्रतिस्थापन से बच सकता हूँ?**  
हां। आप [load external fonts](/slides/hi/python-java/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और रूपांतरण के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**  
नहीं। फ़ॉन्ट प्रदान करना और उनके लाइसेंस का पालन करना आपका दायित्व है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**  
हां। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थितियाँ ऑपरेटिंग सिस्टम के अनुसार बदलती हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरी पर प्रतिस्थापन की आवश्यकता कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे रखें?**  
हर मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, [load required external fonts](/slides/hi/python-java/custom-font/) करें, और लाइसेंस अनुमति देती हो तो [embed fonts](/slides/hi/python-java/embedded-font/) करें। आप निर्यात से पहले अनपेक्षित प्रतिस्थापनों की पहचान के लिये [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) भी कॉल कर सकते हैं।