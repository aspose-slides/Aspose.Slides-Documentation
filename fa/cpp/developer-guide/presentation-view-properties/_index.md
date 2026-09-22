---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در C++
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/cpp/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای معمولی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- قفل‌کردن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ویژگی‌های نمای Aspose.Slides برای C++ را کشف کنید تا فرمت‌های اسلاید PPT، PPTX و ODP را سفارشی‌سازی کنید—چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش را تنظیم کنید."
---
## **مقدمه**

نمای معمولی شامل سه ناحیه محتوایی است: خود اسلاید، یک ناحیه محتوای جانبی و یک ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌گذاری نواحی محتوایی مختلف مربوط می‌شوند. این اطلاعات به برنامه امکان می‌دهد وضعیت نمایش را در فایل ذخیره کند، به‌طوری که هنگام بازگشایی، نمایی که داشته باشد همان حالت باشد که ارائه آخرین بار ذخیره شده بود.

متدی به نام [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) اضافه شده است تا دسترسی به ویژگی‌های نمای معمولی ارائه را فراهم کند.

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inormalviewproperties/) و [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inormalviewrestoredproperties/) و فرزندان آن، همچنین شمارش‌گر [SplitterBarStateType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/splitterbarstatetype/) اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایانگر ویژگی‌های نمای معمولی است.

ویژگی **ShowOutlineIcons** تعیین می‌کند که آیا برنامه باید در صورت نمایش محتوای طرح کلی در هر یک از نواحی محتوایی حالت نمای معمولی، آیکون‌ها را نشان دهد یا نه.

ویژگی **SnapVerticalSplitter** تعیین می‌کند که آیا تقسیم‌کننده عمودی باید هنگام کوچک بودن کافی ناحیه جانبی، به حالت کمینه بچسبد یا نه.

ویژگی **PreferSingleView** مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک‑پرده‌تمام‑صفحه را به جای نمای معمولی استاندارد با سه ناحیه محتوایی ببیند. در صورت فعال بودن، برنامه می‌تواند یکی از نواحی محتوا را در کل پنجره نمایش دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** وضعیت نوار تقسیم‌کننده عمودی یا افقی را که باید نشان داده شود مشخص می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوای زیر اسلاید جدا می‌کند و نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** ابعاد ناحیه بالایی یا جانبی اسلاید در نمای معمولی را مشخص می‌کنند، هنگامی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌طور متناسب اعمال شده باشد.

## **درباره بازیابی INormalViewProperties**

ابعاد ناحیه اسلاید (عرض زمانی که فرزند RestoredTop باشد، ارتفاع زمانی که فرزند RestoredLeft باشد) در نمای معمولی را زمانی که ناحیه دارای اندازه‌ای متغیر بازگردانده شده (نه کمینه و نه بیشینه) باشد، مشخص می‌کند.

ویژگی **DimensionSize** اندازه ناحیه اسلاید (عرض وقتی که فرزند restoredTop باشد، ارتفاع وقتی که فرزند restoredLeft باشد) را مشخص می‌کند.

ویژگی **AutoAdjust** تعیین می‌کند که آیا اندازه ناحیه محتوای جانبی باید برای اندازه جدید جبران کند زمانی که پنجره حاوی نما در برنامه تغییر اندازه می‌دهد.

در مثال زیر نشان داده می‌شود که چگونه می‌توانید به ویژگی‌های **ViewProperties.NormalViewProperties** برای یک ارائه دسترسی پیدا کنید.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// بازگرداندن ویژگی‌های نمای ارائه
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **تنظیم مقدار پیش‌فرض بزرگنمایی**

Aspose.Slides برای C++ اکنون از تنظیم مقدار پیش‌فرض بزرگنمایی برای ارائه پشتیبانی می‌کند به‌طوری که هنگام باز کردن ارائه، بزرگنمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) یک ارائه انجام شود. ویژگی‌های نمای اسلاید و همچنین [get_NotesViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_notesviewproperties/) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این بخش، با یک مثال می‌بینیم چگونه ویژگی‌های نمای یک ارائه را در Aspose.Slides تنظیم کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید
1. ویژگی‌های View [Properties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) ارائه را تنظیم کنید
1. ارائه را به‌عنوان فایل PPTX ذخیره کنید

در مثال زیر، مقدار بزرگنمایی برای نمای اسلاید و همچنین نمای یادداشت‌ها را تنظیم کرده‌ایم.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// تنظیم ویژگی‌های نمای ارائه
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // مقدار بزرگنمایی به درصد برای نمای اسلاید
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // مقدار بزرگنمایی به درصد برای نمای یادداشت‌ها 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **تنظیم فاصله شبکه**

از [Presentation::get_ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/get_gridspacing/) و [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/set_gridspacing/) فواصل شبکه ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم برای تمام ارائه اعمال می‌شود، نه برای یک اسلاید منفرد. فاصله شبکه بر حسب پوینت‌ها تعریف می‌شود، به‌طوری که ۷۲ پوینت برابر یک اینچ است. از مقدار مثبت استفاده کنید، همان‌طور که مستندات API می‌طلبد.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصله شبکه فعلی آن را چاپ می‌کند، فاصله یک‌چهارم اینچ را تنظیم می‌نماید و نتیجه را ذخیره می‌کند.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

شبکه متفاوت از [drawing guides](/slides/fa/cpp/drawing-guides/) است. فاصله شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای رسم خطوط افقی یا عمودی موقعیت‌یابی شدهٔ جداگانه‌ای هستند. افزودن، جابه‌جایی یا حذف راهنمای رسم، فاصله شبکه را تغییر نمی‌دهد.

هر دو، شبکه و راهنمای رسم، ابزارهای کمکی ویرایشی هستند. آنها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا ارائه اسلاید نمایش داده نمی‌شوند. ذخیره‌سازی فاصله شبکه تضمین نمی‌کند که یک ویرایشگر آن را نشان دهد: قابلیت مشاهده آن نیز به تنظیمات مرورگر یا ویرایشگر بستگی دارد.

## **پرسش‌های متداول**

**چرا پس از باز کردن مجدد ارائه، شبکه قابل مشاهده نیست؟**

فایل فاصله شبکه را ذخیره می‌کند، اما ویرایشگر تعیین می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات نمایش شبکه در ویرایشگر را بررسی کنید.

**آیا حذف راهنمای رسم فاصله شبکه را تغییر می‌دهد؟**

خیر. راهنمای رسم و فاصله شبکه تنظیمات مستقلی هستند. حذف راهنماها بازهٔ ذخیره‌شدهٔ شبکه را دست‌نخورده می‌گذارد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

[View settings](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_slideviewproperties/))، نه بر پایهٔ بخش. بنابراین یک مجموعهٔ پارامتر به‌صورت یک‌دست بر روی کل سند هنگام باز شدن اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای متفاوتی را برای کاربران مختلف پیش‌تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره می‌شوند و به‌اشتراک گذاشته می‌شوند. برنامه‌های مشاهده ممکن است به ترجیحات کاربر احترام بگذارند، اما خود فایل تنها یک مجموعهٔ ویژگی‌های نمای را شامل می‌شود.

**آیا می‌توانم قالبی با ویژگی‌های نمای پیش‌تعریف‌شده تهیه کنم تا ارائه‌های جدید به‌همین شکل باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آنها را در یک قالب بگنجانید و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.