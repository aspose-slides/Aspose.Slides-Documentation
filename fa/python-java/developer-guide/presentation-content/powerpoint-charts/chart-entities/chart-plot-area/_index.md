---
title: سفارشی‌سازی نواحی نمودارهای ارائه در پایتون
linktitle: ناحیه نمودار
type: docs
url: /fa/python-java/chart-plot-area/
keywords:
- نمودار
- ناحیه نمودار
- عرض ناحیه نمودار
- ارتفاع ناحیه نمودار
- اندازه ناحیه نمودار
- حالت چیدمان
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "کشف کنید چگونه نواحی نمودار در ارائه‌های PowerPoint را با Aspose.Slides برای پایتون از طریق Java سفارشی کنید. به‌راحتی ظاهر اسلایدهای خود را بهبود دهید."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه با ناحیهٔ نمودار در Aspose.Slides کار کنیم. این مقاله توضیح می‌دهد چگونه موقعیت و اندازهٔ واقعی ناحیهٔ نمودار را با اعتبارسنجی چیدمان نمودار و سپس خواندن مقادیر X، Y، عرض و ارتفاع آن به دست آوریم.

همچنین نحوه پیکربندی حالت چیدمان ناحیهٔ نمودار را هنگامی که چیدمان به‌صورت دستی تنظیم می‌شود، با استفاده از [LayoutTargetType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layouttargettype/) برای تعیین اینکه ناحیهٔ نمودار بر پایهٔ ناحیهٔ داخلی یا ناحیهٔ خارجی همراه با محورها و برچسب‌های محورها محاسبه شود، نشان می‌دهد.

## **دریافت عرض و ارتفاع ناحیهٔ نمودار**

Aspose.Slides for Python via Java یک API ساده برای خواندن موقعیت و اندازهٔ واقعی ناحیهٔ نمودار فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
1. قبل از دریافت مقادیر واقعی، متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) را فراخوانی کنید.
1. موقعیت واقعی X (چپ) عنصر نمودار نسبت به گوشهٔ بالا‑چپ نمودار را دریافت کنید.
1. موقعیت واقعی Y (بالا) عنصر نمودار نسبت به گوشهٔ بالا‑چپ نمودار را دریافت کنید.
1. عرض واقعی عنصر نمودار را دریافت کنید.
1. ارتفاع واقعی عنصر نمودار را دریافت کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# ساختن یک نمونه از کلاس Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **تنظیم حالت چیدمان ناحیهٔ نمودار**

Aspose.Slides for Python via Java یک API ساده برای تنظیم حالت چیدمان ناحیهٔ نمودار فراهم می‌کند. متدهای [setLayoutTargetType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) و [getLayoutTargetType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) در کلاس [ChartPlotArea](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartplotarea/) موجود هستند. اگر چیدمان ناحیهٔ نمودار به‌صورت دستی تعریف شود، این تنظیم مشخص می‌کند که ناحیهٔ نمودار بر پایهٔ داخل (به‌جز محورها و برچسب‌های محورها) یا خارج (شامل محورها و برچسب‌های محورها) چیدمان شود. دو مقدار ممکن در شمارش [LayoutTargetType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layouttargettype/) تعریف شده‌اند.

- [Inner](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layouttargettype/#Inner) نشان می‌دهد که اندازهٔ ناحیهٔ نمودار علامت‌گذاری‌ها و برچسب‌های محورها را شامل نمی‌شود.
- [Outer](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layouttargettype/#Outer) نشان می‌دهد که اندازهٔ ناحیهٔ نمودار علامت‌گذاری‌ها و برچسب‌های محورها را شامل می‌شود.

کد نمونه در زیر ارائه شده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**واحدهای مقادیر X واقعی، Y واقعی، عرض واقعی و ارتفاع واقعی چیست؟**

به نقطه؛ 1 اینچ = 72 نقطه. این‌ها واحدهای مختصاتی Aspose.Slides هستند.

**ناحیهٔ نمودار از ناحیهٔ نمودار کلی (Chart Area) در محتوا چه تفاوتی دارد؟**

ناحیهٔ نمودار ناحیهٔ رسم داده‌ها (سری‌ها، خطوط شبکه، خطوط روند و غیره) است؛ ناحیهٔ نمودار کلی عناصری اطراف آن را شامل می‌شود (عنوان، لگند و غیره). در نمودارهای سه‌بعدی، ناحیهٔ نمودار همچنین دیوارها/کف و محورها را شامل می‌شود.

**X، Y، عرض و ارتفاع ناحیهٔ نمودار هنگام چیدمان دستی چگونه تفسیر می‌شوند؟**

این‌ها کسرهایی (0–1) از اندازهٔ کلی نمودار هستند؛ در این حالت، موقعیت‌یابی خودکار غیرفعال می‌شود و کسرهایی که تنظیم می‌کنید استفاده می‌شوند.

**چرا موقعیت ناحیهٔ نمودار پس از افزودن یا جابجایی لگند تغییر می‌کند؟**

لگند در ناحیهٔ نمودار کلی خارج از ناحیهٔ نمودار قرار می‌گیرد اما بر چیدمان و فضای موجود تأثیر می‌گذارد، بنابراین وقتی موقعیت‌یابی خودکار فعال است، ممکن است ناحیهٔ نمودار جابه‌جا شود. (این رفتار استاندارد برای نمودارهای PowerPoint است.)