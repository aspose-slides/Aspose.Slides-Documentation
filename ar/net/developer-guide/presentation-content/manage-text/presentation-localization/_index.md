---
title: أتمتة توطين العروض التقديمية في .NET
linktitle: توطين العروض التقديمية
type: docs
weight: 100
url: /ar/net/presentation-localization/
keywords:
- تغيير اللغة
- فحص الإملاء
- كتم فحص الإملاء
- لغة التدقيق
- معرف اللغة
- نص متعدد اللغات
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعيين لغات التدقيق لنصوص عروض PowerPoint وOpenDocument في .NET باستخدام Aspose.Slides، بما في ذلك الإعدادات الافتراضية والفقرات متعددة اللغات."
---
## **نظرة عامة**

Aspose.Slides for .NET يتيح لك تكوين بيانات التعريف الخاصة بالتدقيق اللغوي لأجزاء النص الفردية. استخدم [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/) لتحديد لغة التدقيق، و[BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/spellcheck/) للسماح أو كتم فحص الإملاء، و[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/proofdisabled/) للتحكم في حالة عدم التدقيق العامة. نظرًا لتطبيق هذه الإعدادات على مستوى الجزء، يمكن لفقرة واحدة أن تحتوي على عدة لغات وقواعد تدقيق مختلفة.

توضح هذه المقالة كيفية تعيين لغة لنص معين، وضبط اللغة الافتراضية للنص الجديد باستخدام [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaulttextlanguage/)، وإنشاء فقرات متعددة اللغات، واختيار بين `SpellCheck` و `ProofDisabled`، والحفاظ على الإعدادات المقصودة عند استخدام [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/joinportionswithsameformatting/). هذه الخصائص تخزن بيانات التعريف لتطبيقات العروض التقديمية؛ فهي لا تترجم النص، ولا تجري تدقيقًا إملائيًا معتمدًا على القواميس، ولا تُعيد الكلمات المكتوبة بشكل خاطئ.

## **تعيين لغة التدقيق للنص**

أنشئ أو حمّل [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، وابدأ بالوصول إلى الجزء النصي المطلوب عبر [IPortion.PortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/portionformat/)، ثم عيّن معرّف اللغة الخاص به. المثال التالي ينشئ شكلًا، ويضبط الإنجليزية البريطانية كلغة تدقيق، ويحفظ النتيجة باستخدام [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **ضبط اللغة الافتراضية للنص الجديد**

استخدم [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaulttextlanguage/) لتحديد لغة التدقيق التي يطبقها Aspose.Slides على النص الذي يتم إنشاؤه حديثًا. يكون هذا الإعداد مفيدًا عندما يكون معظم أو كل النص الجديد في العرض التقديمي يستخدم نفس اللغة. لا يغيّر هذا الإعداد بيانات التعريف الخاصة بالنص الذي لديه بالفعل لغة صريحة.

المثال التالي يُنشئ عرضًا تقديميًا يستخدم قواعد التدقيق الألمانية للنص الجديد:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **استخدام لغات متعددة في فقرة واحدة**

[IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/) يحتوي على مجموعة من أجزاء النص. أنشئ [Portion](https://reference.aspose.com/slides/ar/net/aspose.slides/portion/) منفصلًا لكل لغة واضبط خاصية `LanguageId` له بشكل مستقل.

هذا المثال يُنشئ فقرة واحدة تحتوي على أجزاء إنجليزية وفرنسية:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **تمكين أو كتم فحص الإملاء لأجزاء معينة**

[IPortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportionformat/) يرث الخصائص النصية العامة المُعرَّفة في [IBasePortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/). عبر [IPortion.PortionFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/iportion/portionformat/) يمكنك ضبط [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/spellcheck/) للتحكم فيما إذا كان تطبيق العروض التقديمية قد يتحقق من الإملاء لهذا الجزء. القيمة الافتراضية هي `false`: `true` يسمح بالتحقق، بينما `false` يكمته.

ينطبق هذا الإعداد على أجزاء النص الفردية. وبالتالي يمكن لأجزاء مختلفة في نفس الفقرة استخدام قيم مختلفة. كل من [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/languageid/) و`SpellCheck` يخدمان أغراضًا تكميلية: `LanguageId` يحدد لغة التدقيق، بينما `SpellCheck` يحدد ما إذا كان يُسمح بفحص الإملاء للجزء.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/proofdisabled/) يتحكم أيضًا في التدقيق، لكنه يمثل حالة "عدم التدقيق" الأوسع كـ[NullableBool](https://reference.aspose.com/slides/ar/net/aspose.slides/nullablebool/). استخدم `SpellCheck` عندما تحتاج إلى مفتاح بولياني مباشر لتدقيق الإملاء. استخدم `ProofDisabled` عندما تحتاج إلى الحفاظ على أو التحكم صراحةً في بيانات التعريف الخاصة بعدم التدقيق في العرض، بما في ذلك حالتها `NotDefined`. إذا قمت بتعيين كلتا الخاصيتين، حافظ على توافق القيم؛ لا تجمع بين `SpellCheck = true` و`ProofDisabled = NullableBool.True`.

تُكوِّن هذه الخصائص بيانات التعريف الخاصة بالتدقيق المستخدمة في PowerPoint وتطبيقات العروض التقديمية الأخرى. لا يستخدم Aspose.Slides هذه الخصائص لتشغيل تدقيق إملائي معتمد على القواميس أو لإرجاع قائمة بالكلمات المكتوبةخاطئً.

المثال الكامل التالي يخلق عرضًا تقديميًا مدخلًا، يحمّله، يعين إعدادات فحص إملائي ولغات تدقيق مختلفة لجزءين في نفس الفقرة، يحفظ النتيجة، يعيد فتحه، ويتحقق من القيم المخزنة:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/joinportionswithsameformatting/) يجمع الأجزاء المتجاورة التي لها نفس التنسيق. اختلاف `SpellCheck` وحده لا يبقي هذه الأجزاء منفصلة؛ بعد دمجها، يحتفظ الجزء الناتج بقيمة `SpellCheck` للجزء الأول. إذا كانت الأجزاء تحتاج إلى إعدادات فحص إملائي مختلفة، استدعِ `JoinPortionsWithSameFormatting` قبل تعيين تلك الإعدادات، أو افحص حدود الجزء الناتج وأعد تطبيق الإعدادات بعد ذلك. تبقى الأجزاء التي لها قيم `LanguageId` مختلفة منفصلة لأن تنسيق لغة التدقيق يختلف.

## **الأسئلة المتكررة**

**هل يُترجم معرف اللغة النص؟**

لا. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/) يخزن بيانات التعريف الخاصة بالتدقيق الإملائي والنحوي؛ ولا يغير محتوى النص. قم بترجمة النص منفصلًا، ثم عيّن معرّف اللغة المناسب لكل جزء مُترجم.

**هل تتحكم لغة التدقيق في الخطوط أو التجزيء أو التفاف السطر؟**

لا. معرّف اللغة يخص التدقيق فقط. يعتمد عرض النص وتنسيقه أساسًا على الخطوط المتوفرة [fonts](/slides/ar/net/powerpoint-fonts/)، ونظام الكتابة، وإعدادات إطار النص. للحصول على عرض موثوق، زوّد الخطوط المطلوبة، واضبط [font substitution](/slides/ar/net/font-substitution/)، أو [embed fonts](/slides/ar/net/embedded-font/) في العرض.

**هل يمكن لفقرة واحدة استخدام عدة لغات تدقيق؟**

نعم. عيّن كل لغة إلى جزء منفصل، كما هو موضح في مثال الفقرة متعددة اللغات.

**هل يجب أن أستخدم `DefaultTextLanguage` أم `LanguageId`؟**

استخدم [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaulttextlanguage/) عندما تريد تحديد لغة افتراضية للنص الذي يُنشأ حديثًا. استخدم [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseportionformat/languageid/) عندما يحتاج جزء معين إلى لغة تدقيق صريحة أو عندما تحتوي الفقرة على لغات متعددة.