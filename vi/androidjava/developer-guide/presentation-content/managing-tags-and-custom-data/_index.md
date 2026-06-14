---
title: Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình bày trên Android
linktitle: Thẻ và Dữ liệu Tùy chỉnh
type: docs
weight: 300
url: /vi/androidjava/managing-tags-and-custom-data
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Thêm, đọc, cập nhật và xóa thẻ & dữ liệu tùy chỉnh trong Aspose.Slides cho Android, với các ví dụ Java cho bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình bày PowerPoint. Nó tóm tắt ngắn gọn cách dữ liệu được lưu trong tệp PPTX, lưu ý rằng dữ liệu đặc thù cho bản trình bày có thể tồn tại dưới dạng thẻ và các phần XML tùy chỉnh, và mô tả thẻ như các cặp khóa-giá trị dạng chuỗi.

Nó cũng cho thấy cách đọc giá trị thẻ và cách thêm thẻ vào một bản trình bày, một slide riêng lẻ hoặc một shape. Ngoài ra, bài viết bao phủ các tác vụ quản lý thẻ phổ biến như xóa tất cả thẻ, loại bỏ một thẻ theo tên và lấy danh sách tên thẻ.

## **Lưu trữ dữ liệu trong tệp bản trình bày**

Các tệp PPTX—các mục có phần mở rộng .pptx—được lưu ở định dạng PresentationML, một phần của thông số kỹ thuật Office Open XML. Định dạng Office Open XML xác định cấu trúc cho dữ liệu chứa trong các bản trình bày. 

Với một *slide* là một trong các yếu tố của bản trình bày, một *slide part* chứa nội dung của một slide duy nhất. Một slide part có thể có các mối quan hệ rõ ràng với nhiều phần—chẳng hạn như User Defined Tags—được định nghĩa bởi ISO/IEC 29500. 

Dữ liệu tùy chỉnh (đặc thù cho một bản trình bày) hoặc người dùng có thể tồn tại dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITagCollection)) và CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Thẻ về cơ bản là các giá trị cặp khóa‑chuỗi. 
{{% /alert %}} 

## **Lấy giá trị của Thẻ**

Trong Slides, một thẻ tương ứng với các phương thức [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) và [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Đoạn mã mẫu này cho bạn biết cách lấy giá trị của một thẻ bằng Aspose.Slides cho Android qua Java cho [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm Thẻ vào Bản Trình Bày**

Aspose.Slides cho phép bạn thêm thẻ vào các bản trình bày. Một thẻ thường gồm hai mục:

- tên của thuộc tính tùy chỉnh - `MyTag` 
- giá trị của thuộc tính tùy chỉnh - `My Tag Value`

Nếu bạn cần phân loại một số bản trình bày dựa trên quy tắc hoặc thuộc tính cụ thể, thì việc thêm thẻ vào các bản trình bày đó có thể hữu ích. Ví dụ, nếu bạn muốn phân loại hoặc gom tất cả các bản trình bày từ các nước Bắc Mỹ lại với nhau, bạn có thể tạo một thẻ North American và sau đó gán các quốc gia liên quan (Mỹ, Mexico và Canada) làm giá trị.

Đoạn mã mẫu này cho bạn biết cách thêm thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) bằng Aspose.Slides cho Android qua Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Thẻ cũng có thể được đặt cho [Slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Hoặc bất kỳ [Shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape) cá nhân nào:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Giới hạn**

Các thẻ được thêm thông qua bộ sưu tập thẻ dữ liệu tùy chỉnh bằng cách gọi `getCustomData().getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình bày được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán làm thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Giải pháp thay thế**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình bày, slide hoặc shape trong một thao tác duy nhất không?**

Có. Bộ sưu tập [tag collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/#clear--) để xóa hết tất cả các cặp khóa‑giá trị cùng lúc.

**Làm sao để xóa một thẻ duy nhất theo tên mà không phải duyệt qua toàn bộ bộ sưu tập?**

Sử dụng thao tác [remove(name)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) trên [tag collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm thế nào tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) trên [tag collection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.