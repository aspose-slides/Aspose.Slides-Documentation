---
title: جوهر
type: docs
weight: 180
url: /fa/php-java/examples/elements/ink/
keywords:
- جوهر
- دسترسی به جوهر
- حذف جوهر
- نمونه‌های کد
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "در PHP با Aspose.Slides جوهر دیجیتال را بر روی اسلایدها مدیریت کنید: خطوط قلم را اضافه کنید، مسیرها را ویرایش کنید، رنگ و ضخامت را تنظیم کنید و نتایج را برای PowerPoint و OpenDocument صادر نمایید."
---
نمونه‌هایی از دسترسی به اشکال جوهر موجود و حذف آن‌ها با استفاده از **Aspose.Slides for PHP via Java** فراهم می‌کند.

> ❗ **نکته:** اشکال جوهر نمایانگر ورودی کاربر از دستگاه‌های تخصصی هستند. Aspose.Slides نمی‌تواند خطوط جوهر جدید را به صورت برنامه‌نویسی ایجاد کند، اما می‌توانید جوهر موجود را بخوانید و تغییر دهید.

## **دسترسی به جوهر**
دریافت اولین شکل جوهر در یک اسلاید.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین شکل جوهر در اسلاید.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف جوهر**
حذف یک شکل جوهر از اسلاید.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین شکل در اسلاید یک شکل جوهر است.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```