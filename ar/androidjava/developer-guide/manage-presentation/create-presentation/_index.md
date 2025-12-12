---
title: إنشاء عروض تقديمية على Android
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/androidjava/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء عروض تقديمية في Java باستخدام Aspose.Slides لنظام Android — إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---

## **إنشاء عرض تقديمي PowerPoint**
لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة Presentation.
1. الحصول على مرجع شريحة باستخدام الفهرس Index.
1. إضافة AutoShape من نوع Line باستخدام الطريقة addAutoShape التي توفرها كائن Shapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة autoshape من النوع line
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**  
يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/androidjava/save-presentation/)، وتصدير إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/androidjava/convert-powerpoint-to-xps/)، [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، [SVG](/slides/ar/androidjava/convert-powerpoint-to-png/)، و[images](/slides/ar/androidjava/convert-powerpoint-to-png/)، وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**  
نعم. قم بتحميل القالب واحفظه بالصيغ المطلوبة؛ الصيغ POTX/POTM/PPTM وما شابهها [مدعومة](/slides/ar/androidjava/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**  
قم بتحديد [slide size](/slides/ar/androidjava/slide-size/) (يشمل الإعدادات المسبقة مثل 4:3 و 16:9 أو أبعاد مخصصة) واختر كيفية مقياس المحتوى.

**بأي وحدات يتم قياس الأحجام والإحداثيات؟**  
بالنقاط: 1 بوصة تساوي 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**  
استخدم [BBlob management strategies](/slides/ar/androidjava/manage-blob/)، وقلل التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من التدفقات التي تُعامل بالكامل في الذاكرة.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**  
لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) من [multiple threads](/slides/ar/androidjava/multithreading/). شغّل نسخًا منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة المائية والقيود؟**  
[Apply a license](/slides/ar/androidjava/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف ترخيص XML غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع PPTX رقمياً؟**  
نعم. [Digital signatures](/slides/ar/androidjava/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم العروض التقديمية التي تم إنشاؤها الماكرو (VBA)؟**  
نعم. يمكنك [create/edit VBA projects](/slides/ar/androidjava/presentation-via-vba/) وحفظ ملفات تدعم الماكرو مثل PPTM/PPSM.