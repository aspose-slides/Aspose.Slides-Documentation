---
title: Thao tác Trình chiếu Low-Code bằng Python
linktitle: API Low-Code
type: docs
weight: 50
url: /vi/python-net/low-code-presentation-operations/
keywords:
- API trình chiếu low-code
- chuyển đổi trình chiếu
- hợp nhất trình chiếu
- thu thập hình dạng
- nén trình chiếu
- loại bỏ các master slide không dùng
- loại bỏ các layout slide không dùng
- nén phông chữ nhúng
- PowerPoint
- OpenDocument
- trình chiếu
- Python
- Aspose.Slides
description: "Sử dụng API low-code Aspose.Slides trong Python để chuyển đổi và hợp nhất các trình chiếu, thu thập các hình dạng, và giảm kích thước của trình chiếu."
---
## **Tổng quan**

Mô-đun [aspose.slides.lowcode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/) cung cấp các lớp trợ giúp cho các thao tác trình chiếu thông thường. Những trợ giúp này gói các quy trình mô hình đối tượng thường được sử dụng vào các phương thức tập trung, cho phép bạn chuyển đổi hoặc hợp nhất tệp, thu thập hình dạng và loại bỏ nội dung không dùng đến với ít mã hơn.

Các trợ giúp low-code hữu ích nhất khi thao tác áp dụng cho toàn bộ tệp hoặc bản trình chiếu và quy trình mặc định đáp ứng yêu cầu của bạn. Sử dụng toàn bộ [Aspose.Slides object model](https://reference.aspose.com/slides/vi/python-net/aspose.slides/) khi bạn cần kiểm soát chi tiết từng slide, master, layout, shape, cài đặt xuất, hoặc mối quan hệ giữa các yếu tố của bản trình chiếu.

Bảng sau tóm tắt các trợ giúp có sẵn:

| Trợ giúp | Sử dụng cho |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/convert/) | Chuyển đổi một bản trình chiếu sang định dạng khác bằng cuộc gọi trực tiếp từ tệp này sang tệp khác. |
| [Merger](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/merger/) | Kết hợp các tệp bản trình chiếu hoàn chỉnh cùng định dạng. |
| [Collect](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/collect/) | Lấy các shape từ toàn bộ bản trình chiếu để xử lý hoặc phân tích lặp lại. |
| [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/) | Loại bỏ các master và layout không dùng và giảm dữ liệu phông chữ nhúng. |

## **Chuyển đổi một bản trình chiếu**

Sử dụng [Convert.auto_by_extension](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/convert/auto_by_extension/) khi phần mở rộng tệp đầu ra đủ để chọn định dạng xuất. Phương thức mở bản trình chiếu nguồn, xác định định dạng cần thiết từ đường dẫn đầu ra và ghi kết quả.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Lớp [Convert](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/convert/) cũng cung cấp các phương thức riêng cho đầu ra PDF, SVG, JPEG, PNG và TIFF. Sử dụng mô hình đối tượng đầy đủ khi bạn cần kiểm tra hoặc sửa đổi bản trình chiếu trước khi xuất hoặc cấu hình tùy chọn xuất mà trợ giúp đã chọn không cung cấp. Xem [Convert Presentation](/python-net/convert-presentation/) để biết quy trình và tùy chọn cho từng định dạng.

## **Hợp nhất các bản trình chiếu**

Sử dụng [Merger.process](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/merger/process/) để kết hợp các tệp bản trình chiếu hoàn chỉnh chỉ bằng một lần gọi. Các bản trình chiếu đầu vào phải có cùng định dạng tệp.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Trợ giúp này phù hợp khi tất cả các slide cần được nối vào một kết quả duy nhất mà không cần chọn hoặc ánh xạ lại từng slide riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần hợp nhất các slide đã chọn, áp dụng master hoặc layout đích, bảo tồn các phần một cách rõ ràng, hoặc điều chỉnh kích thước slide khác nhau. Xem [Merge Presentations](/python-net/merge-presentation/) cho các kịch bản này.

## **Thu thập hình dạng**

Sử dụng [Collect.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/collect/shapes/) khi bạn cần một bộ sưu tập tất cả các shape trong bản trình chiếu. Điều này hữu ích khi cùng một tập hợp sẽ được lọc, đếm hoặc xử lý nhiều lần.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Sử dụng vòng lặp thu thập trực tiếp khi thứ tự duyệt, thoát sớm, lọc trước khi xử lý hoặc kiểm soát chi tiết cha‑con là quan trọng.

## **Nén nội dung bản trình chiếu**

Lớp [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/) có thể loại bỏ các phần tử cấu trúc không dùng và giảm dữ liệu phông chữ nhúng:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) loại bỏ các slide layout mà không có slide bình thường nào tham chiếu.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) loại bỏ các master slide không còn được sử dụng.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) loại bỏ các ký tự không dùng đến từ phông chữ nhúng.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Loại bỏ các layout không dùng trước các master không dùng để một master trở nên không tham chiếu sau khi dọn dẹp layout cũng có thể bị loại bỏ. Lưu bản trình chiếu đã tối ưu vào tệp mới nếu bạn có thể cần lại các master, layout hoặc dữ liệu phông chữ nhúng đầy đủ sau này. Để biết chi tiết hơn, xem [Slide Master](/python-net/slide-master/) và [Embedded Font](/python-net/embedded-font/).

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng API low-code thay vì mô hình đối tượng đầy đủ?**

Sử dụng các trợ giúp low-code khi một thao tác tiêu chuẩn áp dụng cho toàn bộ tệp hoặc bản trình chiếu và không yêu cầu kiểm soát chi tiết các yếu tố riêng lẻ. Sử dụng mô hình đối tượng đầy đủ khi bạn cần chọn các slide cụ thể, kiểm soát quan hệ master và layout, kiểm tra trạng thái trung gian, hoặc cấu hình hành vi mà trợ giúp không cung cấp.

**Merger có thể kết hợp các bản trình chiếu với các định dạng tệp khác nhau không?**

Không. [Merger.process](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/merger/process/) yêu cầu các bản trình chiếu đầu vào có cùng định dạng. Đầu tiên chuyển đổi các tệp đầu vào sang cùng một định dạng, ví dụ bằng [Convert.auto_by_extension](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/convert/auto_by_extension/), rồi sau đó hợp nhất các tệp đã chuyển đổi.

**Collect.shapes bao gồm những gì?**

[Collect.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/collect/shapes/) lấy các shape từ bản trình chiếu để chúng có thể được giữ lại, lọc, đếm hoặc duyệt nhiều lần. Sử dụng vòng lặp thu thập trực tiếp khi bạn cần kiểm soát chính xác loại slide hoặc các đối tượng lồng nhau nào sẽ được truy cập.

**Compress luôn làm giảm kích thước tệp bản trình chiếu không?**

Không nhất thiết. Kết quả phụ thuộc vào việc bản trình chiếu có chứa các layout không dùng, các master không dùng, hoặc phông chữ nhúng có ký tự không dùng. Nếu không có các thành phần này, các thao tác [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/) tương ứng có thể không giảm kích thước tệp.

**Các thay đổi bởi Compress có được lưu tự động không?**

Không. Các trợ giúp này hoạt động trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) đã tải trong bộ nhớ. Sau khi chạy [Compress](https://reference.aspose.com/slides/vi/python-net/aspose.slides.lowcode/compress/), hãy gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) để ghi kết quả.

## **Bài viết liên quan**

- [Chuyển đổi bản trình chiếu](/python-net/convert-presentation/)
- [Hợp nhất các bản trình chiếu](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Quản lý hộp văn bản](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)