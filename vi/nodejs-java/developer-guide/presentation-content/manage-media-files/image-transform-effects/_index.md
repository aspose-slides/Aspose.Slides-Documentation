---
title: Quản lý các hiệu ứng biến đổi ảnh trong bản trình chiếu với JavaScript
linktitle: Hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/nodejs-java/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- xám
- đối sắc
- tông màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng, nối chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình ảnh bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides biểu diễn việc điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi ảnh. Đối với một khung hình ảnh, bắt đầu từ [Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/) của khung và truy cập [Picture.getImageTransform](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/). Bộ [ImageTransformOperationCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa toàn bộ các hiệu ứng mà không cần ghi lại lại dữ liệu ảnh gốc.

Bài viết này trình bày một quy trình hoàn chỉnh cho độ sáng và độ tương phản, biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, giá trị hiệu quả, việc xóa, và kiểm tra vòng quay PPTX.

## **Hiểu Quyền Sở Hữu Hiệu Ứng và Tái Sử Dụng Ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn thuộc bản trình chiếu.
- [Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/) thuộc về một phần tô hình và tham chiếu tới tài nguyên ảnh trong khi lưu trữ bộ sưu tập biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu phần tô hình, hình học, cài đặt cắt và các định dạng mức khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi byte trong [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/). Khi cùng một [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) được truyền cho [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/) hơn một lần, mỗi khung hình mới sẽ nhận được [Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/) và bộ sưu tập biến đổi của riêng mình. Áp dụng hiệu ứng xám cho một khung không làm cho các khung khác cũng xám, mặc dù tất cả chúng cùng tái sử dụng cùng một tài nguyên ảnh nhúng.

Mô hình [Picture.getImageTransform](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/) cũng được sử dụng cho các phần tô hình khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung hình ảnh.

## **Sử Dụng Dải Thông Số Hợp Lệ và Đơn Vị**

Các phương pháp được minh họa sử dụng các dải và đơn vị ngữ nghĩa sau. Giữ các giá trị trong các dải này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình chiếu mục tiêu có thể chuẩn hoá, bỏ qua, hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tập tin.

| Thao tác | Tham số | Dải hợp lệ và đơn vị |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` tới `100`, phần trăm; `0` giữ thành phần không thay đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Hai màu cho pixel tối và sáng. Các kênh RGB và alpha trong `java.awt.Color` dùng giá trị từ `0` tới `255`. |
| [addTintEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), tính bằng độ; amount từ `-100` tới `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), tính bằng độ; saturation và luminance từ `-100` tới `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Màu thay thế sử dụng các giá trị kênh từ `0` tới `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Bán kính không âm và đo bằng points; `grow` là Boolean kiểm soát việc nội dung mờ có thể mở rộng ra ngoài giới hạn ban đầu hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Phần trăm không âm. Dùng `0` tới `100` cho việc điều chỉnh độ mờ thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` tới `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` tới `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở thành trong suốt; giá trị bằng hoặc trên ngưỡng trở thành mờ. |

Đối với điều chỉnh alpha cố định, độ trong suốt và độ mờ là các khái niệm bổ sung nhau. Ví dụ, độ trong suốt 35% tương đương với mức độ điều chế alpha 65%.

## **Áp Dụng Độ Sáng và Độ Tương Phản**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) trả về một thao tác [BrightnessContrast](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/brightnesscontrast/). Các cài đặt vô hướng được cung cấp khi tạo thao tác. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/brightnesscontrast/) trả về các giá trị chỉ đọc đã tính toán mà có thể kiểm tra hoặc ghi lại.

Ví dụ sau tăng độ sáng lên 15% và độ tương phản lên 20%, sau đó tạo bản xem trước mà không thay đổi ảnh nhúng:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản phải vẫn có thể chỉnh sửa sau vòng quay PPTX, hãy sử dụng [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp Dụng Biến Đổi Màu Sắc**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung hình ảnh khác nhau mà cùng tái sử dụng một tài nguyên ảnh. Ví dụ sau tạo năm khung và áp dụng các hiệu ứng xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ cho pixel tối, trong khi `color2` ánh xạ cho pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích cho hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) thay thế màu của mọi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/), cái mà ánh xạ một màu nguồn sang màu đích và cho phép cả hai định dạng màu nguồn và đích.

## **Thêm Hiệu Ứng Làm Mờ, Độ Trong Suốt và Alpha**

[addBlurEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) ảnh hưởng tới tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) thay vào đó gán một giá trị alpha duy nhất cho mọi pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/), khiến mọi alpha khác 0 trở thành hoàn toàn mờ; [addAlphaFloorEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/), khiến mọi alpha dưới 100% trở thành hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/), đổi alpha thành `100% - alpha`.

## **Xây Dựng Chuỗi Hiệu Ứng Có Thứ Tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Bộ render sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, cứ như vậy. Do đó, cùng các thao tác nhưng ở thứ tự khác có thể tạo ra ảnh khác nhau.

Ví dụ, xám rồi tint sẽ đầu tiên loại bỏ thông tin màu sắc và sau đó đổi màu kết quả luminance. Tint rồi xám lại loại bỏ tint một lần nữa. Tương tự, thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự khác biệt tương đối của chúng.

Ví dụ sau xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình chiếu, kiểm tra cả loại thao tác và thứ tự của chúng, và render kết quả đã mở lại:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Bộ sưu tập không áp đặt một ma trận tương thích hạn chế các thao tác màu, alpha và làm mờ thành các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định loại bỏ biến thể RGB do các hiệu ứng màu trước tạo ra; xám sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi‑level có thể xóa chi tiết alpha được tạo ra trước. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì coi các mục trong đó là các cờ định dạng không có thứ tự.

## **Kiểm Tra Giá Trị Có Thể Chỉnh Sửa và Giá Trị Hiệu Quả**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong [Picture.getImageTransform](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/). Tùy vào hiệu ứng, nó có thể mở ra các thành viên có thể ghi trực tiếp. Ví dụ, [Blur](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/blur/) mở ra các giá trị `radius` và `grow` có thể ghi, [AlphaModulateFixed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/alphamodulatefixed/) mở ra `amount` có thể ghi, và [AlphaBiLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/alphabilevel/) mở ra `threshold` có thể ghi. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/duotone/) mở ra các đối tượng [ColorFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colorformat/) có thể thay đổi.

Một số thao tác, bao gồm [BrightnessContrast](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tint/), và [AlphaReplace](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/alphareplace/), không mở ra các vô hướng tạo ra dưới dạng thuộc tính có thể ghi. Để thay đổi các cài đặt này, hãy xóa thao tác và thêm một thao tác thay thế tại vị trí yêu cầu.

Dữ liệu hiệu quả trả về bởi `getEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào theme và đọc các giá trị chuẩn hoá mà bộ render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ sau liệt kê chuỗi và kiểm tra các giá trị hiệu quả ở nơi API cung cấp chúng:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Các hiệu ứng không có tham số như xám, alpha ceiling và alpha inverse vẫn có một đối tượng dữ liệu hiệu quả, nhưng không có cài đặt vô hướng để in. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa Hoặc Xóa Toàn Bộ Biến Đổi Ảnh**

Sử dụng [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) để xóa một thao tác theo chỉ số. Vì các chỉ số sẽ thay đổi sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Sử dụng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) để xóa toàn bộ chuỗi.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Xóa hoặc xóa toàn bộ biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại, hoặc thay đổi bất kỳ tài nguyên [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) được tái sử dụng nào.

## **Xem Xét Định Dạng Bản Trình Chiếu và Đích Xuất**

Biến đổi ảnh bắt nguồn từ DrawingML, do đó PPTX là định dạng chỉnh sửa ưu tiên cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML tiêu chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha phổ biến có cơ hội cao nhất tồn tại qua vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance DrawingML tiêu chuẩn. Nó có thể dùng cho việc render bộ nhớ, nhưng không được đảm bảo vẫn còn là một thao tác [BrightnessContrast](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/brightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Thích hợp hơn là dùng [addLuminanceEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu thành PPT có thể bỏ qua các thao tác không hỗ trợ, rút gọn chuỗi thành một tập con được hỗ trợ, hoặc xấp xỉ hình ảnh. Không sử dụng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Render thành PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi được hỗ trợ vào hình ảnh hiển thị. Những đầu ra này không chứa một [ImageTransformOperationCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagetransformoperationcollection/) có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất tài liệu/vector lưu trữ đại diện render riêng của chúng.
- Hiệu ứng không làm cho một ảnh liên kết tự chứa. Render một hình ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình chiếu được tải.

Các trình chiếu khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi nhiều thao tác alpha hoặc giảm màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng phiên bản Aspose.Slides đã dùng trong sản xuất.

## **Câu Hỏi Thường Gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh nhúng không?**

Không. Các thao tác thuộc về [Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/) được sử dụng bởi phần tô hình. Các byte [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) nền vẫn không thay đổi.

**Hai khung hình ảnh tái sử dụng cùng một ảnh sẽ chia sẻ các hiệu ứng không?**

Không. Tái sử dụng một [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung hình thường có một [Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/picture/) và bộ sưu tập biến đổi riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác ảnh hưởng như thế nào đến kết quả của thao tác trước vì các thao tác thay thế và ngưỡng có thể bỏ qua chi tiết màu hoặc alpha đã tạo trước.

**Tại sao các giá trị hiệu quả lại chỉ đọc?**

Dữ liệu hiệu quả đại diện cho các giá trị đã tính được dùng cho việc render, bao gồm các màu đã giải quyết. Hãy chỉnh sửa thao tác được lưu trong bộ sưu tập biến đổi ở nơi có thành viên có thể ghi; nếu không, hãy xóa nó và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cũ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất hình ảnh chỉ bảo tồn ngoại hình thay vì các thao tác biến đổi có thể chỉnh sửa.