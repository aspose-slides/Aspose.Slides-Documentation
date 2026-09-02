---
title: Python में प्रस्तुति टेक्स्ट को फॉर्मेट करें
linktitle: टेक्स्ट फॉर्मेटिंग
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
- लाइन स्पेसिंग
- ऑटोफिट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण आदि को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फॉर्मेट करने का तरीका दिखाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

नीचे के उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एक टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![नमूना टेक्स्ट](sample_text.png)

शाब्दिक टेक्स्ट या नियमित अभिव्यक्ति मिलान को खोजने और हाइलाइट करने के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/python-net/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) का उपयोग करके आप पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट कर सकते हैं, या व्यक्तिगत टेक्स्ट भागों के लिए [PortionFormat.highlight_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/highlight_color/) का उपयोग करें।

निम्नलिखित कोड उदाहरण **पूरे पैराग्राफ** के पृष्ठभूमि रंग को सेट करने का तरीका दिखाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![स्लेटी पैराग्राफ](gray_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के पृष्ठभूमि रंग को सेट करने का प्रदर्शन करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![स्लेटी टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ को संरेखित करें**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/alignment/) का उपयोग करके आप टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट कर सकते हैं। मान केंद्रित, बाएँ-समर्थित, दाएँ-समर्थित, समानांतर आदि हो सकते हैं।

निम्नलिखित कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ का संरेखण केंद्र में सेट करें।
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **टेक्स्ट की पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता को [PortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/fill_format/) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0-255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे का कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करने का तरीका दिखाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # टेक्स्ट का फ़िल रंग पारदर्शी रंग में सेट करें।
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता लागू करने का तरीका दिखाता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

[BasePortionFormat.spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/spacing/) का उपयोग करके आप टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ा या घटा सकते हैं।

निम्नलिखित Python कोड **पूरे पैराग्राफ** में अक्षर अंतराल को बढ़ाने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.paragraph_format.default_portion_format.spacing = 3  # अक्षर अंतराल का विस्तार करें।

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल को बढ़ाने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.portion_format.spacing = 3  # अक्षर अंतराल का विस्तार करें।

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा अधिक तंग लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट भागों के लिए केरनिंग निष्क्रिय कर सकते हैं। [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

यह सेटिंग मिलते-जुलते टेक्स्ट भागों पर केरनिंग लागू होने से रोकती है और इस PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट के लिए Aspose.Slides रेंडरिंग को PowerPoint की दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

निम्नलिखित कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह सभी भागों में फ़ॉन्ट आकार, बोल्ड, इटैलिक, बिंदुयुक्त अंडरलाइन और Times New Roman फ़ॉन्ट लागू करता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर समान गुण लागू करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **टेक्स्ट का घूर्णन सेट करें**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/text_vertical_type/) का उपयोग करके आप एक आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट कर सकते हैं।

निम्नलिखित कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को `VERTICAL270` सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्षिप्त** घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/rotation_angle/) का उपयोग करके आप एक [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोण सेट कर सकते हैं।

नीचे का कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.space_after](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_before/), और [ParagraphFormat.space_within](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_within/) प्रदान करता है ताकि पैराग्राफ अंतराल को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्नलिखित कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग निर्दिष्ट करने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटोफिट प्रकार सेट करें**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/autofit_type/) निर्धारित करता है कि जब टेक्स्ट उसके कंटेनर की सीमा से बाहर हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग करके आप निर्धारित कर सकते हैं कि टेक्स्ट सिकुड़ना चाहिए, ओवरफ़्लो होना चाहिए, या आकार स्वचालित रूप से बदलना चाहिए।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/anchoring_type/) परिभाषित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित है, जैसे शीर्ष, मध्य, या नीचे।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट टैबुलेशन सेट करें**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_tab_size/) और [ParagraphFormat.tabs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/tabs/) का उपयोग करके आप पैराग्राफ में टैब स्टॉप कॉन्फ़िगर कर सकते हैं।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [PortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/) प्रदान करता है, जिससे आप एक टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित कोड उदाहरण टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट करने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # प्रूफ़िंग भाषा का Id सेट करें।
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके आप प्रस्तुति लोड या बनाते समय बनाए गए टेक्स्ट के लिए डिफ़ॉल्ट भाषा निर्धारित कर सकते हैं।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # पहले भाग की भाषा जांचें।
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए, [Presentation.default_text_style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/default_text_style/) का उपयोग करें।

निम्नलिखित कोड उदाहरण नई प्रस्तुति में सभी स्लाइड्स के टेक्स्ट के लिए 14 pt आकार के साथ डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट करने का तरीका दिखाता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # शीर्ष स्तर का पैराग्राफ फॉर्मेट प्राप्त करें।
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑल-कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखाई देता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक वही स्वरूप में वापस देती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textcaptype/) को देखें और जब मान `ALL` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

मान लें कि हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे का कोड उदाहरण **All Caps** इफ़ेक्ट लागू होने के साथ टेक्स्ट निकालने का तरीका दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

**स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करें?**

स्लाइड पर तालिका में टेक्स्ट को संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [Cell.text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/text_frame/) तथा पैराग्राफ फॉर्मेटिंग को [Paragraph.paragraph_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/paragraph_format/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए, [PortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/fill_format/) का उपयोग करें। [FillFormat.fill_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/fill_type/) को [FillType.GRADIENT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।