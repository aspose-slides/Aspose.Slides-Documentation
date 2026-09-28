---
title: مدیریت پاراگراف‌های متن PowerPoint در PHP
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- متن اضافه کنید
- پاراگراف اضافه کنید
- متن را مدیریت کنید
- پاراگراف را مدیریت کنید
- گلوله را مدیریت کنید
- تو رفتگی پاراگراف
- تو رفتگی معلق
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌ای
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادرات پاراگراف
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای PHP از طریق Java پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تو رفتگی‌ها، محتوای HTML و تصاویر پاراگراف را ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java متن را به صورت سلسله‌مراتبی از فریم‌های متن، پاراگراف‌ها و Portion‌ها نمایش می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) نمایانگر مخزن متن در یک شکل است و دسترسی به مجموعهٔ پاراگراف‌های آن را فراهم می‌آورد.
* [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) نمایانگر یک پاراگراف در یک فریم متن است و دسترسی به Portion‌ها و قالب‌بندی سطح پاراگراف را ارائه می‌دهد.
* [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) نمایانگر یک بخش متن داخل پاراگراف است. هر Portion می‌تواند متن و قالب‌بندی کاراکتری خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با قلم‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از چندین Portion در خود داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

### **ایجاد پاراگراف‌ها با چندین Portion**

مراحل زیر یک فریم متن با سه پاراگراف ایجاد می‌کند که هر کدام شامل سه Portion هستند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. از پاراگراف پیش‌فرض استفاده کنید و دو شیء دیگر از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) به فریم متن اضافه کنید.
6. برای هر پاراگراف به میزان کافی شیء از کلاس [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) اضافه کنید تا بتواند سه Portion داشته باشد. پاراگراف پیش‌فرض قبلاً یک Portion خالی دارد.
7. متن هر Portion را تنظیم کنید.
8. قالب‌بندی کاراکتری را از طریق [Portion::getPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getPortionFormat--) اعمال کنید.
9. ارائهٔ اصلاح‌شده را ذخیره کنید.

این مثال PHP مراحل را پیاده‌سازی می‌کند:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ایجاد فهرست‌های گلوله‌ای و شماره‌دار**

### **ایجاد یک فهرست گلوله‌ای یا شماره‌دار**

گلوله‌ها و شماره‌گذاری، موارد مرتبط را برای اسکن سریع‌تر می‌کنند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/) تعریف می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید انتخاب شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) برای یک گلولهٔ نماد ایجاد کنید.
7. [BulletFormat::setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setType-int-) را به [BulletType::Symbol](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/) تنظیم کرده و کاراکتر گلوله را مشخص کنید.
8. متن پاراگراف، تو رفتگی، رنگ گلوله و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. یک پاراگراف دوم ایجاد کرده و [BulletFormat::setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setType-int-) را به [BulletType::Numbered](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/) تنظیم کنید.
11. سبک گلولهٔ شماره‌دار را پیکربندی کرده و پاراگراف را به فریم متن اضافه کنید.
12. ارائه را ذخیره کنید.

این مثال PHP یک گلولهٔ نماد و یک گلولهٔ شماره‌دار ایجاد می‌کند:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **استفاده از گلوله‌های تصویری**

گلوله‌های تصویری به شما اجازه می‌دهند به جای نماد یا شماره از تصویر سفارشی استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) اضافه کنید و به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) آن دسترسی پیدا کنید.
4. پاراگراف پیش‌فرض را از فریم متن حذف کنید.
5. تصویر گلوله را بارگذاری کرده و به مجموعهٔ تصاویر ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) اضافه کنید.
6. یک [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کرده و متن آن را تنظیم کنید.
7. [BulletFormat::setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setType-int-) را به [BulletType::Picture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/) تنظیم کنید.
8. تصویر را از طریق [BulletFormat::getPicture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#getPicture--) اختصاص داده و ارتفاع گلوله را تنظیم کنید.
9. پاراگراف را به فریم متن اضافه کنید.
10. ارائهٔ اصلاح‌شده را ذخیره کنید.

این مثال PHP یک گلولهٔ تصویری ایجاد می‌کند:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **ایجاد فهرست چندسطحی**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setDepth-short-) را تنظیم کنید تا پاراگراف‌ها در سطوح مختلف یک فهرست قرار گیرند. سطح بالایی عمق `0` دارد.

1. یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کرده و یک اسلاید را دریافت کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) اضافه کنید و پاراگراف پیش‌فرض را از فریم متن آن پاک کنید.
3. چهار پاراگراف ایجاد کرده و نمادهای گلولهٔ آن‌ها را پیکربندی کنید.
4. مقدارهای [ParagraphFormat::setDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setDepth-short-) آن‌ها را به ترتیب `0`، `1`، `2` و `3` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کرده و ارائه را ذخیره کنید.

این مثال PHP یک فهرست گلوله‌ای چهار سطحی ایجاد می‌کند:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **شروع موارد فهرست شماره‌دار با مقادیر دلخواه**

از [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) استفاده کنید تا عدد اولیهٔ نمایش داده‌شده برای پاراگراف شماره‌دار تنظیم شود.

1. یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
2. پاراگراف پیش‌فرض را از فریم متن شکل پاک کنید.
3. سه پاراگراف شماره‌دار ایجاد کنید.
4. برای پاراگراف‌های مربوطه، [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) را به ترتیب به `2`، `3` و `7` تنظیم کنید.
5. پاراگراف‌ها را به فریم متن اضافه کرده و ارائه را ذخیره کنید.

این مثال PHP عدد شروع دلخواهی را برای هر پاراگراف تخصیص می‌دهد:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهایی**

### **تنظیم تو رفتگی خط اول**

از [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setIndent-float-) برای کنترل تو رفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیهٔ چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت، خط اول را به راست می‌برد، در حالی که خطوط باقی‌مانده همانند بدنهٔ پاراگراف تراز می‌شوند.

وقتی نیاز دارید کل پاراگراف را جابه‌جا کنید، از [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابه‌جا کنید، از [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setIndent-float-) استفاده کنید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر مختلف [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setIndent-float-) را برای نشان دادن تأثیر تو رفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کرده و مقادیر مختلف [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setIndent-float-) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه تو رفتگی پاراگراف تنظیم شود:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![تو رفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تو رفتگی معلق**

تو رفتگی معلق، چیدمان پاراگرافی است که در آن خط اول به سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setIndent-float-) ایجاد می‌کنید. برای جابه‌جایی خط اول به چپ نسبت به بدنهٔ پاراگراف، مقدار منفی به این متد بدهید.

در عمل، [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) موقعیت چپ بدنهٔ پاراگراف را تعیین می‌کند و [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setIndent-float-) موقعیت خط اول را نسبت به آن حاشیه تعریف می‌کند. برای ایجاد تو رفتگی معلق، مقدار مثبت به `setMarginLeft` و مقدار منفی به `setIndent` بدهید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنهٔ پاراگراف تراز شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت به [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) بدهید.
6. مقدار منفی به [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setIndent-float-) بدهید تا اثر تو رفتگی معلق ایجاد شود.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائهٔ اصلاح‌شده را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه تو رفتگی معلق برای یک پاراگراف تنظیم شود:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![تو رفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای اجرای پاراگراف**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال PHP زیر اندازه قلم و قلم لاتین را به علامت انتهای پاراگراف دوم اختصاص می‌دهد:

1. یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید و یک اسلاید را دریافت کنید.
2. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) اضافه کرده و پاراگراف پیش‌فرض آن را پاک کنید.
3. دو پاراگراف ایجاد کرده و به آن‌ها Portionهای متنی اضافه کنید.
4. یک [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/) برای علامت انتهای پاراگراف دوم ایجاد کنید.
5. [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) و [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) را تنظیم کنید.
6. قالب را با [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) اختصاص داده و ارائه را ذخیره کنید.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **شمارش خطوط رندر شده**

برای قواعد پاراگراف که بر بسته شدن خودکار و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [کنترل شکست خط](/slides/fa/php-java/text-formatting/#control-line-breaking) و [کنترل نقطه‌گذاری معلق](/slides/fa/php-java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph::getLinesCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getLinesCount--) برای شمارش خطوط اشغال‌شده توسط یک پاراگراف پس از چیدمان متن استفاده کنید؛ این شمارش شامل بسته شدن خودکار نیز می‌شود. این قابلیت برای بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در [TextFrame::getParagraphs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParagraphs--) است و می‌تواند چندین خط رندر شده اشغال کند. یک شکست خط صریح داخل پاراگراف باعث ایجاد خط جدید می‌شود بدون ایجاد پاراگراف دیگر. بسته شدن خودکار خطوط بر اساس عرض موجود ایجاد می‌شود و خط‌های صریحی را وارد متن نمی‌کند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با رشته‌ای کوتاه‌تر جایگزین می‌کند. بسته شدن فعال است و تنظیم خودکار اندازه غیرفعال شده تا عرض شکل کنترل بسته شدن را بدون کوچک کردن خودکار متن یا تغییر اندازه شکل انجام دهد. ابعاد شکل بر حسب پوینت است. در نهایت، یک پاراگراف دیگر اضافه می‌کند و مجموع شمارش خطوط را در فریم متن جمع می‌کند.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

با این متن و این ابعاد، باریک کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشتهٔ کوتاه‌تر آن را کاهش می‌دهد. شمارش‌های دقیق می‌توانند بسته به در دسترس بودن قلم، جایگزینی، اندازهٔ قلم، حاشیه‌ها، تو رفتگی، بسته شدن و تنظیمات خودکار متفاوت باشند. هنگام بررسی قالب، از قلم‌ها و تنظیمات چیدمانی که برای محیط هدف در نظر گرفته‌اید استفاده کنید.

تنها شمارش خطوط تعیین نمی‌کند که متن از مخزن خود زیاد می‌شود یا نه. ارتفاع قابل‌استفاده، ارتفاع خطوط، فاصلهٔ پاراگراف و خط، و رفتار خودکار نیز مهم هستند؛ حتی یک خط واحد می‌تواند عرض موجود را در حالت بسته شدن غیرفعال تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و Portion‌ها در یک فریم متن استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید دریافت کنید و یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) اضافه کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید و پاراگراف پیش‌فرض آن را پاک کنید.
4. فایل HTML منبع را بخوانید.
5. رشتهٔ HTML را به [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) پاس دهید.
6. ارائهٔ اصلاح‌شده را ذخیره کنید.

این مثال PHP HTML را به یک فریم متن وارد می‌کند:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **صادرات متن پاراگراف به HTML**

از [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) برای صادرات یک بازهٔ انتخابی از پاراگراف‌ها به عنوان HTML استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائهٔ موردنظر را بارگذاری کنید.
2. اسلاید را دریافت کنید و [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/)ی حاوی متن را پیدا کنید.
3. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
4. با تعیین اندیس پاراگراف شروع و تعداد پاراگراف‌های موردنظر، [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) را فراخوانی کنید.
5. رشتهٔ HTML بازگشتی را در فایلی بنویسید.

این مثال PHP تمام پاراگراف‌ها را از اولین شکل متنی صادر می‌کند:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **رندر یک پاراگراف به عنوان تصویر**

[Paragraph::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getImage--) یک پاراگراف منفرد را مستقیماً رندر می‌کند و یک شیء [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) برمی‌گرداند. نتیجه را با [IImage::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/#save-java.lang.String-int-) در فایل یا جریان ذخیره یا ارسال کنید. نیازی به رندر شکل حاوی یا برش دستی بیت‌مپ نیست.

[Paragraph::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getImage--) می‌تواند `null` بازگرداند اگر پاراگراف در مجموعهٔ والد یافت نشود، مرزهای رندر معتبری نداشته باشد یا امکان رندر نداشته باشد. پیش از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر برگردانده‌شده را آزاد کنید.

#### **رندر یک پاراگراف با مقیاس پیش‌فرض**

فرض کنید فایلی به نام `sample.pptx` داریم که شامل یک اسلاید است و اولین شکل آن یک جعبهٔ متنی حاوی سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال PHP زیر پاراگراف دوم را در یک شکل متنی معمولی با مقیاس پیش‌فرض رندر می‌کند و تصویر برگردانده‌شده را به فرمت PNG ذخیره می‌نماید. بلوک `finally` اطمینان می‌دهد تصویر به‌درستی آزاد شود.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

#### **رندر یک پاراگراف در سلول جدول با مقیاس‌بندی**

از بارگذاری [Paragraph::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getImage-float-float-) که پارامترهای `$scaleX` و `$scaleY` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال PHP زیر جدول ایجاد می‌کند، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به صورت تصویر PNG ذخیره می‌نماید.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

عامل مقیاس `1` اندازهٔ پیش‌فرض پیکسل را حفظ می‌کند. برای مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و تعداد پیکسل‌ها چهار برابر می‌شود. عوامل بزرگتر معمولاً برای زوم یا خروجی با وضوح بالا متن واضح‌تری تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتری با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت طول و عرض پاراگراف از عوامل برابر استفاده کنید؛ عوامل افقی و عمودی متفاوت، خروجی را به‌صورت مستقل کشیده می‌کنند.

رندر کل شکل با [Shape::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage--) زمانی مفید است که خروجی نیاز به شامل پر، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [Paragraph::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getImage--) استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم بسته شدن خط را به‌طور کامل داخل یک فریم متن غیرفعال کنم؟**

بله. برای غیرفعال کردن بسته شدن، [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setWrapText-byte-) را تنظیم کنید تا خطوط در لبه‌های فریم متن نشکنند.

**چگونه می‌توانم مرزهای دقیق یک پاراگراف خاص را روی اسلاید دریافت کنم؟**

از [Paragraph::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getRect--) برای دریافت مستطیل محدودهٔ پاراگراف استفاده کنید. [Portion::getRect](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/#getRect--) مرزهای یک Portion خاص را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، وسط یا توزیع) در کجا انجام می‌شود؟**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setAlignment-int-) تنظیمی در سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر Portion به‌صورت جداگانه.

**آیا می‌توانم زبان proofing را برای بخشی از یک پاراگراف تنظیم کنم؟**

بله. برای Portionهای جداگانه [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) را تنظیم کنید، به این ترتیب یک پاراگراف می‌تواند متنی با زبان‌های مختلف داشته باشد.