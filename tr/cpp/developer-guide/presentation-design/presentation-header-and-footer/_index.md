---
title: C++'ta Sunum Üstbilgi ve Altbilgi Yönetimi
linktitle: Üstbilgi ve Altbilgi
type: docs
weight: 140
url: /tr/cpp/presentation-header-and-footer/
keywords:
- üstbilgi
- üstbilgi metni
- altbilgi
- altbilgi metni
- üstbilgi ayarla
- altbilgi ayarla
- el ilanı
- notlar
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile slaytlarda, not sayfalarında ve el ilanlarında altbilgi, tarih-saat, slayt-numarası ve üstbilgi yer tutucularını nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

PowerPoint, sayfa türüne göre farklı üstbilgi ve altbilgi yer tutucuları kullanır. Aspose.Slides for C++ bu yer tutucuların metnini ve görünürlüğünü üstbilgi/altbilgi yöneticisi arabirimleri aracılığıyla kontrol etmenizi sağlar.

Kullanılabilir yer tutucular kapsamına göre değişir:

| Kapsam | Üstbilgi | Altbilgi | Tarih/saat | Slayt/sayfa numarası |
|---|---|---|---|---|
| Normal slayt | Hayır | Evet | Evet | Evet |
| Notlar ana sayfası | Evet | Evet | Evet | Evet |
| Not slaytı | Evet | Evet | Evet | Evet |
| El ilanı ana sayfası | Evet | Evet | Evet | Evet |

Normal bir sunum slaytında üstbilgi yer tutucusu bulunmaz. Üstbilgiler not sayfalarında ve el ilanlarında mevcuttur. Normal slaytlar için altbilgi, tarih/saat ve slayt‑numarası yer tutucularını kullanın.

Değişikliğin kapsamı kullandığınız yöneticiye bağlıdır. [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideheaderfootermanager/) arabirimi tek bir normal slaytı kontrol eder. [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotesslideheaderfootermanager/) arabirimi tek bir not slaytını kontrol eder. Ana sayfa ve düzen yöneticileri ayrıca ayarları bağımlı slaytlara yayabilirken, [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) arabirimi el ilanı ana sayfasını kontrol eder.

## **Normal Slaytlarda Altbilgi, Tarih/Saat ve Slayt Numaralarını Ayarlama**

Normal slaytlar için temel iş akışı, her slaytın üstbilgi/altbilgi yöneticisine erişmek, altbilgi ve tarih/saat metnini ayarlamak, gerekli yer tutucuları etkinleştirmek ve sunumu kaydetmektir. Slayt numaraları sunum tarafından otomatik oluşturulur; yalnızca görünürlüğünü kontrol etmeniz gerekir.

Metni ayarlamak için [`SetFooterText`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) ve [`SetDateTimeText`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) yöntemlerini, ilgili yer tutucuları göstermek için ise [`SetFooterVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) ve [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) yöntemlerini kullanın.

Aşağıdaki uçtan uca örnek, aynı altbilgi, tarih/saat metni ve slayt‑numarası görünürlüğünü tüm normal slaytlara uygular:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Yalnızca bir slaytı güncellemek isterseniz, tüm slayt koleksiyonunu döngüye almaktansa [`Presentation::get_Slide`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_slide/) aracılığıyla o slayta doğrudan erişin.

## **Notlar Ana Sayfasında Üstbilgi ve Altbilgi Ayarlama**

Notlar ana sayfası, not sayfaları için ortak biçimlendirme ve yer tutucu davranışını tanımlar. Yalnızca notlar ana sayfasını değiştirmek istediğinizde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/) arabirimini kullanın.

Aşağıdaki örnek, notlar ana sayfasında üstbilgi, altbilgi ve tarih/saat metnini ayarlar ve o ana sayfadaki tüm desteklenen yer tutucuları görünür yapar:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

[`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) yöntemi, sunumda notlar ana sayfası bulunmadığında `nullptr` döndürür.

## **Notlar Ana Sayfası Ayarlarını Alt Not Slaytlarına Uygulama**

Bir notlar ana sayfası, üstbilgi ve altbilgi ayarlarını kendisine ve tüm bağımlı not slaytlarına uygulayabilir. Aynı ayarların notlar hiyerarşisi boyunca uygulanması gerektiğinde [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/) üzerindeki özel yayma yöntemlerini kullanın.

Örneğin, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) ve [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) notlar ana sayfası üstbilgisini ve tüm alt üstbilgileri günceller. Altbilgi, tarih/saat ve slayt numarası için eşdeğer yöntemler mevcuttur.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Yukarıda kullanılan yayma yöntemleri şunlardır: [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), ve [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Bireysel Bir Not Slaytında Üstbilgi ve Altbilgi Ayarlama**

Bir not slaytı, belirli bir normal slayta aittir. Yalnızca o not sayfasını özelleştirmek istediğinizde [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotesslideheaderfootermanager/) arabirimini kullanın.

[`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotesslidemanager/addnotesslide/) yöntemi, mevcut slayt için not slaytını döndürür ve mevcut değilse bir tane oluşturur. Aşağıdaki örnek, ilk sunum slaytıyla ilişkili not sayfasını yapılandırır:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

İlk olarak ayarları notlar ana sayfasından yayar, ardından bireysel bir not slaytını değiştirirseniz, sonraki slayt‑özel ayarlar o not sayfasını bağımsız şekilde özelleştirmenizi sağlar.

## **El İlanı Ana Sayfasında Üstbilgi ve Altbilgi Ayarlama**

El ilanı sayfaları, üstbilgi, altbilgi, tarih/saat ve sayfa‑numarası yer tutucuları için el ilanı ana sayfasını kullanır. Not sayfalarının aksine, el ilanı ayarları bireysel el ilanı slaytları yerine el ilanı ana sayfası aracılığıyla yönetilir.

El ilanı ana sayfasına erişmek için [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) metodunu kullanın. Eğer bulunmuyorsa, varsayılan el ilanı ana sayfasını oluşturmak için [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) metodunu çağırın.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Kapsam ve Kalıtımı Anlama**

Değiştirmek istediğiniz kapsama uygun üstbilgi/altbilgi yöneticisini seçin:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islideheaderfootermanager/) bir normal slayt için altbilgi, tarih/saat ve slayt‑numarası ayarlarını değiştirir.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslideheaderfootermanager/) bir düzen slaytını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslideheaderfootermanager/) bir normal slayt ana sayfasını kontrol eder ve desteklenen ayarları bağımlı slaytlara yayabilir.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasternotesslideheaderfootermanager/) notlar ana sayfasını kontrol eder ve ayarları tüm bağımlı not slaytlarına yayabilir.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/inotesslideheaderfootermanager/) bir not slaytını değiştirir ve üstbilgi yer tutucusunu, altbilgi, tarih/saat ve slayt numarası ile birlikte destekler.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) el ilanı ana sayfasını değiştirir ve dört yer tutucu tipinin tümünü destekler.

Aynı ayarın hiyerarşi boyunca uygulanması gerektiğinde bir ana sayfa veya düzen üzerinden yayma kullanın. Tek bir sayfa için yerel bir ayar gerektiğinde bireysel slayt veya not‑slayt yöneticisini kullanın.

## **SSS**

**Normal bir slayta üstbilgi ekleyebilir miyim?**

Hayır. PowerPoint normal slaytlar için bir üstbilgi yer tutucusu tanımlamaz. Normal slaytlarda altbilgi, tarih/saat ve slayt‑numarası yer tutucularını kullanın. Üstbilgi yer tutucuları not sayfalarında ve el ilanlarında mevcuttur.

**Altbilgi, tarih/saat veya slayt‑numarası yer tutucusu görünmüyorsa ne yapmalıyım?**

İlgili üstbilgi/altbilgi yöneticisini kullanarak görünürlüğünü kontrol edin ve gerektiğinde etkinleştirin. Örneğin, [`get_IsFooterVisible`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) bir altbilgi yer tutucusunun var olup olmadığını raporlar ve [`SetFooterVisibility`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) görünürlüğünü değiştirir.

**Slayt numaralandırmasını 1 dışındaki bir değerden başlatabilir miyim?**

[`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/set_firstslidenumber/) yöntemini kullanarak ilk slayt numarasını ayarlayın. Slayt‑numarası yer tutucuları güncellenen numaralandırma dizisini kullanır.

**PDF, görüntü veya HTML olarak dışa aktarılırken üstbilgi ve altbilgi ne olur?**

Görünür üstbilgi ve altbilgi öğeleri, sunum içeriğiyle birlikte çıktı formatında işlenir. Görünümü, dışa aktarılan sayfa türüne ve ilgili yer tutucu görünürlük ayarlarına bağlıdır.