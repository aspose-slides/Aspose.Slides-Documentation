---
title: Khôi phục và Cập nhật Thông tin Bài thuyết trình trong PHP
linktitle: Thông tin Bài thuyết trình
type: docs
weight: 30
url: /vi/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho PHP để có những hiểu biết nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này trình bày cách kiểm tra thông tin bài thuyết trình trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của một bài thuyết trình mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/) và minh họa các thao tác thông thường khi làm việc với siêu dữ liệu của bài thuyết trình.

## **Kiểm tra định dạng Bài thuyết trình**

Trước khi làm việc với một bài thuyết trình, bạn có thể muốn biết bài thuyết trình hiện đang ở định dạng nào (PPT, PPTX, ODP và các định dạng khác).

Bạn có thể kiểm tra định dạng của bài thuyết trình mà không cần tải bài thuyết trình. Xem đoạn mã PHP này:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Lấy Thuộc tính Bài thuyết trình**

Đoạn mã PHP này cho bạn cách lấy các thuộc tính của bài thuyết trình (thông tin về bài thuyết trình):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Bạn có thể muốn xem các thuộc tính trong lớp [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Cập nhật Thuộc tính Bài thuyết trình**

Aspose.Slides cung cấp phương thức [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) cho phép bạn thực hiện các thay đổi đối với thuộc tính của bài thuyết trình.

Giả sử chúng ta có một bài thuyết trình PowerPoint với các thuộc tính tài liệu được hiển thị bên dưới.

![Thuộc tính tài liệu gốc của bài thuyết trình PowerPoint](input_properties.png)

Ví dụ mã này cho bạn cách chỉnh sửa một số thuộc tính của bài thuyết trình:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị bên dưới.

![Thuộc tính tài liệu đã thay đổi của bài thuyết trình PowerPoint](output_properties.png)

## **Liên kết Hữu ích**

Để có thêm thông tin về một bài thuyết trình và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Kiểm tra xem Bài thuyết trình có được Mã hoá không](https://docs.aspose.com/slides/vi/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kiểm tra xem Bài thuyết trình có được Bảo vệ Ghi (chỉ đọc) không](https://docs.aspose.com/slides/vi/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kiểm tra xem Bài thuyết trình có được Bảo vệ Bằng Mật khẩu Trước khi Tải không](https://docs.aspose.com/slides/vi/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Xác nhận Mật khẩu Được Sử dụng để Bảo vệ Bài thuyết trình](https://docs.aspose.com/slides/vi/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Câu hỏi Thường gặp**

**Làm thế nào tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông chữ nào?**

Tìm thông tin [phông chữ được nhúng](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) ở cấp độ bài thuyết trình, sau đó so sánh các mục này với tập hợp [phông chữ thực sự được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getfonts/) để xác định phông chữ nào là quan trọng cho việc hiển thị.

**Làm sao tôi có thể nhanh chóng biết tệp có slide ẩn và có bao nhiêu?**

Duyệt qua [bộ sưu tập slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) và kiểm tra [cờ hiển thị](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/gethidden/) của mỗi slide.

**Tôi có thể phát hiện liệu có sử dụng kích thước và hướng slide tùy chỉnh không, và liệu chúng có khác với mặc định không?**

Có. So sánh [kích thước slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getslidesize/) và hướng hiện tại với các cài đặt chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả các [biểu đồ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/), kiểm tra [nguồn dữ liệu](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/getdatasourcetype/) của chúng và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm thế nào tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm phức tạp sơ bộ để đánh dấu các điểm nóng tiềm năng về hiệu năng.