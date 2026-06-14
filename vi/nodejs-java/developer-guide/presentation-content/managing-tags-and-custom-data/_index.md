---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình bày bằng JavaScript
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/nodejs-java/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm, đọc, cập nhật và xóa thẻ & dữ liệu tùy chỉnh trong Aspose.Slides cho Node.js, với các ví dụ cho bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides hoạt động với thẻ và dữ liệu tùy chỉnh trong các bản trình bày PowerPoint. Nó tóm tắt ngắn gọn cách dữ liệu được lưu trữ trong tệp PPTX, lưu ý rằng dữ liệu đặc thù cho bản trình bày có thể tồn tại dưới dạng thẻ và các phần XML tùy chỉnh, và mô tả thẻ là các cặp chuỗi khóa‑giá trị.

Nó cũng chỉ ra cách đọc giá trị thẻ và cách thêm thẻ vào một bản trình bày, một slide riêng lẻ hoặc một hình dạng. Ngoài ra, bài viết đề cập đến các tác vụ quản lý thẻ phổ biến như xóa tất cả thẻ, xóa thẻ theo tên và lấy danh sách tên thẻ.

## **Lưu trữ dữ liệu trong tệp bản trình bày**

Các tệp PPTX — các mục có phần mở rộng .pptx — được lưu trữ ở định dạng PresentationML, là một phần của đặc tả Office Open XML. Định dạng Office Open XML định nghĩa cấu trúc cho dữ liệu chứa trong các bản trình bày. 

Với một *slide* là một trong các yếu tố của bản trình bày, một *slide part* chứa nội dung của một slide duy nhất. Một slide part được phép có các quan hệ rõ ràng với nhiều phần — chẳng hạn như User Defined Tags — được định nghĩa bởi ISO/IEC 29500. 

Dữ liệu tùy chỉnh (cụ thể cho một bản trình bày) hoặc người dùng có thể tồn tại dưới dạng thẻ ([TagCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TagCollection)) và CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
Thẻ thực chất là các cặp giá trị chuỗi‑khóa. 
{{% /alert %}} 

## **Lấy giá trị cho các thẻ**

Trong slides, một thẻ tương ứng với các phương thức [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) và [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Đoạn mã mẫu này cho bạn thấy cách lấy giá trị của một thẻ bằng Aspose.Slides cho Node.js qua Java cho [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm thẻ vào bản trình bày**

Aspose.Slides cho phép bạn thêm thẻ vào các bản trình bày. Một thẻ thường bao gồm hai mục:

- tên của thuộc tính tùy chỉnh - `MyTag`
- giá trị của thuộc tính tùy chỉnh - `My Tag Value`

Nếu bạn cần phân loại một số bản trình bày dựa trên quy tắc hoặc thuộc tính cụ thể, thì việc thêm thẻ vào các bản trình bày đó có thể có lợi. Ví dụ, nếu bạn muốn phân loại hoặc gom tất cả các bản trình bày từ các quốc gia Bắc Mỹ lại với nhau, bạn có thể tạo một thẻ North American và sau đó gán các quốc gia liên quan (Mỹ, Mexico và Canada) làm giá trị.

Đoạn mã mẫu này cho bạn thấy cách thêm một thẻ vào [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) bằng Aspose.Slides cho Node.js qua Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Thẻ cũng có thể được đặt cho [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Hoặc bất kỳ [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) nào riêng lẻ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Giới hạn**

Các thẻ được thêm thông qua bộ sưu tập thẻ dữ liệu tùy chỉnh bằng cách sử dụng `getCustomData().getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình bày được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán làm thẻ không thể được truy xuất từ PDF có thẻ.

**Giải pháp thay thế**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình bày, slide hoặc shape trong một thao tác duy nhất không?**

Có. [Bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/clear/) để xóa tất cả các cặp khóa‑giá trị cùng một lúc.

**Làm thế nào để xóa một thẻ duy nhất theo tên mà không cần lặp qua toàn bộ bộ sưu tập?**

Sử dụng thao tác [remove(name)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/remove/) trên [TagCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.