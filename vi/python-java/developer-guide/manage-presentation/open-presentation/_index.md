---
title: Mở các bản trình bày trong Python qua Java
linktitle: Mở Bản Trình Bày
type: docs
weight: 20
url: /vi/python-java/open-presentation/
keywords:
- Mở PowerPoint
- Mở bản trình bày
- Mở PPTX
- Mở PPT
- Mở ODP
- Tải bản trình bày
- Tải PPTX
- Tải PPT
- Tải ODP
- Bản trình bày được bảo vệ
- Bản trình bày lớn
- Tài nguyên bên ngoài
- Đối tượng nhị phân
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình bày PowerPoint và OpenDocument trong Python qua Java, cung cấp mật khẩu mở, kiểm soát tải tài nguyên và giảm việc sử dụng bộ nhớ với Aspose.Slides cho Python qua Java."
---
## **Giới thiệu**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/vi/python-java/) có thể tải các bản trình bày PowerPoint và OpenDocument từ tệp và luồng. Sau khi một bản trình bày được tải, bạn có thể kiểm tra cấu trúc, chỉnh sửa slide, quản lý tài nguyên và lưu nó ở định dạng gốc hoặc định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ heap của Java, kiểm soát tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở bản trình bày**

Sau khi tải tệp hoặc luồng, bạn có thể [xác định định dạng bản trình bày gốc](/slides/vi/python-java/detect-presentation-source-format/) để chọn cách ứng dụng của bạn xử lý nó.

Để mở một bản trình bày hiện có, truyền đường dẫn tệp của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Hủy đối tượng bản trình bày sau khi sử dụng để các tay cầm tệp, dữ liệu tạm và các tài nguyên khác được giải phóng kịp thời.

Ví dụ Python sau đây cho thấy cách mở một bản trình bày và lấy số lượng slide:

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

## **Mở bản trình bày được bảo vệ bằng mật khẩu**

Mật khẩu mở mã hoá nội dung bản trình bày. Để tải toàn bộ bản trình bày, truyền mật khẩu đúng vào [LoadOptions.setPassword](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setPassword) và cung cấp các tùy chọn cho hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không đúng.

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

Để biết thêm về phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/python-java/password-protected-presentation/). Nếu một bản trình bày được mã hoá được lưu cố ý với các thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/python-java/presentation-properties/).

## **Mở bản trình bày lớn**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Mã Python sau đây minh họa việc tải một bản trình bày lớn (ví dụ, 2 GB):

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
Với [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn vẫn bị khóa cho đến khi đối tượng bản trình bày được hủy. Không di chuyển, ghi đè hoặc xóa tệp nguồn khi đối tượng còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào khi tải. Đối với các bản trình bày lớn, việc sử dụng đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/python-java/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm soát tài nguyên bên ngoài**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) chấp nhận một proxy JPype thực thi giao diện callback tải tài nguyên Java. Callback có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định hoặc bỏ qua tài nguyên. Điều này hữu ích khi các bản trình bày chứa hình ảnh bên ngoài cần được giải quyết theo các quy tắc bảo mật hoặc lưu trữ đặc thù của ứng dụng.

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

## **Tải bản trình bày mà không có đối tượng nhị phân được nhúng**

Một bản trình bày có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Các ví dụ bao gồm:

- Dự án VBA, có sẵn qua [Presentation.getVbaProject](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getVbaProject);
- dữ liệu OLE được nhúng, có sẵn qua [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dữ liệu điều khiển ActiveX, có sẵn qua [Control.getActiveXControlBinary](https://reference.aspose.com/slides/vi/python-java/aspose.slides/control/#getActiveXControlBinary).

Đặt [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) thành `True` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bản trình bày đã tải để giữ lại kết quả đã được làm sạch.

Tùy chọn này giảm thiểu việc tiếp xúc với các tải trọng nhúng không mong muốn, nhưng không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung hoàn chỉnh.

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

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides sẽ ném ra ngoại lệ phân tích hoặc định dạng trong quá trình tải. Xử lý lỗi này riêng biệt so với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu phông chữ yêu cầu bị thiếu?**

Bản trình bày vẫn có thể tải, nhưng việc render và xuất có thể thay thế phông chữ. Bạn có thể [cấu hình thay thế phông chữ](/slides/vi/python-java/font-substitution/) hoặc [cung cấp phông chữ tùy chỉnh](/slides/vi/python-java/custom-font/) để kết quả đầu ra dự đoán được hơn.

**Việc tải một bản trình bày có đồng thời tải các phương tiện được nhúng không?**

Âm thanh và video được nhúng sẽ khả dụng qua mô hình đối tượng của bản trình bày. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập vị trí của chúng.