---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در پایتون
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 70
url: /fa/python-net/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل کردن شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- پاورپوینت
- PPTX
- ارائه
- پایتون
- Aspose.Slides
description: "نحوه قفل و بازقفل کردن اشکال در ارائه‌های PPTX با Aspose.Slides for Python via .NET را برای محدود کردن انتخاب، حرکت، تغییر اندازه و گروه‌بندی بیاموزید."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides for Python via .NET ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک گردش کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات اشکال می‌تواند به حفظ طرح‌بندی و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات‌های ویرایشی خاصی را بر روی اشکال تک‌تکی محدود کنید.

## **ساختار یک اسلاید**

یک اسلاید ارائه شامل اجزایی مانند اتو‌شکل‌ها، جدول‌ها، اشیای OLE، اشکال گروه‌بندی شده، قاب‌های تصویر، قاب‌های ویدئویی، کانکتورها و سایر عناصری است که برای ساخت یک ارائه استفاده می‌شوند. در Aspose.Slides for Python via .NET، هر عنصر در یک اسلاید توسط شیئی نمایش داده می‌شود که از کلاس [شکل](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ارث می‌برد.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) کلاس پایه برای قفل‌های اشکال است. Aspose.Slides for Python via .NET کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) قفل اتوشکل‌ها.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) قفل اشکال کانکتور.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) قفل اشیای گرافیکی.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) قفل اشکال گروهی.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) قفل قاب‌های تصویر.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

قفل‌های شکل عملیات‌هایی مانند انتخاب، جابجایی و تغییر اندازه اشکال را محدود می‌کنند. این قفل‌ها کل ارائه را غیرقابل ویرایش نمی‌کنند.

### **اعمال حفاظت به اشکال PPTX**

Aspose.Slides for Python via .NET کلاس [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

در این مثال، ویژگی‌های [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/)، [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/)، و [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) برای اتوشکل‌ها به مقدار `True` تنظیم می‌شوند، و قفل‌های معادل برای اشکال گروهی، کانکتورها و قاب‌های تصویر اعمال می‌شود. برای جابجایی، کانکتورها از [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) استفاده می‌کنند؛ گروه‌ها نیز از [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) برای محدود کردن گروه‌بندی استفاده می‌کنند.

این مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی می‌کند و نسخه‌ای با این محدودیت‌ها ذخیره می‌نماید. اشکالی که خارج از چهار نوع پشتیبانی‌شده هستند بدون تغییر می‌مانند. این حلقه به اشکال فرزند داخل یک گروه پیمایش نمی‌کند.

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

برای حذف یک قفل شکل، مقدار آن را به `False` تنظیم کنید. مثال زیر یک ارائه همراه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) پاک می‌نماید. همچنین [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) را پاک می‌کند و نسخه‌ای از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل بدون تغییر می‌مانند.

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

### **نتیجه‌گیری**

Aspose.Slides for Python via .NET به شما امکان می‌دهد عملیات‌های ویرایشی خاص را بر روی اشکال تک‌تکی محدود کنید یا همان محدودیت‌ها را در سراسر اسلایدها اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `False` تنظیم کنید هنگامی که نیاز به حذف این محدودیت‌ها دارید.

## **پرسش‌های متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات‌های ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/python-net/password-protected-presentation/) می‌تواند باز کردن یا ویرایش ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را در اسلایدهای خاص بدون تأثیر بر دیگر اسلایدها محدود کنم؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخاب شده اعمال کنید. این کار تنظیمات قفل در سایر اسلایدها را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال تک‌تکی داخل یک گروه اعمال کنم؟**

مجموعه [اشکال](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) گروه را پیمایش کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا تنها مجموعه اشکال اسلاید را پردازش می‌کنند، بنابراین قفل‌هایی روی اعضای تک‌تک گروه تنظیم نمی‌شوند.