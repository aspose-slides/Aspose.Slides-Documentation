---
title: Android’de Treemap ve Sunburst Grafiklerde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap grafiği
- sunburst grafiği
- veri noktası
- etiket rengi
- dal rengi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak treemap ve sunburst grafiklerde veri noktalarını nasıl yöneteceğinizi öğrenin, PowerPoint formatlarıyla uyumludur."
---
## **Giriş**

PowerPoint grafiklerinin diğer türleri arasında iki adet “hiyerarşik” tür vardır – **Treemap** ve **Sunburst** grafiği (Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph veya Multi Level Pie Chart olarak da bilinir). Bu grafikler, ağaç yapısı şeklinde düzenlenmiş hiyerarşik verileri – yapraklardan dalın en üstüne kadar – gösterir. Yapraklar, seri veri noktalarıyla tanımlanır ve sonraki her iç içe gruplama seviyesi ilgili kategoriyle tanımlanır. Aspose.Slides for Android via Java, Sunburst ve Treemap grafiklerinin veri noktalarını Java’da biçimlendirmeyi sağlar.

Aşağıda, Series1 sütunundaki verilerin yaprak düğümlerini, diğer sütunların ise hiyerarşik veri noktalarını tanımladığı bir Sunburst grafiği bulunmaktadır:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Sunburst grafiğini sunuma ekleyerek başlayalım:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [**Android’de PowerPoint Sunum Grafiklerini Oluşturma veya Güncelleme**](/slides/tr/androidjava/create-chart/)
{{% /alert %}}

Grafiğin veri noktalarını biçimlendirmek gerektiğinde aşağıdaki öğeler kullanılmalıdır:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPointLevel) sınıfları 
ve [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) yöntemi 
Treemap ve Sunburst grafiklerinin veri noktalarını biçimlendirme erişimi sağlar. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
çok seviyeli kategorilere erişmek için kullanılır – [**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPointLevel) nesnelerinin kapsayıcısını temsil eder.
Temelde, veri noktalarına özgü ek özellikleri içeren bir sarmalayıcıdır ve [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartCategoryLevelsManager) ile aynı işlevi görür.
[**IChartDataPointLevel**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPointLevel) sınıfının iki yöntemi vardır: [**getFormat**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) ve [**getDataLabel**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) ve bu yöntemler ilgili ayarlara erişim sağlar.
## **Bir Veri Noktası Değerini Göster**
“Leaf 4” veri noktasının değerini göster:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Bir Veri Noktası Etiketini ve Rengini Ayarla**
“Branch 1” veri etiketini kategori adı yerine seri adı (“Series1”) gösterecek şekilde ayarlayın. Ardından metin rengini sarı yapın:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Bir Veri Noktası Dal Rengini Ayarla**
“Steam 4” dalının rengini değiştirin:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **SSS**

**Sunburst/Treemap grafiklerinde segmentlerin sırasını (sıralamayı) değiştirebilir miyim?**

Hayır. PowerPoint segmentleri otomatik olarak sıralar (genellikle azalan değerlerle, saat yönünde). Aspose.Slides bu davranışı yansıtır: sıralamayı doğrudan değiştiremezsiniz; veriyi ön işlemden geçirerek istediğiniz sıralamayı elde edersiniz.

**Sunum teması segment ve etiket renklerini nasıl etkiler?**

Grafik renkleri, dolgu/ yazı tipleri açıkça ayarlanmadıkça sunumun [tema/renk paleti](/slides/tr/androidjava/presentation-theme/) üzerinden devralınır. Tutarlı sonuçlar için gerekli seviyelerde katı dolgu ve metin biçimlendirmesini sabitleyin.

**PDF/PNG’ye dışa aktarırken özel dal renkleri ve etiket ayarları korunur mu?**

Evet. Sunumu dışa aktarırken grafik ayarları (dolgu, etiketler) çıktı formatında korunur; Aspose.Slides, grafik biçimlendirmesi uygulanmış şekilde render eder.

**Grafiğin üzerine özel bindirme yerleştirmek için bir etiketin/elemanın gerçek koordinatlarını hesaplayabilir miyim?**

Evet. Grafik yerleşimi doğrulandıktan sonra öğeler için gerçek *x* ve *y* değerleri mevcut olur (örneğin bir [DataLabel](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/datalabel/) için), bu da bindirmelerin hassas konumlandırılmasını sağlar.