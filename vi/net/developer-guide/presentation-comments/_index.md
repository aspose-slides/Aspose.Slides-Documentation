---
title: Quản lý nhận xét bản trình bày trong .NET
linktitle: Nhận xét trình chiếu
type: docs
weight: 100
url: /vi/net/presentation-comments/
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
- xoá nhận xét
- xóa nhận xét
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Quản lý nhận xét bản trình bày một cách chuyên sâu với Aspose.Slides cho .NET: thêm, đọc, chỉnh sửa và xóa nhận xét trong các tệp PowerPoint nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình bày bằng Aspose.Slides. Nó giới thiệu các kiểu dữ liệu liên quan đến nhận xét chính và minh họa cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với phản hồi, sử dụng nhận xét hiện đại và xóa nhận xét khỏi bản trình bày.

Các ví dụ tập trung vào các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi và xoá toàn bộ nhận xét hoặc các nhận xét đã chọn.

Trong PowerPoint, một nhận xét xuất hiện như một ghi chú hoặc chú thích trên slide. Khi nhấp vào nhận xét, nội dung hoặc thông điệp của nó sẽ được hiển thị. 

## **Tại sao cần thêm nhận xét vào bản trình bày?**

Bạn có thể muốn sử dụng nhận xét để đưa ra phản hồi hoặc giao tiếp với đồng nghiệp khi xem xét bản trình bày.

Để cho phép bạn sử dụng nhận xét trong các bản trình bày PowerPoint, Aspose.Slides for .NET cung cấp

* Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation), chứa các bộ sưu tập tác giả (từ thuộc tính [CommentAuthorCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icommentauthorcollection/properties/index)). Các tác giả thêm nhận xét vào slide. 
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/icommentcollection), chứa bộ sưu tập nhận xét cho từng tác giả. 
* Lớp [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment), chứa thông tin về tác giả và các nhận xét của họ: ai đã thêm nhận xét, thời gian thêm, vị trí nhận xét, v.v. 
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/net/aspose.slides/commentauthor), chứa thông tin về từng tác giả: tên tác giả, ký hiệu, các nhận xét liên quan tới tên tác giả, v.v. 

## **Thêm nhận xét vào slide**
Mã C# dưới đây cho thấy cách thêm một nhận xét vào slide trong bản trình bày PowerPoint:

```c#
// Khởi tạo lớp Presentation
using (Presentation presentation = new Presentation())
{
    // Thêm một slide trống
    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

    // Thêm một tác giả
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Jawad", "MF");

    // Đặt vị trí cho các nhận xét
    PointF point = new PointF();
    point.X = 0.2f;
    point.Y = 0.2f;

    // Thêm nhận xét slide cho tác giả trên slide 1
    author.Comments.AddComment("Hello Jawad, this is slide comment", presentation.Slides[0], point, DateTime.Now);

    // Thêm nhận xét slide cho tác giả trên slide 2
    author.Comments.AddComment("Hello Jawad, this is second slide comment", presentation.Slides[1], point, DateTime.Now);

    // Truy cập ISlide 1
    ISlide slide = presentation.Slides[0];

    // Khi truyền null làm đối số, các nhận xét từ tất cả tác giả sẽ được lấy cho slide đã chọn
    IComment[] Comments = slide.GetSlideComments(author);

    // Truy cập nhận xét ở chỉ mục 0 cho slide 1
    String str = Comments[0].Text;

    presentation.Save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.GetLength(0) > 0)
    {
        // Chọn bộ sưu tập nhận xét của tác giả tại chỉ mục 0
        ICommentCollection commentCollection = Comments[0].Author.Comments;
        String Comment = commentCollection[0].Text;
    }
}
```

## **Truy cập nhận xét trên slide**
Mã C# dưới đây cho thấy cách truy cập một nhận xét hiện có trên slide trong bản trình bày PowerPoint:

```c#
// Khởi tạo lớp Presentation
using (Presentation presentation = new Presentation("Comments1.pptx"))
{
    foreach (var commentAuthor in presentation.CommentAuthors)
    {
        var author = (CommentAuthor) commentAuthor;
        foreach (var comment1 in author.Comments)
        {
            var comment = (Comment) comment1;
            Console.WriteLine("ISlide :" + comment.Slide.SlideNumber + " has comment: " + comment.Text + " with Author: " + comment.Author.Name + " posted on time :" + comment.CreatedTime + "\n");
        }
    }
}
```

## **Phản hồi nhận xét**
Một nhận xét cha là nhận xét gốc hoặc nhận xét cấp cao nhất trong một cây nhận xét hoặc phản hồi. Sử dụng thuộc tính [ParentComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/properties/parentcomment) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment)), bạn có thể đặt hoặc lấy nhận xét cha. 

Mã C# dưới đây cho thấy cách thêm nhận xét và lấy các phản hồi cho chúng:

```c#
using (Presentation pres = new Presentation())
{
    // Thêm một nhận xét
    ICommentAuthor author1 = pres.CommentAuthors.AddAuthor("Author_1", "A.A.");
    IComment comment1 = author1.Comments.AddComment("comment1", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    // Thêm một phản hồi cho comment1
    ICommentAuthor author2 = pres.CommentAuthors.AddAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.Comments.AddComment("reply 1 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply1.ParentComment = comment1;

    // Thêm một phản hồi khác cho comment1
    IComment reply2 = author2.Comments.AddComment("reply 2 for comment 1", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply2.ParentComment = comment1;

    // Thêm một phản hồi cho phản hồi hiện có
    IComment subReply = author1.Comments.AddComment("subreply 3 for reply 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    subReply.ParentComment = reply2;

    IComment comment2 = author2.Comments.AddComment("comment 2", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    IComment comment3 = author2.Comments.AddComment("comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);

    IComment reply3 = author1.Comments.AddComment("reply 4 for comment 3", pres.Slides[0], new PointF(10, 10), DateTime.Now);
    reply3.ParentComment = comment3;

    // Hiển thị cây nhận xét trên console
    ISlide slide = pres.Slides[0];
    var comments = slide.GetSlideComments(null);
    for (int i = 0; i < comments.Length; i++)
    {
        IComment comment = comments[i];
        while (comment.ParentComment != null)
        {
            Console.Write("\t");
            comment = comment.ParentComment;
        }

        Console.Write("{0} : {1}", comments[i].Author.Name, comments[i].Text);
        Console.WriteLine();
    }

    pres.Save("parent_comment.pptx",SaveFormat.Pptx);

    // Xóa comment1 và tất cả các phản hồi của nó
    comment1.Remove();

    pres.Save("remove_comment.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" title="Attention" %}} 
* Khi phương thức [Remove](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/methods/remove) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment)) được sử dụng để xóa một nhận xét, các phản hồi của nhận xét cũng sẽ bị xóa. 
* Nếu thiết lập [ParentComment](https://reference.aspose.com/slides/vi/net/aspose.slides/icomment/properties/parentcomment) gây ra vòng tham chiếu, lỗi [PptxEditException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxeditexception) sẽ được ném ra.
{{% /alert %}}

## **Thêm nhận xét hiện đại**

Năm 2021, Microsoft giới thiệu *nhận xét hiện đại* trong PowerPoint. Tính năng nhận xét hiện đại cải thiện đáng kể khả năng cộng tác trong PowerPoint. Thông qua nhận xét hiện đại, người dùng PowerPoint có thể giải quyết nhận xét, gắn nhận xét vào đối tượng và văn bản, và thực hiện tương tác dễ dàng hơn nhiều so với trước đây. 

Trong [Aspose Slides for .NET 21.11](https://docs.aspose.com/slides/vi/net/aspose-slides-for-net-21-11-release-notes/), chúng tôi đã triển khai hỗ trợ cho nhận xét hiện đại bằng cách thêm lớp [ModernComment](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncomment). Các phương thức [AddModernComment](https://reference.aspose.com/slides/vi/net/aspose.slides/commentcollection/methods/addmoderncomment) và [InsertModernComment](https://reference.aspose.com/slides/vi/net/aspose.slides/commentcollection/methods/insertmoderncomment) đã được thêm vào lớp [CommentCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/commentcollection). 

Mã C# dưới đây cho thấy cách thêm một nhận xét hiện đại vào slide trong bản trình bày PowerPoint: 

```c#
using (Presentation pres = new Presentation())
{
     ICommentAuthor newAuthor = pres.CommentAuthors.AddAuthor("Some Author", "SA");
     IModernComment modernComment = newAuthor.Comments.AddModernComment("This is a modern comment", pres.Slides[0], null, new PointF(100, 100), DateTime.Now);
 
     pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Xóa nhận xét**

### **Xóa tất cả nhận xét và tác giả**

Mã C# dưới đây cho thấy cách xóa tất cả nhận xét và tác giả trong một bản trình bày:

```c#
using (var presentation = new Presentation("example.pptx"))
{
    // Xóa tất cả nhận xét khỏi bản trình bày
    foreach (var author in presentation.CommentAuthors)
    {
        author.Comments.Clear();
    }

    // Xóa tất cả tác giả
    presentation.CommentAuthors.Clear();

    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

### **Xóa các nhận xét cụ thể**

Mã C# dưới đây cho thấy cách xóa các nhận xét cụ thể trên một slide:

```c#
using (var presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // thêm nhận xét...
    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "A");
    author.Comments.AddComment("comment 1", slide, new PointF(0.2f, 0.2f), DateTime.Now);
    author.Comments.AddComment("comment 2", slide, new PointF(0.3f, 0.2f), DateTime.Now);
    
    // xóa tất cả nhận xét chứa văn bản "comment 1"
    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
    {
        List<IComment> toRemove = new List<IComment>();
        foreach (IComment comment in slide.GetSlideComments(commentAuthor))
        {
            if (comment.Text == "comment 1")
            {
                toRemove.Add(comment);
            }
        }
        
        foreach (IComment comment in toRemove)
        {
            commentAuthor.Comments.Remove(comment);
        }
    }
    
    presentation.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái như “đã giải quyết” cho nhận xét hiện đại không?**

Có. [Modern comments](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncomment/) cung cấp thuộc tính [Status](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncomment/status/); bạn có thể đọc và đặt [trạng thái của nhận xét](https://reference.aspose.com/slides/vi/net/aspose.slides/moderncommentstatus/) (ví dụ, đánh dấu là đã giải quyết), và trạng thái này sẽ được lưu trong tệp và được PowerPoint nhận diện.

**Có hỗ trợ thảo luận dạng chuỗi (reply chains) không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/net/aspose.slides/comment/parentcomment/), cho phép tạo chuỗi phản hồi tùy ý. API không quy định giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí được lưu dưới dạng điểm số thực trong hệ tọa độ của slide. Điều này cho phép bạn đặt dấu nhận xét chính xác ở vị trí mong muốn.