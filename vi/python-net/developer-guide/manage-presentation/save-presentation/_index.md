---
title: Lưu Bài Thuyết Trình trong Python
linktitle: Lưu Bài Thuyết Trình
type: docs
weight: 80
url: /vi/python-net/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài thuyết trình tới tệp
- bài thuyết trình tới luồng
- kiểu hiển thị được định nghĩa trước
- định dạng Office Open XML nghiêm ngặt
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- Python
- Aspose.Slides
description: "Lưu các bài thuyết trình PowerPoint và OpenDocument vào tệp hoặc luồng trong Python với Aspose.Slides, và cấu hình các tùy chọn đầu ra PPTX."
---
## **Tổng quan**

Sau khi bạn tạo một bài thuyết trình hoặc [mở một bản hiện có](/slides/vi/python-net/open-presentation/), sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipresentation/save/) để ghi kết quả. Aspose.Slides for Python via .NET có thể lưu một bài thuyết trình vào tệp hoặc luồng ở các định dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần tiếp theo bao gồm các thao tác lưu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu Bài Thuyết Trình vào Tệp**

Để lưu một bài thuyết trình vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipresentation/save/). Giá trị định dạng xác định loại tệp mà Aspose.Slides tạo ra.

Ví dụ sau tạo một bài thuyết trình và lưu nó dưới dạng tệp PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Thêm hoặc sửa đổi nội dung bài thuyết trình ở đây.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Lưu Bài Thuyết Trình ở Định Dạng Gốc**

Đối với các ví dụ phát hiện tệp và luồng, hành vi của các bài thuyết trình mới tạo và sự khác biệt giữa định dạng nguồn và định dạng đầu ra, xem [Xác Định Định Dạng Bài Thuyết Trình Gốc](/slides/vi/python-net/detect-presentation-source-format/).

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể chưa được biết trước. Sau khi tải một tệp, đọc định dạng gốc của nó từ thuộc tính [Presentation.source_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/source_format/). Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sourceformat/) nhận được vào [SlideUtil.to_save_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/to_save_format/) để có được giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) tương ứng, sau đó sử dụng [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipresentation/save/) để ghi bài thuyết trình đã sửa đổi.

Ví dụ hoàn chỉnh sau xử lý mọi tệp trong thư mục đầu vào, cập nhật tiêu đề và lưu nó vào thư mục đầu ra ở định dạng mà nó đã được tải:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/to_save_format/) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bài thuyết trình tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bài thuyết trình; không dùng để chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sourceformat/) không hỗ trợ hoặc không hợp lệ sẽ gây ra ngoại lệ.

Các tệp PPT, PPS và POT legacy sử dụng cùng một container nhị phân. Khi một bài thuyết trình như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể bị xác định là PPT. Nếu cần bảo toàn các kiểu phụ legacy này, hãy giữ lại tên tệp hoặc siêu dữ liệu định dạng gốc riêng và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu Bài Thuyết Trình vào Luồng**

Để ghi một bài thuyết trình mà không dựa vào đường dẫn tệp cuối cùng, truyền một luồng [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) có thể ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipresentation/save/). Cách tiếp cận này hữu ích khi đầu ra phải được trả về từ một dịch vụ web, lưu trữ trong cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bài thuyết trình mới vào luồng tệp:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Lưu Bài Thuyết Trình với Kiểu Hiển Thị Được Định Nghĩa Trước**

Bạn có thể chỉ định chế độ hiển thị mà PowerPoint mở bài thuyết trình đã lưu ban đầu. Đặt thuộc tính [ViewProperties.last_view](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/last_view/) thành một giá trị [ViewType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình chế độ Slide Master làm chế độ hiển thị ban đầu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML Nghiêm Ngặt**

Để tạo một tệp PPTX tuân thủ hồ sơ Strict của Office Open XML, tạo một thể hiện [PptxOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/) và đặt thuộc tính [conformance](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/conformance/) thành `Conformance.ISO_29500_2008_STRICT`. Sau đó truyền các tùy chọn này vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML ở Chế Độ Zip64**

Một kho lưu ZIP tiêu chuẩn giới hạn kích thước đã nén và chưa nén của mỗi mục, tổng kích thước kho và số mục. Vì một tệp PPTX là một kho ZIP, một bài thuyết trình rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số mục áp dụng.

Sử dụng thuộc tính [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) để kiểm soát việc Aspose.Slides ghi phần mở rộng ZIP64:

- `IF_NECESSARY` chỉ sử dụng ZIP64 khi bài thuyết trình vượt quá giới hạn ZIP tiêu chuẩn. Đây là chế độ mặc định.
- `NEVER` tắt phần mở rộng ZIP64.
- `ALWAYS` luôn luôn ghi phần mở rộng ZIP64.

Ví dụ sau luôn bật phần mở rộng ZIP64 cho bài thuyết trình đầu ra:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Nếu sử dụng `Zip64Mode.NEVER` và bài thuyết trình không thể vừa trong giới hạn ZIP tiêu chuẩn, thao tác lưu sẽ ném ngoại lệ [PptxException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML với Mức Nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách đặt thuộc tính [PptxOptions.compression_level](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/compression_level/). Các giá trị trong enum [CompressionLevel](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/) như sau:

- `NONE` lưu dữ liệu mà không nén.
- `LEVEL1` cung cấp mức nén nhanh nhất và kết quả nén lớn nhất.
- `LEVEL2` đến `LEVEL5` dần dần ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- `LEVEL6` cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- `LEVEL7` và `LEVEL8` tiếp tục ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- `LEVEL9` cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý lâu nhất.

Ví dụ sau lưu một bài thuyết trình mà không nén:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

Ví dụ sau sử dụng mức nén tối đa:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Lưu Bài Thuyết Trình mà Không Làm Mới Hình Thu Nhỏ**

Khi một bài thuyết trình được lưu dưới dạng PPTX, thuộc tính [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) điều khiển hình thu nhỏ tài liệu:

- `True` tạo lại hình thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `False` giữ nguyên hình thu nhỏ hiện tại. Nếu bài thuyết trình không có hình thu nhỏ, Aspose.Slides sẽ không tạo mới.

Ví dụ sau lưu một bài thuyết trình mà không làm mới hình thu nhỏ của nó:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Vô hiệu hoá việc làm mới hình thu nhỏ có thể giảm thời gian cần thiết để lưu một tệp PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bài thuyết trình thành các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Aspose.Slides có hỗ trợ lưu tăng dần hoặc “lưu nhanh” không?**

Không. Mỗi thao tác lưu sẽ ghi một tệp đầu ra hoàn chỉnh thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một thể hiện Presentation không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) [không an toàn với đa luồng](/slides/vi/python-net/multithreading/). Truy cập và lưu mỗi thể hiện chỉ từ một luồng tại một thời điểm.

**Điều gì xảy ra với các siêu liên kết và tệp liên kết bên ngoài khi tôi lưu một bài thuyết trình?**

[Hyperlinks](/slides/vi/python-net/manage-hyperlinks/) vẫn còn trong bài thuyết trình. Aspose.Slides không sao chép các tệp liên kết bên ngoài, vì vậy bài thuyết trình đã lưu vẫn phải có khả năng truy cập tới vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [document properties](/slides/vi/python-net/presentation-properties/) phù hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.