---
title: Quản lý bình luận bản trình bày trong JavaScript
linktitle: Bình luận trình chiếu
type: docs
weight: 100
url: /vi/nodejs-java/presentation-comments/
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
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Thành thạo việc quản lý bình luận bản trình bày với Aspose.Slides cho Node.js: thêm, đọc, chỉnh sửa và xóa bình luận trong tệp PowerPoint bằng JavaScript một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý các bình luận trong bản trình bày bằng Aspose.Slides. Nó giới thiệu các kiểu dữ liệu chính liên quan đến bình luận và minh họa cách thêm bình luận vào slide, truy cập các bình luận đã tồn tại, làm việc với các phản hồi, sử dụng bình luận hiện đại và xóa bình luận khỏi một bản trình bày.

Các ví dụ tập trung vào các kịch bản xem xét và cộng tác thông thường trong PowerPoint, chẳng hạn như gán bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi phản hồi, và xóa toàn bộ bình luận hoặc xóa các bình luận đã chọn.

Trong PowerPoint, một bình luận xuất hiện như một ghi chú hoặc chú thích trên slide. Khi nhấp vào bình luận, nội dung hoặc thông điệp của nó sẽ được hiển thị.

## **Tại sao cần thêm bình luận vào bản trình bày?**

Bạn có thể muốn sử dụng bình luận để đưa ra phản hồi hoặc giao tiếp với đồng nghiệp khi xem xét bản trình bày.

Để cho phép bạn sử dụng bình luận trong các bản trình bày PowerPoint, Aspose.Slides for Node.js via Java cung cấp

* Lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa các bộ sưu tập tác giả (từ lớp [CommentAuthorCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommentAuthorCollection)). Các tác giả thêm bình luận vào slide.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommentCollection) chứa tập hợp các bình luận cho từng tác giả.
* Lớp [Comment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Comment) chứa thông tin về tác giả và các bình luận của họ: người đã thêm bình luận, thời gian thêm, vị trí bình luận, v.v.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommentAuthor) chứa thông tin về từng tác giả: tên tác giả, ký tự viết tắt, các bình luận liên quan đến tên tác giả, v.v.

## **Thêm bình luận vào slide**
Mã JavaScript này cho bạn thấy cách thêm một bình luận vào slide trong bản trình bày PowerPoint:

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation();
try {
    // Thêm một slide trống
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // Thêm một tác giả
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // Đặt vị trí cho các bình luận
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // Thêm bình luận slide cho tác giả trên slide 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // Thêm bình luận slide cho tác giả trên slide 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // Truy cập ISlide 1
    var slide = pres.getSlides().get_Item(0);
    // Khi null được truyền làm đối số, các bình luận từ mọi tác giả sẽ được lấy cho slide đã chọn
    var Comments = slide.getSlideComments(author);
    // Truy cập bình luận tại chỉ mục 0 cho slide 1
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // Chọn bộ sưu tập bình luận của Tác giả tại chỉ mục 0
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập bình luận trên slide**
Mã JavaScript này cho bạn thấy cách truy cập một bình luận đã tồn tại trên slide trong bản trình bày PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Trả lời bình luận**
Bình luận gốc là bình luận đầu tiên hoặc gốc trong một cấu trúc phân cấp của các bình luận hoặc phản hồi. Sử dụng các phương thức [getParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Comment#getParentComment--) hoặc [setParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) (từ lớp [Comment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Comment)), bạn có thể lấy hoặc đặt một bình luận gốc.

Mã JavaScript này cho bạn thấy cách thêm bình luận và lấy các phản hồi cho chúng:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Thêm một bình luận
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // Thêm một phản hồi cho comment1
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // Thêm một phản hồi khác cho comment1
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // Thêm một phản hồi cho một phản hồi đã tồn tại
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // Hiển thị cấu trúc cây bình luận trên console
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // Xóa comment1 và tất cả các phản hồi của nó
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Chú ý" %}} 

* Khi phương thức [Remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Comment#remove--) (từ lớp [Comment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Comment)) được sử dụng để xóa một bình luận, các phản hồi của bình luận đó cũng sẽ bị xóa.
* Nếu việc thiết lập [setParentComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) dẫn đến một tham chiếu vòng, [PptxEditException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PptxEditException) sẽ được ném ra.

{{% /alert %}}

## **Thêm bình luận hiện đại**

Năm 2021, Microsoft giới thiệu *bình luận hiện đại* trong PowerPoint. Tính năng bình luận hiện đại cải thiện đáng kể khả năng cộng tác trong PowerPoint. Thông qua bình luận hiện đại, người dùng PowerPoint có thể giải quyết bình luận, gắn bình luận vào đối tượng và văn bản, và tương tác một cách dễ dàng hơn rất nhiều so với trước đây. 

Aspose.Slides hỗ trợ bình luận hiện đại bằng lớp [ModernComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ModernComment). Các phương thức [addModernComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) và [insertModernComment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) đã được thêm vào lớp [CommentCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommentCollection).

Mã JavaScript này cho bạn thấy cách thêm một bình luận hiện đại vào slide trong bản trình bày PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa bình luận**

### **Xóa tất cả bình luận và tác giả**

Mã JavaScript này cho bạn thấy cách xóa toàn bộ bình luận và tác giả trong một bản trình bày:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Xóa tất cả các bình luận khỏi bản trình bày
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // Xóa tất cả các tác giả
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **Xóa các bình luận cụ thể**

Mã JavaScript này cho bạn thấy cách xóa các bình luận cụ thể trên một slide:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // thêm bình luận...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // xóa tất cả các bình luận chứa văn bản "comment 1" text
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái như “đã giải quyết” cho bình luận hiện đại không?**

Có. [Bình luận hiện đại](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/) cung cấp các phương thức [getStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/getstatus/) và [setStatus](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncomment/setStatus/); bạn có thể đọc và đặt [trạng thái của bình luận](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/moderncommentstatus/) (ví dụ, đánh dấu là đã giải quyết), và trạng thái này sẽ được lưu trong tệp và được PowerPoint nhận dạng.

**Các cuộc thảo luận chuỗi (chuỗi phản hồi) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu tới [bình luận gốc](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/comment/getparentcomment/), cho phép tạo ra các chuỗi phản hồi bất kỳ. API không quy định giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu hiệu bình luận trên slide được xác định trong hệ tọa độ nào?**

Vị trí được lưu dưới dạng một điểm số thực trong hệ tọa độ của slide. Điều này cho phép bạn đặt dấu hiệu bình luận chính xác ở vị trí mong muốn.