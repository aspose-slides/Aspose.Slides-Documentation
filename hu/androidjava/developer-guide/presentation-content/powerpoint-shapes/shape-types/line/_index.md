---
title: Vonal alakzatok hozzáadása prezentációkhoz Androidon
linktitle: Vonal
type: docs
weight: 50
url: /hu/androidjava/Line/
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
description: "Tanulja meg a vonal formázásának manipulálását PowerPoint prezentációkban az Aspose.Slides for Android segítségével. Fedezze fel a tulajdonságokat, metódusokat és Java példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozott módon vonal alakzatokat adjon hozzá a PowerPoint diákhoz. Ez a cikk bemutatja, hogyan hozhat létre egy egyszerű vonalat, és hogyan testreszabhatja a vonalat úgy, hogy nyílnak nézzen ki.

Megtanulja, hogyan adjon hozzá vonal alakzatot egy diára, hogyan állítsa be a megjelenését, és hogyan mentse a frissített prezentációt. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, mint például a stílus, a szélesség, a szaggatott minta, a nyílfej beállítások és a kitöltőszín.

## **Egyszerű vonal létrehozása**

Ha egy egyszerű sima vonalat szeretne hozzáadni a prezentáció kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy vonal típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus használatával, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el.
- Írja a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy vonalat adtunk hozzá a prezentáció első diájához.

```java
// Hozzon létre egy PresentationEx osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Adjon hozzá egy line típusú AutoShape-et
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Írja a PPTX fájlt lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nyíl alakú vonal létrehozása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára, hogy néhány vonal tulajdonságot konfiguráljanak, hogy vonzóbb legyen. Próbáljunk meg néhány vonaltulajdonságot beállítani, hogy nyílnak tűnjön. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
- Szerezze meg egy dia hivatkozását az Index használatával.
- Adjon hozzá egy vonal típusú AutoShape-et a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus használatával, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el.
- Állítsa be a [Line Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineStyle) egyik, az Aspose.Slides for Android via Java által kínált stílusra.
- Állítsa be a vonal szélességét.
- Állítsa be a [Dash Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineDashStyle) vonalat az Aspose.Slides for Android via Java által kínált egyik stílusra.
- Állítsa be a vonal kezdőpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadLength) értékét.
- Állítsa be a vonal végpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LineArrowheadLength) értékét.
- Írja a módosított prezentációt PPTX fájlként.

```java
// Hozzon létre egy PresentationEx osztályt, amely a PPTX fájlt képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Adjon hozzá egy line típusú AutoShape-et
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

    // Írja a PPTX fájlt lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Átalakíthatom-e a szabályos vonalat csatlakozóvá, hogy a „rögzítse” a formákhoz?**

Nem. A szabályos vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) típusú [Line](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapetype/)) nem válik automatikusan csatlakozóvá. Ahhoz, hogy rögzítve legyen a formákhoz, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/connector/) típust és a [corresponding APIs](/slides/hu/androidjava/connector/) kapcsolatépítéshez.

**Mit tegyek, ha egy vonal tulajdonságai a témából öröklődnek, és nehéz meghatározni a végső értékeket?**

[Olvassa el a hatékony tulajdonságokat](/slides/hu/androidjava/shape-effective-properties/) a [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilinefillformateffectivedata/) interfészeken keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusokat.

**Zárolhatom-e a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. A alakzatok [lock objects](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) biztosítanak, amelyekkel tiltani lehet a szerkesztési műveleteket.