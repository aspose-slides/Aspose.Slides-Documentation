---
title: Chỉnh sửa tài liệu PDF trên Android
linktitle: Chỉnh sửa PDF
type: docs
weight: 65
url: /vi/androidjava/edit-pdf/
keywords:
- chỉnh sửa PDF
- thay thế văn bản PDF
- PDF sang PPTX
- PPTX sang PDF
- Android
- Java
- Aspose.Slides
description: "Chỉnh sửa tài liệu PDF trên Android bằng Java bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản và lưu bản trình chiếu đã sửa lại thành PDF."
---
## **Tổng quan**

Aspose.Slides for Android qua Java cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng slide, sửa đổi bản trình chiếu và xuất lại thành PDF. Bài viết này trình bày cách thay thế văn bản đơn giản. Bản trình chiếu được giữ trong bộ nhớ, vì vậy việc lưu một tệp PPTX trung gian là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [addFromPdf](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) để nhập các trang, [replaceText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) để cập nhật văn bản, và [save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) để xuất kết quả.

Ví dụ dưới đây giả định rằng `input.pdf` chứa từ "Draft" dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó thay thế từ đó bằng "Final" và ghi ra `edited.pdf`. Xóa slide đầu tiên trước khi nhập sẽ ngăn một trang trống thừa trong kết quả. Tìm kiếm khớp toàn bộ từ với cùng kiểu chữ; `null` có nghĩa là không cần callback kết quả.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Để biết thêm tùy chọn, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/androidjava/search-and-replace-text/) và [Chuyển đổi PowerPoint sang PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Việc thay thế văn bản hoạt động trên văn bản được nhập, không phải văn bản trong hình ảnh đã quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy kiểm tra kết quả, đặc biệt khi văn bản thay thế dài hơn so với bản gốc.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có cần lưu tệp PPTX trước khi xuất PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình chiếu trong bộ nhớ. Lưu bản sao PPTX chỉ khi bạn muốn tiếp tục chỉnh sửa nó trong PowerPoint; xem [Lưu Bản trình chiếu](/slides/vi/androidjava/save-presentation/).

**Tại sao một số văn bản có thể không thay đổi?**

Ví dụ này khớp toàn bộ từ "Draft" với đúng kiểu chữ. Văn bản được nhập dưới dạng hình ảnh hoặc chia thành các khung văn bản riêng sẽ không nhất thiết khớp với tìm kiếm. Kiểm tra nội dung đã nhập và điều chỉnh tìm kiếm cho tài liệu của bạn.