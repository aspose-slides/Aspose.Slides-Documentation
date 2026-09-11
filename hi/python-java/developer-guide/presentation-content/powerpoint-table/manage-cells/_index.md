---
title: Python का उपयोग करके प्रस्तुतियों में तालिका कोशिकाओं को प्रबंधित करें
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/python-java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मर्ज करें
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में चित्र
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Java के माध्यम से Python के लिए Aspose.Slides के साथ PowerPoint में तालिका कोशिकाओं को आसानी से प्रबंधित करें। शीघ्रता से कोशिकाओं तक पहुँचने, उन्हें संशोधित करने और शैली देने में निपुण बनें ताकि स्लाइड ऑटोमेशन सुगमता से हो सके।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि कैसे मर्ज्ड तालिका कोशिकाओं की पहचान करें, कोशिका की सीमाएँ हटाएँ, मर्ज या स्प्लिट करने के बाद कोशिका क्रमांक के साथ काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के अंदर एक चित्र जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से फ़ॉर्मेटिंग अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

## **मर्ज्ड तालिका कोशिका की पहचान**

1. Presentation क्लास का एक इंस्टेंस बनाएँ।
2. पहली स्लाइड से तालिका प्राप्त करें।
3. मर्ज्ड कोशिकाओं को खोजने के लिए तालिका की पंक्तियों और कॉलमों के माध्यम से इटररेट करें।
4. जब मर्ज्ड कोशिकाएँ मिलें, तो एक संदेश प्रिंट करें।

This Python code shows you how to identify merged table cells in a presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # मान लीजिए कि पहली स्लाइड पर पहला आकार एक तालिका है।
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **तालिका कोशिका की सीमाएँ हटाएँ**

1. Presentation क्लास का एक इंस्टेंस बनाएँ।
2. अपनी सूचकांक से स्लाइड का संदर्भ प्राप्त करें।
3. कॉलम चौड़ाइयों की एक सूची निर्धारित करें।
4. पंक्ति ऊँचाइयों की एक सूची निर्धारित करें।
5. [addTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addTable) मेथड के माध्यम से स्लाइड में एक तालिका जोड़ें।
6. प्रत्येक कोशिका के ऊपर, नीचे, दाएँ और बाएँ सीमा को साफ़ करने के लिए सभी कोशिकाओं के माध्यम से इटररेट करें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

This Python code shows you how to remove the borders from table cells:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # पहले स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)

    # कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # स्लाइड में एक तालिका जोड़ें।
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # प्रत्येक कोशिका के लिए सीमा फ़ॉर्मेट सेट करें।
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मर्ज्ड कोशिकाओं में क्रमांक**

यदि हम दो जोड़े कोशिकाओं को मर्ज करते हैं, (1, 1) और (2, 1), तथा (1, 2) और (2, 2), तो परिणामी तालिका अपना कोशिका क्रमांक बरकरार रखती है। यह Python कोड इस प्रक्रिया को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # पहले स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)

    # कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # स्लाइड में एक तालिका जोड़ें।
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # प्रत्येक कोशिका के लिए सीमा फ़ॉर्मेट सेट करें।
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


    # कोशिकाओं (1, 1) और (2, 1) को मर्ज करें।
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # कोशिकाओं (1, 2) और (2, 2) को मर्ज करें।
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

इसके बाद हम (1, 1) और (1, 2) को मर्ज करके कोशिकाओं को आगे मर्ज करते हैं। परिणामस्वरूप तालिका के मध्य में एक बड़ा मर्ज्ड कोशिका वाला एक टेबल बनता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)

    # कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # स्लाइड में एक तालिका जोड़ें।
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # प्रत्येक कोशिका के लिए सीमा फ़ॉर्मेट सेट करें।
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


    # कोशिकाओं (1, 1) और (2, 1) को मर्ज करें।
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # कोशिकाओं (1, 2) और (2, 2) को मर्ज करें।
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # कोशिकाओं (1, 1) और (1, 2) को मर्ज करें।
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्प्लिट कोशिका में क्रमांक**

पिछले उदाहरणों में, तालिका कोशिकाओं को मर्ज करने से अन्य कोशिकाओं का क्रमांक नहीं बदला।

इस बार, हम एक सामान्य तालिका (बिना मर्ज्ड कोशिकाओं वाली) लेते हैं और फिर (1, 1) कोशिका को स्प्लिट करने का प्रयास करते हैं ताकि एक विशेष तालिका प्राप्त हो सके। आपको इस तालिका के क्रमांक पर ध्यान देना चाहिए, जिसे अजीब माना जा सकता है। लेकिन यही माइक्रोसॉफ्ट PowerPoint तालिका कोशिकाओं को क्रमांकित करता है और Aspose.Slides भी यही करता है।

This Python code demonstrates the process we described:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)

    # कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # स्लाइड में एक तालिका जोड़ें।
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # प्रत्येक कोशिका के लिए सीमा फ़ॉर्मेट सेट करें।
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


    # कोशिका (1, 1) को विभाजित करें।
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

This Python code shows you how to change a table cell's background color:

```python
import jpway
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # पहली स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)

    # कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # स्लाइड में एक तालिका जोड़ें।
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # एक कोशिका के लिए पृष्ठभूमि रंग सेट करें।
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **तालिका कोशिका के अंदर चित्र जोड़ें**

1. Presentation क्लास का एक इंस्टेंस बनाएँ।
2. अपनी सूचकांक से स्लाइड का संदर्भ प्राप्त करें।
3. कॉलम चौड़ाइयों की एक सूची निर्धारित करें।
4. पंक्ति ऊँचाइयों की एक सूची निर्धारित करें।
5. [addTable](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addTable) मेथड के माध्यम से स्लाइड में एक तालिका जोड़ें।
6. [Images.fromFile](https://reference.aspose.com/slides/hi/python-java/aspose.slides/images/#fromFile) का उपयोग करके चित्र फ़ाइल लोड करें।
7. प्रस्तुति में चित्र जोड़ें ताकि एक [PPImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ppimage/) ऑब्जेक्ट बनाया जा सके।
8. तालिका कोशिका की [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/) भरने के प्रकार को [FillType.Picture](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/#Picture) पर सेट करें।
9. चित्र को तालिका की पहली कोशिका में जोड़ें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

This Python code shows you how to place an image inside a table cell when creating a table:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # पहले स्लाइड तक पहुँचें।
    slide = presentation.getSlides().get_Item(0)

    # कॉलम चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # स्लाइड में एक तालिका जोड़ें।
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # छवि फ़ाइल से प्रस्तुति की छवि बनाएं।
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # चित्र को पहली तालिका कोशिका में जोड़ें।
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं किसी एकल कोशिका के विभिन्न पक्षों के लिए अलग‑अलग लाइन की मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cellformat/#getBorderRight) सीमाओं की अलग‑अलग गुण होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली भिन्न हो सकती है। यह लेख में प्रदर्शित सेल के प्रति‑पक्ष सीमा नियंत्रण से तार्किक रूप से जुड़ा है।

**यदि मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद कॉलम/पंक्ति का आकार बदलूँ तो क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग पर, चित्र नई कोशिका के अनुसार समायोजित होता है; टाइलिंग पर, टाइलें पुनः गणना की जाती हैं। लेख में कोशिका में चित्र प्रदर्शन मोड का उल्लेख है।

**क्या मैं किसी कोशिका की सभी सामग्री पर हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/python-java/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/shape स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को किसी portion या संपूर्ण टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर अलग‑अलग फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। कोशिका के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) (रन) स्वतंत्र फ़ॉर्मेटिंग—फ़ॉन्ट फैमिली, शैली, आकार और रंग—का समर्थन करते हैं।