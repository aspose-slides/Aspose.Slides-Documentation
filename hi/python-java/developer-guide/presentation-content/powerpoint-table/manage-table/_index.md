---
title: Python में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/python-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- अस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सहज बनाने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी प्रदर्शित करने का एक प्रभावी तरीका है। कोशिकाओं की ग्रिड में (पंक्तियों और स्तंभों में व्यवस्थित) जानकारी सीधी और समझने में आसान है।

Aspose.Slides एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) क्लास, [Cell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/) क्लास, और अन्य प्रकार प्रदान करता है जिससे आप विभिन्न प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरुआत से तालिका बनाना**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की नई उदाहरण बनाएँ।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. कॉलम चौड़ाइयों की सूची निर्धारित करें।
4. पंक्ति ऊँचाइयों की सूची निर्धारित करें।
5. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट को [addTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addTable) मेथड के माध्यम से जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/) पर इटरेट करके शीर्ष, नीचे, दाएँ और बाएँ किनारों पर स्वरूपण लागू करें।
7. तालिका की पहली पंक्ति की पहले दो कोशिकाओं को मिलाएँ।
8. [Cell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/) के [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) तक पहुँचें।
9. [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि प्रस्तुति में तालिका कैसे बनानी है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
presentation = Presentation()
try:

    # पहली स्लाइड तक पहुँचता है
    slide = presentation.getSlides().get_Item(0)

    # कॉलमों की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # स्लाइड पर एक तालिका आकार जोड़ता है
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # प्रत्येक कोशिका के लिए बॉर्डर फ़ॉर्मेट सेट करता है
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

    # पंक्ति 1 की सेल 1 और 2 को मिलाता है
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # मर्ज की गई सेल में कुछ टेक्स्ट जोड़ता है
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # प्रस्तुति को डिस्क पर सहेजता है
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मानक तालिका में क्रमांकण**

मानक तालिका में, कोशिकाओं का क्रमांकण सरल और शून्य-आधारित होता है। तालिका की पहली कोशिका को 0,0 (कॉलम 0, पंक्ति 0) के रूप में अनुक्रमित किया जाता है।

उदाहरण के लिए, 4 कॉलम और 4 पंक्तियों वाली तालिका में कोशिकाएँ इस प्रकार क्रमांकित की जाती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह Python कोड दर्शाता है कि मानक सेल क्रमांकण के साथ तालिका कैसे बनानी है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
presentation = Presentation()
try:

    # पहली स्लाइड तक पहुँचता है
    slide = presentation.getSlides().get_Item(0)

    # कॉलम की चौड़ाइयाँ और पंक्तियों की ऊँचाइयाँ परिभाषित करता है
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # स्लाइड में एक तालिका आकार जोड़ता है
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # प्रस्तुति को डिस्क पर सहेजता है
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मौजूदा तालिका तक पहुँचें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की नई उदाहरण बनाएँ।
2. इंडेक्स के माध्यम से तालिका वाली स्लाइड का संदर्भ प्राप्त करें।
3. [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट के लिए एक वेरिएबल प्रारंभ करें और इसे `None` सेट करें।
4. सभी [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटरेट करें जब तक तालिका नहीं मिलती।

   यदि आपको संदेह है कि जिस स्लाइड को आप देख रहे हैं वह केवल एक तालिका रखती है, तो आप उसमें मौजूद सभी शेप्स को सरलता से जांच सकते हैं। जब कोई शेप तालिका के रूप में पहचाना जाता है, तो आप इसे एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट के रूप में उपयोग कर सकते हैं। लेकिन यदि उस स्लाइड में कई तालिकाएँ हैं, तो आप अपनी आवश्यक तालिका को उसके [getAlternativeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getAlternativeText) के माध्यम से खोजना बेहतर है।
5. तालिका के साथ काम करने के लिए [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में, हम दूसरी पंक्ति के पहले कॉलम में टेक्स्ट को अपडेट करते हैं।
6. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि मौजूदा तालिका तक कैसे पहुँचा जाए और उसके साथ कैसे काम किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # पहली स्लाइड तक पहुँचता है
    slide = presentation.getSlides().get_Item(0)

    # टेबल संदर्भ को प्रारंभ करता है।
    table = None

    # शेप्स के माध्यम से इटरेट करता है और मिलने वाली तालिका का संदर्भ सेट करता है
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # दूसरी पंक्ति के पहले कॉलम के टेक्स्ट को सेट करता है
            table.get_Item(0, 1).getTextFrame().setText("New")

    # परिवर्तित प्रस्तुति को डिस्क पर सहेजता है
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ऐसे सेल को खोजें जो टेक्स्ट फ्रेम का मालिक है**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) प्राप्त होता है, तो मालिक [Cell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/) को प्राप्त करने के लिए [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParentCell) मेथड का उपयोग करें। तालिका-सेल टेक्स्ट फ्रेम के लिए, [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParentCell) मालिक को लौटाता है और [TextFrame.getParentShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParentShape) `None` लौटाता है, हालांकि तालिका स्वयं एक शेप है।

सेल कॉर्डिनेट्स को पढ़ने-केवल वाले [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/#getFirstColumnIndex) और [Cell.getFirstRowIndex](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/#getFirstRowIndex) मेथड्स के माध्यम से प्राप्त किया जा सकता है। [TextFrame.getParentCell](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/#getParentCell) पढ़ने-केवल नेविगेशन भी प्रदान करता है: यह मालिक को लौटाता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा लौटाए गए सेल की `None` जाँच करें।

एक पूर्ण उदाहरण के लिए जो तालिका-सेल और शेप मालिकों को पहचानता है, जिसमें SmartArt नोड्स से जुड़े शेप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/python-java/search-and-replace-text/)।

## **तालिका में टेक्स्ट को संरेखित करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की नई उदाहरण बनाएँ।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) ऑब्जेक्ट तक पहुँचें।
5. [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) ऑब्जेक्ट के [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) तक पहुँचें।
6. टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करें।
7. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि तालिका में टेक्स्ट को कैसे संरेखित किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Presentation क्लास का एक उदाहरण बनाता है
presentation = Presentation()
try:

    # पहली स्लाइड प्राप्त करता है
    slide = presentation.getSlides().get_Item(0)

    # कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # स्लाइड में तालिका आकार जोड़ता है
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # टेक्स्ट फ्रेम तक पहुँचता है
    text_frame = table.get_Item(0, 0).getTextFrame()

    # टेक्स्ट फ्रेम में पहला पैराग्राफ पहुँचता है।
    paragraph = text_frame.getParagraphs().get_Item(0)

    # पैराग्राफ में पहला भाग पहुँचता है।
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करता है
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # प्रस्तुति को डिस्क पर सहेजता है
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **टेबल स्तर पर टेक्स्ट फॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की नई उदाहरण बनाएँ।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड से एक [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) ऑब्जेक्ट तक पहुँचें।
4. [setFontHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setFontHeight) का उपयोग करके टेक्स्ट का फ़ॉन्ट ऊँचाई सेट करें।
5. [setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) और [setMarginRight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setMarginRight) का उपयोग करके संरेखण और दाहिना मार्जिन सेट करें।
6. [setTextVerticalType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setTextVerticalType) द्वारा ऊर्ध्वाधर टेक्स्ट प्रकार सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

यह Python कोड दर्शाता है कि तालिका में टेक्स्ट पर अपने पसंदीदा फॉर्मेटिंग विकल्प कैसे लागू करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Presentation क्लास का एक उदाहरण बनाता है
presentation = Presentation("simpletable.pptx")
try:

    # मान लेते हैं कि पहली स्लाइड की पहली शेप एक तालिका है
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # तालिका कोशिकाओं का फ़ॉन्ट आकार सेट करता है
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # एक ही कॉल में तालिका कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन सेट करता है
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # तालिका कोशिकाओं का टेक्स्ट ऊर्ध्वाधर प्रकार सेट करता है
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **टेबल शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह Python कोड दर्शाता है कि तालिका के प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # डिफ़ॉल्ट शैली प्रीसेट थीम बदलें

    # तालिका का शैली प्रीसेट प्राप्त करता है
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # प्राप्त किए गए शैली प्रीसेट को दूसरी तालिका पर लागू करता है
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **टेबल का एस्पेक्ट रेशियो लॉक करें**

एक ज्यामितीय आकार का एस्पेक्ट रेशियो विभिन्न आयामों में उसके आकारों का अनुपात होता है। Aspose.Slides [setAspectRatioLocked](https://reference.aspose.com/slides/hi/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) मेथड प्रदान करता है जिससे आप तालिकाओं और अन्य आकारों के लिए एस्पेक्ट रेशियो सेटिंग को लॉक कर सकते हैं।

यह Python कोड दर्शाता है कि तालिका के लिए एस्पेक्ट रेशियो कैसे लॉक किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # उलटा
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ-से-बाएँ (RTL) रीडिंग दिशा सक्षम कर सकता हूँ?**

हाँ। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/#setRightToLeft) मेथड प्रदान करती है, और पैराग्राफ में [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setRightToLeft) होता है। दोनों का उपयोग करने से कोशिकाओं के अंदर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को मूव या रिसाइज़ करने से कैसे रोक सकता हूँ?**

उपयोगकर्ताओं को मूव, रिसाइज़, चयन आदि को निष्क्रिय करने के लिए [shape locks](/slides/hi/python-java/applying-protection-to-presentation/) का उपयोग करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या सेल के अंदर एक छवि को बैकग्राउंड के रूप में डालना समर्थित है?**

हाँ। आप एक सेल के लिए [picture fill](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्ट्रैच या टाइल) के अनुसार सेल क्षेत्र को कवर कर देगी।