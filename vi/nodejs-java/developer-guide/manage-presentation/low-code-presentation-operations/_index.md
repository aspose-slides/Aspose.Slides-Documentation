---
title: Các thao tác trình chiếu low-code trong JavaScript
linktitle: API low-code
type: docs
weight: 50
url: /vi/nodejs-java/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- lặp qua slide
- lặp qua hình dạng
- lặp qua văn bản
- thu thập hình dạng
- nén trình chiếu
- xóa các slide master không dùng
- xóa các slide bố cục không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Sử dụng API low-code Aspose.Slides trong JavaScript để chuyển đổi và hợp nhất trình chiếu, lặp qua nội dung, thu thập hình dạng và giảm kích thước trình chiếu."
---
## **Tổng quan**

Không gian tên `aspose.slides` cung cấp các lớp trợ giúp tĩnh cho các thao tác trình chiếu thường gặp. Những trợ giúp này gói các quy trình mô hình đối tượng thường sử dụng thành các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các phần tử của trình chiếu, thu thập hình dạng và loại bỏ nội dung không dùng tới với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc trình chiếu và quy trình mặc định phù hợp với yêu cầu của bạn. Sử dụng toàn bộ [Aspose.Slides object model](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, bố cục, hình dạng, cài đặt xuất hoặc mối quan hệ giữa các phần tử trình chiếu.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/) | Chuyển đổi một trình chiếu sang định dạng khác bằng lời gọi trực tiếp từ tệp này sang tệp khác. |
| [Merger](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/merger/) | Kết hợp các tệp trình chiếu hoàn chỉnh cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/) | Thực thi một hành động cho mỗi slide, hình dạng, đoạn văn hoặc phần văn bản. |
| [Collect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/collect/) | Lấy các hình dạng từ toàn bộ trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) | Xóa các master và bố cục không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một trình chiếu**

Sử dụng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/#autoByExtension) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức mở trình chiếu nguồn, xác định định dạng cần thiết từ đường dẫn đầu ra và ghi kết quả.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/) cũng cung cấp các phương thức chuyên dụng cho xuất PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc sửa đổi trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất mà trợ giúp đã chọn không cung cấp. Xem [Convert Presentation](/nodejs-java/convert-presentation/) để biết quy trình và tùy chọn riêng cho từng định dạng.

## **Hợp nhất các trình chiếu**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/merger/#process) để kết hợp các tệp trình chiếu hoàn chỉnh bằng một lời gọi. Các trình chiếu đầu vào phải có cùng định dạng tệp.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối vào một kết quả duy nhất mà không chọn hay ánh xạ lại từng slide. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc bố cục đích, bảo lưu các phần một cách rõ ràng, hoặc điều chỉnh các kích thước slide khác nhau. Xem [Merge Presentations](/nodejs-java/merge-presentation/) cho các trường hợp đó.

## **Duyệt qua các phần tử của trình chiếu**

Lớp [ForEach](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/) gọi một callback cho mỗi loại phần tử trình chiếu được yêu cầu. Nó tránh các vòng lặp bộ sưu tập lồng nhau và tiện lợi cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ trình chiếu. Trong Node.js, tạo các triển khai của giao diện callback bằng `java.newProxy`.

Ví dụ sau sử dụng [ForEach.slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#paragraph) và [ForEach.portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#portion) để kiểm tra các phần tử tương ứng:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Mặc định, việc duyệt hình dạng và văn bản trên toàn bộ trình chiếu bao gồm các slide bình thường, master và layout. Các phiên bản overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp bộ sưu tập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback, hoặc kiểm soát chi tiết cha-con là quan trọng.

## **Thu thập các hình dạng**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/collect/#shapes) khi bạn cần một bộ sưu tập tất cả các hình dạng trong một trình chiếu thay vì một callback cho mỗi hình dạng. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape) thay thế khi mỗi hình dạng có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) có thể xóa các phần tử cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) loại bỏ các slide bố cục mà không có slide bình thường nào tham chiếu.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) xóa các slide master không còn được sử dụng.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) xóa các ký tự không dùng khỏi phông chữ nhúng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Xóa các bố cục không dùng trước các master không dùng để master trở nên không có tham chiếu sau khi dọn dẹp bố cục cũng có thể bị xóa. Lưu trình chiếu đã tối ưu vào một tệp mới nếu bạn có thể cần các master, bố cục hoặc dữ liệu phông chữ nhúng đầy đủ gốc sau này. Để biết chi tiết hơn, xem [Slide Master](/nodejs-java/slide-master/) và [Embedded Font](/nodejs-java/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc trình chiếu và không yêu cầu kiểm soát chi tiết các phần tử riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát mối quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các trình chiếu ở định dạng tệp khác nhau không?**

Không. [Merger.process](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/merger/#process) yêu cầu các trình chiếu đầu vào cùng định dạng. Trước tiên chuyển đổi các tệp đầu vào sang một định dạng chung, ví dụ bằng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/#autoByExtension), sau đó hợp nhất các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và ghi chú không?**

[ForEach.slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#slide) duyệt qua các slide trình chiếu bình thường. Các thao tác [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#paragraph) và [ForEach.portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#portion) trên toàn bộ trình chiếu bao gồm các slide bình thường, master và layout theo mặc định. Sử dụng các phiên bản overload với `includeNotes` đặt thành `true` để bao gồm các slide ghi chú.

**Sự khác nhau giữa ForEach.shape và Collect.shapes là gì?**

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape) để xử lý mỗi hình dạng ngay lập tức qua một callback. Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/collect/#shapes) khi bạn cần một kết quả có thể duyệt được, có thể giữ lại, lọc, đếm hoặc duyệt lại nhiều lần.

**Compress luôn làm file trình chiếu nhỏ hơn không?**

Không nhất thiết. Kết quả phụ thuộc vào việc trình chiếu có chứa các layout không dùng, master không dùng hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có những yếu tố này, các thao tác [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) tương ứng có thể không làm giảm kích thước tệp.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) đã tải vào bộ nhớ. Sau khi thay đổi các phần tử trong callback của [ForEach](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/), gọi [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi trình chiếu](/nodejs-java/convert-presentation/)
- [Hợp nhất các trình chiếu](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Quản lý hộp văn bản](/nodejs-java/manage-textbox/)
- [Phông chữ nhúng](/nodejs-java/embedded-font/)