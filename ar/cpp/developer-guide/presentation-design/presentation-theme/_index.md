---
title: إدارة سمات العروض في C++
linktitle: سمة العرض
type: docs
weight: 10
url: /ar/cpp/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير السمة
- إدارة السمة
- سمة خارجية
- THMX
- لون السمة
- لوحة إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض
- C++
- Aspose.Slides
description: "التحكم في سمات العروض في Aspose.Slides للغة C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint مع هوية علامة تجارية موحدة."
---
## **المقدمة**

تُعرّف سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تُشير الكائنات التي تدعم السمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، وبالتالي يمكن لتغيير السمة أن يُحدّث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، تتوفر سمة المستوى العرض من خلال [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/). يمكن للعرض أيضاً أن يحتوي على تجاوزات للسمة في مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)، بينما يمكن للتخطيط أو الشريحة الفردية أن يستخدم [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). عمليًا، يتم حل السمة الفعلية لشريحة ما عبر سلسلة الإرث هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل سمة شيوعًا: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعلية بعد حل الإرث والتجاوزات.

## **فحص سمة**

يكشف كائن [MasterTheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/) عن طرق [get_ColorScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)، [get_FontScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)، و[get_FormatScheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). يعتبر فحص هذه المجموعات قبل تعديلها مفيدًا بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات النمط قد تختلف.

المثال التالي يقرأ الخصائص الرئيسية للسمة ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزّنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعلية. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعلية الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للملء، الخط، والنص المتوافق مع السمة الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/). عند تغيير الإدخال المقابل في سمة [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/)، تُحل جميع الكائنات التي لا تزال تُشير إلى ذلك اللون السيمائي وفقًا للقيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتأثر بتحديث لون السمة.

المثال التالي كاملًا ينشئ شكلًا يستخدم `Accent4`، يغيّر لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يعيد فتحه، ويطبع لون الملء الفعلي:

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

نظرًا لأن المستطيل يظل مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت اللون السيمائي بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على ذلك الملء.

### **استخدام الألوان من اللوحة الإضافية**

يستخرج PowerPoint متباينات أفتح وأغمق من لون السمة عبر تطبيق تحويلات اللون. تُظهر Aspose.Slides هذه التحويلات عبر [ColorTransformOperation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة والألوان الفاتحة والداكنة المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.

**2** - المتباينات الفاتحة والداكنة المستخرجة من الألوان الرئيسية للسمة.

المثال التالي ينشئ ستة مستطيلات تستند إلى `Accent4`، يطبق تحويلات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتباينات مستندة إلى لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `IColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يكشف [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/) عن نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

تحتوي مخطط خط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية لنص الجسم. تكشف طرق [FontScheme::get_Major()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_major/) و[FontScheme::get_Minor()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_minor/) عن تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي (Minor Latin Font)
* `+mj-lt` - خط العنوان الأساسي (Major Latin Font)
* `+mn-ea` - خط النص الأساسي للغة شرق آسيوية (Minor East Asian Font)
* `+mj-ea` - خط العنوان الأساسي للغة شرق آسيوية (Major East Asian Font)

المثال التالي ينشئ عنوانًا واحدًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط السمة اللاتيني الفرعي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع نص الجسم الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتحول تلقائيًا عندما يتغيّر مخطط خطوط السمة.

يمكن أن تحتوي مجموعة الخطوط الرئيسية والفرعية أيضًا على تعيينات خطوط لأنظمة كتابة فردية مثل السيريلية، العربية، اليابانية، الجورجية، والثانا. لاستعراض، إضافة، استبدال أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

تحل سير عمل الأسفل مشاكل سمة مختلفة.

### **تطبيق سمة خارجية على الشرائح التابعة لماستر**

استخدم [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation::get_Masters](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_masters/) التي تُنفّذ [IMasterSlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تقوم الطريقة بالعمليات التالية:

1. تنشئ شريحة ماستر جديدة استنادًا إلى الماستر المحدد.
1. تطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الماستر المحدد.
1. تُعيد كائن [IMasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على الماستر الأول ويحفظ العرض:

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

قد يتسبب سمة غير صالحة أو تالفة أو غير مدعومة في حدوث [PptxException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxexception/) أو أحد الفئات الفرعية المتعلقة بالتنسيق. تحقق من صحة المسارات التي يُدخلها المستخدمون، عالج فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين الشرائح التي تعتمد على الماستر المحدد فقط. تحتفظ الشرائح المرتبطة بماسترات أخرى بماستراتها وسيماتها الحالية. تُحل الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات المتوافقة مع السمة وفقًا للسمة الخارجية. قد تظل الألوان، الخطوط، التعبئات وغيرها من التنسيقات الصريحة كما هي. يمكن لتجاوزات مستوى التخطيط أو الشريحة أيضًا أن تتفوق على القيم الموروثة من الماستر الجديد.

قد تُشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. لضمان عرض وتصدير ثابتين، قم بتثبيت الخطوط المطلوبة، أو وفّرها عبر [custom font sources](/slides/ar/cpp/custom-font/)، أو اضبط [font substitution](/slides/ar/cpp/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تُقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عند عدم معرفة الماستر المناسب مسبقًا، احصل عليه من شريحة ممثلة عبر [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/get_layoutslide/) و[ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_masterslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماسترها ويطبق سمة خارجية مختلفة على كل مجموعة:

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

الاستدعاء الأول يؤثر فقط على الشرائح التي تعتمد على `firstGroupMaster`، والثاني يؤثر فقط على الشرائح التي تعتمد على `secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، انسخ الماستر المصدر إلى العرض الهدف باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/)، ثم انسخ الشريحة باستخدام [ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) والماستر المنسوخ. هذا يحمل الماستر وتخطيطاتَه والسمة المرتبطة به معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد نسخ المحتوى إلى ماستر هدف غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان من الضروري أن تظل الشريحة المستهدفة على ماسترها وتخطيطها الحاليين، ابدأ تجاوزًا على مستوى الشريحة من سمة المصدر. تنسخ الطرق [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)، و[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) المكونات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme::Clear()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/overridetheme/clear/).

### **تطبيق تجاوز سمة على تخطيط**

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

استخدم سمة على مستوى الماستر أو العرض عندما تحتاج العديد من التخطيطات والشرائح إلى مشاركة نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيطات واحدة إلى نمط مختلف، واستخدم تجاوز الشريحة فقط في الحالات الاستثنائية الحقيقية. تؤدي التجاوزات المتعددة على مستوى الشريحة إلى صعوبة التنبؤ بتغييرات السمة العالمية لاحقًا.

## **تحديث أنماط خلفية السمة**

تُخزن تعبئات خلفية السمة في [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة، لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background::get_StyleIndex()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/get_styleindex/). يستخدم `StyleIndex` القيمة `0` لعدم وجود تعبئة سمة؛ القيم الموجبة هي مراجع لأنماط خلفية السمة. هذا مختلف عن الفهرسة المباشرة لمجموعة C++ عبر `idx_get(0)`, حيث تعني `0` أول عنصر مخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يُعيّن مرجع خلفية سمة إلى أول ماستر، ويحفظ العرض:

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

النتيجة المرئية تعتمد على إدخال السمة الذي يُشير إليه الماستر وأي تجاوزات خلفية في التخطيط أو على مستوى الشريحة. إذا كانت الشريحة تستخدم خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الإرث.

{{% alert color="warning" title="Warning" %}}
لا تُعامِل `StyleIndex` كفهرس مجموعة يبدأ من الصفر. كما يُنصح بتجنب ترميز رقم نمط من ملفٍ واحد وافتراض أنه سيظهر بنفس الشكل في ملفٍ آخر؛ تعريفات نمط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية وإرث الخلفية، راجع [Presentation Background](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

تحتوي مخطط تنسيق السمة على مجموعات منفصلة لـ [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)، [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_linestyles/)، و[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). غالبًا ما تحتوي سمات Office على ثلاث إدخالات أساسية تتوافق بصريًا مع تنسيقات خفيفة، متوسطة، وشديدة، لكن يُفضَّل فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات سمة خفيفة، متوسطة، وشديدة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في C++، يكون فهرس المجموعة قائمًا على صفر: `idx_get(0)` هو أول نمط مخزن و`idx_get(2)` هو الثالث. فهارس مراجع نمط الشكل مفهوم منفصل، تُعرض عبر [IShapeStyle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تُشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود الإدخالات المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط التعبئة الثالث، يُفعِّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح نمط الخط السمة الأول أحمر، ويصبح نمط التعبئة السمة الثالث أخضر غابي صلب، ويضيف نمط التأثير الثالث ظلًا خارجيًا بمسافة 10 نقاط. ما يزال النتيجة البصرية الدقيقة تعتمد على الفتحات التي تُشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير سمة بعد تعديل الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **تحديد ما إذا كان تعبئة صلبة فعّالة تستخدم لون سمة**

يمكن تخزين التعبئة مباشرةً على كائن أو وراثتها من فقرة، تخطيط، ماستر، نمط سمة، أو مستوى تنسيق آخر. استدعِ [IFillFormat::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformat/geteffective/) لحل تلك السلسلة إلى كائن [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/) غير قابل للتغيير. أولًا تحقق من [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). فقط عندما تكون `FillType::Solid` ينبغي قراءة خصائص التعبئة الصلبة.

للتعبئة الصلبة، يُعيد [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) قيمة RGB النهائية بعد الإرث، بحث السمة، وتطبيق تحويلات اللون. يُعيد [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) الفتحة المنطقية في تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/)، مثل `Text1` أو `Accent6`. قيمة `SchemeColor::NotDefined` تعني أن التعبئة الصلبة الفعّالة ليست مستندة إلى لون سمة. في سير عمل حيث تكون التعبئات إما ألوان سمة أو ألوان RGB مباشرة، تُحدِّد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icolorformat/get_schemecolor/) المحلية وحدها لتصنيف تعبئة. على سبيل المثال، قد لا يحمل جزء نصٍ قيمة سيمة محلية، لذا تكون قيمته المحلية `NotDefined`، بينما تُورَث تعبئته الفعّالة لون سمة وتُحل إلى `Text1` أو `Accent6`. بالمقابل، تُظهر `get_SolidFillSchemeColor` الفتحة السيمائية التي بنت اللون الفعلي، لكنها لا تُظهر ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى تنسيق آخر.

المثال التالي يحمل عرضًا، يدقق كل تعبئات الأشكال وتعبئات أجزاء النص، يطبع كل قيمة RGB نهائية والفتحة السيمائية المرتبطة، ويُعلِّم التعبئات الصلبة التي لن تتبع تغيّر ألوان السمة:

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

يوفر الفرع `NotDefined` قائمة تدقيق للتعبئات الصلبة التي لن تستجيب لتغيّر فتحات ألوان السمة. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا يزال عرض قيمة RGB الحالية، بينما يوضح قيمة السيمة ما إذا كان هذا المظهر مرتبطًا بالسمة.

كائنات التنسيق الفعّال هي لقطات. بعد تغيير سمة العرض، أو تجاوز سمة، أو أي تنسيق وراثي، استدعِ `GetEffective` مرة أخرى واطلب كائن `IFillFormatEffectiveData` جديد قبل مقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعّالة**

تخبرك كائنات السمة الخام بما هو مُعرف على مستوى معين. تُظهر القيم الفعّالة ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الإرث والتجاوزات المحلية. للحصول على سمة فعّالة لشريحة، استدعِ [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). للخلفية، استخدم [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/)، وللتعبئة استعمل [FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، التحقق، والمقارنات. إذا نظرت فقط إلى [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/)، قد تغفل عن تجاوز ماستر، تخطيط، شريحة، أو شكل يغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. تُعيد [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) تعيين الشرائح فقط التي تعتمد على الماستر المحدد. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسيماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [IOverrideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ioverridethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة مع الحفاظ على مظهر المصدر، انسخ الماستر المصدر إلى الوجهة ونسخ الشريحة مع ذلك الماستر باستخدام [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/addclone/) و[ISlideCollection::AddClone()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/). هذا يحافظ على الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الإرث والتجاوزات؟**

استخدم [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) لسمة شريحة أو تخطيط، والطُّرُق المقابلة للبيانات الفعّالة لكائنات التنسيق مثل [Background::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/background/geteffective/) و[FillFormat::GetEffective()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/geteffective/). تُعيد هذه الواجهات القيم المُحلَّة بعد تطبيق الإرث والتجاوزات.