---
title: Tạo bản thuyết trình trong Python
linktitle: Tạo bản thuyết trình
type: docs
weight: 10
url: /vi/python-net/create-presentation/
keywords:
- tạo bản thuyết trình
- bản thuyết trình mới
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
description: "Tạo bản thuyết trình PowerPoint trong Python bằng Aspose.Slides—tạo các tệp PPT, PPTX và ODP, hưởng lợi từ hỗ trợ OpenDocument, và lưu chúng một cách lập trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này cho thấy cách tạo một bản thuyết trình bằng Aspose.Slides cho Python thông qua .NET, thêm một hình dạng có văn bản vào slide đầu tiên và lưu kết quả dưới dạng tệp PPTX. Cùng API này cũng cho phép lưu bản thuyết trình dưới dạng PPT và ODP, vì vậy bạn có thể nhắm tới cả định dạng PowerPoint và OpenDocument từ một cơ sở mã duy nhất, mà không cần Microsoft Office. Phần FAQ ngắn ở cuối đề cập đến các câu hỏi thường gặp về định dạng, mẫu, kích thước slide, đơn vị, sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

## **Tạo bản thuyết trình**

Để tạo một bản thuyết trình và đặt một hình dạng có văn bản trên slide đầu tiên, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Một bản thuyết trình mới đã chứa sẵn một slide trống.
2. Lấy slide đó từ bộ sưu tập [slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) bằng chỉ số 0.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) dạng đám mây bằng phương thức [add_auto_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_auto_shape/) của bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/shapes/) của slide, và đặt [text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/text/) của nó.
4. Lưu bản thuyết trình dưới dạng tệp PPTX bằng phương thức [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản thuyết trình.
with slides.Presentation() as presentation:
    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto-shape kiểu CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Lưu bản thuyết trình dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Góc trên-trái của đám mây cách cạnh trái 20 điểm và cách cạnh trên 20 điểm của slide, và đám mây rộng 200 điểm, cao 80 điểm. Câu lệnh `with` giải phóng các tài nguyên của bản thuyết trình khi khối kết thúc. Script lưu *new_presentation.pptx* trong thư mục hiện tại, với một slide chứa đám mây và văn bản của nó. Khi không có giấy phép, Aspose.Slides cũng sẽ thêm watermark đánh giá vào mỗi slide được lưu; xem [Cấp phép](/slides/vi/python-net/licensing/).

Kết quả:

![Bản thuyết trình mới](new_presentation.png)

## **Câu hỏi thường gặp**

### Tôi có thể lưu một bản thuyết trình mới thành những định dạng nào?

Bạn có thể lưu dưới dạng [PPTX, PPT, và ODP](/slides/vi/python-net/save-presentation/), và xuất ra [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/vi/python-net/convert-powerpoint-to-xps/), [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), [SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/), và [hình ảnh](/slides/vi/python-net/convert-powerpoint-to-png/), trong số các định dạng khác.

### Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/python-net/supported-file-formats/).

### Làm thế nào tôi kiểm soát kích thước/tỷ lệ khung hình của slide khi tạo bản thuyết trình?

Đặt [slide size](/slides/vi/python-net/slide-size/) (bao gồm các preset như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung được thu phóng.

### Kích thước và tọa độ được đo bằng đơn vị nào?

Bằng điểm: 1 inch bằng 72 đơn vị.

### Làm sao tôi xử lý các bản thuyết trình rất lớn (có nhiều tệp phương tiện) để giảm việc sử dụng bộ nhớ?

Sử dụng [BLOB management strategies](/slides/vi/python-net/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm, và ưu tiên quy trình làm việc dựa trên tệp hơn các luồng chỉ trong bộ nhớ.

### Tôi có thể tạo/lưu bản thuyết trình song song không?

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) từ [multiple threads](/slides/vi/python-net/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

### Làm sao tôi loại bỏ watermark dùng thử và các hạn chế?

[Áp dụng giấy phép](/slides/vi/python-net/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị thay đổi, và việc thiết lập giấy phép nên được đồng bộ nếu có nhiều luồng tham gia.

### Tôi có thể ký số PPTX tôi tạo không?

Có. [Digital signatures](/slides/vi/python-net/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho bản thuyết trình.

### Macro (VBA) có được hỗ trợ trong các bản thuyết trình được tạo không?

Có. Bạn có thể [create/edit VBA projects](/slides/vi/python-net/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.