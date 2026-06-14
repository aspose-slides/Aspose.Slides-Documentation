---
title: Quản lý bình luận bài thuyết trình trong C++
linktitle: Bình luận Bài thuyết trình
type: docs
weight: 100
url: /vi/cpp/presentation-comments/
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
- loại bỏ bình luận
- xoá bình luận
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Thành thạo quản lý bình luận bài thuyết trình với Aspose.Slides cho C++: thêm, đọc, chỉnh sửa và xoá bình luận trong tệp PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trong bài thuyết trình bằng Aspose.Slides. Nó giới thiệu các kiểu dữ liệu liên quan đến bình luận và minh họa cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với phản hồi, sử dụng bình luận hiện đại và xóa bình luận khỏi bài thuyết trình.

Các ví dụ tập trung vào các kịch bản đánh giá và cộng tác thường gặp trong PowerPoint, chẳng hạn như chỉ định bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi phản hồi, và xóa tất cả bình luận hoặc xóa các bình luận đã chọn.

Trong PowerPoint, một bình luận xuất hiện dưới dạng ghi chú hoặc chú thích trên một slide. Khi nhấp vào bình luận, nội dung hoặc tin nhắn của nó sẽ được hiển thị.

### **Tại sao lại thêm bình luận vào bài thuyết trình?**

Bạn có thể muốn dùng bình luận để đưa ra phản hồi hoặc giao tiếp với đồng nghiệp khi xem xét các bài thuyết trình.

Để cho phép bạn sử dụng bình luận trong các bài thuyết trình PowerPoint, Aspose.Slides for C++ cung cấp

* Lớp [Bản trình chiếu](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) chứa các bộ sưu tập tác giả (từ phương thức [get_CommentAuthors()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d)). Các tác giả thêm bình luận vào các slide. 
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_comment_collection) chứa bộ sưu tập bình luận cho từng tác giả. 
* Lớp [IComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_comment) chứa thông tin về tác giả và bình luận của họ: ai đã thêm bình luận, thời gian bình luận được thêm, vị trí bình luận, v.v. 
* Lớp [Tác giả bình luận](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.comment_author) chứa thông tin về từng tác giả: tên tác giả, chữ viết tắt, các bình luận liên quan tới tên tác giả, v.v. 

## **Thêm bình luận vào slide**
Đoạn mã C++ dưới đây cho bạn biết cách thêm bình luận vào một slide trong bài thuyết trình PowerPoint:

```cpp
// Khởi tạo lớp Presentation
auto presentation = System::MakeObject<Presentation>();
// Thêm một slide trống
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// Thêm một tác giả
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// Đặt vị trí cho bình luận
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// Truy cập ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// Truy cập ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// Thêm bình luận slide cho tác giả trên slide 1
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// Thêm bình luận slide cho tác giả trên slide 2
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// Khi null được truyền làm đối số, các bình luận từ tất cả tác giả sẽ được đưa vào slide đã chọn
auto comments = slide1->GetSlideComments(author);

// Truy cập bình luận ở chỉ mục 0 cho slide 1
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // Chọn bộ sưu tập bình luận của tác giả tại chỉ mục 0
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **Truy cập bình luận trên slide**
Đoạn mã C++ dưới đây cho bạn biết cách truy cập một bình luận hiện có trên slide trong bài thuyết trình PowerPoint:

```cpp
// Khởi tạo lớp Presentation
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```

## **Phản hồi bình luận**
Một bình luận gốc là bình luận đầu tiên hoặc gốc trong một vòng phân cấp các bình luận hoặc phản hồi. Bằng cách sử dụng thuộc tính [ParentComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_comment)), bạn có thể đặt hoặc lấy bình luận gốc.

Đoạn mã C++ dưới đây cho bạn biết cách thêm bình luận và lấy các phản hồi cho chúng:

```cpp
auto pres = System::MakeObject<Presentation>();

// Truy cập ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// Thêm một bình luận
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// Thêm một phản hồi cho comment1
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// Thêm một phản hồi khác cho comment1
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// Thêm một phản hồi cho phản hồi hiện có
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// Hiển thị cây bình luận trên console
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// Xóa comment1 và tất cả các phản hồi của nó
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Attention" %}} 

* Khi phương thức [Remove](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) (từ giao diện [IComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_comment)) được dùng để xóa một bình luận, các phản hồi của bình luận cũng sẽ bị xóa. 
* Nếu cài đặt [ParentComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) dẫn đến tham chiếu vòng, [PptxEditException](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) sẽ được ném.

{{% /alert %}}

## **Thêm bình luận hiện đại**

Năm 2021, Microsoft đã giới thiệu *bình luận hiện đại* trong PowerPoint. Tính năng bình luận hiện đại cải thiện đáng kể khả năng cộng tác trong PowerPoint. Thông qua bình luận hiện đại, người dùng PowerPoint có thể giải quyết bình luận, neo bình luận vào đối tượng và văn bản, và tương tác dễ dàng hơn rất nhiều.

Trong [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/vi/cpp/aspose-slides-for-cpp-21-11-release-notes/), chúng tôi đã triển khai hỗ trợ cho bình luận hiện đại bằng cách thêm lớp [ModernComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.modern_comment). Các phương thức [AddModernComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) và [InsertModernComment](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) đã được thêm vào lớp [CommentCollection](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.comment_collection).

Đoạn mã C++ dưới đây cho bạn biết cách thêm bình luận hiện đại vào một slide trong bài thuyết trình PowerPoint: 

```cpp
auto pres = System::MakeObject<Presentation>();
// Truy cập ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Xóa bình luận**

### **Xóa tất cả bình luận và tác giả**

Đoạn mã C++ dưới đây cho bạn biết cách xóa tất cả bình luận và tác giả trong một bài thuyết trình:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// Xóa tất cả bình luận khỏi bài thuyết trình
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// Xóa tất cả tác giả
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Xóa các bình luận cụ thể**

Đoạn mã C++ dưới đây cho bạn biết cách xóa các bình luận cụ thể trên một slide:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// thêm bình luận...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// xóa tất cả bình luận chứa văn bản "comment 1"
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);

```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái như “đã giải quyết” cho bình luận hiện đại không?**

Có. [Bình luận hiện đại](https://reference.aspose.com/slides/vi/cpp/aspose.slides/moderncomment/) cung cấp các phương thức [get_Status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/moderncomment/get_status/) và [set_Status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/moderncomment/set_status/); bạn có thể đọc và đặt [trạng thái của bình luận](https://reference.aspose.com/slides/vi/cpp/aspose.slides/moderncommentstatus/) (ví dụ, đánh dấu là đã giải quyết), và trạng thái này sẽ được lưu trong tệp và được PowerPoint nhận diện.

**Có hỗ trợ thảo luận dạng chuỗi (chuỗi phản hồi) không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu đến [bình luận gốc](https://reference.aspose.com/slides/vi/cpp/aspose.slides/comment/set_parentcomment/), cho phép xây dựng chuỗi phản hồi tùy ý. API không quy định giới hạn độ sâu cụ thể.

**Vị trí của dấu đánh dấu bình luận trên slide được xác định trong hệ tọa độ nào?**

Vị trí được lưu dưới dạng điểm số thực trong hệ tọa độ của slide. Điều này cho phép bạn đặt dấu đánh dấu bình luận chính xác tại vị trí mong muốn.