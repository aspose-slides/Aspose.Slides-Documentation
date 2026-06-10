---
title: Ellipszisek hozzáadása prezentációkhoz .NET-ben
linktitle: Ellipszis
type: docs
weight: 30
url: /hu/net/ellipse/
keywords:
- ellipszis
- alakzat
- ellipszis hozzáadása
- ellipszis létrehozása
- ellipszis rajzolása
- formázott ellipszis
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, formázhat és kezelhet ellipszis alakzatokat az Aspose.Slides for .NET-ben PPT és PPTX prezentációkban – C# kód példákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatók ellipszis alakzatok a PowerPoint diákhoz az Aspose.Slides használatával. Kitér egy egyszerű ellipszis létrehozására, egy formázott ellipszis elkészítésére, és a módosított bemutató PPTX fájlként való mentésére. Emellett érinti a kapcsolódó kérdéseket, például az ellipszis pozíciójának és méretének kezelését, a rétegezési sorrend szabályozását, valamint az animációs hatások alkalmazását.

## **Ellipszis létrehozása**
Egy egyszerű ellipszis hozzáadásához a bemutató kiválasztott diájához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból
1. Szerezze be a dia hivatkozását az Index használatával
1. Adjon hozzá egy Ellipse típusú AutoShape-et az IShapes objektum által biztosított AddAutoShape metódussal
1. Írja ki a módosított bemutatót PPTX fájlként

Az alábbi példában egy ellipszist adtunk hozzá az első diához.

```c#
// Példányosítja a PPTX-et képviselő Presentation osztályt
using (Presentation pres = new Presentation())
{

    // Lekéri az első diát
    ISlide sld = pres.Slides[0];

    // Ellipszis típusú autoshape-et ad hozzá
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //A PPTX fájlt a lemezre írja
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Formázott ellipszis létrehozása**
Egy jobban formázott ellipszis hozzáadásához a diához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)osztályból.
1. Szerezze be a dia hivatkozását az Index használatával.
1. Adjon hozzá egy Ellipse típusú AutoShape-et az IShapes objektum által biztosított AddAutoShape metódussal.
1. Állítsa be az ellipszis Kitöltés típusát Solid-ra.
1. Állítsa be az ellipszis színét a FillFormat objektumhoz tartozó IShape objektum SolidFillColor.Color tulajdonságával.
1. Állítsa be az ellipszis vonalainak színét.
1. Állítsa be az ellipszis vonalainak szélességét.
1. Írja ki a módosított bemutatót PPTX fájlként.

Az alábbi példában egy formázott ellipszist adtunk hozzá a bemutató első diájához.

```c#
// Példányosítja a PPTX-et képviselő Presentation osztályt
using (Presentation pres = new Presentation())
{

    // Lekéri az első diát
    ISlide sld = pres.Slides[0];

    // Ellipszis típusú autoshape-et ad hozzá
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Formázás alkalmazása az ellipszis alakzatra
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Formázás alkalmazása az ellipszis vonalára
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //A PPTX fájlt a lemezre írja
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Hogyan állíthatom be az ellipszis pontos pozícióját és méretét a dia egységeihez képest?**

A koordinátákat és méreteket általában **pontban** adják meg. A kiszámítható eredmény érdekében a számításokat a dia méretén alapozza, és a szükséges millimétereket vagy hüvelyket pontokra konvertálja a értékek hozzárendelése előtt.

**Hogyan helyezhetem el az ellipszist más objektumok fölé vagy alá (rétegezési sorrend szabályozása)?**

Állítsa be az objektum rajzolási sorrendjét úgy, hogy előre hozza vagy hátra küldi. Ez lehetővé teszi, hogy az ellipszis átfedje a többi objektumot, vagy felfedje az alatta lévőket.

**Hogyan animálhatom az ellipszis megjelenését vagy hangsúlyát?**

[Alkalmaz](/slides/hu/net/shape-animation/) belépő, hangsúlyos vagy kilépő hatásokat alkalmazhat a formára, és beállíthatja a triggert és az időzítést, hogy meghatározza, mikor és hogyan játszódik le az animáció.