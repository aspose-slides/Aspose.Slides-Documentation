---
title: مدیریت اشیاء OLE در ارائه‌ها در .NET
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/net/manage-ole/
keywords:
- شیء OLE
- پیونددهی و جاسازی شیء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء لینک‌شده
- فایل لینک‌شده
- تغییر OLE
- نماد OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت بهینهٔ اشیاء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET. جاسازی، به‌روزرسانی و صادر کردن محتوای OLE به راحتی."
---
## **مقدمه**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند از طریق لینک یا جای‌گذاری در برنامه‌ای دیگر قرار گیرند. 

{{% /alert %}} 

یک نمودار ایجاد شده در MS Excel را در نظر بگیرید. سپس این نمودار در یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE محسوب می‌شود. 

- یک شیء OLE می‌تواند به صورت یک نماد نمایش داده شود. در این حالت، هنگام دوبار کلیک بر روی نماد، نمودار در برنامه مرتبط خود (Excel) باز می‌شود، یا از شما خواسته می‌شود برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE می‌تواند محتوای واقعی خود، مانند محتوای یک نمودار، را نمایش دهد. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را در PowerPoint اصلاح کنید.

[Aspose.Slides for .NET](https://products.aspose.com/slides/fa/net/) به شما اجازه می‌دهد تا OLE Objects را به اسلایدها به عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe)) وارد کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به عنوان یک فریم شیء OLE در یک اسلاید با استفاده از Aspose.Slides for .NET جاسازی کنید؛ می‌توانید به این روش انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) را ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. فایل Excel را به عنوان آرایه‌ای از بایت‌ها بخوانید.
4. فریم [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) را به اسلاید اضافه کنید که شامل آرایه بایت و سایر اطلاعات مربوط به شیء OLE باشد.
5. ارائهٔ تغییر یافته را به عنوان فایل PPTX ذخیره کنید.

در مثال زیر، ما یک نمودار از یک فایل Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) به اسلاید اضافه کردیم با استفاده از Aspose.Slides for .NET.  **توجه** داشته باشید که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/net/aspose.slides.dom.ole/oleembeddeddatainfo/) یک پسوند شیء قابل جاسازی را به عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint اجازه می‌دهد نوع فایل را به درستی تفسیر کرده و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // داده‌های مورد نیاز برای شیء OLE را آماده کنید.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // قاب شیء OLE را به اسلاید اضافه کنید.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **افزودن فریم‌های شیء OLE لینک‌شده**

Aspose.Slides for .NET به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) بدون جاسازی داده، تنها با یک لینک به فایل اضافه کنید.

این کد C# نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) با فایل Excel لینک‌شده به یک اسلاید اضافه کنید:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک فریم شیء OLE با فایل Excel لینک‌شده اضافه کنید.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را به این روش پیدا یا دسترسی پیدا کنید:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) بارگیری کنید.
2. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید. در مثال ما، از PPTX ایجاد شده قبلی که فقط یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شیء را به عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe) *cast* کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.

در مثال زیر، یک فریم شیء OLE (شیء نمودار Excel جاسازی‌شده در یک اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // اولین شکل را به عنوان فریم شیء OLE دریافت کنید.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // داده‌های فایل جاسازی‌شده را دریافت کنید.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // پسوند فایل جاسازی‌شده را دریافت کنید.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE لینک‌شده**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های فریم شیء OLE لینک‌شده دسترسی پیدا کنید.

این کد C# نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک‌شده است و سپس مسیر فایل لینک‌شده را به دست آورید:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // اولین شکل را به‌عنوان فریم شیء OLE دریافت کنید.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // بررسی کنید که آیا شیء OLE لینک‌دار است.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // مسیر کامل فایل لینک‌شده را چاپ کنید.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // اگر موجود باشد، مسیر نسبی فایل لینک‌شده را چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **تغییر داده‌های شیء OLE**

{{% alert color="primary" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells for .NET](/cells/net/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی به آن دسترسی پیدا کنید و داده‌های آن را به این شکل اصلاح کنید:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) بارگیری کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. به شکل [OLEObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید. در مثال ما، از PPTX ایجاد شده قبلی که یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شیء را به عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe) *cast* کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.
6. `Worksheet` موردنظر را دسترسی کنید و داده‌ها را اصلاح کنید.
7. `Workbook` به‌روزرسانی‌شده را در یک جریان (stream) ذخیره کنید.
8. داده‌های شیء OLE را از جریان تغییر دهید.

در مثال زیر، یک فریم شیء OLE (شیء نمودار Excel جاسازی‌شده در یک اسلاید) دسترسی پیدا می‌کند و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // اولین شکل را به‌عنوان فریم شیء OLE دریافت کنید.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // داده‌های شیء OLE را به عنوان یک شیء Workbook بخوانید.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // داده‌های Workbook را اصلاح کنید.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // داده‌های شیء فریم OLE را تغییر دهید.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides for .NET به شما اجازه می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. به عنوان مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد شده دوبار کلیک می‌کند، به‌طور خودکار در برنامه مرتبط باز می‌شود یا از کاربر خواسته می‌شود برنامه مناسب برای باز کردن آن را انتخاب کند.

این کد C# نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید جاسازی کنید:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تنظیم انواع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض نمایید. Aspose.Slides for .NET به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید و بدین وسیله داده‌های فریم OLE یا پسوند آن را به‌روزرسانی کنید.

این کد C# نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // نوع فایل را به ZIP تغییر دهید.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تنظیم تصاویر نماد و عناوین برای اشیاء جاسازی شدی**

پس از جاسازی یک شیء OLE، پیش‌نمایشی شامل تصویر نماد به طور خودکار اضافه می‌شود. این پیش‌نمایش چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر نماد و عنوان را با استفاده از Aspose.Slides for .NET تنظیم کنید.

این کد C# نشان می‌دهد چگونه تصویر نماد و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // یک تصویر به منابع ارائه اضافه کنید.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // عنوان و تصویر را برای پیش‌نمایش OLE تنظیم کنید.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از اضافه کردن یک شیء OLE لینک‌شده به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیغامی مبنی بر به‌روزرسانی لینک‌ها مشاهده کنید. کلیک بر روی دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE لینک‌شده به‌روز کرده و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، ویژگی `UpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) را به `false` تنظیم کنید:

```cs
oleFrame.UpdateAutomatic = false;
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for .NET به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها به عنوان اشیاء OLE را به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید که شامل اشیاء OLE مورد نظر برای استخراج باشد.
2. در تمام اشکال موجود در ارائه حلقه بزنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید.
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های شیء OLE دسترسی پیدا کنید و آن‌ها را روی دیسک بنویسید.

این کد C# نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به عنوان اشیاء OLE استخراج کنید:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **پرسش‌های متداول**

**آیا محتوای OLE هنگام صادر کردن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه بر روی اسلاید قابل مشاهده است رندر می‌شود — آیون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش دلخواه خود را تنظیم کنید تا ظاهر مطلوب در PDF صادر شده تضمین شود.

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابه‌جا/ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides [قفل‌های سطح شکل](/slides/fa/net/applying-protection-to-presentation/) را فراهم می‌کند. این یک رمزنگاری نیست، اما به‌طور مؤثر از ویرایش و جابه‌جایی ناخواسته جلوگیری می‌کند.

**چرا یک شیء Excel لینک‌شده هنگام باز کردن ارائه «پرش» می‌کند یا اندازه‌اش تغییر می‌کند؟**

PowerPoint ممکن است پیش‌نمایش OLE لینک‌شده را تازه کند. برای داشتن ظاهر ثابت، از روش‌های [راه‌حل کارآمد برای تغییر اندازه برگه کاری](/slides/fa/net/working-solution-for-worksheet-resizing/) پیروی کنید — یا فریم را به محدوده تنظیم کنید، یا محدوده را به فریم ثابت مقیاس‌دهی کنید و تصویر جایگزین مناسبی تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE لینک‌شده در قالب PPTX حفظ می‌شوند؟**

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابل حمل بودن، مسیرهای مطمئن مطلق/URIهای قابل دسترس یا جاسازی را ترجیح دهید.