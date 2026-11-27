---
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu bằng PHP
linktitle: Hiệu ứng Hình dạng
type: docs
weight: 30
url: /vi/php-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho PHP qua Java - tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Mặc dù các hiệu ứng trong PowerPoint có thể được dùng để làm cho một hình dạng nổi bật, chúng khác với [đổ màu](/slides/vi/php-java/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh sáng phát ra từ hình dạng, v.v.

![Shape effect](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp hiệu ứng trông tốt hơn những kết hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các kết hợp của hai hoặc nhiều hiệu ứng đã được chứng minh là trông đẹp. Nhờ vậy, bằng cách chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hay kết hợp các hiệu ứng khác nhau để tìm ra một kết hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương pháp trong lớp [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng giống nhau cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng Bóng đổ**

Aspose.Slides for PHP via Java hỗ trợ bóng đổ bên ngoài và bên trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bản trình chiếu của mình.

### **Áp dụng Bóng đổ Ngoài**

Sử dụng bóng đổ ngoài để làm cho một thẻ hoặc bảng điều khiển nổi bật hơn nền slide. Bóng đổ mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng đang nổi lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu.

Đoạn mã PHP sau đây cho thấy cách áp dụng [hiệu ứng bóng đổ ngoài](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) cho một hình chữ nhật:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Shadow effect](shadow_effect.png)

#### **Kiểm soát Hướng Bóng Đổ Khi Hình Dạng Xoay**

Mặc định, bóng đổ ngoài sẽ xoay cùng với hình dạng. Để các hình dạng có các góc quay khác nhau đều được chiếu sáng từ cùng một hướng, gọi [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape) với giá trị `false` và sử dụng [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) để đặt cùng một hướng cho các bóng đổ.

Ví dụ tạo hai mũi tên xanh với bóng đổ xám lệch 42 điểm sang phải (0°). Sau đó sao chép slide và xoay cả hai mũi tên 90° theo chiều kim đồng hồ.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Trên slide thứ hai, mũi tên trái đổ bóng xuống dưới, trong khi mũi tên phải vẫn đổ bóng sang phải. Hướng đã cấu hình vẫn là 0° cho cả hai bóng.

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **Áp dụng Bóng Đổ Nội**

Khi tái tạo kiểu dáng trực quan của một mẫu, sử dụng bóng đổ nội để tạo cảm giác khối hoặc bảng điều khiển được hạ thấp. Bóng đổ ngoài mở rộng ra ngoài hình dạng và làm cho nó trông nổi lên, trong khi bóng đổ nội làm tối các cạnh bên trong của hình dạng.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), sau đó cấu hình bóng đổ trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Giá trị bán kính làm mờ lớn hơn sẽ tạo ra các cạnh mềm hơn.

Đoạn mã PHP này tạo một thẻ màu xanh nhạt với bóng đổ nội màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm, và bán kính làm mờ là 6 điểm:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Để xóa bóng đổ nội, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, Thay đổi và Xóa một Preset Shadow**

Gọi [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) để kích hoạt một preset shadow. Sử dụng [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) để chọn một [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) hoặc chuyển sang phong cách khác trên cùng một hình dạng. Gọi [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) để xóa bóng đổ trong khi vẫn bảo toàn màu đổ và viền.

Đoạn PHP này sao chép hình chữ nhật sau mỗi ba giai đoạn đầu tiên để bạn có thể so sánh bốn giai đoạn bên nhau trên một slide. Cả hai bóng đổ đều lệch 10 điểm. Hướng 225° đặt bóng đầu tiên ở phía trên và bên trái của hình chữ nhật, và 45° đặt bóng thứ hai ở phía dưới và bên phải.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Gốc | Preset đầu tiên | Preset thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Áp dụng Hiệu Ứng Phản Chiếu**

Để áp dụng một hiệu ứng phản chiếu trong Aspose.Slides for PHP via Java, bạn có thể thêm một phản chiếu giống gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ cho bản trình chiếu của bạn bằng cách tạo cho các hình dạng một diện mạo tinh tế và chuyên nghiệp hơn. Nó rất dễ thực hiện với vài dòng mã, cho phép áp dụng nhanh chóng trên nhiều phần tử với thiết kế đồng nhất.

Đoạn mã PHP sau đây cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) cho một hình dạng:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Reflection effect](reflection_effect.png)

## **Áp dụng Hiệu Ứng Phát Sáng**

Để áp dụng hiệu ứng phát sáng cho một hình dạng trong Aspose.Slides for PHP via Java, bạn có thể thêm một hào quang mềm mại quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật hơn và tạo thêm yếu tố trực quan hấp dẫn cho bản trình chiếu. Nó rất dễ thực hiện với một ít mã, nâng cao tổng thể vẻ ngoài của các slide.

Đoạn mã PHP sau đây cho thấy cách áp dụng [hiệu ứng phát sáng](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) cho một hình dạng:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Glow effect](glow_effect.png)

## **Áp dụng Hiệu Ứng Cạnh Mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides for PHP via Java, bạn có thể tạo một chuyển đổi mịn màng, mờ dần quanh các cạnh của hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho những thiết kế cần một cảm giác mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên các hình dạng khác nhau trong bản trình chiếu.

Đoạn mã PHP này cho thấy cách áp dụng [hiệu ứng cạnh mềm](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) cho một hình dạng:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **Áp dụng Hiệu Ứng Làm Mờ**

Sử dụng làm mờ hình dạng để làm mềm màu đổ và viền của hình dạng trong khi vẫn giữ cho hình dạng có thể chỉnh sửa. Gọi [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, với giá trị lớn hơn tạo ra mức độ làm mờ mạnh hơn. Bán kính bằng không sẽ không thay đổi ngoại hình.

Cài đặt [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) kiểm soát giới hạn hiển thị của hiệu ứng. Khi `false`, phần làm mờ bị cắt trong giới hạn đã vẽ ban đầu, bao gồm cả viền. Khi `true`, phần làm mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không làm thay đổi vị trí hay kích thước của hình dạng.

So sánh dưới đây sử dụng cùng một màu đổ, viền và kích thước hình dạng trong suốt quá trình. Hàng trên sử dụng `grow = false`; hàng dưới sử dụng `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Đoạn PHP này tạo một hình chữ nhật màu cam với viền màu xanh đậm, áp dụng làm mờ 5 điểm, sau đó cập nhật lên mức 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Nó lưu cả hai trạng thái đã làm mờ, rồi gọi [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) và lưu hình dạng không có làm mờ.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Làm mờ hình dạng ảnh hưởng đến cả màu đổ và viền. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi làm mờ bóng đổ chỉ làm mềm bóng đổ. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng làm mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành hình ảnh.

## **Câu Hỏi Thường Gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng đổ, phản chiếu và phát sáng, trên một hình dạng duy nhất để tạo ra giao diện động hơn.

**Tôi có thể áp dụng hiệu ứng cho các loại hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm autoshapes, biểu đồ, bảng, ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.