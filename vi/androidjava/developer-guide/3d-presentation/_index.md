---
title: Tạo hiệu ứng 3D trong bài thuyết trình trên Android
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- độ chuyển màu 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trên Android với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides cho Android thông qua Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn, gờ, chiếu sáng, vật liệu, độ chuyển màu hoặc tô ảnh, và văn bản 3D.

{{% alert color="primary" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide sang hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó trong kết quả 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [IThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/), chịu trách nhiệm điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì cho phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Chức năng điều khiển | Khi nào sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Góc nhìn, loại máy ảnh preset, xoay, phóng đại và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với preset xoay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Preset ánh sáng, hướng và xoay ánh sáng. | Thay đổi cách các điểm nhấn và bóng tối hiển thị trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho hình dạng giống nhau trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Màu của các mặt đáy được đùn ra. | Làm cho độ sâu hiển thị hoặc phối hợp màu mặt bên với màu nền phía trước. |
| [getDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt gờ và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Các cạnh nổi lên hoặc được làm tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nhọn. |
| [getContourColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), và [setContourWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả render. |

## **Tạo một Hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thực sự 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn đi phần đùn.
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và bên có thể nhìn thấy.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.
- Cài đặt độ đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình bày dưới dạng PPTX và render slide thành hình ảnh PNG.

```java
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

![Hình chữ nhật 3D màu xanh có văn bản 3D màu trắng trên mặt trước được render](img_01_01.png)

## **Xoay một Hình dạng bằng Máy ảnh**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với việc xoay bạn thiết lập qua API máy ảnh.

![Bảng 3-D Rotation của PowerPoint với các giá trị xoay X, Y và Z được ưu việt](img_02_01.png)

Trong Aspose.Slides, thiết lập loại máy ảnh và xoay thông qua [IThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D được PowerPoint và Aspose.Slides sử dụng khi render.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Đặt [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) để thiết lập độ dày và [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) để đặt màu phía bên:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Sử dụng [IThreeDFormat.setDepth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với gờ, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp hình dạng, `setExtrusionHeight` là cài đặt rõ ràng hơn vì nó trực tiếp biểu thị độ đùn có thể thấy.

## **Sử dụng Đổ Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc tô màu hình. Bạn có thể áp dụng màu đặc, gradient, mẫu hoặc hình ảnh vào mặt trước và vẫn sử dụng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng đổ gradient cho hình và màu đùn tối hơn cho các mặt bên:

```java
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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

![Hình chữ nhật 3D được render với gradient màu xanh đến cam và đùn màu cam](img_02_03.png)

Để sử dụng tô hình ảnh, thêm ảnh vào bản trình bày và gán nó làm màu nền cho hình:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

Hình chữ nhật 3D được render với hình ảnh trên mặt trước và đùn màu cam:

![Hình chữ nhật 3D được render với hình ảnh trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình ảnh ảnh hưởng đến phần thân hình dạng. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với màu nền mẫu, áp dụng biến đổi WordArt và cấu hình cài đặt 3D trên [ITextFrameFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/):

```java
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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

Văn bản được render dưới dạng chữ 3D cong, đùn:

![Văn bản 3D được render với biến đổi WordArt cong, màu nền mẫu màu cam và đùn tối](img_02_05.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu vào các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra như một kết quả 2D. Điều này áp dụng khi bạn render slide sang [PNG](/slides/vi/androidjava/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/androidjava/convert-powerpoint-to-video/).

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem xoay sau khi xuất.
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, hệ thống ánh sáng, vật liệu, độ đùn, màu nền và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, hãy đọc [thuộc tính hình dạng hiệu quả](/slides/vi/androidjava/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả hình ảnh được render thay vì được lưu dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bản trình bày 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML được xuất trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bài thuyết trình. Hiệu ứng 3D là định dạng áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như xoay, đùn, gờ, chiếu sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Các cài đặt nào cần thiết cho một hình dạng 3D có thể nhìn thấy?**

Ít nhất, thiết lập xoay máy ảnh và hoặc là độ đùn hoặc độ sâu. Trong thực tế, cũng cần thiết lập hệ thống ánh sáng và vật liệu để các mặt được render có điểm nhấn và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [IShape.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) cho phần thân hình dạng và [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render các hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và các khung được sử dụng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt giao diện không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/androidjava/shape-effective-properties/) để đọc các giá trị cuối cùng của máy ảnh, hệ thống ánh sáng, gờ và các giá trị 3D liên quan.