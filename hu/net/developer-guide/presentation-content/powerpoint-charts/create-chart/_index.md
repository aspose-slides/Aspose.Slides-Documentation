---
title: Diagramok létrehozása vagy frissítése PowerPoint prezentációkban .NET-ben
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
- kördiagram
- vonaldiagram
- fa térkép diagram
- részvénydiagram
- doboz és siklógörbe diagram
- tölcsérdiagram
- napkitörés diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for .NET használatával. Diagramok hozzáadása, formázása és szerkesztése gyakorlati C# kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt arról, hogyan hozhatunk létre és testreszabhatunk diagramokat az Aspose.Slides for .NET segítségével. Megtanulja, hogyan adhat programozott módon diagramot egy diára, hogyan töltheti fel adatokka­l, és hogyan alkalmazhat különféle formázási lehetőségeket, hogy megfeleljenek a konkrét tervezési követelményeknek. A cikk során részletes kódpéldák illusztrálják az egyes lépéseket, a bemutató és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázat beállításáig. Az útmutató követésével alapos megértést szerez a dinamikus diagramgenerálás integrálásáról .NET alkalmazásaiban, megkönnyítve az adat‑vezérelt prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megjeleníteni az adatokat, és olyan betekintéseket nyerni, amelyek egy táblázatból vagy munkafüzetből nem feltétlenül egyértelműek.

**Miért hozzunk létre diagramokat?**

Diagramok használatával:

* nagy mennyiségű adatot összegezhet, tömöríthet vagy összefoglalhat egyetlen dián egy prezentációban;
* felfedhet mintákat és trendeket az adatokban;
* megállapíthatja az adat irányát és lendületét időben vagy egy meghatározott mértékegységhez viszonyítva;
* észlelheti a kiugró értékeket, anomáliákat, eltéréseket, hibákat és értelmetlen adatokat;
* összetett adatokat kommunikálhat vagy bemutathat.

A PowerPointban a *Insert* (Beszúrás) funkcióval hozhat létre diagramokat, amely számos diagramtípus sablonját kínálja. Az Aspose.Slides segítségével mind szabványos, mind egyedi diagramok készíthetők.

{{% alert color="primary" %}} 
Használja a [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) felsorolást a [Aspose.Slides.Charts](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/) névtérben. Ennek a felsorolásnak az értékei a különböző diagramtípusoknak felelnek meg.
{{% /alert %}} 

### **Halmozott oszlopdiagramok létrehozása**

Ez a szakasz bemutatja, hogyan hozhatók létre halmozott oszlopdiagramok az Aspose.Slides for .NET használatával. Megtanulja, hogyan inicializáljon egy prezentációt, adjon hozzá egy diagramot, és hogyan testreszabja annak elemeit, például a címet, az adatokat, a sorokat, a kategóriákat és a stílust. Kövesse az alábbi lépéseket a standard halmozott oszlopdiagram létrehozásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Adjon címet a diagramnak.
1. Érje el a diagram adatmunkalapját.
1. Törölje az összes alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Alkalmazzon kitöltőszínt a diagram sorozatára.
1. Adjon címkéket a diagram sorozatához.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre halmozott oszlopdiagram:

```c#
// Példányosítja a Presentation osztályt.
using (Presentation presentation = new Presentation())
{
    // Eléri az első diát.
    ISlide slide = presentation.Slides[0];

    // Halmozott oszlopdiagram hozzáadása az alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Beállítja a diagram címét.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Az első sorozatot úgy állítja be, hogy értékeket mutasson.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Beállítja a diagram adatlapjának indexét.
    int worksheetIndex = 0;

    // Lekéri a diagram adatkönyvtárát.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Törli az alapértelmezett generált sorozatokat és kategóriákat.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Új sorozat hozzáadása.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Új kategóriák hozzáadása.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Lekéri az első diagram sorozatot.
    IChartSeries series = chart.ChartData.Series[0];

    // Feltölti a sorozat adatait.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Beállítja a sorozat kitöltőszínét.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Lekéri a második diagram sorozatot.
    series = chart.ChartData.Series[1];

    // Feltölti a sorozat adatait.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Beállítja a sorozat kitöltőszínét.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Az első címkét úgy állítja be, hogy a kategória nevét mutassa.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // A sorozatot úgy állítja be, hogy a harmadik címke értékét mutassa.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // A prezentációt lemezre menti PPTX fájlként.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A halmozott oszlopdiagram](clustered_column_chart.png)

### **Szórási diagramok létrehozása**

A szórási diagramok (más néven pontdiagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szórási diagramot, ha:

* párosított numerikus adatai vannak;
* két változó jól párosítható egymással;
* meg szeretné állapítani, hogy a két változó összefügg-e;
* független változója több értékkel rendelkezik egy függő változóhoz képest.

Ez a C# kód megmutatja, hogyan hozhat létre szórási diagramot különböző jelölőtípusú sorozattal:

```c#
// Példányosítja a Presentation osztályt.
using (Presentation presentation = new Presentation())
{
    // Eléri az első diát.
    ISlide slide = presentation.Slides[0];

    // Létrehozza az alapértelmezett szórási diagramot.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Beállítja a diagram adatlapjának indexét.
    int worksheetIndex = 0;

    // Lekéri a diagram adatkönyvtárát.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Törli az alapértelmezett sorozatot.
    chart.ChartData.Series.Clear();

    // Új sorozatok hozzáadása.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Lekéri az első diagram sorozatot.
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

    // Lekéri a második diagram sorozatot.
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

    // A prezentációt lemezre menti PPTX fájlként.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A szórási diagram](scatter_chart.png)

### **Kördiagramok létrehozása**

A kördiagramok leginkább azt a rész‑a‑teljes egész arányt mutatják be, különösen akkor, ha az adatok kategória címkéket tartalmaznak numerikus értékekkel. Ha a diagram sok részlettel vagy címkével rendelkezik, érdemes inkább oszlopdiagramot használni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Pie` típust.
1. Érje el a diagram adatkönyvtárát ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Adjon hozzá új pontokat a diagramhoz, és alkalmazzon egyedi színeket a kördiagram szektoraira.
1. Állítson be címkéket a sorozathoz.
1. Engedélyezze a vezetővonalakat a sorozatcímkékhez.
1. Állítsa be a kördiagram forgatási szögét.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre kördiagram:

```c#
// Példányosítja a Presentation osztályt.
using (Presentation presentation = new Presentation())
{
    // Eléri az első diát.
    ISlide slide = presentation.Slides[0];

    // Diagram hozzáadása az alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Beállítja a diagram címét.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Az első sorozatot úgy állítja be, hogy értékeket mutasson.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Beállítja a diagram adatlapjának indexét.
    int worksheetIndex = 0;

    // Lekéri a diagram adatkönyvtárát.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Törli az alapértelmezett generált sorozatokat és kategóriákat.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Új kategóriák hozzáadása.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Új sorozatok hozzáadása.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Feltölti a sorozat adatait.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Beállítja a szektor színét.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Beállítja a szektor szegélyét.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Beállítja a szektor szegélyét.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Beállítja a szektor szegélyét.
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

    // A sorozatot úgy állítja be, hogy vezetővonalakat mutasson a diagramon.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Beállítja a kördiagram szektorainak forgatási szögét.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // A prezentációt lemezre menti PPTX fájlként.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A kördiagram](pie_chart.png)

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használhatók, ahol az értékek időbeli változását szeretné bemutatni. Egy vonaldiagram segítségével egyszerre nagy mennyiségű adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti az anomáliákat az adatcsorozatokban, és még sok minden mást.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Line` típust.
1. Érje el a diagram adatkönyvtárát ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre vonaldiagram:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Alapértelmezés szerint a vonaldiagram pontjait egyenes, folytonos vonalak kötik össze. Ha pontok helyett szaggatott vonalat szeretne, adja meg a kívánt szaggatott típust a következőképpen:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Az eredmény:

![A vonaldiagram](line_chart.png)

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább eladási adatokhoz alkalmasak, amikor a különböző adatkategóriák relatív méretét szeretné megjeleníteni, és gyorsan felhívni a figyelmet az egyes kategóriákban nagy hozzájáruló elemekre.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Treemap` típust.
1. Érje el a diagram adatkönyvtárát ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre fa térkép diagram:

```c#
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

![A fa térkép diagram](treemap_chart.png)

### **Részvénydiagramok létrehozása**

A részvénydiagramok pénzügyi adatokat, például nyitó, legmagasabb, legalacsonyabb és záró árakat jelenítenek meg, segítve a piaci trendek és volatilitás elemzését. Alapvető betekintést nyújtanak a részvény teljesítményébe, támogatva a befektetőket és elemzőket a megalapozott döntéshozatalban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.OpenHighLowClose` típust.
1. Érje el a diagram adatkönyvtárát ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Adja meg a HiLowLines formátumot.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre részvénydiagram:

```c#
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

![A részvénydiagram](stock_chart.png)

### **Doboz‑ és siklógörbe diagramok létrehozása**

A doboz‑ és siklógörbe diagramok az adat eloszlását jelenítik meg, összefoglalva a kulcsfontosságú statisztikai mutatókat, például a mediánt, a kvartiliseket és a lehetséges kiugró értékeket. Különösen hasznosak felderítő adatelemzések és statisztikai vizsgálatok során, hogy gyorsan megértsük az adat variabilitását és azonosítsuk az anomáliákat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.BoxAndWhisker` típust.
1. Érje el a diagram adatkönyvtárát ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre doboz‑ és siklógörbe diagram:

```c#
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

### **Tölcsérdiagramok létrehozása**

A tölcsérdiagramok a folyamatok szekvenciális szakaszainak vizualizálására szolgálnak, ahol az adatmennyiség csökken a lépésről lépésre haladva. Különösen hasznosak a konverziós arányok elemzésében, a szűk keresztmetszetek azonosításában és az értékesítési vagy marketing folyamatok hatékonyságának nyomon követésében.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Funnel` típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre tölcsérdiagram:

```c#
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

![A tölcsérdiagram](funnel_chart.png)

### **Napkitörés diagramok létrehozása**

A napkitörés diagramok hierarchikus adatokat jelenítenek meg, szintjeiket koncentrikus gyűrűkkel ábrázolva. Segítenek bemutatni a rész‑a‑teljes egész kapcsolatot, és ideálisak beágyazott kategóriák és alkategóriák tiszta, tömör ábrázolására.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.Sunburst` típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre napkitörés diagram:

```c#
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

![A napkitörés diagram](sunburst_chart.png)

### **Hisztogram diagramok létrehozása**

A hisztogram diagramok a numerikus adatok eloszlását ábrázolják, az értékeket tartományokba vagy „bin”‑ekbe csoportosítva. Különösen hasznosak a gyakoriság, a ferdeség és a szórás mintáinak azonosításában, valamint a kiugró értékek felfedezésében egy adathalmazban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.Histogram` típust.
1. Érje el a diagram adatkönyvtárát ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre hisztogram diagram:

```c#
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

### **Radar diagramok létrehozása**

A radar diagramok többváltozós adatokat jelenítenek meg kétdimenziós formában, lehetővé téve több változó egyszerre történő összehasonlítását. Különösen hasznosak a minták, erősségek és gyengeségek azonosításában több teljesítménymutató vagy attribútum esetén.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a `ChartType.Radar` típust.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre radar diagram:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A radar diagram](radar_chart.png)

### **Többkategóriás diagramok létrehozása**

A többkategóriás diagramok több kategóriacsoportot tartalmazó adatokat jelenítenek meg, lehetővé téve az értékek összehasonlítását több dimenzióban egyszerre. Különösen hasznosak komplex, többrétegű adathalmazok trendjeinek és összefüggéseinek elemzéséhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a `ChartType.ClusteredColumn` típust.
1. Érje el a diagram adatkönyvtárát ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)).
1. Törölje az alapértelmezett sorozatot és kategóriát.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre többkategóriás diagram:

```c#
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

    // Diagrammal együtt menti a prezentációt.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A többkategóriás diagram](multi_category_chart.png)

### **Térkép diagramok létrehozása**

A térkép diagramok földrajzi adatokat ábrázolnak, az információkat konkrét helyekhez – országokhoz, államokhoz vagy városokhoz – rendelve. Különösen hasznosak regionális trendek, demográfiai adatok és térbeli eloszlások elemzésére, egyértelmű, látványos módon.

Ez a C# kód bemutatja, hogyan hozható létre térkép diagram:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A térkép diagram](map_chart.png)

### **Kombinációs diagramok létrehozása**

A kombinációs diagram (vagy combo diagram) két vagy több diagramtípust egyesít egyetlen grafikonon. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja a különböző adatcsoportok közti különbségeket, segítve a közötti kapcsolatok felismerését.

![A kombinációs diagram](combination_chart.png)

Az alábbi C# kód bemutatja, hogyan hozható létre a fent látható kombinációs diagram egy PowerPoint‑prezentációban:

```c#
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

    // Az első sorozat hozzáadása
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

Az Aspose.Slides for .NET lehetővé teszi a PowerPoint diagramok frissítését diagramadatok, formázás és stílus módosításával. Ez a funkció egyszerűsíti a prezentációk dinamikus tartalmakkal való naprakészen tartását, és biztosítja, hogy a diagramok pontosan tükrözzék az aktuális adatokat és a vizuális szabványokat.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályt, amely a diagramot tartalmazó prezentációt képviseli.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Járja be az összes alakzatot a diagram megtalálásához.
1. Érje el a diagram adatmunkalapját.
1. Módosítsa a diagram adatcsorozatait a sorozatértékek módosításával.
1. Adjon hozzá egy új sorozatot, és töltse fel az adatait.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan frissíthető egy diagram:

```c#
const string chartName = "My chart";

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Eléri az első diát.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Beállítja a diagram adatlapjának indexét.
            int worksheetIndex = 0;

            // Lekéri a diagram adatkönyvtárát.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Módosítja a diagram kategória neveit.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Lekéri az első diagram sorozatot.
            IChartSeries series = chart.ChartData.Series[0];

            // Frissíti a sorozat adatait.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // A sorozat nevét módosítja.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Lekéri a második diagram sorozatot.
            series = chart.ChartData.Series[1];

            // Frissíti a sorozat adatait.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // A sorozat nevét módosítja.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Új sorozat hozzáadása.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Feltölti a sorozat adatait.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Mentse a diagramot tartalmazó prezentációt.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Adattartomány beállítása egy diagramhoz**

Az Aspose.Slides for .NET rugalmasságot biztosít egy munkalap adott adattartományának diagramadatforrásként való meghatározásához. Ez azt jelenti, hogy közvetlenül leképezhet egy munkalap szeletet a diagramra, így szabályozhatja, mely cellák járulnak hozzá a diagram sorozataihoz és kategóriáihoz. Ennek eredményeként könnyedén frissítheti és szinkronizálhatja diagramjait a munkalap legújabb adataival, biztosítva, hogy PowerPoint‑prezentációi naprakész és pontos információkat tartalmazzanak.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályt, amely a diagramot tartalmazó prezentációt képviseli.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Járja be az összes alakzatot a diagram megtalálásához.
1. Érje el a diagram adatát, és állítsa be a tartományt.
1. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan állítható be egy diagram adattartománya:

```c#
const string chartName = "My chart";

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Eléri az első diát.
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

Alapértelmezett jelölőket használva a diagram minden sorozata automatikusan más‑más alapértelmezett jelölőszimbólumot kap.

Ez a C# kód bemutatja, hogyan állítható be egy diagram sorozatának jelölője automatikusan:

```c#
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

    // A sorozat adatait tölti fel.
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

Az Aspose.Slides for .NET széles körű diagramtípusokat támogat, beleértve az oszlop, vonal, kör, terület, szórás, hisztogram, radar és még sok más típusát. Ez a rugalmasság lehetővé teszi, hogy az adatvizualizálási igényeihez leginkább megfelelő diagramot válassza.

**Hogyan adhatok hozzá új diagramot egy diára?**

Diagram hozzáadásához először hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, szerezze meg a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típusát és a kezdeti adatokat. Ez a folyamat közvetlenül integrálja a diagramot a prezentációba.

**Hogyan frissíthetem egy diagram megjelenített adatait?**

A diagram adatait a diagram adatkönyvtárának ([IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/)) elérésével, az alapértelmezett sorozatok és kategóriák törlésével, majd saját adatok hozzáadásával frissítheti. Így programozottan frissítheti a diagramot, hogy tükrözze a legújabb adatokat.

**Testreszabható-e a diagram megjelenése?**

Igen, az Aspose.Slides for .NET kiterjedt testreszabási lehetőségeket kínál. Színek, betűtípusok, címkék, jelmagyarázatok és egyéb formázási elemek módosításával a diagram megjelenését az Ön konkrét tervezési követelményeihez igazíthatja.