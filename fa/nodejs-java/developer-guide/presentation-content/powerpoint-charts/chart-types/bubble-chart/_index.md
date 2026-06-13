---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: نمودار حبابی
type: docs
url: /fa/nodejs-java/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌بندی اندازه
- نمایش اندازه
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نمودارهای حبابی قدرتمند را در PowerPoint با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق Java ایجاد و سفارشی‌سازی کنید تا نمایش داده‌های خود را به آسانی ارتقا دهید."
---
## **Overview**

این مقاله نشان می‌دهد چگونه با نمودارهای حبابی در Aspose.Slides کار کنید. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌بندی اندازه حباب‌ها از طریق متد `setBubbleSizeScale` و کنترل نحوه نمایش مقادیر اندازه حباب‌ها از طریق متد `setBubbleSizeRepresentation`.

مثال‌ها نشان می‌دهند چگونه یک نمودار حبابی ایجاد کنید، مقیاس اندازه آن را تنظیم کنید و نمایش اندازه حباب را به استفاده از عرض تغییر دهید. مقاله همچنین شامل بخش کوتاهی از سؤالات متداول است که پشتیبانی از نوع نمودار “Bubble with 3-D” را روشن می‌کند، یادآوری می‌کند که محدودیت‌های عملی نمودار به عملکرد و نسخه هدف PowerPoint بستگی دارد، و توضیح می‌دهد که صادرات ظاهر نمودار را از طریق موتور رندر Aspose.Slides حفظ می‌کند.

## **Bubble Chart Size Scaling**

Aspose.Slides for Node.js via Java پشتیبانی از مقیاس‌بندی اندازه نمودار حبابی را فراهم می‌کند. در Aspose.Slides for Node.js via Java[**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--),[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) و[**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) متدهایی اضافه شده‌اند. نمونه کد زیر ارائه شده است.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Represent Data as Bubble Chart Sizes**

متدهای[**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) و[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) به کلاس‌های[ChartSeries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeries),[ChartSeriesGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartSeriesGroup) و کلاس‌های مرتبط افزوده شده‌اند. **BubbleSizeRepresentation** مشخص می‌کند مقادیر اندازه حباب‌ها در نمودار حبابی چگونه نمایش داده شوند. مقادیر ممکن عبارتند از:[**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) و[**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). به همین ترتیب، شمارشی به نام[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BubbleSizeRepresentationType) برای مشخص کردن روش‌های ممکن نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی اضافه شده است. کد نمونه در زیر آورده شده است.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

بله. یک نوع نمودار جداگانه به نام «Bubble with 3-D» وجود دارد. این نوع به حباب‌ها سبک‌گذاری سه‌بعدی می‌دهد اما محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان به صورت X‑Y‑S (اندازه) باقی می‌مانند. این نوع در شمارنده [chart type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/charttype/) موجود است.

**Is there a limit on the number of series and points in a bubble chart?**

در سطح API محدودیت سخت‌گیرانه‌ای وجود ندارد؛ محدودیت‌ها توسط عملکرد و نسخه هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را به‌گونه‌ای نگه دارید که برای خوانایی و سرعت رندر معقول باشد.

**How will export affect the appearance of a bubble chart (PDF, images)?**

صادرات به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندر توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستری/وب‌کتور، قوانین عمومی رندر گرافیک نمودار (رزولوشن، ضد‌لبه) اعمال می‌شود، بنابراین برای چاپ DPI کافی انتخاب کنید.