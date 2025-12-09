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

## **إنشاء عرض PowerPoint**
لإضافة خط بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة Presentation.
2. الحصول على مرجع الشريحة باستخدام Index الخاص بها.
3. إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape المتاحة عبر كائن Shapes.
4. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation())
{
    // احصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // إضافة شكل تلقائي من النوع خط
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء وحفظ العرض التقديمي**

<a name="csharp-create-save-presentation"><strong>الخطوات: إنشاء وحفظ العرض التقديمي في C#</strong></a>

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. حفظ _Presentation_ بأي تنسيق تدعمه الفئة [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **فتح وحفظ العرض التقديمي**

<a name="csharp-open-save-presentation"><strong>الخطوات: فتح وحفظ العرض التقديمي في C#</strong></a>

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بأي تنسيق مثل PPT أو PPTX أو ODP إلخ.
2. حفظ _Presentation_ بأي تنسيق تدعمه الفئة [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// تحميل أي ملف مدعوم في Presentation مثل ppt أو pptx أو odp إلخ.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**ما هي التنسيقات التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، [SVG](/slides/ar/net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/net/convert-powerpoint-to-png/)، من بين تنسيقات أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. حمِّل القالب واحفظه بالتنسيق المطلوب؛ تدعم الصيغ POTX/POTM/PPTM وما شابهها [موجودة](/slides/ar/net/supported-file-formats/).

**كيف أتحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/net/slide-size/) (متضمنًا القيم المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر طريقة ضبط المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بـ points: البوصة الواحدة تساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية ضخمة (مع ملفات وسائط متعددة كثيرة) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/net/manage-blob/)، قلل التخزين في الذاكرة باستخدام الملفات المؤقتة، وفضّل سير عمل يعتمد على الملفات بدلاً من الجداول المتدفقة في الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك التعامل مع نفس كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/net/multithreading/). استخدم كائنات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة المياه التجريبية والقيود؟**

[قم بتطبيق ترخيص](/slides/ar/net/licensing/) مرة واحدة لكل عملية. يجب ألا يتم تعديل ملف XML للترخيص، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع ملف PPTX رقمياً؟**

نعم. [التوقيعات الرقمية](/slides/ar/net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم العروض التقديمية الماكرو (VBA)؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/net/presentation-via-vba/) وحفظ الملفات الممكَّنة للماكرو مثل PPTM/PPSM.