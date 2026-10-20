---
title: ایجاد نمودارهای اکسل و جاسازی آن‌ها در ارائه‌ها به‌عنوان اشیاء OLE
type: docs
weight: 50
url: /fa/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- نمودار اکسل
- جاسازی نمودار
- شی OLE
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یک نمودار اکسل را با Aspose.Cells for .NET ایجاد کنید و کتاب‌کار را در یک ارائه PowerPoint با Aspose.Slides جاسازی کنید، به‌همراه پیش‌نمایش نمودار."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه می‌توانید یک نمودار ستونی Excel را با Aspose.Cells for .NET ایجاد کنید و کتاب‌کار آن را در یک ارائه PowerPoint با Aspose.Slides for .NET جاسازی کنید. کتاب‌کار جاسازی شده شامل داده‌های منبع و نمودار است. یک پیش‌نمایش PNG جداگانه، نمودار را بر روی اسلاید قبل از فعال‌سازی شی OLE نمایش می‌دهد.

نتیجه یک شی Excel جاسازی شده است، نه یک نمودار بومی PowerPoint. ویرایش کتاب‌کار از طریق OLE به یک برنامه دسکتاپی که از فعال‌سازی OLE پشتیبانی کند و نصب سازگار Excel داشته باشد نیاز دارد.

## **پیش‌نیازها**

در پروژه C# خود مراجع Aspose.Cells for .NET و Aspose.Slides for .NET را اضافه کنید. این مثال از عبارت‌های سطح‑بالا استفاده می‌کند و به C# 9 یا بالاتر نیاز دارد. برای تولید ارائه با این کتابخانه‌ها نصب Microsoft Office الزامی نیست.

فایل ورودی نیاز نیست: مثال داده‌ها و نمودار را در حافظه ایجاد می‌کند، سپس `OutputChart.pptx` را در پوشه کاری فعلی می‌نویسد. هنگام اجرا خارج از حالت ارزیابی، برای هر دو محصول لایسنس‌های مربوطه را اعمال کنید.

## **نحوه کار جاسازی**

1. یک کتاب‌کار با یک ورق داده و یک ورق نمودار ایجاد کنید.  
1. ورق نمودار را فعال کنید تا کتاب‌کار هنگام باز شدن بر روی نمودار نمایش داده شود.  
1. بازه نمایش OLE کتاب‌کار را تنظیم کنید و نمودار را به PNG رندر کنید.  
1. کتاب‌کار را به صورت XLSX در حافظه ذخیره کنید و بایت‌های آن را در یک اسلاید جاسازی کنید.  
1. PNG را به‌عنوان پیش‌نمایش شی OLE اختصاص دهید و ارائه را به صورت PPTX ذخیره کنید.

بازه نمایش کتاب‌کار و چارچوب اسلاید نقش‌های متفاوتی دارند. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) مقادیر شروع/پایان ردیف و ستون را به‌صورت صفر‑محور می‌گیرد. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) به‌جای آن ردیف بالایی، ستون چپ، ردیف پایینی و ستون راست را می‌گیرد. مثال از شاخص ردیف 55 و شاخص ستون 25 به‌عنوان مرزهای پایین‑راست استفاده می‌کند؛ این مقادیر گزینه‌های چیدمان هستند، نه تعداد ردیف‌ها یا ستون‌های داده.

چارچوب اسلاید بر اساس پوینت‌ها است. مثال آن را درون اسلاید قرار می‌دهد و در مرکز می‌گیرد در حالی که نسبت تصویر PNG را حفظ می‌کند، نه کشیدن پیش‌نمایش برای پر کردن کل اسلاید.

## **ایجاد و جاسازی نمودار**

مثال کامل زیر `DataSheet` را با چهار ردیف و پنج ستون مقدار پر می‌کند. هر ردیف تبدیل به یک سری نمودار می‌شود. قبل از ذخیره کتاب‌کار، `ChartSheet` به‌عنوان ورق فعال انتخاب می‌شود.

کتاب‌کار به‌صورت صریح به‌صورت XLSX ذخیره می‌شود، که با پسوند `xlsx` پاس داده شده به [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) مطابقت دارد. PNG به‌صورت مستقیم از جریان خود بارگذاری می‌شود بدون تبدیل به بیت‌مپ میانی. اختصاص آن از طریق [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) جایگزین نگهدارنده پیش‌فرض OLE می‌شود.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// پیش‌نمایش نمودار را رندر کنید و کتاب‌کار قابل ویرایش را به‌صورت جداگانه سریالیزه کنید.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **نتیجهٔ مورد انتظار**

`OutputChart.pptx` شامل یک اسلاید با کتاب‌کار Excel جاسازی شده و پیش‌نمایش نمودار است. کتاب‌کار شامل داده‌های اصلی و یک نمودار ستونی با چهار سری می‌باشد. پیش‌نمایش در مرکز اسلاید قرار می‌گیرد و نسبت‌های خود را نگه می‌دارد.

![نمودار ستونی اکسل نمایش داده شده به عنوان پیش‌نمایش یک کتاب کار جاسازی شده](excel-chart-ole-preview.png)

در یک محیط PowerPoint دسکتاپی سازگار که Excel در دسترس باشد، برای فعال‌سازی و ویرایش کتاب‌کار جاسازی شده، شی را دو بار کلیک کنید. فعال‌سازی و ویرایش به پشتیبانی OLE برنامه میزبان و تنظیمات امنیتی آن وابسته است.

## **سوالات متداول**

**چرا تصویر پیش‌نمایش لازم است؟**

کتاب‌کار جاسازی شده و پیش‌نمایش اسلاید آن محتواهای جداگانه‌ای هستند. برای اینکه اسلاید نمودار را به جای نگهدارنده پیش‌فرض «EMBEDDED OLE OBJECT» نشان دهد، یک تصویر نمودار فراهم کنید. ببینید [Object Preview Issue when Adding OleObjectFrame](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/).

**آیا پیش‌نمایش به‌صورت خودکار به‌روزرسانی می‌شود وقتی کتاب‌کار را در کد تغییر می‌دهم؟**

پیش‌نمایش را به‌عنوان یک снимه ثابت در نظر بگیرید. هنگام به‌روزرسانی داده‌های کتاب‌کار به‌صورت برنامه‌نویسی، تصویر نمودار را مجدداً تولید کنید و هم پیش‌نمایش و هم داده‌های کتاب‌کار جاسازی شده را جایگزین کنید.

**آیا می‌توانم به جای XLSX از XLS استفاده کنم؟**

بله. کتاب‌کار را در قالب XLS ذخیره کنید و از پسوند `xls` به‌عنوان پسوند داده‌های جاسازی شده استفاده کنید. پسوند باید با قالب واقعی کتاب‌کار مطابقت داشته باشد؛ تغییر تنها پسوند داده‌ها را تبدیل نمی‌کند.

**چرا ممکن است پس از فعال‌سازی اندازهٔ شی تغییر کند؟**

برنامه میزبان می‌تواند ارائهٔ شی OLE را هنگام فعال‌سازی کتاب‌کار به‌روز کند. بازه نمایش OLE کتاب‌کار و ابعاد چارچوب اسلاید هر دو مهم هستند. ببینید [Working Solution for Chart Resizing in PPTX](/slides/fa/net/working-solution-for-chart-resizing-in-pptx/).

## **بخش‌های مرتبط**

- [راه‌حل کارآمد برای تغییر اندازه نمودار در PPTX](/slides/fa/net/working-solution-for-chart-resizing-in-pptx/)
- [مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/)
- [به‌روزرسانی خودکار اشیاء OLE با استفاده از افزودنی PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)