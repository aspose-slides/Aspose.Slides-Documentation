---
title: مدیریت قاب‌های تصویر در ارائه‌ها در .NET
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/net/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- افزودن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستر
- تصویر برداری
- برش تصویر
- ناحیه برش‌داده‌شده
- ویژگی StretchOff
- قالب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت طول به عرض
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET اضافه کنید. جریان کار خود را ساده‌سازی کنید و طراحی اسلایدها را بهبود بخشید."
---
## **مقدمه**

قاب تصویر یک شکل است که شامل یک تصویر می‌شود—مانند یک تصویر درون قاب.  

می‌توانید یک تصویر را از طریق یک قاب تصویر به یک اسلاید اضافه کنید. به این ترتیب، با قالب‌بندی قاب تصویر، تصویر را قالب‌بندی می‌کنید.

{{% alert  title="Tip" color="info" %}} 
Aspose مبدل‌های رایگانی را ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد امکان می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند. 
{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) ایجاد کنید با افزودن تصویری به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) که به شیء Presentation مرتبط است و برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع شده ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد C# نشان می‌دهد چگونه یک قاب تصویر ایجاد کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
using (Presentation pres = new Presentation())
{
    // دریافت اولین اسلاید
    ISlide slide = pres.Slides[0];

    // بارگذاری یک تصویر و افزودن آن به مجموعهٔ تصاویر ارائه
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // افزودن یک قاب تصویر با ارتفاع و عرض یکسان
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // اعمال برخی قالب‌بندی‌ها بر روی قاب تصویر
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // نوشتن ارائه به یک فایل PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
قاب‌های تصویر به شما امکان می‌دهند به سرعت اسلایدهای ارائه را بر پایهٔ تصاویر ایجاد کنید. وقتی قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر دستکاری کنید. ممکن است بخواهید این صفحات را مشاهده کنید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/), تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/), تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/). 
{{% /alert %}}

## **ایجاد یک قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی یک تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) ایجاد کنید با افزودن تصویری به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) که به شیء Presentation مرتبط است و برای پر کردن شکل استفاده خواهد شد.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد C# نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
using (Presentation presentation = new Presentation())
{
    // بارگذاری یک تصویر و افزودن آن به مجموعهٔ تصاویر ارائه
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // افزودن یک قاب تصویر به اسلاید
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // تنظیم نسبت مقیاس نسبی عرض و ارتفاع
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // ذخیرهٔ ارائه
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe) استخراج کرده و در قالب‌های PNG، JPG و سایر قالب‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند "sample.pptx" استخراج کرده و در قالب PNG ذخیره کنید.

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

## **استخراج تصاویر SVG از قاب‌های تصویر**

وقتی یک ارائه شامل گرافیک‌های SVG باشد که داخل شکل‌های [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides for .NET به شما اجازه می‌دهد تا تصاویر برداری اصلی را با تمام جزئیات بازگردانی کنید. با پیمایش مجموعهٔ شکل‌های اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) زیرین محتویات SVG دارد یا نه، و سپس آن تصویر را به صورت فایل یا جریان در قالب SVG اصلی ذخیره کنید.

مثال کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:

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

## **دریافت شفافیت تصویر**

Aspose.Slides به شما امکان می‌دهد اثر شفافیتی که بر روی یک تصویر اعمال شده است را دریافت کنید. این کد C# عملیات را نشان می‌دهد:

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

## **دریافت روشنایی و کنتراست تصویر**

Aspose.Slides به شما امکان می‌دهد اثر روشنایی و کنتراست که بر روی یک تصویر اعمال شده است را دریافت کنید. رابط [ILuminance](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iluminance/) این اثر تبدیل تصویر را نمایش می‌دهد.

این کد C# نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:

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
تمام اثرات اعمال‌شده به تصاویر را می‌توانید در [Aspose.Slides.Effects](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/) پیدا کنید. 
{{% /alert %}}

## **قالب‌بندی قاب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را که می‌توانند بر روی یک قاب تصویر اعمال شوند، ارائه می‌کند. با استفاده از این گزینه‌ها، می‌توانید قاب تصویر را طوری تغییر دهید که با نیازهای خاص شما منطبق شود.

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) ایجاد کنید با افزودن تصویری به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) که به شیء Presentation مرتبط است و برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](http://www.aspose.com/api/net/slides/fa/aspose.slides/ishapecollection/methods/addpictureframe) که توسط شیء [IShapes](http://www.aspose.com/api/net/slides/fa/aspose.slides/ishapecollection) مرتبط با اسلاید مرجع شده ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی بچرخانید.  
   * مقدار مثبت تصویر را ساعت‌گرد می‌چرخاند.  
   * مقدار منفی تصویر را ضد ساعت‌گرد می‌چرخاند.  
10. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
11. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد C# فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
using (Presentation presentation = new Presentation())
{
    // دریافت اولین اسلاید
    ISlide slide = presentation.Slides[0];

    // بارگذاری یک تصویر و افزودن آن به مجموعهٔ تصاویر ارائه
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // افزودن یک قاب تصویر با ارتفاع و عرض مساوی تصویر
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // اعمال برخی قالب‌بندی‌ها بر روی قاب تصویر
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // نوشتن ارائه به یک فایل PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 
Aspose به‌تازگی یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز به ترکیب تصاویر JPG/JPEG یا PNG داشتید، یا می‌خواهید گریدی از عکس‌ها بسازید، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **افزودن تصویر به عنوان لینک**

برای جلوگیری از بزرگ شدن اندازهٔ ارائه، می‌توانید به جای جاسازی مستقیم فایل‌ها، تصاویر (یا ویدیوها) را از طریق لینک‌ها اضافه کنید. این کد C# نشان می‌دهد چگونه یک تصویر و یک ویدیو را به یک placeholder اضافه کنید:

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

## **برش تصاویر**

این کد C# نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // یک شیء تصویر جدید ایجاد می‌کند
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // یک PictureFrame به اسلاید اضافه می‌کند
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // تصویر را برش می‌دهد (مقدارهای درصدی)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // نتیجه را ذخیره می‌کند
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **حذف نواحی برش داده‌شدهٔ یک تصویر**

اگر می‌خواهید نواحی برش داده‌شدهٔ یک تصویر موجود در یک قاب را حذف کنید، می‌توانید از متد [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) استفاده کنید. این متد تصویر برش‌داده‌شده یا تصویر اصلی را برمی‌گرداند اگر برش ضرورتی نداشته باشد.

این کد C# عملیات را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // کاب تصویر را از اولین اسلاید دریافت می‌کند
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ناحیه‌های برش‌داده‌شدهٔ تصویر قاب تصویر را حذف می‌کند و تصویر برش‌داده‌شده را برمی‌گرداند
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
متد [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تصویر برش‌داده‌شده را به مجموعهٔ تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند اندازهٔ ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائهٔ نهایی افزایش می‌یابد.  

این متد در عملیات برش، فایل‌های متافایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند. 
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/compressimage/) یک تصویر در ارائه را فشرده کنید. این متد تصویر را با کاهش اندازه بر پایهٔ ابعاد شکل و وضوح مشخص‌شده فشرده می‌کند و امکان حذف نواحی برش‌داده‌شده را نیز فراهم می‌آورد.  

این عملکرد اندازه و وضوح تصویر را مشابه ویژگی **Picture Format → Compress Pictures → Resolution** در PowerPoint تنظیم می‌کند.  

مثال‌های C# زیر نشان می‌دهند چگونه با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش، یک تصویر را در ارائه فشرده کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // فشرده‌سازی تصویر با وضوح هدف 150 DPI (وضوح وب) و حذف نواحی برش‌داده‌شده.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // بررسی نتیجهٔ فشرده‌سازی.
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

یا به‌صورت مستقیم با مقدار DPI سفارشی:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // تصویر را به 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌داده‌شده را حذف کنید.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
متد تصویر را بر پایهٔ ابعاد شکل و DPI ارائه‌شده به وضوح پایین‌تری تبدیل می‌کند. نواحی برش شده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند. اگر تصویر یک متافایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، همانند نحوهٔ پردازش PowerPoint برای JPEGهای با وضوح بالا. 
{{% /alert %}}

## **قفل نسبت ابعاد**

اگر می‌خواهید یک شکل حاوی تصویر حتی پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، می‌توانید از ویژگی [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframelock/aspectratiolocked/) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.  

این کد C# نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:

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

    // شکل را برای حفظ نسبت طول به عرض هنگام تغییر اندازه تنظیم می‌کند
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
این تنظیم *Lock Aspect Ratio* فقط نسبت ابعاد شکل را نگه می‌دارد، نه تصویر موجود در آن. 
{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) از اینترفیس [IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat)، می‌توانید یک مستطیل پر را مشخص کنید.  

هنگامی که کشش برای یک تصویر تعریف شود، یک مستطیل منبع به اندازهٔ مستطیل پر مشخص‌شده مقیاس می‌شود. هر لبهٔ مستطیل پر با درصدی از لبهٔ متناظر جعبه مرزبندی شکل تعریف می‌شود. درصد مثبت یک بازده داخلی و درصد منفی یک بازده خارجی را مشخص می‌کند.

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک `AutoShape` مستطیلی اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. تصویری تنظیم‌شده برای پر کردن شکل اضافه کنید.  
8. آفست‌های تصویر را از لبهٔ متناظر جعبه مرزبندی شکل مشخص کنید.  
9. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.  

این کد C# فرآیندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // تصویر را برای کشیده شدن از هر سمت در بدنهٔ شکل تنظیم می‌کند
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

### چگونه می‌توانم بفهمم چه فرمت‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟

Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (برای مثال SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده معمولاً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

### افزودن چندین تصویر بزرگ چه تأثیری بر اندازه و عملکرد PPTX دارد؟

جاسازی تصاویر بزرگ باعث افزایش حجم فایل و مصرف حافظه می‌شود؛ لینک کردن تصاویر باعث می‌شود اندازهٔ ارائه کوچک بماند، اما فایل‌های خارجی باید در دسترس بمانند. Aspose.Slides امکان افزودن تصاویر به صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

### چگونه می‌توانم یک شیء تصویری را از جابه‌جایی/تغییر اندازه تصادفی محافظت کنم؟

می‌توانید از [قفل‌های شکل](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/pictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال کردن جابه‌جایی یا تغییر اندازه). مکانیسم قفل‌گذاری برای اشکال در یک مقالهٔ جداگانهٔ [حفاظت](/slides/fa/net/applying-protection-to-presentation/) توضیح داده شده و برای انواع مختلف اشکال از جمله [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) پشتیبانی می‌شود.

### آیا حفظ صحت برداری SVG هنگام خروجی گرفتن ارائه به PDF/تصاویر تضمین می‌شود؟

Aspose.Slides امکان استخراج SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) را به شکل بردار اصلی فراهم می‌کند. هنگام خروجی به PDF یا فرمت‌های رستر (مانند PNG)، نتیجه ممکن است بسته به تنظیمات خروجی رستر شود؛ اما این‌که SVG اصلی به عنوان بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.