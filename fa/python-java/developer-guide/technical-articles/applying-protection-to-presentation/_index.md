---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در پایتون
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/python-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت از ویرایش
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
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای پایتون از طریق جاوا، شکل‌ها را در ارائه‌های PPTX قفل و بازقفل کنید تا انتخاب، جابه‌جایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides برای Python از طریق Java ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. زمانی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ طرح و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که چگونه شکل‌ها در اسلایدها سازماندهی می‌شوند و چگونه قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را روی شکل‌های منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند خودشکل‌ها، جداول، اشیاء OLE، شکل‌های گروه‌بندی‌شده، فریم‌های تصویر، فریم‌های ویدیو، کانکتورها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides برای Python از طریق Java، هر عنصر در یک اسلاید توسط شیئی که از کلاس [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ارث‌بری می‌کند، نمایان می‌شود.

انواع مختلف شکل‌ها گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) کلاس پایه برای قفل‌های شکل است. Aspose.Slides برای Python از طریق Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) قفل خودشکل‌ها.
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) قفل شکل‌های کانکتور.
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) قفل اشیاء گرافیکی.
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) قفل شکل‌های گروهی.
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) قفل فریم‌های تصویر.

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

قفل‌های شکل عملیات‌هایی مانند انتخاب، جابه‌جایی و تغییر اندازه شکل‌ها را محدود می‌کنند. این قفل‌ها کل ارائه را غیرقابل ویرایش نمی‌سازند.

### **اعمال حفاظت بر روی شکل‌های PPTX**

Aspose.Slides برای Python از طریق Java کلاس [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) را برای کار با شکل‌ها در یک اسلاید فراهم می‌کند.

در مثال، متدهای [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) با مقدار `True` برای خودشکل‌ها فراخوانی می‌شوند، و قفل‌های معادل برای شکل‌های گروهی، کانکتورها و فریم‌های تصویر اعمال می‌شود. کانکتورها برای جابه‌جایی از [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) استفاده می‌کنند؛ گروه‌ها همچنین از [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی استفاده می‌کنند.

در مثال، یک ارائه PPTX موجود بارگذاری می‌شود، شکل‌ها در مجموعه شکل هر اسلاید بررسی می‌شوند و یک نسخه با این محدودیت‌ها ذخیره می‌شود. شکل‌هایی که خارج از چهار نوع پردازش‌شده هستند بدون تغییر می‌مانند. حلقه به شکل‌های فرزند داخل یک گروه وارد نمی‌شود.

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

برای حذف یک قفل شکل، مقدار آن را به `False` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) پاک می‌کند. همچنین محدودیت گروه‌بندی را با ارسال `False` به [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) حذف می‌کند و یک نسخه از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل بدون تغییر می‌مانند.

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

### **نتیجه‌گیری**

Aspose.Slides برای Python از طریق Java به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی شکل‌های منفرد محدود کنید یا همان محدودیت‌ها را در سراسر اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و هنگام نیاز به حذف این محدودیت‌ها، مقدار آن‌ها را به `False` تنظیم کنید.

## **پرسش‌های متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/python-java/password-protected-presentation/) می‌تواند باز کردن یا ویرایش ارائه را محدود کند. شما می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را در اسلایدهای خاص محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی شکل‌های اسلایدهای انتخابی اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی شکل‌های منفرد داخل یک گروه اعمال کنم؟**

مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) گروه برگردانده می‌شود را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا فقط مجموعه شکل‌های اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای منفرد گروه اعمال نمی‌کنند.