---
title: Tạo Hiệu Ứng 3D trong Bài Thuyết Trình bằng Java
linktitle: Bài Thuyết Trình 3D
type: docs
weight: 232
url: /vi/java/3d-presentation/
keywords:
- PowerPoint 3D
- Bài thuyết trình 3D
- Xoay 3D
- Độ sâu 3D
- Đùn 3D
- Gradient 3D
- Văn bản 3D
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Áp dụng và hiển thị các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Java với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D theo kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, đùn, viền chừng, chiếu sáng, vật liệu, tô màu gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không đề cập đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó trong kết quả 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/).`getThreeDFormat()` để áp dụng định dạng 3D cho một hình dạng. Đối tượng định dạng trả về kiểm soát cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng [ITextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Điều này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Chức năng điều khiển | Khi nào nên sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getCamera--) | Điểm nhìn, loại máy ảnh mặc định, quay, thu phóng và phối cảnh. | Quay đối tượng trong không gian 3D hoặc khớp với một cài đặt quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getLightRig--) | Cài đặt ánh sáng mặc định, hướng và quay ánh sáng. | Thay đổi cách các điểm nhấn và bóng tối xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại hơn. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Màu của các mặt bên được đùn. | Làm cho độ sâu hiển thị hoặc phối màu bên với màu nền phía trước. |
| [getDepth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng cho định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt viền và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm hoặc đúc thay vì một mặt phẳng nhọn. |
| [getContourColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#getContourWidth--), và [setContourWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong đầu ra đã hiển thị. |

## **Tạo một Hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thuyết phục như 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và các bên trở nên rõ ràng.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng tới cách ánh sáng được hiển thị.
- Cài đặt đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình bày dưới dạng PPTX và hiển thị slide thành ảnh PNG.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

![Hình chữ nhật 3D màu xanh được hiển thị với văn bản 3D trắng trên mặt trước](img_01_01.png)

## **Quay một Hình dạng bằng Máy ảnh**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với việc xoay bạn thiết lập qua API máy ảnh.

![Bảng 3-D Rotation của PowerPoint với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, đặt loại máy ảnh và xoay thông qua định dạng 3D trả về bởi `shape.getThreeDFormat()`:

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

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình dạng trên slide. Nó thay đổi quan điểm 3D mà PowerPoint và Aspose.Slides sử dụng khi hiển thị.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày bằng cách kéo nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu thiết lập màu của các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Đặt chiều cao đùn để xác định độ dày và màu đùn cho màu mặt bên:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Sử dụng cài đặt độ sâu khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với viền, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp hình dạng, chiều cao đùn là cài đặt rõ ràng hơn vì nó trực tiếp biểu thị phần đùn hiển thị.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu hình dạng. Bạn có thể áp dụng màu đặc, gradient, hoa văn hoặc đổ hình ảnh lên mặt trước và vẫn sử dụng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng đổ gradient cho hình dạng và màu đùn tối hơn cho các mặt bên:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

![Hình chữ nhật 3D đã hiển thị với đổ gradient từ xanh đến cam và đùn màu cam](img_02_03.png)

Để sử dụng đổ hình ảnh thay thế, thêm ảnh vào bản trình bày và gán nó cho đổ hình dạng:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
    byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Hình chữ nhật 3D đã hiển thị với đổ ảnh trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình dạng ảnh hưởng đến phần thân hình dạng. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với đổ hoa văn, áp dụng biến đổi WordArt và cấu hình cài đặt 3D trên [ITextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/):

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

![Văn bản 3D đã hiển thị với biến đổi WordArt cong, đổ hoa văn màu cam và đùn tối](img_02_05.png)

## **Hành vi Xuất và Hiển thị**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi hiển thị hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn hiển thị slide thành [PNG](/slides/vi/java/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/java/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/java/convert-powerpoint-to-video/).

Hãy ghi nhớ các điểm sau:

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem quay sau khi xuất.
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, hệ thống ánh sáng, vật liệu, đùn, màu nền và tỷ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, hãy đọc [effective shape properties](/slides/vi/java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả hình ảnh được hiển thị chứ không được lưu giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi Thường gặp**

### Aspose.Slides có thể tạo bản trình bày 3D tương tác không?

Aspose.Slides tạo và hiển thị các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML đã xuất trở thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

### Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?

Mô hình 3D là một đối tượng 3D riêng được chèn vào bản trình bày. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như quay, đùn, viền, chiếu sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

### Cài đặt nào cần thiết cho một hình dạng 3D có thể nhìn thấy?

Cần ít nhất thiết lập quay máy ảnh và hoặc đùn hoặc độ sâu. Trong thực tế, cũng nên thiết lập hệ thống ánh sáng và vật liệu để các mặt hiển thị có điểm nhấn và bóng rõ ràng.

### Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?

Có. Sử dụng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/).`getThreeDFormat()` cho phần thân hình dạng và [ITextFrameFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` cho văn bản.

### Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?

Có. Aspose.Slides hiển thị các hiệu ứng 3D khi tạo ảnh slide, xuất PDF, xuất HTML và tạo khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa giao diện đã hiển thị, không phải là đối tượng 3D có thể chỉnh sửa.

### Tôi có thể đọc các giá trị 3D cuối cùng sau khi kế thừa và cài đặt giao diện được áp dụng không?

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/java/shape-effective-properties/) để đọc các giá trị máy ảnh, hệ thống ánh sáng, viền và các giá trị 3D liên quan cuối cùng.