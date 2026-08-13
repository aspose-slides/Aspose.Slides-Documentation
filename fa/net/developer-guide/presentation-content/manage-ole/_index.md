---
title: مدیریت اشیای OLE در ارائه‌ها در .NET
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/net/manage-ole/
keywords:
- شی OLE
- پیونددهی و جاسازی شی
- اضافه کردن OLE
- جاسازی OLE
- اضافه کردن شی
- جاسازی شی
- اضافه کردن فایل
- جاسازی فایل
- شی مرتبط
- فایل مرتبط
- تغییر OLE
- نماد OLE
- عنوان OLE
- استخراج OLE
- استخراج شی
- استخراج فایل
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای .NET. جاسازی، به‌روزرسانی و صادرات محتوای OLE به‌صورت یکپارچه."
---
## **مقدمه**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیایی که در یک برنامه ایجاد شده‌اند، از طریق لینک یا جاسازی در برنامهٔ دیگری قرار گیرند. 

{{% /alert %}} 

در نظر بگیرید یک نمودار در MS Excel ایجاد شده است. سپس آن نمودار در داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شی OLE در نظر گرفته می‌شود. 

- یک شی OLE ممکن است به شکل یک نماد ظاهر شود. در این حالت، زمانی که بر روی نماد دوبار کلیک می‌کنید، نمودار در برنامهٔ مربوطه (Excel) باز می‌شود، یا از شما خواسته می‌شود تا برنامه‌ای برای باز یا ویرایش شی انتخاب کنید. 
- یک شی OLE ممکن است محتوای واقعی خود را نمایش دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را درون PowerPoint اصلاح کنید. 

[Aspose.Slides for .NET](https://products.aspose.com/slides/fa/net/) به شما امکان می‌دهد تا اشیای OLE را به اسلایدها به عنوان فریم‌های شی OLE ( [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) ) وارد کنید.

## **افزودن فریم‌های شی OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به عنوان یک فریم شی OLE در یک اسلاید جاسازی کنید با استفاده از Aspose.Slides for .NET، می‌توانید به این شکل انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. ارجاع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. فایل Excel را به‌عنوان یک آرایه بایت بخوانید.
4. [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) را به اسلاید اضافه کنید و آرایه بایت و سایر اطلاعات مربوط به شی OLE را در آن قرار دهید.
5. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

در مثال زیر، یک نمودار از یک فایل Excel را به‌عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) به یک اسلاید اضافه کردیم با استفاده از Aspose.Slides for .NET.  
**توجه** داشته باشید که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/net/aspose.slides.dom.ole/oleembeddeddatainfo/) یک پسوند شی قابل جاسازی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد تا نوع فایل را به‌درستی تفسیر کرده و برنامه مناسب برای باز کردن این شی OLE را انتخاب کند.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // آماده‌سازی داده‌ها برای شی OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // افزودن فریم شی OLE به اسلاید.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **افزودن فریم‌های شی OLE مرتبط**

Aspose.Slides for .NET به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) را بدون جاسازی داده، تنها با یک لینک به فایل اضافه کنید.

این کد C# نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) با یک فایل Excel مرتبط به یک اسلاید اضافه کنید:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // افزودن فریم شی OLE با یک فایل Excel مرتبط.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **دسترسی به فریم‌های شی OLE**

اگر یک شی OLE از پیش در یک اسلاید جاسازی شده باشد، می‌توانید به سادگی آن را پیدا یا دسترسی پیدا کنید به این روش:

1. یک ارائه شامل شی OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) بارگیری کنید.
2. ارجاع اسلاید را با استفاده از ایندکس آن دریافت کنید.
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید.
   در مثال ما، از PPTX که قبلاً ایجاد شده بود و فقط یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شی را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe) *تبدیل* (cast) کردیم. این همان فریم شی OLE موردنظر برای دسترسی بود.
4. پس از دسترسی به فریم شی OLE، می‌توانید هر عملیاتی را بر روی آن انجام دهید.

در مثال زیر، یک فریم شی OLE (یک شی نمودار Excel که در اسلاید جاسازی شده) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت اولین شکل به عنوان فریم شی OLE.
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

### **دسترسی به خصوصیات فریم شی OLE مرتبط**

Aspose.Slides به شما امکان می‌دهد به خصوصیات فریم شی OLE مرتبط دسترسی پیدا کنید.

این کد C# نشان می‌دهد چگونه بررسی کنید آیا یک شی OLE مرتبط است و سپس مسیر فایل مرتبط را به دست آورید:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت اولین شکل به عنوان فریم شی OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // بررسی اینکه آیا شی OLE مرتبط است.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // نمایش مسیر کامل فایل مرتبط.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // نمایش مسیر نسبی فایل مرتبط در صورت موجود بودن.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **تغییر دادهٔ شی OLE**

{{% alert color="info" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells for .NET](/cells/net/) استفاده می‌کند.

{{% /alert %}}

اگر یک شی OLE از پیش در یک اسلاید جاسازی شده باشد، می‌توانید به سادگی به آن شی دسترسی پیدا کنید و داده‌های آن را به این شکل تغییر دهید:

1. یک ارائه شامل شی OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) بارگیری کنید.
2. ارجاع اسلاید را از طریق ایندکس آن دریافت کنید.
3. به شکل [OLEObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید.
   در مثال ما، از PPTX که قبلاً ایجاد شده بود و یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شی را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe) *تبدیل* (cast) کردیم. این همان فریم شی OLE موردنظر برای دسترسی بود.
4. پس از دسترسی به فریم شی OLE، می‌توانید هر عملیاتی را بر روی آن انجام دهید.
5. یک شی `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.
6. `Worksheet` موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.
7. `Workbook` به‌روز شده را در یک استریم ذخیره کنید.
8. داده‌های شی OLE را از استریم تغییر دهید.

در مثال زیر، یک فریم شی OLE (یک شی نمودار Excel که در اسلاید جاسازی شده) دسترسی پیدا می‌کند و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت اولین شکل به عنوان فریم شی OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // خواندن داده‌های شی OLE به‌عنوان یک شی Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // تغییر داده‌های Workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // تغییر داده‌های شی فریم OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **جاسازی انواع فایل دیگر در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for .NET به شما امکان می‌دهد انواع دیگر فایل‌ها را به اسلایدها جاسازی کنید. به عنوان مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان شیء وارد کنید. وقتی کاربر روی شیء وارد‌شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مربوطه باز می‌شود یا از کاربر خواسته می‌شود برنامهٔ مناسب برای باز کردن آن را انتخاب کند.

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

## **تنظیم نوع فایل برای اشیای جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیای OLE قدیمی را با جدید جایگزین کنید یا یک شی OLE غیرپشتیبانی‌شده را با شی پشتیبانی‌شده عوض کنید. Aspose.Slides for .NET به شما امکان می‌دهد نوع فایل برای یک شی جاسازی‌شده را تنظیم کنید، که به‌روزرسانی داده‌های فریم OLE یا پسوند آن را ممکن می‌سازد.

این کد C# نشان می‌دهد چگونه نوع فایل برای یک شی OLE جاسازی‌شده را به `zip` تنظیم کنید:

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

## **تنظیم تصویر نماد و عنوان برای اشیای جاسازی‌شده**

پس از جاسازی یک شی OLE، پیش‌نمایشی که شامل یک تصویر نماد است به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش چیزی است که کاربران قبل از دسترسی یا باز کردن شی OLE می‌بینند. اگر می‌خواهید از یک تصویر و متن خاص به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر نماد و عنوان را با استفاده از Aspose.Slides for .NET تنظیم کنید.

این کد C# نشان می‌دهد چگونه تصویر نماد و عنوان برای یک شی جاسازی‌شده تنظیم کنید: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **جلوگیری از تغییر اندازه و موقعیت فریم شی OLE**

پس از افزودن یک شی OLE مرتبط به یک اسلاید ارائه، هنگامی که ارائه را در PowerPoint باز می‌کنید، ممکن است پیغامی ببینید که از شما می‌خواهد لینک‌ها را به‌روزرسانی کنید. کلیک بر دکمهٔ «Update Links» ممکن است اندازه و موقعیت فریم شی OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شی OLE مرتبط به‌روز کرده و پیش‌نمایش شی را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی دادهٔ شی، ویژگی `UpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ioleobjectframe/) را به `false` تنظیم کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // حفظ اندازه و موقعیت فریم شی OLE هنگام به‌روزرسانی لینک توسط PowerPoint.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for .NET به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها را به‌عنوان اشیای OLE به این شکل استخراج کنید:
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که شامل اشیای OLEیی که می‌خواهید استخراج کنید، ایجاد کنید.
2. بر تمام شکل‌ها در ارائه حلقه بزنید و به شکل‌های [OLEObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) دسترسی پیدا کنید.
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های OLE استخراج کنید و روی دیسک بنویسید.

این کد C# نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیای OLE استخراج کنید:

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

### آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟

چیزی که در اسلاید مشاهده می‌شود رندر می‌شود — نماد/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در زمان رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی تضمین شود.

### چگونه می‌توانم یک شی OLE را روی اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟

قفل کردن شکل: Aspose.Slides قابلیت [قفل‌های سطح شکل](/slides/fa/net/applying-protection-to-presentation/) را فراهم می‌کند. این یک رمزگذاری نیست، اما به‌طور مؤثری از ویرایش یا جابجایی ناخواسته جلوگیری می‌کند.

### چرا یک شی Excel مرتبط هنگام باز کردن ارائه «پرش» می‌کند یا اندازه‌اش تغییر می‌یابد؟

PowerPoint ممکن است پیش‌نمایش OLE مرتبط را تازه کند. برای داشتن ظاهر ثابت، راهکارهای موجود در [راه‌حل کاری برای تغییر اندازه برگه](/slides/fa/net/working-solution-for-worksheet-resizing/) را دنبال کنید — یا فریم را به محدوده متناسب کنید، یا محدوده را به یک فریم ثابت مقیاس‌بندی کنید و تصویر جایگزین مناسب تنظیم کنید.

### آیا مسیرهای نسبی برای اشیای OLE مرتبط در فرمت PPTX حفظ می‌شوند؟

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابلیت حمل، بهتر است از مسیرهای مطلق قابل اعتماد/URIهای قابل دسترسی یا جاسازی استفاده کنید.