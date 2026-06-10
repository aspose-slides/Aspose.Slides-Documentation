---
title: Hiperhivatkozás
type: docs
weight: 130
url: /hu/python-net/examples/elements/hyperlink/
keywords:
- hiperhivatkozás
- hiperhivatkozás hozzáadása
- hiperhivatkozás elérése
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, szerkesztése és eltávolítása Pythonban az Aspose.Slides segítségével: szöveg, alakzatok, diák, URL-ek és e‑mail hivatkozás; célok és műveletek beállítása PPT, PPTX és ODP fájlokhoz."
---
Bemutatja a hiperhivatkozások hozzáadását, elérését, eltávolítását és frissítését alakzatokon, az **Aspose.Slides for Python via .NET** használatával.

## **Hiperhivatkozás hozzáadása**

Hozzon létre egy téglalap alakzatot, amelynek hiperhivatkozása egy külső weboldalra mutat.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiperhivatkozás elérése**

Olvassa ki a hiperhivatkozás információkat az alakzat szövegrésszel kapcsolatban.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Hiperhivatkozás eltávolítása**

Törölje a hiperhivatkozást az alakzat szövegéből.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiperhivatkozás frissítése**

Módosítsa egy meglévő hiperhivatkozás célját. Használja a `HyperlinkManager`-t a már hiperhivatkozással rendelkező szöveg módosításához, amely azt utánozza, ahogyan a PowerPoint biztonságosan frissíti a hiperhivatkozásokat.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # A meglévő szövegben lévő hiperhivatkozás módosítása a
        # HyperlinkManager használatával kell történjen, a tulajdonság közvetlen beállítása helyett.
        # Ez utánzja, ahogyan a PowerPoint biztonságosan frissíti a hiperhivatkozásokat.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```