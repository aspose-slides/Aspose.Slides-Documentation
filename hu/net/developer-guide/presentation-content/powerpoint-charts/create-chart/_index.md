---
title: PowerPoint prezentáció diagramjainak létrehozása vagy frissítése .NET-ben
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/net/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórt diagram
- torta diagram
- vonal diagram
- fa térkép diagram
- részvény diagram
- doboz‑ és buzogány diagram
- tölcsér diagram
- naplemente diagram
- hisztogram diagram
- radar diagram
- több kategória diagram
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Létrehozza és testreszabja a diagramokat PowerPoint prezentációkban az Aspose.Slides for .NET segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati C# kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides for .NET segítségével. Megtanulja, hogyan adhat programozottan diagramot egy diára, töltheti fel adatokal, és alkalmazhat különféle formázási lehetőségeket, hogy megfeleljen a konkrét tervezési követelményeinek. A cikk során részletes kódrészletek mutatják be az egyes lépéseket, a prezentáció és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alaposan megértheti, hogyan integrálhat dinamikus diagramgenerálást .NET alkalmazásaiba, ezzel egyszerűsítve az adatalapú prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítenek gyorsan megjeleníteni az adatokat és olyan felismeréseket nyerni, amelyek egy táblázatból vagy munkafüzetből nem lennének azonnal nyilvánvalóak.

**Miért érdemes diagramokat készíteni?**

Diagramok használatával:

* nagy mennyiségű adatot összegezhet, tömöríthet vagy összefoglalhat egyetlen dián a prezentációban;
* mintákat és trendeket fedhet fel az adatokban;
* meghatározhatja az adat időbeli vagy egy adott mérőegységhez viszonyított irányát és lendületét;
* észlelheti a kilógó, hibás vagy értelmetlen adatokat;
* komplex adatokat kommunikálhat vagy prezentálhat.

A PowerPointban a diagramokat a *Beszúrás* funkcióval hozhatja létre, amely számos diagramtípushoz kínál sablonokat. Az Aspose.Slides segítségével mind szabványos, mind egyedi diagramokat készíthet.

{{% alert color="info" %}} 
Használja a [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) enumerációt a [Aspose.Slides.Charts](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/) névtérben. Az enumeráció értékei a különböző diagramtípusoknak felelnek meg.
{{% /alert %}} 

### **Halmozott oszlopdiagram létrehozása**

Ez a szakasz bemutatja, hogyan hozhat létre halmozott oszlopdiagramot az Aspose.Slides for .NET segítségével. Megtanulja, hogyan inicializáljon egy prezentációt, adjon hozzá diagramot, és testre szabja annak elemeit, például a címet, adatokat, sorokat, kategóriákat és a formázást. Kövesse az alábbi lépéseket a standard halmozott oszlopdiagram létrehozásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Adjon címet a diagramnak.
1. Hozzáférés a diagram adatlapjához.
1. Törölje az összes alapértelmezett sorozatot és kategóriát.
1. Adjon új sorozatokat és kategóriákat.
1. Adjon új diagramadatot a diagram sorozataihoz.
1. Alkalmazzon kitöltőszínt a diagram sorozatához.
1. Adjon címkéket a diagram sorozatához.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a halmozott oszlopdiagram létrehozását:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// A Presentation osztály példányosítása.
using (Presentation presentation = new Presentation())
{
    // Az első dia elérése.
    ISlide slide = presentation.Slides[0];

    // Halmozott oszlopdiagram hozzáadása az alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // A diagram címének beállítása.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // A diagram adatlapjának indexének beállítása.
    int worksheetIndex = 0;

    // A diagram adatkönyvtárának lekérése.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Az alapértelmezett generált sorozatok és kategóriák törlése.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Új sorozatok hozzáadása.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Új kategóriák hozzáadása.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Az első diagram sorozat lekérése.
    IChartSeries series = chart.ChartData.Series[0];

    // A sorozat adatainak feltöltése.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // A sorozat kitöltőszínének beállítása.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // A második diagram sorozat lekérése.
    series = chart.ChartData.Series[1];

    // A sorozat adatainak feltöltése.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // A sorozat kitöltőszínének beállítása.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Az első címke beállítása a kategórianév megjelenítésére.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // A sorozat beállítása a harmadik címkénél az érték megjelenítésére.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // A prezentáció mentése a lemezre PPTX fájlként.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A halmozott oszlop diagram](clustered_column_chart.png)

### **Szórásdiagram létrehozása**

A szórásdiagramok (más néven szórásábrák vagy x‑y grafikonok) gyakran használatosak a minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szórásdiagramot, ha:

* párosítandó numerikus adatai vannak;
* két változó jól párosítható;
* meg szeretné határozni, hogy a két változó összefügg-e;
* rendelkezik egy független változóval, amely több értéket vehet fel a függő változó számára.

Ez a C# kód bemutatja, hogyan hozhat létre szórásdiagramot különböző jelölőszerekkel:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// A Presentation osztály példányosítása.
using (Presentation presentation = new Presentation())
{
    // Az első dia elérése.
    ISlide slide = presentation.Slides[0];

    // Alapértelmezett szórás diagram létrehozása.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // A diagram adatlapjának indexének beállítása.
    int worksheetIndex = 0;

    // A diagram adatkönyvtárának lekérése.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Az alapértelmezett sorozat törlése.
    chart.ChartData.Series.Clear();

    // Új sorozatok hozzáadása.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Az első diagram sorozat lekérése.
    IChartSeries series = chart.ChartData.Series[0];

    // Új pont (1:3) hozzáadása a sorozathoz.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Új pont (2:10) hozzáadása.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // A sorozat típusának módosítása.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // A diagram sorozat jelölőjének módosítása.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // A második diagram sorozat lekérése.
    series = chart.ChartData.Series[1];

    // Új pont (5:2) hozzáadása a diagram sorozathoz.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Új pont (3:1) hozzáadása.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Új pont (2:2) hozzáadása.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Új pont (5:1) hozzáadása.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // A diagram sorozat jelölőjének módosítása.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // A prezentáció mentése a lemezre PPTX fájlként.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szórás diagram](scatter_chart.png)

### **Tortadiagram létrehozása**

A tortadiagramok leginkább a részek‑egész arányok megjelenítésére alkalmasak, különösen akkor, ha az adatok kategóriákat és numerikus értékeket tartalmaznak. Ha azonban sok rész vagy címke van, érdemes oszlopdiagramot használni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Pie` típust.
1. Hozzáférés a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon új sorozatokat és kategóriákat.
1. Adjon új diagramadatot a diagram sorozataihoz.
1. Adjon új pontokat a diagramhoz, és alkalmazzon egyedi színeket a torta szeleteire.
1. Állítson be címkéket a sorozatokhoz.
1. Engedélyezze a vezetővonalakat a sorozatcímkékhez.
1. Állítsa be a forgásszöget a tortadiagramhoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a tortadiagram létrehozását:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// A Presentation osztály példányosítása.
using (Presentation presentation = new Presentation())
{
    // Az első dia elérése.
    ISlide slide = presentation.Slides[0];

    // Diagram hozzáadása az alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // A diagram címének beállítása.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Az első sorozat beállítása az értékek megjelenítésére.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // A diagram adatlapjának indexének beállítása.
    int worksheetIndex = 0;

    // A diagram adatkönyvtárának lekérése.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Az alapértelmezett generált sorozatok és kategóriák törlése.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Új kategóriák hozzáadása.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Új sorozatok hozzáadása.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // A sorozat adatainak feltöltése.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // A szelet színének beállítása.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // A szelet szegélyének beállítása.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // A szelet szegélyének beállítása.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // A szelet szegélyének beállítása.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Egyéni címkék létrehozása minden kategóriához az új sorozatban.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // A sorozat beállítása a vezetővonalak megjelenítésére a diagramon.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // A tortadiagram szeleteinek forgásszögének beállítása.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // A prezentáció mentése a lemezre PPTX fájlként.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A torta diagram](pie_chart.png)

### **Vonaldiagram létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használandók, amikor az értékek időbeli változását szeretné bemutatni. Vonaldiagrammal egyszerre nagy mennyiségű adatot hasonlíthat össze, nyomon követheti a változásokat és trendeket, kiemelheti az anomáliákat stb.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Line` típust.
1. Hozzáférés a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon új sorozatokat és kategóriákat.
1. Adjon új diagramadatot a diagram sorozataihoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a vonaldiagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Alapértelmezés szerint a vonaldiagram pontjai folytonos egyenes vonallal vannak összekötve. Ha a pontokat szaggatott vonallal szeretné összekötni, adja meg a kívánt vonaltípust a következőképpen:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

Az eredmény:

![A vonal diagram](line_chart.png)

### **Fák leképezés diagram létrehozása**

A fák leképezés diagramok (Tree Map) leginkább értékesítési adatok esetén használatosak, amikor a kategóriák relatív méretét szeretné megjeleníteni, és gyorsan felhívni a figyelmet a legnagyobb hozzájáruló elemekre.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Treemap` típust.
1. Hozzáférés a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon új sorozatokat és kategóriákat.
1. Adjon új diagramadatot a diagram sorozataihoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a fák leképezés diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Ág 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Ág 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A fák leképezés diagram](treemap_chart.png)

### **Részvény diagram létrehozása**

A részvény diagramok pénzügyi adatokat jelenítenek meg, például nyitó, magas, alacsony és záró árakat, ezáltal segítve a piaci trendek és a volatilitás elemzését. Alapvető betekintést nyújtanak a részvény teljesítményébe, támogató eszközként szolgálnak a befektetők és elemzők számára a tájékozott döntéshozatalhoz.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.OpenHighLowClose` típust.
1. Hozzáférés a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon új sorozatokat és kategóriákat.
1. Adjon új diagramadatot a diagram sorozataihoz.
1. Adja meg a HiLowLines formátumát.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a részvény diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A részvény diagram](stock_chart.png)

### **Doboz‑ és buzogány diagramok létrehozása**

A doboz‑ és buzogány diagramok az adat eloszlását jelenítik meg, összegző statisztikai mutatókkal, mint a medián, kvartilisek és esetleges kiugró értékek. Különösen hasznosak feltáró adatgyűjtéskor és statisztikai vizsgálatoknál, amikor gyorsan meg kell érteni az adatok variabilitását és az anomáliákat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.BoxAndWhisker` típust.
1. Hozzáférés a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon új sorozatokat és kategóriákat.
1. Adjon új diagramadatot a diagram sorozataihoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a doboz‑ és buzogány diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Tölcsér diagram létrehozása**

A tölcsér diagramok a szekvenciális lépéseket ábrázolják, ahol az adat mennyisége csökken a folyamat egyes szakaszain. Különösen hasznosak a konverziós arányok elemzésében, a szűk keresztmetszetek azonosításában és az értékesítési vagy marketing folyamatok hatékonyságának nyomon követésében.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Funnel` típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a tölcsér diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A tölcsér diagram](funnel_chart.png)

### **Naplemente diagram létrehozása**

A naplemente diagramok (Sunburst) hierarchikus adatokat ábrázolnak, a szinteket koncentrikus gyűrűkben jelenítik meg. Segítenek a rész‑egész kapcsolatok bemutatásában, és ideálisak beágyazott kategóriák és alkategóriák világos, kompakt formában történő ábrázolásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Sunburst` típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a naplemente diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Ág 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Ág 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A naplemente diagram](sunburst_chart.png)

### **Hisztogram diagram létrehozása**

A hisztogram diagramok a numerikus adatok eloszlását ábrázolják, az értékeket intervallumokra (bin‑ekre) csoportosítva. Különösen hasznosak a gyakoriság, ferdeség, szórás és az esetleges kiugró értékek felismerésében.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.Histogram` típust.
1. Hozzáférés a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon új sorozatokat és kategóriákat.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a hisztogram diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A hisztogram diagram](histogram_chart.png)

### **Radar diagram létrehozása**

A radar diagramok többváltozós adatokat ábrázolnak kétdimenziós formában, lehetővé téve több változó egyszerre történő összehasonlítását. Különösen hasznosak minták, erősségek és gyengeségek felismerésében több teljesítménymutató vagy tulajdonság esetén.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.Radar` típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a radar diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A radar diagram](radar_chart.png)

### **Több kategória diagram létrehozása**

A több kategória diagramok olyan adatokat jelenítenek meg, amelyek több kategóriacsoportot tartalmaznak, lehetővé téve az értékek összehasonlítását több dimenzióban egyszerre. Különösen hasznosak, ha összetett, több rétegből álló adathalmazokat szeretne elemezni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Hozzáférés a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon új sorozatokat és kategóriákat.
1. Adjon új diagramadatot a diagram sorozataihoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja a több kategóriás diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Sorozat hozzáadása.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // A prezentáció mentése a diagrammal.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A több kategóriás diagram](multi_category_chart.png)

### **Térkép diagram létrehozása**

A térkép diagramok földrajzi adatokat ábrázolnak, az információt konkrét helyekhez (országok, államok, városok) rendelve. Különösen hasznosak regionális trendek, demográfiai adatok és térbeli eloszlások elemzésére vizuálisan vonzó módon.

Ez a C# kód bemutatja a térkép diagram létrehozását:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A térkép diagram](map_chart.png)

{{% alert color="info" %}} 
A fenti kép a mentett prezentációt mutatja PowerPointban megnyitva. Az Aspose.Slides helyesen írja ki a térkép diagramot és annak adatait, de maga a diagram nem kerül megrajzolásra: amikor egy olyan diát, amely tartalmaz térkép diagramot, képként renderel vagy PDF‑be vagy SVG‑be konvertál, a diagramterület üres marad. A többi forma a dián változatlanul marad.
{{% /alert %}} 

### **Kombinációs diagramok létrehozása**

A kombinációs (vagy combo) diagram több diagramtípust egyesít egyetlen grafikonban. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja két vagy több adatcsoport közötti különbségeket, segítve a kapcsolatok felismerését.

![A kombinációs diagram](combination_chart.png)

Az alábbi C# kód bemutatja, hogyan hozható létre a fenti kombinációs diagram egy PowerPoint‑prezentációban:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Beállítja a diagram címét
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Beállítja a diagram jelmagyarázatát
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Törli az alapértelmezett generált sorozatokat és kategóriákat
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Új kategóriákat ad hozzá
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Hozzáadja az első sorozatot
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Beállítja a vízszintes tengelyt
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Beállítja a függőleges tengelyt
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Beállítja a függőleges fő rácsvonalak színét
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Beállítja a másodlagos vízszintes tengelyt
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Beállítja a másodlagos függőleges tengelyt
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Diagramok frissítése**

Az Aspose.Slides for .NET lehetővé teszi a PowerPoint diagramok frissítését a diagramadatok, formázás és stílus módosításával. Ez a funkció egyszerűsíti a prezentációk dinamikus tartalommal való naprakészen tartását, és biztosítja, hogy a diagramok pontosan tükrözzék a jelenlegi adatokat és vizuális szabványokat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a diagramot tartalmazó prezentációt reprezentálja.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Járja be az összes alakzatot a diagram megtalálásához.
1. Hozzáférés a diagram adatlapjához.
1. Módosítsa a diagram adat sorozatát a sorozat értékeinek változtatásával.
1. Adjon hozzá egy új sorozatot, és töltse fel annak adatait.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan frissíthet egy diagramot:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Példányosítsa a Presentation osztályt, amely egy PPTX fájlt képvisel.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Az első dia elérése.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // A diagram adatlapjának indexének beállítása.
            int worksheetIndex = 0;

            // A diagram adatkönyvtárának lekérése.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // A diagram kategórianévinek módosítása.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Az első diagram sorozat lekérése.
            IChartSeries series = chart.ChartData.Series[0];

            // A sorozat adatainak frissítése.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // A sorozat nevének módosítása.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // A második diagram sorozat lekérése.
            series = chart.ChartData.Series[1];

            // A sorozat adatainak frissítése.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // A sorozat nevének módosítása.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Új sorozat hozzáadása.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // A sorozat adatainak feltöltése.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // A prezentáció mentése a diagrammal.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Adattartomány beállítása egy diagramhoz**

Az Aspose.Slides for .NET rugalmasságot biztosít a diagram adatforrásaként egy munkalap adott tartományának meghatározásához. Ez azt jelenti, hogy közvetlenül leképezhet egy munkalap részletet a diagramra, így szabályozhatja, mely cellák járulnak hozzá a diagram sorozataihoz és kategóriáihoz. Ennek eredményeként könnyen frissítheti és szinkronizálhatja diagramjait a munkalap legújabb adataival, biztosítva, hogy a PowerPoint‑prezentációk aktuális és pontos információkat tükrözzenek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a diagramot tartalmazó prezentációt reprezentálja.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Járja be az összes alakzatot a diagram megtalálásához.
1. Hozzáférés a diagram adataihoz, és állítsa be a tartományt.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan állíthatja be a diagram adat tartományát:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Az első dia elérése.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használatakor minden diagram sorozat automatikusan más‑más jelölőszimbólumot kap.

Ez a C# kód bemutatja, hogyan állíthat be egy diagram sorozat jelölőt automatikusan:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspise.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Sorozatadatok feltöltése.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides for .NET?**

Az Aspose.Slides for .NET számos diagramtípust támogat, köztük oszlop, vonal, torta, terület, szórás, hisztogram, radar és sok más. Ez a rugalmasság lehetővé teszi a legmegfelelőbb diagramtípus kiválasztását az adatvizualizációs igényekhez.

**Hogyan adhatok új diagramot egy diához?**

Diagram hozzáadásához először hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt, szerezze meg a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típust és a kezdeti adatokat. Ez a folyamat közvetlenül beilleszti a diagramot a prezentációba.

**Hogyan frissíthetem a diagramon megjelenített adatokat?**

A diagram adatainak frissítéséhez férjen hozzá a diagram adatkönyvtárához ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)), törölje az alapértelmezett sorozatokat és kategóriákat, majd adja hozzá a saját egyedi adatait. Ez lehetővé teszi a diagram programozott frissítését a legújabb adatok tükrözésére.

**Lehet-e testreszabni a diagram megjelenését?**

Igen, az Aspose.Slides for .NET kiterjedt testreszabási lehetőségeket kínál. Módosíthat színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb formázási elemeket, hogy a diagram megjelenése megfeleljen a konkrét tervezési követelményeknek.