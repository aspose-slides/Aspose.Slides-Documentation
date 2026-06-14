---
title: Truy xuất và Cập nhật Thông tin Bản trình bày trong Java
linktitle: Thông tin Bản trình bày
type: docs
weight: 30
url: /vi/java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình bày PowerPoint và OpenDocument bằng Java để có những hiểu biết nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này hướng dẫn cách kiểm tra thông tin bản trình bày trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của bản trình bày mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó và cập nhật các thuộc tính đó khi cần.  

Các ví dụ dựa trên API [PresentationInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/documentproperties/) và minh họa các thao tác điển hình khi làm việc với siêu dữ liệu bản trình bày.

## **Kiểm tra định dạng bản trình bày**

Trước khi làm việc với một bản trình bày, bạn có thể muốn biết định dạng (PPT, PPTX, ODP và các định dạng khác) hiện tại của bản trình bày.  

Bạn có thể kiểm tra định dạng của bản trình bày mà không tải bản trình bày. Xem đoạn mã Java sau:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Lấy thuộc tính bản trình bày**

Đoạn mã Java này cho bạn cách lấy các thuộc tính của bản trình bày (thông tin về bản trình bày):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Bạn có thể muốn xem [các thuộc tính trong lớp DocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Cập nhật thuộc tính bản trình bày**

Aspose.Slides cung cấp phương thức [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) cho phép bạn thực hiện các thay đổi đối với thuộc tính của bản trình bày.  

Giả sử chúng ta có một bản trình bày PowerPoint với các thuộc tính tài liệu như dưới đây.

![Thuộc tính tài liệu gốc của bản trình bày PowerPoint](input_properties.png)

Ví dụ mã này cho bạn cách chỉnh sửa một số thuộc tính của bản trình bày:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu đã thay đổi của bản trình bày PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Để lấy thêm thông tin về bản trình bày và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Kiểm tra xem một bản trình bày có được mã hoá hay không](https://docs.aspose.com/slides/vi/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kiểm tra xem một bản trình bày có được bảo vệ ghi (chỉ đọc) hay không](https://docs.aspose.com/slides/vi/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kiểm tra xem một bản trình bày có được bảo vệ bằng mật khẩu trước khi tải hay không](https://docs.aspose.com/slides/vi/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Xác nhận mật khẩu đã dùng để bảo vệ một bản trình bày](https://docs.aspose.com/slides/vi/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Câu hỏi thường gặp**

**Làm thế nào để tôi kiểm tra xem các phông chữ có được nhúng không và chúng là những phông chữ nào?**

Tìm [thông tin phông chữ nhúng](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) ở mức độ bản trình bày, sau đó so sánh các mục này với tập hợp [phông chữ thực tế được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#getFonts--) để xác định những phông chữ nào là quan trọng cho việc hiển thị.

**Làm sao tôi có thể nhanh chóng xác định xem tệp có các slide ẩn và có bao nhiêu không?**

Duyệt qua [bộ sưu tập slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/) và kiểm tra [cờ hiển thị](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getHidden--) của mỗi slide.

**Tôi có thể phát hiện xem kích thước và độ hướng slide tùy chỉnh có được sử dụng không, và chúng có khác so với mặc định không?**

Có. So sánh [kích thước slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlideSize--) hiện tại và độ hướng với các cài đặt chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để kiểm tra xem biểu đồ có tham chiếu tới nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả [biểu đồ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/), kiểm tra [nguồn dữ liệu](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#getDataSourceType--) của chúng và ghi chú xem dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị phá vỡ.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm độ phức tạp sơ bộ để đánh dấu các điểm nóng tiềm năng về hiệu năng.