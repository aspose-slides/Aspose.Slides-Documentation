---
title: Sunumlarda PHP Kullanarak Grafik Lejantlarını Özelleştirme
linktitle: Grafik Lejantı
type: docs
url: /tr/php-java/chart-legend/
keywords:
- grafik lejantı
- lejant konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile grafik lejantlarını özelleştirerek PowerPoint sunumlarını özel lejant biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, PowerPoint sunumlarındaki grafik lejantlarını özelleştirme seçenekleri sunar. Bu makale, bir lejantın konumunu ve boyutunu ayarlamayı, tüm lejant için yazı tipi boyutunu belirlemeyi, tek bir lejant girişini biçimlendirmeyi ve seçilen girişleri gizlemeyi veya geri getirmeyi gösterir.

SSS, lejant için alan ayırma, çok satırlı etiket gösterimi ve lejantın sunum temasından formatı devralması gibi ilgili davranışları kapsar.

## **Lejant Konumlandırması**

Lejantın [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/) ve [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) yöntemlerini kullanarak konumunu ve boyutunu grafiğin boyutlarının kesirleri olarak belirtebilirsiniz.

Bu örnek bir sunum oluşturur ve ilk slayta varsayılan verilerle bir kümeleme sütun grafiği ekler. İstenen lejant ofsetleri ve boyutları grafiğin genişliği ve yüksekliğiyle bölünerek göreli değerlere dönüştürülür: lejant, grafiğin sol üst köşesinden 50 puan uzakta ve 100 × 100 puan boyutundadır. Örnek, PHP/Java Bridge tarafından döndürülen grafik boyutlarını bölmeden önce PHP sayısına dönüştürmek için java_values kullanır.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Lejantın konumunu ve boyutunu grafiğe göre ifade edin.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lejantın Yazı Tipi Boyutunu Ayarlama**

Lejantın [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) yöntemiyle metin biçimlendirmesine erişin ve [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) ile yazı tipi boyutunu puan cinsinden ayarlayın.

Bu örnek, varsayılan verilerle bir grafik oluşturur ve lejant metnini 20 puana ayarlar. Ayrıca dikey eksen için otomatik sınırları devre dışı bırakır ve aralığı -5 ile 10 arasında belirler.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bireysel Lejant Girişinin Yazı Tipi Boyutunu Ayarlama**

Lejantın [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) yöntemiyle döndürülen koleksiyonu kullanarak belirli bir girişin biçimlendirmesine erişin. Giriş indeksleri sıfır tabanlıdır; `1` indeksi ikinci girişi ifade eder.

Bu örnek, varsayılan verileri içinde en az iki seriye sahip bir kümeleme sütun grafiği oluşturur. İkinci lejant girişini kalın, italik ve 20 puan mavi metin olarak biçimlendirir.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bireysel Lejant Girişlerini Gizleme**

Bir yardımcı seriyi verileri görünür tutarken lejanttan çıkarmak için, [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/) üzerinden [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) metodunu `true` olarak çağırın. Bu, yalnızca seçilen lejant girişini gizler; seriyi veya veri noktalarını kaldırmaz. Buna karşılık, [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) metodunu `false` ile çağırmak tüm lejantı gizler.

Aşağıdaki örnek, varsayılan verilerle birden çok seri içeren bir kümeleme sütun grafiği oluşturur. İkinci serinin lejant girişini (indeks `1`) gizler ve sunumu kaydeder. Ardından, [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) metodunu `false` olarak çağırarak girişi geri getirir ve ikinci bir kopya kaydeder. Sütunlar her iki dosyada da görünür kalır.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // aynı girişi grafik verisini değiştirmeden geri yükle.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki karşılaştırma, tüm lejant girişlerinin görünür olduğu ve ikinci girişin gizlendiği aynı grafiği gösterir. İkinci serinin sütunları değişmeden kalır.

![Lejantın tüm girişleri görünürken ve Seri 2 lejanttan gizlenirken bir grafiğin karşılaştırması; tüm sütunlar görünür kalır.](hide-legend-entry.png)

Sütun, çubuk ve çizgi grafiklerinde lejant girişleri serileri tanımlar. Pasta grafiklerinde ise bireysel veri noktalarını (dilimleri) tanımlar; bu yüzden seçili dilim için [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) kullanılmalıdır. API, bu veri noktası metodunu `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` ve `BarOfPie` grafik tipleri için dökümante eder. Donut grafikleri için geçerli olduğunu varsayılamaz.

## **SSS**

**Grafiğin lejant için üzerine bindirmek yerine alan ayırmasını sağlayabilir miyim?**

Evet. Lejantın grafik alanıyla çakışmasını önlemek için `false` ile [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) metodunu çağırın.

**Çok satırlı lejant etiketleri oluşturabilir miyim?**

Evet. Genişlik yetersiz olduğunda uzun etiketler satır başı alabilir. Ayrıca satır sonu karakterlerini seri adlarında kullanarak satır kırılması isteyebilirsiniz.

**Lejantın sunum temasının renk şemasını takip etmesini nasıl sağlarım?**

Lejantın renklerini, doldurmalarını ve yazı tiplerini ayarlamadan bırakın; böylece tema formatını devralır. Açıkça yapılan biçimlendirme, ilgili tema ayarlarını geçersiz kılar.