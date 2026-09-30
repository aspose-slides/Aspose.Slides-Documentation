---
title: Beheer rijen en kolommen in PowerPoint-tabellen met Python
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
- rij-tekstopmaak
- kolom-tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor Python via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Inleiding**

Aspose.Slides for Python via Java stelt u in staat om de tabelstructuur en opmaak in PowerPoint‑presentaties te beheren via de [Tabel](https://reference.aspose.com/slides/python-java/aspose.slides/table/)-klasse. U kunt een header‑rij aanwijzen, rijen en kolommen klonen of verwijderen, en tekstopmaak toepassen op een volledige rij of kolom.

Dit artikel legt deze bewerkingen uit met Python‑voorbeelden. Het laat ook zien hoe u de stijl‑preset van een tabel kunt ophalen zodat u deze kunt hergebruiken. De indices van tabelrijen en -kolommen beginnen bij nul.

## **Rijhoogte regelen**

Gebruik [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) om de minimale hoogte van een rij in punten in te stellen. Het is een ondergrens, geen vaste hoogte. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) retourneert de werkelijke hoogte. Toegang tot de rij verkrijgt u via [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

Het voorbeeld laadt [row-height-input.pptx](row-height-input.pptx), waarin een tabel zich bevindt als de eerste vorm op de eerste dia. De eerste rij begint op 70 punten. De cellen gebruiken 18‑punt Arial‑tekst, tekstomloop en marges van 6 punten boven‑ en onderaan; de langere tekst in de tweede kolom omslaat naar meerdere regels. Het voorbeeld verhoogt de minimumwaarde naar 100 punten, verlaagt deze vervolgens naar 20 punten, drukt na elke wijziging de werkelijke hoogte af en slaat beide resultaten op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Met de meegeleverde presentatie voegt het verhogen van de minimumwaarde ruimte toe aan de rij. Het verlagen ervan verwijdert die extra ruimte, maar de feitelijke hoogte blijft groter dan 20 punten omdat de tekst en celmarges meer ruimte nodig hebben. Alleen het verlagen van de minimumwaarde kan de rij niet onder de door de inhoud vereiste ruimte dwingen.

Verschillende factoren beïnvloeden de feitelijke hoogte:

- **Tekst en lettergrootte:** langere tekst, expliciete regeleinden of een groter lettertype kan meer verticale ruimte vereisen.
- **Tekstomloop en kolombreedte:** bij ingeschakelde tekstomloop kan het verkleinen van de kolombreedte met [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) meer regels opleveren. Een bredere kolom kan de benodigde verticale ruimte verminderen.
- **Celmarges:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) en [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) voegen verticale ruimte toe. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) en [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) verkleinen de breedte die beschikbaar is voor tekst en kunnen extra tekstomloop veroorzaken.

Voor deze tabel zonder samengevoegde cellen bepaalt de cel die de meeste verticale ruimte nodig heeft de inhoud‑gedreven ondergrens voor de gehele rij. Om de rij korter te maken, moet u mogelijk de tekst inkorten, de lettergrootte of marges verkleinen, of een kolom breder maken.

De afbeeldingen hieronder tonen dezelfde tabel op dezelfde schaal. In de geïllustreerde resultaten waren de feitelijke hoogtes 70, 100 en 55,2 punten: de laatste rij bleef hoger dan het minimum van 20 punten. Exacte tekstmetingen kunnen variëren afhankelijk van de lettertypen die in uw omgeving beschikbaar zijn. Download de opgeslagen resultaten: [verhoogd minimum](row-height-increased.pptx) en [verlaagd minimum](row-height-decreased.pptx).

| Origineel: minimum 70 pt, feitelijk 70 pt | Verhoogd: minimum 100 pt, feitelijk 100 pt | Verlaagd: minimum 20 pt, feitelijk 55.2 pt |
| --- | --- | --- |
| ![Originele tabel met een eerste rij van 70 punten.](row-height-before.png) | ![Tabel na het verhogen van het minimum van de eerste rij naar 100 punten.](row-height-increased.png) | ![Tabel na het verlagen van het minimum van de eerste rij naar 20 punten; tekstomloop houdt de rij hoger dan het minimum.](row-height-decreased.png) |

## **Stel de eerste rij in als koptekst**

Gebruik de [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow)-methode om de eerste rij te markeren voor koptekst‑opmaak. Het uiterlijk hangt af van de tabelformaat die op de tabel is toegepast.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
2. Open de eerste dia.
3. Open de tabel die is opgeslagen als de eerste vorm op de dia.
4. Schakel koptekst‑opmaak in voor de eerste rij.
5. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia. Het schakelt de koptekst‑opmaak in voor de eerste rij en slaat `First_row_header.pptx` op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Een tabelrij of -kolom klonen**

Kloon rijen of kolommen om hun inhoud en opmaak opnieuw te gebruiken. U kunt een kopie aan het einde van de tabel toevoegen of op een specifieke positie invoegen.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
2. Open de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable)-methode.
5. Kloon de vereiste rijen.
6. Kloon de vereiste kolommen.
7. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `Test.pptx` met ten minste één dia. Het maakt een tabel met drie kolommen en vijf rijen, waarbij de afmetingen in punten worden opgegeven. Het voegt kopieën van de eerste rij en kolom toe, en vervolgens worden kopieën van de tweede rij en kolom ingevoegd op index 3 (de vierde positie). De resulterende tabel heeft zeven rijen en vijf kolommen. Het argument `False` schakelt klonen in aangrenzende samengevoegde rijen of kolommen uit; deze tabel bevat geen samengevoegde cellen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
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

Verwijder rijen of kolommen die niet langer nodig zijn in een tabel. Het verwijderen van een element verschuift de indices van de rijen of kolommen die erop volgen.

1. Maak een presentatie met de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
2. Open de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable)-methode.
5. Verwijder de tweede rij en de tweede kolom.
6. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een tabel van drie bij drie en verwijdert de rij en kolom op index 1, waardoor een tabel van twee bij twee overblijft in `TestTable_out.pptx`. De afmetingen zijn in punten. Het argument `False` schakelt het verwijderen van aangrenzende samengevoegde rijen of kolommen uit; deze tabel bevat geen samengevoegde cellen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tekstopmaak instellen op tabelrijniveau**

Pas tekstopmaak toe op een volledige rij om de cellen consistent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
2. Open de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) voor de eerste rij.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) en [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) voor de eerste rij.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) voor de tweede rij.
6. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en minstens twee rijen. Het past 25‑punt tekst, rechts‑uitlijning en een rechtermarge van 20 punt toe op de eerste rij, en stelt vervolgens verticale tekst in voor de tweede rij.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tekstopmaak instellen op tabelkolomniveau**

Pas tekstopmaak toe op een volledige kolom om de cellen consistent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)-klasse.
2. Open de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) voor de eerste kolom.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) en [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) voor de eerste kolom.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) voor de tweede kolom.
6. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en minstens twee kolommen. Het past 25‑punt tekst, rechts‑uitlijning en een rechtermarge van 20 punt toe op de eerste kolom, en stelt vervolgens verticale tekst in voor de tweede kolom.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

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

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tabelstijl‑eigenschappen ophalen**

Gebruik de [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset)-methode om de toegepaste preset van een tabel op te halen en deze op een andere tabel te hergebruiken. Dit identificeert de preset in plaats van individuele celopmaak‑overschrijvingen.

Het voorbeeld maakt een tabel, past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) toe en leest de preset terug. Het drukt de gehelegetalwaarde af die overeenkomt met `DarkStyle1` en slaat de tabel op in `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een tabel die al is aangemaakt?**

Ja. De tabel erft het thema van de dia/lay‑out/master, en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen opnieuw in in die volgorde.

**Kan ik afwisselende (gestreepte) kolommen hebben terwijl ik aangepaste kleuren behoud op specifieke cellen?**

Ja. Schakel afwisselende kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op cel‑niveau heeft voorrang boven de tabelstijl.