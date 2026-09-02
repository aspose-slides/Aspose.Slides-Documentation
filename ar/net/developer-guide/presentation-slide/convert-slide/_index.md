---
title: تحويل شرائح العروض التقديمية إلى صور في .NET
linktitle: شريحة إلى صورة
type: docs
weight: 41
url: /ar/net/convert-slide/
keywords:
- تحويل شريحة
- تصدير شريحة
- شريحة إلى صورة
- حفظ الشريحة كصورة
- شريحة إلى EMF
- شريحة إلى PNG
- شريحة إلى JPEG
- شريحة إلى صورة نقطية
- شريحة إلى TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحويل الشرائح من عروض PPT و PPTX و ODP إلى PNG و JPEG و GIF و TIFF و EMF وغيرها من صيغ الصور في C# باستخدام Aspose.Slides for .NET."
---
## **المقدمة**

Aspose.Slides for .NET يمكنه تصيير شرائح فردية من عروض PowerPoint و OpenDocument كصور PNG أو JPEG أو GIF أو TIFF وغيرها من صيغ الصور.

لتحويل شريحة إلى صورة، اتبع الخطوات التالية:

1. حمّل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/).
2. اختر الشريحة التي تريد تصييرها.
3. إذا لزم الأمر، اضبط إعدادات التصيير باستخدام الفئة [RenderingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/renderingoptions/) أو [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/).
4. استدعِ الطريقة [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/). ستُعيد كائنًا من النوع [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/).
5. استدعِ الطريقة [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/save/) وحدد صيغة الإخراج باستخدام قيمة من النوع [ImageFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/).

## **تحويل شريحة إلى صورة PNG**

أبسط طريقة للتحويل هي استخدام إعدادات التصيير الافتراضية. يمكن معالجة كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) الناتج في الذاكرة أو حفظه إلى ملف.

مثال C# التالي يصيّر الشريحة الأولى ويحفظها كصورة PNG:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **تحويل الشرائح إلى صور بأحجام مخصصة**

استخدم التحميل الزائد للطريقة [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/) الذي يقبل قيمة من النوع [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) لتصِيير الشريحة بأبعاد بكسلية محدَّدة.

المثال التالي ينشئ صورة JPEG بحجم 1820 × 1040 بكسل:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بشكل افتراضي، لا تتضمن صور الشرائح الملاحظات أو التعليقات. قم بتعيين كائن من النوع [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notescommentslayoutingoptions/) إلى الخاصية [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) للتحكم في موضع ظهور الملاحظات والتعليقات.

المثال التالي يضع الملاحظات المختصرة أسفل الشريحة والتعليقات إلى يمينها:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
في عملية تحويل الشريحة إلى صورة، لا تقم بتعيين الخاصية [NotesPosition](https://reference.aspose.com/slides/ar/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) إلى [BottomFull](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notespositions/). قد تحتوي الملاحظات على نص أكثر مما يمكن لصورة ثابتة أن تستوعبه. استخدم [BottomTruncated](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notespositions/) بدلاً من ذلك.
{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام خيارات TIFF**

الفئة [TiffOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/) تتيح لك التحكم في الحجم والدقة والخصائص الأخرى لصورة TIFF المصيّرة.

المثال التالي يصيّر الشريحة الأولى كصورة TIFF بحجم 2160 × 2880 بكسل بدقة 300 DPI:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **تحويل جميع الشرائح إلى صور**

قم بالتكرار عبر مجموعة الشرائح لتحويل العرض بالكامل إلى سلسلة من الصور. تُضمّن الشرائح المخفية ما لم تقم بتخطيها صراحةً.

المثال التالي يصيّر كل شريحة كصورة JPEG مع عوامل مقياس أفقية وعمودية بقيمة 2:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **إنشاء مخرجات Enhanced Metafile**

Enhanced Metafile (EMF) مفيدة عندما يجب تبادل رسومات تعتمد على المتجهات مع Microsoft Office أو تطبيقات Windows الأخرى التي تدعم ملفات Windows metafile. على عكس الصورة القائمة على البكسل، يمكن لـ EMF الاحتفاظ بعمليات الرسم المتجهية التي تتوسع دون فقدان الحدة. ومع ذلك، تُعد EMF في الأساس صيغة توافق لتطبيقات تدعم ملفات Windows metafile، وليست صيغة تبادل شاملة. بالإضافة إلى ذلك، قد يتم تخزين محتوى شريحة معقد، مثل الصور النقطية وبعض التأثيرات، كعناصر مُرصّصة داخل حاوية ملف المتجه.

### **تصدير شريحة إلى EMF**

الطريقة [ISlide.WriteAsEmf](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/writeasemf/) تكتب كائن [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/) إلى تدفق الهدف بصيغة EMF. المثال التالي يحمل عرضًا، يختار الشريحة الأولى، ويكتبها إلى تدفق ملف EMF:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

المستدعي هو المسؤول عن تدفق البيانات الممرّر إلى [ISlide.WriteAsEmf](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/writeasemf/) ويجب إغلاقه أو التخلص منه. يقوم Aspose.Slides بالكتابة في الموضع الحالي للتدفق ويترك التدفق مفتوحًا.

### **تحويل صورة SVG إلى EMF وإضافتها إلى عرض**

استخدم [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/writeasemf/) لتحويل محتوى SVG إلى EMF. يمكن إضافة البايتات الناتجة إلى العرض عبر [IImageCollection.AddImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection/addimage/) ووضعها على شريحة باستخدام [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addpictureframe/).

المثال التالي ينشئ كائن [SvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/svgimage/) من تعليمات SVG، يحوله إلى EMF في الذاكرة، يدرج الملف المتجه على الشريحة الأولى، ويحفظ العرض:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/writeasemf/) لا يتولى ملكية تدفق الوجهة. بعد الكتابة، يكون موضع التدفق في نهاية البيانات المُولدة. أعد تعيين `Position` إلى البداية قبل تمرير نفس التدفق القابل للبحث إلى القارئ، كما هو موضح أعلاه. حافظ على التدفق مفتوحًا حتى ينتهي المستهلك من قراءته، ثم حرره. بدلاً من ذلك، استدعِ `ToArray` ومرّر المصفوفة البايتية الناتجة إلى [IImageCollection.AddImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection/addimage/)؛ `ToArray` تُعيد كامل المخزن بغض النظر عن موضع التدفق الحالي.

تتوفر عملية توليد EMF على أنظمة التشغيل المدعومة من بنية Aspose.Slides for .NET المختارة، لكن عملية التصيير قد تختلف بين الأنظمة عندما تكون الخطوط أو تبعيات الرسوميات الأصلية غير متوفرة. ثبّت الخطوط المستخدمة في المحتوى الأصلي أو اضبط استبدالات ملائمة، وتبع [متطلبات المنصة](/slides/ar/net/system-requirements/) لحزمة Aspose.Slides الخاصة بك، وتحقق من النتيجة في التطبيق المستهلك لـ EMF المستهدف. غالبًا ما تكون تطبيقات Linux و macOS ذات دعم محدود أو غير متسق لعرض وتحرير ملفات Windows metafile.

## **تصيير الإيموجي الملونة**

{{% alert title="Note" color="info" %}}
لتحقيق تصيير صحيح للإيموجي الملونة عند تحويل شرائح العرض إلى صور، يجب تثبيت خطوط الإيموجي المستخدمة في العرض وتوافرها على النظام الذي يجري التحويل. على سبيل المثال، إذا كان العرض يستخدم **Segoe UI Emoji** وكانت هذه الخط غير موجودة، قد تظهر الإيموجي بأبيض وأسود في الصور الناتجة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides تصيير الشرائح مع الحركات؟**

لا. الطريقة [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/) تصيّر صورة ثابتة للشريحة ولا تُصدّر الحركات.

**هل يمكن تصدير الشرائح المخفية كصور؟**

نعم. يمكن تصيير الشرائح المخفية مثل الشرائح العادية. أدرجها في حلقة المعالجة كما هو موضح في المثال أعلاه.

**هل يتم الحفاظ على الظلال والتأثيرات الأخرى في صور الشرائح؟**

نعم. تقوم Aspose.Slides بتصيير الظلال والشفافية وغيرها من التأثيرات الرسومية المدعومة في صور الشرائح.