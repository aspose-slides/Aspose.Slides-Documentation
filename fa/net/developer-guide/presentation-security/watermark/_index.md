---
title: افزودن واترمارک به ارائه‌ها در .NET
linktitle: واترمارک
type: docs
weight: 40
url: /fa/net/watermark/
keywords:
- واترمارک
- واترمارک متنی
- واترمارک تصویری
- افزودن واترمارک
- تغییر واترمارک
- حذف واترمارک
- پاک کردن واترمارک
- افزودن واترمارک به PPT
- افزودن واترمارک به PPTX
- افزودن واترمارک به ODP
- حذف واترمارک از PPT
- حذف واترمارک از PPTX
- حذف واترمارک از ODP
- پاک کردن واترمارک از PPT
- پاک کردن واترمارک از PPTX
- پاک کردن واترمارک از ODP
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت واترمارک‌های متنی و تصویری در ارائه‌های PowerPoint و OpenDocument در .NET برای نشان‌دادن پیش‌نویس، اطلاعات محرمانه، حق تکثیر و موارد دیگر."
---
## **مقدمه**

**یک watermark** در یک ارائه، یک متن یا تصویر است که به یک اسلاید یا تمام اسلایدهای ارائه اضافه می‌شود. معمولاً از watermark برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً watermark «Draft»)، اینکه شامل اطلاعات محرمانه است (مثلاً watermark «Confidential»)، برای مشخص کردن شرکت متعلق به آن (مثلاً watermark «Company Name»)، برای شناسایی نویسنده ارائه و غیره استفاده می‌شود. watermark به جلوگیری از نقض حق کپی‌رایت کمک می‌کند زیرا نشان می‌دهد که ارائه نباید کپی شود. watermarkها هم در قالب PowerPoint و هم در قالب OpenDocument استفاده می‌شود. در Aspose.Slides می‌توانید watermark را به فرمت‌های فایل PowerPoint PPT، PPTX و OpenDocument ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/net/) روش‌های مختلفی برای ایجاد watermark در اسناد PowerPoint یا OpenDocument و اصلاح طراحی و رفتار آن‌ها وجود دارد. نکته مشترک این است که برای افزودن watermark متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) استفاده کنید و برای افزودن watermark تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) یا پر کردن یک شکل watermark با تصویر استفاده کنید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) را پیاده‌سازی می‌کند و به شما امکان استفاده از تمام تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. چون `ITextFrame` یک شکل نیست و تنظیماتش محدود است، در یک شیء [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) بسته می‌شود.

دو روش برای اعمال watermark وجود دارد: به یک اسلاید واحد یا به تمام اسلایدهای ارائه. برای افزودن watermark به تمام اسلایدها از Slide Master استفاده می‌شود — watermark به Slide Master اضافه می‌شود، در آنجا به‌طور کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه اجازه ویرایش watermark در اسلایدهای جداگانه تحت تأثیر قرار گیرد.

یک watermark معمولاً به‌عنوان غیرقابل ویرایش توسط سایر کاربران در نظر گرفته می‌شود. برای جلوگیری از ویرایش watermark (یا بهتر بگوییم شکل والد watermark) Aspose.Slides قابلیت قفل‌کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در یک اسلاید عادی یا در Slide Master قفل شود. وقتی شکل watermark در Slide Master قفل شود، در تمام اسلایدهای ارائه نیز قفل خواهد بود.

می‌توانید برای watermark یک نام تعیین کنید تا در آینده، اگر بخواهید آن را حذف کنید، بتوانید آن را بر اساس نام در لیست اشکال اسلاید پیدا کنید.

شما می‌توانید watermark را به هر شکلی طراحی کنید؛ اما معمولاً ویژگی‌های مشترکی مانند ترازبندی وسط، چرخش، موقعیت جلو و غیره در watermarkها وجود دارد. در مثال‌های زیر نحوه استفاده از این ویژگی‌ها را بررسی می‌کنیم.

## **Watermark متنی**

### **افزودن Watermark متنی به یک اسلاید**

برای افزودن watermark متنی در PPT، PPTX یا ODP ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متنی به این شکل اضافه کنید. فریم متنی توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe) نمایش داده می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) ارث‌بری نمی‌کند، در حالی که [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) مجموعه‌ای گسترده از ویژگی‌های موقعیت‌یابی را برای تنظیم watermark به‌صورت انعطاف‌پذیر فراهم می‌کند. بنابراین شیء [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe) در یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) بسته می‌شود. برای افزودن متن watermark به شکل، از متد [AddTextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/methods/addtextframe) همان‌طور که در زیر نشان داده شده استفاده کنید.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// واترمارک را به اسلاید اضافه کنید.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="همچنین ببینید" %}} 
- [چگونه از کلاس TextFrame استفاده کنیم؟](/slides/fa/net/text-formatting/)
{{% /alert %}}

### **افزودن Watermark متنی به یک ارائه**

اگر می‌خواهید watermark متنی را به کل ارائه (یعنی همه اسلایدها به‌صورت همزمان) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/masterslide/) اضافه کنید. منطق باقی مانده همانند افزودن watermark به یک اسلاید واحد است — یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [AddTextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/methods/addtextframe) watermark را به آن اضافه نمایید.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// واترمارک را به اسلاید اصلی اضافه کنید.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="همچنین ببینید" %}} 
- [چگونه از Slide Master استفاده کنیم؟](/slides/fa/net/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل Watermark**

به‌صورت پیش‌فرض، شکل مستطیلی با رنگ پر و رنگ خط استایل می‌شود. این به این معناست که وقتی watermark اضافه می‌شود، ممکن است با پس‌زمینه یا حاشیه‌ای ثابت ظاهر شود که می‌تواند حواس‌پرتی ایجاد کند. برای اطمینان از اینکه watermark به‌صورت دقیق و بدون تداخل با طرح بصری اسلاید باقی بماند، می‌توانید شکل را کاملاً شفاف کنید.

خطوط کد زیر با حذف هر دو رنگ پر و خط، شکل را شفاف می‌کند:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **تنظیم فونت برای Watermark متنی**

قبل از اعمال watermark متنی به اسلاید، مهم است که ظاهر آن را سفارشی کنید تا با طراحی کلی هماهنگ باشد. می‌توانید نوع و اندازه فونت را تغییر دهید تا watermark هم قابل خواندن باشد و هم از لحاظ زیبایی جذاب باشد. سفارشی‌سازی فونت می‌تواند به تقویت هویت برند یا صرفاً مطابقت با سبک ارائه کمک کند.

کد زیر نحوه تنظیم فونت watermark را با انتخاب یک فونت لاتین خاص و تنظیم ارتفاع مناسب نشان می‌دهد:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **تنظیم رنگ متن Watermark**

قبل از اعمال watermark، ضروری است که رنگ متن به‌گونه‌ای تنظیم شود که با محتوای اسلاید ترکیب شود بدون این‌که بر آن غلبه کند. تنظیم شفافیت (آلفا) به همراه مؤلفه‌های قرمز، سبز و آبی به شما امکان می‌دهد watermark نیمه‌شفاف و ظریف ایجاد کنید که قابل مشاهده اما نامرئی باشد. این روش به حفظ تمرکز بر محتوا کمک می‌کند و در عین حال محتوای شما را محافظت می‌نماید.

برای تنظیم رنگ متن watermark، از کد زیر استفاده کنید:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **وسط‌چین کردن Watermark متنی**

قرار دادن درست watermark متنی در مرکز می‌تواند زیبایی کلی ارائه را به‌طور قابل توجهی ارتقا دهد، زیرا watermark به‌صورت متقارن در هر ابعاد اسلاید قرار می‌گیرد. این کار نه تنها ظاهر حرفه‌ای به اسلایدها می‌بخشد بلکه از تداخل watermark با محتوای اصلی اسلاید جلوگیری می‌کند.

کد زیر نحوه محاسبه موقعیت مرکز اسلاید و قرار دادن watermark متنی را نشان می‌دهد:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

تصویر زیر نتیجه نهایی را نشان می‌دهد.

![نشان‌گذاری متنی](text_watermark.png)

## **Watermark تصویری**

### **افزودن Watermark تصویری به یک ارائه**

در بسیاری از موارد، watermark تصویری می‌تواند عنصر برندینگ منحصر به‌فرد یا گزینه‌ای بصری جذاب‌تر نسبت به watermark متنی فراهم کند. قبل از افزودن watermark، اطمینان حاصل کنید که فایل تصویر در دسترس باشد (مثلاً PNG برای شفافیت). مثال زیر نحوه بارگذاری یک تصویر از سیستم فایل، افزودن آن به ارائه و سپس اعمال به‌عنوان watermark با استفاده از ویژگی‌های پر کردن شکل را نشان می‌دهد.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **قفل کردن Watermark از ویرایش**

اگر نیاز باشد که از ویرایش watermark جلوگیری کنید، از ویژگی [IAutoShape.ShapeLock](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/properties/shapelock) بر روی شکل استفاده کنید. با این ویژگی می‌توانید شکل را از انتخاب، تغییر اندازه، تغییر مکان، گروه‌بندی با سایر عناصر، قفل کردن متن از ویرایش و موارد دیگر محافظت نمایید:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// قفل کردن شکل واترمارک از تغییر.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **بردن Watermark به جلو**

در Aspose.Slides می‌توانید ترتیب Z اشکال را با متد [IShapeCollection.Reorder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/reorder/#reorder) تنظیم کنید. برای این کار، باید این متد را از لیست اسلایدهای ارائه فراخوانی کنید و مرجع شکل و شماره ترتیب آن را به‌عنوان پارامتر به متد بدهید. به این ترتیب می‌توانید یک شکل را به جلو یا به عقب اسلاید برورید. این ویژگی به‌ویژه زمانی مفید است که بخواهید watermark را در جلوی ارائه قرار دهید:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **تنظیم چرخش Watermark**

تنظیم چرخش watermark می‌تواند تأثیر بصری و ظرافت ارائه را به‌طور قابل توجهی افزایش دهد. یک watermark قطری، به‌عنوان مثال، می‌تواند کم‌حجمت‌تر باشد در حالی که همچنان حفاظت قوی در برابر استفاده غیرمجاز فراهم می‌کند. مثال زیر زاویه مناسب را بر اساس ابعاد اسلاید محاسبه می‌کند تا watermark به‌صورت قطری در اسلاید قرار گیرد. این محاسبه پویا تضمین می‌کند که watermark صرف‌نظر از اندازه‌های مختلف اسلاید مؤثر بماند.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **تعیین نام برای Watermark**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تنظیم کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی پیدا کنید تا آن را اصلاح یا حذف کنید. برای تنظیم نام شکل watermark، مقدار آن را به ویژگی [IAutoShape.Name](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/name) اختصاص دهید:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **حذف Watermark**

برای حذف شکل watermark، از ویژگی [IAutoShape.Name](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/name) استفاده کنید تا آن را در اشکال اسلاید پیدا کنید. سپس شکل watermark را به متد [IShapeCollection.Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/remove/) پاس بدهید:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **یک مثال زنده**

ممکن است بخواهید ابزارهای آنلاین **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/fa/watermark) و [Remove Watermark](https://products.aspose.app/slides/fa/watermark/remove-watermark) را بررسی کنید.

![ابزارهای آنلاین برای افزودن و حذف watermarkها](online_tools.png)

## **سؤالات متداول**

### watermark چیست و چرا باید از آن استفاده کنم؟

watermark یک متن یا تصویر پوششی است که بر اسلایدها اعمال می‌شود و به محافظت از مالکیت فکری، افزایش شناسایی برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

### آیا می‌توانم watermark را به تمام اسلایدهای یک ارائه اضافه کنم؟

بله، Aspose.Slides به شما اجازه می‌دهد که برنامه‌نویسی watermark را به هر اسلایدی از یک ارائه اضافه کنید. می‌توانید به تمام اسلایدها پیمایش کنید و تنظیمات watermark را به‌صورت جداگانه اعمال کنید.

### چگونه می‌توانم شفافیت watermark را تنظیم کنم؟

می‌توانید شفافیت watermark را با تغییر تنظیمات پر (FillFormat) شکل تنظیم کنید. این کار اطمینان می‌دهد که watermark نامحسوس باشد و حواس‌پرتی ایجاد نکند.

### چه قالب‌های تصویری برای watermark پشتیبانی می‌شوند؟

Aspose.Slides قالب‌های تصویری مختلفی مانند PNG، JPEG، GIF، BMP، SVG و غیره را پشتیبانی می‌کند.

### آیا می‌توانم فونت و سبک watermark متنی را سفارشی کنم؟

بله، می‌توانید هر فونت، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما هم‌خوانی داشته باشد و سازگاری برند را حفظ کنید.

### چگونه موقعیت یا جهت‌گیری watermark را تغییر دهم؟

می‌توانید موقعیت و جهت‌گیری watermark را برنامه‌نویسی با تغییر مختصات، اندازه و ویژگی‌های چرخش شکل تنظیم کنید.