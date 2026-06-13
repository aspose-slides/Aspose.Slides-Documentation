---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها با استفاده از جاوا
linktitle: نمودار حبابی
type: docs
url: /fa/java/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌بندی اندازه
- نمایاندن اندازه
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارهای حبابی قدرتمند در پاورپوینت با Aspose.Slides برای جاوا به‌صورت ساده برای بهبود تجسم داده‌ها."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه با نمودارهای حبابی در Aspose.Slides کار کنیم. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌بندی اندازه حباب‌ها از طریق متد `setBubbleSizeScale` و کنترل نحوه نمایاندن مقادیر اندازه حباب‌ها از طریق متد `setBubbleSizeRepresentation`.

مثال‌ها نشان می‌دهند چگونه یک نمودار حبابی ایجاد کنیم، مقیاس‌بندی اندازه آن را تنظیم کنیم و نمایاندن اندازه حباب را به استفاده از عرض تغییر دهیم. این مقاله همچنین شامل بخش کوتاهی پرسش‌های متداول است که پشتیبانی از نوع نمودار «Bubble with 3‑D» را روشن می‌کند، یادآور می‌شود محدودیت‌های عملی نمودار به عملکرد و نسخه هدف PowerPoint بستگی دارد، و توضیح می‌دهد که صادرات ظاهر نمودار را از طریق موتور رندرینگ Aspose.Slides حفظ می‌کند.

## **مقیاس‌بندی اندازه نمودار حبابی**
Aspose.Slides برای Java از مقیاس‌بندی اندازه نمودار حبابی پشتیبانی می‌کند. در Aspose.Slides برای Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) و [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) متدها اضافه شده‌اند. نمونه مثال زیر ارائه شده است.

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

## **نمایش داده‌ها به‌عنوان اندازه‌های نمودار حبابی**
متدهای [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) و [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) به اینترفیس‌های [IChartSeries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartSeriesGroup) و کلاس‌های مرتبط اضافه شده‌اند. **BubbleSizeRepresentation** تعیین می‌کند مقادیر اندازه حباب در نمودار حبابی چگونه نمایش داده شوند. مقادیر ممکن عبارتند از: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/BubbleSizeRepresentationType#Area) و [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/BubbleSizeRepresentationType#Width). بر این اساس، شمارش‌گر [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/BubbleSizeRepresentationType) برای مشخص کردن روش‌های ممکن نمایش داده‌ها به‌عنوان اندازه‌های نمودار حبابی اضافه شده است. نمونه کد در زیر آورده شده است.

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

## **پرسش‌های متداول**

**آیا «نمودار حبابی با اثر 3‑بعدی» پشتیبانی می‌شود و چگونه با یک نمودار معمولی متفاوت است؟**

بله. یک نوع نمودار جداگانه به نام «Bubble with 3‑D» وجود دارد. این نوع استایل 3‑بعدی را به حباب‌ها اعمال می‌کند اما محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان X‑Y‑S (اندازه) باقی می‌مانند. این نوع در کلاس [نوع نمودار](https://reference.aspose.com/slides/fa/java/com.aspose.slides/charttype/) موجود است.

**آیا محدودیتی برای تعداد سری‌ها و نقاط در یک نمودار حبابی وجود دارد؟**

در سطح API محدودیت سخت‌گیرانه‌ای وجود ندارد؛ محدودیت‌ها توسط عملکرد و نسخه هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را برای قابلیت خواندن و سرعت رندر معقول نگه دارید.

**صادرات چگونه بر ظاهر یک نمودار حبابی (PDF، تصاویر) تأثیر می‌گذارد؟**

صادرات به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندر توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستری/وکتور، قوانین عمومی رندر نمودار (رزولوشن، آنتی‑آلیاسینگ) اعمال می‌شود، بنابراین برای چاپ DPI کافی انتخاب کنید.