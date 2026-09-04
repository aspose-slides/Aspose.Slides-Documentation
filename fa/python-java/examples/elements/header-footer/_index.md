---
title: سرصفحه و پاورقی
type: docs
weight: 220
url: /fa/python-java/examples/elements/header-footer/
keywords:
- مثال کد
- سرصفحه
- پاورقی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "سرصفحه‌ها و پاورقی‌های اسلاید را با Aspose.Slides برای Python از طریق Java کنترل کنید: تاریخ‌ها، شماره اسلایدها و متن‌های سفارشی را در ارائه‌های PPT، PPTX و ODP اضافه کنید."
---
این مقاله نشان می‌دهد که چگونه با استفاده از **Aspose.Slides for Python via Java** پاورقی‌ها را اضافه کرده و جای‌نگهدارهای تاریخ و زمان را به‌روز کنید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است، نصب کنید. هر مثال قبل از شروع JVM `asposeslides` را وارد می‌کند، سپس پس از اجرا شدن JVM API را وارد می‌نماید.

## **افزودن پاورقی**
متن را به ناحیهٔ پاورقی یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **به‌روزرسانی تاریخ و زمان**
جای‌نگهدار تاریخ و زمان را در یک اسلاید تغییر دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```