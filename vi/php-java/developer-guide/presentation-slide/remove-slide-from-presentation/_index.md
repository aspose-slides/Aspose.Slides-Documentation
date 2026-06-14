---
title: Xóa các slide khỏi các bài trình chiếu trong PHP
linktitle: Xóa slide
type: docs
weight: 30
url: /vi/php-java/remove-slide-from-presentation/
keywords:
- xóa slide
- xoá slide
- xóa slide không sử dụng
- PowerPoint
- OpenDocument
- bài trình chiếu
- PHP
- Aspose.Slides
description: "Dễ dàng xóa các slide khỏi các bài trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java. Nhận các ví dụ mã rõ ràng và nâng cao quy trình làm việc của bạn."
---
## **Giới thiệu**

Nếu một slide (hoặc nội dung của nó) trở nên dư thừa, bạn có thể xóa nó. Aspose.Slides cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) bao đóng lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/), là kho lưu trữ cho tất cả các slide trong một bản trình chiếu. Bằng cách sử dụng con trỏ (tham chiếu hoặc chỉ mục) cho một đối tượng [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/) đã biết, bạn có thể chỉ định slide bạn muốn loại bỏ.

## **Xóa một slide bằng tham chiếu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu của slide bạn muốn xóa thông qua ID hoặc chỉ mục của nó.
1. Xóa slide đã được tham chiếu khỏi bản trình chiếu.
1. Lưu bản trình chiếu đã được chỉnh sửa. 

Đoạn mã PHP này cho bạn thấy cách xóa một slide thông qua tham chiếu của nó:

```php
  # Tạo một đối tượng Presentation đại diện cho tệp trình chiếu
  $pres = new Presentation("demo.pptx");
  try {
    # Truy cập một slide qua chỉ mục của nó trong bộ sưu tập các slide
    $slide = $pres->getSlides()->get_Item(0);
    # Xóa một slide qua tham chiếu của nó
    $pres->getSlides()->remove($slide);
    # Lưu bản trình chiếu đã chỉnh sửa
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Xóa một slide bằng chỉ mục**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Xóa slide khỏi bản trình chiếu bằng vị trí chỉ mục của nó.
1. Lưu bản trình chiếu đã được chỉnh sửa. 

Đoạn mã PHP này cho bạn thấy cách xóa một slide thông qua chỉ mục:

```php
  # Tạo một đối tượng Presentation đại diện cho tệp trình chiếu
  $pres = new Presentation("demo.pptx");
  try {
    # Xóa một slide qua chỉ mục slide
    $pres->getSlides()->removeAt(0);
    # Lưu bản trình chiếu đã chỉnh sửa
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Xóa các slide bố cục không sử dụng**

Aspose.Slides cung cấp phương thức [removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/)) để cho phép bạn xóa các slide bố cục không mong muốn và không sử dụng. Đoạn mã PHP này cho bạn thấy cách xóa một slide bố cục khỏi bản trình chiếu PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa các slide mẫu không sử dụng**

Aspose.Slides cung cấp phương thức [removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (từ lớp [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/)) để cho phép bạn xóa các slide mẫu không mong muốn và không sử dụng. Đoạn mã PHP này cho bạn thấy cách xóa một slide mẫu khỏi bản trình chiếu PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Đi gì xảy ra với chỉ mục slide sau khi tôi xóa một slide?**

Sau khi xóa, [collection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) sẽ được đánh chỉ mục lại: mỗi slide sau sẽ dịch sang trái một vị trí, vì vậy các số chỉ mục trước trở nên lỗi thời. Nếu bạn cần một tham chiếu ổn định, hãy sử dụng ID cố định của mỗi slide thay vì chỉ mục của nó.

**ID của một slide có khác với chỉ mục của nó không, và nó có thay đổi khi các slide lân cận bị xóa không?**

Có. Chỉ mục là vị trí của slide và sẽ thay đổi khi slide được thêm hoặc xóa. ID slide là một định danh cố định và không thay đổi khi các slide khác bị xóa.

**Xóa một slide ảnh hưởng như thế nào đến các phần của slide?**

Nếu slide thuộc về một phần, phần đó sẽ chỉ còn ít hơn một slide. Cấu trúc phần vẫn giữ nguyên; nếu một phần trở nên rỗng, bạn có thể [xóa hoặc sắp xếp lại các phần](/slides/vi/php-java/slide-section/) khi cần.

**Đi gì xảy ra với ghi chú và bình luận gắn vào một slide khi nó bị xóa?**

[Notes](/slides/vi/php-java/presentation-notes/) và [comments](/slides/vi/php-java/presentation-comments/) được gắn vào slide cụ thể đó và sẽ bị xóa cùng với nó. Nội dung trên các slide khác không bị ảnh hưởng.

**Xóa slide khác như thế nào so với việc dọn dẹp các bố cục/mẫu không sử dụng?**

Xóa loại bỏ các slide bình thường cụ thể khỏi bộ slide. Dọn dẹp các bố cục/mẫu không sử dụng loại bỏ các slide bố cục hoặc mẫu mà không có gì tham chiếu, giảm kích thước tệp mà không thay đổi nội dung các slide còn lại. Hai hành động này bổ trợ cho nhau: thường thì xóa trước, sau đó dọn dẹp.