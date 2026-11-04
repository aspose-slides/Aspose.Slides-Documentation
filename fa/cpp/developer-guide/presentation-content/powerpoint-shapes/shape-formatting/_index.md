---
title: قالب‌بندی اشکال پاورپوینت در C++
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/cpp/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر اسکچ
- خط اسکچ شکل
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ ثابت
- شفافیت شکل
- رندرینگ سیاه‌سفید شکل
- رندرینگ خاکستری شکل
- چرخاندن شکل
- اثر برجستگی سه‌بعدی
- اثر چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال پاورپوینت را در C++ با استفاده از Aspose.Slides—پر کردن، خط و سبک‌های اثر را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

شکل‌ها را در پاورپوینت با تنظیم خطوط پیرامون، پرکردن‌ها و اثرات قالب‌بندی کنید. Aspose.Slides for C++ به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی سه‌بعدی.

![گزینه‌های قالب‌بندی شکل در پاورپوینت](format-shape-powerpoint.png)

Aspose.Slides for C++ رابط‌ها و متدهایی را فراهم می‌کند که به شما امکان می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) برای کنترل خطوط پیرامون یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکردن با یک خط دورن آبی تولید می‌کند. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) یک خط ترکیبی ضخیم‑نازک را انتخاب می‌کند، در حالی که [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) عرض آن را به ۷ پوینت تنظیم می‌کند و [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) الگوی خط تیره را انتخاب می‌کند.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای سفارشی خط تیره**

از [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) وقتی سبک‌های پیش‌تعریف‌شده خطLengths یا فواصل مورد نیاز شما را ارائه نمی‌دهند، برای مثال برای خطوط برند یا نمودارهای فنی، استفاده کنید. اختصاص یک الگو به‌صورت خودکار سبک خط را به [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) تغییر می‌دهد.

ورودی‌های آرایه به صورت متناوب بین طول خط تیره و فاصله جفت می‌شوند، با یک خط تیره شروع می‌شود. هر مقدار مضرب عرض خط است: `{ 4, 2 }` در عرض ۳ پوینت یک خط تیره ۱۲ پوینتی سپس فاصله ۶ پوینتی تولید می‌کند. از جفت‌های مقدار متناهی و غیرمنفی برای تعریف بخش‌های کامل خط تیره‑فاصله استفاده کنید. این مثال از مقادیر مثبت برای نمایش واضح هر خط تیره و فاصله استفاده می‌کند.

این مثال پنج خط آبی با طول یکسان و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را در عرض ۳ پوینت مقایسه می‌کنند. خط چهارم الگوی اول را در دو برابر عرض تکرار می‌کند و طول خط تیره و فاصله را نیز دو برابر می‌کند. خط پنجم از الگوی سفارشی به خط صلحی سوئیچ می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای بازگشت به یک سبک پیش‌تعریف‌شده خط تیره، به‌جای آن [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) را به [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) پاس بدهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; و **Solid, 3 pt**.

![سه الگوی سفارشی خط تیره، یک خط ضخیم‌تر با استفاده از اولین الگو، و یک خط پیوسته در PowerPoint](custom-dash-patterns.png)

### **تنظیم سرهای خط**

از [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) برای تنظیم انتهای یک خط باز استفاده کنید. شمارش [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) سه سبک سر صریح را فراهم می‌کند:

- `Flat`: خط در نقطه انتها متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای تا نصف عرض خط جلوتر از نقطه انتها ادامه دارد.
- `Square`: یک سر مربعی تا نصف عرض خط جلوتر از نقطه انتها ادامه دارد.

این شمارش همچنین شامل `NotDefined` است که به این معنی است که هیچ سبک سر صریحی تخصیص داده نشده است.

سرها با سرهای فلش متفاوت هستند؛ سرهای فلش نمادهایی را به انتهای خط اضافه می‌کنند و اتصالات گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرهای فلش را از طریق [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) و [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) غیرفعال می‌کند تا فقط شکل سرها مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان با عرض ۲۰ پوینت ایجاد می‌کند. از بالا به پایین، آن‌ها به ترتیب از سرهای flat، round و square استفاده می‌کنند. نقاط انتهایی آن‌ها همان مختصات افقی را دارند؛ سرهای round و square ۱۰ پوینت جلوتر از هر انتها ادامه می‌یابند.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه در PowerPoint، از بالا به پایین: **Flat**, **Round**, and **Square**.

![سرهای Flat، Round و Square روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال اثرات Sketch به خطوط شکل**

یک اثر Sketch باعث می‌شود خط شکل شبیه به دست‌کشیده باشد. از [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) برای دسترسی به تنظیمات خط، از [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) برای دسترسی به تنظیمات Sketch و از [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) برای انتخاب مقداری از شمارش [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) استفاده کنید.

کد C++ زیر نشان می‌دهد چگونه اثر [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاص‌یافته صریحاً بخوانید و اثر را با [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) حذف کنید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

مقداری که توسط [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط بتواند از تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برده شود، از [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) دسترسی پیدا کنید و [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) را بخوانید. مقدار مؤثر بازتاب‌دهندهٔ قالب‌بندی است که پس از حل ارث‌بری واقعاً اعمال می‌شود. این مثال به ارائه‌ای موجود با حداقل یک شکل در اسلاید اول نیاز دارد و هر دو مقدار را چاپ می‌کند:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

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

## **قالب‌بندی سبک‌های اتصال**

در اینجا سه گزینه نوع اتصال موجود است:

* Round
* Miter
* Bevel

سبک اتصال تعیین می‌کند دو بخش پیرامون چگونه در گوشه به‌یکدیگر می‌پیوندند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter** و برای گوشه‌های مسطوح از **Bevel** استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط دورن آبی به عرض ۱۵ پوینت ایجاد می‌کند. با استفاده از [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) مقادیر miter، bevel و round شمارش [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) را به ترتیب تنظیم می‌کند تا نحوهٔ رسم گوشه‌ها مقایسه شود.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **محدود کردن اتصالات مایتر در گوشه‌های تیز**

از [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) همراه با [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) که به [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) تنظیم شده است، برای محدود کردن میزان گسترش یک گوشهٔ تیز استفاده کنید.

محدودیت نسبتی است از فاصلهٔ بین گوشه‌های داخلی و خارجی اتصال به عرض خط. برای مثال، مقدار `8` اجازه می‌دهد طول مایتر تا هشت برابر عرض خط باشد؛ این یک اندازه‌گیری به پوینت نیست. اگر گوشه از محدودیت عبور کند، PowerPoint در آن گوشه از اتصال bevel استفاده می‌کند. محدودیت بزرگ‌تر نقاط تیزتر ایجاد می‌کند. این تنظیم فقط بر اتصالات مایتر تأثیر می‌گذارد و تغییر آن وقتی گوشه در هر دو محدودیت باقی بماند، تأثیری قابل مشاهده ندارد.

این مثال دو مثلث بدون پرکردن یکسان با خطوط دورن به عرض ۲۰ پوینت ایجاد می‌کند. مثلث چپ از محدودیت `2` و مثلث راست از `8` استفاده می‌کند. هر مثلث به عرض ۸۰ پوینت و ارتفاع ۱۶۰ پوینت است که نسبت طول مایتر به عرض خط در بالای آن حدود `4.12` است. بنابراین PowerPoint رأس چپ را bevel می‌کند و رأس راست را حفظ می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![یک رأس برش‌خورده با محدودیت مایتر 2 و یک رأس نوک‌دار با محدودیت مایتر 8 در PowerPoint](miter-limits.png)

## **پر کردن گرادیان**

یک پر کردن گرادیان رنگ‌ها را در طول یک شکل ترکیب می‌کند. این مثال یک بیضی را با یک گرادیان خطی به زاویهٔ ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). متد [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) نقاط توقف رنگ را در ۰ و ۱، یعنی آغاز و پایان گرادیان قرار می‌دهد. پاک‌سازی نقاط توقف موجود اطمینان می‌دهد فقط این دو رنگ استفاده شوند.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادرشده نسبت به همان‌گونه در PowerPoint متفاوت به‌نظر می‌رسد، به [انتخاب سبک رندرینگ گرادیان](/slides/fa/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید یک سبک رندرینگ را بدون تغییر گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویه گرادیان خطی**

از [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) برای کنترل جهت یک پر کردن [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) استفاده کنید. زاویه به درجه اندازه‌گیری می‌شود و ساعت‌گرد افزایشی است: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زاویه‌های کسری پشتیبانی می‌شوند. زاویه‌های متناهی خارج از `[0, 360)` به یک دور نرمال‌سازی می‌شوند؛ برای مثال `-45` تبدیل به `315` و `360` تبدیل به `0` می‌شود.

این مثال شش مستطیل با نقاط توقف قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌سازی غیرفعال شده تا زاویه بتواند به‌طور مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زاویه‌ها، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه در PowerPoint:

![گرادیان‌های خطی در 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌بندی یک گرادیان خطی با شکل**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) یک مقدار [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) می‌گیرد. به‌صورت صریح `False` تنظیم کنید تا زاویهٔ هندسی گرادیان هنگام تغییر نسبت‌های شکل ثابت بماند، یا `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌بندی شود. با فعال شدن مقیاس‌بندی، زاویهٔ قابل مشاهده ممکن است در یک شکل غیرمربع متفاوت از زاویهٔ اختصاصی باشد.

مثال زیر از زاویهٔ `45` درجه و همان نقاط توقف رنگی که در مقایسهٔ زاویه استفاده شد، استفاده می‌کند. ستون چپ `False` و ستون راست `True` دارد. هر ستون شامل یک مستطیل عریض بالا و یک مستطیل بلند پایین است. هر دو با همان ابعاد عریض شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد چگونه پرکردن به تغییر اندازه پاسخ می‌دهد بدون آنکه تنظیمات گرادیان تغییر کنند.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه در PowerPoint، با مقیاس‌سازی غیرفعال در چپ و فعال در راست:

![مستطیل‌های عریض و بلند با گرادیان 45 درجه، مقایسه LinearGradientScaled False در سمت چپ با True در سمت راست](linear-gradient-scaling.png)

با غیرفعال کردن مقیاس‌سازی، نوارهای رنگی قطری همان جهت را در هر دو مستطیل حفظ می‌کنند. با فعال شدن مقیاس‌سازی، نوارها با نسبت‌های شکل کشیده می‌شوند. این کمک می‌کند تا گرادیان یک الگو را هنگام تطبیق شکل به اندازهٔ متفاوت بازتولید کنید. در یک مربع، فعال شدن مقیاس‌سازی ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس برای گرادیان‌های خطی اعمال می‌شوند. آن‌ها بر پر کردن‌های [GradientShape::Radial یا GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) تأثیری ندارند.

### **ترکیب زاویه با جهت گرادیان**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) یک سبک گرادیان را از شمارش [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزین یک زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیهٔ توزیع رنگ‌ها را بدون تغییر زاویه‌ای که از طریق [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) تنظیم شده است، تغییر دهند. جهت را در زمان مقایسهٔ زوایا یا مقیاس ثابت نگه دارید.

مثال زیر همان تنظیمات را به ترتیب مخالف اعمال می‌کند. دو مستطیل ظاهر یکسانی دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
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

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پر کردن الگو**

یک پر کردن الگو یک طرح دو‌رنگ مانند نقطه‌ها، خط‌خط‌ها یا شطرنجی‌ها را اعمال می‌کند. این مثال از [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) برای انتخاب الگوی trellis استفاده می‌کند. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) رنگ زرد الگو را فراهم می‌کند.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر**

یک پر کردن تصویر از یک عکس داخل یک شکل استفاده می‌کند. این مثال نیاز به یک تصویر محلی دارد و از [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) برای بارگذاری آن در مجموعهٔ تصاویر ارائه استفاده می‌کند. تنظیم [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) به حالت tiled تصویر را داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نشان داده شده است:

![عکس نیلوفرآبی](lotus.png)

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **کاشی‌گذاری تصویر به‌عنوان بافت**

اگر می‌خواهید تصویر تایل‌شده را به‌عنوان بافت تنظیم کرده و رفتار تایلینگ را سفارشی کنید، می‌توانید از روش‌های زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) استفاده کنید:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): حالت پر کردن تصویر را تنظیم می‌کند—یا `Tile` یا `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): تراز کاشی‌ها را داخل شکل مشخص می‌کند.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): تعیین می‌کند آیا کاشی به صورت افقی، عمودی یا هر دو وارونه شود.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): افست افقی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): افست عمودی کاشی (به پوینت) از مبدأ شکل را تنظیم می‌کند.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

این مثال نیاز به یک تصویر محلی دارد و [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) را طوری تنظیم می‌کند که تصویر را با ۵۰٪ از اندازهٔ اصلی خود تکرار کند. افست‌های −۳۲ پوینت کاشی‌ها را به صورت افقی و عمودی جابجا می‌کند؛ تراز پایین‑راست و وارونه شدن در هر دو جهت تعیین می‌کند که بافت تکرار شده چگونه چینش شود.

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ ثابت**

یک پر کردن ثابت به شکل یک رنگ واحد و یکنواخت می‌دهد. این مثال [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) را به حالت پر کردن ثابت تنظیم می‌کند و با استفاده از [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) رنگ زرد را اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل با پر کردن رنگ ثابت](solid-color-fill.png)

## **استفاده از پس‌زمینه اسلاید به‌عنوان پر کردن شکل**

از [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) زمانی استفاده کنید که یک شکل باید با پس‌زمینهٔ اسلاید مطابقت داشته باشد، برای مثال در یک قالب ارائه. ابتدا [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) را به [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) تنظیم کنید تا هر پر کردن صریحی حذف شود. با این ترکیب، شکل از پس‌زمینهٔ اسلاید به‌جای سبک پرکردن خود استفاده می‌کند. فعال‌سازی تنها این پرچم، پر کردن صریح موجود را حذف نمی‌کند.

این رفتار با [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) متفاوت است: پر کردن پس‌زمینه اشیای پشت شکل را با ناحیهٔ متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پر کردن آن اشیاء را قابل مشاهده می‌گذارد. یک گرادیان همچنان نسبت به اسلاید هم‌راستا می‌ماند و داخل هر شکل دوباره شروع نمی‌شود.

مثال زیر یک پس‌زمینهٔ اصلی که توسط اسلاید به ارث برده می‌شود ایجاد می‌کند و یک نوار سرخی پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل وسط بدون پر کردن است و مستطیل راست از پر کردن پس‌زمینه به یک پر کردن صریح نارنجی سوئیچ می‌کند.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// گرادیان را از مستر به ارث ببرید.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// این شی را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// قبل از اعمال پر کردن صریح، پر کردن پس‌زمینه را غیرفعال کنید.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه، از چپ به راست: **background fill**, **no fill**, and **explicit fill**. نوار سرخی توسط مستطیل‌های چپ و راست پنهان می‌شود اما از طریق مستطیل وسط قابل مشاهده است.

![پر کردن پس‌زمینه، بدون پر کردن، و پر کردن نارنجی صریح روی نوار صورتی](background-fill.png)

رفتار مشابهی برای پس‌زمینه‌ای که مستقیماً روی اسلاید تعریف شده یا از یک طرح‌بندی ارث برده می‌شود اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ در این مثال هم پس‌زمینهٔ اسلاید و هم پس‌زمینهٔ طرح‌بندی تعریف نشده‌اند تا پیش‌زمینه آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پر کردن ثابت، مؤلفهٔ آلفای رنگ کنترل‌کنندهٔ شفافیت است: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات است. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند، به‌طوری که تقریباً ۵۰٪ شفاف باشد تا مستطیل زیرین قابل مشاهده بماند. رنگ از طریق [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) اختصاص داده می‌شود.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن شکل‌ها**

از [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاویه به درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعت‌گرد می‌چرخاند و ارائه را ذخیره می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجستگی سه‌بعدی**

از [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) برای افزودن عمق و لبه‌های برجسته به یک شکل استفاده کنید. این مثال یک بیضی سبز با خط دورن نارنجی ایجاد می‌کند، [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) را به ۴ پوینت تنظیم می‌کند و یک برجستگی بالائی دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) اعمال می‌کند. یک دوربین ارتوگرافیک جلو و نورپردازی سه‑نقطه‌ای برجستگی را نشان می‌دهد.

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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![افکت برجستگی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش سه‌بعدی**

نمایش سه‌بعدی یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) با زاویه‌های عرضی، طولی و دوران به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. یک دوربین ایزومتریک را از طریق [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) انتخاب می‌کند و نورپردازی متعادل را از طریق [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) تنظیم می‌کند، سپس مستطیل قالب‌بندی‌شده را ذخیره می‌کند.

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
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر کردن سیاه‌سفید برای شکل‌ها**

متد [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) مشخص می‌کند یک شکل به‌تنهایی هنگام مشاهده یا پردازش ارائه در حالت سیاه‌سفید چگونه رندر شود. این متد به‌تنهایی نمایش سیاه‌سفید را فعال نمی‌کند و رنگ، پرکردن یا قالب‌بندی دیگر شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از مقداری از شمارش [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) برای انتخاب رفتار مطلوب استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندرینگ تصمیم‌گیری کند، `Gray` و `LightGray` رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ واحد اعمال می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‌سفید حذف می‌کند. `NotDefined` به این معناست که هیچ حالت سطح شکل اختصاص داده نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) را روی `Gray` تنظیم می‌کند. شکل ذخیره‌شده پرکردن نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و برای برنامه‌هایی که تنظیمات نمایش سیاه‌سفید را رعایت می‌کنند، درخواست رنگ خاکستری می‌کند:

```cpp
#include <DOM/BlackWhiteMode.h>
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
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

در حالت رنگ عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک گردش کار نمایش سیاه‌سفید، به دلیل تنظیم روی `Gray` رنگ خاکستری استفاده می‌شود. این امکان را می‌دهد تا اسلاید رنگ کامل را حفظ کنید در حالی که برای چاپ، پیش‌نمایش یا سایر گردش‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، ظاهر متمایزی تعریف کنید.

## **بازنشانی قالب‌بندی**

از [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) برای بازیابی موقعیت، اندازه و قالب‌بندی مکان‌دارهای اسلاید از مکان‌دارهای متناظر طرح‌بندی آنها استفاده کنید. این مثال به یک ارائه موجود با مکان‌دارهای مرتبط به طرح‌بندی نیاز دارد و قبل از ذخیره هر اسلاید را بازنشانی می‌کند. شکل‌هایی که مکان‌دار متناظر در طرح‌بندی ندارند بازنشانی نمی‌شوند.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پرسش‌های متداول**

**آیا قالب‌بندی شکل بر اندازه نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات اثر معمولاً داده کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های جاسازی‌شده. پر کردن‌های تصویری می‌توانند حجم فایل را افزایش دهند زیرا تصاویرشان در ارائه ذخیره می‌شود.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسان دارند شناسایی کنم تا آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پرکردن، خط و تنظیمات اثر—را مقایسه کنید. اگر تمام مقادیر متناظر هم‌خوانی داشته باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقی آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در ادامه ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. شکل‌های نمونه با سبک‌های موردنظر را در یک اسلاید الگو یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که لازم است اعمال کنید.