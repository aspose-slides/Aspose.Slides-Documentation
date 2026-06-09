---
title: Java'da PPT ve PPTX'i JPG'ye Dönüştür
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten JPG'ye
- sunumdan JPG'ye
- slayttan JPG'ye
- PPT'den JPG'ye
- PPTX'ten JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'i JPG olarak kaydet
- PPT'yi JPG'ye dışa aktar
- PPTX'i JPG'ye dışa aktar
- Java
- Aspose.Slides
description: "Java'da Aspose.Slides for Java kullanarak hızlı ve güvenilir kod örnekleriyle PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görsellere dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görsellere dönüştürmek, slaytları paylaşmayı, performansı iyileştirmeyi ve içeriği web sitelerine ya da uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides, PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görsellere dönüştürmenizi sağlar. Bu kılavuz, dönüşümün farklı yöntemlerini açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Bu, slaytların kopyalanmasını önlemek ya da sunumu yalnızca okunabilir modda göstermek istediğinizde yararlı olabilir. Aspose.Slides, tüm sunumu ya da belirli bir slaytı görüntü formatlarına dönüştürmenize imkan verir.

## **PowerPoint PPT/PPTX'yi JPG'ye Dönüştür**

PPT/PPTX'yi JPG'ye dönüştürmek için adımlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) tipinin bir örneğini oluşturun.
2. [Presentation.getSlides()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) koleksiyonundan [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) tipinin slayt nesnesini alın.
3. Her slaytın küçük resmini oluşturup ardından JPG'ye dönüştürün. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide#getImage-float-float-) yöntemi, bir slaytın küçük resmini almak için kullanılır ve sonuç olarak bir [Images](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Images) nesnesi döndürür. [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) yöntemi, ihtiyaç duyulan [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) tipinin slaytından çağrılmalı, elde edilen küçük resmin ölçekleri metoda geçirilir.
4. Slayt küçük resmini aldıktan sonra, küçük resim nesnesinden [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) yöntemini çağırın. Oluşturulan dosya adını ve görüntü formatını bu yönteme gönderin.

{{% alert color="primary" %}}

**Not**: PPT/PPTX'ten JPG dönüşümü, Aspose.Slides API'sindeki diğer tip dönüşümlerinden farklıdır. Diğer tipler için genellikle [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemi kullanılır; ancak burada [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) yöntemine ihtiyaç vardır.

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Tam ölçekli bir görsel oluşturur
        IImage slideImage = sld.getImage(1f, 1f);

        // Görseli JPEG formatında diske kaydeder
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint PPT/PPTX'yi Özelleştirilmiş Boyutlarla JPG'ye Dönüştür**

Oluşturulan küçük resim ve JPG görüntüsünün boyutunu değiştirmek için *ScaleX* ve *ScaleY* değerlerini [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide#getImage-float-float-) yöntemine geçirerek ayarlayabilirsiniz:

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Boyutları tanımlar
    int desiredX = 1200;
    int desiredY = 800;
    // X ve Y'nin ölçekli değerlerini alır
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Tam ölçekli bir görsel oluşturur
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Görseli JPEG formatında diske kaydeder
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Slaytları Görüntü Olarak Kaydederken Yorumları Oluşturma**

Aspose.Slides for Java, slaytları görüntülere dönüştürürken sunum slaytlarındaki yorumları oluşturmanıza olanak tanıyan bir özellik sağlar. Bu Java kodu işlemi gösterir:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG to JPG](https://products.aspose.app/slides/tr/collage/jpg) ya da PNG to PNG görselleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 

Bu makalede açıklanan aynı prensipleri kullanarak görselleri bir formattan diğerine dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: [image to JPG](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/) dönüştürme; [JPG to image](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/) dönüştürme; [JPG to PNG](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/) dönüştürme, [PNG to JPG](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/) dönüştürme; [PNG to SVG](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/) dönüştürme, [SVG to PNG](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/) dönüştürme.

{{% /alert %}}

## **SSS**

**Bu yöntem toplu dönüşümü destekliyor mu?**

Evet, Aspose.Slides bir işlemde birden çok slaytı JPG'ye toplu olarak dönüştürmenize olanak tanır.

**Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?**

Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil olmak üzere tüm içeriği render eder. Ancak, özel ya da eksik yazı tipleri kullanıldığında render doğruluğu PowerPoint'ten biraz farklı olabilir.

**İşlenebilecek slayt sayısıyla ilgili herhangi bir sınırlama var mı?**

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı üzerinde katı bir sınır koymaz. Ancak, büyük sunumlar veya yüksek çözünürlüklü görsellerle çalışırken bellek yetersizliği hatalarıyla karşılaşabilirsiniz.

## **Ayrıca Bakınız**

PPT/PPTX'i görüntüye dönüştürmek için diğer seçeneklere bakın:

- [PPT/PPTX'den SVG dönüşümü](/slides/tr/java/render-a-slide-as-an-svg-image/).