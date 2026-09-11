---
title: Hantera rader och kolumner i PowerPoint-tabeller med Python
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/python-java/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första raden
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- radtextformatering
- kolumntextformatering
- tabellstil
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för Python via Java och snabba upp redigering av presentationer och datauppdateringar."
---
## **Introduktion**

För att låta dig hantera en tabells rader och kolumner i en PowerPoint-presentation tillhandahåller Aspose.Slides klassen [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/) och många andra typer.

## **Ställ in den första raden som rubrik**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in presentationen.  
2. Hämta en referens till en bild genom dess index.  
3. Skapa en referens till en [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/) och sätt den till `None`.  
4. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/)‑objekt för att hitta den relevanta tabellen.  
5. Ställ in tabellens första rad som dess rubrik.

Denna Python‑kod visar hur du ställer in en tabells första rad som rubrik:

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

## **Klona en tabellrad eller kolumn**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in presentationen.  
2. Hämta en referens till en bild genom dess index.  
3. Definiera en lista med kolumnbredder.  
4. Definiera en lista med radhöjder.  
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addTable).  
6. Klona tabellraden.  
7. Klona tabellkolumnen.  
8. Spara den modifierade presentationen.

Denna Python‑kod visar hur du klonar en PowerPoint‑tabells rad eller kolumn:

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

## **Ta bort en rad eller kolumn från en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).  
2. Hämta en referens till en bild genom dess index.  
3. Definiera en lista med kolumnbredder.  
4. Definiera en lista med radhöjder.  
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addTable).  
6. Ta bort tabellraden.  
7. Ta bort tabellkolumnen.  
8. Spara den modifierade presentationen.

Denna Python‑kod visar hur du tar bort en rad eller kolumn från en tabell:

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

## **Ställ in textformatering på radnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in presentationen.  
2. Hämta en referens till en bild genom dess index.  
3. Få åtkomst till det relevanta [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objektet på bilden.  
4. Ställ in teckenhöjden för cellerna i den första raden med [setFontHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ställ in textjusteringen och högermarginalen för cellerna i den första raden med [setAlignment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setAlignment) och [setMarginRight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Ställ in den vertikala texttypen för cellerna i den andra raden med [setTextVerticalType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Spara den modifierade presentationen.

Denna Python‑kod demonstrerar operationen:

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

## **Ställ in textformatering på kolumnnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och läs in presentationen.  
2. Hämta en referens till en bild genom dess index.  
3. Få åtkomst till det relevanta [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/)‑objektet på bilden.  
4. Ställ in teckenhöjden för cellerna i den första kolumnen med [setFontHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ställ in textjusteringen och högermarginalen för cellerna i den första kolumnen med [setAlignment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setAlignment) och [setMarginRight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Ställ in den vertikala texttypen för cellerna i den andra kolumnen med [setTextVerticalType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Spara den modifierade presentationen.

Denna Python‑kod demonstrerar operationen:

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

## **Hämta tabellens stilegenskaper**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna Python‑kod visar hur du får stilegenskaperna från en förinställd tabellstil:

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

**Kan jag applicera PowerPoint‑teman/stilar på en redan skapad tabell?**

Ja. Tabellen ärver slide/layout/master‑temat, och du kan ändå åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först, och fyll sedan tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner och åsidosätt sedan specifika celler med lokal formatering; formatering på cellnivå har företräde framför tabellstilen.