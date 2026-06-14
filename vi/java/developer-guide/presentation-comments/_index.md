---
title: Quản lý nhận xét bản trình chiếu trong Java
linktitle: Nhận xét bản trình chiếu
type: docs
weight: 100
url: /vi/java/presentation-comments/
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
- xóa nhận xét
- xóa nhận xét
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Thành thạo quản lý nhận xét bản trình chiếu với Aspose.Slides cho Java: thêm, đọc, chỉnh sửa và xóa nhận xét trong tệp PowerPoint nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình chiếu bằng Aspose.Slides. Nó trình bày các kiểu liên quan đến nhận xét chính và minh họa cách thêm nhận xét vào slide, truy cập các nhận xét hiện có, làm việc với phản hồi, sử dụng nhận xét hiện đại và xóa nhận xét khỏi bản trình chiếu.

Các ví dụ tập trung vào các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa tất cả nhận xét hoặc xóa những nhận xét đã chọn.

Trong PowerPoint, một nhận xét hiển thị dưới dạng ghi chú hoặc chú giải trên một slide. Khi nhấp vào một nhận xét, nội dung hoặc tin nhắn của nó sẽ được hiển thị.

## **Tại sao cần thêm nhận xét vào bản trình chiếu?**

Bạn có thể muốn sử dụng nhận xét để cung cấp phản hồi hoặc giao tiếp với đồng nghiệp khi xem xét các bản trình chiếu.

Để cho phép bạn sử dụng nhận xét trong các bản trình chiếu PowerPoint, Aspose.Slides for Java cung cấp

* Lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa các bộ sưu tập tác giả (từ giao diện [ICommentAuthorCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICommentAuthorCollection)). Các tác giả thêm nhận xét vào slide.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICommentCollection) chứa bộ sưu tập nhận xét cho từng tác giả.
* Lớp [IComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IComment) chứa thông tin về tác giả và nhận xét của họ: ai đã thêm nhận xét, thời gian nhận xét được thêm, vị trí của nhận xét, v.v.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/CommentAuthor) chứa thông tin về từng tác giả: tên tác giả, chữ viết tắt, các nhận xét liên kết với tên tác giả, v.v.

## **Thêm nhận xét vào slide**
Mã Java này cho bạn thấy cách thêm một nhận xét vào slide trong bản trình chiếu PowerPoint:

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation();
try {
    // Thêm một slide trống
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // Thêm một tác giả
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // Đặt vị trí cho các nhận xét
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // Thêm nhận xét slide cho tác giả trên slide 1
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // Thêm nhận xét slide cho tác giả trên slide 2
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // Truy cập ISlide 1
    ISlide slide = pres.getSlides().get_Item(0);

    // Khi truyền null làm đối số, các nhận xét từ tất cả tác giả sẽ được đưa vào slide đã chọn
    IComment[] Comments = slide.getSlideComments(author);

    // Truy cập nhận xét ở chỉ mục 0 cho slide 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Chọn bộ sưu tập nhận xét của Tác giả tại chỉ mục 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập nhận xét của slide**
Mã Java này cho bạn thấy cách truy cập một nhận xét hiện có trên slide trong bản trình chiếu PowerPoint:

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Phản hồi nhận xét**
Một nhận xét cha là nhận xét gốc hoặc cao nhất trong cây phân cấp các nhận xét hoặc phản hồi. Bằng cách sử dụng các phương thức [getParentComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IComment#getParentComment--) hoặc [setParentComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IComment)), bạn có thể đặt hoặc lấy một nhận xét cha.

Mã Java này cho bạn thấy cách thêm nhận xét và lấy phản hồi cho chúng:

```java
Presentation pres = new Presentation();
try {
    // Thêm một nhận xét
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // Thêm một phản hồi cho comment1
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // Thêm một phản hồi khác cho comment1
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // Thêm một phản hồi cho một phản hồi đã tồn tại
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Hiển thị cây phân cấp nhận xét trên console
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // Xóa comment1 và tất cả các phản hồi của nó
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* Khi phương thức [Remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IComment#remove--) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IComment)) được sử dụng để xóa một nhận xét, các phản hồi của nhận xét cũng sẽ bị xóa.
* Nếu việc thiết lập [setParentComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) dẫn đến vòng tham chiếu, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/PptxEditException).
{{% /alert %}}

## **Thêm nhận xét hiện đại**

Vào năm 2021, Microsoft đã giới thiệu *nhận xét hiện đại* trong PowerPoint. Tính năng nhận xét hiện đại cải thiện đáng kể khả năng cộng tác trong PowerPoint. Thông qua nhận xét hiện đại, người dùng PowerPoint có thể giải quyết nhận xét, gắn nhận xét vào các đối tượng và văn bản, và thực hiện tương tác dễ dàng hơn rất nhiều.

Trong phiên bản [Aspose Slides for Java 21.11](https://docs.aspose.com/slides/vi/java/aspose-slides-for-java-21-11-release-notes/), chúng tôi đã triển khai hỗ trợ cho nhận xét hiện đại bằng cách thêm lớp [ModernComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ModernComment). Các phương thức [addModernComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) và [insertModernComment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) đã được thêm vào lớp [CommentCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/CommentCollection).

Mã Java này cho bạn thấy cách thêm một nhận xét hiện đại vào slide trong bản trình chiếu PowerPoint: 

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa nhận xét**

### **Xóa tất cả nhận xét và tác giả**

Mã Java này cho bạn thấy cách xóa tất cả nhận xét và tác giả trong một bản trình chiếu:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Xóa tất cả nhận xét khỏi bản trình chiếu
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // Xóa tất cả tác giả
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Xóa các nhận xét cụ thể**

Mã Java này cho bạn thấy cách xóa các nhận xét cụ thể trên một slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm nhận xét...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // Xóa tất cả các nhận xét chứa văn bản "comment 1"
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái như 'đã giải quyết' cho nhận xét hiện đại không?**

Có. [Modern comments](https://reference.aspose.com/slides/vi/java/com.aspose.slides/moderncomment/) cung cấp phương thức [setStatus](https://reference.aspose.com/slides/vi/java/com.aspose.slides/moderncomment/#setStatus-byte-); bạn có thể ghi trạng thái của [nhận xét](https://reference.aspose.com/slides/vi/java/com.aspose.slides/moderncommentstatus/) (ví dụ, đánh dấu là đã giải quyết), và trạng thái này được lưu trong tệp và được PowerPoint nhận diện.

**Liệu các cuộc thảo luận dạng chuỗi (chuỗi phản hồi) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/comment/#getParentComment--), cho phép tạo chuỗi phản hồi bất kỳ. API không quy định giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí được lưu dưới dạng điểm số thực trong hệ tọa độ của slide. Điều này cho phép bạn đặt dấu nhận xét chính xác tại vị trí mong muốn.