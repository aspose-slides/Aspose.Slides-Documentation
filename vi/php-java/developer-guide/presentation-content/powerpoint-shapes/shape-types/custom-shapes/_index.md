---
title: Tùy chỉnh các hình dạng trong bài thuyết trình bằng PHP
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/php-java/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình
- tạo hình
- thay đổi hình
- hình học hình dạng
- đường dẫn hình học
- điểm đường dẫn
- chỉnh sửa điểm
- thêm điểm
- xóa điểm
- thao tác chỉnh sửa
- góc cong
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bài thuyết trình PowerPoint bằng Aspose.Slides cho PHP thông qua Java: đường dẫn hình học, góc cong, hình dạng hỗn hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bài thuyết trình bằng Aspose.Slides bằng cách chỉnh sửa hình học của hình thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình.

Nó cũng minh họa cách tạo các hình dạng tùy chỉnh và phức hợp, xây dựng các hình có góc cong, xác định liệu hình học của một hình có được đóng hay không, kiểm tra các phần tử của hình, và chuyển đổi các đường viền văn bản Java AWT thành các đường dẫn hình học.

## **Thay đổi một Hình bằng các Điểm Chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Việc chỉnh sửa các điểm cho phép bạn thay đổi đường viền của một hình hoặc sử dụng một hình hiện có làm cơ sở để tạo hình mới.

## **Mẹo Chỉnh sửa Hình**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình trong PowerPoint, hãy ghi nhớ các khái niệm sau:

* Một hình (hoặc đường dẫn của nó) có thể là **đóng** hoặc **mở**.
* Đường dẫn của một hình bao gồm các điểm neo được nối bằng các đoạn.
* Một đoạn có thể là thẳng hoặc cong. Các điểm neo và tay cầm điều khiển quyết định hình dạng của đoạn.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Tại một điểm góc, các đoạn liền kề có thể gặp nhau ở một góc.
  * Tại một điểm mượt, hai tay cầm điều khiển được căn thẳng và cách đều điểm neo.
  * Tại một điểm thẳng, hai tay cầm điều khiển được căn thẳng nhưng có thể có khoảng cách khác nhau tới điểm neo.
* Di chuyển các điểm neo hoặc điều chỉnh tay cầm của chúng sẽ thay đổi đường viền của hình.

Để chỉnh sửa các hình PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Một đối tượng [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) đại diện cho đường dẫn hình học của đối tượng [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) từ một thể hiện [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), bạn có thể sử dụng phương thức [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) cho một hình, bạn có thể sử dụng các phương thức: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) cho các hình có một đường và [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) cho các hình có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới lớp [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Bằng cách sử dụng các phương thức [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) và [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), bạn có thể đặt kiểu hiển thị cho một đường dẫn hình học.
* Bằng cách sử dụng phương thức [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) dưới dạng mảng các đoạn đường.
* Để truy cập các tùy chọn tùy chỉnh hình học bổ sung, bạn có thể đọc một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) thông qua [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) và phát lại các đoạn trên một [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Các Thao tác Chỉnh sửa Cơ bản**

Sử dụng các phương thức sau để chỉnh sửa một đường dẫn hình học. Các phương thức quá tải nhận một chỉ mục sẽ chèn một đoạn tại vị trí chỉ mục không dựa trên 0 trong mảng các đoạn của đường.

| Hoạt động | Phương thức |
| --- | --- |
| Thêm hoặc chèn một đoạn thẳng. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Thêm một cung elliptic với kích thước và góc đã chỉ định tính bằng độ. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Đóng hình hiện tại bằng cách nối điểm cuối với điểm bắt đầu. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Xóa một đoạn tại chỉ mục không dựa trên 0. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Thêm Các Điểm Tùy chỉnh vào Hình**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) và áp dụng đường đã chỉnh sửa với [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Các tọa độ là nội bộ đối với hình: cả hai điểm mới đều nằm ở trung tâm, cách trái 100 điểm và cách trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Xóa Các Điểm khỏi Hình**

Ví dụ này thay đổi đường viền hình trái tim bằng cách xóa đoạn tại chỉ mục không dựa trên 0 là 2 bằng [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Áp dụng đường đã sửa đổi bằng [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) sẽ cập nhật đường viền của hình.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Tạo một Hình Tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm cánh bằng [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ là 100 và 50 điểm, xác định các đầu nhọn và các khe vào; bước 72 độ phân bố đều năm đầu nhọn. Đường được đóng bằng [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) và áp dụng cho một hình chữ nhật bằng [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), thay thế đường viền của nó.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Tạo một Hình Tùy chỉnh Phức hợp**

Ví dụ này định nghĩa hai đối tượng [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) đóng cho phần trên và phần dưới của một hình. Áp dụng cả hai đường bằng [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) tạo ra một hình phức hợp duy nhất với một khoảng trống ở đoạn giữa.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Tạo một Hình Tùy chỉnh với Các Góc Cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) để tạo một hình có các góc cong vào trong. Mỗi kích thước góc đặt độ rộng và chiều cao của cung tính bằng điểm, và góc quét -90 độ vẽ một phần tư ellipse ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), và bài thuyết trình được lưu ở định dạng PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Xác định Hình Học Của Hình Có Được Đóng Hay Không**

Trợ giúp sau kiểm tra xem mọi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) và so sánh lệnh của đoạn cuối cùng [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) với [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường nào không rỗng. Kiểm tra này chỉ xem lệnh cuối của mỗi đường; nó không kiểm tra mọi tiểu hình trong một đường. Ví dụ in ra `true` cho một hình chữ nhật.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Kiểm tra Các Lệnh Đường Hình Học**

Tải xuống [contour.pptx](contour.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Hình đầu tiên trên slide đầu tiên có cạnh trên thẳng, một đường cong Bézier bậc ba và một cạnh đóng thẳng. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) để đọc các đường của hình và [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) để đọc các đoạn của mỗi đường theo thứ tự vẽ. Đối với mỗi đoạn, [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) xác định lệnh và quyết định cách diễn giải các giá trị trả về bởi [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

Hình nằm tại (200, 100) điểm trên slide. Các tọa độ được báo cáo là nội bộ đối với hình, với (0, 0) ở góc trên‑trái, x tăng sang phải và y tăng xuống. Đoạn đóng trả về điểm bắt đầu mà không có tọa độ bổ sung.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Trích xuất và Kiểm tra Các Thành phần Hình**

Sử dụng [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) để kiểm tra một hình hiện có dưới dạng các thành phần chứa các điểm đường và kiểu điểm. Sử dụng từng [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) trả về để lấy các mảng điểm và kiểu qua các phương thức [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) và [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Đại diện này hữu ích cho việc phân tích đường viền hoặc truyền hình học cho các công cụ vẽ tùy chỉnh.

Ví dụ mở file input.pptx, tìm shape hình học đầu tiên trực tiếp trên slide đầu tiên, và in ra các đoạn đường của nó. Sử dụng một bài thuyết trình có một hình với các đoạn thẳng và cong để xem cả hai dạng đầu ra. Nó không tìm kiếm bên trong các nhóm.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Giữ lại kiểu đoạn, loại trừ các cờ.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Tiêu thụ cả hai điểm điều khiển và điểm cuối.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Các mảng tương ứng theo chỉ mục: `$points[$i]` là một điểm và `$types[$i]` mô tả vai trò của nó. Kiểu `0` bắt đầu một hình, và kiểu `1` vẽ một đường từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu ở điểm cuối trước và sử dụng ba mục kiểu `3` liên tiếp: hai điểm điều khiển và sau đó điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để biết đóng hay không.

Kiểu điểm cũng chứa các cờ. Hãy dùng mặt nạ `0x07` để xác định kiểu đoạn, và kiểm tra `0x80` riêng biệt để phát hiện một tiểu đường đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối của đoạn thẳng đóng một tiểu đường, và `131` (`0x83`) có nghĩa là một điểm cuối của đoạn Bézier đóng một tiểu đường. Java/PHP Bridge trả về mảng byte dưới dạng chuỗi nhị phân; việc giải nén bằng `"C*"` tạo ra các giá trị byte không dấu. Áp dụng mặt nạ bảo toàn các bit mong muốn. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ lỡ các trường hợp này. Các cờ khác, như dấu gạch (`0x10`) và ký hiệu (`0x20`), không thay đổi kiểu đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng điểm (1/72 inch), với X tăng sang phải và Y tăng xuống. Đối với một hình không thuộc nhóm, các tọa độ đã trích xuất đã bao gồm vị trí trả về bởi [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) và [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) và phản ánh chiều rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không quay tại `(100, 200)` với kích thước `120 × 80` có giới hạn đường viền `(100, 200)`–`(220, 280)`. Không cần cộng lại vị trí của hình một lần nữa. Trừ X và Y để có tọa độ tương đối với khung không quay của nó.

Các điểm đã trích xuất không áp dụng phép quay của hình, trả về bởi [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), hoặc lật ngang và dọc. Để tái tạo đường viền hiển thị, hãy áp dụng các biến đổi này quanh trung tâm của hình. Đối với các hình thuộc nhóm, cũng phải tính đến ánh xạ tọa độ và biến đổi của nhóm; không giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỉ lệ hai lần nếu đã được phản ánh trong khung của đối tượng con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả đường viền; việc thay đổi chúng sẽ không cập nhật lại hình gốc. Chọn cách này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/kiểu. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) khi bạn cần các lệnh hình học trong hệ tọa độ nội bộ của hình hoặc muốn chỉnh sửa hình học. Áp dụng các đường đã chỉnh sửa qua [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) hoặc [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Chuyển đổi Một Java AWT Shape Thành GeometryPath**

Ví dụ này kết hợp một đường viền hình chữ nhật với văn bản đã chuyển thành hình học. Phương thức [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) của đường viền tắt chế độ tô. Một [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tạo đường viền văn bản trong một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) của nó cung cấp các đoạn chuyển, đường thẳng, quadratic, cubic và đóng, mà ví dụ này phát lại trên một [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Ví dụ sử dụng một mảng float Java để Java/PHP Bridge giữ nguyên các tọa độ do iterator ghi lại. Văn bản sử dụng phông Arial 40 điểm. Đường viền được dịch ngang 20 điểm và đặt vị trí sao cho phần trên hiển thị cách mép trên của hình 10 điểm. Đường văn bản được tô, trong khi hình chữ nhật gốc vẫn là đường viền. Áp dụng cả hai đường bằng [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) tạo ra một hình duy nhất chứa cả hình chữ nhật và văn bản.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với màu nền và đường viền sau khi thay thế hình học?**

Kiểu vẫn giữ nguyên trên hình; chỉ có đường viền thay đổi. Màu nền và đường viền sẽ tự động áp dụng cho hình học mới.

**Làm thế nào để xoay đúng một hình tùy chỉnh cùng với hình học của nó?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) của hình; hình học sẽ quay cùng với hình vì nó được gắn vào hệ tọa độ của hình.

**Tôi có thể chuyển một hình tùy chỉnh thành ảnh để "khóa" kết quả không?**

Có. Xuất vùng [slide](/slides/vi/php-java/convert-powerpoint-to-png/) cần thiết hoặc [hình](/slides/vi/php-java/create-shape-thumbnails/) ra định dạng raster; việc này giúp đơn giản hoá các thao tác tiếp theo với các hình học phức tạp.