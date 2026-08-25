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
description: "Aspose.Slides for Python के माध्यम से .NET में प्रस्तुति थीम का मुख्य प्रबंधन करके PowerPoint फ़ाइलों को स्थिर ब्रांडिंग के साथ बनाने, अनुकूलित करने और परिवर्तित करने हेतु।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑जानकार वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करती हैं, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) प्रॉपर्टी के माध्यम से उपलब्ध है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड्स हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/masterthememanager/override_theme/) के द्वारा ओवरराइड कर सकता है, एक लेआउट अपनी विरासत में मिली थीम को [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) के द्वारा ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी ऐसा ही कर सकता है। व्यवहार में, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे आम थीम वर्कफ़्लो दिखाते हैं: थीम की जाँच, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, तथा विरासत और ओवरराइड्स के बाद प्रभावी मान पढ़ना।

## **एक थीम की जाँच करें**

[MasterTheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [color_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/font_scheme/), और [format_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/format_scheme/) प्रॉपर्टी को उजागर करता है। इन संग्रहों को बदलने से पहले जाँचना विशेष रूप से उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम प्रॉपर्टी पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियां संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि हर स्लाइड की समान प्रभावी थीम है। स्लाइड से जुड़ा मास्टर जाँचें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में बाद में दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम रंग बदलें**

थीम‑जानकार भराव, रेखा और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) एन्यूमरेशन से एक तर्कसंगत रंग का संदर्भ ले सकते हैं। जब आप थीम के [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो उन सभी वस्तुओं को नया मान मिल जाता है जो अभी भी उस थीम रंग का संदर्भ ले रही हैं। जो वस्तुएँ सीधे RGB रंग का उपयोग करती हैं, उन्हें थीम‑रंग अपडेट से नहीं बदला जाता।

निम्न पूर्ण‑उदाहरण एक आकृति बनाता है जो `ACCENT4` का उपयोग करता है, थीम के `accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, फिर से खोलता है, और प्रभावी भराव रंग प्रिंट करता है:

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

क्योंकि आयत `ACCENT4` से जुड़ी रहती है, थीम बदलने के बाद उसका दृश्यमान रंग लाल हो जाता है। यदि आप आकृति पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `accent4` में बदलाव उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट बनाता है रंग रूपांतरण लागू करके। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/colortransformoperation/) एन्यूमरेशन के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के व गहरे वैरिएंट।

निम्न उदाहरण `ACCENT4` पर आधारित छह आयतें बनाता है, उन में से पाँच पर प्रकाशता रूपांतरण लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `accent4` बदलता है, तो रूपांतरित रंग नए `accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) एन्यूमरेशन `TEXT1`, `BACKGROUND1`, `TEXT2`, और `BACKGROUND2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) वही थीम स्लॉट्स `dark1`, `light1`, `dark2`, और `light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; ये मूल रूप से एक रूप से दूसरे में गतिशील रूप से परिवर्तित नहीं होते।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग्स के लिए मुख्य फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme.major](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/major/) और [FontScheme.minor](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टी उन सेटों को उजागर करती हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट उपयोग करता है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग मुख्य फ़ॉन्ट का पालन करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। जो टेक्स्ट स्पष्ट फ़ॉन्ट नाम के साथ है, वह थीम फ़ॉन्ट स्कीम बदलने पर स्वचालित रूप से नहीं बदलता।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों, जैसे सिरिलिक, अरबिक, जापानी, जॉर्जियन, और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन मैपिंग्स को जाँचने, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/python-net/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रस्तुति फ़ॉन्ट्स के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/python-net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य वर्कफ़्लो हैं, और वे अलग‑अलग समस्याओं का समाधान करते हैं।

### **स्लाइड्स ले जा रहे हों तो स्रोत थीम को संरक्षित रखें**

यदि आप एक स्लाइड को दूसरे प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिजाइन को संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) के साथ क्लोन करें, फिर स्लाइड को [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) और क्लोन किए हुए मास्टर के साथ क्लोन करें। इससे मास्टर, उसके लेआउट और संबंधित थीम साथ में चलेगा।

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

यह वर्कफ़्लो तब पसंद किया जाता है जब स्रोत स्लाइड को गंतव्य में वही दिखना चाहिए। केवल सामग्री को किसी अपरिचित लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने मौजूदा मास्टर और लेआउट पर रहना है, तो स्रोत थीम से स्लाइड‑स्तर का ओवरराइड प्रारंभ करें। [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), और [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह स्लाइड द्वारा उपयोग की गई थीम को बदलता है बिना अन्य स्लाइडों की विरासत वाली थीम को बदले। स्थानीय ओवरराइड को हटाने और विरासत मानों पर वापस आने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर का ओवरराइड उन स्लाइडों पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशिष्ट स्लाइड अपनी खुद की ओवरराइड न रखे। वही प्रारंभिक मेथड लेआउट के [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड एक ही मूल डिजाइन साझा करनी चाहिए तो प्रस्तुति‑स्तर या मास्टर‑स्तर की थीम उपयोग करें, एक लेआउट परिवार को अलग स्टाइलिंग चाहिए तो लेआउट ओवरराइड, और केवल असाधारण मामलों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को पूर्वानुमानित करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भराव [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) में संग्रहीत होते हैं। PowerPoint अपने UI में अधिक पृष्ठभूमि विकल्प प्रस्तुत कर सकता है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली रेफ़रेंसेस के साथ संयोजित कर सकता है।

![प्रस्तुति थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.style_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/style_index/) को जाँचें। `style_index` का मान `0` का अर्थ कोई थीम्ड भराव नहीं; धनात्मक मान थीम पृष्ठभूमि‑शैली रेफ़रेंसेस होते हैं। यह सीधे एक Python संग्रह के इंडेक्सिंग से अलग है, जहाँ `[0]` पहला संग्रहीत आइटम है। यह न मानें कि हर प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियां होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गणना रिपोर्ट करता है, पहले मास्टर को थीम्ड पृष्ठभूमि रेफ़रेंस असाइन करता है, और प्रस्तुति को सहेजता है:

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

दिखाया गया परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर मौजूद किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि कोई स्लाइड अपनी खुद की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`style_index` को शून्य‑आधारित संग्रह इंडेक्स न समझें। साथ ही एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में उसी रूप मानने से बचें; थीम शैली परिभाषाएं प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/python-net/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FormatScheme.fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/line_styles/), और [FormatScheme.effect_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/effect_styles/) संग्रह होते हैं। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियां होती हैं जो क्रमशः सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग के दृश्य प्रभाव देती हैं, लेकिन कोड को प्रत्येक संग्रह की जाँच करनी चाहिए न कि स्थिर संख्या मानना चाहिए।

![एक ही आकृति पर लागू सूक्ष्म, मध्यम और तीव्र थीम प्रभाव](presentation-design_10.png)

Python में इन संग्रहों को एक्सेस करते समय, संग्रह इंडेक्स शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली और `[2]` तीसरा। आकृति की शैली‑रेफ़रेंस इंडेक्स एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapestyle/) के द्वारा उजागर होती है। थीम शैली को संशोधित करने से उन आकृतियों पर असर पड़ता है जो उस थीम शैली को संदर्भित करती हैं; सीधी फ़ॉर्मेटिंग वाली आकृतियां अपरिवर्तित रह सकती हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्रिय करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाली आकृतियों के लिए, पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन हो जाती है, और तीसरी प्रभाव शैली को 10 पॉइंट दूरी के साथ बाहरी छाया मिलती है। अंतिम दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकृति कौन सा शैली स्लॉट संदर्भित करती है और क्या सीधा फ़ॉर्मेटिंग थीम को ओवरराइड करता है।

![लाइन, भराव और छाया सेटिंग्स बदलने के बाद थीम प्रभाव शैलियां](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड्स के बाद स्लाइड या आकृति वास्तव में क्या उपयोग करती है। स्लाइड के लिए, [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) को कॉल करें। पृष्ठभूमि के लिए, [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) उपयोग करें, और भराव के लिए, [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकृति भराव पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैधता और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) जाँचते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड या आकृति ओवरराइड को मिस कर सकते हैं जो अंतिम रूप को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एकल स्लाइड पर थीम लागू कर सकता हूँ बिना मास्टर बदले?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/slidethememanager/) का उपयोग करके उसके ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइडें अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी प्रस्तुति तक थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड ले जा रहे हों और स्रोत स्वरूप को संरक्षित रखना चाहते हों, तो स्रोत मास्टर को गंतव्य में [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) के साथ क्लोन करें और फिर स्लाइड को उसी मास्टर के साथ [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) के साथ क्लोन करें। इससे मास्टर, लेआउट और थीम साथ में रहते हैं।

**विरासत और ओवरराइड्स के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) और [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) के लिए संबंधित प्रभावी‑डेटा मेथड्स उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।