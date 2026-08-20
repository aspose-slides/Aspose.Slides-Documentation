---
title: Quản lý các hình dạng trong Bài thuyết trình trên Android
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/androidjava/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng interop
- văn bản thay thế của hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- hình dạng thành SVG
- căn chỉnh hình dạng
- lật hình dạng
- PowerPoint
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách xác định, sao chép, xóa, ẩn, sắp xếp lại, xuất, căn chỉnh và lật các hình dạng trong bài thuyết trình bằng Aspose.Slides cho Android thông qua Java."
---
## **Tổng quan**

Aspose.Slides for Android via Java biểu diễn các hình dạng trên một trang trình chiếu như một [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/). Bộ sưu tập vừa là nơi bạn tìm và sửa đổi các hình dạng, vừa là nguồn xác định thứ tự xếp chồng của chúng: chỉ mục `0` là hình ở phía sau nhất, trong khi chỉ mục cuối cùng là hình ở phía trước nhất.

Bài viết này tuân theo mô hình đó. Đầu tiên nó giải thích cách xác định một hình dạng một cách đáng tin cậy, sau đó cho biết cách sao chép, xóa, ẩn và sắp xếp lại các hình dạng. Các phần cuối cùng đề cập đến định dạng ở mức bố cục, xuất SVG, căn chỉnh và cài đặt lật. Mỗi ví dụ là độc lập, vì vậy bạn có thể chỉ sử dụng các thao tác mà quy trình công việc của bạn yêu cầu.

## **Xác định và Tìm Kiếm Hình Dạng**

Các chỉ mục trong bộ sưu tập tiện lợi khi xử lý tệp đã biết, nhưng chúng không phải là định danh ổn định. Thêm, xóa hoặc sắp xếp lại một hình dạng có thể thay đổi chỉ mục của nó. Chọn một định danh dựa trên cách bản trình bày được tạo và duy trì:

- [Name](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getName--) hữu ích cho các mẫu do nhà phát triển kiểm soát và dễ kiểm tra trong Bảng lựa chọn của PowerPoint. Tên có thể được chỉnh sửa và không được đảm bảo là duy nhất, vì vậy hãy thiết lập một quy ước đặt tên nếu mã phụ thuộc vào chúng.
- [AlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getAlternativeText--) hữu dụng khi mô tả khả năng truy cập hoặc thẻ do tác giả cung cấp đã xác định hình dạng. Nó hiển thị cho người dùng, có thể được bản địa hoá hoặc viết lại cho khả năng truy cập, và cũng không được đảm bảo là duy nhất. Đừng dùng lại văn bản khả năng truy cập có ý nghĩa như một khóa cơ sở dữ liệu một cách âm thầm.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) là một định danh chỉ đọc, duy nhất trong một trang và tương ứng với ID hình dạng được PowerPoint interop sử dụng. Sử dụng nó khi tích hợp với PowerPoint hoặc khi bạn cần một tham chiếu không mơ hồ trong suốt thời gian tồn tại của một hình dạng. Một hình dạng được sao chép hoặc tạo lại là một hình khác và nhận ID riêng của nó.

Phương thức [getUniqueId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getUniqueId--) liên quan trả về một định danh có phạm vi toàn bộ bản trình chiếu, nhưng định danh này dành cho add‑in và có thể được gán lại. Nó không nên được xem như một khóa ngoại vi cố định. Nếu nhận dạng lâu dài là cần thiết, hãy lưu ánh xạ trong dữ liệu ứng dụng và xác thực rằng hình dạng mong đợi vẫn còn tồn tại.

Ví dụ sau tìm kiếm theo tên với so sánh chính xác và báo cáo ID interop có phạm vi trang. Khi mẫu không chứa hình dạng mong đợi, mã sẽ báo kết quả đó thay vì tiếp tục với đối tượng sai.

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

Khi một thao tác đặc thù cho một loại hình dạng, hãy kiểm tra giao diện trước khi sử dụng thành viên riêng loại. Ví dụ này cập nhật văn bản và văn bản thay thế chỉ khi đối tượng có tên là một [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/).

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

## **Sửa Đổi Bộ Sưu Tập Hình Dạng**

Các phương thức add, clone, remove và reorder hoạt động trên bộ sưu tập ngay lập tức. Nếu một thao tác thay đổi số lượng hoặc thứ tự các hình dạng, đừng tiếp tục dựa vào các chỉ mục đã được ghi lại trước thao tác đó.

### **Sao Chép Hình Dạng**

[addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tạo một bản sao độc lập và thêm nó vào cuối bộ sưu tập đích. [insertClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) cũng tạo một bản sao nhưng đặt nó ở chỉ mục z‑order được chỉ định. Các overload nhận tọa độ di chuyển bản sao mà không thay đổi kích thước; các overload có chiều rộng và chiều cao có thể thay đổi kích thước nữa.

Ví dụ tạo một trang đích, sao chép một hình chữ nhật có nhãn lên phía trước, và chèn bản sao thứ hai ở phía sau. Thay đổi ở bất kỳ bản sao nào cũng không ảnh hưởng đến hình dạng nguồn.

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

Sao chép bao gồm nội dung và định dạng của hình dạng, bao gồm tên và văn bản thay thế. Gán các định danh logic mới cho bản sao khi các giá trị đó phải là duy nhất. Các tài nguyên được các hình dạng phức tạp sử dụng được trình chiếu quản lý, nhưng bản sao vẫn là một mục mới trong bộ sưu tập với danh tính hình dạng mới.

### **Xóa Hình Dạng**

[remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) xóa một đối tượng hình dạng cụ thể khỏi bộ sưu tập của nó. Khi xóa nhiều kết quả khớp trong vòng lặp dựa trên chỉ mục, hãy duyệt từ cuối để mỗi chỉ mục còn lại vẫn hợp lệ.

Ví dụ này xóa mọi hình dạng có tên được chỉ định. Nó đọc hình dạng tại chỉ mục hiện tại, không phải một mục cố định, và không ép kiểu hình dạng một cách không cần thiết.

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

Sau khi xóa, số lượng hình dạng và chỉ mục của các hình sau thay đổi. Tham chiếu tới các hình không bị ảnh hưởng vẫn đáng tin cậy hơn so với các chỉ mục đã lưu. Cũng cần cân nhắc các connector, animation và các tính năng trình chiếu khác có thể tham chiếu tới đối tượng đã xóa; việc xóa một hình dạng hiển thị có thể thay đổi hơn cả vẻ ngoài của trang.

### **Ẩn Hình Dạng**

Đặt [Hidden](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) thành `true` giữ hình dạng trong bộ sưu tập nhưng ngăn nó xuất hiện trong buổi chiếu bình thường. Chỉ mục, định dạng và nội dung của nó vẫn có sẵn cho mã, vì vậy ẩn là phù hợp cho các yếu tố tùy chọn có thể khôi phục lại sau.

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

Ẩn không phải là xóa hay bảo mật. Đối tượng vẫn có thể được người dùng hoặc mã khám phá và hiển thị lại, và nó vẫn là một phần của tệp trình chiếu.

### **Thay Đổi Thứ Tự Z**

Các hình dạng chồng lên nhau được vẽ theo thứ tự trong bộ sưu tập. [reorder](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) di chuyển một hình dạng hiện có tới chỉ mục mục tiêu mà không sao chép. Chỉ mục `0` là phía sau; `size() - 1` là phía trước.

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

Hình chữ nhật được tạo ra trước và ban đầu nằm phía sau hình elip. Di chuyển nó tới chỉ mục cuối cùng sẽ đưa nó lên phía trước. Hoàn thiện thứ tự Z sau khi thêm hoặc sao chép tất cả các hình dạng liên quan, vì các thao tác đó sẽ thêm hoặc chèn các mục mới vào bộ sưu tập và có thể thay đổi ngăn xếp dự định.

## **Kiểm Tra Hình Dạng Trên Trang Bố Cục**

Các trang bình thường, trang bố cục và trang chủ có các bộ sưu tập hình dạng riêng. Một hình dạng trong bộ sưu tập bố cục không phải là cùng một đối tượng với một hình dạng cùng vị trí trên một trang bình thường. Kiểm tra các hình dạng bố cục khi bạn cần hiểu hoặc thay đổi định dạng do bố cục cung cấp.

Ví dụ sau đọc [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getFillFormat--) và [LineFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getLineFormat--) của mỗi hình dạng bố cục mà không giả định mọi hình dạng đều là `AutoShape`.

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

Chỉnh sửa một bố cục có thể ảnh hưởng tới nhiều trang sử dụng nó. Trước khi thay đổi một hình dạng bố cục, xác định xem một trang bình thường có kế thừa đối tượng đó hay chứa một ghi đè cục bộ, và kiểm tra mọi trang sử dụng bố cục đó.

## **Xuất Hình Dạng Sang SVG**

[writeAsSvg](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) ghi nội dung đã render của một hình dạng vào một stream. Kết quả chỉ chứa hình dạng, không bao gồm nền toàn trang hoặc các hình dạng lân cận.

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

Giữ bản trình chiếu mở trong khi render. Đầu ra phụ thuộc vào định dạng của hình dạng và các tài nguyên như phông chữ và hình ảnh. Nếu bạn cần toàn bộ bố cục, hãy xuất trang thay vì một hình dạng riêng lẻ. Người gọi là chủ sở hữu của stream và phải đóng nó.

## **Căn Chỉnh Hình Dạng**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) có các overload cho phép căn chỉnh tất cả các hình dạng hoặc các chỉ mục bộ sưu tập đã chọn. [ShapesAlignmentType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapesalignmenttype/) chỉ định cạnh, đường trung tâm hoặc chế độ phân phối. Đặt `alignToSlide` thành `true` để sử dụng các cạnh của trang; đặt thành `false` để căn các hình đã chọn tương đối với nhau.

Ví dụ này căn ba hình dạng vào cạnh trên của trang. Các tham chiếu hình dạng trả về được chuyển đổi thành chỉ mục hiện tại ngay trước khi căn chỉnh.

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

Căn chỉnh thay đổi vị trí, không phải thứ tự Z. Căn chỉnh tương đối thường cần ít nhất hai hình dạng, trong khi phân phối ngang hoặc dọc cần đủ hình dạng để xác định khoảng cách. Tính lại chỉ mục nếu bạn sửa đổi bộ sưu tập trước khi gọi phương thức.

## **Lật Hình Dạng**

Lớp [ShapeFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapeframe/) lưu trữ vị trí, kích thước, cài đặt lật ngang và dọc, và xoay. Các giá trị `getFlipH` và `getFlipV` dùng [NullableBool](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/nullablebool/): `True` bật lật, `False` tắt lật, và `NotDefined` giữ trạng thái không xác định/mặc định.

Bản trình chiếu đầu vào bên dưới chứa một hình dạng chưa được lật.

![Hình trước khi lật](shape_to_be_flipped.png)

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

Hình dạng đã lưu được phản chiếu ngang và dọc trong khi vẫn giữ vị trí, kích thước và góc quay.

![Hình sau khi lật](flipped_shape.png)

## **FAQ**

**Có nên sử dụng chỉ mục bộ sưu tập làm định danh cho hình dạng không?**

Chỉ nên dùng cho quy trình ngắn hạn khi bộ sưu tập sẽ không thay đổi trước khi sử dụng chỉ mục. Ưu tiên sử dụng quy ước `Name` hoặc `AlternativeText` đã được xác thực cho các mẫu do người tạo, hoặc `OfficeInteropShapeId` cho công việc interop có phạm vi trang.

**Việc ẩn một hình dạng có làm nó bị loại bỏ khỏi thứ tự Z không?**

Không. Một hình dạng bị ẩn vẫn ở trong bộ sưu tập với cùng chỉ mục. Nó vẫn có thể được tìm, sắp xếp lại, chỉnh sửa hoặc hiển thị lại.

**Tại sao một hình dạng được sao chép lại xuất hiện phía trước một hình dạng khác?**

`addClone` thêm bản sao vào cuối bộ sưu tập, tức là phía trước trong thứ tự Z. Dùng `insertClone` để chọn chỉ mục ban đầu hoặc `reorder` sau khi tất cả các hình đã được thêm.