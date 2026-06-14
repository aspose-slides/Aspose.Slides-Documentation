---
title: "Quản lý Thẻ và Dữ liệu Tùy chỉnh trong Bản trình chiếu bằng PHP"
linktitle: "Thẻ và Dữ liệu Tùy chỉnh"
type: docs
weight: 300
url: /vi/php-java/managing-tags-and-custom-data/
keywords:
- "thuộc tính tài liệu"
- "thẻ"
- "dữ liệu tùy chỉnh"
- "thêm thẻ"
- "cặp giá trị"
- "PowerPoint"
- "bản trình chiếu"
- "PHP"
- "Aspose.Slides"
description: "Tìm hiểu cách thêm, đọc, cập nhật và xóa thẻ & dữ liệu tùy chỉnh trong Aspose.Slides cho PHP qua Java, với các ví dụ cho bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách Aspose.Slides làm việc với thẻ và dữ liệu tùy chỉnh trong các bản trình chiếu PowerPoint. Nó tóm tắt ngắn gọn cách dữ liệu được lưu trữ trong tệp PPTX, lưu ý rằng dữ liệu đặc thù cho bản trình chiếu có thể tồn tại dưới dạng thẻ và các phần XML tùy chỉnh, và mô tả thẻ như các cặp chuỗi khóa‑giá trị.

Nó cũng chỉ ra cách đọc giá trị thẻ và cách thêm thẻ vào một bản trình chiếu, một slide riêng lẻ, hoặc một shape. Ngoài ra, bài viết đề cập đến các tác vụ quản lý thẻ phổ biến như xóa tất cả thẻ, xóa thẻ theo tên, và lấy danh sách tên thẻ.

## **Lưu trữ dữ liệu trong tệp trình chiếu**

Các tệp PPTX—các mục có phần mở rộng .pptx—được lưu ở định dạng PresentationML, là một phần của tiêu chuẩn Office Open XML. Định dạng Office Open XML xác định cấu trúc cho dữ liệu chứa trong các bản trình chiếu. 

Với một *slide* là một trong các thành phần của bản trình chiếu, một *slide part* chứa nội dung của một slide duy nhất. Một slide part có thể có các mối quan hệ rõ ràng tới nhiều phần—như User Defined Tags—được định nghĩa bởi ISO/IEC 29500. 

Dữ liệu tùy chỉnh (cụ thể cho một bản trình chiếu) hoặc người dùng có thể tồn tại dưới dạng thẻ ([TagCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/)) và CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
Thẻ thực chất là các cặp khóa‑giá trị kiểu chuỗi. 
{{% /alert %}} 

## **Lấy giá trị của Thẻ**

Trong slides, một thẻ tương ứng với các phương thức [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getKeywords) và [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#setKeywords). Đoạn mã mẫu sau cho bạn thấy cách lấy giá trị thẻ bằng Aspose.Slides for PHP via Java cho [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Thẻ vào Bản Trình Chiếu**

Aspose.Slides cho phép bạn thêm thẻ vào các bản trình chiếu. Một thẻ thường bao gồm hai mục: 

- tên của thuộc tính tùy chỉnh - `MyTag` 
- giá trị của thuộc tính tùy chỉnh - `My Tag Value`

Nếu bạn cần phân loại một số bản trình chiếu dựa trên quy tắc hoặc thuộc tính cụ thể, thì việc thêm thẻ vào các bản trình chiếu sẽ có lợi. Ví dụ, nếu bạn muốn nhóm tất cả các bản trình chiếu từ các nước Bắc Mỹ lại với nhau, bạn có thể tạo một thẻ North American và sau đó gán các quốc gia liên quan (Mỹ, Mexico và Canada) làm giá trị. 

Đoạn mã mẫu sau cho bạn thấy cách thêm thẻ vào một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) bằng Aspose.Slides for PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Thẻ cũng có thể được đặt cho [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Hoặc bất kỳ [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) cá nhân nào:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Giới hạn**

Các thẻ được thêm thông qua bộ sưu tập thẻ dữ liệu tùy chỉnh bằng cách gọi `getCustomData()->getTags()` chỉ được lưu trong tệp PowerPoint. Chúng **không** được chuyển sang cấu trúc thẻ PDF khi bản trình chiếu được xuất ra PDF. Do đó, một định danh tùy chỉnh được gán làm thẻ không thể được truy xuất từ PDF đã gắn thẻ.

**Cách khắc phục**: Bạn có thể lưu định danh tùy chỉnh trong **Alt Text** của đối tượng (ví dụ, `$shape->setAlternativeText("MyId")`). Sau khi xuất ra PDF, Alt Text có thể xuất hiện trong cấu trúc thẻ PDF.

## **Câu hỏi thường gặp**

**Tôi có thể xóa tất cả thẻ khỏi một bản trình chiếu, slide hoặc shape trong một thao tác duy nhất không?**

Có. [tag collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/) hỗ trợ thao tác [clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/clear/) để xóa tất cả các cặp khóa‑giá trị cùng lúc.

**Làm thế nào để xóa một thẻ duy nhất theo tên mà không phải duyệt qua toàn bộ bộ sưu tập?**

Sử dụng thao tác [remove(name)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/remove/) trên [tag collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/) để xóa thẻ theo khóa của nó.

**Làm sao tôi có thể lấy danh sách đầy đủ các tên thẻ để phân tích hoặc lọc?**

Sử dụng [getNamesOfTags](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/getnamesoftags/) trên [tag collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tagcollection/); nó sẽ trả về một mảng chứa tất cả các tên thẻ.