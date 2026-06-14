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
- đường geometry
- điểm đường
- điểm chỉnh sửa
- thêm điểm
- xóa điểm
- hoạt động chỉnh sửa
- góc cong
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh các hình dạng trong bản trình chiếu PowerPoint với Aspose.Slides cho PHP thông qua Java: đường geometry, góc cong, hình dạng tổng hợp."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh các hình dạng trong bản trình chiếu Aspose.Slides bằng cách chỉnh sửa geometry của hình qua các điểm chỉnh sửa và đường geometry. Nó cho thấy cách làm việc với `GeometryPath` để sửa đổi các hình hiện có, thực hiện các thao tác chỉnh sửa đường cơ bản, thêm hoặc xóa các điểm, và áp dụng geometry đã cập nhật trở lại cho một hình dạng.

Nó cũng minh họa cách tạo các hình dạng tùy chỉnh và tổng hợp, xây dựng các hình dạng với các góc cong, xác định xem geometry của một hình dạng có đóng hay không, và chuyển đổi giữa `GeometryPath` và `java.awt.Shape` cho các kịch bản tùy chỉnh geometry bổ sung.

## **Thay đổi một hình dạng bằng các điểm chỉnh sửa**
Xem xét một hình vuông. Trong PowerPoint, sử dụng **điểm chỉnh sửa**, bạn có thể  

* di chuyển góc của hình vuông vào trong hoặc ra ngoài  
* xác định độ cong cho một góc hoặc một điểm  
* thêm các điểm mới vào hình vuông  
* thao tác các điểm trên hình vuông, v.v.  

Về cơ bản, bạn có thể thực hiện các công việc mô tả trên bất kỳ hình dạng nào. Bằng cách sử dụng các điểm chỉnh sửa, bạn có thể thay đổi một hình dạng hoặc tạo một hình dạng mới từ một hình dạng tồn tại.

## **Mẹo chỉnh sửa hình dạng**

![overview_image](custom_shape_0.png)

Trước khi bắt đầu chỉnh sửa các hình dạng PowerPoint qua các điểm chỉnh sửa, bạn có thể muốn cân nhắc các điểm sau về hình dạng:

* Một hình dạng (hoặc đường của nó) có thể là đóng hoặc mở.  
* Khi một hình dạng đóng, nó không có điểm bắt đầu hay kết thúc. Khi một hình dạng mở, nó có điểm đầu và điểm cuối.  
* Tất cả các hình dạng bao gồm ít nhất 2 điểm neo (anchor point) được liên kết với nhau bằng các đường thẳng.  
* Một đường có thể là thẳng hoặc cong. Các điểm neo quyết định tính chất của đường.  
* Các điểm neo tồn tại dưới dạng điểm góc, điểm thẳng, hoặc điểm mượt:  
  * **Điểm góc** là điểm mà 2 đường thẳng nối nhau tạo thành một góc.  
  * **Điểm mượt** là điểm mà 2 tay cầm (handle) nằm trên một đường thẳng và các đoạn đường nối nhau tạo thành một đường cong mượt. Trong trường hợp này, tất cả các tay cầm cách điểm neo một khoảng cách đều nhau.  
  * **Điểm thẳng** là điểm mà 2 tay cầm nằm trên một đường thẳng và các đoạn đường nối nhau tạo thành một đường cong mượt. Trong trường hợp này, các tay cầm không cần phải cách điểm neo một khoảng cách đều nhau.  
* Bằng cách di chuyển hoặc chỉnh sửa các điểm neo (điều này thay đổi góc của các đường), bạn có thể thay đổi cách hình dạng hiển thị.

Để chỉnh sửa các hình dạng PowerPoint qua các điểm chỉnh sửa, **Aspose.Slides** cung cấp lớp [**GeometryPath**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath).

* Một [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath) đại diện cho một đường geometry của đối tượng [GeometryShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometryshape/).  
* Để lấy `GeometryPath` từ thể hiện `GeometryShape`, bạn có thể sử dụng phương thức [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometryshape/#getGeometryPaths).  
* Để đặt `GeometryPath` cho một hình dạng, bạn có thể dùng các phương thức: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometryshape/#setGeometryPath) cho *hình dạng đặc* và [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometryshape/#setGeometryPaths) cho *hình dạng tổng hợp*.  
* Để thêm các đoạn, bạn có thể dùng các phương thức dưới [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometrypath/).  
* Sử dụng các phương thức [GeometryPath::setStroke](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometrypath/setstroke/) và [GeometryPath::setFillMode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometrypath/setfillmode/) để thiết lập giao diện cho một đường geometry.  
* Dùng phương thức [GeometryPath::getPathData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometrypath/getpathdata/) để lấy đường geometry của một `GeometryShape` dưới dạng mảng các đoạn đường.  
* Để truy cập các tùy chọn tùy chỉnh geometry bổ sung, bạn có thể chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometrypath/) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).  
* Sử dụng các phương thức [geometryPathToGraphicsPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) và [graphicsPathToGeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (từ lớp [ShapeUtil](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ShapeUtil)) để chuyển đổi [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/geometrypath/) sang [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) và ngược lại.

## **Các thao tác chỉnh sửa đơn giản**

Đoạn mã PHP này cho bạn thấy cách  

**Thêm một đường** vào cuối một đường dẫn  

```php

```
**Thêm một đường** vào vị trí xác định trên một đường dẫn:  

```php

```
**Thêm một đường cong Bezier bậc ba** ở cuối một đường dẫn:  

```php

```
**Thêm một đường cong Bezier bậc ba** vào vị trí xác định trên một đường dẫn:  

```php

```
**Thêm một đường cong Bezier bậc hai** ở cuối một đường dẫn:  

```php

```
**Thêm một đường cong Bezier bậc hai** vào vị trí xác định trên một đường dẫn:  

```php

```
**Gắn một cung** đã cho vào một đường dẫn:  

```php

```
**Đóng hình hiện tại** của một đường dẫn:  

```php

```
**Đặt vị trí cho điểm tiếp theo**:  

```php

```
**Xóa đoạn đường** tại một chỉ mục cho trước:  

```php

```

## **Thêm các điểm tùy chỉnh vào một hình dạng**
1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryShape) và đặt loại [ShapeType::Rectangle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ShapeType).  
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath) từ hình dạng.  
3. Thêm một điểm mới giữa hai điểm trên cùng của đường.  
4. Thêm một điểm mới giữa hai điểm dưới cùng của đường.  
5. Áp dụng đường cho hình dạng.

Đoạn mã PHP này cho bạn thấy cách thêm các điểm tùy chỉnh vào một hình dạng:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **Xóa các điểm khỏi một hình dạng**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryShape) và đặt loại [ShapeType::Heart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ShapeType).  
2. Lấy một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath) từ hình dạng.  
3. Xóa đoạn cho đường.  
4. Áp dụng đường cho hình dạng.

Đoạn mã PHP này cho bạn thấy cách xóa các điểm khỏi một hình dạng:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **Tạo một hình dạng tùy chỉnh**

1. Tính toán các điểm cho hình dạng.  
2. Tạo một thể hiện của lớp [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath).  
3. Điền đường bằng các điểm.  
4. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryShape).  
5. Áp dụng đường cho hình dạng.

Đoạn mã Java này cho bạn thấy cách tạo một hình dạng tùy chỉnh:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)

## **Tạo một hình dạng tùy chỉnh tổng hợp**

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryShape).  
2. Tạo một thể hiện đầu tiên của lớp [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath).  
3. Tạo một thể hiện thứ hai của lớp [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath).  
4. Áp dụng các đường cho hình dạng.

Đoạn mã PHP này cho bạn thấy cách tạo một hình dạng tùy chỉnh tổng hợp:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Tạo một hình dạng tùy chỉnh với các góc cong**

Đoạn mã PHP này cho bạn thấy cách tạo một hình dạng tùy chỉnh với các góc cong (hướng vào trong);

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xác định xem geometry của một hình dạng có đóng hay không**

Một hình dạng đóng được định nghĩa là hình mà tất cả các cạnh của nó nối liền nhau, tạo thành một biên duy nhất không có khoảng trống. Hình dạng như vậy có thể là một hình học đơn giản hoặc một đường viền tùy chỉnh phức tạp. Đoạn mã dưới đây cho thấy cách kiểm tra xem geometry của một hình dạng có đóng hay không:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **Chuyển GeometryPath sang java.awt.Shape** 

1. Tạo một thể hiện của lớp [GeometryShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryShape).  
2. Tạo một thể hiện của lớp [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).  
3. Chuyển đổi thể hiện [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) sang thể hiện [GeometryPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GeometryPath) bằng cách sử dụng [ShapeUtil](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ShapeUtil).  
4. Áp dụng các đường cho hình dạng.

Đoạn mã PHP—một triển khai của các bước trên—minh họa quá trình chuyển đổi **GeometryPath** sang **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Tạo hình dạng mới
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Lấy đường geometry của hình dạng
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Tạo đường đồ họa mới với văn bản
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Chuyển đổi đường đồ họa sang đường geometry
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Đặt kết hợp của đường geometry mới và đường geometry gốc cho hình dạng
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **Câu hỏi thường gặp**

**Điều gì sẽ xảy ra với phần tô và viền sau khi thay thế geometry?**  

Kiểu dáng vẫn giữ nguyên trên hình; chỉ đường viền thay đổi. Phần tô và viền sẽ tự động áp dụng lên geometry mới.

**Làm thế nào để xoay một hình dạng tùy chỉnh cùng với geometry một cách chính xác?**  

Sử dụng phương thức [setRotation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/setrotation/) của hình; geometry sẽ quay cùng với hình vì nó được ràng buộc vào hệ tọa độ của hình.

**Tôi có thể chuyển đổi một hình dạng tùy chỉnh thành ảnh để “khóa” kết quả không?**  

Có. Xuất khu vực [slide](/slides/vi/php-java/convert-powerpoint-to-png/) cần thiết hoặc trực tiếp [shape](/slides/vi/php-java/create-shape-thumbnails/) ra định dạng raster; việc này sẽ làm đơn giản hơn khi làm việc với các geometry phức tạp.