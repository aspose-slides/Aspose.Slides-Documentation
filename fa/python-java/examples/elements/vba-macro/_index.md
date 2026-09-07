---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/python-java/examples/elements/vba-macro/
keywords:
- مثال کد
- VBA
- ماکرو
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ماکروهای VBA را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Python از طریق Java اضافه، دسترسی‌یافته و حذف کنید، همراه با مثال‌های کد واضح و عملی."
---
این مقاله نشان می‌دهد که چگونه می‌توان ماکروهای VBA را با استفاده از **Aspose.Slides for Python via Java** اضافه، دسترسی یافت و حذف کرد.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از راه‌اندازی JVM `asposeslides` را ایمپورت می‌کند، سپس پس از راه‌اندازی JVM API را ایمپورت می‌نماید.

## **اضافه کردن ماکرو VBA**

یک ارائه با یک پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **دسترسی به ماکرو VBA**

اولین ماژول را از پروژه VBA بازیابی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **حذف ماکرو VBA**

یک ماژول را از پروژه VBA حذف کنید.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```