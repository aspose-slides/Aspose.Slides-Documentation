---
title: إنشاء عروض تقديمية في .NET
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "إنشاء عروض تقديمية في .NET باستخدام Aspose.Slides—إنشاء ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---

## **إنشاء عرض تقديمي PowerPoint**
لإضافة خط بسيط عادي إلى الشريحة المحددة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة Presentation.
1. الحصول على مرجع الشريحة باستخدام مؤشرها.
1. إضافة AutoShape من نوع الخط باستخدام طريقة AddAutoShape التي توفرها كائن Shapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```c#
 // إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // إضافة AutoShape من نوع خط
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء وحفظ عرض تقديمي**

<a name="csharp-create-save-presentation"><strong>الخطوات: إنشاء وحفظ عرض تقديمي في C#</strong></a>

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. حفظ _Presentation_ إلى أي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **فتح وحفظ عرض تقديمي**

<a name="csharp-open-save-presentation"><strong>الخطوات: فتح وحفظ عرض تقديمي في C#</strong></a>

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بأي تنسيق مثل PPT أو PPTX أو ODP وغيرها.
2. حفظ _Presentation_ إلى أي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
 // قم بتحميل أي ملف مدعوم في Presentation مثل ppt أو pptx أو odp وغيرها.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**ما هي الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/net/save-presentation/)، وكذلك التصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، [SVG](/slides/ar/net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/net/convert-powerpoint-to-png/)، وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. قم بتحميل القالب واحفظه بالتنسيق المطلوب؛ الصيغ POTX/POTM/PPTM والصيغ المماثلة [مدعومة](/slides/ar/net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/net/slide-size/) (بما في ذلك الإعدادات المسبقة مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر كيفية ضبط المحتوى.

**ما هي الوحدات المستخدمة لقياس الأحجام والإحداثيات؟**

بالنقطة: 1 بوصة تساوي 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استخدام الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/net/manage-blob/)، وقلل التخزين في الذاكرة عن طريق الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات بدلاً من التدفقات التي تقتصر على الذاكرة.

**هل يمكنني إنشاء/حفظ عروض تقديمية بالتوازي؟**

لا يمكنك العمل على نفس مثيل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/net/multithreading/). شغل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة المائية والقيود؟**

[تطبيق ترخيص](/slides/ar/net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع ملف PPTX الذي أنشئه رقميًا؟**

نعم. [التوقيعات الرقمية](/slides/ar/net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

**هل تدعم العروض التقديمية التي تم إنشاؤها الماكرو (VBA)؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/net/presentation-via-vba/) وحفظ الملفات الممكّن للماكرو مثل PPTM/PPSM.