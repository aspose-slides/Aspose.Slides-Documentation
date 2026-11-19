---
title: Tạo hiệu ứng 3D trong bản trình chiếu trên Android
linktitle: Bản trình chiếu 3D
type: docs
weight: 232
url: /vi/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- bản trình chiếu 3D
- quay 3D
- độ sâu 3D
- đùn 3D
- độ chuyển màu 3D
- văn bản 3D
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Áp dụng và hiển thị các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trên Android với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, đùn, tô đầy và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Android via Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, đùn, viền, ánh sáng, vật liệu, độ chuyển màu hoặc ảnh nền, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Các khái niệm định dạng 3D**

Sử dụng phương thức [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/), vốn kiểm soát cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Điều gì nó điều khiển | Khi nào nên sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Góc nhìn, loại máy ảnh đặt sẵn, quay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một mẫu quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Cài đặt ánh sáng, hướng và quay ánh sáng. | Thay đổi cách nổi bật và bóng xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Vật liệu bề mặt, chẳng hạn phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình học trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Khoảng cách hình dạng mở rộng ra phía sau mặt trước. | Biến một hình phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Màu của các mặt bên được đùn ra. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với màu nền mặt trước. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng cho định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt viền và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nhọn. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) và [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) và [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Đường viền xung quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong đầu ra đã hiển thị. |

## **Tạo một hình dạng 3D**

Một hình dạng thường cần bốn loại thiết lập trước khi trông thật sự 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể che giấu phần đùn.
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và các bên trở nên dễ nhìn.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.
- Cài đặt đùn hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Giá trị quay của máy ảnh được tính bằng độ, và chiều cao đùn là 100 điểm. Ví dụ này hiển thị slide thành hình ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình bày dưới dạng PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

Hình ảnh slide đã hiển thị cho thấy hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một hình dạng bằng máy ảnh**

Trong PowerPoint, việc quay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị quay X, Y và Z tương ứng với phép quay bạn thiết lập qua API máy ảnh.

![Bảng 3-D Rotation của PowerPoint với các giá trị quay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước orthographic, và đặt các quay X, Y, Z thành 20, 30 và 40 độ tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

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

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình dạng trên slide. Nó thay đổi góc nhìn 3D được PowerPoint và Aspose.Slides sử dụng khi hiển thị.

### **Sao chép hướng máy ảnh từ một hình dạng mẫu**

Để khớp hướng của một hình dạng mẫu, đọc cài đặt máy ảnh của nó bằng [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) và các góc quay bằng [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--). Ví dụ mở `template.pptx` và sao chép hướng máy ảnh từ hình dạng đầu tiên trên slide đầu tiên sang hình dạng thứ hai. Cả hai hình đều đã có ánh sáng 3D, và hình dạng thứ hai không có quay máy ảnh cụ thể.

Các góc được tính bằng độ. Chỉ mục `0` là vĩ độ, chỉ mục `1` là kinh độ, và chỉ mục `2` là vòng quay. Gửi chúng tới [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) theo thứ tự đó. Nếu nguồn trả về `null`, nó không có quay cụ thể, vì vậy để nguyên các góc của hình dạng thứ hai. Một quay cụ thể `(0, 0, 0)` trả về ba số 0 và nên được sao chép.

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

Khi bạn mở lại `camera-copy.pptx` trong PowerPoint, mũi tên bên phải có cùng cài đặt máy ảnh và quay như hình chữ nhật bên trái. Cả hai hình đều sử dụng cùng ánh sáng và độ sâu đùn.

![Một hình chữ nhật 3D màu xanh và một mũi tên sang phải với hướng máy ảnh khớp, nhìn từ trên và bên phải](camera-orientation.png)

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Sử dụng [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) để đặt độ dày và [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) để truy cập màu mặt bên. Ví dụ này cung cấp cho một hình chữ nhật đùn 100 điểm với các mặt bên màu tím và quay máy ảnh để hiện ra độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

Phương thức [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) thiết lập độ sâu của một hình dạng 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) điều khiển chiều cao của hiệu ứng đùn, như được minh họa trong ví dụ này.

## **Sử dụng độ chuyển màu hoặc ảnh nền với hiệu ứng 3D**

Định dạng 3D hoạt động độc lập với việc tô đầy hình dạng. Bạn có thể áp dụng màu nguyên thể, độ chuyển màu, mẫu hoặc ảnh nền cho mặt trước và vẫn sử dụng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng độ chuyển màu xanh dương sang cam cho mặt trước và màu cam đậm cho phần đùn 150 điểm. Các điểm dừng độ chuyển màu ở 0 và 100 đánh dấu đầu và cuối độ chuyển màu. Các giá trị quay máy ảnh tính bằng độ. Slide được hiển thị thành ảnh PNG với kích thước gấp đôi mặc định:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

Kết quả hiển thị giữ độ chuyển màu trên mặt trước và hiển thị phần đùn riêng biệt:

![Hình chữ nhật 3D được hiển thị với độ chuyển màu xanh-dương sang cam và đùn màu cam](img_02_03.png)

Để sử dụng ảnh nền thay thế, thêm hình ảnh vào bản trình bày và gán nó cho phần tô đầy hình dạng. Ví dụ này yêu cầu có một tệp tồn tại tên "image.jpg" trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm, và đặt quay máy ảnh theo độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc hiển thị tệp:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

Ảnh được hiển thị trên mặt trước, trong khi phần đùn được hiển thị như bề mặt 3D bên.

![Hình chữ nhật 3D được hiển thị với ảnh nền trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng định dạng 3D cho văn bản**

Định dạng 3D của hình dạng ảnh hưởng đến phần thân hình. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng giống WordArt, nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với mẫu lưới cam và trắng, áp dụng một vòng cung lên trên, và cấu hình các cài đặt 3D qua [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Chiều cao và độ sâu đùn tính bằng điểm, và quay ánh sáng tính bằng độ. Phần tô và viền của hình được ẩn để chỉ văn bản hiển thị. Ví dụ này hiển thị ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình bày dưới dạng PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

Văn bản được hiển thị dưới dạng chữ 3D cong, đã đùn:

![Văn bản 3D được hiển thị với biến đổi WordArt dạng vòng cung, mẫu màu cam và đùn tối](img_02_05.png)

## **Giữ văn bản phẳng trên hình dạng 3D**

Để giữ cho văn bản dễ đọc trong khi vẫn duy trì vẻ 3D của hình dạng, gọi [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) thông qua [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Khi giá trị là `true`, văn bản sẽ không nằm trong cảnh 3D. Khi là `false`, văn bản sẽ tham gia vào cảnh và tuân theo hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình dạng: máy ảnh, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Nó cũng khác với quay thông thường. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) quay hình trong mặt phẳng slide, trong khi [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) kiểm soát quay tùy chỉnh của văn bản trong khung bao. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong số đó.

Ví dụ tự chứa sau tạo một hình chữ nhật xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao đùn là 40 điểm. Ví dụ này lưu bản trình bày dưới dạng PPTX và hiển thị slide so sánh thành PNG với kích thước gấp đôi mặc định.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

Bên trái, văn bản theo hướng 3D. Bên phải, nó giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng độ đùn nhìn thấy và hướng 3D.

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo hướng 3D bên trái và giữ phẳng bên phải](keep_text_flat.png)

## **Hành vi xuất và hiển thị**

Aspose.Slides giữ định dạng 3D khi lưu dưới dạng PowerPoint như PPTX. Khi hiển thị hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra như kết quả 2D. Điều này áp dụng khi bạn hiển thị slide thành [PNG](/slides/vi/androidjava/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/androidjava/convert-powerpoint-to-video/).

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem quay sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, hệ thống ánh sáng, vật liệu, đùn, tô đầy và tỷ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, hãy đọc [các thuộc tính hình dạng hiệu quả](/slides/vi/androidjava/shape-effective-properties/).
- Một số định dạng xuất không thể lưu định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả hình ảnh được hiển thị thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **FAQ**

**Aspose.Slides có thể tạo bản trình diễn 3D tương tác không?**

Aspose.Slides tạo và hiển thị các hiệu ứng 3D của PowerPoint cho các hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML đã xuất trở thành cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình diễn. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như quay, đùn, viền, ánh sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Cài đặt nào cần thiết cho một hình dạng 3D có thể nhìn thấy?**

Ít nhất, cần đặt một quay máy ảnh và hoặc đùn hoặc độ sâu. Thực tế, cũng cần đặt hệ thống ánh sáng và vật liệu để các mặt hiển thị có nổi bật và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) cho phần thân hình dạng và [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) cho văn bản.

**Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides hiển thị các hiệu ứng 3D khi tạo ảnh slide, xuất ra PDF, HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã hiển thị, không phải là một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt giao diện không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [các thuộc tính hình dạng hiệu quả](/slides/vi/androidjava/shape-effective-properties/) để đọc các giá trị camera, hệ thống ánh sáng, viền và các giá trị 3D liên quan cuối cùng.