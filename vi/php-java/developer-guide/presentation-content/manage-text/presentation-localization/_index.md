---
title: Tự động hoá địa phương hoá bản trình chiếu trong PHP
linktitle: Địa phương hoá bản trình chiếu
type: docs
weight: 100
url: /vi/php-java/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- định danh ngôn ngữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tự động hoá địa phương hoá slide PowerPoint và OpenDocument với Aspose.Slides cho PHP thông qua Java, sử dụng các mẫu mã thực tế và mẹo để triển khai toàn cầu nhanh hơn."
---
## **Tổng quan**

Bài viết này giải thích cách đặt `LanguageId` cho văn bản trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách mở một bản trình chiếu, thêm một hình dạng có văn bản, gán một định danh ngôn ngữ cho một phần văn bản, và lưu kết quả dưới dạng tệp PPTX.

## **Thay đổi ngôn ngữ cho bản trình chiếu và văn bản hình dạng**
- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) loại [Rectangle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ShapeType#Rectangle) vào slide.
- Thêm một số văn bản vào TextFrame.
- Đặt [Đặt Language Id](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) cho văn bản.
- Ghi bản trình chiếu dưới dạng tệp PPTX.

Việc thực hiện các bước trên được minh họa dưới đây trong một ví dụ.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**ID ngôn ngữ có kích hoạt tự động dịch văn bản không?**

Không. [Language ID](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) trong Aspose.Slides lưu trữ ngôn ngữ cho việc kiểm tra chính tả và chứng minh ngữ pháp, nhưng nó không dịch hoặc thay đổi nội dung văn bản. Nó là siêu dữ liệu mà PowerPoint hiểu để chứng minh.

**ID ngôn ngữ có ảnh hưởng đến việc gạch nối và ngắt dòng khi vẽ không?**

Trong Aspose.Slides, [language ID](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) được dùng cho việc chứng minh. Chất lượng gạch nối và việc ngắt dòng chủ yếu phụ thuộc vào sự có sẵn của [phông chữ thích hợp](/slides/vi/php-java/powerpoint-fonts/) và các cài đặt bố cục/ngắt dòng cho hệ thống viết. Để đảm bảo vẽ đúng, hãy cung cấp các phông chữ cần thiết, cấu hình [các quy tắc thay thế phông chữ](/slides/vi/php-java/font-substitution/), và/hoặc [nhúng phông chữ](/slides/vi/php-java/embedded-font/) vào bản trình chiếu.

**Tôi có thể đặt các ngôn ngữ khác nhau trong một đoạn văn duy nhất không?**

Có. [Language ID](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) được áp dụng ở mức phần văn bản, vì vậy một đoạn văn duy nhất có thể kết hợp nhiều ngôn ngữ với các cài đặt chứng minh khác nhau.