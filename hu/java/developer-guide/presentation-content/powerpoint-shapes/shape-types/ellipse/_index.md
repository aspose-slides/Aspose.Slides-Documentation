---
title: Ellipszisek hozzáadása prezentációkhoz Java nyelven
linktitle: Ellipszis
type: docs
weight: 30
url: /hu/java/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, formázhat és kezelhet ellipszis alakzatokat az Aspose.Slides for Java segítségével PPT és PPTX prezentációkban – Java kódrészletek is szerepelnek."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhat ellipszis alakzatokat a PowerPoint diához az Aspose.Slides használatával. Lefedi egy egyszerű ellipszis létrehozását, egy formázott ellipszis létrehozását, és a frissített prezentáció mentését PPTX fájlként. Emellett érinti a kapcsolódó kérdéseket, például az ellipszis pozíciójával és méretével való munkát, a rétegzési sorrend vezérlését, valamint animációs effektusok alkalmazását.

## **Ellipszis létrehozása**
Egyszerű ellipszis hozzáadásához a prezentáció egy kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon hozzá egy Ellipse típusú AutoShape-t a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus segítségével, amelyet a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példában egy ellipszist adtunk hozzá az első diára

```java
// A PPTX-et képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ellipszis típusú AutoShape hozzáadása
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // A PPTX fájl írása a lemegre
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formázott ellipszis létrehozása**
Formázott ellipszis jobb formázású hozzáadásához egy diára, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon hozzá egy Ellipse típusú AutoShape-t a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus segítségével, amelyet a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Állítsa be az ellipszis kitöltés típusát Solid-re.
- Állítsa be az ellipszis színét a SolidFillColor.Color tulajdonság segítségével, amelyet a [FillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFillFormat) objektum biztosít.
- Állítsa be az ellipszis vonalainak színét.
- Állítsa be az ellipszis vonalainak vastagságát.
- Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példában egy formázott ellipszist adtunk hozzá a prezentáció első diájához.

```java
// A PPTX-et képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Ellipszis típusú AutoShape hozzáadása
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Formázás alkalmazása az ellipszis alakzatra
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Formázás alkalmazása az ellipszis vonalára
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // A PPTX fájl írása a lemegre
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan állíthatom be egy ellipszis pontos pozícióját és méretét a dia egységeihez viszonyítva?**

A koordinátákat és méreteket általában **pontokban** adják meg. A kiszámítható eredmények érdekében a számításokat a dia méretére alapozza, és a szükséges millimétereket vagy hüvelyket pontokra konvertálja, mielőtt értékeket rendeli.

**Hogyan helyezhetem az ellipszist más objektumok fölé vagy alá (a rétegzési sorrend vezérlése)?**

Állítsa be a objektum rajzolási sorrendjét úgy, hogy előre hozza vagy hátra küldje. Ez lehetővé teszi, hogy az ellipszis átfedje a többi objektumot, vagy feltárja az alatta lévőket.

**Hogyan animálhatom egy ellipszis megjelenését vagy hangsúlyozását?**

[Alkalmaz](/slides/hu/java/shape-animation/) belépő, hangsúlyozó vagy kilépő effektusokat az alakzatra, és konfigurálja a triggereket és az időzítést, hogy meghatározza, mikor és hogyan játsszák le az animációt.