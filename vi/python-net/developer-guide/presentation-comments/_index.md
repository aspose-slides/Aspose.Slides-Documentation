---
title: Quản lý nhận xét bản trình chiếu trong Python
linktitle: Nhận xét bản trình chiếu
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
- xóa nhận xét
- xoá nhận xét
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý nhận xét bản trình chiếu với Aspose.Slides cho Python qua .NET: thêm, đọc, chỉnh sửa và xóa nhận xét trong các tệp PowerPoint một cách nhanh chóng và dễ dàng."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý các nhận xét trong bản trình chiếu bằng Aspose.Slides. Nó giới thiệu các kiểu liên quan đến nhận xét chính và trình bày cách thêm nhận xét vào các slide, truy cập các nhận xét hiện có, làm việc với phản hồi, sử dụng nhận xét hiện đại và xóa nhận xét khỏi bản trình chiếu.

Các ví dụ tập trung vào các kịch bản xem xét và cộng tác phổ biến trong PowerPoint, chẳng hạn như gán nhận xét cho tác giả, đọc nội dung và siêu dữ liệu của nhận xét, xây dựng chuỗi phản hồi, và xóa toàn bộ nhận xét hoặc xóa các nhận xét đã chọn.

Trong PowerPoint, một nhận xét xuất hiện như một ghi chú hoặc chú thích trên một slide. Khi nhấp vào nhận xét, nội dung hoặc tin nhắn của nó sẽ được hiển thị. 

## **Tại sao cần thêm nhận xét vào bản trình chiếu?**

Bạn có thể muốn sử dụng nhận xét để đưa ra phản hồi hoặc giao tiếp với đồng nghiệp khi xem xét bản trình chiếu.

Để cho phép bạn sử dụng nhận xét trong bản trình chiếu PowerPoint, Aspose.Slides for Python via .NET cung cấp

* Lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) , chứa bộ sưu tập các tác giả (từ thuộc tính [CommentAuthorCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentauthorcollection/)). Các tác giả thêm nhận xét vào các slide. 
* Lớp [CommentCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentcollection/) , chứa bộ sưu tập các nhận xét cho từng tác giả. 
* Lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/) , chứa thông tin về tác giả và nhận xét của họ: ai đã thêm nhận xét, thời gian thêm nhận xét, vị trí của nhận xét, v.v. 
* Lớp [CommentAuthor](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentauthor/) , chứa thông tin về từng tác giả: tên tác giả, ký hiệu viết tắt, các nhận xét gắn với tên tác giả, v.v. 

## **Thêm nhận xét vào slide**
Đoạn mã Python này cho bạn thấy cách thêm một nhận xét vào slide trong bản trình chiếu PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

# Khởi tạo lớp Presentation
with slides.Presentation() as presentation:
    # Thêm một slide trống
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    # Thêm một tác giả
    author = presentation.comment_authors.add_author("Jawad", "MF")

    # Đặt vị trí cho các nhận xét
    point = draw.PointF(0.2, 0.2)

    # Thêm nhận xét slide cho tác giả trên slide 1
    author.comments.add_comment("Hello Jawad, this is slide comment", presentation.slides[0], point, datetime.date.today())

    # Thêm nhận xét slide cho tác giả trên slide 2
    author.comments.add_comment("Hello Jawad, this is second slide comment", presentation.slides[1], point, datetime.date.today())

    # Truy cập ISlide 1
    slide = presentation.slides[0]

    # Khi truyền null làm đối số, các nhận xét từ tất cả các tác giả sẽ được lấy cho slide đã chọn
    comments = slide.get_slide_comments(author)

    # Truy cập nhận xét tại chỉ số 0 cho slide 1
    str = comments[0].text

    presentation.save("Comments_out.pptx", slides.export.SaveFormat.PPTX)

    if comments.length > 0:
        # Chọn bộ sưu tập nhận xét của tác giả tại chỉ số 0
        commentCollection = comments[0].author.comments
        print(commentCollection[0].text)
```



## **Truy cập nhận xét của slide**
Đoạn mã Python này cho bạn thấy cách truy cập một nhận xét hiện có trên slide trong bản trình chiếu PowerPoint:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation
with slides.Presentation("Comments1.pptx") as presentation:
    for author in presentation.comment_authors:
        for comment in author.comments:
            print("ISlide :" + str(comment.slide.slide_number) + 
            " has comment: " + comment.text + 
            " with Author: " + comment.author.name + 
            " posted on time :" + str(comment.created_time) + "\n")
```


## **Phản hồi nhận xét**
Một nhận xét cha là nhận xét gốc hoặc nhận xét ở cấp cao nhất trong một chuỗi nhận xét hoặc phản hồi. Sử dụng thuộc tính `parent_comment` (từ lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/)), bạn có thể thiết lập hoặc lấy nhận xét cha. 

Đoạn mã Python này cho bạn thấy cách thêm nhận xét và lấy các phản hồi của chúng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import datetime

with slides.Presentation() as pres:
    # Thêm một nhận xét
    author1 = pres.comment_authors.add_author("Author_1", "A.A.")
    comment1 = author1.comments.add_comment("comment1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    # Thêm phản hồi cho comment1
    author2 = pres.comment_authors.add_author("Autror_2", "B.B.")
    reply1 = author2.comments.add_comment("reply 1 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply1.parent_comment = comment1

    # Thêm một phản hồi khác cho comment1
    reply2 = author2.comments.add_comment("reply 2 for comment 1", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply2.parent_comment = comment1

    # Thêm phản hồi cho phản hồi hiện có
    subReply = author1.comments.add_comment("subreply 3 for reply 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    subReply.parent_comment = reply2

    comment2 = author2.comments.add_comment("comment 2", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    comment3 = author2.comments.add_comment("comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())

    reply3 = author1.comments.add_comment("reply 4 for comment 3", pres.slides[0], draw.PointF(10, 10), datetime.date.today())
    reply3.parent_comment = comment3

    # Hiển thị cấu trúc nhận xét trên console
    slide = pres.slides[0]
    comments = slide.get_slide_comments(None)
    for i in range(comments.length):
        comment = comments[i]
        while comment.parent_comment is not None:
            print("\t")
            comment = comment.parent_comment

        print(comments[i].author.name + " : " + comments[i].text)
        print("\r\n")

    pres.save("parent_comment.pptx", slides.export.SaveFormat.PPTX)

    # Xóa comment1 và tất cả các phản hồi của nó
    comment1.remove()

    pres.save("remove_comment.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Attention" %}} 
* Khi phương thức `remove` (từ lớp [Comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/comment/)) được sử dụng để xóa một nhận xét, các phản hồi của nhận xét cũng sẽ bị xóa. 
* Nếu thiết lập `parent_comment` gây ra một tham chiếu vòng, `PptxEditException` sẽ được ném ra.
{{% /alert %}}

## **Thêm nhận xét hiện đại**

Năm 2021, Microsoft đã giới thiệu *nhận xét hiện đại* trong PowerPoint. Tính năng nhận xét hiện đại cải thiện đáng kể khả năng cộng tác trong PowerPoint. Thông qua nhận xét hiện đại, người dùng PowerPoint có thể giải quyết nhận xét, gắn nhận xét vào đối tượng và văn bản, và tương tác một cách dễ dàng hơn nhiều so với trước đây. 

Chúng tôi đã triển khai hỗ trợ cho nhận xét hiện đại bằng cách thêm lớp [ModernComment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/). Các phương thức `add_modern_comment` và `insert_modern_comment` đã được thêm vào lớp [CommentCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/commentcollection/). 

Đoạn mã Python này cho bạn thấy cách thêm một nhận xét hiện đại vào slide trong bản trình chiếu PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as pres:
    newAuthor = pres.comment_authors.add_author("Some Author", "SA")
    modernComment = newAuthor.comments.add_modern_comment("This is a modern comment", pres.slides[0], None, draw.PointF(100, 100), date.today())

    pres.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa nhận xét**

### **Xóa tất cả nhận xét và tác giả**

Đoạn mã Python này cho bạn thấy cách xóa tất cả nhận xét và tác giả trong một bản trình chiếu:

```python
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    # Xóa tất cả nhận xét khỏi bản trình chiếu
    for author in presentation.comment_authors:
        author.comments.clear()

    # Xóa tất cả tác giả
    presentation.comment_authors.clear()

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Xóa các nhận xét cụ thể**

Đoạn mã Python này cho bạn thấy cách xóa các nhận xét cụ thể trên một slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides
from datetime import date

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # thêm nhận xét...
    author = presentation.comment_authors.add_author("Author", "A")
    author.comments.add_comment("comment 1", slide, draw.PointF(0.2, 0.2), date.today())
    author.comments.add_comment("comment 2", slide, draw.PointF(0.3, 0.2), date.today())
    
    # xóa tất cả nhận xét chứa văn bản "comment 1"
    for commentAuthor in presentation.comment_authors:
        toRemove = []
        for comment in slide.get_slide_comments(commentAuthor):
            if comment.text == "comment 1":
                toRemove.append(comment)
        
        for comment in toRemove:
            commentAuthor.comments.remove(comment)
    
    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ trạng thái như “đã giải quyết” cho nhận xét hiện đại không?**

Có. [Modern comments](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/) cung cấp thuộc tính [status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/status/); bạn có thể đọc và đặt [trạng thái của nhận xét](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncommentstatus/) (ví dụ, đánh dấu là đã giải quyết), và trạng thái này sẽ được lưu trong tệp và được PowerPoint nhận diện.

**Có hỗ trợ thảo luận dạng chuỗi (reply chains) không, và có giới hạn độ sâu lồng nhau không?**

Có. Mỗi nhận xét có thể tham chiếu tới [parent comment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/moderncomment/parent_comment/), cho phép tạo chuỗi phản hồi tùy ý. API không khai báo giới hạn độ sâu lồng nhau cụ thể.

**Vị trí của dấu đánh dấu nhận xét trên slide được định nghĩa trong hệ tọa độ nào?**

Vị trí được lưu dưới dạng một điểm số thực trong hệ tọa độ của slide. Điều này cho phép bạn đặt dấu đánh dấu nhận xét chính xác ở vị trí mong muốn.