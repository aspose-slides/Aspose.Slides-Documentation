---
title: Lưu Bài Thuyết Trình bằng Python qua Java
linktitle: Lưu Bài Thuyết Trình
type: docs
weight: 80
url: /vi/python-java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài thuyết trình thành tệp
- bài thuyết trình thành luồng
- kiểu xem được định nghĩa trước
- Định dạng Office Open XML Chặt chẽ
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- Python
- Java
- Aspose.Slides
description: "Lưu các bài thuyết trình PowerPoint và OpenDocument thành tệp hoặc luồng trong Python qua Java bằng Aspose.Slides, và cấu hình đầu ra PPTX cùng việc báo cáo tiến độ."
---
## **Tổng quan**

Sau khi bạn tạo một bài thuyết trình hoặc [open an existing one](/slides/vi/python-java/open-presentation/), hãy sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để ghi kết quả. Aspose.Slides for Python via Java có thể lưu một bài thuyết trình vào tệp hoặc luồng dưới dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần sau đây đề cập đến các thao tác lưu tiêu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu bài thuyết trình vào tệp**

Để lưu bài thuyết trình vào tệp, truyền đường dẫn đầu ra và giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Giá trị định dạng xác định loại tệp mà Aspose.Slides sẽ tạo.

Ví dụ sau tạo một bài thuyết trình và lưu nó dưới dạng tệp PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Thêm hoặc sửa nội dung bài thuyết trình ở đây.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lưu bài thuyết trình ở định dạng gốc**

Đối với các ví dụ phát hiện tệp và luồng, hành vi của các bài thuyết trình mới tạo, và sự phân biệt giữa định dạng nguồn và định dạng đầu ra, xem mục [Determine the Original Presentation Format](/slides/vi/python-java/detect-presentation-source-format/).

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể không được biết trước. Sau khi tải tệp, đọc định dạng gốc của nó bằng phương thức [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSourceFormat). Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sourceformat/) thu được cho [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#toSaveFormat) để lấy giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) tương ứng, sau đó dùng [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để ghi bài thuyết trình đã sửa đổi.

Ví dụ đầy đủ sau xử lý mọi tệp trong thư mục đầu vào, cập nhật tiêu đề và lưu chúng vào thư mục đầu ra ở định dạng mà chúng được tải:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#toSaveFormat) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bài thuyết trình tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bài thuyết trình; không được dùng để chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sourceformat/) không được hỗ trợ hoặc không hợp lệ sẽ gây ra ngoại lệ [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Các tệp PPT, PPS và POT cũ sử dụng cùng một container nhị phân. Khi một bài thuyết trình như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT do đó có thể bị nhận dạng là PPT. Nếu cần giữ lại các tiểu loại legacy này, hãy lưu tên tệp hoặc siêu dữ liệu định dạng gốc riêng và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu bài thuyết trình vào luồng**

Để ghi một bài thuyết trình mà không phụ thuộc vào đường dẫn tệp cuối cùng, truyền một luồng có thể ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Cách này hữu ích khi đầu ra phải được trả về từ một dịch vụ web, lưu trong cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bài thuyết trình mới vào luồng tệp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

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

## **Lưu bài thuyết trình với Kiểu xem đã định nghĩa trước**

Bạn có thể chỉ định chế độ xem mà PowerPoint sẽ mở khi tải một bài thuyết trình đã lưu. Sử dụng phương thức [ViewProperties.setLastView](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewproperties/#setLastView) với một giá trị [ViewType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/viewtype/) trước khi lưu.

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

## **Lưu bài thuyết trình ở Định dạng Office Open XML Chặt chẽ**

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

## **Lưu bài thuyết trình ở Định dạng Office Open XML ở Chế độ Zip64**

Một tệp ZIP chuẩn giới hạn kích thước nén và chưa nén của mỗi mục, tổng kích thước lưu trữ và số lượng mục. Vì tệp PPTX là một tệp ZIP, một bài thuyết trình rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số mục.

Sử dụng phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/#setZip64Mode) để kiểm soát việc Aspose.Slides ghi các phần mở rộng ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng ZIP64 khi bài thuyết trình vượt quá giới hạn ZIP chuẩn. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#Never) tắt phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#Always) luôn ghi phần mở rộng ZIP64.

Ví dụ sau luôn bật phần mở rộng ZIP64 cho bài thuyết trình đầu ra:

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
Nếu sử dụng [Zip64Mode.Never](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zip64mode/#Never) và bài thuyết trình không vừa trong giới hạn ZIP chuẩn, thao tác lưu sẽ ném ra ngoại lệ [PptxException](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu bài thuyết trình ở Định dạng Office Open XML với Mức nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách sử dụng phương thức [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Lớp [CompressionLevel](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/) cung cấp các giá trị sau:

- [None](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#None) lưu dữ liệu mà không nén.
- [Level1](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level1) cung cấp nén nhanh nhất và tập tin nén lớn nhất.
- [Level2](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level2) đến [Level5](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level5) dần ưu tiên tập tin nhỏ hơn hơn tốc độ lưu.
- [Level6](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level6) cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- [Level7](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level7) và [Level8](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level8) tiếp tục ưu tiên tập tin nhỏ hơn hơn tốc độ lưu.
- [Level9](https://reference.aspose.com/slides/vi/python-java/aspose.slides/compressionlevel/#Level9) cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý lâu nhất.

Ví dụ sau lưu một bài thuyết trình mà không nén:

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

## **Lưu bài thuyết trình mà không làm mới hình thu nhỏ**

Khi một bài thuyết trình được lưu dưới dạng PPTX, phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kiểm soát hình thu nhỏ tài liệu:

- `True` tạo lại hình thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `False` giữ nguyên hình thu nhỏ hiện có. Nếu bài thuyết trình không có hình thu nhỏ, Aspose.Slides sẽ không tạo mới.

Ví dụ sau lưu một bài thuyết trình mà không làm mới hình thu nhỏ:

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
Vô hiệu hoá việc làm mới hình thu nhỏ có thể giảm thời gian lưu tệp PPTX.
{{% /alert %}}

## **Báo cáo tiến độ lưu dưới dạng phần trăm**

Để theo dõi quá trình lưu, đăng ký một bộ xử lý tiến độ Python thông qua `jpype.JProxy` và truyền nó cho phương thức [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides sẽ gọi phương thức `reporting` của trình xử lý với các giá trị tiến độ trong quá trình xuất.

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
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bài thuyết trình thành các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ lưu Incremental hoặc “fast save” không?**

Không. Mỗi lần lưu đều ghi một tệp đầu ra hoàn chỉnh thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một instance Presentation không?**

Không. Một instance [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) **không an toàn với đa luồng** (/slides/vi/python-java/multithreading/). Hãy truy cập và lưu mỗi instance chỉ từ một luồng tại một thời điểm.

**Liên kết siêu văn bản và các tệp liên kết bên ngoài sẽ xảy ra gì khi tôi lưu bài thuyết trình?**

[Hyperlinks](/slides/vi/python-java/manage-hyperlinks/) vẫn còn trong bài thuyết trình. Aspose.Slides không sao chép các tệp liên kết bên ngoài, vì vậy bài thuyết trình đã lưu vẫn phải có khả năng truy cập tới vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [document properties](/slides/vi/python-java/presentation-properties/) thích hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.