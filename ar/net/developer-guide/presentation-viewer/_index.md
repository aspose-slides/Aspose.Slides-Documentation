---
title: إنشاء عارض عروض تقديمية في C#
linktitle: عارض العروض
type: docs
weight: 50
url: /ar/net/presentation-viewer/
keywords:
- عرض العرض التقديمي
- عارض العروض التقديمية
- إنشاء عارض عروض تقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- C#
- Csharp
- Aspose.Slides for .NET
description: "تعلم كيفية إنشاء عارض عروض تقديمية مخصص في .NET باستخدام Aspose.Slides. اعرض ملفات PowerPoint (PPTX, PPT) و OpenDocument (ODP) بسهولة دون الحاجة إلى Microsoft PowerPoint أو أي برنامج مكتب آخر."
---

## **نظرة عامة**

يُستخدم Aspose.Slides for .NET لإنشاء ملفات عروض تقديمية تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint على سبيل المثال. ومع ذلك، قد يحتاج المطورون في بعض الأحيان إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو استخدامها في عارض عروض مخصص. في هذه الحالات، يتيح لك Aspose.Slides تصدير الشرائح الفردية كصور. يشرح هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. فتح تدفق ملف.
1. حفظ الشريحة كصورة SVG إلى تدفق الملف.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```


## **إنشاء SVG مع معرف شكل مخصص**

يمكن استخدام Aspose.Slides لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرف شكل مخصص `ID`. لتحقيق ذلك، استخدم الخاصية Id من الواجهة [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape). يمكن استخدام الفئة `CustomSvgShapeFormattingController` لتعيين معرف الشكل.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```


## **إنشاء صورة مصغرة لشريحة**

يساعدك Aspose.Slides على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. إنشاء صورة مصغرة للشريحة المرجعية بالمقياس المطلوب.
1. حفظ الصورة المصغرة بالتنسيق المفضل لديك.
```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **إنشاء مصغرة شريحة بأبعاد محددة من قبل المستخدم**

لإنشاء صورة مصغرة للشريحة بأبعاد يحددها المستخدم، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. إنشاء صورة مصغرة للشريحة المرجعية بالأبعاد المحددة.
1. حفظ الصورة المصغرة بالتنسيق المفضل لديك.
```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **إنشاء مصغرة شريحة بملاحظات المتحدث**

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/).
1. استخدام خاصية `RenderingOptions.SlidesLayoutOptions` لتحديد موضع ملاحظات المتحدث.
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع إلى الشريحة حسب الفهرس.
1. إنشاء صورة مصغرة للشريحة المرجعية باستخدام خيارات العرض.
1. حفظ الصورة المصغرة بالتنسيق المفضل لديك.
```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```


## **مثال حي**

جرّب التطبيق المجاني [**عارض Aspose.Slides**](https://products.aspose.app/slides/viewer/) لتعرف ما يمكنك تنفيذه باستخدام Aspose.Slides API:

[![عارض PowerPoint عبر الإنترنت](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **الأسئلة الشائعة**

**هل يمكنني تضمين عارض عرض تقديمي في تطبيق ويب ASP.NET؟**

نعم. يمكنك استخدام Aspose.Slides على جانب الخادم لتصوير الشرائح كصور أو HTML وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض .NET مخصص؟**

النهج الموصى به هو تحويل كل شريحة إلى صورة (مثل PNG أو SVG) أو تحويلها إلى HTML باستخدام Aspose.Slides، ثم عرض الناتج داخل عنصر صورة (للتطبيقات المكتبية) أو داخل حاوية HTML (لويب).

**كيف يمكنني التعامل مع العروض الكبيرة التي تحتوي على العديد من الشرائح؟**

في حال وجود عروض ضخمة، يُنصح باستخدام التحميل الكسول أو العرض حسب الطلب للشرائح. يعني ذلك توليد محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.