---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trên Android
linktitle: Thông tin Bản trình chiếu
type: docs
weight: 30
url: /vi/androidjava/examine-presentation/
keywords:
- định dạng bản trình chiếu
- thuộc tính bản trình chiếu
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
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng Java để có cái nhìn nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này hướng dẫn cách kiểm tra thông tin bản trình chiếu trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của bản trình chiếu mà không tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó, và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/documentproperties/) và trình bày các thao tác điển hình khi làm việc với siêu dữ liệu bản trình chiếu.

## **Kiểm tra định dạng bản trình chiếu**

Trước khi làm việc với một bản trình chiếu, bạn có thể muốn biết định dạng (PPT, PPTX, ODP và các định dạng khác) hiện tại của bản trình chiếu là gì.

Bạn có thể kiểm tra định dạng của bản trình chiếu mà không tải nó. Xem đoạn mã Java sau:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Lấy thuộc tính bản trình chiếu**

Đoạn mã Java này cho bạn cách lấy các thuộc tính bản trình chiếu (thông tin về bản trình chiếu):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Bạn có thể muốn xem [các thuộc tính dưới lớp DocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Cập nhật thuộc tính bản trình chiếu**

Aspose.Slides cung cấp phương thức [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) cho phép bạn thực hiện các thay đổi đối với các thuộc tính của bản trình chiếu.

Giả sử chúng ta có một bản trình chiếu PowerPoint với các thuộc tính tài liệu như bên dưới.

![Thuộc tính tài liệu gốc của bản trình chiếu PowerPoint](input_properties.png)

Ví dụ mã này cho bạn cách chỉnh sửa một số thuộc tính bản trình chiếu:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị bên dưới.

![Thuộc tính tài liệu đã thay đổi của bản trình chiếu PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Để có thêm thông tin về một bản trình chiếu và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Bảo vệ bản trình chiếu bằng mật khẩu](/slides/vi/androidjava/password-protected-presentation/)
- [Bảo vệ bản trình chiếu bằng ghi](/slides/vi/androidjava/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào để kiểm tra xem phông chữ có được nhúng không và là những phông chữ nào?**

Tìm thông tin [thông tin phông chữ nhúng](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ở cấp độ bản trình chiếu, sau đó so sánh các mục này với tập hợp [phông chữ thực tế được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#getFonts--) để xác định phông chữ nào là quan trọng cho việc hiển thị.

**Làm sao nhanh chóng biết tệp có slide ẩn không và có bao nhiêu?**

Duyệt qua [bộ sưu tập slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidecollection/) và kiểm tra [cờ hiển thị](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#getHidden--) của mỗi slide.

**Tôi có thể phát hiện liệu kích thước và hướng slide tùy chỉnh có được sử dụng hay không, và chúng có khác so với mặc định không?**

Có. So sánh [kích thước slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlideSize--) và hướng hiện tại với các thiết lập chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để xem biểu đồ có tham chiếu tới nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả [biểu đồ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/), kiểm tra [nguồn dữ liệu](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--), và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng, hoạt ảnh và đa phương tiện; gán một điểm phức tạp sơ bộ để đánh dấu những điểm nóng tiềm năng về hiệu năng.