---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 14.3.0
linktitle: Aspose.Slides برای .NET 14.3.0
type: docs
weight: 50
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا به‌صورت روان‌تری ارائه‌های PowerPoint (PPT, PPTX) و ODP خود را مهاجرت دهید."
---
## **API عمومی و تغییرات ناسازگار با نسخه‌های قبلی**
### **Enumeration Aspose.Slides.ShapeThumbnailBounds و متدهای Aspose.Slides.IShape.GetThumbnail() اضافه شدند**
متدهای GetThumbnail() و GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) برای ایجاد تصویر بندانگشتی جداگانه‌ای از شکل استفاده می‌شوند. enumeration ShapeThumbnailBounds انواع ممکن مرزهای تصویر بندانگشتی شکل را تعریف می‌کند.

### **ویژگی UniqueId به Aspose.Slides.IShape اضافه شد**
ویژگی Aspose.Slides.IShape.UniqueId شناسهٔ منحصربه‌فردی در زمینهٔ ارائه برای شکل برمی‌گرداند. این شناسه‌های منحصربه‌فرد در برچسب‌های سفارشی شکل ذخیره می‌شوند.

### **امضای متد SetGroupingItem در IChartCategoryLevelsManager تغییر یافت**
امضای متد IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

```

اکنون منقضی شده و با امضای

``` csharp

 void SetGroupingItem(int level, object value);

```

جایگزین شد.

در حال حاضر فراخوانی‌هایی مانند

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

```

باید به فراخوانی‌های مشابه

``` csharp

 .SetGroupingItem(1, "Group 1");

```

تغییر یابند.

یک مقدار مانند "Group 1" را به SetGroupingItem پاس بدهید ولی مقدار از نوع IChartDataCell نباشد. ساختن IChartDataCell با یک ورک‌شوِت، ردیف و ستون تعریف‌شده برای سطوح دسته‌بندی باید برخی الزامات را برآورده کند و در متد SetGroupingItem(int, object) محصور شده است.

### **ویژگی SlideId به رابط Aspose.Slides.IBaseSlide اضافه شد**
ویژگی SlideId یک شناسهٔ منحصربه‌فرد برای اسلاید برمی‌گرداند.

### **ویژگی SoundName به ISlideShowTransition اضافه شد**
رشتهٔ خواندنی‑نوشتنی. نامی قابل‌خواندن برای انسان برای صدای انتقال را مشخص می‌کند. برای دریافت یا تنظیم نام صدا باید ویژگی Sound مقداردهی شود. این نام در رابط کاربری PowerPoint هنگام پیکربندی دستی صدای انتقال ظاهر می‌شود. ممکن است در صورت عدم مقداردهی به ویژگی Sound، PptxException پرتاب شود.

### **نوع ویژگی ChartSeriesGroup.Type تغییر کرد**
ویژگی ChartSeriesGroup.Type از enumeration ChartType به enumeration جدید CombinableSeriesTypesGroup تغییر یافته است. enum CombinableSeriesTypesGroup نشان‌دهندهٔ گروه‌های انواع سری‌های ترکیبی است.

### **پشتیبانی از تولید تصویر بندانگشتی جداگانهٔ شکل اضافه شد**
Aspose.Slides.ShapeThumbnailBounds

اعضای جدید در Aspose.Slides.IShape، Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)