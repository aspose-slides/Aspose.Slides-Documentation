---
title: "تصدير شرائح العروض التقديمية كصور SVG في .NET"
linktitle: "شريحة إلى SVG"
type: docs
weight: 50
url: /ar/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint إلى SVG"
- "العرض التقديمي إلى SVG"
- "شريحة إلى SVG"
- "PPT إلى SVG"
- "PPTX إلى SVG"
- "خيارات تصدير SVG"
- "SVG تفاعلي"
- "PowerPoint"
- "العرض التقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تصدير شرائح PowerPoint كصور SVG في .NET والتحكم في الخطوط والنصوص والصور والمعرّفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML وقابل للتوسع يعمل بشكل جيد للنشر على الويب، وعارضات الشرائح، وتدفقات عمل إمكانية الوصول، والمعالجة اللاحقة الآلية. يقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل ويسمح لك بالتحكم في كيفية كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، متوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

قم بإنشاء [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق. المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

اسم الملف يستخدم [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) يتحكم في عرض SVG. بالنسبة لإطارات النص، يضمّ [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) إطار النص في مساحة العرض، وتحدد [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) ما إذا كان يتم تطبيق دوران الإطار. اضبط [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) إلى `true` عندما يجب عرض النص دون ربط الحروف.

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

## **التحكم في قص نهاية الخط عند رؤوس السهام**

SVG 1.1 لا يضم إعدادًا لتحديد موضع توقف الخط تحت رأس السهم. بشكل افتراضي، يقوم Aspose.Slides باختصار الخط المُصدَّر بحيث لا يبرز حدوده عبر العلامة. اضبط [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) إلى `true` لرسم الحد حتى نهايته الأصلية. هذا الإعداد يؤثر فقط على إخراج SVG. يبقى الخط في موضعه وطوله على الشريحة.

المثال يرسم رؤوس سهام مثلثية وماسية على خطوط بعرض نقطتين وعشرة نقاط. يصدر نفس الشريحة مرتين، مع تغيير خيار القص فقط.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

المقارنة توضح رأس السهم المثلث على الخط بعرض 10 نقاط. مع تمكين القص، تكون القمة حادة. مع تعطيل القص، يبرز الحد عبر جوانب العلامة المائلة ويترك نهاية مسطحة.

![مثلث 10 نقاط مكبر مع طرف حاد عندما يكون القص مفعَّل ونهاية مسطحة عندما يكون القص غير مفعَّل](line-end-cropping.png)

في الخطوط الأخرى من المثال، يصبح الحد البارز أقل وضوحًا على المثلث بعرض نقطتين. الماس المملوء يغطي نهاية الحد في كلا العرضين.

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم في ما إذا كان يظل النص نصًا أو يُحوَّل إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة الاتساق البصري، قابلية اختيار النص، واعتماد الخطوط في SVG المُصدَّر.

### **تحويل جميع النص إلى متجهات**

اضبط [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) إلى `true` لكتابة كل نص الشريحة كرسومات متجهة. هذا يلغي اعتماد الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لم يعد قابلًا للاختيار أو للبحث كـ SVG نصي.

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

### **اختر كيفية معالجة الخطوط الخارجية**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات الخطوط المنفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لرسم النص الذي يستخدم خطوطًا خارجية كرسومات فقط. تحقق من ترخيص الخط قبل تضمينه.

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

## **تقليل حجم الصورة المضمنة**

استخدم [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) لتقليل دقة الصور المضمنة، و[SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) لحذف المناطق المقتصّة من المصدر، و[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) للتحكم في جودة ترميز JPEG. تقلل هذه الإعدادات حجم الملف على حساب دقة الصورة أو احتفاظها ببيانات الصورة.

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

## **التحكم في دقة تحويل ملف الميتا إلى نقطية**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) يحد من الحد الأدنى لدقة التحويل إلى نقطية للملفات الميتا أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يحدد DPI عالميًا لـ SVG ولا يجبر كل كائن على الشريحة على أن يصبح صورة نقطية.

قم بتنزيل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط مائلة متقاربة. المثال التالي يصدر شريحته الأولى بثلاث دقات تحويل مختلفة عبر [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). جميع إعدادات التصدير الأخرى تبقى متطابقة حتى يمكن مقارنة النتائج.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

في المخرجات، تحوّل EMF إلى صورة PNG مدمجة واحدة في كل SVG. القياسات التالية تخص العرض المقدم؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة تحويل ملف الميتا (DPI) | أبعاد PNG المدمج | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه توضح نفس مساحة الصورة النقطية المدمجة عند نفس حجم العرض المكبر. تظهر الخطوط المائلة بكسلية واضحة عند 72 DPI وحواف أكثر سلاسة عند دقات أعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن بالضرورة كل التفاصيل أو تغير كل صورة مُصدَّرة.

![تفصيل خط مائل مكبر عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) يتحكم في تقليل دقة الصورة ويمكن أن يخفي تأثير تغيير دقة تحويل ملف الميتا. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) يتحكم في جودة ترميز JPEG، وليس في دقة تحويل ملف الميتا.

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) لتعيين [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) لكل شكل SVG. لتعيين قيم [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) على عناصر النص `tspan` أيضًا، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). عيّن أحد المتحكمين باستخدام [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

المتحكم التالي يستخدم [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/)، وهو ثابت طوال عمر الشكل، وعدّادًا قابلاً للتكرار لنصوصه. يجعل هذا المعرفات المُولَّدة مناسبة لمعالجة عرض تقديمي غير مُغيَّر لاحقًا.

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

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)، استدعِ [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) مع قيمة [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) لإضافة معالج JavaScript إلى شكل مُصدَّر. عيّن المتحكم باستخدام [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) وعَرِّف دالة JavaScript في الصفحة أو مستند SVG المضيف للنتيجة.

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

يمكن للصفحة المضيفة تعريف دالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يتيح عارضات الشرائح، تحسينات إمكانية الوصول، وسير عمل SVG تفاعلي آخر.

## **الأسئلة المتكررة**

**متى يجب علي استخدام [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل ملف SVG أصغر؟**

ابدأ بضغط الصور المضمنة، حذف مناطق الصور المقتصّة، واختيار ملفات الخطوط المرتبطة عندما يكون البيئة المستهدفة قادرة على خدمتها. اختبر النتيجة لأن تقليل دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجهات كلّها لها موازين جودة وحجم مختلفة.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر متحكم التنسيق، ثم حدد العناصر المطابقة في أداة ما بعد المعالجة أو سكريبت المتصفح.