---
title: JavaScript ile PowerPoint Grafiklerini Canlandırma
linktitle: Animasyonlu Grafikler
type: docs
weight: 80
url: /tr/nodejs-java/animated-charts/
keywords:
- grafik
- animasyonlu grafik
- grafik animasyonu
- grafik serisi
- grafik kategori
- seri öğesi
- kategori öğesi
- etki ekle
- etki türü
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te çarpıcı animasyonlu grafikler oluşturun. PPT ve PPTX dosyalarında dinamik görsellerle sunumları güçlendirin—şimdi başlayın."
---
## **Giriş**

Aspose.Slides for Node.js via Java, grafik öğelerini animasyonlamayı destekler. **Series**, **Categories**, **Series Elements**, **Categories Elements** [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) yöntemi ve iki enum olan [EffectChartMajorGroupingType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effectchartmajorgroupingtype/) ve [EffectChartMinorGroupingType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effectchartminorgroupingtype/) ile animasyonlandırılabilir.

## **Grafik Serisi Animasyonu**
Bir grafik serisini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Seriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte grafik serisini animasyonladık.

```javascript
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referans alın
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Seriyi animasyonlayın
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.BySeries, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Değiştirilmiş sunumu diske kaydedin
    pres.save("AnimatingSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Grafik Kategori Animasyonu**
Bir grafik kategorisini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Kategoriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte grafik kategorisini animasyonladık.

```javascript
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMajorGroupingType.ByCategory, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    pres.save("Sample_Animation_C.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Seri Öğesi İçinde Animasyon**
Seri öğelerini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Seri öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte seri öğelerini animasyonladık.

```javascript
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referans alın
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Seri öğelerini animasyonlayın
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInSeries, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Sunum dosyasını diske kaydedin
    pres.save("AnimatingSeriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kategori Öğesi İçinde Animasyon**
Kategori öğelerini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kod yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Kategori öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte kategori öğelerini animasyonladık.

```javascript
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referans alın
    var slide = pres.getSlides().get_Item(0);
    var shapes = slide.getShapes();
    var chart = shapes.get_Item(0);
    // Kategori öğelerini animasyonlayın
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 0, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 1, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 0, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    slide.getTimeline().getMainSequence().addEffect(chart, aspose.slides.EffectChartMinorGroupingType.ByElementInCategory, 2, 3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Sunum dosyasını diske kaydedin
    pres.save("AnimatingCategoriesElements_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Grafikler için normal şekillerde olduğu gibi farklı etki türleri (ör. giriş, vurgu, çıkış) destekleniyor mu?**

Evet. Bir grafik şekil olarak kabul edilir, bu nedenle giriş, vurgu ve çıkış dahil olmak üzere standart animasyon etki türlerini destekler ve slayt zaman çizelgesi ve animasyon sıralamaları üzerinden tam kontrol sağlar.

**Grafik animasyonunu slayt geçişleriyle birleştirebilir miyim?**

Evet. [Transitions](/slides/tr/nodejs-java/slide-transition/) slayta uygulanırken, animasyon etkileri slayttaki nesnelere uygulanır. İkisini aynı sunumda birlikte kullanabilir ve bağımsız olarak kontrol edebilirsiniz.

**Grafik animasyonları PPTX olarak kaydedildiğinde korunuyor mu?**

Evet. [save to PPTX](/slides/tr/nodejs-java/save-presentation/) yaptığınızda, tüm animasyon etkileri ve sıralamaları sunumun yerel animasyon modelinin bir parçası olduğu için korunur.

**Mevcut bir sunumdan grafik animasyonlarını okuyup değiştirebilir miyim?**

Evet. API, slayt zaman çizelgesi, sıralamalar ve etkiler üzerinden erişim sağlar; böylece mevcut grafik animasyonlarını inceleyebilir ve her şeyi yeniden oluşturmak zorunda kalmadan ayarlayabilirsiniz.

**Aspose.Slides ile grafik animasyonlarını içeren bir video üretebilir miyim?**

Evet. [export a presentation to video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) yaparak animasyonları koruyabilir, zamanlamaları ve diğer dışa aktarma ayarlarını yapılandırarak oluşan klibin animasyonlu oynatımı yansıtmasını sağlayabilirsiniz.