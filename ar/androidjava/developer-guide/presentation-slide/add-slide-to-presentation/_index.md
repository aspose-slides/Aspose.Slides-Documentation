---
title: إضافة شرائح إلى العروض التقديمية على Android
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/androidjava/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة شرائح بسهولة إلى عروض PowerPoint وOpenDocument الخاصة بك باستخدام Aspose.Slides لأندرويد عبر جافا—إدراج شرائح سلس وفعّال في ثوانٍ."
---

## **إضافة شريحة إلى عرض تقديمي**
{{% alert color="primary" %}} 

قبل الحديث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعنا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي PowerPoint على شريحة **Master / Layout** وشرايح **Normal** أخرى. يعني ذلك أن ملف العرض يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides for Android via Java. كل شريحة لها معرف فريد ويتم ترتيب جميع الشرائح **Normal** وفقاً لترتيب يحدده الفهرس الصفري.

{{% /alert %}} 

Aspose.Slides for Android via Java يتيح للمطورين إضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة في العرض، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- إنشاء مثيل من الفئة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) عن طريق تعيين إشارة إلى خاصية [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) (مجموعة كائنات شريحة المحتوى) المعروضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- إضافة شريحة فارغة إلى العرض في نهاية مجموعة شرائح المحتوى عن طريق استدعاء طرق [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) المعروضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection).
- قم ببعض الأعمال مع الشريحة الفارغة التي تمت إضافتها حديثًا.
- أخيرًا، احفظ ملف العرض باستخدام كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // إنشاء كائن من الفئة SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // إضافة شريحة فارغة إلى مجموعة الشرائح
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // قم ببعض العمليات على الشريحة التي تمت إضافتها حديثًا

    // حفظ ملف PPTX إلى القرص
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من النهاية فقط.

**هل يتم الحفاظ على السمة/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. الورقة التخطيطية (Layout) ترث التنسيق من القالب الرئيسي (master)، والشريحة الجديدة ترث من التخطيط المحدد والقالب الرئيسي المرتبط به.

**أي شريحة تكون موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي الذي تم إنشاؤه حديثًا يحتوي بالفعل على شريحة فارغة واحدة ذات الفهرس صفر. من المهم مراعاة ذلك عند حساب فهارس الإدراج.

**كيف أختار التخطيط "الصحيح" لشريحة جديدة إذا كان القالب الرئيسي يحتوي على العديد من الخيارات؟**

عمومًا اختر [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) الذي يتوافق مع الهيكل المطلوب ([Title and Content, Two Content, إلخ.](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [إضافته إلى القالب الرئيسي](/slides/ar/androidjava/slide-layout/) ثم استخدامه.