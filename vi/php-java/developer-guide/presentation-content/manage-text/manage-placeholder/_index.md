---
title: Quản lý các placeholder của bản trình chiếu trong PHP
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/php-java/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- văn bản gợi ý
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý các placeholder trong Aspose.Slides cho PHP qua Java một cách dễ dàng: thay thế văn bản, tùy chỉnh văn bản gợi ý và thiết lập độ trong suốt của hình ảnh trong PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các placeholder trong bản trình chiếu một cách lập trình. Bài viết này giải thích cách tìm placeholder trên các slide và thay đổi văn bản của chúng, đặt văn bản gợi ý tùy chỉnh cho các layout placeholder, và điều chỉnh độ trong suốt của hình ảnh được dùng làm nền cho placeholder. Nó cũng bao gồm một phần Hỏi‑Đáp ngắn gọn giải thích sự khác biệt giữa base placeholder và local shape, mô tả cách áp dụng các thay đổi placeholder thông qua layout hoặc master, và chỉ dẫn cách quản lý placeholder tiêu đề và chân trang.

## **Thay đổi Văn bản trong Placeholder**
Sử dụng [Aspose.Slides for PHP via Java](/slides/vi/php-java/), bạn có thể tìm và chỉnh sửa các placeholder trên các slide trong bản trình chiếu. Aspose.Slides cho phép bạn thay đổi văn bản trong một placeholder.

**Tiền đề**: Bạn cần một bản trình chiếu có chứa placeholder. Bạn có thể tạo bản trình chiếu như vậy bằng ứng dụng Microsoft PowerPoint tiêu chuẩn.

Đây là cách bạn sử dụng Aspose.Slides để thay thế văn bản trong placeholder của bản trình chiếu đó:

1. Khởi tạo lớp [`Presentation`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) và truyền đường dẫn tới bản trình chiếu làm tham số.
2. Lấy tham chiếu tới một slide thông qua chỉ số của nó.
3. Duyệt qua các shape để tìm placeholder.
4. Ép kiểu shape placeholder thành một [`AutoShape`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/AutoShape) và thay đổi văn bản bằng [`TextFrame`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/TextFrame) liên kết với [`AutoShape`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/AutoShape).
5. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã PHP sau cho thấy cách thay đổi văn bản trong một placeholder:

```php
  # Tạo một đối tượng lớp Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Truy cập slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Duyệt qua các shape để tìm placeholder
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Thay đổi văn bản trong mỗi placeholder
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Lưu bản trình chiếu vào đĩa
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt Văn bản Gợi ý trong Placeholder**
Các layout tiêu chuẩn và đã được xây dựng sẵn chứa các văn bản gợi ý placeholder như ***Click to add a title*** hoặc ***Click to add a subtitle***. Sử dụng Aspose.Slides, bạn có thể chèn các văn bản gợi ý tùy chỉnh của mình vào các layout placeholder.

Đoạn mã PHP dưới đây cho thấy cách đặt văn bản gợi ý trong một placeholder:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Duyệt qua slide
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint hiển thị "Click to add title"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Thêm phụ đề
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Đặt Độ Trong Suất Hình Ảnh Placeholder**

Aspose.Slides cho phép bạn đặt độ trong suốt của hình ảnh nền trong một placeholder văn bản. Bằng cách điều chỉnh độ trong suốt của hình ảnh trong khung này, bạn có thể làm cho văn bản hoặc hình ảnh nổi bật hơn (tùy thuộc vào màu sắc của văn bản và hình ảnh).

Đoạn mã PHP sau minh họa cách đặt độ trong suốt cho nền hình ảnh (trong một shape):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Base placeholder là gì và nó khác gì so với local shape trên slide?**

Base placeholder là shape gốc trên một layout hoặc master mà shape của slide kế thừa—loại, vị trí và một số định dạng được lấy từ nó. Local shape là độc lập; nếu không có base placeholder, việc kế thừa sẽ không áp dụng.

**Làm sao cập nhật tất cả tiêu đề hoặc chú thích trên toàn bộ bản trình chiếu mà không phải duyệt từng slide?**

Chỉnh sửa placeholder tương ứng trên layout hoặc master. Các slide dựa trên những layout/ master đó sẽ tự động kế thừa thay đổi.

**Làm thế nào kiểm soát các placeholder tiêu đề/chân trang tiêu chuẩn—ngày & giờ, số slide và văn bản chân trang?**

Sử dụng các trình quản lý HeaderFooter ở mức phạm vi thích hợp (slide bình thường, layout, master, ghi chú/handout) để bật hoặc tắt các placeholder này và đặt nội dung cho chúng.