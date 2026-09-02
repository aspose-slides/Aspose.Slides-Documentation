---
title: تكوين استبدال الخط في العروض التقديمية في C++
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/cpp/font-substitution/
keywords:
- خط
- خط بديل
- استبدال الخط
- استبدال الخط
- استبدال الخط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تكوين قواعد استبدال الخط وفحص الخطوط المستبدلة في Aspose.Slides للغة C++ عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يتيح استبدال الخطوط لـ Aspose.Slides استخدام خط متاح بدلاً من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تعريف الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على تناسق المخرجات عبر بيئات ذات خطوط مثبتة مختلفة.

## **Get Font Substitutions**

استخدم طريقة [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getsubstitutions/) لتحديد الخطوط التي ستستبدل عندما يتم عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة C++ يسرد جميع استبدالات الخطوط لعرض تقديمي:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Get Font Substitutions for Selected Slides**

استخدم التحميل الزائد للطريقة [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getsubstitutions/) مع معامل `System::ArrayPtr<int32_t> slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. يكون هذا مفيدًا عندما تقوم بعرض أو تصدير جزء من العرض التقديمي، أو فحص عرض تقديمي كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط مصغرة لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

يحتوي مصفوفة `slides` على فهارس الشرائح بدءًا من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، تستخدم طريقة [Presentation::get_Slide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slide/) فهرسًا يبدأ من الصفر، لذلك تُستدعى تلك الشريحة نفسها كـ `presentation->get_Slide(0)`. احرص على مراعاة هذا الاختلاف عند بناء المصفوفة لتجنب أخطاء الإزاحة بواحد.

استدعِ التحميل الزائد عبر طريقة [Presentation::get_FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_fontsmanager/) . تُعيد الطريقة الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة فقط. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد السقوط الاحتياطي المُكوَّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsubstrulecollection/)، و[الخطوط المحمَّلة خارجيًا](/slides/ar/cpp/custom-font/).

يمكن أن تتطلب نفس الاستبدالة أكثر من شريحة مختارة. قم بإزالة التكرارات عند إنشاء جرد الخطوط أو تقرير الفحص المسبق. المثال التالي يُبلغ عن كل استبدال مُرجَع ثم يُنشئ قائمة مرتبة لتعيينات الخطوط الفريدة:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

توفر واجهة [IFontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/) كلاً من التحميلين الزائدين. اختر الأنسب حسب نطاق عملية العرض:

| التحميل الزائد | متى تستخدمه |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getsubstitutions/) بدون معامل | تحتاج إلى استبدالات للعرض التقديمي بالكامل. |
| [GetSubstitutions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getsubstitutions/) مع `System::ArrayPtr<int32_t> slides` | تحتاج إلى استبدالات لنطاق مختار، فحص تدريجي، أو تصدير جزئي. |

## **Set Font Substitution Rules**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متوفر:

1. تحميل العرض التقديمي.  
2. إنشاء تعريفات للخط المصدر والبديل.  
3. إنشاء كائن [FontSubstRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsubstrule/) بشرط [WhenInaccessible](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsubstcondition/).  
4. إضافة القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsubstrulecollection/).  
5. تعيين المجموعة باستخدام طريقة [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. عرض أو تحويل العرض التقديمي.

المثال التالي بلغة C++ يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
لإجراء تغيير غير مشروط على الخطوط المستخدمة في جميع أنحاء العرض التقديمي، راجع [Font Replacement](/slides/ar/cpp/font-replacement/).
{{% /alert %}}

## **Limitations for Math Equation Fonts**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يستطيع Aspose.Slides استبدال خط غير متاح بالخط المتاح المحدد بالقاعدة.

معادلات Office Math لديها متطلب إضافي. إذا استخدمت معادلة **Cambria Math**، قد تحتاج Aspose.Slides إلى ذلك الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل خط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد يظل العرض يشير إلى أن **Cambria Math** ضروري.

لعرض أو تحويل مثل هذا العرض، احرص على إتاحة **Cambria Math** لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/cpp/custom-font/).

هذا القيد يقتصر على تخطيط المعادلات. ما زالت قواعد الاستبدال المذكورة أعلاه سارية للنص العادي في العرض التقديمي.

## **FAQ**

**ما الفرق بين استبدال الخط وتبديل الخط؟**

[Font replacement](/slides/ar/cpp/font-replacement/) يغيّر خطًا واحدًا بآخر في جميع أنحاء العرض التقديمي عمدًا. استبدال الخط يختار خطًا للمخرجات المعروضة عندما يتحقق الشرط المُكوَّن، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**

تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/cpp/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث إذا كان الخط مفقودًا ولا توجد قاعدة استبدال مُعَرفة؟**

يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. النتيجة تعتمد على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [load external fonts](/slides/ar/cpp/custom-font/) ليتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والالتزام بتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط حسب نظام التشغيل، لذا قد يتطلب خط متاح في جهاز ما استبدالًا في جهاز آخر.

**كيف يمكنني جعل اختيار الخط متسقًا في التحويلات الدفعية؟**

استخدم نفس ملفات الخط وإصداراتها على كل جهاز أو حاوية، [load required external fonts](/slides/ar/cpp/custom-font/)، و[embed fonts](/slides/ar/cpp/embedded-font/) عندما تسمح التراخيص. يمكنك أيضًا استدعاء [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.