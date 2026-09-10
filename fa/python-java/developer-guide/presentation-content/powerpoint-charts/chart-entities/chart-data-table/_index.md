---
title: سفارشی‌سازی جداول داده نمودار در ارائه‌ها با استفاده از پایتون
linktitle: جدول داده
type: docs
url: /fa/python-java/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "جداول داده نمودار را در پایتون برای PPT و PPTX با Aspose.Slides برای پایتون از طریق جاوا سفارشی کنید تا کارایی و جذابیت ارائه‌ها را افزایش دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با جداول داده‌های نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه یک جدول داده برای یک نمودار نمایش داده شود و قالب‌بندی متن آن را با تنظیم ویژگی‌های قلم مانند حالت بولد و ارتفاع قلم سفارشی کنید. مثال ایجاد یک ارائه، افزودن یک نمودار، فعال‌سازی جدول داده‌های نمودار، اعمال تنظیمات قلم و ذخیره‌سازی ارائه بروز شده را نشان می‌دهد.

همچنین شامل پاسخ‌های مختصری به سؤالات رایج درباره نمایش کلیدهای افسانه در جدول داده نمودار، حفظ جدول داده هنگام خروجی گرفتن، کار با نمودارهای بارگذاری‌شده از ارائه‌ها یا قالب‌های موجود، و شناسایی نمودارهایی که جدول داده در آن فعال است، می‌باشد.

## **تنظیم ویژگی‌های قلم برای جدول داده‌های نمودار**

Aspose.Slides for Python via Java به شما اجازه می‌دهد جدول داده یک نمودار را نشان دهید و ویژگی‌های قلم متن آن را تغییر دهید.

1. یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
1. یک نمودار به اسلاید اضافه کنید.  
1. جدول داده‌های نمودار را نمایش دهید.  
1. سبک بولد و ارتفاع قلم متن جدول داده را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر این مراحل را نشان می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# یک ارائه خالی ایجاد کنید.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**آیا می‌توانم کلیدهای افسانه کوچک را در کنار مقادیر در جدول داده نمودار نمایش دهم؟**

بله. جدول داده از [کلیدهای افسانه](https://reference.aspose.com/slides/fa/python-java/aspose.slides/datatable/#setShowLegendKey) پشتیبانی می‌کند و می‌توانید آنها را روشن یا خاموش کنید.

**آیا جدول داده هنگام خروجی گرفتن ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**

بله. Aspose.Slides نمودار را به عنوان بخشی از اسلاید رندر می‌کند، بنابراین [PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/fa/python-java/convert-powerpoint-to-html/)/[image](/slides/fa/python-java/convert-powerpoint-to-png/) خروجی شامل نمودار با جدول داده آن می‌شود.

**آیا جداول داده برای نمودارهایی که از یک فایل قالب بارگذاری می‌شوند، پشتیبانی می‌شوند؟**

بله. برای هر نموداری که از یک ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از ویژگی‌های نمودار بررسی و تغییر دهید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#hasDataTable) یا خیر.

**چگونه می‌توانم به‌سرعت تشخیص دهم کدام نمودارها در یک فایل جدول داده فعال دارند؟**

ویژگی هر نمودار که نشان می‌دهد جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#hasDataTable) را بررسی کنید و در اسلایدها مرور کنید تا نمودارهایی که این ویژگی فعال است شناسایی شوند.