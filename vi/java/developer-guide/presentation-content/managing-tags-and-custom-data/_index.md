---
title: Quản lý thẻ và dữ liệu tùy chỉnh trong bản trình chiếu bằng Java
linktitle: Thẻ và dữ liệu tùy chỉnh
type: docs
weight: 300
url: /vi/java/managing-tags-and-custom-data/
keywords:
- thuộc tính tài liệu
- thẻ
- dữ liệu tùy chỉnh
- thêm thẻ
- cặp giá trị
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, đọc, cập nhật và xóa thẻ & dữ liệu tùy chỉnh trong Aspose.Slides cho Java, kèm ví dụ cho bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides hoạt động với thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu PowerPoint. Nó tóm tắt ngắn gọn cách dữ liệu được lưu trong tệp PPTX, lưu ý rằng dữ liệu riêng biệt cho bản trình chiếu có thể tồn tại dưới dạng thẻ và các phần XML tùy chỉnh, và mô tả thẻ như các cặp chuỗi khóa-giá trị.

Nó cũng chỉ ra cách đọc giá trị thẻ và cách thêm thẻ vào một bản trình chiếu, một slide riêng lẻ hoặc một hình dạng. Ngoài ra, bài viết bao gồm các tác vụ quản lý thẻ thường gặp như xóa tất cả thẻ, xóa một thẻ theo tên và lấy danh sách các tên thẻ.

## **Lưu trữ dữ liệu trong tệp bản trình chiếu**

Các tệp PPTX—các mục có phần mở rộng .pptx—được lưu dưới định dạng PresentationML, một phần của tiêu chuẩn Office Open XML. Định dạng Office Open XML định nghĩa cấu trúc cho dữ liệu chứa trong các bản trình chiếu. 

Với một *slide* là một trong các thành phần của bản trình chiếu, một *slide part* chứa nội dung của một slide duy nhất. Một slide part được phép có các quan hệ rõ ràng với nhiều phần—như User Defined Tags—được định nghĩa bởi ISO/IEC 29500. 

Dữ liệu tùy chỉnh (đặc thù cho một bản trình chiếu) hoặc người dùng có thể tồn tại dưới dạng thẻ ([ITagCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITagCollection)) và CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 
Thẻ thực chất là các cặp khóa‑giá trị dạng chuỗi. 
{{% /alert %}} 

## **Lấy giá trị của thẻ**

Trong các slide, một thẻ tương ứng với các phương thức [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IDocumentProperties#getKeywords--) và [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Đoạn mã mẫu này cho bạn thấy cách lấy giá trị của một thẻ bằng Aspose.Slides cho Java cho [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thêm thẻ vào bản trình chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào bản trình chiếu. Một thẻ thường bao gồm hai mục: 

- tên của thuộc tính tùy chỉnh - `MyTag` 
- giá trị của thuộc tính tùy chỉnh - `My Tag Value`

Nếu bạn cần phân loại một số bản trình chiếu dựa trên quy tắc hoặc thuộc tính cụ thể, thì bạn có thể hưởng lợi từ việc thêm thẻ vào các bản trình chiếu đó. Ví dụ, nếu bạn muốn phân loại hoặc nhóm tất cả các bản trình chiếu từ các quốc gia Bắc Mỹ lại với nhau, bạn có thể tạo một thẻ North American và sau đó gán các quốc gia tương ứng (Mỹ, Mexico và Canada) làm giá trị.

Đoạn mã mẫu này cho bạn thấy cách thêm một thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) bằng Aspose.Slides cho Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Thẻ cũng có thể được đặt cho [Slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Hoặc bất kỳ [Shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape) nào riêng lẻ:

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

Thẻ được thêm thông qua bộ sưu tập thẻ dữ liệu tùy chỉnh bằng cách sử dụng `getCustomData().getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán dưới dạng thẻ không thể được truy xuất từ PDF có thẻ.

**Workaround**: Bạn có thể lưu một định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `shape.setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Có thể xóa tất cả thẻ khỏi một bản trình chiếu, slide hoặc hình dạng trong một thao tác duy nhất không?**

Có. [Bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#clear--) để xóa tất cả các cặp khóa‑giá trị cùng một lúc.

**Làm sao để xóa một thẻ duy nhất theo tên mà không phải lặp qua toàn bộ bộ sưu tập?**

Sử dụng thao tác [Remove(name)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao để lấy danh sách đầy đủ các tên thẻ cho việc phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/#getNamesOfTags--) trên [bộ sưu tập thẻ](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tagcollection/); nó trả về một mảng chứa tất cả các tên thẻ.