---
title: مدیریت فهرست‌های بولت‌دار و عددی در ارائه‌ها با استفاده از PHP
linktitle: مدیریت فهرست‌ها
type: docs
weight: 60
url: /fa/php-java/manage-lists/
keywords:
- بولت
- فهرست بولت‌دار
- فهرست عددی
- بولت نمادین
- بولت تصویری
- بولت سفارشی
- فهرست چندسطحی
- ایجاد بولت
- افزودن بولت
- افزودن فهرست
- پاورپوینت
- اسناد باز
- ارائه
- PHP
- Aspose.Slides
description: "بیاموزید چگونه فهرست‌های بولت‌دار، تصویری، چندسطحی و عددی را در ارائه‌های پاورپوینت و اسناد باز ایجاد و قالب‌بندی کنید با استفاده از Aspose.Slides برای PHP از طریق Java."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java به شما امکان می‌دهد تا فهرست‌های بولت‌دار و عددی را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات بولت آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از متد [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/#getParagraphFormat--) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطهٔ ورود اصلی [ParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getBullet--) است که یک شیٔ [BulletFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/) را برمی‌گرداند. با استفاده از این شیٔ می‌توانید نوع بولت، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شمارهٔ شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد فهرست بولت‌دار با نماد سفارشی
- ایجاد بولت تصویری
- ایجاد فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد فهرست عددی
- بازرسی و تغییر قالب‌بندی فهرست در یک ارائه موجود

## **ایجاد فهرست بولت‌دار**

برای ایجاد فهرست بولت‌دار، اشیاء [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) را به یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) اضافه کنید و [BulletFormat.setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setType-int-) را به [BulletType.Symbol](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/#Symbol) تنظیم کنید. سپس می‌توانید [BulletFormat.setChar](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setChar-char-)، [BulletFormat.getColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#getColor--) و [BulletFormat.setHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setHeight-float-) را برای کنترل ظاهر بولت تنظیم کنید.

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

نتیجه:

![بولت‌های نمادین](symbol_bullets.png)

## **ایجاد فهرست عددی**

از فهرست‌های عددی زمانی استفاده کنید که ترتیب موارد مهم است. [BulletFormat.setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setType-int-) را به [BulletType.Numbered](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/#Numbered) تنظیم کنید. همچنین می‌توانید یک قالب شماره‌گذاری را با [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) انتخاب کنید یا با [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) زمانی که فهرست باید از مقداری غیر از 1 شروع شود، تنظیم کنید.

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

نتیجه:

![بولت‌های عددی](numbered_bullets.png)

## **ایجاد بولت تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای که در اندازهٔ کوچک خوانا باقی می‌مانند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="primary" %}}
در حالت ایده‌آل، اگر قصد دارید نماد بولت معمولی را با تصویر جایگزین کنید، بهتر است یک گرافیک ساده با پس‌زمینهٔ شفاف انتخاب کنید. چنین تصاویری به عنوان نمادهای بولت سفارشی بسیار مناسب هستند.

به‌خاطر داشته باشید که تصویر به اندازهٔ بسیار کوچکی مقیاس خواهد شد. به همین دلیل به شدت توصیه می‌کنیم تصویری را انتخاب کنید که در حالت بولت در فهرست واضح و بصری مؤثر بماند.
{{% /alert %}}

برای ایجاد بولت تصویری، یک تصویر به [Presentation.getImages](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getImages--) اضافه کنید و شیٔ بازگشتی [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) را به [BulletFormat.getPicture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#getPicture--) انتساب دهید. قبل از انتساب تصویر، [BulletFormat.setType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/#setType-int-) را به [BulletType.Picture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/#Picture) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![تصویری برای بولت‌ها](picture_for_bullets.png)

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

نتیجه:

![بولت‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#setDepth-short-) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح ۰ بالاترین سطح است، سطح ۱ زیر آن تو در تو می‌شود و به همین ترتیب.

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

نتیجه:

![فهرست چندسطحی](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [ParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getBullet--) آن را به‌روز کنید. همان ویژگی‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند، می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری شده از فایل‌های PPT، PPTX یا ODP به کار روند.

```php
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
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**آیا فهرست‌های بولت‌دار و عددی می‌توانند به PDF یا تصاویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را حفظ می‌کند هنگامی که فرمت هدف از چیدمان متن و ویژگی‌های بولت مربوطه پشتیبانی می‌کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگیری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [ParagraphFormat.getBullet](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/#getBullet--) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن موارد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبان ایجاد کنید. مطمئن شوید فونت‌های استفاده‌شده در ارائه از کاراکترهای مورد نیاز شما پشتیبانی می‌کنند.