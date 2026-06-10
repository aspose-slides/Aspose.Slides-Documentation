---
title: "Prezentációs formák bélyegképeinek létrehozása Pythonban"
linktitle: "Forma bélyegképek"
type: docs
weight: 70
url: /hu/python-net/create-shape-thumbnails/
keywords:
- "forma bélyegkép"
- "forma kép"
- "forma renderelése"
- "forma renderelés"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Készítsen kiváló minőségű forma bélyegképeket PowerPoint és OpenDocument diákból az Aspose.Slides for Python via .NET segítségével – egyszerűen hozzon létre és exportáljon prezentációs bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides for Python via .NET-et prezentációs fájlok létrehozására használják, ahol minden oldal egy dia. Ezeket a diákot a Microsoft PowerPoint-ben tekintheti meg a prezentációs fájl megnyitásával. Néha azonban a fejlesztőknek külön képfájlként kell megjeleníteniük a formák képeit egy képmegjelenítőben. Ilyen esetben az Aspose.Slides előállíthat bélyegkép‑képeket a diáformákhoz. Ez a cikk elmagyarázza, hogyan használhatja ezt a funkciót.

## **Bélyegképek generálása formákról diákból**

Amikor egy adott objektum előnézetére van szükség, a teljes dia helyett az egyedi forma bélyegképét is előállíthatja. Az Aspose.Slides lehetővé teszi bármely forma exportálását képként, így egyszerűen létrehozhat könnyű előnézeteket, ikonokat vagy további feldolgozáshoz szükséges eszközöket.

Bélyegkép előállítása bármely formáról:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára azonosítója vagy indexe alapján.
1. Szerezzen referenciát egy formára azon a dián.
1. Renderelje a forma bélyegkép‑képét.
1. Mentse a bélyegképet a kívánt formátumban.

Az alábbi példa egy forma bélyegképet generál.

```py
import aspose.slides as slides

# Hozzon létre egy Presentation példányt a prezentációs fájl megnyitásához.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Hozzon létre egy képet az alapértelmezett mérettel.
    with shape.get_image() as thumbnail:
        # Mentse a képet lemezre PNG formátumban.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Bélyegképek generálása egyedi skálázási tényezővel**

Ez a rész bemutatja, hogyan generálhat forma‑bélyegképeket felhasználó által meghatározott skálázási tényezővel az Aspose.Slides‑ben. A méret szabályozásával finomhangolhatja a bélyegkép méretét az előnézetek, exportok vagy magas DPI‑jű megjelenítők számára.

Bélyegkép generálása bármely forma számára egy dián:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen diát azonosítója vagy indexe alapján.
1. Szerezzen célnak megfelelő formát azon a dián.
1. Renderelje a forma bélyegképét a megadott skálával.
1. Mentse a bélyegképet a kívánt formátumban.

Az alábbi példa egy felhasználó által meghatározott skálával generál bélyegképet.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Hozzon létre egy Presentation példányt a prezentációs fájl megnyitásához.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Hozzon létre egy képet a meghatározott mérettel.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Mentse a képet lemezre PNG formátumban.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Bélyegképek generálása a forma megjelenési határainak figyelembevételével**

Ez a rész bemutatja, hogyan generálhat bélyegképet egy forma megjelenési határain belül. Figyelembe veszi a forma összes effektjét. A generált bélyegkép a dia határaihoz van korlátozva.

Bélyegkép generálása bármely diaformára a megjelenési határokon belül:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen diát azonosítója vagy indexe alapján.
1. Szerezzen célnak megfelelő formát azon a dián.
1. Renderelje a forma bélyegképét a megadott határokkal.
1. Mentse a bélyegképet a kívánt képformátumban.

Az alábbi példa felhasználó által definiált határokkal hoz létre bélyegképet.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Hozzon létre egy Presentation példányt a prezentációs fájl megnyitásához.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Hozzon létre egy megjelenési határokkal rendelkező forma képet.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Mentse a képet lemezre PNG formátumban.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **GYIK**

**Milyen képfájl-formátumok használhatók a forma‑bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imageformat/), és egyebek. A formákat [vektorként SVG‑ként is exportálhatja](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/write_as_svg/) a forma tartalmát SVG‑ként mentve.

**Mi a különbség a SHAPE és az APPEARANCE határok között a bélyegkép renderelésekor?**

A `SHAPE` a forma geometriáját használja; az `APPEARANCE` figyelembe veszi a [vizuális effektusokat](/slides/hu/python-net/shape-effect/) (árnyékok, ragyogás stb.).

**Mi történik, ha egy forma rejtettnek van jelölve? Mégis bélyegképként renderelődik?**

A rejtett forma továbbra is része a modellnek, és renderelhető; a rejtett jelző a diavetítés megjelenését befolyásolja, de nem akadályozza a forma képének előállítását.

**Támogatottak-e csoportos formák, diagramok, SmartArt és más összetett objektumok?**

Igen. Bármely objektum, amely [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/)‑ként van reprezentálva (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/) és a [SmartArt](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/) elemeket) menthető bélyegképként vagy SVG‑ként.

**A rendszerben telepített betűtípusok befolyásolják a szövegformák bélyegképeinek minőségét?**

Igen. A nem kívánt fallback‑eket és a szöveg átrendeződését elkerülendő [biztosítania kell a szükséges betűtípusokat](/slides/hu/python-net/custom-font/) (vagy [beállítani a betűtípus‑helyettesítéseket](/slides/hu/python-net/font-substitution/)).