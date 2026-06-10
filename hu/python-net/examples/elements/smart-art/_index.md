---
title: SmartArt
type: docs
weight: 140
url: /hu/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt hozzáadása
- SmartArt elérése
- SmartArt eltávolítása
- SmartArt elrendezés
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Készítsen és szerkesszen SmartArt grafikákat Pythonban az Aspose.Slides segítségével: adjon hozzá csomópontokat, módosítsa az elrendezéseket és stílusokat, alakítsa pontosan alakzatokká, és exportálja PPT, PPTX és ODP formátumokba."
---
Bemutatja, hogyan lehet SmartArt grafikákat hozzáadni, elérni, eltávolítani, és elrendezéseket módosítani az **Aspose.Slides for Python via .NET** használatával.

## **SmartArt hozzáadása**

Helyezzen be egy SmartArt grafikát az egyik beépített elrendezés használatával.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt elérése**

Szerezze meg az első SmartArt objektumot egy dián.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Az első SmartArt alakzat elérése.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **SmartArt eltávolítása**

Töröljön egy SmartArt alakzatot a diáról.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy SmartArt objektum.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt elrendezés módosítása**

Frissítse egy meglévő SmartArt grafika elrendezés típusát.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy SmartArt objektum.
        smart_art = slide.shapes[0]

        # A SmartArt elrendezés módosítása.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```