---
title: جعبه متن
type: docs
weight: 40
url: /fa/php-java/examples/elements/text-box/
keywords:
- جعبه متن
- افزودن جعبه متن
- دسترسی به جعبه متن
- حذف جعبه متن
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و قالب‌بندی جعبه‌های متن در PHP با Aspose.Slides: تنظیم قلم‌ها، تراز، بسته‌بندی، خودتنظیم و پیوندها برای بهبود اسلایدها در PowerPoint و OpenDocument."
---
در Aspose.Slides، یک **جعبه متن** توسط یک `AutoShape` نمایش داده می‌شود. تقریباً هر شکل می‌تواند متن داشته باشد، اما یک جعبه متن معمولی هیچ پرکردگی یا حاشیه‌ای ندارد و فقط متن را نمایش می‌دهد.

این راهنما توضیح می‌دهد که چگونه می‌توان جعبه‌های متن را به صورت برنامه‌نویسی اضافه، دسترسی پیدا کرد و حذف کرد.

## **افزودن جعبه متن**

یک جعبه متن به سادگی یک `AutoShape` بدون پرکردگی یا حاشیه و با متنی قالب‌بندی‌شده است. در اینجا نحوه ایجاد آن آورده شده است:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // یک شکل مستطیلی ایجاد می‌کند (به‌صورت پیش‌فرض پر شده با حاشیه و بدون متن).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // حذف پرکردگی و حاشیه تا شبیه یک جعبه متن معمولی شود.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // تنظیم قالب‌بندی متن.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // متن واقعی را اختصاص می‌دهد.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نکته:** هر `AutoShape` که شامل یک `TextFrame` غیر خالی باشد می‌تواند به عنوان یک جعبه متن عمل کند.

## **دسترسی به جعبه‌های متن بر اساس محتوا**

برای یافتن تمام جعبه‌های متنی که شامل یک کلمه کلیدی خاص (مثلاً "Slide") هستند، از طریق اشکال مرور کنید و متن آن‌ها را بررسی کنید:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین جعبه متن روی اسلاید.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // کاری با جعبه متن منطبق انجام دهید.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف جعبه‌های متن بر اساس محتوا**

این مثال تمام جعبه‌های متن موجود در اولین اسلاید که شامل یک کلمه کلیدی خاص هستند را پیدا و حذف می‌کند:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نکته:** همیشه قبل از تغییر مجموعهٔ اشکال در طول تکرار، یک کپی از مجموعهٔ اشکال ایجاد کنید تا از خطاهای تغییر مجموعه جلوگیری شود.