---
title: C++'ta PowerPoint Sunumlarını Animasyonlu GIF'lere Dönüştürme
linktitle: PowerPoint'ten GIF'e
type: docs
weight: 65
url: /tr/cpp/convert-powerpoint-to-animated-gif/
keywords:
- animasyonlu GIF
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten GIF'e
- sunumu GIF'e
- slaytı GIF'e
- PPT'den GIF'e
- PPTX'den GIF'e
- PPT'yi GIF olarak kaydet
- PPTX'i GIF olarak kaydet
- PPT'yi GIF olarak dışa aktar
- PPTX'i GIF olarak dışa aktar
- varsayılan ayarlar
- özel ayarlar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint sunumlarını (PPT, PPTX) kolayca animasyonlu GIF'lere dönüştürün. Hızlı, yüksek kalite sonuçlar."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarını sadece birkaç satır kodla animasyonlu GIF dosyalarına dönüştürmenizi sağlar. Bu, slayt içeriğini hafif, yaygın olarak desteklenen ve web sayfalarına, mesajlaşma uygulamalarına veya belgelere gömülebilen bir animasyon formatında paylaşmanız gerektiğinde kullanışlıdır. Bu makale, bir sunumu GIF olarak varsayılan ayarlarla dışa aktarmayı ve [GifOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/gifoptions/) aracılığıyla çerçeve boyutu, slayt gecikmesi ve geçiş çerçeve hızı gibi seçenekleri yapılandırarak çıktıyı nasıl özelleştireceğinizi açıklar.

## **Varsayılan Ayarlarla Sunumları Animasyonlu GIF'e Dönüştürme**

Aşağıdaki C++ örnek kodu, standart ayarlarla bir sunumu animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Animasyonlu GIF, varsayılan parametrelerle oluşturulacaktır. 

{{%  alert  title="TIP"  color="info"  %}} 

GIF için parametreleri özelleştirmek isterseniz, [GifOptions](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.gif_options) sınıfını kullanabilirsiniz. Aşağıdaki örnek koda bakın. 

{{% /alert %}} 

## **Özel Ayarlarla Sunumları Animasyonlu GIF'e Dönüştürme**

Bu örnek kod, C++ içinde özel ayarlarla bir sunumu animasyonlu GIF'e nasıl dönüştüreceğinizi gösterir:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// oluşan GIF'in boyutu
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// her slaydın bir sonraki slayda geçene kadar ne kadar gösterileceği
gifOptions->set_DefaultDelay(2000);
// daha iyi geçiş animasyonu kalitesi için FPS'yi artır

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Aspose tarafından geliştirilen ücretsiz bir [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsünü incelemek isteyebilirsiniz. 

{{% /alert %}}

## **SSS**

### Sunumda kullanılan yazı tipleri sistemde yüklü değilse ne olur?

Eksik yazı tiplerini yükleyin veya [yedek yazı tiplerini yapılandırın](/slides/tr/cpp/powerpoint-fonts/). Aspose.Slides, eksik tipleri yerine koyacaktır, ancak görünüm farklılık gösterebilir. Marka tutarlılığı için gerekli tiplerin kesinlikle mevcut olduğundan emin olun.

### GIF çerçevelerine filigran ekleyebilir miyim?

Evet. Dışa aktarmadan önce ana slayta veya bireysel slaytlara [yarı saydam bir nesne/logo ekleyin](/slides/tr/cpp/watermark/) — filigran her çerçevede görünecektir.