---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình chiếu PowerPoint bằng JavaScript
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/nodejs-java/search-and-replace-text/
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm kiếm, đánh dấu và thay thế văn bản trong các bản trình chiếu PowerPoint trong khi thu thập mọi kết quả khớp bằng Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Aspose.Slides cho Node.js thông qua Java có thể tìm kiếm, đánh dấu và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình bày. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mọi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bản trình bày và đồng thời tạo một bản ghi kiểm toán chứa văn bản đã khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc xem xét, gỡ bỏ, kiểm tra thuật ngữ, dọn dẹp mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên dưới đây, chúng tôi sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) để giới hạn một thao tác chỉ trên một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bản trình bày.

| Thao tác | Một khung văn bản | Toàn bộ bản trình bày |
|---|---|---|
| Đánh dấu văn bản thuần | [TextFrame.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Đánh dấu các khớp biểu thức chính quy | [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Thay thế văn bản thuần | [TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Thay thế các khớp biểu thức chính quy | [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản thuần, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/) để điều khiển việc khớp:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) giới hạn kết quả khớp chỉ về các từ hoàn chỉnh.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kiểm soát việc có phải khớp chữ hoa/thường hay không.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và đánh dấu ở cấp độ bản trình bày.

Các thao tác biểu thức chính quy sử dụng một `Pattern` của Java, do đó các quy tắc khớp như phân biệt chữ hoa/thường và ranh giới từ được định nghĩa bởi biểu thức và các cờ của nó.

## **Xác định chủ sở hữu của một khung văn bản**

Trong các quy trình xử lý văn bản chung, thường nhận được một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) khi tìm kiếm, thay thế, xác thực hoặc xuất văn bản. Sử dụng [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentShape--) và [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentCell--) để xác định đối tượng bản trình bày nào sở hữu khung văn bản.

Giá trị mong đợi phụ thuộc vào chủ sở hữu:

| Chủ sở hữu khung văn bản | `getParentShape` | `getParentCell` |
|---|---|---|
| Một AutoShape hoặc một hình dạng chứa văn bản khác | The owning [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) | `null` |
| Một ô bảng | `null` | The owning [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/) |

Cả hai phương thức đều cung cấp điều hướng chỉ đọc. Gọi chúng không di chuyển khung văn bản hay thay đổi chủ sở hữu. Mã chung nên kiểm tra cả hai giá trị xem có `null` không và xử lý khả năng không có bất kỳ chủ sở hữu nào.

Ví dụ sau sử dụng [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) để lặp qua các khung văn bản trong một bản trình bày. Đối với các hình dạng, nó báo cáo tên hình dạng, loại runtime Java và slide chứa. Đối với các ô bảng, nó báo cáo tọa độ cột và hàng dựa trên chỉ số 0 và slide chứa.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Đối với nội dung SmartArt, lặp qua các hình dạng trong [SmartArtNode.getShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartnode/#getShapes--) và truy cập mỗi [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Khung văn bản có thể được truy xuất tới hình dạng liên quan thông qua [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentShape--), trong khi [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getParentCell--) trả về `null`. Do đó, nhánh hình dạng trong ví dụ cũng xử lý văn bản từ các nút SmartArt.

## **Thu thập thông tin khớp với Callback**

Tạo một proxy Java cho callback kết quả để nhận thông báo về mỗi kết quả khớp. Hàm proxy nhận khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Triển khai bên dưới suy ra nó thông qua hình dạng hoặc ô bảng sở hữu khung văn bản, với [TextFrame.getSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#getSlide--) làm phương án dự phòng. Nó cũng xử lý văn bản được tìm thấy trong ghi chú slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

Đối với các thao tác thay thế, `foundText` chứa văn bản gốc đã khớp, vì vậy callback có thể ghi lại chính xác những thuật ngữ đã được thay thế.

## **Đánh dấu Văn bản**

Sử dụng phương pháp [TextFrame.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) để đánh dấu các khớp văn bản thuần trong một khung văn bản. Đưa [TextSearchOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/) vào để điều khiển việc tìm kiếm.

Ví dụ mã dưới đây đánh dấu tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ đánh dấu toàn bộ từ **"to"**.

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

    // Đánh dấu mọi lần xuất hiện của "try" trong khung văn bản.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Đánh dấu chỉ từ hoàn chỉnh "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản đã được đánh dấu](highlighted_text.png)

## **Đánh dấu Văn bản bằng Biểu thức Chính quy**

Phương pháp [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) đánh dấu các khớp văn bản được tìm thấy bằng biểu thức chính quy trong một khung văn bản.

Mã dưới đây đánh dấu tất cả các từ chứa bảy ký tự trở lên:

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

![Văn bản đã được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đánh dấu Văn bản trên Toàn bộ Bản trình bày**

Sử dụng [Presentation.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [Presentation.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) để tìm kiếm tất cả các khung văn bản áp dụng trong một bản trình bày. Ví dụ dưới đây đánh dấu một thuật ngữ thuần và tất cả địa chỉ email:

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

## **Thay thế Văn bản trong Khung Văn bản**

Sử dụng [TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) cho văn bản thuần và [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) cho việc thay thế dựa trên mẫu. Các phương pháp này cập nhật văn bản đã khớp trong khung văn bản hiện có, giữ định dạng của phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ dưới đây chuẩn hóa một biến thể chính tả và sau đó thay thế các nhãn phiên bản:

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

Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy xem lại kết quả để xác nhận định dạng nào nên áp dụng cho văn bản thay thế.

## **Thay thế Văn bản trên Toàn bộ Bản trình bày**

Sử dụng [Presentation.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [Presentation.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) để áp dụng các thao tác tương tự trên toàn bộ bản trình bày. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và gỡ bỏ thông tin.

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

## **Nhóm các Kết quả Khớp cho Báo cáo**

Vì mỗi kết quả thu thập được lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các kết quả cho việc kiểm toán, báo cáo hoặc quy trình xem xét. Ví dụ dưới đây nhóm các kết quả trước tiên theo slide và sau đó theo khung văn bản:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

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

**Làm sao tôi có thể tìm kiếm chỉ trong một hộp văn bản thay vì toàn bộ bản trình bày?**

Lấy khung văn bản của hình dạng và gọi [TextFrame.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) hoặc [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) trên khung văn bản đó. Các phương pháp ở cấp độ Presentation sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao tôi có thể khớp các từ hoàn chỉnh với đúng cách viết hoa?**

Đặt [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) và [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) thành `true`, và truyền các tùy chọn vào phương pháp đánh dấu hoặc thay thế văn bản thuần. Đối với biểu thức chính quy, định nghĩa ranh giới từ và phân biệt chữ hoa/thường trong `Pattern` của Java.

**Tìm kiếm và thay thế có thể bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) thành `true` khi sử dụng thao tác văn bản thuần ở cấp độ presentation. Triển khai callback ở trên ánh xạ khớp trong slide ghi chú trở lại số slide cha.

**Làm sao tôi có thể tạo báo cáo mà không cần quét lại bản trình bày lần thứ hai?**

Truyền một proxy callback kết quả Java vào thao tác đánh dấu hoặc thay thế. Callback nhận mỗi khớp trong khi thao tác chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để sau này nhóm hoặc xuất.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[TextFrame.replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sửa đổi văn bản đã khớp trong khung văn bản hiện tại và giữ định dạng phần xung quanh. Nếu một khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng kiểu mong muốn.