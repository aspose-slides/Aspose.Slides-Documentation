---
title: C++ ile Sunum Grafiklerini Dışa Aktar
linktitle: Grafiği Dışa Aktar
type: docs
weight: 90
url: /tr/cpp/export-chart/
keywords:
- grafik
- grafikten görüntüye
- grafik görüntüsü
- grafik görüntüsü çıkarma
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile sunum grafiklerini dışa aktarmayı, PPT ve PPTX formatlarını desteklemeyi ve raporlamayı herhangi bir iş akışına sorunsuz bir şekilde entegre etmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan grafiği görüntü olarak dışa aktarmanıza olanak tanır. Bu makale, bir grafikten görüntü almayı ve kaydetmeyi gösterir; bu, grafik görsellerini PowerPoint sunumu dışına yeniden kullanmanız gerektiğinde faydalıdır.

## **Grafik Görüntüsü Al**
Aspose.Slides for C++ belirli bir grafiğin görüntüsünü çıkarmayı destekler. Aşağıda örnek bir örnek verilmiştir.  

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **SSS**

**Grafiği raster görüntü yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Grafik bir şekildir ve içeriği, [shape-to-SVG kaydetme yöntemi](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan grafiğin piksel cinsinden kesin boyutunu nasıl ayarlayabilirim?**

Boyut veya ölçeği belirlemenizi sağlayan görüntü‑renderleme aşırı yüklemelerini kullanın—kütüphane, verilen boyut/ölçekle nesneleri renderlemeyi destekler.

**Etiketlerde ve lejendeki yazı tipleri dışa aktarıldıktan sonra yanlış görünüyorsa ne yapmalıyım?**

[Gerekli yazı tiplerini yükleyin](/slides/tr/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/) böylece grafik renderlaması ölçümleri ve metin görünümünü korur.

**Dışa aktarma, PowerPoint teması, stilleri ve efektleri korur mu?**

Evet. Aspose.Slides renderlayıcı, sunumun biçimlendirmesini (temalar, stiller, doldurmalar, efektler) izler, bu sayede grafiğin görünümü korunur.

**Grafik görüntülerinin ötesindeki mevcut renderleme/dışa aktarma yeteneklerini nerede bulabilirim?**

Çıktı hedefleri ([PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/), vb.) ve ilgili renderleme seçenekleri için [API]https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/ /[belgelendirme](/slides/tr/cpp/convert-powerpoint/) bölümüne bakın.