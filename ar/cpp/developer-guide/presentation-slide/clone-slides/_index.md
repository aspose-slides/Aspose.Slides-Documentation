---
title: استنساخ شرائح العرض التقديمي في C++
linktitle: استنساخ الشرائح
type: docs
weight: 40
url: /ar/cpp/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بنسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides for C++. اتبع أمثلة التعليمات البرمجية الواضحة الخاصة بنا لأتمتة إنشاء ملفات PPT في ثوانٍ وإلغاء العمل اليدوي."
---
## **المقدمة**

التنسخ هو عملية إنشاء نسخة مطابقة أو نسخة متماثلة من شيء ما. تتيح Aspose.Slides for C++ أيضًا إمكانية إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. عملية استنساخ الشريحة تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for C++، (مجموعة من [ISlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/) الكائنات) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) يوفر طريقتي [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) و [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/insertclone/) للقيام بأنواع استنساخ الشرائح المذكورة أعلاه.

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) وفقًا للخطوات المذكورة أدناه:

1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. أنشئ مثيلاً لكائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) عن طريق الإشارة إلى مجموعة Slides المُعرَضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) المُعرَضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) ومرّر الشريحة التي تريد استنساخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) .
1. احفظ ملف العرض التقديمي المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **استنساخ شريحة إلى موضع آخر داخل عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/insertclone/) :

1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. أنشئ مثيلاً للصف عبر الإشارة إلى مجموعة **Slides** المُعرَضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. استدعِ طريقة [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/insertclone/) المُعرَضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) ومرّر الشريحة التي تريد استنساخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/insertclone/) .
1. احفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **استنساخ شريحة في نهاية عرض تقديمي آخر**
إذا احتجت إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) الذي يحتوي على العرض التقديمي الذي ستُستنسَخ منه الشريحة.
1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) الذي يحتوي على عرض تقديمي الهدف الذي ستُضاف إليه الشريحة.
1. أنشئ مثيلاً لكائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) عن طريق الإشارة إلى مجموعة **Slides** المُعرَضة بواسطة كائن Presentation للعرض التقديمي الهدف.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) المُعرَضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) ومرّر الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) .
1. احفظ ملف العرض التقديمي الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **استنساخ شريحة إلى موضع آخر في عرض تقديمي آخر**
إذا احتجت إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في عرض تقديمي آخر، في موضع محدد:

1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) الذي يحتوي على العرض التقديمي المصدر.
1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) الذي يحتوي على العرض التقديمي الهدف.
1. أنشئ مثيلاً لكائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) عن طريق الإشارة إلى مجموعة Slides المُعرَضة بواسطة كائن Presentation للعرض التقديمي الهدف.
1. استدعِ طريقة [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/insertclone/) المُعرَضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) ومرّر الشريحة من العرض التقديمي المصدر مع الموضع المرغوب كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/insertclone/) .
1. احفظ ملف العرض التقديمي الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) للعرض التقديمي الهدف.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **استنساخ شريحة في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع الشريحة الرئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الهدف. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. طريقة **AddClone(ISlide, IMasterSlide)** تتوقع الشريحة الرئيسية من العرض الهدف بدلاً من العرض المصدر. لاستنساخ الشريحة مع الشريحة الرئيسية، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) الذي يحتوي على العرض التقديمي المصدر.
1. أنشئ مثيلاً لكائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) الذي يحتوي على العرض التقديمي الهدف.
1. احصل على الشريحة التي سيتم استنساخها مع الشريحة الرئيسية.
1. أنشئ مثيلاً لكائن [IMasterSlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/) عن طريق الإشارة إلى مجموعة Masters المُعرَضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) للعرض الهدف.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) المُعرَضة بواسطة كائن [IMasterSlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslidecollection/) ومرّر الشريحة الرئيسية من ملف PPTX المصدر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) .
1. أنشئ مثيلاً لكائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) عن طريق تعيين المرجعية إلى مجموعة Slides المُعرَضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) للعرض الهدف.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) المُعرَضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/) ومرّر الشريحة من العرض المصدر إلى أن تُستنسَخ مع الشريحة الرئيسية كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) .
1. احفظ ملف العرض التقديمي الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة مع الشريحة الرئيسية (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الهدف باستخدام الشريحة الرئيسية من العرض المصدر.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **استنساخ شريحة في نهاية قسم محدد**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي لكن في قسم مختلف، استخدم طريقة [**AddClone()**](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/addclone/) المُعرَضة بواسطة واجهة [**ISlideCollection**](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidecollection/). يتيح Aspose.Slides for C++ إمكانية استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

المقتطف البرمجي التالي يوضح كيفية استنساخ شريحة وإدراجها في قسم محدد.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **التأكد من توافق حجم الشريحة**

عند استنساخ الشرائح إلى عرض تقديمي آخر، تأكد من أن حجم الشرائح في العرض الهدف يطابق حجم الشرائح في المصدر. إذا اختلف حجم الشرائح، لا يقوم Aspose.Slides بإعادة تحجيم الأشكال المستنسخة تلقائيًا—تبقى إحداثياتها وأبعادها الأصلية، مما قد يؤدي إلى ظهور المحتوى غير محاذٍ أو يمتد خارج حدود الشريحة.

يمكنك ضبط حجم شرائح العرض الهدف ليتطابق مع المصدر قبل استنساخ الشريحة والشريحة الرئيسية:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

قم بذلك قبل استنساخ الشريحة الرئيسية والشريحة.

## **الأسئلة الشائعة**

**هل يتم استنساخ الملاحظات الصوتية وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب فيها، [قم بإزالتها](/slides/ar/cpp/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر البيانات الخاصة بها؟**

يتم نسخ كائن المخطط، تنسيقه، والبيانات المضمّنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مضمّن)، يُحافظ على هذا الارتباط كـ[كائن OLE](/slides/ar/cpp/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة في فهرس شريحة محدد ووضعها في [القسم](/slides/ar/cpp/slide-section/) المختار. إذا لم يكن القسم المستهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.