---
title: مدیریت اشکال ارائه در C++
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/cpp/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل در اسلاید
- یافتن شکل
- کلون شکل
- حذف شکل
- پنهان کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه شکل interop
- متن جایگزین شکل
- قالب‌بندی‌های طرح‌بندی شکل
- شکل به صورت SVG
- شکل به SVG
- هم‌ترازی شکل
- معکوس کردن شکل
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را با Aspose.Slides برای C++ شناسایی، کلون، حذف، پنهان، دوباره ترتیب‌دهی، صادر، هم‌ترازی و معکوس کنید."
---
## **نمای کلی**

Aspose.Slides for C++ اشکال موجود در یک اسلاید را به عنوان یک [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/) مرتب‌شده نمایش می‌دهد. این مجموعه هم مکانی است که می‌توانید اشکال را پیدا کنید و تغییر دهید و هم منبع ترتیب لایه‌بندی آن‌ها: ایندکس `0` پایین‌ترین شکل است، در حالی که آخرین ایندکس بالاترین شکل است.

این مقاله بر این مدل استوار است. ابتدا نحوه شناسایی یک شکل به‌صورت قابل‌اعتماد را توضیح می‌دهد، سپس نشان می‌دهد چگونه می‌توان اشکال را کلون، حذف، پنهان و دوباره ترتیب داد. بخش‌های نهایی به قالب‌بندی در سطح طرح‌بندی، صادرات SVG، هم‌ترازی و تنظیمات چرخش می‌پردازند. هر مثال مستقل است، بنابراین می‌توانید تنها عملیاتی را که در جریان کاری‌تان نیاز دارید استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه در پردازش یک فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا دوباره ترتیب دادن یک شکل می‌تواند اندیس آن را تغییر دهد. یک شناسه را بر اساس نحوهٔ نگارش و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به‌راحتی قابل‌مشاهده است. نام‌ها قابل ویرایش‌اند و تضمین می‌شود که یکتا نباشند، بنابراین در صورت وابستگی کد به آن‌ها یک قرارداد نام‌گذاری برقرار کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_alternativetext/) زمانی مفید است که یک توضیح دسترس‌پذیری یا برچسبی که توسط نویسنده ارائه شده است، پیش از این شکل را شناسایی کند. این متن برای کاربران قابل‌مشاهده است، ممکن است برای دسترس‌پذیری بومی‌سازی یا بازنویسی شود و تضمین نمی‌شود یکتا باشد. از استفادهٔ ساکتانه از متن معنادار دسترسی به‌عنوان کلید پایگاه داده خودداری کنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_officeinteropshapeid/) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا بوده و با شناسهٔ شکلی که PowerPoint interop استفاده می‌کند، مطابقت دارد. زمانی که با PowerPoint ادغام می‌کنید یا به یک مرجع غیرقابل‌تردید در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون شده یا بازسازی‌شده شکل دیگری است و شناسهٔ خود را دریافت می‌کند.

ویژگی مرتبط [UniqueId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_uniqueid/) دارای حوزهٔ ارائه است، اما برای افزونه‌ها در نظر گرفته می‌شود و می‌تواند دوباره اختصاص یابد. نباید به‌عنوان کلید خارجی دائمی استفاده شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه داشته و صحت شکل مورد انتظار را اعتبارسنجی کنید.

مثال زیر با `Name` جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد آن نتیجه را گزارش می‌کند به‌جای ادامه با شیء اشتباه.

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

زمانی که یک عملیات مختص به نوعی از شکل است، قبل از استفاده از اعضای نوع‑خاص، رابط مربوطه را بررسی کنید. این مثال متن و متن جایگزین را تنها در صورتی به‌روزرسانی می‌کند که شیء نام‌دار یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) باشد.

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

## **تعدیل مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و دوباره ترتیب دادن بلافاصله روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر داد، پس از آن دیگر به اندیس‌های ضبط‌شده قبل از آن عملیات تکیه نکنید.

### **کلون کردن یک شکل**

[AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addclone/) یک کپی مستقل ایجاد می‌کند و به انتهای مجموعه هدف اضافه می‌نماید. [InsertClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/insertclone/) نیز یک کپی ایجاد می‌کند اما آن را در یک اندیس z‑order مشخص قرار می‌دهد. نسخه‌های overloadی که مختصات را می‌پذیرند، کلون را بدون تغییر اندازه منتقل می‌کنند؛ overloadهایی با عرض و ارتفاع می‌توانند آن را نیز تغییر اندازه دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و یک کلون دوم را در عقب درج می‌کند. تغییرات در هر دو کلون شکل منبع را تحت تأثیر قرار نمی‌دهند.

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

کلون کردن محتوا و قالب‌بندی شکل را کپی می‌کند، از جمله نام و متن جایگزین آن. هنگامی که این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع مصرف‌شده توسط اشکال پیچیده توسط ارائه مدیریت می‌شود، اما یک کلون یک مورد جدید در مجموعه با هویت شکلی جدید باقی می‌ماند.

### **حذف اشکال**

[Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/remove/) یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین تطابق در طول یک تکرار اندیسی، از انتها به سمت ابتدا پیش بروید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکل دارای نام تعیین‌شده‌ای را حذف می‌کند. شکل فعلی با اندیس خوانده می‌شود، نه یک مورد ثابت در مجموعه، و شکل به‌صورت غیرضروری تبدیل نوع نمی‌شود.

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

پس از حذف، شمارش اشکال و اندیس‌های اشکال بعدی تغییر می‌کند. ارجاعات به اشکال غیرقابل‌تأثیر نسبت به اندیس‌های ذخیره‌شده قابل‑اعتمادتر هستند. همچنین به اتصالات، انیمیشن‌ها و سایر ویژگی‌های ارائه‌ای که ممکن است به شیء حذف‌شده اشاره داشته باشند، توجه کنید؛ حذف یک شکل قابل‌مشاهده می‌تواند بیش از ظاهر اسلاید را تغییر دهد.

### **پنهان کردن یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_hidden/) به `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در نمایش اسلاید معمولی منع می‌کند. اندیس، قالب‌بندی و محتوای آن برای کد در دسترس می‌ماند، بنابراین پنهان‌سازی برای عناصر اختیاری که ممکن است بعدها بازگردانده شوند مناسب است.

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

پنهان‌سازی حذف یا امنیت نیست. این شیء همچنان قابل کشف و قابل نمایش مجدد توسط کاربر یا کد است و بخشی از فایل ارائه می‌ماند.

### **تغییر ترتیب Z**

اشکال همپوشانی‌شده به ترتیب مجموعه رنگ می‌شوند. [Reorder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/reorder/) یک شکل موجود را به یک اندیس هدف منتقل می‌کند بدون اینکه آن را کلون کند. اندیس `0` پشت صحنه است؛ `Count - 1` جلو صحنه.

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

مستطیل ابتدا ساخته می‌شود و در ابتدا پشت بیضی قرار دارد. جابجا کردن آن به اندیس نهایی آن را به جلو می‌برد. پس از افزودن یا کلون تمام اشکال مربوطه، ترتیب Z را نهایی کنید، زیرا این عملیات‌ها موارد جدیدی به مجموعه اضافه یا وارد می‌کنند و می‌توانند ترتیب موردنظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای طرح‌بندی**

اسلایدهای معمولی، اسلایدهای طرح‌بندی و اسلایدهای استاد دارای مجموعه‌های شکلی جداگانه هستند. یک شکل در مجموعهٔ طرح‌بندی همان شیء شکل در اسلاید معمولی با موقعیت مشابه نیست. زمانی که نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک طرح‌بندی دارید، اشکال طرح‌بندی را بررسی کنید.

مثال زیر هر شکل طرح‌بندی را با استفاده از [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_fillformat/) و [LineFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_lineformat/) می‌خواند بدون این‌که فرض کند هر شکلی یک `AutoShape` است.

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

ویرایش یک طرح‌بندی می‌تواند بر چندین اسلایدی که از آن استفاده می‌کنند تأثیر بگذارد. قبل از تغییر یک شکل طرح‌بندی، تعیین کنید آیا یک اسلاید معمولی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که از آن طرح‌بندی استفاده می‌کند را تست کنید.

## **صادر کردن یک شکل به SVG**

[WriteAsSvg](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/writeassvg/) محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه فقط شامل شکل است، نه پس‌زمینهٔ کامل اسلاید یا شکل‌های همجوار.

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

در حین رندر، ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و به منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخواننده مالک جریان است و باید آن را ببندد یا از بین ببرد.

## **هم‌ترازی اشکال**

متدهای [SlideUtil::AlignShapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/alignshapes/) امکان هم‌ترازی تمام اشکال یا اندیس‌های انتخاب‌شدهٔ مجموعه را فراهم می‌کنند. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapesalignmenttype/) لبه، خط مرکز یا حالت توزیع را مشخص می‌کند. `alignToSlide` را به `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ برای هم‌ترازی اشکال منتخب نسبت به یکدیگر مقدار `false` را بگذارید.

این مثال سه شکل را به لبهٔ بالای اسلاید هم‌تراز می‌کند. ارجاعات به شکل‌های بازگردانده‌شده بلافاصله قبل از هم‌ترازی به اندیس‌های جاریشان تبدیل می‌شوند.

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

هم‌ترازی موقعیت‌ها را تغییر می‌دهد، نه ترتیب Z. هم‌ترازی نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکلی برای تعریف فاصله نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر دادید، اندیس‌ها را دوباره محاسبه کنید.

## **معکوس کردن یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات معکوس افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `FlipH` و `FlipV` از [NullableBool](https://reference.aspose.com/slides/fa/cpp/aspose.slides/nullablebool/) استفاده می‌کنند: `True` معکوس را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت تعریف‌نشده/پیش‌فرض را حفظ می‌کند.

ارائهٔ زیر شامل یک شکل بدون معکوس است.

![شکل قبل از معکوس شدن](shape_to_be_flipped.png)

مثال فقط دو تنظیم معکوس را تغییر می‌دهد و سایر مقادیر فریم را همان‌گونه می‌گذارد. این مهم است چون اختصاص یک [Frame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_frame/) جدید تمام فریم را جایگزین می‌کند.

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

شکل ذخیره‌شده به‌صورت افقی و عمودی معکوس می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![شکل پس از معکوس شدن](flipped_shape.png)

## **سوالات متداول**

**آیا باید از ایندکس مجموعه به عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدت که مجموعه قبل از استفاده از ایندکس تغییر نخواهد کرد. برای قالب‌های نوشته‌شده ترجیحاً از یک قرارداد معتبر `Name` یا `AlternativeText` استفاده کنید یا برای کارهای مرتبط با interop scoped به اسلاید از `OfficeInteropShapeId` بهره ببرید.

**آیا پنهان‌سازی یک شکل آن را از ترتیب Z حذف می‌کند؟**

خیر. یک شکل پنهان‌شده در همان اندیس در مجموعه باقی می‌ماند. می‌توان آن را یافت، دوباره ترتیب داد، ویرایش یا دوباره قابل مشاهده کرد.

**چرا یک شکل کلون‌شده جلوتر از شکل دیگری ظاهر شد؟**

`AddClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی ترتیب Z است. برای انتخاب اندیس اولیه از `InsertClone` استفاده کنید یا پس از افزودن تمام اشکال از `Reorder` بهره بگیرید.