---
title: Python के साथ प्रस्तुतियों से शेप के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/python-net/shape-effective-properties/
keywords:
- शेप गुण
- कैमरा गुण
- लाइट रिज
- बेवेल शेप
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फॉर्मेट
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "जाने कैसे Aspose.Slides for Python via .NET सटीक PowerPoint रेंडरिंग के लिए प्रभावी शेप गुणों की गणना और लागू करता है."
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** गुणों के बीच अंतर को समझाता है। स्थानीय मूल्यों को उन मानों के रूप में परिभाषित किया जाता है जो सीधे किसी विशिष्ट स्वरूपण स्तर पर सेट किए जाते हैं, जैसे:

1. स्लाइड पर भाग गुण।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप आकार के टेक्स्ट शैलियाँ, जब भाग के टेक्स्ट फ्रेम आकार में एक हो।
1. प्रस्तुति में ग्लोबल टेक्स्ट सेटिंग्स।

स्थानीय मानों को किसी भी स्तर पर परिभाषित या छोड़ा जा सकता है। जब Aspose.Slides को अंतिम "जैसे रेंडर किया गया" स्वरूपण चाहिए, तो वह विरासत श्रृंखला को हल करता है और **प्रभावी** मान वापस करता है। आप इन्हें स्थानीय स्वरूप ऑब्जेक्ट पर `get_effective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) है जिसमें एक टेक्स्ट फ्रेम और कम से कम एक भाग है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
प्रभावी स्वरूपण डेटा वह वर्तमान गणना किया गया स्वरूपण दर्शाता है जो विरासत लागू होने के बाद प्राप्त होता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा ऑब्जेक्ट, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iportionformateffectivedata/), आंतरिक रूप से कैश किए जा सकते हैं। पैरेंट या विरासतित स्वरूपण को बदलने के बाद `get_effective` को फिर से कॉल करने से कैश किया गया डेटा रीफ़्रेश हो सकता है, और पहले प्राप्त ऑब्जेक्ट अब पहले की स्थिति को दर्शा नहीं सकता। यदि आपको बाद में पुन: उपयोग के लिए प्रभावी मान सुरक्षित रखने की आवश्यकता है, तो आवश्यक गुणों जैसे फ़ॉन्ट ऊँचाई, भराव रंग, फ़ॉन्ट शैली, या संरेखण को अपने डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी गुण प्राप्त करना**

Aspose.Slides आपको कैमरे के प्रभावी गुण प्राप्त करने की अनुमति देता है। प्रकार [ICameraEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/icameraeffectivedata/) एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें प्रभावी कैमरा गुण शामिल होते हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/icameraeffectivedata/) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि कैमरे के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में 3D स्वरूपण है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **लाइट रिग के प्रभावी गुण प्राप्त करना**

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की अनुमति देता है। प्रकार [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ilightrigeffectivedata/) एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें प्रभावी लाइट रिग गुण शामिल होते हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ilightrigeffectivedata/) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि लाइट रिग के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में 3D स्वरूपण है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **शेप बेवेल के प्रभावी गुण प्राप्त करना**

Aspose.Slides आपको एक आकार बेवेल के प्रभावी गुण प्राप्त करने की अनुमति देता है। प्रकार [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapebeveleffectivedata/) एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें आकार के फ़ेस‑रिलिफ़ गुण शामिल होते हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapebeveleffectivedata/) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [ThreeDFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/threedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि आकार के शीर्ष बेवेल के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में 3D स्वरूपण है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त करना**

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। प्रकार [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/itextframeformateffectivedata/) में प्रभावी टेक्स्ट फ्रेम स्वरूपण गुण होते हैं।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट फ्रेम स्वरूपण गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) है जिसमें टेक्स्ट फ्रेम है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त करना**

Aspose.Slides का उपयोग करके आप टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त कर सकते हैं। प्रकार [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/itextstyleeffectivedata/) में प्रभावी टेक्स्ट स्टाइल गुण होते हैं।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट स्टाइल गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [AutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) है जिसमें टेक्स्ट फ्रेम है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **प्रभावी फ़ॉन्ट ऊँचाई मान प्राप्त करना**

Aspose.Slides का उपयोग करके आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्न कोड दर्शाता है कि विभिन्न प्रस्तुति संरचना स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट करने के बाद किसी भाग की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **टेबल के लिए प्रभावी फ़िल फॉर्मेट प्राप्त करना**

Aspose.Slides का उपयोग करके आप अलग‑अलग टेबल भागों के लिए प्रभावी फ़िल स्वरूपण प्राप्त कर सकते हैं। प्रकार [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ifillformateffectivedata/) में प्रभावी फ़िल स्वरूपण गुण होते हैं। सेल स्वरूपण की प्राथमिकता पंक्तियों के स्वरूपण से अधिक होती है, पंक्तियों का स्वरूपण कॉलम स्वरूपण से अधिक होता है, और कॉलम स्वरूपण का प्राथमिकता पूरे‑टेबल स्वरूपण से अधिक होती है।

परिणामस्वरूप, [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/icellformateffectivedata/) गुणों का उपयोग टेबल सेल को खींचने के लिए किया जाता है। निम्न कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी फ़िल स्वरूपण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [Table](https://reference.aspose.com/slides/hi/python-net/aspose.slides/table/) है।

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **अक्सर पूछे जाने वाले प्रश्न**

**`get_effective` क्या एक स्नैपशॉट लौटाता है?**

हमेशा नहीं। प्रभावी डेटा वह गणना किया गया स्वरूपण दर्शाता है जो विरासत लागू होने के बाद प्राप्त होता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट आंतरिक रूप से कैश किए जा सकते हैं। एक बाद के `get_effective` कॉल से स्वरूपण फिर से गणना हो सकता है और कैश किया गया डेटा रीफ़्रेश हो सकता है, इसलिए पहले प्राप्त ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

**मुझे प्रभावी गुणों को फिर से कब पढ़ना चाहिए?**

`get_effective` को फिर से कॉल करें जब स्थानीय स्वरूपण, पैरेंट स्टाइल, लेआउट स्वरूपण, मास्टर स्वरूपण, या प्रस्तुति‑स्तर के डिफ़ॉल्ट बदलें। अगला कॉल स्वरूपण पदानुक्रम को पुनः मूल्यांकन करता है और वर्तमान प्रभावी परिणाम लौटाता है।

**क्या लेआउट/मास्टर स्लाइड को बदलने या हटाने से पहले प्राप्त किए गए प्रभावी गुण प्रभावित होते हैं?**

हाँ, लेकिन परिवर्तन अगले `get_effective` कॉल पर परिलक्षित होता है। यदि पैरेंट स्वरूपण स्रोत बदलता या हटाया जाता है, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। एक बार फिर से `get_effective` कॉल करने पर, Aspose.Slides स्वरूपण ट्री को पुनः मूल्यांकन करता है और परिणामी फ़ॉन्ट, रंग, आकार, या अन्य मान बदल सकते हैं।

**क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मानों को संशोधित कर सकता हूँ?**

नहीं। प्रभावी डेटा ऑब्जेक्ट्स केवल गणना किए गए मान प्रदर्शित करते हैं। स्थानीय स्वरूपण ऑब्जेक्ट्स में परिवर्तन करें, और फिर प्रभावी मानों को फिर से प्राप्त करें।

**अगर कोई गुण आकार स्तर पर, न लेआउट/मास्टर में, न ही ग्लोबल सेटिंग्स में सेट नहीं है तो क्या होता है?**

प्रभावी मान डिफ़ॉल्ट तंत्र द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides की डिफ़ॉल्ट सेटिंग्स शामिल हैं। वह समाधानित मान वर्तमान प्रभावी डेटा का भाग बन जाता है।

**क्या प्रभावी फ़ॉन्ट मान से मैं बता सकता हूँ कि कौन से स्तर ने आकार या फ़ॉन्ट प्रदान किया?**

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत पता करने के लिए, भाग, पैराग्राफ, टेक्स्ट फ्रेम, और लेआउट, मास्टर, तथा प्रस्तुति स्तर पर टेक्स्ट स्टाइल के स्थानीय मानों को जांचें कि पहली स्पष्ट परिभाषा कहाँ है।

**क्यों कभी‑कभी प्रभावी मान स्थानीय मानों के समान दिखते हैं?**

क्योंकि स्थानीय मान अंततः अंतिम बन जाता है (कोई उच्च‑स्तरीय विरासत आवश्यक नहीं थी)। ऐसे मामलों में, प्रभावी मान स्थानीय मान के समान होता है।

**मुझे प्रभावी गुण कब उपयोग करने चाहिए, और कब केवल स्थानीय मानों के साथ काम करना चाहिए?**

सभी विरासत लागू होने के बाद "जैसे रेंडर किया गया" परिणाम चाहिए तो प्रभावी डेटा का उपयोग करें, जैसे रंग, इंडेंट या आकार को संरेखित करना। यदि आपको बाद के स्वरूपण परिवर्तन के बावजूद उन मानों को संरक्षित रखना है, तो आवश्यक गुणों को अपने ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशिष्ट स्तर पर स्वरूपण बदलना है, तो स्थानीय गुण modify करें और फिर, यदि आवश्यक हो, प्रभावी डेटा को फिर से पढ़ें ताकि परिणाम की पुष्टि हो सके।