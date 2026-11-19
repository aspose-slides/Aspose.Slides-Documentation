---
title: Tạo hiệu ứng 3D trong bản trình bày bằng PHP
linktitle: Bản trình bày 3D
type: docs
weight: 232
url: /vi/php-java/3d-presentation/
keywords:
- PowerPoint 3D
- bản trình bày 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Áp dụng và kết xuất các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong PHP với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides cho PHP thông qua Java có thể tạo, chỉnh sửa, giữ nguyên và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này bao gồm các hiệu ứng 3D như xoay, extrusion, bevels, lighting, material, gradient hoặc picture fills, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không đề cập đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó trong kết quả 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng phương thức [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), đối tượng điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Kiểm soát gì | Khi nào sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Điểm nhìn, loại máy ảnh mặc định, góc quay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một cài đặt xoay 3D mặc định của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Mẫu ánh sáng, hướng và góc quay của ánh sáng. | Thay đổi cách các điểm sáng và bóng tối xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Vật liệu bề mặt, chẳng hạn như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm hơn, bóng hơn hoặc có tính kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày và có thể nhìn thấy được. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Màu của các mặt bên được đùn ra. | Làm cho độ sâu hiển thị hoặc đồng bộ màu mặt bên với màu nền phía trước. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với thiết lập viền và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc được đúc thay vì mặt phẳng nhọn. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) and [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) and [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới của đối tượng trong kết quả hiển thị. |

## **Tạo một Hình dạng 3D**

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các mặt bên có thể nhìn rõ.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.
- Cài đặt đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ dưới tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Giá trị xoay máy ảnh được tính bằng độ, và chiều cao đùn là 100 điểm. Ví dụ này kết xuất slide thành hình PNG với kích thước gấp đôi mặc định và lưu bài thuyết trình dưới dạng PPTX.

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

Hình ảnh slide đã kết xuất hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh được hiển thị với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một Hình dạng bằng Máy ảnh**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng điều khiển 3‑D Rotation. Các giá trị xoay X, Y và Z tương ứng với góc quay bạn đặt thông qua API máy ảnh.

![Bảng 3‑D Rotation của PowerPoint với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn trước dạng trực giao, và đặt các góc quay X, Y, Z lần lượt là 20, 30 và 40 độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

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

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi quan điểm 3D mà PowerPoint và Aspose.Slides sử dụng khi kết xuất.

### **Sao chép Định hướng Máy ảnh từ Hình mẫu**

Để khớp định hướng của một hình mẫu, đọc mẫu máy ảnh của nó bằng [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) và các góc quay bằng [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Ví dụ mở `template.pptx` và sao chép định hướng máy ảnh từ hình đầu tiên trên slide đầu tiên sang hình thứ hai. Cả hai hình đã có ánh sáng 3D, và hình thứ hai không có góc quay máy ảnh rõ ràng.

Các góc được tính bằng độ. Chỉ mục `0` là vĩ độ, chỉ mục `1` là kinh độ, và chỉ mục `2` là vòng quay. Đưa chúng vào [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) theo thứ tự đó. Nếu nguồn trả về `null`, nghĩa là không có góc quay rõ ràng, vì vậy để nguyên góc của hình thứ hai. Một góc quay rõ ràng `(0, 0, 0)` trả về ba số 0 và nên được sao chép.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Khi bạn mở lại `camera-copy.pptx` trong PowerPoint, mũi tên bên phải có cùng mẫu máy ảnh và góc quay như hình chữ nhật bên trái. Cả hai hình đều sử dụng cùng ánh sáng và độ sâu đùn.

![Một hình chữ nhật 3D màu xanh và một mũi tên sang phải với định hướng máy ảnh khớp, nhìn từ trên và bên phải](camera-orientation.png)

## **Thêm Đùn và Độ sâu**

Đùn làm cho hình dạng trông dày lên bằng cách kéo nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu thiết lập màu cho các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Sử dụng [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) để đặt độ dày và [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật đùn 100 điểm với các mặt bên màu tím và xoay máy ảnh để hiển thị độ dày. Nó cấu hình hình trong bộ nhớ mà không lưu tệp:

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

Phương thức [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) đặt độ sâu cho một hình dạng 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) điều khiển chiều cao của hiệu ứng đùn, như được minh họa trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D không phụ thuộc vào màu nền của hình. Bạn có thể áp dụng màu đơn, gradient, pattern hoặc picture fill cho mặt trước và vẫn sử dụng cùng các thiết lập máy ảnh, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng gradient từ xanh đến cam cho mặt trước và màu cam đậm cho phần đùn 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị xoay máy ảnh được tính bằng độ. Slide được kết xuất thành hình PNG với kích thước gấp đôi mặc định:

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

Kết quả đã kết xuất giữ gradient trên mặt trước và kết xuất đùn riêng biệt:

![Hình chữ nhật 3D đã kết xuất với gradient xanh‑cam và đùn màu cam](img_02_03.png)

Để sử dụng picture fill thay thế, thêm hình ảnh vào bài thuyết trình và gán nó cho màu nền của hình. Ví dụ này đòi hỏi một tệp hiện có có tên "image.jpg" trong thư mục làm việc. Nó kéo dài hình ảnh để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm và đặt góc quay máy ảnh tính bằng độ. Nó cấu hình hình trong bộ nhớ mà không lưu hoặc kết xuất tệp:

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

Hình ảnh được kết xuất trên mặt trước, trong khi đùn được hiển thị như bề mặt bên 3D:

![Hình chữ nhật 3D đã kết xuất với picture fill trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng tới phần thân hình. Định dạng 3D của văn bản ảnh hưởng tới khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần đùn, vật liệu, ánh sáng và thiết lập máy ảnh.

Ví dụ sau tạo văn bản với pattern lưới cam‑trắng, áp dụng một cung vòm hướng lên và cấu hình các thiết lập 3D qua [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Chiều cao đùn và độ sâu tính bằng điểm, và góc quay ánh sáng tính bằng độ. Màu nền và đường viền của hình được ẩn để chỉ hiển thị văn bản. Ví dụ này kết xuất một hình PNG có kích thước gấp đôi slide mặc định và lưu bài thuyết trình dưới dạng PPTX:

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

Văn bản được hiển thị dưới dạng chữ 3D cong, đùn:

![Văn bản 3D đã kết xuất với biến đổi WordArt cong, pattern cam, và đùn tối màu](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình dạng 3D**

Để giữ cho văn bản dễ đọc trong khi vẫn bảo toàn ngoại hình 3D của hình, gọi [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) qua [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). Khi giá trị là `true`, văn bản sẽ không nằm trong cảnh 3D. Khi giá trị là `false`, văn bản sẽ tham gia vào cảnh và tuân theo hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình: máy ảnh, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). Nó cũng khác với việc xoay thông thường. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) xoay hình trên mặt phẳng slide, trong khi [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) điều khiển góc xoay tùy chỉnh của văn bản trong khung chứa. Giữ văn bản ra khỏi cảnh 3D không reset bất kỳ góc nào trong hai trường hợp trên.

Ví dụ tự chứa sau tạo một hình chữ nhật màu xanh với văn bản và sao chép nó bên cạnh hình gốc. Cả hai hình đều có cùng định dạng 3D; chỉ có cài đặt văn bản khác nhau: `false` ở phía trái và `true` ở phía phải. Các góc máy ảnh tính bằng độ, và chiều cao đùn là 40 điểm. Ví dụ này lưu bài thuyết trình dưới dạng PPTX và kết xuất slide so sánh thành PNG với kích thước gấp đôi mặc định.

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

Ở bên trái, văn bản theo hướng 3D. Ở bên phải, văn bản giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật vẫn giữ cùng độ đùn và hướng 3D hiển thị.

![Hai hình chữ nhật 3D đặt cạnh nhau: văn bản theo hướng 3D ở bên trái và giữ phẳng ở bên phải](keep_text_flat.png)

## **Hành vi Xuất và Kết xuất**

Aspose.Slides giữ định dạng 3D khi lưu sang các định dạng PowerPoint như PPTX. Khi kết xuất hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào kết quả dưới dạng 2D. Điều này áp dụng khi bạn kết xuất slide thành [PNG](/slides/vi/php-java/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/php-java/convert-powerpoint-to-video/).

Hãy lưu ý các điểm sau:

- Hình ảnh và PDF xuất ra không tương tác. Đối tượng không thể được người xem xoay sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, light rig, vật liệu, đùn, màu nền và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng thừa kế hoặc dựa trên theme, hãy đọc [effective shape properties](/slides/vi/php-java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D có thể chỉnh sửa trong PowerPoint. Trong các định dạng đó, kết quả trực quan được kết xuất thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo các bài thuyết trình 3D tương tác không?**

Aspose.Slides tạo và kết xuất các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML xuất ra trở thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bài thuyết trình. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như xoay, đùn, bevel, ánh sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

**Những cài đặt nào cần thiết để tạo một hình dạng 3D có thể nhìn thấy?**

Ít nhất, cần đặt góc quay máy ảnh và hoặc đùn hoặc độ sâu. Thực tế, thường cũng cần đặt light rig và vật liệu để các mặt được kết xuất có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) cho phần thân hình và [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides kết xuất các hiệu ứng 3D khi tạo hình ảnh slide, PDF, HTML và khung dùng cho chuyển đổi video. Đầu ra được xuất chứa hình ảnh đã kết xuất, không phải một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi đã áp dụng thừa kế và cài đặt theme không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/php-java/shape-effective-properties/) để đọc các giá trị cuối cùng của máy ảnh, light rig, bevel và các giá trị 3D liên quan.