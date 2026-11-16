---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در C++
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/cpp/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای فهرست
- آیکون‌های فهرست
- قفل‌کردن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بُعد
- تنظیم خودکار
- بزرگ‌نمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "از Aspose.Slides برای C++ برای پیکربندی چیدمان نمای عادی، بزرگ‌نمایی اسلاید و یادداشت‌ها، فاصله‌گذاری شبکه و قابلیت نمایش نظرات در ارائه‌های PowerPoint استفاده کنید."
---
## **مقدمه**

در نمای عادی PowerPoint، اسلاید بین یک پنل جانبی برای تصویرهای کوچک یا فهرست و یک پنل یادداشت در زیر نمایش داده می‌شود. Aspose.Slides برای C++ تنظیمات ویرایشی ذخیره‌شدهٔ ارائه را از طریق [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) در دسترس قرار می‌دهد. این تنظیمات شامل چینش پنل‌ها، سطح‌های بزرگ‌نمایی، فاصله‌گذاری شبکه و قابلیت نمایش نظرات هستند.

## **درباره INormalViewProperties**

از [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) برای دسترسی به رابط [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) استفاده کنید. [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) تعیین می‌کند که آیا آیکون‌ها در کنار عناوین اسلایدها در فهرست نمایش داده شوند یا خیر. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) امکان قفل کردن پنل جانبی به حالت کوچک‌سازی‌شدهٔ خود را زمانی که کاربر آن را باریک می‌کند، فراهم می‌کند. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) ترجیح نمایش تنها یک پنل در کل پنجره را نشان می‌دهد.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) تقسیم‌کنندهٔ بین پنل جانبی و اسلاید را کنترل می‌کند. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) تقسیم‌کنندهٔ بالای پنل یادداشت‌ها را تنظیم می‌نماید. هر دو مقدار از نوع [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) را می‌پذیرند که می‌تواند `Minimized`، `Maximized` یا `Restored` باشد.

## **درباره بازگرداندن INormalViewProperties**

هنگامی که یک تقسیم‌کننده بازگردانده شود، [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) اندازهٔ ذخیره‌شدهٔ پنل جانبی و [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) اندازهٔ ذخیره‌شدهٔ ناحیهٔ بالایی اسلاید را فراهم می‌کند. هر دو ویژگی [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) را باز می‌گردانند. متد [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) درصدی بین ۰ تا ۱۰۰ می‌پذیرد و [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) تعیین می‌کند که آیا ویرایشگر هنگام تغییر اندازهٔ پنجره، اندازه را خودکار تنظیم کند یا نه.

این مثال یک ارائهٔ موجود را به‌روزرسانی می‌کند. تقسیم‌کنندهٔ افقی را بازگردانی می‌کند، اندازهٔ ناحیهٔ بالایی اسلاید که توسط [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) افشا می‌شود را به ۸۰٪ تنظیم می‌کند و تنظیم خودکار را فعال می‌سازد، و تقسیم‌کنندهٔ عمودی را به حداکثر می‌رساند. همچنین با [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) آیکون‌های فهرست را برای نمای فهرست فعال می‌کند.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **تنظیم مقدار پیش‌فرض بزرگ‌نمایی**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) و [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) تنظیمات بزرگ‌نمایی جداگانه‌ای برای ویرایشگر ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلایدشو یا وضوح تصویر هنگام خروجی تأثیری ندارند.

این مثال ارائهٔ موجودی را باز می‌کند و با استفاده از [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) مقیاس‌گذاری خودکار را فعال می‌سازد تا اسلاید داخل پنجرهٔ ویرایشگر جا بگیرد. برای صفحهٔ یادداشت، مقیاس‌گذاری خودکار غیرفعال می‌شود و با [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) بزرگ‌نمایی ثابت ۸۰٪ تنظیم می‌گردد.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **تنظیم فاصله‌گذاری شبکه**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) فاصله بین خطوط شبکهٔ ویرایشی را در سراسر ارائه تنظیم می‌کند. این مقدار به صورت عددی مثبت در واحد نقطه (هر اینچ ۷۲ نقطه) دریافت می‌شود. این مثال فاصلهٔ فعلی را در یک ارائهٔ موجود چاپ می‌کند و با تنظیم فاصلهٔ ۱۸ نقطه (یک‌چهارم اینچ) یک شبکهٔ جدید ذخیره می‌نماید.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

شبکه در فواصل ثابت تکرار می‌شود. [راهنماهای رسم](/slides/fa/cpp/drawing-guides/) موقعیت‌های افقی یا عمودی جداگانه را نشان می‌دهند. هر دو ابزار کمکی برای ویرایش هستند و فقط در ویرایشگرهایی که آن‌ها را نمایش می‌دهند ظاهر می‌شوند. نمایش اسلاید و خروجی به PDF، تصویر یا SVG این راهنماها را حذف می‌کنند.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) ترجیحی را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌کنند. برای یک ارائهٔ موجود که حاوی نظرات است، این مثال تنظیم فعلی را چاپ می‌کند و نسخه‌ای با نظرات مخفی ذخیره می‌نماید. همچنین با [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) همراه با [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) نسخهٔ کپی‌شده را در نمای اسلاید باز می‌کند.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

مخفی‌سازی نظرات متن، نویسنده، موقعیت، پاسخ‌ها و وضعیت آن‌ها را حفظ می‌کند. برای تغییر خود نظرات، به بخش [Presentation Comments](/slides/fa/cpp/presentation-comments/) مراجعه کنید. تنظیمات خروجی تعیین می‌کند که آیا نظرات در PDF، HTML، تصویر، یادداشت یا جزوه‌ها ظاهر می‌شوند یا خیر.

## **سوالات متداول**

**چرا شبکه هنگام باز کردن مجدد ارائه مخفی می‌شود؟**

ارائه فاصلهٔ شبکه را ذخیره می‌کند. برای مشاهدهٔ شبکه، قابلیت نمایش شبکه را در ویرایشگر فعال کنید.

**آیا پاک کردن راهنماهای رسم فاصلهٔ شبکه را تغییر می‌دهد؟**

نه. افزودن، جابجایی یا پاک کردن یک راهنما فاصلهٔ شبکه را تغییر نمی‌دهد.

**آیا می‌توان بخش‌های مختلف یک ارائه را با تنظیمات نمای متفاوت داشت؟**

نه. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) برای کل ارائه اعمال می‌شود.

**آیا می‌توانم تنظیمات نمای متفاوتی برای کاربران مختلف ذخیره کنم؟**

فایل تنها یک مجموعهٔ تنظیمات نمای برای همه ذخیره می‌کند. ویرایشگر ممکن است ترجیح‌های محلی کاربر را نیز اعمال کند.

**آیا می‌توانم تنظیمات نمای را در یک قالب ذخیره کنم؟**

بله. ارائه‌های ساخته‌شده از قالب، تنظیمات نمای ذخیره‌شدهٔ قالب را به ارث می‌برند.