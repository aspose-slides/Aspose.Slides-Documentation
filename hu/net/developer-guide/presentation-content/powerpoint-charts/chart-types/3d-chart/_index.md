---
title: 3D diagramok testreszabása prezentációkban .NET-ben
linktitle: 3D diagram
type: docs
url: /hu/net/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3D diagramokat az Aspose.Slides for .NET-ben, PPT és PPTX fájlok támogatásával – fokozza prezentációit még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testre szabni egy 3D diagramot az Aspose.Slides-ban a `Rotation3D` beállítások, például a `RotationX`, `RotationY`, `DepthPercents` és `RightAngleAxes` konfigurálásával. Lépésről lépésre bemutatja egy prezentáció létrehozását, egy alapértelmezett adatokkal rendelkező 3D diagram hozzáadását, a szükséges 3D nézetbeállítások alkalmazását, valamint a módosított prezentáció PPTX fájlként történő mentését.

## **Állítsa be a RotationX, RotationY és DepthPercents tulajdonságait egy 3D diagramon**
Az Aspose.Slides for .NET egyszerű API-t biztosít ezen tulajdonságok beállításához. A következő cikk segít abban, hogyan állíthat be különböző tulajdonságokat, például X,Y forgatást, **DepthPercents** stb. A minta kód alkalmazza a fenti tulajdonságok beállítását.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.
1. Állítsa be a Rotation3D tulajdonságokat.
1. Írja ki a módosított prezentációt PPTX fájlba.

```c#
// Hozzon létre egy példányt a Presentation osztályból
Presentation presentation = new Presentation();
           
// Érje el az első diát
ISlide slide = presentation.Slides[0];

// Adjon hozzá diagramot alapértelmezett adatokkal
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// A diagram adatlap indexének beállítása
int defaultWorksheetIndex = 0;

// A diagram adatlap lekérése
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Sorozat hozzáadása
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Kategóriák hozzáadása
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// A Rotation3D tulajdonságainak beállítása
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Vegye a második diagram sorozatot
IChartSeries series = chart.ChartData.Series[1];

// Most a sorozat adatainak feltöltése
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Az OverLap érték beállítása
series.ParentSeriesGroup.Overlap = 100;         

// Prezentáció mentése lemezre
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100 % Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyek a [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) felsorolásban érhetők el. A pontos, naprakész listáért ellenőrizze a [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) elemeit a telepített verzió API-referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [chart API](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) vagy a [az egész dia renderelése](/slides/hu/net/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumokra. Ez akkor hasznos, ha pixelpontosan pontos előnézetre van szüksége, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba szeretné beágyazni a PowerPoint nélkül.

**Milyen teljesítményű a nagy 3D diagramok létrehozása és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa minimálisra a 3D hatásokat, kerüljön el nehéz textúrákat a falakon és a diagramterületeken, korlátozza az adatpontok számát sorozatonként, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek szerint), hogy megfeleljen a célnak a megjelenítés vagy nyomtatás során.