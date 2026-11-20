---
title: Python में प्रस्तुति टेक्स्ट फॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/python-net/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- पंक्ति अंतराल
- ऑटोफ़िट संपत्ति
- टेक्स्ट फ़्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और शैली दें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **सामान्य जानकारी**

यह लेख दिखाता है कि Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फ़ॉर्मेट किया जाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा उल्लेख न किया जाए, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को सम्मिलित करता है। स्लाइड और आकार दोनों की सूचकांक शून्य-आधारित है। उन उदाहरणों में जो बोल्ड भागों को चुनते हैं, प्रभावी फ़ॉर्मेटिंग का उपयोग किया गया है, जिसमें विरासत में प्राप्त बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![उदाहरण पाठ](sample_text.png)

शाब्दिक टेक्स्ट या नियमित अभिव्यक्ति मिलानों को खोजने और हाइलाइट करने हेतु देखें [पाठ खोजें और बदलें](/slides/hi/python-net/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट हाइलाइट रंग को पैराग्राफ के लिए सेट करने हेतु [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाइलाइट डिफ़ॉल्ट रूप में सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट को ओवरराइड करते हैं:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** के लिए पृष्ठभूमि रंग सेट करने का प्रदर्शन करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफों को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने हेतु [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) का उपयोग करें। मान केंद्रित, बाएँ संरेखित, दाएँ संरेखित, पूर्ण संरेखित आदि हो सकते हैं।

निम्न कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने को दर्शाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ की संरेखण को केंद्र में सेट करें।
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

एक ही लाइन में विभिन्न फ़ॉन्ट आकार वाले टेक्स्ट भागों को ऊर्ध्वाधर रूप से संरेखित करने हेतु [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक लाइन के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट के समान टेक्स्ट होते हैं, प्रत्येक का फ़ॉन्ट संरेखण अलग है। यह Arial का उपयोग करता है, ऑटोफ़िट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एक पंक्ति के लिए पर्याप्त बड़ा रखता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![Baseline, Top, Center, Bottom फ़ॉन्ट संरेखण की तुलना (मिश्रित फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे बिल्कुल समान नहीं होते। उदाहरण में एक बड़े अक्षर और एक नीचे जाने वाला भाग दोनों शामिल है ताकि बेसलाइन और नीचे की संरेखण का अंतर दिखाया जा सके। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकार का अंतर परिणाम को प्रभावित करता है। फ्रेम आकार, मार्जिन, लाइन अंतराल, रैपिंग और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; तुलना के लिए समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) से भिन्न है, जो क्षैतिज पैराग्राफ संरेखण नियंत्रित करती है, और [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) से भी, जो आकार के भीतर टेक्स्ट ब्लॉक को ऊर्ध्वाधर रूप से स्थित करती है। [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फ़ॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष स्थानांतरित करती है, बजाय पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण निर्धारित करने के।

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) को सौंपे गए रंग के अल्फा घटक द्वारा नियंत्रित की जाती है। नीचे के उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-मूल्य है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण पूरे **पैराग्राफ** पर पारदर्शिता लागू करने को दर्शाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # टेक्स्ट के लिए अर्ध-पारदर्शी काली भराव सेट करें।
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** पर पारदर्शिता लागू करने को दर्शाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट भाग की पारदर्शिता सेट करें।
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल बढ़ाने या घटाने हेतु [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) का उपयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को सघन करते हैं।

निम्न Python कोड पूरे **पैराग्राफ** में अक्षर अंतराल बढ़ाने को दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.paragraph_format.default_portion_format.spacing = 3  # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट भागों** में अक्षर अंतराल बढ़ाने को दर्शाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.portion_format.spacing = 3  # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए कर्निंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा अधिक टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्टों के लिए कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में PowerPoint के समान रेंडरिंग प्राप्त करने हेतु आप उन टेक्स्ट भागों के लिए कर्निंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण पहले स्लाइड की पहली आकार पर टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों को जाँचता है, जिसमें विरासत में प्राप्त फ़ॉन्ट शामिल हैं, और Roboto का उपयोग करने वाले भागों के लिए 100 पॉइंट थ्रेशहोल्ड सेट करता है। यह 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले मिलते भागों के लिए कर्निंग निष्क्रिय करता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

थ्रेशहोल्ड से नीचे के मिलते टेक्स्ट के लिए यह सेटिंग कर्निंग को रोकती है और PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्टों के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के अधिक निकट लाने में मदद करती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट को ओवरराइड करती है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटैलिक फ़ॉर्मेटिंग और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्प्लेट टाइपोग्राफी को पुनरुत्पादित करने या अक्षर ऊँचाई में अंतर की जांच करने के लिए [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) का उपयोग करें। PowerPoint में, सामान्यीकरण को सक्रिय करने से व्यक्तिगत अक्षरों को ऊर्ध्वाधर रूप से खींचा या संकुचित किया जाता है ताकि वे टेक्स्ट भाग के भीतर एकसमान दृश्यमान ऊँचाई प्राप्त कर सकें। यह विभिन्न फ़ॉन्टों के बीच समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

गुण को स्पष्ट रूप से सक्षम या निष्क्रिय करने के लिए [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) सेट करें। `NullableBool.NOT_DEFINED` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि भाग पैराग्राफ के [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) से विरासत में प्राप्त कर सके। इसका अर्थ `False` नहीं है। रिजॉल्व़्ड बूलियन मान प्राप्त करने के लिए [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) और [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) का उपयोग करें।

निम्न स्व-समावेशी उदाहरण को **Arial** स्थापित होना चाहिए। यह दो टेक्स्ट ब्लॉक बनाता है जिनमें वही बड़े अक्षर, छोटे अक्षर, नीचे जाने वाले भाग और 54 पॉइंट पर उच्चारित अक्षर होते हैं। दोनों पैराग्राफ़ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। शीर्ष भाग स्पष्ट रूप से इसे निष्क्रिय करता है; नीचे वाला भाग इसे विरासत में प्राप्त करता है। फ्रेम आकार, मार्जिन और पैराग्राफ अंतराल समान हैं, रैपिंग और ऑटोफ़िट निष्क्रिय हैं ताकि तुलना सतत रहे। उदाहरण `FALSE: False` और `NOT_DEFINED: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

नीचे की तुलना सहेजी गई प्रस्तुति से निर्यातित है। शीर्ष पंक्ति में सामान्यीकरण निष्क्रिय (`FALSE`) है; नीचे वाली पंक्ति में यह विरासत में प्राप्त सेटिंग (`NOT_DEFINED` → `True`) है। इस रूप को पुन: उत्पन्न करने के लिए Arial स्थापित रखें।

![Arial 54‑पॉइंट टेक्स्ट जिसमें ऊपर सामान्यीकरण निष्क्रिय और नीचे विरासत में प्राप्त सामान्यीकरण सक्षम है](text_height_normalization.png)

सामान्यीकरण फ़ॉन्ट के [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) मान को बदले बिना अक्षर ऊँचाई बदलता है, जो फ़ॉन्ट आकार को पॉइंट में निर्दिष्ट करता है। पैराग्राफ [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) लाइन अंतराल नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) यह तय करता है कि टेक्स्ट या उसका कंटेनर फिट होने के लिये कैसे समायोजित हो। ये सेटिंग्स अलग‑अलग उद्देश्यों की सेवा करती हैं और समग्र लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ फ़ॉर्मेटिंग और विरासत के बारे में अधिक जानने हेतु देखें [पैराग्राफ प्रबंधित करें](/slides/hi/python-net/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

टेक्स्ट भाग पर [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) का उपयोग करके संशोधन, रद्द शब्द या पूर्व कीमतें मूल टेक्स्ट को हटाए बिना दिखायी जा सकती हैं। इसे [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) पर सेट करने से टेक्स्ट पर एक या दो रेखाएँ लगाई जा सकती हैं।

स्ट्राइकथ्रू हटाने के लिए `TextStrikethroughType.NONE` असाइन करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास की फ़ॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करे। इसके विपरीत, `TextStrikethroughType.NOT_DEFINED` स्थानीय सेटिंग को अनपरिभाषित छोड़ देता है, जिससे भाग पैराग्राफ आदि से फ़ॉर्मेटिंग विरासत में ले सकता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामी फ़ॉर्मेटिंग, जिसमें विरासत में प्राप्त मान शामिल हैं, पढ़ने के लिए [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) का उपयोग करें।

निम्न स्व‑समावेशी उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व मूल्य और वर्तमान मूल्य के लिए अलग‑अलग भाग होते हैं, इसलिए केवल पूर्व मूल्य पर प्रभाव पड़ता है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः एकल और दोहरी स्ट्राइकथ्रू बनाए रहती है। इस गुण को बदलने से टेक्स्ट और उसका अन्य फ़ॉर्मेटिंग, जिसमें बोल्ड पूर्व मूल्य भी शामिल है, संरक्षित रहता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ।
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम, शीर्ष से नीचे: कोई स्ट्राइकथ्रू नहीं, एकल स्ट्राइकथ्रू, और दोहरी स्ट्राइकथ्रू।

![बिना स्ट्राइकथ्रू, एकल स्ट्राइकथ्रू, दोहरी स्ट्राइकथ्रू वाले पूर्व मूल्य](strikethrough.png)

## **टेक्स्ट घूर्णन सेट करें**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) का उपयोग करके आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिमुखीकरण सेट किया जाता है।

निम्न कोड उदाहरण आकार में टेक्स्ट अभिमुखीकरण को [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिकूल दिशा में** घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ़्रेम के लिए कस्टम घूर्णन सेट करें**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) का उपयोग करके एक [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोण सेट किया जाता है।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides निम्न प्रॉपर्टीज़ प्रदान करता है: [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), और [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) पैराग्राफ स्पेसिंग को नियंत्रित करने हेतु। इनका उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ के भीतर अंतराल को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्न प्रॉपर्टीज़ [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होती हैं:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) लैटिन लाइन‑ब्रेकिंग नियम नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से सटे ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैपिंग स्थान भी बदल सकते हैं।
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ईस्ट एशियन लाइन‑ब्रेकिंग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम के भीतर स्वतः रैपिंग को सक्षम करता है। वे तब लेआउट को प्रभावित करते हैं जब रैपिंग होती है; वे लाइन‑ब्रेक अक्षर नहीं डालते। एक स्पष्ट लाइन‑ब्रेक पैराग्राफ में नई पंक्ति बनाता है, उपलब्ध चौड़ाई की परवाह किए बिना।

निम्न स्व‑समावेशी उदाहरण चिनी और लैटिन टेक्स्ट वाला संकीर्ण टेक्स्ट ब्लॉक बनाता है। यह दोनों लाइन‑ब्रेकिंग प्रॉपर्टीज़ को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को आज़माने के लिए, वह प्रॉपर्टी बदलें जबकि अन्य सेटिंग्स को स्थिर रखें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन का उपयोग करता है। [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) को [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **हैंगलिंग पंक्चुएशन नियंत्रित करें**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) योग्य विराम चिह्नों को टेक्स्ट लाइन के दाएँ किनारे के बाहर तक विस्तारित करने की अनुमति देता है, बजाय अगले लाइन में स्थित होने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्व‑समावेशी उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैंगलिंग पंक्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक विस्तारित होता है। तुलना के लिए प्रॉपर्टी को [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु अलग लाइन ले लेगा। रैपिंग सक्षम है और ऑटोफ़िट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

सभी विराम चिह्न हैंग नहीं कर सकते। दृश्यमान परिणाम [फ़ॉन्ट और लेआउट स्थितियों](#control-line-breaking) पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग्स बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ़्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं को पार करने पर कैसे व्यवहार करे। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट सिकुड़ता है, बाहर निकलता है या आकार को स्वतः री‑साइज़ करता है। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार री‑साइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

ऑटो‑रैपिंग के बाद पंक्तियों की गिनती और यह देखने के लिए कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, देखें [रेंडर्ड पंक्तियों की गिनती](/slides/hi/python-net/manage-paragraph/)। केवल पंक्तियों की गिनती यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ़्रेम के एंकर को सेट करें**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) आकार के भीतर टेक्स्ट को ऊर्ध्वाधर रूप से कैसे स्थित किया जाए, निर्धारित करता है, उदाहरण के लिये शीर्ष, मध्य या निचला। निम्न उदाहरण टेक्स्ट को पहली आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट टैबुलेशन सेट करें**

पैरा में टैब स्टॉप को कॉन्फ़िगर करने हेतु [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) और [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैरा टैब्स](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) प्रदान करता है, जो टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट करने की अनुमति देता है। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच हेतु उपयोग की जाने वाली भाषा को निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को "1。" में बदलता है, फ़ॉन्ट को SimSun पर सेट करता है, और Simplified Chinese प्रूफिंग भाषा (`zh-CN`) असाइन करता है। फिर परिणाम "proofing_language.pptx" में सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # प्रूफ़िंग भाषा को सरलीकृत चीनी पर सेट करें।
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **भाषा मेटाडाटा कॉपी करें**

जब टेम्प्लेट से बहुभाषीय टेक्स्ट कॉपी किया जाता है, तो दोनों [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) और [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) को संरक्षित करें। निम्न स्व‑समावेशी उदाहरण US English को उसकी भाषा और French को वैकल्पिक भाषा के रूप में सेट करता है, और टेक्स्ट व आइडेंटिफायर को नई प्रस्तुति में एक भाग में कॉपी करता है।

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # यदि स्रोत में वैकल्पिक भाषा नहीं है, तो None मान को गंतव्य मान को साफ़ करता है।
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

वैकल्पिक भाषा के बिना स्रोत को आज़माने के लिये, `"fr-FR"` असाइनमेंट को छोड़ दें। तब वैकल्पिक आइडेंटिफ़ायर `None` रहेगा, और वही कॉपी स्टेटमेंट उसकी अनुपस्थिति को बिना डिफ़ॉल्ट मान डाले संरक्षित करता है, भले ही गंतव्य में पहले वैकल्पिक भाषा सेट हो।

ये आइडेंटिफ़ायर भाषा मेटाडाटा के रूप में संग्रहीत होते हैं। इन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint वर्तनी या व्याकरण जांच के लिये कौन सा शब्दकोश उपयोग करेगा।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके वह डिफ़ॉल्ट भाषा निर्धारित करें जो प्रस्तुति लोड या बनाते समय निर्मित टेक्स्ट पर लागू होगी। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # एक नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # पहले भाग की भाषा जाँचें।
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने हेतु [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ़ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट बनाता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # शीर्ष स्तर के पैराग्राफ फ़ॉर्मेट प्राप्त करें।
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करने पर लाइब्रेरी टेक्स्ट को बिल्कुल वैसा ही वापस करती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मिलान करने हेतु [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) की जाँच करें और यदि मान `ALL` है तो लौटाई गई स्ट्रिंग को बड़े अक्षरों में बदलें।

इस उदाहरण को "sample2.pptx" की आवश्यकता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ के पहले भाग में **All Caps** प्रभाव के साथ "Hello, Aspose!" है, जैसा कि नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण **All Caps** प्रभाव लागू हुए टेक्स्ट को निकालने का प्रदर्शन करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड में टेबल के टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड में टेबल के टेक्स्ट को संशोधित करने हेतु [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से इटरिएट करें और प्रत्येक सेल को [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) तथा पैराग्राफ फ़ॉर्मेटिंग को [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट के लिए ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने हेतु [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) का उपयोग करें। [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) को [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।

संबंधित सुविधा: [स्लाइड में टेक्स्ट फ़ॉर्मेट करें](/slides/hi/features/text-formatting/).