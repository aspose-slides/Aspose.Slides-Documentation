---
title: إدارة إطارات الصور في العروض التقديمية في .NET
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/net/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مدمجة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتنسيق وربط وقص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضه هما كائنان منفصلان: الـ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) يمتلك موارد الصور المتضمنة من خلال مجموعة الـ [Images](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/images/) الخاصة به، بينما الـ [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) يتحكم في موضع الصورة، حجمها، تنسيق الخط، الدوران، القص، تأثيرات الصورة، وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما يتم عرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) المرجعة، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور احتواء صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذلك من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمنة**

لصورة مدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addpictureframe/). تصبح الصورة جزءًا من حزمة العرض، لذا يظل العرض مستقلًا عندما يُنقل إلى حاسوب آخر.

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المدمجة. يصبح هذا التمييز مهمًا عند القص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

الـ [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) يُظهر مقياس العرض والارتفاع النسبي للإطار. القيمة `1.0` تمثل 100% من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

المقياس النسبي يغيّر إعدادات مقياس الإطار؛ لا يعيد عينة الصورة المدمجة أو يضغطها.

## **الصور المدمجة والمرتبطة**

الصورة المدمجة تخزن بيانات الصورة داخل العرض وبالتالي هي الخيار الأكثر أمانًا للنقل والعرض المتوقع. الصورة المرتبطة تخزن مسار موقع خارجي عبر رابط الـ [ISlidesPicture](https://reference.aspose.com/slides/ar/net/aspose.slides/islidespicture/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصور المخزنة في PPTX، لكنّها تُدخل اعتمادًا خارجيًا. يجب أن يظل الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار، أو نُقل الملف، أو أصبح المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعروض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المدمجة عادة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويوجهه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولم يُدمج عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها فقط كبديل للضغط: ملف PPTX صغير مع تبعيات صور مكسورة يكون عادة أقل فائدة من عرض تقديمي أكبر مستقل.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض تقديمي موجود، تحقق من أن الشكل هو في الواقع [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) وأنه يحتوي على صورة مدمجة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تستخدم [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) مباشرة ولا تحتاج إلى الغلاف القديم لنظام الصورة. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) يُحوّل الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، الـ [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يُظهر كائنًا من النوع [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرة بدلاً من تحويل الصورة أولاً.

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

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. تصدير الرستر مثل PNG أو JPEG يلزم تحويل ذلك المحتوى المتجهي إلى بكسلات. تصدير الشريحة إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسومات المصدَّرة نسخة حرفية من SVG المدمج الأصلي؛ استخدم بيانات الـ [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) المدمجة عندما تكون الحاجة إلى المورد المتجه نفسه.

## **قص صورة**

القص يغيّر الجزء الظاهر من الصورة داخل الإطار. قيم القص على [IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف القص في البداية البكسلات المخفية من الصورة المدمجة؛ فهو فقط يغيّر المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم القص:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أكثر أولوية من القابلية للعكس، يمكن إزالة المناطق المقصوة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) يزيل بيانات الصورة خارج مستطيل القص الحالي ويعيد مورد الصورة الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض، لا تعود البكسلات التي أزيلت متاحة لعملية إلغاء القص لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية تُستخدم أيضًا في إطارات صور أخرى، فإن تلك الإطارات ما زالت تحتاج إلى موردها الحالي، لذا حذف المناطق المقصوة لا يقلل بالضرورة من إجمالي عدد الصور. قص محتوى WMF أو EMF بهذه الطريقة يحوّل النتيجة المقصوصة إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/compressimage/) يقلل دقة الصورة النقطية بالنسبة للحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقصوة في نفس العملية. تُعيد الطريقة `true` عندما تم تعديل حجم الصورة أو قصها و `false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة مسبقة التعريف من [PicturesCompression](https://reference.aspose.com/slides/ar/net/aspose.slides.export/picturescompression/) عندما تكون دقة الهدف القياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من قيمة التعداد عندما يكون هناك هدف محدد مطلوب.

الضغط مخصص للصور النقطية. لا يقلل من محتوى SVG أو ملفات الميتا. وتذكر أن الدقة المنخفضة والمناطق المقصوة المحذوفة لا يمكن استعادتها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم سيُعرض فيه الصورة فعليًا أو يُصدَّر بدلاً من تطبيق أقل DPI عالميًا.

## **فحص تأثيرات الصورة**

تُخزن تأثيرات الصورة على الصورة المستخدمة في الإطار. يمكن أن يحتوي مجموعة تحويلات الصورة على تأثيرات مثل تعديل ألفا ثابت للشفافية واللمعان للسطوع والتباين. المثال أدناه يقرأ بأمان كلا النوعين من التأثيرات من أول إطار صورة على شريحة:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

هذه التأثيرات تُغيّر طريقة عرض الصورة في الإطار؛ لا تُعيد كتابة بايتات الصورة المدمجة الأصلية.

## **قفل هندسة إطار الصورة**

إعدادات الـ [IPictureFrameLock](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframelock/) تحكم أي عمليات تحرير تُعطَّل لإطار الصورة. على سبيل المثال، قفل نسبة الأبعاد يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل يُطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة العينة أو التغيير الدائم إلى نفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تُعرّف قيم الـ stretch‑offset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/) مستطيل الملء نسبةً إلى صندوق إطارات الصورة. النسب المئوية الإيجابية تُنشئ إدخالًا من الحافة، بينما النسب السلبية تُنشئ خروجًا.

هذا مختلف عن القص. قيم القص تحدد أي جزء من الصورة المصدر ظاهر؛ قيم الـ stretch تُغيّر المستطيل الذي يُمدد فيه ملء الصورة الظاهر.

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

استخدم الـ stretch offsets لتحديد موضع الملء. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون الموازنات الرئيسية أسهل في الإدارة عندما تُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المدمجة** تجعل العرض مستقلًا وتُعد الأكثر موثوقية للمشاركة والعرض من الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستهلاك الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على حزمة أصغر، لكن العرض يعتمد على بقاء الملفات الخارجية متاحة في المسارات أو المواقع المخزنة.
- **القص** في البداية غير تدميري. تظل البكسلات المخفية مدمجة حتى يتم حذف المناطق المقصوة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما يكون الحفاظ على المتجه مهمًا. استخرج الـ SVG المدمج مباشرة عندما تحتاج إلى المورد المتجه نفسه. تصدير الشرائح إلى رستر دائمًا يحوّل الشريحة إلى بكسلات.
- **الصور المتكررة** يجب إعادة استخدام مورد [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) موجود إن أمكن بدلاً من تحميل نفس الملف مرارًا في سير العمل.

للعروض الكبيرة، يكون تحسين الصورة أكثر فاعلية عندما يُنفَّذ انتقائيًا: احتفظ بالشعارات والمخططات كمحتوى متجه، اضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، أزل البكسلات المقصوصة فقط عندما لا تكون تعديلها لاحقًا مطلوبًا، وتجنب الروابط الخارجية ما لم يكن إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتداولة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

[IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يمثل مورد صورة مرتبط بالعرض. [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) هو شكل على الشريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم القص، التأثيرات، والقفل.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يكون العرض بحاجة إلى أن يكون قابلًا للنقل أو أرشفة أو عرضًا دون الوصول إلى موارد خارجية. اربط الصور فقط عندما يكون إبقاء ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية موثوقة.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تُخفي أجزاء من الصورة المصدر لكن تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) أو ضغط الصورة مع إزالة المناطق المقصوة عندما يمكن حذف تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقصوة تحذف بيانات الصورة. احتفظ بالصورة المصدر خارج العرض إذا كان قد يُطلب تعديلها بجودة عالية لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون وفاء المتجه مهمًا. يمكن استخراج الـ [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) المدمج مباشرة. عرض شريحة إلى تنسيق رستر مثل PNG أو JPEG يحوّل SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف أتجنب التحويلات غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. استخدام المطابقة النمطية مع [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) أو تصفية مجموعة الأشكال بذلك الواجهة يُجنب التحويلات غير الصالحة ويسمح للشفرة بالتعامل مع الشرائح التي لا تحتوي إطارات صور.