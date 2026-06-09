---
title: PHP Kullanarak Treemap ve Sunburst Grafiklerinde Veri Noktalarını Özelleştirme
linktitle: Treemap ve Sunburst Grafiklerindeki Veri Noktaları
type: docs
url: /tr/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap grafiği
- sunburst grafiği
- veri noktası
- etiket rengi
- dal rengi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak treemap ve sunburst grafiklerinde veri noktalarını nasıl yöneteceğinizi öğrenin, PowerPoint formatlarıyla uyumludur."
---
## **Giriş**

PowerPoint grafiklerinin diğer türlerinin yanı sıra iki “hiyerarşik” tür vardır - **Treemap** ve **Sunburst** grafiği (Sunburst Grafiği, Sunburst Diyagramı, Radial Grafik, Radial Çizim veya Çok Seviyeli Pasta Grafiği olarak da bilinir). Bu grafikler, yapraklardan dalın en üstüne kadar bir ağaç şeklinde düzenlenmiş hiyerarşik verileri gösterir. Yapraklar, seri veri noktalarıyla tanımlanır ve sonraki her iç içe grup seviyesi ilgili kategoriyle tanımlanır. Aspose.Slides for PHP via Java, Sunburst Grafik ve Treemap veri noktalarını biçimlendirmeye olanak tanır.

İşte bir Sunburst Grafik, Series1 sütunundaki veriler yaprak düğümleri tanımlar, diğer sütunlar ise hiyerarşik veri noktalarını tanımlar:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Sunburst grafiğini sunuma eklemeye başlayalım:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Ayrıca bakınız" %}} 
- [**PHP ile PowerPoint Sunum Grafikleri Oluşturma veya Güncelleme**](/slides/tr/php-java/create-chart/)
{{% /alert %}}

Grafiğin veri noktalarını biçimlendirmek gerekiyorsa, aşağıdakileri kullanmalıyız:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevel/) sınıfları 
ve [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) yöntemi, Treemap ve Sunburst grafiklerinin veri noktalarını biçimlendirmeye erişim sağlar. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevelsmanager/) çok seviyeli kategorilere erişmek için kullanılır – bu, [**ChartDataPointLevel**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevel/) nesnelerinin konteynerini temsil eder. 
Temelde, veri noktalarına özgü ek özelliklerle [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartcategorylevelsmanager/) için bir sarmalayıcıdır. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevel/) sınıfı iki yönteme sahiptir: [**getFormat**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevel/#getFormat) ve [**getDataLabel**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatapointlevel/#getLabel); bu yöntemler ilgili ayarlara erişim sağlar.

## **Bir Veri Noktasının Değerini Göster**

"Leaf 4" veri noktasının değerini göster:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Bir Veri Noktasının Etiketini ve Rengini Ayarla**

"Branch 1" veri etiketini kategori adı yerine seri adı ("Series1") gösterecek şekilde ayarlayın. Ardından metin rengini sarıya değiştirin:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Bir Veri Noktasının Dal Rengini Ayarla**

"Steam 4" dalının rengini değiştirin:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **SSS**

**Sunburst/Treemap segmentlerinin sırasını (sıralamasını) değiştirebilir miyim?**

Hayır. PowerPoint segmentleri otomatik olarak sıralar (genellikle azalan değerlerle, saat yönünde). Aspose.Slides bu davranışı yansıtır: sıralamayı doğrudan değiştiremezsiniz; bunu veriyi ön işleyerek elde edersiniz.

**Sunum temasının segment ve etiket renklerini nasıl etkilediği?**

Grafik renkleri, doldurulmaları/yazı tiplerini açıkça ayarlamazsanız sunumun [tema/renk paleti](/slides/tr/php-java/presentation-theme/) üzerinden devralınır. Tutarlı sonuçlar için, gereken katmanlarda katı doldurmaları ve metin biçimlendirmesini sabitleyin.

**PDF/PNG'ye dışa aktarırken özel dal renkleri ve etiket ayarları korunur mu?**

Evet. Sunumu dışa aktarırken, grafik ayarları (doldurmalar, etiketler) çıktı formatlarında korunur çünkü Aspose.Slides, grafiğin uygulanmış biçimlendirmesiyle render eder.

**Grafiğin üzerine özel bindirme yerleştirmek için bir etiket/öğenin gerçek koordinatlarını hesaplayabilir miyim?**

Evet. Grafik yerleşimi doğrulandıktan sonra öğeler için gerçek *x* ve gerçek *y* değerleri (örneğin bir [DataLabel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/datalabel/)) mevcuttur; bu, bindirmelerin kesin konumlandırılmasına yardımcı olur.