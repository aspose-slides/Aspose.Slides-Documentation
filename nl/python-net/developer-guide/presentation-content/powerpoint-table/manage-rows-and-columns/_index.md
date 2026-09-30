---
title: Beheer rijen en kolommen in PowerPoint-tabellen met Python
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/python-net/manage-rows-and-columns/
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
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor Python via .NET en versnel het bewerken van presentaties en data-updates."
---
## **Inleiding**

Aspose.Slides for Python via .NET stelt u in staat om de tabelstructuur en -opmaak in PowerPoint‑presentaties te beheren via de [Tabel](https://reference.aspose.com/slides/python-net/aspose.slides/table/) klasse. U kunt een koprij aanwijzen, rijen en kolommen klonen of verwijderen, en tekstopmaak toepassen op een hele rij of kolom.

Dit artikel legt deze bewerkingen uit met Python‑voorbeelden. Het laat ook zien hoe u een stijl‑preset van een tabel kunt ophalen zodat u deze opnieuw kunt gebruiken. De indices van tabelrijen en -kolommen beginnen bij nul.

## **Rijhoogte regelen**

Gebruik [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) om de minimale hoogte van een rij in punten in te stellen. Het is een ondergrens, geen vaste hoogte. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) geeft de werkelijke hoogte terug en is alleen‑lezen. Toegang tot de rij krijgt u via [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

Het voorbeeld laadt [row-height-input.pptx](row-height-input.pptx), waarin een tabel de eerste vorm op de eerste dia is. De eerste rij begint op 70 punten. De cellen gebruiken 18‑punt Arial‑tekst, tekstomloop en marges van 6 punten boven en onder; de langere tekst in de tweede kolom loopt over meerdere regels. Het voorbeeld verhoogt de minimumwaarde naar 100 punten, verlaagt deze vervolgens naar 20 punten, print de werkelijke hoogte na elke wijziging en slaat beide resultaten op.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Met de meegeleverde presentatie voegt het verhogen van het minimum ruimte toe aan de rij. Het verlagen ervan verwijdert die extra ruimte, maar de werkelijke hoogte blijft groter dan 20 punten omdat de tekst en celmarges meer ruimte nodig hebben. Alleen het verlagen van het minimum kan de rij niet onder de door de inhoud vereiste ruimte dwingen.

Verschillende factoren beïnvloeden de werkelijke hoogte:

- **Tekst en lettergrootte:** langere tekst, expliciete regeleinden of een groter lettertype kunnen meer verticale ruimte vereisen.
- **Omloop en kolombreedte:** met ingeschakelde omloop kan een smallere [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) meer regels opleveren. Een bredere kolom kan de verticale ruimte die nodig is verminderen.
- **Celmarges:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) en [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) voegen verticale ruimte toe. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) en [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) verkleinen de beschikbare breedte voor tekst en kunnen extra omloop veroorzaken.

Voor deze tabel zonder samengevoegde cellen bepaalt de cel die de meeste verticale ruimte nodig heeft de door de inhoud gedreven ondergrens voor de hele rij. Om de rij korter te maken, moet u mogelijk ook de tekst inkorten, de lettergrootte of marges verkleinen, of een kolom breder maken.

De afbeeldingen hieronder tonen dezelfde tabel op dezelfde schaal. In deze run waren de werkelijke hoogtes 70, 100 en 55.2 punten: de laatste rij bleef hoger dan het minimum van 20 punten. Exacte tekstmetingen kunnen variëren afhankelijk van de in uw omgeving beschikbare lettertypen. Download de opgeslagen resultaten: [verhoogd minimum](row-height-increased.pptx) en [verlaagd minimum](row-height-decreased.pptx).

| Origineel: minimum 70 pt, werkelijk 70 pt | Verhoogd: minimum 100 pt, werkelijk 100 pt | Verlaagd: minimum 20 pt, werkelijk 55.2 pt |
| --- | --- | --- |
| ![Originele tabel met een eerste rij van 70 punten.](row-height-before.png) | ![Tabel na het verhogen van het minimum van de eerste rij naar 100 punten.](row-height-increased.png) | ![Tabel na het verlagen van het minimum van de eerste rij naar 20 punten; ingeslagen tekst houdt de rij hoger dan het minimum.](row-height-decreased.png) |

## **Eerste rij instellen als koptekst**

Gebruik de [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) eigenschap om de eerste rij te markeren voor kop­opmaak. Het uiterlijk hangt af van de toegepaste tabelstijl.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Toegang tot de eerste dia.
3. Toegang tot de tabel die als eerste vorm op de dia is opgeslagen.
4. Schakel kop­opmaak in voor de eerste rij.
5. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia. Het schakelt kop­opmaak in voor de eerste rij en slaat `First_row_header.pptx` op.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Rij of kolom van een tabel klonen**

Kloon rijen of kolommen om hun inhoud en opmaak opnieuw te gebruiken. U kunt een kopie aan het einde van de tabel toevoegen of deze op een specifieke positie invoegen.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) methode.
5. Kloon de gewenste rijen.
6. Kloon de gewenste kolommen.
7. Sla de aangepaste presentatie op.

Het voorbeeld vereist `Test.pptx` met ten minste één dia. Het maakt een tabel met drie kolommen en vijf rijen, met afmetingen gespecificeerd in punten. Het voegt kopieën van de eerste rij en kolom toe, en voegt vervolgens kopieën van de tweede rij en kolom in op index 3 (de vierde positie). De resulterende tabel heeft zeven rijen en vijf kolommen. Het argument `False` schakelt klonen in aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rij of kolom uit een tabel verwijderen**

Verwijder rijen of kolommen die niet langer nodig zijn in een tabel. Het verwijderen van een item verschuift de indices van de rijen of kolommen die erop volgen.

1. Maak een presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) methode.
5. Verwijder de tweede rij en tweede kolom.
6. Sla de aangepaste presentatie op.

Dit voorbeeld maakt een drie‑bij‑drie tabel en verwijdert de rij en kolom op index 1, waardoor een twee‑bij‑twee tabel overblijft in `TestTable_out.pptx`. De afmetingen zijn in punten. Het argument `False` schakelt het verwijderen van aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstopmaak op rijniveau instellen**

Pas tekstopmaak toe op een volledige rij om de cellen consequent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Toegang tot de tabel op de eerste dia.
3. Stel [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) in voor de eerste rij.
4. Stel [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) en [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) in voor de eerste rij.
5. Stel [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) in voor de tweede rij.
6. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en ten minste twee rijen. Het past 25‑punt tekst, rechts‑uitlijning en een rechter alinea‑marge van 20 punten toe op de eerste rij, en stelt vervolgens verticale tekst in voor de tweede rij.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstopmaak op kolomniveau instellen**

Pas tekstopmaak toe op een volledige kolom om de cellen consequent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekstrichting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Toegang tot de tabel op de eerste dia.
3. Stel [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) in voor de eerste kolom.
4. Stel [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) en [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) in voor de eerste kolom.
5. Stel [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) in voor de tweede kolom.
6. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en ten minste twee kolommen. Het past 25‑punt tekst, rechts‑uitlijning en een rechter alinea‑marge van 20 punten toe op de eerste kolom, en stelt vervolgens verticale tekst in voor de tweede kolom.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabelstijl‑eigenschappen ophalen**

Gebruik de [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) eigenschap om de op een tabel toegepaste preset op te halen en deze op een andere tabel opnieuw te gebruiken. Dit identificeert de preset in plaats van individuele celopmaak‑overschrijvingen.

Het voorbeeld maakt een tabel, past [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) toe en leest de preset terug. Het print `True` wanneer de opgehaalde preset overeenkomt met de toegepaste preset en slaat de tabel op in `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik PowerPoint‑thema’s/‑stijlen toepassen op een tabel die al is gemaakt?**  
Ja. De tabel erft het thema van de dia/indeling/hoofdpresentatie, en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**  
Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen in die volgorde opnieuw.

**Kan ik gestreepte kolommen hebben en toch aangepaste kleuren op specifieke cellen behouden?**  
Ja. Schakel gestreepte kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; cel‑opmaak heeft voorrang boven de tabelstijl.