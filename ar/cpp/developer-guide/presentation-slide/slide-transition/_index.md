---
title: انتقال الشريحة
type: docs
weight: 80
url: /cpp/slide-transition/
keywords: "انتقال شريحة PowerPoint، انتقال التحول"
description: "انتقال شريحة PowerPoint، انتقال التحول PowerPoint مع Aspose.Slides."
---

## **إضافة انتقال الشريحة**
لتسهيل الفهم، قمنا بعرض استخدام Aspose.Slides لـ C++ لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين تطبيق تأثيرات انتقال شريحة مختلفة على الشرائح، ولكن يمكنهم أيضًا تخصيص سلوك هذه التأثيرات الانتقالية. لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides لـ C++ من خلال TransitionType enum.
1. كتابة ملف العرض المعدل.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **إضافة انتقال شريحة متقدم**
في القسم أعلاه، قمنا فقط بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل ذلك التأثير الانتقالي البسيط أفضل وأكثر تحكمًا، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides لـ C++
1. يمكنك أيضًا تعيين الانتقال ليتم التقدم عند النقر، بعد فترة زمنية معينة أو كليهما.
1. إذا كان انتقال الشريحة مفعلًا ليتم التقدم عند النقر، فإن الانتقال سوف يتقدم فقط عندما ينقر شخص ما على الفأرة. علاوة على ذلك، إذا تم تعيين خاصية التقدم بعد وقت، سيتقدم الانتقال تلقائيًا بعد انقضاء الوقت المحدد للتقدم.
1. كتابة العرض المعدل كملف عرض.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **انتقال التحول**
Aspose.Slides لـ C++ يدعم الآن انتقال التحول. يمثل انتقال التحول الجديد الذي تم تقديمه في PowerPoint 2019. يسمح انتقال التحول لك بتحريك سلاسة من شريحة إلى أخرى. يصف هذا المقال الفكرة وكيفية استخدام انتقال التحول. لاستخدام انتقال التحول بفعالية، ستحتاج إلى وجود شريحتين على الأقل مع وجود عنصر واحد مشترك. أسرع طريقة هي نسخ الشريحة ثم نقل العنصر على الشريحة الثانية إلى مكان مختلف.

توضح الكودات التالية كيفية إضافة نسخة من الشريحة مع بعض النص إلى العرض وتعيين انتقال من نوع التحول للشريحة الثانية.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **نوع انتقال التحول**
تم إضافة enum جديد Aspose.Slides.SlideShow.TransitionMorphType. يمثل أنواعًا مختلفة من انتقال الشريحة بتحول.

يحتوي enum TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال التحول مع اعتبار الأشكال كأشياء غير قابلة للتجزئة.
- ByWord: سيتم تنفيذ انتقال التحول مع نقل النص بكلمات حيثما كان ذلك ممكنًا.
- ByChar: سيتم تنفيذ انتقال التحول مع نقل النص بحروف حيثما كان ذلك ممكنًا.

توضح الكودات التالية كيفية تعيين انتقال التحول للشريحة وتغيير نوع التحول:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **تعيين تأثيرات الانتقال**
Aspose.Slides لـ C++ يدعم تعيين تأثيرات الانتقال مثل: من الأسود، من اليسار، من اليمين، إلخ. من أجل تعيين تأثير الانتقال. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation.
- الحصول على مرجع من الشريحة.
- تعيين تأثير الانتقال.
- كتابة العرض كملف PPTX.

في المثال المقدم أدناه، قمنا بتعيين تأثيرات الانتقال.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}