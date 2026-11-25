---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در پایتون
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 70
url: /fa/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "بیاموزید چگونه اشکال را در ارائه‌های PPTX با Aspose.Slides برای Python از طریق .NET قفل و بازقفل کنید تا انتخاب، جابجایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides for Python via .NET، ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. زمانی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات روی اشکال می‌تواند به حفظ طرح و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند خودشکل‌ها (autoshapes)، جدول‌ها، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئو، کانکتورها و سایر عناصری که برای ساخت یک ارائه استفاده می‌شوند، ساخته شده است. در Aspose.Slides for Python via .NET، هر عنصر در یک اسلاید توسط شیئی نمایش داده می‌شود که از کلاس [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ارث‌بری می‌کند.

انواع مختلف اشکال گزینه‌های قفل متفاوتی را ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) پایهٔ کلاس‌های قفل شکل است. Aspose.Slides for Python via .NET کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) قفل خودشکل‌ها را فعال می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) قفل اشکال کانکتور را فعال می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) قفل اشیای گرافیکی را فعال می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) قفل اشکال گروهی را فعال می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) قفل فریم‌های تصویر را فعال می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را برای هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف محافظت**

ویرایشگرهای ارائه سازگار از قفل‌های شکل برای محدود کردن عملیات ویرایشی منفرد استفاده می‌کنند. رمزنگاری فایل و حفاظت نوشتن سطح سند تنظیمات جداگانه‌ای از [تنظیمات حفاظت ارائه](/slides/fa/python-net/password-protected-presentation/) هستند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides for Python via .NET کلاس [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

در این مثال، [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)، [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) و [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) برای خودشکل‌ها به مقدار `True` تنظیم می‌شوند، به‌همین‌صورت قفل‌های معادل برای اشکال گروهی، کانکتورها و فریم‌های تصویر نیز اعمال می‌شود. کانکتورها از [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) برای جابجایی استفاده می‌کنند؛ گروه‌ها نیز از [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) برای محدود کردن گروه‌بندی استفاده می‌کنند.

این مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعهٔ شکل هر اسلاید را بررسی می‌کند و یک نسخهٔ کپی با این محدودیت‌ها ذخیره می‌کند. اشکالی که خارج از چهار نوع مدیریت‌شده هستند بدون تغییر باقی می‌مانند. حلقه شکل‌های فرزند داخل یک گروه را پیمایش نمی‌کند.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف حفاظت**

برای حذف قفل یک شکل، مقدار آن را به `False` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، جابجایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) پاک می‌کند. همچنین [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) را پاک می‌کند و یک نسخهٔ کپی از ارائه را ذخیره می نماید. تنظیمات قفل دیگر بدون تغییر می‌مانند.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **حفظ برش تصویر**

یک تصویر به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) را بر روی فریم تصویر تنظیم می‌کند. این پرچم برش‌های آینده را محدود کرده و برش موجود را حفظ می‌کند.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` قفل برش را به عنوان `True` ذخیره می‌کند. در PowerPoint، فرمان **Crop** هنگام انتخاب تصویر غیرفعال است.

### **نگه داشتن یک دیاگرام گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) را بر روی خود گروه تنظیم می‌کند تا اجزای دیاگرام را کنار هم نگه دارد. ویرایش‌های دیگر، مانند جابجایی گروه یا تغییر پر رنگ یک جزء، در دسترس می‌مانند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` قفل جداسازی (ungrouping) را به عنوان `True` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** هنگام انتخاب کل دیاگرام غیرفعال است.

### **گزارش قفل‌های موجود شکل**

برای بررسی یک الگو، آن را باز کنید و شیء قفل هر شکل را بخوانید. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) زمانی که تمام پرچم‌ها بر روی آن شیء غیرفعال باشند `True` و وقتی حداقل یکی فعال باشد `False` است. یک گروه و فرزندان آن دارای اشیای قفل جداگانه هستند، بنابراین حتی اگر گروه قفل نداشته باشد، فرزندان را نیز بررسی کنید.

این مثال جابجایی خودشکل‌ها، فریم‌های تصویر و گروه‌ها را بررسی می‌کند، برش برای تصاویر و جداسازی برای گروه‌ها را بررسی می نماید. پرچم‌های شناسایی‌شده را گزارش می‌کند و انواع اشکالی که بررسی نمی‌شوند را علامت‌گذاری می‌کند.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

فرض کنید اسلاید 1 از `Sample.pptx` شامل یک گروه به نام `Layout` باشد که قفل جداسازی (ungrouping) آن فعال باشد، یک تصویر به نام `Photo` داخل آن که قفل برش آن فعال باشد، و یک مستطیل بدون قفل به نام `Free`. گزارش `Free` را نادیده می‌گیرد و این دو خط را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

گزارش پرچم‌های ویرایشی سطح شکل ذخیره‌شده را می‌خواند بدون اینکه آن‌ها را تغییر دهد یا ارائه را ذخیره کند. حفاظت نوشتن سطح سند تنظیمی جداگانه است و اعمال هر پرچم به ویرایشگر بستگی دارد.

## **نتیجه‌گیری**

Aspose.Slides for Python via .NET به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `False` تنظیم کنید زمانی که نیاز به حذف این محدودیت‌ها دارید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در همان ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/python-net/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط بر روی اسلایدهای خاص محدود کنم بدون اینکه بر سایرین تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای منتخب اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**

مجموعهٔ [اشکال](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) گروه را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید و از مسیر پیمایش در مثال گزارش‌گیری پیروی نمایید.