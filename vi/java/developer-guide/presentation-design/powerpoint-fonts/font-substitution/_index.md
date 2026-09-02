---
title: Cấu hình Thay thế Phông chữ trong Trình chiếu bằng Java
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
- trình chiếu
- Java
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Java khi render hoặc chuyển đổi các trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập được khi trình chiếu được render hoặc chuyển đổi. Việc thay thế chỉ ảnh hưởng tới đầu ra đã render; nó không thay đổi phông chữ được gán cho nội dung của trình chiếu.

Bạn có thể xác định phông chữ sẽ được sử dụng khi một phông chữ cụ thể không có sẵn, và có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì tính nhất quán của đầu ra trên các môi trường có các phông chữ được cài đặt khác nhau.

## **Lấy các phép thay thế phông chữ**

Sử dụng [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) để xác định các phông chữ sẽ được thay thế khi trình chiếu được render. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

Ví dụ Java sau liệt kê tất cả các phép thay thế phông chữ cho một trình chiếu:

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

## **Lấy các phép thay thế phông chữ cho các slide được chọn**

Sử dụng overload của [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với đối số `int[] slides` để kiểm tra chỉ các phép thay thế cần thiết cho việc render các slide cụ thể. Điều này hữu ích khi bạn render hoặc xuất một phần của trình chiếu, kiểm tra trình chiếu lớn một cách tăng dần, xác định các slide phụ thuộc vào phông chữ không có sẵn, chuẩn bị gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác nhau trong render mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide dựa trên số 1: `1` xác định slide đầu tiên. Ngược lại, bộ truy cập collection [Presentation.getSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlides--) sử dụng đánh số bắt đầu từ 0, vì vậy cùng một slide được truy cập bằng `presentation.getSlides().get_Item(0)`. Hãy nhớ sự khác nhau này khi xây dựng mảng để tránh lỗi lệch một.

Gọi overload thông qua phương thức [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getFontsManager--). Nó trả về chỉ các phép thay thế được xác định trong quá trình render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc fallback đã cấu hình, các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsubstrulecollection/), và [phông chữ được tải ngoại vi](/slides/vi/java/custom-font/).

Một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp khi bạn tạo danh mục phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mọi phép thay thế được trả về và sau đó tạo danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

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

Giao diện [IFontsManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/) cung cấp cả hai overload. Chọn một trong số chúng tùy theo phạm vi của hoạt động render:

| Overload | Khi nào nên sử dụng |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) không có đối số | Bạn cần các phép thay thế cho toàn bộ trình chiếu. |
| [getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với `int[] slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra tăng dần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi phông chữ nguồn không có sẵn:

1. Tải trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsubstrulecollection/).
5. Gán collection bằng cách sử dụng phương thức [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Render hoặc chuyển đổi trình chiếu.

Ví dụ Java sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không có sẵn, và sau đó render slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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
Đối với việc thay đổi không điều kiện toàn bộ phông chữ được sử dụng trong một trình chiếu, xem mục [Thay thế phông chữ](/slides/vi/java/font-replacement/).
{{% /alert %}}

## **Giới hạn đối với phông chữ công thức toán học**

Quy tắc thay thế phông chữ là một phần của quy trình chọn phông chữ tiêu chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động cho văn bản thông thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ có sẵn được quy tắc chỉ định.

Các công thức Office Math có yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần chính xác phông chữ đó để tính toán và render bố cục công thức. Quy tắc thay thế một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và quá trình render vẫn có thể báo rằng **Cambria Math** là bắt buộc.

Để render hoặc chuyển đổi trình chiếu như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ ngoại vi](/slides/vi/java/custom-font/).

Giới hạn này chỉ áp dụng cho bố cục công thức. Các quy tắc thay thế mô tả ở trên vẫn áp dụng cho văn bản thường trong trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa thay thế phông chữ và thay thế toàn bộ phông chữ là gì?**

[Font replacement](/slides/vi/java/font-replacement/) thay đổi có chủ đích một phông chữ thành phông chữ khác trên toàn bộ trình chiếu. Thay thế phông chữ chọn một phông chữ cho đầu ra đã render khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không có sẵn.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [chuỗi lựa chọn phông chữ](/slides/vi/java/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của mình. Kết quả phụ thuộc vào các phông chữ có trong môi trường runtime.

**Tôi có thể tải phông chữ ngoại vi để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ ngoại vi](/slides/vi/java/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có cung cấp phông chữ kèm theo thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy hệ điều hành, vì vậy một phông chữ có sẵn trên máy này có thể cần được thay thế trên máy khác.

**Làm sao để giữ cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp và phiên bản phông chữ trên mọi máy hoặc container, [tải các phông chữ ngoại vi cần thiết](/slides/vi/java/custom-font/), và [nhúng phông chữ](/slides/vi/java/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) trước khi xuất để xác định các phép thay thế không mong muốn.