---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trong PHP
linktitle: Thông tin Bản trình chiếu
type: docs
weight: 30
url: /vi/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho PHP để có những hiểu biết nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Overview**

Bài viết này hướng dẫn cách kiểm tra thông tin bản trình chiếu trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của bản trình chiếu mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/) và minh họa các thao tác thường gặp khi làm việc với siêu dữ liệu bản trình chiếu.

## **Check a Presentation Format**

Trước khi làm việc với một bản trình chiếu, bạn có thể muốn biết nó hiện đang ở định dạng nào (PPT, PPTX, ODP và các định dạng khác).

Bạn có thể kiểm tra định dạng của bản trình chiếu mà không cần tải nó. Xem đoạn mã PHP sau:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Get Presentation Properties**

Đoạn mã PHP này cho bạn cách lấy các thuộc tính của bản trình chiếu (thông tin về bản trình chiếu):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Bạn có thể muốn xem [các thuộc tính trong lớp DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Update Presentation Properties**

Aspose.Slides cung cấp phương thức [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) cho phép bạn thực hiện các thay đổi đối với thuộc tính của bản trình chiếu.

Giả sử chúng ta có một bản trình chiếu PowerPoint với các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu gốc của bản trình chiếu PowerPoint](input_properties.png)

Đoạn mã ví dụ này cho bạn cách chỉnh sửa một số thuộc tính của bản trình chiếu:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Thuộc tính tài liệu đã thay đổi của bản trình chiếu PowerPoint](output_properties.png)

## **Useful Links**

Để nhận thêm thông tin về một bản trình chiếu và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Bảo vệ Bản trình chiếu bằng Mật khẩu](/slides/vi/php-java/password-protected-presentation/)
- [Bảo vệ Bản trình chiếu khỏi Việc Ghi](/slides/vi/php-java/write-protected-presentation/)

## **FAQ**

**Làm thế nào tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông chữ nào?**

Tìm thông tin [phông chữ được nhúng](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) ở mức độ bản trình chiếu, sau đó so sánh các mục đó với tập hợp [phông chữ thực tế được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getfonts/) để xác định những phông chữ quan trọng cho việc hiển thị.

**Làm sao tôi có thể nhanh chóng biết tệp có slide ẩn và có bao nhiêu?**

Duyệt qua [bộ sưu tập slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) và kiểm tra [cờ hiển thị](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/gethidden/) của mỗi slide.

**Tôi có thể phát hiện xem có sử dụng kích thước và hướng slide tùy chỉnh không, và chúng có khác với mặc định không?**

Có. So sánh [kích thước slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getslidesize/) và hướng hiện tại với các thiết lập tiêu chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh chóng để kiểm tra xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả [biểu đồ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/), kiểm tra [nguồn dữ liệu](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getdatasourcetype/) của chúng và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm phức tạp sơ bộ để đánh dấu các điểm nóng về hiệu năng tiềm năng.