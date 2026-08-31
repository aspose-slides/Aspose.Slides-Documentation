---
title: عرض الشريحة كصورة SVG
type: docs
weight: 50
url: /ar/net/render-slide-as-svg-image/
---
SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تُحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تلبي معايير عالية جداً في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، إمكانية الوصول، البرمجة، وغيرها. لهذا السبب يُستخدم عادةً في تطوير الويب. 

قد ترغب في استخدام ملفات SVG في هذه الحالات:

- عندما تخطط لطباعة عرضك التقديمي بصيغة كبيرة جداً. يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تعديل حجم صور SVG عدة مرات حسب الحاجة دون التضحية بالجودة.
- عندما تريد استخدام المخططات والرسوم البيانية من شرائحك في وسائط أو منصات مختلفة. معظم القارئات يمكنها تفسير ملفات SVG. 
- عندما تحتاج إلى أصغر حجم ممكن للصور. عادةً ما تكون ملفات SVG أصغر من ما يعادلها عالي الدقة في تنسيقات أخرى، خاصةً تلك القائمة على الصور النقطية (JPEG أو PNG).

Aspose.Slides for .NET يتيح لك تصدير الشرائح في عروضك التقديمية كصور **SVG**. لتوليد صورة SVG من أي شيء، قم بما يلي:

- إنشاء كائن من الفئة Presentation.
- حلق عبر جميع الشرائح في العرض التقديمي.
- اكتب كل شريحة إلى ملف SVG خاص بها عبر FileStream.

{{% alert color="info" %}} 
قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/ar/conversion/ppt-to-svg) الذي طبقنا فيه وظيفة تحويل PPT إلى SVG باستخدام Aspose.Slides for .NET.
{{% /alert %}} 

هذا المثال البرمجي بلغة C# يوضح لك كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
``` csharp
using Aspose.Slides;

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