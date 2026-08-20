---
title: Quản lý khung hình trong bài thuyết trình bằng JavaScript
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/nodejs-java/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- hình ảnh nhúng
- hình ảnh liên kết
- trích xuất hình ảnh
- hình raster
- hình SVG
- cắt hình ảnh
- xóa khu vực đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỉ lệ khung hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung hình trong bài thuyết trình với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Một picture frame là một hình dạng slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) kiểm soát vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các cài đặt cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình chiếu một lần, giữ lại đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) được trả về, và sử dụng tài nguyên hình ảnh đó khi tạo picture frame.

Picture frame có thể chứa hình raster như PNG hoặc JPEG và hình vector SVG. Chúng cũng có thể tham chiếu tới hình ảnh liên kết thay vì lưu trữ byte hình ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến tính di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy cần quyết định cách lưu trữ hình ảnh trước khi định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình chiếu và tạo picture frame bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Hình ảnh trở thành một phần của gói bản trình chiếu, vì vậy bản trình chiếu vẫn tự chứa khi được di chuyển sang máy tính khác.

Ví dụ sau thêm một hình PNG, tạo khung với kích thước gốc của hình ảnh, và áp dụng định dạng đường viền và xoay:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Picture frame kiểm soát hình dạng hiển thị; thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) cung cấp tỷ lệ chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương ứng với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần giữ một mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không thực hiện tái mẫu hay nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Một picture nhúng lưu trữ dữ liệu hình ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho tính di động và việc render dự đoán được. Một picture liên kết lưu trữ vị trí bên ngoài thông qua phương thức [Picture.setLinkPathLong](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu hình ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tập tin liên kết phải luôn có sẵn cho ứng dụng mở hoặc render bản trình chiếu. Nếu đường dẫn thay đổi, tập tin bị di chuyển, hoặc tài nguyên không khả dụng, picture liên kết có thể không được hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi email, lưu trữ, hoặc render trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một picture frame và trỏ nó tới một tập tin hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; liên kết video là một quy trình media riêng và không được trộn vào ví dụ này.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng liên kết khi việc quản lý tập tin bên ngoài là có chủ đích. Không dùng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc hình ảnh bị gãy thường kém hữu ích hơn so với một bản trình chiếu tự chứa lớn hơn.

## **Trích xuất Hình ảnh từ Picture Frames**

Trước khi trích xuất hình ảnh từ một bản trình chiếu hiện có, kiểm tra rằng một shape thực sự là một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) và nó chứa một hình ảnh nhúng. Các picture frame liên kết có thể không chứa byte hình ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình raster**

API hình ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) trực tiếp. Ví dụ sau tìm picture raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save) sẽ chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần byte đã mã hoá được lưu trong bản trình chiếu thay vì một file raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh.

### **Trích xuất Hình SVG**

Đối với picture SVG, [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá picture trước.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một hoạt động render, vì vậy đồ họa được xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [SvgImage.getSvgData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Cắt Hình ảnh**

Cắt thay đổi phần nào của hình ảnh hiển thị bên trong khung. Các giá trị cắt trên [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một picture frame một cách an toàn và áp dụng các giá trị cắt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng đảo ngược, các vùng đã cắt có thể được loại bỏ thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình ảnh Đã Cắt**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu hình ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi lưu bản trình chiếu, các pixel đã bị xóa sẽ không còn khả dụng cho một thao tác un‑crop sau này.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Phương thức có thể thêm một tài nguyên hình ảnh mới vào bản trình chiếu. Nếu hình ảnh gốc cũng được sử dụng bởi các picture frame khác, những frame đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các khu vực đã cắt không nhất thiết giảm tổng số hình ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Hình ảnh Raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) giảm độ phân giải hình raster tương đối với kích thước mà picture được hiển thị. Nó cũng có thể loại bỏ các khu vực đã cắt trong cùng một thao tác. Phương thức trả về `true` khi hình ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không có thay đổi nào cần thiết.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturescompression/) đã định sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Có thể truyền một giá trị DPI dương tùy chỉnh thay cho giá trị định sẵn khi cần một mục tiêu cụ thể.

Nén được thiết kế cho hình raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các khu vực đã cắt bị xóa không thể khôi phục từ bản trình chiếu đã tối ưu hoá. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất trên toàn bộ.

## **Kiểm tra Hiệu ứng Hình ảnh**

Hiệu ứng picture được lưu trên picture mà khung sử dụng. Bộ sưu tập chuyển đổi hình ảnh có thể chứa các hiệu ứng như điều chế alpha cố định để tạo độ trong suốt và độ sáng để điều chỉnh luminance. Ví dụ bên dưới đọc an toàn cả hai loại hiệu ứng từ picture frame đầu tiên trên một slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Các hiệu ứng này thay đổi cách hình ảnh được render trong khung; chúng không ghi đè lên byte của hình ảnh nhúng gốc.

## **Khóa Hình dạng Picture Frame**

Cài đặt [PictureFrameLock](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một picture frame. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) giữ tỉ lệ của shape khi nó được thay đổi kích thước.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khóa áp dụng cho shape picture frame. Nó không buộc hình ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn để có cùng tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ fill picture là stretch, các giá trị stretch‑offset trên [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) định nghĩa hình chữ nhật fill tương đối với bounding box của picture frame. Phần trăm dương tạo khoảng chèn từ cạnh, trong khi phần trăm âm tạo khoảng mở rộng.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà fill picture hiển thị được kéo giãn vào.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng stretch offset để đặt vị trí fill. Dùng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Xem xét Khi Xuất**

Các cân bằng chính dễ quản lý hơn khi lưu trữ hình ảnh và định dạng picture‑frame được xử lý riêng biệt:

- **Hình ảnh nhúng** làm cho bản trình chiếu tự chứa và là đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các hình raster lớn làm tăng kích thước PPTX và mức sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tập tin bên ngoài vẫn phải tồn tại ở các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các khu vực đã cắt được xóa rõ ràng hoặc bị loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng nó đổi chác độ phân giải nguồn. Nên áp dụng sau khi biết kích thước thực tế trên slide.
- **Hình SVG** nên để lại dưới dạng SVG khi việc bảo toàn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Hình ảnh lặp lại** nên tái sử dụng một tài nguyên [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) hiện có khi có thể thay vì tải lại cùng một tập tin nhiều lần vào quy trình làm việc của bản trình chiếu.

Đối với các bản trình chiếu lớn, tối ưu hoá hình ảnh thường hiệu quả nhất khi thực hiện một cách chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa picture frame và tài nguyên hình ảnh là gì?**

Một [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) đại diện cho một tài nguyên hình ảnh gắn với bản trình chiếu. Một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) là một shape trên slide hiển thị hình ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bản trình chiếu phải di động, lưu trữ, hoặc render mà không cần truy cập tài nguyên bên ngoài. Liên kết hình ảnh chỉ khi việc giữ các tập tin hình ảnh bên ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt có giảm kích thước tệp PPTX không?**

Không tự động. Cài đặt cắt bình thường ẩn một phần của ảnh nguồn nhưng vẫn giữ lại các pixel nền. Hãy dùng [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) hoặc nén hình ảnh với việc loại bỏ khu vực đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng hình ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc loại bỏ các khu vực đã cắt sẽ xoá dữ liệu hình ảnh. Giữ bản gốc của nguồn ảnh bên ngoài bản trình chiếu nếu có thể cần chỉnh sửa ở độ phân giải cao sau này.

**Nên xử lý hình SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/) nhúng có thể được trích xuất trực tiếp. Render một slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**Làm sao tránh các cast không an toàn khi đọc các slide hiện có?**

Kiểm tra kiểu shape trước khi sử dụng các thành viên đặc thù của picture‑frame. Kiểm tra `java.instanceOf` đối với [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) tránh các cast không hợp lệ và cho phép mã xử lý các slide không chứa picture frame.