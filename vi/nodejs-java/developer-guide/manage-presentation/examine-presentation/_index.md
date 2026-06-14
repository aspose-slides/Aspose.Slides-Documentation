---
title: Truy xuất và Cập nhật Thông tin Bài thuyết trình trong JavaScript
linktitle: Thông tin Bài thuyết trình
type: docs
weight: 30
url: /vi/nodejs-java/examine-presentation/
keywords:
- định dạng bài thuyết trình
- thuộc tính bài thuyết trình
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
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bài thuyết trình PowerPoint và OpenDocument bằng JavaScript để có những hiểu biết nhanh hơn và kiểm toán nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này hướng dẫn cách kiểm tra thông tin bài thuyết trình trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của một bài thuyết trình mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó, và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/) và minh họa các thao tác điển hình để làm việc với siêu dữ liệu của bài thuyết trình.

## **Kiểm tra Định dạng Bài thuyết trình**

Trước khi làm việc với một bài thuyết trình, bạn có thể muốn biết định dạng (PPT, PPTX, ODP và các định dạng khác) hiện tại của bài thuyết trình là gì.

Bạn có thể kiểm tra định dạng của bài thuyết trình mà không tải nó. Xem mã JavaScript sau:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Lấy Thuộc tính Bài thuyết trình**

Mã JavaScript này cho bạn thấy cách lấy các thuộc tính của bài thuyết trình (thông tin về bài thuyết trình):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

Bạn có thể muốn xem [các thuộc tính dưới lớp DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Cập nhật Thuộc tính Bài thuyết trình**

Aspose.Slides cung cấp phương thức [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) cho phép bạn thực hiện các thay đổi đối với các thuộc tính của bài thuyết trình.

Giả sử chúng ta có một bài thuyết trình PowerPoint với các thuộc tính tài liệu như dưới đây.

![Các thuộc tính tài liệu gốc của bài thuyết trình PowerPoint](input_properties.png)

Ví dụ mã này cho bạn biết cách chỉnh sửa một số thuộc tính của bài thuyết trình:

```javascript
let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Các thuộc tính tài liệu đã thay đổi của bài thuyết trình PowerPoint](output_properties.png)

## **Liên kết Hữu ích**

Để có thêm thông tin về một bài thuyết trình và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Kiểm tra liệu một Bài thuyết trình có được Mã hoá hay không](https://docs.aspose.com/slides/vi/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kiểm tra liệu một Bài thuyết trình có được Bảo vệ Ghi (chỉ đọc) hay không](https://docs.aspose.com/slides/vi/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kiểm tra liệu một Bài thuyết trình có được Bảo vệ bằng Mật khẩu trước khi tải hay không](https://docs.aspose.com/slides/vi/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Xác nhận Mật khẩu được sử dụng để Bảo vệ một Bài thuyết trình](https://docs.aspose.com/slides/vi/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Câu hỏi Thường gặp**

**Làm thế nào tôi có thể kiểm tra liệu các phông chữ có được nhúng hay không và chúng là phông chữ nào?**

Tìm thông tin [embedded-font information](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) ở mức độ bài thuyết trình, sau đó so sánh các mục đó với tập hợp [fonts actually used across content](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getfonts/) để xác định các phông chữ nào là quan trọng cho việc hiển thị.

**Làm thế nào tôi có thể nhanh chóng biết liệu tệp có các slide ẩn và có bao nhiêu?**

Duyệt qua [slide collection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) và kiểm tra [visibility flag](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/gethidden/) của mỗi slide.

**Tôi có thể phát hiện liệu kích thước và hướng slide tùy chỉnh có được sử dụng không, và chúng có khác so với mặc định không?**

Có. So sánh [slide size](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslidesize/) và hướng hiện tại với các preset tiêu chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để xem liệu các biểu đồ có tham chiếu tới nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả các [charts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/), kiểm tra [data source](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) của chúng, và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm thế nào tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm phức tạp ước tính để đánh dấu các điểm nóng tiềm năng về hiệu năng.