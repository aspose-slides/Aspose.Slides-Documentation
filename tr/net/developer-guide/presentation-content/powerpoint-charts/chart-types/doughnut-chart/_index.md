---
title: .NET'te Sunumlarda Halka Grafikleri Özelleştirme
linktitle: Halka Grafiği
type: docs
weight: 30
url: /tr/net/doughnut-chart/
keywords:
- halka grafik
- merkez boşluk
- delik boyutu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile halka grafiklerini nasıl oluşturacağınızı ve özelleştireceğinizi keşfedin, dinamik sunumlar için PowerPoint formatlarını destekler."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir halka grafiği ile nasıl çalışılacağını, grafiği bir slayta ekleyerek, merkezindeki deliğin boyutunu ayarlayarak ve sunumu kaydederek gösterir. `DoughnutHoleSize` ayarına odaklanır ve bu grafik tipini kodla özelleştirmek için gereken temel adımları gösterir.

Ayrıca, birden çok seriyi kullanarak birden çok halka oluşturma, patlatılmış halka grafikleriyle çalışma ve bir grafiği raster görüntü veya SVG olarak dışa aktarma gibi ilgili halka grafik senaryolarını kapsayan kısa bir SSS de içerir.

## **Halka Grafiğinde Merkez Boşluğunu Belirleme**
Bir halka grafiğindeki deliğin boyutunu belirtmek için aşağıdaki adımları izleyin:

- Presentation sınıfını örnekleyin.
- Slayta bir halka grafiği ekleyin.
- Halka grafiğindeki deliğin boyutunu belirtin.
- Sunumu diske yazın.

Aşağıda verilen örnekte, halka grafiğindeki deliğin boyutunu ayarladık.

```c#
// Presentation sınıfının bir örneğini oluştur
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Sunumu diske kaydet
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **SSS**

**Birden çok halka ile çok seviyeli bir halka oluşturabilir miyim?**

Evet. Tek bir halka grafiğine birden çok seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyondaki sırasına göre belirlenir.

**"Patlatılmış" bir halka (ayıralmış dilimler) destekleniyor mu?**

Evet. Patlatılmış Halka [grafik türü](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/charttype/) ve veri noktalarında bir patlatma özelliği vardır; bireysel dilimleri ayırabilirsiniz.

**Bir rapor için halka grafiğinin (PNG/SVG) görüntüsünü nasıl alabilirim?**

Bir grafik bir şekildir; onu bir [raster görüntü](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/getimage/) olarak işleyebilir veya grafiği bir [SVG görüntüsü](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/writeassvg/) olarak dışa aktarabilirsiniz.