---
title: Quản lý Chủ đề Trình chiếu trong PHP
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/php-java/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- chủ đề bên ngoài
- THMX
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý các chủ đề bản trình bày trong Aspose.Slides cho PHP thông qua Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản trình bày định nghĩa một bộ màu, phông chữ, kiểu nền, độ phủ, đường viền và hiệu ứng phối hợp. Các đối tượng nhận thức chủ đề tham chiếu đến các định nghĩa chia sẻ này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, chủ đề cấp trình bày có sẵn thông qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Một bản trình bày cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề trình bày thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề kế thừa của nó thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/). Thực tế, chủ đề thực tế cho một slide được giải quyết thông qua chuỗi kế thừa này: chủ đề trình bày, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần chủ đề: màu, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/) cung cấp lược đồ màu, lược đồ phông chữ và lược đồ định dạng của chủ đề thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình bày đến từ nguồn bên ngoài vì số lượng và nội dung các mục style có thể thay đổi.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo có bao nhiêu kiểu nền, độ phủ, đường viền và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, đừng cho rằng mọi slide đều có cùng một chủ đề thực tế. Kiểm tra master liên quan tới slide, và sử dụng quy trình làm việc chủ đề‑hiệu quả được mô tả sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các độ phủ, đường viền và văn bản nhận thức chủ đề có thể tham chiếu đến một màu logic từ liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorscheme/), mọi đối tượng vẫn tham chiếu màu chủ đề ấy sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản trình bày, mở lại và in màu độ phủ thực tế:

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

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu lược đồ bằng một màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới độ phủ đó nữa.

### **Sử dụng Màu từ Bảng Màu Bổ Sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua liệt kê [ColorTransformOperation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colortransformoperation/).

![Các màu chủ đề chính và các màu sáng hơn, tối hơn được tạo ra từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Các màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo ra từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

### **Ánh xạ Các Giá trị `SchemeColor` tới Các Vị trí `ColorScheme`**

Liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một lược đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích với PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi các phông chữ chủ đề và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ rõ ràng thay vì định danh chủ đề sẽ không tự động chuyển khi lược đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc loại bỏ các ánh xạ này, xem mục [Script‑Specific Theme Fonts](/slides/vi/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình bày, xem [PowerPoint Fonts](/slides/vi/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình làm việc dưới đây giải quyết các vấn đề liên quan đến chủ đề khác nhau.

### **Áp dụng Chủ đề Bên ngoài cho Các Slide Phụ Thuộc vào Master**

Sử dụng [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation::getMasters](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), được biểu diễn bởi [MasterSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/), và truyền đường dẫn tới tệp chủ đề cho phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề bên ngoài vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [MasterSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) mới tạo.

Ví dụ dưới đây áp dụng một chủ đề bên ngoài cho các slide phụ thuộc vào master đầu tiên và lưu bản trình bày:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxreadexception/). Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và lưu bản trình bày chỉ sau khi chủ đề đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và chủ đề hiện có. Các màu, phông chữ, độ phủ, đường viền, nền và hiệu ứng nhận thức chủ đề sẽ được giải quyết dựa trên chủ đề bên ngoài. Các màu, phông chữ, độ phủ và các định dạng rõ ràng khác được gán trực tiếp có thể vẫn không thay đổi. Các ghi đè ở cấp layout và slide cũng có thể ưu tiên hơn các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu tới các phông chữ không có trong môi trường chạy. Để đảm bảo việc hiển thị và xuất ra nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng thông qua [custom font sources](/slides/vi/php-java/custom-font/), hoặc cấu hình [font substitution](/slides/vi/php-java/font-substitution/).

Đây là một quy trình làm việc trực tiếp ở cấp master: phương thức nhận một đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở cấp slide hoặc layout.

### **Áp dụng Các Chủ đề Bên ngoài Khác nhau trong Một Bản Trình Bày Đa‑Master**

Khi master liên quan không được biết trước, hãy lấy nó từ một slide đại diện thông qua [Slide::getLayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/) và [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong bản trình bày.

Ví dụ dưới đây sử dụng slide từ hai phần để xác định master của chúng và áp dụng một chủ đề bên ngoài khác nhau cho mỗi nhóm:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Lệnh gọi đầu tiên chỉ ảnh hưởng đến các slide phụ thuộc vào `$firstGroupMaster`, và lệnh gọi thứ hai chỉ ảnh hưởng đến các slide phụ thuộc vào `$secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không được thay đổi kiểu dáng.

### **Bảo lưu Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình bày khác và bảo lưu thiết kế gốc, hãy sao chép master nguồn vào bản trình bày đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/), sau đó sao chép slide bằng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) và master đã sao chép. Điều này sẽ mang theo master, các layout và chủ đề liên quan.

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

Đây là quy trình ưu tiên khi slide nguồn cần giữ nguyên giao diện ở đích. Chỉ sao chép nội dung vào một master đích không liên quan có thể thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Một Slide Đã Tồn tại**

Nếu slide đích phải ở lại master và layout hiện tại, hãy khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/) sao chép ba thành phần chủ đề chính vào ghi đè.

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

Điều này thay đổi chủ đề được slide đó sử dụng mà không làm thay đổi chủ đề kế thừa bởi các slide khác. Để loại bỏ ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Một Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng thông qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslidethememanager/):

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

Sử dụng một chủ đề cấp master hoặc cấp trình bày khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một họ layout cần kiểu dáng khác nhau, và sử dụng ghi đè slide chỉ cho những ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các độ phủ nền của chủ đề được lưu trong [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/). PowerPoint có thể hiển thị nhiều tùy chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa độ phủ thực tế trong bộ sưu tập này vì UI có thể kết hợp độ phủ chủ đề với màu chủ đề và các tham chiếu style khác.

![Thư viện kiểu nền PowerPoint cho một chủ đề trình bày](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) hiện tại. Một chỉ số kiểu `0` có nghĩa là không có độ phủ có chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc lập chỉ mục bộ sưu tập PHP trực tiếp, trong đó `get_Item(0)` nghĩa là mục đầu tiên được lưu. Đừng cho rằng mọi bản trình bày đều chứa cùng số lượng kiểu độ phủ nền.

Ví dụ dưới đây báo cáo số lượng độ phủ nền có sẵn, gán một tham chiếu nền có chủ đề cho master đầu tiên, và lưu bản trình bày:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề được master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không làm thay đổi slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng xem chỉ số kiểu như một chỉ mục bộ sưu tập bắt đầu từ 0. Đồng thời, tránh mã cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng từng bản trình bày.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem mục [Presentation Background](/slides/vi/php-java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một lược đồ định dạng chủ đề chứa các bộ sưu tập độ phủ, đường viền và hiệu ứng riêng biệt được mở ra thông qua [FormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/), và [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/). Các chủ đề Office thường chứa ba mục style chính tương ứng với kiểu định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng chủ đề nhẹ, trung bình và mạnh được áp dụng lên cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong PHP, chỉ mục bộ sưu tập bắt đầu từ 0: `get_Item(0)` là style đầu tiên được lưu và `get_Item(2)` là style thứ ba. Các chỉ mục tham chiếu style của hình dạng là một khái niệm riêng, được mở ra qua [ShapeStyle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapestyle/). Việc sửa đổi một style chủ đề sẽ ảnh hưởng tới các hình dạng tham chiếu style đó; các hình dạng có định dạng trực tiếp có thể vẫn không thay đổi.

Ví dụ dưới đây kiểm tra sự tồn tại của các mục style cần thiết, thay đổi style đường viền đầu tiên, thay đổi style độ phủ thứ ba, bật bóng ngoài trong style hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, style đường viền chủ đề đầu tiên sẽ trở thành màu đỏ, style độ phủ chủ đề thứ ba sẽ trở thành màu xanh rừng đặc, và style hiệu ứng thứ ba sẽ có một bóng ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào mỗi hình dạng tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Các style hiệu ứng chủ đề sau khi thay đổi đường viền, độ phủ và cài đặt bóng](presentation-design_11.png)

## **Xác định Liệu Độ phủ Đặc Rắn Hiệu quả Có Sử dụng Màu Chủ đề Hay Không**

Một độ phủ có thể được lưu trực tiếp trên đối tượng hoặc kế thừa từ đoạn văn, layout, master, style chủ đề, hoặc một mức định dạng khác. Gọi [FillFormat::getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) để giải quyết chuỗi phân cấp này thành dữ liệu độ phủ hiệu quả không thể thay đổi. Đầu tiên kiểm tra kết quả `getFillType`. Chỉ khi nó trả về `FillType::Solid` bạn mới đọc các thuộc tính độ phủ đặc.

Đối với độ phủ đặc, `getSolidFillColor` trả về giá trị RGB cuối cùng sau khi đã áp dụng kế thừa, tra cứu chủ đề và các phép biến đổi màu. Phương thức `getSolidFillSchemeColor` trả về vị trí logic [SchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor::NotDefined` có nghĩa là độ phủ đặc hiệu quả không dựa trên một màu lược đồ. Trong một quy trình làm việc mà độ phủ chỉ là màu chủ đề hoặc màu RGB trực tiếp, giá trị này xác định một độ phủ RGB trực tiếp.

Đừng chỉ dựa vào giá trị địa phương [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorformat/) để phân loại độ phủ. Ví dụ, một đoạn văn có thể không có màu lược đồ được xác định cục bộ, vì vậy giá trị địa phương là `NotDefined`, trong khi độ phủ hiệu quả của nó kế thừa một màu chủ đề và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho bạn biết vị trí logic nào của chủ đề tạo ra màu hiệu quả, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay mức định dạng nào khác.

Ví dụ sau tải một bản trình bày, kiểm tra cả độ phủ của hình dạng và độ phủ của đoạn văn bản, in mỗi giá trị RGB cuối cùng và màu lược đồ liên quan, và đánh dấu các độ phủ đặc sẽ không theo dõi thay đổi màu chủ đề:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Nhánh `NotDefined` cung cấp danh sách kiểm tra các độ phủ đặc sẽ không phản hồi khi các vị trí màu chủ đề thay đổi. Xem lại các đối tượng này khi một bản trình bày phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo cáo vẫn hiển thị giao diện hiện tại, trong khi giá trị lược đồ giải thích liệu giao diện đó có liên kết với chủ đề hay không.

Các đối tượng định dạng‑hiệu quả là ảnh chụp tĩnh. Sau khi thay đổi chủ đề bản trình bày, một ghi đè chủ đề, hoặc bất kỳ định dạng kế thừa nào, hãy gọi lại `getEffective` và đọc dữ liệu độ phủ hiệu quả mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá trị Chủ đề Hiệu quả**

Các đối tượng chủ đề thô cho bạn biết những gì đã được định nghĩa ở một mức nhất định. Các giá trị hiệu quả cho bạn biết một slide hoặc hình dạng thực sự sử dụng gì sau khi đã giải quyết kế thừa và ghi đè cục bộ. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/), và đối với độ phủ, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu quả, nền và độ phủ hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu quả cho việc chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng nào đó đã thay đổi giao diện cuối cùng.

## **FAQ**

**Áp dụng một chủ đề bên ngoài có ảnh hưởng tới mọi slide trong bản trình bày không?**

Không. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác giữ nguyên chủ đề hiện có.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề cho nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện có.

**Cách an toàn nhất để mang một chủ đề từ bản trình bày này sang bản trình bày khác là gì?**

Khi di chuyển một slide và muốn bảo lưu giao diện nguồn, sao chép master nguồn vào bản trình bày đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/) và sao chép slide cùng master đó bằng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/). Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/) cho một slide hoặc layout theme và các phương thức dữ liệu‑hiệu quả tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/). Những API này trả về các giá trị đã được giải quyết sau khi đã áp dụng kế thừa và ghi đè.