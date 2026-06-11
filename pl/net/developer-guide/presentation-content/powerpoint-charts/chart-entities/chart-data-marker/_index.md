---
title: Zarządzanie znacznikami danych wykresu w prezentacjach w .NET
linktitle: Znacznik danych
type: docs
url: /pl/net/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides dla .NET, zwiększając wpływ prezentacji w formatach PPT i PPTX dzięki przejrzystym przykładom kodu C#."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienia obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika i zapisać zaktualizowaną prezentację. Zawiera również informację, że standardowe kształty znaczników są dostępne poprzez wyliczenie `MarkerStyleType` oraz że wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw opcje znaczników wykresu**
Znaczniki można ustawiać na punktach danych wykresu w obrębie określonej serii. Aby ustawić opcje znaczników wykresu, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Utwórz domyślny wykres.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje znaczników wykresu na poziomie punktów danych.

```c#
// Utwórz instancję klasy Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Tworzenie domyślnego wykresu
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Pobieranie indeksu domyślnego arkusza danych wykresu
int defaultWorksheetIndex = 0;

// Pobieranie arkusza danych wykresu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Usuń przykładową serię
chart.ChartData.Series.Clear();

// Dodaj nową serię
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Ustaw obraz
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Ustaw obraz
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Pobierz pierwszą serię wykresu
IChartSeries series = chart.ChartData.Series[0];

// Dodaj nowy punkt (1:3) w tym miejscu.
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

// Zmiana znacznika serii wykresu
series.Marker.Size = 15;

// Zapisz prezentację na dysku
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Standardowe kształty są dostępne (koło, kwadrat, romb, trójkąt itp.); lista jest zdefiniowana przez wyliczenie [MarkerStyleType](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/markerstyletype/). Jeśli potrzebny jest niestandardowy kształt, użyj znacznika z wypełnieniem obrazem, aby emulować własne elementy wizualne.

**Czy znaczniki są zachowywane przy eksporcie wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [formatów rastrowych](/slides/pl/net/convert-powerpoint-to-png/) lub zapisywania [kształtów jako SVG](/slides/pl/net/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obrys.