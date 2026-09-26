---
title: Quản lý ghi chú bản trình bày trong PHP
linktitle: Ghi chú bản trình bày
type: docs
weight: 110
url: /vi/php-java/presentation-notes/
keywords:
- ghi chú
- slide ghi chú
- thêm ghi chú
- xóa ghi chú
- kiểu ghi chú
- ghi chú chính
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Tùy chỉnh ghi chú bản trình bày với Aspose.Slides cho PHP qua Java. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để nâng cao năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ việc loại bỏ các slide ghi chú khỏi bản trình bày. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách xóa ghi chú và cách áp dụng kiểu cho các slide ghi chú trong bản trình bày. Aspose.Slides cho phép bạn xóa ghi chú khỏi bất kỳ slide nào và cũng có thể áp dụng định dạng cho các ghi chú hiện có. Các nhà phát triển có thể xóa ghi chú theo các cách sau:

- Xóa ghi chú khỏi một slide cụ thể trong bản trình bày.
- Xóa ghi chú khỏi tất cả các slide trong bản trình bày.

Để đọc hoặc thay đổi kích thước trang ghi chú, chuyển đổi hướng, và kiểm tra hành vi xuất, xem [Notes Page Size](/slides/vi/php-java/notes-size/).

## **Xóa ghi chú khỏi một slide**
Ghi chú từ một slide cụ thể có thể được xóa như trong ví dụ dưới đây:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình bày
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Xóa ghi chú của slide đầu tiên
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Lưu bản trình bày vào ổ đĩa
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa ghi chú khỏi một bản trình bày**
Ghi chú từ tất cả các slide trong bản trình bày có thể được xóa như trong ví dụ dưới đây:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình bày
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Xóa ghi chú của tất cả các slide
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Lưu bản trình bày vào ổ đĩa
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm kiểu ghi chú**
Phương thức [getNotesStyle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) của lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterNotesSlide) cung cấp quyền truy cập vào kiểu văn bản ghi chú. Việc triển khai được trình diễn trong ví dụ dưới đây.

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình bày
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Lấy kiểu văn bản MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Đặt biểu tượng bullet cho các đoạn ở mức độ đầu tiên
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Thực thể API nào cung cấp quyền truy cập vào ghi chú của một slide cụ thể?**

Ghi chú được truy cập thông qua trình quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslidemanager/) và một [phương thức](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslidemanager/getnotesslide/) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác nhau nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện hỗ trợ một loạt các định dạng Microsoft PowerPoint (từ 97 trở lên) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt PowerPoint.