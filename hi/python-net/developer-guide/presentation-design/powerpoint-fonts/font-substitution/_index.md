---
title: Python के साथ प्रस्तुतियों में फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें
linktitle: फ़ॉन्ट प्रतिस्थापन
type: docs
weight: 70
url: /hi/python-net/font-substitution/
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
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या रूपांतरित करते समय .NET के माध्यम से Python के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्टों की जाँच करें।"
---
## **परिचय**

फ़ॉन्ट प्रतिस्थापन Aspose.Slides को प्रस्तुति को रेंडर या रूपांतरित करते समय उपलब्ध फ़ॉन्ट को उपयोग करने की अनुमति देता है जब मूल फ़ॉन्ट तक पहुँच नहीं पा रहे हों। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप एक विशिष्ट फ़ॉन्ट अनुपलब्ध होने पर उपयोग करने वाले फ़ॉन्ट को परिभाषित कर सकते हैं, और आप रेंडरिंग के दौरान Aspose.Slides द्वारा किए जाने वाले प्रतिस्थापनों की जाँच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले वातावरणों में आउटपुट को सुसंगत रखने में मदद करता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

प्रस्तुति रेंडर होने पर कौन‑से फ़ॉन्ट प्रतिस्थापित किए जाएंगे, यह निर्धारित करने के लिए [FontsManager.get_substitutions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_substitutions/) मेथड का उपयोग करें। यह मेथड [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsubstitutioninfo/) वस्तुएँ लौटाता है जो मूल और प्रतिस्थापित फ़ॉन्ट नामों की पहचान करती हैं।

निम्नलिखित Python उदाहरण प्रस्तुति के सभी फ़ॉन्ट प्रतिस्थापन को सूचीबद्ध करता है:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **चयनित स्लाइडों के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

विशिष्ट स्लाइडों को रेंडर करने के लिए आवश्यक केवल प्रतिस्थापनों को जाँचने हेतु [FontsManager.get_substitutions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_substitutions/) को स्लाइड अनुक्रमों की सूची के साथ उपयोग करें। यह उपयोगी है जब आप प्रस्तुति का कोई भाग रेंडर या निर्यात कर रहे हों, बड़े प्रस्तुति को क्रमिक रूप से जांच रहे हों, ऐसे स्लाइडों को खोज रहे हों जो अनुपलब्ध फ़ॉन्ट पर निर्भर हों, सर्वर या कंटेनर के लिए न्यूनतम फ़ॉन्ट पैकेज तैयार कर रहे हों, या गैर‑संबंधित स्लाइडों को प्रोसेस किए बिना रेंडरिंग अंतर का निदान करना चाहते हों।

सूची में एक‑आधारित स्लाइड अनुक्रम होते हैं: `1` पहला स्लाइड दर्शाता है। इसके विपरीत, [Presentation.slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) संग्रह शून्य‑आधारित है, इसलिए वही स्लाइड `presentation.slides[0]` के रूप में पहुँचा जाता है। इस अंतर को सूची बनाते समय ध्यान में रखें ताकि ऑफ‑बाय‑वन त्रुटियों से बचा जा सके।

मेथड को [Presentation.fonts_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/fonts_manager/) प्रॉपर्टी के माध्यम से कॉल करें। यह केवल चयनित स्लाइडों को रेंडर करने के दौरान निर्धारित प्रतिस्थापन लौटाता है। प्रत्येक परिणाम एक [FontSubstitutionInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsubstitutioninfo/) वस्तु है जिसमें मूल और प्रतिस्थापित फ़ॉन्ट नाम शामिल होते हैं। परिणाम वर्तमान फ़ॉन्ट वातावरण, कॉन्फ़िगर किए गए फ़ॉलबैक नियम, एक [IFontSubstRuleCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifontsubstrulecollection/) में संग्रहीत प्रतिस्थापन नियम, और [बाहरी रूप से लोड किए गए फ़ॉन्ट](/slides/hi/python-net/custom-font/) को प्रतिबिंबित करता है।

एक ही प्रतिस्थापन कई चयनित स्लाइडों द्वारा आवश्यक हो सकता है। फ़ॉन्ट इन्वेंटरी या प्री‑फ़्लाइट रिपोर्ट बनाते समय परिणामों को डिडुप्लिकेट करें। निम्नलिखित उदाहरण प्रत्येक लौटाए गए प्रतिस्थापन को रिपोर्ट करता है और फिर अद्वितीय फ़ॉन्ट मैपिंग की क्रमबद्ध सूची बनाता है:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

[FontsManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/) क्लास मेथड के दोनों रूप प्रदान करता है। रेंडरिंग ऑपरेशन के दायरे के अनुसार एक चुनें:

| मेथड कॉल | कब उपयोग करें |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_substitutions/) बिना तर्कों के | आपको पूरे प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [get_substitutions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_substitutions/) स्लाइड अनुक्रमों की सूची के साथ | आपको चयनित रेंज, क्रमिक जांच, या भागीय निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम सेट करें**

जब स्रोत फ़ॉन्ट अनुपलब्ध हो, तब Aspose.Slides को कौन‑सा फ़ॉन्ट उपयोग करना चाहिए, इसे निर्दिष्ट करने के लिए:

1. प्रस्तुति लोड करें।  
2. स्रोत और प्रतिस्थापन फ़ॉन्ट के लिए फ़ॉन्ट परिभाषाएँ बनाएँ।  
3. [FontSubstRule](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsubstrule/) को [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsubstcondition/) शर्त के साथ बनाएँ।  
4. नियम को एक [FontSubstRuleCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsubstrulecollection/) में जोड़ें।  
5. संग्रह को [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) प्रॉपर्टी को असाइन करें।  
6. प्रस्तुति को रेंडर या रूपांतरित करें।

निम्नलिखित Python उदाहरण `SomeRareFont` अनुपलब्ध होने पर `Arial` को प्रतिस्थापित करता है, और फिर परिणाम की पुष्टि के लिए पहला स्लाइड रेंडर करता है। प्रतिस्थापन फ़ॉन्ट Aspose.Slides के लिए उपलब्ध होना चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
पूरी प्रस्तुति में उपयोग किए जाने वाले फ़ॉन्ट को बिना शर्त बदलने के लिए, देखें [Font Replacement](/slides/hi/python-net/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्टों के लिए सीमाएं**

फ़ॉन्ट प्रतिस्थापन नियम रेंडरिंग और रूपांतरण के दौरान उपयोग की जाने वाली मानक फ़ॉन्ट चयन प्रक्रिया का हिस्सा हैं। वे सामान्य टेक्स्ट के लिए काम करते हैं जब Aspose.Slides एक अनुपलब्ध फ़ॉन्ट को नियम द्वारा निर्दिष्ट उपलब्ध फ़ॉन्ट से बदल सकता है।

Office Math समीकरणों में अतिरिक्त आवश्यकता होती है। यदि किसी समीकरण में **Cambria Math** उपयोग किया गया है, तो समीकरण लेआउट की गणना और रेंडर करने के लिए Aspose.Slides को उसी फ़ॉन्ट की आवश्यकता हो सकती है। कोई भी नियम जो किसी अन्य गणित फ़ॉन्ट, जैसे **STIX Two Math**, को प्रतिस्थापित करता है, वह इस उद्देश्य के लिए **Cambria Math** को बदल नहीं सकता, और रेंडरिंग अभी भी रिपोर्ट कर सकती है कि **Cambria Math** आवश्यक है।

ऐसी प्रस्तुति को रेंडर या रूपांतरित करने के लिए, **Cambria Math** को Aspose.Slides के लिए उपलब्ध कराएँ। इसे ऑपरेटिंग सिस्टम में स्थापित करें या एक [बाहरी फ़ॉन्ट](/slides/hi/python-net/custom-font/) के रूप में लोड करें।

यह सीमा समीकरण लेआउट पर लागू होती है। ऊपर वर्णित प्रतिस्थापन नियम सामान्य प्रस्तुति टेक्स्ट पर अभी भी लागू होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट प्रतिस्थापन और फ़ॉन्ट प्रतिस्थापन (substitution) में क्या अंतर है?**

[Font replacement](/slides/hi/python-net/font-replacement/) प्रस्तुति में एक फ़ॉन्ट को पूरे दस्तावेज़ में दूसरे फ़ॉन्ट से जानबूझकर बदलता है। फ़ॉन्ट प्रतिस्थापन रेंडर किए गए आउटपुट के लिए एक फ़ॉन्ट चुनता है जब कॉन्फ़िगर की गई शर्त पूरी होती है, जैसे मूल फ़ॉन्ट अनुपलब्ध हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**

नियम रेंडरिंग और रूपांतरण के दौरान [फ़ॉन्ट चयन अनुक्रम](/slides/hi/python-net/font-selection-sequence/) में भाग लेते हैं। `WHEN_INACCESSIBLE` के साथ, नियम केवल तब उपयोग होता है जब Aspose.Slides स्रोत फ़ॉन्ट तक पहुँच नहीं पाता।

**जब फ़ॉन्ट अनुपलब्ध हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**

Aspose.Slides अपने फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे नज़दीकी उपलब्ध फ़ॉन्ट चुनता है। परिणाम रन‑टाइम वातावरण में उपलब्ध फ़ॉन्ट पर निर्भर करता है।

**क्या मैं बाहरी फ़ॉन्ट लोड करके प्रतिस्थापन से बच सकता हूँ?**

हाँ। आप [बाहरी फ़ॉन्ट लोड](/slides/hi/python-net/custom-font/) कर सकते हैं ताकि Aspose.Slides उन्हें रेंडरिंग और रूपांतरण के दौरान उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**

नहीं। फ़ॉन्ट प्रदान करने और उनके लाइसेंस का पालन करने की जिम्मेदारी आपके ऊपर है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS में अलग हो सकते हैं?**

हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम के अनुसार भिन्न होते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरी पर प्रतिस्थापन की आवश्यकता बना सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे रखें?**

प्रत्येक मशीन या कंटेनर पर समान फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, [आवश्यक बाहरी फ़ॉन्ट लोड](/slides/hi/python-net/custom-font/) करें, और लाइसेंस अनुमति होने पर [फ़ॉन्ट एम्बेड](/slides/hi/python-net/embedded-font/) करें। निर्यात से पहले अप्रत्याशित प्रतिस्थापनों की पहचान के लिए आप [FontsManager.get_substitutions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_substitutions/) भी कॉल कर सकते हैं।