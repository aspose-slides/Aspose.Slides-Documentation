---
title: Quản lý phông chữ chủ đề theo script trong PHP
linktitle: Phông chữ chủ đề theo script
type: docs
weight: 15
url: /vi/php-java/script-specific-font-mappings/
keywords:
- phông chữ theo script
- ánh xạ phông chữ chủ đề
- bản trình chiếu đa ngôn ngữ
- hệ thống viết
- phông chữ Cyrillic
- phông chữ Ả Rập
- phông chữ Nhật
- phông chữ Georgia
- phông chữ Thaana
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xóa các ánh xạ phông chữ theo script trong chủ đề PowerPoint với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Một chủ đề trình chiếu có thể chọn các họ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ của chủ đề để theo một sơ đồ phông chữ đồng nhất trong khi sử dụng các phông chữ phù hợp cho Cyrillic, Arabic, Japanese, Georgian, Thaana và các ký tự khác.

Bộ [FontScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/) của chủ đề chứa một bộ sưu tập phông chữ chính, thường được sử dụng cho tiêu đề, và một bộ sưu tập phông chữ phụ, thường được sử dụng cho nội dung văn bản. Ngoài các cài đặt phông chữ Latin và Đông Á, cả hai bộ sưu tập [Fonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/) đều cung cấp các ánh xạ từ thẻ hệ thống viết sang tên họ phông chữ.

Bài viết này mô tả cách kiểm tra và chỉnh sửa các ánh xạ đó trong chủ đề master của bản trình chiếu và xác minh rằng các thay đổi vẫn tồn tại sau một vòng lưu và tải lại.

## **Hiểu các Thẻ Script**

Các phương thức phông chữ script sử dụng các phụ thẻ script BCP 47 bốn ký tự để xác định hệ thống viết. Các giá trị thường gặp bao gồm:

| Thẻ script | Hệ thống viết |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Tiếng Trung giản thể |
| `Jpan` | Tiếng Nhật |
| `Geor` | Tiếng Gruzia |
| `Thaa` | Thaana |

## **Truy cập và Kiểm tra Ánh xạ Phông chữ Script**

Sử dụng [Presentation::getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getMasterTheme) để truy cập vào chủ đề cấp trình chiếu. Các phương thức [MasterTheme::getFontScheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/#getMajor) và [FontScheme::getMinor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontscheme/#getMinor) cung cấp quyền truy cập vào hai bộ sưu tập [Fonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/).

Gọi [Fonts::getScriptFontMap](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/#getScriptFontMap) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết, gọi [Fonts::getScriptFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/#getScriptFont) với thẻ script của nó. `Fonts::getScriptFont` trả về `null` khi bộ sưu tập đó không định nghĩa ánh xạ được yêu cầu.

## **Chỉnh sửa Ánh xạ và Xác minh Tính Bền vững**

Sử dụng [Fonts::setScriptFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/#setScriptFont) để tạo một ánh xạ hoặc thay thế họ phông chữ hiện tại. Sử dụng [Fonts::removeScriptFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/#removeScriptFont) để xóa một ánh xạ.

Ví dụ toàn diện dưới đây đọc tất cả các ánh xạ chính và phụ hiện có, tra cứu phông chữ chính cho Japanese, thay đổi phông chữ chính cho Cyrillic, xóa ánh xạ phụ cho Thaana, lưu bản trình chiếu và mở lại để xác minh cả hai thay đổi. Để bước xóa không phụ thuộc vào chủ đề ban đầu, ví dụ đầu tiên tạo ánh xạ Thaana chỉ khi chưa có ánh xạ nào được định nghĩa.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Xác minh sử dụng cùng hành vi `null` như một truy vấn thông thường: sau khi xóa được lưu, `Fonts::getScriptFont("Thaa")` trả về `null` cho bộ sưu tập phụ.

## **Phân biệt Ánh xạ Chủ đề với Các Cài đặt Phông chữ Khác**

| Cơ chế | Mục đích | Ảnh hưởng của việc thay đổi ánh xạ chủ đề |
|---|---|---|
| Ánh xạ phông chữ chủ đề theo script | Chọn phông chữ chủ đề chính hoặc phụ cho một hệ thống viết. | Văn bản vẫn sử dụng phông chữ chủ đề tương ứng có thể chuyển đến họ mới được ánh xạ. |
| Phông chữ được gán một cách rõ ràng cho một phần văn bản | Cố định họ phông chữ yêu cầu cho phần đó thay vì dựa vào chủ đề. | Phần này có thể không thay đổi vì định dạng trực tiếp ghi đè lên lựa chọn của chủ đề. |
| Thay thế phông chữ | Thay thế phông chữ yêu cầu khi phông chữ đó không có hoặc khi quy tắc thay thế áp dụng. | Nó hoạt động sau khi phông chữ đã được yêu cầu; không định nghĩa lại ánh xạ script của chủ đề. |
| Phông chữ dự phòng | Cung cấp các glyph mà phông chữ đã chọn không chứa, thường cho các phạm vi Unicode cụ thể. | Nó lấp đầy các glyph còn thiếu; không thay đổi ánh xạ chủ đề đã lưu. |

Để biết thêm thông tin về hai cơ chế cuối cùng, xem [Font Substitution](/slides/vi/php-java/font-substitution/) và [Fallback Fonts](/slides/vi/php-java/fallback-font/).

Thay đổi một ánh xạ trong [Presentation::getMasterTheme](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getMasterTheme) chỉ ảnh hưởng đến nội dung mà định dạng hiệu quả vẫn phụ thuộc vào chủ đề đó. Văn bản có thể thay vào đó kế thừa một ghi đè chủ đề từ master, layout hoặc slide, hoặc sử dụng một phông chữ được gán rõ ràng. Kiểm tra các cấp này khi kết quả hiển thị không theo ánh xạ cấp trình chiếu.

## **Cung cấp Phông chữ Được Ánh xạ và Xác nhận Kết quả**

Một ánh xạ script chỉ lưu tên họ phông chữ; nó không cài đặt hoặc tải tệp phông chữ tương ứng. Để hiển thị và xuất ra nhất quán, mỗi phông chữ được ánh xạ phải được cài đặt trong môi trường hoặc được cung cấp cho Aspose.Slides qua nguồn tùy chỉnh như [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFonts) hoặc [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Xem [Custom Fonts](/slides/vi/php-java/custom-font/) để biết các tùy chọn tải.

Xác minh ánh xạ đã lưu chỉ chứng nhận rằng định nghĩa chủ đề đã được bảo tồn. Nó không chứng minh rằng phông chữ có sẵn, chứa tất cả glyph cần thiết, hoặc tạo ra bố cục dự định. Hãy render văn bản mẫu cho mỗi hệ thống viết yêu cầu thành ảnh hoặc PDF và kiểm tra kết quả. Điều này giúp bắt phông chữ thiếu, vùng phủ glyph chưa đầy đủ, hành vi fallback và thay đổi bố cục trước khi bản trình chiếu được phân phối. Xem [Convert PowerPoint Presentations](/slides/vi/php-java/convert-powerpoint/) để biết các ví dụ về render và xuất.

## **CÂU HỎI THƯỜNG GẶP**

**`Fonts::getScriptFont` trả về gì khi một script không được ánh xạ?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/#getScriptFont) trả về `null` khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập phông chữ chính hoặc phụ.

**`Fonts::setScriptFont` có thêm một ánh xạ thứ hai khi script đã tồn tại không?**

Không. [Fonts::setScriptFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fonts/#setScriptFont) tạo ánh xạ khi nó thiếu và thay thế họ phông chữ đã ánh xạ khi thẻ script đã có mặt.

**Tại sao việc thay đổi ánh xạ chủ đề không thay đổi một số văn bản?**

Văn bản có thể có phông chữ được gán rõ ràng, kế thừa một chủ đề khác qua ghi đè, hoặc bị ảnh hưởng bởi việc thay thế hoặc fallback trong quá trình render. Ánh xạ script cấp trình chiếu chỉ kiểm soát các văn bản mà định dạng hiệu quả vẫn tham chiếu tới bộ sưu tập phông chữ của chủ đề đó.

**Lưu và mở lại có đủ để xác thực đầu ra đa ngôn ngữ không?**

Không. Mở lại chỉ xác minh tính bền vững của dữ liệu chủ đề. Cũng cần render văn bản mẫu từ mỗi hệ thống viết yêu cầu để xác nhận rằng các phông chữ đã ánh xạ có sẵn và chứa các glyph cần thiết.