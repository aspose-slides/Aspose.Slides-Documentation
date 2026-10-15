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
  - افزودن متن
  - افزودن پاراگراف
  - مدیریت متن
  - مدیریت پاراگراف
  - مدیریت گلوله
  - تورفتگی پاراگراف
  - تورفتگی معلق
  - گلوله پاراگراف
  - فهرست عددی
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
description: "بیاموزید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های عددی، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای PHP از طریق Java ایجاد و قالب‌بندی کنید."
---
## **مرور کلی**

Aspose.Slides برای PHP از طریق Java متن را به صورت سلسله‌مراتبی از فریم‌های متنی، پاراگراف‌ها و بخش‌ها (Portion) نشان می‌دهد:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) محفظه متن در یک شکل را نمایندگی می‌کند و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌سازد.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) نماینده یک پاراگراف در یک فریم متنی است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را می‌دهد.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) نمایندهٔ یک قسمت متن درون یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی کاراکتر خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متنی با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف داشته باشد، با استفاده از چندین بخش.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متنی یک شکل ایجاد کنید و برای قالب‌بندی اجرای‌های متنی جداگانه از بخش‌ها (Portion) استفاده کنید. این بخش نشان می‌دهد چگونه می‌توان چندین بخش را در هر پاراگراف ترکیب کرد و رنگ‌ها، اندازه‌های قلم و سبک‌های مختلف را اعمال کرد.

### **ایجاد پاراگراف‌ها با چندین بخش**

مثال PHP زیر سه پاراگراف ایجاد می‌کند که هر کدام شامل سه اجرای متن در مجموعه‌ای که توسط [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions) برگردانده می‌شود. ابتدا از پاراگراف پیش‌فرض و بخش خالی آن استفاده می‌شود، سپس پاراگراف‌ها و بخش‌های باقی‌مانده اضافه می‌گردند. قالب‌بندی از طریق [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat) اعمال می‌شود: اولین بخش در هر پاراگراف قرمز، بولد و 15 پوینت است؛ دومین بخش آبی، ایتالیک و 18 پوینت؛ بخش سوم قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

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

متن پاراگراف‌ها را به فهرست‌هایی با نماد، شماره یا تصاویر سفارشی تبدیل کنید. مثال‌های این بخش شامل قالب‌بندی گلوله‌ها، فهرست‌های چندسطحه‌ای و شماره‌های شروع سفارشی می‌شود.

### **ایجاد فهرست گلوله‌ای یا شماره‌دار**

گلوله‌ها و شماره‌گذاری موارد مرتبط را برای اسکن سریع‌تر می‌کند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) تعریف می‌شود.

این مثال PHP یک گلوله نمادین و یک مورد شماره‌دار را به همان فریم متنی اضافه می‌کند. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) نوع گلوله را انتخاب می‌کند، در حالی که [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) نماد را فراهم می‌کند و [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) سبک شماره‌گذاری را انتخاب می‌کند. هر دو مورد از گلوله‌های سیاه با ارتفاع 100 درصد و تورفتگی پاراگراف 25 پوینت استفاده می‌کنند:

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

گلوله‌های تصویری به شما اجازه می‌دهند به جای نماد یا شماره از یک تصویر سفارشی استفاده کنید.

این مثال PHP یک تصویر را به مجموعه تصاویر ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) اضافه می‌کند و آن را به عنوان گلوله پاراگراف استفاده می‌کند. با فراخوانی [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) برای استفاده از گلوله تصویری، تصویر را از طریق [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) اختصاص می‌دهد. [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) بر روی 100 درصد تنظیم می‌شود تا اندازه گلوله نسبت به متن پاراگراف باشد:

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

### **ایجاد فهرست چندسطحه‌ای**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) را تنظیم کنید تا پاراگراف‌ها را در سطوح مختلف یک فهرست قرار دهید. سطح بالایی عمق `0` دارد.

این مثال PHP مقادیر [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) را از 0 تا 3 به چهار پاراگراف اختصاص می‌دهد و سلسله‌مراتبی داخل یک فریم متنی ایجاد می‌کند. هر پاراگراف از یک گلوله نماد استفاده می‌کند، به‌طوری که [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) بین یک گلوله گرد و یک خط تیره برای تمایز سطوح مجاور چرخش می‌کند:

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

### **شروع شماره‌گذاری فهرست با مقادیر سفارشی**

از [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) برای تعیین عدد اولیه نمایش داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

این مثال PHP [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) را برای استفاده از شماره‌گذاری در سه پاراگراف تنظیم می‌کند و مقادیر [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) را به ترتیب 2، 3 و 7 اختصاص می‌دهد. مقدار شروع به‌صورت جداگانه برای هر پاراگراف پیکربندی می‌شود تا اعداد نمایش داده‌شده بتوانند مقادیر را رد کنند:

```php
use aspose\slides\BulletType;
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

## **کنترل چیدمان پاراگراف و ویژگی‌های پایان**

مارجین‌ها و تورفتگی‌های پاراگراف را تنظیم کنید تا موقعیت اولین خط و خطوط بسته‌شده را کنترل کنید. می‌توانید علامت انتهای پاراگراف را جدا از بخش‌های متنی قابل مشاهده قالب‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از متد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این تنظیم فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به راست می‌برد، در حالی که خطوط باقی‌مانده با بدنه پاراگراف هم‌تراز می‌مانند.

هنگامی که نیاز به جابه‌جایی کل پاراگراف دارید از [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابه‌جا کنید از [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) استفاده کنید.

مثال زیر سه پاراگراف را با یک [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) برابر 20 پوینت و مقادیر [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) به ترتیب 0، 20 و 40 پوینت تنظیم می‌کند. خطوط اول به‌تدریج از افست بزرگتری شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیه چپ را حفظ می‌کنند:

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

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

### **تنظیم تورفتگی معلق**

تورفتگی معلق چیدمانی است که در آن خط اول نسبت به خطوط باقی‌مانده به سمت چپ شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) ایجاد می‌کنید. مقدار `Indent` را به عدد منفی بگذارید تا خط اول نسبت به بدنه پاراگراف به چپ جابه‌جا شود.

در عمل، [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) موقعیت چپ بدنه پاراگراف را تعیین می‌کند و [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) موقعیت خط اول نسبت به آن حاشیه را تنظیم می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` را تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف هم‌راستا شوند مفید است.

مثال PHP زیر مقادیر [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) برابر 40 و 60 پوینت را با مقادیر [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) برابر -20 و -30 پوینت ترکیب می‌کند. در هر پاراگراف، خط اول به سمت چپ خطوط بسته‌شده شروع می‌شود؛ پاراگراف دوم تورفتگی معلق عمیق‌تری دارد:

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

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف**

متد [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) ایجاد می‌کند که در آن [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) برابر 48 پوینت و [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) برابر Times New Roman تنظیم شده است. این قالب به علامت پایان پاراگراف دوم اختصاص می‌دهد و بخش‌های متنی قابل مشاهده را بدون تغییر می‌گذارد:

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

برای قواعد پاراگرافی که بر بسته شدن خودکار و نگهداری نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به [Control Line Breaking](/slides/fa/php-java/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/php-java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) برای شمارش خطوطی که یک پاراگراف پس از چیدمان متن اشغال می‌کند، استفاده کنید؛ این شامل بسته شدن خودکار می‌شود. این روش برای بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

پاراگراف یک مورد در [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح درون پاراگراف یک خط جدید ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته شدن خودکار خطوط را بر پایهٔ عرض موجود ایجاد می‌کند بدون اینکه شکست خط صریحی در متن وارد شود. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خطوط رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی می‌سازد، خطوط آن را می‌شمارد، اندازه شکل را کم می‌کند و سپس متن را با یک رشته کوتاه‌تر جایگزین می‌کند. در این مثال با [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) بسته شدن متن فعال و با [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) خود تنظیم‌پذیری غیرفعال می‌شود تا عرض شکل کنترل بسته شدن باشد بدون اینکه متن یا شکل به‌صورت خودکار کوچک شود. هر اندازه‌گیری از [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) استفاده می‌کند. ابعاد شکل بر حسب پوینت هستند. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و شمارش خطوط را در سراسر فریم متنی جمع می‌کند:

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

با این متن و این ابعاد، باریک‌تر کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه‌تر آن را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن فونت و جایگزینی، اندازهٔ قلم، حاشیه‌ها، تورفتگی، بسته شدن و تنظیمات خود تنظیم‌پذیری متفاوت باشد. برای بررسی یک قالب، از فونت‌ها و تنظیمات چیدمان موردنظر در محیط هدف استفاده کنید.

تعداد خطوط به تنهایی تعیین نمی‌کند که آیا متن از محفظه‌اش سرریز می‌شود یا نه. ارتفاع موجود، ارتفاع خطوط، فاصلهٔ پاراگرافی و خطی، و رفتار خود تنظیم‌پذیری نیز مؤثرند؛ حتی یک خط واحد می‌تواند وقتی بسته شدن غیرفعال باشد عرض موجود را تجاوز کند.

## **واردات و صادرات محتوای پاراگراف**

از HTML برای آوردن متن به یک ارائه یا صادرات پاراگراف‌های موجود به منظور استفاده در خارج از آن استفاده کنید. این بخش همچنین نشان می‌دهد چگونه می‌توان پاراگراف‌های جداگانه را به صورت تصویر رندر کرد، از جمله پاراگراف‌های موجود در سلول‌های جدول.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) برای تبدیل علامت‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

این مثال PHP HTML را از یک فایل می‌خواند و علامت‌گذاری را به [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) می‌سپارد. پاراگراف پیش‌فرض فریم متنی را پاک می‌کند تا فریم فقط شامل محتوای وارد شده باشد. شکل مستطیلی حاشیهٔ 10 پوینت در هر طرف اسلاید می‌گذارد:

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

از [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) برای صادرات یک بازهٔ انتخابی از پاراگراف‌ها به HTML استفاده کنید. هنگام استفاده مجدد از متن ارائه در یک وب‌سایت، ممکن است بخواهید تأکیدهای محلی را بدون انتقال قلم، اندازه یا سبک جعبهٔ متن ارائه حفظ کنید. با تنظیم [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) می‌توانید کنترل کنید که مبدل تا چه حد قالب‌بندی وراثتی را دنبال می‌کند.

[نمونه ارائه را دانلود کنید](text-inheritance.pptx) و در پوشهٔ کاری برنامه قرار دهید. اسلاید اول آن یک شکل متنی دارد که متن «Inherited text; explicit red 18pt» را شامل می‌شود. ورودی به‌ عمده از سطوح مختلف قالب‌بندی استفاده می‌کند:

- سبک متنی پیش‌فرض ارائه Calibri با اندازهٔ 28 pt را فراهم می‌کند.
- سبک متنی سطح اول فریم متنی متن آبی و ایتالیک را فراهم می‌کند.
- پاراگراف به‌طور صریح متن بولد را تنظیم می‌کند.
- بخش دوم، «explicit red 18pt»، به‌صورت صریح متن قرمز و اندازهٔ 18 pt را تنظیم می‌کند.

مثال کامل زیر همان پاراگراف‌ها را سه بار صادر می‌کند. به متد صادرات یک شیء [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) می‌فرستد و هر نتیجه را به‌صورت یک فایل HTML UTF‑8 جداگانه می‌نویسد:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
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

HTML تولید شده CSS زیر را برای اولین بخش «Inherited text; » شامل می‌شود. جدول مربوطه را نشان می‌دهد؛ سایر ویژگی‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مرتبط برای اولین بخش | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد و ایتالیک با اندازهٔ 28 pt در Calibri، اگر آن قلم موجود باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، بولد و ایتالیک؛ صفحه یا مرورگر زمینهٔ قلم و اندازهٔ آن را فراهم می‌کند. |
| `ParagraphOnly.html` | `font-weight:bold` | متن بولد؛ صفحه یا مرورگر قلم، اندازه، رنگ و سبک ایتالیک را تامین می‌کند. |

بخش دوم `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. این بخش در خروجی‌های `All` و `TextBox` ایتالیک را نیز حفظ می‌کند، اما در `ParagraphOnly` این ویژگی حذف می‌شود. محدود کردن وراثت لذا قالب‌بندی صریحاً اختصاص داده‌شده به پاراگراف یا بخش حذف نمی‌شود.

فایل‌ها را در همان مرورگر باز کنید تا مقایسه کنید. در دو حالت محدود شده، ویژگی‌های CSS حذف‌شده توسط سبک‌های صفحه مقصد یا پیش‌فرض مرورگر حل می‌شوند، بنابراین ظاهر نهایی به جایی که HTML استفاده می‌شود بستگی دارد.

### **رندر پاراگراف به عنوان تصویر**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) یک پاراگراف منفرد را مستقیم رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) برمی‌گرداند. نتیجه را می‌توانید با [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) در یک فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی یا برش بیت‌مپ به‌صورت دستی نیست.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) می‌تواند `null` برگرداند اگر پاراگراف در مجموعهٔ والد یافت نشود، مرزهای رندر معتبری نداشته باشد یا نتواند رندر شود. قبل از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر برگردانده‌شده را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

این مثال از یک ارائه با یک اسلاید استفاده می‌کند که شکل اول آن یک جعبه متنی شامل سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم (اندیس 1) را انتخاب می‌کند و بدون پارامترهای مقیاس به [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) فراخوانی می‌کند. ابتدا بررسی می‌کند که شکل پاراگراف موردنیاز را دارد و رندر تصویر بازگردانده شده است قبل از این‌که [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) را برای ذخیره به فرمت PNG فراخوانی کند. بلوک `finally` تصویر را پس از استفاده آزاد می‌کند.

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

#### **رندر پاراگراف در یک سلول جدول با مقیاس**

از بارگذاری [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) که پارامترهای `$scaleX` و `$scaleY` را می‌پذیرد استفاده کنید تا عوامل مقیاس افقی و عمودی را تنظیم کنید. مثال زیر یک جدول می‌سازد، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به‌صورت تصویر PNG ذخیره می‌نماید.

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

عامل مقیاس `1` آن محور را در اندازه پیش‌فرض پیکسل نگه می‌دارد. به‌عنوان مثال، `2` برای هر دو عامل تصویری تولید می‌کند که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض است و تعداد پیکسل‌ها چهار برابر می‌شود. عوامل بزرگتر عموماً متن شفاف‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر با جزئیات کمتر می‌سازند. برای حفظ نسبت طول/عرض پاراگراف از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی تصویر را به‌صورت مستقل کش می‌دهند.

رندر کل شکل با [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) زمانی مفید است که خروجی نیاز به شامل پرکردن، حاشیه یا سایر زمینه‌های بصری شکل داشته باشد. برای تصویر فقط پاراگراف، از [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) استفاده کنید.

## **سؤالات متدوال**

**آیا می‌توانم بسته شدن خط داخل یک فریم متنی را به‌طور کامل غیرفعال کنم؟**

بله. با تنظیم [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) بسته شدن را غیرفعال کنید تا خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم حدود دقیق روی اسلاید برای یک پاراگراف خاص را دریافت کنم؟**

از [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) برای دریافت مستطیل محدود‌کننده پاراگراف استفاده کنید. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) حدود یک بخش منفرد را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، وسط یا توجیه) در کجا انجام می‌شود؟**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) تنظیمی در سطح پاراگراف است و بر کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی بخش‌های منفرد.

برای تراز عمودی بخش‌های با اندازهٔ قلم متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/php-java/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان اثبات (proofing) را برای قسمتی از پاراگراف تنظیم کنم؟**

بله. با تنظیم [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) برای بخش‌های منفرد، می‌توانید یک پاراگراف را شامل متن‌های چند زبانه کنید.