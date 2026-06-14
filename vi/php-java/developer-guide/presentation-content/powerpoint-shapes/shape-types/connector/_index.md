---
title: Quản lý các kết nối trong bản trình chiếu bằng PHP
linktitle: Kết nối
type: docs
weight: 10
url: /vi/php-java/connector/
keywords:
- kết nối
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- kết nối các hình
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Cho phép các ứng dụng PHP vẽ, kết nối và tự động định tuyến các đường trên slide PowerPoint — nắm kiểm soát đầy đủ các kết nối thẳng, gối và cong."
---
## **Giới thiệu**

Kết nối PowerPoint là một đường đặc biệt kết nối hoặc liên kết hai hình lại với nhau và vẫn gắn vào các hình ngay cả khi chúng được di chuyển hoặc thay đổi vị trí trên một slide nhất định. 

Các kết nối thường được gắn vào *điểm kết nối* (điểm xanh lá), vốn có sẵn trên tất cả các hình theo mặc định. Các điểm kết nối xuất hiện khi con trỏ tiếp cận chúng.

*Điểm điều chỉnh* (điểm cam), chỉ tồn tại trên một số kết nối, được dùng để thay đổi vị trí và hình dạng của các kết nối.

## **Các loại kết nối**

Trong PowerPoint, bạn có thể sử dụng các kết nối thẳng, gối (có góc) và cong. 

Aspose.Slides cung cấp các kết nối này:

| Connector | Image | Number of adjustment points |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Kết nối các hình bằng kết nối**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy tham chiếu một slide thông qua chỉ mục của nó.
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` được cung cấp bởi đối tượng `Shapes`.
1. Thêm một kết nối bằng phương thức `addConnector` được cung cấp bởi đối tượng `Shapes` bằng cách xác định kiểu kết nối.
1. Kết nối các hình bằng kết nối.
1. Gọi phương thức `reroute` để áp dụng đường nối ngắn nhất.
1. Lưu bản trình chiếu. 

Mã PHP này cho bạn thấy cách thêm một kết nối (kết nối gập) giữa hai hình (một hình elip và hình chữ nhật):

```php
// Tạo một lớp presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Truy cập bộ sưu tập các hình cho một slide cụ thể
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Thêm một hình tự động Ellipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Thêm một hình tự động Rectangle
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Thêm một hình kết nối vào bộ sưu tập các hình của slide
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Kết nối các hình bằng kết nối
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Gọi reroute để đặt đường ngắn nhất tự động giữa các hình
    $connector->reroute();
    # Lưu bản trình chiếu
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Phương thức `Connector.reroute` sẽ định tuyến lại một kết nối và buộc nó đi theo đường ngắn nhất có thể giữa các hình. Để đạt mục tiêu này, phương thức có thể thay đổi các điểm `setStartShapeConnectionSiteIndex` và `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Xác định một điểm kết nối**

Nếu bạn muốn một kết nối liên kết hai hình bằng các điểm cụ thể trên các hình, bạn phải xác định các điểm kết nối ưa thích của mình theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy tham chiếu một slide thông qua chỉ mục của nó.
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` được cung cấp bởi đối tượng `Shapes`.
1. Thêm một kết nối bằng phương thức `addConnector` được cung cấp bởi đối tượng `Shapes` bằng cách xác định kiểu kết nối.
1. Kết nối các hình bằng kết nối.
1. Đặt các điểm kết nối ưa thích của bạn trên các hình.
1. Lưu bản trình chiếu.

```php
  # Tạo một lớp presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Truy cập bộ sưu tập các hình cho một slide cụ thể
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Thêm một hình tự động Ellipse
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Thêm một hình tự động Rectangle
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Thêm một hình kết nối vào bộ sưu tập các hình của slide
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Kết nối các hình bằng kết nối
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Đặt chỉ mục điểm kết nối ưa thích trên hình Ellipse
    $wantedIndex = 6;
    # Kiểm tra xem chỉ mục ưa thích có nhỏ hơn số lượng điểm kết nối tối đa không
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Đặt điểm kết nối ưa thích trên hình tự động Ellipse
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Lưu bản trình chiếu
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Điều chỉnh một điểm kết nối**

Bạn có thể điều chỉnh một kết nối hiện có thông qua các điểm điều chỉnh của nó. Chỉ các kết nối có điểm điều chỉnh mới có thể được thay đổi theo cách này. Xem bảng dưới **[Các loại kết nối.](/slides/vi/php-java/connector/#types-of-connectors)**

### **Trường hợp đơn giản**

Xem xét một trường hợp mà một kết nối giữa hai hình (A và B) đi qua một hình thứ ba (C):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Để tránh hoặc bỏ qua hình thứ ba, chúng ta có thể điều chỉnh kết nối bằng cách di chuyển đường thẳng đứng của nó sang trái như sau:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Trường hợp phức tạp** 

Để thực hiện các điều chỉnh phức tạp hơn, bạn phải cân nhắc các yếu tố sau:

* Một điểm có thể điều chỉnh của kết nối gắn liền chặt chẽ với công thức tính và xác định vị trí của nó. Do đó, việc thay đổi vị trí của điểm có thể làm thay đổi hình dạng của kết nối.
* Các điểm điều chỉnh của kết nối được xác định theo thứ tự chặt chẽ trong một mảng. Các điểm điều chỉnh được đánh số từ điểm bắt đầu của kết nối đến điểm kết thúc.
* Giá trị điểm điều chỉnh phản ánh phần trăm của chiều rộng/chiều cao của hình dạng kết nối. 
  * Hình dạng được giới hạn bởi các điểm bắt đầu và kết thúc của kết nối nhân với 1000. 
  * Điểm thứ nhất, điểm thứ hai và điểm thứ ba lần lượt xác định phần trăm từ chiều rộng, phần trăm từ chiều cao và lại phần trăm từ chiều rộng.
* Đối với các phép tính xác định tọa độ của các điểm điều chỉnh của kết nối, bạn phải tính đến góc quay và phản chiếu của kết nối. **Lưu ý** rằng góc quay cho tất cả các kết nối được hiển thị dưới **[Các loại kết nối](/slides/vi/php-java/connector/#types-of-connectors)** là 0.

#### **Trường hợp 1**

Xem xét một trường hợp mà hai đối tượng khung văn bản được liên kết với nhau qua một kết nối:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Tạo một lớp presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên trong bản trình chiếu
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm các hình sẽ được nối lại với nhau bằng một kết nối
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Thêm một kết nối
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Xác định hướng của kết nối
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Xác định màu của kết nối
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Xác định độ dày của đường kết nối
    $connector->getLineFormat()->setWidth(3);
    # Liên kết các hình lại với nhau bằng kết nối
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Lấy các điểm điều chỉnh cho kết nối
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Điều chỉnh**

Chúng ta có thể thay đổi giá trị điểm điều chỉnh của kết nối bằng cách tăng phần trăm chiều rộng và chiều cao tương ứng lên 20% và 200%, tương ứng:

```php
  # Thay đổi giá trị của các điểm điều chỉnh
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

Kết quả:

![connector-adjusted-1](connector-adjusted-1.png)

Để xác định một mô hình cho phép chúng ta tìm tọa độ và hình dạng của các phần riêng lẻ của kết nối, hãy tạo một hình tương ứng với thành phần ngang của kết nối tại điểm connector.getAdjustments().get_Item(0):

```php
  # Vẽ thành phần dọc của kết nối
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

Kết quả:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Trường hợp 2**

Trong **Trường hợp 1**, chúng tôi đã trình bày một thao tác điều chỉnh kết nối đơn giản dựa trên các nguyên tắc cơ bản. Trong các tình huống bình thường, bạn phải tính đến góc quay của kết nối và cách hiển thị của nó (được đặt bởi connector.getRotation(), connector.getFrame().getFlipH() và connector.getFrame().getFlipV()). Bây giờ chúng tôi sẽ minh họa quy trình.

Đầu tiên, hãy thêm một đối tượng khung văn bản mới (**To 1**) vào slide (để kết nối) và tạo một kết nối (màu xanh lá) mới để kết nối nó với các đối tượng đã tạo trước đó.

```php
  # Tạo một đối tượng liên kết mới
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Tạo một kết nối mới
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Kết nối các đối tượng bằng kết nối mới tạo
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Lấy các điểm điều chỉnh của kết nối
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Thay đổi giá trị của các điểm điều chỉnh
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

Kết quả:

![connector-adjusted-3](connector-adjusted-3.png)

Thứ hai, hãy tạo một hình sẽ tương ứng với thành phần ngang của kết nối đi qua điểm điều chỉnh mới của kết nối connector.getAdjustments().get_Item(0). Chúng ta sẽ sử dụng các giá trị từ dữ liệu kết nối cho connector.getRotation(), connector.getFrame().getFlipH() và connector.getFrame().getFlipV() và áp dụng công thức chuyển đổi tọa độ phổ biến cho việc quay quanh một điểm x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Trong trường hợp của chúng ta, góc quay của đối tượng là 90 độ và kết nối được hiển thị theo chiều dọc, vì vậy đây là mã tương ứng:

```php
  # Lưu các tọa độ của kết nối
  $x = $connector->getX();
  $y = $connector->getY();
  # Sửa các tọa độ của kết nối nếu nó xuất hiện
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Lấy giá trị điểm điều chỉnh làm tọa độ
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Chuyển đổi các tọa độ vì Sin(90) = 1 và Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Xác định chiều rộng của thành phần ngang bằng giá trị điểm điều chỉnh thứ hai
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

Kết quả:

![connector-adjusted-4](connector-adjusted-4.png)

Chúng tôi đã minh họa các phép tính liên quan đến việc điều chỉnh đơn giản và các điểm điều chỉnh phức tạp (các điểm điều chỉnh có góc quay). Với kiến thức đã thu được, bạn có thể phát triển mô hình riêng của mình (hoặc viết mã) để lấy một đối tượng `GraphicsPath` hoặc thậm chí thiết lập các giá trị điểm điều chỉnh của kết nối dựa trên tọa độ slide cụ thể.

## **Tìm góc của các đường kết nối**

1. Tạo một thể hiện của lớp.
1. Lấy tham chiếu một slide thông qua chỉ mục của nó.
1. Truy cập hình dạng đường kết nối.
1. Sử dụng chiều rộng, chiều cao của đường, chiều cao khung hình và chiều rộng khung hình để tính góc.

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Làm sao tôi biết một kết nối có thể "dán" vào một hình cụ thể?**

Kiểm tra xem hình có cung cấp [điểm kết nối](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getconnectionsitecount/) hay không. Nếu không có hoặc số lượng bằng 0, tính năng dán không khả dụng; trong trường hợp đó, hãy sử dụng các đầu nối tự do và đặt vị trí chúng theo cách thủ công. Thông thường nên kiểm tra số lượng điểm trước khi gắn.

**Điều gì xảy ra với một kết nối nếu tôi xóa một trong các hình đã kết nối?**

Các đầu của nó sẽ bị tách ra; kết nối vẫn còn trên slide như một đường thường với đầu/bắt đầu tự do. Bạn có thể xóa nó hoặc gán lại các kết nối và, nếu cần, [định tuyến lại](https://reference.aspose.com/slides/vi/php-java/aspose.slides/connector/reroute/).

**Liên kết của kết nối có được giữ lại khi sao chép một slide sang bản trình chiếu khác không?**

Thông thường có, với điều kiện các hình đích cũng được sao chép. Nếu slide được chèn vào tệp khác mà không có các hình đã kết nối, các đầu sẽ trở thành tự do và bạn sẽ cần gắn lại chúng.