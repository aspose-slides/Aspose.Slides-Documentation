---
title: عرض الشريحة كصورة SVG
type: docs
weight: 50
url: /ar/net/render-slide-as-svg-image/
---

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق قياسي للرسوميات يُستخدم لعرض الصور ثنائية الأبعاد. تخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

تُعتبر SVG واحدة من القلائل التي تلبي معايير عالية جداً من حيث: القابلية للتوسع، التفاعلية، الأداء، الوصول، البرمجة، وغيرها. ولهذه الأسباب، فإنها تُستخدم بشكل شائع في تطوير الويب.

قد ترغب في استخدام ملفات SVG في السيناريوهات التالية:

- عندما تخطط لطباعة العرض التقديمي الخاص بك في تنسيق كبير جداً. يمكن أن تتوسع صور SVG إلى أي دقة أو مستوى. يمكنك إعادة تغيير حجم صور SVG عدة مرات حسب الحاجة دون التنازل عن الجودة.
- عندما تنوي استخدام المخططات والرسوم البيانية من الشرائح الخاصة بك في وسائط أو منصات مختلفة. يمكن لمعظم القراء تفسير ملفات SVG.
- عندما تحتاج لاستخدام أصغر أحجام ممكنة من الصور. تكون ملفات SVG عمومًا أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، خاصة تلك التنسيقات المعتمدة على Bitmap (JPEG أو PNG).

يسمح لك Aspose.Slides لـ .NET بتصدير الشرائح في العروض التقديمية كصور **SVG**. لإنشاء صورة SVG من أي منها، اتبع الخطوات التالية:

- إنشاء نسخة من فئة Presentation.
- التكرار عبر جميع الشرائح في العرض التقديمي.
- كتابة كل شريحة إلى ملف SVG الخاص بها عبر FileStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides لـ .NET.

{{% /alert %}} 

يوضح لك هذا الكود النموذجي بلغة C# كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:

``` csharp
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