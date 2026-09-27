---
title: Tạo Bài thuyết trình trong Node.js qua .NET
linktitle: Tạo Bài thuyết trình
type: docs
weight: 10
url: /vi/nodejs-net/create-presentation/
keywords:
- tạo bài thuyết trình
- bài thuyết trình mới
- tạo PowerPoint
- tạo PPTX
- thêm hộp văn bản
- thêm slide
- kích thước slide
- màn hình rộng
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo các bài thuyết trình PowerPoint trong JavaScript bằng Aspose.Slides cho Node.js qua .NET: thêm hộp văn bản và các slide, đặt kích thước slide 16:9, và lưu kết quả dưới dạng PPTX."
---
## **Tổng quan**

Bài viết này mô tả cách tạo một bài thuyết trình với Aspose.Slides cho Node.js qua .NET, thêm một hộp văn bản vào slide đầu tiên, và lưu kết quả dưới dạng tệp PPTX. Nó cũng chỉ ra cách thêm các slide khác và cách chuyển bài thuyết trình sang định dạng màn hình rộng (16:9).

Các ví dụ yêu cầu một dự án được thiết lập như mô tả trong [Installation](/slides/vi/nodejs-net/installation/). Lưu mỗi ví dụ dưới dạng tệp `.js` trong thư mục dự án và chạy nó từ thư mục đó bằng `node`, ví dụ `node create-presentation.js`.

{{% alert color="info" title="Lưu ý" %}}
Aspose.Slides cho Node.js qua .NET không có tài liệu tham chiếu API riêng. Nó sao chép API của Aspose.Slides cho .NET với các tên camelCase, vì vậy các liên kết API trong bài viết này dẫn đến các lớp và thành viên tương ứng trong [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Tạo một Bài thuyết trình với Hộp Văn bản**

Để tạo một bài thuyết trình và đặt một hộp văn bản trên slide đầu tiên, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Một bài thuyết trình mới đã chứa sẵn một slide trống.  
2. Lấy slide đó từ bộ sưu tập [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Các bộ sưu tập trong gói này được đọc bằng `get(index)`, và chỉ số bắt đầu từ 0.  
3. Thêm một hình chữ nhật bằng phương thức [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) và đặt [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) của [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).  
4. Lưu bài thuyết trình bằng phương thức [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) và giá trị `SaveFormat.Pptx`.  
5. Gọi `dispose` trong khối `finally` để giải phóng các tài nguyên .NET hỗ trợ bài thuyết trình.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Vị trí (x, y) và kích thước (chiều rộng, chiều cao) được tính bằng điểm.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Kịch bản sẽ viết tệp `new-presentation.pptx` vào thư mục dự án. Tệp này có một slide chứa một hình chữ nhật được tô màu, góc trên‑trái cách mép trái và mép trên của slide 50 điểm. Hình chữ nhật có độ rộng 400 điểm và độ cao 100 điểm, và văn bản bên trong được căn giữa. Một điểm bằng 1/72 inch. Nếu không có giấy phép, Aspose.Slides cũng sẽ thêm một dấu nước đánh giá vào slide; xem [Licensing](/slides/vi/nodejs-net/licensing/).

## **Thêm Slide**

Một bài thuyết trình mới có một slide. Để thêm nhiều slide hơn, truyền một layout slide vào phương thức [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) của bộ sưu tập `slides`. Phương thức [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) của bộ sưu tập [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) trả về layout đầu tiên của một [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/) nhất định.

Ví dụ sau thêm hai slide với layout Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kịch bản in ra `Slide count: 3` và ghi tệp `three-slides.pptx`. Các slide mới được nối tiếp sau slide đầu tiên và không chứa hình dạng nào. Một bài thuyết trình mới luôn có layout Blank, nhưng một bài thuyết trình bạn mở từ tệp có thể không có layout thuộc loại yêu cầu; trong trường hợp đó `getByType` trả về `null`, vì vậy hãy kiểm tra kết quả trước khi truyền tiếp.

## **Đặt Kích thước Slide**

Một bài thuyết trình mới sử dụng slide 4:3 có kích thước 720 × 540 điểm (10 × 7.5 inch). Để tạo slide màn hình rộng thay thế, gọi phương thức [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) của thuộc tính [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) của bài thuyết trình, với một giá trị [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) và một giá trị [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Kiểu tỉ lệ cho Aspose.Slides biết cách xử lý các hình dạng đã có trên slide; `DoNotScale` giữ nguyên chúng, là lựa chọn phù hợp cho một bài thuyết trình chưa có nội dung.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kịch bản in ra `Slide size: 960 x 540 points`, tương đương 13.33 × 7.5 inch, và ghi tệp `widescreen.pptx`. `SlideSizeType.OnScreen16x9` có tỷ lệ 16:9 giống nhau nhưng nhỏ hơn: 720 × 405 điểm.

## **Câu hỏi thường gặp**

**Các vị trí và kích thước được đo bằng đơn vị gì?**  
Đơn vị là điểm. Một inch bằng 72 điểm, vì vậy slide 4:3 mặc định có kích thước 720 × 540 điểm, và slide màn hình rộng 16:9 có kích thước 960 × 540 điểm.

**Tôi có thể lưu một bài thuyết trình mới ở định dạng nào?**  
Bất kỳ giá trị nào của enumeration [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), ví dụ `SaveFormat.Ppt` cho PowerPoint 97–2003, `SaveFormat.Odp` cho OpenDocument, hoặc `SaveFormat.Pdf`. Đối với xuất PDF, xem [Convert PowerPoint to PDF](/slides/vi/nodejs-net/convert-powerpoint-to-pdf/).

**Tại sao bài thuyết trình đã lưu chứa văn bản "Evaluation only"?**  
Nếu không có giấy phép, Aspose.Slides sẽ thêm một dấu nước đánh giá vào các slide mà nó lưu. Áp dụng giấy phép như mô tả trong [Licensing](/slides/vi/nodejs-net/licensing/) để loại bỏ nó.

**Tại sao tôi nên gọi `dispose`?**  
Đối tượng `Presentation` được hỗ trợ bởi một đối tượng .NET giữ bộ nhớ và các tài nguyên khác. Gọi `dispose` giải phóng chúng ngay khi bạn không còn cần bài thuyết trình, và gọi trong khối `finally` đảm bảo chúng được giải phóng ngay cả khi xảy ra lỗi.