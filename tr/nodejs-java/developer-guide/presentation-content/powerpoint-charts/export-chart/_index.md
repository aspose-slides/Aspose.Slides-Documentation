---
title: JavaScript'te Sunum Grafiklerini Dışa Aktarma
linktitle: Grafiği Dışa Aktar
type: docs
weight: 90
url: /tr/nodejs-java/export-chart/
keywords:
- grafik
- grafiği resme
- grafik resim olarak
- grafik resmi çıkar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile sunum grafiklerini nasıl dışa aktaracağınızı öğrenin, PPT ve PPTX formatlarını destekler ve raporlamayı herhangi bir iş akışına sorunsuz entegre eder."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan bir grafiği resim olarak dışa aktarmanıza izin verir. Bu makale, bir grafikten nasıl resim alacağınızı ve kaydedeceğinizi gösterir; bu, grafik görsellerini PowerPoint sunumu dışındaki yerlerde yeniden kullanmanız gerektiğinde faydalıdır.

## **Grafik Resmi Al**
Aspose.Slides for Node.js via Java, belirli bir grafiğin resmini çıkarmayı destekler. Aşağıda örnek bir örnek verilmiştir.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Bir grafiği raster resim yerine vektör (SVG) olarak dışa aktarabilir miyim?**

Evet. Bir grafik bir şekildir ve içeriği, [shape-to-SVG kaydetme yöntemi](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/) kullanılarak SVG olarak kaydedilebilir.

**Dışa aktarılan grafiğin piksel cinsinden tam boyutunu nasıl ayarlayabilirim?**

Boyut veya ölçeği belirlemenizi sağlayan image-rendering aşırı yüklemelerini kullanın—kütüphane, verilen boyutlar/ölçekle nesneleri renderlemeyi destekler.

**Etiketlerde ve açıklama kutusundaki yazı tipleri dışa aktarma sonrası yanlış görünüyor ise ne yapmalıyım?**

[Gerekli yazı tiplerini yükleyin](/slides/tr/nodejs-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/fontsloader/) grafiğin render'ının ölçümleri ve metin görünümünü korumasını sağlar.

**Dışa aktarma, PowerPoint teması, stilleri ve efektleri korur mu?**

Evet. Aspose.Slides render'ı, sunumun biçimlendirmesini (temalar, stiller, doldurmalar, efektler) izler; bu sayede grafiğin görünümü korunur.

**Grafik görüntülerinin ötesindeki mevcut render/dışa aktarma yeteneklerini nerede bulabilirim?**

Çıktı hedefleri için [API](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/)/[belgelendirme](/slides/tr/nodejs-java/convert-powerpoint/) bölümüne bakın ([PDF](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/tr/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/), vb.) ve ilgili render seçeneklerine.