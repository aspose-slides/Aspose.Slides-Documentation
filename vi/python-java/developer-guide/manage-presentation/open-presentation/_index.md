---
title: Mở các bản trình chiếu trong Python qua Java
linktitle: Mở bản trình chiếu
type: docs
weight: 20
url: /vi/python-java/open-presentation/
keywords:
- mở PowerPoint
- mở bản trình chiếu
- mở PPTX
- mở PPT
- mở ODP
- tải bản trình chiếu
- tải PPTX
- tải PPT
- tải ODP
- bản trình chiếu được bảo vệ
- bản trình chiếu lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình chiếu PowerPoint và OpenDocument trong Python qua Java, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm sử dụng bộ nhớ với Aspose.Slides cho Python qua Java."
---
## **Giới thiệu**

[Aspose.Slides cho Python qua Java](https://products.aspose.com/slides/vi/python-java/) có thể tải các bản trình chiếu PowerPoint và OpenDocument từ tệp và luồng. Sau khi tải bản trình chiếu, bạn có thể kiểm tra cấu trúc, chỉnh sửa các slide, quản lý tài nguyên và lưu lại dưới định dạng gốc hoặc một định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ heap của Java, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở bản trình chiếu**

Để mở một bản trình chiếu hiện có, truyền đường dẫn tệp vào hàm khởi tạo của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Giải phóng (dispose) bản trình chiếu sau khi sử dụng để các tay cầm tệp, dữ liệu tạm và các tài nguyên khác được giải phóng kịp thời.

Ví dụ Python sau đây cho thấy cách mở một bản trình chiếu và lấy số slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Mở các bản trình chiếu có mật khẩu**

Mật khẩu mở mã hoá nội dung bản trình chiếu. Để tải toàn bộ bản trình chiếu, truyền mật khẩu đúng vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setPassword) và cung cấp các tùy chọn này cho hàm khởi tạo của [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Đối với việc phát hiện, xác thực và quy trình mã hoá mật khẩu, xem mục [Password-Protect Presentations](/slides/vi/python-java/password-protected-presentation/). Nếu một bản trình chiếu được mã hoá nhưng được lưu có các thuộc tính tài liệu công khai, những thuộc tính này vẫn có thể đọc được mà không cần mật khẩu; xem mục [Manage Presentation Properties](/slides/vi/python-java/presentation-properties/).

## **Mở các bản trình chiếu lớn**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tạo tệp tạm, và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Đoạn mã Python sau minh họa cách tải một bản trình chiếu lớn (ví dụ, 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Với [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng Presentation được giải phóng. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng này còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng nhập trong quá trình tải. Đối với các bản trình chiếu lớn, đường dẫn tệp thường hiệu quả hơn so với luồng. Xem mục [Manage BLOBs](/slides/vi/python-java/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm soát tài nguyên bên ngoài**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) nhận một proxy JPype thực hiện giao diện callback tải tài nguyên của Java. Callback có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Tính năng này hữu ích khi bản trình chiếu chứa các hình ảnh bên ngoài cần được giải quyết theo quy tắc bảo mật hoặc lưu trữ riêng của ứng dụng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Tải bản trình chiếu mà không có các đối tượng nhị phân được nhúng**

Một bản trình chiếu có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Các ví dụ bao gồm:

- Dự án VBA, truy cập qua [Presentation.getVbaProject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getVbaProject);
- Dữ liệu OLE được nhúng, truy cập qua [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- Dữ liệu điều khiển ActiveX, truy cập qua [Control.getActiveXControlBinary](https://reference.aspose.com/slides/vi/python-java/aspose.slides/control/#getActiveXControlBinary).

Đặt [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) thành `True` để xóa dữ liệu nhị phân này khi tải. Lưu bản trình chiếu đã tải để lưu lại kết quả đã được làm sạch.

Tùy chọn này giảm thiểu rủi ro các payload nhúng không mong muốn, nhưng không phải là một hệ thống phát hiện phần mềm độc hại hay làm sạch nội dung hoàn chỉnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một tệp đã bị hỏng và không thể mở?**

Aspose.Slides sẽ ném ngoại lệ phân tích hoặc định dạng trong quá trình tải. Xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì sẽ xảy ra nếu các phông chữ bắt buộc bị thiếu?**

Bản trình chiếu vẫn có thể tải, nhưng việc hiển thị và xuất có thể thay thế phông chữ. Bạn có thể [cấu hình thay thế phông chữ](/slides/vi/python-java/font-substitution/) hoặc [cung cấp phông chữ tùy chỉnh](/slides/vi/python-java/custom-font/) để làm cho kết quả đầu ra dự đoán được hơn.

**Việc tải một bản trình chiếu có đồng thời tải các phương tiện nhúng không?**

Âm thanh và video được nhúng sẽ khả dụng thông qua mô hình đối tượng của bản trình chiếu. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không có sẵn nếu không thể truy cập được vị trí của chúng.