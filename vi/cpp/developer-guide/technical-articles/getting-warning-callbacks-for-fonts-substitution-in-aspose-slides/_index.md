---
title: Nhận Callback Cảnh Báo cho Việc Thay Thế Phông Chữ
type: docs
weight: 70
url: /vi/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- thay thế phông chữ
- quá trình render
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách nhận các callback cảnh báo cho việc thay thế phông chữ trong Aspose.Slides cho C++ và hiển thị bản trình chiếu PowerPoint và OpenDocument một cách chính xác."
---
## **Giới thiệu**

Aspose.Slides for C++ cho phép bạn nhận các callback cảnh báo về việc thay thế phông chữ khi phông chữ yêu cầu không có trên máy trong quá trình render. Các callback này giúp chẩn đoán các vấn đề với phông chữ thiếu hoặc không truy cập được.

## **Bật Callback Cảnh Báo**

Aspose.Slides for C++ cung cấp các API đơn giản để nhận các callback cảnh báo khi render các slide trình chiếu. Thực hiện các bước sau để cấu hình callback cảnh báo:

1. Tạo một lớp callback tùy chỉnh triển khai giao diện [IWarningCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides.warnings/iwarningcallback/) để xử lý cảnh báo.
1. Đặt callback cảnh báo bằng cách sử dụng các lớp tùy chọn như [RenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/htmloptions/), và các lớp khác.
1. Tải một bản trình chiếu sử dụng phông chữ không có trên máy mục tiêu.
1. Tạo ảnh thu nhỏ slide hoặc xuất bản trình chiếu để quan sát hiệu ứng.

**Lớp Callback Cảnh Báo Tùy Chỉnh:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Ví dụ đầu ra:
//
// Phông chữ sẽ được thay thế từ XYZ sang {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Tạo ảnh thu nhỏ slide:**

```cpp
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình render slide.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Tạo ảnh thu nhỏ cho mỗi slide trong bản trình chiếu.
for(auto&& slide : presentation->get_Slides())
{
    // Lấy ảnh thu nhỏ của slide bằng cách sử dụng các tùy chọn render đã chỉ định.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Xuất ra định dạng PDF:**

```cpp
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình xuất PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Xuất bản trình chiếu ra định dạng PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Xuất ra định dạng HTML:**

```cpp
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình xuất HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Xuất bản trình chiếu ở định dạng HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```