---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu Sử dụng Java
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/java/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay đổi phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Java khi render hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi một bản trình chiếu được hiển thị hoặc chuyển đổi. Việc thay thế ảnh hưởng đến kết quả hiển thị; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể định nghĩa phông chữ sẽ dùng khi một phông chữ cụ thể không khả dụng, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì kết quả nhất quán trên các môi trường có các phông chữ được cài đặt khác nhau.

## **Lấy các phép thay thế phông chữ**

Sử dụng phương thức [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) để xác định các phông chữ nào sẽ được thay thế khi bản trình chiếu được render. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

Ví dụ Java sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình chiếu:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Lấy các phép thay thế phông chữ cho các slide đã chọn**

Sử dụng phiên bản tải quá tải của [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với đối số `int[] slides` để chỉ kiểm tra các phép thay thế cần thiết cho việc render các slide cụ thể. Điều này hữu ích khi bạn đang render hoặc xuất một phần của bản trình chiếu, kiểm tra dần dần một bản trình chiếu lớn, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong render mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ số slide tính từ một: `1` đại diện cho slide đầu tiên. Ngược lại, bộ truy cập collection [Presentation.getSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlides--) sử dụng chỉ số bắt đầu từ 0, vì vậy slide tương tự được truy cập bằng `presentation.getSlides().get_Item(0)`. Hãy ghi nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch một.

Gọi phiên bản tải quá tải này thông qua phương thức [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getFontsManager--). Nó chỉ trả về các phép thay thế được xác định trong quá trình render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, và [phông chữ được tải từ bên ngoài](/slides/vi/java/custom-font/). Các quy tắc thay thế được lưu trong [IFontSubstRuleCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsubstrulecollection/) sẽ được áp dụng khi bản trình chiếu được render, nhưng kết quả không liệt kê chúng; thay vào đó kiểm tra các phông chữ trong tệp đầu ra.

Cùng một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo kiểm tra trước. Ví dụ sau báo cáo mỗi phép thay thế được trả về và sau đó tạo danh sách sắp xếp các ánh xạ phông chữ duy nhất:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Giao diện [IFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/) cung cấp cả hai phiên bản tải quá tải. Chọn một trong số chúng tùy theo phạm vi của thao tác render:

| Overload | Khi nào sử dụng |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) không có đối số | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với `int[] slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra dần dần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstrulecollection/).
5. Gán collection bằng cách sử dụng phương thức [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Render hoặc chuyển đổi bản trình chiếu.

Ví dụ Java sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, sau đó render slide đầu tiên để xác nhận kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Để thay đổi vô điều kiện các phông chữ được sử dụng trong toàn bộ bản trình chiếu, xem [Font Replacement](/slides/vi/java/font-replacement/).
{{% /alert %}}

## **Giới hạn cho phông chữ công thức toán học**

Các quy tắc thay thế phông chữ là một phần của quá trình lựa chọn phông chữ chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động với văn bản thường khi Aspose.Slides có thể thay thế phông chữ không truy cập được bằng phông chữ khả dụng được quy tắc chỉ định.

Các công thức Office Math có yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và render bố cục công thức. Quy tắc thay thế một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và quá trình render vẫn có thể báo rằng **Cambria Math** là cần thiết.

Để render hoặc chuyển đổi một bản trình chiếu như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó dưới dạng một [phông chữ bên ngoài](/slides/vi/java/custom-font/).

Giới hạn này áp dụng cho bố cục công thức. Các quy tắc thay thế đã mô tả ở trên vẫn áp dụng cho văn bản thường của bản trình chiếu.

## **Câu hỏi thường gặp**

**What is the difference between font replacement and font substitution?**

[Font replacement](/slides/vi/java/font-replacement/) cố ý thay đổi một phông chữ sang phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho kết quả hiển thị khi điều kiện được cấu hình thỏa mãn, chẳng hạn khi phông chữ gốc không khả dụng.

**When are substitution rules applied?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/java/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**What happens when a font is missing and no substitution rule is configured?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Can I load external fonts to avoid substitution?**

Có. Bạn có thể [load external fonts](/slides/vi/java/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình render và chuyển đổi.

**Does Aspose distribute fonts with the library?**

Không. Bạn có trách nhiệm cung cấp phông chữ và tuân thủ giấy phép của chúng.

**Can substitution results differ between Windows, Linux, and macOS?**

Có. Các phông chữ được cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy hệ điều hành, vì vậy một phông chữ có sẵn trên một máy có thể cần được thay thế trên máy khác.

**How can I make font selection consistent in batch conversions?**

Sử dụng cùng các tệp và phiên bản phông chữ trên mọi máy hoặc container, [load required external fonts](/slides/vi/java/custom-font/), và [embed fonts](/slides/vi/java/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) trước khi xuất để xác định các phép thay thế không mong muốn.