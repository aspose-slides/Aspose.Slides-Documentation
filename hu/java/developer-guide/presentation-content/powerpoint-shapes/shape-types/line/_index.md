---
title: Vonal alakzatok hozzáadása a prezentációkhoz Java-ban
linktitle: Vonal
type: docs
weight: 50
url: /hu/java/Line/
keywords:
- vonal
- vonal létrehozása
- vonal hozzáadása
- egyszerű vonal
- vonal konfigurálása
- vonal testreszabása
- szaggatott stílus
- nyílfej
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a vonalformázást PowerPoint prezentációkban az Aspose.Slides for Java segítségével. Fedezze fel a tulajdonságokat, metódusokat és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan vonal alakzatokat adjunk hozzá a PowerPoint diákhoz. Ez a cikk bemutatja, hogyan hozhatunk létre egyszerű vonalat, és hogyan testreszabhatjuk a vonalat, hogy nyílként jelenjen meg.

Megtanulja, hogyan adjon hozzá vonal alakzatot egy diára, állítsa be a megjelenését, és mentse el a frissített bemutatót. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, mint a stílus, szélesség, szaggatott minta, nyílfej beállítások és a kitöltőszín.

## **Egyszerű vonal létrehozása**

Egyszerű egyenes vonal hozzáadásához a bemutató kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon hozzá egy Line típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódussal, amelyet az [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Írja ki a módosított bemutatót PPTX fájlként.

Az alábbi példában egy vonalat adtunk hozzá a bemutató első diájához.

```java
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Az első diát lekéri
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Adjunk hozzá egy vonal típusú AutoShape-et
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Írja a PPTX fájlt a lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nyíllal rendelkező vonal létrehozása**

Az Aspose.Slides for Java is lehetővé teszi a fejlesztők számára, hogy néhány vonal tulajdonságát úgy állítsák be, hogy vonzóbb legyen. Próbáljuk meg beállítani néhány vonal tulajdonságát, hogy nyílnak látszanak. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon hozzá egy Line típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódussal, amelyet az [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Állítsa be a [Line Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineStyle) egyet az Aspose.Slides for Java által kínált stílusok közül.
- Állítsa be a vonal szélességét.
- Állítsa be a vonal [Dash Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineDashStyle) egyet az Aspose.Slides for Java által kínált stílusok közül.
- Állítsa be a vonal kezdő pontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadLength) értékét.
- Állítsa be a vonal végpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadLength) értékét.
- Írja ki a módosított bemutatót PPTX fájlként.

```java
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Az első diát lekéri
    ISlide sld = pres.getSlides().get_Item(0);

    // Adjunk hozzá egy vonal típusú AutoShape-et
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Alkalmazzon némi formázást a vonalon
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Írja a PPTX fájlt a lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Átalakíthatom a szokásos vonalat csatlakozóvá, hogy "rögzítse" a alakzatokhoz?**

Nem. Egy szokásos vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) típusú [Line](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapetype/)) nem válik automatikusan csatlakozóvá. Ahhoz, hogy rögzítse az alakzatokhoz, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/java/com.aspose.slides/connector/) típust és a [corresponding APIs](/slides/hu/java/connector/) csatlakozásokhoz.

**Mit tegyek, ha egy vonal tulajdonságai a témából örököltek, és nehéz meghatározni a végső értékeket?**

Olvassa el az [Olvassa el a tényleges tulajdonságokat](/slides/hu/java/shape-effective-properties/) a [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinefillformateffectivedata/) interfészeken keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusát.

**Zárolhatom a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objects](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/#getAutoShapeLock--) objektumot biztosítanak, amelyek lehetővé teszik a [disallow editing operations](/slides/hu/java/applying-protection-to-presentation/) tiltását.