---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /ar/net/add-slide-to-presentation/
keywords: "إضافة شريحة إلى العرض التقديمي, C#, Csharp, .NET, Aspose.Slides"
description: "إضافة شريحة إلى العرض التقديمي في C# أو .NET"
---

## **إضافة شريحة إلى العرض التقديمي**
قبل التطرق إلى إضافة الشرائح إلى ملفات العرض التقديمي، دعونا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي PowerPoint على شريحة Master / Layout وشريحة Normal أخرى. يعني ذلك أن ملف العرض التقديمي يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التقديمي بدون شرائح غير مدعومة من قبل Aspose.Slides for .NET. لكل شريحة معرف فريد وتُرتب جميع الشرائح Normal وفقًا لترتيب يُحدده الفهرس القائم على الصفر. يسمح Aspose.Slides for .NET للمطورين بإضافة شرائح فارغة إلى العرض التقديمي الخاص بهم. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
- إنشاء فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق ضبط مرجع إلى خاصية Slides (مجموعة كائنات Slide المحتوى) المعروضة من قبل كائن Presentation .
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة الشرائح المحتوى عن طريق استدعاء أساليب AddEmptySlide المعروضة من قبل كائن ISlideCollection .
- القيام ببعض الأعمال مع الشريحة الفارغة التي تم إضافتها حديثًا .
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **الأسئلة المتكررة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertclone/) ، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من الإضافة فقط في النهاية.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. يرث التخطيط التنسيق من الـ master الخاص به، وتُرث الشريحة الجديدة من التخطيط المحدد والـ master المرتبط به.

**أي شريحة تكون موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي الذي تم إنشاؤه حديثًا يحتوي بالفعل على شريحة فارغة واحدة ذات فهرس صفر. من المهم أخذ ذلك في الاعتبار عند حساب فهارس الإدراج.

**كيف أختار التخطيط "الصحيح" لشريحة جديدة إذا كان الـ master يحتوي على العديد من الخيارات؟**

عموماً اختر [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) الذي يتوافق مع الهيكل المطلوب ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [add it to the master](/slides/ar/net/slide-layout/) ثم استخدامه.