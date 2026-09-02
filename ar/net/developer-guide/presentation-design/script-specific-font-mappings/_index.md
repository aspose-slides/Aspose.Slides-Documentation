---
title: إدارة خطوط السمة الخاصة بالنص في .NET
linktitle: خطوط السمة الخاصة بالنص
type: docs
weight: 15
url: /ar/net/script-specific-font-mappings/
keywords:
- خط خاص بالنص
- تعيين خط السمة
- عرض متعدد اللغات
- نظام كتابة
- خط سيريلي
- خط عربي
- خط ياباني
- خط جورجي
- خط ثانا
- PowerPoint
- عرض
- .NET
- C#
- Aspose.Slides
description: "فحص وإضافة واستبدال وإزالة تعيينات الخطوط الخاصة بالنص في سمات PowerPoint باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

يمكن لثيم العرض اختيار عائلات خطوط مختلفة لأنظمة كتابة مختلفة. يتيح ذلك نصًا متعدد اللغات مازال يستخدم خطوط الثيم ليتبع مخطط خطوط منسق مع استخدام خطوط مناسبة للسيريلية والعربية واليابانية والجورجية والثانا وغيرها من الخطوط.

يحتوي الثيم الخاص بـ[IFontScheme](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/ifontscheme/) على مجموعة خطوط رئيسية تُستخدم عادةً للعناوين، ومجموعة خطوط فرعية تُستخدم عادةً للنص الأساسي. بالإضافة إلى خصائص الخطوط اللاتينية والآسيوية الشرقية، تعرض كلتا المجموعتين تعيينات من وسوم أنظمة الكتابة إلى أسماء عائلات الخطوط عبر واجهة[IFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/ifonts/).

تظهر هذه المقالة كيفية فحص وتعديل تلك التعيينات في الثيم الرئيسي للعرض والتحقق من أن التغييرات تبقى بعد عملية الحفظ وإعادة التحميل.

## **فهم وسوم النص**

تستخدم طرق خطوط النص وسوم نصية مكوّنة من أربعة أحرف وفق معيار BCP 47 لتحديد أنظمة الكتابة. تشمل القيم الشائعة:

| وسوم النص | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلي |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | الثانا |

هذه التعيينات تتبع مخطط خط الثيم، لا النصوص الفردية. قد يحدد العرض تعيينات مختلفة للمجموعتين الرئيسية والفرعية، وقد يتجاوز تعيينات لبعض النصوص.

## **الوصول إلى وفحص تعيينات خطوط النص**

استخدم[Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/) للوصول إلى ثيم مستوى العرض. تُعيد خصائص[FontScheme.Major](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/major/) و[FontScheme.Minor](https://reference.aspose.com/slides/ar/net/aspose.slides.theme/fontscheme/minor/) مجموعتي[IFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/ifonts/) .

استدعِ[IFonts.GetScriptFontMap](https://reference.aspose.com/slides/ar/net/aspose.slides/fonts/getscriptfontmap/) لاسترجاع جميع التعيينات من مجموعة. للبحث عن نظام كتابة واحد، استدعِ[IFonts.GetScriptFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fonts/getscriptfont/) مع وسم النص الخاص به. `GetScriptFont` تُرجع `null` عندما لا تحدد تلك المجموعة التعيين المطلوب.

## **تعديل التعيينات والتحقق من الاستمرارية**

استخدم[IFonts.SetScriptFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fonts/setscriptfont/) لإنشاء تعيين أو استبدال عائلة الخط الحالية. استخدم[IFonts.RemoveScriptFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fonts/removescriptfont/) لإزالة تعيين.

المثال التالي يقرأ جميع التعيينات الرئيسية والفرعية الحالية، يبحث عن خط اليابانية الرئيسي، يغيّر خط السيريلية الرئيسي، يزيل تعيين الثانا الفرعي، يحفظ العرض، ويعيد فتحه للتحقق من كلا التغييرين. لجعل خطوة الإزالة مستقلة عن الثيم الأولي، ينشئ المثال تعيين الثانا فقط عندما لا يكون معرفًا مسبقًا.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

التحقق يستخدم نفس سلوك `null` كبحث عادي: بعد حفظ خطوة الإزالة، `GetScriptFont("Thaa")` تُرجع `null` للمجموعة الفرعية.

## **تمييز تعيينات السمة عن إعدادات الخطوط الأخرى**

تشارك تعيينات خطوط الثيم الخاصة بالنص في اختيار الخط، لكنها تحل مشكلة مختلفة عن تنسيق النص المباشر، والاستبدال، والاحتياطي:

| آلية | الغرض | تأثير تغيير تعيين السمة |
|---|---|---|
| تعيين خط السمة الخاص بالنص | يختار خط سمة رئيسي أو فرعي لنظام كتابة. | النص الذي لا يزال يستخدم خط السمة المقابل يمكن أن يُحل إلى عائلة الخط الجديدة. |
| الخط المعين صراحةً لجزء نص | يثبت عائلة الخط المطلوبة لهذا الجزء بدلاً من الاعتماد على السمة. | قد يبقى الجزء غير متغير لأن تنسيقه المباشر يتجاوز اختيار السمة. |
| استبدال الخط | يستبدل الخط المطلوب عندما يكون غير متوفر أو عندما تنطبق قاعدة استبدال. | يحدث بعد طلب الخط؛ لا يعيد تعريف تعيين النص في السمة. |
| احتياطي الخط | يوفّر رموزًا لا يحتويها الخط المحدد، غالبًا لنطاقات يونيكود معينة. | يملأ النقص في الرموز؛ لا يغيّر تعيين السمة المخزن. |

لمزيد من المعلومات حول الآليتين الأخيرتين، راجع [Font Substitution](/slides/ar/net/font-substitution/) و[Fallback Fonts](/slides/ar/net/fallback-font/).

تغيير تعيين في[Presentation.MasterTheme](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/mastertheme/) يؤثر فقط على المحتوى الذي لا يزال تنسيقه الفعّال يعتمد على ذلك الثيم. قد يرث النص بدلًا من ذلك تجاوز سمة من رئيس، أو تخطيط، أو شريحة، أو يستخدم خطًا معينًا صراحةً. افحص تلك المستويات عندما لا يتبع النتيجة الظاهرة تعيين مستوى العرض.

## **إتاحة الخطوط المعينة والتحقق من النتيجة**

يخزن تعيين النص اسم عائلة الخط؛ لا يثبت أو يحمل ملف الخط المقابل. لضمان عرض وتصدير متسق، يجب أن يكون كل خط معين مثبتًا في البيئة أو مُزودًا إلى Aspose.Slides عبر مصدر مخصص مثل [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/) أو [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/documentlevelfontsources/). راجع [Custom Fonts](/slides/ar/net/custom-font/) لخيارات التحميل المتاحة.

التحقق من حفظ التعيين يؤكد فقط أن تعريف السمة تم الحفاظ عليه. لا يثبت أن الخط متاح، أو يحتوي على جميع الرموز المطلوبة، أو ينتج التخطيط المقصود. قم بتصوير نص تمثيلي لكل نظام كتابة مطلوب إلى صورة أو PDF وافحص الناتج. سيساعد ذلك في اكتشاف الخطوط المفقودة، أو نقص الرموز، أو سلوك الاحتياطي، أو تغييرات التخطيط قبل توزيع العرض. راجع [Convert PowerPoint Presentations](/slides/ar/net/convert-powerpoint/) لأمثلة على العرض والتصدير.

## **الأسئلة المتكررة**

**ماذا تُرجع `GetScriptFont` عندما لا يكون النص مُعينًا؟**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fonts/getscriptfont/) تُرجع `null` عندما لا يكون تعيين النص المطلوب معرفًا في تلك المجموعة الرئيسية أو الفرعية.

**هل `SetScriptFont` يضيف تعيينًا ثانيًا عندما يكون النص موجودًا بالفعل؟**

لا. [IFonts.SetScriptFont](https://reference.aspose.com/slides/ar/net/aspose.slides/fonts/setscriptfont/) يخلق التعيين عندما يكون مفقودًا ويستبدل عائلة الخط المعينة عندما يكون وسم النص موجودًا بالفعل.

**لماذا لم يغيّر تغيير تعيين السمة بعض النصوص؟**

قد يكون النص قد عُيّن له خط صراحةً، أو ورث سمة مختلفة عبر تجاوز، أو تأثر بالاستبدال أو الاحتياطي أثناء العرض. يتحكم تعيين النص في مستوى العرض فقط في النصوص التي لا يزال تنسيقها الفعّال يشير إلى مجموعة خطوط السمة تلك.

**هل حفظ وإعادة فتح كافٍ للتحقق من المخرجات المتعددة اللغات؟**

لا. إعادة الفتح تَتحقق من بقاء بيانات السمة. يجب أيضًا عرض نص تمثيلي من كل نظام كتابة مطلوب لتأكيد توفر الخطوط المعينة واحتوائها على الرموز الضرورية.