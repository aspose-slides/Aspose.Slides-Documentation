---
title: Chuyển đổi bản trình bày PowerPoint sang SWF Flash trong .NET
linktitle: PowerPoint sang SWF
type: docs
weight: 80
url: /vi/net/convert-powerpoint-to-swf-flash/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang SWF
- bản trình bày sang SWF
- slide sang SWF
- PPT sang SWF
- PPTX sang SWF
- PowerPoint sang Flash
- bản trình bày sang Flash
- slide sang Flash
- PPT sang Flash
- PPTX sang Flash
- lưu PPT dưới dạng SWF
- lưu PPTX dưới dạng SWF
- xuất PPT sang SWF
- xuất PPTX sang SWF
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi PowerPoint (PPT/PPTX) sang SWF Flash trong .NET với Aspose.Slides. Mẫu mã C# từng bước, đầu ra nhanh chất lượng, không cần tự động hóa PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình bày PowerPoint sang SWF bằng Aspose.Slides. Nó cho thấy cách lưu một bản trình bày dưới dạng tệp SWF bằng phương thức [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) và cách cấu hình việc xuất với [SwfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/swfoptions/), bao gồm cài đặt trình xem và bố cục ghi chú hoặc nhận xét.

## **Chuyển đổi bản trình bày sang Flash**

Phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/save/index) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) có thể được sử dụng để chuyển đổi toàn bộ bản trình bày thành tài liệu SWF. Bạn cũng có thể bao gồm nhận xét trong SWF được tạo bằng cách sử dụng lớp [SWFOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/swfoptions) và giao diện [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/inotescommentslayoutingoptions). Ví dụ dưới đây cho thấy cách chuyển đổi một bản trình bày thành tài liệu SWF bằng cách sử dụng các tùy chọn được cung cấp bởi lớp SWFOptions.

```c#
// Tạo một đối tượng Presentation đại diện cho tệp bản trình bày
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Lưu bản trình bày và các trang ghi chú
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **Câu hỏi thường gặp**

**Tôi có thể bao gồm các slide ẩn trong SWF không?**

Có. Bật tùy chọn [ShowHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export/swfoptions/showhiddenslides/) trong [SwfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/swfoptions/). Mặc định, các slide ẩn sẽ không được xuất.

**Làm thế nào tôi có thể kiểm soát việc nén và kích thước cuối cùng của SWF?**

Sử dụng cờ [Compressed](https://reference.aspose.com/slides/vi/net/aspose.slides.export/swfoptions/compressed/) (được bật mặc định) và điều chỉnh [JpegQuality](https://reference.aspose.com/slides/vi/net/aspose.slides.export/swfoptions/jpegquality/) để cân bằng giữa kích thước tệp và độ trung thực hình ảnh.

**'ViewerIncluded' dùng để làm gì, và khi nào nên tắt nó?**

[ViewerIncluded](https://reference.aspose.com/slides/vi/net/aspose.slides.export/swfoptions/viewerincluded/) thêm giao diện người dùng của trình phát nhúng (các điều khiển điều hướng, bảng, tìm kiếm). Hãy tắt nó nếu bạn dự định sử dụng trình phát riêng hoặc cần một khung SWF thuần không có giao diện người dùng.

**Điều gì sẽ xảy ra nếu phông chữ nguồn thiếu trên máy xuất?**

Aspose.Slides sẽ thay thế phông chữ bằng phông bạn chỉ định qua [DefaultRegularFont](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/defaultregularfont/) trong [SwfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/) để tránh việc sử dụng phông dự phòng không mong muốn.