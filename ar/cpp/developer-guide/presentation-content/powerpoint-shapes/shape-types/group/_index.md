---
title: "أشكال مجموعة العرض التقديمي في C++"
linktitle: "مجموعة الشكل"
type: docs
weight: 40
url: /ar/cpp/group/
keywords:
- "شكل مجموعة"
- "مجموعة الشكل"
- "إضافة مجموعة"
- "نص بديل"
- "PowerPoint"
- "عرض تقديمي"
- "C++"
- "Aspose.Slides"
description: "تعلم كيفية تجميع وفك تجميع الأشكال في مجموعات PowerPoint باستخدام Aspose.Slides لـ C++ — دليل سريع خطوة بخطوة مع كود C++ مجاني."
---

## **إضافة شكل مجموعة**
يدعم Aspose.Slides العمل مع أشكال المجموعة على الشرائح. تساعد هذه الميزة المطورين على إنشاء عروض تقديمية أكثر غنى. يدعم Aspose.Slides للغة C++ إضافة أو الوصول إلى أشكال المجموعة. يمكن إضافة أشكال إلى شكل مجموعة مضاف لملئه أو الوصول إلى أي خاصية من خصائص شكل المجموعة. لإضافة شكل مجموعة إلى شريحة باستخدام Aspose.Slides للغة C++:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. احصل على مرجع الشريحة باستخدام فهرسها
1. أضف شكل مجموعة إلى الشريحة.
1. أضف الأشكال إلى شكل المجموعة المضاف.
1. احفظ العرض التقديمي المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **الوصول إلى خاصية AltText**
يوضح هذا القسم خطوات بسيطة، مع أمثلة شفرة، لإضافة شكل مجموعة والوصول إلى خاصية AltText لأشكال المجموعة على الشرائح. للوصول إلى AltText لشكل مجموعة في شريحة باستخدام Aspose.Slides للغة C++:

1. أنشئ فئة `Presentation` التي تمثل ملف PPTX.
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة الأشكال للشرائح.
1. الوصول إلى شكل المجموعة.
1. الوصول إلى خاصية AltText.

المثال أدناه يصل إلى النص البديل لشكل المجموعة.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **الأسئلة الشائعة**

**هل يتم دعم التجميع المتداخل (مجموعة داخل مجموعة)؟**

نعم. يحتوي [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/) على طريقة [get_ParentGroup](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_parentgroup/) التي تشير مباشرة إلى دعم التسلسل الهرمي (يمكن أن تكون مجموعة طفلاً لمجموعة أخرى).

**كيف يمكنني التحكم في ترتيب z للمجموعة بالنسبة للكائنات الأخرى على الشريحة؟**

استخدم [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/)’s [Z-Order position](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_zorderposition/) لفحص موقعه في مكدس العرض.

**هل يمكنني منع التحريك/التعديل/إلغاء التجميع؟**

نعم. يتم كشف قسم القفل للمجموعة عبر [get_GroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/get_groupshapelock/)، مما يتيح لك تقييد العمليات على الكائن.