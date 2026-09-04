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
description: "Tìm hiểu cách mở các bài thuyết trình PowerPoint và OpenDocument trong Python, cung cấp mật khẩu mở, và giảm việc sử dụng bộ nhớ với Aspose.Slides for Python via .NET."
---
## **Giới thiệu**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/vi/python-net/) có thể tải các bài thuyết trình PowerPoint và OpenDocument từ tệp và luồng. Sau khi bài thuyết trình được tải, bạn có thể kiểm tra cấu trúc, chỉnh sửa các slide, quản lý tài nguyên và lưu nó ở định dạng gốc hoặc định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở Bài Thuyết Trình**

Để mở một bài thuyết trình hiện có, truyền đường dẫn tệp của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Sử dụng câu lệnh `with` để các trình xử lý tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ Python sau cho thấy cách mở một bài thuyết trình và lấy số lượng slide:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Mở Bài Thuyết Trình Được Bảo Vệ Bằng Mật Khẩu**

Mật khẩu mở mã hoá nội dung bài thuyết trình. Để tải toàn bộ bài thuyết trình, gán mật khẩu đúng vào [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/) và truyền các tùy chọn này vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Để tìm hiểu về phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/python-net/password-protected-presentation/). Nếu một bài thuyết trình đã được mã hoá nhưng cố ý lưu kèm các thuộc tính tài liệu công khai, các thuộc tính này có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/python-net/presentation-properties/).

## **Mở Bài Thuyết Trình Lớn**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/blob_management_options/) kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời, và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Đoạn mã Python sau minh họa cách tải một bài thuyết trình lớn (ví dụ, 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Ghi chú" %}}
Với `PresentationLockingBehavior.KEEP_LOCKED`, tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng `Presentation` được giải phóng. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng này còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào trong quá trình tải. Đối với các bài thuyết trình lớn, việc sử dụng đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/python-net/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Tải Bài Thuyết Trình mà Không Có Đối Tượng Nhị Phân Nhúng**

Một bài thuyết trình có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Ví dụ bao gồm:

- Dự án VBA, có sẵn qua [Presentation.vba_project](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/vba_project/);
- Dữ liệu OLE được nhúng, có sẵn qua [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- Dữ liệu điều khiển ActiveX, có sẵn qua [Control.active_x_control_binary](https://reference.aspose.com/slides/vi/python-net/aspose.slides/control/active_x_control_binary/).

Đặt [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) thành `True` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bài thuyết trình đã tải để duy trì kết quả đã được làm sạch.

Tùy chọn này giảm thiểu việc phơi bày các payload nhúng không mong muốn, nhưng không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung hoàn chỉnh.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides sẽ ném ra một ngoại lệ phân tích hoặc định dạng trong quá trình tải. Hãy xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì sẽ xảy ra nếu các phông chữ bắt buộc bị thiếu?**

Bài thuyết trình vẫn có thể được tải, nhưng việc hiển thị và xuất ra có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/python-net/font-substitution/) hoặc [provide custom fonts](/slides/vi/python-net/custom-font/) để làm cho kết quả đầu ra dự đoán được hơn.

**Việc tải một bài thuyết trình có đồng thời tải các phương tiện nhúng không?**

Audio và video được nhúng sẽ khả dụng thông qua mô hình đối tượng của bài thuyết trình. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên mặc định và có thể không khả dụng nếu không thể truy cập vị trí của chúng.