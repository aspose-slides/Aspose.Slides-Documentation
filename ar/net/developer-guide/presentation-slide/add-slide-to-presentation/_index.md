---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /net/add-slide-to-presentation/
keywords: "إضافة شريحة إلى العرض التقديمي, C#, Csharp, .NET, Aspose.Slides"
description: "إضافة شريحة إلى العرض التقديمي في C# أو .NET"
---

## **إضافة شريحة إلى العرض التقديمي**
قبل الحديث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعونا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي بـ PowerPoint على شريحة واحدة رئيسية / تخطيط وشرائح عادية أخرى. وهذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التقديمي بدون شرائح غير مدعومة من قبل Aspose.Slides لـ .NET. تحتوي كل شريحة على معرف فريد ويتم ترتيب جميع الشرائح العادية وفقًا لترتيب محدد بواسطة الفهرس المعتمد على الصفر. يسمح Aspose.Slides لـ .NET للمطورين بإضافة شرائح فارغة إلى عروضهم التقديمية. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- إنشاء مثيل من [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) class عن طريق تعيين مرجع إلى خاصية الشرائح (مجموعة كائنات شريحة المحتوى) المعروضة من قبل كائن العرض التقديمي.
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة الشرائح المحتوية من خلال استدعاء طرق AddEmptySlide المعروضة من قبل كائن ISlideCollection.
- القيام ببعض العمل مع الشريحة الفارغة التي تم إضافتها حديثًا.
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}