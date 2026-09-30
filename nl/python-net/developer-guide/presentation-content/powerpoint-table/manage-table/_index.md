---
title: Beheer presentatie tabellen met Python
linktitle: Beheer Tabel
type: docs
weight: 10
url: /nl/python-net/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel benaderen
- aspectverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via .NET. Ontdek eenvoudige code-voorbeelden om je tabel-werkstromen te stroomlijnen."
---
## **Inleiding**

Tabellen in PowerPoint organiseren informatie in rijen en kolommen, waardoor het makkelijker wordt om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Tabel](https://reference.aspose.com/slides/python-net/aspose.slides/table/) en [Cel](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) klassen en andere types om tabellen in presentaties te maken, bij te werken en te beheren.

## **Maak een tabel vanaf nul**

Maak een tabel door de positie, kolombreedtes en rijhoogtes op te geven. Nadat je hem aan een dia hebt toegevoegd, kun je celranden formatteren, cellen samenvoegen en tekst invoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Definieer een lijst met kolombreedtes in punten.
4. Definieer een lijst met rijhoogtes in punten.
5. Voeg een [Tabel](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object toe aan de dia via de [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) methode.
6. Loop door elke [Cel](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) om de boven-, onder-, rechts- en linkerrand op te maken.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Benader de samengevoegde cel via de [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) eigenschap.
9. Stel de tekst in de samengevoegde cel in.
10. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder maakt een tabel met drie kolommen en vijf rijen op (100, 50) punten. Het past rode randen met een breedte van 5 punten toe, voegt de eerste twee cellen in de eerste rij samen, en slaat het resultaat op als `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummering in een standaardtabel**

In een standaardtabel zijn celindexen nulgebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft index (0, 0). In Python benader je een cel met `table.rows[row_index][column_index]`; de rij‑index staat eerst in deze uitdrukking.

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de 4 × 4 tabel die hierboven is geïllustreerd, met kolombreedtes en rijhoogtes van 70 punten en rode celranden van 5 punten. De coördinaten illustreren celindexen; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een bestaande tabel**

Tabellen worden opgeslagen in de vormverzameling van een dia. Loop door de vormen om een tabel te vinden, en gebruik vervolgens de [Tabel](https://reference.aspose.com/slides/python-net/aspose.slides/table/) klasse om de cellen te lezen of bij te werken.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia die de tabel bevat op basis van de index.
3. Loop door de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) objecten en stop wanneer een tabel wordt gevonden. Als de dia meerdere tabellen bevat, gebruik dan [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) om de gewenste tabel te identificeren.
4. Werk de tekst in de doelcel bij.
5. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel op kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet minstens één dia bevatten, en de eerste tabel op die dia moet minstens één kolom en twee rijen hebben.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Om een rij in een bestaande tabel van grootte te veranderen en te begrijpen waarom de werkelijke hoogte groter kan zijn dan de gevraagde minimumhoogte, zie [Control Row Height](/slides/nl/python-net/manage-rows-and-columns/#control-row-height).

## **Vind de cel die een tekstframe bezit**

Wanneer generieke tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) van een tabel ontvangt, gebruik dan de [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) eigenschap om de bezittende [Cel](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) op te halen. Voor een tabel‑cel‑tekstframe is [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) ingesteld en is [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) `None`, hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen eigenschappen [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) en [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) is ook alleen‑lezen: het biedt navigatie naar de eigenaar maar verandert de eigendom niet. Controleer altijd of de geretourneerde cel `None` is voordat je deze gebruikt.

Voor een compleet voorbeeld dat tabel‑cel‑ en vorm‑eigenaars identificeert, inclusief vormen die zijn gekoppeld aan SmartArt‑knooppunten, zie [Search and Replace Text](/slides/nl/python-net/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

Je kunt de verticale verankering en tekstrichting van individuele tabelcellen regelen. Het voorbeeld in deze sectie centreert de tekst in de eerste cel en roteert deze met 270 graden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Voeg een [Tabel](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object toe aan de dia.
4. Haal een [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) object op uit de tabel.
5. Haal de eerste [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) op en stel de tekst en kleur in.
6. Stel de [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) en [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) van de cel in.
7. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een 4 × 4 tabel met kolombreedtes van 120 punten en rijhoogtes van 100 punten. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de overige cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstopmaak instellen op tabelniveau**

Gebruik [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren opmaak voor delen, alinea’s en tekstframes, zodat je deze eigenschappen kunt instellen zonder door individuele cellen te itereren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Haal een [Tabel](https://reference.aspose.com/slides/python-net/aspose.slides/table/) object op van de dia.
4. Stel de [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) in voor de tekst.
5. Stel de [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) en [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) in.
6. Stel de [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) in.
7. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `table.pptx`, die minstens één dia met een tabel als eerste vorm moet bevatten. Het stelt de lettergrootte in op 25 punten, alinea’s rechts uitgelijnd met een rechter marge van 20 punten, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabelstijl‑eigenschappen ophalen**

Gebruik [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) om de vooraf ingestelde stijl van een tabel te lezen of toe te wijzen. Dit voorbeeld past [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) toe op één tabel, drukt de preset‑naam af, en wijst dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Verhoudingssleutel van een tabel vergrendelen**

De verhoudingssleutel van een tabel is de verhouding tussen breedte en hoogte. Gebruik [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) om deze verhouding voor een tabel te vergrendelen.

Het voorbeeld hieronder opent `pres.pptx`, die minstens één dia met een tabel als eerste vorm moet bevatten. Het drukt de huidige vergrendelingsstatus af, schakelt de verhoudingsvergrendeling in, drukt de bijgewerkte status (`True`) af, en slaat het resultaat op als `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik de leesrichting van rechts‑naar‑links (RTL) voor een hele tabel en de tekst in de cellen inschakelen?**

Ja. De tabel stelt een [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) eigenschap beschikbaar, en alinea’s hebben [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte aanpassen?**

Gebruik [shape locks](/slides/nl/python-net/applying-protection-to-presentation/) om verplaatsen, grootte‑aanpassing, selectie, enz. te uitschakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. Je kunt een [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding bedekt het celgebied volgens de gekozen modus (strekken of betegelen).