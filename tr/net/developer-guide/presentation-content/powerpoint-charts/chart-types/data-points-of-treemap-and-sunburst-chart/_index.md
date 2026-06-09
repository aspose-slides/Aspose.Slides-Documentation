---
title: Treemap ve Sunburst Grafiklerinde Veri Noktalarını Özelleştirme (.NET)
linktitle: Treemap ve Sunburst Grafiklerinde Veri Noktaları
type: docs
url: /tr/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap grafik
- sunburst grafik
- veri noktası
- etiket rengi
- dal rengi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile treemap ve sunburst grafiklerdeki veri noktalarını nasıl yöneteceğinizi öğrenin, PowerPoint formatlarıyla uyumludur."
---
## **Giriş**

PowerPoint grafiklerinin diğer türleri arasında, iki adet “hiyerarşik” tür bulunmaktadır - **Treemap** ve **Sunburst** grafiği (Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph veya Multi Level Pie Chart olarak da bilinir). Bu grafikler, yapraklardan dalın tepesine kadar bir ağaç olarak düzenlenmiş hiyerarşik verileri gösterir. Yapraklar, seri veri noktalarıyla tanımlanırken, sonraki her iç içe grup seviyesi ilgili kategoriyle tanımlanır. Aspose.Slides for .NET, C#’ta Sunburst Chart ve Treemap’in veri noktalarını biçimlendirmeye olanak tanır.

İşte bir Sunburst Grafiği, Series1 sütunundaki verilerin yaprak düğümleri tanımladığı, diğer sütunların ise hiyerarşik veri noktalarını tanımladığı bir örnek:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Sunburst grafiğini sunuma ekleyerek başlayalım:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [**Sunburst Grafiği Oluşturma**](/slides/tr/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Grafiğin veri noktalarını biçimlendirme ihtiyacı varsa, aşağıdakileri kullanmalıyız:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointlevel) sınıfları ve [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) özelliği, Treemap ve Sunburst grafiklerinin veri noktalarını biçimlendirmeye erişim sağlar. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/IChartDataPointLevelsManager) multi seviyeli kategorilere erişmek için kullanılır – [**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/IChartDataPointLevel) nesnelerinin konteynerini temsil eder. Temelde, veri noktalarına özgü eklenen özelliklerle [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/IChartCategoryLevelsManager) için bir sarmalayıcıdır. [**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/IChartDataPointLevel) sınıfının iki özelliği vardır: [**Format**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointlevel/properties/format) ve [**DataLabel**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatapointlevel/properties/label) , bunlar ilgili ayarlara erişim sağlar.

## **Veri Noktasının Değerini Göster**
“Leaf 4” veri noktasının değerini göster:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Veri Noktası Etiketini ve Rengini Ayarla**
“Branch 1” veri etiketini kategori adı yerine seri adı (“Series1”) gösterecek şekilde ayarlayın. Ardından metin rengini sarıya değiştirin:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Veri Noktası Dal Rengini Ayarla**
“Stem 4” dalının rengini değiştirin:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **SSS**

**Sunburst/Treemap'teki segmentlerin sırasını (sıralamasını) değiştirebilir miyim?**

Hayır. PowerPoint segmentleri otomatik olarak sıralar (genellikle azalan değerlerle, saat yönünde). Aspose.Slides bu davranışı yansıtır: sıralamayı doğrudan değiştiremezsiniz; bunu veriyi ön işleme tabi tutarak elde edersiniz.

**Sunum teması segmentlerin ve etiketlerin renklerini nasıl etkiler?**

Grafik renkleri, doldurma/karakterleri açıkça ayarlamadığınız sürece, sunumun [tema/renk paleti](/slides/tr/net/presentation-theme/) üzerinden devralınır. Tutarlı sonuçlar için, gerekli seviyelerde katı dolgu ve metin biçimlendirmesini sabitleyin.

**PDF/PNG olarak dışa aktarma, özel dal renklerini ve etiket ayarlarını korur mu?**

Evet. Sunumu dışa aktarırken, grafik ayarları (dolgu, etiketler) çıkış formatlarında korunur; çünkü Aspose.Slides grafik formatlamasıyla render alır.

**Grafiğin üstüne özel bir katman yerleştirmek için bir etiket/elemanın gerçek koordinatlarını hesaplayabilir miyim?**

Evet. Grafik düzeni doğrulandıktan sonra, öğeler için `ActualX`/`ActualY` değerleri mevcuttur (örneğin, bir [DataLabel](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/datalabel/)), bu da katmanların hassas konumlandırılmasına yardımcı olur.