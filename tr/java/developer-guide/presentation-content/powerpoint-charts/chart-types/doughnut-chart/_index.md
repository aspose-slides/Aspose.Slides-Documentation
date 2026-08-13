---
title: Java Kullanarak Sunumlarda Donut Grafiklerini Özelleştirme
linktitle: Donut Grafik
type: docs
weight: 30
url: /tr/java/doughnut-chart/
keywords:
- donut grafik
- merkez boşluk
- delik boyutu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da donut grafiklerini nasıl oluşturacağınızı ve özelleştireceğinizi keşfedin; dinamik sunumlar için PowerPoint formatlarını destekler."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te bir donut (halka) grafiğiyle nasıl çalışılacağını, grafiği bir slayta eklemeyi, merkez deliğinin boyutunu ayarlamayı ve sunumu kaydetmeyi gösterir. `setDoughnutHoleSize` yöntemine odaklanır ve bu grafik türünü kod içinde özelleştirmek için gerekli temel adımları anlatır.

Ayrıca, birden çok seriyi kullanarak birden fazla halka oluşturma, patlatılmış donut grafiklerle çalışma ve bir grafiği raster görüntü ya da SVG olarak dışa aktarma gibi ilgili donut‑grafik senaryolarını kapsayan kısa bir SSS içerir.

## **Donut Grafiğinde Merkez Boşluğunu Belirleme**
{{% alert color="info" %}} 

Aspose.Slides for Java artık donut grafiğinde deliğin boyutunu belirlemeyi destekliyor. Bu konuda, bir örnekle donut grafiğinde deliğin boyutunun nasıl belirleneceğini göreceğiz.

{{% /alert %}} 

Donut grafiğinde deliğin boyutunu belirlemek için lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) nesnesini oluşturun.
1. Slayta donut grafiği ekleyin.
1. Donut grafiğinde deliğin boyutunu belirtin.
1. Sunumu diske yazın.

Aşağıdaki örnekte donut grafiğinde deliğin boyutunu ayarladık.

```java
import com.aspose.slides.*;

// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Sunumu diske kaydet
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

### Birden çok halka içeren çok seviyeli bir donut oluşturabilir miyim?

Evet. Tek bir donut grafiğine birden fazla seri ekleyin — her seri ayrı bir halka olur. Halkaların sırası, serilerin koleksiyondaki sırasına göre belirlenir.

### "Patlatılmış" bir donut (ayrılmış dilimler) destekleniyor mu?

Evet. Bir Patlatılmış Donut [grafik tipi](https://reference.aspose.com/slides/tr/java/com.aspose.slides/charttype/) ve veri noktaları üzerindeki patlatma özelliği vardır; bireysel dilimleri ayırabilirsiniz.

### Bir rapor için donut grafiğinin görüntüsünü (PNG/SVG) nasıl alabilirim?

Grafik bir şekildir; onu bir [raster görüntü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) olarak render edebilir veya grafiği bir [SVG görüntüsü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) olarak dışa aktarabilirsiniz.