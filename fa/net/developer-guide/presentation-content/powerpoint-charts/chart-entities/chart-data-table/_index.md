---
title: سفارشی‌سازی جداول دادهٔ نمودار در ارائه‌ها با .NET
linktitle: جدول داده
type: docs
url: /fa/net/chart-data-table/
keywords:
- داده نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "جداول دادهٔ نمودار را در .NET برای PPT و PPTX با Aspose.Slides سفارشی‌سازی کنید تا کارایی و جذابیت ارائه‌ها را افزایش دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با جداول دادهٔ نمودار در Aspose.Slides کار کنیم. نشان می‌دهد چگونه یک جدول داده برای یک نمودار نمایش داده و قالب‌بندی متن آن را با تنظیم ویژگی‌های قلم مانند حالت بولد و ارتفاع قلم سفارشی کنید. مثال بارگیری یک ارائه، افزودن نمودار، فعال‌سازی جدول دادهٔ نمودار، اعمال تنظیمات قلم و ذخیرهٔ ارائه به‌روز شده را نشان می‌دهد.

همچنین پاسخ‌های کوتاهی به سوالات رایج درباره نمایش کلیدهای راهنما در جدول دادهٔ نمودار، حفظ جدول داده هنگام خروجی‌گیری، کار با نمودارهای بارگذاری شده از ارائه‌ها یا قالب‌های موجود، و شناسایی نمودارهایی که جدول داده برای آنها فعال است، ارائه می‌کند.

## **تنظیم ویژگی‌های قلم برای جدول دادهٔ نمودار**
Aspose.Slides برای .NET پشتیبانی از تغییر رنگ دسته‌ها در رنگ سری را فراهم می‌کند.

1. یک شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) را نمونه‌سازی کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. جدول نمودار را تنظیم کنید.
1. ارتفاع قلم را تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

در زیر یک نمونه مثال آورده شده است.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم کلیدهای راهنمای کوچک را در کنار مقادیر در جدول دادهٔ نمودار نشان دهم؟**

بله. جدول داده از [کلیدهای راهنما](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/datatable/showlegendkey/) پشتیبانی می‌کند و می‌توانید آنها را روشن یا خاموش کنید.

**آیا جدول داده هنگام صادرات ارائه به PDF، HTML یا تصویر حفظ می‌شود؟**

بله. Aspose.Slides نمودار را به عنوان بخشی از اسلاید رندر می‌کند، بنابراین [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)/[HTML](/slides/fa/net/convert-powerpoint-to-html/)/[image](/slides/fa/net/convert-powerpoint-to-png/) خروجی‌شده شامل نمودار با جدول دادهٔ آن است.

**آیا جداول داده برای نمودارهایی که از یک فایل قالب بارگذاری می‌شوند، پشتیبانی می‌شود؟**

بله. برای هر نموداری که از یک ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از ویژگی‌های نمودار بررسی و تغییر دهید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/hasdatatable/) یا نه.

**چگونه می‌توانم سریعاً تشخیص دهم کدام نمودارها در یک فایل جدول دادهٔ فعال دارند؟**

ویژگی هر نمودار که نشان می‌دهد آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/hasdatatable/) را بررسی کنید و در اسلایدها مرور کنید تا نمودارهایی که فعال هستند را شناسایی کنید.