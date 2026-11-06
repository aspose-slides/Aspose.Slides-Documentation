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
- حذف نظر
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای PHP از طریق Java: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های PowerPoint به‌سرعت و به‌سادگی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides برای PHP از طریق Java مدیریت کنید. انواع اصلی مربوط به نظرات معرفی می‌شود و نحوه افزودن نظر به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها و نظرات مدرن، و حذف نظرات از یک ارائه نشان داده می‌شود.

مثال‌ها سناریوهای رایج بازبینی و همکاری در PowerPoint را پوشش می‌دهند، از جمله اختصاص نظرات به نویسندگان، خواندن متن نظر و متادیتا، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخابی یا همه نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مرتبط با آن را نمایش می‌دهد.

برای درخواست نمایش یا پنهان‌کردن نظرات هنگام باز کردن ارائه بدون تغییر در خود نظرات، به [نمایش یا پنهان‌کردن نظرات هنگام باز کردن یک ارائه](/slides/fa/php-java/presentation-view-properties/) مراجعه کنید.

## **چرا نظرات به ارائه اضافه می‌شوند؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بازبینی ارائه‌ها استفاده کنید.

Aspose.Slides برای PHP از طریق Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* کلاس [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) که اطلاعاتی درباره نویسنده شامل نام، نام‌خانوادگی و نظرات مرتبط را فراهم می‌کند.

## **افزودن نظرات به اسلایدها**

این مثال دو اسلاید ایجاد می‌کند و یک نویسنده نظر را با استفاده از [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) ثبت می‌کند. با استفاده از [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) یک نظر بر روی هر اسلاید قرار می‌دهد، سپس نظرات اسلاید اول برای آن نویسنده را با [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) بازیابی می‌کند. کنسول متن اولین نظر را دو بار نمایش می‌دهد، که دسترسی از طریق اسلاید و نویسنده را نشان می‌دهد، و ارائه ذخیره‌شده شامل هر دو نظر است.

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

## **یافتن یا ایجاد نویسنده نظر**

هنگامی که یک بازبینی خودکار به‌طور مکرر همان ارائه را پردازش می‌کند، قبل از افزودن نویسنده، مجموعه‌ای که توسط [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) برگردانده می‌شود را جستجو کنید. متد [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) هم نام و هم حروف اولیه را مقایسه می‌کند و آرایه‌ای از نویسندگان مطابق برمی‌گرداند، یا آرایه‌ای خالی اگر مطابقتی وجود نداشته باشد. در مقابل، متد [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) فقط بر اساس نام جستجو می‌کند، صرف‌نظر از حروف اولیه. فراخوانی [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) با نام و حروف اولیه‌ای که پیش‌تر در مجموعه موجود است، استثنا پرتاب می‌کند.

این مثال به یک فایل ارائه با حداقل یک اسلاید نیاز دارد. در هر یک از دو عبور، نویسنده‌ی مطابقت یافته‌ی اول را دوباره استفاده می‌کند یا فقط زمانی که نتیجه خالی باشد، نویسنده‌ای جدید می‌سازد. اگر چندین مطابقت وجود داشته باشد، اولین عنصر آرایه را بدون ادغام یا حذف سایر نویسندگان انتخاب می‌کند. سپس برای نویسنده انتخاب شده [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) را فراخوانی می‌کند و ارائه را ذخیره می‌نماید. عبور دوم خروجی عبور اول را باز می‌کند و عملیات را تکرار می‌نماید.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

عبور دوم یک نظر دیگر اضافه می‌کند بدون اینکه نویسنده دیگری اضافه یا نظرات موجود حذف شوند. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را همراه با هر نظر اصلی نگه می‌دارد. استفاده مجدد از یک نویسنده تکراری‌سازی نظرات را حذف نمی‌کند: برای جلوگیری از افزودن مکرر همان نظر، قبل از افزودن آن، تشخیص تکراری جداگانه‌ای پیاده‌سازی کنید.

## **دسترسی به نظرات اسلاید**

این مثال یک ارائه موجود را باز می‌کند و مجموعه‌ای که توسط [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) برگردانده می‌شود را می‌خواند. برای هر نویسنده، مجموعه‌ای که توسط [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) برگردانده می‌شود را پیمایش می‌کند و شماره اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائه ورودی باید حاوی نظرات باشد تا خروجی کنسول تولید شود.

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

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتب پاسخ است. متدهای [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) و [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) امکان دریافت یا تنظیم والد یک نظر را می‌دهند.

این مثال نظراتی از دو نویسنده ایجاد می‌کند و با استفاده از [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) پاسخ‌ها را می‌سازد، شامل پاسخی به یک پاسخ دیگر. ارسال `null` به [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) نظرات تمامی نویسندگان را بازیابی می‌کند؛ کنسول هر ورودی را بر اساس عمق آن در سلسله‌مراتب پاسخ‌ها تورفتگی می‌دهد. مثال بحث کامل را ذخیره می‌کند، بر روی اولین نظر ریشه‌ای [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) فراخوانی می‌کند و یک ارائه دوم را با حذف آن نظر و پاسخ‌های مرتبط ذخیره می‌نماید.

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
* وقتی از متد [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌گردند.
* اگر [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) یک مرجع حلقوی ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، یک شکل خاص یا یک محدوده متن درون AutoShape وابسته باشند. متد [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) را می‌پذیرد.

زمانی که برای آرگومان shape مقدار `null` ارسال شود، نظر یک نظر سطح اسلاید است. نشانگر آن توسط مختصات ارائه‌شده موقعیت‌گیری می‌شود، اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) مقدار `null` برمی‌گرداند. وقتی یک [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر بر روی اسلاید را تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

این مثال دو بار [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) را فراخوانی می‌کند: یک بار با shape `null` برای یک نظر سطح اسلاید و یک بار با یک مستطیل به‌عنوان لنگر. خواندن [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) برای نظر سطح اسلاید مقدار `true` برای بررسی null و برای نظر متصل به شکل مقدار `Revenue title` چاپ می‌کند. هر دو نظر با ارائه ذخیره می‌شوند.

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

### **اتصال نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که توسط کلاس [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) نشان داده می‌شود می‌تواند به‌عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) مانند نمودارها هستند.

این مثال از [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) برای ارتباط یک نظر با هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک picture frame، یک group، یک connector و یک chart. تصویر از داده‌های تصویری توکار استفاده می‌کند، بنابراین نیازی به تصویر خارجی نیست. هر نظر موقعیت نشانگر خود را دارد و ارائه ذخیره‌شده تمام پنج ارتباط شکل را نگه می‌دارد.

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

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)، متدهای [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) و [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) موقعیت شروع متن انتخاب‌شده در فریم متن شکل را دسترسی می‌دهند. متدهای [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) طول انتخاب را برمی‌گردانند. ترکیب این مقادیر نظر را به محدوده متنی خاصی درون AutoShape پیوند می‌دهد.

متدهای [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) و [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) مقداری از ثابت‌های [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) را برمی‌گردانند:

- `NotDefined` — وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل‌شده است.
- `Closed` — نظر بسته است.

این مثال یک نظر مدرن را به واژه‌های «quarterly revenue» در متن یک مستطیل متصل می‌کند. شروع انتخاب صفر‑مبنا را از متن محاسبه می‌کند و به [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) می‌فرستد و با استفاده از [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) تعداد کاراکترهای انتخاب‌شده را تنظیم می‌کند. پس از فراخوانی [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) با مقدار `Resolved`، ارائه را ذخیره و مجدداً باز می‌کند. چهار بررسی کنسولی باید هر کدام `true` چاپ کنند و تأیید کنند که لنگر شکل، محدوده متن و وضعیت حفظ شده‌اند.

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

این مثال به یک ارائه موجود حاوی نظرات مدرن نیاز دارد و متن، وضعیت و جزئیات لنگر آن‌ها را چاپ می‌کند. برای بررسی، ابتدا بررسی می‌شود که هر نظر یک [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) است یا نه، سپس [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/)، [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/)، [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) بررسی می‌شود. یک shape `null` نشان‌دهنده‌ی نظر سطح اسلاید است. برای یک لنگر [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) متدهای انتخاب متن محدوده متنی مرتبط در فریم متن شکل را شناسایی می‌کنند.

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

Aspose.Slides برای PHP از طریق Java امکان حذف تمام نظرات و نویسندگان آن‌ها از یک ارائه یا حذف نظرات انتخابی در حالی که بقیه حفظ می‌شوند را می‌دهد. مثال‌های زیر هر دو روش را نشان می‌دهند و ارائه به‌روز شده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

این مثال یک ارائه موجود را باز می‌کند و برای هر نویسنده [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) را فراخوانی می‌کند، سپس [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) را برای حذف خود نویسندگان فراخوانی می‌کند. ارائه ذخیره‌شده هیچ نظری یا نویسنده نظری در بر ندارد. برای مشاهده حذف، از ارائه‌ای حاوی نظرات استفاده کنید.

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

این مثال دو نظر بر روی یک اسلاید ایجاد می‌کند و با استفاده از [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) نظرات هر نویسنده را پیدا می‌کند. نظراتی که متن آن‌ها برابر «comment 1» است جمع‌آوری می‌کند قبل از آنکه [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) فراخوانی شود، تا از تغییر مجموعه در حین انتخاب جلوگیری شود. ارائه ذخیره‌شده تنها «comment 2» را نگه می‌دارد.

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

**آیا Aspose.Slides از وضعیت حل‌شده برای نظرات مدرن پشتیبانی می‌کند؟**

بله. متدهای [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) و [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) مقدار یک [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) را باز می‌گردانند، از جمله `Resolved`. این وضعیت در ارائه ذخیره می‌شود و پس از باز کردن مجدد فایل می‌توان دوباره آن را خواند.

**آیا بحث‌های سلسله‌مراتبی (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تویی وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) خود ارجاع دهد، که امکان ایجاد زنجیره‌های پاسخ را می‌دهد. API محدودیت خاصی برای عمق تو در تویی تعریف نمی‌کند.

**موقعیت نشانگر یک نظر بر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر با مختصات نقطه شناور (floating‑point) در سیستم مختصات اسلاید تعریف می‌شود، که امکان قرار دادن دقیق آن بر روی اسلاید را می‌دهد.