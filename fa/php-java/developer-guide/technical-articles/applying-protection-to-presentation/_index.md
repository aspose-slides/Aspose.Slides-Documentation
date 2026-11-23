---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در PHP
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/php-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت در برابر ویرایش
- قفل کردن شکل
- قفل کردن موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌ها را در ارائه‌های PPTX با Aspose.Slides برای PHP از طریق Java قفل و بازقفل کنید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **بررسی کلی**

یک استفاده رایج از Aspose.Slides برای PHP از طریق Java، ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ چیدمان و محتوای موردنظر کمک کند.

این مقاله توضیح می‌دهد که شکل‌ها چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات‌های ویرایشی خاصی را بر روی شکل‌های منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزائی مانند اشکال خودکار، جدول‌ها، اشیای OLE، شکل‌های گروهی، قاب‌های تصویر، قاب‌های ویدئو، کانکتورها و عناصر دیگر برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides برای PHP از طریق Java، هر عنصر در یک اسلاید توسط شیئی که از کلاس [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) ارث‌بری می‌کند، نمایندگی می‌شود.

انواع مختلف شکل‌ها گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) پایهٔ قفل‌های شکل است. Aspose.Slides برای PHP از طریق Java کلاس‌های قفل زیر را فراهم می‌کند:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) قفل‌های اشکال خودکار را اعمال می‌کند.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) قفل‌های اشکال کانکتور را اعمال می‌کند.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) قفل‌های اشیای گرافیکی را اعمال می‌کند.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) قفل‌های شکل‌های گروهی را اعمال می‌کند.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) قفل‌های قاب‌های تصویر را اعمال می‌کند.  

برای اعمال قفل‌ها روی یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای ارائه سازگار از قفل‌های شکل برای محدود کردن عملیات‌های ویرایشی فردی استفاده می‌کنند. رمزگذاری فایل و حفاظت نوشتاری در سطح سند تنظیمات جداگانهٔ [تنظیمات حفاظت ارائه](/slides/fa/php-java/password-protected-presentation/) دارند.

### **اعمال حفاظت بر شکل‌های PPTX**

Aspose.Slides برای PHP از طریق Java کلاس [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) را برای کار با شکل‌ها در یک اسلاید فراهم می‌کند.

در مثال، متدهای [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) با مقدار `true` برای اشکال خودکار فراخوانی می‌شوند؛ قفل‌های معادل برای شکل‌های گروهی، کانکتورها و قاب‌های تصویر نیز اعمال می‌شوند. کانکتورها از [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) برای حرکت استفاده می‌کنند؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی بهره می‌برند.

مثال یک ارائه PPTX موجود را بارگیری می‌کند، شکل‌های موجود در مجموعهٔ شکل‌های هر اسلاید را بررسی می‌کند و یک نسخهٔ کپی با این محدودیت‌ها ذخیره می‌شود. شکل‌هایی که در چهار نوع پردازش‌شده قرار ندارند، بدون تغییر باقی می‌مانند. حلقه به شکل‌های فرزند داخل یک گروه پیمایش نمی‌کند.

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

### **حذف حفاظت**

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل بارگیری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) پاک‌سازی می‌کند. همچنین با ارسال `false` به [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) محدودیت گروه‌بندی را حذف می‌کند و یک نسخهٔ کپی از ارائه را ذخیره می‌نماید. سایر تنظیمات قفل بدون تغییر می‌مانند.

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

### **حفظ برش تصویر**

یک فایلی به نام `photo.jpg` در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) را بر روی قفل قاب تصویر فراخوانی می‌کند. ارسال مقدار `true` برش‌های بعدی را محدود کرده و برش موجود را حفظ می‌کند.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

فایل `PictureLocked.pptx` قفل برش را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** زمانی که تصویر انتخاب شده باشد غیرفعال می‌شود.

### **نگه‌داشتن یک نمودار به صورت گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) را بر روی قفل گروه فراخوانی می‌کند تا اجزای نمودار با هم باقی بمانند. ویرایش‌های دیگری مانند جابه‌جایی گروه یا تغییر پر رنگی یک مؤلفه، همچنان قابل دسترس هستند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

فایل `DiagramLocked.pptx` قفل جداسازی را به عنوان `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** زمانی که کل نمودار انتخاب شده باشد غیرفعال می‌شود.

### **نتیجه‌گیری**

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد عملیات‌های ویرایشی خاصی را بر روی شکل‌های منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و برای حذف این محدودیت‌ها مقادیر آن‌ها را به `false` تنظیم کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در همان ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات‌های ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/php-java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط بر روی اسلایدهای خاص محدود کنم بدون اینکه بر اسلایدهای دیگر تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی شکل‌های اسلایدهای انتخابی اعمال کنید. این کار تنظیمات قفل را در اسلایدهای دیگر تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی شکل‌های منفرد داخل یک گروه اعمال کنم؟**

مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) گروه برگردانده می‌شود را پیمایش کنید و قفل‌های مناسب را بر روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا فقط مجموعهٔ شکل‌های اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای فردی گروه تنظیم نمی‌کنند.