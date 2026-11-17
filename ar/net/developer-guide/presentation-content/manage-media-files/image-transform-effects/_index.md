---
title: إدارة تأثيرات تحويل الصور في العروض التقديمية باستخدام .NET
linktitle: تأثيرات تحويل الصور
type: docs
weight: 11
url: /ar/net/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- رمادي
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
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصور لإطارات الصور باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

تمثل Aspose.Slides تعديلات الصور كمجموعة مرتبة من عمليات تحويل الصور. لإطار صورة، ابدأ بإطار الـ[ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) ثم وصول إلى [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). المجموعة المرتجعة [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) تسمح لك بإضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، وتحويلات اللون، وغموض الصورة، والشفافية، وسلاسل التأثير المرتبة، والقيم الفعّالة، والإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد الصورة والصورة التي تعرضه كائنان مختلفان:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي يمتلكها العرض.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) يخص تعبئة صورة ويشير إلى مورد صورة مع تخزين مجموعة تحويلات الصورة.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) هو شكل الشريحة الذي يمتلك تعبئة الصورة، الهندسة، إعدادات القص، وغير ذلك من تنسيقات المستوى الإطاري.

لذلك، عمليات تحويل الصورة لا تعدل البايتات في [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). عندما يتم تمرير نفس `IPPImage` إلى [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) أكثر من مرة، يحصل كل إطار صورة جديد على `ISlidesPicture` الخاص به ومجموعة التحويل الخاصة به. تطبيق تحويل الرمادي على إطار واحد لا يجعل الأطر الأخرى رمادية، رغم أن جميعها تعيد استخدام نفس مورد الصورة المضمّن.

نموذج `ISlidesPicture.ImageTransform` نفسه يُستعمل أيضاً من قبل تعبئات صور أخرى، مثل الشكل أو خلفية الشريحة. الأمثلة أدناه تركّز على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعلمات**

الطرق الموضحة تستخدم النطاقات والمعايير الدلالية التالية. احتفظ بالقيم ضمن هذه النطاقات حتى لو لم يرفض إصدار المكتبة نسخةً خارج النطاق مباشرة؛ قد يُطبع العرض المستهدف أو يتجاهل أو يرفض البيانات غير الصالحة أثناء الحفظ أو عند فتح PowerPoint للملف.

| العملية | المعلمات | النطاق والوحدة الصالحة |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | لا شيء | لا معلمات عددية. الشفافية تبقى دون تغيير. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | لونان للبيكسلات الداكنة والفاتحة. القنوات RGB والشفافية في `System.Drawing.Color` تستخدم من `0` إلى `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | درجة الصبغة `0` شاملة إلى `360` غير شاملة، بالدرجات؛ الكمية `-100` إلى `100`، نسبة مئوية. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | درجة الصبغة `0` شاملة إلى `360` غير شاملة، بالدرجات؛ التشبع والإضاءة `-100` إلى `100`، نسبة مئوية. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم الشفافية الحالية تبقى دون تغيير. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | نصف القطر غير سالب ويقاس بالنقاط؛ `grow` قيمة منطقية تتحكم ما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` شفاف بالكامل و`100` يحافظ على الشفافية الحالية. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` إلى `100`، نسبة مئوية للحدّ الشفافي. القيم الأقل تصبح شفافة؛ القيم عنده أو أعلى تصبح غير شفافة. |

للتعديل الثابت للشفافية، يكون الشفافية والعتامة متكاملين. على سبيل المثال، شفافية 35٪ تعادل تعديل عتامة 65٪.

## **تطبيق السطوع والتباين**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) يُعيد عملية [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). تُحدد الإعدادات العددية عند إنشاء العملية. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) تُعيد قيمًا محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يرفع السطوع بنسبة 15٪ والتباين بنسبة 20٪، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) هو امتداد تأثير صورة Office 2010 وهو أقل قابلية للنقل مقارنةً بتأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلة للتحرير بعد جولة PPTX، استخدم [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود الصيغة هذا التفريق بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق الرمادي، والداوتون، والصبغة، وتعديل HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) يحتوي على معلمتين للون يمكن تحريرهما بشكل مستقل: `Color1` يحدد اللون للبيكسلات الداكنة، بينما `Color2` يحدد اللون للبيكسلات الفاتحة. هذا يجعله مثالاً مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة عددية واحدة.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) يستبدل لون كل بيكسل بلون ثابت واحد مع الحفاظ على الشفافية. يختلف عن [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)، الذي يطابق لون مصدر إلى لون هدف ويظهر صيغتي اللون للمصدر والهدف.

### **تطبيق عتبة الإضاءة**

عتبة الإضاءة يمكن أن تجعل العلامات الخفيفة على صفحة ممسوحة ضوئياً أسهل للتمييز عن الخلفية. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) يحافظ على درجات الرمادي المتوسطة. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) يطابق الإضاءة إلى أسود أو أبيض، بينما [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) يطبق حدًا للشفافية.

عتبة الإضاءة تتراوح من 0% إلى 100% شاملة. البيكسلات أقل من العتبة تصبح سوداء. البيكسلات عندها أو أعلى تصبح بيضاء. رفع العتبة يجعل المزيد من الظلال سوداء لأن المزيد منها يقع تحت الحد.

حمّل [grayscale-swatches.png](grayscale-swatches.png) إلى دليل العمل. كل تسمية تُظهر مستوى الرمادي الأصلي على مقياس من 0 إلى 255. يضع المثال الأصل إلى جانب نسختين ويحفظ عتبة كل نسخة في العرض.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

افتح العرض الناتج في PowerPoint للمقارنة بين الإطارات الثلاثة. العينة المسمّاة 96 لها تقريبًا 38% إضاءة (96 من 255). تتحول إلى أبيض عند عتبة 20% وإلى أسود عند عتبة 60%.

![عينات رمادية أصلية بجوار نتائج أبيض وأسود عند عتبة إضاءة 20% و60%](luminance-threshold.png)

## **إضافة غموض، شفافية، وتأثيرات ألفا**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) يؤثر على جميع قنوات اللون، بما فيها الشفافية. عيّن `grow` إلى `true` عندما قد يمتد الحد الضبابي خارج حدود الصورة الأصلية.

للحصول على شفافية موحدة، استخدم [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). يضاعف كل قيمة شفافية موجودة، لذا تبقى البيكسلات شبه الشفافة متفاوتة بنسبتها. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) بدلاً من ذلك يعيّن قيمة شفافية واحدة لكل البيكسلات. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) يحول الشفافية إلى مستويين بناءً على حدّ.

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

عمليات ألفا بدون معلمات تشمل أيضاً [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)، الذي يجعل كل شفافية غير صفرية غير شفافة بالكامل؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)، الذي يجعل كل شفافية أقل من 100% شفافة بالكامل؛ و[AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)، الذي يغيّر الشفافية إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `Add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المرسِّم المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، نفس العمليات بترتيب مختلف قد تنتج صورة مختلفة.

على سبيل المثال، الغموض ثم الصبغة يزيل أولاً المعلومات اللونية ثم يعيد تلوين نتيجة الإضاءة. الصبغة ثم الغموض يُزيل الصبغة مرة أخرى. بالمثل، استبدال الشفافية قد يتجاوز قيم الشفافية المحسوبة بواسطة العمليات السابقة، بينما تعديل الشفافية يحافظ على اختلافاتها النسبية.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض، يتحقق من نوعية العمليات وترتيبها، ثم يرسم النتيجة المعاد فتحها:

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

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، الشفافية، والغموض إلى سلاسل منفصلة. يمكن دمجها، لكن الجمع قد لا يكون دائمًا مفيدًا. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات لون سابقة؛ الغموض بعد الداوتون يزيل اللونين المحددين؛ وعملية سقف الشفافية أو أرضية الشفافية أو الاستبدال أو المستوى الثنائي قد تُهدر تفاصيل الشفافية التي تم إنشاؤها مسبقًا. ابنِ السلسلة وفق تسلسل معالجة البكسل المطلوب بدلاً من معاملة عناصرها كعلامات تنسيق غير مرتبة.


<!-- visual-explanation:image-transform-effects:start -->
[![نفس الصورة تمر عبر غموض ثم صبغة، وصبغة ثم غموض. الصورة الرمادية النهائية لكل منهما لها نغمات مختلفة.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا التوضيح لــ Aspose.Slides للـ .NET 26.11، صبغة بزاوية 220° وبنسبة 25% لا تغير الصورة الرمادية. تطبيق نفس الصبغة قبل الغموض ينتج نغمات مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتحرير والفعّالة**

عملية قابلة للتحرير هي الكائن المخزن في `ISlidesPicture.ImageTransform`. حسب التأثير، قد يكشف عن أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) يكشف عن `Radius` و `Grow` القابلة للكتابة، و[IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) يكشف عن `Amount` القابل للكتابة، و[IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) يكشف عن `Threshold` القابل للكتابة. تأثيرات اللون مثل [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) تكشف عن كائنات [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) القابلة للتعديل.

بعض واجهات العمليات، بما في ذلك [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/)، و[IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/)، لا تكشف عن القيم العددية للإنشاء كخصائص قابلة للكتابة. لتغيير هذه الإعدادات، احذف العملية وأضف بديلًا في الموضع المطلوب.

البيانات الفعّالة التي تُعيدها `GetEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان الموضوع وقراءة القيم المُعَدَّلة التي يستخدمها المرسِّل، لكنها ليست سطح تحرير آخر. المثال التالي يتعداد السلسلة ويفحص القيم الفعّالة حيث توفر الواجهة المقابلة ذلك:

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

التأثيرات بدون معلمات مثل الرمادي، سقف الشفافية، والعكس الشفاف لا يزال لها كائن بيانات فعّالة، لكن لا توجد إعدادات عددية لطبعها. وجودها وموقعها في المجموعة هو ما يهم.

## **إزالة أو مسح تحويلات الصورة**

استخدم [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) لإزالة عملية واحدة حسب الفهرس. لأن الفهارس تتShift بعد الإزالة، ابحث عن الهدف أولاً ثم احذفه بعد التعداد. استخدم `Clear()` لإزالة السلسلة بالكامل.

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

إزالة أو مسح التحويلات يغيّر تنسيق الصورة فقط. لا يحذف، ولا يعيد ضغط، ولا يغيّر مورد [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) المعاد استخدامه.

## **مراعاة صيغ العرض وأهداف التصدير**

تأتي تحويلات الصورة من DrawingML، لذا يُفضَّل استخدام PPTX كصيغة تحرير لسلاسل التأثير. حتى مع PPTX، ليست كل عملية لها قابلية نقل مطابقة:

- عمليات DrawingML القياسية مثل الإضاءة، الرمادي، الداوتون، الصبغة، HSL، الغموض، والعمليات الشائعة للشفافية لديها أفضل فرصة للبقاء بعد جولة PPTX. أعد فتح الملف المُولَّد وتفقد المجموعة عندما تكون الحفظ مطلوبة.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) هو امتداد Office 2010 وليس عملية الإضاءة القياسية في DrawingML. يمكن استخدامه للعرض داخل الذاكرة، لكنه غير مضمون أن يبقى كـ [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) قابل للتحرير بعد حفظ وإعادة فتح PPTX. فضّل [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) لتعديلات السطوع والتباين المستدامة.
- صيغة PPT الثنائية سابقة لنموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يحذف عمليات غير مدعومة، أو يقلل السلسلة إلى مجموعة مدعومة، أو يقرب المظهر. لا تستخدم PPT كصيغة للتحقق من سلسلة تحرير معقدة.
- التحويل إلى PNG أو JPEG أو TIFF أو PDF أو SVG أو HTML أو أي مخرج بصري آخر يطبق السلسلة المدعومة على المظهر المُرَسَّم. تلك النواتج لا تحتوي على `IImageTransformOperationCollection` قابلة للتحرير؛ صيغ raster تُسطّح النتيجة إلى بكسلات، وتصدير المستند/الرسوم المتجهة يخزن تمثيله الخاص بالرسم.
- التأثيرات لا تجعل الصورة المرتبطة مكتملة ذاتيًا. لا يزال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

مستهلكو العروض المختلفون قد يرسمون حالات الحافة بصورة مختلفة، خاصةً عندما تُدمج عدة عمليات شفافية أو تكميم لون. للنتائج الحرجة، اختبر كل من جولة التحرير النهائية وصيغة التصدير النهائية باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تؤثر تأثيرات تحويل الصورة على بيانات الصورة المضمّنة؟**

لا. العمليات تنتمي إلى `ISlidesPicture` المستخدمة في تعبئة الصورة. بايتات `IPPImage` الأساسية تبقى دون تغيير.

**هل تشارك إطاري صورة يستخدمان نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `IPPImage` توفر بيانات الصورة المتكررة، لكن كل إطار صورة عادةً ما يكون له `ISlidesPicture` منفصل ومجموعة تحويلات صورة مستقلة.

**هل يمكن دمج تأثيرات اللون، الغموض، والشفافية؟**

نعم. المجموعة تقبلها في سلسلة مرتبة واحدة. ضع في اعتبارك ما تفعله كل عملية على مخرجات العملية السابقة لأن عمليات الاستبدال والحد قد تُهدر تفاصيل اللون أو الشفافية السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في العرض، بما فيها الألوان المحلولة. عدّل العملية المخزنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلًا بمعلمات إنشاء جديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. صيغ PPT القديمة لا تستطيع تمثيل نموذج تأثير DrawingML الكامل، والصيغ المُصدَّرة تُحافظ على المظهر فقط ولا تحتفظ بعمليات تحويل الصورة القابلة للتحرير.