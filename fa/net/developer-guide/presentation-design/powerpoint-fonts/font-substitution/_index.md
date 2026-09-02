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
- تعویض قلم
- جایگزینی قلم
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین شده را در Aspose.Slides برای .NET هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **بررسی کلی**

جایگزینی قلم به Aspose.Slides اجازه می‌دهد که هنگام عدم دسترسی به یک قلم، از قلم موجود دیگری استفاده کند. این جایگزینی بر خروجی رندر شده تأثیر می‌گذارد؛ اما قلم اختصاص‌یافته به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید قلمی را که وقتی قلم خاصی در دسترس نیست استفاده شود، تعریف کنید و همچنین می‌توانید جایگزینی‌هایی را که Aspose.Slides در طول رندر انجام می‌دهد، بررسی کنید. این کار به حفظ سازگاری خروجی در محیط‌هایی با قلم‌های نصب‌شده متفاوت کمک می‌کند.

## **دریافت جایگزینی‌های قلم**

از روش [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getsubstitutions/) برای تعیین اینکه کدام قلم‌ها هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این روش اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

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

از بارگذاری [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getsubstitutions/) با آرگومان `int[] slides` استفاده کنید تا تنها جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص را بررسی کنید. این مورد زمانی مفید است که بخواهید بخشی از یک ارائه را رندر یا خروجی بگیرید، یک ارائه بزرگ را به‌صورت تدریجی بررسی کنید، اسلایدهایی که به قلم‌های غیرقابل دسترس وابسته‌اند را پیدا کنید، بسته قلمی حداقلی برای سرور یا کانتینر آماده کنید یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل ایندکس‌های اسلاید یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، ایندکس‌گذار مجموعه [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) پایه صفر دارد، بنابراین همان اسلاید به صورت `presentation.Slides[0]` دسترسی پیدا می‌کند. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطای off-by-one جلوگیری کنید.

بارگذاری را از طریق ویژگی [Presentation.FontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/fontsmanager/) صدا بزنید. این فقط جایگزینی‌هایی را که در حین رندر اسلایدهای انتخاب‌شده تعیین می‌شوند، برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsubstitutioninfo/) است که شامل نام‌های قلم اصلی و جایگزین می‌باشد. نتیجه بازتاب‌دهنده محیط قلم فعلی، قوانین fallback پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsubstrulecollection/)، و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/net/custom-font/) است.

همین جایگزینی می‌تواند توسط بیش از یک اسلاید انتخاب‌شده نیاز باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش پیش‌پرواز، نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی بازگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلم منحصر به‌فرد ایجاد می‌کند:

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

رابط [IFontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/) هر دو بارگذاری را فراهم می‌کند. یکی را بر اساس دامنه عملیات رندر انتخاب کنید:

| بارگذاری | زمان استفاده |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | به جایگزینی‌ها برای کل ارائه نیاز دارید. |
| [GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | به جایگزینی‌ها برای بازه‌ای انتخابی، بررسی تدریجی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید زمانی که قلم منبع در دسترس نیست استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و قلم جایگزین را ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsubstcondition/) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را به ویژگی [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/fontsubstrulelist/) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال C# زیر هنگام عدم دسترسی به `SomeRareFont`، `Arial` را به‌جای آن جایگزین می‌کند و سپس اولین اسلاید را برای تأیید نتیجه رندر می‌کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

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

For an unconditional change to the fonts used throughout a presentation, see [Font Replacement](/slides/fa/net/font-replacement/).

{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم بخشی از فرآیند استاندارد انتخاب قلم هستند که در حین رندر و تبدیل استفاده می‌شود. آن‌ها برای متن معمولی کار می‌کنند زمانی که Aspose.Slides می‌تواند قلم غیرقابل دسترس را با قلم موجودی که توسط یک قانون مشخص شده جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر یک معادله از **Cambria Math** استفاده کند، ممکن است Aspose.Slides به آن قلم دقیق برای محاسبه و رندر طرح‌بندی معادله نیاز داشته باشد. قانون جایگزینی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را برای این منظور جایگزین کند و ممکن است رندر همچنان گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را برای Aspose.Slides در دسترس بگذارید. آن را در سیستم‌عامل نصب کنید یا به‌صورت یک [قلم خارجی](/slides/fa/net/custom-font/) بارگذاری کنید.

این محدودیت بر روی طرح‌بندی معادله اعمال می‌شود. قوانین جایگزینی که در بالا توضیح داده شد هنوز برای متن معمولی ارائه کاربرد دارند.

## **سؤالات متداول**

**تفاوت جایگزینی قلم و جایگزینی قلم (font replacement) چیست؟**

[Font replacement](/slides/fa/net/font-replacement/) به‌صورت عمدی یک قلم را در کل ارائه با قلم دیگری عوض می‌کند. جایگزینی قلم قلمی را برای خروجی رندر شده زمانی که شرط پیکربندی‌شده برآورده شود (مانند عدم دسترسی به قلم اصلی) انتخاب می‌کند.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنباله انتخاب قلم](/slides/fa/net/font-selection-sequence/) هنگام رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، یک قانون تنها زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**هنگامی که قلم گم شود و هیچ قانون جایگزینی‌ای پیکربندی نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری کنم؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری کنید](/slides/fa/net/custom-font/) تا Aspose.Slides در حین رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول تأمین قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی بین Windows، Linux و macOS می‌تواند متفاوت باشد؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم در هر سیستم‌عامل متفاوت است، بنابراین قلمی که در یک ماشین موجود است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای سازگار کنم؟**

از همان فایل‌ها و نسخه‌های قلم در هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری کنید](/slides/fa/net/custom-font/)، و هنگامی که مجوز اجازه دهد [قلم‌ها را جاسازی کنید](/slides/fa/net/embedded-font/). همچنین می‌توانید پیش از خروجی‌گیری [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getsubstitutions/) را فراخوانی کنید تا جایگزینی‌های ناخواسته را شناسایی کنید.