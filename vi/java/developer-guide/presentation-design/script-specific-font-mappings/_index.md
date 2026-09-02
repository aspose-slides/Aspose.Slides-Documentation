---
title: Quản lý phông chữ Theme riêng cho Script trong Java
linktitle: Phông chữ Theme riêng cho Script
type: docs
weight: 15
url: /vi/java/script-specific-font-mappings/
keywords:
- phông chữ riêng cho script
- ánh xạ phông chữ theme
- bản trình chiếu đa ngôn ngữ
- hệ thống viết
- phông chữ Cyrillic
- phông chữ Arabic
- phông chữ Japanese
- phông chữ Georgian
- phông chữ Thaana
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xoá các ánh xạ phông chữ riêng cho script trong các Theme PowerPoint bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Một giao diện bản trình chiếu có thể chọn các họ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ giao diện để tuân theo một sơ đồ phông chữ thống nhất, đồng thời áp dụng các phông chữ thích hợp cho Cyrillic, Arabic, Japanese, Georgian, Thaana và các chữ viết khác.

[IFontScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontscheme/) của giao diện chứa một bộ sưu tập phông chữ chính, thường được dùng cho tiêu đề, và một bộ sưu tập phông chữ phụ, thường được dùng cho nội dung. Ngoài các cài đặt phông chữ Latin và Đông Á, cả hai bộ sưu tập đều cung cấp ánh xạ từ các thẻ hệ thống viết sang tên họ phông chữ thông qua giao diện [IFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifonts/).

Bài viết này chỉ ra cách kiểm tra và sửa đổi các ánh xạ đó trong giao diện chủ đề của bản trình chiếu và xác minh rằng các thay đổi vẫn tồn tại sau một chu kỳ lưu và tải lại.

## **Hiểu các thẻ Script**

Các phương thức phông chữ script sử dụng các phụ thẻ script BCP 47 gồm bốn ký tự để xác định hệ thống viết. Các giá trị phổ biến bao gồm:

| Thẻ script | Hệ thống viết |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Trung Quốc giản thể |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Các ánh xạ này thuộc về sơ đồ phông chữ của giao diện, không phải của các đoạn văn bản riêng lẻ. Một bản trình chiếu có thể định nghĩa các ánh xạ khác nhau cho bộ sưu tập chính và phụ, và có thể không có ánh xạ cho một số script.

## **Truy cập và Kiểm tra Ánh xạ Phông chữ Script**

Sử dụng [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getMasterTheme--) để truy cập giao diện ở mức bản trình chiếu. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontscheme/#getMajor--) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontscheme/#getMinor--) trả về hai bộ sưu tập [IFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifonts/).

Gọi [IFonts.getScriptFontMap](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fonts/#getScriptFontMap--) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết, gọi [IFonts.getScriptFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) với thẻ script tương ứng. `getScriptFont` trả về `null` khi bộ sưu tập đó không định nghĩa ánh xạ được yêu cầu.

## **Sửa đổi Ánh xạ và Xác minh Độ Bền**

Sử dụng [IFonts.setScriptFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) để tạo một ánh xạ hoặc thay thế họ phông chữ hiện tại. Dùng [IFonts.removeScriptFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) để xoá một ánh xạ.

Ví dụ dưới đây thực hiện toàn bộ quy trình: đọc tất cả các ánh xạ chính và phụ hiện có, tra cứu phông chữ chính cho Japanese, thay đổi phông chữ chính cho Cyrillic, xoá ánh xạ phụ cho Thaana, lưu bản trình chiếu và mở lại để xác minh cả hai thay đổi. Để bước xoá không phụ thuộc vào giao diện ban đầu, ví dụ sẽ tạo ánh xạ Thaana chỉ khi chưa có ánh xạ nào.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Việc xác minh sử dụng cùng hành vi `null` như một tra cứu thông thường: sau khi lưu bước xoá, `getScriptFont("Thaa")` trả về `null` cho bộ sưu tập phụ.

## **Phân biệt Ánh xạ Giao diện và Các Cài đặt Phông chữ Khác**

Ánh xạ phông chữ theme theo script tham gia vào việc chọn phông chữ, nhưng chúng giải quyết một vấn đề khác so với định dạng văn bản trực tiếp, thay thế và dự phòng:

| Cơ chế | Mục đích | Ảnh hưởng khi thay đổi ánh xạ theme |
|---|---|---|
| Ánh xạ phông chữ theme theo script | Chọn phông chữ theme chính hoặc phụ cho một hệ thống viết. | Văn bản vẫn sử dụng phông chữ theme tương ứng có thể chuyển sang họ mới được ánh xạ. |
| Phông chữ được gán rõ ràng cho một đoạn văn bản | Ghi cố định họ phông chữ được yêu cầu cho đoạn đó thay vì dựa vào theme. | Đoạn văn bản có thể không thay đổi vì định dạng trực tiếp ghi đè lựa chọn theme. |
| Thay thế phông chữ | Thay thế phông chữ được yêu cầu khi phông chữ đó không khả dụng hoặc khi quy tắc thay thế áp dụng. | Thực hiện sau khi phông chữ đã được yêu cầu; không định nghĩa lại ánh xạ script của theme. |
| Dự phòng phông chữ | Cung cấp các glyph mà phông chữ đã chọn không chứa, thường cho các dải Unicode cụ thể. | Điền vào các glyph thiếu; không thay đổi ánh xạ theme đã lưu. |

Để biết thêm thông tin về hai cơ chế cuối cùng, xem [Font Substitution](/slides/vi/java/font-substitution/) và [Fallback Fonts](/slides/vi/java/fallback-font/).

Thay đổi một ánh xạ trong [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getMasterTheme--) chỉ ảnh hưởng đến nội dung mà định dạng thực tế vẫn phụ thuộc vào theme đó. Văn bản có thể kế thừa một theme ghi đè từ master, layout hoặc slide, hoặc sử dụng một phông chữ được gán rõ ràng. Kiểm tra các mức này khi kết quả hiển thị không tuân theo ánh xạ ở mức bản trình chiếu.

## **Cung cấp Phông chữ Được Ánh xạ và Xác thực Kết quả**

Một ánh xạ script lưu trữ tên họ phông chữ; nó không cài đặt hoặc tải tệp phông chữ tương ứng. Để đảm bảo việc hiển thị và xuất khẩu nhất quán, mọi phông chữ được ánh xạ phải được cài đặt trong môi trường hoặc được cung cấp cho Aspose.Slides qua một nguồn tùy chỉnh như [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) hoặc [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Xem [Custom Fonts](/slides/vi/java/custom-font/) để biết các tùy chọn tải lên khả dụng.

Xác minh ánh xạ đã lưu chỉ chứng minh rằng định nghĩa theme đã được giữ lại. Nó không chứng minh rằng phông chữ có sẵn, chứa tất cả glyph cần thiết, hoặc tạo ra bố cục mong muốn. Hãy render văn bản mẫu cho mỗi hệ thống viết cần thiết thành hình ảnh hoặc PDF và kiểm tra kết quả. Điều này sẽ phát hiện phông chữ thiếu, phạm vi glyph không đầy đủ, hành vi dự phòng và thay đổi bố cục trước khi bản trình chiếu được phát hành. Xem [Convert PowerPoint Presentations](/slides/vi/java/convert-powerpoint/) để biết ví dụ về render và xuất khẩu.

## **Câu hỏi Thường gặp**

**`getScriptFont` trả về gì khi một script không được ánh xạ?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) trả về `null` khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập phông chữ chính hoặc phụ tương ứng.

**`setScriptFont` có thêm một ánh xạ thứ hai khi script đã tồn tại không?**

Không. [IFonts.setScriptFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) tạo ánh xạ khi chưa có và thay thế họ phông chữ đã ánh xạ khi thẻ script đã tồn tại.

**Tại sao việc thay đổi ánh xạ theme không làm thay đổi một số văn bản?**

Văn bản có thể đã được gán phông chữ rõ ràng, kế thừa một theme khác qua ghi đè, hoặc bị ảnh hưởng bởi thay thế hoặc dự phòng trong quá trình render. Một ánh xạ script ở mức bản trình chiếu chỉ điều khiển những văn bản mà định dạng thực tế vẫn tham chiếu đến bộ sưu tập phông chữ của theme đó.

**Lưu và mở lại có đủ để xác thực đầu ra đa ngôn ngữ không?**

Không. Mở lại chỉ xác nhận tính bền vững của dữ liệu theme. Cũng cần render văn bản mẫu từ mỗi hệ thống viết yêu cầu để xác nhận rằng các phông chữ đã được ánh xạ có sẵn và chứa các glyph cần thiết.