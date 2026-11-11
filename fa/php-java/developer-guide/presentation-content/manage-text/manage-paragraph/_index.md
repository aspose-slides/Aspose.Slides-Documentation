---
title: "مدیریت پاراگراف‌های متن پاورپوینت در PHP"
linktitle: "مدیریت پاراگراف"
type: docs
weight: 40
url: /fa/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- "افزودن متن"
- "افزودن پاراگراف"
- "مدیریت متن"
- "مدیریت پاراگراف"
- "مدیریت گلوله"
- "تورفتگی پاراگراف"
- "تورفتگی آویزان"
- "گلوله پاراگراف"
- "فهرست شماره‌دار"
- "فهرست نقطه‌دار"
- "خصوصیات پاراگراف"
- "وارد کردن HTML"
- "متن به HTML"
- "پاراگراف به HTML"
- "پاراگراف به تصویر"
- "متن به تصویر"
- "صدور پاراگراف"
- "PowerPoint"
- "ارائه"
- "PHP"
- "Aspose.Slides"
description: "یاد بگیرید چگونه پاراگراف‌ها، بخش‌ها، گلوله‌ها، فهرست‌های شماره‌دار، تورفتگی‌ها، محتوای HTML و تصاویر پاراگراف را با Aspose.Slides برای PHP از طریق Java ایجاد و قالب‌بندی کنید."
---
## **مرور کلی**

Aspose.Slides for PHP via Java متن را به صورت یک سلسله‌مراتب از فریم‌های متنی، پاراگراف‌ها و بخش‌ها (Portions) مدل‌سازی می‌کند:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) نمایانگر محفظه متن در یک شکل است و دسترسی به مجموعه پاراگراف‌های آن را فراهم می‌کند.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) نمایانگر یک پاراگراف در یک فریم متنی است و دسترسی به بخش‌ها و قالب‌بندی سطح پاراگراف را فراهم می‌کند.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) نمایانگر یک بخش متن درون یک پاراگراف است. هر بخش می‌تواند متن و قالب‌بندی کاراکتری خود را داشته باشد.

بنابراین یک پاراگراف می‌تواند متن با فونت‌ها، رنگ‌ها، اندازه‌ها و قالب‌بندی‌های مختلف را با استفاده از چندین بخش (Portion) در خود داشته باشد.

## **ایجاد و قالب‌بندی پاراگراف‌ها**

پاراگراف‌ها را در فریم متنی یک شکل ایجاد کنید و از بخش‌ها برای قالب‌بندی اجرای‌های منفرد متن استفاده کنید. این بخش نشان می‌دهد چگونه می‌توان چندین بخش را در هر پاراگراف ترکیب کرد و رنگ‌ها، اندازه‌های قلم و سبک‌های متفاوتی اعمال کرد.

### **ایجاد پاراگراف‌ها با چندین بخش**

مثال PHP زیر، سه پاراگراف ایجاد می‌کند که هر کدام شامل سه اجرای متن در مجموعه‌ای است که توسط [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions) برگردانده می‌شود. این مثال پاراگراف پیش‌فرض و بخش خالی آن را مجدداً استفاده می‌کند، سپس پاراگراف‌ها و بخش‌های باقیمانده را اضافه می‌کند. قالب‌بندی از طریق [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat) اعمال می‌شود: اولین بخش در هر پاراگراف قرمز، توپر (Bold) و ۱۵ نقطه است؛ دومین بخش آبی، کج (Italic) و ۱۸ نقطه؛ بخش سوم قالب‌بندی پیش‌فرض خود را حفظ می‌کند:

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

## **ایجاد فهرست‌های نقطه‌دار و شماره‌دار**

متن پاراگراف را به فهرست‌های نمادین، عددی یا با تصویر سفارشی سازماندهی کنید. مثال‌های این بخش شامل قالب‌بندی گلوله (Bullet)، فهرست‌های چندسطحی و تنظیم اعداد آغازین سفارشی است.

### **ایجاد فهرست نقطه‌دار یا شماره‌دار**

گلوله‌ها و شماره‌گذاری موارد مرتبط را برای اسکن راحت‌تر می‌کنند. در Aspose.Slides تنظیمات فهرست از طریق [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) تعریف می‌شوند.

این مثال PHP یک گلوله نمادین و یک مورد شماره‌دار را به همان فریم متنی اضافه می‌کند. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) نوع گلوله را انتخاب می‌کند، در حالی که [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) نماد را فراهم می‌کند و [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) سبک شماره‌گذاری را انتخاب می‌کند. هر دو مورد از گلوله‌های سیاه با ارتفاع ۱۰۰ درصد و تورفتگی پاراگراف ۲۵ نقطه استفاده می‌کنند:

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

گلوله‌های تصویری به شما امکان می‌دهند به جای نماد یا عدد، از تصویر سفارشی استفاده کنید.

این مثال PHP یک تصویر را به مجموعه تصویرهای ارائه به عنوان یک [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) اضافه می‌کند و آن را به‌عنوان گلوله پاراگراف استفاده می‌کند. برای استفاده از گلوله تصویری، [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) فراخوانی می‌شود و تصویر از طریق [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) اختصاص داده می‌شود. [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) بر ۱۰۰ درصد تنظیم می‌شود تا اندازه گلوله نسبت به متن پاراگراف تنظیم شود:

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

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) را تنظیم کنید تا پاراگراف‌ها را در سطوح مختلف یک فهرست قرار دهید. سطح بالا عمق `0` دارد.

این مثال PHP مقادیر [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) را از ۰ تا ۳ به چهار پاراگراف اختصاص می‌دهد و یک سلسله‌مراتب در یک فریم متنی ایجاد می‌کند. هر پاراگراف از گلوله نمادین استفاده می‌کند؛ با [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) بین گلوله گرد و خط تیره برای تمایز سطوح مجاور چرخش می‌کند:

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

### **شروع موارد فهرست شماره‌دار با مقادیر سفارشی**

از [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) برای تنظیم شماره اولیه نمایش داده‌شده برای یک پاراگراف شماره‌دار استفاده کنید.

این مثال PHP [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) را برای استفاده از شماره‌گذاری برای سه پاراگراف تنظیم می‌کند و مقادیر [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) را به ترتیب ۲، ۳ و ۷ اختصاص می‌دهد. مقدار شروع به‌صورت جداگانه برای هر پاراگراف پیکربندی می‌شود تا اعداد نمایش داده‌شده مقادیر خاصی را رد کنند:

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

## **کنترل چیدمان پاراگراف و ویژگی‌های انتهای پاراگراف**

مارجین‌ها و تورفتگی‌های پاراگراف را تنظیم کنید تا موقعیت خط اول و خطوط بسته‌شده را کنترل کنید. می‌توانید علامت انتهای پاراگراف را به‌صورت جداگانه از بخش‌های متنی قابل مشاهده قالب‌بندی کنید.

### **تنظیم تورفتگی خط اول**

از متد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این تنظیم فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به حاشیه بدنه پاراگراف هم‌راستا می‌مانند.

از [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) زمانی که نیاز به جابه‌جایی کل پاراگراف دارید، استفاده کنید. از [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) زمانی که فقط خط اول را می‌خواهید جابه‌جا کنید، استفاده کنید.

مثال زیر سه پاراگراف را با همان [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) برابر ۲۰ نقطه و مقادیر [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) برابر ۰، ۲۰ و ۴۰ نقطه تنظیم می‌کند. خطوط اول به‌صورت پیش‌رونده در آفست‌های بزرگتری شروع می‌شوند، در حالی که خطوط بسته‌شده همان حاشیه چپ را حفظ می‌کنند:

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

### **تنظیم تورفتگی آویزان**

تورفتگی آویزان یک چیدمان پاراگراف است که در آن خط اول در سمت چپ خطوط دیگر شروع می‌شود. در Aspose.Slides این اثر را با ویژگی [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) ایجاد می‌کنید. مقدار `Indent` را به مقدار منفی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به سمت چپ حرکت کند.

در عمل، [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) موقعیت چپ بدنه پاراگراف را تعیین می‌کند و [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) موقعیت خط اول را نسبت به آن حاشیه تنظیم می‌کند. برای ایجاد تورفتگی آویزان، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` را تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول قرار گیرند مفید است.

مثال PHP زیر مقادیر [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) برابر ۴۰ و ۶۰ نقطه را با مقادیر [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) برابر –۲۰ و –۳۰ نقطه جفت می‌کند. در هر پاراگراف، خط اول به سمت چپ خطوط بسته‌شده شروع می‌شود؛ پاراگراف دوم تورفتگی آویزان عمیق‌تری دارد:

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

![تورفتگی آویزان پاراگراف‌ها](hanging_indent.png)

### **تنظیم ویژگی‌های انتهای پاراگراف**

متد [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) قالب‌بندی علامت انتهای پاراگراف را کنترل می‌کند. مثال زیر یک [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) ایجاد می‌کند که در آن [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) برابر ۴۸ نقطه و [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) برابر Times New Roman تنظیم شده‌اند. این قالب به علامت انتهای پاراگراف دوم اختصاص می‌یابد و بخش‌های متنی قابل مشاهده دست نخورده می‌مانند:

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

برای قوانین پاراگراف که بر بسته شدن خودکار خطوط و نقطه‌گذاری در انتهای خطوط تأثیر می‌گذارند، به بخش‌های [Control Line Breaking](/slides/fa/php-java/text-formatting/#control-line-breaking) و [Control Hanging Punctuation](/slides/fa/php-java/text-formatting/#control-hanging-punctuation) مراجعه کنید.

از [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) برای شمارش خطوط اشغالی یک پاراگراف پس از چیدمان متن، شامل بسته شدن خودکار، استفاده کنید. این روش برای بررسی طول متن و چیدمان در قالب‌های ارائه مفید است.

یک پاراگراف یک مورد در [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) است و می‌تواند چندین خط رندر شده را اشغال کند. یک شکست خط صریح درون یک پاراگراف خط جدیدی ایجاد می‌کند بدون اینکه پاراگراف دیگری ساخته شود. بسته شدن خودکار خطوط را بر اساس عرض موجود ایجاد می‌کند بدون آنکه شکست‌های صریح خط به متن اضافه شوند. بنابراین شمارش پاراگراف‌ها یا کاراکترهای شکست خط، شمارش خط‌های رندر شده را نمی‌دهد.

مثال زیر یک شکل متنی ایجاد می‌کند، خطوط آن را می‌شمارد، شکل را باریک می‌کند و سپس متن را با یک رشته کوتاه‌تر جایگزین می‌کند. این مثال با استفاده از [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) بسته شدن متن را فعال می‌کند و با [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) حالت خودتنظیم را غیرفعال می‌سازد تا عرض شکل کنترل بسته شدن را بدون کوچک‌سازی خودکار متن یا تغییر اندازه شکل انجام دهد. هر اندازه‌گیری با [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) انجام می‌شود. ابعاد شکل بر حسب نقطه است. در نهایت، مثال یک پاراگراف دیگر اضافه می‌کند و مجموع خطوط را در سراسر فریم متنی محاسبه می‌کند.

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

با این متن و این ابعاد، باریک‌تر کردن شکل تعداد خطوط را افزایش می‌دهد، در حالی که جایگزینی متن با رشته کوتاه تعداد خطوط را کاهش می‌دهد. شمارش دقیق می‌تواند بسته به در دسترس بودن فونت و جایگزینی، اندازه قلم، حاشیه‌ها، تورفتگی، بسته شدن و تنظیمات خودتنظیم متفاوت باشد. هنگام بررسی یک قالب، از فونت‌ها و تنظیمات چیدمان مورد انتظار در محیط هدف استفاده کنید.

تعداد خطوط به تنهایی تعیین نمی‌کند که متن از محفظه‌اش سرریز می‌شود یا نه. ارتفاع موجود، ارتفاع خطوط، فاصله پاراگراف و خط، و رفتار خودتنظیم نیز مهم‌اند؛ حتی یک خط واحد می‌تواند عرض موجود را در حالت غیر فعال بودن بسته شدن تجاوز کند.

## **واردات و خروجی محتوای پاراگراف**

از HTML برای وارد کردن متن به ارائه یا خروجی‌گیری از پاراگراف‌های موجود برای استفاده خارج از آن بهره بگیرید. این بخش همچنین نحوه رندر کردن پاراگراف‌های منفرد به عنوان تصویر، شامل پاراگراف‌های داخل سلول‌های جدول را نشان می‌دهد.

### **وارد کردن متن HTML به پاراگراف‌ها**

از [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) برای تبدیل نشانه‌گذاری HTML به پاراگراف‌ها و بخش‌ها در یک فریم متنی استفاده کنید.

این مثال PHP، HTML را از یک فایل می‌خواند و نشانه‌گذاری را به [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) می‌گذارد. پاراگراف پیش‌فرض فریم متنی را پاک می‌کند تا فریم فقط شامل محتوای وارد شده باشد. شکل مستطیلی حاشیه ۱۰ نقطه‌ای در هر طرف اسلاید می‌گذارد:

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

### **خروجی متن پاراگراف به HTML**

از [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) برای خروجی‌گیری یک بازه انتخابی از پاراگراف‌ها به صورت HTML استفاده کنید. هنگام استفاده مجدد از متن ارائه در یک وب‌سایت، ممکن است بخواهید تأکیدهای محلی را بدون انتقال فونت، اندازه یا سبک‌های جعبه متن ارائه حفظ کنید. با تنظیم [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) می‌توانید کنترل کنید که مبدل تا چه حد قواعد ارث‌بری قالب‌بندی را دنبال می‌کند.

نمونه ارائه را از [text-inheritance.pptx](text-inheritance.pptx) دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول آن شامل یک شکل متنی با متن «Inherited text; explicit red 18pt» است. ورودی به‌صورت عمدی از چندین سطح قالب‌بندی استفاده می‌کند:

- سبک متن پیش‌فرض ارائه Calibri با اندازه ۲۸ pt را فراهم می‌کند.
- سبک متن سطح اول فریم متنی متن آبی و کج را فراهم می‌کند.
- پاراگراف به‌صورت صریح متن توپر را تنظیم می‌کند.
- بخش دوم، «explicit red 18pt»، به‌صورت صریح متن قرمز و اندازه ۱۸ pt را تنظیم می‌کند.

مثال کامل زیر همان پاراگراف‌ها را سه بار خروجی می‌گیرد. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) به متد خروجی پاس داده می‌شود و هر نتیجه به‌عنوان یک فایل HTML UTF‑8 جداگانه ذخیره می‌شود:

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

HTML تولید شده CSS زیر را برای اولین بخش «Inherited text; » شامل می‌شود. جدول مربوطه اعلامیه‌های CSS مرتبط را فهرست می‌کند؛ سایر ویژگی‌های تولید شده برای وضوح حذف شده‌اند.

| خروجی | CSS مرتبط برای اولین بخش | ظاهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، توپر، کج با ۲۸ pt در Calibri، اگر این فونت در دسترس باشد. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | متن آبی، توپر، کج؛ صفحه یا مرورگر میزبان فونت و اندازه را فراهم می‌کند. |
| `ParagraphOnly.html` | `font-weight:bold` | متن توپر؛ صفحه یا مرورگر فونت، اندازه، رنگ و سبک کج را تأمین می‌کند. |

بخش دوم `color:#ff0000`، `font-size:18pt` و `font-weight:bold` را در هر سه خروجی حفظ می‌کند. همچنین ایتالیک در خروجی‌های `All` و `TextBox` حفظ می‌شود اما در `ParagraphOnly` نیست. محدود کردن ارث‌بری بنابراین قالب‌بندی صریح اختصاص داده‌شده به پاراگراف یا بخش را حذف نمی‌کند.

فایل‌ها را در یک مرورگر باز کنید تا مقایسه کنید. در دو حالت محدود، ویژگی‌های CSS حذف‌شده توسط سبک‌های صفحه مقصد یا پیش‌فرض مرورگر حل می‌شوند، بنابراین ظاهر نهایی به محل استفاده HTML وابسته است.

### **تولید یک قطعه کلیپ‌بورد HTML**

از [TextToHtmlConversionOptions::setAddClipboardFragmentHeader](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setAddClipboardFragmentHeader) برای انتخاب خروجی از [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) استفاده کنید. با مقدار `false`، متد HTML معمولی برمی‌گرداند. با مقدار `true`، رشتهٔ بازگشتی با یک سرآیند کلیپ‌بورد ویندوز شروع می‌شود. فیلدهای `StartHTML` و `EndHTML` بایت‑آفست‌های UTF‑8 HTML را می‌دهند، در حالی که `StartFragment` و `EndFragment` محتوای قابل چسباندن را مشخص می‌کنند.

این مثال دو پاراگراف قالب‌بندی‌شده را به‌صورت HTML معمولی (`$html`) و به‌صورت قطعه کلیپ‌بورد HTML (`$clipboardHtml`) خروجی می‌گیرد. سپس برنامه می‌تواند این قطعه را به کلیپ بورد سیستم بنویسد. اگر API کلیپ‌بورد بیت‌های خام انتظار دارد، قطعه را به‌صورت UTF‑8 بدون علامت ترتیب بایت (BOM) فراهم کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 400, 100);
    $paragraphs = $shape->getTextFrame()->getParagraphs();
    $paragraphs->clear();
    $paragraphs->addFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

    $options = new TextToHtmlConversionOptions();
    $options->setAddClipboardFragmentHeader(false);
    $html = java_values($paragraphs->exportToHtml(0, $paragraphs->getCount(), $options));

    $options->setAddClipboardFragmentHeader(true);
    $clipboardHtml = java_values($paragraphs->exportToHtml(0, $paragraphs->getCount(), $options));
} finally {
    $presentation->dispose();
}
```

### **رندر یک پاراگراف به عنوان تصویر**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) یک پاراگراف منفرد را به‌صورت مستقیم رندر می‌کند و یک [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) باز می‌گرداند. نتیجه را با [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) در یک فایل یا جریان ذخیره کنید. نیازی به رندر شکل حاوی آن یا برش دستی بیت‌مپ ندارید.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) ممکن است `null` برگرداند اگر پاراگراف در مجموعه والد پیدا نشود، مرزهای رندر معتبری نداشته باشد یا قابل رندر نباشد. پیش از ذخیره‌سازی نتیجه را بررسی کنید و پس از استفاده تصویر بازگردانده‌شده را آزاد کنید.

#### **رندر پاراگراف با مقیاس پیش‌فرض**

مثال از یک ارائه با یک اسلاید استفاده می‌کند که شکل اولین آن یک جعبه متنی با سه پاراگراف است.

![جعبه متنی با سه پاراگراف](paragraph_to_image_input.png)

مثال زیر پاراگراف دوم را با ایندکس ۱ انتخاب می‌کند و بدون پارامترهای مقیاس به [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) فراخوانی می‌کند. ابتدا بررسی می‌کند که شکل پاراگراف مورد نیاز را دارد و رندر یک تصویر برمی‌گرداند، سپس با [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) آن را در قالب PNG ذخیره می‌کند. بلوک `finally` تصویر را پس از استفاده آزاد می‌کند.

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

#### **رندر پاراگراف در سلول جدول با مقیاس‌بندی**

از overload متد [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) که پارامترهای `$scaleX` و `$scaleY` را می‌پذیرد، برای تعیین عوامل مقیاس افقی و عمودی استفاده کنید. مثال زیر یک جدول می‌سازد، پاراگراف را در اولین سلول آن با دو برابر عرض و ارتفاع پیش‌فرض رندر می‌کند و نتیجه را به عنوان تصویر PNG ذخیره می‌کند.

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

عامل مقیاس `1` آن محور را با اندازه پیکسل پیش‌فرض حفظ می‌کند. به‌عنوان مثال، `2` برای هر دو عامل تصویری می‌سازد که عرض و ارتفاع آن تقریباً دو برابر ابعاد پیش‌فرض باشد و به این ترتیب چهار برابر پیکسل داشته باشد. عوامل بزرگ‌تر معمولاً متن شفاف‌تری برای بزرگ‌نمایی یا خروجی با وضوح بالا تولید می‌کنند، اما مصرف حافظه و حجم فایل را نیز افزایش می‌دهند. عوامل زیر `1` تصاویر کوچکتر با جزئیات کمتر تولید می‌کنند. برای حفظ نسبت ابعاد پاراگراف از عوامل برابر استفاده کنید؛ عوامل متفاوت افقی و عمودی خروجی را به‌طور مستقل کش می‌دهند.

رندر کل شکل با [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) همچنان مفید است وقتی خروجی باید پر، مرز یا سایر زمینه‌های بصری شکل را شامل شود. برای تصویر صرفاً شامل پاراگراف، از [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) استفاده کنید.

## **پرسش‌های متداول**

**آیا می‌توانم بسته شدن خطوط داخل یک فریم متنی را کاملاً غیر فعال کنم؟**

بله. با تنظیم [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) بسته شدن را غیرفعال کنید تا خطوط در لبه‌های فریم متنی شکسته نشوند.

**چگونه می‌توانم محدوده دقیق پاراگراف خاصی روی اسلاید را به دست آورم؟**

از [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) برای دریافت مستطیل محاطی پاراگراف استفاده کنید. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) مرزهای یک بخش منفرد را فراهم می‌کند.

**کنترل تراز پاراگراف (چپ، راست، مرکز یا توجیه) در کجا انجام می‌شود؟**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) یک تنظیم سطح پاراگراف است و بر تمام پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی بخش‌های منفرد.

برای تراز عمودی بخش‌های مختلف با اندازه‌های قلم متفاوت در هر خط، به [Align Fonts Within a Line](/slides/fa/php-java/text-formatting/#align-fonts-within-a-line) مراجعه کنید.

**آیا می‌توانم زبان اثبات برای بخشی از پاراگراف تنظیم کنم؟**

بله. با تنظیم [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) برای بخش‌های منفرد، می‌توانید در یک پاراگراف متن را به چندین زبان داشته باشید.