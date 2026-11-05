---
title: पायथन में प्रस्तुति टेक्स्ट को स्वरूपित करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/python-net/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट स्टाइल
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घुमाव
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटोफिट प्रॉपर्टी
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को स्वरूपित और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण आदि को कस्टमाइज़ करें।"
---
## **सारांश**

यह लेख दर्शाता है कि Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फॉर्मेट करें। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतर, फ़ॉन्ट गुण, घुमाव, पैराग्राफ स्पेसिंग, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अलग से न कहा गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। उसकी पहली स्लाइड पर पहली आकृति एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाया गया टेक्स्ट रखता है। स्लाइड और आकृति दोनों के सूचकांक शून्य-आधारित हैं। जो उदाहरण बोल्ड भागों का चयन करते हैं वे प्रभावी फॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड फॉर्मेटिंग भी शामिल है:

![नमूना पाठ](sample_text.png)

जब आप लिटरल टेक्स्ट या रेगुलर‑एक्सप्रेशन मैच को खोजकर हाइलाइट करना चाहते हैं, तो देखें [पाठ खोजें और बदलें](/slides/hi/python-net/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने हेतु [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) का उपयोग करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के लिए हल्के ग्रे हाईलाइट को डिफ़ॉल्ट रूप में सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता रखते हैं:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट करें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) का उपयोग करके टेक्स्ट फ्रेम के भीतर पैराग्राफ का संरेखण सेट करें। मान केंद्रित, बाएँ-संरेखित, दाएँ-संरेखित, जस्टिफाइड आदि हो सकता है।

निम्नलिखित कोड उदाहरण दर्शाता है कि पैराग्राफ को **केंद्रीय** कैसे संरेखित करें:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ का संरेखण केंद्र में सेट करें.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

[ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) का उपयोग करके विभिन्न फ़ॉन्ट आकारों के टेक्स्ट भागों को लाइन के भीतर लंबवत रूप से संरेखित करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक लाइन के भीतर संरेखण को नियंत्रित करती है।

निम्नलिखित स्व-निहित उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36, और 54 प्वाइंट पर समान टेक्स्ट है, विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटोफिट और रैपिंग को अक्षम करता है, और टेक्स्ट फ्रेम को एकल लाइन के लिए पर्याप्त बड़ा रखता है।

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

![मिश्रित फ़ॉन्ट आकारों के साथ बेसलाइन, टॉप, सेंटर, और बॉटम फ़ॉन्ट संरेखण की तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स का उपयोग करता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे अनिवार्य रूप से सटीक नहीं मिलते। उदाहरण में एक बड़े अक्षर और एक डिसेंडर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के बीच अंतर दिखाया जा सके। फ़ॉन्ट की उपलब्धता और प्रतिस्थापन, उपयोग किए गए वर्ण, तथा फ़ॉन्ट आकारों का अंतर परिणाम को प्रभावित करते हैं। फ्रेम आकार, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटोफिट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) से भिन्न है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) से, जो टेक्स्ट ब्लॉक को आकृति के भीतर लंबवत रूप से स्थित करता है। [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष स्थानांतरित करती है, बजाय पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट करने के।

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता को [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) को दिए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण दर्शाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू करें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # टेक्स्ट के लिए अर्ध-पारदर्शी काली भराव सेट करें.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता कैसे लागू करें:

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
            # टेक्स्ट भाग की पारदर्शिता सेट करें.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

[BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाया या घटाया जा सकता है। उदाहरण 3 प्वाइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करते हैं।

निम्नलिखित Python कोड दर्शाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल कैसे बढ़ाया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # नोट: चर स्पेसिंग को संकुचित करने के लिए नकारात्मक मान उपयोग करें.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # अक्षर अंतराल बढ़ाएँ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल कैसे बढ़ाया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # नोट: चर स्पेसिंग को संकुचित करने के लिए नकारात्मक मान उपयोग करें.
            portion.portion_format.spacing = 3  # अक्षर अंतराल बढ़ाएँ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कभी-कभी, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट की तुलना में थोड़ा अधिक कसाव दिखा सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को नजरअंदाज़ कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर किए गए आउटपुट को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट भागों के लिए केरनिंग अक्षम कर सकते हैं। [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। इस उदाहरण में पहली स्लाइड पर पहली आकृति के रूप में एक टेक्स्ट बॉक्स वाला "presentation.pptx" आवश्यक है। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिले फ़ॉन्ट भी शामिल हैं, और रोबोटो का उपयोग करने वाले भागों के लिए 100 प्वाइंट की सीमा निर्धारित करता है। यह 100 प्वाइंट से कम फ़ॉन्ट आकार वाले मिलते‑जुलते भागों के लिए केरनिंग अक्षम कर देता है:

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

दिये गये सीमा से नीचे के मेल खाते टेक्स्ट के लिए, यह सेटिंग केरनिंग को रोकती है और उन फ़ॉन्ट्स के लिए Aspose.Slides के रेंडरिंग को PowerPoint के विज़ुअल आउटपुट के साथ संरेखित करने में मदद कर सकती है, जो इस PowerPoint‑विशिष्ट व्यवहार से प्रभावित होते हैं।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्नलिखित उदाहरण पहले पैराग्राफ के डिफ़ॉल्ट फ़ॉन्ट को 12 प्वाइंट Times New Roman पर बोल्ड, इटैलिक और डॉटेड अंडरलाइन फॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट सेटिंग्स पर प्राथमिकता रखती है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्नलिखित उदाहरण 13 प्वाइंट Times New Roman, इटैलिक फ़ॉर्मेटिंग और डॉटेड अंडरलाइन उन भागों पर लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

![टेक्स्ट भागों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी को दोहराते समय या अक्षर ऊँचाई में अंतर की जाँच करते समय [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) का उपयोग करें। PowerPoint में, सामान्यीकरण को सक्षम करने से व्यक्तिगत अक्षर लंबवत रूप से खिंचते या संकुचित होते हैं जिससे वे टेक्स्ट भाग के भीतर एक समान दृश्यमान ऊँचाई प्राप्त करते हैं। यह विभिन्न फ़ॉन्ट्स में समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

नॉर्मलाइज़ेशन को स्पष्ट रूप से सक्षम या अक्षम करने के लिए प्रॉपर्टी को [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) पर सेट करें। `NullableBool.NOT_DEFINED` स्थानीय सेटिंग को अनसेट रहने देता है ताकि भाग अपने मान को, उदाहरण के लिए पैराग्राफ के [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) से विरासत में ले। इसका अर्थ `False` नहीं है। हल किए गए बूलियन मान को प्राप्त करने के लिए [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) और [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) का उपयोग करें।

निम्नलिखित स्व-निहित उदाहरण के लिए **Arial** स्थापित होना आवश्यक है। यह दो टेक्स्ट ब्लॉक बनाता है जिनमें समान बड़े अक्षर, छोटे अक्षर, डिसेंडर और 54 प्वाइंट पर एक्सेंटेड कैरेक्टर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। ऊपर वाला भाग स्पष्ट रूप से इसे अक्षम करता है; नीचे वाला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, रैपिंग और ऑटोफिट अक्षम हैं ताकि तुलना सुसंगत रहे। उदाहरण `FALSE: False` और `NOT_DEFINED: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

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

नीचे की तुलना सहेजे गए प्रस्तुति से निर्यात की गई है। ऊपर की पंक्ति में सामान्यीकरण अक्षम है (`FALSE`); नीचे की पंक्ति में सक्षम सेटिंग विरासत में मिलती है (`NOT_DEFINED` → `True`)। इस स्वरूप को पुनः बनाने के लिए Arial स्थापित रखें।

![Arial 54-प्वाइंट टेक्स्ट जिसमें ऊपर सामान्यीकरण अक्षम है और नीचे विरासत में सामान्यीकरण सक्षम है](text_height_normalization.png)

सामान्यीकरण अक्षर ऊँचाई को बदलता है बिना असाइन किए गए [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) मान को बदले, जो फ़ॉन्ट आकार प्वाइंट में निर्दिष्ट करता है। पैराग्राफ [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) लाइन स्पेसिंग को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) यह निर्धारित करता है कि टेक्स्ट या उसका कंटेनर फिट होने के लिए कैसे समायोजित होता है। ये सेटिंग्स विभिन्न उद्देश्यों की सेवा करती हैं और स्वतंत्र रूप से सम्पूर्ण लेआउट को प्रभावित कर सकती हैं। पैराग्राफ फॉर्मेटिंग और इनहेरिटेंस के बारे में अधिक जानकारी के लिए देखें [Manage Paragraph](/slides/hi/python-net/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

[BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) का उपयोग टेक्स्ट भाग पर संशोधन, रद्द किए गए शब्द या पिछले मूल्यों को मूल टेक्स्ट हटाए बिना दिखाने के लिए किया जा सकता है। टेक्स्ट पर एक या दो रेखाएँ लगाने के लिए इसे [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) पर सेट करें।

स्ट्राइकथ्रू हटाने के लिए `TextStrikethroughType.NONE` असाइन करें। यह प्रभाव को स्पष्ट रूप से अक्षम करता है, भले ही आसपास की फ़ॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करे। इसके मुकाबले, `TextStrikethroughType.NOT_DEFINED` स्थानीय सेटिंग को अनिर्दिष्ट छोड़ देता है, जिससे भाग पैराग्राफ जैसी फ़ॉर्मेटिंग विरासत में ले सकता है। यह यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामी फ़ॉर्मेटिंग, जिसमें विरासत में मिली मान भी शामिल हैं, पढ़ने के लिए [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) का उपयोग करें।

निम्नलिखित स्व-निहित उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पिछले मूल्य और वर्तमान मूल्य के लिए अलग-अलग भाग होते हैं, इसलिए केवल पिछले मूल्य पर असर पड़ता है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में सिंगल और डबल स्ट्राइकथ्रू बना रहता है। इस प्रॉपर्टी को बदलने से टेक्स्ट और उसकी अन्य फ़ॉर्मेटिंग, जिसमें बोल्ड पिछले मूल्य भी शामिल है, सुरक्षित रहती है।

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

    # स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से स्पष्ट रूप से हटाएँ.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, सिंगल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![पिछले मूल्य बिना स्ट्राइकथ्रू के, सिंगल स्ट्राइकथ्रू के साथ, और डबल स्ट्राइकथ्रू के साथ](strikethrough.png)

## **टेक्स्ट रोटेशन सेट करें**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) का उपयोग करके आकृति के भीतर पूर्वनिर्धारित टेक्स्ट ओरिएंटेशन सेट करें।

निम्नलिखित कोड उदाहरण आकृति में टेक्स्ट ओरिएंटेशन को [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री विपरीत घड़ी की दिशा में** घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम्स के लिए कस्टम रोटेशन सेट करें**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) का उपयोग करके [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) के लिए कस्टम रोटेशन एंगल सेट करें।

नीचे दिया गया कोड उदाहरण आकृति के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) और [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन प्रॉपर्टी का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को प्वाइंट में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के भीतर स्पेसिंग को लाइन ऊँचाई के 200% (डबल स्पेसिंग) पर सेट करता है:

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

पैराग्राफ लाइन-ब्रेकिंग नियम संकीर्ण टेक्स्ट ब्लॉकों और लैटिन तथा ईस्ट एशियाई टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्नलिखित प्रॉपर्टी [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होती हैं:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) लैटिन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से निकटवर्ती ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैप स्थान भी बदल सकते हैं।
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ईस्ट एशियन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। रैपिंग होने पर ये लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरक्टर नहीं डालते। स्पष्ट लाइन ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ में नई लाइन बनाता है।

निम्नलिखित स्व-निहित उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट शामिल है। यह दोनों लाइन‑ब्रेकिंग प्रॉपर्टी को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिए, उस प्रॉपर्टी का मान बदलें जबकि अन्य सेटिंग्स को स्थिर रखें। उदाहरण 24 प्वाइंट Arial और SimSun का उपयोग करता है, 160 प्वाइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ। [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) को [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग पंक्चुएशन नियंत्रित करें**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) योग्य विराम चिह्न को टेक्स्ट लाइन के दाएँ किनारे से बाहर विस्तारित करने देता है, बजाय अगले लाइन में स्थान पाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्नलिखित स्व-निहित उदाहरण 100 प्वाइंट चौड़े टेक्स्ट फ्रेम में हैंगिंग पंक्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24 प्वाइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम पूर्णविराम "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर विस्तारित होता है। तुलना के लिए प्रॉपर्टी को [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ, पूर्णविराम एक अलग लाइन लेता है। रैपिंग सक्षम है और ऑटोफिट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं किया जा सकता। दृश्यमान परिणाम [फ़ॉन्ट और लेआउट शर्तों](#control-line-breaking) पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटोफिट सेटिंग्स बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम्स के लिए ऑटोफिट प्रकार सेट करें**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) निर्धारित करता है कि कंटेनर की सीमाओं से टेक्स्ट बाहर निकलने पर वह कैसे व्यवहार करता है। इसे उपयोग करके नियंत्रित करें कि टेक्स्ट छोटा हो, ओवरफ़्लो करे, या आकृति को स्वचालित रूप से आकार बदले। निम्नलिखित उदाहरण आकृति को उसके टेक्स्ट के अनुरूप आकार बदलने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

स्वचालित रैपिंग के बाद लाइनों की संख्या गिनने और यह देखने के लिए कि टेक्स्ट या आकृति की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/python-net/manage-paragraph/). केवल लाइन गिनती यह नहीं बताती कि टेक्स्ट कंटेनर से बाहर निकलता है या नहीं।

## **टेक्स्ट फ्रेम्स के एंकर को सेट करें**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) निर्धारित करता है कि टेक्स्ट आकृति के भीतर लंबवत कैसे स्थित हो, जैसे शीर्ष, मध्य, या नीचे। निम्नलिखित उदाहरण टेक्स्ट को पहली आकृति के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट टैबुलेशन सेट करें**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) और [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करें। निम्नलिखित उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 प्वाइंट पर सेट करता है और 30 प्वाइंट पर बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर युक्त टेक्स्ट को प्रभावित करती हैं।

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

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) प्रदान करता है, जिससे आप टेक्स्ट भाग की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में स्पेलिंग और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित उदाहरण के लिए "presentation.pptx" आवश्यक है, जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक टेक्स्ट बॉक्स और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरल चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। यह परिणाम "proofing_language.pptx" में सहेजता है:

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

    # प्रमाणन भाषा को सरल चीनी में सेट करें.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए गए टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित करें। निम्नलिखित उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के साथ एक प्रस्तुति बनाता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # टेक्स्ट के साथ नई आयताकार आकृति जोड़ें.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # पहले भाग की भाषा जाँचें.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए, [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) का उपयोग करें।

निम्नलिखित उदाहरण नई प्रस्तुति में शीर्ष‑स्तर पैराग्राफ के लिए 14 प्वाइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फॉर्मेटिंग उन्हें ओवरराइड न करे।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में, **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखाई देता है, भले ही इसे मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल करने के लिए, [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) जाँचें और जब मान `ALL` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहली आकृति के रूप में एक टेक्स्ट बॉक्स हो। उसके पहले पैराग्राफ की पहली भाग में "Hello, Aspose!" है, जिस पर All Caps इफ़ेक्ट लागू है, जैसा कि नीचे दिखाया गया है।

![All Caps इफ़ेक्ट](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि **All Caps** इफ़ेक्ट लागू होने पर टेक्स्ट को कैसे निकालें:

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

**मैं स्लाइड पर तालिका में टेक्स्ट कैसे संशोधित करूँ?**

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटरेट करें और प्रत्येक कोशिका को [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) तथा पैराग्राफ फॉर्मेटिंग को [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) का उपयोग करें। [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) को [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।

[स्लाइड्स के भीतर टेक्स्ट फॉर्मेट करें](/slides/hi/features/text-formatting/)।