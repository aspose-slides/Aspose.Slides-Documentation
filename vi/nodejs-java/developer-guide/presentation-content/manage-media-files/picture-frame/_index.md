---
title: Quản lý Khung Hình trong Bản Thuyết Trình bằng JavaScript
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/nodejs-java/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- thêm ảnh
- tạo ảnh
- trích xuất ảnh
- ảnh raster
- ảnh vector
- cắt ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- trong suốt ảnh
- PowerPoint
- OpenDocument
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm khung hình vào các bản thuyết trình PowerPoint và OpenDocument với Aspose.Slides cho Node.js thông qua Java. Tinh giản quy trình làm việc của bạn và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa một ảnh — nó giống như một bức tranh trong khung.

Bạn có thể thêm ảnh vào một slide thông qua khung hình. Bằng cách này, bạn định dạng ảnh bằng cách định dạng khung hình.

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG sang PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG sang PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bản thuyết trình nhanh chóng từ ảnh. 

{{% /alert %}} 

## **Tạo Khung Hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của một slide qua chỉ mục của nó. 
3. Tạo một đối tượng `PPImage` bằng cách thêm một ảnh vào [ImagesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection) liên kết với đối tượng presentation sẽ được dùng để đổ đầy hình dạng.
4. Xác định chiều rộng và chiều cao của ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFrame) dựa trên chiều rộng và chiều cao của ảnh thông qua phương thức `addPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm một khung hình (chứa ảnh) vào slide.
7. Ghi bản thuyết trình đã sửa đổi thành tệp PPTX.

Đoạn mã JavaScript này cho bạn thấy cách tạo khung hình:

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo lớp Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Thêm khung hình với chiều cao và chiều rộng tương đương của ảnh
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Khung hình cho phép bạn nhanh chóng tạo các slide thuyết trình dựa trên ảnh. Khi bạn kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các hoạt động nhập/xuất để chuyển đổi ảnh từ định dạng này sang định dạng khác.

## **Tạo Khung Hình với Tỷ Lệ Tương Đối**

Bằng cách thay đổi tỷ lệ tương đối của ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của một slide qua chỉ mục của nó. 
3. Thêm một ảnh vào bộ sưu tập ảnh của bản thuyết trình.
4. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một ảnh vào [ImagesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection) liên kết với đối tượng presentation sẽ được dùng để đổ đầy hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của ảnh trong khung hình.
6. Ghi bản thuyết trình đã sửa đổi thành tệp PPTX.

Ví dụ mã JavaScript sau đây cho bạn thấy cách tạo khung hình với tỷ lệ tương đối:

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo lớp Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Thêm khung hình với chiều cao và chiều rộng tương đương của ảnh
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Thiết lập tỷ lệ tương đối cho chiều cao và chiều rộng
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Trích xuất ảnh Raster từ Khung Hình**

Bạn có thể trích xuất ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFrame) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một ảnh từ tài liệu "sample.pptx" và lưu nó ở định dạng PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Trích xuất ảnh SVG từ Khung Hình**

Khi một bản thuyết trình chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) , Aspose.Slides cho Node.js qua Java cho phép bạn lấy lại các ảnh vector gốc với độ chính xác đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/), kiểm tra xem [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) bên dưới có chứa nội dung SVG hay không, và sau đó lưu ảnh đó vào đĩa hoặc luồng ở định dạng SVG gốc.

Ví dụ mã sau đây minh họa cách trích xuất ảnh SVG từ một khung hình:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Lấy Độ Trong Suốt của Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một ảnh. Đoạn mã JavaScript này minh họa thao tác:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Định dạng Khung Hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho khung hình. Sử dụng các tùy chọn này, bạn có thể chỉnh sửa khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của một slide qua chỉ mục của nó. 
3. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một ảnh vào [ImagesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection) liên kết với đối tượng presentation sẽ được dùng để đổ đầy hình dạng.
4. Xác định chiều rộng và chiều cao của ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của ảnh thông qua phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) được cung cấp bởi đối tượng [Shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection) liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa ảnh) vào slide.
7. Đặt màu đường viền của khung hình.
8. Đặt độ rộng đường viền của khung hình.
9. Xoay khung hình bằng cách cung cấp giá trị dương hoặc âm.
   * Giá trị dương sẽ xoay ảnh theo chiều kim đồng hồ. 
   * Giá trị âm sẽ xoay ảnh ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa ảnh) vào slide.
11. Ghi bản thuyết trình đã sửa đổi thành tệp PPTX.

Đoạn mã JavaScript này minh họa quá trình định dạng khung hình:

```javascript
// Khởi tạo lớp Presentation đại diện cho PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo lớp Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Thêm Khung Hình với chiều cao và chiều rộng tương đương của Ảnh
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Áp dụng một số định dạng cho PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Ghi tệp PPTX ra đĩa
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose mới đây đã phát triển một [Công cụ Tạo Collage miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [gộp ảnh JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 

{{% /alert %}}

## **Thêm Ảnh dưới dạng Liên kết**

Để tránh kích thước bản thuyết trình quá lớn, bạn có thể thêm ảnh (hoặc video) thông qua liên kết thay vì chèn trực tiếp các tệp vào bản thuyết trình. Đoạn mã JavaScript này cho bạn thấy cách thêm ảnh và video vào một placeholder:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Cắt Ảnh**

Đoạn mã JavaScript này cho bạn thấy cách cắt một ảnh hiện có trên slide:

```javascript
var pres = new aspose.slides.Presentation();
// Tạo đối tượng ảnh mới
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Thêm một PictureFrame vào Slide
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Cắt ảnh (giá trị phần trăm)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Lưu kết quả
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Các Vùng Đã Cắt của Ảnh**

Nếu bạn muốn xóa các vùng đã cắt của một ảnh chứa trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Phương thức này trả về ảnh đã cắt hoặc ảnh gốc nếu việc cắt không cần thiết.

Đoạn mã JavaScript này minh họa thao tác:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Lấy PictureFrame từ slide đầu tiên
    var picFrame = slide.getShapes().get_Item(0);
    // Xóa các vùng đã cắt của ảnh PictureFrame và trả về ảnh đã cắt
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Lưu kết quả
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) thêm ảnh đã cắt vào bộ sưu tập ảnh của bản thuyết trình. Nếu ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/), cấu hình này có thể giảm kích thước bản thuyết trình. Ngược lại, số lượng ảnh trong bản thuyết trình kết quả sẽ tăng.

Phương thức này chuyển các tệp metafile WMF/EMF sang ảnh PNG raster trong quá trình cắt. 

{{% /alert %}}

## **Nén Ảnh**

Bạn có thể nén một ảnh trong bản thuyết trình bằng phương thức [PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) . Phương thức này nén ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của ảnh tương tự như tính năng **Picture Format → Compress Pictures → Resolution** của PowerPoint.

Các ví dụ JavaScript sau đây minh họa cách nén ảnh trong bản thuyết trình bằng cách chỉ định độ phân giải mục tiêu và tùy chọn loại bỏ các vùng đã cắt:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Nén ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và loại bỏ các vùng đã cắt.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Kiểm tra kết quả của quá trình nén.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hoặc sử dụng một giá trị DPI đã định sẵn khác:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Nén ảnh tới 96 DPI (độ phân giải email), loại bỏ các vùng đã cắt.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức này chuyển ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các khu vực đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.
Nếu ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ tùy theo độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao.

{{% /alert %}}

## **Khoá Tỷ Lệ Khung Hình**

Nếu bạn muốn một hình dạng chứa ảnh giữ nguyên tỷ lệ khung hình ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) để đặt thiết lập *Lock Aspect Ratio*.

Đoạn mã JavaScript này cho bạn thấy cách khoá tỷ lệ khung hình của một hình dạng:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // đặt hình dạng để giữ tỉ lệ khung khi thay đổi kích thước
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Thiết lập *Lock Aspect Ratio* này chỉ bảo vệ tỷ lệ khung hình của hình dạng mà không ảnh hưởng đến ảnh bên trong.

{{% /alert %}}

## **Sử dụng Thuộc tính StretchOff**

Sử dụng các phương thức [setStretchOffsetLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) và [setStretchOffsetBottom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) từ lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat) và lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat), bạn có thể chỉ định một hình chữ nhật đổ đầy.

Khi chỉ định kéo giãn cho một ảnh, một hình chữ nhật nguồn sẽ được co giãn để vừa với hình chữ nhật đổ đã chỉ định. Mỗi cạnh của hình chữ nhật đổ được định nghĩa bằng một phần trăm độ dịch chuyển so với cạnh tương ứng của hộp bao của hình dạng. Phần trăm dương chỉ ra một phần lùi trong, còn phần trăm âm chỉ ra một phần lùi ra.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
2. Lấy tham chiếu của một slide qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một ảnh.
5. Đặt kiểu đổ màu cho hình dạng.
6. Đặt chế độ đổ ảnh cho hình dạng.
7. Thêm ảnh đã thiết lập để đổ đầy hình dạng.
8. Xác định độ lệch của ảnh so với cạnh tương ứng của hộp bao của hình dạng
9. Ghi bản thuyết trình đã sửa đổi thành tệp PPTX.

Đoạn mã JavaScript này minh họa một quá trình trong đó thuộc tính StretchOff được sử dụng:

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Khởi tạo lớp ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Thêm một AutoShape dạng Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Đặt loại đổ màu của hình dạng
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Đặt chế độ đổ ảnh của hình dạng
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Đặt ảnh để đổ đầy hình dạng
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Xác định độ dịch của ảnh so với cạnh tương ứng của hộp bao của hình dạng
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Ghi tệp PPTX ra đĩa
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu Hỏi Thường Gặp**

**Bạn có thể tìm hiểu các định dạng ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và ảnh vector (ví dụ, SVG) thông qua đối tượng ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của công cụ chuyển đổi slide và ảnh.

**Việc thêm hàng chục ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?**

Nhúng ảnh lớn làm tăng kích thước tệp và sử dụng bộ nhớ; liên kết ảnh giúp giữ kích thước bản thuyết trình nhỏ hơn nhưng yêu cầu các tệp ngoại vi vẫn có sẵn. Aspose.Slides cung cấp khả năng thêm ảnh bằng liên kết để giảm kích thước tệp.

**Làm thế nào để khóa một đối tượng ảnh tránh việc di chuyển/đổi kích thước nhầm?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá di chuyển hoặc đổi kích thước). Cơ chế khóa được hỗ trợ cho nhiều loại hình dạng, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/).

**Độ trung thực vector SVG có được bảo tồn khi xuất bản thuyết trình sang PDF/ảnh không?**

Aspose.Slides cho phép trích xuất một SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất sang PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/nodejs-java/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy vào cài đặt xuất; việc SVG gốc được lưu dưới dạng vector được xác nhận bởi hành vi trích xuất.