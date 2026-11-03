---
title: Quản lý trình giữ chỗ trong bản trình chiếu bằng PHP
linktitle: Quản lý trình giữ chỗ
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
description: "Tìm hiểu cách kiểm tra và chỉnh sửa các trình giữ chỗ văn bản, hình ảnh, biểu đồ và nội dung, cũng như hiểu cách kế thừa trình giữ chỗ với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Placeholder là một hình dạng dành chỗ cho một loại nội dung cụ thể trong mẫu trình chiếu. Các ví dụ phổ biến là placeholder tiêu đề, nội dung, hình ảnh, biểu đồ và placeholder nội dung đa năng. Không giống như một hình dạng thông thường, placeholder có thể kế thừa vị trí, kích thước, định dạng và các thiết lập khác từ slide bố cục hoặc slide master.

Aspose.Slides cung cấp thông tin placeholder thông qua phương thức [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) . Phương thức này trả về một đối tượng [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) hoặc `null` cho một hình dạng bình thường. Sử dụng [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) để xác định placeholder dự định chứa gì.

Lớp hình dạng vẫn quan trọng sau khi bạn biết loại placeholder:

- Một placeholder trống cho văn bản, hình ảnh, biểu đồ hoặc nội dung thường được biểu diễn bằng một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Một placeholder hình ảnh đã được điền có thể được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/).
- Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/).
- Một placeholder nội dung có thể chứa nhiều loại nội dung. Kiểm tra cả [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) và lớp hình dạng tại thời gian chạy thay vì giả định mọi placeholder đều là một [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) mô tả vai trò của placeholder; nó không đảm bảo lớp hình dạng tại thời gian chạy. Luôn luôn kiểm tra kiểu trước khi truy cập các thành viên văn bản, hình ảnh, biểu đồ, bảng hoặc phương tiện.
{{% /alert %}}

## **Hiểu về kế thừa Placeholder**

Placeholder tạo thành một cây phân cấp:

1. Slide master định nghĩa các kiểu có thể tái sử dụng và, trong một số trường hợp, các placeholder ở mức master.
2. Slide layout định nghĩa cách sắp xếp được sử dụng cho một hoặc nhiều slide bình thường và có thể kế thừa từ master.
3. Slide bình thường chứa các placeholder cho slide đó và có thể kế thừa từ layout của nó.

Gọi [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) để di chuyển lên một cấp trong cây phân cấp này. Placeholder của slide thường trả về placeholder của layout; placeholder của layout có thể trả về placeholder của master. Phương thức trả về `null` khi hình dạng không có placeholder cơ sở.

Ví dụ sau liệt kê các placeholder trên slide đầu tiên và báo cáo placeholder cơ sở của chúng:

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

Chỉnh sửa một placeholder trên slide bình thường sẽ tạo hoặc thay đổi một ghi đè cục bộ cho slide đó. Chỉnh sửa layout hoặc master liên quan có thể ảnh hưởng đến tất cả các slide vẫn kế thừa thiết lập đó. Một hình dạng bình thường cục bộ không có placeholder cơ sở và sẽ không bắt đầu kế thừa chỉ vì nó chiếm cùng tọa độ.

## **Xóa trạng thái Placeholder**

Khi điều chỉnh một mẫu, sử dụng [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) để giữ một đối tượng hiện có như một hình dạng bình thường. Phương thức [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) của nó trả về `null`, nhưng hình dạng vẫn còn trong bộ sưu tập của slide. Ngược lại, [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) xóa hình dạng khỏi bộ sưu tập đó.

Ví dụ sau yêu cầu file `template.pptx` có ít nhất một slide và một placeholder văn bản không rỗng trên slide đầu tiên. Sử dụng một placeholder với định dạng được kế thừa từ layout hoặc master để xem hiệu quả của việc xóa quan hệ đó. Ví dụ kiểm tra rằng cùng một hình dạng vẫn còn, gọi lại phương thức trên hình dạng đã trở thành bình thường, và lưu kết quả.

{{% alert color="warning" title="Warning" %}}
Việc xóa trạng thái placeholder không tự động giữ các thiết lập hiển thị được kế thừa. Ví dụ dưới đây cố ý để các thiết lập đó không thay đổi, vì vậy đầu ra có thể trông khác. Một hình dạng mà vị trí và kích thước hoàn toàn được kế thừa có thể có tọa độ và kích thước bằng không sau khi gọi và trở nên ẩn mặc dù vẫn còn trong bộ sưu tập.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Gọi phương thức trên một hình dạng thường không có ảnh hưởng.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Đối với một placeholder phù hợp, cả ba kiểm tra đều in ra `true`. Văn bản vẫn còn, nhưng vị trí, kích thước, xoay, phông chữ, căn đoạn, lề khung văn bản, neo dọc, màu nền và thiết lập đường viền được kế thừa có thể thay đổi khi quan hệ placeholder bị xóa. Ví dụ, định dạng tiêu đề được kế thừa có thể quay lại định dạng văn bản thông thường. Xem [Slide Layout](/slides/vi/php-java/slide-layout/) để biết thêm về các layout.

Để giữ nguyên giao diện mong muốn, hãy ghi lại vị trí, kích thước và góc quay đã được giải quyết trước khi gọi, và sao chép các giá trị định dạng hiệu quả cần thiết vào các biến riêng. Lấy các giá trị đó thông qua [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/), và [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/). Không nên chỉ dựa vào việc giữ lại các đối tượng định dạng hiệu quả, vì các giá trị định dạng văn bản của chúng có thể thay đổi sau khi quan hệ bị xóa. Áp dụng một cách rõ ràng các giá trị đã ghi lại cho hình dạng bình thường sau đó, bao gồm họ phông chữ, kích thước, kiểu, màu, thiết lập đoạn, thiết lập khung văn bản, màu nền và đường viền được mẫu của bạn sử dụng.

Hình học của hình dạng được kế thừa cũng có thể cần được gán một cách rõ ràng thông qua [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType). Đối với placeholder văn bản dạng hình chữ nhật, điều này có nghĩa là gán [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/); chỉ khôi phục màu nền và đường viền có thể không khôi phục lại hình chữ nhật hiển thị. Các mẫu có hiệu ứng bổ sung hoặc định dạng phức tạp hơn cũng cần xử lý các thiết lập đó.

## **Thay đổi Văn bản trong Placeholder**

Các placeholder tiêu đề, tiêu đề trung tâm, phụ đề, nội dung và văn bản thường hỗ trợ văn bản. Kiểm tra xem có phải là [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) trước khi sử dụng phương thức [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) .

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

Mẫu này tránh việc đối xử với placeholder hình ảnh, biểu đồ, bảng hoặc phương tiện như các đối tượng [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) . Nó cũng xác định placeholder theo mục đích thay vì dựa vào chỉ số hình dạng dễ phá vỡ.

## **Đặt Văn bản Gợi ý trên Layout**

Văn bản gợi ý là chỉ thị thời gian thiết kế hiển thị trong một placeholder trống, chẳng hạn *Click to add title*. Đặt văn bản gợi ý tùy chỉnh trên placeholder của layout thay vì cố gắng truy cập qua bộ sưu tập hình dạng của slide bình thường. Truy cập layout thông qua [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) và lặp qua bộ sưu tập trả về bởi [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) .

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

- Nếu placeholder hình ảnh đã được điền và được biểu diễn bằng một [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), thay thế hình ảnh qua [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) và [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) .
- Nếu nó vẫn là một placeholder trống, thêm một picture frame tại tọa độ của placeholder bằng [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) và xóa placeholder trống.

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

Việc thay thế được tạo cho một placeholder trống là một picture frame cục bộ, không phải một placeholder mới, vì [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) không cung cấp setter. Nó giữ vị trí đã dành nhưng không còn kế thừa hành vi đặc thù của placeholder. Nếu việc giữ quan hệ placeholder là quan trọng, hãy chuẩn bị và điền placeholder trong PowerPoint trước, sau đó cập nhật [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) kết quả bằng Aspose.Slides.

Đối với độ trong suốt hình ảnh, cắt ảnh và các hiệu ứng đặc thù của hình ảnh, xem [Manage Picture Frames](/slides/vi/php-java/picture-frame/). Những thao tác này thuộc về picture frame hoặc picture fill, không phải metadata của placeholder.

## **Làm việc với Placeholder Biểu đồ và Nội dung**

Một placeholder biểu đồ đã được điền có thể được biểu diễn bằng một [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/). Ví dụ này tìm biểu đồ như vậy bằng cả loại placeholder và lớp thời gian chạy, thay đổi tiêu đề và lưu file:

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

Một placeholder nội dung chung thường có [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). Trong PowerPoint nó hoạt động như một trình khởi chạy cho nhiều loại nội dung, bao gồm biểu đồ, bảng, sơ đồ, hình ảnh và phương tiện. Sau khi được điền, kiểm tra lớp hình dạng thực tế để biết nó chứa gì. Các layout chuyên biệt cũng có thể hiển thị [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), hoặc [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) .

Aspose.Slides không chuyển một placeholder [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) trống thành một [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) chỉ bằng cách thay đổi [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) ; loại không thể thay đổi qua lớp. Để điền một biểu đồ hoặc khu vực nội dung trống một cách lập trình, thêm đối tượng cần thiết tại tọa độ của placeholder và sau đó xóa placeholder trống. Ví dụ sau thực hiện điều này cho một biểu đồ:

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

Biểu đồ được thêm là một biểu đồ cục bộ thông thường. Nó chiếm khu vực của placeholder nhưng không kế thừa từ placeholder của layout. Sử dụng các [chart management articles](/slides/vi/php-java/powerpoint-charts/) khi bạn cần thay thế các danh mục, series hoặc dữ liệu workbook của nó.

## **Ví dụ Hoàn chỉnh: Cập nhật Văn bản hoặc Nội dung Hình ảnh**

Ví dụ toàn diện sau mở một mẫu, tìm kiếm slide đầu tiên cho một placeholder tiêu đề hoặc hình ảnh, kiểm tra các loại placeholder và hình dạng, cập nhật nội dung phù hợp, và lưu kết quả. Ví dụ này cố ý tránh giả định chỉ số hình dạng hoặc đối xử mọi placeholder như cùng một lớp.

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

**Placeholder cơ sở là gì?**

Placeholder cơ sở là hình dạng tương ứng trên layout hoặc master mà từ đó một placeholder khác kế thừa. Sử dụng [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) để lấy nó. Một hình dạng bình thường cục bộ trả về `null` vì nó không thuộc phần của cây placeholder.

**Tôi có thể thay đổi tất cả tiêu đề slide bằng cách chỉnh sửa một placeholder layout không?**

Bạn có thể thay đổi định dạng kế thừa hoặc văn bản gợi ý qua layout, nhưng nội dung tiêu đề hiện có được lưu trên các slide bình thường. Để thay thế văn bản tiêu đề thực tế trên toàn bộ bản trình chiếu, hãy lặp qua các slide và cập nhật mỗi placeholder tiêu đề.

**Làm thế nào để quản lý các placeholder ngày, số slide, header và footer?**

Sử dụng các trình quản lý header và footer ở phạm vi slide, layout, master, notes hoặc handout thích hợp. Xem [Manage Presentation Header and Footer](/slides/vi/php-java/presentation-header-and-footer/) để có các ví dụ hoàn chỉnh.