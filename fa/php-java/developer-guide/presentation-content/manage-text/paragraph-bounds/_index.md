---
title: دریافت مرزهای پاراگراف از ارائه‌ها در PHP
linktitle: مرزهای پاراگراف
type: docs
weight: 43
url: /fa/php-java/paragraph-bounds/
keywords:
- مرزهای پاراگراف
- مختصات پاراگراف
- اندازه پاراگراف
- فریم متن
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه مرزهای پاراگراف را در Aspose.Slides برای PHP از طریق Java بازیابی کنید تا موقعیت‌بندی متن در ارائه‌های پاورپوینت بهینه شود."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه مرزها، اندازه و مختصات پاراگراف‌ها را در Aspose.Slides به دست آورید. نشان می‌دهد چگونه با استفاده از [Paragraph::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/getrect/) یک مستطیل پاراگراف را از یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) دریافت کنید، چگونه مختصات پاراگراف را داخل یک فریم متنی سلول جدول به دست آورید، و جزئیات مهمی مانند واحدهای اندازه‌گیری، تأثیر پیچش متن بر مرزها، تبدیل به پیکسل و مقادیر قالب‌بندی مؤثر پاراگراف را برجسته می‌کند.

## **دریافت مختصات مستطیلی یک پاراگراف**

از [Paragraph::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/getrect/) برای دریافت مستطیل محدوده یک پاراگراف استفاده کنید.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **دریافت اندازه یک پاراگراف داخل فریم متنی سلول جدول**

برای دریافت اندازه و مختصات یک [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) در فریم متنی سلول جدول، از [Paragraph::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/getrect/) استفاده کنید. مستطیل بازگشتی نسبت به فریم متنی سلول جدول است، بنابراین هنگام نیاز به مختصات سطح اسلاید، موقعیت جدول و جابه‌جایی سلول را اضافه کنید.

مثال زیر مرزهای پاراگراف داخل یک سلول جدول را دریافت می‌کند و مستطیل‌هایی را روی اسلاید رسم می‌نماید تا این مرزها را به تصویر بکشد:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**مختصات پاراگراف‌ها بر حسب چه واحدی اندازه‌گیری می‌شود؟**

آنها بر حسب پوینت اندازه‌گیری می‌شوند، به‌طوری که ۱ اینچ برابر ۷۲ پوینت است. این برای تمام مختصات و ابعاد بر روی اسلاید صادق است.

**آیا پیچش متن بر مرزهای پاراگراف تأثیر می‌گذارد؟**

بله. اگر [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/setwraptext/) برای [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) فعال باشد، متن برای جا شدن در عرض ناحیه شکسته می‌شود و این باعث تغییر مرزهای واقعی پاراگراف می‌شود.

**آیا می‌توان مختصات پاراگراف را به‌دقت به پیکسل‌های تصویر خروجی تبدیل کرد؟**

بله. پوینت‌ها را به پیکسل با استفاده از این فرمول تبدیل کنید: پیکسل = پوینت × (DPI / 72). نتیجه به DPI انتخاب‌شده برای رندر یا خروجی بستگی دارد.

**چگونه پارامترهای قالب‌بندی «موثر» پاراگراف را که وراثت سبک را در نظر می‌گیرد، به‌دست آورم؟**

از [ساختار داده قالب‌بندی مؤثر پاراگراف](/slides/fa/php-java/shape-effective-properties/) استفاده کنید؛ این ساختار مقادیر نهایی یکپارچه برای تورفتگی‌ها، فاصله‌ها، بسته‌بندی، راست به چپ و موارد دیگر را برمی‌گرداند.