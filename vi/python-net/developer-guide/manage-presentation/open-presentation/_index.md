---
title: Mở bản trình bày trong Python
linktitle: Mở bản trình bày
type: docs
weight: 20
url: /vi/python-net/open-presentation/
keywords:
- mở PowerPoint
- mở bản trình bày
- mở PPTX
- mở PPT
- mở ODP
- tải bản trình bày
- tải PPTX
- tải PPT
- tải ODP
- bản trình bày được bảo vệ
- bản trình bày lớn
- nguồn tài nguyên bên ngoài
- đối tượng nhị phân
- Python
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình bày PowerPoint và OpenDocument trong Python, cung cấp mật khẩu mở, và giảm việc sử dụng bộ nhớ với Aspose.Slides cho Python qua .NET."
---
## **Giới thiệu**

[Aspose.Slides cho Python qua .NET](https://products.aspose.com/slides/vi/python-net/) có thể tải các bản trình bày PowerPoint và OpenDocument từ tệp và luồng. Sau khi một bản trình bày được tải, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa slide, quản lý tài nguyên và lưu lại ở định dạng gốc hoặc một định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở bản trình bày**

Sau khi tải một tệp hoặc luồng, bạn có thể [xác định định dạng bản trình bày gốc](/slides/vi/python-net/detect-presentation-source-format/) để chọn cách ứng dụng của bạn xử lý nó.

Để mở một bản trình bày hiện có, truyền đường dẫn tệp của nó vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Sử dụng câu lệnh `with` để các handle tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ Python sau đây cho thấy cách mở một bản trình bày và lấy số lượng slide của nó:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Mở bản trình bày được bảo vệ bằng mật khẩu**

Mật khẩu mở mã hoá nội dung bản trình bày. Để tải toàn bộ bản trình bày, gán mật khẩu đúng vào [LoadOptions.password](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/password/) và truyền các tùy chọn vào hàm tạo [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Việc tải sẽ thất bại khi mật khẩu bị thiếu hoặc sai.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Đối với các quy trình phát hiện, xác thực và mã hoá mật khẩu, xem [Bảo vệ bản trình bày bằng mật khẩu](/slides/vi/python-net/password-protected-presentation/). Nếu một bản trình bày được mã hoá được lưu cố ý với các thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Quản lý thuộc tính bản trình bày](/slides/vi/python-net/presentation-properties/).

## **Mở bản trình bày lớn**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/blob_management_options/) kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép các tệp tạm thời, và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Đoạn mã Python sau đây minh họa cách tải một bản trình bày lớn (ví dụ, 2 GB):

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

{{% alert color="info" title="Note" %}}
Với `PresentationLockingBehavior.KEEP_LOCKED`, tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng `Presentation` được giải phóng. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng này còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào khi tải. Đối với các bản trình bày lớn, đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Quản lý BLOBs](/slides/vi/python-net/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Tải bản trình bày mà không có các đối tượng nhị phân được nhúng**

Một bản trình bày có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Các ví dụ bao gồm:

- các dự án VBA, có sẵn thông qua [Presentation.vba_project](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/vba_project/);
- dữ liệu OLE được nhúng, có sẵn thông qua [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- dữ liệu điều khiển ActiveX, có sẵn thông qua [Control.active_x_control_binary](https://reference.aspose.com/slides/vi/python-net/aspose.slides/control/active_x_control_binary/).

Đặt [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) thành `True` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bản trình bày đã tải để duy trì kết quả đã làm sạch.

Tùy chọn này giảm thiểu rủi ro từ các payload nhúng không mong muốn, nhưng nó không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung hoàn chỉnh.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Làm sao tôi biết rằng một tệp bị hỏng và không thể mở?**

Aspose.Slides ném ra một ngoại lệ phân tích cú pháp hoặc định dạng khi tải. Hãy xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu các phông chữ yêu cầu bị thiếu?**

Bản trình bày vẫn có thể được tải, nhưng việc hiển thị và xuất có thể thay thế phông chữ. Bạn có thể [cấu hình thay thế phông chữ](/slides/vi/python-net/font-substitution/) hoặc [cung cấp phông chữ tùy chỉnh](/slides/vi/python-net/custom-font/) để làm cho kết quả đầu ra dự đoán được hơn.

**Việc tải một bản trình bày có đồng thời tải các phương tiện được nhúng không?**

Âm thanh và video được nhúng sẽ khả dụng qua mô hình đối tượng của bản trình bày. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên mặc định và có thể không khả dụng nếu không thể truy cập vị trí của chúng.