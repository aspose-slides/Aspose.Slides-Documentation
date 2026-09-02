---
title: Quản lý phông chữ theme theo script trên Android
linktitle: Phông chữ Theme Theo Script
type: docs
weight: 15
url: /vi/androidjava/script-specific-font-mappings/
keywords:
- phông chữ theo script
- ánh xạ phông chữ theme
- bản trình chiếu đa ngôn ngữ
- hệ thống viết
- phông chữ Cyrillic
- phông chữ Ả Rập
- phông chữ Nhật Bản
- phông chữ Gruzia
- phông chữ Thaana
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Kiểm tra, thêm, thay thế và xóa các ánh xạ phông chữ theo script trong các theme PowerPoint bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Một giao diện trình chiếu có thể chọn các họ phông chữ khác nhau cho các hệ thống viết khác nhau. Điều này cho phép văn bản đa ngôn ngữ vẫn sử dụng phông chữ của giao diện tuân theo một sơ đồ phông chữ đồng nhất trong khi sử dụng các phông chữ phù hợp cho Cyrillic, Arabic, Japanese, Georgian, Thaana và các script khác.

Giao diện theme chứa một bộ sưu tập phông chữ chính, thường dùng cho tiêu đề, và một bộ sưu tập phông chữ phụ, thường dùng cho nội dung. Ngoài các cài đặt phông chữ Latin và Đông Á, cả hai bộ sưu tập đều cung cấp các ánh xạ từ thẻ hệ thống viết sang tên họ phông chữ thông qua giao diện [IFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifonts/).

Bài viết này mô tả cách kiểm tra và sửa đổi các ánh xạ đó trong theme master của bản trình chiếu và xác minh rằng các thay đổi vẫn tồn tại sau một chu kỳ lưu‑và‑tải lại.

## **Hiểu các Thẻ Script**

Các phương thức phông chữ script sử dụng các thẻ script phụ BCP 47 gồm bốn ký tự để xác định hệ thống viết. Các giá trị thường gặp bao gồm:

| Script tag | Hệ thống viết |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Tiếng Ả Rập |
| `Hans` | Tiếng Trung giản thể |
| `Jpan` | Tiếng Nhật |
| `Geor` | Tiếng Gruzia |
| `Thaa` | Thaana |

Các ánh xạ này thuộc về scheme phông chữ của theme, không phải các phần văn bản riêng lẻ. Một bản trình chiếu có thể định nghĩa các ánh xạ khác nhau cho bộ sưu tập chính và phụ, và có thể không định nghĩa ánh xạ cho một số script.

## **Truy cập và Kiểm tra Ánh xạ Phông chữ Script**

Sử dụng [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getMasterTheme--) để truy cập theme ở cấp độ bản trình chiếu. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/#getMajor--) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/#getMinor--) trả về hai bộ sưu tập [IFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifonts/).

Gọi [IFonts.getScriptFontMap](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) để lấy tất cả các ánh xạ từ một bộ sưu tập. Để tra cứu một hệ thống viết, gọi [IFonts.getScriptFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) với thẻ script tương ứng. `getScriptFont` trả về `null` khi bộ sưu tập đó không định nghĩa ánh xạ yêu cầu.

## **Sửa đổi Ánh xạ và Xác minh Sự Bảo tồn**

Sử dụng [IFonts.setScriptFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) để tạo một ánh xạ hoặc thay đổi họ phông chữ hiện tại. Sử dụng [IFonts.removeScriptFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) để xóa một ánh xạ.

Ví dụ toàn diện dưới đây đọc tất cả các ánh xạ chính và phụ hiện có, tra cứu phông chữ chính cho Japanese, thay đổi phông chữ chính cho Cyrillic, xóa ánh xạ phụ cho Thaana, lưu bản trình chiếu và mở lại để xác minh cả hai thay đổi. Để bước xóa không phụ thuộc vào theme ban đầu, ví dụ đầu tiên tạo ánh xạ Thaana chỉ khi chưa có ánh xạ nào.

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

Việc xác minh sử dụng cùng hành vi `null` như tra cứu thông thường: sau khi lưu xong bước xóa, `getScriptFont("Thaa")` trả về `null` cho bộ sưu tập phụ.

## **Phân biệt Ánh xạ Theme với Các Cài đặt Phông chữ Khác**

Các ánh xạ theme theo script tham gia vào việc chọn phông chữ, nhưng chúng giải quyết một vấn đề khác so với định dạng văn bản trực tiếp, thay thế phông chữ và fallback:

| Cơ chế | Mục đích | Ảnh hưởng khi thay đổi ánh xạ theme |
|---|---|---|
| Script-specific theme font mapping | Chọn phông chữ theme chính hoặc phụ cho một hệ thống viết. | Văn bản vẫn sử dụng phông chữ theme tương ứng sẽ được ánh xạ tới họ mới. |
| Font assigned explicitly to a text portion | Gán cố định họ phông chữ cho đoạn văn bản đó thay vì dựa vào theme. | Đoạn văn có thể không thay đổi vì định dạng trực tiếp ghi đè lên lựa chọn theme. |
| Font substitution | Thay thế phông chữ yêu cầu khi phông chữ đó không khả dụng hoặc có quy tắc thay thế. | Thực hiện sau khi yêu cầu phông chữ; không định nghĩa lại ánh xạ script của theme. |
| Font fallback | Cung cấp glyph mà phông chữ đã chọn không có, thường cho các phạm vi Unicode cụ thể. | Điền vào các glyph thiếu; không thay đổi ánh xạ theme đã lưu. |

Để biết thêm thông tin về hai cơ chế cuối, xem [Font Substitution](/slides/vi/androidjava/font-substitution/) và [Fallback Fonts](/slides/vi/androidjava/fallback-font/).

Thay đổi một ánh xạ trong [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getMasterTheme--) chỉ ảnh hưởng đến nội dung mà định dạng thực tế vẫn dựa vào theme đó. Văn bản có thể kế thừa một theme override từ master, layout hoặc slide, hoặc sử dụng phông chữ được gán trực tiếp. Kiểm tra các cấp độ này khi kết quả hiển thị không tuân theo ánh xạ ở cấp độ bản trình chiếu.

## **Cung cấp Phông chữ Được Ánh xạ và Xác nhận Kết quả**

Một ánh xạ script lưu trữ tên họ phông chữ; nó không cài đặt hoặc tải tệp phông chữ tương ứng. Để hiển thị nhất quán và xuất khẩu, mỗi phông chữ đã ánh xạ phải được cài đặt trong môi trường hoặc cung cấp cho Aspose.Slides qua một nguồn tùy chỉnh như [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) hoặc [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Xem [Custom Fonts](/slides/vi/androidjava/custom-font/) để biết các tùy chọn tải sẵn có.

Xác thực ánh xạ đã lưu chỉ chứng minh rằng định nghĩa theme đã được bảo tồn. Nó không chứng minh rằng phông chữ khả dụng, chứa đầy đủ glyph cần thiết, hay tạo ra bố cục mong muốn. Hãy render văn bản mẫu cho mỗi hệ thống viết cần thiết thành hình ảnh hoặc PDF và kiểm tra kết quả. Điều này giúp phát hiện phông chữ thiếu, coverage glyph không đầy đủ, hành vi fallback và thay đổi bố cục trước khi bản trình chiếu được phân phối. Xem [Convert PowerPoint Presentations](/slides/vi/androidjava/convert-powerpoint/) để biết ví dụ về render và xuất khẩu.

## **Câu hỏi thường gặp**

**`getScriptFont` trả về gì khi một script không được ánh xạ?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) trả về `null` khi ánh xạ script được yêu cầu không được định nghĩa trong bộ sưu tập phông chữ chính hoặc phụ tương ứng.

**`setScriptFont` có tạo một ánh xạ thứ hai khi script đã tồn tại không?**

Không. [IFonts.setScriptFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) tạo ánh xạ khi nó chưa tồn tại và thay thế họ phông chữ đã ánh xạ khi thẻ script đã có.

**Tại sao việc thay đổi một ánh xạ theme lại không làm thay đổi một số văn bản?**

Văn bản có thể đã được gán phông chữ một cách rõ ràng, kế thừa một theme khác qua override, hoặc bị ảnh hưởng bởi substitution hoặc fallback trong quá trình render. Ánh xạ script ở cấp độ bản trình chiếu chỉ điều khiển các văn bản mà định dạng thực tế vẫn tham chiếu tới bộ sưu tập phông chữ của theme đó.

**Lưu và mở lại có đủ để xác nhận đầu ra đa ngôn ngữ không?**

Không. Mở lại chỉ xác minh sự tồn tại của dữ liệu theme. Cũng cần render văn bản mẫu từ mỗi hệ thống viết cần thiết để xác nhận rằng các phông chữ đã ánh xạ khả dụng và chứa các glyph cần thiết.