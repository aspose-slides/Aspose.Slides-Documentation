---
title: مدیریت تم‌های ارائه در C++
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/cpp/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- تم خارجی
- THMX
- رنگ تم
- پالت افزوده
- قلم تم
- سبک تم
- اثر تم
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای C++ را برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ سازگار مدیریت کنید."
---
## **مقدمه**

یک تم ارائه یک مجموعه هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیاء آگاه از تم به این تعاریف مشترک ارجاع می‌دهند به جای ذخیره کردن هر ویژگی بصری به عنوان مقدار ثابت، بنابراین تغییر تم می‌تواند بسیاری از اشیاء را یک‌باره به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/)در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق[MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)بازنویسی کند، در حالی که یک لایه‌بندی یا اسلاید تک‌تک می‌تواند از[IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)استفاده کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه‌بندی و بازنویسی اسلاید.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بازبینی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بازبینی یک تم**

شیء[MasterTheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/)متدهای[get_ColorScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)،[get_FontScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)، و[get_FormatScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_formatscheme/)تم را فاش می‌کند. بازبینی این مجموعه‌ها قبل از تغییر آن‌ها بویژه وقتی که یک ارائه از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بازبینی کنید و از جریان کاری تم مؤثر که در ادامه مقاله نشان داده شده استفاده کنید زمانی که بازنویسی‌های لایه‌بندی یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارشگر[SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/)ارجاع دهند. وقتی ورودی متناظر در[IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/)تم را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند با مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها به انتهای زیر یک شکل ایجاد می‌کند که از`Accent4` استفاده می‌کند، رنگ`Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، آن را باز می‌گرداند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

از آنجایی که مستطیل همچنان به`Accent4` لینک شده است، رنگ قابل مشاهده‌اش پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد داشت.

### **استفاده از رنگ‌ها از پالت افزوده**

PowerPoint با اعمال تبدیل‌های رنگی، واریانت‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق[ColorTransformOperation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/colortransformoperation/)فاش می‌کند.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - واریانت‌های روشن‌تر و تیره‌تر که از رنگ‌های اصلی تم تولید شده‌اند.

مثال زیر شش مستطیل بر پایه`Accent4` ایجاد می‌کند، تبدیل‌های روشنایی را بر پنج مورد از آن‌ها اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این واریانت‌ها همچنان بر پایه رنگ تم باقی می‌مانند. اگر بعداً `Accent4` تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به شکاف‌های `IColorScheme`**

شمارشگر[SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/)از`Text1`،`Background1`،`Text2` و`Background2`استفاده می‌کند، در حالی که[IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/)همان شکاف‌های تم را به‌صورت`Dark1`،`Light1`،`Dark2` و`Light2`فاش می‌کند. نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان شکاف‌های تم هستند؛ مقادیری که به‌صورت پویا از یک فرم به فرم دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعه قلم عمده برای سرعنوان‌ها و یک مجموعه قلم فرعی برای متن بدنه است. متدهای[FontScheme::get_Major()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_major/)و[FontScheme::get_Minor()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_minor/)آن مجموعه‌ها را فاش می‌کنند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

مثال زیر یک سرعنوان که از قلم لاتین عمده تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند ایجاد می‌کند. سپس قلم‌های تم را تغییر داده و نتیجه را ذخیره می‌کند:

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

سرعنوان از قلم عمده پیروی می‌کند و متن بدنه از قلم فرعی. متنی که دارای نام قلم صریح به جای شناسه تم باشد، به‌صورت خودکار هنگام تغییر طرح قلم تم تعویض نمی‌شود.

مجموعه‌های قلم عمده و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری منفرد مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا باشند. برای بازبینی، افزودن، جایگزینی یا حذف این نگاشت‌ها، ببینید [Script-Specific Theme Fonts](/slides/fa/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/cpp/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

جریان‌های کاری زیر مشکلات مختلف مربوط به تم را حل می‌کنند.

### **اعمال یک تم خارجی به اسلایدهای وابسته به یک مستر**

از[IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/)استفاده کنید وقتی یک فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند را دوباره‌استایل کنید. مستر را از مجموعه[Presentation::get_Masters](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_masters/)که پیاده‌سازی‌گر[IMasterSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/)است، انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

این متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده ایجاد می‌کند.
1. تم خارجی را بر مستر جدید اعمال می‌کند.
1. مستر جدید را به تمام اسلایدهایی که قبلاً به مستر انتخاب‌شده وابسته بودند، اختصاص می‌دهد.
1. [IMasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/)جدید ایجاد‌شده را باز می‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند و ارائه را ذخیره می‌نماید:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند خطای[PptxException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxexception/)یا یکی از زیرکلاس‌های مربوط به فرمت را تولید کند. مسیرهای ارائه‌شده توسط کاربران را اعتبارسنجی کنید، خطاهای دسترسی به سیستم‌فایل را مدیریت کنید و فقط پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند مجدداً تخصیص می‌یابند. اسلایدهای مرتبط با مسترهای دیگر مستر و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم بر اساس تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و سایر قالب‌بندی‌های صریح ممکن است بدون تغییر باقی بمانند. بازنویسی‌های سطح لایه‌بندی و سطح اسلاید نیز می‌توانند بر مقادیر ارث‌بری‌شده از مستر جدید تقدم پیدا کنند.

تم ممکن است به قلم‌هایی ارجاع دهد که در محیط زمان اجرا در دسترس نیستند. برای رندر و صادرات سازگار، قلم‌های موردنیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/cpp/custom-font/)ارائه دهید یا [جایگزینی قلم](/slides/fa/cpp/font-substitution/)را پیکربندی کنید.

این یک جریان کاری مستقیم سطح مستر است: متد مسیر فایل `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم سطح اسلاید یا لایه‌بندی نیست.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چندمستری**

وقتی مستر مرتبط از پیش شناخته شده نیست، آن را از یک اسلاید مع represent بسیاری از اسلایدها از طریق[ISlide::get_LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/get_layoutslide/)و[ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_masterslide/)به‌دست آورید. قبل از اعمال هر تمی، مراجع مستر اصلی را ذخیره کنید زیرا هر فراخوانی مستر دیگری در ارائه می‌سازد.

مثال زیر از اسلایدهای دو بخش برای یافتن مسترهایشان استفاده می‌کند و یک تم خارجی متفاوت را به هر گروه اعمال می‌نماید:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

فراخوانی اول فقط بر اسلایدهایی که به`firstGroupMaster` وابسته‌اند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به`secondGroupMaster` وابسته‌اند. اسلایدهای متعلق به هر مستر دیگر دوباره‌استایل نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/)به ارائه هدف کلون کنید، سپس اسلاید را با[ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/)و مستر کلون‌شده کلون کنید. این کار مستر، لایه‌بندی‌های آن و تم مرتبط را به‌هم می‌چسباند.

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

این جریان کاری ترجیحی است وقتی اسلاید منبع باید در مقصد ظاهر یکسانی داشته باشد. صرفاً کلون محتوا بر مستری نامرتبط در مقصد می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید روی مستر و لایه‌بندی فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای[OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)،[OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/)سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و برگشت به مقادیر ارث‌بری‌شده،[OverrideTheme::Clear()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/clear/)را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لایه‌بندی**

یک بازنویسی سطح لایه‌بندی بر اسلایدهایی که از آن لایه‌بندی استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خودش را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق[IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/)لایه‌بندی استفاده شوند:

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

وقتی تعداد زیاد اسلایدها و لایه‌بندی‌ها باید طراحی پایه یکسانی داشته باشند، از تم سطح مستر یا ارائه استفاده کنید؛ وقتی یک خانواده لایه‌بندی به استایل متفاوتی نیاز دارد، از بازنویسی لایه‌بندی استفاده کنید؛ و برای استثناهای واقعی فقط بازنویسی اسلاید به کار رود. بازنویسی‌های اسلایدی بیش از حد، اعمال تغییرات تم سراسری بعدی را دشوار می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در[FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود نسبت به تعداد تعریف‌های پرکننده موجود در این مجموعه ارائه دهد، زیرا رابط می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاع‌های سبک ترکیب کند.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و[Background::get_StyleIndex()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/get_styleindex/)فعلی را بازبینی کنید. `StyleIndex` برای عدم وجود پرکننده تم مقدار `0` را دارد؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم یک مجموعه C++ با `idx_get(0)` است که `0` به اولین آیتم ذخیره‌شده اشاره دارد. فرض نکنید هر ارائه تعداد یکسانی از سبک‌های پس‌زمینه دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینه تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به ورودی تم ارجاع‌شده توسط مستر و هر بازنویسی پس‌زمینه در سطح لایه‌بندی یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خودش را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. وقتی نیاز به دانستن پس‌زمینه نهایی پس از اعمال ارث‌بری دارید، از[Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/)استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`StyleIndex` را به‌عنوان یک ایندکس صفر‌پایه مجموعه در نظر نگیرید. همچنین از کدگذاری ثابت شماره یک سبک در یک فایل و فرض یک ظاهر مشابه در فایل دیگر خودداری کنید؛ تعاریف سبک تم مخصوص ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/cpp/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

طرح فرمت تم شامل مجموعه‌های جداگانه[FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)،[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_linestyles/)، و[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_effectstyles/)است. تم‌های رایج Office اغلب شامل سه ورودی سبک اصلی هستند که به‌صورت بصری به فرمت‌های ملایم، متوسط و پررنگ متناظر می‌شوند، اما کد باید هر مجموعه را بازبینی کند به‌جای این‌که شمار ثابت فرض کند.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

زمانی که این مجموعه‌ها را در C++ دسترسی می‌کنید، ایندکس مجموعه صفر‑پایه است: `idx_get(0)` اولین سبک ذخیره‌شده و `idx_get(2)` سومین است. ایندکس‌های مرجع‌استایل یک شکل مفهوم جداگانه‌ای است که از طریق[IShapeStyle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapestyle/)فاش می‌شود. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌های دارای قالب‌بندی مستقیم ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک موردنیاز موجودند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این شکاف‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز، سومین سبک پرکننده تم به سبز جنگلی ثابت و سومین سبک افکت یک سایهٔ بیرونی با فاصلهٔ 10 پوینت می‌گیرد. نتیجهٔ بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام شکاف‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم ارجاع دارد یا نه.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **تعیین اینکه آیا یک پرکنندهٔ جامد مؤثر از یک رنگ تم استفاده می‌کند**

یک پرکننده می‌تواند مستقیماً روی شیء ذخیره شود یا از یک پاراگراف، لایه‌بندی، مستر، سبک تم یا سطح دیگر قالب‌بندی ارث‌بری شود. برای حل این سلسله‌مراتب به یک [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/)غیرقابل تغییر، متد[IFillFormat::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformat/geteffective/)را فراخوانی کنید. ابتدا[get_FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/get_filltype/)را بررسی کنید. فقط وقتی مقدار `FillType::Solid` باشد باید ویژگی‌های پرکنندهٔ جامد را بخوانید.

برای یک پرکنندهٔ جامد،[IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/)مقدار نهایی RGB رندر شده پس از ارث‌بری، جستجوی تم و اعمال تبدیل‌های رنگی را برمی‌گرداند. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/)اسلات منطقی[SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/)مربوطه را برمی‌گرداند، مانند `Text1` یا `Accent6`. مقدار `SchemeColor::NotDefined` به این معناست که پرکنندهٔ جامد مؤثر بر پایهٔ یک رنگ طرح نیست. در یک جریان کاری که پرکننده‌ها یا رنگ‌های تم یا رنگ‌های RGB مستقیم هستند، این مقدار یک پرکنندهٔ RGB مستقیم را نشان می‌دهد.

از مقدار محلی[IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icolorformat/get_schemecolor/)به‌تنهایی برای طبقه‌بندی یک پرکننده استفاده نکنید. برای مثال، بخشی از متن ممکن است اسلومر رنگ طرح محلی نداشته باشد، بنابراین مقدار محلی آن `NotDefined` است، در حالی که پرکننده مؤثر آن یک رنگ تم را ارث می‌برد و به `Text1` یا `Accent6` حل می‌شود. برعکس، `get_SolidFillSchemeColor` به شما می‌گوید کدام اسلات منطقی تم رنگ مؤثر را تولید کرده است، اما نمی‌گوید آن اسلات از شیء، پاراگراف، لایه‌بندی، مستر یا سطح دیگری آمده است.

مثال زیر یک ارائه را بارگذاری می‌کند، هر دو پرکنندهٔ شکل و پرکنندهٔ بخش متن را مرور می‌کند، هر مقدار RGB نهایی و اسلات طرح مرتبط را چاپ می‌کند و پرکننده‌های جامدی را که تغییرات رنگ تم را دنبال نمی‌کنند پرچم‌گذاری می‌کند:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

شاخهٔ `NotDefined` یک فهرست حسابرسی از پرکننده‌های جامدی ارائه می‌دهد که به تغییرات اسلات‌های رنگ تم پاسخ نمی‌دهند. وقتی یک ارائه باید از یک پالت برند جدید پیروی کند، این اشیاء را بازبینی کنید. مقدار RGB گزارش‌شده هنوز ظاهر فعلی را نشان می‌دهد، در حالی که مقدار طرح توضیح می‌دهد که آیا آن ظاهر به تم متصل است یا خیر.

اشیاء فرمت مؤثر snapshots هستند. بعد از تغییر تم ارائه، یک بازنویسی تم یا هر قالب‌بندی ارث‌بری، `GetEffective` را دوباره صدا بزنید و قبل از مقایسه یا گزارش رنگ‌ها یک شیء جدید `IFillFormatEffectiveData` بخوانید.

## **خواندن مقادیر مؤثر تم**

اشیای تم خام به شما می‌گویند در سطحی خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل بعد از حل ارث‌بری و بازنویسی‌های محلی دقیقاً چه چیزی استفاده می‌کند. برای یک اسلاید، [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)را صدا بزنید. برای پس‌زمینه، از[Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/)استفاده کنید و برای پرکننده، از[FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/)استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/)را بازبینی کنید، ممکن است یک بازنویسی مستر، لایه‌بندی، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد از دست بدهید.

## **پرسش‌های متداول**

**اعمال یک تم خارجی بر تمام اسلایدهای ارائه تأثیر می—گذارد؟**

نه. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/)فقط اسلایدهایی را که به مستر انتخاب‌شده وابسته‌اند دوباره تخصیص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط بر یک اسلاید بدون تغییر مستر اعمال کنم؟**

بله. از[IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/)اسلاید استفاده کنید و تم بازنویسی‌شدهٔ آن را مقداردهی اولیه کنید. تغییر فقط به‌صورت محلی بر همان اسلاید باقی می‌ماند؛ اسلایدهای دیگر ادامه می‌دهند تم‌های موجود خود را ارث‌بری کنند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

وقتی یک اسلاید را جابجا می‌کنید و ظاهر منبع را حفظ می‌کنید، مستر منبع را به مقصد کلون کنید و اسلاید را با آن مستر از طریق[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/)و[ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/)کلون کنید. این کار مستر، لایه‌بندی‌ها و تم را همراه نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

برای یک اسلاید یا تم لایه‌بندی از[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)استفاده کنید و برای اشیای قالب‌بندی مانند[Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/)و[FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/)متدهای دادهٔ مؤثر مربوطه را صدا بزنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.