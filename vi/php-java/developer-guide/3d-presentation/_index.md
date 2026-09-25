---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng PHP
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/php-java/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- quay 3D
- độ sâu 3D
- ép 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Áp dụng và kết xuất các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong PHP với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, ép, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides cho PHP qua Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D theo kiểu PowerPoint cho hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, ép, viền chéo, chiếu sáng, vật liệu, độ gradient hoặc ảnh nền, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không nói về việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide ra ảnh, PDF hoặc HTML, Aspose.Slides sẽ kết xuất các hiệu ứng 3D này vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [Shape::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getThreeDFormat--) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/), điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Điều khiển | Khi nào sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getCamera--) | Góc nhìn, loại máy ảnh mẫu, quay, thu phóng và phối cảnh. | Quay đối tượng trong không gian 3D hoặc khớp với một mẫu quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getLightRig--) | Mẫu ánh sáng, hướng và quay ánh sáng. | Thay đổi cách nổi bật và bóng đổ xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getMaterial--) và [setMaterial](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Vật liệu bề mặt, chẳng hạn như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình học trông phẳng hơn, mềm mại hơn, bóng hơn hoặc kim loại hơn. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getExtrusionHeight--) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Chuyển một hình dạng phẳng thành một vật thể 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Màu của các mặt bên được ép. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với màu nền mặt trước. |
| [getDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getDepth--) và [setDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setDepth-double-) | Độ sâu 3D bổ sung được PowerPoint sử dụng. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt viền chéo và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getBevelTop--) và [getBevelBottom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getBevelBottom--) | Các cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc được tạo khuôn thay vì mặt phẳng sắc nét. |
| [getContourColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getContourColor--) và [getContourWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getContourWidth--) và [setContourWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong đầu ra đã kết xuất. |

## **Tạo một Hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thực sự 3D:

- Cài đặt máy ảnh, vì góc nhìn mặc định có thể ẩn phần ép.
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và các mặt bên dễ nhận biết.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được kết xuất.
- Cài đặt ép hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ dưới đây tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị quay máy ảnh được tính bằng độ, và chiều cao ép là 100 điểm. Ví dụ này kết xuất slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản thuyết trình dưới dạng PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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

Ảnh slide đã kết xuất hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D xanh nền với văn bản 3D trắng trên mặt trước](img_01_01.png)

## **Quay một Hình dạng bằng Máy ảnh**

Trong PowerPoint, quay 3D được cấu hình từ bảng 3‑D Rotation. Các giá trị quay X, Y và Z tương ứng với quay bạn đặt qua API máy ảnh.

![Bảng 3‑D Rotation của PowerPoint với các giá trị quay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [ThreeDFormat::getCamera](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getCamera--). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước trực giao, và đặt các giá trị quay X, Y, Z thành 20, 30 và 40 độ tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình dạng trên slide. Nó thay đổi góc nhìn 3D được PowerPoint và Aspose.Slides sử dụng khi kết xuất.

## **Thêm Ép và Độ sâu**

Ép làm cho một hình dạng trông dày bằng cách kéo nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu xác định độ dày hiển thị này, và điều khiển màu xác định màu của các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu ép và chiều cao ép](img_02_02.png)

Sử dụng [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) để đặt độ dày và [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getExtrusionColor--) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật độ ép 100 điểm với các mặt bên màu tím và quay máy ảnh để hiển thị độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Phương thức [ThreeDFormat::setDepth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setDepth-double-) đặt độ sâu của một hình dạng 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) điều khiển chiều cao của hiệu ứng ép, như trong ví dụ này.

## **Sử dụng Gradient hoặc Ảnh nền với Hiệu ứng 3D**

Định dạng 3D độc lập với màu nền của hình dạng. Bạn có thể áp dụng màu đồng nhất, gradient, hoạ tiết hoặc ảnh nền cho mặt trước và vẫn dùng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và ép.

Ví dụ này áp dụng gradient từ xanh tới cam cho mặt trước và màu cam đậm cho phần ép 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị quay máy ảnh tính bằng độ. Slide được kết xuất thành ảnh PNG với kích thước gấp đôi mặc định:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

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

Kết quả đã kết xuất giữ gradient trên mặt trước và kết xuất phần ép riêng biệt:

![Hình chữ nhật 3D với gradient xanh‑cam và ép màu cam](img_02_03.png)

Để dùng ảnh nền thay thế, thêm ảnh vào bản thuyết trình và gán nó cho màu nền của hình dạng. Ví dụ này yêu cầu một tệp có tên "image.jpg" trong thư mục làm việc. Nó kéo dài ảnh để phủ toàn bộ hình chữ nhật, áp dụng ép 150 điểm và đặt quay máy ảnh tính bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc kết xuất tệp:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Ảnh được kết xuất trên mặt trước, trong khi phần ép được kết xuất như bề mặt bên 3D:

![Hình chữ nhật 3D với ảnh nền trên mặt trước và ép màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình dạng ảnh hưởng đến thân hình dạng. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần ép, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ dưới đây tạo văn bản với hoạ tiết lưới cam‑trắng, áp dụng một vòng cung hướng lên, và cấu hình các cài đặt 3D qua [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Chiều cao ép và độ sâu tính bằng điểm, và quay ánh sáng tính bằng độ. Màu nền và đường viền của hình dạng được ẩn để chỉ văn bản hiển thị. Ví dụ này kết xuất ảnh PNG với kích thước gấp đôi kích thước slide mặc định và lưu bản thuyết trình dưới dạng PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

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
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
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

Văn bản được kết xuất dưới dạng chữ 3D cong, ép:

![Văn bản 3D đã được cong dạng WordArt, nền hoạ tiết cam và ép tối màu](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình dạng 3D**

Để giữ cho văn bản dễ đọc đồng thời bảo tồn vẻ ngoài 3D của hình dạng, gọi [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) qua [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getTextFrameFormat--). Khi giá trị là `true`, văn bản sẽ không nằm trong cảnh 3D. Khi là `false`, văn bản sẽ tham gia vào cảnh và tuân theo định hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình dạng: máy ảnh, ánh sáng, vật liệu và ép vẫn được cấu hình qua [Shape::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getThreeDFormat--) . Nó cũng khác với quay thông thường. [Shape::setRotation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#setRotation-float-) quay hình dạng trong mặt phẳng slide, trong khi [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) điều khiển quay tùy chỉnh của văn bản trong khung bao. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong số đó.

Ví dụ tự chứa dưới đây tạo một hình chữ nhật xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình dạng đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `false` ở bên trái và `true` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao ép là 40 điểm. Ví dụ lưu bản thuyết trình dưới dạng PPTX và kết xuất slide so sánh thành PNG với kích thước gấp đôi mặc định.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Ở bên trái, văn bản theo định hướng 3D. Ở bên phải, văn bản giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng độ ép và định hướng 3D có thể nhìn thấy.

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo định hướng 3D bên trái và giữ phẳng bên phải](keep_text_flat.png)

## **Xuất và Hành vi Kết xuất**

Aspose.Slides giữ định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi kết xuất hoặc xuất ra các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra như một kết quả 2D. Điều này áp dụng khi bạn kết xuất slide sang [PNG](/slides/vi/php-java/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/php-java/convert-powerpoint-to-video/).

Hãy nhớ các điểm sau:

- Ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem quay sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, bộ ánh sáng, vật liệu, ép, màu nền và tỉ lệ slide.
- Nếu cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên theme, đọc [thuộc tính hình dạng hiệu quả](/slides/vi/php-java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả trực quan được kết xuất thay vì được lưu dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bài thuyết trình 3D tương tác không?**

Aspose.Slides tạo và kết xuất các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các ảnh, PDF hoặc trang HTML xuất ra trở thành các cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

**Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản thuyết trình. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn như quay, ép, viền chéo, chiếu sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Các cài đặt nào cần thiết để có một hình dạng 3D thấy được?**

Ít nhất, cần đặt một quay máy ảnh và hoặc ép hoặc độ sâu. Thực tế, cũng nên đặt bộ ánh sáng và vật liệu để các mặt được kết xuất có điểm nhấn và bóng đổ rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Dùng [Shape::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getThreeDFormat--) cho thân hình dạng và [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#getThreeDFormat--) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides kết xuất hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và các khung được dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã kết xuất, không phải một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và cài đặt theme không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Thuộc tính Hình dạng Hiệu quả](/slides/vi/php-java/shape-effective-properties/) để đọc camera cuối cùng, bộ ánh sáng, viền chéo và các giá trị 3D liên quan.