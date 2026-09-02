---
title: Quản lý Chủ đề Bản trình chiếu trong PHP
linktitle: Chủ đề Bản trình chiếu
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
- chủ đề bên ngoài
- THMX
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
description: "Quản lý các chủ đề bản trình chiếu trong Aspose.Slides cho PHP thông qua Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản trình chiếu xác định một tập hợp phối hợp các màu, phông chữ, kiểu nền, độ phủ, đường viền và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu tới các định nghĩa chia sẻ này thay vì lưu trữ từng thuộc tính trực quan dưới dạng giá trị cố định, do đó việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề cấp bản trình chiếu có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Một bản trình chiếu cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề bản trình chiếu qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề kế thừa của nó qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/). Trong thực tế, chủ đề hiệu lực cho một slide được giải quyết qua chuỗi kế thừa này: chủ đề bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây cho thấy các quy trình làm việc chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/) cung cấp sơ đồ màu, sơ đồ phông và sơ đồ định dạng của chủ đề thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/), và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo bao nhiêu kiểu nền, độ phủ, đường viền và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide có cùng một chủ đề hiệu lực. Kiểm tra master liên quan tới slide, và sử dụng quy trình làm việc chủ đề hiệu lực được mô tả sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi màu chủ đề**

Các độ phủ, đường viền và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành đỏ, lưu bản trình chiếu, mở lại và in ra màu độ phủ hiệu lực:

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

Vì hình chữ nhật vẫn được liên kết tới `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu lược đồ bằng một màu trực tiếp trên hình, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới độ phủ đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các chuyển đổi màu. Aspose.Slides cung cấp các chuyển đổi này qua liệt kê [ColorTransformOperation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu sáng hơn và tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo từ màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các chuyển đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã chuyển đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ các giá trị `SchemeColor` tới các khe `ColorScheme`**

Liệt kê [SchemeColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorscheme/) đưa ra cùng các khe chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bản đồ cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các khe chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ của chủ đề**

Một sơ đồ phông chữ chủ đề bao gồm một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ thân văn bản Latin (Phông chữ Latin phụ)
* `+mj-lt` - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* `+mn-ea` - Phông chữ thân văn bản Đông Á (Phông chữ Đông Á phụ)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ chủ đề và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và văn bản thân tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi sơ đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông cho các hệ viết riêng lẻ, chẳng hạn Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc áp dụng một chủ đề**

Các quy trình dưới đây giải quyết các vấn đề liên quan đến chủ đề khác nhau.

### **Áp dụng một Chủ đề bên ngoài cho các Slide phụ thuộc vào Master**

Sử dụng [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu cho mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation::getMasters](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), được biểu diễn bằng [MasterSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một slide master mới dựa trên master đã chọn.
1. Áp dụng chủ đề bên ngoài vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về [MasterSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) mới được tạo.

Ví dụ sau áp dụng một chủ đề bên ngoài cho các slide phụ thuộc vào master đầu tiên và lưu bản trình chiếu:

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

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxreadexception/). Xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và lưu bản trình chiếu chỉ sau khi chủ đề đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và chủ đề hiện tại. Các màu, phông, độ phủ, đường viền, nền và hiệu ứng nhận thức chủ đề được giải quyết dựa trên chủ đề bên ngoài. Các màu, phông, độ phủ và định dạng rõ ràng khác có thể vẫn không thay đổi. Các ghi đè ở cấp layout và slide cũng có thể ưu tiên so với các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu tới các phông chữ không có sẵn trong môi trường chạy. Để đảm bảo việc hiển thị và xuất khẩu nhất quán, hãy cài đặt các phông cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/php-java/custom-font/), hoặc cấu hình [font substitution](/slides/vi/php-java/font-substitution/).

Đây là quy trình làm việc trực tiếp ở cấp master: phương thức nhận một đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở cấp slide hoặc layout.

### **Áp dụng các Chủ đề bên ngoài khác nhau trong Bản trình chiếu đa Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện qua [Slide::getLayoutSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/) và [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslide/). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong bản trình chiếu.

Ví dụ sau sử dụng slide từ hai phần để xác định master của chúng và áp dụng một chủ đề bên ngoài khác nhau cho mỗi nhóm:

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

Lệnh gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `$firstGroupMaster`, và lệnh gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `$secondGroupMaster`. Các slide thuộc bất kỳ master nào khác đều không bị thay đổi kiểu.

### **Bảo lưu Chủ đề nguồn khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và bảo lưu thiết kế gốc, sao chép master nguồn vào bản trình chiếu đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/), sau đó sao chép slide bằng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình làm việc được khuyến nghị khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể thay đổi các màu, phông, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide hiện có**

Nếu slide đích phải giữ nguyên master và layout hiện tại, khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/), và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/) sao chép ba thành phần chính của chủ đề vào ghi đè.

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

Điều này thay đổi chủ đề được sử dụng bởi slide đó mà không thay đổi chủ đề mà các slide khác kế thừa. Để xóa ghi đè cục bộ và trở lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/layoutslidethememanager/):

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

Sử dụng một chủ đề cấp master hoặc cấp bản trình chiếu khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ sở, sử dụng ghi đè layout khi một nhóm layout cần kiểu khác, và sử dụng ghi đè slide chỉ cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu nền Chủ đề**

Các độ phủ nền của chủ đề được lưu trong [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số định nghĩa độ phủ thực tế được lưu trong bộ sưu tập này vì giao diện có thể kết hợp các độ phủ chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) hiện tại. Chỉ số kiểu `0` có nghĩa là không có độ phủ chủ đề; các giá trị dương là tham chiếu kiểu nền chủ đề. Điều này khác với việc chỉ mục trực tiếp vào bộ sưu tập PHP, nơi `get_Item(0)` là mục lưu đầu tiên. Đừng giả định mọi bản trình chiếu đều chứa cùng số lượng kiểu độ phủ nền.

Ví dụ sau báo cáo số lượng độ phủ nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu bản trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng của nó, việc chỉ thay đổi nền master có thể không thay đổi slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng coi chỉ số kiểu như một chỉ mục bộ sưu tập dựa trên số 0. Cũng tránh việc mã cứng một số kiểu từ một tệp và giả định nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng biệt cho mỗi bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/php-java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một sơ đồ định dạng chủ đề chứa các bộ sưu tập riêng biệt cho độ phủ, đường viền và hiệu ứng được mở ra qua [FormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/), và [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/php-java/aspose.slides/formatscheme/). Các chủ đề Office thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, vừa và mạnh, nhưng code nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Các hiệu ứng chủ đề nhẹ, vừa và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong PHP, chỉ mục bộ sưu tập là dựa trên số 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [ShapeStyle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapestyle/). Việc sửa đổi một kiểu chủ đề ảnh hưởng tới các hình dạng tham chiếu tới kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra xem các mục kiểu cần thiết có tồn tại không, thay đổi kiểu đường đầu tiên, thay đổi kiểu độ phủ thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu tới những khe này, kiểu đường chủ đề đầu tiên trở thành đỏ, kiểu độ phủ chủ đề thứ ba trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba nhận một bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào từng hình dạng tham chiếu khe nào và liệu định dạng trực tiếp có ghi đè lên chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi cài đặt đường, độ phủ và bóng đổ](presentation-design_11.png)

## **Đọc Các Giá trị Chủ đề Hiệu lực**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở một cấp cụ thể. Các giá trị hiệu lực cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè địa phương đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/), và đối với độ phủ, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu lực, nền và độ phủ hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu lực để chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng nào đó thay đổi diện mạo cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề bên ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác giữ nguyên chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ tồn tại ở slide đó; các slide khác vẫn kế thừa chủ đề hiện có.

**Cách an toàn nhất để mang một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

Khi di chuyển một slide và giữ nguyên giao diện nguồn, sao chép master nguồn vào đích và sao chép slide cùng master đó bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslidecollection/) và [SlideCollection.addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/). Điều này giữ nguyên master, các layout và chủ đề cùng nhau.

**Làm thế nào để xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu hiệu lực tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.