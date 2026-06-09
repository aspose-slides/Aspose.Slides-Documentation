---
title: JavaScript Kullanarak Sunumlarda Halka Grafiklerini Özelleştirme
linktitle: Halka Grafik
type: docs
weight: 30
url: /tr/nodejs-java/doughnut-chart/
keywords:
- halka grafik
- merkez boşluğu
- delik boyutu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak halka grafiklerini oluşturma ve özelleştirme yöntemlerini keşfedin; dinamik sunumlar için PowerPoint formatlarını destekler."
---
## **Genel Bakış**

Bu makale Aspose.Slides'de bir halka grafiği ile nasıl çalışılacağını gösterir; grafiği bir slayta ekleme, merkez boşluğunun boyutunu ayarlama ve sunumu kaydetme. `setDoughnutHoleSize` yöntemine odaklanır ve bu grafik tipini kod içinde özelleştirmenin temel adımlarını gösterir.

Ayrıca çoklu serilerle birden fazla halka oluşturma, patlamış halka grafikleriyle çalışma ve grafiği raster görüntü ya da SVG olarak dışa aktarma gibi konuları kapsayan kısa bir SSS içerir.

## **Halka Grafiğinde Merkez Boşluğunu Değiştirme**

Bir halka grafiğinde boşluğun boyutunu belirlemek için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) nesnesini oluşturun.
1. Slayta halka grafiği ekleyin.
1. Bir halka grafiğinde boşluğun boyutunu belirtin.
1. Sunumu diske yazın.

Aşağıdaki örnekte, bir halka grafiğinde boşluğun boyutunu ayarladık.

```javascript
// Presentation sınıfının bir örneğini oluşturun
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Sunumu diske yazın
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Çok katmanlı bir halka grafiği birden fazla halka ile oluşturabilir miyim?**

Evet. Tek bir halka grafiğine birden fazla seri ekleyin—her seri ayrı bir halka olur. Halkanın sırası, serilerin koleksiyondaki sırasına göre belirlenir.

**Patlamış bir halka (ayrı dilimler) destekleniyor mu?**

Evet. Bir Patlamış Halka [grafik türü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) ve veri noktalarında bir patlama özelliği vardır; böylece tek tek dilimleri ayırabilirsiniz.

**Bir rapor için halka grafiğinin (PNG/SVG) görüntüsünü nasıl alabilirim?**

Bir grafik bir şekildir; onu bir [raster görüntü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) olarak oluşturabilir veya grafiği bir [SVG görüntüsü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/) olarak dışa aktarabilirsiniz.