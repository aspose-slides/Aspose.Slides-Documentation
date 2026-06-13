---
title: "SmartArt"
type: docs
weight: 140
url: /fa/php-java/examples/elements/smartart/
keywords:
- "SmartArt"
- "افزودن SmartArt"
- "دسترسی به SmartArt"
- "حذف SmartArt"
- "طرح‌بندی SmartArt"
- "نمونه کد"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "ساخت و ویرایش SmartArt در PHP با Aspose.Slides: افزودن گره‌ها، تغییر طرح‌بندی‌ها و سبک‌ها، تبدیل به اشکال با دقت، و صادرات برای PPT، PPTX و ODP."
---
نشان می‌دهد که چگونه گرافیک‌های SmartArt را اضافه، دسترسی داشته، حذف و طرح‌بندی‌ها را با استفاده از **Aspose.Slides for PHP via Java** تغییر دهید.

## **افزودن SmartArt**

یک گرافیک SmartArt را با استفاده از یکی از طرح‌بندی‌های توکار وارد کنید.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به SmartArt**

اولین شیء SmartArt را در یک اسلاید دریافت کنید.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین SmartArt در اسلاید.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف SmartArt**

یک شکل SmartArt را از اسلاید حذف کنید.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین شکل در اسلاید یک SmartArt است.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تغییر طرح‌بندی SmartArt**

نوع طرح‌بندی یک گرافیک SmartArt موجود را به‌روزرسانی کنید.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین شکل در اسلاید یک SmartArt است.
        $smartArt = $slide->getShapes()->get_Item(0);

        // تغییر طرح‌بندی SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```