---
title: مدیریت چارچوب‌های تصویر در ارائه‌ها در .NET
linktitle: چارچوب تصویر
type: docs
weight: 10
url: /fa/net/picture-frame/
keywords:
- چارچوب تصویر
- اضافه‌کردن چارچوب تصویر
- ایجاد چارچوب تصویر
- اضافه‌کردن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستر
- تصویر برداری
- برش تصویر
- ناحیه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی چارچوب تصویر
- خصوصیات چارچوب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت عرض به ارتفاع
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اضافه کردن چارچوب‌های تصویر به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET. جریان کاری خود را ساده کنید و طراحی اسلایدها را بهبود ببخشید."
---
## **معرفی**

یک چارچوب تصویر شکل است که حاوی یک تصویر می‌باشد—مانند یک تصویر در چارچوب.  

می‌توانید یک تصویر را از طریق یک چارچوب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی چارچوب تصویر فرمت کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به افراد امکان می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند. 

{{% /alert %}} 

## **ایجاد یک چارچوب تصویر**

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید. 
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید. 
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) مرتبط با شیء presentation که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید. 
4. عرض و ارتفاع تصویر را مشخص کنید. 
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء shape مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید. 
6. یک چارچوب تصویر (حاوی تصویر) را به اسلاید اضافه کنید. 
7. ارائه‌ی اصلاح شده را به صورت فایل PPTX بنویسید. 

این کد C# نشان می‌دهد چگونه یک چارچوب تصویر ایجاد کنید:

```c#
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation pres = new Presentation())
{
    // اسلاید اول را دریافت می‌کند
    ISlide slide = pres.Slides[0];

    // یک تصویر را بارگذاری می‌کند و آن را به مجموعه تصاویر ارائه اضافه می‌نماید
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // یک چارچوب تصویر با همان ارتفاع و عرض اضافه می‌کند
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // برخی قالب‌بندی‌ها را بر روی چارچوب تصویر اعمال می‌کند
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // ارائه را به یک فایل PPTX می‌نویسد
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

چارچوب‌های تصویر به شما اجازه می‌دهند به سرعت اسلایدهای ارائه مبتنی بر تصاویر ایجاد کنید. وقتی چارچوب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر دستکاری کنید. ممکن است این صفحات برای شما مفید باشند: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/), تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/), تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/). 

{{% /alert %}}

## **ایجاد یک چارچوب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی تصویر، می‌توانید یک چارچوب تصویر پیچیده‌تر ایجاد کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید. 
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید. 
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید. 
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) مرتبط با شیء presentation که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید. 
5. عرض و ارتفاع نسبی تصویر را در چارچوب تصویر مشخص کنید. 
6. ارائه‌ی اصلاح شده را به صورت فایل PPTX بنویسید. 

این کد C# نشان می‌دهد چگونه یک چارچوب تصویر با مقیاس نسبی ایجاد کنید:

```c#
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // یک تصویر را بارگذاری می‌کند و آن را به مجموعه تصاویر ارائه اضافه می‌نماید
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // یک چارچوب تصویر را به اسلاید اضافه می‌کند
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // عرض و ارتفاع مقیاس نسبی را تنظیم می‌کند
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // ارائه را ذخیره می‌کند
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **استخراج تصاویر رستر از چارچوب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe) استخراج کنید و در فرمت‌های PNG، JPG و سایر فرمت‌ها ذخیره نمایید. مثال کد زیر نشان می‌دهد چگونه تصویری را از سند «sample.pptx» استخراج کرده و در فرمت PNG ذخیره کنید.

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

## **استخراج تصاویر SVG از چارچوب‌های تصویر**

هنگامی که یک ارائه شامل گرافیک‌های SVG قرار گرفته در شکل‌های [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) باشد، Aspose.Slides برای .NET به شما امکان می‌دهد تا تصاویر برداری اصلی را با تمام دقت استخراج کنید. با پیمایش مجموعه شکل‌های اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) زیرین محتویات SVG دارد یا نه، و سپس آن تصویر را به صورت فایل SVG بومی روی دیسک یا به‌صورت جریان ذخیره کنید.

کد نمونه زیر نشان می‌دهد چگونه یک تصویر SVG را از یک چارچوب تصویر استخراج کنید:

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

## **دریافت شفافیت تصویر**

Aspose.Slides به شما امکان می‌دهد اثر شفافیت اعمال‌شده بر یک تصویر را دریافت کنید. این کد C# عملیات را نشان می‌دهد:

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

## **دریافت روشنایی و کنتراست تصویر**

Aspose.Slides به شما امکان می‌دهد روشنایی و کنتراست اثر اعمال‌شده بر یک تصویر را دریافت کنید. رابط [ILuminance](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iluminance/) این اثر تبدیل تصویر را نشان می‌دهد.

این کد C# نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک چارچوب تصویر دریافت کنید:

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
تمام اثرات اعمال‌شده بر تصاویر را می‌توانید در [Aspose.Slides.Effects](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/) پیدا کنید. 
{{% /alert %}}

## **قالب‌بندی چارچوب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را که می‌توان به یک چارچوب تصویر اعمال کرد، ارائه می‌دهد. با استفاده از این گزینه‌ها می‌توانید چارچوب تصویر را به‌گونه‌ای تغییر دهید که با نیازهای خاص شما منطبق شود.

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید. 
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید. 
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) مرتبط با شیء presentation که برای پر کردن شکل استفاده خواهد شد، ایجاد کنید. 
4. عرض و ارتفاع تصویر را مشخص کنید. 
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](http://www.aspose.com/api/net/slides/fa/aspose.slides/ishapecollection/methods/addpictureframe) که توسط شیء [IShapes](http://www.aspose.com/api/net/slides/fa/aspose.slides/ishapecollection) مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید. 
6. چارچوب تصویر (حاوی تصویر) را به اسلاید اضافه کنید. 
7. رنگ خط چارچوب تصویر را تنظیم کنید. 
8. ضخامت خط چارچوب تصویر را تنظیم کنید. 
9. چارچوب تصویر را با مقدار مثبت یا منفی چرخانید. 
   * مقدار مثبت تصویر را ساعت‌گرد می‌چرخاند. 
   * مقدار منفی تصویر را پادساعت‌گرد می‌چرخاند. 
10. چارچوب تصویر (حاوی تصویر) را به اسلاید اضافه کنید. 
11. ارائه‌ی اصلاح شده را به صورت فایل PPTX بنویسید. 

این کد C# فرآیند قالب‌بندی چارچوب تصویر را نشان می‌دهد:

```c#
 // یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت می‌کند
    ISlide slide = presentation.Slides[0];

    // یک تصویر را بارگذاری می‌کند و آن را به مجموعه تصاویر ارائه اضافه می‌نماید
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // یک چارچوب تصویر با همان ارتفاع و عرض تصویر اضافه می‌کند
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // برخی قالب‌بندی‌ها را بر روی چارچوب تصویر اعمال می‌کند
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // ارائه را به یک فایل PPTX می‌نویسد
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose اخیراً یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر ever نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG داشته باشید، یا [ایجاد شبکه‌های تصویری](https://products.aspose.app/slides/fa/collage/photo-grid)، می‌توانید از این سرویس استفاده کنید. 

{{% /alert %}}

## **افزودن تصویر به عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه‌ها، می‌توانید تصاویر (یا ویدیوها) را از طریق لینک‌ها اضافه کنید به‌جای اینکه فایل‌ها را مستقیماً در ارائه‌ها جاسازی کنید. این کد C# نشان می‌دهد چگونه یک تصویر و ویدیو را به یک جایگذاشتن اضافه کنید:

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

## **قاب‌بندی تصاویر**

این کد C# نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:

```c#
using (Presentation presentation = new Presentation())
{
    // یک شیء تصویر جدید ایجاد می‌کند
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // یک PictureFrame به اسلاید اضافه می‌کند
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // تصویر را برش می‌دهد (مقادیر درصدی)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // نتیجه را ذخیره می‌کند
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **حذف نواحی برش‌خورده تصویر**

اگر می‌خواهید نواحی برش‌خورده یک تصویر موجود در یک چارچوب را حذف کنید، می‌توانید از متد [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را برمی‌گرداند اگر برش ضروری نباشد.

این کد C# عملیات را نشان می‌دهد:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // چارچوب تصویر را از اسلاید اول دریافت می‌کند
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // نواحی برش‌خورده تصویر چارچوب تصویر را حذف کرده و تصویر برش‌خورده را برمی‌گرداند
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

متد [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند اندازه ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه‌ی نهایی افزایش خواهد یافت. 

این متد در عملیات برش، فایل‌های متا‌فایل WMF/EMF را به تصویر رستر PNG تبدیل می‌کند. 

{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر را در ارائه با استفاده از متد [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/compressimage/) فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس اندازه شکل و وضوح مشخص‌شده، و با گزینه حذف نواحی برش‌خورده، فشرده می‌کند. 

این روش اندازه و وضوح تصویر را مشابه ویژگی **Picture Format → Compress Pictures → Resolution** در PowerPoint تنظیم می‌کند. 

کدهای C# زیر نشان می‌دهند چگونه با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش‌خورده، یک تصویر را در ارائه فشرده کنید:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌نماید.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // نتیجه فشرده‌سازی را بررسی کنید.
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

یا با استفاده مستقیم از مقدار DPI دلخواه:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // تصویر را به 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌نماید.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

این متد تصویر را بر اساس اندازه شکل و DPI ارائه‌شده به وضوح پایین‌تر تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند حذف شوند تا اندازه فایل بهینه شود. اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نخواهد شد. همچنین کیفیت JPEG بسته به وضوح حفظ یا کمی کاهش می‌یابد، مشابه رفتار PowerPoint برای JPEGهای با وضوح بالا. 

{{% /alert %}}

## **قفل کردن نسبت عرض به ارتفاع**

اگر می‌خواهید شکلی که شامل یک تصویر است حتی پس از تغییر ابعاد تصویر، نسبت عرض به ارتفاع خود را حفظ کند، می‌توانید از ویژگی [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframelock/aspectratiolocked/) برای تنظیم ویژگی *Lock Aspect Ratio* استفاده کنید. 

این کد C# نشان می‌دهد چگونه نسبت عرض به ارتفاع یک شکل را قفل کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // شکل را برای حفظ نسبت عرض به ارتفاع هنگام تغییر اندازه تنظیم می‌کند
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* تنها نسبت عرض به ارتفاع شکل را حفظ می‌کند و تصویر داخل آن را تحت تأثیر قرار نمی‌دهد. 

{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat) می‌توانید یک مستطیل پرکننده را مشخص کنید. 

زمانی که کشش برای یک تصویر مشخص می‌شود، یک مستطیل منبع به اندازه مستطیل پرکننده مقیاس می‌شود. هر لبهٔ مستطیل پرکننده توسط درصدی نسبت به لبهٔ مربوطهٔ جعبه محدودهٔ شکل تعریف می‌شود. درصد مثبت یک حذف داخلی و درصد منفی یک گسترش خارجی را مشخص می‌کند.

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید. 
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید. 
3. یک مستطیل `AutoShape` اضافه کنید. 
4. یک تصویر ایجاد کنید. 
5. نوع پر کردن شکل را تنظیم کنید. 
6. حالت پر کردن تصویر شکل را تنظیم کنید. 
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید. 
8. افست‌های تصویر را از لبهٔ مربوطهٔ جعبه محدودهٔ شکل مشخص کنید. 
9. ارائه‌ی اصلاح شده را به صورت فایل PPTX بنویسید. 

این کد C# فرآیندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // تصویر را از هر طرف در بدنه شکل کشیده تنظیم می‌کند
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم کدام فرمت‌های تصویر برای PictureFrame پشتیبانی می‌شوند؟**

Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده معمولاً با توانمندی‌های موتور اسلاید و تبدیل تصویر همپوشانی دارد.

**اضافه کردن ده‌ها تصویر بزرگ چه تأثیری بر اندازه و عملکرد PPTX دارد؟**

جاسازی تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به کاهش حجم ارائه کمک می‌کند اما نیاز دارد فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides قابلیت افزودن تصاویر به‌صورت لینک برای کاهش حجم فایل را فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویر را از جابجایی/تغییر اندازه ناخواسته قفل کنم؟**

برای یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) می‌توانید از [قفل‌های شکل](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/pictureframelock/) استفاده کنید (مثلاً غیر فعال کردن جابجایی یا تغییر اندازه). مکانیسم قفل‌گذاری برای اشکال در مقالهٔ جداگانهٔ [محافظت](/slides/fa/net/applying-protection-to-presentation/) شرح داده شده و برای انواع مختلف اشکال از جمله [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا صحت برداری SVG هنگام خروجی به PDF/تصاویر حفظ می‌شود؟**

Aspose.Slides امکان استخراج یک SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) به‌صورت بردار اصلی را فراهم می‌کند. هنگام خروجی به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/) یا [فرمت‌های رستر](/slides/fa/net/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات خروجی رستر شود؛ این که SVG اصلی به‌صورت بردار ذخیره شده است توسط رفتار استخراج تأیید می‌شود.