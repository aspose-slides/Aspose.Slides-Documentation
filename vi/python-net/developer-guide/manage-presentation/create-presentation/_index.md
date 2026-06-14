---
title: Tạo bản trình bày bằng Python
linktitle: Tạo bản trình bày
type: docs
weight: 10
url: /vi/python-net/create-presentation/
keywords:
- tạo bản trình bày
- bản trình bày mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Tạo bản trình bày PowerPoint bằng Python với Aspose.Slides—tạo các tệp PPT, PPTX và ODP, tận hưởng hỗ trợ OpenDocument, và lưu chúng một cách lập trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Aspose.Slides for Python cho phép bạn tạo một tệp bản trình bày mới hoàn toàn bằng mã. Bài viết này trình bày quy trình chính — tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), lấy slide đầu tiên, chèn một hình dạng đơn giản và lưu kết quả — để bạn thấy chỉ cần ít cài đặt để tạo bản trình bày mà không cần Microsoft Office. Vì cùng một API có thể ghi file PPT, PPTX và ODP, bạn có thể hướng tới cả định dạng PowerPoint truyền thống và OpenDocument từ một cơ sở mã duy nhất. Aspose.Slides phù hợp cho môi trường desktop, web hoặc server, cung cấp cho ứng dụng Python của bạn một điểm khởi đầu hiệu quả để thêm nội dung phong phú như văn bản, hình ảnh hoặc biểu đồ sau khi bộ slide ban đầu đã có.

## **Tạo một bản trình bày**

Tạo một tệp PowerPoint từ đầu trong Aspose.Slides for Python đơn giản như việc khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Hàm khởi tạo tự động cung cấp một bộ slide trống với một slide duy nhất, cho bạn ngay một canvas để vẽ hình, văn bản, biểu đồ hoặc bất kỳ nội dung nào mà ứng dụng của bạn cần. Khi bạn chỉnh sửa slide đó — hoặc thêm slide mới — bạn có thể lưu kết quả dưới dạng PPTX, PPT truyền thống hoặc thậm chí các định dạng OpenDocument. Đoạn mã ngắn dưới đây minh họa quy trình này bằng cách thêm một hình dạng đơn giản vào slide đầu tiên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Thêm một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) loại `CLOUD` bằng phương thức `add_auto_shape` được cung cấp bởi bộ sưu tập `shapes`.
1. Thêm văn bản vào auto‑shape.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, một hình dạng đám mây được thêm vào slide đầu tiên của bản trình bày.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto-shape loại CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![The new presentation](new_presentation.png)

## **Câu hỏi thường gặp**

**Tôi có thể lưu bản trình bày mới sang những định dạng nào?**

Bạn có thể lưu dưới dạng [PPTX, PPT và ODP](/slides/vi/python-net/save-presentation/), và xuất sang [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/vi/python-net/convert-powerpoint-to-xps/), [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), [SVG](/slides/vi/python-net/convert-powerpoint-to-png/), và [images](/slides/vi/python-net/convert-powerpoint-to-png/), cùng các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/python-net/supported-file-formats/).

**Làm sao tôi kiểm soát kích thước/tỷ lệ khung hình khi tạo bản trình bày?**

Đặt [slide size](/slides/vi/python-net/slide-size/) (bao gồm các cài đặt sẵn như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được thu phóng.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Bằng điểm: 1 inch bằng 72 đơn vị.

**Làm sao tôi xử lý các bản trình bày rất lớn (có nhiều file media) để giảm tiêu thụ bộ nhớ?**

Sử dụng [BLOB management strategies](/slides/vi/python-net/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng các file tạm, và ưu tiên quy trình làm việc dựa trên file thay vì luồng dữ liệu chỉ trong bộ nhớ.

**Tôi có thể tạo/lưu bản trình bày song song không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) từ [multiple threads](/slides/vi/python-net/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

**Làm sao tôi gỡ bỏ watermark và các hạn chế của phiên bản dùng thử?**

[Apply a license](/slides/vi/python-net/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải được để nguyên, và việc thiết lập giấy phép nên được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX mà tôi tạo không?**

Có. [Digital signatures](/slides/vi/python-net/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bản trình bày.

**Macro (VBA) có được hỗ trợ trong các bản trình bày được tạo không?**

Có. Bạn có thể [create/edit VBA projects](/slides/vi/python-net/presentation-via-vba/) và lưu các tệp có macro như PPTM/PPSM.