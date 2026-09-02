---
title: Quản lý Khung Hình trong Bài Thuyết Trình Sử dụng JavaScript
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
- xóa các khu vực đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khía cạnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung hình trong các bài thuyết trình với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Khung hình ảnh là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, quay, cắt, hiệu ứng ảnh và các cài đặt ở mức khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) được trả về, và sử dụng tài nguyên hình ảnh đó khi tạo các khung hình ảnh.

Khung hình ảnh có thể chứa các hình raster như PNG hoặc JPEG và các hình vector SVG. Chúng cũng có thể tham chiếu tới các hình ảnh được liên kết thay vì lưu trữ byte hình ảnh trong bản trình bày. Lựa chọn này ảnh hưởng tới khả năng di chuyển, kích thước tệp, việc trích xuất và hành vi xuất, do đó hữu ích khi quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu hoá.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình bày và tạo một khung hình ảnh bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Hình ảnh trở thành một phần của gói bản trình bày, vì vậy bản trình bày vẫn tự chứa khi di chuyển sang máy tính khác.

Ví dụ sau thêm một hình PNG, tạo khung có kích thước gốc của hình ảnh, và áp dụng định dạng đường viền cùng việc quay:

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

Khung hình ảnh điều khiển hình học được hiển thị; việc thay đổi kích thước khung không làm thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) cung cấp khả năng điều chỉnh tỷ lệ rộng và cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương đương 100% kích thước hình gốc. Tỷ lệ tương đối hữu ích khi quy trình cần duy trì mối quan hệ với kích thước nguồn thay vì tính toán kích thước cuối cùng một cách thủ công.

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

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không tái lấy mẫu hoặc nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Một hình ảnh nhúng lưu dữ liệu hình ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho khả năng di chuyển và hiển thị dự đoán được. Một hình ảnh liên kết lưu vị trí bên ngoài thông qua phương thức [Picture.setLinkPathLong](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu hình ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được bởi ứng dụng mở hoặc render bản trình bày. Nếu đường dẫn thay đổi, tệp được di chuyển, hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình bày cần được gửi email, lưu trữ, hoặc render trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một khung hình ảnh và trỏ tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; việc liên kết video là một quy trình media riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Không dùng chúng chỉ để thay thế cho việc nén: một PPTX nhỏ với các phụ thuộc hình ảnh bị hỏng thường kém hữu ích hơn một bản trình bày tự chứa lớn hơn.

## **Trích xuất Hình ảnh từ Khung Hình ảnh**

Trước khi trích xuất hình ảnh từ một bản trình bày hiện có, kiểm tra xem một hình dạng thực sự có phải là [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) và nó có chứa hình ảnh nhúng không. Các khung hình ảnh liên kết có thể không chứa byte hình ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình raster**

API hình ảnh hiện đại sử dụng trực tiếp [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/). Ví dụ sau tìm hình raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save) chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoá được lưu trong bản trình bày thay vì một tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh.

### **Trích xuất Hình SVG**

Đối với hình SVG, đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá hình ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide sang PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; hãy sử dụng dữ liệu [SvgImage.getSvgData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Cắt Hình ảnh**

Cắt thay đổi phần nào của hình ảnh hiển thị bên trong khung. Các giá trị cắt trên [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) là phần trăm của kích thước hình ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung hình ảnh một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu hình ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau này mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn khả năng đảo ngược, các vùng đã cắt có thể được loại bỏ vật lý như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình ảnh Đã Cắt**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu hình ảnh nằm ngoài khu vực cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi bản trình bày được lưu, các pixel đã bị xóa sẽ không còn khả dụng cho thao tác hủy cắt sau này.

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

Phương thức có thể thêm một tài nguyên hình ảnh mới vào bản trình bày. Nếu hình ảnh gốc cũng được các khung hình ảnh khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số hình ảnh. Cắt nội dung WMF hoặc EMF bằng phương thức này sẽ raster hoá kết quả đã cắt sang PNG.

## **Nén Hình raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) giảm độ phân giải hình raster tương đối với kích thước mà hình ảnh được hiển thị. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi hình ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi.

Sử dụng một giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturescompression/) được định sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Một giá trị DPI dương tùy chỉnh có thể được truyền vào thay vì giá trị định sẵn khi yêu cầu mục tiêu cụ thể.

Nén được thiết kế cho hình raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Cũng nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình bày đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình ảnh sẽ thực sự được xem hoặc xuất hơn là áp dụng DPI thấp nhất trên toàn bộ.

## **Quản lý Hiệu ứng Biến đổi Hình ảnh**

Đối với quy trình hoàn chỉnh bao gồm độ sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi lệnh, kiểm tra, loại bỏ và xác minh vòng lặp, xem [Image Transform Effects](/slides/vi/nodejs-java/image-transform-effects/).

## **Khóa Hình học Khung Hình ảnh**

Cài đặt [PictureFrameLock](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung hình ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) giữ tỷ lệ hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung hình ảnh. Nó không buộc hình ảnh nguồn phải được tái lấy mẫu hoặc thay đổi vĩnh viễn thành cùng tỷ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy hình ảnh là stretch, các giá trị stretch‑offset trên [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) định nghĩa hình chữ nhật lấp đầy tương đối với hộp bao của khung hình ảnh. Phần trăm dương tạo ra khoảng inset từ mép, trong khi phần trăm âm tạo ra khoảng outset.

Điều này khác với cắt. Giá trị cắt chọn phần nào của hình ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà phần hình ảnh hiển thị được kéo giãn vào.

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

Sử dụng stretch offset để định vị lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của hình ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Xem xét Khi Xuất**

Các cân nhắc chính dễ quản lý hơn khi lưu trữ hình ảnh và định dạng khung hình ảnh được xử lý riêng biệt:

- **Hình ảnh nhúng** làm cho bản trình bày tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng các hình raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp bên ngoài vẫn phải khả dụng tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng nó hy sinh độ phân giải nguồn. Nên áp dụng sau khi biết kích thước mong muốn trên slide.
- **Hình SVG** nên giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển slide được render sang pixel.
- **Hình ảnh lặp lại** nên tái sử dụng một tài nguyên [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc của bản trình bày.

Đối với các bản trình bày lớn, tối ưu hoá hình ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp dựa trên kích thước hiển thị thực tế, loại bỏ các pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa khung hình ảnh và tài nguyên hình ảnh là gì?**

Một [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) đại diện cho một tài nguyên hình ảnh được liên kết với bản trình bày. Một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thuộc tính ở mức khung như kích thước, quay, giá trị cắt, hiệu ứng và khóa.

**Tôi nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần truy cập tài nguyên bên ngoài. Liên kết hình ảnh chỉ khi việc giữ các tệp hình ảnh bên ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt có giảm kích thước tệp PPTX không?**

Không tự động. Cài đặt cắt thông thường ẩn các phần của hình ảnh nguồn nhưng giữ nguyên các pixel bên dưới. Sử dụng [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) hoặc nén hình ảnh với việc loại bỏ vùng đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Tôi có thể phục hồi chất lượng hình ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc loại bỏ các vùng đã cắt sẽ xóa dữ liệu hình ảnh. Giữ nguyên hình ảnh nguồn bên ngoài bản trình bày nếu sau này có thể cần chỉnh sửa độ phân giải cao.

**Cách xử lý hình SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ chính xác vector quan trọng. [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/) nhúng có thể được trích xuất trực tiếp. Render một slide sang định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**Làm sao tránh cast không an toàn khi đọc các slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù của khung hình ảnh. Kiểm tra `java.instanceOf` đối với [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) tránh các cast không hợp lệ và cho phép mã xử lý các slide không chứa khung hình ảnh.