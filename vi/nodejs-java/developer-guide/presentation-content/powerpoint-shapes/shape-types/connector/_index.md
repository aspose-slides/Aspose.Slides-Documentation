---
title: Quản lý các connector trong bài thuyết trình bằng JavaScript
linktitle: Kết nối
type: docs
weight: 10
url: /vi/nodejs-java/connector/
keywords:
- connector
- loại kết nối
- điểm kết nối
- đường kết nối
- góc kết nối
- vị trí kết nối
- điểm điều chỉnh
- kết nối các hình dạng
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm, gắn, định tuyến lại, điều chỉnh và kiểm tra các connector thẳng, cong và uốn của PowerPoint với Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Một connector là một đường có thể gắn vào hai hình dạng và vẫn duy trì khi một trong hai hình dịch chuyển. Các đầu của nó gắn vào các site kết nối, được biểu thị bằng các dấu chấm xanh lá trong PowerPoint. Một số connector cong và uốn cũng cung cấp các điểm điều chỉnh, được biểu thị bằng các dấu chấm cam, điều khiển vị trí của các đoạn connector riêng lẻ.

Aspose.Slides biểu diễn connector thông qua lớp [Connector](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/). Bạn có thể tạo chúng, gắn đầu vào các hình, chọn site kết nối, định tuyến lại và sửa đổi hình học của các connector có điểm điều chỉnh.

## **Các loại Connector**

Lớp [ShapeType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapetype/) bao gồm các preset connector thẳng, cong và uốn. Bảng sau hiển thị các hình học connector khả dụng và số điểm điều chỉnh được định nghĩa bởi mỗi preset.

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

Số lượng và ý nghĩa của các điểm điều chỉnh là một phần của preset connector được chọn. Đừng cho rằng hai loại connector khác nhau sẽ hiển thị cùng một bố cục collection.

## **Kết nối Hai Hình Dạng**

Sử dụng [ShapeCollection.addConnector](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/addconnector/) để thêm một connector, và dùng [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) cùng [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) để gắn các đầu của nó. Sau khi cả hai đầu đã được gắn, [Connector.reroute](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/reroute/) sẽ chọn một lộ trình ngắn nhất giữa các hình.

Ví dụ sau kết nối một ellipse và một rectangle bằng một bent connector:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Gọi `reroute` có thể làm thay đổi các giá trị [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) và [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Gán các site kết nối cụ thể sau khi định tuyến lại nếu các site đó phải được cố định.
{{% /alert %}}

## **Chọn Một Site Kết Nối**

Mỗi hình có thể kết nối báo cáo số lượng site của mình qua [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Kiểm tra một chỉ mục site dựa trên zero trước khi gán cho đầu connector; số lượng site thay đổi tùy theo hình học của hình.

Ví dụ này gắn connector vào một site cụ thể trên ellipse khi site đó tồn tại:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Điều Chỉnh Một Điểm Connector**

Các connector có điểm điều chỉnh sẽ mở ra chúng qua [GeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/geometryshape/). Kiểm tra từng [AdjustValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/) và kiểm tra giá trị [getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/) trước khi thay đổi bằng [setRawValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Các quy tắc chung để xác định các điều chỉnh shape preset được mô tả trong [Shape Manipulation](/slides/vi/nodejs-java/shape-manipulations/).

Số lượng, thứ tự, ý nghĩa và phạm vi giá trị hợp lệ của các điều chỉnh connector phụ thuộc vào preset connector. Kiểu điều chỉnh là chỉ đọc, trong khi giá trị điều chỉnh có thể ghi. Phương thức chỉ đọc [getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/getname/) cung cấp thông tin nhận dạng bổ sung khi một connector chứa hơn một điều chỉnh có cùng kiểu ngữ nghĩa.

### **Định Tuyến Xung Quanh Một Vật Cản**

Trong bố cục dưới đây, một connector `BentConnector5` giữa hai hình đi qua một hình thứ ba:

![connector-obstruction](connector-obstruction.png)

Mã này tạo connector bị cản:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Di chuyển khúc uốn dọc thay đổi lộ trình sao cho connector bỏ qua vật cản:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Thay vì giả định chỉ mục collection `1` luôn đại diện cho khúc uốn dọc, ví dụ này tìm `ConnectorBendPositionY` và chỉ thay đổi khi kiểu ngữ nghĩa mong đợi xuất hiện:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Một `BentConnector5` có hai điều chỉnh `ConnectorBendPositionX` và một `ConnectorBendPositionY`. Nếu kiểu bạn cần xuất hiện nhiều hơn một lần, kiểm tra `getName` và hình học đã biết của preset trước khi chọn. Nếu một điều chỉnh trả về `ShapeAdjustmentType.Custom`, coi ý nghĩa và phạm vi của nó là đặc thù cho preset và không thay đổi cho đến khi bạn biết rõ hợp đồng.

## **Liên Hệ Giá Trị Điều Chỉnh với Hình Học Connector**

Đối với các bent connector, giá trị điều chỉnh có thể dùng để ước tính vị trí của các đoạn riêng lẻ. Các tính toán này riêng cho preset connector:

- `BentConnector4` thường cung cấp một điều chỉnh `ConnectorBendPositionX` và một `ConnectorBendPositionY`.
- Đối với các vị trí uốn này, chia giá trị trả về bởi `getRawValue` cho `100000` sẽ cho phần thập phân của chiều rộng hoặc chiều cao khung connector như trong các ví dụ dưới.
- Một khung connector có thể bị quay hoặc lật, vì vậy tọa độ khung phải được biến đổi trước khi so sánh với tọa độ slide.

Các ví dụ sau dùng `getType` để xác định các điều chỉnh trước. Chúng không sử dụng chỉ mục collection như định danh di động.

### **Connector Không Được Quay**

Bố cục ban đầu chứa hai hình chữ nhật văn bản được kết nối bởi một `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Ví dụ này kiểm tra connector và lấy các điều chỉnh uốn ngang và dọc:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Để thay đổi cả hai uốn, tìm mỗi kiểu mong đợi và sửa giá trị chỉ sau khi đã tìm được cả hai:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Kết quả là một connector mà các đoạn ngang và dọc đã di chuyển:

![connector-adjusted-1](connector-adjusted-1.png)

Khi các kiểu ngữ nghĩa đã được biết, giá trị của chúng có thể chuyển thành tọa độ khung connector. Ví dụ này vẽ một hình chữ nhật mỏng trên đoạn dọc được điều khiển bởi hai điều chỉnh uốn:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Hình dẫn hướng đánh dấu đoạn được tính toán:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connector Được Quay Hoặc Lật**

Khi cùng một hình học connector được định hướng dọc, các giá trị [Shape.getFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapeframe/getfliph/), và [ShapeFrame.getFlipV](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapeframe/getflipv/) ảnh hưởng đến việc chuyển đổi từ tọa độ khung connector sang tọa độ slide.

Ví dụ này tạo và điều chỉnh connector định hướng dọc:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Connector đã điều chỉnh xuất hiện dọc giữa các hình:

![connector-adjusted-3](connector-adjusted-3.png)

Đối với một góc quay tùy ý `alpha`, quay một điểm khung connector `(x, y)` quanh trung tâm khung `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Mã sau xử lý độ định hướng 90 độ được dùng trong ví dụ này và vẽ một hướng dẫn màu đỏ lên đoạn connector tương ứng:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Hướng dẫn màu đỏ đánh dấu đoạn đã tính toán sau khi biến đổi tọa độ:

![connector-adjusted-4](connector-adjusted-4.png)

Các công thức này mô tả các preset được dùng trong các ví dụ, không phải mô hình connector chung. Kiểm tra kiểu điều chỉnh, hướng khung và phạm vi giá trị trước khi áp dụng cùng một phép tính cho một preset khác.

## **Tìm Góc Hướng Của Connector**

Hướng của một straight connector có thể tính từ chiều rộng và chiều cao của nó, kèm theo các lật ngang và dọc. Ví dụ sau báo cáo góc theo chiều kim đồng hồ từ trục ngang dương trong tọa độ slide:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Làm sao tôi biết một connector có thể gắn vào một hình không?**

Kiểm tra giá trị [getConnectionSiteCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getconnectionsitecount/) của hình. Một số đếm dương nghĩa là hình cung cấp các site kết nối. Kiểm tra chỉ mục site được chọn trước khi gán cho bất kỳ đầu connector nào.

**Tôi có thể xác định một điều chỉnh connector bằng chỉ mục collection không?**

Một chỉ mục chỉ có ý nghĩa đối với một preset connector đã biết và bố cục collection. Kiểm tra [AdjustValue.getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/) trước khi sửa giá trị, và dùng [AdjustValue.getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/getname/) làm thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.

**Điều gì xảy ra khi một hình đã được kết nối bị xóa?**

Đầu connector tương ứng sẽ bị tách rời. Connector vẫn còn trên slide và có thể bị xóa, được đặt như một đường tự do, hoặc gắn lại vào một hình khác.

**Các liên kết connector có được giữ lại khi sao chép slide không?**

Các liên kết thường được bảo lưu khi các hình được kết nối được sao chép cùng slide. Nếu một connector được sao chép mà không có một trong các hình mục tiêu, đầu bị ảnh hưởng phải được gắn lại.