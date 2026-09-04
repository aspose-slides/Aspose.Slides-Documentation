---
title: "Trích xuất Văn bản Slide: PPT, PPTX, ODP Cơ bản"
type: docs
weight: 10
url: /vi/python-java/slide-text-extraction-ppt-pptx-odp-essentials/
keywords:
- nền tảng đám mây
- trích xuất văn bản bản trình chiếu
- trích xuất văn bản slide
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- Microsoft PowerPoint
- OpenDocument
- LibreOffice Impress
- Office Open XML
- lập chỉ mục tìm kiếm
- tự động hoá tài liệu
- phân tích dữ liệu
- khả năng truy cập
- Python
- Aspose.Slides
description: "Hiểu cách PPT, PPTX và ODP lưu trữ văn bản slide và lên kế hoạch trích xuất cho tìm kiếm, tự động hoá và bản địa hoá với Aspose.Slides for Python via Java."
---
## **Giới thiệu**

Việc trích xuất văn bản bản trình chiếu giúp nội dung slide có thể tìm kiếm, phân tích, hỗ trợ khả năng truy cập và bản địa hoá. Trong một ứng dụng Python, văn bản đã trích xuất có thể được đưa vào chỉ mục, hệ thống quản lý tài liệu, hoặc quy trình xử lý ngôn ngữ. Các worker trên đám mây có thể áp dụng cùng một quy trình làm việc cho các tệp nhận được từ tải lên hoặc lưu trữ đối tượng.

Bài viết này giải thích cách PPT, PPTX và ODP lưu trữ văn bản và những khác biệt này ảnh hưởng như thế nào tới việc trích xuất. Aspose.Slides for Python via Java hỗ trợ tải cả ba định dạng; xem [Định dạng tệp được hỗ trợ](/slides/vi/python-java/supported-file-formats/).

## **Các ứng dụng thực tiễn của việc trích xuất văn bản**

- **Quy trình tài liệu:** nhập nội dung bản trình chiếu vào hệ thống quản lý tài liệu và liên kết nó với siêu dữ liệu của tệp nguồn.
- **Lập chỉ mục tìm kiếm:** lập chỉ mục văn bản slide đồng thời giữ lại tên bản trình chiếu và số slide cho mỗi kết quả.
- **Phân tích nội dung:** xác định các chủ đề, thuật ngữ và các mẫu lặp lại trong kho lưu trữ bản trình chiếu.
- **Khả năng truy cập và bản địa hoá:** cung cấp văn bản cho các công cụ hỗ trợ hoặc quy trình dịch, kèm theo việc xem xét lại thứ tự đọc và ngữ cảnh.
- **Phân tích bố cục:** kết hợp văn bản với vị trí các đối tượng khi kiểm tra cấu trúc slide hoặc chuẩn bị xuất dữ liệu có cấu trúc.

## **Tổng quan về các định dạng bản trình chiếu**

### **PPT: Định dạng PowerPoint kế thừa**

PPT là định dạng nhị phân liên quan đến PowerPoint 97–2003. Các record của nó không thể xử lý dưới dạng tài liệu XML. Bộ phân tích cần hiểu cấu trúc nhị phân và mối quan hệ của chúng để tái tạo nội dung slide.

Văn bản có thể xuất hiện trong các đối tượng slide, ghi chú và bình luận. Quy trình trích xuất nên xác định nguồn nào sẽ được bao gồm, thay vì xem bản trình chiếu như một luồng văn bản liên tục.

### **PPTX: Office Open XML**

PPTX là một gói ZIP chứa các phần XML và các tài nguyên khác. Văn bản slide thường xuất hiện trong `ppt/slides/vi/slideX.xml` trong các phần tử `a:t`. Ghi chú được lưu trong các phần notes-slide riêng biệt, và bình luận có phần riêng kết nối qua các quan hệ gói.

Chỉ đọc các phần tử văn bản từ XML slide có thể bỏ lỡ nội dung được lưu ở các vị trí khác trong gói. Nó cũng không tái tạo định dạng hay thứ tự đọc. Một quy trình hoàn chỉnh có thể cần tính đến bố cục, nhóm hình dạng, bảng, biểu đồ và các phần liên quan.

### **ODP: OpenDocument Presentation**

ODP là định dạng bản trình chiếu OpenDocument được đóng gói, được sử dụng bởi các ứng dụng như LibreOffice Impress. Giống PPTX, nó chứa XML trong một gói ZIP, nhưng sử dụng từ vựng và cấu trúc OpenDocument.

Nội dung bản trình chiếu chủ yếu được lưu trong `content.xml`. Văn bản đoạn văn sử dụng các phần tử như `text:p`, với các phần tử lồng nhau cho các span và các tính năng văn bản khác. Do đó các truy vấn XML đặc thù cho PPTX không thể tái sử dụng trực tiếp cho ODP.

## **Sử dụng mô hình bản trình chiếu chung trong Python**

Lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) tải các tệp bản trình chiếu được hỗ trợ để mã ứng dụng có thể làm việc với slide và các đối tượng của chúng mà không cần triển khai bộ phân tích gói hoặc bộ phân tích nhị phân riêng cho mỗi định dạng.

Trước khi tích hợp việc trích xuất vào một worker trên đám mây, hãy thực hiện [Cài đặt](/slides/vi/python-java/installation/). Đối với việc triển khai và các cân nhắc vòng đời JVM, xem [Slides trên các nền tảng đám mây](/slides/vi/python-java/slides-on-cloud-platforms/).

Giữ những quyết định này rõ ràng trong thiết kế trích xuất:

- **Phạm vi nội dung:** quyết định cách xử lý văn bản slide, ghi chú, bình luận, bảng và nhãn biểu đồ.
- **Thứ tự đọc:** giữ lại ranh giới slide và sử dụng thông tin bố cục khi thứ tự đối tượng không đủ.
- **Văn bản trong hình ảnh:** sử dụng quy trình OCR riêng khi văn bản được nhúng trong ảnh chụp màn hình hoặc slide đã quét.
- **Cấu trúc đầu ra:** giữ lại định danh nguồn và ghi văn bản bằng mã hóa hỗ trợ các ngôn ngữ yêu cầu, chẳng hạn UTF-8.

## **Kết luận**

PPT yêu cầu xử lý định dạng nhị phân, trong khi PPTX và ODP sử dụng các cấu trúc gói XML khác nhau. Thư viện bản trình chiếu cung cấp điểm khởi đầu chung để làm việc với các định dạng này trong Python. Xác định phạm vi nội dung và thứ tự đọc giúp làm cho văn bản kết quả hữu ích cho việc lập chỉ mục, phân tích và bản địa hoá.

## **Câu hỏi thường gặp**

**Tôi có thể trích xuất văn bản PPT bằng cách giải nén tệp không?**

Không. PPT sử dụng cấu trúc nhị phân. Cách tiếp cận ZIP‑và‑XML áp dụng cho các định dạng đóng gói như PPTX và ODP.

**Ghi chú và bình luận có được lưu cùng với văn bản slide chính trong PPTX không?**

Chúng được lưu trong các phần gói riêng biệt. Chỉ đọc XML slide sẽ không tự động bao gồm chúng.

**Việc trích xuất văn bản thuần sẽ bắt được văn bản trong ảnh chụp màn hình không?**

Không. Văn bản trong ảnh chụp màn hình là một phần của hình ảnh chứ không phải văn bản slide có thể chỉnh sửa. Nó cần OCR.