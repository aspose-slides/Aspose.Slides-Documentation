---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trong JavaScript
linktitle: Thông tin Bản trình chiếu
type: docs
weight: 30
url: /vi/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng JavaScript để có cái nhìn nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này chỉ ra cách kiểm tra thông tin bản trình chiếu trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của bản trình chiếu mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu, và cập nhật những thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/) và minh họa các thao tác điển hình khi làm việc với siêu dữ liệu của bản trình chiếu.

## **Kiểm tra Định dạng Bản trình chiếu**

Trước khi làm việc với một bản trình chiếu, bạn có thể muốn tìm hiểu nó đang ở định dạng nào (PPT, PPTX, ODP, và các định dạng khác) vào thời điểm hiện tại.

Bạn có thể kiểm tra định dạng của bản trình chiếu mà không cần tải nó. Xem đoạn JavaScript sau:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Lấy Thuộc tính Bản trình chiếu**

Mã JavaScript này cho bạn cách lấy các thuộc tính của bản trình chiếu (thông tin về bản trình chiếu):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Bạn có thể muốn xem [các thuộc tính dưới lớp DocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Cập nhật Thuộc tính Bản trình chiếu**

Aspose.Slides cung cấp phương thức [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) cho phép bạn thực hiện các thay đổi đối với thuộc tính của bản trình chiếu.

Giả sử chúng ta có một bản PowerPoint với các thuộc tính tài liệu như bên dưới.

![Thuộc tính tài liệu gốc của bản PowerPoint](input_properties.png)

Đoạn mã này cho bạn thấy cách chỉnh sửa một số thuộc tính của bản trình chiếu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu đã thay đổi của bản PowerPoint](output_properties.png)

## **Liên kết Hữu ích**

Để biết thêm thông tin về một bản trình chiếu và các thuộc tính bảo mật của nó, bạn có thể tham khảo các liên kết sau:

- [Bảo mật Bản trình chiếu bằng Mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/)
- [Bảo vệ Bản trình chiếu khỏi Việc Ghi](/slides/vi/nodejs-java/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm sao tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông nào?**

Tìm kiếm [thông tin phông chữ nhúng](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) ở cấp độ bản trình chiếu, sau đó so sánh các mục này với tập hợp [phông chữ thực sự được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getfonts/) để xác định phông chữ nào là quan trọng cho việc hiển thị.

**Làm sao tôi có thể nhanh chóng biết tệp có slide ẩn và có bao nhiêu slide ẩn?**

Duyệt qua [bộ sưu tập slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) và kiểm tra [cờ hiển thị](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/gethidden/) của từng slide.

**Tôi có thể phát hiện xem có sử dụng kích thước và định hướng slide tùy chỉnh không, và chúng có khác với mặc định không?**

Có. So sánh [kích thước slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslidesize/) và định hướng hiện tại với các thiết lập chuẩn; việc này giúp dự đoán hành vi khi in và xuất file.

**Có cách nhanh để xem các biểu đồ có tham chiếu đến nguồn dữ liệu bên ngoài không?**

Có. Duyệt tất cả các [biểu đồ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/), kiểm tra [nguồn dữ liệu](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) của chúng, và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm sao tôi đánh giá các slide “nặng” có thể làm chậm quá trình render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; đưa ra một điểm số phức tạp ước lượng để đánh dấu các điểm nóng hiệu năng tiềm năng.