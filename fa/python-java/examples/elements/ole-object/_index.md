---
title: شیء OLE
type: docs
weight: 210
url: /fa/python-java/examples/elements/ole-object/
keywords:
- نمونه کد
- شیء OLE
- افزودن شیء OLE
- دسترسی به شیء OLE
- حذف شیء OLE
- به‌روزرسانی شیء OLE
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "از Aspose.Slides for Python via Java برای افزودن، دسترسی، حذف و به‌روزرسانی شیء OLE در ارائه‌های PowerPoint و OpenDocument استفاده کنید."
---
این مقاله نحوه جاسازی یک فایل به‌عنوان شیء OLE و به‌روزرسانی داده‌های آن را با استفاده از **Aspose.Slides for Python via Java** نشان می‌دهد.

پکیج را همان‌طور که در بخش [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را ایمپورت می‌کند و سپس پس از اجرا شدن JVM، API را ایمپورت می‌نماید.

## **افزودن یک شیء OLE**
یک فایل PDF را در ارائه جاسازی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **دسترسی به شیء OLE**
قاب اولین شیء OLE را در یک اسلاید بازیابی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
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

## **حذف یک شیء OLE**
یک شیء OLE جاسازی‌شده را از اسلاید حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **به‌روزرسانی داده‌های شیء OLE**
داده‌های جاسازی‌شده در یک شیء OLE موجود را جایگزین کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Files.readAllBytes(Paths.get("Picture.png"))
    new_data_info = OleEmbeddedDataInfo(new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```