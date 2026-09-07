---
title: Chuyển đổi các bài thuyết trình PowerPoint sang SWF Flash trong Python qua Java
linktitle: PowerPoint sang SWF
type: docs
weight: 80
url: /vi/python-java/convert-powerpoint-to-swf-flash/
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
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PowerPoint sang SWF Flash trong Python qua Java với Aspose.Slides. Cấu hình trình xem, ghi chú, các slide ẩn, nén và phông chữ."
---
## **Tổng quan**

Aspose.Slides for Python via Java cho phép bạn chuyển đổi các bài thuyết trình PowerPoint sang SWF mà không cần Microsoft PowerPoint. Sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để xuất bài thuyết trình và [SwfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/) để cấu hình các thiết lập trình xem, chất lượng hình ảnh và bố cục của ghi chú hoặc bình luận.

## **Chuyển đổi bài thuyết trình sang Flash**

Tải tệp nguồn bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/), cấu hình [SwfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/), và lưu bằng [SaveFormat.Swf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/#Swf).

Ví dụ sau xuất `presentation.pptx` sang `presentation.swf`. Nó tắt trình xem nhúng bằng [setViewerIncluded](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/#setViewerIncluded) và bao gồm ghi chú diễn giả bên dưới các slide bằng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

Trước khi chạy ví dụ, [install Aspose.Slides for Python via Java](/slides/vi/python-java/installation/) và đặt `presentation.pptx` trong thư mục làm việc. JVM được khởi động một lần cho mỗi tiến trình Python.

Ví dụ áp dụng [NotesPositions.BottomFull](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomFull) thông qua [setNotesPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) và truyền bố cục cho [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions). Để bao gồm cả bình luận, cấu hình [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) trước khi xuất.

## **Câu hỏi thường gặp**

**Có thể bao gồm các slide ẩn trong file SWF không?**

Có. Gọi [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) với `True`. Mặc định, các slide ẩn không được xuất.

**Làm thế nào để kiểm soát nén và kích thước cuối cùng của SWF?**

Sử dụng [SwfOptions.setCompressed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/#setCompressed) để bật hoặc tắt nén và [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/#setJpegQuality) để điều chỉnh chất lượng ảnh JPEG. Giảm chất lượng JPEG có thể làm giảm kích thước tệp nhưng sẽ ảnh hưởng đến độ trung thực của hình ảnh.

**Trình xem nhúng dùng để làm gì, và khi nào nên tắt nó?**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/#setViewerIncluded) điều khiển việc SWF tạo ra có bao gồm trình xem hay không. Đặt `False` khi bạn cần các slide đã xuất mà không có trình xem nhúng, như trong ví dụ trên.

**Nếu phông chữ nguồn thiếu trên máy xuất thì sẽ xảy ra gì?**

Bạn có thể chỉ định phông chữ mặc định cho văn bản thường bằng [setDefaultRegularFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setDefaultRegularFont), được kế thừa bởi [SwfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/swfoptions/). Chọn một phông chữ có sẵn cho quá trình xuất; việc thay thế phông chữ có thể làm thay đổi diện mạo và bố cục văn bản.