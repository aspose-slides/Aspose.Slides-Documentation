---
title: سفارشی‌سازی جداول داده نمودار در پایتون
linktitle: جدول داده
type: docs
url: /fa/python-net/chart-data-table/
keywords:
- داده نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "جداول دادهٔ نمودار را در پایتون برای فرمت‌های PPT، PPTX و ODP با Aspose.Slides سفارشی کنید تا کارایی و جذابیت ارائه‌ها را افزایش دهید."
---
## **نمای کلی**

این مقاله نحوه کار با جداول داده‌ نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه یک جدول داده برای نمودار نمایش داده شده و قالب‌بندی متن آن را با تنظیم خصوصیات فونت مانند حالت بولد و ارتفاع فونت سفارشی کنید. مثال بارگذاری یک ارائه، افزودن یک نمودار، فعال‌سازی جدول دادهٔ نمودار، اعمال تنظیمات فونت و ذخیرهٔ ارائه به‌روز شده را نشان می‌دهد.

همچنین پاسخ‌های کوتاهی به سؤالات رایج دربارهٔ نمایش کلیدهای راهنمایی در جدول دادهٔ نمودار، حفظ جدول داده هنگام خروجی‌گیری، کار با نمودارهایی که از ارائه‌ها یا قالب‌های موجود بارگذاری شده‌اند، و شناسایی نمودارهایی که جدول داده در آن‌ها فعال است، ارائه می‌کند.

## **تنظیم خصوصیات فونت برای جدول دادهٔ نمودار**
Aspose.Slides for Python via .NET امکان تغییر رنگ دسته‌ها در یک سری رنگی را فراهم می‌کند.

1. نمونه‌سازی از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) .
2. افزودن نمودار به اسلاید.
3. تنظیم جدول نمودار.
4. تنظیم ارتفاع فونت.
5. ذخیرهٔ ارائهٔ تغییر یافته.

در زیر نمونه‌ای از کد ارائه شده است.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**آیا می‌توانم کلیدهای راهنمایی کوچک را در کنار مقادیر جدول دادهٔ نمودار نشان دهم؟**

بله. جدول داده از [کلیدهای راهنمایی](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/datatable/show_legend_key/) پشتیبانی می‌کند و می‌توانید آن‌ها را روشن یا خاموش کنید.

**آیا جدول داده هنگام خروجی‌گیری ارائه به PDF، HTML یا تصویر حفظ می‌شود؟**

بله. Aspose.Slides نمودار را به‌عنوان بخشی از اسلاید رندر می‌کند، بنابراین [PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/fa/python-net/convert-powerpoint-to-html/)/[تصویر](/slides/fa/python-net/convert-powerpoint-to-png/) خروجی شامل نمودار به همراه جدول داده است.

**آیا جداول داده برای نمودارهایی که از فایل قالب بارگذاری می‌شوند پشتیبانی می‌شوند؟**

بله. برای هر نموداری که از یک ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از خصوصیات نمودار بررسی و تغییر دهید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/has_data_table/) یا خیر.

**چگونه می‌توانم به‌سرعت تعیین کنم کدام نمودارها در یک فایل جدول داده فعال دارند؟**

خصوصیت هر نمودار که نشان می‌دهد جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/has_data_table/) را بررسی کنید و از طریق اسلایدها عبور کنید تا نمودارهایی که این ویژگی فعال است را شناسایی کنید.