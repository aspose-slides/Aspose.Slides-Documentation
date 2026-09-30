---
title: Hantera presentationstabeller med Python
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/python-net/manage-table/
keywords:
- lägg till tabell
- skapa tabell
- åtkomst till tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Upptäck enkla kodexempel för att effektivisera dina tabellarbetsflöden."
---
## **Introduktion**

Tabeller i PowerPoint organiserar information i rader och kolumner, vilket gör det enklare att läsa och jämföra värden.

Aspose.Slides tillhandahåller klasserna [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) och [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) samt andra typer för att låta dig skapa, uppdatera och hantera tabeller i presentationer.

## **Skapa en tabell från början**

Skapa en tabell genom att ange dess position, kolumnbredder och radhöjder. Efter att ha lagt till den på en bild kan du formatera cellkanter, slå samman celler och infoga text.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Definiera en lista med kolumnbredder i punkter.
4. Definiera en lista med radhöjder i punkter.
5. Lägg till ett [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑objekt på bilden via metoden [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Iterera genom varje [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) för att applicera formatering på övre, nedre, högra och vänstra kanterna.
7. Slå samman de två första cellerna i tabellens första rad.
8. Kom åt den sammanslagna cellen via dess [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/)‑egenskap.
9. Ställ in texten i den sammanslagna cellen.
10. Spara den modifierade presentationen.

Exemplet nedan skapar en tabell med tre kolumner och fem rader på (100, 50) punkter. Det applicerar röda kanter med en bredd på 5 punkter, slår samman de två första cellerna i den första raden och sparar resultatet som `table.pptx`.

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

## **Numrering i en standardtabell**

I en standardtabell är cellindex nollbaserade och använder ordningen (kolumn, rad). Den första cellen har index (0, 0). I Python får du åtkomst till en cell med `table.rows[row_index][column_index]`; radindexet kommer först i detta uttryck.

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Detta exempel skapar den 4 × 4‑tabell som illustrerats ovan, med kolumnbredder och radhöjder på 70 punkter samt röda cellkanter med en bredd på 5 punkter. Koordinaterna illustrerar cellindex; exemplet lämnar cellerna tomma och sparar tabellen som `StandardTables_out.pptx`.

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

## **Åtkomst till en befintlig tabell**

Tabeller lagras i en bilds form-collection. Iterera genom formerna för att hitta en tabell och använd sedan klassen [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) för att läsa eller uppdatera dess celler.

1. Läs in presentationen med hjälp av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen via dess index.
3. Iterera genom objekten [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) och stoppa när en tabell hittas. Om bilden innehåller flera tabeller, använd [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) för att identifiera den du behöver.
4. Uppdatera texten i målcellens.
5. Spara den modifierade presentationen.

Exemplet nedan öppnar `UpdateExistingTable.pptx` och hittar den första tabellen på den första bilden. Det sätter cellen i kolumn 0, rad 1 till `New` och sparar resultatet som `table1_out.pptx`. Inmatningen måste innehålla minst en bild, och den första tabellen på den bilden måste ha minst en kolumn och två rader.

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

För att ändra storlek på en rad i en befintlig tabell och förstå varför dess faktiska höjd kan överstiga det begärda minimumet, se [Kontrollera radhöjd](/slides/sv/python-net/manage-rows-and-columns/#control-row-height).

## **Hitta cellen som äger en textram**

När generisk textbehandlingskod får en [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) från en tabell, använd egenskapen [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) för att hämta den ägande [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). För en tabellcell‑textram är [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) satt och [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) är `None`, även om själva tabellen är en form.

Cellekoordinaterna är tillgängliga via de skrivskyddade egenskaperna [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) och [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) är också skrivskyddad: den ger navigering till ägaren men ändrar inte ägandet. Kontrollera alltid om den returnerade cellen är `None` innan du använder den.

För ett komplett exempel som identifierar tabellcell‑ och formägare, inklusive former associerade med SmartArt‑noder, se [Sök och ersätt text](/slides/sv/python-net/search-and-replace-text/).

## **Justera text i en tabell**

Du kan kontrollera den vertikala förankringen och textriktningen för enskilda tabellceller. Exemplet i detta avsnitt centrerar text i den första cellen och roterar den 270 grader.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Lägg till ett [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑objekt på bilden.
4. Kom åt ett [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)‑objekt från tabellen.
5. Kom åt den första [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) och ange dess text och färg.
6. Ange cellens [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) och [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/).
7. Spara den modifierade presentationen.

Detta exempel skapar en 4 × 4‑tabell med kolumnbredder på 120 punkter och radhöjder på 100 punkter. Det formaterar texten i cell (0, 0), lägger till värden i de återstående cellerna i den första raden och sparar resultatet som `Vertical_Align_Text_out.pptx`.

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

## **Ange textformatering på tabellnivå**

Använd [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) för att tillämpa textformatering på alla celler i en tabell. Dess överlagringar accepterar formatering för del, stycke och textram, så du kan sätta dessa egenskaper utan att iterera genom enskilda celler.

1. Läs in presentationen med hjälp av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Kom åt ett [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑objekt från bilden.
4. Ange [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) för texten.
5. Ange [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) och [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Ange [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Spara den modifierade presentationen.

Exemplet nedan öppnar `table.pptx`, som måste innehålla minst en bild med en tabell som dess första form. Det sätter teckenstorleken till 25 punkter, justerar stycken åt höger med en högermarginal på 20 punkter och gör texten vertikal. Den formaterade presentationen sparas som `result.pptx`.

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

## **Hämta tabellstilsegenskaper**

Använd [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) för att läsa eller tilldela en tabsellens förinställda stil. Detta exempel applicerar [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) på en tabell, skriver ut förinställningsnamnet och tilldelar samma förinställning till en annan tabell. Båda tabellerna sparas i `table-style.pptx`.

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

## **Lås bildförhållandet för en tabell**

En tabsells bildförhållande är förhållandet mellan dess bredd och höjd. Använd [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) för att låsa detta förhållande för en tabell.

Exemplet nedan öppnar `pres.pptx`, som måste innehålla minst en bild med en tabell som dess första form. Det skriver ut det aktuella låstillståndet, aktiverar låsning av bildförhållandet, skriver ut det uppdaterade tillståndet (`True`) och sparar resultatet som `pres-out.pptx`.

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

**Kan jag aktivera höger‑till‑vänster (RTL) läsriktning för en hel tabell och texten i dess celler?**

Ja. Tabellen exponerar egenskapen [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) och stycken har [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutliga filen?**

Använd [formlås](/slides/sv/python-net/applying-protection-to-presentation/) för att inaktivera flytt, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [bildfyllning](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt valt läge (sträckning eller kakel).