---
title: Android'de Sunumlarda Doughnut Grafiklerini Özelleştirme
linktitle: Doughnut Grafiği
type: docs
weight: 30
url: /tr/androidjava/doughnut-chart/
keywords:
- doughnut grafik
- merkez boşluğu
- delik boyutu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile doughnut grafiklerini oluşturmayı ve özelleştirmeyi keşfedin, dinamik sunumlar için PowerPoint formatlarını destekler."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir doughnut chart ile nasıl çalışılacağını, grafiği bir slayta ekleyerek, merkezindeki deliğin boyutunu ayarlayarak ve sunumu kaydederek gösterir. `setDoughnutHoleSize` metoduna odaklanır ve bu grafik türünü kod içinde özelleştirmek için gereken temel adımları gösterir.

Ayrıca, birden fazla seriyi kullanarak birden çok halka oluşturma, patlatılmış doughnut chart'larla çalışma ve bir grafiği raster görüntü veya SVG olarak dışa aktarma gibi ilgili doughnut-chart senaryolarını kapsayan kısa bir SSS içerir.

## **Halka Grafiğinde Merkez Boşluğunu Belirleme**
{{% alert color="primary" %}} 
Aspose.Slides for Android via Java artık bir doughnut chart'teki deliğin boyutunu belirlemeyi destekliyor. Bu konuda, bir doughnut chart'teki deliğin boyutunu nasıl belirleyeceğinizi bir örnekle göreceğiz.
{{% /alert %}} 

Bir doughnut chart'teki deliğin boyutunu belirtmek için, lütfen aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesi oluşturun.
1. Slayta bir doughnut chart ekleyin.
1. Halka grafiğindeki deliğin boyutunu belirleyin.
1. Sunumu diske yazın.

Aşağıdaki örnekte, bir doughnut chart'teki deliğin boyutunu ayarladık.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Sunumu diske yaz
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Birden çok halka ile çok seviyeli bir doughnut oluşturabilir miyim?**

Evet. Tek bir doughnut chart'a birden çok seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyondaki sırasına göre belirlenir.

**"Patlatılmış" bir doughnut (ayrılmış dilimler) destekleniyor mu?**

Evet. Bir Patlatılmış Doughnut [chart type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) ve veri noktalarında bir patlama özelliği vardır; tek tek dilimleri ayırabilirsiniz.

**Bir rapor için doughnut chart'ın (PNG/SVG) görüntüsünü nasıl alabilirim?**

Bir chart bir şekildir; bunu bir [raster image](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) olarak işleyebilir veya chart'ı bir [SVG image](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) olarak dışa aktarabilirsiniz.