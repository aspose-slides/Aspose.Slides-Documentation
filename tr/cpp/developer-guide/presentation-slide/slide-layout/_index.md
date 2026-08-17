---
title: C++'ta Slayt Düzenlerini Uygulama veya Değiştirme
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/cpp/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- alt bilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
- boş düzen
- altyazılı içerik
- altyazılı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde slayt düzenlerini uygulama, oluşturma ve düzenleme, yer tutucular ekleme, kullanılmayan düzenleri kaldırma ve alt bilgi görünürlüğünü kontrol etme."
---
## **Genel Bakış**

Bir slayt düzeni, başlık, metin, resim, grafik ve tablo gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzenin uygulanması, slaytlara tutarlı bir yapı kazandırırken her slaytın kendi içeriğini barındırmasına izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve tüm şekillerin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Kalıtımını Anlamak**

Bir sunum üç ilişkili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
1. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/) bir mastera aittir ve belirli bir yer tutucu düzenini tanımlar.
1. Bir [normal slayt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Normal bir slayt temayı ve biçimlendirmeyi düzeninden devralır; düzen ise masterından devralır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki devralınan değeri geçersiz kılar. Normal bir slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden üretilir; bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir slayttan önce düzene gerekli yer tutucuları ekleyin. Daha sonra bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişki iki önemli sonuca sahiptir:

- Bir düzen üzerindeki devralınan biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanımdaki bir düzeni düzenlemeden önce, bağımlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt hâlâ kullandığı bir düzen silinemez. Önce bu slaytları başka bir düzene yönlendirin veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slide Master](/slides/tr/cpp/slide-master/) bölümüne bakın.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını takip ediyorsa bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden ad‑bazlı seçim, kaynak şablonu kontrol etmiyorsanız güvenilir olmayabilir.

Aşağıdaki örnek, ilk masterda **Başlık ve İçerik** düzenini arar. Bu düzen mevcut değilse, bilerek **Boş** düzenine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği durumlar için gereklidir. Seçilen düzen, ardından [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/set_layoutslide/) yöntemiyle ilk normal slayta uygulanır.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bir slaydın düzenini değiştirmek, doğrudan slayta eklenen sıradan şekilleri kaldırmaz. Ancak yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucularla yeni düzen arasındaki eşleşme değişebilir; bu nedenle çok farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; yeni bir tane oluşturmaz. Bir düzen oluşturmak için hedef masterın düzen koleksiyonunda [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterlayoutslidecollection/add/) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Başlık ve İçerik** düzeni ekler, ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bir şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmak yerine onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekleme**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu               | `ILayoutPlaceholderManager` Yöntemi |
| ----------------------------------- | ------------------------------------ |
| ![Content](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                 | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Aşağıdaki örnek, **Boş** düzeninin var olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slayt için karşılık gelen yer tutucu şekillerini üretebilir.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Uyarı" %}}
Devralınan biçimlendirme ya da mevcut düzen yer tutucularının geometrisinin değiştirilmesi, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara otomatik olarak eklenmez. Düzen değişikliklerini bir sunum kopyası üzerinde test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Kompres::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yöntemini kullanarak hiçbir normal slayt tarafından referans edilmeyen düzenleri kaldırın. Yöntem, hâlâ kullanımdaki düzenleri olduğu gibi bırakır.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Tek bir belirli düzeni kaldırmak için önce onun [get_HasDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) ya da [GetDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/getdependingslides/) yöntemini kullanın. Bağımlı slaytları yeniden atadıktan sonra [ILayoutSlide::Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/remove/) yöntemini çağırın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxeditexception/) oluşturur.

## **Bir Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi alt bilgi, slayt numarası ve tarih‑zaman yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) yöntemini kullanın. Bu, örneğin içerik düzenlerinin alt bilgi göstermesi, başlık düzenlerinin ise göstermemesi gerektiğinde faydalıdır.

Aşağıdaki örnek bir düzeni güvenli bir şekilde seçer ve alt bilgi öğelerini görünür yapar:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bir Master ve Alt Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Etme**

Master hiyerarşisi boyunca tutarlı alt bilgi ayarları uygulamak için [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/get_headerfootermanager/) yöntemini kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslideheaderfootermanager/) sınıfının yayılım yöntemleri, master ve ona bağlı düzen slaytları ile normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedef almaz.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SSS**

**Master Slayt ile Düzen Slaytı Arasındaki Fark Nedir?**

Master slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Düzen slaytı bir mastera aittir ve yeniden kullanılabilir bir yer tutucu düzeni tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igloballayoutslidecollection/addclone/) yöntemiyle kopyayı hedef koleksiyona ekleyin. Sunumlar arasında kopyalarken, kaynak düzenin kullandığı yazı tiplerini, temaları, resimleri ve diğer kaynakları da doğrulayın.

**Kullanımdaki Bir Düzeni Değiştirirsem Ne Olur?**

Bağımlı slaytlar, yerel olarak etkilenilen biçimlendirmeyi veya nesneleri geçersiz kılmazlarsa, düzen değişikliklerini devralır. Yer tutucu geometrisi ve devralınan stil, birçok slaytta bir anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [GetDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/getdependingslides/) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxeditexception/) fırlatır. Önce bağımlı slaytları yeniden atayın veya yalnızca referans edilmeyen düzenleri kaldırmak için [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yöntemini kullanın.