---
title: Treemap ve Sunburst Grafiklerde Veri Noktalarını JavaScript ile Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerde Veri Noktaları
type: docs
url: /tr/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap grafik
- sunburst grafik
- veri noktası
- etiket rengi
- dal rengi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Treemap ve sunburst grafiklerde veri noktalarını JavaScript ve Aspose.Slides for Node.js via Java ile nasıl yöneteceğinizi öğrenin, PowerPoint formatlarıyla uyumludur."
---
## **Giriş**

Diğer PowerPoint grafik türlerinin yanı sıra iki "hiyerarşik" tür vardır - **Treemap** ve **Sunburst** grafik (aynı zamanda Sunburst Grafiği, Sunburst Diyagramı, Radial Grafik, Radial Çizim ya da Çok Katmanlı Pasta Grafiği olarak da bilinir). Bu grafikler, yapraklardan dalın tepesine kadar bir ağaç şeklinde düzenlenmiş hiyerarşik verileri gösterir. Yapraklar, seri veri noktalarıyla tanımlanır ve her bir sonraki iç içe grup seviyesi ilgili kategoriyle tanımlanır. Aspose.Slides for Node.js via Java, Sunburst Chart ve Treemap'in veri noktalarını JavaScript'te biçimlendirmeye olanak tanır.

İşte bir Sunburst grafiği, Series1 sütunundaki veriler yaprak düğümleri tanımlarken, diğer sütunlar hiyerarşik veri noktalarını tanımlar:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Yeni bir Sunburst grafiği sunuma eklemeye başlayalım:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [**PowerPoint Sunum Grafiklerini JavaScript'te Oluşturma veya Güncelleme**](/slides/tr/nodejs-java/create-chart/)
{{% /alert %}}

Grafiğin veri noktalarını biçimlendirmeye ihtiyaç duyulursa, aşağıdakileri kullanmalıyız:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPointLevel) sınıfları 
ve [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) metodu 
Treemap ve Sunburst grafiklerinin veri noktalarını biçimlendirmeye erişim sağlar. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPointLevelsManager) 
çok seviyeli kategorilere erişim için kullanılır - bu, 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPointLevel) nesnelerinin 
kapsayıcısını temsil eder. 
Temelde bu, veri noktalarına özgü eklenmiş özelliklere sahip 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartCategoryLevelsManager) için bir sarmalayıcıdır. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPointLevel) sınıfının 
iki yöntemi vardır: [**getFormat**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) ve 
[**getDataLabel**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) ve ilgili ayarlara erişim sağlar.

## **Veri Noktası Değerini Göster**
"Leaf 4" veri noktasının değerini göster:

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Veri Noktası Etiketini ve Rengini Ayarla**
"Branch 1" veri etiketini kategori adı yerine seri adı ("Series1") gösterecek şekilde ayarlayın. Ardından metin rengini sarıya ayarlayın:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Veri Noktası Dal Rengini Ayarla**
"Steam 4" dalının rengini değiştir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **SSS**

**Sunburst/Treemap'teki segmentlerin sırasını (sıralamasını) değiştirebilir miyim?**

Hayır. PowerPoint segmentleri otomatik olarak sıralar (genellikle azalan değerlere göre, saat yönünde). Aspose.Slides bu davranışı yansıtır: sıralamayı doğrudan değiştiremezsiniz; bunu verileri ön işlemden geçirerek elde edersiniz.

**Sunum teması segmentlerin ve etiketlerin renklerini nasıl etkiler?**

Grafik renkleri, doldurmaları/yazı tiplerini açıkça ayarlamadığınız sürece sunumun [tema/renk paleti](/slides/tr/nodejs-java/presentation-theme/) öğesinden devralınır. Tutarlı sonuçlar için, gerekli seviyelerde katı dolgu ve metin biçimlendirmesini sabitleyin.

**PDF/PNG'ye dışa aktarma, özel dal renklerini ve etiket ayarlarını korur mu?**

Evet. Sunumu dışa aktarırken, grafik ayarları (dolgu, etiketler) çıkış formatlarında korunur çünkü Aspose.Slides grafik biçimlendirmesi uygulanmış olarak render eder.

**Grafiğin üzerine özel kaplama yerleştirmek için bir etiketin/elemanın gerçek koordinatlarını hesaplayabilir miyim?**

Evet. Grafik düzeni doğrulandıktan sonra, öğeler için gerçek X ve gerçek Y değerleri (örneğin bir [DataLabel](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datalabel/)) mevcuttur; bu, kaplamaların hassas konumlandırılmasına yardımcı olur.