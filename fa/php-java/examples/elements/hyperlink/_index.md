---
title: هایپرلینک
type: docs
weight: 130
url: /fa/php-java/examples/elements/hyperlink/
keywords:
- هایپرلینک
- افزودن هایپرلینک
- دسترسی به هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "در PHP با Aspose.Slides، هایپرلینک‌ها را اضافه، ویرایش و حذف کنید: متن لینک، اشکال، اسلایدها، URLها و ایمیل؛ هدف‌ها و اقدامات را برای PPT، PPTX و ODP تنظیم کنید."
---
اضافه کردن، دسترسی، حذف و به‌روزرسانی هایپرلینک‌ها روی اشکال با استفاده از **Aspose.Slides for PHP via Java** را نشان می‌دهد.

## **افزودن یک هایپرلینک**

یک شکل مستطیل با یک هایپرلینک که به یک وب‌سایت خارجی اشاره می‌کند، ایجاد کنید.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به یک هایپرلینک**

اطلاعات هایپرلینک را از بخش متنی یک شکل بخوانید.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌شود که اولین شکل شامل هایپرلینک است.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف یک هایپرلینک**

هایپرلینک را از متن یک شکل پاک کنید.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌شود اولین شکل شامل هایپرلینک است.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **به‌روزرسانی یک هایپرلینک**

مقصد یک هایپرلینک موجود را تغییر دهید. برای اصلاح متنی که قبلاً شامل یک هایپرلینک است از `HyperlinkManager` استفاده کنید، که شبیه‌سازی می‌کند نحوه به‌روزرسانی ایمن هایپرلینک‌ها در PowerPoint.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌شود اولین شکل شامل هایپرلینک است.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // تغییر یک هایپرلینک در متن موجود باید از طریق
        // HyperlinkManager انجام شود نه تنظیم مستقیم ویژگی.
        // این رفتار شبیه به نحوه به‌روزرسانی ایمن هایپرلینک‌ها در PowerPoint است.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```