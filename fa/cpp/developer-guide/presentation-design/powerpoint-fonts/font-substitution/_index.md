---
title: "پیکربندی جایگزینی قلم در ارائه‌ها با C++"
linktitle: "جایگزینی قلم"
type: docs
weight: 70
url: /fa/cpp/font-substitution/
keywords:
- "قلم"
- "قلم جایگزین"
- "جایگزینی قلم"
- "جایگزینی قلم"
- "جایگزینی قلم"
- "قانون جایگزینی"
- "قانون جایگزینی"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "قوانین جایگزینی قلم را پیکربندی کنید و قلم‌های جایگزین‌شده را در Aspose.Slides برای C++ هنگام رندر یا تبدیل ارائه‌های PowerPoint و OpenDocument بررسی کنید."
---
## **نمای کلی**

جایگزینی قلم به Aspose.Slides امکان استفاده از یک قلم موجود به جای قلم‌ای که در هنگام رندر یا تبدیل ارائه قابل دسترسی نیست را می‌دهد. این جایگزینی فقط بر خروجی رندر شده تأثیر می‌گذارد؛ قلم اختصاص‌یافته به محتوای ارائه تغییر نمی‌کند.

می‌توانید قلمی را که در صورت عدم دسترسی به قلم خاصی استفاده شود، تعریف کنید و جایگزینی‌هایی که Aspose.Slides در طول رندر اعمال می‌کند را بررسی کنید. این کار به سازگاری خروجی در محیط‌های دارای قلم‌های نصب‌شده متفاوت کمک می‌کند.

اگر قلمی موجود است اما وزن ‎Bold اختصاصی ندارد، به [مدیریت قلم‌ها بدون نوع ‎Bold اختصاصی](/slides/fa/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) مراجعه کنید. آن بخش توضیح می‌دهد چگونه متن تحت تأثیر را هنگام خروجی PDF رستر کنید و پیامدهای انتخاب متن، جستجو و مقیاس‌گذاری را بیان می‌کند.

## **دریافت جایگزینی قلم‌ها**

از متد [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) برای تعیین قلم‌هایی که هنگام رندر ارائه جایگزین می‌شوند استفاده کنید. این متد اشیای [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) را برمی‌گرداند که نام‌های قلم اصلی و جایگزین را شناسایی می‌کند.

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

## **دریافت جایگزینی قلم‌ها برای اسلایدهای انتخاب‌شده**

از بارگذاری [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) که آرگومان `System::ArrayPtr<int32_t> slides` می‌گیرد، برای بررسی فقط جایگزینی‌های لازم برای رندر اسلایدهای خاص استفاده کنید. این کار هنگام رندر یا خروجی‌گیری بخشی از یک ارائه، بررسی افزایشی یک ارائه بزرگ، پیدا کردن اسلایدهایی که به قلم‌های غیرقابل دسترس وابسته‌اند، تهیه بسته قلمی کمینه برای سرور یا کانتینر، یا تشخیص تفاوت‌های رندر بدون پردازش اسلایدهای نامرتبط مفید است.

آرایه `slides` شامل شماره‌ اسلایدهای یک‌پایه است: `1` اولین اسلاید را شناسایی می‌کند. در مقابل، متد [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) از اندیس صفرپایه استفاده می‌کند، بنابراین همان اسلاید به صورت `presentation->get_Slide(0)` دسترسی می‌یابد. هنگام ساخت آرایه این اختلاف را در نظر بگیرید تا از خطای یک‑واحد اختلاف جلوگیری کنید.

این بارگذاری را از طریق متد [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) فراخوانی کنید. این متد فقط جایگزینی‌های تعیین‌شده در طول رندر اسلایدهای انتخاب‌شده را برمی‌گرداند. هر نتیجه یک شیء [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) حاوی نام‌های قلم اصلی و جایگزین است. نتیجه منعکس‌کننده محیط قلمی جاری، قوانین فالبک پیکربندی‌شده، قوانین جایگزینی ذخیره‌شده در یک [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/)، و [قلم‌های بارگذاری‌شده به‌صورت خارجی](/slides/fa/cpp/custom-font/) می‌باشد.

یک جایگزینی می‌تواند توسط بیش از یک اسلاید انتخاب‌شده لازم باشد. هنگام ایجاد فهرست موجودی قلم یا گزارش پیش‌پرواز، نتایج را یکتا کنید. مثال زیر هر جایگزینی بازگشتی را گزارش می‌کند و سپس فهرست مرتب‌شده‌ای از نگاشت‌های قلمی یکتا ایجاد می‌کند:

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

رابط [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) هر دو بارگذاری را فراهم می‌کند. یکی را بر اساس دامنه عملیات رندر انتخاب کنید:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | شما به جایگزینی‌ها برای تمام ارائه نیاز دارید. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | شما به جایگزینی‌ها برای یک بازه انتخابی، بررسی افزایشی یا خروجی‌گیری جزئی نیاز دارید. |

## **تنظیم قوانین جایگزینی قلم**

برای مشخص کردن قلمی که Aspose.Slides باید در صورت عدم دسترسی به قلم منبع استفاده کند:

1. ارائه را بارگذاری کنید.
2. تعریف‌های قلم برای قلم منبع و جایگزین ایجاد کنید.
3. یک [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) با شرط [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/) ایجاد کنید.
4. قانون را به یک [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/) اضافه کنید.
5. مجموعه را با استفاده از متد [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) اختصاص دهید.
6. ارائه را رندر یا تبدیل کنید.

مثال C++ زیر، هنگام عدم دسترسی به `SomeRareFont`، `Arial` را به‌جای آن استفاده می‌کند و سپس اولین اسلاید را رندر می‌کند تا نتیجه را تأیید کند. قلم جایگزین باید برای Aspose.Slides در دسترس باشد.

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
برای تغییر بی‌قید و شرط تمام قلم‌های استفاده‌شده در یک ارائه، به [Font Replacement](/slides/fa/cpp/font-replacement/) مراجعه کنید.
{{% /alert %}}

## **محدودیت‌ها برای قلم‌های معادلات ریاضی**

قوانین جایگزینی قلم جزئی از فرآیند استاندارد انتخاب قلم در طول رندر و تبدیل هستند. آن‌ها برای متن عادی کار می‌کنند هنگامی که Aspose.Slides می‌تواند یک قلم غیرقابل دسترس را با قلم موجود تعریف‌شده توسط قانون جایگزین کند.

معادلات Office Math نیاز اضافی دارند. اگر معادله‌ای از **Cambria Math** استفاده کند، Aspose.Slides ممکن است به دقیقاً همان قلم برای محاسبه و رندر چیدمان معادله نیاز داشته باشد. قانونی که یک قلم ریاضی دیگر مانند **STIX Two Math** را جایگزین می‌کند، نمی‌تواند **Cambria Math** را در این منظور جایگزین کند و رندر ممکن است هنوز اعلام کند که **Cambria Math** لازم است.

برای رندر یا تبدیل چنین ارائه‌ای، **Cambria Math** را در دسترس Aspose.Slides قرار دهید. آن را در سیستم‌عامل نصب کنید یا به‌عنوان یک [external font](/slides/fa/cpp/custom-font/) بارگذاری کنید.

این محدودیت فقط به چیدمان معادله مربوط می‌شود. قوانین جایگزینی که در بالا توضیح داده شد برای متن معمولی ارائه همچنان معتبر است.

## **سوالات متداول**

**تفاوت جایگزینی قلم و تعویض قلم چیست؟**

[Font replacement](/slides/fa/cpp/font-replacement/) به‌صورت عمدی یک قلم را در سراسر ارائه به قلم دیگری تغییر می‌دهد. جایگزینی قلم، قلمی برای خروجی رندر شده انتخاب می‌کند وقتی شرط پیکربندی‌شده برآورده شود، مثلاً وقتی قلم اصلی در دسترس نباشد.

**قوانین جایگزینی کی اعمال می‌شوند؟**

قوانین در [دنباله انتخاب قلم](/slides/fa/cpp/font-selection-sequence/) در طول رندر و تبدیل مشارکت می‌کنند. با `WhenInaccessible`، قانون فقط زمانی استفاده می‌شود که Aspose.Slides نتواند به قلم منبع دسترسی پیدا کند.

**اگر قلمی موجود نباشد و قانون جایگزینی پیکربندی نشده باشد چه می‌شود؟**

Aspose.Slides نزدیک‌ترین قلم موجود را بر اساس فرآیند انتخاب قلم خود انتخاب می‌کند. نتیجه به قلم‌های موجود در محیط زمان اجرا بستگی دارد.

**آیا می‌توانم قلم‌های خارجی را بارگذاری کنم تا از جایگزینی جلوگیری شود؟**

بله. می‌توانید [قلم‌های خارجی را بارگذاری کنید](/slides/fa/cpp/custom-font/) تا Aspose.Slides در طول رندر و تبدیل از آن‌ها استفاده کند.

**آیا Aspose قلم‌ها را همراه کتابخانه توزیع می‌کند؟**

خیر. مسئولیت فراهم کردن قلم‌ها و رعایت مجوزهای آن‌ها بر عهده شماست.

**آیا نتایج جایگزینی می‌توانند بین Windows، Linux و macOS متفاوت باشند؟**

بله. قلم‌های نصب‌شده و مسیرهای جستجوی قلم در هر سیستم‌عامل متفاوت است، بنابراین قلمی که در یک ماشین در دسترس است ممکن است در ماشین دیگر نیاز به جایگزینی داشته باشد.

**چگونه می‌توانم انتخاب قلم را در تبدیل‌های گروهی سازگار کنم؟**

از همان فایل‌ها و نسخه‌های قلم در هر ماشین یا کانتینر استفاده کنید، [قلم‌های خارجی مورد نیاز را بارگذاری کنید](/slides/fa/cpp/custom-font/)، و هنگام اجازه‌پذیری مجوزها [قلم‌ها را جاسازی کنید](/slides/fa/cpp/embedded-font/). همچنین می‌توانید قبل از خروجی از [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) فراخوانی کنید تا جایگزینی‌های غیرمنتظره را شناسایی کنید.