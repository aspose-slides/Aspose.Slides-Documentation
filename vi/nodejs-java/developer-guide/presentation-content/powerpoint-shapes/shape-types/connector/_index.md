---
title: Quản lý các Connector trong Bản trình chiếu bằng JavaScript
linktitle: Connector
type: docs
weight: 10
url: /vi/nodejs-java/connector/
keywords:
- kết nối
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- kết nối các hình
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Cho phép các ứng dụng JavaScript vẽ, kết nối và tự động định tuyến các đường trong slide PowerPoint—đạt được kiểm soát đầy đủ đối với các connector thẳng, góc và cong."
---
## **Giới thiệu**

Một connector trong PowerPoint là một đường đặc biệt kết nối hoặc liên kết hai hình lại với nhau và vẫn gắn vào các hình ngay cả khi chúng được di chuyển hoặc thay đổi vị trí trên một slide nhất định. 

Các connector thường được gắn vào *điểm kết nối* (điểm xanh lá), vốn tồn tại trên mọi hình mặc định. Điểm kết nối sẽ xuất hiện khi con trỏ di chuột gần chúng.

*Điểm điều chỉnh* (điểm cam), chỉ tồn tại trên một số connector nhất định, được dùng để thay đổi vị trí và hình dạng của connector.

## **Các loại Connector**

Trong PowerPoint, bạn có thể sử dụng connector thẳng, gập (có góc) và cong. 

Aspose.Slides cung cấp các connector sau:

| Connector                      | Image                                                        | Number of adjustment points |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Kết nối các hình bằng Connector**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` được cung cấp bởi đối tượng `Shapes`.
4. Thêm một connector bằng phương thức `addConnector` được cung cấp bởi đối tượng `Shapes` bằng cách xác định kiểu connector.
5. Kết nối các hình bằng connector.
6. Gọi phương thức `reroute` để áp dụng đường kết nối ngắn nhất.
7. Lưu bản trình bày. 

Đoạn mã JavaScript này cho bạn thấy cách thêm một connector (một connector cong) giữa hai hình (một hình ellipse và một hình rectangle):

```javascript
// Tạo một lớp trình chiếu đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập bộ sưu tập các shape cho một slide cụ thể
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Thêm một autoshape Ellipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Thêm một autoshape Rectangle
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Thêm một shape connector vào bộ sưu tập shape của slide
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Kết nối các shape bằng connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Gọi reroute để đặt đường ngắn nhất tự động giữa các shape
    connector.reroute();
    // Lưu bản trình chiếu
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Phương thức `Connector.reroute` sẽ định tuyến lại connector và buộc nó đi theo đường ngắn nhất có thể giữa các hình. Để đạt được mục tiêu này, phương thức có thể thay đổi các điểm `setStartShapeConnectionSiteIndex` và `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Chỉ định Điểm Kết Nối**

Nếu bạn muốn một connector liên kết hai hình bằng các điểm cụ thể trên các hình, bạn phải chỉ định các điểm kết nối ưa thích của mình theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` được cung cấp bởi đối tượng `Shapes`.
4. Thêm một connector bằng phương thức `addConnector` được cung cấp bởi đối tượng `Shapes` bằng cách xác định kiểu connector.
5. Kết nối các hình bằng connector. 
6. Đặt các điểm kết nối ưa thích trên các hình. 
7. Lưu bản trình bày.

Đoạn mã JavaScript này minh họa một thao tác trong đó một điểm kết nối ưa thích được chỉ định:

```javascript
// Tạo một lớp trình chiếu đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Truy cập bộ sưu tập shape cho một slide cụ thể
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Thêm một autoshape Ellipse
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Thêm một autoshape Rectangle
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Thêm một shape connector vào bộ sưu tập shape của slide
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Kết nối các shape bằng connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Đặt chỉ mục điểm kết nối ưa thích trên shape Ellipse
    var wantedIndex = 6;
    // Kiểm tra xem chỉ mục ưa thích có nhỏ hơn số lượng site tối đa không
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Đặt điểm kết nối ưa thích trên autoshape Ellipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Lưu bản trình chiếu
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Điều chỉnh Điểm Connector**

Bạn có thể điều chỉnh một connector hiện có thông qua các điểm điều chỉnh của nó. Chỉ các connector có điểm điều chỉnh mới có thể được thay đổi theo cách này. Xem bảng dưới **[Các loại connector.](/slides/vi/nodejs-java/connector/#types-of-connectors)**

### **Trường hợp Đơn giản**

Xem xét một trường hợp trong đó một connector giữa hai hình (A và B) đi qua một hình thứ ba (C):

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Để tránh hoặc bỏ qua hình thứ ba, chúng ta có thể điều chỉnh connector bằng cách di chuyển đường thẳng đứng sang trái như sau:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Trường hợp Phức tạp** 

Để thực hiện các điều chỉnh phức tạp hơn, bạn phải cân nhắc các yếu tố sau:

* Một điểm có thể điều chỉnh của connector gắn chặt với công thức tính toán và xác định vị trí của nó. Do đó, việc thay đổi vị trí của điểm có thể làm thay đổi hình dạng của connector.
* Các điểm điều chỉnh của connector được định nghĩa theo một thứ tự nghiêm ngặt trong một mảng. Các điểm điều chỉnh được đánh số từ điểm bắt đầu của connector tới điểm kết thúc.
* Giá trị điểm điều chỉnh phản ánh phần trăm của chiều rộng/chiều cao hình connector. 
  * Hình được giới hạn bởi các điểm bắt đầu và kết thúc của connector nhân với 1000. 
  * Điểm thứ nhất, điểm thứ hai và điểm thứ ba định nghĩa phần trăm từ chiều rộng, phần trăm từ chiều cao và phần trăm từ chiều rộng (lại một lần) tương ứng.
* Đối với các phép tính xác định tọa độ của các điểm điều chỉnh của connector, bạn phải tính đến góc quay và phản chiếu của connector. **Lưu ý** rằng góc quay cho tất cả các connector được hiển thị dưới **[Các loại connector](/slides/vi/nodejs-java/connector/#types-of-connectors)** là 0.

#### **Trường hợp 1**

Xem xét một trường hợp trong đó hai đối tượng khung văn bản được liên kết với nhau qua một connector:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// Tạo một lớp trình chiếu đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    var sld = pres.getSlides().get_Item(0);
    // Thêm các shape sẽ được nối với nhau qua một connector
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Thêm một connector
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Xác định hướng của connector
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Xác định màu của connector
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Xác định độ dày của đường connector
    connector.getLineFormat().setWidth(3);
    // Liên kết các shape với nhau bằng connector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Lấy các điểm điều chỉnh cho connector
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Adjustment**

Chúng ta có thể thay đổi giá trị điểm điều chỉnh của connector bằng cách tăng phần trăm chiều rộng và chiều cao tương ứng lên 20% và 200%:

```javascript
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Kết quả:

![connector-adjusted-1](connector-adjusted-1.png)

Để xác định một mô hình cho phép chúng ta tính tọa độ và hình dạng của các phần riêng lẻ của connector, hãy tạo một hình tương ứng với thành phần ngang của connector tại điểm `connector.getAdjustments().get_Item(0)`:

```javascript
// Vẽ thành phần dọc của connector
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

Kết quả:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Trường hợp 2**

Trong **Trường hợp 1**, chúng tôi đã minh họa một thao tác điều chỉnh connector đơn giản dựa trên các nguyên tắc cơ bản. Trong các tình huống bình thường, bạn phải tính đến góc quay và cách hiển thị của connector (được thiết lập bởi `connector.getRotation()`, `connector.getFrame().getFlipH()` và `connector.getFrame().getFlipV()`). Bây giờ chúng tôi sẽ trình bày quy trình.

Đầu tiên, hãy thêm một đối tượng khung văn bản mới (**To 1**) vào slide (để kết nối) và tạo một connector (màu xanh lá) mới nối nó với các đối tượng đã tạo trước đó.

```javascript
// Tạo một đối tượng binding mới
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Tạo một connector mới
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Kết nối các đối tượng bằng connector mới tạo
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Lấy các điểm điều chỉnh của connector
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Kết quả:

![connector-adjusted-3](connector-adjusted-3.png)

Thứ hai, hãy tạo một hình sẽ tương ứng với thành phần ngang của connector đi qua điểm điều chỉnh mới `connector.getAdjustments().get_Item(0)`. Chúng ta sẽ sử dụng các giá trị từ dữ liệu connector cho `connector.getRotation()`, `connector.getFrame().getFlipH()` và `connector.getFrame().getFlipV()` và áp dụng công thức chuyển đổi tọa độ phổ biến cho vòng quay quanh một điểm x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Trong trường hợp của chúng ta, góc quay của đối tượng là 90 độ và connector được hiển thị theo chiều dọc, vì vậy đây là mã tương ứng:

```javascript
// Lưu tọa độ của connector
x = connector.getX();
y = connector.getY();
// Sửa lại tọa độ của connector trong trường hợp nó xuất hiện
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Lấy giá trị điểm điều chỉnh làm tọa độ
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Chuyển đổi tọa độ vì Sin(90) = 1 và Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Xác định chiều rộng của thành phần ngang dựa trên giá trị điểm điều chỉnh thứ hai
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

Kết quả:

![connector-adjusted-4](connector-adjusted-4.png)

Chúng tôi đã minh họa các phép tính liên quan đến điều chỉnh đơn giản và các điểm điều chỉnh phức tạp (điểm điều chỉnh có góc quay). Với kiến thức đã thu thập, bạn có thể phát triển mô hình riêng (hoặc viết mã) để lấy một đối tượng `GraphicsPath` hoặc thậm chí đặt giá trị điểm điều chỉnh của connector dựa trên tọa độ slide cụ thể.

## **Tìm Góc của Các Đường Connector**

1. Tạo một thể hiện của lớp.
1. Lấy tham chiếu slide thông qua chỉ mục của nó.
1. Truy cập hình dạng đường connector.
1. Sử dụng chiều rộng, chiều cao của đường, chiều cao khung hình và chiều rộng khung hình để tính góc.

Đoạn mã JavaScript này minh họa một thao tác trong đó chúng tôi tính góc cho một hình dạng đường connector:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể biết một connector có thể "dán" vào một hình cụ thể không?**

Kiểm tra xem hình có cung cấp [connection sites](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getconnectionsitecount/) không. Nếu không có hoặc số lượng bằng 0, việc dán không khả dụng; trong trường hợp đó, hãy sử dụng các đầu nối tự do và định vị chúng theo cách thủ công. Thông thường nên kiểm tra số lượng site trước khi gắn.

**Điều gì xảy ra với một connector nếu tôi xóa một trong các hình đã kết nối?**

Các đầu của connector sẽ bị tách rời; connector vẫn còn trên slide như một đường thẳng thông thường với đầu/start và end tự do. Bạn có thể xóa nó hoặc gán lại các kết nối và, nếu cần, sử dụng [reroute](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/reroute/).

**Các ràng buộc của connector có được giữ lại khi sao chép một slide sang bản trình bày khác không?**

Thông thường có, miễn là các hình mục tiêu cũng được sao chép. Nếu slide được chèn vào tệp khác mà không có các hình đã kết nối, các đầu sẽ trở thành tự do và bạn sẽ cần gắn lại chúng.