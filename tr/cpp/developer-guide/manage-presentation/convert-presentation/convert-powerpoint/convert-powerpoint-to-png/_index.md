---
title: PowerPoint Slaytlarını C++'ta PNG'ye Dönüştür
linktitle: PowerPoint'ten PNG'ye
type: docs
weight: 30
url: /tr/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PNG'ye
- sunumu PNG'ye
- slaytı PNG'ye
- PPT'yi PNG'ye
- PPTX'i PNG'ye
- PPT'yi PNG olarak kaydet
- PPTX'i PNG olarak kaydet
- PPT'yi PNG'ye dışa aktar
- PPTX'i PNG'ye dışa aktar
- C++
- Aspose.Slides
description: "PowerPoint sunumlarını yüksek kaliteli PNG görüntülerine hızlı bir şekilde Aspose.Slides for C++ ile dönüştürerek, kesin ve otomatik sonuçlar sağlar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for C++ kullanarak sunum slaytlarını PNG görüntülerine nasıl dönüştüreceğinizi açıklar. PPT, PPTX ve ODP gibi formatlarda sunumları yükleyebilir, her slaytı işleyebilir ve ayrı bir PNG görüntüsü olarak kaydedebilirsiniz.

Aşağıdaki örnekler, varsayılan ölçekle render etme, ölçeği artırma, çıktı boyutlarını piksel olarak belirleme ve bir degrade render stili seçmeyi gösterir.

## **PowerPoint'i PNG'ye Dönüştür**

Bir sunumu, [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı ile yükleyin ve slaytlarına [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) erişicisi aracılığıyla erişin. Örnek, her slaytı parametresiz olarak [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) ile render ederek bir küçük resim oluşturur. Ardından, her render edilen slaytı PNG görüntüsü olarak kaydetmek için [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) metodunu [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) ile çağırır.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Parametresiz [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) aşırı yüklemesi 0.2 ölçeğinde render eder. Örneğin, 720 × 540 puan ölçüsündeki bir slayt 144 × 108 piksel bir küçük resim üretir. Çıktı boyutlarını kontrol etmek için aşağıda gösterildiği gibi ölçek faktörleriyle ya da açık bir görüntü boyutu ile aşırı yüklemeleri kullanın.
{{% /alert %}}

## **PowerPoint'i Özel Boyutlarla PNG'ye Dönüştür**

Render edilen boyutları kontrol etmek için [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) yöntemine yatay ve dikey ölçek faktörleri gönderin. Bu örnekte, her iki faktör de 2 olduğundan 720 × 540 puan ölçüsündeki bir slayt 1440 × 1080 piksel bir görüntü üretir. Aynı ölçek faktörleri slaytın en-boy oranını korur. Her görüntü, [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) ile PNG formatında kaydedilir.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **PowerPoint'i Özel Boyutla PNG'ye Dönüştür**

Çıktı boyutlarını piksel olarak belirtmek için ölçek faktörleri yerine bir boyut değerini [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) metoduna gönderin. Bu örnek, her slaytı 960 × 720 pikselde render eder ve sonucu [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) ile kaydeder. Görüntünün gerilmesini önlemek için slaytın en‑boy oranına uygun boyutlar seçin.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Bir Degrade Render Stili Seçin**

Bir slayt degrade doldurmalar içeriyorsa, dışa aktarılan PNG'deki geçişler PowerPoint'te gördüklerinizden daha açık ya da farklı görünebilir. Degraderin nasıl render edileceğini seçmek için [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) içindeki [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) metodunu kullanabilirsiniz.

[gradient-styles.pptx](gradient-styles.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı iki lineer degrade içerir: üstte camgöbeği‑turuncu, altta mavi‑sarı. Her degrade iki durak içerir, %0 ve %100 konumlarında.

Aşağıdaki örnek bu sunumu yükler ve aynı ilk slaytı iki modda [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) ile render eder.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

| Varsayılan | PowerPointUI |
| --- | --- |
| ![Varsayılan ile render edilen camgöbeği‑turuncu ve mavi‑sarı degrader](gradient-Default.png) | ![PowerPointUI ile render edilen aynı degrader](gradient-PowerPointUI.png) |

Bu örnekte, `Default` daha açık ara renkler üretirken, `PowerPointUI` daha koyu ara renkler üretir. Fark, degrade içindeki renkler ve duraklara bağlıdır.

Standart Aspose.Slides çıktısı ihtiyaçlarınızı karşılıyorsa `Default` seçin. Önceliğiniz PowerPoint'teki görünümle eşleşmekse `PowerPointUI` deneyin. Her iki çıktıyı da hedef sonucunuzla karşılaştırın; hiçbir mod evrensel olarak daha iyidir.

## **SSS**

**Bir grafiği veya resmi gibi belirli bir şekli, tüm slayt yerine nasıl dışa aktarabilirim?**  
Aspose.Slides, tek tek şekiller için [küçük resimler oluşturmayı](/slides/tr/cpp/shape-thumbnails/) destekler; böylece bir şekli PNG görüntüsü olarak render edebilirsiniz.

**Sunucuda paralel dönüşüm destekleniyor mu?**  
Evet. Her iş parçacığı veya süreç için ayrı bir sunum örneği kullanın; [tek bir örneği iş parçacıkları arasında paylaşmayın](/slides/tr/cpp/multithreading/).

**PNG'ye dışa aktarırken değerlendirme sınırlamaları nelerdir?**  
Değerlendirme modu, çıktı görüntülerine bir filigran ekler ve lisans uygulanana kadar [diğer kısıtlamaları](/slides/tr/cpp/licensing/) uygular.