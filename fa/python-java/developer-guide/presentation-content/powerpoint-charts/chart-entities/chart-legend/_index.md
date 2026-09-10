---
title: سفارشی‌سازی پیش‌نویس‌های نمودار در ارائه‌ها با استفاده از پایتون
linktitle: پیش‌نویس نمودار
type: docs
url: /fa/python-java/chart-legend/
keywords:
- پیش‌نویس نمودار
- موقعیت پیش‌نویس
- اندازه قلم
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "پیش‌نویس‌های نمودار را با Aspose.Slides برای Python از طریق Java سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی پیش‌نویس مناسب بهینه کنید."
---
## **مرور کلی**

Aspose.Slides گزینه‌هایی برای سفارشی‌سازی پیش‌نویس‌های نمودار در ارائه‌های PowerPoint ارائه می‌دهد. این مقاله نشان می‌دهد چگونه یک پیش‌نویس را موقعیت‌دهی و اندازه‌گذاری کنید، اندازهٔ قلم را برای کل پیش‌نویس تنظیم کنید، و قالب‌بندی را برای یک ورودی پیش‌نویس منفرد اعمال کنید.

همچنین چند رفتار مرتبط در بخش پرسش‌های متداول پوشش داده می‌شود، از جمله استفاده از حالت غیر‌پوشش (non‑overlay) تا ناحیهٔ نمودار برای پیش‌نویس فضای لازم را داشته باشد، اجازه دادن به برچسب‌های طولانی پیش‌نویس برای شکست خطوط یا استفاده از خطوط جدید، و اجازه دادن به ارث‌بری قالب‌بندی پیش‌نویس از تم ارائه وقتی تنظیمات صریح متن و پرکردن اعمال نشده باشند.

## **موقعیت‌دهی پیش‌نویس**

برای تنظیم ویژگی‌های پیش‌نویس، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلاید دریافت کنید.
1. یک نمودار به اسلاید اضافه کنید.
1. ویژگی‌های پیش‌نویس را تنظیم کنید.
1. ارائه را به عنوان فایل PPTX ذخیره کنید.

مثال زیر موقعیت و اندازهٔ پیش‌نویس یک نمودار را تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# یک ارائهٔ خالی ایجاد کنید.
presentation = Presentation()
try:
    # یک مرجع به اسلاید دریافت کنید.
    slide = presentation.getSlides().get_Item(0)

    # یک نمودار ستونی خوشه‌ای به اسلاید اضافه کنید.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # ویژگی‌های پیش‌نویس را تنظیم کنید.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # ارائه را بر روی دیسک ذخیره کنید.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم اندازهٔ قلم پیش‌نویس**

Aspose.Slides for Python via Java به شما اجازه می‌دهد اندازهٔ قلم پیش‌نویس را تنظیم کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. نمودار پیش‌فرض را ایجاد کنید.
1. اندازهٔ قلم را تنظیم کنید.
1. حداقل مقدار محورها را تنظیم کنید.
1. حداکثر مقدار محورها را تنظیم کنید.
1. ارائه را بر روی دیسک ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# یک ارائهٔ خالی ایجاد کنید.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم اندازهٔ قلم یک ورودی پیش‌نویس منفرد**

Aspose.Slides for Python via Java به شما اجازه می‌دهد اندازهٔ قلم ورودی‌های منفرد پیش‌نویس را تنظیم کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. نمودار پیش‌فرض را ایجاد کنید.
1. به یک ورودی پیش‌نویس دسترسی پیدا کنید.
1. اندازهٔ قلم را تنظیم کنید.
1. ارائه را بر روی دیسک ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# یک ارائهٔ خالی ایجاد کنید.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**آیا می‌توانم پیش‌نویس را طوری فعال کنم که نمودار به‌صورت خودکار برای آن فضا اختصاص دهد به‌جای اینکه آن را روی‌هم بگذارد؟**

بله. از [setOverlay](https://reference.aspose.com/slides/fa/python-java/aspose.slides/legend/#setOverlay) با مقدار `False` استفاده کنید تا حالت غیر‌پوشش فعال شود؛ در این حالت، ناحیهٔ نمودار برای جا دادن پیش‌نویس کوچک می‌شود.

**آیا می‌توانم برچسب‌های چندخطی برای پیش‌نویس ایجاد کنم؟**

بله. برچسب‌های طولانی به‌صورت خودکار وقتی فضا کافی نیست، شکسته می‌شوند؛ خطوط شکستهٔ اجباری از طریق کاراکترهای خط جدید در نام سری پشتیبانی می‌شود.

**چگونه می‌توانم پیش‌نویس را مطابق طرح رنگی تم ارائه تنظیم کنم؟**

رنگ‌ها، پرکردن‌ها یا قلم‌های صریح برای پیش‌نویس یا متن آن تنظیم نکنید. در این صورت، آنها از تم ارث می‌برند و هنگام تغییر طراحی به‌درستی به‌روزرسانی می‌شوند.