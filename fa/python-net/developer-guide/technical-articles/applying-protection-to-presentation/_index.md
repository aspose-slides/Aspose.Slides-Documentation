---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در پایتون
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 70
url: /fa/python-net/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- پاورپوینت
- PPTX
- ارائه
- پایتون
- Aspose.Slides
description: "چگونگی قفل و باز قفل کردن اشکال در ارائه‌های PPTX با Aspose.Slides برای پایتون از طریق .NET برای محدود کردن انتخاب، حرکت، تغییر اندازه و گروه‌بندی را بیاموزید."
---
## **پیش‌زمینه**

یک مورد استفاده رایج برای Aspose.Slides for Python via .NET، ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. وقتی کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ طرح و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که چگونه اشکال در اسلایدها سازماندهی می‌شوند و چگونه قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزائی مانند اشکال خودکار، جداول، اشیاء OLE، اشکال گروه‌بندی شده، فریم‌های تصویر، فریم‌های ویدئویی، کانکتورها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides for Python via .NET، هر عنصر در یک اسلاید توسط شیئی نماینده می‌شود که از کلاس [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ارث‌بری می‌کند.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) کلاس پایه برای قفل‌های اشکال است. Aspose.Slides for Python via .NET کلاس‌های قفل زیر را فراهم می‌کند:
- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) اشکال خودکار را قفل می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) اشکال کانکتور را قفل می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) اشیاء گرافیکی را قفل می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) اشکال گروهی را قفل می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) فریم‌های تصویر را قفل می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، اسلایدهای آن را مرور کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای ارائه سازگار از قفل‌های شکل برای محدود کردن عملیات ویرایشی منفرد استفاده می‌کنند. رمزنگاری فایل و محافظت نوشتاری در سطح سند تنظیمات [تنظیمات محافظت ارائه](/slides/fa/python-net/password-protected-presentation/) جداگانه‌ای هستند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides for Python via .NET کلاس [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) را برای کار با اشکال روی یک اسلاید فراهم می‌کند.

در این مثال، برای اشکال خودکار ویژگی‌های [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)، [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) و [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) به مقدار `True` تنظیم می‌شوند، و قفل‌های معادل برای اشکال گروهی، کانکتورها و فریم‌های تصویر نیز اعمال می‌شود. کانکتورها برای جابه‌جایی از [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) استفاده می‌کنند؛ گروه‌ها همچنین از [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) برای محدود کردن گروه‌بندی استفاده می‌کنند.

این مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی کرده و یک نسخه با این محدودیت‌ها ذخیره می‌کند. اشکالی که از چهار نوع قابل‌پردازش خارج هستند، دست‌نخورده می‌مانند. حلقه داخل اشکال فرزند یک گروه را مرور نمی‌کند.

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

برای حذف یک قفل شکل، مقدار آن را به `False` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) پاک می‌کند. همچنین [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) را پاک کرده و یک نسخه از ارائه را ذخیره می‌کند. سایر تنظیمات قفل دست‌نخورده می‌مانند.

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

عکس با نام `photo.jpg` را در پوشه کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) را بر روی فریم تصویر تنظیم می‌کند تا برش حفظ شود.

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

`PictureLocked.pptx` قفل برش را به عنوان `True` ذخیره می‌کند. در PowerPoint، فرمان **Crop** زمانی که عکس انتخاب شده باشد غیرفعال است.

### **نگه داشتن نمودار به صورت گروهی**

این مثال یک مستطیل و یک پیکان را گروهبندی می‌کند، سپس [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) را بر روی خود گروه تنظیم می‌کند تا اجزای نمودار با هم باقی بمانند. ویرایش‌های دیگر، مانند جابه‌جایی گروه یا تغییر پرکردگی یک جزء، همچنان در دسترس هستند.

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

`DiagramLocked.pptx` قفل جداسازی (Ungrouping) را به عنوان `True` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** زمانی که تمام نمودار انتخاب شده باشد غیرفعال است.

### **نتیجه‌گیری**

Aspose.Slides for Python via .NET به شما اجازه می‌دهد عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر تمام اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `False` تنظیم کنید وقتی می‌خواهید آن محدودیت‌ها را حذف کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/python-net/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش در اسلایدهای خاص را بدون تأثیر بر سایرین محدود کنم؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**

در مجموعهٔ [اشکال](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) گروه پیمایش کنید و قفل‌های مناسب را بر روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا فقط مجموعهٔ اشکال اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای فردی گروه تنظیم نمی‌کنند.