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
لإضافة خط بسيط إلى الشريحة المحددة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من الفئة Presentation.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من نوع خط باستخدام طريقة AddAutoShape المتاحة عبر كائن Shapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // إضافة AutoShape من النوع Line
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء وحفظ العرض التقديمي**

<a name="csharp-create-save-presentation"><strong>الخطوات: إنشاء وحفظ العرض التقديمي في C#</strong></a>

1. إنشاء كائن من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. حفظ _Presentation_ بأي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **فتح وحفظ العرض التقديمي**

<a name="csharp-open-save-presentation"><strong>الخطوات: فتح وحفظ العرض التقديمي في C#</strong></a>

1. إنشاء كائن من الفئة [العرض التقديمي](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بأي تنسيق مثل PPT أو PPTX أو ODP إلخ.
2. حفظ _Presentation_ بأي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// تحميل أي ملف مدعوم في Presentation مثل ppt أو pptx أو odp إلخ.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**ما التنسيقات التي يمكنني حفظ عرض تقديمي جديد فيها؟**

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/), [HTML](/slides/ar/net/convert-powerpoint-to-html/), [SVG](/slides/ar/net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/net/convert-powerpoint-to-png/)، وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. قم بتحميل القالب وحفظه بالتنسيق المطلوب؛ تنسيقات POTX/POTM/PPTM وما شابهها [مدعومة](/slides/ar/net/supported-file-formats/).

**كيف أتحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

قم بتعيين [حجم الشريحة](/slides/ar/net/slide-size/) (بما في ذلك القوالب مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر كيفية تكبير المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: البوصة الواحدة تساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع الكثير من ملفات الوسائط) لتقليل استخدام الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/net/manage-blob/)، قلل من التخزين في الذاكرة عن طريق الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات بدلاً من التدفقات داخل الذاكرة فقط.

**هل يمكنني إنشاء/حفظ العروض التقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/net/multithreading/). شغّل كائنات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة المائية والقيود؟**

[تطبيق ترخيص](/slides/ar/net/licensing/) مرة واحدة لكل عملية. يجب أن يظل ملف XML للترخيص بدون تعديل، ويجب مزامنة إعداد الترخيص إذا كانت هناك عدة خيوط.

**هل يمكنني توقيع ملف PPTX رقمياً الذي أنشأه؟**

نعم. [التواقيع الرقمية](/slides/ar/net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

**هل تدعم الماكرو (VBA) في العروض التقديمية التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/net/presentation-via-vba/) وحفظ ملفات مُمكنة للماكرو مثل PPTM/PPSM.