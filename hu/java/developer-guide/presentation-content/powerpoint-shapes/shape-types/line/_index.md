---
title: Vonal alakzatok hozzáadása a prezentációkhoz Java-ban
linktitle: Vonal
type: docs
weight: 50
url: /hu/java/line/
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
description: "Ismerje meg, hogyan lehet manipulálni a vonalformázást PowerPoint prezentációkban az Aspose.Slides for Java segítségével. Fedezze fel a tulajdonságokat, módszereket és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan vonal alakzatokat adj hozzá a PowerPoint diákhoz. Ez a cikk bemutatja, hogyan hozhatsz létre egyszerű vonalat, és hogyan testre szabhatod a vonalat úgy, hogy nyílként jelenjen meg.

Megtanulod, hogyan adj hozzá egy vonal alakzatot egy diára, hogyan állítsd be a megjelenését, és hogyan mentsd el a frissített prezentációt. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, például a stílusra, szélességre, szaggatott mintára, nyílhegy‑beállításokra és a kitöltőszínre.

## **Egyszerű Vonal Létrehozása**

Egyszerű egyenes vonal hozzáadásához a prezentáció kiválasztott diájához, kövesd az alábbi lépéseket:

- Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Szerezd meg egy dia referenciáját az Index használatával.
- Adj hozzá egy Line típusú AutoShape‑t a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus használatával, amelyet a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Írd ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy vonalat adtunk hozzá a prezentáció első diájához.

```java
// A PPTX fájlt képviselő PresentationEx osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első diát lekérdezi
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Line típusú AutoShape hozzáadása
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // A PPTX írása a lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nyíl Alakú Vonal Létrehozása**

Az Aspose.Slides for Java fejlesztők számára lehetővé teszi, hogy a vonal bizonyos tulajdonságait konfigurálják, így vonzóbbá téve azt. Próbáljunk meg néhány tulajdonságot beállítani, hogy a vonal nyílként jelenjen meg. Kövesd az alábbi lépéseket:

- Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
- Szerezd meg egy dia referenciáját az Index használatával.
- Adj hozzá egy Line típusú AutoShape‑t a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus segítségével, amelyet a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Állítsd be a [Line Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineStyle) értékét valamelyik, az Aspose.Slides for Java által kínált stílusra.
- Állítsd be a vonal szélességét.
- Állítsd be a vonal [Dash Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineDashStyle) értékét valamelyik, az Aspose.Slides for Java által kínált stílusra.
- Állítsd be a vonal kezdő pontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadLength) értékét.
- Állítsd be a vonal végpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadStyle) és [Length](https://reference.aspose.com/slides/hu/java/com.aspose.slides/LineArrowheadLength) értékét.
- Írd ki a módosított prezentációt PPTX fájlként.

```java
// A PPTX fájlt képviselő PresentationEx osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első diát lekéri
    ISlide sld = pres.getSlides().get_Item(0);

    // Line típusú AutoShape hozzáadása
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Alkalmaz némi formázást a vonalon
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // A PPTX írása a lemezre
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Átalakíthatok egy egyszerű vonalat csatlakozóvá, hogy „ráilleszkedjen” az alakzatokra?**

Nem. Egy egyszerű vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/) [Line](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapetype/) típusú) nem válik automatikusan csatlakozóvá. Ahhoz, hogy ráilleszkedjen az alakzatokra, használd a dedikált [Connector](https://reference.aspose.com/slides/hu/java/com.aspose.slides/connector/) típust és a [megfelelő API‑kat](/slides/hu/java/connector/) a kapcsolatokhoz.

**Mit tegyek, ha egy vonal tulajdonságai a témából öröklődnek, és nehéz meghatározni a végleges értékeket?**

[Olvasd el a hatékony tulajdonságokat](/slides/hu/java/shape-effective-properties/) a [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilinefillformateffectivedata/) interfészeken keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Zárolhatok egy vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objects](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/#getAutoShapeLock--) funkciót biztosítanak, amelyekkel [tilthatod a szerkesztési műveleteket](/slides/hu/java/applying-protection-to-presentation/).