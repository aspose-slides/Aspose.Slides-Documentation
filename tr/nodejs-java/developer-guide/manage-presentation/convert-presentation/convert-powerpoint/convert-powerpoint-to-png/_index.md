---
title: JavaScript'te PowerPoint Slaytlarını PNG'ye Dönüştürme
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/nodejs-java/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PNG'ye
- sunumu PNG'ye
- slaytı PNG'ye
- PPT'yi PNG'ye
- PPTX'i PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine hızlı bir şekilde dönüştürerek, kesin ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını PNG görüntülerine dönüştürmeyi açıklar. PPT, PPTX ve ODP gibi formatlardaki sunum dosyalarını nasıl yükleyeceğinizi, slaytları görüntü olarak nasıl oluşturacağınızı ve sonuçları PNG formatında nasıl kaydedeceğinizi gösterir.

Ayrıca, ölçek değerlerini ayarlayarak veya istenen genişlik ve yüksekliği belirterek oluşturulan PNG görüntülerini nasıl özelleştirebileceğinizi gösterir.

## **PowerPoint'i PNG'ye Dönüştürme**

Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide) sınıfı altındaki [Presentation.getSlides()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) yöntemi tarafından döndürülen koleksiyondan slayt nesnesini alın.
3. Her slayt için küçük resmi almak üzere [Slide.getImage()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide) metodunu kullanın.
4. Slayt küçük resmini PNG formatına kaydetmek için [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) metodunu kullanın.

Bu JavaScript kodu, bir PowerPoint sunumunu PNG'ye nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Özel Boyutlarla PowerPoint'i PNG'ye Dönüştürme**

Belirli bir ölçeğe göre PNG dosyaları elde etmek istiyorsanız, oluşturulan küçük resmin boyutlarını belirleyen `desiredX` ve `desiredY` değerlerini ayarlayabilirsiniz.

Bu JavaScript kodu, açıklanan işlemi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Özel Boyutlarla PowerPoint'i PNG'ye Dönüştürme**

Belirli bir boyuta göre PNG dosyaları elde etmek istiyorsanız, `ImageSize` için tercih ettiğiniz `width` ve `height` argümanlarını geçebilirsiniz.

Bu kod, görsellerin boyutunu belirterek bir PowerPoint'i PNG'ye nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Yalnızca belirli bir şekli (ör. grafik veya resim) tüm slayt yerine nasıl dışa aktarabilirim?**

Aspose.Slides, [bireysel şekiller için küçük resim oluşturma](/slides/tr/nodejs-java/create-shape-thumbnails/) özelliğini destekler; bir şekli PNG görüntüsüne render edebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet, ancak tek bir presentation örneğini iş parçacıkları arasında [paylaşmayın](/slides/tr/nodejs-java/multithreading/) etmeyin. Her iş parçacığı veya süreç için ayrı bir örnek kullanın.

**PNG olarak dışa aktarırken deneme sürümü kısıtlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine su işareti ekler ve bir lisans uygulanana kadar [diğer kısıtlamalar](/slides/tr/nodejs-java/licensing/) uygular.