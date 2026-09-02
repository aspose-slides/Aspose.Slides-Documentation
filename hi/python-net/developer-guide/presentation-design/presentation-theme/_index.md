---
title: "Python में PowerPoint प्रस्तुति थीम प्रबंधित करें"
linktitle: "प्रस्तुति थीम"
type: docs
weight: 10
url: /hi/python-net/presentation-theme/
keywords:
- "PowerPoint थीम"
- "प्रस्तुति थीम"
- "स्लाइड थीम"
- "थीम सेट करें"
- "थीम बदलें"
- "थीम प्रबंधित करें"
- "थीम रंग"
- "अतिरिक्त पैलेट"
- "थीम फ़ॉन्ट"
- "थीम शैली"
- "थीम प्रभाव"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python द्वारा .NET के माध्यम से मास्टर प्रस्तुति थीम को प्रबंधित करके PowerPoint फ़ाइलों को स्थिर ब्रांडिंग के साथ बनाएं, अनुकूलित करें और परिवर्तित करें।"
---
## **परिचय**

एक प्रेजेंटेशन थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, फ़िल्स, लाइनों और इफ़ेक्ट्स का समन्वित सेट परिभाषित करती है। थीम‑सजग ऑब्जेक्ट्स इन साझा परिभाषाओं का संदर्भ लेते हैं, बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम बदलने पर कई ऑब्जेक्ट्स एक साथ अपडेट हो सकते हैं।

Aspose.Slides में, प्रेजेंटेशन‑स्तर की थीम [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) प्रॉपर्टी के माध्यम से उपलब्ध है। एक प्रेजेंटेशन नीचे स्तरों पर भी थीम ओवरराइड रख सकता है। एक मास्टर प्रेजेंटेशन थीम को [MasterThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/masterthememanager/override_theme/) द्वारा ओवरराइड कर सकता है, एक लेआउट अपने विरासत में मिली थीम को [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) द्वारा ओवरराइड कर सकता है, और एक व्यक्तिगत स्लाइड भी ऐसा ही कर सकता है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस वंशानुगत श्रृंखला के माध्यम से हल की जाती है: प्रेजेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फोंट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और इफ़ेक्ट शैलियों को अपडेट करना, और वंशानुक्रम एवं ओवरराइड हल होने के बाद प्रभावी मान पढ़ना।

## **थीम की जाँच**

[MasterTheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/) ऑब्जेक्ट थीम के [color_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/font_scheme/), और [format_scheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/mastertheme/format_scheme/) प्रॉपर्टी को उजागर करता है। इन संग्रहों को बदलने से पहले निरीक्षण करना खास तौर पर उपयोगी होता है जब प्रेजेंटेशन बाहरी स्रोत से आता है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्न उदाहरण मुख्य थीम प्रॉपर्टीज़ पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, फ़िल, लाइन और इफ़ेक्ट शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड का वही प्रभावी थीम है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं।

## **थीम रंग बदलें**

थीम‑सजग फ़िल्स, लाइन्स, और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ ले सकते हैं। जब आप थीम की [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नए मान के विरुद्ध हल होते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंतिम‑से‑अंत उदाहरण एक आकार बनाता है जो `ACCENT4` का उपयोग करता है, थीम के `accent4` रंग को लाल में बदलता है, प्रेजेंटेशन को सहेजता है, उसे पुनः खोलता है, और प्रभावी फ़िल रंग को प्रिंट करता है:

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

चूँकि आयत `ACCENT4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `accent4` में परिवर्तन उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट्स को रंग परिवर्तन लागू करके प्राप्त करता है। Aspose.Slides इन परिवर्तन को [ColorTransformOperation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के और गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंग से उत्पन्न हल्के और गहरे वैरिएंट्स।

निम्न उदाहरण `ACCENT4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट्स थीम रंग पर आधारित रहते हैं। यदि `accent4` बाद में बदलेगा, तो परिवर्तित रंग नए `accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मिलाएँ**

[SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) enumeration `TEXT1`, `BACKGROUND1`, `TEXT2`, और `BACKGROUND2` का उपयोग करती है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) समान थीम स्लॉट्स को `dark1`, `light1`, `dark2`, और `light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

ये एक ही थीम स्लॉट्स के वैकल्पिक नाम हैं; ये कोई गतिशील रूपांतरण नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग्स के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए लघु फ़ॉन्ट सेट शामिल होता है। [FontScheme.major](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/major/) और [FontScheme.minor](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/fontscheme/minor/) प्रॉपर्टी उन सेट को उजागर करती हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकों का उपयोग टेक्स्ट फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* `+mj‑lt` - हेडिंग फ़ॉन्ट लैटिन (मैजर लैटिन फ़ॉन्ट)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* `+mj‑ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (मैजर ईस्ट एशियन फ़ॉन्ट)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो लघु लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट लघु फ़ॉन्ट का। वह टेक्स्ट जिसमें स्पष्ट फ़ॉन्ट नाम है न कि थीम पहचानकर्ता, थीम फ़ॉन्ट स्कीम बदलने पर स्वतः नहीं बदलता।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट्स के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/python-net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह हैं, और वे अलग‑अलग समस्याओं को हल करते हैं।

### **स्लाइड्स को ले जाने पर स्रोत थीम रखें**

यदि आप एक स्लाइड को दूसरे प्रेजेंटेशन में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रेजेंटेशन में [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) से क्लोन करें, फिर स्लाइड को [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) और क्लोन किए गए मास्टर के साथ क्लोन करें। यह मास्टर, उसके लेआउट, और संबद्ध थीम को एक साथ ले जाता है।

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

जब स्रोत स्लाइड को गंतव्य में समान दिखना चाहिए, यह सबसे पसंदीदा कार्यप्रवाह है। अनिर्धारित गंतव्य मास्टर पर केवल सामग्री क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, पृष्ठभूमि और इफ़ेक्ट बदल सकते हैं।

### **मौजूद स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपनी वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को इनिशियलाइज़ करें। [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), और [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह केवल उस स्लाइड की थीम को बदलता है, जबकि अन्य स्लाइड्स द्वारा विरासत में मिली थीम अपरिवर्तित रहती है। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/overridetheme/clear/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

एक लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपनी स्वयं की ओवरराइड न रखे। समान इनिशियलाइज़ेशन मेथड्स लेआउट के [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/layoutslidethememanager/) के माध्यम से उपयोग की जा सकती हैं:

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

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रेजेंटेशन‑स्तर थीम का उपयोग करें, एक लेआउट ओवरराइड तब उपयोग करें जब किसी एक लेआउट परिवार को अलग शैली की आवश्यकता हो, और स्लाइड ओवरराइड केवल वास्तविक अपवादों के लिए उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद के ग्लोबल थीम परिवर्तनों को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि फ़िल्स [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) में संग्रहीत हैं। PowerPoint UI में पृष्ठभूमि विकल्पों की संख्या इस संग्रह में भौतिक रूप से संग्रहीत फ़िल परिभाषाओं से अधिक हो सकती है क्योंकि UI थीम फ़िल को थीम रंगों और अन्य शैली संदर्भों के साथ जोड़ सकती है।

![प्रेजेंटेशन थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.style_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/style_index/) को निरीक्षण करें। `style_index` कोई थीम्ड फ़िल न होने के लिये `0` का उपयोग करता है; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह सीधे Python संग्रह को इंडेक्स करने से अलग है, जहाँ `[0]` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रेजेंटेशन में समान संख्या में पृष्ठभूमि फ़िल शैलियाँ होती हैं।

निम्न उदाहरण उपलब्ध पृष्ठभूमि फ़िल गिनती रिपोर्ट करता है, पहले मास्टर को एक थीम्ड पृष्ठभूमि संदर्भ असाइन करता है, और प्रेजेंटेशन को सहेजता है:

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

दृश्य परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि का उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने की आवश्यकता होने पर [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
`style_index` को शून्य‑आधारित संग्रह इंडेक्स न समझें। साथ ही एक फ़ाइल से शैली नंबर को हार्ड‑कोड करके दूसरे फ़ाइल में उसी रूप में मानने से बचें; थीम शैली परिभाषाएँ प्रेजेंटेशन‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/python-net/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग [FormatScheme.fill_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/line_styles/), और [FormatScheme.effect_styles](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/effect_styles/) संग्रह होते हैं। सामान्य Office थीम अक्सर तीन मुख्य शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग के अनुरूप होती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि स्थिर गणना पर निर्भर होना चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम इफ़ेक्ट्स](presentation-design_10.png)

Python में इन संग्रहों तक पहुँचते समय, संग्रह इंडेक्स शून्य‑आधारित होता है: `[0]` पहला संग्रहीत शैली है और `[2]` तीसरा। आकार की शैली‑संदर्भ इंडेक्स एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapestyle/) के माध्यम से उजागर होती है। थीम शैली को संशोधित करने से उन आकारों पर असर पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

उन आकारों के लिए जो इन स्लॉट्स को संदर्भित करते हैं, पहली थीम लाइन शैली लाल हो जाती है, तीसरी थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन हो जाती है, और तीसरी इफ़ेक्ट शैली को 10 पॉइंट दूरी के साथ बाहरी छाया मिलती है। वास्तविक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार किन शैली स्लॉट्स को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग ने थीम को ओवरराइड किया है।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी निश्चित स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) को कॉल करें। पृष्ठभूमि के लिए, [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) का उपयोग करें, और फ़िल के लिए, [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) का उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकार फ़िल पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैलिडेशन, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.master_theme](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/master_theme/) को निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम रूप को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर को बदलें बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/slidethememanager/) को उपयोग करें और उसके ओवरराइड थीम को इनिशियलाइज़ करें। परिवर्तन केवल उस स्लाइड पर स्थानीय रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में जारी रखती हैं।

**एक प्रेजेंटेशन से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को ले जाएँ और उसकी स्रोत उपस्थिति को बरकरार रखें, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और उस मास्टर के साथ स्लाइड को [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masterslidecollection/add_clone/) और [SlideCollection.add_clone](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidecollection/add_clone/) से क्लोन करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/background/get_effective/) और [FillFormat.get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/get_effective/) के लिए संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।