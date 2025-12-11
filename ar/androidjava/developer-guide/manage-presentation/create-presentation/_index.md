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
description: "إنشاء عروض تقديمية في Java باستخدام Aspose.Slides لـ Android—إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---

## **إنشاء عرض PowerPoint**
لإضافة خط بسيط إلى شريحة محددة في العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة Presentation.
1. الحصول على مرجع الشريحة باستخدام Index الخاص بها.
1. إضافة AutoShape من نوع Line باستخدام الطريقة addAutoShape المتاحة عبر كائن Shapes.
1. كتابة العرض المعدل كملف PPTX.

في المثال المقدم أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض.
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع خط
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/androidjava/save-presentation/)، وتصدير إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/androidjava/convert-powerpoint-to-xps/)، [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، [SVG](/slides/ar/androidjava/convert-powerpoint-to-png/)، و[images](/slides/ar/androidjava/convert-powerpoint-to-png/)، من بين غيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. حمّل القالب واحفظه بالصيغة المطلوبة؛ الصيغ POTX/POTM/PPTM والصيغ المماثلة [are supported](/slides/ar/androidjava/supported-file-formats/).

**كيف أتحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

قم بتعيين [slide size](/slides/ar/androidjava/slide-size/) (بما في ذلك القيم المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر كيفية مقياس المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة تساوي 72 وحدة.

**كيف أتعامل مع العروض الكبيرة (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [BLOB management strategies](/slides/ar/androidjava/manage-blob/)، قلل التخزين في الذاكرة باستخدام الملفات المؤقتة، ويفضل سير عمل قائم على الملفات على التدفقات المستندة إلى الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) من [multiple threads](/slides/ar/androidjava/multithreading/). استخدم نسخ منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة التجربة المائية والقيود؟**

[Apply a license](/slides/ar/androidjava/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML الخاص بالترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك عدة خيوط.

**هل يمكنني توقيع ملف PPTX الذي أنشئه رقمياً؟**

نعم. [Digital signatures](/slides/ar/androidjava/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرضات.

**هل تدعم العروض التقديمية التي تم إنشاؤها الماكرو (VBA)؟**

نعم. يمكنك [create/edit VBA projects](/slides/ar/androidjava/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.