---
title: Quản lý các đối tượng mực trong bài thuyết trình bằng JavaScript
linktitle: Quản lý mực
type: docs
weight: 95
url: /vi/nodejs-java/manage-ink/
keywords:
- mực
- đối tượng mực
- dấu vết mực
- quản lý mực
- vẽ mực
- vẽ
- xuất mực
- kết xuất mực
- ẩn mực
- InkOptions
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint, chỉnh sửa dấu vết và thuộc tính brush, và kiểm soát giao diện mực khi xuất PDF, HTML, SVG, TIFF và ảnh với Aspose.Slides cho Node.js qua Java."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng mực cho phép bạn vẽ các nét tự do. Mực có thể được sử dụng để làm nổi bật các đối tượng khác, thể hiện các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.

Aspose.Slides cung cấp các kiểu cần thiết để làm việc với các đối tượng mực. Ví dụ, lớp [Ink](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ink/) đại diện cho một đối tượng mực trên slide.

## **Sự khác biệt giữa Đối tượng thường và Đối tượng mực**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng shape. Ở dạng đơn giản nhất, shape là một container xác định khu vực của chính đối tượng (khung của nó) cùng với các thuộc tính như kích thước container, hình dạng và nền. Để biết thêm chi tiết, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó sẽ bỏ qua mọi thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước khu vực container được xác định bằng các phương thức tiêu chuẩn [Shape.getWidth](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getWidth--) và [Shape.getHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết mực**

Một dấu vết mực là thành phần cơ bản được dùng để ghi lại quỹ đạo của bút khi người dùng viết mực kỹ thuật số. Một dấu vết lưu trữ một dãy các điểm liên tiếp.

Dạng mã hoá đơn giản nhất xác định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm liên tiếp được vẽ, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Brush để Vẽ**

Brush được dùng để vẽ các đường nối các điểm của một dấu vết mực. Brush có màu và kích thước riêng, được biểu diễn bằng các phương thức [InkBrush.getColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkbrush/#getColor--) và [InkBrush.getSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Đặt màu Brush cho mực**

Đoạn mã JavaScript sau cho thấy cách đặt màu cho brush mực:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Đặt kích thước Brush cho mực**

Đoạn mã JavaScript sau cho thấy cách đặt kích thước cho brush mực:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Thông thường, chiều rộng và chiều cao của brush không bằng nhau, vì vậy PowerPoint không hiển thị kích thước brush (phần dữ liệu tương ứng bị xám). Khi chiều rộng và chiều cao của brush bằng nhau, PowerPoint hiển thị kích thước như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của các brush — nó luôn giả định rằng độ dày đường vẽ là 0 (xem hình ảnh trước).

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng mực, phải tính đến kích thước brush của các dấu vết. Ở đây, đối tượng mục tiêu (dấu vết văn bản viết tay) đã được co giãn tới kích thước của container (khung). Khi kích thước container thay đổi, kích thước brush vẫn cố định, và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint áp dụng hành vi tương tự cho các đối tượng văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát Hiển thị Mực khi Xuất và Khi Render**

Aspose.Slides cung cấp lớp [InkOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/) để kiểm soát cách các đối tượng mực xuất hiện trong kết quả xuất khẩu hoặc render. Bạn có thể sử dụng các thuộc tính của nó để ẩn hoàn toàn mực hoặc thay đổi cách các thao tác mask của brush mực được diễn giải.

Các tùy chọn mực có sẵn thông qua các tùy chọn xuất hoặc render cho một số loại đầu ra:

| Đầu ra | Thuộc tính tùy chọn mực |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Ảnh slide | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Các phương thức [InkOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/) sau khai thác cùng hai cài đặt:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#getHideInk--) xác định liệu các đối tượng mực có được đưa vào đầu ra hay không. Giá trị mặc định là `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) xác định liệu một thao tác mask có được diễn giải là độ trong suốt khi render brush mực hay không. Giá trị mặc định là `true`; gọi [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) với `false` để sử dụng thao tác ROP thay thế.

### **Ẩn các Đối tượng mực trong Đầu ra PDF**

Mặc định, các đối tượng mực vẫn hiển thị khi xuất. Để tạo ra đầu ra sạch sẽ không có chú thích viết tay hoặc bất kỳ nội dung mực nào, gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) với `true`.

Đoạn JavaScript sau xuất bản trình chiếu ra PDF đồng thời ẩn tất cả các đối tượng mực:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ẩn các Đối tượng mực Khi Render Slide dưới dạng Ảnh**

Để ẩn các đối tượng mực khi render các slide dưới dạng ảnh bitmap, cấu hình [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) và truyền các tùy chọn render vào [Slide.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Đoạn JavaScript sau render slide đầu tiên dưới dạng ảnh PNG mà không có đối tượng mực:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Kiểm soát Render Mask cho Mực**

Cài đặt [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) kiểm soát cách các thao tác mask được diễn giải khi render brush mực. Giá trị mặc định là `true`, sử dụng độ trong suốt. Để dùng thao tác ROP thay thế, gọi [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) với `false`.

Đoạn JavaScript sau xuất một slide ra SVG và sử dụng render dựa trên ROP cho các thao tác mask của mực:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Cài đặt tương tự cũng có thể áp dụng qua [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) khi xuất bản trình chiếu hoặc render slide sang TIFF.

### **Chọn Ẩn hay Giữ lại Mực**

Khi bạn cần một phiên bản sạch sẽ của bản trình chiếu có chú thích để phân phối mà không có dấu hiệu duyệt, gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) với `true` trong quá trình xuất.

Để giữ lại mực, để [InkOptions.getHideInk](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#getHideInk--) ở giá trị mặc định `false` khi các chú thích mực là một phần nội dung mong muốn, chẳng hạn bình luận duyệt, ghi chú viết tay, gạch chân hoặc bản vẽ cần hiển thị trong kết quả xuất. Điều này cho phép các ứng dụng tạo ra các đầu ra duyệt và cuối cùng riêng biệt từ cùng một bản trình chiếu mà không sửa đổi các đối tượng mực nguồn.

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi màu hoặc kích thước của một nét mực đã tồn tại không?**

Có. Lấy dấu vết từ [Ink.getTraces](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ink/#getTraces--) và sau đó thay đổi [InkTrace.getBrush](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inktrace/#getBrush--). Gọi [InkBrush.setColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) hoặc [InkBrush.setSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) để thay đổi brush.

**Việc ẩn mực có thay đổi bản trình chiếu nguồn không?**

Không. Gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) chỉ ảnh hưởng tới kết quả render hoặc xuất; nó không xóa hay sửa đổi các đối tượng mực trong bản trình chiếu nguồn.

**Các định dạng xuất nào hỗ trợ tùy chọn mực?**

Bạn có thể cấu hình tùy chọn mực cho PDF, HTML, SVG, TIFF và ảnh slide bitmap thông qua các tùy chọn xuất hoặc render tương ứng được liệt kê ở trên.

**Đọc thêm**

* Để tìm hiểu về shape nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/nodejs-java/powerpoint-shapes/).
* Để biết thêm về giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Để biết chi tiết về xuất PDF, xem [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/vi/nodejs-java/convert-powerpoint-to-pdf/).
* Để biết chi tiết về xuất HTML, xem [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/vi/nodejs-java/convert-powerpoint-to-html/).
* Để biết chi tiết về xuất SVG, xem [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/).
* Để biết chi tiết về xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/vi/nodejs-java/convert-powerpoint-to-tiff/).
* Để biết chi tiết về render slide thành ảnh, xem [Convert Presentation Slides to Images](https://docs.aspose.com/slides/vi/nodejs-java/convert-slide/).