---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /ar/androidjava/add-slide-to-presentation/
---

## **إضافة شريحة إلى العرض التقديمي**
{{% alert color="primary" %}} 

قبل الحديث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعنا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي من PowerPoint على شريحة **ماستر / تخطيط** وشرائح **عادية** أخرى. وهذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التقديمي بدون شرائح غير مدعومة من قبل Aspose.Slides لنظام Android عبر Java. تحتوي كل شريحة على معرف فريد وجميع الشرائح العادية مرتبة وفقًا للتسلسل المحدد بواسطة الفهرس الذي يبدأ من الصفر.

{{% /alert %}} 

يسمح Aspose.Slides لنظام Android عبر Java للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة إلى العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- إنشاء مثيل من فئة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) عن طريق تعيين مرجع إلى خاصية [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (مجموعة من كائنات الشرائح المحتوى) المعروضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة الشرائح المحتوى عن طريق استدعاء طرق [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) المعروضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- القيام ببعض العمل مع الشريحة الفارغة الجديدة المضافة.
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).

```java
// إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // إنشاء مثيل لفئة SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // إضافة شريحة فارغة إلى مجموعة الشرائح
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // القيام ببعض العمل على الشريحة المضافة حديثًا

    // حفظ ملف PPTX على القرص
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```