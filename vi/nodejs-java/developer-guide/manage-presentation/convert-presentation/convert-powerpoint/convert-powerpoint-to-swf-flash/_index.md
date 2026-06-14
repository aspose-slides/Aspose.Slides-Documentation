---
title: Chuyển đổi bản trình chiếu PowerPoint sang SWF Flash trong JavaScript
linktitle: PowerPoint sang SWF
type: docs
weight: 80
url: /vi/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang SWF
- bản trình chiếu sang SWF
- slide sang SWF
- PPT sang SWF
- PPTX sang SWF
- PowerPoint sang Flash
- bản trình chiếu sang Flash
- slide sang Flash
- PPT sang Flash
- PPTX sang Flash
- lưu PPT dưới dạng SWF
- lưu PPTX dưới dạng SWF
- xuất PPT sang SWF
- xuất PPTX sang SWF
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi PowerPoint (PPT/PPTX) sang SWF Flash với Aspose.Slides cho Node.js. Các mẫu mã từng bước, xuất nhanh với chất lượng cao, không cần tự động hoá PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang SWF bằng cách sử dụng Aspose.Slides. Nó cho thấy cách lưu một bản trình chiếu dưới dạng tệp SWF bằng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) và cách cấu hình việc xuất với [SwfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/swfoptions/), bao gồm cài đặt trình xem và bố cục ghi chú hoặc bình luận.

## **Chuyển đổi PPT(X) sang SWF**
Phương thức [save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) được công bố bởi lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) có thể được sử dụng để chuyển đổi toàn bộ bản trình chiếu thành tài liệu **SWF**. Ví dụ sau đây cho thấy cách chuyển đổi một bản trình chiếu thành tài liệu **SWF** bằng cách sử dụng các tùy chọn được cung cấp bởi lớp [**SWFOptions**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SwfOptions). Bạn cũng có thể bao gồm bình luận trong SWF được tạo bằng cách sử dụng lớp [**SWFOptions**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SwfOptions) và lớp [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) class.

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Lưu bản trình chiếu
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bao gồm các slide ẩn trong SWF không?**

Có. Sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) trong [SwfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/swfoptions/). Mặc định, các slide ẩn sẽ không được xuất.

**Làm thế nào tôi có thể kiểm soát nén và kích thước cuối cùng của SWF?**

Sử dụng phương thức [setCompressed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/swfoptions/setcompressed/) và [setJpegQuality](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/swfoptions/setjpegquality/) để cân bằng kích thước tệp và độ trung thực hình ảnh.

**'setViewerIncluded' dùng để làm gì, và khi nào tôi nên sử dụng nó?**

[setViewerIncluded](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) thêm giao diện người dùng trình phát nhúng (các điều khiển điều hướng, bảng, tìm kiếm). Sử dụng nó nếu bạn dự định sử dụng trình phát của riêng mình hoặc cần một khung SWF tối giản không có giao diện.

**Điều gì xảy ra nếu phông chữ nguồn thiếu trên máy xuất?**

Aspose.Slides sẽ thay thế phông chữ bạn chỉ định bằng [setDefaultRegularFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) trong [SwfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/swfoptions/) để tránh việc sử dụng phông chữ thay thế không mong muốn.