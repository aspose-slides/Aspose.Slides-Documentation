---
title: Quản lý connector trong bài thuyết trình bằng Java
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
- điểm kết nối
- điểm điều chỉnh
- kết nối các hình dạng
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, gắn, định tuyến lại, điều chỉnh và kiểm tra các connector thẳng, uốn và cong của PowerPoint bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Một connector là một đường có thể vẫn gắn vào hai hình dạng khi bất kỳ hình dạng nào di chuyển. Đầu của nó gắn vào các điểm kết nối, được biểu thị bằng các chấm xanh trong PowerPoint. Một số connector uốn cong và cong cũng hiển thị các điểm điều chỉnh, được biểu thị bằng các chấm cam, kiểm soát vị trí của các đoạn connector riêng lẻ.

Aspose.Slides biểu diễn connector thông qua giao diện [IConnector](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iconnector/). Bạn có thể tạo chúng, gắn đầu vào các hình dạng, chọn các điểm kết nối, định tuyến lại và sửa đổi hình học của các connector có điểm điều chỉnh.

## **Các loại Connector**

Lớp [ShapeType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapetype/) bao gồm các mẫu connector thẳng, uốn và cong. Bảng sau cho thấy các hình học connector có sẵn và số điểm điều chỉnh được định nghĩa cho mỗi mẫu.

| Connector | Image | Số điểm điều chỉnh |
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

Số lượng và ý nghĩa của các điểm điều chỉnh là một phần của mẫu connector đã chọn. Không nên giả định rằng hai loại connector khác nhau sẽ hiển thị cùng một bố cục bộ sưu tập.

## **Kết nối Hai Hình Dạng**

Sử dụng [IShapeCollection.addConnector](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) để thêm một connector, và sử dụng [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) và [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) để gắn đầu của nó. Sau khi cả hai đầu đã được gắn, [IConnector.reroute](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iconnector/#reroute--) sẽ chọn một tuyến ngắn giữa các hình dạng.

Ví dụ sau kết nối một ellipse và một rectangle bằng một bent connector:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Cảnh báo" %}}

Gọi `reroute` có thể thay đổi các giá trị [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) và [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-). Gán các điểm kết nối cụ thể sau khi định tuyến lại nếu các điểm đó phải cố định.

{{% /alert %}}

## **Chọn Một Điểm Kết Nối**

Mỗi hình dạng có thể kết nối báo cáo số lượng điểm thông qua [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Xác thực một chỉ mục điểm dựa trên zero trước khi gán nó cho đầu connector; số điểm tùy thuộc vào hình học của hình dạng.

Ví dụ này gắn connector vào một điểm cụ thể trên ellipse khi điểm đó tồn tại:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Điều Chỉnh Một Điểm Connector**

Các connector có điểm điều chỉnh sẽ hiển thị chúng thông qua [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igeometryshape/#getAdjustments--). Kiểm tra mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/) và kiểm tra giá trị [getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getType--) trước khi thay đổi bằng [setRawValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#setRawValue-long-). Các quy tắc chung để xác định các điều chỉnh hình dạng mẫu được mô tả trong [Shape Manipulation](/slides/vi/java/shape-manipulations/).

Số lượng, thứ tự, ý nghĩa và phạm vi giá trị hợp lệ của các điều chỉnh connector phụ thuộc vào mẫu connector. Kiểu điều chỉnh chỉ đọc, trong khi giá trị điều chỉnh có thể ghi. Phương thức chỉ đọc [getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getName--) cung cấp thông tin nhận dạng bổ sung khi một connector chứa nhiều hơn một điều chỉnh cùng kiểu ngữ nghĩa.

### **Định Tuyến Quanh Một Chướng Ngại Vật**

Trong bố cục sau, một connector `BentConnector5` giữa hai hình dạng đi qua một hình dạng thứ ba:

![connector-obstruction](connector-obstruction.png)

Đoạn mã này tạo connector bị cản trở:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Di chuyển khúc uốn dọc thay đổi tuyến đường sao cho connector bỏ qua chướng ngại vật:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Thay vì giả định chỉ mục bộ sưu tập `1` luôn đại diện cho khúc uốn dọc, ví dụ này tìm kiếm `ConnectorBendPositionY` và chỉ thay đổi khi kiểu ngữ nghĩa mong đợi hiện hữu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Một `BentConnector5` có hai điều chỉnh `ConnectorBendPositionX` và một `ConnectorBendPositionY`. Nếu kiểu bạn cần xuất hiện nhiều lần, hãy kiểm tra `getName` và hình học đã biết của mẫu trước khi chọn. Nếu một điều chỉnh báo cáo `ShapeAdjustmentType.Custom`, coi ý nghĩa và phạm vi của nó là đặc thù cho mẫu và không thay đổi cho đến khi hợp đồng đó được xác định.

## **Liên Kết Giá Trị Điều Chỉnh với Hình Học Connector**

Đối với các connector uốn, giá trị điều chỉnh có thể được dùng để ước tính vị trí của các đoạn riêng lẻ. Các phép tính này cụ thể cho mỗi mẫu connector:

- `BentConnector4` thường hiển thị một điều chỉnh `ConnectorBendPositionX` và một `ConnectorBendPositionY`.
- Đối với các vị trí uốn này, chia giá trị trả về bởi `getRawValue` cho `100000f` tạo ra phần tỷ lệ của chiều rộng hoặc chiều cao khung connector như trong các ví dụ dưới.
- Khung connector có thể bị quay hoặc lật, vì vậy tọa độ khung phải được biến đổi trước khi so sánh với tọa độ slide.

Các ví dụ sau dùng `getType` để xác định các điều chỉnh trước. Chúng không dùng chỉ mục bộ sưu tập làm định danh di động.

### **Connector Không Được Quay**

Bố cục ban đầu chứa hai hình dạng văn bản được kết nối bằng một `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Ví dụ này kiểm tra connector và lấy các điều chỉnh uốn ngang và dọc:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Để thay đổi cả hai khúc uốn, tìm mỗi kiểu mong đợi và sửa đổi giá trị chỉ sau khi cả hai đã được tìm thấy:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Kết quả là một connector mà các đoạn ngang và dọc đã di chuyển:

![connector-adjusted-1](connector-adjusted-1.png)

Khi đã biết các kiểu ngữ nghĩa, giá trị của chúng có thể được chuyển đổi thành tọa độ khung connector. Ví dụ này vẽ một hình chữ nhật mỏng lên đoạn dọc được điều khiển bởi hai điều chỉnh uốn:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Hình dạng hướng dẫn đánh dấu đoạn đã tính toán:

![connector-adjusted-2](connector-adjusted-2.png)

### **Connector Được Quay Hoặc Lật**

Khi cùng một hình học connector được định hướng dọc, các giá trị của [IShape.getFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeframe/#getFlipH--), và [ShapeFrame.getFlipV](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeframe/#getFlipV--) ảnh hưởng đến việc chuyển đổi từ tọa độ khung connector sang tọa độ slide.

Ví dụ này tạo và điều chỉnh connector định hướng dọc:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Connector đã chỉnh trở nên dọc giữa các hình dạng:

![connector-adjusted-3](connector-adjusted-3.png)

Với một góc quay tùy ý `alpha`, quay một điểm khung connector `(x, y)` quanh trung tâm khung `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Đoạn mã dưới đây xử lý hướng 90 độ được dùng trong ví dụ và vẽ một hướng dẫn màu đỏ lên đoạn connector tương ứng:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Hướng dẫn màu đỏ đánh dấu đoạn đã tính toán sau khi biến đổi tọa độ:

![connector-adjusted-4](connector-adjusted-4.png)

Các công thức này mô tả các mẫu được dùng trong ví dụ, không phải mô hình connector chung. Hãy xác thực kiểu điều chỉnh, hướng khung và phạm vi giá trị trước khi áp dụng cùng một phép tính cho mẫu khác.

## **Tìm Góc Hướng Của Connector**

Hướng của một straight connector có thể tính từ chiều rộng và chiều cao, cộng với việc áp dụng lật ngang và dọc. Ví dụ sau báo cáo góc theo chiều kim đồng hồ tính từ trục ngang dương trong tọa độ slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một connector có thể gắn vào một hình dạng không?**

Kiểm tra giá trị [getConnectionSiteCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getConnectionSiteCount--) của hình dạng. Giá trị dương có nghĩa là hình dạng cung cấp các điểm kết nối. Xác thực chỉ mục điểm đã chọn trước khi gán cho bất kỳ đầu connector nào.

**Tôi có thể xác định một điểm điều chỉnh connector bằng chỉ mục bộ sưu tập không?**

Chỉ mục chỉ có ý nghĩa đối với một mẫu connector đã biết và bố cục bộ sưu tập. Kiểm tra [IAdjustValue.getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getType--) trước khi sửa đổi giá trị, và sử dụng [IAdjustValue.getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getName--) như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.

**Điều gì xảy ra khi một hình dạng đã được kết nối bị xóa?**

Đầu connector tương ứng sẽ bị tách rời. Connector vẫn còn trên slide và có thể bị xóa, đặt làm một đường tự do, hoặc gắn lại vào một hình dạng khác.

**Các ràng buộc connector có được giữ lại khi sao chép slide không?**

Các ràng buộc thường được giữ lại khi các hình dạng được kết nối cùng với slide được sao chép. Nếu một connector được sao chép mà không có một trong các hình dạng mục tiêu, đầu bị ảnh hưởng phải được gắn lại.