---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام C++
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/cpp/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال الشريحة المتقدم
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides for C++، مع إرشادات خطوة بخطوة لعروض PowerPoint وOpenDocument."
---

## **إضافة انتقال الشريحة**
لتسهيل الفهم، قمنا بتوضيح كيفية استخدام Aspose.Slides for C++ لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال مختلفة على الشرائح، بل أيضًا تخصيص سلوك هذه التأثيرات. لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال المتوفرة في Aspose.Slides for C++ عبر تعداد TransitionType.
3. كتابة ملف العرض التقديمي المعدّل.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **إضافة انتقال شريحة متقدم**
في القسم السابق، قمنا بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير البسيط أكثر تحكمًا وتحسينًا، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال المتوفرة في Aspose.Slides for C++
3. يمكنك أيضًا ضبط الانتقال على التقدم عند النقر، بعد فترة زمنية محددة أو كليهما.
4. إذا تم تمكين انتقال الشريحة للتقدم عند النقر، سيتقدم الانتقال فقط عند النقر بالماوس. علاوة على ذلك، إذا تم ضبط خاصية التقدم بعد الوقت، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
5. كتابة العرض التقديمي المعدّل كملف عرض تقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **انتقال Morph**
يدعم Aspose.Slides for C++ الآن انتقال Morph. وهو يمثل انتقال Morph الجديد المقدم في PowerPoint 2019. يتيح انتقال Morph تحريكًا سلسًا من شريحة إلى أخرى. يصف هذا المقال المفهوم وكيفية استخدام انتقال Morph. لاستخدام انتقال Morph بفعالية، ستحتاج إلى شريحتين على الأقل تشتركان في كائن واحد. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى مكان مختلف.

القطعة البرمجية التالية توضح كيفية إضافة نسخة من الشريحة تحتوي على نص إلى العرض وضبط انتقال من نوع morph إلى الشريحة الثانية.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **أنواع انتقال Morph**
تم إضافة تعداد جديد Aspose.Slides.SlideShow.TransitionMorphType. وهو يمثل أنواعًا مختلفة من انتقال شريحة Morph.

يحتوي تعداد TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتقسيم.
- ByWord: سيتم تنفيذ انتقال Morph بنقل النص كلمة بكلمة حيثما أمكن.
- ByChar: سيتم تنفيذ انتقال Morph بنقل النص حرفًا بحرف حيثما أمكن.

القطعة البرمجية التالية توضح كيفية ضبط انتقال Morph على الشريحة وتغيير نوع Morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **ضبط تأثيرات الانتقال**
يدعم Aspose.Slides for C++ ضبط تأثيرات الانتقال مثل من السّوداء، من اليسار، من اليمين وغيرها. لضبط تأثير الانتقال، يرجى اتباع الخطوات التالية:

- إنشاء مثال من فئة Presentation.
- الحصول على مرجع الشريحة.
- ضبط تأثير الانتقال.
- كتابة العرض كملف PPTX.

في المثال أدناه، قمنا بضبط تأثيرات الانتقال.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. اضبط [سرعة](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) الانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (مثلاً، بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت والتكرار (مثلاً، [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/)، [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/)، [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/)، بالإضافة إلى بيانات وصفية مثل [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) و [set_SoundName](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**ما أسرع طريقة لتطبيق نفس الانتقال على كل الشريحة؟**

قم بتكوين نوع الانتقال المطلوب في إعدادات الانتقال لكل شريحة؛ يتم تخزين الانتقالات لكل شريحة، لذا تطبيق نفس النوع على جميع الشرائح يعطي نتيجة متسقة.

**كيف يمكنني التحقق من الانتقال الحالي المطبق على شريحة؟**

تحقق من [إعدادات الانتقال](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_slideshowtransition/) الخاصة بالشريحة واقرأ [نوع الانتقال](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); القيمة ستخبرك بالتحديد أي تأثير تم تطبيقه.