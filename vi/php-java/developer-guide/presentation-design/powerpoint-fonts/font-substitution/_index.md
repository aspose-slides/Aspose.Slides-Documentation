---
title: Cấu hình Thay thế Phông chữ trong Bản trình chiếu sử dụng PHP
linktitle: Thay thế Phông chữ
type: docs
weight: 70
url: /vi/php-java/font-substitution/
keywords:
- phông chữ
- phông chữ thay thế
- sự thay thế phông chữ
- thay thế phông chữ
- thay thế phông chữ
- quy tắc thay thế
- quy tắc thay thế
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Cấu hình các quy tắc thay thế phông chữ và kiểm tra các phông chữ đã được thay thế trong Aspose.Slides cho PHP thông qua Java khi render hoặc chuyển đổi các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Thay thế phông chữ cho phép Aspose.Slides sử dụng một phông chữ có sẵn thay cho phông chữ không thể truy cập khi bản trình chiếu được render hoặc chuyển đổi. Việc thay thế ảnh hưởng đến đầu ra đã render; nó không thay đổi phông chữ được gán cho nội dung bản trình chiếu.

Bạn có thể xác định phông chữ sẽ sử dụng khi một phông chữ cụ thể không khả dụng, và bạn có thể kiểm tra các phép thay thế mà Aspose.Slides sẽ thực hiện trong quá trình render. Điều này giúp duy trì tính nhất quán của đầu ra trong các môi trường có các phông chữ được cài đặt khác nhau.

## **Lấy các phép thay thế phông chữ**

Sử dụng phương thức [FontsManager::getSubstitutions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getsubstitutions/) để xác định những phông chữ nào sẽ được thay thế khi bản trình chiếu được render. Phương thức trả về các đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsubstitutioninfo/) mô tả tên phông chữ gốc và phông chữ thay thế.

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

## **Lấy các phép thay thế phông chữ cho các slide đã chọn**

Sử dụng phương thức overload của [FontsManager::getSubstitutions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getsubstitutions/) có tham số `int[] slides` để kiểm tra chỉ các phép thay thế cần thiết cho việc render những slide cụ thể. Điều này hữu ích khi bạn render hoặc xuất một phần của bản trình chiếu, kiểm tra dần một bản trình chiếu lớn, xác định các slide phụ thuộc vào phông chữ không khả dụng, chuẩn bị một gói phông chữ tối thiểu cho máy chủ hoặc container, hoặc chẩn đoán sự khác biệt khi render mà không xử lý các slide không liên quan.

Mảng `slides` chứa các chỉ mục slide dựa trên số 1: `1` xác định slide đầu tiên. Ngược lại, bộ truy cập collection [Presentation::getSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlides) sử dụng chỉ mục bắt đầu từ 0, vì vậy cùng slide đó được truy cập bằng `$presentation->getSlides()->get_Item(0)`. Hãy nhớ sự khác biệt này khi xây dựng mảng để tránh lỗi lệch chỉ mục.

Gọi overload thông qua phương thức [Presentation::getFontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getFontsManager). Nó trả về chỉ các phép thay thế được xác định khi render các slide đã chọn. Mỗi kết quả là một đối tượng [FontSubstitutionInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsubstitutioninfo/) chứa tên phông chữ gốc và phông chữ thay thế. Kết quả phản ánh môi trường phông chữ hiện tại, các quy tắc fallback đã cấu hình, các quy tắc thay thế được lưu trong một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsubstrulecollection/), và [phông chữ được tải từ bên ngoài](/slides/vi/php-java/custom-font/).

Cùng một phép thay thế có thể được yêu cầu bởi nhiều slide đã chọn. Hãy loại bỏ trùng lặp kết quả khi bạn tạo kiểm kê phông chữ hoặc báo cáo preflight. Ví dụ sau báo cáo mỗi phép thay thế được trả về và sau đó tạo danh sách đã sắp xếp các ánh xạ phông chữ duy nhất:

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

Lớp [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/) cung cấp cả hai overload. Chọn một phương thức phù hợp với phạm vi của hoạt động render:

| Phương thức | Sử dụng khi |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getsubstitutions/) không có đối số | Bạn cần các phép thay thế cho toàn bộ bản trình chiếu. |
| [getSubstitutions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getsubstitutions/) với `int[] slides` | Bạn cần các phép thay thế cho một phạm vi đã chọn, kiểm tra dần, hoặc xuất một phần. |

## **Đặt quy tắc thay thế phông chữ**

Để chỉ định phông chữ mà Aspose.Slides nên sử dụng khi phông chữ nguồn không khả dụng:

1. Tải bản trình chiếu.
2. Tạo định nghĩa phông chữ cho phông nguồn và phông thay thế.
3. Tạo một [FontSubstRule](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsubstrule/) với điều kiện [WhenInaccessible](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsubstcondition/).
4. Thêm quy tắc vào một [FontSubstRuleCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsubstrulecollection/).
5. Gán bộ sưu tập bằng cách sử dụng phương thức [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Render hoặc chuyển đổi bản trình chiếu.

Ví dụ PHP sau thay thế `Arial` cho `SomeRareFont` khi `SomeRareFont` không khả dụng, sau đó render slide đầu tiên để xác minh kết quả. Phông chữ thay thế phải có sẵn cho Aspose.Slides.

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
Để thay đổi không điều kiện các phông chữ được sử dụng trong toàn bộ bản trình chiếu, xem [Font Replacement](/slides/vi/php-java/font-replacement/).
{{% /alert %}}

## **Hạn chế cho phông chữ công thức toán học**

Quy tắc thay thế phông chữ là một phần của quy trình lựa chọn phông chữ chuẩn được sử dụng trong quá trình render và chuyển đổi. Chúng hoạt động cho văn bản thường khi Aspose.Slides có thể thay thế một phông chữ không truy cập được bằng phông chữ khả dụng được chỉ định trong quy tắc.

Công thức Office Math có một yêu cầu bổ sung. Nếu một công thức sử dụng **Cambria Math**, Aspose.Slides có thể cần chính phông chữ đó để tính toán và render bố cục công thức. Một quy tắc thay thế bằng một phông chữ toán học khác, chẳng hạn **STIX Two Math**, không thể thay thế **Cambria Math** cho mục đích này, và việc render vẫn có thể báo cáo rằng **Cambria Math** là bắt buộc.

Để render hoặc chuyển đổi bản trình chiếu như vậy, hãy làm cho **Cambria Math** khả dụng với Aspose.Slides. Cài đặt nó trong hệ điều hành hoặc tải nó như một [phông chữ bên ngoài](/slides/vi/php-java/custom-font/).

Hạn chế này chỉ áp dụng cho bố cục công thức. Các quy tắc thay thế được mô tả ở trên vẫn áp dụng cho văn bản thông thường của bản trình chiếu.

## **Câu hỏi thường gặp**

**Sự khác biệt giữa thay thế phông chữ và thay thế phông chữ (substitution) là gì?**  
[Font replacement](/slides/vi/php-java/font-replacement/) thay đổi cố ý một phông chữ thành phông chữ khác trên toàn bộ bản trình chiếu. Thay thế phông chữ chọn một phông chữ cho đầu ra đã render khi điều kiện cấu hình được đáp ứng, chẳng hạn khi phông chữ gốc không khả dụng.

**Khi nào các quy tắc thay thế được áp dụng?**  
Các quy tắc tham gia vào [chuỗi lựa chọn phông chữ](/slides/vi/php-java/font-selection-sequence/) trong quá trình render và chuyển đổi. Với `WhenInaccessible`, quy tắc chỉ được sử dụng khi Aspose.Slides không thể truy cập phông chữ nguồn.

**Điều gì xảy ra khi một phông chữ thiếu và không có quy tắc thay thế nào được cấu hình?**  
Aspose.Slides sẽ chọn phông chữ khả dụng gần nhất theo quy trình lựa chọn phông chữ của nó. Kết quả phụ thuộc vào các phông chữ có sẵn trong môi trường runtime.

**Tôi có thể tải phông chữ bên ngoài để tránh việc thay thế không?**  
Có. Bạn có thể [tải phông chữ bên ngoài](/slides/vi/php-java/custom-font/) để Aspose.Slides có thể sử dụng chúng trong quá trình render và chuyển đổi.

**Aspose có phân phối phông chữ cùng với thư viện không?**  
Không. Bạn chịu trách nhiệm cung cấp phông chữ và tuân thủ các giấy phép của chúng.

**Kết quả thay thế có thể khác nhau giữa Windows, Linux và macOS không?**  
Có. Các phông chữ được cài đặt và vị trí tìm kiếm phông chữ khác nhau tùy theo hệ điều hành, vì vậy một phông chữ có sẵn trên máy này có thể cần được thay thế trên máy khác.

**Làm thế nào để làm cho việc lựa chọn phông chữ nhất quán trong các chuyển đổi hàng loạt?**  
Sử dụng cùng các tệp phông chữ và phiên bản trên mọi máy hoặc container, [tải phông chữ bên ngoài cần thiết](/slides/vi/php-java/custom-font/), và [nhúng phông chữ](/slides/vi/php-java/embedded-font/) khi giấy phép cho phép. Bạn cũng có thể gọi [FontsManager::getSubstitutions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/getsubstitutions/) trước khi xuất để xác định các phép thay thế không mong muốn.