---
title: أتمتة توطين العروض التقديمية في C++
linktitle: توطين العروض التقديمية
type: docs
weight: 100
url: /ar/cpp/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- قمع تدقيق إملائي
- لغة التدقيق
- معرف اللغة
- نص متعدد اللغات
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعيين لغات التدقيق للنصوص في عروض PowerPoint وOpenDocument باستخدام C++ مع Aspose.Slides، بما في ذلك الإعدادات الافتراضية والفقرات المتعددة اللغات."
---
## **نظرة عامة**

يتيح لك Aspose.Slides for C++ تكوين بيانات التعريف الخاصة بالتدقيق للجزئات النصية الفردية. استخدم [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_languageid/) لتحديد لغة التدقيق، واستخدم [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_spellcheck/) للسماح أو قمع فحص الإملاء، واستخدم [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_proofdisabled/) للتحكم في حالة عدم التدقيق العامة. نظرًا لتطبيق هذه الإعدادات على مستوى الجزئية، يمكن للفقرة الواحدة أن تحتوي على لغات متعددة وقواعد تدقيق مختلفة.

تشرح هذه المقالة كيفية تعيين لغة لنص معين، وتحديد اللغة الافتراضية للنص الجديد باستخدام [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)، وإنشاء فقرات متعددة اللغات، واختيار بين `SpellCheck` و `ProofDisabled`، والحفاظ على الإعدادات المقصودة عند استخدام [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/joinportionswithsameformatting/). تخزن هذه الخصائص بيانات التعريف لتطبيقات العروض التقديمية؛ فهي لا تترجم النص، ولا تُجري فحص إملائي يعتمد على القواميس، ولا تُعيد الكلمات الخاطئة.

## **تعيين لغة التدقيق للنص**

أنشئ أو حمّل [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، وابدأ بالجزئية النصية المطلوبة عبر [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/get_portionformat/)، ثم عيّن معرف لغتها. المثال التالي ينشئ شكلًا، يحدد اللغة الإنجليزية البريطانية كلغة تدقيق، ويحفظ النتيجة باستخدام [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تحديد اللغة الافتراضية للنص الجديد**

استخدم [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) لتحديد لغة التدقيق التي يعيّنها Aspose.Slides للنص الذي يتم إنشاؤه حديثًا. يفيد هذا الإعداد عندما تستخدم معظم أو كل النصوص الجديدة في العرض اللغة نفسها. لا يغيّر هذا الإعداد بيانات التعريف الخاصة بالنص الذي لديه بالفعل لغة معرفة صراحةً.

المثال التالي ينشئ عرضًا تكون فيه النصوص الجديدة تتبع قواعد التدقيق الألمانية:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استخدام لغات متعددة في فقرة واحدة**

يحتوي [IParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraph/) على مجموعة من الجزئات النصية. أنشئ [Portion](https://reference.aspose.com/slides/ar/cpp/aspose.slides/portion/) منفصلة لكل لغة وقم بتعيين `LanguageId` لكل منها بشكل مستقل.

هذا المثال ينشئ فقرة واحدة تحتوي على جزئيات بالإنجليزية والفرنسية:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تمكين أو قمع فحص الإملاء للجزئات الفردية**

[IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/) يرث خصائص النص العامة المحددة بواسطة [IBasePortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/). وصل إلى تنسيق الجزئية عبر [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportion/get_portionformat/) واستدعِ [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_spellcheck/) للتحكم فيما إذا كان تطبيق العرض يمكنه فحص الإملاء لتلك الجزئية. القيمة الافتراضية هي `false`: `true` يسمح بفحص الإملاء، بينما `false` يقمعه.

ينطبق الإعداد على الجزئات النصية الفردية. وبالتالي يمكن للجزئات المختلفة في نفس الفقرة أن تستخدم قيمًا مختلفة. يعمل كل من [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_languageid/) و `SpellCheck` لأغراض تكاملية: يحدد `LanguageId` لغة التدقيق، بينما يحدد `SpellCheck` ما إذا كان يُسمح بفحص الإملاء لتلك الجزئية.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_proofdisabled/) يتحكم أيضًا في التدقيق، لكنه يمثل حالة "عدم التدقيق" الأوسع باعتبارها [NullableBool](https://reference.aspose.com/slides/ar/cpp/aspose.slides/nullablebool/). استخدم `SpellCheck` عندما تحتاج إلى مفتاح منطقي مباشر لتفعيل فحص الإملاء. استخدم `ProofDisabled` عندما تريد الحفاظ على أو التحكم صراحةً في بيانات التعريف الخاصة بعدم التدقيق، بما في ذلك حالتها `NullableBool::NotDefined`. إذا قمت بتعيين الخاصيتين، حافظ على توافق القيم؛ لا تجمع `SpellCheck = true` مع `ProofDisabled = NullableBool::True`.

تُعد هذه الخصائص بيانات تعريفية للتدقيق تُستخدمها PowerPoint وتطبيقات العروض التقديمية الأخرى. لا يستخدم Aspose.Slides هذه الخصائص لتشغيل فحص إملائي معتمد على القاموس أو لإرجاع قائمة الكلمات الخطأ.

المثال الكامل التالي يُنشئ عرضًا إدخالياً، يحملّه، يعيّن إعدادات فحص إملائي ولغات تدقيق مختلفة لجزئيتين في نفس الفقرة، يحفظ النتيجة، يفتحها مرة أخرى، ويتحقق من القيم المخزنة:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/joinportionswithsameformatting/) يجمع الجزئات المتجاورة التي لها نفس التنسيق. الاختلاف في `SpellCheck` وحده لا يمنع دمج هذه الجزئات؛ بعد دمجها، تحتفظ الجزئية الناتجة بقيمة `SpellCheck` للجزئية الأولى. إذا احتاجت الجزئات إلى إعدادات فحص إملائي مختلفة، استدعِ `JoinPortionsWithSameFormatting` قبل تعيين تلك الإعدادات، أو فحص حدود الجزئات الناتجة وإعادة تطبيق الإعدادات لاحقًا. تظل الجزئات ذات قيم `LanguageId` مختلفة منفصلة لأن تنسيق لغة التدقيق يختلف.

## **الأسئلة الشائعة**

**هل يترجم معرف اللغة النص؟**

لا. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_languageid/) يخزن بيانات تعريفية للتدقيق الإملائي والنحوي؛ ولا يغيّر محتوى النص. قم بترجمة النص بشكل منفصل، ثم حدد معرف اللغة المناسب لكل جزئية مترجمة.

**هل تتحكم لغة التدقيق في الخطوط أو الفواصل أو التفاف الأسطر؟**

لا. معرف اللغة مخصص للتدقيق فقط. يعتمد عرض النص وتنسيقه أساسًا على [الخطوط](/slides/ar/cpp/powerpoint-fonts/)، ونظام الكتابة، وإعدادات إطار النص. للحصول على عرض موثوق، قدّم الخطوط المطلوبة، واضبط [استبدال الخطوط](/slides/ar/cpp/font-substitution/)، أو [ضم الخطوط](/slides/ar/cpp/embedded-font/) في العرض.

**هل يمكن لفقرة واحدة استخدام عدة لغات تدقيق؟**

نعم. عيّن كل لغة إلى جزئية منفصلة، كما هو موضح في مثال الفقرة المتعددة اللغات.

**هل يجب استخدام `DefaultTextLanguage` أم `LanguageId`؟**

استخدم [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) عندما تريد قيمة افتراضية للنص الجديد. استخدم [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/set_languageid/) عندما تحتاج جزئية معينة إلى لغة تدقيق صريحة أو عندما تحتوي الفقرة على لغات متعددة.