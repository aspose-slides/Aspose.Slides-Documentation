---
title: مدیریت بخش‌های اسلاید در ارائه‌ها با .NET
linktitle: بخش اسلاید
type: docs
weight: 100
url: /fa/net/slide-section/
keywords:
- ایجاد بخش
- اضافه کردن بخش
- ویرایش بخش
- تغییر بخش
- نام بخش
- دریافت اسلایدهای بخش
- پردازش اسلایدهای بخش
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید با Aspose.Slides برای .NET: ایجاد، تغییر نام، ترتیب‌دهنی، دریافت و پردازش اسلایدهای بخش در ارائه‌های PPTX."
---
## **معرفی**

بخش‌ها اسلایدهای متوالی را در گروه‌های نام‌گذاری‌شده سازماندهی می‌کنند بدون تغییر محتوای اسلاید. با Aspose.Slides برای .NET، می‌توانید بخش‌ها را از طریق ویژگی [Presentation.Sections](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sections/) ایجاد، ترتیب‌دهي، تغییر نام، بازبینی و حذف کنید.

بخش‌ها به‌ویژه زمانی مفید هستند که:

- یک ارائه بزرگ نیاز به تقسیم به موضوعات یا فصول منطقی دارد؛
- گروه‌های مختلف اسلاید به همکاران مختلف اختصاص داده می‌شوند؛
- اسلایدها نیاز به پردازش، جابجایی یا ادغام به‌صورت گروهی دارند.

نام‌های مختصر برای بخش‌ها انتخاب کنید که هدف اسلایدهای گروه‌بندی‌شده را توصیف کنند. از آنجا که بخش‌ها جزئی از ساختار ارائه هستند، برای تعیین عضویت از APIهای بخش استفاده کنید نه این‌که آن را از موقعیت اسلایدها استخراج کنید.

## **ایجاد و مدیریت بخش‌ها**

از [ISectionCollection.AddSection](https://reference.aspose.com/slides/fa/net/aspose.slides/sectioncollection/addsection/) برای ایجاد یک بخش با مشخص کردن نام و اسلاید شروع استفاده کنید. Aspose.Slides تشخیص می‌دهد کدام اسلایدها به بخش تعلق دارند براساس ساختار فعلی بخش‌های ارائه.

همان [ISectionCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isectioncollection/) همچنین به شما اجازه می‌دهد:

- یک بخش را همراه با اسلایدهای آن با استفاده از [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/sectioncollection/reordersectionwithslides/) جابجا کنید؛
- فقط تعریف بخش را با [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/fa/net/aspose.slides/sectioncollection/removesection/) حذف کنید، که اسلایدهای آن را نگه می‌دارد؛
- یک بخش و اسلایدهای آن را با [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/sectioncollection/removesectionwithslides/) حذف کنید؛
- یک بخش خالی در انتها با [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/fa/net/aspose.slides/sectioncollection/appendemptysection/) اضافه کنید.

مثال زیر دو بخش ایجاد می‌کند، یکی از آن‌ها را جابجا می‌کند، آن را همراه با اسلایدهایش حذف می‌کند و یک بخش خالی افزودن می‌کند:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

پس از این عملیات، ارائه شامل بخش `Introduction` به همراه اسلایدهای آن و یک بخش خالی `Appendix` می‌شود. بخش `Results` و اسلایدهای آن حذف شده‌اند.

## **تغییر نام بخش‌ها**

برای تغییر نام یک بخش، ویژگی [ISection.Name](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/name/) آن را تنظیم کنید. اسلایدها و موقعیت بخش بدون تغییر می‌مانند.

مثال زیر یک بخش ایجاد می‌کند و نام آن را تغییر می‌دهد:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **دریافت اسلایدها از بخش‌ها**

ویژگی [Presentation.Sections](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sections/) یک [ISectionCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isectioncollection/) را برمی‌گرداند که می‌توانید پیمایش کنید. برای هر [ISection](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/)، متد [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/getslideslistofsection/) را صدا بزنید تا اسلایدهایی که در حال حاضر به آن تعلق دارند دریافت کنید. این متد یک [ISectionSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isectionslidecollection/) را برمی‌گرداند که شمارش، دسترسی ایندکس‌دار و پیمایش را فراهم می‌کند.

مثال زیر دو بخش پر شده و یک بخش خالی ایجاد می‌کند، سپس نام، شناسه، اسلاید شروع، تعداد اسلاید و شماره‌های اسلاید هر بخش را چاپ می‌کند. برای خواندن اولین اسلاید از ایندکس‌گذار مجموعه استفاده می‌شود و برای پردازش هر اسلاید از `foreach` بهره می‌گیرد. برای بخش خالی، مجموعه بازگردانده‌شده شمارش صفر دارد، ایندکس‌گذار دسترسی پیدا نمی‌کند و پیمایش هیچ تکراری انجام نمی‌دهد.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

عضویت در بخش توسط ساختار بخش‌های ارائه تعیین می‌شود. بازه یک بخش را به‌صورت دستی از [ISection.StartedFromSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/startedfromslide/)، ایندکس‌های اسلاید و اسلاید شروع بخش بعدی محاسبه نکنید.

ویرایش‌های ساختاری می‌توانند هم اسلایدهای بازگردانده‌شده برای یک بخش و هم شماره‌های اسلایدهای آن را تغییر دهند. این شامل ترتیب‌دهنی اسلایدها، کلون کردن اسلاید در یک بخش، جابجایی یک بخش همراه با اسلایدهایش، حذف اسلایدها و حذف بخش‌ها است. مثال بعدی پس از هر تغییر این‌چنین، به‌جای حفظ فرضیات در مورد مرزهای قبلی بخش، متد [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/getslideslistofsection/) را فراخوانی می‌کند.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

هر بار که اسلایدها یا بخش‌ها ترتیب‌دهنی، کلون، جابجا یا حذف می‌شوند، دوباره متد [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/getslideslistofsection/) را صدا بزنید. این کار پردازش‌های بعدی را با ساختار جاری ارائه همساز می‌کند.

قالب PPT (PowerPoint 97–2003) متادیتای بخش‌ها را حفظ نمی‌کند. از این کارگردانی با قالبی که از بخش‌ها پشتیبانی می‌کند، مانند PPTX، استفاده کنید؛ تبدیل به PPT ساختار بخش‌های مورد نیاز برای پیمایش بعدی را حذف می‌کند.

## **پرسش‌های متداول**

**آیا بخش‌ها هنگام ذخیره‌سازی به فرمت PPT (PowerPoint 97–2003) حفظ می‌شوند؟**

خیر. فرمت PPT از داده‌های متادیتای بخش پشتیبانی نمی‌کند، بنابراین گروه‌بندی بخش‌ها هنگام ذخیره به .ppt از بین می‌رود.

**آیا می‌توان یک بخش کامل را «پنهان» کرد؟**

خیر. یک بخش هیچ وضعیت نمایانی ندارد. برای مخفی کردن محتویات آن، ویژگی [ISlide.Hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/hidden/) را برای هر اسلاید در بخش تنظیم کنید.

**چگونه می‌توانم بخشی را که شامل یک اسلاید است پیدا کنم؟**

[Presentation.Sections](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sections/) را پیمایش کنید، برای هر بخش متد [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/getslideslistofsection/) را صدا بزنید و اسلایدهای بازگردانده‌شده را با اسلاید هدف مقایسه کنید. برای یک بخش غیرخالی، [ISection.StartedFromSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/isection/startedfromslide/) اسلاید اول آن را برمی‌گرداند؛ برای یک بخش خالی، `null` برمی‌گرداند.