---
title: पाइथन में प्रस्तुति पाठ स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/python-net/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ़्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- पाठ फ़्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **परिचय**

यह लेख दर्शाता है कि Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे स्वरूपित किया जाए। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, अनुच्छेद अंतराल, स्वतः‑फ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा नहीं बताया गया है, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। उसकी पहली स्लाइड में पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला अनुच्छेद नीचे दिखाए गए पाठ को सम्मिलित करता है। स्लाइड और आकार दोनों के सूचकांक शून्य‑आधारित हैं। बोल्ड भागों को चुनने वाले उदाहरण प्रभावी स्वरूपण का उपयोग करते हैं, जिनमें विरासत में मिला हुआ बोल्ड स्वरूपण भी शामिल है:

![नमूना पाठ](sample_text.png)

शाब्दिक पाठ या नियमित अभिव्यक्ति मिलानों को खोजने व हाइलाइट करने के लिए देखें [टेक्स्ट खोजें और बदलें](/slides/hi/python-net/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिए [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्के ग्रे हाइलाइट को डिफ़ॉल्ट रूप से सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेते हैं:

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

![धूसर पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भाग** के पृष्ठभूमि रंग को कैसे सेट किया जाए दर्शाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # पाठ भाग के लिए हाइलाइट रंग सेट करें।
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![धूसर पाठ भाग](gray_text_portions.png)

## **पाठ अनुच्छेदों को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) का उपयोग करें। मान केंद्रित, बाएँ‑संजालित, दाएँ‑संजालित, व्यवस्थित आदि हो सकते हैं।

निम्न कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने का तरीका दिखाता है:

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

## **पंक्ति में फ़ॉन्ट संरेखण**

विभिन्न फ़ॉन्ट आकार वाले पाठ भागों को एक पंक्ति में लंबवत रूप से संरेखित करने के लिए [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्ति में संरेखण को नियंत्रित करती है।

निम्न स्व-समाहित उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में समान पाठ 18, 36 और 54 पॉइंट पर विभिन्न फ़ॉन्ट संरेखण के साथ होता है। यह Arial का उपयोग करता है, स्वतः‑फ़िट और रैपिंग को निष्क्रिय करता है, तथा टेक्स्ट फ्रेम को एक पंक्ति के लिए पर्याप्त बड़ा रखता है।

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

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे जरूरी नहीं कि बिल्कुल मिलें। उदाहरण में बड़े अक्षर और एक नीचे‑खिसका हुआ अक्षर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के बीच अंतर दिखाया जा सके। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, उपयोग किए गए अक्षर और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आकार, मार्जिन, लाइन अंतराल, रैपिंग और स्वतः‑फ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) से अलग है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करती है, और [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) से भी, जो आकार के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है। [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) के माध्यम से सुपरस्ट्रिप्ट और सबस्ट्रिप्ट स्वरूपण व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, न कि पैराग्राफ की पंक्तियों के लिए फ़ॉन्ट संरेखण सेट करता है।

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ पारदर्शिता को [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) को सौंपे गए रंग के अल्फ़ा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फ़ा‑चैनल मान है, न कि प्रतिशत पारदर्शिता।

निम्न कोड उदाहरण पूरा **पैराग्राफ** पर पारदर्शिता लागू करने का तरीका दिखाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पाठ के लिए अर्धपारदर्शी काला भराव सेट करें।
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भाग** पर पारदर्शिता लागू करने का तरीका दिखाता है:

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
            # पाठ भाग की पारदर्शिता सेट करें।
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को फैलाने या संकुचित करने के लिए [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) का उपयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करेंगे।

निम्न Python कोड पूरे **पैराग्राफ** में अक्षर अंतराल को बढ़ाने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.paragraph_format.default_portion_format.spacing = 3  # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भाग** में अक्षर अंतराल को बढ़ाने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.portion_format.spacing = 3  # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग निष्क्रिय करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखने वाले पाठ से थोड़ा अधिक कसकर दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्टों के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडरिंग को PowerPoint के अधिक निकट लाने के लिए, प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ भागों के लिए केरनिंग निष्क्रिय कर सकते हैं। इसके लिए [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण प्रथम स्लाइड के प्रथम आकार पर एक टेक्स्ट बॉक्स के साथ "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) को जाँचता है और Roboto का उपयोग करने वाले भागों के लिए 100‑पॉइंट की सीमा सेट करता है। यह 100 पॉइंट से कम आकार के उन भागों के लिए केरनिंग निष्क्रिय कर देता है:

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

सीमा से नीचे के मेल खाते पाठ के लिए यह सेटिंग केरनिंग को रोकती है और Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स पर प्राथमिकता लेता है:

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

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटैलिक और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी स्वरूपण बोल्ड है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # पाठ भाग के लिए फ़ॉन्ट गुण सेट करें।
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पाठ भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्प्लेट टाइपोग्राफी को पुन: उत्पन्न करने या अक्षर ऊँचाई में अंतर की जाँच करने के लिए [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) का उपयोग करें। PowerPoint में, सामान्यीकरण को सक्षम करने से व्यक्तिगत अक्षर ऊर्ध्वाधर रूप से खिंचे या संकुचित होते हैं ताकि वे पाठ भाग के भीतर समान दृश्य ऊँचाई प्राप्त कर सकें। यह विभिन्न फ़ॉन्टों में समान पाठ ऊँचाई की गारंटी नहीं देता।

इस गुण को स्पष्ट रूप से सक्षम या निष्क्रिय करने के लिए [NullableBool.TRUE या FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) सेट करें। `NullableBool.NOT_DEFINED` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि भाग पैराग्राफ के [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) से मान विरासत में ले सके। यह `False` के बराबर नहीं है। विरासत के मान को प्राप्त करने के लिए [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) और [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) का उपयोग करें।

निम्न स्व-समाहित उदाहरण के लिए **Arial** इंस्टॉल होना आवश्यक है। यह दो पाठ ब्लॉक बनाता है जिनमें समान बड़े अक्षर, छोटे अक्षर, नीचे‑खिसके हुए अक्षर और 54 पॉइंट पर उच्चारणयुक्त अक्षर होते हैं। दोनों पैराग्राफ़ डिफ़ॉल्ट रूप से सामान्यीकरण को सक्षम रखते हैं। ऊपर वाला भाग स्पष्ट रूप से इसे निष्क्रिय करता है; नीचे वाला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ अंतराल समान हैं, और तुलना को सुसंगत रखने के लिए रैपिंग और स्वतः‑फ़िट निष्क्रिय हैं। उदाहरण `FALSE: False` और `NOT_DEFINED: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है:

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

नीचे की तुलना सहेजे गए प्रस्तुतीकरण से निर्यातित है। ऊपर की पंक्ति में सामान्यीकरण निष्क्रिय (`FALSE`) है; नीचे की पंक्ति में यह विरासत में मिला हुआ (`NOT_DEFINED` → `True`) है। इस रूप को पुन: उत्पन्न करने के लिए Arial इंस्टॉल रखें।

![Arial 54‑पॉइंट पाठ, ऊपर सामान्यीकरण निष्क्रिय और नीचे विरासत में सामान्यीकरण सक्षम](text_height_normalization.png)

सामान्यीकरण अक्षर ऊँचाई को बदलता है बिना असाइन किए गए [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) मान को बदले, जो फ़ॉन्ट आकार को पॉइंट में निर्दिष्ट करता है। पैराग्राफ का [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) लाइन अंतराल को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम का [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) टेक्स्ट या उसके कंटेनर को फिट करने के तरीके को नियंत्रित करता है। ये सेटिंग्स अलग‑अलग उद्देश्यों की सेवा करती हैं और समग्र लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ स्वरूपण और विरासत के बारे में अधिक जानकारी के लिए देखें [Manage Paragraph](/slides/hi/python-net/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

पाठ भाग पर [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) का उपयोग करके सुधार, रद्द शब्द या पूर्व कीमत को बिना मूल पाठ हटाए दिखाया जा सकता है। इसे [TextStrikethroughType.SINGLE या DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) पर सेट करें ताकि टेक्स्ट पर एक या दो रेखाएँ आएँ।

स्ट्राइकथ्रू हटाने के लिए `TextStrikethroughType.NONE` असाइन करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आस‑पास का स्वरूपण स्ट्राइकथ्रू निर्दिष्ट करे। इसके विपरीत, `TextStrikethroughType.NOT_DEFINED` स्थानीय सेटिंग को अनिर्धारित छोड़ देता है, जिससे भाग पैराग्राफ आदि से स्वरूपण विरासत में ले सकता है। यह स्ट्राइकथ्रू हटाने की गारंटी नहीं देता। परिणामी स्वरूपण, जिसमें विरासत में मिले मान भी शामिल हैं, को पढ़ने के लिए [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) का उपयोग करें।

निम्न स्व‑समाहित उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व मूल्य और वर्तमान मूल्य के लिए अलग‑अलग भाग होते हैं, इसलिए केवल पूर्व मूल्य प्रभावित होता है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः एकल और दोहरी स्ट्राइकथ्रू रहता है। इस गुण को बदलने से पाठ और उसकी अन्य स्वरूपण, जिसमें बोल्ड पूर्व मूल्य शामिल है, संरक्षित रहता है।

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

परिणाम, ऊपर से नीचे तक: कोई स्ट्राइकथ्रू नहीं, एकल स्ट्राइकथ्रू, दोहरी स्ट्राइकथ्रू।

![बिना स्ट्राइकथ्रू, एकल स्ट्राइकथ्रू और दोहरी स्ट्राइकथ्रू वाले पूर्व मूल्य](strikethrough.png)

## **पाठ घूर्णन सेट करें**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) का उपयोग करके आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जा सकता है।

निम्न कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिकक्ष** घुमा देता है:

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

## **ऊर्ध्वाधर पाठ में अंक साइड‑बाय‑साइड दिखाएँ**

दो अंकों के नंबर को ऊर्ध्वाधर जापानी लेबल में साथ रखने के लिए दोनों अंक को एक पाठ भाग में रखें और उस भाग पर [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) सेट करें। उदाहरण दो लेबल बनाता है जिसमें नया प्रस्तुतीकरण का उपयोग करके [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) और 40‑पॉइंट MS Gothic का प्रयोग किया गया है। केवल संख्यात्मक भाग को सौंपा गया [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) मान अलग है।

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint में बायाँ लेबल (`TRUE`) अंक को सीधे और साइड‑बाय‑साइड दिखाता है (和 और 年 के बीच)। दायाँ लेबल (`FALSE`) अंक को 90 डिग्री घड़ी की दिशा में घुमा देता है। दोनों लेबल में आसपास के जापानी अक्षर सीधे बने रहते हैं।

![बाएँ ओर upright अंक और दाएँ ओर घुमे हुए अंक के साथ ऊर्ध्वर लेबल की PowerPoint तुलना](vertical_date.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) का उपयोग करके [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोण सेट किया जा सकता है।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमा देता है:

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

## **पैराग्राफ की लाइन स्पेसिंग नियंत्रित करें**

Aspose.Slides निम्न गुण प्रदान करता है: [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), और [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) ताकि पैराग्राफ स्पेसिंग नियंत्रित की जा सके। इनका उपयोग इस प्रकार है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए धनात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए ऋणात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ के भीतर स्पेसिंग को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

संकीर्ण टेक्स्ट ब्लॉक और उन प्रस्तुतियों में जहाँ लैटिन और ईस्ट एशियन पाठ मिश्रित होते हैं, पैराग्राफ लाइन‑ब्रेकिंग नियम उपयोगी होते हैं। निम्न गुण [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) लैटिन लाइन‑ब्रेकिंग नियम नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से पास के ईस्ट एशियन पाठ और विराम चिह्नों की रैपिंग भी बदल सकती है।
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ईस्ट एशियन लाइन‑ब्रेकिंग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। ये रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक अक्षर नहीं डालते। एक स्पष्ट लाइन‑ब्रेक पैराग्राफ के भीतर नई पंक्ति को उपलब्ध चौड़ाई से स्वतंत्र रूप से शुरू करता है।

निम्न स्व‑समाहित उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चाइनीज़ और लैटिन पाठ सम्मिलित हैं। यह दोनो लाइन‑ब्रेकिंग गुणों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिए, दूसरे सेटिंग को स्थिर रख कर उस गुण के मान को बदलें। उदाहरण में 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ़्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन उपयोग किए गये हैं। [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) को [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ़्रेम आयाम स्थिर रहें।

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

## **हैँगिंग पंक्चुएशन नियंत्रित करें**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) योग्य विराम चिह्नों को पाठ लाइन के दाएँ किनारे से बाहर तक बढ़ने देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैँगिंग इंडेंट से अलग है।

निम्न स्व‑समाहित उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैँगिंग पंक्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक बढ़ता है। तुलना के लिए गुण को [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु अलग लाइन में आता है। रैपिंग सक्षम है और उपलब्ध चौड़ाई स्थिर रखने के लिए ऑटोफ़िट निष्क्रिय है।

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

हर पंक्चुएशन मार्क नहीं हैँग कर सकता। दृश्य परिणाम [फ़ॉन्ट और लेआउट स्थितियों](#control-line-breaking) पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग बदलने से दिखाई देने वाले अंतर को हटाया जा सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) निर्धारित करता है कि जब टेक्स्ट कंटेनर की सीमाओं से अधिक हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग करके आप तय कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो हो या आकार स्वचालित रूप से री‑साइज़ हो। निम्न उदाहरण आकार को उसके टेक्स्ट को फिट करने के लिए री‑साइज़ करता है और परिणाम "autofit_type.pptx" के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

स्वचालित रैपिंग के बाद पंक्तियों की गणना और यह देखने के लिए कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/python-net/manage-paragraph/)। केवल पंक्ति गिनती यह नहीं बताती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) निर्धारित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित हो, उदाहरण के लिए शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को प्रथम आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट टैबुलेशन सेट करें**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) और [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर किए जा सकते हैं। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संजालित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब अक्षर वाले पाठ को प्रभावित करती हैं।

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

![पैराग्राफ टैब](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) प्रदान करता है, जिससे आप एक पाठ भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" की आवश्यकता है, जिसमें प्रथम स्लाइड पर प्रथम आकार के रूप में एक टेक्स्ट बॉक्स हो और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है और प्रूफ़िंग भाषा को Simplified Chinese (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" के रूप में सहेजा जाता है:

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

जब टेम्प्लेट से बहु‑भाषी पाठ को कॉपी किया जाता है, तो दोनों [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) और [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) को बनाए रखें। निम्न स्व‑समाहित उदाहरण स्रोत भाग को US English भाषा और French वैकल्पिक भाषा के साथ बनाता है और नए प्रस्तुतीकरण में एक भाग में पाठ और पहचानकर्ता कॉपी करता है।

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
    # यदि स्रोत में वैकल्पिक भाषा नहीं है, तो None गंतव्य मान को साफ़ कर देता है।
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

विकल्पीय भाषा के बिना स्रोत आज़माने के लिए `"fr-FR"` असाइनमेंट को छोड़ दें। तब वैकल्पिक पहचानकर्ता `None` रहेगा, और वही कॉपी कथन उसकी अनुपस्थिति को बिना डिफ़ॉल्ट मान डाले सुरक्षित रखेगा, यहाँ तक कि गंतव्य में पहले से वैकल्पिक भाषा सेट हो।

ये पहचानकर्ता भाषा मेटाडाटा के रूप में संग्रहीत होते हैं। इन्हें बनाए रखने से यह निर्धारित नहीं होता कि PowerPoint किस शब्दकोश का चयन वर्तनी या व्याकरण जांच के लिए करेगा।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके प्रस्तुतीकरण लोड या बनाते समय बनाए गए पाठ के लिए डिफ़ॉल्ट भाषा निर्धारित करें। निम्न उदाहरण US English को डिफ़ॉल्ट पाठ भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है और उसके पहले पाठ भाग के लिए `en-US` प्रिंट करता है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # पहले भाग की भाषा जाँचें।
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुतीकरण स्तर पर डिफ़ॉल्ट पाठ स्वरूपण लागू करने के लिए [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुतीकरण में शीर्ष‑स्तरीय पैराग्राफ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप से सेट करता है और इसे "default_text_style.pptx" के रूप में सहेजता है। पाठ इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट स्वरूपण उन्हें ओवरराइड न करे।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # शीर्ष स्तर के पैराग्राफ स्वरूप को प्राप्त करें।
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑल‑कैप्स प्रभाव के साथ पाठ निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव को लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखाई देता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसे पाठ भाग को प्राप्त करते हैं, तो लाइब्रेरी पाठ को बिल्कुल उसी तरह लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) जाँचें और जब मान `ALL` हो तो लौटाए गए स्ट्रिंग को अप्परकेस में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें प्रथम स्लाइड पर प्रथम आकार के रूप में एक टेक्स्ट बॉक्स हो। उसके प्रथम पैराग्राफ के प्रथम भाग में "Hello, Aspose!" है, जिस पर All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **All Caps** प्रभाव लागू होने पर पाठ को कैसे निकालें दिखाता है:

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

**मैं स्लाइड पर तालिका में पाठ कैसे बदलूँ?**

स्लाइड पर तालिका में पाठ बदलने के लिए [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटरिटेट करें और प्रत्येक कोशिका को [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) और पैराग्राफ स्वरूपण को [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर पाठ को ग्रेडिएंट रंग कैसे लागू करूँ?**

पाठ पर ग्रेडिएंट रंग लागू करने के लिए [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) का उपयोग करें। [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) को [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।

संबंधित फ़ीचर: [Format text within slides](/slides/hi/features/text-formatting/).