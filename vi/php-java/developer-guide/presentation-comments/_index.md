---
title: Quản lý nhận xét bài thuyết trình trong PHP
linktitle: Nhận xét bài thuyết trình
type: docs
weight: 100
url: /vi/php-java/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bài thuyết trình
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- trả lời nhận xét
- xóa nhận xét
- xoá nhận xét
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Quản lý nhận xét bài thuyết trình bằng Aspose.Slides cho PHP thông qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong bản trình bày PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bài thuyết trình bằng Aspose.Slides cho PHP thông qua Java. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với trả lời và nhận xét hiện đại, và xóa nhận xét khỏi một bài thuyết trình.

Các ví dụ bao gồm các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi trả lời, và xóa các nhận xét đã chọn hoặc tất cả các nhận xét.

Trong PowerPoint, nhận xét xuất hiện dưới dạng chú thích trên các slide. Khi chọn một nhận xét, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

## **Tại sao cần thêm nhận xét vào bài thuyết trình?**

Bạn có thể sử dụng nhận xét để đưa ra phản hồi và cộng tác với đồng nghiệp khi xem xét bài thuyết trình.

Aspose.Slides cho PHP thông qua Java cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả nhận xét của bài thuyết trình.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/) đại diện cho các nhận xét được liên kết với một tác giả cụ thể.
* Lớp [Comment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/) cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các nhận xét liên quan.

## **Thêm nhận xét vào slide**

Ví dụ sau cho thấy cách thêm nhận xét vào các slide trong một bản trình bày PowerPoint:

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

## **Truy cập nhận xét slide**

Ví dụ sau cho thấy cách truy cập các nhận xét hiện có trong một bản trình bày PowerPoint:

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

## **Trả lời nhận xét**

Một nhận xét cha là nhận xét gốc ở đầu một cây phân cấp trả lời. Các phương thức [Comment::getParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/getparentcomment/) và [Comment::setParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/setparentcomment/) cho phép bạn lấy hoặc đặt cha của một nhận xét.

Ví dụ sau cho thấy cách thêm trả lời và kiểm tra cấu trúc nhận xét kết quả:

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
* Khi phương thức [Comment::remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/remove/) được sử dụng để xóa một nhận xét, tất cả các trả lời cho nhận xét đó cũng sẽ bị xóa.
* Nếu [Comment::setParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/setparentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm nhận xét hiện đại**

Nhận xét hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản trong AutoShape. Phương thức [CommentCollection::addModernComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/addmoderncomment/) nhận một đối số [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) bổ sung cho slide và tọa độ dấu nhận xét.

Khi `null` được truyền cho đối số shape, nhận xét sẽ là nhận xét cấp slide. Dấu nhận xét được định vị bằng các tọa độ đã cung cấp, nhưng nó không được gắn với một shape cụ thể, vì vậy [ModernComment::getShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getshape/) trả về `null`. Khi một [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) được cung cấp, nhận xét sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi mối liên kết shape có thể được lấy thông qua [ModernComment::getShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getshape/).

### **Định vị một nhận xét hiện đại vào hình dạng**

Ví dụ sau tạo cả một nhận xét hiện đại cấp slide và một nhận xét hiện đại được neo vào một AutoShape cụ thể. Sau đó nó đọc shape liên kết từ mỗi nhận xét.

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

### **Định vị nhận xét vào các loại hình dạng khác nhau**

Bất kỳ đối tượng slide nào được đại diện bởi lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) đều có thể được dùng làm neo cho shape. Các ví dụ thường gặp bao gồm [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/vi/php-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sau tạo một vài loại shape phổ biến và gắn một nhận xét hiện đại vào mỗi shape.

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

### **Định vị nhận xét vào văn bản và đặt trạng thái**

Đối với một nhận xét hiện đại được liên kết với một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/), các phương thức [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionstart/) và [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/settextselectionstart/) truy cập vị trí bắt đầu của đoạn văn bản đã chọn trong khung văn bản của shape. Các phương thức [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/settextselectionlength/) truy cập độ dài của đoạn chọn. Cùng nhau, các giá trị này liên kết nhận xét với một đoạn văn bản cụ thể trong AutoShape.

Các phương thức [ModernComment::getStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getstatus/) và [ModernComment::setStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị từ các hằng số [ModernCommentStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — không được xác định — không có trạng thái nhận xét hiện đại cụ thể nào được định nghĩa.
- `Active` — đang hoạt động — nhận xét đang hoạt động.
- `Resolved` — đã giải quyết — nhận xét đã được giải quyết.
- `Closed` — đã đóng — nhận xét đã đóng.

Ví dụ sau tạo một nhận xét hiện đại neo vào shape, liên kết nó với một đoạn văn bản được chọn, đánh dấu là đã giải quyết, lưu bài thuyết trình và xác minh các giá trị sau khi mở lại tệp.

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

### **Kiểm tra nhận xét hiện đại hiện có**

Để kiểm tra một bài thuyết trình hiện có, kiểm tra mỗi nhận xét có phải là [ModernComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/) không, sau đó xem xét [ModernComment::getShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionlength/), và [ModernComment::getStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getstatus/). Một shape `null` cho biết đây là nhận xét cấp slide. Đối với neo vào [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/), các phương thức lựa chọn văn bản xác định phạm vi liên kết trong khung văn bản của shape.

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

## **Xóa nhận xét**

### **Xóa tất cả nhận xét và tác giả nhận xét**

Ví dụ sau cho thấy cách xóa tất cả nhận xét và tác giả nhận xét khỏi một bài thuyết trình:

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

### **Xóa các nhận xét cụ thể**

Ví dụ sau cho thấy cách xóa các nhận xét cụ thể khỏi một slide:

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

## **FAQ**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. Các phương thức [ModernComment::getStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getstatus/) và [ModernComment::setStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái này được lưu trong bài thuyết trình và có thể được đọc lại sau khi tệp được mở lại.

**Liệu các cuộc thảo luận dạng chuỗi (chuỗi trả lời) có được hỗ trợ và có giới hạn độ lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/getparentcomment/), cho phép tạo chuỗi trả lời. API không xác định một giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu nhận xét được định nghĩa bằng các tọa độ số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.