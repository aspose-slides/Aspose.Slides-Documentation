---
title: "Hantera tabellceller i presentationer med Python"
linktitle: "Hantera celler"
type: docs
weight: 30
url: /sv/python-net/manage-cells/
keywords:
- tabellcell
- sammanfoga celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera tabellceller i PowerPoint och OpenDocument med Aspose.Slides för Python via .NET på ett enkelt sätt. Behärska åtkomst, ändring och formatering av celler snabbt för sömlös bildautomatisering."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering via cellegenskaper och sparar den ändrade presentationen som en PPTX-fil.

## **Identifiera sammanslagna tabellceller**

Tabeller innehåller ofta sammanslagna celler för rubriker eller för att gruppera relaterad data. I det här avsnittet ser du hur du avgör om en specifik cell tillhör ett sammanslaget område och hur du refererar till huvudcellen (övre vänstra) så att du kan läsa eller formatera hela blocket konsekvent.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Hämta tabellen från den första bilden.
1. Iterera genom tabellens rader och kolumner för att hitta sammanslagna celler.
1. Skriv ut ett meddelande när sammanslagna celler hittas.

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Antag att den första formen på den första bilden är en tabell.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Ta bort tabellcellramar**

Ibland stör tabellramar innehållet eller skapar visuellt brus. Detta avsnitt visar hur du tar bort ramar från valda celler – eller specifika sidor av en cell – så att du kan uppnå en renare layout och bättre anpassa dig till bildens design.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Hämta bilden efter dess index.
1. Definiera en array med kolumnbredder.
1. Definiera en array med radhöjder.
1. Lägg till en tabell på bilden med metoden [add_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_table/) .
1. Iterera genom varje cell för att rensa de övre, nedre, vänstra och högra ramarna.
1. Spara den ändrade presentationen som en PPTX-fil.

```python
import aspose.slides as slides

# Instansiera Presentation‑klassen som representerar en PPTX‑fil.
with slides.Presentation() as presentation:
    # Åtkomst till den första bilden.
    slide = presentation.slides[0]

    # Definiera kolumner med bredder och rader med höjder.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Lägg till en tabellform på bilden.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Rensa kantfyllningen för varje cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Spara PPTX‑filen till disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numrering i sammanslagna celler**

Om du sammanslår två par celler – till exempel (1, 1) × (2, 1) och (1, 2) × (2, 2) – behåller den resulterande tabellen samma cellnumrering som tabellen utan sammanslagning. Följande Python‑kod demonstrerar detta beteende:

```python
import aspose.slides as slides

# Instansiera Presentation‑klassen som representerar en PPTX‑fil.
with slides.Presentation() as presentation:
    # Åtkomst till den första bilden.
    slide = presentation.slides[0]

    # Definiera kolumner med bredder och rader med höjder.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Lägg till en tabellform på bilden.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Slå samman cellerna (1,1) och (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Slå samman cellerna (1, 2) och (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Skriv ut cellindexen.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Spara PPTX‑filen till disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Numrering i delade celler**

I föregående exempel, när tabellcellerna var sammanslagna, förändrades inte numreringen i de andra cellerna. Denna gång skapar vi en vanlig tabell (utan sammanslagna celler) och delar sedan cell (1, 1) för att producera en speciell tabell. Lägg märke till tabellens numrering – den kan se ovanlig ut. Detta är dock hur Microsoft PowerPoint numrerar tabellceller, och Aspose.Slides följer samma beteende.

Följande Python‑kod demonstrerar detta beteende:

```python
import aspose.slides as slides

# Instansiera Presentation‑klassen som representerar en PPTX‑fil.
with slides.Presentation() as presentation:
    # Åtkomst till den första bilden.
    slide = presentation.slides[0]

    # Definiera kolumnbredder och radhöjder.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Lägg till en tabellform på bilden.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Dela cell (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Skriv ut cellindexen.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Spara PPTX‑filen till disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Output:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Ändra bakgrundsfärg för tabellcell**

Följande Python‑exempel visar hur du ändrar en tabellcells bakgrundsfärg:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Skapa en ny tabell.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Ställ in bakgrundsfärgen för en cell.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Infoga bilder i tabellceller**

Detta avsnitt visar hur du infogar en bild i en tabellcell i Aspose.Slides. Det täcker att applicera en bildfyllning på målcell och att konfigurera visningsalternativ såsom streckning eller mosaik.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Hämta en bildreferens efter dess index.
1. Definiera en array med kolumnbredder.
1. Definiera en array med radhöjder.
1. Lägg till en tabell på bilden med metoden [add_table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/add_table/) .
1. Läs in bilden från en fil.
1. Lägg till bilden i presentationens bilder för att få en [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) .
1. Ställ in tabellcellens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `PICTURE`.
1. Applicera bilden på tabellcellen och välj en fyllningsmetod (t.ex. `STRETCH`).
1. Spara presentationen som en PPTX-fil.

```python
import aspose.slides as slides

# Instansiera ett Presentation‑objekt.
with slides.Presentation() as presentation:
    # Åtkomst till den första bilden.
    slide = presentation.slides[0]

    # Definiera kolumnbredder och radhöjder.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Lägg till en tabellform på bilden.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Läs in bilden och lägg till den i presentationen för att få ett PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Applicera bilden på den första tabellcellen.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Spara presentationen till disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag ange olika linjetjocklekar och -stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cellformat/border_right/)‑ramarna har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig åt. Detta följer logiskt av per‑sida‑ramkontrollen för en cell som demonstreras i artikeln.

**Vad händer med bilden om jag ändrar kolumn‑/radstorleken efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillmode/) (stretch/tile). Vid streckning anpassas bilden till den nya cellen; vid mosaik beräknas rutorna om. Artikeln nämner bildvisningslägena i en cell.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/python-net/manage-hyperlinks/) sätts på text‑ (portion)‑nivå inuti cellens textruta eller på hela tabellens/figurens nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag använda olika teckensnitt inom en enda cell?**

Ja. En cells textruta stöder [portions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) (körningar) med oberoende formatering – teckensnitt, stil, storlek och färg.