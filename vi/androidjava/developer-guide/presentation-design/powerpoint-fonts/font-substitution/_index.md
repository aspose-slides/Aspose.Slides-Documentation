---
title: Cấu hình Thay thế Phông chữ trong Bản trình bày trên Android
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
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Android via Java khi hiển thị hoặc chuyển đổi bản trình bày."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập được khi bản trình bày được hiển thị hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã được hiển thị; nó không thay đổi phông chữ được gán cho nội dung bản trình bày.

Bạn có thể xác định phông chữ sẽ được sử dụng khi một phông chữ cụ thể không có sẵn, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình hiển thị. Điều này giúp duy trì độ nhất quán của đầu ra trên các thiết bị Android và môi trường có các phông chữ khả dụng khác nhau.

Nếu một phông chữ có sẵn nhưng không có dạng chữ đậm riêng, xem [Xử lý phông chữ không có dạng chữ đậm riêng](/slides/vi/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Phần đó giải thích cách raster hoá văn bản bị ảnh hưởng trong quá trình xuất PDF và các hậu quả đối với việc chọn văn bản, tìm kiếm và phóng to/thu nhỏ.

## **Lấy Các Phép Thay Thế Phông Chữ**

Sử dụng phương thức [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) để xác định các phông chữ nào sẽ được thay thế khi bản trình bày được hiển thị. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

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

## **Lấy Các Phép Thay Thế Phông Chữ cho Các Slide Đã Chọn**

Sử dụng phiên bản tải quá tải của [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với đối số `int[] slides` để kiểm tra chỉ các phép thay thế cần thiết cho việc hiển thị các slide cụ thể. Điều này hữu ích khi bạn đang hiển thị hoặc xuất một phần của bản trình bày, kiểm tra dần một bản trình bày lớn, xác định các slide phụ thuộc vào phông chữ không có sẵn, chuẩn bị một gói phông chữ tối thiểu cho ứng dụng Android, hoặc chẩn đoán sự khác biệt trong quá trình hiển thị mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide bắt đầu từ một: `1` xác định slide đầu tiên. Ngược lại, bộ truy cập bộ sưu tập [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) sử dụng chỉ mục bắt đầu từ không, vì vậy slide cùng đó được truy cập bằng `presentation.getSlides().get_Item(0)`. Hãy nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi phiên bản tải quá tải thông qua phương thức [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) . Nó chỉ trả về các phép thay thế được xác định trong quá trình hiển thị các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, các quy tắc thay thế được lưu trong một [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), và [phông chữ được tải ngoại vi](/slides/vi/androidjava/custom-font/).

Cùng một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo kiểm tra. Ví dụ sau báo cáo mọi phép thay thế được trả về và sau đó tạo một danh sách được sắp xếp của các ánh xạ phông chữ duy nhất:

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

Giao diện [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) cung cấp cả hai phiên bản tải quá tải. Chọn một trong số chúng tùy theo phạm vi của hoạt động hiển thị:

| Phiên bản tải quá tải | Sử dụng khi |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) với không có đối số | Bạn cần các phép thay thế cho toàn bộ bản trình bày. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) với `int[] slides` | Bạn cần các phép thay thế cho một dải đã chọn, kiểm tra dần, hoặc xuất một phần. |

## **Đặt Quy Tắc Thay Thế Phông Chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi phông chữ nguồn không có sẵn:

1. Tải bản trình bày.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập bằng cách sử dụng phương thức [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Hiển thị hoặc chuyển đổi bản trình bày.

Ví dụ Java sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không có sẵn, và sau đó hiển thị slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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
Để thay đổi không có điều kiện các phông chữ được sử dụng trong toàn bộ bản trình bày, xem [Thay Thế Phông Chữ](/slides/vi/androidjava/font-replacement/).
{{% /alert %}}

## **Hạn Chế Đối Với Phông Chữ Phương Trình Toán**

Các quy tắc thay thế phông chữ là một phần của quy trình chọn phông chữ tiêu chuẩn được sử dụng trong quá trình hiển thị và chuyển đổi. Chúng hoạt động cho văn bản thông thường khi Aspose.Slides có thể thay thế một phông chữ không thể truy cập bằng phông chữ có sẵn được chỉ định bởi quy tắc.

Các phương trình Office Math có yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và hiển thị bố cục phương trình. Quy tắc thay thế một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc hiển thị vẫn có thể báo rằng **Cambria Math** là bắt buộc.

Để hiển thị hoặc chuyển đổi bản trình bày như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Tải nó như một [phông chữ ngoại vi](/slides/vi/androidjava/custom-font/) để ứng dụng có thể sử dụng trong quá trình hiển thị và chuyển đổi.

Hạn chế này áp dụng cho bố cục phương trình. Các quy tắc thay thế đã mô tả ở trên vẫn áp dụng cho văn bản bình thường trong bản trình bày.

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa Thay Thế Phông Chữ và Thay Thế Phông Chữ (Font Substitution) là gì?**

[Thay Thế Phông Chữ](/slides/vi/androidjava/font-replacement/) cố ý thay đổi một phông chữ sang phông chữ khác trong toàn bộ bản trình bày. Thay thế phông chữ (font substitution) chọn một phông chữ cho đầu ra đã hiển thị khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không có sẵn.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [chuỗi lựa chọn phông chữ](/slides/vi/androidjava/font-selection-sequence/) trong quá trình hiển thị và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường thực thi.

**Tôi có thể tải phông chữ ngoại vi để tránh việc thay thế không?**

Có. Bạn có thể [tải phông chữ ngoại vi](/slides/vi/androidjava/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình hiển thị và chuyển đổi.

**Aspose có phân phối phông chữ kèm theo thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa các thiết bị Android không?**

Có. Các phông chữ hệ thống khả dụng có thể khác nhau giữa các phiên bản Android, thiết bị và nhà cung cấp, do đó một phông chữ có sẵn trong môi trường này có thể cần được thay thế trong môi trường khác.

**Làm thế nào để tôi có thể làm cho việc lựa chọn phông chữ nhất quán trên các thiết bị Android?**

Đóng gói cùng các tệp phông chữ cần thiết với ứng dụng, [tải chúng như phông chữ ngoại vi](/slides/vi/androidjava/custom-font/), và [nhúng phông chữ](/slides/vi/androidjava/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) trước khi xuất để xác định các phép thay thế không mong muốn.