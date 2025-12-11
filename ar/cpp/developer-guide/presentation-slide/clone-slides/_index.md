---
title: استنساخ شرائح العرض التقديمي في C++
linktitle: استنساخ الشرائح
type: docs
weight: 40
url: /ar/cpp/clone-slides/
keywords:
- استنساخ شريحة
- نسخ الشريحة
- حفظ الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "انسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides للغة C++. اتبع أمثلة الشيفرة الواضحة لتوليد عروض PPT في ثوانٍ وإزالة العمل اليدوي."
---

## **استنساخ الشرائح في عرض تقديمي**
الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة مُماثلة لشيء ما. يتيح Aspose.Slides للغة C++ إمكانية إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض التقديمي الحالي أو أي عرض آخر مفتوح. عملية استنساخ الشريحة تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق محتملة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides للغة C++، (مجموعة من [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) الكائنات) التي يُعرِّفها كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) توفر طريقتي [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) و[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) لأداء الأنواع المذكورة أعلاه من استنساخ الشرائح.

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الحالية، استخدم طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) وفقًا للخطوات المذكورة أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. إنشاء كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) بالإشارة إلى مجموعة الشرائح التي يُعرِّفها كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) المعرّفة على كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) وتمرير الشريحة التي سيتم استنساخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) .
1. كتابة ملف العرض التقديمي المُعدَّل.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **استنساخ شريحة في موضع آخر داخل عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) :

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. إنشاء كائن بالإشارة إلى مجموعة **Slides** المعرّفة على كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) المعرّفة على كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) وتمرير الشريحة المستنسخة مع الفهرس للموضع الجديد كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) .
1. كتابة العرض التقديمي المُعدَّل كملف PPTX.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **استنساخ شريحة في نهاية عرض تقديمي آخر**
إذا كنت تحتاج إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في نهاية الشرائح الحالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة التي ستُضاف إليها الشريحة.
1. إنشاء كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) بالإشارة إلى مجموعة **Slides** المعرّفة على كائن Presentation في العرض التقديمي الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) المعرّفة على كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) وتمرير الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) .
1. كتابة ملف العرض التقديمي الوجهة المُعدَّل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس الأول من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **استنساخ شريحة في موضع آخر في عرض تقديمي آخر**
إذا كنت تحتاج إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في موضع محدد:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تحتوي على العرض التقديمي المصدر.
1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة.
1. إنشاء كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) بالإشارة إلى مجموعة Slides المعرّفة على كائن Presentation في العرض التقديمي الوجهة.
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) المعرّفة على كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) وتمرير الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) .
1. كتابة ملف العرض التقديمي الوجهة المُعدَّل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس صفر في العرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) في العرض التقديمي الوجهة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **استنساخ شريحة في موضع محدد في عرض تقديمي آخر**
إذا كنت تحتاج إلى استنساخ شريحة مع شريحة أساسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الأساسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة. ثم تحتاج إلى استخدام تلك الشريحة الأساسية لاستنساخ الشريحة مع الشريحة الأساسية. طريقة **AddClone(ISlide, IMasterSlide)** تتوقع شريحة أساسية من العرض التقديمي الوجهة وليس من العرض المصدر. لاستنساخ الشريحة مع الشريحة الأساسية، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تحتوي على العرض التقديمي المصدر.
1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة.
1. الوصول إلى الشريحة التي سيتم استنساخها مع الشريحة الأساسية.
1. إنشاء كائن [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) بالإشارة إلى مجموعة Masters المعرّفة على كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) في العرض التقديمي الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) المعرّفة على كائن [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) وتمرير الشريحة الأساسية من ملف PPTX المصدر لتُستنسخ كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) .
1. إنشاء كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) بإعداد الإشارة إلى مجموعة Slides المعرّفة على كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) في العرض التقديمي الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) المعرّفة على كائن [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) وتمرير الشريحة من العرض المصدر لتُستنسخ مع الشريحة الأساسية كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) .
1. كتابة ملف العرض التقديمي الوجهة المُعدَّل.

في المثال أدناه، قمنا باستنساخ شريحة مع شريحة أساسية (تقع في الفهرس صفر من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام الشريحة الأساسية من الشريحة المصدر.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **استنساخ شريحة في نهاية قسم محدد**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في قسم مختلف، استخدم طريقة [**AddClone()**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) المعرّفة على واجهة [**ISlideCollection**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) . يتيح Aspose.Slides للغة C++ إمكانية استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

يظهر المقتطف البرمجي التالي كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **الأسئلة الشائعة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في الاستنساخ. إذا لم ترغب بها، يمكنك [إزالتها](/slides/ar/cpp/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر البيانات الخاصة بها؟**

يتم نسخ كائن المخطط، وتنسيقه، والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مضمّن)، فإن الربط يُحافظ عليه كـ[كائن OLE](/slides/ar/cpp/manage-ole/). بعد النقل بين الملفات، تحقق من توافر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للاستنساخ؟**

نعم. يمكنك إدراج الاستنساخ في فهرس شريحة محدد ووضعه في [قسم](/slides/ar/cpp/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.