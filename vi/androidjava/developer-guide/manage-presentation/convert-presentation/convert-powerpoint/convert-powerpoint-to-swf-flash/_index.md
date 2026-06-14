---
title: Chuyển đổi bài thuyết trình PowerPoint sang SWF Flash trên Android
linktitle: PowerPoint sang SWF
type: docs
weight: 80
url: /vi/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint (PPT/PPTX) sang SWF Flash trong Java với Aspose.Slides cho Android. Các mẫu mã từng bước, đầu ra nhanh chất lượng, không cần tự động hoá PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bài thuyết trình PowerPoint sang SWF bằng cách sử dụng Aspose.Slides. Nó cho thấy cách lưu một bài thuyết trình dưới dạng tệp SWF bằng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) và cách cấu hình việc xuất với [SwfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/swfoptions/), bao gồm cài đặt trình xem và bố cục ghi chú hoặc bình luận.

## **Chuyển đổi PPT(X) sang SWF**

Phương thức [Save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) có thể được sử dụng để chuyển đổi toàn bộ bài thuyết trình thành tài liệu **SWF**. Ví dụ sau đây cho thấy cách chuyển đổi một bài thuyết trình thành tài liệu **SWF** bằng cách sử dụng các tùy chọn được cung cấp bởi lớp [**SWFOptions**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SwfOptions). Bạn cũng có thể bao gồm bình luận trong SWF được tạo bằng cách sử dụng lớp [**ISWFOptions**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISwfOptions) và giao diện [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

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

Có. Bật các slide ẩn bằng cách sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) trong [SwfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/swfoptions/). Mặc định, các slide ẩn sẽ không được xuất.

**Làm thế nào để tôi kiểm soát việc nén và kích thước cuối cùng của SWF?**

Sử dụng phương thức [setCompressed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) và [adjust JPEG quality](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) để cân bằng giữa kích thước tệp và độ trung thực hình ảnh.

**'setViewerIncluded' dùng để làm gì, và khi nào tôi nên tắt nó?**

[setViewerIncluded](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) thêm giao diện người dùng trình phát nhúng (các điều khiển điều hướng, bảng, tìm kiếm). Tắt nó nếu bạn dự định sử dụng trình phát riêng của mình hoặc cần một khung SWF thuần không có giao diện.

**Nếu phông chữ nguồn bị thiếu trên máy xuất thì sẽ xảy ra gì?**

Aspose.Slides sẽ thay thế phông chữ bạn chỉ định bằng [setDefaultRegularFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) trong [SwfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/swfoptions/) để tránh việc dự phòng không mong muốn.