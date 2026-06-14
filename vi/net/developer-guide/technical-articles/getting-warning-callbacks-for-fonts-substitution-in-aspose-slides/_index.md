---
title: Nhận callbacks cảnh báo cho việc thay thế phông chữ trong .NET
type: docs
weight: 120
url: /vi/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- thay thế phông chữ
- quá trình render
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: Tìm hiểu cách nhận callbacks cảnh báo cho việc thay thế phông chữ trong Aspose.Slides cho .NET và hiển thị chính xác các bản trình chiếu PowerPoint và OpenDocument.
---
## **Giới thiệu**

Aspose.Slides for .NET cho phép bạn nhận các callback cảnh báo về việc thay thế phông chữ khi phông chữ yêu cầu không có trên máy trong quá trình render. Các callback này giúp chẩn đoán các vấn đề liên quan đến phông chữ thiếu hoặc không truy cập được.

## **Bật Callback Cảnh báo**

Aspose.Slides for .NET cung cấp các API đơn giản để nhận các callback cảnh báo khi render các slide trình chiếu. Thực hiện các bước sau để cấu hình callback cảnh báo:

1. Tạo một lớp callback tùy chỉnh triển khai giao diện [IWarningCallback](https://reference.aspose.com/slides/vi/net/aspose.slides.warnings/iwarningcallback/) để xử lý cảnh báo.
1. Đặt callback cảnh báo bằng cách sử dụng các lớp tùy chọn như [RenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/htmloptions/), và các lớp khác.
1. Tải một bản trình chiếu sử dụng phông chữ không có trên máy đích.
1. Tạo ảnh thu nhỏ của slide hoặc xuất bản trình chiếu để quan sát hiệu quả.

**Lớp Callback Cảnh báo Tùy chỉnh:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Example output:
//
// // Phông chữ sẽ được thay thế từ XYZ sang {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Tạo ảnh thu nhỏ slide:**

```c#
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình render slide.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
using var presentation = new Presentation("sample.pptx");

// Tạo ảnh thu nhỏ cho mỗi slide trong bản trình chiếu.
foreach (var slide in presentation.Slides)
{
    // Lấy ảnh thu nhỏ của slide bằng các tùy chọn render đã chỉ định.
    using var image = slide.GetImage(options);
    // ...
}
```

**Xuất ra định dạng PDF:**

```c#
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình xuất PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
using var presentation = new Presentation("sample.pptx");

// Xuất bản trình chiếu dưới dạng PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Xuất ra định dạng HTML:**

```c#
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình xuất HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
using var presentation = new Presentation("sample.pptx");

// Xuất bản trình chiếu dưới định dạng HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```