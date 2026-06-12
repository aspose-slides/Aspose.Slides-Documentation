---
title: Tabel
type: docs
weight: 120
url: /nl/python-net/examples/elements/table/
keywords:
- tabel
- tabel toevoegen
- tabel benaderen
- tabel verwijderen
- cellen samenvoegen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak en formatteer tabellen in Python met Aspose.Slides: gegevens invoegen, cellen samenvoegen, randen stijlen, inhoud uitlijnen, en importeren/exporteren voor PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen van tabellen, het benaderen ervan, het verwijderen ervan en het samenvoegen van cellen met **Aspose.Slides for Python via .NET**.

## **Tabel toevoegen**

Maak een eenvoudige tabel met twee rijen en twee kolommen.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Definieer kolombreedtes en rijhoogtes.
        widths = [80, 80]
        heights = [30, 30]

        # Voeg een tabelvorm toe aan de dia.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een tabel**

Haal de eerste tabelvorm op de dia op.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Toegang tot de eerste tabel op de dia.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Tabel verwijderen**

Verwijder een tabel van een dia.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemen dat de eerste vorm een tabel is.
        table = slide.shapes[0]

        # Verwijder de tabel van de dia.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabelcellen samenvoegen**

Voeg naast elkaar liggende cellen van een tabel samen tot één cel.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemen dat de eerste vorm een tabel is.
        table = slide.shapes[0]

        # Cellen samenvoegen.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```