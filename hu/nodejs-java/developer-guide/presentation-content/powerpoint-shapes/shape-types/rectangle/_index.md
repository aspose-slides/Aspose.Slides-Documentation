---
title: Téglalapok hozzáadása prezentációkhoz JavaScript-ben
linktitle: Téglalap
type: docs
weight: 80
url: /hu/nodejs-java/rectangle/
keywords:
- téglalap hozzáadása
- téglalap létrehozása
- téglalap alak
- egyszerű téglalap
- formázott téglalap
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Növeld PowerPoint prezentációidat téglalapok hozzáadásával JavaScript és a Node.js-hez készült Aspose.Slides segítségével – könnyedén tervezhetsz és módosíthatsz alakzatokat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet téglalap alakzatokat hozzáadni a PowerPoint diához az Aspose.Slides segítségével. Lefedi egy egyszerű téglalap létrehozását, egy formázott téglalap létrehozását és a frissített bemutató PPTX fájlként való mentését.

Meg fogja látni, hogyan kell alapvető téglalap formázást alkalmazni, például egyszínű kitöltést, vonal színt és vonalvastagságot. Továbbá a cikk GYIK-ja kapcsolódó téglalap feladatokra mutat, többek között lekerekített sarkokra, képes kitöltésekre, vizuális hatásokra, hiperhivatkozásokra, alakzat zárolásra, exportálási lehetőségekre és hatékony tulajdonságokra. 

## **Téglalap hozzáadása diára**

Az előző témákhoz hasonlóan ez is egy alakzat hozzáadásáról szól, és ezúttal a Rectangle (téglalap) alakzatról lesz szó. Ebben a témában leírtuk, hogyan adhatnak fejlesztők egyszerű vagy formázott téglalapokat a diáikhoz az Aspose.Slides használatával. 

Egy egyszerű téglalap hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
- Szerezze meg egy dia referenciáját az Index használatával.  
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) Rectangle típusú elemet a [addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon érhető el.  
- Írja a módosított bemutatót PPTX fájlként.  

Az alábbi példában egy egyszerű téglalapot adtunk hozzá a prezentáció első diájához.

```javascript
// Példányosítsa a PPTX-et képviselő Presentation osztályt
var pres = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát
    var sld = pres.getSlides().get_Item(0);
    // Ellipszis típusú AutoShape hozzáadása
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Írja a PPTX fájlt a lemezre
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Formázott téglalap hozzáadása diára**
Egy formázott téglalap hozzáadásához a diához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
- Szerezze meg egy dia referenciáját az Index használatával.  
- Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/AutoShape) Rectangle típusú elemet a [addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) metódussal, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon érhető el.  
- Állítsa be a téglalap [Fill Type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FillType) értékét Solid-ra.  
- Állítsa be a téglalap színét a [SolidFillColor.setColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) metódussal, amely a [FillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FillFormat) objektumon keresztül érhető el.  
- Állítsa be a téglalap vonalainak színét.  
- Állítsa be a téglalap vonalainak vastagságát.  
- Írja a módosított bemutatót PPTX fájlként.  

A fenti lépések a lenti példában vannak megvalósítva.

```javascript
// Példányosítsa a PPTX-et képviselő Presentation osztályt
var pres = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát
    var sld = pres.getSlides().get_Item(0);
    // Ellipszis típusú AutoShape hozzáadása
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Alkalmazzon némi formázást az ellipszis alakzatra
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Alkalmazzon némi formázást az ellipszis vonalára
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Írja a PPTX fájlt a lemezre
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Hogyan adhatok hozzá egy lekerekített sarkú téglalapot?**  
Használja a lekerekített sarkú [shape type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapetype/) típust, és állítsa be a sarkok sugarát az alakzat tulajdonságaiban; a lekerekítés minden sarokhoz külön is alkalmazható geometriai módosításokkal.

**Hogyan tölthetek ki egy téglalapot képpel (textúrával)?**  
Válassza ki a kép [fill type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) lehetőségét, adja meg a képfájlt, és konfigurálja a [stretching/tiling modes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillmode/) beállításait.

**Lehet-e a téglalapnak árnyéka és ragyogása?**  
Igen. A [Outer/inner shadow, glow, and soft edges](/slides/hu/nodejs-java/shape-effect/) elérhető, a paraméterek pedig állíthatók.

**Átalakíthatom-e a téglalapot gombbal és hiperhivatkozással?**  
Igen. [Assign a hyperlink](/slides/hu/nodejs-java/manage-hyperlinks/) a forma klikkjéhez (ugrás egy diára, fájlra, webcímre vagy e‑mailre).

**Hogyan védhetem meg a téglalapot a mozgatástól és a módosítástól?**  
Használjon formazárolásokat: tilthatja a mozgatást, átméretezést, kiválasztást vagy a szövegszerkesztést, hogy megőrizze a elrendezést.

**Átkonvertálhatom-e a téglalapot raszteres képpé vagy SVG‑vé?**  
Igen. A [render the shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage) metódussal képet hozhat létre megadott mérettel/skálával, vagy [export it as SVG](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) formátumban vektoros használatra.

**Hogyan szerezhetem meg gyorsan egy téglalap tényleges (hatékony) tulajdonságait a téma és öröklődés figyelembevételével?**  
[Use the shape’s effective properties](/slides/hu/nodejs-java/shape-effective-properties/): az API kiszámított értékeket ad vissza, amelyek figyelembe veszik a téma stílusait, a layoutot és a helyi beállításokat, ezáltal leegyszerűsítve a formázási elemzést.