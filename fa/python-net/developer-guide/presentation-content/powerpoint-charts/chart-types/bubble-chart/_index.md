---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها با پایتون
linktitle: نمودار حبابی
type: docs
url: /fa/python-net/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌بندی اندازه
- نمایش اندازه
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارهای حبابی قدرتمند در PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET برای بهبود سادهٔ تجسم داده‌های شما."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چطور با نمودارهای حبابی در Aspose.Slides کار کنید. دو گزینهٔ سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌بندی اندازه حباب‌ها از طریق ویژگی `bubble_size_scale` و کنترل نحوهٔ نمایش مقادیر اندازه حباب‌ها از طریق ویژگی `bubble_size_representation`.

مثال‌ها نحوهٔ ایجاد یک نمودار حبابی، تنظیم مقیاس‌بندی اندازه آن و تغییر نمایش اندازه حباب به استفاده از عرض را نشان می‌دهند. مقاله همچنین شامل بخش کوتاه پرسش‌های متداول است که پشتیبانی از نوع نمودار «Bubble with 3‑D» را روشن می‌کند، اشاره می‌کند محدودیت‌های عملی نمودار بستگی به عملکرد و نسخهٔ هدف PowerPoint دارد، و توضیح می‌دهد خروجی با استفاده از موتور رندرینگ Aspose.Slides ظاهر نمودار را حفظ می‌کند.

## **مقیاس‌بندی اندازه نمودار حبابی**
Aspose.Slides for Python via .NET پشتیبانی از مقیاس‌بندی اندازه نمودار حبابی را فراهم می‌کند. در Aspose.Slides for Python via .NET ویژگی‌های **ChartSeries.bubble_size_scale** و **ChartSeriesGroup.bubble_size_scale** اضافه شده‌اند. نمونهٔ زیر ارائه شده است.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی**
ویژگی **bubble_size_representation** به کلاس‌های ChartSeries و ChartSeriesGroup اضافه شده است. **bubble_size_representation** مشخص می‌کند مقادیر اندازه حباب‌ها در نمودار حبابی چگونه نمایش داده شوند. مقادیر ممکن عبارتند از: **BubbleSizeRepresentationType.AREA** و **BubbleSizeRepresentationType.WIDTH**. به همین ترتیب، شمارندهٔ **BubbleSizeRepresentationType** برای تعیین روش‌های ممکن نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی اضافه شده است. کد نمونه در زیر آمده است.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا «نمودار حبابی با اثر ۳‑بعدی» پشتیبانی می‌شود و چه تفاوتی با نسخهٔ معمولی دارد؟**

بله. یک نوع نمودار جداگانه به نام «Bubble with 3‑D» وجود دارد. این نوع استایل ۳‑بعدی را بر روی حباب‌ها اعمال می‌کند اما محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان به صورت X‑Y‑S (اندازه) باقی می‌مانند. این نوع در شمارندهٔ [chart type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/charttype/) موجود است.

**آیا محدودیتی برای تعداد سری‌ها و نقاط در یک نمودار حبابی وجود دارد؟**

در سطح API محدودیت سخت‌گیرانه‌ای وجود ندارد؛ محدودیت‌ها توسط عملکرد و نسخهٔ هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را به‌ گونه‌ای نگه دارید که خوانایی و سرعت رندر مناسب باشد.

**صادرات چگونه بر ظاهر یک نمودار حبابی (PDF، تصاویر) تأثیر می‌گذارد؟**

صادرات به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندرینگ توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستر/وکتور، قوانین کلی رندرینگ گرافیک نمودار (رزولوشن، ضد‑الایاسینگ) اعمال می‌شود، بنابراین برای چاپ DPI کافی انتخاب کنید.