---
title: Python का उपयोग करके PowerPoint तालिकाओं में पंक्तियों और स्तंभों का प्रबंधन
linktitle: पंक्तियाँ और स्तंभ
type: docs
weight: 20
url: /hi/python-java/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका स्तंभ
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति टेक्स्ट फ़ॉर्मेटिंग
- स्तंभ टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का प्रयोग करके PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुति संपादन तथा डेटा अपडेट को तेज़ बनाएँ।"
---
## **परिचय**

PowerPoint प्रस्तुति में तालिका की पंक्तियों और स्तंभों का प्रबंधन करने के लिए, Aspose.Slides [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) क्लास और कई अन्य प्रकार प्रदान करता है।

## **पहली पंक्ति को हेडर के रूप में सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की instance बनाएँ और प्रस्तुति लोड करें।  
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) संदर्भ बनाएँ और इसे `None` सेट करें।  
4. संबंधित तालिका खोजने के लिए सभी [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) ऑब्जेक्ट्स में इटरेट करें।  
5. तालिका की पहली पंक्ति को उसके हेडर के रूप में सेट करें।

यह Python कोड दिखाता है कि कैसे तालिका की पहली पंक्ति को हेडर के रूप में सेट किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका की पंक्ति या स्तंभ को क्लोन करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की instance बनाएँ और प्रस्तुति लोड करें।  
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. स्तंभ चौड़ाइयों की सूची निर्धारित करें।  
4. पंक्ति ऊंचाइयों की सूची निर्धारित करें।  
5. [addTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addTable) मेथड के माध्यम से स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट जोड़ें।  
6. तालिका की पंक्ति को क्लोन करें।  
7. तालिका के स्तंभ को क्लोन करें।  
8. संशोधित प्रस्तुति सहेजें।

यह Python कोड दिखाता है कि कैसे PowerPoint तालिका की पंक्ति या स्तंभ को क्लोन किया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की instance बनाएँ।  
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. स्तंभ चौड़ाइयों की सूची निर्धारित करें।  
4. पंक्ति ऊंचाइयों की सूची निर्धारित करें।  
5. [addTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addTable) मेथड के माध्यम से स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट जोड़ें।  
6. तालिका की पंक्ति हटाएँ।  
7. तालिका का स्तंभ हटाएँ।  
8. संशोधित प्रस्तुति सहेजें।

यह Python कोड दिखाता है कि कैसे तालिका से पंक्ति या स्तंभ हटाया जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका पंक्ति स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की instance बनाएँ और प्रस्तुति लोड करें।  
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड से संबंधित [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट तक पहुँचें।  
4. पहली‑पंक्ति की सेल्स के फ़ॉन्ट ऊँचाई को [setFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontHeight) से सेट करें।  
5. पहली‑पंक्ति की सेल्स के टेक्स्ट संरेखण और दायाँ मार्जिन को [setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) और [setMarginRight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginRight) से सेट करें।  
6. दूसरी‑पंक्ति की सेल्स के वर्टिकल टेक्स्ट प्रकार को [setTextVerticalType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setTextVerticalType) से सेट करें।  
7. संशोधित प्रस्तुति सहेजें।

यह Python कोड इस ऑपरेशन को प्रदर्शित करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **तालिका स्तंभ स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की instance बनाएँ और प्रस्तुति लोड करें।  
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड से संबंधित [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट तक पहुँचें।  
4. पहली‑स्तंभ की सेल्स के फ़ॉन्ट ऊँचाई को [setFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontHeight) से सेट करें।  
5. पहली‑स्तंभ की सेल्स के टेक्स्ट संरेखण और दायाँ मार्जिन को [setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) और [setMarginRight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginRight) से सेट करें।  
6. दूसरी‑स्तंभ की सेल्स के वर्टिकल टेक्स्ट प्रकार को [setTextVerticalType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setTextVerticalType) से सेट करें।  
7. संशोधित प्रस्तुति सहेजें।

यह Python कोड इस ऑपरेशन को प्रदर्शित करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के शैली गुण प्राप्त करने की अनुमति देता है ताकि आप इन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह Python कोड दिखाता है कि कैसे तालिका प्रीसेट शैली से शैली गुण प्राप्त किए जाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/शैलियाँ लागू कर सकता हूँ?**

हां। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप उस थीम के ऊपर फ़िल, बॉर्डर और टेक्स्ट रंगों को ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका की पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में अंतर्निहित सॉर्टिंग या फ़िल्टर नहीं होते। पहले डेटा को मेमोरी में सॉर्ट करें, फिर उस क्रम में तालिका की पंक्तियों को फिर से भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकते हूँ जबकि विशिष्ट कोशिकाओं पर कस्टम रंग बनाए रखें?**

हां। बैंडेड स्तंभ चालू करें, फिर विशिष्ट कोशिकाओं को स्थानीय फ़ॉर्मेटिंग से ओवरराइड करें; सेल‑स्तरीय फ़ॉर्मेटिंग तालिका शैली पर प्राथमिकता रखती है।