---
title: Quản lý các đối tượng mực trong PowerPoint bằng PHP
linktitle: Quản lý Mực
type: docs
weight: 95
url: /vi/php-java/manage-ink/
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
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint, chỉnh sửa dấu vết và thuộc tính brush, và kiểm soát hiển thị mực khi xuất PDF, HTML, SVG, TIFF và hình ảnh với Aspose.Slides cho PHP qua Java."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng mực cho phép bạn vẽ các nét tự do. Mực có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.

Aspose.Slides cung cấp các kiểu cần thiết để làm việc với các đối tượng mực. Ví dụ, lớp [Ink](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ink/) đại diện cho một đối tượng mực trên slide.

## **Sự khác biệt giữa Đối tượng Thông thường và Đối tượng Mực**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) . Trong dạng đơn giản nhất, một shape là một container định nghĩa khu vực của chính đối tượng (khung của nó) cùng với các thuộc tính như kích thước container, hình dạng và nền. Để biết thêm thông tin, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/php-java/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước của khu vực container được xác định bằng các phương thức tiêu chuẩn [Shape.getWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getWidth) và [Shape.getHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết Mực**

Một dấu vết mực là yếu tố cơ bản được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết mực kỹ thuật số. Một dấu vết lưu trữ một chuỗi các điểm kết nối.

Dạng mã hoá đơn giản nhất chỉ định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm kết nối được vẽ, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Brush để Vẽ**

Brush được sử dụng để vẽ các đường nối các điểm của một dấu vết mực. Brush có màu và kích thước riêng, được biểu diễn bằng các phương thức [InkBrush.getColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkbrush/#getColor) và [InkBrush.getSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkbrush/#getSize).

### **Đặt Màu Brush Mực**

Đoạn mã PHP sau cho thấy cách đặt màu cho brush mực:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Đặt Kích thước Brush Mực**

Đoạn mã PHP sau cho thấy cách đặt kích thước cho brush mực:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Thông thường, chiều rộng và chiều cao của brush không khớp nhau, vì vậy PowerPoint không hiển thị kích thước brush (phần dữ liệu tương ứng bị xám). Khi chiều rộng và chiều cao của brush khớp nhau, PowerPoint hiển thị kích thước của nó như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để rõ hơn, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của brush — nó luôn giả định độ dày đường bằng 0 (xem hình ảnh trước).

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng mực, phải tính đến kích thước brush của các dấu vết. Ở đây, đối tượng mục tiêu (dấu vết văn bản viết tay) đã được phóng to tới kích thước của container (khung). Khi kích thước của container thay đổi, kích thước brush vẫn không đổi, và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint sử dụng hành vi tương tự cho các đối tượng văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát Hiển thị Mực khi Xuất và Kết xuất**

Aspose.Slides cung cấp lớp [InkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/) để kiểm soát cách các đối tượng mực xuất hiện trong đầu ra đã xuất hoặc kết xuất. Bạn có thể sử dụng các thuộc tính của nó để ẩn hoàn toàn mực hoặc thay đổi cách các thao tác mask brush mực được diễn giải.

Các tùy chọn mực có sẵn thông qua các tùy chọn xuất hoặc kết xuất cho một số loại đầu ra:

| Output | Ink options property |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Các phương thức [InkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/) sau đây cung cấp cùng hai cài đặt:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#getHideInk) xác định liệu các đối tượng mực có được bao gồm trong đầu ra hay không. Giá trị mặc định là `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) xác định liệu một thao tác mask có được diễn giải là độ trong suốt khi kết xuất brush mực hay không. Giá trị mặc định là `true`; gọi [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) với `false` để sử dụng thao tác ROP thay thế.

### **Ẩn Đối tượng Mực trong Đầu ra PDF**

Mặc định, các đối tượng mực vẫn hiển thị khi xuất. Để tạo ra đầu ra sạch sẽ không có chú thích viết tay hoặc nội dung mực khác, gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#setHideInk) với `true`.

Ví dụ PHP sau xuất bản trình chiếu sang PDF trong khi ẩn tất cả các đối tượng mực:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Ẩn Đối tượng Mực Khi Kết xuất Slide thành Ảnh**

Để ẩn các đối tượng mực khi kết xuất slide thành ảnh bitmap, cấu hình [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/renderingoptions/#getInkOptions) và truyền các tùy chọn kết xuất cho [Slide.getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage).

Ví dụ PHP sau kết xuất slide đầu tiên thành ảnh PNG mà không có đối tượng mực:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Kiểm soát Kết xuất Mask Mực**

Cài đặt [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) điều khiển cách các thao tác mask được diễn giải khi kết xuất brush mực. Giá trị mặc định là `true`, sử dụng độ trong suốt. Để sử dụng thao tác ROP thay thế, gọi [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) với `false`.

Ví dụ PHP dưới đây xuất một slide sang SVG và sử dụng kết xuất dựa trên ROP cho các thao tác mask mực:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Cùng cài đặt này có thể được áp dụng thông qua [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tiffoptions/#getInkOptions) khi xuất bản trình chiếu hoặc kết xuất slide thành TIFF.

### **Chọn Ẩn hay Giữ lại Mực**

Khi bạn cần một phiên bản sạch sẽ của bản trình chiếu có chú thích để phân phối mà không có dấu hiệu đánh giá, gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#setHideInk) với `true` trong quá trình xuất.

Giữ [InkOptions.getHideInk](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#getHideInk) ở giá trị mặc định `false` khi các chú thích mực là một phần của nội dung dự định, chẳng hạn như bình luận xem xét, ghi chú viết tay, phần nổi bật hoặc bản vẽ cần hiển thị trong kết quả xuất. Điều này cho phép ứng dụng tạo ra các bản xuất đánh giá và bản cuối cùng riêng biệt từ cùng một trình chiếu mà không cần sửa đổi các đối tượng mực gốc.

## **FAQ**

**Tôi có thể thay đổi màu hoặc kích thước của nét mực đã tồn tại không?**

Có. Lấy dấu vết từ [Ink.getTraces](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ink/#getTraces), sau đó thay đổi [InkTrace.getBrush](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inktrace/#getBrush). Gọi [InkBrush.setColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkbrush/#setColor) hoặc [InkBrush.setSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkbrush/#setSize) để thay đổi brush.

**Việc ẩn mực có thay đổi trình chiếu nguồn không?**

Không. Gọi [InkOptions.setHideInk](https://reference.aspose.com/slides/vi/php-java/aspose.slides/inkoptions/#setHideInk) chỉ ảnh hưởng đến kết quả đã kết xuất hoặc xuất; nó không xóa hoặc sửa đổi các đối tượng mực trong trình chiếu nguồn.

**Định dạng xuất nào hỗ trợ tùy chọn mực?**

Bạn có thể cấu hình tùy chọn mực cho PDF, HTML, SVG, TIFF và ảnh slide bitmap thông qua các tùy chọn xuất hoặc kết xuất tương ứng được hiển thị ở trên.

**Đọc thêm**

* Để tìm hiểu về shape nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/php-java/powerpoint-shapes/).
* Để biết thêm về giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/php-java/shape-effective-properties/#get-effective-font-height-value).
* Để biết chi tiết về xuất PDF, xem [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/vi/php-java/convert-powerpoint-to-pdf/).
* Để biết chi tiết về xuất HTML, xem [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/vi/php-java/convert-powerpoint-to-html/).
* Để biết chi tiết về xuất SVG, xem [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/vi/php-java/render-a-slide-as-an-svg-image/).
* Để biết chi tiết về xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/vi/php-java/convert-powerpoint-to-tiff/).
* Để biết chi tiết về kết xuất slide thành ảnh, xem [Convert Presentation Slides to Images](https://docs.aspose.com/slides/vi/php-java/convert-slide/).