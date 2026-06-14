---
title: Lấy nền slide toàn bộ từ bản trình bày dưới dạng hình ảnh
linktitle: Nền Slide Toàn Bộ
type: docs
weight: 95
url: /vi/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- trình chiếu
- nền
- nền slide
- nền cuối cùng
- nền thành hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Trích xuất nền slide đầy đủ dưới dạng hình ảnh từ các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET, giúp đơn giản hóa quy trình làm việc trực quan."
---
## **Tổng quan**

Trong các bài thuyết trình PowerPoint, nền của một slide có thể được tạo thành từ nhiều yếu tố, bao gồm hình nền slide, giao diện bài thuyết trình, bảng màu và các đối tượng được đặt trên slide chủ hoặc slide bố cục.

Bài viết này mô tả cách trích xuất toàn bộ nền slide dưới dạng hình ảnh bằng Aspose.Slides. Vì không có một phương pháp duy nhất cho nhiệm vụ này, cách tiếp cận bao gồm sao chép slide đã chọn vào một bản trình bày tạm thời, xóa các hình dạng trên slide, và sau đó chuyển nền slide kết quả thành hình ảnh.

## **Lấy toàn bộ nền slide**

Aspose.Slides cho Python không cung cấp một phương thức đơn giản để trích xuất toàn bộ nền slide của bản trình bày dưới dạng hình ảnh, nhưng bạn có thể thực hiện các bước dưới đây để làm điều đó:
1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy kích thước slide từ bản trình bày.
1. Chọn một slide.
1. Tạo một bản trình bày tạm thời.
1. Đặt cùng kích thước slide trong bản trình bày tạm thời.
1. Sao chép slide đã chọn vào bản trình bày tạm thời.
1. Xóa các hình dạng khỏi slide đã sao chép.
1. Chuyển slide đã sao chép thành hình ảnh.

Ví dụ mã sau trích xuất toàn bộ nền slide của bản trình bày dưới dạng hình ảnh.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```

## **Câu hỏi thường gặp**

**Liệu các gradient phức tạp, kết cấu hoặc nền ảnh từ slide chủ có được giữ nguyên trong hình nền kết quả không?**

Có. Aspose.Slides sẽ hiển thị các gradient, hình ảnh và kết cấu được định nghĩa trên slide, bố cục hoặc slide chủ. Nếu bạn cần tách biệt giao diện khỏi các slide chủ kế thừa, hãy [đặt nền riêng](/slides/vi/python-net/presentation-background/) cho slide hiện tại trước khi xuất.

**Tôi có thể thêm watermark vào hình nền kết quả trước khi lưu không?**

Có. Bạn có thể [thêm watermark](/slides/vi/python-net/watermark/) dưới dạng hình dạng hoặc hình ảnh vào một [bản sao của slide](/slides/vi/python-net/clone-slides/) đang làm việc (đặt phía sau nội dung khác) và sau đó xuất. Điều này cho phép bạn tạo một hình nền có watermark được tích hợp sẵn.

**Tôi có thể lấy nền cho một bố cục hoặc slide chủ cụ thể mà không cần gắn với một slide hiện có không?**

Có. Truy cập vào slide chủ hoặc bố cục mong muốn, áp dụng nó cho một [slide tạm thời](/slides/vi/python-net/clone-slides/) với kích thước cần thiết, và xuất slide đó để nhận nền được suy ra từ bố cục hoặc slide chủ ấy.

**Có những hạn chế về giấy phép nào ảnh hưởng tới việc xuất hình ảnh không?**

Các tính năng render hoàn toàn khả dụng với một [giấy phép hợp lệ](/slides/vi/python-net/licensing/). Trong chế độ đánh giá, đầu ra có thể có các hạn chế như watermark. Kích hoạt giấy phép một lần cho mỗi tiến trình trước khi chạy xuất hàng loạt.