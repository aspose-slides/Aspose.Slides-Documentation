---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình chiếu PowerPoint trên Android
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/androidjava/search-and-replace-text/
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
- Android
- Java
- Aspose.Slides
description: "Tìm kiếm, đánh dấu và thay thế văn bản trong bản trình chiếu PowerPoint đồng thời thu thập mọi kết quả khớp với Aspose.Slides cho Android thông qua Java."
---
## **Tổng quan**

Aspose.Slides cho Android thông qua Java có thể tìm kiếm, đánh dấu và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình chiếu. Mỗi hoạt động cũng có thể thông báo cho ứng dụng về mỗi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bản trình chiếu đồng thời xây dựng một bản ghi kiểm toán chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc rà soát, xóa nhạy cảm, kiểm tra thuật ngữ, dọn dẹp mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên bên dưới, chúng tôi sử dụng một tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn Phạm vi Tìm kiếm**

Sử dụng các phương thức trên [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) để giới hạn một hoạt động trong một khung văn bản. Sử dụng các phương thức trên [IPresentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/) để xử lý tất cả văn bản áp dụng trong bản trình chiếu.

| Hoạt động | Một khung văn bản | Toàn bộ bản trình chiếu |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Cấu hình khớp văn bản**

Đối với các hoạt động văn bản chữ nguyên, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/) để kiểm soát việc khớp:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) giới hạn các kết quả khớp chỉ ở các từ hoàn chỉnh.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kiểm soát việc có phải khớp chữ hoa/thường.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) bao gồm ghi chú slide trong các hoạt động tìm kiếm, thay thế và đánh dấu ở mức bản trình chiếu.

Các hoạt động biểu thức chính quy sử dụng một `Pattern` của Java, vì vậy các quy tắc khớp như phân biệt chữ hoa/thường và ranh giới từ được xác định bởi biểu thức và các cờ của nó.

## **Thu thập thông tin khớp bằng Callback**

Triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifindresultcallback/) để nhận thông báo cho mỗi kết quả khớp. Phương thức [IFindResultCallback.foundResult](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) của nó cung cấp khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Phần triển khai bên dưới suy ra nó từ slide cha và cũng xử lý văn bản được tìm thấy trong ghi chú slide. Một `Integer` có thể null cho phép mô hình kết quả giống nhau đại diện cho văn bản liên quan đến các loại slide khác.

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

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

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

Đối với các hoạt động thay thế, `foundText` chứa văn bản khớp gốc, do đó callback có thể ghi lại chính xác các thuật ngữ đã được thay thế.

## **Đánh dấu Văn bản**

Sử dụng phương thức [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) để đánh dấu các kết quả khớp văn bản chữ nguyên trong một khung văn bản. Chuyển [TextSearchOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/) để kiểm soát việc tìm kiếm và một callback để thu thập chi tiết kết quả khớp.

Ví dụ mã bên dưới đánh dấu tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ đánh dấu từ đầy đủ **"to"**. Cả hai tìm kiếm đều báo cáo các kết quả khớp cho cùng một callback.

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

    // Đánh dấu mọi lần xuất hiện của "try" trong khung văn bản.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Đánh dấu chỉ từ đầy đủ "to".
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

![Văn bản đã được đánh dấu](highlighted_text.png)

## **Đánh dấu Văn bản bằng Biểu thức Chính quy**

Phương thức [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) đánh dấu các kết quả khớp văn bản được tìm thấy bởi một biểu thức chính quy trong một khung văn bản.

Mã sau đây đánh dấu tất cả các từ chứa bảy ký tự trở lên và thu thập mỗi kết quả khớp:

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

![Văn bản đã được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đánh dấu Văn bản trên Toàn bộ Bản trình chiếu**

Sử dụng [IPresentation.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [IPresentation.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) để tìm kiếm tất cả các khung văn bản áp dụng trong một bản trình chiếu. Ví dụ sau đây đánh dấu một thuật ngữ chữ nguyên và tất cả địa chỉ email đồng thời giữ các bộ kết quả riêng biệt cho hai tìm kiếm.

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

## **Thay thế Văn bản trong một Khung Văn bản**

Sử dụng [ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) cho văn bản chữ nguyên và [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ định dạng phần bao quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ sau đây chuẩn hoá một biến thể chính tả và sau đó thay thế các nhãn phiên bản. Callback giống nhau ghi lại các thuật ngữ gốc đã khớp bởi cả hai hoạt động.

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

Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy xem lại đầu ra để xác nhận định dạng nào sẽ được áp dụng cho văn bản thay thế.

## **Thay thế Văn bản trên Toàn bộ Bản trình chiếu**

Sử dụng [IPresentation.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [IPresentation.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) để áp dụng các hoạt động giống nhau trên toàn bộ bản trình chiếu. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và xóa nhạy cảm.

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

## **Nhóm Các Kết quả Khớp cho Báo cáo**

Vì mỗi kết quả lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các kết quả khớp để kiểm toán, báo cáo hoặc quy trình rà soát. Ví dụ sau đây nhóm các kết quả đã thu thập đầu tiên theo slide và sau đó theo khung văn bản:

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

**Làm thế nào để tôi chỉ tìm kiếm một hộp văn bản thay vì toàn bộ bản trình chiếu?**

Lấy khung văn bản của shape và gọi [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), hoặc [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) trên khung văn bản đó. Các phương thức ở mức bản trình chiếu sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm thế nào tôi có thể khớp các từ đầy đủ với việc viết hoa đúng?**

Đặt [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) và [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) thành `true`, và truyền các tùy chọn này vào phương thức đánh dấu hoặc thay thế văn bản chữ nguyên. Đối với biểu thức chính quy, định nghĩa ranh giới từ và phân biệt chữ hoa/thường trong chính `Pattern` của Java.

**Tìm kiếm và thay thế có thể bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) thành `true` khi sử dụng một hoạt động văn bản chữ nguyên ở mức bản trình chiếu. Phần triển khai callback được trình bày ở trên sẽ ánh xạ một kết quả khớp trong slide ghi chú trở lại số slide cha của nó.

**Làm thế nào tôi có thể tạo báo cáo mà không cần quét lại bản trình chiếu lần thứ hai?**

Truyền một triển khai [IFindResultCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifindresultcallback/) vào hoạt động đánh dấu hoặc thay thế. Callback nhận mọi kết quả khớp trong khi hoạt động đang chạy, do đó ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để nhóm hoặc xuất sau này.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) và [ITextFrame.replaceRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ lại định dạng phần bao quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng phong cách mong muốn.