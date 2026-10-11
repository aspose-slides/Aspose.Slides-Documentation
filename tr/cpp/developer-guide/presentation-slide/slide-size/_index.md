---
title: C++ ile Sunum Slayt Boyutunu Değiştirme
linktitle: Slayt Boyutu
type: docs
weight: 70
url: /tr/cpp/slide-size/
keywords:
- slayt boyutu
- en-boy oranı
- standard
- geniş ekran
- 4:3
- 16:9
- slayt boyutunu ayarla
- slayt boyutunu değiştir
- özel slayt boyutu
- özel slayt boyutu
- benzersiz slayt boyutu
- tam boyutlu slayt
- ekran türü
- ölçekleme yapma
- uyumu sağla
- azami boyut
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "C++ ve Aspose.Slides kullanarak PPT, PPTX ve ODP dosyalarındaki slaytları hızlı bir şekilde yeniden boyutlandırmayı öğrenin, herhangi bir ekrana kalite kaybı olmadan sunumları optimize edin."
---
## **Giriş**

Aspose.Slides, PowerPoint sunumlarında slayt boyutunu ve en‑boy oranını ayarlamak için kapsamlı araçlar sunar; bu, baskı ve ekran görüntüsü için kritik öneme sahiptir.

Popüler Slayt Boyutları ve Oranları:

- **Standard (4:3 En‑Boy Oranı)**: Daha eski ekranlar ve cihazlar için idealdir.
- **Geniş Ekran (16:9 En‑Boy Oranı)**: Modern projektörler ve ekranlar için önerilir.

Tüm slaytlar aynı slayt boyutu ve en‑boy oranını kullandığından sunumunuzda tutarlılık sağlanır. En iyi sonuçlar için slayt boyutlarını, sunumu oluşturma sürecinin başında ayarlayın; bu, sorunları önler.

{{% alert color="info" %}} 
Varsayılan olarak, Aspose.Slides ile oluşturulan sunumlar standart 4:3 en‑boy oranını kullanır.
{{% /alert %}}

Not ve el kitabı sayfalarının, normal slaytlardan ayrı boyutları vardır. Boyutlarını ve yönlerini değiştirmek için [Not Sayfası Boyutu](/slides/tr/cpp/notes-size/) sayfasına bakın.

## **Sunumlarda Slayt Boyutunu Değiştirme**

Bu örnek kod, Aspose.Slides kullanarak C++ ile bir sunumda slayt boyutunu nasıl değiştireceğinizi gösterir:

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

## **Sunumlarda Özel Slayt Boyutlarını Belirtme**

Ortak slayt boyutları (4:3 ve 16:9) işiniz için uygun değilse, belirli ya da benzersiz bir slayt boyutu kullanmayı tercih edebilirsiniz. Örneğin, sunumunuzdaki tam boy slaytları özel bir sayfa düzeninde yazdırmayı planlıyorsanız ya da sunumunuzu belirli ekran türlerinde görüntülemeyi düşünüyorsanız, özel bir boyut ayarı kullanmak size fayda sağlayabilir.

Bu örnek kod, C++ için Aspose.Slides kullanarak bir sunumda özel bir slayt boyutu nasıl belirtilir gösterir:

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

## **Yeniden Boyutlandırmadan Sonra Slayt İçeriğini Yönetme**

Bir sunumun slayt boyutunu değiştirdikten sonra, slaytların içeriği (örneğin görüntüler veya nesneler) bozulabilir. Varsayılan olarak, nesneler yeni slayt boyutuna uyması için otomatik olarak yeniden boyutlandırılır. Ancak, bir sunumun slayt boyutunu değiştirirken, Aspose.Slides'in slaytlardaki içeriği nasıl işleyeceğini belirleyen bir ayar belirtebilirsiniz.

Ne yapmayı amaçladığınıza bağlı olarak, bu ayarlardan herhangi birini kullanabilirsiniz:

- `DoNotScale`
  
  Slaytlardaki nesnelerin yeniden boyutlandırılmasını **ISTEMİYORSANIZ**, bu ayarı kullanın.

- `EnsureFit`
  
  Daha küçük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini küçülterek hepsinin slaytlara sığmasını (böylece içeriği kaybetmezsiniz) sağlamasını istiyorsanız, bu ayarı kullanın.

- `Maximize`
  
  Daha büyük bir slayt boyutuna ölçeklendirmek ve Aspose.Slides'in slayt nesnelerini yeni slayt boyutuna orantılı olacak şekilde büyütmesini istiyorsanız, bu ayarı kullanın.

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

## **FAQ**

### İnç (örneğin, puan veya milimetre) dışındaki birimler kullanarak özel bir slayt boyutu ayarlayabilir miyim?

Evet. Aspose.Slides içinde puanları (points) kullanır; 1 puan 1/72 inçe eşittir. Milimetre veya santimetre gibi herhangi bir birimi puana dönüştürebilir ve dönüştürülmüş değerleri slayt genişliği ve yüksekliğini tanımlamak için kullanabilirsiniz.

### Çok büyük bir özel slayt boyutu, render alırken performans ve bellek kullanımını etkiler mi?

Evet. Daha büyük slayt boyutları (puan cinsinden) yüksek render ölçeğiyle birleştirildiğinde bellek tüketimi artar ve işlem süresi uzar. Pratik bir slayt boyutu hedefleyin ve istenen çıktı kalitesini elde etmek için yalnızca gerektiğinde render ölçeğini ayarlayın.

### Tek bir standart dışı slayt boyutu tanımlayıp ardından farklı boyutlarda sunumlardan slaytları birleştirebilir miyim?

Farklı slayt boyutlarına sahip oldukları sürece [sunumları birleştir](/slides/tr/cpp/merge-presentation/) yapılamaz — önce bir sunumu diğerine eşitleyecek şekilde yeniden boyutlandırın. Slayt boyutunu değiştirirken, mevcut içeriğin nasıl işleneceğini [SlideSizeScaleType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesizescaletype/) seçeneğiyle belirleyebilirsiniz. Boyutları eşleştirdikten sonra, biçimlendirmeyi koruyarak slaytları birleştirebilirsiniz.

### Tek tek şekiller veya bir slaydın belirli bölgeleri için küçük resimler oluşturabilir miyim ve bunlar yeni slayt boyutuna uyacak mı?

Evet. Aspose.Slides, [tüm slaytlar](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/getimage/) ve [seçili şekiller](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) için küçük resimler oluşturabilir. Oluşan görüntüler mevcut slayt boyutunu ve en‑boy oranını yansıtarak tutarlı çerçeveleme ve geometri sağlar.