---
title: Quản lý các hình dạng trong bản trình chiếu bằng JavaScript
linktitle: Thao tác hình dạng
type: docs
weight: 40
url: /vi/nodejs-java/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình trên slide
- tìm hình
- sao chép hình
- xóa hình
- ẩn hình
- thay đổi thứ tự hình
- lấy ID hình interop
- văn bản thay thế của hình
- điểm điều chỉnh hình
- điều chỉnh hình preset
- hình học của hình
- định dạng bố cục hình
- hình dưới dạng SVG
- hình sang SVG
- căn chỉnh hình
- lật hình
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu với Aspose.Slides cho Node.js via Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java đại diện cho các hình dạng trên một trang trình chiếu dưới dạng một [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên giải thích cách xác định một hình dạng một cách đáng tin cậy và sửa đổi các điểm điều chỉnh hình dạng đã định sẵn, sau đó trình bày cách sao chép, xóa, ẩn và thay đổi thứ tự các hình dạng. Các phần cuối cùng bao gồm định dạng ở mức bố cục, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng những thao tác cần thiết cho quy trình của mình.

## **Xác định và Tìm Kiếm Hình Dạng**

Chỉ mục trong bộ sưu tập thuận tiện khi xử lý một tệp đã biết, nhưng chúng không phải là định danh cố định. Thêm, xóa hoặc thay đổi thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Chọn một định danh tùy theo cách trình chiếu được tạo và bảo trì:

- [Name](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getname/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy tắc đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getalternativetext/) hữu ích khi một mô tả khả năng tiếp cận hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được địa phương hoá hoặc viết lại cho khả năng tiếp cận, và không được đảm bảo là duy nhất. Đừng lạm dụng văn bản khả năng tiếp cận có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một trang và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng đã sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng của nó.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getuniqueid/) liên quan trả về một định danh có phạm vi trong bản trình chiếu, nhưng định danh đó được dự định cho các add‑in và có thể được gán lại. Nó không nên được coi là một khóa bên ngoài vĩnh viễn. Nếu nhận dạng dài hạn là cần thiết, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn còn tồn tại.

Ví dụ sau tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop có phạm vi trong slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Khi một thao tác cụ thể cho một loại hình dạng, hãy kiểm tra lớp runtime trước khi sử dụng các thành viên đặc thù loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Xác định và Sửa Đổi Các Điểm Điều Chỉnh Hình Dạng Được Định Sẵn**

Các hình dạng có hình học đã được định sẵn có thể lộ các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ đọc [GeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/geometryshape/). Bộ sưu tập này được cung cấp bởi hình dạng, nhưng mỗi [AdjustValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/) chứa một giá trị có thể được thay đổi.

Đừng chỉ dựa vào một chỉ mục bộ sưu tập cố định. Duyệt qua các điều chỉnh và kiểm tra phương thức chỉ đọc [getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/) , giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapeadjustmenttype/) của nó mô tả điều chỉnh kiểm soát gì. Phương thức chỉ đọc [getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/getname/) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa nhiều hơn một điều chỉnh có cùng kiểu ngữ nghĩa.

Sử dụng phương thức giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước góc bo tròn | [setRawValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Độ dày đuôi mũi tên | `setRawValue` |
| `ArrowheadLength` | Độ dài đầu mũi tên | `setRawValue` |
| `ArrowheadWidth` | Độ rộng đầu mũi tên | `setRawValue` |
| `StartAngle` | Góc bắt đầu của bánh tròn hoặc cung | [setAngleValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Góc kết thúc của bánh tròn hoặc cung | `setAngleValue` |

`getType` và `getName` trả về thông tin chỉ đọc. `getRawValue` và `setRawValue` làm việc với một số nguyên trong đơn vị hình học gốc của preset, trong khi `getAngleValue` và `setAngleValue` làm việc với góc tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset được trả về bởi [GeometryShape.getShapeType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/geometryshape/). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho một preset khác.

Khi `getType` trả về `ShapeAdjustmentType.Custom`, API không nhận ra ý nghĩa ngữ nghĩa tiêu chuẩn. Kiểm tra `getName`, kiểu preset và giá trị hiện tại, và để nguyên điều chỉnh trừ khi bạn biết ý nghĩa và phạm vi mong đợi. Ngay cả với các kiểu được công nhận, hãy kiểm tra xem cùng một kiểu có xuất hiện hơn một lần hay không trước khi chọn một giá trị. Bài viết về [Connector](/slides/vi/nodejs-java/connector/) minh họa tình huống này với các điều chỉnh uốn cong của connector.

Ví dụ hoàn chỉnh sau tạo các phiên bản mặc định và đã sửa đổi của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo tên và kiểu, thay đổi các giá trị liên quan đến kích thước qua `setRawValue`, thay đổi góc qua `setAngleValue`, và lưu kết quả. Cột bên trái giữ hình học mặc định; cột bên phải hiển thị hình chữ nhật bo tròn đã điều chỉnh, mũi tên bốn chiều và bánh tròn.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Thêm tiêu đề cho các cột hình dạng mặc định và đã điều chỉnh.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kiểm tra kiểu ngữ nghĩa trước khi thay đổi giá trị giúp mã rõ ràng về mục đích và tránh giả định rằng một chỉ mục bộ sưu tập cụ thể có cùng ý nghĩa trên các preset khác nhau.

## **Sửa Đổi Bộ Sưu Tập Hình Dạng**

Các phương thức thêm, sao chép, xóa và thay đổi thứ tự hoạt động ngay trên bộ sưu tập. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được ghi lại trước thao tác đó.

### **Sao Chép Một Hình Dạng**

[addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/addclone/) tạo một bản sao độc lập và đính vào bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó tại chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn một bản sao thứ hai ở phía sau. Thay đổi trên bất kỳ bản sao nào cũng không làm thay đổi hình dạng nguồn.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sao chép sao chép nội dung và định dạng của hình, bao gồm tên và văn bản thay thế. Gán định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được sử dụng bởi các hình dạng phức tạp do bản trình chiếu quản lý, nhưng bản sao vẫn là một mục mới trong bộ sưu tập với định danh hình dạng mới.

### **Xóa Hình Dạng**

[remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả trong quá trình lặp có chỉ mục, hãy duyệt từ cuối lên đầu để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng tại chỉ mục hiện tại và không giả định kiểu hình dạng cụ thể.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sau khi xóa, số lượng hình dạng và các chỉ mục của các hình dạng sau thay đổi. Tham chiếu tới các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với việc lưu lại các chỉ mục. Cũng cần cân nhắc các connector, animation và các tính năng khác của bản trình chiếu có thể tham chiếu tới đối tượng đã bị xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn cả ngoại hình của slide.

### **Ẩn Một Hình Dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/sethidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong chế độ chiếu slide bình thường. Chỉ mục, định dạng và nội dung của nó vẫn có sẵn cho mã, vì vậy việc ẩn phù hợp cho các yếu tố tùy chọn có thể khôi phục lại sau này.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ẩn không đồng nghĩa với việc xóa hay bảo mật. Đối tượng vẫn có thể được phát hiện và bỏ ẩn bởi người dùng hoặc mã, và nó vẫn là một phần của tệp bản trình chiếu.

### **Thay Đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/reorder/) di chuyển một hình dạng hiện có tới một chỉ mục mục tiêu mà không sao chép nó. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình chữ nhật được tạo đầu tiên và ban đầu nằm sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ thêm hoặc chèn các mục mới vào bộ sưu tập và có thể thay đổi thứ tự chồng mong muốn.

## **Kiểm Tra Các Hình Dạng Trên Slide Bố Cục**

Slide thường, slide bố cục và slide chủ có các bộ sưu tập hình dạng riêng. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng ở vị trí tương tự trên slide thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do bố cục cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getfillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getlineformat/) của mỗi hình dạng bố cục mà không giả định mọi hình dạng đều là `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Việc chỉnh sửa một bố cục có thể ảnh hưởng đến nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố cục, hãy xác định xem một slide thường có kế thừa đối tượng này hay chứa một ghi đè cục bộ, và kiểm tra mọi slide sử dụng bố cục đó.

## **Xuất Hình Dạng Ra SVG**

[writeAsSvg](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không có nền toàn slide hay các hình dạng lân cận.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì riêng lẻ một hình dạng. Người gọi sở hữu luồng và phải đóng nó.

## **Căn Chỉnh Các Hình Dạng**

Các overload của [SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/alignshapes/) căn chỉnh tất cả các hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm, hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để dùng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương đối với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Căn chỉnh thay đổi vị trí, không phải z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ số hình để xác định khoảng cách. Tính lại chỉ mục nếu bạn chỉnh sửa bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapeframe/) lưu vị trí, kích thước, thiết lập lật ngang và dọc, và góc quay. Các giá trị `getFlipH` và `getFlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái chưa xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình không được lật.

![Hình trước khi lật](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai thiết lập lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/setframe/) mới sẽ thay thế toàn bộ khung.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình đã lưu được lật ngược cả chiều ngang và chiều dọc trong khi giữ nguyên vị trí, kích thước và góc quay.

![Hình sau khi lật](flipped_shape.png)

## **FAQ**

**Có nên dùng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng trong quá trình xử lý ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên quy tắc `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi trong slide.

**Ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn nằm trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm, thay đổi thứ tự, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng sao chép lại xuất hiện trước một hình dạng khác?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước của z‑order. Sử dụng `insertClone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi tất cả các hình dạng đã được thêm.

**Có thể dùng chỉ mục cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ được sau khi xác thực preset và bố trí bộ sưu tập chính xác. Ưu tiên duyệt qua `GeometryShape.getAdjustments` và kiểm tra `AdjustValue.getType`; dùng `AdjustValue.getName` như thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện hơn một lần.