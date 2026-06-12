---
title: Beheer tabelcellen in presentaties met Python
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/python-net/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer tabelcellen moeiteloos in PowerPoint en OpenDocument met Aspose.Slides voor Python via .NET. Toegang, wijzigen en opmaken van cellen snel voor naadloze dia-automatisering."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en aan te passen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia krijgt, celopmaak bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Samengevoegde tabelcellen identificeren**

Tabellen bevatten vaak samengevoegde cellen voor kopteksten of om gerelateerde gegevens te groeperen. In deze sectie ziet u hoe u kunt bepalen of een specifieke cel tot een samengevoegd gebied behoort en hoe u de master‑cel (linksboven) kunt refereren, zodat u het volledige blok consistent kunt lezen of opmaken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal de tabel op van de eerste dia.
1. Itereer door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.
1. Druk een bericht af wanneer er samengevoegde cellen worden gevonden.

De volgende Python‑code identificeert samengevoegde tabelcellen in een presentatie:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Aannemende dat de eerste vorm op de eerste dia een tabel is.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Tabelcelranden verwijderen**

Soms voeren tabelranden afleiding af of creëren ze visueel rommel. Deze sectie laat zien hoe u randen van geselecteerde cellen—of van specifieke zijden van een cel—kunt verwijderen, zodat u een nettere lay‑out krijgt en beter aansluit bij het ontwerp van uw dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal de dia op via de index.
1. Definieer een array met kolombreedtes.
1. Definieer een array met rijhoogtes.
1. Voeg een tabel toe aan de dia met de [add_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_table/)‑methode.
1. Itereer door elke cel om de boven‑, onder‑, linker‑ en rechterrand te wissen.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe u randen van tabelcellen kunt verwijderen:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Definieer kolommen met breedtes en rijen met hoogtes.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Voeg een tabelvorm toe aan de dia.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Maak de randvulling van elke cel leeg.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Sla het PPTX-bestand op schijf.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummering in samengevoegde cellen**

Als u twee paren cellen samenvoegt—bijvoorbeeld (1, 1) × (2, 1) en (1, 2) × (2, 2)—behoudt de resulterende tabel dezelfde celnummering als de tabel zonder samenvoegen. De volgende Python‑code demonstreert dit gedrag:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Definieer kolommen met breedtes en rijen met hoogtes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Voeg een tabelvorm toe aan de dia.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Voeg cellen (1,1) en (2,1) samen.
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Voeg cellen (1, 2) en (2, 2) samen.
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Print de celindices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Sla het PPTX-bestand op schijf.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Uitvoer:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Nummering in gesplitste cellen**

In het vorige voorbeeld, toen tabelcellen werden samengevoegd, veranderde de nummering in de andere cellen niet. Deze keer maken we een gewone tabel (zonder samengevoegde cellen) en splitsen we cel (1, 1) om een speciale tabel te creëren. Let op de nummering van deze tabel—die er ongewoon uit kan zien. Dit is echter hoe Microsoft PowerPoint tabelcellen nummert, en Aspose.Slides volgt hetzelfde gedrag.

De volgende Python‑code demonstreert dit gedrag:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Voeg een tabelvorm toe aan de dia.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Splits cel (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Print de celindices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Sla het PPTX-bestand op schijf.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Uitvoer:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Achtergrondkleur van tabelcel wijzigen**

Het volgende Python‑voorbeeld toont hoe u de achtergrondkleur van een tabelcel kunt wijzigen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Maak een nieuwe tabel.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Stel de achtergrondkleur voor een cel in.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen in tabelcellen invoegen**

Deze sectie laat zien hoe u een afbeelding in een tabelcel kunt invoegen in Aspose.Slides. Het behandelt het toepassen van een afbeelding als vulling op de doelcel en het configureren van weergaveopties zoals rekken of tegel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar de dia op via de index.
1. Definieer een array met kolombreedtes.
1. Definieer een array met rijhoogtes.
1. Voeg een tabel toe aan de dia met de [add_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_table/)‑methode.
1. Laad de afbeelding vanuit een bestand.
1. Voeg de afbeelding toe aan de afbeeldingen van de presentatie om een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) te verkrijgen.
1. Stel de [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) van de tabelcel in op `PICTURE`.
1. Pas de afbeelding toe op de tabelcel en kies een vullingsmodus (bijv. `STRETCH`).
1. Sla de presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe u een afbeelding in een tabelcel plaatst bij het maken van een tabel:

```python
import aspose.slides as slides

# Instantieer een Presentation-object.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Voeg een tabelvorm toe aan de dia.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Laad de afbeelding en voeg deze toe aan de presentatie om een PPImage te verkrijgen.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Pas de afbeelding toe op de eerste tabelcel.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Sla de presentatie op schijf.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik verschillende lijndiktes en -stijlen instellen voor de verschillende zijden van één cel?**

Ja. De [boven](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cellformat/border_top/)/[onder](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cellformat/border_bottom/)/[links](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cellformat/border_left/)/[rechts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/cellformat/border_right/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen. Dit volgt logisch uit de per‑zijde randcontrole voor een cel die in het artikel wordt aangetoond.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [vullingsmodus](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillmode/) (stretch/tile). Bij rekken past de afbeelding zich aan de nieuwe cel aan; bij tegels worden de tegels opnieuw berekend. Het artikel vermeldt de weergavemodi van een afbeelding in een cel.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/python-net/manage-hyperlinks/) worden ingesteld op tekst‑ (gedeelte) niveau binnen het tekstvak van de cel of op het niveau van de gehele tabel/vorm. In de praktijk kent u de link toe aan een gedeelte of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel instellen?**

Ja. Het tekstvak van een cel ondersteunt [portions](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertypefamilie, stijl, grootte en kleur.