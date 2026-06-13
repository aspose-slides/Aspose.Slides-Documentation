---
title: "جلوگیری از ویرایش ارائه با قفل‌های شکل در پایتون"
linktitle: "جلوگیری از ویرایش ارائه"
type: docs
weight: 70
url: /fa/python-net/applying-protection-to-presentation/
keywords:
- "جلوگیری از ویرایش"
- "محافظت در برابر ویرایش"
- "قفل شکل"
- "قفل موقعیت"
- "قفل انتخاب"
- "قفل اندازه"
- "قفل گروه‌بندی"
- PowerPoint
- OpenDocument
- "ارائه"
- Python
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides برای پایتون از طریق .NET، شکل‌ها را در فایل‌های PPT، PPTX و ODP قفل یا بازقفل می‌کند، ارائه‌ها را ایمن می‌سازد در حالی که ویرایش‌های کنترل‌شده و تحویل سریعتر را امکان‌پذیر می‌سازد."
---
## **پیش‌زمینه**

یک کاربرد رایج Aspose.Slides ایجاد، به‌روزرسانی و ذخیره ارائه‌های Microsoft PowerPoint (PPTX) به عنوان بخشی از یک گردش کار خودکار است. کاربران برنامه‌هایی که Aspose.Slides را به این شکل به کار می‌برند به ارائه‌های تولید شده دسترسی دارند، بنابراین محافظت از آنها در برابر ویرایش یک نگرانی معمول است. مهم است که ارائه‌های به‌طور خودکار تولید شده قالب‌بندی و محتوای اصلی خود را حفظ کنند.

این مقاله توضیح می‌دهد که ارائه‌ها و اسلایدها چگونه ساختاربندی می‌شوند و Aspose.Slides for Python چگونه می‌تواند محافظت را به یک ارائه اعمال کرده و بعداً آن را حذف کند. این به توسعه‌دهندگان روشی برای کنترل نحوه استفاده از ارائه‌هایی که برنامه‌هایشان تولید می‌کنند، ارائه می‌دهد.

## **ترکیب اسلاید**

یک اسلاید ارائه شامل اجزائی مانند autoshapes، جدول‌ها، اشیاء OLE، شکل‌های گروه‌بندی‌شده، فریم‌های تصویر، فریم‌های ویدئو، کانکتورها و سایر عناصری است که برای ساخت یک ارائه استفاده می‌شوند. در Aspose.Slides for Python، هر عنصر در یک اسلاید توسط آبجکتی که از کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) ارث‌بری می‌کند، نمایان می‌شود.

ساختار PPTX پیچیده است، به‌طوری‌که بر خلاف PPT که می‌توان از یک قفل عمومی برای تمام انواع شکل‌ها استفاده کرد، انواع مختلف شکل‌ها به قفل‌های متفاوتی نیاز دارند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseshapelock/) کلاس قفل‌گذاری عمومی برای PPTX است. انواع قفل‌های زیر در Aspose.Slides for Python برای PPTX پشتیبانی می‌شوند:

- [AutoShapeLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshapelock/) قفل autoshapes را اعمال می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/connectorlock/) قفل connector shapes را اعمال می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/graphicalobjectlock/) قفل graphic objects را اعمال می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshapelock/) قفل group shapes را اعمال می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframelock/) قفل picture frames را اعمال می‌کند.  

هر عملی که بر روی تمام اشیاء shape در یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) انجام شود، بر کل ارائه اعمال می‌شود.

## **اعمال و حذف محافظت**

اعمال محافظت اطمینان می‌دهد که یک ارائه نمی‌تواند ویرایش شود. این یک تکنیک مفید برای محافظت از محتوای ارائه است.

### **اعمال محافظت بر شکل‌های PPTX**

Aspose.Slides for Python کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را برای کار با شکل‌ها در یک اسلاید فراهم می‌کند.

همان‌طور که پیش‌تر اشاره شد، هر کلاس shape یک کلاس shape‑lock مرتبط برای محافظت دارد. این مقاله بر قفل‌های NoSelect، NoMove و NoResize متمرکز است. این قفل‌ها اطمینان می‌دهند که شکل‌ها نمی‌توانند انتخاب شوند (از طریق کلیک ماوس یا روش‌های دیگر انتخاب) و نمی‌توانند جابجا یا اندازه‌شان تغییر یابد.

نمونه کد زیر محافظت را بر روی تمام انواع shapeها در یک ارائه اعمال می‌کند.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
with slides.Presentation("Sample.pptx") as presentation:
    # پیمایش تمام اسلایدهای موجود در ارائه.
    for slide in presentation.slides:
        # پیمایش تمام شکل‌ها در اسلاید.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # ذخیره کردن فایل ارائه.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **حذف محافظت**

برای باز کردن قفل یک shape، مقدار قفل اعمال‌شده را به `False` تنظیم کنید. نمونه کد زیر نشان می‌دهد چطور shapeها را در یک ارائهٔ قفل‌شده باز کنید.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # پیمایش تمام اسلایدهای موجود در ارائه.
    for slide in presentation.slides:
        # پیمایش تمام شکل‌ها در اسلاید.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # ذخیره کردن فایل ارائه.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **نتیجه‌گیری**

Aspose.Slides چند گزینه برای محافظت از shapeها در یک ارائه ارائه می‌دهد. می‌توانید یک shape جداگانه را قفل کنید یا بر تمام shapeهای یک ارائه پیمایش کنید و هر یک را قفل کنید تا به‌طور مؤثر کل فایل را ایمن کنید. می‌توانید با تنظیم مقدار قفل به `False` محافظت را حذف کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های shape و محافظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌ها محدودیت ویرایش اشیاء داخل فایل را اعمال می‌کنند، در حالی که [password protection](/slides/fa/python-net/password-protected-presentation/) دسترسی به باز کردن و/یا ذخیرهٔ تغییرات را کنترل می‌کند. این مکانیزم‌ها یکدیگر را تکمیل می‌کنند و همراه هم کار می‌کنند.

**آیا می‌توانم ویرایش را در اسلایدهای خاص محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را بر روی shapeهای اسلایدهای انتخاب‌شده اعمال کنید؛ اسلایدهای باقی‌مانده قابل ویرایش باقی می‌مانند.

**آیا قفل‌های shape بر روی اشیاء گروه‌بندی‌شده و کانکتورها اعمال می‌شود؟**

بله. انواع قفل‌های مخصوص برای گروه‌ها، کانکتورها، اشیاء گرافیکی و سایر انواع shapeها پشتیبانی می‌شوند.