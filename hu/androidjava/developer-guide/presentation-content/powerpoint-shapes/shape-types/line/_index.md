---
title: Vonal alakzatok hozzáadása prezentációkhoz Androidon
linktitle: Vonal
type: docs
weight: 50
url: /hu/androidjava/line/
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
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet manipulálni a vonal formázását PowerPoint prezentációkban az Aspose.Slides for Android segítségével. Fedezze fel a tulajdonságokat, módszereket és Java példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programból vonal alakzatokat adjunk hozzá PowerPoint diához. Ez a cikk bemutatja, hogyan hozhatunk létre egyszerű vonalat, valamint hogyan testreszabhatjuk a vonalat, hogy nyílnaként jelenjen meg.

Megtanulja, hogyan adjon egy vonal alakzatot egy diára, hogyan állítsa be a megjelenését, és hogyan mentse el a módosított prezentációt. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, mint a stílus, szélesség, szaggatott minta, nyílfej beállítások és kitöltőszín.

## **Egyszerű vonal létrehozása**

Egy egyszerű, sima vonal hozzáadásához a prezentáció kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy Line típusú AutoShape‑ot a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódussal, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el.
- Írja a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy vonalat adtunk hozzá a prezentáció első diájához.

```java
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Adjon hozzá egy vonal típusú AutoShape-t
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Írja ki a PPTX-et a lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nyílszerű vonal létrehozása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára, hogy a vonal néhány tulajdonságát beállítva vonzóbbá tegyék. Próbáljuk meg néhány tulajdonságot konfigurálni, hogy a vonal nyílnak tűnjön. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy Line típusú AutoShape‑ot a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódussal, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el.
- Állítsa be a [Line Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineStyle) egyik elérhető stílusra.
- Állítsa be a vonal szélességét.
- Állítsa be a [Dash Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineDashStyle) egyik elérhető stílusra.
- Állítsa be a vonal kezdőpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadLength) értékét.
- Állítsa be a vonal végpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadLength) értékét.
- Írja a módosított prezentációt PPTX fájlként.

```java
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Adjon hozzá egy vonal típusú AutoShape-t
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

    // Írja ki a PPTX-et a lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Átalakíthatom a normál vonalat csatlakozóvá, hogy „ráilleszkedjen” az alakzatokra?**

Nem. Egy normál vonal (a [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) típusú [Line](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapetype/) ) nem válik automatikusan csatlakozóvá. A rajz objektumokra való illesztéshez használja a dedikált [Connector](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/connector/) típust és a [corresponding APIs](/slides/hu/androidjava/connector/)‑t a kapcsolatokhoz.

**Mi a teendő, ha egy vonal tulajdonságait a téma örökli, és nehéz meghatározni a végleges értékeket?**

Olvassa el a [effective properties](/slides/hu/androidjava/shape-effective-properties/) a [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinefillformateffectivedata/) interfészeken keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Zárolhatom a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objects](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) segítségével megakadályozhatók a szerkesztési műveletek.