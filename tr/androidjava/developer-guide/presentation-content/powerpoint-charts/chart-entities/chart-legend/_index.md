---
title: Android'de Sunumlarda Grafik Açıklama Kutularını Özelleştirin
linktitle: Grafik Açıklama Kutusu
type: docs
url: /tr/androidjava/chart-legend/
keywords:
- grafik açıklama kutusu
- açıklama kutusu konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile grafik açıklama kutularını özelleştirerek, PowerPoint sunumlarını özelleştirilmiş açıklama kutusu biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, PowerPoint sunumlarında grafik açıklama kutularını özelleştirme seçenekleri sunar. Bu makale, bir açıklama kutusunun konumlandırılması ve boyutlandırılması, tüm açıklama kutusunun yazı tipi boyutunun ayarlanması, tek bir açıklama girdisinin biçimlendirilmesi ve seçili girdilerin gizlenmesi veya geri getirilmesi nasıl yapılır gösterir.

SSS, açıklama kutusu için alan ayırma, çok satırlı etiketlerin görüntülenmesi ve sunum temasından biçimlendirmeyi devralma gibi ilgili davranışları kapsar.

## **Açıklama Kutusu Konumlandırma**

Grafiğin boyutlarının kesirleri olarak konum ve boyutunu belirtmek için açıklama kutusunun [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-) ve [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-) metodlarını kullanın.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan verilerle bir küme sütun grafiği ekler. İstenen açıklama kutusu kaydırma ve boyutlarını grafiğin genişliği ve yüksekliğiyle bölmek, bunları göreli değerlere dönüştürür: açıklama kutusu, grafiğin sol üst köşesinden 50 puan kaydırılır ve 100x100 puan boyutlandırılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Grafiğe göre açıklama kutusunun konum ve boyutunu ifade eder.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Açıklama Kutusunun Yazı Tipi Boyutunu Ayarlama**

Açıklama kutusunun metin biçimlendirmesine erişmek için [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) metodunu kullanın ve puan cinsinden yazı tipi boyutunu ayarlamak için [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) metodunu kullanın.

Bu örnek varsayılan verilerle bir grafik oluşturur ve açıklama kutusu metnini 20 puana ayarlar. Ayrıca dikey eksen için otomatik sınırlamaları devre dışı bırakır ve aralığını -5 ile 10 arasında belirler.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tek Bir Açıklama Kutusu Girdisinin Yazı Tipi Boyutunu Ayarlama**

Açıklama kutusunun [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--) metodunun döndürdüğü koleksiyonu, belirli bir girdinin biçimlendirmesine erişmek için kullanın. Girdi indeksleri sıfır tabanlıdır, bu yüzden `1` indeksi ikinci girdiyi ifade eder.

Bu örnek, varsayılan verileri en az iki seriyi içeren bir küme sütun grafiği oluşturur. İkinci açıklama kutusu girdisini kalın, italik ve 20 puan mavi metin olarak biçimlendirir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tek Tek Açıklama Kutusu Girdilerini Gizleme**

Verileri görünür tutarken yardımcı bir seriyi açıklama kutusundan çıkarmak için, [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) metodunu `true` ile ve [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) üzerinden çağırın. Bu, yalnızca seçili açıklama girdisini gizler; seriyi ya da veri noktalarını kaldırmaz. Buna karşılık, [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) metodunu `false` ile çağırmak, tüm açıklama kutusunu gizler.

Aşağıdaki örnek, varsayılan verileri kullanan birden fazla seriyle bir küme sütun grafiği oluşturur. İkinci serinin açıklama girdisini (indeks `1`) gizler ve sunumu kaydeder. Ardından, [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) metodunu `false` ile çağırarak girdiyi geri yükler ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Grafik verisini değiştirmeden aynı girişi geri yükle.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, tüm girdileri görünür ve ikinci girdi gizli olarak aynı grafiği gösterir. İkinci serinin sütunları değişmeden kalır.

![Tüm açıklama girdileri görünür ve 2. Seri açıklamadan gizli olduğunda grafik karşılaştırması; tüm sütunlar görünür.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerinde, açıklama girdileri serileri tanımlar. Pasta grafiklerinde ise bireysel veri noktalarını (dilimleri) tanımlar, bu nedenle seçili dilimde [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) metodunu kullanın. API, bu veri noktası metodunu `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` ve `BarOfPie` grafik türleri için belgelendirir. Listede yer almayan halka (doughnut) grafiklerinde geçerli olduğunu varsımayın.

## **SSS**

**Grafik, açıklama kutusu için alan ayırıp üzerine bindirmesini önleyebilir miyim?**

Evet. Açıklama kutusu için alan ayırmak ve çizim alanının üzerine bindirmesini önlemek için [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) metodunu `false` ile çağırın.

**Çok satırlı açıklama etiketleri oluşturabilir miyim?**

Evet. Mevcut genişlik yetersiz olduğunda uzun etiketler satır başına kaydırılabilir. Ayrıca seri adlarında satır sonu karakterleri kullanarak satır sonları isteyebilirsiniz.

**Açıklama kutusunun sunum temasının renk şemasını izlemesini nasıl sağlayabilirim?**

Açıklama kutusunun renklerini, doldurmalarını ve yazı tiplerini ayarlamadan bırakın; böylece tema biçimlendirmesini devralır. Açıkça belirlenen biçimlendirme, ilgili tema ayarlarını geçersiz kılar.