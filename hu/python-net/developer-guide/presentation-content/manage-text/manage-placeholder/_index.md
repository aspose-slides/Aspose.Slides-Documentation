---
title: Helyőrzők kezelése prezentációkban Python segítségével
linktitle: Helyőrzők kezelése
type: docs
weight: 10
url: /hu/python-net/manage-placeholder/
keywords:
- helyőrző
- szöveghelyőrző
- képhelyőrző
- diagramhelyőrző
- felhívási szöveg
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Könnyedén kezelheti a helyőrzőket az Aspose.Slides for Python (.NET) segítségével: cserélheti a szöveget, testreszabhatja a felhívásokat és beállíthatja a kép átlátszóságát PowerPointban és OpenDocumentban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan kezelje a bemutatóhelyőrzőket. Ez a cikk bemutatja, hogyan találhatók meg a helyőrzők a diákon, hogyan változtatható meg a szövegük, hogyan állítható be egyéni felhívási szöveg a helyőrző elrendezésekhez, valamint hogyan állítható be egy kép átlátszósága, amely a helyőrző háttérként szolgál. Tartalmaz egy rövid GYIK-et is, amely tisztázza a bázishelyőrző és a helyi alakzat közti különbséget, ismerteti, hogyan alkalmazhatók a helyőrző módosításai elrendezéseken vagy mestereken keresztül, és hivatkozik a fejléc és lábléc helyőrző kezelésére.

## **Szöveg módosítása a helyőrzőkben**

Az Aspose.Slides for Python segítségével megtalálhatja és módosíthatja a helyőrzőket egy prezentáció diáin. Az Aspose.Slides lehetővé teszi a helyőrző szövegének módosítását.

**Előfeltétel:** Szüksége van egy helyőrzőt tartalmazó prezentációra. Ilyen prezentációt létrehozhat a Microsoft PowerPointben.

Az alábbiakban bemutatjuk, hogyan használja az Aspose.Slides‑t egy helyőrző szövegének cseréjéhez:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és adja meg a prezentációt argumentumként.
1. Szerezzen hivatkozást a dia indexe alapján.
1. Iteráljon a alakzatokon a helyőrző megtalálásáig.
1. Módosítsa a szöveget a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) segítségével, amely a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/)-hez tartozik.
1. Mentse el a módosított prezentációt.

Ez a Python kód mutatja be, hogyan változtatható meg a szöveg egy helyőrzőben:

```python
import aspose.slides as slides

# Példányosítsa a Presentation osztályt.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Nyissa meg az első diát.
    slide = presentation.slides[0]

    # Iteráljon a formákon a helyőrzők megtalálásához.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Módosítsa minden helyőrző szövegét.
            shape.text_frame.text = "This is Placeholder"

    # Mentse a prezentációt a lemezre.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Felhívási szöveg beállítása egy helyőrzőhöz**

A szabványos és előre elkészített elrendezések tartalmaznak helyőrző felhívási szöveget, például **Kattintson a cím hozzáadásához** vagy **Kattintson az alcím hozzáadásához**. Az Aspose.Slides segítségével ezeket a felhívásokat saját szövegre cserélheti a helyőrző elrendezésekben.

Az alábbi Python példa bemutatja, hogyan állítható be a felhívási szöveg egy helyőrzőhöz:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Iteráljon a formákon a helyőrzők megtalálásához.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kép átlátszóságának beállítása egy helyőrzőben**

Az Aspose.Slides lehetővé teszi egy háttérkép átlátszóságának beállítását egy szöveghelyőrzőben. A kép átlátszóságának módosításával a keretben kiemelhető a szöveg vagy a kép, a színek függvényében.

Az alábbi Python példa megmutatja, hogyan állítható be egy kép háttér átlátszósága egy alakzaton belül:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **GYIK**

**Mi az a bázishelyőrző, és miben különbözik egy helyi alakzattól a diámon?**

A bázishelyőrző az eredeti alakzat egy elrendezésen vagy masteren, amelyből a dia alakzata örököl – a típus, a pozíció és néhány formázás innen származik. A helyi alakzat független; ha nincs bázishelyőrző, az öröklődés nem érvényesül.

**Hogyan frissíthetek minden címet vagy feliratot egy prezentációban anélkül, hogy minden diát külön-külön iterálnék?**

A megfelelő helyőrzőt szerkessze az elrendezésen vagy a masteren. Az azok alapján létrehozott diák automatikusan öröklik a változást.

**Hogyan irányíthatom a szabványos fejléc/lábléc helyőrzőket – dátum & idő, dia szám és lábléc szöveg?**

Használja a HeaderFooter kezelőket a megfelelő hatókörben (normál diák, elrendezések, master, jegyzetek/handoutok) a helyőrzők be- vagy kikapcsolásához, valamint a tartalmuk beállításához.