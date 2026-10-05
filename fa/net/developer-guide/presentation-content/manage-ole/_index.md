---
title: "مدیریت اشیای OLE در ارائه‌ها در .NET"
linktitle: "مدیریت OLE"
type: docs
weight: 40
url: /fa/net/manage-ole/
keywords:
- "شیء OLE"
- "پیوند و جاسازی شیء"
- "افزودن OLE"
- "جاسازی OLE"
- "افزودن شیء"
- "جاسازی شیء"
- "افزودن فایل"
- "جاسازی فایل"
- "شیء پیوندی"
- "فایل پیوندی"
- "تغییر OLE"
- "آیکون OLE"
- "عنوان OLE"
- "استخراج OLE"
- "استخراج شیء"
- "استخراج فایل"
- "PowerPoint"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "بهینه‌سازی مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET. جاسازی، به‌روزرسانی و استخراج محتویات OLE به‌صورت یکپارچه."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) یک فناوری مایکروسافتی است که امکان قرار دادن داده‌ها و اشیاء ایجاد‌شده در یک برنامه در برنامه‌ای دیگر را از طریق لینک یا جاسازی فراهم می‌کند. 
{{% /alert %}}

به یک نمودار در MS Excel فکر کنید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به‌عنوان یک شیء OLE در نظر گرفته می‌شود. 

- یک شیء OLE ممکن است به‌صورت یک آیکون ظاهر شود. در این حالت، وقتی بر روی آیکون دوبار کلیک می‌کنید، نمودار در برنامه مرتبط خود (Excel) باز می‌شود، یا از شما خواسته می‌شود تا برنامه‌ای برای باز یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE ممکن است محتویات واقعی خود را نمایش دهد، مانند محتویات یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را درون PowerPoint ویرایش کنید. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) allows you to insert OLE Objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به‌عنوان یک فریم شیء OLE در یک اسلاید جاسازی کنید با استفاده از Aspose.Slides for .NET، می‌توانید به این روش انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. فایل Excel را به‌عنوان یک آرایه باییتی بخوانید.  
4. فریم [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) را به اسلاید اضافه کنید که شامل آرایه باییتی و سایر اطلاعات مربوط به شیء OLE باشد.  
5. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.  

در مثال زیر، یک نمودار از فایل Excel را به‌عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) به اسلاید اضافه کردیم با استفاده از Aspose.Slides for .NET.  
**توجه** داشته باشید که سازنده‌ی [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) یک پسوند شیء قابل جاسازی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد تا نوع فایل را به‌درستی تفسیر کند و برنامه مناسب برای باز کردن این شیء OLE را انتخاب نماید.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // آماده‌سازی داده‌ها برای شیء OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // افزودن فریم شیء OLE به اسلاید.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **افزودن فریم‌های شیء OLE پیوندی**

Aspose.Slides for .NET به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) را بدون جاسازی داده اضافه کنید، بلکه تنها با یک لینک به فایل.

این کد C# نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) را با یک فایل Excel پیوندی به اسلاید اضافه کنید:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // اضافه کردن فریم شیء OLE با فایل Excel پیوندی.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به‌راحتی آن را پیدا یا دسترسی پیدا کنید به این روش:

1. یک ارائه شامل شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
   در مثال ما، از PPTX که قبلاً ساخته بودیم و فقط یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) *cast* کردیم. این همان فریم شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (شیء نمودار Excel جاسازی‌شده در اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شود.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت اولین شکل به‌عنوان فریم شیء OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // دریافت داده‌های فایل جاسازی‌شده.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // دریافت پسوند فایل جاسازی‌شده.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های فریم شیء OLE پیوندی دسترسی پیدا کنید.

این کد C# نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را به دست آورید:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت اولین شکل به‌عنوان فریم شیء OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // بررسی اینکه آیا شیء OLE پیوندی است یا خیر.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // چاپ مسیر کامل به فایل پیوندی.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // چاپ مسیر نسبی به فایل پیوندی در صورت وجود.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را شامل شوند.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}
در این بخش، مثال کد زیر از [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/) استفاده می‌کند.
{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به‌راحتی به آن شیء دسترسی داشته باشید و داده‌های آن را به این روش تغییر دهید:

1. یک ارائه شامل شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. به شکل [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
   در مثال ما، از PPTX که قبلاً ساخته بودیم و فقط یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe) *cast* کردیم. این همان فریم شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. شیء `Worksheet` موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روزرسانی‌شده را در یک جریان (stream) ذخیره کنید.  
8. داده‌های شیء OLE را از جریان تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (شیء نمودار Excel جاسازی‌شده در اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شوند.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت اولین شکل به‌عنوان فریم شیء OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // خواندن داده‌های شیء OLE به‌عنوان یک شیء Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // تعدیل داده‌های Workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // تغییر داده‌های شیء فریم OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for .NET به شما امکان می‌دهد انواع دیگر فایل‌ها را به اسلایدها جاسازی کنید. برای مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر بر روی شیء وارد شده دوبار کلیک می‌کند، به‌ طور خودکار در برنامه مرتبط باز می‌شود یا از کاربر خواسته می‌شود برنامه مناسب برای باز کردن آن را انتخاب کند.  

این کد C# نشان می‌دهد چگونه HTML و ZIP را به یک اسلاید جاسازی کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

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

هنگام کار با ارائه‌ها ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for .NET به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید و بتوانید داده‌های فریم OLE یا پسوند آن را به‌روز کنید.  

این کد C# نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده به `zip` تنظیم شود:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // تغییر نوع فایل به ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تنظیم تصاویر آیکون و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی متشکل از تصویر آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر بخواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با Aspose.Slides for .NET تنظیم کنید.  

این کد C# نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // اضافه کردن یک تصویر به منابع ارائه.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // تنظیم عنوان و تصویر برای پیش‌نمایش OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **جلوگیری از تغییر اندازه و جابجایی فریم شیء OLE**

پس از افزودن یک شیء OLE پیوندی به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیغامی مبنی بر به‌روزرسانی لینک‌ها مشاهده کنید. کلیک بر دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌های شیء OLE پیوندی را به‌روز می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، ویژگی `UpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) را روی `false` تنظیم کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // حفظ اندازه و موقعیت فریم شیء OLE هنگام به‌روزرسانی لینک توسط PowerPoint.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for .NET به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها را به‌عنوان اشیاء OLE این‌گونه استخراج کنید:
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ایجاد کنید که شامل اشیاء OLE موردنظر برای استخراج باشد.  
2. بر روی تمام اشکال در ارائه حلقه بزنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های OLE استخراج کنید و روی دیسک بنویسید.  

این کد C# نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

```c#
using Aspose.Slides;

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

## **سوالات متداول**

**آیا محتویات OLE هنگام استخراج اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه در اسلاید قابل مشاهده است رندر می‌شود — آیکون/تصویر جایگزین (پیش‌نمایش). محتویات «زنده» OLE در زمان رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر موردنظر در PDF استخراج‌شده حفظ شود.

برای نگه داشتن فایل جاسازی‌شده به‌عنوان پیوست PDF، ویژگی [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) را روی `true` تنظیم کنید. این گزینه به‌ طور پیش‌فرض غیرفعال است. برای مثال و راهنمایی درباره بررسی پیوست، به [Preserve Embedded OLE Files as PDF Attachments](/slides/fa/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) مراجعه کنید.

**چگونه می‌توانم یک شیء OLE را روی اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides [قفل‌های سطح شکل](/slides/fa/net/applying-protection-to-presentation/) را فراهم می‌کند. این رمزگذاری نیست، اما به‌طور مؤثر از ویرایش‌ها و جابه‌جایی‌های ناخواسته جلوگیری می‌کند.

**چرا یک شیء Excel پیوندی «پرش» می‌کند یا هنگام باز کردن ارائه اندازه‌اش تغییر می‌کند؟**

PowerPoint ممکن است پیش‌نمایش OLE پیوندی را تازه کند. برای حفظ ظاهر ثابت، روش‌های [Working Solution for Worksheet Resizing](/slides/fa/net/working-solution-for-worksheet-resizing/) را دنبال کنید — یا فریم را با بازه تطبیق دهید، یا بازه را به فریم ثابت مقیاس‌بندی کنید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE پیوندی در فرمت PPTX حفظ می‌شوند؟**

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی‌تر PPT یافت می‌شوند. برای قابلیت حمل، مسیرهای مطلق قابل اطمینان/URIهای قابل دسترسی یا جاسازی را ترجیح دهید.