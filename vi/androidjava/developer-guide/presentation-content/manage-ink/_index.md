---
title: Quản lý Đối tượng Bút trong Bản trình chiếu trên Android
linktitle: Quản lý Bút
type: docs
weight: 95
url: /vi/androidjava/manage-ink/
keywords:
- bút
- đối tượng bút
- dấu vết bút
- quản lý bút
- vẽ bút
- vẽ
- xuất bút
- render bút
- ẩn bút
- IInkOptions
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các đối tượng bút PowerPoint, chỉnh sửa dấu vết và thuộc tính cọ, và kiểm soát hiển thị bút khi xuất PDF, HTML, SVG, TIFF và hình ảnh với Aspose.Slides cho Android."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng bút cho phép bạn vẽ các nét tự do. Bút có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.

Aspose.Slides cung cấp các kiểu cần thiết để làm việc với các đối tượng bút. Ví dụ, giao diện [IInk](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iink/) đại diện cho một đối tượng bút trên slide.

## **Sự khác biệt giữa các đối tượng thường và đối tượng bút**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng hình dạng. Ở dạng đơn giản nhất, một hình dạng là một vùng chứa xác định khu vực của chính đối tượng (khung của nó) cùng với các thuộc tính như kích thước vùng chứa, hình dạng và nền. Để biết thêm thông tin, xem [Định dạng bố cục hình dạng](https://docs.aspose.com/slides/vi/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng bút, nó bỏ qua mọi thuộc tính của khung đối tượng (vùng chứa) ngoại trừ kích thước của nó. Kích thước của khu vực vùng chứa được xác định bằng các phương thức tiêu chuẩn [IShape.getWidth](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getWidth--) và [IShape.getHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getHeight--)：

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết bút**

Một dấu vết bút là yếu tố cơ bản được dùng để ghi lại quỹ đạo của bút khi người dùng viết bút kỹ thuật số. Một dấu vết lưu trữ một chuỗi các điểm nối nhau.

Dạng mã hóa đơn giản nhất chỉ xác định tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm nối nhau được vẽ ra, chúng tạo thành một hình ảnh như sau：

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính cọ vẽ**

Cọ được dùng để vẽ các đường nối các điểm của một dấu vết bút. Cọ có màu và kích thước riêng, được biểu diễn bằng các phương thức [IInkBrush.getColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkbrush/#getColor--) và [IInkBrush.getSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkbrush/#getSize--)。

### **Đặt màu cọ bút**

Đoạn mã Java này cho thấy cách đặt màu cho cọ bút：

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **Đặt kích thước cọ bút**

Đoạn mã Java này cho thấy cách đặt kích thước cho cọ bút：

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Thông thường, chiều rộng và chiều cao của cọ không khớp nhau, vì vậy PowerPoint không hiển thị kích thước cọ (phần dữ liệu tương ứng bị xám). Khi chiều rộng và chiều cao của cọ khớp, PowerPoint sẽ hiển thị kích thước như sau：

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng bút và xem xét các kích thước quan trọng：

![ink_powerpoint4](ink_powerpoint4.png)

Vùng chứa (khung) không tính đến kích thước của các cọ — nó luôn giả định độ dày đường nét bằng 0 (xem ảnh trước).

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng bút, cần tính đến kích thước cọ của các dấu vết. Ở đây, đối tượng mục tiêu (dấu vết văn bản viết tay) đã được thu phóng tới kích thước của vùng chứa (khung). Khi kích thước của vùng chứa thay đổi, kích thước cọ giữ nguyên, và ngược lại。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint áp dụng hành vi tương tự cho các đối tượng văn bản：

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát hiển thị bút khi xuất và render**

Aspose.Slides cung cấp giao diện [IInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/) để kiểm soát cách các đối tượng bút xuất hiện trong kết quả xuất hoặc render. Bạn có thể sử dụng các thuộc tính của nó để ẩn bút hoàn toàn hoặc thay đổi cách các thao tác mặt nạ cọ bút được diễn giải.

Các tùy chọn bút có sẵn thông qua các tùy chọn xuất hoặc render cho một số loại đầu ra：

| Đầu ra | Thuộc tính tùy chọn bút |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Các phương thức sau của [IInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/) cung cấp cùng hai cài đặt:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) xác định liệu các đối tượng bút có được bao gồm trong đầu ra hay không. Giá trị mặc định là `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) xác định liệu một thao tác mặt nạ có được diễn giải là độ mờ khi render cọ bút hay không. Giá trị mặc định là `true`; gọi [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) với `false` để sử dụng thao tác ROP thay thế.

### **Ẩn đối tượng bút trong đầu ra PDF**

Theo mặc định, các đối tượng bút vẫn hiển thị khi xuất. Để tạo một đầu ra sạch sẽ mà không có chú thích viết tay hoặc nội dung bút khác, gọi [IInkOptions.setHideInk](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) với `true`.

Đoạn mã Java sau xuất bản trình chiếu ra PDF đồng thời ẩn tất cả các đối tượng bút：

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

### **Ẩn đối tượng bút khi render slide thành hình ảnh**

Để ẩn các đối tượng bút khi render slide thành ảnh bitmap, cấu hình [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) và truyền các tùy chọn render vào [ISlide.getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Đoạn mã Java sau render slide đầu tiên thành ảnh PNG mà không có đối tượng bút：

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

### **Kiểm soát việc render mặt nạ bút**

Cài đặt [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) kiểm soát cách các thao tác mặt nạ được diễn giải khi render cọ bút. Giá trị mặc định là `true`, sử dụng độ mờ. Để dùng thao tác ROP thay thế, gọi [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) với `false`.

Đoạn mã Java sau xuất một slide ra SVG và sử dụng render dựa trên ROP cho các thao tác mặt nạ bút：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Cài đặt tương tự cũng có thể áp dụng qua [TiffOptions.getInkOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) khi xuất bản trình chiếu hoặc render slide sang TIFF.

### **Chọn ẩn hay giữ lại bút**

Khi bạn cần một phiên bản sạch sẽ của bản trình chiếu có chú thích để phân phối mà không có dấu hiệu xem xét, hãy gọi [IInkOptions.setHideInk](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) với `true` trong quá trình xuất.

Để giữ lại bút, để [IInkOptions.getHideInk](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) ở giá trị mặc định `false` khi các chú thích bút là một phần nội dung dự định, chẳng hạn như bình luận đánh giá, ghi chú viết tay, tô sáng hoặc bản vẽ cần hiển thị trong kết quả xuất. Điều này cho phép các ứng dụng tạo ra các đầu ra đánh giá và cuối cùng riêng biệt từ cùng một bản trình chiếu mà không cần sửa đổi các đối tượng bút nguồn.

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi màu hoặc kích thước của một nét bút đã tồn tại không?**

Có. Lấy dấu vết từ [IInk.getTraces](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iink/#getTraces--), sau đó thay đổi [IInkTrace.getBrush](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinktrace/#getBrush--). Gọi [IInkBrush.setColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) hoặc [IInkBrush.setSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) để thay đổi cọ.

**Việc ẩn bút có thay đổi bản trình bày nguồn không?**

Không. Gọi [IInkOptions.setHideInk](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) chỉ ảnh hưởng tới kết quả render hoặc xuất; nó không loại bỏ hay sửa đổi các đối tượng bút trong bản trình bày nguồn.

**Định dạng xuất nào hỗ trợ tùy chọn bút?**

Bạn có thể cấu hình tùy chọn bút cho PDF, HTML, SVG, TIFF và hình ảnh slide bitmap thông qua các tùy chọn xuất hoặc render tương ứng được liệt kê ở trên.

**Đọc thêm**

* Để đọc về hình dạng nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/androidjava/powerpoint-shapes/) .
* Để biết thêm thông tin về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/androidjava/shape-effective-properties/#get-effective-font-height-value) .
* Để biết chi tiết về xuất PDF, xem [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/vi/androidjava/convert-powerpoint-to-pdf/) .
* Để biết chi tiết về xuất HTML, xem [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/vi/androidjava/convert-powerpoint-to-html/) .
* Để biết chi tiết về xuất SVG, xem [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/vi/androidjava/render-a-slide-as-an-svg-image/) .
* Để biết chi tiết về xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/vi/androidjava/convert-powerpoint-to-tiff/) .
* Để biết chi tiết về render slide thành hình ảnh, xem [Convert Presentation Slides to Images](https://docs.aspose.com/slides/vi/androidjava/convert-slide/) .