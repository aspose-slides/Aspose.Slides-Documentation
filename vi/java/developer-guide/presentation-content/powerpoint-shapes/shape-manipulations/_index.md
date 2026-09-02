---
title: Quản lý các hình trong bản trình chiếu bằng Java
linktitle: Thao tác hình
type: docs
weight: 40
url: /vi/java/shape-manipulations/
keywords:
- hình PowerPoint
- hình trong bản trình chiếu
- hình trên slide
- tìm hình
- sao chép hình
- xóa hình
- ẩn hình
- thay đổi thứ tự hình
- lấy ID hình interop
- văn bản thay thế của hình
- định dạng bố cục hình
- hình dưới dạng SVG
- xuất hình ra SVG
- căn chỉnh hình
- lật hình
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách xác định, sao chép, xóa, ẩn, thay đổi thứ tự, xuất, căn chỉnh và lật các hình trong bản trình chiếu với Aspose.Slides cho Java."
---
## **Overview**

Aspose.Slides for Java đại diện cho các hình trên một slide dưới dạng một [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/) có thứ tự. Bộ sưu tập vừa là nơi bạn tìm và chỉnh sửa các hình, vừa là nguồn xác định thứ tự xếp chồng của chúng: chỉ mục `0` là hình ở phía sau nhất, trong khi chỉ mục cuối cùng là hình ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình một cách đáng tin cậy, sau đó trình bày cách sao chép, xóa, ẩn và thay đổi thứ tự các hình. Các phần cuối cùng đề cập đến định dạng ở cấp layout, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình của bạn yêu cầu.

## **Identify and Find Shapes**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc thay đổi thứ tự một hình có thể làm thay đổi chỉ mục của nó. Hãy chọn một định danh dựa trên cách bản trình chiếu được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập quy tắc đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getAlternativeText--) hữu ích khi mô tả khả năng tiếp cận hoặc thẻ do tác giả cung cấp đã xác định hình. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho khả năng tiếp cận, và không được đảm bảo là duy nhất. Đừng lạm dụng văn bản khả năng tiếp cận có nghĩa làm khóa cơ sở dữ liệu một cách âm thầm.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) là một định danh chỉ đọc, duy nhất trong một slide và tương ứng với ID hình được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt thời gian tồn tại của một hình. Một hình được sao chép hoặc tạo lại là một hình khác và sẽ nhận ID riêng của nó.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getUniqueId--) liên quan trả về một định danh có phạm vi trong bản trình chiếu, nhưng định danh này được thiết kế cho các add‑in và có thể được gán lại. Nó không nên được coi là khóa ngoài lâu dài. Nếu nhận dạng lâu dài là cần thiết, hãy giữ ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình mong đợi vẫn tồn tại.

Ví dụ sau tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop có phạm vi slide. Khi mẫu không chứa hình mong đợi, mã sẽ báo cáo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác chỉ áp dụng cho một loại hình, hãy kiểm tra giao diện trước khi sử dụng các thành viên đặc thù loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/).

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

## **Modify the Shape Collection**

Các phương thức thêm, sao chép, xóa và thay đổi thứ tự hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác làm thay đổi số lượng hoặc thứ tự các hình, đừng tiếp tục dựa vào các chỉ mục đã được ghi lại trước thao tác đó.

### **Clone a Shape**

[addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tạo một bản sao độc lập và thêm vào cuối bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có width và height có thể thay đổi kích thước nó nữa.

Ví dụ tạo một slide đích, sao chép một hình chữ nhật có nhãn lên phía trước và chèn bản sao thứ hai ở phía sau. Thay đổi bất kỳ bản sao nào cũng không ảnh hưởng đến hình nguồn.

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

Sao chép sao chép nội dung và định dạng của hình, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được hình phức tạp sử dụng được trình chiếu quản lý, nhưng bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình mới.

### **Remove Shapes**

[remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) xóa một đối tượng hình cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều khớp trong vòng lặp có chỉ mục, hãy duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình có tên được chỉ định. Nó đọc hình tại chỉ mục hiện tại, không phải một mục cố định trong bộ sưu tập, và không ép kiểu hình một cách không cần thiết.

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

Sau khi xóa, số lượng hình và các chỉ mục của các hình sau thay đổi. Tham chiếu tới các hình không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần cân nhắc các connector, animation và các tính năng trình chiếu khác có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình hiển thị có thể thay đổi nhiều hơn chỉ giao diện slide.

### **Hide a Shape**

Thiết lập [Hidden](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setHidden-boolean-) thành `true` giữ hình trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn có sẵn cho mã, vì vậy ẩn là phù hợp cho các yếu tố tuỳ chọn có thể được khôi phục sau này.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã phát hiện và hiển thị lại, và nó vẫn nằm trong tệp trình chiếu.

### **Change the Z-Order**

Các hình chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) di chuyển một hình hiện có tới chỉ mục mục tiêu mà không sao chép nó. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

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

Hình chữ nhật được tạo đầu tiên và ban đầu nằm phía sau hình ellipse. Di chuyển nó tới chỉ mục cuối cùng sẽ đặt nó lên phía trước. Hoàn thiện thứ tự z‑order sau khi thêm hoặc sao chép tất cả các hình liên quan, vì các thao tác đó thêm hoặc chèn các mục mới vào bộ sưu tập và có thể làm thay đổi ngăn xếp dự định.

## **Inspect Shapes on Layout Slides**

Slide bình thường, slide layout và master slide có các bộ sưu tập hình riêng biệt. Một hình trong bộ sưu tập layout không phải là cùng một đối tượng với một hình có vị trí tương tự trên slide bình thường. Kiểm tra các hình layout khi bạn cần hiểu hoặc thay đổi định dạng do layout cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getFillFormat--) và [LineFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getLineFormat--) của mỗi hình layout mà không giả định mọi hình đều là `AutoShape`.

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

Chỉnh sửa một layout có thể ảnh hưởng tới nhiều slide sử dụng nó. Trước khi thay đổi một hình layout, hãy xác định slide bình thường có kế thừa đối tượng này hay chứa một ghi đè cục bộ, và kiểm thử mọi slide sử dụng layout đó.

## **Export a Shape to SVG**

[writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ghi nội dung đã render của một hình vào một stream. Kết quả chứa hình, không phải toàn bộ nền slide hay các hình lân cận.

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

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất slide thay vì một hình riêng lẻ. Người gọi sở hữu stream và phải đóng nó.

## **Align Shapes**

Phương thức [SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) có các overload cho phép căn chỉnh tất cả các hình hoặc các chỉ mục bộ sưu tập được chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapesalignmenttype/) xác định cạnh, đường trung tâm hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh slide; đặt thành `false` để căn các hình đã chọn tương quan với nhau.

Ví dụ này căn ba hình tới cạnh trên của slide. Các tham chiếu hình trả về được chuyển thành chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không thay đổi thứ tự z‑order. Căn chỉnh tương đối thường cần ít nhất hai hình, trong khi phân phối ngang hoặc dọc cần đủ hình để xác định khoảng cách. Tính lại chỉ mục nếu bạn thay đổi bộ sưu tập trước khi gọi phương thức.

## **Flip a Shape**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và góc quay. Các giá trị `getFlipH` và `getFlipV` sử dụng [NullableBool](https://reference.aspose.com/slides/vi/java/com.aspose.slides/nullablebool/): `True` bật lật, `False` tắt, và `NotDefined` giữ trạng thái chưa xác định/mặc định.

Bản trình chiếu đầu vào dưới đây chứa một hình chưa được lật.

![The shape before flipping](shape_to_be_flipped.png)

Ví dụ này giữ nguyên mọi giá trị frame khác và chỉ thay đổi hai cài đặt lật. Điều này quan trọng vì gán một [Frame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) mới sẽ thay thế toàn bộ frame.

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

Hình đã lưu được phản chiếu ngang và dọc trong khi giữ vị trí, kích thước và góc quay.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Chỉ nên dùng cho xử lý ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi chỉ mục được sử dụng. Ưu tiên quy tắc `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu được tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi slide.

**Does hiding a shape remove it from the z-order?**

Không. Một hình ẩn vẫn nằm trong bộ sưu tập ở cùng chỉ mục. Nó vẫn có thể được tìm thấy, thay đổi thứ tự, chỉnh sửa hoặc hiển thị lại.

**Why did a cloned shape appear in front of another shape?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước trong z‑order. Sử dụng `insertClone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi tất cả các hình đã được thêm.