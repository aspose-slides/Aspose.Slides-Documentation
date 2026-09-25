---
title: Tạo và Áp dụng Hiệu ứng WordArt trong PHP
linktitle: WordArt
type: docs
weight: 110
url: /vi/php-java/wordart/
keywords:
- WordArt
- tạo WordArt
- mẫu WordArt
- hiệu ứng WordArt
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng ngoài
- hiệu ứng bóng trong
- PHP
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho PHP qua Java. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình chiếu với văn bản chuyên nghiệp trong PHP."
---
## **Overview**

Hiệu ứng WordArt cho phép bạn tạo kiểu cho văn bản với các màu nền, viền, bóng, phản chiếu, phát sáng, biến đổi và định dạng 3D. Bài viết này giải thích cách tạo và tùy chỉnh các hiệu ứng này trong bản thuyết trình PowerPoint bằng Aspose.Slides for PHP via Java, mà không cần cài đặt Microsoft Office.

## **Create a Simple WordArt Template and Apply It to Text**

Các ví dụ sau xây dựng một kiểu WordArt đơn giản bằng cách đặt văn bản, phông chữ, mẫu màu nền và viền.

Mỗi ví dụ tạo một bản trình chiếu mới và thêm một hình chữ nhật vào slide đầu tiên; không cần tệp đầu vào. Ví dụ đầu tiên đặt văn bản thành "Aspose.Slides". Vị trí và kích thước của hình được đo bằng điểm:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Đặt phông chữ thành Arial Black với kích thước 36 điểm để định dạng nổi bật hơn:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Áp dụng mẫu [SmallGrid](https://reference.aspose.com/slides/vi/php-java/aspose.slides/patternstyle/#SmallGrid) với màu nền trước màu cam đậm và nền trắng, sau đó thêm viền văn bản màu đen với độ rộng 1 điểm:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Văn bản kết quả:

![Mẫu WordArt đơn giản](WordArt_template.png)

## **Apply Other WordArt Effects**

Các ví dụ sau minh họa cách áp dụng bóng, phản chiếu, phát sáng, biến đổi và hiệu ứng 3D cho văn bản.

### **Apply Outer Shadow Effects**

Bóng ngoài tạo độ sâu bằng cách đặt bóng phía sau văn bản. Bạn có thể tùy chỉnh màu, hướng, khoảng cách, bán kính làm mờ, tỷ lệ và độ nghiêng.

Ví dụ này gọi [enableOuterShadowEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) và đặt bóng màu đen với bán kính làm mờ 4 điểm, hướng 230 độ và khoảng cách 30 điểm. Giá trị tỷ lệ 100 giữ nguyên kích thước bóng, trong khi độ nghiêng ngang làm bóng nghiêng 20 độ. Thuộc tính alpha transform đặt độ trong suốt thành 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Văn bản kết quả:

![Hiệu ứng bóng ngoài](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Khi sử dụng đồng thời bóng ngoài và bóng preset, chỉ bóng ngoài được áp dụng.
- Nếu sử dụng đồng thời bóng ngoài và bóng trong, hiệu ứng cuối cùng phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng bị nhân đôi, trong khi ở PowerPoint 2007, chỉ bóng ngoài được áp dụng.
{{% /alert %}}

### **Apply Reflection Effects**

Phản chiếu tạo một bản sao phản chiếu của văn bản. Điều chỉnh vị trí, tỷ lệ, độ mờ và độ trong suốt để kiểm soát cách hiển thị.

Ví dụ này gọi [enableReflectionEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effectformat/#enableReflectionEffect--) và lật phản chiếu theo chiều dọc với tỷ lệ -100%. Nó sử dụng bán kính làm mờ 0.5 điểm và khoảng cách 4.72 điểm. Độ trong suốt giảm từ 60% xuống 0.9% giữa các vị trí 0% và 60% dọc theo phản chiếu:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Văn bản kết quả:

![Hiệu ứng phản chiếu](reflection_effect.png)

### **Apply Glow Effects**

Phát sáng thêm một viền màu mềm quanh văn bản. Điều chỉnh màu, độ trong suốt và bán kính để kiểm soát hiệu ứng.

Ví dụ này gọi [enableGlowEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effectformat/#enableGlowEffect--) và áp dụng phát sáng màu đỏ với độ trong suốt 54% và bán kính 7 điểm:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Văn bản kết quả:

![Hiệu ứng phát sáng](glow_effect.png)

### **Apply WordArt Transformations**

Biến đổi WordArt uốn, kéo dãn hoặc làm biến dạng một khối văn bản.

Đặt [setTransform](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setTransform-int-) thành [ArchUpPour](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textshapetype/#ArchUpPour) để cong toàn bộ khung văn bản lên trên:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Văn bản kết quả:

![Biến đổi WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java cung cấp một tập hợp các [loại biến đổi đã định nghĩa trước](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Apply 3D Effects to Shapes and Text**

Bạn có thể áp dụng hiệu ứng 3D cho một hình dạng hoặc cho văn bản của nó. Các thông số bevel, extrusion, ánh sáng và máy ảnh kiểm soát kết quả hiển thị.

Ví dụ sau sử dụng [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/) để thêm bevel tròn, extrusion màu cam và viền màu đỏ đậm cho hình chữ nhật. Các kích thước bevel, chiều cao extrusion, độ rộng viền và độ sâu đều đo bằng điểm. Chất liệu nhựa, ánh sáng cân bằng quay 40 độ quanh trục Z và máy ảnh phối cảnh xác định ngoại hình:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Hình dạng kết quả:

![Hiệu ứng 3D cho hình dạng](shape_3D_effect.png)

Ví dụ này áp dụng định dạng 3D tương tự cho văn bản thông qua [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Bevel nhỏ hơn tạo hình các cạnh ký tự, trong khi extrusion và ánh sáng tạo độ sâu cho văn bản:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Văn bản kết quả:

![Hiệu ứng 3D cho văn bản](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Việc áp dụng hiệu ứng 3D cho văn bản hoặc cho các hình dạng của nó — và cách chúng tương tác — được quy định bởi các quy tắc cụ thể. Xem xét một cảnh bao gồm cả văn bản và hình dạng chứa nó. Một hiệu ứng 3D bao gồm biểu diễn 3D của đối tượng và cảnh mà nó được đặt trong đó.

- Nếu một cảnh được đặt cho cả hình dạng và văn bản, cảnh của hình dạng có ưu tiên và cảnh của văn bản sẽ bị bỏ qua.
- Nếu hình dạng không có cảnh riêng nhưng có biểu diễn 3D, cảnh của văn bản sẽ được sử dụng.
- Nếu hình dạng hoàn toàn không có hiệu ứng 3D, nó được coi là phẳng và hiệu ứng 3D chỉ áp dụng cho văn bản.

Các hành vi này liên quan đến các phương thức [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getLightRig--) và [ThreeDFormat::getCamera](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Để xem thêm các ví dụ về định dạng 3D, tham khảo [Create 3D Effects in Presentations Using PHP](/slides/vi/php-java/3d-presentation/).

## **FAQ**

**Can I use WordArt effects with different fonts or scripts (e.g., Arabic, Chinese)?**

Có, Aspose.Slides for PHP via Java hỗ trợ Unicode và hoạt động với mọi phông chữ và kiểu chữ chính. Các hiệu ứng WordArt như bóng, màu nền và viền có thể được áp dụng bất kể ngôn ngữ, mặc dù khả năng hiển thị và sự có sẵn của phông chữ có thể phụ thuộc vào phông chữ hệ thống.

**Can I apply WordArt effects to slide master elements?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên slide master, bao gồm các placeholder tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Do WordArt effects affect presentation file size?**

Hơi tăng. Các hiệu ứng WordArt như bóng, phát sáng và màu nền gradient có thể làm tăng nhẹ dung lượng tệp do thêm metadata định dạng, nhưng sự chênh lệch thường không đáng kể.

**Can I preview the result of WordArt effects without saving the presentation?**

Có, bạn có thể render các slide chứa WordArt thành hình ảnh (ví dụ PNG, JPEG) bằng [Slide::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage--), hoặc render từng hình dạng riêng lẻ bằng [Shape::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage--). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản trình chiếu.