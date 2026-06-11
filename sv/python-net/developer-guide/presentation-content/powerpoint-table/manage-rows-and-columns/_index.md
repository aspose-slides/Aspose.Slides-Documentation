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
description: "Hantera tabellrader och -kolumner i PowerPoint och OpenDocument med Aspose.Slides för Python via .NET och snabba upp redigering av presentationer samt datauppdateringar."
---
## **Översikt**

Denna artikel visar hur du hanterar tabellrader och -kolumner i PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för Python. Du får lära dig hur du lägger till, infogar, klonar och tar bort rader eller kolumner, markerar den första raden som en rubrik, justerar storlek och layout samt tillämpar text‑ och stilformatering på rad‑ eller kolumnnivå. Varje uppgift demonstreras med kompakt, självständigt kodexempel baserat på API‑referensen [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/), så att du snabbt kan hitta en tabell på en bild och omforma dess struktur enligt din design.

## **Ange den första raden som rubrik**

Markera tabellens första rad som en rubrik för att tydligt skilja kolumnrubriker från data. I Aspose.Slides för Python aktiverar du helt enkelt tabellens *First Row*-alternativ för att tillämpa rubrikformateringen som definieras av den valda tabellstilen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och ladda presentationen.  
1. Åtkomst till bilden via dess index.  
1. Iterera genom alla objekt av typen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) för att hitta den relevanta tabellen.  
1. Ställ in tabellens första rad som rubrik.

Denna Python‑kod visar hur du anger en tabells första rad som rubrik:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation("table.pptx") as presentation:
    # Åtkomst till den första bilden.
    slide = presentation.slides[0]

    # Iterera genom formerna och få en referens till tabellen.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Ställ in tabellens första rad som rubrik.
    table.first_row = True
    
    # Spara presentationen till disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klona en tabellrad eller -kolumn**

Klona en valfri tabellrad eller -kolumn och infoga kopian på önskad position i tabellen. Duplicatet bevarar cellinnehåll, formatering och storlekar, så att du snabbt kan utöka layouter på ett konsekvent sätt.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och ladda presentationen.  
1. Åtkomst till bilden via dess index.  
1. Definiera en array med kolumnbredder.  
1. Definiera en array med radhöjder.  
1. Lägg till en [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/) på bilden med `add_table(x, y, column_widths, row_heights)`.  
1. Klona en tabellrad.  
1. Klona en tabellkolumn.  
1. Spara den ändrade presentationen.

Denna Python‑kod visar hur du klonar en rad och en kolumn i en PowerPoint‑tabell:

```python
 import aspose.slides as slides

# Skapa en instans av Presentation‑klassen.
with slides.Presentation() as presentation:
    # Åtkomst till den första bilden.
    slide = presentation.slides[0]

    # Definiera kolumnbredder och radhöjder.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Lägg till en tabell på bilden.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Lägg till text i rad 1, kolumn 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Lägg till text i rad 2, kolumn 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Klona rad 1 i slutet av tabellen.
    table.rows.add_clone(table.rows[0], False)

    # Lägg till text i rad 1, kolumn 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Lägg till text i rad 2, kolumn 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Klona rad 2 som den fjärde raden i tabellen.
    table.rows.insert_clone(3,table.rows[1], False)

    # Klona den första kolumnen i slutet.
    table.columns.add_clone(table.columns[0], False)

    # Klona den andra kolumnen på index 3 (den fjärde positionen).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Spara presentationen till disk.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort en rad eller kolumn från en tabell**

Förenkla en tabell genom att ta bort en rad eller kolumn via index med Aspose.Slides för Python – layouten justeras automatiskt samtidigt som formateringen för återstående celler bevaras. Detta är praktiskt för att förenkla datagrids eller radera platshållare utan att behöva bygga om tabellen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och ladda presentationen.  
1. Åtkomst till bilden via dess index.  
1. Definiera en array med kolumnbredder.  
1. Definiera en array med radhöjder.  
1. Lägg till en ITable på bilden med `add_table(x, y, column_widths, row_heights)`.  
1. Ta bort tabellraden.  
1. Ta bort tabellkolumnen.  
1. Spara den ändrade presentationen.

Följande Python‑kod visar hur du tar bort en rad och en kolumn från en tabell:

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

## **Ställ in textformatering på radnivå i tabellen**

Tillämpa enhetlig textstil på en hel tabellrad i ett steg. Med Aspose.Slides för Python kan du ange typsnitt, storlek, vikt, färg och justering för alla celler i raden samtidigt för att hålla rubriker eller databand uniforma.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och ladda presentationen.  
1. Åtkomst till bilden via dess index.  
1. Åtkomst till det relevanta [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/)-objektet på bilden.  
1. Ange teckenhöjden för cellerna i första raden.  
1. Ange justering och högermarginal för cellerna i första raden.  
1. Ange vertikal texttyp för cellerna i andra raden.  
1. Spara den ändrade presentationen.

Denna Python‑kod demonstrerar operationen.

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Ange teckenhöjden för cellerna i första raden.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Ange textjustering och högermarginal för cellerna i första raden.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Ange vertikal texttyp för cellerna i andra raden.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Spara presentationen till disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in textformatering på kolumnnivå i tabellen**

Tillämpa enhetlig textstil på en hel tabellkolumn på en gång. Med Aspose.Slides för Python kan du ange typsnitt, storlek, vikt, färg och justering för alla celler i en kolumn för att skapa enhetliga vertikala band för rubriker eller data.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och ladda presentationen.  
1. Åtkomst till bilden via dess index.  
1. Åtkomst till det relevanta [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/)-objektet på bilden.  
1. Ange teckenhöjden för cellerna i första kolumnen.  
1. Ange justering och högermarginal för cellerna i första kolumnen.  
1. Ange vertikal texttyp för cellerna i andra kolumnen.  
1. Spara den ändrade presentationen.

Följande Python‑kod demonstrerar operationen:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Ställ in teckenhöjden för cellerna i första kolumnen.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Ställ in textjustering och högermarginal för cellerna i första kolumnen.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Ställ in vertikal texttyp för cellerna i andra kolumnen.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Spara presentationen till disk.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Hämta egenskaper för tabellstil**

Aspose.Slides låter dig hämta en tabells stilegenskaper så att du kan återanvända dem för en annan tabell eller på annan plats. Följande Python‑kod visar hur du får stilegenskaperna från en fördefinierad tabellstil:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Kan jag tillämpa PowerPoint‑teman/-stilar på en tabell som redan har skapats?**

Ja. Tabellen ärver slide‑/layout‑/master‑temat, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först, och fyll sedan tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller egna färger på specifika celler?**

Ja. Aktivera bandade kolumner och åsidosätt sedan specifika celler med lokala format; cell‑nivå‑formatering har företräde framför tabellstilen.