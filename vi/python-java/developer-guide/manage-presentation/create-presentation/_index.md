---
title: "Tạo bản trình chiếu bằng Python qua Java"
linktitle: "Tạo bản trình chiếu"
type: docs
weight: 10
url: /vi/python-java/create-presentation/
keywords:
- tạo bản trình chiếu
- bản trình chiếu mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo bản trình chiếu bằng Python qua Java với Aspose.Slides—sản xuất các tệp PPT, PPTX và ODP, hưởng lợi từ hỗ trợ OpenDocument, và lưu chúng một cách lập trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo bản trình chiếu với Aspose.Slides for Python via Java, thêm một hình dạng có văn bản vào slide đầu tiên và lưu kết quả dưới dạng tệp PPTX. phần FAQ bao gồm các định dạng xuất, mẫu, kích thước slide, sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

Trước khi bắt đầu, hãy cài đặt Python, JDK, JPype và Aspose.Slides for Python via Java. Xem [Cài đặt](/slides/vi/python-java/installation/) để biết các bước trên Windows, Linux và macOS.

## **Tạo bản trình chiếu**

Việc tạo tệp PowerPoint từ đầu trong Aspose.Slides for Python via Java đơn giản như việc khởi tạo lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Hàm khởi tạo tự động tạo một bản trình chiếu trống với một slide duy nhất, cung cấp ngay một canvas cho các hình dạng, văn bản, biểu đồ hoặc bất kỳ nội dung nào mà ứng dụng của bạn cần. Khi bạn chỉnh sửa slide đó—hoặc thêm slide mới—bạn có thể lưu kết quả dưới dạng PPTX, PPT cổ điển hoặc thậm chí các định dạng OpenDocument. Đoạn mã ngắn dưới đây minh họa quy trình này bằng cách thêm một hình dạng đơn giản vào slide đầu tiên.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Lấy slide đầu tiên bằng chỉ mục 0.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) loại [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) bằng cách sử dụng [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Đặt văn bản cho hình dạng bằng [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText).
1. Lưu bản trình chiếu bằng [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) với [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx).

Ví dụ sau khởi động Java Virtual Machine (JVM) nếu nó chưa chạy, thêm một hình đám mây có văn bản vào slide đầu tiên và lưu bản trình chiếu. Lưu lại dưới tên *create_presentation.py*:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Tạo một bản trình chiếu với một slide trống.
presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm hình dạng đám mây và đặt văn bản cho nó.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Chạy script trong môi trường đã cài đặt các gói:

```sh
python create_presentation.py
```

Góc trên‑trái của đám mây cách các cạnh trái và trên của slide 20 điểm, và đám mây rộng 200 điểm, cao 80 điểm. Script lưu *new_presentation.pptx* vào thư mục làm việc hiện tại, với một slide chứa đám mây và văn bản của nó. JVM sẽ tiếp tục chạy cho đến khi tiến trình Python kết thúc; xem [Các hạn chế và sự khác nhau của API](/slides/vi/python-java/limitations-and-api-differences/#import-the-library). Khi không có giấy phép, Aspose.Slides cũng sẽ thêm một hộp văn bản watermark đánh giá vào mọi slide được lưu; xem [Cấp phép](/slides/vi/python-java/licensing/).

Kết quả:

![Bản trình chiếu mới](new_presentation.png)

## **Câu hỏi thường gặp**

**Tôi có thể lưu bản trình chiếu mới sang những định dạng nào?**

Bạn có thể lưu dưới dạng [PPTX, PPT và ODP](/slides/vi/python-java/save-presentation/), và xuất sang [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/python-java/convert-powerpoint-to-xps/), [HTML](/slides/vi/python-java/convert-powerpoint-to-html/), [SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/) và [images](/slides/vi/python-java/convert-powerpoint-to-png/), trong số các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/python-java/supported-file-formats/).

**Làm sao tôi kiểm soát kích thước/ tỷ lệ khung hình khi tạo bản trình chiếu?**

Đặt [kích thước slide](/slides/vi/python-java/slide-size/) (bao gồm các mẫu như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được co giãn.

**Các kích thước và tọa độ được đo bằng đơn vị nào?**

Theo điểm: 1 inch bằng 72 đơn vị.

**Làm sao tôi xử lý các bản trình chiếu rất lớn (có nhiều tệp media) để giảm sử dụng bộ nhớ?**

Sử dụng [chiến lược quản lý BLOB](/slides/vi/python-java/manage-blob/), hạn chế lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp hơn là các luồng trong bộ nhớ thuần túy.

**Tôi có thể tạo/lưu bản trình chiếu song song không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/python-java/multithreading/). Hãy chạy các thể hiện riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

**Làm sao tôi loại bỏ watermark dùng thử và các hạn chế?**

[Áp dụng giấy phép](/slides/vi/python-java/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị thay đổi, và việc thiết lập giấy phép nên được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX mà tôi tạo không?**

Có. [Chữ ký số](/slides/vi/python-java/digital-signature-in-powerpoint/) (thêm và xác thực) được hỗ trợ cho các bản trình chiếu.

**Macro (VBA) có được hỗ trợ trong các bản trình chiếu được tạo không?**

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/python-java/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.