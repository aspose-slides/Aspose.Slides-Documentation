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
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- قص صورة
- منطقة مقصوصة
- خاصية StretchOff
- تنسيق إطار الصورة
- خصائص إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- شفافية الصورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أضف إطارات الصور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. سهل عملية عملك وحسّن تصميم الشرائح."
---
## **المقدمة**

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="نصيحة" color="info" %}} 
Aspose تقدم محولات مجانية — [JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt) — التي تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class. 
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
4. تحديد عرض وارتفاع الصورة. 
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe) بناءً على عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` المكشوفة من كائن الشكل المرتبط بالشريحة المرجعية. 
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة. 
7. كتابة العرض المعدل كملف PPTX. 

هذا الكود C# يوضح لك كيفية إنشاء إطار صورة:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// ينشئ كائن من الفئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بنفس الارتفاع والعرض
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيقات على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يكتب العرض إلى ملف PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
تسمح لك إطارات الصور بإنشاء شرائح عرض بسرعة بناءً على الصور. عندما تجمع إطار الصورة مع خيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/net/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/net/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/net/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/net/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/net/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/net/conversion/svg-to-png/). 
{{% /alert %}}

## **إنشاء إطار صورة بمقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class. 
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة صورة إلى مجموعة صور العرض. 
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة. 
6. كتابة العرض المعدل كملف PPTX. 

هذا الكود C# يوضح لك كيفية إنشاء إطار صورة بمقياس نسبي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// ينشئ كائن من الفئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يضبط عرض وارتفاع المقياس النسبي
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // يحفظ العرض
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **استخراج صور نقطية من إطارات الصور**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe) وحفظها بصيغ PNG أو JPG وغيرها. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **استخراج صور SVG من إطارات الصور**

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/)، يتيح لك Aspose.Slides for .NET استعادة الصور المتجّهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) المتعلق به يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغة SVG الأصلية.

الكود التالي يوضح كيفية استخراج صورة SVG من إطار صورة:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **الحصول على شفافية الصورة**

Aspose.Slides يتيح لك الحصول على تأثير الشفافية المطبق على الصورة. يوضح هذا الكود C# العملية:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **الحصول على سطوع وتباين الصورة**

Aspose.Slides يتيح لك الحصول على تأثير السطوع والتباين المطبق على الصورة. تمثل واجهة [ILuminance](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iluminance/) هذا التحويل.

هذا الكود C# يوضح كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
جميع التأثيرات المطبقة على الصور يمكن العثور عليها في [Aspose.Slides.Effects](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/). 
{{% /alert %}}

## **تنسيق إطار الصورة**

Aspose.Slides يقدم العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتطابق مع المتطلبات المحددة.

1. إنشاء نسخة من فئة [Presentation](http://www.aspose.com/api/net/slides/ar/aspose.slides/)class. 
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
4. تحديد عرض وارتفاع الصورة. 
5. إنشاء `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](http://www.aspose.com/api/net/slides/ar/aspose.slides/ishapecollection/methods/addpictureframe) المكشوفة من كائن [IShapes](http://www.aspose.com/api/net/slides/ar/aspose.slides/ishapecollection) المرتبط بالشريحة المرجعية. 
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
7. تعيين لون خط إطار الصورة. 
8. تعيين عرض خط إطار الصورة. 
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة. 
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة. 
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
11. كتابة العرض المعدل كملف PPTX. 

هذا الكود C# يوضح عملية تنسيق إطار الصورة:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// ينشئ كائن من الفئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بارتفاع وعرض الصورة المتساويين
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيقات على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يكتب العرض إلى ملف PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose طورت مؤخرًا أداة مجانية لصنع الكولاج [Collage Maker](https://products.aspose.app/slides/ar/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتقليل حجم العروض الكبيرة، يمكنك إضافة الصور (أو الفيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح هذا الكود C# كيفية إضافة صورة وفيديو إلى عنصر نائب:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **اقتصاص الصور**

هذا الكود C# يوضح كيفية اقتصاص صورة موجودة على شريحة:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // ينشئ كائن صورة جديد
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف PictureFrame إلى شريحة
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // يقتطع الصورة (قيم النسبة المئوية)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // يحفظ النتيجة
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **حذف المناطق المقطوعة من إطار الصورة**

إذا كنت ترغب في حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تُرجع هذه الطريقة الصورة المقطوعة أو الصورة الأصلية إذا لم يكن الاقتصاص ضرورياً.

هذا الكود C# يوضح العملية:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يحصل على إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // يحذف المناطق المقصوصة من صورة إطار الصورة ويعيد الصورة المقصوصة
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // يحفظ النتيجة
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ملاحظة" color="warning" %}} 

طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تضيف الصورة المقطوعة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية الاقتصاص. 
{{% /alert %}}

## **ضغط الصور**

يمكنك ضغط صورة في العرض باستخدام طريقة [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/compressimage/). تقوم هذه الطريقة بضغط الصورة عن طريق تقليل حجمها بناءً على حجم الشكل والدقة المحددة، مع خيار حذف المناطق المقصوصة. 

إنها تضبط حجم الصورة ودقتها بشكل مشابه لميزة PowerPoint **Picture Format → Compress Pictures → Resolution**.

الأمثلة التالية في C# توضح كيفية ضغط صورة في عرض بتحديد دقة الهدف وإزالة المناطق المقصوصة إذا رغبت:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وحذف المناطق المقصوصة.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // تحقق من نتيجة الضغط.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

أو باستخدام قيمة DPI مخصصة مباشرة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة إلى 150 DPI (دقة الويب)، مع حذف المناطق المقصوصة.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ملاحظة" color="warning" %}} 

تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل و DPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف. 
إذا كانت الصورة ملف ميتا (WMF/EMF) أو SVG، لن يُطبق الضغط. كما أن جودة JPEG تُحافظ أو تُقلل قليلًا بناءً على الدقة، كما في PowerPoint. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعادها حتى بعد تغيير أبعاد الصورة، يمكنك استخدام خاصية [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframelock/aspectratiolocked/) لتعيين إعداد *قفل نسبة الأبعاد*. 

هذا الكود C# يوضح كيفية قفل نسبة أبعاد الشكل:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // يضبط الشكل للحفاظ على نسبة الأبعاد عند إعادة التحجيم
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="ملاحظة" color="warning" %}} 

إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل ولا يحافظ على الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و [StretchOffsetBottom](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat)، يمكنك تحديد مستطيل تعبئة. 

عند تحديد التمدد لصورة، يتم تحجيم مستطيل المصدر ليناسب مستطيل التعبئة المحدد. كل حافة من مستطيل التعبئة تُعرف بنسبة إزاحة من الحافة المقابلة لصندوق حدود الشكل. النسبة الموجبة تشير إلى تقليص بينما السالبة تشير إلى توسعة.

1. إنشاء نسخة من فئة [Presentation](http://www.aspose.com/api/net/slides/ar/aspose.slides/)class. 
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة. 
5. تعيين نوع تعبئة الشكل. 
6. تعيين وضع تعبئة صورة الشكل. 
7. إضافة صورة لتعبئة الشكل. 
8. تحديد إزاحات الصورة من الحافة المقابلة لصندوق حدود الشكل. 
9. كتابة العرض المعدل كملف PPTX. 

هذا الكود C# يوضح عملية استخدام خاصية StretchOff:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // يضبط تمدد الصورة من كل جانب داخل جسم الشكل
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة المتكررة**

### كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟

Aspose.Slides يدعم كل من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهية (مثل SVG) عبر كائن الصورة المعيّن إلى [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عادةً مع قدرات محرك تحويل الشرائح والصور.

### كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟

إدراج صور كبيرة يزيد من حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد في تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متاحة. Aspose.Slides يوفر إمكانية إضافة صور عبر رابط لتقليل حجم الملف.

### كيف يمكنني قفل كائن الصورة لمنعه من التحريك/إعادة التحجيم غير المقصودة؟

استخدم [قفل الأشكال](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/pictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/) (مثلاً، تعطيل التحريك أو التحجيم). تم شرح آلية القفل للأشكال في مقالة [الحماية](/slides/ar/net/applying-protection-to-presentation/) وتدعم أنواع أشكال مختلفة بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/).

### هل يتم الحفاظ على دقة SVG المتجهة عند تصدير العرض إلى PDF/صور؟

Aspose.Slides يتيح استخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/net/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/net/convert-powerpoint-to-png/)، قد تُرسم النتيجة كنقطة اعتمادًا على إعدادات التصدير؛ يبقى حفظ SVG كمتجه مؤكدًا بسلوك الاستخراج.