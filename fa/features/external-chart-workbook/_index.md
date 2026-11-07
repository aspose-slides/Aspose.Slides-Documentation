---
title: پیوند نمودارها به کتاب‌کارهای خارجی
description: پیوند داده‌های نمودار به یک کتاب‌کار خارجی و تازه‌سازی آن.
type: docs
url: /fa/features/external-chart-workbook/
weight: 1070
feature_id: نمودار-کتاب-کار-خارجی
feature_group: نمودارها
translationKey: اسلاید-ویژگی-نمودار-کتاب-کار-خارجی
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **بررسی کلی**

یک نمودار را به یک کتاب‌کار خارجی ارجاع دهید به جای اینکه تمام داده‌های منبع آن را داخل ارائه جاسازی کنید. می‌توانید مسیر کتاب‌کار را تنظیم کنید و انتخاب کنید آیا نمودار از آن فایل به‌روز شود یا نه. نمودار ذخیره‌شده می‌تواند داده‌های نمایش کش‌شده را نیز حمل کند.

## **مثال استفاده**

این مثال C# از Aspose.Slides برای .NET استفاده می‌کند. یک کتاب‌کار فروش معتبر با North = 55 و South = 40 ایجاد کنید و آن را به‌صورت sales.xlsx در کنار خروجی بنویسید. مقدار North در نمودار را به 20 بازنشانی کنید، سپس نمودار را به مسیر مطلق کتاب‌کار پیوند دهید و تازه‌سازی کنید: North دوباره به 55 تبدیل می‌شود. بازه صریح شامل سرعنوان و دو سطر داده است. هنگام بازکردن مجدد یا به‌روزرسانی نمودار پیوندی، sales.xlsx را در دسترس نگه دارید؛ ارائه این فایل خارجی را جاسازی نمی‌کند. نیازی به فایل ورودی نیست. فایل‌های *external-chart-workbook.pptx* و *external-chart-workbook.png* ذخیره می‌شوند. کتابخانه را با استفاده از [راهنمای نصب](/slides/fa/net/installation/) نصب کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **سوالات متداول**

### **آیا می‌توانم هر مقدار کش‌شده‌ای را وقتی فایل پیوندی موجود نیست بخوانم؟**

Aspose.Slides برای .NET 26.11 می‌تواند [مقادیر ذخیره‌شده نمودار را مستقیماً بخواند](/slides/fa/net/chart-workbook/#read-cached-chart-values-without-a-workbook) بدون باز کردن کتاب‌کار پیوندی. این شامل مقادیر عادی، مقادیر X/Y، اندازه‌های حباب و مقادیر دسته‌بندی است زمانی که این کش‌ها موجود باشند. داده‌های کش‌شده ممکن است غیربا حضور یا منسوخ باشند؛ این یک کتاب‌کار کامل نیست. تازه‌سازی از منبع همچنان به یک کتاب‌کار پشتیبانی‌شده موجود نیاز دارد. برای دیگر SDKها و نسخه‌ها، راهنمای مربوط به نمودار آن‌ها را بررسی کنید.

### **اگر کتاب‌کار خارجی جابجا شود چه می‌شود؟**

مسیر کتاب‌کار خارجی نمودار را به مکان جدید آن به‌روزرسانی کنید و اطمینان حاصل کنید که آن فایل در هر جایی که ارائه پردازش می‌شود در دسترس باشد. هنگام عدم وجود کش، برای عملیات دسترسی کامل به داده‌ها به کش وابسته نشوید.

### **آیا می‌توانم انتخاب کنم که داده‌های کش‌شده نمودار هنگام پیوند تازه‌سازی شوند یا نه؟**

بله. می‌توانید هنگام تنظیم پیوند انتخاب کنید که داده‌های نمودار به‌روز شوند یا نه. تازه‌سازی نیاز به یک کتاب‌کار پشتیبانی‌شده موجود دارد؛ گذر از تازه‌سازی فقط پیوند را ثبت می‌کند بدون اینکه مقادیر جدید را از آن فایل بخواند.

## **راهنماها**

- [مدیریت کتاب‌کارهای نمودار در ارائه‌ها در .NET](/slides/fa/net/chart-workbook/)

ویژگی مرتبط: [پر کردن نمودارهای قابل ویرایش با داده](/slides/fa/features/chart-data-binding/).