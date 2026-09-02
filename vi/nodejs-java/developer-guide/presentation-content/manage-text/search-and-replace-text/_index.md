---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình bày PowerPoint bằng JavaScript
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/nodejs-java/search-and-replace-text/
keywords:
- tìm kiếm văn bản
- tô sáng văn bản
- thay thế văn bản
- biểu thức chính quy
- callback kết quả
- khung văn bản
- báo cáo audit
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm kiếm, tô sáng và thay thế văn bản trong các bản trình bày PowerPoint đồng thời thu thập mọi kết quả khớp bằng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java có thể tìm kiếm, tô sáng và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình bày. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mọi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bản trình bày đồng thời xây dựng một bản ghi audit chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc xem xét, xóa thông tin, kiểm tra thuật ngữ, dọn dẹp mẫu và các quy trình báo cáo tự động.

Trong các ví dụ đầu tiên bên dưới, chúng ta dùng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) để giới hạn thao tác vào một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bản trình bày.

| Thao tác | Một khung văn bản | Toàn bộ bản trình bày |
|---|---|---|
| Tô sáng văn bản nguyên mẫu | [TextFrame.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Tô sáng các khớp biểu thức chính quy | [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Thay thế văn bản nguyên mẫu | [TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Thay thế các khớp biểu thức chính quy | [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên mẫu, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/) để kiểm soát cách khớp:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) hạn chế các kết quả chỉ khớp với từ đầy đủ.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) điều khiển việc có yêu cầu phân biệt chữ hoa/chữ thường hay không.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và tô sáng ở mức bản trình bày.

Các thao tác biểu thức chính quy sử dụng một `Pattern` của Java, do đó các quy tắc khớp như phân biệt chữ hoa/chữ thường và ranh giới từ được xác định bởi biểu thức và các flag của nó.

## **Thu thập thông tin khớp với Callback**

Tạo một proxy Java cho callback kết quả để nhận thông báo cho mỗi khớp. Hàm proxy nhận khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Đoạn triển khai dưới đây suy ra số slide thông qua [TextFrame.getSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getSlideNumber--), và [NotesSlide.getParentSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Nó cũng xử lý văn bản được tìm thấy trong ghi chú slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Đối với các thao tác thay thế, `foundText` chứa văn bản khớp gốc, vì vậy callback có thể ghi lại chính xác những thuật ngữ đã được thay thế.

## **Tô sáng văn bản**

Sử dụng phương thức [TextFrame.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) để tô sáng các khớp văn bản nguyên mẫu trong một khung văn bản. Gửi [TextSearchOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/) để kiểm soát việc tìm kiếm.

Đoạn mã dưới đây tô sáng tất cả các lần xuất hiện của chuỗi **"try"** và sau đó chỉ tô sáng từ đầy đủ **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Tô sáng mọi lần xuất hiện của "try" trong khung văn bản.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Chỉ tô sáng từ đầy đủ "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản được tô sáng](highlighted_text.png)

## **Tô sáng văn bản bằng biểu thức chính quy**

Phương thức [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) tô sáng các khớp văn bản được tìm thấy bằng một biểu thức chính quy trong một khung văn bản.

Mã dưới đây tô sáng tất cả các từ có độ dài bảy ký tự trở lên:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản được tô sáng bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Tô sáng văn bản trên toàn bộ bản trình bày**

Sử dụng [Presentation.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [Presentation.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) để tìm kiếm tất cả các khung văn bản áp dụng trong bản trình bày. Ví dụ sau tô sáng một thuật ngữ nguyên mẫu và tất cả các địa chỉ email:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay thế văn bản trong một khung văn bản**

Sử dụng [TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) cho văn bản nguyên mẫu và [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ lại định dạng của các phần xung quanh thay vì tạo lại khung văn bản từ một chuỗi thuần.

Ví dụ dưới đây chuẩn hoá một biến thể chính tả rồi thay thế các nhãn phiên bản:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy xem lại đầu ra để xác định định dạng nào nên áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bản trình bày**

Sử dụng [Presentation.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [Presentation.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) để áp dụng cùng một thao tác trên toàn bộ bản trình bày. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và xóa thông tin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nhóm các khớp để báo cáo**

Vì mỗi kết quả thu thập được lưu trữ số slide và khung văn bản, ứng dụng có thể nhóm các khớp để audit, báo cáo hoặc quy trình xem xét. Ví dụ dưới đây nhóm kết quả đầu tiên theo slide rồi theo khung văn bản:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tìm kiếm chỉ trong một hộp văn bản thay vì toàn bộ bản trình bày?**

Lấy khung văn bản của hình dạng và gọi [TextFrame.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), hoặc [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) trên khung văn bản đó. Các phương thức ở mức bản trình bày sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao để khớp toàn bộ từ với ký tự viết hoa đúng?**

Đặt [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) và [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) thành `true`, và truyền các tùy chọn này cho phương thức tô sáng hoặc thay thế văn bản nguyên mẫu. Đối với biểu thức chính quy, định nghĩa ranh giới từ và phân biệt chữ hoa/chữ thường trong chính `Pattern` của Java.

**Tìm kiếm và thay thế có bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) thành `true` khi sử dụng thao tác văn bản nguyên mẫu ở mức bản trình bày. triển khai callback được trình bày ở trên sẽ ánh xạ một khớp trong ghi chú slide về số slide cha của nó.

**Làm sao tạo báo cáo mà không phải quét lại bản trình bày?**

Truyền một proxy callback kết quả Java cho thao tác tô sáng hoặc thay thế. Callback nhận mọi khớp trong khi thao tác đang chạy, do đó ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để sau này nhóm hoặc xuất ra.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ lại định dạng của phần xung quanh. Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo phần thay thế sử dụng kiểu mong muốn.