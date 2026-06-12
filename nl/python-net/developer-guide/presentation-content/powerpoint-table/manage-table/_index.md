---
title: Beheer presentatietabellen met Python
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/python-net/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel openen
- aspectratio
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET. Ontdek eenvoudige code-voorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie te presenteren. Informatie die is gerangschikt in een raster van cellen (rijen en kolommen) is overzichtelijk en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) klasse, de [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/) klasse en andere gerelateerde types om u te helpen tabellen te maken, bij te werken en te beheren in elke presentatie.

## **Tabellen vanaf nul maken**

Deze sectie toont hoe u een tabel vanaf nul maakt in Aspose.Slides door een tabelvorm aan een dia toe te voegen, de rijen en kolommen te definiëren en exacte afmetingen in te stellen. U ziet ook hoe u cellen met tekst vult, uitlijning en randen aanpast en het uiterlijk van de tabel aanpast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
2. Haal een referentie naar een dia op basis van de index.  
3. Definieer een array met kolombreedtes.  
4. Definieer een array met rijhoogtes.  
5. Voeg een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) toe aan de dia.  
6. Itereer over elke [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/) en formatteer de boven-, onder-, rechts- en linkerranden.  
7. Samenvoegen van de eerste twee cellen in de eerste rij van de tabel.  
8. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) van een [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/).  
9. Voeg tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld toont hoe u een tabel in een presentatie maakt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Open de eerste dia.
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
        
    # Samenvoegen van cellen van (rij 0, kol 0) tot (rij 1, kol 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Voeg tekst toe aan de samengevoegde cel.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Sla de presentatie op naar schijf.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummering in standaardtabellen**

In een standaardtabel is de celnummering eenvoudig en nulgebaseerd. De eerste cel in een tabel heeft de index (0, 0) (kolom 0, rij 0).

Bijvoorbeeld, in een tabel met 4 kolommen en 4 rijen, worden de cellen als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Het volgende Python‑voorbeeld toont hoe u cellen kunt refereren met deze nulgebaseerde nummering:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Een bestaande tabel openen**

Deze sectie legt uit hoe u een bestaande tabel in een presentatie kunt vinden en ermee kunt werken met behulp van Aspose.Slides. U leert hoe u de tabel op een dia vindt, toegang krijgt tot de rijen, kolommen en cellen, en inhoud of opmaak bijwerkt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
2. Haal een referentie naar de dia die de tabel bevat op basis van de index.  
3. Itereer door alle [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/) objecten totdat u de tabel vindt.  
4. Gebruik het [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) object om met de tabel te werken.  
5. Sla de gewijzigde presentatie op.

{{% alert color="info" %}}
Als de dia meerdere tabellen bevat, is het beter om de gewenste tabel te zoeken op basis van de eigenschap `alternative_text`.
{{% /alert %}}

Het volgende Python‑voorbeeld toont hoe u toegang krijgt tot en werkt met een bestaande tabel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantieer de Presentation-klasse om een PPTX-bestand te laden.
with slides.Presentation("sample.pptx") as presentation:
    # Open de eerste dia.
    slide = presentation.slides[0]

    table = None

    # Itereer door de shapes en verwijs naar de eerste gevonden tabel.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Stel de tekst in van de eerste cel in de eerste rij.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Sla de gewijzigde presentatie op naar schijf.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekst uitlijnen in tabellen**

Deze sectie toont hoe u de tekstuitlijning binnen tabelcellen kunt beheersen met Aspose.Slides. U leert horizontale en verticale uitlijning voor cellen in te stellen om uw inhoud duidelijk en consistent te houden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
2. Haal een referentie naar de dia op basis van de index.  
3. Voeg een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) object toe aan de dia.  
4. Toegang tot een [Cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cell/) object uit de tabel.  
5. Lijn de tekst verticaal uit.  
6. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld toont hoe u de tekst in een tabel uitlijnt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    # Open de eerste dia.
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

    # Centreer de tekst en stel verticale oriëntatie in.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Sla de presentatie op naar schijf.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstopmaak op tabelniveau instellen**

Deze sectie toont hoe u tekstopmaak op tabelniveau toepast in Aspose.Slides zodat elke cel een consistente, eenduidige stijl erft. U leert lettergroottes, uitlijningen en marges globaal in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
2. Haal een referentie naar de dia op basis van de index.  
3. Voeg een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) toe aan de dia.  
4. Stel de lettergrootte (fonthoogte) voor de tekst in.  
5. Stel alinea‑uitlijning en marges in.  
6. Stel de verticale tekstoriëntatie in.  
7. Sla de gewijzigde presentatie op.

Het volgende Python‑voorbeeld toont hoe u uw gewenste opmaakopties toepast op tekst in een tabel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Maakt een instantie van de Presentation-klasse
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

## **Ingebouwde tabelstijlen toepassen**

Aspose.Slides stelt u in staat tabellen te formatteren met vooraf gedefinieerde stijlen rechtstreeks in code. Het voorbeeld laat zien hoe u een tabel maakt, een ingebouwde stijl toepast en het resultaat opslaat — een efficiënte manier om consistente, professionele opmaak te garanderen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Aspect‑ratio van tabellen vergrendelen**

De aspect‑ratio van een vorm is de verhouding tussen de afmetingen. Aspose.Slides biedt de eigenschap `aspect_ratio_locked`, waarmee u de aspect‑ratio voor tabellen en andere vormen kunt vergrendelen.

Het volgende Python‑voorbeeld toont hoe u de aspect‑ratio voor een tabel kunt vergrendelen:

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

**Kan ik de rechts‑naar‑links (RTL) leesrichting inschakelen voor een volledige tabel en de tekst in de cellen?**

Ja. De tabel biedt een [right_to_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/right_to_left/) eigenschap, en alinea’s hebben [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/right_to_left/). Door beide te gebruiken wordt de juiste RTL‑volgorde en weergave binnen cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte aanpassen?**

Gebruik [shape locks](/slides/nl/python-net/applying-protection-to-presentation/) om verplaatsen, formaat wijzigen, selectie, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding zal het celgebied bedekken volgens de gekozen modus (uitrekken of tegelen).