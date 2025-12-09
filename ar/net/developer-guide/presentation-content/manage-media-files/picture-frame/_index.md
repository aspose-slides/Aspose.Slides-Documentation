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
description: "أضف إطارات الصور إلى عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET. سَهل سير عملك وحسّن تصاميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة — إنه مثل صورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 
تقدم Aspose محولات مجانية — [JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **Create Picture Frame**

1. إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class. 
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل. 
4. تحديد عرض وارتفاع الصورة. 
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) استنادًا إلى عرض وارتفاع الصورة من خلال طريقة `AddPictureFrame` التي يوفّرها كائن الشكل المرتبط بالشريحة المرجعية. 
6. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة. 
7. كتابة العرض التقديمي المعدل كملف PPTX. 

يوضح لك هذا الكود C# كيفية إنشاء إطار صورة:
```c#
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // يقوم بتحميل صورة ويضيفها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بنفس الارتفاع والعرض
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيق على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يحفظ العرض التقديمي إلى ملف PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" %}} 
تتيح لك إطارات الصورة إنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عند الجمع بين إطار الصورة وخيارات الحفظ في Aspose.Slides، يمكنك معالجة عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 
{{% /alert %}}

## **Create Picture Frame with Relative Scale**

من خلال تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class. 
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض التقديمي. 
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل. 
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة. 
6. كتابة العرض التقديمي المعدل كملف PPTX. 

يوضح لك هذا الكود C# كيفية إنشاء إطار صورة مع مقياس نسبي:
```c#
// ينشئ كائن فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يقوم بتحميل صورة ويضيفها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يضبط العرض والارتفاع النسبيين للمقياس
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // يحفظ العرض التقديمي
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```


## **Extract Raster Images from Picture Frames**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح المثال البرمجي أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG. 
```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```


## **Extract SVG Images from Picture Frames**

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) ، يتيح لك Aspose.Slides for .NET استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغتها الأصلية SVG.

يوضح المثال البرمجي التالي كيفية استخراج صورة SVG من إطار صورة:
```cs
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


## **Get Transparency of Image**

يتيح لك Aspose.Slides الحصول على تأثير الشفافية المطبّق على الصورة. يوضح لك هذا الكود C# العملية:
```c#
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


{{% alert color="primary" %}} 
يمكن العثور على جميع التأثيرات المطبقة على الصور في [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/). 
{{% /alert %}}

## **Picture Frame Formatting**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة لجعله يتوافق مع المتطلبات المحددة.

1. إنشاء مثيل من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class. 
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) بإضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبط بكائن العرض التقديمي والذي سيُستخدم لملء الشكل. 
4. تحديد عرض وارتفاع الصورة. 
5. إنشاء `PictureFrame` استنادًا إلى عرض وارتفاع الصورة من خلال طريقة [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) التي يوفّرها كائن [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection). 
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
7. تعيين لون حد إطار الصورة. 
8. تعيين عرض حد إطار الصورة. 
9. تدوير إطار الصورة بمنحه قيمة موجبة أو سالبة. 
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة. 
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
11. كتابة العرض التقديمي المعدل كملف PPTX. 

يوضح لك هذا الكود C# عملية تنسيق إطار الصورة:
```c#
// ينشئ كائن فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يقوم بتحميل صورة ويضيفها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بارتفاع وعرض الصورة المتساويين
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيق على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يحفظ العرض التقديمي إلى ملف PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}

طوّرت Aspose مؤخرًا [صانع كولاج مجاني](https://products.aspose.app/slides/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **Add Image as Link**

لتقليل حجم العروض التقديمية الكبيرة، يمكنك إضافة الصور (أو الفيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح لك هذا الكود C# كيفية إضافة صورة وفيديو إلى عنصر نائب:
```c#
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


## **Crop Image**

يظهر لك هذا الكود C# كيفية قص صورة موجودة على شريحة:
```c#
using (Presentation presentation = new Presentation())
{
    // ينشئ كائن صورة جديد
    IImage image = Images.FromFile(imagePath);
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


## **Delete Cropped Areas of Picture**

إذا أردت حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن هناك حاجة للقص.

يظهر لك هذا الكود C# العملية:
```c#
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


{{% alert title="NOTE" color="warning" %}} 

طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تُضيف الصورة المقصوصة إلى مجموعة صور العرض التقديمي. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض التقديمي. خلاف ذلك، سيزيد عدد الصور في العرض الناتج.

تحوّل هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}}

## **Compress Image**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/). 
تضغط هذه الطريقة الصورة بتقليل حجمها بناءً على حجم الشكل والدقة المحددة، مع خيار حذف المناطق المقصوصة. 

تُعدل حجم الصورة ودقتها بطريقة مشابهة لميزة PowerPoint **Picture Format → Compress Pictures → Resolution**. 

تُظهر الأمثلة البرمجية التالية كيفية ضغط صورة في عرض تقديمي بتحديد دقة مستهدفة وحذف المناطق المقصوصة اختياريًا:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على إطار الصورة من الشريحة
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وحذف المناطق المقصوصة
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // تحقق من نتيجة الضغط
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }
}
```


أو باستخدام قيمة DPI مخصصة مباشرة:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة إلى 150 DPI (دقة الويب)، مع حذف المناطق المقصوصة
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 

تحوّل الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف. إذا كانت الصورة ملف ميتافايل (WMF/EMF) أو SVG، لن يتم تطبيق الضغط. كما تُحافظ جودة JPEG أو تُقللها قليلًا بناءً على الدقة، كما تفعل PowerPoint مع JPEG عالي الدقة. 
{{% /alert %}}

## **Lock Aspect Ratio**

إذا أردت أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام الخاصية [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) لتعيين إعداد *Lock Aspect Ratio*. 

يوضح لك هذا الكود C# كيفية تأمين نسبة أبعاد الشكل:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // يضبط الشكل للحفاظ على نسبة الأبعاد عند تغيير الحجم
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 

إعداد *Lock Aspect Ratio* هذا يحافظ فقط على نسبة أبعاد الشكل وليس على الصورة التي يحتويها. 
{{% /alert %}}

## **Use StretchOff Property**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و[StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat)، يمكنك تحديد مستطيل ملء. 

عند تحديد تمديد لصورة، يتم تحجيم مستطيل المصدر ليتناسب مع مستطيل الملء المحدد. يُعرّف كل حافة من حواف مستطيل الملء بنسبة إزاحة من الحافة المقابلة لمربع حدود الشكل. النسبة الموجبة تمثل تقليصًا داخلياً بينما النسبة السالبة تمثل توسعًا خارجيًا. 

1. إنشاء مثيل من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class. 
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. إضافة شكل مستطيل `AutoShape`. 
4. إنشاء صورة. 
5. تعيين نوع ملء الشكل. 
6. تعيين نمط ملء صورة الشكل. 
7. إضافة مجموعة صورة لملء الشكل. 
8. تحديد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل. 
9. كتابة العرض التقديمي المعدل كملف PPTX. 

يوضح لك هذا الكود C# عملية استخدام خاصية StretchOff:
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // يضبط الصورة لتُمدّ من كل جانب في جسم الشكل
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**كيف يمكنني معرفة تنسيقات الصور المدعومة لإطار الصورة؟**  
يدعم Aspose.Slides كل من الصور النقطية (PNG, JPEG, BMP, GIF, إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصّص لـ[PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). عادةً ما تتقاطع قائمة التنسيقات المدعومة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX وأدائه؟**  
تؤدي تضمين الصور الكبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد على تقليل حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني تأمين كائن الصورة من التحريك/التغيير غير المقصود؟**  
استخدم أقفال الشكل ([shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/)) لإطار الصورة (مثلاً، تعطيل التحريك أو تغيير الحجم). يُوضّح آلية القفل للأشكال في مقالة الحماية المستقلة [protection article](/slides/ar/net/applying-protection-to-presentation/) وتُدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة المتجهات SVG عند تصدير العرض التقديمي إلى PDF/صور؟**  
يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) كمتجه أصلي. عند التصدير إلى PDF (/slides/ar/net/convert-powerpoint-to-pdf/) أو صيغ نقطية (/slides/ar/net/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطي حسب إعدادات التصدير؛ يبقى وجود SVG كمتجه مؤكدًا من سلوك الاستخراج.