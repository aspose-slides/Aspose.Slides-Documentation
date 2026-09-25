---
title: Quản lý các Hình dạng trong Bản trình chiếu bằng Java
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/java/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- điểm điều chỉnh hình dạng
- điều chỉnh hình dạng preset
- hình học hình dạng
- định dạng bố trí hình dạng
- hình dạng dưới dạng SVG
- hình dạng sang SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách xác định, điều chỉnh, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình dạng trong bản trình chiếu với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides for Java biểu diễn các hình dạng trên một slide dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và chỉnh sửa các hình dạng, vừa là nguồn xác định thứ tự xếp chồng: chỉ mục `0` là hình dạng ở phía sau nhất, trong khi chỉ mục cuối cùng là hình dạng ở phía trước nhất.

Bài viết này theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy và chỉnh sửa các điểm điều chỉnh hình dạng đã được đặt trước, sau đó cho thấy cách sao chép, xóa, ẩn và thay đổi thứ tự các hình dạng. Các phần cuối cùng bao gồm định dạng cấp bố trí, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình của bạn yêu cầu.

## **Xác định và Tìm kiếm Hình dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý một tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc thay đổi thứ tự một hình dạng có thể làm thay đổi chỉ mục của nó. Chọn một định danh tùy thuộc vào cách bản trình chiếu được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getAlternativeText--) hữu ích khi mô tả truy cập hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hóa hoặc viết lại cho khả năng truy cập, và không được đảm bảo là duy nhất. Đừng âm thầm dùng lại văn bản khả năng truy cập có ý nghĩa như một khóa cơ sở dữ liệu.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Dùng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt vòng đời của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình dạng khác và nhận ID riêng của nó.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getUniqueId--) liên quan trả về một định danh có phạm vi bản trình chiếu, nhưng định danh đó dành cho các add-in và có thể được gán lại. Nó không nên được coi là khóa bên ngoài cố định. Nếu độ nhận dạng lâu dài là quan trọng, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn tồn tại.

Đối với một ví dụ thực tế về việc đọc và cập nhật cả tiêu đề và mô tả văn bản thay thế, xem [Quản lý Tiêu đề và Mô tả Văn bản Thay thế](/slides/vi/java/presentation-accessibility/). Sử dụng văn bản thay thế để giải thích ý nghĩa của hình ảnh cho người đọc, và giữ nó tách riêng khỏi tên hình dạng được mã sử dụng để tìm hình.

Ví dụ dưới đây tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác chỉ dành cho một loại hình dạng, hãy kiểm tra giao diện trước khi sử dụng các thành viên đặc thù cho loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng được đặt tên là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/).

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

## **Xác định và Chỉnh sửa Các Điều chỉnh Hình dạng Đặt trước**

Các hình dạng hình học đặt trước có thể hiển thị các điểm điều chỉnh kiểm soát các tính năng như kích thước góc, tỷ lệ mũi tên hoặc góc cung. Truy cập chúng qua bộ sưu tập chỉ đọc [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igeometryshape/#getAdjustments--) . Bộ sưu tập này được cung cấp bởi hình dạng, nhưng mỗi [IAdjustValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/) chứa một giá trị có thể thay đổi.

Đừng chỉ dựa vào một chỉ mục cố định trong bộ sưu tập. Duyệt qua các điều chỉnh và kiểm tra phương thức chỉ đọc [getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getType--) , giá trị [ShapeAdjustmentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeadjustmenttype/) của nó mô tả điều chỉnh kiểm soát gì. Phương thức chỉ đọc [getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#getName--) cung cấp thông tin nhận dạng bổ sung và đặc biệt hữu ích khi một preset chứa hơn một điều chỉnh có cùng loại ngữ nghĩa.

Sử dụng phương thức giá trị phù hợp với ý nghĩa của điều chỉnh:

| Loại điều chỉnh | Mục đích | Giá trị cần thay đổi |
|---|---|---|
| `CornerSize` | Kích thước các góc bo tròn | [setRawValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Độ dày đuôi mũi tên | `setRawValue` |
| `ArrowheadLength` | Độ dài đầu mũi tên | `setRawValue` |
| `ArrowheadWidth` | Độ rộng đầu mũi tên | `setRawValue` |
| `StartAngle` | Góc bắt đầu của một miếng bánh hoặc cung | [setAngleValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Góc kết thúc của một miếng bánh hoặc cung | `setAngleValue` |

`getType` và `getName` trả về thông tin chỉ đọc. `getRawValue` và `setRawValue` làm việc với một số nguyên trong các đơn vị hình học gốc của preset, trong khi `getAngleValue` và `setAngleValue` làm việc với góc tính bằng độ. Số lượng, thứ tự, ý nghĩa và phạm vi hợp lệ của các điều chỉnh phụ thuộc vào preset [ShapeType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igeometryshape/#getShapeType--). Một giá trị hợp lệ cho một preset có thể không hợp lệ hoặc có hiệu ứng khác cho preset khác.

Khi `getType` trả về `ShapeAdjustmentType.Custom`, API không nhận ra ý nghĩa ngữ nghĩa chuẩn. Kiểm tra `getName`, loại preset và giá trị hiện có, và để nguyên điều chỉnh nếu không biết ý nghĩa và phạm vi mong đợi. Ngay cả với các loại đã nhận diện, cũng hãy kiểm tra xem cùng một loại có xuất hiện hơn một lần hay không trước khi chọn giá trị. Bài viết [Connector](/slides/vi/java/connector/) cho thấy tình huống này với các điều chỉnh uốn cong của connector.

Ví dụ hoàn chỉnh dưới đây tạo các phiên bản mặc định và đã chỉnh sửa của ba hình dạng preset. Nó duyệt qua mọi điều chỉnh, báo cáo tên và loại, thay đổi các giá trị liên quan đến kích thước qua `setRawValue`, thay đổi góc qua `setAngleValue`, và lưu kết quả. Cột trái giữ hình học mặc định; cột phải hiển thị hình chữ nhật bo tròn, mũi tên bốn chiều và miếng bánh đã được chỉnh sửa.

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

Kiểm tra loại ngữ nghĩa trước khi thay đổi giá trị làm cho mã rõ ràng về mục đích và tránh giả định rằng một chỉ mục bộ sưu tập cụ thể có cùng ý nghĩa trên các hình dạng preset khác nhau.

## **Chỉnh sửa Bộ sưu tập Hình dạng**

Các phương thức thêm, sao chép, xóa và thay đổi thứ tự hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được lấy trước thao tác đó.

### **Sao chép một Hình dạng**

[addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z-order được chỉ định. Các overload chấp nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao có thể thay đổi kích thước nó.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi trên bất kỳ bản sao nào cũng không làm thay đổi hình dạng nguồn.

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

Sao chép bao gồm nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị này phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được xử lý bởi bản trình chiếu, nhưng một bản sao vẫn là mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Hình dạng**

[remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả trong quá trình duyệt có chỉ mục, hãy duyệt từ cuối danh sách để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên đã chỉ định. Nó đọc hình dạng tại chỉ mục hiện tại, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình dạng một cách không cần thiết.

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

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình dạng sau thay đổi. Tham chiếu đến các hình dạng không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng hãy cân nhắc các connector, hoạt hình và các tính năng khác của bản trình chiếu có thể tham chiếu đến đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi nhiều hơn chỉ giao diện slide.

### **Ẩn một Hình dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setHidden-boolean-) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó hiển thị trong chế độ trình chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn khả dụng cho mã, vì vậy việc ẩn phù hợp cho các thành phần tùy chọn có thể được khôi phục sau này.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và hiện lại, và nó vẫn là một phần của tệp bản trình chiếu.

### **Thay đổi Z-Order**

Các hình dạng chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) di chuyển một hình dạng hiện có đến một chỉ mục mục tiêu mà không sao chép nó. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

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

Hình chữ nhật được tạo trước và ban đầu nằm sau hình ellipse. Di chuyển nó đến chỉ mục cuối cùng đưa nó lên phía trước. Hoàn thiện thứ tự z sau khi đã thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác này thêm hoặc chèn mục mới vào bộ sưu tập và có thể thay đổi lớp chồng dự định.

## **Kiểm tra Hình dạng trên Slide Bố trí**

Slide thông thường, slide bố trí và slide mẫu có các bộ sưu tập hình dạng riêng biệt. Một hình dạng trong bộ sưu tập bố trí không phải là cùng một đối tượng với một hình dạng nằm ở vị trí tương tự trên một slide thông thường. Kiểm tra các hình dạng bố trí khi bạn cần hiểu hoặc thay đổi định dạng do bố trí cung cấp.

Ví dụ dưới đây đọc [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getFillFormat--) và [LineFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getLineFormat--) của mỗi hình dạng bố trí mà không giả định rằng mọi hình dạng đều là `AutoShape`.

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

Chỉnh sửa một bố trí có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình dạng bố trí, xác định liệu một slide bình thường có kế thừa đối tượng này hay chứa một ghi đè cục bộ, và thử nghiệm trên mọi slide dùng bố trí đó.

## **Xuất Hình dạng ra SVG**

[writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ghi nội dung đã render của một hình dạng vào một luồng. Kết quả chỉ chứa hình dạng, không phải toàn bộ nền slide hoặc các hình dạng lân cận.

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

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ thành phần, hãy xuất slide thay vì một hình dạng riêng lẻ. Người gọi sở hữu luồng và phải đóng nó.

## **Căn chỉnh Hình dạng**

Phương thức [SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) có các overload cho phép căn chỉnh toàn bộ hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân bố. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt `false` để căn chỉnh các hình dạng đã chọn tương quan với nhau.

Ví dụ này căn chỉnh ba hình dạng tới cạnh trên của slide. Các tham chiếu hình dạng trả về được chuyển đổi thành chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không phải thứ tự z. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân bố ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn thay đổi bộ sưu tập trước khi gọi phương thức.

## **Lật một Hình dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `getFlipH` và `getFlipV` của nó sử dụng [NullableBool](https://reference.aspose.com/slides/vi/java/com.aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái chưa xác định/mặc định.

Bản trình chiếu nhập dưới đây chứa một hình dạng chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị khung khác và chỉ thay thế hai cài đặt lật. Điều này quan trọng vì việc gán một [Frame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) mới sẽ thay thế toàn bộ khung.

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

Hình dạng đã lưu sẽ được lật ngược chiều ngang và chiều dọc trong khi giữ nguyên vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng cho quá trình ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Ẩn một hình dạng có loại bỏ nó khỏi z-order không?**

Không. Một hình dạng ẩn vẫn nằm trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm, thay đổi thứ tự, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng được sao chép lại xuất hiện phía trước một hình dạng khác?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước của z-order. Dùng `insertClone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi đã thêm tất cả các hình dạng.

**Có thể sử dụng một chỉ mục cố định để xác định một điều chỉnh hình dạng preset không?**

Chỉ được sau khi xác thực preset và cấu trúc bộ sưu tập chính xác. Ưu tiên duyệt qua `IGeometryShape.getAdjustments` và kiểm tra `IAdjustValue.getType`; dùng `IAdjustValue.getName` làm thông tin bổ sung khi cùng một loại ngữ nghĩa xuất hiện hơn một lần.