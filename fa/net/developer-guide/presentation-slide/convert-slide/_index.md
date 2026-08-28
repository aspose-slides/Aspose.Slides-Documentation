---
title: تبدیل اسلایدهای ارائه به تصاویر در .NET
linktitle: اسلاید به تصویر
type: docs
weight: 41
url: /fa/net/convert-slide/
keywords:
- تبدیل اسلاید
- صادرات اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به EMF
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اسلایدها را از ارائه‌های PPT، PPTX و ODP به فرمت‌های تصویری PNG، JPEG، GIF، TIFF، EMF و سایر فرمت‌ها در C# با Aspose.Slides برای .NET تبدیل کنید."
---
## **مقدمه**

Aspose.Slides for .NET می‌تواند اسلایدهای تک تک ارائه‌های PowerPoint و OpenDocument را به فرمت‌های PNG، JPEG، GIF، TIFF و سایر فرمت‌های تصویر رندره کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدی که می‌خواهید رندر کنید را انتخاب کنید.
3. در صورت نیاز، رندرینگ را با کلاس‌های [RenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) پیکربندی کنید.
4. متد [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) را فراخوانی کنید. این متد یک شیء [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) برمی‌گرداند.
5. متد [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/save/) را فراخوانی کنید و قالب خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) مشخص کنید.

## **تبدیل اسلاید به تصویر PNG**

ساده‌ترین تبدیل از تنظیمات پیش‌فرض رندرینگ استفاده می‌کند. شیء [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) حاصل می‌تواند در حافظه پردازش یا در فایل ذخیره شود.

مثال زیر به زبان C# اولین اسلاید را رندر کرده و به عنوان تصویر PNG ذخیره می‌کند:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

از overload متد [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) که یک مقدار [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) می‌پذیرد استفاده کنید تا اسلاید را با ابعاد پیکسلی دقیق رندر کنید.

مثال زیر تصویری JPEG با ابعاد ۱۸۲۰ × ۱۰۴۰ ایجاد می‌کند:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

به طور پیش‌فرض، تصاویر اسلاید شامل یادداشت‌ها یا نظرات نیستند. برای کنترل مکان نمایش یادداشت‌ها و نظرات، یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) را به ویژگی [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) انتساب دهید.

مثال زیر یادداشت‌های کوتاه شده را زیر اسلاید و نظرات را در سمت راست آن قرار می‌دهد:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="هشدار" color="warning" %}}
برای تبدیل اسلاید به تصویر، ویژگی [NotesPosition](https://reference.aspose.com/slides/fa/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) را روی [BottomFull](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notespositions/) تنظیم نکنید. یادداشت‌ها ممکن است متنی بیش از اندازه تصویر ثابت داشته باشند. به‌جای آن از [BottomTruncated](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notespositions/) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) به شما امکان کنترل اندازه، وضوح و سایر ویژگی‌های تصویر TIFF رندر شده را می‌دهد.

مثال زیر اولین اسلاید را به تصویر TIFF با ابعاد ۲۱۶۰ × ۲۸۸۰ و ۳۰۰ DPI رندر می‌کند:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **تبدیل تمام اسلایدها به تصاویر**

از حلقه‌ای برای عبور از مجموعه اسلایدها استفاده کنید تا کل ارائه را به مجموعه‌ای از تصاویر تبدیل کنید. اسلایدهای مخفی نیز گنجانده می‌شوند مگر اینکه صراحتاً آنها را نادیده بگیرید.

مثال زیر هر اسلاید را به تصویر JPEG با عوامل مقیاس افقی و عمودی ۲ رندر می‌کند:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **ایجاد خروجی Enhanced Metafile**

Enhanced Metafile (EMF) زمانی مفید است که گرافیک‌های مبتنی بر بردار باید با Microsoft Office یا برنامه‌های ویندوزی دیگر که از متافایل‌های ویندوز پشتیبانی می‌کنند، تبادل شود. برخلاف تصویر مبتنی بر پیکسل، EMF می‌تواند عملیات رسم برداری را که بدون از دست رفتن وضوح مقیاس می‌شوند، حفظ کند. با این حال، EMF عمدتاً یک قالب سازگاری برای برنامه‌های دارای پشتیبانی از متافایل ویندوز است و نه یک قالب مبادله‌ای جهانی. علاوه بر این، محتوای پیچیده اسلاید مانند تصاویر بیت‌مپ و برخی افکت‌ها ممکن است به‌صورت عناصر شطرنجی داخل کانتینر متافایل برداری ذخیره شوند.

### **صادر کردن اسلاید به EMF**

متد [ISlide.WriteAsEmf](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/writeasemf/) یک شیء [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) را به یک جریان هدف با فرمت EMF می‌نویسد. مثال زیر یک ارائه را بارگذاری می‌کند، اولین اسلاید را انتخاب می‌کند و آن را به یک جریان فایل EMF می‌نویسد:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

صاحبی که جریان را به [ISlide.WriteAsEmf](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/writeasemf/) پاس می‌دهد، باید پس از استفاده آن را ببندد یا آن را Dispose کند. Aspose.Slides در موقعیت فعلی جریان می‌نویسد و جریان را باز می‌گذارد.

### **تبدیل تصویر SVG به EMF و افزودن آن به ارائه**

از [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/writeasemf/) برای تبدیل محتوای SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [IImageCollection.AddImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection/addimage/) به ارائه اضافه شوند و با [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addpictureframe/) روی اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/svgimage/) را از مارکاپ SVG می‌سازد، آن را به یک EMF در حافظه تبدیل می‌کند، متافایل را در اولین اسلاید درج می‌کند و ارائه را ذخیره می‌سازد:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/writeasemf/) مالکیت جریان مقصد را بر عهده نمی‌گیرد. پس از نوشتن، موقعیت جریان در انتهای داده‌های تولید شده است. قبل از ارسال همان جریان جستجوپذیر به یک خواننده، `Position` را به ابتدا بازنشانی کنید، همان‌طور که در بالا نشان داده شده است. جریان را تا زمانی که مصرف‌کننده خواندن را تمام کند باز نگه دارید و سپس آن را Dispose کنید. به‌علاوه می‌توانید `ToArray` را فراخوانی کنید و آرایه بایت بازگردانده‌شده را به [IImageCollection.AddImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection/addimage/) پاس دهید؛ `ToArray` تمام بافر را صرف‌نظر از موقعیت جاری جریان برمی‌گرداند.

تولید EMF در سیستم‌عامل‌های پشتیبانی‌شده توسط نسخه انتخابی Aspose.Slides for .NET موجود است، اما رندرسازی می‌تواند در پلتفرم‌های مختلف هنگام عدم دسترسی به فونت‌ها یا وابستگی‌های گرافیکی بومی متفاوت باشد. فونت‌های استفاده‌شده در محتوای منبع را نصب کنید یا جایگزین‌های مناسب را پیکربندی کنید، الزامات [پلتفرم](/slides/fa/net/system-requirements/) بسته Aspose.Slides خود را دنبال کنید و نتیجه را در برنامه مصرف‌کننده EMF هدف اعتبارسنجی کنید. برنامه‌های Linux و macOS اغلب پشتیبانی محدودی یا ناسازگاری در نمایش و ویرایش متافایل‌های ویندوز دارند.

## **رندرسازی ایموجی‌های رنگی**

{{% alert title="توجه" color="info" %}}
برای رندرسازی صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصویر، فونت‌های ایموجی استفاده‌شده در ارائه باید روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشند. به‌عنوان مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به‌صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از رندرسازی اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر. متد [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) یک تصویر ثابت از اسلاید رندر می‌کند و انیمیشن‌ها را صادر نمی‌کند.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله. اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی رندر شوند. آنها را در حلقه پردازش گنجانده کنید، همان‌طور که در مثال بالا نشان داده شد.

**آیا سایه‌ها و سایر افکت‌ها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.