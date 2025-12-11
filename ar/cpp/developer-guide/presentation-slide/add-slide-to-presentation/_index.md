---
title: إضافة شرائح إلى العروض التقديمية بلغة C++
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/cpp/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "يمكنك بسهولة إضافة شرائح إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ C++ — إدراج شرائح سلس وفعّال في ثوانٍ."
---

## **إضافة شريحة إلى عرض تقديمي**
قبل التحدث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعونا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي PowerPoint على شريحة Master / Layout وشريحة Normal أخرى. هذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العروض التقديمية بدون شرائح غير مدعومة من قبل Aspose.Slides for C++. كل شريحة لها معرف فريد وتُرتب جميع الشرائح Normal وفقًا لترتيب يحدده الفهرس الصفري القائم. يسمح Aspose.Slides for C++ للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- إنشاء مثيل من فئة[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) عن طريق تعيين مرجع إلى خاصية Slides (مجموعة كائنات Slide المحتوى) المعروضة بواسطة كائن Presentation.
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة الشرائح المحتوى عن طريق استدعاء طريقة AddEmptySlide المعروضة بواسطة كائن ISlideCollection.
- القيام ببعض العمل مع الشريحة الفارغة التي تمت إضافتها حديثًا.
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات[insert](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/insertclone/) ، وبالتالي يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من النهاية فقط.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. يرث التخطيط التنسيق من الـ master الخاص به، وتورّث الشريحة الجديدة من التخطيط المختار والـ master المرتبط به.

**أي شريحة تكون موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي الذي تم إنشاؤه حديثًا يحتوي بالفعل على شريحة فارغة واحدة ذات فهرس صفر. هذا أمر مهم عند حساب فهارس الإدراج.

**كيف أختار "التخطيط" المناسب لشريحة جديدة إذا كان الـ master يحتوي على خيارات متعددة؟**

عمومًا اختر[LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) الذي يتطابق مع الهيكل المطلوب ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cpp/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك[add it to the master](/slides/ar/cpp/slide-layout/) ثم استخدامه.