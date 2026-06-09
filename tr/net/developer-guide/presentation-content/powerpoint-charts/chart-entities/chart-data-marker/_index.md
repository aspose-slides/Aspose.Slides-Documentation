---
title: Sunumlarda .NET'te Grafik Veri İşaretçilerini Yönetme
linktitle: Veri İşaretçisi
type: docs
url: /tr/net/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- doldurma türü
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te grafik veri işaretçilerini nasıl özelleştireceğinizi öğrenin, PPT ve PPTX formatlarında net C# kod örnekleriyle sunum etkisini artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik veri işaretçilerinin nasıl kullanılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve onun veri noktalarına erişmeyi, veri noktası seviyesinde işaretçilere resim doldurmayı, işaretçi boyutunu ayarlamayı ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca, standart işaretçi şekillerinin `MarkerStyleType` enum'ı aracılığıyla mevcut olduğu ve grafikler raster formatlarına veya SVG'ye dışa aktarıldığında işaretçi görünümünün korunduğu belirtilir.

## **Grafik İşaretçi Seçeneklerini Ayarlama**
İşaretçiler, belirli seriler içindeki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Resmi ayarlayın.
- İlk grafik serisini alın.
- Yeni bir veri noktası ekleyin.
- Sunumu diske yazın.

Aşağıda verilen örnekte, grafik işaretçi seçeneklerini veri noktası seviyesinde ayarladık.

```c#
// Presentation sınıfının bir örneğini oluştur
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Varsayılan grafiği oluştur
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Varsayılan grafik veri çalışma sayfası indeksini al
int defaultWorksheetIndex = 0;

// Grafik veri çalışma sayfasını al
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Demo serisini sil
chart.ChartData.Series.Clear();

// Yeni seri ekle
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Resmi ayarla
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Resmi ayarla
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// İlk grafik serisini al
IChartSeries series = chart.ChartData.Series[0];

// Oraya yeni bir nokta ekle (1:3).
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

// Grafik serisi işaretçisini değiştir
series.Marker.Size = 15;

// Sunumu diske yaz
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **SSS**

**Hangi işaretçi şekilleri kutudan çıktığı gibi mevcuttur?**

Standart şekiller mevcuttur (daire, kare, elmas, üçgen vb.); liste [MarkerStyleType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/markerstyletype/) enum'ı tarafından tanımlanır. Standart dışı bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim doldurmalı bir işaretçi kullanın.

**Bir grafik bir resim veya SVG olarak dışa aktarıldığında işaretçiler korunur mu?**

Evet. Grafikler [raster formatlarına](/slides/tr/net/convert-powerpoint-to-png/) render edildiğinde veya [şekiller SVG olarak kaydedildiğinde](/slides/tr/net/render-a-slide-as-an-svg-image/), işaretçiler boyut, dolgu ve kontur dahil görünüm ve ayarlarını korur.