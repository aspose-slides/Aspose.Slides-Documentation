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
- presentatie
- Python
- Aspose.Slides
description: "Beheer PowerPoint-tabelcellen in Python: identificeer samengevoegde cellen, verwijder randen, split cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides stelt je in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe je samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe je een presentatie maakt of opent, een tabel van een dia haalt, celopmaak bijwerkt via cel‑eigenschappen en de gewijzigde presentatie opslaat als PPTX‑bestand.

Aspose.Slides gebruikt nulgebaseerde indexen. Coördinaten in dit artikel worden geschreven als `(kolom, rij)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en de vorm bestaan en dat de vorm een tabel is. Vervolgens doorloopt het alle rijen en kolommen en gebruikt [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) om cellen in samengevoegde gebieden te identificeren. Voor elke vondst wordt de celcoördinaat in de volgorde `rij;kolom` afgedrukt, samen met [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), en de startcoördinaten van het gebied, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) en [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Tabelcelranden verwijderen**

Maak een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en voeg een tabel toe aan de eerste dia met [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Kolombreedtes, rijhoogtes en de positie van de tabel worden gespecificeerd in punten. Het voorbeeld stelt alle vier de celranden in op [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagonale celranden toevoegen**

Gebruik [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) om een lijn van de linkerbovenhoek naar de rechteronderhoek te tekenen, en [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) om een lijn van de linkeronderhoek naar de rechterbovenhoek te tekenen. Een diagonale lijn kan een koptekst‑hoekaanduiding zijn; beide diagonalen kunnen een X vormen om een cel als niet‑toepasselijk te markeren.

Elke diagonale is een [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). In de [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) stel je [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) in op [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) en kies je een [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Stel de [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) van de lijn in punten in.

Het voorbeeld maakt drie cellen in één rij: een rode neerwaartse diagonale, een blauwe opwaartse diagonale en beide diagonalen. De boven‑, onder‑, linker‑ en rechtercelranden blijven ongewijzigd.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Een diagonale is een opmaak‑eigenschap, geen cel­split. Elke cel behoudt één [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); de gebieden aan beide kanten van een diagonale kunnen niet onafhankelijk worden bewerkt.

De opgeslagen tabel, weergegeven in Microsoft PowerPoint:

![Drie tabelcellen die een rode diagonale tonen van links‑boven naar rechts‑onder, een blauwe diagonale van links‑onder naar rechts‑boven, en beide diagonalen die een X vormen.](diagonal-cell-borders.png)

*Van links naar rechts: neerwaartse diagonale (rood, 3 pt), opwaartse diagonale (blauw, 5 pt) en beide diagonalen.*

## **Tabelcellen samenvoegen**

Gebruik [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Geef de cellen op in de linkerboven‑ en rechteronderhoek van het bereik. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `False` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4‑tabel met kolommen en rijen van 70 pt, en voegt vervolgens de vier centrale cellen van `(1, 1)` tot en met `(2, 2)` samen. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruik je de linkerboven‑positie: `table.rows[1][1]` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik niet wijzigen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabelcellen splitsen**

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolom‑indexen van de cellen rechts daarvan wijzigen. Aspose.Slides volgt het tabelraster‑model van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4‑tabel met kolommen en rijen van 70 pt en roept [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) aan op cel `(1, 1)`. De helft van de 70‑pt breedte van de cel wordt doorgegeven om twee cellen van gelijke breedte te creëren.

Na deze splitsing worden de twee helften benaderd als `table.rows[1][1]` en `table.rows[1][2]`. Het tabelraster bevat nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verplaatsen zich naar kolommen 3 en 4. Rij‑indexen blijven gelijk. Gebruik deze bijgewerkte kolom‑indexen bij het benaderen van cellen na de splitsing.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

<!-- visual-explanation:manage-cells:start -->
[![Een ongesplitste 70‑pt cel splitst in twee 35‑pt cellen, waardoor een vijfde rasterkolom ontstaat en de indexen rechts ervan verschuiven.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*De breedtesplitsing heeft invloed op cel (1, 1), gebruikmakend van nulgebaseerde (kolom, rij)‑indexen. Andere rijen behouden een cel die beide nieuwe kolomposities beslaat.*
<!-- visual-explanation:manage-cells:end -->

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen klaar te maken voor gegevensvulling, gebruik je [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) om langs een bestaande rij‑grens te splitsen, of [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) om langs een kolom‑grens te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linkerdeel van de splitsing; het is relatief ten opzichte van het samengevoegde gebied:

- Rijsplitsing: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Kolomsplitsing: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Het voorbeeld gaat uit van een presentatie met een tabel als eerste vorm op de eerste dia, waarbij `(1, 2)` en `(1, 3)` verticaal samengevoegd zijn. Beginnend vanaf de onderste positie, gebruikt het [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) en [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) om de oorsprong te vinden en controleert beide spans. `split_by_row_span` met een index van 1 scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale twee‑kolomsamenvoeging gebruik je `split_by_col_span` met een index van 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Haal de resulterende cellen op uit de tabel na het splitsen.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Het tabelraster en de omliggende cel‑indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; beide hebben spans van 1 en [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) geeft `False` weer. Grotere gebieden kunnen na één splitsing deels samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven behouden in de boven‑ (of linker‑)cel; de nieuwe cel is leeg maar erft celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen en stel eventuele tekst‑opmaak expliciet in.

De opgeslagen presentatie bevat aparte “Product A”‑ en “Product B”‑cellen waarbij de sjablooncelformatting behouden blijft. Zie de [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) voor details.

### **Een cel splitsen op een specifieke hoogte**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) neemt de hoogte van het bovenste deel in punten. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) neemt het aantal bestaande rasterrijen in het bovenste deel. Om een 40‑pt cel verticaal te centreren in de rechterkolom, trek je 40 af van de werkelijke hoogte van de cel en verdeel je de resterende ruimte gelijk boven en onder.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

De eerste splitsing voegt een rasterrij toe, waardoor de onderste 90 pt in `table.rows[1][1]` achterblijven. De tweede splitsing verdeelt die cel in een midden‑cel van 40 pt en een onder‑cel van 50 pt. De drie cellen in de rechterkolom zijn nu 50, 40 en 50 pt hoog van boven naar beneden. De linker‑cel beslaat alle drie de rijen met de oorspronkelijke hoogte van 140 pt.

![De linker‑cel beslaat de volledige tabelhoogte naast drie cellen met “Middle” in het midden.](split-by-height.png)

## **De achtergrondkleur van de tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 pt en rijen van 50 pt. Het stelt [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) in op solid en [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Een afbeelding in een tabelcel toevoegen**

Plaats de invoer‑afbeelding in de werkmap voordat je dit voorbeeld uitvoert. De afbeelding wordt geladen met [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) en toegevoegd aan de afbeeldingsverzameling van de presentatie met [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Vervolgens wordt de afbeelding toegewezen aan de picture‑fill van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) rekt de afbeelding uit zodat ze de cel vult, wat de beeldverhouding kan veranderen. Kolombreedtes en rijhoogtes staan in punten. De geladen afbeelding wordt automatisch verwijderd wanneer het `with`‑blok eindigt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kunnen verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rij‑grootte wijzig nadat ik een picture als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Bij stretching past de afbeelding zich aan de nieuwe cel aan; bij tiling worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan de volledige inhoud van een cel?**

[Hyperlinks](/slides/nl/python-net/manage-hyperlinks/) worden ingesteld op tekst‑ (portion‑) niveau binnen het tekstframe van de cel of op niveau van de gehele tabel/vorm. In de praktijk ken je de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen instellen binnen één cel?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) met onafhankelijke opmaak – lettertype, stijl, grootte en kleur.