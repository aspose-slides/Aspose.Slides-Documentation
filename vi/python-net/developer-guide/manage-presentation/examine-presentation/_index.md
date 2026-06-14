---
title: Truy xuất và Cập nhật Thông tin Bài trình chiếu trong Python
linktitle: Thông tin Bài trình chiếu
type: docs
weight: 30
url: /vi/python-net/examine-presentation/
keywords:
- định dạng bài trình chiếu
- thuộc tính bài trình chiếu
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
- bài trình chiếu
- Python
- Aspose.Slides
description: Khám phá các slide, cấu trúc và siêu dữ liệu trong các bài trình chiếu PowerPoint và OpenDocument bằng Python để thu được cái nhìn nhanh hơn và kiểm toán nội dung thông minh hơn.
---
## **Tổng quan**

Bài viết này hướng dẫn cách kiểm tra thông tin bài trình chiếu trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của một bài trình chiếu mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/) và minh họa các thao tác điển hình để làm việc với siêu dữ liệu của bài trình chiếu.

## **Kiểm tra định dạng bài trình chiếu**

Trước khi làm việc với một bài trình chiếu, bạn có thể muốn biết định dạng (PPT, PPTX, ODP và các định dạng khác) hiện tại của bài trình chiếu là gì.

Bạn có thể kiểm tra định dạng của một bài trình chiếu mà không cần tải bài trình chiếu. Xem đoạn mã Python này:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Lấy thuộc tính bài trình chiếu**

Đoạn mã Python này cho bạn biết cách lấy các thuộc tính của bài trình chiếu (thông tin về bài trình chiếu):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Bạn có thể muốn xem [các thuộc tính dưới lớp DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/#properties).

## **Cập nhật thuộc tính bài trình chiếu**

Aspose.Slides cung cấp phương thức [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) cho phép bạn thực hiện các thay đổi đối với các thuộc tính của bài trình chiếu.

Giả sử chúng ta có một bài trình chiếu PowerPoint với các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu gốc của bài trình chiếu PowerPoint](input_properties.png)

Ví dụ mã này cho bạn thấy cách chỉnh sửa một số thuộc tính của bài trình chiếu:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu đã thay đổi của bài trình chiếu PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Để nhận thêm thông tin về một bài trình chiếu và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Kiểm tra xem một bài trình chiếu có được mã hoá hay không](https://docs.aspose.com/slides/vi/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kiểm tra xem một bài trình chiếu có được bảo vệ ghi (chỉ đọc) hay không](https://docs.aspose.com/slides/vi/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kiểm tra xem một bài trình chiếu có được bảo mật bằng mật khẩu trước khi tải hay không](https://docs.aspose.com/slides/vi/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Xác nhận mật khẩu đã sử dụng để bảo vệ một bài trình chiếu](https://docs.aspose.com/slides/vi/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông nào?**

Tìm thông tin [embedded-font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ở cấp độ bài trình chiếu, sau đó so sánh các mục đó với tập hợp các [phông chữ thực sự được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_fonts/) để xác định phông chữ nào là quan trọng cho việc hiển thị.

**Làm sao tôi có thể nhanh chóng biết tệp có các slide ẩn và có bao nhiêu?**

Duyệt qua [slide collection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/) và kiểm tra [visibility flag](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/hidden/) của từng slide.

**Tôi có thể phát hiện liệu kích thước và hướng slide tùy chỉnh có được sử dụng hay không, và chúng có khác so với mặc định không?**

Có. So sánh [slide size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slide_size/) và hướng hiện tại với các cài đặt chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để xem biểu đồ có tham chiếu tới nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả các [charts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/), kiểm tra [data source](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/) của chúng và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm độ phức tạp sơ bộ để đánh dấu các điểm nóng tiềm năng về hiệu năng.