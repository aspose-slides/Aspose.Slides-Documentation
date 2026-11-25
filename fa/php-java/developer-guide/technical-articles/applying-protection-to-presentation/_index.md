---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در PHP
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 60
url: /fa/php-java/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل‌گذاری شکل
- قفل‌گذاری موقعیت
- قفل‌گذاری انتخاب
- قفل‌گذاری تغییر اندازه
- قفل‌گذاری گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در ارائه‌های PPTX با Aspose.Slides برای PHP از طریق Java قفل و بازقفل کنید تا انتخاب، جابجایی، تغییر اندازه و گروه‌بندی محدود شوند."
---
## **نمای کلی**

یک کاربرد رایج Aspose.Slides برای PHP از طریق Java این است که ارائه‌های PowerPoint (PPTX) را به‌عنوان بخشی از یک جریان کار خودکار ایجاد، به‌روزرسانی و ذخیره کنید. وقتی کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات اشکال می‌تواند به حفظ چیدمان و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چطور قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید.

## **ساختار اسلاید**

یک اسلاید ارائه از اجزائی مانند autoshapes، جداول، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئو، کانکتورها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides برای PHP از طریق Java، هر عنصر در اسلاید توسط شی‌ای که از کلاس [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) ارث می‌گیرد، نمایش داده می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی را فراهم می‌کنند. کلاس [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) کلاس پایه برای قفل‌های اشکال است. Aspose.Slides برای PHP از طریق Java کلاس‌های قفل زیر را ارائه می‌دهد:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) قفل‌گذاری بر autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) قفل‌گذاری بر اشکال کانکتور.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) قفل‌گذاری بر اشیای گرافیکی.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) قفل‌گذاری بر اشکال گروهی.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) قفل‌گذاری بر فریم‌های تصویر.  

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کرده و قفل‌های مناسب را بر روی هر اشکال پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای سازگار با ارائه از قفل‌های اشکال برای محدود کردن عملیات ویرایشی منفرد استفاده می‌کنند. رمزگذاری فایل و حفاظت نوشتاری سطح سند تنظیمات جداگانه‌ای تحت عنوان [presentation protection settings](/slides/fa/php-java/password-protected-presentation/) دارند.

### **اعمال حفاظت بر اشکال PPTX**

Aspose.Slides برای PHP از طریق Java کلاس [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) را برای کار با اشکال در یک اسلاید فراهم می‌کند.

مثال زیر متدهای [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)، [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) و [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) را برای autoshapes با مقدار `true` فراخوانی می‌کند و قفل‌های معادل برای اشکال گروهی، کانکتورها و فریم‌های تصویر اعمال می‌شود. برای کانکتورها از [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) جهت جابجایی استفاده می‌شود؛ گروه‌ها نیز از [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) برای محدود کردن گروه‌بندی بهره می‌برند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعهٔ اشکال هر اسلاید را بررسی می‌نماید و یک کپی با این محدودیت‌ها ذخیره می‌کند. اشکالی که جزو چهار نوع مدیریت‌شده هستند، بدون تغییر می‌مانند. حلقهٔ پیمایش، اشکال فرزند داخل یک گروه را پیمایش نمی‌کند.

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

برای حذف یک قفل اشکال، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های اشکال را بارگذاری کرده و محدودیت‌های انتخاب، جابجایی و تغییر اندازه را از طریق [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)، [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)، [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) و [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) پاک می‌کند. همچنین محدودیت گروه‌بندی را با عبور `false` به متد [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) حذف کرده و یک نسخهٔ کپی از ارائه را ذخیره می‌کند. سایر تنظیمات قفل بدون تغییر می‌مانند.

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

یک عکس به نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس متد [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) را بر قفل فریم تصویر فراخوانی می‌کند. تنظیم `true` مانع برش‌های بعدی می‌شود و برش موجود را حفظ می‌کند.

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

`PictureLocked.pptx` قفل برش را به صورت `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** زمانی که عکس انتخاب شده باشد غیرفعال می‌شود.

### **نگه داشتن یک نمودار به صورت گروهی**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس متد [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) را بر قفل گروه فراخوانی می‌کند تا ترکیب اجزای نمودار حفظ شود. سایر ویرایش‌ها مانند جابجایی گروه یا تغییر پرکردگی یک جزء همچنان در دسترس هستند.

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

`DiagramLocked.pptx` قفل جداسازی را به صورت `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** زمانی که کل نمودار انتخاب شده باشد غیرفعال می‌شود.

### **گزارش قفل‌های موجود اشکال**

برای بررسی یک قالب، آن را باز کنید و شیء قفل هر اشکال را بخوانید. متد [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) وقتی تمام پرچم‌ها در آن شیء غیرفعال باشند `true` و وقتی حداقل یکی فعال باشد `false` برمی‌گرداند. یک گروه و فرزندانش اشیای قفل جداگانه دارند، بنابراین حتی زمانی که گروه قفل ندارد، باید فرزندان را بررسی کنید.

این مثال جابجایی را برای autoshapes، فریم‌های تصویر و گروه‌ها بررسی می‌کند. همچنین برش برای تصاویر و جداسازی برای گروه‌ها را چک می‌کند. گزارش پرچم‌های فعال شناسایی‌شده را فهرست می‌کند و انواع اشکالی که بررسی نمی‌شوند را علامت‌گذاری می‌کند.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

فرض کنید اسلاید 1 از `Sample.pptx` شامل یک گروه به نام `Layout` باشد که جداسازی آن قفل شده است، یک تصویر به نام `Photo` داخل آن که برش آن قفل شده و یک مستطیل ناشناس به نام `Free` باشد. گزارش `Free` را حذف می‌کند و دو خط زیر را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

گزارش پرچم‌های ویرایشی سطح اشکال ذخیره‌شده را می‌خواند بدون آنکه آن‌ها را تغییر دهد یا ارائه را ذخیره کند. حفاظت نوشتاری سطح سند تنظیم جداگانه‌ای است و اعمال هر پرچم بستگی به ویرایشگر دارد.

### **نتیجه‌گیری**

Aspose.Slides برای PHP از طریق Java به شما اجازه می‌دهد عملیات ویرایشی خاصی را بر روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع اشکال را انتخاب کنید و برای حذف این محدودیت‌ها مقدار آن‌ها را به `false` تنظیم کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های اشکال و حفاظت رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های اشکال عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [password protection](/slides/fa/php-java/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط بر روی اسلایدهای خاصی محدود کنم بدون آن‌که بر سایر اسلایدها تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخاب‌شده اعمال کنید. این کار تنظیمات قفل در اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**

مجموعه‌ای که توسط متد [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) گروه برگردانده می‌شود را پیمایش کنید و قفل‌های مناسب را بر هر اشکال فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید، همانند نمونهٔ گزارش‌دهی.