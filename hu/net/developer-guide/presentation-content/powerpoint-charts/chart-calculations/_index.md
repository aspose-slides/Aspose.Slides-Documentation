---
title: Diagram számítások optimalizálása prezentációkhoz .NET-ben
linktitle: Diagram számítások
type: docs
weight: 50
url: /hu/net/chart-calculations/
keywords:
- diagram számítások
- diagram elemek
- elem pozíció
- valós pozíció
- gyermek elem
- szülő elem
- diagram értékek
- valós érték
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Értse meg a diagram számításokat, az adatok frissítését és a pontosság szabályozását az Aspose.Slides for .NET-ben PPT és PPTX esetén, gyakorlati C# kódpéldákkal."
---
## **Áttekintés**

Az Aspose.Slides API-kat biztosít a diagramok számításaihoz és az elrendezési adatokhoz a prezentációkban. Ez a cikk bemutatja, hogyan lehet lekérni a diagram elemeinek tényleges értékeit, beleértve a `IActualLayout` interfészt megvalósító elemek valós pozícióját és méretét, valamint a diagram tengelyek tényleges értékeit. Az is kiderül, hogy ezek az értékek a diagram elrendezésének ellenőrzése után kerülnek kitöltésre.

Ezen felül a cikk bemutatja, hogyan lehet lekérni a szülő diagram elemek tényleges pozícióját, valamint hogyan lehet elrejteni a diagram komponenseket, mint a cím, a tengelyek, a jelmagyarázat és a rácsvonalak. Ezek a példák együtt segítenek a diagram elrendezési információk vizsgálatában és a diagram elemek láthatóságának programozott szabályozásában a PowerPoint‑prezentációkban.

## **A diagram elemek tényleges értékeinek kiszámítása**
Az Aspose.Slides for .NET egyszerű API-t biztosít ezen tulajdonságok lekéréséhez. Ez segít a diagram elemek tényleges értékeinek kiszámításában. A tényleges értékek tartalmazzák az IActualLayout interfészt megvalósító elemek pozícióját (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight), valamint a tengelyek tényleges értékeit (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Prezentáció mentése
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **A szülő diagram elemek tényleges pozíciójának kiszámítása**
Az Aspose.Slides for .NET egyszerű API-t biztosít ezen tulajdonságok lekéréséhez. Az IActualLayout tulajdonságai információt adnak a szülő diagram elem tényleges pozíciójáról. A tulajdonságok tényleges értékekkel való feltöltéséhez előzetesen meg kell hívni az IChart.ValidateChartLayout() metódust.

```c#
// Üres prezentáció létrehozása
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **Diagram elemek elrejtése**
Ez a téma segít megérteni, hogyan lehet információkat elrejteni a diagramról. Az Aspose.Slides for .NET használatával elrejtheti a **címet, a függőleges tengelyt, a vízszintes tengelyt** és a **rácsvonalakat** a diagramról. Az alábbi kódrészlet bemutatja, hogyan használhatók ezek a tulajdonságok.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // Diagram cím elrejtése
    chart.HasTitle = false;

    /// Értéktengely elrejtése
    chart.Axes.VerticalAxis.IsVisible = false;

    // Kategória tengely láthatósága
    chart.Axes.HorizontalAxis.IsVisible = false;

    // Jelmagyarázat elrejtése
    chart.HasLegend = false;

    // Fő rácsvonalak elrejtése
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    // Sorozat vonalszín beállítása
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Külső Excel munkafüzetek használhatók adatforrásként, és ez hogyan befolyásolja az újraszámítást?**

Igen. Egy diagram hivatkozhat külső munkafüzetre: amikor csatlakozik vagy frissíti a külső forrást, a képletek és értékek a munkafüzettől származnak, és a diagram a nyitás/szerkesztés műveletei során tükrözi a frissítéseket. Az API lehetővé teszi, hogy [megadja a külső munkafüzet](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/setexternalworkbook/) útvonalát és kezelje a kapcsolt adatokat.

**Kiszámíthatok és megjeleníthetek trendvonalakat anélkül, hogy saját regressziót implementálnék?**

Igen. A [trendvonalak](/slides/hu/net/trend-line/) (lineáris, exponenciális és egyebek) hozzáadódnak és frissülnek az Aspose.Slides által; paramétereiket a sorozat adataiból automatikusan újraszámítja a rendszer, így nem szükséges saját számításokat implementálni.

**Ha egy prezentáció több diagrammal rendelkezik, amelyek külső hivatkozásokat tartalmaznak, szabályozhatom, hogy melyik munkafüzetet használja az egyes diagramok a számított értékekhez?**

Igen. Minden diagram saját [külső munkafüzettel](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/setexternalworkbook/) hivatkozhat, vagy minden diagramhoz külön‑külön létrehozhat vagy cserélhet külső munkafüzetet a többitől függetlenül.