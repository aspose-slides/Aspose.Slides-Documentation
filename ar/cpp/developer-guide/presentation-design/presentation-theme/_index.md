---
title: "إدارة سمات العرض في C++"
linktitle: "سمة العرض"
type: docs
weight: 10
url: /ar/cpp/presentation-theme/
keywords:
- "سمة PowerPoint"
- "سمة العرض"
- "سمة الشريحة"
- "تعيين سمة"
- "تغيير سمة"
- "إدارة سمة"
- "سمة خارجية"
- THMX
- "لون سمة"
- "لوحة إضافية"
- "خط سمة"
- "نمط سمة"
- "تأثير سمة"
- PowerPoint
- OpenDocument
- عرض
- C++
- Aspose.Slides
description: "إدارة سمات العرض الرئيسية في Aspose.Slides للغة C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتناسقة."
---
## **مقدمة**

يعرّف سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تشير الكائنات التي تدعم السمة إلى هذه التعاريف المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة أن يحدّث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض عبر [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). يمكن للعرض أيضاً أن يحتوي على تعديلات سمة على مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)، بينما يمكن للتخطيط أو الشريحة الفردية استخدام [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). عملياً، يتم حل السمة الفعلية لشريحة عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل السمة شيوعاً: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثير، وقراءة القيم الفعلية بعد حل الوراثة والتجاوزات.

## **فحص سمة**

كائن [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) يعرض طرق [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)، و[get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) الخاصة بالسمة. فحص هذه المجموعات قبل تعديلها مفيد خاصة عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للسمة ويبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعلية. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعلية الموضح لاحقاً في هذه المقالة عندما تكون هناك تعديلات على التخطيط أو الشريحة.

## **تغيير ألوان السمة**

التعبئات، الخطوط، والنصوص التي تدعم السمة يمكنها الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) الخاصة بالسمة، جميع الكائنات التي لا تزال تشير إلى ذلك اللون يتم حلها مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

المثال الشامل التالي ينشئ شكلًا يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون التعبئة الفعلي:

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

لأن المستطيل ما يزال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

PowerPoint يشتق تدرجات أفتح وأغمق من لون السمة عبر تطبيق تحويلات اللون. Aspose.Slides expose هذه التحويلات عبر [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الفاتحة والداكنة المتولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.

**2** - التدرجات الفاتحة والداكنة المشتقة من الألوان الرئيسية للسمة.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه التدرجات مستندة إلى لون السمة. إذا تغير `Accent4` لاحقاً، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **تخطيط قيم `SchemeColor` إلى فتحات `IColorScheme`**

تعداد [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) يستخدم `Text1`، `Background1`، `Text2`، و`Background2`، بينما [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) يعرض نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. التخطيط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكياً من شكل إلى آخر.

## **تغيير خطوط السمة**

يتضمن مخطط خطوط السمة مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. طُرق [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) و[FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) تُظهر هذه المجموعات.

يمكن استخدام معرفات خطوط سمة متوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي لاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان لاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)
* `+mn-cs` - خط النص الأساسي نص معقد (Minor Complex Script Font)
* `+mj-cs` - خط العنوان نص معقد (Major Complex Script Font)

المثال التالي ينشئ عنوانًا يستخدم خط السمة اللاتيني الرئيسي وسطر نص أساسي يستخدم خط السمة اللاتيني الفرعي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتغيّر تلقائياً عندما يتغيّر مخطط خطوط السمة.

يمكن أيضًا لمجموعات الخطوط الرئيسية والفرعية أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثعنا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، راجع [خطوط السمة الخاصة بالسكريبت](/slides/ar/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

### **حل مراجع خطوط السمة**

عند فحص النص، قد يحتوي [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) على مرجع سمة مثل `+mn-lt` بدلاً من اسم عائلة الخط. استدعِ [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) مع الـ [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) المناسب لحل هذا المرجع. البادئان `+mj` و`+mn` يحددان مجموعات الخطوط الرئيسية والفرعية؛ واللاحقان `-lt`، `-ea`، و`-cs` يحددان خطوط اللاتينية، الشرقية الآسيوية، والنص المعقد على التوالي.

احصل على السمة الفعلية عبر [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) على الكائن الذي تنطبق سمعته على النص المفحوص. للنص العادي على شريحة، استخدم `slide->CreateThemeEffective()` بحيث يشتمل السياق على سمة الشريحة الموروثة وتجاوزاتها المحلية. عند فحص تخطيط أو ماستر نفسها، استخدم سمةه الفعلية. لا تفترض أن سمة أول ماستر تنطبق على كل شريحة.

المثال التالي ينشئ جزء نص يُشير صراحةً إلى الخط اللاتيني الفرعي. يهيئ مخطط خطوط الشريحة عبر [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) ويضبط عائلات اللاتينيين الرئيسيين والفرعيين إلى `Arial` و`Calibri`، مما يجعل النتيجة قابلة لإعادة الإنتاج دون ملف إدخال.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

الإخراج هو `+mn-lt -> Calibri` ثم `Verdana -> Verdana`. يظل المرجع المخزن دون تغيير، بينما يُعيد اسم العائلة الصريح كما هو. إذا كان الجزء يستخدم `+mj-lt`، لكان سيُحَل إلى `Arial` في هذه السمة.

حل مرجع السمة يحدد عائلة الخط المحددة من قبل السمة. لا يتحقق من توفر الخط أو يحدد ملف الخط الذي يُستَخدم نهائياً بعد الاستبدال أو fallback الأحرف أثناء العرض. راجع [Font Selection Sequence](/slides/ar/cpp/font-selection-sequence/) و[Font Substitution](/slides/ar/cpp/font-substitution/) لتلك الخطوات المنفصلة.

## **نسخ أو تطبيق سمة**

تُحلّ سير العمل أدناه مشكلات مختلفة متعلقة بالسمة.

### **تطبيق سمة خارجية على شرائح تعتمد على ماستر**

استخدم [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) التي تُطبق [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. تنشئ شريحة ماستر جديدة بناءً على الماستر المحدد.
1. تطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد لكل الشرائح التي كانت تعتمد مسبقاً على الماستر المختار.
1. تُعيد الـ [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) الجديد المنشأ.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على أول ماستر ويحفظ العرض:

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

قد يتسبب سمة غير صالحة أو تالفة أو غير مدعومة في حدوث [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) أو إحدى الفئات الفرعية المتعلقة بالتنسيق. تحقق من صحة المسارات التي يزوّدها المستخدمون، وتعامل مع فشل الوصول لنظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين فقط الشرائح التي كانت تعتمد على الماستر المُختار. الشرائح المرتبطة بماسترّات أخرى تحتفظ بماستراتها وسِماتها الحالية. تُحلّ الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات التي تدعم السمة مقابل السمة الخارجية. قد تظل التنسيقات المُعطاة مباشرةً (الألوان، الخطوط، التعبئات، وغيرها) دون تغيير. يمكن لتجاوزات مستوى التخطيط أو الشريحة أن تتفوّق أيضاً على القيم الموروثة من الماستر الجديد.

قد تُشير السمة إلى خطوط غير متوفرة في بيئة التنفيذ. لضمان عرض وتصدير متسقين، ثبّت الخطوط المطلوبة، وقدّمها عبر [مصادر الخطوط المخصّصة](/slides/ar/cpp/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/cpp/font-substitution/).

هذا سير عمل على مستوى الماستر مباشرةً: تقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدوياً.

### **تطبيق سمات خارجية مختلفة في عرض متعدد ماستر**

عندما لا يُعرف الماستر المناسب سلفاً، احصل عليه من شريحة تمثيلية عبر [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) و[ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء يخلق ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتهم ويطبق سمة خارجية مختلفة على كل مجموعة:

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

الاستدعاء الأول يؤثر فقط على الشرائح التي كانت تعتمد على `firstGroupMaster`، والاستدعاء الثاني يؤثر فقط على الشرائح التي كانت تعتمد على `secondGroupMaster`. الشرائح التي تنتمي إلى أي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا كنت تريد نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، انسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/)، ثم انسخ الشريحة باستخدام [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) والماستر المنسوخ. هذا ينقل الماستر، تخطيطاته، والسمة المرتبطة معاً.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد نسخ المحتوى إلى ماستر وجهة غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على ماسترها وتخطيطها الحالي، ابدأ تجاوزًا على مستوى الشريحة من سمة المصدر. طرق [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) تنسخ المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

تجاوز على مستوى التخطيط يُطبق على الشرائح التي تستخدم ذلك التخطيط، ما لم يكن لشريحة معينة تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالتخطيط:

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

استخدم سمة على مستوى الماستر أو العرض عندما تحتاج العديد من التخطيطات والشرائح إلى مشاركة نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للتميّز الحقيقي. التجاوزات المفرطة على مستوى الشريحة تجعل تغييرات السمة العامة لاحقاً أصعب في التنبؤ.

## **تحديث أنماط خلفية السمة**

تُخزن تعبئات خلفية السمة في [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة الفعلية المخزنة في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). يستخدم `StyleIndex` القيمة `0` عندما لا يكون هناك تعبئة سمة؛ القيم الموجبة هي مراجع أنماط خلفية سمة. هذا يختلف عن فهرسة مجموعة C++ مباشرةً بـ `idx_get(0)`، حيث يعني `0` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يبلغ عن عدد تعبئات الخلفية المتاحة، يعيّن مرجع خلفية سمة إلى أول ماستر، ويحفظ العرض:

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

النتيجة المرئية تعتمد على إدخال السمة الذي يشير إليه الماستر وعلى أي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تتعامل مع `StyleIndex` كفهرس مجموعة يبدأ من الصفر. كما يجب تجنّب ترميز رقم نمط من ملف واحد والافتراض بأنه سيكون له نفس المظهر في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على مجموعات منفصلة من [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/)، و[FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). غالباً ما تحتوي سمات Office النموذجية على ثلاثة إدخالات أساسية تتطابق بصرياً مع تنسيق خفيف، متوسط، وشديد، لكن يجب على الكود فحص كل مجموعة بدلاً من الافتراض بعدد ثابت.

![تأثيرات سمة خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C++، يكون فهرس المجموعة يبدأ من الصفر: `idx_get(0)` هو أول نمط مخزن و`idx_get(2)` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، يُظهرها [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تشير إلى ذلك النمط؛ الأشكال ذات التنسيق المباشر قد تبقى دون تغيير.

المثال التالي يتحقق من وجود إدخالات النمط المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في النمط الثالث للتأثير، ويحفظ النتيجة:

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

للأشكال التي تشير إلى هذه الفتحات، يصبح أول خط سمة أحمر، وثالث تعبئة سمة صلبًا بلون أخضر غابي، والثالث تأثير سمة يكتسب ظلًا خارجيًا بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على أي فتحات نمط كل شكل يشير إليها وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **اختيار أنماط تعبئة وخط سمة لشكل**

يمكن للشكل اختيار تعبئته وحدوده بشكل مستقل عبر [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) و[IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). لكل من الدالتين، الفهرس `1` يختار الإدخال الأول في مجموعة السمة المقابلة (`idx_get(0)`)، والفهرس `2` يختار الثاني.

المثال التالي يُعدّ نمطين تعبئة (ذهب وسماء زرقاء) ونمطين خط (أزرق داكن 6 pt وأحمر داكن 12 pt) في سمة العرض الافتراضية لعرض جديد. يحفظ الشريحة في ثلاث مراحل لتتمكن من مقارنة النتائج في PowerPoint.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| الأنماط الأولية | تغيير الخط الخارجي الأيمن | تعديل أول تعبئة سمة |
|:---:|:---:|:---:|
| ![مستطيلات ذهبية وزرقاء سماوية مع حدود أزرق داكن رفيعة متطابقة](theme-style-initial.png) | ![المستطيل السماوي الآن له حد أحمر داكن سميك](theme-style-line-changed.png) | ![المستطيل الأيسر الآن أخضر وكلا الحدين بدون تغيير](theme-style-fill-changed.png) |

اختيار نمط خط مختلف يغيّر فقط حدود المستطيل الأيمن. تعديل أول تعبئة سمة يحدّث كل شكل يستخدمها. هنا، يتحول المستطيل الأيسر فقط إلى اللون الأخضر.

على شكل موجود، يمكن للون تعبئة محلي، لون خط، أو عرض خط أن يتجاوز ذلك الجزء من نمط السمة. إذا لم يُظهر تغيير فهرس النمط أي تأثير مرئي، فتحقق من [التنسيق المباشر](/slides/ar/cpp/shape-formatting/) للشكل.

## **تحديد ما إذا كان تعبئة صلبة فعلية تستخدم لون سمة**

يمكن أن تُخزن التعبئة مباشرةً على كائن أو تُورّث من فقرة، تخطيط، ماستر، نمط سمة، أو مستوى تنسيق آخر. استدعِ [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) لحل تلك الهرمية إلى [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/) غير قابل للتغيير. أولاً تحقق من [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). فقط عندما يكون `FillType::Solid` يجب قراءة خصائص التعبئة الصلبة.

لتعبئة صلبة، تُعيد [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) القيمة النهائية للـ RGB بعد الوراثة، البحث في السمة، وتطبيق تحويلات اللون. تُعيد [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) الفتحة المنطقية من [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) المقابلة، مثل `Text1` أو `Accent6`. القيمة `SchemeColor::NotDefined` تعني أن التعبئة الصلبة الفعلية ليست مبنية على لون مخطط. في سير عمل تكون فيه التعبئات إما ألوان سمة أو ألوان RGB مباشرة، تُحدِّد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) المحلية وحدها لتصنيف تعبئة. على سبيل المثال، قد لا يحتوي جزء نص على لون مخطط معرف محلياً، لذا تكون قيمته المحلية `NotDefined`، بينما تُورّث التعبئة الفعلية لون سمة وتُحل إلى `Text1` أو `Accent6`. بالمقابل، تُظهر `get_SolidFillSchemeColor` أي فتحة سمة منطقية أنتجت اللون الفعلي، لكنها لا تخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر من الهرمية.

المثال التالي يحمل عرضًا، يراجع كل تعبئات الأشكال وتعبئات أجزاء النص، يطبع كل قيمة RGB نهائية والقيمة المخططة المرتبطة، ويُعلِّم التعبئات الصلبة التي لن تتتبّع تغييرات ألوان السمة:

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

الفرع `NotDefined` يُوفر قائمة تدقيق للتعبئات الصلبة التي لن تستجيب لتغييرات فتحة لون السمة. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا يزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما توضح قيمة المخطط ما إذا كان هذا المظهر مرتبطاً بالسمة.

كائنات التنسيق الفعلي هي لقطات. بعد تغيير سمة العرض، أو تجاوز سمة، أو أي تنسيق موروث، استدعِ `GetEffective` مرة أخرى واقرأ كائن `IFillFormatEffectiveData` جديد قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعلية**

الكائنات الخام للسمة تخبرك بما هو مُعرّف على مستوى معين. القيم الفعلية تخبرك بما يستخدمه الشريحة أو الشكل فعلياً بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). للخلفية، استخدم [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/)، وللتعبئة، استخدم [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ السمة الفعلية، الخلفية، وأول تعبئة شكل من شريحة:

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

استخدم البيانات الفعلية للتشخيص، التحقق، والمقارنات. إذا فحصت فقط [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/)، قد تفوت ماسترًا أو تخطيطًا أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة الشائعة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) يُعيد تعيين فقط الشرائح التي تعتمد على الماستر المختار. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسيماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ الشرائح الأخرى تستمر في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهر المصدر، انسخ الماستر المصدر إلى الوجهة وانسخ الشريحة باستخدام [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). هذا يبقي الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعلية بعد الوراثة والتجاوزات؟**

استخدم [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) لسمة شريحة أو تخطيط، واستخدم طرق البيانات الفعلية المقابلة لكائنات التنسيق مثل [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) و[FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). تُعيد هذه الواجهات القيم محلولة بعد تطبيق الوراثة والتجاوزات.