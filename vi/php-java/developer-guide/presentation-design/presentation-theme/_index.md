---
title: Quản lý Chủ đề Bài thuyết trình trong PHP
linktitle: Chủ đề Bài thuyết trình
type: docs
weight: 10
url: /vi/php-java/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề bài thuyết trình
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
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Quản lý các chủ đề bài thuyết trình trong Aspose.Slides cho PHP via Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bài thuyết trình định nghĩa một tập hợp phối hợp các màu, phông chữ, kiểu nền, tô, đường và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu đến những định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, do đó việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề ở mức độ bài thuyết trình có thể truy cập thông qua [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Một bài thuyết trình cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề bài thuyết trình thông qua [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề kế thừa của nó thông qua [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Trong thực tế, chủ đề hiệu lực cho một slide được giải quyết thông qua chuỗi kế thừa này: chủ đề bài thuyết trình, ghi đè master, ghi đè layout và ghi đè slide.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) cung cấp sơ đồ màu, sơ đồ phông chữ và sơ đồ định dạng của chủ đề thông qua [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) và [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Việc kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bài thuyết trình đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, tô, đường và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một chủ đề hiệu lực. Kiểm tra master liên quan đến slide, và sử dụng quy trình làm việc chủ đề hiệu lực được trình bày sau trong bài viết khi có thể có ghi đè ở mức layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các tô, đường và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ end-to-end sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bài thuyết trình, mở lại và in màu tô hiệu lực:

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

Vì hình chữ nhật vẫn được liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu sơ đồ bằng một màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng đến tô đó.

### **Sử dụng Màu từ Bảng màu Bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này thông qua enum [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

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

### **Ánh xạ Giá trị `SchemeColor` tới Các vị trí `ColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bảng ánh xạ cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng kia.

## **Thay đổi Phông chữ Chủ đề**

Một sơ đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) và [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)
* `+mn-cs` - Phông chữ nội dung Kịch bản phức hợp (Minor Complex Script Font)
* `+mj-cs` - Phông chữ tiêu đề Kịch bản phức hợp (Major Complex Script Font)

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

Tiêu đề tuân theo phông chữ chính và văn bản nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ rõ ràng thay vì định danh chủ đề sẽ không tự động chuyển khi sơ đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, hãy xem [Script-Specific Theme Fonts](/slides/vi/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
For more information about presentation fonts, see [PowerPoint Fonts](/slides/vi/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Giải quyết Tham chiếu Phông chữ Chủ đề**

Khi kiểm tra văn bản, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) có thể trả về một tham chiếu chủ đề như `+mn-lt` thay vì tên họ phông chữ. Gọi [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) với dữ liệu chủ đề hiệu lực phù hợp để giải quyết tham chiếu đó. Các tiền tố `+mj` và `+mn` chọn bộ phông chữ chính và phụ; các hậu tố `-lt`, `-ea` và `-cs` chọn phông chữ Latin, Đông Á và Kịch bản phức hợp tương ứng.

Lấy chủ đề hiệu lực thông qua [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) trên đối tượng mà chủ đề áp dụng cho văn bản được kiểm tra. Đối với văn bản thường trên một slide, gọi phương thức này trên slide để ngữ cảnh bao gồm chủ đề kế thừa của slide và các ghi đè cục bộ. Khi kiểm tra một layout hoặc master, sử dụng chủ đề hiệu lực riêng của chúng. Đừng giả định rằng chủ đề của master đầu tiên áp dụng cho mọi slide.

Ví dụ sau tạo một đoạn văn bản tham chiếu rõ ràng tới phông chữ Latin phụ. Nó khởi tạo một sơ đồ phông chữ slide thông qua [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) và đặt họ Latin chính và phụ thành `Arial` và `Calibri`, làm cho kết quả có thể tái tạo mà không cần tệp đầu vào.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Kết quả là `+mn-lt -> Calibri` tiếp theo là `Verdana -> Verdana`. Tham chiếu được lưu giữ không đổi, trong khi tên họ rõ ràng được trả về nguyên trạng. Nếu đoạn văn bản dùng `+mj-lt`, nó sẽ giải quyết thành `Arial` trong chủ đề này.

Giải quyết một tham chiếu chủ đề xác định họ phông chữ mà chủ đề chỉ định. Nó không kiểm tra tính khả dụng của phông chữ hoặc xác định tệp phông chữ cuối cùng được dùng sau khi thay thế hoặc fallback glyph trong quá trình render. Xem [Font Selection Sequence](/slides/vi/php-java/font-selection-sequence/) và [Font Substitution](/slides/vi/php-java/font-substitution/) cho các bước riêng biệt đó.

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình dưới đây giải quyết các vấn đề liên quan đến chủ đề khác nhau.

### **Áp dụng Chủ đề Ngoài cho Các Slide Phụ Thuộc vào Master**

Sử dụng [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), được biểu diễn bằng [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề ngoài vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) mới tạo.

Ví dụ sau áp dụng một chủ đề ngoài cho các slide phụ thuộc vào master đầu tiên và lưu bài thuyết trình:

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

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). Xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tập tin, và chỉ lưu bài thuyết trình sau khi chủ đề đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và chủ đề hiện tại. Các màu, phông chữ, tô, đường, nền và hiệu ứng nhận thức chủ đề sẽ được giải quyết dựa trên chủ đề ngoài. Các màu, phông chữ, tô và định dạng rõ ràng được gán trực tiếp có thể vẫn không thay đổi. Các ghi đè ở mức layout và slide cũng có thể có ưu tiên hơn các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu đến các phông chữ không có sẵn trong môi trường chạy. Để đảm bảo render và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/php-java/custom-font/), hoặc cấu hình [font substitution](/slides/vi/php-java/font-substitution/).

Đây là quy trình làm việc trực tiếp ở mức master: phương thức nhận đường dẫn tới tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở mức slide hoặc layout.

### **Áp dụng Các Chủ đề Ngoài Khác nhau trong Bài thuyết trình Nhiều Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện thông qua [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) và [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong bài thuyết trình.

Ví dụ sau sử dụng slide từ hai phần để xác định master của chúng và áp dụng một chủ đề ngoài khác nhau cho mỗi nhóm:

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

Lần gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `$firstGroupMaster`, và lần gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `$secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu dáng.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slide**

Nếu bạn muốn di chuyển một slide sang bài thuyết trình khác và giữ nguyên thiết kế gốc, sao chép master nguồn vào bài thuyết trình đích bằng [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), sau đó sao chép slide bằng [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) và master đã sao chép. Điều này sẽ mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình ưu tiên khi slide nguồn phải hiển thị giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide Đã Tồn tại**

Nếu slide đích phải ở trên master và layout hiện tại, khởi tạo một ghi đè ở mức slide từ chủ đề nguồn. Các phương thức [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) và [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) sao chép ba thành phần chủ đề chính vào ghi đè.

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

Điều này thay đổi chủ đề được slide sử dụng mà không thay đổi chủ đề kế thừa bởi các slide khác. Để xóa ghi đè cục bộ và trở lại giá trị kế thừa, gọi [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

Một ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

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

Sử dụng một chủ đề ở mức master hoặc bài thuyết trình khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và chỉ dùng ghi đè slide cho các ngoại lệ thực sự. Quá nhiều ghi đè ở mức slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu nền Chủ đề**

Các tô nền của chủ đề được lưu trong [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong UI so với số lượng định nghĩa tô thực tế được lưu trong bộ sưu tập này vì UI có thể kết hợp các tô chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Chỉ số kiểu `0` có nghĩa là không có tô chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ số trực tiếp vào bộ sưu tập PHP, trong đó `get_Item(0)` là mục đầu tiên được lưu. Đừng giả định rằng mọi bài thuyết trình đều chứa cùng số lượng kiểu tô nền.

Ví dụ sau báo cáo số lượng tô nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu bài thuyết trình:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide có nền riêng, việc chỉ thay đổi nền master có thể không thay đổi slide đó. Sử dụng [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Do not treat the style index as a zero-based collection index. Also avoid hard-coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation-specific.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
For direct background formatting and background inheritance, see [Presentation Background](/slides/vi/php-java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một sơ đồ định dạng chủ đề chứa các bộ sưu tập riêng biệt cho tô, đường và hiệu ứng được khai thác thông qua [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) và [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Các chủ đề Office thường chứa ba mục kiểu chính tương ứng với định dạng tinh tế, trung bình và mạnh mẽ, nhưng code nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong PHP, chỉ số bộ sưu tập là zero-based: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của shape là một khái niệm riêng, được khai thác qua [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Thay đổi một kiểu chủ đề ảnh hưởng đến các shape tham chiếu tới kiểu đó; các shape có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường đầu tiên, thay đổi kiểu tô thứ ba, kích hoạt bóng ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các shape tham chiếu các vị trí này, kiểu đường chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu tô chủ đề thứ ba sẽ trở thành màu xanh rừng đậm, và kiểu hiệu ứng thứ ba sẽ có bóng ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cụ thể vẫn phụ thuộc vào việc mỗi shape tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Chọn Kiểu Tô và Đường cho Shape**

Một shape có thể chọn tô và viền độc lập thông qua [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) và [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Đối với mỗi phương thức, chỉ số `1` chọn mục đầu tiên trong bộ sưu tập chủ đề tương ứng (`get_Item(0)`), và chỉ số `2` chọn mục thứ hai (`get_Item(1)`).

Ví dụ sau thiết lập hai kiểu tô (vàng và xanh trời) và hai kiểu đường (xanh đậm 6 pt và đỏ đậm 12 pt) trong chủ đề mặc định của một bài thuyết trình mới. Nó lưu slide ở ba giai đoạn để bạn có thể so sánh kết quả trong PowerPoint.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Kiểu ban đầu | Thay đổi viền bên phải | Chỉnh sửa tô chủ đề đầu tiên |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

Chọn một kiểu đường khác sẽ chỉ thay đổi viền của hình chữ nhật bên phải. Chỉnh sửa tô chủ đề đầu tiên sẽ cập nhật mọi shape sử dụng nó. Ở đây, chỉ hình chữ nhật bên trái đổi màu thành xanh lá.

Trên một shape đã tồn tại, một màu tô cục bộ, màu đường hoặc độ rộng đường có thể ghi đè phần đó của kiểu chủ đề. Nếu việc thay đổi chỉ số kiểu không có hiệu ứng nhìn thấy, hãy kiểm tra [direct formatting](/slides/vi/php-java/shape-formatting/) của shape.

## **Xác định Liệu Tô Đặc Hữu Hiệu sử dụng Màu Chủ đề hay Không**

Một tô có thể được lưu trực tiếp trên một đối tượng hoặc kế thừa từ đoạn văn, layout, master, kiểu chủ đề hoặc một mức định dạng khác. Gọi [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) để giải quyết cấp độ này thành dữ liệu tô hiệu lực bất biến. Đầu tiên kiểm tra kết quả của `getFillType`. Chỉ khi nó là `FillType::Solid` mới đọc các thuộc tính tô đặc.

Đối với tô đặc, `getSolidFillColor` trả về giá trị RGB cuối cùng sau khi kế thừa, tra cứu chủ đề và áp dụng các phép biến đổi màu. Phương thức `getSolidFillSchemeColor` trả về vị trí logic [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor::NotDefined` có nghĩa là tô đặc hiệu lực không dựa trên màu sơ đồ. Trong một quy trình mà các tô chỉ là màu chủ đề hoặc màu RGB trực tiếp, giá trị này xác định một tô RGB trực tiếp.

Không chỉ dùng giá trị địa phương [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) để phân loại một tô. Ví dụ, một đoạn văn có thể không có màu sơ đồ được định nghĩa cục bộ, do đó giá trị địa phương là `NotDefined`, trong khi tô hiệu lực kế thừa từ chủ đề và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho bạn biết vị trí chủ đề nào đã tạo ra màu hiệu lực, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay mức độ khác.

Ví dụ sau tải một bài thuyết trình, kiểm tra cả tô shape và tô đoạn văn, in mỗi giá trị RGB cuối cùng và màu sơ đồ liên quan, và đánh dấu các tô đặc sẽ không theo dõi thay đổi màu chủ đề:

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

Nhánh `NotDefined` cung cấp danh sách kiểm tra các tô đặc sẽ không phản hồi khi các vị trí màu chủ đề thay đổi. Xem lại những đối tượng này khi một bài thuyết trình phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo vẫn cho thấy diện mạo hiện tại, trong khi giá trị màu sơ đồ giải thích liệu diện mạo đó có liên kết với chủ đề hay không.

Các đối tượng định dạng hiệu lực là ảnh chụp nhanh. Sau khi thay đổi chủ đề bài thuyết trình, một ghi đè chủ đề, hoặc bất kỳ định dạng kế thừa nào, gọi lại `getEffective` và đọc dữ liệu tô mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá trị Chủ đề Hiệu lực**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở mức độ cụ thể. Các giá trị hiệu lực cho bạn biết slide hoặc shape thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Đối với nền, dùng [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), và đối với tô, dùng [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu lực, nền và tô shape đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu lực cho chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè shape thay đổi diện mạo cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề ngoài có ảnh hưởng tới mọi slide trong bài thuyết trình không?**

Không. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác giữ nguyên chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để mang một chủ đề từ bài thuyết trình này sang bài thuyết trình khác là gì?**

Khi di chuyển một slide và giữ nguyên diện mạo nguồn, sao chép master nguồn vào đích và sao chép slide cùng master đó bằng [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) và [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). Điều này giữ lại master, các layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu hiệu lực tương ứng cho các đối tượng định dạng như [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) và [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Những API này trả về các giá trị đã giải quyết sau khi kế thừa và ghi đè được áp dụng.