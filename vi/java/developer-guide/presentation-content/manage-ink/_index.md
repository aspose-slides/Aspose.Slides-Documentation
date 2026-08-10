---
title: Quản lý các đối tượng mực trong PowerPoint bằng Java
linktitle: Quản lý Mực
type: docs
weight: 95
url: /vi/java/manage-ink/
keywords:
- mực
- đối tượng mực
- dấu mực
- quản lý mực
- vẽ mực
- vẽ
- xuất mực
- kết xuất mực
- ẩn mực
- IInkOptions
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các đối tượng mực trong PowerPoint, chỉnh sửa dấu và thuộc tính bàn chải, và kiểm soát hiển thị mực trong quá trình xuất PDF, HTML, SVG, TIFF và ảnh với Aspose.Slides cho Java."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng mực cho phép bạn vẽ các nét tự do. Mực có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.

Aspose.Slides cung cấp các kiểu cần thiết để làm việc với các đối tượng mực. Ví dụ, giao diện [IInk](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iink/) đại diện cho một đối tượng mực trên slide.

## **Sự khác biệt giữa Đối tượng thường và Đối tượng mực**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng shape. Ở dạng đơn giản nhất, shape là một container định nghĩa khu vực của chính đối tượng (khung của nó) cùng với các thuộc tính như kích thước container, hình dạng và nền. Để biết thêm thông tin, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/java/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước. Kích thước khu vực container được xác định bởi các phương thức tiêu chuẩn [IShape.getWidth](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getWidth--) và [IShape.getHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getHeight--):

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu mực**

Dấu mực là một yếu tố cơ bản được dùng để ghi lại quỹ đạo của bút khi người dùng viết mực kỹ thuật số. Một dấu lưu trữ một chuỗi các điểm nối nhau.

Dạng mã hoá đơn giản nhất chỉ định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm nối nhau được render, chúng tạo thành một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính bàn chải để vẽ**

Bàn chải được dùng để vẽ các đường nối các điểm của một dấu mực. Bàn chải có màu và kích thước riêng, được đại diện bởi các phương thức [IInkBrush.getColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkbrush/#getColor--) và [IInkBrush.getSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkbrush/#getSize--).

### **Đặt màu bàn chải mực**

Đoạn mã Java này cho thấy cách đặt màu cho bàn chải mực:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Đặt kích thước bàn chải mực**

Đoạn mã Java này cho thấy cách đặt kích thước cho bàn chải mực:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Thông thường, chiều rộng và chiều cao của bàn chải không khớp nhau, vì vậy PowerPoint không hiển thị kích thước bàn chải (phần dữ liệu tương ứng sẽ bị làm mờ). Khi chiều rộng và chiều cao của bàn chải khớp, PowerPoint hiển thị kích thước của nó như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của các bàn chải — nó luôn giả định độ dày đường nét bằng 0 (xem hình ảnh trước).

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng mực, phải tính đến kích thước bàn chải của các dấu. Ở đây, đối tượng mục tiêu (dấu văn bản viết tay) đã được thu phóng tới kích thước của container (khung). Khi kích thước container thay đổi, kích thước bàn chải vẫn không thay đổi, và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint sử dụng hành vi tương tự cho các đối tượng văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát hiển thị mực trong quá trình xuất và render**

Aspose.Slides cung cấp giao diện [IInkOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/) để kiểm soát cách các đối tượng mực xuất hiện trong đầu ra được xuất hoặc render. Bạn có thể dùng các thuộc tính của nó để ẩn hoàn toàn mực hoặc thay đổi cách các thao tác mặt nạ bàn chải mực được diễn giải.

Các tùy chọn mực có sẵn thông qua các tùy chọn xuất hoặc render cho một số loại đầu ra:

| Đầu ra | Thuộc tính tùy chọn mực |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/vi/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Các phương thức sau của [IInkOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/) cung cấp cùng hai cài đặt:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#getHideInk--) xác định liệu các đối tượng mực có được bao gồm trong đầu ra hay không. Giá trị mặc định là `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) xác định liệu một thao tác mặt nạ có được diễn giải như độ trong suốt khi render bàn chải mực hay không. Giá trị mặc định là `true`; gọi [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) với `false` để sử dụng thao tác ROP thay thế.

### **Ẩn đối tượng mực trong đầu ra PDF**

Mặc định, các đối tượng mực vẫn hiển thị khi xuất. Để tạo đầu ra sạch sẽ không có chú thích viết tay hoặc nội dung mực khác, gọi [IInkOptions.setHideInk](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) với `true`.

Đoạn mã Java sau xuất bản trình chiếu sang PDF trong khi ẩn tất cả các đối tượng mực:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ẩn đối tượng mực khi render slide dưới dạng hình ảnh**

Để ẩn các đối tượng mực khi render slide dưới dạng ảnh bitmap, cấu hình [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/renderingoptions/#getInkOptions--) và truyền các tùy chọn render cho [ISlide.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Đoạn mã Java sau render slide đầu tiên thành ảnh PNG mà không có đối tượng mực:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Kiểm soát việc render mặt nạ mực**

Cài đặt [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) kiểm soát cách các thao tác mặt nạ được diễn giải khi render bàn chải mực. Giá trị mặc định là `true`, sử dụng độ trong suốt. Để dùng thao tác ROP thay thế, gọi [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) với `false`.

Đoạn mã Java sau xuất một slide sang SVG và sử dụng render dựa trên ROP cho các thao tác mặt nạ mực:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

Cài đặt tương tự có thể được áp dụng qua [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/tiffoptions/#getInkOptions--) khi xuất bản trình chiếu hoặc render slide sang TIFF.

### **Chọn ẩn hay bảo tồn mực**

Khi bạn cần một phiên bản sạch sẽ của bản trình chiếu có chú thích để phân phối mà không có dấu đánh dấu xem xét, gọi [IInkOptions.setHideInk](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) với `true` trong quá trình xuất.

Giữ [IInkOptions.getHideInk](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#getHideInk--) ở giá trị mặc định `false` khi các chú thích mực là một phần của nội dung dự định, chẳng hạn như bình luận đánh giá, ghi chú viết tay, đánh dấu hoặc bản vẽ cần hiển thị trong kết quả xuất. Điều này cho phép các ứng dụng tạo ra các đầu ra đánh giá và cuối cùng riêng biệt từ cùng một bản trình chiếu mà không cần thay đổi các đối tượng mực nguồn.

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi màu hoặc kích thước của một nét mực hiện có không?**

Có. Lấy dấu từ [IInk.getTraces](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iink/#getTraces--), sau đó thay đổi [IInkTrace.getBrush](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinktrace/#getBrush--). Gọi [IInkBrush.setColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) hoặc [IInkBrush.setSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) để thay đổi bàn chải.

**Việc ẩn mực có thay đổi bản trình chiếu nguồn không?**

Không. Gọi [IInkOptions.setHideInk](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) chỉ ảnh hưởng đến kết quả render hoặc xuất; nó không loại bỏ hoặc sửa đổi các đối tượng mực trong bản trình chiếu nguồn.

**Các định dạng xuất nào hỗ trợ tùy chọn mực?**

Bạn có thể cấu hình tùy chọn mực cho PDF, HTML, SVG, TIFF và ảnh slide bitmap thông qua các tùy chọn xuất hoặc render tương ứng được liệt kê ở trên.

**Đọc thêm**

* Để đọc về các hình dạng nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/java/powerpoint-shapes/).
* Để biết thêm về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/java/shape-effective-properties/#get-effective-font-height-value).
* Để biết chi tiết về xuất PDF, xem [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/vi/java/convert-powerpoint-to-pdf/).
* Để biết chi tiết về xuất HTML, xem [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/vi/java/convert-powerpoint-to-html/).
* Để biết chi tiết về xuất SVG, xem [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/vi/java/render-a-slide-as-an-svg-image/).
* Để biết chi tiết về xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/vi/java/convert-powerpoint-to-tiff/).
* Để biết chi tiết về render slide thành ảnh, xem [Convert Presentation Slides to Images](https://docs.aspose.com/slides/vi/java/convert-slide/).