---
title: C++'ta Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/cpp/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- alternatif metin
- alternatif metin başlığı
- alternatif metin açıklaması
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PPT, PPTX ve ODP dosyalarında sunum erişilebilirlik kontrollerini otomatikleştirin—ekran okuyucu deneyimini iyileştirin ve uyumluluğu artırın."
---
## **Giriş**

Alternatif metin, yardımcı teknolojiler kullanan kişilerin görsellerin, grafiklerin ve diğer bilgilendirici şekillerin anlamını anlamalarına yardımcı olur. Bu makale, Aspose.Slides for C++ ile alternatif metin başlıklarını ve açıklamalarını nasıl okuyup güncelleyeceğinizi, erişilebilirlik açıklamalarını kodda kullanılan şekil adlarından nasıl ayıracağınızı ve bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl kontrol edeceğinizi açıklar.

Bu özellikler sunum erişilebilirliğini destekler, ancak bunu garanti etmez. Okuma sırası, renk kontrastı, metin okunabilirliği ve diğer erişilebilirlik gereksinimleri de incelenmelidir.

## **Alternatif Metin Başlıkları ve Açıklamalarını Yönet**

Alternatif metni, görüntüleri, grafikleri ve diğer bilgilendirici şekilleri göremeyen kişilere anlamını açıklamak için kullanın. Aşağıdaki özellikler farklı amaçlara hizmet eder:

| Özellik veya içerik | Amaç |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Alternatif açıklama için kısa bir başlık. |
| [AlternativeText](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_alternativetext/) | Şeklin içeriği veya slayt bağlamındaki amacının anlamlı açıklaması. |
| [Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) | Şeklin adı, kodun sunum içinde belirli bir şekli bulmak için kullanabileceği. |
| Görünür metin | Slaytta gösterilen içerik, örneğin bir şeklin metni veya bir grafiğin başlığı ve etiketleri. Alternatif metni güncellemek bu içeriği değiştirmez. |

Bir sunum şablon olarak yeniden kullanıldığında, kod bir şekli güncellemeden önce [Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) özelliğiyle bulabilir. Bu ad, görselin okuyucuya ilettiği şeyi açıklayan alternatif metinden farklı bir amaca hizmet eder. İsme göre arama, yazarların açıklamaları değiştirmesine veya çevirmesine olanak tanır, kodun şekli bulma şeklini etkilemez. İsimler düzenlenebilir ve benzersiz olması garanti edilmez; bu nedenle ismin hedeflenen şekille eşleştiğini kontrol edin; bkz. [Identify and Find Shapes](/slides/tr/cpp/shape-manipulations/#identify-and-find-shapes).

Aşağıdaki örnek, ilk slaytın ilk şekli olarak bir ofis girişinin görüntüsü bulunan `input.pptx` dosyasını gerektirir. Görüntünün dekoratif olarak işaretlenmemiş olması gerekir. Örnek, mevcut alternatif metin başlığı ve açıklamasını okur ve yazdırır, her iki değeri günceller ve sunumu `output.pptx` olarak kaydeder. Metni gerçek görüntü ve ilettiği bilgiye göre uyarlayın.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Alternatif metin eklemek tek başına sunum erişilebilirliğini veya erişilebilirlik standartlarına uyumu garanti etmez. Açıklamaları doğruluk ve alaka açısından gözden geçirin ve ayrıca okuma sırası, renk kontrastı, okunabilir metin ve diğer erişilebilirlik gereksinimlerini kontrol edin. Bilgilendirici görseller dekoratif olarak işaretlenmemelidir; bir sonraki bölümde [IsDecorative](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_isdecorative/) nasıl okunur gösterilir.

## **Dekoratif Olarak İşaretle**

Dekoratif olarak işaretle, yalnızca süs amaçlı görselleri ekran okuyucularının atlamasını sağlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı sürdürür. Arka planlar, süslemeler ve boşluk tutuculara uygulanır—hiçbir zaman bilgi veren grafiklere, simgelere veya görüntülere uygulanmaz. Aspose.Slides bu bayrağı algılama ve doğrulama amacıyla sunar, otomatik erişilebilirlik kontrolü ve temizlik için kullanılabilir.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini nasıl belirleyeceğinizi gösterir.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **SSS**

**Alternatif metin başlığı ve açıklamasına ne koymalıyım?**

Kısa bir başlıkla konuyu tanımlayın ve açıklama ile görselin slayt bağlamında ilettiği bilgiyi açıklayın. Bir grafik için yalnızca “grafik” demek yerine ilgili trendi veya karşılaştırmayı açıklayın.

**Şablonda şekilleri bulmak için alternatif metni kullanmalı mıyım?**

Şekli önce [Name](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/get_name/) özelliğiyle bulup beklenen şekil olduğundan emin olun. Alternatif metin düzenlenebilir veya çevrilebilir; bu da tam açıklama arayan kodu bozabilir; bkz. [Identify and Find Shapes](/slides/tr/cpp/shape-manipulations/).

**Bir şekil ne zaman dekoratif olarak işaretlenmeli?**

Bilgi eklemeyen süs amaçlı görseller için dekoratif bayrağı kullanın. Anlam taşıyan görüntüler ve grafikler uygun bir açıklamaya sahip olmalıdır.

**Alternatif metin eklemek bir sunumu tamamen erişilebilir kılar mı?**

Hayır. Alternatif metin sadece erişilebilirliğin bir parçasını kapsar. Ayrıca okuma sırası, renk kontrastı, metin okunabilirliği ve diğer geçerli gereksinimleri gözden geçirin; bu özellikleri ayarlamak tek başına uyumu sağlamaz.