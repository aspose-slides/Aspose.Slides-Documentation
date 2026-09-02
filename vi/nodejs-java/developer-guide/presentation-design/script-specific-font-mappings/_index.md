---
title: Quản lý phông chữ chủ đề riêng cho script trong JavaScript
linktitle: Phông chữ chủ đề riêng cho script
type: docs
weight: 15
url: /vi/nodejs-java/script-specific-font-mappings/
keywords:
- phông chữ riêng cho script
- ánh xạ phông chữ chủ đề
- bản trình bày đa ngôn ngữ
- hệ thống viết
- phông Cyrillic
- phông Arabic
- phông Japanese
- phông Georgian
- phông Thaana
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xóa các ánh xạ phông chữ riêng cho script trong chủ đề PowerPoint bằng Aspose.Slides cho Node.js."
---
## **Tổng quan**

Một chủ đề bản trình bày có thể chọn các họ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ của chủ đề và tuân theo một sơ đồ phông chữ phối hợp, trong khi sử dụng các phông chữ phù hợp cho Cyrillic, Arabic, Japanese, Georgian, Thaana và các chữ viết khác.

[FontScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontscheme/) của chủ đề chứa một bộ sưu tập phông chữ chính, thường dùng cho tiêu đề, và một bộ sưu tập phụ, thường dùng cho nội dung văn bản. Ngoài các cài đặt phông Latin và Đông Á, cả hai bộ sưu tập đều cung cấp các ánh xạ từ thẻ hệ thống viết sang tên họ phông chữ thông qua lớp [Fonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/).

Bài viết này trình bày cách kiểm tra và sửa đổi các ánh xạ đó trong chủ đề mẫu của bản trình bày và xác minh rằng các thay đổi vẫn tồn tại sau một chu kỳ lưu‑và‑tải lại.

## **Hiểu các thẻ Script**

Các phương thức phông chữ script sử dụng các phụ thẻ script BCP 47 có bốn ký tự để xác định hệ thống viết. Các giá trị thường gặp bao gồm:

| Thẻ script | Hệ thống viết |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Tiếng Trung giản thể |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Các ánh xạ này thuộc về sơ đồ phông chữ của chủ đề, không phải của các đoạn văn bản riêng lẻ. Một bản trình bày có thể định nghĩa các ánh xạ khác nhau cho bộ sưu tập chính và phụ, và có thể bỏ qua một số script.

## **Truy cập và Kiểm tra Ánh xạ Phông chữ Script**

Sử dụng [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getmastertheme/) để truy cập chủ đề ở mức bản trình bày. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontscheme/) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontscheme/) trả về hai bộ sưu tập [Fonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/).

Gọi [Fonts.getScriptFontMap](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết, gọi [Fonts.getScriptFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/) với thẻ script tương ứng. `getScriptFont` trả về `null` khi bộ sưu tập đó không định nghĩa ánh xạ được yêu cầu.

## **Sửa đổi Ánh xạ và Xác minh Tính Bảo tồn**

Sử dụng [Fonts.setScriptFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/) để tạo một ánh xạ mới hoặc thay thế họ phông chữ hiện tại. Dùng [Fonts.removeScriptFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/) để xóa một ánh xạ.

Ví dụ toàn diện dưới đây đọc tất cả các ánh xạ chính và phụ hiện có, tra cứu phông chữ chính cho Japanese, thay đổi phông chữ chính cho Cyrillic, xóa ánh xạ phụ cho Thaana, lưu bản trình bày và mở lại để xác minh cả hai thay đổi. Để bước xóa không phụ thuộc vào chủ đề ban đầu, ví dụ sẽ tạo ánh xạ Thaana chỉ khi chưa có ánh xạ nào được định nghĩa.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Việc xác minh sử dụng cùng hành vi `null` như một tra cứu thông thường: sau khi lưu bước xóa, `getScriptFont("Thaa")` trả về `null` cho bộ sưu tập phụ.

## **Phân biệt Ánh xạ Chủ đề và Các Cài đặt Phông chữ Khác**

Ánh xạ chủ đề riêng cho script tham gia vào việc lựa chọn phông chữ, nhưng chúng giải quyết một vấn đề khác so với định dạng văn bản trực tiếp, thay thế phông và dự phòng:

| Cơ chế | Mục đích | Ảnh hưởng khi thay đổi ánh xạ chủ đề |
|---|---|---|
| Ánh xạ phông chữ chủ đề riêng cho script | Chọn phông chữ chủ đề chính hoặc phụ cho một hệ thống viết. | Văn bản vẫn sử dụng phông chữ chủ đề tương ứng sẽ được giải quyết thành họ mới đã ánh xạ. |
| Phông chữ được gán rõ ràng cho một đoạn văn bản | Gắn cố định họ phông chữ cho đoạn đó mà không dựa vào chủ đề. | Đoạn văn bản có thể không thay đổi vì định dạng trực tiếp ghi đè lên lựa chọn của chủ đề. |
| Thay thế phông chữ | Thay thế phông chữ được yêu cầu khi phông đó không có sẵn hoặc khi quy tắc thay thế áp dụng. | Thực thi sau khi phông đã được yêu cầu; không định nghĩa lại ánh xạ script của chủ đề. |
| Dự phòng phông chữ | Cung cấp các glyph mà phông đã chọn không chứa, thường cho các phạm vi Unicode cụ thể. | Bổ sung các glyph thiếu; không thay đổi ánh xạ chủ đề đã lưu. |

Để biết thêm về hai cơ chế cuối cùng, xem [Font Substitution](/slides/vi/nodejs-java/font-substitution/) và [Fallback Fonts](/slides/vi/nodejs-java/fallback-font/).

Thay đổi một ánh xạ trong [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getmastertheme/) chỉ ảnh hưởng đến nội dung mà định dạng thực tế vẫn dựa vào chủ đề đó. Văn bản có thể kế thừa một ghi đè chủ đề từ master, layout hoặc slide, hoặc sử dụng phông chữ được gán rõ ràng. Kiểm tra các cấp này khi kết quả hiển thị không tuân theo ánh xạ ở mức bản trình bày.

## **Cung cấp Phông chữ Được Ánh xạ và Xác thực Kết quả**

Một ánh xạ script lưu trữ tên họ phông chữ; nó không cài đặt hoặc tải tệp phông tương ứng. Để render nhất quán và xuất file, mọi phông chữ được ánh xạ đều phải được cài đặt trong môi trường hoặc cung cấp cho Aspose.Slides thông qua nguồn tùy chỉnh như [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) hoặc [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/). Xem [Custom Fonts](/slides/vi/nodejs-java/custom-font/) để biết các tùy chọn tải lên có sẵn.

Việc xác minh ánh xạ đã lưu chỉ chứng minh rằng định nghĩa chủ đề được bảo tồn. Nó không chứng minh rằng phông chữ có sẵn, chứa đầy đủ glyph cần thiết, hay tạo ra bố cục mong muốn. Hãy render văn bản đại diện cho mỗi hệ thống viết bắt buộc thành hình ảnh hoặc PDF và kiểm tra kết quả. Cách này sẽ phát hiện phông chữ thiếu, phạm vi glyph không đầy đủ, hành vi dự phòng và thay đổi bố cục trước khi bản trình bày được phân phối. Xem [Convert PowerPoint Presentations](/slides/vi/nodejs-java/convert-powerpoint/) để biết ví dụ về render và xuất.

## **Câu hỏi thường gặp**

**`getScriptFont` trả về gì khi một script không được ánh xạ?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/) trả về `null` khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập phông chính hoặc phụ tương ứng.

**`setScriptFont` có tạo thêm một ánh xạ khi script đã tồn tại không?**

Không. [Fonts.setScriptFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fonts/) tạo ánh xạ khi còn thiếu và thay thế họ phông chữ đã ánh xạ khi thẻ script đã có sẵn.

**Tại sao việc thay đổi ánh xạ chủ đề không làm thay đổi một số văn bản?**

Văn bản có thể có phông chữ được gán rõ ràng, kế thừa một chủ đề khác qua ghi đè, hoặc bị ảnh hưởng bởi thay thế hoặc dự phòng trong quá trình render. Ánh xạ script ở mức bản trình bày chỉ kiểm soát những văn bản mà định dạng thực tế vẫn tham chiếu đến bộ sưu tập phông chủ đề đó.

**Lưu và mở lại có đủ để xác thực đầu ra đa ngôn ngữ không?**

Không. Mở lại chỉ xác minh tính bảo tồn của dữ liệu chủ đề. Cũng cần render văn bản đại diện cho mỗi hệ thống viết yêu cầu để xác nhận rằng các phông chữ đã ánh xạ có sẵn và chứa các glyph cần thiết.