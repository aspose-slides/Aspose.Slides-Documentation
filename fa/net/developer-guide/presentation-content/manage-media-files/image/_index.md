---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با .NET
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/net/image/
keywords:
- افزودن تصویر
- افزودن عکس
- جایگزینی تصویر
- مجموعه تصویر
- قاب تصویر
- تصویر لینک‌دار
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- SVG به اشکال
- منابع خارجی SVG
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه تصاویر رستری و SVG را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET اضافه، دوباره استفاده، لینک‌دار، جایگزین و مدیریت کنید."
---
## **مقدمه**

Aspose.Slides برای .NET چندین روش برای کار با تصاویر ارائه می‌دهد و هر کدام هدف متفاوتی دارند. می‌توانید یک تصویر را در ارائه ذخیره کنید، آن را در یک قاب تصویر نمایش دهید، به عنوان پس‌زمینهٔ اسلاید استفاده کنید، به یک تصویر خارجی لینک دهید، منبع تصویر مشترک را جایگزین کنید یا محتوای SVG را به اشکال قابل ویرایش تبدیل کنید.

این مقاله بر روی منابع تصویر و نحوه استفادهٔ آنها در سراسر یک ارائه متمرکز است. برای برش، شفافیت، اثرات، کشیدگی و سایر قالب‌بندی‌های اعمال‌شده به یک قاب تصویر منفرد، به [قاب تصویر](/slides/fa/net/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

مفاهیم API زیر به هم نزدیک هستند اما قابل تعویض نیستند:

- مجموعهٔ تصویر ارائه ([presentation image collection](https://reference.aspose.com/slides/fa/net/aspose.slides/iimagecollection/)) منابع تصویری را که توسط ارائه استفاده می‌شوند ذخیره می‌کند. برای افزودن دادهٔ تصویر و دریافت منبع [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) از `ImageCollection.AddImage` استفاده کنید.
- یک [قاب تصویر](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) یک شکل است که تصویر را بر روی اسلاید، طرح‌بندی یا مستر نمایش می‌دهد. برای قرار دادن منبع تصویر بر روی اسلاید از `IShapeCollection.AddPictureFrame` استفاده کنید.
- پس‌زمینهٔ اسلاید از یک تصویر به عنوان بخشی از پرکردن اسلاید استفاده می‌کند نه به‌عنوان یک شکل. بنابراین رفتار آن شبیه قاب تصویر نیست.
- `[IPPImage].ReplaceImage` منبع تصویر را جایگزین می‌کند. اگر چندین عنصر ارائه از آن منبع استفاده کنند، همه آن جایگزین را به‌کار می‌گیرند.
- تبدیل SVG به اشکال، اشکال ویرایش‌پذیر اسلاید را ایجاد می‌کند. پس از تبدیل، محتوا دیگر به‌عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

یک جریان کاری معمول به این صورت است: دادهٔ تصویر را به مجموعهٔ تصویر اضافه کنید، یک [IPPImage] دریافت کنید و سپس از آن منبع در یک یا چند قاب تصویر یا پرکننده استفاده کنید.

## **افزودن تصویر توکار**

برای افزودن یک تصویر محلی، فایل را بخوانید، دادهٔ آن را به مجموعهٔ تصویر اضافه کنید و یک قاب تصویر ایجاد کنید که `IPPImage` بازگشتی را استفاده می‌کند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

تصویری که به این روش افزوده می‌شود در ارائه توکار می‌شود، بنابراین فایل نهایی به موجود بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

زمانی که تصویر از طریق HTTP یا HTTPS در دسترس باشد، بایت‌های آن را با `HttpClient` دانلود کنید، به مجموعهٔ تصویر ارائه اضافه کنید و از منبع تصویری بازگشتی به همان شیوهٔ تصویر محلی استفاده کنید.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

در برنامه‌های طولانی‌مدت، به‌جای ساختن یک نمونه جدید برای هر درخواست، `HttpClient` را مجدداً استفاده کنید. همچنین URLهای دوردست، اندازهٔ پاسخ و انواع محتوا را هنگامی که منبع قابل اعتماد نیست، اعتبارسنجی کنید.

## **استفاده مجدد از تصاویر در سراسر اسلایدها**

اگر همان تصویر بیشتر از یک بار نیاز باشد، یک‌بار آن را به ارائه اضافه کنید و هنگام ایجاد قاب‌های تصویر دیگر، `IPPImage` بازگشتی را دوباره استفاده کنید. این کار از بارگذاری مکرر دادهٔ منبع جلوگیری می‌کند و رابطهٔ بین منبع تصویر مشترک و استفاده‌های آن را واضح می‌سازد.

برای گرافیک‌هایی که باید به‌صورت خودکار در اسلایدهای متعدد ظاهر شوند، مانند لوگوی شرکت، بهتر است قاب تصویر را بر روی یک [مستری اسلاید](/slides/fa/net/slide-master/) یا طرح‌بندی قرار دهید تا نیازی به افزودن شکل معادل به هر اسلاید نباشد.

## **استفاده از تصویر به‌عنوان پس‌زمینهٔ اسلاید**

یک تصویر پس‌زمینه به پرکردن اسلاید اختصاص می‌یابد؛ به‌عنوان یک شکل قاب تصویر افزوده نمی‌شود. این برای مواردی مفید است که تصویر باید کل پس‌زمینهٔ اسلاید را پوشش دهد و نه به‌عنوان یک شیء اسلاید معمولی دست‌کاری شود.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

برای گزینه‌های پس‌زمینهٔ بیشتر، شامل پس‌زمینه‌های مستر و طرح‌بندی، به [پس‌زمینهٔ ارائه](/slides/fa/net/presentation-background/) مراجعه کنید.

## **تصاویر توکار و تصاویر لینک‌دار**

تصاویر توکار و لینک‌دار تعادل‌های متفاوتی در قابلیت حمل‌پذیری و حجم فایل دارند:

- **تصویر توکار:** دادهٔ تصویر داخل ارائه ذخیره می‌شود. ارائه خودکفا است، اما حجم فایل شامل دادهٔ تصویر می‌شود.
- **تصویر لینک‌دار:** ارائه مسیر یا URL یک تصویر خارجی را ذخیره می‌کند. این می‌تواند حجم ارائه را کاهش دهد، اما منبع خارجی باید هنگام باز یا رندر شدن ارائه در دسترس باشد.

می‌توانید یک تصویر لینک‌دار را با اختصاص مسیر یا URL خارجی از طریق `ISlidesPicture.LinkPathLong` به جای توکار کردن دادهٔ تصویر ایجاد کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

تصاویر لینک‌دار را فقط زمانی استفاده کنید که محیط استقرار بتواند به‌طور قابل اعتماد به منبع خارجی دسترسی داشته باشد. برای ارائه‌هایی که باید آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، تصاویر توکار معمولاً ایمن‌ترند.

## **کار با تصاویر SVG**

SVG یک قالب برداری است، بنابراین برای آیکن‌ها، نمودارها و گرافیک‌های دیگری که باید بدون از دست دادن جزئیات به‌صورت مقیاس‌پذیر باشند مفید است. Aspose.Slides هم به عنوان منبع تصویر و هم به‌عنوان منبعی برای اشکال ویرایش‌پذیر اسلاید از SVG پشتیبانی می‌کند.

### **افزودن SVG به‌عنوان تصویر**

یک `SvgImage` ایجاد کنید، آن را به مجموعهٔ تصویر اضافه کنید و منبع تصویر حاصل را در یک قاب تصویر قرار دهید.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **فایل‌های SVG با منابع خارجی**

یک SVG می‌تواند به تصاویر، stylesheetها یا فونت‌های خارجی ارجاع دهد. برای این موارد، `SvgImage` سازندگ‌هایی ارائه می‌دهد که یک `IExternalResourceResolver` و یک URI پایه می‌پذیرند. این حل‌کننده می‌تواند یک URI نسبی را به یک URI مطلق مجاز نگاشت کند و یک جریان برای منبع درخواست‌شده برگرداند.

حل‌کننده منابع خارجی را در حین پردازش SVG توسط Aspose.Slides در دسترس می‌گذارد، اما SVG را به یک سند خودکفا بازنویسی نمی‌کند. اگر SVG باید قابل حمل بماند، منابع مورد نیاز را در خود SVG تعبیه کنید، برای مثال با استفاده از URIهای `data:` برای تصاویر لینک‌دار.

هنگامی که فایل‌های SVG از منابع غیرقابل اعتماد می‌آیند، طرح‌ها، مکان‌های فایل و میزبان‌هایی را که حل‌کننده می‌تواند به آن‌ها دسترسی داشته باشد محدود کنید. حل‌کننده‌های شبکه باید همچنین زمان‌سنج‌ها، محدودیت‌های اندازهٔ پاسخ و اعتبارسنجی محتوا را اعمال کنند.

### **تبدیل SVG به اشکال ویرایش‌پذیر**

Aspose.Slides می‌تواند یک SVG را به گروهی از اشکال ویرایش‌پذیر اسلاید تبدیل کند، مشابه دستور مربوطه در PowerPoint.

![منوی پاپ‑آپ PowerPoint](img_01_01.png)

برای انجام تبدیل، overload `IShapeCollection.AddGroupShape` را که یک `ISvgImage` می‌پذیرد، استفاده کنید.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

از تبدیل SVG به اشکال زمانی استفاده کنید که عناصر برداری منفرد نیاز به ویرایش به‌عنوان اشکال PowerPoint داشته باشند. اگر SVG فقط برای نمایش نیاز است، نگه داشتن آن به‌عنوان تصویر ساده‌تر است و از ایجاد تعداد زیادی شکل جداگانه جلوگیری می‌کند.

## **جایگزینی یک منبع تصویر موجود**

زمانی که می‌خواهید یک منبع تصویر موجود را جایگزین کنید، از `IPPImage.ReplaceImage` استفاده کنید. این کار به‌ویژه برای گرافیک‌های مشترک مانند لوگوها مفید است.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

اگر چندین قاب تصویر، پس‌زمینه، مستر یا طرح‌بندی از همان منبع تصویر استفاده می‌کنند، جایگزینی آن منبع همهٔ موارد استفاده را به‌روز می‌کند. اگر فقط یک قاب تصویر باید تغییر کند، به‌جای جایگزینی منبع مشترک، تصویر متفاوتی به آن قاب اختصاص دهید.

`ReplaceImage` همچنین overloadهایی دارد که یک `IImage` یا یک `IPPImage` دیگر می‌پذیرند.

## **راهنمای عملی مدیریت تصویر**

### **کنترل حجم ارائه**

تصاویر رستر بزرگ می‌توانند حجم ارائه را به‌طور غیرضروری افزایش دهند. از تصاویر منبع با ابعاد مناسب برای اندازهٔ نمایش موردنظر استفاده کنید، در صورت امکان از منابع تصویر مشترک مجدداً استفاده کنید و از توکار کردن کپی‌های تکراری یک گرافیک با وضوح کامل خودداری کنید.

برای تصاویر رستری که قبلاً در قاب‌های تصویر قرار گرفته‌اند، `IPictureFillFormat.CompressImage` می‌تواند دادهٔ تصویر را بر اساس وضوح انتخابی و تنظیمات برش کاهش دهد. این پردازش مربوط به قاب تصویر است نه مدیریت مجموعهٔ تصویر، بنابراین برای عملیات قالب‌بندی مرتبط به [قاب تصویر](/slides/fa/net/picture-frame/) مراجعه کنید.

### **انتخاب بین محتوای توکار و لینک‌دار**

توکار کردن ارائه را قابل حمل می‌سازد زیرا تمام داده‌های تصویر موردنیاز همراه فایل می‌آیند. لینک‌دار کردن می‌تواند حجم فایل را کاهش دهد، اما وابستگی خارجی ایجاد می‌کند. لینک‌ها را فقط زمانی استفاده کنید که این وابستگی قابل قبول و پایدار باشد.

### **استفاده مجدد از برندینگ مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی تکراری، یک منبع تصویر استفاده کنید و آن را دوباره به‌کار ببرید. اگر گرافیک متعلق به طراحی ارائه باشد نه به محتوای اسلاید، آن را بر روی مستر یا طرح‌بندی قرار دهید تا توسط اسلایدهای مربوطه به ارث برسد.

### **نگهداری منابع SVG قابل حمل**

یک SVG خودکفا راحت‌تر می‌تواند جابه‌جا و به‌صورت ثابت رندر شود نسبت به SVGی که به فایل‌ها یا منابع شبکه‌ای خارجی وابسته است. در صورت امکان، پیش از وارد کردن SVG، منابع مورد نیاز را توکار کنید. تبدیل SVG به اشکال را فقط زمانی انجام دهید که عناصر برداری منفرد نیاز به ویرایش داشته باشند.

### **استفاده از API مدرن تصویر چندپلتفرمی**

برای کد جدید .NET، به‌جای اتکا به `System.Drawing.Image` یا `Bitmap`، از APIهای Aspose.Slides `IImage` و `Images` استفاده کنید. برای راهنمایی مهاجرت به [API مدرن](/slides/fa/net/modern-api/) مراجعه کنید.

WMF و EMF نیاز به ملاحظات ویژه‌ای دارند. وقتی این قالب‌ها از طریق یک `IImage` عبور می‌کنند، `ImageCollection.AddImage` پیش از درج، متافایل را به یک نمایه PNG رستر تبدیل می‌کند. اگر حفظ دادهٔ متافایل مهم باشد، به‌جای overload مبتنی بر مسیر، overload مبتنی بر جریان `ImageCollection.AddImage` را استفاده کنید. تولید محتوای EMF از صفحات گسترده یا محصولات دیگر یک جریان یکپارچه‌سازی جداگانه است و در محدودهٔ این مقاله نمی‌باشد.

## **پرسش‌های متداول**

**فرق بین مجموعهٔ تصویر و قاب تصویر چیست؟**

مجموعهٔ تصویر منابع تصویر قابل استفاده مجدد را ذخیره می‌کند. قاب تصویر یک شکل اسلاید است که یکی از این منابع را نمایش می‌دهد و قالب‌بندی خاص تصویر مانند برش و افکت‌ها را فراهم می‌کند.

**بهترین روش برای جایگزینی یک لوگو در همه‌جا چیست؟**

اگر لوگو قبلاً به‌عنوان یک منبع تصویر مشترک وجود داشته باشد، آن منبع را با `IPPImage.ReplaceImage` جایگزین کنید. برای برندینگ سراسری ارائه، قرار دادن لوگو بر روی مستر یا طرح‌بندی نیز می‌تواند محتوای تکراری اسلایدها را کاهش دهد.

**چرا یک تصویر لینک‌دار در کامپیوتر دیگر ناپدید می‌شود؟**

یک تصویر لینک‌دار به فایل یا URL خارجی خود وابسته است. اگر آن منبع از کامپیوتر دیگر قابل دسترسی نباشد، تصویر لینک‌دار ممکن است در دسترس نباشد. زمانی که ارائه باید خودکفا باشد، تصویر را توکار کنید.

**آیا می‌توان یک SVG درج‌شده را به‌عنوان اشکال PowerPoint ویرایش کرد؟**

بله. با استفاده از `IShapeCollection.AddGroupShape` SVG را تبدیل کنید؛ گروه حاصل شامل اشکال ویرایش‌پذیر اسلاید است نه یک تصویر SVG واحد.

**چگونه می‌توانم ارائه‌های حاوی تصاویر متعدد را کوچکتر نگه دارم؟**

از منابع تصویر مشترک استفاده مجدد کنید، از منابع رستری غیرضروری بزرگ خودداری کنید، در مواقع مناسب تصاویر رستری مناسب را فشرده کنید، برندینگ تکراری را بر روی مستر یا طرح‌بندی نگه دارید و فقط در صورت پذیرش وابستگی خارجی، از تصاویر لینک‌دار استفاده کنید.