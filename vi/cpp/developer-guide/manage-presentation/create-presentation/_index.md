---
title: Tạo bản trình chiếu bằng C++
linktitle: Tạo bản trình chiếu
type: docs
weight: 10
url: /vi/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Tạo bản trình chiếu trong C++ với Aspose.Slides—tạo file PPT, PPTX và ODP, tận dụng hỗ trợ OpenDocument, và lưu chúng bằng chương trình để đạt kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bản trình chiếu trong Aspose.Slides, thêm nội dung đơn giản vào một slide, và lưu kết quả dưới dạng tệp.

## **Tạo bản trình chiếu PowerPoint**
Để thêm một đường thẳng đơn giản vào slide được chọn trong bản trình chiếu, vui lòng thực hiện các bước sau:

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu tới một slide bằng cách sử dụng chỉ số (Index) của nó.
3. Thêm một AutoShape loại Line bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes.
4. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường thẳng vào slide đầu tiên của bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **Câu hỏi thường gặp**

**Tôi có thể lưu bản trình chiếu mới sang những định dạng nào?**

Bạn có thể lưu dưới định dạng [PPTX, PPT, and ODP](/slides/vi/cpp/save-presentation/), và xuất ra [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/vi/cpp/convert-powerpoint-to-xps/), [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), [SVG](/slides/vi/cpp/convert-powerpoint-to-png/), và [images](/slides/vi/cpp/convert-powerpoint-to-png/), trong số những định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/cpp/supported-file-formats/).

**Làm sao tôi kiểm soát kích thước/tỷ lệ khung hình của slide khi tạo bản trình chiếu?**

Đặt [slide size](/slides/vi/cpp/slide-size/) (bao gồm các cài đặt trước như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung được phóng đại.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Bằng điểm: 1 inch bằng 72 đơn vị.

**Làm sao tôi xử lý các bản trình chiếu rất lớn (có nhiều tệp media) để giảm việc sử dụng bộ nhớ?**

Sử dụng [BLOB management strategies](/slides/vi/cpp/manage-blob/), giới hạn bộ nhớ trong khi lưu trữ bằng cách sử dụng các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp thay vì chỉ dùng các luồng trong bộ nhớ.

**Tôi có thể tạo/lưu bản trình chiếu song song không?**

Bạn không thể thao tác trên cùng một instance của [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) từ [multiple threads](/slides/vi/cpp/multithreading/). Hãy chạy các instance riêng biệt, cô lập cho mỗi luồng hoặc tiến trình.

**Làm sao tôi loại bỏ dấu nước thử nghiệm và các hạn chế?**

[Apply a license](/slides/vi/cpp/licensing/) một lần cho mỗi tiến trình. Tập tin XML giấy phép phải không bị chỉnh sửa, và việc thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký kỹ thuật số cho PPTX tôi tạo không?**

Có. [Digital signatures](/slides/vi/cpp/digital-signature-in-powerpoint/) (thêm và xác minh) được hỗ trợ cho các bản trình chiếu.

**Macro (VBA) có được hỗ trợ trong các bản trình chiếu được tạo không?**

Có. Bạn có thể [create/edit VBA projects](/slides/vi/cpp/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.