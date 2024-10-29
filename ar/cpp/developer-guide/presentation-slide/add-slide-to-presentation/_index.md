---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /ar/cpp/add-slide-to-presentation/
---

## **إضافة شريحة إلى العرض التقديمي**
قبل الحديث عن إضافة شرائح إلى ملفات العرض التقديمي، دعونا نتحدث عن بعض الحقائق حول الشرائح. تحتوي كل ملف عرض تقديمي من PowerPoint على شريحة رئيسية / تخطيط وشرائح عادية أخرى. وهذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة أو أكثر على الأقل. من المهم أن نعرف أن ملفات العرض التقديمي التي لا تحتوي على شرائح غير مدعومة من Aspose.Slides لـ C++. كل شريحة لها معرف فريد وجميع الشرائح العادية مرتبة وفقًا لترتيب محدد بواسطة الفهرس المعتمد على الصفر. تسمح Aspose.Slides لـ C++ للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) درجة.
- انشاء مثيل من [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق تعيين مرجع إلى خاصية الشرائح (مجموعة من كائنات شريحة المحتوى) المعروضة من قبل كائن العرض التقديمي.
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة شرائح المحتوى عن طريق استدعاء طرق AddEmptySlide المعروضة من قبل كائن ISlideCollection.
- القيام ببعض الأعمال مع الشريحة الفارغة المضافة حديثًا.
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}