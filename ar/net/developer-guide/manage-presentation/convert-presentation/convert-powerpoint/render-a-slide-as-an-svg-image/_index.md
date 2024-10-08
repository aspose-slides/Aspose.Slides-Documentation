---
title: تحويل شريحة كصورة SVG في C#
linktitle: تحويل شريحة كصورة SVG
type: docs
weight: 50
url: /ar/net/render-a-slide-as-an-svg-image/
description: يشرح هذا المقال كيفية تحويل عرض PowerPoint إلى تنسيق SVG باستخدام C#. يمكنك تحويل تنسيقات PPT و PPTX و ODP إلى صور SVG.
keywords: C# تحويل PowerPoint إلى SVG، C# PPT إلى SVG، C# PPTX إلى SVG
---

## نظرة عامة

يشرح هذا المقال كيفية **تحويل عرض PowerPoint إلى تنسيق SVG باستخدام C#**. يغطي الموضوعات التالية.

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

_التنسيق_: **شريحة**
- [C# تحويل شريحة PowerPoint إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة PPT إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة PPTX إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة ODP إلى SVG](#render-a-slide-as-an-svg-image)

مواضيع أخرى تم تغطيتها في هذا المقال.
- [انظر أيضاً](#see-also)

## تنسيق SVG
SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يستخدم لرسم الصور ثنائية الأبعاد. يتم تخزين الصور في SVG كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

SVG هو واحد من القليل من التنسيقات للصور التي تفي بمعايير عالية جداً في هذه الجوانب: قابلية التوسع، التفاعل، الأداء، إمكانية الوصول، البرمجة، وغيرها. لهذه الأسباب، غالباً ما يستخدم في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي في *تنسيق كبير جداً*.** يمكن أن تتوسع صور SVG إلى أي دقة أو مستوى. يمكنك إعادة تغيير حجم صور SVG عدة مرات كما هو مطلوب دون التضحية بالجودة.
- **استخدام الرسوم البيانية والمخططات من شرائحك في *وسائط أو منصات مختلفة**.* يمكن لمعظم القارئين تفسير ملفات SVG.
- **استخدام *أصغر أحجام ممكنة من الصور***. ملفات SVG عادة ما تكون أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، وخاصة تلك التنسيقات المعتمدة على البت (JPEG أو PNG).

## تحويل شريحة كصورة SVG

يسمح لك Aspose.Slides لـ .NET بتصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لتوليد صور SVG:

_الخطوات: تحويل PowerPoint إلى SVG في C#_

يفسر الكود النموذجي التالي هذه التحويلات باستخدام .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>الخطوات: تحويل PowerPoint إلى SVG في C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>الخطوات: تحويل PPT إلى SVG في C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>الخطوات: تحويل PPTX إلى SVG في C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>الخطوات: تحويل ODP إلى SVG في C#</strong></a>

_خطوات الكود:_

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
   * _.ppt_ لتحميل ملف **PPT** داخل فئة _Presentation_.
   * _.pptx_ لتحميل ملف **PPTX** داخل فئة _Presentation_.
   * _.odp_ لتحميل ملف **ODP** داخل فئة _Presentation_.
   * _.pps_ لتحميل ملف **PPS** داخل فئة _Presentation_.
2. استعرض جميع الشرائح في العرض التقديمي.
3. اكتب كل شريحة إلى ملف SVG خاص بها من خلال FileStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيقنا المجاني على الويب](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا فيه بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides لـ .NET.

{{% /alert %}} 

يوضح هذا الكود النموذجي في C# كيفية تحويل PowerPoint إلى SVG باستخدام Aspose.Slides: 

``` csharp
// يمكن كائن Presentation تحميل تنسيقات PowerPoint مثل PPT و PPTX و ODP وما إلى ذلك.
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

## انظر أيضاً 

يغطي هذا المقال أيضاً هذه المواضيع. الكود هو نفسه كما هو أعلاه.

_التنسيق_: **PowerPoint**
- [C# PowerPoint إلى SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG برمجياً](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG Library](#csharp-powerpoint-to-svg)
- [C# حفظ PowerPoint كـ SVG](#csharp-powerpoint-to-svg)
- [C# توليد SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# إنشاء SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG Converter](#csharp-powerpoint-to-svg)

_التنسيق_: **PPT**
- [C# PPT إلى SVG Code](#csharp-ppt-to-svg)
- [C# PPT إلى SVG API](#csharp-ppt-to-svg)
- [C# PPT إلى SVG برمجياً](#csharp-ppt-to-svg)
- [C# PPT إلى SVG Library](#csharp-ppt-to-svg)
- [C# حفظ PPT كـ SVG](#csharp-ppt-to-svg)
- [C# توليد SVG من PPT](#csharp-ppt-to-svg)
- [C# إنشاء SVG من PPT](#csharp-ppt-to-svg)
- [C# PPT إلى SVG Converter](#csharp-ppt-to-svg)

_التنسيق_: **PPTX**
- [C# PPTX إلى SVG Code](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG API](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG برمجياً](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG Library](#csharp-pptx-to-svg)
- [C# حفظ PPTX كـ SVG](#csharp-pptx-to-svg)
- [C# توليد SVG من PPTX](#csharp-pptx-to-svg)
- [C# إنشاء SVG من PPTX](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG Converter](#csharp-pptx-to-svg)

_التنسيق_: **ODP**
- [C# ODP إلى SVG Code](#csharp-odp-to-svg)
- [C# ODP إلى SVG API](#csharp-odp-to-svg)
- [C# ODP إلى SVG برمجياً](#csharp-odp-to-svg)
- [C# ODP إلى SVG Library](#csharp-odp-to-svg)
- [C# حفظ ODP كـ SVG](#csharp-odp-to-svg)
- [C# توليد SVG من ODP](#csharp-odp-to-svg)
- [C# إنشاء SVG من ODP](#csharp-odp-to-svg)
- [C# ODP إلى SVG Converter](#csharp-odp-to-svg)