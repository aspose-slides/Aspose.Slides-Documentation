---
title: إنشاء عرض PowerPoint باستخدام JavaScript
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/nodejs-java/create-presentation/
keywords: إنشاء ppt java, إنشاء ppt presentation, إنشاء pptx java
description: تعلم كيفية إنشاء عروض PowerPoint مثل PPT و PPTX باستخدام JavaScript من الصفر.
---

## **إنشاء عرض PowerPoint**

لإضافة خط بسيط ومستوٍ إلى شريحة مختارة من العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من الفئة Presentation.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من نوع خط باستخدام الطريقة addAutoShape التي توفرها كائن Shapes.
1. كتابة العرض المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض.
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation();
try {
    // احصل على الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة AutoShape من النوع خط
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**ما هي الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**

يمكنك حفظ إلى [PPTX, PPT, and ODP](/slides/ar/nodejs-java/save-presentation/)، وتصدير إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، [SVG](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، و[images](/slides/ar/nodejs-java/convert-powerpoint-to-png/)، من بين أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. احمِل القالب واحفظه بالصيغة المطلوبة؛ الصيغ POTX/POTM/PPTM وغيرها من الصيغ المشابهة [are supported](/slides/ar/nodejs-java/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

قم بضبط [slide size](/slides/ar/nodejs-java/slide-size/) (بما في ذلك الخيارات المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر طريقة تكبير المحتوى.

**بأي وحدات يتم قياس الأحجام والإحداثيات؟**

بالنقاط: البوصة الواحدة تساوي 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية كبيرة جدًا (مع الكثير من ملفات الوسائط) لتقليل استخدام الذاكرة؟**

استخدم [BLOB management strategies](/slides/ar/nodejs-java/manage-blob/)، واقتصّر على التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من تدفقات الذاكرة الصرفة.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك التعامل مع نفس كائن [Presentation](
https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) من [multiple threads](/slides/ar/nodejs-java/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة المائية والقيود؟**

[Apply a license](/slides/ar/nodejs-java/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف الترخيص XML دون تعديل، ويجب مزامنة إعداد الترخيص إذا شاركت خيوط متعددة.

**هل يمكنني توقيع الـ PPTX الذي أنشئه رقمياً؟**

نعم. [Digital signatures](/slides/ar/nodejs-java/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم الماكرو (VBA) في العروض التي تم إنشاؤها؟**

نعم. يمكنك [create/edit VBA projects](/slides/ar/nodejs-java/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.