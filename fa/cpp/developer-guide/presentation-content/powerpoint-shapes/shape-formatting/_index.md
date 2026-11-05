---
title: قالب‌بندی اشکال PowerPoint در C++
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/cpp/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- افکت اسکچ
- خط اسکچ شکل
- قالب‌بندی سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ یکدست
- شفافیت شکل
- رندرینگ شکل سیاه‑سفید
- رندرینگ شکل خاکستری
- چرخاندن شکل
- افکت برجسته‌سازی سه‌بعدی
- افکت چرخش سه‌بعدی
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال PowerPoint را در C++ با استفاده از Aspose.Slides قالب‌بندی کنید—قالب‌های پرکردن، خط و افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

شکل‌ها را در PowerPoint با تنظیم خطوط حاشیه، پرکردن‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides for C++ به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و قالب‌بندی سه‌بعدی.

![گزینه‌های قالب‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ رابط‌ها و متدهایی را فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با استفاده از همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) برای کنترل حاشیه یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکردن با حاشیه آبی خط‌چین ایجاد می‌کند. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) یک خط ترکیبی ضخیم‑نازک را انتخاب می‌کند، در حالی که [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) عرض آن را به ۷ پوینت تنظیم می‌کند و [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) الگوی خط‌چین را انتخاب می‌کند.

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

![خطوط قالب‌بندی شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای خط‌چین سفارشی**

از [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) زمانی که سبک‌های پیش‌فرض خط طول‌ها و فواصل مورد نیاز شما را فراهم نمی‌کنند، مثلاً برای خطوط برند یا نمودارهای فنی، استفاده کنید. اختصاص یک الگو به‌صورت خودکار سبک خط را به [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) تغییر می‌دهد.

مقادیر آرایه به‌صورت متناوب بین طول خط و فاصله جابجا می‌شوند و با یک خط شروع می‌شوند. هر مقدار مضربی از عرض خط است: `{ 4, 2 }` با عرض ۳ پوینت یک خط ۱۲ پوینتی سپس یک فاصله ۶ پوینتی تولید می‌کند. برای تعریف بخش‌های کامل خط‑و‑فاصله از جفت‌های مقادیر محدود، غیرمنفی استفاده کنید. مثال از مقادیر مثبت برای مشاهده واضح هر خط و فاصله استفاده می‌کند.

این مثال پنج خط آبی با همان طول و سرهای صاف ایجاد می‌کند. سه خط اول الگوها را با عرض ۳ پوینت مقایسه می‌کنند. خط چهارم همان الگو را با دو برابر عرض تکرار می‌کند و طول خط و فاصله را دو برابر می‌کند. خط پنجم از الگوی سفارشی به خط یکدست تغییر می‌یابد.

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

برای بازگشت به یک سبک خط‌چین پیش‌فرض، به‌جای آن [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) را به [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) پاس بدهید. سبک انتخابی ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگو خط‌چین سفارشی، خطی پهن‌تر با اولین الگو، و خط یکدست در PowerPoint](custom-dash-patterns.png)


### **تنظیم سرهای خط**

از [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) برای تنظیم سرهای یک خط باز استفاده کنید. شمارش [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) سه سبک صریح سر را ارائه می‌دهد:

- `Flat`: خط در نقطه انتها متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای به اندازه نصف عرض خط فراسوی نقطه انتها گسترش می‌یابد.
- `Square`: یک سر مربعی به اندازه نصف عرض خط فراسوی نقطه انتها گسترش می‌یابد.

این شمارش همچنین `NotDefined` را شامل می‌شود که به این معنی است که هیچ سبک سر صریحی اختصاص داده نشده است.

سرها متفاوت از سرهای پیکان هستند که نمادهایی به انتهای خط اضافه می‌کنند، و از اتصالات که گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال سرهای پیکان را از طریق [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) و [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) غیرفعال می‌کند تا فقط اشکال سر مقایسه شوند.

مثال زیر سه خط افقی تقریباً یکسان با عرض ۲۰ پوینت ایجاد می‌کند. از بالا به پایین، سرهای صاف، گرد و مربعی استفاده می‌شوند. نقاط انتهایی آن‌ها هم مختصات افقی یکسان دارند؛ سرهای گرد و مربعی ۱۰ پوینت بیش از هر انتها گسترش می‌یابند.

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

نتیجه در PowerPoint، از بالا به پایین: **Flat**, **Round**, و **Square**.

![سرهای صاف، گرد و مربعی بر روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های اسکچ به خطوط شکل‌ها**

یک افکت اسکچ باعث می‌شود خط شکل دست‌نویس به‌نظر برسد. از [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) برای دسترسی به تنظیمات خط، از [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) برای دسترسی به تنظیمات اسکچ، و از [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) برای انتخاب مقداری از شمارش [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) استفاده کنید.

کد C++ زیر نشان می‌دهد چگونه افکت [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) را اعمال کنید، مقدار اختصاص داده شده را بخوانید، و با [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) افکت را حذف کنید:

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

مقداری که توسط [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) برگردانده می‌شود، تنظیمی است که مستقیم به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید چیدمان به ارث برده شود، از [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) دسترسی پیدا کنید، و مقدار [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) را بخوانید. مقدار مؤثر نشان‌دهنده قالب‌بندی است که پس از حل ارث‌بری واقعاً اعمال می‌شود. این مثال به یک ارائه موجود با حداقل یک شکل در اسلاید اول نیاز دارد و هر دو مقدار را چاپ می‌کند:

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

سه گزینه نوع اتصال عبارتند از:

* Round
* Miter
* Bevel

سبک اتصال نحوهٔ اتصال دو بخش حاشیه را در گوشه کنترل می‌کند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter**، یا برای گوشه‌های مسطح از **Bevel** استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط حاشیه آبی به عرض ۱۵ پوینت ایجاد می‌کند. با استفاده از [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) به ترتیب مقدارهای مایتر، بویل و راند از شمارش [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) تنظیم می‌شود تا مشاهده شود گوشه‌ها چگونه رسم می‌شوند.

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

از [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) همراه با [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) تنظیم‌شده به [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) برای محدود کردن میزان گسترش یک گوشه تیز استفاده کنید.

محدودیت نسبتی از فاصله بین گوشه داخلی و خارجی اتصال به عرض خط است. به‌عنوان مثال، مقدار `8` اجازه می‌دهد طول مایتر تا هشت برابر عرض خط باشد؛ این یک اندازه در پوینت نیست. اگر گوشه از این حد فراتر رود، PowerPoint در آن گوشه از اتصال بویل استفاده می‌کند. مقدار بزرگ‌تر نقاط تیزتر را امکان‌پذیر می‌کند. این تنظیم فقط بر اتصالات مایتر تأثیر دارد و تغییر آن اثری روی نمایش ندارد وقتی گوشه در هر دو حد محدود باقی می‌ماند.

این مثال دو مثلث بدون پرکردن یکسان با خطوط حاشیه به عرض ۲۰ پوینت ایجاد می‌کند. مثلث چپ از حد `2` استفاده می‌کند و راست از `8`. هر مثلث به عرض ۸۰ پوینت و ارتفاع ۱۶۰ پوینت است که نسبت طول مایتر به عرض خط گوشهٔ بالایی تقریباً `4.12` است. بنابراین PowerPoint گوشهٔ چپ را بویل می‌کند و گوشهٔ راست را حفظ می‌کند.

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

![یک نقطه بویل با حد مایتر ۲ و یک نقطه نوک‌دار با حد مایتر ۸ در PowerPoint](miter-limits.png)

## **پرکردن گرادیان**

پر کردن گرادیان رنگ‌ها را در یک شکل ترکیب می‌کند. این مثال یک بیضی را با گرادیان خطی به زاویهٔ ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). متد [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) نقاط رنگ را در ۰ و ۱، آغاز و انتهای گرادیان قرار می‌دهد. پاک کردن نقاط توقف موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

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

![بیضی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر صادراتی نسبت به PowerPoint متفاوت به‌نظر برسد، به [Choose a Gradient Rendering Style](/slides/fa/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید سبک رندرینگ را بدون تغییر گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویهٔ گرادیان خطی**

از [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) برای کنترل جهت یک پرکردن [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و به‌صورت ساعتگرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ، و `270` از پایین به بالا. زوایای کسری نیز پشتیبانی می‌شوند. زوایای محدودی خارج از `[0, 360)` به یک دور کامل نرمال می‌شوند؛ برای مثال `-45` تبدیل به `315` و `360` تبدیل به `0` می‌شود.

این مثال شش مستطیل با نقاط توقف قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال شده تا زاویه بتواند مستقل از نسبت‌های مستطیل‌ها مقایسه شود. زوایا، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

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

![گرادیان‌های خطی با زاویهٔ ۰، ۴۵ و ۹۰ درجه در ردیف بالا، و ۱۳۵، ۱۸۰ و ۲۷۰ درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری گرادیان خطی با شکل**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) یک مقدار [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) می‌پذیرد. آن را به‌طور صریح به `False` تنظیم کنید تا زاویهٔ هندسی گرادیان همانند تغییر نسبت‌های شکل حفظ شود، یا به `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌گذاری شود. با فعال‌سازی مقیاس‌گذاری، زاویهٔ قابل‌مشاهده می‌تواند با زاویهٔ اختصاص‌یافته در یک شکل غیر مربعی متفاوت باشد.

مثال زیر از زاویهٔ `45` درجه و همان نقاط رنگی که در مقایسهٔ زاویه استفاده شد، استفاده می‌کند. ستون چپ `False` و ستون راست `True` را دارد. هر ستون شامل یک مستطیل پهن بالای یک مستطیل بلند است. هر دو با ابعاد پهن یکسان شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پرکردن چگونه بدون تغییر تنظیمات گرادیان به تغییر اندازه واکنش می‌دهد.

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

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در چپ و فعال در راست:

![مستطیل‌های پهن و بلند با گرادیان ۴۵ درجه، مقایسه LinearGradientScaled False در چپ با True در راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌گذاری، نوارهای رنگی اریب در هر دو مستطیل همان جهت را حفظ می‌کنند. با فعال بودن مقیاس‌گذاری، نوارها با نسبت‌های شکل کشیده می‌شوند. این کار به بازتولید گرادیان یک الگو هنگام تغییر اندازهٔ شکل کمک می‌کند. در یک مربع، فعال‌کردن مقیاس‌گذاری ظاهر این گرادیان `45` درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس‌گذاری فقط برای گرادیان‌های خطی اعمال می‌شوند. آن‌ها بر پرکردن‌های [GradientShape::Radial یا GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) تأثیری ندارند.

### **ترکیب زاویه با جهت گرادیان**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) یک سبک گرادیان را از شمارش [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزینی برای زاویهٔ عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند ناحیه‌ای که رنگ‌ها توزیع می‌شوند را بدون تغییر زاویه‌ای که از طریق [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) اختصاص داده شده است، تغییر دهند. هنگام مقایسهٔ زاویه یا مقیاس‌گذاری، جهت را بدون تغییر نگه دارید.

مثال زیر تنظیمات یکسان را به ترتیب مخالف اعمال می‌کند. دو مستطیل ظاهری مشابه دارند: اختصاص جهت قبل یا بعد از زاویه تغییری در نتیجه ایجاد نمی‌کند.

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

## **پرکردن الگو**

پر کردن الگو یک طرح دو‌رنگ مانند نقطه‌ها، خط‌ها یا 체크‌ها اعمال می‌کند. این مثال با استفاده از [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) یک الگوی trellis را انتخاب می‌کند. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) رنگ زرد الگو را می‌دهد.

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

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

پرکردن تصویر از یک تصویر داخل یک شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) برای بارگذاری آن در مجموعهٔ تصاویر ارائه استفاده می‌کند. تنظیم [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) به حالت کاشی‌شده تصویر را داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در زیر نمایش داده شده است:

![عکس لوتوس](lotus.png)

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

![شکل با پرکردن تصویر](picture-fill.png)

### **کاشی کردن تصویر به عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌بندی را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) استفاده کنید:

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): حالت پرکردن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): تراز کاشی‌ها داخل شکل را مشخص می‌کند.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): تعیین می‌کند که کاشی به‌صورت افقی، عمودی یا هر دو معکوس شود.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): افست افقی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): افست عمودی کاشی (به پوینت) را از مبدأ شکل تنظیم می‌کند.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) را طوری تنظیم می‌کند که آن را با ۵۰٪ اندازهٔ اصلی تکرار کند. افست‌های −۳۲ پوینت کاشی را به‌صورت افقی و عمودی جابجا می‌کند؛ تراز راست‑پایین و معکوس‌سازی در هر دو جهت نحوهٔ چیدمان بافت تکراری را تعیین می‌کند.

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

## **پرکردن رنگ یکدست**

پرکردن یکدست به شکل یک رنگ یکنواخت می‌دهد. این مثال [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) را به حالت پرکردن یکدست تنظیم می‌کند و با استفاده از [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) رنگ زرد را اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

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

![شکل با پرکردن رنگ یکدست](solid-color-fill.png)

### **کپی رنگ‌ها در حالی که مراجع تم حفظ می‌شود**

از [IColorFormat::CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/copyfrom/) برای کپی‌کردن تعریف رنگ، شامل نوع رنگ، مرجع تم و تبدیلات استفاده کنید. این کار زمانی مفید است که بخواهید رنگ پرکردن را بین شکل‌هایی که باید به تم ارائه ادامه دهند، انتقال دهید. این متد فقط رنگ را کپی می‌کند: نوع پرکردن، حاشیه یا دیگر قالب‌بندی‌های شکل را کپی نمی‌کند. نوع پرکردن مقصد را به‌صورت صریح با [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) تنظیم کنید.

این مثال سه مستطیل ایجاد می‌کند؛ از چپ به راست: منبع، کپی آگاهی از تم، و کپی RGB ثابت. منبع با استفاده از [IColorFormat::set_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_schemecolor/) به اولین رنگ تأکیدی ارجاع می‌دهد و با [IColorOperationCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icoloroperationcollection/add/) یک تیرگی اضافه می‌کند. کپی RGB از رنگ پرکردن مؤثر منبع استفاده می‌کند به طوری که هر سه در ابتدا یکسان به‌نظر می‌رسند. فراخوانی [IColorFormat::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_color/) مقدار RGB ثابت را تنظیم و هر تبدیل رنگ موجود را پاک می‌کند.

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(660, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_RoyalBlue());

auto source = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
auto themeCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
auto rgbCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

for (auto shape : { source, themeCopy, rgbCopy })
{
    shape->get_FillFormat()->set_FillType(FillType::Solid);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
}

auto sourceColor = source->get_FillFormat()->get_SolidFillColor();
sourceColor->set_SchemeColor(SchemeColor::Accent1);
sourceColor->get_ColorTransform()->Add(ColorTransformOperation::Tint, 0.75f);

themeCopy->get_FillFormat()->get_SolidFillColor()->CopyFrom(sourceColor);
auto effectiveFill = source->get_FillFormat()->GetEffective();
rgbCopy->get_FillFormat()->get_SolidFillColor()->set_Color(effectiveFill->get_SolidFillColor());

auto before = slide->GetImage(1.0f, 1.0f);
before->Save(u"color-copy-before.png", ImageFormat::Png);
before->Dispose();

// مراجع تم پس از رنگ تأکیدی جدید به‌روز می‌شوند؛ مقدار ثابت RGB تغییر نمی‌کند.
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_OrangeRed());

auto after = slide->GetImage(1.0f, 1.0f);
after->Save(u"color-copy-after.png", ImageFormat::Png);
after->Dispose();
presentation->Save(u"copied_colors.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

قبل از تغییر تم، هر سه پرکردن یکسان هستند:

![منبع، مقصد CopyFrom و مقصد RGB ثابت با پرکردن‌های آبی یکسان](color-copy-before.png)

پس از تغییر تم، منبع و کپی آگاهی از تم به رنگ تأکیدی جدید پیروی می‌کنند و تیرگی خود را حفظ می‌کنند. کپی RGB ثابت آبی می‌ماند:

![منبع و مقصد CopyFrom با پرکردن‌های نارنجی، در حالی که مقصد RGB ثابت آبی می‌ماند](color-copy-after.png)

تعریف کپی‌شده مستقل از منبع است. تغییر بعدی مرجع تم منبع، اختصاص رنگ دیگری، یا افزودن یا حذف تبدیلات آن، مقصد را تغییر نمی‌دهد. تغییر تم هنوز بر هر دو شکل اثر می‌گذارد زیرا هر کدام به طور مستقل به همان رنگ تم ارجاع می‌دهند.

ذخیره و بازکردن مجدد PPTX نوع رنگ کپی‌شده را حفظ می‌کند، که از طریق [IColorFormat::get_ColorType](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortype/) در دسترس است، مرجع تم آن و مجموعهٔ تبدیلات رنگی که توسط [IColorFormat::get_ColorTransform](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortransform/) برگردانده می‌شود؛ این تعریف به RGB مسطح نمی‌شود.

هنگام کپی بین زمینه‌های تم متفاوت، مانند ارائه‌هایی با پالت‌های تأکیدی مختلف، مرجع کپی‌شده نسبت به تم مقصد حل می‌شود. بنابراین همان مرجع و تبدیلات می‌توانند رنگ قابل‌مشاهده متفاوتی تولید کنند. برای پیکربندی رنگ‌های تم به [Presentation Theme](/slides/fa/cpp/presentation-theme/) مراجعه کنید.

## **استفاده از پس‌زمینهٔ اسلاید به‌عنوان پرکردن شکل**

از [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) زمانی که شکل باید با پس‌زمینهٔ اسلاید مطابقت داشته باشد، مثلاً در یک قالب ارائه، استفاده کنید. ابتدا [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) را به [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) تنظیم کنید تا هر پرکردن صریحی حذف شود. با این ترکیب، شکل از پس‌زمینهٔ اسلاید به‌جای پرکردن سبک خود استفاده می‌کند. تنها فعال‌سازی پرچم، پرکردن صریح موجود را حذف نمی‌کند.

این رفتار متفاوت از [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) است: پرکردن پس‌زمینه اشیاء پشت شکل را با ناحیهٔ متناظر پس‌زمینهٔ اسلاید پوشش می‌دهد، در حالی که بدون پرکردن این اشیا قابل مشاهده می‌مانند. یک گرادیان نیز به اسلاید هم‌راستا می‌ماند به‌جای اینکه در هر شکل دوباره شروع شود.

مثال زیر یک پس‌زمینهٔ مادر که توسط اسلاید به ارث می‌رسد ایجاد می‌کند و یک نوار سرخ‌کرم پشت سه مستطیل قرار می‌دهد. مستطیل چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی بدون پرکردن است و مستطیل راست از پس‌زمینه به پرکردن صریح نارنجی سوئیچ می‌کند.

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

// به ارث بردن گرادیان از مستر.
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

// این شیء را ابتدا اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
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

// قبل از اعمال پرکردن صریح، پرکردن پس‌زمینه را غیرفعال کنید.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه، از چپ به راست: **پرکردن پس‌زمینه**، **بدون پرکردن**، و **پرکردن صریح**. نوار سرخ‌کرم توسط مستطیل‌های چپ و راست مخفی می‌شود اما از طریق مستطیل میانی قابل مشاهده است.

![پرکردن پس‌زمینه، بدون پرکردن، و پرکردن صریح نارنجی روی نوار سرخ‌کرم](background-fill.png)

همین رفتار برای پس‌زمینه‌ای که مستقیماً بر روی اسلاید تعریف شده یا از یک لایه به ارث می‌رود، اعمال می‌شود. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و لایه را Undefined می‌گذارد تا مادر آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پرکردن یکدست، جزء آلفای رنگ کنترل‌کنندهٔ کدری است: ۰ کاملاً شفاف و ۲۵۵ کاملاً مات. این مثال از مقدار آلفا ۱۲۸ برای یک مستطیل زرد استفاده می‌کند تا تقریباً ۵۰٪ شفاف باشد و مستطیل زیرین قابل رؤیت بماند. رنگ از طریق [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) اختصاص می‌یابد.

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

از [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعتگرد می‌چرخاند و ارائه را ذخیره می‌کند.

```cpp
#include <DOM/IAutoShape>/
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto 

```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برجستهٔ سه‌بعدی**

از [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) برای اضافه کردن عمق و لبه‌های برجسته به یک شکل استفاده کنید. این مثال یک بیضی سبز با حاشیهٔ نارنجی ایجاد می‌کند، [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) را به ۴ پوینت تنظیم می‌کند و یک برجستهٔ بالای دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) اعمال می‌کند. یک دوربین ارتوگرافیک جلویی و نوردهی سه‌نقطه‌ای برجسته را قابل مشاهده می‌کند.

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

![افکت برجستهٔ سه‌بعدی](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش سه‌بعدی**

نمایش سه‌بعدی یک شکل توسط تنظیمات دوربین کنترل می‌شود. این مثال از [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) با زاویه‌های عرض، طول و انقلاب به ترتیب ۴۰، ۳۵ و ۲۰ درجه استفاده می‌کند. یک دوربین ایزومتریک از طریق [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) و نوردهی متعادل از طریق [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) انتخاب می‌شود، سپس مستطیل قالب‌بندی‌شده ذخیره می‌شود.

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

![افکت چرخش سه‌بعدی](3D-rotation-effect.png)

## **کنترل رندرینگ سیاه‑سفید برای شکل‌ها**

متد [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) مشخص می‌کند یک شکل به‌تنهایی چگونه در هنگام مشاهده یا پردازش ارائه در حالت سیاه‑سفید رندر می‌شود. این متد به‌تنهایی حالت نمایش سیاه‑سفید را فعال نمی‌کند و قالب‌بندی پرکردن، خط یا دیگر ویژگی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از یک مقدار شمارش [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) برای انتخاب رفتار موردنظر استفاده کنید. به‌عنوان مثال، `Automatic` به برنامهٔ رندر اجازه می‌دهد تبدیل را انتخاب کند، `Gray` و `LightGray` از رنگ خاکستری استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت اعمال می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‑سفید حذف می‌کند. `NotDefined` به این معنی است که هیچ حالت سطح‑شکلی اختصاص داده نشده است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) را به `Gray` تنظیم می‌کند. شکل ذخیره‌شده پرکردن نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و درخواست رنگ خاکستری را از برنامه‌هایی که تنظیمات نمایش سیاه‑سفید را رعایت می‌کنند، می‌کند:

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

در حالت رنگ عادی، مستطیل پرکردن نارنجی خود را حفظ می‌کند. در یک جریان کاری نمایش سیاه‑سفید، از رنگ خاکستری استفاده می‌کند چون حالت آن روی `Gray` تنظیم شده است. این امکان را می‌دهد تا اسلاید رنگی کامل را حفظ کنید و ظاهر متفاوتی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‑سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) برای بازگرداندن موقعیت، اندازه و قالب‌بندی فضاهای نگه‌دارندهٔ اسلاید از فضاهای نگه‌دارندهٔ لایهٔ مرتبط استفاده کنید. این مثال به یک ارائه موجود با فضاهای نگه‌دارندهٔ مرتبط با لایه نیاز دارد و قبل از ذخیره کردن هر اسلاید را بازنشانی می‌کند. شکل‌هایی که فضاهای نگه‌دارندهٔ مرتبط ندارند بازنشانی نمی‌شوند.

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

## **سوالات متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت معمولاً دادهٔ کمی اضافه می‌کنند نسبت به تصاویر و رسانه‌های تعبیه‌شده. پرکردن‌های تصویر می‌توانند اندازهٔ فایل را افزایش دهند زیرا تصاویرشان در ارائه ذخیره می‌شود.

**چگونه می‌توانم شکل‌های یک اسلاید که قالب‌بندی یکسان دارند را شناسایی کنم تا آنها را گروه‌بندی کنم؟**

هر یک از ویژگی‌های کلیدی قالب‌بندی شکل‌ها — پرکردن، خط و تنظیمات افکت — را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک‌های آنها را یکسان در نظر بگیرید و منطقی آن شکل‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌های بعدی را ساده می‌کند.

**آیا می‌توانم یک مجموعهٔ سفارشی از سبک‌های شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. شکل‌های نمونه با سبک‌های دلخواه را در یک مجموعهٔ اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائهٔ جدید، قالب را باز کنید، شکل‌های سبک‌دار موردنیاز را شبیه‌سازی (clone) کنید و قالب‌بندی آنها را در هر جایی که لازم است دوباره اعمال کنید.