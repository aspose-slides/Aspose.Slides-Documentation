---
title: افزودن واترمارک‌ها به ارائه‌ها در .NET
linktitle: واترمارک
type: docs
weight: 40
url: /fa/net/watermark/
keywords:
- واترمارک
- واترمارک متنی
- واترمارک تصویری
- اضافه کردن واترمارک
- تغییر واترمارک
- حذف واترمارک
- پاک کردن واترمارک
- اضافه کردن واترمارک به PPT
- اضافه کردن واترمارک به PPTX
- اضافه کردن واترمارک به ODP
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
description: "در .NET، واترمارک‌های متنی و تصویری را در ارائه‌های PowerPoint و OpenDocument مدیریت کنید تا پیش‌نویس، اطلاعات محرمانه، حق کپی‌رایت و موارد دیگر را نشان دهند."
---
## **مقدمه**

**یک واترمارک** در یک ارائه، متن یا تصویرمطبوعی است که بر روی یک اسلاید یا تمام اسلایدهای ارائه قرار می‌گیرد. معمولاً واترمارک برای نشان دادن این که ارائه یک پیش‌نویس است (به عنوان مثال، واترمارک «پیش‌نویس»)، حاوی اطلاعات محرمانه است (به عنوان مثال، واترمارک «محرمانه»)، تعلق به یک شرکت خاص را نشان می‌دهد (به عنوان مثال، واترمارک «نام شرکت»)، شناسایی نویسندهٔ ارائه و غیره استفاده می‌شود. واترمارک به جلوگیری از نقض حق کپی‌رایت کمک می‌کند زیرا نشان می‌دهد که ارائه نباید کپی شود. واترمارک‌ها هم در فرمت‌های PowerPoint و هم در فرمت‌های OpenDocument استفاده می‌شوند. در Aspose.Slides می‌توانید واترمارک را به فرمت‌های PowerPoint PPT، PPTX و OpenDocument ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/net/)، راه‌های مختلفی برای ایجاد واترمارک در اسناد PowerPoint یا OpenDocument و تغییر طرح و رفتار آن‌ها وجود دارد. نکته مشترک این است که برای افزودن واترمارک متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) استفاده کنید و برای افزودن واترمارک تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/pictureframe/) یا پر کردن یک شکل واترمارک با تصویر استفاده کنید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) را پیاده‌سازی می‌کند و به شما امکان استفاده از تمام تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجا که `ITextFrame` یک شکل نیست و تنظیمات آن محدود است، در یک شیء [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape) بسته می‌شود.

دو روش برای اعمال واترمارک وجود دارد: به یک اسلاید واحد یا به تمام اسلایدهای ارائه. برای اعمال واترمارک به تمام اسلایدها از Slide Master استفاده می‌شود — واترمارک به Slide Master اضافه می‌شود، در آنجا به طور کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه اجازهٔ ویرایش واترمارک در اسلایدهای فردی را تحت تأثیر قرار دهد.

معمولاً واترمارک برای کاربران دیگر غیرقابل ویرایش در نظر گرفته می‌شود. برای جلوگیری از ویرایش واترمارک (یا بهتر بگوییم شکل مادر واترمارک) Aspose.Slides قابلیت قفل‌گذاری شکل را فراهم می‌کند. یک شکل خاص می‌تواند در اسلاید عادی یا در Slide Master قفل شود. وقتی شکل واترمارک در Slide Master قفل شود، در تمام اسلایدهای ارائه قفل می‌ماند.

می‌توانید برای واترمارک نامی تعیین کنید تا در آینده، اگر بخواهید آن را حذف کنید، بتوانید آن را به‌وسیله نام در بین اشکال اسلاید پیدا کنید.

می‌توانید واترمارک را به هر شکلی طراحی کنید؛ اما معمولاً ویژگی‌های مشترکی در واترمارک‌ها وجود دارد، مانند تراز وسط، چرخش، موقعیت جلو و غیره. در مثال‌های زیر به نحوه استفاده از این ویژگی‌ها می‌پردازیم.

## **واترمارک متنی**

### **افزودن واترمارک متنی به یک اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متن به این شکل اضافه کنید. فریم متن توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe) نمایندگی می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) ارث‌بری نمی‌کند و مجموعهٔ وسیعی از ویژگی‌های موقعیت‌یابی انعطاف‌پذیر را در اختیار ندارند. بنابراین شیء [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe) در یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) بسته می‌شود. برای افزودن متن واترمارک به شکل، از متد [AddTextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/methods/addtextframe) همان‌طور که در زیر نشان داده شده استفاده کنید.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// واترمارک را به اسلاید اضافه کنید.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [چگونه از کلاس TextFrame استفاده کنیم؟](/slides/fa/net/text-formatting/)
{{% /alert %}}

### **افزودن واترمارک متنی به یک ارائه**

اگر می‌خواهید واترمارک متنی را به کل ارائه (یعنی تمام اسلایدها به‌صورت همزمان) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/masterslide/) اضافه کنید. بقیه منطق مشابه افزودن واترمارک به یک اسلاید است — یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [AddTextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/methods/addtextframe) واترمارک را به آن اضافه کنید.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// واترمارک را به اسلاید اصلی اضافه کنید.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [چگونه از Slide Master استفاده کنیم؟](/slides/fa/net/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به‌صورت پیش‌فرض، شکل مستطیل با رنگ پر و رنگ خط استایل می‌شود. این به این معنی است که وقتی واترمارک اضافه شود، ممکن است پس‌زمینه یا مرزی جامد داشته باشد که می‌تواند از محتوای اسلاید حواس‌پرت کند. برای اطمینان از اینکه واترمارک به‌صورت ظریف باقی می‌ماند و با طراحی بصری ارائه تداخل ندارد، می‌توانید شکل را کاملاً شفاف کنید.

کدهای زیر شکل را با حذف هر دو رنگ پر و مرز شفاف می‌کند:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **تنظیم قلم برای واترمارک متنی**

قبل از اعمال واترمارک متنی بر اسلاید، مهم است ظاهر آن را سفارشی کنید تا با طراحی کلی هم‌خوانی داشته باشد. می‌توانید نوع و اندازهٔ قلم را تغییر دهید تا واترمارک هم خوانا و هم زیبا باشد. سفارشی‌سازی قلم می‌تواند به تقویت هویت برند یا صرفاً مطابقت با سبک ارائه کمک کند.

قطعه کد زیر نشان می‌دهد چگونه تنظیمات قلم واترمارک را با انتخاب یک قلم لاتین خاص و تنظیم ارتفاع مناسب قلم انجام دهید:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **تنظیم رنگ متن واترمارک**

پیش از اعمال واترمارک، ضروری است رنگ متن به‌گونه‌ای تنظیم شود که با محتوای اسلاید ترکیب شود بدون اینکه بیش از حد برجسته باشد. تنظیم شفافیت رنگ (آلفا) به‌همراه مؤلفه‌های قرمز، سبز و آبی به شما امکان می‌دهد واترمارکی نیمه‌شفاف و ظریف ایجاد کنید که قابل مشاهده اما کم‌تداخل باشد. این رویکرد تمرکز بر ارائهٔ اصلی را حفظ می‌کند در حالی که همچنان محتوای شما را محافظت می‌کند.

برای تنظیم رنگ متن واترمارک، از کد زیر استفاده کنید:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **مرکزی‌سازی واترمارک متنی**

مرکز‌گذاری صحیح واترمارک متنی می‌تواند زیبایی کلی ارائه را به‌طور قابل توجهی ارتقا دهد، زیرا واترمارک به‌صورت متقارن نسبت به ابعاد اسلاید قرار می‌گیرد. این کار نه تنها ظاهر حرفه‌ای به اسلایدها می‌بخشد، بلکه اطمینان می‌دهد که واترمارک محتوا اصلی اسلاید را مختل نمی‌کند.

قطعه کد زیر نشان می‌دهد چگونه موقعیت مرکز اسلاید را محاسبه کرده و واترمارک متنی را مطابق آن قرار دهید:

```cs
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

![The text watermark](text_watermark.png)

## **واترمارک تصویری**

### **افزودن واترمارک تصویری به یک ارائه**

در بسیاری از موارد، واترمارک تصویری می‌تواند عنصر برندینگ منحصربه‌فرد یا جایگزینی بصری جذاب‌تر نسبت به واترمارک متنی ارائه دهد. قبل از افزودن واترمارک، مطمئن شوید که فایل تصویر در دسترس است (مثلاً PNG برای شفافیت). مثال زیر نشان می‌دهد چگونه یک تصویر را از سیستم فایل بارگذاری کنید، به ارائه اضافه کنید و سپس به‌وسیلهٔ ویژگی پر کردن شکل، به‌عنوان واترمارک اعمال کنید.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **قفل کردن واترمارک در برابر ویرایش**

اگر لازم باشد از ویرایش واترمارک جلوگیری کنید، از ویژگی [IAutoShape.ShapeLock](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/properties/shapelock) بر روی شکل استفاده کنید. با این ویژگی می‌توانید از انتخاب، تغییر اندازه، جابه‌جا کردن، گروه‌بندی با عناصر دیگر، قفل متن در برابر ویرایش و موارد بیشتر برای شکل جلوگیری کنید:

```cs
// قفل کردن شکل واترمارک برای جلوگیری از تغییر.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **آوردن واترمارک به جلو**

در Aspose.Slides، ترتیب Z اشکال می‌تواند از طریق متد [IShapeCollection.Reorder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/reorder/#reorder) تنظیم شود. برای انجام این کار، باید این متد را از لیست اسلایدهای ارائه فراخوانی کنید و مرجع شکل و شماره ترتیب آن را به‌عنوان پارامتر به متد بدهید. به این ترتیب می‌توانید شکلی را به جلو یا به عقب اسلاید برسانید. این قابلیت به‌ویژه زمانی مفید است که نیاز داشته باشید واترمارک را جلوی ارائه قرار دهید:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **تنظیم چرخش واترمارک**

تنظیم چرخش واترمارک می‌تواند تأثیر بصری و ظرافت ارائه را به‌طور قابل ملاحظه‌ای بهبود بخشد. به‌عنوان مثال، واترمارک قطری می‌تواند کم‌تداخل‌تر باشد و همچنان محافظت قوی در برابر استفادهٔ غیرمجاز ارائه دهد. مثال زیر زاویه مناسب را بر اساس ابعاد اسلاید محاسبه می‌کند تا واترمارک به‌صورت قطری در سراسر اسلاید قرار گیرد. این محاسبهٔ پویا اطمینان می‌دهد که واترمارک بدون توجه به اندازه‌های متفاوت اسلاید مؤثر بماند.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **تنظیم نام برای واترمارک**

Aspose.Slides امکان تنظیم نام برای یک شکل را فراهم می‌کند. با استفاده از نام شکل، می‌توانید در آینده به آن دسترسی پیدا کنید تا آن را تغییر یا حذف کنید. برای تنظیم نام شکل واترمارک، مقدار آن را به ویژگی [IAutoShape.Name](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/name) اختصاص دهید:

```cs
watermarkShape.Name = "watermark";
```

## **حذف واترمارک**

برای حذف شکل واترمارک، از ویژگی [IAutoShape.Name](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/properties/name) برای پیدا کردن آن در اشکال اسلاید استفاده کنید. سپس شکل واترمارک را به متد [IShapeCollection.Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/remove/) پاس دهید:

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **یک مثال زنده**

ممکن است بخواهید ابزارهای آنلاین **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/fa/watermark) و [Remove Watermark](https://products.aspose.app/slides/fa/watermark/remove-watermark) را بررسی کنید.

![Online tools to add and remove watermarks](online_tools.png)

## **سوالات متداول**

**واترمارک چیست و چرا باید از آن استفاده کنم؟**

یک واترمارک، پوشش متنی یا تصویری‌ای است که بر روی اسلایدها اعمال می‌شود و به محافظت از مالکیت فکری، تقویت شناخت برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

**آیا می‌توانم واترمارک را به همه اسلایدهای یک ارائه اضافه کنم؟**

 بله، Aspose.Slides امکان افزودن برنامه‌نویسی شدهٔ واترمارک به هر اسلاید از یک ارائه را فراهم می‌کند. می‌توانید بر روی تمام اسلایدها پیمایش کنید و تنظیمات واترمارک را به‌صورت جداگانه اعمال کنید.

**چگونه می‌توانم شفافیت واترمارک را تنظیم کنم؟**

می‌توانید شفافیت واترمارک را با تغییر تنظیمات پر ([FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/fillformat/)) شکل تنظیم کنید. این کار اطمینان می‌دهد که واترمارک به‌صورت ظریف باقی می‌ماند و از محتوای اسلاید حواس‌پرت نمی‌شود.

**چه قالب‌های تصویری برای واترمارک پشتیبانی می‌شود؟**

Aspose.Slides قالب‌های تصویری متنوعی مانند PNG، JPEG، GIF، BMP، SVG و موارد دیگر را پشتیبانی می‌کند.

**آیا می‌توانم قلم و سبک واترمارک متنی را سفارشی کنم؟**

بله، می‌توانید هر قلم، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه‌تان مطابقت داشته باشد و سازگاری برند را حفظ کنید.

**چگونه می‌توانم موقعیت یا جهت‌گیری واترمارک را تغییر دهم؟**

می‌توانید موقعیت و جهت‌گیری واترمارک را برنامه‌نویسی با تغییر مختصات، اندازه و ویژگی‌های چرخش شکل تنظیم کنید.