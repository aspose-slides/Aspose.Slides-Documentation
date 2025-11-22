---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /ar/nodejs-java/add-slide-to-presentation/
---

## **إضافة شريحة إلى العرض التقديمي**
{{% alert color="primary" %}} 

قبل التحدث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعنا نناقش بعض الحقائق حول الشرائح. كل ملف عرض تقديمي PowerPoint يحتوي على شريحة **Master / Layout** وشريحة **Normal** أخرى. هذا يعني أن ملف العرض يحتوي على شريحة واحدة على الأقل أو أكثر. من المهم معرفة أن ملفات العرض التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides for Node.js via Java. كل شريحة لديها معرف فريد وجميع الشرائح العادية مرتبة بترتيب يُحدَّد بواسطة الفهرس القائم على الصفر.

{{% /alert %}} 

يسمح Aspose.Slides for Node.js via Java للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة إلى العرض، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- إنشاء فئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) عن طريق تعيين مرجع إلى خاصية [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) (مجموعة كائنات Slide المحتوى) المعروضة من قبل كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
- إضافة شريحة فارغة إلى العرض في نهاية مجموعة الشرائح المحتوى باستدعاء طريقة [**addEmptySlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) المعروضة من كائن [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection).
- تنفيذ بعض العمليات على الشريحة الفارغة التي تم إضافتها حديثًا.
- أخيرًا، كتابة ملف العرض باستخدام كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
```javascript
// إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
var pres = new aspose.slides.Presentation();
try {
    // إنشاء فئة SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // إضافة شريحة فارغة إلى مجموعة Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // إجراء بعض العمليات على الشريحة التي تم إضافتها حديثًا
    // حفظ ملف PPTX إلى القرص
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertclone/) ، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من الإضافة فقط في النهاية.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. يرث التخطيط التنسيق من الماستر الخاص به، وتورّث الشريحة الجديدة التنسيق من التخطيط المحدد والماستر المرتبط به.

**ما الشريحة الموجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي المنشأ حديثًا يحتوي بالفعل على شريحة فارغة واحدة ذات فهرس صفر. هذا مهم عند حساب مؤشرات الإدراج.

**كيف أختار التخطيط "الصحيح" لشريحة جديدة إذا كان الماستر يحتوي على العديد من الخيارات؟**

عموماً اختر فئة [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) التي تتطابق مع البنية المطلوبة ([Title and Content, Two Content, إلخ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [add it to the master](/slides/ar/nodejs-java/slide-layout/) ثم استخدامه.