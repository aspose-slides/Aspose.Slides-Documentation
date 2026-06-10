---
title: Ellipszisek hozzáadása Android prezentációkhoz
linktitle: Ellipszis
type: docs
weight: 30
url: /hu/androidjava/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre, formázhat és manipulálhat ellipszis alakzatokat az Aspose.Slides for Androidban PPT és PPTX prezentációkhoz - Java kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet ellipszis alakzatokat hozzáadni a PowerPoint diákhoz az Aspose.Slides használatával. Középpontjában egy egyszerű ellipszis létrehozása, egy formázott ellipszis létrehozása, és a frissített bemutató PPTX fájlként mentése áll. Emellett érinti a kapcsolódó kérdéseket is, például az ellipszis helyének és méretének kezelése, a rétegezési sorrend szabályozása, valamint animációs hatások alkalmazása.

## **Ellipszis létrehozása**
Ahhoz, hogy egyszerű ellipszist adjunk hozzá egy kiválasztott diára, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
- Szerezze meg egy dia referenciáját az Index használatával.
- Adjon hozzá egy Ellipse típusú AutoShape-t a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus használatával, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el.
- Írja ki a módosított bemutatót PPTX fájlként.

Az alábbi példában egy ellipszist adtunk hozzá az első diára

```java
// Hozzon létre egy Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Adjon hozzá egy ellipszis típusú AutoShape-t
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Írja ki a PPTX fájlt a lemezre
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formázott ellipszis létrehozása**
Ahhoz, hogy jobban formázott ellipszist adjunk egy diára, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
- Szerezze meg egy dia referenciáját az Index használatával.
- Adjon hozzá egy Ellipse típusú AutoShape-t a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus használatával, amely a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektumon keresztül érhető el.
- Állítsa be az ellipszis kitöltéstípust Szilárdra.
- Állítsa be az ellipszis színét a SolidFillColor.Color tulajdonság segítségével, amely a [FillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IFillFormat) objektumon keresztül érhető el, és a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape) objektumhoz kapcsolódik.
- Állítsa be az ellipszis vonalainak színét.
- Állítsa be az ellipszis vonalainak vastagságát.
- Írja ki a módosított bemutatót PPTX fájlként.

Az alábbi példában egy formázott ellipszist adtunk hozzá a bemutató első diájához.

```java
// Hozzon létre egy Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Adjon hozzá egy ellipszis típusú AutoShape-t
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Alkalmazzon némi formázást az ellipszis alakzatra
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Alkalmazzon némi formázást az ellipszis vonalára
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Írja ki a PPTX fájlt a lemezre
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan állíthatom be egy ellipszis pontos pozícióját és méretét a dia egységeihez viszonyítva?**

A koordinátákat és méreteket általában **pontban** adják meg. A kiszámítható eredmények érdekében a számításokat a dia mérete alapján végezze, és a szükséges millimétereket vagy hüvelyket konvertálja pontokra, mielőtt értékeket adna meg.

**Hogyan helyezhetem el egy ellipszist más objektumok fölé vagy alá (a rétegezési sorrend szabályozása)?**

Állítsa be az objektum rajzolási sorrendjét úgy, hogy előre hozza vagy hátulra küldje. Ez lehetővé teszi, hogy az ellipszis átfedje a többi objektumot, vagy felfedje az alatta lévőket.

**Hogyan animáljam egy ellipszis megjelenését vagy hangsúlyát?**

[Alkalmazzon](/slides/hu/androidjava/shape-animation/) belépő, hangsúlyos vagy kilépő hatásokat a formára, és konfigurálja a triggereket és az időzítést, hogy meghatározza, mikor és hogyan játszódik le az animáció.