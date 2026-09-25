---
title: مدیریت اشکال ارائه در C++
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/cpp/shape-manipulations/
keywords:
- اشکال پاورپوینت
- اشکال ارائه
- شکل در اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه شکل interop
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌تنظیم شکل
- هندسه شکل
- قالب‌بندی‌های طرح‌بندی شکل
- شکل به عنوان SVG
- تبدیل شکل به SVG
- تراز کردن شکل
- چرخاندن شکل
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، تنظیم، کلون، حذف، مخفی، ترتیب‌گذاری مجدد، صادر، تراز و چرخاندن کنید با Aspose.Slides برای C++."
---
## **نمای کلی**

Aspose.Slides برای C++ اشکال موجود در یک اسلاید را به‌صورت یک [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) مرتب نشان می‌دهد. این مجموعه هم‌مرجع یافتن و تغییر اشکال است و هم منبع ترتیب انباشت آن‌ها: شاخص `0` نشانهٔ عقب‌ترین شکل است، در حالی که آخرین شاخص نشانگر شکل جلویی است.

این مقاله بر این مدل استوار است. ابتدا چگونگی شناسایی قابل اعتماد یک شکل و تغییر نقاط تنظیم پیش‌فرض شکل را توضیح می‌دهد، سپس نحوهٔ کلون‌کردن، حذف، مخفی‌کردن و تغییر ترتیب اشکال را نشان می‌دهد. بخش‌های نهایی به قالب‌بندی سطح طرح‌بندی، خروجی SVG، تراز کردن و تنظیمات چرخش می‌پردازند. هر مثال به‌صورت مستقل است، بنابراین می‌توانید تنها عملیاتی که جریان کاری شما به آن نیاز دارد را استفاده کنید.

## **شناسایی و یافتن اشکال**

شاخص‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مناسب هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند شاخص آن را تغییر دهد. شناسه‌ای را متناسب با نحوهٔ ایجاد و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به راحتی قابل مشاهده است. نام‌ها قابل ویرایش‌اند و تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است یک قرارداد نام‌گذاری برقرار کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_alternativetext/) زمانی مفید است که یک توصیف دسترسی یا برچسبی که توسط نویسنده ارائه شده است، پیشاپیش شکل را شناسایی کند. این متن برای کاربران قابل رؤیت است، می‌تواند بومی‌سازی یا برای دسترسی بازنویسی شود و تضمین نمی‌شود که یکتا باشد. متن دسترسی معنادار را به‌صورت ساکت به‌عنوان کلید پایگاه‌داده بازنگری نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_officeinteropshapeid/) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا است و با شناسهٔ شکلی که PowerPoint استفاده می‌کند، مطابقت دارد. هنگام ادغام با PowerPoint یا زمانی که به یک مرجع واضح در طول حیات شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازساخته، شکل دیگری است و شناسهٔ خود را دریافت می‌کند.

ویژگی مرتبط [UniqueId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_uniqueid/) دامنهٔ ارائه دارد، اما برای افزودنی‌ها در نظر گرفته شده و می‌تواند بازتخصیص یابد. نباید به‌عنوان کلید خارجی دائمی درنظر گرفته شود. اگر هویت طولانی‌مدت ضرورت دارد، نگاشتی را در داده‌های برنامه نگه‌دارید و اطمینان حاصل کنید که شکل مورد انتظار هنوز وجود دارد.

برای مثال عملی از خواندن و به‌روزرسانی هم عنوان متن جایگزین و هم توضیح، به [Manage Alternative Text Titles and Descriptions](/slides/fa/cpp/presentation-accessibility/) مراجعه کنید. متن جایگزین را برای توضیح معنی بصری به خوانندگان استفاده کنید و آن را از نام‌های اشکالی که کد برای یافتن آن‌ها استفاده می‌کند، جدا نگه دارید.

مثال زیر با `Name` جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شکل مورد انتظار را نداشته باشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

هنگامی که عملیاتی خاص به نوعی از شکل مربوط است، قبل از استفاده از اعضای نوع‑خاص، رابط را بررسی کنید. این مثال متن و متن جایگزین را تنها در صورتی به‌روزرسانی می‌کند که شیء نام‌دار از نوع [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) باشد.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **شناسایی و تغییر تنظیمات پیش‌فرض شکل**

اشکال هندسی پیش‌فرض می‌توانند نقاط تنظیمی را نشان دهند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت‌های پیکان یا زوایای قوس را کنترل می‌کند. به آن‌ها از طریق مجموعهٔ فقط‑خواندنی [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igeometryshape/get_adjustments/) دسترسی پیدا کنید. خود مجموعه توسط شکل فراهم می‌شود، اما هر [IAdjustValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/) مقداری دارد که می‌توان آن را تغییر داد.

فقط به یک شاخص ثابت در مجموعه اطمینان نکنید. از طریق تنظیمات پیمایش کنید و ویژگی فقط‑خواندنی [IAdjustValue::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/get_type/) را بررسی کنید؛ مقدار [ShapeAdjustmentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapeadjustmenttype/) توصیف می‌کند که تنظیم چه چیزی را کنترل می‌کند. ویژگی فقط‑خواندنی [IAdjustValue::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/get_name/) اطلاعات شناسایی اضافی ارائه می‌دهد و بخصوص وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی دارد، مفید است.

از ویژگی مقدار متناسب با معنای تنظیم استفاده کنید:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [RawValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | ضخامت انتهای پیکان | `RawValue` |
| `ArrowheadLength` | طول سر پیکان | `RawValue` |
| `ArrowheadWidth` | عرض سر پیکان | `RawValue` |
| `StartAngle` | زاویهٔ شروع دایره یا قوس | [AngleValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | زاویهٔ پایان دایره یا قوس | `AngleValue` |

`Type` و `Name` قابل انتساب نیستند. `RawValue` یک عدد صحیح خواندنی/قابل نوشتن در واحدهای هندسی بومی پیش‌تنظیم است، در حالی که `AngleValue` یک زاویهٔ خواندنی/قابل نوشتن بر حسب درجه است. تعداد، ترتیب، معنی و بازهٔ معتبر تنظیمات به [ShapeType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igeometryshape/get_shapetype/) پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است، ممکن است برای پیش‌تنظیم دیگر نامعتبر یا اثر متفاوتی داشته باشد.

هنگامی که `Type` برابر `ShapeAdjustmentType::Custom` باشد، API معنای معنایی استانداردی را تشخیص نمی‌دهد. `Name`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست نخورده بگذارید مگر اینکه معنی و بازهٔ مورد انتظار شناخته شده باشد. حتی برای انواع شناخته‌شده، پیش از انتخاب مقدار بررسی کنید که آیا همان نوع بیش از یک بار ظاهر می‌شود یا نه. مقالهٔ [Connector](/slides/fa/cpp/connector/) این وضعیت را با تنظیمات انحنای کانکتور نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و تغییر یافتهٔ سه شکل پیش‌تنظیم‌شده را می‌سازد. هر تنظیم را پیمایش می‌کند، `Name` و `Type` آن را گزارش می‌دهد، مقادیر مرتبط با اندازه را از طریق `RawValue` تغییر می‌دهد، زوایا را از طریق `AngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسه پیش‌فرض را حفظ می‌کند؛ ستون راست مستطیل گرد تنظیم‌شده، پیکان چهارطرفه و دایره را نشان می‌دهد.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// سرصفحه‌ها را برای ستون‌های شکل پیش‌فرض و تنظیم‌شده اضافه می‌کند.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

بررسی نوع معنایی قبل از تغییر یک مقدار کد را شفاف می‌کند و از فرض اینکه یک شاخص خاص در تمام اشکال پیش‌تنظیم‌شده یک معنی ثابت دارد، جلوگیری می‌کند.

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و تغییر ترتیب بلافاصله بر مجموعه اعمال می‌شوند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، دیگر به شاخص‌هایی که پیش از آن عملیات گرفته‌اید تکیه نکنید.

### **کلون کردن یک شکل**

[AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addclone/) یک نسخه مستقل می‌سازد و به انتهای مجموعه هدف اضافه می‌کند. [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/insertclone/) نیز یک نسخه می‌سازد اما آن را در یک شاخص z‑order مشخص می‌گذارد. بارگذاری‌هایی که مختصات می‌پذیرند کلون را بدون تغییر اندازه جابجا می‌کنند؛ بارگذاری‌هایی با عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال زیر یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلوی اسلاید کلون می‌کند و یک کلون دوم را در پشت درج می‌کند. تغییرات بر روی هر دو کلون منجر به تغییر شکل منبع نمی‌شود.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

کلون‌کردن محتوا و قالب‌بندی شکل را کپی می‌کند، از جمله نام و متن جایگزین آن. هنگامی که این مقادیر باید یکتا باشند شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع مورد استفادهٔ اشکال پیچیده توسط ارائه مدیریت می‌شود، اما یک کلون همچنان یک آیتم جدید در مجموعه با هویت جدید شکل است.

### **حذف اشکال**

[Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/remove/) یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین مطابقت در طول پیمایش شاخص‌دار، از انتها به جلو پیمایش کنید تا هر شاخص باقی‌مانده معتبر بماند.

این مثال هر شکلی را که نام مشخصی داشته باشد حذف می‌کند. شکل شاخص‌دار فعلی را می‌خواند، نه یک آیتم ثابت از مجموعه، و شکل را بدون تبدیل غیرضروری به نوع دیگر استفاده می‌کند.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

بعد از حذف، تعداد اشکال و شاخص‌های اشکال بعدی تغییر می‌کنند. ارجاعات به اشکال بدون تغییر نسبت به شاخص‌های ذخیره‌شده قابل اعتمادتر هستند. همچنین به کانکتورها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **مخفی‌کردن یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_hidden/) به `true` شکل را در مجموعه باقی می‌گذارد اما از نمایش در اسلایدشو معمولی جلوگیری می‌کند. شاخص، قالب‌بندی و محتویات آن برای کد در دسترس می‌مانند، بنابراین مخفی‌کردن برای عناصری که ممکن است بعدها بازیابی شوند مناسب است.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

مخفی‌کردن حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و دوباره نمایش داده شود و همچنان بخشی از فایل ارائه است.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده بر اساس ترتیب مجموعه رنگ می‌شوند. [Reorder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/reorder/) یک شکل موجود را به شاخص هدف منتقل می‌کند بدون این که آن را کلون کند. شاخص `0` پشت‌ترین است؛ `Count - 1` جلویی‌ترین.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

در ابتدا مستطیل ساخته می‌شود و در پشت بیضی قرار می‌گیرد. جابجایی آن به شاخص نهایی آن را به جلو می‌برد. پس از افزودن یا کلون کردن تمام اشکال مرتبط، ترتیب z‑order را نهایی کنید، زیرا آن عملیات‌ها آیتم‌های جدیدی به مجموعه اضافه یا درج می‌کنند و ممکن است پشتهٔ موردنظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای طرح‌بندی**

اسلایدهای عادی، اسلایدهای طرح‌بندی و اسلایدهای مستر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ طرح‌بندی شیء‌ای برابر با شکل موقعیت‌دار مشابه در یک اسلاید عادی نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک طرح‌بندی، اشکال طرح‌بندی را بررسی کنید.

مثال زیر `FillFormat` و `LineFormat` هر شکل طرح‌بندی را می‌خواند بدون این‌که فرض کند هر شکل یک `AutoShape` است.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

ویرایش یک طرح‌بندی می‌تواند چندین اسلایدی را که از آن استفاده می‌کنند تحت تأثیر قرار دهد. قبل از تغییر شکل طرح‌بندی، تعیین کنید آیا اسلاید عادی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که از آن طرح‌بندی استفاده می‌کند را آزمایش کنید.

## **صادر کردن یک شکل به SVG**

[WriteAsSvg](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/writeassvg/) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل خود شکل است، نه پس‌زمینهٔ کامل اسلاید یا اشکال همسایه.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

در حین رندر، ارائه باز بماند. خروجی به قالب‌بندی شکل و به منابعی مانند فونت‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل جداگانه صادر کنید. فراخواننده مالک جریان است و باید آن را بسته یا از بین ببرد.

## **تراز کردن اشکال**

متدهای [SlideUtil::AlignShapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/alignshapes/) می‌توانند همهٔ اشکال یا شاخص‌های منتخب را تراز کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapesalignmenttype/) لبه، خط مرکزی یا حالت توزیع را مشخص می‌کند. `alignToSlide` را به `true` تنظیم کنید تا لبه‌های اسلاید استفاده شوند؛ به `false` تنظیم کنید تا اشکال منتخب نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالایی اسلاید تراز می‌کند. ارجاعات به شکل‌های بازگردانده‌شده بلافاصله قبل از تراز به شاخص‌های جاریشان تبدیل می‌شوند.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تراز کردن موقعیت‌ها را تغییر می‌دهد، نه ترتیب z‑order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به اندازهٔ کافی شکل برای تعریف فاصله نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، شاخص‌ها را دوباره محاسبه کنید.

## **چرخاندن (Flip) یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات چرخش افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `FlipH` و `FlipV` از نوع [NullableBool](https://reference.aspose.com/slides/fa/cpp/aspose.slides/nullablebool/) استفاده می‌کنند: `True` چرخش را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت نامشخص/پیش‌فرض را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون چرخش است.

![شکل قبل از چرخش](shape_to_be_flipped.png)

مثال تمام مقادیر دیگر Frame را حفظ می‌کند و فقط دو تنظیم چرخش را جایگزین می‌کند. این مهم است زیرا تخصیص یک [Frame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_frame/) جدید، کل Frame را بازنویسی می‌کند.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

شکل ذخیره‌شده به صورت افقی و عمودی معکوس می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![شکل پس از چرخش](flipped_shape.png)

## **پرسش‌های متداول**

**آیا باید از شاخص مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه پیش از استفاده از شاخص تغییر نخواهد کرد. برای قالب‌های ساخته‌شده، ترجیحاً از یک قرارداد معتبر `Name` یا `AlternativeText` استفاده کنید، یا برای کارهای مبتنی بر interop در اسلاید از `OfficeInteropShapeId`.

**آیا مخفی‌کردن یک شکل آن را از z‑order حذف می‌کند؟**

خیر. یک شکل مخفی در همان شاخص در مجموعه باقی می‌ماند. می‌توان آن را یافت، دوباره ترتیب داد، ویرایش یا دوباره قابل مشاهده کرد.

**چرا یک شکل کلون‌شده جلوتر از شکل دیگری ظاهر شد؟**

`AddClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی z‑order است. برای انتخاب شاخص اولیه از `InsertClone` استفاده کنید یا پس از افزودن تمام اشکال از `Reorder` بهره‌بگیرید.

**آیا می‌توان از یک شاخص ثابت برای شناسایی تنظیم پیش‌تنظیم شکل استفاده کرد؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و چیدمان مجموعه. ترجیحاً از طریق `IGeometryShape::get_Adjustments` پیمایش کنید و `IAdjustValue::get_Type` را بررسی کنید؛ هنگام تکرار نوع معنایی، از `IAdjustValue::get_Name` به عنوان اطلاعات تکمیلی استفاده کنید.