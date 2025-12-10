---
title: إضافة شرائح إلى العروض التقديمية في .NET
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/net/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أضف الشرائح بسهولة إلى عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides for .NET—إدراج شرائح سلس وفعال في ثوانٍ."
---

## **إضافة شريحة إلى عرض تقديمي**
قبل الحديث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعونا نناقش بعض الحقائق حول الشرائح. كل ملف عرض تقديمي PowerPoint يحتوي على شريحة Master / Layout وشريحات عادية أخرى. هذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التقديمي بدون شرائح غير مدعومة بواسطة Aspose.Slides for .NET. لكل شريحة معرف فريد وتتم ترتيب جميع الشرائح العادية بترتيب محدد بواسطة الفهرس الصفري. يسمح Aspose.Slides for .NET للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- إنشاء مثيل للفئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق تعيين مرجع إلى الخاصية Slides (مجموعة كائنات Slide المحتوى) التي تعرضها كائن Presentation .
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة الشرائح المحتوى عبر استدعاء طريقة AddEmptySlide المعروضة من قبل كائن ISlideCollection .
- قم بأداء بعض الأعمال على الشريحة الفارغة التي تم إضافتها حديثًا .
- أخيرًا، احفظ ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **الأسئلة المتكررة**

**هل يمكنني إدراج شريحة جديدة في موقع محدد، وليس فقط في النهاية؟**
نعم. تدعم المكتبة مجموعات الشرائح وعمليتي [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/) ، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من النهاية فقط.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**
نعم. يرث التخطيط التنسيق من الـ master الخاص به، وتورث الشريحة الجديدة من التخطيط المختار والـ master المرتبط به.

**أي شريحة توجد في عرض تقديمي جديد "فارغ" قبل إضافة الشرائح؟**
يحتوي العرض التقديمي الذي تم إنشاؤه حديثًا بالفعل على شريحة فارغة واحدة ذات فهرس صفر. من المهم مراعاة ذلك عند حساب مؤشرات الإدراج.

**كيف يمكنني اختيار التخطيط "الصحيح" لشريحة جديدة إذا كان الـ master يحتوي على خيارات عديدة؟**
عمومًا اختر الـ [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) الذي يطابق البنية المطلوبة ([Title and Content, Two Content, إلخ](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [إضافته إلى الـ master](/slides/ar/net/slide-layout/) ثم استخدامه.