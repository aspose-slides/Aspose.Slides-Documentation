---
title: Tạo bài thuyết trình trong .NET
linktitle: Tạo bài thuyết trình
type: docs
weight: 10
url: /vi/net/create-presentation/
keywords:
- tạo bài thuyết trình
- bài thuyết trình mới
- tạo PPT
- PPT mới
- tạo PPTX
- PPTX mới
- tạo ODP
- ODP mới
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tạo bài thuyết trình trong .NET với Aspose.Slides — tạo các tệp PPT, PPTX và ODP, tận hưởng hỗ trợ OpenDocument, và lưu chúng một cách lập trình để có kết quả đáng tin cậy."
---
## **Tổng quan**

Bài viết này cho thấy cách tạo một bài thuyết trình trong Aspose.Slides, thêm một hộp văn bản vào slide đầu tiên và lưu kết quả dưới dạng tệp. Nó cũng trình bày cách tạo và lưu một bài thuyết trình trống, và cách mở một bài thuyết trình hiện có ở định dạng được hỗ trợ và lưu nó sang định dạng khác. Một phần FAQ ngắn ở cuối bao gồm các câu hỏi thường gặp về định dạng, mẫu, kích thước slide, đơn vị, việc sử dụng bộ nhớ, đa luồng, cấp phép, chữ ký số và hỗ trợ VBA.

Trước khi bắt đầu, thêm Aspose.Slides vào dự án của bạn từ NuGet. Xem [Installation](/slides/vi/net/installation/) để biết gói cần sử dụng trên Windows, Linux và macOS.

## **Tạo bài thuyết trình PowerPoint**

Để tạo một bài thuyết trình và đặt một hộp văn bản trên slide đầu tiên, hãy làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Một bài thuyết trình mới đã chứa sẵn một slide trống.
2. Lấy slide đó từ tập hợp [Slides](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slides/vi/) bằng chỉ mục 0.
3. Thêm một hình chữ nhật bằng phương thức [AddAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/ishapecollection/addautoshape/) và đặt [text](https://reference.aspose.com/slides/vi/net/aspose.slides/itextframe/text/) cho nó.
4. Lưu bài thuyết trình dưới dạng tệp PPTX bằng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Góc trên‑trái của hình chữ nhật cách mép trái 50 điểm và cách mép trên 50 điểm của slide, và hình chữ nhật rộng 400 điểm, cao 100 điểm. Tệp đã lưu chứa một slide với hình chữ nhật và văn bản của nó. Nếu không có giấy phép, Aspose.Slides cũng sẽ thêm dấu nước đánh giá vào mỗi slide mà nó lưu; xem [Licensing](/slides/vi/net/licensing/).

## **Tạo và lưu một bài thuyết trình**

<a name="csharp-create-save-presentation"></a>

Để tạo một bài thuyết trình trống và lưu nó, tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và lưu nó ở bất kỳ định dạng nào của liệt kê [SaveFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/). Kết quả là một bài thuyết trình có một slide trống.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Mở và lưu một bài thuyết trình**

<a name="csharp-open-save-presentation"></a>

Để chuyển đổi một bài thuyết trình từ định dạng này sang định dạng khác, mở nó bằng cách truyền đường dẫn vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/presentation/), sau đó lưu nó ở định dạng mục tiêu. Aspose.Slides tự động phát hiện định dạng đầu vào, như PPT, PPTX hoặc ODP, dựa trên tệp.

Ví dụ dưới đây mong đợi một bài thuyết trình OpenDocument tên *Sample.odp* trong thư mục làm việc và lưu nó dưới dạng PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### Những định dạng nào tôi có thể lưu một bài thuyết trình mới sang?

Bạn có thể lưu thành [PPTX, PPT và ODP](/slides/vi/net/save-presentation/), và xuất sang [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), [XPS](/slides/vi/net/convert-powerpoint-to-xps/), [HTML](/slides/vi/net/convert-powerpoint-to-html/), [SVG](/slides/vi/net/render-a-slide-as-an-svg-image/), và [images](/slides/vi/net/convert-powerpoint-to-png/), trong số các định dạng khác.

### Tôi có thể bắt đầu từ một mẫu (POTX/POTM) và lưu thành PPTX thông thường không?

Có. Tải mẫu và lưu sang định dạng mong muốn; các định dạng POTX/POTM/PPTM và các định dạng tương tự [được hỗ trợ](/slides/vi/net/supported-file-formats/).

### Làm sao tôi kiểm soát kích thước/ tỷ lệ khung hình của slide khi tạo bài thuyết trình?

Đặt [slide size](/slides/vi/net/slide-size/) (bao gồm các preset như 4:3 và 16:9 hoặc kích thước tùy chỉnh) và chọn cách nội dung được thu phóng.

### Đơn vị đo kích thước và tọa độ là gì?

Bằng điểm: 1 inch bằng 72 đơn vị.

### Làm sao tôi xử lý các bài thuyết trình rất lớn (có nhiều tệp media) để giảm việc sử dụng bộ nhớ?

Sử dụng [BLOB management strategies](/slides/vi/net/manage-blob/), giới hạn lưu trữ trong bộ nhớ bằng cách tận dụng tệp tạm, và ưu tiên quy trình làm việc dựa trên tệp hơn là các luồng chỉ trong bộ nhớ.

### Tôi có thể tạo/lưu các bài thuyết trình song song không?

Bạn không thể thao tác trên cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) từ [multiple threads](/slides/vi/net/multithreading/). Hãy chạy các thể hiện riêng biệt, độc lập cho mỗi luồng hoặc tiến trình.

### Làm sao tôi loại bỏ dấu nước dùng thử và các hạn chế?

[Apply a license](/slides/vi/net/licensing/) một lần cho mỗi tiến trình. Tệp XML giấy phép phải không bị chỉnh sửa, và việc thiết lập giấy phép cần được đồng bộ nếu có nhiều luồng.

### Tôi có thể ký số PPTX tôi tạo không?

Có. [Digital signatures](/slides/vi/net/digital-signature-in-powerpoint/) (thêm và xác thực) được hỗ trợ cho các bài thuyết trình.

### Các macro (VBA) có được hỗ trợ trong các bài thuyết trình đã tạo không?

Có. Bạn có thể [create/edit VBA projects](/slides/vi/net/presentation-via-vba/) và lưu các tệp có macro như PPTM/PPSM.