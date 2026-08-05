---
title: مدیریت پاراگراف‌های متن پاورپوینت در PHP
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی معلق
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌ای
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صدور پاراگراف
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "بهینه‌سازی قالب‌بندی پاراگراف با Aspose.Slides برای PHP از طریق Java — بهبود تراز، فواصل و سبک در ارائه‌های PPT، PPTX و ODP."
---
## **مقدمه**

Aspose.Slides تمام کلاس‌های مورد نیاز برای کار با متون، پاراگراف‌ها و بخش‌های PowerPoint را فراهم می‌کند.

* Aspose.Slides کلاس [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) را ارائه می‌دهد تا بتوانید اشیائی اضافه کنید که نمایانگر یک پاراگراف هستند. یک شی `TextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف با یک بازگشت carriage ایجاد می‌شود).
* Aspose.Slides کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) را ارائه می‌دهد تا بتوانید اشیائی اضافه کنید که نمایانگر بخش‌ها هستند. یک شی `Paragraph` می‌تواند یک یا چند بخش (مجموعه‌ای از اشیای Portion) داشته باشد.
* Aspose.Slides کلاس [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) را ارائه می‌دهد تا بتوانید اشیائی اضافه کنید که متون و ویژگی‌های قالب‌بندی آن‌ها را نشان می‌دهند.

یک شی `Paragraph` قادر است متونی با ویژگی‌های قالب‌بندی مختلف را از طریق اشیای زیرین `Portion` خود مدیریت کند.

## **افزودن چندین پاراگراف شامل چندین بخش**

این مراحل نشان می‌دهند چگونه یک فریم متن شامل ۳ پاراگراف و هر پاراگراف شامل ۳ بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به ارجاع اسلاید مربوطه از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. `ITextFrame` مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) را دریافت کنید.
5. دو شی [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید و آن‌ها را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) اضافه کنید.
6. برای هر `Paragraph` جدید سه شی [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) (برای پاراگراف پیش‌فرض دو شی Portion) ایجاد کنید و هر شی `Portion` را به مجموعه بخش‌های هر `Paragraph` اضافه کنید.
7. برای هر بخش متنی تنظیم کنید.
8. ویژگی‌های قالب‌بندی دلخواه خود را به هر بخش اعمال کنید با استفاده از ویژگی‌های موجود در شی `Portion`.
9. ارائه تغییر یافته را ذخیره کنید.

این کد PHP پیاده‌سازی مراحل افزودن پاراگراف‌های شامل بخش‌ها است:

```php
# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
$pres = new Presentation();
try {
    # دسترسی به اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape از نوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # دسترسی به TextFrame شکل AutoShape
    $tf = $ashp->getTextFrame();
    # ایجاد پاراگراف‌ها و Portion‌ها با قالب‌بندی متنی متفاوت
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # نوشتن فایل PPTX بر روی دیسک
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **مدیریت گلوله‌های پاراگراف**

فهرست‌های گلوله‌ای به شما کمک می‌کنند اطلاعات را به سرعت و کارآمد سازماندهی و ارائه کنید. پاراگراف‌های دارای گلوله همیشه خواناتر و قابل‌فهم‌تر هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به ارجاع اسلاید مربوطه از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) قالب متن اشکال دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید.
7. ویژگی `Type` گلوله را برای پاراگراف به `Symbol` تنظیم کنید و کاراکتر گلوله را تعیین کنید.
8. متن پاراگراف را تنظیم کنید.
9. مقدار `Indent` پاراگراف را برای گلوله تنظیم کنید.
10. رنگی برای گلوله تعیین کنید.
11. ارتفاع گلوله را تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و فرآیند مراحل ۷ تا ۱۳ را تکرار کنید.
14. ارائه را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک گلوله پاراگراف اضافه کنید:

```php
# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
$pres = new Presentation();
try {
    # دسترسی به اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن و دسترسی به Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # دسترسی به فریم متن autoshape
    $txtFrm = $aShp->getTextFrame();
    # حذف پاراگراف پیش‌فرض
    $txtFrm->getParagraphs()->removeAt(0);
    # ایجاد پاراگراف
    $para = new Paragraph();
    # تنظیم سبک گلوله پاراگراف و نماد
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # تنظیم متن پاراگراف
    $para->setText("Welcome to Aspose.Slides");
    # تنظیم تورفتگی گلوله
    $para->getParagraphFormat()->setIndent(25);
    # تنظیم رنگ گلوله
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// تنظیم IsBulletHardColor به true برای استفاده از رنگ گلوله سفارشی

    # تنظیم ارتفاع گلوله
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # افزودن پاراگراف به فریم متن
    $txtFrm->getParagraphs()->add($para);
    # ایجاد پاراگراف دوم
    $para2 = new Paragraph();
    # تنظیم نوع و سبک گلوله پاراگراف
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # افزودن متن پاراگراف
    $para2->setText("This is numbered bullet");
    # تنظیم تورفتگی گلوله
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// تنظیم IsBulletHardColor به true برای استفاده از رنگ گلوله سفارشی

    # تنظیم ارتفاع گلوله
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # افزودن پاراگراف به فریم متن
    $txtFrm->getParagraphs()->add($para2);
    # ذخیره ارائه تغییر یافته
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **مدیریت گلوله‌های تصویری**

فهرست‌های گلوله‌ای به شما کمک می‌کنند اطلاعات را به سرعت و کارآمد سازماندهی و ارائه کنید. پاراگراف‌های تصویری به راحتی خوانده می‌شوند و قابل‌فهم هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به ارجاع اسلاید مربوطه از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) قالب متن اشکال دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را با استفاده از [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) بارگذاری کنید.
8. نوع گلوله را به [Picture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/#Picture) تنظیم کنید و تصویر را تعیین کنید.
9. متن پاراگراف را تنظیم کنید.
10. مقدار `Indent` پاراگراف را برای گلوله تنظیم کنید.
11. رنگی برای گلوله تعیین کنید.
12. ارتفاع گلوله را تعیین کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و بر اساس مراحل قبلی فرآیند را تکرار کنید.
15. ارائه تغییر یافته را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه گلوله‌های تصویری را اضافه و مدیریت کنید:

```php
# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
$presentation = new Presentation();
try {
    # دسترسی به اولین اسلاید
    $slide = $presentation->getSlides()->get_Item(0);
    # نمونه‌سازی تصویر برای گلوله‌ها
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # افزودن و دسترسی به Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # دسترسی به فریم متن autoshape
    $textFrame = $autoShape->getTextFrame();
    # حذف پاراگراف پیش‌فرض
    $textFrame->getParagraphs()->removeAt(0);
    # ایجاد یک پاراگراف جدید
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # تنظیم سبک گلوله پاراگراف و تصویر
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # تنظیم ارتفاع گلوله
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # افزودن پاراگراف به فریم متن
    $textFrame->getParagraphs()->add($paragraph);
    # نوشتن ارائه به‌صورت فایل PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # نوشتن ارائه به‌صورت فایل PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **مدیریت گلوله‌های چندسطحی**

فهرست‌های گلوله‌ای به شما کمک می‌کنند اطلاعات را به سرعت و کارآمد سازماندهی و ارائه کنید. گلوله‌های چندسطحی خوانا و قابل‌فهم هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به ارجاع اسلاید مربوطه از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) در اسلاید جدید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) قالب متن اشکال دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید و عمق را به ۰ تنظیم کنید.
7. دومین پاراگراف را با استفاده از کلاس `Paragraph` ایجاد کرده و عمق را به ۱ تنظیم کنید.
8. سومین پاراگراف را با استفاده از کلاس `Paragraph` ایجاد کرده و عمق را به ۲ تنظیم کنید.
9. چهارمین پاراگراف را با استفاده از کلاس `Paragraph` ایجاد کرده و عمق را به ۳ تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائه تغییر یافته را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه گلوله‌های چندسطحی را اضافه و مدیریت کنید:

```php
# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است
$pres = new Presentation();
try {
    # دسترسی به اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن و دسترسی به Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # دسترسی به فریم متن شکل Autoshape ایجاد شده
    $text = $aShp->addTextFrame("");
    # پاک‌سازی پاراگراف پیش‌فرض
    $text->getParagraphs()->clear();
    # افزودن اولین پاراگراف
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تنظیم سطح گلوله
    $para1->getParagraphFormat()->setDepth(0);
    # افزودن پاراگراف دوم
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تنظیم سطح گلوله
    $para2->getParagraphFormat()->setDepth(1);
    # افزودن پاراگراف سوم
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تنظیم سطح گلوله
    $para3->getParagraphFormat()->setDepth(2);
    # افزودن پاراگراف چهارم
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تنظیم سطح گلوله
    $para4->getParagraphFormat()->setDepth(3);
    # افزودن پاراگراف‌ها به مجموعه
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # نوشتن ارائه به‌صورت فایل PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **مدیریت پاراگراف با فهرست شماره‌دار سفارشی**

کلاس [BulletFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/) متد [setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) و سایر متدها را فراهم می‌کند که به شما امکان مدیریت پاراگراف‌ها با شماره‌گذاری یا قالب‌بندی سفارشی را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به اسلایدی که شامل پاراگراف است دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) قالب متن اشکال دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) را روی ۲ تنظیم کنید.
7. دومین پاراگراف را با استفاده از کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را روی ۳ تنظیم کنید.
8. سومین پاراگراف را با استفاده از کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را روی ۷ تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائه تغییر یافته را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی اضافه و مدیریت کنید:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # دسترسی به فریم متن شکل Autoshape ایجاد شده
    $textFrame = $shape->getTextFrame();
    # حذف پاراگراف پیش‌فرض موجود
    $textFrame->getParagraphs()->removeAt(0);
    # فهرست اول
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **تنظیم تورفتگی خط اول برای پاراگراف**

از متد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد تنها خط اول را نسبت به حاشیه چپ پاراگراف جابجا می‌کند. مقدار مثبت خط اول را به راست می‌برد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف تراز می‌شوند.

زمانی که نیاز به جابه‌جایی کل پاراگراف دارید از [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginleft/) استفاده کنید. برای جابه‌جایی فقط خط اول از [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) بهره بگیرید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر تورفتگی متفاوتی را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) را برای هر یک تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف تنظیم شود:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

![The first-line indent of the paragraphs](first_line_indent.png)

## **تنظیم تورفتگی معلق برای پاراگراف**

تورفتگی معلق یک چیدمان پاراگراف است که در آن خط اول نسبت به خطوط باقی‌مانده به سمت چپ آغاز می‌شود. در Aspose.Slides این اثر را با متد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌کنید. مقدار منفی به `Indent` می‌دهد تا خط اول را نسبت به بدنه پاراگراف به چپ منتقل کنید.

در عمل، [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) موقعیت خط اول نسبت به آن حاشیه را تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط پیچیده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول تراز شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginleft/) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) را برای ایجاد اثر تورفتگی معلق تنظیم کنید.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی معلق برای پاراگراف تنظیم شود:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

![The hanging indent of the paragraphs](hanging_indent.png)

## **مدیریت ویژگی‌های End برای پاراگراف**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید حاوی پاراگراف را از طریق موقعیت آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
1. یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) با دو پاراگراف به مستطیل اضافه کنید.
1. ارتفاع و نوع فونت پاراگراف‌ها را تنظیم کنید.
1. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
1. ارائه تغییر یافته را به صورت فایل PPTX بنویسید.

این کد PHP نشان می‌دهد چگونه ویژگی‌های End را برای پاراگراف‌های PowerPoint تنظیم کنید:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **وارد کردن متن HTML به پاراگراف‌ها**

Aspose.Slides پشتیبانی پیشرفته‌ای برای وارد کردن متن HTML به پاراگراف‌ها فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. به ارجاع اسلاید مربوطه از طریق شاخص آن دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) قالب متن AutoShape دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. فایل HTML منبع را در یک TextReader بخوانید.
7. اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML خوانده‌شده در TextReader را به [ParagraphCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphcollection/) فریم متن اضافه کنید.
9. ارائه تغییر یافته را ذخیره کنید.

این کد PHP پیاده‌سازی مراحل وارد کردن متن‌های HTML به پاراگراف‌ها است:

```php
# ایجاد یک نمونه خالی از ارائه
$pres = new Presentation();
try {
    # دسترسی به اسلاید پیش‌فرض اول ارائه
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape برای جای دادن محتوای HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # افزودن فریم متن به شکل
    $ashape->addTextFrame("");
    # پاک‌سازی تمام پاراگراف‌های فریم متن افزودنی
    $ashape->getTextFrame()->getParagraphs()->clear();
    # بارگذاری فایل HTML با استفاده از StreamReader
    $tr = new StreamReader("file.html");
    # افزودن متن از StreamReader HTML به فریم متن
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # ذخیره ارائه
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **صادر کردن متن پاراگراف به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای صادر کردن متون (موجود در پاراگراف‌ها) به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. به ارجاع اسلاید مربوطه از طریق شاخص آن دسترسی پیدا کنید.
3. به شکل حاوی متنی که به HTML صادر خواهد شد دسترسی پیدا کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. یک نمونه از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک ایندکس شروع به StreamWriter بدهید و پاراگراف‌های دلخواه خود را صادر کنید.

این کد PHP نشان می‌دهد چگونه متن‌های پاراگراف PowerPoint را به HTML صادر کنید:

```php
# بارگذاری فایل ارائه
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # دسترسی به اسلاید پیش‌فرض اول ارائه
    $slide = $pres->getSlides()->get_Item(0);
    # شاخص موردنظر
    $index = 0;
    # دسترسی به شکل اضافه‌شده
    $ashape = $slide->getShapes()->get_Item($index);
    # ایجاد فایل خروجی HTML
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # استخراج اولین پاراگراف به صورت HTML
    # نوشتن داده‌های پاراگراف‌ها به HTML با ارائهٔ شاخص شروع پاراگراف و تعداد کل پاراگراف‌های قابل کپی
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **ذخیره یک پاراگراف به عنوان تصویر**

در این بخش دو مثال بررسی می‌شود که نشان می‌دهند چگونه یک پاراگراف متنی، نمایانگر توسط کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) را به صورت تصویر ذخیره کنید. هر دو مثال شامل دریافت تصویر شکل حاوی پاراگراف با استفاده از متدهای `getImage` از کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/)، محاسبه مرزهای پاراگراف داخل شکل و صادر کردن آن به عنوان تصویر بیت‌مپ هستند. این روش‌ها به شما امکان استخراج قسمت‌های خاصی از متن ارائه‌های PowerPoint و ذخیره آن‌ها به صورت تصاویر جداگانه را می‌دهند که می‌تواند در سناریوهای متنوع مفید باشد.

فرض کنید فایلی به نام sample.pptx داریم که شامل یک اسلاید است و اولین شکل آن یک جعبه متن با سه پاراگراف می‌باشد.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال 1**

در این مثال پاراگراف دوم به عنوان تصویر استخراج می‌شود. برای این کار تصویر شکل را از اسلاید اول ارائه استخراج میکنیم و سپس مرزهای پاراگراف دوم در فریم متن شکل را محاسبه می‌کنیم. سپس پاراگراف روی یک تصویر بیت‌مپ جدید رسم می‌شود و به فرمت PNG ذخیره می‌شود. این روش زمانی مفید است که بخواهید پاراگراف خاصی را به عنوان تصویر جداگانه ذخیره کنید در حالی که ابعاد و قالب‌بندی دقیق متن حفظ شود.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // ذخیره شکل در حافظه به‌عنوان یک بیت‌مپ.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // ایجاد بیت‌مپ شکل از حافظه.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // محاسبه مرزهای پاراگراف دوم.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // محاسبه مختصات و اندازه برای تصویر خروجی (حداقل اندازه - 1x1 پیکسل).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // برش بیت‌مپ شکل برای دریافت فقط بیت‌مپ پاراگراف.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

نتیجه:

![The paragraph image](paragraph_to_image_output.png)

**مثال 2**

در این مثال رویکرد قبلی با افزودن عوامل مقیاس به تصویر پاراگراف گسترش می‌یابد. شکل از ارائه استخراج شده و با عامل مقیاس `2` به عنوان تصویر ذخیره می‌شود. این امکان خروجی با وضوح بالاتر را هنگام صادر کردن پاراگراف فراهم می‌کند. سپس مرزهای پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شوند. مقیاس‌بندی به‌ویژه زمانی مفید است که به تصویر دقیق‌تری نیاز باشد، برای مثال برای استفاده در مواد چاپی با کیفیت بالا.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // ذخیره شکل در حافظه به‌عنوان یک بیت‌مپ با مقیاس‌بندی.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // ایجاد بیت‌مپ شکل از حافظه.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // محاسبه مرزهای پاراگراف دوم.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // محاسبه مختصات و اندازه برای تصویر خروجی (حداقل اندازه - 1x1 پیکسل).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // برش بیت‌مپ شکل برای دریافت فقط بیت‌مپ پاراگراف.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **سؤالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل یک فریم متن را به‌طور کامل غیرفعال کنم؟**

بله. از تنظیم بسته‌بندی فریم متن ([setWrapText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/setwraptext/)) استفاده کنید تا بسته‌بندی را خاموش کنید و خطوط در لبه‌های فریم شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق پاراگراف خاصی را روی اسلاید به‌دست آورم؟**

می‌توانید مستطیل محدوده پاراگراف (و حتی یک Portion واحد) را بازیابی کنید تا موقعیت و اندازه دقیق آن را روی اسلاید بدانید.

**کنترل ترازبندی پاراگراف (چپ/ right/center/justify) در کجا انجام می‌شود؟**

[Alignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setalignment/) تنظیمی در سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/) است؛ برای تمام پاراگراف اعمال می‌شود بدون در نظر گرفتن قالب‌بندی هر Portion.

**آیا می‌توانم زبان بررسی املایی را فقط برای بخش خاصی از پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح Portion تنظیم می‌شود ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId))، بنابراین می‌توان چند زبان را در یک پاراگراف همزمان داشته باشید.