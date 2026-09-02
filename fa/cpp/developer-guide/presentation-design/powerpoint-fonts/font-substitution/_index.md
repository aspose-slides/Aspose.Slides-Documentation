---
title: پیکربندی جایگزینی قلم در ارائه‌ها در C++
linktitle: جایگزینی قلم
type: docs
weight: 70
url: /fa/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "قواعد جایگزینی قلم را پیکربندی کرده و قلم‌های جایگزین شده را در Aspose.Slides برای C++ هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **مرور کلی**

جایگزینی قلم (Font substitution) به Aspose.Slides امکان می‌دهد تا در هنگام رندر یا تبدیل یک ارائه، از یک قلم موجود به جای قلم‌ای که در دسترس نیست استفاده کند. این جایگزینی فقط بر خروجی رندر شده تأثیر می‌گذارد؛ قلم اختصاص داده‌شده به محتوای ارائه تغییر نمی‌کند.

می‌توانید قلم مورد استفاده را زمانی که قلم خاصی در دسترس نیست تعریف کنید و جایگزینی‌هایی را که Aspose.Slides هنگام رندر انجام می‌دهد بررسی کنید. این کار به حفظ خروجی یکسان در محیط‌های مختلف با فونت‌های نصب شده متفاوت کمک می‌کند.

## **دریافت جایگزینی قلم‌ها**

از روش [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getsubstitutions/) برای تعیین این که هنگام رندر ارائه چه قلم‌هایی جایگزین می‌شوند، استفاده کنید. این روش اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

مثال C++ زیر تمام جایگزینی‌های قلم برای یک ارائه را فهرست می‌کند:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **دریافت جایگزینی قلم‌ها برای اسلایدهای منتخب**

از overload متد [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getsubstitutions/) با آرگومان `System::ArrayPtr<int32_t> slides` استفاده کنید تا فقط جایگزینی‌های مورد نیاز برای رندر اسلایدهای خاص بررسی شوند. این کار زمانی مفید است که بخواهید بخشی از ارائه را رندر یا خروجی بگیرید، ارائه بزرگ را به‌تدریج بررسی کنید، اسلایدهایی که به قلم‌های در دسترس نیستند را شناسایی کنید، بسته قلمی حداقلی برای سرور یا کانتینر آماده کنید یا اختلافات رندر را بدون پردازش اسلایدهای نامرتبط تشخیص دهید.

آرایه `slides` شامل شماره‌های اسلاید به‌صورت یک‌پایه (یک‌مبنا) است: `1` اولین اسلاید را مشخص می‌کند. در مقابل، متد [Presentation::get_Slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slide/) از ایندکس صفرپایه استفاده می‌کند، بنابراین همان اسلاید با `presentation->get_Slide(0)` دسترسی پیدا می‌کند. هنگام ساخت آرایه این تفاوت را در نظر بگیرید تا خطای یک‑به‑یک ایجاد نشود.

این overload را از طریق متد [Presentation::get_FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_fontsmanager/) فراخوانی کنید. این متد فقط جایگزینی‌هایی را که در رندر اسلایدهای منتخب تعیین شده‌اند برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsubstitutioninfo/) است که نام‌های قلم اصلی و جایگزین را دربردارد. نتیجه بازتاب‌دهنده محیط قلم فعلی، قوانین fall‑back پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsubstrulecollection/)، و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/cpp/custom-font/) است.

یک جایگزینی ممکن است توسط بیش از یک اسلاید منتخب مورد نیاز باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش preflight نتایج را حذف تکرار کنید. مثال زیر هر جایگزینی برگردانده‌شده را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلم یونیک ایجاد می‌نماید:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

رابط [IFontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/) هر دو overload را فراهم می‌کند. یکی را بر اساس حوزه عملیات رندر انتخاب کنید:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getsubstitutions/) بدون آرگومان | به جایگزینی برای کل ارائه نیاز دارید. |
| [GetSubstitutions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getsubstitutions/) با `System::ArrayPtr<int32_t> slides` | به جایگزینی برای یک بازه منتخب، بررسی افزایشی یا خروجی جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای تعیین قلمی که Aspose.Slides باید هنگام عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و قلم جایگزین ایجاد کنید.
3. یک شیء [FontSubstRule](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsubstcondition/) بسازید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) انتساب دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال C++ زیر، زمانی که `SomeRareFont` در دسترس نباشد، `Arial` را به‌جای آن استفاده می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
برای تغییر بدون شرط قلم‌های استفاده‌شده در سرتاسر یک ارائه، به [Font Replacement](/slides/fa/cpp/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌های قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم بخشی از فرآیند استاندارد انتخاب قلم است که در زمان رندر و تبدیل اعمال می‌شود. این قوانین برای متن معمولی کار می‌کنند زمانی که Aspose.Slides بتواند قلم در دسترس را به‌جای قلم غیرقابل دسترسی جایگزین کند.

معادلات Office Math نیاز خاصی دارند. اگر یک معادله از **Cambria Math** استفاده کند، ممکن است Aspose.Slides برای محاسبه و رندر چیدمان معادله به دقیقاً همان قلم نیاز داشته باشد. قاعده‌ای که قلم ریاضی دیگری مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را در این منظور جایگزین کند و رندر ممکن است همچنان اعلام کند که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. این قلم را در سیستم‌عامل نصب کنید یا به‌عنوان یک [قلم خارجی](/slides/fa/cpp/custom-font/) بارگذاری کنید.

این محدودیت فقط در چیدمان معادله اعمال می‌شود. قوانین جایگزینی توصیف‌شده در بالا همچنان برای متن معمولی ارائه معتبر است.

## **سؤالات متداول**

**تفاوت جایگزینی قلم با جایگزینی (replacement) قلم چیست؟**

[Font replacement](/slides/fa/cpp/font-replacement/) به‌صورت عمدی یک قلم را در سرتاسر ارائه با قلم دیگری عوض می‌کند. جایگزینی قلم (font substitution) در خروجی رندر شده یک قلم را زمانی که شرط پیکربندی شده (مانند عدم دسترسی به قلم اصلی) برآورده شود، انتخاب می‌کند.

**قوانین جایگزینی چه زمانی اعمال می‌شوند؟**

قوانین در [دنباله انتخاب قلم](/slides/fa/cpp/font-selection-sequence/) در زمان رندر و تبدیل مشارکت می‌کنند. با شرط `WhenInaccessible`، قانون فقط زمانی به کار می‌رود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و قانون جایگزینی تنظیم نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه بستگی به قلم‌های موجود در محیط زمان اجرا دارد.

**آیا می‌توانم قلم‌های خارجی را برای جلوگیری از جایگزینی بارگذاری کنم؟**

بله. می‌توانید [قلم‌های خارجی](/slides/fa/cpp/custom-font/) را بارگذاری کنید تا Aspose.Slides در زمان رندر و تبدیل از آنها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. شما مسئول فراهم‌آوری قلم‌ها و رعایت مجوزهای آن‌ها هستید.

**آیا نتایج جایگزینی می‌توانند بین Windows، Linux و macOS متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مکان‌های جستجوی قلم در هر سیستم عامل متفاوت است، بنابراین قلمی که در یک ماشین موجود است ممکن است در دیگری نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های دسته‌ای یک‌دست نگه دارم؟**

از همان فایل‌های قلم و نسخه‌ها در هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز](/slides/fa/cpp/custom-font/) را بارگذاری کنید و در صورت امکان، [قلم‌ها را جاسازی](/slides/fa/cpp/embedded-font/) کنید. همچنین می‌توانید پیش از خروجی‌گیری متد [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifontsmanager/getsubstitutions/) را فراخوانی کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.