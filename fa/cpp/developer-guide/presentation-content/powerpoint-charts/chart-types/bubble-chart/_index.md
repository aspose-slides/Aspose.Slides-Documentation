---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها با استفاده از С++
linktitle: نمودار حبابی
type: docs
url: /fa/cpp/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌گذاری اندازه
- نمایش اندازه
- PowerPoint
- ارائه
- С++
- Aspose.Slides
description: "نمودارهای حبابی قدرتمند را در PowerPoint با Aspose.Slides برای С++ ایجاد و سفارشی کنید تا به راحتی تجسم داده‌های خود را ارتقا دهید."
---
## **Overview**

این مقاله نشان می‌دهد چگونه با چارت‌های حبابی در Aspose.Slides کار کنیم. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: تنظیم مقیاس اندازه حباب‌ها از طریق متد `set_BubbleSizeScale` و کنترل نحوهٔ نمایش مقدار اندازه حباب‌ها از طریق متد `set_BubbleSizeRepresentation`.

مثال‌ها نشان می‌دهند چگونه یک چارت حبابی ایجاد شود، مقیاس اندازه آن تنظیم گردد، و نمایش اندازه حباب به‌صورت عرض تغییر یابد. همچنین بخشی کوتاه از پرسش‌های متداول شامل پشتیبانی از نوع چارت “Bubble with 3‑D”، اشاره‌ای به محدودیت‌های عملی چارت که به عملکرد و نسخه هدف PowerPoint وابسته است، و توضیحی دربارهٔ این که صادرات ظاهر چارت را با موتور رندر Aspose.Slides حفظ می‌کند، گنجانده شده است.

## **Bubble Chart Size Scaling**
Aspose.Slides for C++ پشتیبانی از مقیاس‌گذاری اندازه چارت حبابی را ارائه می‌دهد. در Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** و **IChartSeriesGroup.BubbleSizeScale** ویژگی‌ها اضافه شده‌اند. نمونهٔ زیر ارائه شده است.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Represent Data as Bubble Chart Sizes**
متد جدید **get_BubbleSizeRepresentation()** به کلاس‌های **IChartSeries** و **ChartSeries** اضافه شده است. **BubbleSizeRepresentation** مشخص می‌کند مقادیر اندازه حباب‌ها در چارت حبابی چگونه نمایش داده شوند. مقادیر ممکن: **BubbleSizeRepresentationType.Area** و **BubbleSizeRepresentationType.Width**. به همین دلیل، enum **BubbleSizeRepresentationType** برای تعریف روش‌های ممکن نمایش داده‌ها به‌عنوان اندازه‌های چارت حبابی اضافه شده است. کد نمونه در زیر آمده است.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**آیا “چارت حبابی با اثر سه‑بعدی” پشتیبانی می‌شود و چگونه با چارت معمولی متفاوت است؟**

بله. یک نوع چارت جداگانه به نام “Bubble with 3-D” موجود است. این نوع استایل سه‑بعدی را به حباب‌ها اعمال می‌کند اما محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان به شکل X‑Y‑S (اندازه) باقی می‌مانند. این نوع در شمارش‌گر [chart type](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/charttype/) قابل دسترسی است.

**آیا محدودیتی برای تعداد سری‌ها و نقاط در یک چارت حبابی وجود دارد؟**

در سطح API محدودیت سختی وجود ندارد؛ محدودیت‌ها به عملکرد و نسخهٔ هدف PowerPoint بستگی دارند. توصیه می‌شود تعداد نقاط را به‌گونه‌ای تنظیم کنید که برای خوانایی و سرعت رندر مناسب باشد.

**صادرات چگونه بر ظاهر چارت حبابی (PDF، تصویر) تأثیر می‌گذارد؟**

صادرات به فرمت‌های پشتیبانی‌شده ظاهر چارت را حفظ می‌کند؛ رندر توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستر/وکتور، قوانین عمومی رندر گرافیک چارت (وضوح، ضد‌لرزگی) اعمال می‌شود، بنابراین برای چاپ DPI کافی انتخاب کنید.