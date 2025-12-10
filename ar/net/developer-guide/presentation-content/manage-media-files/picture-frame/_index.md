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
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- صورة نقطية
- صورة متجهة
- قص صورة
- منطقة مقطوعة
- خاصية StretchOff
- تنسيق إطار صورة
- خصائص إطار صورة
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
description: "أضف إطارات الصور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. سهل سير عملك وحسّن تصميم الشرائح."
---

إطار الصورة هو شكل يحتوي على صورة—إنه مثل صورة داخل إطار.  

يمكنك إضافة صورة إلى شريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.  

{{% alert title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تسمح للأشخاص بإنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. احصل على مرجع الشريحة من خلال فهرسها.  
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.  
4. حدد عرض وارتفاع الصورة.  
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) بناءً على عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` التي يُظهرها كائن الشكل المرتبط بالشريحة المشار إليها.  
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.  
7. احفظ العرض التقديمي المعدل كملف PPTX.  

يظهر لك هذا الكود C# كيفية إنشاء إطار صورة:  
```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض التقديمي
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

    // يكتب العرض التقديمي إلى ملف PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="warning" %}} 
تسمح لك إطارات الصورة بإنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات حفظ Aspose.Slides، يمكنك معالجة عمليات الإدخال/الإخراج لتحويل الصور من صيغة إلى أخرى. قد ترغب في مشاهدة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), تحويل [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), تحويل [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 
{{% /alert %}} 

## **إنشاء إطار صورة مع مقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.  

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. احصل على مرجع الشريحة من خلال فهرسها.  
3. أضف صورة إلى مجموعة صور العرض التقديمي.  
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.  
5. حدد العرض والارتفاع النسبيين للصورة في إطار الصورة.  
6. احفظ العرض التقديمي المعدل كملف PPTX.  

يظهر لك هذا الكود C# كيفية إنشاء إطار صورة مع مقياس نسبي:  
```c#
// إنشاء كائن الفئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // تحميل صورة وإضافتها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // إضافة إطار صورة إلى الشريحة
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // تعيين عرض وارتفاع المقياس النسبي
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // حفظ العرض التقديمي
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```


## **استخراج الصور النقطية من إطارات الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) وحفظها بصيغ PNG، JPG، وغيرها. يُظهر مثال الكود أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.  
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

عندما يحتوي عرض تقديمي على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/)، تسمح لك Aspose.Slides for .NET باستخراج الصور المتجهة الأصلية بجودة كاملة. عبر استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame]، والتحقق مما إذا كان [IPPImage] الأساسي يحتوي محتوى SVG، ثم حفظ تلك الصورة على القرص أو في تدفق بصيغتها الأصلية SVG.  

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

تتيح لك Aspose.Slides الحصول على تأثير الشفافية المطبق على صورة. يوضح هذا الكود C# العملية:  
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

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار صورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتوافق مع المتطلبات المحددة.  

1. إنشاء مثيل من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).  
2. احصل على مرجع الشريحة من خلال فهرسها.  
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض التقديمي والذي سيُستخدم لملء الشكل.  
4. حدد عرض وارتفاع الصورة.  
5. إنشاء `PictureFrame` بناءً على عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) التي يُظهرها كائن [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) المرتبط بالشريحة المشار إليها.  
6. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.  
7. ضبط لون حد إطار الصورة.  
8. ضبط عرض حد إطار الصورة.  
9. تدوير إطار الصورة بإعطائه قيمة إيجابية أو سلبية.  
   * قيمة إيجابية تدور الصورة باتجاه عقارب الساعة.  
   * قيمة سلبية تدور الصورة عكس اتجاه عقارب الساعة.  
10. أضف إطار الصورة (يحتوي على الصورة) إلى الشريحة.  
11. احفظ العرض التقديمي المعدل كملف PPTX.  

يظهر لك هذا الكود C# عملية تنسيق إطار الصورة:  
```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض التقديمي
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

    // يكتب العرض التقديمي إلى ملف PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 
طورت Aspose مؤخرًا أداة [Collage Maker](https://products.aspose.app/slides/collage) مجانية. إذا احتجت إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة. 
{{% /alert %}} 

## **إضافة صورة كرابط**

لتقليل حجم العرض التقديمي، يمكنك إضافة صور (أو فيديوهات) عبر روابط بدلاً من تضمين الملفات مباشرة في العروض. يوضح هذا الكود C# كيفية إضافة صورة وفيديو إلى عنصر نائب:  
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


## **قص الصور**

يظهر لك هذا الكود C# كيفية قص صورة موجودة على شريحة:  
```c#
using (Presentation presentation = new Presentation())
{
    // ينشئ كائن صورة جديد
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى شريحة
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


## **حذف المناطق المقطوعة من الصورة**

إذا كنت ترغب في حذف المناطق المقطوعة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تُعيد هذه الطريقة الصورة المقطوعة أو الصورة الأصلية إذا لم يكن هناك حاجة للقص.  
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يحصل على إطار الصورة من الشريحة الأولى
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // يحذف المناطق المقطوعة من صورة إطار الصورة ويرجع الصورة المقطوعة
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // يحفظ النتيجة
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```


{{% alert title="ملاحظة" color="warning" %}} 
تضيف طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) الصورة المقطوعة إلى مجموعة صور العرض التقديمي. إذا استُخدمت الصورة فقط في [PictureFrame] المعالجة، يمكن لهذا الإعداد تقليل حجم العرض التقديمي. وإلا سيزداد عدد الصور في العرض الناتج.  

تحول هذه الطريقة ملفات WMF/EMF إلى صورة PNG نقطية أثناء عملية القص. 
{{% /alert %}} 

## **ضغط الصور**

يمكنك ضغط صورة في عرض تقديمي باستخدام طريقة [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/). تُقلص هذه الطريقة حجم الصورة بناءً على حجم الشكل والدقة المحددة، مع إمكانية حذف المناطق المقطوعة.  

تُعدِّل حجم الصورة ودقتها بطريقة مشابهة لميزة PowerPoint **Picture Format → Compress Pictures → Resolution**.  

يظهر الأمثلة التالية في C# كيفية ضغط صورة في عرض تقديمي بتحديد دقة هدف وحذف المناطق المقطوعة إذا رغبت:  
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على إطار الصورة من الشريحة
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقطوعة
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

    // ضغط الصورة إلى 150 DPI (دقة الويب)، وإزالة المناطق المقطوعة
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="ملاحظة" color="warning" %}} 
تحول الطريقة الصورة إلى دقة أقل بناءً على حجم الشكل وDPI المحدد. يمكن أيضًا حذف المناطق المقطوعة لتحسين حجم الملف. إذا كانت الصورة ملف ميتا (WMF/EMF) أو SVG، لن تُطبق عملية الضغط. كما يُحافظ على جودة JPEG أو تُقللها قليلًا حسب الدقة، كما تفعل PowerPoint مع JPEG عالي الدقة. 
{{% /alert %}} 

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعادها حتى بعد تغيير أبعاد الصورة، يمكنك استخدام خاصية [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) لتعيين إعداد *قفل نسبة الأبعاد*.  

يظهر لك هذا الكود C# كيفية قفل نسبة الأبعاد للشكل:  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // يضبط الشكل للحفاظ على نسبة الأبعاد عند التحجيم
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="ملاحظة" color="warning" %}} 
إعداد *قفل نسبة الأبعاد* يحافظ فقط على نسبة أبعاد الشكل ولا يؤثر على الصورة الموجودة داخله. 
{{% /alert %}} 

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و[StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) من الواجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat)، يمكنك تحديد مستطيل تعبئة.  

عند تحديد تمديد لصورة، يتم تحجيم المستطيل المصدر ليتناسب مع مستطيل التعبئة المحدد. يُعرّف كل حافة من حواف مستطيل التعبئة بنسبة إزاحة من الحافة المقابلة لمربع حدود الشكل. تُشير النسبة الموجبة إلى داخلية، والنسبة السلبية إلى خارجية.  

1. إنشاء مثيل من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .  
2. احصل على مرجع الشريحة من خلال فهرسها.  
3. إضافة مستطيل `AutoShape`.  
4. إنشاء صورة.  
5. ضبط نوع تعبئة الشكل.  
6. ضبط وضع تعبئة صورة الشكل.  
7. إضافة صورة لتعبئة الشكل.  
8. تحديد إزاحة الصورة من الحافة المقابلة لمربع حدود الشكل.  
9. احفظ العرض التقديمي المعدل كملف PPTX.  

يُظهر هذا الكود C# عملية استخدام خاصية StretchOff:  
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // يحدد تمدد الصورة من كل جانب داخل جسم الشكل
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة صيغ الصور التي يدعمها PictureFrame؟**  
يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المعين إلى [PictureFrame]. تتقاطع قائمة الصيغ المدعومة عادة مع قدرات محرك تحويل الشرائح والصور.

**كيف سيؤثر إضافة عدد كبير من الصور الكبيرة على حجم PPTX والأداء؟**  
تؤدي إدماج الصور الكبيرة إلى زيادة حجم الملف واستهلاك الذاكرة؛ ربط الصور يساعد على تقليل حجم العرض التقديمي لكنه يتطلب بقاء الملفات الخارجية متاحة. يوفر Aspose.Slides إمكانية إضافة الصور عبر رابط لتقليل حجم الملف.

**كيف يمكنني قفل كائن صورة لمنعه من النقل/التغيير غير المقصود؟**  
استخدم أقفال الأشكال ([shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/)) لـ [PictureFrame] (مثل تعطيل النقل أو إعادة التحجيم). توضح آلية القفل للأشكال في مقال الحماية المنفصل وتُدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame].

**هل يتم الحفاظ على دقة المتجهات في SVG عند تصدير العرض إلى PDF/صور؟**  
تتيح Aspose.Slides استخراج SVG من [PictureFrame] كمتجه أصلي. عند التصدير إلى PDF أو صيغ نقطية، قد يتم تحويل النتيجة إلى نقطية حسب إعدادات التصدير؛ يبقى وجود SVG كمتجه مؤكدًا من سلوك الاستخراج. 

