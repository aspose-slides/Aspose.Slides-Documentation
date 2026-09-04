---
title: جوش
type: docs
weight: 180
url: /fa/python-java/examples/elements/ink/
keywords:
- مثال کد
- جوش
- دسترسی به جوش
- حذف جوش
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "دسترسی و حذف اشکال جوش در ارائه‌های Aspose.Slides برای Python از طریق Java، شامل فایل‌های PPT, PPTX و ODP."
---
این مقاله مثال‌هایی برای دسترسی به اشکال جوهرافشان موجود و حذف آن‌ها با استفاده از **Aspose.Slides for Python via Java** ارائه می‌دهد.

پکیج را همان‌طور که در [نصب](/slides/fa/python-java/installation/) توضیح داده شده است، نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را وارد می‌کند و پس از اجرای JVM، API را وارد می‌نماید.

{{% alert color="info" title="نکته" %}}
اشکال جوهرافشان نشان‌دهنده ورودی کاربر از دستگاه‌های تخصصی هستند. Aspose.Slides نمی‌تواند خطوط جوهرافشان جدید را به‌صورت برنامه‌نویسی ایجاد کند، اما می‌توانید جوهرافشان موجود را بخوانید و اصلاح کنید.
{{% /alert %}}

## **دسترسی به جوهرافشان**

برچسب‌های اولین اشکال جوهرافشان روی یک اسلاید را بخوانید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # از tag_name بر حسب نیاز استفاده کنید.
finally:
    presentation.dispose()
```

## **حذف جوهرافشان**

اگر یک اشکال جوهرافشان وجود داشته باشد، آن را از اسلاید حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```