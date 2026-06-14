---
title: Chuyển đổi bản trình chiếu PowerPoint sang SWF Flash trong PHP
linktitle: PowerPoint sang SWF
type: docs
weight: 80
url: /vi/php-java/convert-powerpoint-to-swf-flash/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang SWF
- bản trình chiếu sang SWF
- slide sang SWF
- PPT sang SWF
- PPTX sang SWF
- PowerPoint sang Flash
- bản trình chiếu sang Flash
- slide sang Flash
- PPT sang Flash
- PPTX sang Flash
- lưu PPT dưới dạng SWF
- lưu PPTX dưới dạng SWF
- xuất PPT sang SWF
- xuất PPTX sang SWF
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chuyển đổi PowerPoint (PPT/PPTX) sang SWF Flash trong PHP với Aspose.Slides. Mẫu mã từng bước, đầu ra nhanh chất lượng, không cần tự động hoá PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang SWF bằng cách sử dụng Aspose.Slides. Nó cho thấy cách lưu một bản trình chiếu dưới dạng tệp SWF bằng phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/save/) và cách cấu hình việc xuất bằng [SwfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/), bao gồm các cài đặt trình xem và bố cục ghi chú hoặc bình luận.

## **Chuyển đổi bản trình chiếu sang Flash**

Phương thức [save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/save/) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) có thể được dùng để chuyển toàn bộ bản trình chiếu thành một tài liệu **SWF**. Ví dụ sau cho thấy cách chuyển một bản trình chiếu thành tài liệu **SWF** bằng cách sử dụng các tùy chọn được cung cấp bởi lớp [SWFOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/). Bạn cũng có thể bao gồm bình luận trong SWF đã tạo bằng cách sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/notescommentslayoutingoptions/).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Lưu bản trình chiếu
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể bao gồm các slide ẩn trong SWF không?**

Có. Kích hoạt các slide ẩn bằng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/setshowhiddenslides/) trong [SwfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/). Mặc định, các slide ẩn sẽ không được xuất.

**Làm thế nào tôi có thể kiểm soát nén và kích thước cuối cùng của SWF?**

Sử dụng phương thức [setCompressed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/setcompressed/) và [adjust JPEG quality](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/setjpegquality/) để cân bằng giữa kích thước tệp và độ trung thực hình ảnh.

**'setViewerIncluded' dùng để làm gì, và khi nào tôi nên tắt nó?**

[setViewerIncluded](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/setviewerincluded/) thêm giao diện người dùng trình phát nhúng (các điều khiển điều hướng, bảng, tìm kiếm). Hãy tắt nó nếu bạn dự định sử dụng trình phát riêng hoặc cần một khung SWF không có giao diện người dùng.

**Điều gì sẽ xảy ra nếu phông chữ nguồn thiếu trên máy xuất?**

Aspose.Slides sẽ thay thế phông chữ bằng phông chữ bạn chỉ định qua [setDefaultRegularFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) trong [SwfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/swfoptions/) để tránh việc sử dụng phông chữ dự phòng không mong muốn.