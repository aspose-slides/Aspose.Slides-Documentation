---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام Python عبر Java
linktitle: استبدال الخطوط
type: docs
weight: 70
url: /ar/python-java/font-substitution/
keywords:
- خط
- خط مستبدل
- استبدال الخط
- استبدال الخط
- استبدال الخط
- قاعدة استبدال
- قاعدة استبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لـ Python عبر Java عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يتيح استبدال الخطوط لـ Aspose.Slides استخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على الإخراج المعروض؛ لا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على التناسق في الإخراج عبر بيئات مختلفة تحتوي على خطوط مثبتة مختلفة.

إذا كان الخط متوفرًا ولكنه لا يحتوي على شكل سميك مخصص، راجع [معالجة الخطوط التي لا تملك نوعًا سميكًا مخصصًا](/slides/ar/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يشرح ذلك القسم كيفية تحويل النص المتأثر إلى نمط نقطي أثناء تصدير PDF والعواقب على تحديد النص والبحث والتكبير.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) لتحديد الخطوط التي سيتم استبدالها عندما يتم عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والبديل.

المثال التالي بلغة بايثون يسرد جميع استبدالات الخطوط لعرض تقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **الحصول على استبدالات الخطوط للشرائح المحددة**

استخدم نسخة طريقة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) التي تستقبل مصفوفة أعداد صحيحة من جافا لتفحص فقط الاستبدالات المطلوبة لعرض شرائح معينة. يكون ذلك مفيدًا عند عرض أو تصدير جزء من العرض التقديمي، أو فحص عرض تقديمي كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط حدّية للخادم أو الحاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

مصفوفة `slides` تحتوي على فهارس شرائح بدءًا من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستعمل الواصف [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) فهارس تبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة عبر `presentation.getSlides().get_Item(0)`. احرص على مراعاة هذا الاختلاف عند بناء المصفوفة لتجنب أخطاء الإزاحة.

استدعي النسخة عبر طريقة [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). تعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والبديل. تعكس النتيجة بيئة الخطوط الحالية، وقواعد الاحتياط المكوَّنة، وقواعد الاستبدال المخزنة في [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/)، و[الخطوط المحمَّلة خارجيًا](/slides/ar/python-java/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة مختارة. قم بإزالة التكرارات من النتائج عندما تنشئ جردًا للخطوط أو تقريرًا مسبقًا. المثال التالي يعرض كل استبدال تم إرجاعه ثم ينشئ قائمة مرتبة للتطابقات الفريدة للخطوط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

توفر الفئة [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) كلا النسختين. اختر واحدة وفقًا لنطاق عملية العرض.

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) بدون معطيات | تحتاج إلى استبدالات للعرض التقديمي بالكامل. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) مع مصفوفة أعداد صحيحة من جافا | تحتاج إلى استبدالات لنطاق مختار، فحص تدريجي، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب على Aspose.Slides استخدامه عندما يكون الخط الأصلي غير متوفر:

1. حمّل العرض التقديمي.
2. أنشئ تعريفات الخط للخط الأصلي والبديل.
3. أنشئ كائنًا من نوع [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) مع شرط [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. عيّن المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. اعرض أو حوّل العرض التقديمي.

المثال التالي بلغة بايثون يستبدل الخط `Arial` بالخط `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
لإجراء تغيير غير مشروط للخطوط المستخدمة عبر العرض التقديمي بأكمله، راجع [استبدال الخط](/slides/ar/python-java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط المعادلات الرياضية**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يستطيع Aspose.Slides استبدال خط غير متاح بالخط المتوفر المحدد بواسطة قاعدة.

معادلات Office Math لها متطلب إضافي. إذا استخدمت معادلة **Cambria Math**، قد تحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. قاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، لا يمكنها استبدال **Cambria Math** لهذا الغرض، وقد يظل العرض يُظهر أن **Cambria Math** مطلوب.

لعرض أو تحويل مثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/python-java/custom-font/).

هذا القيد ينطبق على تخطيط المعادلات. لا تزال قواعد الاستبدال المذكورة أعلاه سارية على النص العادي في العرض.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**  
[استبدال الخط](/slides/ar/python-java/font-replacement/) يغيّر خطًا إلى آخر عمدًا عبر العرض التقديمي بأكمله. استبدال الخطوط يختار خطًا للإخراج المعروض عندما يتحقق الشرط المحدد، مثل عدم توفر الخط الأصلي.

**متى تُطبّق قواعد الاستبدال؟**  
تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/python-java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا تستطيع Aspose.Slides الوصول إلى الخط الأصلي.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**  
تختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة بها. يعتمد النتيجة على الخطوط المتوفرة في بيئة التنفيذ.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/python-java/custom-font/) لكي تتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**  
لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**  
نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخطوط بين أنظمة التشغيل، لذا قد يتطلب خط متوفر على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكنني جعل اختيار الخطوط متسقًا في التحويلات الدفعية؟**  
استخدم نفس ملفات الخطوط وإصداراتها على كل جهاز أو حاوية، [حمِّل الخطوط الخارجية المطلوبة](/slides/ar/python-java/custom-font/)، و[ضمن الخطوط](/slides/ar/python-java/embedded-font/) عندما تسمح الرخصة. يمكنك أيضًا استدعاء [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) قبل التصدير لتحديد الاستبدالات غير المتوقعة.