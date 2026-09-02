---
title: Quản lý nhận xét trong bản trình chiếu bằng C++
linktitle: Nhận xét bản trình chiếu
type: docs
weight: 100
url: /vi/cpp/presentation-comments/
keywords:
- nhận xét
- nhận xét hiện đại
- nhận xét PowerPoint
- nhận xét bản trình chiếu
- nhận xét slide
- thêm nhận xét
- truy cập nhận xét
- chỉnh sửa nhận xét
- trả lời nhận xét
- gỡ bỏ nhận xét
- xóa nhận xét
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý nhận xét bản trình chiếu với Aspose.Slides cho C++: thêm, đọc, chỉnh sửa, trả lời và xóa nhận xét trong bản trình chiếu PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình chiếu bằng Aspose.Slides cho C++. Nó giới thiệu các kiểu liên quan đến nhận xét chính và minh họa cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với các phản hồi và nhận xét hiện đại, và xóa nhận xét khỏi bản trình chiếu.

Các ví dụ bao phủ các kịch bản đánh giá và cộng tác phổ biến trong PowerPoint, chẳng hạn như chỉ định nhận xét cho tác giả, đọc văn bản và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa các nhận xét được chọn hoặc tất cả các nhận xét.

Trong PowerPoint, nhận xét hiển thị dưới dạng chú thích trên các slide. Khi chọn một nhận xét, nó hiển thị văn bản và cuộc thảo luận liên quan.

## **Tại sao cần thêm nhận xét vào bản trình chiếu?**

Bạn có thể sử dụng nhận xét để đưa ra phản hồi và cộng tác với đồng nghiệp khi đánh giá bản trình chiếu.

Aspose.Slides cho C++ cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả nhận xét của bản trình chiếu.
* Giao diện [ICommentCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icommentcollection/) đại diện cho các nhận xét liên kết với một tác giả cụ thể.
* Giao diện [IComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/) cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/cpp/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, viết tắt và các nhận xét liên quan.

## **Thêm nhận xét vào slide**

Ví dụ sau cho thấy cách thêm nhận xét vào các slide trong một bản trình chiếu PowerPoint:

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

## **Truy cập nhận xét của slide**

Ví dụ sau cho thấy cách truy cập các nhận xét hiện có trong một bản trình chiếu PowerPoint:

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

## **Phản hồi nhận xét**

Một nhận xét cha là nhận xét gốc nằm ở đầu của cấu trúc phản hồi. Các phương thức [get_ParentComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/get_parentcomment/) và [set_ParentComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/set_parentcomment/) của giao diện [IComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/) cho phép bạn lấy hoặc thiết lập nhận xét cha.

Ví dụ sau cho thấy cách thêm phản hồi và kiểm tra cấu trúc nhận xét kết quả:

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

auto author1 = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto author2 = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
reply1->set_ParentComment(comment1);

auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
reply2->set_ParentComment(comment1);

auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(reply2);

author2->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
reply3->set_ParentComment(comment3);

auto comments = slide->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
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

comment1->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Cảnh báo" %}}
* Khi phương thức [Remove](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/remove/) của giao diện [IComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/) được sử dụng để xóa một nhận xét, tất cả các phản hồi của nhận xét đó cũng sẽ bị xóa.
* Nếu phương thức [set_ParentComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/set_parentcomment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm nhận xét hiện đại**

Nhận xét hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong AutoShape. Phương thức [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icommentcollection/addmoderncomment/) chấp nhận đối số [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) bên cạnh slide và tọa độ của dấu nhận xét.

Khi truyền `nullptr` cho đối số shape, nhận xét sẽ là nhận xét ở cấp slide. Dấu nhận xét được đặt theo các tọa độ cung cấp, nhưng không liên kết với bất kỳ hình dạng nào, vì vậy [IModernComment::get_Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_shape/) trả về `nullptr`. Khi cung cấp một [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/), nhận xét sẽ được neo vào hình dạng đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi liên kết hình dạng có thể được lấy thông qua [IModernComment::get_Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_shape/).

### **Neo một nhận xét hiện đại vào hình dạng**

Ví dụ sau tạo cả một nhận xét hiện đại ở cấp slide và một nhận xét hiện đại được neo vào một AutoShape cụ thể. Sau đó nó đọc hình dạng liên quan từ mỗi nhận xét.

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

### **Neo nhận xét vào các loại hình dạng khác nhau**

Bất kỳ đối tượng slide nào thực hiện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) đều có thể được sử dụng làm neo hình dạng. Các ví dụ thường gặp bao gồm các thể hiện của [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iconnector/), và [IGraphicalObject](https://reference.aspose.com/slides/vi/cpp/aspose.slides/igraphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại hình dạng phổ biến và liên kết một nhận xét hiện đại với mỗi loại.

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

### **Neo nhận xét vào văn bản và thiết lập trạng thái của nó**

Đối với một nhận xét hiện đại được liên kết với [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/), các phương thức [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_textselectionstart/) và [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/set_textselectionstart/) kiểm soát vị trí bắt đầu của đoạn văn bản được chọn trong khung văn bản của hình dạng. Tương tự, [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_textselectionlength/) và [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/set_textselectionlength/) kiểm soát độ dài của phần chọn. Cả hai phương thức này cùng nhau liên kết nhận xét với một đoạn văn bản cụ thể bên trong AutoShape.

Các phương thức [IModernComment::get_Status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_status/) và [IModernComment::set_Status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/set_status/) sử dụng một giá trị từ liệt kê [ModernCommentStatus](https://reference.aspose.com/slides/vi/cpp/aspose.slides/moderncommentstatus/):
- `NotDefined` — không có trạng thái nhận xét hiện đại cụ thể nào được xác định.
- `Active` — nhận xét đang hoạt động.
- `Resolved` — nhận xét đã được giải quyết.
- `Closed` — nhận xét đã đóng.

Ví dụ sau tạo một nhận xét hiện đại được neo vào hình dạng, liên kết nó với một đoạn văn bản được chọn, đánh dấu là đã giải quyết, lưu bản trình chiếu và xác minh các giá trị sau khi mở lại tệp.

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

### **Kiểm tra các nhận xét hiện đại hiện có**

Để kiểm tra một bản trình chiếu hiện có, kiểm tra các nhận xét nào triển khai [IModernComment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/), sau đó xem xét [IModernComment::get_Shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_textselectionlength/), và [IModernComment::get_Status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_status/). Một hình dạng `nullptr` cho biết đó là nhận xét ở cấp slide. Đối với neo [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) , các phương thức lựa chọn văn bản xác định đoạn phạm vi liên quan trong khung văn bản của hình dạng.

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

## **Xóa nhận xét**

### **Xóa tất cả nhận xét và tác giả nhận xét**

Ví dụ sau cho thấy cách xóa tất cả các nhận xét và tác giả nhận xét khỏi một bản trình chiếu:

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

### **Xóa các nhận xét cụ thể**

Ví dụ sau cho thấy cách xóa các nhận xét cụ thể khỏi một slide:

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

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. Các phương thức [IModernComment::get_Status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/get_status/) và [IModernComment::set_Status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/imoderncomment/set_status/) sử dụng một giá trị của [ModernCommentStatus](https://reference.aspose.com/slides/vi/cpp/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bản trình chiếu và có thể được đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (reply chains) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icomment/set_parentcomment/), cho phép tạo chuỗi phản hồi. API không định nghĩa một giới hạn độ sâu lồng nhau cụ thể.

**Vị trí dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu nhận xét được định nghĩa bằng các tọa độ số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.