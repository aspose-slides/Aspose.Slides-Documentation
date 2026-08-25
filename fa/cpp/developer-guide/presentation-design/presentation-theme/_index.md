---
title: مدیریت قالب‌های ارائه در C++
linktitle: قالب ارائه
type: docs
weight: 10
url: /fa/cpp/presentation-theme/
keywords:
- قالب PowerPoint
- قالب ارائه
- قالب اسلاید
- تنظیم قالب
- تغییر قالب
- مدیریت قالب
- رنگ قالب
- پالت اضافی
- قلم قالب
- سبک قالب
- اثر قالب
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "قالب‌های اصلی ارائه در Aspose.Slides برای C++ را برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان مدیریت کنید."
---
## **مقدمه**

یک تم ارائه یک مجموعهٔ هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و اثرها را تعریف می‌کند. اشیاء آگاه از تم به این تعاریف مشترک ارجاع می‌دهند به جای این که هر ویژگی بصری را به عنوان مقدار ثابت ذخیره کنند، به‌طوری که تغییر تم می‌تواند بسیاری از اشیاء را به‌صورت همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/) بازنویسی کند، در حالی که یک لایه یا اسلاید فردی می‌تواند از [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/) استفاده کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیرهٔ ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه و بازنویسی اسلاید.

![اجزاء تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و اثرها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بازبینی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و اثر، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بازرسی تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/) متدهای [get_ColorScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)، و [get_FormatScheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) را در اختیار می‌گذارد. بازبینی این مجموعه‌ها پیش از تغییر آنها به‌ویژه زمانی مفید است که یک ارائه از منبع خارجی آمده باشد، چون تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکننده، خط و اثر ذخیره‌شده در تم را گزارش می‌کند:

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

اگر یک فایل از چند مستر استفاده کند، فرض نکنید هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بازبینی کنید و هنگام وجود بازنویسی‌های لایه یا اسلاید، از جریان کاری تم مؤثر نشان‌داده‌شده در ادامهٔ این مقاله استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از enumeration [SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی مربوطه در [IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/) تم تغییر می‌کند، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال پایان به پایان زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکنندهٔ مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `Accent4` متصل است، رنگ قابل مشاهدهٔ آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیل‌های رنگی، انواع روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/colortransformoperation/) در دسترس قرار می‌دهد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تری که از پالت اضافی تولید می‌شوند](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - انواع روشن‌تر و تیره‌تری که از رنگ‌های اصلی تم ساخته شده‌اند.

مثال زیر شش مستطیل بر پایهٔ `Accent4` ایجاد می‌کند، برای پنج‌تا از آنها تبدیل روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این انواع بر پایهٔ رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/) همان اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` در اختیار می‌گذارد. نقشه ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

اینها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ مقادیری که به‌صورت پویا از یک شکل به شکل دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعهٔ قلم اصلی برای عناوین و یک مجموعهٔ قلم فرعی برای متن بدنه است. متدهای [FontScheme::get_Major()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_major/) و [FontScheme::get_Minor()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/fontscheme/get_minor/) این مجموعه‌ها را در دسترس می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن به کار روند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم عنوان لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه شرق آسیایی (Minor East Asian Font)
* `+mj-ea` - قلم عنوان شرق آسیایی (Major East Asian Font)

مثال زیر یک عنوان ایجاد می‌کند که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که دارای نام قلم صریح به جای شناسهٔ تم باشد، هنگام تغییر طرح قلم تم به‌صورت خودکار سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری فردی همچون سیریلیک، عربی، ژاپنی، گرجی و ثآنا باشند. برای بازبینی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به بخش [Script-Specific Theme Fonts](/slides/fa/cpp/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/cpp/powerpoint-fonts/) رجوع کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

دو جریان کاری رایج وجود دارد که هر یک مشکل متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام انتقال اسلایدها**

اگر می‌خواهید اسلایدی را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/) به ارائه هدف کلون کنید، سپس اسلاید را همراه با مستر کلون‌شده با [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، لایه‌های آن و تم مرتبط را به‌صورت یک‌جا منتقل می‌کند.

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

این جریان کاری در زمانی که اسلاید منبع باید همان ظاهر را در مقصد داشته باشد ترجیح داده می‌شود. ساده‌ترین کلون محتوا بر روی مستری نامرتبط در مقصد می‌تواند رنگ‌های مبتنی بر تم، قلم‌ها، پس‌زمینه‌ها و اثرها را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لایهٔ فعلی خود بماند، یک بازنویسی سطح اسلاید از تم منبع راه‌اندازی کنید. متدهای [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)، و [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، متد [OverrideTheme::Clear()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/overridetheme/clear/) را فرا بگیرید.

### **اعمال بازنویسی تم به یک لایه**

بازنویسی سطح لایه برای تمام اسلایدهایی که از آن لایه استفاده می‌کنند اعمال می‌شود، مگر آنکه اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای راه‌اندازی می‌توانند از طریق [IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/) لایه استفاده شوند:

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

هنگامی که بسیاری از لایه‌ها و اسلایدها باید همان طراحی پایه را به اشتراک بگذارند، از تم در سطح مستر یا ارائه استفاده کنید؛ وقتی یک خانوادهٔ لایه نیاز به استایل متفاوتی دارد، از بازنویسی لایه استفاده کنید؛ و برای استثناهای واقعی تنها از بازنویسی اسلاید بهره ببرید. بازنویسی‌های بیش از حد در سطح اسلاید، اعمال تغییرات سراسری تم را در آینده دشوارتر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینهٔ تم**

پرکننده‌های پس‌زمینهٔ تم در [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینهٔ بیشتری در UI خود نشان دهد نسبت به تعداد تعریف‌های پرکنندهٔ فیزیکی موجود در این مجموعه، چون UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و دیگر مراجع سبک ترکیب کند.

![گالری سبک‌های پس‌زمینهٔ PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعهٔ ذخیره‌شده و مقدار فعلی [Background::get_StyleIndex()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/get_styleindex/) را بازبینی کنید. `StyleIndex` عدد `0` را برای عدم داشتن پرکنندهٔ تم استفاده می‌کند؛ مقادیر مثبت ارجاع به سبک پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم یک مجموعهٔ C++ با `idx_get(0)` است که `0` نشان‌دهندهٔ اولین مورد ذخیره‌شده است. فرض نکنید هر ارائه همان تعداد سبک پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکنندهٔ پس‌زمینهٔ موجود را گزارش می‌کند، یک ارجاع پس‌زمینهٔ تم به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی تمی که توسط مستر ارجاع داده شده و به هر بازنویسی پس‌زمینهٔ لایه یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. زمانی که نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری دارید، از [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}
`StyleIndex` را به‌عنوان یک ایندکس مبتنی بر صفر برای مجموعه در نظر نگیرید. همچنین از کدگذاری صریح یک شمارهٔ سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعریف‌های سبک تم به‌صورت ارائه‑محور هستند.
{{% /alert %}}

{{% alert color="info" title="نکته" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/cpp/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی اثرهای تم**

یک طرح قالب تم شامل مجموعه‌های جداگانهٔ [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_linestyles/)، و [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) است. تم‌های اداری معمولاً سه ورودی سبک اصلی دارند که بصورت ظریف، متوسط و پررنگ نمایش داده می‌شوند، اما کد باید هر مجموعه را بازبینی کند به‌جای این که تعداد ثابت فرض کند.

![اثرهای ظریف، متوسط و پررنگ تم که بر همان شکل اعمال شده‌اند](presentation-design_10.png)

زمانی که این مجموعه‌ها را در C++ دسترسی می‌یابید، ایندکس مجموعه صفر‑مبنا است: `idx_get(0)` اولین سبک ذخیره‌شده و `idx_get(2)` سومین است. ایندکس‌های مرجع سبک یک شکل یک مفهوم جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapestyle/) در دسترس قرار می‌گیرد. تغییر یک سبک تم بر اشکالی که به آن مرجع دارند تأثیر می‌گذارد؛ اشکالی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های سبک مورد نیاز را بررسی می‌کند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک اثر فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز، سومین سبک پرکننده تم به سبز جنگلی سفت و سومین سبک اثر یک سایهٔ خارجی با فاصلهٔ 10 پوینت می‌گیرد. نتیجهٔ بصری دقیق هنوز به این بستگی دارد که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم بازنویسی تم را نادیده می‌گیرد یا نه.

![سبک‌های اثر تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

شیء تم خام به شما می‌گوید در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) را فراخوانی کنید. برای پس‌زمینه، از [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) استفاده کنید و برای یک پرکننده، از [FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/) بهره ببرید.

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_mastertheme/) را بازبینی کنید، ممکن است یک بازنویسی در مستر، لایه، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سؤالات متداول**

**آیا می‌توانم یک تم را فقط بر یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [IOverrideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ioverridethememanager/) اسلاید استفاده کنید و تم بازنویسی آن را راه‌اندازی کنید. تغییر به‌صورت محلی بر همان اسلاید باقی می‌ماند؛ سایر اسلایدها تم‌های موجود خود را ارث می‌بخشند.

**ایمن‌ترین روش برای انتقال یک تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگامی که اسلایدی را منتقل می‌کنید و می‌خواهید ظاهر منبع را حفظ کنید، مستر منبع را به مقصد کلون کنید و سپس اسلاید را با همان مستر کلون‌شده با استفاده از [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslidecollection/addclone/) و [ISlideCollection::AddClone()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، لایه‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر پس از ارث‌بری و بازنویسی‌ها را ببینم؟**

از [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) برای یک اسلاید یا تم لایه استفاده کنید و برای اشیای قالب مانند [Background::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/background/geteffective/) و [FillFormat::GetEffective()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/geteffective/) متدهای دادهٔ مؤثر متناظر را فراخوانی کنید. این API‌ها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.