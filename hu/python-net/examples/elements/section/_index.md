---
title: Szakasz
type: docs
weight: 90
url: /hu/python-net/examples/elements/section/
keywords:
- szakasz
- dia szakasz
- szakasz hozzáadása
- szakasz elérése
- szakasz eltávolítása
- szakasz átnevezése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Kêrélje a dia szakaszokat Pythonban az Aspose.Slides segítsegével: kényen hozhat létre, átnevezíthetők, átrendézhetők, diák athélyezhetők a szakaszok közőt, és szabályozhatja a láthatóságot PPT, PPTX és ODP esetén."
---
Példák a prezentáció szakaszok kezelésére – hozzáadás, elérés, eltávolítás és átnevezés programozott módon az **Aspose.Slides for Python via .NET** használatával.

## **Szakasz hozzáadása**

Hozzon létre egy szakaszt, amely egy adott diától indul.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Új szakasz hozzáadása és a szakasz kezdetét jelölő dia megadása.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Szakasz elérése**

Szerezzen be egy szakaszt egy prezentációból.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Szakaszt index alapján elérni.
        section = presentation.sections[0]
```

## **Szakasz eltávolítása**

Törölje a korábban hozzáadott szakaszt.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Szakasz eltávolítása.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Szakasz átnevezése**

Módosítsa egy meglévő szakasz nevét.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # A szakasz átnevezése.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```