---
title: Android'de Sunumlarda Halka Grafiklerini Özelleştirme
linktitle: Halka Grafiği
type: docs
weight: 30
url: /tr/androidjava/doughnut-chart/
keywords:
- halka grafiği
- merkez boşluğu
- boşluk boyutu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile dinamik sunumlar için PowerPoint formatlarını destekleyen, halka grafiklerini oluşturma ve özelleştirme yöntemlerini keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir halka grafiğiyle nasıl çalışılacağını, grafiği bir slayta eklemeyi, merkez boşluğunun boyutunu ayarlamayı ve sunumu kaydetmeyi gösterir. `setDoughnutHoleSize` metoduna odaklanır ve bu grafik türünü kod içinde özelleştirmek için gereken temel adımları gösterir.

Ayrıca, birden fazla seriyi kullanarak birden çok halka oluşturma, patlatılmış halka grafikleriyle çalışma ve bir grafiği raster görüntü ya da SVG olarak dışa aktarma gibi ilgili halka grafiği senaryolarını kapsayan kısa bir SSS bölümünü içerir.

## **Halka Grafiğinde Merkez Boşluğunu Belirleme**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java artık bir halka grafiğindeki boşluğun boyutunu belirtmeyi desteklemektedir. Bu konuda, bir örnekle halka grafiğindeki boşluğun boyutunun nasıl belirleneceğini göreceğiz.

{{% /alert %}} 

Halka grafiğindeki boşluğun boyutunu belirtmek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) nesnesini örnekleyin.
1. Slayta bir halka grafiği ekleyin.
1. Halka grafiğindeki boşluğun boyutunu belirtin.
1. Sunumu diske yazın.

Aşağıdaki örnekte, bir halka grafiğindeki boşluğun boyutunu ayarladık.

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

### Birden fazla halka içeren çok seviyeli bir halka oluşturabilir miyim?

Evet. Tek bir halka grafiğine birden fazla seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyondaki sırasına göre belirlenir.

### “Patlatılmış” halka (ayrılmış dilimler) destekleniyor mu?

Evet. Bir Patlatılmış Halka [grafik türü](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) ve veri noktalarında bir patlatma özelliği vardır; bireysel dilimleri ayırabilirsiniz.

### Bir rapor için halka grafiğinin (PNG/SVG) görüntüsünü nasıl alabilirim?

Grafik bir şekildir; onu bir [raster görüntü](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) olarak render edebilir veya grafiği bir [SVG görüntüsü](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) olarak dışa aktarabilirsiniz.