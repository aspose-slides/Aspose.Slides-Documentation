---
title: Truy xuất và Cập nhật Thông tin Bản trình bày trong Python
linktitle: Thông tin Bản trình bày
type: docs
weight: 30
url: /vi/python-net/examine-presentation/
keywords:
- định dạng bản trình bày
- thuộc tính bản trình bày
- thuộc tính tài liệu
- lấy thuộc tính
- đọc thuộc tính
- thay đổi thuộc tính
- sửa đổi thuộc tính
- cập nhật thuộc tính
- kiểm tra PPTX
- kiểm tra PPT
- kiểm tra ODP
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình bày PowerPoint và OpenDocument bằng Python để có được những hiểu biết nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này trình bày cách kiểm tra thông tin bản trình bày trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của bản trình bày mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên API [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/) và minh họa các thao tác điển hình để làm việc với siêu dữ liệu bản trình bày.

## **Kiểm tra định dạng bản trình bày**

Trước khi làm việc với một bản trình bày, bạn có thể muốn biết nó hiện đang ở định dạng nào (PPT, PPTX, ODP, v.v.).

Bạn có thể kiểm tra định dạng của bản trình bày mà không cần tải bản trình bày. Xem đoạn mã Python này:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Lấy thuộc tính bản trình bày**

Đoạn mã Python này cho bạn cách lấy các thuộc tính của bản trình bày (thông tin về bản trình bày):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Bạn có thể muốn xem các **properties** trong lớp [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/#properties).

## **Cập nhật thuộc tính bản trình bày**

Aspose.Slides cung cấp phương thức [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) cho phép bạn thay đổi các thuộc tính của bản trình bày.

Giả sử chúng ta có một bản PowerPoint với các thuộc tính tài liệu như dưới đây.

![Thuộc tính tài liệu gốc của bản trình bày PowerPoint](input_properties.png)

Đoạn mã mẫu này cho bạn cách chỉnh sửa một số thuộc tính của bản trình bày:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu đã thay đổi của bản trình bày PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Để biết thêm thông tin về bản trình bày và các thuộc tính bảo mật của nó, bạn có thể tham khảo các liên kết sau:

- [Password-Protect Presentations](/slides/vi/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/vi/python-net/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào để kiểm tra xem phông chữ có được nhúng và là những phông nào?**

Tìm thông tin [embedded-font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ở mức bản trình bày, sau đó so sánh các mục này với tập hợp [fonts actually used across content](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_fonts/) để xác định phông chữ nào là quan trọng cho việc hiển thị.

**Làm sao nhanh chóng biết tệp có slide ẩn và có bao nhiêu?**

Duyệt qua [slide collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) và kiểm tra [visibility flag](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/hidden/) của mỗi slide.

**Tôi có thể phát hiện xem có sử dụng kích thước và hướng slide tùy chỉnh không, và chúng có khác so với mặc định không?**

Có. So sánh [slide size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slide_size/) và hướng hiện tại với các cài đặt tiêu chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để xem các biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Duyệt tất cả [charts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/), kiểm tra [data source](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/) của chúng và ghi nhận liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm thế nào đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm phức tạp sơ bộ để đánh dấu các điểm nóng về hiệu năng.