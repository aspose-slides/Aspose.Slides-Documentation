---
title: Kördiagramok testreszabása a prezentációkban .NET-ben
linktitle: Kördiagram
type: docs
url: /hu/net/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram beállítások
- diagram beállítások
- ábrázolási beállítások
- szelet szín
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat kördiagramokat .NET-ben az Aspose.Slides segítségével, PowerPoint-ba exportálhatóan, és ezáltal másodpercek alatt fokozhatja adatmesélését."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatsz kördiagramokkal az Aspose.Slides-ben. Bemutatja, hogyan konfigurálhatók a másodlagos ábrázolási beállítások a Pie of Pie és a Bar of Pie diagramokhoz, valamint hogyan engedélyezhető az automatikus szelet-színezés egy szabványos kördiagram esetén.

A példák a gyakorlati diagramtestreszabási lépésekre összpontosítanak, például diagram hozzáadására egy diára, sorozatok és címkék beállításának módosítására, az alapértelmezett diagramadatok egyéni kategóriákkal és értékekkel történő helyettesítésére, valamint a frissített bemutató mentésére.

## **Másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz**

Az Aspose.Slides for .NET most már támogatja a másodlagos ábrázolási beállításokat a Pie of Pie vagy Bar of Pie diagramokhoz. Ebben a témában példán keresztül megmutatjuk, hogyan adhatók meg ezek a beállítások az Aspose.Slides használatával. Kérjük, kövesd az alábbi lépéseket:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztálypéldányt.
2. Adj hozzá egy diagramot a diára.
3. Állítsd be a diagram másodlagos ábrázolási beállításait.
4. Írd a bemutatót a lemezre.

Az alábbi példában különböző tulajdonságokat állítottunk be a Pie of Pie diagramhoz.

```c#
// Hozzon létre egy Presentation osztály példányt
Presentation presentation = new Presentation();

// Adjon hozzá egy diagramot a diára
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
//     Állítson be különböző tulajdonságokat
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Mentse a prezentációt a lemezre
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **Automatikus kördiagram-szelet színek beállítása**

Az Aspose.Slides for .NET egyszerű API-t biztosít az automatikus kördiagram-szelet színek beállításához. A mintakód alkalmazza a fent említett beállításokat.

1. Hozz létre egy Presentation osztálypéldányt.
2. Érj el az első diát.
3. Adj hozzá egy diagramot alapértelmezett adatokkal.
4. Állítsd be a diagram címét.
5. Állítsd be az első sorozatot az Értékek megjelenítésére.
6. Állítsd be a diagram adatlap indexét.
7. Szerezd meg a diagram adatlap munkafüzetét.
8. Töröld az alapértelmezett generált sorozatokat és kategóriákat.
9. Adj hozzá új kategóriákat.
10. Adj hozzá új sorozatot.

Írd a módosított bemutatót egy PPTX fájlba.

```c#
// Hozzon létre egy Presentation osztály példányt, amely PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
	// Hozzon létre egy Presentation osztály példányt, amely PPTX fájlt képvisel
	Presentation presentation = new Presentation();

	// Első dia elérése
	ISlide slides = presentation.Slides[0];

	// Diagram hozzáadása alapértelmezett adatokkal
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Diagram címének beállítása
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Első sorozat beállítása az Értékek megjelenítésére
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Diagram adatlap indexének beállítása
	int defaultWorksheetIndex = 0;

	// Diagram adatlap munkafüzetének lekérése
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Alapértelmezett generált sorozatok és kategóriák törlése
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Új kategóriák hozzáadása
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Új sorozat hozzáadása
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Sorozat adatainak feltöltése most
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **GYIK**

**Támogatottak a 'Pie of Pie' és 'Bar of Pie' változatok?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) a másodlagos ábrázolást kördiagramoknál, beleértve a 'Pie of Pie' és a 'Bar of Pie' típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, [exportálhatod a diagramot képként](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) (például PNG) a teljes bemutató nélkül.