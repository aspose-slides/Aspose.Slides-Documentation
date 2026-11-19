---
title: ".NET'te Sunumlarda 3B Grafikleri Özelleştirme"
linktitle: "3B Grafik"
type: docs
url: /tr/net/3d-chart/
keywords:
- "3B grafik"
- "döndürme"
- "derinlik"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında 3B grafikler oluşturun. C# örnekleriyle döndürmeyi, yükseklik oranlarını, grafik derinliğini ve seriler arasındaki boşluğu ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for .NET, 3B bir grafik görünümünü [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) özelliği aracılığıyla özelleştirmenizi sağlar. Bu makale, döndürmeyi, yükseklik oranlarını, derinliği, dik açılı eksenleri ve seriler arasındaki boşluğu ayarlamayı ve ardından sunumu PPTX formatında kaydetmeyi gösterir.

## **3B Grafiğin Döndürmesini ve Derinliğini Ayarlama**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturur ve [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) kullanarak ilk slaytına yığılmış bir 3B sütun grafiği ekler. Varsayılan serileri ve kategorileri, her biri üç değer içeren iki seriyle değiştirir. Çalışma sayfası indeksi `0`, grafiğin ilk veri çalışma sayfasını tanımlar; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

[RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) ve [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) özellikleri, grafiğin döndürmesini sırasıyla 40 ve 270 derece olarak ayarlar. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) derinliğini genişliğinin %150'si olarak belirler, [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) ise perspektif yerine dik açılı eksenleri etkinleştirir. Ortaya çıkan sunum, bu 3B görüntü ayarlarıyla doldurulmuş grafiği içerir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **3B Grafiğin Yükseklik Oranlarını Ayarlama**

[IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) kullanarak bir 3B grafiğin yüksekliğini genişliğinin yüzdesi olarak ayarlayabilirsiniz. Bu, slayttaki grafik nesnesinin boyutunu değiştirmeden 3B sahnenin oranlarını değiştirir.

Aşağıdaki örnek, varsayılan veriyle bir [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) grafiği oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunum kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, döndürme, derinlik, seri aralığı ve biçimlendirme üç dosyada da aynıdır; sadece yükseklik yüzdesi değişir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

Aşağıdaki görseller, oluşturulan sunumlardan Microsoft PowerPoint kullanılarak dışa aktarıldı. Daha küçük bir yüzde daha düz bir sahne üretirken, daha büyük bir yüzde aynı grafik nesnesi içinde daha yüksek bir sahne üretir. PowerPoint, sahneye uyması için eksen işaretçi aralıklarını ve etiket yerleşimini de ayarlayabilir.

| Yükseklik: 50% | Yükseklik: 100% | Yükseklik: 200% |
| --- | --- | --- |
| ![3D sütun grafiği yüksekliği, genişliğinin %50'sine ayarlanmış](height_percent_50.png) | ![3D sütun grafiği yüksekliği, genişliğinin %100'sine ayarlanmış](height_percent_100.png) | ![3D sütun grafiği yüksekliği, genişliğinin %200'sine ayarlanmış](height_percent_200.png) |

Bu özellikler, grafiğin farklı yönlerini kontrol eder:

| Özellik | Etki |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | 3B sahnenin yüksekliği, genişliğinin yüzdesi olarak. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | Slayttaki grafik nesnesinin yüksekliği, puan cinsinden. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | 3B sahnenin derinliği, genişliğinin yüzdesi olarak. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzdesi olarak. |

Yükseklik ayarı, silindir, koni ve piramit varyantlarını içeren 3B sütun ve çubuk grafiklerini, ayrıca 3B çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma doğrulanmış `Column3D` türünü kullanır. Ayar, 2B `ClusteredColumn` grafiğinin veya `BubbleWith3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumünün üyeleridir. Diğer grafik görünüm ayarları için [Grafik Biçimlendirme](/slides/tr/net/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) kullanarak bir 3B grafiğin derinlik ekseni boyunca veri serileri arasındaki mesafeyi, işaretçi genişliğinin yüzdesi olarak kontrol edebilirsiniz. **0 ile 500** arasında değerler kullanın: `0` boşluğu kaldırır, daha büyük değerler aralığı artırır. Sabit bir grafik derinliğiyle, boşluğun artırılması işaretçileri derinlik ekseninde daha ince yapar.

[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) üzerinden gruba erişin. Ayar, o gruptaki tüm serilere uygulanır, sadece erişim için kullanılan seriye değil. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) yalnızca okunabilir ve üst grup ayarını yansıtır.

Bu ayar, silindir, koni ve piramit varyantlarını içeren 3B sütun ve çubuk grafiklerini, ayrıca 3B çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlik, kümelenmiş veya yığılmış olmasına bağlıdır. Ayrı seriler arasındaki boşlukları net bir şekilde karşılaştırmak için [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumundan `ChartType.Column3D` kullanın.

Bu özellikler, grafiğin farklı yönlerini kontrol eder:

| Özellik | Etki |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzdesi olarak. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | Yakın komşu çubuk veya sütun kümeleri arasındaki boşluk, çubuk veya sütun genişliğinin yüzdesi olarak. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | Genel grafik derinliği, grafik genişliğinin yüzdesi olarak. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verisini kullanır. Veri, döndürme, boşluk genişliği ve grafik derinliği aynı olan iki sunum kaydeder; sadece boşluk derinliği değişir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

Aşağıdaki görseller, oluşturulan sunumlardan Microsoft PowerPoint kullanılarak dışa aktarıldı.

| Boşluk derinliği: 0% | Boşluk derinliği: 500% |
| --- | --- |
| ![3D sütun grafiği, derinlik ekseni boyunca seriler arasında boşluk yok](gap_depth_0.png) | ![3D sütun grafiği, derinlik ekseni boyunca seriler arasında %500 boşluk](gap_depth_500.png) |

## **3B Seri Türünü ve Çubuk Şekli Değiştirme**

Kümelenmiş silindir grafiğinde, ilk seri silindirik çubuk şekliyle başlar. Örnek, her değişiklikten önce ve sonra [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) ve [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) okur.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| İlk seride yapılan değişiklik | `Type` | `Bar3DShape` |
| --- | --- | --- |
| Grafiği oluştur | `ClusteredCylinder` | `Cylinder` |
| `Type` değerini `ClusteredCone` olarak ayarla | `ClusteredCone` | `Cone` |
| `Bar3DShape` değerini `Box` olarak ayarla | `ClusteredColumn3D` | `Box` |

Şekli `Box` olarak ayarlamak aynı zamanda seri türünü `ClusteredColumn3D` olarak değiştirir. Kodunuz seri türüne göre dallanıyorsa, şekli değiştirdikten sonra `series.Type` değerini okuyun. Atamadan önce önbelleğe alınmış bir değer hâlâ `ClusteredCone` dalını seçecektir.

![PowerPoint karşılaştırması, ilk seriyi soldan sağa silindir, koni ve dikdörtgen sütun olarak gösterir](series-shapes.png)

## **SSS**

**Aspose.Slides'ta hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Sütun 3D, Kümelenmiş Sütun 3D, Yığılmış Sütun 3D ve %100 Yığılmış Sütun 3D gibi sütun grafiklerinin 3D varyantlarını, ayrıca [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumü aracılığıyla sunulan ilgili 3D türlerini destekler. Tam ve güncel liste için, kurulu sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) ile görüntüye dışa aktarabilir veya tüm slaytı [tüm slaytı render et](/slides/tr/net/convert-powerpoint-to-png/) ile PNG ya da JPEG gibi formatlara dönüştürebilirsiniz. Bu, bir raster ön izleme gerektiğinde veya grafiği belgeler, gösterge panoları veya web sayfalarına PowerPoint gerektirmeden yerleştirmek istediğinizde yararlıdır.

**Büyük 3D grafiklerin oluşturulması ve render edilmesi ne kadar performanslıdır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimumda tutun, duvar ve çizim alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri noktası sayısını sınırlayın ve hedef görüntüleme veya baskı ihtiyacına uygun bir çözünürlük ve boyutta çıktı üretmek için render edin.