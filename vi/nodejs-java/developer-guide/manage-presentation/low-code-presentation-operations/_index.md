---
title: Các thao tác trình chiếu Low-Code trong JavaScript
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/nodejs-java/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- ghép nối trình chiếu
- lặp qua các slide
- lặp qua các hình dạng
- lặp qua văn bản
- thu thập hình dạng
- nén trình chiếu
- xóa slide master không dùng
- xóa slide layout không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Sử dụng API low-code của Aspose.Slides trong JavaScript để chuyển đổi và ghép nối các trình chiếu, lặp qua nội dung, thu thập các hình dạng và giảm kích thước của trình chiếu."
---
## **Tổng quan**

Không gian tên `aspose.slides` cung cấp các lớp trợ giúp tĩnh cho các thao tác trình chiếu phổ biến. Những trợ giúp này gói gọn các quy trình mô hình đối tượng thường dùng vào các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, xử lý các thành phần trình chiếu, thu thập các hình dạng và loại bỏ nội dung không dùng đến với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc trình chiếu và quy trình mặc định đáp ứng yêu cầu của bạn. Sử dụng mô hình đối tượng đầy đủ của [Aspose.Slides object model](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/) khi cần kiểm soát chi tiết các slide, master, layout, shape, thiết lập xuất khẩu, hoặc quan hệ giữa các thành phần trình chiếu.

Bảng dưới đây tóm tắt các trợ giúp có sẵn:

| Tiện ích | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/) | Chuyển đổi một bài thuyết trình sang định dạng khác bằng lời gọi trực tiếp từ tệp này sang tệp khác. |
| [Merger](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/merger/) | Kết hợp các tệp trình chiếu hoàn chỉnh có cùng định dạng. |
| [ForEach](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/) | Thực hiện một hành động cho mỗi slide, shape, paragraph hoặc portion. |
| [Collect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/collect/) | Lấy các shape từ toàn bộ trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) | Loại bỏ các master và layout không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một bài thuyết trình**

Sử dụng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/#autoByExtension) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức này mở trình chiếu nguồn, xác định định dạng yêu cầu từ đường dẫn đầu ra và ghi kết quả.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

Lớp [Convert](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/) cũng cung cấp các phương thức riêng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi cần kiểm tra hoặc sửa đổi trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất không được trợ giúp cung cấp. Xem [Convert Presentation](/slides/vi/nodejs-java/convert-presentation/) để biết các quy trình và tùy chọn theo định dạng.

## **Ghép các bài thuyết trình**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/merger/#process) để kết hợp các tệp trình chiếu hoàn chỉnh chỉ bằng một lời gọi. Các trình chiếu đầu vào phải có cùng định dạng tệp.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối vào một kết quả mà không cần chọn hoặc ánh xạ từng slide riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi cần ghép các slide đã chọn, áp dụng master hoặc layout đích, bảo tồn các phần rõ ràng, hoặc điều chỉnh kích thước slide khác nhau. Xem [Merge Presentations](/slides/vi/nodejs-java/merge-presentation/) cho các kịch bản đó.

## **Duyệt qua các thành phần của bài thuyết trình**

Lớp [ForEach](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/) gọi một callback cho mỗi loại thành phần trình chiếu được yêu cầu. Nó tránh các vòng lặp bộ sưu tập lồng nhau và thuận tiện cho việc kiểm tra hoặc thay đổi định dạng trên toàn bộ trình chiếu. Trong Node.js, tạo các triển khai của các giao diện callback bằng `java.newProxy`.

Ví dụ sau sử dụng [ForEach.slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#paragraph) và [ForEach.portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#portion) để kiểm tra các yếu tố tương ứng:

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

Mặc định, việc duyệt hình dạng và văn bản trên toàn bộ trình chiếu bao gồm các slide bình thường, master và layout. Các overload có tham số `includeNotes` cũng có thể xử lý các slide ghi chú. Sử dụng vòng lặp bộ sưu tập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi gọi callback hoặc kiểm soát chi tiết cha-con là quan trọng.

## **Thu thập các hình dạng**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/collect/#shapes) khi bạn cần một bộ sưu tập tất cả các shape trong một trình chiếu thay vì một callback cho mỗi shape. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

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

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape) thay thế khi mỗi shape có thể được xử lý ngay lập tức và bạn không cần giữ lại kết quả đã thu thập.

## **Nén nội dung bài thuyết trình**

Lớp [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) có thể loại bỏ các phần cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) loại bỏ các slide layout mà không có slide bình thường nào tham chiếu.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) loại bỏ các slide master không còn được sử dụng.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) loại bỏ các ký tự không dùng khỏi phông chữ nhúng.

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

Hãy loại bỏ các layout không dùng trước các master không dùng để một master trở nên không được tham chiếu sau khi dọn dẹp layout cũng có thể bị xóa. Lưu trình chiếu đã tối ưu vào một tệp mới nếu bạn có thể cần lại các master, layout hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/slides/vi/nodejs-java/slide-master/) và [Embedded Font](/slides/vi/nodejs-java/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc trình chiếu và không yêu cầu kiểm soát chi tiết các yếu tố riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi cần chọn các slide cụ thể, điều khiển quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các trình chiếu có định dạng tệp khác nhau không?**

Không. [Merger.process](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/merger/#process) yêu cầu các trình chiếu đầu vào ở cùng một định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert.autoByExtension](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/convert/#autoByExtension), sau đó ghép các tệp đã chuyển đổi.

**ForEach có xử lý các slide master, layout và notes không?**

[ForEach.slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#slide) duyệt các slide trình chiếu bình thường. Các thao tác [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#paragraph) và [ForEach.portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#portion) trên toàn bộ trình chiếu bao gồm các slide bình thường, master và layout theo mặc định. Sử dụng các overload với `includeNotes` được đặt là `true` để bao gồm các slide ghi chú.

**Sự khác nhau giữa ForEach.shape và Collect.shapes là gì?**

Sử dụng [ForEach.shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/#shape) để xử lý mỗi shape ngay lập tức qua một callback. Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/collect/#shapes) khi bạn cần một kết quả có thể lưu lại, lọc, đếm hoặc duyệt nhiều lần.

**Compress luôn làm cho tệp trình chiếu nhỏ hơn không?**

Không nhất thiết. Kết quả phụ thuộc vào việc trình chiếu có chứa các layout không dùng, master không dùng, hoặc phông chữ nhúng có ký tự không dùng hay không. Nếu không có các yếu tố trên, các thao tác [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/) tương ứng có thể không giảm kích thước tệp.

**Các thay đổi do ForEach hoặc Compress thực hiện có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi thay đổi các yếu tố trong callback của [ForEach](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/foreach/) hoặc chạy [Compress](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compress/), hãy gọi [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) để ghi kết quả.

## **Bài viết liên quan**

- [Convert Presentation](/slides/vi/nodejs-java/convert-presentation/)
- [Merge Presentations](/slides/vi/nodejs-java/merge-presentation/)
- [Slide Master](/slides/vi/nodejs-java/slide-master/)
- [Manage Text Box](/slides/vi/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/vi/nodejs-java/embedded-font/)