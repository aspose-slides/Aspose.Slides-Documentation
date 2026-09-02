---
title: قالب‌بندی اشکال PowerPoint در C++
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/cpp/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکیچ
- خط شکل اسکیچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندر شکل سیاه‑سفید
- رندر شکل مقیاس خاکستری
- چرخاندن شکل
- افکت برجسته‌سازی 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در C++ با استفاده از Aspose.Slides—سبک‌های پر، خط و افکت را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. از آنجا که اشکال از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال افکت‌ها بر روی خطوط مرزی آن‌ها را فرمت‌بندی کنید. همچنین می‌توانید با مشخص کردن تنظیماتی که نحوه پر شدن داخلی آن‌ها را کنترل می‌کند، اشکال را فرمت‌بندی کنید.

![فرمت‌گذاری شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides برای C++ رابط‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد اشکال را با استفاده از همان گزینه‌های موجود در PowerPoint فرمت‌بندی کنید.

## **فرمت خطوط**

با استفاده از Aspose.Slides می‌توانید استایل خط سفارشی برای یک شکل تعیین کنید. مراحل زیر روند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. استایل [line style](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linestyle/) شکل را تنظیم کنید.  
1. عرض خط را تنظیم کنید.  
1. استایل [dash style](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linedashstyle/) خط را تنظیم کنید.  
1. رنگ خط شکل را تنظیم کنید.  
1. ارائه‌نامه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک `AutoShape` مستطیلی را فرمت‌بندی کنید:

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

// شیء کلاس Presentation را که نمایانگر یک فایل ارائه است، ایجاد می‌کند.
auto presentation = MakeObject<Presentation>();

// اولین اسلاید را دریافت کنید.
auto slide = presentation->get_Slide(0);

// یک شکل خودکار از نوع Rectangle اضافه کنید.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// رنگ پرکردن برای شکل مستطیلی را تنظیم کنید.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// قالب‌بندی را بر خطوط مستطیل اعمال کنید.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// رنگ خط مستطیل را تنظیم کنید.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// فایل PPTX را روی دیسک ذخیره کنید.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![خطوط فرمت‌بندی شده در ارائه](formatted-lines.png)

## **اعمال افکت‌های اسکیچ به خطوط شکل**

یک افکت اسکیچ باعث می‌شود خط یک شکل شبیه به دست‌نویس شود. برای دسترسی به تنظیمات خط از [IShape::get_LineFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_lineformat/) استفاده کنید، برای دسترسی به تنظیمات اسکیچ از [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilineformat/get_sketchformat/) و برای انتخاب مقدار از enumeration [LineSketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linesketchtype/) از [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isketchformat/set_sketchtype/) استفاده کنید.

کد C++ زیر نشان می‌دهد چگونه یک افکت [LineSketchType::Curved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linesketchtype/) اعمال کنید، مقدار اختصاص یافته صریحاً را بخوانید و با [LineSketchType::None](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linesketchtype/) افکت را حذف کنید:

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// دسترسی به قالب خط شکل و قالب اسکیچ آن.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// اعمال افکت اسکیچ.
sketchFormat->set_SketchType(LineSketchType::Curved);

// خواندن افکت اسکیچ اختصاص داده شده مستقیم به شکل.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// حذف افکت اسکیچ.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

مقداری که توسط [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isketchformat/get_sketchtype/) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر فرمت‌بندی خط می‌تواند از تم، اسلاید استاد یا اسلاید طرح‌بندی ارث‌بری شود، از [ILineFormat::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) دسترسی پیدا کنید و [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) را بخوانید. مقدار مؤثر فرمت‌بندی را که پس از حل ارث‌بری واقعاً اعمال می‌شود، نشان می‌دهد:

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

## **فرمت سبک‌های اتصال**

سه گزینه نوع اتصال وجود دارد:

* گرد
* میتر
* بویل

به‌طور پیش‌فرض، زمانی که PowerPoint دو خط را در زاویه‌ای به هم وصل می‌کند (مانند گوشهٔ یک شکل)، از تنظیم **Round** استفاده می‌کند. اما اگر شکل با زوایای تیز می‌کشید، ممکن است گزینه **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد C++ زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نمایش داده شده) با استفاده از تنظیمات نوع اتصال Miter، Bevel و Round ایجاد شدند:

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن سه شکل خودکار از نوع Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// تنظیم رنگ پر برای هر شکل مستطیلی.
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

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پر کردن گرادیان**

در PowerPoint، پر کردن گرادیان یک گزینهٔ فرمت‌بندی است که به شما اجازه می‌دهد ترکیب پیوسته‌ای از رنگ‌ها را روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌گونه‌ای اعمال کنید که یکی به‌تدریج به دیگری محو شود.

در اینجا نحوهٔ اعمال پر شدن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. نوع پر کردن [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) شکل را به `Gradient` تنظیم کنید.  
1. دو رنگ مورد نظر خود را با موقعیت‌های تعیین‌شده با استفاده از متدهای `Add` مجموعهٔ نقاط توقف گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igradientformat/) در دسترس است، اضافه کنید.  
1. ارائه‌نامه را به‌عنوان فایل PPTX ذخیره کنید.

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// اعمال قالب‌بندی گرادیان به بیضی.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// تنظیم جهت گرادیان.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// افزودن دو نقطه توقف گرادیان.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![بیضی با پر شدن گرادیان](gradient-fill.png)

## **پر کردن الگو**

در PowerPoint، پر کردن الگو یک گزینهٔ فرمت‌بندی است که به شما اجازه می‌دهد طرح دو رنگی—مانند نقطه‌ها، نوارها، خط‌متقاطع یا شطرنجی—را روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینه الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف شده را فراهم می‌کند که می‌توانید به اشکال اعمال کنید تا جذابیت بصری ارائه‌های خود را افزایش دهید. حتی پس از انتخاب یک الگوی پیش‌تعریف شده، می‌توانید رنگ‌های دقیق موردنظر آن را نیز تعیین کنید.

در اینجا نحوهٔ اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. نوع پر کردن [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) شکل را به `Pattern` تنظیم کنید.  
1. یک سبک الگو را از گزینه‌های پیش‌تعریف شده انتخاب کنید.  
1. رنگ پس‌زمینه الگو را با استفاده از [Background Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipatternformat/get_backcolor/) تنظیم کنید.  
1. رنگ پیش‌زمینه الگو را با استفاده از [Foreground Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipatternformat/get_forecolor/) تنظیم کنید.  
1. ارائه‌نامه را به‌عنوان فایل PPTX ذخیره کنید.

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تنظیم نوع پر کردن به Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// تنظیم سبک الگو.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تنظیم رنگ‌های پس‌زمینه و پیش‌زمینه الگو.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

در PowerPoint، پر کردن تصویر یک گزینهٔ فرمت‌بندی است که به شما اجازه می‌دهد یک تصویر را داخل یک شکل وارد کنید—به‌طور مؤثری تصویر را به‌عنوان پس‌زمینهٔ شکل استفاده می‌کند.

در اینجا نحوهٔ استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. نوع پر کردن [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) شکل را به `Picture` تنظیم کنید.  
1. حالت پر کردن تصویر را به `Tile` (یا حالت دیگری که ترجیح می‌دهید) تنظیم کنید.  
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.  
1. تصویر را به متد `ISlidesPicture.set_Image` پاس بدهید.  
1. ارائه‌نامه را به‌عنوان فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام "lotus.png" داریم که تصویر زیر را دارد:

![تصویر لوتوس](lotus.png)

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
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

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی کردن تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌شدن را سفارشی کنید، می‌توانید از روش‌های زیر در رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/picturefillformat/) استفاده کنید:

- [set_PictureFillMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.  
- [set_TileAlignment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): ترازبندی کاشی‌ها داخل شکل را مشخص می‌کند.  
- [set_TileFlip](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tileflip/): کنترل می‌کند که آیا کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.  
- [set_TileOffsetX](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): افست افقی کاشی (بر حسب پوینت) از مبدا شکل را تنظیم می‌کند.  
- [set_TileOffsetY](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): افست عمودی کاشی (بر حسب پوینت) از مبدا شکل را تنظیم می‌کند.  
- [set_TileScaleX](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.  
- [set_TileScaleY](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

کد زیر نشان می‌دهد چگونه یک شکل مستطیل با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto firstSlide = presentation->get_Slide(0);

// افزودن یک شکل خودکار مستطیلی.
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

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![گزینه‌های کاشی](tile-options.png)

## **پر کردن با رنگ ثابت**

در PowerPoint، پر کردن با رنگ ثابت یک گزینهٔ فرمت‌بندی است که شکل را با یک رنگ یکدست پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگو اعمال می‌شود.

برای اعمال پر کردن با رنگ ثابت به یک شکل با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. نوع پر کردن [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) شکل را به `Solid` تنظیم کنید.  
1. رنگ پر کردن دلخواه خود را به شکل اختصاص دهید.  
1. ارائه‌نامه را به‌عنوان فایل PPTX ذخیره کنید.

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تنظیم نوع پر کردن به Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// تنظیم رنگ پر کردن.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **تنظیم شفافیت**

در PowerPoint، وقتی یک پر کردن رنگ ثابت، گرادیان، تصویر یا بافت را بر روی اشکال اعمال می‌کنید، می‌توانید سطح شفافیت را نیز تنظیم کنید تا میزان شفافیت پر کردن را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل شفاف‌تر باشد و پس‌زمینه یا اشیای زیرین به‌صورت جزئی دیده شوند.

Aspose.Slides به شما امکان می‌دهد سطح شفافیت را با تنظیم مقدار آلفا در رنگ مورد استفاده برای پر کردن تنظیم کنید. در اینجا نحوهٔ انجام این کار آمده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. نوع پر کردن [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) را به `Solid` تنظیم کنید.  
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مؤلفه `alpha` شفافیت را کنترل می‌کند).  
1. ارائه‌نامه را ذخیره کنید.

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار مستطیلی ثابت.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// افزودن یک شکل خودکار مستطیلی شفاف بر روی شکل ثابت.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

Aspose.Slides به شما اجازه می‌دهد اشکال را در ارائه‌های PowerPoint چرخانده کنید. این می‌تواند هنگام موقعیت‌یابی عناصر بصری با نیازهای خاص هماهنگی یا طراحی مفید باشد.

برای چرخاندن یک شکل در اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. ویژگی چرخش شکل را به زاویهٔ دلخواه تنظیم کنید.  
1. ارائه‌نامه را ذخیره کنید.

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

// نمونه‌ساز کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// چرخاندن شکل به اندازه 5 درجه.
shape->set_Rotation(5);

// ذخیره فایل PPTX روی دیسک.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجسته‌سازی 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های برجسته‌سازی 3D را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/threedformat/) آن‌ها.

برای افزودن افکت‌های برجسته‌سازی 3D به یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/threedformat/) شکل را پیکربندی کنید تا تنظیمات برجسته‌سازی را تعریف کنید.  
1. ارائه‌نامه را ذخیره کنید.

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

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// ارائه را به عنوان فایل PPTX ذخیره کنید.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![افکت برجسته‌سازی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

Aspose.Slides به شما امکان می‌دهد افکت‌های چرخش 3D را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/threedformat/) آن‌ها.

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
1. یک مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.  
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.  
1. از [set_CameraType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icamera/set_cameratype/) و [set_LightType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilightrig/set_lighttype/) برای تعریف چرخش 3D استفاده کنید.  
1. ارائه‌نامه را ذخیره کنید.

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

// ارائه را به عنوان فایل PPTX ذخیره کنید.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‑سفید برای اشکال**

متد [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_blackwhitemode/) نحوهٔ رندر یک شکل شخصی را زمانی که ارائه در حالت سیاه‑سفید مشاهده یا پردازش می‌شود، مشخص می‌کند. این متد به تنهایی نمای سیاه‑سفید را فعال نمی‌کند و فرمت‌بندی‌های پر، خط یا سایر ویژگی‌های شکل در حالت رنگ عادی را تغییر نمی‌دهد.

از مقدارهای موجود در enumeration [BlackWhiteMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامهٔ رندر تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید را به‌کار می‌گیرد، `Black` و `White` رنگ تک تکی را تحمیل می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‌شیپی تعیین نشده است.

کد C++ زیر یک شکل رنگی ایجاد می‌کند و در حالت نمایش سیاه‑سفید آن را به‌صورت خاکستری نشان می‌دهد:

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

// رنگ پر نارنجی را در حالت رنگی نگه دارید، اما شکل را در حالت سیاه‑سفید با رنگ خاکستری رندر کنید.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

در حالت رنگ عادی، مستطیل پر رنگ نارنجی خود را حفظ می‌کند. در یک جریان کار نمایش سیاه‑سفید، به دلیل تنظیم حالت به `Gray` از رنگ خاکستری استفاده می‌شود. این امکان را می‌دهد تا اسلاید رنگ‌پُر را حفظ کنید در حالی که ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی فرمت‌بندی**

کد C++ زیر نشان می‌دهد چگونه فرمت‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و فرمت تمام اشکال با جای‌دارها در [LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/layoutslide/) را به تنظیمات پیش‌فرض برگردانید:

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
    // بازنشانی هر شکل روی اسلاید که دارای جای‌دار در طرح‌بندی است.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**آیا فرمت‌بندی شکل بر حجم نهایی فایل ارائه تأثیر می‌گذارد؟**

تنها به‌صورت جزئی. تصاویر و رسانه‌های جاسازی‌شده بیشتر فضا را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به عنوان متاداده ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم شکل‌هایی در یک اسلاید را که فرمت‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی فرمت‌بندی هر شکل—مانند تنظیمات پر، خط و افکت‌ها—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشد، سبک آن‌ها را یکسان در نظر بگیرید و منطقی آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مراحل بعدی ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد شود؟**

بله. شکل‌های نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و فرمت‌بندی آن‌ها را در مکان‌های موردنظر اعمال کنید.