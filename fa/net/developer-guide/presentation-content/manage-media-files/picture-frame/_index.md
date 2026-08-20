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
- تصویر جاسازی‌شده
- تصویر پیوندی
- استخراج تصویر
- تصویر رستری
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی قاب‌های تصویر در ارائه‌ها با Aspose.Slides برای .NET."
---
## **مروری کلی**

یک قاب تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیای جداگانه‌ای هستند: یک [ارائه](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق مجموعهٔ [تصاویر](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/images/) خود مالک می‌شود، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، برش، اثرات تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که یک تصویر بیش از یک بار نمایش داده شود. تصویر را یک‌بار به ارائه اضافه کنید، شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) برگردانده‌شده را نگه دارید و هنگام ایجاد قاب‌های تصویر از آن منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند شامل تصاویر رستری مانند PNG یا JPEG و تصاویر برداری SVG باشند. همچنین می‌توانند به تصاویر پیوندی اشاره کنند به جای اینکه بایت‌های تصویر را در ارائه ذخیره کنند. این انتخاب پرتابل بودن، حجم فایل، استخراج و رفتار خروجی را تحت تأثیر قرار می‌دهد، بنابراین قبل از اعمال قالب‌بندی یا بهینه‌سازی تصمیم‌گیری دربارهٔ نحوهٔ ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک قاب تصویر با [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addpictureframe/) ایجاد کنید. تصویر بخشی از بستهٔ ارائه می‌شود، بنابراین ارائه هنگام انتقال به کامپیوتر دیگر مستقل باقی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌کند:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

قاب تصویر هندسهٔ نمایشی را کنترل می‌کند؛ تغییر اندازهٔ قاب ابعاد پیکسلی اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تمایز زمانی مهم می‌شود که بعداً تصویر را برش یا فشرده کنید.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) مقیاس‌گیری نسبی عرض و ارتفاع برای قاب را نمایش می‌دهد. مقدار `1.0` معادل 100٪ اندازهٔ اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک گردش کار نیاز داشته باشد رابطهٔ آن با اندازهٔ تصویر منبع حفظ شود به جای محاسبهٔ ابعاد نهایی به صورت دستی.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ تصویر جاسازی‌شده را بازنمونه‌برداری یا فشرده نمی‌کند.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین ایمن‌ترین گزینه برای پرتابل بودن و رندر قابل پیش‌بینی است. یک تصویر پیوندی مکان خارجی را از طریق مسیر پیوند [ISlidesPicture](https://reference.aspose.com/slides/fa/net/aspose.slides/islidespicture/) ذخیره می‌کند به جای اینکه داده‌های تصویر را به همان شکل جاسازی کند.

تصاویر پیوندی می‌توانند مقدار داده‌های تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس باشد. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، ممکن است تصویر پیوندی همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی گردند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اطمینان‌تر هستند.

### **افزودن یک تصویر پیوندی**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر پردازش می‌کند؛ پیوند ویدیو یک گردش کار رسانه‌ای جداگانه است و عمداً با این مثال ترکیب نشده است.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

از پیوندها زمانی استفاده کنید که مدیریت فایل‌های خارجی عمدی باشد. از آنها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر کاربردی است نسبت به یک ارائهٔ بزرگ‌تر و خودمستقل.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج یک تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) باشد و شامل یک تصویر جاسازی‌شده باشد. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری که به همان روش قابلیت استخراج دارند، نداشته باشند.

### **استخراج تصویر رستری**

API مدرن تصویر از [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) به‌صورت مستقیم استفاده می‌کند و نیازی به بسته‌بندی سیستم‌تصویر قدیمی نیست. مثال زیر اولین تصویر رستری جاسازی‌شده در یک اسلاید را پیدا کرده و به صورت PNG ذخیره می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

ذخیره‌سازی از طریق [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) تصویر استخراج‌شده را به فرمت خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شدهٔ ذخیره‌شده در ارائه به‌جای یک فایل رستری تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) را نشان می‌دهد. این به شما اجازه می‌دهد داده‌های SVG را به‌صورت مستقیم بازیابی کنید به‌جای اینکه ابتدا تصویر را رستر کنید.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

نگه داشتن محتوای SVG به‌عنوان SVG، منبع برداری را در داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG به‌طور ضروری آن محتوای برداری را به پیکسل تبدیل می‌کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان نسخهٔ بایت‌به‌بایت SVG جاسازی‌شدهٔ اصلی در نظر گرفته شوند؛ زمانی که منبع برداری اصلی مورد نیاز است، از دادهٔ [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) جاسازی‌شده استفاده کنید.

## **برش تصویر**

برش بخشی از تصویر را که داخل قاب قابل رؤیت است تغییر می‌دهد. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش در ابتدا پیکسل‌های پنهان تصویر جاسازی‌شده را حذف نمی‌کند؛ فقط ناحیهٔ قابل رؤیت را تغییر می‌دهد.

مثال زیر به‌صورت ایمن یک قاب تصویر را پیدا کرده و مقادیر برش را اعمال می‌کند:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

از آنجا که داده‌های تصویر پنهان هنوز وجود دارد، می‌توان برش را بعداً بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت برگشت‌پذیری باشد، می‌توان نواحی برش‌خورده را همان‌طور که در بخش بعدی توصیف شده فیزیکی حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) داده‌های تصویری خارج از مستطیل برش فعلی را حذف کرده و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما به‌عنوان یک بهینه‌سازی مخرب عمل می‌کند: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات برگرداندن برش در دسترس نیستند.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگر نیز استفاده می‌شود، آن قاب‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌خورده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این متد، نتیجهٔ برش‌خورده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستری**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/compressimage/) رزولوشن تصویر رستری را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد وقتی که تصویر تغییر اندازه یا برش داده شود `true` و وقتی هیچ‌گونه تغییری لازم نباشد `false` برمی‌گرداند.

از یک مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/net/aspose.slides.export/picturescompression/) استفاده کنید زمانی که رزولوشن هدف استاندارد کافی باشد:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

به‌جای مقدار enum می‌توان یک مقدار DPI مثبت سفارشی را هنگام نیاز به هدف خاص پاس داد.

فشرده‌سازی برای تصاویر رستری در نظر گرفته شده است. محتوای SVG و متافایل توسط این گردش کار فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به‌یاد داشته باشید که رزولوشن پایین‌تر و نواحی برش‌خوردهٔ حذف‌شده را نمی‌توان از ارائهٔ بهینه‌شده بازیابی کرد. رزولوشن هدف را بر پایهٔ بزرگ‌ترین اندازه‌ای که تصویر در واقع مشاهده یا خروجی خواهد شد انتخاب کنید، نه این‌که پایین‌ترین DPI را به‌صورت سراسری اعمال کنید.

## **بررسی اثرات تصویر**

اثرهای تصویر بر روی تصویری که توسط قاب استفاده می‌شود ذخیره می‌شوند. مجموعهٔ تبدیل تصویر می‌تواند شامل اثرهایی مانند مدولاسیون آلفای ثابت برای شفافیت و روشنایی برای تنظیم روشنایی و کنتراست باشد. مثال زیر به‌صورت ایمن هر دو نوع اثر را از اولین قاب تصویر در یک اسلاید می‌خواند:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

این اثرها نحوهٔ رندر تصویر در قاب را تغییر می‌دهند؛ بایت‌های تصویر جاسازی‌شدهٔ اصلی را بازنویسی نمی‌کنند.

## **قفل‌کردن هندسهٔ قاب تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframelock/) کنترل می‌کند کدام عملیات‌های ویرایشی برای یک قاب تصویر غیرفعال هستند. به‌عنوان مثال، قفل نسبت ابعاد، نسبت‌های شکل را هنگام تغییر اندازه حفظ می‌کند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

قفل بر روی شکل قاب تصویر اعمال می‌شود. این قفل تصویر منبع را مجبور به بازنمونه‌برداری یا تغییر دائمی به همان نسبت ابعاد نمی‌کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پرشدن تصویر کشیده (stretch) است، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/) مستطیل پرشدن را نسبت به جعبهٔ حاشیهٔ قاب تصویر تعریف می‌کند. درصدهای مثبت از لبهٔ داخلی را ایجاد می‌کنند، در حالی که درصدهای منفی بیرون‌زدگی ایجاد می‌کنند.

این متفاوت از برش است. مقادیر برش بخش قابل رؤیت تصویر منبع را انتخاب می‌کند؛ offsetهای کشسان مستطیلی را که پرشدن تصویر قابل رؤیت در آن کشیده می‌شود، تغییر می‌دهد.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

از offsetهای کشسان برای جایگذاری پرشدن استفاده کنید. زمانی که هدف مخفی‌سازی لبه‌های تصویر منبع است از خصوصیات برش استفاده کنید.

## **نکات مربوط به ذخیره‌سازی، حجم فایل و خروجی**

موازنه‌های اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی قاب تصویر به‌صورت جداگانه در نظر گرفته شوند:

- **تصاویر جاسازی‌شده** ارائه را خودمستقل می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستری بزرگ حجم PPTX و استفادهٔ حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی وابسته است که باید در مسیرهای ذخیره‌شده در دسترس بمانند.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش‌خورده صراحتاً حذف یا در زمان فشرده‌سازی حذف نشوند، درون‌رو می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستری بیش از حد بزرگ به‌طور قابل‌توجهی کاهش دهد، اما رزولوشن منبع را از بین می‌برد. این کار باید پس از دانستن اندازهٔ نهایی مورد نظر روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند وقتی حفظ بردار مهم است. SVG جاسازی‌شده را مستقیماً استخراج کنید وقتی به منبع برداری نیاز دارید. خروجی‌های رستری اسلاید همیشه اسلاید رندر‌شده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [IPPImage] موجود مجدداً استفاده کنند به‌جای بارگذاری مکرر همان فایل در گردش کار ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثرترین است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتویات برداری نگه دارید، عکس‌ها را بر اساس اندازهٔ واقعی نمایش فشرده کنید، پیکسل‌های برش‌خورده را فقط زمانی حذف کنید که ویرایش بعدی لازم نباشد و از پیوندهای خارجی خودداری کنید مگر اینکه مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **سوالات متداول**

**تفاوت بین یک قاب تصویر و یک منبع تصویر چیست؟**

[IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح قاب مانند اندازه، چرخش، مقادیر برش، اثرات و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را جاسازی کنم یا پیوند دهم؟**

تصاویر را زمانی جاسازی کنید که ارائه باید پرتابل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود. تصاویر را فقط زمانی پیوند دهید که نگهداری فایل‌های تصویری خارج از PPTX عمدی باشد و مکان‌های خارجی به‌طور قابل‌اعتماد در دسترس باقی بمانند.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را نمی‌کند. تنظیمات برش معمولی بخش‌های تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای حذف دائمی پیکسل‌ها می‌توانید از [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) یا فشرده‌سازی تصویر با حذف نواحی برش‌خورده استفاده کنید.

**آیا می‌توان بعد از فشرده‌سازی کیفیت تصویر را بازیابی کرد؟**

نه. فشرده‌سازی می‌تواند رزولوشن رستری ذخیره‌شده را کاهش دهد و حذف نواحی برش داده‌ها را از بین می‌برد. اگر احتمالا بعداً به ویرایش با وضوح بالا نیاز دارید، تصویر اصلی را خارج از ارائه نگه دارید.

**تصاویر SVG باید چگونه مدیریت شوند؟**

محتوای SVG را به‌عنوان SVG نگه دارید وقتی که حفظ دقت برداری مهم است. می‌توانید دادهٔ [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) جاسازی‌شده را مستقیماً استخراج کنید. رندر اسلاید به فرمت رستری مانند PNG یا JPEG، SVG را به بخشی از تصویر اسلاید رستر می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای مخصوص قاب تصویر، نوع شکل را بررسی کنید. استفاده از الگوی تطبیق با [IPictureFrame] یا فیلتر کردن مجموعهٔ اشکال بر اساس این رابط، از تبدیل‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که قاب تصویر ندارند را به‌صورت مناسب مدیریت کند.