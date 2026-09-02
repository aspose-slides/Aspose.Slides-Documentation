---
title: Quản lý khung ảnh trong bản trình chiếu bằng JavaScript
linktitle: Khung ảnh
type: docs
weight: 10
url: /vi/nodejs-java/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- ảnh nhúng
- ảnh liên kết
- trích xuất ảnh
- ảnh raster
- ảnh SVG
- cắt ảnh
- xóa các vùng đã cắt
- nén ảnh
- StretchOffset
- định dạng khung ảnh
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Khung ảnh là một hình dạng trên slide hiển thị một hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) sở hữu các tài nguyên ảnh được nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các thiết lập cấp khung khác.

Sự tách biệt này hữu ích khi cùng một ảnh được hiển thị nhiều lần. Thêm ảnh vào bản trình chiếu một lần, giữ lại đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) được trả về, và sử dụng tài nguyên ảnh đó khi tạo các khung ảnh.

Khung ảnh có thể chứa ảnh raster như PNG hoặc JPEG và ảnh vector SVG. Chúng cũng có thể tham chiếu đến ảnh liên kết thay vì lưu trữ dữ liệu ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến khả năng di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hóa.

## **Thêm và Định dạng Ảnh Được Nhúng**

Đối với ảnh được nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo khung ảnh bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Ảnh sẽ trở thành một phần của gói bản trình chiếu, vì vậy bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một ảnh PNG, tạo khung với kích thước gốc của ảnh, và áp dụng định dạng đường viền cũng như xoay:

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

Khung ảnh điều khiển hình học được hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên ảnh được nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ Tương Đối**

[PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) cung cấp khả năng tỷ lệ rộng và cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Giá trị `1.0` tương đương với 100% kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi một quy trình cần duy trì mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng một cách thủ công.

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

Tỷ lệ tương đối thay đổi các thiết lập tỷ lệ của khung; nó không thực hiện tái mẫu hoặc nén ảnh được nhúng.

## **Ảnh Nhúng và Ảnh Liên Kết**

Một ảnh nhúng lưu trữ dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho khả năng di động và việc hiển thị dự đoán được. Một ảnh liên kết lưu trữ vị trí bên ngoài thông qua phương thức [Picture.setLinkPathLong](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) thay vì nhúng dữ liệu ảnh theo cùng cách.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được đối với ứng dụng mở hoặc hiển thị bản trình chiếu. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, ảnh liên kết có thể không được hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi email, lưu trữ, hoặc hiển thị trong môi trường cô lập, ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Ảnh Liên Kết**

Ví dụ sau tạo một khung ảnh và trỏ tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; liên kết video là một quy trình truyền thông riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng dùng chúng chỉ như một biện pháp thay thế cho nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường kém hữu ích hơn so với một bản trình chiếu lớn tự chứa.

## **Trích xuất Ảnh từ Khung Ảnh**

Trước khi trích xuất ảnh từ một bản trình chiếu hiện có, hãy kiểm tra xem hình dạng thực sự là một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) và nó có chứa ảnh đã nhúng hay không. Các khung ảnh liên kết có thể không chứa byte ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Ảnh Raster**

API ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) trực tiếp. Ví dụ sau tìm ảnh raster được nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save) sẽ chuyển đổi ảnh đã trích xuất sang định dạng đầu ra yêu cầu. Nếu bạn cần các byte đã mã hoá lưu trong bản trình chiếu thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh.

### **Trích xuất Ảnh SVG**

Đối với ảnh SVG, [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide thành PDF hoặc SVG cũng là một hoạt động render, vì vậy đồ họa xuất ra không nên được coi là bản sao byte‑for‑byte của SVG đã nhúng; hãy sử dụng dữ liệu [SvgImage.getSvgData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/#getSvgData--) khi cần tài nguyên vector gốc.

## **Cắt Ảnh**

Cắt thay đổi phần nào của ảnh hiển thị bên trong khung. Các giá trị cắt trên [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi ảnh đã nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung ảnh một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng phục hồi, các vùng đã cắt có thể bị loại bỏ vật lý như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) loại bỏ dữ liệu ảnh nằm ngoài hình chữ nhật cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hoá phá hủy: sau khi lưu bản trình chiếu, các pixel đã bị xóa sẽ không còn khả năng phục hồi cho thao tác “uncrop” sau này.

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

Phương thức có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được các khung ảnh khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Ảnh Raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) giảm độ phân giải ảnh raster tương đối với kích thước mà ảnh được hiển thị. Nó cũng có thể xóa các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi nào.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturescompression/) đã định sẵn khi một độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Có thể truyền một giá trị DPI dương tùy chỉnh thay vì giá trị định sẵn khi cần một mục tiêu cụ thể.

Nén nhằm vào ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Cũng nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình chiếu đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất cho toàn bộ.

## **Quản lý Hiệu Ứng Biến Đổi Ảnh**

Đối với quy trình hoàn chỉnh bao gồm độ sáng, độ tương phản, biến đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác thực vòng lặp, xem [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Khóa Hình Học Khung Ảnh**

Cài đặt [PictureFrameLock](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị tắt cho một khung ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) giữ nguyên tỷ lệ của hình dạng khi thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn theo cùng tỷ lệ.

## **Điều Chỉnh Giá Trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [PictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/) định nghĩa hình chữ nhật lấp đầy tương đối với hộp giới hạn của khung ảnh. Phần trăm dương tạo ra một khoảng chèn từ cạnh, trong khi phần trăm âm tạo ra một khoảng mở rộng.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà ảnh lấp đầy được kéo dãn vào.

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

Sử dụng stretch offset để đặt vị trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của ảnh nguồn.

## **Lưu Trữ, Kích Thước Tệp và Cân Nhắc Khi Xuất**

Các cân bằng chính dễ quản lý hơn khi lưu trữ ảnh và định dạng khung ảnh được xem xét riêng biệt:

- **Ảnh nhúng** làm cho bản trình chiếu tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía server, nhưng ảnh raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp bên ngoài phải vẫn khả dụng ở các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho ảnh raster quá lớn, nhưng đánh đổi độ phân giải nguồn. Nên áp dụng sau khi đã biết kích thước hiển thị trên slide.
- **Ảnh SVG** nên giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG đã nhúng trực tiếp khi bạn cần tài nguyên vector. Xuất slide dạng raster luôn chuyển đổi slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng tài nguyên [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc của bản trình chiếu.

Đối với các bản trình chiếu lớn, tối ưu hoá ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau, và tránh liên kết ngoại nếu quản lý phụ thuộc không phải là một phần của thiết kế triển khai.

## **Câu Hỏi Thường Gặp**

**Khác biệt giữa khung ảnh và tài nguyên ảnh là gì?**

[PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) đại diện cho một tài nguyên ảnh gắn với bản trình chiếu. [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) là một hình dạng trên slide hiển thị ảnh và lưu trữ các thông tin hình học và định dạng cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu phải di động, lưu trữ hoặc render mà không cần truy cập tới tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc giữ ảnh ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt bình thường ẩn một phần ảnh nguồn nhưng vẫn giữ lại pixel nền. Sử dụng [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) hoặc nén ảnh kèm loại bỏ vùng đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc xóa các vùng đã cắt sẽ loại bỏ dữ liệu ảnh. Giữ bản gốc ảnh ngoài bản trình chiếu nếu sau này có thể cần chỉnh sửa ở độ phân giải cao.

**Nên xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/) đã nhúng có thể được trích xuất trực tiếp. Render slide thành định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của ảnh slide.

**Làm sao tránh ép kiểu không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù cho khung ảnh. Một kiểm tra `java.instanceOf` đối với [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) tránh các ép kiểu không hợp lệ và cho phép code xử lý các slide không chứa khung ảnh.