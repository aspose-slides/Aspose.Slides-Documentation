---
title: مدیریت جعبه‌های متن در ارائه‌ها با استفاده از PHP
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/php-java/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد، شناسایی، فرمت‌بندی و به‌روزرسانی جعبه‌های متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP از طریق Java."
---
## **مقدمه**

در Aspose.Slides برای PHP از طریق Java، متن اسلایدها در چارچوب‌های متنی که متعلق به اشکال هستند ذخیره می‌شود. کلاس [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) نمایانگر رایج‌ترین شکل حامل متن است و متن آن را از طریق متد [AutoShape::getTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#getTextFrame) در دسترس می‌گذارد.

{{% alert color="info" title="Note" %}}
هر شکل خودکار از [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) ارث می‌برد، اما هر شکل خودکار نیست یا از چارچوب متن پشتیبانی نمی‌کند. هنگام پردازش یک ارائه موجود، از `java_instanceof` برای بررسی اینکه یک شکل یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) باشد قبل از دسترسی به متن آن استفاده کنید.
{{% /alert %}}

## **ایجاد جعبه متن در یک اسلاید**

برای ایجاد یک جعبه متن، یک شکل خودکار را به اسلاید اضافه کنید، متن را به چارچوب متن آن اضافه کنید و ارائه را ذخیره کنید. مثال زیر یک جعبه متن مستطیلی ایجاد می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مختصات و ابعادی که به [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) ارسال می‌شوند بر حسب پوینت اندازه‌گیری می‌شوند. [AutoShape::addTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#addTextFrame) چارچوب متن را با متنی که فراهم شده مقداردهی اولیه می‌کند.

## **بررسی وجود شکل جعبه متن**

از متد [AutoShape::isTextBox](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#isTextBox) برای تعیین اینکه آیا یک شکل خودکار به عنوان جعبه متن درنظر گرفته می‌شود استفاده کنید. این مورد زمانی مفید است که یک ارائه شامل هر دو شکل خودکار حامل متن و شکل‌های گرافیکی صرفاً باشد.

![یک جعبه متن و یک شکل](istextbox.png)

مثال زیر هر شکل خودکار را در یک ارائه بازرسی می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

یک شکل خودکار تازه اضافه‌شده تا زمانی که متن غیرخالی داشته باشد، به عنوان جعبه متن محسوب نمی‌شود. می‌توانید آن متن را از طریق [AutoShape::addTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#addTextFrame) یا [TextFrame::setText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#setText) فراهم کنید. افزودن یا اختصاص یک رشته خالی باعث می‌شود [AutoShape::isTextBox](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#isTextBox) مقدار `false` برگرداند:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

دو فراخوانی اول `true` چاپ می‌کنند؛ دو فراخوانی آخر `false` چاپ می‌کنند.

## **یافتن شکلی که چارچوب متن را دارد**

کد عمومی پردازش متن ممکن است یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) دریافت کند بدون اینکه بداند کدام شی ارائه آن را شامل می‌شود. از متد فقط‑خواندنی [TextFrame::getParentShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentShape) برای بازگشت به [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) مالک استفاده کنید.

برای چارچوب متنی که توسط یک شکل خودکار یا شکل دیگری حامل متن مالکیت می‌شود، [TextFrame::getParentShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentShape) مالک را برمی‌گرداند و [TextFrame::getParentCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentCell) مقدار `null` برمی‌گرداند. قبل از دسترسی به مقدار برگردانده‌شده آن را با `java_is_null` بررسی کنید. برای شناسایی هر دو مالک شکل و سلول جدول، شامل اشکالی که به گره‌های SmartArt مربوط می‌شوند، به [جستجو و جایگزینی متن](/slides/fa/php-java/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به جعبه متن**

متد [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setColumnCount) چارچوب متن را به ستون‌ها تقسیم می‌کند، در حالی که [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setColumnSpacing) فاصله بین ستون‌ها را بر حسب پوینت تنظیم می‌کند. هر دو تنظیم متعلق به [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/) هستند و می‌توان از طریق چارچوب متن یک جعبه متن موجود تغییر داد. متن در داخل همان شکل بین ستون‌ها جریان می‌یابد؛ به شکل دیگری ادامه نمی‌یابد.

مثال زیر یک جعبه متن سه‑ستونی با فاصله ۱۰ پوینت بین ستون‌ها ایجاد می‌کند، ارائه را ذخیره می‌کند و تنظیمات ذخیره‌شده را از فایل خروجی می‌خواند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **استخراج متن از ستون‌های جداگانه**

از [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#splitTextByColumns) برای دریافت متنی که به هر ستون بصری در یک چارچوب متن موجود اختصاص یافته استفاده کنید. این متد یک رشته برای هر ستون، به ترتیب خواندن ستونی، برمی‌گرداند. چارچوب متن تک‌ستونی یک آرایه با یک عنصر تولید می‌کند و ستون خالی با رشته خالی نمایان می‌شود. رشته‌ها فقط شامل متن ساده هستند؛ قالب‌بندی سطح بخش حفظ نمی‌شود.

- استخراج متن در حالی که ترتیب خواندن ستون‑محور آن حفظ می‌شود.
- فهرست یا مقایسه محتوای اسلایدهای چندستونی.
- خروجی هر ستون به فایل جداگانه، فیلد پایگاه‌داده یا مقصد دیگر.
- بررسی نحوه توزیع مجدد متن پس از تغییر تعداد ستون‌ها با [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setColumnCount)، فاصله با [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/#setColumnSpacing)، قلم یا اندازه چارچوب متن.

متد متن توزیع‌شده در داخل [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) جاری را گزارش می‌کند؛ به‌صورت خودکار متن را بین اشکال یا جعبه‌های متن جداگانه منتقل نمی‌کند. توزیع ستون ممکن است به قلم‌های موجود و تنظیمات دیگر چیدمان متن وابسته باشد، بنابراین هنگامیکه نتایج سازگار مهم است، اطمینان حاصل کنید که قلم‌های لازم در دسترس باشند.

مثال زیر یک ارائه را بارگذاری می‌کند، اولین شکل خودکار چندستونی با چارچوب متن را پیدا می‌کند، تعداد ستون‌های تنظیم‌شده را می‌خواند و متن هر ستون را در فایل جداگانه می‌نویسد. اشکالی که چارچوب متن ندارند، نادیده گرفته می‌شوند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **به‌روزرسانی متن**

برای به‌روزرسانی متن در سراسر یک ارائه، اسلایدها و اشکال را مرور کنید، شکل‌های خودکار را انتخاب کنید و سپس بخش‌های متنی آن‌ها را ویرایش کنید. کار در سطح بخش به شما امکان می‌دهد هم متن و هم قالب‌بندی کاراکترها را تغییر دهید.

مثال زیر هر رخداد `years` را با `months` در متن شکل‌های خودکار جایگزین می‌کند و هر بخش تحت تأثیر را به حالت بولد در می‌آورد:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

این پیمایش فقط متن را در شکل‌های خودکار به‌روز می‌کند. متنی که در جداول، نمودارها، SmartArt یا اشکال گروهی ذخیره شده است، نیاز به پیمایش مجموعه‌های خاص آن اشیاء دارد.

## **افزودن جعبه متن با پیوند**

یک پیوند می‌تواند به بخش خاصی از متن اختصاص داده شود، به طوری که فقط همان متن به عنوان لینک قابل کلیک عمل کند. از [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) برای ارتباط بخش با URL خارجی استفاده کنید.

مثال زیر متن پیوندی ایجاد می‌کند و آن را در یک ارائه ذخیره می‌ندازد:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**تفاوت جعبه متن با جای‌دار متن در اسلاید مستر یا طرح‌بندی چیست؟**

یک [جای‌دار](/slides/fa/php-java/manage-placeholder/) می‌تواند موقعیت و قالب‌بندی خود را از یک [اسلاید مستر](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) یا [اسلاید طرح‌بندی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) به ارث ببرد. یک جعبه متن معمولی یک شکل مستقل بر روی اسلایدی که ایجاد شده است و هنگام تغییر طرح‌بندی، رفتار جای‌دار را دریافت نمی‌کند.

**چگونه می‌توان متن را جایگزین کرد بدون اینکه متن در نمودارها، جداول یا SmartArt تغییر کند؟**

پیمایش را به اشیاء [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) محدود کنید، همان‌طور که در مثال به‌روزرسانی متن نشان داده شده است. نمودارها، جداول و SmartArt متن را در مدل شیء خود ذخیره می‌کنند، بنابراین توسط آن حلقه تغییر نمی‌یابند.