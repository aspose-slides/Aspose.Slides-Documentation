---
title: مدیریت زوم ارائه در .NET
linktitle: مدیریت زوم
type: docs
weight: 60
url: /fa/net/manage-zoom/
keywords:
- زوم
- فریم زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- افزودن زوم
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای .NET — پرش بین بخش‌ها، افزودن تصویر کوچک و انتقال‌ها در ارائه‌های PPT، PPTX و ODP."
---
## **مقدمه**

Zoomها در PowerPoint به شما امکان می‌دهند تا به اسلایدها، بخش‌ها و قسمت‌های خاصی از ارائه پرش کنید و از آن‌ها خارج شوید. هنگام ارائه، این قابلیت برای ناوبری سریع در محتوا بسیار مفید است. 

![تصویر_نمای_کلی](overview.png)

* برای خلاصه‌کردن تمام ارائه در یک اسلاید، از [Zoom خلاصه](#Summary-Zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخابی، از [Zoom اسلاید](#Slide-Zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از [Zoom بخش](#Section-Zoom) استفاده کنید.

## **Zoom اسلاید**
Zoom اسلاید می‌تواند ارائه شما را پویاتر کند و به شما اجازه دهد بین اسلایدها به هر ترتیبی که می‌خواهید حرکت کنید بدون این‌که جریان ارائه شما مختل شود. Zoomهای اسلاید برای ارائه‌های کوتاه بدون بخش‌های زیاد عالی هستند، اما می‌توانید آن‌ها را در سناریوهای مختلف ارائه به کار ببرید.

Zoomهای اسلاید به شما کمک می‌کنند تا به صورت همزمان به قسمت‌های مختلف اطلاعات دسترسی داشته باشید همانند اینکه بر روی یک بوم واحد کار می‌کنید. 

![تصویر_نمای_کلی](slidezoomsel.png)

برای اشیای Zoom اسلاید، Aspose.Slides ویژگی‌های زیر را فراهم می‌کند: مقدار enumerations [ZoomImageType](https://reference.aspose.com/slides/fa/net/aspose.slides/zoomimagetype)، اینترفیس [IZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/izoomframe) و برخی متدها در زیر اینترفیس [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection).

### **ایجاد فریم‌های Zoom**

می‌توانید یک فریم Zoom را روی اسلاید به این روش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلایدهای جدیدی ایجاد کنید که قصد دارید فریم‌های Zoom به آن‌ها لینک شود. 
3. متن شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. فریم‌های Zoom (که به اسلایدهای ایجاد شده اشاره می‌کنند) را به اسلاید اول اضافه کنید.
5. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک فریم Zoom روی اسلاید ایجاد کنید:

``` csharp 
using (Presentation pres = new Presentation())
{
    //اسلایدهای جدید را به ارائه اضافه می‌کند
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // یک جعبه متنی برای اسلاید دوم ایجاد می‌کند
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // یک پس‌زمینه برای اسلاید سوم ایجاد می‌کند
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // یک جعبه متنی برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //اشیای ZoomFrame را اضافه می‌کند
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **ایجاد فریم‌های Zoom با تصاویر سفارشی**
با Aspose.Slides برای .NET می‌توانید فریم Zoom را با تصویر پیش‌نمایش متفاوتی به این صورت ایجاد کنید: 
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید که قصد دارید فریم Zoom به آن لینک شود. 
3. متن شناسایی و پس‌زمینه‌ای به اسلاید اضافه کنید.
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا فریم را پر کند.
5. فریم‌های Zoom (که به اسلاید ایجاد شده اشاره می‌کنند) را به اسلاید اول اضافه کنید.
6. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه فریم Zoom را با تصویر متفاوتی ایجاد کنید:

``` csharp 
using (Presentation pres = new Presentation())
{
    // اسلاید جدیدی به ارائه اضافه می‌کند
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // یک جعبه متنی برای اسلاید سوم ایجاد می‌کند
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // شیء ZoomFrame را اضافه می‌کند
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **قالب‌بندی فریم‌های Zoom**
در بخش‌های قبلی نحوهٔ ایجاد فریم‌های Zoom ساده را نشان دادیم. برای ایجاد فریم‌های Zoom پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید به فریم Zoom اعمال کنید. 

می‌توانید قالب‌بندی فریم Zoom را روی اسلاید به این روش کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلایدهای جدیدی برای لینک کردن به فریم Zoom ایجاد کنید. 
3. متن شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. فریم‌های Zoom (که به اسلایدهای ایجاد شده اشاره می‌کنند) را به اسلاید اول اضافه کنید.
5. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا فریم را پر کند.
6. تصویر سفارشی را برای اولین فریم Zoom تنظیم کنید.
7. قالب خط را برای فریم Zoom دوم تغییر دهید.
8. پس‌زمینه تصویر فریم Zoom دوم را حذف کنید.
9. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه قالب‌بندی فریم Zoom را روی اسلاید تغییر دهید: 

``` csharp 
using (Presentation pres = new Presentation())
{
    //اسلایدهای جدید را به ارائه اضافه می‌کند
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //یک پس‌زمینه برای اسلید دوم ایجاد می‌کند
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //یک جعبه متنی برای اسلاید دوم ایجاد می‌کند
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //یک پس‌زمینه برای اسلید سوم ایجاد می‌کند
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //یک جعبه متنی برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //اشیای ZoomFrame را اضافه می‌کند
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //تصویر سفارشی را برای شیء zoomFrame1 تنظیم می‌کند
    zoomFrame1.ZoomImage = ppImage;

    //قالب فریم زوم را برای شیء zoomFrame2 تنظیم می‌کند
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    //تنظیم برای عدم نمایش پس‌زمینه برای شیء zoomFrame2
    zoomFrame2.ShowBackground = false;

    //ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Zoom بخش**

Zoom بخش یک لینک به یک بخش در ارائهٔ شماست. می‌توانید از Zoomهای بخش برای بازگشت به بخش‌هایی که می‌خواهید به‌طور ویژه‌ای برجسته کنید استفاده کنید. یا می‌توانید از آن‌ها برای نشان دادن نحوهٔ ارتباط بخش‌های مختلف ارائهٔ خود بهره ببرید. 

![تصویر_نمای_کلی](seczoomsel.png)

برای اشیای Zoom بخش، Aspose.Slides این اینترفیس‌ها و متدها را فراهم می‌کند: [ISectionZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/isectionzoomframe) و برخی متدها در زیر اینترفیس [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection).

### **ایجاد فریم‌های Zoom بخش**

می‌توانید یک فریم Zoom بخش را به اسلاید اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید. 
3. پس‌زمینهٔ شناسایی را به اسلاید ایجاد شده اضافه کنید.
4. بخش جدیدی ایجاد کنید که قصد دارید فریم Zoom به آن لینک شود. 
5. فریم Zoom بخش (که به بخش ایجاد شده اشاره می‌کند) را به اسلاید اول اضافه کنید.
6. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک فریم Zoom روی اسلاید ایجاد کنید:

``` csharp 
using (Presentation pres = new Presentation())
{
    //اسلاید جدیدی به ارائه اضافه می‌کند
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 1", slide);

    // یک شیء SectionZoomFrame اضافه می‌کند
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **ایجاد فریم‌های Zoom بخش با تصاویر سفارشی**

با استفاده از Aspose.Slides برای .NET می‌توانید فریم Zoom بخش را با تصویر پیش‌نمایش متفاوتی به این صورت ایجاد کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید.
3. پس‌زمینهٔ شناسایی را به اسلاید ایجاد شده اضافه کنید.
4. بخش جدیدی ایجاد کنید که قصد دارید فریم Zoom به آن لینک شود. 
5. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا فریم را پر کند.
6. فریم Zoom بخش (که به بخش ایجاد شده اشاره می‌کند) را به اسلاید اول اضافه کنید.
7. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه فریم Zoom را با تصویر متفاوتی ایجاد کنید:

``` csharp 
using (Presentation pres = new Presentation())
{
    //اسلاید جدیدی به ارائه اضافه می‌کند
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 1", slide);

    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // شیء SectionZoomFrame را اضافه می‌کند
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **قالب‌بندی فریم‌های Zoom بخش**

برای ایجاد فریم‌های Zoom بخش پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی برای فریم Zoom بخش وجود دارد. 

می‌توانید قالب‌بندی فریم Zoom بخش را روی اسلاید به این روش کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید.
3. پس‌زمینهٔ شناسایی را به اسلاید اضافه کنید.
4. بخش جدیدی ایجاد کنید که قصد دارید فریم Zoom به آن لینک شود. 
5. فریم Zoom بخش (که به بخش ایجاد شده اشاره می‌کند) را به اسلاید اول اضافه کنید.
6. اندازه و موقعیت شیء Zoom بخش ایجاد شده را تغییر دهید.
7. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا فریم را پر کند.
8. تصویر سفارشی را برای فریم Zoom بخش تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
10. پس‌زمینهٔ تصویر فریم Zoom بخش را حذف کنید.
11. قالب خط فریم Zoom دوم را تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه قالب‌بندی فریم Zoom بخش را تغییر دهید:

``` csharp 
using (Presentation pres = new Presentation())
{
    //Adds a new slide to the presentation
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Adds a new Section to the presentation
    pres.Sections.AddSection("Section 1", slide);

    // Add SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formatting for SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Saves the presentation
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Zoom خلاصه**

Zoom خلاصه شبیه یک صفحهٔ لندینگ است که تمام قسمت‌های ارائه‌تان به‌یک‌بار نمایش داده می‌شود. هنگام ارائه می‌توانید از Zoom استفاده کنید تا از یک نقطه به نقطهٔ دیگر به هر ترتیبی که بخواهید پرش کنید. می‌توانید خلاق باشید، جلو بزنید یا بخش‌های اسلایدشو را بدون قطع جریان ارائه‌تان دوباره ببینید.

![تصویر_نمای_کلی](sumzoomsel.png)

برای اشیای Zoom خلاصه، Aspose.Slides این اینترفیس‌ها و متدها را فراهم می‌کند: [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomframe)، [ISummaryZoomFrameSection](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomsection) و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomsectioncollection) و برخی متدها در زیر اینترفیس [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection).

### **ایجاد Zoom خلاصه**

می‌توانید یک فریم Zoom خلاصه را به اسلاید اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده بسازید.
3. فریم Zoom خلاصه را به اسلاید اول اضافه کنید.
4. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک فریم Zoom خلاصه روی اسلاید ایجاد کنید:

``` csharp 
using (Presentation pres = new Presentation())
{
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 1", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 2", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 3", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 4", slide);

    // یک شیء SummaryZoomFrame را اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **افزودن و حذف بخش Zoom خلاصه**

تمام بخش‌های یک فریم Zoom خلاصه توسط اشیای [ISummaryZoomFrameSection](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomsection) نمایش داده می‌شوند که در شیء [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomsectioncollection) ذخیره می‌شوند. می‌توانید بخش Zoom خلاصه را از طریق اینترفیس [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/isummaryzoomsectioncollection) به این شکل اضافه یا حذف کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده بسازید.
3. فریم Zoom خلاصه را به اسلید اول اضافه کنید.
4. اسلاید و بخش جدیدی به ارائه اضافه کنید.
5. بخش ایجاد شده را به فریم Zoom خلاصه اضافه کنید.
6. اولین بخش را از فریم Zoom خلاصه حذف کنید.
7. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه بخش‌ها را در فریم Zoom خلاصه اضافه و حذف کنید:

``` csharp 
using (Presentation pres = new Presentation())
{
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 1", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 2", slide);

    // یک شیء SummaryZoomFrame را اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // یک بخش به Summary Zoom اضافه می‌کند
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // بخشی را از Summary Zoom حذف می‌کند
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **قالب‌بندی بخش‌های Zoom خلاصه**

برای ایجاد اشیای بخش Zoom خلاصه پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید به یک بخش Zoom خلاصه اعمال کنید. 

می‌توانید قالب‌بندی یک بخش Zoom خلاصه در فریم Zoom خلاصه را به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده بسازید.
3. فریم Zoom خلاصه را به اسلاید اول اضافه کنید.
4. یک شیء بخش Zoom خلاصه را از `ISummaryZoomSectionCollection` برای اولین شیء دریافت کنید.
5. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage) با افزودن تصویر به مجموعه images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا فریم را پر کند.
6. تصویر سفارشی را برای شیء فریم Zoom بخش ایجاد شده تنظیم کنید.
7. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
8. قالب خط فریم Zoom دوم را تغییر دهید.
9. مدت زمان انتقال را تغییر دهید.
10. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه قالب‌بندی بخش Zoom خلاصه را تغییر دهید:

``` csharp 
using (Presentation pres = new Presentation())
{
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 1", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.Sections.AddSection("Section 2", slide);

    // یک شیء SummaryZoomFrame را اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // اولین شیء SummaryZoomSection را دریافت می‌کند
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // قالب‌بندی برای شیء SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // ارائه را ذخیره می‌کند
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

**آیا می‌توانم رفتار بازگشت به اسلاید «والد» پس از نمایش هدف را کنترل کنم؟**

بله. فریم [Zoom](https://reference.aspose.com/slides/fa/net/aspose.slides/zoomframe/) یا [section](https://reference.aspose.com/slides/fa/net/aspose.slides/sectionzoomframe/) دارای ویژگی `ReturnToParent` است که وقتی فعال باشد، بینندگان را پس از بازدید از محتوا هدف به اسلاید مبدأ بازمی‌گرداند.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال Zoom را تنظیم کنم؟**

بله. Zoom از تنظیم `TransitionDuration` پشتیبانی می‌کند تا بتوانید مدت زمان انیمیشن پرش را کنترل کنید.

**آیا محدودیتی برای تعداد اشیای Zoom در یک ارائه وجود دارد؟**

محدودیتی سخت در API مستند نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد دستگاه مشاهده‌کننده بستگی دارد. می‌توانید فریم‌های Zoom زیادی اضافه کنید، اما به حجم فایل و زمان رندرینگ توجه داشته باشید.