---
title: Chỉnh sửa tài liệu PDF trong Java
linktitle: Chỉnh sửa PDF
type: docs
weight: 65
url: /vi/java/edit-pdf/
keywords:
- chỉnh sửa PDF
- thay thế văn bản PDF
- PDF sang PPTX
- PPTX sang PDF
- Java
- Aspose.Slides
description: "Chỉnh sửa tài liệu PDF trong Java bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản, và lưu bản trình chiếu đã sửa lại dưới dạng PDF."
---
## **Tổng quan**

Aspose.Slides for Java cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng slide, sửa đổi bản trình chiếu và xuất lại dưới dạng PDF. Bài viết này trình bày một ví dụ đơn giản về thay thế văn bản. Bản trình chiếu được giữ trong bộ nhớ, vì vậy việc lưu tệp PPTX trung gian là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [addFromPdf](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) để nhập các trang, [replaceText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) để cập nhật văn bản, và [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) để xuất kết quả.

Ví dụ dưới đây giả định `input.pdf` chứa từ “Draft” dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó sẽ thay thế từ đó bằng “Final” và ghi ra `edited.pdf`. Xóa slide ban đầu trước khi nhập ngăn việc tạo trang trắng thừa trong kết quả. Tìm kiếm khớp toàn từ với cùng chữ hoa/thường; `null` có nghĩa là không cần callback kết quả.

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

Để biết thêm tùy chọn, xem [Search and Replace Text](/slides/vi/java/search-and-replace-text/) và [Convert PowerPoint to PDF](/slides/vi/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Việc thay thế văn bản chỉ áp dụng cho văn bản được nhập, không phải văn bản trong hình ảnh đã quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy kiểm tra lại đầu ra, đặc biệt khi văn bản thay thế dài hơn văn bản gốc.
{{% /alert %}}

## **FAQ**

**Tôi có cần lưu tệp PPTX trước khi xuất ra PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình chiếu trong bộ nhớ. Chỉ lưu một bản sao PPTX nếu bạn cũng muốn tiếp tục chỉnh sửa nó trong PowerPoint; xem [Save Presentations](/slides/vi/java/save-presentation/).

**Tại sao một số văn bản vẫn không thay đổi?**

Ví dụ khớp toàn từ “Draft” với đúng chữ hoa/thường. Văn bản được nhập dưới dạng hình ảnh hoặc bị chia thành các khung văn bản riêng sẽ không nhất thiết khớp với tìm kiếm. Kiểm tra nội dung đã nhập và điều chỉnh tiêu chí tìm kiếm cho tài liệu của bạn.