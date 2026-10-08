---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام بايثون
linktitle: استبدال الخطوط
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
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لبايثون عبر .NET عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

تتيح استبدال الخطوط (Font substitution) لـ Aspose.Slides استعمال خط متاح بدلاً من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغير الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على اتساق المخرجات عبر بيئات مختلفة ذات خطوط مثبتة مختلفة.

إذا كان الخط متوفرًا لكنه لا يحتوي على نمط غامق مخصص، راجع [معالجة الخطوط التي لا تحتوي على نوع غامق مخصص](/slides/ar/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يشرح ذلك كيفية تحويل النص المتأثر إلى صورة أثناء تصدير PDF والعواقب على اختيار النص والبحث والتكبير.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) لتحديد الخطوط التي سيتم استبدالها عندما يُعرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والبديل.

المثال التالي بلغة Python يسرد جميع استبدالات الخطوط لعروض تقديمية:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **الحصول على استبدالات الخطوط للشرائح المحددة**

استخدم [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) مع قائمة من فهارس الشرائح لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. هذا مفيد عندما تقوم بعرض أو تصدير جزء من العرض، أو فحص عرض كبير بصورة متدرجة، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط حد أدنى للخادم أو الحاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

تحتوي القائمة على فهارس شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، مجموعة [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) صفرية الفهرس، لذا تُ accessed نفس الشريحة كـ `presentation.slides[0]`. احرص على مراعاة هذا الاختلاف عند بناء القائمة لتجنب أخطاء الإزاحة.

استدعِ الطريقة عبر خاصية [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). تُعيد فقط الاستبدالات المحددة أثناء عرض الشرائح المختارة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والبديل. تعكس النتيجة بيئة الخط الحالية، وقواعد الاستfallback المكوَّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/)، و[الخطوط المحمّلة خارجيًا](/slides/ar/python-net/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة مختارة. احذف التكرارات عند إنشاء جرد خطوط أو تقرير فحص مسبق. المثال التالي يورد كل استبدال تم إرجاعه ثم يُنشئ قائمة مرتبة من تعيينات الخطوط الفريدة:

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

توفر فئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) كلتا الصيغتين للطريقة. اختر واحدة وفق نطاق عملية العرض:

| استدعاء الطريقة | استخدمه عندما |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) بدون معلمات | تحتاج إلى استبدالات للعرض التقديمي بأكمله. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) مع قائمة فهارس الشرائح | تحتاج إلى استبدالات لنطاق مختار، فحص متدرج، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط الأصلي غير متوفر:

1. حمّل العرض التقديمي.  
2. أنشئ تعريفات للخط الأصلي والبديل.  
3. أنشئ [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) باستخدام الشرط [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).  
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).  
5. عيّن المجموعة إلى خاصية [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. اعرض أو حول العرض التقديمي.

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
لتغيير غير مشروط للخطوط المستخدمة عبر العرض بأكمله، راجع [استبدال الخطوط](/slides/ar/python-net/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل للكتابة العادية عندما يستطيع Aspose.Slides استبدال خط غير قابل للوصول بالخط المتاح المحدد في القاعدة.

معادلات Office Math لها متطلب إضافي. إذا استخدمت المعادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر مثل **STIX Two Math** أن تحل محل **Cambria Math** لهذا الغرض، وقد يظل العرض يُبلغ أن **Cambria Math** مطلوب.

للعرض أو التحويل لمثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. ثبّته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/python-net/custom-font/).

تنطبق هذه القيد على تخطيط المعادلات. لا يزال بإمكان قواعد الاستبدال المذكورة أعلاه العمل على النص العادي في العرض التقديمي.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**  
[استبدال الخطوط](/slides/ar/python-net/font-replacement/) يغيّر خطًا إلى آخر في جميع أنحاء العرض بشكل متعمد. استبدال الخط يختار خطًا للمخرجات المعروضة عندما يتحقق الشرط المُكوَّن، مثل عدم توفر الخط الأصلي.

**متى يتم تطبيق قواعد الاستبدال؟**  
تشارك القواعد في [تسلسل اختيار الخط](/slides/ar/python-net/font-selection-sequence/) أثناء العرض والتحويل. مع `WHEN_INACCESSIBLE`، تُستَخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط الأصلي.

**ماذا يحدث إذا كان الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**  
يختار Aspose.Slides أقرب خط متاح وفق عملية اختيار الخط الخاصة به. النتيجة تعتمد على الخطوط المتوفرة في بيئة وقت التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/python-net/custom-font/) بحيث يستخدمها Aspose.Slides أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**  
لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**  
نعم. تختلف الخطوط المثبتة ومواقع بحث الخط حسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكن جعل اختيار الخط متسقًا في التحويلات الدفعية؟**  
استخدم نفس ملفات الخط وإصداراته على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/python-net/custom-font/)، و[ضمّ الخطوط](/slides/ar/python-net/embedded-font/) عندما تسمح التراخيص. يمكنك أيضًا استدعاء [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.