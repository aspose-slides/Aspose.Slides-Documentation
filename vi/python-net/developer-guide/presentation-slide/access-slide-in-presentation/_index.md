---
title: Truy cập các slide trong bản trình chiếu bằng Python
linktitle: Truy cập Slide
type: docs
weight: 20
url: /vi/python-net/access-slide-in-presentation/
keywords:
- truy cập slide
- chỉ mục slide
- id slide
- vị trí slide
- thay đổi vị trí
- thuộc tính slide
- số slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách truy cập và quản lý các slide trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET. Tăng năng suất với các ví dụ mã."
---
## **Tổng quan**

Bài viết này giải thích cách truy cập các slide cụ thể trong một bản trình chiếu PowerPoint bằng Aspose.Slides for Python. Nó cho thấy cách mở bản trình chiếu, tham chiếu các slide theo chỉ mục hoặc theo ID duy nhất, và đọc các thông tin cơ bản của slide cần thiết cho việc điều hướng trong tệp. Với các kỹ thuật này, bạn có thể xác định một cách đáng tin cậy slide chính xác mà bạn muốn kiểm tra hoặc xử lý.

## **Truy cập slide theo chỉ mục**

Các slide trong bản trình chiếu được đánh chỉ mục theo vị trí, bắt đầu từ 0. Slide đầu tiên có chỉ mục 0, slide thứ hai có chỉ mục 1, và tiếp tục như vậy.

Lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) (đại diện cho tệp bản trình chiếu) cung cấp các slide thông qua một [SlideCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) của các đối tượng [Slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/).

Đoạn mã Python sau cho thấy cách truy cập một slide theo chỉ mục của nó:

```python
import aspose.slides as slides

# Tạo một Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    # Lấy một slide theo chỉ mục của nó.
    slide = presentation.slides[0]
```

## **Truy cập slide theo ID**

Mỗi slide trong bản trình chiếu có một ID duy nhất liên kết với nó. Bạn có thể dùng phương thức [get_slide_by_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_slide_by_id/) (được lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cung cấp) để truy cập ID đó.

Đoạn mã Python sau cho thấy cách cung cấp một ID slide hợp lệ và truy cập slide đó thông qua phương thức [get_slide_by_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# Tạo một Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    # Lấy ID của slide.
    id = presentation.slides[0].slide_id
    # Truy cập slide bằng ID của nó.
    slide = presentation.get_slide_by_id(id)
```

## **Thay đổi vị trí của slide**

Aspose.Slides cho phép bạn thay đổi vị trí của một slide. Ví dụ, bạn có thể làm cho slide đầu tiên trở thành slide thứ hai.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide mà bạn muốn thay đổi vị trí bằng chỉ mục của nó.
1. Đặt vị trí mới cho slide thông qua thuộc tính [slide_number](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/slide_number/).
1. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã Python sau di chuyển slide ở vị trí 1 tới vị trí 2:

```python
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    # Lấy slide mà vị trí sẽ được thay đổi.
    slide = presentation.slides[0]
    # Đặt vị trí mới cho slide.
    slide.slide_number = 2
    # Lưu bản trình chiếu đã chỉnh sửa.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Slide đầu tiên trở thành slide thứ hai; slide thứ hai trở thành slide đầu tiên. Khi bạn thay đổi vị trí của một slide, các slide khác sẽ tự động được điều chỉnh.

## **Đặt số slide**

Sử dụng thuộc tính [first_slide_number](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/first_slide_number/) (được lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) cung cấp), bạn có thể chỉ định một số mới cho slide đầu tiên trong bản trình chiếu. Thao tác này sẽ làm cho các số slide khác được tính lại.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Đặt số slide.
1. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã Python sau minh họa một thao tác mà trong đó số slide đầu tiên được đặt thành 10:

```python
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation("sample.pptx") as presentation:
    # Đặt số slide.
    presentation.first_slide_number = 10
    # Lưu bản trình chiếu đã chỉnh sửa.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Nếu bạn muốn bỏ qua slide đầu tiên, bạn có thể bắt đầu đánh số từ slide thứ hai (và ẩn số trên slide đầu tiên) như sau:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Đặt số cho slide đầu tiên trong bản trình chiếu.
    presentation.first_slide_number = 0

    # Hiển thị số slide cho tất cả các slide.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Ẩn số slide trên slide đầu tiên.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Lưu bản trình chiếu đã chỉnh sửa.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Số slide người dùng thấy có khớp với chỉ mục bắt đầu từ 0 của bộ sưu tập không?**

Số hiển thị trên slide có thể bắt đầu từ một giá trị tùy ý (ví dụ, 10) và không nhất thiết phải khớp với chỉ mục; mối quan hệ này được điều khiển bởi cài đặt [first slide number](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/first_slide_number/) của bản trình chiếu.

**Các slide ẩn có ảnh hưởng đến việc đánh chỉ mục không?**

Có. Một slide ẩn vẫn tồn tại trong bộ sưu tập và được tính trong việc đánh chỉ mục; “ẩn” chỉ đề cập đến việc hiển thị, không liên quan đến vị trí của nó trong bộ sưu tập.

**Chỉ mục của slide có thay đổi khi các slide khác được thêm hoặc xóa không?**

Có. Chỉ mục luôn phản ánh thứ tự hiện tại của các slide và được tính lại khi thực hiện các thao tác chèn, xóa và di chuyển.