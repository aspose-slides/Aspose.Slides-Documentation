---
title: Quản lý các connector trong bản trình chiếu bằng .NET
linktitle: Connector
type: docs
weight: 10
url: /vi/net/connector/
keywords:
- connector
- loại connector
- điểm connector
- đường connector
- góc connector
- kết nối các hình
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Cho phép các ứng dụng .NET vẽ, kết nối và tự động định tuyến các đường trong slide PowerPoint—đạt được kiểm soát toàn diện đối với các connector thẳng, góc khuỷu và cong."
---
## **Giới thiệu**

Một connector trong PowerPoint là một đường đặc biệt kết nối hoặc liên kết hai hình lại với nhau và vẫn gắn vào các hình ngay cả khi chúng được di chuyển hoặc thay đổi vị trí trên một slide nhất định. 

Các connector thường được gắn vào *điểm kết nối* (điểm màu xanh lục), các điểm này có sẵn trên mọi hình theo mặc định. Điểm kết nối xuất hiện khi con trỏ di chuột đến gần chúng.

*Điểm điều chỉnh* (điểm màu cam), chỉ tồn tại trên một số connector, được sử dụng để thay đổi vị trí và hình dạng của connector.

## **Các loại connector**

Trong PowerPoint, bạn có thể sử dụng các connector thẳng, góc khuỷu (có góc) và cong. 

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

## **Kết nối các hình bằng connector**

1. Tạo một thể hiện của lớp [Bản trình chiếu](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu của slide bằng chỉ số của nó.
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) vào slide bằng phương thức `AddAutoShape` được cung cấp bởi đối tượng `Shapes`.
1. Thêm một connector bằng phương thức `AddConnector` được cung cấp bởi đối tượng `Shapes` và xác định loại connector.
1. Kết nối các hình bằng connector.
1. Gọi phương thức `Reroute` để áp dụng đường kết nối ngắn nhất.
1. Lưu bản trình chiếu.

Mã C# dưới đây cho thấy cách thêm một connector (connector gập) giữa hai hình (một hình ellipse và một hình chữ nhật):

```c#
// Tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation input = new Presentation())
{                
    // Truy cập bộ sưu tập shapes cho một slide cụ thể
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Thêm một autoshape Ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Thêm một autoshape Rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Thêm một shape connector vào bộ sưu tập shapes của slide
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Kết nối các shape bằng connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Gọi reroute để đặt đường ngắn nhất tự động giữa các shape
    connector.Reroute();

    // Lưu bản trình chiếu
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Phương thức `Connector.Reroute` định tuyến lại một connector và buộc nó đi theo đường ngắn nhất có thể giữa các hình. Để đạt được mục tiêu này, phương thức có thể thay đổi các điểm `StartShapeConnectionSiteIndex` và `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Xác định điểm kết nối**
Nếu bạn muốn một connector liên kết hai hình bằng các điểm cụ thể trên các hình, bạn phải chỉ định các điểm kết nối ưa thích của mình theo cách sau:

1. Tạo một thể hiện của lớp [Bản trình chiếu](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu của slide bằng chỉ số của nó.
1. Thêm hai [AutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/autoshape/) vào slide bằng phương thức `AddAutoShape` được cung cấp bởi đối tượng `Shapes`.
1. Thêm một connector bằng phương thức `AddConnector` được cung cấp bởi đối tượng `Shapes` và xác định loại connector.
1. Kết nối các hình bằng connector. 
1. Đặt các điểm kết nối ưa thích trên các hình. 
1. Lưu bản trình chiếu.

Mã C# dưới đây minh họa một thao tác trong đó một điểm kết nối ưa thích được chỉ định:

```c#
// Tạo một lớp Presentation đại diện cho tệp PPTX
using (Presentation presentation = new Presentation())
{
    // Truy cập bộ sưu tập shapes cho một slide cụ thể
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Thêm một shape connector vào bộ sưu tập shapes của slide
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Thêm một autoshape Ellipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Thêm một autoshape Rectangle
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Kết nối các shape bằng connector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Đặt chỉ số điểm kết nối ưa thích trên shape Ellipse
    uint wantedIndex = 6;

    // Kiểm tra xem chỉ số ưa thích có nhỏ hơn số lượng site tối đa không
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Đặt điểm kết nối ưa thích trên autoshape Ellipse
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Lưu bản trình chiếu
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Điều chỉnh điểm connector**

Bạn có thể điều chỉnh một connector hiện có thông qua các điểm điều chỉnh của nó. Chỉ các connector có điểm điều chỉnh mới có thể được thay đổi theo cách này. Xem bảng trong **[Các loại connector.](/slides/vi/net/connector/#types-of-connectors)** 

### **Trường hợp đơn giản**

Xem xét một trường hợp trong đó một connector giữa hai hình (A và B) đi qua một hình thứ ba (C):

![connector-obstruction](connector-obstruction.png)

Mã:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Để tránh hoặc vượt qua hình thứ ba, chúng ta có thể điều chỉnh connector bằng cách di chuyển đường thẳng đứng sang trái như sau:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Các trường hợp phức tạp** 

Để thực hiện các điều chỉnh phức tạp hơn, bạn phải lưu ý các yếu tố sau:

* Một điểm điều chỉnh của connector liên kết chặt chẽ với một công thức tính toán và xác định vị trí của nó. Do đó, việc thay đổi vị trí của điểm có thể thay đổi hình dạng của connector.
* Các điểm điều chỉnh của connector được định nghĩa theo một thứ tự nghiêm ngặt trong một mảng. Các điểm điều chỉnh được đánh số từ điểm bắt đầu của connector đến điểm cuối.
* Giá trị điểm điều chỉnh phản ánh phần trăm chiều rộng/chiều cao của hình connector. 
  * Hình được giới hạn bởi các điểm bắt đầu và kết thúc của connector nhân với 1000. 
  * Điểm thứ nhất, điểm thứ hai và điểm thứ ba lần lượt định nghĩa phần trăm từ chiều rộng, phần trăm từ chiều cao và phần trăm từ chiều rộng (lại một lần nữa).
* Đối với các phép tính xác định tọa độ của các điểm điều chỉnh của connector, bạn phải tính đến góc quay và việc phản chiếu của connector. **Lưu ý** rằng góc quay cho tất cả các connector được hiển thị trong **[Các loại connector](/slides/vi/net/connector/#types-of-connectors)** là 0.

#### **Trường hợp 1**

Xem xét một trường hợp trong đó hai đối tượng khung văn bản được liên kết với nhau bằng một connector:

![connector-shape-complex](connector-shape-complex.png)

Mã:

```c#
// Tạo một lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
// Lấy slide đầu tiên trong bản trình chiếu
ISlide sld = pres.Slides[0];
// Thêm các hình sẽ được nối với nhau bằng một connector
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Thêm một connector
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Xác định hướng của connector
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Xác định màu sắc của connector
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Xác định độ dày của đường connector
connector.LineFormat.Width = 3;

// Nối các hình lại với nhau bằng connector
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Lấy các điểm điều chỉnh cho connector
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Điều chỉnh**

Chúng ta có thể thay đổi giá trị điểm điều chỉnh của connector bằng cách tăng phần trăm chiều rộng và chiều cao tương ứng lên 20 % và 200 %, tương ứng:

```c#
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Kết quả:

![connector-adjusted-1](connector-adjusted-1.png)

Để xác định một mô hình cho phép chúng ta tính toán tọa độ và hình dạng của các phần riêng lẻ của connector, hãy tạo một hình tương ứng với thành phần ngang của connector tại điểm connector.Adjustments[0]:

```c#
// Vẽ thành phần dọc của connector

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Kết quả:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Trường hợp 2**

Trong **Trường hợp 1**, chúng tôi đã minh họa một thao tác điều chỉnh connector đơn giản bằng các nguyên tắc cơ bản. Trong các tình huống bình thường, bạn phải tính đến góc quay của connector và cách hiển thị nó (được đặt bởi connector.Rotation, connector.Frame.FlipH và connector.Frame.FlipV). Bây giờ chúng tôi sẽ trình bày quy trình.

Đầu tiên, hãy thêm một đối tượng khung văn bản mới (**To 1**) vào slide (để kết nối) và tạo một connector (màu xanh lá) mới nối nó với các đối tượng đã tạo trước đó.

```c#
// Tạo một đối tượng binding mới
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Tạo một connector mới
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Kết nối các đối tượng bằng connector vừa tạo
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Lấy các điểm điều chỉnh của connector
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Thay đổi giá trị của các điểm điều chỉnh
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

Kết quả:

![connector-adjusted-3](connector-adjusted-3.png)

Thứ hai, hãy tạo một hình sẽ tương ứng với thành phần ngang của connector đi qua điểm điều chỉnh mới connector.Adjustments[0]. Chúng tôi sẽ sử dụng các giá trị từ dữ liệu connector cho connector.Rotation, connector.Frame.FlipH và connector.Frame.FlipV và áp dụng công thức chuyển đổi tọa độ phổ biến để quay quanh một điểm x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Trong trường hợp của chúng tôi, góc quay của đối tượng là 90 độ và connector được hiển thị theo chiều dọc, vì vậy đây là mã tương ứng:

```c#
// Lưu tọa độ của connector
x = connector.X;
y = connector.Y;
// Sửa tọa độ của connector nếu nó xuất hiện
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Lấy giá trị điểm điều chỉnh làm tọa độ
x += connector.Width * adjValue_0.RawValue / 100000;
//  Chuyển đổi tọa độ vì Sin(90) = 1 và Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Xác định chiều rộng của thành phần ngang bằng cách sử dụng giá trị điểm điều chỉnh thứ hai
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

Kết quả:

![connector-adjusted-4](connector-adjusted-4.png)

Chúng tôi đã minh họa các phép tính liên quan đến điều chỉnh đơn giản và các điểm điều chỉnh phức tạp (có góc quay). Với kiến thức này, bạn có thể phát triển mô hình riêng (hoặc viết mã) để nhận đối tượng `GraphicsPath` hoặc thậm chí đặt giá trị điểm điều chỉnh của connector dựa trên các tọa độ slide cụ thể.

## **Tìm góc của các đường connector**

1. Tạo một thể hiện của lớp [Bản trình chiếu](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
1. Lấy tham chiếu của slide bằng chỉ số của nó.
1. Truy cập hình dạng đường connector. 
1. Sử dụng chiều rộng, chiều cao, chiều cao khung hình và chiều rộng khung hình để tính góc.

Mã C# dưới đây minh họa một thao tác trong đó chúng tôi tính toán góc cho một hình dạng đường connector:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**Làm sao tôi biết một connector có thể “dán” vào một hình cụ thể không?**

Kiểm tra xem hình có cung cấp [các site kết nối](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/connectionsitecount/) hay không. Nếu không có hoặc số lượng bằng 0, việc dán không khả dụng; trong trường hợp đó, hãy sử dụng các đầu nối tự do và định vị chúng thủ công. Thông thường nên kiểm tra số lượng site trước khi gắn.

**Điều gì sẽ xảy ra với một connector nếu tôi xóa một trong các hình đã kết nối?**

Các đầu của nó sẽ bị tách rời; connector sẽ còn lại trên slide như một đường thẳng thông thường với đầu/bắt đầu tự do. Bạn có thể xóa nó hoặc gán lại các kết nối và, nếu cần, [reroute](https://reference.aspose.com/slides/vi/net/aspose.slides/connector/reroute/).

**Các ràng buộc của connector có được giữ lại khi sao chép slide sang bản trình chiếu khác không?**

Thông thường có, với điều kiện các hình mục tiêu cũng được sao chép. Nếu slide được chèn vào một tệp khác mà không có các hình đã kết nối, các đầu sẽ trở thành tự do và bạn sẽ cần gắn lại chúng.