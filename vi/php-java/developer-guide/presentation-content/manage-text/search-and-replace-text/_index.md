---
title: Tìm kiếm và Thay thế Văn bản trong các bài thuyết trình PowerPoint bằng PHP
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/php-java/search-and-replace-text/
keywords:
- tìm kiếm văn bản
- đánh dấu văn bản
- thay thế văn bản
- biểu thức chính quy
- callback kết quả
- khung văn bản
- báo cáo kiểm toán
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm kiếm, đánh dấu và thay thế văn bản trong các bài thuyết trình PowerPoint đồng thời thu thập mọi kết quả khớp bằng Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides for PHP via Java có thể tìm kiếm, đánh dấu và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bài thuyết trình. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mọi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bài thuyết trình và đồng thời xây dựng một dấu vết kiểm toán chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc xem xét, xóa thông tin, kiểm tra thuật ngữ, dọn dẹp mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên dưới đây, chúng tôi sử dụng một tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) để giới hạn một thao tác trong một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bài thuyết trình.

| Hoạt động | Một khung văn bản | Toàn bộ bài thuyết trình |
|---|---|---|
| Đánh dấu văn bản nguyên bản | [TextFrame::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightText) |
| Đánh dấu các kết quả khớp biểu thức chính quy | [TextFrame::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightRegex) |
| Thay thế văn bản nguyên bản | [TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceText) |
| Thay thế các kết quả khớp biểu thức chính quy | [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceRegex) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên bản, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/) để điều khiển việc khớp:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) giới hạn các kết quả khớp chỉ với các từ hoàn chỉnh.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) điều khiển việc có cần khớp đúng kiểu chữ hay không.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và đánh dấu ở cấp độ bài thuyết trình.

Các thao tác biểu thức chính quy sử dụng một `Pattern` của Java, vì vậy các quy tắc khớp như độ nhạy cảm với kiểu chữ và ranh giới từ được xác định bởi biểu thức và các cờ của nó.

## **Thu thập thông tin khớp với Callback**

Gửi một callback proxy Java tới phương pháp đánh dấu hoặc thay thế để nhận thông báo cho mỗi kết quả khớp. Phương thức callback nhận khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Triển khai dưới đây suy ra nó từ slide cha và cũng xử lý văn bản được tìm thấy trong ghi chú slide. Mảng kết quả sử dụng `null` khi văn bản được liên kết với loại slide khác.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentSlide = $textFrame->getSlide();
        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Tạo một proxy cho đối tượng PHP này trước khi truyền nó vào một thao tác:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Đối với các thao tác thay thế, `foundText` chứa văn bản khớp gốc, vì vậy callback có thể ghi lại chính xác các thuật ngữ đã được thay thế.

## **Đánh dấu văn bản**

Sử dụng phương thức [TextFrame::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightText) để đánh dấu các kết quả khớp văn bản nguyên bản trong một khung văn bản. Truyền [TextSearchOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/) để điều khiển việc tìm kiếm.

Ví dụ mã dưới đây đánh dấu mọi lần xuất hiện của các ký tự **"try"** và sau đó chỉ đánh dấu từ hoàn chỉnh **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Đánh dấu mọi lần xuất hiện của "try" trong khung văn bản.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Đánh dấu chỉ từ hoàn chỉnh "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Kết quả:

![Văn bản đã được đánh dấu](highlighted_text.png)

## **Đánh dấu văn bản bằng biểu thức chính quy**

Phương thức [TextFrame::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightRegex) đánh dấu các kết quả khớp văn bản được tìm thấy bởi một biểu thức chính quy trong một khung văn bản.

Mã sau đây đánh dấu tất cả các từ chứa bảy ký tự trở lên:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Kết quả:

![Văn bản đã được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đánh dấu văn bản trên toàn bộ bài thuyết trình**

Sử dụng [Presentation::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightText) và [Presentation::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightRegex) để tìm kiếm tất cả các khung văn bản áp dụng trong một bài thuyết trình. Ví dụ sau đây đánh dấu một thuật ngữ nguyên bản và tất cả địa chỉ email:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Thay thế văn bản trong một khung văn bản**

Sử dụng [TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) cho văn bản nguyên bản và [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ nguyên định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ sau chuẩn hoá một biến thể chính tả và sau đó thay thế các nhãn phiên bản:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy xem lại kết quả để xác định định dạng nào nên áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bài thuyết trình**

Sử dụng [Presentation::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceText) và [Presentation::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceRegex) để áp dụng cùng các thao tác trên toàn bộ bài thuyết trình. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và xóa thông tin.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Nhóm các kết quả khớp cho báo cáo**

Vì mỗi kết quả đều lưu số slide và khung văn bản, các ứng dụng có thể nhóm các kết quả khớp cho kiểm toán, báo cáo hoặc quy trình xem xét. Ví dụ dưới đây nhóm các kết quả đã thu thập trước tiên theo slide, sau đó theo khung văn bản:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể tìm kiếm chỉ trong một hộp văn bản thay vì toàn bộ bài thuyết trình?**

Lấy khung văn bản của hình dạng và gọi [TextFrame::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) hoặc [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) trên khung văn bản đó. Các phương thức ở cấp độ bài thuyết trình sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao tôi có thể khớp toàn bộ từ với việc viết hoa đúng?**

Đặt [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) và [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) thành `true`, và truyền các tùy chọn này vào phương pháp đánh dấu hoặc thay thế văn bản nguyên bản. Đối với biểu thức chính quy, xác định ranh giới từ và độ nhạy cảm với kiểu chữ trong `Pattern` của Java.

**Việc tìm kiếm và thay thế có thể bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) thành `true` khi sử dụng thao tác văn bản nguyên bản ở cấp độ bài thuyết trình.

**Làm sao tôi có thể tạo báo cáo mà không cần quét lại bài thuyết trình lần thứ hai?**

Gửi một callback proxy Java tới thao tác đánh dấu hoặc thay thế. Callback nhận mọi kết quả khớp trong khi thao tác đang chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để nhóm hoặc xuất ra sau.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) và [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ lại định dạng của phần xung quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng kiểu định dạng mong muốn.