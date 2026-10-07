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
- कोशिका विभाजन
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में PowerPoint तालिका कोशिकाओं का प्रबंधन: विलीन कोशिकाओं की पहचान करें, सीमाओं को हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for Python via Java के साथ पृष्ठभूमि रंग और छवियाँ सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उनपर परिवर्तन करने की सुविधा देता है। यह लेख यह बताता है कि विलीन तालिका कोशिकाओं की पहचान कैसे करें, सेल सीमाओं को कैसे हटाएँ, कोशिकाओं के मिलाने या विभाजित करने के बाद क्रमांकण को कैसे संभालें, सेल की पृष्ठभूमि रंग को कैसे बदलें, और तालिका सेल के भीतर एक छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुतीकरण कैसे बनाएँ या खोलें, स्लाइड से तालिका प्राप्त करें, सेल गुणों के माध्यम से सेल स्वरूपण अपडेट करें, और संशोधित प्रस्तुतीकरण को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित सूचकांक का उपयोग करता है ताकि तालिका कोशिकाओं को क्रम `(column, row)` में पहुँच सके।

## **विलीन तालिका सेल की पहचान करें**

उदाहरण मौजूदा प्रस्तुतीकरण को खोलता है और पहली स्लाइड पर पहले आकार को तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। इसके बाद यह सभी पंक्तियों और स्तंभों पर पुनरावृति करता है और [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) का उपयोग करके विलीन क्षेत्रों में कोशिकाओं की पहचान करता है। प्रत्येक मेल के लिये यह `row;column` क्रम में सेल निर्देशांक प्रिंट करता है, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan), और क्षेत्र की प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) तथा [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex)।

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

## **तालिका सेल की सीमाओं को हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाएँ और उसकी पहली स्लाइड पर [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) का उपयोग करके एक तालिका जोड़ें। स्तंभ चौड़ाइयाँ, पंक्ति ऊँचाइयाँ, और तालिका की स्थिति पॉइंट में निर्दिष्ट की जाती है। उदाहरण सभी चार सेल सीमाओं को [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्यमान हो जाती हैं।

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

## **तालिका कोशिकाओं को मिलाएँ**

[mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) का उपयोग करके तालिका कोशिकाओं की आयताकार रेंज को एक ही सेल में संयोजित करें। रेंज के ऊपर‑बाएँ और नीचे‑दाएँ कोनों पर स्थित कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क निर्धारित करता है कि क्या मिलान निर्दिष्ट रेंज के बाहर की कोशिकाओं को शामिल कर सकता है; `False` मिलान को उस रेंज के भीतर रखता है।

उदाहरण 70‑पॉइंट स्तंभों और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है, फिर केंद्रीय चार कोशिकाओं को `(1, 1)` से `(2, 2)` तक मिलाता है। परिणामी सेल दो स्तंभों और दो पंक्तियों को कवर करता है, जबकि तालिका की मूल ग्रिड चार स्तंभों और चार पंक्तियों को बनाए रखती है। मिलाए गए सेल की सामग्री या स्वरूपण तक पहुँचने के लिये, इस उदाहरण में `table.get_Item(1, 1)` का शीर्ष‑बाएँ स्थान उपयोग करें। मिलान रेंज में अन्य स्थान तालिका ग्रिड का हिस्सा बना रहता है, इसलिए रेंज के बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

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

पिछले उदाहरण में कोशिकाओं को मिलाने से तालिका की ग्रिड बनी रहती है। किसी सेल को विभाजित करने से नया ग्रिड स्तंभ बन सकता है और उसके दाएँ स्थित कोशिकाओं के स्तंभ सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 70‑पॉइंट स्तंभों और पंक्तियों के साथ 4‑बाय‑4 तालिका बनाता है और सेल `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) को कॉल करता है। सेल की 70‑पॉइंट चौड़ाई का आधा भाग दो समान‑चौड़ाई वाले कोशिकाओं को बनाने के लिये पास किया जाता है।

इस विभाजन के बाद, दो भागों को `table.get_Item(1, 1)` तथा `table.get_Item(2, 1)` के रूप में पहुँचा जाता है। तालिका ग्रिड अब पाँच स्तंभ रखती है: मूल रूप से स्तंभ 2 और 3 में स्थित कोशिकाएँ क्रमशः स्तंभ 3 और 4 में चली गई हैं। पंक्ति सूचकांक बदले नहीं रहते। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन स्तंभ सूचकांकों का उपयोग करें।

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

### **पंक्ति या स्तंभ विस्तार द्वारा मिलाए गए कोशिकाओं को विभाजित करें**

डेटा भरने के लिये विलीन टेम्प्लेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजन के लिये [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) का उपयोग करें, या स्तंभ सीमा के साथ विभाजन के लिये [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग की पंक्तियों या बाएँ भाग के स्तंभों की गिनती करता है; यह विलीन क्षेत्र के सापेक्ष होता है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan)।
- स्तंभ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan)।

उदाहरण अपेक्षा करता है कि प्रस्तुतीकरण की पहली स्लाइड पर पहला आकार एक तालिका हो, जिसमें `(1, 2)` और `(1, 3)` लंबवत रूप से मिलाए गए हों। निचले स्थान से शुरू करके, यह मूल को खोजने के लिये [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) और [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) का उपयोग करता है और दोनों विस्तारों की जाँच करता है। `splitByRowSpan(1)` फिर उत्पाद नामों के लिये पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो‑स्तंभ मिलान के लिये, इसके बजाय `splitByColSpan(1)` का उपयोग करें।

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

        # विभाजन के बाद तालिका से प्राप्त होने वाली कोशिकाओं को प्राप्त करें।
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

तालिका ग्रिड और आसपास की सेल सूचकांङ्क अपरिवर्तित रहते हैं। परिणामस्वरूप कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ दोनों के विस्तार 1 हैं और [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) `False` प्रिंट करता है। एक विभाजन के बाद बड़े क्षेत्रों के कुछ भाग अभी भी भागिक रूप से मिलाए रह सकते हैं।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) सेल में बना रहता है; नया सेल खाली है लेकिन भराव, सीमाएँ और मार्जिन जैसी सेल स्वरूपण को विरासत में प्राप्त करता है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक पाठ स्वरूपण को स्पष्ट रूप से सेट करें।

सहेजा गया प्रस्तुतीकरण अलग‑अलग "Product A" और "Product B" कोशिकाओं को टेम्प्लेट की सेल स्वरूपण के साथ रखता है। विवरण के लिये [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) देखें।

## **तालिका सेल की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तंभों और 50‑पॉइंट पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) का उपयोग करके ठोस भराव चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) द्वारा लौटाए गए रंग को लाल सेट करता है, जिससे सेल `(2, 3)` (तीसरा स्तंभ और चौथी पंक्ति) लाल हो जाता है।

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

## **तालिका सेल के भीतर छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) से लोड करता है और प्रस्तुतीकरण की छवि संग्रह में [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) के साथ जोड़ता है। फिर यह छवि को सेल `(0, 0)` (तालिका की पहली कोशिका) के चित्र भराव में असाइन करता है।

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) छवि को सेल में भरने के लिये खींचता है, जिससे इसका अनुपात बदल सकता है। स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ पॉइंट में हैं। लोड की गई छवि को `finally` ब्लॉक में प्रस्तुतीकरण में जोड़ने के बाद नष्ट किया जाता है।

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

**क्या मैं एक ही सेल के विभिन्न पक्षों के लिये अलग‑अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) सीमाओं की अलग‑अलग विशेषताएँ होती हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**यदि मैं चित्र को सेल की पृष्ठभूमि के रूप में सेट करने के बाद स्तंभ/पंक्ति आकार बदलूँ तो छवि क्या करती है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच करने पर छवि नए सेल के अनुसार समायोजित होती है; टाइल करने पर टाइलें पुनःगणना की जाती हैं।

**क्या मैं सेल की सभी सामग्री को हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/python-java/manage-hyperlinks/) को टेक्स्ट (portion) स्तर पर या संपूर्ण तालिका/आकार स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को एक भाग या सेल के सभी पाठ पर असाइन करते हैं।

**क्या मैं एक ही सेल के भीतर विभिन्न फॉन्ट सेट कर सकता हूँ?**

हाँ। सेल का टेक्स्ट फ्रेम [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (रन्स) का समर्थन करता है, जिनमें फ़ॉन्ट परिवार, शैली, आकार और रंग जैसी स्वतंत्र स्वरूपण होती है।