---
title: تغییر اندازه اشکال در اسلایدهای ارائه با PHP
type: docs
weight: 130
url: /fa/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "به راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای PHP via Java تغییر اندازه دهید—تنظیمات چینش اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نمای کلی**

هنگامی که اندازهٔ اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز به تغییر اندازه و جابجایی اشکال آن داشته باشید تا با ابعاد جدید مطابقت پیدا کنند. این مقاله نشان می‌دهد چگونه اشکال را به صورت دستی مقیاس‌بندی کنید و چگونه جداول را در اسلایدها، اسلایدهای اصلی و طرح‌بندی‌ها مدیریت کنید.

## **تغییر اندازه اشکال**

برای حفظ موقعیت نسبی و اندازهٔ هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع متناظر را بر مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول یک ارائه را بارگذاری می‌کند که اسلایدهای آن حاوی جدولی نیستند، اندازهٔ اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) همراه با [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) استفاده می‌کند تا حلقهٔ بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب پوینت اندازه‌گیری می‌شوند. نسبت‌های متفاوت عرض و ارتفاع می‌توانند اشکال را تحریف کنند و تغییر ابعاد یک شکل مقیاس‌بندی اندازهٔ قلم‌های آن را انجام نمی‌دهد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی مستقل.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
جداول نیاز به پردازش جداگانه دارند: به جای تعیین عرض و ارتفاع کلی جدول، عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید. اگر محتوای سلول نیاز به فضای بیشتری داشته باشد، ارتفاع ردیف ممکن است بزرگ‌تر از مقدار درخواستی باقی بماند.
{{% /alert %}}

مثال دوم از جداول پشتیبانی می‌کند و قبل از ذخیرهٔ ارائهٔ تغییر اندازه یافته، اشکال را در اسلایدهای اصلی، طرح‌بندی‌ها و اسلایدهای تک تک پردازش می‌کند. ابزار کمکی آن هر [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) را با مقیاس‌بندی عرض ستون‌ها با [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) و حداقل ارتفاع ردیف‌ها با [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) مدیریت می‌کند. سپس موقعیت جدول را مقیاس‌بندی می‌کند بدون اینکه ابعاد کلی آن به طور جداگانه مقیاس‌بندی شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // ابعاد جدول توسط عرض ستون‌ها و ارتفاع ردیف‌ها کنترل می‌شود.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی مستقل.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // تغییر اندازه اشکالی که در اسلایدهای اصلی، طرح‌بندی‌ها و اسلایدهای تک‌تک تعریف شده‌اند.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

**چرا پس از تغییر اندازهٔ اسلاید، اشکال تحریف یا بریده می‌شوند؟**

اگر اندازهٔ اسلاید را بدون مقیاس‌بندی اشکال تغییر دهید، آن‌ها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است از محدودهٔ اسلاید بیرون بزنند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند اشکال را تحریف کند.

**آیا کد ارائه‌شده برای تمام انواع اشکال کار می‌کند؟**

مثال اول محدودهٔ اشکال را به‌صورت مستقیم تغییر می‌دهد و برای اسلایدهای بدون جدول در نظر گرفته شده است. مثال دوم جداول را به‌صورت جداگانه مدیریت می‌کند. چیدمان نهایی را، به‌ویژه متن و جداول، بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازهٔ اسلاید، جداول را نیز تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض و ارتفاع حداقل ردیف‌ها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را مقیاس‌بندی کنید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای اصلی و اسلایدهای طرح‌بندی نیز اعمال می‌شود؟**

بله. مثال دوم از طریق [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) و برای هر اسلاید اصلی از [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) مرور می‌کند و منطق تغییر اندازه یکسان را بر روی اشکال آن‌ها اعمال می‌سازد.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازهٔ اسلاید و قبل از خواندن ابعاد هدف، [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) را فراخوانی کنید تا عوامل مقیاس‌گذاری جهت نهایی را منعکس کنند.

**آیا حدی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد دلخواه اسلاید را با [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود بستگی دارد.

**چگونه می‌توانم از تحریف اشکالی که نسبت تصویر ثابت دارند جلوگیری کنم؟**

از همان عامل مقیاس‌گذاری برای عرض و ارتفاع استفاده کنید. برای جا گذاشتن چیدمان اصلی در ابعاد جدید اسلاید، نسبت کوچکتر بین نسبت عرض و ارتفاع را برای هر دو بعد و موقعیت به کار ببرید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضای خالی در یک سمت باقی بماند.