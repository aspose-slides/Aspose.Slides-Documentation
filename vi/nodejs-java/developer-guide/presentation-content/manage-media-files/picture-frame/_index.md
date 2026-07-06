---
title: Quản lý Khung Hình trong Bài Thuyết Trình bằng JavaScript
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
- độ trong suốt ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm khung hình vào các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java. Tối ưu quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa một hình ảnh — nó giống như một bức tranh trong khung.

Bạn có thể thêm một hình ảnh vào slide thông qua khung hình. Bằng cách này, bạn định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các trình chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo nhanh các bài thuyết trình từ hình ảnh. 

{{% /alert %}} 

## **Tạo Khung Hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide qua chỉ mục của nó. 
3. Tạo một đối tượng `PPImage` bằng cách thêm một hình ảnh vào [ImagesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection) được liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFrame) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `addPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa ảnh) vào slide.
7. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Đoạn mã JavaScript này cho bạn thấy cách tạo một khung hình:

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo lớp Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Thêm một khung hình với chiều cao và chiều rộng tương đương của ảnh
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Ghi tệp PPTX vào đĩa
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Khung hình cho phép bạn nhanh chóng tạo các slide thuyết trình dựa trên hình ảnh. Khi bạn kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các hoạt động nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác.

## **Tạo Khung Hình với Tỷ Lệ Tương Đối**

Bằng cách thay đổi tỷ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của presentation.
4. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một hình ảnh vào [ImagesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection) được liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình.
6. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Đoạn mã JavaScript này cho bạn thấy cách tạo một khung hình với tỷ lệ tương đối:

```javascript
// Khởi tạo lớp Presentation đại diện cho PPTX
var pres = new aspose.slides.Presentation();
try {
    // Lấy slide đầu tiên
    var sld = pres.getSlides().get_Item(0);
    // Khởi tạo lớp Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Thêm Khung Hình với chiều cao và chiều rộng tương đương của Hình ảnh
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Đặt tỷ lệ tương đối cho chiều rộng và chiều cao
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Ghi tệp PPTX vào đĩa
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Trích Xuất Hình Ảnh Raster từ Khung Hình**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFrame) và lưu chúng ở định dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu "sample.pptx" và lưu nó ở định dạng PNG.

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

## **Trích Xuất Hình Ảnh SVG từ Khung Hình**

Khi một bản trình bày chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) , Aspose.Slides cho Node.js qua Java cho phép bạn lấy lại các hình ảnh vector gốc với độ chính xác đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/), kiểm tra xem [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) cơ bản có chứa nội dung SVG hay không, và sau đó lưu hình ảnh đó vào đĩa hoặc luồng ở định dạng SVG gốc.

Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh SVG từ một khung hình:

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

## **Lấy Độ Trong Suất của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Đoạn mã JavaScript này minh họa thao tác này:

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

## **Lấy Độ Sáng và Độ Tương Phản của Hình Ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng độ sáng và độ tương phản được áp dụng cho một hình ảnh. Lớp [Luminance](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/luminance/) đại diện cho hiệu ứng biến đổi hình ảnh này.

Đoạn mã JavaScript này minh họa cách lấy cài đặt độ sáng và độ tương phản từ một khung hình:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Định Dạng Khung Hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho khung hình. Sử dụng các tùy chọn này, bạn có thể chỉnh sửa khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu của slide qua chỉ mục của nó. 
3. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PPImage) bằng cách thêm một hình ảnh vào [ImagesCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection) được liên kết với đối tượng presentation sẽ được sử dụng để lấp đầy hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) được cung cấp bởi đối tượng [Shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection) liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa ảnh) vào slide.
7. Đặt màu đường viền của khung hình.
8. Đặt độ rộng đường viền của khung hình.
9. Xoay khung hình bằng cách cung cấp giá trị dương hoặc âm.
   * Giá trị dương sẽ xoay hình ảnh theo chiều kim đồng hồ. 
   * Giá trị âm sẽ xoay hình ảnh ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa ảnh) vào slide.
11. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Đoạn mã JavaScript này minh họa quy trình định dạng khung hình:

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
    // Ghi tệp PPTX vào đĩa
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose gần đây đã phát triển một [công cụ Collage Maker miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [ghép nối JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 

{{% /alert %}}

## **Thêm Hình Ảnh dưới Dạng Liên Kết**

Để tránh kích thước bản trình bày lớn, bạn có thể thêm hình ảnh (hoặc video) qua các liên kết thay vì nhúng tệp trực tiếp vào bản trình bày. Đoạn mã JavaScript này cho bạn thấy cách thêm hình ảnh và video vào một placeholder:

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

## **Cắt Hình Ảnh**

Đoạn mã JavaScript này cho bạn thấy cách cắt một hình ảnh hiện có trên slide:

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
    // Thêm Khung Hình vào Slide
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

## **Xóa Các Vùng Đã Cắt của Khung Hình**

Nếu bạn muốn xóa các khu vực đã cắt của hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu không cần cắt.

Đoạn mã JavaScript này minh họa thao tác:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Lấy PictureFrame từ slide đầu tiên
    var picFrame = slide.getShapes().get_Item(0);
    // Xóa các khu vực đã cắt của hình ảnh PictureFrame và trả về hình ảnh đã cắt
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

Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của bản trình bày. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/), cấu hình này có thể giảm kích thước bản trình bày. Ngược lại, số lượng hình ảnh trong bản trình bày kết quả sẽ tăng.

Phương thức này chuyển các metafile WMF/EMF thành hình ảnh PNG raster trong quá trình cắt. 

{{% /alert %}}

## **Nén Hình Ảnh**

Bạn có thể nén một hình ảnh trong bản trình bày bằng phương thức [PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) .
Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các khu vực đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format → Compress Pictures → Resolution** của PowerPoint.

Các ví dụ JavaScript dưới đây minh họa cách nén một hình ảnh trong bản trình bày bằng cách chỉ định độ phân giải mục tiêu và tùy chọn loại bỏ các khu vực đã cắt:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Nén ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và xóa các khu vực đã cắt.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Kiểm tra kết quả của việc nén.
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

Hoặc sử dụng giá trị DPI định sẵn khác:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Nén ảnh đến 96 DPI (độ phân giải email), xóa các khu vực đã cắt.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Phương thức này chuyển hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.
Nếu hình ảnh là metafile (WMF/EMF) hoặc SVG, nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao.

{{% /alert %}}

## **Khóa Tỷ Lệ Khung Hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ tỷ lệ khung hình ngay cả khi thay đổi kích thước ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) để thiết lập cài đặt *Lock Aspect Ratio*.

Đoạn mã JavaScript này cho bạn thấy cách khóa tỷ lệ khung hình của một hình dạng:

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
    // đặt hình dạng để giữ tỷ lệ khung khi thay đổi kích thước
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Cài đặt *Lock Aspect Ratio* này chỉ bảo tồn tỷ lệ của hình dạng chứ không phải hình ảnh bên trong.

{{% /alert %}}

## **Sử Dụng Thuộc Tính StretchOff**

Sử dụng các phương thức [setStretchOffsetLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) và [setStretchOffsetBottom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) từ lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PictureFillFormat), bạn có thể chỉ định một hình chữ nhật lấp đầy.

Khi kéo dài được chỉ định cho một hình ảnh, hình chữ nhật nguồn sẽ được thu phóng để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được xác định bởi phần trăm độ lệch so với cạnh tương ứng của hộp bao của hình dạng. Phần trăm dương chỉ độ lệch vào trong, trong khi phần trăm âm chỉ độ lệch ra ngoài.

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) class.
2. Lấy tham chiếu của slide qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt loại lấp đầy cho hình dạng.
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng.
7. Thêm một hình ảnh đã đặt để lấp đầy hình dạng.
8. Xác định độ lệch hình ảnh từ cạnh tương ứng của hộp bao của hình dạng
9. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Đoạn mã JavaScript này minh họa quy trình sử dụng tính năng StretchOff:

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
    // Đặt kiểu lấp đầy cho hình dạng
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Đặt chế độ lấp đầy hình ảnh cho hình dạng
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Đặt hình ảnh để lấp đầy hình dạng
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Xác định độ lệch của hình ảnh từ các cạnh tương ứng của hộp bao của hình dạng
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Ghi tệp PPTX vào đĩa
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Làm thế nào tôi có thể biết các định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của engine chuyển đổi slide và hình ảnh.

**Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào tới kích thước và hiệu suất của PPTX?**

Nhúng hình ảnh lớn làm tăng kích thước tệp và mức sử dụng bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản trình bày nhưng yêu cầu các tệp bên ngoài phải luôn có thể truy cập được. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm dung lượng tệp.

**Làm sao tôi có thể khóa một đối tượng hình ảnh khỏi việc di chuyển/điều chỉnh kích thước vô tình?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) (ví dụ, vô hiệu hóa việc di chuyển hoặc thay đổi kích thước). Cơ chế khóa được hỗ trợ cho nhiều loại hình dạng, bao gồm cả [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/).

**Độ trung thực vector SVG có được bảo lưu khi xuất bản trình bày sang PDF/hình ảnh không?**

Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất sang PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) hoặc [các định dạng raster](/slides/vi/nodejs-java/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; việc SVG gốc được lưu dưới dạng vector được xác nhận bằng hành vi trích xuất.