---
title: Quản lý nhận xét trong bài thuyết trình bằng Python
linktitle: Nhận xét bài thuyết trình
type: docs
weight: 100
url: /vi/python-net/presentation-comments/
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
- xóa nhận xét
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Quản lý nhận xét trong bài thuyết trình với Aspose.Slides cho Python qua .NET: thêm, đọc, chỉnh sửa, phản hồi và xóa nhận xét trong các bài thuyết trình PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bài thuyết trình bằng Aspose.Slides cho Python qua .NET. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với phản hồi và nhận xét hiện đại, và xóa nhận xét khỏi một bài thuyết trình.

Các ví dụ bao gồm các kịch bản đánh giá và cộng tác phổ biến trong PowerPoint, chẳng hạn gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa các nhận xét đã chọn hoặc toàn bộ nhận xét.

Trong PowerPoint, nhận xét xuất hiện dưới dạng chú thích trên các slide. Khi chọn một nhận xét, nó hiển thị văn bản và cuộc thảo luận liên quan.

## **Tại sao thêm nhận xét vào bài thuyết trình?**

Bạn có thể sử dụng nhận xét để cung cấp phản hồi và cộng tác với đồng nghiệp khi đánh giá các bài thuyết trình.

Aspose.Slides cho Python qua .NET cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả nhận xét của bài thuyết trình.
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentcollection/) đại diện cho các nhận xét liên quan đến một tác giả cá nhân.
* Lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/) cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và nội dung.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, chữ viết tắt và các nhận xét liên quan.

## **Thêm nhận xét vào slide**

Ví dụ sau cho thấy cách thêm nhận xét vào các slide trong một bài thuyết trình PowerPoint:

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

## **Truy cập nhận xét trên slide**

Ví dụ sau cho thấy cách truy cập các nhận xét hiện có trong một bài thuyết trình PowerPoint:

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

## **Phản hồi cho nhận xét**

Một nhận xét cha là nhận xét gốc ở đầu của một chuỗi phản hồi. Thuộc tính [parent_comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/parent_comment/) của lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/) cho phép bạn lấy hoặc đặt cha của một nhận xét.

Ví dụ sau cho thấy cách thêm phản hồi và kiểm tra cấu trúc nhận xét tạo ra:

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

{{% alert color="warning" title="Cảnh báo" %}}
* Khi phương thức [remove](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/remove/) của lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/) được sử dụng để xóa một nhận xét, tất cả các phản hồi của nhận xét đó cũng sẽ bị xóa.
* Nếu thuộc tính [parent_comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/parent_comment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm nhận xét hiện đại**

Nhận xét hiện đại có thể được liên kết với chính slide, với một hình dạng cụ thể, hoặc với một đoạn văn bản bên trong một AutoShape. Phương thức [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentcollection/add_modern_comment/) nhận một đối số [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) ngoài slide và tọa độ của bộ đánh dấu nhận xét.

Khi `None` được truyền cho đối số shape, nhận xét là một nhận xét ở mức slide. Bộ đánh dấu của nó được định vị bằng các tọa độ đã cung cấp, nhưng không gắn với một hình dạng cụ thể, vì vậy [ModernComment.shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/shape/) trả về `None`. Khi một [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) được cung cấp, nhận xét được neo vào hình dạng đó. Các tọa độ vẫn xác định vị trí của bộ đánh dấu nhận xét trên slide, trong khi việc gắn kết hình dạng có thể được truy xuất qua [ModernComment.shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/shape/).

### **Neo một nhận xét hiện đại vào một Shape**

Ví dụ sau tạo cả một nhận xét hiện đại ở mức slide và một nhận xét hiện đại được neo vào một AutoShape cụ thể. Sau đó nó đọc shape liên quan từ mỗi nhận xét.

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

### **Neo nhận xét vào các loại Shape khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) đều có thể được dùng làm neo shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/vi/python-net/aspose.slides/connector/), và các thể hiện [GraphicalObject](https://reference.aspose.com/slides/vi/python-net/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sau tạo một số loại shape phổ biến và gắn một nhận xét hiện đại vào mỗi shape.

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

### **Neo nhận xét vào văn bản và đặt trạng thái**

Đối với một nhận xét hiện đại được gắn với một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/), thuộc tính [ModernComment.text_selection_start](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_start/) chỉ vị trí bắt đầu của văn bản đã chọn trong khung văn bản của shape, trong khi [ModernComment.text_selection_length](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_length/) chỉ độ dài của lựa chọn. Hai thuộc tính này kết hợp để liên kết nhận xét với một đoạn văn bản cụ thể bên trong AutoShape.

Thuộc tính [ModernComment.status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/status/) có thể được đọc hoặc cập nhật với một giá trị từ enum [ModernCommentStatus](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — không có trạng thái nhận xét hiện đại cụ thể nào được định nghĩa.
- `ACTIVE` — nhận xét đang hoạt động.
- `RESOLVED` — nhận xét đã được giải quyết.
- `CLOSED` — nhận xét đã đóng.

Ví dụ sau tạo một nhận xét hiện đại được neo vào shape, gắn nó với một đoạn văn bản đã chọn, đánh dấu là đã giải quyết, lưu bài thuyết trình và xác minh các giá trị sau khi mở lại tệp.

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

### **Kiểm tra các nhận xét hiện đại hiện có**

Để kiểm tra một bài thuyết trình hiện có, xác định các nhận xét nào là thể hiện của [ModernComment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/), sau đó xem xét [ModernComment.shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/text_selection_length/), và [ModernComment.status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/status/). Một shape `None` cho thấy đó là một nhận xét ở mức slide. Đối với một neo AutoShape, các thuộc tính chọn văn bản xác định đoạn văn bản liên quan trong khung văn bản của shape.

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

## **Xóa nhận xét**

### **Xóa toàn bộ nhận xét và tác giả nhận xét**

Ví dụ sau cho thấy cách xóa toàn bộ nhận xét và các tác giả nhận xét khỏi một bài thuyết trình:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()
    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Xóa các nhận xét cụ thể**

Ví dụ sau cho thấy cách xóa các nhận xét cụ thể khỏi một slide:

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

**Aspose.Slides có hỗ trợ trạng thái đã giải quyết cho nhận xét hiện đại không?**

Có. Thuộc tính [ModernComment.status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/status/) có thể được đọc và đặt bằng một giá trị của [ModernCommentStatus](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncommentstatus/), bao gồm `RESOLVED`. Trạng thái được lưu trong bài thuyết trình và có thể được đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi trả lời có được hỗ trợ không, và có giới hạn độ sâu không?**

Có. Mỗi nhận xét có thể tham chiếu đến [parent comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/parent_comment/), cho phép tạo chuỗi trả lời. API không định nghĩa giới hạn độ sâu cụ thể nào.

**Vị trí của bộ đánh dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí của bộ đánh dấu được định nghĩa bằng các tọa độ số thực trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.