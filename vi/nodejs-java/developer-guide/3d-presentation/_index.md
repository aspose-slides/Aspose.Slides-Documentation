---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng Node.js
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/nodejs-java/3d-presentation/
keywords:
- PowerPoint 3D
- Bài thuyết trình 3D
- Quay 3D
- Độ sâu 3D
- Đùn 3D
- Độ chuyển màu 3D
- Văn bản 3D
- PowerPoint
- Bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng và render hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Node.js bằng Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, extrusion, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java có thể tạo, chỉnh sửa, bảo quản và hiển thị định dạng 3D kiểu PowerPoint cho các hình và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, extrusion, bevel, ánh sáng, vật liệu, độ chuyển màu hoặc ảnh nền, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này đề cập đến các hiệu ứng định dạng 3D trên các hình và văn bản của PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide ra ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D đó vào đầu ra 2D được xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getThreeDFormat) để áp dụng định dạng 3D cho một hình. Phương thức này trả về [ThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/), điều khiển cảnh 3D cho hình đó.

Đối với văn bản, sử dụng phương thức [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình.

Các thành viên API quan trọng nhất là:

| Thành viên API | Chức năng | Khi nào sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getCamera) | Góc nhìn, loại máy ảnh được đặt trước, quay, thu phóng và phối cảnh. | Quay đối tượng trong không gian 3D hoặc khớp với cài đặt quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getLightRig) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách ánh sáng nổi bật và bóng đổ xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getMaterial) và [setMaterial](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#setMaterial) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho hình dạng cùng một cấu trúc trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại hơn. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Khoảng cách mà hình kéo dài ra phía sau mặt trước. | Biến một hình phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Màu của các mặt phía bên được kéo ra. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với màu nền mặt trước. |
| [getDepth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getDepth) và [setDepth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#setDepth) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getBevelTop) và [getBevelBottom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Các cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm hoặc đúc thay vì mặt phẳng sắc nhọn. |
| [getContourColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getContourWidth) và [setContourWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong đầu ra được render. |

## **Tạo hình 3D**

Một hình thường cần bốn loại cài đặt trước khi trông thật 3D:

- Cài đặt máy ảnh, vì góc nhìn trước mặc định có thể che mất phần extrude.
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và cạnh có thể nhìn thấy.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.
- Cài đặt extrusion hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị quay máy ảnh tính bằng độ, và chiều cao extrusion là 100 điểm. Ví dụ này render slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình chiếu dưới dạng PPTX.

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

Ảnh slide được render hiển thị hình chữ nhật dưới dạng khối 3D dày:

![Hình chữ nhật 3D màu xanh có văn bản 3D màu trắng trên mặt trước được render](img_01_01.png)

## **Xoay hình bằng máy ảnh**

Trong PowerPoint, việc quay 3D được cấu hình từ bảng 3‑D Rotation. Các giá trị quay X, Y và Z tương ứng với góc quay bạn đặt thông qua API máy ảnh.

![Bảng PowerPoint 3‑D Rotation với các giá trị quay X, Y và Z được tô sáng](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [ThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getCamera). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn trước trực giao, và đặt các góc quay X, Y, Z lần lượt là 20, 30 và 40 độ. Nó cấu hình hình trong bộ nhớ mà không lưu tệp:

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

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình dạng 2D trên slide, mà thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides dùng khi render.

## **Thêm Extrusion và Độ sâu**

Extrusion làm cho một hình trông dày bằng cách kéo nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu thiết lập màu của các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu extrusion và chiều cao extrusion](img_02_02.png)

Sử dụng [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) để đặt độ dày và [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) để lấy màu mặt bên. Ví dụ này cho hình chữ nhật một extrusion 100 điểm với các mặt bên màu tím và quay máy ảnh để lộ độ dày. Nó cấu hình hình trong bộ nhớ mà không lưu tệp:

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

Phương thức [ThreeDFormat.setDepth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#setDepth) đặt độ sâu cho một hình 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) điều khiển chiều cao của hiệu ứng extrusion, như trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với hiệu ứng 3D**

Định dạng 3D độc lập với màu nền của hình. Bạn có thể áp dụng màu rắn, gradient, họa tiết hoặc ảnh nền cho mặt trước và vẫn sử dụng cùng một cài đặt máy ảnh, ánh sáng, vật liệu và extrusion.

Ví dụ này áp dụng gradient màu xanh‑hồng cho mặt trước và màu cam đậm cho extrusion 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị quay máy ảnh tính bằng độ. Slide được render thành ảnh PNG với kích thước gấp đôi mặc định:

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

Kết quả render giữ gradient trên mặt trước và render extrusion riêng biệt:

![Hình chữ nhật 3D với màu nền gradient từ xanh sang cam và extrusion màu cam được render](img_02_03.png)

Để sử dụng ảnh nền thay thế, thêm ảnh vào bản trình chiếu và gán cho màu nền của hình. Ví dụ này yêu cầu tệp "image.jpg" có sẵn trong thư mục làm việc. Nó kéo căng ảnh để lấp đầy hình chữ nhật, áp dụng extrusion 150 điểm, và đặt quay máy ảnh tính bằng độ. Nó cấu hình hình trong bộ nhớ mà không lưu hay render tệp:

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

Ảnh được render trên mặt trước, trong khi extrusion được render dưới dạng bề mặt 3D bên:

![Hình chữ nhật 3D với ảnh nền trên mặt trước và extrusion màu cam được render](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình ảnh ảnh hưởng đến phần thân hình. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt khi các ký tự cần extrusion, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với họa tiết lưới cam‑trắng, áp dụng cung cong lên và cấu hình các cài đặt 3D qua [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Chiều cao extrusion và độ sâu tính bằng điểm, góc quay ánh sáng tính bằng độ. Màu nền và viền của hình được ẩn để chỉ văn bản hiển thị. Ví dụ này render ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình chiếu dưới dạng PPTX:

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

Văn bản được render dưới dạng chữ 3D cong, extrusion màu đậm:

![Văn bản 3D được render với biến đổi WordArt cong, họa tiết màu cam và extrusion tối màu](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ văn bản có thể đọc được trong khi vẫn duy trì diện mạo 3D của hình, gọi [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) qua [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Khi giá trị là `true`, văn bản không tham gia vào cảnh 3D. Khi là `false`, văn bản sẽ tham gia vào cảnh và theo hướng 3D của nó.

Cài đặt này không xóa định dạng 3D của hình: máy ảnh, ánh sáng, vật liệu và extrusion vẫn được cấu hình qua [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getThreeDFormat). Nó cũng khác với quay thông thường. [Shape.setRotation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#setRotation) quay hình trên mặt phẳng slide, trong khi [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) điều khiển góc quay tùy chỉnh của văn bản trong khung bao. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong hai trường hợp này.

Ví dụ tự chứa sau tạo một hình chữ nhật màu xanh với văn bản và sao chép nó cạnh hình gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao extrusion là 40 điểm. Ví dụ này lưu bản trình chiếu dưới dạng PPTX và render slide so sánh thành PNG với kích thước gấp đôi mặc định.

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

Bên trái, văn bản theo hướng 3D. Bên phải, văn bản giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật vẫn giữ extrusion và hướng 3D hiển thị giống nhau.

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo hướng 3D ở bên trái và giữ phẳng ở bên phải](keep_text_flat.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo toàn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/nodejs-java/convert-powerpoint-to-png/), xuất thành [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), xuất thành [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/nodejs-java/convert-powerpoint-to-video/).

Lưu ý các điểm sau:

- Ảnh và PDF đã xuất không tương tác. Đối tượng không thể quay lại bởi người xem sau khi xuất.
- Nhìn cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, bộ ánh sáng, vật liệu, extrusion, màu nền và tỉ lệ slide.
- Nếu cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên theme, hãy đọc [thuộc tính hình hiệu quả](/slides/vi/nodejs-java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả hình ảnh được render thay vì được lưu dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bản trình chiếu 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình và văn bản. Nó không làm cho ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

**Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng được áp dụng lên một hình PowerPoint thông thường hoặc văn bản, như quay, extrusion, bevel, ánh sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

**Cài đặt nào là bắt buộc để có một hình 3D nhìn thấy được?**

Ít nhất, phải đặt một góc quay máy ảnh và hoặc extrusion hoặc độ sâu. Thực tế, cũng nên đặt bộ ánh sáng và vật liệu để các mặt được render có điểm nhấn và bóng đổ rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình và văn bản không?**

Có. Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getThreeDFormat) cho phần thân hình và [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render hiệu ứng 3D khi tạo ảnh slide, PDF, HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã được render, không phải một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc giá trị 3D cuối cùng sau khi kế thừa và cài đặt theme được áp dụng không?**

Có. Sử dụng API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/nodejs-java/shape-effective-properties/) để đọc các giá trị cuối cùng của máy ảnh, bộ ánh sáng, bevel và các giá trị 3D liên quan.