---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با C++
linktitle: بخش اسلاید
type: docs
weight: 100
url: /fa/cpp/slide-section/
keywords:
- ایجاد بخش
- افزودن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- دریافت اسلایدهای بخش
- پردازش اسلایدهای بخش
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید با Aspose.Slides برای C++: ایجاد، تغییر نام، ترتیب‌دهی مجدد، دریافت و پردازش اسلایدهای بخش در ارائه‌های PPTX."
---
## **معرفی**

بخش‌ها اسلایدهای متوالی را بدون تغییر محتوای اسلاید، به صورت گروه‌های نام‌گذاری‌شده سازماندهی می‌کنند. با Aspose.Slides برای C++ می‌توانید با استفاده از متد [Presentation::get_Sections](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sections/) بخش‌ها را ایجاد، ترتیب‌دهی مجدد، تغییر نام، بررسی و حذف کنید.

بخش‌ها به‌ویژه زمانی مفید هستند که:
- یک ارائه بزرگ نیاز دارد به موضوعات یا فصل‌های منطقی تقسیم شود؛
- گروه‌های مختلف اسلاید به همکاران متفاوت اختصاص داده شوند؛
- اسلایدها نیاز داشته باشند به‌عنوان گروه‌ها پردازش، منتقل یا ادغام شوند.

نام‌های بخش کوتاه و واضحی انتخاب کنید که هدف اسلایدهای گروه‌بندی‌شده را توصیف کند. چون بخش‌ها بخشی از ساختار ارائه هستند، برای تعیین عضویت از APIهای بخش استفاده کنید نه این‌که از موقعیت اسلایدها استخراج کنید.

## **ایجاد و مدیریت بخش‌ها**

از [ISectionCollection::AddSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectioncollection/addsection/) برای ایجاد یک بخش با مشخص کردن نام و اسلاید شروع استفاده کنید. Aspose.Slides اسلایدهایی که به بخش تعلق دارند را از ساختار فعلی بخش‌های ارائه تعیین می‌کند.

هم‌چنین [ISectionCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectioncollection/) همان امکان را می‌دهد:
- جابه‌جایی یک بخش همراه با اسلایدهای آن با استفاده از [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- حذف فقط تعریف بخش با [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectioncollection/removesection/)، که اسلایدهای آن را حفظ می‌کند؛ 
- حذف یک بخش به همراه اسلایدهای آن با [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- افزودن یک بخش خالی در انتها با [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectioncollection/appendemptysection/).

مثال زیر دو بخش ایجاد می‌کند، یکی از آن‌ها را جابه‌جا می‌کند، آن را همراه با اسلایدهایش حذف می‌کند و یک بخش خالی اضافه می‌نماید:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

پس از این عملیات، ارائه شامل بخش `Introduction` به همراه اسلایدهایش و یک بخش خالی `Appendix` می‌شود. بخش `Results` و اسلایدهایش حذف شده‌اند.

## **تغییر نام بخش‌ها**

برای تغییر نام یک بخش، [ISection::set_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/set_name/) را فراخوانی کنید. اسلایدهای بخش و موقعیت آن بدون تغییر باقی می‌مانند.

مثال زیر یک بخش ایجاد می‌کند و نام آن را تغییر می‌دهد:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **دریافت اسلایدها از بخش‌ها**

متد [Presentation::get_Sections](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sections/) یک [ISectionCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectioncollection/) را برمی‌گرداند که می‌توانید آن را مرور کنید. برای هر [ISection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/)، با فراخوانی [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/getslideslistofsection/) اسلایدهایی که در حال حاضر به آن تعلق دارند را به دست می‌آورید. این متد یک [ISectionSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectionslidecollection/) را باز می‌گرداند که شامل شمارش، دسترسی اندیسی و امکان مرور است.

مثال زیر دو بخش پر شده و یک بخش خالی ایجاد می‌کند، سپس نام هر بخش را با استفاده از لینک [نام](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/get_name/)، [شناسه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/get_sectionid/), [اسلاید شروع](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/get_startedfromslide/), تعداد اسلایدها و شماره اسلایدها چاپ می‌کند. از دسترسی اندیسی برای خواندن اولین اسلاید و یک حلقه `for` مبتنی بر بازه برای پردازش تمام اسلایدها استفاده می‌شود. برای بخش خالی، مجموعه بازگردانده‌شده شمارشی برابر صفر دارد، دسترسی اندیسی استفاده نمی‌شود و مرور هیچ تکراری انجام نمی‌دهد.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

عضویت در بخش‌ها توسط ساختار بخش‌های ارائه تعیین می‌شود. محدوده یک بخش را به‌صورت دستی از [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/get_startedfromslide/)، شاخص‌های اسلاید و اسلاید شروع بخش بعدی محاسبه نکنید.

ویرایش‌های ساختاری می‌توانند هم اسلایدهای برگشتی برای یک بخش و هم شماره‌های آن را تغییر دهند. این شامل ترتیب‌داده‑مجدّد اسلایدها، کلون کردن یک اسلاید به یک بخش، جابه‌جایی یک بخش همراه با اسلایدهای آن، حذف اسلایدها و حذف بخش‌ها می‌شود. مثال بعدی پس از هر چنین تغییری به جای حفظ فرضیات دربارهٔ مرزهای قبلی بخش، [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/getslideslistofsection/) را فراخوانی می‌کند.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

هر زمان اسلایدها یا بخش‌ها دوباره ترتیب داده شوند، کلون شوند، جابه‌جا یا حذف شوند، [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/getslideslistofsection/) را دوباره فراخوانی کنید. این کار پردازش‌های بعدی را با ساختار فعلی ارائه هم‌راستا نگه می‌دارد.

قالب PPT (PowerPoint 97–2003) متادیتای بخش‌ها را حفظ نمی‌کند. از این جریان کاری با قالبی که از بخش‌ها پشتیبانی می‌کند، مانند PPTX استفاده کنید؛ تبدیل به PPT ساختار بخش‌ها را که برای شمارش‌های بعدی لازم است، حذف می‌کند.

## **سوالات متداول**

**آیا بخش‌ها هنگام ذخیره به قالب PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. قالب PPT از متادیتای بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از بین می‌رود.

**آیا می‌توان یک بخش کامل را "پنهان" کرد؟**

خیر. یک بخش وضعیت نمایش ندارد. برای پنهان کردن محتویات آن، برای هر اسلاید در بخش، [ISlide::set_Hidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/set_hidden/) را فراخوانی کنید.

**چگونه می‌توانم بخشی که شامل یک اسلاید است پیدا کنم؟**

با مرور [Presentation::get_Sections](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sections/)، برای هر بخش [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/getslideslistofsection/) را صدا بزنید و اسلایدهای برگردانده‌شده را با اسلاید هدف مقایسه کنید. برای یک بخش غیر خالی، [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isection/get_startedfromslide/) اولین اسلاید آن را برمی‌گرداند؛ برای یک بخش خالی، `nullptr` برمی‌گرداند.