---
title: تكوين استبدال الخط في العروض التقديمية باستخدام C++
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
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides للغة C++ عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يتيح استبدال الخط لـ Aspose.Slides استخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على الناتج المعروض؛ ولا يغيّر الخط المعين لمحتوى العرض.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي ستجريها Aspose.Slides أثناء العرض. يساعد هذا في الحفاظ على تناسق الناتج عبر البيئات التي تحتوي على خطوط مثبتة مختلفة.

إذا كان الخط متوفرًا لكن لا يحتوي على نمط غامق مخصص، راجع [معالجة الخطوط التي لا تحتوي على نمط غامق مخصص](/slides/ar/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يشرح ذلك كيفية تحويل النص المتأثر إلى نقطية أثناء تصدير PDF والعواقب على اختيار النص والبحث وتكبيره.

## **الحصول على استبدالات الخط**

استخدام طريقة [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة C++ يسرد جميع استبدالات الخطوط لعروض تقديمية:

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

## **الحصول على استبدالات الخط للشرائح المحددة**

استخدم نسخة [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) المتجاوزة مع معامل `System::ArrayPtr<int32_t> slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. يكون هذا مفيدًا عندما تقوم بعرض أو تصدير جزء من عرض تقديمي، أو فحص عرض كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط حد أدنى لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير المتعلقة.

مصفوفة `slides` تحتوي على فهارس شرائح تبدأ من الواحد: `1` يشير إلى الشريحة الأولى. بالمقابل، تستخدم طريقة [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) فهرسًا يبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة كـ `presentation->get_Slide(0)`. احرص على مراعاة هذا الاختلاف عند إنشاء المصفوفة لتجنب أخطاء إزاحة واحدة.

استدعِ النسخة عبر طريقة [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). تُعيد هذه الطريقة فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد الاحتياطي المُكوّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/)، و[الخطوط المحمّلة خارجيًا](/slides/ar/cpp/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة مُحددة. احذف التكرارات من النتائج عند إنشاء جرد للخطوط أو تقرير ما قبل الطيران. المثال التالي يُظهر كل استبدال مُرجع ثم ينشئ قائمة مرتبة لتطابقات الخطوط الفريدة:

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

توفر واجهة [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) كلتا النسختين. اختر واحدة وفقًا لنطاق عملية العرض:

| الإصدار | متى تُستخدم |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) بدون معاملات | تحتاج إلى استبدالات للعرض التقديمي بأكمله. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) مع `System::ArrayPtr<int32_t> slides` | تحتاج إلى استبدالات لنطاق محدد، أو فحص تدريجي، أو تصدير جزئي. |

## **تعيين قواعد استبدال الخط**

لتحديد الخط الذي يجب أن تستخدمه Aspose.Slides عندما يكون الخط الأصلي غير متوفر:

1. تحميل العرض التقديمي.  
2. إنشاء تعريفات الخط للخط الأصلي والبديل.  
3. إنشاء [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) مع شرط [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).  
4. إضافة القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).  
5. تعيين المجموعة باستخدام طريقة [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).  
6. عرض أو تحويل العرض التقديمي.

المثال التالي بلغة C++ يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متوفرًا لـ Aspose.Slides.

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
لتغيير غير مشروط للخطوط المستخدمة في جميع أنحاء العرض التقديمي، راجع [استبدال الخط](/slides/ar/cpp/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخط جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يستطيع Aspose.Slides استبدال خط غير متوفر بالخط المتاح المحدد في القاعدة.

معادلات Office Math لها متطلبات إضافية. إذا استخدمت معادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد يظل العرض يشير إلى أن **Cambria Math** مطلوب.

لعرض أو تحويل عرض تقديمي من هذا النوع، احرص على إتاحة **Cambria Math** لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/cpp/custom-font/).

هذا القيد ينطبق على تخطيط المعادلات. لا تزال قواعد الاستبدال الموصوفة أعلاه تنطبق على نص العرض التقديمي العادي.

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط (Font Replacement) واستبدال الخط (Font Substitution)؟**  
[استبدال الخط](/slides/ar/cpp/font-replacement/) يغيّر خطًا بآخر عمدًا في جميع أجزاء العرض التقديمي. استبدال الخط يختار خطًا للإخراج المعروض عندما تتحقق الشرط المُكوّن، مثل عندما يكون الخط الأصلي غير متوفر.

**متى تُطبّق قواعد الاستبدال؟**  
تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/cpp/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط الأصلي.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوّنة؟**  
يقوم Aspose.Slides باختيار أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/cpp/custom-font/) حتى يتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**  
لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**  
نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط حسب نظام التشغيل، لذا قد يكون الخط المتوفر على جهاز ما مطلوبًا استبداله على جهاز آخر.

**كيف يمكنني جعل اختيار الخط متسقًا في التحويلات الدفعية؟**  
استخدم نفس ملفات الخطوط وإصداراتها على كل جهاز أو حاوية، [حمل الخطوط الخارجية المطلوبة](/slides/ar/cpp/custom-font/)، و[ضم الخطوط](/slides/ar/cpp/embedded-font/) عندما تسمح التراخيص. يمكنك أيضًا استدعاء [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.