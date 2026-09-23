---
title: Quản lý bình luận trong bản trình bày bằng PHP
linktitle: Bình luận bản trình bày
type: docs
weight: 100
url: /vi/php-java/presentation-comments/
keywords:
- bình luận
- bình luận hiện đại
- bình luận PowerPoint
- bình luận bản trình bày
- bình luận slide
- thêm bình luận
- truy cập bình luận
- chỉnh sửa bình luận
- trả lời bình luận
- xóa bình luận
- xoá bình luận
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý bình luận trong bản trình bày với Aspose.Slides cho PHP qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa bình luận trong bản trình chiếu PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trong bản trình bày bằng Aspose.Slides for PHP via Java. Nó giới thiệu các kiểu dữ liệu liên quan đến bình luận chính và trình bày cách thêm bình luận vào slide, truy cập các bình luận hiện có, làm việc với phản hồi và bình luận hiện đại, cũng như xóa bình luận khỏi bản trình bày.

Các ví dụ bao gồm các kịch bản xem xét và cộng tác thường gặp trong PowerPoint, chẳng hạn như gán bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi trả lời, và xóa các bình luận đã chọn hoặc tất cả các bình luận.

Trong PowerPoint, bình luận xuất hiện dưới dạng chú thích trên các slide. Khi chọn một bình luận, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

Để yêu cầu hiển thị hoặc ẩn bình luận khi mở bản trình bày mà không thay đổi nội dung bình luận, xem [Show or Hide Comments When Opening a Presentation](/slides/vi/php-java/presentation-view-properties/).

## **Tại sao cần thêm bình luận vào bản trình bày?**

Bạn có thể sử dụng bình luận để cung cấp phản hồi và cộng tác với đồng nghiệp khi xem xét bản trình bày.

Aspose.Slides for PHP via Java cung cấp các API sau để làm việc với bình luận:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả bình luận của bản trình bày.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/) đại diện cho các bình luận liên quan đến một tác giả riêng lẻ.
* Lớp [Comment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/) cung cấp thông tin về một bình luận, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các bình luận liên quan.

## **Thêm bình luận vào slide**

Ví dụ sau cho thấy cách thêm bình luận vào các slide trong một bản trình bày PowerPoint:

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

## **Truy cập bình luận slide**

Ví dụ sau cho thấy cách truy cập các bình luận hiện có trong một bản trình bày PowerPoint:

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

## **Trả lời bình luận**

Một bình luận gốc là bình luận ban đầu ở đầu một chuỗi trả lời. Các phương thức [Comment::getParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/getparentcomment/) và [Comment::setParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/setparentcomment/) cho phép bạn lấy hoặc đặt bình luận gốc của một bình luận.

Ví dụ sau cho thấy cách thêm phản hồi và kiểm tra cấu trúc cây bình luận được tạo ra:

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

* Khi sử dụng phương thức [Comment::remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/remove/) để xóa một bình luận, tất cả các phản hồi của bình luận đó cũng sẽ bị xóa.
* Nếu [Comment::setParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/setparentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/) sẽ được ném ra.

{{% /alert %}}

## **Thêm bình luận hiện đại**

Bình luận hiện đại có thể được gắn với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một AutoShape. Phương thức [CommentCollection::addModernComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/addmoderncomment/) nhận một đối số [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) bên cạnh slide và tọa độ của dấu đánh dấu bình luận.

Khi truyền `null` cho đối số shape, bình luận sẽ là bình luận cấp slide. Dấu đánh dấu của nó được định vị bằng các tọa độ đã cung cấp, nhưng không gắn với bất kỳ shape nào, vì vậy [ModernComment::getShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getshape/) trả về `null`. Khi cung cấp một [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/), bình luận sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu đánh dấu bình luận trên slide, trong khi liên kết shape có thể được truy xuất qua [ModernComment::getShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getshape/).

### **Neo một bình luận hiện đại vào shape**

Ví dụ sau tạo cả bình luận hiện đại cấp slide và bình luận hiện đại được neo vào một AutoShape cụ thể. Sau đó nó đọc shape liên quan từ mỗi bình luận.

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

### **Neo bình luận vào các loại shape khác nhau**

Bất kỳ đối tượng slide nào được đại diện bằng lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) đều có thể được dùng làm neo shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/) và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/vi/php-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại shape phổ biến và gắn một bình luận hiện đại vào mỗi shape.

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

### **Neo bình luận vào văn bản và đặt trạng thái**

Đối với một bình luận hiện đại được gắn với một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/), các phương thức [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionstart/) và [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/settextselectionstart/) truy cập vị trí bắt đầu của đoạn văn bản được chọn trong khung văn bản của shape. Các phương thức [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/settextselectionlength/) truy cập độ dài của phần chọn. Cùng nhau, các giá trị này gắn bình luận với một đoạn văn bản cụ thể trong AutoShape.

Các phương thức [ModernComment::getStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getstatus/) và [ModernComment::setStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/setstatus/) truy xuất một giá trị từ các hằng số [ModernCommentStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái bình luận hiện đại nào được định nghĩa.
- `Active` — bình luận đang hoạt động.
- `Resolved` — bình luận đã được giải quyết.
- `Closed` — bình luận đã đóng.

Ví dụ sau tạo một bình luận hiện đại được neo vào shape, gắn nó với một đoạn văn bản được chọn, đánh dấu là đã giải quyết, lưu bản trình bày và xác minh các giá trị sau khi mở lại tệp.

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

### **Kiểm tra các bình luận hiện đại hiện có**

Để kiểm tra một bản trình bày hiện có, kiểm tra xem mỗi bình luận có phải là một [ModernComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/) không, sau đó xem xét [ModernComment::getShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment::getStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getstatus/). Một shape `null` cho thấy bình luận cấp slide. Đối với neo [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/), các phương thức lựa chọn văn bản xác định đoạn văn bản liên quan trong khung văn bản của shape.

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

## **Xóa bình luận**

### **Xóa tất cả bình luận và tác giả bình luận**

Ví dụ sau cho thấy cách xóa tất cả các bình luận và tác giả bình luận khỏi một bản trình bày:

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

### **Xóa các bình luận cụ thể**

Ví dụ sau cho thấy cách xóa các bình luận cụ thể khỏi một slide:

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

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho bình luận hiện đại không?**

Có. Các phương thức [ModernComment::getStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/getstatus/) và [ModernComment::setStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái này được lưu trong bản trình bày và có thể đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (reply chains) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/getparentcomment/), cho phép tạo chuỗi trả lời. API không định nghĩa giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu đánh dấu bình luận trên slide được xác định dựa trên hệ tọa độ nào?**

Vị trí dấu đánh dấu được xác định bằng các tọa độ kiểu số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.