---
title: Beheer presentatietabellen met Python
linktitle: Beheer tabel
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
description: "Maak & bewerk tabellen in PowerPoint- en OpenDocument‑slides met Aspose.Slides voor Python via .NET. Ontdek eenvoudige codevoorbeelden om je tabelwerkstromen te stroomlijnen."
---
## **Introductie**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven. Informatie die is gerangschikt in een raster van cellen (rijen en kolommen) is eenvoudig en makkelijk te begrijpen.

Aspose.Slides levert de [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/)‑klasse, de [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/)‑klasse en andere gerelateerde types om tabellen in elke presentatie te maken, bij te werken en te beheren.

## **Tabellen van Grund af creëren**

Dit gedeelte laat zien hoe je een tabel vanaf nul maakt in Aspose.Slides door een tabelvorm aan een dia toe te voegen, rijen en kolommen te definiëren en precieze afmetingen in te stellen. Je ziet ook hoe je cellen vult met tekst, uitlijning en randen aanpast en het uiterlijk van de tabel aanpast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Definieer een array met kolombreedtes.
4. Definieer een array met rijhoogtes.
5. Voeg een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) toe aan de dia.
6. Loop over elke [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/) en formatteer de boven‑, onder‑, rechter‑ en linkerranden.
7. Voeg de cellen van de eerste twee rijen en de eerste twee kolommen samen tot één cel.
8. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van een [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/).
9. Voeg tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).
10. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld laat zien hoe je een tabel in een presentatie creëert:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand representeert.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Voeg een tabelvorm toe aan de dia.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Stel het randformaat in voor elke cel.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Voeg cellen samen van (rij 0, kolom 0) tot (rij 1, kolom 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Voeg tekst toe aan de samengevoegde cel.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Sla de presentatie op naar schijf.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummering in Standaardtabel­len**

In een standaardtabel is de celnummering eenvoudig en nul‑gebaseerd. De eerste cel in een tabel heeft de index (0, 0) (kolom 0, rij 0).

Bijvoorbeeld, in een tabel met 4 kolommen en 4 rijen worden de cellen als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Het volgende Python‑voorbeeld toont hoe je cellen kunt refereren met deze nul‑gebaseerde nummering:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Voeg een tabel toe met 4 kolommen en 4 rijen.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een Bestaande Tabel**

Dit gedeelte legt uit hoe je een bestaande tabel in een presentatie kunt lokaliseren en bewerken met Aspose.Slides. Je leert hoe je de tabel op een dia vindt, toegang krijgt tot rijen, kolommen en cellen, en de inhoud of opmaak bijwerkt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een referentie op naar de dia die de tabel bevat op basis van de index.
3. Loop door alle [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑objecten totdat je de tabel vindt.
4. Gebruik het [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/)‑object om met de tabel te werken.
5. Sla de gewijzigde presentatie op.

{{% alert color="info" title="Note" %}}

Als de dia meerdere tabellen bevat, is het beter om te zoeken naar de tabel die je nodig hebt via de eigenschap `alternative_text`.

{{% /alert %}}

Het volgende Python‑voorbeeld laat zien hoe je een bestaande tabel benadert en bewerkt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantieren van de Presentation-klasse om een PPTX-bestand te laden.
with slides.Presentation("sample.pptx") as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    table = None

    # Doorloop de shapes en verwijs naar de eerste gevonden tabel.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Stel de tekst van de eerste cel in de eerste rij in.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Sla de gewijzigde presentatie op naar schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoek de Cel die een Tekstframe Bezit**

Wanneer generieke tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) uit een tabel ontvangt, gebruik je de eigenschap [TextFrame.parent_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_cell/) om de eigende [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/) op te halen. Voor een tabelcel‑tekstframe is [TextFrame.parent_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_cell/) gezet en is [TextFrame.parent_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_shape/) `None`, ook al is de tabel zelf een vorm.

De celcoördinaten zijn beschikbaar via de alleen‑lezen eigenschappen [Cell.first_column_index](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/first_column_index/) en [Cell.first_row_index](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_cell/) is eveneens alleen‑lezen: het biedt navigatie naar de eigenaar maar verandert de eigenaar niet. Controleer altijd of de geretourneerde cel niet `None` is voordat je deze gebruikt.

Voor een volledig voorbeeld dat tabel‑cel‑ en vorm‑eigenaren identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knopen, zie [Search and Replace Text](/slides/nl/python-net/search-and-replace-text/).

## **Tekst uitlijnen in Tabellen**

Dit gedeelte toont hoe je de plaatsing van tekst binnen tabelcellen kunt regelen met Aspose.Slides. Je leert de tekst verticaal in een cel te verankeren en de richting waarin de tekst loopt te wijzigen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een referentie op naar de dia op basis van de index.
3. Voeg een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/)‑object toe aan de dia.
4. Verkrijg een [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/)‑object uit de tabel.
5. Centreer de tekst verticaal in de cel en stel de tekstrichting in.
6. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld toont hoe je de tekst in een tabel uitlijnt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Voeg een tabelvorm toe aan de dia.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Centreer de tekst en stel de verticale oriëntatie in.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Sla de presentatie op naar schijf.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstopmaak Instellen op Tabelniveau**

Dit gedeelte laat zien hoe je tekstopmaak op tabelniveau toepast in Aspose.Slides zodat elke cel een consistente, uniforme stijl erft. Je leert lettergroottes, uitlijningen en marges globaal in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een referentie op naar de dia op basis van de index.
3. Voeg een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) toe aan de dia.
4. Stel de lettergrootte (font height) voor de tekst in.
5. Stel alinea‑uitlijning en marges in.
6. Stel de verticale tekstoriëntatie in.
7. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld laat zien hoe je je gewenste opmaakopties toepast op tekst in een tabel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creëert een instantie van de Presentation-klasse
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Stel de lettergrootte in voor alle tabelcellen.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Stel rechts uitgelijnde tekst en een rechtermarge in voor alle tabelcellen.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Stel de verticale tekstoriëntatie in voor alle tabelcellen.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ingebouwde Tabelstijlen Toepassen**

Aspose.Slides maakt het mogelijk tabellen te formatteren met vooraf gedefinieerde stijlen direct in de code. Het voorbeeld demonstreert het maken van een tabel, het toepassen van een ingebouwde stijl en het opslaan van het resultaat – een efficiënte manier om consistente, professionele opmaak te garanderen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Verhouding van Tabellen vergrendelen**

De beeldverhouding van een vorm is de verhouding tussen de afmetingen. Aspose.Slides biedt de eigenschap `aspect_ratio_locked`, waarmee je de beeldverhouding voor tabellen en andere vormen kunt vergrendelen.

Het volgende Python‑voorbeeld laat zien hoe je de beeldverhouding van een tabel vergrendelt:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik de leesrichting van rechts‑naar‑links (RTL) voor een gehele tabel en de tekst in de cellen inschakelen?**

Ja. De tabel exposeert een eigenschap [right_to_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/right_to_left/), en alinea’s hebben [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/right_to_left/). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel in het eindbestand verplaatsen of de grootte aanpassen?**

Gebruik [shape locks](/slides/nl/python-net/applying-protection-to-presentation/) om verplaatsen, schalen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. Je kunt een [picture fill](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding bedekt het celgebied volgens de gekozen modus (stretch of tile).