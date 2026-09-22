---
title: Truy xuất và Cập nhật Thông tin Bản trình bày bằng Python
linktitle: Thông tin Bản trình bày
type: docs
weight: 30
url: /vi/python-net/examine-presentation/
keywords:
- định dạng bản trình bày
- thuộc tính bản trình bày
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
- bản trình bày
- Python
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong bản trình bày PowerPoint và OpenDocument bằng Python để có cái nhìn nhanh hơn và kiểm toán nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể nhận dạng định dạng của bản trình bày và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng bản trình bày đầy đủ. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng một danh mục, hoặc kiểm tra các thuộc tính trước khi quyết định có tải và xử lý nội dung bản trình bày hay không.

Bài viết này trình bày cách kiểm tra nhẹ thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/) và [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/), cũng như các cập nhật mục tiêu thông qua [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/).

## **Kiểm tra định dạng bản trình bày**

Nếu bạn đã tải một bản trình bày, xem mục [Determine the Original Presentation Format](/slides/vi/python-net/detect-presentation-source-format/) để phát hiện sau khi tải và các hạn chế của luồng PPT, PPS và POT cũ.

Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) để kiểm tra tệp mà không tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Thuộc tính [PresentationInfo.load_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/load_format/) báo cáo định dạng đã phát hiện, chẳng hạn PPTX, PPT hoặc ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Xây dựng danh mục bản trình bày nhẹ**

Khi bạn xử lý nhiều tệp bản trình bày, có thể cần một danh mục gọn cho việc xác thực, lập chỉ mục hoặc hệ thống quản lý tài liệu. Trong trường hợp này, hãy dùng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) để lấy đối tượng [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/), sau đó gọi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và không yêu cầu bạn duyệt toàn bộ mô hình đối tượng bản trình bày.

Các thuộc tính mở rộng được cung cấp bởi [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/) đưa ra các giá trị danh mục sau:

| Thuộc tính | Giá trị tồn kho |
| --- | --- |
| [slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/slides/vi/) | Tổng số slide. |
| [hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/hidden_slides/) | Số slide ẩn. |
| [notes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/notes/) | Số slide có ghi chú. |
| [paragraphs](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/paragraphs/) | Tổng số đoạn văn, nếu có. |
| [words](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/words/) | Tổng số từ. |
| [multimedia_clips](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/multimedia_clips/) | Tổng số đoạn âm thanh và video. |

Ví dụ sau đọc các giá trị này mà không tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và in ra một danh mục gọn. Nó cũng kết hợp [heading_pairs](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/heading_pairs/) với [titles_of_parts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/titles_of_parts/) để hiển thị các nhóm nội dung như phông chữ, chủ đề và tiêu đề slide.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Mỗi [HeadingPair](https://reference.aspose.com/slides/vi/python-net/aspose.slides/headingpair/) cung cấp một tên nhóm và số mục trong nhóm đó. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/titles_of_parts/) là một bộ sưu tập phẳng, có thứ tự, vì vậy hãy tiêu thụ số tiêu đề liên tiếp được chỉ định bởi mỗi cặp tiêu đề.

### **Siêu dữ liệu đã lưu và các hạn chế định dạng**

Các thuộc tính danh mục được trả về bởi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) phản ánh siêu dữ liệu có trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình bày để tính lại các giá trị này cho lời gọi này. Các thuộc tính thiếu sẽ được biểu thị bằng giá trị mặc định, và các giá trị đã lưu có thể lỗi thời nếu ứng dụng lưu lần cuối không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng cung cấp các thuộc tính tài liệu mở rộng cho số slide, ghi chú, slide ẩn, đoạn văn, từ và đa phương tiện, cũng như các cặp tiêu đề và tiêu đề phần. Tính sẵn có phụ thuộc vào các thuộc tính mà người tạo tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính vắng mặt hoặc không được người tạo tài liệu làm mới, Aspose.Slides sẽ trả về giá trị đã lưu hoặc mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp các thống kê chung của tài liệu, chẳng hạn số trang, đoạn văn và từ, nhưng các giá trị này không khớp với mọi thuộc tính mở rộng đặc thù của PowerPoint. Siêu dữ liệu về slide ẩn, slide ghi chú, đa phương tiện, cặp tiêu đề và tiêu đề phần có thể không khả dụng, và các thuộc tính danh mục có thể trả về giá trị mặc định. Đừng coi giá trị 0 hoặc bộ sưu tập rỗng là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho danh mục và kiểm tra sơ bộ. Tải bản trình bày và duyệt mô hình đối tượng trực tiếp khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình bày.

## **Cập nhật thuộc tính bản trình bày**

Các thuộc tính trả về bởi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) cũng có thể được thay đổi mà không tạo đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) nào. Áp dụng các thay đổi bằng [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/update_document_properties/), sau đó ghi bản trình bày đã ràng buộc bằng [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Hình ảnh sau hiển thị các thuộc tính tài liệu gốc.

![Original document properties of the PowerPoint presentation](input_properties.png)

Ví dụ sau thay đổi tiêu đề và thời gian lưu lần cuối và ghi kết quả ra tệp mới:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Hình ảnh sau hiển thị các thuộc tính tài liệu đã cập nhật.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật và cài đặt bảo vệ liên quan, xem các bài viết sau:

- [Password-Protect Presentations](/slides/vi/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/vi/python-net/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm sao kiểm tra xem phông chữ có được nhúng và là những phông nào?**

Tải bản trình bày và sử dụng [Presentation.fonts_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/fonts_manager/). Gọi [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) để lấy danh sách phông đã nhúng và [FontsManager.get_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_fonts/) để lấy phông được sử dụng trong bản trình bày. So sánh hai kết quả để tìm các phông cần thiết cho việc hiển thị nhưng chưa được nhúng.

**Làm sao nhanh chóng xác định xem tệp có slide ẩn và có bao nhiêu?**

Khi siêu dữ liệu tài liệu lưu trữ đủ, đọc [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/hidden_slides/) qua [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) và [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/). Cách này phù hợp cho một danh mục nhẹ. Nếu bản trình bày đã được sửa đổi trong bộ nhớ, siêu dữ liệu lưu có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh giá trị thực tế, hãy duyệt qua [Presentation.slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) và kiểm tra thuộc tính [Slide.hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/hidden/) của từng slide.

**Tôi có thể phát hiện liệu kích thước và hướng slide tùy chỉnh có được sử dụng và có khác so với mặc định không?**

Có. Tải bản trình bày và đọc [Presentation.slide_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slide_size/). Kiểm tra [SlideSize.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/size/) và [SlideSize.orientation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/orientation/) để so sánh cài đặt hiện tại với preset và kích thước mặc định.

**Có cách nhanh để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Xác định mỗi [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/) và kiểm tra [ChartData.data_source_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/). Đối với workbook bên ngoài, đọc [ChartData.external_workbook_path](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Loại nguồn dữ liệu và đường dẫn xác định tham chiếu bên ngoài, nhưng việc xác minh nguồn có khả dụng hay không cần kiểm tra tài nguyên riêng.

**Làm sao đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Không có thuộc tính phức tạp đơn lẻ. Duyệt [Presentation.slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) và bộ sưu tập [BaseSlide.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/shapes/) của mỗi slide. Sử dụng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện như tín hiệu sàng lọc, và đo một lần render hoặc xuất mẫu trước khi coi một slide là nút thắt hiệu năng đã xác nhận.