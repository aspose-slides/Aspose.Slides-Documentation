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
- sunumu JPG'ye
- slaytı JPG'ye
- PPT'yi JPG'ye
- PPTX'i JPG'ye
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
description: "Aspose.Slides for .NET kullanarak, C# ile PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine hızlı ve güvenilir kod örnekleriyle dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytları paylaşmayı, performansı optimize etmeyi ve içeriği web sitelerine veya uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides for .NET, PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görüntülere dönüştürmenizi sağlar. Bu kılavuz, dönüştürme için farklı yöntemleri açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Bu, sunum slaytlarını kopyalamaya karşı korumak veya sunumu yalnızca okunabilir modda göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatına dönüştürmenize olanak tanır.

## **Sunum Slaytlarını JPG Görüntülere Dönüştürme**

1. Presentation sınıfının bir örneğini oluşturun.
2. [Presentation.Slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/properties/slides) koleksiyonundan [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide) tipinde slayt nesnesini alın.
3. [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/#getimage_5) metodunu kullanarak slaytın bir görüntüsünü oluşturun.
4. Görüntü nesnesi üzerinde [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/save/#save_3) metodunu çağırın. Çıktı dosya adını ve görüntü formatını argüman olarak geçirin.

{{% alert color="info" %}} 
**Not:** PPT, PPTX veya ODP'den JPG'ye dönüşüm, Aspose.Slides .NET API'sinde diğer formatlara dönüşümden farklıdır. Diğer formatlar için genellikle [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/save/#save_5) metodunu kullanırsınız. Ancak JPG dönüşümü için [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/save/#save_3) metodunu kullanmanız gerekir.
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Belirtilen ölçekle bir slayt görüntüsü oluştur.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Görüntüyü JPEG formatında diske kaydet.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Özelleştirilmiş Boyutlarla Slaytları JPG'ye Dönüştürme**

Oluşturulan JPG görüntülerinin boyutlarını değiştirmek için, görüntü boyutunu [ISlide.GetImage(Size)](https://reference.aspose.com/slides/tr/net/aspose.slides/islide/getimage/#getimage_6) metoduna geçirerek ayarlayabilirsiniz. Bu, belirli genişlik ve yükseklik değerlerine sahip görüntüler oluşturmanızı sağlar ve çıktının çözünürlük ve en‑boy oranı gereksinimlerinizi karşılamasını garantiler. Bu esneklik, özellikle web uygulamaları, raporlar veya dokümantasyon için kesin görüntü boyutlarının gerektiği durumlarda yararlıdır.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Belirtilen boyutta bir slayt görüntüsü oluştur.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Görüntüyü JPEG formatında diske kaydet.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Slaytları Görüntü Olarak Kaydederken Yorumları İşleme**

Aspose.Slides for .NET, bir sunumun slaytlarını JPG görüntülere dönüştürürken yorumları işleme özelliği sağlar. Bu işlevsellik, PowerPoint sunumlarına katkıda bulunanlar tarafından eklenen açıklamaları, geri bildirimleri veya tartışmaları korumak için özellikle yararlıdır. Bu seçeneği etkinleştirerek, yorumların oluşturulan görüntülerde görünmesini sağlarsınız ve böylece orijinal sunum dosyasını açmadan geri bildirimi incelemek ve paylaşmak daha kolay olur.

Diyelim ki içinde yorumlar olan bir slayt bulunan “sample.pptx” adlı bir sunum dosyamız var:

![Yorumlu slayt](slide_with_comments.png)

Aşağıdaki C# kodu, slaytı yorumları koruyarak JPG görüntüsüne dönüştürür:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Ayrıca Bakınız**

PPT, PPTX veya ODP'yi görüntülere dönüştürmek için diğer seçeneklere de göz atın, örneğin:

- [PowerPoint'i GIF'e Dönüştür](/slides/tr/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint'i PNG'ye Dönüştür](/slides/tr/net/convert-powerpoint-to-png/)
- [PowerPoint'i TIFF'e Dönüştür](/slides/tr/net/convert-powerpoint-to-tiff/)
- [PowerPoint'i SVG'ye Dönüştür](/slides/tr/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Aspose.Slides'in PowerPoint'i JPG görüntülere nasıl dönüştürdüğünü görmek için bu ücretsiz çevrimiçi dönüştürücüleri deneyin: PowerPoint [PPTX'ten JPG](https://products.aspose.app/slides/tr/conversion/pptx-to-jpg) ve [PPT'den JPG](https://products.aspose.app/slides/tr/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Ücretsiz Çevrimiçi PPTX'ten JPG Dönüştürücü](ppt-to-jpg.png)

{{% alert title="İpucu" color="info" %}}

Aspose, ücretsiz bir [Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz.

Bu makalede açıklanan aynı prensipleri kullanarak bir formattan başka bir formata görüntü dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: convert [görüntüyü JPG'ye](https://products.aspose.com/slides/tr/net/conversion/image-to-jpg/); convert [JPG'yi görüntüye](https://products.aspose.com/slides/tr/net/conversion/jpg-to-image/); convert [JPG'yi PNG'ye](https://products.aspose.com/slides/tr/net/conversion/jpg-to-png/), convert [PNG'yi JPG'ye](https://products.aspose.com/slides/tr/net/conversion/png-to-jpg/); convert [PNG'yi SVG'ye](https://products.aspose.com/slides/tr/net/conversion/png-to-svg/), convert [SVG'yi PNG'ye](https://products.aspose.com/slides/tr/net/conversion/svg-to-png/).
{{% /alert %}}

## **SSS**

### Bu yöntem toplu dönüşümü destekliyor mu?

Evet, Aspose.Slides tek bir işlemde birden fazla slaytı JPG'ye toplu olarak dönüştürmenizi sağlar.

### Dönüştürme SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?

Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil tüm içeriği işler. Ancak, özellikle özel veya eksik yazı tipleri kullanıldığında, render doğruluğu PowerPoint'e kıyasla biraz farklılık gösterebilir.

### İşlenebilecek slayt sayısı konusunda herhangi bir sınırlama var mı?

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı konusunda katı bir sınırlama getirmez. Ancak, büyük sunumlarla veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatası alabilirsiniz.