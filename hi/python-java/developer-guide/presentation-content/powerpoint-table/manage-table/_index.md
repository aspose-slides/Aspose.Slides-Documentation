---
title: Python में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/python-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपनी तालिका कार्यप्रवाह को सुव्यवस्थित करने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मान पढ़ना और तुलना करना आसान हो जाता है।

Aspose.Slides निम्नलिखित [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) और [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) क्लास और अन्य प्रकार प्रदान करता है जिससे आप प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरू से तालिका बनाना**

एक तालिका बनाते समय उसकी स्थिति, स्तंभ की चौड़ाई, और पंक्ति की ऊँचाई निर्दिष्ट की जाती है। इसे स्लाइड में जोड़ने के बाद आप सेल की सीमाओं को स्वरूपित कर सकते हैं, सेल्स को मर्ज कर सकते हैं, और टेक्स्ट डाल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. पॉइंट में स्तंभ की चौड़ाई की सूची परिभाषित करें।
4. पॉइंट में पंक्ति की ऊँचाई की सूची परिभाषित करें।
5. स्लाइड में एक [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) वस्तु को [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) मेथड के माध्यम से जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) पर इटरैट करके उनके ऊपर, नीचे, दाएँ और बाएँ सीमा का स्वरूप लागू करें।
7. तालिका की पहली पंक्ति के पहले दो सेल्स को मर्ज करें।
8. मर्ज किए गए सेल को उसके [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) मेथड के माध्यम से एक्सेस करें।
9. मर्ज किए गए सेल में टेक्स्ट सेट करें।
10. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण तीन स्तंभ और पाँच पंक्तियों वाली तालिका (100, 50) पॉइंट पर बनाता है। यह 5 पॉइंट चौड़ी लाल सीमाएँ लागू करता है, पहली पंक्ति के पहले दो सेल्स को मर्ज करता है, और परिणाम को `table.pptx` के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, सेल इंडेक्स शून्य-आधारित होते हैं और क्रम (स्तंभ, पंक्ति) का उपयोग करते हैं। पहला सेल (0, 0) के रूप में इंडेक्स किया जाता है।

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका में सेल्स इस प्रकार क्रमांकित किए जाते हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह उदाहरण ऊपर दर्शाए गए 4 × 4 तालिका को बनाता है, जिसमें स्तंभ चौड़ाई और पंक्ति ऊँचाई 70 पॉइंट है और लाल सेल सीमाएँ 5 पॉइंट की हैं। निर्देशांक सेल इंडेक्स दिखाते हैं; उदाहरण सेल्स को खाली छोड़ता है और तालिका को `StandardTables_out.pptx` के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मौजूदा तालिका तक पहुँच**

तालिकाएँ स्लाइड के शेप संग्रह में संग्रहीत होती हैं। शेप्स के माध्यम से इटरैट करके तालिका खोजें, फिर उसके सेल्स को पढ़ने या अपडेट करने के लिए [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) क्लास का उपयोग करें।

1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
2. इंडेक्स द्वारा तालिका वाली स्लाइड का संदर्भ प्राप्त करें।
3. सभी [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) वस्तुओं के माध्यम से इटरैट करें और जब तालिका मिले तो रुकें। यदि स्लाइड में कई तालिकाएँ हों, तो आवश्यक तालिका पहचानने के लिए [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) का उपयोग करें।
4. लक्षित सेल में टेक्स्ट अपडेट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `UpdateExistingTable.pptx` खोलता है और पहले स्लाइड पर पहली तालिका खोजता है। यह कॉलम 0, पंक्ति 1 के सेल को `New` सेट करता है और परिणाम को `table1_out.pptx` के रूप में सहेजता है। इनपुट में कम से कम एक स्लाइड होनी चाहिए, और उस स्लाइड की पहली तालिका में कम से कम एक स्तंभ और दो पंक्तियाँ होनी चाहिए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[पंक्ति की ऊँचाई नियंत्रित करना](/slides/hi/python-java/manage-rows-and-columns/#control-row-height) के बारे में देखें ताकि मौजूदा तालिका की पंक्ति का आकार बदला जा सके और यह समझा जा सके कि वास्तविक ऊँचाई अनुरोधित न्यूनतम से अधिक क्यों हो सकती है।

## **टेक्स्ट फ़्रेम वाला सेल खोजें**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से एक [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) मिलता है, तो स्वामित्व वाला [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) प्राप्त करने के लिए [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) मेथड का उपयोग करें। एक तालिका-सेल टेक्स्ट फ़्रेम के लिए, [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) मालिक लौटाता है और [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) `None` लौटाता है, भले ही तालिका स्वयं एक शेप हो।

सेल निर्देशांक पढ़ने-केवल [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) और [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) मेथड्स के माध्यम से उपलब्ध होते हैं। [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) भी पढ़ने-केवल नेविगेशन प्रदान करता है: यह मालिक को वापस करता है लेकिन स्वामित्व नहीं बदलता। हमेशा उपयोग करने से पहले `None` के लिए लौटाए गए सेल की जांच करें।

तालिका-सेल और शेप मालिकों की पहचान करने वाला पूरा उदाहरण, जिसमें SmartArt नोड्स से जुड़े शेप्स भी शामिल हैं, के लिए देखें [टेक्स्ट खोजें और बदलें](/slides/hi/python-java/search-and-replace-text/)।

## **तालिका में टेक्स्ट संरेखित करना**

आप व्यक्तिगत तालिका सेल्स की ऊर्ध्वाधर एंकरिंग और टेक्स्ट दिशा को नियंत्रित कर सकते हैं। इस अनुभाग में दिया गया उदाहरण पहली सेल के भीतर टेक्स्ट को केंद्रित करता है और उसे 270 डिग्री घुमाता है।

1. एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) वस्तु जोड़ें।
4. तालिका से एक [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) वस्तु प्राप्त करें।
5. पहले [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) को एक्सेस करें और उसका टेक्स्ट और रंग सेट करें।
6. सेल की ऊर्ध्वाधर एंकरिंग और टेक्स्ट दिशा को [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) और [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType) का उपयोग करके सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

यह उदाहरण 4 × 4 तालिका बनाता है जिसमें स्तंभ चौड़ाई 120 पॉइंट और पंक्ति ऊँचाई 100 पॉइंट है। यह सेल (0, 0) में टेक्स्ट को स्वरूपित करता है, पहली पंक्ति के शेष सेल्स में मान जोड़ता है, और परिणाम को `Vertical_Align_Text_out.pptx` के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका स्तर पर टेक्स्ट स्वरूपण सेट करें**

[setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) का उपयोग करके आप तालिका के सभी सेल्स में टेक्स्ट स्वरूपण लागू कर सकते हैं। इसके ओवरलोड्स भाग, पैराग्राफ, और टेक्स्ट फ्रेम स्वरूपण स्वीकार करते हैं, इसलिए आप इन गुणों को बिना व्यक्तिगत सेल्स में इटरैट किए सेट कर सकते हैं।

1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड से एक [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) वस्तु प्राप्त करें।
4. टेक्स्ट के फ़ॉन्ट आकार को सेट करने के लिए [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) का उपयोग करें।
5. पैराग्राफ संरेखण और दायाँ मार्जिन सेट करने के लिए [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) और [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) का उपयोग करें।
6. टेक्स्ट दिशा सेट करने के लिए [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करें।
7. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `table.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए और पहली शेप तालिका होनी चाहिए। यह फ़ॉन्ट आकार 25 पॉइंट, पैराग्राफ को दाएँ संरेखित (दायाँ मार्जिन 20 पॉइंट) करता है और टेक्स्ट को लंबवत बनाता है। स्वरूपित प्रस्तुति `result.pptx` के रूप में सहेजी जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका शैली गुण प्राप्त करें**

[getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) का उपयोग करके आप तालिका की प्रीसेट शैली पढ़ सकते हैं और [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) से इसे असाइन कर सकते हैं। यह उदाहरण एक तालिका पर [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) लागू करता है, प्रीसेट मान को प्रिंट करता है, और वही प्रीसेट दूसरी तालिका को असाइन करता है। दोनों तालिकाएँ `table-style.pptx` में सहेजी गई हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका का पहलू अनुपात लॉक करें**

तालिका का पहलू अनुपात उसकी चौड़ाई और ऊँचाई के अनुपात को दर्शाता है। तालिका के लिए इस अनुपात को लॉक करने हेतु [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) का उपयोग करें।

नीचे दिया गया उदाहरण `pres.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए और पहली शेप तालिका होनी चाहिए। यह वर्तमान लॉक स्थिति प्रिंट करता है, पहलू अनुपात लॉक सक्षम करता है, अपडेटेड स्थिति (`True`) प्रिंट करता है, और परिणाम को `pres-out.pptx` के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं पूरी तालिका और उसके सेल्स में टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft) मेथड प्रदान करती है, और पैराग्राफ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft) होता है। दोनों का उपयोग करने से सेल्स के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं कैसे सुनिश्चित करूँ कि अंतिम फ़ाइल में उपयोगकर्ता तालिका को स्थानांतरित या आकार बदल न सकें?**

[शेप लॉक](/slides/hi/python-java/applying-protection-to-presentation/) का उपयोग करके स्थानांतरित करने, आकार बदलने, चयन आदि को अक्षम करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या एक सेल के अंदर छवि को बैकग्राउंड के रूप में डालना समर्थित है?**

हां। आप किसी सेल के लिए एक [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्ट्रेस्च या टाइल) के अनुसार सेल क्षेत्र को कवर कर देगी।