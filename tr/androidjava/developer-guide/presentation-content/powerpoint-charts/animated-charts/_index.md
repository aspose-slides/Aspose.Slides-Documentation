---
title: Android'de PowerPoint Grafiklerini Animasyonla
linktitle: Animasyonlu Grafikler
type: docs
weight: 80
url: /tr/androidjava/animated-charts/
keywords:
- grafik
- animasyonlu grafik
- grafik animasyonu
- grafik serisi
- grafik kategori
- seri öğesi
- kategori öğesi
- efekt ekle
- efekt tipi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java'da çarpıcı animasyonlu grafikler oluşturun. PPT ve PPTX dosyalarında dinamik görsellerle sunumları güçlendirin—şimdi başlayın."
---
## **Giriş**

Aspose.Slides for Android via Java, grafik öğelerinin animasyonunu destekler. **Series**, **Categories**, **Series Elements**, **Categories Elements** [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) yöntemi ve iki enum olan [EffectChartMajorGroupingType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/EffectChartMajorGroupingType) ve [EffectChartMinorGroupingType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/EffectChartMinorGroupingType) ile animasyonlandırılabilir.

## **Grafik Seri Animasyonu**
Grafik serisini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kodu yazın:

1. Sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Seriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, grafik serisini animasyonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referans alın
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Seriyi animasyonla
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Değiştirilmiş sunumu diske yaz
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafik Kategori Animasyonu**
Grafik kategorisini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kodu yazın:

1. Sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Kategoriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, grafik kategorisini animasyonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Seri Öğesinde Animasyon**
Seri öğelerini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kodu yazın:

1. Sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Seri öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, serinin öğelerini animasyonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referans alın
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Seri öğelerini animasyonla
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Sunum dosyasını diske yaz 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kategori Öğesinde Animasyon**
Kategori öğelerini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kodu yazın:

1. Sunumu yükleyin.
1. Grafik nesnesine referans alın.
1. Kategori öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, kategori öğelerini animasyonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referans alın
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Kategori öğelerini animasyonla
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Sunum dosyasını diske yaz
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Grafiklerde, normal şekillerde olduğu gibi farklı efekt tipleri (ör. giriş, vurgu, çıkış) destekleniyor mu?**  
Evet. Bir grafik şekil olarak değerlendirilir, bu nedenle giriş, vurgu ve çıkış dahil standart animasyon efekt tiplerini destekler, slayt zaman çizelgesi ve animasyon sıralamaları üzerinden tam kontrol sağlar.

**Grafik animasyonunu slayt geçişleriyle birleştirebilir miyim?**  
Evet. [Transitions](/slides/tr/androidjava/slide-transition/) slayta uygulanırken, animasyon efektleri slayttaki nesnelere uygulanır. İkisini aynı sunumda birlikte kullanabilir ve bağımsız olarak kontrol edebilirsiniz.

**Grafik animasyonları PPTX olarak kaydedildiğinde korunuyor mu?**  
Evet. [save to PPTX](/slides/tr/androidjava/save-presentation/) yaparken, tüm animasyon efektleri ve sıralamaları korunur çünkü bunlar sunumun yerel animasyon modelinin bir parçasıdır.

**Mevcut bir sunumdan grafik animasyonlarını okuyup değiştirebilir miyim?**  
Evet. API, slayt zaman çizelgesi, sıralamalar ve efektlere erişim sağlar, böylece mevcut grafik animasyonlarını inceleyebilir ve her şeyi yeniden oluşturmadan ayarlayabilirsiniz.

**Aspose.Slides kullanarak grafik animasyonlarını içeren bir video üretebilir miyim?**  
Evet. [export a presentation to video](/slides/tr/androidjava/convert-powerpoint-to-video/) yaparken animasyonları koruyabilir, zamanlamaları ve diğer dışa aktarma ayarlarını yapılandırarak ortaya çıkan klibin animasyonlu oynatımını sağlayabilirsiniz.