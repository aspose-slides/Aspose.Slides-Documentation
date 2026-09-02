---
title: مدیریت تم‌های ارائه در C++
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/cpp/presentation-theme/
keywords:
- تم پاورپوینت
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- قلم تم
- سبک تم
- افکت تم
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای C++ برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه‌شده مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به جای ذخیره هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند بسیاری از اشیا را همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) بازنویسی کند، در حالی که یک لِی‌آوت یا یک اسلاید فرد می‌تواند از [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) استفاده کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لِی‌آوت و بازنویسی اسلاید.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کار با تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/) متدهای [get_ColorScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) و [get_FormatScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) را در معرض نمایش می‌گذارد. بررسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه زمانی مفید است که یک ارائه از منبع خارجی آمده باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌توانند متفاوت باشند.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستر مرتبط با اسلاید را بررسی کنید و از جریان کار تم مؤثر که در ادامه مقاله نشان داده شده است استفاده کنید وقتی که بازنویسی‌های لِی‌آوت یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/) ارجاع دهند. هنگامی که ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/) تم تغییر می‌کند، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند بر اساس مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها به انتهایی زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

چون مستطیل همچنان به `Accent4` پیوسته است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح‌واره را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد داشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، انواع روشن‌تر و تاریک‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/colortransformoperation/) در دسترس قرار می‌دهد.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - انواع روشن‌تر و تاریک‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، به پنج‌ مورد از آن‌ها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

```cpp
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
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

این انواع همچنان بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/) همان اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` در معرض نمایش می‌گذارد. نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آن‌ها مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل مجموعه‌ای اصلی برای سرعنوان‌ها و یک مجموعه فرعی برای متن بدنه است. متدهای [FontScheme::get_Major()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_major/) و [FontScheme::get_Minor()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_minor/) این مجموعه‌ها را در معرض نمایش می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

مثال زیر یک سرعنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند، ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

سرعنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که نام قلم صریحی به‌جای شناسه تم داشته باشد، هنگام تغییر طرح قلم تم به‌طور خودکار سوئیچ نخواهد شد.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، بخش [PowerPoint Fonts](/slides/fa/cpp/powerpoint-fonts/) را ببینید.
{{% /alert %}}

## **کپی یا اعمال تم**

دو جریان کاری رایج وجود دارد و آن‌ها مشکلات متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/) به ارائه هدف کلون کنید، سپس اسلاید را با استفاده از [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) و مستر کلون‌شده کلون کنید. این کار مستر، لِی‌آوت‌های آن و تم مرتبط را به‌صورت یک‌جا منتقل می‌کند.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

این جریان کاری ترجیحی است وقتی اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. ساده‌جایگذاری محتوا روی مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید روی مستر و لِی‌آوت فعلی خود بماند، یک بازنویسی سطح اسلاید از تم منبع را مقداردهی اولیه کنید. متدهای [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) و [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم وارث شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث شده، متد [OverrideTheme::Clear()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/clear/) را صدا بزنید.

### **اعمال بازنویسی تم به یک لِی‌آوت**

یک بازنویسی سطح لِی‌آوت برای اسلایدهایی که از آن لِی‌آوت استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خودش را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/) لِی‌آوت استفاده شوند:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

از تم سطح مستر یا ارائه استفاده کنید وقتی بسیاری از لِی‌آوت‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند؛ از بازنویسی لِی‌آوت وقتی یک خانواده لِی‌آوت نیاز به استایل متفاوت دارد؛ و از بازنویسی اسلاید فقط برای استثناهای واقعی. بازنویسی‌های سطح اسلاید بیش از حد، اعمال تغییرات سراسری تم را دشوارتر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در UI خود نمایش دهد نسبت به تعداد تعریف‌های پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، چون UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و مراجع سبک‌های دیگر ترکیب کند.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و [Background::get_StyleIndex()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/get_styleindex/) جاری را بررسی کنید. `StyleIndex` از `0` برای عدم وجود پرکننده تم استفاده می‌کند؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم یک مجموعه C++ با `idx_get(0)` است که در آن `0` اولین مورد ذخیره شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینه تم به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

نتیجه قابل مشاهده به ورودی تمی که مستر به آن ارجاع می‌دهد و به هر بازنویسی پس‌زمینه در لِی‌آوت یا سطح اسلاید بستگی دارد. اگر یک اسلاید پس‌زمینه خود را داشته باشد، تغییر تنها پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. وقتی به پس‌زمینه نهایی پس از اعمال وراثت نیاز دارید، از [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`StyleIndex` را به‌عنوان یک ایندکس صفر‑مبنای مجموعه در نظر نگیرید. همچنین از کدنویسی ثابت یک شماره سبک از یک فایل و فرض اینکه همان ظاهر را در فایل دیگر دارد پرهیز کنید؛ تعاریف سبک تم بسته به ارائه متفاوت هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، بخش [Presentation Background](/slides/fa/cpp/presentation-background/) را ببینید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌بندی قالب تم شامل مجموعه‌های جداگانه [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_linestyles/) و [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) است. تم‌های اداری معمولاً سه ورودی سبک اصلی دارند که به‌صورت بصری به فرمت‌های ملایم، متوسط و تند متناظر می‌شوند، اما کد باید هر مجموعه را بررسی کند و به‌جای فرض تعداد ثابت، آن را بررسی نماید.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

زمانی که این مجموعه‌ها را در C++ دسترسی می‌دهید، ایندکس مجموعه صفر‑مبنای است: `idx_get(0)` اولین سبک ذخیره‌شده و `idx_get(2)` سومین ‌است. ایندکس‌های مرجع‑سبک یک شکل مفهوم جداگانه‌ای هستند که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapestyle/) در دسترس هستند. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک مورد نیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را عوض می‌کند، یک سایه بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌نماید:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
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
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

برای شکل‌هایی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم قرمز می‌شود، سومین سبک پرکننده تم به سبز جنگلی سفت تبدیل می‌شود و سومین سبک افکت یک سایه بیرونی با فاصله 10 پوینت می‌گیرد. نتیجه بصری دقیق هنوز به این بستگی دارد که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم تم را بازنویسی می‌کند یا نه.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند که در سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) را صدا بزنید. برای یک پس‌زمینه، از [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) استفاده کنید و برای یک پرکننده، از [FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/) بهره ببرید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکننده شکل را از یک اسلاید می‌خواند:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

از داده‌های مؤثر برای تشخیص عیب، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) را بررسی کنید، ممکن است یک بازنویسی مستر، لِی‌آوت، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهد از دست بدهید.

## **سؤالات متداول**

**آیا می‌توانم تم را فقط به یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/) اسلاید استفاده کنید و تم بازنویسی آن را مقداردهی اولیه کنید. تغییر تنها به‌صورت محلی برای آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر به تم‌های موجود خود ادامه می‌دهند.

**ایمن‌ترین راه برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگامی که اسلایدی را جابجا می‌کنید و می‌خواهید ظاهر منبع را حفظ کنید، مستر منبع را به مقصد کلون کنید و اسلاید را با آن مستر با استفاده از [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/) و [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، لِی‌آوت‌ها و تم را به‌همراه هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**

از [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) برای تم اسلاید یا لِی‌آوت و متدهای داده‑مؤثر مربوطه برای اشیای قالب مانند [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) و [FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/) استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.