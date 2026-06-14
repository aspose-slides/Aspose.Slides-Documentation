---
title: Chuyển đổi Bài thuyết trình PowerPoint sang SWF Flash trong Java
linktitle: PowerPoint sang SWF
type: docs
weight: 80
url: /vi/java/convert-powerpoint-to-swf-flash/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang SWF
- bài thuyết trình sang SWF
- slide sang SWF
- PPT sang SWF
- PPTX sang SWF
- PowerPoint sang Flash
- bài thuyết trình sang Flash
- slide sang Flash
- PPT sang Flash
- PPTX sang Flash
- lưu PPT dưới dạng SWF
- lưu PPTX dưới dạng SWF
- xuất PPT sang SWF
- xuất PPTX sang SWF
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint (PPT/PPTX) sang SWF Flash trong Java với Aspose.Slides. Mẫu code từng bước, đầu ra nhanh chất lượng, không cần tự động hóa PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bài thuyết trình PowerPoint sang định dạng SWF bằng cách sử dụng Aspose.Slides. Nó chỉ ra cách lưu một bài thuyết trình dưới dạng tệp SWF bằng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) và cách cấu hình xuất bằng [SwfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/swfoptions/), bao gồm cài đặt trình xem và bố cục ghi chú hoặc bình luận.

## **Chuyển đổi Bài thuyết trình sang Flash**

Phương thức [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) có thể được sử dụng để chuyển đổi toàn bộ bài thuyết trình thành tài liệu **SWF**. Ví dụ sau cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu **SWF** bằng cách sử dụng các tùy chọn được cung cấp bởi lớp **SWFOptions**. Bạn cũng có thể bao gồm bình luận trong SWF được tạo bằng cách sử dụng lớp **ISWFOptions** và giao diện **INotesCommentsLayoutingOptions**.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Lưu bài thuyết trình
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bao gồm các slide ẩn trong SWF không?**

Có. Kích hoạt các slide ẩn bằng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) trong [SwfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/swfoptions/). Mặc định, các slide ẩn sẽ không được xuất.

**Làm thế nào tôi có thể kiểm soát việc nén và kích thước cuối cùng của SWF?**

Sử dụng phương thức [setCompressed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) và [adjust JPEG quality](https://reference.aspose.com/slides/vi/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) để cân bằng giữa kích thước tệp và độ trung thực của hình ảnh.

**Chức năng của 'setViewerIncluded' là gì, và khi nào tôi nên tắt nó?**

[setViewerIncluded](https://reference.aspose.com/slides/vi/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) thêm giao diện người dùng trình phát nhúng (các điều khiển điều hướng, bảng, tìm kiếm). Vô hiệu hoá nó nếu bạn dự định sử dụng trình phát riêng của mình hoặc cần khung SWF thuần túy không có giao diện.

**Điều gì sẽ xảy ra nếu phông chữ nguồn bị thiếu trên máy xuất?**

Aspose.Slides sẽ thay thế phông chữ bạn chỉ định qua [setDefaultRegularFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) trong [SwfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/swfoptions/) để tránh việc tự động chuyển sang phông chữ không mong muốn.