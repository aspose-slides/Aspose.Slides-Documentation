---
title: Quản lý các hình dạng trong bản trình chiếu bằng PHP
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/php-java/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- điểm điều chỉnh hình dạng
- điều chỉnh hình dạng preset
- hình học hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- chuyển hình dạng sang SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, sắp xếp lại, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides for PHP via Java biểu diễn các hình dạng trên một slide dưới dạng một ordered [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/). Bộ sưu tập này vừa là nơi bạn tìm và sửa đổi các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy và sửa đổi các điểm điều chỉnh đã được đặt trước, sau đó cho biết cách sao chép, xóa, ẩn và sắp xếp lại các hình dạng. Các phần cuối bao gồm định dạng cấp bố cục, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ độc lập, vì vậy bạn có thể chỉ sử dụng những thao tác cần thiết cho quy trình của mình.

## **Xác định và Tìm Kiếm Hình Dạng**

Chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp xếp lại một hình dạng có thể làm thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách bản trình bày được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getname/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng Chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy tắc đặt tên nếu code phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getalternativetext/) hữu ích khi mô tả khả năng truy cập hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được địa phương hoá hoặc viết lại cho khả năng truy cập, và cũng không được đảm bảo là duy nhất. Đừng tự ý sử dụng lại văn bản khả năng truy cập có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getofficeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Hãy dùng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng của nó.

Phương thức liên quan [Shape::getUniqueId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getuniqueid/) trả về một định danh có phạm vi bản trình bày, nhưng định danh này được dự định cho add‑in và có thể được gán lại. Nó không nên được coi là khóa ngoại lâu dài. Nếu nhận dạng lâu dài là quan trọng, hãy lưu ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Ví dụ sau tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Khi một thao tác đặc thù cho một loại hình dạng, hãy kiểm tra lớp runtime trước khi dùng các thành viên đặc thù cho loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng được đặt tên là một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Xác định và Sửa Đổi Các Điều Chỉnh Hình Dạng Được Đặt Trước**

Các hình dạng hình học được đặt trước có thể cung cấp các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ đọc [GeometryShape::getAdjustments](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometryshape/#getAdjustments). Bộ sưu tập này do hình dạng cung cấp, nhưng mỗi [AdjustValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục cố định. Lặp qua các điều chỉnh và kiểm tra phương thức chỉ đọc [AdjustValue::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/#getType), trong đó giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeadjustmenttype/) mô tả điều chỉnh điều khiển gì. Phương thức chỉ đọc [AdjustValue::getName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/getname/) cung cấp thông tin định danh bổ sung và đặc biệt hữu ích khi một preset chứa hơn một điều chỉnh có cùng kiểu ngữ nghĩa.

Sử dụng phương thức giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước góc tròn | [setRawValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Độ dày đuôi mũi tên | `setRawValue` |
| `ArrowheadLength` | Độ dài đầu mũi tên | `setRawValue` |
| `ArrowheadWidth` | Độ rộng đầu mũi tên | `setRawValue` |
| `StartAngle` | Góc bắt đầu của một phần tròn hoặc cung | [setAngleValue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Góc kết thúc của một phần tròn hoặc cung | `setAngleValue` |

`getType` và `getName` trả về thông tin chỉ đọc. `getRawValue` và `setRawValue` làm việc với một số nguyên trong đơn vị hình học gốc của preset, trong khi `getAngleValue` và `setAngleValue` làm việc với góc tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset [GeometryShape::getShapeType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometryshape/#getShapeType). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho một preset khác.

Khi `getType` trả về `ShapeAdjustmentType::Custom`, API không nhận ra ý nghĩa ngữ nghĩa chuẩn. Kiểm tra `getName`, loại preset và giá trị hiện có, và để nguyên điều chỉnh nếu không biết ý nghĩa và phạm vi dự kiến. Ngay cả với các kiểu đã được nhận diện, hãy kiểm tra xem cùng một kiểu có xuất hiện hơn một lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/php-java/connector/) minh hoạ trường hợp này với các điều chỉnh uốn cong connector.

Ví dụ đầy đủ sau tạo các phiên bản mặc định và đã chỉnh sửa của ba hình dạng preset. Nó lặp qua mọi điều chỉnh, báo cáo tên và kiểu, thay đổi các giá trị liên quan đến kích thước qua `setRawValue`, thay đổi góc qua `setAngleValue`, và lưu kết quả. Cột bên trái giữ hình học mặc định; cột bên phải hiển thị hình chữ nhật bo tròn đã điều chỉnh, mũi tên bốn chiều và phần tròn.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm tiêu đề cho các cột hình dạng mặc định và đã điều chỉnh.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kiểm tra kiểu ngữ nghĩa trước khi thay đổi giá trị làm cho code rõ ràng về mục đích và tránh giả định rằng một chỉ mục bộ sưu tập nhất định có cùng ý nghĩa trên các hình dạng preset khác nhau.

## **Sửa Đổi Bộ Sưu Tập Hình Dạng**

Các phương thức thêm, sao chép, xóa và sắp xếp lại hoạt động ngay trên bộ sưu tập. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước thao tác đó.

### **Sao Chép Một Hình Dạng**

[ShapeCollection::addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addclone/) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập đích. [ShapeCollection::insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/insertclone/) cũng tạo bản sao nhưng đặt nó tại một chỉ mục z‑order xác định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi trên bất kỳ bản sao nào cũng không ảnh hưởng đến hình dạng nguồn.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Việc sao chép sao chép nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được trình bày quản lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Hình Dạng**

[ShapeCollection::remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều đối tượng phù hợp trong quá trình lặp có chỉ mục, hãy duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng tại chỉ mục hiện tại, không phải một mục bộ sưu tập cố định, và không ép kiểu hình dạng một cách không cần thiết.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình dạng còn lại thay đổi. Tham chiếu tới các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng hãy xem xét các connector, animation và các tính năng khác có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn cả hình ảnh của slide.

### **Ẩn Một Hình Dạng**

Thiết lập [Shape::setHidden](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/sethidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong chế độ trình chiếu thông thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho code, vì vậy ẩn phù hợp cho các yếu tố tùy chọn có thể được khôi phục sau.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc code khám phá và hiển thị lại, và nó vẫn là một phần của tệp bản trình bày.

### **Thay Đổi Thứ Tự Z**

Các hình dạng chồng lên nhau được vẽ theo thứ tự bộ sưu tập. [ShapeCollection::reorder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/reorder/) di chuyển một hình dạng hiện có đến một chỉ mục đích mà không sao chép. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện thứ tự Z sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ thêm hoặc chèn các mục mới vào bộ sưu tập và có thể làm thay đổi ngăn xếp dự kiến.

## **Kiểm Tra Các Hình Dạng Trên Slide Bố Cục**

Slide thường, slide bố cục và slide master có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng nằm ở vị trí tương tự trên một slide thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do bố cục cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getfillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getlineformat/) của mỗi hình dạng bố cục mà không giả định rằng mọi hình dạng đều là `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Chỉnh sửa một bố cục có thể ảnh hưởng đến nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố cục, hãy xác định liệu một slide thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và kiểm tra mọi slide sử dụng bố cục đó.

## **Xuất Hình Dạng Thành SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/) ghi nội dung đã render của một hình dạng vào một stream. Kết quả chứa chỉ hình dạng, không phải toàn bộ nền slide hay các hình dạng lân cận.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Giữ bản trình bày mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ thành phần, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu stream và phải đóng nó.

## **Căn Chỉnh Các Hình Dạng**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/alignshapes/) có các overload căn chỉnh toàn bộ hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapesalignmenttype/) chỉ định cạnh, đường trung tâm hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng được trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Căn chỉnh thay đổi vị trí, không phải thứ tự Z. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn thay đổi bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `getFlipH` và `getFlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/php-java/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` bảo lưu trạng thái chưa xác định/mặc định.

Bản trình bày nhập dưới đây chứa một hình dạng chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị frame khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì việc gán một [Frame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/setframe/) mới sẽ thay thế toàn bộ frame.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hình dạng đã lưu được lật ngược ngang và dọc trong khi giữ nguyên vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **Câu hỏi thường gặp**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh cho một hình dạng không?**

Chỉ nên khi xử lý ngắn hạn và bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên quy tắc `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Ẩn một hình dạng có làm nó mất khỏi thứ tự Z không?**

Không. Một hình dạng ẩn vẫn ở trong bộ sưu tập tại cùng chỉ mục. Nó có thể được tìm thấy, sắp xếp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng được sao chép lại xuất hiện trước một hình dạng khác?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước trong thứ tự Z. Hãy dùng `insertClone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi tất cả các hình dạng đã được thêm.

**Có thể dùng chỉ mục cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ được sau khi xác thực preset và bố cục bộ sưu tập chính xác. Ưu tiên lặp qua `GeometryShape::getAdjustments` và kiểm tra `AdjustValue::getType`; dùng `AdjustValue::getName` làm thông tin bổ trợ khi cùng một kiểu ngữ nghĩa xuất hiện hơn một lần.