---
title: Java'da PowerPoint Grafiklerini Canlandırma
linktitle: Animasyonlu Grafikler
type: docs
weight: 80
url: /tr/java/animated-charts/
keywords:
- grafik
- animasyonlu grafik
- grafik animasyonu
- grafik serisi
- grafik kategorisi
- seri öğesi
- kategori öğesi
- efekt ekle
- efekt türü
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da göz alıcı animasyonlu grafikler oluşturun. PPT ve PPTX dosyalarında dinamik görsellerle sunumları güçlendirin—hemen başlayın."
---
## **Introduction**

Aspose.Slides for Java, grafik öğelerinin animasyonunu destekler. **Series**, **Categories**, **Series Elements**, **Categories Elements** [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) yöntemi ve iki enum olan [EffectChartMajorGroupingType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/EffectChartMajorGroupingType) ve [EffectChartMinorGroupingType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/EffectChartMinorGroupingType) ile animasyonlandırılabilir.

## **Chart Series Animation**
Grafik serisini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kodu yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine başvuruyu alın.
1. Seriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıda verilen örnekte, grafik serisini animasyonlandırdık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referansı al
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

    // Değiştirilmiş sunumu diske kaydet
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chart Category Animation**
Grafik kategorisini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kodu yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine başvuruyu alın.
1. Kategoriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıda verilen örnekte, grafik kategorisini animasyonlandırdık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
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

## **Animation in a Series Element**
Seri öğelerini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kodu yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine başvuruyu alın.
1. Seri öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıda verilen örnekte, serinin öğelerini animasyonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referansı al
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

    // Sunum dosyasını diske kaydet 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animation in a Category Element**
Kategori öğelerini animasyonlamak istiyorsanız, aşağıdaki adımlara göre kodu yazın:

1. Bir sunumu yükleyin.
1. Grafik nesnesine başvuruyu alın.
1. Kategori öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıda verilen örnekte, kategori öğelerini animasyonladık.

```java
// Sunum dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Grafik nesnesine referansı al
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // Kategorilerin öğelerini animasyonla
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

    // Sunum dosyasını diske kaydet
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Farklı efekt türleri (ör. giriş, vurgulama, çıkış) normal şekillerde olduğu gibi grafikler için de destekleniyor mu?**

Evet. Bir grafik bir şekil gibi ele alınır, bu nedenle giriş, vurgulama ve çıkış dahil olmak üzere standart animasyon efekt türlerini destekler; slayt zaman çizelgesi ve animasyon dizileri aracılığıyla tam kontrol sağlanabilir.

**Grafik animasyonunu slayt geçişleriyle birleştirebilir miyim?**

Evet. [Transitions](/slides/tr/java/slide-transition/) slayta uygulanırken, animasyon efektleri slayttaki nesnelere uygulanır. İkisini aynı sunumda birlikte kullanabilir ve bağımsız olarak kontrol edebilirsiniz.

**Grafik animasyonları PPTX olarak kaydedildiğinde korunuyor mu?**

Evet. [save to PPTX](/slides/tr/java/save-presentation/) yaptığınızda, animasyon efektleri ve sıralamaları korunur çünkü bunlar sunumun yerel animasyon modelinin bir parçasıdır.

**Mevcut bir sunumdan grafik animasyonlarını okuyup değiştirebilir miyim?**

Evet. API, slayt zaman çizelgesine, dizilere ve efektlere erişim sağlar; böylece mevcut grafik animasyonlarını inceleyip her şeyi sıfırdan oluşturmak zorunda kalmadan ayarlayabilirsiniz.

**Aspose.Slides kullanarak grafik animasyonlarını içeren bir video üretebilir miyim?**

Evet. Animasyonları koruyarak, zamanlamaları ve diğer dışa aktarım ayarlarını yapılandırarak bir sunumu videoya [export a presentation to video](/slides/tr/java/convert-powerpoint-to-video/) edebilirsiniz; böylece oluşan klip animasyonlu oynatımı yansıtır.