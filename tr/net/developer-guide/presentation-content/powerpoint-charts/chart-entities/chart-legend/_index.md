---
title: .NET'te Sunumlarda Grafik Lejantlarını Özelleştirme
linktitle: Grafik Lejantı
type: docs
url: /tr/net/chart-legend/
keywords:
- grafik lejantı
- lejant konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile grafik lejantlarını özelleştirerek, PowerPoint sunumlarını özel lejant biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides for .NET, PowerPoint sunumlarındaki grafik lejantlarını özelleştirmek için seçenekler sunar. Bu makale, bir lejantı konumlandırma ve boyutlandırma, tüm lejant için yazı tipi boyutunu ayarlama, tekil bir lejant girdisini biçimlendirme ve seçili girdileri gizleme ya da geri getirme yollarını gösterir.

SSS, lejant için alan ayırma, çok satırlı etiket gösterimi ve sunum temasından biçimlendirme miras alma gibi ilgili davranışları kapsar.

## **Lejant Konumlandırma**

Lejantın [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) ve [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) özelliklerini kullanarak konumunu ve boyutunu, grafiğin boyutlarının kesirleri olarak belirtebilirsiniz.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan verilerle bir kümelenmiş sütun grafiği ekler. İstenen lejant kaydırma ve boyutlarını grafiğin genişlik ve yüksekliğine bölerek göreli değerler elde edilir: lejant, grafiğin sol üst köşesinden 50 puan kaydırılır ve 100 x 100 puan olarak boyutlandırılır.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Grafiğe göre lejantın konumunu ve boyutunu ifade edin.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Lejantın Yazı Tipi Boyutunu Ayarlama**

Lejantın [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) özelliğini kullanarak metin biçimlendirmesine erişebilir ve [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) değerini puan olarak ayarlayabilirsiniz.

Bu örnek, varsayılan verilerle bir grafik oluşturur ve lejant metnini 20 puan olarak ayarlar. Ayrıca dikey eksen için otomatik sınırları devre dışı bırakır ve aralığını -5 ile 10 arasında ayarlar.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Bireysel Lejant Girdisinin Yazı Tipi Boyutunu Ayarlama**

Lejantın [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) koleksiyonunu kullanarak belirli bir girdinin biçimlendirmesine erişebilirsiniz. Girdi dizinleri sıfır bazlıdır, bu yüzden `1` dizini ikinci girdiyi ifade eder.

Bu örnek, varsayılan verilerinde en az iki seri bulunan bir kümelenmiş sütun grafiği oluşturur. İkinci lejant girdisini kalın, italik ve 20 puan mavi metin olarak biçimlendirir.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Bireysel Lejant Girdilerini Gizle**

Ek bir seriyi lejanttan hariç tutup verilerini görünür tutmak için, [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) aracılığıyla [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) özelliğini `true` olarak ayarlayın. Bu, yalnızca seçilen lejant girdisini gizler; seriyi veya veri noktalarını kaldırmaz. Bunun aksine, [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) değerini `false` olarak ayarlamak tüm lejantı gizler.

Aşağıdaki örnek, varsayılan veriyle birden çok seri içeren bir kümelenmiş sütun grafiği oluşturur. İkinci serinin lejant girdisini (dizin `1`) gizler ve sunumu kaydeder. Ardından `Hide` değerini `false` olarak ayarlayarak girdiyi geri getirir ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Aynı girişi grafik verisini değiştirmeden geri yükle.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Aşağıdaki karşılaştırma, tüm girdilerin görünür olduğu ve ikinci girdinin gizlendiği aynı grafiği gösterir. İkinci serinin sütunları değişmeden kalır.

![Tüm lejant girdileri görünür ve Seri 2 lejanttan gizli olduğu bir grafiğin karşılaştırması; tüm sütunlar görünür kalır.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerde lejant girdileri serileri tanımlar. Pasta grafiklerde ise tek tek veri noktalarını (dilimleri) tanımlar, bu yüzden seçilen dilimde [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) kullanılmalıdır. API, bu veri noktası özelliğini `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` ve `BarOfPie` grafik tipleri için belgeler. Bu özelliğin, listede yer almayan halka grafiklerine (doughnut) uygulanacağını varsaymayın.

## **SSS**

**Grafik, lejantın üzerine binmek yerine lejant için alan ayırabilir mi?**

Evet. [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) özelliğini `false` olarak ayarlayarak lejantın çizim alanı üzerine binmesine izin vermek yerine lejant için yer ayırırsınız.

**Çok satırlı lejant etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, mevcut genişlik yetersiz olduğunda satır başına bölünebilir. Ayrıca seri adlarında satır sonu karakterleri kullanarak satır sonları isteyebilirsiniz.

**Lejantın sunum temasının renk şemasını izlemesini nasıl sağlayabilirim?**

Lejantın renklerini, doldurmalarını ve yazı tiplerini ayarlamadan bırakın; böylece tema biçimlendirmesini miras alır. Açıkça belirlenen biçimlendirme, ilgili tema ayarlarını geçersiz kılar.