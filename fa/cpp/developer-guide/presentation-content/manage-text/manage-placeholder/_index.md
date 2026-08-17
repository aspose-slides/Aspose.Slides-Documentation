---
title: مدیریت نگهدارنده‌های ارائه در C++
linktitle: مدیریت نگهدارنده‌ها
type: docs
weight: 10
url: /fa/cpp/manage-placeholder/
keywords:
- نگهدارنده
- نگهدارنده متن
- نگهدارنده تصویر
- نگهدارنده نمودار
- نگهدارنده محتوا
- متن راهنما
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه نگهدارنده‌های متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت نگهدارنده‌ها را با Aspose.Slides برای C++ درک نمایید."
---
## **بررسی کلی**

یک نگهدارنده (placeholder) یک شکل است که موقعیتی را برای نوع خاصی از محتوا در قالب ارائه رزرو می‌کند. مثال‌های رایج شامل نگهدارنده‌های عنوان، بدنه، تصویر، نمودار و نگهدارنده‌های محتوای عمومی هستند. برخلاف یک شکل عادی، یک نگهدارنده می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از اسلاید طرح‌بندی یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات نگهدارنده را از طریق متد [IShape::get_Placeholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_placeholder/) در دسترس می‌گذارد. این متد یک شیء [IPlaceholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iplaceholder/) یا `nullptr` برای یک شکل عادی برمی‌گرداند. برای تعیین محتوای مورد انتظار نگهدارنده از [IPlaceholder::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iplaceholder/get_type/) استفاده کنید.

پس از این‌که نوع نگهدارنده را دانستید، رابط شکل همچنان مهم است:

- یک نگهدارنده خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) نمایان می‌شود.
- یک نگهدارنده تصویر پر شده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) نمایان شود.
- یک نگهدارنده نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/) نمایان شود.
- یک نگهدارنده محتوا می‌تواند انواع مختلفی از محتوا را در خود داشته باشد. به‌جای فرض اینکه هر نگهدارنده‌ای یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) است، هم [IPlaceholder::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iplaceholder/get_type/) و هم رابط شکل در زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iplaceholder/get_type/) توصیف‌کننده نقش یک نگهدارنده است؛ این تضمین نمی‌کند که نوع شکل در زمان اجرا همان باشد. همیشه قبل از دسترسی به اعضای متنی، تصویر، نمودار، جدول یا رسانه‌ای، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بری نگهدارنده**

نگهدارنده‌ها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد، نگهدارنده‌های سطح اصلی را نیز در بر می‌گیرد.
2. یک اسلاید طرح‌بندی (layout) چیدمان استفاده‌شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اسلاید اصلی ارث‌بری کند.
3. یک اسلاید عادی شامل نگهدارنده‌های مربوط به آن اسلاید است و می‌تواند از طرح‌بندی خود ارث‌بری کند.

برای رفتن یک سطح بالا در این سلسله‌مراتب، متد [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getbaseplaceholder/) را فراخوانی کنید. یک نگهدارنده اسلاید معمولاً نگهدارنده طرح‌بندی خود را برمی‌گرداند؛ یک نگهدارنده طرح‌بندی می‌تواند نگهدارنده اصلی خود را برگرداند. این متد زمانی که شکل پایه‌ای نداشته باشد `nullptr` برمی‌گرداند.

مثال زیر نگهدارنده‌های اسلاید اول را فهرست می‌کند و پایهٔ هر یک را گزارش می‌دهد:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

ویرایش یک نگهدارنده در یک اسلاید عادی، بازنویسی یا تغییر محلی برای آن اسلاید ایجاد می‌کند. ویرایش طرح‌بندی یا اسلاید اصلی مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند تأثیر بگذارد. یک شکل عادی محلی پایهٔ نگهدارنده‌ای ندارد و تنها به این دلیل که همان مختصات را در بر می‌گیرد، ارث‌بری شروع نمی‌کند.

## **تغییر متن در یک نگهدارنده**

نگهدارنده‌های عنوان، عنوان‌وسط‌چین، زیرنویس، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [get_TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/get_textframe/)، وجود [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) را بررسی کنید.

این مثال اولین نگهدارندهٔ عنوان در اسلاید اول را به‌روز می‌کند و نتیجه را ذخیره می‌نماید:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

این الگو از تبدیل نگهدارنده‌های تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین نگهدارنده را بر اساس هدف شناسایی می‌کند به‌جای وابستگی به یک شاخص شکل ناپایدار.

## **تنظیم متن راهنمایی در یک طرح‌بندی**

متن راهنمایی (Prompt text) دستور طراحی است که در یک نگهدارندهٔ خالی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. متن راهنمای سفارشی را بر روی نگهدارندهٔ طرح‌بندی تنظیم کنید نه این‌که سعی کنید از مجموعهٔ شکل‌های اسلاید عادی به آن دسترسی پیدا کنید. طرح‌بندی را از طریق [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/get_layoutslide/) دریافت کنید و بر روی [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_shapes/) تکرار کنید.

مثال زیر متن راهنمایی عنوان و زیرنویس را در طرح‌بندی استفاده‌شده توسط اسلاید اول تغییر می‌دهد:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

متن راهنمایی محتوای اسلاید عادی نیست. این متن برای نگهدارنده‌های خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. هنگامی که کاربر یا برنامه محتوای واقعی را فراهم می‌کند، راهنمایی دیگر نمایش داده نمی‌شود. تغییر راهنمایی همچنین متن موجود در اسلایدهایی که از این طرح‌بندی استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک نگهدارندهٔ تصویر**

دو مورد برای پردازش وجود دارد:

- اگر نگهدارندهٔ تصویر قبلاً پر شده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) نمایان شود، تصویر را از طریق [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/get_picture/) و [ISlidesPicture::set_Image](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/set_image/) جایگزین کنید.
- اگر هنوز یک نگهدارندهٔ خالی باشد، یک چارچوب تصویر را در مختصات نگهدارنده با استفاده از [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addpictureframe/) اضافه کنید و نگهدارندهٔ خالی را حذف نمایید.

مثال بعدی هر دو مورد را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

جایگزینی که برای یک نگهدارندهٔ خالی ساخته می‌شود یک چارچوب تصویر محلی است، نه یک نگهدارندهٔ جدید، زیرا [IShape::get_Placeholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_placeholder/) فقط خواندنی است. این جایگزین موقعیت رزروشده را حفظ می‌کند اما دیگر رفتار خاص نگهدارنده را به ارث نمی‌برد. اگر حفظ رابطهٔ نگهدارنده ضروری است، ابتدا در PowerPoint آن را آماده و پر کنید، سپس [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر اثرات خاص تصویر، به [Manage Picture Frames](/slides/fa/cpp/picture-frame/) مراجعه کنید. این عملیات‌ها مربوط به چارچوب تصویر یا پرکنندهٔ تصویر هستند، نه به متادادهٔ نگهدارنده.

## **کار با نگهدارنده‌های نمودار و محتوا**

یک نگهدارندهٔ نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/) نمایان شود. این مثال با استفاده از نوع نگهدارنده و رابط زمان اجرا، چنین نموداری را پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

یک نگهدارندهٔ محتوای عمومی معمولاً دارای [PlaceholderType::Object](https://reference.aspose.com/slides/fa/cpp/aspose.slides/placeholdertype/) است. در PowerPoint این نگهدارنده به‌عنوان یک راه‌انداز برای انواع مختلف محتوا عمل می‌کند، از جمله نمودارها، جداول، دیاگرام‌ها، تصاویر و رسانه‌ها. پس از پر شدن، برای فهمیدن محتوا باید رابط شکل واقعی را بررسی کنید. طرح‌بندی‌های ویژه می‌توانند همچنین [PlaceholderType::Chart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/placeholdertype/)، [PlaceholderType::Table](https://reference.aspose.com/slides/fa/cpp/aspose.slides/placeholdertype/)، [PlaceholderType::Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/placeholdertype/)، [PlaceholderType::Media](https://reference.aspose.com/slides/fa/cpp/aspose.slides/placeholdertype/)، یا [PlaceholderType::Diagram](https://reference.aspose.com/slides/fa/cpp/aspose.slides/placeholdertype/) را نشان دهند.

Aspose.Slides تنها با تغییر [IPlaceholder::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iplaceholder/get_type/) یک نگهدارندهٔ خالی [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) را به یک [IChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/) تبدیل نمی‌کند؛ نوع فقط خواندنی است. برای پر کردن برنامه‌ای یک ناحیهٔ خالی نمودار یا محتوا، شیء مورد نیاز را در مختصات نگهدارنده اضافه کنید و سپس نگهدارندهٔ خالی را حذف نمایید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

نمودار اضافه‌شده یک نمودار محلی عادی است. این نمودار ناحیهٔ نگهدارنده را اشغال می‌کند اما از نگهدارندهٔ طرح‌بندی ارث نمی‌برد. هنگامی که نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتاب کاری آن داشته باشید، از مقالات اختصاصی [chart management articles](/slides/fa/cpp/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها به انتهای زیر یک قالب را باز می‌کند، اسلاید اول را برای یافتن نگهدارندهٔ عنوان یا تصویر جستجو می‌کند، نوع نگهدارنده و شکل را بررسی می‌نماید، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال عمداً از فرض وجود شاخص شکل یا تبدیل همهٔ نگهدارنده‌ها به یک رابط واحد اجتناب می‌کند.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **پرسش‌های متداول**

**پایهٔ یک نگهدارنده چیست؟**

یک پایهٔ نگهدارنده، شکل متناظر در طرح‌بندی یا اسلاید اصلی است که از آن یک نگهدارنده دیگر ارث می‌برد. برای به‌دست آوردن آن از [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getbaseplaceholder/) استفاده کنید. یک شکل محلی عادی `nullptr` برمی‌گرداند زیرا بخشی از سلسله‌مراتب نگهدارنده‌ها نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک نگهدارندهٔ طرح‌بندی تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمایی ارث‌برده‌شده را از طریق یک طرح‌بندی تغییر دهید، اما محتوای عنوان موجود در اسلایدهای عادی ذخیره شده است. برای جایگزینی متن واقعی عنوان در تمام ارائه، بر تمام اسلایدها پیمایش کنید و هر نگهدارندهٔ عنوان را به‌روز کنید.

**چگونه می‌توانم نگهدارنده‌های تاریخ، شماره‌اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیران سرصفحه و پاورقی در اسلاید، طرح‌بندی، اسلاید اصلی، یادداشت یا نسخهٔ توزیع مناسب استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/cpp/presentation-header-and-footer/) مراجعه کنید.