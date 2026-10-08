---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu bằng PHP
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/php-java/font-substitution/
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
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho PHP qua Java khi kết xuất hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn để thay cho phông chữ không thể truy cập được khi bản trình chiếu được kết xuất hoặc chuyển đổi. Việc thay thế ảnh hưởng tới đầu ra đã được kết xuất; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể định nghĩa phông chữ sẽ dùng khi một phông chữ nhất định không khả dụng, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình kết xuất. Điều này giúp duy trì tính nhất quán của đầu ra trên các môi trường có các phông chữ đã cài đặt khác nhau.

Nếu một phông chữ có sẵn nhưng không có dạng in đậm riêng, xem [Xử lý phông chữ không có dạng in đậm riêng](/slides/vi/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Phần đó giải thích cách raster hoá văn bản bị ảnh hưởng trong quá trình xuất PDF và các hậu quả đối với việc chọn văn bản, tìm kiếm và thu phóng.

## **Lấy Thay Thế Phông Chữ**

Sử dụng phương thức [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) để xác định những phông chữ nào sẽ được thay thế khi bản trình chiếu được kết xuất. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

Ví dụ PHP sau liệt kê tất cả các phép thay thế phông chữ cho một bản trình chiếu:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Lấy Thay Thế Phông Chữ cho Các Slide Được Chọn**

Sử dụng phiên bản overload của [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) với đối số `int[] slides` để kiểm tra chỉ những phép thay thế cần thiết cho việc kết xuất các slide cụ thể. Điều này hữu ích khi bạn đang kết xuất hoặc xuất phần của bản trình chiếu, kiểm tra dần dần một bản trình chiếu lớn, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt trong việc kết xuất mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide tính từ một: `1` xác định slide đầu tiên. Ngược lại, bộ truy cập tập hợp [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) sử dụng chỉ số bắt đầu từ zero, vì vậy cùng một slide được truy cập bằng `$presentation->getSlides()->get_Item(0)`. Hãy ghi nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch một.

Gọi overload thông qua phương thức [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/). Nó trả về chỉ các phép thay thế được xác định trong quá trình kết xuất các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc dự phòng đã cấu hình, các quy tắc thay thế được lưu trong một [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) và [các phông chữ được tải bên ngoài](/slides/vi/php-java/custom-font/).

Cùng một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo danh mục phông chữ hoặc báo cáo kiểm tra trước. Ví dụ sau báo cáo mọi phép thay thế được trả về và sau đó tạo danh sách đã sắp xếp của các ánh xạ phông chữ duy nhất:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Lớp [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) cung cấp cả hai overload. Chọn một trong số chúng tùy theo phạm vi của thao tác kết xuất:

| Phiên bản overload | Sử dụng khi |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra gia tăng, hoặc xuất một phần. |

## **Đặt Quy Tắc Thay Thế Phông Chữ**

Để chỉ định phông chữ mà Aspose.Slides sẽ sử dụng khi phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông chữ nguồn và phông chữ thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập bằng cách sử dụng phương thức [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Kết xuất hoặc chuyển đổi bản trình chiếu.

Ví dụ PHP sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, và sau đó kết xuất slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Để thay đổi không có điều kiện các phông chữ được sử dụng trong toàn bộ bản trình chiếu, xem [Thay Thế Phông Chữ](/slides/vi/php-java/font-replacement/).
{{% /alert %}}

## **Hạn Chế cho Phông Chữ Phương Trình Toán**

Quy tắc thay thế phông chữ là một phần của quy trình chọn phông chữ tiêu chuẩn được sử dụng trong quá trình kết xuất và chuyển đổi. Chúng hoạt động cho văn bản thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ có sẵn được chỉ định bởi một quy tắc.

Các phương trình Office Math có một yêu cầu bổ sung. Nếu một phương trình sử dụng **Cambria Math**, Aspose.Slides có thể cần phông chữ chính xác đó để tính toán và kết xuất bố cục phương trình. Một quy tắc thay thế bằng một phông chữ toán khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc kết xuất vẫn có thể báo rằng **Cambria Math** là bắt buộc.

Để kết xuất hoặc chuyển đổi bản trình chiếu như vậy, hãy đảm bảo **Cambria Math** có sẵn cho Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó dưới dạng [phông chữ bên ngoài](/slides/vi/php-java/custom-font/).

Hạn chế này áp dụng cho bố cục phương trình. Các quy tắc thay thế đã mô tả ở trên vẫn áp dụng cho văn bản bình thường của bản trình chiếu.

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa Font Replacement và Font Substitution là gì?**

[Thay Thế Phông Chữ](/slides/vi/php-java/font-replacement/) cố ý thay đổi một phông chữ thành phông chữ khác trong toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho đầu ra đã được kết xuất khi điều kiện đã cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**

Các quy tắc tham gia vào [dãy lựa chọn phông chữ](/slides/vi/php-java/font-selection-sequence/) trong quá trình kết xuất và chuyển đổi. Với `WhenInaccessible`, một quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ bị thiếu và không có quy tắc thay thế nào được cấu hình?**

Aspose.Slides chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường thực thi.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**

Vâng. Bạn có thể [tải phông chữ bên ngoài](/slides/vi/php-java/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình kết xuất và chuyển đổi.

**Aspose có phân phối phông chữ kèm theo thư viện không?**

Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**

Có. Các phông chữ đã cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy theo hệ điều hành, vì vậy một phông chữ có sẵn trên một máy có thể cần được thay thế trên máy khác.

**Làm thế nào để tôi làm cho việc lựa chọn phông chữ nhất quán trong các lần chuyển đổi hàng loạt?**

Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [tải phông chữ bên ngoài cần thiết](/slides/vi/php-java/custom-font/), và [nhúng phông chữ](/slides/vi/php-java/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) trước khi xuất để xác định các phép thay thế bất ngờ.