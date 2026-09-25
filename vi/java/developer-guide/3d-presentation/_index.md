---
title: Tạo hiệu ứng 3D trong bản trình chiếu bằng Java
linktitle: Bản trình chiếu 3D
type: docs
weight: 232
url: /vi/java/3d-presentation/
keywords:
- PowerPoint 3D
- bản trình chiếu 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Áp dụng và hiển thị hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Java bằng Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, đùn, tô màu và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn ép, viền ngang, chiếu sáng, vật liệu, tô màu dần hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó trong kết quả 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/), cho phép điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Điều này áp dụng định dạng 3D cho khung văn bản thay vì thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Những gì nó điều khiển | Khi nào nên sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getCamera--) | Góc nhìn, loại máy ảnh đã định sẵn, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getLightRig--) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách các điểm sáng và bóng xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Vật liệu bề mặt, chẳng hạn như phẳng, mờ, nhựa hoặc kim loại. | Làm cho hình dạng cùng một hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ rệt. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Màu của các mặt bên được đùn. | Làm cho độ sâu hiển thị hoặc phối hợp màu mặt bên với phần tô màu mặt trước. |
| [getDepth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Độ sâu 3D bổ sung được sử dụng bởi định dạng 3D của PowerPoint. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt viền và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Các cạnh nhô lên hoặc làm tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc đúc thay vì một mặt phẳng sắc nhọn. |
| [getContourColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getContourColor--) và [getContourWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getContourWidth--) và [setContourWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Đường viền quanh vật thể 3D. | Nhấn mạnh biên giới của vật thể trong kết quả hiển thị. |

## **Tạo một Hình 3D**

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.  
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các bên có thể nhìn thấy.  
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.  
- Cài đặt đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Giá trị xoay máy ảnh được tính bằng độ, và chiều cao đùn là 100 điểm. Ví dụ này hiển thị slide dưới dạng hình PNG với kích thước gấp đôi so với mặc định và lưu bản trình bày dưới dạng PPTX.

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

Hình ảnh slide đã được hiển thị cho thấy hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh với văn bản 3D trắng trên mặt trước](img_01_01.png)

## **Xoay một Hình bằng Máy ảnh**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng điều khiển 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với việc xoay bạn thiết lập thông qua API máy ảnh.

![Bảng 3-D Rotation của PowerPoint với các giá trị xoay X, Y và Z được làm nổi bật](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh thông qua [IThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getCamera--). Ví dụ này tạo một hình chữ nhật, chọn chế độ xem mặt trước trực giao, và đặt các góc xoay X, Y, Z thành 20°, 30° và 40° tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu file:

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

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi quan điểm 3D mà PowerPoint và Aspose.Slides sử dụng khi hiển thị.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu xác định độ dày hiển thị này, và điều khiển màu sắc xác định màu của các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Sử dụng [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) để đặt độ dày và [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật đùn 100 điểm với các mặt bên màu tím và xoay máy ảnh để hiển thị độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu file:

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

Phương thức [IThreeDFormat.setDepth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setDepth-double-) đặt độ sâu cho một hình 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) kiểm soát chiều cao của hiệu ứng đùn, như trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc tô màu hình dạng. Bạn có thể áp dụng màu đồng nhất, gradient, họa tiết hoặc hình ảnh lên mặt trước và vẫn sử dụng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng gradient từ xanh dương sang cam cho mặt trước và màu cam đậm cho phần đùn 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu bắt đầu và kết thúc gradient. Giá trị xoay máy ảnh tính bằng độ. Slide được hiển thị dưới dạng hình PNG với kích thước gấp đôi so với mặc định:

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

![Hình chữ nhật 3D được hiển thị với màu gradient xanh dương đến cam và đùn màu cam](img_02_03.png)

Để sử dụng tô hình ảnh thay thế, thêm ảnh vào bản trình bày và gán nó cho phần tô của hình. Ví dụ này yêu cầu một tệp hiện có tên "image.jpg" trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm và đặt góc xoay máy ảnh tính bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc hiển thị tệp:

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

![Hình chữ nhật 3D được hiển thị với tô ảnh trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình ảnh ảnh hưởng đến thân hình dạng. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần đùn, vật liệu, chiếu sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với họa tiết lưới cam-trắng, áp dụng một vòng cung lên trên, và cấu hình các cài đặt 3D qua [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Chiều cao và độ sâu đùn tính bằng điểm, và góc xoay ánh sáng tính bằng độ. Phần tô và viền của hình dạng được ẩn để chỉ hiển thị văn bản. Ví dụ này hiển thị hình PNG với kích thước gấp đôi kích thước slide mặc định và lưu bản trình bày thành PPTX:

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

![Văn bản 3D được hiển thị với biến đổi WordArt dạng vòng cung, tô họa tiết cam và đùn màu tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ cho văn bản dễ đọc đồng thời bảo toàn vẻ ngoài 3D của hình, gọi [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) qua [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Khi giá trị là `true`, văn bản sẽ không nằm trong cảnh 3D. Khi là `false`, văn bản sẽ tham gia vào cảnh và tuân theo hướng 3D của nó.

Cài đặt này không loại bỏ định dạng 3D của hình: máy ảnh, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getThreeDFormat--). Nó cũng khác với việc xoay thông thường. [IShape.setRotation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setRotation-float-) xoay hình trong mặt phẳng slide, trong khi [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kiểm soát góc xoay tùy chỉnh của văn bản trong hộp chứa. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong số này.

Ví dụ tự chứa sau tạo một hình chữ nhật màu xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao đùn là 40 điểm. Ví dụ này lưu bản trình bày thành PPTX và hiển thị slide so sánh dưới dạng PNG với kích thước gấp đôi so với mặc định.

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

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo hướng 3D ở bên trái và giữ phẳng ở bên phải](keep_text_flat.png)

## **Xuất và Hành vi Hiển thị**

Aspose.Slides bảo tồn định dạng 3D khi lưu thành các định dạng PowerPoint như PPTX. Khi hiển thị hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn hiển thị slide thành [PNG](/slides/vi/java/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/java/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/java/convert-powerpoint-to-video/).

- Hình ảnh và PDF đã xuất không có tính tương tác. Đối tượng không thể được người xem xoay sau khi xuất.  
- Bản ngoài cùng phụ thuộc vào sự kết hợp của máy ảnh, bộ ánh sáng, vật liệu, đùn, tô màu và tỉ lệ slide.  
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, hãy đọc [effective shape properties](/slides/vi/java/shape-effective-properties/).  
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong những định dạng đó, kết quả hình ảnh được hiển thị thay vì được lưu dưới dạng cài đặt 3D có thể chỉnh sửa.

## **FAQ**

**Aspose.Slides có thể tạo bản trình bày 3D tương tác không?**

Aspose.Slides tạo và hiển thị các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML đã xuất trở thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Một mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình bày. Một hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như xoay, đùn, viền, chiếu sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Cài đặt nào cần thiết cho một hình 3D có thể nhìn thấy?**

Tối thiểu, cần đặt góc xoay máy ảnh và một trong hai: đùn hoặc độ sâu. Thực tế, cũng nên đặt bộ ánh sáng và vật liệu để các mặt hiển thị có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getThreeDFormat--) cho thân hình dạng và [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) cho văn bản.

**Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides hiển thị các hiệu ứng 3D khi tạo hình ảnh slide, đầu ra PDF, đầu ra HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã hiển thị, không phải một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt giao diện không?**

Có. Sử dụng các API định dạng hiệu lực được mô tả trong [Shape Effective Properties](/slides/vi/java/shape-effective-properties/) để đọc các giá trị cuối cùng của máy ảnh, bộ ánh sáng, viền và các giá trị 3D liên quan.