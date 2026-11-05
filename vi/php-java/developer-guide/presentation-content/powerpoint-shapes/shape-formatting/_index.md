---
title: Định dạng các hình PowerPoint trong PHP
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/php-java/shape-formatting/
keywords:
- định dạng hình
- định dạng đường
- hiệu ứng phác thảo
- đường viền hình dạng phác thảo
- định dạng kiểu nối
- đổ màu gradient
- đổ màu mẫu
- đổ màu hình ảnh
- đổ màu kết cấu
- đổ màu đặc
- độ trong suốt hình dạng
- hiển thị hình dạng đen-trắng
- hiển thị hình dạng mức xám
- xoay hình dạng
- hiệu ứng viền 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình PowerPoint trong PHP bằng Aspose.Slides—đặt kiểu nền, đường viền và hiệu ứng cho các tệp PPT và PPTX một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Định dạng các hình dạng trong PowerPoint bằng cách điều chỉnh đường viền, nền và hiệu ứng của chúng. Aspose.Slides cho PHP thông qua Java cho phép bạn kiểm soát các cài đặt này bằng mã, bao gồm độ trong suốt, xoay và định dạng 3D.

![Các tùy chọn định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides cho PHP thông qua Java cung cấp các lớp và phương thức cho phép bạn định dạng các hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường**

Sử dụng [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) để kiểm soát đường viền của hình dạng. Ví dụ này tạo một hình chữ nhật không nền với đường viền xanh, dạng nét đứt. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) chọn một đường hợp chất dày-mỏng, trong khi [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) đặt độ rộng của nó thành 7 điểm và [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) chọn mẫu nét đứt.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các đường đã định dạng trong bản trình chiếu](formatted-lines.png)

### **Đặt Mẫu Đường Nét Đứt Tùy Chỉnh**

Sử dụng [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) khi các kiểu đường viền định sẵn không cung cấp độ dài nét đứt và khoảng trống cần thiết, ví dụ cho các đường viền thương hiệu hoặc sơ đồ kỹ thuật. Gán một mẫu sẽ tự động thay đổi kiểu nét đứt của đường thành [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Các mục trong mảng luân phiên giữa độ dài nét và khoảng trống, bắt đầu bằng nét. Mỗi giá trị là bội số của độ rộng đường: `[4, 2]` với độ rộng 3 điểm tạo ra một nét dài 12 điểm sau đó là một khoảng trống 6 điểm. Sử dụng các cặp giá trị hữu hạn, không âm để định nghĩa các đoạn nét‑khoảng trống hoàn chỉnh. Ví dụ này sử dụng các giá trị dương để giữ mọi nét và khoảng trống luôn hiển thị.

Ví dụ này tạo năm đường xanh với cùng độ dài và đầu phẳng. Ba đường đầu tiên so sánh các mẫu ở độ rộng 3 điểm. Đường thứ tư lặp lại mẫu đầu tiên với độ rộng gấp đôi, làm gấp đôi độ dài nét và khoảng trống. Đường thứ năm chuyển từ mẫu tùy chỉnh sang đường liền.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Trả về đường cuối cùng thành kiểu solid.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để quay lại một kiểu nét đứt định sẵn, truyền [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) cho [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Kiểu đã chọn kiểm soát cách hiển thị của đường.

Kết quả trong PowerPoint, từ trên xuống dưới: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; và **Solid, 3 pt**.

![Ba mẫu nét đứt tùy chỉnh, một đường rộng hơn sử dụng mẫu đầu tiên, và một đường liền trong PowerPoint](custom-dash-patterns.png)

### **Đặt Đầu Đường**

Sử dụng [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) để đặt đầu của một đường mở. Lớp [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) cung cấp ba kiểu đầu rõ ràng:

- `Flat`: Đường nét dừng lại tại điểm cuối.
- `Round`: Một đầu bán vòng tròn kéo dài ra ngoài điểm cuối bằng một nửa độ rộng của đường.
- `Square`: Một đầu vuông kéo dài ra ngoài điểm cuối bằng một nửa độ rộng của đường.

Lớp cũng bao gồm `NotDefined`, có nghĩa là không có kiểu đầu nào được gán rõ ràng.

Đầu khác với mũi tên, những ký hiệu thêm vào đầu đường, và nối, các điểm điều khiển góc giữa các đoạn đường. Ví dụ này tắt mũi tên bằng [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) và [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) để chỉ so sánh các hình dạng đầu.

Ví dụ sau tạo ba đường ngang gần như giống nhau, độ rộng 20 điểm. Từ trên xuống dưới, chúng sử dụng đầu phẳng, tròn và vuông. Các điểm cuối có cùng tọa độ ngang; đầu tròn và vuông mở rộng 10 điểm ra ngoài mỗi điểm cuối.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả trong PowerPoint, từ trên xuống dưới: **Flat**, **Round**, và **Square**.

![Đầu phẳng, tròn và vuông trên các đường dày giống nhau trong PowerPoint](line-caps.png)

## **Áp dụng Hiệu ứng Phác thảo cho Đường viền Hình dạng**

Hiệu ứng phác thảo làm cho đường nét của hình dạng trông như vẽ tay. Sử dụng [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) để truy cập cài đặt đường, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) để truy cập cài đặt phác thảo, và [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) để chọn một giá trị từ lớp [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Đoạn mã PHP sau cho thấy cách áp dụng hiệu ứng [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), đọc giá trị đã gán rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Giá trị trả về bởi [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ giao diện, slide chủ, hoặc slide bố cục, sử dụng [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), truy cập phương thức `getSketchFormat` của đối tượng trả về, và đọc giá trị `getSketchType` của nó. Giá trị hiệu lực phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết. Ví dụ này yêu cầu một bản trình chiếu hiện có có ít nhất một hình dạng trên slide đầu tiên và in cả hai giá trị:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Định dạng Kiểu Nối**

Dưới đây là ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Kiểu nối kiểm soát cách hai đoạn viền gặp nhau tại một góc. Sử dụng **Round** cho các góc tròn, **Miter** cho các góc nhọn, hoặc **Bevel** cho các góc phẳng.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Ví dụ này tạo ba hình chữ nhật đen với viền xanh rộng 15 điểm. Nó đặt [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) thành các giá trị miter, bevel và round của [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) tương ứng, để so sánh cách các góc được vẽ.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Giới hạn Nối Miter ở Các Góc Nhọn**

Sử dụng [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) cùng với [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) được đặt thành [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) để giới hạn độ dài mà một góc nhọn có thể mở rộng.

Giới hạn là tỉ lệ giữa khoảng cách giữa góc trong và góc ngoài của nối so với độ rộng đường. Ví dụ, giá trị `8` cho phép độ dài miter lên tới tám lần độ rộng đường; đây không phải là đơn vị điểm. Nếu góc vượt quá giới hạn, PowerPoint sẽ sử dụng nối bevel ở góc đó. Giới hạn lớn hơn cho phép các điểm nhọn hơn. Cài đặt này chỉ ảnh hưởng tới các nối miter và không có tác động nào khi góc vẫn nằm trong giới hạn.

Ví dụ này tạo hai tam giác không nền giống hệt nhau với viền rộng 20 điểm. Tam giác bên trái sử dụng giới hạn `2`, còn bên phải sử dụng `8`. Mỗi tam giác rộng 80 điểm và cao 160 điểm, tạo tỉ lệ độ dài miter‑so‑với‑độ rộng đường ở đỉnh trên khoảng `4.12`. Do đó, PowerPoint bevel đỉnh trái và giữ nguyên đỉnh phải.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả trong PowerPoint: **Miter limit 2** ở bên trái và **miter limit 8** ở bên phải.

![Một đỉnh cắt chéo với giới hạn miter 2 và một đỉnh nhọn với giới hạn miter 8 trong PowerPoint](miter-limits.png)

## **Đổ màu Gradient**

Đổ màu gradient pha trộn các màu trên một hình dạng. Ví dụ này đổ màu cho một hình ellipse bằng gradient tuyến tính góc 45 độ từ đỏ sang tím bằng [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). Phương thức [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) đặt các điểm dừng màu ở 0 và 1, tương ứng đầu và cuối gradient. Xóa các điểm dừng hiện có đảm bảo chỉ hai màu này được dùng.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình ellip với đổ màu gradient](gradient-fill.png)

Nếu một gradient trông khác nhau trong hình ảnh xuất khẩu so với trong PowerPoint, xem mục [Choose a Gradient Rendering Style](/slides/vi/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn kiểu hiển thị mà không thay đổi gradient được lưu trong bản trình chiếu.

### **Đặt Góc Gradient Tuyến**

Sử dụng [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) để kiểm soát hướng của một nền [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). Góc được đo bằng độ và tăng theo chiều kim đồng hồ: `0` chạy từ trái sang phải, `90` từ trên xuống dưới, `180` từ phải sang trái, và `270` từ dưới lên trên. Các góc thập phân được hỗ trợ. Các góc hữu hạn ngoài `[0, 360)` được chuẩn hoá về một vòng quay; ví dụ, `-45` trở thành `315` và `360` trở thành `0`.

Ví dụ này tạo sáu hình chữ nhật với các điểm dừng màu đỏ, xanh lá và xanh dương giống nhau tại vị trí `0`, `0.5`, và `1`. Thu phóng được tắt để góc có thể so sánh độc lập với tỷ lệ của các hình chữ nhật. Các góc, từ trái sang phải, là `0`, `45`, và `90` ở hàng trên, và `135`, `180`, và `270` ở hàng dưới.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả trong PowerPoint:

![Gradient tuyến tính ở các góc 0, 45 và 90 độ ở hàng trên, và 135, 180 và 270 độ ở hàng dưới](linear-gradient-angles.png)

### **Thu phóng Gradient Tuyến với Hình**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) nhận một giá trị [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Đặt nó rõ ràng thành `False` để giữ góc gradient hình học khi kích thước hình thay đổi, hoặc thành `True` để thu phóng gradient cùng với chiều rộng và chiều cao của hình. Khi thu phóng được bật, góc hiển thị có thể khác với góc đã gán trên một hình không vuông.

Ví dụ sau sử dụng góc `45` độ và cùng các điểm dừng màu như trong so sánh góc. Cột trái sử dụng `False`; cột phải sử dụng `True`. Mỗi cột chứa một hình chữ nhật rộng ở trên và một hình chữ nhật cao ở dưới. Cả hai đều bắt đầu với cùng kích thước rộng; việc thay đổi chiều rộng và chiều cao của hình thứ hai minh họa cách nền phản hồi khi thay đổi kích thước mà không thay đổi cài đặt gradient.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả trong PowerPoint, với thu phóng tắt ở bên trái và bật ở bên phải:

![Các hình chữ nhật rộng và cao với gradient 45 độ, so sánh LinearGradientScaled False ở bên trái với True ở bên phải](linear-gradient-scaling.png)

Với thu phóng tắt, các dải màu chéo giữ cùng hướng trong cả hai hình. Với thu phóng bật, các dải kéo dài theo tỷ lệ của hình. Điều này giúp tái tạo gradient của một mẫu khi điều chỉnh hình sang kích thước khác. Trên một hình vuông, bật thu phóng không thay đổi ngoại hình của gradient `45` độ.

Cả góc và cài đặt thu phóng đều áp dụng cho gradient tuyến tính. Chúng không kiểm soát các nền [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Kết hợp Góc với Hướng Gradient**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) chọn một kiểu gradient từ lớp [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); nó không phải là thay thế cho một góc số. Đối với gradient tuyến tính, các kiểu góc có thể thay đổi khu vực màu được phân bố mà không thay đổi góc đã gán qua [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Giữ hướng không thay đổi khi so sánh góc hoặc thu phóng.

Ví dụ sau áp dụng cùng các cài đặt nhưng theo thứ tự ngược nhau. Hai hình chữ nhật có cùng ngoại hình: việc đặt hướng trước hoặc sau góc không làm thay đổi kết quả.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đổ màu Mẫu**

Đổ màu mẫu áp dụng một thiết kế hai màu, chẳng hạn chấm, sọc, hoặc caro. Ví dụ này sử dụng [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) để chọn mẫu trellis. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) cung cấp nền xám nhạt, và [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) cung cấp màu vàng cho mẫu.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình chữ nhật với đổ màu mẫu](pattern-fill.png)

## **Đổ màu Hình ảnh**

Đổ màu hình ảnh sử dụng một hình ảnh bên trong một hình dạng. Ví dụ này yêu cầu một hình ảnh cục bộ và sử dụng [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) để tải nó vào bộ sưu tập ảnh của bản trình chiếu. Đặt [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) sang chế độ lát (Tile) sẽ lặp lại hình ảnh trong hình chữ nhật. Hình ảnh nguồn được dùng ở đây được hiển thị bên dưới:

![Hình ảnh sen](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình dạng với đổ màu hình ảnh](picture-fill.png)

### **Lát Hình Ảnh như Kết Cấu**

Nếu bạn muốn đặt một hình ảnh lát làm kết cấu và tùy chỉnh hành vi lát, có thể sử dụng các phương thức sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Đặt chế độ đổ ảnh—hoặc `Tile` hoặc `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Xác định vị trí căn chỉnh các ô trong hình dạng.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Kiểm soát việc lật ô theo chiều ngang, dọc, hoặc cả hai.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Đặt độ lệch ngang của ô (bằng điểm) từ gốc của hình dạng.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Đặt độ lệch dọc của ô (bằng điểm) từ gốc của hình dạng.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): X xác định tỷ lệ dọc của ô dưới dạng phần trăm.

Ví dụ này yêu cầu một hình ảnh cục bộ và cấu hình [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) để lặp lại nó ở 50% kích thước gốc. Độ lệch `−32` điểm dịch các ô theo chiều ngang và dọc; căn chỉnh góc phải‑dưới và lật ở cả hai hướng quyết định cách kết cấu lặp được sắp xếp.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các tùy chọn lằn](tile-options.png)

## **Đổ màu Đặc**

Đổ màu đặc cung cấp cho một hình dạng một màu duy nhất, đồng nhất. Ví dụ này đặt [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) thành chế độ đổ đặc và gán màu vàng qua [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), sau đó lưu hình chữ nhật vào bản trình chiếu.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình dạng với màu đổ đặc](solid-color-fill.png)

### **Sao chép Màu Đồng thời Giữ Tham chiếu Giao diện**

Sử dụng [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) để sao chép định nghĩa màu, bao gồm kiểu màu, tham chiếu giao diện và các biến đổi. Điều này hữu ích khi chuyển màu đổ giữa các hình dạng mà vẫn muốn chúng tiếp tục theo giao diện của bản trình chiếu. Phương thức chỉ sao chép màu: không sao chép kiểu đổ, viền, hoặc các định dạng khác của hình dạng. Đặt kiểu đổ của đích một cách rõ ràng bằng [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Ví dụ này tạo ba hình chữ nhật, từ trái sang phải: nguồn, bản sao có nhận thức giao diện, và bản sao RGB cố định. Nguồn sử dụng [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) để tham chiếu màu nhấn đầu tiên và thêm một sắc tố qua [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). Bản sao RGB sử dụng màu đổ hiệu lực của nguồn nên cả ba ban đầu trông giống nhau. Gọi [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) đặt một giá trị RGB cố định và xoá mọi biến đổi màu hiện có.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Tham chiếu giao diện theo màu nhấn mới; giá trị RGB cố định thì không.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Trước khi thay đổi giao diện, cả ba màu đổ đều giống nhau:

![Nguồn, đích copyFrom và đích RGB cố định với các màu xanh đồng nhất](color-copy-before.png)

Sau khi thay đổi giao diện, nguồn và bản sao có nhận thức giao diện sẽ theo màu nhấn mới và giữ lại sắc tố. Bản sao RGB cố định vẫn màu xanh:

![Nguồn và đích copyFrom với màu cam, trong khi đích RGB cố định vẫn màu xanh](color-copy-after.png)

Định nghĩa đã sao chép độc lập với nguồn. Thay đổi tham chiếu giao diện của nguồn, gán màu khác, hoặc thêm/bỏ các biến đổi sẽ không ảnh hưởng đến đích. Thay đổi giao diện vẫn ảnh hưởng tới cả hai hình vì mỗi hình đều tham chiếu riêng biệt tới cùng một màu giao diện.

Lưu và mở lại tệp PPTX giữ nguyên kiểu màu đã sao chép được trả về bởi [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), tham chiếu giao diện và tập hợp biến đổi trả về bởi [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); chúng không chuyển đổi định nghĩa thành RGB.

Khi sao chép giữa các ngữ cảnh giao diện khác nhau, chẳng hạn các bản trình chiếu có bảng màu nhấn khác nhau, tham chiếu đã sao chép sẽ được giải quyết dựa trên giao diện của đích. Do đó cùng một tham chiếu và biến đổi có thể tạo ra màu hiển thị khác nhau. Xem mục [Presentation Theme](/slides/vi/php-java/presentation-theme/) để biết thêm về cấu hình màu giao diện.

## **Sử dụng Nền Slide làm Đổ cho Hình dạng**

Sử dụng [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) khi một hình dạng nên khớp với nền slide, ví dụ trong một mẫu trình chiếu. Đặt kiểu đổ bằng [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) thành [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) trước để loại bỏ bất kỳ đổ nào được xác định rõ. Với sự kết hợp này, hình dạng sẽ sử dụng nền slide thay vì nền kiểu của nó. Bật cờ này một mình không loại bỏ đổ đã được xác định trước đó.

Điều này khác với [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): đổ nền phủ các đối tượng phía sau hình dạng bằng khu vực nền slide tương ứng, trong khi không đổ để lại các đối tượng đó hiển thị. Một gradient vẫn được căn chỉnh với slide thay vì khởi động lại trong mỗi hình dạng.

Ví dụ sau tạo một nền chủ được slide kế thừa và đặt một dải màu hồng đô phía sau ba hình chữ nhật. Hình chữ nhật bên trái sử dụng nền, hình giữa không có đổ, và hình bên phải chuyển từ đổ nền sang đổ màu cam rõ ràng.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Kế thừa gradient từ master.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Thêm đối tượng này trước để nó nằm phía sau các hình chữ nhật.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Tắt nền trước khi áp dụng nền xác định.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả, từ trái sang phải: **background fill**, **no fill**, và **explicit fill**. Dải màu hồng đô bị ẩn bởi hình bên trái và bên phải nhưng vẫn hiển thị qua hình ở giữa.

![Đổ nền, không đổ, và đổ màu cam rõ ràng trên dải màu hồng đô](background-fill.png)

Hành vi tương tự áp dụng cho nền được xác định trực tiếp trên slide hoặc kế thừa từ bố cục. Hình dạng sẽ sử dụng nền đã giải quyết của slide; ví dụ để cả nền slide và bố cục không xác định để nền chủ cung cấp.

## **Đặt Độ trong suốt**

Đối với đổ đặc, thành phần alpha của màu kiểm soát độ trong suốt: 0 là hoàn toàn trong suốt và 255 là hoàn toàn không trong suốt. Ví dụ này dùng giá trị alpha 128 cho một hình chữ nhật màu vàng, làm cho nó khoảng 50 % trong suốt để hình chữ nhật phía dưới vẫn nhìn thấy được. Màu được gán qua [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Sử dụng [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) để xoay một hình dạng trên mặt phẳng slide. Góc được đo bằng độ; ví dụ này xoay một hình chữ nhật 5 độ theo chiều kim đồng hồ và lưu bản trình chiếu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu Ứng Viền 3D**

Sử dụng [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) để cho một hình dạng độ sâu và cạnh viền. Ví dụ này tạo một ellipse xanh lá với viền cam, đặt [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) thành 4 điểm, và áp dụng một viền trên dạng vòng tròn với chiều rộng và chiều cao 6 điểm qua [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Một camera trực giao hướng mặt và ánh sáng ba‑điểm làm cho viền hiển thị rõ.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hiệu ứng viền 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Một hình dạng có góc nhìn 3D được điều khiển bởi cài đặt camera. Ví dụ này sử dụng [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) với các góc vĩ độ, kinh độ và vòng quay lần lượt là 40, 35 và 20 độ. Nó chọn một camera isometric qua [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) và ánh sáng cân bằng qua [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), sau đó lưu hình chữ nhật đã định dạng.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Hiển thị Đen-Trắng cho Hình dạng**

Phương thức [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) chỉ định cách một hình dạng đơn lẻ được hiển thị khi một bản trình chiếu được xem hoặc xử lý ở chế độ đen‑trắng. Nó không tự động bật chế độ hiển thị đen‑trắng và không thay đổi nền, đường viền hay định dạng khác của hình trong chế độ màu bình thường.

Sử dụng một giá trị từ lớp [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `Automatic` để ứng dụng hiển thị tự chọn cách chuyển đổi, `Gray` và `LightGray` dùng màu xám, `BlackWhite` chỉ dùng đen và trắng, `Black` và `White` ép một màu duy nhất, `Color` giữ nguyên màu bình thường, và `Hidden` bỏ qua hình trong chế độ đen‑trắng. `NotDefined` nghĩa là không có chế độ cấp cho hình.

Ví dụ này tạo một hình chữ nhật màu cam và đặt [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) thành màu xám. Hình đã lưu giữ nguyên màu đổ cam cho hiển thị màu bình thường và yêu cầu màu xám từ các ứng dụng tôn trọng cài đặt hiển thị đen‑trắng:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu đổ cam. Trong quy trình làm việc hiển thị đen‑trắng, nó dùng màu xám vì chế độ đã được đặt thành `Gray`. Điều này cho phép bạn giữ một slide màu đầy đủ trong khi định nghĩa một ngoại hình riêng cho in, xem trước, hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Sử dụng [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) để khôi phục vị trí, kích thước và định dạng của các placeholder trên slide từ các placeholder bố cục tương ứng. Ví dụ này yêu cầu một bản trình chiếu hiện có có các placeholder liên kết bố cục và đặt lại mọi slide trước khi lưu. Các hình không có placeholder bố cục tương ứng sẽ không được đặt lại.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp trình chiếu không?**

Màu sắc, kiểu đường và cài đặt hiệu ứng thường chỉ thêm một lượng dữ liệu nhỏ so với hình ảnh và phương tiện nhúng. Đổ hình ảnh có thể làm tăng kích thước tệp vì hình ảnh của chúng được lưu trong bản trình chiếu.

**Làm sao tôi có thể phát hiện các hình trên một slide có cùng định dạng để nhóm chúng?**

So sánh các thuộc tính định dạng chính của mỗi hình — màu đổ, đường viền và cài đặt hiệu ứng. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm các hình lại với nhau, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một bộ các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu với các kiểu mong muốn trong một slide mẫu hoặc tệp .POTX. Khi tạo một bản trình chiếu mới, mở mẫu, sao chép các hình đã định dạng cần thiết, và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần.