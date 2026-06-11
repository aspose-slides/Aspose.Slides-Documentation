---
title: Anpassa 3D-diagram i presentationer i .NET
linktitle: 3D-diagram
type: docs
url: /sv/net/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar 3D-diagram i Aspose.Slides för .NET, med stöd för PPT- och PPTX-filer—höj dina presentationer idag."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar ett 3D-diagram i Aspose.Slides genom att konfigurera `Rotation3D`-inställningar såsom `RotationX`, `RotationY`, `DepthPercents` och `RightAngleAxes`. Den går igenom hur man skapar en presentation, lägger till ett 3D-diagram med standarddata, tillämpar de erforderliga 3D‑vyinställningarna och sparar den ändrade presentationen som en PPTX‑fil.

## **Ställ in egenskaperna RotationX, RotationY och DepthPercents för ett 3D‑diagram**
Aspose.Slides för .NET tillhandahåller ett enkelt API för att ställa in dessa egenskaper. Följande artikel hjälper dig att sätta olika egenskaper som X‑Y‑rotation, **DepthPercents** etc. Exempelkoden visar hur man tillämpar de ovan nämnda egenskaperna.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Ställ in Rotation3D‑egenskaper.
1. Skriv den ändrade presentationen till en PPTX‑fil.

```c#
// Skapa en instans av Presentation-klassen
Presentation presentation = new Presentation();
           
// Hämta den första bilden
ISlide slide = presentation.Slides[0];

// Lägg till ett diagram med standarddata
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Ställer in indexet för diagrammets datablad
int defaultWorksheetIndex = 0;

// Hämtar diagrammets datablad
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Add series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Lägg till kategorier
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Ställ in Rotation3D-egenskaper
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Hämta den andra diagramserien
IChartSeries series = chart.ChartData.Series[1];

// Nu fyller vi i seriedata
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Ställ in Overlap-värde
series.ParentSeriesGroup.Overlap = 100;         

// Spara presentationen till disk
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Vilka diagramtyper stöder 3D‑läge i Aspose.Slides?**

Aspose.Slides stöder 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via uppräkningen [ChartType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/). För en exakt och aktuell lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild via [chart API](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/) eller [rendera hela bilden](/slides/sv/net/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en pixel‑perfekt förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att behöva PowerPoint.

**Hur presterar byggande och rendering av stora 3D‑diagram?**

Prestandan beror på datamängd och visuell komplexitet. För bästa resultat, håll 3D‑effekterna minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämplig storlek på utdata (upplösning och dimensioner) för att matcha målskärmen eller utskriftsbehoven.