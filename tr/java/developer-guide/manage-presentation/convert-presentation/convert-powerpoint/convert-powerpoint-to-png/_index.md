---
title: Java'da PowerPoint Slaytlarını PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/java/convert-powerpoint-to-png/
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
- PPTX'den PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine hızlı bir şekilde dönüştürerek, kesin ve otomatik sonuçlar elde edin."
---
## **Genel Bakış**

Bu makale Aspose.Slides kullanarak PowerPoint sunumlarını PNG görüntülerine dönüştürmenin nasıl yapılacağını açıklar. PPT, PPTX ve ODP gibi formatlardaki sunum dosyalarını nasıl yükleyeceğinizi, slaytları görüntü olarak nasıl render edeceğinizi ve sonuçları PNG formatında nasıl kaydedeceğinizi gösterir.

Makale ayrıca ölçek değerlerini ayarlayarak veya istenen genişlik ve yüksekliği belirterek oluşturulan PNG görüntülerini nasıl özelleştirebileceğinizi gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. [Presentation.getSlides()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) koleksiyonundan [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) arayüzü altında slayt nesnesini alın. 
3. Her slayt için thumbnail (önizleme) almak üzere [ISlide.getImage()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) metodunu kullanın.
4. Slide thumbnail'ını PNG formatında kaydetmek için [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) metodunu kullanın.

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

Belirli bir ölçeğe göre PNG dosyaları elde etmek istiyorsanız, sonuç thumbnail'ının boyutlarını belirleyen `desiredX` ve `desiredY` değerlerini ayarlayabilirsiniz. 

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

Belirli bir boyuta göre PNG dosyaları elde etmek istiyorsanız, `ImageSize` için tercih ettiğiniz `width` ve `height` argümanlarını geçirebilirsiniz. 

Bu kod, görüntüler için boyutu belirterek bir PowerPoint'i PNG'ye nasıl dönüştüreceğinizi gösterir: 

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

**Bir slaytı tümü yerine yalnızca belirli bir şekli (ör. grafik veya resim) dışa aktarmak nasıl mümkün?**

Aspose.Slides, [bireysel şekiller için thumbnail oluşturmayı](/slides/tr/java/create-shape-thumbnails/) destekler; bir şekli PNG görüntüsü olarak render edebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**

Evet, ancak tek bir sunum örneğini thread'ler arasında [paylaşmayın](/slides/tr/java/multithreading/). Her thread veya işlem için ayrı bir örnek kullanın.

**PNG'ye dışa aktarırken deneme sürümü sınırlamaları nelerdir?**

Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/java/licensing/) uygular.