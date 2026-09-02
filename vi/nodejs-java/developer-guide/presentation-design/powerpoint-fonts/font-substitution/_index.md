---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu bằng JavaScript
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/nodejs-java/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- thay thế phông chữ
- thay đổi phông chữ
- thay đổi phông chữ
- quy tắc thay thế
- quy tắc thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho Node.js thông qua Java khi kết xuất hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình chiếu được kết xuất hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã kết xuất; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể xác định phông chữ sẽ sử dụng khi một phông chữ cụ thể không khả dụng, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình kết xuất. Điều này giúp duy trì sự nhất quán của đầu ra trên các môi trường có các phông chữ đã cài đặt khác nhau.

## **Lấy các phép thay thế phông chữ**

Sử dụng phương thức [FontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) để xác định những phông chữ sẽ được thay thế khi bản trình chiếu được kết xuất. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsubstitutioninfo/) xác định tên phông chữ gốc và phông chữ thay thế.

Ví dụ JavaScript sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình chiếu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Lấy các phép thay thế phông chữ cho các slide đã chọn**

Sử dụng phương thức [FontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) quá tải với một mảng chỉ mục slide để kiểm tra chỉ các phép thay thế cần thiết cho việc kết xuất các slide cụ thể. Điều này hữu ích khi bạn đang kết xuất hoặc xuất khẩu một phần của bản trình chiếu, kiểm tra một bản trình chiếu lớn một cách tăng dần, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác nhau trong việc kết xuất mà không xử lý các slide không liên quan.

Quá tải này yêu cầu một kiểu nguyên thủy Java `int[]`. Tạo nó bằng `java.newArray("int", [...])`; một mảng JavaScript thuần sẽ được chuyển thành `Integer[]` và không khớp với quá tải này.

Mảng chứa các chỉ mục slide tính từ một: `1` xác định slide đầu tiên. Ngược lại, bộ truy cập bộ sưu tập [Presentation.getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslides/) sử dụng chỉ mục bắt đầu từ không, vì vậy slide đó được truy cập bằng `presentation.getSlides().get_Item(0)`. Hãy ghi nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi quá tải thông qua [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getfontsmanager/). Nó trả về chỉ các phép thay thế được xác định trong khi kết xuất các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, các quy tắc thay thế được lưu trong một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsubstrulecollection/), và [phông chữ được tải bên ngoài](/slides/vi/nodejs-java/custom-font/).

Một phép thay thế giống nhau có thể được yêu cầu bởi hơn một slide đã chọn. Hãy loại bỏ trùng lặp các kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mỗi phép thay thế được trả về và sau đó tạo một danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

Lớp [FontsManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/) cung cấp cả hai quá tải. Chọn một trong số chúng tùy theo phạm vi của hoạt động kết xuất:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [getSubstitutions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra tăng dần, hoặc xuất một phần. |

## **Thiết lập quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập bằng cách sử dụng phương thức [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Kết xuất hoặc chuyển đổi bản trình chiếu.

Ví dụ JavaScript sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, và sau đó kết xuất slide đầu tiên để xác nhận kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Để thay đổi không có điều kiện các phông chữ được sử dụng trong toàn bộ bản trình chiếu, xem [Font Replacement](/slides/vi/nodejs-java/font-replacement/).
{{% /alert %}}

## **Giới hạn đối với phông chữ phương trình toán học**

Các quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ chuẩn được sử dụng trong quá trình kết xuất và chuyển đổi. Chúng hoạt động cho văn bản thông thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ khả dụng đã chỉ định trong quy tắc.

Các phương trình Office Math có yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và kết xuất bố cục phương trình. Một quy tắc thay thế bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc kết xuất vẫn có thể báo rằng **Cambria Math** là bắt buộc.

Để kết xuất hoặc chuyển đổi bản trình chiếu như vậy, hãy làm cho **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ bên ngoài](/slides/vi/nodejs-java/custom-font/).

Giới hạn này áp dụng cho bố cục phương trình. Các quy tắc thay thế mô tả ở trên vẫn áp dụng cho văn bản thông thường trong bản trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa thay thế phông chữ và thay thế phông chữ tạm thời là gì?**

[Font replacement](/slides/vi/nodejs-java/font-replacement/) thay đổi có chủ đích một phông chữ thành một phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ (font substitution) chọn một phông chữ cho đầu ra đã kết xuất khi điều kiện được cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [font selection sequence](/slides/vi/nodejs-java/font-selection-sequence/) trong quá trình kết xuất và chuyển đổi. Với `WhenInaccessible`, quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Đi gì sẽ xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**

Có. Bạn có thể [load external fonts](/slides/vi/nodejs-java/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình kết xuất và chuyển đổi.

**Aspose có phân phối phông chữ đi kèm với thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau theo hệ điều hành, vì vậy một phông chữ có sẵn trên máy này có thể yêu cầu thay thế trên máy khác.

**Làm thế nào để tôi có thể đồng nhất việc chọn phông chữ trong các chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [load required external fonts](/slides/vi/nodejs-java/custom-font/), và [embed fonts](/slides/vi/nodejs-java/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [FontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.