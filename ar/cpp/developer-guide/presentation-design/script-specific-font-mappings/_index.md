---
title: إدارة خطوط المظهر المخصصة للنصوص في C++
linktitle: خطوط المظهر المخصصة للنصوص
type: docs
weight: 15
url: /ar/cpp/script-specific-font-mappings/
keywords:
- خط نص مخصص
- تعيين خط المظهر
- عرض متعدد اللغات
- نظام كتابة
- خط سيريلية
- خط عربي
- خط ياباني
- خط جورجي
- خط ثانا
- PowerPoint
- عرض
- C++
- Aspose.Slides
description: "فحص وإضافة واستبدال وإزالة تعيينات خطوط مخصصة للنصوص في سمات PowerPoint باستخدام Aspose.Slides لـ C++."
---
## **نظرة عامة**

يمكن لمظهر العرض اختيار عائلات خطوط مختلفة لأنظمة كتابة مختلفة. يتيح ذلك نصًا متعدد اللغات لا يزال يستخدم خطوط المظهر ويتبع مخطط خط منسق واحد مع استخدام خطوط مناسبة للسيريلية، العربية، اليابانية، الجورجية، الثانا، وغيرها من الخطوط.

يحتوي [IFontScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/ifontscheme/) للمظهر على مجموعة خطوط رئيسية، تُستخدم عادة للعناوين، ومجموعة خطوط ثانوية تُستخدم عادة لنصوص الفقرات. بالإضافة إلى خصائص الخطوط اللاتينية والآسيوية الشرقية، تكشف كلتا المجموعتين عن تعيينات من وسوم نظام الكتابة إلى أسماء عائلات الخط عبر واجهة [IFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifonts/).

توضح هذه المقالة كيفية فحص وتعديل تلك التعيينات في المظهر الرئيسي للعرض والتحقق من بقاء التغييرات بعد عملية الحفظ وإعادة التحميل.

## **فهم وسوم النصوص**

تستخدم أساليب خطوط النص وسوم نصية من أربعة أحرف وفق معيار BCP 47 لتحديد أنظمة الكتابة. القيم الشائعة تشمل:

| علامة النص | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلية |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | الثانا |

تنتمي هذه التعيينات إلى مخطط خطوط المظهر، وليس إلى أجزاء النص الفردية. قد يحدد العرض تعيينات مختلفة للمجموعتين الرئيسيين والثانويين، وقد يحذف تعيينات لبعض الخطوط.

## **الوصول إلى وفحص تعيينات خطوط النصوص**

استخدم [Presentation::get_MasterTheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/) للوصول إلى المظهر على مستوى العرض. تُعيد طرق [FontScheme::get_Major](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_major/) و[FontScheme::get_Minor](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/fontscheme/get_minor/) المجموعتين [IFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifonts/).

استدعِ [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fonts/getscriptfontmap/) لاسترجاع جميع التعيينات من مجموعة معينة. للبحث عن نظام كتابة معين، استدعِ [Fonts::GetScriptFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fonts/getscriptfont/) مع وسمة النص الخاصة به. تُعيد `GetScriptFont` سلسلة فارغة عندما لا تعرف تلك المجموعة التعيين المطلوب.

## **تعديل التعيينات والتحقق من استمراريتها**

استخدم [Fonts::SetScriptFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fonts/setscriptfont/) لإنشاء تعيين أو استبدال عائلة الخط الحالية. استخدم [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fonts/removescriptfont/) لإزالة تعيين.

تقرأ المثال المتكامل أدناه جميع تعيينات الخطوط الرئيسة والثانوية الحالية، يبحث عن الخط الرئيس للغة اليابانية، يغيّر الخط الرئيس للسيريلية، يزيل تعيين الثانا الثانوي، يحفظ العرض، ثم يعيده للتحقق من كلا التغييرين. لجعل خطوة الإزالة مستقلة عن المظهر الأصلي، ينشئ المثال تعيين الثانا فقط عندما لا يكون موجودًا مسبقًا.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

يستخدم التحقق نفس سلوك السلسلة الفارغة كما في البحث العادي: بعد حفظ الإزالة، تُعيد `GetScriptFont(u"Thaa")` سلسلة فارغة للمجموعة الثانوية.

## **تمييز تعيينات المظهر عن إعدادات الخطوط الأخرى**

تشارك تعيينات خطوط المظهر المخصصة للنصوص في اختيار الخط، لكنها تحل مشكلة مختلفة عن التنسيق النصي المباشر، والاستبدال، والبدائل:

| الآلية | الغرض | أثر تغيير تعيين المظهر |
|---|---|---|
| تعيين خط المظهر المخصص للنص | يختار خطًا رئيسيًا أو ثانويًا للمظهر لنظام كتابة معين. | يمكن للنص الذي لا يزال يستخدم خط المظهر المقابل أن يُستبدل إلى العائلة الجديدة. |
| الخط المعين صراحةً لجزء نص | يثبت عائلة الخط المطلوبة على ذلك الجزء بدلاً من الاعتماد على المظهر. | قد يبقى الجزء دون تغيير لأن التنسيق المباشر يتجاوز اختيار المظهر. |
| استبدال الخط | يُستبدل الخط المطلوب عندما يكون غير متوفر أو عندما تُطبق قاعدة استبدال. | يحدث بعد طلب الخط؛ لا يعيد تعريف تعيين المظهر للنص. |
| بديل الخط | يُوفر رموزًا غير موجودة في الخط المختار، غالبًا لنطاقات يونيكود معينة. | يملأ الفجوات في الرموز؛ لا يغيّر تعيين المظهر المخزن. |

لمزيد من المعلومات حول الآليتين الأخيرتين، راجع [Font Substitution](/slides/ar/cpp/font-substitution/) و[Fallback Fonts](/slides/ar/cpp/fallback-font/).

يؤثر تغيير تعيين في [Presentation::get_MasterTheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_mastertheme/) فقط على المحتوى الذي لا يزال يعتمد تنسيقه الفعّال على ذلك المظهر. قد يرث النص بدلاً من ذلك تجاوزًا للمظهر من ماستر أو تخطيط أو شريحة، أو يستخدم خطًا معينًا صراحةً. افحص تلك المستويات عندما لا يتطابق النتيجة الظاهرة مع تعيين المظهر على مستوى العرض.

## **إتاحة الخطوط المعينة والتحقق من النتيجة**

يخزن تعيين النص اسم عائلة الخط؛ ولا يثبت أو يحمل ملف الخط المقابل. لتماسك العرض وتصديره، يجب تثبيت كل خط معين في البيئة أو تزويده إلى Aspose.Slides عبر مصدر مخصص مثل [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/loadexternalfonts/) أو [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). راجع [Custom Fonts](/slides/ar/cpp/custom-font/) للحصول على خيارات التحميل المتاحة.

يؤكد التحقق من التعيين المحفوظ فقط أن تعريف المظهر تم حفظه. لا يثبت أن الخط متاح، أو يحتوي على جميع الأحرف المطلوبة، أو ينتج التخطيط المقصود. قم بتصوير نص تمثيلي لكل نظام كتابة مطلوب إلى صورة أو PDF وافحص النتيجة. يكتشف ذلك الخطوط المفقودة، ونطاقات الأحرف غير المكتملة، وسلوك البدائل، وتغييرات التخطيط قبل توزيع العرض. راجع [Convert PowerPoint Presentations](/slides/ar/cpp/convert-powerpoint/) لأمثلة على التصيير والتصدير.

## **الأسئلة المتكررة**

**ماذا تُعيد `GetScriptFont` عندما لا يكون هناك تعيين للنص؟**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fonts/getscriptfont/) تُعيد سلسلة فارغة عندما لا يكون تعيين النص المطلوب مُعرفًا في تلك المجموعة الرئيسة أو الثانوية.

**هل `SetScriptFont` يضيف تعيينًا ثانيًا عندما يكون النص موجودًا مسبقًا؟**

لا. [Fonts::SetScriptFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fonts/setscriptfont/) يُنشئ التعيين عندما يكون مفقودًا ويستبدل عائلة الخط المعينة عندما تكون وسمة النص موجودة بالفعل.

**لماذا لم يُغيّر تغيير تعيين المظهر بعض النصوص؟**

قد يحتوي النص على خط معين صراحةً، أو يرث مظهرًا مختلفًا عبر تجاوز، أو يتأثر بالاستبدال أو البديل أثناء التصيير. يتحكم تعيين نص المظهر على مستوى العرض فقط في النصوص التي لا يزال تنسيقها الفعّال يعتمد على مجموعة خطوط المظهر تلك.

**هل حفظ العرض وإعادة فتحه كافٍ للتحقق من الإخراج متعدد اللغات؟**

لا. تُظهر إعادة الفتح بقاء بيانات المظهر. يجب أيضًا تصيير نص تمثيلي من كل نظام كتابة مطلوب للتأكد من أن الخطوط المعينة متاحة وتحتوي على الأحرف الضرورية.