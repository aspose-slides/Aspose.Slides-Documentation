---
title: Quản lý các Hình trong Bài thuyết trình bằng PHP
linktitle: Thao tác Hình
type: docs
weight: 40
url: /vi/php-java/shape-manipulations/
keywords:
- hình PowerPoint
- hình trong bài thuyết trình
- hình trên slide
- tìm hình
- sao chép hình
- xóa hình
- ẩn hình
- thay đổi thứ tự hình
- lấy ID hình interop
- văn bản thay thế của hình
- định dạng layout của hình
- hình dưới dạng SVG
- hình thành SVG
- căn chỉnh hình
- lật hình
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách xác định, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình trong bài thuyết trình với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides for PHP via Java đại diện cho các hình trên một slide dưới dạng một [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình ở phía sau nhất, trong khi chỉ mục cuối cùng là hình ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình một cách đáng tin cậy, sau đó minh họa cách sao chép, xóa, ẩn và thay đổi thứ tự các hình. Các phần cuối cùng đề cập đến định dạng ở cấp layout, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình của bạn cần.

## **Xác định và Tìm Kiếm Hình**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc thay đổi thứ tự một hình có thể làm thay đổi chỉ mục của nó. Chọn một định danh dựa trên cách bài thuyết trình được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getname/) hữu ích cho các mẫu được kiểm soát bởi nhà phát triển và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã của bạn phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getalternativetext/) hữu ích khi một mô tả truy cập hoặc một thẻ do tác giả cung cấp đã xác định hình. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho mục đích truy cập, và không được đảm bảo là duy nhất. Đừng lặng lẽ tái sử dụng văn bản truy cập có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getofficeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình được sử dụng bởi PowerPoint interop. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt thời gian tồn tại của một hình. Một hình được sao chép hoặc tạo lại là một hình khác và sẽ nhận ID riêng.

Phương thức [Shape::getUniqueId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getuniqueid/) liên quan trả về một định danh có phạm vi toàn bài thuyết trình, nhưng định danh đó dành cho add-in và có thể được gán lại. Nó không nên được coi là khóa ngoại lâu dài. Nếu cần duy trì danh tính lâu dài, hãy lưu ánh xạ trong dữ liệu ứng dụng và xác minh rằng hình mong đợi vẫn còn tồn tại.

Ví dụ sau tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop ở cấp slide. Khi mẫu không chứa hình mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác cụ thể đối với một loại hình, hãy kiểm tra lớp thực thi trước khi sử dụng các thành viên đặc thù. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ nếu đối tượng có tên là một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).

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

## **Sửa Đổi Bộ Sưu Tập Hình**

Các phương thức thêm, sao chép, xóa và thay đổi thứ tự hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình, đừng tiếp tục dựa vào các chỉ mục đã lấy trước khi thực hiện thao tác đó.

### **Sao chép một Hình**

[ShapeCollection::addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addclone/) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập mục tiêu. [ShapeCollection::insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó ở một chỉ mục z‑order xác định. Các overload chấp nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao có thể thay đổi kích thước đồng thời.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi đối với bất kỳ bản sao nào cũng không làm ảnh hưởng đến hình nguồn.

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

Sao chép bao gồm nội dung và định dạng của hình, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được sử dụng bởi các hình phức tạp được trình chiếu xử lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với định danh hình mới.

### **Xóa Hình**

[ShapeCollection::remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/remove/) xóa một đối tượng hình cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả khớp trong quá trình lặp có chỉ mục, hãy duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình có tên được chỉ định. Nó đọc hình ở chỉ mục hiện tại, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình một cách không cần thiết.

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

Sau khi xóa, số lượng hình và chỉ mục của các hình sau thay đổi. Tham chiếu tới các hình không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng nên xem xét các connector, animation và các tính năng trình chiếu khác có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình hiển thị có thể thay đổi hơn cả giao diện slide.

### **Ẩn một Hình**

Đặt [Shape::setHidden](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/sethidden/) thành `true` giữ hình trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi chiếu thông thường. Chỉ mục, định dạng và nội dung của nó vẫn có sẵn cho mã, vì vậy ẩn phù hợp cho các thành phần tùy chọn có thể được khôi phục sau này.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và hủy ẩn, và nó vẫn là một phần của tệp trình chiếu.

### **Thay đổi Z‑Order**

Các hình chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [ShapeCollection::reorder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/reorder/) di chuyển một hình hiện có tới một chỉ mục mục tiêu mà không sao chép nó. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

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

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau hình elip. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện z‑order sau khi thêm hoặc sao chép tất cả các hình liên quan, vì các thao tác đó thêm hoặc chèn các mục mới vào bộ sưu tập và có thể làm thay đổi cấu trúc ngăn xếp đã định.

## **Kiểm Tra Các Hình trên Slide Layout**

Slide bình thường, slide layout và master slide có các bộ sưu tập hình riêng biệt. Một hình trong bộ sưu tập layout không phải là cùng một đối tượng với một hình cùng vị trí trên slide bình thường. Kiểm tra các hình layout khi bạn cần hiểu hoặc thay đổi định dạng do layout cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getfillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getlineformat/) của mỗi hình trong layout mà không giả định mọi hình đều là `AutoShape`.

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

Việc chỉnh sửa một layout có thể ảnh hưởng đến nhiều slide sử dụng nó. Trước khi thay đổi một hình trong layout, xác định xem một slide bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và kiểm tra mọi slide dùng layout đó.

## **Xuất Hình ra SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/) ghi nội dung đã render của một hình vào một stream. Kết quả chứa hình, không phải toàn bộ nền slide hay các hình lân cận.

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

Giữ trình chiếu mở khi render. Đầu ra phụ thuộc vào định dạng của hình và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình riêng lẻ. Người gọi sở hữu stream và phải đóng nó.

## **Căn chỉnh Hình**

Các overload của [SlideUtil::alignShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/alignshapes/) căn chỉnh toàn bộ hình hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân bố. Đặt `alignToSlide` thành `true` để căn chỉnh theo các cạnh slide; đặt `false` để căn chỉnh các hình đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình tới cạnh trên của slide. Các tham chiếu hình trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không phải z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình, trong khi phân bố ngang hoặc dọc cần đủ hình để xác định khoảng cách. Tính lại chỉ mục nếu bạn thay đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `getFlipH` và `getFlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/php-java/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái chưa xác định/mặc định.

Bản trình chiếu đầu vào bên dưới chứa một hình chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị frame khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/setframe/) mới sẽ thay thế toàn bộ frame.

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

Hình đã lưu được lật ngang và dọc trong khi vẫn giữ vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **Câu Hỏi Thường Gặp**

**Có nên dùng chỉ mục bộ sưu tập làm định danh cho một hình không?**

Chỉ nên dùng trong các quy trình ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo sẵn, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Ẩn một hình có loại bỏ nó khỏi z‑order không?**

Không. Một hình ẩn vẫn ở trong bộ sưu tập với cùng chỉ mục. Nó vẫn có thể được tìm, thay đổi thứ tự, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình được sao chép lại xuất hiện phía trước một hình khác?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước của z‑order. Dùng `insertClone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi đã thêm tất cả các hình.