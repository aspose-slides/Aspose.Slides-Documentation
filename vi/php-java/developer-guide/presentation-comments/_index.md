---
title: Quản lý nhận xét bản trình chiếu trong PHP
linktitle: Nhận xét bản trình chiếu
type: docs
weight: 100
url: /vi/php-java/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bản trình chiếu
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- phản hồi nhận xét
- gỡ bỏ nhận xét
- xoá nhận xét
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý nhận xét bản trình chiếu với Aspose.Slides cho PHP qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong các bản trình chiếu PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình chiếu bằng Aspose.Slides for PHP via Java. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với các phản hồi và nhận xét hiện đại, và xóa nhận xét khỏi bản trình chiếu.

Các ví dụ bao phủ các kịch bản đánh giá và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa các nhận xét đã chọn hoặc toàn bộ nhận xét.

Trong PowerPoint, nhận xét xuất hiện dưới dạng chú thích trên các slide. Khi chọn một nhận xét, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

Để yêu cầu hiển thị hoặc ẩn nhận xét khi mở bản trình chiếu mà không thay đổi nội dung nhận xét, xem [Hiển thị hoặc Ẩn Nhận xét Khi Mở Bản trình chiếu](/slides/vi/php-java/presentation-view-properties/).

## **Tại sao nên thêm nhận xét vào bản trình chiếu?**

Bạn có thể sử dụng nhận xét để cung cấp phản hồi và cộng tác với đồng nghiệp khi đánh giá các bản trình chiếu.

Aspose.Slides for PHP via Java cung cấp các API sau để làm việc với nhận xét:

* The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class, cung cấp quyền truy cập vào các tác giả nhận xét của bản trình chiếu.
* The [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) class, đại diện cho các nhận xét liên quan tới một tác giả riêng lẻ.
* The [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) class, cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) class, cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các nhận xét liên quan.

## **Thêm Nhận xét cho Slide**

Ví dụ tạo hai slide và đăng ký một tác giả nhận xét bằng [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/). Nó sử dụng [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) để đặt một nhận xét trên mỗi slide, sau đó lấy các nhận xét của slide đầu tiên cho tác giả đó bằng [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/). Bảng điều khiển hiển thị nội dung của nhận xét đầu tiên hai lần, chứng minh việc truy cập qua cả slide và tác giả, và bản trình chiếu đã lưu chứa cả hai nhận xét.

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

## **Tìm hoặc Tạo Tác Giả Nhận Xét**

Khi một quy trình đánh giá tự động xử lý cùng một bản trình chiếu nhiều lần, hãy tìm kiếm trong bộ sưu tập trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) trước khi thêm tác giả. [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) khớp cả tên và chữ viết tắt và trả về một mảng các tác giả phù hợp, hoặc một mảng rỗng nếu không có kết quả. Ngược lại, [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) chỉ tìm theo tên, bất kể chữ viết tắt. Gọi [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) với một tên và chữ viết tắt đã tồn tại trong bộ sưu tập sẽ ném ngoại lệ.

Ví dụ yêu cầu một tệp bản trình chiếu có ít nhất một slide. Trong mỗi trong hai vòng lặp, nó tái sử dụng tác giả đầu tiên phù hợp, hoặc tạo mới chỉ khi kết quả rỗng. Nếu có nhiều kết quả phù hợp, nó chọn phần tử đầu tiên của mảng mà không hợp nhất hay xóa các tác giả khác. Sau đó nó gọi [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) cho tác giả đã chọn và lưu bản trình chiếu. Vòng lặp thứ hai mở đầu ra của vòng lặp đầu tiên và lặp lại thao tác.

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

Vòng lặp thứ hai thêm một nhận xét khác mà không thêm tác giả mới hoặc xóa các nhận xét hiện có. Tệp cuối cùng, `review_pass_2.pptx`, chứa cả hai nhận xét mới cùng với bất kỳ nhận xét gốc nào. Tái sử dụng một tác giả không loại bỏ trùng lặp nhận xét: để tránh việc liên tục thêm cùng một nhận xét, hãy triển khai phát hiện trùng lặp riêng trước khi thêm.

## **Truy cập Nhận xét Slide**

Ví dụ mở một bản trình chiếu hiện có và đọc bộ sưu tập trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/). Đối với mỗi tác giả, nó lặp qua bộ sưu tập trả về bởi [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) và in số slide, nội dung nhận xét, tên tác giả và thời gian tạo. Bản trình chiếu đầu vào phải chứa nhận xét để tạo ra đầu ra bảng điều khiển.

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

## **Phản hồi Nhận xét**

Một nhận xét cha là nhận xét gốc ở đầu một cây phân cấp phản hồi. Các phương thức [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) và [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) cho phép bạn lấy hoặc đặt cha của một nhận xét.

Ví dụ tạo nhận xét từ hai tác giả và sử dụng [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) để xây dựng phản hồi, bao gồm phản hồi cho một phản hồi khác. Truyền `null` vào [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) sẽ lấy nhận xét từ tất cả các tác giả; bảng điều khiển thụt lề mỗi mục theo độ sâu của nó trong cây phản hồi. Ví dụ lưu toàn bộ cuộc thảo luận, gọi [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) trên nhận xét gốc đầu tiên, và lưu một bản trình chiếu thứ hai với nhận xét đó và các phản hồi của nó đã bị xóa.

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
* Khi phương thức [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) được sử dụng để xóa một nhận xét, tất cả các phản hồi của nhận xét đó cũng sẽ bị xóa.
* Nếu [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm Nhận xét Hiện đại**

Nhận xét hiện đại có thể liên kết với chính slide, với một shape cụ thể, hoặc với một đoạn văn bản trong AutoShape. Phương thức [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) chấp nhận một đối số [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) bên cạnh slide và tọa độ dấu nhận xét.

Khi `null` được truyền cho đối số shape, nhận xét là nhận xét cấp slide. Dấu nhận xét được đặt theo tọa độ đã cung cấp, nhưng không liên kết với shape nào, vì vậy [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) trả về `null`. Khi một [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) được cung cấp, nhận xét sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi mối liên kết shape có thể được lấy qua [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/).

### **Gắn Nhận xét Hiện đại vào Shape**

Ví dụ gọi [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) hai lần: một lần với shape `null` cho nhận xét cấp slide và một lần với một hình chữ nhật làm neo. Đọc [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) in `true` cho kiểm tra null của nhận xét cấp slide và `Revenue title` cho nhận xét đã neo. Cả hai nhận xét đều được lưu cùng bản trình chiếu.

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

### **Gắn Nhận xét vào Các Kiểu Shape Khác nhau**

Bất kỳ đối tượng slide nào được đại diện bởi lớp [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) đều có thể được dùng làm neo shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sử dụng [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) để liên kết một nhận xét với mỗi trong năm kiểu shape: một AutoShape, một picture frame, một group, một connector và một chart. Hình ảnh được nhúng dữ liệu ảnh, vì vậy không cần ảnh bên ngoài. Mỗi nhận xét có vị trí dấu riêng, và bản trình chiếu đã lưu giữ tất cả năm liên kết shape.

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

### **Gắn Nhận xét vào Văn bản và Đặt Trạng thái của Nó**

Đối với một nhận xét hiện đại liên kết với một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), các phương thức [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) và [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) truy cập vị trí bắt đầu của đoạn văn bản đã chọn trong khung văn bản của shape. Các phương thức [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) truy cập độ dài của phần chọn. Cùng nhau, những giá trị này gắn nhận xét với một đoạn văn bản cụ thể bên trong AutoShape.

Các phương thức [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) và [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị từ các hằng số [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/):

- `NotDefined` — không xác định trạng thái hiện đại cụ thể.
- `Active` — nhận xét đang hoạt động.
- `Resolved` — nhận xét đã được giải quyết.
- `Closed` — nhận xét đã đóng.

Ví dụ neo một nhận xét hiện đại vào các từ “quarterly revenue” trong văn bản của một hình chữ nhật. Nó tính vị trí bắt đầu lựa chọn (zero‑based) từ văn bản và truyền vào [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/), sau đó dùng [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) để đặt số ký tự được chọn. Sau khi gọi [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) với `Resolved`, nó lưu và mở lại bản trình chiếu. Bốn kiểm tra trong bảng điều khiển đều in `true`, xác nhận rằng neo shape, phạm vi văn bản và trạng thái đã được giữ nguyên.

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

### **Kiểm tra Nhận xét Hiện đại hiện có**

Ví dụ yêu cầu một bản trình chiếu hiện có chứa các nhận xét hiện đại và in ra nội dung, trạng thái và chi tiết neo của chúng. Để kiểm tra, xác định mỗi nhận xét có phải là một [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) hay không, sau đó xem [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) và [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/). Một shape `null` cho biết đó là nhận xét cấp slide. Đối với neo [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), các phương thức chọn văn bản xác định phạm vi liên quan trong khung văn bản của shape.

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

## **Xóa Nhận xét**

Aspose.Slides for PHP via Java cho phép bạn xóa tất cả nhận xét và các tác giả của chúng khỏi một bản trình chiếu hoặc xóa các nhận xét đã chọn trong khi giữ lại phần còn lại. Các ví dụ dưới đây minh họa cả hai cách và lưu bản trình chiếu đã cập nhật.

### **Xóa Tất cả Nhận xét và Tác Giả Nhận xét**

Ví dụ mở một bản trình chiếu hiện có và gọi [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) cho mỗi tác giả, sau đó gọi [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) để xóa các tác giả. Bản trình chiếu đã lưu không còn chứa nhận xét hoặc tác giả nhận xét nào. Sử dụng một bản trình chiếu có nhận xét để quan sát việc xóa.

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

### **Xóa Nhận xét Cụ thể**

Ví dụ tạo hai nhận xét trên một slide và sử dụng [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) để tìm nhận xét theo từng tác giả. Nó thu thập các nhận xét có nội dung bằng “comment 1” trước khi gọi [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/), tránh thay đổi bộ sưu tập trong quá trình lựa chọn. Bản trình chiếu đã lưu chỉ giữ lại “comment 2”.

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

Có. [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) và [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) truy cập một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bản trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Liệu các cuộc thảo luận dạng chuỗi (reply chains) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/), cho phép tạo chuỗi phản hồi. API không định nghĩa một giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu nhận xét được xác định bằng các tọa độ số thực trong hệ tọa độ của slide, cho phép đặt nó một cách chính xác trên slide.