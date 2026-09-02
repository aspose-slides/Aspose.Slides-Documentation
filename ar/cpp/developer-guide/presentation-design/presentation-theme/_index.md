---
title: إدارة سمات العروض التقديمية في C++
linktitle: سمة العرض
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
- سمة خارجية
- THMX
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides للـ C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint مع العلامة التجارية المتسقة."
---
## **المقدمة**

تحدد سمة العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملء والخطوط والتأثيرات. تُشير الكائنات الواعية للسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر السمة على مستوى العرض عبر [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/). يمكن للعرض أيضًا أن يحتوي على تعديلات سمة في مستويات أدنى. يمكن للماستر تجاوز سمة العرض عبر [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)، بينما يمكن للتخطيط أو الشريحة الفردية استخدام [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). عمليًا، تُحل السمة الفعّالة لشريحة ما عبر سلسلة الوراثة التالية: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تظهر الأقسام أدناه أكثر سير عمل شائع للسمة: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/) طريقة [get_ColorScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)، و[get_FormatScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). يكون فحص هذه المجموعات قبل تعديلها مفيدًا بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

الشفرة التالية تقرأ خصائص السمة الرئيسية وتُبلغ عدد أنماط الخلفية والملء والخط والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم ماسترات متعددة، لا تفترض أن كل شريحة لديها نفس السمة الفعّالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذا المقال عندما قد تكون هناك تجاوزات في التخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للملء والخط والنص الواعي للسمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/). عندما تُغيّر الإدخال المقابل في [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/)، يتم حل جميع الكائنات التي ما زالت تُشير إلى ذلك اللون السمة وفقًا للقيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تُغيّر بتحديث لون السمة.

الشيفرة التالية تُنشئ شكلًا يستخدم `Accent4`، وتغيّر لون السمة `Accent4` إلى الأحمر، وتحفظ العرض، وتعيد فتحه، وتطبع لون الملء الفعّال:

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

نظرًا لأن المستطيل ما يزال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون التعداد بلون مباشر على الشكل، لن تؤثر التغييرات المستقبلية على `Accent4` على ذلك الملء.

### **استخدام ألوان من اللوحة الإضافية**

يستخلص PowerPoint تدرجات أفتح وأغمق من لون السمة عن طريق تطبيق تحولات لونية. تُظهر Aspose.Slides هذه التحولات عبر [ColorTransformOperation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/colortransformoperation/).

![ألوان السمة الرئيسية والألوان الأفتح والأغمق المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - ألوان السمة الرئيسية.

**2** - تدرجات أفتح وأغمق مُنتجة من ألوان السمة الرئيسية.

الشيفرة التالية تُنشئ ستة مستطيلات تستند إلى `Accent4`، وتطبق تحولات الإضاءة على خمسة منها، وتُحفظ النتيجة:

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

تظل هذه التدرجات مبنية على لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوَّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم SchemeColor بفتحات IColorScheme**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/) نفس فتوحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الترابط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتوحات السمة؛ ليست قيمًا يتم تحويلها ديناميكيًا من صيغة إلى أخرى.

## **تغيير خطوط السمة**

تحتوي مجموعة خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تُظهر الطريقتان [FontScheme::get_Major()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_major/) و[FontScheme::get_Minor()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_minor/) تلك المجموعات.

يمكن استخدام معرفات خطوط سمة متوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي لاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان لاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)

الشيفرة التالية تُنشئ عنوانًا يستخدم خط سمة لاتيني رئيسي وسطرًا نصيًا يستخدم خط سمة لاتيني فرعي. ثم تُغيّر خطوط السمة وتحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتغيّر تلقائيًا عندما تتغيّر مجموعة خطوط السمة.

يمكن لمجموعات الخطوط الرئيسية والفرعية أيضًا أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثانا. لفحص، إضافة، استبدال أو حذف هذه التعيينات، راجع [خطوط السمة وفقًا للغة النص](/slides/ar/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

تحل سير العمل أدناه مشاكل مختلفة متعلقة بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة لماستر**

استخدم [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation::get_Masters](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_masters/) التي تُطبق [IMasterSlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تؤدي الطريقة العمليات التالية:

1. تنشئ شريحة ماستر جديدة بناءً على الماستر المحدد.
1. تطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الماستر المحدد.
1. تُعيد كائن [IMasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/) المُنشأ حديثًا.

الشيفرة التالية تُطبق سمة خارجية على الشرائح التي تعتمد على الماستر الأول وتحفظ العرض:

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

قد يتسبب سمة غير صالحة أو تالفة أو غير مدعومة في ظهور [PptxException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxexception/) أو أحد الفئات الفرعية المتعلقة بالتنسيق. تحقق من صحة المسارات التي يزودها المستخدمون، وتعامل مع فشل وصول نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المحدد فقط. الشرائح المرتبطة بماسترات أخرى تحتفظ بماستراتها وسيماتها الحالية. تُحل الألوان والخطوط والملء والخطوط الخلفية والتأثيرات الواعية للسمة وفقًا للسمة الخارجية. قد تبقى الألوان والخطوط والملء وغيرها من التنسيقات الصريحة دون تغيير. قد تتفوق تجاوزات المستوى التخطيطي أو المستوى الشريحة على القيم الموروثة من الماستر الجديد.

قد تشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. للحصول على عرض وتصدير متسقين، ثبّت الخطوط المطلوبة، قدّمها عبر [مصادر الخطوط المخصصة](/slides/ar/cpp/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/cpp/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عندما لا يُعرف الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/get_layoutslide/) و[ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_masterslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

الشيفرة التالية تستخدم شرائح من قسمين لتحديد ماستراتها وتُطبق سمة خارجية مختلفة على كل مجموعة:

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

الاستدعاء الأول يؤثر فقط على الشرائح التي تعتمد على `firstGroupMaster`، والاستدعاء الثاني يؤثر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر مع الحفاظ على التصميم الأصلي، انسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/)، ثم انسخ الشريحة باستخدام [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) والماستر المنسوخ. هذا ينقل الماستر وتخطيطاتّه والسمة المرتبطة معه معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد نسخ المحتوى إلى ماستر وجهة غير مرتبط قد يُغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على الماستر والتخطيط الحاليين، ابدأ بتجاوز على مستوى الشريحة من السمة المصدر. تُنسخ طرق [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يُغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme::Clear()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

يُطبق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تُنشئ شريحة معينة تجاوزها الخاص. يمكن استخدام نفس طرق التهيئة عبر [IOverrideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالتخطيط:

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

استخدم سمة ماستر أو سمة على مستوى العرض عندما تحتاج العديد من التخطيطات والشرائح إلى مشاركة نفس التصميم الأساسي، واستخدم تجاوز تخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز شريحة فقط للاستثناءات الحقيقية. تُصعّب التجاوزات المفرطة على مستوى الشريحة من توقع تأثير تغييرات السمة العامة لاحقًا.

## **تحديث أنماط خلفية السمة**

تُخزن ملء الخلفيات في السمة ضمن [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مما هو مخزن فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج ملء السمة مع ألوان سمة وإشارات نمطية أخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background::get_StyleIndex()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/get_styleindex/). يستخدم `StyleIndex` القيمة `0` لعدم وجود ملء مُمَثّل بسمة؛ القيم الموجبة تمثل مراجع أنماط خلفية السمة. هذا يختلف عن فهرسة مجموعة C++ مباشرةً بـ `idx_get(0)`, حيث يمثل `0` العنصر المخزن الأول. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

الشفرة التالية تُبلغ عدد ملء الخلفيات المتاحة، وتُعيّن مرجع خلفية مُمَثّل بسمة للماستر الأول، وتحفظ العرض:

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

النتيجة المرئية تعتمد على إدخال السمة المشار إليه من قبل الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا كانت شريحة ما تستخدم خلفية خاصة بها، قد لا يُغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تُعامل `StyleIndex` كفهرس مجموعة يبدأ من الصفر. وتجنب كتابة رقم نمط ثابت من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [خلفية العرض](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

تحتوي مجموعة تنسيق السمة على مجموعات منفصلة لـ [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_linestyles/)، و[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). غالبًا ما تحتوي السمات المكتبية على ثلاثة مداخل رئيسية تتوافق بصريًا مع تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات سمة خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C++، يكون فهرس المجموعة يبدأ من الصفر: `idx_get(0)` هو النمط المخزن الأول و`idx_get(2)` هو النمط الثالث. فهارس مراجع النمط الخاصة بالشكل مفهوم منفصل، تُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تُشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

الشيفرة التالية تتحقق من وجود المداخل المطلوبة، وتغيّر نمط الخط الأول، وتغيّر نمط الملء الثالث، وتُفعّل ظلًا خارجيًا في نمط التأثير الثالث، وتحفظ النتيجة:

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

بالنسبة للأشكال التي تُشير إلى هذه الفتوحات، يصبح نمط الخط السمة الأول أحمر، ونمط الملء السمة الثالث أخضر غابي صلب، ونمط التأثير الثالث يكتسب ظلًا خارجيًا بمسافة 10 نقاط. النتيجة البصرية الدقيقة لا تزال تعتمد على الفتوحات التي تُشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير الخط والملء وإعدادات الظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

تُظهر كائنات السمة الخام ما تم تعريفه على مستوى معين. القيم الفعّالة تُظهر ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). للخلفية، استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/)، وللملء استخدم [FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/).

الشيفرة التالية تقرأ السمة الفعّالة، الخلفية، وملء الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، والتحقق، والمقارنات. إذا فحصت فقط [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/)، قد تفوتك تجاوزات ماستر أو تخطيط أو شريحة أو شكل تغير المظهر النهائي.

## **الأسئلة الشائعة**

**هل تطبيق سمة خارجية يؤثر على كل شريحة في العرض؟**

لا. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) يعيد تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسيماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [IOverrideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. التغيير يبقى محليًا لتلك الشريحة؛ الشرائح الأخرى تظل تُورّث سماتها الحالية.

**ما هي الطريقة الآمنة لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهرها الأصلي، انسخ الماستر المصدر إلى الوجهة ونسخ الشريحة باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/). هذا يحافظ على الماستر والتخطيطات والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) لسمة شريحة أو تخطيط، واستخدم طرق البيانات الفعّالة المقابلة لكائنات التنسيق مثل [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) و[FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/). تُعيد هذه الـ API القيم المحلولة بعد تطبيق الوراثة والتجاوزات.