---
title: مدیریت فهرست‌های علامت‌دار و شماره‌دار در ارائه‌ها با استفاده از PHP
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/php-java/manage-lists/
keywords:
- نقطه
- فهرست علامت‌دار
- فهرست شماره‌دار
- نقطه نماد
- نقطه تصویری
- نقطه سفارشی
- فهرست چندسطحی
- ایجاد نقطه
- افزودن نقطه
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های علامت‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP via Java ایجاد و قالب‌بندی کنید."
---
## **نمای کلی**

Aspose.Slides for PHP via Java به شما امکان می‌دهد فهرست‌های علامت‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست پاراگرافی است که تنظیمات نقطه آن از طریق قالب‌بندی پاراگراف آن کنترل می‌شود.

از متد [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) است که یک شیء [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) را برمی‌گرداند. با این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد فهرست علامت‌دار با نماد سفارشی
- ایجاد نقطه تصویری
- ایجاد فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد فهرست شماره‌دار
- بازرسی و تغییر قالب‌بندی فهرست در یک ارائه موجود
- خواندن علامت‌ها و شماره‌های واقعی فهرست در کنار متن پاراگراف

## **ایجاد فهرست علامت‌دار**

برای ایجاد یک فهرست علامت‌دار، اشیای [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) اضافه کنید و [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) را به [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) تنظیم کنید. سپس می‌توانید [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar)، [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) و [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) را برای کنترل ظاهر نقطه تنظیم کنید.

کد PHP زیر نشان می‌دهد چگونه یک فهرست علامت‌دار در یک اسلاید ایجاد شود:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![نقطه‌های نمادین](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

برای مواردی که ترتیب موارد مهم است از فهرست‌های شماره‌دار استفاده کنید. [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) را به [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) انتخاب کنید یا با تنظیم [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) فهرست را از مقداری غیر از 1 شروع کنید.

کد PHP زیر نشان می‌دهد چگونه یک فهرست شماره‌دار در یک اسلاید ایجاد شود:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![نقطه‌های شماره‌دار](numbered_bullets.png)

## **ایجاد نقطه تصویری**

Aspose.Slides به شما امکان می‌دهد نماد نقطه معمولی را با یک تصویر جایگزین کنید. نقطه‌های تصویری بهترین کارایی را با تصاویر ساده‌ای که در اندازه کوچک خوانا می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="info" title="Note" %}}
به‌طور ایده‌آل، اگر قصد دارید نماد نقطه معمولی را با یک تصویر جایگزین کنید، بهتر است گرافیک ساده‌ای با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای سفارشی نقطه به‌خوبی کار می‌کنند.

به‌خاطر داشته باشید که تصویر به اندازه بسیار کوچک مقیاس می‌شود. به همین دلیل، قویاً توصیه می‌کنیم تصویری انتخاب کنید که هنگام استفاده به‌عنوان نقطه در فهرست واضح و بصری مؤثر بماند.
{{% /alert %}}

برای ایجاد نقطه تصویری، یک تصویر به [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) اضافه کنید و شیء بازگردانده شده [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) را به [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) اختصاص دهید. قبل از اختصاص تصویر، [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) را به [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) تنظیم کنید.

فرض کنید ما یک «image.png» داریم:

![عکسی برای نقطه‌ها](picture_for_bullets.png)

کد PHP زیر نشان می‌دهد چگونه نقطه‌های تصویری را در یک اسلاید ایجاد کنید:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![نقطه‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو است و به همین ترتیب.

کد PHP زیر نشان می‌دهد چگونه یک فهرست علامت‌دار چندسطحی ایجاد شود:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![فهرست چندسطحی](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) آن را به‌روزرسانی کنید. همان خصوصیت‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند می‌توانند برای بازبینی یا اصلاح فهرست‌های بارگذاری شده از فایل‌های PPT، PPTX یا ODP به‌کار روند.

کد PHP زیر اولین پاراگراف در یک فریم متن را به سبک فهرست شماره‌دار تغییر می‌دهد:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **خواندن مقادیر واقعی نقطه**

هنگام استخراج محتوای ارائه، علامت‌های فهرست را در کنار متن پاراگراف نگه دارید. [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) را فراخوانی کنید و به [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) دسترسی پیدا کنید تا قالب نقطه مؤثر را به‌دست آورید. قبل از خواندن [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)، [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) آن را بررسی کنید.

برای فهرست‌های شماره‌دار، این سه مقدار را متمایز کنید:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) قالب را تعیین می‌کند، مانند اعداد عربی به‌همراه نقطه یا حروف کوچک به‌همراه نقطه.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) شماره شروع را برای گروهی از پاراگراف‌های شماره‌دار مشخص می‌کند.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) نشانگر قالب‌بندی شده را برای یک پاراگراف خاص برمی‌گرداند. برای مثال، دومین مورد در فهرستی که از 5 شروع شده است، `6.` را برمی‌گرداند.

[getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) را برای هر پاراگراف حفظ کنید تا سطح تو در توی آن حفظ شود. نشانگر واقعی تمام سلسله مراتب را کدگذاری نمی‌کند: یک مورد تو در تو می‌تواند `c.` را بازگرداند به‌جای برچسب ترکیبی مانند `6.c.`.

مثال مستقل زیر فهرست‌ها را ایجاد می‌کند، آن‌ها را در یک ارائه ذخیره می‌کند و سپس ارائه را دوباره بارگذاری می‌کند تا متن، عمق، نوع نقطه و مقدار واقعی هر پاراگراف را گزارش دهد. نشانگر تصویر کوچک آبی از SVG درون‌خطی ساخته شده است.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // یک نشانگر تصویری بدون فایل تصویر خارجی ایجاد کنید.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

فهرست‌های منبع در زیر نشان داده شده‌اند.

![فهرست‌های شروع‌شده از 5، موارد حروفی تو در تو و عدد رومی، یک نشانگر نماد، پاراگراف بدون نقطه، و یک نشانگر تصویر آبی](actual_bullet_values.png)

گزارش با نشانگرهای نمایش داده‌شده در PowerPoint مطابقت دارد:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

برای [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/)، [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) مقدار `null` را برمی‌گرداند، نه یک رشته خالی. این انواع را به‌صورت جداگانه پردازش کنید: نوع اول نشانگری ندارد، در حالی که نوع دوم نیاز به استخراج تصویر نقطه به‌صورت جداگانه دارد. یک نقطه تصویری نمی‌تواند تنها با استخراج یک نشانگر متنی بازتولید شود.

## **پرسش‌های متداول**

**آیا فهرست‌های علامت‌دار و شماره‌دار می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را حفظ می‌کند هنگامی که قالب هدف از چیدمان متن و ویژگی‌های نقطه مربوطه پشتیبانی می‌کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که قلم‌های استفاده شده در ارائه، کاراکترهای مورد نیاز شما را پشتیبانی می‌کنند.