---
title: Quản lý Placeholder của Bản trình chiếu trong PHP
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/php-java/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- trình giữ chỗ nội dung
- văn bản gợi ý
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các placeholder văn bản, hình ảnh, biểu đồ và nội dung, đồng thời hiểu về kế thừa placeholder với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Một placeholder là một shape dành riêng vị trí cho một loại nội dung cụ thể trong mẫu bản trình chiếu. Các ví dụ phổ biến bao gồm placeholder tiêu đề, nội dung, hình ảnh, biểu đồ và placeholder nội dung đa mục đích. Không giống như một shape thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ một layout slide hoặc master slide.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [Shape::getPlaceholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getplaceholder/). Phương thức trả về một đối tượng [Placeholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholder/) hoặc `null` cho một shape bình thường. Sử dụng [Placeholder::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholder/gettype/) để xác định placeholder dự định chứa gì.

Lớp shape vẫn quan trọng sau khi bạn biết kiểu placeholder:

- Một placeholder trống cho văn bản, hình ảnh, biểu đồ hoặc nội dung thường được biểu diễn bằng một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/).
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [Placeholder::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholder/gettype/) và lớp shape tại thời gian chạy thay vì giả định rằng mọi placeholder đều là một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholder/gettype/) mô tả vai trò của một placeholder; nó không đảm bảo lớp shape tại thời gian chạy. Luôn luôn kiểm tra kiểu trước khi truy cập các thành viên văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện cụ thể.
{{% /alert %}}

## **Hiểu về Kế thừa Placeholder**

Placeholders tạo thành một hệ thống phân cấp:

1. Một master slide định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức master.
2. Một layout slide xác định bố cục được sử dụng cho một hoặc nhiều slide bình thường và có thể kế thừa từ master.
3. Một slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ layout của nó.

Gọi [Shape::getBasePlaceholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getbaseplaceholder/) để di chuyển lên một mức trong hệ thống này. Một slide placeholder thường trả về placeholder của layout; một layout placeholder có thể trả về placeholder của master. Phương thức trả về `null` khi shape không có base placeholder.

Ví dụ dưới đây liệt kê các placeholder trên slide đầu tiên và báo cáo base placeholder của chúng:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Chỉnh sửa một placeholder trên slide bình thường tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa layout hoặc master liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa thiết lập đó. Một shape bình thường cục bộ không có base placeholder và không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Thay đổi Văn bản trong Placeholder**

Placeholder tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và văn bản thường hỗ trợ văn bản. Kiểm tra xem đó có phải là [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) trước khi sử dụng phương thức [getTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/gettextframe/) của nó.

Ví dụ này cập nhật placeholder tiêu đề đầu tiên trên slide đầu tiên và lưu kết quả:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mô hình này tránh việc xử lý các placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện như các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/). Nó cũng xác định placeholder theo mục đích thay vì dựa vào một chỉ mục shape dễ hỏng.

## **Đặt Văn bản Gợi ý trên Layout**

Văn bản gợi ý là chỉ dẫn thời gian thiết kế hiển thị trong một placeholder trống, chẳng hạn như *Click to add title*. Đặt văn bản gợi ý tùy chỉnh trên placeholder của layout thay vì cố gắng truy cập nó qua bộ sưu tập shape của slide thường. Truy cập layout thông qua [Slide::getLayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getLayoutSlide) và lặp qua bộ sưu tập trả về bởi [BaseSlide::getShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getShapes).

Ví dụ sau thay đổi các gợi ý tiêu đề và phụ đề trên layout được sử dụng bởi slide đầu tiên:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Văn bản gợi ý không phải là nội dung slide bình thường. Nó dành cho các placeholder trống trong các ứng dụng chỉnh sửa như PowerPoint. Khi người dùng hoặc chương trình cung cấp nội dung thực, gợi ý sẽ không còn hiển thị. Thay đổi gợi ý cũng không thay thế văn bản hiện có trên các slide sử dụng layout đó.

## **Cập nhật Placeholder Hình ảnh**

Có hai trường hợp cần xử lý:

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/), thay thế hình ảnh qua [PictureFillFormat::getPicture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/getpicture/) và [SlidesPicture::setImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidespicture/setimage/).
- Nếu vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/) và loại bỏ placeholder trống.

Ví dụ tiếp theo hỗ trợ cả hai trường hợp và lưu bản trình chiếu:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [Shape::getPlaceholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getplaceholder/) không cung cấp setter. Nó giữ vị trí đã đặt nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ mối quan hệ placeholder là quan trọng, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt ảnh, cắt ảnh và các hiệu ứng đặc thù của hình ảnh, xem [Manage Picture Frames](/slides/vi/php-java/picture-frame/). Các thao tác này thuộc về picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/). Ví dụ này tìm một biểu đồ như vậy bằng cả kiểu placeholder và lớp runtime, thay đổi tiêu đề của nó và lưu file:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Một placeholder nội dung chung thường có [PlaceholderType::Object](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholdertype/). Trong PowerPoint, nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi đã được điền, kiểm tra lớp shape thực tế để biết nó chứa gì. Các layout chuyên biệt cũng có thể mở rộng [PlaceholderType::Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholdertype/), hoặc [PlaceholderType::Diagram](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholdertype/).

Aspose.Slides không chuyển một placeholder [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) trống thành một [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/) chỉ bằng cách thay đổi [Placeholder::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/placeholder/gettype/); kiểu không thể thay đổi qua lớp. Để điền một biểu đồ hoặc khu vực nội dung trống bằng chương trình, thêm đối tượng cần thiết tại tọa độ của placeholder rồi loại bỏ placeholder trống. Ví dụ sau thực hiện việc này cho một biểu đồ:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm vùng của placeholder nhưng không kế thừa từ placeholder của layout. Sử dụng các bài viết quản lý biểu đồ chuyên biệt [/slides/vi/php-java/powerpoint-charts/] khi bạn cần thay thế danh mục, series hoặc dữ liệu workbook của nó.

## **Ví dụ Hoàn chỉnh: Cập nhật Nội dung Văn bản hoặc Hình ảnh**

Ví dụ end‑to‑end dưới đây mở một mẫu, tìm placeholder tiêu đề hoặc hình ảnh trên slide đầu tiên, kiểm tra kiểu placeholder và shape, cập nhật nội dung phù hợp và lưu kết quả. Ví dụ cố ý tránh giả định chỉ mục shape hoặc xử lý mọi placeholder như cùng một lớp:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Base placeholder là gì?**

Base placeholder là shape tương ứng trên layout hoặc master mà một placeholder khác kế thừa. Sử dụng [Shape::getBasePlaceholder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getbaseplaceholder/) để lấy nó. Một shape cục bộ bình thường trả về `null` vì nó không thuộc phần của hệ thống placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa một layout placeholder không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, hãy lặp qua các slide và cập nhật từng placeholder tiêu đề.

**Làm thế nào để quản lý các placeholder ngày, số slide, tiêu đề và chân trang?**

Sử dụng các trình quản lý header và footer tại phạm vi slide, layout, master, notes hoặc handout thích hợp. Xem [Manage Presentation Header and Footer](/slides/vi/php-java/presentation-header-and-footer/) để có các ví dụ đầy đủ.