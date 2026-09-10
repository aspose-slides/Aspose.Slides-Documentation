---
title: سفارشی‌سازی نمودارهای حبابی در ارائه‌ها با استفاده از پایتون
linktitle: نمودار حبابی
type: docs
url: /fa/python-java/bubble-chart/
keywords:
- نمودار حبابی
- اندازه حباب
- مقیاس‌بندی اندازه
- نمایش اندازه
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارهای حبابی قدرتمند در PowerPoint با Aspose.Slides برای Python از طریق Java برای ارتقای آسان تجسم داده‌های شما."
---
## **مروری کلی**

این مقاله نشان می‌دهد چگونه با نمودارهای حبابی در Aspose.Slides کار کنید. دو گزینه سفارشی‌سازی خاص را پوشش می‌دهد: مقیاس‌بندی اندازه حباب‌ها از طریق متد [setBubbleSizeScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) و کنترل نحوه نمایش مقادیر اندازه حباب‌ها از طریق متد [setBubbleSizeRepresentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

مثال‌ها نشان می‌دهند چگونه یک نمودار حبابی ایجاد کنید، مقیاس اندازه آن را تنظیم کنید و نمایاندن اندازه حباب‌ها را به استفاده از عرض تغییر دهید. مقاله همچنین شامل بخش کوتاهی از سوالات متداول است که پشتیبانی از نوع نمودار “Bubble with 3‑D” را روشن می‌کند، توجه می‌کند که محدودیت‌های عملی نمودار به عملکرد و نسخه هدف PowerPoint وابسته است و توضیح می‌دهد که خروجی ظاهر نمودار را از طریق موتور رندر Aspose.Slides حفظ می‌کند.

## **مقیاس‌بندی اندازه نمودار حبابی**
Aspose.Slides for Python via Java از مقیاس‌بندی اندازه نمودار حبابی از طریق متدهای [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseries/#getBubbleSizeScale)، [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) و [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) پشتیبانی می‌کند. مثال زیر نشان می‌دهد چگونه اندازه حباب‌ها را مقیاس‌بندی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی**
متدهای [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) و [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) در کلاس [ChartSeriesGroup](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/) موجود هستند. نمایاندن اندازه حباب مشخص می‌کند که مقادیر اندازه حباب‌ها در نمودار حبابی چگونه نمایش داده شوند. مقادیر ممکن عبارتند از [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bubblesizerepresentationtype/#Area) و [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bubblesizerepresentationtype/#Width). شمارش [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/fa/python-java/aspose.slides/bubblesizerepresentationtype/) روش‌های ممکن برای نمایش داده‌ها به عنوان اندازه‌های نمودار حبابی را تعریف می‌کند. مثال زیر نشان می‌دهد چگونه اندازه حباب‌ها را با استفاده از عرض نمایش دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا نمودار حبابی با اثر 3‑بعدی پشتیبانی می‌شود و چه تفاوتی با نسخه معمولی دارد؟**

بله. یک نوع نمودار جداگانه به نام «Bubble with 3‑D» وجود دارد. این نوع استایل سه‌بعدی را بر روی حباب‌ها اعمال می‌کند اما محور اضافی اضافه نمی‌کند؛ داده‌ها همچنان X‑Y‑S (اندازه) باقی می‌مانند. این نوع در کلاس [chart type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) موجود است.

**آیا محدودیتی برای تعداد سری‌ها و نقاط در یک نمودار حبابی وجود دارد؟**

در سطح API محدودیت سختی وجود ندارد؛ محدودیت‌ها توسط عملکرد و نسخه هدف PowerPoint تعیین می‌شوند. توصیه می‌شود تعداد نقاط را در حد معقولی نگه دارید تا خوانایی و سرعت رندر حفظ شود.

**استخراج چگونه بر ظاهر نمودار حبابی (PDF، تصاویر) تأثیر می‌گذارد؟**

صادر کردن به فرمت‌های پشتیبانی‌شده ظاهر نمودار را حفظ می‌کند؛ رندرینگ توسط موتور Aspose.Slides انجام می‌شود. برای فرمت‌های رستر/وکتور، قوانین کلی رندر گرافیک نمودار (رزولوشن، ضد لبه) اعمال می‌شود، بنابراین برای چاپ DPI کافی انتخاب کنید.