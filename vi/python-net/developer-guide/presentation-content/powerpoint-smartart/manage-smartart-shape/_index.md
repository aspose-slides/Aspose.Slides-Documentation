---
title: Quản lý Đồ họa SmartArt trong Bản trình bày bằng Python
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/python-net/manage-smartart-shape/
keywords:
- đối tượng SmartArt
- đồ họa SmartArt
- phong cách SmartArt
- màu SmartArt
- tạo SmartArt
- thêm SmartArt
- chỉnh sửa SmartArt
- thay đổi SmartArt
- truy cập SmartArt
- kiểu bố cục SmartArt
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tự động hóa việc tạo, chỉnh sửa và tạo kiểu SmartArt trong PowerPoint bằng Python qua .NET sử dụng Aspose.Slides, với các ví dụ mã ngắn gọn và hướng dẫn tập trung vào hiệu năng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý các đồ họa SmartArt trong bản trình bày PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình SmartArt vào slide, truy cập các hình SmartArt hiện có, tìm SmartArt theo một kiểu bố cục cụ thể, và cập nhật giao diện của nó bằng cách thay đổi phong cách SmartArt hoặc phong cách màu.

Các ví dụ cho thấy cách làm việc với các hình SmartArt thông qua bộ sưu tập hình trên slide của bản trình bày, kiểm tra xem một hình có phải là SmartArt không và sau đó sửa đổi hoặc kiểm tra các thuộc tính của nó.

## **Tạo các hình SmartArt**

Aspose.Slides for Python via .NET cho phép bạn thêm các hình SmartArt tùy chỉnh vào slide từ đầu. API làm cho việc này trở nên dễ dàng. Để thêm một hình SmartArt vào slide:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy slide đích bằng chỉ mục của nó.
1. Thêm một hình SmartArt, chỉ định kiểu bố cục của nó.
1. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Khởi tạo lớp Presentation.
with slides.Presentation() as presentation:
    # Truy cập slide của bản trình bày.
    slide = presentation.slides[0]
    # Thêm một hình SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Lưu bản trình bày vào đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập các hình SmartArt trên slide**

Đoạn mã sau minh họa cách truy cập các hình SmartArt trên một slide. Mẫu lặp qua từng hình trên slide và kiểm tra xem nó có phải là đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/) hay không.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Tải tệp bản trình bày.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Lặp qua mọi hình trên slide đầu tiên.
    for shape in presentation.slides[0].shapes:
        # Kiểm tra xem hình có phải là hình SmartArt hay không.
        if isinstance(shape, smartart.SmartArt):
            # In tên hình.
            print("Shape name:", shape.name)
```

## **Truy cập các hình SmartArt với Kiểu Bố Cục Được chỉ định**

Ví dụ dưới đây cho thấy cách truy cập một hình SmartArt với một kiểu bố cục được chỉ định. Lưu ý rằng bạn không thể thay đổi kiểu bố cục của SmartArt—nó chỉ đọc và được đặt khi tạo hình.

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình bày chứa hình SmartArt.
1. Lấy tham chiếu tới slide đầu tiên bằng chỉ mục.
1. Lặp qua mọi hình trên slide đầu tiên.
1. Kiểm tra xem hình có phải là đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/) không.
1. Nếu kiểu bố cục của hình SmartArt khớp với yêu cầu, thực hiện các hành động cần thiết.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Lặp qua mọi hình trên slide đầu tiên.
    for shape in presentation.slides[0].shapes:
        # Kiểm tra xem hình có phải là hình SmartArt hay không.
        if isinstance(shape, smartart.SmartArt):
            # Kiểm tra kiểu bố cục SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Thay đổi Phong cách Hình SmartArt**

Ví dụ dưới đây cho thấy cách định vị các hình SmartArt và thay đổi phong cách của chúng:

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải tệp chứa các hình SmartArt.
1. Lấy tham chiếu tới slide đầu tiên bằng chỉ mục.
1. Lặp qua từng hình trên slide đầu tiên.
1. Tìm hình SmartArt với phong cách được chỉ định.
1. Gán phong cách mới cho hình SmartArt.
1. Lưu bản trình bày.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Lặp qua mọi hình trên slide đầu tiên.
    for shape in presentation.slides[0].shapes:
        # Kiểm tra xem hình có phải là hình SmartArt hay không.
        if isinstance(shape, smartart.SmartArt):
            # Kiểm tra phong cách SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Thay đổi phong cách SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Lưu bản trình bày.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Thay đổi Phong cách Màu của các hình SmartArt**

Ví dụ này cho thấy cách thay đổi phong cách màu của một hình SmartArt. Mã mẫu định vị một hình SmartArt với phong cách màu được chỉ định và cập nhật nó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình bày chứa các hình SmartArt.
1. Lấy tham chiếu tới slide đầu tiên bằng chỉ mục.
1. Lặp qua từng hình trên slide đầu tiên.
1. Kiểm tra xem hình có phải là đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/) không.
1. Định vị hình SmartArt với phong cách màu được chỉ định.
1. Đặt phong cách màu mới cho hình SmartArt đó.
1. Lưu bản trình bày.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Lặp qua mọi hình trên slide đầu tiên.
    for shape in presentation.slides[0].shapes:
        # Kiểm tra xem hình có phải là hình SmartArt hay không.
        if isinstance(shape, smartart.SmartArt):
            # Kiểm tra kiểu màu.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Thay đổi kiểu màu.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Lưu bản trình bày.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể hoạt hình hóa SmartArt như một đối tượng duy nhất không?**

Có. SmartArt là một hình, vì vậy bạn có thể áp dụng [các hoạt hình tiêu chuẩn](/slides/vi/python-net/powerpoint-animation/) qua API hoạt hình (đầu vào, thoát, nhấn mạnh, đường chuyển động) giống như với các hình khác.

**Làm sao tôi tìm được SmartArt cụ thể trên slide nếu không biết ID nội bộ của nó?**

Đặt và sử dụng Văn bản Thay thế (AltText) và tìm kiếm hình bằng giá trị đó—đây là cách được khuyến nghị để xác định hình mục tiêu.

**Tôi có thể nhóm SmartArt với các hình khác không?**

Có. Bạn có thể nhóm SmartArt với các hình khác (hình ảnh, bảng, v.v.) và sau đó [thao tác với nhóm](/slides/vi/python-net/group/).

**Làm sao tôi lấy được hình ảnh của một SmartArt cụ thể (ví dụ để xem trước hoặc báo cáo)?**

Xuất một hình thu nhỏ/hình ảnh của hình; thư viện có thể [render các hình riêng lẻ](/slides/vi/python-net/create-shape-thumbnails/) ra các tệp raster (PNG/JPG/TIFF).

**Giao diện của SmartArt có được bảo toàn khi chuyển đổi toàn bộ bản trình bày sang PDF không?**

Có. Động cơ render nhắm tới độ trung thực cao cho [xuất PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), với một loạt tùy chọn chất lượng và khả năng tương thích.