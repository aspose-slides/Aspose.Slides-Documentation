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
- تعویض قلم
- قانون جایگزینی
- قانون تعویض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین‌شده را در Aspose.Slides برای .NET هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **بررسی اجمالی**

جایگزینی قلم به Aspose.Slides امکان می‌دهد تا یک قلم موجود را به‌جای قلمی که هنگام رندر یا تبدیل ارائه قابل دسترسی نیست، استفاده کند. این جایگزینی بر خروجی رندر شده تأثیر می‌گذارد؛ اما قلم اختصاص داده شده به محتوای ارائه را تغییر نمی‌دهد.

می‌توانید قلمی را که هنگام عدم دسترسی به قلم خاصی باید استفاده شود، تعریف کنید و جایگزینی‌هایی که Aspose.Slides در طول رندر انجام می‌دهد را بررسی کنید. این کار به حفظ سازگاری خروجی در محیط‌های مختلف با قلم‌های نصب شده متفاوت کمک می‌کند.

## **دریافت جایگزینی‌های قلم**

از روش [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) برای تعیین اینکه کدام قلم‌ها هنگام رندر ارائه جایگزین می‌شوند، استفاده کنید. این روش اشیاء [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

مثال زیر به زبان C# تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **دریافت جایگزینی‌های قلم برای اسلایدهای انتخابی**

از بارگذاری [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) با آرگومان `int[] slides` برای بررسی فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص استفاده کنید. این گزینه زمانی مفید است که بخواهید بخشی از ارائه را رندر یا صادرات کنید، یک ارائه بزرگ را به‌صورت تدریجی بررسی کنید، اسلایدهایی که به قلم‌های غیرقابل دسترس وابسته هستند را پیدا کنید، بسته قلمی حداقلی برای سرور یا کانتینر تهیه کنید یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل ایندکس‌های اسلاید به‌صورت یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، ایندکس‌گذار مجموعه [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) صفرپایه است، بنابراین همان اسلاید به صورت `presentation.Slides[0]` قابل دسترسی است. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا از خطاهای یک‑پایه‑جای‑یک جلوگیری کنید.

این بارگذاری را از طریق ویژگی [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) صدا بزنید. این ویژگی تنها جایگزینی‌های تعیین‌شده هنگام رندر اسلایدهای انتخابی را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) است که نام‌های قلم اصلی و جایگزین را شامل می‌شود. نتیجه محیط قلمی فعلی و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/net/custom-font/) را منعکس می‌کند. قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) خروجی رندر شده را تغییر می‌دهند اما در نتیجه بازگشتی نشان داده نمی‌شوند.

یک جایگزینی ممکن است توسط بیش از یک اسلاید انتخابی مورد نیاز باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش پیش‌پروازی، نتایج را یک‌بارگی کنید. مثال زیر هر جایگزینی بازگشتی را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلم منحصربه‌فرد ایجاد می‌کند:

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

رابط [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) هر دو بارگذاری را فراهم می‌کند. یکی را بسته به دامنه عملیات رندر انتخاب کنید:

| بارگذاری | زمان استفاده |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) بدون آرگومان | برای دریافت جایگزینی‌های تمام ارائه. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) با `int[] slides` | برای دریافت جایگزینی‌های یک بازهٔ انتخابی، بررسی تدریجی یا صادرات جزئی. |

## **تنظیم قوانین جایگزینی قلم**

برای تعیین قلمی که Aspose.Slides باید هنگام عدم دسترس بودن قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و جایگزین را ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) بسازید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را به ویژگی [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال زیر به زبان C# قلم `Arial` را به‌جای `SomeRareFont` زمانی که `SomeRareFont` در دسترس نیست، جایگزین می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

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
برای تغییر بدون شرط قلم‌های استفاده‌شده در سراسر یک ارائه، به بخش [Font Replacement](/slides/fa/net/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم بخشی از فرآیند استاندارد انتخاب قلم هستند که هنگام رندر و تبدیل مورد استفاده قرار می‌گیرند. آنها برای متن عادی کار می‌کنند وقتی Aspose.Slides می‌تواند قلم غیرقابل دسترس را با قلم موجود مشخص‌شده در قانون جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر یک معادله از **Cambria Math** استفاده کند، Aspose.Slides ممکن است برای محاسبه و رندر چیدمان معادله به همان قلم دقیقاً نیاز داشته باشد. قانونی که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین کند، نمی‌تواند **Cambria Math** را برای این هدف جایگزین کند و رندر ممکن است همچنان گزارش دهد که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌صورت [قلم خارجی](/slides/fa/net/custom-font/) بارگذاری کنید.

این محدودیت تنها بر چیدمان معادله اعمال می‌شود. قوانین جایگزینی ذکر شده در بالا همچنان برای متن عادی ارائه معتبر هستند.

## **سئوالات متداول**

**تفاوت جایگزینی قلم با جایگزینی قلم چیست؟**

[Font replacement](/slides/fa/net/font-replacement/) به‌طور عمدی یک قلم را در سراسر ارائه با قلم دیگری عوض می‌کند. جایگزینی قلم، قلمی را برای خروجی رندر شده انتخاب می‌کند زمانی که شرط پیکربندی‌شده برقرار باشد، مانند عدم دسترسی به قلم اصلی.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنبالهٔ انتخاب قلم](/slides/fa/net/font-selection-sequence/) هنگام رندر و تبدیل شرکت می‌کنند. با `WhenInaccessible`، قانون تنها زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و هیچ قانون جایگزینی پیکربندی نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری شود؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری](/slides/fa/net/custom-font/) کنید تا Aspose.Slides آنها را هنگام رندر و تبدیل استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. مسئولیت تهیه قلم‌ها و رعایت مجوزهای آنها بر عهدهٔ شماست.

**آیا نتایج جایگزینی بین Windows، Linux و macOS متفاوت است؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم در هر سیستم‌عامل متفاوت است، بنابراین قلمی که در یک ماشین موجود است ممکن است در دستگاه دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای ثابت نگه دارم؟**

از همان فایل‌ها و نسخه‌های قلم در همهٔ ماشین‌ها یا کانتینرها استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری](/slides/fa/net/custom-font/) کنید و در صورت اجازهٔ مجوز، [قلم‌ها را تعبیه](/slides/fa/net/embedded-font/) کنید. همچنین می‌توانید قبل از صادرات، [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) را فراخوانی کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.