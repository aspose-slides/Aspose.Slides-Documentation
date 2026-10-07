---
title: Hantera tabellceller i presentationer med Python
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/python-net/manage-cells/
keywords:
- tabellcell
- slå ihop celler
- ta bort kant
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i Python: identifiera sammanslagna celler, ta bort kanter, dela celler och ange bakgrundsfärger samt bilder med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index. Koordinater i den här artikeln skrivs som `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itererar det genom alla rader och kolumner och använder [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) för att identifiera celler i sammanslagna områden. För varje träff skriver det ut cellkoordinaterna i `row;column`‑ordning, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/) och områdets startkoordinater, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) och [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

## **Ta bort tabellcellramar**

Skapa en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) och lägg till en tabell på dess första bild med [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Kolumnbredder, radhöjder och tabellens position anges i punkter. Exemplet sätter alla fyra cellramar till [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), vilket gör dem osynliga.

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

## **Slå ihop tabellceller**

Använd [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) för att kombinera ett rektangulärt område av tabellceller till en cell. Ange cellerna i det övre vänstra respektive nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får inkludera celler utanför det angivna området; `False` håller sammanslagningen inom det området.

Exemplet skapar en 4×4‑tabell med 70‑punkts kolumner och rader, och slår sedan ihop de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen sträcker sig över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre vänstra position: `table.rows[1][1]` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

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

## **Dela tabellceller**

Att slå ihop celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan införa en ny kolumn i rutnätet och ändra kolumnindex för celler till höger om den. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4×4‑tabell med 70‑punkts kolumner och rader och anropar [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) på cell `(1, 1)`. Hälften av cellens 70‑punkts bredd används för att skapa två celler med lika bredd.

Efter denna delning nås de två halvorna som `table.rows[1][1]` och `table.rows[1][2]`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen fanns i kolumnerna 2 och 3 flyttas till kolumnerna 3 respektive 4. Radräknare förblir oförändrade. Använd dessa uppdaterade kolumnindex när du kommer åt celler efter delningen.

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

### **Dela sammanslagna celler efter rad- eller kolumnspann**

För att förbereda sammanslagna mallceller för datainmatning, använd [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) för att dela längs en befintlig radgräns, eller [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) för att dela längs en kolumngräns.

`index`‑argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Kolumndelning: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med start från den lägre positionen använder det [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) och [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) för att lokalisera ursprunget och kontrollerar båda span. `split_by_row_span` med ett index på 1 separerar sedan raderna 2 och 3 för produktnamn. För en horisontell tvåkolumnssammanslagning, använd `split_by_col_span` med ett index på 1 istället.

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

        # Hämta de resulterande cellerna från tabellen efter delning.
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

Tabellrutnätet och omgivande cellindex förblir oförändrade. Hämta de resulterande cellerna via deras koordinater; här har båda ett spann på 1 och [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) skriver ut `False`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering finns kvar i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering såsom fyllning, ramar och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata "Product A"- och "Product B"-celler med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) för detaljer.

## **Ändra tabellcellens bakgrundsfärg**

Detta exempel skapar en tabell med 150‑punkts kolumner och 50‑punkts rader. Det sätter [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) till solid och [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

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

## **Lägg till en bild i en tabellcell**

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den läser in bilden med [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) och lägger till den i presentationens bildsamling med [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Den tilldelar sedan bilden till bildfyllningen för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) sträcker bilden så att den fyller cellen, vilket kan förändra dess bildförhållande. Kolumnbredder och radhöjder är i punkter. Den inlästa bilden frigörs automatiskt när dess `with`‑block avslutas.

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

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/)‑ramarna har separata egenskaper, så tjockleken och stilen för varje sida kan skilja sig.

**Vad händer med bilden om jag ändrar kolumn-/radstorleken efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Vid stretching justeras bilden till den nya cellen; vid tiling återberäknas plattorna.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/python-net/manage-hyperlinks/) sätts på text‑ (del)‑nivå inuti cellens textruta eller på hela tabellens/formens nivå. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika typsnitt i en enda cell?**

Ja. En cells textruta stöder [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (körningar) med oberoende formatering — typsnittsfamilj, stil, storlek och färg.