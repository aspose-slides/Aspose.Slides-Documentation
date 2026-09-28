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
- yalnızca başlık
- boş düzen
- başlıklı içerik
- başlıklı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde slayt düzenlerini uygula, oluştur ve değiştir, yer tutucular ekle, kullanılmayan düzenleri kaldır ve alt bilgi görünürlüğünü kontrol et."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulamak, slaytlara tutarlı bir yapı kazandırırken her slaytın kendi içeriğini barındırmasına olanak tanır.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Kalıtımını Anlayın**

Bir sununun üç ilgili seviyesi vardır:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/) temayı, paylaşılan biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
2. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/) bir mastera aittir ve belirli bir yer tutucu düzenini tanımlar.
3. Bir [normal slayt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) bir düzen kullanır ve o slayt için girilen içeriği saklar.

Bir normal slayt, temasını ve biçimlendirmesini düzeninden, düzen ise masterından devralır. Normal slayta doğrudan ayarlanan bir değer, o seviyedeki devralınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzenden üretilir, bu yer tutuculara girilen içerik ise normal slayta aittir.

Gerekli yer tutucuları bir düzene, ondan slaytlar oluşturmadan önce ekleyin. Bir düzene daha sonra başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzen üzerindeki devralınan biçimlendirme veya mevcut yer tutucu geometrisinin değiştirilmesi, ona bağlı tüm slaytları güncelleyebilir. Halihazırda kullanılan bir düzeni düzenlemeden önce, ona bağlı slaytları inceleyin ve ortaya çıkan sunuyu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağlı slaytlarını başka bir düzene atayın ya da yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için [Slide Master](/slides/tr/cpp/slide-master/) sayfasına bakın.

Bir slaytta veya ortak bir düzen üzerinden devralınan logoları veya süsleme master şekillerini gizlemek için [Control the Visibility of Master Graphics](/slides/tr/cpp/slide-master/) bölümüne bakın. Örnek aynı masterı kullanan iki slaytı karşılaştırır.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum, standart PowerPoint düzen tanımlarını izlediğinde bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden ad temelli seçim, kaynak şablonu kontrol etmediğiniz sürece daha az güvenilirdir.

Aşağıdaki örnek, ilk masterda **Başlık ve İçerik** düzenini arar. Bu düzen bulunamazsa, bilinçli olarak **Boş** düzenine geri döner. İkinci null kontrolü, bir sununun yalnızca özel düzenler içerebileceği için gereklidir. Seçilen düzen daha sonra [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/set_layoutslide/) yöntemiyle ilk normal slayta uygulanır.

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

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu yüzden büyük ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; oluşturmaz. Bir düzen oluşturmak için hedef masterın düzen koleksiyonunda [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterlayoutslidecollection/add/) metodunu çağırın.

Aşağıdaki örnek, her zaman `Report Title and Content` adında yeni bir **Başlık ve İçerik** düzeni ekler ve ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

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

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten mevcutsa, bir kopya oluşturmak yerine onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucu Ekleme**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [ILayoutPlaceholderManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![İçerik](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![İçerik (Dikey)](contentV.png)   | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Metin](text.png)                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Metin (Dikey)](textV.png)        | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Resim](picture.png)              | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Grafik](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tablo](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)          | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Ortam](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Çevrimiçi Görsel](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Aşağıdaki örnek, **Boş** düzenin mevcut olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta karşılık gelen yer tutucu şekillerini üretebilir.

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

{{% alert color="warning" title="Warning" %}}
Devralınan biçimlendirmenin veya mevcut düzen yer tutucularının geometrisinin değiştirilmesi, bağlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara otomatik olarak eklenmez. Düzen değişikliklerini bir sunum kopyasında test edin ve her bağlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

[Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metodunu, hiçbir normal slaytın başvurduğu düzenleri kaldırmak için kullanın. Metod, hâlâ kullanılan düzenleri olduğu gibi bırakır.

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

Belirli bir düzeni kaldırmak için, önce onun [get_HasDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) metodunu ya da [GetDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/getdependingslides/) metodunu kullanın. [ILayoutSlide::Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/remove/) metodunu çağırmadan önce bağlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxeditexception/) hatası oluşturur.

## **Düzen Slaytında Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi alt bilgisi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) metodunu kullanın. Bu, örneğin içerik düzenlerinin alt bilgi göstermesi, ancak başlık düzenlerinin göstermemesi gerektiğinde yararlıdır.

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

## **Master ve Alt Düzenlerinde Alt Bilgi Görünürlüğünü Kontrol Etme**

Bir master hiyerarşisi boyunca tutarlı alt bilgi ayarları uygulamak için [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/get_headerfootermanager/) metodunu kullanın. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslideheaderfootermanager/) nesnesinin yayma yöntemleri, master ve ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca bir normal slaytı hedef almaz.

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

**Master Slaytı ile Düzen Slaytı Arasındaki Fark Nedir?**

Bir master slayt, sunumun temasını ve paylaşılan biçimlendirmesini tanımlar. Bir düzen slaytı bir mastera aittir ve yeniden kullanılabilir bir yer tutucu düzeni tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Düzen Slaytını Bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/igloballayoutslidecollection/addclone/) yöntemiyle hedef koleksiyona bir kopya ekleyin. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı yazı tiplerini, temaları, resimleri ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Düzeni Değiştirdiğimde Ne Olur?**

Bağlı slaytlar, etkilenilen biçimlendirme veya nesneleri yerel olarak geçersiz kılmadıkça, düzen değişikliklerini devralır. Bu nedenle yer tutucu geometrisi ve devralınan stil, birden çok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [GetDependingSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/getdependingslides/) metodunu kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/pptxeditexception/) hatası fırlatır. Önce bağlı slaytları yeniden atayın veya yalnızca referanslandırılmamış düzenleri kaldırmak için [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metodunu kullanın.