---
title: "C++'ta Sunum Slayt Boyutunu Değiştir"
linktitle: "Slayt Boyutu"
type: docs
weight: 70
url: /tr/cpp/slide-size/
keywords:
- slayt boyutu
- en-boy oranı
- standart
- geniş ekran
- 4:3
- 16:9
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- eşsiz slayt boyutu
- tam boyutlu slayt
- ekran tipi
- yeniden ölçeklendirme
- uygunluk sağla
- en çok büyüt
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ ve Aspose.Slides ile PPT, PPTX ve ODP dosyalarında slaytları hızlıca yeniden boyutlandırmayı öğrenin, kalite kaybı olmadan her ekran için sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sağlar; bu, hem baskı hem de ekran gösterimi için kritiktir.

Popüler Slayt Boyutları ve Oranları:

- **Standart (4:3 En-Boy Oranı)**: Eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En-Boy Oranı)**: Modern projeksiyon cihazları ve ekranlar için önerilir.

Sunumunuz boyunca tutarlılığı sağlamak için tek bir slayt boyutu ve en‑boy oranı tüm slaytlara uygulanır. En iyi sonuçlar için slayt boyutlarını, sunum oluşturma sürecinin başında ayarlayın; böylece komplikasyonlardan kaçınabilirsiniz.

{{% alert color="info" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak C++ ile bir sunumda slayt boyutunun nasıl değiştirileceğini gösterir:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Sunumlarda Özel Slayt Boyutlarını Belirleme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli veya benzersiz bir slayt boyutu kullanmayı seçebilirsiniz. Örneğin, sunumunuzu özel bir sayfa düzeninde tam boyutta yazdırmayı planlıyorsanız ya da sunumunuzu belirli ekran tiplerinde göstermek istiyorsanız, sunumunuz için özel bir boyut ayarı kullanmanız faydalı olacaktır.

Bu örnek kod, Aspose.Slides for C++ kullanarak C++ içinde bir sunum için özel bir slayt boyutu nasıl belirtilir gösterir:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 kağıt boyutu
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Boyutlandırma Sonrası Slayt İçeriğini İşleme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örnek olarak görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içerikle nasıl başa çıkacağını belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı veya neyi başarmayı amaçladığınıza bağlı olarak, aşağıdaki ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`

  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **İSTEMİYORSANIZ**, bu ayarı kullanın.

- `EnsureFit`

  Daha küçük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını sağlamak (böylece içeriği kaybetmezsiniz) istiyorsanız bu ayarı kullanın. 

- `Maximize`

  Daha büyük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna göre orantılı hale getirecek şekilde büyütmesini istiyorsanız bu ayarı kullanın. 

Bu örnek kod, bir sunumun slayt boyutunu değiştirirken `Maximize` ayarının nasıl kullanılacağını gösterir:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **SSS**

### Özel bir slayt boyutunu inç dışındaki birimler (örneğin, puan veya milimetre) kullanarak ayarlayabilir miyim?

Evet. Aspose.Slides içsel olarak puanları kullanır; 1 puan 1/72 inçtir. Herhangi bir birimi (örneğin milimetre veya santimetre) puana dönüştürüp, dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

### Çok büyük bir özel slayt boyutu, işleme sırasında performansı ve bellek kullanımını etkiler mi?

Evet. Daha büyük slayt boyutları (puan cinsinden) ve yüksek işleme ölçeği birleştirildiğinde, bellek tüketimi artar ve işlem süreleri uzar. Pratik bir slayt boyutunu hedefleyin ve istenen çıktı kalitesine ulaşmak için yalnızca gerektiğinde işleme ölçeğini ayarlayın.

### Tek bir standart dışı slayt boyutu belirleyip, farklı boyutlarda sunumlardan slaytları birleştirebilir miyim?

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştiremezsiniz](/slides/tr/cpp/merge-presentation/) — önce bir sunumu diğerine eşitleyecek şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutlar hizalandıktan sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

### Bireysel şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna saygı gösterir mi?

Evet. Aspose.Slides, [tam slaytlar](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/getimage/) ve [seçili şekiller](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) için küçük resimler oluşturabilir. Oluşan görüntüler mevcut slayt boyutunu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.