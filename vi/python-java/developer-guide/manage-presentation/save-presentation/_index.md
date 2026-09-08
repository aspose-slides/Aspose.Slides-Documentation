---
title: Lưu bản trình chiếu trong Python qua Java
linktitle: Lưu bản trình chiếu
type: docs
weight: 80
url: /vi/python-java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình chiếu tới tệp
- bản trình chiếu tới luồng
- kiểu xem đã định nghĩa trước
- Định dạng Office Open XML Strict
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- Python
- Java
- Aspose.Slides
description: "Lưu các bản trình chiếu PowerPoint và OpenDocument vào tệp hoặc luồng trong Python qua Java với Aspose.Slides, và cấu hình đầu ra PPTX cũng như báo cáo tiến độ."
---
## **Tổng quan**

Sau khi bạn tạo một bản trình chiếu hoặc [mở một bản trình chiếu hiện có](/slides/vi/python-java/open-presentation/), sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để ghi kết quả. Aspose.Slides cho Python qua Java có thể lưu bản trình chiếu vào tệp hoặc luồng ở định dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần sau đây mô tả các thao tác lưu tiêu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu bản trình chiếu vào tệp**

Để lưu một bản trình chiếu vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Giá trị định dạng xác định loại tệp mà Aspose.Slides tạo ra.

Ví dụ sau tạo một bản trình chiếu và lưu nó dưới dạng tệp PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Thêm hoặc chỉnh sửa nội dung bản trình chiếu ở đây.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lưu bản trình chiếu ở định dạng gốc**

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể không được biết trước. Sau khi tải một tệp, đọc định dạng gốc của nó từ phương thức [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSourceFormat). Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sourceformat/) nhận được cho [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#toSaveFormat) để lấy giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) tương ứng, sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để ghi bản trình chiếu đã chỉnh sửa.

Ví dụ hoàn chỉnh sau xử lý mọi tệp trong thư mục đầu vào, cập nhật tiêu đề của chúng và lưu chúng vào thư mục đầu ra ở định dạng mà chúng đã được tải:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#toSaveFormat) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bản trình chiếu tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bản trình chiếu; không nhằm mục đích chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sourceformat/) không hỗ trợ hoặc không hợp lệ sẽ gây ra một [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Các tệp PPT, PPS và POT cũ sử dụng cùng một container nhị phân. Khi một bản trình chiếu như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể được xác định là PPT. Nếu cần bảo tồn các kiểu phụ legacy này, hãy giữ lại tên tệp gốc hoặc siêu dữ liệu định dạng riêng biệt và sử dụng chúng khi chọn tên và định dạng tệp đầu ra.

## **Lưu bản trình chiếu vào luồng**

Để ghi một bản trình chiếu mà không phụ thuộc vào đường dẫn tệp cuối cùng, truyền một luồng có thể ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Cách này hữu ích khi đầu ra cần được trả về từ dịch vụ web, lưu trong cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bản trình chiếu mới vào luồng tệp:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpile.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Lưu bản trình chiếu với Kiểu xem đã định nghĩa trước**

Bạn có thể chỉ định chế độ xem mà PowerPoint sẽ mở bản trình chiếu đã lưu ban đầu. Sử dụng phương thức [ViewProperties.setLastView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#setLastView) với một giá trị [ViewType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình chế độ xem Slide Master làm chế độ xem ban đầu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML Strict**

Để tạo một tệp PPTX tuân thủ hồ sơ Strict của Office Open XML, tạo một thể hiện [PptxOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/) và sử dụng phương thức [setConformance](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/#setConformance) với [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Sau đó truyền các tùy chọn này vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML ở chế độ Zip64**

Một kho lưu ZIP tiêu chuẩn giới hạn kích thước nén và không nén của mỗi mục, tổng kích thước kho lưu và số lượng mục. Vì tệp PPTX là một kho lưu ZIP, một bản trình chiếu rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số mục áp dụng.

Sử dụng phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/#setZip64Mode) để kiểm soát việc Aspose.Slides có ghi phần mở rộng ZIP64 hay không:

- [IfNecessary](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng ZIP64 khi bản trình chiếu vượt quá giới hạn ZIP tiêu chuẩn. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#Never) tắt phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#Always) luôn ghi phần mở rộng ZIP64.

Ví dụ sau luôn bật phần mở rộng ZIP64 cho bản trình chiếu đầu ra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Nếu sử dụng [Zip64Mode.Never](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#Never), và bản trình chiếu không thể vừa trong giới hạn ZIP tiêu chuẩn, thao tác lưu sẽ ném một [PptxException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu bản trình chiếu ở Định dạng Office Open XML với các mức nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách sử dụng phương thức [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Lớp [CompressionLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/) cung cấp các giá trị sau:

- [None](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#None) lưu dữ liệu mà không nén.
- [Level1](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level1) cung cấp mức nén nhanh nhất và đầu ra nén lớn nhất.
- [Level2](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level2) tới [Level5](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level5) dần dần ưu tiên đầu ra nhỏ hơn thay vì tốc độ lưu.
- [Level6](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level6) cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- [Level7](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level7) và [Level8](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level8) tiếp tục ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- [Level9](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level9) cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý nhiều nhất.

Ví dụ sau lưu một bản trình chiếu mà không nén:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Ví dụ sau sử dụng mức nén tối đa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Lưu bản trình chiếu mà không làm mới hình thu nhỏ**

Khi một bản trình chiếu được lưu dưới dạng PPTX, phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kiểm soát hình thu nhỏ tài liệu:

- `True` tạo lại hình thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `False` giữ nguyên hình thu nhỏ hiện có. Nếu bản trình chiếu không có hình thu nhỏ, Aspose.Slides sẽ không tạo ra.

Ví dụ sau lưu một bản trình chiếu mà không làm mới hình thu nhỏ của nó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Vô hiệu hoá việc làm mới hình thu nhỏ có thể giảm thời gian cần thiết để lưu tệp PPTX.
{{% /alert %}}

## **Cập nhật tiến độ lưu dưới dạng phần trăm**

Để giám sát một thao tác lưu, đăng ký một trình xử lý tiến độ Python thông qua `jpype.JProxy` và truyền nó vào phương thức [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides sau đó sẽ gọi phương thức `reporting` của trình xử lý với các giá trị tiến độ trong quá trình xuất.

Ví dụ sau báo cáo tiến độ xuất PDF lên bảng điều khiển:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bản trình chiếu dưới dạng các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ lưu tăng dần hoặc “lưu nhanh” không?**

Không. Mỗi thao tác lưu sẽ ghi toàn bộ tệp đầu ra thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một thể hiện Presentation không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) [không an toàn với đa luồng](/slides/vi/python-java/multithreading/). Chỉ truy cập và lưu mỗi thể hiện từ một luồng tại một thời điểm.

**Điều gì xảy ra với các siêu liên kết và tệp liên kết ngoài khi tôi lưu một bản trình chiếu?**

[Hyperlinks](/slides/vi/python-java/manage-hyperlinks/) vẫn còn trong bản trình chiếu. Aspose.Slides không sao chép các tệp liên kết bên ngoài, vì vậy bản trình chiếu đã lưu vẫn phải có khả năng truy cập đến vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [thuộc tính tài liệu](/slides/vi/python-java/presentation-properties/) thích hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.