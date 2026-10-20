---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 60
url: /fa/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار Excel
- شی OLE
- جاسازی نمودار
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تصحیح تغییر اندازه ناخواستهٔ نمودار در فایل PPTX هنگام استفاده از اشیای OLE Excel جاسازی‌شده با Aspose.Slides برای .NET. تنظیم ابعاد ثابت نمودار برای حفظ سازگاری اندازهٔ نمودار و فریم OLE."
---
## **پیش‌زمینه**

نمودارهای Excel که به عنوان اشیای OLE در ارائه‌های PowerPoint با استفاده از مؤلفه‌های Aspose جایگذاری می‌شوند، می‌توانند پس از اولین فعال‌سازی اندازه خود را تغییر دهند. این می‌تواند اختلاف قابل ملاحظه‌ای در ظاهر نمودار قبل و بعد از فعال‌سازی ایجاد کند. این مقاله توضیح می‌دهد چرا تغییر اندازه رخ می‌دهد و نشان می‌دهد چگونه می‌توان با تطبیق ابعاد ثابت نمودار با فریم OLE از آن جلوگیری کرد.

در [ایجاد نمودارهای Excel و جایگذاری آن‌ها به‌عنوان اشیای OLE در ارائه‌ها](/slides/fa/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، ما توضیح دادیم چگونه یک نمودار Excel با Aspose.Cells for .NET ایجاد و آن را در یک ارائه PowerPoint با استفاده از Aspose.Slides for .NET جایگذاری کنیم. برای رفع [مسئله پیش‌نمایش شی](/slides/fa/net/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به فریم شی OLE اختصاص دادیم. در ارائه خروجی، هنگامی که فریم شی OLE که تصویر نمودار را نشان می‌دهد را دوبار کلیک کنید، نمودار Excel فعال می‌شود. کاربران می‌توانند کتاب‌کار Excel جاسازی‌شده را ویرایش کنند و سپس با کلیک خارج از کتاب‌کار فعال‌شده به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و ضریب تغییر اندازه بسته به اندازه‌های اولیه هر دو فریم شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

کتاب‌کار Excel جاسازی‌شده ابعاد پنجرهٔ خود را دارد که Excel سعی می‌کند هنگام اولین فعال‌سازی شی آن را حفظ کند. فریم OLE روی اسلاید ابعاد مستقلی دارد. هنگامی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای حفظ نسبت‌های آن اندازهٔ شی را مذاکره می‌کنند؛ این توافق بخشی از فرایند جاسازی است. اختلاف بین پنجرهٔ کتاب‌کار و فریم OLE می‌تواند منجر به تغییر اندازهٔ شی شود.

## **راه‌حل عملی**

اندازه نمودار را با فریم OLE روی اسلاید تطبیق دهید و ابعاد نمودار را مستقل از پنجرهٔ کتاب‌کار نگه دارید. این راه‌حل با یک ارائهٔ جدید یا یک الگوی موجود کار می‌کند.

این مثال به Aspose.Cells for .NET و Aspose.Slides for .NET نیاز دارد. یک نمودار ستونی ساده بر روی شیت نمودار فعال ایجاد می‌کند و کتاب‌کار را در قالب XLS جاسازی می‌نماید. هیچ تصویر پیش‌نمایش نموداری اختصاص داده نشده‌است؛ نمودار زمانی که شی OLE در PowerPoint فعال می‌شود، قابل مشاهده می‌شود.

مثال یک ارائهٔ جدید با فریم OLE به‌اندازهٔ 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبهٔ چپ و 1 اینچ از بالای اسلاید قرار دارد. مختصات و ابعاد اسلاید بر حسب پوینت (72 پوینت در هر اینچ) هستند. برای یک ارائهٔ موجود، به [استفاده از الگو](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

Set [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) to false so that the chart dimensions are independent of the workbook window. Set the [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) dimensions through [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) and [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) to the Custom value of [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). The example embeds the workbook with [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) and saves a presentation with a 9.5 × 4-inch OLE frame.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// مختصات و ابعاد اسلاید بر حسب پوینت است (۷۲ پوینت در هر اینچ).
var width = 684f; // 9.5 اینچ.
var height = 288f; // 4 اینچ.

chart.SizeWithWindow = false;
// تبدیل پوینت‌ها به پیکسل‌های نمودار با استفاده از ۹۶ پیکسل در هر اینچ.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **استفاده از الگو**

منطق اندازه‌گیری برای یک ارائهٔ موجود مشابه است. برای سازگار کردن مثال:

1. ارائه قالب را بارگذاری کنید به‌جای ایجاد یک ارائه خالی.
2. اطمینان حاصل کنید که اسلاید اول حداقل شامل سه شکل باشد، سپس شکل با اندیس 2 را به‌عنوان جای‌گذاری استفاده کنید.
3. عرض و ارتفاع فریم را از آن شکل بگیرید به‌جای استفاده از مقادیر ثابت 684 و 288. محاسبات اندازه‌گیری را بدون تغییر نگه دارید.
4. فریم OLE را در موقعیت جای‌گذاری اضافه کنید به‌جای مختصات ثابت 36 و 72.
5. قبل از ذخیرهٔ ارائه، جای‌گذاری را حذف کنید.

## **سوالات متداول**

**چرا نمودار Excel جاسازی‌شده من پس از فعال‌سازی در PowerPoint اندازه‌اش را تغییر می‌دهد؟**

این به این دلیل اتفاق می‌افتد که Excel سعی می‌کند اندازهٔ پنجرهٔ اصلی را هنگام اولین فعال‌سازی بازگرداند، در حالی که فریم شی OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت ابعاد مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توانم اندازه‌های نمودار و فریم OLE را یکسان نگه دارم؟**

اندازه‌های ثابت نمودار را تنظیم کنید طوری که با فریم OLE مطابقت داشته باشد و قبل از جاسازی کتاب‌کار از یک اندازه چاپ سفارشی برای نمودار استفاده کنید. مثال بالا تنظیمات لازم و تبدیل واحدها را نشان می‌دهد.

**آیا تطبیق اندازه پنجرهٔ کتاب‌کار کافی است؟**

تنها تطبیق اندازه پنجرهٔ کتاب‌کار به‌طور قابل اعتمادی از تغییر اندازهٔ فریم OLE پس از فعال‌سازی جلوگیری نمی‌کند. از اندازه‌های ثابت نمودار همان‌طور که در مثال نشان داده شده استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید هر دو کار می‌کند؟**

بله. برای یک الگو، از ابعاد و موقعیت جای‌گذاری استفاده کنید. برای یک ارائهٔ جدید، مستقیماً ابعاد و موقعیت فریم را مشخص کنید.

**آیا می‌توانم این مثال را با نمودارهای ساخته‌شده در برنامه‌های جدول‌محور دیگر استفاده کنم؟**

این مثال از یک کتاب‌کار Excel ساخته‌شده با Aspose.Cells استفاده می‌کند. رفتار فعال‌سازی برای برنامه‌های جدول‌محور دیگر نشان داده نشده است.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای Excel و جایگذاری آن‌ها به‌عنوان اشیای OLE در ارائه‌ها](/slides/fa/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [به‌روزرسانی خودکار اشیای OLE با استفاده از افزودنی PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)