---
title: مدیریت محل‌نگه‌دارهای ارائه در C++
linktitle: مدیریت محل‌نگه‌دارها
type: docs
weight: 10
url: /fa/cpp/manage-placeholder/
keywords:
- محل‌نگه‌دار
- محل‌نگه‌دار متن
- محل‌نگه‌دار تصویر
- محل‌نگه‌دار نمودار
- محل‌نگه‌دار محتوا
- متن راهنما
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه محل‌نگه‌دارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت محل‌نگه‌دارها را با Aspose.Slides برای C++ درک کنید."
---
## **مروری کلی**

یک placeholder شکلی است که موقعیتی را برای نوع خاصی از محتوا در یک قالب ارائه ذخیره می‌کند. مثال‌های رایج شامل عنوان، متن اصلی، تصویر، نمودار و placeholderهای محتوای عمومی هستند. برخلاف یک شکل عادی، یک placeholder می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید چیدمان یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات placeholder را از طریق متد [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) در دسترس قرار می‌دهد. این متد یک شیء [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) یا `nullptr` برای یک شکل عادی برمی‌گرداند. برای تعیین منظور placeholder از [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) استفاده کنید.

رابط شکل همچنان پس از دانستن نوع placeholder مهم است:

- یک placeholder متن، تصویر، نمودار یا محتوا خالی معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) نمایش داده می‌شود.
- یک placeholder تصویر پر شده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) نمایش داده شود.
- یک placeholder نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) نمایش داده شود.
- یک placeholder محتوا می‌تواند شامل چندین نوع محتوا باشد. به جای فرض اینکه هر placeholder یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) است، هم [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) و هم رابط شکل زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) نقش یک placeholder را توصیف می‌کند؛ اما نوع زمان اجرای شکل را تضمین نمی‌کند. همیشه قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه، بررسی نوع را انجام دهید.
{{% /alert %}}

## **درک ارث‌بری محل‌نما**

محل‌نماها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی سبک‌های قابل استفاده مجدد و در برخی موارد placeholderهای سطح اصلی را تعریف می‌کند.
2. یک اسلاید چیدمان ترتیب استفاده شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اسلاید اصلی ارث بگیرد.
3. یک اسلاید عادی placeholderهای مربوط به آن اسلاید را شامل می‌شود و می‌تواند از چیدمان خود ارث بگیرد.

برای جابه‌جایی یک سطح بالا در این سلسله‌مراتب، متد [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) را فراخوانی کنید. یک placeholder اسلاید معمولاً placeholder چیدمان خود را برمی‌گرداند؛ یک placeholder چیدمان می‌تواند placeholder اصلی را برگرداند. این متد `nullptr` برمی‌گرداند وقتی شکلی placeholder پایه‌ای ندارید.

مثال زیر placeholderهای اسلاید اول را فهرست می‌کند و placeholderهای پایه‌ای آن‌ها را گزارش می‌دهد:

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

ویرایش یک placeholder در یک اسلاید عادی یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش چیدمان یا اسلاید اصلی مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند، تأثیر بگذارد. یک شکل عادی محلی placeholder پایه‌ای ندارد و صرفاً به دلیل قرار گرفتن در همان مختصات شروع به ارث‌بری نمی‌کند.

## **حذف وضعیت placeholder**

هنگامی که یک قالب را سازگار می‌کنید، از [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) استفاده کنید تا یک شیء موجود را به عنوان یک شکل عادی نگه دارید. متد [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) آن `nullptr` برمی‌گرداند، اما شکل در مجموعه اسلاید باقی می‌ماند. در مقابل، [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) شکل را از آن مجموعه حذف می‌کند.

مثال زیر به فایل `template.pptx` نیاز دارد که حداقل یک اسلاید و یک placeholder متن غیرخالی در اسلاید اول داشته باشد. برای مشاهده اثر حذف رابطه، از یک placeholder با قالب‌بندی ارث‌بری‌شده از چیدمان یا اسلاید اصلی استفاده کنید. مثال بررسی می‌کند که همان شکل باقی می‌ماند، دوباره متد را بر روی شکل الآن عادی فراخوانی می‌کند و نتیجه را ذخیره می‌سازد.

{{% alert color="warning" title="Warning" %}}
حذف وضعیت placeholder به‌طور خودکار تنظیمات ظاهر ارث‌بری‌شده را حفظ نمی‌کند. مثال زیر به‌ص knowingly تنظیمات را بدون تغییر می‌گذارد، بنابراین خروجی ممکن است متفاوت به‌نظر برسد. یک شکلی که موقعیت و اندازه‌اش به‌طور کامل ارث‌بری شده‌اند می‌تواند پس از فراخوانی مختصات و ابعاد صفر داشته باشد و حتی نامرئی شود، هرچند هنوز در مجموعه باقی می‌ماند.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // فراخوانی متد روی یک شکل عادی هیچ تأثیری ندارد.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

برای یک placeholder مطابق، هر سه بررسی `True` چاپ می‌شود. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، قلم، تراز پاراگراف، حاشیه‌های فریم متن، لنگر عمودی، پر کردن و تنظیمات خط می‌توانند هنگام حذف رابطه placeholder تغییر کنند. به‌عنوان مثال، قالب‌بندی عنوان ارث‌بری‌شده می‌تواند به قالب‌بندی متن عادی بازگردد. برای اطلاعات بیشتر درباره چیدمان‌ها، به [Slide Layout](/slides/fa/cpp/slide-layout/) مراجعه کنید.

برای حفظ ظاهر موردنظر، موقعیت، اندازه و چرخش حل‌شده را قبل از فراخوانی ذخیره کنید و مقادیر قالب‌بندی مؤثر موردنیاز را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/)، [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/)، [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/)، [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) و [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) دریافت کنید. فقط به اشیای مؤثر قالب‌بندی اطمینان نکنید، زیرا مقادیر قالب‌بندی متن آن‌ها پس از حذف رابطه می‌تواند تغییر کند. پس از آن، مقادیر ذخیره‌شده را به شکل عادی اعمال کنید، شامل خانواده قلم، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات فریم متن، پر کردن و خط مورد استفاده در قالب شما.

شکلی که به‌صورت ارث‌بری دریافت می‌کند ممکن است نیاز به تعیین صریح از طریق [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/) داشته باشد. برای یک placeholder متن مستطیلی، این به معنای تخصیص [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) است؛ تنها بازگرداندن پر کردن و خط ممکن است مستطیل قابل مشاهده را بازنشانی نکند. قالب‌هایی که اثرات اضافی یا قالب‌بندی پیچیده‌تر دارند نیز به‌همین تنظیمات نیاز دارند.

## **تغییر متن در یک placeholder**

Placeholderهای عنوان، عنوان‌متمرکز، زیرعنوان، متن اصلی و متن معمولاً از متن پشتیبانی می‌کنند. پیش از استفاده از متد [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) آن، از وجود [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) اطمینان حاصل کنید.

این مثال اولین placeholder عنوان در اسلاید اول را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌سازد:

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

این الگو از تبدیل placeholderهای تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین placeholder را بر اساس هدف شناسایی می‌کند نه بر اساس یک شاخص شکننده شکل.

## **تنظیم متن راهنما در یک چیدمان**

متن راهنما (prompt text) دستور زمان طراحی است که در یک placeholder خالی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. متن راهنمای سفارشی را بر روی placeholder چیدمان تنظیم کنید نه سعی در دسترسی به آن از طریق مجموعه شکل‌های اسلاید عادی. چیدمان را از طریق [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) دسترسی پیدا کنید و بر روی [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/) پیمایش کنید.

مثال زیر متن راهنمای عنوان و زیرعنوان را در چیدمانی که اسلاید اول از آن استفاده می‌کند، تغییر می‌دهد:

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

متن راهنما محتوای عادی اسلاید نیست. برای placeholderهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. هنگامی که یک کاربر یا برنامه محتوی واقعی را اضافه می‌کند، راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما نیز متن موجود در اسلایدهایی که از آن چیدمان استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک placeholder تصویر**

دو حالت برای رسیدگی وجود دارد:

- اگر placeholder تصویر قبلاً پر شده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) نمایش داده شود، تصویر را از طریق [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) و [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) جایگزین کنید.
- اگر هنوز یک placeholder خالی است، یک فریم تصویر را در مختصات placeholder با [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) اضافه کنید و placeholder خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌سازد:

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

جایگزینی که برای یک placeholder خالی ساخته می‌شود، یک فریم تصویر محلی است، نه یک placeholder جدید، زیرا [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) فقط‑خواندنی است. موقعیت رزرو‌شده را حفظ می‌کند اما دیگر رفتار خاص placeholder را ارث نمی‌برد. اگر حفظ رابطه placeholder ضروری است، ابتدا placeholder را در PowerPoint آماده و پر کنید، سپس [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر اثرات مخصوص تصویر، به [Manage Picture Frames](/slides/fa/cpp/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پر کردن تصویر تعلق دارند، نه به متادیتاهای placeholder.

## **کار با placeholderهای نمودار و محتوا**

یک placeholder نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) نمایش داده شود. این مثال چنین نموداری را با توجه به نوع placeholder و رابط زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک placeholder محتوای عمومی معمولاً دارای [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) است. در PowerPoint به‌عنوان یک راه‌انداز برای چندین نوع محتوا عمل می‌کند، از جمله نمودارها، جدول‌ها، دیاگرام‌ها، تصاویر و رسانه‌ها. پس از پر شدن، رابط شکل واقعی را بررسی کنید تا بفهمید چه چیزی درون آن است. چیدمان‌های تخصصی می‌توانند همچنین [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)، [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)، [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)، [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) یا [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/) را ارائه دهند.

Aspose.Slides یک placeholder خالی [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) را فقط با تغییر [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) به یک [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) تبدیل نمی‌کند؛ نوع فقط‑خواندنی است. برای پر کردن یک نمودار یا ناحیه محتوا به‌صورت برنامه‌نویسی، شیء موردنیاز را در مختصات placeholder اضافه کنید و سپس placeholder خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نمودار اضافه‌شده یک نمودار محلی عادی است. منطقه placeholder را اشغال می‌کند اما از placeholder چیدمان ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتاب کار، از مقالات اختصاصی مدیریت نمودارها ([chart management articles](/slides/fa/cpp/powerpoint-charts/)) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال پایان‑به‑پایان زیر یک قالب را باز می‌کند، اسلاید اول را برای یافتن یک placeholder عنوان یا تصویر جستجو می‌کند، نوع placeholder و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌سازد. این مثال عمدی است که از فرض وجود یک شاخص شکل یا تبدیل همه placeholderها به یک رابط یکسان خودداری می‌کند.

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

## **سوالات متداول**

**یک placeholder پایه چیست؟**

یک placeholder پایه شکل متناظر در چیدمان یا اسلاید اصلی است که از آن placeholder دیگری ارث می‌برد. برای به‌دست‌آوردن آن از [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) استفاده کنید. یک شکل محلی عادی `nullptr` برمی‌گرداند زیرا جز سلسله‌مراتب placeholder نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک placeholder چیدمان تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنما را از طریق چیدمان تغییر دهید، اما محتوای واقعی عناوین در اسلایدهای عادی ذخیره شده‌اند. برای جایگزینی متن عناوین در سراسر ارائه، باید بر روی اسلایدها پیمایش کنید و هر placeholder عنوان را به‌روزرسانی کنید.

**چگونه placeholderهای تاریخ، شماره اسلاید، سرصفحه و پاصفحه را مدیریت کنم؟**

از مدیران سرصفحه و پاصفحه در محدوده اسلاید، چیدمان، اسلاید اصلی، یادداشت یا جزوه مناسب استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/cpp/presentation-header-and-footer/) مراجعه کنید.