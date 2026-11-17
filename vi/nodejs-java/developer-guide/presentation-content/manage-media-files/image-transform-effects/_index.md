---
title: Quản lý các hiệu ứng biến đổi hình ảnh trong bản trình chiếu bằng JavaScript
linktitle: Hiệu ứng biến đổi hình ảnh
type: docs
weight: 11
url: /vi/nodejs-java/image-transform-effects/
keywords:
- biến đổi hình ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- màu xám
- hai màu
- tông màu
- HSL
- thay thế màu
- làm mờ
- trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng, xâu chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi hình ảnh cho khung hình ảnh với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides biểu thị các điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự các thao tác biến đổi hình ảnh. Đối với một khung hình ảnh, bắt đầu với [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) của khung và truy cập [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Bộ [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại lại các byte ảnh gốc.

Bài viết này trình bày quy trình làm việc đầy đủ cho độ sáng và độ tương phản, biến đổi màu, làm mờ, trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, xóa, và xác minh vòng quay PPTX.

## **Hiểu Quyền sở hữu Hiệu ứng và Tái sử dụng Ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn mà bản trình bày sở hữu.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) thuộc về một nền ảnh và tham chiếu đến tài nguyên ảnh đồng thời lưu trữ bộ sưu tập biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu nền ảnh, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi các byte trong [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). Khi cùng một [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) được truyền cho [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) nhiều lần, mỗi khung hình mới sẽ nhận được [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) và bộ sưu tập biến đổi riêng. Áp dụng chuyển đổi màu xám cho một khung không làm các khung khác trở nên màu xám, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) cũng được sử dụng bởi các nền ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào các khung hình ảnh.

## **Sử dụng Phạm vi và Đơn vị Tham số Hợp lệ**

Các phương thức được minh họa sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong những phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình bày đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Thao tác | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` tới `100`, phần trăm; `0` để giữ nguyên thành phần. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Hai màu cho pixel tối và sáng. Các kênh RGB và alpha trong `java.awt.Color` dùng giá trị `0` tới `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), đơn vị độ; amount từ `-100` tới `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), đơn vị độ; saturation và luminance từ `-100` tới `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Màu thay thế sử dụng các giá trị kênh từ `0` tới `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` là Boolean kiểm soát việc nội dung mờ có mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Phần trăm không âm. Dùng `0` tới `100` cho việc thay đổi độ mờ thông thường: `0` hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` tới `100`, phần trăm độ trong suốt. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` tới `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc trên ngưỡng trở nên đục. |

Đối với điều chế alpha cố định, trong suốt và độ mờ là các khái niệm bổ trợ. Ví dụ, 35 % trong suốt tương đương với mức điều chế alpha 65 %.

## **Áp dụng Độ sáng và Độ tương phản**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) trả về một thao tác [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Các thiết lập vô hướng được cung cấp khi tạo thao tác. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) trả về các giá trị chỉ đọc đã tính toán có thể được kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng 15 % và độ tương phản 20 %, sau đó hiển thị bản xem trước mà không thay đổi ảnh được nhúng:

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh của Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản cần phải vẫn có thể chỉnh sửa sau một vòng quay PPTX, hãy dùng [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp dụng Biến đổi Màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung hình ảnh khác nhau mà cùng tái sử dụng một tài nguyên ảnh. Ví dụ sau tạo năm khung và áp dụng màu xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích của hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng đơn.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) thay thế màu của mọi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), phương pháp này ánh xạ một màu nguồn sang một màu đích và cho phép cả hai định dạng màu nguồn và đích.

### **Áp dụng Ngưỡng Luminance**

Một ngưỡng luminance có thể làm cho các dấu mờ trên trang quét dễ phân biệt hơn so với nền. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) giữ lại các sắc thái xám trung gian. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ánh xạ luminance thành đen hoặc trắng, trong khi [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) áp dụng ngưỡng cho độ trong suốt.

Ngưỡng luminance dao động từ 0 % tới 100 %, bao gồm. Các pixel dưới ngưỡng trở thành màu đen. Các pixel bằng hoặc trên ngưỡng trở thành màu trắng. Tăng ngưỡng sẽ biến nhiều sắc thái thành màu đen hơn vì chúng rơi dưới mức cắt.

Tải xuống [grayscale-swatches.png](grayscale-swatches.png) vào thư mục làm việc. Mỗi nhãn cho biết mức xám gốc trên thang 0 tới 255. Ví dụ đặt bản gốc bên cạnh hai bản sao và lưu ngưỡng của mỗi bản sao trong bản trình bày.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mở bản trình bày đầu ra trong PowerPoint để so sánh ba khung. Bảng màu có nhãn 96 có khoảng 38 % luminance (96 trên 255). Nó chuyển sang màu trắng ở ngưỡng 20 % và sang màu đen ở ngưỡng 60 %.

![Các mẫu xám gốc bên cạnh kết quả đen‑trắng ở ngưỡng luminance 20 % và 60 %](luminance-threshold.png)

## **Thêm Làm Mờ, Trong Suốt và Hiệu ứng Alpha**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ảnh hưởng tới mọi kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với trong suốt đồng đều, dùng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) thay vào đó gán một giá trị alpha duy nhất cho mọi pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) chuyển alpha thành hai mức dựa trên một ngưỡng.

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

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), làm cho mọi alpha khác không bằng 0 trở thành đục hoàn toàn; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), làm cho mọi alpha dưới 100 % trở thành trong suốt hoàn toàn; và [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), thay đổi alpha thành `100% - alpha`.

## **Xây dựng Chuỗi Hiệu ứng Có Thứ tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Bộ render sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ tiếp tục như vậy. Do đó, cùng các thao tác nhưng sắp xếp khác nhau có thể tạo ra ảnh khác nhau.

Ví dụ, chuyển đổi màu xám rồi tint đầu tiên loại bỏ thông tin màu sắc và sau đó tô lại kết quả luminance. Tint rồi màu xám lại loại bỏ tint. Tương tự, thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự khác nhau tương đối của chúng.

Ví dụ dưới đây xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình bày, kiểm tra cả loại thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

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

Bộ sưu tập không áp đặt một ma trận tương thích nào hạn chế các thao tác màu, alpha và làm mờ vào các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định loại bỏ biến thể RGB do các hiệu ứng màu trước đó tạo ra; màu xám sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replace hoặc bi‑level có thể bỏ qua chi tiết alpha được tạo ra trước. Xây dựng chuỗi dựa trên thứ tự xử lý pixel mong muốn hơn là xem các mục như các cờ định dạng không có thứ tự.

<!-- visual-explanation:image-transform-effects:start -->
[![Cùng một hình ảnh đi qua màu xám rồi tint, và tint rồi màu xám. Hai hình ảnh màu xám cuối cùng có tông màu khác nhau.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Trong bản render minh họa Aspose.Slides cho .NET 26.11 này, tint 220° ở mức 25 % không thay đổi hình ảnh màu xám. Áp dụng cùng một tint trước khi màu xám tạo ra các tông màu khác nhau.*
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm tra Giá trị Có Thể Chỉnh sửa và Giá trị Thực tế**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Tùy thuộc vào hiệu ứng, nó có thể cung cấp các thành viên có thể ghi trực tiếp. Ví dụ, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) cung cấp các giá trị `radius` và `grow` có thể ghi, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) cung cấp `amount` có thể ghi, và [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) cung cấp `threshold` có thể ghi. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) cung cấp các đối tượng [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) có thể thay đổi.

Một số thao tác, bao gồm [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), và [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), không cung cấp các vô hướng tạo ra như các thuộc tính có thể ghi. Để thay đổi các cài đặt này, hãy xóa thao tác và thêm một thao tác thay thế ở vị trí yêu cầu.

Dữ liệu thực tế được trả về bởi `getEffective()` là đã tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào chủ đề và đọc các giá trị chuẩn hoá mà bộ render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới đây liệt kê chuỗi và kiểm tra các giá trị thực tế ở những nơi API tương ứng cung cấp chúng:

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

Các hiệu ứng không có tham số như màu xám, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu thực tế, nhưng không có cài đặt vô hướng để in ra. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa hoặc Xóa sạch Các Biến đổi Ảnh**

Dùng [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) để xóa một thao tác theo chỉ mục. Vì các chỉ mục thay đổi sau khi xóa, hãy tìm mục tiêu trước và xóa sau khi liệt kê. Dùng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) để xóa toàn bộ chuỗi.

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

Xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại, hay thay đổi tài nguyên [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) được tái sử dụng.

## **Cân nhắc Định dạng Bản trình bày và Đích xuất**

Các biến đổi ảnh xuất phát từ DrawingML, do đó PPTX là định dạng có thể chỉnh sửa được ưu tiên cho chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML tiêu chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha thông thường có khả năng tồn tại tốt nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) là một phần mở rộng của Office 2010 chứ không phải thao tác luminance DrawingML chuẩn. Nó có thể được dùng cho việc render trong bộ nhớ, nhưng không được đảm bảo vẫn là một thao tác [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Ưu tiên [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân có trước mô hình hiệu ứng DrawingML đầy đủ. Lưu thành PPT có thể bỏ qua các thao tác không hỗ trợ, giảm chuỗi thành một phần tập con được hỗ trợ, hoặc xấp xỉ giao diện. Không dùng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi được hỗ trợ vào hình ảnh render. Các đầu ra này không chứa một [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất tài liệu/vector lưu trữ đại diện render riêng của chúng.
- Các hiệu ứng không làm cho một hình ảnh được liên kết tự chứa. Render một hình ảnh được liên kết vẫn phụ thuộc vào tài nguyên liên kết sẵn có khi trình bày được tải.

Các đối tượng tiêu thụ bản trình bày khác nhau có thể render các trường hợp góc cạnh khác nhau, đặc biệt khi một số thao tác alpha hoặc lượng giác màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng với cùng một phiên bản Aspose.Slides được dùng trong môi trường thực tế.

## **FAQ**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh được nhúng không?**

Không. Các thao tác thuộc về [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) được dùng cho nền ảnh. Các byte của [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) nền tảng vẫn không thay đổi.

**Hai khung hình ảnh tái sử dụng cùng một ảnh sẽ chia sẻ các hiệu ứng không?**

Không. Tái sử dụng một [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) tránh việc trùng lặp dữ liệu ảnh, nhưng mỗi khung hình thường có một [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập chấp nhận chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác ảnh hưởng đến đầu ra của thao tác trước vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã có.

**Tại sao các giá trị thực tế chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán được dùng để render, bao gồm cả các màu đã giải quyết. Chỉnh sửa thao tác được lưu trong bộ sưu tập biến đổi ở nơi có thành viên có thể ghi; nếu không, hãy xóa nó và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn chuỗi biến đổi?**

Dùng PPTX và xác minh tệp bằng cách mở lại. PPT cổ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất render chỉ giữ lại giao diện thay vì các thao tác biến đổi có thể chỉnh sửa.