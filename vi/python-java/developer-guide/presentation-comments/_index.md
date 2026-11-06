---
title: Quản lý bình luận bản trình chiếu trong Python qua Java
linktitle: Bình luận bản trình chiếu
type: docs
weight: 100
url: /vi/python-java/presentation-comments/
keywords:
- bình luận
- bình luận hiện đại
- bình luận PowerPoint
- bình luận bản trình chiếu
- bình luận slide
- thêm bình luận
- truy cập bình luận
- chỉnh sửa bình luận
- trả lời bình luận
- xóa bỏ bình luận
- xoá bình luận
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Quản lý bình luận bản trình chiếu với Aspose.Slides cho Python qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa bình luận trong các bản trình chiếu PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trong bản trình chiếu với Aspose.Slides for Python via Java. Nó giới thiệu các kiểu liên quan đến bình luận chính và trình bày cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với các trả lời và bình luận hiện đại, và xóa bình luận khỏi bản trình chiếu.

Các ví dụ bao phủ các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi trả lời, và xóa các bình luận đã chọn hoặc tất cả các bình luận.

Trong PowerPoint, bình luận xuất hiện như chú thích trên các slide. Khi chọn một bình luận, nó hiển thị nội dung và cuộc thảo luận liên quan.

Để yêu cầu hiển thị hoặc Ẩn bình luận khi một bản trình chiếu mở mà không thay đổi chính các bình luận, hãy xem [Hiển thị hoặc Ẩn bình luận khi mở bản trình chiếu](/slides/vi/python-java/presentation-view-properties/).

## **Tại sao nên thêm bình luận vào bản trình chiếu?**

Bạn có thể sử dụng bình luận để cung cấp phản hồi và cộng tác với đồng nghiệp khi xem xét bản trình chiếu.

Aspose.Slides for Python via Java cung cấp các API sau để làm việc với bình luận:

* Lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) , cung cấp quyền truy cập vào tác giả bình luận của bản trình chiếu.
* Lớp [CommentCollection](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/) , đại diện cho các bình luận liên kết với một tác giả cá nhân.
* Lớp [Comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/) , cung cấp thông tin về một bình luận, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/) , cung cấp thông tin về một tác giả, bao gồm tên, ký tự viết tắt và các bình luận liên quan.

## **Thêm bình luận vào slide**

Ví dụ tạo hai slide và đăng ký một tác giả bình luận bằng [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor). Nó sử dụng [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) để đặt một bình luận trên mỗi slide, sau đó lấy các bình luận của slide đầu tiên cho tác giả đó bằng [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments). Bảng điều khiển hiển thị nội dung của bình luận đầu tiên hai lần, minh họa việc truy cập qua cả slide và tác giả, và bản trình chiếu đã lưu chứa cả hai bình luận.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0))

    author = presentation.getCommentAuthors().addAuthor("Jawad", "MF")
    position = Point2DFloat(0.2, 0.2)
    created_time = Date()

    author.getComments().addComment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.getComments().addComment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.getSlideComments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.getText())

        author_comments = first_comment.getAuthor().getComments()
        comment_text = author_comments.get_Item(0).getText()
        print(comment_text)

    presentation.save("Comments_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tìm hoặc tạo tác giả bình luận**

Khi một quy trình xem xét tự động xử lý cùng một bản trình chiếu nhiều lần, hãy tìm trong bộ sưu tập trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors) trước khi thêm tác giả. [findByNameAndInitials](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByNameAndInitials) khớp cả tên và ký tự viết tắt và trả về một mảng các tác giả khớp, hoặc một mảng rỗng nếu không có kết quả. Ngược lại, [findByName](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#findByName) tìm chỉ theo tên, bất kể ký tự viết tắt. Gọi [addAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#addAuthor) với một tên và ký tự viết tắt đã tồn tại trong bộ sưu tập sẽ ném ngoại lệ.

Ví dụ yêu cầu một tệp bản trình chiếu có ít nhất một slide. Trong mỗi trong hai lần chạy, nó tái sử dụng tác giả khớp đầu tiên, hoặc tạo mới chỉ khi kết quả rỗng. Nếu có nhiều kết quả khớp, nó chọn phần tử đầu tiên trong mảng mà không hợp nhất hoặc xóa các tác giả khác. Sau đó nó gọi [addComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addComment) cho tác giả được chọn và lưu bản trình chiếu. Lần chạy thứ hai mở đầu ra của lần chạy thứ nhất và lặp lại thao tác.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = Point2DFloat(20, 20)

for pass_number in range(1, 3):
    presentation = Presentation(input_file)
    try:
        matches = presentation.getCommentAuthors().findByNameAndInitials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.getCommentAuthors().addAuthor(author_name, author_initials)
        created_time = Date()
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, created_time)

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, SaveFormat.Pptx)
        input_file = output_file
    finally:
        presentation.dispose()
```

Lần chạy thứ hai thêm một bình luận khác mà không thêm tác giả mới hoặc xóa các bình luận hiện có. Tệp cuối cùng, `review_pass_2.pptx`, chứa cả hai bình luận mới bên cạnh bất kỳ bình luận gốc nào. Tái sử dụng một tác giả không loại bỏ trùng lặp bình luận: để tránh việc thêm cùng một bình luận nhiều lần, hãy triển khai phát hiện trùng lặp riêng trước khi thêm.

## **Truy cập bình luận slide**

Ví dụ mở một bản trình chiếu hiện có và đọc bộ sưu tập trả về bởi [getCommentAuthors](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getCommentAuthors). Đối với mỗi tác giả, nó lặp qua bộ sưu tập trả về bởi [getComments](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthor/#getComments) và in số slide, nội dung bình luận, tên tác giả và thời gian tạo. Bản trình chiếu đầu vào phải chứa các bình luận để tạo đầu ra trên bảng điều khiển.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Comments1.pptx")
try:
    for author in presentation.getCommentAuthors():
        for comment in author.getComments():
            print("Slide: ", comment.getSlide().getSlideNumber())
            print("Comment: ", comment.getText())
            print("Author: ", comment.getAuthor().getName())
            print("Posted at: ", comment.getCreatedTime())
            print()
finally:
    presentation.dispose()
```

## **Trả lời bình luận**

Một bình luận cha là bình luận gốc ở đầu một cây phân cấp trả lời. Các phương thức [Comment.getParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment) và [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) cho phép bạn lấy hoặc đặt cha của một bình luận.

Ví dụ tạo các bình luận từ hai tác giả và sử dụng [setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) để xây dựng các trả lời, bao gồm một trả lời cho một trả lời khác. Truyền `None` vào [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) sẽ lấy các bình luận từ mọi tác giả; bảng điều khiển thụt lề mỗi mục theo độ sâu trong cây trả lời. Ví dụ lưu toàn bộ cuộc thảo luận, gọi [remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) trên bình luận gốc đầu tiên, và lưu một bản trình chiếu thứ hai với bình luận đó và các trả lời của nó đã bị xóa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    position = Point2DFloat(10, 10)
    created_time = Date()

    thread_author = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.")
    root_comment = thread_author.getComments().addComment("comment 1", slide, position, created_time)

    responding_author = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.")
    direct_reply = responding_author.getComments().addComment("reply 1 for comment 1", slide, position, created_time)
    direct_reply.setParentComment(root_comment)

    branch_reply = responding_author.getComments().addComment("reply 2 for comment 1", slide, position, created_time)
    branch_reply.setParentComment(root_comment)

    nested_reply = thread_author.getComments().addComment("subreply 3 for reply 2", slide, position, created_time)
    nested_reply.setParentComment(branch_reply)

    responding_author.getComments().addComment("comment 2", slide, position, created_time)
    separate_thread_comment = responding_author.getComments().addComment("comment 3", slide, position, created_time)

    separate_thread_reply = thread_author.getComments().addComment("reply 4 for comment 3", slide, position, created_time)
    separate_thread_reply.setParentComment(separate_thread_comment)

    comments = slide.getSlideComments(None)
    for i in range(len(comments)):
        comment = comments[i]
        while comment.getParentComment() is not None:
            print("\t", end="")
            comment = comment.getParentComment()

        print(f"{comments[i].getAuthor().getName()}: {comments[i].getText()}")

    presentation.save("parent_comment.pptx", SaveFormat.Pptx)

    root_comment.remove()
    presentation.save("remove_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
* Khi phương thức [Comment.remove](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#remove) được sử dụng để xóa một bình luận, tất cả các trả lời cho bình luận đó cũng sẽ bị xóa.
* Nếu [Comment.setParentComment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#setParentComment) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm bình luận hiện đại**

Bình luận hiện đại có thể được gắn với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Phương thức [CommentCollection.addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) nhận một đối số [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ngoài slide và tọa độ đánh dấu bình luận.

Khi `None` được truyền cho đối số shape, bình luận là bình luận ở cấp slide. Dấu đánh dấu được định vị bằng các tọa độ cung cấp, nhưng không liên kết với một hình dạng cụ thể, vì vậy [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) trả về `None`. Khi một [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) được cung cấp, bình luận được neo vào hình dạng đó. Các tọa độ vẫn xác định vị trí của dấu đánh dấu bình luận trên slide, trong khi liên kết hình dạng có thể được lấy thông qua [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape).

### **Gắn một bình luận hiện đại vào hình dạng**

Ví dụ gọi [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) hai lần: một lần với shape `None` cho bình luận cấp slide và một lần với một hình chữ nhật làm neo. Đọc [getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape) in ra `True` cho kiểm tra `None` của bình luận cấp slide và `Revenue title` cho bình luận đã được neo. Cả hai bình luận đều được lưu cùng bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80)
    shape.setName("Revenue title")
    shape.getTextFrame().setText("Quarterly revenue")

    created_time = Date()
    slide_comment_position = Point2DFloat(20, 20)
    shape_comment_position = Point2DFloat(60, 60)
    slide_comment = author.getComments().addModernComment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.getComments().addModernComment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.getShape() is None)
    print(shape_comment.getShape().getName())

    presentation.save("modern_comments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gắn bình luận vào các loại hình dạng khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) đều có thể được dùng làm neo hình dạng. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-java/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sử dụng [addModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#addModernComment) để gắn một bình luận với mỗi trong năm loại hình dạng: một AutoShape, một picture frame, một group, một connector và một chart. Hình ảnh sử dụng dữ liệu ảnh nhúng, vì vậy không cần ảnh bên ngoài. Mỗi bình luận có vị trí dấu đánh dấu riêng, và bản trình chiếu đã lưu giữ lại tất cả năm liên kết hình dạng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")
Base64 = jpype.JClass("java.util.Base64")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    created_time = Date()

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60)
    auto_shape.getTextFrame().setText("AutoShape")

    auto_shape_comment_position = Point2DFloat(30, 30)
    author.getComments().addModernComment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = Base64.getDecoder().decode(image_base64)
    image = presentation.getImages().addImage(image_data)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image)
    picture_comment_position = Point2DFloat(230, 30)
    author.getComments().addModernComment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.getShapes().addGroupShape()
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40)
    group_shape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40)
    group_comment_position = Point2DFloat(40, 150)
    author.getComments().addModernComment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40)
    connector_comment_position = Point2DFloat(240, 150)
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180)
    chart_comment_position = Point2DFloat(420, 40)
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gắn bình luận vào văn bản và đặt trạng thái của nó**

Đối với một bình luận hiện đại gắn với một [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), các phương thức [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart) và [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart) truy xuất vị trí bắt đầu của đoạn văn bản đã chọn trong khung văn bản của hình dạng. Các phương thức [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) và [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) truy xuất độ dài của lựa chọn. Cùng nhau, các giá trị này gắn bình luận với một đoạn văn bản cụ thể trong AutoShape.

Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) và [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) truy cập một giá trị từ các hằng số [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#NotDefined) — không có trạng thái bình luận hiện đại nào được xác định.
- [Active](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Active) — bình luận đang hoạt động.
- [Resolved](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Resolved) — bình luận đã được giải quyết.
- [Closed](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/#Closed) — bình luận đã đóng.

Ví dụ gắn một bình luận hiện đại vào các từ “quarterly revenue” trong văn bản của một hình chữ nhật. Nó tính vị trí bắt đầu lựa chọn không dựa trên chỉ số từ văn bản và truyền vào [setTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionStart), sau đó dùng [setTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setTextSelectionLength) để đặt số ký tự được chọn. Sau khi gọi [setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) với `Resolved`, nó lưu và mở lại bản trình chiếu. Bốn kiểm tra trên bảng điều khiển đều nên in ra `True`, xác nhận rằng neo hình dạng, đoạn văn bản và trạng thái đã được bảo toàn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ModernComment, ModernCommentStatus, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.find(selected_text)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    shape.setName("Forecast text")
    shape.getTextFrame().setText(shape_text)

    author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV")
    comment_position = Point2DFloat(60, 60)
    created_time = Date()
    comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, comment_position, created_time)
    comment.setTextSelectionStart(expected_selection_start)
    comment.setTextSelectionLength(len(selected_text))
    comment.setStatus(ModernCommentStatus.Resolved)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_comments = reopened_slide.getSlideComments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, ModernComment):
            continue

        modern_comment = reopened_comment
        shape_matches = modern_comment.getShape() is not None and modern_comment.getShape().getName() == "Forecast text"
        selection_start_matches = modern_comment.getTextSelectionStart() == expected_selection_start
        selection_length_matches = modern_comment.getTextSelectionLength() == len(selected_text)
        status_matches = modern_comment.getStatus() == ModernCommentStatus.Resolved

        print("Shape anchor preserved: ", shape_matches)
        print("Text selection start preserved: ", selection_start_matches)
        print("Text selection length preserved: ", selection_length_matches)
        print("Resolved status preserved: ", status_matches)
finally:
    reopened_presentation.dispose()
```

### **Kiểm tra các bình luận hiện đại hiện có**

Ví dụ yêu cầu một bản trình chiếu hiện có chứa các bình luận hiện đại và in ra nội dung, trạng thái và chi tiết neo của chúng. Để kiểm tra, xác định các bình luận là thể hiện của [ModernComment](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/), sau đó xem xét [ModernComment.getShape](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getTextSelectionLength) và [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus). Một shape `None` cho biết bình luận cấp slide. Đối với một neo [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), các phương pháp chọn đoạn văn bản xác định phạm vi liên quan trong khung văn bản của hình dạng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ModernComment, Presentation

presentation = Presentation("comments.pptx")
try:
    for slide in presentation.getSlides():
        comments = slide.getSlideComments(None)
        for comment in comments:
            if not isinstance(comment, ModernComment):
                continue

            modern_comment = comment
            print("Slide: ", slide.getSlideNumber())
            print("Text: ", modern_comment.getText())
            print("Status: ", modern_comment.getStatus())

            shape = modern_comment.getShape()
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: ", shape.getName())
                print("Anchor type: ", shape.getClass().getSimpleName())

                if isinstance(shape, AutoShape):
                    print("Text selection start: ", modern_comment.getTextSelectionStart())
                    print("Text selection length: ", modern_comment.getTextSelectionLength())

            print()
finally:
    presentation.dispose()
```

## **Xóa bình luận**

Aspose.Slides for Python via Java cho phép bạn xóa tất cả bình luận và các tác giả bình luận khỏi một bản trình chiếu hoặc xóa các bình luận đã chọn trong khi giữ lại các bình luận còn lại. Các ví dụ sau minh họa cả hai cách và lưu bản trình chiếu đã cập nhật.

### **Xóa tất cả bình luận và tác giả bình luận**

Ví dụ mở một bản trình chiếu hiện có và gọi [CommentCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#clear) cho mỗi tác giả, sau đó gọi [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/commentauthorcollection/#clear) để xóa chính các tác giả. Bản trình chiếu đã lưu không chứa bất kỳ bình luận hay tác giả bình luận nào. Sử dụng một bản trình chiếu chứa bình luận để quan sát việc xóa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("example.pptx")
try:
    for author in presentation.getCommentAuthors():
        author.getComments().clear()

    presentation.getCommentAuthors().clear()

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Xóa các bình luận cụ thể**

Ví dụ tạo hai bình luận trên một slide và sử dụng [getSlideComments](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideComments) để tìm các bình luận theo từng tác giả. Nó thu thập các bình luận có nội dung bằng “comment 1” trước khi gọi [CommentCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/commentcollection/#remove), tránh việc thay đổi bộ sưu tập trong khi chọn. Bản trình chiếu đã lưu chỉ còn lại “comment 2”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")
Date = jpype.JClass("java.util.Date")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    author = presentation.getCommentAuthors().addAuthor("Author", "A")
    created_time = Date()

    first_comment_position = Point2DFloat(0.2, 0.2)
    second_comment_position = Point2DFloat(0.3, 0.2)
    author.getComments().addComment("comment 1", slide, first_comment_position, created_time)
    author.getComments().addComment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.getCommentAuthors():
        comments_to_remove = []
        comments = slide.getSlideComments(comment_author)

        for comment in comments:
            if comment.getText() == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.getComments().remove(comment)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho bình luận hiện đại không?**

Có. [ModernComment.getStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#getStatus) và [ModernComment.setStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncomment/#setStatus) truy cập một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/python-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bản trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (chuỗi trả lời) có được hỗ trợ không, và có giới hạn độ sâu không?**

Có. Mỗi bình luận có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/python-java/aspose.slides/comment/#getParentComment), cho phép tạo chuỗi trả lời. API không định nghĩa giới hạn độ sâu cụ thể nào.

**Vị trí của dấu đánh dấu bình luận trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu đánh dấu được xác định bằng các tọa độ kiểu số thực trong hệ tọa độ của slide, cho phép đặt chính xác trên slide.