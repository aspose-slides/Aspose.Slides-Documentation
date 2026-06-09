---
title: Sunum Grafiklerini .NET'te Dışa Aktarın
linktitle: Grafiği Dışa Aktar
type: docs
weight: 90
url: /tr/net/export-chart/
keywords:
- grafik
- grafiği resme
- grafik resim olarak
- grafik resmini çıkar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile sunum grafiklerini dışa aktarmayı, PPT ve PPTX formatlarını desteklemeyi ve raporlamayı herhangi bir iş akışına sorunsuz bir şekilde entegre etmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan bir grafiği resim olarak dışa aktarmanıza olanak tanır. Bu makale, bir grafikten resim almayı ve kaydetmeyi gösterir; bu, grafik görsellerini PowerPoint sunumunun dışına yeniden kullanmanız gerektiğinde faydalıdır.

Temel resim dışa aktarma iş akışının yanı sıra, makale SVG olarak grafik içeriğini kaydetme, render seçenekleriyle çıktı boyutunu kontrol etme, etiket ve lejand görünümünü korumak için yazı tiplerini yükleme ve render sırasında temalar, stiller, doldurmalar ve efektler gibi orijinal sunum biçimlendirmesini koruma gibi yaygın dışa aktarma sorularını da ele alır.

## **Grafik Görüntüsü Alın**
Aspose.Slides for .NET, belirli bir grafiğin görüntüsünü çıkarmayı destekler. Aşağıda örnek bir kod verilmiştir.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Bir grafiği raster resim yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir grafik bir şekildir ve içeriği, [shape-to-SVG kaydetme yöntemi](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/writeassvg/) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan grafiğin tam boyutunu piksel cinsinden nasıl ayarlayabilirim?**

Boyut veya ölçeği belirlemenizi sağlayan görüntü render aşırı yüklemelerini kullanın—kütüphane, verilen boyut/ölçekle nesneleri renderlemeyi destekler.

**Etiket ve lejanddaki yazı tipleri dışa aktardıktan sonra yanlış görünüyorsa ne yapmalıyım?**

[Gerekli yazı tiplerini yükleyin](/slides/tr/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/) böylece grafik renderı ölçüleri ve metin görünümünü korur.

**Dışa aktarma, PowerPoint teması, stiller ve efektleri korur mu?**

Evet. Aspose.Slides renderlayıcısı, sunumun biçimlendirmesini (temalar, stiller, doldurmalar, efektler) takip eder, bu sayede grafiğin görünümü korunur.

**Grafik görüntülerinin ötesindeki mevcut render/dışa aktarma yeteneklerini nerede bulabilirim?**

Çıktı hedefleri ([PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [SVG](/slides/tr/net/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/net/convert-powerpoint-to-xps/), [HTML](/slides/tr/net/convert-powerpoint-to-html/), vb.) ve ilgili render seçenekleri için [API](https://reference.aspose.com/slides/tr/net/aspose.slides.export/)/[dokümantasyon](/slides/tr/net/convert-powerpoint/) bölümüne bakın.