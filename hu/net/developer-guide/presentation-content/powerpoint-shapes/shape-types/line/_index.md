---
title: Vonal alakzatok hozzáadása a bemutatókhoz .NET-ben
linktitle: Vonal
type: docs
weight: 50
url: /hu/net/line/
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
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg a vonalformázás kezelését PowerPoint bemutatókban az Aspose.Slides for .NET segítségével. Fedezze fel a tulajdonságokat, metódusokat és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozottan vonal alakzatokat adjunk hozzá a PowerPoint diákhoz. Ez a cikk bemutatja, hogyan hozhatunk létre egy egyszerű vonalat, és hogyan testreszabhatunk egy vonalat, hogy nyílként jelenjen meg.

Megtanulja, hogyan adjon vonal alakzatot egy diára, hogyan állítsa be a vizuális megjelenését, és hogyan mentse el a módosított bemutatót. A példák a gyakorlati vonalformázási beállításokra koncentrálnak, mint például stílus, szélesség, vonalminta, nyílfej beállítások és kitöltőszín.

## **Egyszerű vonal létrehozása**
Egyszerű, sima vonal hozzáadásához a bemutató kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)class‑ból.
- Szerezze meg a dia referenciáját az Index használatával.
- Adjon hozzá egy Line típusú AutoShape‑et a Shapes objektum által kínált [AddAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/methods/addautoshape/index) metódussal.
- Írja a módosított bemutatót PPTX fájlként.

Az alábbi példában egy vonalat adtunk hozzá a bemutató első diájához.

```c#
// Példányosítja a PresentationEx osztályt, amely a PPTX fájlt képviseli
using (Presentation pres = new Presentation())
{
    // Lekéri az első diát
    ISlide sld = pres.Slides[0];

    // Hozzáad egy vonal típusú AutoShape-et
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Írja a PPTX fájlt a lemezre
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Nyíl alakú vonal létrehozása**
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy a vonal néhány tulajdonságát úgy állítsák be, hogy vonzóbbá váljon. Próbáljuk meg beállítani néhány tulajdonságot, hogy a vonal nyílnak tűnjön. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)class‑ból[](http://www.aspose.com/api/net/slides/hu/aspose.slides/)[](http://www.aspose.com/api/net/slides/hu/aspose.slides/).
- Szerezze meg a dia referenciáját az Index használatával.
- Adjon hozzá egy Line típusú AutoShape‑et az AddAutoShape metódussal a Shapes objektumon keresztül.
- Állítsa be a vonal Stílusát az Aspose.Slides for .NET által kínált egyik stílusra.
- Állítsa be a vonal Szélességét.
- Állítsa be a vonal [Dash Style](https://reference.aspose.com/slides/hu/net/aspose.slides/linedashstyle)‑ját az Aspose.Slides for .NET által kínált egyik mintára.
- Állítsa be a [Arrow Head Style](https://reference.aspose.com/slides/hu/net/aspose.slides/linearrowheadstyle)‑t és a vonal kezdőpontjának hosszát.
- Állítsa be a nyílfej Stílusát és a vonal végpontjának hosszát.
- Írja a módosított bemutatót PPTX fájlként.

```c#
 // Példányosítja a PresentationEx osztályt, amely a PPTX fájlt képviseli
using (Presentation pres = new Presentation())
{

    // Lekéri az első diát
    ISlide sld = pres.Slides[0];

    // Hozzáad egy vonal típusú autoshape-et
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Alkalmaz néhány formázást a vonalon
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Kiírja a PPTX fájlt a lemezre
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Átalakíthatom a szabályos vonalat kapcsolóvá, hogy „rákapcsolódjon” az alakzatokra?**

Nem. Egy szabályos vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) a [Line](https://reference.aspose.com/slides/hu/net/aspose.slides/shapetype/) típusú) nem válik automatikusan kapcsolóvá. Ahhoz, hogy rákapcsolódjon az alakzatokra, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/net/aspose.slides/connector/) típust és a [megfelelő API‑kat](/slides/hu/net/connector/) a kapcsolatokhoz.

**Mit tegyek, ha egy vonal tulajdonságai a témából származnak, és nehéz meghatározni a végleges értékeket?**

Olvassa el a [hatékony tulajdonságokat](/slides/hu/net/shape-effective-properties/) az [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilinefillformateffectivedata/) interfészeken keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Zárolhatom a vonalat a szerkesztés (mozgatás, átméretezés) ellen?**

Igen. Az alakzatok [lock objektumokat](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/autoshapelock/) biztosítanak, amelyekkel letilthatók a [szerkesztési műveletek](/slides/hu/net/applying-protection-to-presentation/).