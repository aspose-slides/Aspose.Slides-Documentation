---
title: Android'da Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/androidjava/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarında grafik veri tablosu yazı tiplerini, kenarlıklarını ve lejand anahtarlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, bir grafiğin veri tablosunu görüntülemenizi ve metin biçimlendirmesini, kenarlıkları ve lejand anahtarlarını özelleştirmenizi sağlar. Bu makale, tabloyu nasıl etkinleştireceğinizi, metnini nasıl biçimlendireceğinizi, her kenarlık türünü nasıl kontrol edeceğinizi ve lejand anahtarlarını nasıl göstereceğinizi veya gizleyeceğinizi açıklar. Örnekler, yapılandırılmış grafikleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarla**

Bir grafiğin veri tablosunu görüntülemek için, [setDataTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) yöntemine `true` değerini geçin. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [getChartDataTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/#getChartDataTable--) yöntemini kullanın.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. İlk slayta bir kümelenmiş sütun grafiği ekleyin.
1. Grafiğin veri tablosunu etkinleştirin.
1. Kalın metni [setFontBold](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) ile etkinleştirin ve 20 puanlık metin için [setFontHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) yöntemine `20` değerini geçin.
1. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek, çalışma dizininde en az bir slayt içeren `test.pptx` dosyasını gerektirir. Varsayılan veriyle bir grafiği (50, 50) konumuna, 600 puan genişliğinde ve 400 puan yüksekliğinde ekler. Kaydedilen `output.pptx` dosyası, veri tablosu etkinleştirilmiş ve belirtilen yazı tipi ayarları uygulanmış grafiği içerir.

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

## **Veri Tablosu Kenarlıklarını Özelleştirme**

Tabloyu, [IChart.setDataTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) ile etkinleştirin ve [IChart.getChartDataTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#getChartDataTable--) aracılığıyla erişin. Üç kenarlık türünü bağımsız olarak kontrol edebilirsiniz:

- [setBorderHorizontal](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) yatay hücre kenarlıklarını kontrol eder.
- [setBorderVertical](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) dikey hücre kenarlıklarını kontrol eder.
- [setBorderOutline](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) tablonun dış kenarlığını kontrol eder.

`true` değerini her metoda geçirerek kenarlıkları gösterin veya `false` ile gizleyin. Aşağıdaki örnek, varsayılan veriyle bir kümelenmiş sütun grafiği oluşturur, yatay kenarlıkları ve dış kenarlığı gösterir, dikey kenarlıkları gizler. Giriş dosyası gerektirmez. Grafiğin konumu ve boyutu puan cinsinden belirtilir.

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

Aşağıdaki karşılaştırma, dört durumda da aynı grafik verisi ve lejand anahtarı ayarını kullanır. Tüm kenarlıklar etkinleştirilmiş olarak başlar, kalan her varyant sadece bir kenarlık ayarını devre dışı bırakır. Sol alt varyant, örnekteki kenarlık ayarlarıyla eşleşir.

![Tüm kenarlıklar etkin, yatay kenarlık yok, dikey kenarlık yok ve dış kenarlık yok olan grafik veri tabloları](data-table-borders.png)

## **Lejand Anahtarlarını Göster veya Gizle**

Lejand anahtarları, veri tablosundaki seri adlarının yanında bulunan küçük renkli işaretçilerdir. Okuyucuların her tablo satırını bir grafik serisiyle eşleştirmesine yardımcı olur. Bu işaretçileri göstermek için [setShowLegendKey](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) yöntemine `true` değerini, gizlemek için `false` değerini geçin.

Grafiğin ayrı lejandı, [IChart.setLegend](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) ile kontrol edilir. Bu ayarlar bağımsızdır: ayrı lejandı gizlemek, veri tablosundaki anahtarları gizlemez; tablo anahtarlarını gizlemek ise ayrı lejandı gizlemez.

Aşağıdaki örnek, varsayılan veriyle bir grafik oluşturur, veri tablosunu etkinleştirir ve ayrı lejandı gizlerken içinde lejand anahtarlarını gösterir. Tüm tablo kenarlıkları açıkça etkinleştirilir. Giriş sunumu gerekmez. Sadece tablonun anahtarlarını gizlemek için, [setShowLegendKey](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) yöntemine `false` değerini geçin.

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

Aşağıdaki karşılaştırma, aynı tabloyu lejand anahtarları etkin ve devre dışı olarak gösterir. Tüm kenarlıklar etkin kalır ve ayrı grafik lejandı her iki durumda da gizlenir.

![Sol tarafta lejand anahtarları gösterilen, sağ tarafta gizlenen grafik veri tabloları](data-table-legend-keys.png)

## **SSS**

**Bir grafiğin veri tablosunda lejand anahtarlarını gösterebilir miyim?**

Evet. Lejand anahtarlarını göstermek için [setShowLegendKey](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) yöntemine `true`, gizlemek için `false` değerini geçin.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**

Evet. Aspose.Slides, grafiği ve görüntülenen veri tablosunu, [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) veya [görüntüler](/slides/tr/androidjava/convert-powerpoint-to-png/) olarak dışa aktarırken slaytın bir parçası olarak işler.

**Şablondan yüklenen grafiklerde veri tablolarıyla çalışabilir miyim?**

Evet. Mevcut bir sunum veya şablondan yüklenen bir grafik için, veri tablosunun görüntülenip görüntülenmediğini kontrol etmek veya değiştirmek üzere [hasDataTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/#hasDataTable--) ve [setDataTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) yöntemlerini kullanın.

**Veri tablosu etkinleştirilmiş grafikleri nasıl bulabilirim?**

Her slayttaki şekiller arasında döngü yapın, grafikleri belirleyin ve onların [hasDataTable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chart/#hasDataTable--) metodunu çağırın. `true` değeri, veri tablosunun etkin olduğunu gösterir.