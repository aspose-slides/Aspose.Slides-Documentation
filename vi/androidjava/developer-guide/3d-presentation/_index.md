---
title: Tạo hiệu ứng 3D trong bài thuyết trình trên Android
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- quay 3D
- độ sâu 3D
- kéo dài 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trên Android với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, kéo dài, tô màu và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Android via Java có thể tạo, chỉnh sửa, bảo tồn và render định dạng 3D kiểu PowerPoint cho hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, kéo dài, bevels, chiếu sáng, vật liệu, tô màu gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản của PowerPoint. Nó không liên quan tới việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/), đối tượng điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Điều khiển gì | Khi nào nên dùng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Góc quan sát, loại máy ảnh mặc định, quay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một cài đặt quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách các điểm sáng và bóng xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Chất liệu bề mặt, chẳng hạn như phẳng, mờ, nhựa hoặc kim loại. | Làm cho hình học giống nhau trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Màu của các mặt bên được kéo dài. | Làm cho độ sâu hiển thị hoặc phối màu các mặt bên với màu nền phía trước. |
| [getDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng cho định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Các cạnh được nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nét. |
| [getContourColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) và [getContourWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) và [setContourWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả render. |

## **Tạo một hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thực sự 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần kéo dài.  
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các bên trở nên dễ đọc.  
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.  
- Cài đặt kéo dài hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị quay máy ảnh được tính bằng độ, và chiều cao kéo dài là 100 điểm. Ví dụ này render slide thành hình PNG với kích thước gấp đôi kích thước mặc định và lưu bản trình chiếu dưới dạng PPTX.

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

Hình ảnh slide đã render hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh được render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một hình dạng bằng máy ảnh**

Trong PowerPoint, quay 3D được cấu hình từ bảng **3‑D Rotation**. Các giá trị quay X, Y và Z tương ứng với góc quay bạn thiết lập qua API máy ảnh.

![Bảng điều khiển quay 3‑D của PowerPoint với các giá trị quay X, Y và Z được đánh dấu nổi bật](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh thông qua [IThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước kiểu orthographic, và đặt các góc quay X, Y, Z thành 20, 30 và 40 độ tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

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

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide, mà chỉ thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides dùng khi render.

## **Thêm kéo dài và độ sâu**

Kéo dài làm cho một hình dạng trông dày bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu thiết lập màu cho các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu kéo dài và chiều cao kéo dài](img_02_02.png)

Dùng [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) để đặt độ dày và [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật kéo dài 100 điểm với các mặt bên màu tím và quay máy ảnh để hiển thị độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

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

Phương thức [IThreeDFormat.setDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) đặt độ sâu cho một hình dạng 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) điều khiển chiều cao của hiệu ứng kéo dài, như trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu cho hình dạng. Bạn có thể áp dụng màu đặc, gradient, mẫu hoặc hình ảnh lên mặt trước và vẫn sử dụng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và kéo dài.

Ví dụ này áp dụng gradient từ xanh sang cam lên mặt trước và màu cam đậm cho phần kéo dài 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị quay máy ảnh tính bằng độ. Slide được render thành hình PNG với kích thước gấp đôi kích thước mặc định:

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

Kết quả render giữ gradient trên mặt trước và render phần kéo dài riêng biệt:

![Hình chữ nhật 3D được render với màu nền gradient từ xanh sang cam và phần kéo dài màu cam](img_02_03.png)

Để sử dụng đổ màu hình ảnh thay thế, thêm ảnh vào bản trình chiếu và gán nó cho nền hình dạng. Ví dụ này yêu cầu một tệp hiện có tên “image.jpg” trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng kéo dài 150 điểm và đặt quay máy ảnh tính bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc render tệp:

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

Hình ảnh được render trên mặt trước, trong khi phần kéo dài được render như bề mặt bên 3D:

![Hình chữ nhật 3D được render với hình ảnh nền trên mặt trước và phần kéo dài màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình dạng ảnh hưởng tới phần thân hình dạng. Định dạng 3D cho văn bản ảnh hưởng tới khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần kéo dài, vật liệu, chiếu sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với mẫu lưới cam‑trắng, áp dụng một vòm cong lên trên và cấu hình các cài đặt 3D qua [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Chiều cao kéo dài và độ sâu tính bằng điểm, và góc quay ánh sáng tính bằng độ. Nền và viền hình dạng được ẩn để chỉ văn bản hiển thị. Ví dụ này render một hình PNG với kích thước gấp đôi kích thước slide mặc định và lưu bản trình chiếu dưới dạng PPTX:

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

Văn bản được render dưới dạng chữ 3D cong, kéo dài:

![Văn bản 3D được render với hiệu ứng WordArt cong, màu nền họa tiết cam, và phần kéo dài màu tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình dạng 3D**

Để giữ văn bản dễ đọc trong khi vẫn bảo toàn diện mạo 3D của hình dạng, gọi [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) thông qua [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Khi giá trị là `true`, văn bản sẽ không nằm trong cảnh 3D. Khi giá trị là `false`, văn bản sẽ tham gia vào cảnh và theo hướng 3D của nó.

Cài đặt này không loại bỏ định dạng 3D của hình dạng: máy ảnh, ánh sáng, vật liệu và kéo dài vẫn được cấu hình qua [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Nó cũng khác với quay thông thường. [IShape.setRotation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setRotation-float-) quay hình dạng trong mặt phẳng slide, trong khi [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) điều khiển góc quay tùy chỉnh của văn bản trong khung giới hạn của nó. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong hai trường hợp trên.

Ví dụ tự chứa sau tạo một hình chữ nhật xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ thiết lập văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao kéo dài là 40 điểm. Ví dụ lưu bản trình chiếu dưới dạng PPTX và render slide so sánh thành PNG với kích thước gấp đôi kích thước mặc định.

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

Ở bên trái, văn bản theo hướng 3D. Ở bên phải, nó giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng phần kéo dài và hướng 3D nhìn thấy được.

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo hướng 3D ở phía bên trái và giữ phẳng ở phía bên phải](keep_text_flat.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo toàn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/androidjava/convert-powerpoint-to-png/), xuất thành [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), xuất thành [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), hoặc tạo các khung cho [video conversion](/slides/vi/androidjava/convert-powerpoint-to-video/).

Lưu ý các điểm sau:

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem xoay sau khi xuất.  
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, hệ thống ánh sáng, vật liệu, kéo dài, nền và thu phóng slide.  
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, hãy đọc [effective shape properties](/slides/vi/androidjava/shape-effective-properties/).  
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả trực quan được render thay vì được bảo toàn dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo các bản trình chiếu 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML xuất ra trở thành các cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn như quay, kéo dài, bevel, chiếu sáng và vật liệu. Bài viết này chỉ đề cập đến các hiệu ứng 3D.

**Cài đặt nào bắt buộc để có một hình dạng 3D nhìn được?**

Ít nhất, cần thiết lập một góc quay máy ảnh và hoặc kéo dài hoặc độ sâu. Thực tế, cũng nên thiết lập hệ thống ánh sáng và vật liệu để các mặt được render có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) cho phần thân hình dạng và [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) cho văn bản.

**Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render các hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa giao diện đã render, không phải một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi đã áp dụng kế thừa và cài đặt giao diện không?**

Có. Sử dụng các API định dạng hiệu lực mô tả trong [Shape Effective Properties](/slides/vi/androidjava/shape-effective-properties/) để đọc các giá trị máy ảnh, hệ thống ánh sáng, bevel và các giá trị 3D liên quan cuối cùng.