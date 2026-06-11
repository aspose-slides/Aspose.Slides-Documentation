---
title: Hantera presentationstabeller med Python
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/python-net/manage-table/
keywords:
- lägga till tabell
- skapa tabell
- åtkomst till tabell
- aspektförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Upptäck enkla kodexempel för att förenkla dina tabellarbetsflöden."
---
## **Introduktion**

En tabell i PowerPoint är ett effektivt sätt att presentera information. Information organiserad i ett rutnät av celler (rader och kolumner) är enkel och lätt att förstå.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/), klassen [Cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/) och andra relaterade typer för att hjälpa dig att skapa, uppdatera och hantera tabeller i vilken presentation som helst.

## **Skapa tabeller från grunden**

Detta avsnitt visar hur du skapar en tabell från grunden i Aspose.Slides genom att lägga till en tabellform på en bild, definiera dess rader och kolumner samt ange exakta storlekar. Du får också se hur du fyller celler med text, justerar justering och kantlinjer samt anpassar tabellens utseende.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till en bild med dess index.
3. Definiera en matris med kolumnbredder.
4. Definiera en matris med radhöjder.
5. Lägg till en [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/) på bilden.
6. Iterera över varje [Cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/) och formatera dess övre, nedre, högra och vänstra kantlinjer.
7. Sammanfoga de två första cellerna i tabellens första rad.
8. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) för en [Cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/).
9. Lägg till text i [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
10. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du skapar en tabell i en presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:
    # Få åtkomst till den första bilden.
    slide = presentation.slides[0]

    # Definiera kolumnbredder och radhöjder.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Lägg till en tabellform på bilden.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Ange kantformat för varje cell.
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
        
    # Sammanfoga celler från (rad 0, kol 0) till (rad 1, kol 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Lägg till text i den sammanslagna cellen.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Spara presentationen till disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numrering i standardtabeller**

I en standardtabell är cellnumrering enkel och nollbaserad. Den första cellen i en tabell indexeras som (0, 0) (kolumn 0, rad 0).

Till exempel, i en tabell med 4 kolumner och 4 rader, numreras cellerna enligt följande:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Följande Python‑exempel visar hur du refererar till celler med denna nollbaserade numrering:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Åtkomst till en befintlig tabell**

Detta avsnitt förklarar hur du hittar och arbetar med en befintlig tabell i en presentation med hjälp av Aspose.Slides. Du lär dig hur du hittar tabellen på en bild, får åtkomst till dess rader, kolumner och celler samt uppdaterar innehåll eller formatering.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen med dess index.
3. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) objekt tills du hittar tabellen.
4. Använd [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/) objektet för att arbeta med tabellen.
5. Spara den modifierade presentationen.

{{% alert color="info" %}}
Om bilden innehåller flera tabeller är det bättre att söka efter den tabell du behöver via dess `alternative_text`-egenskap.
{{% /alert %}}

Följande Python‑exempel visar hur du får åtkomst till och arbetar med en befintlig tabell:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Skapa en instans av Presentation-klassen för att läsa in en PPTX-fil.
with slides.Presentation("sample.pptx") as presentation:
    # Få åtkomst till den första bilden.
    slide = presentation.slides[0]

    table = None

    # Iterera genom formerna och referera till den första hittade tabellen.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Ange texten för den första cellen i den första raden.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Spara den modifierade presentationen till disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Justera text i tabeller**

Detta avsnitt visar hur du styr textjustering inne i tabellceller med Aspose.Slides. Du lär dig att ställa in horisontell och vertikal justering för celler för att hålla ditt innehåll tydligt och konsekvent.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Lägg till en [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/) på bilden.
4. Få åtkomst till ett [Cell](https://reference.aspose.com/slides/sv/python-net/aspose.slides/cell/)‑objekt från tabellen.
5. Justera texten vertikalt.
6. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du justerar texten i en tabell:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Definiera kolumnbredder och radhöjder.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Lägg till en tabellform på bilden.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Centrera texten och ställ in vertikal orientering.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Spara presentationen till disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in textformatering på tabellnivå**

Detta avsnitt visar hur du applicerar textformatering på tabellnivå i Aspose.Slides så att varje cell ärver en konsekvent, enhetlig stil. Du lär dig att ställa in teckenstorlekar, justeringar och marginaler globalt.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Lägg till en [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/) på bilden.
4. Ställ in teckenstorleken (teckenhöjd) för texten.
5. Ställ in styckejustering och marginaler.
6. Ställ in vertikal textorientering.
7. Spara den modifierade presentationen.

Följande Python‑exempel visar hur du tillämpar dina föredragna formateringsalternativ på text i en tabell:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Skapar en instans av Presentation-klassen
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Ange teckenstorlek för alla tabellceller.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Ställ in högerjusterad text och en högermarginal för alla tabellceller.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Ställ in vertikal textorientering för alla tabellceller.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Använd inbyggda tabellstilar**

Aspose.Slides låter dig formatera tabeller med fördefinierade stilar direkt i kod. Exemplet demonstrerar hur man skapar en tabell, tillämpar en inbyggd stil och sparar resultatet – ett effektivt sätt att säkerställa konsekvent, professionell formatering.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Lås bildförhållandet för tabeller**

Bildförhållandet för en form är förhållandet mellan dess dimensioner. Aspose.Slides tillhandahåller egenskapen `aspect_ratio_locked`, som gör att du kan låsa bildförhållandet för tabeller och andra former.

Följande Python‑exempel visar hur du låser bildförhållandet för en tabell:

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

**Kan jag aktivera läsriktning från höger till vänster (RTL) för en hel tabell och texten i dess celler?**

Ja. Tabellen har en [right_to_left](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/right_to_left/) egenskap, och stycken har [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/right_to_left/). Genom att använda båda säkerställs korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutgiltiga filen?**

Använd [shape locks](/slides/sv/python-net/applying-protection-to-presentation/) för att inaktivera flytt, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt valt läge (stretch eller tile).