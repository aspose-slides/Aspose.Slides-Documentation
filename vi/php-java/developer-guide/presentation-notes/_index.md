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
description: "Tùy chỉnh ghi chú bản trình bày với Aspose.Slides cho PHP qua Java. Làm việc liền mạch với ghi chú PowerPoint và OpenDocument để tăng năng suất của bạn."
---
## **Tổng quan**

Aspose.Slides hỗ trợ gỡ bỏ các slide ghi chú khỏi một bản trình bày. Trong chủ đề này, chúng tôi sẽ giới thiệu tính năng này, bao gồm cách gỡ bỏ ghi chú và cách áp dụng kiểu cho slide ghi chú trong một bản trình bày. Aspose.Slides cho phép bạn gỡ bỏ ghi chú khỏi bất kỳ slide nào và cũng áp dụng kiểu cho các ghi chú hiện có. Các nhà phát triển có thể gỡ bỏ ghi chú theo các cách sau:

- Gỡ bỏ ghi chú khỏi một slide cụ thể trong bản trình bày.
- Gỡ bỏ ghi chú khỏi tất cả các slide trong bản trình bày.

## **Gỡ bỏ ghi chú khỏi một slide**
Ghi chú của một slide cụ thể có thể được gỡ bỏ như trong ví dụ bên dưới:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Xóa ghi chú của slide đầu tiên
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # Lưu bản trình bày vào đĩa
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gỡ bỏ ghi chú khỏi một bản trình bày**
Ghi chú của tất cả các slide trong một bản trình bày có thể được gỡ bỏ như trong ví dụ bên dưới:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # Xóa ghi chú của tất cả các slide
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # Lưu bản trình bày vào đĩa
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm kiểu ghi chú**
[getNotesStyle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) phương thức đã được thêm vào lớp [MasterNotesSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterNotesSlide) tương ứng. Thuộc tính này xác định kiểu của văn bản ghi chú. Việc thực hiện được minh họa trong ví dụ dưới đây.

```php
  # Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình bày
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # Lấy kiểu văn bản MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # Đặt ký hiệu bullet cho các đoạn văn cấp độ đầu tiên
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

Ghi chú được truy cập thông qua quản lý ghi chú của slide: slide có một [NotesSlideManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslidemanager/) và một [method](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notesslidemanager/getnotesslide/) trả về đối tượng ghi chú, hoặc `null` nếu không có ghi chú.

**Có sự khác biệt nào trong việc hỗ trợ ghi chú giữa các phiên bản PowerPoint mà thư viện hỗ trợ không?**

Thư viện hướng tới một loạt các định dạng Microsoft PowerPoint (97–mới hơn) và ODP; ghi chú được hỗ trợ trong các định dạng này mà không phụ thuộc vào việc cài đặt PowerPoint.