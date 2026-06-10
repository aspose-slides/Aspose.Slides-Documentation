---
title: Alakzatok kezelése prezentációkban Python használatával
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/python-net/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentáció alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat azonosító lekérése
- alakzat alternatív szövege
- alakzat elrendezési formátumok
- alakzat SVG formátumban
- alakzat SVG-be
- alakzat igazítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, szerkeszthet és optimalizálhat alakzatokat az Aspose.Slides for Python via .NET segítségével, és szállíthat nagy teljesítményű PowerPoint és OpenDocument prezentációkat."
---
## **Áttekintés**

Ez az útmutató bemutatja az alakzatkezelést az Aspose.Slides for Python via .NET környezetben. Ismerjen meg gyakorlati mintákat az alakzatok megtalálásához (beleértve az Alternatív Szöveg alapján is), másoláshoz, törléshez vagy elrejtéshez, újrarendezéshez, igazításhoz és tükrözéshez, az azonosítók és elrendezés‑alapú formázás olvasásához, valamint az egyedi alakzatok SVG‑be exportálásához a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) és a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) API‑k segítségével.

## **Alakzatok keresése diákon**

A PowerPoint csak belső azonosítók alapján ismeri fel az alakzatokat. Adjunk egyedi Alternatív Szöveget a célnak megfelelő alakzathoz a PowerPointban, majd nyissuk meg a prezentációt az Aspose.Slides for Python segítségével, iteráljunk a diák alakzatai között, és válasszuk ki azt, amelynek Alternatív Szövege egyezik. A `find_shape` metódus ezt a megközelítést valósítja meg, és visszaadja a megfelelő alakzatot.

```py
import aspose.slides as slides

# Alakzat keresése egy dián az alternatív szövege alapján.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


    # Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
        # Keresse meg az "Shape1" Alternatív Szöveggel rendelkező alakzatot.
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Alakzatok klónozása**

Az alakzatok egy forrásdiáról egy új diára történő klónozásához az Aspose.Slides‑ban kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot a forrásfájlból.
1. Szerezze meg a forrásdiát index alapján, és annak alakzatgyűjteményét.
1. Hozzon elő egy üres elrendezést a mesterdiáról.
1. Adjon hozzá egy üres diát az elrendezés felhasználásával, és szerezze meg annak alakzatait.
1. Klónozza az alakzatokat a céldiára.
1. Mentse a prezentációt PPTX formátumban.

Az alábbi kódrészlet bemutatja az alakzatok egy diáról a másikra történő klónozását.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Mentse a prezentációt a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alakzatok eltávolítása**

Az Aspose.Slides lehetővé teszi bármely alakzat eltávolítását a diáról. Például az első dián található alakzat Alternatív Szöveg alapján történő törléséhez kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és töltse be a fájlt.
1. Szerezze meg az első diát a diák gyűjteményéből.
1. Keresse meg az alakzatot az Alternatív Szöveg értéke alapján.
1. Távolítsa el az alakzatot a dia alakzatgyűjteményéből.
1. Mentse a prezentációt PPTX formátumban a lemezre.

```py
import aspose.slides as slides

# Alakzat keresése egy dián az alternatív szövege alapján.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Keresse meg az "User Defined" Alternatív Szöveggel rendelkező alakzatot.
    shape = find_shape(slide, "User Defined")
    # Távolítsa el az alakzatot.
    slide.shapes.remove(shape)
    # Mentse a prezentációt a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alakzatok elrejtése**

Az Aspose.Slides lehetővé teszi bármely alakzat elrejtését a dián. Például az első dián lévő alakzat Alternatív Szöveg alapján történő elrejtéséhez kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és töltse be a fájlt.
1. Szerezze meg az első diát a diák gyűjteményéből.
1. Keresse meg az alakzatot az Alternatív Szöveg értéke alapján.
1. Rejtse el az alakzatot.
1. Mentse a prezentációt PPTX formátumban a lemezre.

```py
# Alakzat keresése egy dián az alternatív szövege alapján.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Keresse meg az "User Defined" Alternatív Szöveggel rendelkező alakzatot.
    shape = find_shape(slide, "User Defined")
    # Rejtse el az alakzatot.
    shape.hidden = True
    # Mentse a prezentációt a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Alakzatok sorrendjének módosítása**

Az Aspose.Slides lehetővé teszi a fejlesztők számára az alakzatok újrarendezését (z‑rend módosítása). Az újrarendezés határozza meg, hogy melyik alakzat jelenik meg elöl vagy mögötte. Például két alakzat első dián való újrarendezéséhez kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
1. Szerezze meg az első diát.
1. Adjon hozzá egy első alakzatot (például egy téglalapot).
1. Adjon hozzá egy második alakzatot (például egy háromszöget).
1. Rendezzze át az alakzatokat úgy, hogy a második alakzatot helyezze az első helyre a gyűjteményben.
1. Mentse a prezentációt a lemezre.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Két alakzat hozzáadása a diához.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # A második alakzat áthelyezése az első pozícióba.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Interop alakzat‑azonosító lekérése**

Az Aspose.Slides lehetővé teszi egy alakzat egyedi azonosítójának lekérdezését a dia szintjén, ellentétben a `unique_id` tulajdonsággal, amely a teljes prezentáción belül egyedi. Az `office_interop_shape_id` tulajdonság a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályon érhető el. Értéke megegyezik a `Microsoft.Office.Interop.PowerPoint.Shape` objektum `Id` értékével. Az alábbiakban egy mintakód látható.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Szerezze meg az alakzat egyedi azonosítóját a dián.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Alternatív Szöveg beállítása alakzatokhoz**

Az Aspose.Slides lehetővé teszi a fejlesztők számára, hogy alternatív szöveget állítsanak be bármelyik alakzathoz. Az alternatív szöveg használható az alakzatok azonosítására és megtalálására egy prezentációban. Az alternatív szöveg tulajdonság olvasható és írható mind az Aspose.Slides, mind a Microsoft PowerPoint segítségével. Az alakzatok ezzel a tulajdonsággal való megcímkézése után később eltávolíthatók, elrejthetők vagy újrarendezhetők a dián.

Az alternatív szöveg beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
1. Szerezze meg az első diát.
1. Adjon hozzá egy alakzatot a diához.
1. Állítsa be az alternatív szöveget.
1. Mentse a prezentációt a lemezre.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Alakzat hozzáadása.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Állítsa be az alakzat alternatív szövegét.
    shape.alternative_text = "User Defined"
    # Mentse a prezentációt a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Elrendezés‑formátumok elérése alakzatokhoz**

Az Aspose.Slides egyszerű API‑t biztosít az alakzatok elrendezés‑formátumainak eléréséhez. Ez a szakasz bemutatja, hogyan férhet hozzá az elrendezés‑formátumokhoz.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Alakzatok renderelése SVG‑ként**

Az Aspose.Slides támogatja az alakzatok SVG‑ként történő renderelését. A [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztály `write_as_svg` metódusa (és túlterhelései) lehetővé teszik egy alakzat tartalmának SVG‑képként történő mentését. Az alábbi kódrészlet bemutatja, hogyan exportálhatunk egy alakzatot SVG fájlba.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Szerezze meg az első dián az első alakzatot.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Alakzat igazítása**

A [SlidesUtil](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/) osztály `align_shape` metódusával a következőket teheti:

* Alakzatok igazítása a dia margóira vonatkozóan (lásd 1. példa).
* Alakzatok egymáshoz viszonyított igazítása (lásd 2. példa).

A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapesalignmenttype/) felsorolás határozza meg a rendelkezésre álló igazítási lehetőségeket.

**Példa 1**

Ez a Python‑kód bemutatja, hogyan igazíthatók az 1, 2 és 4 indexű alakzatok a dia felső szélétől:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Példa 2**

Ez a Python‑példa azt mutatja, hogyan igazíthatók a gyűjtemény összes alakzata a legalsó alakzathoz képest:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Tükrözési tulajdonságok**

Az Aspose.Slides [ShapeFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapeframe/) osztálya lehetővé teszi a horizontális és vertikális tükrözés vezérlését az `flip_h` és `flip_v` tulajdonságokon keresztül. Mindkét tulajdonság a [NullableBool](https://reference.aspose.com/slides/hu/python-net/aspose.slides/nullablebool/) típusú, ami `TRUE` értékkel tükrözést jelez, `FALSE`‑zal nincs tükrözés, vagy `NOT_DEFINED`‑dal az alapértelmezett viselkedés alkalmazandó. Ezek az értékek a forma [Frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/frame/) objektumából érhetők el.

A tükrözési beállítások módosításához egy új [ShapeFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapeframe/) példányt hozunk létre a forma aktuális pozíciójával és méretével, a kívánt `flip_h` és `flip_v` értékekkel, valamint a forgatás szögével. Ennek az instance-nak a forma [Frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/frame/) tulajdonságához rendelése és a prezentáció mentése alkalmazza a tükrözési transzformációkat és rögzíti azokat a kimeneti fájlban.

Tegyük fel, hogy van egy sample.pptx fájlunk, amelynek első diája egyetlen, alapértelmezett tükrözési beállításokkal rendelkező alakzatot tartalmaz, ahogy az alább látható.

![The shape to be flipped](shape_to_be_flipped.png)

Az alábbi kódrészlet lekéri a forma aktuális tükrözési tulajdonságait, és mindkét irányban tükrözi azt.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # A forma vízszintes tükrözési tulajdonságának lekérése.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # A forma függőleges tükrözési tulajdonságának lekérése.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Vízszintesen és függőlegesen tükröz.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The flipped shape](flipped_shape.png)

## **GYIK**

**Összevonhatok (union/intersect/subtract) alakzatokat a dián, mint egy asztali szerkesztőben?**

Nincs beépített Boolean művelet API. Készíthet saját kontúrt, például a [GeometryPath](https://reference.aspose.com/slides/hu/python-net/aspose.slides/geometrypath/) segítségével számolt geometriát felhasználva, majd egy új alakzatot hoz létre ezzel a körvonallal, opcionálisan eltávolítva az eredetieket.

**Hogyan szabályozhatom a rétegsorrendet (z‑order), hogy egy alakzat mindig „felül” maradjon?**

Módosítsa a beszúrási/mozgatási sorrendet a dia [shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/shapes/) gyűjteményében. A kiszámítható eredmény érdekében a z‑rend beállítását a többi dia módosítása után végezze el.

**Lehet‑e „lezárni” egy alakzatot, hogy a PowerPoint felhasználók ne szerkeszthessék?**

Igen. Állítson be [shape‑level protection flags](/slides/hu/python-net/applying-protection-to-presentation/) (például kiválasztás, mozgatás, átméretezés, szövegszerkesztés zárolása). Szükség esetén a mester vagy elrendezés szintjén is tükrözze a korlátozásokat. Ez UI‑szintű védelem, nem biztonsági funkció; erősebb védelemhez kombinálja fájlszintű korlátozásokkal, mint a [read‑only ajánlások vagy jelszavak](/slides/hu/python-net/password-protected-presentation/).