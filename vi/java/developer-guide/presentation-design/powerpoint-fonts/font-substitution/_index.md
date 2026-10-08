---
title: Cấu hình Thay thế Phông chữ trong Bản trình bày bằng Java
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/java/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay thế
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Java khi render hoặc chuyển đổi bản trình bày PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình bày được render hoặc chuyển đổi. Việc thay thế chỉ ảnh hưởng tới kết quả đã render; nó không thay đổi phông chữ được gán cho nội dung bản trình bày.

Bạn có thể xác định phông chữ sẽ dùng khi một phông chữ cụ thể không có, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì kết quả nhất quán giữa các môi trường có các phông chữ được cài đặt khác nhau.

Nếu một phông chữ có sẵn nhưng không có kiểu chữ in đậm riêng, xem [Xử lý phông chữ không có kiểu chữ in đậm riêng](/slides/vi/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Phần đó giải thích cách raster hoá văn bản bị ảnh hưởng trong quá trình xuất PDF và các hệ quả đối với việc chọn văn bản, tìm kiếm và phóng to/thu nhỏ.

## **Lấy các phép thay thế phông chữ**

Sử dụng phương thức [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) để xác định các phông chữ nào sẽ được thay thế khi bản trình bày được render. Phương thức này trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

Ví dụ Java sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình bày:

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

Bạn có thể sử dụng phiên bản overload của [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với đối số `int[] slides` để chỉ kiểm tra các phép thay thế cần thiết cho việc render các slide cụ thể. Điều này hữu ích khi bạn đang render hoặc xuất một phần của bản trình bày, kiểm tra dần một bản trình bày lớn, xác định các slide phụ thuộc vào phông chữ không có, chuẩn bị gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong render mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide tính từ 1: `1` xác định slide đầu tiên. Ngược lại, phương thức truy cập bộ sưu tập [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) sử dụng chỉ mục bắt đầu từ 0, vì vậy slide tương tự được truy cập bằng `presentation.getSlides().get_Item(0)`. Hãy lưu ý sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi overload này thông qua phương thức [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--). Nó trả về chỉ các phép thay thế đã xác định trong quá trình render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng được cấu hình, và [các phông chữ được tải ngoại vi](/slides/vi/java/custom-font/). Các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) sẽ được áp dụng khi bản trình bày được render, nhưng kết quả không liệt kê chúng; hãy kiểm tra các phông chữ trong tệp đầu ra thay thế.

Cùng một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mọi phép thay thế đã trả về và sau đó tạo danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

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

Giao diện [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) cung cấp cả hai overload. Chọn một trong chúng tùy thuộc vào phạm vi của thao tác render:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Bạn cần các phép thay thế cho toàn bộ bản trình bày. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra dần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi phông chữ nguồn không có:

1. Tải bản trình bày.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập bằng cách sử dụng phương thức [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Render hoặc chuyển đổi bản trình bày.

Ví dụ Java sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không có, và sau đó render slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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
Để thay đổi không có điều kiện các phông chữ được sử dụng trong toàn bộ bản trình bày, xem [Thay thế phông chữ](/slides/vi/java/font-replacement/).
{{% /alert %}}

## **Hạn chế đối với phông chữ công thức toán học**

Quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ tiêu chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động cho văn bản thông thường khi Aspose.Slides có thể thay thế phông chữ không truy cập được bằng phông chữ khả dụng được chỉ định bởi quy tắc.

Các phương trình Office Math có yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và render bố cục phương trình. Quy tắc thay thế một phông chữ toán khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và quá trình render vẫn có thể báo cáo rằng cần **Cambria Math**.

Để render hoặc chuyển đổi bản trình bày như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ ngoại vi](/slides/vi/java/custom-font/).

Giới hạn này áp dụng cho bố cục phương trình. Các quy tắc thay thế đã mô tả ở trên vẫn áp dụng cho văn bản thông thường của bản trình bày.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa việc thay thế phông chữ và việc thay thế phông chữ tạm thời là gì?**

[Thay thế phông chữ](/slides/vi/java/font-replacement/) cố ý thay đổi một phông chữ thành phông chữ khác trên toàn bộ bản trình bày. Thay thế phông chữ chọn một phông chữ cho kết quả render khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [chuỗi lựa chọn phông chữ](/slides/vi/java/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ gần nhất có sẵn theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ ngoại vi để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ ngoại vi](/slides/vi/java/custom-font/) để Aspose.Slides sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có phân phối phông chữ kèm theo thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ được cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy theo hệ điều hành, vì vậy một phông chữ có sẵn trên một máy có thể cần được thay thế trên máy khác.

**Làm thế nào để làm cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [tải các phông chữ ngoại vi cần thiết](/slides/vi/java/custom-font/), và [nhúng phông chữ](/slides/vi/java/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) trước khi xuất để xác định các phép thay thế không mong muốn.