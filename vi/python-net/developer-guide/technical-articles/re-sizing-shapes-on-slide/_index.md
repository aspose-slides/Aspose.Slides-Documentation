---
title: Thay đổi kích thước các hình dạng trong bài thuyết trình bằng Python
linktitle: Thay đổi kích thước hình dạng
type: docs
weight: 130
url: /vi/python-net/re-sizing-shapes-on-slide/
keywords:
- thay đổi kích thước hình dạng
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Dễ dàng thay đổi kích thước các hình dạng trên slide PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET—tự động điều chỉnh bố cục slide và tăng năng suất."
---
## **Tổng quan**

Một trong những câu hỏi phổ biến nhất từ khách hàng sử dụng Aspose.Slides cho Python là làm thế nào để thay đổi kích thước các hình dạng sao cho khi kích thước slide thay đổi, dữ liệu không bị cắt. Bài viết kỹ thuật ngắn này cho thấy cách thực hiện.

## **Thay đổi kích thước các hình dạng**

Để ngăn các hình dạng bị lệch khi kích thước slide thay đổi, hãy cập nhật vị trí và kích thước của từng hình dạng sao cho chúng phù hợp với bố cục slide mới.

```py
import aspose.slides as slides

# Tải tệp bài thuyết trình.
with slides.Presentation("sample.pptx") as presentation:
    # Lấy kích thước slide gốc.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Thay đổi kích thước slide mà không tỷ lệ các hình dạng hiện có.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Lấy kích thước slide mới.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Thay đổi kích thước và vị trí các hình dạng trên mọi slide.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Tỷ lệ kích thước hình dạng.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Tỷ lệ vị trí hình dạng.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Nếu một slide chứa bảng, đoạn mã trên sẽ không hoạt động đúng. Trong trường hợp đó, mỗi ô trong bảng phải được thay đổi kích thước.
{{% /alert %}} 

Sử dụng đoạn mã dưới đây để thay đổi kích thước các slide có chứa bảng. Đối với bảng, việc đặt chiều rộng hoặc chiều cao là một trường hợp đặc biệt: bạn phải điều chỉnh chiều cao của từng hàng và chiều rộng của từng cột để thay đổi kích thước tổng thể của bảng.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Lấy kích thước slide gốc.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Thay đổi kích thước slide mà không tỷ lệ các hình dạng hiện có.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Lấy kích thước slide mới.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Tỷ lệ kích thước hình dạng.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Tỷ lệ vị trí hình dạng.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Tỷ lệ kích thước hình dạng.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Tỷ lệ vị trí hình dạng.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Tỷ lệ kích thước hình dạng.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Tỷ lệ vị trí hình dạng.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**

Khi thay đổi kích thước slide, các hình dạng giữ nguyên vị trí và kích thước ban đầu trừ khi tỷ lệ được thay đổi một cách rõ ràng. Điều này có thể dẫn đến nội dung bị cắt hoặc các hình dạng bị lệch.

**Mã được cung cấp có hoạt động cho mọi loại hình dạng không?**

Ví dụ cơ bản hoạt động cho hầu hết các loại hình dạng (hộp văn bản, hình ảnh, biểu đồ, v.v.). Tuy nhiên, đối với bảng, bạn cần xử lý hàng và cột riêng biệt, vì chiều cao và chiều rộng của bảng được xác định bởi kích thước của các ô riêng lẻ.

**Làm thế nào để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Bạn cần lặp qua toàn bộ các hàng và cột của bảng và thay đổi chiều cao và chiều rộng của chúng một cách tỷ lệ, như được minh họa trong ví dụ mã thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các master slide và layout slide không?**

Có, nhưng bạn cũng nên duyệt qua [Masters](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/masters/) và [Layout slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/layout_slides/) và áp dụng cùng logic tỷ lệ cho các hình dạng của chúng để đảm bảo tính nhất quán trong toàn bộ bài thuyết trình.

**Tôi có thể thay đổi hướng của slide (chân dung/ngang) cùng với việc thay đổi kích thước không?**

Có. Bạn có thể sử dụng [presentation.slide_size.orientation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/islidesize/orientation/) để thay đổi hướng. Đảm bảo bạn thiết lập logic tỷ lệ phù hợp để duy trì bố cục.

**Có giới hạn nào cho kích thước slide tôi có thể đặt không?**

Aspose.Slides hỗ trợ các kích thước tùy chỉnh, nhưng kích thước quá lớn có thể ảnh hưởng đến hiệu suất hoặc khả năng tương thích với một số phiên bản PowerPoint.

**Làm thế nào để ngăn các hình dạng có tỷ lệ khung cố định bị biến dạng?**

Bạn có thể kiểm tra thuộc tính `aspect_ratio_locked` của hình dạng trước khi thực hiện tỷ lệ. Nếu thuộc tính này được khóa, hãy điều chỉnh chiều rộng hoặc chiều cao một cách tỷ lệ thay vì thay đổi chúng riêng lẻ.