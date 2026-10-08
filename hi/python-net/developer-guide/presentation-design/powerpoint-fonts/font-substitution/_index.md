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
description: "PowerPoint और OpenDocument प्रस्तुतियों को रेंडर या कनवर्ट करते समय .NET के माध्यम से Python के लिए Aspose.Slides में फ़ॉन्ट प्रतिस्थापन नियम कॉन्फ़िगर करें और प्रतिस्थापित फ़ॉन्ट्स की जाँच करें।"
---
## **अवलोकन**

Font substitution Aspose.Slides को प्रस्तुति को रेंडर या परिवर्तित करते समय किसी अनुपलब्ध फ़ॉन्ट के स्थान पर उपलब्ध फ़ॉन्ट का उपयोग करने देता है। प्रतिस्थापन रेंडर किए गए आउटपुट को प्रभावित करता है; यह प्रस्तुति की सामग्री को सौंपे गए फ़ॉन्ट को नहीं बदलता।

आप एक विशेष फ़ॉन्ट उपलब्ध न होने पर उपयोग करने के लिए फ़ॉन्ट निर्धारित कर सकते हैं, और आप Aspose.Slides द्वारा रेंडरिंग के दौरान किए जाने वाले प्रतिस्थापनों की जाँच कर सकते हैं। यह विभिन्न स्थापित फ़ॉन्ट वाले परिवेशों में आउटपुट को सुसंगत रखने में मदद करता है।

यदि कोई फ़ॉन्ट उपलब्ध है लेकिन उसका समर्पित बॉल्ड टाइपफ़ेस नहीं है, तो देखें [समर्पित बॉल्ड टाइपफ़ेस के बिना फ़ॉन्ट को संभालना](/slides/hi/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)। वह अनुभाग PDF निर्यात के दौरान प्रभावित पाठ को रास्टराइज़ करने और पाठ चयन, खोज, तथा स्केलेशन पर उसके परिणामों को समझाता है।

## **फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

Use the [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

The following Python example lists all font substitutions for a presentation:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **चयनित स्लाइड्स के लिए फ़ॉन्ट प्रतिस्थापन प्राप्त करें**

Use [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The list contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection is zero-based, so that same slide is accessed as `presentation.slides[0]`. Keep this difference in mind when building the list to avoid off-by-one errors.

Call the method through the [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) property. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment, configured fallback rules, substitution rules stored in an [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), and [externally loaded fonts](/slides/hi/python-net/custom-font/).

The same substitution can be required by more than one selected slide. Deduplicate the results when you create a font inventory or preflight report. The following example reports every returned substitution and then creates a sorted list of unique font mappings:

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

The [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) class provides both forms of the method. Choose one according to the scope of the rendering operation:

| मेथड कॉल | कब उपयोग करें |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) कोई आर्ग्यूमेंट नहीं | आपको पूरी प्रस्तुति के लिए प्रतिस्थापन चाहिए। |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) स्लाइड सूचकांकों की सूची के साथ | आपको चयनित रेंज, क्रमिक जाँच, या भागिक निर्यात के लिए प्रतिस्थापन चाहिए। |

## **फ़ॉन्ट प्रतिस्थापन नियम निर्धारित करें**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.  
2. Create font definitions for the source and substitute fonts.  
3. Create a [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) को [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) स्थिति के साथ बनाएँ।  
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).  
5. Assign the collection to the [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) प्रॉपर्टी को असाइन करें।  
6. Render or convert the presentation.

The following Python example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

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
फ़ॉन्ट्स में एक शर्तरहित परिवर्तन के लिए, देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/python-net/font-replacement/)।
{{% /alert %}}

## **गणित समीकरण फ़ॉन्ट्स के लिए सीमाएँ**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [external font](/slides/hi/python-net/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट रिप्लेसमेंट और फ़ॉन्ट प्रतिस्थापन में क्या अंतर है?**  
[Font replacement](/slides/hi/python-net/font-replacement/) प्रस्तुति के पूरे भाग में एक फ़ॉन्ट को दूसरे से जानबूझकर बदलता है। फ़ॉन्ट प्रतिस्थापन तब रेंडर किए गए आउटपुट के लिए फ़ॉन्ट चुनता है जब निर्धारित शर्त पूरी होती है, जैसे कि मूल फ़ॉन्ट अनुपलब्ध हो।

**प्रतिस्थापन नियम कब लागू होते हैं?**  
The rules participate in the [font selection sequence](/slides/hi/python-net/font-selection-sequence/) during rendering and conversion. With `WHEN_INACCESSIBLE`, a rule is used only when Aspose.Slides cannot access the source font.

**जब फ़ॉन्ट गायब हो और कोई प्रतिस्थापन नियम कॉन्फ़िगर न हो तो क्या होता है?**  
Aspose.Slides फ़ॉन्ट चयन प्रक्रिया के अनुसार सबसे नज़दीकी उपलब्ध फ़ॉन्ट चुनता है। परिणाम रनटाइम पर्यावरण में उपलब्ध फ़ॉन्ट्स पर निर्भर करता है।

**क्या मैं प्रतिस्थापन से बचने के लिए बाहरी फ़ॉन्ट लोड कर सकता हूँ?**  
हाँ। आप [load external fonts](/slides/hi/python-net/custom-font/) कर सकते हैं ताकि Aspose.Slides रेंडरिंग और परिवर्तनों के दौरान उनका उपयोग कर सके।

**क्या Aspose लाइब्रेरी के साथ फ़ॉन्ट वितरित करता है?**  
नहीं। फ़ॉन्ट प्रदान करना और उनके लाइसेंस का पालन करना आपकी ज़िम्मेदारी है।

**क्या प्रतिस्थापन परिणाम Windows, Linux और macOS के बीच अलग हो सकते हैं?**  
हाँ। स्थापित फ़ॉन्ट और फ़ॉन्ट खोज स्थान ऑपरेटिंग सिस्टम पर निर्भर करते हैं, इसलिए एक मशीन पर उपलब्ध फ़ॉन्ट दूसरी पर प्रतिस्थापन की आवश्यकता पैदा कर सकता है।

**बैच रूपांतरण में फ़ॉन्ट चयन को सुसंगत कैसे रखें?**  
हर मशीन या कंटेनर पर वही फ़ॉन्ट फ़ाइलें और संस्करण उपयोग करें, [load required external fonts](/slides/hi/python-net/custom-font/) और [embed fonts](/slides/hi/python-net/embedded-font/) लाइसेंस की अनुमति के साथ करें। आप निर्यात से पहले [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) को कॉल करके अप्रत्याशित प्रतिस्थापन पहचान सकते हैं।