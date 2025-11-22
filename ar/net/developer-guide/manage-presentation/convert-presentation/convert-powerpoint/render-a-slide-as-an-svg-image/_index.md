---
title: عرض شريحة كصورة SVG في C#
linktitle: عرض شريحة كصورة SVG
type: docs
weight: 50
url: /ar/net/render-a-slide-as-an-svg-image/
description: تشرح هذه المقالة كيفية تحويل عرض PowerPoint إلى صيغة SVG باستخدام C#. يمكنك تحويل صيغ PPT و PPTX و ODP إلى صور SVG.
keywords: C# تحويل PowerPoint إلى SVG, C# PPT إلى SVG, C# PPTX إلى SVG
---

## **نظرة عامة**

تشرح هذه المقالة كيفية **تحويل عرض PowerPoint إلى صيغة SVG باستخدام C#**. تغطي المواضيع التالية.

_تنسيق_: **PowerPoint**
- [C# PowerPoint إلى SVG](#csharp-powerpoint-to-svg)
- [C# تحويل PowerPoint إلى SVG](#csharp-powerpoint-to-svg)
- [C# كيفية تحويل ملف PowerPoint إلى SVG](#csharp-powerpoint-to-svg)

_تنسيق_: **PPT**
- [C# PPT إلى SVG](#csharp-ppt-to-svg)
- [C# تحويل PPT إلى SVG](#csharp-ppt-to-svg)
- [C# كيفية تحويل ملف PPT إلى SVG](#csharp-ppt-to-svg)

_تنسيق_: **PPTX**
- [C# PPTX إلى SVG](#csharp-pptx-to-svg)
- [C# تحويل PPTX إلى SVG](#csharp-pptx-to-svg)
- [C# كيفية تحويل ملف PPTX إلى SVG](#csharp-pptx-to-svg)

_تنسيق_: **ODP**
- [C# ODP إلى SVG](#csharp-odp-to-svg)
- [C# تحويل ODP إلى SVG](#csharp-odp-to-svg)
- [C# كيفية تحويل ملف ODP إلى SVG](#csharp-odp-to-svg)

_تنسيق_: **Slide**
- [C# تحويل شريحة PowerPoint إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة PPT إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة PPTX إلى SVG](#render-a-slide-as-an-svg-image)
- [C# تحويل شريحة ODP إلى SVG](#render-a-slide-as-an-svg-image)

المواضيع الأخرى التي يغطيها هذا المقال.
- [انظر أيضًا](#see-also)

## **صيغة SVG**
SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو صيغة رسومات قياسية تُستخدم لعرض الصور ثنائية الأبعاد. يُخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من الصيغ التي تفي بمستويات عالية جداً في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، إمكانية الوصول، البرمجة، وغيرها. لهذه الأسباب، يُستخدم على نطاق واسع في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بصيغة *كبيرة جداً*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG عددًا لا نهائيًا من المرات دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.** معظم القارئات يمكنها تفسير ملفات SVG. 
- **استخدام أصغر حجم ممكن للصور*.** عادةً ما تكون ملفات SVG أصغر من نظيراتها ذات الدقة العالية في صيغ أخرى، خاصةً الصيغ المعتمدة على البتات (JPEG أو PNG).

## **عرض شريحة كصورة SVG**

Aspose.Slides for .NET يسمح لك بتصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لتوليد صور SVG:

_خطوات: تحويل PowerPoint إلى SVG في C#_

الكود النموذجي التالي يوضح هذه التحولات باستخدام .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>خطوات: تحويل PowerPoint إلى SVG في C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>خطوات: تحويل PPT إلى SVG في C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>خطوات: تحويل PPTX إلى SVG في C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>خطوات: تحويل ODP إلى SVG في C#</strong></a>

_خطوات الكود:_

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
   * امتداد _.ppt_ لتحميل ملف **PPT** داخل فئة _Presentation_.
   * امتداد _.pptx_ لتحميل ملف **PPTX** داخل فئة _Presentation_.
   * امتداد _.odp_ لتحميل ملف **ODP** داخل فئة _Presentation_.
   * امتداد _.pps_ لتحميل ملف **PPS** داخل فئة _Presentation_.
2. تكرار عبر جميع الشرائح في العرض التقديمي.
3. اكتب كل شريحة إلى ملف SVG خاص بها عبر FileStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا فيه بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides for .NET.

{{% /alert %}} 

هذا الكود النموذجي في C# يوضح لك كيفية تحويل PowerPoint إلى SVG باستخدام Aspose.Slides: 
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


## **الأسئلة المتكررة**

**لماذا قد يبدو ملف SVG الناتج مختلفًا عبر المتصفحات؟**

دعم ميزات SVG المحددة يتم تنفيذه بطرق مختلفة من قبل محركات المتصفحات. معلمات [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) تساعد في تقليل عدم التوافق.

**هل من الممكن تصدير ليس فقط الشرائح ولكن أيضًا الأشكال الفردية إلى SVG؟**

نعم. أي [شكل يمكن حفظه كملف SVG منفصل](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)، وهو ما يكون ملائمًا للأيقونات، الرسوم البيانية، وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في ملف SVG واحد (شريط/وثيقة)؟**

السيناريو القياسي هو شريحة واحدة → ملف SVG واحد. دمج عدة شرائح في قماش SVG واحد هو خطوة معالجة لاحقة تُنفّذ على مستوى التطبيق.

## **انظر أيضًا** 

هذه المقالة تغطي أيضًا هذه المواضيع. الرموز هي نفسها كما أعلاه.

_تنسيق_: **PowerPoint**
- [C# PowerPoint إلى SVG الكود](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG برمجيًا](#csharp-powerpoint-to-svg)
- [C# PowerPoint إلى SVG مكتبة](#csharp-powerpoint-to-svg)
- [C# حفظ PowerPoint كـ SVG](#csharp-powerpoint-to-svg)
- [C# توليد SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# إنشاء SVG من PowerPoint](#csharp-powerpoint-to-svg)
- [C# محول PowerPoint إلى SVG](#csharp-powerpoint-to-svg)

_تنسيق_: **PPT**
- [C# PPT إلى SVG الكود](#csharp-ppt-to-svg)
- [C# PPT إلى SVG API](#csharp-ppt-to-svg)
- [C# PPT إلى SVG برمجيًا](#csharp-ppt-to-svg)
- [C# PPT إلى SVG مكتبة](#csharp-ppt-to-svg)
- [C# حفظ PPT كـ SVG](#csharp-ppt-to-svg)
- [C# توليد SVG من PPT](#csharp-ppt-to-svg)
- [C# إنشاء SVG من PPT](#csharp-ppt-to-svg)
- [C# محول PPT إلى SVG](#csharp-ppt-to-svg)

_تنسيق_: **PPTX**
- [C# PPTX إلى SVG الكود](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG API](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG برمجيًا](#csharp-pptx-to-svg)
- [C# PPTX إلى SVG مكتبة](#csharp-pptx-to-svg)
- [C# حفظ PPTX كـ SVG](#csharp-pptx-to-svg)
- [C# توليد SVG من PPTX](#csharp-pptx-to-svg)
- [C# إنشاء SVG من PPTX](#csharp-pptx-to-svg)
- [C# محول PPTX إلى SVG](#csharp-pptx-to-svg)

_تنسيق_: **ODP**
- [C# ODP إلى SVG الكود](#csharp-odp-to-svg)
- [C# ODP إلى SVG API](#csharp-odp-to-svg)
- [C# ODP إلى SVG برمجيًا](#csharp-odp-to-svg)
- [C# ODP إلى SVG مكتبة](#csharp-odp-to-svg)
- [C# حفظ ODP كـ SVG](#csharp-odp-to-svg)
- [C# توليد SVG من ODP](#csharp-odp-to-svg)
- [C# إنشاء SVG من ODP](#csharp-odp-to-svg)
- [C# محول ODP إلى SVG](#csharp-odp-to-svg)