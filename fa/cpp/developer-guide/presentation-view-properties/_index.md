---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در C++
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/cpp/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- آیکون‌های طرح کلی
- چسباندن تقسیم‌کننده عمودی
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
description: "کشف ویژگی‌های نمای Aspose.Slides برای C++ برای سفارشی‌سازی فرمت‌های اسلاید PPT، PPTX و ODP — تنظیم چیدمان‌ها، سطوح بزرگنمایی و تنظیمات نمایش."
---
## **معرفی**

نمای عادی شامل سه ناحیه محتوا است: اسلاید خود، ناحیه محتوای جانبی و ناحیه محتوای پایین. ویژگی‌هایی که به موقعیت‌یابی نواحی مختلف محتوا مربوط می‌شوند. این اطلاعات به برنامه امکان می‌دهد وضعیت نمای خود را در فایل ذخیره کند، به طوری که هنگام بازگشایی، نما در همان وضعیتی باشد که ارائه آخرین بار ذخیره شده بود.

متد [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) برای دسترسی به ویژگی‌های نمای عادی ارائه اضافه شده است.  

رابط‌های [INormalViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inormalviewproperties/)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/inormalviewrestoredproperties/) و زیررده‌های آن، enum [SplitterBarStateType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/splitterbarstatetype/) نیز اضافه شده‌اند.

## **درباره INormalViewProperties**

نمایش ویژگی‌های نمای عادی را ارائه می‌دهد.

ویژگی **ShowOutlineIcons** مشخص می‌کند که آیا برنامه باید آیکون‌ها را نمایش دهد زمانی که محتوای طرح کلی در هر یک از نواحی محتوا در حالت نمای عادی نمایش داده می‌شود یا خیر.

ویژگی **SnapVerticalSplitter** تعیین می‌کند که آیا تقسیم‌کننده عمودی باید وقتی ناحیه جانبی به اندازه کافی کوچک است، به حالت کوچک‌شده (Minimized) بچسبد یا خیر.

ویژگی **PreferSingleView** مشخص می‌کند که آیا کاربر ترجیح می‌دهد یک ناحیه محتوای تک‌پنجره‌ای را به‌جای نمای عادی استاندارد با سه ناحیه محتوا ببیند. اگر فعال باشد، برنامه ممکن است یک از نواحی محتوا را در تمام پنجره نمایش دهد.

ویژگی‌های **VerticalBarState** و **HorizontalBarState** حالت نشان داده شدن نوار تقسیم‌کننده افقی یا عمودی را تعیین می‌کنند. نوار تقسیم‌کننده افقی اسلاید را از ناحیه محتوای زیرین اسلاید جدا می‌کند، نوار تقسیم‌کننده عمودی اسلاید را از ناحیه محتوای جانبی جدا می‌کند. مقادیر ممکن عبارتند از: **SplitterBarStateType.Minimized، SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

ویژگی‌های **RestoredLeft** و **RestoredTop** اندازه‌گیری ناحیه اسلاید بالا یا سمت را در نمای عادی مشخص می‌کنند، زمانی که مقدار **SplitterBarStateType.Restored** برای **VerticalBarState** و **HorizontalBarState** به‌صورت متناسب اعمال شده باشد.

## **درباره بازیابی INormalViewProperties**

اندازه‌گیری ناحیه اسلاید (عرض زمانی که فرزند RestoredTop باشد، ارتفاع زمانی که فرزند RestoredLeft باشد) در نمای عادی را مشخص می‌کند، زمانی که ناحیه دارای اندازهٔ بازگردانده شده متغیر (نه کوچک‌شده نه بزرگ‌شده) باشد.

ویژگی **DimensionSize** اندازه ناحیه اسلاید (عرض زمانی که فرزند restoredTop باشد، ارتفاع زمانی که فرزند restoredLeft باشد) را مشخص می‌کند.

ویژگی **AutoAdjust** تعیین می‌کند که آیا اندازهٔ ناحیه محتوای جانبی باید برای اندازهٔ جدید هنگام تغییر اندازهٔ پنجرهٔ حاوی نما در برنامه جبران شود یا خیر.

مثالی که در زیر آورده شده است نشان می‌دهد چگونه می‌توانید به ویژگی‌های **ViewProperties.NormalViewProperties** برای یک ارائه دسترسی پیدا کنید.

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

Aspose.Slides برای C++ اکنون از تنظیم مقدار پیش‌فرض بزرگنمایی برای ارائه پشتیبانی می‌کند به‌گونه‌ای که هنگام باز شدن ارائه، بزرگنمایی از پیش تنظیم شده باشد. این کار می‌تواند با تنظیم [ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) یک ارائه انجام شود. ویژگی‌های نمای اسلاید و همچنین [get_NotesViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_notesviewproperties/) می‌توانند به‌صورت برنامه‌نویسی تنظیم شوند. در این موضوع، با یک مثال می‌بینیم چگونه ویژگی‌های نمای یک ارائه را در Aspose.Slides تنظیم کنیم.

برای تنظیم ویژگی‌های نما، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید
1. ویو [Properties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) ارائه را تنظیم کنید
1. ارائه را به‌عنوان فایل PPTX ذخیره کنید

در مثال زیر، مقدار بزرگنمایی را برای نمای اسلاید و همچنین نمای یادداشت تنظیم کرده‌ایم.

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
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // مقدار بزرگنمایی به درصد برای نمای یادداشت 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **تنظیم فاصله شبکه**

از [Presentation::get_ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. متدهای [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/get_gridspacing/) و [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/set_gridspacing/) فاصلهٔ شبکهٔ ویرایشی زیرین را می‌خوانند یا تغییر می‌دهند. این تنظیم بر کل ارائه اعمال می‌شود، نه بر روی یک اسلاید جداگانه. فاصلهٔ شبکه بر حسب نقطه مشخص می‌شود، که ۷۲ نقطه برابر یک اینچ است. یک مقدار مثبت استفاده کنید، همان‌طور که مستندات API می‌طلبد.

مثال زیر یک فایل `demo.pptx` موجود را باز می‌کند، فاصلهٔ شبکهٔ فعلی آن را چاپ می‌کند، فاصلهٔ یک‌چهارم اینچ را تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

شبکه با [drawing guides](/slides/fa/cpp/drawing-guides/) متفاوت است. فاصلهٔ شبکه یک بازهٔ منظم را کنترل می‌کند، در حالی که راهنمای‌های رسم خطوط ترازبندی افقی یا عمودی هستند که به‌صورت جداگانه موقعیت‌یابی می‌شوند. افزودن، جابجایی یا پاک‌سازی راهنمای‌های رسم باعث تغییر فاصلهٔ شبکه نمی‌شود.

هر دو، شبکه و راهنمای‌های رسم، ابزارهای کمکی ویرایش هستند. آن‌ها به‌عنوان محتوای اسلاید در PDF، تصاویر، SVG یا نمایش اسلاید رندر نمی‌شوند. ذخیرهٔ فاصلهٔ شبکه تضمین نمی‌کند که یک ویرایشگر شبکه را نمایش دهد؛ قابلیت دید آن نیز به تنظیمات مشاهده‌گر یا ویرایشگر بستگی دارد.

## **نمایش یا مخفی کردن نظرات هنگام باز کردن یک ارائه**

از [Presentation::get_ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) برای دسترسی به تنظیمات نمای سراسری ارائه استفاده کنید. از [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/get_showcomments/) و [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/set_showcomments/) برای ذخیرهٔ ترجیح نمایش یا عدم نمایش نظرات زمانی که ارائه در PowerPoint یا ویرایشگر سازگار دیگری باز می‌شود، استفاده کنید.

این تنظیم تنها ترجیح ذخیره‌شدهٔ نما را کنترل می‌کند. این تنظیم نظرات را اضافه، حذف، ویرایش یا حل نمی‌کند. مخفی کردن نظرات محتوای آن‌ها، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌ها را حفظ می‌کند. برای عملیات‌هایی که نظرات را خودش تغییر می‌دهند به [Presentation Comments](/slides/fa/cpp/presentation-comments/) مراجعه کنید.

مثال زیر نیاز به یک فایل `comments.pptx` موجود دارد که شامل نظرات باشد. این مثال تنظیم فعلی نمایش را چاپ می‌کند، درخواست می‌کند نظرات مخفی شوند و یک PPTX جدید را بدون حذف هیچ‌یک از نظرات ذخیره می‌کند. همچنین از [IViewProperties::set_LastView](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iviewproperties/set_lastview/) همراه با [ViewType::SlideView](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewtype/) برای پیکربندی نمای ویرایشی اولیه به‌همراه قابلیت نمایش نظرات استفاده می‌کند.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

این تنظیم تعیین نمی‌کند که نظرات در خروجی‌های PDF، HTML، تصویر، یادداشت یا جزوه گنجانده شوند یا نه. گزینه‌های مربوط به هر نوع خروجی را به‌صورت جداگانه پیکربندی کنید.

## **سوالات متداول**

**چرا پس از بازگشایی دوبارهٔ ارائه، شبکه نمایش داده نمی‌شود؟**

فایل فاصلهٔ شبکه را ذخیره می‌کند، اما ویرایشگر کنترل می‌کند که آیا شبکه نمایش داده شود یا نه. تنظیمات دیداری شبکهٔ ویرایشگر را بررسی کنید.

**آیا پاک‌سازی راهنمای‌های رسم فاصلهٔ شبکه را تغییر می‌دهد؟**

خیر. راهنمای‌های رسم و فاصلهٔ شبکه تنظیمات مستقلی هستند. پاک‌سازی راهنماها فاصلهٔ ذخیره‌شدهٔ شبکه را بدون تغییر می‌گذارد.

**آیا می‌توانم تنظیمات نمای متفاوتی برای بخش‌های مختلف یک ارائه تنظیم کنم؟**

تنظیمات [View settings](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) در سطح ارائه تعریف می‌شوند ([Normal View](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/get_slideviewproperties/))، نه برای هر بخش، بنابراین یک مجموعهٔ واحد از پارامترها هنگام باز شدن، برای سرتاسر سند اعمال می‌شود.

**آیا می‌توانم حالت‌های نمای متفاوتی را برای کاربران مختلف پیش‌تعریف کنم؟**

خیر. تنظیمات در فایل ذخیره شده و به‌اشتراک گذاشته می‌شوند. برنامه‌های نمایش ممکن است ترجیحات کاربر را رعایت کنند، اما خود فایل فقط یک مجموعهٔ ویژگی‌های نمای را شامل می‌شود.

**آیا می‌توانم یک الگو با ویژگی‌های نمای پیش‌تعریف شده تهیه کنم تا ارائه‌های جدید به همان شکل باز شوند؟**

بله. چون [view properties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_viewproperties/) در سطح ارائه ذخیره می‌شوند، می‌توانید آن‌ها را در یک قالب قرار دهید و اسناد جدید را بر پایهٔ آن با همان پیکربندی نمای اولیه ایجاد کنید.