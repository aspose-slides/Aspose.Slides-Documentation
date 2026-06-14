---
title: Chuyển đổi bản trình chiếu PowerPoint sang SWF Flash trong C++
linktitle: PowerPoint sang SWF
type: docs
weight: 80
url: /vi/cpp/convert-powerpoint-to-swf-flash/
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
- C++
- Aspose.Slides
description: "Chuyển đổi PowerPoint (PPT/PPTX) sang SWF Flash trong C++ với Aspose.Slides. Mẫu code từng bước, đầu ra nhanh và chất lượng, không cần tự động hoá PowerPoint."
---
## **Overview**

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang SWF bằng cách sử dụng Aspose.Slides. Nó cho thấy cách lưu một bản trình chiếu dưới dạng tệp SWF bằng phương thức [Presentation::Save](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/save/) và cách cấu hình xuất với [SwfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/swfoptions/), bao gồm cài đặt trình xem và bố cục ghi chú hoặc bình luận.

## **Chuyển Đổi Bản Trình Chiếu sang Flash**

Phương pháp [Save](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) có thể được sử dụng để chuyển đổi toàn bộ bản trình chiếu thành tài liệu SWF. Bạn cũng có thể bao gồm bình luận trong SWF được tạo bằng cách sử dụng lớp [SWFOptions](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.export.swf_options) và lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/). Ví dụ sau minh họa cách chuyển đổi một bản trình chiếu thành tài liệu SWF bằng cách sử dụng các tùy chọn được cung cấp bởi lớp SWFOptions.

``` cpp
// Đường dẫn tới thư mục tài liệu.
    System::String dataDir = GetDataPath();

    // Tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Lưu bản trình chiếu và các trang ghi chú
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **Câu hỏi thường gặp**

**Có thể bao gồm các slide ẩn trong SWF không?**

Có. Sử dụng phương thức [set_ShowHiddenSlides](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) trong [SwfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/swfoptions/). Mặc định, các slide ẩn không được xuất.

**Làm thế nào tôi có thể kiểm soát việc nén và kích thước cuối cùng của SWF?**

Sử dụng phương thức [set_Compressed](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/swfoptions/set_compressed/) và điều chỉnh [JPEG quality](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/swfoptions/set_jpegquality/) để cân bằng giữa kích thước tệp và độ trung thực hình ảnh.

**'set_ViewerIncluded' dùng để làm gì, và khi nào nên sử dụng?**

[set_ViewerIncluded](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) thêm giao diện người dùng của trình phát nhúng (các điều khiển điều hướng, bảng, tìm kiếm). Vô hiệu hoá nó nếu bạn dự định sử dụng trình phát riêng của mình hoặc cần một khung SWF thuần không có giao diện.

**Điều gì sẽ xảy ra nếu một phông chữ nguồn bị thiếu trên máy xuất?**

Aspose.Slides sẽ thay thế phông chữ bạn chỉ định qua [set_DefaultRegularFont](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) trong [SwfOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/swfoptions/) để tránh việc thay thế không mong muốn.