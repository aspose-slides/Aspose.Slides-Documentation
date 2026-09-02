---
title: تكوين استبدال الخط في العروض التقديمية باستخدام Python
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/python-net/font-substitution/
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
- Aspose.Slides
description: "تكوين قواعد استبدال الخط وفحص الخطوط المستبدلة في Aspose.Slides للغة Python عبر .NET عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يسمح استبدال الخطوط لـ Aspose.Slides باستخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على النتيجة المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على ثبات الإخراج عبر بيئات مختلفة تحتوي على خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [FontsManager.get_substitutions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_substitutions/) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة Python يسرد جميع استبدالات الخطوط لعرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **الحصول على استبدالات الخطوط للشرائح المحددة**

استخدم [FontsManager.get_substitutions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_substitutions/) مع قائمة بمؤشرات الشرائح لفحص الاستبدالات المطلوبة فقط لعرض شرائح محددة. هذا مفيد عندما تقوم بعرض أو تصدير جزء من العرض، أو فحص عرض كبير بشكل متدرج، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط حد أدنى لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير المتعلقة.

تحتوي القائمة على مؤشرات شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، مجموعة [Presentation.slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) تبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة كـ `presentation.slides[0]`. ضع في اعتبارك هذا الاختلاف عند بناء القائمة لتجنب أخطاء الإزاحة.

استدعِ الطريقة عبر خاصية [Presentation.fonts_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/fonts_manager/). تُعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المختارة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد الاحتياطي المكوّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ifontsubstrulecollection/)، و[الخطوط المحمَّلة خارجيًا](/slides/ar/python-net/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة مختارة. قم بإزالة التكرارات عند إنشاء جرد الخطوط أو تقرير الفحص المسبق. المثال التالي يعلن كل استبدال تم إرجاعه ثم يُنشئ قائمة مرتبة بخرائط الخطوط الفريدة:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

فئة [FontsManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/) توفر كلا الشكلين من الطريقة. اختر ما يناسب نطاق عملية العرض:

| طريقة الاستدعاء | استخدامها عندما |
|---|---|
| [get_substitutions] بدون أي معلمات | تحتاج إلى استبدالات لكامل العرض التقديمي. |
| [get_substitutions] مع قائمة مؤشرات شرائح | تحتاج إلى استبدالات لنطاق مختار، فحص متدرج، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متوفر:

1. تحميل العرض التقديمي.
2. إنشاء تعريفات الخط للخط المصدر والبديل.
3. إنشاء كائن [FontSubstRule](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsubstrule/) مع شرط [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsubstcondition/).
4. إضافة القاعدة إلى مجموعة [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsubstrulecollection/).
5. تعيين المجموعة إلى خاصية [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. عرض أو تحويل العرض التقديمي.

المثال التالي بلغة Python يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
لإجراء تغيير غير مشروط على الخطوط المستخدمة في جميع أنحاء العرض، راجع [Font Replacement](/slides/ar/python-net/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل بالنسبة للنص العادي عندما يمكن لـ Aspose.Slides استبدال الخط غير المتاح بالخط المتاح المحدد في القاعدة.

تتطلب معادلات Office Math شرطًا إضافيًا. إذا استخدمت المعادلة **Cambria Math**، قد تحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر مثل **STIX Two Math** استبدال **Cambria Math** لهذا الغرض، وقد يظل العرض يُظهر أن **Cambria Math** مطلوب.

للعرض أو التحويل لمثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. ثبّته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/python-net/custom-font/).

تنطبق هذه القاعدة على تخطيط المعادلات فقط. ما زالت قواعد الاستبدال المذكورة أعلاه سارية على النص العادي في العرض.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبداله؟**

[Font replacement](/slides/ar/python-net/font-replacement/) يغيّر الخط بشكل متعمد عبر العرض بأكمله. استبدال الخط يختار خطًا للنتيجة المعروضة عندما يتحقق الشرط المحدد، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**

تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/python-net/font-selection-sequence/) أثناء العرض والتحويل. مع `WHEN_INACCESSIBLE`، تُستخدم القاعدة فقط عندما لا تستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**

تختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة بها. تعتمد النتيجة على الخطوط المتوفرة في بيئة التنفيذ.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/python-net/custom-font/) حتى يستخدمها Aspose.Slides أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل قد تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث حسب نظام التشغيل، لذا قد يكون خط متاح على جهاز ما ويحتاج إلى استبدال على جهاز آخر.

**كيف يمكن جعل اختيار الخط موحدًا في التحويلات الجماعية؟**

استخدم نفس ملفات الخط وإصداراتها على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/python-net/custom-font/)، و[ضمّن الخطوط](/slides/ar/python-net/embedded-font/) عندما تسمح الرخص. يمكنك أيضًا استدعاء [FontsManager.get_substitutions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_substitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.