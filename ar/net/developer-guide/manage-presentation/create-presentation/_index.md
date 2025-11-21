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
description: "إنشاء عروض تقديمية في .NET باستخدام Aspose.Slides — إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---

## **إنشاء عرض تقديمي ببرنامج PowerPoint**
لإضافة خط بسيط عادي إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة Presentation.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من النوع Line باستخدام الطريقة AddAutoShape المتاحة عبر كائن Shapes.
1. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع خط
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء وحفظ العرض التقديمي**

<a name="csharp-create-save-presentation"><strong>خطوات: إنشاء وحفظ العرض التقديمي بلغة C#</strong></a>

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. حفظ _Presentation_ إلى أي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **فتح وحفظ العرض التقديمي**

<a name="csharp-open-save-presentation"><strong>خطوات: فتح وحفظ العرض التقديمي بلغة C#</strong></a>

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بأي تنسيق مثل PPT أو PPTX أو ODP وما إلى ذلك.
2. حفظ _Presentation_ إلى أي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// تحميل أي ملف مدعوم في Presentation مثلاً ppt أو pptx أو odp إلخ.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**ما هي الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، و[XPS](/slides/ar/net/convert-powerpoint-to-xps/)، و[HTML](/slides/ar/net/convert-powerpoint-to-html/)، و[SVG](/slides/ar/net/convert-powerpoint-to-png/)، و[images](/slides/ar/net/convert-powerpoint-to-png/)، وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. قم بتحميل القالب وحفظه بالتنسيق المطلوب؛ الصيغ مثل POTX/POTM/PPTM والصيغ المشابهة [مدعومة](/slides/ar/net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

قم بضبط [slide size](/slides/ar/net/slide-size/) (بما في ذلك القوالب مثل 4:3 و16:9 أو أبعاد مخصصة) واختر طريقة تصغير/تكبير المحتوى.

**بأي وحدات يتم قياس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة تساوي 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [BLOB management strategies](/slides/ar/net/manage-blob/)، وقلل من التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات بدلاً من التدفقات في الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) من خلال [multiple threads](/slides/ar/net/multithreading/). شغّل كائنات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة المائية والقيود؟**

[Apply a license](/slides/ar/net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف ترخيص XML دون تعديل، ويجب مزامنة إعداد الترخيص إذا شاركت خيوط متعددة.

**هل يمكنني توقيع PPTX الذي أنشئه رقمياً؟**

نعم. [Digital signatures](/slides/ar/net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم العروض التقديمية التي تم إنشاؤها ماكرو (VBA)؟**

نعم. يمكنك [create/edit VBA projects](/slides/ar/net/presentation-via-vba/) وحفظ ملفات ممكّنة للماكرو مثل PPTM/PPSM.