---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /java/add-slide-to-presentation/
---

## **إضافة شريحة إلى العرض التقديمي**
{{% alert color="primary" %}} 

قبل الحديث عن إضافة شرائح إلى ملفات العرض التقديمي، دعونا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي في PowerPoint على شريحة **ماستر / تخطيط** وشرائح **عادية** أخرى. وهذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة أو أكثر على الأقل. من المهم معرفة أن ملفات العرض التقديمي بدون شرائح غير مدعومة من قبل Aspose.Slides لـ Java. كل شريحة لها معرف فريد، وجميع الشرائح العادية مرتبة وفقًا لترتيب محدد بواسطة الفهرس ذو الأساس صفر.

{{% /alert %}} 

تسمح Aspose.Slides لـ Java للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- قم بإنشاء مثيل من فئة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) عن طريق تعيين مرجع إلى خاصية [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) (مجموعة من كائنات شريحة المحتوى) المعرضة من قبل كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة شرائح المحتوى عن طريق استدعاء الطرق [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) المعرضة من قبل كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection).
- قم ببعض العمل مع الشريحة الفارغة المضافة حديثًا.
- أخيرًا، قم بكتابة ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).

```java
// انشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // انشاء مثيل لفئة SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // إضافة شريحة فارغة إلى مجموعة الشرائح
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // قم بعمل بعض العمل على الشريحة المضافة حديثًا

    // حفظ ملف PPTX إلى القرص
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```