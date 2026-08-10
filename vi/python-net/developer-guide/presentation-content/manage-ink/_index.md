---
title: Quản lý Đối tượng Mực trong PowerPoint bằng Python
linktitle: Quản lý Mực
type: docs
weight: 95
url: /vi/python-net/manage-ink/
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
- trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các đối tượng mực PowerPoint, chỉnh sửa dấu vết và thuộc tính cọ, và kiểm soát hiển thị mực khi xuất PDF, HTML, SVG, TIFF và ảnh với Aspose.Slides cho Python qua .NET."
---
## **Giới thiệu**

PowerPoint cung cấp tính năng mực cho phép bạn vẽ các nét tự do. Mực có thể được sử dụng để làm nổi bật các đối tượng khác, hiển thị các kết nối và quy trình, và thu hút sự chú ý đến các mục cụ thể trên một slide.

Namespace [aspose.slides.ink](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/) chứa các lớp cần thiết để làm việc với các đối tượng mực. Ví dụ, lớp [Ink](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/ink/) đại diện cho một đối tượng mực trên slide.

## **Sự khác biệt giữa Đối tượng Thông thường và Đối tượng Ink**

Các đối tượng trên một slide PowerPoint thường được biểu diễn bằng các đối tượng hình dạng. Ở dạng đơn giản nhất, một hình dạng là một container định nghĩa khu vực của chính đối tượng (khung) cùng với các thuộc tính như kích thước container, hình dạng và nền. Để biết thêm thông tin, xem [Shape Layout Format](https://docs.aspose.com/slides/vi/python-net/shape-manipulations/#access-layout-formats-for-shape).

Tuy nhiên, khi PowerPoint xử lý một đối tượng mực, nó bỏ qua tất cả các thuộc tính của khung đối tượng (container) ngoại trừ kích thước của nó. Kích thước của khu vực container được xác định bởi các thuộc tính tiêu chuẩn [Ink.width](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/ink/width/) và [Ink.height](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Dấu vết Ink**

Một dấu vết mực là thành phần cơ bản được sử dụng để ghi lại quỹ đạo của bút khi người dùng viết mực kỹ thuật số. Một dấu vết lưu trữ một chuỗi các điểm được nối liền.

Dạng mã hoá đơn giản nhất chỉ định các tọa độ X và Y của mỗi điểm mẫu. Khi tất cả các điểm được nối lại và hiển thị, chúng tạo ra một hình ảnh như sau:

![ink_powerpoint2](ink_powerpoint2.png)

## **Thuộc tính Cọ vẽ**

Một cọ được dùng để vẽ các đường nối các điểm của một dấu vết mực. Các thuộc tính [InkBrush.color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/inkbrush/color/) và [InkBrush.size](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/inkbrush/size/) kiểm soát màu và kích thước của nó.

### **Đặt màu Cọ Ink**

Đoạn mã Python này cho thấy cách đặt màu cho một cọ mực:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Đặt kích thước Cọ Ink**

Đoạn mã Python này cho thấy cách đặt kích thước cho một cọ mực:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Thông thường, chiều rộng và chiều cao của một cọ không khớp nhau, vì vậy PowerPoint không hiển thị kích thước cọ (phần dữ liệu tương ứng bị xám). Khi chiều rộng và chiều cao của cọ khớp nhau, PowerPoint hiển thị kích thước như sau:

![ink_powerpoint3](ink_powerpoint3.png)

Để làm rõ, hãy tăng chiều cao của đối tượng mực và xem lại các kích thước quan trọng:

![ink_powerpoint4](ink_powerpoint4.png)

Container (khung) không tính đến kích thước của các cọ — nó luôn giả định độ dày dòng bằng 0 (xem hình ảnh trước).

Do đó, để xác định khu vực hiển thị của toàn bộ đối tượng mực, phải tính đến kích thước cọ của các dấu vết. Ở đây, đối tượng mục tiêu (dấu vết văn bản viết tay) đã được mở rộng đến kích thước của container (khung). Khi kích thước container thay đổi, kích thước cọ vẫn không đổi, và ngược lại.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint sử dụng hành vi tương tự cho các đối tượng văn bản:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kiểm soát Hiển thị Mực khi Xuất và Kết xuất**

Aspose.Slides cung cấp lớp [InkOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/) để kiểm soát cách các đối tượng mực xuất hiện trong kết quả xuất hoặc kết xuất. Bạn có thể dùng các thuộc tính của nó để ẩn hoàn toàn mực hoặc thay đổi cách các thao tác mặt nạ cọ mực được diễn giải.

Các tùy chọn mực có sẵn thông qua các tùy chọn xuất hoặc kết xuất cho một số loại đầu ra:

| Đầu ra | Thuộc tính tùy chọn Ink |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Ảnh slide | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Hai cài đặt sau có sẵn thông qua các thuộc tính này:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/hide_ink/) xác định có bao gồm các đối tượng mực trong đầu ra hay không. Giá trị mặc định là `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) xác định có diễn giải thao tác mặt nạ là độ trong suốt khi kết xuất một cọ mực không. Giá trị mặc định là `True`; đặt thành `False` để sử dụng thao tác ROP thay thế.

### **Ẩn Đối tượng Mực trong Đầu ra PDF**

Mặc định, các đối tượng mực vẫn hiển thị khi xuất. Đặt [InkOptions.hide_ink](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/hide_ink/) thành `True` khi bạn cần một đầu ra sạch sẽ không có chú thích viết tay hoặc nội dung mực khác.

Đoạn Python dưới đây xuất một bản trình chiếu sang PDF đồng thời ẩn tất cả các đối tượng mực:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ẩn Đối tượng Mực Khi Kết xuất Slide thành Ảnh**

Để ẩn các đối tượng mực khi kết xuất slide thành ảnh bitmap, cấu hình [RenderingOptions.ink_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/renderingoptions/ink_options/) và truyền các tùy chọn kết xuất vào phương thức [Slide.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/).

Đoạn Python dưới đây kết xuất slide đầu tiên thành ảnh PNG mà không có đối tượng mực:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Kiểm soát Kết xuất Mặt nạ Ink**

Thuộc tính [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) kiểm soát cách các thao tác mặt nạ được diễn giải khi kết xuất cọ mực. Giá trị mặc định là `True`, sử dụng độ trong suốt. Đặt thuộc tính này thành `False` để dùng thao tác ROP thay thế.

Đoạn Python dưới đây xuất một slide sang SVG và sử dụng kết xuất dựa trên ROP cho các thao tác mặt nạ mực:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Cài đặt tương tự có thể được áp dụng qua [TiffOptions.ink_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/tiffoptions/ink_options/) khi xuất bản trình chiếu hoặc kết xuất slide thành TIFF.

### **Chọn Ẩn hay Giữ lại Ink**

Đặt [InkOptions.hide_ink](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/hide_ink/) thành `True` khi tệp xuất ra cần là phiên bản sạch sẽ của bản trình chiếu có chú thích, ví dụ: bản sao cuối cùng dự định phân phối mà không có dấu hiệu xem xét.

Giữ [InkOptions.hide_ink](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/hide_ink/) ở giá trị mặc định `False` khi các chú thích mực là một phần của nội dung dự định, chẳng hạn như bình luận xem xét, ghi chú viết tay, tô sáng hoặc bản vẽ cần hiển thị trong kết quả xuất. Điều này cho phép các ứng dụng tạo ra các đầu ra xem xét và cuối cùng riêng biệt từ cùng một bản trình chiếu mà không cần thay đổi các đối tượng mực nguồn.

## **Câu hỏi thường gặp**

**Tôi có thể thay đổi màu hoặc kích thước của một nét mực đã tồn tại không?**

Có. Lấy dấu vết từ [Ink.traces](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/ink/traces/), sau đó thay đổi thuộc tính [InkTrace.brush](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/inktrace/brush/). Bạn có thể đặt [InkBrush.color](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/inkbrush/color/) và [InkBrush.size](https://reference.aspose.com/slides/vi/python-net/aspose.slides.ink/inkbrush/size/) cho cọ.

**Việc ẩn mực có thay đổi bản trình chiếu nguồn không?**

Không. [InkOptions.hide_ink](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/inkoptions/hide_ink/) chỉ ảnh hưởng đến kết quả kết xuất hoặc xuất; nó không xóa hoặc sửa đổi các đối tượng mực trong bản trình chiếu nguồn.

**Định dạng xuất nào hỗ trợ tùy chọn ink?**

Bạn có thể cấu hình tùy chọn ink cho PDF, HTML, SVG, TIFF và ảnh slide bitmap thông qua các tùy chọn xuất hoặc kết xuất tương ứng đã nêu ở trên.

**Đọc thêm**

* Để tìm hiểu về hình dạng nói chung, xem phần [PowerPoint Shapes](https://docs.aspose.com/slides/vi/python-net/powerpoint-shapes/).
* Để biết thêm về các giá trị hiệu quả, xem [Shape Effective Properties](https://docs.aspose.com/slides/vi/python-net/shape-effective-properties/#get-effective-font-height-value).
* Để biết chi tiết về xuất PDF, xem [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-pdf/).
* Để biết chi tiết về xuất HTML, xem [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-html/).
* Để biết chi tiết về xuất SVG, xem [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/vi/python-net/render-a-slide-as-an-svg-image/).
* Để biết chi tiết về xuất TIFF, xem [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-tiff/).
* Để biết chi tiết về kết xuất slide thành ảnh, xem [Convert Presentation Slides to Images](https://docs.aspose.com/slides/vi/python-net/convert-slide/).