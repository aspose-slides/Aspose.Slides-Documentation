---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها برای اندروید
linktitle: نمودار حبابی
type: docs
url: /fa/androidjava/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌بندی اندازه
- نمایش اندازه
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "نمودارهای حبابی قدرتمند را در PowerPoint با Aspose.Slides برای اندروید از طریق Java ایجاد و سفارشی کنید تا به راحتی تجسم داده‌های خود را بهبود بخشید."
---
## **Overview**

این مقاله نحوه کار با نمودارهای حبابی در Aspose.Slides را نشان می‌دهد. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌بندی اندازه‌های حباب از طریق متد `setBubbleSizeScale` و کنترل نحوه نمایش مقادیر اندازه حباب‌ها با استفاده از متد `setBubbleSizeRepresentation`.

مثال‌ها نشان می‌دهند چگونه یک نمودار حبابی ایجاد کرده، مقیاس اندازه آن را تنظیم کنید و نمای اندازه حباب را به استفاده از عرض تغییر دهید. همچنین مقاله شامل بخش کوتاهی پرسش‌های متداول (FAQ) است که پشتیبانی از نوع نمودار «Bubble with 3-D» را روشن می‌کند، اشاره می‌کند محدودیت‌های عملی نمودار به عملکرد و نسخه هدف PowerPoint وابسته است، و توضیح می‌دهد خروجی صادرات ظاهر نمودار را از طریق موتور رندر Aspose.Slides حفظ می‌کند.

## **Bubble Chart Size Scaling**
Aspose.Slides for Android via Java پشتیبانی از مقیاس‌بندی اندازه نمودار حبابی را فراهم می‌کند. در Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) و [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) متدها اضافه شده‌اند. نمونه کد زیر ارائه شده است.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Represent Data as Bubble Chart Sizes**
متدهای [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) و [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) به رابط‌های [IChartSeries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeries)، [IChartSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartSeriesGroup) و کلاس‌های مرتبط اضافه شده‌اند. **BubbleSizeRepresentation** مشخص می‌کند مقادیر اندازه حباب‌ها در نمودار حبابی چگونه نمایش داده شوند. مقادیر ممکن عبارتند از: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) و [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). بر این اساس، شمارش ([**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/BubbleSizeRepresentationType)) برای تعیین روش‌های ممکن نمایش داده‌ها به‌عنوان اندازه‌های نمودار حبابی افزوده شده است. کد نمونه در زیر آورده شده است.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**آیا «نمودار حبابی با اثر سه‌بعدی» پشتیبانی می‌شود و چطور با نسخهٔ عادی متفاوت است؟**

بله. یک نوع نمودار جداگانه به نام «Bubble with 3-D» وجود دارد. این نوع استایل سه‌بعدی را به حباب‌ها اعمال می‌کند اما محور اضافه‌ای ایجاد نمی‌کند؛ داده‌ها همچنان X‑Y‑S (اندازه) باقی می‌مانند. این نوع در کلاس [chart type](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) موجود است.

**آیا محدودیتی برای تعداد سری‌ها و نقاط در یک نمودار حبابی وجود دارد؟**

در سطح API محدودیت سخت‌گیرانه‌ای وجود ندارد؛ محدودیت‌ها بر پایهٔ عملکرد و نسخه هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را به‌گونه‌ای معقول نگه دارید تا خوانایی و سرعت رندر حفظ شود.

**صدور (Export) چگونه بر ظاهر نمودار حبابی (PDF، تصویر) تاثیر می‌گذارد؟**

صادر شدن به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندر توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستر/وکتور، قوانین عمومی رندر گرافیک نمودار (رزولوشن، ضد لبه) اعمال می‌شود، بنابراین برای چاپ DPI کافی را انتخاب کنید.