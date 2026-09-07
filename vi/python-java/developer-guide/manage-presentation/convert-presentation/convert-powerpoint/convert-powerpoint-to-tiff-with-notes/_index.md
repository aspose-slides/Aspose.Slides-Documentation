---
title: Chuyển đổi bản trình chiếu PowerPoint sang TIFF có chú thích trong Python
linktitle: PowerPoint sang TIFF có chú thích
type: docs
weight: 100
url: /vi/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang TIFF
- bản trình chiếu sang TIFF
- slide sang TIFF
- PPT sang TIFF
- PPTX sang TIFF
- lưu PPT dưới dạng TIFF
- lưu PPTX dưới dạng TIFF
- xuất PPT sang TIFF
- xuất PPTX sang TIFF
- PowerPoint có chú thích
- bản trình chiếu có chú thích
- slide có chú thích
- PPT có chú thích
- PPTX có chú thích
- TIFF có chú thích
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu PowerPoint sang TIFF có chú thích bằng Aspose.Slides cho Python qua Java. Tìm hiểu cách xuất slide cùng ghi chú người thuyết trình một cách hiệu quả."
---
## **Giới thiệu**

Aspose.Slides for Python qua Java cung cấp giải pháp đơn giản để chuyển đổi các bản thuyết trình PowerPoint và OpenDocument (PPT, PPTX và ODP) có chú thích sang định dạng TIFF. Định dạng này được sử dụng rộng rãi để lưu trữ hình ảnh chất lượng cao, in ấn và lưu trữ tài liệu. Sử dụng phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) để xuất các slide và ghi chú của người thuyết trình thành một tệp TIFF đa trang duy nhất.

## **Chuyển đổi bản thuyết trình sang TIFF có chú thích**

Việc lưu một bản thuyết trình PowerPoint hoặc OpenDocument sang TIFF có chú thích bằng cách sử dụng Aspose.Slides for Python qua Java bao gồm các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/): Tải một tệp PowerPoint hoặc OpenDocument.
1. Cấu hình các tùy chọn bố cục đầu ra: Sử dụng lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) để chỉ định cách hiển thị chú thích và bình luận.
1. Lưu bản thuyết trình sang TIFF: Truyền các tùy chọn đã cấu hình cho phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save).

Giả sử chúng ta có tệp "speaker_notes.pptx" với slide sau:

![Slide bản thuyết trình có ghi chú người nói](slide_with_notes.png)

Đoạn mã dưới đây minh họa cách chuyển đổi bản thuyết trình sang hình ảnh TIFF ở chế độ Notes Slide bằng phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # Hiển thị đầy đủ ghi chú người thuyết trình dưới mỗi slide.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # Cấu hình độ phân giải TIFF và bố cục ghi chú.
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # Lưu bản trình chiếu dưới dạng TIFF có ghi chú người thuyết trình.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Kết quả:

![Hình ảnh TIFF có ghi chú người nói](TIFF_with_notes.png)

{{% alert title="Tip" color="success" %}}
Khám phá Aspose [Công cụ chuyển đổi PowerPoint sang Poster miễn phí](https://products.aspose.app/slides/vi/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát vị trí khu vực ghi chú trong TIFF kết quả không?**

Có. Cấu hình [setNotesPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) với [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomTruncated) để đặt ghi chú trên một trang, có thể cắt bớt chúng, hoặc [NotesPositions.BottomFull](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomFull) để hiển thị tất cả ghi chú bằng cách sử dụng các trang bổ sung khi cần. Để xuất các slide mà không có ghi chú, bỏ qua cấu hình bố cục ghi chú như được mô tả trong [Convert PowerPoint to TIFF](/slides/vi/python-java/convert-powerpoint-to-tiff/).

**Làm thế nào để giảm kích thước tệp TIFF có ghi chú mà không làm mất chất lượng hình ảnh?**

Sử dụng nén [LZW compression](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffcompressiontypes/#LZW) không mất dữ liệu thông qua [setCompressionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/#setCompressionType). Giảm độ phân giải hoặc độ sâu màu có thể giảm kích thước tệp hơn, nhưng có thể ảnh hưởng đến chất lượng hình ảnh và khả năng đọc ghi chú. Xem [TIFF export settings](/slides/vi/python-java/convert-powerpoint-to-tiff/) để biết thêm tùy chọn.

**Phông chữ trong ghi chú có ảnh hưởng đến kết quả nếu các phông chữ gốc không có trong hệ thống không?**

Có. Các phông chữ bị thiếu sẽ kích hoạt [font substitution](/slides/vi/python-java/font-selection-sequence/), có thể thay đổi các thông số và giao diện của văn bản. [Cung cấp các phông chữ cần thiết](/slides/vi/python-java/custom-font/) để giữ nguyên kiểu chữ mong muốn.