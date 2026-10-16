---
title: ".NET'te Sunum Grafiklerine Eğri Çizgileri Ekle"
linktitle: "Eğri Çizgi"
type: docs
url: /tr/net/trend-line/
keywords:
- grafik
- eğri çizgi
- üstel eğri çizgi
- doğrusal eğri çizgi
- logaritmik eğri çizgi
- hareketli ortalama eğri çizgi
- polinom eğri çizgi
- güç eğri çizgi
- özel eğri çizgi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint grafiklerine eğri çizgileri hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine eğri çizgileri eklemenin nasıl yapılacağını açıklar. Bir grafik oluşturmayı, grafik serilerine eğri çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli eğri çizgi türleriyle çalışmayı gösterir.

Ayrıca, bir grafik üzerine çizgi şekli ekleyerek özel bir satır eklemenin nasıl yapılacağını açıklar ve ileri ve geri eğri çizgi projeksiyon değerleri ile eğri çizgilerin PDF veya SVG olarak dışa aktarılırken ve grafiklerin görüntü olarak işlendğinde korunup korunmadığına dair kısa bir SSS içerir.

## **Eğri Çizgi Ekle**

Bir grafik serisine eğri çizgi eklemek için [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) kullanın, türünü ise [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir küme sütun grafiği oluşturur ve üç serisinin her birine iki eğri çizgi ekler.

Üstel eğri çizgi, denklemini ve R‑kare değerini [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) ve [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) aracılığıyla gizler, doğrusal eğri çizgi ise kırmızıdır. Logaritmik eğri çizgi, özel bir etiket için [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) kullanır. Hareketli ortalama, üç veri noktasının [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) değerini ve özel bir [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) kullanır.

Polinom eğri çizgi, üç [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) değerine sahiptir ve bir kategori ileriye doğru [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) ile uzatılır. Güç eğri çizgi ise bir kategori geriye doğru [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/) ile uzatılır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Eğri Çizgi Kesiti Ayarla**

[Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) kullanarak bir eğri çizginin Y değerini X = 0'da sabitleyin. Bu ayar, doğrusal, üstel ve polinom eğri çizgileri için desteklenir.

Örneğin, bir üretim maliyeti modeli, ölçümler sıfır olmayan üretim hacimlerinde farklı bir temel gösterse bile, 100 gibi bilinen sabit maliyetlerle başlamalı olabilir. Doğrusal bir eğri çizgi için, kesiti sabitlemek `y = ax + b` denklemini `b = 100` olarak kısıtlar; eğim bu kısıtlama altında verilere uydurulur. Bu, zaten uydurulmuş bir çizgiyi sadece kaydırmaz. Eksen kesişim ayarları, grafik eksenlerinin nerede buluşacağını kontrol eder, uydurulmuş eğri çizginin katsayılarını değil.

Aşağıdaki örnek, 1'den 4'e kadar üretim hacimleri ve 170, 200, 230 ve 260 maliyetleri içeren bir dağılım (XY) grafiği oluşturur. Grafik, varsayılan otomatik kesit ile kaydedilir, kesit 100 olarak ayarlanır ve ikinci bir PPTX olarak kaydedilir. İki dosya yalnızca kesit ayarında farklılık gösterir. Eğri çizgi denklemini gösterir ve X = 0'a kadar geriye uzanır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Otomatik hesaplamayla, bu veriler `y = 30x + 140` sonucunu verir. Kesiti 100 olarak ayarlamak ise yaklaşık `y = 43.33x + 100` üretir: sıfırda uydurulan değer bilinen temel ile eşleşir, ancak çizgi artık her veri noktasından geçmez.

| Otomatik kesit | 100'lik sabit kesit |
| --- | --- |
| ![Otomatik olarak hesaplanan 140 kesitli doğrusal eğri çizgi](intercept-automatic.png) | ![100 sabit kesitli doğrusal eğri çizgi](intercept-fixed.png) |

Her iki görüntü de aynı veri ve eksen ölçeklerini kullanır. Eğri çizgiler, kesitlerini göstermek için X = 0'a kadar geriye uzatılmıştır.

Varsayılan olarak, özellik `double.NaN` içerir; bu, sıfır yerine belirtilmemiş bir kesiti temsil eder. Kesit daha sonra verilerden otomatik olarak hesaplanır.

## **Özel Bir Çizgi Ekle**

Özel bir çizgi, serilerden hesaplanan bir eğri çizgi yerine, grafiğin üzerine çizilen bir şekildir. Bu örnek, grafiğin üzerine bir yatay çizgi eklemek için [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) kullanır. Çizginin konumu slide koordinatlarıyla, nokta cinsinden belirtilir; bu yüzden grafiğin sol kenarından başlar ve grafiğin yarısına kadar uzanır. Genişliği grafiğin genişliğiyle aynıdır. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) çizgiye katı kırmızı bir renk verir.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **SSS**

**'İleri' ve 'geri' bir eğri çizgi için ne anlama geliyor?**

Bunlar, eğri çizginin ileri/geri projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısında ölçülür. Yalnızca negatif olmayan değerler izinlidir.

**Sunumu PDF veya SVG olarak dışa aktarırken veya bir slaytı görüntüye işlediğinizde eğri çizgi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/net/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/net/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere renderlar; eğri çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin bir görüntüsünü [grafiğin bir görüntüsünü dışa aktarmak](/slides/tr/net/create-shape-thumbnails/) için bir yöntem de mevcuttur.