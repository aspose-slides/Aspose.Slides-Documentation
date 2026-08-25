---
title: مدیریت قلم‌های تم خاص اسکریپت در C++
linktitle: قلم‌های تم خاص اسکریپت
type: docs
weight: 15
url: /fa/cpp/script-specific-font-mappings/
keywords:
- قلم خاص اسکریپت
- نگاشت قلم تم
- ارائه چندزبانه
- سیستم نوشتاری
- قلم سیریلیک
- قلم عربی
- قلم ژاپنی
- قلم گرجی
- قلم ثانا
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "بررسی، افزودن، جایگزینی و حذف نگاشت‌های قلم خاص اسکریپت در تم‌های PowerPoint با Aspose.Slides برای C++."
---
## **نمای کلی**

یک تم ارائه می‌تواند برای سیستم‌های نوشتاری مختلف خانواده‌های قلم متفاوتی انتخاب کند. این امکان باعث می‌شود متن چندزبانه‌ای که همچنان از قلم‌های تم استفاده می‌کند، یک طرح قلم هماهنگ داشته باشد در حالی که برای سیریلیک، عربی، ژاپنی، گرجی، ثانا و سایر خوشنویسی‌ها قلم‌های مناسب به کار رود.

تم دارای اینترفیس [IFontScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ifontscheme/) است که شامل یک مجموعه قلم اصلی (معمولاً برای عناوین) و یک مجموعه قلم فرعی (معمولاً برای متن بدنه) می‌شود. علاوه بر ویژگی‌های قلم‌های لاتین و شرق آسیا، هر دو مجموعه‌نگاشت‌هایی از برچسب‌های سیستم نوشتاری به نام‌های خانواده قلم از طریق اینترفیس [IFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifonts/) ارائه می‌دهند.

این مقاله نشان می‌دهد چگونه این نگاشت‌ها را در تم اصلی ارائه بررسی و اصلاح کنیم و تأیید کنیم که تغییرات پس از ذخیره‑بارگذاری حفظ می‌شوند.

## **درک برچسب‌های اسکریپت**

متدهای قلم اسکریپت از برچسب‌های چهار حرفی BCP 47 برای شناسایی سیستم‌های نوشتاری استفاده می‌کنند. مقادیر رایج شامل:

| برچسب اسکریپت | سیستم نوشتاری |
|---|---|
| `Cyrl` | سیریلیک |
| `Arab` | عربی |
| `Hans` | چینی ساده |
| `Jpan` | ژاپنی |
| `Geor` | گرجی |
| `Thaa` | ثانا |

این نگاشت‌ها به طرح قلم تم تعلق دارند، نه به بخش‌های متن جداگانه. یک ارائه می‌تواند نگاشت‌های متفاوتی برای مجموعه‌های اصلی و فرعی داشته باشد و ممکن است برای برخی اسکریپت‌ها نگاشت تعریف نکند.

## **دسترسی و بررسی نگاشت‌های قلم اسکریپت**

از [Presentation::get_MasterTheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) برای دسترسی به تم سطح ارائه استفاده کنید. متدهای [FontScheme::get_Major](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_major/) و [FontScheme::get_Minor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_minor/) دو مجموعه [IFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifonts/) را برمی‌گردانند.

برای دریافت تمام نگاشت‌ها از یک مجموعه، [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fonts/getscriptfontmap/) را فراخوانی کنید. برای جستجوی یک سیستم نوشتاری خاص، با برچسب اسکریپت مربوطه، [Fonts::GetScriptFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fonts/getscriptfont/) را صدا بزنید. `GetScriptFont` هنگامی که آن مجموعه نگاشت درخواست‌شده را تعریف نکرده باشد، یک رشتهٔ تهی (null) برمی‌گرداند.

## **تغییر نگاشت‌ها و تأیید حفظ‌سازی**

از [Fonts::SetScriptFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fonts/setscriptfont/) برای ایجاد یا جایگزینی خانواده قلم فعلی استفاده کنید. برای حذف یک نگاشت، [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fonts/removescriptfont/) را به کار ببرید.

مثال کامل زیر تمام نگاشت‌های اصلی و فرعی موجود را می‌خواند، قلم اصلی ژاپنی را جستجو می‌کند، قلم اصلی سیریلیک را تغییر می‌دهد، نگاشت ثانا برای مجموعهٔ فرعی را حذف می‌کند، ارائه را ذخیره می‌سازد و سپس برای تأیید هر دو تغییر آن را باز می‌خواند. برای اینکه مرحلهٔ حذف مستقل از تم اولیه باشد، مثال ابتدا فقط زمانی که نگاشت ثانا از پیش تعریف نشده باشد، آن را ایجاد می‌کند.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

تأیید با همان رفتار رشتهٔ تهی همانند یک جستجوی معمولی انجام می‌شود: پس از ذخیره‌سازی حذف، `GetScriptFont(u"Thaa")` برای مجموعهٔ فرعی یک رشتهٔ تهی برمی‌گرداند.

## **تفاوت نگاشت‌های تم با سایر تنظیمات قلم**

نگاشت‌های تم خاص اسکریپت در انتخاب قلم مشارکت دارند، اما مشکلی متفاوت از قالب‌بندی مستقیم متن، جایگزینی و بازگشت (fallback) را حل می‌کنند:

| مکانیزم | هدف | اثر تغییر یک نگاشت تم |
|---|---|---|
| نگاشت قلم تم خاص اسکریپت | انتخاب قلم تم اصلی یا فرعی برای یک سیستم نوشتاری. | متنی که هنوز از قلم تم مربوطه استفاده می‌کند می‌تواند به خانوادهٔ قلم جدید نگاشت‌شده برسد. |
| قلم اختصاصی به یک بخش متن | ثابت کردن خانوادهٔ قلم درخواست‌شده برای آن بخش به‌جای اتکا به تم. | ممکن است بخش بدون تغییر بماند چون قالب‌بندی مستقیم آن، انتخاب تم را بازنویسی می‌کند. |
| جایگزینی قلم | جایگزینی قلم درخواست‌شده وقتی قلم موجود نیست یا قانون جایگزینی ای اعمال می‌شود. | پس از درخواست قلم انجام می‌شود؛ نقشی در تعریف مجدد نگاشت اسکریپت تم ندارد. |
| بازگشت قلم (Fallback) | ارائهٔ گلیف‌های غایب در قلم انتخاب‌شده، اغلب برای بازه‌های یونیکد خاص. | پوشش گلیف‌های گمشده را تکمیل می‌کند؛ نگاشت تم ذخیره‌شده را تغییر نمی‌دهد. |

برای اطلاعات بیشتر دربارهٔ دو مکانیزم آخر، به [Font Substitution](/slides/fa/cpp/font-substitution/) و [Fallback Fonts](/slides/fa/cpp/fallback-font/) مراجعه کنید.

تغییر یک نگاشت در [Presentation::get_MasterTheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) فقط بر محتوایی که قالب‌بندی مؤثرش همچنان به آن تم وابسته است، تأثیر می‌گذارد. متن ممکن است به جای آن از یک بازنویسی تم در مستر، چیدمان یا اسلاید ارث‌بری کند یا از قلم اختصاصی استفاده کند. هنگام مشاهدهٔ نتیجه‌ای که با نگاشت سطح ارائه مطابقت ندارد، این سطوح را بررسی کنید.

## **قابلیت دسترسی به قلم‌های نگاشت‌شده و اعتبارسنجی نتیجه**

یک نگاشت اسکریپت تنها نام خانوادهٔ قلم را ذخیره می‌کند؛ قلم مربوطه را نصب یا بارگذاری نمی‌کند. برای رندر ثابت و خروجی، هر قلم نگاشت‌شده باید در محیط نصب باشد یا از طریق منبع سفارشی مانند [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsloader/loadexternalfonts/) یا [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) به Aspose.Slides ارائه شود. گزینه‌های بارگذاری موجود را در [Custom Fonts](/slides/fa/cpp/custom-font/) ببینید.

تأیید نگاشت ذخیره‌شده تنها نشان می‌دهد تعریف تم حفظ شده است. این موضوع به این معنا نیست که قلم در دسترس باشد، تمام گلیف‌های لازم را داشته باشد یا چیدمان موردنظر را ایجاد کند. برای هر سیستم نوشتاری موردنیاز، متن نمایشی را به تصویر یا PDF رندر کنید و خروجی را بررسی کنید. این کار از قلم‌های گمشده، پوشش ناکامل گلیف، رفتار fallback و تغییرات چیدمان پیش از توزیع ارائه جلوگیری می‌کند. برای نمونه‌های رندر و خروجی به [Convert PowerPoint Presentations](/slides/fa/cpp/convert-powerpoint/) مراجعه کنید.

## **پرسش‌های متداول**

**`GetScriptFont` هنگام عدم وجود نگاشت برای یک اسکریپت چه چیزی برمی‌گرداند؟**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fonts/getscriptfont/) وقتی نگاشت اسکریپت درخواست‌شده در مجموعهٔ اصلی یا فرعی تعریف نشده باشد، یک رشتهٔ تهی (null) برمی‌گرداند.

**آیا `SetScriptFont` هنگام وجود قبلی اسکریپت یک نگاشت دوم اضافه می‌کند؟**

نه. [Fonts::SetScriptFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fonts/setscriptfont/) وقتی نگاشت موجود نباشد آن را ایجاد می‌کند و وقتی همان برچسب اسکریپت پیشاپیش موجود باشد، خانوادهٔ قلم نگاشت‌شده را جایگزین می‌کند.

**چرا تغییر نگاشت تم باعث تغییر برخی متن‌ها نشد؟**

متن ممکن است قلم اختصاصی داشته باشد، تم متفاوتی از طریق یک بازنویسی ارث‌بری کرده باشد یا در زمان رندر تحت تأثیر جایگزینی یا بازگشت قرار گیرد. یک نگاشت اسکریپت سطح ارائه فقط بر متنی که قالب‌بندی مؤثرش هنوز به آن مجموعهٔ قلم تم مراجعه می‌کند، کنترل دارد.

**آیا ذخیره‌سازی و بازگشایی کافی است تا خروجی چندزبانه را اعتبارسنجی کنیم؟**

خیر. بازگشایی فقط حفظ‌سازی داده‌های تم را تایید می‌کند. همچنین باید متن نمایشی هر سیستم نوشتاری موردنیاز را رندر کنید تا اطمینان حاصل شود قلم‌های نگاشت‌شده در دسترس هستند و گلیف‌های لازم را دارند.