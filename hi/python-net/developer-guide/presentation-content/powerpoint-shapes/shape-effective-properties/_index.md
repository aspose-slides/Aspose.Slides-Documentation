---
title: Python में प्रस्तुतियों से शैप प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/python-net/shape-effective-properties/
keywords:
- शैप गुण
- कैमरा गुण
- लाइट रिग
- बीवेल शैप
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides को .NET के माध्यम से Python के लिए उपयोग करके PowerPoint प्रस्तुतियों में स्थानीय, उत्तराधिकारित और प्रभावी शैप फ़ॉर्मेटिंग को कैसे अलग किया जाए, जानें।"
---
## **समझें स्थानीय, उत्तराधिकारित, और प्रभावी गुण**

PowerPoint फ़ॉर्मेटिंग कई स्रोतों से आ सकती है। किसी ऑब्जेक्ट पर सीधे संग्रहीत मान उसकी **स्थानीय मान** है। अगर वह मान सेट नहीं है, तो PowerPoint पैराग्राफ़ डिफ़ॉल्ट, टेक्स्ट स्टाइल, लेआउट या मास्टर स्लाइड, थीम, या प्रेजेंटेशन‑लेवल डिफ़ॉल्ट जैसी पैरेंट फ़ॉर्मेटिंग स्रोतों को देखता है। ये मान **उत्तराधिकारित मान** होते हैं। पूरी पदानुक्रम का समाधान होने के बाद जो मान बचता है वह **प्रभावी मान** है, जिसका उपयोग ऑब्जेक्ट को रेंडर करने के लिये किया जाता है।

उदाहरण के लिए, किसी टेक्स्ट भाग में फ़ॉन्ट ऊँचाई परिभाषित नहीं हो सकती। उसकी स्थानीय [font_height](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ibaseportionformat/font_height/) फिर `float("nan")` होती है, जिसका अर्थ है “यहाँ सेट नहीं है।” भाग पैराग्राफ़, प्रेजेंटेशन की डिफ़ॉल्ट टेक्स्ट स्टाइल, या अन्य लागू स्रोत से ऊँचाई उत्तराधिकारित कर सकता है। भाग फ़ॉर्मेट पर [get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iportionformat/get_effective/) कॉल करने से अंतिम समाधानित ऊँचाई मिलती है।

दो प्रकार के फ़ॉर्मेटिंग डेटा का अलग‑अलग प्रयोजन है:

- किसी स्थानीय फ़ॉर्मेट ऑब्जेक्ट को पढ़ना या बदलना, जैसे [IPortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iportionformat/), जब आपको यह नियंत्रित करना हो कि मान कहाँ परिभाषित है।
- किसी प्रभावी डेटा ऑब्जेक्ट को पढ़ना, जैसे [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iportionformateffectivedata/), जब आपको अंतिम, रेंडर किया हुआ परिणाम चाहिए। प्रभावी डेटा केवल‑पढ़ने योग्य होता है।

## **स्थानीय, उत्तराधिकारित, और प्रभावी मानों की तुलना करें**

निम्नलिखित पूर्ण उदाहरण एक शैप बनाता है और फ़ॉन्ट ऊँचाई को प्रेजेंटेशन, पैराग्राफ़, और भाग स्तर पर लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों और समान टेक्स्ट भाग के लिए परिणामित प्रभावी मान को प्रिंट करता है। यह यह भी दर्शाता है कि फ़ॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को फिर से पढ़ना क्यों आवश्यक है।

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # पहले किए गए परिवर्तनों के बाद प्रभावी डेटा पढ़ें।
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # दो विभिन्न स्तरों पर उत्तराधिकारित मान निर्धारित करें।
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # भाग पर स्थानीय मान दोनों उत्तराधिकारित मानों को ओवरराइड करता है।
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # एक उत्तराधिकारित मान बदलने से मौजूदा स्थानीय मान ओवरराइड नहीं होता।
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # स्थानीय मान को साफ़ करें। अब भाग फिर से पैराग्राफ़ से उत्तराधिकारित होता है।
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # पैराग्राफ़ मान को साफ़ करें। अब प्रेजेंटेशन डिफ़ॉल्ट परिणाम प्रदान करता है।
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

इस उदाहरण में प्राथमिकता भाग की स्थानीय फ़ॉर्मेटिंग, फिर पैराग्राफ़ फ़ॉर्मेटिंग, फिर प्रेजेंटेशन डिफ़ॉल्ट की है। अन्य ऑब्जेक्ट्स की विरासत श्रृंखलाएँ अलग हो सकती हैं, लेकिन सिद्धान्त समान है: अधिक विशिष्ट स्पष्ट मान जीतता है, और [get_effective](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iportionformat/get_effective/) अंतिम परिणाम देता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फ़ॉर्मेटिंग कई ऑब्जेक्ट्स में बँटी होती है:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/itextframeformat/get_effective/) मार्जिन, एंकरिंग, ऑटोफ़िट, और वर्टिकल टेक्स्ट दिशा जैसे टेक्स्ट‑फ़्रेम गुणों को हल करता है।
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/itextstyle/get_effective/) प्रत्येक टेक्स्ट स्टाइल स्तर के लिये पैराग्राफ फ़ॉर्मेटिंग को हल करता है।
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iparagraphformat/get_effective/) संरेखण, इंडेंटेशन, और बुलेट्स जैसी पैराग्राफ़ प्रॉपर्टी को हल करता है।
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iportionformat/get_effective/) फ़ॉन्ट ऊँचाई, टाइपफ़ेस, रंग, बोल्ड, और इटैलिक जैसी कैरेक्टर प्रॉपर्टी को हल करता है।

अगले उदाहरण के लिये `text-formatting.pptx` में कम से कम एक स्लाइड और एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) जिसमें खाली न हो ऐसा टेक्स्ट फ्रेम हो, आवश्यक है। AutoShape शेप कलेक्शन में कहीं भी हो सकता है; कोड उपयुक्त ऑब्जेक्ट की खोज करता है और उपयोग से पहले उसकी पुष्टि करता है।

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **प्रभावी 3D गुण प्राप्त करें**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformat/get_effective/) एक [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/) ऑब्जेक्ट लौटाता है जो सभी हल किए गए 3D सेटिंग्स को समूहित करता है। इसके [camera](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/), और [bevel_bottom](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) प्रॉपर्टी संबंधित प्रभावी डेटा को उजागर करती हैं। इन सम्बंधित सेटिंग्स को एक साथ पढ़ने से शैप के अंतिम 3D लुक को समझना आसान हो जाता है।

इस उदाहरण के लिये `shape-3d.pptx` में पहली स्लाइड पर कम से कम एक शैप होना चाहिए। यदि आप आउटपुट में डिफ़ॉल्ट के अलावा अन्य मान देखना चाहते हैं तो उस शैप पर 3D कैमरा, लाइटिंग, या बीवेल सेटिंग्स लागू करें।

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **प्रभावी टेबल फ़ॉर्मेटिंग प्राप्त करें**

टेबल फ़ॉर्मेटिंग टेबल स्टाइल और पूरे टेबल, कॉलम, रो, या व्यक्तिगत सेल पर लागू फ़ॉर्मेट से आ सकती है। स्पष्ट रूप से परिभाषित फ़िल्स में टकराव होने पर प्राथमिकता क्रम है: सेल, रो, कॉलम, फिर पूरी टेबल। किसी सेल का प्रभावी फ़ॉर्मेट वह अंतिम फ़ॉर्मेट है जो उस सेल को ड्रॉ करने के लिये उपयोग किया जाता है।

इस उदाहरण के लिये `table-formatting.pptx` में पहली स्लाइड पर कम से कम एक टेबल हो, जिसमें कम से कम एक रो और एक कॉलम हो। कोड [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) की खोज करता है यह मानते हुए कि `shapes[0]` टेबल है।

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

यदि आपको रंग चाहिए और केवल फ़िल प्रकार नहीं, तो पहले प्रभावी [fill_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifillformateffectivedata/fill_type/) जाँचें, फिर उस प्रकार के अनुसार प्रॉपर्टी पढ़ें, उदाहरण के लिये ठोस फ़िल के लिये [solid_fill_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/)।

## **परिवर्तन के बाद प्रभावी डेटा को पुनः पढ़ें**

प्रभावी डेटा उस समय की फ़ॉर्मेटिंग पदानुक्रम को दर्शाता है जब वह हल किया गया था। पदानुक्रम में भाग लेने वाली किसी भी चीज़ को बदलने के बाद `get_effective` को फिर से कॉल करें, जिसमें शामिल हैं:

- ऑब्जेक्ट की स्थानीय फ़ॉर्मेटिंग;
- पैराग्राफ़ या टेक्स्ट‑फ़्रेम डिफ़ॉल्ट;
- टेबल स्टाइल, टेबल, कॉलम, रो, या सेल फ़ॉर्मेट;
- लेआउट या मास्टर स्लाइड फ़ॉर्मेटिंग;
- थीम डेटा या प्रेजेंटेशन‑लेवल डिफ़ॉल्ट;
- स्लाइड को असाइन किया गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides कुछ प्रभावी डेटा को आंतरिक रूप से कैश कर सकता है, और बाद का `get_effective` कॉल वह डेटा रीफ़्रेश कर सकता है। यदि आपको परिवर्तन से पहले और बाद के मानों की तुलना करनी है, तो परिवर्तन करने से पहले फ़ॉन्ट ऊँचाई, रंग, संरेखण, या बीवेल चौड़ाई जैसी स्केलर वैल्यूज़ को अपने वेरिएबल्स में कॉपी कर लें।

किसी मान को बदलने के लिये, उपयुक्त स्थानीय फ़ॉर्मेट ऑब्जेक्ट को अपडेट करें और फिर `get_effective` कॉल कर परिणाम सत्यापित करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने योग्य होते हैं।

## **FAQ**

**मैं कैसे पता लगा सकता हूँ कि कौन‑सा स्तर प्रभावी मान प्रदान कर रहा है?**

प्रभावी डेटा अंतिम मान रखता है, उसके स्रोत को नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय ऑब्जेक्ट्स को जांचें। टेक्स्ट के लिये यह भाग, पैराग्राफ़, टेक्स्ट‑फ़्रेम, लेआउट, मास्टर, थीम, और प्रेजेंटेशन डिफ़ॉल्ट शामिल हो सकते हैं। `float("nan")` या `None` जैसे अपरिभाषित मान यह दर्शाते हैं कि खोज अगले स्तर पर जारी रहती है।

**जब कोई स्तर किसी गुण को परिभाषित नहीं करता तो क्या होता है?**

Aspose.Slides उपयुक्त PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। यह हल किया गया मान प्रभावी डेटा में दिखाई देता है भले ही कोई स्थानीय ऑब्जेक्ट स्पष्ट रूप से इसे परिभाषित न करे।

**कभी‑कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**

स्थानीय मान ने विरासत गणना जीत ली है। यह तब अपेक्षित है जब गुण स्पष्ट रूप से ऑब्जेक्ट पर सेट हो और कोई अधिक विशिष्ट नियम उसे ओवरराइड न करे।

**कब मैं स्थानीय डेटा के बजाय प्रभावी डेटा का उपयोग करूँ?**

स्थानीय डेटा का उपयोग किसी विशिष्ट फ़ॉर्मेटिंग स्तर को निरीक्षण या संपादित करने के लिये करें। प्रभावी डेटा का उपयोग तब करें जब आपको विरासत, थीम नियम, और लागू स्टाइल्स के समाधान के बाद अंतिम दिखावट चाहिए। दोनों को एक ही वर्कफ़्लो में दर्शाने वाला [complete comparison example](#compare-local-inherited-and-effective-values) इस बात को स्पष्ट करता है।