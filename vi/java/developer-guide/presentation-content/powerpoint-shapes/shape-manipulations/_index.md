---
title: Quản lý các hình dạng trong bài thuyết trình bằng Java
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/java/shape-manipulations/
keywords:
- Hình dạng PowerPoint
- Hình dạng trong bài thuyết trình
- Hình dạng trên slide
- Tìm hình dạng
- Sao chép hình dạng
- Xóa hình dạng
- Ẩn hình dạng
- Thay đổi thứ tự hình dạng
- Lấy ID hình dạng interop
- Văn bản thay thế cho hình dạng
- Điểm điều chỉnh hình dạng
- Điều chỉnh hình dạng preset
- Hình học hình dạng
- Định dạng bố cục hình dạng
- Hình dạng dưới dạng SVG
- Chuyển hình dạng sang SVG
- Căn chỉnh hình dạng
- Lật hình dạng
- PowerPoint
- Bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, sắp xếp lại, xuất, căn chỉnh và lật các hình dạng trong bài thuyết trình bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides for Java biểu diễn các hình dạng trên một slide như một [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng vừa là nguồn của thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy và sửa đổi các điểm điều chỉnh hình dạng đã được xác định trước, sau đó cho thấy cách sao chép, xóa, ẩn và sắp xếp lại các hình dạng. Các phần cuối cùng bao gồm định dạng cấp bố cục, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình công việc của bạn yêu cầu.

## **Xác định và Tìm Kiếm Hình Dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp xếp lại một hình dạng có thể làm thay đổi chỉ mục của nó. Chọn một định danh dựa trên cách bản trình chiếu được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng Chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getAlternativeText--) hữu ích khi mô tả khả năng tiếp cận hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được địa phương hoá hoặc viết lại cho khả năng tiếp cận, và cũng không được đảm bảo là duy nhất. Đừng tự động chuyển đổi văn bản khả năng tiếp cận có ý nghĩa thành khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getUniqueId--) liên quan trả về một định danh có phạm vi toàn bộ bản trình chiếu, nhưng định danh này dành cho add‑in và có thể được gán lại. Không nên coi nó là khóa ngoại việt vĩnh viễn. Nếu tính nhận dạng lâu dài là quan trọng, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn còn tồn tại.

Ví dụ dưới đây tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop trong phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác cụ thể cho một loại hình dạng, kiểm tra giao diện trước khi sử dụng các thành viên riêng loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng được đặt tên là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/).

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

## **Xác định và Sửa Đổi Các Điều Chỉnh Hình Dạng Được Định Nghĩa Trước**

Các hình dạng hình học đã được xác định trước có thể mở ra các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng thông qua bộ sưu tập chỉ đọc [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igeometryshape/#getAdjustments--) . Bộ sưu tập này do hình dạng cung cấp, nhưng mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục cố định trong bộ sưu tập. Duyệt qua các điều chỉnh và kiểm tra phương thức chỉ đọc [getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getType--) , giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeadjustmenttype/) của nó mô tả điều chỉnh điều khiển gì. Phương thức chỉ đọc [getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getName--) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa hơn một điều chỉnh có cùng kiểu ngữ nghĩa.

Sử dụng phương thức giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước góc bo tròn | [setRawValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Độ dày đuôi mũi tên | `setRawValue` |
| `ArrowheadLength` | Độ dài đầu mũi tên | `setRawValue` |
| `ArrowheadWidth` | Độ rộng đầu mũi tên | `setRawValue` |
| `StartAngle` | Góc bắt đầu của một phần tròn hoặc cung | [setAngleValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Góc kết thúc của một phần tròn hoặc cung | `setAngleValue` |

`getType` và `getName` trả về thông tin chỉ đọc. `getRawValue` và `setRawValue` làm việc với một số nguyên theo đơn vị hình học gốc của preset, trong khi `getAngleValue` và `setAngleValue` làm việc với góc tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset [ShapeType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igeometryshape/#getShapeType--). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho preset khác.

Khi `getType` trả về `ShapeAdjustmentType.Custom`, API không nhận ra ý nghĩa ngữ nghĩa tiêu chuẩn. Kiểm tra `getName`, loại preset và giá trị hiện tại, và để nguyên điều chỉnh nếu không biết rõ ý nghĩa và phạm vi mong muốn. Ngay cả với các kiểu đã được công nhận, cũng cần kiểm tra xem cùng một kiểu có xuất hiện nhiều lần không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/java/connector/) minh họa trường hợp này với các điều chỉnh độ cong của connector.

Ví dụ hoàn chỉnh dưới đây tạo các phiên bản mặc định và đã chỉnh sửa của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo tên và kiểu, thay đổi các giá trị liên quan đến kích thước qua `setRawValue`, thay đổi góc qua `setAngleValue`, và lưu kết quả. Cột trái giữ hình học mặc định; cột phải hiển thị hình chữ nhật bo tròn đã chỉnh, mũi tên bốn chiều và phần tròn.

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

Kiểm tra kiểu ngữ nghĩa trước khi thay đổi giá trị giúp mã rõ ràng về mục đích và tránh giả định rằng một chỉ mục bộ sưu tập nhất định có cùng ý nghĩa trên các preset hình dạng khác nhau.

## **Sửa Đổi Bộ Sưu Tập Hình Dạng**

Các phương thức thêm, sao chép, xóa và sắp xếp lại hoạt động ngay trên bộ sưu tập. Nếu một thao tác thay đổi số lượng hoặc thứ tự của các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước khi thực hiện thao tác đó.

### **Sao Chép Một Hình Dạng**

[addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) cũng tạo bản sao nhưng đặt nó ở chỉ mục z‑order được chỉ định. Các overload chấp nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao có thể thay đổi kích thước nó.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn một bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không làm thay đổi hình dạng nguồn.

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

Sao chép bao gồm nội dung và định dạng của hình dạng, bao gồm cả tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên được hình dạng phức tạp sử dụng được xử lý bởi bản trình chiếu, nhưng bản sao vẫn là một mục bộ sưu tập mới với danh tính hình dạng mới.

### **Xóa Các Hình Dạng**

[remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều mục khớp trong quá trình lặp có chỉ mục, hãy duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng tại chỉ mục hiện tại, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng không cần thiết.

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

Sau khi xóa, số lượng hình dạng và các chỉ mục của các hình dạng sau thay đổi. Tham chiếu đến các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng hãy xem xét các connector, hoạt ảnh và các tính năng khác của bản trình chiếu có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn cả vẻ ngoài của slide.

### **Ẩn Một Hình Dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setHidden-boolean-) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi chiếu slide bình thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy việc ẩn thích hợp cho các thành phần tùy chọn có thể được khôi phục sau.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và hiển thị lại, và nó vẫn là một phần của tệp bản trình chiếu.

### **Thay Đổi Z‑Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) di chuyển một hình dạng hiện có tới một chỉ mục đích mà không sao chép nó. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình chữ nhật được tạo trước và ban đầu nằm phía sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện z‑order sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ chèn hoặc thêm mục mới vào bộ sưu tập và có thể làm thay đổi thứ tự dự định.

## **Kiểm Tra Các Hình Dạng Trên Slide Bố Cục**

Slide bình thường, slide bố cục và slide chủ đề có các bộ sưu tập hình dạng riêng. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng tương tự trên slide bình thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do một bố cục cung cấp.

Ví dụ dưới đây đọc [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getFillFormat--) và [LineFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getLineFormat--) của mỗi hình dạng bố cục mà không giả định rằng mọi hình dạng đều là `AutoShape`.

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

Chỉnh sửa một bố cục có thể ảnh hưởng đến nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố cục, xác định xem một slide bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và kiểm tra mọi slide sử dụng bố cục đó.

## **Xuất Một Hình Dạng Ra SVG**

[writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không phải toàn bộ nền slide hay các hình dạng lân cận.

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

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải đóng nó.

## **Căn Chỉnh Các Hình Dạng**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) có các overload cho phép căn chỉnh tất cả các hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapesalignmenttype/) chỉ ra cạnh, đường trung tâm hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt `false` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng đến cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển sang chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không thay đổi z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật Một Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và quay. Các giá trị `getFlipH` và `getFlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/java/com.aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái chưa xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình dạng chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) mới sẽ thay thế toàn bộ khung.

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

Hình dạng đã lưu được lật ngang và dọc trong khi vẫn giữ vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ đối với quá trình ngắn hạn khi bộ sưu tập không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu do người tạo, hoặc `OfficeInteropShapeId` cho công việc interop trong phạm vi slide.

**Ẩn một hình dạng có làm nó bị loại bỏ khỏi z‑order không?**

Không. Một hình dạng ẩn vẫn còn trong bộ sưu tập tại cùng một chỉ mục. Nó có thể được tìm, sắp xếp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng sao chép lại xuất hiện phía trước một hình dạng khác?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước của z‑order. Sử dụng `insertClone` để chọn chỉ mục khởi đầu hoặc `reorder` sau khi đã thêm tất cả các hình dạng.

**Có thể dùng chỉ mục cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ sau khi xác thực preset và bố cục bộ sưu tập một cách chính xác. Ưu tiên duyệt `IGeometryShape.getAdjustments` và kiểm tra `IAdjustValue.getType`; sử dụng `IAdjustValue.getName` làm thông tin bổ sung khi cùng một kiểu ngữ nghĩa xuất hiện nhiều lần.