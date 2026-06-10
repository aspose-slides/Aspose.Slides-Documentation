---
title: Vonal alakzatok hozzáadása prezentációkhoz .NET-ben
linktitle: Vonal
type: docs
weight: 50
url: /hu/net/Line/
keywords:
- vonal
- vonal létrehozása
- vonal hozzáadása
- egyszerű vonal
- vonal beállítása
- vonal testreszabása
- szaggatott stílus
- nyílfej
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg a vonalformázás manipulálását PowerPoint prezentációkban az Aspose.Slides for .NET használatával. Fedezze fel a tulajdonságokat, metódusokat és példákat."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy programozott módon vonal alakzatokat adjon hozzá a PowerPoint diákhoz. Ez a cikk bemutatja, hogyan hozhat létre egyszerű vonalat, és hogyan szabhatja testre a vonalat úgy, hogy nyílként jelenjen meg.

Megtanulja, hogyan adjon hozzá vonal alakzatot egy diához, hogyan állítsa be a megjelenését, és hogyan mentse a frissített prezentációt. A példák a gyakorlati vonalformázási beállításokra összpontosítanak, például a stílusra, szélességre, vonalstílusra, nyílfej beállításokra és kitöltőszínre.

## **Egyszerű vonal létrehozása**
Egyszerű vonal hozzáadásához a prezentáció kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
- Szerezze be a dia referenciáját az Index használatával.
- Adjon hozzá egy vonal típusú AutoShape-et a Shapes objektum által biztosított [AddAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/methods/addautoshape/index) metódussal.
- Mentse a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy vonalat adtunk hozzá a prezentáció első diájához.

```c#
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
using (Presentation pres = new Presentation())
{
    // Szerezze meg az első diát
    ISlide sld = pres.Slides[0];

    // Adjon hozzá egy vonal típusú autoshape-et
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write a PPTX-et a lemezre
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Nyíl alakú vonal létrehozása**
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy néhány vonal tulajdonságát beállítsák, így az vonzóbbá válik. Próbáljuk meg néhány vonal tulajdonságát úgy konfigurálni, hogy nyílként jelenjen meg. Kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/hu/aspose.slides/)[](http://www.aspose.com/api/net/slides/hu/aspose.slides/).
- Szerezze be a dia referenciáját az Index használatával.
- Adjon hozzá egy vonal típusú AutoShape-et a Shapes objektum által biztosított AddAutoShape metódussal.
- Állítsa be a vonal stílusát az Aspose.Slides for .NET által kínált stílusok egyikére.
- Állítsa be a vonal szélességét.
- Állítsa be a vonal [Dash Style](https://reference.aspose.com/slides/hu/net/aspose.slides/linedashstyle) értékét az Aspose.Slides for .NET által kínált stílusok egyikére.
- Állítsa be a vonal kezdőpontjának [Arrow Head Style](https://reference.aspose.com/slides/hu/net/aspose.slides/linearrowheadstyle) és hosszát.
- Állítsa be a vonal végpontjának Arrow Head Style és hosszát.
- Mentse a módosított prezentációt PPTX fájlként.

```c#
// Példányosítsa a PresentationEx osztályt, amely a PPTX fájlt képviseli
using (Presentation pres = new Presentation())
{

    // Szerezze meg az első diát
    ISlide sld = pres.Slides[0];

    // Adjon hozzá egy vonal típusú autoshape-et
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Alkalmazzon némi formázást a vonalon
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //    //Írja a PPTX-et a lemezre
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Átalakíthatom a normál vonalat csatlakozóvá, hogy „rákapcsolódjon” az alakzatokhoz?**

Nem. A normál vonal (egy [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) típusa [Line](https://reference.aspose.com/slides/hu/net/aspose.slides/shapetype/)) nem válik automatikusan csatlakozóvá. Ahhoz, hogy rákapcsolódjon az alakzatokra, használja a dedikált [Connector](https://reference.aspose.com/slides/hu/net/aspose.slides/connector/) típust és a kapcsolódáshoz szükséges [corresponding APIs](/slides/hu/net/connector/) linkeket.

**Mit tegyek, ha egy vonal tulajdonságai a témából öröklődnek, és nehéz meghatározni a végleges értékeket?**

[Olvassa el a hatékony tulajdonságokat](/slides/hu/net/shape-effective-properties/) az [ILineFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilinefillformateffectivedata/) interfészeken keresztül – ezek már figyelembe veszik az öröklődést és a téma stílusait.

**Zárolhatom a vonalat szerkesztés (mozgás, átméretezés) ellen?**

Igen. Az alakzatok [lock objects](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/autoshapelock/) biztosítanak, amelyek lehetővé teszik a [szerkesztési műveletek letiltása](/slides/hu/net/applying-protection-to-presentation/).