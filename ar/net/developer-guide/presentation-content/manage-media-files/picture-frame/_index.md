---
title: إدارة إطارات الصور في العروض التقديمية باستخدام .NET
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
description: "أضف إطارات صور إلى عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. سهل سير عملك وحسّن تصاميم الشرائح."
---
## **المقدمة**

الإطار هو شكل يحتوي على صورة—وهو مثل صورة داخل إطار.  

يمكنك إضافة صورة إلى الشريحة عبر إطار صورة. بهذه الطريقة، يمكنك تنسيق الصورة عن طريق تنسيق إطار الصورة.  

{{% alert  title="Tip" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور.  
{{% /alert %}} 

## **إنشاء إطار صورة**

1. إنشاء نسخة من فئة [Presentation ](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class.  
2. احصل على مرجع الشريحة عبر فهرستها.  
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.  
4. حدد عرض الصورة وارتفاعها.  
5. إنشاء [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe) استنادًا إلى عرض وارتفاع الصورة عبر طريقة `AddPictureFrame` التي ي exposeها كائن الشكل المرتبط بالشريحة المرجعية.  
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.  
7. احفظ العرض المعدل كملف PPTX.  

يعرض لك هذا الكود C# كيفية إنشاء إطار صورة:  

```c#
// يقوم بإنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بالارتفاع والعرض نفسه
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيق على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يكتب العرض إلى ملف PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
تتيح لك أطر الصورة إنشاء شرائح عرض بسرعة بناءً على الصور. عندما تجمع بين إطار الصورة وخيارات الحفظ في Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من صيغة إلى أخرى. قد ترغب في زيارة هذه الصفحات: تحويل [image to JPG](https://products.aspose.com/slides/ar/net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/ar/net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/ar/net/conversion/jpg-to-png/), تحويل [PNG to JPG](https://products.aspose.com/slides/ar/net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/ar/net/conversion/png-to-svg/), تحويل [SVG to PNG](https://products.aspose.com/slides/ar/net/conversion/svg-to-png/).  
{{% /alert %}} 

## **إنشاء إطار صورة بمقياس نسبي**

عن طريق تعديل مقياس الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.  

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation)class.  
2. احصل على مرجع الشريحة عبر فهرستها.  
3. إضافة صورة إلى مجموعة صور العرض.  
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.  
5. تحديد العرض والارتفاع النسبيين للصورة في إطار الصورة.  
6. احفظ العرض المعدل كملف PPTX.  

يعرض لك هذا الكود C# كيفية إنشاء إطار صورة بمقياس نسبي:  

```c#
// ينشئ فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يحدد عرض وارتفاع المقياس النسبي
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // يحفظ العرض
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **استخراج الصور النقطية من أطر الصورة**

يمكنك استخراج الصور النقطية من كائنات [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe) وحفظها بصيغة PNG أو JPG أو صيغ أخرى. يوضح مثال الكود أدناه كيفية استخراج صورة من المستند "sample.pptx" وحفظها بصيغة PNG.  

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

## **استخراج صور SVG من أطر الصورة**

عندما يحتوي عرض على رسومات SVG موضوعة داخل أشكال [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/)، تسمح لك Aspose.Slides for .NET باستعادة الصور المتجهة الأصلية مع الحفاظ الكامل على الجودة. من خلال استعراض مجموعة أشكال الشريحة، يمكنك تحديد كل [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/)، والتحقق مما إذا كان [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage/) الأساسي يحتوي على محتوى SVG، ثم حفظ تلك الصورة إلى قرص أو تدفق بصيغتها الأصلية SVG.  

الكود التالي يوضح كيفية استخراج صورة SVG من إطار صورة:  

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

## **الحصول على السطوع والتباين للصورة**

تتيح لك Aspose.Slides الحصول على تأثير السطوع والتباين المطبق على صورة. تمثل الواجهة [ILuminance](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/iluminance/) هذا التأثير التحويلي للصورة.  

يظهر هذا الكود C# كيفية الحصول على إعدادات السطوع والتباين من إطار صورة:  

```csharp
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

{{% alert color="primary" %}} 
يمكن العثور على جميع التأثيرات المطبقة على الصور في [Aspose.Slides.Effects](https://reference.aspose.com/slides/ar/net/aspose.slides.effects/).  
{{% /alert %}} 

## **تنسيق إطار الصورة**

توفر Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليناسب متطلبات معينة.  

1. إنشاء نسخة من فئة [Presentation](http://www.aspose.com/api/net/slides/ar/aspose.slides/)class.  
2. احصل على مرجع الشريحة عبر فهرستها.  
3. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيُستخدم لملء الشكل.  
4. تحديد عرض الصورة وارتفاعها.  
5. إنشاء `PictureFrame` استنادًا إلى عرض وارتفاع الصورة عبر طريقة [AddPictureFrame](http://www.aspose.com/api/net/slides/ar/aspose.slides/ishapecollection/methods/addpictureframe) التي ي exposeها كائن [IShapes](http://www.aspose.com/api/net/slides/ar/aspose.slides/ishapecollection) المرتبط بالشريحة المرجعية.  
6. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.  
7. تعيين لون خط إطار الصورة.  
8. تعيين عرض خط إطار الصورة.  
9. تدوير إطار الصورة بإعطائه قيمة موجبة أو سالبة.  
   * القيمة الموجبة تدير الصورة باتجاه عقارب الساعة.  
   * القيمة السالبة تدير الصورة عكس اتجاه عقارب الساعة.  
10. إضافة إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.  
11. احفظ العرض المعدل كملف PPTX.  

يعرض لك هذا الكود C# عملية تنسيق إطار الصورة:  

```c#
// ينشئ كائن فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بارتفاع وعرض الصورة المتطابقين
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيق على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يحفظ العرض إلى ملف PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 
قامت Aspose مؤخرًا بتطوير أداة [Collage Maker](https://products.aspose.app/slides/ar/collage) مجانية. إذا كنت تحتاج إلى دمج صور JPG/JPEG أو PNG، أو إنشاء شبكات من الصور، يمكنك استخدام هذه الخدمة.  
{{% /alert %}} 

## **إضافة صورة كارتباط**

لتقليل حجم العرض التقديمي، يمكنك إضافة الصور (أو الفيديوهات) من خلال روابط بدلاً من تضمين الملفات مباشرةً في العروض. يوضح هذا الكود C# كيفية إضافة صورة وفيديو إلى عنصر نائب:  

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

يظهر هذا الكود C# كيفية قص صورة موجودة على شريحة:  

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

    // يقص الصورة (قيم النسب المئوية)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // يحفظ النتيجة
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **حذف المناطق المقصوصة من الصورة**

إذا رغبت بحذف المناطق المقصوصة من صورة موجودة داخل إطار، يمكنك استخدام طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تُعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا لم يكن القَص ضروريًا.  

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
تضيف طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة تُستخدم فقط في [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/) المُعالجة، يمكن لهذا الإعداد تقليل حجم العرض. وإلا، سيزداد عدد الصور في العرض الناتج.  

تحول هذه الطريقة ملفات WMF/EMF إلى صور PNG نقطية أثناء عملية القَص.  
{{% /alert %}} 

## **ضغط الصور**

يمكنك ضغط صورة داخل عرض باستخدام طريقة [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat/compressimage/).  
تضغط هذه الطريقة الصورة عبر تقليل حجمها استنادًا إلى حجم الشكل والدقة المحددة، مع إمكانية حذف المناطق المقصوصة.  

تقوم بتعديل حجم الصورة ودقتها بطريقة مماثلة لميزة PowerPoint **Picture Format → Compress Pictures → Resolution**.  

توضح الأمثلة التالية بلغة C# كيفية ضغط صورة في عرض عن طريق تحديد دقة مستهدفة وحذف المناطق المقصوصة اختياريًا:  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة بدقة مستهدفة 150 DPI (دقة الويب) وإزالة المناطق المقصوصة.
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

أو باستخدام قيمة DPI مخصصة مباشرةً:  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // ضغط الصورة إلى 150 DPI (دقة الويب)، وإزالة المناطق المقصوصة.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
تحول الطريقة الصورة إلى دقة أقل استنادًا إلى حجم الشكل وDPI المقدم. يمكن أيضًا حذف المناطق المقصوصة لتحسين حجم الملف. إذا كانت الصورة ملفًا ميتاً (WMF/EMF) أو SVG، لن يتم تطبيق الضغط. كما يتم الحفاظ على جودة JPEG أو تقليلها قليلاً وفقًا للدقة، كما هو الحال في PowerPoint عند معالجة JPEG عالي الدقة.  
{{% /alert %}} 

## **قفل نسبة الأبعاد**

إذا رغبت في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة أبعاده حتى بعد تغيير أبعاد الصورة، يمكنك استخدام الخاصية [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframelock/aspectratiolocked/) لضبط إعداد *Lock Aspect Ratio*.  

يظهر لك هذا الكود C# كيفية قفل نسبة أبعاد الشكل:  

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

{{% alert title="NOTE" color="warning" %}} 
يحافظ هذا الإعداد *Lock Aspect Ratio* على نسبة أبعاد الشكل فقط ولا يؤثر على الصورة التي يحتويها.  
{{% /alert %}} 

## **استخدام خاصية StretchOff**

باستخدام خصائص [StretchOffsetLeft](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و[StretchOffsetBottom](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipicturefillformat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/picturefillformat)، يمكنك تحديد مستطيل ملئ.  

عند تحديد تمديد لصورة، يتم تحجيم مستطيل المصدر ليناسب مستطيل الملئ المحدد. يُعرّف كل حافة من حواف مستطيل الملئ بنسبة إزاحة من الحافة المقابلة لمربع حدود الشكل. النسبة الموجبة تحدد تقليلًا داخليًا، بينما النسبة السالبة تحدد تمديدًا خارجيًا.  

1. إنشاء نسخة من فئة [Presentation](http://www.aspose.com/api/net/slides/ar/aspose.slides/)class.  
2. احصل على مرجع الشريحة عبر فهرستها.  
3. إضافة مستطيل `AutoShape`.  
4. إنشاء صورة.  
5. تعيين نوع ملء الشكل.  
6. تعيين وضع ملء صورة الشكل.  
7. إضافة صورة للملء.  
8. تحديد إزاحات الصورة من الحافة المقابلة لمربع حدود الشكل.  
9. احفظ العرض المعدل كملف PPTX.  

يعرض لك هذا الكود C# عملية استخدام خاصية StretchOff:  

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // يضبط تمديد الصورة من كل جانب في جسم الشكل
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
يدعم Aspose.Slides كلًا من الصور النقطية (PNG، JPEG، BMP، GIF، إلخ) والصور المتجهة (مثل SVG) عبر كائن الصورة المخصص لـ[PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/). تتقاطع قائمة الصيغ المدعومة عمومًا مع إمكانات محرك تحويل الشرائح والصور.  

**كيف سيؤثر إضافة عشرات الصور الكبيرة على حجم وأداء ملف PPTX؟**  
تزيد تضمين الصور الكبيرة من حجم الملف واستهلاك الذاكرة؛ بينما يساعد ربط الصور على تقليل حجم العرض لكنه يتطلب بقاء الملفات الخارجية متوفرة. يوفر Aspose.Slides إمكانية إضافة الصور عبر روابط لتقليل حجم الملف.  

**كيف يمكنني قفل كائن صورة لمنع التحريك/إعادة التحجيم غير المقصود؟**  
استخدم [قفل الأشكال](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/pictureframelock/) لـ[PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/) (مثال: تعطيل التحريك أو التحجيم). يُشرح آلية القفل للأشكال في مقالة الحماية المستقلة [/slides/ar/net/applying-protection-to-presentation/] وتدعم أنواعًا متعددة من الأشكال بما فيها [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/).  

**هل يتم الحفاظ على دقة SVG المتجهة عند تصدير العرض إلى PDF/الصور؟**  
تتيح Aspose.Slides استخراج SVG من [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/) كمتجه أصلي. عند [التصدير إلى PDF](/slides/ar/net/convert-powerpoint-to-pdf/) أو [الصيغ النقطية](/slides/ar/net/convert-powerpoint-to-png/)، قد يتم تحويله إلى نقطية اعتمادًا على إعدادات التصدير؛ لكن سلوك الاستخراج يؤكد أن SVG الأصلي يبقى متجهًا.