---
title: إدارة إطارات الصور في العروض التقديمية في .NET
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/net/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مدمجة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقتصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة العرض إلى الارتفاع
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتنسيق وربط واقتصاص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكلة التي تعرضها كائنان منفصلان: الـ[Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) يمتلك موارد الصور المضمنة عبر مجموعة الـ[Images](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/images/) الخاصة به، بينما يتحكم الـ[IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) في موضع الصورة وحجمها وتنسيق الخط والدوران والاقتصاص وتأثيرات الصورة وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما تُظهر الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض التقديمي مرة واحدة، احتفظ بالـ[IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) المعاد، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. كما يمكنها الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض التقديمي. الاختيار يؤثر على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مدمجة**

لصورة مدمجة، أضف بيانات الصورة إلى العرض التقديمي وأنشئ إطار صورة باستخدام [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addpictureframe/). تصبح الصورة جزءًا من حزمة العرض التقديمي، لذا يظل العرض التقديمي مستقلاً عند نقله إلى كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المدمج. يصبح هذا التمييز مهمًا عند الاقتصاص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

الـ[IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) يتيح مقياس عرض وارتفاع نسبي للإطار. القيمة `1.0` تعادل 100 % من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

المقياس النسبي يغيّر إعدادات مقياس الإطار؛ لا يعيد أخذ العينات ولا يضغط الصورة المدمجة.

## **الصور المدمجة والمرتبطة**

الصورة المدمجة تخزن بيانات الصورة داخل العرض التقديمي وبالتالي تكون الخيار الأكثر أمانًا للنقل والعرض المتوقع. الصورة المرتبطة تخزن موقعًا خارجيًا عبر مسار رابط الـ[ISlidesPicture](https://reference.aspose.com/slides/ar/net/aspose.slides/islidespicture/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل تبعية خارجية. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض التقديمي. إذا تغير المسار، أو نُقل الملف، أو أصبح المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعرض التقديمي الذي يجب إرساله بالبريد الإلكتروني أو أرشفته أو عرضه في بيئات معزولة، عادة ما تكون الصور المدمجة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويوجهه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولم يُدمج عمدًا في هذا المثال.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

استخدم الروابط عندما تكون إدارة الملفات الخارجية مقصودة. لا تستخدمها فقط كبديل للضغط: ملف PPTX صغير يحتوي على تبعيات صور مكسورة عادةً ما يكون أقل فائدة من عرض تقديمي أكبر ومكتمل ذاتيًا.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض تقديمي موجود، تأكد أن الشكل هو فعلاً [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) وأنه يحتوي على صورة مدمجة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تستخدم الـ[IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) مباشرة ولا تتطلب ملف التغليف النظامي القديم. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

الحفظ عبر الـ[IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) يُحوّل الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت تحتاج البايتات المشفرة المخزنة في العرض التقديمي بدلاً من ملف نقطي محول، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، الـ[IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يُظهر كائن الـ[ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/). هذا يتيح لك استرجاع بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولاً.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض التقديمي. تصديرات النقطية مثل PNG أو JPEG تُعيد بالضرورة تحويل ذلك المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسومات المصدَّرة نسخة مطابقة بايتًا بايتًا من SVG المدمج الأصلي؛ استخدم بيانات الـ[ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) المدمجة عندما يكون المورد المتجه الأصلي مطلوبًا.

## **اقتصاص صورة**

يُغيّر الاقتصاص الجزء المرئي من الصورة داخل الإطار. قيم الاقتصاص على الـ[IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد الصورة الأصلية. لا يحذف الاقتصاص في البداية البكسلات المخفية من الصورة المدمجة؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم الاقتصاص:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل الاقتصاص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقتصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقتصة**

طريقة الـ[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تُزيل بيانات الصورة خارج مستطيل الاقتصاص الحالي وتعيد مورد الصورة الناتج. يمكن لهذا تقليل حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض التقديمي، لا تكون البكسلات التي أزيلت متاحة لعملية إلغاء اقتصاص لاحقة.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

قد تضيف الطريقة مورد صورة جديد إلى العرض التقديمي. إذا كانت الصورة الأصلية مستخدمة أيضًا من قبل إطارات صور أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقتصة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يحول النتيجة المقتصة إلى PNG.

## **ضغط الصور النقطية**

الـ[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/compressimage/) يقلل من دقة الصورة النقطية بالنسبة إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقتصة في نفس العملية. تُعيد الطريقة القيمة `true` عندما يتم تغيير حجم الصورة أو اقتصاصها، وتُعيد `false` عندما لا تكون هناك حاجة للتغيير.

استخدم قيمة مسبقة التعريف من الـ[PicturesCompression](https://reference.aspose.com/slides/ar/net/aspose.slides.export/picturescompression/) عندما تكون الدقة المستهدفة القياسية كافية:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

يمكن تمرير قيمة DPI موجبة مخصصة بدلًا من قيمة تعداد عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. لا تُقلل محتويات SVG أو ملفات الميتافايل هذا النوع من الضغط النقطي. تذكّر أيضًا أن الدقة الأقل والمناطق المقتصة المحذوفة لا يمكن استرجاعها من العرض التقديمي المُحسّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض فيه الصورة فعليًا أو تُصدر به بدلاً من تطبيق أدنى DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

لسير عمل كامل يغطي السطوع، التباين، تحويلات اللون، الضبابية، تأثيرات الشفافية، السلاسل المرتبة، الفحص، الإزالة، والتحقق المتبادل، راجع [Image Transform Effects](/slides/ar/net/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات الـ[IPictureFrameLock](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframelock/) تتحكم في عمليات التحرير التي تُعطل لإطار الصورة. على سبيل المثال، قفل نسبة العرض إلى الارتفاع يحافظ على نسب الشكل أثناء تغيير حجمه.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

القفل يُطبق على شكل إطار الصورة. ولا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم لنسبة العرض إلى الارتفاع نفسها.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تحدد قيم الـstretch‑offset على الـ[IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/) مستطيل التعبئة بالنسبة إلى صندوق الإطار. النسب المئوية الإيجابية تُنشئ تقليمًا من الحافة، بينما النسب السالبة تُنشئ امتدادًا.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تحدد أي جزء من الصورة المصدر مرئي؛ قيم الـstretch‑offset تغير المستطيل الذي يُمدد فيه ملء الصورة المرئي.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

استخدم الـstretch‑offset لتحديد موضع التعبئة. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

يصبح موازنة الفوائد أسهل عندما يُعامل تخزين الصورة وتنسيق إطار الصورة ككيانين منفصلين:

- **الصور المدمجة** تجعل العرض التقديمي مكتملًا ذاتيًا وتُعد الأكثر موثوقية للمشاركة والعرض من الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغر الحزمة، لكن العرض التقديمي يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **الاقتصاص** في البداية غير تدميري. تبقى البكسلات المخفية مدمجة حتى يتم حذف المناطق المقتصة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يفتقد الدقة الأصلية. يجب تطبيقه بعد معرفة الحجم المقصود على الشريحة.
- **صور SVG** يجب أن تظل كـ SVG عندما يكون الحفاظ على المتجه مهمًا. استخرج الـSVG المدمج مباشرةً عندما تحتاج إلى المورد المتجه نفسه. تصدير الشرائح إلى النقطية دائمًا يحول الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** يجب أن تُعيد استخدام مورد الـ[IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) الموجود عندما يكون ذلك ممكنًا بدلاً من تحميل نفس الملف مرارًا وتكرارًا إلى سير عمل العرض التقديمي.

للعروض التقديمية الكبيرة، غالبًا ما تكون تحسينات الصورة أكثر فاعلية عندما تُجرى انتقائيًا: احتفظ بالشعارات والرسوم البيانية كمتجهات، اضغط الصور الفوتوغرافية وفقًا لحجم العرض الفعلي، أزِل البكسلات المقتصة فقط عندما لا تكون هناك حاجة لتحرير لاحق، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

الـ[IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يمثل مورد الصورة المرتبط بالعرض التقديمي. الـ[IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) هو شكل على شريحة يعرض صورة ويخزن الهندسة وتنسيق الإطار مثل الحجم، الدوران، قيم الاقتصاص، التأثيرات، والقُفل.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يجب أن يكون العرض التقديمي قابلًا للنقل، مُؤرشفًا، أو مُعرضًا دون الوصول إلى موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصورة خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بصورة موثوقة.

**هل يقلل الاقتصاص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتصاص العادية تخفي أجزاء من الصورة الأصلية ولكنها تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) أو ضغط الصورة مع إزالة المناطق المقتصة عندما يمكن حذف تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقتصة تحذف بيانات الصورة. احتفظ بالصورة المصدرية الأصلية خارج العرض التقديمي إذا قد تكون هناك حاجة لتعديل بدقة عالية لاحقًا.

**كيف يجب معالجة صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون الدقة المتجهية مهمة. يمكن استخراج الـ[ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) المدمج مباشرةً. تحويل شريحة إلى تنسيق نقطي مثل PNG أو JPEG يُحوّل SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف أتجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام الأعضاء الخاصة بإطار الصورة. يتيح لك مطابقة النمط مع الـ[IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) أو تصفية مجموعة الأشكال وفقًا لذلك تجنب التحويلات غير الصالحة ويسمح للكود بمعالجة الشرائح التي لا تحتوي على إطارات صور.