---
title: مدیریت زوم ارائه در PHP
linktitle: مدیریت زوم
type: docs
weight: 60
url: /fa/php-java/manage-zoom/
keywords:
- زوم
- فریم زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- افزودن زوم
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای PHP از طریق Java — پرش بین بخش‌ها، افزودن تصویر بندانگشتی و انتقال‌ها در ارائه‌های PowerPoint."
---
## **مقدمه**

زاوم‌های پاورپوینت به شما اجازه می‌دهند بین اسلایدها و بخش‌های خاص در حین نمایش اسلاید حرکت کنید. با Aspose.Slides برای PHP از طریق Java می‌توانید زوم‌های اسلاید، بخش و خلاصه‌وار را ایجاد کرده و پیش‌نمایش‌ها، حاشیه‌ها و انتقال‌های آن‌ها را سفارشی کنید.

![نمای کلی زوم پاورپوینت](overview.png)

* برای خلاصه‌کردن کل ارائه در یک اسلاید، از یک [خلاصه زوم](#summary-zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخاب‌شده، از یک [زوم اسلاید](#slide-zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از یک [زوم بخش](#section-zoom) استفاده کنید.

## **زوم اسلاید**

یک زوم اسلاید می‌تواند ارائه شما را پویا‌تر کند و به شما امکان می‌دهد به‌صورت آزادانه بین اسلایدها به هر ترتیب دلخواه حرکت کنید بدون اینکه جریان ارائه شما قطع شود. زوم‌های اسلاید برای ارائه‌های کوتاه بدون بخش‌های زیاد عالی هستند، اما می‌توانید همچنان از آن‌ها در سناریوهای مختلف ارائه استفاده کنید.

زوم‌های اسلاید به شما امکان می‌دهند اطلاعات مرتبط را از یک اسلاید نمای کلی بررسی کنید.

![انتخاب اسلایدها برای زوم اسلاید](slidezoomsel.png)

برای اشیای زوم اسلاید، Aspose.Slides شمارنده [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/)، کلاس [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/) و روش‌هایی در کلاس [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) را فراهم می‌کند.

### **ایجاد فریم‌های زوم**

از [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) برای قرار دادن پیوندهایی به اسلایدهای منفرد در یک اسلاید نمای کلی استفاده کنید. این مثال دو اسلاید هدف با پس‌زمینه‌ها و برچسب‌های متمایز ایجاد می‌کند، سپس پیش‌نمایشی از هر کدام را به اسلاید اول اضافه می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند. موقعیت‌ها و اندازه‌های فریم به واحد نقطه (points) مشخص شده‌اند.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ایجاد فریم‌های زوم با تصاویر سفارشی**

یک تصویر سفارشی را به [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) پاس دهید تا پیش‌نمایش پیش‌فرض اسلاید هدف را جایگزین کنید. این مثال به یک تصویر محلی نیاز دارد، آن را با [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) بارگذاری می‌کند و با استفاده از [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه می‌شود. فریم حاصل آن تصویر را نمایش می‌دهد در حالی که همچنان به اسلاید دوم پیوند دارد.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **قالب‌بندی فریم‌های زوم**

این مثال دو فریم زوم اسلاید را سفارشی می‌کند. یک تصویر محلی به فریم اول از طریق [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) اختصاص می‌دهد و به فریم دوم حاشیه‌ای به‌عرض پنج نقطه، خط نقطه‌خطی صورتی از طریق [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) می‌گذارد. با ارسال `false` به [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) پس‌زمینه فریم دوم مخفی می‌شود. برای پیش‌نمایش سفارشی یک تصویر محلی لازم است؛ هر دو فریم هدف اسلاید خود را در PPTX ذخیره‌شده حفظ می‌کنند.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $firstZoomFrame = $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $secondZoomFrame = $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $firstZoomFrame->setZoomImage($previewImage);

    $secondZoomFrame->getLineFormat()->setWidth(5);
    $secondZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 105, 180);
    $secondZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);

    $secondZoomFrame->setShowBackground(false);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **زوم بخش**

یک زوم بخش به یک بخش در ارائه شما پیوند می‌دهد. از آن برای بازدید مجدد از یک موضوع یا نشان دادن چگونگی ارتباط بخش‌های مختلف ارائه استفاده کنید.

![انتخاب یک بخش برای زوم بخش](seczoomsel.png)

برای اشیای زوم بخش، Aspose.Slides کلاس [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) و روش‌هایی در کلاس [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) را فراهم می‌کند.

### **ایجاد فریم‌های زوم بخش**

یک بخش را با [SectionCollection::addSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection) ایجاد کنید، سپس بخش بازگشتی را به [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) بدهید. این مثال یک زوم بخش را بر روی اسلاید اول قرار می‌دهد و آن را به بخشی که با اسلاید رنگی شروع می‌شود پیوند می‌دهد. موقعیت و ابعاد فریم به واحد نقطه (points) مشخص می‌شود و ارائه به صورت PPTX ذخیره می‌شود.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ایجاد فریم‌های زوم بخش با تصاویر سفارشی**

بارگذاری نسخه‌ی تصویری [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) به شما امکان می‌دهد پیش‌نمایش سفارشی را بدون تغییر بخش مقصد نمایش دهید. این مثال به یک تصویر محلی نیاز دارد که با [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) بارگذاری می‌شود و از طریق [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه می‌گردد. ارائه ذخیره‌شده شامل یک زوم بخش بر روی اسلاید اول است که به بخش تازه‌ساخته‌شده پیوند دارد.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تغییر بخش هدف زوم بخش**

از [SectionZoomFrame::setTargetSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/#setTargetSection) برای تغییر مسیر یک زوم بخش موجود بدون ایجاد مجدد آن استفاده کنید. یک بخش پرشده از مجموعه‌ی [Presentation::getSections](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSections) همان ارائه انتخاب کنید. اختصاص یک بخش خالی هدف جاری را دست‌نخورده می‌گذارد، بنابراین قبل از اختصاص باید [Section::getSlidesListOfSection](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSlidesListOfSection) را بررسی کنید. برای جزئیات بیشتر درباره بخش‌ها به [Manage Slide Sections](/slides/fa/php-java/slide-section/) مراجعه کنید.

مثال زیر یک فایل ارائه را بارگذاری می‌کند که باید شامل چندین بخش پر شده باشد، یک زوم بخش موجود به نام `Section navigation` و یک بخش با نام منحصر به فرد `Results` داشته باشد. تمام اسلایدها برای پیدا کردن زوم جستجو می‌شوند و مقصد بر اساس نام پیدا می‌شود نه بر اساس اندیس مجموعه‌ای که ممکن است با جابه‌جایی بخش‌ها تغییر کند. اگر نام‌ها منحصر به فرد نباشند، می‌توانید از [Section::getSectionId](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSectionId) برای شناسایی مقصد استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("section-zoom.pptx");
try {
    $zoom = null;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($i = 0; $i < $slideCount; $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($j = 0; $j < $shapeCount; $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISectionZoomFrame")) && java_values($shape->getName()) === "Section navigation") {
                $zoom = $shape;
                break;
            }
        }
        if ($zoom != null) {
            break;
        }
    }

    $targetSection = null;
    $sectionCount = java_values($presentation->getSections()->size());
    for ($i = 0; $i < $sectionCount; $i++) {
        $section = $presentation->getSections()->get_Item($i);
        if (java_values($section->getName()) === "Results") {
            $targetSection = $section;
            break;
        }
    }

    if ($zoom == null || $targetSection == null) {
        echo "The section zoom or destination section was not found.", PHP_EOL;
    } else if (java_values($targetSection->getSlidesListOfSection()->size()) == 0) {
        echo "The destination section is empty.", PHP_EOL;
    } else {
        $currentSection = $zoom->getTargetSection();
        echo "Current section: " . (java_is_null($currentSection) ? "" : java_values($currentSection->getName())), PHP_EOL;
        $zoom->setTargetSection($targetSection);
        $presentation->save("section-zoom-updated.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

### **قالب‌بندی فریم‌های زوم بخش**

این مثال یک زوم بخش را به‌صورت 100×75 نقطه جابه‌جا و اندازه‌گذاری می‌کند، یک تصویر محلی از طریق [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) اختصاص می‌دهد و حاشیه‌ای به‌عرض 2.5 نقطه، خط نقطه‌خطی قهوه‌ای اعمال می‌کند. همچنین [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) را فعال می‌کند تا پس از پایان بخش به اسلاید مبداء بازگردد، [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) را غیرفعال می‌سازد و [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) را روی 1.5 ثانیه تنظیم می‌کند. برای پیش‌نمایش سفارشی یک تصویر محلی لازم است.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);

    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $sectionZoomFrame->setZoomImage($previewImage);

    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);

    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);

    $sectionZoomFrame->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **زوم خلاصه**

یک زوم خلاصه نمای کلی از بخش‌های ارائه را فراهم می‌کند. در حین نمایش اسلاید می‌توانید از آن برای پرش به یک بخش، پیشروی یا بازدید مجدد از یک موضوع استفاده کنید بدون این‌که ترتیب اسلایدها را دنبال کنید.

![انتخاب بخش‌ها برای زوم خلاصه](sumzoomsel.png)

برای اشیای زوم خلاصه، Aspose.Slides کلاس‌های [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/)، [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) و [SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/) و روش‌هایی در کلاس [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) را فراهم می‌کند.

### **ایجاد زوم خلاصه**

از [ShapeCollection::addSummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSummaryZoomFrame) برای ایجاد نمای کلی از بخش‌های ارائه استفاده کنید. این مثال چهار بخش با پس‌زمینه‌های متمایز اسلاید ایجاد می‌کند و یک زوم خلاصه را بر روی اسلاید اول اضافه می‌کند. موقعیت و ابعاد فریم به واحد نقطه (points) مشخص شده‌اند و نمای کلی حاصل در یک ارائه PPTX ذخیره می‌شود.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 3", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 100, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 4", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **افزودن و حذف بخش زوم خلاصه**

یک زوم خلاصه اشیای [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) خود را در [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) ذخیره می‌کند. این مثال نمای کلی دو بخش را ایجاد می‌کند، یک بخش سوم را با استفاده از [SummaryZoomSectionCollection::addSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) اضافه می‌کند و ورودی اولین بخش را با استفاده از [SummaryZoomSectionCollection::removeSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) حذف می‌کند. حذف ورودی بخش‌های ارائه و اسلایدهای مربوطه را دست‌نخورده می‌گذارد.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $firstSection = $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $thirdSection = $presentation->getSections()->addSection("Section 3", $slide);

    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($thirdSection);

    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($firstSection);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **قالب‌بندی بخش‌های زوم خلاصه**

این مثال اولین ورودی در [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) را که اندیس صفر‑مبنا دارد، قالب‌بندی می‌کند. برای [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage) نیاز به یک تصویر محلی دارد، حاشیه‌ای به‌عرض 1.5 نقطه، خط نقطه‌خطی سیاه اعمال می‌کند و [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) را روی 1.5 ثانیه تنظیم می‌کند. ارسال `false` به [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) بازگشت خودکار به اسلاید خلاصه برای این ورودی را غیرفعال می‌کند.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $summarySection->setZoomImage($previewImage);
    $summarySection->setReturnToParent(false);

    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);

    $summarySection->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم بازگشت به اسلاید «والد» پس از نمایش هدف را کنترل کنم؟**

بله. با فراخوانی [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) با مقدار `true` می‌توانید پس از نمایش محتوای هدف، به اسلاید منبع بازگردید.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال زوم را تنظیم کنم؟**

بله. از [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) برای تنظیم مدت زمان انتقال بر حسب ثانیه استفاده کنید.

**آیا محدودیتی برای تعداد اشیای زوم در یک ارائه وجود دارد؟**

هیچ محدودیت سختی در API مستند نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد نمایش‌دهنده بستگی دارد. می‌توانید فریم‌های زوم زیادی اضافه کنید، اما باید به اندازه فایل و زمان رندرینگ توجه داشته باشید.