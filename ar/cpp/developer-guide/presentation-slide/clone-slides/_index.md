---
title: نسخ الشرائح
type: docs
weight: 40
url: /ar/cpp/clone-slides/
---


## **نسخ الشريحة في العرض التقديمي**
النسخ هو عملية صنع نسخة أو نموذج مطابق لشيء ما. كما أن Aspose.Slides لـ C++ يجعل من الممكن عمل نسخة أو نسخ من أي شريحة ثم إدخال تلك الشريحة المنسوخة إلى العرض التقديمي الحالي أو أي عرض مفتوح آخر. عملية نسخ الشرائح تنشئ شريحة جديدة يمكن تعديلها بواسطة المطورين دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لنسخ شريحة:

- النسخ في النهاية داخل عرض تقديمي.
- النسخ في موضع آخر داخل العرض التقديمي.
- النسخ في النهاية في عرض تقديمي آخر.
- النسخ في موضع آخر في عرض تقديمي آخر.
- النسخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides لـ C++، (مجموعة من [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) الأشياء) المكشوفة بواسطة الكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) توفر طرق [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) و [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) لأداء أنواع النسخ المذكورة أعلاه.

## **النسخ في النهاية داخل العرض التقديمي**
إذا كنت تريد نسخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) حسب الخطوات المذكورة أدناه:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعِ فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة الشرائح المعروضة بواسطة الكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرر الشريحة المراد نسخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. اكتب ملف العرض التقديمي المعدل.

في المثال المذكور أدناه، قمنا بنسخ شريحة (تقع في الموضع الأول – فهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **النسخ في موضع آخر داخل العرض التقديمي**
إذا كنت تريد نسخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index):

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعِ الفئة بالإشارة إلى مجموعة **Slides** المكشوفة بواسطة الكائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعِ طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمِرِّر الشريحة المراد نسخها جنبًا إلى جنب مع الفهرس للموضع الجديد كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index).
1. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بنسخ شريحة (تقع في فهرس صفر – موضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **نسخ الشريحة إلى النهاية في عرض تقديمي آخر**
إذا كنت بحاجة إلى نسخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض التقديمي الذي سيتم نسخ الشريحة منه.
1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض التقديمي الوجهة الذي ستضاف إليه الشريحة.
1. استدعِ فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة **Slides** المكشوفة بواسطة كائن presentation من العرض التقديمي الوجهة.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمِرِّر الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. اكتب ملف العرض التقديمي المعدل الوجهة.

في المثال المذكور أدناه، قمنا بنسخ شريحة (من الفهرس الأول من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **نسخ شريحة إلى موضع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى نسخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في موضع محدد:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض التقديمي المصدر الذي سيتم نسخ الشريحة منه.
1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض التقديمي الذي ستضاف إليه الشريحة.
1. استدعِ فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة الشرائح المكشوفة بواسطة كائن presentation من العرض التقديمي الوجهة.
1. استدعِ طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمِرِّر الشريحة من العرض التقديمي المصدر جنبًا إلى جنب مع الموضع المرغوب كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index).
1. اكتب ملف العرض التقديمي المعدل الوجهة.

في المثال المذكور أدناه، قمنا بنسخ شريحة (من الفهرس صفر من العرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) من العرض التقديمي الوجهة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **نسخ الشريحة في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى نسخ شريحة مع الشريحة الرئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، تحتاج إلى نسخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة أولاً. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لنسخ الشريحة مع الشريحة الرئيسية. يتوقع **AddClone(ISlide, IMasterSlide)** أن تكون الشريحة الرئيسية من العرض التقديمي الوجهة بدلاً من العرض التقديمي المصدر. لنسخ الشريحة مع الرئيسية، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض التقديمي المصدر الذي سيتم نسخ الشريحة منه.
1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض التقديمي الوجهة التي سيتم نسخ الشريحة إليها.
1. الوصول إلى الشريحة المراد نسخها جنبًا إلى جنب مع الشريحة الرئيسية.
1. استدعِ فئة [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) عن طريق الإشارة إلى مجموعة الماستر المكشوفة بواسطة كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) من العرض التقديمي الوجهة.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) المكشوفة بواسطة كائن [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) وتمِرِّر الرئيسية من الـ PPTX المصدر المراد نسخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. استدعِ فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق تعيين المرجع إلى مجموعة الشرائح المعروضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) من العرض التقديمي الوجهة.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمِرِّر الشريحة من العرض التقديمي المصدر المراد نسخها والشريحة الرئيسية كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. اكتب ملف العرض التقديمي المعدل الوجهة.

في المثال المذكور أدناه، قمنا بنسخ شريحة مع الرئيسية (تقع في الفهرس صفر من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام الرئيسية من الشريحة المصدر.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **نسخ الشريحة إلى قسم محدد**
إذا كنت تريد نسخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في قسم مختلف، فاستخدم طريقة [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b) المكشوفة بواسطة واجهة [**ISlideCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection). يجعل Aspose.Slides لـ C++ من الممكن نسخ شريحة من القسم الأول ثم إدخال تلك الشريحة المنسوخة إلى القسم الثاني من نفس العرض التقديمي.

يوضح مقتطف الشيفرة التالي كيف يمكنك نسخ شريحة وإدخال الشريحة المنسوخة في قسم محدد.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}