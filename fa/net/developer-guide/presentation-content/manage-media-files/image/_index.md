---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها در .NET
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/net/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت تصویر در پاورپوینت و OpenDocument را با Aspose.Slides برای .NET ساده‌سازی کنید، عملکرد را بهینه‌سازی کرده و جریان کاری خود را خودکار کنید."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و جالب‌تر می‌کنند. در مایکروسافت پاورپوینت می‌توانید تصاویر را از یک فایل، اینترنت یا دیگر مکان‌ها به اسلایدها اضافه کنید. به همین ترتیب، Aspose.Slides به شما اجازه می‌دهد تا با روش‌های مختلف، تصاویر را به اسلایدهای ارائه‌ی خود اضافه کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد امکان می‌دهد به‌سرعت از تصاویر ارائه‌ها را ایجاد کنند. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

اگر می‌خواهید یک تصویر را به‌عنوان شیء قاب اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد برای تغییر اندازه، افزودن افکت‌ها و غیره استفاده کنید—به [Picture Frame](https://docs.aspose.com/slides/fa/net/picture-frame/) مراجعه کنید. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

می‌توانید عملیات ورودی/خروجی مرتبط با تصاویر و ارائه‌های PowerPoint را برای تبدیل یک تصویر از یک فرمت به فرمت دیگر مدیریت کنید. این صفحات را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/); تبدیل [JPG به image](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/), تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/), تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides عملیات‌های کار با تصاویر را در این فرمت‌های محبوب پشتیبانی می‌کند: JPEG, PNG, BMP, GIF و سایرین. 

## **افزودن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر موجود در رایانه خود را به یک اسلاید در یک ارائه اضافه کنید. این کد نمونه در C# نشان می‌دهد چگونه یک تصویر را به یک اسلاید اضافه کنید:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید بر روی رایانه شما موجود نباشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

این کد نمونه نشان می‌دهد چگونه یک تصویر را از وب به یک اسلاید در C# اضافه کنید:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **افزودن تصاویر به اسلاید مسترها**

اسلاید مستر بالاترین اسلاید است که اطلاعات (تم، چیدمان و غیره) تمام اسلایدهای زیرمجموعه‌اش را ذخیره و کنترل می‌کند. بنابراین، هنگامی که یک تصویر را به اسلاید مستر اضافه می‌کنید، آن تصویر در هر اسلاید زیر آن مستر ظاهر می‌شود. 

این کد نمونه C# نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **افزودن تصاویر به‌عنوان پس‌زمینه اسلایدها**

ممکن است تصمیم بگیرید از یک تصویر به‌عنوان پس‌زمینه برای یک اسلاید خاص یا چند اسلاید استفاده کنید. در این صورت باید *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/fa/net/presentation-background/#setting-images-as-background-for-slides)* را ببینید.

## **افزودن SVG به ارائه‌ها**

می‌توانید هر تصویری را به یک ارائه اضافه یا درج کنید با استفاده از روش [AddPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/methods/addpictureframe) که متعلق به رابط [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection) است.

برای ایجاد یک شیء تصویر بر پایه تصویر SVG می‌توانید به این شکل عمل کنید:

1. ایجاد شیء SvgImage برای درج آن در ImageShapeCollection  
2. ایجاد شیء PPImage از ISvgImage  
3. ایجاد شیء PictureFrame با استفاده از رابط IPPImage  

این کد نمونه نشان می‌دهد چگونه مراحل بالا را پیاده‌سازی کنید تا یک تصویر SVG را به یک ارائه اضافه کنید:

``` csharp 
// مسیر به پوشه اسناد
string dataDir = @"D:\Documents\";

// نام فایل SVG منبع
string svgFileName = dataDir + "sample.svg";

// نام فایل خروجی ارائه
string outPptxPath = dataDir + "presentation.pptx";

// ایجاد ارائه جدید
using (var p = new Presentation())
{
    // خواندن محتوای فایل SVG
    string svgContent = File.ReadAllText(svgFileName);

    // ایجاد شیء SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // ایجاد شیء PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // ایجاد یک PictureFrame جدید
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // ذخیره ارائه در فرمت PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

تبدیل SVG به مجموعه‌ای از شکل‌ها در Aspose.Slides شبیه به عملکرد PowerPoint است که برای کار با تصاویر SVG استفاده می‌شود:

![PowerPoint Popup Menu](img_01_01.png)

این عملکرد توسط یکی از بارگذاری‌های روش [AddGroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides.ishapecollection/addgroupshape/methods/1) رابط [IShapeCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage) را به عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

این کد نمونه نشان می‌دهد چگونه از روش توصیف‌شده برای تبدیل یک فایل SVG به مجموعه‌ای از شکل‌ها استفاده کنید:

``` csharp 
// مسیر به پوشه اسناد
string dataDir = @"D:\Documents\";

// نام فایل SVG منبع
string svgFileName = dataDir + "sample.svg";

// نام فایل خروجی ارائه
string outPptxPath = dataDir + "presentation.pptx";

// ایجاد ارائه جدید
using (IPresentation presentation = new Presentation())
{
    // خواندن محتوای فایل SVG
    string svgContent = File.ReadAllText(svgFileName);

    // ایجاد شیء SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // دریافت اندازه اسلاید
    SizeF slideSize = presentation.SlideSize.Size;

    // تبدیل تصویر SVG به گروهی از شکل‌ها با مقیاس‌بندی به اندازه اسلاید
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // ذخیره ارائه در فرمت PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides for .NET به شما امکان می‌دهد تصاویر EMF را از شیت‌های اکسل تولید کنید و تصاویر را به‌صورت EMF در اسلایدها با Aspose.Cells اضافه کنید.  

این کد نمونه نشان می‌دهد چگونه کار موردنظر را انجام دهید:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //ذخیره کتاب کار به جریان
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **جایگزینی تصاویر در مجموعه‌ی تصویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه‌ی تصویر یک ارائه (از جمله آن‌هایی که توسط شکل‌های اسلاید استفاده می‌شوند) را جایگزین کنید. این بخش چندین رویکرد برای به‌روزرسانی تصاویر در مجموعه را نشان می‌دهد. API روش‌های ساده‌ای برای جایگزینی تصویر با استفاده از داده‌های بایت خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) یا تصویر دیگری که از قبل در مجموعه موجود است، فراهم می‌کند.

مراحل زیر را دنبال کنید:

1. باز کردن فایل ارائه که شامل تصاویر است با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/).  
2. بارگذاری یک تصویر جدید از یک فایل به یک آرایه بایت.  
3. جایگزینی تصویر هدف با تصویر جدید با استفاده از آرایه بایت.  
4. در رویکرد دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.  
5. در رویکرد سوم، تصویر هدف را با تصویری که از قبل در مجموعه‌ی تصویر ارائه وجود دارد، جایگزین کنید.  
6. نوشتن ارائه‌ی تغییر یافته به‌صورت فایل PPTX.

```cs
// نمونه‌سازی کلاس Presentation که نشان‌دهنده یک فایل ارائه است.
using Presentation presentation = new Presentation("sample.pptx");

// روش اول.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// روش دوم.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// روش سوم.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// ذخیره ارائه به یک فایل.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

با استفاده از مبدل رایگان Aspose [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به‌راحتی متن‌ها را انیمیشن دهید، GIFهایی از متن‌ها بسازید و غیره. 

{{% /alert %}}

## **سوالات متداول**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بستگی به این دارد که چگونه [picture](/slides/fa/net/picture-frame/) در اسلاید مقیاس‌بندی شده و چه فشرده‌سازی‌ای هنگام ذخیره اعمال می‌شود.

**بهترین روش برای جایگزینی یک لوگو یکسان در ده‌ها اسلاید به‌طور همزمان چیست؟**

لوگو را در اسلاید مستر یا یک چیدمان قرار دهید و آن را در مجموعه‌ی تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از این منبع استفاده می‌کنند، پراکندگی می‌یابد.

**آیا می‌توان یک SVG درج‌شده را به شکل‌های قابل ویرایش تبدیل کرد؟**

بله. می‌توانید یک SVG را به گروهی از شکل‌ها تبدیل کنید؛ پس از آن بخش‌های جداگانه با ویژگی‌های استاندارد شکل قابلیت ویرایش پیدا می‌کنند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌صورت همزمان تنظیم کرد؟**

*[Assign the image as the background](/slides/fa/net/presentation-background/)* را بر روی اسلاید مستر یا چیدمان مربوطه اعمال کنید—هر اسلایدی که از آن مستر/چیدمان استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توان از بزرگ شدن بیش از حد ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کرد؟**

به‌جای استفاده از تصاویر تکراری، یک منبع تصویر واحد را بازاستفاده کنید، رزولوشن‌های معقول را انتخاب کنید، فشرده‌سازی را هنگام ذخیره اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید که مناسب است.