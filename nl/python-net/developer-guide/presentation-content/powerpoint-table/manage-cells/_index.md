---
title: Beheer tabelcellen in presentaties met Python
linktitle: Cellen beheren
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
description: "Beheer PowerPoint-tabelcellen in Python: identificeer samengevoegde cellen, verwijder randen, splits cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen, en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden tonen hoe u een presentatie kunt maken of openen, een tabel van een dia kunt ophalen, de opmaak van een cel kunt bijwerken via cel‑eigenschappen, en de gewijzigde presentatie kunt opslaan als een PPTX‑bestand.

Aspose.Slides gebruikt nul‑gebaseerde indexen. Coördinaten in dit artikel worden geschreven als `(column, row)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens doorloopt het alle rijen en kolommen en gebruikt [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) om cellen in samengevoegde gebieden te identificeren. Voor elke overeenkomst drukt het de celcoördinaten af in `row;column`‑volgorde, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), en de startcoördinaten van het gebied, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) en [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

Maak een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) en voeg een tabel toe aan de eerste dia met [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Kolombreedtes, rijhoogtes en de tabelpositie worden gespecificeerd in points. Het voorbeeld stelt alle vier de celranden in op [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

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

## **Tabelcellen samenvoegen**

Gebruik [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Specificeer de cellen in de linkerboven‑ en rechteronderhoek van het bereik. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `False` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 points, en voegt vervolgens de vier centrale cellen van `(1, 1)` tot `(2, 2)` samen. De resulterende cel bestrijkt twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruikt u de linkerboven‑positie: `table.rows[1][1]` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik ongewijzigd blijven.

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

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van cellen rechts van die cel wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 points en roept [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) aan op cel `(1, 1)`. De helft van de 70 points brede cel wordt doorgegeven om twee even‑brede cellen te maken.

Na deze splitsing worden de twee helften benaderd als `table.rows[1][1]` en `table.rows[1][2]`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verschuiven naar kolommen 3 en 4. Rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

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

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevenspopulatie voor te bereiden, gebruikt u [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) om langs een bestaande rijscheiding te splitsen, of [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) om langs een kolomscheiding te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linkerdeel van de splitsing; het is relatief ten opzichte van het samengevoegde gebied:

- Row split: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Column split: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Het voorbeeld gaat ervan uit dat een presentatie een tabel bevat als de eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Vanuit de lagere positie gebruikt het [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) en [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) om de oorsprong te vinden en controleert beide spans. `split_by_row_span` met een index van 1 scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale twee‑kolomsamenvoeging gebruikt u `split_by_col_span` met een index van 1.

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

        # Haal de resulterende cellen uit de tabel op na het splitsen.
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

Het tabelraster en de omringende cel­indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) geeft `False` weer. Grotere gebieden kunnen na één splitsing gedeeltelijk samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven behouden in de bovenste (of linker) cel; de nieuwe cel is leeg maar erft celopmaak zoals vulling, randen en marges. Populate de cellen na het splitsen en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat afzonderlijke “Product A”‑ en “Product B”‑cellen waarbij de opmaak van het sjabloon behouden blijft. Zie de [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) voor details.

## **Achtergrondkleur van de tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 points en rijen van 50 points. Het stelt [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) in op solid en [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Een afbeelding in een tabelcel toevoegen**

Plaats de invoerafbeelding in de werkmap voordat u dit voorbeeld uitvoert. De afbeelding wordt geladen met [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) en toegevoegd aan de afbeeldingencollectie van de presentatie met [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Vervolgens wordt de afbeelding toegewezen aan de picture‑fill van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) strekt de afbeelding uit om de cel te vullen, wat de beeldverhouding kan wijzigen. Kolombreedtes en rijhoogtes worden in points opgegeven. De geladen afbeelding wordt automatisch vrijgegeven wanneer het `with`‑blok eindigt.

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

**Kan ik verschillende lijndiktes en -stijlen instellen voor de verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kunnen verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rij‑grootte aanpas nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Bij stretching past de afbeelding zich aan de nieuwe cel aan; bij tiling worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/python-net/manage-hyperlinks/) worden ingesteld op tekstaanduidings‑ (portion) niveau binnen het tekstframe van de cel of op niveau van de gehele tabel/vorm. In de praktijk wijst u de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen instellen binnen één cel?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) met onafhankelijke opmaak – lettertype, stijl, grootte en kleur.