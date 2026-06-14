---
title: Quản lý tiêu đề và chân trang cho bản trình bày trong PHP
linktitle: Tiêu đề và Chân trang
type: docs
weight: 140
url: /vi/php-java/presentation-header-and-footer/
keywords:
- tiêu đề
- văn bản tiêu đề
- chân trang
- văn bản chân trang
- đặt tiêu đề
- đặt chân trang
- tài liệu phát tay
- ghi chú
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Sử dụng Aspose.Slides for PHP via Java để thêm và tùy chỉnh tiêu đề và chân trang trong các bản trình bày PowerPoint và OpenDocument, tạo giao diện chuyên nghiệp."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý cài đặt tiêu đề và chân trang trong các bản trình bày PowerPoint. Tiêu đề và chân trang được xử lý ở mức master của bản trình bày, và API cung cấp các phương thức để đặt văn bản chân trang, thay đổi hiển thị chân trang và cập nhật văn bản tiêu đề trên các slide ghi chú master.

Bạn cũng có thể quản lý tiêu đề và chân trang cho các slide tài liệu phát tay và ghi chú. Điều này bao gồm việc thay đổi hiển thị và nội dung của các placeholder tiêu đề, chân trang, số slide và ngày‑giờ cho notes master, tất cả các slide ghi chú con hoặc một slide ghi chú riêng lẻ.

## **Quản lý Tiêu đề và Chân trang trong Bản trình bày**

Ghi chú của một số slide cụ thể có thể bị xóa như minh họa dưới đây:

```php
  # Tải bản trình bày
  $pres = new Presentation("headerTest.pptx");
  try {
    # Đặt chân trang
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # Truy cập và Cập nhật tiêu đề
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # Lưu bản trình bày
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Quản lý Tiêu đề và Chân trang trên Slide Tài liệu và Ghi chú**
Aspose.Slides for PHP via Java hỗ trợ Tiêu đề và Chân trang trong slide tài liệu và ghi chú. Vui lòng thực hiện các bước sau:

- Tải một [Bản trình bày](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa video.
- Thay đổi cài đặt Tiêu đề và Chân trang cho notes master và tất cả các slide ghi chú.
- Đặt các placeholder Chân trang của master notes slide và tất cả các placeholder con hiển thị.
- Đặt các placeholder Ngày và giờ của master notes slide và tất cả các placeholder con hiển thị.
- Thay đổi cài đặt Tiêu đề và Chân trang chỉ cho slide ghi chú đầu tiên.
- Đặt placeholder Tiêu đề của slide ghi chú hiển thị.
- Đặt văn bản cho placeholder Tiêu đề của slide ghi chú.
- Đặt văn bản cho placeholder Ngày‑giờ của slide ghi chú.
- Ghi file bản trình bày đã chỉnh sửa.

Đoạn mã mẫu được cung cấp trong Ví dụ dưới đây.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    # Thay đổi cài đặt Tiêu đề và Chân trang cho notes master và tất cả các slide ghi chú
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// làm cho master notes slide và tất cả placeholder Tiêu đề con hiển thị

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// làm cho master notes slide và tất cả placeholder Chân trang con hiển thị

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// làm cho master notes slide và tất cả placeholder Số slide con hiển thị

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// làm cho master notes slide và tất cả placeholder Ngày và giờ con hiển thị

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// đặt văn bản cho master notes slide và tất cả placeholder Tiêu đề con

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// đặt văn bản cho master notes slide và tất cả placeholder Chân trang con

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// đặt văn bản cho master notes slide và tất cả placeholder Ngày và giờ con

    }
    # Thay đổi cài đặt Tiêu đề và Chân trang chỉ cho slide ghi chú đầu tiên
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// làm cho placeholder Tiêu đề của slide ghi chú này hiển thị

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// làm cho placeholder Chân trang của slide ghi chú này hiển thị

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// làm cho placeholder Số slide của slide ghi chú này hiển thị

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// làm cho placeholder Ngày‑giờ của slide ghi chú này hiển thị

      $headerFooterManager->setHeaderText("New header text");// đặt văn bản cho placeholder Tiêu đề của slide ghi chú

      $headerFooterManager->setFooterText("New footer text");// đặt văn bản cho placeholder Chân trang của slide ghi chú

      $headerFooterManager->setDateTimeText("New date and time text");// đặt văn bản cho placeholder Ngày‑giờ của slide ghi chú

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Tôi có thể thêm “tiêu đề” vào các slide thông thường không?**

Trong PowerPoint, “Tiêu đề” chỉ tồn tại cho ghi chú và tài liệu phát tay; trên các slide thông thường, các yếu tố được hỗ trợ là chân trang, ngày/giờ và số slide. Trong Aspose.Slides điều này cũng tương tự: tiêu đề chỉ dành cho Notes/Handout, còn trên slide thì có Chân trang/DateTime/SlideNumber.

**Nếu bố cục không có vùng chân trang—tôi có thể “bật” hiển thị không?**

Có. Kiểm tra trạng thái hiển thị qua trình quản lý tiêu đề/chân trang và bật nó nếu cần. Các chỉ báo và phương thức API này được thiết kế cho trường hợp placeholder bị thiếu hoặc bị ẩn.

**Làm sao để số slide bắt đầu từ giá trị khác 1?**

Đặt [số slide đầu tiên](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/setfirstslidenumber/) cho bản trình bày; sau đó, tất cả các số sẽ được tính lại. Ví dụ, bạn có thể bắt đầu từ 0 hoặc 10, và ẩn số trên slide tiêu đề.

**Tiêu đề/chân trang sẽ như thế nào khi xuất ra PDF/hình ảnh/HTML?**

Chúng được hiển thị như các thành phần văn bản thường của bản trình bày. Nghĩa là, nếu các yếu tố này hiển thị trên slide/ghi chú, chúng cũng sẽ xuất hiện trong định dạng đầu ra cùng với các nội dung còn lại.