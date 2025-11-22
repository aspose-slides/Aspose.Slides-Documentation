---
title: إنشاء عرض تقديمي في .NET
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/net/create-presentation/
keywords: "إنشاء PowerPoint, PPTX, PPT, إنشاء عرض تقديمي, تهيئة العرض التقديمي, C#, .NET"
description: "إنشاء عروض PowerPoint برمجيًا باستخدام C# مثل PPT، PPTX، ODP وغيرها."
---

## **إنشاء عرض PowerPoint**
لإضافة خط بسيط إلى الشريحة المحددة في العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة Presentation.
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape التي تُتاح عبر كائن Shapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا بإضافة خط إلى الشريحة الأولى في العرض التقديمي.
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

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. حفظ _Presentation_ إلى أي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **فتح وحفظ العرض التقديمي**

<a name="csharp-open-save-presentation"><strong>الخطوات: فتح وحفظ العرض التقديمي في C#</strong></a>

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class بأي تنسيق مثل PPT أو PPTX أو ODP وغيرها.
2. حفظ _Presentation_ إلى أي تنسيق يدعمه [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// تحميل أي ملف مدعوم في Presentation مثل ppt أو pptx أو odp إلخ.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**ما هي التنسيقات التي يمكنني حفظ عرض تقديمي جديد بها؟**

يمكنك حفظه إلى [PPTX, PPT, و ODP](/slides/ar/net/save-presentation/)، وتصديره إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/), [HTML](/slides/ar/net/convert-powerpoint-to-html/), [SVG](/slides/ar/net/convert-powerpoint-to-png/), و[الصور](/slides/ar/net/convert-powerpoint-to-png/)، وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. قم بتحميل القالب وحفظه بالتنسيق المطلوب؛ تنسيقات POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/net/slide-size/) (بما في ذلك القوالب مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر طريقة تعديل حجم المحتوى.

**ما هي وحدات القياس للأحجام والإحداثيات؟**

بالنقاط: البوصة الواحدة تساوي 72 وحدة.

**كيف أتعامل مع العروض التقديمية الكبيرة (مع الكثير من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/net/manage-blob/)، وقم بتقليل التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات بدلاً من التدفقات التي تُحفظ بالكامل في الذاكرة.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكن العمل على نفس مثيل Presentation من عدة خيوطٍ (threads). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة المائية والقيود؟**

[قم بتطبيق ترخيص](/slides/ar/net/licensing/) مرةً واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص دون تعديل، ويجب مزامنة إعداد الترخيص إذا شاركت عدة خيوط.

**هل يمكنني توقيع ملف PPTX رقمياً؟**

نعم. [التواقيع الرقمية](/slides/ar/net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

**هل يتم دعم الماكرو (VBA) في العروض التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/net/presentation-via-vba/) وحفظ الملفات المُمكّنة للماكرو مثل PPTM/PPSM.