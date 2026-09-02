---
title: Python में PowerPoint प्रस्तुति थीम को नियंत्रित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/python-net/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुति थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
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
description: "Aspose.Slides के लिए Python में .NET के माध्यम से प्रमुख प्रस्तुति थीम को नियंत्रित करें, जिससे आप PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ बना, अनुकूलित और परिवर्तित कर सकते हैं।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड शैलियों, फ़िल्स, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करते हैं, जिससे थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम उपलब्ध है [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) गुण के माध्यम से। एक प्रस्तुति में निम्न स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर प्रस्तुति थीम को ओवरराइड कर सकता है [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/masterthememanager/override_theme/) के द्वारा, एक लेआउट अपनी विरासत वाली थीम को ओवरराइड कर सकता है [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) के द्वारा, और एक व्यक्तिगत स्लाइड भी यही कर सकता है। व्यवहार में, स्लाइड की प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, बैकग्राउंड शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: एक थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, बैकग्राउंड और प्रभाव शैलियों को अपडेट करना, और विरासत एवं ओवरराइड के बाद प्रभावी मान पढ़ना।

## **एक थीम की जांच करें**

[MasterTheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [color_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/font_scheme/), और [format_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/format_scheme/) गुण उजागर करता है। इन संग्रहों का निरीक्षण करना, विशेष रूप से तब उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल में कई मास्टर उपयोग होते हैं, तो यह न मानें कि प्रत्येक स्लाइड की प्रभावी थीम समान है। स्लाइड से संबंधित मास्टर की जांच करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं तो इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सचेत फ़िल्स, रेखाएँ और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप थीम के [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग का संदर्भ ले रहे हैं, नया मान प्राप्त करेंगे। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक आकृति बनाता है जो `ACCENT4` का उपयोग करती है, थीम के `accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

क्योंकि आयत `ACCENT4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकृति पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `accent4` में किए गए परिवर्तन उस फ़िल को अधिक प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे विविधताएँ उत्पन्न करने के लिए रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे विविधताएँ।

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

ये विविधताएँ थीम रंग पर आधारित रहती हैं। यदि बाद में `accent4` बदलता है, तो परिवर्तित रंग नए `accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मानचित्रित करें**

[SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) enumeration `TEXT1`, `BACKGROUND1`, `TEXT2`, और `BACKGROUND2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) समान थीम स्लॉट्स को `dark1`, `light1`, `dark2`, और `light2` के रूप में उजागर करता है। मानचित्रण स्थिर है:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; ये किसी रूप में गतिशील रूपांतरण नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए लघु फ़ॉन्ट सेट होता है। [FontScheme.major](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/major/) और [FontScheme.minor](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/minor/) गुण इन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करती है और एक बॉडी पंक्ति जो लघु लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर वह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट लघु फ़ॉन्ट का। जो टेक्स्ट में स्पष्ट फ़ॉन्ट नाम है, वह थीम फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से नहीं बदलेगा।

मुख्य और लघु फ़ॉन्ट संग्रहों में व्यक्तिगत लेखन प्रणालियों जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें जांचने, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/python-net/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट्स के बारे में अधिक जानकारी के लिए, देखें [PowerPoint Fonts](/slides/hi/python-net/powerpoint-fonts/)।  
{{% /alert %}}

## **थीम को कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **एक बाहरी थीम को मास्टर की निर्भर स्लाइड्स पर लागू करें**

जब आपके पास एक PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स को पुनःशैलि देना चाहते हों, तो उपयोग करें [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/)। चयनित मास्टर को [Presentation.masters](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/masters/) संग्रह से चुनें, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/) को लागू करता है, और विधि को थीम फ़ाइल पथ पास करें।

विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
2. बाहरी थीम को नए मास्टर पर लागू करती है।
3. सभी स्लाइड्स को जो पहले चयनित मास्टर पर निर्भर थीं, नए मास्टर को असाइन करती है।
4. नया बनाया गया [IMasterSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/) लौटाती है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

एक अमान्य, क्षतिग्रस्त या असमर्थित थीम [PptxException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxexception/) या उसके फ़ॉर्मेट‑संबंधी उपवर्गों का कारण बन सकती है। उपयोगकर्ता द्वारा प्रदान किए गए पथों को मान्य करें, फ़ाइल‑सिस्टम एक्सेस विफलताओं को संभालें, और केवल तभी प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनःसौंपा जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर से जुड़ी स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, फ़िल, रेखा, बैकग्राउंड और प्रभाव बाहरी थीम के विरुद्ध हल किए जाते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नए मास्टर से विरासत में मिली मानों पर प्राथमिकता ले सकते हैं।

थीम उन फ़ॉन्ट को संदर्भित कर सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। निरंतर रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/python-net/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/python-net/font-substitution/) कॉन्फ़िगर करें।

यह एक प्रत्यक्ष मास्टर‑स्तर कार्यप्रवाह है: विधि `.thmx` फ़ाइल पथ को स्वीकार करती है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअली बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड से प्राप्त करें [Slide.layout_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/layout_slide/) और [LayoutSlide.master_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/layoutslide/master_slide/) के माध्यम से। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स को उनके मास्टर खोजने और प्रत्येक समूह पर अलग बाहरी थीम लागू करने के लिए उपयोग करता है:

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

पहली कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `first_group_master` पर निर्भर थीं, और दूसरी कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `second_group_master` पर निर्भर थीं। अन्य किसी मास्टर से जुड़ी स्लाइड्स पुनःशैलि नहीं की जातीं।

### **स्लाइड्स ले जाने पर स्रोत थीम संरक्षित रखें**

यदि आप एक स्लाइड को दूसरे प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) के द्वारा क्लोन करें, फिर स्लाइड को [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) और क्लोन किए गए मास्टर के साथ क्लोन करें। इससे मास्टर, उसके लेआउट और संबंधित थीम साथ में चलते हैं।

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

यह वही कार्यप्रवाह है जब स्रोत स्लाइड को लक्ष्य में समान रूप से दिखाना आवश्यक हो। केवल सामग्री को एक असंबंधित लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, बैकग्राउंड और प्रभाव बदल सकते हैं।

### **एक मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), और [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह स्लाइड द्वारा उपयोग की जाने वाली थीम को बदलेगा, जबकि अन्य स्लाइड्स की विरासत वाली थीम अपरिवर्तित रहेगी। स्थानीय ओवरराइड को हटाने और विरासत मानों पर लौटने के लिए कॉल करें [OverrideTheme.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/clear/)।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपनी स्वयं की ओवरराइड न रखे। समान प्रारंभिक विधियों का उपयोग लेआउट के [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से किया जा सकता है:

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

जब कई लेआउट और स्लाइड्स को समान आधार डिज़ाइन साझा करना हो तो प्रस्तुति‑स्तर या मास्टर‑स्तर थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट‑ओवरराइड उपयोग करें, और वास्तविक अपवादों के लिए केवल स्लाइड‑ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम की बैकग्राउंड फ़िल्स [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) में संग्रहीत होती हैं। PowerPoint अपने UI में अधिक बैकग्राउंड विकल्प प्रस्तुत कर सकता है बनिस्बत उन फ़िल परिभाषाओं की संख्या से जो इस संग्रह में भौतिक रूप से संग्रहीत हैं, क्योंकि UI थीम फ़िल को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![प्रेजेंटेशन थीम के लिए पॉवरपॉइंट बैकग्राउंड शैली गैलरी](presentation-design_8.png)

बैकग्राउंड शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.style_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/style_index/) को जांचें। `style_index` `0` का उपयोग करता है जब कोई थीम फ़िल नहीं है; सकारात्मक मान थीम बैकग्राउंड‑शैली संदर्भ होते हैं। यह सीधे Python संग्रह के इंडेक्सिंग से अलग है जहाँ `[0]` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में बैकग्राउंड फ़िल शैलियाँ होती हैं।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल गणना रिपोर्ट करता है, पहली मास्टर को एक थीम‑बैकग्राउंड संदर्भ असाइन करता है, और प्रस्तुति को सहेजता है:

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

दिखायी देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदल सकती। जब आपको विरासत के बाद अंतिम बैकग्राउंड जानना हो तो उपयोग करें [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/)।

{{% alert color="warning" title="Warning" %}}
`style_index` को शून्य‑आधारित संग्रह इंडेक्स न मानें। किसी एक फ़ाइल से शैली क्रमांक को हार्ड‑कोड करना और मान लेना कि वह दूसरी फ़ाइल में समान दिखेगा, से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।  
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
डायरेक्ट बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/python-net/presentation-background/)।  
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FormatScheme.fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/line_styles/), और [FormatScheme.effect_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/effect_styles/) संग्रह होते हैं। Typical Office थीम्स में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप में सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग के अनुरूप होती हैं, लेकिन कोड को प्रत्येक संग्रह की जांच करनी चाहिए न कि निश्चित गिनती मान लेना।

![एक ही आकार पर लागू सूक्ष्म, मध्यम और तीव्र थीम प्रभाव](presentation-design_10.png)

Python में इन संग्रहों तक पहुँचते समय, संग्रह इंडेक्स शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली है और `[2]` तीसरा। एक आकृति का शैली‑संदर्भ इंडेक्स एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। किसी थीम शैली को बदलने से उन आकृतियों पर असर पड़ता है जो उस थीम शैली का संदर्भ लेती हैं; सीधे फ़ॉर्मेटिंग वाले आकृतियों पर कोई असर नहीं हो सकता।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी प्रभाव शैली में बाह्य छाया सक्रिय करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स का संदर्भ लेने वाली आकृतियों के लिए, पहली थीम रेखा शैली लाल हो जाएगी, तीसरी थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन हो जाएगी, और तीसरी प्रभाव शैली 10 पॉइंट की दूरी के साथ बाह्य छाया प्राप्त करेगी। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकृति कौन से शैली स्लॉट्स का संदर्भ लेती है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![रेखा, फ़िल और शैडो सेटिंग बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **निर्धारित करें कि क्या प्रभावी ठोस फ़िल थीम रंग का उपयोग करता है**

फ़िल को ऑब्जेक्ट पर सीधे संग्रहीत किया जा सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली या किसी अन्य फ़ॉर्मेटिंग स्तर से विरासत में मिल सकता है। इसे हल करने के लिए कॉल करें [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) ताकि वह हायरार्की को अपरिवर्तनीय [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifillformateffectivedata/) में परिवर्तित हो सके। पहले जांचें [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifillformateffectivedata/fill_type/)। केवल जब यह `FillType.SOLID` हो, तभी ठोस‑फ़िल गुण पढ़ें।

एक ठोस फ़िल के लिए, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) विरासत, थीम लुक‑अप और रंग रूपांतरण लागू करने के बाद अंतिम रेंडर किया गया RGB मान लौटाता है। [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `TEXT1` या `ACCENT6`। `SchemeColor.NOT_DEFINED` का अर्थ है कि प्रभावी ठोस फ़िल किसी स्कीम रंग पर आधारित नहीं है। फ़ॉर्मेटिंग जहाँ फ़िल थीम रंग या सीधे RGB रंग है, उस कार्यप्रवाह में यह मान दर्शाता है कि फ़िल सीधे RGB है।

स्थानीय [IColorFormat.scheme_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/icolorformat/scheme_color/) मान को अकेले उपयोग न करें फ़िल को वर्गीकृत करने के लिए। उदाहरण के लिए, किसी टेक्स्ट भाग में स्थानीय रूप से कोई स्कीम रंग परिभाषित नहीं हो सकता, इसलिए उसका स्थानीय मान `NOT_DEFINED` होगा, जबकि उसका प्रभावी फ़िल थीम रंग विरासत में लेकर `TEXT1` या `ACCENT6` पर हल हो सकता है। इसके विपरीत, `solid_fill_scheme_color` बताता है कि कौन सा तार्किक थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

`NOT_DEFINED` शाखा उन ठोस फ़िलों की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट में परिवर्तन के जवाब में नहीं बदलेंगे। जब किसी प्रस्तुति को नए ब्रांड पैलेट को अपनाना हो तो उन ऑब्जेक्ट्स की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान दिखावट दर्शाता है, जबकि स्कीम मान बताता है कि वह दिखावट थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम‑ओवरराइड, या कोई विरासत फ़ॉर्मेटिंग बदलने के बाद, फिर से `get_effective` कॉल करें और नई `IFillFormatEffectiveData` ऑब्जेक्ट पढ़ें, उसके बाद रंगों की तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताएँगे कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि स्लाइड या आकृति वास्तव में क्या उपयोग करती है, विरासत और स्थानीय ओवरराइड को हल करने के बाद। किसी स्लाइड के लिए कॉल करें [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/)। बैकग्राउंड के लिए उपयोग करें [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/), और फ़िल के लिए उपयोग करें [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/)।

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

रेंडरिंग निदान, मान्यकरण और तुलनाओं के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) का निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड या आकृति ओवरराइड को नज़रअंदाज़ कर सकते हैं जो अंतिम दिखावट बदलते हैं।

## अक्सर पूछे जाने वाले प्रश्न

**क्या बाहरी थीम लागू करने से प्रस्तुति की प्रत्येक स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) केवल उन स्लाइड्स को पुनःसौंपता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर की स्लाइड्स अपने मौजूदा थीम को बरकरार रखती हैं।

**क्या मैं मास्टर बदले बिना केवल एक स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/slidethememanager/) का उपयोग करके उसके ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड पर स्थानीय रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड ले जा रहे हैं और उसके स्रोत रूप को संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को गंतव्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) और [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) से क्लोन करें। इससे मास्टर, लेआउट और थीम एक साथ रखे जाते हैं।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिए उपयोग करें [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) और [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) के संबंधित प्रभावी‑डेटा विधियों को। ये API विरासत और ओवरराइड लागू करने के बाद हल किए गए मान लौटाते हैं।