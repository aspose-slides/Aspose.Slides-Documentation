---
title: Python में प्रस्तुति पाठ को फॉर्मेट करें
linktitle: पाठ फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/python-net/text-formatting/
keywords:
- पाठ हाइलाइट
- नियमित अभिव्यक्ति
- अनुच्छेद संरेखित करना
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर स्पेसिंग
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
- पाठ फ्रेम
- लाइन स्पेसिंग
- ऑटॉफिट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण आदि को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट करने के तरीके को दिखाता है। इसमें हाइलाइटिंग, पृष्ठभूमि रंग, पारदर्शिता, अक्षर स्पेसिंग, फ़ॉन्ट गुण, घुमाव, अनुच्छेद स्पेसिंग, ऑटॉफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स शामिल हैं।

निम्नलिखित उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एक ही टेक्स्ट बॉक्स है और उसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

## **पाठ को हाइलाइट करें**

जब आपको टेक्स्ट फ़्रेम में किसी विशिष्ट नमूने से मिलते हुए पाठ को हाइलाइट करना हो, तो आप [TextFrame.highlight_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_text/) मेथड का उपयोग करें। यह मेथड मिलते हुए पाठ खंडों पर हाइलाइट रंग लागू करता है और इसे [TextSearchOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textsearchoptions/) के साथ उपयोग करके खोज के तरीके को नियंत्रित किया जा सकता है, जैसे कि केवल पूरे शब्दों को मिलाना।

नीचे का कोड उदाहरण सभी **"try"** अक्षरों को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # पहली स्लाइड से पहला आकार प्राप्त करें।
    shape = presentation.slides[0].shapes[0]

    # आकार में शब्द "try" को हाइलाइट करें।
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # आकार में शब्द "to" को हाइलाइट करें।
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![हाइलाइट किया गया पाठ](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके पाठ को हाइलाइट करें**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/highlight_regex/) मेथड नियमित अभिव्यक्ति द्वारा पाए गए पाठ मिलानों को हाइलाइट करता है। Python में यह API [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) पर उपलब्ध है।

नीचे का कोड उदाहरण सभी उन शब्दों को हाइलाइट करता है जिनमें **सात या अधिक अक्षर** हैं:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # सात या अधिक अक्षर वाले सभी शब्दों को हाइलाइट करें।
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![नियमित अभिव्यक्ति का उपयोग करके हाइलाइट किया गया पाठ](highlighted_text_using_regex.png)

## **पाठ पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट हाइलाइट रंग सेट करने के लिए आप [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) का उपयोग कर सकते हैं, या व्यक्तिगत पाठ भागों के लिए [PortionFormat.highlight_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/highlight_color/) का उपयोग कर सकते हैं।

नीचे का कोड उदाहरण **पूरे अनुच्छेद** के पृष्ठभूमि रंग को सेट करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # पूरे अनुच्छेद के लिए हाइलाइट रंग सेट करें।
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![धूसर अनुच्छेद](gray_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** के पृष्ठभूमि रंग को सेट करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

टेक्स्ट फ़्रेम के भीतर अनुच्छेद संरेखण सेट करने के लिए आप [ParagraphFormat.alignment](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/alignment/) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, समायोजित आदि हो सकते हैं।

नीचे का कोड उदाहरण **केंद्र** में अनुच्छेद को संरेखित करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # अनुच्छेद की संरेखण को केंद्र में सेट करें।
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![संरेखित अनुच्छेद](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ पारदर्शिता को [PortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/fill_format/) को सौंपे गये रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` ARGB अल्फा‑चैनल मान है 0‑255 सीमा में, न कि पारदर्शिता प्रतिशत।

नीचे का कोड उदाहरण **पूरे अनुच्छेद** पर पारदर्शिता लागू करता है:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # टेक्स्ट का भराव रंग पारदर्शी रंग में सेट करें।
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर पारदर्शिता लागू करता है:

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

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर स्पेसिंग सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच स्पेसिंग को विस्तारित या घटाने के लिए आप [BasePortionFormat.spacing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/spacing/) का उपयोग करें।

नीचे का Python कोड **पूरे अनुच्छेद** में अक्षर स्पेसिंग को विस्तारित करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # नोट: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.paragraph_format.default_portion_format.spacing = 3  # अक्षर स्पेसिंग को बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![अनुच्छेद में अक्षर स्पेसिंग](character_spacing_in_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** में अक्षर स्पेसिंग को विस्तारित करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # नोट: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.portion_format.spacing = 3  # अक्षर स्पेसिंग को बढ़ाएँ।

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पाठ भागों में अक्षर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए पाठ से थोड़ा अधिक कसा हुआ दिख सकता है। यह इसलिए होता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को नजरअंदाज़ कर सकता है, भले ही फ़ॉन्ट में मान्य केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्रिय हो।

ऐसे मामलों में रेंडर किए गए आउटपुट को PowerPoint के करीब लाने के लिए आप उन फ़ॉन्ट्स का उपयोग करने वाले पाठ भागों के लिए केरनिंग को अक्षम कर सकते हैं। [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

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

यह सेटिंग मेल खाते पाठ भागों पर केरनिंग को लागू होने से रोकती है और उन फ़ॉन्ट्स के लिए Asp Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट से अधिक मिलाने में मदद करती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को अनुच्छेद स्तर पर [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_portion_format/) के माध्यम से या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) के माध्यम से सेट किया जा सकता है।

नीचे का कोड पूरे अनुच्छेद के लिए फ़ॉन्ट और पाठ शैली सेट करता है: यह सभी भागों में फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट लागू करता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # अनुच्छेद के लिए फ़ॉन्ट गुण सेट करें।
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![अनुच्छेद के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर समान गुण लागू करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

![पाठ भागों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ घुमाव सेट करें**

आप किसी आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/text_vertical_type/) का उपयोग कर सकते हैं।

नीचे का कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को `VERTICAL270` पर सेट करता है, जो पाठ को **90 डिग्री प्रतिकूल दिशा में** घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![पाठ घुमाव](text_rotation.png)

## **पाठ फ्रेम्स के लिए कस्टम घुमाव सेट करें**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/rotation_angle/) का उपयोग करके आप किसी [TextFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframe/) के लिए कस्टम घुमाव कोण सेट कर सकते हैं।

नीचे का कोड आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![कस्टम पाठ घुमाव](custom_text_rotation.png)

## **अनुच्छेदों की लाइन स्पेसिंग सेट करें**

Aspose.Slides अनुच्छेद स्पेसिंग को नियंत्रित करने के लिए [ParagraphFormat.space_after](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_before/), और [ParagraphFormat.space_within](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/space_within/) प्रदान करता है। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान प्रयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान प्रयोग करें।

नीचे का कोड उदाहरण अनुच्छेद के भीतर लाइन स्पेसिंग को निर्दिष्ट करता है:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

परिणाम:

![अनुच्छेद के भीतर लाइन स्पेसिंग](line_spacing.png)

## **पाठ फ्रेम्स के लिए ऑटॉफिट प्रकार सेट करें**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/autofit_type/) निर्धारित करता है कि जब पाठ अपने कंटेनर की सीमाओं से अधिक हो जाए तो उसका व्यवहार क्या होगा। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि पाठ छोटा हो, ओवरफ़्लो हो, या आकार को स्वचालित रूप से पुनः आकार दिया जाए।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **पाठ फ्रेम्स की एंकर सेट करें**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textframeformat/anchoring_type/) निर्धारित करता है कि आकार के भीतर टेक्स्ट को लंबवत रूप से कैसे स्थित किया जाए, उदाहरण के लिए शीर्ष, मध्य, या नीचे।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **पाठ टैबुलेशन सेट करें**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/default_tab_size/) और [ParagraphFormat.tabs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraphformat/tabs/) का उपयोग करके आप अनुच्छेद में टैब स्टॉप कॉन्फ़िगर कर सकते हैं।

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

![अनुच्छेद टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [PortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/language_id/) प्रदान करता है, जो आपको किसी पाठ भाग के लिए प्रूफ़िंग भाषा सेट करने की अनुमति देता है। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

नीचे का कोड उदाहरण किसी पाठ भाग के लिए प्रूफ़िंग भाषा सेट करता है:

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

    # प्रूफ़िंग भाषा के Id को सेट करें।
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके आप प्रस्तुति लोड या बनाते समय बनाये गये पाठ की डिफ़ॉल्ट भाषा निर्धारित कर सकते हैं।

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # टेक्स्ट के साथ नया आयताकार आकार जोड़ें।
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # पहले भाग की भाषा जांचें।
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **डिफ़ॉल्ट पाठ शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट पाठ फ़ॉर्मेटिंग लागू करने के लिए आप [Presentation.default_text_style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/default_text_style/) का उपयोग करें।

नीचे का कोड उदाहरण नई प्रस्तुति में सभी स्लाइडों के पाठ के लिए 14 pt आकार का डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट करता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # शीर्ष स्तर का अनुच्छेद फ़ॉर्मेट प्राप्त करें।
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑल‑कैप्स प्रभाव के साथ पाठ निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से पाठ स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा पाठ भाग प्राप्त करते हैं, तो लाइब्रेरी पाठ को उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ के साथ मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/textcaptype/) की जाँच करें और यदि मान `ALL` है तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल कैप्स प्रभाव](all_caps_effect.png)

नीचे का कोड उदाहरण **All Caps** प्रभाव लागू किए गए पाठ को निकालता है:

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

**स्लाइड पर तालिका में पाठ को कैसे संशोधित करें?**

तालिका में पाठ संशोधित करने के लिए आप [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [Cell.text_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/cell/text_frame/) के माध्यम से अपडेट करें तथा अनुच्छेद फ़ॉर्मेट को [Paragraph.paragraph_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/paragraph_format/) के माध्यम से बदलें।

**PowerPoint स्लाइड में पाठ पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए आप [PortionFormat.fill_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/fill_format/) का उपयोग करें। [FillFormat.fill_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fillformat/fill_type/) को [FillType.GRADIENT](https://reference.aspose.com/slides/hi/python-net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा एवं पारदर्शिता को कॉन्फ़िगर करें।