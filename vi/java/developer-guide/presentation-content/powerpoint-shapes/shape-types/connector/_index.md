---
title: Quản lý các kết nối trong bản trình chiếu bằng Java
linktitle: Kết nối
type: docs
weight: 10
url: /vi/java/connector/
keywords:
- kết nối
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- kết nối các hình
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Cho phép các ứng dụng Java vẽ, kết nối và tự động định tuyến các đường trong slide PowerPoint—đạt được kiểm soát hoàn toàn đối với các kết nối thẳng, góc khuỷu và cong."
---
## **Giới thiệu**

Kết nối PowerPoint là một đường đặc biệt dùng để kết nối hoặc liên kết hai hình dạng lại với nhau và vẫn giữ gắn vào các hình dạng ngay cả khi chúng được di chuyển hoặc thay đổi vị trí trên một slide nhất định.  

Các kết nối thường được gắn vào *điểm kết nối* (điểm xanh lá), các điểm này tồn tại trên mọi hình dạng theo mặc định. Điểm kết nối sẽ xuất hiện khi con trỏ di chuyển gần chúng.  

*Điểm điều chỉnh* (điểm màu cam), chỉ tồn tại trên một số kết nối nhất định, được dùng để thay đổi vị trí và hình dạng của các kết nối.  

## **Các loại kết nối**

Trong PowerPoint, bạn có thể sử dụng các kết nối thẳng, góc khuỷu (có góc) và cong.  

Aspose.Slides cung cấp các kết nối sau:

| Kết nối | Hình ảnh | Số điểm điều chỉnh |
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

## **Kết nối các hình bằng kết nối**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Lấy tham chiếu của slide thông qua chỉ mục của nó.
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` được cung cấp bởi đối tượng `Shapes`.
1. Thêm một kết nối bằng phương thức `addConnector` được cung cấp bởi đối tượng `Shapes` bằng cách định nghĩa loại kết nối.
1. Kết nối các hình bằng kết nối.
1. Gọi phương thức `reroute` để áp dụng đường kết nối ngắn nhất.
1. Lưu bản trình bày.  

Đoạn mã Java này cho bạn thấy cách thêm một kết nối (kết nối gập) giữa hai hình (một hình ellipse và hình chữ nhật):

```Java
// Khởi tạo một lớp trình chiếu đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập bộ sưu tập hình dạng cho một slide cụ thể
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Thêm một hình tự động Ellipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Thêm một hình tự động Rectangle
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Thêm một hình kết nối vào bộ sưu tập hình dạng của slide
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Kết nối các hình bằng kết nối
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Gọi reroute để thiết lập đường ngắn nhất tự động giữa các hình
    connector.reroute();
    
    // Lưu bản trình chiếu
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
`Phương thức `Connector.reroute` sẽ định tuyến lại một kết nối và buộc nó di chuyển theo đường ngắn nhất có thể giữa các hình. Để đạt mục tiêu này, phương thức có thể thay đổi các điểm `setStartShapeConnectionSiteIndex` và `setEndShapeConnectionSiteIndex`. 
{{% /alert %}} 

## **Chỉ định một điểm kết nối**

Nếu bạn muốn một kết nối liên kết hai hình bằng các điểm cụ thể trên các hình, bạn phải chỉ định các điểm kết nối ưa thích của mình theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Lấy tham chiếu của slide thông qua chỉ mục của nó.
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/AutoShape) vào slide bằng phương thức `addAutoShape` được cung cấp bởi đối tượng `Shapes`.
1. Thêm một kết nối bằng phương thức `addConnector` được cung cấp bởi đối tượng `Shapes` bằng cách định nghĩa loại kết nối.
1. Kết nối các hình bằng kết nối. 
1. Đặt các điểm kết nối ưa thích của bạn trên các hình. 
1. Lưu bản trình bày.  

Đoạn mã Java này minh họa một thao tác trong đó một điểm kết nối ưa thích được chỉ định:

```java
// Khởi tạo một lớp trình chiếu đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Truy cập bộ sưu tập hình dạng cho một slide cụ thể
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Thêm một hình tự động Ellipse
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Thêm một hình tự động Rectangle
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Thêm một hình kết nối vào bộ sưu tập hình dạng của slide
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Kết nối các hình bằng kết nối
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Đặt chỉ mục điểm kết nối ưa thích trên hình Ellipse
    int wantedIndex = 6;

    // Kiểm tra xem chỉ mục ưa thích có nhỏ hơn số lượng điểm tối đa không
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Đặt điểm kết nối ưa thích trên hình tự động Ellipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Lưu bản trình chiếu
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Điều chỉnh một điểm kết nối**

Bạn có thể điều chỉnh một kết nối hiện có thông qua các điểm điều chỉnh của nó. Chỉ những kết nối có điểm điều chỉnh mới có thể được thay đổi theo cách này. Xem bảng dưới **[Các loại kết nối.](/slides/vi/java/connector/#types-of-connectors)**  

### **Trường hợp đơn giản**

Xem xét một trường hợp mà một kết nối giữa hai hình (A và B) đi qua một hình thứ ba (C):

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

Để tránh hoặc vượt qua hình thứ ba, chúng ta có thể điều chỉnh kết nối bằng cách di chuyển đường thẳng đứng sang trái như sau:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Trường hợp phức tạp** 

Để thực hiện các điều chỉnh phức tạp hơn, bạn cần lưu ý các yếu tố sau:

* Một điểm điều chỉnh của kết nối liên quan chặt chẽ tới công thức tính toán và xác định vị trí của nó. Vì vậy, việc thay đổi vị trí của điểm có thể làm thay đổi hình dạng của kết nối.  
* Các điểm điều chỉnh của một kết nối được định nghĩa trong một mảng với thứ tự chặt chẽ. Các điểm này được đánh số từ điểm bắt đầu của kết nối tới điểm kết thúc.  
* Giá trị của điểm điều chỉnh phản ánh tỷ lệ phần trăm của chiều rộng/chiều cao của hình dạng kết nối.  
  * Hình dạng được giới hạn bởi các điểm bắt đầu và kết thúc của kết nối nhân với 1000.  
  * Điểm thứ nhất, điểm thứ hai và điểm thứ ba lần lượt xác định tỷ lệ phần trăm từ chiều rộng, tỷ lệ phần trăm từ chiều cao và lại từ chiều rộng.  
* Đối với các phép tính xác định tọa độ của các điểm điều chỉnh của kết nối, bạn phải tính đến góc quay và phản chiếu của kết nối. **Lưu ý** rằng góc quay cho tất cả các kết nối được hiển thị trong **[Các loại kết nối](/slides/vi/java/connector/#types-of-connectors)** là 0.  

#### **Trường hợp 1**

Xem xét một trường hợp mà hai đối tượng khung văn bản được liên kết với nhau qua một kết nối:

![connector-shape-complex](connector-shape-complex.png)

```java
// Khởi tạo một lớp trình chiếu đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên trong bản trình chiếu
    ISlide sld = pres.getSlides().get_Item(0);
    // Thêm các hình sẽ được nối lại với nhau bằng một kết nối
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Thêm một kết nối
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Xác định hướng của kết nối
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Xác định màu sắc của kết nối
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Xác định độ dày của đường kết nối
    connector.getLineFormat().setWidth(3);
    
    // Nối các hình lại với nhau bằng kết nối
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Lấy các điểm điều chỉnh cho kết nối
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Điều chỉnh**

Chúng ta có thể thay đổi giá trị các điểm điều chỉnh của kết nối bằng cách tăng tỷ lệ phần trăm chiều rộng và chiều cao tương ứng lên 20% và 200%, tương ứng:

```java
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Kết quả:

![connector-adjusted-1](connector-adjusted-1.png)

Để xác định một mô hình cho phép chúng ta tính toán tọa độ và hình dạng của các phần riêng lẻ của kết nối, hãy tạo một hình dạng tương ứng với thành phần ngang của kết nối tại điểm `connector.getAdjustments().get_Item(0)`:

```java
// Vẽ thành phần thẳng đứng của kết nối
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Kết quả:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Trường hợp 2**

Trong **Trường hợp 1**, chúng tôi đã minh họa một thao tác điều chỉnh kết nối đơn giản bằng các nguyên tắc cơ bản. Trong các trường hợp bình thường, bạn phải tính đến góc quay của kết nối và cách hiển thị của nó (được đặt bởi `connector.getRotation()`, `connector.getFrame().getFlipH()` và `connector.getFrame().getFlipV()`). Bây giờ chúng tôi sẽ trình bày quy trình.  

Đầu tiên, hãy thêm một đối tượng khung văn bản mới (**To 1**) vào slide (để kết nối) và tạo một kết nối (màu xanh lá) mới để nối nó với các đối tượng đã tạo trước đó.

```java
// Tạo một đối tượng ràng buộc mới
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Tạo một kết nối mới
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Kết nối các đối tượng bằng kết nối vừa tạo
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Lấy các điểm điều chỉnh của kết nối
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Kết quả:

![connector-adjusted-3](connector-adjusted-3.png)

Thứ hai, hãy tạo một hình dạng sẽ tương ứng với thành phần ngang của kết nối đi qua điểm điều chỉnh mới của kết nối `connector.getAdjustments().get_Item(0)`. Chúng ta sẽ sử dụng các giá trị từ dữ liệu kết nối cho `connector.getRotation()`, `connector.getFrame().getFlipH()` và `connector.getFrame().getFlipV()` và áp dụng công thức chuyển đổi tọa độ phổ biến cho phép quay quanh một điểm cho trước x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Trong trường hợp của chúng ta, góc quay của đối tượng là 90 độ và kết nối được hiển thị theo chiều dọc, vì vậy đoạn mã tương ứng là:

```java
// Lưu tọa độ của kết nối
x = connector.getX();
y = connector.getY();
// Điều chỉnh tọa độ của kết nối trong trường hợp nó xuất hiện
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
// Xác định độ rộng của thành phần ngang bằng cách sử dụng giá trị điểm điều chỉnh thứ hai
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Kết quả:

![connector-adjusted-4](connector-adjusted-4.png)

Chúng tôi đã minh họa các phép tính liên quan đến điều chỉnh đơn giản và các điểm điều chỉnh phức tạp (các điểm điều chỉnh có góc quay). Với kiến thức đã học, bạn có thể phát triển mô hình riêng (hoặc viết mã) để lấy một đối tượng `GraphicsPath` hoặc thậm chí đặt giá trị các điểm điều chỉnh của kết nối dựa trên tọa độ slide cụ thể.  

## **Tìm góc của các đường kết nối**

1. Tạo một thể hiện của lớp.  
1. Lấy tham chiếu của slide thông qua chỉ mục của nó.  
1. Truy cập hình dạng đường kết nối.  
1. Sử dụng độ rộng, độ cao của đường, chiều cao khung hình và độ rộng khung hình để tính góc.  

Đoạn mã Java này minh họa một thao tác trong đó chúng tôi tính góc cho một hình dạng đường kết nối:

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

**Làm sao tôi biết một kết nối có thể "dán" vào một hình dạng cụ thể?**  

Kiểm tra xem hình dạng có cung cấp [các điểm kết nối](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getConnectionSiteCount--) hay không. Nếu không có hoặc số lượng bằng 0, việc dán không khả dụng; trong trường hợp này, hãy sử dụng các đầu nối tự do và đặt chúng thủ công. Nên kiểm tra số lượng điểm trước khi gắn.  

**Điều gì xảy ra với một kết nối nếu tôi xóa một trong những hình đã kết nối?**  

Đầu của nó sẽ bị tách rời; kết nối vẫn còn trên slide như một đường thường với đầu/mối tự do. Bạn có thể xóa nó hoặc gán lại các kết nối và, nếu cần, [reroute](https://reference.aspose.com/slides/vi/java/com.aspose.slides/connector/#reroute--).  

**Liệu các ràng buộc của kết nối có được giữ lại khi sao chép một slide sang bản trình bày khác không?**  

Nói chung là có, với điều kiện các hình mục tiêu cũng được sao chép. Nếu slide được chèn vào tệp khác mà không có các hình đã kết nối, các đầu sẽ trở thành tự do và bạn sẽ cần gắn lại chúng.