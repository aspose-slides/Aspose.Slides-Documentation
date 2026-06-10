---
title: Vonal alakzatok hozzáadása a bemutatókhoz JavaScript-ben
linktitle: Vonal
type: docs
weight: 50
url: /hu/nodejs-java/line/
keywords:
- vonal
- vonal létrehozása
- vonal hozzáadása
- egyszerű vonal
- vonal beállítása
- vonal testreszabása
- vonalstílus
- nyílfej
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan manipulálhatja a vonalformázást PowerPoint bemutatókban JavaScript és a Node.js-hez készült Aspose.Slides segítségével. Fedezze fel a tulajdonságokat, metódusokat és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi vonal alakzatok programozott hozzáadását PowerPoint diákhoz. Ez a cikk bemutatja, hogyan hozhatunk létre egyszerű vonalat, és hogyan állíthatjuk be a vonalat, hogy nyílnaként jelenjen meg.

Megtanulja, hogyan adjon vonal alakzatot egy diára, állítsa be a vizuális megjelenését, és mentse el a frissített bemutatót. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, mint például a stílus, szélesség, vonalminta, nyílfej beállítások és kitöltőszín.

## **Egyszerű vonal létrehozása**

Egy egyszerű, sima vonal hozzáadásához a bemutató kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia hivatkozását az Indexe alapján.
- Adjon hozzá egy Line típusú AutoShape‑t a [addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) metódussal a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon keresztül.
- Írja ki a módosított bemutatót PPTX fájlként.

Az alább látható példában egy vonalat adtunk hozzá a bemutató első diájához.

```javascript
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
var pres = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát
    var sld = pres.getSlides().get_Item(0);
    // Adjon hozzá egy vonal típusú AutoShape-et
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Írja a PPTX fájlt a lemezre
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nyíl alakú vonal létrehozása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy a vonal néhány tulajdonságát úgy állítsák be, hogy vonzóbb legyen. Próbáljunk meg néhány tulajdonságot konfigurálni, hogy a vonal nyílnak tűnjön. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
- Szerezze meg a dia hivatkozását az Indexe alapján.
- Adjon hozzá egy Line típusú AutoShape‑t a [addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) metódussal a [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeCollection) objektumon keresztül.
- Állítsa be a [Line Style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LineStyle) egyik elérhető stílusra.
- Állítsa be a vonal szélességét.
- Állítsa be a vonal [Dash Style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LineDashStyle) egyik elérhető mintájára.
- Állítsa be a vonal kezdőpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LineArrowheadLength) beállításait.
- Állítsa be a vonal végpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/LineArrowheadLength) beállításait.
- Írja ki a módosított bemutatót PPTX fájlként.

```javascript
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
var pres = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát
    var sld = pres.getSlides().get_Item(0);
    // Adjon hozzá egy vonal típusú AutoShape-et
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Alkalmazzon némi formázást a vonalon
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Írja a PPTX fájlt a lemezre
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Átalakíthatom-e a normál vonalat kapcsolóvá, hogy „ráilleszkedjen” az alakzatokra?**

Nem. Egy normál vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) a [Line](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapetype/) típussal) nem válik automatikusan kapcsolóvá. Ahhoz, hogy ráilleszkedjen az alakzatokra, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/) típust és a [megfelelő API‑kat](/slides/hu/nodejs-java/connector/) a kapcsolatokhoz.

**Mit tehetek, ha egy vonal tulajdonságait a téma örökli, és nehéz meghatározni a végső értékeket?**

Olvassa el a [hatékony tulajdonságokat](/slides/hu/nodejs-java/shape-effective-properties/) a `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` osztályokon keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Lezárhatom-e a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objektumokat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/getautoshapelock/) biztosítanak, amelyekkel megtilthatók a szerkesztési műveletek.