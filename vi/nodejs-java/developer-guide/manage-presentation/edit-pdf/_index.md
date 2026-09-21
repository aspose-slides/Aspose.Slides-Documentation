---
title: Chỉnh sửa tài liệu PDF trong JavaScript
linktitle: Chỉnh sửa PDF
type: docs
weight: 65
url: /vi/nodejs-java/edit-pdf/
keywords:
- chỉnh sửa PDF
- thay thế văn bản PDF
- PDF sang PPTX
- PPTX sang PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Chỉnh sửa tài liệu PDF trong JavaScript bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản và lưu bản trình bày đã sửa lại thành PDF."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng slide, chỉnh sửa bản trình bày và xuất lại thành PDF. Bài viết này trình bày cách thay thế văn bản đơn giản. Bản trình bày được giữ trong bộ nhớ, vì vậy việc lưu tệp PPTX trung gian là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [addFromPdf](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addFromPdf) để nhập các trang, [replaceText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#replaceText) để cập nhật văn bản và [save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) để xuất kết quả.

Ví dụ sau giả định rằng `input.pdf` chứa từ “Draft” dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó thay thế từ đó bằng “Final” và ghi ra `edited.pdf`. Xóa slide ban đầu trước khi nhập giúp tránh một trang trống thừa trong output. Tìm kiếm khớp toàn bộ từ với cùng kiểu chữ; `null` có nghĩa là không cần callback kết quả.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Để biết thêm tùy chọn, xem [Search and Replace Text](/slides/vi/nodejs-java/search-and-replace-text/) và [Convert PowerPoint to PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Lưu ý" %}}
Thay thế văn bản chỉ áp dụng cho văn bản đã nhập, không phải văn bản trong hình ảnh được quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy kiểm tra kết quả, đặc biệt khi văn bản thay thế dài hơn so với bản gốc.
{{% /alert %}}

## **FAQ**

**Tôi có cần lưu tệp PPTX trước khi xuất ra PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình bày trong bộ nhớ. Lưu một bản sao PPTX chỉ khi bạn cũng muốn tiếp tục chỉnh sửa nó trong PowerPoint; xem [Save Presentations](/slides/vi/nodejs-java/save-presentation/).

**Tại sao một số văn bản vẫn không thay đổi?**

Ví dụ khớp toàn bộ từ “Draft” với cùng kiểu chữ. Văn bản được nhập dưới dạng hình ảnh hoặc chia thành nhiều khung văn bản riêng biệt sẽ không nhất thiết khớp với tìm kiếm. Kiểm tra nội dung đã nhập và điều chỉnh tìm kiếm cho tài liệu của bạn.