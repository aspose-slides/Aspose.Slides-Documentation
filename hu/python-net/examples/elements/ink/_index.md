---
title: Tinta
type: docs
weight: 180
url: /hu/python-net/examples/elements/ink/
keywords:
- tinta
- tinta elérése
- tinta eltávolítása
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "Kezelje a digitális tintát a diákon Pythonban az Aspose.Slides segítségével: adjon hozzá tollvonásokat, szerkessze az útvonalakat, állítsa be a színt és a szélességet, és exportálja az eredményeket PowerPoint és OpenDocument formátumba."
---
Példákat mutat be létező tintalakzatok elérésére és eltávolítására a **Aspose.Slides for Python via .NET** használatával.

> ❗ **Megjegyzés:** A tintalakzatok a speciális eszközök felhasználói bemenetét képviselik. Az Aspose.Slides programozottan nem tud új tintavonalakat létrehozni, de a meglévő tintát olvashatja és módosíthatja.

## **Tintához hozzáférés**

Szerezze meg az első tintalakzatot egy diáról.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Tintát eltávolítani**

Törölje a tintalakzatot a diáról.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy Ink objektum.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```