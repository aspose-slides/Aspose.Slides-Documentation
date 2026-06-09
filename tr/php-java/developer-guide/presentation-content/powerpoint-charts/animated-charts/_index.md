---
title: PHP'de PowerPoint Grafiklerini Canlandırın
linktitle: Animasyonlu Grafikler
type: docs
weight: 80
url: /tr/php-java/animated-charts/
keywords:
- grafik
- animasyonlu grafik
- grafik animasyonu
- grafik serisi
- grafik kategorisi
- seri öğesi
- kategori öğesi
- efekt ekle
- efekt tipi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile çarpıcı animasyonlu grafikler oluşturun. PPT ve PPTX dosyalarında dinamik görsellerle sunumları güçlendirin — hemen başlayın."
---
## **Giriş**

Aspose.Slides for PHP via Java, grafik öğelerinin animasyonunu destekler. **Series**, **Categories**, **Series Elements**, **Categories Elements** [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/#addEffect) yöntemi ve iki enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/EffectChartMajorGroupingType) ve [EffectChartMinorGroupingType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/EffectChartMinorGroupingType) ile animasyonlandırılabilir.

## **Grafik Serisi Animasyonu**
Bir grafik serisini animasyonlamak istiyorsanız, kodu aşağıda listelenen adımlara göre yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine referans alın.
3. Seriyi animasyonlayın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, grafik serisini animasyonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Grafiğe referans al
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Seriyi animasyonla
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Değiştirilmiş sunumu diske kaydet
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Grafik Kategori Animasyonu**
Bir grafik kategorisini animasyonlamak istiyorsanız, kodu aşağıda listelenen adımlara göre yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine referans alın.
3. Kategoriyi animasyonlayın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, grafik kategorisini animasyonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Seri Öğesinde Animasyon**
Seri öğelerini animasyonlamak istiyorsanız, kodu aşağıda listelenen adımlara göre yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine referans alın.
3. Seri öğelerini animasyonlayın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, seri öğelerini animasyonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Grafiğe referans alın
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Seri öğelerini animasyonla
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Sunum dosyasını diske kaydedin
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Kategori Öğesinde Animasyon**
Kategori öğelerini animasyonlamak istiyorsanız, kodu aşağıda listelenen adımlara göre yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine referans alın.
3. Kategori öğelerini animasyonlayın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, kategori öğelerini animasyonladık.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Grafik nesnesine referans alın
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Kategorilerin öğelerini animasyonla
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Sunum dosyasını diske kaydedin
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Grafikler için normal şekillerde olduğu gibi farklı etki türleri (ör. giriş, vurgu, çıkış) destekleniyor mu?**

Evet. Bir grafik bir şekil olarak ele alınır, bu nedenle giriş, vurgu ve çıkış dahil olmak üzere standart animasyon etki türlerini destekler; slayt zaman çizelgesi ve animasyon dizileri aracılığıyla tam kontrol sağlanır.

**Grafik animasyonunu slayt geçişleriyle birleştirebilir miyim?**

Evet. [Geçişler](/slides/tr/php-java/slide-transition/) slayta uygulanırken, animasyon efektleri slayttaki nesnelere uygulanır. İkisini aynı sunumda birlikte kullanabilir ve bağımsız olarak kontrol edebilirsiniz.

**Grafik animasyonları PPTX olarak kaydedildiğinde korunuyor mu?**

Evet. [PPTX'e kaydet](/slides/tr/php-java/save-presentation/) yaptığınızda, tüm animasyon efektleri ve sıralamaları korunur çünkü bunlar sunumun yerel animasyon modelinin bir parçasıdır.

**Mevcut bir sunumdan grafik animasyonlarını okuyup değiştirebilir miyim?**

Evet. API, slayt zaman çizelgesi, diziler ve efektlere erişim sağlar; böylece mevcut grafik animasyonlarını inceleyebilir ve her şeyi yeniden oluşturmak zorunda kalmadan ayarlayabilirsiniz.

**Aspose.Slides kullanarak grafik animasyonlarını içeren bir video üretebilir miyim?**

Evet. [Sunumu video olarak dışa aktar](/slides/tr/php-java/convert-powerpoint-to-video/) yaparak animasyonları koruyabilir, zamanlamaları ve diğer dışa aktarma ayarlarını yapılandırarak elde edilen klibin animasyonlu oynatmayı yansıtmasını sağlayabilirsiniz.