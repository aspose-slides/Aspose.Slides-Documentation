---
title: Python में प्रेज़ेंटेशन टेक्स्ट को फॉर्मेट करें
linktitle: टेक्स्ट फॉर्मेटिंग
type: docs
weight: 50
url: /hi/python-net/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट बैकग्राउंड
- टेक्स्ट पारदर्शिता
- कैरेक्टर स्पेसिंग
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट रोटेशन
- रोटेशन एंगल
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट प्रॉपर्टी
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **परिचय**

यह लेख दिखाता है कि Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फॉर्मेट किया जाता है। इसमें बैकग्राउंड रंग, पारदर्शिता, कैरेक्टर स्पेसिंग, फ़ॉन्ट गुण, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

नीचे के उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एक ही टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![उदाहरण टेक्स्ट](sample_text.png)

शाब्दिक टेक्स्ट या रेगुलर‑एक्सप्रेशन मिलान को खोजने और हाइलाइट करने के लिए, देखें [पाठ खोजें और बदलें](/slides/hi/python-net/search-and-replace-text/)।

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

डिफ़ॉल्ट पैराग्राफ हाइलाइट रंग सेट करने के लिए [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [PortionFormat.highlight_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/highlight_color/) का उपयोग करें।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** के लिए बैकग्राउंड रंग कैसे सेट किया जाए:

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

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे का कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** के लिए बैकग्राउंड रंग कैसे सेट किया जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट हिस्से के लिए हाइलाइट रंग सेट करें।
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![ग्रे टेक्स्ट हिस्से](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ संरेखित करें**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/alignment/) का उपयोग करके टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट किया जा सकता है। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, जस्टिफ़ाइड आदि हो सकते हैं।

नीचे दिया गया कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पैराग्राफ की संरेखण को केंद्र में सेट करें।
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

टेक्स्ट की पारदर्शिता को [PortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/fill_format/) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि प्रतिशत।

नीचे का कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** में पारदर्शिता कैसे लागू की जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # टे्क्स्ट का फ़िल रंग पारदर्शी रंग में सेट करें।
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

नीचे का कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** में पारदर्शिता कैसे लागू की जाए:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट हिस्से की पारदर्शिता सेट करें।
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी टेक्स्ट हिस्से](transparent_text_portions.png)

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

टेक्स्ट बॉक्स में कैरेक्टर्स के बीच स्पेसिंग को विस्तारित या घटाने के लिए [BasePortionFormat.spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/spacing/) का उपयोग करें।

नीचे दिया गया Python कोड दिखाता है कि **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग कैसे विस्तारित की जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # नोट: कैरेक्टर स्पेसिंग को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.paragraph_format.default_portion_format.spacing = 3  # कैरेक्टर स्पेसिंग बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

नीचे का कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** में कैरेक्टर स्पेसिंग कैसे विस्तारित की जाए:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # नोट: कैरेक्टर स्पेसिंग को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.portion_format.spacing = 3  # कैरेक्टर स्पेसिंग बढ़ाएँ।

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट हिस्सों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए टेक्स्ट से थोड़ा अधिक तंग लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, उन टेक्स्ट हिस्सों के लिए केरनिंग अक्षम कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग कर रहे हैं। [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

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

यह सेटिंग मिलते‑जुलते टेक्स्ट हिस्सों पर केरनिंग लागू होने से रोकती है और प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद करती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) के माध्यम से या व्यक्तिगत हिस्सों पर [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

नीचे दिया गया कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट को सभी हिस्सों पर लागू करता है।

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

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर समान गुण लागू करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # टेक्स्ट हिस्से के लिए फ़ॉन्ट गुण सेट करें।
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट हिस्सों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/text_vertical_type/) का उपयोग करके शकल के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जा सकता है।

नीचे दिया गया कोड उदाहरण शकल में टेक्स्ट अभिविन्यास को `VERTICAL270` पर सेट करता है, जिससे टेक्स्ट **90 डिग्री उल्टी दिशा में** घुमता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम रोटेशन सेट करें**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/rotation_angle/) का उपयोग करके किसी [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के लिए कस्टम रोटेशन एंगल सेट किया जा सकता है।

नीचे का कोड उदाहरण शकल के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.space_after](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_before/), और [ParagraphFormat.space_within](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_within/) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

नीचे दिया गया कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग कैसे निर्दिष्ट की जाए दिखाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पैराग्राफ की लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/autofit_type/) निर्धारित करता है कि टेक्स्ट अपने कंटेनर की सीमाओं को पार करने पर कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट सिकुड़े, ओवरफ़्लो हो, या शकल को स्वतः रिसाइज़ करे।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

ऑटोमैटिक रैपिंग के बाद लाइनों की गिनती और शकल या टेक्स्ट की चौड़ाई में परिवर्तन देखना है तो देखें [रेंडर किए गए लाइनों की गिनती](/slides/hi/python-net/manage-paragraph/)। केवल लाइनों की गिनती यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/anchoring_type/) यह निर्धारित करता है कि शकल के भीतर टेक्स्ट लंबवत रूप से कहाँ स्थित होगा, जैसे ऊपर, मध्य या नीचे।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट टैबुलेशन सेट करें**

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_tab_size/) और [ParagraphFormat.tabs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/tabs/) का उपयोग करें।

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

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [PortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/) प्रदान करता है, जिससे आप किसी टेक्स्ट हिस्से के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में स्पेलिंग और ग्रामर जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

नीचे दिया गया कोड उदाहरण दिखाता है कि टेक्स्ट हिस्से के लिए प्रूफिंग भाषा कैसे सेट की जाए:

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

    # प्रूफिंग भाषा का Id सेट करें।
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए जाने वाले टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # एक नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # पहले हिस्से की भाषा जाँचें।
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए [Presentation.default_text_style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/default_text_style/) का उपयोग करें।

नीचे दिया गया कोड उदाहरण दिखाता है कि नई प्रस्तुति में सभी स्लाइड्स के लिए 14 pt आकार के डिफ़ॉल्ट बोल्ड फ़ॉन्ट को कैसे सेट किया जाए।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # टॉप लेवल पैराग्राफ फॉर्मेट प्राप्त करें।
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से स्लाइड पर टेक्स्ट बड़े अक्षरों में दिखता है, भले ही मूल रूप से वह छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides से ऐसा टेक्स्ट हिस्सा प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी तरह लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textcaptype/) को जांचें और जब मान `ALL` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे का कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू हुए टेक्स्ट को कैसे निकालें:

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

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिए, [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) का उपयोग करें। सेल्स के माध्यम से इटरेट करें और प्रत्येक सेल को [Cell.text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/text_frame/) तथा पैराग्राफ फॉर्मेटिंग को [Paragraph.paragraph_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/paragraph_format/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [PortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/fill_format/) का प्रयोग करें। [FillFormat.fill_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/fill_type/) को [FillType.GRADIENT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा और पारदर्शिता को कॉन्फ़िगर करें।