---
title: So sánh các slide trong bản trình chiếu bằng PHP
linktitle: So sánh slide
type: docs
weight: 50
url: /vi/php-java/compare-slides/
keywords:
- so sánh slide
- so sánh slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "So sánh các bản trình chiếu PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho PHP thông qua Java. Xác định nhanh sự khác biệt của các slide trong mã."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn so sánh các slide, slide bố cục và slide mẫu bằng cách sử dụng phương thức `equals` được cung cấp bởi lớp `BaseSlide`. Phương thức này trả về `true` khi các slide được so sánh giống hệt nhau về cấu trúc và nội dung tĩnh.

## **So sánh hai slide**

Phương thức Equals đã được thêm vào lớp [BaseSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/BaseSlide). Nó trả về true cho các slide/bố cục và slide/mẫu mà giống nhau về cấu trúc và nội dung tĩnh.

Hai slide được coi là bằng nhau nếu tất cả các hình dạng, kiểu dáng, văn bản, hoạt ảnh và các thiết lập khác, v.v. đều bằng nhau. Việc so sánh không tính đến các giá trị định danh duy nhất, chẳng hạn như SlideId và nội dung động, ví dụ giá trị ngày hiện tại trong Date Placeholder.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **Câu hỏi thường gặp**

**Liệu việc một slide bị ẩn có ảnh hưởng đến việc so sánh các slide hay không?**

[Hidden status](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/gethidden/) là thuộc tính ở mức trình chiếu/đánh dấu, không phải nội dung trực quan. Độ bằng nhau của hai slide cụ thể được xác định bởi cấu trúc và nội dung tĩnh của chúng; việc một slide bị ẩn không khiến các slide trở nên khác nhau.

**Liên kết siêu văn bản và các tham số của chúng có được tính đến không?**

Có. Liên kết là một phần của nội dung tĩnh của slide. Nếu URL hoặc hành động siêu liên kết khác nhau, thường sẽ được xem là sự khác biệt trong nội dung tĩnh.

**Nếu một biểu đồ tham chiếu đến file Excel bên ngoài, nội dung của file đó có được tính đến không?**

Không. Việc so sánh được thực hiện dựa trên chính các slide. Các nguồn dữ liệu bên ngoài thường không được đọc khi so sánh; chỉ những gì có trong cấu trúc và trạng thái tĩnh của slide mới được xem xét.