---
title: جاسازی فونت‌ها در ارائه‌ها در .NET
linktitle: فونت‌های جاسازی‌شده
type: docs
weight: 40
url: /fa/net/embedded-font/
keywords:
- افزودن فونت
- جاسازی فونت
- جاسازی فونت
- دریافت فونت جاسازی‌شده
- افزودن فونت جاسازی‌شده
- حذف فونت جاسازی‌شده
- فشرده‌سازی فونت جاسازی‌شده
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فونت‌های جاسازی‌شده در PowerPoint را با Aspose.Slides برای .NET مدیریت کنید. از C# برای افزودن، بازیابی، حذف و فشرده‌سازی فونت‌ها استفاده کنید تا ظاهر متن حفظ شود و حجم فایل کاهش یابد."
---
## **مقدمه**

جاسازی فونت‌ها داده‌های فونت را داخل یک ارائهٔ PowerPoint ذخیره می‌کند. وقتی یک بیننده از فونت‌های جاسازی‌شده پشتیبانی می‌کند، می‌تواند متن را با استفاده از آن فونت‌ها نمایش دهد حتی اگر روی سیستم هدف نصب نشده باشند. این کار به حفظ شکاف‌های خط، فواصل متن و چیدمان اسلاید کمک می‌کند.

Aspose.Slides برای .NET به شما امکان می‌دهد فونت‌های جاسازی‌شده را از طریق ویژگی [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بازیابی، اضافه یا حذف کنید. همچنین می‌توانید با حذف کاراکتری که ارائه از آن استفاده نمی‌کند، حجم داده‌های فونت جاسازی‌شده را کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. پیش از جاسازی یک فونت، اطمینان حاصل کنید دادهٔ فونت برای Aspose.Slides در دسترس است و مجوز آن اجازهٔ جاسازی را می‌دهد.

## **دریافت و حذف فونت‌های جاسازی‌شده**

از [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) برای فهرست کردن فونت‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یک فونت، یک فونت از آن فهرست را به [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/) پاس داده، سپس ارائه را ذخیره کنید.

مثال زیر فونت‌های جاسازی‌شده در `EmbeddedFonts.pptx` را فهرست می‌کند و در صورت وجود Calibri را حذف می‌نماید:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

حذف یک فونت جاسازی‌شده دادهٔ فونت ذخیره‌شده را حذف می‌کند؛ این کار فونت اختصاص‌یافته به متن را تغییر نمی‌دهد. اگر فونت بر روی سیستم هدف نصب شده باشد، متن همچنان می‌تواند از آن استفاده کند. در غیر این صورت، رندر ممکن است نیاز به [جایگزینی قلم](/slides/fa/net/font-substitution/) داشته باشد که می‌تواند بر چیدمان تأثیر بگذارد.

## **بازرسی دادهٔ فونت و مجوزهای جاسازی**

از رابط [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) برای بازبینی فونت‌ها پیش از جاسازی استفاده کنید. برای دریافت فونت‌های استفاده‌شده در ارائه، [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) را فراخوانی کنید. برای هر فونت، یک شیء [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) را به [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/) پاس دهید. این متد دادهٔ باینری آن سبک فونت را برمی‌گرداند یا `null` زمانی که فونت یا سبک درخواست‌شده موجود نیست. نتیجهٔ `null` را به [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) پاس ندهید، زیرا این متد به آرایه‌ای از بایت نیاز دارد.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) یک شمارش پرچم‌هاست که محدودیت‌های جاسازی ذخیره‌شده در فونت را گزارش می‌کند:

- `Installable` اجازهٔ جاسازی و نصب دائمی روی سیستم دیگر را می‌دهد، مشروط بر مجوز فونت.
- `Restricted` مگر اینکه اجازهٔ مالک قانونی فونت دریافت شود، اجازهٔ جاسازی نمی‌دهد، وقتی که تنها پرچم مجوز استفاده باشد.
- `PreviewPrint` اجازهٔ استفادهٔ موقت برای مشاهده و چاپ را می‌دهد؛ سند حاوی فونت باید فقط‑خواندنی باشد.
- `Editable` اجازهٔ استفادهٔ موقت و امکان ویرایش و ذخیرهٔ سند را می‌دهد.
- `NoSubsetting` محدودیتی اضافه است که اجازهٔ جاسازی تنها زیرمجموعه‌ای از گلیف‌ها را نمی‌دهد. وقتی این پرچم وجود داشته باشد، باید همهٔ کاراکترها جاسازی شوند.
- `BitmapOnly` محدودیتی اضافه است که فقط ضربه‌های بیت‌مپ را اجازهٔ جاسازی می‌دهد، نه دادهٔ خطوط بیرونی. اگر فونت ضربهٔ بیت‌مپ نداشته باشد، نمی‌تواند جاسازی شود.

چهار مقدار اولیه مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آن‌ها ترکیب شوند. برای بررسی این اصلاح‌کننده‌ها از عملیات بیتی استفاده کنید. از آنجا که `Installable` برابر صفر است، برای تشخیص آن از `HasFlag` استفاده نکنید؛ بیت‌های مجوز استفاده را ماسک کرده و نتیجه را با `Installable` مقایسه کنید. فونت‌های فعلی باید حداکثر یک بیت مجوز استفاده داشته باشند. برای سازگاری با فونت‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، کمکی که در ادامه می‌آید، کم‌محدودیت‌ترین مجوز را انتخاب می‌کند: ابتدا `Editable`، سپس `PreviewPrint` و در نهایت `Restricted`.

مثال زیر داده‌های معمول، بولد، ایتالیک و بولد‑ایتالیک موجود برای هر فونتی که `GetFonts` برگردانده است را بازبینی می‌کند. سبک‌های ناموجود، فونت‌های محدود، فونت‌های فقط‑بیت‌مپ، فونت‌های محدود به پیش‌نمایش و چاپ (زیرا خروجی ویرایش‌پذیر می‌ماند) و فونت‌های قبلاً جاسازی‌شده را نادیده می‌گیرد. اگر هر سبک موجود دارای `NoSubsetting` باشد، تمام کاراکترهای آن خانوادهٔ فونت را جاسازی می‌کند.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

این بازرسی محدودیت‌های رمزگذاری‌شده در هر فایل فونت را گزارش می‌دهد. این کار مجوزی اعطا نمی‌کند، ثابت نمی‌کند که فونت به‌صورت قانونی به دست آمده و جایگزینی بررسی مجوز فونت پیش از توزیع یک نسخهٔ جاسازی‌شده را جایگزین نمی‌کند.

## **افزودن فونت‌های جاسازی‌شده**

از [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) برای جاسازی یک فونت استفاده کنید. بارگذاری‌های آن یا یک شیء [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) یا یک آرایهٔ بایت حاوی دادهٔ فونت را می‌پذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) تعیین می‌کند که کدام کاراکترها گنجانده شوند:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) همهٔ کاراکترهای فونت را جاسازی می‌کند. این گزینه را زمانی استفاده کنید که گیرندگان نیاز به ویرایش ارائه و وارد کردن متن جدید داشته باشند.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) فقط کاراکترهای استفاده‌شده در ارائه را جاسازی می‌کند تا حجم فایل کاهش یابد. این گزینه برای ارائهٔ نهایی که عمدتاً برای نمایش است مناسب است.

مثال زیر از [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) برای دریافت فونت‌های استفاده‌شده در `Fonts.pptx` استفاده می‌کند و آن‌هایی که پیش از این جاسازی نشده‌اند را اضافه می‌نماید. فونت‌های مورد افزودن باید بر روی دستگاه اجرا کنندهٔ کد در دسترس باشند. فونت‌های جاسازی‌شدهٔ موجود مجموعهٔ کاراکترهای فعلی خود را حفظ می‌کنند.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **فشرده‌سازی فونت‌های جاسازی‌شده**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) دادهٔ فونت جاسازی‌شده را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این متد روی فونت‌هایی که قبلاً جاسازی شده‌اند عمل می‌کند، بنابراین میزان کاهش حجم به مقدار دادهٔ فونت استفاده‌نشدهٔ موجود در ارائه وابسته است.

مثال زیر فونت‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به عنوان یک فایل جداگانه ذخیره می‌نماید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

اگر ممکن است گیرندگان بعداً نیاز به افزودن متن داشته باشند، فایل اصلی را نگه دارید. کاراکترهای حذف‌شده در طول فشرده‌سازی دیگر از فونت جاسازی‌شده در دسترس نیستند، حتی اگر در ابتدا همهٔ کاراکترها را جاسازی کرده باشید.

برای اینکه یک فونت ثبت‌شدهٔ مطابق در زمان خروجی اولویت داشته باشد بدون اینکه فونت جاسازی‌شده حذف شود، به [Prefer Registered Fonts over Embedded Fonts](/slides/fa/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 یا بالاتر) مراجعه کنید.

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک فونت جاسازی‌شده هنگام رندر هنوز جایگزین می‌شود یا نه؟**

در محیطی که ارائه را رندر می‌کنید، [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) را فراخوانی کنید تا ببینید Aspose.Slides چه فونت‌هایی را جایگزین می‌کند. همچنین تنظیمات [جایگزینی قلم](/slides/fa/net/font-substitution/) و قوانین [fallback-font](/slides/fa/net/fallback-font/) را بررسی کنید. بازگشت به فونت‌های پیش‌فرض کاراکترهای گمشده را مدیریت می‌کند، بنابراین جاسازی یک فونت مشکلی را برای کاراکترهایی که خود فونت شامل آن‌ها نیست، حل نمی‌کند.

**آیا باید فونت‌های عمومی مانند Arial و Calibri را جاسازی کنم؟**

تصمیم‌گیری بر پایهٔ محیط هدف باشد. اگر فونت‌های مورد نیاز بر روی هر دستگاهی که ارائه را باز یا رندر می‌کند موجود باشد، جاسازی آن‌ها ممکن است حجم فایل را بدون نیاز اضافه کند. اگر گیرندگان یا سرورها ممکن است این فونت‌ها را نداشته باشند، جاسازی آن‌ها می‌تواند به حفظ ظاهر موردنظر کمک کند، به شرطی که مجوزهایشان این امکان را بدهد.