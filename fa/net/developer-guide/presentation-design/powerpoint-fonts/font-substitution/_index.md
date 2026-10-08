---
title: پیکربندی جایگزینی قلم در ارائه‌ها در .NET
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/net/font-substitution/
keywords:
- قلم
- قلم جایگزین
- جایگزینی قلم
- جایگزینی قلم
- جایگزینی قلم
- قانون جایگزینی
- قانون جایگزینی
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین شده را در Aspose.Slides برای .NET هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **مرور کلی**

جایگزینی قلم به Aspose.Slides امکان می‌دهد تا در صورت عدم دسترسی به یک قلم هنگام رندر یا تبدیل ارائه، از یک قلم موجود استفاده کند. این جایگزینی فقط بر خروجی رندر شده تأثیر می‌گذارد؛ فونتی که به محتوای ارائه اختصاص یافته است را تغییر نمی‌دهد.

می‌توانید قلم مورد استفاده را زمانی که قلم خاصی در دسترس نیست تعریف کنید و می‌توانید جایگزین‌های انجام‌شده توسط Aspose.Slides در هنگام رندر را بررسی کنید. این کار به حفظ سازگاری خروجی در محیط‌های مختلف با قلم‌های نصب‌شده متفاوت کمک می‌کند.

اگر قلم در دسترس باشد اما نسخه ضخیم اختصاصی نداشته باشد، به [مدیریت قلم‌ها بدون خط ضخیم اختصاصی](/slides/fa/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) مراجعه کنید. آن بخش توضیح می‌دهد چگونه متن تحت تأثیر را در هنگام استخراج PDF رستر کنید و پیامدهای آن برای انتخاب متن، جستجو و مقیاس‌گذاری.

## **دریافت جایگزینی‌های قلم**

از متد [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) برای تعیین اینکه کدام قلم‌ها هنگام رندر ارائه جایگزین می‌شوند استفاده کنید. این متد اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

مثال C# زیر تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخاب‌شده**

از بارگذاری [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) با آرگومان `int[] slides` برای بررسی تنها جایگزینی‌های لازم جهت رندر اسلایدهای خاص استفاده کنید. این روش زمانی مفید است که بخواهید بخشی از یک ارائه را رندر یا صادر کنید، یک ارائه بزرگ را به صورت افزایشی بررسی کنید، اسلایدهایی که به قلم‌های در دسترس نیستند را پیدا کنید، یک بسته قلم حداقل برای سرور یا کانتینر آماده کنید، یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل ایندکس‌های اسلاید به صورت یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، ایندکسر مجموعه [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) صفرپایه است، بنابراین همان اسلاید به صورت `presentation.Slides[0]` دسترسی پیدا می‌شود. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطاهای یک‌واحدی جلوگیری کنید.

از این بارگذاری از طریق ویژگی [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) صدا بزنید. این ویژگی فقط جایگزینی‌هایی را که در حین رندر اسلایدهای انتخاب‌شده تعیین شده‌اند برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) است که نام‌های قلم اصلی و جایگزین را شامل می‌شود. نتیجه محیط قلم فعلی و [قلم‌های بارگذاری‌شده به صورت خارجی](/slides/fa/net/custom-font/) را بازتاب می‌دهد. قوانین جایگزینی که در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) ذخیره شده‌اند خروجی رندر شده را تغییر می‌دهند اما در نتیجه نشان داده نمی‌شوند.

یک جایگزینی ممکن است برای بیش از یک اسلاید انتخاب‌شده مورد نیاز باشد. هنگام ایجاد فهرست قلم یا گزارش پیش‌پرواز، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی بازگشتی را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلم منحصر به‌فرد ایجاد می‌نماید:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

رابط [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) هر دو بارگذاری را فراهم می‌کند. بسته به دامنه عملیات رندر، یکی را انتخاب کنید:

| بارگذاری | زمان استفاده |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) بدون آرگومان | زمانی که برای کل ارائه به جایگزینی‌ها نیاز دارید. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) با `int[] slides` | زمانی که برای بازهٔ انتخاب‌شده، بررسی افزایشی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلم‌ای که Aspose.Slides باید هنگام عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعاریف قلم برای قلم منبع و جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را به ویژگی [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال C# زیر `Arial` را به‌جای `SomeRareFont` هنگام عدم دسترسی به `SomeRareFont` جایگزین می‌کند و سپس اولین اسلاید را رندر می‌نماید تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
برای تغییر بدون شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به [جایگزینی قلم](/slides/fa/net/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم جزئی از فرآیند استاندارد انتخاب قلم است که در حین رندر و تبدیل استفاده می‌شود. این قوانین برای متن عادی کار می‌کنند وقتی Aspose.Slides می‌تواند قلم غیرقابل دسترس را با قلم موجودی که توسط قانون مشخص شده‌اند، جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر معادله‌ای از **Cambria Math** استفاده کند، ممکن است Aspose.Slides برای محاسبه و رندر چیدمان معادله به همان قلم دقیق نیاز داشته باشد. قاعده‌ای که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور جایگزین کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/net/custom-font/) بارگذاری کنید.

این محدودیت به چیدمان معادله اعمال می‌شود. قوانین جایگزینی توضیح داده شده در بالا همچنان برای متن عادی ارائه معتبر هستند.

## **پرسش‌های متداول**

**تفاوت بین جایگزینی قلم و جایگزینی قلم چیست؟**

[جایگزینی قلم](/slides/fa/net/font-replacement/) به‌صورت عمدی یک قلم را در سراسر ارائه با قلم دیگری تعویض می‌کند. جایگزینی قلم یک قلم را برای خروجی رندر شده انتخاب می‌کند وقتی شرط پیکربندی‌شده برآورده شود، مانند زمانی که قلم اصلی در دسترس نباشد.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در [دنباله انتخاب قلم](/slides/fa/net/font-selection-sequence/) در حین رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، یک قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**وقتی قلم موجود نیست و هیچ قانونی برای جایگزینی پیکربندی نشده است چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه بستگی به قلم‌های موجود در محیط زمان اجرا دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری کنید](/slides/fa/net/custom-font/) تا Aspose.Slides بتواند در حین رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول فراهم کردن قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی می‌توانند بین Windows، Linux و macOS متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم در هر سیستم‌عامل متفاوت است، بنابراین قلمی که در یک دستگاه در دسترس است ممکن است در دستگاه دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای یک‌دست کنم؟**

از یک‌سان بودن فایل‌ها و نسخه‌های قلم در هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری کنید](/slides/fa/net/custom-font/) و هنگام اجازه‌نامه، [قلم‌ها را تعبیه کنید](/slides/fa/net/embedded-font/). همچنین می‌توانید پیش از خروجی‌گیری [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) را صدا بزنید تا جایگزینی‌های غیرمنتظره شناسایی شوند.