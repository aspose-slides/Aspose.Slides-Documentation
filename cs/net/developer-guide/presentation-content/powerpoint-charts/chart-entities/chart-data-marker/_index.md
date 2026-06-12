---
title: Správa označovačů dat v grafech v prezentacích v .NET
linktitle: Datový označovač
type: docs
url: /cs/net/chart-data-marker/
keywords:
- graf
- datový bod
- označovač
- možnosti označovače
- velikost označovače
- typ výplně
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak přizpůsobit označovače dat v grafech v Aspose.Slides pro .NET, zvýšit dopad prezentací v formátech PPT a PPTX pomocí přehledných ukázek kódu v C#."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s označovači dat v grafech v Aspose.Slides. Ukazuje, jak vytvořit graf, získat přístup k řadě a jejím datovým bodům, použít vyplnění obrázkem na označovače na úrovni datového bodu, upravit velikost označovače a uložit aktualizovanou prezentaci. Také upozorňuje, že standardní tvary označovačů jsou k dispozici prostřednictvím výčtu `MarkerStyleType` a že vzhled označovače je zachován při exportu grafů do rastrálních formátů nebo SVG.

## **Nastavení možností označovačů grafu**
Označovače lze nastavit na datových bodech grafu v konkrétních řadách. Pro nastavení možností označovačů grafu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
- Vytvoření výchozího grafu.
- Nastavte obrázek.
- Získejte první řadu grafu.
- Přidejte nový datový bod.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili možnosti označovačů grafu na úrovni datových bodů.

```c#
// Vytvořte instanci třídy Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Vytvoření výchozího grafu
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Získání indexu výchozího listu dat grafu
int defaultWorksheetIndex = 0;

// Získání listu dat grafu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Odstraňte ukázkovou řadu
chart.ChartData.Series.Clear();

// Přidejte novou řadu
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Nastavte obrázek
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Nastavte obrázek
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Získejte první řadu grafu
IChartSeries series = chart.ChartData.Series[0];

// Přidejte nový bod (1:3) tam.
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

// Změna označovače řady grafu
series.Marker.Size = 15;

// Uložte prezentaci na disk
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Jaké tvary označovačů jsou k dispozici přímo z krabice?**

Standardní tvary jsou k dispozici (kruh, čtverec, diamant, trojúhelník atd.); seznam je definován výčtem [MarkerStyleType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/markerstyletype/). Pokud potřebujete nestandardní tvar, použijte označovač s vyplněním obrázkem pro napodobení vlastního vizuálu.

**Zůstávají označovače zachovány při exportu grafu do obrázku nebo SVG?**

Ano. Při vykreslování grafů do [rastrální formáty](/slides/cs/net/convert-powerpoint-to-png/) nebo ukládání [tvary jako SVG](/slides/cs/net/render-a-slide-as-an-svg-image/) si označovače zachovávají svůj vzhled a nastavení, včetně velikosti, výplně a obrysu.