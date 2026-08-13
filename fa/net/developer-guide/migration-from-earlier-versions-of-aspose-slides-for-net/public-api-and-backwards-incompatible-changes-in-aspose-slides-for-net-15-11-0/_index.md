---
title: API عمومی و تغییرات ناسازگار با عقبگرد در Aspose.Slides برای .NET 15.11.0
linktitle: Aspose.Slides برای .NET 15.11.0
type: docs
weight: 210
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکننده در Aspose.Slides برای .NET را مرور کنید تا بتوانید به‌صورت یک‌پارچه راهکارهای ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و سایر موارد [added](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) یا [removed](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) را که با API Aspose.Slides for .NET 15.11.0 معرفی شده‌اند، فهرست می‌کند.

{{% /alert %}} 
## **Public API Changes**

#### **ویژگی‌های منسوخ شده در کلاس DataLabelCollection حذف شدند**
ویژگی‌های منسوخ شده در کلاس DataLabelCollection حذف شدند:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **ویژگی جدید FirstSlideNumber به کلاس Presentation اضافه شد**
ویژگی جدید FirstSlideNumber که به کلاس Presentation اضافه شده است، امکان دریافت یا تنظیم شماره اولین اسلاید در یک ارائه را فراهم می‌کند.

زمانی که مقدار جدید FirstSlideNumber مشخص شود، تمام شماره‌های اسلاید دوباره محاسبه می‌شوند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```