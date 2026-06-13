---
title: مدیریت فریم‌های تصویر در ارائه‌ها با .NET
linktitle: فریم تصویر
type: docs
weight: 10
url: /fa/net/picture-frame/
keywords:
- فریم تصویر
- افزودن فریم تصویر
- ایجاد فریم تصویر
- افزودن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستری
- تصویر برداری
- برش تصویر
- ناحیه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی فریم تصویر
- ویژگی‌های فریم تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت ابعاد
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فریم‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET اضافه کنید. جریان کاری خود را بهینه‌سازی کنید و طراحی اسلایدها را بهبود بخشید."
---
## **مقدمه**

فریم تصویر یک شکل است که شامل یک تصویر می‌شود—شبیه یک تصویر داخل قاب است.  

می‌توانید یک تصویر را از طریق فریم تصویر به اسلاید اضافه کنید. به این ترتیب، می‌توانید تصویر را با قالب‌بندی فریم تصویر فرمت کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد اجازه می‌دهد به سرعت از تصاویر ارائه‌ها را بسازند. 

{{% /alert %}} 

## **ایجاد فریم تصویر**

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation)class ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده می‌شود، ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شی shape مرتبط با اسلاید مرجع نمایش داده می‌شود، ایجاد کنید.  
6. یک فریم تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.  

```c#
// یک شیء از کلاس Presentation که نمایانگر فایل PPTX است ایجاد می‌کند
using (Presentation pres = new Presentation())
{
    // اولین اسلاید را دریافت می‌کند
    ISlide slide = pres.Slides[0];

    // یک تصویر را بارگذاری می‌کند و به مجموعهٔ تصاویر ارائه اضافه می‌کند
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // یک فریم تصویر با ارتفاع و عرض یکسان اضافه می‌کند
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // برخی قالب‌بندی‌ها را بر روی فریم تصویر اعمال می‌کند
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // ارائه را به فایل PPTX می‌نویسد
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

فریم‌های تصویر به شما اجازه می‌دهند به سرعت اسلایدهای ارائه بر پایهٔ تصاویر ایجاد کنید. وقتی فریم تصویر را با گزینه‌های ذخیرهٔ Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک قالب به قالب دیگر مدیریت کنید. ممکن است بخواهید این صفحات را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/)، تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/)، تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/). 

{{% /alert %}}

## **ایجاد فریم تصویر با مقیاس نسبی**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. تصویری را به مجموعهٔ تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده می‌شود، ایجاد کنید.  
5. عرض و ارتفاع نسبی تصویر را در فریم تصویر مشخص کنید.  
6. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.  

```c#
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // یک تصویر را بارگذاری می‌کند و به مجموعهٔ تصاویر ارائه اضافه می‌نماید
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // یک فریم تصویر را به اسلاید اضافه می‌کند
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // عرض و ارتفاع مقیاس نسبی را تنظیم می‌کند
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // ارائه را ذخیره می‌کند
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **استخراج تصاویر رستری از فریم‌های تصویر**

می‌توانید تصاویر رستری را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe) استخراج کنید و در قالب‌های PNG، JPG و دیگر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه تصویری را از سند «sample.pptx» استخراج و در قالب PNG ذخیره کنید.

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

## **استخراج تصاویر SVG از فریم‌های تصویر**

وقتی یک ارائه حاوی گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای .NET به شما امکان می‌دهد تصاویر برداری اصلی را با تمام جزئیات دریافت کنید. با عبور از مجموعهٔ اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) زیرساختی محتوای SVG دارد یا نه، و سپس آن تصویر را به صورت فایل SVG بومی یا به یک جریان ذخیره کنید.  

کد نمونهٔ زیر نشان می‌دهد چگونه یک تصویر SVG را از فریم تصویر استخراج کنید:

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

Aspose.Slides به شما امکان می‌دهد شفافیت اعمال‌شده به یک تصویر را دریافت کنید. این کد C# عملیات را نشان می‌دهد:

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
تمام اثرات اعمال‌شده به تصاویر را می‌توان در [Aspose.Slides.Effects](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/) یافت. 
{{% /alert %}}

## **قالب‌بندی فریم تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متنوعی ارائه می‌دهد که می‌توان بر روی فریم تصویر اعمال کرد. با استفاده از این گزینه‌ها می‌توانید فریم تصویر را طوری تغییر دهید که با نیازهای خاص مطابقت داشته باشد.

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده می‌شود، ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](http://www.aspose.com/api/net/slides/fa/aspose.slides/ishapecollection/methods/addpictureframe) که توسط شیء [IShapes](http://www.aspose.com/api/net/slides/fa/aspose.slides/ishapecollection) مرتبط با اسلاید مرجع فراهم شده، ایجاد کنید.  
6. فریم تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط فریم تصویر را تنظیم کنید.  
8. ضخامت خط فریم تصویر را تنظیم کنید.  
9. فریم تصویر را با مقدار مثبت یا منفی چرخش دهید.  
   * مقدار مثبت تصویر را ساعت‌گرد می‌چرخاند.  
   * مقدار منفی تصویر را پادساعت‌گرد می‌چرخاند.  
10. فریم تصویر (حاوی تصویر) را به اسلاید اضافه کنید.  
11. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.  

```c#
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد می‌کند
using (Presentation presentation = new Presentation())
{
    // اسلاید اول را دریافت می‌کند
    ISlide slide = presentation.Slides[0];

    // یک تصویر را بارگذاری می‌کند و به مجموعهٔ تصاویر ارائه اضافه می‌نماید
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // یک فریم تصویر با ارتفاع و عرض معادل تصویر اضافه می‌کند
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // برخی قالب‌بندی‌ها را بر روی فریم تصویر اعمال می‌کند
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // ارائه را در یک فایل PPTX می‌نویسد
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose اخیراً یک [free Collage Maker](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG، یا [ایجاد شبکه‌های تصویری از عکس‌ها](https://products.aspose.app/slides/fa/collage/photo-grid) داشته باشید، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **افزودن تصویر به عنوان لینک**

برای جلوگیری از بزرگ شدن حجم ارائه، می‌توانید تصاویر (یا ویدیوها) را از طریق لینک اضافه کنید به‌جای این‌که فایل‌ها را مستقیم در ارائه جاسازی کنید. این کد C# نشان می‌دهد چگونه تصویر و ویدیو را به یک placeholder اضافه کنید:

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

## **برش تصاویر**

این کد C# نشان می‌دهد چگونه یک تصویر موجود بر روی اسلاید را برش دهید:

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

اگر می‌خواهید نواحی برش‌خوردهٔ یک تصویر موجود در فریم را حذف کنید، می‌توانید از متد [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را برمی‌گرداند اگر برش لازم نباشد.  

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // فریم تصویر را از اولین اسلاید دریافت می‌کند
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ناحیه‌های برش‌خوردهٔ تصویر فریم تصویر را حذف می‌کند و تصویر برش‌خورده را برمی‌گرداند
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // نتیجه را ذخیره می‌کند
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

متد [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تصویر برش‌خورده را به مجموعهٔ تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند حجم ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائهٔ نهایی افزایش می‌یابد.  

این متد در عملیات برش، فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند. 
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر در ارائه را با استفاده از متد [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/compressimage/) فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس ابعاد شکل و وضوح‌سنجی تعیین‌شده فشرده می‌کند و گزینهٔ حذف نواحی برش‌خورده را دارد.  

این کار اندازه و وضوح تصویر را مشابه ویژگی **Picture Format → Compress Pictures → Resolution** در PowerPoint تنظیم می‌کند.  

مثال‌های C# زیر نشان می‌دهند چگونه با تعیین وضوح هدف و حذف اختیاری نواحی برش‌خورده، یک تصویر را در ارائه فشرده کنید:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌کند.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // نتیجه فشرده‌سازی را بررسی می‌کند.
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

یا به‌صورت مستقیم از مقدار DPI سفارشی استفاده کنید:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // تصویر را به 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌کند.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

این متد تصویر را به وضوح پایین‌تری بر اساس اندازهٔ شکل و DPI ارائه‌شده تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند.  
اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نخواهد شد. همچنین کیفیت JPEG بر اساس وضوح حفظ یا به‌صورت جزئی کاهش می‌یابد، مشابه نحوهٔ پردازش PowerPoint برای JPEGهای با وضوح بالا. 
{{% /alert %}}

## **قفل‌کردن نسبت ابعاد**

اگر می‌خواهید شکلی که شامل یک تصویر است حتی پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، می‌توانید از ویژگی [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframelock/aspectratiolocked/) برای تنظیم گزینهٔ *Lock Aspect Ratio* استفاده کنید.  

این کد C# نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // شکل را تنظیم می‌کند تا نسبت ابعاد را هنگام تغییر اندازه حفظ کند
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

این تنظیم *قفل‌کردن نسبت ابعاد* فقط نسبت ابعاد شکل را حفظ می‌کند و نه تصویر داخل آن. 
{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsettop)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetright) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/picturefillformat) می‌توانید یک مستطیل پر‌کننده تعیین کنید.  

هنگامی که کشش برای یک تصویر مشخص می‌شود، یک مستطیل منبع مقیاس‌بندی می‌شود تا مستطیل پر‌کنندهٔ مشخص‌شده را پر کند. هر لبهٔ مستطیل پر‌کننده توسط یک درصد جابجایی نسبت به لبهٔ متناظر جعبهٔ محدودهٔ شکل تعریف می‌شود. درصد مثبت یک تو رفتگی و درصد منفی یک بیرون‌زدگی را نشان می‌دهد.

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید.  
8. جابجایی‌های تصویر را نسبت به لبهٔ متناظر جعبهٔ محدودهٔ شکل مشخص کنید.  
9. ارائهٔ تغییر یافته را به صورت فایل PPTX بنویسید.  

این کد C# فرآیندی را نشان می‌دهد که در آن ویژگی StretchOff استفاده می‌شود:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // تصویر را از هر طرف در بدنهٔ شکل کشیده می‌کند
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم چه قالب‌های تصویری برای PictureFrame پشتیبانی می‌شوند؟**  

Aspose.Slides هم تصاویر رستری (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست قالب‌های پشتیبانی‌شده عموماً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.  

**افزودن ده‌ها تصویر بزرگ چه تاثیری بر حجم و کارایی PPTX دارد؟**  

جاسازی مستقیم تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک‌کردن تصاویر به حفظ حجم ارائه کمک می‌کند اما فایل‌های خارجی باید در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.  

**چگونه می‌توانم شیء تصویر را از جابجایی/تغییر اندازهٔ تصادفی محافظت کنم؟**  

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/pictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال کردن جابجایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در مقالهٔ جداگانهٔ [حفاظت](/slides/fa/net/applying-protection-to-presentation/) توضیح داده شده و برای انواع مختلف اشکال شامل [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) پشتیبانی می‌شود.  

**آیا صحت برداری SVG در هنگام خروجی‌گیری ارائه به PDF/تصاویر حفظ می‌شود؟**  

Aspose.Slides امکان استخراج SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) را به‌صورت بردار اصلی فراهم می‌کند. هنگام [خروجی‌گیری به PDF](/slides/fa/net/convert-powerpoint-to-pdf/) یا [قالب‌های رستری](/slides/fa/net/convert-powerpoint-to-png/)، بسته به تنظیمات خروجی ممکن است نتیجه رستر شود؛ اما رفتار استخراج نشان می‌دهد SVG اصلی به‌عنوان بردار ذخیره می‌شود.