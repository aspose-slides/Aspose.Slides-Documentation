---
title: ActiveX
type: docs
weight: 200
url: /fa/python-java/examples/elements/activex/
keywords:
- نمونه کد
- ActiveX
- کنترل ActiveX
- ویژگی‌های ActiveX
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "از Aspose.Slides برای Python از طریق Java برای افزودن، دسترسی، حذف و پیکربندی کنترل‌های ActiveX در ارائه‌های PowerPoint با نمونه‌های کد عملی استفاده کنید."
---
این مقاله نحوه افزودن، دسترسی، حذف و پیکربندی کنترل‌های ActiveX در یک ارائه را با استفاده از **Aspose.Slides for Python via Java** نشان می‌دهد.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از شروع JVM، `asposeslides` را ایمپورت می‌کند و سپس پس از راه‌اندازی JVM، API را ایمپورت می‌کند. مثال‌های دسترسی و حذف از `add_activex.pptm` استفاده می‌کنند که توسط اولین مثال ایجاد شده است.

## **افزودن یک کنترل ActiveX**

یک کنترل Windows Media Player را در اسلاید اول قرار داده و ارائه را به صورت فایل PPTM ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # یک کنترل Windows Media Player اضافه کنید.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **دسترسی به یک کنترل ActiveX**

نام و تنظیم پخش خودکار اولین کنترل ActiveX روی اسلاید را بخوانید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # دسترسی به اولین کنترل ActiveX.
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **حذف یک کنترل ActiveX**

اولین کنترل ActiveX را از اسلاید حذف کنید و ارائهٔ تغییر یافته را ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # حذف اولین کنترل ActiveX.
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **تنظیم خصوصیات ActiveX**

یک کنترل Windows Media Player اضافه کنید، پخش خودکار را غیرفعال کنید و کنترل‌های پخش آن را مخفی کنید. برای مقداردهی به خصوصیات به عنوان رشته، از [ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/fa/python-java/aspose.slides/controlpropertiescollection/#set_Item) استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # یک کنترل Windows Media Player اضافه کنید و ویژگی‌های آن را پیکربندی کنید.
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```