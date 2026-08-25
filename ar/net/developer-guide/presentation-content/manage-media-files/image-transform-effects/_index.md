---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام .NET
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/net/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تحويل إلى رمادي
- ثنائي اللون
- صبغة
- HSL
- استبدال اللون
- ضبابية
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [ISlidesPicture](https://reference.aspose.com/slides/ar/net/aspose.slides/islidespicture/) الخاص بالإطار وافتح [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/ar/net/aspose.slides/islidespicture/imagetransform/). تُعيد [IImageTransformOperationCollection](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/) إمكانية إلحاق، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

تُظهر هذه المقالة سير عمل كامل للسطوع والتباين، تحولات الألوان، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد الصورة والصورة التي تُظهره كائنان مختلفان:

- [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) يخزن أو يشير إلى بيانات الصورة المصدر المملوكة للعرض التقديمي.
- [ISlidesPicture](https://reference.aspose.com/slides/ar/net/aspose.slides/islidespicture/) ينتمي إلى ملء الصورة ويشير إلى مورد الصورة بينما يخزن مجموعة تحويل الصورة.
- [IPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe/) هو شكل الشريحة الذي يملك ملء الصورة ذو الصلة، الهندسة، إعدادات القص، وتنسيقات المستوى الإطاري الأخرى.

لذلك، لا تُعدّل عمليات تحويل الصورة البايتات في [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/). عندما يتم تمرير نفس `IPPImage` إلى [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addpictureframe/) أكثر من مرة، يحصل كل إطار صورة جديد على `ISlidesPicture` خاص به ومجموعة تحويل خاصة به. تطبيق التحويل إلى رمادي على إطار واحد لا يجعل الأطر الأخرى رمادية، على الرغم من أن جميعها تعيد استخدام نفس مورد الصورة المضمّن.

نفس نموذج `ISlidesPicture.ImageTransform` يُستخدم أيضًا في ملء صور أخرى، مثل شكل أو خلفية شريحة. تركز الأمثلة أدناه على إطارات الصور.

## **استخدام نطاقات ومعايير صالحة للمعاملات**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. احتفظ بالقيم ضمن هذه النطاقات حتى لو لم يرفض إصدار مكتبة معين كل قيمة خارجة عن النطاق فورًا؛ قد يقوم تنسيق العرض التقديمي المستهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عندما يفتح PowerPoint الملف.

| العملية | المعاملات | النطاق والوحدة الصالحة |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | من `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | لا شيء | لا معلمات رقمية. يبقى ألفا دون تغيير. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | لونان للبكسلات الداكنة والفاتحة. القنوات RGB وalpha في `System.Drawing.Color` تتراوح من `0` إلى `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `amount` من `-100` إلى `100`، نسبة مئوية. |
| [AddHSLEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `saturation` و`luminance` من `-100` إلى `100`، نسبة مئوية. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم ألفا الموجودة لا تتغير. |
| [AddBlurEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` غير سالب ويُقاس بالنقاط؛ `grow` هو Boolean يتحكم فيما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادية: `0` شفاف تمامًا و`100` يحافظ على ألفا الموجود. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | من `0` إلى `100`، نسبة مئوية للشفافية. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | من `0` إلى `100`، نسبة مئوية للحد ألفا. القيم الأقل تصبح شفافة؛ القيم عند الحد أو فوقه تصبح غير شفافة. |

للتعديل الثابت على ألفا، الشفافية والعتامة متكاملتان. على سبيل المثال، شفافية 35% تُقابل مقدار تعديل ألفا 65%.

## **تطبيق السطوع والتباين**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) تُعيد عملية [IBrightnessContrast](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/ibrightnesscontrast/). تُزود إعداداته المتعددة عند إنشاء العملية. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/brightnesscontrast/geteffective/) تُعيد قيمًا محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بـ 15% والتباين بـ 20%، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/brightnesscontrast/) هو امتداد تأثير صورة Office 2010 وهو أقل قابلية للنقل من تأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابليين للتحرير بعد جولة PPTX، استخدم [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) وتحقق من النتيجة بعد إعادة فتح الملف. يشرح قسم قيود الصيغة هذا الاختلاف بمزيد من التفصيل.

## **تطبيق تحولات الألوان**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق الرمادي، الثنائي اللون، الصبغة، تعديل HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iduotone/) يحتوي على معاملين لونيين قابلين للتحرير بشكل مستقل: `Color1` يرمز للبكسلات الداكنة، بينما `Color2` يرمز للبكسلات الفاتحة. يجعل ذلك منه مثالًا مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة عددية واحدة.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) يستبدل لون كل بكسل بلون ثابت مع الحفاظ على ألفا. وهو مختلف عن [AddColorChangeEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)، الذي يطابق لون مصدر بلون هدف ويكشف عن صيغ اللون للمصدر والهدف.

## **إضافة ضبابية، شفافية، وتأثيرات ألفا**

[AddBlurEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) يؤثر على جميع قنوات اللون، بما فيها ألفا. اضبط `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). إنه يضرب كل قيمة ألفا موجودة، لذا تظل البكسلات شبه الشفافة متفاوتة نسبيًا. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) يُعيّن بدلاً من ذلك قيمة ألفا واحدة لجميع البكسلات. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) يحوّل ألفا إلى مستويين بناءً على حد.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

عمليات ألفا خالية من المعاملات تشمل أيضًا [AddAlphaCeilingEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)، الذي يجعل كل ألفا غير صفري غير شفاف تمامًا؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)، الذي يجعل كل ألفا أقل من 100% شفافًا تمامًا؛ و[AddAlphaInverseEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)، الذي يغيّر ألفا إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `Add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المُرَكّب المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، يمكن أن تُنتج نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، الرمادي ثم الصبغة يزيل أولاً المعلومات اللونية ثم يعيد تلوين النتيجة الإضاءة. الصبغة ثم الرمادي يزيل الصبغة مرة أخرى. بالمثل، استبدال ألفا يمكن أن يتجاوز قيم ألفا التي حسبتها عمليات سابقة، بينما تعديل ألفا يحافظ على اختلافاتها النسبية.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض التقديمي، يتحقق من كل من أنواع العمليات وترتيبها، ويعرض النتيجة المفتوحة مجددًا:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، ألفا، والضبابية إلى سلاسل منفصلة. يمكن دمجها، لكن الجمع ليس دائمًا مفيدًا. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات اللون السابقة؛ الرمادي بعد الثنائي اللون يزيل اللونين المحددين؛ وعمليات ألفا السقفية، الأرضية، الاستبدال، أو الثنائية يمكن أن تتخلص من تفاصيل ألفا التي أُنشِئَت مسبقًا. ابنِ السلسلة وفقًا لتسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كعلامات تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في `ISlidesPicture.ImageTransform`. اعتمادًا على التأثير، قد تكشف عن أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iblur/) يكشف عن `Radius` و`Grow` القابلة للكتابة، [IAlphaModulateFixed](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/ialphamodulatefixed/) يكشف عن `Amount` القابل للكتابة، و[IAlphaBiLevel](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/ialphabilevel/) يكشف عن `Threshold` القابل للكتابة. تأثيرات اللون مثل [IDuotone](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iduotone/) تكشف عن كائنات [IColorFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/icolorformat/) قابلة للتعديل.

بعض واجهات العمليات، بما في ذلك [IBrightnessContrast](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/itint/)، و[IAlphaReplace](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/ialphareplace/)، لا تكشف عن القيم العددية التي أُنشئت كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف استبدالًا في الموضع المطلوب.

البيانات الفعّالة التي تُرجعها `GetEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُطَّبعَة التي يستخدمها المُرَكّب، لكنها ليست سطح تحرير آخر. المثال التالي يعداد السلسلة ويفحص القيم الفعّالة حيث توفر API المقابلة ذلك:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

التأثيرات الخالية من المعاملات مثل الرمادي، السقيفة، والعكس لا يزال لديها كائن بيانات فعّالة، لكن لا توجد إعدادات عددية لطبعها. وجودها وموقعها في المجموعة هو المعلومات المهمة.

## **إزالة أو مسح تحويلات الصورة**

استخدم [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) لإزالة عملية واحدة حسب الفهرس. لأن الفهارس تتshift بعد الإزالة، ابحث عن الهدف أولًا ثم أزله بعد التعداد. استخدم `Clear()` لإزالة السلسلة بأكملها.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

إزالة أو مسح التحويلات يغيّر تنسيق الصورة فقط. لا يحذف، يعيد ضغط، أو يغيّر مورد [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) المعاد استخدامه.

## **اعتبارات صيغ العرض التقديمي وأهداف التصدير**

تأتي تحويلات الصورة من DrawingML، لذا يُعد PPTX الصيغة القابلة للتحرير المفضلة لسلاسل التأثير. حتى مع PPTX، ليست كل عملية ذات قابلية نقل متطابقة:

- عمليات DrawingML القياسية مثل الإضاءة، الرمادي، الثنائي اللون، الصبغة، HSL، الضبابية، والعمليات الشائعة لألفا لديها أفضل فرص للبقاء بعد جولة PPTX. دائمًا أعد فتح الملف المُنشأ وتفحص المجموعة عندما تكون المحافظة شرطًا.
- [BrightnessContrast](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/brightnesscontrast/) هو امتداد Office 2010 وليس عملية الإضاءة القياسية في DrawingML. يمكن استخدامه لتصوير في الذاكرة، لكنه غير مضمون أن يظل [IBrightnessContrast](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/ibrightnesscontrast/) قابلاً للتحرير بعد حفظ وإعادة فتح PPTX. فضلًا عن [AddLuminanceEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) لتعديلات سطوع وتباين مستمرة.
- تنسيق PPT الثنائي يسبق نموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يحذف العمليات غير المدعومة، يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقرب المظهر. لا تستخدم PPT كصيغة تحقق لسلسلة تحريرية معقّدة.
- التصيير إلى PNG، JPEG، TIFF، PDF، SVG، HTML، أو مخرجات بصرية أخرى يطبق السلسلة المدعومة على المظهر المصور. هذه المخرجات لا تحتوي على `IImageTransformOperationCollection` قابلة للتحرير؛ صيغ الرستر تسطح النتيجة إلى بكسلات، وتصديرات المستند/الرسوم المتجهة تخزن تمثيلها التصييري الخاص.
- التأثيرات لا تجعل الصورة المرتبطة مكتفية ذاتيًا. لا يزال تصيير صورة مرتبطة يعتمد على توفر المورد المرتبط عندما يُحمَّل العرض التقديمي.

قد يعرض مستهلكو العروض التقديمية المختلفون الحالات الحدية بطرق مختلفة، خاصةً عندما تُدمج عدة عمليات ألفا أو تكميم ألوان. للنتائج الحرجة، اختبر كلًّا من جولة التحرير النهائية وصيغة التصدير النهائية باستخدام نفس إصدار Aspose.Slides المستخدم في الإنتاج.

## **الأسئلة المتكررة**

**هل تعدّ تأثيرات تحويل الصورة بيانات الصورة المضمّنة؟**

لا. العمليات تنتمي إلى `ISlidesPicture` المستخدمة في ملء الصورة. تظل بايتات `IPPImage` الأساسية دون تغيير.

**هل تشارك إطاري صورة يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `IPPImage` يجنّب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يكون له `ISlidesPicture` منفصل ومجموعة تحويل صورة منفصلة.

**هل يمكن دمج تأثيرات اللون، الضبابية، وألفا؟**

نعم. تقبل المجموعة جميعها في سلسلة واحدة مرتبة. ضع في اعتبارك ما تفعله كل عملية على ناتج العملية السابقة لأن عمليات الاستبدال والحد قد تزيل تفاصيل اللون أو ألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في التصيير، بما فيها الألوان المحلولة. حرّر العملية المخزنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف استبدالًا بمعلمات إنشاء جديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن للـ PPT القديم تمثيل نموذج تأثير DrawingML الكامل، وتُحافظ صيغ التصدير المصورة على المظهر فقط دون عمليات التحويل القابلة للتحرير.