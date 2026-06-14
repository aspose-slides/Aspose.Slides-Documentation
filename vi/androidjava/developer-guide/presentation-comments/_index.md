---
title: Quản lý nhận xét bản trình bày trên Android
linktitle: Nhận xét bản trình bày
type: docs
weight: 100
url: /vi/androidjava/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bản trình bày
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- phản hồi nhận xét
- xóa nhận xét
- xóa nhận xét
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Quản lý nhận xét bản trình bày với Aspose.Slides cho Android qua Java: thêm, đọc, chỉnh sửa và xóa nhận xét trong tệp PowerPoint nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình bày bằng Aspose.Slides. Nó mô tả các kiểu dữ liệu liên quan tới nhận xét và minh họa cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với các phản hồi, sử dụng nhận xét hiện đại và xóa nhận xét khỏi bản trình bày.

Các ví dụ tập trung vào các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa tất cả nhận xét hoặc xóa những nhận xét đã chọn.

Trong PowerPoint, một nhận xét hiển thị như một ghi chú hoặc chú thích trên slide. Khi nhấp vào một nhận xét, nội dung hoặc tin nhắn của nó sẽ được hiển thị.

### **Tại sao nên thêm nhận xét vào bản trình bày?**

Bạn có thể muốn sử dụng nhận xét để đưa ra phản hồi hoặc giao tiếp với đồng nghiệp khi xem xét bản trình bày.

Để cho phép bạn sử dụng nhận xét trong các bản trình bày PowerPoint, Aspose.Slides for Android via Java cung cấp

* Lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) chứa các bộ sưu tập tác giả (từ giao diện [ICommentAuthorCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICommentAuthorCollection)). Các tác giả thêm nhận xét vào slide.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICommentCollection) chứa bộ sưu tập nhận xét cho từng tác giả.
* Lớp [IComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IComment) chứa thông tin về tác giả và nhận xét của họ: người đã thêm nhận xét, thời gian thêm, vị trí nhận xét, v.v.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/CommentAuthor) chứa thông tin về từng tác giả: tên tác giả, viết tắt, các nhận xét liên quan đến tên tác giả, v.v.

## **Thêm nhận xét cho slide**
Đoạn mã Java sau cho bạn biết cách thêm một nhận xét vào slide trong bản trình bày PowerPoint:

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

    // Truy cập nhận xét tại chỉ mục 0 cho slide 1
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // Chọn bộ sưu tập nhận xét của tác giả tại chỉ mục 0
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập nhận xét trên slide**
Đoạn mã Java sau cho bạn biết cách truy cập một nhận xét hiện có trên slide trong bản trình bày PowerPoint:

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
Một nhận xét gốc là nhận xét đầu tiên hoặc gốc trong một chuỗi nhận xét hay phản hồi. Bằng cách sử dụng phương thức [getParentComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IComment#getParentComment--) hoặc [setParentComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IComment)), bạn có thể thiết lập hoặc lấy nhận xét gốc.

Đoạn mã Java sau cho bạn biết cách thêm nhận xét và lấy các phản hồi của chúng:

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

    // Thêm một phản hồi cho phản hồi hiện có
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // Hiển thị cấu trúc nhận xét trên console
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
* Khi phương thức [Remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IComment#remove--) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IComment)) được sử dụng để xóa một nhận xét, các phản hồi của nhận xét đó cũng sẽ bị xóa.
* Nếu việc thiết lập [setParentComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) gây ra tham chiếu vòng, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

## **Thêm nhận xét hiện đại**

Năm 2021, Microsoft giới thiệu *nhận xét hiện đại* trong PowerPoint. Tính năng nhận xét hiện đại cải thiện đáng kể khả năng cộng tác trong PowerPoint. Thông qua nhận xét hiện đại, người dùng PowerPoint có thể giải quyết nhận xét, neo nhận xét vào các đối tượng và văn bản, và tương tác một cách dễ dàng hơn nhiều so với trước đây.

Aspose.Slides hỗ trợ nhận xét hiện đại bằng lớp [ModernComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ModernComment). Các phương thức [addModernComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) và [insertModernComment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) đã được thêm vào lớp [CommentCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/CommentCollection).

Đoạn mã Java sau cho bạn biết cách thêm một nhận xét hiện đại vào slide trong bản trình bày PowerPoint:

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

## **Xóa một nhận xét**

### **Xóa tất cả nhận xét và tác giả**

Đoạn mã Java sau cho bạn biết cách xóa tất cả nhận xét và tác giả trong một bản trình bày:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // Xóa tất cả nhận xét khỏi bản trình bày
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

Đoạn mã Java sau cho bạn biết cách xóa các nhận xét cụ thể trên một slide:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // thêm nhận xét...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // xóa tất cả nhận xét có chứa văn bản "comment 1" text
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

**Aspose.Slides có hỗ trợ trạng thái như “đã giải quyết” cho nhận xét hiện đại không?**

Có. [Modern comments](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/moderncomment/) cung cấp phương thức [setStatus](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-); bạn có thể ghi lại trạng thái của nhận xét (ví dụ, đánh dấu là đã giải quyết), và trạng thái này sẽ được lưu trong tệp và được PowerPoint nhận diện.

**Có hỗ trợ chuỗi thảo luận (chuỗi phản hồi) không, và có giới hạn mức lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/comment/#getParentComment--), cho phép tạo chuỗi phản hồi tùy ý. API không quy định giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được xác định trong hệ tọa độ nào?**

Vị trí được lưu dưới dạng một điểm số thực trong hệ tọa độ của slide. Điều này cho phép bạn đặt dấu nhận xét chính xác tại vị trí mong muốn.