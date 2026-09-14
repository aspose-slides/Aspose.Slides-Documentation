---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام بايثون عبر جافا
linktitle: استبدال الخطوط
type: docs
weight: 70
url: /ar/python-java/font-substitution/
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
- Python
- Java
- Aspose.Slides
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لبايثون عبر جافا عند عرض أو تحويل عروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

يُتيح استبدال الخطوط (Font substitution) لـ Aspose.Slides استخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيقوم بها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على اتساق المخرجات عبر بيئات تحتوي على خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getSubstitutions) لتحديد الخطوط التي ستُستبدل عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والخط المستبدل.

المثال التالي بلغة Python يعرض جميع استبدالات الخطوط لعرض تقديمي:

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

استخدم التحميل الزائد لطريقة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getSubstitutions) مع معامل مصفوفة أعداد صحيحة Java لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. يكون ذلك مفيدًا عندما تقوم بعرض أو تصدير جزء من العرض التقديمي، أو فحص عرض تقديمي كبير تدريجيًا، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط دقيقة لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير المرتبطة.

تحتوي مصفوفة `slides` على فهارس شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم قارئ مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) فهارس تبدأ بالصفر، لذا تُستَخدم الشريحة نفسها كـ `presentation.getSlides().get_Item(0)`. احرص على مراعاة هذا الاختلاف عند بناء المصفوفة لتجنب أخطاء الإزاحة.

استدعِ التحميل الزائد عبر طريقة [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getFontsManager). تُعيد الطريقة الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة فقط. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والخط المستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد السقوط الاحتياطي المكوَّنة، وقواعد الاستبدال المخزنة في [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsubstrulecollection/)، و[الخطوط المحمَّلة خارجيًا](/slides/ar/python-java/custom-font/).

يمكن أن تكون نفس الاستبدال مطلوبة لأكثر من شريحة محددة. قم بإزالة التكرارات عند إنشاء جرد للخطوط أو تقرير الفحص المسبق. المثال التالي يُبلِّغ عن كل استبدال مُعاد ويُنشئ قائمة مرتبة من تعيينات الخطوط الفريدة:

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

توفر فئة [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) كلتا التحميلات الزائدة. اختر واحدة وفقًا لنطاق عملية العرض:

| التحميل الزائد | متى تستخدمه |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getSubstitutions) دون معاملات | تحتاج إلى استبدالات للعرض التقديمي بأكمله. |
| [getSubstitutions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getSubstitutions) مع مصفوفة أعداد صحيحة Java | تحتاج إلى استبدالات لنطاق محدد، أو فحص تدريجي، أو تصدير جزئي. |

## **تعيين قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متوفر:

1. حمِّل العرض التقديمي.  
2. أنشئ تعريفات للخط المصدر والخط البديل.  
3. أنشئ كائنًا من نوع [FontSubstRule](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsubstrule/) مع شرط [WhenInaccessible](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsubstrulecollection/).  
5. اسند المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. عرض أو تحويل العرض التقديمي.

المثال التالي بلغة Python يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

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

{{% alert color="info" title="ملاحظة" %}}
لإجراء تغيير غير مشروط على الخطوط المستخدمة في كامل العرض التقديمي، راجع [استبدال الخطوط](/slides/ar/python-java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط المعادلات الرياضية**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل للكتابة العادية عندما يستطيع Aspose.Slides استبدال خط غير متاح بالخط المتاح المحدد بالقاعدة.

تتطلب المعادلات الرياضية في Office Math متطلبات إضافية. إذا استخدمت معادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد يظل العرض يُبلِّغ أن **Cambria Math** مطلوب.

لعرض أو تحويل مثل هذا العرض التقديمي، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. ثبت الخط في نظام التشغيل أو حمِّله كـ [خط خارجي](/slides/ar/python-java/custom-font/).

تنطبق هذه القاعدة على تخطيط المعادلات فقط. لا تزال قواعد الاستبدال المذكورة أعلاه سارية على النص العادي في العرض التقديمي.

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط وإستبدال الخطوط؟**  
[استبدال الخطوط](/slides/ar/python-java/font-replacement/) يغيِّر خطًا إلى آخر بشكل متعمد في جميع أنحاء العرض التقديمي. استبدال الخط يختار خطًا للمخرجات المعروضة عندما يتحقق الشرط المُكوَّن، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**  
تشارك القواعد في [تسلسل اختيار الخط](/slides/ar/python-java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible` تُستَخدم القاعدة فقط عندما لا يتمكن Aspose.Slides من الوصول إلى الخط المصدر.

**ماذا يحدث إذا كان الخط مفقودًا ولم تُحدد قاعدة استبدال؟**  
يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/python-java/custom-font/) ليستخدمها Aspose.Slides أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**  
لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**  
نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط بحسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز ما استبدالًا على جهاز آخر.

**كيف أجعل اختيار الخط ثابتًا في عمليات التحويل الجماعي؟**  
استخدم نفس ملفات الخط وإصداراتها على كل جهاز أو حاوية، [حمِّل الخطوط الخارجية المطلوبة](/slides/ar/python-java/custom-font/)، و[ضمّن الخطوط](/slides/ar/python-java/embedded-font/) عندما تسمح الترخيصات. يمكنك أيضًا استدعاء [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getSubstitutions) قبل التصدير لتحديد الاستبدالات غير المتوقعة.