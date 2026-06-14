---
title: Quản lý các hình dạng trong bản trình chiếu bằng JavaScript
linktitle: Thao tác Hình dạng
type: docs
weight: 40
url: /vi/nodejs-java/shape-manipulations/
keywords:
- hình dạng PowerPoint
- hình dạng bản trình chiếu
- hình dạng trên slide
- tìm hình dạng
- sao chép hình dạng
- xóa hình dạng
- ẩn hình dạng
- thay đổi thứ tự hình dạng
- lấy ID hình dạng Interop
- văn bản thay thế của hình dạng
- định dạng bố cục hình dạng
- hình dạng dưới dạng SVG
- hình dạng sang SVG
- căn hình dạng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo, chỉnh sửa và tối ưu hóa các hình dạng bằng JavaScript và Aspose.Slides cho Node.js qua Java và cung cấp các bản trình chiếu PowerPoint hiệu suất cao."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình dạng trong bản trình chiếu bằng Aspose.Slides. Nó cho thấy cách tìm một hình dạng trên slide, sao chép nó, xóa nó, ẩn nó, thay đổi thứ tự, lấy ID hình dạng Interop, và đặt văn bản thay thế để nhận dạng và xử lý tiếp theo.

Nó cũng đề cập đến cách truy cập định dạng bố cục cho hình dạng, kết xuất một hình dạng dưới dạng SVG, căn các hình dạng trên slide, và sử dụng các thuộc tính lật để tạo ảnh phản chiếu theo chiều ngang và chiều dọc. Ngoài ra, bài viết bao gồm một phần FAQ ngắn về việc kết hợp hình dạng, thứ tự xếp chồng và khóa hình dạng.

## **Tìm Hình Dạng Trong Slide**
Chủ đề này sẽ mô tả một kỹ thuật đơn giản để giúp các nhà phát triển dễ dàng tìm một hình dạng cụ thể trên slide mà không cần sử dụng Id nội bộ của nó. Quan trọng là biết rằng các tệp PowerPoint Presentation không có cách nào để xác định hình dạng trên slide ngoại trừ Id duy nhất nội bộ. Điều này làm cho việc tìm một hình dạng bằng Id duy nhất nội bộ trở nên khó khăn đối với các nhà phát triển. Tất cả các hình dạng được thêm vào slide đều có một số Văn Bản Thay Thế (Alt Text). Chúng tôi đề nghị các nhà phát triển sử dụng văn bản thay thế để tìm một hình dạng cụ thể. Bạn có thể dùng MS PowerPoint để định nghĩa văn bản thay thế cho các đối tượng mà bạn dự định sẽ thay đổi trong tương lai.

Sau khi đặt văn bản thay thế cho bất kỳ hình dạng mong muốn nào, bạn có thể mở bản trình chiếu đó bằng Aspose.Slides for Node.js via Java và duyệt qua tất cả các hình dạng được thêm vào một slide. Trong mỗi vòng lặp, bạn kiểm tra văn bản thay thế của hình dạng và hình dạng có văn bản thay thế khớp sẽ là hình dạng bạn cần. Để minh họa kỹ thuật này, chúng tôi đã tạo một phương thức, [findShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) mà thực hiện việc tìm một hình dạng cụ thể trong slide và sau đó trả về hình dạng đó.

```javascript
// Tạo một lớp Presentation đại diện cho tệp bản trình chiếu
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Văn bản thay thế của hình dạng cần tìm
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Sao Chép Hình Dạng**
Để sao chép một hình dạng vào slide bằng Aspose.Slides for Node.js via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập bộ sưu tập hình dạng của slide nguồn.
1. Thêm slide mới vào bản trình chiếu.
1. Sao chép các hình dạng từ bộ sưu tập hình dạng của slide nguồn sang slide mới.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng file PPTX.

Ví dụ dưới đây thêm một nhóm hình dạng vào một slide.

```javascript
// Tạo một lớp Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Ghi tệp PPTX vào đĩa
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Hình Dạng**
Aspose.Slides for Node.js via Java cho phép các nhà phát triển xóa bất kỳ hình dạng nào. Để xóa hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Tìm hình dạng có Văn Bản Thay Thế (AlternativeText) cụ thể.
1. Xóa hình dạng.
1. Lưu tệp vào đĩa.

```javascript
// Tạo đối tượng Presentation
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm autoshape dạng hình chữ nhật
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Lưu bản trình chiếu vào đĩa
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ẩn Hình Dạng**
Aspose.Slides for Node.js via Java cho phép các nhà phát triển ẩn bất kỳ hình dạng nào. Để ẩn hình dạng khỏi bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Tìm hình dạng có Văn Bản Thay Thế (AlternativeText) cụ thể.
1. Ẩn hình dạng.
1. Lưu tệp vào đĩa.

```javascript
// Tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm autoshape dạng hình chữ nhật
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Lưu bản trình chiếu vào đĩa
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay Đổi Thứ Tự Hình Dạng**
Aspose.Slides for Node.js via Java cho phép các nhà phát triển thay đổi thứ tự các hình dạng. Thay đổi thứ tự xác định hình dạng nào ở phía trước hoặc phía sau. Để thay đổi thứ tự các hình dạng trên bất kỳ slide nào, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm một hình dạng.
1. Thêm một đoạn văn bản vào khung văn bản của hình dạng.
1. Thêm một hình dạng khác với cùng tọa độ.
1. Thay đổi thứ tự các hình dạng.
1. Lưu tệp vào đĩa.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lấy ID Hình Dạng Interop**
Aspose.Slides for Node.js via Java cho phép các nhà phát triển lấy một định danh duy nhất cho hình dạng trong phạm vi slide, khác với phương thức [getUniqueId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getUniqueId--) cho phép lấy định danh duy nhất trong phạm vi bản trình chiếu. Phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) đã được thêm vào lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape) và lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape) tương ứng. Giá trị trả về bởi phương thức [getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) tương ứng với giá trị Id của đối tượng Microsoft.Office.Interop.PowerPoint.Shape. Dưới đây là một đoạn mã mẫu.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Lấy định danh hình dạng duy nhất trong phạm vi slide
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Văn Bản Thay Thế cho Hình Dạng**
Aspose.Slides for Node.js via Java cho phép các nhà phát triển đặt AlternateText cho bất kỳ hình dạng nào. Các hình dạng trong một bản trình chiếu có thể được phân biệt bằng phương thức [AlternativeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) hoặc [Shape Name](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). Các phương thức [setAlternativeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) và [getAlternativeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getAlternativeText--) có thể được đọc hoặc đặt bằng Aspose.Slides cũng như Microsoft PowerPoint. Bằng cách sử dụng phương thức này, bạn có thể gắn thẻ một hình dạng và thực hiện các thao tác khác nhau như Xóa hình dạng, Ẩn hình dạng hoặc Thay đổi thứ tự các hình dạng trên slide. Để đặt AlternateText cho một hình dạng, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Truy cập slide đầu tiên.
1. Thêm bất kỳ hình dạng nào vào slide.
1. Thực hiện một số công việc với hình dạng vừa thêm.
1. Duyệt qua các hình dạng để tìm một hình dạng.
1. Đặt AlternativeText.
1. Lưu tệp vào đĩa.

```javascript
// Tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Thêm autoshape dạng hình chữ nhật
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Lưu bản trình chiếu vào đĩa
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy Cập Định Dạng Bố Cục cho Hình Dạng**
Aspose.Slides for Node.js via Java cung cấp một API đơn giản để truy cập định dạng bố cục cho một hình dạng. Bài viết này trình bày cách bạn có thể truy cập các định dạng bố cục.

Dưới đây là đoạn mã mẫu.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kết Xuất Hình Dạng dưới dạng SVG**
Hiện nay Aspose.Slides for Node.js via Java hỗ trợ việc kết xuất một hình dạng dưới dạng SVG. Phương thức [writeAsSvg](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (và các overload của nó) đã được thêm vào lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape) và lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape). Phương thức này cho phép lưu nội dung của hình dạng dưới dạng file SVG. Đoạn mã dưới đây cho thấy cách xuất hình dạng của slide ra file SVG.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Căn Hình Dạng**
Aspose.Slides cho phép căn các hình dạng hoặc tương đối với lề slide hoặc tương đối với nhau. Đối với mục đích này, phương thức overload [SlidesUtil.alignShape()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) đã được thêm vào. Phân loại [ShapesAlignmentType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapesAlignmentType) xác định các tùy chọn căn có thể.

**Ví dụ 1**

Mã nguồn dưới đây căn các hình dạng có chỉ số 1,2 và 4 dọc theo viền trên của slide.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Ví dụ 2**

Ví dụ dưới đây cho thấy cách căn toàn bộ bộ sưu tập các hình dạng tương đối với hình dạng dưới cùng trong bộ sưu tập.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thuộc Tính Lật**

Trong Aspose.Slides, lớp [ShapeFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapeframe/) cung cấp khả năng điều khiển việc lật ngang và lật dọc của các hình dạng thông qua các thuộc tính `flipH` và `flipV`. Cả hai thuộc tính đều có kiểu `byte`, cho phép giá trị `1` để lật, `0` để không lật, hoặc `-1` để sử dụng hành vi mặc định. Các giá trị này có thể truy cập từ [Frame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getFrame) của một hình dạng.

Để chỉnh sửa các thiết lập lật, một thể hiện mới của [ShapeFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapeframe/) được tạo ra với vị trí và kích thước hiện tại của hình dạng, các giá trị mong muốn cho `flipH` và `flipV`, và góc quay. Gán thể hiện này cho [Frame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getFrame) của hình dạng và lưu bản trình chiếu sẽ áp dụng các biến đổi phản chiếu và ghi chúng vào tệp đầu ra.

Giả sử chúng ta có tệp sample.pptx trong đó slide đầu tiên chứa một hình dạng duy nhất với cài đặt lật mặc định, như hình dưới đây.

![The shape to be flipped](shape_to_be_flipped.png)

Đoạn mã sau lấy các thuộc tính lật hiện tại của hình dạng và lật nó cả ngang lẫn dọc.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Lấy thuộc tính lật ngang của hình dạng.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Lấy thuộc tính lật dọc của hình dạng.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Lật ngang.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Lật dọc.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The flipped shape](flipped_shape.png)

## **Câu Hỏi Thường Gặp**

**Tôi có thể kết hợp các hình dạng (hợp/giao/trừ) trên slide giống như trong trình chỉnh sửa trên máy tính để bàn không?**

Không có API thao tác Boolean tích hợp sẵn. Bạn có thể xấp xỉ bằng cách tự xây dựng đường viền mong muốn — ví dụ, tính toán hình học kết quả (qua [GeometryPath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/geometrypath/)) và tạo một hình dạng mới với đường viền đó, tùy chọn loại bỏ các hình dạng gốc.

**Làm thế nào tôi có thể kiểm soát thứ tự xếp chồng (z-order) để một hình dạng luôn ở trên cùng?**

Thay đổi thứ tự chèn/di chuyển trong bộ sưu tập [shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getShapes) của slide. Để có kết quả dự đoán được, hãy hoàn thiện thứ tự z sau khi thực hiện mọi thay đổi khác trên slide.

**Tôi có thể "khóa" một hình dạng để ngăn người dùng chỉnh sửa nó trong PowerPoint không?**

Có. Đặt các cờ bảo vệ ở mức hình dạng (ví dụ, khóa chọn, di chuyển, thay đổi kích thước, chỉnh sửa văn bản). Nếu cần, có thể áp dụng các hạn chế này trên master hoặc layout. Lưu ý đây là bảo vệ ở cấp UI, không phải tính năng bảo mật; để bảo vệ mạnh hơn, hãy kết hợp với các hạn chế ở cấp tệp như [đề xuất chỉ đọc hoặc mật khẩu](/slides/vi/nodejs-java/password-protected-presentation/).