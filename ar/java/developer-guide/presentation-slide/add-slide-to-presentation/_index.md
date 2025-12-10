---
title: إضافة شرائح إلى العروض التقديمية في Java
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/java/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "أضف الشرائح بسهولة إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java — إدراج شرائح سلس وفعّال في ثوانٍ."
---

## **إضافة شريحة إلى عرض تقديمي**
{{% alert color="primary" %}} 

قبل التحدث عن إضافة شرائح إلى ملفات العروض التقديمية، دعنا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي PowerPoint على شريحة **Master / Layout** وشريحة **Normal** أخرى. هذا يعني أن ملف العرض يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العروض التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides for Java. كل شريحة لها معرّف فريد وجميع الشرائح العادية مرتبة وفق الترتيب المحدد بواسطة الفهرس الصفري.

{{% /alert %}} 

Aspose.Slides for Java يسمح للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة في العرض، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
- إنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) عن طريق تعيين مرجع إلى خاصية [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) (مجموعة من كائنات الشرائح المحتوى) المعروضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
- إضافة شريحة فارغة إلى العرض في نهاية مجموعة الشرائح المحتوى باستدعاء طريقة [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) المعروضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) .
- القيام ببعض العمليات مع الشريحة الفارغة التي تم إضافتها حديثًا.
- أخيرًا، كتابة ملف العرض باستخدام كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
```java
// إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // إنشاء فئة SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // إضافة شريحة فارغة إلى مجموعة Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // إجراء بعض العمليات على الشريحة التي تمت إضافتها حديثًا

    // حفظ ملف PPTX إلى القرص
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إدراج شريحة جديدة في موضع معين، وليس فقط في النهاية؟**

نعم. المكتبة تدعم مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)، لذلك يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من الإضافة فقط في النهاية.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. التخطيط يرث التنسيق من القالب الرئيسي، والشريحة الجديدة ترث من التخطيط المختار والقالب الرئيسي المتعلق به.

**أي شريحة تكون موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي الذي تم إنشاؤه حديثًا يحتوي بالفعل على شريحة فارغة واحدة ذات فهرس صفر. هذا أمر مهم مراعاته عند حساب مؤشرات الإدراج.

**كيف أختار التخطيط "الصحيح" لشريحة جديدة إذا كان القالب يحتوي على العديد من الخيارات؟**

عادةً اختر فئة [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) التي تتطابق مع البنية المطلوبة ([Title and Content, Two Content, إلخ](https://reference.aspose.com/slides/java/com.aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [add it to the master](/slides/ar/java/slide-layout/) ثم استخدامه.