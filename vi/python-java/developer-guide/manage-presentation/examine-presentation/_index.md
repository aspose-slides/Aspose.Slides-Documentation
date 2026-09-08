---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trong Python thông qua Java
linktitle: Thông tin Bản trình chiếu
type: docs
weight: 30
url: /vi/python-java/examine-presentation/
keywords:
- định dạng bản trình chiếu
- thuộc tính bản trình chiếu
- thuộc tính tài liệu
- lấy thuộc tính
- đọc thuộc tính
- thay đổi thuộc tính
- sửa đổi thuộc tính
- cập nhật thuộc tính
- kiểm tra PPTX
- kiểm tra PPT
- kiểm tra ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng Python thông qua Java để có cái nhìn nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình chiếu và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng bản trình chiếu đầy đủ. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng danh mục, hoặc kiểm tra các thuộc tính trước khi quyết định có tải và xử lý nội dung bản trình chiếu hay không.

Các ví dụ yêu cầu Aspose.Slides cho Python thông qua Java và một môi trường Java tương thích. Mỗi ví dụ sẽ khởi động JVM nếu chưa chạy. Cung cấp các tệp trình chiếu hiện có tại các đường dẫn được sử dụng trong các ví dụ.

Bài viết này trình bày cách kiểm tra nhẹ nhàng thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/) và [PresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/), cũng như các cập nhật có mục tiêu thông qua [DocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/).

## **Kiểm tra định dạng bản trình chiếu**

Sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) để kiểm tra tệp mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Phương thức [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#getLoadFormat) báo cáo định dạng được phát hiện, chẳng hạn PPTX, PPT, hoặc ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Xây dựng danh mục bản trình chiếu nhẹ**

Khi bạn xử lý nhiều tệp bản trình chiếu, bạn có thể cần một danh mục gọn gàng để xác thực, lập chỉ mục, hoặc hệ thống quản lý tài liệu. Trong trường hợp này, sử dụng [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) để lấy một đối tượng [PresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/), sau đó gọi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và không yêu cầu bạn duyệt qua toàn bộ mô hình đối tượng bản trình chiếu.

Các thuộc tính mở rộng được cung cấp bởi [DocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/) cung cấp các giá trị danh mục sau:

| Phương thức | Giá trị danh mục |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getSlides) | Tổng số slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Số slide ẩn. |
| [getNotes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getNotes) | Số slide có ghi chú. |
| [getParagraphs](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getParagraphs) | Tổng số đoạn văn, nếu có. |
| [getWords](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getWords) | Tổng số từ. |
| [getMultimediaClips](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Tổng số đoạn audio và video. |

Ví dụ sau đọc các giá trị này mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và in ra một danh mục gọn gàng. Nó cũng kết hợp [getHeadingPairs](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getHeadingPairs) với [getTitlesOfParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) để hiển thị các nhóm nội dung như phông chữ, giao diện và tiêu đề slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Mỗi [HeadingPair](https://reference.aspose.com/slides/vi/python-java/aspose.slides/headingpair/) cung cấp một tên nhóm và số mục trong nhóm đó. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) trả về một mảng phẳng, có thứ tự, vì vậy hãy tiêu thụ số tiêu đề liên tiếp được chỉ định bởi mỗi heading pair.

### **Siêu dữ liệu lưu trữ và hạn chế định dạng**

Các thuộc tính danh mục trả về bởi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) phản ánh siêu dữ liệu có sẵn trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình chiếu để tính lại các giá trị này cho cuộc gọi này. Các thuộc tính thiếu sẽ được biểu diễn bằng giá trị mặc định, và các giá trị lưu trữ có thể đã lỗi thời nếu ứng dụng lưu tệp lần cuối không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng cung cấp các thuộc tính tài liệu mở rộng cho số slide, ghi chú, slide ẩn, đoạn văn, từ và số lượng đa phương tiện, cũng như heading pairs và tiêu đề phần. Tính khả dụng phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính thiếu hoặc không được nhà sản xuất tài liệu làm mới, Aspose.Slides sẽ trả về giá trị lưu trữ hoặc mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp thống kê tổng quan tài liệu, chẳng hạn số trang, đoạn văn và từ, nhưng các giá trị này không tương ứng với mọi thuộc tính mở rộng đặc thù của PowerPoint. Siêu dữ liệu slide ẩn, slide ghi chú, đa phương tiện, heading-pair và part-title có thể không có, và các thuộc tính danh mục có thể trả về giá trị mặc định. Đừng coi một giá trị zero hoặc một mảng trống là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho danh mục và kiểm tra sơ bộ. Tải bản trình chiếu và kiểm tra mô hình đối tượng sống của nó khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình chiếu.

## **Cập nhật thuộc tính bản trình chiếu**

Các thuộc tính trả về bởi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) cũng có thể được thay đổi mà không tạo một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Áp dụng các thay đổi bằng [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), sau đó ghi bản trình chiếu đã liên kết bằng [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Hình ảnh sau hiển thị các thuộc tính tài liệu gốc của bản trình chiếu PowerPoint:

![Thuộc tính tài liệu gốc của bản trình chiếu PowerPoint](input_properties.png)

Ví dụ sau thay đổi tiêu đề và thời gian lưu lần cuối và ghi kết quả vào một tệp mới:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Hình ảnh sau hiển thị các thuộc tính tài liệu đã được cập nhật:

![Thuộc tính tài liệu đã được thay đổi của bản trình chiếu PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật và cài đặt bảo vệ liên quan, xem các bài viết sau:

- [Bảo mật Bản trình chiếu bằng Mật khẩu](/slides/vi/python-java/password-protected-presentation/)
- [Bảo vệ Bản trình chiếu khi Ghi](/slides/vi/python-java/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là gì?**

Tải bản trình chiếu và sử dụng [Presentation.getFontsManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getFontsManager). Gọi [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) để lấy các phông chữ đã nhúng và [FontsManager.getFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsmanager/#getFonts) để lấy các phông chữ được sử dụng trong bản trình chiếu. So sánh hai kết quả để tìm các phông chữ cần thiết cho việc hiển thị nhưng chưa được nhúng.

**Làm thế nào tôi có thể nhanh chóng xác định tệp có slide ẩn và có bao nhiêu?**

Khi siêu dữ liệu tài liệu lưu trữ đủ, đọc [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#getHiddenSlides) thông qua [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) và [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Điều này phù hợp cho một danh mục nhẹ. Nếu bản trình chiếu đã được sửa đổi trong bộ nhớ, siêu dữ liệu lưu trữ có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh các giá trị thực tế, hãy duyệt qua [Presentation.getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) và kiểm tra phương thức [Slide.getHidden](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getHidden) của mỗi slide.

**Tôi có thể phát hiện liệu kích thước và hướng slide tùy chỉnh có được sử dụng hay không, và chúng có khác so với mặc định không?**

Có. Tải bản trình chiếu và gọi [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlideSize). Sử dụng [SlideSize.getType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesize/#getSize) và [SlideSize.getOrientation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesize/#getOrientation) để so sánh các cài đặt hiện tại với preset và kích thước dự kiến.

**Có cách nhanh để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Xác định mỗi [Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/) và gọi [ChartData.getDataSourceType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getDataSourceType). Đối với workbook bên ngoài, gọi [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Loại nguồn dữ liệu và đường dẫn xác định một tham chiếu bên ngoài, nhưng việc xác minh liệu mục tiêu có sẵn hay không cần một kiểm tra tài nguyên riêng.

**Làm thế nào tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Không có một thuộc tính độ phức tạp duy nhất. Duyệt qua [Presentation.getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) và bộ sưu tập [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getShapes) của mỗi slide. Sử dụng số lượng hình dạng và sự xuất hiện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện như các tín hiệu sàng lọc, và đo một lần render hoặc xuất mẫu trước khi coi một slide là nút thắt hiệu năng đã xác nhận.