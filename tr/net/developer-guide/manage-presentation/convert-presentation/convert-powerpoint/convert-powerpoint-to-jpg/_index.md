---
title: PPT ve PPTX'i .NET'te JPG'ye Dönüştür
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten JPG'ye
- sunumdan JPG'ye
- slayttan JPG'ye
- PPT'den JPG'ye
- PPTX'den JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'i JPG olarak kaydet
- PPT'yi JPG'ye dışa aktar
- PPTX'i JPG'ye dışa aktar
- .NET
- C#
- Aspose.Slides
description: "C# ile Aspose.Slides for .NET kullanarak PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine hızlı ve güvenilir kod örnekleriyle dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytları paylaşmayı, performansı iyileştirmeyi ve içeriği web sitelerine veya uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides for .NET, PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görüntülere dönüştürmenizi sağlar. Bu kılavuz, dönüşüm için farklı yöntemleri açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Bu, sunum slaytlarını kopyalamaya karşı korumak veya sunumu sadece okunabilir modda göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatlarına dönüştürmenizi sağlar.

## **Sunum Slaytlarını JPG Görüntülere Dönüştürme**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı.
2. Get the slide object of the [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide) tipinden [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/properties/slides) koleksiyonundan alın.
3. Slaytın bir görüntüsünü, [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/#getimage_5) metodunu kullanarak oluşturun.
4. Görüntü nesnesinde [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/save/#save_3) metodunu çağırın. Çıktı dosya adını ve görüntü formatını argüman olarak verin.

{{% alert color="primary" %}} 

**Not:** PPT, PPTX veya ODP'den JPG dönüşümü, Aspose.Slides .NET API'sinde diğer formatlara dönüşümden farklıdır. Diğer formatlar için genellikle [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/#save_5) metodunu kullanırsınız. Ancak JPG dönüşümü için [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/save/#save_3) metodunu kullanmanız gerekir.

{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Belirtilen ölçekle bir slayt resmi oluştur.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Resmi JPEG formatında diske kaydet.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Özelleştirilmiş Ölçülerle Slaytları JPG'ye Dönüştürme**

Sonuçta oluşan JPG görüntülerinin boyutlarını değiştirmek için, görüntü boyutunu [ISlide.GetImage(Size)](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/#getimage_6) metoduna geçirerek ayarlayabilirsiniz. Bu, belirli genişlik ve yükseklik değerlerine sahip görüntüler oluşturmanızı sağlar ve çıktının çözünürlük ve en‑boy oranı gereksinimlerinizi karşılamasını temin eder. Bu esneklik, özellikle web uygulamaları, raporlar veya belgeler için, kesin görüntü boyutlarının gerektiği durumlarda yararlıdır.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Belirtilen boyutta bir slayt resmi oluştur.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Resmi JPEG formatında diske kaydet.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Yorumları Görüntülere Kaydederken İşleme**

Aspose.Slides for .NET, bir sunumun slaytlarında yorumları JPG görüntülere dönüştürürken işleyebilen bir özellik sunar. Bu işlevsellik, PowerPoint sunumlarında iş birliği yapanların eklediği açıklamaları, geri bildirimleri veya tartışmaları korumak için özellikle yararlıdır. Bu seçeneği etkinleştirerek yorumların oluşturulan görüntülerde görünür olmasını sağlarsınız, böylece orijinal sunum dosyasını açmadan geri bildirimi incelemek ve paylaşmak kolaylaşır.

Diyelim ki içinde yorumlar bulunan bir slayt içeren "sample.pptx" adlı bir sunum dosyamız var:

![Yorumlu slayt](slide_with_comments.png)

Aşağıdaki C# kodu, slaytı yorumları koruyarak bir JPG görüntüsüne dönüştürür:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Slayt yorumları için seçenekleri ayarla.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // İlk slaytı bir görüntüye dönüştür.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Sonuç:

![Yorumlu JPG görüntüsü](image_with_comments.png)

## **Diğer Bağlantılar**

PPT, PPTX veya ODP'yi görüntülere dönüştürmek için diğer seçeneklere aşağıdakiler gibi bakabilirsiniz:

- [PowerPoint'ı GIF'e Dönüştür](/slides/tr/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint'ı PNG'ye Dönüştür](/slides/tr/net/convert-powerpoint-to-png/)
- [PowerPoint'ı TIFF'e Dönüştür](/slides/tr/net/convert-powerpoint-to-tiff/)
- [PowerPoint'ı SVG'ye Dönüştür](/slides/tr/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides'in PowerPoint'i JPG görüntülere nasıl dönüştürdüğünü görmek için, bu ücretsiz çevrimiçi dönüştürücüleri deneyin: PowerPoint [PPTX'ten JPG'ye](https://products.aspose.app/slides/tr/conversion/pptx-to-jpg) ve [PPT'ten JPG'ye](https://products.aspose.app/slides/tr/conversion/ppt-to-jpg).

{{% /alert %}} 

![Ücretsiz Çevrimiçi PPTX'ten JPG Dönüştürücü](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak, [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 

Bu makalede açıklanan aynı prensipleri kullanarak, görüntüleri bir formatından diğerine dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: dönüştür [görüntüyü JPG'ye](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/); dönüştür [JPG'yi görüntüye](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/); dönüştür [JPG'yi PNG'ye](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/), dönüştür [PNG'yi JPG'ye](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/); dönüştür [PNG'yi SVG'ye](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/), dönüştür [SVG'yi PNG'ye](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/).

{{% /alert %}}

## **SSS**

**Bu yöntem toplu dönüşümü destekliyor mu?**

Evet, Aspose.Slides birden fazla slaytı tek bir işlemede toplu olarak JPG'ye dönüştürmeye olanak tanır.

**Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?**

Evet, Aspose.Slides tüm içeriği, SmartArt, grafikler, tablolar, şekiller ve daha fazlasını işler. Ancak, özel veya eksik yazı tipleri kullanıldığında render doğruluğu PowerPoint'e göre hafif farklılık gösterebilir.

**İşlenebilecek slayt sayısı konusunda herhangi bir sınırlama var mı?**

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı üzerinde katı bir limit koymaz. Ancak büyük sunumlar veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatası alabilirsiniz.