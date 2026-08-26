---
title: PowerPoint प्रस्तुति थीम को Python में प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/python-net/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुति थीम
- स्लाइड थीम
- थीम सेट करना
- थीम बदलना
- थीम प्रबंधन
- बाहरी थीम
- THMX
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के लिए Python में .NET के माध्यम से प्रमुख प्रस्तुति थीम, ताकि स्थिर ब्रांडिंग के साथ PowerPoint फ़ाइलें बनाई, अनुकूलित और परिवर्तित की जा सकें।"
---
## **परिचय**

एक प्रस्तुति थीम रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, फ़िल, रेखाएँ और प्रभावों का समन्वित सेट परिभाषित करती है। थीम-सेवी ऑब्जेक्ट इन साझा परिभाषाओं को संदर्भित करते हैं बजाय प्रत्येक दृश्य गुण को स्थायी मान के रूप में संग्रहीत करने के, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) संपत्ति के माध्यम से उपलब्ध है। एक प्रस्तुति निचले स्तरों पर थीम ओवरराइड भी रख सकती है। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/masterthememanager/override_theme/) के माध्यम से ओवरराइड कर सकता है, एक लेआउट अपने विरासत में मिली थीम को [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) के माध्यम से ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी ऐसा ही कर सकती है। व्यावहारिक रूप से, किसी स्लाइड के लिए प्रभावी थीम इस विरासत शृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत एवं ओवरराइड के बाद प्रभावी मानों को पढ़ना।

## **थीम निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [color_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/font_scheme/), और [format_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/format_scheme/) गुणों को उजागर करता है। इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी है जब कोई प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री विभिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, फ़िल, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

यदि कोई फ़ाइल कई मास्टरों का उपयोग करती है, तो यह मानने से बचें कि हर स्लाइड की समान प्रभावी थीम है। स्लाइड से संबद्ध मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख के बाद दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सेवी फ़िल, रेखा और पाठ एक तर्कसंगत रंग को [SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) enumeration से संदर्भित कर सकते हैं। जब आप थीम के [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट जो अभी भी उस थीम रंग को संदर्भित करते हैं, नई मान के अनुसार हल होते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंतिम‑से‑अंत उदाहरण एक आकार बनाता है जो `ACCENT4` का उपयोग करता है, थीम के `accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, उसे पुनः खोलता है, और प्रभावी फ़िल रंग को प्रिंट करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

चूँकि आयत `ACCENT4` से जुड़ी रहती है, थीम बदलने पर उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `accent4` में किए गए परिवर्तन उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करने के लिए रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के और गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंग से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `ACCENT4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `accent4` बदलता है, तो रूपांतरित रंग नए `accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) enumeration `TEXT1`, `BACKGROUND1`, `TEXT2`, और `BACKGROUND2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) समान थीम स्लॉट को `dark1`, `light1`, `dark2`, और `light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये ऐसे मान नहीं हैं जो गतिशील रूप से एक रूप से दूसरे में परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में शीर्षकों के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme.major](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/major/) और [FontScheme.minor](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/minor/) गुण इन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग पाठ फॉर्मैटिंग में किया जा सकता है:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (मेजर लैटिन फ़ॉन्ट)
* `+mn‑ea` - बॉडी फ़ॉन्ट इस्ट एशियन (माइनर इस्ट एशियन फ़ॉन्ट)
* `+mj‑ea` - हेडिंग फ़ॉन्ट इस्ट एशियन (मेजर इस्ट एशियन फ़ॉन्ट)

निम्न उदाहरण एक शीर्षक बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन बनाता है जो माइनर लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

शीर्षक प्रमुख फ़ॉन्ट का अनुसरण करता है और बॉडी टेक्स्ट माइनर फ़ॉन्ट का। जिसमें स्पष्ट फ़ॉन्ट नाम का उपयोग किया गया है, वह थीम फ़ॉन्ट स्कीम बदलने पर स्वतः नहीं बदलेगा।

प्रमुख और माइनर फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों, जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन और थाना के लिये फ़ॉन्ट मैपिंग भी रख सकते हैं। इन मैपिंग को निरीक्षित, जोड़े, बदलें या हटाएँ, इसके लिये देखें [Script‑Specific Theme Fonts](/slides/hi/python-net/script-specific-font-mappings/)।

{{% alert color="info" title="सलाह" %}}
प्रस्तुति फ़ॉन्ट के बारे में अधिक जानकारी के लिये देखें [PowerPoint Fonts](/slides/hi/python-net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **मास्टर की निर्भर स्लाइड्स पर बाहरी थीम लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) है और आप किसी निश्चित मास्टर पर निर्भर सभी स्लाइड्स को पुनः शैली देना चाहते हैं, तो [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) का उपयोग करें। [Presentation.masters](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/masters/) संग्रह से वह मास्टर चुनें, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) लागू करता है, और विधि को थीम फ़ाइल पथ पास करें।

विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
2. बाहरी थीम को नए मास्टर पर लागू करती है।
3. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर को सौंपती है।
4. नई बनी हुई [IMasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/) लौटाती है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

एक अमान्य, भ्रष्ट, या असमर्थित थीम [PptxException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxexception/) या उसके फ़ॉर्मेट‑संबंधी उपवर्गों को उत्पन्न कर सकती है। उपयोगकर्ता द्वारा प्रदान किए गए पथों को मान्य करें, फ़ाइल‑सिस्टम पहुँच त्रुटियों को संभालें, और केवल तभी प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल वही स्लाइड्स पुनः सौंपी जाती हैं जो चुने हुए मास्टर पर निर्भर थीं। अन्य मास्टरों से जुड़े स्लाइड्स अपने मौजूदा मास्टर और थीम को बनाए रखते हैं। थीम‑सेवी रंग, फ़ॉन्ट, फ़िल, रेखा, पृष्ठभूमि और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नए मास्टर से विरासत में मिली मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम वातावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिये आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [custom font sources](/slides/hi/python-net/custom-font/) के माध्यम से प्रदान करें, या [font substitution](/slides/hi/python-net/font-substitution/) को कॉन्फ़िगर करें।

यह एक प्रत्यक्ष मास्टर‑स्तर कार्यप्रवाह है: विधि `.thmx` फ़ाइल पथ को स्वीकार करती है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब प्रासंगिक मास्टर पहले से ज्ञात न हो, तो इसे किसी प्रतिनिधि स्लाइड से [Slide.layout_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/layout_slide/) और [LayoutSlide.master_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/master_slide/) के माध्यम से प्राप्त करें। किसी भी थीम को लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स के मास्टर खोजता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

पहला कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `first_group_master` पर निर्भर थीं, और दूसरा कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `second_group_master` पर निर्भर थीं। अन्य किसी भी मास्टर की स्लाइड्स को पुनः शैली नहीं दी जाती।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम बनाए रखें**

यदि आप किसी स्लाइड को किसी अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को बरकरार रखना चाहते हैं, तो [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) के साथ स्रोत मास्टर को लक्ष्य प्रस्तुति में क्लोन करें, फिर [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) के साथ स्लाइड को क्लोन करें और क्लोन किए गए मास्टर को सौंपें। इससे मास्टर, उसके लेआउट और सम्बद्ध थीम एक साथ स्थानांतरित होते हैं।

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

यह वह पसंदीदा कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में समान रूप दिखना आवश्यक हो। केवल सामग्री को असंबंधित गंतव्य मास्टर पर क्लोन करने से थीम‑चलित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को उसकी वर्तमान मास्टर और लेआउट पर रखना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), और [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) विधियां तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलेगा, जबकि अन्य स्लाइड्स द्वारा विरासत में मिली थीम नहीं बदलेगी। स्थानीय ओवरराइड को हटाने और विरासत मानों पर लौटने के लिये [OverrideTheme.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

एक लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशिष्ट स्लाइड अपनी स्वयं की ओवरराइड न रखती हो। वही प्रारंभिक विधियां लेआउट की [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग की जा सकती हैं:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम का उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड और केवल विशिष्ट अपवादों के लिये स्लाइड ओवरराइड का उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तनों को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि फ़िलें [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) में संग्रहीत होती हैं। PowerPoint UI में पृष्ठभूमि विकल्पों की संख्या इस संग्रह में शारीरिक रूप से संग्रहीत फ़िल परिभाषाओं से अधिक हो सकती है क्योंकि UI थीम फ़िल को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint पृष्ठभूमि शैली गैलरी प्रस्तुति थीम के लिये](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.style_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/style_index/) को निरीक्षण करें। `style_index` थीम‑फ़िल न होने पर `0` का उपयोग करता है; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह Python संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `[0]` प्रथम संग्रहीत आइटम को दर्शाता है। यह मानने से बचें कि हर प्रस्तुति में समान संख्या की पृष्ठभूमि फ़िल शैलियाँ हों।

निम्न उदाहरण उपलब्ध पृष्ठभूमि फ़िल गणना रिपोर्ट करता है, प्रथम मास्टर को एक थीम‑पृष्ठभूमि संदर्भ सौंपता है, और प्रस्तुति को सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

दिखायी देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड‑स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि का उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिये [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}
`style_index` को शून्य‑आधारित संग्रह सूचकांक न समझें। एक फ़ाइल से शैली संख्या हार्ड‑कोड करने और इसे दूसरी फ़ाइल में समान रूप मानने से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="सलाह" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिये देखें [Presentation Background](/slides/hi/python-net/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग-अलग [FormatScheme.fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/line_styles/), और [FormatScheme.effect_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/effect_styles/) संग्रह होते हैं। सामान्य Office थीम अक्सर तीन मुख्य शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप से सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि निश्चित संख्या मानना चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप Python में इन संग्रहों को एक्सेस करते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `[0]` प्रथम संग्रहीत शैली है और `[2]` तृतीय है। एक आकार की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapestyle/) के माध्यम से उजागर होती है। थीम शैली को संशोधित करने से उन आकारों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, प्रथम रेखा शैली बदलता है, तृतीय फ़िल शैली बदलता है, तृतीय प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिये, प्रथम थीम रेखा शैली लाल हो जाएगी, तृतीय थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन हो जाएगी, और तृतीय प्रभाव शैली में 10 पॉइंट की दूरी के साथ एक बाहरी छाया जुड़ जाएगी। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौन से शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिये, [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) को कॉल करें। पृष्ठभूमि के लिये, [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) का उपयोग करें, और फ़िल के लिये, [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) का उपयोग करें।

निम्न उदाहरण किसी स्लाइड से प्रभावी थीम, पृष्ठभूमि और प्रथम आकार फ़िल पढ़ता है:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

रेंडरिंग निदान, मान्यकरण और तुलना के लिये प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड या आकार के ओवरराइड को मिस कर सकते हैं जो अंतिम स्वरूप को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की सभी स्लाइड्स प्रभावित होती हैं?**

नहीं। [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) केवल उन स्लाइड्स को पुनः सौंपता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों का उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम को बरकरार रखती हैं।

**क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड की [SlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक स्थानीय रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम विरासत में लेते रहेंगी।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम को ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित करते हैं और उसके स्रोत स्वरूप को बनाए रखना चाहते हैं, तो [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) के साथ स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) के साथ स्लाइड को क्लोन करें। यह मास्टर, लेआउट और थीम को साथ‑साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिये [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) और [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) के लिये संबंधित प्रभावी‑डेटा विधियों का प्रयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।