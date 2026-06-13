---
title: مدیریت پاراگراف‌های متن PowerPoint در PHP
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/php-java/manage-paragraph/
keywords:
- اضافه کردن متن
- اضافه کردن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی آویزان
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌ای
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادر کردن پاراگراف
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قالب‌بندی پیشرفته پاراگراف‌ها با Aspose.Slides برای PHP از طریق Java — بهبود تراز، فواصل و سبک در ارائه‌های PPT، PPTX و ODP."
---
## **معرفی**

Aspose.Slides تمام کلاس‌هایی را که برای کار با متن‌ها، پاراگراف‌ها و بخش‌های PowerPoint نیاز دارید، فراهم می‌کند.

* Aspose.Slides کلاس [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) را ارائه می‌دهد تا به شما امکان افزودن اشیایی که نمایانگر یک پاراگراف هستند را بدهد. یک شی `TextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف با یک بازگشت carriage ایجاد می‌شود).
* Aspose.Slides کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) را ارائه می‌دهد تا به شما امکان افزودن اشیایی که نمایانگر بخش‌ها هستند را بدهد. یک شی `Paragraph` می‌تواند یک یا چند بخش داشته باشد (مجموعه‌ای از اشیای Portion).
* Aspose.Slides کلاس [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) را ارائه می‌دهد تا به شما امکان افزودن اشیایی که نمایانگر متن‌ها و ویژگی‌های قالب‌بندی آن‌ها هستند را بدهد.

یک شی `Paragraph` قادر است متن‌ها را با ویژگی‌های قالب‌بندی متفاوت از طریق اشیای زیرین `Portion` خود مدیریت کند.

## **افزودن چندین پاراگراف شامل چندین بخش**

این مراحل نشان می‌دهند چگونه یک فریم متنی حاوی 3 پاراگراف و هر پاراگراف شامل 3 بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مورد نظر دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. `ITextFrame` مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) را دریافت کنید.
5. دو شیء [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید و آن‌ها را به مجموعه پاراگراف‌های [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) اضافه کنید.
6. برای هر `Paragraph` جدید سه شیء [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) (دو شیء Portion برای پاراگراف پیش‌فرض) ایجاد کنید و هر شیء `Portion` را به مجموعه بخش‌های هر `Paragraph` اضافه کنید.
7. برای هر بخش متنی تنظیم کنید.
8. ویژگی‌های قالب‌بندی دلخواه خود را با استفاده از ویژگی‌های قالب‌بندی موجود در شیء `Portion` به هر بخش اعمال کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

این کد PHP یک پیاده‌سازی از مراحل افزودن پاراگراف‌های حاوی بخش‌ها است:

```php
# یک شی از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PPTX است
$pres = new Presentation();
try {
    # دسترسی به اسلاید اول
    $slide = $pres->getSlides()->get_Item(0);
    # یک AutoShape از نوع Rectangle اضافه کنید
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # دسترسی به TextFrame شکل AutoShape
    $tf = $ashp->getTextFrame();
    # ایجاد Paragraph و Portion با قالب‌بندی‌های متنی مختلف
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
    # ذخیره PPTX بر روی دیسک
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **مدیریت گلوله‌های پاراگراف**

فهرست‌های گلوله‌ای به شما کمک می‌کنند اطلاعات را به‌سرعت و به‌صورت کارآمد سازماندهی و ارائه دهید. پاراگراف‌های گلوله‌ای همیشه خواندن و درک آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مورد نظر دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین شیء پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید.
7. `Type` گلوله را برای پاراگراف به `Symbol` تنظیم کنید و کاراکتر گلوله را تعیین کنید.
8. `Text` پاراگراف را تنظیم کنید.
9. `Indent` پاراگراف برای گلوله را تنظیم کنید.
10. رنگی برای گلوله تعیین کنید.
11. ارتفاع گلوله را تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و فرآیند مراحل 7 تا 13 را تکرار کنید.
14. ارائه را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک گلوله پاراگراف اضافه کنید:

```php
# یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد می‌کند
$pres = new Presentation();
try {
    # اسلاید اول را می‌خواند
    $slide = $pres->getSlides()->get_Item(0);
    # یک AutoShape اضافه می‌کند و به آن دسترسی پیدا می‌کند
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # فریم متنی autoshape را دسترسی می‌دهد
    $txtFrm = $aShp->getTextFrame();
    # پاراگراف پیش‌فرض را حذف می‌کند
    $txtFrm->getParagraphs()->removeAt(0);
    # یک پاراگراف ایجاد می‌کند
    $para = new Paragraph();
    # سبک و نماد گلوله پاراگراف را تنظیم می‌کند
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # متن پاراگراف را تنظیم می‌کند
    $para->setText("Welcome to Aspose.Slides");
    # تورفتگی گلوله را تنظیم می‌کند
    $para->getParagraphFormat()->setIndent(25);
    # رنگ گلوله را تنظیم می‌کند
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// برای استفاده از رنگ خود گلوله IsBulletHardColor را به true تنظیم می‌کند

    # ارتفاع گلوله را تنظیم می‌کند
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # پاراگراف را به فریم متنی اضافه می‌کند
    $txtFrm->getParagraphs()->add($para);
    # پاراگراف دوم را ایجاد می‌کند
    $para2 = new Paragraph();
    # نوع و سبک گلوله پاراگراف را تنظیم می‌کند
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # متن پاراگراف را اضافه می‌کند
    $para2->setText("This is numbered bullet");
    # تورفتگی گلوله را تنظیم می‌کند
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// برای استفاده از رنگ خود گلوله IsBulletHardColor را به true تنظیم می‌کند

    # ارتفاع گلوله را تنظیم می‌کند
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # پاراگراف را به فریم متنی اضافه می‌کند
    $txtFrm->getParagraphs()->add($para2);
    # ارائه اصلاح‌شده را ذخیره می‌کند
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **مدیریت گلوله‌های تصویری**

فهرست‌های گلوله‌ای به شما کمک می‌کنند اطلاعات را به‌سرعت و به‌صورت کارآمد سازماندهی و ارائه دهید. پاراگراف‌های تصویری خواندن و درک آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مورد نظر دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین شیء پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را در [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) بارگذاری کنید.
8. نوع گلوله را به [Picture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bullettype/#Picture) تنظیم کنید و تصویر را تعیین کنید.
9. `Text` پاراگراف را تنظیم کنید.
10. `Indent` پاراگراف برای گلوله را تنظیم کنید.
11. رنگی برای گلوله تعیین کنید.
12. ارتفاع گلوله را تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و فرآیند را بر اساس مراحل قبلی تکرار کنید.
15. ارائه اصلاح‌شده را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه گلوله‌های تصویری را اضافه و مدیریت کنید:

```php
# یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد می‌کند
$presentation = new Presentation();
try {
    # به اسلاید اول دسترسی می‌یابد
    $slide = $presentation->getSlides()->get_Item(0);
    # تصویر مورد استفاده برای گلوله‌ها را ایجاد می‌کند
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # یک AutoShape اضافه می‌کند و به آن دسترسی می‌یابد
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # فریم متنی AutoShape را دسترسی می‌دهد
    $textFrame = $autoShape->getTextFrame();
    # پاراگراف پیش‌فرض را حذف می‌کند
    $textFrame->getParagraphs()->removeAt(0);
    # یک پاراگراف جدید ایجاد می‌کند
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # سبک گلوله پاراگراف و تصویر را تنظیم می‌کند
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # ارتفاع گلوله را تنظیم می‌کند
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # پاراگراف را به فریم متنی اضافه می‌کند
    $textFrame->getParagraphs()->add($paragraph);
    # ارائه را به عنوان فایل PPTX ذخیره می‌کند
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # ارائه را به عنوان فایل PPT ذخیره می‌کند
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **مدیریت گلوله‌های چندسطحی**

فهرست‌های گلوله‌ای به شما کمک می‌کنند اطلاعات را به‌سرعت و به‌صورت کارآمد سازماندهی و ارائه دهید. گلوله‌های چندسطحی خواندن و درک آسان‌تری دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مورد نظر دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) در اسلاید جدید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید و عمق را به 0 تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به 1 تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به 2 تنظیم کنید.
9. چهارمین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به 3 تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائه اصلاح‌شده را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه گلوله‌های چندسطحی را اضافه و مدیریت کنید:

```php
# یک شی از کلاس Presentation که نمایانگر یک فایل PPTX است ایجاد می‌کند
$pres = new Presentation();
try {
    # به اسلاید اول دسترسی می‌یابد
    $slide = $pres->getSlides()->get_Item(0);
    # یک AutoShape اضافه می‌کند و به آن دسترسی می‌یابد
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # فریم متنی AutoShape ایجاد شده را دسترسی می‌دهد
    $text = $aShp->addTextFrame("");
    # پاراگراف پیش‌فرض را پاک می‌کند
    $text->getParagraphs()->clear();
    # پاراگراف اول را اضافه می‌کند
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # سطح گلوله را تنظیم می‌کند
    $para1->getParagraphFormat()->setDepth(0);
    # پاراگراف دوم را اضافه می‌کند
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # سطح گلوله را تنظیم می‌کند
    $para2->getParagraphFormat()->setDepth(1);
    # پاراگراف سوم را اضافه می‌کند
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # سطح گلوله را تنظیم می‌کند
    $para3->getParagraphFormat()->setDepth(2);
    # پاراگراف چهارم را اضافه می‌کند
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # سطح گلوله را تنظیم می‌کند
    $para4->getParagraphFormat()->setDepth(3);
    # پاراگراف‌ها را به مجموعه اضافه می‌کند
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # ارائه را به عنوان فایل PPTX ذخیره می‌کند
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **مدیریت پاراگراف با فهرست شماره‌گذاری سفارشی**

کلاس [BulletFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/) متد [setNumberedBulletStartWith](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) و دیگر متدها را فراهم می‌کند تا بتوانید پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی مدیریت کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدی که شامل پاراگراف است را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) را به 2 تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به 3 تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به 7 تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی اضافه و مدیریت کنید:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # به فریم متنی AutoShape ایجاد شده دسترسی می‌دهد
    $textFrame = $shape->getTextFrame();
    # پاراگراف پیش‌فرض موجود را حذف می‌کند
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

از متد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد تنها خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به راست می‌برد، در حالی که خطوط باقی‌مانده به متن اصلی هم‌راستا می‌مانند.

وقتی نیاز دارید تمام پاراگراف را جابه‌جا کنید، از [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginleft/) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابه‌جا کنید، از [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) استفاده کنید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر تورفتگی مختلفی را برای نشان دادن نحوه تأثیر تورفتگی خط اول بر نحوه چینش پاراگراف اعمال می‌نماید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متنی اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه یک تورفتگی پاراگراف تنظیم کنید:

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

## **تنظیم تورفتگی آویزان برای پاراگراف**

تورفتگی آویزان یک چیدمان پاراگراف است که در آن خط اول نسبت به خطوط دیگر به سمت چپ شروع می‌شود. در Aspose.Slides این اثر با متد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌شود. برای جابه‌جا کردن خط اول به سمت چپ، مقدار تورفتگی را به مقدار منفی تنظیم کنید.

در عمل، [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [ParagraphFormat::setIndent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) موقعیت خط اول نسبت به آن حاشیه را تعیین می‌کند. برای ایجاد تورفتگی آویزان، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` تنظیم کنید.

این قالب‌بندی برای کتاب‌نامه‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌بندی‌شده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول هم‌راستا شوند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setmarginleft/) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setindent/) را تنظیم کنید تا اثر تورفتگی آویزان ایجاد شود.
7. پاراگراف‌ها را به فریم متنی اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی آویزان برای یک پاراگراف تنظیم کنید:

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

## **مدیریت ویژگی‌های اجرا (Run) انتهای پاراگراف**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید حاوی پاراگراف را از طریق موقعیت آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
1. یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) با دو پاراگراف به مستطیل اضافه کنید.
1. ارتفاع فونت و نوع فونت را برای پاراگراف‌ها تنظیم کنید.
1. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
1. ارائه اصلاح‌شده را به عنوان فایل PPTX بنویسید.

این کد PHP نشان می‌دهد چگونه ویژگی‌های End را برای پاراگراف‌ها در PowerPoint تنظیم کنید:

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
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. `AutoShape`‌تان را به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. فایل HTML منبع را در یک TextReader بخوانید.
7. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML را که در TextReader خوانده شده است به [ParagraphCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphcollection/) فریم متنی اضافه کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

این کد PHP یک پیاده‌سازی از مراحل وارد کردن متن‌های HTML در پاراگراف‌ها است:

```php
# یک شی Presentation خالی ایجاد کنید
$pres = new Presentation();
try {
    # به اسلاید پیش‌فرض اول ارائه دسترسی می‌یابد
    $slide = $pres->getSlides()->get_Item(0);
    # یک AutoShape اضافه می‌کند تا محتوای HTML را دربر بگیرد
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # فریم متنی به شکل اضافه می‌کند
    $ashape->addTextFrame("");
    # تمام پاراگراف‌های فریم متنی اضافه شده را پاک می‌کند
    $ashape->getTextFrame()->getParagraphs()->clear();
    # بارگذاری فایل HTML با استفاده از StreamReader
    $tr = new StreamReader("file.html");
    # متن را از StreamReader HTML به فریم متنی اضافه می‌کند
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

Aspose.Slides پشتیبانی پیشرفته‌ای برای صادر کردن متن‌ها (موجود در پاراگراف‌ها) به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. به شکل حاوی متنی که قرار است به HTML صادر شود دسترسی پیدا کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. یک نمونه از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک ایندکس شروعی به StreamWriter بدهید و پاراگراف‌های دلخواه خود را صادر کنید.

این کد PHP نشان می‌دهد چگونه متن‌های پاراگراف PowerPoint را به HTML صادر کنید:

```php
# فایل ارائه را بارگذاری کنید
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # به اسلاید پیش‌فرض اول ارائه دسترسی می‌یابد
    $slide = $pres->getSlides()->get_Item(0);
    # ایندکس مورد نظر
    $index = 0;
    # دسترسی به شکل اضافه‌شده
    $ashape = $slide->getShapes()->get_Item($index);
    # ایجاد فایل خروجی HTML
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # استخراج اولین پاراگراف به صورت HTML
    # نوشتن داده‌های پاراگراف‌ها به HTML با ارائه ایندکس شروع پاراگراف و تعداد کل پاراگراف‌های کپی‌شده
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

در این بخش، دو مثال بررسی می‌شود که نشان می‌دهند چگونه یک پاراگراف متنی، نماینده توسط کلاس [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) را به عنوان تصویر ذخیره کنیم. هر دو مثال شامل دریافت تصویر یک شکل حاوی پاراگراف با استفاده از متدهای `getImage` از کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/)، محاسبه حدود پاراگراف داخل شکل و صادر کردن آن به عنوان تصویر بیت‌مپ می‌شود. این روش‌ها به شما اجازه می‌دهند بخش‌های خاصی از متن را از ارائه‌های PowerPoint استخراج کرده و به‌صورت تصاویر جداگانه ذخیره کنید، که می‌تواند در سناریوهای مختلف مفید باشد.

بیایید فرض کنیم فایلی به نام sample.pptx داریم که یک اسلاید دارد و اولین شکل آن یک جعبه متن حاوی سه پاراگراف است.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

در این مثال، پاراگراف دوم را به‌عنوان تصویر به‌دست می‌آوریم. برای این کار، تصویر شکل را از اسلاید اول ارائه استخراج می‌کنیم و سپس حدود پاراگراف دوم را در فریم متن شکل محاسبه می‌کنیم. سپس پاراگراف بر روی یک تصویر بیت‌مپ جدید بازکشیده می‌شود و به‌صورت PNG ذخیره می‌گردد. این روش به‌ویژه زمانی مفید است که نیاز به ذخیره یک پاراگراف خاص به‌عنوان تصویر جداگانه همراه با ابعاد و قالب‌بندی دقیق متن داشته باشید.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // شکل را در حافظه به عنوان یک بیت‌مپ ذخیره می‌کند.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // یک بیت‌مپ شکل را از حافظه ایجاد می‌کند.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه می‌کند.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // مختصات و اندازه تصویر خروجی را محاسبه می‌کند (حداقل اندازه - 1x1 پیکسل).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // بیت‌مپ شکل را برش می‌دهد تا تنها بیت‌مپ پاراگراف به دست آید.
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

**Example 2**

در این مثال، رویکرد قبلی را با افزودن عوامل مقیاس به تصویر پاراگراف گسترش می‌دهیم. شکل از ارائه استخراج می‌شود و با ضریب مقیاس `2` به‌عنوان تصویر ذخیره می‌گردد. این امکان خروجی با رزولوشن بالاتر را هنگام صادر کردن پاراگراف فراهم می‌کند. سپس حدود پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شود. مقیاس‌بندی می‌تواند به‌ویژه زمانی مفید باشد که تصویر دقیق‌تری مورد نیاز باشد، برای مثال برای استفاده در مواد چاپی با کیفیت بالا.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // شکل را در حافظه به عنوان یک بیت‌مپ با مقیاس ذخیره می‌کند.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // یک بیت‌مپ شکل را از حافظه ایجاد می‌کند.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه می‌کند.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // مختصات و اندازه تصویر خروجی را محاسبه می‌کند (حداقل اندازه – 1x1 پیکسل).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // بیت‌مپ شکل را برش می‌دهد تا فقط بیت‌مپ پاراگراف به دست آید.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **سوالات متداول**

**آیا می‌توانم بسته شدن خطوط داخل یک چارچوب متن را کاملاً غیرفعال کنم؟**

بله. از تنظیمات بسته‌بندی فریم متنی ([setWrapText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/setwraptext/)) استفاده کنید تا بسته‌بندی را خاموش کنید؛ به این ترتیب خطوط در لبه‌های فریم شکسته نمی‌شوند.

**چگونه می‌توانم محدوده دقیق یک پاراگراف خاص را روی اسلاید به دست آورم؟**

می‌توانید مستطیل محدوده‌ی پاراگراف (و حتی یک Portion واحد) را دریافت کنید تا موقعیت و اندازه دقیق آن را روی اسلاید بدانید.

**تنظیمات تراز پاراگراف (چپ/راست/وسط/پراکندگی) در کجا کنترل می‌شود؟**

[Alignment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/setalignment/) یک تنظیم در سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/) است؛ این تنظیم برای کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر Portion جداگانه.

**آیا می‌توانم زبان بررسی املایی را فقط برای بخشی از پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح Portion تنظیم می‌شود ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/#setLanguageId))، بنابراین می‌توانید چندین زبان را داخل یک پاراگراف ترکیب کنید.