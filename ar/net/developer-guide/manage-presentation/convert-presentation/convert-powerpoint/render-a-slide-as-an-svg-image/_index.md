---
title: تصدير شرائح العرض التقديمي كصور SVG في .NET
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
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في .NET والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قابل للتوسيع قائم على XML يعمل جيدًا للنشر على الويب، وعارض الشرائح، وسير العمل المتعلق بإمكانية الوصول، ومعالجة ما بعد الإنتاج الآلية. تقوم Aspose.Slides بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص، والخطوط، والصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) عندما يجب أن يكون SVG المصدر مضغوطًا، قابلًا للتنبؤ عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق. المثال التالي يصدر كل شريحة في العرض التقديمي كملف SVG منفصل.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

يستخدم اسم الملف [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) بدلاً من مؤشر الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) يتحكم في رسم SVG. بالنسبة لإطارات النص، فإن [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) يضم إطار النص في منطقة الرسم، و[SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) يحدد ما إذا كان يتم تطبيق تدوير الإطار. اضبط [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) إلى `true` عندما يجب أن يُرسم النص بدون الواصات.

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

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى كنص أو يتحول إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة التناسق البصري، واختيار النص، واعتمادات الخطوط في SVG المصدر.

### **تحويل كل النص إلى متجه**

قم بضبط [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) إلى `true` لكتابة كل نص الشريحة كرسومات متجهة. هذا يقضي على اعتمادات الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، ولكن النص لم يعد قابلًا للتحديد أو البحث كنص SVG.

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

يستخدم [SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، أو `Embed` لتضمين بيانات الخط في SVG، أو `Vectorize` لرسم النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من ترخيص الخط قبل تضمينه.

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

استخدم [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) لتقليل دقة الصور المدمجة، و[SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) لإهمال المناطق المقطوعة من المصدر، و[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) للتحكم في جودة ترميز JPEG. تقلل هذه الإعدادات من حجم الملف على حساب وضوح الصورة أو البيانات المحتفظ بها.

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

## **التحكم في دقة تحويل ملفات الميتا إلى نقطية**

يضبط [SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) الحد الأدنى لدقة تمثيل ملفات الميتا إلى نقطية أثناء تصدير SVG. استخدمه لتحقيق توازن بين التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يُعرّف DPI عالميًا للـ SVG ولا يجبر كل كائن في الشريحة على أن يصبح صورة نقطية.

نزّل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF ذات خطوط مائلة متقاربة. المثال التالي يصدر شريحته الأولى بثلاث دقات تمثيل نقطية عبر [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). تبقى جميع إعدادات التصدير الأخرى متطابقة بحيث يمكن مقارنة النتائج.

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

في الناتج، تحولت صورة EMF إلى PNG مدمج واحد في كل SVG. القياسات التالية تخص العرض التقديمي المرفق؛ ليست صيغة عامة لتحويل DPI إلى أبعاد البكسل.

| دقة تمثيل ملف الميتا DPI | أبعاد PNG المدمجة | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

تُظهر المقارنة أدناه نفس منطقة الصورة النقطية المدمجة بنفس حجم العرض المكبر. تُظهر الخطوط المائلة بكسلة واضحة عند 72 DPI وحوافًا أكثر سلاسة عند الدقات الأعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن بالضرورة كل التفاصيل ولا تغير كل صورة مُصدرة.

![تفاصيل الخط المائل المكبر عند 72 و150 و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) يتحكم في تقليل دقة الصورة ويمكن أن يخفي تأثير تغيير دقة تمثيل ملف الميتا. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) يتحكم في جودة ترميز JPEG، وليس في دقة تمثيل ملف الميتا.

## **تعيين معرفات ثابتة للأشكال والنص**

استخدم [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) لتعيين [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) لكل شكل SVG. لتعيين قيم [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) على عناصر النص `tspan` أيضًا، نفّذ [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). عَيِّن أي من المتحكمين باستخدام [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

المتحكم التالي يستخدم [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/)، وهو ثابت طوال عمر الشكل، وعدادًا قابلًا للتكرار لنصوصه. يجعل هذا المعرفات المولدة مناسبة للمعالجة اللاحقة لعرض تقديمي غير معدل.

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

في [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)، استدعِ [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) بقيمة [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدَّר. عيّن المتحكم باستخدام [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) وحدد دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المستضيفة تعريف دالة JavaScript التي يشير إليها المعالج. يتيح تعيين المعرفات ومعالجات الأحداث للمشاهدين للشرائح، وتحسينات إمكانية الوصول، وغيرها من سير عمل SVG التفاعلية.

## **الأسئلة الشائعة**

**متى يجب علي استخدام [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

استخدم [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) عندما يجب أن يكون كل النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل ملف SVG أصغر؟**

ابدأ بضغط الصور المدمجة، حذف مناطق الصور المقصوصة، واختيار ملفات الخطوط المرتبطة عندما يمكن للبيئة المستهدفة خدمتها. اختبر النتيجة لأن تقليل دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجه كل منها له مقايضات متفاوتة بين الجودة والحجم.

**هل يمكن تعديل عناصر SVG المصدرة بعد التصدير؟**

نعم. عيّن المعرفات عبر متحكم تنسيق، ثم حدد عناصر SVG المطابقة في أداة المعالجة اللاحقة أو سكريبت المتصفح.