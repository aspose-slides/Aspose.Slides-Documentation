---
title: Obrázek
type: docs
weight: 50
url: /cs/python-net/examples/elements/picture/
keywords:
- obrázek
- rámec obrázku
- přidat obrázek
- přístup k obrázku
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Práce s obrázky v Pythonu pomocí Aspose.Slides: vložit, nahradit, oříznout, komprimovat, upravit průhlednost a efekty, vyplnit tvary a exportovat pro PPT, PPTX a ODP."
---
Ukazuje, jak vložit a přistupovat k obrázkům z paměťových obrázků pomocí **Aspose.Slides for Python via .NET**. Níže uvedené příklady vytvoří obrázek v paměti, umístí jej na snímek a poté jej načtou.

## **Přidat obrázek**

Tento kód načte obrázek ze souboru a vloží jej jako rámec obrázku na první snímek.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Načíst obrázek ze souboru.
        with open("image.png", "rb") as image_stream:
            # Přidat obrázek do zdrojů prezentace.
            image = presentation.images.add_image(image_stream)

        # Vložit rámeček obrázku zobrazující obrázek na první snímek.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k obrázku**

Tento příklad zajistí, že snímek obsahuje rámec obrázku, a poté přistoupí k prvnímu, který najde.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Přístup k prvnímu rámečku obrázku na snímku.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```