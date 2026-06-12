---
title: Tabulka
type: docs
weight: 120
url: /cs/python-net/examples/elements/table/
keywords:
- tabulka
- přidat tabulku
- přístup k tabulce
- odstranit tabulku
- sloučit buňky
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte a formátujte tabulky v Pythonu pomocí Aspose.Slides: vložte data, sloučte buňky, stylizujte okraje, zarovnejte obsah a importujte/exportujte pro PPT, PPTX a ODP."
---
Příklady přidávání tabulek, přístupu k nim, odstraňování a slučování buněk pomocí **Aspose.Slides for Python via .NET**.

## **Přidat tabulku**

Vytvořte jednoduchou tabulku se dvěma řádky a dvěma sloupci.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Definovat šířky sloupců a výšky řádků.
        widths = [80, 80]
        heights = [30, 30]

        # Přidat tvar tabulky na snímek.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k tabulce**

Získejte první tvar tabulky na snímku.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Přístup k první tabulce na snímku.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Odstranit tabulku**

Odstraňte tabulku ze snímku.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že první tvar je tabulka.
        table = slide.shapes[0]

        # Odstranit tabulku ze snímku.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Sloučit buňky tabulky**

Sloučte sousední buňky tabulky do jedné buňky.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládá se, že první tvar je tabulka.
        table = slide.shapes[0]

        # Sloučit buňky.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```