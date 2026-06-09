---
title: .NET'te PowerPoint Grafiklerini Animasyonla
linktitle: Animasyonlu Grafikler
type: docs
weight: 80
url: /tr/net/animated-charts/
keywords:
- grafik
- animasyonlu grafik
- grafik animasyonu
- grafik serisi
- grafik kategori
- seri öğesi
- kategori öğesi
- efekt ekle
- efekt türü
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te çarpıcı animasyonlu grafikler oluşturun. PPT ve PPTX dosyalarında dinamik görsellerle sunumları güçlendirin—şimdi başlayın."
---
## **Giriş**

Aspose.Slides for .NET, grafik öğelerinin animasyonunu destekler. **Series**, **Categories**, **Series Elements**, **Categories Elements** [ISequence.AddEffect](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/methods/addeffect) yöntemi ve iki enum [EffectChartMajorGroupingType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effectchartmajorgroupingtype) ve [EffectChartMinorGroupingType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effectchartminorgroupingtype) ile animasyon yapılabilir.

## **Grafik Serisi Animasyonu**
Bir grafik serisini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kod yazın:

1. Bir sunum yükleyin.
1. Grafik nesnesine referans alın.
1. Seriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, grafik serisini animasyonladık.

```c#
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin 
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Grafik nesnesine referans alın
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Seriyi animasyonlayın
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Değiştirilmiş sunumu diske yazın 
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Grafik Kategori Animasyonu**
Bir grafik kategorisini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kod yazın:

1. Bir sunum yükleyin.
1. Grafik nesnesine referans alın.
1. Kategoriyi animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, grafik kategorisini animasyonladık.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Grafik nesnesine referans alın
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Kategorilerin öğelerini animasyonlayın
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Sunum dosyasını diske yazın
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **Seri Öğesinde Animasyon**
Seri öğelerini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kod yazın:

1. Bir sunum yükleyin.
1. Grafik nesnesine referans alın.
1. Seri öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, seri öğelerini animasyonladık.

```c#
 // Sunumu yükle
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // Grafik nesnesine referans alın
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // Seri öğelerini animasyonlayın
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Sunum dosyasını diske yazın 
     presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
```

## **Kategori Öğesinde Animasyon**
Kategori öğelerini animasyonlamak istiyorsanız, aşağıda listelenen adımlara göre kod yazın:

1. Bir sunum yükleyin.
1. Grafik nesnesine referans alın.
1. Kategori öğelerini animasyonlayın.
1. Sunum dosyasını diske yazın.

Aşağıdaki örnekte, kategori öğelerini animasyonladık.

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Grafik nesnesine referans alın
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // Kategorilerin öğelerini animasyonlayın
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Sunum dosyasını diske yazın
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Grafikler için, normal şekiller gibi farklı efekt türleri (ör. giriş, vurgu, çıkış) destekleniyor mu?**  
Evet. Bir grafik bir şekil olarak kabul edildiği için, giriş, vurgu ve çıkış dahil olmak üzere standart animasyon efekt türlerini destekler ve slaytın zaman çizelgesi ve animasyon sıralamaları aracılığıyla tam kontrol sağlar.

**Grafik animasyonunu slayt geçişleriyle birleştirebilir miyim?**  
Evet. [Transitions](/slides/tr/net/slide-transition/) slayta uygulanırken, animasyon efektleri slayttaki nesnelere uygulanır. Aynı sunumda ikisini birlikte kullanabilir ve bağımsız olarak kontrol edebilirsiniz.

**Grafik animasyonları PPTX olarak kaydedildiğinde korunuyor mu?**  
Evet. [PPTX olarak kaydet](/slides/tr/net/save-presentation/) yaptığınızda, tüm animasyon efektleri ve sıralamaları korunur çünkü bunlar sunumun yerel animasyon modelinin bir parçasıdır.

**Mevcut bir sunumdan grafik animasyonlarını okuyup değiştirebilir miyim?**  
Evet. [API](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/) slayt zaman çizelgesi, sıralamaları ve efektlere erişim sağlar; böylece mevcut grafik animasyonlarını inceleyebilir ve her şeyi yeniden oluşturmadan ayarlayabilirsiniz.

**Aspose.Slides kullanarak grafik animasyonları içeren bir video üretebilir miyim?**  
Evet. [Sunumu video olarak dışa aktar](/slides/tr/net/convert-powerpoint-to-video/) yapabilir, animasyonları koruyabilir, zamanlamaları ve diğer dışa aktarma ayarlarını yapılandırarak son klibin animasyonlu oynatımı yansıtmasını sağlayabilirsiniz.