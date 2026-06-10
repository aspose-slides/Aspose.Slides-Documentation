---
title: Diagram adatcímkék kezelése prezentációkban .NET-ben
linktitle: Adatcímke
type: docs
url: /hu/net/chart-data-label/
keywords:
- diagram
- adatcímke
- adatpontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for .NET segítségével, hogy a diák vonzóbbak legyenek."
---
## **Bevezetés**

A diagramon megjelenő adatcímkék részleteket mutatnak a diagram adatcsoportjáról vagy az egyes adatpontokról. Segítik az olvasókat gyorsan azonosítani az adatcsoportokat, és könnyebbé teszik a diagramok megértését.

## **Adatpontosság beállítása a diagram adatcímkéiben**

Ez a C# kód megmutatja, hogyan állítható be az adatpontosság egy diagram adatcímkében:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Százalék megjelenítése címkékként**

Az Aspose.Slides for .NET lehetővé teszi százalékcímkék beállítását a megjelenített diagramokban. Ez a C# kód szemlélteti a műveletet:

```c#
// Létrehozza a Presentation osztály egy példányát
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// Elmenti a diagramot tartalmazó prezentációt
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Százalékjel beállítása diagram adatcímkékkel**

Ez a C# kód megmutatja, hogyan állítható be a százalékjel egy diagram adatcímkében:

```c#
// Létrehozza a Presentation osztály egy példányát
Presentation presentation = new Presentation();

// Lekéri a diák referenciáját indexe alapján
ISlide slide = presentation.Slides[0];

// Létrehozza a PercentsStackedColumn diagramot egy dián
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Beállítja a NumberFormatLinkedToSource értékét false-ra
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Lekéri a diagram adat munkalapját
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Új sorozatot ad hozzá
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Beállítja a sorozat kitöltő színét
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Beállítja a LabelFormat tulajdonságokat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Új sorozatot ad hozzá
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Beállítja a kitöltés típusát és színét
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// A prezentációt lemezre menti
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Címke távolságának beállítása egy tengelytől**

Ez a C# kód megmutatja, hogyan állítható be a címke távolsága egy kategória tengelytől, amikor tengelyek közül felépített diagrammal dolgozunk:

```c#
// Létrehozza a Presentation osztály egy példányát
Presentation presentation = new Presentation();

// Lekéri egy dia referenciáját
ISlide sld = presentation.Slides[0];

// Létrehozza a diagramot a dián
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Beállítja a címke távolságát egy tengelytől
ch.Axes.HorizontalAxis.LabelOffset = 500;

// A prezentációt lemezre menti
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Címke helyének állítása**

Ha olyan diagramot hozunk létre, amely nem támaszkodik semmilyen tengelyre, például kördiagramot, a diagram adatcímkéi túl közel kerülhetnek a széleihez. Ilyen esetben a címke helyzetét kell módosítani, hogy a vezető vonalak tisztán megjelenjenek.

Ez a C# kód megmutatja, hogyan állítható be a címke helye egy kördiagramon:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan akadályozhatom meg, hogy az adatcímkék összemosódjanak sűrű diagramokon?**

Kombinálja az automatikus címkeelhelyezést, a vezető vonalakat és a kisebb betűméretet; szükség esetén rejtse el egyes mezőket (például a kategóriát), vagy csak a szélső/kulcsfontosságú pontoknál jelenítse meg a címkéket.

**Hogyan tilthatom le a címkéket csak nulla, negatív vagy üres értékeknél?**

Szűrje le az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést 0, negatív vagy hiányzó értékek esetén egy meghatározott szabály szerint.

**Hogyan biztosíthatom a konzisztens címkestílust PDF/képek exportálásakor?**

Állítsa be kifejezetten a betűtípusokat (család, méret), és ellenőrizze, hogy a betűtípus elérhető legyen a renderelés oldalán, így elkerülve a visszaesést.