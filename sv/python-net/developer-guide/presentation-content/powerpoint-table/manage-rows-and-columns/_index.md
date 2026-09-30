---
title: "Hantera rader och kolumner i PowerPoint‑tabeller med Python"
linktitle: "Rader och kolumner"
type: docs
weight: 20
url: /sv/python-net/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första rad
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- radtextformatering
- kolumntextformatering
- tabellstil
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för Python via .NET och snabba upp redigering av presentationer och datauppdateringar."
---
## **Introduktion**

Aspose.Slides for Python via .NET låter dig hantera tabellstruktur och formatering i PowerPoint‑presentationer via klassen [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Du kan ange en rubrikrad, klona eller ta bort rader och kolumner samt tillämpa textformatering på en hel rad eller kolumn.

Den här artikeln förklarar dessa operationer med Python‑exempel. Den visar också hur du hämtar ett tabellformatförinställning så att du kan återanvända den. Index för tabellrader och -kolumner är nollbaserade.

## **Styr radens höjd**

Använd [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) för att ange en rads minsta höjd i punkter. Det är en lägre gräns, inte en fast höjd. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) returnerar den faktiska höjden och är skrivskyddad. Åtkomst till raden sker via [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

Exemplet laddar [row-height-input.pptx](row-height-input.pptx), som har en tabell som den första formen på den första bilden. Dess första rad börjar vid 70 punkter. Cellerna använder 18‑punkts Arial‑text, radbrytning och 6 punkts marginaler över‑ och under; den längre texten i den andra kolumnen radbryts på flera rader. Exemplet ökar minimum till 100 punkter, minskar det sedan till 20 punkter, skriver ut den faktiska höjden efter varje ändring och sparar båda resultatena.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Med den medföljande presentationen lägger ökning av minimum till extra utrymme i raden. Minskning tar bort det extra utrymmet, men den faktiska höjden förblir över 20 punkter eftersom texten och cellmarginalerna kräver mer plats. Att bara minska minimum kan inte tvinga raden under det utrymme som dess innehåll kräver.

Flera faktorer påverkar den faktiska höjden:

- **Text och teckenstorlek:** längre text, explicita radbrytningar eller en större teckenstorlek kan kräva mer vertikalt utrymme.
- **Radbrytning och kolumnbredd:** med radbrytning aktiverad kan en smalare [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) skapa fler rader. En bredare kolumn kan minska det vertikala utrymmet som behövs.
- **Cellmarginaler:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) och [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) lägger till vertikalt utrymme. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) och [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) minskar bredden som finns för text och kan orsaka ytterligare radbrytning.

För den här tabellen utan sammanslagna celler avgör den cell som behöver mest vertikalt utrymme den innehållsdrivna lägre gränsen för hela raden. För att göra raden kortare kan du behöva förkorta texten, minska teckenstorleken eller marginalerna, eller bredda en kolumn.

Bilderna nedan visar samma tabell i samma skala. I detta körning var de faktiska höjderna 70, 100 och 55,2 punkter: den sista raden förblev högre än dess 20‑punkts minimum. Exakta textmått kan variera beroende på vilka teckensnitt som finns i din miljö. Ladda ner de sparade resultaten: [increased minimum](row-height-increased.pptx) och [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Ange den första raden som en rubrik**

Använd egenskapen [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) för att markera den första raden för rubrikformatering. Dess utseende beror på den tabellstil som tillämpas på tabellen.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Åtkomst till den första bilden.
3. Åtkomst till tabellen som lagras som den första formen på bilden.
4. Aktivera rubrikformatering för dess första rad.
5. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden. Det aktiverar rubrikformatering för den första raden och sparar `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona en tabellrad eller -kolumn**

Klona rader eller kolumner för att återanvända deras innehåll och formatering. Du kan lägga till en kopia i slutet av tabellen eller infoga den på en specifik position.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Åtkomst till den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Klona de önskade raderna.
6. Klona de önskade kolumnerna.
7. Spara den modifierade presentationen.

Exemplet kräver `Test.pptx` med minst en bild. Det skapar en tabell med tre kolumner och fem rader, med dimensioner angivna i punkter. Det lägger till kopior av den första raden och kolumnen, och infogar sedan kopior av den andra raden och kolumnen på index 3 (den fjärde positionen). Den resulterande tabellen har sju rader och fem kolumner. Argumentet `False` inaktiverar kloning i intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort en rad eller kolumn från en tabell**

Ta bort rader eller kolumner som inte längre behövs i en tabell. När ett objekt tas bort förskjuts indexen för de rader eller kolumner som följer efter det.

1. Skapa en presentation med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Åtkomst till den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Ta bort den andra raden och den andra kolumnen.
6. Spara den modifierade presentationen.

Detta exempel skapar en tre‑gånger‑tre‑tabell och tar bort raden och kolumnen på index 1, vilket lämnar en två‑gånger‑två‑tabell i `TestTable_out.pptx`. Dimensionerna är i punkter. Argumentet `False` inaktiverar borttagning av intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange textformatering på radr nivå**

Tillämpa textformatering på en hel rad för att hålla cellerna konsekventa. Du kan ställa in teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Åtkomst till tabellen på den första bilden.
3. Ställ in [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) för den första raden.
4. Ställ in [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) och [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) för den första raden.
5. Ställ in [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) för den andra raden.
6. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två rader. Det tillämpar 25‑punkts text, högerjustering och en 20‑punkts högermarginal på den första raden, och sätter sedan vertikal text i den andra raden.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange textformatering på kolumnnivå**

Tillämpa textformatering på en hel kolumn för att hålla cellerna konsekventa. Du kan ställa in teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Åtkomst till tabellen på den första bilden.
3. Ställ in [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) för den första kolumnen.
4. Ställ in [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) och [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) för den första kolumnen.
5. Ställ in [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) för den andra kolumnen.
6. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två kolumner. Det tillämpar 25‑punkts text, högerjustering och en 20‑punkts högermarginal på den första kolumnen, och sätter sedan vertikal text i den andra kolumnen.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Hämta tabellstils‑egenskaper**

Använd egenskapen [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) för att hämta den förinställning som har tillämpats på en tabell och återanvända den på en annan tabell. Detta identifierar förinställningen snarare än individuella cell‑formaterings‑överskrivningar.

Exemplet skapar en tabell, tillämpar [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), och läser tillbaka förinställningen. Det skriver ut `True` när den hämtade förinställningen matchar den tillämpade och sparar tabellen i `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/stilar på en tabell som redan skapats?**

Ja. Tabellen ärver bild‑/layout‑/master‑temat, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först och återbefolka sedan tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner, och åsidosätt sedan specifika celler med lokal formatering; cell‑nivå‑formatering har företräde framför tabellstilen.