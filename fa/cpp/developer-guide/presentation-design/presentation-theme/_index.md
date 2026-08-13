---
title: "مدیریت تم‌های ارائه در C++"
linktitle: "تم ارائه"
type: docs
weight: 10
url: /fa/cpp/presentation-theme/
keywords:
- "تم PowerPoint"
- "تم ارائه"
- "تم اسلاید"
- "تنظیم تم"
- "تغییر تم"
- "مدیریت تم"
- "رنگ تم"
- "پالت اضافی"
- "فونت تم"
- "سبک تم"
- "افکت تم"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "تم‌های اصلی ارائه در Aspose.Slides برای C++ را برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکپارچه مدیریت کنید."
---
## **مقدمه**

یک تم ارائه ویژگی‌های عناصر طراحی را تعریف می‌کند. وقتی یک تم ارائه را انتخاب می‌کنید، در واقع مجموعه‌ای خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در پاورپوینت، یک تم شامل رنگ‌ها، [fonts](/slides/fa/cpp/powerpoint-fonts/)، [background styles](/slides/fa/cpp/presentation-background/) و افکت‌ها است.

![theme-constituents](theme-constituents.png)

## **تغییر رنگ تم**

یک تم پاورپوینت مجموعه‌ای خاص از رنگ‌ها را برای عناصر مختلف یک اسلاید استفاده می‌کند. اگر این رنگ‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید برای تم، رنگ‌ها را تغییر دهید. برای اینکه بتوانید یک رنگ تم جدید انتخاب کنید، Aspose.Slides مقادیر را تحت شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) ارائه می‌دهد.

این کد C++ نحوه تغییر رنگ Accent برای یک تم را نشان می‌دهد:
```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

به این طریق می‌توانید مقدار مؤثر رنگ حاصل را تعیین کنید:
```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (رنگ [A=255, R=128, G=100, B=162])
```

برای نمایش بیشتر عملیات تغییر رنگ، یک عنصر دیگر ایجاد می‌کنیم و رنگ Accent (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ را در تم تغییر می‌دهیم:
```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از یک پالت اضافی**

زمانی که تبدیل‌های روشنایی را بر روی رنگ تم اصلی (1) اعمال می‌کنید، رنگ‌هایی از پالت اضافی (2) ساخته می‌شوند. سپس می‌توانید این رنگ‌های تم را تنظیم و دریافت کنید.

![additional-palette-colors](additional-palette-colors.png)

**1**- رنگ‌های تم اصلی  
**2**- رنگ‌ها از پالت اضافی

این کد C++ عملیاتی را نشان می‌دهد که در آن رنگ‌های پالت اضافی از رنگ تم اصلی به دست آمده و سپس در اشکال استفاده می‌شوند:
```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **نقشه‌برداری `SchemeColor` به رنگ‌های `IColorScheme`**

وقتی با [SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگ تم زیر است:
`Background1`, `Background2`, `Text1`, and `Text2`.

با این حال، `Presentation::get_MasterTheme()::get_ColorScheme()` یک [IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/) را بر می‌گرداند که رنگ‌های مربوطه را به‌صورت زیر نشان می‌دهد:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

این تفاوت فقط در نامگذاری است. این مقادیر به همان اسلات‌های رنگ تم اشاره دارند و نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل پویا بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آنها صرفاً نام‌های جایگزین برای همان رنگ‌های تم هستند.

این تفاوت نامگذاری از اصطلاحات Microsoft Office ناشی می‌شود. نسخه‌های قدیمی Office از `Dark 1`، `Light 1`، `Dark 2` و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید رابط کاربری همان اسلات‌ها را به صورت `Text 1`، `Background 1`، `Text 2` و `Background 2` نمایش می‌دهند.

## **تغییر فونت تم**

برای این که بتوانید فونت‌ها را برای تم‌ها و مقاصد دیگر انتخاب کنید، Aspose.Slides از این شناسه‌های خاص (مشابه آنچه در پاورپوینت استفاده می‌شود) بهره می‌گیرد:

* **+mn-lt** - فونت متن اصلی لاتین (فونت کوچک لاتین)
* **+mj-lt** - فونت عنوان لاتین (فونت بزرگ لاتین)
* **+mn-ea** - فونت متن اصلی آسیایی شرقی (فونت کوچک آسیای شرقی)
* **+mj-ea** - فونت متن اصلی آسیایی شرقی (فونت بزرگ آسیای شرقی)

این کد C++ نشان می‌دهد چگونه فونت لاتین را به یک عنصر تم اختصاص دهید:
```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

این کد C++ نشان می‌دهد چگونه فونت تم ارائه را تغییر دهید:
```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

فونت در تمام جعبه‌های متن به‌روزرسانی خواهد شد.

{{% alert color="info" title="TIP" %}} 
ممکن است بخواهید [PowerPoint fonts](/slides/fa/cpp/powerpoint-fonts/) را ببینید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به‌صورت پیش‌فرض، برنامه پاورپوینت 12 پس‌زمینه از پیش تعریف شده ارائه می‌دهد اما تنها 3 تا از این 12 پس‌زمینه در یک ارائه معمولی ذخیره می‌شوند.

![todo:image_alt_text](presentation-design_8.png)

برای مثال، پس از ذخیره یک ارائه در برنامه پاورپوینت، می‌توانید این کد C++ را اجرا کنید تا تعداد پس‌زمینه‌های از پیش تعریف شده در ارائه را بیابید:
```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme/)، می‌توانید سبک پس‌زمینه را در یک تم پاورپوینت اضافه یا دسترسی داشته باشید.
{{% /alert %}}

این کد C++ نشان می‌دهد چگونه پس‌زمینه یک ارائه را تنظیم کنید:
```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**راهنمای ایندکس**: 0 برای بدون پر کردن استفاده می‌شود. ایندکس از 1 شروع می‌شود.

{{% alert color="info" title="TIP" %}} 
ممکن است بخواهید [PowerPoint Background](/slides/fa/cpp/presentation-background/) را ببینید.
{{% /alert %}}

## **تغییر افکت تم**

یک تم پاورپوینت معمولاً برای هر آرایه استایل 3 مقدار دارد. این آرایه‌ها به 3 افکت ترکیب می‌شوند: ملایم (subtle)، متوسط (moderate) و شدید (intense). برای مثال، این نتیجه اعمال افکت‌ها بر روی یک شکل خاص است:
![todo:image_alt_text](presentation-design_10.png)

با استفاده از 3 ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)، [LineStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd)، [EffectStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme/)، می‌توانید عناصر یک تم را تغییر دهید (تا حدی انعطاف‌پذیرتر از گزینه‌های موجود در پاورپوینت).

این کد C++ نشان می‌دهد چگونه یک افکت تم را با تغییر بخش‌های عناصر تغییر دهید:
```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

تغییرات حاصل در رنگ پر، نوع پر، افکت سایه و غیره به‌صورت زیر است:
![todo:image_alt_text](presentation-design_11.png)

## **سؤالات متداول**

### آیا می‌توانم تم را به یک اسلاید اعمال کنم بدون تغییر مستر؟

بله. Aspose.Slides از بازنویسی تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید یک تم محلی را فقط برای آن اسلاید اعمال کنید در حالی که تم مستر دست نخورده می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/slidethememanager/)).

### امن‌ترین روش برای انتقال تم از یک ارائه به ارائهٔ دیگر چه است؟

[Clone slides](/slides/fa/cpp/clone-slides/) همراه با مستر آنها را به ارائه هدف انتقال دهید. این کار مستر اصلی، طرح‌بندی‌ها و تم مربوطه را حفظ می‌کند تا ظاهر یک‌دست بماند.

### چگونه می‌توانم مقادیر «مؤثر» را پس از تمام وراثت و بازنویسی‌ها ببینم؟

از نماهای ["effective"](/slides/fa/cpp/shape-effective-properties/) API برای تم/رنگ/فونت/افکت استفاده کنید. این نماها پس از اعمال مستر و هر بازنویسی محلی، ویژگی‌های نهایی و حل‌شده را برمی‌گردانند.