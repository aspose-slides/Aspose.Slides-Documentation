---
title: Python के जरिए Java में प्रस्तुतियों से शैप प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/python-java/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- लाइट रिग
- बिवेल आकार
- पाठ फ्रेम
- पाठ शैली
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Python के लिए Java के माध्यम से Aspose.Slides का उपयोग कैसे करें, यह सीखें ताकि PowerPoint प्रस्तुतियों में स्थानीय, विरासत में मिले और प्रभावी शैप फ़ॉर्मेटिंग को अलग किया जा सके।"
---
## **स्थानीय, विरासत में मिले, और प्रभावी गुणों को समझें**

PowerPoint फ़ॉर्मेटिंग कई स्थानों से आ सकती है। किसी ऑब्जेक्ट पर सीधे संग्रहीत मान उसका **स्थानीय मान** है। यदि वह मान सेट नहीं किया गया है, तो PowerPoint पैरेंट फ़ॉर्मेटिंग स्रोतों को देखता है, जैसे पैराग्राफ़ डिफ़ॉल्ट, टेक्स्ट स्टाइल, लेआउट या मास्टर स्लाइड, थीम, या प्रेज़ेंटेशन‑लेवल डिफ़ॉल्ट्स। इन मानों को **विरासत में मिले मान** कहा जाता है। पूरी पदानुक्रम को हल करने के बाद जो मान शेष रहता है, वह **प्रभावी मान** है — वह मान जो ऑब्जेक्ट को रेंडर करने के लिए इस्तेमाल होता है।

उदाहरण के लिए, किसी टेक्स्ट भाग ने अपना फ़ॉन्ट ऊँचाई निर्धारित नहीं की हो सकती है। उसका स्थानीय [getFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#getFontHeight) मान फिर `float("nan")` होता है, जिसका अर्थ है “यहाँ सेट नहीं है।” भाग पैराग्राफ़, प्रेज़ेंटेशन के डिफ़ॉल्ट टेक्स्ट स्टाइल, या अन्य लागू स्रोत से ऊँचाई विरासत में ले सकता है। भाग फ़ॉर्मेट पर [getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#getEffective) कॉल करने से अंतिम हल की गई ऊँचाई मिलती है।

विभिन्न प्रयोजनों के लिए दो प्रकार के फ़ॉर्मेटिंग डेटा का उपयोग करें:

- स्थानीय फ़ॉर्मेट ऑब्जेक्ट, जैसे [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/), को पढ़ें या बदलें, जब आपको नियंत्रित करना हो कि मान कहाँ परिभाषित है।
- प्रभावी डेटा ऑब्जेक्ट, जैसे `PortionFormatEffectiveData`, को पढ़ें, जब आपको अंतिम, रेंडर किया गया परिणाम चाहिए। प्रभावी डेटा केवल‑पढ़ने योग्य है।

## **स्थानीय, विरासत में मिले, और प्रभावी मानों की तुलना करें**

निम्नलिखित पूर्ण उदाहरण एक शैप बनाता है और प्रेज़ेंटेशन, पैराग्राफ़, तथा भाग स्तर पर फ़ॉन्ट ऊँचाइयाँ लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों और उसी टेक्स्ट भाग के परिणामस्वरूप प्रभावी मान को प्रिंट करता है। यह यह भी दर्शाता है कि फ़ॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को फिर से पढ़ना क्यों आवश्यक है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # पूर्ववर्ती परिवर्तनों के बाद प्रभावी डेटा पढ़ें।
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # दो विभिन्न स्तरों पर विरासत में मिले मान निर्धारित करें।
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # भाग पर एक स्थानीय मान दोनों विरासत में मिले मानों को अधिलेखित करता है।
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # एक विरासत में मिले मान को बदलने से मौजूदा स्थानीय मान अधिलेखित नहीं होता।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # स्थानीय मान को साफ़ करें। अब भाग पैराग्राफ़ से फिर से विरासत में लेता है।
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # पैराग्राफ़ मान को साफ़ करें। अब प्रेज़ेंटेशन डिफ़ॉल्ट परिणाम प्रदान करता है।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

इस उदाहरण में प्राथमिकता भाग का स्थानीय फ़ॉर्मेटिंग, फिर पैराग्राफ़ फ़ॉर्मेटिंग, और फिर प्रेज़ेंटेशन डिफ़ॉल्ट है। अन्य ऑब्जेक्ट्स की विरासत श्रृंखलाएँ अलग हो सकती हैं, लेकिन सिद्धांत समान है: अधिक विशिष्ट स्पष्ट मान जीतता है, और [getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#getEffective) अंतिम परिणाम लौटाता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फ़ॉर्मेटिंग कई ऑब्जेक्ट्स में विभाजित है:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#getEffective) मार्जिन, एंकरिंग, ऑटофिट, और वर्टिकल टेक्स्ट दिशा जैसे टेक्स्ट‑फ़्रेम गुणों को हल करता है।
- [TextStyle.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textstyle/#getEffective) प्रत्येक टेक्स्ट‑स्टाइल स्तर के लिए पैराग्राफ़ फ़ॉर्मेटिंग को हल करता है।
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#getEffective) संरेखण, इंडेंटेशन, और बुलेट्स जैसे पैराग्राफ़ गुणों को हल करता है।
- [PortionFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#getEffective) फ़ॉन्ट ऊँचाई, टाइपफ़ेस, रंग, बोल्ड, और इटैलिक जैसे कैरेक्टर गुणों को हल करता है।

अगले उदाहरण के लिए, `text-formatting.pptx` में कम से कम एक स्लाइड और एक [AutoShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/autoshape/) जिसमें गैर‑खाली टेक्स्ट फ़्रेम हो, होना चाहिए। AutoShape शेप कलेक्शन में कहीं भी हो सकता है; कोड उपयुक्त ऑब्जेक्ट की खोज करता है और उपयोग से पहले उसकी सत्यापना करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **प्रभावी 3D गुण प्राप्त करें**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/threedformat/#getEffective) एक `ThreeDFormatEffectiveData` ऑब्जेक्ट लौटाता है जो सभी हल किए गए 3D सेटिंग्स को समूहित करता है। इसके `getCamera`, `getLightRig`, `getBevelTop`, और `getBevelBottom` मेथड्स संबंधित प्रभावी डेटा को उजागर करते हैं। इन संबंधित सेटिंग्स को साथ‑साथ पढ़ने से किसी शैप की अंतिम 3D उपस्थिति को समझना आसान हो जाता है।

इस उदाहरण के लिए, `shape-3d.pptx` में पहले स्लाइड पर कम से कम एक शैप होना चाहिए। यदि आप डिफ़ॉल्ट मानों से भिन्न आउटपुट चाहते हैं, तो उस शैप पर 3D कैमरा, लाइटिंग, या बिवेल सेटिंग्स लागू करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **प्रभावी टेबल फ़ॉर्मेटिंग प्राप्त करें**

टेबल फ़ॉर्मेटिंग टेबल स्टाइल और पूरे टेबल, कॉलम, पंक्ति, या व्यक्तिगत सेल पर लागू फ़ॉर्मेट्स दोनों से आ सकती है। स्पष्ट रूप से परिभाषित फ़िल्स के बीच टकराव में प्राथमिकता क्रम सेल, पंक्ति, कॉलम, और फिर पूरा टेबल है। किसी सेल का प्रभावी फ़ॉर्मेट वह अंतिम फ़ॉर्मेट है जो उस सेल को ड्रॉ करने के लिए उपयोग किया जाता है।

इस उदाहरण के लिए, `table-formatting.pptx` में पहले स्लाइड पर कम से कम एक टेबल होना चाहिए। टेबल में कम से कम एक पंक्ति और एक कॉलम होना ज़रूरी है। कोड यह मानकर नहीं चलता कि `getShapes().get_Item(0)` टेबल है; बल्कि वह एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) की खोज करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

यदि आपको केवल फ़िल प्रकार के बजाय रंग चाहिए, तो पहले प्रभावी `getFillType` जांचें, और फिर उस प्रकार पर लागू मेथड पढ़ें—उदाहरण के लिए सॉलिड फ़िल के लिए `getSolidFillColor`।

## **परिवर्तनों के बाद प्रभावी डेटा को दोबारा पढ़ें**

प्रभावी डेटा उस समय की फ़ॉर्मेटिंग पदानुक्रम को वर्णित करता है जब वह हल किया जाता है। किसी भी वह बदलाव करने के बाद जो उस पदानुक्रम में भाग ले सकता है, फिर से [getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#getEffective) कॉल करें, जिसमें शामिल है:

- ऑब्जेक्ट का स्थानीय फ़ॉर्मेटिंग;
- पैराग्राफ़ या टेक्स्ट‑फ़्रेम डिफ़ॉल्ट्स;
- टेबल स्टाइल, टेबल, कॉलम, पंक्ति, या सेल फ़ॉर्मेट;
- लेआउट या मास्टर स्लाइड फ़ॉर्मेटिंग;
- थीम डेटा या प्रेज़ेंटेशन‑लेवल डिफ़ॉल्ट;
- स्लाइड को असाइन किया गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides कुछ प्रभावी डेटा को आंतरिक रूप से कैश कर सकता है, और बाद में [getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#getEffective) कॉल उस डेटा को रीफ़्रेश कर सकता है। यदि आपको परिवर्तन से पहले और बाद के मानों की तुलना करनी है, तो परिवर्तन करने से पहले आवश्यक स्कैलर मानों—जैसे फ़ॉन्ट ऊँचाई, रंग, संरेखण, या बिवेल चौड़ाई—को अपनी स्वयं की वेरिएबल्स में कॉपी करें।

किसी मान को बदलने के लिए, उपयुक्त स्थानीय फ़ॉर्मेट ऑब्जेक्ट को अपडेट करें और फिर परिणाम की पुष्टि के लिए [getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/#getEffective) कॉल करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने योग्य होते हैं।

## **FAQ**

**मैं कैसे पता करूँ कि कौन‑सा स्तर प्रभावी मान प्रदान किया?**

प्रभावी डेटा में केवल अंतिम मान होता है, स्रोत नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय ऑब्जेक्ट्स की जाँच करें। टेक्स्ट के लिए यह भाग, पैराग्राफ़, टेक्स्ट‑फ़्रेम, लेआउट, मास्टर, थीम, और प्रेज़ेंटेशन डिफ़ॉल्ट्स शामिल हो सकते हैं। `float("nan")` या `None` जैसे अनिर्दिष्ट मान दर्शाते हैं कि खोज अगले स्तर तक जारी रहती है।

**जब कोई स्तर गुण को परिभाषित नहीं करता तो क्या होता है?**

Aspose.Slides उचित PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। वह हल किया गया मान प्रभावी डेटा में दिखता है, भले ही कोई स्थानीय ऑब्जेक्ट स्पष्ट रूप से उसे परिभाषित न करे।

**कभी‑कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**

स्थानीय मान विरासत गणना में जीत जाता है। यह तब अपेक्षित है जब गुण ऑब्जेक्ट पर स्पष्ट रूप से सेट किया गया हो और कोई अधिक विशिष्ट नियम उसे ओवरराइड न करे।

**मुझे स्थानीय डेटा कब उपयोग करना चाहिए, प्रभावी डेटा के बजाय?**

विशिष्ट फ़ॉर्मेटिंग स्तर को निरीक्षण या संपादित करने के लिए स्थानीय डेटा उपयोग करें। विरासत, थीम नियम, और लागू स्टाइल्स को हल करने के बाद अंतिम उपस्थिति चाहिए तो प्रभावी डेटा उपयोग करें। [पूर्ण तुलना उदाहरण](#compare-local-inherited-and-effective-values) दोनों को एक ही वर्कफ़्लो में दर्शाता है।