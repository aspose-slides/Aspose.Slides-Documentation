---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu trên Android
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Android bằng Java khi hiển thị hoặc chuyển đổi bản trình chiếu."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập được khi một bản trình chiếu được hiển thị hoặc chuyển đổi. Việc thay thế ảnh hưởng đến kết quả hiển thị; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể định nghĩa phông chữ sẽ dùng khi một phông chữ cụ thể không có, và có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình hiển thị. Điều này giúp duy trì kết quả nhất quán trên các thiết bị Android và môi trường có các phông chữ khả dụng khác nhau.

## **Lấy Thay Thế Phông Chữ**

Sử dụng phương thức [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) để xác định các phông chữ nào sẽ được thay thế khi bản trình chiếu được hiển thị. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

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

## **Lấy Thay Thế Phông Chữ cho Các Slide Được Chọn**

Sử dụng phương thức [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) có tham số `int[] slides` để kiểm tra chỉ những phép thay thế cần thiết cho các slide cụ thể. Điều này hữu ích khi bạn đang hiển thị hoặc xuất một phần của bản trình chiếu, kiểm tra dần dần một bản trình chiếu lớn, xác định các slide phụ thuộc vào phông chữ không có, chuẩn bị một gói phông chữ tối thiểu cho ứng dụng Android, hoặc chẩn đoán sự khác biệt về hiển thị mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide bắt đầu từ 1: `1` là slide đầu tiên. Ngược lại, bộ truy cập collection [Presentation.getSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlides--) sử dụng chỉ mục bắt đầu từ 0, vì vậy slide tương tự được truy cập bằng `presentation.getSlides().get_Item(0)`. Hãy nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi phương thức này thông qua [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getFontsManager--) . Nó trả về chỉ các phép thay thế được xác định khi hiển thị các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsubstrulecollection/), và [phông chữ tải ngoài](/slides/vi/androidjava/custom-font/).

Một phép thay thế có thể cần cho hơn một slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo kiểm tra. Ví dụ sau báo cáo mọi phép thay thế được trả về và sau đó tạo danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

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

Giao diện [IFontsManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/) cung cấp cả hai phương thức quá tải. Chọn một trong số chúng tùy theo phạm vi của thao tác hiển thị:

| Phương thức | Khi nào sử dụng |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) không có tham số | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [getSubstitutions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với `int[] slides` | Bạn cần các phép thay thế cho một phạm vi được chọn, kiểm tra dần dần, hoặc xuất một phần. |

## **Đặt Quy Tắc Thay Thế Phông Chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi một phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông nguồn và phông thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Gán collection bằng cách sử dụng phương thức [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Hiển thị hoặc chuyển đổi bản trình chiếu.

Ví dụ Java sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, sau đó hiển thị slide đầu tiên để kiểm tra kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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
Đối với việc thay đổi không điều kiện toàn bộ phông chữ được dùng trong một bản trình chiếu, xem mục [Font Replacement](/slides/vi/androidjava/font-replacement/).
{{% /alert %}}

## **Giới Hạn Đối Với Phông Chữ Phương Trình Toán Học**

Quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình hiển thị và chuyển đổi. Chúng hoạt động cho văn bản thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ khả dụng được quy tắc chỉ định.

Các phương trình Office Math có một yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần chính xác phông chữ này để tính toán và hiển thị bố cục phương trình. Một quy tắc thay thế bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc hiển thị vẫn có thể báo cáo rằng **Cambria Math** là bắt buộc.

Để hiển thị hoặc chuyển đổi bản trình chiếu như vậy, hãy cung cấp **Cambria Math** cho Aspose.Slides. Tải nó như một [phông chữ tải ngoài](/slides/vi/androidjava/custom-font/) để ứng dụng có thể sử dụng trong quá trình hiển thị và chuyển đổi.

Giới hạn này chỉ áp dụng cho bố cục phương trình. Các quy tắc thay thế mô tả ở trên vẫn áp dụng cho văn bản thường trong bản trình chiếu.

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa thay thế phông chữ và thay đổi phông chữ là gì?**

[Font replacement](/slides/vi/androidjava/font-replacement/) thay đổi có chủ đích một phông chữ thành phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho kết quả hiển thị khi đáp ứng điều kiện cấu hình, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/androidjava/font-selection-sequence/) trong quá trình hiển thị và chuyển đổi. Với `WhenInaccessible`, quy tắc chỉ được dùng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ ngoài để tránh việc thay thế không?**

Có. Bạn có thể [load external fonts](/slides/vi/androidjava/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình hiển thị và chuyển đổi.

**Aspose có phân phối phông chữ cùng với thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa các thiết bị Android không?**

Có. Các phông chữ hệ thống khả dụng có thể khác nhau giữa các phiên bản Android, thiết bị và nhà sản xuất, vì vậy một phông chữ có sẵn ở môi trường này có thể cần được thay thế ở môi trường khác.

**Làm sao để làm cho việc lựa chọn phông chữ nhất quán trên các thiết bị Android?**

Đóng gói cùng một bộ phông chữ yêu cầu với ứng dụng, [load chúng như phông chữ tải ngoài](/slides/vi/androidjava/custom-font/), và [embed fonts](/slides/vi/androidjava/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) trước khi xuất để xác định các phép thay thế không mong muốn.