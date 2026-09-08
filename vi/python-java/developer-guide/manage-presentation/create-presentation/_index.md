---
title: Tạo Bài thuyết trình bằng Python qua Java
linktitle: Tạo Bài thuyết trình
type: docs
weight: 10
url: /vi/python-java/create-presentation/
keywords:
- tạo bài thuyết trình
- bài thuyết trình mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tạo các bài thuyết trình bằng Python qua Java với Aspose.Slides—sinh ra các tệp PPT, PPTX và ODP, tận dụng hỗ trợ OpenDocument, và lưu chúng một cách lập trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bài thuyết trình bằng Aspose.Slides for Python via Java, thêm một hình dạng có văn bản vào slide đầu tiên, và lưu kết quả dưới dạng tệp PPTX. Phần Hỏi đáp bao gồm các định dạng xuất, mẫu, kích thước slide, sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

## **Tạo một Bài thuyết trình**

Việc tạo tệp PowerPoint từ đầu trong Aspose.Slides for Python via Java đơn giản như việc khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Hàm khởi tạo tự động cung cấp một bộ trống có một slide duy nhất, cho bạn ngay một canvas để thêm hình dạng, văn bản, biểu đồ hoặc bất kỳ nội dung nào mà ứng dụng của bạn cần. Khi bạn chỉnh sửa slide đó—hoặc thêm slide mới—bạn có thể lưu kết quả dưới dạng PPTX, PPT cũ, hoặc thậm chí các định dạng OpenDocument. Đoạn mã ngắn dưới đây minh họa quy trình này bằng cách thêm một hình dạng đơn giản vào slide đầu tiên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Lấy slide đầu tiên theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) loại [ShapeType.Cloud](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapetype/#Cloud) bằng cách sử dụng [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Đặt văn bản cho hình dạng bằng [TextFrame.setText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#setText).
1. Lưu bài thuyết trình bằng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Pptx).

Ví dụ sau yêu cầu Aspose.Slides for Python via Java và một môi trường Java tương thích. Nó khởi động JVM nếu chưa chạy, thêm một hình dạng đám mây vào slide đầu tiên, và lưu bài thuyết trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Tạo một bài thuyết trình với một slide trống.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình dạng đám mây và đặt văn bản cho nó.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Lưu bài thuyết trình dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Bài thuyết trình mới](new_presentation.png)

## **Câu hỏi thường gặp**

**Tôi có thể lưu bài thuyết trình mới thành những định dạng nào?**

Bạn có thể lưu dưới dạng [PPTX, PPT và ODP](/slides/vi/python-java/save-presentation/), và xuất ra [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/python-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/python-java/convert-powerpoint-to-html/), [SVG](/slides/vi/python-java/render-slide-as-svg/), và [hình ảnh](/slides/vi/python-java/convert-powerpoint-to-png/), cùng các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/python-java/supported-file-formats/).

**Làm sao tôi kiểm soát kích thước/tỉ lệ của slide khi tạo bài thuyết trình?**

Đặt [kích thước slide](/slides/vi/python-java/slide-size/) (bao gồm các preset như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được thu phóng.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Bằng điểm: 1 inch tương đương 72 đơn vị.

**Làm sao tôi xử lý các bài thuyết trình rất lớn (có nhiều tệp phương tiện) để giảm sử dụng bộ nhớ?**

Sử dụng [các chiến lược quản lý BLOB](/slides/vi/python-java/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng tệp tạm, và ưu tiên quy trình làm việc dựa trên tệp thay vì chỉ sử dụng luồng bộ nhớ.

**Tôi có thể tạo/lưu bài thuyết trình một cách song song không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/python-java/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

**Làm sao tôi loại bỏ dấu nước bản dùng thử và các hạn chế?**

[Áp dụng giấy phép](/slides/vi/python-java/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị sửa đổi, và việc thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX mà mình tạo không?**

Có. [Chữ ký số](/slides/vi/python-java/digital-signature-in-powerpoint/) (thêm và xác thực) được hỗ trợ cho các bài thuyết trình.

**Macro (VBA) có được hỗ trợ trong các bài thuyết trình được tạo không?**

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/python-java/presentation-via-vba/) và lưu các tệp có macro như PPTM/PPSM.