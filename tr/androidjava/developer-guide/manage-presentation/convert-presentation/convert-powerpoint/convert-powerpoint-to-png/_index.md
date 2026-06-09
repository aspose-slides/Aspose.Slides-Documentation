---
title: Android'de PowerPoint Slaytlarını PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PNG'ye
- sunumdan PNG'ye
- slayttan PNG'ye
- PPT'den PNG'ye
- PPTX'ten PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'yi PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'yi PNG'ye dışa aktar
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine hızlıca dönüştürün, kesin ve otomatik sonuçlar sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını PNG görüntülerine dönüştürmeyi açıklar. PPT, PPTX ve ODP gibi formatlarda sunum dosyalarını nasıl yükleyeceğinizi, slaytları görüntü olarak nasıl işleyip, sonuçları PNG formatında nasıl kaydedeceğinizi gösterir.

Makale ayrıca, ölçek değerlerini ayarlayarak veya istenen genişlik ve yüksekliği belirterek oluşturulan PNG görüntülerini nasıl özelleştirebileceğinizi gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfını örnekleyin.
2. [Presentation.getSlides()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#getSlides--) koleksiyonundan, [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlide) arayüzü altında slide nesnesini alın.
3. Her slide için küçük resmi almak üzere [ISlide.getImage()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISlide) yöntemini kullanın.
4. Slide küçük resmini PNG formatında kaydetmek için [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) metodunu kullanın.

Bu Java kodu, bir PowerPoint sunumunu PNG'ye nasıl dönüştüreceğinizi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Özel Boyutlarla PowerPoint'i PNG'ye Dönüştür**

Belirli bir ölçeğe yakın PNG dosyaları elde etmek istiyorsanız, sonuç küçük resminin boyutlarını belirleyen `desiredX` ve `desiredY` değerlerini ayarlayabilirsiniz. 

Bu Java kodu, açıklanan işlemi gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Özel Boyutla PowerPoint'i PNG'ye Dönüştür**

Belirli bir boyuta yakın PNG dosyaları elde etmek istiyorsanız, `ImageSize` için tercih ettiğiniz `width` ve `height` argümanlarını geçirebilirsiniz. 

Bu kod, görüntülerin boyutunu belirterek bir PowerPoint'i PNG'ye nasıl dönüştüreceğinizi gösterir: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Yalnızca belirli bir şekli (ör. grafik veya resim) tüm slayt yerine nasıl dışa aktarabilirim?**

Aspose.Slides, [bireysel şekiller için küçük resim oluşturmayı](/slides/tr/androidjava/create-shape-thumbnails/) destekler; bir şekli PNG görüntüsü olarak işleyebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet, ancak tek bir sunum örneğini thread'ler arasında [paylaşmayın](/slides/tr/androidjava/multithreading/). Her thread ya da süreç için ayrı bir örnek kullanın.

**PNG'ye dışa aktarırken deneme sürümü sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/androidjava/licensing/) uygular.