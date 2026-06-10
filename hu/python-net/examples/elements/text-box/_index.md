---
title: Szövegdoboz
type: docs
weight: 40
url: /hu/python-net/examples/elements/text-box/
keywords:
- szövegdoboz
- szövegdoboz hozzáadása
- szövegdoboz elérése
- szövegdoboz eltávolítása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Szövegdobozok létrehozása és formázása Pythonban az Aspose.Slides segítségével: betűtípusok, igazítás, tördelés, automatikus méretezés beállítása, valamint hivatkozások a diák finomhangolásához PowerPoint és OpenDocument esetén."
---
Az Aspose.Slides-ban a **szövegdoboz** egy `AutoShape`-ként van ábrázolva. Szinte bármely alakzat tartalmazhat szöveget, de egy tipikus szövegdoboz nem rendelkezik kitöltéssel vagy kerettel, és csak szöveget jelenít meg.

Ez az útmutató bemutatja, hogyan lehet programozottan hozzáadni, elérni és eltávolítani a szövegdobozokat.

## **Szövegdoboz hozzáadása**

A szövegdoboz egyszerűen egy `AutoShape`, amely nem rendelkezik kitöltéssel vagy kerettel, valamint formázott szöveget tartalmaz. Íme, hogyan hozható létre egy:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Hozzon létre egy téglalap alakzatot (alapértelmezés szerint kitöltött kerettel és szöveg nélkül).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Távolítsa el a kitöltést és a keretet, hogy tipikus szövegdoboznak tűnjön.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Állítsa be a szövegformázást.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Adja meg a tényleges szövegtartalmat.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Megjegyzés:** Bármely `AutoShape`, amely nem üres `TextFrame`-et tartalmaz, funkcionálhat szövegdobozként.

## **Szövegdobozok elérése tartalom alapján**

Az összes olyan szövegdoboz megtalálásához, amely egy adott kulcsszót tartalmaz (például „Slide”), iteráljon végig az alakzatokon, és ellenőrizze a szöveget:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Csak az AutoShape-ek tartalmazhatnak szerkeszthető szöveget.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Végezzen valamit a megfelelő szövegdobozzal.
                    pass
```

## **Szövegdobozok eltávolítása tartalom alapján**

Ez a példa megtalálja és törli az első dián található összes olyan szövegdobozt, amely egy adott kulcsszót tartalmaz:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Keresse meg az eltávolítandó alakzatokat, amelyek AutoShape-ek és tartalmazzák a "Slide" szót.
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Távolítsa el a megfelelő alakzatot a diáról.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tipp:** Mindig készítsen másolatot az alakzatelérési gyűjteményről, mielőtt módosítaná azt iterálás során, hogy elkerülje a gyűjtemény módosítási hibákat.