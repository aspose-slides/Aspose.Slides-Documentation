---
title: عرض شرائح العرض التقديمي كصور SVG في .NET
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- الشريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- حفظ PPT كـ SVG
- حفظ PPTX كـ SVG
- تصدير PPT إلى SVG
- تصدير PPTX إلى SVG
- عرض الشريحة
- تحويل الشريحة
- تصدير الشريحة
- صورة متجهة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية عرض شرائح PowerPoint كصور SVG باستخدام Aspose.Slides لـ .NET. مرئيات عالية الجودة مع أمثلة بسيطة لكود C#."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية **تحويل عرض PowerPoint إلى تنسيق SVG باستخدام C#**. تغطي المواضيع التالية.

_التنسيق_: **PowerPoint**
- [C# PowerPoint إلى SVG](#csharp-powerpoint-to-svg)
- [C# تحويل PowerPoint إلى SVG](#csharp-powerpoint-to-svg)
- [C# كيفية تحويل ملف PowerPoint إلى SVG](#csharp-powerpoint-to-svg)

_التنسيق_: **PPT**
- [C# PPT إلى SVG](#csharp-ppt-to-svg)
- [C# تحويل PPT إلى SVG](#csharp-ppt-to-svg)
- [C# كيفية تحويل ملف PPT إلى SVG](#csharp-ppt-to-svg)

_التنسيق_: **PPTX**
- [C# PPTX إلى SVG](#csharp-pptx-to-svg)
- [C# تحويل PPTX إلى SVG](#csharp-pptx-to-svg)
- [C# كيفية تحويل ملف PPTX إلى SVG](#csharp-pptx-to-svg)

_التنسيق_: **ODP**
- [C# ODP إلى SVG](#csharp-odp-to-svg)
- [C# تحويل ODP إلى SVG](#csharp-odp-to-svg)
- [C# كيفية تحويل ملف ODP إلى SVG](#csharp-odp-to-svg)

_التنسيق_: **Slide**
- [C# تحويل شريحة PowerPoint إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة PPT إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة PPTX إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة ODP إلى SVG](#render-a-slide-as-an-svg-image)

المواضيع الأخرى التي تغطيها هذه المقالة.
- [انظر أيضًا](#see-also)

## **تنسيق SVG**

SVG—اختصار لScalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

SVG هو أحد القليل من تنسيقات الصور التي تفي بمعايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، إمكانية الوصول، البرمجة، وغيرها. لهذا السبب يُستخدم غالبًا في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى
- **طباعة عرضك التقديمي في *تنسيق كبير جدًا*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك إعادة تحجيم صور SVG مرات عديدة دون فقدان الجودة.
- **استخدام المخططات والرسوم البيانية من الشرائح في *وسائط أو منصات مختلفة*.** معظم القارئات يمكنها تفسير ملفات SVG.
- **استخدام *أصغر أحجام ممكنة للصور*.** عادةً ما تكون ملفات SVG أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، خاصةً تلك التنسيقات القائمة على البت ماب (JPEG أو PNG).

## **عرض شريحة كصورة SVG**

يتيح Aspose.Slides لـ .NET تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

_الخطوات: تحويلات PowerPoint إلى SVG في C#_

الروابط التالية تشرح هذه التحويلات باستخدام .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>الخطوات: تحويل PowerPoint إلى SVG في C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>الخطوات: تحويل PPT إلى SVG في C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>الخطوات: تحويل PPTX إلى SVG في C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>الخطوات: تحويل ODP إلى SVG في C#</strong></a>

_خطوات الشيفرة:_

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
   * _.ppt_ امتداد لتحميل ملف **PPT** داخل الفئة _Presentation_ .
   * _.pptx_ امتداد لتحميل ملف **PPTX** داخل الفئة _Presentation_ .
   * _.odp_ امتداد لتحميل ملف **ODP** داخل الفئة _Presentation_ .
   * _.pps_ امتداد لتحميل ملف **PPS** داخل الفئة _Presentation_ .
2. التنقل عبر جميع الشرائح في العرض التقديمي.
3. كتابة كل شريحة إلى ملف SVG الخاص بها عبر FileStream.

{{% alert color="primary" %}} 
قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الخاص بنا الذي نفّذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides لـ .NET.
{{% /alert %}} 

هذا المثال البرمجي بلغة C# يوضح لك كيفية تحويل PowerPoint إلى SVG باستخدام Aspose.Slides: 
``` csharp
// يمكن لكائن Presentation تحميل صيغ PowerPoint مثل PPT و PPTX و ODP وغيرها.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```


## **الأسئلة الشائعة**

**لماذا قد يبدو SVG الناتج مختلفًا عبر المتصفحات؟**

يدعم محركات المتصفحات ميزات SVG معينة بطرق مختلفة. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) في تخفيف التعارضات.

**هل من الممكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [shape as a separate SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) ، وهو مناسب للأيقونات والرسوم التصويرية وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.

## **انظر أيضًا** 

هذه المقالة تغطي أيضًا هذه المواضيع. الأكواد هي نفسها كما أعلاه.

_التنسيق_: **PowerPoint**
- [C# PowerPoint إلى SVG الكود](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG برمجياً](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG مكتبة](#csharp-powerpoint-to-svg)
- [C# حفظ PowerPoint كـ SVG](#csharp-powerpoint-to-svg)
- [C# إنشاء SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# إنشاء SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# محول PowerPoint إلى SVG](#csharp-powerpoint-to-svg)

_التنسيق_: **PPT**
- [C# PPT إلى SVG الكود](#csharp-ppt-to-svg)
- [C# PPT إلى SVG API](#csharp-ppt-to-svg)
- [C# PPT إلى SVG برمجياً](#csharp-ppt-to-svg)
- [C# PPT إلى SVG مكتبة](#csharp-ppt-to-svg)
- [C# حفظ PPT كـ SVG](#csharp-ppt-to-svg)
- [C# إنشاء SVG من PPT](#csharp-ppt-to-svg)
- [C# إنشاء SVG من PPT](#csharp-ppt-to-svg)
- [C# محول PPT إلى SVG](#csharp-ppt-to-svg)

_التنسيق_: **PPTX**
- [C# PPTX إلى SVG الكود](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG API](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG برمجياً](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG مكتبة](#csharp-pptx-to-svg)
- [C# حفظ PPTX كـ SVG](#csharp-pptx-to-svg)
- [C# إنشاء SVG من PPTX](#csharp-pptx-to-svg)
- [C# إنشاء SVG من PPTX](#csharp-pptx-to-svg)
- [C# محول PPTX إلى SVG](#csharp-pptx-to-svg)

_التنسيق_: **ODP**
- [C# ODP إلى SVG الكود](#csharp-odp-to-svg)
- [C# ODP إلى SVG API](#csharp-odp-to-svg)
- [C# ODP إلى SVG برمجياً](#csharp-odp-to-svg)
- [C# ODP إلى SVG مكتبة](#csharp-odp-to-svg)
- [C# حفظ ODP كـ SVG](#csharp-odp-to-svg)
- [C# إنشاء SVG من ODP](#csharp-odp-to-svg)
- [C# إنشاء SVG من ODP](#csharp-odp-to-svg)
- [C# محول ODP إلى SVG](#csharp-odp-to-svg)