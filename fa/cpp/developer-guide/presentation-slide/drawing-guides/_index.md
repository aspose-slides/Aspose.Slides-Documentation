---
title: مدیریت راهنماهای رسم در ارائه‌ها با C++
linktitle: راهنماهای رسم
type: docs
weight: 85
url: /fa/cpp/drawing-guides/
keywords:
- راهنمای رسم
- راهنمای افقی
- راهنمای عمودی
- راهنمای هم‌راستایی
- نمای اسلاید
- اسلاید مستر
- اسلاید لایه‌بندی
- مستر یادداشت
- مستر برگه توزیع
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "افزودن، دسترسی و حذف راهنماهای افقی و عمودی رسم در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای C++."
---
## **نمای کلی**

راهنماهای رسم خطوط افقی و عمودی قابل تنظیمی هستند که به کاربران کمک می‌کنند هنگام ویرایش یک ارائه در PowerPoint به‌صورت مداوم اشکال را هم‌راستا کنند. این راهنماها به‌ویژه زمانی مفیدند که یک برنامه ارائه‌ای را تولید می‌کند که بعدها به‌صورت دستی اصلاح می‌شود: برنامه می‌تواند همان ابزارهای هم‌راستایی را ذخیره کند تا نویسندگان هنگام افزودن یا جابه‌جا کردن محتوا از آن پیروی کنند.

راهنماهای رسم ابزارهای ویرایشی هستند، نه محتوای اسلاید. آنها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides برای C++ آنها را از طریق رابط [IDrawingGuidesCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguidescollection/) در دسترس قرار می‌دهد. یک راهنما توسط [IDrawingGuide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguide/) نمایانده می‌شود و دارای جهت، موقعیت و رنگ است.

موقعیت به‌واحد نقطه از گوشهٔ بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمأ عمودی از مختصات افقی استفاده می‌کند که معمولاً بین صفر و عرض اسلاید قرار دارد. یک راهنمأ افقی از مختصات عمودی استفاده می‌کند که معمولاً بین صفر و ارتفاع اسلاید است.

## **افزودن راهنماها به نمای اسلاید**

از [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) برای مدیریت راهنماهایی که در حین ویرایش اسلایدهای معمولی نمایش داده می‌شوند، استفاده کنید. با فراخوانی [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguidescollection/add/) یک مقدار [Orientation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/orientation/) و موقعیتی به‌واحد نقطه، یک راهنما اضافه می‌شود.

مثال زیر یک راهنمأ عمودی را در سمت راست مرکز اسلاید و یک راهنمأ افقی را در زیر آن اضافه می‌کند:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دسترسی به راهنماهای رسم**

متد [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguidescollection/get_count/) و متد [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguidescollection/idx_get/) امکان دسترسی به راهنماهای موجود را فراهم می‌کنند. متدهای [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguide/get_orientation/)، [IDrawingGuide::get_Position](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguide/get_position/) و [IDrawingGuide::get_Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguide/get_color/) مقادیر فعلی یک راهنما را برمی‌گردانند. متدهای setter مربوطه می‌توانند این ویژگی‌ها را تغییر دهند.

مثال زیر راهنماهای نمای اسلاید را از ارائهٔ ساخته‌شده در بالا می‌خواند:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **افزودن راهنماها به اسلایدهای مستر و لایه‌بندی**

یک اسلاید مستر و هر یک از اسلایدهای لایه‌بندی آن می‌توانند مجموعهٔ راهنماهای رسم خود را داشته باشند. برای یک اسلاید مستر از [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/get_drawingguides/) و برای یک اسلاید لایه‌بندی از [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_drawingguides/) استفاده کنید.

مثال زیر یک راهنمأ عمودی را به اولین اسلاید مستر و یک راهنمأ افقی را به اولین اسلاید لایه‌بندی اضافه می‌کند:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **افزودن راهنماها به مسترهای یادداشت و برگه‌های توزیع**

مسترهای یادداشت و برگه‌های توزیع نیز از راهنماهای رسم پشتیبانی می‌کنند. برای دسترسی به مجموعه‌های آنها از [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslide/get_drawingguides/) و [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) استفاده کنید. اگر ارائه‌ای یکی از این مسترها را نداشته باشد، [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) یا [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) مستر پیش‌فرض را ایجاد کرده و برمی‌گرداند.

مثال زیر یک راهنمأ افقی را به یک مستر یادداشت و یک راهنمأ عمودی را به یک مستر برگهٔ توزیع اضافه می‌کند:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پاک‌سازی راهنماهای رسم**

برای حذف همهٔ راهنماها از یک مجموعهٔ خاص، متد [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idrawingguidescollection/clear/) را فراخوانی کنید. پاک‌سازی یک مجموعه، راهنماهای ذخیره‌شده در حوزهٔ دیگر را تحت‌تأثیر قرار نمی‌دهد.

مثال زیر راهنماهای نمای اسلاید و تمام راهنماهای موجود بر روی اسلایدهای مستر، اسلایدهای لایه‌بندی، مستر یادداشت و مستر برگهٔ توزیع را بدون ایجاد مسترهای مفقود پاک‌سازی می‌کند:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**آیا راهنماهای رسم در یک نمایش اسلاید یا تصاویر خروجی ظاهر می‌شوند؟**

نه. راهنماهای رسم ابزارهای هم‌راستایی برای ویرایش هستند و به عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک راهنما را مستقیماً به یک اسلاید عادی اضافه کرد؟**

راهنماهای ویرایشی اسلاید عادی در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های راهنماهای جداگانه‌ای برای اسلایدهای مستر، اسلایدهای لایه‌بندی، مسترهای یادداشت و مسترهای برگهٔ توزیع موجود است.

**کدام واحد برای موقعیت راهنماها استفاده می‌شود؟**

موقعیت‌ها بر حسب نقطه مشخص می‌شوند که در آن ۷۲ نقطه برابر با یک اینچ است. موقعیت‌های عمودی از لبهٔ چپ اندازه‌گیری می‌شوند و موقعیت‌های افقی از لبهٔ بالا.

**آیا پاک‌سازی راهنماهای رسم باعث حذف اشکال یا تغییر محتوای اسلاید می‌شود؟**

نه. متد `Clear` فقط راهنماهای موجود در مجموعه انتخاب‌شده را حذف می‌کند. اشکال و سایر محتوای اسلاید بدون تغییر باقی می‌مانند.