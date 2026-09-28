---
title: Python में प्रस्तुति पाठ को फ़ॉर्मेट करें
linktitle: पाठ फ़ॉर्मेटिंग
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
- पाठ घुमाव
- घुमाव कोण
- पाठ फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for Python via .NET का उपयोग करके पाठ को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **सारांश**

यह लेख Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने का तरीका दिखाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर स्पेसिंग, फ़ॉन्ट गुण, घुमाव, पैराग्राफ स्पेसिंग, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

यदि अन्यथा उल्लेख न किया गया हो, तो उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को शामिल करता है। स्लाइड और आकार दोनों के इंडेक्स शून्य-आधारित हैं। मोटा भाग चुनने वाले उदाहरण प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला मोटा फ़ॉर्मेटिंग भी शामिल है:

![उदाहरण टेक्स्ट](sample_text.png)

शाब्दिक टेक्स्ट या नियमित-व्यक्तिक अभिव्यक्ति मेल को खोजने और हाईलाइट करने के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/python-net/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) का उपयोग करके पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट किया जाता है, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/highlight_color/) का उपयोग किया जाता है।

निम्न उदाहरण पहले पैराग्राफ के डिफ़ॉल्ट के रूप में हल्का ग्रे हाइलाइट सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर अधिमान्य होते हैं:

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

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** के लिए पृष्ठभूमि रंग कैसे सेट करें:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट हिस्से के लिए हाइलाइट रंग सेट करें.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ग्रे टेक्स्ट हिस्से](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ संरेखित करें**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/alignment/) का उपयोग करके टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट किया जाता है। मान केंद्रित, बाएँ-समर्थित, दाएँ-समर्थित, न्यायसंगत आदि हो सकते हैं।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ की संरेखण को केंद्र में सेट करें.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट पारदर्शिता [BasePortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/fill_format/) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित की जाती है। नीचे के उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # टेक्स्ट के लिए अर्द्धपारदर्शी काले फ़िल को सेट करें.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर पारदर्शिता कैसे लागू की जाए:

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
            # टेक्स्ट हिस्से की पारदर्शिता सेट करें.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी टेक्स्ट हिस्से](transparent_text_portions.png)

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

[BasePortionFormat.spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/spacing/) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को बढ़ाया या घटाया जा सकता है। उदाहरण 3 पॉइंट की स्पेसिंग जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करते हैं।

निम्न Python कोड दिखाता है कि **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग कैसे बढ़ाई जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # अक्षर अंतराल को बढ़ाएँ.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** में कैरेक्टर स्पेसिंग कैसे बढ़ाई जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
            portion.portion_format.spacing = 3  # अक्षर अंतराल को बढ़ाएँ.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट हिस्सों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशेष फ़ॉन्ट्स के लिए केरनिंग बंद करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा अधिक कसा हुआ लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, आप उन फ़ॉन्ट्स को उपयोग करने वाले टेक्स्ट हिस्सों के लिए केरनिंग बंद कर सकते हैं। [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण "presentation.pptx" को पहले स्लाइड के पहले आकार में टेक्स्ट बॉक्स के साथ आवश्यक करता है। यह प्रभावी फ़ॉन्ट नामों, जिसमें विरासत में मिले फ़ॉन्ट भी शामिल हैं, को जांचता है और Roboto का उपयोग करने वाले हिस्सों के लिए 100 पॉइंट की सीमा सेट करता है। यह 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले मेल खाने वाले हिस्सों के लिए केरनिंग को बंद कर देता है:

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

सीमा से नीचे के मेल खाने वाले टेक्स्ट के लिए यह सेटिंग केरनिंग को रोकती है और फ़ॉन्ट और लेआउट स्थितियों के आधार पर Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ बेहतर संरेखित करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) या व्यक्तिगत हिस्सों पर [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न उदाहरण पहला पैराग्राफ का डिफ़ॉल्ट फ़ॉन्ट 12‑पॉइंट Times New Roman बोल्ड, इटैलिक और डॉटेड अंडरलाइन फॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट पर अधिमान्य होती है:

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

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक फॉर्मेटिंग और डॉटेड अंडरलाइन को उन हिस्सों पर लागू करता है जिनकी प्रभावी फॉर्मेटिंग बोल्ड है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट हिस्से के लिए फ़ॉन्ट गुण सेट करें.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट हिस्सों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट घुमाव सेट करें**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/text_vertical_type/) का उपयोग करके आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जाता है।

निम्न कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लॉकवाइस** घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट घुमाव](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घुमाव सेट करें**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/rotation_angle/) का उपयोग करके [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के लिए कस्टम घुमाव कोण सेट किया जाता है।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइस घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![कस्टम टेक्स्ट घुमाव](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.space_after](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_before/), और [ParagraphFormat.space_within](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_within/) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

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

पैराग्राफ लाइन‑ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉकों और लैटिन तथा ईस्ट एशियन टेक्स्ट के मिश्रण वाले प्रस्तुतियों में उपयोगी होते हैं। ये गुण [ParagraphFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [latin_line_break](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/latin_line_break/) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैपिंग स्थान भी बदल सकता है।
- [east_asian_line_break](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/east_asian_line_break/) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/wrap_text/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक अक्षर नहीं डालते। एक स्पष्ट लाइन ब्रेक पैराग्राफ के भीतर नई लाइन को उपलब्ध चौड़ाई से स्वतंत्र रूप से बनाता है।

निम्न स्वनिर्भर उदाहरण एक संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट शामिल है। यह दोनों लाइन‑ब्रेकिंग गुण स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम को आज़माने के लिए, दूसरे सेटिंग को स्थिर रखते हुए उस गुण का मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun को 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ उपयोग करता है। [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/autofit_type/) को [TextAutofitType.NONE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग पंक्चर नियंत्रण**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/hanging_punctuation/) योग्य विराम चिह्नों को टेक्स्ट लाइन के दाएँ किनारे से बाहर निकलने देता है, बजाय अगले लाइन में स्थित होने के। यह पूरे पैराग्राफ पर लागू होता है और हेंजिंग इंडेंट से अलग है।

निम्न स्वनिर्भर उदाहरण 100‑पॉइंट चौड़ी टेक्स्ट फ़्रेम में हैंगिंग पंक्चर को सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्ट‑फ़्रेम मार्जिन के साथ, अंतिम पूर्ण विराम "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर निकलता है। तुलना के लिए प्रॉपर्टी को [NullableBool.FALSE](https://reference.aspose.com/slides/hi/python-net/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ, पूर्ण विराम एक अलग लाइन में occupy करता है। रैपिंग सक्षम है और उपलब्ध चौड़ाई को स्थिर रखने के लिए ऑटोफ़िट निष्क्रिय है।

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

हर विराम चिह्न हैंग नहीं कर सकता। दृश्य परिणाम फ़ॉन्ट और लेआउट स्थितियों पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग बदलने से दिखाई देने वाला अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/autofit_type/) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं को पार करने पर कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो हो या आकार को स्वचालित रूप से री‑साइज़ करे। निम्न उदाहरण आकार को उसके टेक्स्ट फ़िट करने के लिए री‑साइज़ करता है और परिणाम "autofit_type.pptx" में सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

स्वचालित रैपिंग के बाद लाइनों की गिनती और टेक्स्ट या आकार की चौड़ाई से परिणाम कैसे बदलता है, जानने के लिए देखें [भेजे गए लाइनों की गिनती देखें](/slides/hi/python-net/manage-paragraph/)। केवल लाइनों की गिनती यह नहीं दर्शाती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम के एंकर सेट करें**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/anchoring_type/) निर्धारित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित हो, उदाहरण के लिए शीर्ष, मध्य या नीचे। नीचे दिया गया उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट टैबुलेशन सेट करें**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_tab_size/) और [ParagraphFormat.tabs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/tabs/) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर किए जा सकते हैं। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर एक बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

Aspose.Slides [BasePortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/language_id/) प्रदान करता है, जिससे आप टेक्स्ट हिस्से की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण "presentation.pptx" को आवश्यकता करता है, जिसमें पहली स्लाइड के पहले आकार में एक टेक्स्ट बॉक्स और कम से कम एक पैराग्राफ हो। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफ़िंग भाषा (`zh-CN`) सौंपता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

    # प्रूफ़िंग भाषा को सरल चीनी पर सेट करें.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाये गए टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित की जा सकती है। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करके एक प्रस्तुति बनाता है, टेक्स्ट बॉक्स जोड़ता है, और पहले टेक्स्ट हिस्से के लिए `en-US` प्रिंट करता है।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # नया आयताकार आकार टेक्स्ट के साथ जोड़ें.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # पहले हिस्से की भाषा जांचें.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [Presentation.default_text_style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/default_text_style/) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तरीय पैराग्राफ़ों के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

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

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट हिस्सा प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी तरह लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textcaptype/) को जांचें और जब मान `ALL` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

यह उदाहरण "sample2.pptx" को आवश्यकता करता है, जिसमें पहली स्लाइड के पहले आकार में एक टेक्स्ट बॉक्स हो। उसके पहले पैराग्राफ़ के पहले हिस्से में "Hello, Aspose!" है जिसमें All Caps इफ़ेक्ट लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू होने पर टेक्स्ट कैसे निकाला जाए:

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

## **FAQ**

**मैं स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित कर सकता हूँ?**

स्लाइड पर तालिका में टेक्स्ट को संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) का उपयोग करें। प्रत्येक सेल को [Cell.text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/text_frame/) के माध्यम से अपडेट करें और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph.paragraph_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/paragraph_format/) के माध्यम से बदलें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू कर सकता हूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [BasePortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/fill_format/) का उपयोग करें। [FillFormat.fill_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/fill_type/) को [FillType.GRADIENT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।