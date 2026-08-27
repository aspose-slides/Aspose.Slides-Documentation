---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình chiếu PowerPoint trên Android
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/androidjava/search-and-replace-text/
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
- Android
- Java
- Aspose.Slides
description: "Tìm kiếm, làm nổi bật và thay thế văn bản trong các bản trình chiếu PowerPoint đồng thời thu thập mọi kết quả khớp bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Aspose.Slides for Android qua Java có thể tìm kiếm, làm nổi bật và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình chiếu. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mỗi kết quả phù hợp thông qua một hàm gọi lại (callback) kết quả. Điều này cho phép cập nhật bản trình chiếu đồng thời xây dựng một bản ghi kiểm toán chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc rà soát, xóa nhạy, kiểm tra thuật ngữ, làm sạch mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên dưới đây, chúng tôi sử dụng tệp có tên "sample.pptx", chứa một ô văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Sample text](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) để giới hạn một thao tác trong một khung văn bản. Sử dụng các phương thức trên [IPresentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/) để xử lý tất cả các văn bản áp dụng trong bản trình chiếu.

| Hoạt động | Một khung văn bản | Toàn bộ bản trình chiếu |
|---|---|---|
| Làm nổi bật văn bản nguyên văn | [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Làm nổi bật kết quả khớp biểu thức chính quy | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Thay thế văn bản nguyên văn | [ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Thay thế kết quả khớp biểu thức chính quy | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên văn, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/) để điều khiển việc khớp:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) giới hạn kết quả chỉ ở các từ đầy đủ.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kiểm soát việc có phân biệt chữ hoa/thường hay không.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và làm nổi bật ở mức bản trình chiếu.

Các thao tác biểu thức chính quy sử dụng một `Pattern` của Java, do đó các quy tắc khớp như phân biệt chữ hoa/thường và ranh giới từ được định nghĩa bởi biểu thức và các cờ của nó.

## **Xác định chủ sở hữu của một khung văn bản**

Các quy trình xử lý văn bản chung thường nhận một [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) khi tìm kiếm, thay thế, xác thực hoặc xuất văn bản. Sử dụng [ITextFrame.getParentShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getParentShape--) và [ITextFrame.getParentCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getParentCell--) để xác định đối tượng trình chiếu nào sở hữu khung văn bản.

Các giá trị trả về phụ thuộc vào chủ sở hữu:

| Chủ sở hữu khung văn bản | `getParentShape` | `getParentCell` |
|---|---|---|
| Một AutoShape hoặc hình dạng chứa văn bản khác | Đối tượng sở hữu [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) | `null` |
| Một ô bảng | `null` | Đối tượng sở hữu [ICell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icell/) |

Cả hai phương thức đều cung cấp điều hướng chỉ đọc. Gọi chúng không di chuyển khung văn bản hay thay đổi chủ sở hữu. Mã chung nên kiểm tra cả hai giá trị xem có `null` và xử lý khả năng không có chủ sở hữu nào.

Ví dụ sau sử dụng [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) để duyệt qua các khung văn bản trong một bản trình chiếu. Đối với các hình dạng, nó báo cáo tên hình dạng, kiểu runtime của Java và slide chứa. Đối với các ô bảng, nó báo cáo tọa độ cột và hàng dựa trên chỉ số 0 và slide chứa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Đối với nội dung SmartArt, duyệt qua các hình dạng trong [ISmartArtNode.getShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ismartartnode/#getShapes--) và truy cập mỗi [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Khung văn bản có thể được truy vết tới hình dạng tương ứng thông qua [ITextFrame.getParentShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getParentShape--), trong khi [ITextFrame.getParentCell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getParentCell--) trả về `null`. Do đó, nhánh hình dạng trong ví dụ cũng xử lý văn bản từ các nút SmartArt.

## **Thu thập thông tin khớp bằng Callback**

Triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifindresultcallback/) để nhận thông báo cho mỗi kết quả khớp. Phương thức [IFindResultCallback.foundResult](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) cung cấp khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Cài đặt bên dưới suy ra số slide từ slide cha và đồng thời xử lý văn bản được tìm thấy trong ghi chú slide. Một `Integer` có thể nhận giá trị null cho phép cùng một mô hình kết quả đại diện cho văn bản liên quan tới các loại slide khác.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Đối với các thao tác thay thế, `foundText` chứa văn bản khớp gốc, vì vậy callback có thể ghi lại chính xác các thuật ngữ đã được thay thế.

## **Làm nổi bật văn bản**

Sử dụng phương thức [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) để làm nổi bật các kết quả khớp văn bản nguyên văn trong một khung văn bản. Truyền [TextSearchOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/) để điều khiển tìm kiếm và một callback để thu thập chi tiết khớp.

Ví dụ mã dưới đây làm nổi bật tất cả các lần xuất hiện của chuỗi **"try"** và sau đó chỉ làm nổi bật từ đầy đủ **"to"**. Cả hai tìm kiếm đều báo cáo kết quả cho cùng một callback.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Làm nổi bật mọi lần xuất hiện của "try" trong khung văn bản.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Chỉ làm nổi bật từ đầy đủ "to".
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The highlighted text](highlighted_text.png)

## **Làm nổi bật văn bản bằng biểu thức chính quy**

Phương thức [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) làm nổi bật các kết quả khớp được tìm thấy bằng biểu thức chính quy trong một khung văn bản.

Mã sau làm nổi bật tất cả các từ có bảy ký tự trở lên và thu thập mỗi kết quả:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Làm nổi bật văn bản trên toàn bộ bản trình chiếu**

Sử dụng [IPresentation.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [IPresentation.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) để tìm kiếm tất cả các khung văn bản áp dụng trong một bản trình chiếu. Ví dụ sau làm nổi bật một thuật ngữ nguyên văn và tất cả địa chỉ email đồng thời giữ các bộ kết quả riêng biệt cho hai tìm kiếm.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay thế văn bản trong một khung văn bản**

Sử dụng [ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) cho văn bản nguyên văn và [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ sau chuẩn hoá một biến thể chính tả và sau đó thay thế các nhãn phiên bản. Cùng một callback ghi lại các thuật ngữ gốc được khớp bởi cả hai thao tác.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra đầu ra để xác nhận định dạng nào nên áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bản trình chiếu**

Sử dụng [IPresentation.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [IPresentation.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) để áp dụng các thao tác tương tự trên toàn bộ bản trình chiếu. Điều này hữu ích cho việc làm sạch mẫu, cập nhật thuật ngữ và xóa nhạy.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nhóm các kết quả để báo cáo**

Vì mỗi kết quả lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các kết quả cho các quy trình kiểm toán, báo cáo hoặc rà soát. Ví dụ sau nhóm các kết quả thu thập được trước tiên theo slide rồi theo khung văn bản:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **Câu hỏi thường gặp**

**Làm thế nào để tìm kiếm chỉ trong một ô văn bản thay vì toàn bộ bản trình chiếu?**

Lấy khung văn bản của hình dạng và gọi [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), hoặc [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) trên khung văn bản đó. Các phương thức ở mức bản trình chiếu sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao để khớp đầy đủ các từ với chữ hoa/thường đúng?**

Đặt [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) và [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) thành `true`, và truyền các tùy chọn này vào phương thức làm nổi bật hoặc thay thế văn bản nguyên văn. Đối với biểu thức chính quy, định nghĩa ranh giới từ và phân biệt chữ hoa/thường trong chính `Pattern` của Java.

**Việc tìm kiếm và thay thế có bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) thành `true` khi sử dụng một thao tác văn bản nguyên văn ở mức bản trình chiếu. Cài đặt callback được trình bày ở trên sẽ ánh xạ một kết quả trong slide ghi chú trở lại số slide cha.

**Làm sao tạo báo cáo mà không phải quét lại bản trình chiếu một lần nữa?**

Truyền một triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifindresultcallback/) vào thao tác làm nổi bật hoặc thay thế. Callback nhận mọi kết quả trong khi thao tác đang chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để nhóm hoặc xuất sau này.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ định dạng phần xung quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng phong cách mong muốn.