---
title: Sunumlarda Grafik Açıklamalarını JavaScript ile Özelleştirme
linktitle: Grafik Açıklaması
type: docs
url: /tr/nodejs-java/chart-legend/
keywords:
- grafik açıklaması
- açıklama konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile grafik açıklamalarını özelleştirerek, PowerPoint sunumlarını özel açıklama biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, PowerPoint sunumlarındaki grafik açıklamalarını özelleştirmek için seçenekler sunar. Bu makale, bir açıklamayı konumlandırma ve boyutlandırma, tüm açıklamanın yazı tipi boyutunu ayarlama, tek bir açıklama girişini biçimlendirme ve seçili girişleri gizleme veya geri yükleme konularını gösterir.

SSS, açıklama için alan ayırma, çok satırlı etiketleri gösterme ve sunum temasından biçimlendirmeyi devralma gibi ilgili davranışları kapsar.

## **Açıklama Konumlandırması**

Açıklamanın [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) ve [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) yöntemlerini kullanarak konum ve boyutunu grafiğin boyutlarının kesirleri olarak belirtebilirsiniz.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan verilerle bir kümelenmiş sütun grafiği ekler. İstenen açıklama kaydırmalarını ve boyutlarını grafiğin genişliği ve yüksekliği ile bölmek, bunları göreli değerlere dönüştürür: açıklama, grafiğin sol üst köşesinden 50 puan uzaklıkta ve 100 x 100 puan boyutundadır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Grafiğe göre açıklamanın konum ve boyutunu ifade eder.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Açıklamanın Yazı Tipi Boyutunu Ayarlama**

Açıklamanın metin biçimlendirmesine erişmek için [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) metodunu kullanın ve noktalarla yazı tipi boyutunu ayarlamak için [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) metodunu kullanın.

Bu örnek, varsayılan verilerle bir grafik oluşturur ve açıklama metnini 20 puana ayarlar. Ayrıca dikey eksen için otomatik sınırları devre dışı bırakır ve aralığını -5 ile 10 arasında belirler.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tek Bir Açıklama Girişinin Yazı Tipi Boyutunu Ayarlama**

Açıklamanın [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) metodundan dönen koleksiyonu kullanarak belirli bir girişin biçimlendirmesine erişin. Giriş indeksleri sıfır tabanlıdır, bu nedenle `1` indeksi ikinci girdiyi ifade eder.

Bu örnek, varsayılan verileri en az iki seriyi içeren bir kümelenmiş sütun grafiği oluşturur. İkinci açıklama girdisini kalın, italik ve 20 puan mavi metin olarak biçimlendirir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tek Tek Açıklama Girdilerini Gizleme**

Verileri görünür tutarken yardımcı bir seriyi açıklamadan çıkarmak için, [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) aracılığıyla `true` ile [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) metodunu çağırın. Bu, yalnızca seçilen açıklama girdisini gizler; seriyi veya veri noktalarını kaldırmaz. Buna karşılık, `false` ile [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) metodunu çağırmak tüm açıklamayı gizler.

Aşağıdaki örnek, varsayılan verilerle birden çok seri içeren bir kümelenmiş sütun grafiği oluşturur. İkinci serinin açıklama girdisini (indeks `1`) gizler ve sunumu kaydeder. Ardından, `false` ile [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) metodunu çağırarak girdiyi geri yükler ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Grafik verisini değiştirmeden aynı girdiyi geri yükle.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, tüm girdileri görünür ve ikinci girdi gizli olan aynı grafiği gösterir. İkinci serinin sütunları değişmeden kalır.

![Tüm açıklama girdileri görünür ve Seri 2 açıklamadan gizli olduğunda bir grafiğin karşılaştırması; tüm sütunlar görünür kalır.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerinde açıklama girdileri serileri tanımlar. Pasta grafiklerinde ise tek tek veri noktalarını (dilimleri) tanımlar, bu yüzden seçili dilimde [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) metodunu kullanın. API, bu veri noktası metodunu `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` ve `BarOfPie` grafik türleri için belgelendirir. Listedeki gibi donut grafiklerine uygulanacağını varsaymayın.

## **SSS**

**Grafiğin açıklama için alan ayırmasını, üst üste binmesini önleyebilir miyim?**

Evet. Açıklamanın çizim alanı üzerine binmesine izin vermek yerine alan ayırmak için [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) metodunu `false` ile çağırın.

**Çok satırlı açıklama etiketleri oluşturabilir miyim?**

Evet. Kullanılabilir genişlik yetersiz olduğunda uzun etiketler satır başına kaydırılabilir. Ayrıca seri adlarında yeni satır karakterleri ekleyerek satır sonu isteyebilirsiniz.

**Açıklamanın sunum temasının renk şemasını izlemesini nasıl sağlarım?**

Açıklamanın renklerini, doldurmalarını ve yazı tiplerini ayarlamadan bırakın; böylece tema biçimlendirmesini devralır. Açıkça belirlenmiş biçimlendirme, ilgili tema ayarlarının üzerine yazar.