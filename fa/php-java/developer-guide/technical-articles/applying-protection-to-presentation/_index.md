---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در PHP
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/php-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل کردن شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- PHP
- Aspose.Slides
description: "نحوه قفل و بازقفل کردن شکل‌ها در ارائه‌های PPTX با Aspose.Slides برای PHP از طریق Java را برای محدود کردن انتخاب، جابه‌جایی، تغییر اندازه و گروه‌بندی بیاموزید."
---
## **مرور کلی**

یک استفاده رایج از Aspose.Slides برای PHP از طریق Java ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به‌عنوان بخشی از یک جریان کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ چیدمان و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که شکل‌ها چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما اجازه می‌دهند عملیات ویرایشی خاصی را بر روی هر شکل به‌طور جداگانه محدود کنید.

## **ترکیب اسلاید**

یک اسلاید ارائه از اجزایی مانند اشکال خودکار، جدول‌ها، اشیاء OLE، گروه‌های شکل، قاب‌های تصویر، قاب‌های ویدئو، اتصال‌دهنده‌ها و عناصر دیگر تشکیل شده است. در Aspose.Slides برای PHP از طریق Java، هر عنصر روی اسلاید توسط یک شیء که از کلاس [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) ارث‌بری می‌کند، نمایش داده می‌شود.

انواع مختلف شکل‌ها گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) پایهٔ قفل‌های شکل است. Aspose.Slides برای PHP از طریق Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) قفل‌های اشکال خودکار را اعمال می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) قفل‌های اشکال اتصال‌دهنده را اعمال می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) قفل‌های اشیاء گرافیکی را اعمال می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) قفل‌های گروه‌های شکل را اعمال می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) قفل‌های قاب‌های تصویر را اعمال می‌کند.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، اسلایدهای آن را مرور کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف محافظت**

قفل‌های شکل عملیات‌هایی مانند انتخاب، جابه‌جایی و تغییر اندازهٔ شکل‌ها را محدود می‌کنند. این قفل‌ها کل ارائه را به‌طور کلی غیرقابل ویرایش نمی‌سازند.

### **اعمال محافظت به اشکال PPTX**

Aspose.Slides برای PHP از طریق Java کلاس [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) را برای کار با شکل‌ها روی اسلاید فراهم می‌کند.

مثال متدهای [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) را با مقدار `true` برای اشکال خودکار صدا می‌زند، و قفل‌های معادل برای گروه‌های شکل، اتصال‌دهنده‌ها و قاب‌های تصویر نیز اعمال می‌شوند. برای جابه‌جایی اتصال‌دهنده‌ها از [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) استفاده می‌شود؛ گروه‌ها همچنین از [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائهٔ PPTX موجود را بارگذاری می‌کند، شکل‌ها را در مجموعهٔ شکل‌های هر اسلاید بررسی می‌کند و یک کپی با این محدودیت‌ها ذخیره می‌کند. شکل‌هایی که در چهار نوع مدیریت‌شده نیستند بدون تغییر باقی می‌مانند. حلقه داخل شکل‌های فرزند یک گروه را پیمایش نمی‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **حذف محافظت**

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل بارگذاری می‌کند و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) پاک می‌کند. همچنین محدودیت گروه‌بندی را با ارسال `false` به [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) حذف می‌کند و یک کپی از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل دست‌نخورده می‌مانند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **نتیجه‌گیری**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد عملیات ویرایشی خاصی را بر روی شکل‌های جداگانه محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `false` تنظیم کنید زمانی که نیاز به حذف این محدودیت‌ها دارید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و محافظت با رمز عبور را در همان ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات‌های ویرایشی خاصی را محدود می‌کنند، در حالی که [محافظت با رمز عبور](/slides/fa/php-java/password-protected-presentation/) می‌تواند بازکردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را روی اسلایدهای خاص محدود کنم بدون اینکه بر اسلایدهای دیگر تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی شکل‌های اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در سایر اسلایدها را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی شکل‌های منفرد داخل یک گروه اعمال کنم؟**

در مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) گروه بازگردانده می‌شود، تکرار کنید و قفل‌های مناسب را بر روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو نیز تکرار کنید. مثال‌های بالا فقط مجموعهٔ شکل‌های اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای فردی یک گروه تنظیم نمی‌کنند.