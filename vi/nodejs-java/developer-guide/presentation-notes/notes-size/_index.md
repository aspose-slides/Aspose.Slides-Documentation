---
title: Thay đổi kích thước và hướng trang ghi chú trong JavaScript
linktitle: Kích thước trang ghi chú
type: docs
weight: 10
url: /vi/nodejs-java/notes-size/
keywords:
- kích thước trang ghi chú
- hướng ghi chú
- ghi chú ngang
- ghi chú dọc
- kích thước handout
- PowerPoint
- bản trình bày
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Đọc và thay đổi kích thước trang ghi chú trong Aspose.Slides cho Node.js thông qua Java, chuyển hướng, xác minh kích thước đã lưu, và xuất ghi chú hoặc handout sang PDF và hình ảnh."
---
## **Tổng quan**

Sử dụng [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getnotessize/) để truy cập cài đặt trang ghi chú của bản trình bày. Nó trả về một đối tượng [NotesSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notessize/) mà phương thức [setSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notessize/setsize/) thiết lập kích thước trang. Mặc dù đối tượng cài đặt không thể được thay thế, bạn có thể gán các kích thước mới thông qua phương thức này.

Chiều rộng và chiều cao được chỉ định bằng **điểm**, với 72 điểm mỗi inch. Ví dụ, 900 × 600 điểm tương đương 12,5 × 8⅓ inch. Các cài đặt này áp dụng cho toàn bộ bản trình bày, chứ không phải cho ghi chú của một slide riêng lẻ.

| Cài đặt | Mục đích |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getnotessize/) | Điều khiển kích thước trang ghi chú và kích thước trang được sử dụng cho việc xuất handout. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getslidesize/) | Điều khiển kích thước slide bình thường của bản trình bày thông qua [SlideSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesize/). |

Thay đổi một cài đặt sẽ không tự động thay đổi cài đặt còn lại. Thay đổi hướng trang ghi chú cũng không xoay các slide bình thường. Xem [Slide Size](/slides/vi/nodejs-java/slide-size/) để thay đổi kích thước slide bình thường.

Các ví dụ bên dưới sử dụng tệp `sample.pptx` hiện có. Đối với các ví dụ xuất, hãy sử dụng một bản trình bày có ít nhất một slide chứa ghi chú người thuyết trình. Mỗi ví dụ có thể chạy độc lập.

## **Đọc Kích Thước và Hướng Trang Ghi Chú**

Đọc chiều rộng và chiều cao và so sánh chúng để xác định hướng: trang rộng hơn là ngang, trang cao hơn là dọc, và các kích thước bằng nhau mô tả một trang vuông. Ví dụ này in ra các kích thước thực tế bằng điểm, mà không giả định kích thước giấy tiêu chuẩn.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Chuyển sang Ngang mà Không Thay Đổi Kích Thước Giấy**

Để chỉ thay đổi hướng, hoán đổi chiều rộng và chiều cao hiện có. Điều này giữ nguyên độ dài của cả hai cạnh, kể cả khi sử dụng kích thước giấy tùy chỉnh. Điều kiện dưới đây ngăn một trang đã ở chế độ ngang bị chuyển lại thành dọc và để một trang vuông không bị thay đổi.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với hướng dọc, sử dụng cùng một phép gán khi `size.getWidth() > size.getHeight()`. Không thay thế kích thước A4 hoặc Letter trừ khi bạn cũng muốn thay đổi kích thước giấy.

## **Đặt và Xác Nhận Kích Thước Trang Ghi Chú Tùy Chỉnh**

Gán cả hai kích thước cùng lúc, sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/save/) để ghi bản trình bày. Ví dụ này đặt một trang ngang 900 × 600 điểm, lưu dưới dạng PPTX và mở lại tệp đã lưu để kiểm tra các giá trị được lưu giữ. So sánh cho phép sai số 0,01 điểm đối với các giá trị số thực; đây không phải là bảo đảm độ chính xác cho mọi định dạng tệp.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Kết quả mong đợi là `900 x 600 points` và `Size preserved: true`. Kiểm tra một bản trình bày mới được mở lại xác nhận tệp đã lưu, chứ không chỉ là các cài đặt trong bộ nhớ.

## **Xuất Ghi Chú và Handout**

Kích thước trang xác định khu vực khả dụng cho bố cục ghi chú hoặc handout. Chúng không tự động bật các bố cục này: cần cấu hình các tùy chọn xuất. Việc xuất slide bình thường vẫn sử dụng kích thước slide.

### **Xuất Ghi Chú sang PDF và PNG**

Gán [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) cho [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) để bao gồm ghi chú trong PDF. Ví dụ này cũng render slide đầu tiên có ghi chú sang PNG bằng cách sử dụng [Slide.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage) và [RenderingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/).

Chế độ [BottomTruncated](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notespositions/) giữ ghi chú trên một trang; các ghi chú không vừa có thể bị cắt ngắn. PDF sử dụng các trang 900 × 600 điểm. Với tỷ lệ ảnh 1 × 1 được dùng dưới đây, PNG có kích thước 900 × 600 pixel. Điểm mô tả hình học trang; pixel mô tả output raster, kích thước cũng phụ thuộc vào tỷ lệ render.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Đối với xuất PDF với ghi chú dài, [BottomFull](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notespositions/) cho phép thêm các trang khi cần. Không sử dụng chế độ này với lệnh tạo ảnh một slide ở trên, vì nó không hỗ trợ. Sau khi thay đổi kích thước, kiểm tra đầu ra để thấy liệu có ghi chú bị cắt hay vị trí của các đối tượng notes‑master hiện có; việc chỉ thay đổi kích thước trang không nên được coi là bảo đảm mọi nội dung sẽ vừa. Xem [Convert PowerPoint to PDF with Notes](/slides/vi/nodejs-java/convert-powerpoint-to-pdf-with-notes/) để biết thêm về xuất ghi chú.

### **Xuất Handout sang PDF**

Sử dụng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handoutlayoutingoptions/) cho nhiều hình thu nhỏ slide trên một trang. Ví dụ sau đặt một trang 900 × 600 điểm và dùng [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/handouttype/) để sắp xếp tối đa bốn slide mỗi trang. Cài đặt ngang điều khiển thứ tự slide; hướng trang được lấy từ chiều rộng và chiều cao của nó.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Thay đổi kích thước trang thay đổi khu vực khả dụng cho lưới handout mà không thay đổi kích thước slide nguồn. Đối với hình handout, sử dụng [Presentation.getImages](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getimages/) với bố cục handout, thay vì phương thức tạo ảnh của slide riêng lẻ. Trong Aspose.Slides, việc render handout ở mức bản trình bày sử dụng kích thước trang ghi chú, trong khi lệnh tạo ảnh slide riêng không tạo trang handout. Xem [Handout Mode](/slides/vi/nodejs-java/convert-powerpoint-in-handout-mode/) để biết các tùy chọn bố cục.

## **Kích Thước Trang trong Trình Xem, Xuất và In**

Giữ riêng biệt kích thước bản trình bày đã lưu, kích thước trang xuất và kích thước giấy in:

- **Presentation viewers:** Trình xem có thể hiển thị hoặc in ghi chú theo quy tắc bố cục riêng. Nếu một ứng dụng khác lưu tệp, mở lại và kiểm tra lại kích thước; quá trình chuyển đổi định dạng của ứng dụng đó có thể chuẩn hoá chúng.
- **Export formats:** Các ví dụ PDF ghi chú và handout ở trên sử dụng kích thước trang đã cấu hình. Hình raster dùng kích thước pixel nguyên và tỷ lệ render, vì vậy các giá trị điểm thập phân có thể được làm tròn trong đầu ra hình ảnh. Việc xuất slide bình thường không áp dụng kích thước trang ghi chú.
- **Printer drivers:** Lựa chọn giấy, tự động xoay và cài đặt vừa trang có thể thay đổi kết quả in mà không thay đổi kích thước lưu trong bản trình bày hoặc PDF. Đối với kích thước giấy cụ thể, hãy điều chỉnh cài đặt máy in và kiểm tra trước khi in.

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước ghi chú cho chỉ một slide không?**

Kích thước trang ghi chú là cài đặt ở mức bản trình bày. Các slide riêng lẻ có thể có nội dung ghi chú khác nhau, nhưng thuộc tính này không cung cấp kích thước trang riêng cho từng slide.

**Tại sao việc thay đổi hướng ghi chú không thay đổi các slide của tôi?**

Trang ghi chú và các slide bình thường có kích thước độc lập. Hãy sử dụng cài đặt kích thước slide bình thường khi bạn muốn thay đổi kích thước của các slide.

**Tại sao kết quả đã lưu hoặc đã in của tôi có kích thước khác?**

Đầu tiên mở lại bản trình bày đã lưu và so sánh kích thước ghi chú. Nếu chúng đã thay đổi, kiểm tra xem việc lưu hoặc chuyển đổi tệp trong ứng dụng khác có thay đổi cài đặt trang không. Nếu không, kiểm tra bố cục xuất, tỷ lệ ảnh, cài đặt trình xem và lựa chọn giấy của máy in.