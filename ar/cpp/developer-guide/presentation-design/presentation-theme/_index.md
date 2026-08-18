---
title: إدارة سمات العرض في C++
linktitle: قالب العرض
type: docs
weight: 10
url: /ar/cpp/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- لون السمة
- لوحة الألوان الإضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض
- C++
- Aspose.Slides
description: "إتقان سمات العروض التقديمية في Aspose.Slides للغة C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint مع هوية علامية متسقة."
---
## **المقدمة**

يُعرّف قالب العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والظلال. تُشير الكائنات المتوافقة مع القالب إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيّر القالب تحديث عدة كائنات في آن واحد.

في Aspose.Slides، يتوفر قالب المستوى العام للعرض عبر [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للقالب في مستويات أدنى. يمكن للماستر أن يتجاوز قالب العرض عبر [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)، بينما يمكن للتخطيط أو الشريحة الفردية استخدام [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). عمليًا، يتم حل القالب الفعّال لشريحة ما عبر سلسلة الوراثة هذه: قالب العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات القالب: الألوان والخطوط وأنماط الخلفية والظلال](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل القالب شيوعًا: فحص القالب، تغيير الألوان والخطوط، نسخ أو تطبيق قالب، تحديث أنماط الخلفية والظلال، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص القالب**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/) طريقة [get_ColorScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)، و[get_FormatScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) الخاصة بالقالب. إن فحص هذه التجمعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للقالب ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والظلال المخزنة في القالب:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لديها نفس القالب الفعّال. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل القالب الفعّال الموضح لاحقًا في هذه المقالة عندما تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان القالب**

يمكن أن تشير التعبئات، الخطوط، والنصوص المتوافقة مع القالب إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/) الخاص بالقالب، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون القالب مقابل القيمة الجديدة. لا تتغير الكائنات التي تستخدم لون RGB مباشر بتحديث لون القالب.

المثال التالي من النهاية إلى النهاية يُنشئ شكلًا يستخدم `Accent4`، يغيّر لون القالب `Accent4` إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون التعبئة الفعّال:

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

نظرًا لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير القالب. إذا استبدلت لون المخطط بلون مباشر على الشكل، لن تؤثر التغييرات اللاحقة على `Accent4` على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

يستخرج PowerPoint متغيرات أفتح وأغمق من لون القالب عن طريق تطبيق تحولات اللون. تُظهر Aspose.Slides هذه التحولات عبر [ColorTransformOperation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للقالب والألوان الأفتح والأغمق المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للقالب.

**2** - المتغيرات الأفتح والأغمق المنتجة من الألوان الرئيسية للقالب.

المثال التالي يُنشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتغيرات مُستمًدة على لون القالب. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المُحوَّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما تُظهر [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/) نفس فتحات القالب كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات القالب؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط القالب**

يحتوي مخطط خطوط القالب على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تُظهر طريقتا [FontScheme::get_Major()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_major/) و[FontScheme::get_Minor()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_minor/) تلك المجموعات.

يمكن استخدام معرفات خطوط القالب المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - الخط الأساسي للغة اللاتينية (Minor Latin Font)
* `+mj-lt` - خط العناوين للغة اللاتينية (Major Latin Font)
* `+mn-ea` - الخط الأساسي للغة الآسيوية الشرقية (Minor East Asian Font)
* `+mj-ea` - خط العناوين للغة الآسيوية الشرقية (Major East Asian Font)

المثال التالي يُنشئ عنوانًا يستخدم الخط اللاتيني الرئيسي وخطًا أساسيًا يستخدم الخط اللاتيني الفرعي. ثم يغيّر خطوط القالب ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف القالب لن يتحول تلقائيًا عندما يتغيّر مخطط خطوط القالب.

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق قالب**

هناك سيرا عمل شائعان، ويحلّان مشكلتين مختلفتين.

### **الحفاظ على القالب الأصلي عند نقل الشرائح**

إذا كنت ترغب في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/)، ثم استنسخ الشريحة باستخدام [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) والماستر المستنسخ. هذا يحمل الماستر وتخطيطاته والقالب المرتبط به معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنسخ المحتوى إلى ماستر غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والظلال المدفوعة بالقالب.

### **تطبيق قيم القالب على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على الماستر والتخطيط الحاليين، ابدأ تجاوزًا على مستوى الشريحة من القالب المصدر. تنسخ طرق [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) المكونات الثلاثة الرئيسية للقالب إلى التجاوز.

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

هذا يغيّر القالب المستخدم لتلك الشريحة دون تغيير القالب الموروث من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme::Clear()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز القالب على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لها تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [IOverrideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالتخطيط:

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

استخدم قالب الماستر أو مستوى العرض عندما يجب أن تتشارك العديد من التخطيطات والشرائح نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى نمط مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشرائح تغيّر القالب العالمي لاحقًا أصعب توقعًا.

## **تحديث أنماط خلفية القالب**

تُخزن تعبئات الخلفية الخاصة بالقالب في [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). يمكن لـ PowerPoint عرض المزيد من خيارات الخلفية في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذا التجمع لأن الواجهة يمكنها دمج تعبئات القالب مع ألوان القالب ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لقالب عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص التجمع المخزن و[Background::get_StyleIndex()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/get_styleindex/). يستخدم `StyleIndex` القيمة `0` لعدم وجود تعبئة قالب؛ القيم الموجبة هي مراجع لأنماط خلفية القالب. هذا يختلف عن فهرسة مجموعة C++ مباشرة بـ `idx_get(0)` حيث `0` يعني العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية قالب إلى أول ماستر، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على مدخل القالب الذي يُشار إليه من قبل الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تعتقد أن `StyleIndex` هو فهرس مجموعة صفر‑مبدئي. تجنّب أيضًا الترميز الصلب لرقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط القالب خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تحديث ظلال القالب**

يحتوي مخطط تنسيق القالب على مجموعات منفصلة من [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_linestyles/)، و[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). غالبًا ما تحتوي القوالب المكتبية على ثلاثة مدخلات نمط أساسية تُطابق بصريًا التنسيقات الخفيفة، المتوسطة، والشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![ظلال القالب الخفيفة، المتوسطة، والشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C++، يكون فهرس المجموعة صفر‑مبدئي: `idx_get(0)` هو أول نمط مخزن و`idx_get(2)` هو الثالث. فهارس إشارة النمط في الشكل هي مفهوم منفصل يُعرَف عبر [IShapeStyle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapestyle/). تعديل نمط القالب يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يُفعِّل ظلًا خارجيًا في النمط الثالث للظلال، ويحفظ النتيجة:

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

بالنسبة للأشكال التي تشير إلى هذه الفتحات، يصبح أول نمط خط للقالب أحمر، وثالث نمط تعبئة يصبح أخضر غامق صلب، ويكتسب النمط الثالث للظلال ظلًا خارجيًا بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على أي فترات نمط يشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز القالب.

![أنماط ظلال القالب بعد تعديل الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **قراءة قيم القالب الفعّالة**

تخبرك كائنات القالب الخام ما هو معرف على مستوى معين. تُظهر القيم الفعّالة ما يستخدمه الشريحة أو الشكل بالفعل بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). للخلفية، استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/)، وللتعبئة استخدم [FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ القالب الفعّال، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، والتحقق، والمقارنات. إذا فحصت فقط [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/)، قد تفوّت ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق قالب على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [IOverrideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالشريحة وابدأ تهيئة قالب التجاوز الخاص به. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة القوالب الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل قالب من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/). هذا يحافظ على الماستر، التخطيطات، والقالب معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) لقالب شريحة أو تخطيط والطُرق المقابلة للبيانات الفعّالة للكائنات التنسيقية مثل [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) و[FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.