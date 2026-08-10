---
title: تحويل شرائح العرض التقديمي إلى صور SVG في .NET
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
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في .NET والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صور قائم على XML وقابل للتوسيع يعمل بشكل جيد للنشر على الويب، عارضات الشرائح، سير عمل إمكانية الوصول، ومعالجة ما بعد الإنتاج الآلية. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق. المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

اسم الملف يستخدم [ISlide.SlideNumber](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/slidenumber/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape.WriteAsSvg](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/writeassvg/) عندما يحتاج عارض الشرائح أو صفحة ويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/) يُتحكم في تصيير SVG. بالنسبة لإطارات النص، يتضمن [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/useframesize/) إطار النص في منطقة التصيير، و[SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/useframerotation/) يحدد ما إذا كان يتم تطبيق تدوير الإطار. اضبط [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/disablefontligatures/) على `true` عندما يجب أن يُصوَّر النص بدون الحروف المتصلة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **التحكم في النص والخطوط**

### **تحويل كل النص إلى رسومات متجهة**

اضبط [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/vectorizetext/) على `true` لكتابة كل نص الشريحة كرسومات متجهة. هذا يزيل الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث ك نص SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/externalfontshandling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لضم بيانات الخط داخل SVG، أو `Vectorize` لتصوير النص الذي يستخدم خطوطًا خارجية كرسوم. تحقق من ترخيص الخطوط قبل تضمينها.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **تقليل حجم الصور المضمَّنة**

استخدم [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/picturescompression/) لتقليل دقة الصور المضمَّنة، و[SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) لحذف المناطق المقصوفة من المصدر، و[SVGOptions.JpegQuality](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/jpegquality/) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isvgshapeformattingcontroller/) لتعيين [ISvgShape.Id](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isvgshape/id/) لكل شكل SVG. لتعيين قيم [ISvgTSpan.Id](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isvgtspan/id/) لعناصر النص `tspan` أيضًا، نفِّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). عيّن أي من المتحكمين باستخدام [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

المتحكم التالي يستخدم [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/officeinteropshapeid/)، وهو ثابت طوال عمر الشكل، ومؤشر قابل للتكرار لنصوصه. هذا يجعل المعرفات المُنشأة مناسبة لمعالجة ما بعد العرض التقديمي غير المتغيّر.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **إضافة معالجات أحداث SVG**

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isvgshapeformattingcontroller/)، استدعِ [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isvgshape/seteventhandler/) مع قيمة [SvgEvent](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدَّر. عيّن المتحكم باستخدام [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) وعرّف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

يمكن للصفحة المستضيفة تعريف دالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يتيح لعارضات الشرائح، تحسينات إمكانية الوصول، وسير عمل SVG التفاعلية الأخرى.

## **الأسئلة الشائعة**

**متى يجب أن أستخدم [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/vectorizetext/) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgoptions/vectorizetext/) عندما يجب أن يكون جميع النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/net/aspose.slides.export/svgexternalfontshandling/) عندما يجب تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتصغير حجم SVG؟**

ابدأ بضغط الصور المضمَّنة، حذف مناطق الصور المقصوفة، واختيار ملفات خطوط مرتبطة عندما يكون بإمكان البيئة المستهدفة تقديمها. اختبر النتيجة لأن خفض دقة الصورة، انخفاض جودة JPEG، والنص المتجه كل منها له مقايضات مختلفة بين الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر متحكم التنسيق، ثم اختر عناصر SVG المطابقة في أداة المعالجة اللاحقة أو سكريبت المتصفح الخاص بك.