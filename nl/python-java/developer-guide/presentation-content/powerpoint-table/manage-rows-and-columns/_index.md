---
title: Beheer rijen en kolommen in PowerPoint‑tabellen met Python
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/python-java/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak van rij
- tekstopmaak van kolom
- tabelstijl
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor Python via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Introductie**

Om u in staat te stellen de rijen en kolommen van een tabel in een PowerPoint‑presentatie te beheren, biedt Aspose.Slides de [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) klasse en vele andere typen.

## **Stel de eerste rij in als koptekst**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de presentatie.  
2. Haal een referentie naar een dia op basis van de index.  
3. Maak een referentie naar een [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) en stel deze in op `None`.  
4. Iterate door alle [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/) objecten om de betreffende tabel te vinden.  
5. Stel de eerste rij van de tabel in als koptekst.

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

## **Kloon een tabelrij of -kolom**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de presentatie.  
2. Haal een referentie naar een dia op basis van de index.  
3. Definieer een lijst met kolombreedtes.  
4. Definieer een lijst met rijhoogtes.  
5. Voeg een [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addTable) methode.  
6. Kloon de tabelrij.  
7. Kloon de tabelkolom.  
8. Sla de gewijzigde presentatie op.

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

## **Verwijder een rij of kolom uit een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.  
2. Haal een referentie naar een dia op basis van de index.  
3. Definieer een lijst met kolombreedtes.  
4. Definieer een lijst met rijhoogtes.  
5. Voeg een [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addTable) methode.  
6. Verwijder de tabelrij.  
7. Verwijder de tabelkolom.  
8. Sla de gewijzigde presentatie op.

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

## **Stel tekstopmaak in op rijniveau van de tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de presentatie.  
2. Haal een referentie naar een dia op basis van de index.  
3. Verkrijg het relevante [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object van de dia.  
4. Stel de lettergrootte van de cellen in de eerste rij in met behulp van [setFontHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Stel de tekstuitlijning en de rechter marge van de cellen in de eerste rij in met behulp van [setAlignment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setAlignment) en [setMarginRight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Stel het verticale teksttype van de cellen in de tweede rij in met behulp van [setTextVerticalType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Sla de gewijzigde presentatie op.

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

## **Stel tekstopmaak in op kolomniveau van de tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse en laad de presentatie.  
2. Haal een referentie naar een dia op basis van de index.  
3. Verkrijg het relevante [Table](https://reference.aspose.com/slides/nl/python-java/aspose.slides/table/) object van de dia.  
4. Stel de lettergrootte van de cellen in de eerste kolom in met behulp van [setFontHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Stel de tekstuitlijning en de rechter marge van de cellen in de eerste kolom in met behulp van [setAlignment](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setAlignment) en [setMarginRight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Stel het verticale teksttype van de cellen in de tweede kolom in met behulp van [setTextVerticalType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Sla de gewijzigde presentatie op.

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

## **Haal tabelstijl‑eigenschappen op**

Aspose.Slides stelt u in staat de stijl‑eigenschappen van een tabel op te halen, zodat u die details voor een andere tabel of elders kunt gebruiken. Deze Python‑code laat zien hoe u de stijl‑eigenschappen van een vooraf ingestelde tabelstijl kunt ophalen:

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

**Kan ik PowerPoint‑thema's/stijlen toepassen op een tabel die al is aangemaakt?**

Ja. De tabel erft het thema van de dia/lay-out/master, en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, tabellen van Aspose.Slides hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen opnieuw in die volgorde.

**Kan ik afwisselend (gestreept) gekleurde kolommen hebben terwijl ik aangepaste kleuren behoud voor specifieke cellen?**

Ja. Schakel afwisselende kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op cel‑niveau heeft voorrang boven de tabelstijl.