---
title: Trendvonalak hozzáadása a prezentációs diagramokhoz .NET-ben
linktitle: Trendvonal
type: docs
url: /hu/net/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for .NET segítségével — egy gyakorlati útmutató, amely segít lekötni a közönséget."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhat trendvonalakat a prezentáció diagramjaihoz az Aspose.Slides használatával. Megmutatja, hogyan hozhat létre diagramot, adhat hozzá trendvonalakat a diagram sorozataihoz, és dolgozhat több trendvonal típussal, beleértve az exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány típusokat.

Leírja továbbá, hogyan adhat egy egyéni vonalat a diagramhoz vonal alakzat beszúrásával, valamint tartalmaz egy rövid GYIK-et a trendvonal előre és hátra irányú projekciós értékekkel kapcsolatban, és arról, hogy a trendvonalak megmaradnak-e PDF vagy SVG exportálásakor, illetve a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**
Aspose.Slides for .NET egyszerű API-t kínál a különböző diagram trendvonalak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típus egyikével (ebben a példában a ChartType.ClusteredColumn típus kerül használatra).
4. Exponenciális trendvonal hozzáadása az 1. diagram sorozathoz.
5. Lineáris trendvonal hozzáadása az 1. diagram sorozathoz.
6. Logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz.
7. Mozgó átlag trendvonal hozzáadása a 2. diagram sorozathoz.
8. Polinomiális trendvonal hozzáadása a 3. diagram sorozathoz.
9. Hatvány trendvonal hozzáadása a 3. diagram sorozathoz.
10. Írja a módosított prezentációt egy PPTX fájlba.

Az alábbi kódot használják diagram Trendvonalakkal való létrehozásához.

```c#
// Üres prezentáció létrehozása
Presentation pres = new Presentation();

// Csoportosított oszlopdiagram létrehozása
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Exponenciális trendvonal hozzáadása a diagram 1. sorozatához
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Lineáris trendvonal hozzáadása a diagram 1. sorozatához
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Logaritmikus trendvonal hozzáadása a diagram 2. sorozatához
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Mozgó átlag trendvonal hozzáadása a diagram 2. sorozatához
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Polinomiális trendvonal hozzáadása a diagram 3. sorozatához
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Hatvány trendvonal hozzáadása a diagram 3. sorozatához
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Prezentáció mentése
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```

## **Egyéni vonal hozzáadása**
Aspose.Slides for .NET egyszerű API-t biztosít egyéni vonalak diagramhoz való hozzáadásához. Egyszerű egyenes vonal hozzáadásához a prezentáció egy kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze meg egy dia hivatkozását az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által biztosított AddChart metódussal
- Adjon hozzá egy vonal típusú AutoShape-et a Shapes objektum által biztosított AddAutoShape metódussal
- Állítsa be a forma vonalainak színét.
- Írja a módosított prezentációt PPTX fájlként

Az alábbi kódot használják diagram Custom Lines (egyéni vonalakkal) létrehozásához.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Mit jelentenek a 'forward' és 'backward' a trendvonal esetében?**

Ezek a trendvonal előre/hátra kiterjesztett hosszát jelentik: szórt (XY) diagramok esetén – tengelyegységekben; nem szórt diagramok esetén – kategóriák számában. Csak nem negatív értékek megengedettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba exportálásakor, illetve a dia képpé renderelésekor?**

Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/net/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/net/render-a-slide-as-an-svg-image/) formátumra konvertálja és a diagramokat képként rendereli; a trendvonalak, amelyek a diagram részét képezik, ezeknek a műveleteknek a során megmaradnak. Egy módszer is rendelkezésre áll a diagram [képének exportálásához](/slides/hu/net/create-shape-thumbnails/).