---
title: Android'de PPT ve PPTX'i JPG'ye Dönüştür
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/androidjava/convert-powerpoint-to-jpg/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten JPG'ye
- sunumu JPG'ye
- slaytı JPG'ye
- PPT'yi JPG'ye
- PPTX'i JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'i JPG olarak kaydet
- PPT'yi JPG'ye aktar
- PPTX'i JPG'ye aktar
- Android
- Java
- Aspose.Slides
description: "Java ile Aspose.Slides for Android kullanarak hızlı ve güvenilir kod örnekleriyle PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine dönüştürün."
---
## **Introduction**

PowerPoint ve OpenDocument sunumlarını JPG görüntülerine dönüştürmek, slaytları paylaşmayı, performansı optimize etmeyi ve içeriği web sitelerine veya uygulamalara gömmeyi kolaylaştırır. Aspose.Slides for Android via Java, PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görüntülerine dönüştürmenizi sağlar. Bu kılavuz, dönüşümün farklı yöntemlerini açıklar.

Bu özelliklerle kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Bu, sunum slaytlarını kopyalamaya karşı korumak veya sunumu yalnızca okunabilir modda göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatlarına dönüştürmenize olanak tanır.

## **Convert Presentation Slides to JPG Images**

Here are the steps to convert a PPT, PPTX, or ODP file to JPG:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation.getSlides()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlides--) yöntemiyle dönen koleksiyondan [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) tipinde bir slayt nesnesi alın.
1. [ISlide.getImage(float, float)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-float-float-) yöntemini kullanarak slaytın bir görüntüsünü oluşturun.
1. Görüntü nesnesi üzerinde [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) yöntemini çağırın. Çıktı dosya adını ve görüntü formatını argüman olarak geçirin.

{{% alert color="primary" %}} 
**Not:** PPT, PPTX veya ODP'den JPG'ye dönüşüm, Aspose.Slides Android via Java API'sinde diğer formatlara dönüştürmeden farklıdır. Diğer formatlar için genellikle [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemini kullanırsınız. Ancak JPG dönüşümü için [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) yöntemini kullanmanız gerekir.
{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Belirtilen ölçekle bir slayt görüntüsü oluştur.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Görüntüyü JPEG formatında diske kaydet.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Convert Slides to JPG with Customized Dimensions**

**Özel Boyutlarla Slaytları JPG'ye Dönüştür**

Sonuçta elde edilen JPG görüntülerinin boyutlarını değiştirmek için, [ISlide.getImage(Size)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) yöntemine geçirerek görüntü boyutunu ayarlayabilirsiniz. Bu sayede belirli genişlik ve yükseklik değerlerine sahip görüntüler oluşturabilir, çıktının çözünürlük ve en-boy oranı gereksinimlerinizi karşılamasını sağlayabilirsiniz. Bu esneklik, web uygulamaları, raporlar veya belgeler için kesin görüntü boyutlarının gerektiği durumlarda özellikle faydalıdır.

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Belirtilen boyutta bir slayt görüntüsü oluştur.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // JPEG formatında görüntüyü diske kaydet.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Render Comments When Saving Slides as Images**

**Slaytları Görüntü Olarak Kaydederken Yorumları İşleme**

Aspose.Slides for Android via Java, slaytları JPG görüntülerine dönüştürürken sunum slaytlarındaki yorumları da işleme özelliği sunar. Bu işlev, PowerPoint sunumlarına iş birliği yapan kişilerin eklediği açıklamaları, geri bildirimleri veya tartışmaları korumak için özellikle yararlıdır. Bu seçeneği etkinleştirerek yorumların oluşturulan görüntülerde görünür olmasını sağlarsınız; böylece orijinal sunum dosyasını açmaya gerek kalmadan geri bildirimi gözden geçirebilir ve paylaşabilirsiniz.

Diyelim ki içinde yorumlar bulunan bir slaytı olan "sample.pptx" adlı bir sunum dosyamız var:

![Yorumlu slayt](slide_with_comments.png)

Aşağıdaki Java kodu, slaytı yorumları koruyarak bir JPG görüntüsüne dönüştürür:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // İlk slaytı bir görüntüye dönüştür.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

Sonuç:

![Yorumlu JPG görüntüsü](image_with_comments.png)

## **See Also**

Diğer PPT, PPTX veya ODP'yi görüntülere dönüştürme seçeneklerine bakın:

- [PowerPoint'i GIF'e Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint'i PNG'e Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-png/)
- [PowerPoint'i TIFF'e Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint'i SVG'ye Dönüştür](/slides/tr/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
**Not:** Aspose.Slides'in PowerPoint sunumlarını JPG görüntülerine nasıl dönüştürdüğünü görmek için bu ücretsiz çevrimiçi dönüştürücüleri deneyin: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/tr/conversion/pptx-to-jpg) ve [PPT to JPG](https://products.aspose.app/slides/tr/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Ücretsiz Çevrimiçi PPTX to JPG Dönüştürücü](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose, ücretsiz bir [Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG to JPG](https://products.aspose.app/slides/tr/collage/jpg) veya PNG to PNG görüntülerini birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilirsiniz.

Bu makalede anlatılan aynı prensipleri kullanarak görüntüleri bir formattan diğerine dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: [image to JPG](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/); [JPG to image](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/); [JPG to PNG](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/); [PNG to JPG](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/); [PNG to SVG](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/); [SVG to PNG](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Bu yöntem toplu dönüşümü destekliyor mu?**

Evet, Aspose.Slides tek bir işlemde birden fazla slaytı JPG'ye toplu olarak dönüştürmeye olanak tanır.

**Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?**

Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil olmak üzere tüm içeriği işler. Ancak, özel veya eksik yazı tipleri kullanıldığında render doğruluğu PowerPoint'e göre biraz farklılık gösterebilir.

**İşlenebilecek slayt sayısı üzerinde herhangi bir sınırlama var mı?**

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı için katı bir sınır koymaz. Ancak büyük sunumlar veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatası alabilirsiniz.