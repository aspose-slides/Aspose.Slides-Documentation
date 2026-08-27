---
title: Quản lý các đầu nối trong bản trình chiếu bằng .NET
linktitle: Đầu nối
type: docs
weight: 10
url: /vi/net/connector/
keywords:
- đầu nối
- loại đầu nối
- điểm đầu nối
- đường đầu nối
- góc đầu nối
- địa điểm kết nối
- điểm điều chỉnh
- kết nối các hình
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm, gắn, định tuyến lại, điều chỉnh và kiểm tra các đầu nối PowerPoint thẳng, uốn và cong bằng Aspose.Slides cho .NET."
---
## **Tổng quan**

Một connector là một đường có thể gắn giữ hai hình khi một trong hai hình di chuyển. Các đầu của nó gắn vào các site kết nối, được biểu thị bằng các chấm xanh lá trong PowerPoint. Một số connector cong và uốn cũng hiển thị các điểm điều chỉnh, được biểu thị bằng các chấm cam, để kiểm soát vị trí của các đoạn connector riêng lẻ.

Aspose.Slides biểu diễn các connector thông qua giao diện [IConnector](https://reference.aspose.com/slides/vi/net/aspose.slides/iconnector/). Bạn có thể tạo chúng, gắn các đầu vào các hình, chọn site kết nối, reroute chúng và sửa đổi hình học của các connector có điểm điều chỉnh.

## **Các loại connector**

Phân枚列 [ShapeType](https://reference.aspose.com/slides/vi/net/aspose.slides/shapetype/) bao gồm các preset connector thẳng, uốn và cong. Bảng sau hiển thị các hình học connector có sẵn và số điểm điều chỉnh được định nghĩa cho mỗi preset.

| Connector | Image | Number of adjustment points |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Số lượng và ý nghĩa của các điểm điều chỉnh là một phần của preset connector được chọn. Đừng giả định rằng hai loại connector khác nhau sẽ hiển thị cùng một bố cục collection.

## **Kết nối hai hình**

Sử dụng [IShapeCollection.AddConnector](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addconnector/) để thêm một connector, và gán các thuộc tính [StartShapeConnectedTo](https://reference.aspose.com/slides/vi/net/aspose.slides/connector/startshapeconnectedto/) và [EndShapeConnectedTo](https://reference.aspose.com/slides/vi/net/aspose.slides/connector/endshapeconnectedto/). Sau khi cả hai đầu được gắn, [IConnector.Reroute](https://reference.aspose.com/slides/vi/net/aspose.slides/iconnector/reroute/) sẽ chọn một đường ngắn giữa các hình.

Ví dụ sau kết nối một ellipse và một rectangle bằng một bent connector:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Cảnh báo" %}}
Gọi `Reroute` có thể thay đổi các giá trị [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/net/aspose.slides/connector/startshapeconnectionsiteindex/) và [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/net/aspose.slides/connector/endshapeconnectionsiteindex/). Gán các site kết nối cụ thể sau khi reroute nếu các site đó phải cố định.
{{% /alert %}}

## **Chọn vị trí kết nối**

Mỗi hình có thể kết nối sẽ báo cáo số lượng site của nó qua [ConnectionSiteCount](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/connectionsitecount/). Kiểm tra một chỉ số site dựa trên zero trước khi gán nó cho đầu connector; số lượng site thay đổi tùy theo hình học của hình.

Ví dụ này gắn connector vào một site cụ thể trên ellipse khi site đó tồn tại:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **Điều chỉnh điểm connector**

Các connector có điểm điều chỉnh sẽ hiển thị chúng qua [IGeometryShape.Adjustments](https://reference.aspose.com/slides/vi/net/aspose.slides/igeometryshape/adjustments/). Kiểm tra mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/net/aspose.slides/iadjustvalue/) và kiểm tra [Type](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/type/) trước khi thay đổi [RawValue](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/rawvalue/). Các quy tắc chung để nhận dạng các adjustment shape preset được mô tả trong [Shape Manipulation](/slides/vi/net/shape-manipulations/).

Số lượng, thứ tự, ý nghĩa và phạm vi giá trị hợp lệ của các adjustment connector phụ thuộc vào preset connector. Thuộc tính `Type` chỉ đọc, trong khi giá trị adjustment có thể ghi. Thuộc tính chỉ đọc [Name](https://reference.aspose.com/slides/vi/net/aspose.slides/adjustvalue/name/) cung cấp thông tin nhận dạng bổ sung khi một connector chứa hơn một adjustment có cùng kiểu ngữ nghĩa.

### **Định hướng quanh chướng ngại vật**

Trong bố cục dưới đây, một connector `BentConnector5` giữa hai hình đi qua một hình thứ ba:

![connector-obstruction](connector-obstruction.png)

Mã sau tạo connector bị cản trở:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

Di chuyển độ uốn dọc thay đổi đường đi sao cho connector tránh chướng ngại vật:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Thay vì giả định rằng chỉ số collection `1` luôn đại diện cho độ uốn dọc, ví dụ này tìm `ConnectorBendPositionY` và chỉ thay đổi nó khi kiểu ngữ nghĩa mong đợi có mặt:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

Một `BentConnector5` có hai adjustment `ConnectorBendPositionX` và một adjustment `ConnectorBendPositionY`. Nếu kiểu bạn cần xuất hiện hơn một lần, hãy kiểm tra `Name` và hình học đã biết của preset trước khi chọn. Nếu một adjustment báo cáo `ShapeAdjustmentType.Custom`, coi ý nghĩa và phạm vi của nó là đặc thù cho preset và không thay đổi cho đến khi hợp đồng này được xác định.

## **Liên hệ giá trị điều chỉnh với hình học connector**

Đối với các bent connector, giá trị điều chỉnh có thể dùng để ước tính vị trí của các đoạn riêng lẻ. Các phép tính này chỉ áp dụng cho preset connector cụ thể:

- `BentConnector4` thường hiển thị một adjustment `ConnectorBendPositionX` và một `ConnectorBendPositionY`.
- Đối với các vị trí uốn này, `RawValue / 100000f` tạo ra phần tỷ lệ của chiều rộng hoặc chiều cao khung connector được sử dụng trong các ví dụ dưới.
- Khung connector có thể được quay hoặc lật, vì vậy tọa độ khung phải được chuyển đổi trước khi so sánh với tọa độ slide.

Các ví dụ sau dùng `Type` để xác định các adjustment trước. Chúng không coi chỉ số collection là định danh di động.

### **Connector chưa quay**

Bố cục ban đầu chứa hai hình text được kết nối bằng một `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Ví dụ này kiểm tra connector và lấy các adjustment uốn ngang và dọc:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

Để thay đổi cả hai uốn, tìm mỗi kiểu mong đợi và chỉ sửa giá trị sau khi cả hai đã được tìm:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

Kết quả là một connector mà các đoạn ngang và dọc đã di chuyển:

![connector-adjusted-1](connector-adjusted-1.png)

Khi đã biết các kiểu ngữ nghĩa, giá trị của chúng có thể chuyển sang tọa độ khung connector. Ví dụ này vẽ một hình chữ nhật mỏng trên đoạn dọc được điều khiển bởi hai adjustment uốn:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Hình guide đánh dấu đoạn đã tính:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connector quay hoặc lật**

Khi cùng một hình học connector được định hướng dọc, các giá trị [Frame](https://reference.aspose.com/slides/vi/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeframe/fliph/), và [FlipV](https://reference.aspose.com/slides/vi/net/aspose.slides/shapeframe/flipv/) ảnh hưởng tới việc chuyển đổi từ tọa độ khung connector sang tọa độ slide.

Ví dụ này tạo và điều chỉnh connector được định hướng dọc:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

Connector đã điều chỉnh xuất hiện dọc giữa các hình:

![connector-adjusted-3](connector-adjusted-3.png)

Với một góc quay tùy ý `alpha`, quay một điểm khung connector `(x, y)` quanh trung tâm khung `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Mã sau xử lý định hướng 90 độ được dùng trong ví dụ này và vẽ một guide màu đỏ lên đoạn connector tương ứng:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

Guide màu đỏ đánh dấu đoạn đã tính sau khi chuyển đổi tọa độ:

![connector-adjusted-4](connector-adjusted-4.png)

Các công thức này mô tả các preset được dùng trong các ví dụ, không phải mô hình connector chung. Kiểm tra kiểu adjustment, hướng khung và phạm vi giá trị trước khi áp dụng cùng một phép tính cho một preset khác.

## **Tìm góc hướng của connector**

Hướng của một straight connector có thể tính từ chiều rộng và chiều cao của nó, kèm theo các phép lật ngang và dọc. Ví dụ sau báo cáo góc thuận kim đồng hồ từ trục ngang dương trong tọa độ slide:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một connector có thể gắn vào một shape hay không?**  
Kiểm tra `ConnectionSiteCount` của shape. Giá trị dương có nghĩa shape cung cấp các site kết nối. Xác thực chỉ số site được chọn trước khi gán cho bất kỳ đầu connector nào.

**Tôi có thể nhận dạng một adjustment connector bằng chỉ số collection của nó không?**  
Chỉ số chỉ có ý nghĩa đối với một preset connector và bố cục collection đã biết. Kiểm tra `IAdjustValue.Type` trước khi thay đổi giá trị, và dùng `IAdjustValue.Name` làm thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.

**Điều gì xảy ra khi một shape đã được kết nối bị xóa?**  
Đầu connector tương ứng sẽ bị tách rời. Connector vẫn còn trên slide và có thể bị xóa, chuyển thành một đường tự do, hoặc gắn lại vào một shape khác.

**Các ràng buộc connector có được giữ khi sao chép một slide không?**  
Thông thường ràng buộc được giữ khi các shape được kết nối cùng với slide được sao chép. Nếu một connector được sao chép mà không có một trong các shape mục tiêu, đầu bị ảnh hưởng phải được gắn lại nữa.