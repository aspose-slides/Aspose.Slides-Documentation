---
title: "شی OLE"
type: docs
weight: 210
url: /fa/python-java/examples/elements/ole-object/
keywords:
- "مثال کد"
- "شی OLE"
- "افزودن شی OLE"
- "دسترسی به شی OLE"
- "حذف شی OLE"
- "به‌روزرسانی شی OLE"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Python"
- "Java"
- "Aspose.Slides"
description: "از Aspose.Slides برای Python از طریق Java برای افزودن، دسترسی، حذف و به‌روزرسانی اشیای OLE در ارائه‌های PowerPoint و OpenDocument استفاده کنید."
---
این مقاله نشان می‌دهد چگونه یک فایل را به‌عنوان یک شی OLE جاسازی کنید و داده‌های آن را با استفاده از **Aspose.Slides for Python via Java** به‌روزرسانی کنید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از شروع JVM، `asposeslides` را ایمپورت می‌کند، سپس پس از اجرای JVM، API را ایمپورت می‌کند.

## **افزودن یک شی OLE**

یک فایل PDF را در ارائه جاسازی کنید.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **دسترسی به یک شی OLE**

قاب اول شی OLE را در یک اسلاید بازیابی کنید.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    first_ole_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, OleObjectFrame):
            first_ole_frame = shape
            break

    if first_ole_frame is None:
        print("The slide contains no OLE object frames.")
finally:
    presentation.dispose()
```

## **حذف یک شی OLE**

یک شی OLE جاسازی‌شده را از اسلاید حذف کنید.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpype.JArray(jpype.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **به‌روزرسانی داده‌های شی OLE**

داده‌های جاسازی‌شده در یک شی OLE موجود را جایگزین کنید.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Path("doc.pdf").read_bytes()
    java_pdf_data = jpile.JArray(jpile.JByte)(pdf_data)
    data_info = OleEmbeddedDataInfo(java_pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Path("Picture.png").read_bytes()
    java_new_data = jpile.JArray(jpile.JByte)(new_data)
    new_data_info = OleEmbeddedDataInfo(java_new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```