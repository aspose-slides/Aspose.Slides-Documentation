---
title: Python üzerinden Java ile PowerPoint Grafiklerini Canlandırın
linktitle: Canlandırılmış Grafikler
type: docs
weight: 80
url: /tr/python-java/animated-charts/
keywords:
- grafik
- canlandırılmış grafik
- grafik animasyonu
- grafik serisi
- grafik kategori
- seri öğesi
- kategori öğesi
- efekt ekle
- efekt tipi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python üzerinden Java'da çarpıcı animasyonlu grafikler oluşturun. PPT ve PPTX dosyalarında dinamik görsellerle sunumları güçlendirin—şimdi başlayın."
---
## **Giriş**

Aspose.Slides for Python via Java, grafik öğelerinin animasyonunu destekler. **Series**, **Categories**, **Series Elements**, ve **Category Elements**, [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) metodunu ve iki enumu kullanarak animasyonlandırılabilir: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effectchartmajorgroupingtype/) ve [EffectChartMinorGroupingType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Grafik Serisi Animasyonu**

Bir grafik serisini animasyonlandırmak istiyorsanız, aşağıda listelenen adımlara göre kodu yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine bir referans alın.
3. Seriyi animasyonlandırın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnek grafik serilerini animasyonlandırır. Örnek dosyadaki grafik üç seriye sahiptir, bu yüzden 0 ile 2 arasındaki her indeks için bir efekt eklenir. Aspose.Slides, indeksi grafik verileriyle kontrol etmez ve var olmayan bir seri için eklenen efekt dosyaya yazılır ancak hiçbir şey animasyonlandırmaz—kendi grafiğinizdeki seri sayısının altında bir indeks kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Sunumu yükleyin.
presentation = Presentation("ExistingChart.pptx")
try:
    # Grafik nesnesine bir referans alın.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Grafik öğelerini animasyonlandırın.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Değiştirilmiş sunumu diske yazın.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Kategori Animasyonu**

Bir grafik kategorisini animasyonlandırmak istiyorsanız, aşağıdaki adımlara göre kodu yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine bir referans alın.
3. Kategoriyi animasyonlandırın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnek grafik kategorilerini animasyonlandırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Sunumu yükleyin.
presentation = Presentation("ExistingChart.pptx")
try:
    # Grafik nesnesine bir referans alın.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Grafik öğelerini animasyonlandırın.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Değiştirilmiş sunumu diske yazın.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Seri Öğesinde Animasyon**

Seri öğelerini animasyonlandırmak istiyorsanız, aşağıdaki adımlara göre kodu yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine bir referans alın.
3. Seri öğelerini animasyonlandırın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnek seri öğelerini animasyonlandırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Sunumu yükleyin.
presentation = Presentation("ExistingChart.pptx")
try:
    # Grafik nesnesine bir referans alın.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Grafik öğelerini animasyonlandırın.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Değiştirilmiş sunumu diske yazın.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategori Öğesinde Animasyon**

Kategori öğelerini animasyonlandırmak istiyorsanız, aşağıdaki adımlara göre kodu yazın:

1. Sunumu yükleyin.
2. Grafik nesnesine bir referans alın.
3. Kategori öğelerini animasyonlandırın.
4. Sunum dosyasını diske yazın.

Aşağıdaki örnek kategori öğelerini animasyonlandırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Sunumu yükleyin.
presentation = Presentation("ExistingChart.pptx")
try:
    # Grafik nesnesine bir referans alın.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Grafik öğelerini animasyonlandırın.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Değiştirilmiş sunumu diske yazın.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Farklı efekt türleri (ör. giriş, vurgu, çıkış) normal şekillerde olduğu gibi grafiklerde de destekleniyor mu?**  
Evet. Bir grafik bir şekil olarak ele alındığından, giriş, vurgu ve çıkış dahil olmak üzere standart animasyon efekt türlerini destekler; bunlar slayt zaman çizelgesi ve animasyon dizileri aracılığıyla tam kontrol edilebilir.

**Grafik animasyonunu slayt geçişleriyle birleştirebilir miyim?**  
Evet. [Transitions](/slides/tr/python-java/slide-transition/) slayta uygulanırken, animasyon efektleri slayttaki nesnelere uygulanır. Aynı sunumda her ikisini birlikte kullanabilir ve bağımsız olarak kontrol edebilirsiniz.

**Grafik animasyonları PPTX olarak kaydedildiğinde korunur mu?**  
Evet. [save to PPTX](/slides/tr/python-java/save-presentation/) yaptığınızda, tüm animasyon efektleri ve sıralamaları korunur çünkü bunlar sunumun yerel animasyon modelinin bir parçasıdır.

**Var olan bir sunumdan grafik animasyonlarını okuyup değiştirebilir miyim?**  
Evet. API, slayt zaman çizelgesine, dizilere ve efektlere erişim sağlar; böylece mevcut grafik animasyonlarını inceleyebilir ve her şeyi baştan yaratmadan ayarlayabilirsiniz.

**Aspose.Slides kullanarak grafik animasyonlarını içeren bir video üretebilir miyim?**  
Evet. [export a presentation to video](/slides/tr/python-java/convert-powerpoint-to-video/) yaparak animasyonları koruyabilir, zamanlamaları ve diğer dışa aktarım ayarlarını yapılandırarak ortaya çıkan klibin animasyonlu oynatımı yansıtmasını sağlayabilirsiniz.