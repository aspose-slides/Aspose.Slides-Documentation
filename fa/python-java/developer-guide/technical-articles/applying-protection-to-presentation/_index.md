---
title: جلوگیری از ویرایش ارائه با قفل‌های شکل
linktitle: جلوگیری از ویرایش ارائه
type: docs
weight: 60
url: /fa/python-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل شکل
- قفل موقعیت
- قفل انتخاب
- قفل اندازه
- قفل گروه‌بندی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides برای Python از طریق Java، شکل‌ها را در فایل‌های PPT، PPTX و ODP قفل یا باز می‌کند، ارائه‌ها را ایمن می‌سازد در حالی که ویرایش‌های کنترل‌شده و تحویل سریع‌تر را امکان‌پذیر می‌سازد."
---
## **پیش‌زمینه**

استفادهٔ رایج از Aspose.Slides ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های Microsoft PowerPoint (PPTX) به‌عنوان بخشی از یک گردش کار خودکار است. کاربران برنامه‌هایی که Aspose.Slides را به این شکل به کار می‌برند به ارائه‌های تولید شده دسترسی دارند، بنابراین محافظت از آنها در برابر ویرایش یک نگرانی شایع است. مهم است که ارائه‌های به‌صورت خودکار تولید شده فرمت و محتوای اصلی خود را حفظ کنند.

این مقاله توضیح می‌دهد ساختار ارائه‌ها و اسلایدها چگونه است و Aspose.Slides for Python via Java چگونه می‌تواند محافظت را بر روی یک ارائه اعمال کرده و بعدها آن را حذف کند. این به توسعه‌دهندگان روشی برای کنترل نحوهٔ استفاده از ارائه‌هایی که برنامه‌هایشان تولید می‌کند، ارائه می‌دهد.

## **ساختار یک اسلاید**

یک اسلاید ارائه از اجزایی چون شکل‌های خودکار، جدول‌ها، اشیاء OLE، شکل‌های گروهی، فریم‌های تصویر، فریم‌های ویدئویی، کانکتورها و سایر المان‌های مورد استفاده برای ساخت ارائه تشکیل می‌شود. در Aspose.Slides for Python via Java، هر عنصر روی اسلاید توسط یک شیء که از کلاس [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث‌بری می‌کند، نمایش داده می‌شود.

ساختار PPTX پیچیده است، به‌طوری‌که بر خلاف PPT که می‌توان یک قفل کلی برای تمام انواع شکل‌ها استفاده کرد، انواع مختلف شکل‌ها به قفل‌های متفاوتی نیاز دارند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseshapelock/) کلاس قفل‌گذاری عمومی برای PPTX است. انواع قفل‌های زیر در Aspose.Slides for Python via Java برای PPTX پشتیبانی می‌شوند:

- قفل‌گذاری خودکار شکل‌ها توسط [AutoShapeLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshapelock/).  
- قفل‌گذاری شکل‌های کانکتور توسط [ConnectorLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/connectorlock/).  
- قفل‌گذاری اشیاء گرافیکی توسط [GraphicalObjectLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/graphicalobjectlock/).  
- قفل‌گذاری شکل‌های گروهی توسط [GroupShapeLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshapelock/).  
- قفل‌گذاری فریم‌های تصویر توسط [PictureFrameLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframelock/).  

هر عملی که بر تمام اشیاء شکل در یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) انجام شود، بر کل ارائه اعمال می‌گردد.

## **اعمال و حذف محافظت**

اعمال محافظت تضمین می‌کند که یک ارائه قابل ویرایش نیست. این تکنیک مفیدی برای حفاظت از محتوای ارائه است.

### **اعمال محافظت بر شکل‌های PPTX**

Aspose.Slides for Python via Java کلاس [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) را برای کار با شکل‌ها روی اسلاید فراهم می‌کند.

همان‌طور که قبلاً اشاره شد، هر کلاس شکل یک کلاس قفل‑شکل مرتبط برای محافظت دارد. این مقاله بر قفل‌های NoSelect، NoMove و NoResize متمرکز است. این قفل‌ها تضمین می‌کنند که شکل‌ها نمی‌توانند انتخاب (از طریق کلیک ماوس یا روش‌های دیگر) شوند و همچنین نمی‌توانند جابه‌جا یا اندازه‌شان تغییر یابد.

نمونه کدی که در ادامه می‌آید، محافظت را بر تمام انواع شکل در یک ارائه اعمال می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
presentation = Presentation("Sample.pptx")
try:
    # پیمایش همهٔ اسلایدها در ارائه.
    for slide in presentation.getSlides():
        # پیمایش همهٔ شکل‌ها در اسلاید.
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

    # ذخیرهٔ فایل ارائه.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **حذف محافظت**

برای رفع قفل یک شکل، مقدار قفل اعمال‌شده را به `False` تنظیم کنید. نمونه کد زیر نشان می‌دهد چگونه شکل‌ها در یک ارائهٔ قفل‌شده را باز کنید.

```python
import jpype
import asposeslides

if not jpape.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
presentation = Presentation("ProtectedSample.pptx")
try:
    # پیمایش همهٔ اسلایدهای ارائه.
    for slide in presentation.getSlides():
        # پیمایش تمام شکل‌ها در اسلاید.
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

    # ذخیرهٔ فایل ارائه.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **نتیجه‌گیری**

Aspose.Slides گزینه‌های متعددی برای محافظت از شکل‌ها در یک ارائه ارائه می‌دهد. می‌توانید یک شکل را به‌صورت تک‌تک قفل کنید یا به‌صورت حلقه‌ای بر تمام شکل‌های یک ارائه عبور کنید و هر کدام را قفل کنید تا به‌طور مؤثری کل فایل را ایمن کنید. می‌توانید محافظت را با تنظیم مقدار قفل به `False` حذف کنید.

## **سؤالات متداول**

**آیا می‌توانم قفل‌های شکل و محافظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌ها محدودیت ویرایش اشیاء داخل فایل را اعمال می‌کنند، در حالی که [password protection](/slides/fa/python-java/password-protected-presentation/) دسترسی به باز کردن و/یا ذخیرهٔ تغییرات را کنترل می‌کند. این مکانیزم‌ها یکدیگر را تکمیل می‌کنند و هم‌زمان کار می‌کنند.

**آیا می‌توانم ویرایش را روی اسلایدهای خاص محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را بر شکل‌های اسلایدهای منتخب اعمال کنید؛ اسلایدهای باقی‌مانده قابل ویرایش خواهند ماند.

**آیا قفل‌های شکل برای اشیاء گروهی و کانکتورها نیز اعمال می‌شوند؟**

بله. انواع قفل‌های اختصاصی برای گروه‌ها، کانکتورها، اشیاء گرافیکی و سایر انواع شکل‌ها پشتیبانی می‌شود.