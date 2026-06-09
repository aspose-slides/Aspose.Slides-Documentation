---
title: Java kullanarak Sunumlarda Halka Grafiklerini Özelleştirme
linktitle: Halka Grafik
type: docs
weight: 30
url: /tr/java/doughnut-chart/
keywords:
- halka grafik
- merkez boşluğu
- boşluk boyutu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da halka grafiklerini nasıl oluşturacağınızı ve özelleştireceğinizi keşfedin; dinamik sunumlar için PowerPoint formatlarını destekler."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te bir halka grafiğiyle nasıl çalışılacağını, grafiği bir slayta ekleyerek, merkez boşluğunun boyutunu ayarlayarak ve sunumu kaydederek gösterir. `setDoughnutHoleSize` yöntemine odaklanır ve kod içinde bu grafik türünü özelleştirmek için gerekli temel adımları gösterir.

Ayrıca, çoklu serilerle birden çok halka oluşturma, patlamış halka grafiklerle çalışma ve bir grafiği raster görüntü veya SVG olarak dışa aktarma gibi ilgili halka grafik senaryolarını kapsayan kısa bir SSS içerir.

## **Halka Grafiğinde Merkez Boşluğunu Belirleme**
{{% alert color="primary" %}} 

Aspose.Slides for Java artık bir halka grafiğinde boşluğun boyutunu belirlemeyi destekliyor. Bu konuda, bir örnekle halka grafiğindeki boşluğun boyutunu nasıl belirleyeceğimizi göreceğiz.

{{% /alert %}} 

Bir halka grafiğinde boşluğun boyutunu belirlemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesini örnekleyin.
1. Slayta bir halka grafiği ekleyin.
1. Halka grafiğinde boşluğun boyutunu belirleyin.
1. Sunumu diske yazın.

Aşağıda verilen örnekte, halka grafiğindeki boşluğun boyutunu ayarladık.

```java
// Presentation sınıfının bir örneğini oluşturun
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Sunumu diske kaydedin
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Birden fazla halka içeren çok seviyeli bir halka oluşturabilir miyim?**

Evet. Tek bir halka grafiğine birden fazla seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyon içindeki sırasına göre belirlenir.

**"Patlamış" bir halka (ayrılmış dilimler) destekleniyor mu?**

Evet. Bir Patlamış Halka [chart type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) ve veri noktaları için bir patlama özelliği vardır; bireysel dilimleri ayırabilirsiniz.

**Bir rapor için halka grafiğinin (PNG/SVG) görüntüsünü nasıl alabilirim?**

Bir grafik bir şekildir; onu bir [raster image](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) olarak oluşturabilir veya grafiği bir [SVG image](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) olarak dışa aktarabilirsiniz.