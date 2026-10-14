---
title: قالب‌بندی اشکال پاورپوینت در C++
linktitle: قالب‌بندی اشکال
type: docs
weight: 20
url: /fa/cpp/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت طرح‌کش
- خط طرح‌کش شکل
- قالب‌بندی سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن تکستچر
- پرکردن رنگ ثابت
- شفافیت شکل
- رندرینگ شکل سیاه و سفید
- رندرینگ شکل در مقیاس خاکستری
- چرخاندن شکل
- افکت برجستگی سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "به‌روشنی یاد بگیرید چگونه اشکال پاورپوینت را در C++ با استفاده از Aspose.Slides—قالب‌های پر، خط و افکت را برای فایل‌های PPT, PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در پاورپوینت می‌توانید شکل‌ها را به اسلایدها اضافه کنید. از آنجا که شکل‌ها از خطوط تشکیل شده‌اند، می‌توانید آن‌ها را با تغییر یا اعمال افکت‌ها به حاشیه‌هایشان قالب‌بندی کنید. علاوه بر این، می‌توانید شکل‌ها را با تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، قالب‌بندی کنید.

![قالب‌بندی شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides for C++ رابط‌ها و روش‌هایی را ارائه می‌دهد که به شما امکان می‌دهد شکل‌ها را با همان گزینه‌های موجود در پاورپوینت قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید یک سبک خط سفارشی برای یک شکل مشخص کنید. مراحل زیر روند کار را نشان می‌دهد:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [سبک خط](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. [سبک خط تیره](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط را برای شکل تنظیم کنید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیل را قالب‌بندی کنید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک AutoShape از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// تنظیم رنگ پر کردن برای شکل مستطیل.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// اعمال قالب‌بندی بر خطوط مستطیل.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// تنظیم رنگ خط مستطیل.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![خط‌های قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های طرح‌کش به خطوط شکل**

یک افکت طرح‌کش باعث می‌شود خط شکل به‌صورت دستی کشیده شده به‌نظر برسد. از [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) برای دسترسی به تنظیمات خط، [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) برای دسترسی به تنظیمات طرح‌کش و [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) برای انتخاب مقداری از شمارشگر [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) استفاده کنید.

کد C++ زیر نشان می‌دهد چگونه افکت [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاص داده‌شده صریحاً بخوانید و با [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) افکت را حذف کنید:

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

مقداری که توسط [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) برگردانده می‌شود، تنظیمی است که مستقیم به شکل اختصاص داده شده است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برده شود، از [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) دسترسی پیدا کنید و [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) را بخوانید. مقدار مؤثر قالب‌بندی که پس از حل ارث‌بری واقعاً اعمال می‌شود را نشان می‌دهد:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **قالب‌بندی انواع اتصال**

سه گزینه نوع اتصال وجود دارد:

* Round
* Miter
* Bevel

به‌طور پیش‌فرض، وقتی PowerPoint دو خط را در زاویه‌ای (مانند گوشه یک شکل) به‌هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. با این حال، اگر شکلی با زوایای تیز می‌کشید، ممکن است گزینه **Miter** را ترجیح دهید.

![نوع اتصال در ارائه](join-style-powerpoint.png)

کد C++ زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا مشاهده می‌کنید) با استفاده از تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شدند:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن سه AutoShape از نوع Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// تنظیم رنگ پر برای هر شکل مستطیل.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// تنظیم عرض خط.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// تنظیم رنگ خط هر مستطیل.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// تنظیم سبک اتصال.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// افزودن متن به هر مستطیل.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پرکردن گرادیان**

در پاورپوینت، پرکردن گرادیان یک گزینه قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را به یک شکل اعمال کنید. به‌عنوان مثال می‌توانید دو یا چند رنگ را به‑طوری اعمال کنید که یکی به‑تدریج به دیگری محو شود.

در اینجا نحوه اعمال پرکردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.
1. دو رنگ موردنظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `Add` مجموعه‌ توقف‌گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) در دسترس است، اضافه کنید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه یک افکت پرکردن گرادیان به یک بیضی اعمال می‌شود:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک AutoShape از نوع Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// اعمال قالب‌بندی گرادیان به بیضی.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// تنظیم جهت گرادیان.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// افزودن دو نقطه توقف گرادیان.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادراتی نسبت به همان‌طور که در پاورپوینت دیده می‌شود متفاوت باشد، بخش [Choose a Gradient Rendering Style](/slides/fa/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) را ببینید. می‌توانید بدون تغییر پرکردن گرادیان ذخیره‌شده در ارائه، یک سبک رندرینگ انتخاب کنید.

## **پرکردن الگو**

در پاورپوینت، پرکردن الگو یک گزینه قالب‌بندی است که به شما امکان می‌دهد طرح دو‌رنگی—مانند نقاط، خط‌قات، متقاطع یا شطرنجی—را به یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینه الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده را فراهم می‌کند که می‌توانید به شکل‌ها اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌فرض، می‌توانید رنگ‌های دقیق موردنظر خود را تعیین کنید.

در اینجا نحوه اعمال پرکردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) الگو را تنظیم کنید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه پرکردن الگو به یک مستطیل اعمال می‌شود:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک AutoShape از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تنظیم نوع پر کردن به Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// تنظیم سبک الگو.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تنظیم رنگ پس‌زمینه و پیش‌زمینه الگو.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

در پاورپوینت، پرکردن تصویر یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک تصویر را داخل یک شکل درج کنید—در واقع تصویر به‌عنوان پس‌زمینه شکل استفاده می‌شود.

در اینجا نحوه استفاده از Aspose.Slides برای اعمال پرکردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.
1. حالت پرکردن تصویر را به `Tile` (یا حالت دیگری که ترجیح می‌دهید) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.set_Image` پاس بدهید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" داریم با تصویر زیر:

![تصویر لوتوس](lotus.png)

کد C++ زیر نشان می‌دهد چگونه یک شکل را با تصویر پر کنید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک AutoShape از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// تنظیم نوع پر کردن به Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// تنظیم حالت پر کردن تصویر.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// بارگذاری یک تصویر و افزودن آن به منابع ارائه.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// تنظیم تصویر.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل با پرکردن تصویر](picture-fill.png)

### **کشتن تصویر به‌عنوان تکستچر**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان تکستچر تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) استفاده کنید:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): حالت پرکردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): تراز کاشی‌ها را درون شکل مشخص می‌کند.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): کنترل می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): افست افقی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): افست عمودی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): مقیاس افقی کاشی را به درصد تعریف می‌کند.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): مقیاس عمودی کاشی را به درصد تعریف می‌کند.

نمونه کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پرکردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto firstSlide = presentation->get_Slide(0);

// افزودن یک AutoShape مستطیل.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// تنظیم نوع پر کردن شکل به Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// بارگذاری تصویر و افزودن آن به منابع ارائه.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// اختصاص تصویر به شکل.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// پیکربندی حالت پر کردن تصویر و ویژگی‌های کاشی‌گذاری.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پرکردن رنگ ثابت**

در پاورپوینت، پرکردن رنگ ثابت یک گزینه قالب‌بندی است که یک شکل را با یک رنگ یگانه و یکنواخت پر می‌کند. این پس‌زمینه ساده بدون هیچ‌گونه گرادیان، تکستچر یا الگو اعمال می‌شود.

برای اعمال پرکردن رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.
1. رنگ پرکردن دلخواه خود را به شکل اختصاص دهید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه یک مستطیل در اسلاید پاورپوینت را با رنگ ثابت پر کنید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک AutoShape از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تنظیم نوع پر کردن به Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// تنظیم رنگ پر کردن.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل با پرکردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در پاورپوینت، هنگام اعمال رنگ ثابت، گرادیان، تصویر یا تکستچر به شکل‌ها، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان شفافیت پرکردن را کنترل کنید. مقدار شفافیت بیشتر، شکل را بیشتر شفاف می‌کند و اجازه می‌دهد پس‌زمینه یا اشیای زیرین به‌طور جزئی دیده شوند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پرکردن تنظیم کنید. در اینجا نحوه انجام این کار آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت (مؤلفه `alpha` شفافیت را کنترل می‌کند) استفاده کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه یک رنگ پرکردن شفاف به یک مستطیل اعمال کنید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک AutoShape مستطیل ثابت.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// افزودن یک AutoShape مستطیل شفاف بر روی شکل ثابت.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن شکل‌ها**

Aspose.Slides به شما امکان می‌دهد شکل‌ها را در ارائه‌های پاورپوینت بچرخانید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص هم‌راستایی یا طراحی مفید باشد.

برای چرخاندن یک شکل روی اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویه موردنظر تنظیم کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه یک شکل را به‌صورت 5 درجه بچرخانید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک AutoShape از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// چرخاندن شکل به اندازه 5 درجه.
shape->set_Rotation(5);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجستگی سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) افکت‌های برجستگی سه‌بعدی را به شکل‌ها اعمال کنید.

برای افزودن افکت‌های برجستگی سه‌بعدی به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجستگی پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه افکت‌های برجستگی سه‌بعدی را به یک شکل اعمال کنید:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// یک شکل به اسلاید اضافه کنید.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// ویژگی‌های ThreeDFormat شکل را تنظیم کنید.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// ارائه را به‌عنوان فایل PPTX ذخیره کنید.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![افکت برجستگی سه‌بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش سه‌بعدی**

Aspose.Slides به شما امکان می‌دهد با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) افکت‌های چرخش سه‌بعدی را به شکل‌ها اعمال کنید.

برای اعمال چرخش سه‌بعدی به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. از [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) و [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) برای تعریف چرخش سه‌بعدی استفاده کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه افکت‌های چرخش سه‌بعدی را به یک شکل اعمال کنید:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// ارائه را به‌عنوان فایل PPTX ذخیره کنید.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![افکت چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندرینگ سیاه‑سفید برای شکل‌ها**

متد [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) نحوه رندرینگ یک شکل منفرد را زمانی که ارائه در حالت سیاه‑سفید مشاهده یا پردازش می‌شود، مشخص می‌کند. این متد به‌تنهایی حالت نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی پر، خط یا سایر ویژگی‌های شکل را در حالت رنگی عادی تغییر نمی‌دهد.

از یک مقدار موجود در شمارشگر [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به‌معنی عدم تنظیم حالت در سطح شکل است.

کد C++ زیر یک شکل رنگی را ایجاد می‌کند و باعث می‌شود در حالت نمایش سیاه‑سفید به‌صورت خاکستری ظاهر شود:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// پر کردن نارنجی را در حالت رنگ نگه دارید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

در حالت رنگی عادی، مستطیل پرشدگی نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، به‌دلیل تنظیم حالت به `Gray`، از رنگ خاکستری استفاده می‌کند. این به شما امکان می‌دهد یک اسلاید تمام‌رنگ را حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

کد C++ زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام شکل‌های دارای جای‌گیر در [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگردانید:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // بازنشانی هر شکل در اسلاید که جای‌گیر در طرح‌بندی دارد.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

به‌صورت حداقل. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضا را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، اثرات و گرادیان‌ها به‌عنوان فراداده ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسانی دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

هر ویژگی کلیدی قالب‌بندی شکل‌ها—پرکردن، خط و تنظیمات اثر—را مقایسه کنید. اگر تمام مقادیر مربوطه مطابقت داشته باشند، سبک‌های آن‌ها را یکسان در نظر بگیرید و به‌صورت منطقی گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده شود؟**

بله. نمونه‌های شکل با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در مکان‌های موردنظر اعمال کنید.