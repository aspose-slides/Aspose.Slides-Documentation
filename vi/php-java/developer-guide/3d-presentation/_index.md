---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng PHP
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/php-java/3d-presentation/
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
- PHP
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho hình dạng và văn bản PowerPoint trong PHP với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, extrusion, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for PHP via Java có thể tạo, chỉnh sửa, bảo tồn và render định dạng 3D kiểu PowerPoint cho hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, extrusion, bevel, ánh sáng, vật liệu, độ đổ màu gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="primary" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản của PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D đó vào kết quả 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) và phương thức [Shape::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức trả về [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/), điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/) và phương thức [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Điều này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các cài đặt quan trọng nhất là:

| Phương thức hoặc cài đặt | Điều gì nó điều khiển | Khi nào nên sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getCamera--) | Góc nhìn, kiểu máy ảnh mặc định, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getLightRig--) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách các vùng sáng và bóng xuất hiện trên bề mặt 3D. |
| [setMaterial](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Chất liệu bề mặt, chẳng hạn phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [setExtrusionHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Màu của các mặt bên được kéo dài. | Làm cho độ sâu hiển thị hoặc phối hợp màu mặt bên với màu nền phía trước. |
| [setDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng cho định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và material. |
| [getBevelTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getBevelBottom--) | Cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nét. |
| [getContourColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getContourColor--) và [setContourWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Viền bao quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả render. |

## **Tạo hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thuyết phục là 3D:

- Cài đặt camera, vì chế độ xem mặt trước mặc định có thể ẩn extrusion.
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và cạnh có thể nhìn thấy.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.
- Cài đặt extrusion hoặc độ sâu, vì một hình dạng phẳng cần có độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình bày dưới dạng PPTX và render slide thành ảnh PNG.

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hình ảnh slide được render hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh được render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay hình dạng bằng Máy ảnh**

Trong PowerPoint, việc quay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị quay X, Y và Z tương ứng với góc quay bạn thiết lập qua API máy ảnh.

![Bảng xoay 3D của PowerPoint với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, đặt loại máy ảnh và góc quay thông qua [ThreeDFormat::getCamera](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

## **Thêm Extrusion và Độ sâu**

Extrusion làm cho một hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu thiết lập màu cho các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu extrusion và độ cao extrusion](img_02_02.png)

Đặt [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) để xác định độ dày và [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getExtrusionColor--) để xác định màu mặt bên:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Sử dụng [ThreeDFormat::setDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setDepth-double-) khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với bevel, material và các hiệu ứng văn bản. Trong nhiều trường hợp hình dạng, `setExtrusionHeight` là cài đặt rõ ràng hơn vì nó trực tiếp biểu thị extrusion có thể nhìn thấy.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu hình dạng. Bạn có thể áp dụng màu đồng nhất, gradient, pattern hoặc hình ảnh cho mặt trước và vẫn sử dụng cùng máy ảnh, ánh sáng, vật liệu và cài đặt extrusion.

Ví dụ này áp dụng độ đổ gradient cho hình và màu extrusion tối hơn cho các mặt bên:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Kết quả render giữ gradient trên mặt trước và render extrusion riêng biệt:

![Hình chữ nhật 3D được render với độ đổ màu gradient từ xanh đến cam và extrusion màu cam](img_02_03.png)

Để sử dụng độ đổ hình ảnh thay thế, thêm hình vào bản trình bày và gán nó cho độ đổ hình dạng:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

Hình ảnh được render trên mặt trước, trong khi extrusion được render như bề mặt 3D bên:

![Hình chữ nhật 3D được render với hình ảnh trên mặt trước và extrusion màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình dạng ảnh hưởng đến phần thân hình, trong khi định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần extrusion, material, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với độ đổ pattern, áp dụng biến đổi WordArt và cấu hình các cài đặt 3D trên [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/):

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Văn bản được render dưới dạng chữ 3D cong, extrusion:

![Văn bản 3D được render với hiệu ứng WordArt cong, độ đổ pattern cam và extrusion tối màu](img_02_05.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/php-java/convert-powerpoint-to-png/), xuất thành [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), xuất thành [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/php-java/convert-powerpoint-to-video/).

Hãy nhớ các điểm sau:

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được xoay bởi người xem sau khi xuất.
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, light rig, material, extrusion, fill và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng được kế thừa hoặc dựa trên theme, hãy đọc [các thuộc tính hình dạng hiệu quả](/slides/vi/php-java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong những định dạng đó, kết quả hình ảnh được render thay vì được lưu dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bài thuyết trình 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML xuất ra trở thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình bày. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như quay, extrusion, bevel, ánh sáng và vật liệu. Bài viết này chỉ nói về hiệu ứng 3D.

**Cài đặt nào cần thiết để có một hình dạng 3D hiển thị?**

Ít nhất, cần đặt một góc quay máy ảnh và entweder extrusion hoặc depth. Thực tế, cũng nên đặt light rig và material để các mặt được render có điểm nhấn và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getThreeDFormat--) cho phần thân hình và [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#getThreeDFormat--) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất ra hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt theme không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [các thuộc tính hình dạng hiệu quả](/slides/vi/php-java/shape-effective-properties/) để đọc camera, light rig, bevel và các giá trị 3D liên quan cuối cùng.