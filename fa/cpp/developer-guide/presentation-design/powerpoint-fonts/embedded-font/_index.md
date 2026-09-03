---
title: جاسازی قلم‌ها در ارائه‌ها با C++
linktitle: قلم‌های جاسازی‌شده
type: docs
weight: 40
url: /fa/cpp/embedded-font/
keywords:
- افزودن قلم
- جاسازی قلم
- جاسازی قلم
- دریافت قلم جاسازی‌شده
- افزودن قلم جاسازی‌شده
- حذف قلم جاسازی‌شده
- فشرده‌سازی قلم جاسازی‌شده
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "قلم‌های جاسازی‌شده در PowerPoint را با Aspose.Slides برای C++ مدیریت کنید. قلم‌ها را اضافه، بازیابی، حذف و فشرده‌سازی کنید تا ظاهر متن حفظ شود و حجم فایل کاهش یابد."
---
## **مقدمه**

جاسازی قلم‌ها داده‌های قلم را داخل یک ارائهٔ PowerPoint ذخیره می‌کند. وقتی یک نمایشگر از قلم‌های جاسازی‌شده پشتیبانی کند، می‌تواند متن را با آن قلم‌ها نمایش دهد حتی اگر قلم‌ها بر روی سیستم هدف نصب نشده باشند. این کار به حفظ شکست خطوط، فاصله‌های متنی و چیدمان اسلاید کمک می‌کند.

Aspose.Slides for C++ به شما امکان می‌دهد قلم‌های جاسازی‌شده را از طریق متد [Presentation::get_FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_fontsmanager/) یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) دریافت، اضافه و حذف کنید. همچنین می‌توانید با حذف کاراکترهایی که ارائه از آن‌ها استفاده نمی‌کند، حجم داده‌های قلم‌های جاسازی‌شده را کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. پیش از جاسازی یک قلم، مطمئن شوید داده‌های قلم برای Aspose.Slides در دسترس است و مجوز آن اجازهٔ جاسازی را می‌دهد.

## **دریافت و حذف قلم‌های جاسازی‌شده**

از [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) برای فهرست‌کردن قلم‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یکی از آن‌ها، قلم مورد نظر را از آن فهرست به [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/removeembeddedfont/) پاس داده و سپس ارائه را ذخیره کنید.

مثال زیر قلم‌های جاسازی‌شده در `EmbeddedFonts.pptx` را فهرست می‌کند و در صورتی که قلم Calibri موجود باشد آن را حذف می‌کند:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

حذف یک قلم جاسازی‌شده داده‌های ذخیره شدهٔ آن قلم را حذف می‌کند؛ این کار قلم اختصاص‌یافته به متن را تغییر نمی‌دهد. اگر قلم بر روی سیستم هدف نصب شده باشد، متن همچنان می‌تواند از آن استفاده کند. در غیر این صورت، ممکن است رندرینگ نیاز به [font substitution](/slides/fa/cpp/font-substitution/) داشته باشد که می‌تواند بر چیدمان تأثیر بگذارد.

## **بازرسی داده‌های قلم و مجوزهای جاسازی**

از رابط [IFontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/) برای بازرسی قلم‌ها پیش از جاسازی استفاده کنید. برای دریافت قلم‌های استفاده‌شده در ارائه، متد [IFontsManager::GetFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getfonts/) را صدا بزنید. برای هر قلم، یک شیء [IFontData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontstyletype/) را به [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getfontbytes/) پاس دهید. این متد داده‌های باینری آن سبک قلم را برمی‌گرداند یا `nullptr` زمانی که قلم یا سبک درخواست‌شده موجود نباشد. نتیجهٔ `nullptr` را به [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) پاس ندهید، زیرا این متد به یک آرایهٔ بایت نیاز دارد.

[EmbeddingLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides/embeddinglevel/) یک شمارش پرچم‌دار است که محدودیت‌های جاسازی ذخیره‌شده در قلم را گزارش می‌دهد:

- `Installable` اجازهٔ جاسازی و نصب دائمی بر روی سیستم دیگر را می‌دهد، مشروط بر مجوز قلم.
- `Restricted` مگر اینکه اجازهٔ قانونی مالک قلم دریافت شود، جاسازی را ممنوع می‌کند هنگامی که این پرچم تنها پرچم مجوز استفاده باشد.
- `PreviewPrint` استفاده موقت برای مشاهده و چاپ را مجاز می‌کند؛ سندی که حاوی این قلم باشد باید به‌صورت فقط‑خواندنی باشد.
- `Editable` استفاده موقت را مجاز می‌سازد و اجازه می‌دهد سند ویرایش و ذخیره شود.
- `NoSubsetting` محدودیتی اضافی است که تنها اجازهٔ جاسازی زیرمجموعه‌ای از گلیف‌ها را نمی‌دهد. وقتی این پرچم وجود داشته باشد، باید همهٔ کاراکترها جاسازی شوند.
- `BitmapOnly` محدودیتی اضافه است که فقط ضربات بیتی (bitmap) را اجازهٔ جاسازی می‌دهد، نه داده‌های خطی. اگر قلم هیچ ضربهٔ بیتی نداشته باشد، نمی‌تواند جاسازی شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آن‌ها ترکیب شوند. با عملیات بیتی این اصلاح‌کننده‌ها را بررسی کنید. چون `Installable` مقدار صفر است، بیت‌های مجوز استفاده را ماسک کرده و نتیجه را با `Installable` مقایسه کنید. قلم‌های فعلی باید حداکثر یک بیت مجوز استفاده داشته باشند. برای سازگاری با قلم‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، کمکی که در زیر آورده شده است کم‌محدودیت‌ترین مجوز را انتخاب می‌کند: ابتدا `Editable`، سپس `PreviewPrint`، سپس `Restricted`.

مثال زیر داده‌های معمول، بولد، ایتالیک و بولد‑ایتالیک هر قلم بازگردانده‌شده توسط `GetFonts` را بازبینی می‌کند. سبک‌های ناموجود، قلم‌های محدود‌شده، قلم‌های فقط‑بیتی، قلم‌هایی که فقط برای پیش‌نمایش و چاپ محدود شده‌اند (چون خروجی همچنان قابل ویرایش است) و قلم‌های از پیش جاسازی‌شده را حذف می‌کند. اگر هر سبک موجود دارای `NoSubsetting` باشد، تمام کاراکترهای آن خانوادهٔ قلم جاسازی می‌شوند.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

این بازبینی محدودیت‌های کدگذاری‌شده در هر فایل قلم را گزارش می‌کند. این کار مجوزی اعطا نمی‌کند، اثبات نمی‌کند که قلم را به‌طور قانونی دریافت کرده‌اید و جایگزین بررسی توافق‌نامهٔ مجوز قلم قبل از توزیع یک نسخهٔ جاسازی‌شده نمی‌شود.

## **افزودن قلم‌های جاسازی‌شده**

از [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/addembeddedfont/) برای جاسازی یک قلم استفاده کنید. این متد بارگذاری‌های مختلفی دارد که یا یک شیء [IFontData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontdata/) یا یک آرایهٔ بایت حاوی داده‌های قلم را می‌پذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/embedfontcharacters/) تعیین می‌کند کدام کاراکترها گنجانده شوند:

- [All](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/embedfontcharacters/) تمام کاراکترهای قلم را جاسازی می‌کند. از این گزینه زمانی استفاده کنید که گیرندگان نیاز به ویرایش ارائه و وارد کردن متن جدید داشته باشند.
- [OnlyUsed](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/embedfontcharacters/) فقط کاراکترهای استفاده‌شده در ارائه را جاسازی می‌کند تا حجم فایل کاهش یابد. این گزینه را برای یک ارائهٔ نهایی که عمدتاً برای نمایش است، انتخاب کنید.

مثال زیر از [IFontsManager::GetFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getfonts/) برای دریافت قلم‌های استفاده‌شده در `Fonts.pptx` استفاده می‌کند و آن‌هایی را که هنوز جاسازی نشده‌اند، اضافه می‌کند. قلم‌های مورد نیاز باید بر روی ماشینی که کد اجرا می‌شود در دسترس باشند. قلم‌های جاسازی‌شدهٔ موجود مجموعهٔ کاراکتر فعلی خود را حفظ می‌کنند.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **فشرده‌سازی قلم‌های جاسازی‌شده**

متد [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) داده‌های قلم‌های جاسازی‌شده را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این عملیات بر روی قلم‌هایی که قبلاً جاسازی شده‌اند اعمال می‌شود، بنابراین میزان کاهش حجم به مقدار داده‌های قلم استفاده‌نشدهٔ موجود در ارائه بستگی دارد.

مثال زیر قلم‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به‌صورت یک فایل جداگانه ذخیره می‌نماید:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

اگر ممکن است گیرندگان بعداً نیاز به افزودن متن داشته باشند، فایل اصلی را نگه دارید. کاراکترهای حذف‌شده هنگام فشرده‌سازی دیگر از قلم جاسازی‌شده در دسترس نیستند، حتی اگر در ابتدا همهٔ کاراکترها را جاسازی کرده باشید.

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک قلم جاسازی‌شده در هنگام رندرینگ همچنان جایگزین می‌شود یا نه؟**

در محیطی که ارائه را رندر می‌کنید، متد [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getsubstitutions/) را فراخوانی کنید تا ببینید Aspose.Slides چه قلم‌هایی را جایگزین می‌کند. همچنین تنظیمات [font substitution](/slides/fa/cpp/font-substitution/) و قواعد [font fallback](/slides/fa/cpp/fallback-font/) را بررسی کنید. fallback کاراکترهای گمشده را پوشش می‌دهد، بنابراین جاسازی یک قلم مشکلات کاراکترهایی را که آن قلم خودشان دارد حل نمی‌کند.

**آیا باید قلم‌های رایج مانند Arial و Calibri را جاسازی کنم؟**

تصمیم‌گیری را بر پایهٔ محیط هدف انجام دهید. اگر قلم‌های مورد نیاز روی هر ماشینی که ارائه را باز یا رندر می‌کند موجود باشد، جاسازی آن‌ها ممکن است حجم فایل را بی‌مورد افزایش دهد. اگر گیرندگان یا سرورهایی ممکن است این قلم‌ها را نداشته باشند، جاسازی آن‌ها می‌تواند به حفظ ظاهر مورد نظر کمک کند، به‌شرط آنکه مجوزهای آن‌ها اجازهٔ این کار را بدهد.