---
title: Ellipszisek hozzáadása prezentációkhoz JavaScript-ben
linktitle: Ellipszis
type: docs
weight: 30
url: /hu/nodejs-java/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, formázhat és manipulálhat ellipszis alakzatokat az Aspose.Slides for Node.js segítségével PPT és PPTX prezentációkban – JavaScript kódrészletek is szerepelnek."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk ellipszis alakzatokat a PowerPoint diához az Aspose.Slides használatával. Leírja egy egyszerű ellipszis létrehozását, egy formázott ellipszis létrehozását, és a frissített prezentáció PPTX fájlként történő mentését. Emellett érint kapcsolódó kérdéseket, mint az ellipszis pozíciójának és méretének kezelése, a rétegzési sorrend szabályozása, valamint animációs hatások alkalmazása.

## **Ellipszis létrehozása**
Egy egyszerű ellipszis hozzáadásához a prezentáció egy kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy Ellipse típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) metódus segítségével, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon keresztül érhető el.
- Írja ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy ellipszist adtunk hozzá az első diához

```javascript
// Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
var pres = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát
    var sld = pres.getSlides().get_Item(0);
    // Adjon hozzá egy ellipszis típusú AutoShape-et
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Írja ki a PPTX fájlt a lemezre
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Formázott ellipszis létrehozása**
Egy jobban formázott ellipszis hozzáadásához egy diára kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy Ellipse típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) metódus segítségével, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon keresztül érhető el.
- Állítsa be az ellipszis kitöltést Solid típusra.
- Állítsa be az ellipszis színét a SolidFillColor.Color tulajdonság segítségével, amely a [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FillFormat) objektumon keresztül érhető el, és a [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Shape) objektumhoz tartozik.
- Állítsa be az ellipszis vonalainak színét.
- Állítsa be az ellipszis vonalainak szélességét.
- Írja ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy formázott ellipszist adtunk hozzá a prezentáció első diájához.

```javascript
// Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
var pres = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát
    var sld = pres.getSlides().get_Item(0);
    // Adjon hozzá egy ellipszis típusú AutoShape-et
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Alkalmazzon némi formázást az ellipszis alakzatra
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Alkalmazzon némi formázást az ellipszis vonalára
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Írja ki a PPTX fájlt a lemezre
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **GYIK**

**Hogyan állíthatom be egy ellipszis pontos pozícióját és méretét a dia egységeihez viszonyítva?**

A koordinátákat és méreteket általában **pontban** adják meg. A kiszámítható eredmények érdekében alapozza a számításait a dia méretére, és a szükséges millimétereket vagy hüvelyket konvertálja pontokra, mielőtt értékeket adna meg.

**Hogyan helyezhetem el egy ellipszist más objektumok fölé vagy alá (rétegző sorrend szabályozása)?**

Állítsa be az objektum rajzolási sorrendjét úgy, hogy előre hozza vagy hátra küldje. Ez lehetővé teszi, hogy az ellipszis átfedje a többi objektumot, vagy feltárja az alatta lévőket.

**Hogyan animálhatom egy ellipszis megjelenését vagy hangsúlyozását?**

[Apply](/slides/hu/nodejs-java/shape-animation/) belépési, hangsúlyos vagy kilépési hatásokat az alakzatra, és konfigurálja a kiváltókat és az időzítést, hogy meghatározza, mikor és hogyan játssza le az animációt.