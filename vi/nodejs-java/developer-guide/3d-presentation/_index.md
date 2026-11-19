---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng Node.js
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/nodejs-java/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- xoay 3D
- độ sâu 3D
- nhô ra 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Node.js với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, nhô ra, màu đổ và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D theo kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, nhô ra (extrusion), làm viền (bevel), chiếu sáng, vật liệu, các loại tô màu gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này đề cập đến các hiệu ứng định dạng 3D trên hình dạng và văn bản PowerPoint. Nó không liên quan tới việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide ra hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) để áp dụng định dạng 3D cho một hình dạng. Phương thức trả về [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/), bộ điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Những gì nó kiểm soát | Khi nào nên sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | Điểm nhìn, loại máy ảnh preset, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | Đặt trước ánh sáng, hướng và góc xoay ánh sáng. | Thay đổi cách các điểm nhấn và bóng đổ xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) và [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | Vật liệu bề mặt, chẳng hạn phẳng, mờ, nhựa hoặc kim loại. | Làm cho hình học giống nhau trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại hơn. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) và [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Chuyển một hình dạng phẳng thành một đối tượng 3D dày mắt thấy được. |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Màu của các mặt bên được nhô ra. | Làm cho độ sâu hiện ra hoặc phối màu mặt bên với màu tô mặt trước. |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) và [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | Độ sâu 3D bổ sung được PowerPoint sử dụng. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với bevel và cài đặt vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) và [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc được đúc thay vì mặt phẳng sắc nhọn. |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) và [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả render. |

## **Tạo một Hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thật như 3D:

- Cài đặt máy ảnh, vì góc nhìn mặc định có thể ẩn phần nhô ra.
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các cạnh có thể nhận diện được.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng tới cách ánh sáng được render.
- Cài đặt nhô ra hoặc độ sâu, vì một hình dạng phẳng cần có độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị xoay máy ảnh được tính bằng độ, và chiều cao nhô ra là 100 điểm. Ví dụ này render slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình chiếu dưới dạng PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ảnh slide đã render hiển thị hình chữ nhật như một khối 3D dày:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Xoay một Hình dạng bằng Máy ảnh**

Trong PowerPoint, xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với các góc xoay bạn đặt qua API máy ảnh.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước dạng trực giao, và đặt các góc xoay X, Y, Z thành 20, 30 và 40 độ tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình dạng trên slide. Nó thay đổi góc nhìn 3D được PowerPoint và Aspose.Slides sử dụng khi render.

### **Sao chép Định hướng Máy ảnh từ Hình dạng Mẫu**

Để khớp định hướng của một hình dạng mẫu, đọc preset máy ảnh của nó bằng [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) và các góc xoay bằng [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation). Ví dụ mở `template.pptx` và sao chép định hướng máy ảnh từ hình dạng đầu tiên trên slide đầu tiên sang hình dạng thứ hai. Cả hai hình dạng đã có ánh sáng 3D, và hình dạng thứ hai không có xoay máy ảnh rõ ràng.

Các góc được tính bằng độ. Chỉ số `0` là vĩ độ, `1` là kinh độ, và `2` là vòng quay. Gửi chúng tới [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) theo thứ tự đó. Nếu nguồn trả về `null`, nghĩa là không có xoay rõ ràng, vì vậy hãy để các góc của hình dạng thứ hai không được đặt. Một xoay rõ ràng `(0, 0, 0)` trả về ba số 0 và cần được sao chép.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khi bạn mở lại `camera-copy.pptx` trong PowerPoint, mũi tên bên phải có cùng preset máy ảnh và góc xoay như hình chữ nhật bên trái. Cả hai hình dạng đều sử dụng cùng ánh sáng và độ sâu nhô ra.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Thêm Nhô ra và Độ sâu**

Nhô ra làm cho một hình dạng trông dày bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày có thể nhìn thấy này, và điều khiển màu thiết lập màu của các mặt bên.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Sử dụng [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) để đặt độ dày và [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật nhô ra 100 điểm với các mặt bên màu tím và xoay máy ảnh để lộ độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Phương thức [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) thiết lập độ sâu cho một hình dạng 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) điều khiển chiều cao của hiệu ứng nhô ra, như trong ví dụ này.

## **Sử dụng Gradient hoặc Hình ảnh Đổ đầy với Hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu hình dạng. Bạn có thể áp dụng màu đặc, gradient, mẫu hoặc hình ảnh lên mặt trước và vẫn sử dụng cùng máy ảnh, ánh sáng, vật liệu và cài đặt nhô ra.

Ví dụ này áp dụng gradient từ xanh dương sang cam lên mặt trước và màu cam đậm cho phần nhô ra 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu bắt đầu và kết thúc gradient. Các giá trị xoay máy ảnh tính bằng độ. Slide được render thành ảnh PNG với kích thước gấp đôi mặc định:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kết quả render giữ gradient trên mặt trước và render nhô ra riêng biệt:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Để sử dụng hình ảnh thay vì gradient, thêm ảnh vào bản trình chiếu và gán nó làm màu đổ cho hình dạng. Ví dụ này yêu cầu một tệp hiện có tên "image.jpg" trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng nhô ra 150 điểm và đặt xoay máy ảnh tính bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc render tệp:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Hình ảnh được render trên mặt trước, trong khi phần nhô ra được render như bề mặt bên 3D:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình dạng ảnh hưởng đến phần thân hình. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần được nhô ra, có vật liệu, chiếu sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với mẫu lưới cam và trắng, áp dụng một cung cong lên trên, và cấu hình các cài đặt 3D qua [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Chiều cao và độ sâu nhô ra tính bằng điểm, và góc xoay ánh sáng tính bằng độ. Đổ màu và viền của hình dạng được ẩn để chỉ văn bản hiển thị. Ví dụ này render ảnh PNG ở kích thước gấp đôi slide mặc định và lưu bản trình chiếu dưới dạng PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Văn bản được render dưới dạng chữ 3D cong, nhô ra:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình dạng 3D**

Để giữ văn bản dễ đọc đồng thời giữ nguyên diện mạo 3D của hình dạng, gọi [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) thông qua [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Khi giá trị là `true`, văn bản sẽ không nằm trong cảnh 3D. Khi là `false`, văn bản sẽ tham gia vào cảnh và tuân theo định hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình dạng: máy ảnh, ánh sáng, vật liệu và nhô ra vẫn được cấu hình qua [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat). Nó cũng khác với việc xoay thông thường. [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) xoay hình dạng trong mặt phẳng slide, trong khi [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) kiểm soát góc xoay tùy chỉnh của văn bản trong khung bao. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong số đó.

Ví dụ tự chứa sau tạo một hình chữ nhật màu xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao nhô ra là 40 điểm. Ví dụ lưu bản trình chiếu dưới dạng PPTX và render slide so sánh sang PNG với kích thước gấp đôi mặc định.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Ở bên trái, văn bản theo định hướng 3D. Ở bên phải, nó giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật vẫn giữ cùng độ nhô ra và định hướng 3D có thể nhìn thấy.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Xuất và Hành vi Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất ra các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/nodejs-java/convert-powerpoint-to-png/), xuất ra [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), xuất ra [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/nodejs-java/convert-powerpoint-to-video/).

Lưu ý các điểm sau:

- Ảnh và PDF đã xuất không tương tác. Đối tượng không thể bị xoay bởi người xem sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, rig ánh sáng, vật liệu, nhô ra, đổ màu và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng được kế thừa hoặc dựa trên chủ đề, hãy đọc [effective shape properties](/slides/vi/nodejs-java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu định dạng 3D PowerPoint có thể chỉnh sửa. Trong những định dạng đó, kết quả trực quan được render thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bản trình chiếu 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML xuất ra trở thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng được áp dụng lên một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn xoay, nhô ra, bevel, chiếu sáng và vật liệu. Bài viết này chỉ đề cập đến các hiệu ứng 3D.

**Cài đặt nào cần thiết để có một hình dạng 3D có thể nhìn thấy?**

Ít nhất, cần đặt góc xoay máy ảnh và một trong hai: nhô ra hoặc độ sâu. Thực tế, cũng nên đặt rig ánh sáng và vật liệu để các mặt được render có điểm nhấn và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) cho phần thân hình dạng và [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất ra ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render các hiệu ứng 3D khi tạo ảnh slide, PDF, HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã render, không phải một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi kế thừa và cài đặt chủ đề được áp dụng không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/nodejs-java/shape-effective-properties/) để đọc camera cuối cùng, rig ánh sáng, bevel và các giá trị 3D liên quan.