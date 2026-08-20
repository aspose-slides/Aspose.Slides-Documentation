---
title: Quản lý các hình dạng trong bản trình chiếu bằng JavaScript
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/nodejs-java/shape-manipulations/
keywords:
- Hình dạng PowerPoint
- Hình dạng bản trình chiếu
- Hình dạng trên slide
- Tìm hình dạng
- Sao chép hình dạng
- Xóa hình dạng
- Ẩn hình dạng
- Thay đổi thứ tự hình dạng
- Lấy ID hình dạng interop
- Văn bản thay thế của hình dạng
- Định dạng bố cục hình dạng
- Hình dạng dưới dạng SVG
- Chuyển hình dạng sang SVG
- Căn chỉnh hình dạng
- Lật hình dạng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách xác định, sao chép, xóa, ẩn, sắp xếp lại, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java đại diện cho các hình dạng trên một slide dưới dạng một [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng, vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy, sau đó cho thấy cách sao chép, xóa, ẩn và sắp xếp lại các hình dạng. Các phần cuối cùng bao gồm định dạng cấp bố cục, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình của bạn yêu cầu.

## **Xác định và Tìm Kiếm Hình Dạng**

Các chỉ mục trong bộ sưu tập thuận tiện khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc thay đổi thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách mà bản trình chiếu được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getname/) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy tắc đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getalternativetext/) hữu dụng khi một mô tả khả năng tiếp cận hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho khả năng tiếp cận, và không được đảm bảo là duy nhất. Đừng lạm dụng văn bản khả năng tiếp cận có ý nghĩa làm khóa cơ sở dữ liệu một cách im lặng.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt thời gian tồn tại của một hình dạng. Một hình dạng được sao chép hoặc tái tạo là một hình dạng khác và nhận ID riêng của nó.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getuniqueid/) liên quan trả về một định danh với phạm vi toàn bộ bản trình chiếu, nhưng định danh đó được dự định cho các add‑in và có thể được gán lại. Nó không nên được coi là một khóa bên ngoài vĩnh viễn. Nếu danh tính lâu dài là cần thiết, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Ví dụ dưới đây tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác cụ thể cho một loại hình dạng, hãy kiểm tra lớp thời gian chạy trước khi sử dụng các thành viên đặc thù loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/).

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

## **Sửa Đổi Bộ Sưu Tập Hình Dạng**

Các phương thức thêm, sao chép, xóa và sắp xếp lại hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước thao tác đó.

### **Sao Chép Một Hình Dạng**

[addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/addclone/) tạo một bản sao độc lập và nối nó vào bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/insertclone/) cũng tạo một bản sao nhưng đặt nó tại một chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có độ rộng và chiều cao có thể thay đổi kích thước đồng thời.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn một bản sao thứ hai vào phía sau. Thay đổi bất kỳ bản sao nào cũng không sửa đổi hình dạng nguồn.

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

Sao chép sao chép nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được xử lý bởi bản trình chiếu, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Hình Dạng**

[remove](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/remove/) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả khớp trong quá trình duyệt có chỉ mục, hãy duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng tại chỉ mục hiện tại và không giả định một loại hình dạng cụ thể.

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

Sau khi xóa, số lượng hình dạng và các chỉ mục của các hình dạng sau thay đổi. Tham chiếu đến các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần xem xét các connector, animation và các tính năng khác của bản trình chiếu có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi nhiều hơn chỉ hình ảnh của slide.

### **Ẩn Một Hình Dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/sethidden/) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong chế độ trình chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy việc ẩn phù hợp cho các yếu tố tùy chọn có thể được khôi phục sau này.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã khám phá và bật lại, và nó vẫn là một phần của tệp bản trình chiếu.

### **Thay Đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự của bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/reorder/) di chuyển một hình dạng hiện có đến một chỉ mục đích mà không sao chép nó. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

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

Hình chữ nhật được tạo đầu tiên và ban đầu nằm sau hình ellipse. Di chuyển nó đến chỉ mục cuối cùng sẽ đặt nó lên phía trước. Hoàn thiện z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ nối hoặc chèn các mục mới vào bộ sưu tập và có thể làm thay đổi ngăn xếp mong muốn.

## **Kiểm Tra Hình Dạng Trên Các Slide Bố Cục**

Các slide bình thường, slide bố cục và slide master có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng có vị trí tương tự trên một slide bình thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do một bố cục cung cấp.

Ví dụ dưới đây đọc [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getfillformat/) và [LineFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getlineformat/) của mỗi hình dạng bố cục mà không giả định mọi hình dạng đều là `AutoShape`.

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

Việc chỉnh sửa một bố cục có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố cục, hãy xác định liệu một slide bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và kiểm tra mọi slide sử dụng bố cục đó.

## **Xuất Hình Dạng Thành SVG**

[writeAsSvg](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/) ghi nội dung đã render của một hình dạng vào một stream. Kết quả chỉ chứa hình dạng, không phải toàn bộ nền slide hay các hình dạng lân cận.

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

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu stream và phải đóng nó.

## **Căn Chỉnh Hình Dạng**

Các overload của [SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/alignshapes/) căn chỉnh tất cả các hình dạng hoặc các chỉ mục bộ sưu tập được chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapesalignmenttype/) chỉ định cạnh, đường trung tâm, hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên cùng của slide. Các tham chiếu hình dạng trả về được chuyển sang chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không thay đổi z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại các chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và quay. Các giá trị `getFlipH` và `getFlipV` của nó sử dụng [NullableBool](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái không xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình dạng chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/setframe/) mới sẽ thay thế toàn bộ khung.

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

Hình dạng đã lưu được sao chép ngược chiều ngang và dọc trong khi giữ nguyên vị trí, kích thước và quay.

![The shape after flipping](flipped_shape.png)

## **Câu hỏi thường gặp**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh hình dạng không?**

Chỉ nên dùng trong các quy trình ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên một quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Việc ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn nằm trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm, sắp xếp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng được sao chép lại xuất hiện phía trước một hình dạng khác?**

`addClone` nối bản sao vào cuối bộ sưu tập, tức là phía trước trong z‑order. Sử dụng `insertClone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi tất cả các hình dạng đã được thêm.