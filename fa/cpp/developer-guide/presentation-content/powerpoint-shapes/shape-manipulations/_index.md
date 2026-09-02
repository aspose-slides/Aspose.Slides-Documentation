---
title: مدیریت اشکال ارائه در C++
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/cpp/shape-manipulations/
keywords:
- اشکل PowerPoint
- اشکل ارائه
- اشکل روی اسلاید
- یافتن شکل
- کلون‌کردن شکل
- حذف شکل
- پنهان کردن شکل
- تغییر ترتیب شکل
- دریافت شناسهٔ interop شکل
- متن جایگزین شکل
- نقطه تنظیم شکل
- تنظیم پیش‌تنظیم شدهٔ شکل
- هندسهٔ شکل
- قالب‌بندی‌های طرح‌بندی شکل
- شکل به صورت SVG
- تبدیل شکل به SVG
- تراز کردن شکل
- وارون‌کردن شکل
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را با Aspose.Slides برای C++ شناسایی، تنظیم، کلون‌کردن، حذف، پنهان‌کردن، تغییر ترتیب، خروجی‌گیری، تراز کردن و وارون‌کردن کنید."
---
## **مروری**

Aspose.Slides for C++ اشکال موجود در یک اسلاید را به عنوان یک ‎[IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/)‎ مرتب‌شده نمایش می‌دهد. این مجموعه هم مکانی است که می‌توانید اشکال را پیدا و ویرایش کنید و هم منبع ترتیب لایه‌ای آن‌ها: اندیس `0` پایین‌ترین شکل است و آخرین اندیس بالاترین شکل را نشان می‌دهد.

این مقاله بر همان مدل استوار است. ابتدا نحوه شناسایی قابل‌اعتماد یک شکل و ویرایش نقاط تنظیم پیش‌تنظیم‌شدهٔ شکل را توضیح می‌دهد، سپس نحوهٔ کلون‌کردن، حذف، پنهان‌کردن و تغییر ترتیب اشکال را نشان می‌دهد. بخش‌های نهایی به قالب‌بندی در سطح طرح‌بندی، خروجی SVG، تراز و تنظیمات وارون‌کردن می‌پردازند. هر مثال به‌صورت مستقل است، بنابراین می‌توانید تنها عملیاتی را که در جریان کارتان نیاز دارید، به کار ببرید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده مفید هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند اندیس آن را تغییر دهد. یک شناسه را بر اساس نحوهٔ نگارش و نگهداری ارائه‌نامه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و به‌راحتی در پنل انتخاب پاورپوینت قابل مشاهده است. نام‌ها قابل ویرایش هستند و تضمین نمی‌شود یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است، یک قرارداد نام‌گذاری برقرار کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_alternativetext/) وقتی توصیف دسترس‌پذیری یا برچسبی توسط نویسنده پیش از این شکل را شناسایی می‌کند، مفید است. این متن برای کاربران قابل مشاهده است، می‌تواند محلی‌سازی یا بازنویسی برای دسترس‌پذیری شود و تضمین نمی‌شود یکتا باشد. متن معنادار دسترس‌پذیری را به‌طور خاموش به عنوان کلید دیتابیس استفاده نکنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_officeinteropshapeid/) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا بوده و به شناسهٔ شکلی که پاورپوینت برای هم‌بستگی استفاده می‌کند، مطابقت دارد. هنگام یکپارچه‌سازی با پاورپوینت یا زمانی که به مرجع بدون ابهامی در طول عمر یک شکل نیاز دارید، از آن استفاده کنید. یک شکل کلون‌شده یا دوباره‌ساخته شکل دیگری است و شناسهٔ خودش را دریافت می‌کند.

ویژگی مرتبط ‎[UniqueId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_uniqueid/)‎ حوزهٔ ارائه‌نامه را در بر می‌گیرد، اما برای افزودنی‌ها در نظر گرفته شده و می‌تواند دوباره‌تخصیص یابد. نباید آن را به‌عنوان کلید خارجی دائمی در نظر گرفت. اگر هویت طولانی‌مدت لازم است، نگاشت را در داده‌های برنامه نگه دارید و اعتبارسنجی کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با استفاده از `Name` جستجو می‌کند و شناسهٔ interop مخصوص اسلاید را گزارش می‌دهد. وقتی قالب حاوی شکل مورد انتظار نیست، کد همان نتیجه را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

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

هنگامی که عملیاتی به نوع خاصی از شکل مربوط می‌شود، پیش از استفاده از اعضای خاص نوع، رابط مربوطه را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روزرسانی می‌کند که شیء نام‌دار یک ‎[IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/)‎ باشد.

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

## **شناسایی و اصلاح تنظیمات پیش‌تنظیم اشکال**

اشکال هندسی پیش‌تنظیم می‌توانند نقاط تنظیمی داشته باشند که ویژگی‌هایی مانند اندازهٔ گوشه، نسبت‌های پیکان یا زاویهٔ قوس را کنترل می‌کنند. از مجموعهٔ فقط‑خواندنی ‎[IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igeometryshape/get_adjustments/)‎ به آن‌ها دسترسی پیدا کنید. خود مجموعه توسط شکل ارائه می‌شود، اما هر ‎[IAdjustValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/)‎ شامل مقداری است که می‌توان آن را تغییر داد.

به تنها اندیس ثابت مجموعه اطمینان نکنید. بر روی تنظیمات پیمایش کنید و ویژگی فقط‑خواندنی ‎[IAdjustValue::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/get_type/)‎ را بررسی کنید؛ مقدار ‎[ShapeAdjustmentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapeadjustmenttype/)‎ توصیف می‌کند که تنظیم چه چیزی را کنترل می‌کند. ویژگی فقط‑خواندنی ‎[IAdjustValue::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/get_name/)‎ اطلاعات شناسایی تکمیلی فراهم می‌کند و به‌ویژه وقتی یک پیش‌تنظیم بیش از یک تنظیم با همان نوع معنایی دارد، مفید است.

از ویژگی مقدار متناسب با معنای تنظیم استفاده کنید:

| نوع تنظیم | هدف | مقدار برای تغییر |
|---|---|---|
| `CornerSize` | اندازهٔ گوشه‌های گرد | [RawValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | ضخامت دم‌پیکان | `RawValue` |
| `ArrowheadLength` | طول سر پیکان | `RawValue` |
| `ArrowheadWidth` | عرض سر پیکان | `RawValue` |
| `StartAngle` | زاویهٔ شروع یک دایره یا قوس | [AngleValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | زاویهٔ پایان یک دایره یا قوس | `AngleValue` |

`Type` و `Name` قابل انتساب نیستند. `RawValue` یک عدد صحیح قابل خواندن/نوشتن در واحدهای هندسی بومی پیش‌تنظیم است، در حالی که `AngleValue` یک زاویهٔ قابل خواندن/نوشتن بر حسب درجه است. تعداد، ترتیب، معنای و بازهٔ معتبر تنظیمات به ‎[ShapeType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igeometryshape/get_shapetype/)‎ پیش‌تنظیم وابسته است. مقداری که برای یک پیش‌تنظیم معتبر است ممکن است برای پیش‌تنظیم دیگری نامعتبر یا اثر متفاوتی داشته باشد.

زمانی که `Type` برابر با `ShapeAdjustmentType::Custom` باشد، API معنایی استانداردی برای آن شناسایی نمی‌کند. `Name`، نوع پیش‌تنظیم و مقدار موجود را بررسی کنید و تنظیم را دست‌نکرده بگذارید مگر اینکه معنای مورد انتظار و بازهٔ آن را بدانید. حتی برای انواع شناخته‌شده، قبل از انتخاب مقدار بررسی کنید که آیا همان نوع بیش از یک بار ظاهر می‌شود یا نه. مقاله ‎[Connector](/slides/fa/cpp/connector/)‎ این وضعیت را با تنظیمات انحنای کانکتور نشان می‌دهد.

مثال کامل زیر نسخه‌های پیش‌فرض و اصلاح‌شدهٔ سه شکل پیش‌تنظیم‌شده را ایجاد می‌کند. بر روی هر تنظیم پیمایش می‌کند، `Name` و `Type` آن را گزارش می‌دهد، مقادیر مرتبط با اندازه را از طریق `RawValue` و زاویه‌ها را از طریق `AngleValue` تغییر می‌دهد و نتیجه را ذخیره می‌کند. ستون چپ هندسهٔ پیش‌فرض را حفظ می‌کند؛ ستون راست مستطیل گرد، پیکان چهارطرفه و دایرهٔ قطعی تنظیم‌شده را نمایش می‌دهد.

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

// افزودن سرصفحه‌ها برای ستون‌های شکل پیش‌فرض و تنظیم‌شده.
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

بررسی نوع معنایی قبل از تغییر مقدار، کد را صریحاً نسبت به هدفش می‌کند و از فرض اینکه اندیس خاصی در تمام پیش‌تنظیم‌ها همان معنا را دارد جلوگیری می‌نماید.

## **اصلاح مجموعهٔ اشکال**

متدهای افزودن، کلون‌کردن، حذف و تغییر ترتیب بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن دیگر نباید به اندیس‌های گرفته‌شده قبل از عملیات تکیه کرد.

### **کلون‌کردن یک شکل**

‎[AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addclone/)‎ یک نسخهٔ مستقل ایجاد می‌کند و آن را به انتهای مجموعه هدف اضافه می‌نماید. ‎[InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/insertclone/)‎ نیز یک نسخه می‌سازد اما در اندیس z‑order مشخصی جای می‌دهد. بارگذاری‌های پذیرفتن مختصات کلون را بدون تغییر اندازه جابه‌جا می‌کند؛ بارگذاری‌های شامل عرض و ارتفاع می‌توانند اندازه را نیز تغییر دهند.

مثال یک اسلاید مقصد ایجاد می‌کند، مستطیل برچسب‌دار را به جلو کلون می‌کند و کلون دوم را به پشت وارد می‌نماید. تغییرات بر روی هر یک از کلون‌ها شکل منبع را تحت تأثیر قرار نمی‌دهد.

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

کلون‌کردن محتوا و قالب‌بندی شکل را، شامل نام و متن جایگزین، کپی می‌کند. هنگامیکه این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع استفاده‌شده توسط اشکال پیچیده توسط ارائه‌نامه مدیریت می‌شوند، اما یک کلون به‌عنوان یک آیتم جدید در مجموعه با هویت شکل جدید باقی می‌ماند.

### **حذف اشکال**

‎[Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/remove/)‎ یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین مطابقت در طی iteration ایندکس‌دار، از انتها به ابتدا پیمایش کنید تا هر ایندکس باقی‌مانده معتبر بماند.

این مثال هر شکلی با نام تعیین‌شده را حذف می‌کند. شکل فعلی بر اساس ایندکس فعلی خوانده می‌شود، نه یک آیتم ثابت از مجموعه، و نیازی به تبدیل نوع غیرضروری شکل نیست.

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

پس از حذف، تعداد اشکال و ایندکس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکالی که تحت تأثیر حذف قرار نگرفته‌اند، نسبت به ایندکس‌های ذخیره‌شده معتبرتر است. همچنین به اتصال‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **پنهان‌کردن یک شکل**

تنظیم ‎[Hidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_hidden/)‎ روی `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در اسلاید شو عادی جلوگیری می‌کند. ایندکس، قالب‌بندی و محتوا همچنان در دسترس کد باقی می‌مانند، بنابراین پنهان‌کردن برای عناصر اختیاری که ممکن است بعداً بازیابی شوند، مناسب است.

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

پنهان‌کردن حذف یا امنیت نیست. شیء می‌تواند توسط کاربر یا کد کشف و دوباره نمایان شود و همچنان بخشی از فایل ارائه‌نامه می‌ماند.

### **تغییر ترتیب Z**

اشکال همپوشانی‌شده به ترتیب مجموعه‌رنگ می‌شوند. ‎[Reorder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/reorder/)‎ یک شکل موجود را به اندیس هدفی منتقل می‌کند بدون اینکه آن را کلون کند. اندیس `0` پشت‌ترین، `Count - 1` جلوی‌ترین است.

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

در ابتدا مستطیل ساخته می‌شود و پشت بیضی قرار می‌گیرد. جابه‌جا کردن آن به اندیس نهایی آن را به جلو می‌آورد. ترتیب Z را پس از افزودن یا کلون‌کردن تمام اشکال مرتبط نهایی کنید، زیرا این عملیات آیتم‌های جدیدی را به مجموعه اضافه یا وارد می‌کنند و می‌توانند پشتهٔ موردنظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای طرح‌بندی**

اسلایدهای عادی، اسلایدهای طرح‌بندی و اسلایدهای مستر مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ طرح‌بندی همان شیء‌ای نیست که در اسلاید عادی با موقعیت مشابه قرار دارد. هنگام نیاز به درک یا تغییر قالب‌بندی فراهم‌شده توسط یک طرح‌بندی، به اشکال طرح‌بندی مراجعه کنید.

مثال زیر ‎[FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_fillformat/)‎ و ‎[LineFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_lineformat/)‎ هر شکل طرح‌بندی را می‌خواند بدون اینکه فرض کند هر شکل یک `AutoShape` است.

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

ویرایش یک طرح‌بندی می‌تواند بر اسلایدهای متعددی که از آن استفاده می‌کنند تأثیر بگذارد. پیش از تغییر یک شکل طرح‌بندی، تعیین کنید آیا اسلاید عادی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که از آن طرح‌بندی استفاده می‌کند را تست کنید.

## **صادر کردن یک شکل به SVG**

‎[WriteAsSvg](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/writeassvg/)‎ محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل خود شکل است، نه پس‌زمینهٔ تمام اسلاید یا اشکال همجوار.

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

در زمان رندر، ارائه‌نامه باز بماند. خروجی به قالب‌بندی شکل و به منابعی مثل قلم‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، به جای یک شکل منفرد اسلاید را صادر کنید. فراخواننده مالک جریان است و باید آن را ببندد یا تخلیه کند.

## **تراز کردن اشکال**

متد ‎[SlideUtil::AlignShapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/alignshapes/)‎ می‌تواند همهٔ اشکال یا اندیس‌های انتخابی مجموعه را تراز کند. ‎[ShapesAlignmentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapesalignmenttype/)‎ لبه، مرکز یا حالت توزیع را مشخص می‌کند. `alignToSlide` را روی `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ روی `false` تنظیم کنید تا اشکال انتخابی نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالای اسلاید تراز می‌کند. مراجع شکل بازگردانده‌شده بلافاصله قبل از تراز به ایندکس‌های فعلی خود تبدیل می‌شوند.

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

تراز موقعیت‌ها را تغییر می‌دهد، نه ترتیب Z. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی برای تعیین فواصل به تعداد کافی شکل نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، ایندکس‌ها را مجدداً محاسبه کنید.

## **وارون‌کردن یک شکل**

کلاس ‎[ShapeFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapeframe/)‎ موقعیت، اندازه، تنظیمات وارون‌کردن افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `FlipH` و `FlipV` از ‎[NullableBool](https://reference.aspose.com/slides/fa/cpp/aspose.slides/nullablebool/)‎ استفاده می‌کنند: `True` وارون‌کردن را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت نامشخص/پیش‌فرض را حفظ می‌کند.

ارائه‌نامهٔ ورودی زیر شامل یک شکل بدون وارون‌کردن است.

![شکل قبل از وارون‌کردن](shape_to_be_flipped.png)

این مثال تمام مقادیر دیگر قاب را حفظ می‌کند و فقط دو تنظیم وارون‌کردن را جایگزین می‌نماید. این مهم است چون اختصاص یک ‎[Frame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_frame/)‎ جدید، کل قاب را بازنویسی می‌کند.

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

شکل ذخیره‌شده به صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![شکل پس از وارون‌کردن](flipped_shape.png)

## **پرسش‌های متداول**

**آیا باید از اندیس مجموعه به‌عنوان شناسهٔ یک شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه قبل از استفاده از اندیس تغییر نخواهد کرد. برای قالب‌های نوشته‌شده، ترجیحاً از یک قرارداد معتبر `Name` یا `AlternativeText` استفاده کنید، یا برای کارهای هم‌بستگی اسلاید‑محدود `OfficeInteropShapeId` را به کار ببرید.

**آیا پنهان‌کردن یک شکل آن را از ترتیب Z حذف می‌کند؟**

خیر. یک شکل پنهان در همان اندیس در مجموعه باقی می‌ماند. می‌توان آن را یافت، دوباره‌مرتب‌سازی، ویرایش یا دوباره قابل مشاهده کرد.

**چرا یک شکل کلون‌شده جلوی شکل دیگری ظاهر شد؟**

`AddClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی ترتیب Z محسوب می‌شود. برای انتخاب اندیس اولیه از `InsertClone` استفاده کنید یا پس از افزودن همهٔ اشکال از `Reorder` بهره ببرید.

**آیا می‌توانم با استفاده از یک اندیس ثابت، تنظیم پیش‌تنظیم یک شکل را شناسایی کنم؟**

فقط پس از اعتبارسنجی دقیق پیش‌تنظیم و چیدمان مجموعه. ترجیحاً از ‎`IGeometryShape::get_Adjustments`‎ پیمایش کنید و `IAdjustValue::get_Type` را بررسی کنید؛ وقتی همان نوع معنایی بیش از یک بار ظاهر می‌شود، از `IAdjustValue::get_Name` به عنوان اطلاعات تکمیلی استفاده کنید.