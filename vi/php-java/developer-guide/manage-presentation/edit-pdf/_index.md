---
title: "Chỉnh sửa tài liệu PDF trong PHP"
linktitle: "Chỉnh sửa PDF"
type: docs
weight: 65
url: /vi/php-java/edit-pdf/
keywords:
- "chỉnh sửa PDF"
- "thay thế văn bản PDF"
- "PDF sang PPTX"
- "PPTX sang PDF"
- "PHP"
- "Aspose.Slides"
description: "Chỉnh sửa tài liệu PDF trong PHP bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản và lưu bản trình bày đã chỉnh sửa trở lại thành PDF."
---
## **Tổng quan**

Aspose.Slides for PHP via Java cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng slide, chỉnh sửa bản trình bày và xuất lại thành PDF. Bài viết này trình bày cách thay thế văn bản đơn giản. Bản trình bày vẫn ở trong bộ nhớ, vì vậy việc lưu một tệp PPTX trung gian là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [SlideCollection::addFromPdf](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/#addFromPdf) để nhập các trang, [Presentation::replaceText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#replaceText) để cập nhật văn bản, và [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) để xuất kết quả.

Ví dụ sau giả định rằng `input.pdf` chứa từ "Draft" dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó thay thế từ đó bằng "Final" và ghi ra `edited.pdf`. Xóa slide đầu tiên trước khi nhập sẽ ngăn một trang trống thừa trong kết quả. Tìm kiếm khớp toàn bộ từ với cùng kiểu chữ; `null` có nghĩa là không cần hàm gọi lại kết quả.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Để biết thêm tùy chọn, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/php-java/search-and-replace-text/) và [Chuyển đổi PowerPoint sang PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Lưu ý" %}}
Việc thay thế văn bản chỉ áp dụng cho văn bản đã nhập, không áp dụng cho văn bản trong hình ảnh quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy kiểm tra kết quả, đặc biệt khi văn bản thay thế dài hơn so với bản gốc.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có cần lưu tệp PPTX trước khi xuất PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình bày trong bộ nhớ. Chỉ lưu một bản sao PPTX nếu bạn cũng muốn tiếp tục chỉnh sửa nó trong PowerPoint; xem [Lưu Bản Trình Bày](/slides/vi/php-java/save-presentation/).

**Tại sao một số văn bản vẫn không thay đổi?**

Ví dụ khớp toàn bộ từ "Draft" với đúng kiểu chữ. Văn bản được nhập dưới dạng hình ảnh hoặc chia thành các khung văn bản riêng sẽ không nhất thiết khớp với tìm kiếm. Kiểm tra nội dung đã nhập và điều chỉnh tìm kiếm cho tài liệu của bạn.