---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در پایتون
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/python-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش‌ها
- حفاظت در برابر ویرایش
- قفل شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌ها را در ارائه‌های PPTX با Aspose.Slides for Python via Java قفل و بازقفل کنید تا انتخاب، جابجایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پیش‌زمینه**

یک کاربرد رایج Aspose.Slides for Python via Java، ایجاد، به‌روزرسانی و ذخیره‌سازی ارائه‌های PowerPoint (PPTX) به‌عنوان بخشی از یک گردش کار خودکار است. وقتی کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ طرح و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که شکل‌ها چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توانید قفل‌های شکل‌ها را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایش خاصی را بر روی شکل‌های جداگانه محدود کنید.

## **ساختار یک اسلاید**

یک اسلاید ارائه شامل اجزایی مانند اشکال خودکار، جدول‌ها، اشیاء OLE، گروه‌های شکل، قاب‌های تصویر، قاب‌های ویدئو، کانکتورها و سایر عناصر مورد استفاده برای ساخت ارائه است. در Aspose.Slides for Python via Java، هر عنصر روی اسلاید توسط یک شیء که از کلاس [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ارث‌بری می‌کند، نمایش داده می‌شود.

انواع مختلف شکل‌ها گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) پایه‌ای برای قفل‌های شکل است. Aspose.Slides for Python via Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) قفل‌های اشکال خودکار را اعمال می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) قفل‌های کانکتور را اعمال می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) قفل‌های اشیاء گرافیکی را اعمال می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) قفل‌های گروه‌های شکل را اعمال می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) قفل‌های قاب‌های تصویر را اعمال می‌کند.  

برای اعمال قفل‌ها در سرتاسر یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای ارائه سازگار از قفل‌های شکل برای محدود کردن عملیات ویرایشی فردی استفاده می‌کنند. رمزنگاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای تحت عنوان [presentation protection settings](/slides/fa/python-java/password-protected-presentation/) دارند.

### **اعمال حفاظت بر روی اشکال PPTX**

Aspose.Slides for Python via Java کلاس [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) را برای کار با اشکال روی اسلاید فراهم می‌کند.

مثال، متدهای [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) را برای اشکال خودکار با مقدار `True` فراخوانی می‌کند و قفل‌های مساوی را برای گروه‌ها، کانکتورها و قاب‌های تصویر اعمال می‌کند. کانکتورها از [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) برای جابجایی استفاده می‌کنند؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی بهره می‌برند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعهٔ شکل هر اسلاید را بررسی می‌کند و یک نسخهٔ کپی با این محدودیت‌ها ذخیره می‌شود. شکل‌هایی که جزو چهار نوع پردازش‌شده نیستند بدون تغییر باقی می‌مانند. حلقهٔ پیمایش به شکل‌های فرزند داخل یک گروه نمی‌پردازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **حذف حفاظت**

برای حذف قفل یک شکل، مقدار آن را به `False` تنظیم کنید. مثال زیر یک ارائه حاوی قفل‌های شکل را بارگذاری کرده و محدودیت‌های انتخاب، جابجایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) پاک می‌کند. همچنین محدودیت گروه‌بندی را با ارسال `False` به [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) حذف کرده و یک نسخهٔ کپی از ارائه ذخیره می‌شود. سایر تنظیمات قفل دست نخورده می‌مانند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **حفظ برش تصویر**

یک عکس به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس با فراخوانی [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) مقدار `True` را تنظیم می‌کند تا برش حفظ شود.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در فایل `PictureLocked.pptx`، PowerPoint فرمان **Crop** را هنگام انتخاب عکس غیرفعال می‌کند.

### **دست‌ن‌های یک نمودار را گروه‌بندی نگه دارید**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند و سپس با فراخوانی [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) مقدار `True` را تنظیم می‌کند تا دو شکل با هم باقی بمانند. همچنان می‌توانید گروه را جابجا کنید یا رنگ پر جزء را تغییر دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

در فایل `DiagramLocked.pptx`، PowerPoint فرمان **Ungroup** را هنگام انتخاب کل نمودار غیرفعال می‌کند.

### **گزارش قفل‌های شکل موجود**

برای بررسی یک الگو، آن را باز کنید و شیء قفل هر شکل را بخوانید. متد [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) زمانی که همه پرچم‌های آن شیء غیرفعال باشند مقدار `True` و در غیر این صورت مقدار `False` برمی‌گرداند. یک گروه و فرزندان آن اشیاء قفل جداگانه‌ای داشته‌اند، بنابراین حتی اگر گروه قفل نداشته باشد، باید فرزندان را نیز بررسی کنید.

این مثال حرکت اشکال خودکار، قاب‌های تصویر و گروه‌ها را بررسی می‌کند. همچنین برش تصاویر و رفع گروه‌بندی برای گروه‌ها را چک می‌کند. گزارش پرچم‌های فعال شناسایی‌شده را فهرست می‌کند و انواع شکل‌هایی که بررسی نمی‌کند را علامت‌گذاری می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

فرض کنید اسلاید 1 از `Sample.pptx` شامل یک گروه به نام `Layout` باشد که رفع گروه‌بندی قفل‌گذاری شده است، تصویری به نام `Photo` داخل آن با برش قفل‌گذاری شده داشته باشد و یک مستطیل بدون قفل به نام `Free` داشته باشد. گزارش `Free` را نادیده می‌گیرد و دو خط زیر را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

گزارش پرچم‌های ویرایشی سطح شکل ذخیره‌شده را می‌خواند بدون اینکه آنها را تغییر دهد یا ارائه را ذخیره کند. حفاظت نوشتن در سطح سند تنظیم جداگانه‌ای است و اعمال هر پرچم به ویرایشگر بستگی دارد.

### **نتیجه‌گیری**

Aspose.Slides for Python via Java به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی اشکال جداگانه محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و برای حذف این محدودیت‌ها مقدار آنها را به `False` تنظیم کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [password protection](/slides/fa/python-java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط بر روی اسلایدهای خاصی محدود کنم بدون اینکه به دیگران اثر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخابی اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال جداگانه داخل یک گروه اعمال کنم؟**

مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) گروه برگردانده می‌شود را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید، همان‌طور که در مثال گزارش‌گیری نشان داده شده است.