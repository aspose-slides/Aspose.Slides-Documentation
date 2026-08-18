---
title: Quản lý chủ đề bản trình chiếu trong PHP
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/php-java/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề bản trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý chủ đề bản trình chiếu trong Aspose.Slides cho PHP qua Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản trình chiếu định nghĩa một tập hợp phối hợp các màu sắc, phông chữ, kiểu nền, họa tiết, đường viền và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu tới các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng đồng thời.

Trong Aspose.Slides, chủ đề cấp trình bày có thể truy cập thông qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Một bản trình chiếu cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề của bản trình chiếu thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề được kế thừa thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/). Thực tế, chủ đề hiệu quả cho một slide được giải quyết qua chuỗi kế thừa này: chủ đề bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của Theme: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc phổ biến nhất với chủ đề: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/) cung cấp lược đồ màu, lược đồ phông chữ và lược đồ định dạng của chủ đề thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, họa tiết, đường viền và hiệu ứng được lưu trong chủ đề:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một chủ đề hiệu quả. Kiểm tra master liên quan đến slide và sử dụng quy trình làm việc chủ đề‑hiệu quả được mô tả sau trong bài viết khi có thể có các ghi đè ở layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các họa tiết, đường viền và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorscheme/), mọi đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ end‑to‑end sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản trình chiếu, mở lại và in ra màu tô đầy hiệu quả:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Vì hình chữ nhật vẫn được liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề thay đổi. Nếu bạn thay thế màu scheme bằng một màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới tô đầy đó.

### **Sử dụng Màu từ Bảng màu Bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu sáng hơn, tối hơn được tạo ra từ bảng màu bổ sung](additional-palette-colors.png)

**1** – Màu chủ đề chính.  
**2** – Các biến thể sáng hơn và tối hơn được tạo ra từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng và lưu kết quả:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các vị trí `ColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ được cố định:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một lược đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` – Phông chữ nội dung Latin (Minor Latin Font)  
* `+mj-lt` – Phông chữ tiêu đề Latin (Major Latin Font)  
* `+mn-ea` – Phông chữ nội dung Đông Á (Minor East Asian Font)  
* `+mj-ea` – Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chủ đề chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi các phông chữ chủ đề và lưu kết quả:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tiêu đề tuân theo phông chữ chính và văn bản nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi lược đồ phông chữ chủ đề thay đổi.

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng Chủ đề**

Có hai quy trình làm việc phổ biến, và chúng giải quyết các vấn đề khác nhau.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide tới bản trình chiếu khác và giữ nguyên thiết kế gốc, sao chép master nguồn vào bản trình chiếu đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/), sau đó sao chép slide bằng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng được điều khiển bởi chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide hiện có**

Nếu slide đích phải ở trên master và layout hiện tại, khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/) sao chép ba thành phần chính của chủ đề vào ghi đè.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Điều này thay đổi chủ đề được sử dụng bởi slide đó mà không ảnh hưởng đến chủ đề mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay về giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được dùng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Sử dụng một chủ đề cấp master hoặc trình bày khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, dùng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và dùng ghi đè slide chỉ cho những ngoại lệ thực sự. Quá nhiều ghi đè cấp slide khiến việc thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các tô đầy nền của chủ đề được lưu trong [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện so với số lượng định nghĩa tô đầy thực tế trong bộ sưu tập này vì giao diện có thể kết hợp các tô đầy chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) hiện tại. Chỉ số kiểu `0` có nghĩa là không có tô đầy có chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ mục trực tiếp vào bộ sưu tập PHP, nơi `get_Item(0)` nghĩa là mục đầu tiên được lưu. Đừng giả định rằng mọi bản trình chiếu đều chứa cùng số lượng kiểu tô nền.

Ví dụ sau báo cáo số lượng tô nền khả dụng, gán một tham chiếu nền có chủ đề cho master đầu tiên và lưu bản trình chiếu:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không thay đổi slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi kế thừa đã được áp dụng.

{{% alert color="warning" title="Warning" %}}
Đừng xem chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh mã cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng cho mỗi bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/php-java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một lược đồ định dạng chủ đề chứa các bộ sưu tập kiểu tô đầy, đường viền và hiệu ứng riêng biệt được cung cấp qua [FormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/) và [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/). Các chủ đề Office điển hình thường có ba mục kiểu chính tương ứng với định dạng tinh tế, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng chủ đề tinh tế, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong PHP, chỉ mục bộ sưu tập là bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [ShapeStyle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapestyle/). Việc sửa đổi một kiểu chủ đề ảnh hưởng tới các hình dạng tham chiếu kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu yêu cầu, thay đổi kiểu đường viền đầu tiên, thay đổi kiểu tô đầy thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba và lưu kết quả:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường viền chủ đề đầu tiên sẽ trở thành đỏ, kiểu tô đầy thứ ba sẽ trở thành màu xanh rừng đặc và kiểu hiệu ứng thứ ba sẽ có bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào mỗi hình dạng tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường viền, tô đầy và cài đặt bóng đổ](presentation-design_11.png)

## **Đọc Giá trị Chủ đề Hiệu quả**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở một cấp độ cụ thể. Các giá trị hiệu quả cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/). Đối với nền, dùng [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/), và đối với tô đầy, dùng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu quả, nền và tô đầy của hình dạng đầu tiên từ một slide:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Sử dụng dữ liệu hiệu quả cho việc chuẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ tồn tại cục bộ ở slide đó; các slide khác vẫn kế thừa chủ đề hiện có.

**Cách an toàn nhất để chuyển một chủ đề từ bản trình chiếu này sang bản khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên giao diện nguồn, sao chép master nguồn vào đích và sao chép slide với master đó bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/) và [SlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/). Điều này giữ master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/) cho một slide hoặc layout theme và các phương thức dữ liệu‑hiệu quả tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/). Những API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.