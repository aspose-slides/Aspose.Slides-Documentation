---
title: Java Kullanarak Sunumlarda Grafik Lejantlarını Özelleştirme
linktitle: Grafik Lejanti
type: docs
url: /tr/java/chart-legend/
keywords:
- grafik lejantı
- lejant konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile grafik lejantlarını özelleştirerek PowerPoint sunumlarını özel lejant biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides for Java, PowerPoint sunumlarındaki grafik lejantlarını özelleştirme seçenekleri sunar. Bu makale, bir lejantı konumlandırma ve boyutlandırma, tüm lejantın yazı tipi boyutunu ayarlama, tek bir lejant girdisini biçimlendirme ve seçili girdileri gizleme veya geri getirme işlemlerini gösterir.

SSS, lejant için alan ayırma, çok satırlı etiket gösterme ve sunum temasından biçimlendirmeyi devralma gibi ilgili davranışları kapsar.

## **Lejant Konumlandırması**

Lejantın konumunu ve boyutunu, grafiğin boyutlarının kesirleri olarak belirtmek için lejantın [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), ve [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) metodlarını kullanın.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan veri ile bir küme sütun grafiği ekler. İstenen lejant ofset ve boyutlarını grafiğin genişliği ve yüksekliğiyle bölmek, bunları göreli değerlere dönüştürür: lejant, grafiğin sol üst köşesinden 50 puan uzaklıkta ve 100 × 100 puan boyutundadır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Lejantın konum ve boyutunu grafiğe göre ifade edin.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lejantın Yazı Tipi Boyutunu Ayarlama**

Lejantın [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) metoduyla metin biçimlendirmesine erişin ve [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metodunu kullanarak yazı tipi boyutunu puan cinsinden ayarlayın.

Bu örnek bir grafik oluşturur, varsayılan veri ekler ve lejant metnini 20 puan olarak ayarlar. Ayrıca dikey eksen için otomatik sınırları devre dışı bırakır ve aralığı –5 ile 10 arasında ayarlar.

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

## **Bireysel Lejant Girdisinin Yazı Tipi Boyutunu Ayarlama**

Lejantın [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) metoduyla dönen koleksiyonu kullanarak belirli bir girdinin biçimlendirmesine erişin. Girdi indeksleri sıfır tabanlıdır; bu nedenle `1` indeksi ikinci girdiyi ifade eder.

Bu örnek, varsayılan verisi en az iki seri içeren bir küme sütun grafiği oluşturur. İkinci lejant girdisini kalın, italik ve 20 puan mavi metin ile biçimlendirir.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Bireysel Lejant Girdilerini Gizleme**

Yardımcı bir seriyi lejanttan dışlamak ancak verisini görünür tutmak için, [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) metodunu `true` olarak, [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) üzerinden çağırın. Bu sadece seçili lejant girdisini gizler; seriyi veya veri noktalarını kaldırmaz. Buna karşın, [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) metodunu `false` ile çağırmak tüm lejantı gizler.

Aşağıdaki örnek, varsayılan veriyle birden çok seri içeren bir küme sütun grafiği oluşturur. İkinci serinin lejant girdisini (indeks `1`) gizler ve sunumu kaydeder. Ardından girdiyi `false` ile [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) çağırarak geri getirir ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

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

    // Grafiğin verisini değiştirmeden aynı girişi geri yükle.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, aynı grafiği tüm girdileri görünür ve ikinci girdi gizli olarak gösterir. İkinci serinin sütunları değişmeden kalır.

![Tüm lejant girdileri görünür ve Seri 2 lejanttan gizli olduğu bir grafiğin karşılaştırması; tüm sütunlar görünür kalır.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerde lejant girdileri serileri tanımlar. Pasta grafiklerde ise bireysel veri noktalarını (dilimleri) tanımlar; bu nedenle seçili dilim üzerinde [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) metodunu kullanın. API, bu veri‑nokta metodunu `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` ve `BarOfPie` grafik türleri için belgeler. Bu yöntemin, listede yer almayan halka grafiklerinde geçerli olduğunu varsaymayın.

## **SSS**

**Grafiğin lejant için alan ayırmasını, üst üste gelmesi yerine sağlayabilir miyim?**

Evet. Lejantın grafik alanıyla çakışmasına izin vermek yerine alan ayırmak için [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) metodunu `false` ile çağırın.

**Çok satırlı lejant etiketleri oluşturabilir miyim?**

Evet. Kullanılabilir genişlik yetersiz olduğunda uzun etiketler satır sonuna geçebilir. Ayrıca seri adlarında satır sonu karakterleri ekleyerek satır sonları isteyebilirsiniz.

**Lejantın sunum temasının renk şemasını izlemesini nasıl sağlarım?**

Lejantın renklerini, doldurmalarını ve yazı tiplerini ayarlamadan bırakın, böylece tema biçimlendirmesini devralır. Açıkça belirlenmiş biçimlendirme, ilgili tema ayarlarını geçersiz kılar.