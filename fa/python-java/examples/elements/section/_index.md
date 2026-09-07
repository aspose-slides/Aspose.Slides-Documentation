---
title: بخش
type: docs
weight: 90
url: /fa/python-java/examples/elements/section/
keywords:
- مثال کد
- بخش
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "مدیریت بخش‌های ارائه در Aspose.Slides برای Python از طریق Java: افزودن، دسترسی، حذف و تغییر نام بخش‌ها با مثال‌های کد پایتون."
---
نمونه‌هایی برای مدیریت بخش‌های ارائه—اضافه کردن، دسترسی، حذف و تغییر نام آن‌ها به‌صورت برنامه‌نویسی با استفاده از **Aspose.Slides for Python via Java**.

پکیج را همانطور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال قبل از شروع JVM `asposeslides` را ایمپورت می‌کند، سپس پس از اجرای JVM API را ایمپورت می‌کند.

## **افزودن یک بخش**

یک بخش ایجاد کنید که از اسلاید خاصی شروع می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # اسلایدی که آغاز بخش را نشان می‌دهد.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **دسترسی به یک بخش**

اطلاعات بخش را از یک ارائه بخوانید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # دسترسی به بخش بر اساس ایندکس.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **حذف یک بخش**

یک بخش که قبلاً اضافه شده است را حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # حذف اولین بخش.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **تغییر نام یک بخش**

نام یک بخش موجود را تغییر دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```