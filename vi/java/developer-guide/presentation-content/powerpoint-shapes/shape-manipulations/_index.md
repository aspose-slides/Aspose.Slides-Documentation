---
title: Quản lý các Hình dạng trong Bài thuyết trình bằng Java
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
- Lấy ID hình dạng Interop
- Văn bản thay thế cho hình dạng
- Định dạng bố cục hình dạng
- Hình dạng dưới dạng SVG
- Chuyển hình dạng sang SVG
- Cân chỉnh hình dạng
- PowerPoint
- Bài thuyết trình
- Java
- Aspose.Slides
description: "Học cách tạo, chỉnh sửa và tối ưu hóa các hình dạng trong Aspose.Slides cho Java và cung cấp các bài thuyết trình PowerPoint hiệu suất cao."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình dạng trong bản trình chiếu bằng Aspose.Slides. Nó cho thấy cách tìm một hình dạng trên một slide, sao chép nó, xoá nó, ẩn nó, thay đổi thứ tự, lấy ID hình dạng Interop, và đặt văn bản thay thế để nhận dạng và xử lý tiếp.

Cũng bao gồm cách truy cập định dạng bố cục cho các hình dạng, xuất hình dạng dưới dạng SVG, căn chỉnh các hình trên slide, và sử dụng các thuộc tính lật để phản chiếu ngang và dọc. Thêm vào đó, bài viết có một phần FAQ ngắn về việc kết hợp hình, thứ tự xếp chồng và khóa hình.

## **Tìm một Hình dạng trên Slide**
Chủ đề này sẽ mô tả một kỹ thuật đơn giản giúp các nhà phát triển dễ dàng tìm một hình dạng cụ thể trên slide mà không cần sử dụng Id nội bộ của nó. Cần lưu ý rằng các tệp PowerPoint Presentation không có cách nào để xác định các hình trên slide ngoại trừ Id duy nhất nội bộ. Thực tế, việc tìm một hình dựa trên Id duy nhất nội bộ là khó khăn cho các nhà phát triển. Tất cả các hình được thêm vào slide đều có một đoạn Văn bản thay thế (Alt Text). Chúng tôi đề xuất các nhà phát triển sử dụng văn bản thay thế để tìm một hình cụ thể. Bạn có thể dùng MS PowerPoint để đặt văn bản thay thế cho các đối tượng mà bạn dự định sẽ thay đổi trong tương lai.

Sau khi đặt văn bản thay thế cho bất kỳ hình nào mong muốn, bạn có thể mở bản trình chiếu đó bằng Aspose.Slides for Java và duyệt qua tất cả các hình được thêm vào một slide. Trong mỗi vòng lặp, bạn có thể kiểm tra văn bản thay thế của hình và hình có văn bản thay thế trùng khớp sẽ là hình bạn cần. Để minh họa kỹ thuật này một cách tốt hơn, chúng tôi đã tạo một phương pháp, [findShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) để tìm một hình cụ thể trong slide và trả về hình đó.

```java
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Văn bản thay thế của hình cần tìm
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Triển khai phương thức để tìm một hình trong slide bằng văn bản thay thế của nó
public static IShape findShape(ISlide slide, String alttext)
{
    // Duyệt qua tất cả các hình trong slide
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Nếu văn bản thay thế của hình trùng khớp với yêu cầu thì
        // Trả về hình
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Sao chép một Hình dạng**
Để sao chép một hình vào slide bằng Aspose.Slides for Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập bộ sưu tập hình của slide nguồn.
1. Thêm slide mới vào bản trình chiếu.
1. Sao chép các hình từ bộ sưu tập hình của slide nguồn sang slide mới.
1. Lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một nhóm hình vào slide.

```java
// Khởi tạo lớp Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Ghi tệp PPTX vào đĩa
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa một Hình dạng**
Aspose.Slides for Java cho phép các nhà phát triển xóa bất kỳ hình nào. Để xóa hình khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Tìm hình có AlternativeText cụ thể.
1. Xóa hình.
1. Lưu tệp vào đĩa.

```java
// Tạo đối tượng Presentation
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm autoshape loại hình chữ nhật
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Lưu bản trình chiếu vào đĩa
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ẩn một Hình dạng**
Aspose.Slides for Java cho phép các nhà phát triển ẩn bất kỳ hình nào. Để ẩn hình khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Tìm hình có AlternativeText cụ thể.
1. Ẩn hình.
1. Lưu tệp vào đĩa.

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm autoshape loại hình chữ nhật
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Lưu bản trình chiếu vào đĩa
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi Thứ tự Hình dạng**
Aspose.Slides for Java cho phép các nhà phát triển sắp xếp lại thứ tự các hình. Việc sắp xếp lại xác định hình nào ở phía trước và hình nào ở phía sau. Để sắp xếp lại hình trên bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm một hình.
1. Thêm một số văn bản vào khung văn bản của hình.
1. Thêm một hình khác với cùng tọa độ.
1. Sắp xếp lại các hình.
1. Lưu tệp vào đĩa.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lấy ID Hình dạng Interop**
Aspose.Slides for Java cho phép các nhà phát triển lấy một định danh duy nhất cho hình trong phạm vi slide, khác với phương thức [getUniqueId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getUniqueId--) cho phép lấy định danh duy nhất trong phạm vi bản trình chiếu. Phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) đã được thêm vào giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape) và lớp [Shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Shape). Giá trị trả về bởi phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) tương ứng với giá trị Id của đối tượng Microsoft.Office.Interop.PowerPoint.Shape. Dưới đây là một đoạn mã mẫu.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Lấy định danh hình duy nhất trong phạm vi slide
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt Văn bản Thay thế cho một Hình dạng**
Aspose.Slides for Java cho phép các nhà phát triển đặt AlternateText cho bất kỳ hình nào. Các hình trong một bản trình chiếu có thể được phân biệt bằng phương thức [AlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) hoặc [Shape Name](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#setName-java.lang.String-). Các phương thức [setAlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) và [getAlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#getAlternativeText--) có thể được đọc hoặc đặt bằng Aspose.Slides cũng như Microsoft PowerPoint. Khi sử dụng phương thức này, bạn có thể gắn thẻ cho một hình và thực hiện các thao tác khác nhau như Xóa một hình, Ẩn một hình hoặc Sắp xếp lại các hình trên slide. Để đặt AlternateText cho một hình, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm bất kỳ hình nào vào slide.
1. Thực hiện một số công việc với hình vừa thêm.
1. Duyệt qua các hình để tìm một hình.
1. Đặt AlternativeText.
1. Lưu tệp vào đĩa.

```java
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
    // Lấy slide đầu tiên
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm autoshape loại hình chữ nhật
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Lưu bản trình chiếu vào đĩa
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập Định dạng Bố cục cho một Hình dạng**
Aspose.Slides for Java cung cấp một API đơn giản để truy cập định dạng bố cục cho một hình. Bài viết này trình bày cách bạn có thể truy cập các định dạng bố cục. Dưới đây là đoạn mã mẫu.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xuất Hình dạng dưới dạng SVG**
Hiện tại Aspose.Slides for Java hỗ trợ việc xuất một hình dạng dưới dạng SVG. Phương thức [writeAsSvg](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (và các overload của nó) đã được thêm vào lớp [Shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Shape) và giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IShape). Phương thức này cho phép lưu nội dung của hình dưới dạng tệp SVG. Đoạn mã dưới đây cho thấy cách xuất một hình trên slide thành tệp SVG.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Căn chỉnh một Hình dạng**
Aspose.Slides cho phép căn chỉnh các hình, hoặc tương đối với lề slide, hoặc tương đối với nhau. Để mục đích này, phương thức overload [SlidesUtil.alignShape()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) đã được thêm. Enum [ShapesAlignmentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ShapesAlignmentType) định nghĩa các tùy chọn căn chỉnh khả dụng.

**Ví dụ 1**

Mã nguồn dưới đây căn chỉnh các hình có chỉ số 1,2 và 4 dọc theo cạnh trên của slide.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Ví dụ 2**

Ví dụ dưới đây cho thấy cách căn chỉnh toàn bộ bộ sưu tập các hình so với hình ở dưới cùng trong bộ sưu tập.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thuộc tính Lật**

Trong Aspose.Slides, lớp [ShapeFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeframe/) cung cấp khả năng điều khiển việc phản chiếu ngang và dọc của các hình thông qua các thuộc tính `flipH` và `flipV`. Cả hai thuộc tính đều có kiểu `byte`, cho phép giá trị `1` để chỉ lật, `0` để không lật, hoặc `-1` để sử dụng hành vi mặc định. Các giá trị này có thể truy cập từ [Frame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getFrame--) của hình.

Để thay đổi cài đặt lật, một thể hiện mới của [ShapeFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapeframe/) được tạo với vị trí và kích thước hiện tại của hình, các giá trị mong muốn cho `flipH` và `flipV`, và góc quay. Gán thể hiện này cho [Frame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getFrame--) của hình và lưu bản trình chiếu sẽ áp dụng các biến đổi phản chiếu và ghi chúng vào tệp đầu ra.

Giả sử chúng ta có tệp sample.pptx trong đó slide đầu tiên chứa một hình duy nhất với cài đặt lật mặc định, như dưới đây.

![Hình cần được lật](shape_to_be_flipped.png)

Đoạn mã sau lấy các thuộc tính lật hiện tại của hình và lật nó cả ngang lẫn dọc.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Lấy thuộc tính lật ngang của hình.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Lấy thuộc tính lật dọc của hình.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Lật ngang.
    byte flipV = NullableBool.True; // Lật ngang.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hình đã được lật](flipped_shape.png)

## **FAQ**

**Tôi có thể kết hợp các hình (union/intersect/subtract) trên slide giống như trong trình chỉnh sửa desktop không?**

Không có API toán tử Boolean tích hợp. Bạn có thể gần đúng bằng cách tự xây dựng đường viền mong muốn—ví dụ, tính toán hình học kết quả (qua [GeometryPath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/geometrypath/)) và tạo một hình mới với đường viền đó, tùy chọn là xóa các hình gốc.

**Làm sao tôi có thể kiểm soát thứ tự xếp chồng (z-order) để một hình luôn ở trên cùng?**

Thay đổi thứ tự chèn/di chuyển trong bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslide/#getShapes--) của slide. Để có kết quả dự đoán được, hãy hoàn thiện z-order sau khi thực hiện tất cả các thay đổi khác trên slide.

**Tôi có thể "khóa" một hình để ngăn người dùng chỉnh sửa trong PowerPoint không?**

Có. Thiết lập [các cờ bảo vệ cấp hình](/slides/vi/java/applying-protection-to-presentation/) (ví dụ, khóa lựa chọn, di chuyển, thay đổi kích thước, chỉnh sửa văn bản). Nếu cần, áp dụng các hạn chế tương tự trên master hoặc layout. Lưu ý đây là bảo vệ mức giao diện người dùng, không phải tính năng bảo mật; để bảo vệ mạnh hơn, kết hợp với các hạn chế cấp tệp như [đề xuất chỉ đọc hoặc mật khẩu](/slides/vi/java/password-protected-presentation/).