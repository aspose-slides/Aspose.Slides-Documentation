---
title: Quản lý các hình dạng bài thuyết trình trên Android
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/androidjava/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bài thuyết trình
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- điểm điều chỉnh hình dạng
- điều chỉnh hình dạng đã định sẵn
- hình học hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- chuyển hình dạng sang SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, sắp xếp lại, xuất, căn chỉnh và lật các hình dạng trong bài thuyết trình bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Aspose.Slides for Android via Java biểu diễn các hình dạng trên một slide dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và chỉnh sửa các hình dạng, vừa là nguồn cung cấp thứ tự xếp chồng của chúng: chỉ số `0` là hình dạng ở phía sau nhất, trong khi chỉ số cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy và chỉnh sửa các điểm điều chỉnh hình dạng đã định sẵn, sau đó trình bày cách sao chép, xóa, ẩn và sắp xếp lại các hình dạng. Các phần cuối cùng bao gồm định dạng ở mức layout, xuất SVG, căn chỉnh và thiết lập lật. Mỗi ví dụ đều độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình của bạn yêu cầu.

## **Xác định và Tìm kiếm Hình dạng**

Các chỉ số trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp xếp lại một hình dạng có thể làm thay đổi chỉ số của nó. Hãy chọn định danh dựa trên cách bài thuyết trình được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getName--) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy tắc đặt tên nếu mã của bạn phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getAlternativeText--) hữu dụng khi một mô tả khả năng truy cập hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được địa phương hoá hoặc viết lại cho khả năng truy cập, và không được đảm bảo là duy nhất. Đừng lặng lẽ dùng lại văn bản khả năng truy cập có ý nghĩa làm khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) là một định danh chỉ-đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Dùng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt thời gian tồn tại của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và sẽ nhận ID riêng của nó.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getUniqueId--) liên quan trả về một định danh có phạm vi trong toàn bài thuyết trình, nhưng định danh này dành cho các add‑in và có thể được gán lại. Không nên xem nó như một khóa ngoại permanen. Nếu nhận dạng lâu dài là cần thiết, hãy lưu ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Ví dụ sau tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Khi một thao tác đặc thù với loại hình dạng, hãy kiểm tra giao diện trước khi sử dụng các thành viên riêng loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ nếu đối tượng có tên là một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Xác định và Chỉnh sửa Các Điều chỉnh Hình dạng Được Đặt Trước**

Các hình dạng hình học đã định sẵn có thể cung cấp các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ-đọc [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Bộ sưu tập này được cung cấp bởi hình dạng, nhưng mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iadjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ số bộ sưu tập cố định. Duyệt qua các điều chỉnh và kiểm tra phương thức chỉ-đọc [getType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iadjustvalue/#getType--) , trong đó giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapeadjustmenttype/) mô tả điều chỉnh điều khiển gì. Phương thức chỉ-đọc [getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iadjustvalue/#getName--) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa nhiều hơn một điều chỉnh có cùng loại ngữ nghĩa.

Sử dụng phương pháp giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước góc bo tròn | [setRawValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Độ dày phần đuôi mũi tên | `setRawValue` |
| `ArrowheadLength` | Độ dài đầu mũi tên | `setRawValue` |
| `ArrowheadWidth` | Độ rộng đầu mũi tên | `setRawValue` |
| `StartAngle` | Góc bắt đầu của phần bánh hoặc cung | [setAngleValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Góc kết thúc của phần bánh hoặc cung | `setAngleValue` |

`getType` và `getName` trả về thông tin chỉ-đọc. `getRawValue` và `setRawValue` làm việc với một số nguyên trong đơn vị hình học gốc của preset, trong khi `getAngleValue` và `setAngleValue` làm việc với góc tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset [ShapeType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho preset khác.

Khi `getType` trả về `ShapeAdjustmentType.Custom`, API không nhận ra ý nghĩa ngữ nghĩa chuẩn. Kiểm tra `getName`, loại preset và giá trị hiện có, và để nguyên điều chỉnh nếu không biết chắc ý nghĩa và phạm vi. Ngay cả với các kiểu đã được nhận diện, cũng hãy kiểm tra xem cùng một kiểu xuất hiện hơn một lần hay không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/androidjava/connector/) minh họa tình huống này với các điều chỉnh uốn cong của connector.

Ví dụ hoàn chỉnh sau tạo các phiên bản mặc định và đã chỉnh sửa của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo tên và loại, thay đổi các giá trị liên quan tới kích thước qua `setRawValue`, thay đổi góc qua `setAngleValue`, và lưu kết quả. Cột trái giữ hình học mặc định; cột phải hiển thị hình chữ nhật bo tròn đã chỉnh, mũi tên bốn chiều và phần bánh.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm tiêu đề cho các cột hình dạng mặc định và đã điều chỉnh.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kiểm tra loại ngữ nghĩa trước khi thay đổi giá trị làm cho mã rõ ràng về ý định và tránh giả định rằng một chỉ số bộ sưu tập cụ thể có cùng ý nghĩa trên các preset hình dạng khác nhau.

## **Chỉnh sửa Bộ sưu tập Hình dạng**

Các phương pháp add, clone, remove và reorder hoạt động ngay trên bộ sưu tập. Nếu một thao tác làm thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ số đã lấy trước đó.

### **Sao chép một Hình dạng**

[addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tạo một bản sao độc lập và thêm vào cuối bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) cũng tạo bản sao nhưng đặt nó tại một chỉ số z‑order nhất định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có width và height cũng có thể thay đổi kích thước.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không làm ảnh hưởng đến hình dạng nguồn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sao chép bao gồm nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này cần phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được trình chiếu quản lý, nhưng một bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Hình dạng**

[remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều đối tượng khớp trong quá trình duyệt có chỉ số, hãy duyệt từ cuối danh sách để mỗi chỉ số còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng tại chỉ số hiện tại, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng một cách không cần thiết.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sau khi xóa, số lượng hình dạng và các chỉ số của các hình dạng sau thay đổi. Tham chiếu tới các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với việc lưu các chỉ số. Cũng cần cân nhắc các connector, hoạt ảnh và các tính năng khác của bài thuyết trình có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn chỉ ngoại hình của slide.

### **Ẩn một Hình dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó hiển thị trong chế độ trình chiếu bình thường. Chỉ số, định dạng và nội dung của nó vẫn có sẵn cho mã, vì vậy ẩn thích hợp cho các thành phần tùy chọn có thể được khôi phục sau này.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể bị người dùng hoặc mã phát hiện và bật lại, và nó vẫn là một phần của tệp trình chiếu.

### **Thay đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự của bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) di chuyển một hình dạng hiện có tới một chỉ số đích mà không sao chép nó. Chỉ số `0` là phía sau; `size() - 1` là phía trước.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau ellipse. Di chuyển nó tới chỉ số cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ chèn hoặc thêm mục mới vào bộ sưu tập và có thể thay đổi thứ tự chồng dự kiến.

## **Kiểm tra Các Hình dạng trên Layout Slides**

Slide bình thường, layout slide và master slide có các bộ sưu tập hình dạng riêng. Một hình dạng trong bộ sưu tập layout không phải là cùng một đối tượng với một hình dạng có vị trí tương tự trên slide bình thường. Kiểm tra các hình dạng layout khi bạn cần hiểu hoặc thay đổi định dạng được layout cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getFillFormat--) và [LineFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getLineFormat--) của mỗi hình dạng layout mà không giả định rằng mọi hình dạng đều là `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Chỉnh sửa một layout có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng layout, hãy xác định xem slide bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và kiểm tra mọi slide sử dụng layout đó.

## **Xuất Hình dạng ra SVG**

[writeAsSvg](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không phải toàn bộ nền slide hay các hình dạng lân cận.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Giữ bài thuyết trình mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi chịu trách nhiệm sở hữu luồng và phải đóng nó.

## **Căn chỉnh Hình dạng**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) có các overload cho phép căn chỉnh tất cả các hình dạng hoặc các chỉ số bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân bố. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt `false` để căn chỉnh các hình dạng đã chọn tương đối với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển thành chỉ số hiện tại ngay trước khi căn chỉnh.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Căn chỉnh thay đổi vị trí, không phải z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân bố ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ số nếu bạn thay đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `getFlipH` và `getFlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái chưa xác định/mặc định.

Bài thuyết trình đầu vào dưới đây chứa một hình dạng chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì việc gán một [Frame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) mới sẽ thay thế toàn bộ khung.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình dạng đã lưu được lật ngang và dọc trong khi giữ nguyên vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **Câu hỏi thường gặp**

**Tôi có nên dùng chỉ số bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng trong quá trình xử lý ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi sử dụng chỉ số. Nên ưu tiên một quy ước `Name` hoặc `AlternativeText` đã được kiểm chứng cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Việc ẩn một hình dạng có loại bỏ nó khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn tồn tại trong bộ sưu tập ở cùng chỉ số. Nó vẫn có thể được tìm, sắp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng sao chép lại xuất hiện phía trước một hình dạng khác?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước trong z‑order. Sử dụng `insertClone` để chọn chỉ số ban đầu hoặc `reorder` sau khi đã thêm tất cả các hình dạng.

**Tôi có thể dùng chỉ số cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ được sau khi xác thực chính xác preset và bố cục bộ sưu tập. Ưu tiên duyệt qua `IGeometryShape.getAdjustments` và kiểm tra `IAdjustValue.getType`; dùng `IAdjustValue.getName` làm thông tin bổ sung khi cùng một loại ngữ nghĩa xuất hiện nhiều lần.