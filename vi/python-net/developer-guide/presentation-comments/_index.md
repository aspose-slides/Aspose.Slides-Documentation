---
title: Quản lý bình luận bài trình chiếu trong Python
linktitle: Bình luận bài trình chiếu
type: docs
weight: 100
url: /vi/python-net/presentation-comments/
keywords:
- bình luận
- bình luận hiện đại
- bình luận PowerPoint
- bình luận bài trình chiếu
- bình luận slide
- thêm bình luận
- truy cập bình luận
- chỉnh sửa bình luận
- phản hồi bình luận
- xóa bình luận
- xoá bình luận
- PowerPoint
- bài trình chiếu
- Python
- Aspose.Slides
description: "Quản lý bình luận trong bài trình chiếu bằng Aspose.Slides cho Python qua .NET: thêm, đọc, chỉnh sửa, trả lời và xóa bình luận trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý bình luận trong bài trình chiếu bằng Aspose.Slides for Python via .NET. Nó giới thiệu các kiểu liên quan tới bình luận chính và trình bày cách thêm bình luận vào các slide, truy cập các bình luận hiện có, làm việc với phản hồi và bình luận hiện đại, đồng thời xóa bình luận khỏi một bài trình chiếu.

Các ví dụ bao gồm các kịch bản đánh giá và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán bình luận cho các tác giả, đọc nội dung và siêu dữ liệu của bình luận, xây dựng chuỗi phản hồi, và xóa các bình luận đã chọn hoặc tất cả các bình luận.

Trong PowerPoint, bình luận xuất hiện như các chú thích trên slide. Khi chọn một bình luận, nội dung và cuộc thảo luận liên quan sẽ được hiển thị.

Để yêu cầu hiển thị hoặc ẩn bình luận khi mở một bài trình chiếu mà không thay đổi nội dung bình luận, xem [Show or Hide Comments When Opening a Presentation](/slides/vi/python-net/presentation-view-properties/).

## **Tại sao nên thêm bình luận vào bài trình chiếu?**

Bạn có thể sử dụng bình luận để cung cấp phản hồi và cộng tác với đồng nghiệp khi duyệt các bài trình chiếu.

Aspose.Slides for Python via .NET cung cấp các API sau để làm việc với bình luận:

* The [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **Thêm bình luận vào slide**

Ví dụ sau cho thấy cách thêm bình luận vào các slide trong một bài trình chiếu PowerPoint:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = draw.PointF(0.2, 0.2)
    created_time = datetime.now()

    author.comments.add_comment("Hello Jawad, this is a slide comment", first_slide, position, created_time)
    author.comments.add_comment("Hello Jawad, this is the second slide comment", second_slide, position, created_time)

    comments = first_slide.get_slide_comments(author)
    if len(comments) > 0:
        first_comment = comments[0]
        print(first_comment.text)

        comment_text = first_comment.author.comments[0].text
        print(comment_text)

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập bình luận trên slide**

Ví dụ sau cho thấy cách truy cập các bình luận hiện có trong một bài trình chiếu PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("Slide: " + str(comment.slide.slide_number))
            print("Comment: " + comment.text)
            print("Author: " + comment.author.name)
            print("Posted at: " + str(comment.created_time))
            print()
```

## **Phản hồi bình luận**

Một bình luận cha là bình luận gốc ở đầu chuỗi phản hồi. Thuộc tính [parent_comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/parent_comment/) của lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/) cho phép bạn lấy hoặc đặt cha của một bình luận.

Ví dụ sau cho thấy cách thêm phản hồi và kiểm tra cấu trúc bình luận thu được:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    position = draw.PointF(10, 10)
    created_time = datetime.now()

    author1 = presentation.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment 1", slide, position, created_time)

    author2 = presentation.comment_authors.add_author("Author_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    reply1.parent_comment = comment1

    reply2 = author2.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    reply2.parent_comment = comment1

    sub_reply = author1.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = reply2

    author2.comments.add_comment("comment 2", slide, position, created_time)
    comment3 = author2.comments.add_comment("comment 3", slide, position, created_time)

    reply3 = author1.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    reply3.parent_comment = comment3

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    comment1.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Khi phương thức [remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/remove/) của lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/) được sử dụng để xóa một bình luận, tất cả các phản hồi của bình luận đó cũng sẽ bị xóa.
* Nếu thuộc tính [parent_comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/parent_comment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/) sẽ được ném ra.
{{% /alert %}}

## **Thêm bình luận hiện đại**

Bình luận hiện đại có thể được gắn với slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một AutoShape. Phương thức [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentcollection/add_modern_comment/) chấp nhận một đối số [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) bên cạnh slide và tọa độ dấu đánh dấu bình luận.

Khi truyền `None` cho đối số shape, bình luận sẽ là bình luận ở mức slide. Dấu đánh dấu được định vị bằng các tọa độ đã cung cấp, nhưng không gắn với một shape nào, vì vậy [ModernComment.shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/shape/) trả về `None`. Khi cung cấp một [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/), bình luận sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu đánh dấu bình luận trên slide, trong khi mối liên kết với shape có thể được truy xuất thông qua [ModernComment.shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/shape/).

### **Neo một bình luận hiện đại vào một Shape**

Ví dụ sau tạo cả một bình luận hiện đại ở mức slide và một bình luận hiện đại được neo vào một AutoShape cụ thể. Sau đó đọc shape liên quan từ mỗi bình luận.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = draw.PointF(20, 20)
    shape_comment_position = draw.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Neo bình luận vào các loại Shape khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) đều có thể được dùng làm anchor cho shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/vi/python-net/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/vi/python-net/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại shape phổ biến và gắn một bình luận hiện đại vào từng shape.

```python
import base64
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"
    auto_shape_comment_position = draw.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = draw.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = draw.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = draw.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = draw.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Neo bình luận vào văn bản và đặt trạng thái**

Đối với một bình luận hiện đại gắn với một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/), thuộc tính [ModernComment.text_selection_start](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_start/) chỉ vị trí bắt đầu của đoạn văn bản được chọn trong khung văn bản của shape, trong khi [ModernComment.text_selection_length](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_length/) chỉ độ dài của đoạn chọn. Hai thuộc tính này kết hợp để gắn bình luận với một đoạn văn bản cụ thể bên trong AutoShape.

Thuộc tính [ModernComment.status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/status/) có thể được đọc hoặc cập nhật với một giá trị từ liệt kê [ModernCommentStatus](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — không có trạng thái bình luận hiện đại cụ thể nào được định nghĩa.
- `ACTIVE` — bình luận đang hoạt động.
- `RESOLVED` — bình luận đã được giải quyết.
- `CLOSED` — bình luận đã được đóng.

Ví dụ sau tạo một bình luận hiện đại được neo vào shape, gắn nó với một đoạn văn bản được chọn, đánh dấu là đã giải quyết, lưu bài trình chiếu và xác minh các giá trị sau khi mở lại tệp.

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

output_file = "modern_comment_text_anchor.pptx"
shape_text = "Review the quarterly revenue forecast."
selected_text = "quarterly revenue"
expected_selection_start = shape_text.index(selected_text)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 100)
    shape.name = "Forecast text"
    shape.text_frame.text = shape_text

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    comment_position = draw.PointF(60, 60)
    comment = author.comments.add_modern_comment("Verify this forecast wording.", slide, shape, comment_position, datetime.now())
    comment.text_selection_start = expected_selection_start
    comment.text_selection_length = len(selected_text)
    comment.status = slides.ModernCommentStatus.RESOLVED

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_comments = reopened_slide.get_slide_comments(None)

    for reopened_comment in reopened_comments:
        if not isinstance(reopened_comment, slides.ModernComment):
            continue

        shape_matches = reopened_comment.shape.name == "Forecast text"
        selection_start_matches = reopened_comment.text_selection_start == expected_selection_start
        selection_length_matches = reopened_comment.text_selection_length == len(selected_text)
        status_matches = reopened_comment.status == slides.ModernCommentStatus.RESOLVED

        print("Shape anchor preserved: " + str(shape_matches))
        print("Text selection start preserved: " + str(selection_start_matches))
        print("Text selection length preserved: " + str(selection_length_matches))
        print("Resolved status preserved: " + str(status_matches))
```

### **Kiểm tra các bình luận hiện đại hiện có**

Để kiểm tra một bài trình chiếu hiện có, xác định các bình luận nào là thể hiện của [ModernComment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/), sau đó xem xét [ModernComment.shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_length/) và [ModernComment.status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/status/). Một shape `None` cho biết đây là bình luận ở mức slide. Đối với anchor là một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/), các thuộc tính lựa chọn văn bản xác định đoạn liên quan trong khung văn bản của shape.

```python
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    for slide in presentation.slides:
        comments = slide.get_slide_comments(None)
        for comment in comments:
            if not isinstance(comment, slides.ModernComment):
                continue

            print("Slide: " + str(slide.slide_number))
            print("Text: " + comment.text)
            print("Status: " + str(comment.status))

            shape = comment.shape
            if shape is None:
                print("Anchor: slide level")
            else:
                print("Anchor shape: " + shape.name)
                print("Anchor type: " + type(shape).__name__)

                if isinstance(shape, slides.AutoShape):
                    print("Text selection start: " + str(comment.text_selection_start))
                    print("Text selection length: " + str(comment.text_selection_length))

            print()
```

## **Xóa bình luận**

### **Xóa tất cả bình luận và các tác giả bình luận**

Ví dụ sau cho thấy cách xóa tất cả bình luận và các tác giả bình luận khỏi một bài trình chiếu:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Xóa các bình luận cụ thể**

Ví dụ sau cho thấy cách xóa các bình luận cụ thể khỏi một slide:

```python
from datetime import datetime

import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = draw.PointF(0.2, 0.2)
    second_comment_position = draw.PointF(0.3, 0.2)
    author.comments.add_comment("comment 1", slide, first_comment_position, created_time)
    author.comments.add_comment("comment 2", slide, second_comment_position, created_time)

    for comment_author in presentation.comment_authors:
        comments_to_remove = []
        comments = slide.get_slide_comments(comment_author)

        for comment in comments:
            if comment.text == "comment 1":
                comments_to_remove.append(comment)

        for comment in comments_to_remove:
            comment_author.comments.remove(comment)

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho bình luận hiện đại không?**

Có. [ModernComment.status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/status/) có thể được đọc và đặt bằng một giá trị của [ModernCommentStatus](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncommentstatus/), bao gồm `RESOLVED`. Trạng thái được lưu trong bài trình chiếu và có thể đọc lại sau khi tệp được mở lại.

**Có hỗ trợ thảo luận dạng chuỗi (reply chains) không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi bình luận có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/parent_comment/), cho phép tạo chuỗi phản hồi. API không xác định một giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu đánh dấu bình luận trên slide được xác định bằng hệ tọa độ nào?**

Vị trí dấu đánh dấu được xác định bằng các tọa độ dấu chấm thập phân trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.