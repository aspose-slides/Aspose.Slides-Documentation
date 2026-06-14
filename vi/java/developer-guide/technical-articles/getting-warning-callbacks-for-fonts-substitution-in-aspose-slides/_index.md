---
title: Nhận Callback Cảnh báo cho Việc Thay Thế Phông chữ
type: docs
weight: 90
url: /vi/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- thay thế phông chữ
- quá trình render
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhận callback cảnh báo cho việc thay thế phông chữ trong Aspose.Slides for Java và hiển thị bản trình chiếu PowerPoint và OpenDocument một cách chính xác."
---
## **Giới thiệu**

Aspose.Slides for Java cho phép bạn nhận các callback cảnh báo cho việc thay thế phông chữ khi một phông chữ cần thiết không có trên máy trong quá trình render. Các callback này giúp chẩn đoán các vấn đề với phông chữ thiếu hoặc không truy cập được.

## **Kích hoạt Callback Cảnh báo**

Aspose.Slides for Java cung cấp các API đơn giản để nhận các callback cảnh báo khi render slide trình chiếu. Thực hiện các bước sau để cấu hình callback cảnh báo:

1. Tạo một lớp callback tùy chỉnh triển khai giao diện [IWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarningcallback/) để xử lý cảnh báo.
1. Đặt callback cảnh báo bằng cách sử dụng các lớp tùy chọn như [RenderingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/htmloptions/) và các lớp khác.
1. Tải một bản trình chiếu sử dụng phông chữ không có trên máy mục tiêu.
1. Tạo hình thu nhỏ slide hoặc xuất bản trình chiếu để quan sát hiệu ứng.

**Lớp Callback Cảnh báo Tùy chỉnh:**  

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Ví dụ đầu ra:
//
// Phông chữ sẽ được thay thế từ XYZ sang {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Tạo Hình Thu Nhỏ Slide:**  

```java
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình render slide.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Load the presentation from the specified file path.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Tạo hình thu nhỏ cho mỗi slide trong bản trình chiếu.
    for (ISlide slide : presentation.getSlides()) {
        // Lấy hình thu nhỏ slide bằng các tùy chọn render đã chỉ định.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Xuất ra Định dạng PDF:**  

```java
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình xuất PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Xuất bản trình chiếu dưới dạng PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Xuất ra Định dạng HTML:**  

```java
// Thiết lập callback cảnh báo để xử lý các cảnh báo liên quan đến phông chữ trong quá trình xuất HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Tải bản trình chiếu từ đường dẫn tệp đã chỉ định.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Xuất bản trình chiếu dưới dạng HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```