---
title: مدیریت قاب‌های تصویر در ارائه‌ها با .NET
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/net/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- تصویر جاسازی‌شده
- تصویر لینک‌دار
- استخراج تصویر
- تصویر رستری
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی قاب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قاب‌های تصویر را در ارائه‌ها با Aspose.Slides برای .NET ایجاد، قالب‌بندی، لینک‌گذاری، برش، استخراج و فشرده‌سازی کنید."
---
## **مرور کلی**

یک قاب تصویر یک شکل اسلاید است که تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیاء جداگانه‌ای هستند: یک [ارائه](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق مجموعهٔ [Images](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/images/) خود مالکیت می‌کند، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نشان داده شود. تصویر را یک‌بار به ارائه اضافه کنید، شیء ‎[IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/)‎ بازگردانده‌شده را حفظ کنید و هنگام ایجاد قاب‌های تصویر از آن منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند تصاویر رستر مانند PNG یا JPEG و تصاویر SVG برداری را دربر بگیرند. همچنین می‌توانند به تصاویر لینک‌دار اشاره کنند به جای اینکه بایت‌های تصویر را در ارائه ذخیره کنند. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی تصمیم‌گیری در مورد نحوهٔ ذخیرهٔ تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک قاب تصویر با ‎[IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addpictureframe/)‎ ایجاد کنید. تصویر بخشی از بستهٔ ارائه می‌شود، بنابراین ارائه هنگام انتقال به کامپیوتر دیگر به‌صورت خودگردان باقی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد بومی تصویر می‌سازد و قالب‌بندی خطوط و چرخش را اعمال می‌کند:

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

قاب تصویر هندسهٔ نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازهٔ قاب تغییراتی در ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده ایجاد نمی‌کند. این تمایز زمانی مهم می‌شود که بعداً تصویر را برش یا فشرده‌سازی کنید.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) مقیاس‌گذاری عرض و ارتفاع نسبی برای قاب را افشا می‌کند. مقدار `1.0` معادل 100٪ اندازهٔ اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز داشته باشد نسبت به اندازهٔ منبع تصویر حفظ شود به جای محاسبهٔ ابعاد نهایی به‌صورت دستی.

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

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ آن تصویر جاسازی‌شده را بازنمونه‌برداری یا فشرده نمی‌کند.

## **تصاویر جاسازی‌شده و لینک‌دار**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت حمل و رندر پیش‌بینی‌پذیر ایمن‌ترین گزینه است. یک تصویر لینک‌دار مسیر خارجی را از طریق پیوند ‎[ISlidesPicture](https://reference.aspose.com/slides/fa/net/aspose.slides/islidespicture/)‎ ذخیره می‌کند به‌جای این‌که داده‌های تصویر را همان‌طور جاسازی کند.

تصاویر لینک‌دار می‌توانند میزان دادهٔ تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل لینک‌شده باید برای برنامهٔ بازکننده یا رندرکنندهٔ ارائه در دسترس باقی بماند. اگر مسیر تغییر کند، فایل جابه‌جا شود یا منبع در دسترس نباشد، تصویر لینک‌دار ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید از طریق ایمیل ارسال، بایگانی یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اطمینان‌تر هستند.

### **افزودن تصویر لینک‌دار**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به لینک‌گذاری تصویر می‌پردازد؛ لینک‌گذاری ویدئو یک جریان کار رسانه‌ای جداگانه است و عمداً در این مثال مخلوط نشده است.

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

از لینک‌ها زمانی استفاده کنید که مدیریت فایل‌های خارجی عمدی باشد. آنها را صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائهٔ خودکفا بزرگ‌تر.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) باشد و حاوی تصویر جاسازی‌شده باشد. قاب‌های تصویر لینک‌دار ممکن است بایت‌های تصویر را نداشته باشند که بتوان به همان روش استخراج کرد.

### **استخراج یک تصویر رستری**

API مدرن تصویر از ‎[IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/)‎ به‌طور مستقیم استفاده می‌کند و نیازی به بسته‌بندی سیستم تصویر قدیمی ندارد. مثال زیر اولین تصویر رستری جاسازی‌شده را در یک اسلاید پیدا می‌کند و به‌عنوان PNG ذخیره می‌کند:

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

ذخیره‌سازی از طریق ‎[IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/)‎ تصویر استخراج‌شده را به قالب خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شدهٔ ذخیره‌شده در ارائه به‌جای فایل رستری تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، ‎[IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/)‎ یک شیء ‎[ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/)‎ را افشا می‌کند. این امکان را می‌دهد که داده‌های SVG را به‌صورت مستقیم دریافت کنید به‌جای اینکه ابتدا تصویر را رستری کنید.

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

نگهداری محتویات SVG به‌عنوان SVG، منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG لزوماً آن محتویات برداری را به پیکسل تبدیل می‌کنند. خروجی اسلاید به PDF یا SVG نیز عملیات رندرینگ است، بنابراین گرافیک‌های خروجی نباید به‌عنوان یک نسخهٔ بایت به بایت از SVG جاسازی‌شدهٔ اصل در نظر گرفته شوند؛ برای استفاده از منبع برداری اصلی، دادهٔ ‎[ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/)‎ جاسازی‌شده را استخراج کنید.

## **برش تصویر**

برش مشخص می‌کند کدام بخش از تصویر درون قاب قابل مشاهده باشد. مقادیر برش در ‎[IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/)‎ درصدی از ابعاد تصویر منبع هستند. برش اولیه بایت‌های پنهان را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط ناحیهٔ قابل مشاهده را تغییر می‌دهد.

مثال زیر به‌صورت ایمن یک قاب تصویر را پیدا می‌کند و مقادیر برش را اعمال می‌کند:

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

چون داده‌های تصویر مخفی هنوز موجود هستند، می‌توان برش را بعدها بدون از دست رفتن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگشت باشد، می‌توان نواحی برش خورده را همان‌طور که در بخش بعدی توضیح داده شده است به‌صورت فیزیکی حذف کرد.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) داده‌های تصویری خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما بهینه‌سازی تخریبی است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات بازبرش در دسترس نیستند.

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

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط سایر قاب‌های تصویر نیز استفاده شود، آن قاب‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتویات WMF یا EMF با این روش نتیجهٔ برش‌شده را به PNG رستری می‌کند.

## **فشرده‌سازی تصاویر رستری**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/compressimage/) رزولوشن تصویر رستری را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد زمانی که تصویر تغییر اندازه یا برش داده‌شود `true` و در غیر این صورت `false` برمی‌گرداند.

از یک مقدار پیش‌تعریفی ‎[PicturesCompression](https://reference.aspose.com/slides/fa/net/aspose.slides.export/picturescompression/)‎ استفاده کنید زمانی که یک رزولوشن هدف استاندارد کافی است:

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

به‌جای مقدار enum می‌توان مقدار DPI مثبت سفارشی را هنگام نیاز به هدف خاص ارسال کرد.

فشرده‌سازی برای تصاویر رستری منظور شده است. محتوای SVG و متافایل توسط این جریان کار فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به یاد داشته باشید که رزولوشن پایین‌تر و نواحی برش‌خورده حذف‌شده را نمی‌توانید از ارائه بهینه‌شده بازگردانید. رزولوشن هدف را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعیً مشاهده یا خروجی می‌شود انتخاب کنید نه این‌که کم‌ترین DPI را به‌صورت سراسری اعمال کنید.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک جریان کار کامل که شامل روشنایی، کنتراست، تبدیل رنگ، تاری، افکت‌های آلفا، زنجیره‌های مرتب‌شده، بازبینی، حذف و تأیید دوطرفه است، به ‎[Image Transform Effects](/slides/fa/net/image-transform-effects/)‎ مراجعه کنید.

## **قفل کردن هندسهٔ قاب تصویر**

تنظیمات ‎[IPictureFrameLock](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframelock/)‎ کنترل می‌کند کدام عملیات‌های ویرایشی برای یک قاب تصویر غیرفعال هستند. به‌عنوان مثال، قفل نسبت ابعاد، تناسبات شکل را هنگام تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل قاب تصویر اعمال می‌شود. این باعث نمی‌شود تصویر منبع بازنمونه‌برداری شود یا به‌صورت دائم به همان نسبت ابعاد تبدیل شود.

## **تنظیم مقادیر StretchOffset**

هنگامی که حالت پر کردن تصویر stretch باشد، مقادیر stretch‑offset در ‎[IPictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/)‎ مستطیل پر را نسبت به جعبهٔ محدود کنندهٔ قاب تصویر تعریف می‌کند. درصدهای مثبت یک تورفتگی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک بیرون‌زدگی ایجاد می‌کنند.

این متفاوت از برش است. مقادیر برش مشخص می‌کند کدام بخش از تصویر منبع قابل مشاهده است؛ offsetهای stretch مستطیل را که در آن پر کردن تصویر قابل دیدن کشیده می‌شود تغییر می‌دهند.

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

از offsetهای stretch برای قراردهی پر استفاده کنید. از ویژگی‌های برش زمانی استفاده کنید که هدف مخفی کردن لبه‌های تصویر منبع باشد.

## **نگهداری، حجم فایل و ملاحظات خروجی**

تجارت‌های اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیرهٔ تصویر و قالب‌بندی قاب تصویر جداگانه در نظر گرفته شوند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستری بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر لینک‌دار** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده یا مکان‌ها وابسته می‌شود.
- **برش** در ابتدا غیر تخریبی است. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده صریحاً حذف یا در طول فشرده‌سازی حذف نشوند، جاسازی می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستری حجیم به طور قابل‌توجهی کاهش دهد، اما رزولوشن منبع را قربانی می‌کند. این کار باید پس از شناخت اندازهٔ نهایی روی اسلاید اعمال شود.
- **تصاویر SVG** باید زمانی که حفظ وکتور مهم است به‌صورت SVG باقی بمانند. هنگام نیاز به منبع برداری، SVG جاسازی‌شده را به‌صورت مستقیم استخراج کنید. خروجی‌های اسلاید رستری همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** بهتر است در صورت امکان از یک منبع ‎[IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/)‎ موجود استفاده کنند به جای بارگذاری مکرر همان فایل در جریان کار ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثرتر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوای وکتور نگه دارید، عکس‌ها را بر اساس اندازهٔ نمایشی واقعی فشرده کنید، پیکسل‌های برش‌خورده را فقط زمانی که نیازی به ویرایش بعدی نیست حذف کنید و از لینک‌های خارجی صرف‌نظر کنید مگر اینکه مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **سوالات متداول**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک ‎[IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/)‎ نمایانگر منبع تصویر مرتبط با ارائه است. یک ‎[IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/)‎ شکلی روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح قاب مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**کدام یک را باید جاسازی یا لینک کنم؟**

زمانی که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، تصاویر را جاسازی کنید. تصاویر را فقط زمانی لینک کنید که نگهداری فایل‌های تصویری خارج از PPTX عمدی است و می‌توان مکان‌های خارجی را به‌طور قابل‌اعتماد مدیریت کرد.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را انجام نمی‌دهد. تنظیمات برش معمولاً قسمت‌های تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم، از ‎[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)‎ یا فشرده‌سازی تصویر همراه با حذف نواحی برش‌شده استفاده کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازیابی کرد؟**

خیر. فشرده‌سازی می‌تواند رزولوشن رستری ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده دادهٔ تصویری را از بین می‌برد. اگر ویرایش با رزولوشن بالا بعداً لازم باشد، تصویر منبع اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG رفتار کرد؟**

وقتی که حفظ دقت وکتور مهم است، محتویات SVG را به‌عنوان SVG نگه دارید. می‌توانید ‎[ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/)‎ جاسازی‌شده را به‌صورت مستقیم استخراج کنید. رندر کردن اسلاید به فرمتی رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از castهای ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. استفاده از pattern matching با ‎[IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/)‎ یا فیلتر کردن مجموعهٔ اشکال بر اساس این واسط، از castهای نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که قاب تصویر ندارند را به‌درستی مدیریت کند.