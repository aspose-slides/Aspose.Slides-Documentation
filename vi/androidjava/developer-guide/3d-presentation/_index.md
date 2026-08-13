---
title: Tạo hiệu ứng 3D trong bản trình chiếu trên Android
linktitle: Bản trình chiếu 3D
type: docs
weight: 232
url: /vi/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- bản trình chiếu 3D
- xoay 3D
- độ sâu 3D
- nhô ra 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Áp dụng và kết xuất các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trên Android bằng Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, nhô ra, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides cho Android thông qua Java có thể tạo, chỉnh sửa, bảo tồn và kết xuất định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, nhô ra, viền, ánh sáng, vật liệu, màu nền gradient hoặc ảnh, và văn bản 3D.

{{% alert color="info" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ kết xuất các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm định dạng 3D**

Sử dụng phương thức [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/), cho phép kiểm soát cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Những gì nó kiểm soát | Khi nào sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Góc nhìn, loại camera đặt sẵn, xoay, phóng to và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một cài đặt xoay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Ánh sáng đặt sẵn, hướng và xoay ánh sáng. | Thay đổi cách các điểm sáng và bóng xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Vật liệu bề mặt, chẳng hạn như phẳng, mờ, nhựa, hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm mại hơn, bóng hơn hoặc kim loại hơn. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng mở rộng về phía sau từ mặt trước của nó. | Biến một hình phẳng thành một đối tượng 3D dày nhìn được. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Màu của các mặt bên được nhô ra. | Làm cho độ sâu hiển thị hoặc đồng bộ màu mặt bên với màu nền phía trước. |
| [getDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt viền và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Các cạnh nổi lên hoặc được bo tròn trên mặt trước và mặt sau. | Thêm cạnh làm mềm hoặc được đúc thay vì mặt phẳng sắc nhọn. |
| [getContourColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), và [setContourWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả hiển thị. |

## **Tạo một hình 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thật 3D:

- Cài đặt camera, vì góc nhìn mặt trước mặc định có thể che mất phần nhô ra.
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các bên nhìn rõ hơn.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được kết xuất.
- Cài đặt nhô ra hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình bày dưới dạng PPTX và kết xuất slide thành hình ảnh PNG.

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

Hình ảnh slide đã kết xuất cho thấy hình chữ nhật dưới dạng một khối 3D dày:

![Hình chữ nhật 3D màu xanh với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một hình dạng bằng Camera**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng Xoay 3D. Các giá trị xoay X, Y và Z tương ứng với góc xoay bạn đặt qua API camera.

![Bảng Xoay 3D của PowerPoint với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, đặt loại camera và góc xoay thông qua [IThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

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

Bạn sử dụng camera khi cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi kết xuất.

## **Thêm Nhô ra và Độ sâu**

Nhô ra làm cho một hình dạng trông dày hơn bằng cách mở rộng nó phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày nhìn thấy này, và điều khiển màu đặt màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được liên kết với các thuộc tính màu nhô ra và chiều cao nhô ra](img_02_02.png)

Đặt [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) cho độ dày và [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) cho màu mặt bên:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Sử dụng [IThreeDFormat.setDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với viền, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp hình dạng, `setExtrusionHeight` là cài đặt rõ ràng hơn vì nó diễn đạt trực tiếp phần nhô ra nhìn thấy.

## **Sử dụng màu nền Gradient hoặc Hình ảnh với hiệu ứng 3D**

Định dạng 3D độc lập với màu nền của hình. Bạn có thể áp dụng màu đồng nhất, gradient, họa tiết hoặc màu nền ảnh cho mặt trước và vẫn sử dụng cùng một camera, ánh sáng, vật liệu và cài đặt nhô ra.

Ví dụ này áp dụng màu nền gradient cho hình dạng và màu nhô ra tối hơn cho các mặt bên:

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

![Hình chữ nhật 3D đã kết xuất với màu nền gradient từ xanh đến cam và nhô ra màu cam](img_02_03.png)

Để sử dụng màu nền hình ảnh thay thế, thêm ảnh vào bản trình bày và gán nó cho màu nền của hình:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

![Hình chữ nhật 3D đã kết xuất với màu nền ảnh trên mặt trước và nhô ra màu cam](img_02_04.png)

## **Áp dụng định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng đến phần thân hình. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần nhô ra, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với màu nền họa tiết, áp dụng biến đổi WordArt, và cấu hình cài đặt 3D trên [ITextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

![Văn bản 3D đã kết xuất với biến đổi WordArt cong, màu nền họa tiết cam và nhô ra tối](img_02_05.png)

## **Hành vi xuất và kết xuất**

Aspose.Slides bảo tồn định dạng 3D khi lưu thành các định dạng PowerPoint như PPTX. Khi kết xuất hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn kết xuất slide thành [PNG](/slides/vi/androidjava/convert-powerpoint-to-png/), xuất thành [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), xuất thành [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/androidjava/convert-powerpoint-to-video/).

Lưu ý các điểm sau:

- Hình ảnh và PDF đã xuất không có tính tương tác. Đối tượng không thể được xoay bởi người xem sau khi xuất.
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của camera, ánh sáng, vật liệu, nhô ra, màu nền và tỷ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng được kế thừa hoặc dựa trên chủ đề, đọc [thuộc tính hình dạng hiệu quả](/slides/vi/androidjava/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D có thể chỉnh sửa của PowerPoint. Trong các định dạng đó, kết quả hình ảnh được kết xuất thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

### Aspose.Slides có thể tạo các bản trình bày 3D tương tác không?

Aspose.Slides tạo và kết xuất các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML được xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

### Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình bày. Hiệu ứng 3D là định dạng áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn như xoay, nhô ra, viền, ánh sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

### Cài đặt nào cần thiết cho một hình 3D có thể nhìn thấy?

Ít nhất, cần đặt một góc xoay camera và hoặc nhô ra hoặc độ sâu. Thực tế, cũng nên đặt ánh sáng và vật liệu để các mặt được kết xuất có điểm nhấn và bóng rõ ràng.

### Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?

Có. Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) cho phần thân hình và [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) cho văn bản.

### Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?

Có. Aspose.Slides kết xuất các hiệu ứng 3D khi tạo hình ảnh slide, đầu ra PDF, đầu ra HTML và các khung được dùng cho chuyển đổi video. Đầu ra đã xuất chứa giao diện đã được kết xuất, không phải một đối tượng 3D có thể chỉnh sửa.

### Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt chủ đề không?

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/androidjava/shape-effective-properties/) để đọc camera, ánh sáng, viền và các giá trị 3D liên quan cuối cùng.