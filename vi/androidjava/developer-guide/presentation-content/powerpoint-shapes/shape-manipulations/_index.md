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
- lấy ID hình dạng Interop
- văn bản thay thế cho hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- chuyển hình dạng sang SVG
- căn chỉnh hình dạng
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Học cách tạo, chỉnh sửa và tối ưu hóa các hình dạng trong Aspose.Slides cho Android qua Java và tạo ra các bản thuyết trình PowerPoint hiệu suất cao."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình dạng trong bản trình chiếu bằng Aspose.Slides. Nó cho thấy cách tìm một hình dạng trên một slide, sao chép nó, xóa nó, ẩn nó, thay đổi thứ tự, lấy ID hình dạng Interop, và đặt văn bản thay thế để nhận dạng và xử lý tiếp theo.

Nó cũng đề cập đến cách truy cập định dạng bố cục cho hình dạng, xuất hình dạng dưới dạng SVG, căn chỉnh các hình dạng trên slide, và sử dụng các thuộc tính lật cho việc lật ngang và dọc. Ngoài ra, bài viết bao gồm một phần FAQ ngắn về việc kết hợp hình dạng, thứ tự xếp chồng, và khóa hình dạng.

## **Tìm một hình dạng trên slide**
Chủ đề này sẽ mô tả một kỹ thuật đơn giản giúp các nhà phát triển dễ dàng tìm một hình dạng cụ thể trên slide mà không cần sử dụng Id nội bộ của nó. Cần lưu ý rằng các tệp PowerPoint Presentation không có cách nào để xác định các hình dạng trên slide ngoại trừ Id duy nhất nội bộ. Thực tế, việc tìm một hình dạng bằng Id duy nhất nội bộ có thể gặp khó khăn đối với các nhà phát triển. Tất cả các hình dạng được thêm vào slide đều có một số Văn bản thay thế (Alt Text). Chúng tôi đề nghị các nhà phát triển sử dụng văn bản thay thế để tìm một hình dạng cụ thể. Bạn có thể sử dụng MS PowerPoint để đặt văn bản thay thế cho các đối tượng mà bạn dự định sẽ thay đổi trong tương lai.

Sau khi đặt văn bản thay thế cho bất kỳ hình dạng nào mong muốn, bạn có thể mở bản trình chiếu đó bằng Aspose.Slides for Android qua Java và duyệt qua tất cả các hình dạng được thêm vào một slide. Trong mỗi vòng lặp, bạn có thể kiểm tra văn bản thay thế của hình dạng và hình dạng có văn bản thay thế khớp sẽ là hình dạng bạn cần. Để minh họa kỹ thuật này một cách rõ ràng hơn, chúng tôi đã tạo một phương thức, [findShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) thực hiện việc tìm một hình dạng cụ thể trong slide và trả về hình dạng đó.

```java
// Khởi tạo một lớp Presentation đại diện cho tệp bản thuyết trình
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Văn bản thay thế của hình dạng cần tìm
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
// Triển khai phương thức để tìm một hình dạng trong slide bằng văn bản thay thế của nó
public static IShape findShape(ISlide slide, String alttext)
{
    // Duyệt qua tất cả các hình dạng trong slide
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Nếu văn bản thay thế của slide khớp với yêu cầu thì
        // Trả về hình dạng
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Sao chép một hình dạng**
Để sao chép một hình dạng vào slide bằng Aspose.Slides for Android qua Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
3. Truy cập bộ sưu tập hình dạng của slide nguồn.
4. Thêm slide mới vào bản trình chiếu.
5. Sao chép các hình dạng từ bộ sưu tập hình dạng của slide nguồn sang slide mới.
6. Lưu bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

Ví dụ dưới đây thêm một hình dạng nhóm vào slide.

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

    // Ghi file PPTX vào đĩa
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xóa một hình dạng**
Aspose.Slides for Android qua Java cho phép các nhà phát triển xóa bất kỳ hình dạng nào. Để xóa hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Tìm hình dạng có AlternativeText cụ thể.
4. Xóa hình dạng.
5. Lưu file vào đĩa.

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

    // Lưu bản thuyết trình vào đĩa
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ẩn một hình dạng**
Aspose.Slides for Android qua Java cho phép các nhà phát triển ẩn bất kỳ hình dạng nào. Để ẩn hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Tìm hình dạng có AlternativeText cụ thể.
4. Ẩn hình dạng.
5. Lưu file vào đĩa.

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

    // Lưu bản thuyết trình vào đĩa
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thay đổi thứ tự hình dạng**
Aspose.Slides for Android qua Java cho phép các nhà phát triển sắp xếp lại thứ tự các hình dạng. Việc sắp xếp lại hình dạng xác định hình dạng nào ở phía trước hoặc phía sau. Để sắp xếp lại hình dạng trên bất kỳ slide nào, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Thêm một hình dạng.
4. Thêm một số văn bản vào khung văn bản của hình dạng.
5. Thêm một hình dạng khác với cùng tọa độ.
6. Sắp xếp lại các hình dạng.
7. Lưu file vào đĩa.

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
Aspose.Slides for Android qua Java cho phép các nhà phát triển lấy một định danh duy nhất cho hình dạng trong phạm vi slide, khác với phương thức [getUniqueId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#getUniqueId--) cho phép lấy định danh duy nhất trong phạm vi toàn bộ bản trình chiếu. Phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) đã được thêm vào giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape) và lớp [Shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Shape). Giá trị trả về bởi phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) tương ứng với giá trị Id của đối tượng Microsoft.Office.Interop.PowerPoint.Shape. Dưới đây là một đoạn mã mẫu.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Lấy định danh duy nhất của hình dạng trong phạm vi slide
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt Văn bản Thay thế cho một Hình dạng**
Aspose.Slides for Android qua Java cho phép các nhà phát triển đặt AlternateText cho bất kỳ hình dạng nào. Các hình dạng trong bản trình chiếu có thể được phân biệt bằng phương thức [AlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) hoặc [Shape Name](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). Các phương thức [setAlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) và [getAlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#getAlternativeText--) có thể được đọc hoặc đặt bằng Aspose.Slides cũng như Microsoft PowerPoint. Bằng cách sử dụng phương thức này, bạn có thể gắn thẻ một hình dạng và thực hiện các thao tác khác nhau như Xóa một hình dạng, Ẩn một hình dạng hoặc Sắp xếp lại các hình dạng trên slide. Để đặt AlternateText cho một hình dạng, vui lòng thực hiện các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Truy cập slide đầu tiên.
3. Thêm bất kỳ hình dạng nào vào slide.
4. Thực hiện một số công việc với hình dạng vừa thêm.
5. Duyệt qua các hình dạng để tìm một hình dạng.
6. Đặt AlternativeText.
7. Lưu file vào đĩa.

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

    // Lưu bản thuyết trình vào đĩa
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Truy cập Định dạng Bố cục cho một Hình dạng**
Aspose.Slides for Android qua Java cung cấp một API đơn giản để truy cập định dạng bố cục cho một hình dạng. Bài viết này minh họa cách bạn có thể truy cập các định dạng bố cục.

Dưới đây là đoạn mã mẫu.

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
Hiện tại Aspose.Slides for Android qua Java hỗ trợ xuất một hình dạng dưới dạng svg. Phương thức [writeAsSvg](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (và các overload của nó) đã được thêm vào lớp [Shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Shape) và giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IShape). Phương thức này cho phép lưu nội dung của hình dạng dưới dạng file SVG. Đoạn mã dưới đây cho thấy cách xuất hình dạng của slide thành file SVG.

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
Aspose.Slides cho phép căn chỉnh các hình dạng hoặc tương đối với lề slide hoặc tương đối với nhau. Để thực hiện điều này, phương thức overload [SlidesUtil.alignShape()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) đã được thêm vào. Kiểu liệt kê [ShapesAlignmentType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ShapesAlignmentType) định nghĩa các tùy chọn căn chỉnh khả thi.

**Ví dụ 1**

Mã nguồn dưới đây căn chỉnh các hình dạng có chỉ số 1,2 và 4 dọc theo viền trên của slide.

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

Ví dụ dưới đây cho thấy cách căn chỉnh toàn bộ bộ sưu tập hình dạng tương đối với hình dạng ở mức thấp nhất trong bộ sưu tập.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Thuộc tính Lật**

Trong Aspose.Slides, lớp [ShapeFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapeframe/) cung cấp khả năng kiểm soát việc lật ngang và dọc của các hình dạng thông qua các thuộc tính `flipH` và `flipV`. Cả hai thuộc tính đều có kiểu `byte`, cho phép giá trị `1` để chỉ lật, `0` để không lật, hoặc `-1` để sử dụng hành vi mặc định. Các giá trị này có thể truy cập từ [Frame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getFrame--) của một hình dạng.

Để sửa đổi các cài đặt lật, một thể hiện mới của [ShapeFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapeframe/) được tạo bằng vị trí và kích thước hiện tại của hình dạng, các giá trị mong muốn cho `flipH` và `flipV`, và góc quay. Gán thể hiện này cho [Frame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getFrame--) của hình dạng và lưu bản trình chiếu sẽ áp dụng các phép biến đổi lật và ghi chúng vào file đầu ra.

Giả sử chúng ta có một file sample.pptx trong đó slide đầu tiên chứa một hình dạng duy nhất với cài đặt lật mặc định, như hình dưới.

![Hình dạng sẽ được lật](shape_to_be_flipped.png)

Đoạn mã sau đây lấy các thuộc tính lật hiện tại của hình dạng và lật nó cả theo chiều ngang và chiều dọc.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Lấy thuộc tính lật ngang của hình dạng.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Lấy thuộc tính lật dọc của hình dạng.
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

Kết quả:

![Hình dạng đã lật](flipped_shape.png)

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp các hình dạng (hợp nhất/giao/khấu) trên slide giống như trong trình chỉnh sửa trên máy tính để bàn không?**

Hiện không có API thao tác Boolean được tích hợp sẵn. Bạn có thể xấp xỉ bằng cách tự xây dựng đường viền mong muốn—ví dụ, tính toán hình học kết quả (qua [GeometryPath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/geometrypath/)) và tạo một hình dạng mới với đường viền đó, tùy chọn xóa các hình dạng gốc.

**Làm thế nào tôi có thể kiểm soát thứ tự xếp chồng (z-order) để một hình dạng luôn ở "trên cùng"?**

Thay đổi thứ tự chèn/di chuyển trong bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslide/#getShapes--) của slide. Để có kết quả dự đoán được, hãy cuối cùng thiết lập z-order sau khi đã thực hiện mọi chỉnh sửa khác trên slide.

**Tôi có thể "khóa" một hình dạng để ngăn người dùng chỉnh sửa nó trong PowerPoint không?**

Có. Đặt các cờ bảo vệ ở mức hình dạng (ví dụ, khóa chọn, di chuyển, thay đổi kích thước, chỉnh sửa văn bản). Nếu cần, bạn có thể áp dụng các hạn chế tương tự trên master hoặc layout. Lưu ý đây là bảo vệ ở cấp UI, không phải tính năng bảo mật; nếu muốn bảo vệ mạnh hơn, kết hợp với các hạn chế ở cấp file như [đề xuất chỉ đọc hoặc mật khẩu](/slides/vi/androidjava/password-protected-presentation/).