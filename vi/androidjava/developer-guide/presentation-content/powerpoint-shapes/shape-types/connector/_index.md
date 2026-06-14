---
title: Quản lý các Connector trong Bản trình chiếu trên Android
linktitle: Kết nối
type: docs
weight: 10
url: /vi/androidjava/connector/
keywords:
- kết nối
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- kết nối các hình
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Cung cấp cho các ứng dụng Java khả năng vẽ, kết nối và tự động định tuyến các đường trong slide PowerPoint trên Android—đạt được kiểm soát hoàn toàn đối với các connector thẳng, gập và cong."
---
## **Giới thiệu**

Một connector trong PowerPoint là một đường đặc biệt kết nối hoặc liên kết hai hình với nhau và vẫn gắn vào các hình ngay cả khi chúng được di chuyển hoặc thay đổi vị trí trên một slide nhất định.

Connector thường được kết nối tới *điểm kết nối* (điểm xanh lá), vốn tồn tại trên tất cả các hình theo mặc định. Các điểm kết nối xuất hiện khi con trỏ di chuột gần chúng.

*Điểm điều chỉnh* (điểm cam), chỉ tồn tại trên một số connector nhất định, được dùng để thay đổi vị trí và hình dạng của connector.

## **Các loại Connector**

Trong PowerPoint, bạn có thể sử dụng các connector thẳng, gập (có góc) và cong.

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

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).  
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.  
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` được cung cấp bởi đối tượng `Shapes`.  
1. Thêm một connector bằng phương thức `addConnector` của đối tượng `Shapes`, xác định loại connector.  
1. Kết nối các hình bằng connector.  
1. Gọi phương thức `reroute` để áp dụng đường kết nối ngắn nhất.  
1. Lưu bản trình chiếu.  

Đoạn mã Java dưới đây cho thấy cách thêm một connector (connector gập) giữa hai hình (hình elip và hình chữ nhật):

```Java
// Tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập bộ sưu tập shapes cho một slide cụ thể
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Thêm một autoshape hình Ellipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Thêm một autoshape hình Rectangle
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Thêm một shape connector vào bộ sưu tập shapes của slide
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Kết nối các shape bằng connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Gọi reroute để thiết lập đường ngắn nhất tự động giữa các shape
    connector.reroute();
    
    // Lưu bản trình chiếu
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Phương thức `Connector.reroute` sẽ định tuyến lại connector và buộc nó lấy đường ngắn nhất có thể giữa các hình. Để đạt mục tiêu này, phương thức có thể thay đổi các điểm `setStartShapeConnectionSiteIndex` và `setEndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Xác định một Điểm Kết Nối**

Nếu bạn muốn một connector liên kết hai hình bằng các điểm cụ thể trên các hình, hãy chỉ định các điểm kết nối ưa thích của bạn theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).  
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.  
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` của đối tượng `Shapes`.  
1. Thêm một connector bằng phương thức `addConnector` của đối tượng `Shapes`, xác định loại connector.  
1. Kết nối các hình bằng connector.  
1. Đặt các điểm kết nối ưa thích trên các hình.  
1. Lưu bản trình chiếu.  

Đoạn mã Java sau minh họa việc chỉ định một điểm kết nối ưa thích:

```java
// Tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập bộ sưu tập shapes cho một slide cụ thể
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Thêm một autoshape hình Ellipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Thêm một autoshape hình Rectangle
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Thêm một shape connector vào bộ sưu tập shapes của slide
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Kết nối các shape bằng connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Đặt chỉ số điểm kết nối ưa thích trên shape Ellipse
    int wantedIndex = 6;

    // Kiểm tra xem chỉ số ưa thích có nhỏ hơn số lượng điểm kết nối tối đa không
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Đặt điểm kết nối ưa thích trên autoshape Ellipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Lưu bản trình chiếu
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Điều chỉnh một Điểm Connector**

Bạn có thể điều chỉnh một connector hiện có thông qua các điểm điều chỉnh của nó. Chỉ những connector có điểm điều chỉnh mới có thể được thay đổi theo cách này. Xem bảng dưới **[Các loại connector](/slides/vi/androidjava/connector/#types-of-connectors)**

### **Trường hợp Đơn giản**

Xem xét một trường hợp trong đó một connector giữa hai hình (A và B) đi qua một hình thứ ba (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Để tránh hoặc vòng qua hình thứ ba, chúng ta có thể điều chỉnh connector bằng cách di chuyển đường thẳng đứng sang trái như sau:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Trường hợp Phức tạp** 

Để thực hiện các điều chỉnh phức tạp hơn, bạn cần lưu ý các điểm sau:

* Một điểm điều chỉnh của connector liên quan chặt chẽ tới một công thức tính toán và xác định vị trí của nó. Do đó, việc thay đổi vị trí điểm có thể làm thay đổi hình dạng của connector.  
* Các điểm điều chỉnh được định nghĩa theo thứ tự nghiêm ngặt trong một mảng. Các điểm được đánh số từ điểm bắt đầu của connector tới điểm kết thúc.  
* Giá trị của điểm điều chỉnh phản ánh phần trăm chiều rộng/chiều cao của hình connector.  
  * Hình được giới hạn bởi các điểm bắt đầu và kết thúc của connector nhân với 1000.  
  * Điểm thứ nhất, thứ hai và thứ ba lần lượt xác định phần trăm từ chiều rộng, phần trăm từ chiều cao và lại phần trăm từ chiều rộng.  
* Khi tính toán tọa độ của các điểm điều chỉnh, bạn phải cân nhắc tới góc quay và việc phản chiếu của connector. **Lưu ý** rằng góc quay cho tất cả các connector được hiển thị dưới **[Các loại connector](/slides/vi/androidjava/connector/#types-of-connectors)** là 0.

#### **Trường hợp 1**

Xem xét một trường hợp trong đó hai đối tượng khung văn bản được nối với nhau bằng một connector:

![connector-shape-complex](connector-shape-complex.png)

```java
// Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    ISlide sld = pres.getSlides().get_Item(0);
    // Thêm các shape sẽ được nối lại với nhau bằng một connector
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Thêm một connector
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Xác định hướng của connector
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Xác định màu của connector
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Xác định độ dày của đường connector
    connector.getLineFormat().setWidth(3);
    
    // Nối các shape lại với nhau bằng connector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Lấy các điểm điều chỉnh cho connector
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Điều chỉnh**

Chúng ta có thể thay đổi giá trị các điểm điều chỉnh của connector bằng cách tăng phần trăm chiều rộng và chiều cao tương ứng lên 20 % và 200 %:

```java
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Kết quả:

![connector-adjusted-1](connector-adjusted-1.png)

Để xác định một mô hình cho phép chúng ta tính tọa độ và hình dạng của từng phần riêng lẻ của connector, hãy tạo một hình tương ứng với thành phần ngang của connector tại điểm `connector.getAdjustments().get_Item(0)`:

```java
// Vẽ thành phần dọc của connector
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Kết quả:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Trường hợp 2**

Trong **Trường hợp 1**, chúng ta đã minh họa một thao tác điều chỉnh đơn giản bằng các nguyên tắc cơ bản. Trong thực tế, bạn cần tính đến góc quay và cách hiển thị của connector (được thiết lập bởi `connector.getRotation()`, `connector.getFrame().getFlipH()` và `connector.getFrame().getFlipV()`). Bây giờ chúng ta sẽ trình bày quy trình.

Đầu tiên, thêm một đối tượng khung văn bản mới (**To 1**) vào slide (để làm điểm kết nối) và tạo một connector (màu xanh lá) mới nối nó tới các đối tượng đã tạo trước đó.

```java
// Tạo một đối tượng ràng buộc mới
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Tạo một connector mới
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
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

Thứ hai, tạo một hình sẽ tương ứng với thành phần ngang của connector đi qua điểm điều chỉnh mới `connector.getAdjustments().get_Item(0)`. Chúng ta sẽ sử dụng các giá trị từ dữ liệu connector cho `connector.getRotation()`, `connector.getFrame().getFlipH()` và `connector.getFrame().getFlipV()` và áp dụng công thức chuyển đổi tọa độ quay quanh một điểm x₀:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Trong trường hợp của chúng ta, góc quay của đối tượng là 90 độ và connector hiển thị theo chiều dọc, vì vậy mã tương ứng là:

```java
// Lưu tọa độ của connector
x = connector.getX();
y = connector.getY();
// Sửa tọa độ của connector trong trường hợp nó xuất hiện
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Lấy giá trị điểm điều chỉnh làm tọa độ
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Chuyển đổi tọa độ vì Sin(90) = 1 và Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Xác định chiều rộng của thành phần ngang bằng cách sử dụng giá trị điểm điều chỉnh thứ hai
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Kết quả:

![connector-adjusted-4](connector-adjusted-4.png)

Chúng ta đã trình bày các phép tính liên quan đến việc điều chỉnh đơn giản và các điểm điều chỉnh phức tạp (có góc quay). Với kiến thức này, bạn có thể xây dựng mô hình riêng (hoặc viết mã) để lấy một đối tượng `GraphicsPath` hoặc thậm chí đặt giá trị các điểm điều chỉnh của connector dựa trên tọa độ slide cụ thể.

## **Tìm Góc của Các Đường Connector**

1. Tạo một thể hiện của lớp.  
1. Lấy tham chiếu tới một slide bằng chỉ số của nó.  
1. Truy cập hình dạng đường connector.  
1. Sử dụng chiều rộng, chiều cao, chiều cao khung hình và chiều rộng khung hình của đường để tính góc.

Đoạn mã Java dưới đây minh họa một thao tác tính góc cho một hình dạng đường connector:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một connector có thể “dán” vào một hình cụ thể không?**

Kiểm tra xem hình có cung cấp [các điểm kết nối](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--) hay không. Nếu không có hoặc số lượng bằng 0, việc dán không khả dụng; trong trường hợp đó, hãy sử dụng các đầu tự do và đặt chúng thủ công. Nên kiểm tra số lượng điểm trước khi gắn.

**Điều gì sẽ xảy ra với một connector nếu tôi xóa một trong các hình đã kết nối?**

Các đầu của nó sẽ bị tách rời; connector vẫn tồn tại trên slide như một đường thường với đầu/start và cuối/end tự do. Bạn có thể xóa nó hoặc gán lại các kết nối và, nếu cần, [reroute](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/connector/#reroute--).

**Các ràng buộc của connector có được giữ lại khi sao chép slide sang một bản trình chiếu khác không?**

Thông thường có, với điều kiện các hình mục tiêu cũng được sao chép. Nếu slide được chèn vào một tệp khác mà không có các hình đã kết nối, các đầu sẽ trở thành tự do và bạn sẽ cần gắn lại chúng.