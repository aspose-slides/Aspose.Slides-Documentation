---
title: Harici çalışma kitaplarına grafik bağlayın
description: Grafik verilerini harici bir çalışma kitabına bağlayın ve yenileyin.
type: docs
url: /tr/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Genel Bakış**

Bir grafiği, kaynak verilerini sunumda gömülü tutmak yerine harici bir çalışma kitabına yönlendirin. Çalışma kitabı yolunu ayarlayabilir ve grafiği o dosyadan güncelleyip güncellemeyeceğinizi seçebilirsiniz. Kaydedilen grafik ayrıca önbelleğe alınmış gösterim verilerini taşıyabilir.

## **Kullanım örneği**

Bu C# örneği Aspose.Slides for .NET kullanır. North = 55 ve South = 40 olan geçerli bir satış çalışma kitabı oluşturun ve çıktının yanına sales.xlsx olarak yazın. Grafiğin North değerini 20'ye sıfırlayın, ardından grafiği çalışma kitabının mutlak yoluna bağlayın ve yenileyin: North tekrar 55 olur. Açık aralık başlığı ve iki veri satırını kapsar. Bağlı grafiği yeniden açarken veya güncellerken sales.xlsx dosyasının erişilebilir olmasını sağlayın; sunum bu harici dosyayı gömmemiştir. Girdi dosyasına gerek yoktur. *external-chart-workbook.pptx* ve *external-chart-workbook.png* dosyalarını kaydeder. Kütüphaneyi [kurulum kılavuzu](/slides/tr/net/installation/) kullanarak kurun.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **SSS**

### **Bağlı dosya eksik olduğunda önbelleğe alınmış tüm değerleri okuyabilir miyim?**

Aspose.Slides for .NET 26.11, bağlı çalışma kitabını açmadan [saklanan grafik değerlerini doğrudan okuyabilir](/slides/tr/net/chart-workbook/#read-cached-chart-values-without-a-workbook). Bu, sıradan değerleri, X/Y değerlerini, baloncuk boyutlarını ve bu önbellekler mevcut olduğunda kategori değerlerini içerir. Önbellek verileri eksik veya eski olabilir; bu tam bir çalışma kitabı değildir. Kaynaktan yenilemek hâlâ erişilebilir bir desteklenen çalışma kitabı gerektirir. Diğer SDK'lar ve sürümler için ilgili grafik kılavuzlarını kontrol edin.

### **Harici çalışma kitabı taşınırsa ne olur?**

Grafiğin harici çalışma kitabı yolunu yeni konumuna güncelleyin ve bu dosyanın sunum işlendiği her yerde erişilebilir olmasını sağlayın. Eksik olduğunda tam veri erişim işlemleri için önbellek verilerine güvenmeyin.

### **Bağlantı kurarken önbelleğe alınmış grafik verilerini yenilemek isteyip istemediğinizi seçebilir miyim?**

Evet. Bağlantıyı ayarlarken grafik verilerini güncelleyip güncellemeyeceğinizi seçin. Yenileme, erişilebilir bir desteklenen çalışma kitabı gerektirir; yenilemeyi atlamak bağlantıyı kaydeder ancak dosyadan yeni değerleri okumaz.

## **Kılavuzlar**

- [Sunumlarda .NET'te Grafik Çalışma Kitaplarını Yönet](/slides/tr/net/chart-workbook/)

İlgili özellik: [Düzenlenebilir grafikleri veri ile doldurun](/slides/tr/features/chart-data-binding/).