---
title: إطار الصورة
type: docs
weight: 10
url: /net/picture-frame/
keywords: 
- إضافة إطار الصورة
- إنشاء إطار الصورة
- إضافة صورة
- إنشاء صورة
- استخراج صورة
- خاصية StretchOff
- تنسيق إطار الصورة
- خصائص إطار الصورة
- عرض PowerPoint
- C#
- Csharp
- Aspose.Slides for .NET
description: "إضافة إطار الصورة إلى عرض PowerPoint باستخدام C# أو .NET"
---

إطار الصورة هو شكل يحتوي على صورة، إنه مثل صورة داخل إطار.

يمكنك إضافة صورة إلى شريحة من خلال إطار الصورة. بهذه الطريقة، يمكنك تنسيق الصورة من خلال تنسيق إطار الصورة.

{{% alert title="نصيحة" color="primary" %}} 

توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—التي تسمح للناس بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

## **إنشاء إطار صورة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. قم بإنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. قم بإنشاء [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) بناءً على عرض الصورة وارتفاعها من خلال طريقة `AddPictureFrame` التي تم توفيرها بواسطة كائن الشكل المرتبط بالشريحة المرجعية.
6. أضف إطار صورة (يحتوي على الصورة) إلى الشريحة.
7. اكتب العرض المعدل كملف PPTX.

يوضح كود C# هذا كيفية إنشاء إطار صورة:

```c#
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
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

تسمح لك إطارات الصور بإنشاء شرائح عرض تقديمي بسرعة بناءً على الصور. عند دمج إطار الصورة مع خيارات الحفظ من Aspose.Slides، يمكنك التحكم في عمليات الإدخال/الإخراج لتحويل الصور من تنسيق إلى آخر. قد ترغب في رؤية هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **إنشاء إطار صورة بمقياس نسبي**

من خلال تغيير تدرج الصورة النسبي، يمكنك إنشاء إطار صورة أكثر تعقيدًا.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. أضف صورة إلى مجموعة صور العرض.
4. قم بإنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
5. حدد عرض الصورة وارتفاعها النسبي في إطار الصورة.
6. اكتب العرض المعدل كملف PPTX.

يوضح كود C# هذا كيفية إنشاء إطار صورة بمقياس نسبي:

```c#
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
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
    presentation.Save("إضافة إطار صورة بمقياس نسبي_out.pptx", SaveFormat.Pptx);
}
```

## **استخراج صورة من إطار الصورة**

يمكنك استخراج الصور من كائنات [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) وحفظها في تنسيقات PNG وJPG وتنسيقات أخرى. توضح مثال الشفرة أدناه كيفية استخراج صورة من الوثيقة "sample.pptx" وحفظها بتنسيق PNG.

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

## **الحصول على شفافية الصورة**

تسمح لك Aspose.Slides بالحصول على شفافية الصورة. يوضح كود C# هذا العملية:

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("شفافية الصورة: " + transparencyValue);
        }
    }
}
```

## **تنسيق إطار الصورة**

تقدم Aspose.Slides العديد من خيارات التنسيق التي يمكن تطبيقها على إطار الصورة. باستخدام هذه الخيارات، يمكنك تعديل إطار الصورة ليتناسب مع متطلبات محددة.

1. قم بإنشاء مثيل من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. قم بإنشاء كائن [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) عن طريق إضافة صورة إلى [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) المرتبطة بكائن العرض الذي سيتم استخدامه لملء الشكل.
4. حدد عرض الصورة وارتفاعها.
5. قم بإنشاء `PictureFrame` بناءً على عرض الصورة وارتفاعها من خلال طريقة [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) التي تم توفيرها بواسطة كائن [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) المرتبط بالشريحة المرجعية.
6. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
7. حدد لون خط إطار الصورة.
8. حدد عرض خط إطار الصورة.
9. قم بتدوير إطار الصورة بإعطائه قيمة إيجابية أو سلبية.
   * القيمة الإيجابية تدور الصورة في اتجاه عقارب الساعة. 
   * القيمة السلبية تدور الصورة عكس اتجاه عقارب الساعة.
10. أضف إطار الصورة (الذي يحتوي على الصورة) إلى الشريحة.
11. اكتب العرض المعدل كملف PPTX.

يوضح كود C# هذا عملية تنسيق إطار الصورة:

```c#
// ينشئ مثيل من فئة Presentation التي تمثل ملف PPTX
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يحمل صورة ويضيفها إلى مجموعة صور العرض
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة بأبعاد الصورة المتساوية
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // يطبق بعض التنسيق على إطار الصورة
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // يكتب العرض إلى ملف PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

طورت Aspose مؤخرًا [صانع الكولاج المجاني](https://products.aspose.app/slides/collage). إذا كنت بحاجة إلى [دمج صور JPG/JPEG](https://products.aspose.app/slides/collage/jpg) أو صور PNG، [إنشاء شبكات من الصور](https://products.aspose.app/slides/collage/photo-grid)، يمكنك استخدام هذه الخدمة. 

{{% /alert %}}

## **إضافة صورة كرابط**

لتجنب أحجام العروض الكبيرة، يمكنك إضافة صور (أو مقاطع فيديو) من خلال روابط بدلاً من إدخال الملفات مباشرة في العروض. يظهر كود C# هذا كيفية إضافة صورة وفيديو إلى عنصر نائب:

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

## **قص الصورة**

يوضح كود C# هذا كيفية قص صورة موجودة على شريحة:

```c#
using (Presentation presentation = new Presentation())
{
    // ينشئ كائن صورة جديدة
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى شريحة
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // يقص الصورة (قيمة النسبة المئوية)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // يحفظ النتيجة
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **حذف المناطق المقصوصة من الصورة**

إذا كنت ترغب في حذف المناطق المقصوصة من صورة موجودة في إطار، يمكنك استخدام طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). تعيد هذه الطريقة الصورة المقصوصة أو الصورة الأصلية إذا كان القص غير ضروري.

يظهر كود C# هذا العملية:

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

{{% alert title="ملاحظة" color="warning" %}} 

تضيف طريقة [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) الصورة المقصوصة إلى مجموعة صور العرض. إذا كانت الصورة مستخدمة فقط في [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) المعالج، يمكن أن يقلل هذا الإعداد من حجم العرض. خلاف ذلك، سيزداد عدد الصور في العرض الناتج.

تحول هذه الطريقة ملفات WMF/EMF الميتافايل إلى صورة PNG نقطية في عملية القص.

{{% /alert %}}

## **قفل نسبة العرض إلى الارتفاع**

إذا كنت ترغب في أن يحتفظ الشكل الذي يحتوي على صورة بنسبة العرض إلى الارتفاع حتى بعد تغيير أبعاد الصورة، يمكنك استخدام خاصية [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) لضبط إعداد *قفل نسبة العرض إلى الارتفاع*. 

يوضح كود C# هذا كيفية قفل نسبة العرض إلى الارتفاع لشكل:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // يعين الشكل للاحتفاظ بنسبة العرض إلى الارتفاع عند تغيير الحجم
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="ملاحظة" color="warning" %}} 

يحتفظ إعداد *قفل نسبة العرض إلى الارتفاع* فقط بالنسبة إلى العرض إلى الارتفاع للشكل وليس الصورة التي تحتوي عليها.

{{% /alert %}}

## **استخدام خاصية StretchOff**

باستخدام الخصائص [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight,](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و[StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) وفئة [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat)، يمكنك تحديد مستطيل التعبئة. 

عند تحديد التمديد لصورة، يتم توسيع مستطيل المصدر ليتناسب مع مستطيل التعبئة المحدد. يتم تعريف كل حافة من مستطيل التعبئة بنسيج مئوي من الحافة المقابلة لصندوق الحدود للشكل. تحدد النسبة المئوية الإيجابية نطاقًا في حين تحدد النسبة المئوية السلبية نطاقًا خارجيًا.

1. قم بإنشاء مثيل من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف شكل مستطيل `AutoShape`. 
4. قم بإنشاء صورة.
5. اضبط نوع تعبئة الشكل.
6. اضبط وضع تعبئة الصورة للشكل.
7. أضف صورة محددة لملء الشكل.
8. حدد تعويضات الصورة من الحافة المقابلة لصندوق الحدود للشكل.
9. اكتب العرض المعدل كملف PPTX.

يوضح كود C# هذا عملية تستخدم فيها خاصية StretchOff:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // يحدد الصورة المنبثقة من كل جانب في جسم الشكل
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```