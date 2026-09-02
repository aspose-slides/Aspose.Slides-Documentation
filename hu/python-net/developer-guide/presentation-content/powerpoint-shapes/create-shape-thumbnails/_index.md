---
title: Prezentációs alakzatok miniatűrök létrehozása Pythonban
linktitle: Alakzat miniatűrök
type: docs
weight: 70
url: /hu/python-net/create-shape-thumbnails/
keywords:
- alakzat miniatűr
- alakzat kép
- alakzat renderelése
- alakzat renderelés
- vizuális határok
- alakzat határok
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Készítsen magas minőségű alakzat miniatűröket PowerPoint és OpenDocument diákból az Aspose.Slides for Python via .NET segítségével – egyszerűen hozhat és exportálhat prezentációs miniatűröket."
---
## **Bevezetés**

Az Aspose.Slides for Python via .NET-et prezentációs fájlok létrehozására használják, ahol minden oldal egy dia. Ezeket a diákot megtekintheted a Microsoft PowerPointben a prezentációs fájl megnyitásával. Néha a fejlesztőknek szükségük van a formák képeinek külön megtekintésére egy képnézőben. Ilyen esetekben az Aspose.Slides képes előnézeti képeket (thumbnail) generálni a diaformák számára. Ez a cikk bemutatja, hogyan használható ez a funkció.

## **Alakzat‑miniatűrök generálása diákból**

Amikor egy adott objektum előnézetére van szükség a teljes dia helyett, egyetlen alakzat miniatűrjét is készítheted. Az Aspose.Slides lehetővé teszi bármely alakzat képként való exportálását, így könnyen létrehozhatsz könnyű előnézeteket, ikonokat vagy további feldolgozáshoz alkalmas erőforrásokat.

Alakzat‑miniatűr létrehozásához:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezz referenciát egy diára azonosítója vagy indexe alapján.
1. Szerezz referenciát a dián lévő alakzatra.
1. Rendereld az alakzat miniatűr képét.
1. Mentsd el a miniatűr képet a kívánt formátumban.

Az alábbi példa egy alakzat‑miniatűröt generál.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt a prezentációs fájl megnyitásához.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Készítsen egy képet az alapértelmezett mérettel.
    with shape.get_image() as thumbnail:
        # Mentse a képet lemezre PNG formátumban.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Alakzat‑miniatűrök létrehozása egyéni skálázási tényezővel**

Ez a szakasz bemutatja, hogyan generálj alakzat‑miniatűröket egy felhasználó által meghatározott skálázási tényezővel az Aspose.Slidesben. A skála szabályozásával finomhangolhatod a miniatűr méretét az előnézetekhez, exportokhoz vagy nagy DPI‑s kijelzőkhöz.

Alakzat‑miniatűr létrehozásához egy dián:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezz egy diát azonosítója vagy indexe alapján.
1. Szerezz célagyakra a dián.
1. Rendereld az alakzat miniatűr képét a megadott skálával.
1. Mentsd el a miniatűr képet a kívánt formátumban.

Az alábbi példa egy felhasználó által meghatározott skálázási tényezővel rendelkező miniatűröt generál.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Példányosítsa a Presentation osztályt a prezentációs fájl megnyitásához.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Készítsen egy képet a meghatározott skálával.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Mentse a képet lemezre PNG formátumban.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Alakzat‑miniatűrök létrehozása az alakzat megjelenési határaival**

Ez a szakasz azt mutatja be, hogyan generálj miniatűröket egy alakzat megjelenési határai szerint. Figyelembe veszi az összes alakzati effektust. A létrehozott miniatűr a diahatárok által korlátozott.

Alakzat‑miniatűr létrehozásához a megjelenési határokon belül:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezz egy diát azonosítója vagy indexe alapján.
1. Szerezz célagyakra a dián.
1. Rendereld az alakzat miniatűr képét a megadott határokkal.
1. Mentsd el a miniatűr képet a kívánt képformátumban.

Az alábbi példa felhasználó által meghatározott határokkal hoz létre egy miniatűröt.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Példányosítsa a Presentation osztályt a prezentációs fájl megnyitásához.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Készítsen egy megjelenési határokon belüli alakzat képet.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Mentse a képet lemezre PNG formátumban.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Alakzat tényleges vizuális határainak lekérdezése**

Egy [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) keret‑tulajdonságai – `Shape.x`, `Shape.y`, `Shape.width` és `Shape.height` – a prezentációs modellben tárolt téglalapot írják le. A ténylegesen renderelt tartalom meghaladhatja ezt a keretet, vagy egy másik, tengely‑igazított téglalapban helyezkedhet el. A forgatás, körvonalak, nyilak, szöveg‑elrendezés és túlcsordulás, a generált SmartArt geometria és egyéb renderelési hatások mind módosíthatják az elfoglalt területet.

Használd a [Shape.get_visual_bounds](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_visual_bounds/) metódust, hogy a kép létrehozása nélkül kiszámold ezt a területet. A metódus lebegőpontos téglalapot ad vissza dia‑koordinátákban. A visszaadott téglalap nincs levágva a diára, ezért koordinátái negatívak lehetnek, ha a tartalom túlnyúlik a dia origóján.

Az alábbi példa lekéri és összehasonlítja a keret‑ és a vizuális határokat:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Ugyanaz a téglalap használható a közeli alakzatok `left`, `right`, `top` vagy `bottom` élhez való igazításához; elegendő hely lefoglalásához egy generált elrendezésben; vagy a megengedett régiótól való kilógó tartalom észleléséhez. A vizuális határok különösen hasznosak SmartArt, szöveg­dobozok, nyilak, képek, forgatott alakzatok és csoportos alakzatok esetén, ahol a tárolt keret nem feltétlenül tükrözi a teljes renderelt eredményt.

Használd a [Shape.get_visual_bounds](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_visual_bounds/) metódust, ha koordinátákra van szükséged elrendezéshez vagy ellenőrzéshez, és nem kell bitmap. Használd a [Shape.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/) metódust, ha a alakzatot le kell renderelni. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapethumbnailbounds/) esetén a `ShapeThumbnailBounds.SHAPE` a kép méretét az alakzat határaiból számítja, beleértve a körvonal beállításait, míg a `ShapeThumbnailBounds.APPEARANCE` a kép méretét az alakzat megjelenéséből, és a diára korlátozza az eredményt. Ezzel szemben a `Shape.get_visual_bounds` csak a kiszámított téglalapot adja vissza, és nem vágja le a diára.

## **GYIK**

**Milyen képformátumok használhatók alakzat‑miniatűrök mentésénél?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imageformat/), és egyebek. Az alakzatok [exportálhatók vektorgrafikaként SVG‑ként](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/write_as_svg/) a tartalom SVG‑ként történő mentésével.

**Mi a különbség a SHAPE és az APPEARANCE határok között a miniatűr renderelésekor?**

A `SHAPE` az alakzat geometriáját használja; az `APPEARANCE` a [vizuális hatásokat](/slides/hu/python-net/shape-effect/) (árnyékok, ragyogások stb.) is figyelembe veszi.

**Mi történik, ha egy alakzat rejtettnek van jelölve? A miniatűr még mindig létrejön?**

A rejtett alakzat továbbra is a modell része, és renderelhető; a rejtett jelző a diavetítés megjelenésére hat, de nem akadályozza meg az alakzat képeinek létrehozását.

**Támogatottak a csoportos alakzatok, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely objektum, amely [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/)‑ként van reprezentálva (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/) és a [SmartArt](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/) elemeket) menthető miniatűrként vagy SVG‑ként.

**A rendszerben telepített betűtípusok befolyásolják a szöveg‑alakzatok miniatűrök minőségét?**

Igen. **Biztosítsa a szükséges betűtípusokat**[/slides/hu/python-net/custom-font/] (vagy **konfigurálja a betűtípus helyettesítéseket**[/slides/hu/python-net/font-substitution/]), hogy elkerülje a nem kívánt helyettesítéseket és a szöveg átrendeződését.