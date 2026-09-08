---
title: Quản lý BLOB trong Bài thuyết trình bằng Python qua Java để Tối ưu Sử dụng Bộ nhớ
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/python-java/manage-blob/
keywords:
  - đối tượng lớn
  - mục lớn
  - tệp lớn
  - thêm BLOB
  - xuất BLOB
  - thêm hình ảnh dưới dạng BLOB
  - giảm bộ nhớ
  - tiêu thụ bộ nhớ
  - bài thuyết trình lớn
  - tệp tạm thời
  - PowerPoint
  - OpenDocument
  - bài thuyết trình
  - Python
  - Java
  - Aspose.Slides
description: "Quản lý dữ liệu BLOB trong Aspose.Slides cho Python qua Java để tối ưu hoá các thao tác với tệp PowerPoint và OpenDocument, nâng cao hiệu quả xử lý bài thuyết trình."
---
## **Tổng quan**

Aspose.Slides cung cấp xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bài thuyết trình để giúp giảm tiêu thụ bộ nhớ khi làm việc với hình ảnh, âm thanh, video và tệp bài thuyết trình kích thước lớn.

Bài viết này trình bày cách sử dụng xử lý dựa trên BLOB để thêm phương tiện lớn vào bài thuyết trình, xuất phương tiện lớn ra khỏi bài thuyết trình và tải các bài thuyết trình lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng các tệp tạm thời trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một mục lớn (hình ảnh, bài thuyết trình, tài liệu hoặc phương tiện) được lưu dưới dạng nhị phân.

Aspose.Slides for Python via Java cho phép bạn sử dụng BLOB cho các đối tượng theo cách giảm tiêu thụ bộ nhớ khi các tệp lớn liên quan.

{{% alert color="info" title="Note" %}}
Để tránh một số giới hạn khi tương tác với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Tải một bài thuyết trình lớn thông qua luồng của nó sẽ gây ra việc sao chép nội dung bài thuyết trình và khiến việc tải chậm lại. Do đó, khi bạn muốn tải một bài thuyết trình lớn, chúng tôi khuyến nghị mạnh mẽ rằng bạn sử dụng đường dẫn tệp bài thuyết trình chứ không phải luồng của nó.
{{% /alert %}}

## **Sử dụng BLOB để giảm tiêu thụ bộ nhớ**

### **Thêm tệp lớn qua BLOB vào bài thuyết trình**

[Aspose.Slides](/slides/vi/python-java/) for Python via Java cho phép bạn thêm các tệp lớn (trong trường hợp này là một tệp video lớn) thông qua quy trình sử dụng BLOB để giảm tiêu thụ bộ nhớ.

Đoạn mã Python sau cho bạn thấy cách thêm tệp video lớn qua quy trình BLOB vào một bài thuyết trình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# Tạo một bài thuyết trình mới để thêm video vào.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # Giữ luồng ở trạng thái khóa vì chúng tôi không dự định truy cập tệp video.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # Lưu bài thuyết trình trong khi giữ mức tiêu thụ bộ nhớ thấp.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **Xuất tệp lớn qua BLOB từ bài thuyết trình**

Aspose.Slides for Python via Java cho phép bạn xuất các tệp lớn (trong trường hợp này là tệp âm thanh hoặc video) thông qua quy trình sử dụng BLOB từ các bài thuyết trình. Ví dụ, bạn có thể cần trích xuất một tệp phương tiện lớn từ bài thuyết trình nhưng không muốn tệp này được tải vào bộ nhớ máy tính của bạn. Bằng cách xuất tệp qua quy trình BLOB, bạn duy trì mức tiêu thụ bộ nhớ thấp.

Đoạn mã Python dưới đây minh họa thao tác đã mô tả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# Khóa tệp nguồn thay vì tải nó vào bộ nhớ.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # Chuyển dữ liệu video qua bộ đệm để giữ mức tiêu thụ bộ nhớ thấp.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # Sử dụng luồng thay vì tải toàn bộ video vào mảng byte.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # Nếu cần, áp dụng các bước tương tự cho tệp âm thanh.
finally:
    presentation.dispose()
```

### **Thêm hình ảnh dưới dạng BLOB vào bài thuyết trình**

Với các phương pháp từ lớp [ImageCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/) , bạn có thể thêm một hình ảnh lớn dưới dạng luồng để nó được xử lý như một BLOB.

Đoạn mã Python này cho bạn thấy cách thêm một hình ảnh lớn qua quy trình BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# Tạo một bài thuyết trình mới để thêm hình ảnh vào.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # Giữ luồng ở trạng thái khóa vì chúng tôi không dự định truy cập tệp hình ảnh.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # Lưu bài thuyết trình trong khi giữ mức tiêu thụ bộ nhớ thấp.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **Bộ nhớ và các bài thuyết trình lớn**

Thông thường, để tải một bài thuyết trình lớn, máy tính cần rất nhiều bộ nhớ tạm thời. Toàn bộ nội dung của bài thuyết trình được tải vào bộ nhớ và tệp (từ đó bài thuyết trình được tải) ngừng được sử dụng.

Xem xét một bài thuyết trình PowerPoint lớn (large.pptx) chứa một tệp video 1,5 GB. Phương pháp chuẩn để tải bài thuyết trình được mô tả trong đoạn mã Python này:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Nhưng phương pháp này tiêu thụ khoảng 1,6 GB bộ nhớ tạm thời.

### **Tải một bài thuyết trình lớn dưới dạng BLOB**

Thông qua quy trình sử dụng BLOB, bạn có thể tải một bài thuyết trình lớn trong khi sử dụng ít bộ nhớ. Đoạn mã Python này mô tả cách thực hiện nơi quy trình BLOB được dùng để tải lên tệp bài thuyết trình lớn (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **Thay đổi thư mục cho các tệp tạm thời**

Khi quy trình BLOB được sử dụng, máy tính của bạn sẽ tạo các tệp tạm thời trong thư mục mặc định cho tệp tạm. Nếu bạn muốn các tệp tạm được lưu ở thư mục khác, có thể thay đổi cài đặt lưu trữ bằng [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
Khi bạn sử dụng [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath), Aspose.Slides sẽ không tự động tạo thư mục để lưu các tệp tạm. Bạn phải tự tạo thư mục này.
{{% /alert %}}

### **Giải phóng đối tượng Presentation để giải phóng bộ nhớ**

Khi xử lý các bài thuyết trình lớn, đảm bảo rằng thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ nó chiếm dụng được giải phóng. Gọi [Presentation.dispose](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#dispose) sau khi bạn hoàn thành việc sử dụng bài thuyết trình để giải phóng tài nguyên không quản lý.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...xử lý bài thuyết trình...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # Giải phóng tài nguyên một cách rõ ràng.
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Dữ liệu nào trong một bài thuyết trình Aspose.Slides được xem là BLOB và được kiểm soát bởi các tùy chọn BLOB?**

Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được xem là BLOB. Toàn bộ tệp bài thuyết trình cũng liên quan đến xử lý BLOB khi nó được tải hoặc lưu. Những đối tượng này được quản lý bởi các chính sách BLOB cho phép bạn kiểm soát việc sử dụng bộ nhớ và việc ghi ra tệp tạm khi cần.

**Tôi cấu hình các quy tắc xử lý BLOB ở đâu khi tải bài thuyết trình?**

Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/) cùng với [BlobManagementOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/blobmanagementoptions/). Ở đó bạn đặt giới hạn bộ nhớ trong cho BLOB, cho phép hoặc không cho phép tệp tạm, chọn đường dẫn gốc cho tệp tạm và chọn hành vi khóa nguồn.

**Cài đặt BLOB có ảnh hưởng đến hiệu năng không, và làm sao cân bằng tốc độ vs bộ nhớ?**

Có. Giữ BLOB trong bộ nhớ tối đa tốc độ nhưng tăng tiêu thụ RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm, giảm RAM nhưng tăng I/O. Sử dụng phương thức [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/vi/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) để đạt được cân bằng phù hợp cho khối lượng công việc và môi trường của bạn.

**Các tùy chọn BLOB có giúp khi mở các bài thuyết trình cực lớn (ví dụ, hàng gigabyte) không?**

Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/blobmanagementoptions/) được thiết kế cho các kịch bản như vậy: bật tệp tạm và sử dụng khóa nguồn có thể giảm đáng kể mức RAM cao nhất và ổn định quá trình xử lý cho các bộ sưu tập rất lớn.

**Tôi có thể sử dụng các chính sách BLOB khi tải từ luồng thay vì tệp trên đĩa không?**

Có. Các quy tắc giống nhau áp dụng cho luồng: thể hiện bài thuyết trình có thể sở hữu và khóa luồng đầu vào (tùy vào chế độ khóa được chọn), và các tệp tạm sẽ được sử dụng khi được cho phép, giữ cho mức tiêu thụ bộ nhớ dự đoán được trong quá trình xử lý.