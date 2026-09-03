---
title: یکپارچه‌سازی قلم‌ها در ارائه‌ها در .NET
linktitle: قلم‌های یکپارچه شده
type: docs
weight: 40
url: /fa/net/embedded-font/
keywords:
- افزودن قلم
- یکپارچه‌سازی قلم
- یکپارچه‌سازی قلم
- دریافت قلم یکپارچه شده
- افزودن قلم یکپارچه شده
- حذف قلم یکپارچه شده
- فشرده‌سازی قلم یکپارچه شده
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قلم‌های یکپارچه شده در PowerPoint را با Aspose.Slides برای .NET مدیریت کنید. از C# برای افزودن، دریافت، حذف و فشرده‌سازی قلم‌ها استفاده کنید تا ظاهر متن حفظ شود و حجم فایل کاهش یابد."
---
## **معرفی**

یکپارچه‌سازی قلم‌ها داده‌های قلم را داخل یک ارائهٔ PowerPoint ذخیره می‌کند. وقتی یک نمایشگر از قلم‌های یکپارچه پشتیبانی می‌کند، می‌تواند متن را با استفاده از آن قلم‌ها نمایش دهد حتی اگر در سیستم هدف نصب نشده باشند. این کار به حفظ شکست خطوط، فاصله‌گذاری متن و چیدمان اسلاید کمک می‌کند.

Aspose.Slides for .NET به شما امکان می‌دهد قلم‌های یکپارچه را از طریق ویژگی [FontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/fontsmanager/) یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) دریافت، اضافه و حذف کنید. همچنین می‌توانید با حذف کاراکترهایی که ارائه از آنها استفاده نمی‌کند، حجم داده‌های قلم یکپارچه را کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. قبل از یکپارچه‌سازی یک قلم، اطمینان حاصل کنید که داده‌های قلم برای Aspose.Slides در دسترس باشد و مجوز آن اجازهٔ یکپارچه‌سازی را بدهد.

## **دریافت و حذف قلم‌های یکپارچه شده**

از [GetEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts/) برای فهرست کردن قلم‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یک قلم، یک قلم از آن فهرست را به [RemoveEmbeddedFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/removeembeddedfont/) پاس دهید، سپس ارائه را ذخیره کنید.

مثال زیر قلم‌های یکپارچه موجود در `EmbeddedFonts.pptx` را فهرست می‌کند و در صورت وجود Calibri را حذف می‌نماید:

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

حذف یک قلم یکپارچه، داده‌های ذخیره‌شدهٔ آن قلم را حذف می‌کند؛ اما قلم اختصاص‌یافته به متن را تغییر نمی‌دهد. اگر قلم بر روی سیستم هدف نصب شده باشد، متن همچنان می‌تواند از آن استفاده کند. در غیر این صورت، ممکن است رندرینگ نیاز به [font substitution](/slides/fa/net/font-substitution/) داشته باشد که می‌تواند بر چیدمان تأثیر بگذارد.

## **بازرسی داده‌های قلم و مجوزهای یکپارچه‌سازی**

از رابط [IFontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/) برای بازرسی قلم‌ها پیش از یکپارچه‌سازی استفاده کنید. با فراخوانی [IFontsManager.GetFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getfonts/) قلم‌های استفاده‌شده در ارائه را به‌دست آورید. برای هر قلم، یک شیء [IFontData](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/fa/net/aspose.slides/fontstyletype/) را به [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getfontbytes/) پاس دهید. این متد داده‌های باینری آن سبک قلم را برمی‌گرداند یا `null` وقتی قلم یا سبک موردنظر موجود نیست. نتیجهٔ `null` را به [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) پاس ندهید، زیرا آن متد به آرایه بایتی نیاز دارد.

[EmbeddingLevel](https://reference.aspose.com/slides/fa/net/aspose.slides/embeddinglevel/) یک شمارش پرچم‌هاست که محدودیت‌های یکپارچه‌سازی ذخیره‌شده در قلم را گزارش می‌دهد:

- `Installable` اجازهٔ یکپارچه‌سازی و نصب دائمی بر روی سیستم دیگر را می‌دهد، مشروط بر مجوز قلم.
- `Restricted` یکپارچه‌سازی را ممنوع می‌کند مگر این که مجوز از مالک قانونی قلم اخذ شود وقتی که این پرچم تنها پرچم مجوز استفاده باشد.
- `PreviewPrint` اجازهٔ استفاده موقت برای مشاهده و چاپ را می‌دهد؛ سند حاوی قلم باید فقط‑خواندنی باشد.
- `Editable` اجازهٔ استفاده موقت و امکان ویرایش و ذخیرهٔ سند را می‌دهد.
- `NoSubsetting` محدودیتی اضافه است که ممنوع می‌کند تنها زیرمجموعه‌ای از گلیف‌ها یکپارچه شود. وقتی این پرچم حضور دارد، تمام کاراکترها یکپارچه می‌شوند.
- `BitmapOnly` محدودیتی اضافه است که فقط ضربه‌های بیت‌مپ را برای یکپارچه‌سازی می‌پذیرد، نه دادهٔ خطوط بیرونی. اگر قلم هیچ ضربهٔ بیت‌مپ نداشته باشد، نمی‌تواند یکپارچه شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آنها ترکیب شوند. برای بررسی این اصلاح‌کننده‌ها از عملیات بیتی استفاده کنید. چون `Installable` برابر صفر است، برای تشخیص آن از `HasFlag` استفاده نکنید؛ بیت‌های مجوز استفاده را ماسک کرده و نتیجه را با `Installable` مقایسه کنید. قلم‌های فعلی باید حداکثر یک بیت مجوز استفاده داشته باشند. برای سازگاری با قلم‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، کمک‌کنندهٔ زیر کم‌محدودترین مجوز را انتخاب می‌کند: `Editable`، سپس `PreviewPrint`، سپس `Restricted`.

مثال زیر داده‌های معمول، بولد، ایتالیک و بولد‑ایتالیک در دسترس برای هر قلم برگردانده‌شده توسط `GetFonts` را بررسی می‌کند. سبک‌های غیرفعال، قلم‌های محدود شده، قلم‌های فقط‑بیت‌مپ، قلم‌های محدود به پیش‌نمایش و چاپ (چون خروجی همچنان قابل ویرایش می‌ماند) و قلم‌های پیش‌اکنون یکپارچه را نادیده می‌گیرد. اگر هر سبک در دسترس `NoSubsetting` داشته باشد، تمام کاراکترهای آن خانوادهٔ قلم یکپارچه می‌شوند.

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

این بازرسی محدودیت‌های کدگذاری‌شده در هر فایل قلم را گزارش می‌دهد. این کار مجوزی نمی‌بخشد، ثابت نمی‌کند قلم را به‌صورت قانونی به‌دست آورده‌اید و جایگزین بررسی توافق‌نامهٔ مجوز قلم قبل از توزیع یک نسخهٔ یکپارچه نمی‌شود.

## **افزودن قلم‌های یکپارچه شده**

از [AddEmbeddedFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/addembeddedfont/) برای یکپارچه‌سازی یک قلم استفاده کنید. بارگذاری‌های آن یا یک شیء [IFontData](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontdata/) یا آرایهٔ بایتی حاوی دادهٔ قلم را می‌پذیرند. شمارش [EmbedFontCharacters](https://reference.aspose.com/slides/fa/net/aspose.slides.export/embedfontcharacters/) تعیین می‌کند کدام کاراکترها گنجانده شوند:

- [All](https://reference.aspose.com/slides/fa/net/aspose.slides.export/embedfontcharacters/) تمام کاراکترهای قلم را یکپارچه می‌کند. از این گزینه زمانی استفاده کنید که دریافت‌کنندگان نیاز به ویرایش ارائه و وارد کردن متن جدید داشته باشند.
- [OnlyUsed](https://reference.aspose.com/slides/fa/net/aspose.slides.export/embedfontcharacters/) تنها کاراکترهای استفاده‌شده در ارائه را یکپارچه می‌کند تا حجم فایل کاهش یابد. این گزینه را برای یک ارائهٔ نهایی که عمدتاً برای مشاهده است انتخاب کنید.

مثال زیر از [GetFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getfonts/) برای به‌دست آوردن قلم‌های استفاده‌شده در `Fonts.pptx` استفاده می‌کند و آن‌هایی را که هنوز یکپارچه نشده‌اند، یکپارچه می‌کند. قلم‌های اضافه‌شده باید بر روی ماشین اجرا کنندهٔ کد موجود باشند. قلم‌های یکپارچهٔ موجود مجموعهٔ کاراکترهای فعلی خود را حفظ می‌کنند.

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

## **فشرده‌سازی قلم‌های یکپارچه شده**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/compressembeddedfonts/) داده‌های قلم یکپارچه را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این متد بر قلم‌هایی که قبلاً یکپارچه شده‌اند کار می‌کند، بنابراین میزان کاهش حجم به مقدار داده‌های قلم استفاده‌نشده‌ای که ارائه دارد بستگی دارد.

مثال زیر قلم‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به‌عنوان یک فایل جداگانه ذخیره می‌نماید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

اگر ممکن است دریافت‌کنندگان بعداً نیاز به افزودن متن داشته باشند، فایل اصلی را نگه دارید. کاراکترهای حذف‌شده در طول فشرده‌سازی دیگر از قلم یکپارچه در دسترس نیستند، حتی اگر در ابتدا تمام کاراکترها را یکپارچه کرده باشید.

## **سؤالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک قلم یکپارچه در زمان رندر هنوز جایگزین می‌شود؟**

در محیطی که ارائه را رندر می‌کنید، [GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getsubstitutions/) را فراخوانی کنید تا ببینید Aspose.Slides کدام قلم‌ها را جایگزین می‌کند. همچنین تنظیمات [font substitution](/slides/fa/net/font-substitution/) و قوانین [font fallback](/slides/fa/net/fallback-font/) را بررسی کنید. فالباک کاراکترهای گمشده را مدیریت می‌کند، بنابراین یکپارچه‌سازی یک قلم کاراکترهایی که خود قلم دربردارد را برطرف نمی‌کند.

**آیا باید قلم‌های عمومی مانند Arial و Calibri را یکپارچه کنم؟**

تصمیم را بر اساس محیط هدف بگیرید. اگر قلم‌های مورد نیاز بر روی هر ماشینی که ارائه را باز یا رندر می‌کند موجود باشد، یکپارچه‌سازی آنها ممکن است حجم غیرضروری به فایل اضافه کند. اگر دریافت‌کنندگان یا سرورها ممکن است این قلم‌ها را نداشته باشند، یکپارچه‌سازی آنها می‌تواند به حفظ ظاهر موردنظر کمک کند، مشروط بر این که مجوزهای آنها اجازهٔ این کار را بدهد.