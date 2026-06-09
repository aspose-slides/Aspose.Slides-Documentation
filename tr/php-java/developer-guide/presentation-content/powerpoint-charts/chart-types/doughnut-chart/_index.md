---
title: PHP Kullanarak Sunumlarda Doughnut Grafiklerini Özelleştirme
linktitle: Doughnut Grafik
type: docs
weight: 30
url: /tr/php-java/doughnut-chart/
keywords:
- doughnut grafik
- merkez boşluk
- delik boyutu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides'te doughnut grafiklerini nasıl oluşturup özelleştireceğinizi keşfedin; dinamik sunumlar için PowerPoint formatlarını destekler."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde bir doughnut grafiğiyle çalışmayı, grafiği bir slayta eklemeyi, merkez deliğinin boyutunu ayarlamayı ve sunumu kaydetmeyi göstermektedir. `setDoughnutHoleSize` yöntemine odaklanır ve bu grafik tipini kod içinde özelleştirmek için gerekli temel adımları gösterir.

Ayrıca, birden fazla seri kullanarak birden çok halka oluşturma, patlatılmış doughnut grafiklerle çalışma ve bir grafiği raster görüntü veya SVG olarak dışa aktarma gibi ilgili doughnut grafiği senaryolarını kapsayan kısa bir SSS bölümü de içerir.

## **Doughnut Grafikinde Merkez Boşluğunu Belirleme**

Doughnut grafiğindeki deliğin boyutunu belirtmek için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) nesnesi örnekleyin.
1. Slayta bir doughnut grafiği ekleyin.
1. Doughnut grafiğindeki deliğin boyutunu belirtin.
1. Sunumu diske yazın.

Aşağıdaki örnekte, doughnut grafiğindeki deliğin boyutunu ayarladık.

```php
  # Presentation sınıfının bir örneğini oluştur
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Sunumu diske kaydet
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Birden fazla halka ile çok seviyeli bir doughnut oluşturabilir miyim?**

Evet. Tek bir doughnut grafiğine birden fazla seri ekleyin—her seri ayrı bir halka olur. Halka sırası, serilerin koleksiyondaki sırasına göre belirlenir.

**"Patlatılmış" bir doughnut (ayrılmış dilimler) destekleniyor mu?**

Evet. Bir Exploded Doughnut [chart type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/charttype/) ve veri noktalarında bir patlatma özelliği vardır; bireysel dilimleri ayırabilirsiniz.

**Bir rapor için doughnut grafiğinin (PNG/SVG) görüntüsünü nasıl elde edebilirim?**

Bir grafik bir şekildir; onu bir [raster image](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getImage) olarak render edebilir veya grafiği bir [SVG image](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#writeAsSvg) olarak dışa aktarabilirsiniz.