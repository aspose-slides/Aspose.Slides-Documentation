---
title: Thay đổi kích thước hình dạng trên các slide của bản trình chiếu trong PHP
type: docs
weight: 130
url: /vi/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
keywords:
  - thay đổi kích thước hình dạng
  - đổi kích thước hình dạng
  - PowerPoint
  - OpenDocument
  - bản trình chiếu
  - PHP
  - Aspose.Slides
description: "Dễ dàng thay đổi kích thước hình dạng trên các slide PowerPoint và OpenDocument bằng Aspose.Slides cho PHP thông qua Java—tự động điều chỉnh bố cục slide và nâng cao năng suất."
---
## **Tổng quan**

Khi bạn thay đổi kích thước slide của bài thuyết trình, bạn cũng có thể cần thay đổi kích thước và vị trí lại các hình dạng để phù hợp với kích thước mới. Bài viết này chỉ ra cách thu phóng các hình dạng theo cách thủ công và cách xử lý bảng trên slide, master và layout.

## **Thay đổi kích thước hình dạng**

Để giữ nguyên vị trí và kích thước tương đối của từng hình dạng, nhân các tọa độ ngang và độ rộng của nó với tỉ lệ giữa độ rộng slide mới và độ rộng gốc. Áp dụng tỉ lệ chiều cao tương ứng cho các tọa độ dọc và chiều cao của nó.

Ví dụ đầu tiên tải một bài thuyết trình mà các slide không chứa bảng, thay đổi kích thước slide thành A4 và lưu kết quả. Nó sử dụng [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) với [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) để vòng lặp tiếp theo điều khiển việc thu phóng. Các tỉ lệ không có đơn vị; vị trí và kích thước của hình dạng được đo bằng điểm. Các tỉ lệ chiều rộng và chiều cao khác nhau có thể làm biến dạng hình dạng, và việc thay đổi kích thước của một hình dạng không làm thu phóng kích thước phông chữ của nó.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Tính các hệ số thu phóng ngang và dọc độc lập.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Bảng cần được xử lý riêng: thu phóng độ rộng cột và chiều cao hàng thay vì gán toàn bộ độ rộng và chiều cao cho bảng. Chiều cao hàng có thể vẫn lớn hơn yêu cầu nếu nội dung ô đòi hỏi nhiều không gian hơn.
{{% /alert %}}

Ví dụ thứ hai hỗ trợ bảng và xử lý các hình dạng trên master và layout cũng như các slide riêng lẻ trước khi lưu bài thuyết trình đã thay đổi kích thước. Trợ giúp của nó xử lý từng [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) bằng cách thu phóng độ rộng cột với [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) và chiều cao tối thiểu của hàng với [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Sau đó nó thu phóng vị trí của bảng mà không thu phóng riêng các kích thước tổng thể của nó.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Kích thước bảng được kiểm soát bởi độ rộng cột và chiều cao hàng.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Tính các hệ số thu phóng ngang và dọc độc lập.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Thay đổi kích thước các hình dạng được định nghĩa trên master và layout cũng như các slide riêng lẻ.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Tại sao các hình dạng bị biến dạng hoặc bị cắt sau khi thay đổi kích thước slide?**

Nếu bạn thay đổi kích thước slide mà không thu phóng các hình dạng, chúng sẽ giữ vị trí và kích thước gốc và có thể vượt ra ngoài slide. Thu phóng chiều rộng và chiều cao bằng các tỉ lệ khác nhau cũng có thể làm biến dạng các hình dạng.

**Mã cung cấp có hoạt động cho mọi loại hình dạng không?**

Ví dụ đầu tiên thay đổi giới hạn của hình dạng trực tiếp và được thiết kế cho các slide không có bảng. Ví dụ thứ hai xử lý bảng riêng biệt. Kiểm tra bố cục kết quả, đặc biệt là văn bản và bảng, vì các ví dụ này không thu phóng kích thước phông chữ và nội dung bảng có thể hạn chế chiều cao hàng.

**Làm thế nào để thay đổi kích thước bảng khi thay đổi kích thước slide?**

Thu phóng độ rộng cột theo tỉ lệ chiều rộng và chiều cao tối thiểu của hàng theo tỉ lệ chiều cao, sau đó thu phóng vị trí của bảng, như được minh họa trong ví dụ thứ hai.

**Việc thay đổi kích thước này có hoạt động cho các master slide và layout slide không?**

Có. Ví dụ thứ hai duyệt qua [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) và các [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) của mỗi master và áp dụng cùng logic thay đổi kích thước cho các hình dạng của chúng.

**Tôi có thể thay đổi hướng của slide (dọc/ngang) cùng với việc thay đổi kích thước không?**

Có. Gọi [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) sau khi thay đổi kích thước slide và trước khi đọc các kích thước mục tiêu, để các hệ số thu phóng phản ánh hướng cuối cùng.

**Có giới hạn nào cho kích thước slide tôi có thể đặt không?**

Bạn có thể chỉ định kích thước slide tùy chỉnh bằng [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). Các kích thước hỗ trợ còn phụ thuộc vào định dạng bài thuyết trình và ứng dụng dùng để mở tệp.

**Làm thế nào để ngăn các hình dạng có tỷ lệ khung cố định bị biến dạng?**

Sử dụng cùng một hệ số thu phóng cho chiều rộng và chiều cao. Để vừa khớp bố cục gốc vào kích thước slide mới, sử dụng tỉ lệ nhỏ hơn giữa tỉ lệ chiều rộng và chiều cao cho cả hai kích thước và vị trí. Điều này giữ nguyên tỉ lệ nhưng có thể để lại khoảng trống không sử dụng ở một cạnh.