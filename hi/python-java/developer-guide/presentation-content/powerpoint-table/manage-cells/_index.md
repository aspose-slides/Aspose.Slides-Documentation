---
title: Python का उपयोग करके प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/python-java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python के लिए Java के माध्यम से Aspose.Slides के साथ PowerPoint तालिका कोशिकाओं का प्रबंधन: मिलाए गए कोशिकाओं की पहचान, सीमाओं को हटाना, कोशिकाओं को विभाजित करना, और पृष्ठभूमि रंग व छवियों को सेट करना।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुति में तालिका की कोशिकाओं को एक्सेस करने और संशोधित करने की सुविधा देता है। यह लेख बताता है कि मिलाए गए तालिका कोशिकाओं की पहचान कैसे करें, कोशिका की सीमाओं को कैसे हटाएँ, कोशिकाओं को मिलाने या विभाजित करने के बाद क्रमांक कैसे काम करता है, कोशिका की पृष्ठभूमि रंग कैसे बदलें, और तालिका कोशिका के भीतर एक छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि कैसे प्रस्तुतिकरण बनाया या खोला जाता है, स्लाइड से तालिका प्राप्त की जाती है, कोशिका गुणों के माध्यम से कोशिका स्वरूपण अपडेट किया जाता है, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजा जाता है।

Aspose.Slides तालिका की कोशिकाओं को एक्सेस करने के लिए शून्य‑आधारित इंडेक्स का उपयोग करता है, क्रम `(column, row)` में।

## **एक मिलाए गए तालिका कोशिका की पहचान करें**

उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहले स्लाइड की पहली आकृति को तालिका के रूप में एक्सेस करता है। यह मानता है कि स्लाइड और आकृति मौजूद हैं और आकृति एक तालिका है। फिर यह सभी पंक्तियों और स्तम्भों को पार करता है और [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) का उपयोग करके मिलाए गए क्षेत्रों की कोशिकाओं की पहचान करता है। प्रत्येक मिलान के लिए यह `row;column` क्रम में कोशिका निर्देशांक, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), तथा क्षेत्र की प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) और [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **तालिका कोशिका की सीमाएँ हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाएँ और उसके पहले स्लाइड में [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) का उपयोग करके एक तालिका जोड़ें। स्तम्भ चौड़ाई, पंक्ति ऊँचाई, और तालिका की स्थिति बिंदुओं में निर्दिष्ट की गई है। उदाहरण सभी चार कोशिका सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) सेट करता है, जिससे वे अदृश्य हो जाती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तिर्यक कोशिका सीमाएँ जोड़ें**

[tgetBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) का उपयोग करके ऊपरी‑बाएँ कोने से निचले‑दाएँ कोने तक एक रेखा खींचें, और [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) का उपयोग करके निचले‑बाएँ कोने से ऊपरी‑दाएँ कोने तक एक रेखा खींचें। एक तिर्यक कोने के शीर्षक को दर्शा सकता है। दोनों तिर्यक मिलकर X बनाते हैं, जिससे कोशिका 'लागू नहीं' के रूप में चिह्नित होती है।

प्रत्येक तिर्यक एक [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/) है। इसके [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) में, [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) का उपयोग करके [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) चुनें और [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) के माध्यम से रंग निर्दिष्ट करें। [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) से रेखा की चौड़ाई बिंदुओं में सेट करें।

उदाहरण एक पंक्ति में तीन कोशिकाएँ बनाता है: एक लाल नीचे‑तिर्यक, एक नीला ऊपर‑तिर्यक, और दोनों तिर्यकों वाला। यह शीर्ष, नीचे, बाएँ और दाएँ कोशिका सीमाओं को अपरिवर्तित छोड़ देता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

एक तिर्यक स्वरूपण गुण है, कोशिका विभाजन नहीं। प्रत्येक कोशिका में एक ही टेक्स्ट फ्रेम रहता है, जिसे आप [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) के माध्यम से एक्सेस कर सकते हैं। तिर्यक के दोनों पक्षों के क्षेत्रों को स्वतंत्र रूप से संपादित नहीं किया जा सकता।

सहेजी गई तालिका, Microsoft PowerPoint में रेंडर की गई:

![तीन तालिका कोशिकाएँ जो बाएँ‑ऊपर से दाएँ‑नीचे तक लाल तिर्यक, बाएँ‑नीचे से दाएँ‑ऊपर तक नीला तिर्यक, और दोनों तिर्यक मिलाकर X दर्शाती हैं।](diagonal-cell-borders.png)

*बाएँ से दाएँ: नीचे की ओर तिर्यक (लाल, 3 pt), ऊपर की ओर तिर्यक (नीला, 5 pt), और दोनों तिर्यक।*

## **तालिका कोशिकाओं को मिलाएँ**

[mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) का उपयोग करके तालिका कोशिकाओं की आयताकार सीमा को एक कोशिका में संयोजित करें। सीमा के ऊपरी‑बाएँ और निचले‑दाएँ कोनों की कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि क्या मिलाने में निर्दिष्ट सीमा के बाहर की कोशिकाओं को शामिल किया जा सके; `False` मिलाने को केवल उस सीमा के भीतर रखता है।

उदाहरण 70‑बिंदु स्तम्भ और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रीय कोशिकाओं को मिलाता है। परिणामी कोशिका दो स्तम्भों और दो पंक्तियों में फैली होती है, जबकि तालिका की मूल ग्रिड चार स्तम्भ और चार पंक्तियों को बनाए रखती है। मिलाए गए कोशिका की सामग्री या स्वरूपण को एक्सेस करने के लिए उसकी ऊपरी‑बाएँ स्थिति का उपयोग करें: इस उदाहरण में `table.get_Item(1, 1)`। मिलाए गए क्षेत्र में अन्य स्थितियाँ तालिका ग्रिड का हिस्सा बनी रहती हैं, इसलिए सीमा के बाहर की कोशिकाओं के संकेतक नहीं बदलते।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका कोशिकाओं को विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मिलाने से तालिका की ग्रिड बनी रहती है। एक कोशिका को विभाजित करने से नई ग्रिड स्तम्भ बन सकता है और दाईं ओर की कोशिकाओं के स्तम्भ संकेतक बदल सकते हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70‑बिंदु स्तम्भ और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है और कोशिका `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) कॉल करता है। कोशिका की 70‑बिंदु चौड़ाई का आधा भाग दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिये पास किया जाता है।

इस विभाजन के बाद, दो भागों को `table.get_Item(1, 1)` और `table.get_Item(2, 1)` से एक्सेस किया जाता है। तालिका ग्रिड अब पाँच स्तम्भ रखता है: मूलतः स्तम्भ 2 और 3 में मौजूद कोशिकाएँ क्रमशः स्तम्भ 3 और 4 में चली गईं। पंक्ति संकेतक अपरिवर्तित रहते हैं। विभाजन के बाद कोशिकाओं को एक्सेस करते समय इन अपडेटेड स्तम्भ संकेतकों का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![एक अनमर्ज्ड 70‑बिंदु कोशिका दो 35‑बिंदु कोशिकाओं में विभाजित होती है, जिससे पाँचवाँ ग्रिड स्तम्भ जुड़ता है और दाएँ के संकेतक शिफ्ट होते हैं।](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*चौड़ाई विभाजन कोशिका (1, 1) को प्रभावित करता है, शून्य‑आधारित (column, row) संकेतक का प्रयोग करते हुए। अन्य पंक्तियाँ दोनों नए स्तम्भ स्थितियों को कवर करने वाली एक कोशिका को रखती हैं।*
<!-- visual-explanation:manage-cells:end -->

### **पंक्ति या स्तम्भ स्पैन के द्वारा मिलाए गए कोशिकाओं को विभाजित करें**

मिलाए गए टेम्पलेट कोशिकाओं को डेटा भरने के लिये तैयार करने हेतु, [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) का उपयोग करके मौजूदा पंक्ति सीमा के अनुसार विभाजन करें, या [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) का उपयोग करके स्तम्भ सीमा के अनुसार विभाजन करें।

`index` तर्क विभाजन के बाएँ भाग या ऊपर वाले भाग में पंक्तियों/स्तम्भों की गिनती करता है; यह मिलाए गये क्षेत्र के सापेक्ष होता है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)।
- स्तम्भ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)।

उदाहरण मानता है कि प्रस्तुति में पहले स्लाइड की पहली आकृति एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` ऊर्ध्वाधर रूप से मिलाए गए हैं। निचली स्थिति से शुरू करके यह [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) और [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) का उपयोग करके मूल बिंदु खोजता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` तब पंक्तियों 2 और 3 को अलग करता है ताकि उत्पाद नाम रखे जा सकें। क्षैतिज दो‑स्तम्भ मिलान के लिये `splitByColSpan(1)` का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # विभाजन के बाद तालिका से प्राप्त हुई कोशिकाओं को प्राप्त करें.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

तालिका ग्रिड और आसपास की कोशिका संकेतक अपरिवर्तित रहते हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ दोनों की स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) `False` दिखाता है। एक विभाजन के बाद बड़े क्षेत्रों का भाग‑भाग में मिलाए रहना संभव है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में बना रहता है; नई कोशिका खाली होती है लेकिन फॉर्मेटिंग जैसे भराव, सीमाएँ, तथा मार्जिन विरासत में लेती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक किसी भी टेक्स्ट स्वरूपण को स्पष्ट रूप से सेट करें।

सहेजा गया प्रस्तुति अलग‑अलग "Product A" और "Product B" कोशिकाएँ दिखाता है, जिसमें टेम्पलेट की कोशिका स्वरूपण बनी रहती है। विवरण के लिये देखें [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/)।

### **निर्दिष्ट ऊँचाई पर एक कोशिका को विभाजित करें**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) ऊपरी भाग की ऊँचाई बिंदुओं में लेता है। [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) ऊपरी भाग में मौजूदा ग्रिड पंक्तियों की संख्या लेता है। 40‑बिंदु की कोशिका को दाएँ स्तम्भ में केंद्रित करने के लिये, कोशिका की वास्तविक ऊँचाई से 40 घटाएँ और शेष स्थान को बराबर‑बराबर ऊपर और नीचे विभाजित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

पहला विभाजन एक ग्रिड पंक्ति जोड़ता है और `(1, 1)` में निचले 90 बिंदु छोड़ता है। दूसरा विभाजन उस कोशिका को 40‑बिंदु मध्य कोशिका और 50‑बिंदु निचली कोशिका में बाँटता है। दाएँ स्तम्भ में अब तीन कोशिकाएँ हैं, ऊँचाइयाँ क्रमशः 50, 40 और 50 बिंदु ऊपर‑से‑नीचे हैं। बायाँ कोशिका सभी तीन पंक्तियों को कवर करता है और अपनी मूल 140 बिंदु की ऊँचाई बनाए रखता है।

![बायाँ कोशिका पूरी तालिका की ऊँचाई को कवर करता है, जबकि तीन कोशिकाएँ मध्य में स्थित हैं।](split-by-height.png)

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑बिंदु स्तम्भ और 50‑बिंदु पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) का उपयोग करके ठोस भराव चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) द्वारा प्राप्त रंग को लाल सेट करता है, कोशिका `(2, 3)` के लिये, जो तृतीय स्तम्भ और चतुर्थ पंक्ति में है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एक तालिका कोशिका के भीतर छवि जोड़ें**

उदाहरण चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) से लोड करता है और प्रस्तुति की इमेज कलेक्शन में [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) के साथ जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` के पिक्चर फ़िल में असाइन करता है, जो तालिका की पहली कोशिका है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) छवि को कोशिका भरने के लिये फैलाता है, जिससे उसका अनुपात बदल सकता है। स्तम्भ चौड़ाई और पंक्ति ऊँचाई बिंदुओं में हैं। लोड की गई छवि को `finally` ब्लॉक में नष्ट किया जाता है, जब वह प्रस्तुति में जोड़ दी गई हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिये अलग‑अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हँ। शीर्ष‑[top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/नीचे‑[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/बाएँ‑[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/दाएँ‑[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) सीमाओं की अलग‑अलग प्रॉपर्टी होती है, इसलिए प्रत्येक पक्ष की मोटाई व शैली भिन्न हो सकती है।

**यदि मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद स्तम्भ/पंक्ति का आकार बदलूँ तो क्या होगा?**

वर्ताव [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच करने पर चित्र नई कोशिका के अनुसार समायोजित हो जाता है; टाइल करने पर टाइल्स पुनः गणना की जाती हैं।

**क्या मैं पूरे कोशिका की सामग्री पर एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/python-java/manage-hyperlinks/) को कोशिका के टेक्स्ट (portion) स्तर पर या पूरी तालिका/आकृति स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को एक पोर्शन या कोशिका के सभी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हँ। कोशिका का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) को समर्थन देता है, जिनमें फ़ॉन्ट फ़ैमिली, शैली, आकार और रंग जैसी स्वतंत्र स्वरूपण हो सकती है।