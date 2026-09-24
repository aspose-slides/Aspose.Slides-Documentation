---
title: .NET'te Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/net/chart-data-table/
keywords:
- grafik verileri
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ve C# kullanarak PowerPoint sunumlarında grafik veri tablosu yazı tiplerini, kenarlıklarını ve lejand anahtarlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for .NET, bir grafik veri tablosunu görüntülemenizi ve metin biçimlendirmesini, kenarlıklarını ve lejand anahtarlarını özelleştirmenizi sağlar. Bu makale, tabloyu nasıl etkinleştireceğinizi, metnini nasıl biçimlendireceğinizi, her kenarlık tipini nasıl kontrol edeceğinizi ve lejand anahtarlarını nasıl göstereceğinizi veya gizleyeceğinizi açıklar. Örnekler, yapılandırılmış grafikleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarla**

Bir grafik veri tablosunu görüntülemek için, [HasDataTable](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/hasdatatable/) özelliğini `true` olarak ayarlayın. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [ChartDataTable](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/chartdatatable/) kullanın.

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.
1. İlk slayta bir kümelenmiş sütun grafiği ekleyin.
1. Grafiğin veri tablosunu etkinleştirin.
1. [FontBold](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/fontbold/) ile kalın metni etkinleştirin ve 20 puanlık metin için [FontHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/fontheight/) özelliğini `20` olarak ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, çalışma dizininde en az bir slaytı olan `test.pptx` dosyasını gerektirir. Varsayılan verilerle (50, 50) konumunda, 600 puan genişliğinde ve 400 puan yüksekliğinde bir grafik ekler. Kaydedilen `output.pptx`, veri tablosu etkinleştirilmiş grafik ve belirtilen yazı tipi ayarlarını içerir.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Veri Tablosu Kenarlıklarını Özelleştir**

Tabloyu, [IChart.HasDataTable](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/hasdatatable/) ile etkinleştirin ve [IChart.ChartDataTable](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/chartdatatable/) aracılığıyla erişin. Üç kenarlık türünü bağımsız olarak kontrol edebilirsiniz:

- [HasBorderHorizontal](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatatable/hasborderhorizontal/) yatay hücre kenarlıklarını kontrol eder.
- [HasBorderVertical](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatatable/hasbordervertical/) dikey hücre kenarlıklarını kontrol eder.
- [HasBorderOutline](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatatable/hasborderoutline/) tablonun dış kenarlığını kontrol eder.

Her özelliği `true` olarak ayarlayarak kenarlıkları gösterin veya `false` olarak ayarlayarak gizleyin. Aşağıdaki örnek, varsayılan verilerle bir kümelenmiş sütun grafiği oluşturur, yatay kenarlıkları ve dış kenarlığı gösterir, dikey kenarlıkları gizler. Girdi dosyası gerektirmez. Grafiğin konumu ve boyutu puan cinsinden belirtilir.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Aşağıdaki karşılaştırma, dört durumda da aynı grafik verilerini ve lejand anahtarı ayarını kullanır. Tüm kenarlıkların etkin olduğu durumdan başlayarak, kalan her varyant sadece bir kenarlık özelliğini devre dışı bırakır. Sol alt varyant, örnekteki kenarlık ayarlarıyla eşleşir.

![Grafik veri tabloları, tüm kenarlıklar etkin, yatay kenarlık yok, dikey kenarlık yok ve dış kenarlık yok](data-table-borders.png)

## **Lejant Anahtarlarını Göster veya Gizle**

Lejant anahtarları, veri tablosundaki seri adlarının yanında bulunan küçük renkli işaretçilerdir. Okuyucuların her tablo satırını bir grafik serisiyle eşleştirmesine yardımcı olurlar. Bu işaretçileri göstermek için [ShowLegendKey](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/idatatable/showlegendkey/) özelliğini `true`, gizlemek için `false` olarak ayarlayın.

Grafiğin ayrı lejandı, [IChart.HasLegend](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichart/haslegend/) ile kontrol edilir. Bu ayarlar bağımsızdır: ayrı lejandı gizlemek veri tablosundaki anahtarları gizlemez ve tablo anahtarlarını gizlemek ayrı lejandı gizlemez.

Aşağıdaki örnek, varsayılan verilerle bir grafik oluşturur, veri tablosunu etkinleştirir ve ayrı lejandı gizlerken içinde lejand anahtarlarını gösterir. Tüm tablo kenarlıkları açıkça etkinleştirilir. Girdi sunumu gerekmez. Sadece tablonun anahtarlarını gizlemek için `dataTable.ShowLegendKey` değerini `false` olarak değiştirin.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Aşağıdaki karşılaştırma, lejand anahtarları etkin ve devre dışı bırakılmış aynı tabloyu gösterir. Tüm kenarlıklar etkin kalır ve ayrı grafik lejandı her iki durumda da gizlidir.

![Grafik veri tabloları, sol tarafta lejand anahtarları gösterilirken sağ tarafta gizlidir](data-table-legend-keys.png)

## **SSS**

**Grafikteki veri tablosunda lejand anahtarlarını gösterebilir miyim?**  
Evet. Lejant anahtarlarını görüntülemek için [ShowLegendKey](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/datatable/showlegendkey/) özelliğini `true`, gizlemek için `false` olarak ayarlayın.

**Sunumu PDF, HTML veya görüntülere aktarırken veri tablosu korunacak mı?**  
Evet. Aspose.Slides, grafiği ve görüntülenen veri tablosunu slaytın bir parçası olarak [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/net/convert-powerpoint-to-html/) veya [görüntüler](/slides/tr/net/convert-powerpoint-to-png/) formatına aktarırken render eder.

**Şablondan yüklenen grafiklerde veri tabloları ile çalışabilir miyim?**  
Evet. Mevcut bir sunumdan veya şablondan yüklenen bir grafik için, veri tablosunun görüntülenip görüntülenmediğini kontrol etmek veya değiştirmek üzere [HasDataTable](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/hasdatatable/) kullanın.

**Veri tablosu etkin olan grafikleri nasıl bulabilirim?**  
Her slayttaki şekilleri döngüyle gezerek grafikleri belirleyin ve [HasDataTable](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chart/hasdatatable/) özelliklerini kontrol edin. `true` değeri, veri tablosunun etkin olduğunu gösterir.