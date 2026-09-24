---
title: Java Kullanarak Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/java/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "PowerPoint sunumlarında Aspose.Slides for Java kullanarak grafik veri tablosu yazı tiplerini, kenarlarını ve açıklama anahtarlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for Java, bir grafik veri tablosunu görüntülemenizi ve metin biçimlendirmesini, kenarları ve açıklama anahtarlarını özelleştirmenizi sağlar. Bu makale, tabloyu nasıl etkinleştireceğinizi, metnini nasıl biçimlendireceğinizi, her kenar türünü nasıl kontrol edeceğinizi ve açıklama anahtarlarını nasıl göstereceğinizi veya gizleyeceğinizi açıklar. Örnekler, yapılandırılmış grafikleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarlama**

Bir grafiğin veri tablosunu görüntülemek için `true` değerini [setDataTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/#setDataTable-boolean-) metoduna geçirin. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [getChartDataTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/#getChartDataTable--) metodunu kullanın.

1. Sunumu [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.  
1. İlk slayta bir küme sütun grafiği ekleyin.  
1. Grafiğin veri tablosunu etkinleştirin.  
1. [setFontBold](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) ile kalın metni etkinleştirin ve 20 puanlık metin için [setFontHeight](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metoduna `20` değerini geçirin.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, çalışma dizininde en az bir slaytı olan `test.pptx` dosyasını gerektirir. Varsayılan veriyle (50, 50) konumunda, 600 puan genişliğinde ve 400 puan yüksekliğinde bir grafik ekler. Kaydedilen `output.pptx`, veri tablosu etkinleştirilmiş ve belirtilen yazı tipi ayarları uygulanmış grafiği içerir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veri Tablosu Kenarlarını Özelleştirme**

Tabloyu [IChart.setDataTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#setDataTable-boolean-) ile etkinleştirin ve [IChart.getChartDataTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#getChartDataTable--) üzerinden erişin. Üç kenar tipini bağımsız olarak kontrol edebilirsiniz:

- [setBorderHorizontal](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) yatay hücre kenarlarını kontrol eder.  
- [setBorderVertical](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) dikey hücre kenarlarını kontrol eder.  
- [setBorderOutline](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) tablonun dış kenarını kontrol eder.

Her metoda `true` geçirerek kenarları gösterin, `false` geçirerek gizleyin. Aşağıdaki örnek, varsayılan veriyle bir küme sütun grafiği oluşturur, yatay kenarları ve dış kenarı gösterir, dikey kenarları gizler. Giriş dosyası gerektirmez. Grafik konumu ve boyutu puan cinsindendir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, aynı grafik verisi ve açıklama anahtarı ayarını dört durumda kullanır. Tüm kenarlar etkinleştirilmiş olarak başlar; kalan varyantlar sadece bir kenar ayarını devre dışı bırakır. Sol‑alt varyant, örnekteki kenar ayarlarıyla eşleşir.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Açıklama Anahtarlarını Gösterme veya Gizleme**

Açıklama anahtarları, veri tablosundaki seri adlarının yanında bulunan küçük renkli işaretlerdir. Okuyucuların her tablo satırını bir grafik serisiyle eşleştirmesine yardımcı olur. Bu işaretleri göstermek için [setShowLegendKey](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) metoduna `true`, gizlemek için `false` geçirin.

Grafiğin ayrı açıklaması, [IChart.setLegend](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#setLegend-boolean-) ile kontrol edilir. Bu ayarlar bağımsızdır: ayrı açıklamayı gizlemek, veri tablosundaki anahtarları gizlemez; veri tablosundaki anahtarları gizlemek ise ayrı açıklamayı etkileyemez.

Aşağıdaki örnek, varsayılan veriyle bir grafik oluşturur, veri tablosunu etkinleştirir ve içinde açıklama anahtarlarını gösterirken ayrı açıklamayı gizler. Tüm tablo kenarları açıkça etkinleştirilmiştir. Giriş sunumu gerekmez. Yalnızca tablonun anahtarlarını gizlemek için [setShowLegendKey](https://reference.aspose.com/slides/tr/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) metoduna `false` geçirin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki karşılaştırma, aynı tabloyu açıklama anahtarları etkin ve devre dışı durumda gösterir. Tüm kenarlar etkin kalır ve ayrı grafik açıklaması her iki durumda da gizlenir.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **SSS**

**Bir grafiğin veri tablosunda açıklama anahtarlarını gösterebilir miyim?**

Evet. Açıklama anahtarlarını göstermek için [setShowLegendKey](https://reference.aspose.com/slides/tr/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) metoduna `true`, gizlemek için `false` geçirin.

**Veri tablosu, sunum PDF, HTML veya görsellere dışa aktarılırken korunur mu?**

Evet. Aspose.Slides, dışa aktarırken grafiği ve gösterilen veri tablosunu slaytın bir parçası olarak [PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/java/convert-powerpoint-to-html/) ve [images](/slides/tr/java/convert-powerpoint-to-png/) formatlarına renderlar.

**Şablondan yüklenen grafiklerde veri tablolarıyla çalışabilir miyim?**

Evet. Mevcut bir sunum veya şablondan yüklenen bir grafik için, veri tablosunun görüntülenip görüntülenmediğini kontrol etmek veya değiştirmek üzere [hasDataTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/#hasDataTable--) ve [setDataTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/#setDataTable-boolean-) metodlarını kullanın.

**Veri tablosu etkinleştirilmiş grafikleri nasıl bulabilirim?**

Her slayttaki şekiller arasında gezinin, grafikleri tanımlayın ve onların [hasDataTable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chart/#hasDataTable--) metodunu çağırın. `true` değeri, veri tablosunun etkin olduğunu gösterir.