---
title: Hantera diagramdatamarkörer i presentationer i .NET
linktitle: Datamarkör
type: docs
url: /sv/net/chart-data-marker/
keywords:
- diagram
- datapunkt
- markör
- marköralternativ
- markörstorlek
- fyllningstyp
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du anpassar diagramdatamarkörer i Aspose.Slides för .NET, vilket ökar presentationens genomslag i PPT- och PPTX-format med tydliga C#-kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramdatamarkörer i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, applicerar bildfyllningar på markörer på datapunktsnivå, justerar markörens storlek och sparar den uppdaterade presentationen. Den noterar också att standardmarkörformer finns tillgängliga via `MarkerStyleType`‑enumerationen och att markörens utseende bevaras när diagram exporteras till rasterformat eller SVG.

## **Ställ in diagrammarköralternativ**
Markörerna kan ställas in på diagramdatapunkter i specifika serier. För att ställa in diagrammarköralternativ, följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-klassen.
- Skapa standarddiagrammet.
- Ställ in bilden.
- Hämta den första diagramserien.
- Lägg till en ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi ställt in diagrammarköralternativ på datapunktsnivå.

```c#
// Skapa en instans av Presentation‑klassen
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Skapar standarddiagrammet
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Hämtar standardarbetsbladets index för diagramdata
int defaultWorksheetIndex = 0;

// Hämtar diagrammets dataarbetsblad
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Ta bort demoserien
chart.ChartData.Series.Clear();

// Lägg till ny serie
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Ställ in bilden
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Ställ in bilden
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Hämta den första diagramserien
IChartSeries series = chart.ChartData.Series[0];

// Lägg till ny punkt (1:3) där.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Ändrar diagramseriens markör
series.Marker.Size = 15;

// Spara presentationen till disk
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

**Vilka markörformer är tillgängliga direkt?**

Standardformer är tillgängliga (cirkel, kvadrat, diamant, triangel osv.); listan definieras av [MarkerStyleType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/markerstyletype/)-enumerationen. Om du behöver en icke‑standardform, använd en markör med bildfyllning för att efterlikna anpassade visuella element.

**Behålls markörerna vid export av ett diagram till en bild eller SVG?**

Ja. När diagram renderas till [rasterformat](/slides/sv/net/convert-powerpoint-to-png/) eller när [former sparas som SVG](/slides/sv/net/render-a-slide-as-an-svg-image/), behåller markörerna sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.