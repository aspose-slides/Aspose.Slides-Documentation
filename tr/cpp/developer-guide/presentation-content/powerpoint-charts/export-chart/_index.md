---
title: C++ ile Sunum Grafiklerini Dışa Aktarın
linktitle: Grafiği Dışa Aktar
type: docs
weight: 90
url: /tr/cpp/export-chart/
keywords:
- grafik
- grafiği görüntüye
- grafik görüntüsü
- grafik görüntüsünü çıkar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak sunum grafiklerini dışa aktarmayı, PPT ve PPTX formatlarını desteklemeyi ve raporlamayı herhangi bir iş akışına sorunsuz entegre etmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan bir grafiği görüntü olarak dışa aktarmanıza olanak tanır. Bu makale, bir grafikten görüntü almayı ve kaydetmeyi gösterir; bu, grafik görsellerini PowerPoint sunumunun dışındaki yerlerde yeniden kullanmanız gerektiğinde yararlıdır.

## **Grafik Görüntüsü Al**
Aspose.Slides for C++ belirli bir grafiğin görüntüsünü çıkarmayı destekler. Aşağıda bir örnek verilmiştir.

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

**Bir grafiği raster görüntü yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir grafik bir şekildir ve içeriği, [shape-to-SVG saving method](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan grafiğin piksel cinsinden tam boyutunu nasıl ayarlayabilirim?**

Boyut veya ölçeği belirlemenizi sağlayan image-rendering aşırı yüklemelerini kullanın—kütüphane, nesneleri verilen boyut/ölçekle renderlemeyi destekler.

**Etiketlerde ve lejendeki yazı tipleri dışa aktarıldıktan sonra yanlış görünüyorsa ne yapmalıyım?**

Grafik render'ının ölçüleri ve metin görünümünü koruması için gerekli yazı tiplerini [Gerekli yazı tiplerini yükleyin](/slides/tr/cpp/custom-font/) üzerinden [FontsLoader](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/) ile yükleyin.

**Dışa aktarma PowerPoint teması, stilleri ve efektleri korur mu?**

Evet. Aspose.Slides render'ı, sunumun biçimlendirmesini (temalar, stiller, dolgu, efektler) takip eder, bu yüzden grafiğin görünümü korunur.

**Grafik görüntülerinin ötesindeki mevcut renderleme/dışa aktarma yeteneklerini nerede bulabilirim?**

Çıktı hedefleri ([PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/tr/cpp/convert-powerpoint-to-html/), vb.) ve ilgili renderleme seçenekleri için [API](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/)/[documentation](/slides/tr/cpp/convert-powerpoint/) dışa aktarma bölümüne bakın.