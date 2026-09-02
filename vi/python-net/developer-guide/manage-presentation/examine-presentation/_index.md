---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trong Python
linktitle: Thông tin Bản trình chiếu
type: docs
weight: 30
url: /vi/python-net/examine-presentation/
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
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng Python để có được cái nhìn nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình chiếu và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng bản trình chiếu đầy đủ. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng một kho lưu trữ, hoặc kiểm tra các thuộc tính trước khi quyết định có nên tải và xử lý nội dung bản trình chiếu hay không.

Bài viết này trình bày cách kiểm tra nhẹ nhàng thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/) và [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/), cũng như cách cập nhật mục tiêu thông qua [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/).

## **Kiểm tra định dạng bản trình chiếu**

Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) để kiểm tra tệp mà không tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Thuộc tính [PresentationInfo.load_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/load_format/) báo cáo định dạng đã phát hiện, chẳng hạn PPTX, PPT hoặc ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Xây dựng kho lưu trữ bản trình chiếu nhẹ**

Khi bạn xử lý nhiều tệp bản trình chiếu, bạn có thể cần một kho lưu trữ gọn nhẹ để xác thực, lập chỉ mục, hoặc cho hệ thống quản lý tài liệu. Trong trường hợp này, sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) để lấy một đối tượng [PresentationInfo](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/), sau đó gọi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và cũng không yêu cầu bạn duyệt qua mô hình đối tượng bản trình chiếu đầy đủ.

Các thuộc tính mở rộng do [DocumentProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/) cung cấp các giá trị kho lưu trữ sau:

| Thuộc tính | Giá trị kho lưu trữ |
| --- | --- |
| [slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/slides/vi/) | Tổng số slide. |
| [hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/hidden_slides/) | Số lượng slide ẩn. |
| [notes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/notes/) | Số slide chứa ghi chú. |
| [paragraphs](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/paragraphs/) | Tổng số đoạn, nếu có. |
| [words](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/words/) | Tổng số từ. |
| [multimedia_clips](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/multimedia_clips/) | Tổng số đoạn âm thanh và video. |

Ví dụ dưới đây đọc các giá trị này mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và in ra một kho lưu trữ gọn nhẹ. Nó cũng kết hợp [heading_pairs](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/heading_pairs/) với [titles_of_parts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/titles_of_parts/) để hiển thị các nhóm nội dung như phông chữ, chủ đề và tiêu đề slide.

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

Mỗi [HeadingPair](https://reference.aspose.com/slides/vi/python-net/aspose.slides/headingpair/) cung cấp một tên nhóm và số mục trong nhóm đó. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/titles_of_parts/) là một tập hợp phẳng, có thứ tự, vì vậy hãy tiêu thụ số tiêu đề liên tiếp được chỉ định bởi mỗi cặp tiêu đề.

### **Siêu dữ liệu được lưu và các giới hạn định dạng**

Các thuộc tính kho lưu trữ được trả về bởi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) phản ánh siêu dữ liệu có sẵn trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình chiếu để tính lại các giá trị này cho lời gọi này. Các thuộc tính thiếu được biểu thị bằng giá trị mặc định, và các giá trị đã lưu có thể đã lỗi thời nếu ứng dụng đã lưu tệp lần cuối không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng cung cấp các thuộc tính tài liệu mở rộng cho số lượng slide, ghi chú, slide ẩn, đoạn, từ và clip đa phương tiện, cũng như các cặp tiêu đề và tiêu đề phần. Tính khả dụng phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính không tồn tại hoặc không được nhà sản xuất tài liệu làm mới, Aspose.Slides sẽ trả về giá trị đã lưu hoặc mặc định thay vì tính toán lại từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp các thống kê chung của tài liệu, chẳng hạn số trang, đoạn và từ, nhưng các giá trị này không ánh xạ tới mọi thuộc tính mở rộng đặc trưng của PowerPoint. Siêu dữ liệu về slide ẩn, slide ghi chú, đa phương tiện, cặp tiêu đề và tiêu đề phần có thể không khả dụng, và các thuộc tính kho lưu trữ có thể trả về giá trị mặc định. Đừng coi một giá trị zero hoặc một tập hợp rỗng là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho các kho lưu trữ và kiểm tra sơ bộ. Tải bản trình chiếu và kiểm tra mô hình đối tượng sống khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình chiếu.

## **Cập nhật thuộc tính bản trình chiếu**

Các thuộc tính được trả về bởi [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/) cũng có thể được thay đổi mà không tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Áp dụng các thay đổi với [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/update_document_properties/), sau đó ghi bản trình chiếu đã liên kết bằng [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Hình ảnh dưới đây hiển thị các thuộc tính tài liệu gốc của bản trình chiếu PowerPoint.

![Thuộc tính tài liệu gốc của bản trình chiếu PowerPoint](input_properties.png)

Ví dụ dưới đây thay đổi tiêu đề và thời gian lưu lần cuối và ghi kết quả vào một tệp mới:

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

Hình ảnh dưới đây hiển thị các thuộc tính tài liệu đã cập nhật của bản trình chiếu PowerPoint.

![Thuộc tính tài liệu đã cập nhật của bản trình chiếu PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật liên quan và cài đặt bảo vệ, xem các bài viết sau:

- [Bảo mật bằng mật khẩu cho bản trình chiếu](/slides/vi/python-net/password-protected-presentation/)
- [Bảo vệ bản trình chiếu bằng ghi](/slides/vi/python-net/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể kiểm tra các phông chữ đã được nhúng và chúng là những phông nào?**

Tải bản trình chiếu và sử dụng [Presentation.fonts_manager](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/fonts_manager/). Gọi [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) để lấy các phông đã nhúng và [FontsManager.get_fonts](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsmanager/get_fonts/) để lấy các phông được bản trình chiếu sử dụng. So sánh hai kết quả để tìm các phông cần thiết cho việc render nhưng chưa được nhúng.

**Làm thế nào tôi có thể nhanh chóng biết tệp có slide ẩn và có bao nhiêu?**

Khi siêu dữ liệu tài liệu đã lưu là đủ, đọc [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/hidden_slides/) thông qua [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) và [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/read_document_properties/). Cách này phù hợp cho một kho lưu trữ nhẹ. Nếu bản trình chiếu đã được sửa đổi trong bộ nhớ, siêu dữ liệu đã lưu có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh các giá trị sống, hãy duyệt qua [Presentation.slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) và kiểm tra thuộc tính [Slide.hidden](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/hidden/) của mỗi slide thay vì.

**Tôi có thể phát hiện xem kích thước slide tùy chỉnh và hướng độ ảnh được sử dụng hay không, và chúng có khác so với mặc định không?**

Có. Tải bản trình chiếu và đọc [Presentation.slide_size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slide_size/). Kiểm tra [SlideSize.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/size/) và [SlideSize.orientation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesize/orientation/) để so sánh cài đặt hiện tại với preset và kích thước dự kiến.

**Có cách nhanh để xem biểu đồ có tham chiếu tới nguồn dữ liệu bên ngoài không?**

Có. Định vị mỗi [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/) và kiểm tra [ChartData.data_source_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/data_source_type/). Đối với một workbook bên ngoài, đọc [ChartData.external_workbook_path](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Kiểu nguồn dữ liệu và đường dẫn cho biết có tham chiếu bên ngoài, nhưng việc xác minh nguồn có khả dụng hay không đòi hỏi kiểm tra tài nguyên riêng.

**Làm thế nào tôi có thể đánh giá các slide “nặng” có thể làm chậm việc render hoặc xuất PDF?**

Không có một thuộc tính độ phức tạp duy nhất. Duyệt [Presentation.slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/slides/vi/) và bộ sưu tập [BaseSlide.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/shapes/) của mỗi slide. Sử dụng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện như các dấu hiệu sàng lọc, và đo một lần render hoặc xuất mẫu trước khi coi một slide là nút thắt hiệu năng đã được xác nhận.