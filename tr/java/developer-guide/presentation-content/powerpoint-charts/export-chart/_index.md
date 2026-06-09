---
title: Java'da Sunum Grafiklerini Dışa Aktar
linktitle: Grafiği Dışa Aktar
type: docs
weight: 90
url: /tr/java/export-chart/
keywords:
- grafik
- grafiği görüntüye
- grafik görüntü olarak
- grafik görüntüsü çıkar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile sunum grafiklerini nasıl dışa aktaracağınızı öğrenin, PPT ve PPTX formatlarını destekler ve raporlamayı herhangi bir iş akışına sorunsuz bir şekilde entegre eder."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan grafiği görüntü olarak dışa aktarmanızı sağlar. Bu makale, bir grafikten nasıl bir görüntü elde edileceğini ve kaydedileceğini gösterir; bu, grafik görsellerini PowerPoint sunumu dışında tekrar kullanmanız gerektiğinde faydalıdır.

Temel görüntü dışa aktarma iş akışının yanı sıra, makale SVG'ye grafik içeriğini kaydetme, çıktı boyutunu render seçenekleriyle kontrol etme, etiket ve lejand görünümünü korumak için yazı tiplerini yükleme ve render sırasında temalar, stiller, doldurmalar ve efektler gibi orijinal sunum biçimlendirmesini koruma gibi yaygın dışa aktarma sorularını da ele alır.

## **Grafik Görüntüsü Al**
Aspose.Slides for Java, belirli bir grafiğin görüntüsünü çıkarma desteği sağlar. Aşağıdaki örnek verilmiştir.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Grafiği raster görüntü yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir grafik bir şekildir ve içeriği, [SVG kaydetme yöntemi](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) kullanılarak SVG'ye kaydedilebilir.

**Dışa aktarılan grafiğin piksel cinsinden tam boyutunu nasıl ayarlayabilirim?**

Boyut veya ölçeği belirtebilen görüntü render aşırı yüklemelerini kullanın—kütüphane verilen boyut/ölçekle nesneleri render etmeyi destekler.

**Etiketlerde ve lejanda kullanılan yazı tipleri dışa aktarıldıktan sonra hatalı görünüyorsa ne yapmalıyım?**

[Gerekli yazı tiplerini yükleyin](/slides/tr/java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/tr/java/com.aspose.slides/fontsloader/) böylece grafik render'ı metrikleri ve metin görünümünü korur.

**Dışa aktarma PowerPoint teması, stilleri ve efektleri dikkate alıyor mu?**

Evet. Aspose.Slides’ın render'ı, sunumun biçimlendirmesini (temalar, stiller, doldurmalar, efektler) takip eder, böylece grafiğin görünümü korunur.

**Grafik görüntülerinin ötesinde mevcut render/dışa aktarma yeteneklerini nerede bulabilirim?**

[API](https://reference.aspose.com/slides/tr/java/com.aspose.slides/)/[belgeler](/slides/tr/java/convert-powerpoint/) içinde çıktı hedeflerini ([PDF](/slides/tr/java/convert-powerpoint-to-pdf/), [SVG](/slides/tr/java/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/java/convert-powerpoint-to-xps/), [HTML](/slides/tr/java/convert-powerpoint-to-html/), vb.) ve ilgili render seçeneklerini inceleyin.