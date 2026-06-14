---
title: Tạo bản thuyết trình trong .NET
linktitle: Tạo bản thuyết trình
type: docs
weight: 10
url: /vi/net/create-presentation/
keywords:
- tạo bản thuyết trình
- bản thuyết trình mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo bản thuyết trình trong .NET với Aspose.Slides—tạo ra các tệp PPT, PPTX và ODP, tận hưởng hỗ trợ OpenDocument, và lưu chúng bằng chương trình để có kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này cho thấy cách tạo một bản thuyết trình trong Aspose.Slides, thêm nội dung đơn giản vào một slide và lưu kết quả thành tệp. Nó cũng trình bày cách tạo và lưu một bản thuyết trình mới, mở một bản thuyết trình hiện có ở định dạng được hỗ trợ và lưu nó sang định dạng khác. Ngoài ra, bài viết bao gồm một phần Hỏi‑đáp ngắn về các câu hỏi thường gặp liên quan đến định dạng, mẫu, kích thước slide, đơn vị, sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

## **Tạo bản thuyết trình PowerPoint**

Để thêm một đường thẳng đơn giản vào slide được chọn của bản thuyết trình, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp Presentation.  
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.  
3. Thêm một AutoShape kiểu Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes.  
4. Ghi bản thuyết trình đã sửa đổi dưới dạng tệp PPTX.  

Trong ví dụ dưới đây, chúng tôi đã thêm một đường thẳng vào slide đầu tiên của bản thuyết trình.

```c#
// Khởi tạo một đối tượng Presentation đại diện cho tệp bản thuyết trình
using (Presentation presentation = new Presentation())
{
    // Lấy slide đầu tiên
    ISlide slide = presentation.Slides[0];

    // Thêm một autoshape loại đường thẳng
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Tạo và Lưu một Bản Thuyết Trình**

<a name="csharp-create-save-presentation"><strong>Các bước: Tạo và Lưu Bản Thuyết Trình trong C#</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/).  
2. Lưu _Presentation_ thành bất kỳ định dạng nào được hỗ trợ bởi [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Mở và Lưu một Bản Thuyết Trình**

<a name="csharp-open-save-presentation"><strong>Các bước: Mở và Lưu Bản Thuyết Trình trong C#</strong></a>

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) với bất kỳ định dạng nào, ví dụ PPT, PPTX, ODP, v.v.  
2. Lưu _Presentation_ thành bất kỳ định dạng nào được hỗ trợ bởi [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/)

```c#
// Tải bất kỳ tệp nào được hỗ trợ trong Presentation, ví dụ ppt, pptx, odp, v.v.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể lưu bản thuyết trình mới sang những định dạng nào?**

Bạn có thể lưu thành [PPTX, PPT và ODP](/slides/vi/net/save-presentation/), và xuất sang [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), [XPS](/slides/vi/net/convert-powerpoint-to-xps/), [HTML](/slides/vi/net/convert-powerpoint-to-html/), [SVG](/slides/vi/net/convert-powerpoint-to-png/), và [hình ảnh](/slides/vi/net/convert-powerpoint-to-png/), trong số các định dạng khác.

**Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu dưới dạng PPTX thông thường không?**

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/net/supported-file-formats/).

**Làm thế nào để tôi kiểm soát kích thước/ tỷ lệ khung hình của slide khi tạo bản thuyết trình?**

Đặt [kích thước slide](/slides/vi/net/slide-size/) (bao gồm các cài đặt sẵn như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung sẽ được phóng to/thu nhỏ.

**Kích thước và tọa độ được đo bằng đơn vị nào?**

Theo điểm: 1 inch bằng 72 đơn vị.

**Làm sao xử lý các bản thuyết trình rất lớn (có nhiều tệp media) để giảm việc sử dụng bộ nhớ?**

Sử dụng [chiến lược quản lý BLOB](/slides/vi/net/manage-blob/), hạn chế lưu trữ trong bộ nhớ bằng cách tận dụng các tệp tạm thời, và ưu tiên quy trình làm việc dựa trên tệp hơn là các luồng chỉ trong bộ nhớ.

**Tôi có thể tạo/lưu các bản thuyết trình đồng thời không?**

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) từ [nhiều luồng](/slides/vi/net/multithreading/). Hãy chạy các thể hiện riêng biệt, độc lập cho mỗi luồng hoặc tiến trình.

**Làm thế nào để loại bỏ watermark và các hạn chế của phiên bản dùng thử?**

[Áp dụng giấy phép](/slides/vi/net/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị sửa đổi, và việc thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng tham gia.

**Tôi có thể ký số PPTX tôi tạo không?**

Có. [Chữ ký số](/slides/vi/net/digital-signature-in-powerpoint/) (thêm và xác thực) được hỗ trợ cho các bản thuyết trình.

**Macro (VBA) có được hỗ trợ trong các bản thuyết trình đã tạo không?**

Có. Bạn có thể [tạo/chỉnh sửa dự án VBA](/slides/vi/net/presentation-via-vba/) và lưu các tệp hỗ trợ macro như PPTM/PPSM.