---
title: Java'da PPT ve PPTX'yi JPG'ye Dönüştür
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
- sunumu JPG'ye
- slaytı JPG'ye
- PPT'den JPG'ye
- PPTX'ten JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'i JPG olarak kaydet
- PPT'yi JPG'ye aktar
- PPTX'i JPG'ye aktar
- Java
- Aspose.Slides
description: "Java'da Aspose.Slides for Java kullanarak hızlı ve güvenilir kod örnekleriyle PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülerine dönüştürmek, slaytları paylaşmayı, performansı iyileştirmeyi ve içeriği web sitelerine veya uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides, PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görüntülerine dönüştürmenizi sağlar. Bu kılavuz, dönüşüm için farklı yöntemleri açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Sunum slaytlarını kopyalamaya karşı korumak veya sunumu yalnızca okunabilir modda göstermek istiyorsanız bu faydalı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatlarına dönüştürmenizi sağlar.

## **PowerPoint PPT/PPTX'yi JPG'ye Dönüştür**

İşte PPT/PPTX'yi JPG'ye dönüştürme adımları:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) tipinde bir örnek oluşturun.
2. [Presentation.getSlides()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#getSlides--) koleksiyonundan [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) tipindeki slayt nesnesini alın.
3. Her slayt için küçük resim oluşturun ve ardından JPG'ye dönüştürün. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide#getImage-float-float-) yöntemi bir slaytın küçük resmini elde etmek için kullanılır, sonuç olarak bir [Images](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Images) nesnesi döndürür. [getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) yöntemi, ihtiyaç duyulan [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide) tipindeki slayttan çağrılmalı ve ortaya çıkan küçük resmin ölçekleri metoda geçirilir.
4. Slayt küçük resmini aldığınızda, küçük resim nesnesinden [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) yöntemini çağırın. Oluşan dosya adını ve görüntü formatını ona geçirin.

{{% alert color="info" %}}
**Not**: PPT/PPTX'den JPG'ye dönüşüm, Aspose.Slides API'de diğer tiplere dönüşümden farklıdır. Diğer tipler için genellikle [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemini kullanırsınız, ancak burada [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) yöntemine ihtiyacınız vardır.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Tam ölçekli bir görüntü oluşturur
        IImage slideImage = sld.getImage(1f, 1f);

        // Görüntüyü JPEG formatında diske kaydeder
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

Oluşturulan küçük resim ve JPG görüntüsünün boyutunu değiştirmek için, *ScaleX* ve *ScaleY* değerlerini [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISlide#getImage-float-float-) yöntemlerine geçirerek ayarlayabilirsiniz:

```java
import com.aspose.slides.*;

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
        // Tam ölçekli bir görüntü oluşturur
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Görüntüyü JPEG formatında diske kaydeder
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

## **Slaytları Görüntü Olarak Kaydederken Yorumları Render Et**

Aspose.Slides for Java, slaytları görüntülere dönüştürürken sunumdaki yorumları render etmenizi sağlayan bir özellik sunar. Bu Java kodu işlemi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

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

{{% alert title="Tip" color="info" %}}
Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sağlar. Bu çevrimiçi hizmeti kullanarak [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir vb.

Bu makalede açıklanan aynı prensipleri kullanarak görüntüleri bir formattan başka bir formata dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: dönüştür [image to JPG](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/); dönüştür [JPG to image](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/); dönüştür [JPG to PNG](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), dönüştür [PNG to JPG](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/); dönüştür [PNG to SVG](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), dönüştür [SVG to PNG](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/).
{{% /alert %}}

## **SSS**

### Bu yöntem toplu dönüşümü destekliyor mu?

Evet, Aspose.Slides birden fazla slaytı tek bir işlemede JPG'ye toplu olarak dönüştürmenize olanak tanır.

### Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?

Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil olmak üzere tüm içeriği render eder. Ancak, render doğruluğu PowerPoint'e göre biraz farklı olabilir, özellikle özel veya eksik yazı tipleri kullanıldığında.

### İşlenebilecek slayt sayısıyla ilgili herhangi bir sınırlama var mı?

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı üzerinde katı bir sınırlama getirmez. Ancak, büyük sunumlar veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatasıyla karşılaşabilirsiniz.

## **Ayrıca Bakınız**

PPT/PPTX'i görüntüye dönüştürmek için diğer seçenekleri inceleyin, örneğin:

- [PPT/PPTX'ten SVG dönüşümü](/slides/tr/java/render-a-slide-as-an-svg-image/).