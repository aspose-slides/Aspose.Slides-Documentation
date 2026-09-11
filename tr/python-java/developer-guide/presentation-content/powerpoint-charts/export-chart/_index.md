---
title: Python via Java ile Sunum Grafiklerini Dışa Aktarın
linktitle: Grafiği Dışa Aktar
type: docs
weight: 90
url: /tr/python-java/export-chart/
keywords:
- grafik
- grafik görüntüye
- grafik görüntü olarak
- grafik görüntüsünü çıkar
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PPT ve PPTX formatlarını destekleyen sunum grafiklerini dışa aktarmayı öğrenin ve raporlamayı herhangi bir iş akışına entegre edin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan bir grafiği görüntü olarak dışa aktarmanıza olanak tanır. Bu makale, bir grafikten nasıl bir görüntü alıp kaydedebileceğinizi gösterir; bu, grafik görsellerini PowerPoint sunumu dışında yeniden kullanmanız gerektiğinde faydalıdır.

Temel görüntü dışa aktarma iş akışına ek olarak, makale SVG'ye grafik içeriği kaydetme, render seçenekleriyle çıktı boyutunu kontrol etme, etiket ve lejand görünümünü korumak için yazı tiplerini yükleme ve render sırasında temalar, stiller, dolgu ve efektler gibi orijinal sunum biçimlendirmesini koruma gibi yaygın dışa aktarım sorularını da ele alır.

## **Bir Grafik Görüntüsü Al**
Aspose.Slides for Python via Java, belirli bir grafiğin görüntüsünü çıkarmayı destekler. Aşağıdaki örnek bunun nasıl yapılacağını gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **SSS**

**Bir grafiği raster görüntü yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir grafik bir şekildir ve içeriği, [shape-to-SVG saving method](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#writeAsSvgToBytes) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan grafiğin piksel cinsinden tam boyutunu nasıl ayarlayabilirim?**

Boyut veya ölçeği belirlemenizi sağlayan görüntü render aşırı yüklemelerini kullanın—kütüphane, verilen boyut/ölçekle nesneleri render etmeyi destekler.

**Etiketlerde ve lejanda kullanılan yazı tipleri dışa aktarıldıktan sonra yanlış görünüyorsa ne yapmalıyım?**

[Gerekli yazı tiplerini](/slides/tr/python-java/custom-font/) [FontsLoader](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fontsloader/) aracılığıyla yükleyin, böylece grafik renderı ölçümleri ve metin görünümünü korur.

**Dışa aktarım PowerPoint teması, stilleri ve efektleri korur mu?**

Evet. Aspose.Slides render'ı, sunumun biçimlendirmesini (temalar, stiller, dolgu, efektler) takip eder, bu yüzden grafiğin görünümü korunur.

**Grafik görüntülerinin ötesindeki mevcut render/dışa aktarma yeteneklerini nerede bulabilirim?**

Çıktı hedefleri ([PDF](/slides/tr/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/tr/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/python-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/python-java/convert-powerpoint-to-html/), vb.) ve ilgili render seçenekleri için [API](https://reference.aspose.com/slides/tr/python-java/aspose.slides/)/[belgelendirme](/slides/tr/python-java/convert-powerpoint/) bölümüne bakın.