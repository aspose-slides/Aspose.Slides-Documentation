---
title: Android için Sunum Grafiklerini Dışa Aktarma
linktitle: Grafiği Dışa Aktar
type: docs
weight: 90
url: /tr/androidjava/export-chart/
keywords:
- grafik
- grafiği görüntüye
- grafik görüntü olarak
- grafik görüntüsünü çıkar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile sunum grafiklerini dışa aktarmayı, PPT ve PPTX formatlarını desteklemeyi ve raporlamayı herhangi bir iş akışına sorunsuz bir şekilde entegre etmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan grafiği görüntü olarak dışa aktarmanıza olanak tanır. Bu makale, bir grafikten görüntü alıp kaydetmeyi gösterir; bu, grafik görsellerini PowerPoint sunumu dışına yeniden kullanmanız gerektiğinde faydalıdır.

Temel görüntü dışa aktarma iş akışına ek olarak, makale SVG’ye grafik içeriği kaydetme, render seçenekleriyle çıktı boyutunu kontrol etme, etiket ve lejand görünümünü korumak için yazı tiplerini yükleme ve render sırasında temalar, stiller, doldurmalar ve efektler gibi orijinal sunum biçimlendirmesini koruma gibi yaygın dışa aktarma sorularını da ele alır.

## **Bir Grafik Görüntüsü Alın**
Aspose.Slides for Android via Java, belirli bir grafiğin görüntüsünü çıkarmayı destekler. Aşağıda örnek bir örnek verilmiştir.

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

**Bir grafiği raster görüntü yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir grafik bir şekildir ve içeriği, [shape-to-SVG kaydetme yöntemi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan grafiğin tam boyutunu piksel olarak nasıl ayarlayabilirim?**

Boyut veya ölçeği belirtebilen görüntü‑renderleme aşırı yüklemelerini kullanın—kütüphane, verilen boyut/ölçeğe göre nesneleri renderlemeyi destekler.

**Etiketlerde ve lejanda kullanılan yazı tipleri dışa aktardıktan sonra yanlış görünüyorsa ne yapmalıyım?**

Grafik renderi metrikleri ve metin görünümünü koruması için [gerekli yazı tiplerini](/slides/tr/androidjava/custom-font/) [FontsLoader](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsloader/) aracılığıyla yükleyin.

**Dışa aktarma PowerPoint teması, stilleri ve efektleri dikkate alıyor mu?**

Evet. Aspose.Slides’ın renderleyicisi, sunumun biçimlendirmesini (temalar, stiller, doldurmalar, efektler) izler, böylece grafik görünümü korunur.

**Grafik görüntülerinin ötesinde mevcut renderleme/dışa aktarma yeteneklerini nerede bulabilirim?**

Çıktı hedefleri ([PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/tr/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/), vb.) ve ilgili renderleme seçenekleri için [API](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/)/[dökümantasyon](/slides/tr/androidjava/convert-powerpoint/) bakın.