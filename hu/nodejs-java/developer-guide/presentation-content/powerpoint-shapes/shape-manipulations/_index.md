---
title: Prezentációs alakzatok kezelése JavaScript-ben
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/nodejs-java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat azonosító lekérése
- alakzat alternatív szövege
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg alakzatok létrehozását, szerkesztését és optimalizálását JavaScript és az Aspose.Slides for Node.js via Java segítségével, és készítsen nagy teljesítményű PowerPoint prezentációkat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk alakzatokkal a prezentációkban az Aspose.Slides segítségével. Megmutatja, hogyan találhatunk egy alakzatot egy dián, klónozhatjuk, eltávolíthatjuk, elrejthetjük, módosíthatjuk a sorrendjét, lekérhetjük az Interop alakzat azonosítóját, és beállíthatjuk a helyettesítő szöveget a beazonosításhoz és a további feldolgozáshoz.

Továbbá lefedi, hogyan érhetjük el az elrendezési formátumokat az alakzatokhoz, hogyan renderelhetünk egy alakzatot SVG-ként, hogyan igazíthatjuk az alakzatokat egy dián, és hogyan használhatjuk a flip tulajdonságokat vízszintes és függőleges tükrözéshez. Emellett a cikk tartalmaz egy rövid GYIK-et az alakzat kombinálásáról, a rétegsorrendről és az alakzat zárolásáról.

## **Alakzat keresése a dián**
Ez a téma egy egyszerű technikát mutat be, amely megkönnyíti a fejlesztők számára egy konkrét alakzat megtalálását a dián anélkül, hogy annak belső azonosítóját használnák. Fontos tudni, hogy a PowerPoint prezentációs fájlok nem rendelkeznek más módon az alakzatok azonosítására a dián, csak egy belső egyedi azonosítóval. A fejlesztőknek nehézséget jelent, ha a belső egyedi azonosítóval próbálnak egy alakzatot megtalálni. Minden diára hozzáadott alakzat rendelkezik valamilyen alternatív szöveggel. Javasoljuk, hogy a fejlesztők alternatív szöveget használjanak egy konkrét alakzat megtalálásához. A Microsoft PowerPointben definiálhatja az objektumok alternatív szövegét, amelyet a későbbiekben módosítani szeretne.

Miután beállította a kívánt alakzat alternatív szövegét, megnyithatja a prezentációt az Aspose.Slides for Node.js via Java segítségével, és végigiterálhat az összes diára hozzáadott alakzaton. Minden iteráció során ellenőrizheti az alakzat alternatív szövegét, és a megfelelő alternatív szöveggel rendelkező alakzat lesz az Ön által keresett. Ennek a technikának a jobb bemutatására létrehoztunk egy [findShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) nevű módszert, amely megoldja a konkrét alakzat megtalálását egy dián, és egyszerűen visszaadja azt az alakzatot.

```javascript
// Példányosít egy Presentation osztályt, amely a prezentáció fájlt képviseli
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // A megtalálandó alakzat alternatív szövege
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Alakzat klónozása**
Alakzat klónozásához egy diára az Aspose.Slides for Node.js via Java segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Szerezze be egy dia referenciáját az indexe alapján.
1. Hozzáférjen a forrásdia alakzatgyűjteményéhez.
1. Adjon hozzá egy új diát a prezentációhoz.
1. Klónozza az alakzatokat a forrásdia alakzatgyűjteményéből az új diára.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példa egy csoportos alakzatot ad egy diához.

```javascript
// Presentation osztály példányosítása
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // A PPTX fájl mentése lemezre
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alakzat eltávolítása**
Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy bármelyik alakzatot eltávolítsák. Az alakzat bármely diáról történő eltávolításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozzáférjen az első diához.
1. Keresse meg a specifikus AlternativeText tulajdonsággal rendelkező alakzatot.
1. Távolítsa el az alakzatot.
1. Mentse a fájlt lemezre.

```javascript
// Prezentáció objektum létrehozása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia lekérése
    var sld = pres.getSlides().get_Item(0);
    // Téglalap típusú automatikus alakzat hozzáadása
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Prezentáció mentése lemezre
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alakzat elrejtése**
Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy bármelyik alakzatot elrejtsék. Az alakzat egy diáról történő elrejtéséhez kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozzáférjen az első diához.
1. Keresse meg a specifikus AlternativeText tulajdonsággal rendelkező alakzatot.
1. Rejtse el az alakzatot.
1. Mentse a fájlt lemezre.

```javascript
// Presentation osztály példányosítása, amely a PPTX-et képviseli
var pres = new aspose.slides.Presentation();
try {
    // Az első dia lekérése
    var sld = pres.getSlides().get_Item(0);
    // Téglalap típusú automatikus alakzat hozzáadása
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Prezentáció mentése lemezre
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alakzatok sorrendjének módosítása**
Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára az alakzatok újrarendezését. Az újrarendezés meghatározza, melyik alakzat van elöl vagy hátul. Az alakzat bármely dián történő újrarendezéséhez kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozzáférjen az első diához.
1. Adjon hozzá egy alakzatot.
1. Helyezzen el némi szöveget az alakzat szövegdobozában.
1. Adjon hozzá egy másik alakzatot ugyanazzal a koordinátával.
1. Rendezzük át az alakzatokat.
1. Mentse a fájlt lemezre.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Interop alakzat ID lekérése**
Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy egyedi alakzat-azonosítót kapjanak a dia szintjén, szemben a [getUniqueId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getUniqueId--) metódussal, amely a prezentáció szintjén ad egyedi azonosítót. A [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) metódus a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape) osztályba került. Az [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) metódus által visszaadott érték megfelel a Microsoft.Office.Interop.PowerPoint.Shape objektum Id értékének. Az alábbiakban egy példa kód látható.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Egyedi alakzat-azonosító lekérése a diában
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alternatív szöveg beállítása az alakzathoz**
Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy bármely alakzat AlternateText értékét beállítsák.
A prezentációban az alakzatokat megkülönböztethetjük a [AlternativeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) vagy a [Shape Name](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) metódussal.
A [setAlternativeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) és a [getAlternativeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#getAlternativeText--) metódusokkal olvashatunk vagy írhatunk a Aspose.Slides vagy a Microsoft PowerPoint segítségével.
Ezzel a módszerrel címkézhet egy alakzatot, és különböző műveleteket végezhet, például alakzat eltávolítása,
alakzat elrejtése vagy alakzatok újrarendezése a dián.
Az AlternateText beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
1. Hozzáférjen az első diához.
1. Adjon hozzá bármilyen alakzatot a diához.
1. Végezzen el némi munkát az újonnan hozzáadott alakzattal.
1. Traversálja végig az alakzatokat egy alakzat megtalálásához.
1. Állítsa be az AlternativeText-et.
1. Mentse a fájlt lemezre.

```javascript
// Presentation osztály példányosítása, amely a PPTX-et képviseli
var pres = new aspose.slides.Presentation();
try {
    // Az első dia lekérése
    var sld = pres.getSlides().get_Item(0);
    // Téglalap típusú automatikus alakzat hozzáadása
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Prezentáció mentése lemezre
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Elrendezési formátumok elérése az alakzathoz**
Az Aspose.Slides for Node.js via Java egyszerű API-t biztosít az alakzat elrendezési formátumainak eléréséhez. Ez a cikk bemutatja, hogyan érheti el az elrendezési formátumokat.

Az alábbi példa kód látható.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alakzat renderelése SVG-ként**
Az Aspose.Slides for Node.js via Java most már támogatja egy alakzat SVG-ként történő renderelését. A [writeAsSvg](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (és annak overloadja) metódus a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape) osztályba került. Ez a metódus lehetővé teszi, hogy az alakzat tartalmát SVG fájlként mentse. Az alábbi kódrészlet bemutatja, hogyan exportálhatjuk egy dia alakzatát SVG-fájlba.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alakzatok igazítása**
Az Aspose.Slides lehetővé teszi az alakzatok igazítását a dia margóival vagy egymással szemben. Ehhez hozzáadtuk a túlterhelt [SlidesUtil.alignShape()](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) metódust. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapesAlignmentType) felsorolás határozza meg a lehetséges igazítási lehetőségeket.

**Példa 1**

Az alábbi forráskód a 1., 2. és 4. indexű alakzatokat igazítja a dia felső szélén.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Példa 2**

Az alábbi példa azt mutatja be, hogyan igazítható a teljes alakzategyüttes a gyűjtemény legalsó alakzatához képest.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Flip tulajdonságok**

Az Aspose.Slides-ben a [ShapeFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapeframe/) osztály lehetővé teszi a vízszintes és függőleges tükrözést a `flipH` és `flipV` tulajdonságokkal. Mindkét tulajdonság `byte` típusú, ahol az `1` érték tükrözést, a `0` érték nem tükrözést, a `-1` az alapértelmezett viselkedést jelenti. Ezek az értékek egy alakzat [Frame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getFrame)-ből érhetők el.

A flip beállítások módosításához egy új [ShapeFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapeframe/) példányt hozunk létre a forma aktuális pozíciójával és méretével, a kívánt `flipH` és `flipV` értékekkel, valamint a forgási szöggel. Ennek a példánynak a forma [Frame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getFrame)-hez való hozzárendelése és a prezentáció mentése alkalmazza a tükrözési transzformációkat és elmenti őket a kimeneti fájlba.

Tegyük fel, hogy van egy sample.pptx fájlunk, amelynek az első diáján egyetlen alakzat van az alapértelmezett flip beállításokkal, ahogy alább látható.

![The shape to be flipped](shape_to_be_flipped.png)

Az alábbi kódrészlet lekéri az alakzat jelenlegi flip tulajdonságait, és mindkét irányban tükrözi azt.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // A forma vízszintes tükrözési tulajdonságának lekérése.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // A forma függőleges tükrözési tulajdonságának lekérése.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Vízszintesen tükröz.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Függőlegesen tükröz.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The flipped shape](flipped_shape.png)

## **GYIK**

**Összevonhatok-e alakzatokat (unió/metszés/kivonás) egy dián, ahogy egy asztali szerkesztőben?**

Nincs beépített logikai művelet API. Megközelítheti úgy, hogy magát a kívánt körvonalat építi fel – például kiszámítja a végső geometriát a [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/geometrypath/) segítségével, és egy új alakzatot hoz létre ezzel a körvonallal, opcionálisan eltávolítva az eredetit.

**Hogyan szabályozhatom a rétegsorrendet (z-sorrendet), hogy egy alakzat mindig "felül" maradjon?**

Módosítsa a beszúrási/áthelyezési sorrendet a dia [shapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getShapes) gyűjteményében. A kiszámítható eredmények érdekében a z-sorrendet a többi dia módosítása után véglegesítse.

**Lehet-e "zárolni" egy alakzatot, hogy a PowerPoint felhasználók ne szerkeszthessék?**

Igen. Állítson be alakzatszintű védelmi zászlókat (például kiválasztás, mozgatás, átméretezés, szövegszerkesztés zárolása). Szükség esetén tükrözze a korlátozásokat a mester vagy az elrendezés szintjén. Vegye figyelembe, hogy ez UI-szintű védelem, nem biztonsági funkció; erősebb védelemhez kombinálja fájlszintű korlátozásokkal, például [csak olvasható ajánlásokkal vagy jelszavakkal](/slides/hu/nodejs-java/password-protected-presentation/).