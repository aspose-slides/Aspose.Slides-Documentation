---
title: مدیریت نظرات ارائه در PHP
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/php-java/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات PowerPoint
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- پاک کردن نظر
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای PHP از طریق Java: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های PowerPoint به‌صورت سریع و آسان."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides برای PHP از طریق Java مدیریت کنید. این مقاله انواع اصلی مرتبط با نظرات را معرفی می‌کند و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، به نظرات موجود دسترسی پیدا کنید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

مثال‌ها شامل سناریوهای رایج بررسی و همکاری در PowerPoint می‌شوند، از جمله اختصاص نظرات به نویسندگان، خواندن متن نظرات و متادیتا، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخاب شده یا تمام نظرات.

در PowerPoint، نظرات به عنوان حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مربوط به آن را نمایش می‌دهد.

## **چرا نظرات به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بررسی ارائه‌ها استفاده کنید.

Aspose.Slides for PHP via Java provides the following APIs for working with comments:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentcollection/) که نظرات مرتبط با یک نویسنده را نشان می‌دهد.
* کلاس [Comment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentauthor/) که اطلاعاتی درباره نویسنده شامل نام، حروف اول و نظرات مرتبط را فراهم می‌کند.

## **اضافه کردن نظرات به اسلاید**

مثال زیر نشان می‌دهد چگونه نظراتی به اسلایدهای یک ارائه PowerPoint اضافه کنید:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));
    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دسترسی به نظرات اسلاید**

مثال زیر نشان می‌دهد چگونه به نظرات موجود در یک ارائه PowerPoint دسترسی پیدا کنید:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی در بالای سلسله‌مراتب پاسخ‌ها است. متدهای [Comment::getParentComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/getparentcomment/) و [Comment::setParentComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/setparentcomment/) به شما امکان می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

مثال زیر نشان می‌دهد چگونه پاسخ‌ها را اضافه کنید و سلسله‌مراتب نظرات حاصل را بررسی کنید:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* هنگامی که متد [Comment::remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/remove/) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر [Comment::setParentComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/setparentcomment/) یک ارجاع دایره‌ای ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **اضافه کردن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به یک بازه متنی در داخل AutoShape مرتبط شوند. متد [CommentCollection::addModernComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commentcollection/addmoderncomment/) علاوه بر اسلاید و مختصات علامت‌گذاری نظر، یک پارامتر از نوع [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) را می‌پذیرد.

هنگامی که برای پارامتر shape مقدار `null` ارسال شود، نظر به عنوان یک نظر سطح اسلاید در نظر گرفته می‌شود. علامت آن توسط مختصات ارائه‌شده موقعیت‌گیری می‌شود، اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment::getShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/getshape/) مقدار `null` برمی‌گرداند. وقتی یک [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان مکان علامت نظر را روی اسلاید تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [ModernComment::getShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/getshape/) بازیابی شود.

### **متصل کردن یک نظر مدرن به یک شکل**

مثال زیر یک نظر مدرن سطح اسلاید و یک نظر مدرن متصل به یک AutoShape خاص ایجاد می‌کند. سپس شکل مرتبط با هر نظر را می‌خواند.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **متصل کردن نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که توسط کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) نشان داده می‌شود می‌تواند به عنوان نقطه‌ی اتصال شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/fa/php-java/aspose.slides/connector/) و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/fa/php-java/aspose.slides/graphicalobject/) مانند نمودارها هستند.

مثال زیر چند نوع شکل رایج ایجاد می‌کند و یک نظر مدرن را به هر کدام اختصاص می‌دهد.

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");
    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **متصل کردن نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن که به یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) مرتبط است، متدهای [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/gettextselectionstart/) و [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/settextselectionstart/) موقعیت شروع متن انتخاب‌شده در فریم متنی شکل را برمی‌گردانند. متدهای [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/settextselectionlength/) طول انتخاب را برمی‌گردانند. با ترکیب این مقادیر، نظر به یک بازه متنی خاص داخل AutoShape متصل می‌شود.

متدهای [ModernComment::getStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/getstatus/) و [ModernComment::setStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/setstatus/) مقداری از ثابت‌های [ModernCommentStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncommentstatus/) را دریافت می‌کنند:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته شده است.

مثال زیر یک نظر مدرن متصل به شکل ایجاد می‌کند، آن را به یک بازه متنی پیوست می‌کند، به عنوان حل شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌نماید و پس از باز کردن دوباره فایل، مقادیر را تأیید می‌کند.

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **بررسی نظرات مدرن موجود**

برای بررسی یک ارائه موجود، ابتدا بررسی کنید که هر نظر یک [ModernComment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/) است یا نه، سپس [ModernComment::getShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/getshape/)، [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/gettextselectionstart/)، [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment::getStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/getstatus/) را مورد بررسی قرار دهید. شکل `null` نشان‌دهنده یک نظر سطح اسلاید است. برای یک انتساب به [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) ، متدهای انتخاب متن بازه مرتبط در فریم متنی شکل را شناسایی می‌کنند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **حذف نظرات**

### **حذف تمام نظرات و نویسندگان نظرات**

مثال زیر نشان می‌دهد چگونه تمام نظرات و نویسندگان نظرات را از یک ارائه حذف کنید:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **حذف نظرات خاص**

مثال زیر نشان می‌دهد چگونه نظرات خاصی را از یک اسلاید حذف کنید:

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

**آیا Aspose.Slides وضعیت حل‌شده برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. متدهای [ModernComment::getStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/getstatus/) و [ModernComment::setStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncomment/setstatus/) یک مقدار از [ModernCommentStatus](https://reference.aspose.com/slides/fa/php-java/aspose.slides/moderncommentstatus/) را برمی‌گردانند، از جمله `Resolved`. وضعیت در ارائه ذخیره می‌شود و پس از باز کردن مجدد فایل می‌توان آن را دوباره خواند.

**آیا گفتگوهای سلسله‌دار (زنجیره‌های پاسخ) پشتیبانی می‌شود و آیا محدودیتی برای عمق تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/php-java/aspose.slides/comment/getparentcomment/) خود ارجاع دهد، که امکان ایجاد زنجیره‌های پاسخ را فراهم می‌کند. API محدودیت خاصی برای عمق تو در تویی تعریف نکرده است.

**موقعیت علامت‌گذاری نظر در اسلاید بر پایه چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت علامت‌گذاری توسط مختصات اعشاری در سیستم مختصات اسلاید تعریف می‌شود که به شما امکان می‌دهد دقیقاً آن را روی اسلاید قرار دهید.