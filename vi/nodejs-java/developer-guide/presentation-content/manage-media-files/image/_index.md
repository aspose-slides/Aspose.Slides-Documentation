---
title: Tối ưu quản lý hình ảnh trong bài thuyết trình bằng JavaScript
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/nodejs-java/image/
keywords:
- thêm hình ảnh
- thêm ảnh
- thêm bitmap
- thay thế hình ảnh
- thay thế ảnh
- từ web
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- thêm EMF
- thêm WMF
- thêm TIFF
- PowerPoint
- OpenDocument
- bài thuyết trình
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Đơn giản hoá việc quản lý hình ảnh trong PowerPoint và OpenDocument bằng JavaScript và Aspose.Slides cho Node.js, tối ưu hiệu năng và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bài thuyết trình trở nên sinh động và thú vị hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh từ tệp, internet hoặc các vị trí khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trong bài thuyết trình của mình thông qua các quy trình khác nhau. 

{{% alert  title="Mẹo" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bài thuyết trình nhanh chóng từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Thông tin" color="info" %}}

Nếu bạn muốn thêm một hình ảnh dưới dạng đối tượng khung—đặc biệt nếu bạn dự định sử dụng các tùy chọn định dạng chuẩn để thay đổi kích thước, thêm hiệu ứng, v.v.—xem [Picture Frame](https://docs.aspose.com/slides/vi/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides hỗ trợ các thao tác với hình ảnh ở các định dạng phổ biến này: JPEG, PNG, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Lưu Trên Máy Vào Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh trên máy tính của mình vào một slide trong bài thuyết trình. Đoạn mã mẫu này bằng JavaScript cho bạn thấy cách thêm một hình ảnh vào slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Hình Ảnh Từ Luồng Vào Slide**

Nếu hình ảnh bạn muốn thêm vào slide không có trên máy tính, bạn có thể thêm hình ảnh trực tiếp từ web. 

Đoạn mã mẫu này cho bạn thấy cách thêm một hình ảnh từ web vào slide bằng JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Nạp tệp Excel vào luồng
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Tạo đối tượng dữ liệu để nhúng
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Thêm hình dạng Khung Đối Tượng Ole
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Ghi tệp PPTX ra đĩa
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master là slide trên cùng lưu trữ và kiểm soát thông tin (chủ đề, bố cục, v.v.) cho tất cả các slide bên dưới nó. Do đó, khi bạn thêm một hình ảnh vào slide master, hình ảnh đó sẽ xuất hiện trên mọi slide dưới slide master đó. 

Đoạn mã mẫu JavaScript này cho bạn thấy cách thêm một hình ảnh vào slide master:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Hình Ảnh Là Nền Slide**

Bạn có thể quyết định sử dụng một bức tranh làm nền cho một slide cụ thể hoặc nhiều slide. Trong trường hợp đó, bạn cần xem *[Cài Đặt Hình Ảnh Là Nền Cho Slide](https://docs.aspose.com/slides/vi/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bài Thuyết Trình**
Bạn có thể thêm hoặc chèn bất kỳ hình ảnh nào vào bài thuyết trình bằng cách sử dụng phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) thuộc lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection). 

Để tạo một đối tượng hình ảnh dựa trên SVG, bạn có thể thực hiện như sau:

1. Tạo đối tượng SvgImage để chèn vào ImageShapeCollection  
2. Tạo đối tượng PPImage từ ISvgImage  
3. Tạo đối tượng PictureFrame bằng lớp PPImage  

Đoạn mã mẫu này cho bạn thấy cách thực hiện các bước trên để thêm một hình ảnh SVG vào bài thuyết trình:
```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Chuyển Đổi SVG Thành Tập Hình Dạng**
Việc chuyển đổi SVG thành tập các hình dạng của Aspose.Slides tương tự chức năng của PowerPoint dùng để làm việc với hình ảnh SVG:

![Menu bật lên của PowerPoint](img_01_01.png)

Chức năng này được cung cấp bởi một trong các overload của phương thức [addGroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) của lớp [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection) nhận một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SvgImage) làm đối số đầu tiên. 

Đoạn mã mẫu này cho bạn thấy cách sử dụng phương thức đã mô tả để chuyển đổi một tệp SVG thành tập các hình dạng:

```javascript
// Tạo bài thuyết trình mới
var presentation = new aspose.slides.Presentation();
try {
    // Đọc nội dung tệp SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Tạo đối tượng SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Lấy kích thước slide
    var slideSize = presentation.getSlideSize().getSize();
    // Chuyển đổi hình ảnh SVG thành nhóm các shape và co giãn tới kích thước slide
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Lưu bài thuyết trình ở định dạng PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**
Aspose.Slides for Node.js via Java cho phép bạn tạo hình ảnh EMF từ các bảng tính Excel và thêm các hình ảnh này dưới dạng EMF vào slide bằng Aspose.Cells. 

Đoạn mã mẫu này cho bạn thấy cách thực hiện nhiệm vụ đã mô tả:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Lưu workbook vào luồng
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của một bài thuyết trình (bao gồm cả những hình ảnh được sử dụng bởi các shape trên slide). Phần này trình bày một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương thức đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện của [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/), hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập. 

Thực hiện các bước sau:

1. Tải tệp bài thuyết trình có chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).  
2. Tải một hình ảnh mới từ tệp vào một mảng byte.  
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.  
4. Trong cách tiếp cận thứ hai, tải hình ảnh vào đối tượng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.  
5. Trong cách tiếp cận thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bài thuyết trình.  
6. Ghi bài thuyết trình đã chỉnh sửa thành tệp PPTX.  

```js
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Cách thứ nhất.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Cách thứ hai.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Cách thứ ba.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Lưu bài thuyết trình vào tệp.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Thông tin" color="info" %}}

Sử dụng công cụ chuyển đổi Aspose FREE [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif), bạn có thể dễ dàng tạo hoạt ảnh cho văn bản, tạo GIF từ văn bản, v.v. 

{{% /alert %}}

## **Câu hỏi thường gặp**

**Độ phân giải gốc của hình ảnh có được giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được bảo tồn, nhưng hình ảnh cuối cùng phụ thuộc vào cách mà [picture](/slides/vi/nodejs-java/picture-frame/) được thu phóng trên slide và bất kỳ nén nào được áp dụng khi lưu.

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng một lúc là gì?**

Đặt logo trên slide master hoặc một layout và thay thế nó trong bộ sưu tập hình ảnh của bài thuyết trình—các cập nhật sẽ lan tỏa tới tất cả các thành phần sử dụng tài nguyên đó.

**Có thể chuyển một SVG đã chèn thành các shape có thể chỉnh sửa được không?**

Có. Bạn có thể chuyển SVG thành một nhóm các shape, sau đó từng phần sẽ có thể chỉnh sửa bằng các thuộc tính shape tiêu chuẩn.

**Làm sao để đặt một hình ảnh làm nền cho nhiều slide cùng lúc?**

[Gán hình ảnh làm nền](/slides/vi/nodejs-java/presentation-background/) trên slide master hoặc layout liên quan—bất kỳ slide nào sử dụng master/layout đó sẽ thừa nhận nền này.

**Làm sao để ngăn bài thuyết trình “phồng to” vì quá nhiều hình ảnh?**

Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu và giữ các đồ họa lặp lại trên master khi thích hợp.