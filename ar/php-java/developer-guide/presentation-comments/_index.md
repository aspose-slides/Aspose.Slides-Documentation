---
title: "إدارة تعليقات العروض التقديمية في PHP"
linktitle: "تعليقات العرض التقديمي"
type: docs
weight: 100
url: /ar/php-java/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides للـ PHP عبر Java: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint التقديمية بسرعة وسهولة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. تُقدم الأنواع الرئيسية المتعلقة بالتعليق وتظهر كيفية إضافة تعليقات إلى الشرائح، والوصول إلى التعليقات الموجودة، والعمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتعليقات توضيحية على الشرائح. اختيار تعليق يُظهر نصه والنقاش المرتبط به.

## **لماذا إضافة تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم ملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides للـ PHP عبر Java واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* The [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) class, التي توفر إمكانية الوصول إلى مؤلفي تعليقات العرض التقديمي.
* The [CommentCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/commentcollection/) class, التي تمثل التعليقات المرتبطة بمؤلف فردي.
* The [Comment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/comment/) class, التي توفر معلومات حول التعليق، بما في ذلك المؤلف، وقت الإنشاء، الموقع، والنص.
* The [CommentAuthor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/commentauthor/) class, التي توفر معلومات حول المؤلف، بما في ذلك اسمه، الأحرف الأولية، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

المثال التالي يوضح كيفية إضافة تعليقات إلى الشرائح في عرض PowerPoint:

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

## **الوصول إلى تعليقات الشرائح**

المثال التالي يوضح كيفية الوصول إلى التعليقات الموجودة في عرض PowerPoint:

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

## **الرد على التعليقات**

التعليق الأصلي هو التعليق الأول في تسلسل الردود. طريقتا [Comment::getParentComment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/comment/getparentcomment/) و[Comment::setParentComment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/comment/setparentcomment/) تتيحان لك الحصول على التعليق الأصلي أو تعيينه.

المثال التالي يوضح كيفية إضافة ردود وفحص هيكل التعليقات الناتج:

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

{{% alert color="warning" title="تحذير" %}}
* عند استخدام طريقة [Comment::remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/comment/remove/) لحذف تعليق، يتم حذف جميع الردود على ذلك التعليق أيضًا.
* إذا أدت طريقة [Comment::setParentComment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/comment/setparentcomment/) إلى إنشاء إشارة دائرية، يُرمى استثناء [PptxEditException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشريحة نفسها، أو بشكل معين، أو بنطاق نص داخل AutoShape. طريقة [CommentCollection::addModernComment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/commentcollection/addmoderncomment/) تقبل وسيطًا من النوع [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) بالإضافة إلى إحداثيات الشريحة وعلامة التعليق.

عند تمرير `null` كقيمة للوسيط shape، يكون التعليق تعليقًا على مستوى الشريحة. يتم وضع علامته بالإحداثيات المقدمة، لكنه غير مرتبط بشكل معين، وبالتالي تُعيد الطريقة [ModernComment::getShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/getshape/) القيمة `null`. إذا تم تزويد [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) ، يتم تثبيت التعليق على ذلك الشكل. لا تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، ويمكن استرجاع ارتباط الشكل عبر [ModernComment::getShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/getshape/).

### **تثبيت تعليق حديث على شكل**

المثال التالي ينشئ كلًا من تعليق حديث على مستوى الشريحة وتعليق حديث مثبت على AutoShape معين. ثم يقرأ الشكل المرتبط بكل تعليق.

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

### **تثبيت التعليقات إلى أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة ممثل بفئة [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) كمرساة شكل. تشمل الأمثلة الشائعة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/ar/php-java/aspose.slides/connector/)، و[GraphicalObject](https://reference.aspose.com/slides/ar/php-java/aspose.slides/graphicalobject/) مثل المخططات.

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

### **تثبيت تعليق إلى نص وتحديد حالته**

بالنسبة لتعليق حديث مرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/)، تتيح طريقتا [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/gettextselectionstart/) و[ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/settextselectionstart/) الوصول إلى موضع البداية للنص المحدد في إطار نص الشكل. طريقتا [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/gettextselectionlength/) و[ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/settextselectionlength/) تعيدان طول التحديد. معًا، ترتبط هذه القيم التعليق بنطاق نص محدد داخل AutoShape.

توفر طريقتا [ModernComment::getStatus](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/getstatus/) و[ModernComment::setStatus](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/setstatus/) قيمة من الثوابت [ModernCommentStatus](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — لا يتم تعريف حالة تعليق حديث محددة.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

المثال التالي ينشئ تعليقًا حديثًا مثبتًا على شكل، يربطه بتحديد نص، يضعه كـ "تم حلّه"، يحفظ العرض التقديمي، ويتحقق من القيم بعد فتح الملف مرة أخرى.

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

### **فحص التعليقات الحديثة الموجودة**

لفحص عرض تقديمي موجود، تحقق مما إذا كان كل تعليق هو [ModernComment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/)، ثم استعرض [ModernComment::getShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/getshape/)، [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/gettextselectionstart/)، [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/gettextselectionlength/)، و[ModernComment::getStatus](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/getstatus/). يشير الشكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/)، تحدد طرق تحديد النص النطاق المرتبط بإطار نص الشكل.

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

## **إزالة التعليقات**

### **إزالة جميع التعليقات ومؤلفي التعليقات**

المثال التالي يوضح كيفية إزالة جميع التعليقات ومؤلفي التعليقات من عرض تقديمي:

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

### **إزالة تعليقات محددة**

المثال التالي يوضح كيفية إزالة تعليقات محددة من شريحة:

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

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides حالة تم الحل للتعليقات الحديثة؟**

نعم. طريقتا [ModernComment::getStatus](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/getstatus/) و[ModernComment::setStatus](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncomment/setstatus/) تصلان إلى قيمة من [ModernCommentStatus](https://reference.aspose.com/slides/ar/php-java/aspose.slides/moderncommentstatus/)، بما في ذلك `Resolved`. يتم تخزين الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الرد) وهل هناك حد للتعمق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/comment/getparentcomment/)، مما يتيح سلاسل الرد. لا تحدد واجهة برمجة التطبيقات حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موقع علامة التعليق على الشريحة؟**

يتم تعريف موقع العلامة بإحداثيات ذات نقاط عائمة في نظام إحداثيات الشريحة، مما يسمح بوضعها بدقة على الشريحة.