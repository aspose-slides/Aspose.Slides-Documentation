---
title: عرض شرائح العرض التقديمي كصور SVG في .NET
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- حفظ PPT كـ SVG
- حفظ PPTX كـ SVG
- تصدير PPT إلى SVG
- تصدير PPTX إلى SVG
- عرض شريحة
- تحويل شريحة
- تصدير شريحة
- صورة متجهة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية عرض شرائح PowerPoint كصور SVG باستخدام Aspose.Slides لـ .NET. صور عالية الجودة مع أمثلة بسيطة لكود C#."
---

## **نظرة عامة**

توضح هذه المقالة كيفية **تحويل عرض PowerPoint إلى تنسيق SVG باستخدام C#**. تغطي المواضيع التالية.

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

مواضيع أخرى تغطيها هذه المقالة.
- [انظر أيضاً](#see-also)

## **تنسيق SVG**
SVG—اختصار Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يُستخدم لعرض الصور ثنائية الأبعاد. تخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تلبي معايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعل، الأداء، إمكانية الوصول، القابلية للبرمجة، وغيرها. لهذه الأسباب، يُستخدم على نطاق واسع في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك بصيغة *كبيرة جدًا*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG مرات عديدة حسب الحاجة دون فقدان الجودة.
- **استخدام المخططات والرسوم البيانية من الشرائح في *وسائط أو منصات مختلفة*.** معظم القُراء يمكنهم تفسير ملفات SVG. 
- **استخدام أصغر حجم ممكن للصور**. عادةً ما تكون ملفات SVG أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، خاصة تلك التي تعتمد على البتات (JPEG أو PNG).

## **عرض شريحة كصورة SVG**

تتيح لك Aspose.Slides لـ .NET تصدير الشرائح في عروضك كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

_خطوات: تحويل PowerPoint إلى SVG في C#_

الكود النموذجي التالي يوضح هذه التحويلات باستخدام .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>خطوات: تحويل PowerPoint إلى SVG في C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>خطوات: تحويل PPT إلى SVG في C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>خطوات: تحويل PPTX إلى SVG في C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>خطوات: تحويل ODP إلى SVG في C#</strong></a>

_خطوات الكود:_

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
   * امتداد _.ppt_ لتحميل ملف **PPT** داخل الفئة _Presentation_ .
   * امتداد _.pptx_ لتحميل ملف **PPTX** داخل الفئة _Presentation_ .
   * امتداد _.odp_ لتحميل ملف **ODP** داخل الفئة _Presentation_ .
   * امتداد _.pps_ لتحميل ملف **PPS** داخل الفئة _Presentation_ .
2. تكرار جميع الشرائح في العرض التقديمي.
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيقنا الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفّذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides لـ .NET.

{{% /alert %}} 

يعرض لك هذا الكود النموذجي في C# كيفية تحويل PowerPoint إلى SVG باستخدام Aspose.Slides: 
``` csharp
// كائن Presentation يمكنه تحميل تنسيقات PowerPoint مثل PPT و PPTX و ODP وغيرها.
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


## **الأسئلة المتكررة**

**لماذا قد يبدو SVG الناتج مختلفًا عبر المتصفحات؟**

يتم تنفيذ دعم ميزات SVG معينة بصورة مختلفة بواسطة محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) في تسوية عدم التوافق.

**هل يمكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**

نعم. أي [shape can be saved as a separate SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)، وهو أمر مناسب للأيقونات والرسومات البيانية وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/وثيقة)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.

## **انظر أيضاً** 

تغطي هذه المقالة أيضًا هذه المواضيع. الأكواد هي نفسها كما في الأعلى.

_التنسيق_: **PowerPoint**
- [C# PowerPoint إلى SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG Library](#csharp-powerpoint-to-svg)
- [C# حفظ PowerPoint كـ SVG](#csharp-powerpoint-to-svg)
- [C# توليد SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# إنشاء SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG Converter](#csharp-powerpoint-to-svg)

_التنسيق_: **PPT**
- [C# PPT إلى SVG Code](#csharp-ppt-to-svg)
- [C# PPT إلى SVG API](#csharp-ppt-to-svg)
- [C# PPT إلى SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT إلى SVG Library](#csharp-ppt-to-svg)
- [C# حفظ PPT كـ SVG](#csharp-ppt-to-svg)
- [C# توليد SVG من PPT](#csharp-ppt-to-svg)
- [C# إنشاء SVG من PPT](#csharp-ppt-to-svg)
- [C# PPT إلى SVG Converter](#csharp-ppt-to-svg)

_التنسيق_: **PPTX**
- [C# PPTX إلى SVG Code](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG API](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG Library](#csharp-pptx-to-svg)
- [C# حفظ PPTX كـ SVG](#csharp-pptx-to-svg)
- [C# توليد SVG من PPTX](#csharp-pptx-to-svg)
- [C# إنشاء SVG من PPTX](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG Converter](#csharp-pptx-to-svg)

_التنسيق_: **ODP**
- [C# ODP إلى SVG Code](#csharp-odp-to-svg)
- [C# ODP إلى SVG API](#csharp-odp-to-svg)
- [C# ODP إلى SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP إلى SVG Library](#csharp-odp-to-svg)
- [C# حفظ ODP كـ SVG](#csharp-odp-to-svg)
- [C# توليد SVG من ODP](#csharp-odp-to-svg)
- [C# إنشاء SVG من ODP](#csharp-odp-to-svg)
- [C# ODP إلى SVG Converter](#csharp-odp-to-svg)