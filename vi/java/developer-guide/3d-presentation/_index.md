---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng Java
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/java/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Java với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Java có thể tạo, chỉnh sửa, bảo tồn và render định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn, bevels, chiếu sáng, vật liệu, gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide ra hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D đó vào kết quả 2D xuất ra.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), bộ điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Điều này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| API member | What it controls | When to use it |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Điểm nhìn, loại máy ảnh preset, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với preset xoay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Cài đặt ánh sáng preset, hướng và góc quay ánh sáng. | Thay đổi cách các điểm sáng và bóng xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho hình dạng cùng một hình học trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng kéo dài ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Màu của các mặt đùn. | Làm cho độ sâu dễ nhìn thấy hoặc phối hợp màu phía bên với màu lấp đầy mặt trước. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Các cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc được đúc thay vì mặt phẳng sắc nét. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) và [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) và [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới của đối tượng trong kết quả render. |

## **Tạo hình 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thật 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.  
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và bên trở nên dễ nhận biết.  
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.  
- Cài đặt đùn hoặc độ sâu, vì hình dạng phẳng cần có độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Giá trị xoay máy ảnh được tính bằng độ, và độ cao đùn là 100 điểm. Ví dụ này render slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình bày dưới dạng PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hình ảnh slide đã render hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh đã render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một hình dạng bằng Máy ảnh**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với góc xoay bạn thiết lập qua API máy ảnh.

![Bảng 3-D Rotation của PowerPoint với các giá trị xoay X, Y và Z được làm nổi bật](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước orthographic, và đặt các góc xoay X, Y, Z thành 20, 30 và 40 độ tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

### **Sao chép Định hướng Máy ảnh từ Hình mẫu**

Để khớp định hướng của một hình mẫu, đọc preset máy ảnh của nó bằng [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) và các góc xoay bằng [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Ví dụ mở `template.pptx` và sao chép định hướng máy ảnh từ hình đầu tiên trên slide đầu tiên sang hình thứ hai. Cả hai hình đều đã có ánh sáng 3D, và hình thứ hai không có góc xoay máy ảnh rõ ràng.

Các góc được tính bằng độ. Chỉ số `0` là vĩ độ, chỉ số `1` là kinh độ, và chỉ số `2` là vòng quay. Gửi chúng tới [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) theo thứ tự đó. Nếu nguồn trả về `null`, nghĩa là không có góc xoay rõ ràng, vì vậy để các góc của hình thứ hai không được đặt. Một góc xoay rõ ràng `(0, 0, 0)` trả về ba số không và nên được sao chép.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Khi bạn mở lại `camera-copy.pptx` trong PowerPoint, mũi tên bên phải có cùng preset máy ảnh và góc xoay như hình chữ nhật bên trái. Cả hai hình đều dùng cùng ánh sáng và độ sâu đùn.

![Một hình chữ nhật 3D màu xanh và một mũi tên bên phải với định hướng máy ảnh khớp, nhìn từ trên và bên phải](camera-orientation.png)

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu xác định độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu đùn và độ cao đùn](img_02_02.png)

Sử dụng [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) để đặt độ dày và [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật độ đùn 100 điểm với các mặt bên màu tím và xoay máy ảnh để bật độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu file:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Phương thức [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) đặt độ sâu cho một hình dạng 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) kiểm soát độ cao của hiệu ứng đùn, như trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với màu nền của hình. Bạn có thể áp dụng màu đồng nhất, gradient, hoa văn hoặc đổ màu hình ảnh lên mặt trước và vẫn sử dụng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng gradient từ xanh đến cam cho mặt trước và màu cam đậm cho độ đùn 150 điểm. Các điểm dừng gradient ở 0 và 100 đánh dấu đầu và cuối gradient. Giá trị xoay máy ảnh tính bằng độ. Slide được render thành ảnh PNG với kích thước gấp đôi mặc định:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kết quả render giữ gradient trên mặt trước và render đùn riêng biệt:

![Hình chữ nhật 3D được render với nền gradient xanh‑cam và đùn màu cam](img_02_03.png)

Để sử dụng đổ màu hình ảnh thay thế, thêm hình vào bản trình bày và gán nó cho nền hình. Ví dụ này yêu cầu có tệp "image.jpg" trong thư mục làm việc. Nó kéo dài hình để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm và đặt góc xoay máy ảnh tính bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hay render tệp:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Hình ảnh được render trên mặt trước, trong khi đùn được render thành bề mặt bên 3D:

![Hình chữ nhật 3D được render với nền ảnh trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh hưởng đến phần thân hình. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các chữ cái cần đùn, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với họa tiết lưới màu cam‑trắng, áp dụng vòm cong lên trên, và cấu hình các cài đặt 3D qua [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Độ cao đùn và độ sâu tính bằng điểm, và góc xoay ánh sáng tính bằng độ. Nền và viền của hình được ẩn để chỉ hiển thị văn bản. Ví dụ này render ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình bày dưới dạng PPTX:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Văn bản được render dưới dạng chữ 3D cong, đùn:

![Văn bản 3D được render với biến đổi WordArt cong, đổ mẫu màu cam và đùn tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ văn bản dễ đọc trong khi duy trì diện mạo 3D của hình, gọi [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) qua [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Khi giá trị là `true`, văn bản nằm ngoài cảnh 3D. Khi là `false`, văn bản tham gia vào cảnh và tuân theo hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình: máy ảnh, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). Nó cũng khác với việc xoay thông thường. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) xoay hình trong mặt phẳng slide, trong khi [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kiểm soát góc xoay tùy chỉnh của văn bản trong hộp giới hạn. Giữ văn bản ngoài cảnh 3D không đặt lại bất kỳ góc nào trong số này.

Ví dụ tự chứa dưới đây tạo một hình chữ nhật màu xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở phía trái và `true` ở phía phải. Các góc máy ảnh tính bằng độ, và độ cao đùn là 40 điểm. Ví dụ này lưu bản trình bày dưới dạng PPTX và render slide so sánh thành PNG với kích thước gấp đôi mặc định.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Ở phía trái, văn bản theo hướng 3D. Ở phía phải, nó giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng độ đùn hiển thị và hướng 3D.

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo hướng 3D ở trái và giữ phẳng ở phải](keep_text_flat.png)

## **Xuất và Hành vi Render**

Aspose.Slides giữ nguyên định dạng 3D khi lưu sang các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào kết quả đầu ra dưới dạng 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/java/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/java/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/java/convert-powerpoint-to-video/).

Hãy lưu ý các điểm sau:

- Hình ảnh và PDF đã xuất không có tính tương tác. Đối tượng không thể được người xem xoay sau khi xuất.  
- Hiển thị cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, light rig, vật liệu, đùn, nền và tỷ lệ slide.  
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên theme, hãy đọc [thuộc tính hình hiệu quả](/slides/vi/java/shape-effective-properties/).  
- Một số định dạng đầu ra không thể lưu định dạng 3D có thể chỉnh sửa của PowerPoint. Trong những định dạng này, kết quả hình ảnh được render thay vì được lưu như cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bản trình bày 3D tương tác không?**  
Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML được xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**  
Mô hình 3D là một đối tượng 3D riêng được chèn vào bản trình bày. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như xoay, đùn, bevel, chiếu sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Cài đặt nào cần thiết cho một hình 3D có thể nhìn thấy?**  
Tối thiểu, cần thiết lập góc xoay máy ảnh và một trong hai: đùn hoặc độ sâu. Thực tế, cũng nên thiết lập light rig và vật liệu để các mặt render có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**  
Có. Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) cho phần thân hình và [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**  
Có. Aspose.Slides render các hiệu ứng 3D khi tạo hình ảnh slide, xuất PDF, xuất HTML và các khung dùng cho chuyển đổi video. Đầu ra được xuất chứa hình ảnh render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt theme không?**  
Có. Sử dụng các API định dạng hiệu quả được mô tả trong [thuộc tính hình hiệu quả](/slides/vi/java/shape-effective-properties/) để đọc các giá trị cuối cùng của máy ảnh, light rig, bevel và các giá trị 3D liên quan.