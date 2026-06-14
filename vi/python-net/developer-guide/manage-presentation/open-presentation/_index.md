---
title: Mở Bài Thuyết Trình trong Python
linktitle: Mở Bài Thuyết Trình
type: docs
weight: 20
url: /vi/python-net/open-presentation/
keywords:
- mở PowerPoint
- mở bài thuyết trình
- mở PPTX
- mở PPT
- mở ODP
- tải bài thuyết trình
- tải PPTX
- tải PPT
- tải ODP
- bài thuyết trình được bảo vệ
- bài thuyết trình lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- Python
- Aspose.Slides
description: "Mở các bài thuyết trình PowerPoint (.pptx, .ppt) và OpenDocument (.odp) một cách dễ dàng với Aspose.Slides cho Python qua .NET—nhanh, đáng tin cậy, đầy đủ tính năng."
---
## **Giới thiệu**

Ngoài việc tạo bài thuyết trình PowerPoint từ đầu, Aspose.Slides còn cho phép bạn mở các bài thuyết trình đã tồn tại. Sau khi tải một bài thuyết trình, bạn có thể lấy thông tin về nó, chỉnh sửa nội dung slide, thêm slide mới, xóa các slide hiện có, và hơn nữa.

## **Mở Bài Thuyết Trình**

Để mở một bài thuyết trình hiện có, khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và truyền đường dẫn tệp vào hàm tạo của nó.

Ví dụ Python sau đây cho thấy cách mở một bài thuyết trình và lấy số lượng slide của nó:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation và truyền đường dẫn tệp vào hàm tạo của nó.
with slides.Presentation("sample.pptx") as presentation:
    # In ra tổng số slide trong bài thuyết trình.
    print(presentation.slides.length)
```

## **Mở Bài Thuyết Trình Được Bảo Vệ Bằng Mật Khẩu**

Khi bạn cần mở một bài thuyết trình được bảo vệ bằng mật khẩu, hãy truyền mật khẩu qua thuộc tính [password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/) của lớp [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/) để giải mã và tải nó. Đoạn mã Python sau đây minh họa thao tác này:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Thực hiện các thao tác trên bài thuyết trình đã giải mã.
```

## **Mở Bài Thuyết Trình Lớn**

Aspose.Slides cung cấp các tùy chọn—đặc biệt là thuộc tính [blob_management_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/blob_management_options/) trong lớp [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/)—để giúp bạn tải các bài thuyết trình lớn.

Đoạn mã Python sau đây minh họa việc tải một bài thuyết trình lớn (ví dụ, 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Chọn hành vi KeepLocked — tệp bài thuyết trình sẽ được khóa trong suốt thời gian tồn tại của 
# đối tượng Presentation, nhưng không cần phải tải vào bộ nhớ hoặc sao chép vào tệp tạm thời.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Bài thuyết trình lớn đã được tải và có thể sử dụng, trong khi tiêu thụ bộ nhớ vẫn ở mức thấp.

    # Thực hiện các thay đổi cho bài thuyết trình.
    presentation.slides[0].name = "Large presentation"

    # Lưu bài thuyết trình ra tệp khác. Tiêu thụ bộ nhớ vẫn ở mức thấp trong quá trình này.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Đừng làm điều này! Một ngoại lệ I/O sẽ được ném ra vì tệp bị khóa cho đến khi đối tượng Presentation được giải phóng.
    os.remove(file_path)

# Ở đây có thể thực hiện được. Tệp nguồn không còn bị khóa bởi đối tượng Presentation.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Để khắc phục một số hạn chế nhất định khi làm việc với stream, Aspose.Slides có thể sao chép nội dung của stream. Tải một bài thuyết trình lớn từ stream sẽ gây sao chép bài thuyết trình và có thể làm chậm quá trình tải. Do đó, khi bạn cần tải một bài thuyết trình lớn, chúng tôi mạnh mẽ khuyến cáo sử dụng đường dẫn tệp của bài thuyết trình thay vì stream.

Khi tạo một bài thuyết trình chứa các đối tượng lớn (video, audio, hình ảnh độ phân giải cao, v.v.), bạn có thể sử dụng [BLOB management](/slides/vi/python-net/manage-blob/) để giảm tiêu thụ bộ nhớ.
{{%/alert %}}

## **Tải Bài Thuyết Trình Không Có Đối Tượng Nhị Phân Nhúng**

Một bài thuyết trình PowerPoint có thể chứa các loại đối tượng nhị phân nhúng sau:

- Dự án VBA (có thể truy cập qua [Presentation.vba_project](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/vba_project/));
- Dữ liệu nhúng của đối tượng OLE (có thể truy cập qua [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Dữ liệu nhị phân của điều khiển ActiveX (có thể truy cập qua [Control.active_x_control_binary](https://reference.aspose.com/slides/vi/python-net/aspose.slides/control/active_x_control_binary/)).

Bằng cách sử dụng thuộc tính [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), bạn có thể tải một bài thuyết trình mà không có bất kỳ đối tượng nhị phân nhúng nào.

Thuộc tính này hữu ích để loại bỏ nội dung nhị phân có thể gây hại. Đoạn mã Python sau đây minh họa cách tải một bài thuyết trình mà không có bất kỳ nội dung nhị phân nhúng nào:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Thực hiện các thao tác trên bài thuyết trình.
```

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Bạn sẽ nhận được một ngoại lệ xác thực/định dạng khi phân tích trong quá trình tải. Các lỗi này thường đề cập tới cấu trúc ZIP không hợp lệ hoặc các bản ghi PowerPoint bị hỏng.

**Điều gì sẽ xảy ra nếu các phông chữ bắt buộc thiếu khi mở?**

Tệp sẽ mở được, nhưng sau đó [rendering/export](/slides/vi/python-net/convert-presentation/) có thể thay thế phông chữ. [Configure font substitutions](/slides/vi/python-net/font-substitution/) hoặc [add the required fonts](/slides/vi/python-net/custom-font/) vào môi trường runtime.

**Còn các phương tiện nhúng (video/audio) khi mở thì sao?**

Chúng sẽ trở thành tài nguyên của bài thuyết trình. Nếu các phương tiện được tham chiếu qua đường dẫn bên ngoài, hãy đảm bảo những đường dẫn đó có thể truy cập trong môi trường của bạn; nếu không [rendering/export](/slides/vi/python-net/convert-presentation/) có thể bỏ qua các phương tiện.