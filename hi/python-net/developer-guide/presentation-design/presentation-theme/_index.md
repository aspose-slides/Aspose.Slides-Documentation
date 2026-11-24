---
title: Python में PowerPoint प्रस्तुति थीम प्रबंधित करें
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
description: "Aspose.Slides for Python को .NET के माध्यम से उपयोग करके प्रस्तुति थीम को मुख्य रूप से नियंत्रित करें, जिससे PowerPoint फ़ाइलों को लगातार ब्रांडिंग के साथ बनाना, अनुकूलित करना और परिवर्तित करना संभव हो।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट निर्धारित करती है। थीम‑सेवित ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करते हैं, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर थीम [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) गुण के माध्यम से उपलब्ध है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) के द्वारा ओवरराइड कर सकता है, एक लेआउट अपनी उत्तराधिकारित थीम को [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) के द्वारा ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी वही कर सकता है। व्यवहार में, स्लाइड के लिये प्रभावी थीम इस विरासत श्रृंखला के द्वारा हल की जाती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के खंड सबसे आम थीम कार्यप्रवाह दिखाते हैं: थीम निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत एवं ओवरराइड हल होने के बाद प्रभावी मान पढ़ना।

## **थीम निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/), और [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) गुणों को उजागर करता है। इन संग्रहों को बदलने से पहले निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

नीचे का उदाहरण मुख्य थीम गुण पढ़ता है और थीम में संग्रहीत पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियों की संख्या रिपोर्ट करता है:

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

यदि फ़ाइल कई मास्टर उपयोग करती है, तो यह मानना सही नहीं है कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से संबंधित मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं तो इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सेवित भराव, रेखा और पाठ [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप थीम के [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नए मान के अनुसार हल हो जाते हैं। सीधे RGB रंग उपयोग करने वाले ऑब्जेक्ट्स को थीम‑रंग अपडेट द्वारा नहीं बदला जाता।

नीचे का अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `ACCENT4` का उपयोग करता है, थीम के `accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, उसे पुनः खोलता है, और प्रभावी भराव रंग प्रिंट करता है:

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

क्योंकि आयत `ACCENT4` से जुड़ी रहती है, थीम बदलने के बाद उसका दृश्य रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग पर रंग परिवर्तन लागू करके हल्के और गहरे रूप बनाता है। Aspose.Slides इन परिवर्तन들을 [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।  
**2** - मुख्य थीम रंगों से उत्पन्न हल्के व गहरे रूप।

नीचे का उदाहरण `ACCENT4` पर आधारित छः आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये रूप थीम रंग पर आधारित रहते हैं। यदि `accent4` बाद में बदलता है, तो परिवर्तित रंग नए `accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मिलाएँ**

[SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) enumeration `TEXT1`, `BACKGROUND1`, `TEXT2`, और `BACKGROUND2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) समान थीम स्लॉट को `dark1`, `light1`, `dark2`, और `light2` के रूप में उजागर करता है। मैपिंग निश्चित है:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

ये वही थीम स्लॉट के वैकल्पिक नाम हैं; इन्हें एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हैडिंग के लिये प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिये गौण फ़ॉन्ट सेट होता है। [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) और [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) गुण उन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फॉर्मेटिंग में किया जा सकता है:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj‑lt` - हैडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj‑ea` - हैडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)
* `+mn‑cs` - बॉडी फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Minor Complex Script Font)
* `+mj‑cs` - हैडिंग फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Major Complex Script Font)

नीचे का उदाहरण एक हैडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी लाइन बनाता है जो गौण लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हैडिंग प्रमुख फ़ॉन्ट का पालन करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। यदि कोई टेक्स्ट स्पष्ट फ़ॉन्ट नाम रखता है न कि थीम पहचानकर्ता, तो थीम फ़ॉन्ट स्कीम बदलने पर वह स्वचालित रूप से नहीं बदलेगा।

प्रमुख और गौण फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों के लिये फ़ॉन्ट मैपिंग भी रख सकते हैं, जैसे कि सिरिलिक, अरबी, जापानी, जॉर्जियन, और थाना। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिये देखें [Script‑Specific Theme Fonts](/slides/hi/python-net/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेज़ेंटेशन फ़ॉन्ट्स के बारे में अधिक जानकारी के लिये देखें [PowerPoint फ़ॉन्ट](/slides/hi/python-net/powerpoint-fonts/)।
{{% /alert %}}

### **थीम फ़ॉन्ट रेफ़रेंस हल करें**

जब टेक्स्ट का निरीक्षण करते हैं, तो [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) में `+mn‑lt` जैसी थीम रेफ़रेंस हो सकती है, न कि फ़ॉन्ट परिवार नाम। उचित [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) के साथ [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) कॉल करके उस रेफ़रेंस को हल करें। `+mj` और `+mn` उपसर्ग प्रमुख और गौण फ़ॉन्ट सेट चुनते हैं; `-lt`, `-ea`, और `-cs` प्रत्यय क्रमशः लैटिन, ईस्ट एशियन, और कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट चुनते हैं।

उस ऑब्जेक्ट पर [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) के साथ प्रभावी थीम प्राप्त करें जिसकी थीम उस निरीक्षित टेक्स्ट पर लागू होती है। सामान्य स्लाइड टेक्स्ट के लिये, `slide.create_theme_effective` का उपयोग करें ताकि संदर्भ में वह स्लाइड की उत्तराधिकारित थीम और स्थानीय ओवरराइड शामिल हों। लेआउट या मास्टर स्वयं का निरीक्षण करते समय उसकी अपनी प्रभावी थीम उपयोग करें। यह मानिए नहीं कि पहले मास्टर की थीम हर स्लाइड पर लागू होती है।

नीचे का उदाहरण एक टेक्स्ट भाग बनाता है जो स्पष्ट रूप से गौण लैटिन फ़ॉन्ट का रेफ़रेंस रखता है। यह [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) के द्वारा स्लाइड फ़ॉन्ट स्कीम आरंभ करता है और प्रमुख एवं गौण लैटिन फ़ॉन्ट परिवारों को क्रमशः `Arial` और `Calibri` सेट करता है, जिससे इनपुट फ़ाइल के बिना परिणाम पुनरुत्पादित हो सके।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

आउटपुट `+mn‑lt -> Calibri` के बाद `Verdana -> Verdana` है। संग्रहीत रेफ़रेंस अपरिवर्तित रहता है, जबकि स्पष्ट परिवार नाम जैसा है वैसा ही लौटाया जाता है। यदि भाग `+mj‑lt` उपयोग करता, तो यह इस थीम में `Arial` में हल होता।

थीम रेफ़रेंस को हल करने से वह फ़ॉन्ट परिवार मिलता है जो थीम द्वारा निर्दिष्ट है। यह फ़ॉन्ट उपलब्धता या रेंडरिंग के दौरान प्रतिस्थापन या ग्लिफ़ फॉलबैक का निर्धारण नहीं करता। उन अलग-अलग चरणों के लिये देखें [Font Selection Sequence](/slides/hi/python-net/font-selection-sequence/) और [Font Substitution](/slides/hi/python-net/font-substitution/)।

## **थीम कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तो [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) का उपयोग करें। चयनित मास्टर को [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) संग्रह ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) से चुनें, और विधि को थीम फ़ाइल पथ पास करें।

यह विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
1. नए मास्टर पर बाहरी थीम लागू करती है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर को असाइन करती है।
1. नया निर्मित [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) लौटाती है।

नीचे का उदाहरण पहले मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

एक अमान्य, दूषित, या असमर्थित थीम [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) या उसके फ़ॉर्मेट‑संबंधी उपवर्गों को उत्पन्न कर सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथ की वैधता जांचें, फ़ाइल‑सिस्टम एक्सेस विफलताओं को संभालें, और थीम सफलतापूर्वक लागू होने के बाद ही प्रस्तुति सहेजें।

केवल चयनित मास्टर पर निर्भर स्लाइड्स ही पुनः असाइन की जाती हैं। अन्य मास्टरों से जुड़े स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखती हैं। थीम‑सेवित रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि और प्रभाव बाहरी थीम के अनुसार हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव एवं अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड नई मास्टर से विरासत में मिलने वाले मानों पर भी प्राबल्य रख सकते हैं।

थीम ऐसे फ़ॉन्टों का रेफ़रेंस कर सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिये आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/python-net/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/python-net/font-substitution/) कॉन्फ़िगर करें।

यह सीधा मास्टर‑स्तर कार्यप्रवाह है: विधि `.thmx` फ़ाइल पथ लेती है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड मैन्युअली बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में अलग‑अलग बाहरी थीम लागू करें**

जब संबंधित मास्टर पहले से ज्ञात नहीं है, तो उसे प्रतिनिधि स्लाइड से [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) और [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/) द्वारा प्राप्त करें। किसी भी थीम को लागू करने से पहले मूल मास्टर रेफ़रेंसेज़ को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

नीचे का उदाहरण दो अनुभागों की स्लाइड्स का उपयोग करके उनके मास्टर ढूँढ़ता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

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

पहली कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `first_group_master` पर निर्भर थीं, और दूसरी कॉल केवल उन स्लाइड्स को जो `second_group_master` पर निर्भर थीं। किसी अन्य मास्टर से जुड़ी स्लाइड्स की शैली नहीं बदलेगी।

### **स्लाइड स्थानांतरित करते समय स्रोत थीम बरकरार रखें**

यदि आप स्लाइड को दूसरी प्रस्तुति में स्थानांतरित करना चाहते हैं और उसका मूल डिज़ाइन बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) से क्लोन करें, फिर क्लोन किए गए मास्टर के साथ स्लाइड को [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) से क्लोन करें। इससे मास्टर, उसके लेआउट और संबंधित थीम साथ में लेकर चले जाएंगे।

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

जब स्रोत स्लाइड को गंतव्य में समान रूप दिखाना हो तब यह पसंदीदा कार्यप्रवाह है। केवल कंटेंट को किसी असंबंधित गंतव्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को उसके वर्तमान मास्टर और लेआउट पर बना रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड आरंभ करें। [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), और [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) विधियां तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है जबकि अन्य स्लाइड्स की विरासतित थीम अपरिवर्तित रहती है। स्थानीय ओवरराइड हटाने और विरासतित मानों पर वापस आने के लिये [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/) कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशिष्ट स्लाइड अपनी स्वयं की ओवरराइड न रखे। समान आरंभीकरण विधियों को लेआउट के [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

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

जब कई लेआउट और स्लाइड एक ही बेस डिज़ाइन साझा करने चाहिए, तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें; जब एक लेआउट परिवार को अलग शैली चाहिए, तो लेआउट ओवरराइड उपयोग करें; और केवल वास्तविक अपवादों के लिये स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में ग्लोबल थीम परिवर्तन को अनुमानित करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) में संग्रहीत होती हैं। PowerPoint उपयोगकर्ता इंटरफ़ेस में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भरावों को थीम रंगों और अन्य शैली रेफ़रेंस के साथ संयोजित कर सकता है।

![प्रेज़ेंटेशन थीम के लिये PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) को निरीक्षण करें। `style_index` का मान `0` कोई थीम्ड भराव नहीं दर्शाता; धनात्मक मान थीम पृष्ठभूमि‑शैली रेफ़रेंस होते हैं। यह Python संग्रह के शून्य‑आधारित इंडेक्स से अलग है, जहाँ `[0]` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियां हैं।

नीचे का उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को एक थीम्ड पृष्ठभूमि रेफ़रेंस असाइन करता है, और प्रस्तुति सहेजता है:

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

दिखाया गया परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। अंतिम पृष्ठभूमि (विरासत लागू होने के बाद) जानने के लिये [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`style_index` को शून्य‑आधारित संग्रह इंडेक्स न समझें। किसी एक फ़ाइल से शैली संख्या हार्ड‑कोड करने और मान लेना कि वह दूसरे फ़ाइल में समान दिखेगी, से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फॉर्मेटिंग और पृष्ठभूमि विरासत के लिये देखें [Presentation Background](/slides/hi/python-net/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग-अलग [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/), और [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) संग्रह होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियां होती हैं जो वैचारिक रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि निश्चित संख्या मान लेना।

![एक ही आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

Python में इन संग्रहों तक पहुंचते समय, संग्रह इंडेक्स शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली है और `[2]` तीसरा। Shape की शैली‑रेफ़रेंस इंडेक्स एक अलग अवधारणा है, जो [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/) के माध्यम से उजागर होती है। थीम शैली को बदलने से उन आकारों पर असर पड़ेगा जो उसी थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

नीचे का उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया (दूरी 10 पॉइंट) सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों में पहली थीम रेखा शैली लाल हो जाएगी, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन होगी, और तीसरी प्रभाव शैली में 10 पॉइंट दूरी के साथ बाहरी छाया जुड़ जाएगी। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौन से स्लॉट संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, भराव, और छाया सेटिंग बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **एक आकार के लिये थीम भराव और रेखा शैली चुनें**

एक आकार अपनी भराव और रूपरेखा को स्वतंत्र रूप से [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) और [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) के द्वारा चुन सकता है। दोनों गुणों के लिये, इंडेक्स `1` संबंधित थीम संग्रह में पहला प्रविष्टि (`fill_styles[0]` या `line_styles[0]`) चुनता है, और इंडेक्स `2` दूसरा प्रविष्टि चुनता है।

नीचे का उदाहरण दो भराव (स्वर्ण और आकाश नीला) और दो रूपरेखा (6 pt के साथ गहरा नीला और 12 pt के साथ गहरा लाल) को नई प्रस्तुति की डिफ़ॉल्ट थीम में परिभाषित करता है। यह तीन चरणों में स्लाइड सहेजता है ताकि आप परिणाम PowerPoint में तुलना कर सकें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| प्रारंभिक शैलियाँ | दाएँ रूपरेखा बदलें | पहली थीम भराव संपादित करें |
|:---:|:---:|:---:|
| ![स्वर्ण और आकाश‑नीले आयतें समान पतली गहरी नीली रूपरेखा के साथ](theme-style-initial.png) | ![आकाश‑नीला आयत अब मोटी गहरी लाल रूपरेखा के साथ है](theme-style-line-changed.png) | ![बाँए आयत अब हरा है और दोनों रूपरेखा अपरिवर्तित हैं](theme-style-fill-changed.png) |

विभिन्न रेखा शैली चुनने से केवल दाएँ आयत की रूपरेखा बदलती है। पहली थीम भराव संपादित करने से उस भराव को उपयोग करने वाले सभी आकार अपडेट होते हैं। यहाँ केवल बाएँ आयत हरा हो जाता है।

मौजूदा आकार पर, स्थानीय भराव रंग, रेखा रंग, या रेखा चौड़ाई थीम शैली के उस भाग को ओवरराइड कर सकती है। यदि शैली इंडेक्स बदलने से कोई दृश्य प्रभाव नहीं दिखता, तो आकार की [direct formatting](/slides/hi/python-net/shape-formatting/) जांचें।

## **निर्धारित करें कि प्रभावी ठोस भराव थीम रंग उपयोग करता है या नहीं**

भराव ऑब्जेक्ट पर सीधे संग्रहीत हो सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली या किसी अन्य फ़ॉर्मेटिंग स्तर से विरासतित हो सकता है। [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) को कॉल करके उस पदानुक्रम को अपरिवर्तनीय [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) में हल करें। पहले [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/) जांचें। केवल जब यह `FillType.SOLID` हो, तब ठोस‑भराव गुण पढ़ें।

ठोस भराव के लिये, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) विरासत, थीम लुक‑अप और रंग परिवर्तन लागू होने के बाद अंतिम RGB मान लौटाता है। [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `TEXT1` या `ACCENT6`। `SchemeColor.NOT_DEFINED` का मान दर्शाता है कि प्रभावी ठोस भराव स्कीम रंग पर आधारित नहीं है। ऐसे कार्यप्रवाह में जहाँ भराव या तो थीम रंग होते हैं या सीधे RGB रंग, यह मान सीधे RGB भराव की पहचान करता है।

स्थानीय [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) मान केवल उपयोग करके भराव को वर्गीकृत न करें। उदाहरणतः, एक टेक्स्ट भाग के पास स्थानीय स्तर पर कोई स्कीम रंग नहीं हो सकता, इसलिए उसका स्थानीय मान `NOT_DEFINED` रहता है, जबकि उसका प्रभावी भराव थीम रंग विरासत में लेकर `TEXT1` या `ACCENT6` में हल हो सकता है। दूसरी ओर, `solid_fill_scheme_color` बताता है कि कौन सा लॉजिकल थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

नीचे का उदाहरण प्रस्तुति लोड करता है, आकार भराव और टेक्स्ट‑पोर्टियन भराव दोनों का ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबद्ध स्कीम रंग प्रिंट करता है, और उन ठोस भरावों को फ़्लैग करता है जो थीम रंग परिवर्तनों को ट्रैक नहीं करेंगे:

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

`NOT_DEFINED` शाखा उन ठोस भरावों की ऑडिट सूची देती है जो थीम रंग स्लॉट में परिवर्तन के प्रति प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नई ब्रांड पैलेट के अनुरूप बनाना हो तो उन ऑब्जेक्ट्स की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान दृश्य दिखाता है, जबकि स्कीम मान बताता है कि वह दृश्य थीम से जुड़ा है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम ओवरराइड या कोई भी विरासतित फ़ॉर्मेटिंग बदलने के बाद, फिर से `get_effective` कॉल करें और नई `IFillFormatEffectiveData` ऑब्जेक्ट पढ़ें इससे पहले कि आप रंगों की तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट यह बताते हैं कि विशेष स्तर पर क्या परिभाषित है। प्रभावी मान यह बताते हैं कि स्लाइड या आकार वास्तव में क्या उपयोग करता है, विरासत और स्थानीय ओवरराइड हल होने के बाद। स्लाइड के लिये, [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) कॉल करें। पृष्ठभूमि के लिये [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) और भराव के लिये [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) उपयोग करें।

नीचे का उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकार भराव पढ़ता है:

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

रेंडरिंग निदान, वैधता, और तुलना के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) का निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड या आकार ओवरराइड को चूक सकते हैं जो अंतिम दिखावट को बदलते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड पर असर पड़ता है?**

नहीं। [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर हैं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम बरकरार रखती हैं।

**क्या मैं मास्टर बदले बिना केवल एक स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) का उपयोग करके उसकी ओवरराइड थीम को आरंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम विरासती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित कर उसके स्रोत स्वरूप को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को गंतव्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को क्लोन करें, इसके लिये [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) और [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) उपयोग करें। इससे मास्टर, लेआउट और थीम एक साथ रखे जाते हैं।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिये [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) और [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) के अनुरूप प्रभावी‑डेटा विधियों को कॉल करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।