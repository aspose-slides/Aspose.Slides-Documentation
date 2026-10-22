---
title: Tùy chỉnh các hình dạng trong bản trình chiếu bằng PHP
linktitle: Hình dạng tùy chỉnh
type: docs
weight: 20
url: /vi/php-java/custom-shape/
keywords:
- hình dạng tùy chỉnh
- thêm hình dạng
- tạo hình dạng
- thay đổi hình dạng
- hình học hình dạng
- đường dẫn hình học
- điểm đường dẫn
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint bằng Aspose.Slides cho PHP thông qua Java: đường dẫn hình học, các góc cong, hình ghép hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu Aspose.Slides bằng cách chỉnh sửa hình học của hình dạng thông qua các điểm chỉnh sửa và đường dẫn hình học. Nó cho thấy cách làm việc với [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) để sửa đổi các hình đã tồn tại, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa các điểm, và áp dụng hình học đã cập nhật trở lại cho một hình dạng.

Nó cũng minh họa cách tạo các hình tùy chỉnh và ghép hợp, xây dựng các hình có các góc cong, xác định xem hình học của một hình dạng có đóng hay không, kiểm tra các thành phần hình dạng, và chuyển đổi các đường viền văn bản Java AWT thành các đường dẫn hình học.

## **Thay đổi một hình dạng bằng Điểm chỉnh sửa**

Trong PowerPoint, bạn có thể sử dụng **Edit Points** để chỉnh sửa một hình vuông:

* Di chuyển một góc vào trong hoặc ra ngoài.
* Điều chỉnh độ cong tại một điểm.
* Thêm các điểm mới.

Các điểm chỉnh sửa cho phép bạn sửa đổi viền của một hình dạng hoặc sử dụng một hình dạng hiện có làm cơ sở cho một hình mới.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Khi chỉnh sửa các hình dạng PowerPoint, hãy ghi nhớ những khái niệm sau:

* Một hình dạng (hoặc đường dẫn của nó) có thể là đóng hoặc mở.
* Đường dẫn của một hình dạng gồm các điểm neo được kết nối bằng các đoạn.
* Một đoạn có thể thẳng hoặc cong. Các điểm neo và tay cầm điều khiển (control handles) quyết định hình dạng của nó.
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng hoặc điểm mượt:
  * Ở điểm góc, các đoạn liền kề có thể gặp nhau tại một góc.
  * Ở điểm mượt, hai tay cầm điều khiển được thẳng hàng và cách đều điểm neo.
  * Ở điểm thẳng, hai tay cầm điều khiển được thẳng hàng nhưng có thể cách điểm neo với khoảng cách khác nhau.
* Di chuyển các điểm neo hoặc điều chỉnh tay cầm của chúng sẽ thay đổi viền của hình dạng.

Để chỉnh sửa các hình dạng PowerPoint thông qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Một thể hiện của [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) đại diện cho một đường dẫn hình học của đối tượng [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Để lấy [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) từ thể hiện [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), bạn có thể sử dụng phương thức [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Để đặt [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) cho một hình dạng, bạn có thể sử dụng các phương thức sau: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) cho các hình có một đường duy nhất và [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) cho các hình có nhiều đường.
* Để thêm các đoạn, bạn có thể sử dụng các phương thức dưới [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Sử dụng các phương thức [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) và [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), bạn có thể đặt giao diện cho một đường dẫn hình học.
* Sử dụng phương thức [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), bạn có thể lấy đường dẫn hình học của một [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) dưới dạng một mảng các đoạn đường.
* Để truy cập các tùy chọn tùy chỉnh hình học bổ sung, bạn có thể đọc một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) thông qua [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) của nó và phát lại các đoạn trên một [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Các thao tác chỉnh sửa đơn giản**

Sử dụng các phương thức sau để chỉnh sửa một đường dẫn hình học. Các overload chấp nhận một chỉ mục sẽ chèn một đoạn tại vị trí có chỉ mục bắt đầu từ 0 trong mảng đoạn của đường dẫn.

| Operation | Method |
| --- | --- |
| Thêm hoặc chèn một đường thẳng. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Thêm hoặc chèn một đường cong Bézier bậc ba với hai điểm điều khiển và một điểm cuối. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Thêm hoặc chèn một đường cong Bézier bậc hai với một điểm điều khiển và một điểm cuối. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Thêm một cung ellip với kích thước và góc đã chỉ định tính bằng độ. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Đóng hình hiện tại bằng cách kết nối điểm cuối với điểm bắt đầu. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Đặt điểm bắt đầu của một hình. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Xóa một đoạn tại vị trí có chỉ mục bắt đầu từ 0. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Thêm các điểm tùy chỉnh vào một hình dạng**

Ví dụ này chèn hai điểm vào một hình chữ nhật bằng cách sử dụng [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) và áp dụng đường đã chỉnh sửa bằng [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Các tọa độ là cục bộ đối với hình dạng: cả hai điểm mới đều nằm ở trung tâm, cách bên trái 100 điểm và cách bên trên 50 điểm. Các chỉ mục đoạn 1 và 4 đặt chúng trên các cạnh trên và dưới, kéo các cạnh này vào trong.

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

## **Xóa các điểm khỏi một hình dạng**

Ví dụ này thay đổi viền hình dạng trái tim bằng cách xóa đoạn có chỉ mục bắt đầu từ 0 là 2 bằng [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Áp dụng đường đã sửa đổi bằng [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) sẽ cập nhật đường viền của hình dạng.

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

## **Tạo một hình dạng tùy chỉnh**

Ví dụ này xây dựng một ngôi sao năm đầu bằng [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Các bán kính ngoài và trong xen kẽ là 100 và 50 điểm, xác định các đầu nhọn và các khe lõm; bước 72 độ chia đều năm đầu. Đường được đóng bằng [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) và áp dụng cho một hình chữ nhật bằng [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), thay thế viền của nó.

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

## **Tạo một hình dạng tùy chỉnh ghép hợp**

Ví dụ này định nghĩa hai [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) đóng cho phần trên và dưới của một hình dạng. Áp dụng cả hai đường bằng [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) tạo ra một hình ghép hợp duy nhất với một khoảng trống ở phần giữa.

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

## **Tạo một hình dạng tùy chỉnh với các góc cong**

Ví dụ này kết hợp các đoạn thẳng với [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) để tạo một hình có các góc cong vào trong. Kích thước mỗi góc xác định độ rộng và chiều cao của cung tính bằng điểm, và góc quét -90 độ vẽ một phần tư ellipse ngược chiều kim đồng hồ. Đường hoàn chỉnh được áp dụng bằng [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), và bản trình chiếu được lưu ở định dạng PPTX.

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

## **Xác định xem hình học của một hình dạng có đóng hay không**

Trợ giúp sau kiểm tra xem mọi đường hình học không rỗng có kết thúc bằng một đoạn đóng hay không. Nó đọc [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) và so sánh lệnh cuối cùng của đoạn bằng [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) với [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Nó trả về false khi không có đường nào không rỗng. Kiểm tra này chỉ xem lệnh cuối cùng của mỗi đường; nó không kiểm tra từng subfigure bên trong một đường. Ví dụ in ra `true` cho một hình chữ nhật.

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

## **Trích xuất và kiểm tra các thành phần hình dạng**

Sử dụng [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) để kiểm tra một hình dạng hiện có dưới dạng các thành phần chứa các điểm đường và loại điểm. Sử dụng mỗi [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) được trả về để lấy mảng điểm và mảng loại thông qua các phương thức [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) và [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Đại diện này hữu ích cho việc phân tích viền hoặc truyền hình học tới các công cụ vẽ tùy chỉnh.

Ví dụ mở file input.pptx, tìm hình dạng geometry đầu tiên trực tiếp trên slide đầu tiên, và in ra các đoạn đường của nó. Dùng một bản trình chiếu chứa một hình dạng có các đoạn thẳng và cong để thấy cả hai loại đầu ra. Nó không tìm kiếm bên trong các nhóm.

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
                $pointType = $types[$i] & 0x07; // Giữ lại loại đoạn, loại trừ các cờ.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
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

Các mảng tương ứng theo chỉ mục: `$points[$i]` là một điểm và `$types[$i]` mô tả vai trò của nó. Loại `0` bắt đầu một hình, và loại `1` vẽ một đoạn thẳng từ điểm trước tới điểm hiện tại. Một đoạn Bézier bậc ba bắt đầu tại điểm cuối trước và sử dụng ba mục loại `3` liên tiếp: hai điểm điều khiển rồi sau đó là điểm cuối mới. Vòng lặp tiêu thụ ba mục này cùng nhau và kiểm tra điểm cuối để xác định sự đóng.

Các loại điểm cũng chứa các cờ. Áp dụng mặt nạ `0x07` để xác định loại đoạn, và kiểm tra `0x80` riêng để phát hiện một subpath đóng. Ví dụ, `129` (`0x81`) có nghĩa là một điểm cuối đoạn thẳng đóng một subpath, và `131` (`0x83`) là một điểm cuối Bézier đóng một subpath. Bridge PHP/Java trả về mảng byte dưới dạng chuỗi nhị phân; giải nén bằng `"C*"` sẽ tạo ra các giá trị byte không dấu. Áp dụng mặt nạ giữ nguyên các bit mong muốn. So sánh giá trị thô chỉ với `1` hoặc `3` sẽ bỏ sót các trường hợp này. Các cờ khác, chẳng hạn dash (`0x10`) và marker (`0x20`), không thay đổi loại đoạn cơ bản.

**Tọa độ và biến đổi.** Các điểm được đo bằng point (1/72 inch), với trục X tăng về phía bên phải và trục Y tăng xuống dưới. Đối với một hình dạng không nằm trong nhóm, các tọa độ đã trích xuất bao gồm vị trí trả về bởi [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) và [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) và phản ánh chiều rộng và chiều cao hiện tại của nó. Ví dụ, một hình chữ nhật không xoay tại `(100, 200)` với kích thước `120 × 80` có giới hạn viền `(100, 200)`–`(220, 280)`. Đừng cộng lại vị trí của hình dạng một lần nữa. Trừ X và Y của nó để có tọa độ tương đối với khung không xoay.

Các điểm đã trích xuất không áp dụng phép xoay của hình dạng, được trả về bởi [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), hoặc các phép lật ngang và dọc. Để tái tạo viền hiển thị, hãy áp dụng các biến đổi này quanh trung tâm của hình dạng. Đối với các hình dạng nằm trong nhóm, cũng phải tính tới việc ánh xạ tọa độ nhóm và các biến đổi; đừng giả định rằng các điểm đã trích xuất là tọa độ cuối cùng trên slide hoặc áp dụng một phép dịch hoặc tỉ lệ hai lần nếu nó đã được phản ánh trong khung của đối tượng con.

**Kiểm tra so với chỉnh sửa.** Các mảng đã trích xuất mô tả viền; việc thay đổi chúng sẽ không cập nhật hình dạng gốc. Chọn cách tiếp cận này khi phân tích hoặc mã vẽ của bạn cần các mảng điểm/loại. Sử dụng [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) khi bạn cần các lệnh hình học trong hệ tọa độ cục bộ của hình dạng hoặc muốn chỉnh sửa hình học của nó. Áp dụng các đường đã chỉnh sửa qua [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) hoặc [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Chuyển đổi một Java AWT Shape sang GeometryPath**

Ví dụ này kết hợp viền hình chữ nhật với văn bản được chuyển đổi thành hình học. Phương thức [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) của viền tắt chế độ tô. Một [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tạo ra đường viền văn bản trong một [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) của nó cung cấp các đoạn di chuyển, đường thẳng, quadratic, cubic và đóng, mà ví dụ này phát lại trên một [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Ví dụ sử dụng một mảng float Java để Bridge PHP/Java giữ nguyên các tọa độ được iterator ghi. Văn bản sử dụng phông Arial kích thước 40 point. Viền được dịch sang phải 20 point và đặt vị trí sao cho phần trên thị giác cách mép trên của hình dạng 10 point. Đường văn bản được tô, trong khi hình chữ nhật gốc vẫn chỉ là viền. Áp dụng cả hai đường bằng [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) tạo ra một hình duy nhất chứa hình chữ nhật và văn bản.

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

**Điều gì sẽ xảy ra với màu nền và viền sau khi thay thế hình học?**

Kiểu dáng vẫn giữ nguyên trên hình dạng; chỉ viền được thay đổi. Màu nền và viền sẽ tự động áp dụng cho hình học mới.

**Làm thế nào để xoay một hình dạng tùy chỉnh cùng với hình học của nó một cách chính xác?**

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) của hình dạng; hình học sẽ xoay cùng hình dạng vì nó được gắn vào hệ tọa độ của hình dạng đó.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành hình ảnh để "khóa" kết quả không?**

Có. Xuất phần [trình chiếu](/slides/vi/php-java/convert-powerpoint-to-png/) cần thiết hoặc [hình dạng](/slides/vi/php-java/create-shape-thumbnails/) thành định dạng raster; việc này giúp đơn giản hoá các bước tiếp theo với các hình học phức tạp.