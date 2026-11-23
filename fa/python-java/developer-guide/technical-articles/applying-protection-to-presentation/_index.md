---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در پایتون
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/python-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت در برابر ویرایش
- قفل کردن شکل
- قفل کردن موقعیت
- قفل کردن انتخاب
- قفل کردن تغییر اندازه
- قفل کردن گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌ها را در ارائه‌های PPTX با Aspose.Slides برای Python از طریق Java قفل و بازقفل کنید تا انتخاب، جابه‌جایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پس‌زمینه**

یک کاربرد رایج Aspose.Slides برای Python از طریق Java ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. زمانی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ چیدمان و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که شکل‌ها چطور در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را برای هر شکل به‌صورت جداگانه محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند اشکال خودکار، جدول‌ها، اشیاء OLE، شکل‌های گروهی، فریم‌های تصویر، فریم‌های ویدئو، اتصال‌کننده‌ها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides برای Python از طریق Java، هر عنصر روی یک اسلاید توسط شیئی نمایش داده می‌شود که از کلاس [شکل](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ارث‌بری می‌کند.

انواع مختلف شکل‌ها گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) پایهٔ قفل‌های شکل است. Aspose.Slides برای Python از طریق Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) قفل‌های اشکال خودکار را فعال می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) قفل‌های اتصال‌کننده‌ها را فعال می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) قفل‌های اشیاء گرافیکی را فعال می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) قفل‌های شکل‌های گروهی را فعال می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) قفل‌های فریم‌های تصویر را فعال می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای سازگار ارائه از قفل‌های شکل برای محدود کردن عملیات ویرایشی فردی استفاده می‌کنند. رمزگذاری فایل و حفاظت نوشتن در سطح سند تنظیمات جداگانه‌ای از [تنظیمات حفاظت ارائه](/slides/fa/python-java/password-protected-presentation/) هستند.

### **اعمال حفاظت بر روی شکل‌های PPTX**

Aspose.Slides برای Python از طریق Java کلاس [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) را برای کار با شکل‌ها بر روی اسلاید فراهم می‌کند.

مثال متدهای [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) را با مقدار `True` برای اشکال خودکار فراخوانی می‌کند، با قفل‌های معادل برای گروه‌های شکل، اتصال‌کننده‌ها و فریم‌های تصویر. اتصال‌کننده‌ها از [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) برای جابه‌جایی استفاده می‌کنند؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، شکل‌ها را در مجموعهٔ شکل هر اسلاید بررسی می‌کند و نسخه‌ای با این محدودیت‌ها ذخیره می‌نماید. شکل‌هایی که در چهار نوع پشتیبانی‌شده نیستند بدون تغییر می‌مانند. حلقه به شکل‌های فرزند داخل یک گروه پیمایشی انجام نمی‌دهد.

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

برای حذف یک قفل شکل، مقدار آن را به `False` تنظیم کنید. مثال زیر یک ارائه دارای قفل‌های شکل را بارگذاری کرده و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/), و [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) پاک می‌کند. همچنین با ارسال `False` به [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) محدودیت گروه‌بندی را حذف کرده و نسخه‌ای از ارائه ذخیره می‌شود. سایر تنظیمات قفل دست‌نخورده می‌مانند.

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

یک تصویر به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست برش می‌دهد، سپس [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) را با مقدار `True` فراخوانی می‌کند تا برش حفظ شود.

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

در فایل `PictureLocked.pptx`، PowerPoint فرمان **Crop** را هنگامی که تصویر را انتخاب می‌کنید غیرفعال می‌کند.

### **نگهداری یک نمودار به صورت گروه‌بندی شده**

مثال یک مستطیل و یک فلش را گروه‌بندی می‌کند، سپس [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) را با مقدار `True` فراخوانی می‌کند تا دو شکل با هم بمانند. همچنان می‌توانید گروه را جابه‌جا کنید یا پر رنگ یک مؤلفه را تغییر دهید.

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

در فایل `DiagramLocked.pptx`، PowerPoint فرمان **Ungroup** را هنگامی که کل نمودار را انتخاب می‌کنید غیرفعال می‌کند.

### **نتیجه‌گیری**

Aspose.Slides برای Python از طریق Java به شما اجازه می‌دهد عملیات ویرایشی خاصی را برای هر شکل به‌صورت جداگانه محدود کنید یا همان محدودیت‌ها را بر تمام اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و هنگام نیاز به حذف این محدودیت‌ها مقدار آن‌ها را به `False` تنظیم کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/python-java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود نماید. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط در اسلایدهای خاصی محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی شکل‌های اسلایدهای انتخابی اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی شکل‌های منفرد داخل یک گروه اعمال کنم؟**

مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) گروه بازگردانده می‌شود را پیمایش کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا تنها مجموعهٔ شکل‌های اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر اعضای فردی گروه تنظیم نمی‌کنند.