---
title: إطار الصورة
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
- قص صورة
- خاصية StretchOff
- تنسيق إطار الصورة
- خصائص إطار الصورة
- تأثير الصورة
- نسبة الأبعاد
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "أضف إطار صورة إلى عرض تقديمي PowerPoint باستخدام C# أو .NET"
---

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار. 

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.

{{% alert  title="Tip" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
4. تحديد عرض الصورة وارتفاعها. 
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) بناءً على عرض الصورة وارتفاعها عبر طريقة `AddPictureFrame` التي يوفرها كائن الشكل المرتبط بالشريحة المرجعية. 
6. إضافة إطار صورة (الذي يحتوي على الصورة) إلى الشريحة. 
7. حفظ العرض المعدل كملف PPTX. 

يعرض لك هذا الكود C# كيفية إنشاء إطار صورة:
```c#
// ينشئ كائنًا من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // يقوم بتحميل صورة وإضافتها إلى مجموعة صور العرض
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

    // يحفظ العرض في ملف PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" %}} 
تتيح لك إطارات الصورة إنشاء شرائح عرض تقديمي بسرعة استنادًا إلى الصور. عند الجمع بين إطار الصورة وخيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في مراجعة الصفحات التالية: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 
{{% /alert %}}

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) . 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة صورة إلى مجموعة صور العرض. 
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة. 
6. حفظ العرض المعدل كملف PPTX. 

يعرض لك هذا الكود C# كيفية إنشاء إطار صورة بمقياس نسبي:
```c#
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يقوم بتحميل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يضبط العرض والارتفاع النسبيين
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // يحفظ العرض
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```


## **استخراج الصور النقطية من إطارات الصورة**

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


## **استخراج صور SVG من إطارات الصورة**

عند احتواء عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)، يتيح لك Aspose.Slides for .NET استرجاع الصور المتجهة الأصلية بجودة كاملة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) المتعلق يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى القرص أو إلى تدفق بصيغة SVG الأصلية. 

المثال التالي يوضح كيفية استخراج صورة SVG من إطار صورة:
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


## **الحصول على شفافية الصورة**

يتيح لك Aspose.Slides الحصول على تأثير الشفافية المطبق على الصورة. يوضح لك هذا الكود C# العملية:
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

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتوافق مع المتطلبات المحددة.

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) . 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل. 
4. تحديد عرض الصورة وارتفاعها. 
5. إنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها عبر طريقة [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) التي يوفرها كائن [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) المرتبط بالشريحة المرجعية. 
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
7. تحديد لون خط إطار الصورة. 
8. تحديد عرض خط إطار الصورة. 
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة. 
   * القيمة الموجبة تدور الصورة باتجاه عقارب الساعة. 
   * القيمة السالبة تدور الصورة عكس اتجاه عقارب الساعة. 
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة. 
11. حفظ العرض المعدل كملف PPTX. 

يعرض لك هذا الكود C# عملية تنسيق إطار الصورة:
```c#
// ينشئ كائناً من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بارتفاع وعرض مساويين للصورة
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيق على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يكتب العرض في ملف PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 
قامت Aspose مؤخرًا بتطوير [صانع كولاج مجاني](https://products.aspose.app/slides/collage). إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب أحجام العرض الكبيرة، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح لك هذا الكود C# كيفية إضافة صورة وفيديو إلى عنصر نائب:
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


## **اقتصاص الصورة**

يوضح لك هذا الكود C# كيفية اقتصاص صورة موجودة على شريحة:
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

    // يقص الصورة (قيم النسبة المئوية)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // يحفظ النتيجة
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```


## **حذف المناطق المقصوصة من الصورة**

إذا كنت ترغب في حذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) . ترجع هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القص ضروريًا.

يظهر هذا الكود C# العملية:
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
تضيف طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) المعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF الميتا إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}}

## **ضغط الصورة**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/). تقلل هذه الطريقة من حجم الصورة بناءً على حجم الشكل والدقة المحددة، مع إمكانية حذف المناطق المقصوصة.

تُعدِّل حجم الصورة ودقتها بطريقة مشابهة لميزة **Picture Format → Compress Pictures → Resolution** في PowerPoint.

المثال التالي يوضح كيفية ضغط صورة في عرض تقديمي بتحديد دقة مستهدفة وحذف المناطق المقصوصة اختياريًا:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على PictureFrame من الشريحة
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة
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


أو باستخدام قيمة DPI مخصصة مباشرةً:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة إلى 150 DPI (دقة الويب)، وإزالة المناطق المقصوصة
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 
تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتقليل حجم الملف. إذا كانت الصورة ملف ميتا (WMF/EMF) أو SVG، لا يتم تطبيق الضغط. كما يتم الحفاظ على جودة JPEG أو تقليلها قليلًا وفقًا للدقة، كما يحدث في PowerPoint مع JPEG عالي الدقة. 
{{% /alert %}}

## **قفل نسبة الأبعاد**

إذا أردت أن يحتفظ شكل يحتوي صورة بنسبة أبعاده حتى بعد تعديل أبعاد الصورة، يمكنك استخدام الخاصية [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) لتعيين إعداد *Lock Aspect Ratio*.

يعرض لك هذا الكود C# كيفية قفل نسبة أبعاد الشكل:
```c#
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


{{% alert title="NOTE" color="warning" %}} 
إعداد *Lock Aspect Ratio* يحافظ فقط على نسبة أبعاد الشكل وليس الصورة التي يحتويها. 
{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و[StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat)، يمكنك تحديد مستطيل تعبئة.

عند تحديد تمديد للصورة، يتم تحجيم مستطيل المصدر ليلائم مستطيل التعبئة المحدد. كل حافة من حواف مستطيل التعبئة تُحدَّد بنسبة مئوية من الحافة المقابلة لمربع حدود الشكل. النسبة المئوية الموجبة تعني داخلية، والسالبة تعني خارجية.

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) . 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. إضافة مستطيل `AutoShape`. 
4. إنشاء صورة. 
5. تحديد نوع تعبئة الشكل. 
6. تحديد وضع تعبئة الصورة للشكل. 
7. إضافة صورة لتعبئة الشكل. 
8. تحديد إزاحات الصورة من الحافة المقابلة لصندوق حدود الشكل. 
9. حفظ العرض المعدل كملف PPTX. 

يوضح لك هذا الكود C# عملية استخدام خاصية StretchOff:
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // يضبط تمدد الصورة من كل جانب في جسم الشكل
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة صيغ الصور المدعومة لإطار الصورة؟**

يدعم Aspose.Slides كل من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عادةً مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة العشرات من الصور الكبيرة على حجم PPTX والأداء؟**

تؤدي تضمين صور كبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ بينما تساعد الروابط على الحفاظ على حجم العرض منخفضًا لكنها تتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر الروابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن صورة لمنع تحريكه/تحجيمه عن طريق الخطأ؟**

استخدم [قفل الأشكال](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) لـ [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (مثل تعطيل التحريك أو التحجيم). يُوضح آلية القفل في مقالة الحماية الخاصة بالأشكال /slides/net/applying-protection-to-presentation/ وتدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).

**هل يتم الحفاظ على دقة المتجهات SVG عند تصدير العرض إلى PDF/صور؟**

يسمح Aspose.Slides باستخراج SVG من [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) كمتجه أصلي. عند **التصدير إلى PDF** (/slides/ar/net/convert-powerpoint-to-pdf/) أو **الصيغ النقطية** (/slides/ar/net/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطي حسب إعدادات التصدير؛ لكن يبقى SVG الأصلي محفوظًا كمتجه عند استخراج الصورة.