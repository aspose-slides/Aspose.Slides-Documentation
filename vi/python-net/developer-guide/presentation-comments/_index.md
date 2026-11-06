---
title: Quản lý Nhận xét Bản trình chiếu trong Python
linktitle: Nhận xét Bản trình chiếu
type: docs
weight: 100
url: /vi/python-net/presentation-comments/
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
- loại bỏ nhận xét
- xóa nhận xét
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý nhận xét bản trình chiếu với Aspose.Slides cho Python qua .NET: thêm, đọc, chỉnh sửa, phản hồi và xóa nhận xét trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý nhận xét trong bản trình chiếu bằng Aspose.Slides cho Python qua .NET. Nó giới thiệu các kiểu liên quan đến nhận xét chính và minh họa cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với các phản hồi và nhận xét hiện đại, và xóa nhận xét khỏi một bản trình chiếu.

Các ví dụ bao phủ các kịch bản đánh giá và cộng tác thường gặp trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc văn bản và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa các nhận xét đã chọn hoặc tất cả các nhận xét.

Trong PowerPoint, nhận xét xuất hiện như các chú thích trên các slide. Khi chọn một nhận xét, nó hiển thị văn bản và cuộc thảo luận liên quan.

Để yêu cầu hiển thị hoặc ẩn nhận xét khi mở bản trình chiếu mà không thay đổi nhận xét, xem [Hiển thị hoặc Ẩn Nhận xét Khi Mở Bản Trình Chiếu](/slides/vi/python-net/presentation-view-properties/).

## **Tại sao cần Thêm Nhận xét vào Bản Trình Chiếu?**

Bạn có thể sử dụng nhận xét để cung cấp phản hồi và hợp tác với đồng nghiệp khi xem xét bản trình chiếu.

Aspose.Slides cho Python qua .NET cung cấp các API sau để làm việc với nhận xét:

* Lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) cung cấp quyền truy cập vào các tác giả nhận xét của bản trình chiếu.
* Lớp [CommentCollection](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/) đại diện cho các nhận xét liên quan tới một tác giả riêng lẻ.
* Lớp [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) cung cấp thông tin về một nhận xét, bao gồm tác giả, thời gian tạo, vị trí và văn bản.
* Lớp [CommentAuthor](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/) cung cấp thông tin về một tác giả, bao gồm tên, ký tự viết tắt và các nhận xét liên quan.

## **Thêm Nhận xét cho Slide**

Ví dụ tạo hai slide và đăng ký một tác giả nhận xét bằng [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/). Nó sử dụng [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) để đặt một nhận xét trên mỗi slide, sau đó lấy các nhận xét của slide đầu tiên cho tác giả đó bằng [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/). Console hiển thị văn bản của nhận xét đầu tiên hai lần, chứng minh khả năng truy cập cả qua slide và tác giả, và bản trình chiếu đã lưu chứa cả hai nhận xét.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    author = presentation.comment_authors.add_author("Jawad", "MF")
    position = slides.PointF(0.2, 0.2)
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

## **Tìm hoặc Tạo một Tác giả Nhận xét**

Khi một quá trình đánh giá tự động xử lý cùng một bản trình chiếu liên tục, hãy tìm trong bộ sưu tập [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/) trước khi thêm tác giả. [find_by_name_and_initials](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name_and_initials/) khớp cả tên và ký tự viết tắt và trả về một mảng các tác giả phù hợp, hoặc một mảng rỗng nếu không có kết quả. Ngược lại, [find_by_name](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/find_by_name/) tìm kiếm chỉ theo tên, bất kể ký tự viết tắt. Gọi [add_author](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/add_author/) với một tên và ký tự viết tắt đã tồn tại trong bộ sưu tập sẽ ném ra một ngoại lệ.

Ví dụ yêu cầu một tệp bản trình chiếu có ít nhất một slide. Trong mỗi trong hai lần chạy, nó tái sử dụng tác giả khớp đầu tiên, hoặc tạo mới chỉ khi kết quả là rỗng. Nếu có nhiều kết quả phù hợp, nó chọn phần tử đầu tiên của mảng mà không hợp nhất hay xóa các tác giả khác. Sau đó nó gọi [add_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_comment/) cho tác giả đã chọn và lưu bản trình chiếu. Lần chạy thứ hai mở đầu ra của lần chạy đầu tiên và lặp lại thao tác.

```python
from datetime import datetime

import aspose.slides as slides

author_name = "Reviewer"
author_initials = "RV"

input_file = "input.pptx"
position = slides.PointF(20, 20)

for pass_number in range(1, 3):
    with slides.Presentation(input_file) as presentation:
        matches = presentation.comment_authors.find_by_name_and_initials(author_name, author_initials)

        author = matches[0] if len(matches) > 0 else presentation.comment_authors.add_author(author_name, author_initials)
        author.comments.add_comment("Please review this slide.", presentation.slides[0], position, datetime.now())

        output_file = f"review_pass_{pass_number}.pptx"
        presentation.save(output_file, slides.export.SaveFormat.PPTX)
        input_file = output_file
```

Lần chạy thứ hai thêm một nhận xét khác mà không thêm tác giả mới hay xóa các nhận xét hiện có. Tệp cuối cùng, `review_pass_2.pptx`, chứa cả hai nhận xét mới cùng với bất kỳ nhận xét gốc nào. Việc tái sử dụng tác giả không loại bỏ trùng lặp nhận xét: để tránh việc thêm lặp lại cùng một nhận xét, bạn nên thực hiện phát hiện trùng lặp riêng trước khi thêm.

## **Truy cập Nhận xét của Slide**

Ví dụ mở một bản trình chiếu hiện có và đọc bộ sưu tập [comment_authors](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/comment_authors/). Đối với mỗi tác giả, nó lặp qua [comments](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthor/comments/) và in ra số slide, văn bản nhận xét, tên tác giả và thời gian tạo. Bản trình chiếu đầu vào phải chứa nhận xét để tạo ra đầu ra trên console.

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

## **Phản hồi cho Nhận xét**

Một nhận xét gốc là nhận xét ban đầu ở đầu một chuỗi phản hồi. Thuộc tính [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) của lớp [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) cho phép bạn lấy hoặc đặt phần cha của một nhận xét.

Ví dụ tạo nhận xét từ hai tác giả và sử dụng [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) để xây dựng các phản hồi, bao gồm một phản hồi cho một phản hồi khác. Truyền `None` vào [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) sẽ lấy các nhận xét từ mọi tác giả; console thụt lề mỗi mục theo độ sâu trong chuỗi phản hồi. Ví dụ lưu toàn bộ cuộc thảo luận, gọi [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) trên nhận xét gốc đầu tiên, và lưu một bản trình chiếu thứ hai với nhận xét đó và các phản hồi của nó đã bị xóa.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    position = slides.PointF(10, 10)
    created_time = datetime.now()

    original_author = presentation.comment_authors.add_author("Author_1", "A.A.")
    root_comment = original_author.comments.add_comment("comment 1", slide, position, created_time)

    reviewer = presentation.comment_authors.add_author("Author_2", "B.B.")
    first_reply = reviewer.comments.add_comment("reply 1 for comment 1", slide, position, created_time)
    first_reply.parent_comment = root_comment

    second_reply = reviewer.comments.add_comment("reply 2 for comment 1", slide, position, created_time)
    second_reply.parent_comment = root_comment

    sub_reply = original_author.comments.add_comment("subreply 3 for reply 2", slide, position, created_time)
    sub_reply.parent_comment = second_reply

    reviewer.comments.add_comment("comment 2", slide, position, created_time)
    separate_comment = reviewer.comments.add_comment("comment 3", slide, position, created_time)

    separate_reply = original_author.comments.add_comment("reply 4 for comment 3", slide, position, created_time)
    separate_reply.parent_comment = separate_comment

    comments = slide.get_slide_comments(None)
    for current_comment in comments:
        comment = current_comment
        while comment.parent_comment is not None:
            print("\t", end="")
            comment = comment.parent_comment

        print(current_comment.author.name + ": " + current_comment.text)

    presentation.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    root_comment.remove()
    presentation.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
* Khi phương thức [remove](https://reference.aspose.com/slides/python-net/aspose.slides/comment/remove/) của lớp [Comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/) được sử dụng để xóa một nhận xét, tất cả các phản hồi của nhận xét đó cũng sẽ bị xóa.
* Nếu thuộc tính [parent_comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/) tạo ra một tham chiếu vòng, một [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) sẽ được ném.
{{% /alert %}}

## **Thêm Nhận xét Hiện đại**

Nhận xét hiện đại có thể được gắn với chính slide, với một shape cụ thể, hoặc với một đoạn văn bản trong một AutoShape. Phương thức [CommentCollection.add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) chấp nhận một đối số [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ngoài slide và tọa độ của dấu nhận xét.

Khi truyền `None` cho đối số shape, nhận xét sẽ là nhận xét cấp slide. Dấu nhận xét được đặt bằng các tọa độ đã cung cấp, nhưng không gắn với shape nào, do đó [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) trả về `None`. Khi cung cấp một [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), nhận xét sẽ được neo vào shape đó. Các tọa độ vẫn xác định vị trí của dấu nhận xét trên slide, trong khi thông tin về shape có thể được lấy thông qua [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/).

### **Gắn Nhận xét Hiện đại vào một Shape**

Ví dụ gọi [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) hai lần: một lần với shape `None` cho một nhận xét cấp slide và một lần với một hình chữ nhật làm neo. Đọc [shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/) in ra `True` cho kiểm tra null của nhận xét cấp slide và `Revenue title` cho nhận xét được neo. Cả hai nhận xét đều được lưu cùng bản trình chiếu.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 300, 80)
    shape.name = "Revenue title"
    shape.text_frame.text = "Quarterly revenue"

    created_time = datetime.now()
    slide_comment_position = slides.PointF(20, 20)
    shape_comment_position = slides.PointF(60, 60)
    slide_comment = author.comments.add_modern_comment("Review the overall slide layout.", slide, None, slide_comment_position, created_time)
    shape_comment = author.comments.add_modern_comment("Check this title.", slide, shape, shape_comment_position, created_time)

    print(slide_comment.shape is None)
    print(shape_comment.shape.name)

    presentation.save("modern_comments.pptx", slides.export.SaveFormat.PPTX)
```

### **Gắn Nhận xét vào Các Loại Shape Khác nhau**

Bất kỳ đối tượng slide nào kế thừa từ [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) đều có thể dùng làm neo shape. Các ví dụ phổ biến bao gồm [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/), và các đối tượng [GraphicalObject](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobject/) như biểu đồ.

Ví dụ sử dụng [add_modern_comment](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/add_modern_comment/) để liên kết một nhận xét với mỗi trong năm kiểu shape: một AutoShape, một picture frame, một nhóm, một connector và một biểu đồ. Hình ảnh được nhúng dữ liệu, vì vậy không cần hình ảnh bên ngoài. Mỗi nhận xét có vị trí dấu riêng, và bản trình chiếu đã lưu giữ lại tất cả năm liên kết shape.

```python
import base64
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Reviewer", "RV")
    created_time = datetime.now()

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 180, 60)
    auto_shape.text_frame.text = "AutoShape"

    auto_shape_comment_position = slides.PointF(30, 30)
    author.comments.add_modern_comment("Comment on an AutoShape.", slide, auto_shape, auto_shape_comment_position, created_time)

    image_base64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg=="
    image_data = base64.b64decode(image_base64)
    image = presentation.images.add_image(image_data)
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 120, 80, image)
    picture_comment_position = slides.PointF(230, 30)
    author.comments.add_modern_comment("Comment on a picture.", slide, picture_frame, picture_comment_position, created_time)

    group_shape = slide.shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 80, 40)
    group_shape.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 100, 0, 80, 40)
    group_comment_position = slides.PointF(40, 150)
    author.comments.add_modern_comment("Comment on a group.", slide, group_shape, group_comment_position, created_time)

    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 220, 150, 140, 40)
    connector_comment_position = slides.PointF(240, 150)
    author.comments.add_modern_comment("Comment on a connector.", slide, connector, connector_comment_position, created_time)

    chart = slide.shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 400, 20, 250, 180)
    chart_comment_position = slides.PointF(420, 40)
    author.comments.add_modern_comment("Comment on a graphical object.", slide, chart, chart_comment_position, created_time)

    presentation.save("modern_comment_shape_types.pptx", slides.export.SaveFormat.PPTX)
```

### **Gắn Nhận xét vào Văn bản và Đặt Trạng thái của Nó**

Đối với một nhận xét hiện đại gắn với một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) chỉ vị trí bắt đầu của đoạn văn bản được chọn trong khung văn bản của shape, trong khi [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) chỉ độ dài của đoạn chọn. Hai thuộc tính này cùng nhau gắn nhận xét với một đoạn văn bản cụ thể trong AutoShape.

Thuộc tính [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) có thể được đọc hoặc cập nhật bằng một giá trị từ enumeration [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/):

- `NOT_DEFINED` — không có trạng thái nhận xét hiện đại cụ thể nào được định nghĩa.
- `ACTIVE` — nhận xét đang hoạt động.
- `RESOLVED` — nhận xét đã được giải quyết.
- `CLOSED` — nhận xét đã đóng.

Ví dụ gắn một nhận xét hiện đại vào các từ “quarterly revenue” trong văn bản của một hình chữ nhật. Nó tính toán [text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/) dựa trên văn bản và đặt [text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) thành số ký tự đã chọn. Sau khi đặt [status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) thành `RESOLVED`, nó lưu và mở lại bản trình chiếu. Bốn kiểm tra trên console sẽ mỗi lần in ra `True`, xác nhận rằng neo shape, đoạn văn bản và trạng thái đã được bảo lưu.

```python
from datetime import datetime

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
    comment_position = slides.PointF(60, 60)
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

### **Kiểm tra Nhận xét Hiện đại hiện có**

Ví dụ yêu cầu một bản trình chiếu hiện có chứa các nhận xét hiện đại và in ra văn bản, trạng thái và chi tiết neo của chúng. Để kiểm tra, xác định các nhận xét là thể hiện của [ModernComment](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/), sau đó xem xét [ModernComment.shape](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/shape/), [ModernComment.text_selection_start](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_start/), [ModernComment.text_selection_length](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/text_selection_length/) và [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/). Một shape `None` cho biết là nhận xét cấp slide. Đối với một neo [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), các thuộc tính lựa chọn văn bản xác định khoảng văn bản liên quan trong khung văn bản của shape.

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

## **Xóa Nhận xét**

Aspose.Slides cho Python qua .NET cho phép bạn xóa tất cả nhận xét và các tác giả của chúng khỏi một bản trình chiếu hoặc xóa các nhận xét đã chọn trong khi giữ lại phần còn lại. Các ví dụ sau minh họa cả hai cách và lưu bản trình chiếu đã cập nhật.

### **Xóa Tất cả Nhận xét và Tác giả Nhận xét**

Ví dụ mở một bản trình chiếu hiện có và gọi [CommentCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/clear/) cho mỗi tác giả, sau đó gọi [CommentAuthorCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/commentauthorcollection/clear/) để xóa các tác giả. Bản trình chiếu đã lưu không còn nhận xét cũng như tác giả nhận xét. Hãy sử dụng một bản trình chiếu có nhận xét để quan sát quá trình xóa.

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    for author in presentation.comment_authors:
        author.comments.clear()

    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Xóa các Nhận xét Cụ thể**

Ví dụ tạo hai nhận xét trên một slide và sử dụng [get_slide_comments](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_slide_comments/) để tìm nhận xét của mỗi tác giả. Nó thu thập các nhận xét có văn bản bằng “comment 1” trước khi gọi [CommentCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/commentcollection/remove/), tránh việc thay đổi bộ sưu tập trong quá trình lựa chọn. Bản trình chiếu đã lưu chỉ còn “comment 2”.

```python
from datetime import datetime

import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    author = presentation.comment_authors.add_author("Author", "A")
    created_time = datetime.now()

    first_comment_position = slides.PointF(0.2, 0.2)
    second_comment_position = slides.PointF(0.3, 0.2)
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

Có. [ModernComment.status](https://reference.aspose.com/slides/python-net/aspose.slides/moderncomment/status/) có thể được đọc và đặt bằng một giá trị từ enumeration [ModernCommentStatus](https://reference.aspose.com/slides/python-net/aspose.slides/moderncommentstatus/), bao gồm `RESOLVED`. Trạng thái được lưu trong bản trình chiếu và có thể được đọc lại sau khi tệp được mở lại.

**Các cuộc thảo luận dạng chuỗi (reply chains) có được hỗ trợ không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/python-net/aspose.slides/comment/parent_comment/), cho phép tạo chuỗi phản hồi. API không định nghĩa một giới hạn độ sâu lồng nhau cụ thể.

**Vị trí đánh dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí dấu nhận xét được xác định bằng các tọa độ kiểu floating‑point trong hệ tọa độ của slide, cho phép bạn đặt nó một cách chính xác trên slide.