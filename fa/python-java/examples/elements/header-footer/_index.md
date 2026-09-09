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
description: "کنترل سرصفحه‌ها و پاورقی‌های اسلاید با Aspose.Slides برای Python از طریق Java: افزودن تاریخ‌ها، شماره اسلایدها و متن سفارشی در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه پاورقی‌ها را اضافه کنید و جای‌نگهدارهای تاریخ و زمان را با استفاده از **Aspose.Slides for Python via Java** به‌روزرسانی کنید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را وارد می‌کند و سپس پس از اجرای JVM، API را وارد می‌نماید.

## **Add a Footer**

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

## **Update Date and Time**

جای‌نگهدار تاریخ و زمان را در یک اسلاید اصلاح کنید.

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