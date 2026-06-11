---
title: Tabell
type: docs
weight: 120
url: /sv/python-net/examples/elements/table/
keywords:
- tabell
- lägga till tabell
- komma åt tabell
- ta bort tabell
- slå ihop celler
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa och formatera tabeller i Python med Aspose.Slides: infoga data, slå ihop celler, formatera kanter, justera innehåll och importera/exportera för PPT, PPTX och ODP."
---
Exempel på att lägga till tabeller, komma åt dem, ta bort dem och slå ihop celler med **Aspose.Slides for Python via .NET**.

## **Lägg till en tabell**

Skapa en enkel tabell med två rader och två kolumner.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Definiera kolumnbredder och radhöjder.
        widths = [80, 80]
        heights = [30, 30]

        # Lägg till en tabellform på bilden.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Kom åt en tabell**

Hämta den första tabellformen på bilden.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första tabellen på bilden.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Ta bort en tabell**

Radera en tabell från en bild.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att den första formen är en tabell.
        table = slide.shapes[0]

        # Ta bort tabellen från bilden.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Slå ihop tabellceller**

Slå ihop intilliggande celler i en tabell till en enda cell.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att den första formen är en tabell.
        table = slide.shapes[0]

        # Slå ihop celler.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```