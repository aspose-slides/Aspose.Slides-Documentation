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
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET के साथ मास्टर प्रस्तुतिकरण थीम बनाएं, अनुकूलित करें और PowerPoint फाइलों को सुसंगत ब्रांडिंग के साथ परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम उसके डिज़ाइन तत्वों की गुणधर्म निर्धारित करती है। जब आप कोई थीम चुनते हैं, तो आप दृश्य तत्वों और उनके गुणधर्मों का समन्वित सेट चुन रहे होते हैं।

PowerPoint में, एक थीम में रंग, [फ़ॉन्ट](/slides/hi/python-net/powerpoint-fonts/), [पृष्ठभूमि शैलियाँ](/slides/hi/python-net/presentation-background/), और प्रभाव शामिल होते हैं।

![theme-constituents](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड के विभिन्न तत्वों के लिए एक विशिष्ट रंग सेट उपयोग करती है। यदि आपको डिफ़ॉल्ट रंग पसंद नहीं हैं, तो आप नई थीम रंग लागू करके उन्हें बदल सकते हैं। नई थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) enumeration में मान प्रदान करता है।

यह Python कोड दिखाता है कि कैसे थीम का एक्सेंट रंग बदलें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

आप नीचे दर्शाए अनुसार परिणामस्वरूप रंग का प्रभावी मान निर्धारित कर सकते हैं:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# उदाहरण आउटपुट:
#
# ff8064a2 (रंग [A=255, R=128, G=100, B=162])
```

रंग परिवर्तन को आगे दिखाने के लिए, हम एक और तत्व बनाते हैं, उसे प्रारंभिक चरण से एक्सेंट रंग असाइन करते हैं, और फिर थीम रंग अपडेट करते हैं।

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

नया रंग स्वचालित रूप से दोनों तत्वों पर लागू हो जाता है।

### **अतिरिक्त पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग (1) पर ल्यूमिनेंस परिवर्तन लागू करते हैं, तो अतिरिक्त पैलेट (2) से रंग उत्पन्न होते हैं। आप इन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![additional-palette-colors](additional-palette-colors.png)

**1** — मुख्य थीम रंग

**2** — अतिरिक्त पैलेट के रंग

यह Python कोड दर्शाता है कि कैसे अतिरिक्त‑पैलेट रंग मुख्य थीम रंग से व्युत्पन्न होते हैं और फिर आकारों में उपयोग होते हैं:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # एक्सेंट 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # एक्सेंट 4, 80% हल्का
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # एक्सेंट 4, 60% हल्का
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # एक्सेंट 4, 40% हल्का
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # एक्सेंट 4, 25% गहरा
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # एक्सेंट 4, 50% गहरा
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **`SchemeColor` को `ColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/python-net/aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देख सकते हैं कि इसमें निम्नलिखित थीम रंग मान मौजूद हैं:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, और `TEXT2`।

हालाँकि, `Presentation.master_theme.color_scheme` [ColorScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/colorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार प्रस्तुत करता है:

`dark1`, `dark2`, `light1`, और `light2`।

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉट को दर्शाते हैं और उनका मैपिंग स्थिर है:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

`TEXT`/`BACKGROUND` और `dark`/`light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office शब्दावली से उत्पन्न हुआ है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` उपयोग होते थे, जबकि नए UI संस्करण समान स्लॉट को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में प्रदर्शित करते हैं।

## **थीम फ़ॉन्ट बदलें**

आपको थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चुनने की अनुमति देने हेतु, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (PowerPoint में समान):

- **+mn-lt** — बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
- **+mj-lt** — हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
- **+mn-ea** — बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
- **+mj-ea** — हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

यह Python कोड दिखाता है कि कैसे लैटिन फ़ॉन्ट को थीम तत्व से असाइन करें:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

यह Python उदाहरण दिखाता है कि कैसे प्रस्तुति के थीम फ़ॉन्ट को बदलें:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

सभी टेक्स्ट बॉक्स नए फ़ॉन्ट में अपडेट हो जाएंगे।

{{% alert color="primary" title="TIP" %}}
अधिक जानकारी के लिए देखें [Master PowerPoint Fonts with Python](/slides/hi/python-net/powerpoint-fonts/)।
{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint 12 पूर्वनिर्धारित पृष्ठभूमि प्रदान करता है, लेकिन सामान्य प्रस्तुति में केवल 3 ही संग्रहीत होते हैं।

![todo:image_alt_text](presentation-design_8.png)

उदाहरण के लिए, PowerPoint में प्रस्तुति सहेजने के बाद, आप नीचे दिया गया Python कोड चलाकर यह निर्धारित कर सकते हैं कि इसमें कितनी पूर्वनिर्धारित पृष्ठभूमियां मौजूद हैं:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
[FormatScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/) क्लास की `background_fill_styles` प्रॉपर्टी का उपयोग करके आप PowerPoint थीम में पृष्ठभूमि शैलियों को जोड़ या पहुँचा सकते हैं।
{{% /alert %}}

यह Python उदाहरण दिखाता है कि प्रस्तुति पृष्ठभूमि कैसे सेट करें:

```python
presentation.masters[0].background.style_index = 2  # 0 का अर्थ कोई भराव नहीं है; अनुक्रमण 1 से शुरू होता है।
```

{{% alert color="primary" title="TIP" %}}
अधिक जानकारी के लिए देखें [Manage Presentation Backgrounds in Python](/slides/hi/python-net/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट बदलें**

PowerPoint थीम आमतौर पर प्रत्येक शैली सरणी में तीन मान शामिल करती है। ये सरणियाँ मिलकर तीन इफ़ेक्ट स्तर बनाती हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब उन इफ़ेक्ट्स को किसी विशिष्ट आकार पर लागू किया जाता है तो परिणाम इस प्रकार है:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/formatscheme/) क्लास की तीन प्रॉपर्टीज़ — `FillStyles`, `LineStyles`, और `EffectStyles` — का उपयोग करके आप थीम तत्वों को PowerPoint से भी अधिक लचीले तरीके से संशोधित कर सकते हैं।

यह Python कोड दिखाता है कि कैसे इन तत्वों के भागों को बदलकर थीम इफ़ेक्ट बदलें:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

परिणामी परिवर्तन में फ़िल रंग, फ़िल प्रकार, शैडो इफ़ेक्ट, और अन्य प्रॉपर्टी अपडेट शामिल हैं:

![todo:image_alt_text](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर को बदले बिना केवल एक स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। Aspose.Slides स्लाइड‑स्तर थीम ओवरराइड का समर्थन करता है, इसलिए आप स्थानीय थीम को केवल उस स्लाइड पर लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं (via the [SlideThemeManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides.theme/slidethememanager/))।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

[Clone slides](/slides/hi/python-net/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में ले जाएँ। इससे मूल मास्टर, लेआउट, और संबंधित थीम संरक्षित रहते हैं ताकि रूप‑रेखा समान बनी रहे।

**सभी विरासत और ओवरराइड के बाद "प्रभावी" मान कैसे देखें?**

API के ["effective" views](/slides/hi/python-net/shape-effective-properties/) का उपयोग करें जो थीम/रंग/फ़ॉन्ट/इफ़ेक्ट के लिए हल किए गए अंतिम प्रॉपर्टी लौटाते हैं।