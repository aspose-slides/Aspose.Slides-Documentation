---
title: Android'de PPT ve PPTX'yi JPG'ye Dönüştür
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/androidjava/convert-powerpoint-to-jpg/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine hızlı ve güvenilir kod örnekleriyle dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytları paylaşmayı, performansı iyileştirmeyi ve içerği web sitelerine veya uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides for Android via Java, PPTX, PPT ve ODP dosyalarını yüksek kalite JPEG görüntülere dönüştürmenizi sağlar. Bu kılavuz, farklı dönüşüm yöntemlerini açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi kolayca uygulayabilir ve her slayt için bir küçük resim oluşturabilirsiniz. Bu, sunum slaytlarını kopyalamaya karşı korumak veya yalnızca okunabilir modda sunumu göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu ya da belirli bir slaytı görüntü formatlarına dönüştürmenize izin verir.

## **Sunum Slaytlarını JPG Görüntülere Dönüştürme**

PPT, PPTX veya ODP dosyasını JPG’ye dönüştürmek için adımlar:

1. [Sunum](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. [Presentation.getSlides()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getSlides--) yöntemiyle dönen koleksiyondan [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) türünde slayt nesnesini alın.
1. [ISlide.getImage(float, float)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-float-float-) yöntemiyle slaytın bir görüntüsünü oluşturun.
1. Görüntü nesnesi üzerinde [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) yöntemini çağırın. Çıktı dosya adını ve görüntü formatını argüman olarak geçin.

{{% alert color="info" %}} 

**Not:** PPT, PPTX veya ODP’den JPG’ye dönüşüm, Aspose.Slides Android via Java API’da diğer formatlara dönüşümden farklıdır. Diğer formatlar için genellikle [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemi kullanılır. Ancak JPG dönüşümü için [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) yöntemini kullanmanız gerekir.

{{% /alert %}} 

```java
import com.aspose.slides.*;

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

## **Özelleştirilmiş Boyutlarla Slaytları JPG’ye Dönüştürme**

Oluşturulan JPG görüntülerinin boyutlarını değiştirmek için [ISlide.getImage(Size)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) yöntemine boyutları geçirerek görüntü boyutunu ayarlayabilirsiniz. Bu, belirli genişlik ve yükseklik değerlerine sahip görüntüler üretmenizi sağlar ve çıktının çözünürlük ve en-boy oranı gereksinimlerinize uymasını temin eder. Bu esneklik, web uygulamaları, raporlar veya dokümantasyon için kesin görüntü boyutlarının gerekli olduğu durumlarda özellikle yararlıdır.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Belirtilen boyutta bir slayt görüntüsü oluştur.
        IImage slideImage = slide.getImage(imageSize);

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

## **Slaytları Görüntü Olarak Kaydederken Yorumları İşleme**

Aspose.Slides for Android via Java, sunum slaytlarını JPG görüntülere dönüştürürken yorumların işlenmesini sağlayan bir özellik sunar. Bu işlev, PowerPoint sunumlarına eklenen açıklamaları, geri bildirimleri veya tartışmaları korumak için özellikle faydalıdır. Bu seçeneği etkinleştirerek yorumların oluşturulan görüntülerde görünür olmasını sağlarsınız; böylece orijinal sunum dosyasını açmadan yorumları gözden geçirmek ve paylaşmak daha kolay olur.

Örneğin, içinde yorumlar bulunan bir “sample.pptx” dosyamız olduğunu varsayalım:

![Yorumlu slayt](slide_with_comments.png)

Aşağıdaki Java kodu, slaytı yorumları korunmuş bir JPG görüntüsüne dönüştürür:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

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

## **Diğer Bağlantılar**

PPT, PPTX veya ODP’yi görüntülere dönüştürmek için diğer seçeneklere bakın:

- [PowerPoint’i GIF’e Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint’i PNG’ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-png/)
- [PowerPoint’i TIFF’ye Dönüştür](/slides/tr/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint’i SVG’ye Dönüştür](/slides/tr/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Aspose.Slides’ın PowerPoint sunumlarını JPG görüntülere nasıl dönüştürdüğünü görmek için bu ücretsiz çevrimiçi dönüştürücüleri deneyin: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/tr/conversion/pptx-to-jpg) ve [PPT to JPG](https://products.aspose.app/slides/tr/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Ücretsiz Çevrimiçi PPTX to JPG Dönüştürücü](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose, bir [ÜCRETSİZ Kolaj web uygulaması](https://products.aspose.app/slides/tr/collage) sağlar. Bu çevrimiçi hizmeti kullanarak [JPG to JPG](https://products.aspose.app/slides/tr/collage/jpg) veya PNG to PNG görüntülerini birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir vb. 

Bu makalede açıklanan aynı prensipleri kullanarak görüntüleri bir formattan başka bir formata dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: [görüntüyü JPG’e dönüştür](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/); [JPG’yi görüntüye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/); [JPG’yi PNG’ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), [PNG’yi JPG’ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/); [PNG’yi SVG’ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), [SVG’yi PNG’ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/).

{{% /alert %}}

## **SSS**

### Bu yöntem toplu dönüşümü destekliyor mu?

Evet, Aspose.Slides, birden çok slaytı tek bir işlemde JPG’ye toplu olarak dönüştürmeye olanak tanır.

### Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?

Evet, Aspose.Slides tüm içeriği, SmartArt, grafikler, tablolar, şekiller ve daha fazlasını işler. Ancak, özel veya eksik yazı tipleri kullanıldığında render doğruluğu PowerPoint’e göre hafifçe farklılık gösterebilir.

### İşlenebilecek slayt sayısı konusunda bir sınırlama var mı?

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı için katı bir sınırlama koymaz. Ancak büyük sunumlar veya yüksek çözünürlüklü görüntülerle çalışırken bellek dışı hatalarla karşılaşabilirsiniz.