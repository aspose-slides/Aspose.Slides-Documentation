---
title: "C++'ta PPT ve PPTX'i JPG'ye Dönüştürme"
linktitle: "PowerPoint'tan JPG'ye"
type: docs
weight: 60
url: /tr/cpp/convert-powerpoint-to-jpg/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan JPG'ye
- sunumu JPG'ye
- slaytı JPG'ye
- PPT'den JPG'ye
- PPTX'ten JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'i JPG olarak kaydet
- PPT'yi JPG'ye dışa aktar
- PPTX'i JPG'ye dışa aktar
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine hızlı ve güvenilir kod örnekleri kullanarak dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytları paylaşmayı, performansı iyileştirmeyi ve içeriği web sitelerine veya uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides for C++ PPTX, PPT ve ODP dosyalarını yüksek kalitede JPEG görüntülere dönüştürmenizi sağlar. Bu kılavuz, dönüşüm için farklı yöntemleri açıklar.

Bu özelliklerle kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir önizleme oluşturmak kolaydır. Bu, sunum slaytlarını kopyalamadan korumak veya yalnızca okunabilir modda sunumu göstermek istediğinizde faydalı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatlarına dönüştürmenize olanak tanır.

## **Sunum Slaytlarını JPG Görüntülere Dönüştürme**

Bir PPT, PPTX veya ODP dosyasını JPG’ye dönüştürmek için adımlar:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Sunumun slayt koleksiyonundan [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) tipinde slayt nesnesini alın.
1. Slaytı [ISlide.GetImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/) yöntemiyle bir görüntüye dönüştürün.
1. Görüntü nesnesi üzerinde [IImage.Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/save/) yöntemini çağırın. Çıktı dosya adını ve görüntü formatını parametre olarak geçirin.

{{% alert color="info" %}} 

**Not:** PPT, PPTX veya ODP’den JPG dönüşümü, Aspose.Slides for C++ API'sindeki diğer format dönüşümlerinden farklıdır. Diğer formatlar için genellikle [IPresentation.Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/save/) yöntemini kullanırsınız. Ancak JPG dönüşümü için [IImage.Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/save/) yöntemini kullanmanız gerekir.

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Belirtilen ölçeğe göre bir slayt görüntüsü oluştur.
    auto image = slide->GetImage(scaleX, scaleY);

    // Resmi JPEG formatında diske kaydet.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Özelleştirilmiş Boyutlarla Slaytları JPG’ye Dönüştürme**

Oluşturulan JPG görüntülerinin boyutlarını değiştirmek için [ISlide.GetImage(Size)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) yöntemine boyut parametresini geçirebilirsiniz. Bu sayede belirli genişlik ve yükseklik değerleriyle görüntüler oluşturabilir, çıktının çözünürlük ve en‑boy oranı gereksinimlerinizi karşılamasını sağlayabilirsiniz. Bu esneklik, web uygulamaları, raporlar veya belgeler için kesin görüntü boyutlarının gerektiği durumlarda özellikle faydalıdır.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

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

## **Kaydedilen Slayt Görsellerinde Yorumları İşleme**

Aspose.Slides for C++ sunum slaytlarını JPG görüntülere dönüştürürken yorumları da işleyebilmenizi sağlayan bir özellik sunar. Bu işlev, PowerPoint sunumlarında işbirlikçiler tarafından eklenen açıklamaları, geri bildirimleri veya tartışmaları korumak için çok yararlıdır. Bu seçeneği etkinleştirerek yorumların oluşturulan görüntülerde görünür olmasını sağlarsınız; böylece orijinal sunum dosyasını açmadan yorumları gözden geçirmek ve paylaşmak kolaylaşır.

Örneğin, "sample.pptx" adlı bir sunum dosyamız ve içinde yorumlar olan bir slaytımız olduğunu varsayalım:

![Yorumlu slayt](slide_with_comments.png)

Aşağıdaki C++ kodu, slaytı yorumları koruyarak bir JPG görüntüsüne dönüştürür:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

![Yorumlu JPG resmi](image_with_comments.png)

## **Diğer Bağlantılar**

Aşağıdaki seçenekleri kullanarak PPT, PPTX veya ODP’yi görüntülere dönüştürebilirsiniz:

- [PowerPoint'i GIF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint'i PNG'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-png/)
- [PowerPoint'i TIFF'e Dönüştür](/slides/tr/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint'i SVG'ye Dönüştür](/slides/tr/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Aspose.Slides’in PowerPoint’i JPG görüntülere nasıl dönüştürdüğünü görmek için ücretsiz çevrimiçi dönüştürücüleri deneyin: PowerPoint [PPTX'den JPG'ye](https://products.aspose.app/slides/tr/conversion/pptx-to-jpg) ve [PPT'den JPG'ye](https://products.aspose.app/slides/tr/conversion/ppt-to-jpg). 

{{% /alert %}}

![Ücretsiz Çevrimiçi PPTX'ten JPG Dönüştürücü](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose, [ÜCRETSİZ Kolaj web uygulaması](https://products.aspose.app/slides/tr/collage) sağlar. Bu çevrimiçi hizmetle [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 

Bu makalede açıklanan aynı prensipleri kullanarak bir formattan başka bir formata görüntü dönüştürebilirsiniz. Daha fazla bilgi için şu sayfalara bakın: [görseli JPG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/image-to-jpg/); [JPG'yi görsele dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-image/); [JPG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/jpg-to-png/), [PNG'yi JPG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-jpg/); [PNG'yi SVG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/png-to-svg/), [SVG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **SSS**

### Bu yöntem toplu dönüşümü destekliyor mu?

Evet, Aspose.Slides bir işlemde birden çok slaytı JPG’ye toplu olarak dönüştürmenize olanak tanır.

### Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?

Evet, Aspose.Slides SmartArt, grafikler, tablolar, şekiller ve daha fazlası dahil tüm içeriği işler. Ancak, özel veya eksik yazı tipleri kullanıldığında, işleme doğruluğu PowerPoint’e göre hafifçe farklılık gösterebilir.

### İşlenebilecek slayt sayısı konusunda bir sınırlama var mı?

Aspose.Slides, işleyebileceğiniz slayt sayısı üzerinde katı bir sınırlama getirmez. Ancak, büyük sunumlar veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatası alabilirsiniz.