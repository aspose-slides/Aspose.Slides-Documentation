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
- gỡ bỏ bình luận
- xóa bình luận
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Quản lý bình luận bản trình chiếu với Aspose.Slides cho Python qua Java: thêm, đọc, chỉnh sửa, trả lời và xóa bình luận trong các bản trình chiếu PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trong bản trình chiếu bằng Aspose.Slides cho Python qua Java. Nó giới thiệu các kiểu liên quan đến bình luận chính và minh họa cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với trả lời và bình luận hiện đại, và xóa bình luận khỏi bản trình chiếu.

Các ví dụ bao phủ các kịch bản đánh giá và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán bình luận cho tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi trả lời, và xóa các bình luận đã chọn hoặc tất cả các bình luận.

Trong PowerPoint, bình luận xuất hiện dưới dạng chú thích trên các slide. Khi chọn một bình luận, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

Để yêu cầu hiển thị hoặc ẩn bình luận khi một bản trình chiếu mở mà không thay đổi nội dung bình luận, xem [Hiển thị hoặc Ẩn Bình luận Khi Mở Bản Trình Chiếu](/slides/vi/python-java/presentation-view-properties/).

## **Tại sao cần thêm bình luận vào bản trình chiếu?**

Bạn có thể sử dụng bình luận để cung cấp phản hồi và cộng tác với đồng nghiệp khi đánh giá bản trình chiếu.

Aspose.Slides cho Python qua Java cung cấp các API sau để làm việc với bình luận:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả bình luận của bản trình chiếu.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commentcollection/) đại diện cho các bình luận được liên kết với một tác giả riêng lẻ.
* Lớp [Comment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/comment/) cung cấp thông tin về một bình luận, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các bình luận được liên kết.

## **Thêm Bình luận vào Slide**

Ví dụ sau cho thấy cách thêm bình luận vào các slide trong một bản trình chiếu PowerPoint:

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

## **Truy cập Bình luận trên Slide**

Ví dụ sau cho thấy cách truy cập các bình luận hiện có trong một bản trình chiếu PowerPoint:

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

## **Trả lời Bình luận**

Một bình luận cha là bình luận gốc ở đầu cây trả lời. Các phương thức [Comment.getParentComment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/comment/#getParentComment) và [Comment.setParentComment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/comment/#setParentComment) cho phép bạn lấy hoặc đặt bình luận cha của một bình luận.

Ví dụ sau cho thấy cách thêm trả lời và kiểm tra cấu trúc cây bình luận tạo ra:

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
* Khi sử dụng phương thức [Comment.remove](https://reference.aspose.com/slides/vi/python-java/aspose.slides/comment/#remove) để xóa một bình luận, tất cả các trả lời cho bình luận đó cũng sẽ bị xóa.
* Nếu [Comment.setParentComment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/comment/#setParentComment) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxeditexception/) sẽ được ném ra.
{{% /alert %}}

## **Thêm Bình luận Hiện đại**

Bình luận hiện đại có thể được gắn liền với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/). Phương thức [CommentCollection.addModernComment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commentcollection/#addModernComment) chấp nhận một đối số [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) ngoài slide và tọa độ đánh dấu bình luận.

Khi truyền `None` cho đối số shape, bình luận sẽ là bình luận cấp slide. Đánh dấu của nó được định vị bằng các tọa độ cung cấp, nhưng không gắn với bất kỳ shape nào, vì vậy [ModernComment.getShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getShape) trả về `None`. Khi cung cấp một [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/), bình luận sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu bình luận trên slide, trong khi mối liên kết shape có thể được truy xuất qua [ModernComment.getShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getShape).

### **Neo một Bình luận Hiện đại vào Shape**

Ví dụ sau tạo cả một bình luận hiện đại cấp slide và một bình luận hiện đại được neo vào một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) cụ thể. Sau đó nó đọc shape được liên kết từ mỗi bình luận.

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

### **Neo Bình luận vào Các Kiểu Shape Khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) đều có thể được sử dụng làm neo shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/vi/python-java/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sau tạo một số kiểu shape phổ biến và gắn một bình luận hiện đại vào mỗi shape.

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

### **Neo Bình luận vào Văn bản và Đặt Trạng thái của Nó**

Đối với một bình luận hiện đại được gắn vào một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/), các phương thức [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getTextSelectionStart) và [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#setTextSelectionStart) truy cập vị trí bắt đầu của văn bản được chọn trong khung văn bản của shape. Các phương thức [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getTextSelectionLength) và [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#setTextSelectionLength) truy cập độ dài của phần chọn. Cùng nhau, các giá trị này liên kết bình luận với một đoạn văn bản cụ thể bên trong AutoShape.

Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getStatus) và [ModernComment.setStatus](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#setStatus) truy cập một giá trị từ các hằng số [ModernCommentStatus](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncommentstatus/):

- [NotDefined](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncommentstatus/#NotDefined) — không có trạng thái bình luận hiện đại cụ thể nào được định nghĩa.
- [Active](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncommentstatus/#Active) — bình luận đang hoạt động.
- [Resolved](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncommentstatus/#Resolved) — bình luận đã được giải quyết.
- [Closed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncommentstatus/#Closed) — bình luận đã đóng.

Ví dụ sau tạo một bình luận hiện đại neo vào shape, liên kết nó với một phần chọn văn bản, đánh dấu là đã giải quyết, lưu bản trình chiếu và xác minh các giá trị sau khi mở lại tệp.

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

### **Kiểm tra Các Bình luận Hiện đại Hiện có**

Để kiểm tra một bản trình chiếu hiện có, xác định các bình luận là thể hiện của [ModernComment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/), sau đó xem xét [ModernComment.getShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getShape), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getTextSelectionStart), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getTextSelectionLength) và [ModernComment.getStatus](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getStatus). Một shape `None` cho thấy bình luận cấp slide. Đối với neo vào [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/), các phương thức chọn văn bản xác định đoạn văn bản liên quan trong khung văn bản của shape.

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

## **Xóa Bình luận**

### **Xóa Tất cả Bình luận và Tác giả Bình luận**

Ví dụ sau cho thấy cách xóa tất cả bình luận và các tác giả bình luận khỏi một bản trình chiếu:

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

### **Xóa Các Bình luận Cụ thể**

Ví dụ sau cho thấy cách xóa các bình luận cụ thể khỏi một slide:

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

Có. Các phương thức [ModernComment.getStatus](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#getStatus) và [ModernComment.setStatus](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncomment/#setStatus) truy cập một giá trị [ModernCommentStatus](https://reference.aspose.com/slides/vi/python-java/aspose.slides/moderncommentstatus/), bao gồm `Resolved`. Trạng thái được lưu trong bản trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Liệu các cuộc thảo luận dạng chuỗi trả lời (threaded discussions) có được hỗ trợ, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/comment/#getParentComment), cho phép tạo chuỗi trả lời. API không định nghĩa giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu bình luận trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu được định nghĩa bằng các tọa độ số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.