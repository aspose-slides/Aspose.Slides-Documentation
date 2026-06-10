---
title: Táblázat
type: docs
weight: 120
url: /hu/python-net/examples/elements/table/
keywords:
- táblázat
- táblázat hozzáadása
- táblázat elérése
- táblázat eltávolítása
- cellák egyesítése
- kód példák
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "Táblázatok létrehozása és formázása Pythonban az Aspose.Slides segítségével: adatok beillesztése, cellák egyesítése, szegélyek stílusozása, tartalom igazítása, valamint import/export PPT, PPTX és ODP formátumokhoz."
---
Példák táblák hozzáadására, elérésére, eltávolítására és cellák egyesítésére a **Aspose.Slides for Python via .NET** használatával.

## **Táblázat hozzáadása**

Hozzon létre egy egyszerű táblázatot két sorral és két oszloppal.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Határozza meg az oszlopszélességeket és a sormagasságokat.
        widths = [80, 80]
        heights = [30, 30]

        # Adjon hozzá egy táblázat alakzatot a diához.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázat elérése**

Hozza vissza az első táblázat alakzatot a dián.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # A dián lévő első táblázat elérése.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Táblázat eltávolítása**

Törölje a táblázatot egy diáról.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy táblázat.
        table = slide.shapes[0]

        # A táblázat eltávolítása a diáról.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Táblázatcellák egyesítése**

Egyesítse a táblázat egymás melletti celláit egyetlen cellába.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy táblázat.
        table = slide.shapes[0]

        # Cellák egyesítése.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```