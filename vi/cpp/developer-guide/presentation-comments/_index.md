---
title: Quản lý nhận xét bài thuyết trình trong C++
linktitle: Nhận xét bài thuyết trình
type: docs
weight: 100
url: /vi/cpp/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bài thuyết trình
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- phản hồi nhận xét
- xóa nhận xét
- xoá nhận xét
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Quản lý nhận xét bài thuyết trình với Aspose.Slides cho C++: thêm, đọc, chỉnh sửa, phản hồi và xóa nhận xét trong các bài thuyết trình PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bài thuyết trình với Aspose.Slides for C++. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với phản hồi và nhận xét hiện đại, và xóa nhận xét khỏi một bài thuyết trình.

Các ví dụ bao phủ các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc văn bản và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa các nhận xét được chọn hoặc toàn bộ nhận xét.

Trong PowerPoint, nhận xét xuất hiện dưới dạng chú thích trên các slide. Khi chọn một nhận xét, nó sẽ hiển thị văn bản và cuộc thảo luận liên quan.

Để yêu cầu hiển thị hoặc ẩn nhận xét khi một bài thuyết trình mở mà không thay đổi các nhận xét, xem [Hiển thị hoặc Ẩn Nhận xét Khi Mở Bài Thuyết Trình](/slides/vi/cpp/presentation-view-properties/).

## **Tại sao phải thêm nhận xét vào bài thuyết trình?**

Bạn có thể sử dụng nhận xét để cung cấp phản hồi và cộng tác với đồng nghiệp khi xem xét các bài thuyết trình.

Aspose.Slides for C++ cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả nhận xét của bài thuyết trình.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/) đại diện cho các nhận xét liên kết với một tác giả cụ thể.
* Giao diện [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và văn bản.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, ký tự viết tắt và các nhận xét liên quan.

## **Thêm Nhận xét cho Slide**

Ví dụ tạo hai slide và đăng ký một tác giả nhận xét bằng [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Nó sử dụng [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) để đặt một nhận xét trên mỗi slide, sau đó lấy các nhận xét của slide đầu tiên cho tác giả đó bằng [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). Console hiển thị văn bản của nhận xét đầu tiên hai lần, minh họa việc truy cập thông qua cả slide và tác giả, và bài thuyết trình đã lưu chứa cả hai nhận xét.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **Tìm hoặc Tạo Tác Giả Nhận Xét**

Khi một quá trình kiểm tra tự động xử lý cùng một bài thuyết trình nhiều lần, hãy tìm trong bộ sưu tập trả về bởi [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) trước khi thêm tác giả. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) khớp cả tên và ký tự viết tắt và trả về một mảng các tác giả phù hợp, hoặc một mảng rỗng nếu không có khớp. Ngược lại, [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) tìm kiếm chỉ theo tên, bất kể ký tự viết tắt. Gọi [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) với một tên và ký tự viết tắt đã tồn tại trong bộ sưu tập sẽ ném ra ngoại lệ.

Ví dụ yêu cầu một tệp bài thuyết trình có ít nhất một slide. Trong mỗi trong hai lần chạy, nó tái sử dụng tác giả đầu tiên phù hợp, hoặc tạo mới chỉ khi kết quả rỗng. Nếu có nhiều kết quả phù hợp, nó chọn phần tử đầu tiên của mảng mà không hợp nhất hoặc xóa các tác giả khác. Sau đó nó gọi [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) cho tác giả đã chọn và lưu bài thuyết trình. Lần chạy thứ hai mở đầu ra của lần chạy đầu tiên và lặp lại thao tác.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

Lần chạy thứ hai thêm một nhận xét khác mà không thêm tác giả mới hoặc xóa các nhận xét hiện có. Tệp cuối cùng, `review_pass_2.pptx`, chứa cả hai nhận xét mới cùng với bất kỳ nhận xét gốc nào. Việc tái sử dụng một tác giả không loại bỏ các nhận xét trùng lặp: để tránh việc thêm đi thêm lại cùng một nhận xét, hãy triển khai cơ chế phát hiện trùng lặp riêng trước khi thêm.

## **Truy Cập Nhận Xét của Slide**

Ví dụ mở một bài thuyết trình hiện có và đọc bộ sưu tập trả về bởi [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). Đối với mỗi tác giả, nó lặp qua bộ sưu tập trả về bởi [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) và in số slide, văn bản nhận xét, tên tác giả và thời gian tạo. Bài thuyết trình đầu vào phải chứa nhận xét để tạo ra đầu ra console.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **Trả Lời Nhận Xét**

Một nhận xét gốc là nhận xét ban đầu ở đầu của một chuỗi phản hồi. Các phương thức [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) và [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) của giao diện [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) cho phép bạn lấy hoặc đặt nhận xét cha.

Ví dụ tạo các nhận xét từ hai tác giả và sử dụng [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) để xây dựng các phản hồi, bao gồm cả một phản hồi cho một phản hồi khác. Truyền `nullptr` vào [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) sẽ lấy nhận xét từ mọi tác giả; console thụt lề mỗi mục tùy theo độ sâu trong cây phản hồi. Ví dụ lưu toàn bộ cuộc thảo luận, gọi [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) cho nhận xét gốc đầu tiên, và lưu một bài thuyết trình thứ hai với nhận xét đó và các phản hồi của nó đã bị xóa.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Khi phương thức [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) của giao diện [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) được sử dụng để xóa một nhận xét, tất cả các phản hồi của nhận xét đó cũng sẽ bị xóa.
* Nếu phương thức [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm Nhận Xét Hiện Đại**

Nhận xét hiện đại có thể được gắn vào chính slide, vào một hình cụ thể, hoặc vào một đoạn văn bản trong một AutoShape. Phương thức [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) chấp nhận một đối số [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) bên cạnh slide và tọa độ của dấu nhận xét.

Khi truyền `nullptr` cho đối số shape, nhận xét sẽ là một nhận xét cấp slide. Dấu của nó được định vị bằng các tọa độ đã cung cấp, nhưng không gắn với một shape cụ thể, vì vậy [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) trả về `nullptr`. Khi cung cấp một [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), nhận xét sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi mối liên kết shape có thể được truy xuất qua [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **Gắn Nhận Xét Hiện Đại vào Hình**

Ví dụ gọi [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) hai lần: một lần với shape `nullptr` cho một nhận xét cấp slide và một lần với một hình chữ nhật làm neo. Gọi [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) in `True` cho kiểm tra null của nhận xét cấp slide và `Revenue title` cho nhận xét đã được neo. Cả hai nhận xét đều được lưu cùng với bài thuyết trình.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **Gắn Nhận Xét vào Các Kiểu Hình Khác Nhau**

Bất kỳ đối tượng slide nào thực thi [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) đều có thể được dùng làm neo shape. Các ví dụ phổ biến bao gồm [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/), và các thể hiện [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/) như biểu đồ.

Ví dụ sử dụng [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) để gắn một nhận xét với mỗi trong năm kiểu shape: một AutoShape, một picture frame, một nhóm, một connector và một chart. Hình ảnh được nhúng dữ liệu hình ảnh, nên không cần hình ảnh bên ngoài. Mỗi nhận xét có vị trí dấu riêng, và bài thuyết trình đã lưu giữ lại tất cả năm mối liên kết shape.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");

auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **Gắn Nhận Xét vào Văn Bản và Đặt Trạng Thái của Nó**

Đối với một nhận xét hiện đại gắn với một [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) và [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) điều khiển vị trí bắt đầu của văn bản đã chọn trong khung văn bản của shape. Tương tự, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) và [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) điều khiển độ dài của đoạn chọn. Cùng nhau, các phương thức này gắn nhận xét với một đoạn văn bản cụ thể trong AutoShape.

Các phương thức [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) và [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) sử dụng một giá trị từ liệt kê [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — không có trạng thái nhận xét hiện đại cụ thể nào được định nghĩa.
- `Active` — nhận xét đang hoạt động.
- `Resolved` — nhận xét đã được giải quyết.
- `Closed` — nhận xét đã đóng.

Ví dụ gắn một nhận xét hiện đại vào các từ “quarterly revenue” trong văn bản của một hình chữ nhật. Nó tính vị trí bắt đầu chọn không dựa trên zero từ văn bản, truyền giá trị này vào [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/), và gọi [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) với số ký tự đã chọn. Sau khi gọi [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) với `Resolved`, nó lưu và mở lại bài thuyết trình. Bốn kiểm tra console đều nên in `True`, xác nhận rằng neo shape, đoạn văn bản và trạng thái đã được bảo toàn.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **Kiểm Tra Nhận Xét Hiện Đại Hiện Tại**

Ví dụ yêu cầu một bài thuyết trình hiện có chứa các nhận xét hiện đại và in ra văn bản, trạng thái và chi tiết neo của chúng. Để kiểm tra, xác định những nhận xét nào triển khai [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/), sau đó kiểm tra [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) và [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Một shape `nullptr` cho biết đây là một nhận xét cấp slide. Đối với neo [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), các phương thức chọn văn bản xác định đoạn liên quan trong khung văn bản của shape.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **Xóa Nhận Xét**

Aspose.Slides for C++ cho phép bạn xóa tất cả nhận xét và các tác giả của chúng khỏi một bài thuyết trình hoặc xóa các nhận xét đã chọn trong khi giữ lại những phần còn lại. Các ví dụ dưới đây minh họa cả hai cách và lưu bản cập nhật của bài thuyết trình.

### **Xóa Tất Cả Nhận Xét và Tác Giả Nhận Xét**

Ví dụ mở một bài thuyết trình hiện có và gọi [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/) cho mỗi tác giả, sau đó gọi [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) để xóa các tác giả. Bài thuyết trình đã lưu sẽ không chứa nhận xét hay tác giả nhận xét nào. Hãy sử dụng một bài thuyết trình có nhận xét để quan sát việc xóa.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Xóa Các Nhận Xét Cụ Thể**

Ví dụ tạo hai nhận xét trên một slide và sử dụng [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) để tìm nhận xét của mỗi tác giả. Nó thu thập các nhận xét có văn bản bằng “comment 1” trước khi gọi [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/), tránh thay đổi bộ sưu tập trong quá trình lựa chọn. Bài thuyết trình đã lưu chỉ giữ lại “comment 2”.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **CÂU HỎI THƯỜNG GẶP**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) và [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) sử dụng một giá trị của [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bài thuyết trình và có thể đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (chuỗi phản hồi) có được hỗ trợ không, và có giới hạn độ sâu không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), cho phép tạo chuỗi phản hồi. API không định nghĩa giới hạn độ sâu cụ thể.

**Vị trí của dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu được định nghĩa bằng các tọa độ dạng số thực trong hệ tọa độ slide, cho phép bạn đặt nó một cách chính xác trên slide.