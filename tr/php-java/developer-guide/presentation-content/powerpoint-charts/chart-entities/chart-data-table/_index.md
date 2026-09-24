---
title: PHP kullanarak Sunumlarda Grafik Veri Tablolarını Özelleştirme
linktitle: Veri Tablosu
type: docs
url: /tr/php-java/chart-data-table/
keywords:
- grafik verisi
- veri tablosu
- yazı tipi özellikleri
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında grafik veri tablosu yazı tiplerini, kenarlıklarını ve açıklama işaretlerini özelleştirin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, bir grafiğin veri tablosunu görüntülemenizi ve metin biçimlendirmesini, kenarlıklarını ve açıklama işaretlerini özelleştirmenizi sağlar. Bu makale, tabloyu nasıl etkinleştirileceğini, metnini nasıl biçimlendireceğinizi, her kenarlık tipini nasıl kontrol edeceğinizi ve açıklama işaretlerini nasıl gösterip gizleyeceğinizi açıklar. Örnekler, yapılandırılmış grafikleri PPTX dosyalarına kaydeder.

## **Yazı Tipi Özelliklerini Ayarlama**

Bir grafiğin veri tablosunu görüntülemek için `true` değerini [setDataTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/setdatatable/) metoduna geçirin. Tabloya erişmek ve metin biçimlendirmesini yapılandırmak için [getChartDataTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/getchartdatatable/) metodunu kullanın.

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. İlk slayta bir kümelenmiş sütun grafiği ekleyin.
1. Grafiğin veri tablosunu etkinleştirin.
1. [setFontBold](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setFontBold) ile kalın metni etkinleştirin ve 20 puanlık metin için `20` değerini [setFontHeight](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setFontHeight) metoduna geçirin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, çalışma dizininde en az bir slaytı olan `test.pptx` dosyasını gerektirir. (50, 50) konumunda, genişliği 600 puan ve yüksekliği 400 puan olan varsayılan veri ile bir grafik ekler. Kaydedilen `output.pptx` dosyası, veri tablosu etkinleştirilmiş grafiği ve belirtilen yazı tipi ayarlarını içerir.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Veri Tablosu Kenarlıklarını Özelleştirme**

Tabloyu [Chart::setDataTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/setdatatable/) ile etkinleştirin ve [Chart::getChartDataTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/getchartdatatable/) ile erişin. Üç ayrı kenarlık tipini bağımsız olarak kontrol edebilirsiniz:

- [setBorderHorizontal](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datatable/setborderhorizontal/) yatay hücre kenarlıklarını kontrol eder.
- [setBorderVertical](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datatable/setbordervertical/) dikey hücre kenarlıklarını kontrol eder.
- [setBorderOutline](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datatable/setborderoutline/) tablonun dış kenarlığını kontrol eder.

`true` değerini her metoda geçirerek kenarlıkları gösterin, `false` değerini geçirerek gizleyin. Aşağıdaki örnek, varsayılan veri ile bir kümelenmiş sütun grafiği oluşturur, yatay kenarlıklar ve dış kenarlığı gösterir, dikey kenarlıkları gizler. Giriş dosyası gerektirmez. Grafiğin konumu ve boyutu puan cinsinden belirtilir.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki karşılaştırma, dört durumda da aynı grafik verisini ve açıklama işareti ayarını kullanır. Tüm kenarlıklar etkinleştirilmiş olarak başlayıp, her sonraki varyant sadece bir kenarlık ayarını devre dışı bırakır. Sol alt varyant, örnekteki kenarlık ayarlarıyla eşleşir.

![Tüm kenarlıklar etkin, yatay kenarlık yok, dikey kenarlık yok ve dış kenarlık yok grafik veri tabloları](data-table-borders.png)

## **Açıklama İşaretlerini Gösterme veya Gizleme**

Açıklama işaretleri, veri tablosundaki seri adlarının yanında bulunan küçük renkli işaretlerdir. Okuyucuların her tablo satırını bir grafik serisiyle eşleştirmesine yardımcı olur. Bu işaretleri göstermek için [setShowLegendKey](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datatable/setshowlegendkey/) metoduna `true` değerini, gizlemek için `false` değerini geçirin.

Grafiğin ayrı açıklaması, [Chart::setLegend](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/setlegend/) ile kontrol edilir. Bu ayarlar bağımsızdır: ayrı açıklamayı gizlemek veri tablosundaki işaretleri gizlemez, tablo işaretlerini gizlemek ise ayrı açıklamayı gizlemez.

Aşağıdaki örnek, varsayılan veri ile bir grafik oluşturur, veri tablosunu etkinleştirir ve içinde açıklama işaretlerini gösterirken ayrı açıklamayı gizler. Tüm tablo kenarlıkları açıkça etkinleştirilir. Giriş sunumu gerekmez. Sadece tablo işaretlerini gizlemek için [setShowLegendKey](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datatable/setshowlegendkey/) metoduna `false` değerini geçirin.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki karşılaştırma, aynı tabloyu açıklama işaretleri etkin ve devre dışı bırakılmış şekilde gösterir. Tüm kenarlıklar etkin kalır ve ayrı grafik açıklaması her iki durumda da gizlenir.

![Sol tarafta açıklama işaretleri gösterilen, sağ tarafta gizlenen grafik veri tabloları](data-table-legend-keys.png)

## **SSS**

**Bir grafiğin veri tablosunda açıklama işaretlerini gösterebilir miyim?**  
Evet. Açıklama işaretlerini göstermek için [setShowLegendKey](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datatable/setshowlegendkey/) metoduna `true`, gizlemek için `false` değerini geçirin.

**Sunumu PDF, HTML veya görüntülere dışa aktarırken veri tablosu korunur mu?**  
Evet. Aspose.Slides, grafiği ve görüntülenen veri tablosunu, slaytın bir parçası olarak [PDF](/slides/tr/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/tr/php-java/convert-powerpoint-to-html/) veya [images](/slides/tr/php-java/convert-powerpoint-to-png/) dışa aktarırken oluşturur.

**Şablondan yüklenen grafikerde veri tabloları ile çalışabilir miyim?**  
Evet. Mevcut bir sunumdan veya şablondan yüklenen bir grafik için, veri tablosunun görüntülenip görüntülenmediğini kontrol etmek veya değiştirmek amacıyla [hasDataTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/hasdatatable/) ve [setDataTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/setdatatable/) metodlarını kullanın.

**Veri tablosu etkin olan grafikleri nasıl bulabilirim?**  
Her slayttaki şekilleri döngüyle gezerek grafikleri tespit edin ve [hasDataTable](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chart/hasdatatable/) metodunu çağırın. `true` değeri, veri tablosunun etkin olduğunu gösterir.