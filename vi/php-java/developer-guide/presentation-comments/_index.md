---
title: Quản lý bình luận trong bài thuyết trình bằng PHP
linktitle: Bình luận bài thuyết trình
type: docs
weight: 100
url: /vi/php-java/presentation-comments/
keywords:
- bình luận
- bình luận hiện đại
- bình luận PowerPoint
- bình luận bài thuyết trình
- bình luận slide
- thêm bình luận
- truy cập bình luận
- chỉnh sửa bình luận
- phản hồi bình luận
- xóa bình luận
- xoá bình luận
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Thành thạo việc quản lý bình luận trong bài thuyết trình với Aspose.Slides cho PHP qua Java: thêm, đọc, chỉnh sửa và xoá bình luận trong file PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trong bài thuyết trình bằng Aspose.Slides. Nó hiển thị các kiểu liên quan đến bình luận chính và trình bày cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với phản hồi, sử dụng bình luận hiện đại, và xóa bình luận khỏi một bài thuyết trình.

Các ví dụ tập trung vào các kịch bản xem xét và cộng tác thông thường trong PowerPoint, chẳng hạn như gán bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi phản hồi, và xóa toàn bộ bình luận hoặc xóa các bình luận đã chọn.

Trong PowerPoint, bình luận xuất hiện như một ghi chú hoặc chú thích trên slide. Khi một bình luận được nhấp, nội dung hoặc tin nhắn của nó sẽ được hiển thị.

## **Tại sao nên thêm bình luận vào bài thuyết trình?**

Bạn có thể muốn sử dụng bình luận để cung cấp phản hồi hoặc giao tiếp với đồng nghiệp khi bạn xem xét các bài thuyết trình.

Để cho phép bạn sử dụng bình luận trong các bài thuyết trình PowerPoint, Aspose.Slides for PHP via Java cung cấp

* Lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) chứa các bộ sưu tập của các tác giả (từ lớp [CommentAuthorCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentauthorcollection/)). Các tác giả thêm bình luận vào các slide.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/) chứa bộ sưu tập các bình luận cho từng tác giả.
* Lớp [Comment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/) chứa thông tin về các tác giả và bình luận của họ: ai đã thêm bình luận, thời gian bình luận được thêm, vị trí của bình luận, v.v.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentauthor/) chứa thông tin về từng tác giả: tên tác giả, chữ viết tắt của họ, các bình luận liên quan tới tên tác giả, v.v.

## **Thêm bình luận vào slide**

Đoạn mã PHP này cho bạn thấy cách thêm một bình luận vào slide trong một bản trình chiếu PowerPoint:

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Thêm một slide trống
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # Thêm một tác giả
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # Đặt vị trí cho các bình luận
    $point = new Point2DFloat(0.2, 0.2);
    # Thêm bình luận slide cho tác giả trên slide 1
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # Thêm bình luận slide cho tác giả trên slide 2
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # Truy cập ISlide 1
    $slide = $pres->getSlides()->get_Item(0);
    # Khi truyền null làm đối số, các bình luận từ tất cả tác giả sẽ được đưa lên slide đã chọn
    $Comments = $slide->getSlideComments($author);
    # Truy cập bình luận tại chỉ mục 0 cho slide 1
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # Chọn bộ sưu tập bình luận của Tác giả tại chỉ mục 0
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Truy cập bình luận của slide**

Đoạn mã PHP này cho bạn thấy cách truy cập một bình luận hiện có trên slide trong một bản trình chiếu PowerPoint:

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Phản hồi bình luận**

Một bình luận gốc là bình luận đầu tiên hoặc gốc trong một cấp độ của các bình luận hoặc phản hồi. Sử dụng các phương pháp [getParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/getparentcomment/) hoặc [setParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/setparentcomment/) (từ lớp [Comment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/)), bạn có thể thiết lập hoặc lấy một bình luận gốc.

Đoạn mã PHP này cho bạn thấy cách thêm bình luận và nhận phản hồi cho chúng:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Thêm một bình luận
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # Thêm một phản hồi cho comment1
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # Thêm một phản hồi khác cho comment1
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # Thêm một phản hồi cho phản hồi đã tồn tại
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # Hiển thị cấu trúc cây bình luận trên console
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # Xóa comment1 và tất cả các phản hồi của nó
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="Attention" %}} 
* Khi phương pháp [remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/remove/) (từ lớp [Comment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/)) được sử dụng để xóa một bình luận, các phản hồi của bình luận cũng sẽ bị xóa.
* Nếu cài đặt [setParentComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/setparentcomment/) tạo ra một tham chiếu vòng, [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm bình luận hiện đại**

Vào năm 2021, Microsoft đã giới thiệu *bình luận hiện đại* trong PowerPoint. Tính năng bình luận hiện đại cải thiện đáng kể việc cộng tác trong PowerPoint. Thông qua bình luận hiện đại, người dùng PowerPoint có thể giải quyết bình luận, gắn bình luận vào các đối tượng và văn bản, và tương tác một cách dễ dàng hơn rất nhiều so với trước đây. 

Aspose Slides hỗ trợ bình luận hiện đại bằng lớp [ModernComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/). Các phương pháp [addModernComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/addmoderncomment/) và [insertModernComment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/insertmoderncomment/) đã được thêm vào lớp [CommentCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/commentcollection/). 

Đoạn mã PHP này cho bạn thấy cách thêm một bình luận hiện đại vào slide trong một bản trình chiếu PowerPoint:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa bình luận**

### **Xóa toàn bộ bình luận và tác giả**

Đoạn mã PHP này cho bạn thấy cách xóa tất cả bình luận và tác giả trong một bản trình chiếu:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # Xóa tất cả bình luận khỏi bài thuyết trình
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # Xóa tất cả tác giả
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Xóa bình luận cụ thể**

Đoạn mã PHP này cho bạn thấy cách xóa các bình luận cụ thể trên một slide:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # thêm bình luận...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # xóa tất cả bình luận chứa văn bản "comment 1"
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái như 'đã giải quyết' cho bình luận hiện đại không?**

Có. [Bình luận hiện đại](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/) cung cấp phương pháp [setStatus](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncomment/setstatus/); bạn có thể ghi lại [trạng thái của bình luận](https://reference.aspose.com/slides/vi/php-java/aspose.slides/moderncommentstatus/) (ví dụ, đánh dấu là đã giải quyết), và trạng thái này được lưu trong tệp và được PowerPoint nhận dạng.

**Các cuộc thảo luận dạng chuỗi (chuỗi phản hồi) có được hỗ trợ không, và có giới hạn độ sâu không?**

Có. Mỗi bình luận có thể tham chiếu đến [bình luận gốc](https://reference.aspose.com/slides/vi/php-java/aspose.slides/comment/getparentcomment/), cho phép tạo chuỗi phản hồi tùy ý. API không quy định giới hạn độ sâu cụ thể.

**Vị trí của dấu đánh dấu bình luận trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí được lưu dưới dạng điểm số thực trong hệ tọa độ của slide. Điều này cho phép bạn đặt dấu đánh dấu bình luận chính xác ở vị trí mong muốn.