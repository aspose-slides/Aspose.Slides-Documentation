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
- تم خارجی
- THMX
- رنگ تم
- پالت اضافه
- قلم تم
- استایل تم
- افکت تم
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای C++ جهت ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندینگ سازگار."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هم‌راستا از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای «آگاه به تم» به این تعاریف مشترک ارجاع می‌دهند به‌جای اینکه هر ویژگی بصری را به‌عنوان مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند تعداد زیادی از اشیاء را به‌صورت همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) بازنویسی کند، در حالی که یک طرح‌بندی یا یک اسلاید جداگانه می‌تواند از [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) استفاده کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی طرح‌بندی و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین فرآیندهای تم را نشان می‌دهند: بازرسی تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بازرسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/) متدهای [get_ColorScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) و [get_FormatScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) را در دسترس می‌گذارد. بازرسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه زمانی که ارائه‌ای از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکننده، خط و افکت ذخیره‌شده در تم را گزارش می‌کند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بازرسی کنید و وقتی بازنویسی‌های طرح‌بندی یا اسلاید ممکن است وجود داشته باشد، از فرآیند تم مؤثر نشان داده‌شده در ادامه مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های «آگاه به تم» می‌توانند به یک رنگ منطقی از نوع [SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/) ارجاع دهند. زمانی که ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/) تم را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید حل می‌شوند. اشیایی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال پایان‑به‑پایان زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `Accent4` لینک شده است، رنگ قابل مشاهده آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint واریانت‌های روشن‌تر و تیره‌تر را از یک رنگ تم با اعمال تبدیل‌های رنگی تولید می‌کند. Aspose.Slides این تبدیل‌ها را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن و تیره تولیدشده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - واریانت‌های روشن‌تر و تیره‌تر تولیدشده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، تبدیل‌های روشنایی را بر پنج تا از آن‌ها اعمال می‌کند و نتیجه را ذخیره می‌داند:

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

این واریانت‌ها همچنان مبتنی بر رنگ تم هستند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` مجدداً محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شیوع `SchemeColor` از مقادیر `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که `IColorScheme` اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` ارائه می‌دهد. نقشه‌بندی ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ مقادیری که به‌صورت دینامیک از یک فرم به فرم دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعه قلم اصلی برای عناوین و یک مجموعه قلم فرعی برای متن بدنه است. متدهای [FontScheme::get_Major()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_major/) و [FontScheme::get_Minor()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_minor/) این مجموعه‌ها را در اختیار می‌گذارند.

شناسه‌های قلم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (قلم فرعی لاتین)
* `+mj-lt` - قلم عنوان لاتین (قلم اصلی لاتین)
* `+mn-ea` - قلم بدنه آسیای شرقی (قلم فرعی آسیای شرقی)
* `+mj-ea` - قلم عنوان آسیای شرقی (قلم اصلی آسیای شرقی)

مثال زیر یک عنوان ایجاد می‌کند که از قلم اصلی لاتین تم استفاده می‌کند و یک خط بدنه که از قلم فرعی لاتین تم استفاده می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که یک نام قلم صریح به‌جای شناسه تم دارد، خودکار سوییچ نمی‌شود وقتی که طرح قلم تم تغییر کند.

مجموعه‌های قلم اصلی و فرعی می‌توانند همچنین شامل نگاشت‌های قلم برای سیستم‌های نوشتاری فردی باشند، مانند سیریلی، عربی، ژاپنی، گرجی و ثآنا. برای بازرسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [قلم‌های تم خاص اسکریپت](/slides/fa/cpp/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [قلم‌های پاورپوینت](/slides/fa/cpp/powerpoint-fonts/) نگاه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

رویه‌های زیر مسائل مختلف مرتبط با تم را حل می‌کنند.

### **اعمال یک تم خارجی به اسلایدهای وابسته به یک مستر**

از [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) زمانی استفاده کنید که یک فایل تم PowerPoint (`.thmx`) داشته باشید و بخواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند، استایل جدید بگیرند. مستر موردنظر را از مجموعه [Presentation::get_Masters](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_masters/) که پیاده‌سازی‌شده توسط [IMasterSlideCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/) است، انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده ایجاد می‌کند.
1. تم خارجی را بر روی مستر جدید اعمال می‌کند.
1. مستر جدید را به تمام اسلایدهایی که پیش‌تر به مستر انتخاب‌شده وابسته بودند، اختصاص می‌دهد.
1. `[IMasterSlide]` تازه ساخته‌شده را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته هستند، اعمال می‌کند و ارائه را ذخیره می‌نماید:

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

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند باعث بروز [PptxException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxexception/) یا یکی از زیرکلاس‌های مرتبط با فرمت شود. مسیرهای ورودی کاربر را اعتبارسنجی کنید، خطاهای دسترسی به فایل‌سیستم را مدیریت کنید و فقط پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند بازنگری می‌شوند. اسلایدهای مرتبط با مسترهای دیگر مسترها و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های «آگاه به تم» نسبت به تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و قالب‌بندی‌های صریحی که به‌صورت مستقیم اختصاص یافته‌اند ممکن است بدون تغییر بمانند. بازنویسی‌های سطح طرح‌بندی و اسلاید نیز می‌توانند بر مقادیر ارث‌بری‌شده از مستر جدید اولویت بگیرند.

تم می‌تواند به قلم‌هایی ارجاع دهد که در محیط زمان اجرا موجود نیستند. برای رندرینگ و خروجی سازگار، قلم‌های مورد نیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/cpp/custom-font/) استفاده کنید یا [جایگزینی قلم](/slides/fa/cpp/font-substitution/) را پیکربندی کنید.

این یک روند مستقیم سطح مستر است: متد مسیر یک فایل `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا طرح‌بندی نیست.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چند‑مستر**

وقتی مستر مربوطه از پیش شناخته‌شده نیست، آن را از یک اسلاید نماینده از طریق [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/get_layoutslide/) و [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_masterslide/) به دست آورید. قبل از اعمال هر تمی، مراجع مستر اصلی را ذخیره کنید، زیرا هر فراخوانی یک مستر جدید در ارائه ایجاد می‌کند.

مثال زیر اسلایدهای دو بخش را برای یافتن مسترهایشان استفاده می‌کند و برای هر گروه یک تم خارجی متفاوت اعمال می‌نماید:

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

فراخوانی اول فقط بر اسلایدهایی که به `firstGroupMaster` وابسته بودند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `secondGroupMaster` وابسته بودند. اسلایدهای وابسته به هر مستر دیگری بازنویسی نمی‌شوند.

### **حفظ تم منبع هنگام جابه‌جایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائه دیگری منتقل کنید و طرح اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/) در ارائه هدف کلون کنید، سپس اسلاید را با استفاده از [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) و مستر کلون‌شده کلون کنید. این کار مستر، طرح‑بندی‌ها و تم مرتبط را به‌هم می‌چسباند.

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

این روش ترجیحی است زمانی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. صرفاً کلون کردن محتوا روی یک مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و طرح‑بندی فعلی خود بماند، یک بازنویسی سطح اسلاید از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) و [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) سه جزء اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم مورد استفاده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، [OverrideTheme::Clear()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک طرح‑بندی**

یک بازنویسی سطح طرح‑بندی بر اسلایدهایی که از آن طرح‑بندی استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/) طرح‑بندی فراخوانی شوند:

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

از تم مستر یا تم سطح ارائه زمانی استفاده کنید که بسیاری از طرح‑بندی‌ها و اسلایدها باید طراحی پایه یکسانی داشته باشند، از بازنویسی طرح‑بندی زمانی که یک خانواده طرح‑بندی به استایل متفاوتی نیاز دارد و از بازنویسی اسلاید فقط برای موارد استثنایی واقعی. بازنویسی‌های زیاد در سطح اسلاید باعث می‌شود پیش‌بینی تغییرات تم سراسری بعدی دشوارتر شود.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را در UI خود نشان دهد نسبت به تعداد تعریف‌های پرکننده‌ای که به‌طور فیزیکی در این مجموعه ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و دیگر ارجاع‌های سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background::get_StyleIndex()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/get_styleindex/) را بررسی کنید. `StyleIndex` از `0` برای عدم وجود پرکننده تم استفاده می‌کند؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم یک مجموعه C++ با `idx_get(0)` است، جایی که `0` اولین آیتم ذخیره‌شده را نشان می‌دهد. فرض نکنید هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

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

نتیجه قابل مشاهده به ورودی تمی که توسط مستر ارجاع داده شده و هر بازنویسی پس‌زمینه در سطح طرح‑بندی یا اسلاید بستگی دارد. اگر یک اسلاید پس‌زمینه خود را داشته باشد، تغییر تنها پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. وقتی نیاز به دانستن پس‌زمینه نهایی پس از اعمال ارث‌بری دارید، از [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}
`StyleIndex` را به‌عنوان یک ایندکس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدگذاری ثابت یک شماره سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را داشته باشد، خودداری کنید؛ تعاریف سبک تم به‌صورت خاص به ارائه بستگی دارند.
{{% /alert %}}

{{% alert color="info" title="نکته" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [پس‌زمینه ارائه](/slides/fa/cpp/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح‌بندی فرمت تم شامل مجموعه‌های جداگانه‌ی [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_linestyles/) و [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) است. تم‌های معمولی آفیس اغلب سه ورودی سبک اصلی دارند که به‌صورت بصری به قالب‌بندی‌های زیرک، متوسط و شدید متناظرند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که شمارش ثابت را فرض کند.

![افکت‌های تم زیرک، متوسط و شدید که بر یک شکل یکسان اعمال شده‌اند](presentation-design_10.png)

هنگام دسترسی به این مجموعه‌ها در C++، ایندکس مجموعه صفر‑پایه است: `idx_get(0)` اولین سبک ذخیره‌شده و `idx_get(2)` سومین است. ایندکس‌های ارجاع سبک یک شکل مفهومی جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر اشکالی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های سبک لازم را بررسی می‌کند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایه خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم قرمز می‌شود، سومین سبک پرکننده تم به سبزی متالیک سفت تبدیل می‌شود و در سومین سبک افکت یک سایه خارجی با فاصله 10 نقطه اضافه می‌شود. نتیجه بصری نهایی همچنان به این بستگی دارد که هر شکل به کدام اسلات سازگار است و آیا قالب‌بندی مستقیم بازنویسی تم را خنثی می‌کند یا خیر.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

آبجکت‌های خام تم به شما می‌گویند که در سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر نشان می‌دهند که یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) را فراخوانی کنید. برای یک پس‌زمینه، از [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) استفاده کنید و برای یک پرکننده، از [FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/) استفاده کنید.

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) را بررسی کنید، ممکن است یک بازنویسی مستر، طرح‑بندی، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد از دست بدهید.

## **سؤالات متداول**

**آیا اعمال یک تم خارجی بر همه اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) فقط اسلایدهایی را که به مستر انتخاب‌شده وابسته هستند، بازنویسی می‌کند. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط بر یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/) اسلاید استفاده کنید و تم بازنویسی آن را مقداردهی اولیه کنید. تغییر فقط به‌صورت محلی برای آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر به تم‌های موجود خود ادامه می‌دهند.

**امن‌ترین روش برای انتقال یک تم از یک ارائه به ارائه دیگر چیست؟**

هنگامی که یک اسلاید را جابه‌جا می‌کنید و می‌خواهید ظاهر منبع را حفظ کنید، مستر منبع را به مقصد کلون کنید و سپس اسلاید را با آن مستر کلون کنید؛ برای این کار از [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imastersslidecollection/addclone/) و [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) استفاده کنید. این کار مستر، طرح‑بندی‌ها و تم را همراه هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها مشاهده کنم؟**

از [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) برای تم اسلاید یا طرح‑بندی استفاده کنید و برای اشیای فرمت مانند [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) و [FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/) متدهای داده‑مؤثر مربوطه را فراخوانی کنید. این APIها مقادیر حل‑شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.