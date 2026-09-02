---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình chiếu PowerPoint bằng PHP
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/php-java/search-and-replace-text/
keywords:
- tìm kiếm văn bản
- làm nổi bật văn bản
- thay thế văn bản
- biểu thức chính quy
- callback kết quả
- khung văn bản
- báo cáo kiểm toán
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm kiếm, làm nổi bật và thay thế văn bản trong các bản trình chiếu PowerPoint đồng thời thu thập mọi kết quả khớp với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides for PHP via Java có thể tìm kiếm, làm nổi bật và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình chiếu. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mỗi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bản trình chiếu đồng thời xây dựng một nhật ký kiểm tra chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc rà soát, xóa thông tin nhạy cảm, kiểm tra thuật ngữ, dọn dẹp mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên dưới đây, chúng tôi sử dụng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) để giới hạn một thao tác cho một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để xử lý tất cả các văn bản áp dụng trong bản trình chiếu.

| Thao tác | Một khung văn bản | Toàn bộ bản trình chiếu |
|---|---|---|
| Đánh dấu văn bản nguyên văn | [TextFrame::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightText) |
| Đánh dấu các khớp biểu thức chính quy | [TextFrame::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightRegex) |
| Thay thế văn bản nguyên văn | [TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceText) |
| Thay thế các khớp biểu thức chính quy | [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceRegex) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên văn, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/) để kiểm soát việc khớp:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) giới hạn kết quả chỉ ở những từ hoàn chỉnh.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) kiểm soát việc có phải khớp chữ hoa/thường hay không.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và làm nổi bật ở mức bản trình chiếu.

Các thao tác biểu thức chính quy sử dụng một `Pattern` của Java, vì vậy các quy tắc khớp như phân biệt chữ hoa/thường và ranh giới từ được xác định bởi biểu thức và các cờ của nó.

## **Xác định chủ sở hữu của một khung văn bản**

Các quy trình xử lý văn bản chung thường nhận được một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) khi tìm kiếm, thay thế, xác thực hoặc xuất văn bản. Sử dụng [TextFrame::getParentShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentShape) và [TextFrame::getParentCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentCell) để xác định đối tượng trong bản trình chiếu sở hữu khung văn bản.

Các giá trị mong đợi phụ thuộc vào chủ sở hữu:

| Chủ sở hữu khung văn bản | `getParentShape` | `getParentCell` |
|---|---|---|
| Một AutoShape hoặc một hình dạng chứa văn bản khác | Đối tượng sở hữu [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) | `null` |
| Một ô trong bảng | `null` | Đối tượng sở hữu [Cell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/) |

Cả hai phương thức đều chỉ cung cấp điều hướng chỉ đọc. Gọi chúng không di chuyển khung văn bản hay thay đổi chủ sở hữu. Mã chung nên kiểm tra cả hai giá trị bằng `java_is_null` và xử lý khả năng không có bất kỳ chủ sở hữu nào.

Ví dụ sau sử dụng [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/#getAllTextFrames) để duyệt qua các khung văn bản trong một bản trình chiếu. Đối với các hình dạng, nó báo cáo tên hình dạng, kiểu runtime của Java và slide chứa. Đối với các ô bảng, nó báo cáo tọa độ cột và hàng (bắt đầu từ 0) và slide chứa.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Đối với nội dung SmartArt, duyệt qua các hình dạng trong [SmartArtNode::getShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnode/#getShapes) và truy cập mỗi [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartshape/#getTextFrame). Khung văn bản có thể được truy vết đến hình dạng liên quan thông qua [TextFrame::getParentShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentShape), trong khi [TextFrame::getParentCell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#getParentCell) trả về `null`. Do đó, nhánh hình dạng trong ví dụ cũng xử lý văn bản từ các nút SmartArt.

## **Thu thập thông tin khớp bằng Callback**

Truyền một callback proxy Java cho phương thức làm nổi bật hoặc thay thế để nhận thông báo cho mỗi khớp. Phương thức callback nhận khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Triển khai dưới đây suy ra số slide từ slide cha và cũng xử lý văn bản được tìm thấy trong ghi chú slide. Mảng kết quả sử dụng `null` khi văn bản liên kết với một loại slide khác.

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
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

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

Tạo một proxy cho đối tượng PHP này trước khi truyền vào một thao tác:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Đối với các thao tác thay thế, `foundText` chứa văn bản gốc đã khớp, vì vậy callback có thể ghi lại chính xác các thuật ngữ đã được thay thế.

## **Làm nổi bật văn bản**

Sử dụng phương thức [TextFrame::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightText) để làm nổi bật các khớp văn bản nguyên văn trong một khung văn bản. Truyền [TextSearchOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/) để kiểm soát việc tìm kiếm.

Ví dụ mã dưới đây làm nổi bật tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ làm nổi bật từ hoàn chỉnh **"to"**.

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

    // Làm nổi bật mọi lần xuất hiện của "try" trong khung văn bản.
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

    // Chỉ làm nổi bật từ hoàn chỉnh "to".
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

![Văn bản đã được làm nổi bật](highlighted_text.png)

## **Làm nổi bật văn bản bằng biểu thức chính quy**

Phương thức [TextFrame::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightRegex) làm nổi bật các khớp văn bản được tìm thấy bằng một biểu thức chính quy trong một khung văn bản.

Mã sau làm nổi bật tất cả các từ chứa bảy ký tự trở lên:

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

![Văn bản đã được làm nổi bật bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Làm nổi bật văn bản trên toàn bộ bản trình chiếu**

Sử dụng [Presentation::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightText) và [Presentation::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#highlightRegex) để tìm kiếm tất cả các khung văn bản áp dụng trong một bản trình chiếu. Ví dụ sau làm nổi bật một thuật ngữ nguyên văn và tất cả địa chỉ email:

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

Sử dụng [TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) cho văn bản nguyên văn và [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp bên trong khung văn bản hiện có, giữ nguyên định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ sau chuẩn hóa một biến thể chính tả và sau đó thay thế các nhãn phiên bản:

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

Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy xem lại đầu ra để xác nhận định dạng nào sẽ áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bản trình chiếu**

Sử dụng [Presentation::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceText) và [Presentation::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceRegex) để áp dụng cùng một thao tác trên toàn bộ bản trình chiếu. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và xóa thông tin nhạy cảm.

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

## **Nhóm các khớp cho báo cáo**

Vì mỗi kết quả lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các khớp để kiểm toán, báo cáo hoặc quy trình rà soát. Ví dụ sau nhóm các kết quả thu thập được đầu tiên theo slide và sau đó theo khung văn bản:

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

**Làm thế nào để tìm kiếm chỉ một hộp văn bản thay vì toàn bộ bản trình chiếu?**

Lấy khung văn bản của hình dạng và gọi [TextFrame::highlightText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) hoặc [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) trên khung văn bản đó. Các phương thức cấp độ Presentation xử lý tất cả các khung văn bản áp dụng.

**Làm thế nào để khớp các từ hoàn chỉnh với đúng chữ hoa?**

Đặt [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) và [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) thành `true`, và truyền các tùy chọn này cho phương thức làm nổi bật hoặc thay thế văn bản nguyên văn. Đối với biểu thức chính quy, định nghĩa ranh giới từ và phân biệt chữ hoa trong `Pattern` của Java.

**Tìm kiếm và thay thế có bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) thành `true` khi sử dụng một thao tác văn bản nguyên văn ở mức bản trình chiếu.

**Làm sao tạo báo cáo mà không quét lại bản trình chiếu một lần nữa?**

Truyền một callback proxy Java cho thao tác làm nổi bật hoặc thay thế. Nó sẽ nhận mỗi khớp trong khi thao tác đang chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để sau này nhóm hoặc xuất.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[TextFrame::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceText) và [TextFrame::replaceRegex](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/#replaceRegex) sửa đổi văn bản khớp bên trong khung văn bản hiện có và giữ lại định dạng phần xung quanh. Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng kiểu mong muốn.