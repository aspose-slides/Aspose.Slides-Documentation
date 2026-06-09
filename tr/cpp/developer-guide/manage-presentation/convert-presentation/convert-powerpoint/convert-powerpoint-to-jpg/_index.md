---
title: C++'ta PPT ve PPTX'i JPG'ye Dönüştür
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten JPG'ye
- sunumu JPG'ye
- slaytı JPG'ye
- PPT'den JPG'ye
- PPTX'i JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'i JPG olarak kaydet
- PPT'yi JPG'ye aktar
- PPTX'i JPG'ye aktar
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görsellere hızlı ve güvenilir kod örnekleriyle dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytların paylaşılması, performansın iyileştirilmesi ve içeriğin web sitelerine veya uygulamalara yerleştirilmesi konusunda yardımcı olur. Aspose.Slides for C++ PPTX, PPT ve ODP dosyalarını yüksek kaliteli JPEG görüntülere dönüştürmenizi sağlar. Bu kılavuz, dönüşüm için farklı yöntemleri açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Bu, sunum slaytlarını kopyalamaya karşı korumak veya sunumu yalnızca okunabilir modda göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu ya da belirli bir slaytı görüntü formatlarına dönüştürmenize olanak tanır.

## **Sunum Slaytlarını JPG Görüntülere Dönüştürme**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Sunumun slayt koleksiyonundan [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) tipinde slayt nesnesini alın.
1. [ISlide.GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) yöntemini kullanarak slaytın bir görüntüsünü oluşturun.
1. Görüntü nesnesi üzerinde [IImage.Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/save/) yöntemini çağırın. Çıktı dosya adını ve görüntü formatını argüman olarak geçirin.

{{% alert color="primary" %}} 
**Not:** PPT, PPTX veya ODP'den JPG'ye dönüşüm, Aspose.Slides for C++ API'sindeki diğer formatlara dönüşümden farklıdır. Diğer formatlar için genellikle [IPresentation.Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/save/) yöntemini kullanırsınız. Ancak JPG dönüşümü için [IImage.Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/save/) yöntemini kullanmanız gerekir.
{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Belirtilen ölçekle bir slayt görüntüsü oluştur.
    auto image = slide->GetImage(scaleX, scaleY);

    // Görüntüyü JPEG formatında diske kaydet.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Özel Boyutlarla Slaytları JPG'ye Dönüştürme**

Oluşturulan JPG görüntülerinin boyutlarını değiştirmek için, görüntü boyutunu [ISlide.GetImage(Size)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) yöntemine parametre olarak geçirebilirsiniz. Bu, belirli genişlik ve yükseklik değerlerine sahip görüntüler oluşturmanıza olanak tanır ve çıktının çözünürlük ve en‑boy oranı gereksinimlerinizi karşılamasını sağlar. Bu esneklik, web uygulamaları, raporlar veya belgeler için görüntü oluştururken kesin görüntü boyutlarına ihtiyaç duyulduğunda özellikle faydalıdır.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Belirtilen boyutta bir slayt görüntüsü oluştur.
    auto image = slide->GetImage(imageSize);

    // Görüntüyü JPEG formatında diske kaydet.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Görseller Olarak Kaydederken Yorumları İşleme**

Aspose.Slides for C++, bir sunumun slaytlarını JPG görüntülere dönüştürürken slaytlardaki yorumları işleme özelliği sunar. Bu işlevsellik, PowerPoint sunumlarına iş ortakları tarafından eklenen açıklamaları, geri bildirimleri veya tartışmaları korumak için özellikle yararlıdır. Bu seçenek etkinleştirildiğinde, yorumların oluşturulan görüntülerde görünür olmasını sağlayarak, orijinal sunum dosyasını açmaya gerek kalmadan geri bildirimi gözden geçirmeyi ve paylaşmayı kolaylaştırır.

Diyelim ki içinde yorumlar bulunan bir slayt içeren "sample.pptx" adlı bir sunum dosyamız var:

![Yorumlu slayt](slide_with_comments.png)

Aşağıdaki C++ kodu, slaytı yorumları koruyarak bir JPG görüntüsüne dönüştürür:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Slayt yorumları için seçenekleri ayarla.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // İlk slaytı bir görüntüye dönüştür.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Sonuç:

![Yorumlu JPG görüntüsü](image_with_comments.png)

## **Diğer Bağlantılar**

PPT, PPTX veya ODP'yi görüntülere dönüştürmek için diğer seçeneklere de bakabilirsiniz, örneğin:

- [PowerPoint'i GIF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint'i PNG'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-png/)
- [PowerPoint'i TIFF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint'i SVG'ye Dönüştür](/slides/tr/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides'in PowerPoint'i JPG görüntülere nasıl dönüştürdüğünü görmek için bu ücretsiz çevrimiçi dönüştürücüleri deneyin: PowerPoint [PPTX'den JPG'ye](https://products.aspose.app/slides/tr/conversion/pptx-to-jpg) ve [PPT'den JPG'ye](https://products.aspose.app/slides/tr/conversion/ppt-to-jpg). 
{{% /alert %}}

![Ücretsiz Çevrimiçi PPTX'ten JPG Dönüştürücü](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 

Bu makalede açıklanan aynı prensipleri kullanarak, görüntüleri bir formattan diğerine dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: [görüntüyü JPG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/); [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/); [JPG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/), [PNG'yi JPG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/); [PNG'yi SVG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/), [SVG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **SSS**

**Bu yöntem toplu dönüşümü destekliyor mu?**  
Evet, Aspose.Slides tek bir işlemde birden çok slaytı JPG'ye toplu olarak dönüştürmeye izin verir.

**Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?**  
Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil tüm içeriği render eder. Ancak, render doğruluğu, özellikle özel veya eksik yazı tipleri kullanıldığında PowerPoint'e kıyasla biraz farklılık gösterebilir.

**İşlenebilecek slayt sayısıyla ilgili herhangi bir sınırlama var mı?**  
Aspose.Slides kendisi işleyebileceğiniz slayt sayısı üzerinde katı bir sınırlama getirmez. Ancak, büyük sunumlarla veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatası alabilirsiniz.