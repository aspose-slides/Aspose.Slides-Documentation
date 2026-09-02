---
title: إدارة موضوعات العرض التقديمي في C++
linktitle: موضوع العرض التقديمي
type: docs
weight: 10
url: /ar/cpp/presentation-theme/
keywords:
- موضوع PowerPoint
- موضوع العرض التقديمي
- موضوع الشريحة
- تعيين الموضوع
- تغيير الموضوع
- إدارة الموضوع
- لون الموضوع
- لوحة إضافية
- خط الموضوع
- نمط الموضوع
- تأثير الموضوع
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "إتقان موضوعات العرض التقديمي في Aspose.Slides للغة C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint مع علامة تجارية متسقة."
---
## **المقدمة**

يعرف موضوع العرض التقديمي مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تشير الكائنات الواعية للموضوع إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير الموضوع أن يحدث تحديثاً للعديد من الكائنات في آن واحد.

في Aspose.Slides، يتوفر موضوع العرض على مستوى العرض من خلال [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للموضوع على مستويات أدنى. يمكن للماستر أن يتجاوز موضوع العرض عبر [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)، بينما يمكن لتخطيط أو شريحة فردية أن تستخدم [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). عملياً، يتم حل الموضوع الفعلي لشريحة ما من خلال سلسلة الوراثة هذه: موضوع العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات الموضوع: ألوان، خطوط، أنماط خلفية، وتأثيرات](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل شائع للموضوع: فحص الموضوع، تغيير الألوان والخطوط، نسخ أو تطبيق موضوع، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص موضوع**

يكشف كائن [MasterTheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/) عن طرق [get_ColorScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)، و[get_FormatScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). يكون فحص هذه المجموعات قبل تعديلها مفيداً خصوصاً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ خصائص الموضوع الرئيسية ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في الموضوع:

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

إذا كان الملف يستخدم عدة ماسترز، لا تفترض أن كل شريحة لها نفس الموضوع الفعّال. فحص الماستر المرتبط بالشريحة، واستخدم سير عمل الموضوع الفعّال الموضح لاحقاً في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان الموضوع**

يمكن للتعبئات، الخطوط، والنصوص الواعية للموضوع أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/) الخاص بالموضوع، يتم حل جميع الكائنات التي لا تزال تشير إلى ذلك اللون وفقاً للقيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير عند تحديث لون الموضوع.

المثال الشامل التالي ينشئ شكلاً يستخدم `Accent4`، يغيّر لون `Accent4` في الموضوع إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون التعبئة الفعّال:

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

نظرًا لأن المستطيل لا يزال مرتبطاً بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير الموضوع. إذا استبدلت اللون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

يستمد PowerPoint متغيرات أفتح وأغمق من لون الموضوع عن طريق تطبيق تحويلات لونية. تعرض Aspose.Slides هذه التحويلات عبر [ColorTransformOperation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للموضوع والألوان الأفتح والأغمق المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للموضوع.

**2** - المتغيرات الأفتح والأغمق المنتجة من الألوان الرئيسية للموضوع.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحويلات سطوع على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتغيرات قائمة على لون الموضوع. إذا تغيّر `Accent4` لاحقاً، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/) القيم `Text1`, `Background1`, `Text2`, و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/) نفس فتحات الموضوع كـ `Dark1`, `Light1`, `Dark2`, و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات الموضوع؛ ليست قيماً تُحوَّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط الموضوع**

تحتوي مخططة خطوط الموضوع على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية لنص الجسم. تكشف الطريقتان [FontScheme::get_Major()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_major/) و[FontScheme::get_Minor()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_minor/) تلك المجموعات.

يمكن استخدام معرّفات خطوط الموضوع المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط جسم النص اللاتيني (Minor Latin Font)
* `+mj-lt` - خط عنوان النص اللاتيني (Major Latin Font)
* `+mn-ea` - خط جسم النص شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط عنوان النص شرق آسيوي (Major East Asian Font)

المثال التالي ينشئ عنواناً يستخدم الخط اللاتيني الرئيسي وخط جسم نص يستخدم الخط اللاتيني الثانوي. ثم يغير خطوط الموضوع ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع نص الجسم الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف موضوع لن يتبدل تلقائياً عندما تتغيّر مخططة خطوط الموضوع.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والثانوية أيضاً على خرائط خطوط للأنظمة الكتابية الفردية، مثل السيريلية، العربية، اليابانية، الجورجية، والثانا. لتفقد، إضافة، استبدال أو إزالة هذه الخرائط، انظر [خطوط الموضوع الخاصة بالسكريبت](/slides/ar/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق موضوع**

هناك سيرا عمل شائعين، كل منهما يحل مشكلة مختلفة.

### **الحفاظ على موضوع المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض المستهدف باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/)، ثم استنسخ الشريحة باستخدام [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) والماستر المستنسخ. ينقل هذا الماستر وتخطيطاته والموضوع المرتبط معه معاً.

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

هذا هو سير العمل المفضّل عندما يجب أن تبدو الشريحة المصدرية نفس الشكل في الوجهة. مجرد استنساخ المحتوى على ماستر غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالموضوع.

### **تطبيق قيم الموضوع على شريحة موجودة**

إذا كان على الشريحة المستهدفة البقاء على الماستر والتخطيط الحاليين، قم بتهيئة تجاوز على مستوى الشريحة من الموضوع المصدر. تنسخ الطرق [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) المكونات الثلاثة الرئيسية للموضوع إلى التجاوز.

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

يغيّر هذا الموضوع المستخدم لتلك الشريحة دون تغيير الموضوع الموروث من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme::Clear()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز موضوع على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص. يمكن استخدام نفس طرق التهيئة عبر [IOverrideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالتخطيط:

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

استخدم موضوع ماستر أو مستوى عرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز تخطيط عندما تحتاج عائلة تخطيط واحدة إلى نمط مختلف، واستخدم تجاوز شريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات الكثيرة على مستوى الشريحة تغييرات الموضوع العالمية المستقبلية أصعب توقعاً.

## **تحديث أنماط خلفية الموضوع**

تُخزن تعبئات خلفية الموضوع في [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). يمكن لـ PowerPoint عرض مزيد من خيارات الخلفية في واجهته مقارنة بعدد تعريفات التعبئة المخزَّنة فعلياً في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات الموضوع مع ألوان الموضوع وإشارات نمطية أخرى.

![معرض أنماط خلفية PowerPoint لموضوع عرض تقديمي](presentation-design_8.png)

قبل استخدام نمط خلفية، فحص المجموعة المخزَّنة و[Background::get_StyleIndex()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/get_styleindex/). يستخدم `StyleIndex` القيمة `0` لعدم وجود تعبئة موضوع؛ القيم الموجبة تشير إلى مراجع أنماط خلفية موضوع. هذا مختلف عن فهرسة مجموعة C++ مباشرةً باستخدام `idx_get(0)`, حيث `0` يعني العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئة الخلفيات المتاحة، يعين مرجع خلفية موضوع للماستر الأول، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على إدخال الموضوع المرجعي من قبل الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) عندما تحتاج لمعرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تتعامل مع `StyleIndex` كفهرس مجموعة يبدأ من الصفر. وتجنب أيضاً ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعاريف أنماط الموضوع خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
لمزيد من التنسيق المباشر للخلفية ووراثة الخلفية، راجع [خلفية العرض](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات الموضوع**

تحتوي مخططة تنسيق الموضوع على مجموعات منفصلة لـ [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_linestyles/)، و[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). غالباً ما تحتوي موضوعات Office على ثلاثة إدخالات أساسية تتCorrespond بصرياً إلى تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الكود فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات موضوع خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C++، يكون فهرس المجموعة يبدأ من الصفر: `idx_get(0)` هو أول نمط مخزن و`idx_get(2)` هو الثالث. فهارس مراجع النمط للشكليات هي مفهوم منفصل، يُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapestyle/). تعديل نمط موضوع يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود الإدخالات المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط التعبئة الثالث، يفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تشير إلى هذه الفتحات، يصبح نمط الخط الموضوع الأول أحمر، ويصبح نمط التعبئة الموضوع الثالث أخضر غابوي صلب، ويضيف نمط التأثير الثالث ظلًا خارجيًا بمسافة 10 نقاط. لا يزال النتيجة البصرية الدقيقة تعتمد على الفتحات التي تشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز الموضوع.

![أنماط تأثيرات الموضوع بعد تغيير الخط والتعبئة وإعدادات الظل](presentation-design_11.png)

## **قراءة القيم الفعّالة للموضوع**

تخبرك كائنات الموضوع الخام بما تم تعريفه على مستوى معين. القيم الفعّالة تخبرك بما تستخدمه الشريحة أو الشكل فعلياً بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). للخلفية، استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/)، وللتعبئة استخدم [FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ الموضوع الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/)، قد تفوتك تجاوزات ماستر، تخطيط، شريحة أو شكل تغير المظهر النهائي.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق موضوع على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [IOverrideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالشريحة وابدأ موضوع التجاوز الخاص بها. يبقى التغيير محلياً لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة موضوعاتها الحالية.

**ما هي الطريقة الأكثر أماناً لنقل موضوع من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/). هذا يحافظ على الماستر، التخطيطات، والموضوع معاً.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) لموضوع شريحة أو تخطيط والطرق المقابلة للحصول على بيانات فعّالة لكائنات التنسيق مثل [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) و[FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.