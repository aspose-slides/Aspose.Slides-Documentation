---
title: مدیریت قلم‌های تم مخصوص اسکریپت در .NET
linktitle: قلم‌های تم مخصوص اسکریپت
type: docs
weight: 15
url: /fa/net/script-specific-font-mappings/
keywords:
- قلم مخصوص اسکریپت
- نگاشت قلم تم
- ارائه چند زبانه
- سیستم نوشتاری
- قلم سیریلیک
- قلم عربی
- قلم ژاپنی
- قلم گرجی
- قلم ثانا
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بازرسی، افزودن، جایگزینی و حذف نگاشت‌های قلم مخصوص اسکریپت در تم‌های PowerPoint با Aspose.Slides برای .NET."
---
## **بررسی کلی**

یک تم ارائه می‌تواند برای سیستم‌های نوشتاری مختلف خانواده‌های قلم متفاوتی انتخاب کند. این امکان را می‌دهد که متنی چند زبانه که هنوز از قلم‌های تم استفاده می‌کند، یک طرح قلم هماهنگ داشته باشد در حالی که برای سیریلیک، عربی، ژاپنی، گرجی، ثانا و سایر اسکریپت‌ها قلم‌های مناسب به کار رود.

تم [IFontScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/ifontscheme/) شامل یک مجموعه قلم اصلی، که معمولاً برای عناوین استفاده می‌شود، و یک مجموعه قلم فرعی، که معمولاً برای متن بدنه به کار می‌رود، است. علاوه بر ویژگی‌های قلم‌های لاتین و شرق آسیا، هر دو مجموعه با واسط [IFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/ifonts/) نگاشت‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده قلم ارائه می‌دهند.

این مقاله نشان می‌دهد چگونه این نگاشت‌ها را در تم اصلی ارائه بررسی و تغییر داده و تأیید کنید که تغییرات پس از یک چرخه ذخیره‑بارگذاری حفظ می‌شوند.

## **درک برچسب‌های اسکریپت**

روش‌های قلم اسکریپت از زیر برچسب‌های چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقادیر رایج شامل:

| برچسب اسکریپت | سیستم نوشتاری |
|---|---|
| `Cyrl` | سیریلیک |
| `Arab` | عربی |
| `Hans` | چینی ساده |
| `Jpan` | ژاپنی |
| `Geor` | گرجی |
| `Thaa` | ثانا |

این نگاشت‌ها به طرح قلم تم تعلق دارند، نه به بخش‌های متنی جداگانه. یک ارائه می‌تواند نگاشت‌های متفاوتی برای مجموعه‌های اصلی و فرعی داشته باشد و ممکن است برای برخی اسکریپت‌ها نگاشت نداشته باشد.

## **دسترسی و بررسی نگاشت‌های فونت اسکریپت**

از [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) برای دسترسی به تم سطح ارائه استفاده کنید. ویژگی‌های [FontScheme.Major](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/major/) و [FontScheme.Minor](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/minor/) دو مجموعه [IFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/ifonts/) را برمی‌گردانند.

برای دریافت تمام نگاشت‌ها از یک مجموعه، از [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/fa/net/aspose.slides/fonts/getscriptfontmap/) فراخوانی کنید. برای جستجوی یک سیستم نوشتاری خاص، با برچسب اسکریپت مربوطه، [IFonts.GetScriptFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fonts/getscriptfont/) را صدا بزنید. `GetScriptFont` وقتی مجموعه درخواست‌شده نگاشت مورد نظر را تعریف نکرده باشد `null` برمی‌گرداند.

## **تغییر نگاشت‌ها و تأیید ماندگاری**

از [IFonts.SetScriptFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fonts/setscriptfont/) برای ایجاد یک نگاشت یا جایگزینی خانواده قلم فعلی استفاده کنید. برای حذف یک نگاشت، از [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fonts/removescriptfont/) بهره ببرید.

مثال زیر به‌صورت سرتاسری تمام نگاشت‌های اصلی و فرعی موجود را می‌خواند، قلم اصلی ژاپنی را جستجو می‌کند، قلم اصلی سیریلیک را تغییر می‌دهد، نگاشت ثانا در مجموعه فرعی را حذف می‌کند، ارائه را ذخیره می‌کند و دوباره باز می‌کند تا هر دو تغییر را تأیید کند. برای اینکه قدم حذف مستقل از تم اولیه باشد، مثال ابتدا یک نگاشت ثانا ایجاد می‌کند فقط زمانی که قبلاً تعریف نشده باشد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

تأیید با همان رفتار `null` یک جستجوی معمولی مشابه است: پس از ذخیره‌سازی حذف، `GetScriptFont("Thaa")` برای مجموعه فرعی `null` برمی‌گرداند.

## **تمایز نگاشت‌های تم از سایر تنظیمات قلم**

نگاشت‌های تم مخصوص اسکریپت در انتخاب قلم مشارکت می‌کنند، اما مسأله‌ای متفاوت از قالب‌بندی مستقیم متن، جایگزینی و فالبک حل می‌نمایند:

| مکانیزم | هدف | اثر تغییر نگاشت تم |
|---|---|---|
| نگاشت قلم تم مخصوص اسکریپت | انتخاب قلم تم اصلی یا فرعی برای یک سیستم نوشتاری. | متنی که هنوز از قلم تم مربوطه استفاده می‌کند می‌تواند به خانواده قلم جدید منتقل شود. |
| قلم اختصاصی به یک بخش متنی | ثابت کردن خانواده قلم درخواست‌شده برای آن بخش به جای تکیه بر تم. | ممکن است بخش تغییر نکند چون قالب‌بندی مستقیم آن، انتخاب تم را نادیده می‌گیرد. |
| جایگزینی قلم | جایگزین کردن قلم درخواست‌شده وقتی قلم موجود نیست یا قاعده جایگزینی اعمال می‌شود. | پس از درخواست قلم رخ می‌دهد؛ نگاشت اسکریپت تم را بازتعریف نمی‌کند. |
| فالبک قلم | فراهم کردن گلیف‌هایی که قلم انتخاب‌شده شامل آن‌ها نیست، معمولاً برای محدوده‌های یونیکد خاص. | پوشش گلیف‌های گمشده را پر می‌کند؛ نگاشت تم ذخیره‌شده را تغییر نمی‌دهد. |

برای اطلاعات بیشتر دربارهٔ دو مکانیزم آخر، به [Font Substitution](/slides/fa/net/font-substitution/) و [Fallback Fonts](/slides/fa/net/fallback-font/) مراجعه کنید.

تغییر یک نگاشت در [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) فقط بر محتوایی که قالب‌بندی مؤثر آن هنوز به آن تم وابسته است تأثیر می‌گذارد. متن می‌تواند به‌جای آن، یک لغو تم از مستر، لایه یا اسلاید دریافت کند یا از قلم اختصاصی استفاده کند. در زمانیکه نتیجه قابل مشاهده با نگاشت سطح ارائه هم‌خوانی ندارد، سطوح مذکور را بررسی کنید.

## **قلم‌های نگاشته‌شده را در دسترس قرار دهید و نتیجه را اعتبارسنجی کنید**

یک نگاشت اسکریپت فقط نام خانواده قلم را ذخیره می‌کند؛ فونت مربوطه را نصب یا بارگذاری نمی‌کند. برای رندر یکدست و خروجی، هر قلم نگاشته‌شده باید در محیط نصب شده باشد یا از طریق منبع سفارشی به Aspose.Slides ارائه شود، مانند [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) یا [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/). گزینه‌های بارگذاری موجود را در [Custom Fonts](/slides/fa/net/custom-font/) ببینید.

تأیید نگاشت ذخیره‌شده فقط این را ثابت می‌کند که تعریف تم حفظ شده است. این نشان نمی‌دهد که قلم در دسترس است، شامل تمام گلیف‌های مورد نیاز است یا طرح مورد نظر را تولید می‌کند. برای هر سیستم نوشتاری ضروری، متن نمایشی را به تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این کار قلم‌های گمشده، پوشش ناتمام گلیف، رفتار فالبک و تغییرات طرح را پیش از توزیع ارائه شناسایی می‌کند. برای مثال‌های رندر و خروجی، به [Convert PowerPoint Presentations](/slides/fa/net/convert-powerpoint/) مراجعه کنید.

## **سؤال‌های متداول**

**`GetScriptFont` هنگام عدم وجود نگاشت برای یک اسکریپت چه مقدار را برمی‌گرداند؟**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fonts/getscriptfont/) وقتی نگاشت اسکریپت درخواست‌شده در مجموعهٔ اصلی یا فرعی تعریف نشده باشد `null` برمی‌گرداند.

**آیا `SetScriptFont` زمانی که اسکریپت از قبل وجود دارد، نگاشت دوم ایجاد می‌کند؟**

خیر. [IFonts.SetScriptFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fonts/setscriptfont/) هنگام نبود نگاشت، آن را ایجاد می‌کند و وقتی همان برچسب اسکریپت قبلاً موجود باشد، خانواده قلم نگاشت‌شده را جایگزین می‌کند.

**چرا تغییر نگاشت تم باعث تغییر برخی متن‌ها نشد؟**

متن ممکن است قلم اختصاصی داشته باشد، از تم متفاوتی به‌وسیلهٔ یک لغو دریافت کند یا در زمان رندر توسط جایگزینی یا فالبک تحت تأثیر قرار گیرد. نگاشت اسکریپت سطح ارائه فقط متنی را کنترل می‌کند که قالب‌بندی مؤثر آن هنوز به آن مجموعهٔ قلم تم ارجاع می‌دهد.

**آیا ذخیره و بازگشایی کافی است تا خروجی چند زبانه را اعتبارسنجی کنیم؟**

خیر. بازگشایی فقط ماندگاری داده‌های تم را تأیید می‌کند. همچنین باید متن نمایشی هر سیستم نوشتاری مورد نیاز را رندر کنید تا اطمینان حاصل شود قلم‌های نگاشته‌شده در دسترس هستند و شامل گلیف‌های لازم می‌باشند.