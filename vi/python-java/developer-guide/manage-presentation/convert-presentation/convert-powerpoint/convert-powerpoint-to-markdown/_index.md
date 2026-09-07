---
title: Chuyển đổi Bản trình chiếu PowerPoint sang Markdown trong Python qua Java
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/python-java/convert-powerpoint-to-markdown/
keywords:
  - chuyển đổi PowerPoint
  - chuyển đổi bản trình chiếu
  - chuyển đổi slide
  - chuyển đổi PPT
  - chuyển đổi PPTX
  - PowerPoint sang MD
  - bản trình chiếu sang MD
  - slide sang MD
  - PPT sang MD
  - PPTX sang MD
  - lưu PowerPoint dưới dạng Markdown
  - lưu bản trình chiếu dưới dạng Markdown
  - lưu slide dưới dạng Markdown
  - lưu PPT dưới dạng MD
  - lưu PPTX dưới dạng MD
  - xuất PPT sang MD
  - xuất PPTX sang MD
  - xuất ảnh Markdown
  - liên kết ảnh CDN
  - PowerPoint
  - bản trình chiếu
  - Markdown
  - Python
  - Java
  - Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PPT và PPTX sang Markdown trong Python qua Java và kiểm soát nơi lưu và tham chiếu các ảnh bitmap, metafile và SVG được xuất."
---
## **Tổng quan**

Aspose.Slides for Python via Java có thể chuyển đổi các bản thuyết trình PPT và PPTX sang Markdown cho tài liệu, trang tĩnh, di chuyển nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn kiểu Markdown, kiểm soát cách nội dung slide được hiển thị và quyết định nơi lưu ảnh xuất khẩu cũng như cách Markdown sinh ra tham chiếu chúng.

Mặc định, xuất khẩu Markdown chỉ tạo ra đầu ra dạng văn bản. Để xuất nội dung hình ảnh, hãy đặt kiểu xuất bằng phương thức [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setExportType) thành giá trị `Sequential` hoặc `Visual` từ liệt kê [MarkdownExportType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownexporttype/). `Sequential` sẽ render các mục slide riêng biệt và theo thứ tự, trong khi `Visual` giữ các mục được nhóm lại với nhau để bảo tồn mối quan hệ trực quan. Giá trị `TextOnly` không tạo ra tài nguyên ảnh, vì vậy các callback lưu ảnh sẽ không được gọi trong chế độ này.

## **Chuyển đổi bản thuyết trình sang Markdown**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và sau đó gọi phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) với giá trị `Md` từ liệt kê [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Mỗi ví dụ đọc tệp `presentation.pptx` từ thư mục làm việc hiện tại. Cài đặt Aspose.Slides for Python via Java và một môi trường Java tương thích trước khi chạy các ví dụ. Khởi động JVM một lần cho mỗi tiến trình Python.

## **Chọn kiểu Markdown**

Phương thức [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setFlavor) kiểm soát đặc tả Markdown được dùng cho đầu ra. Liệt kê [Flavor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể hỗ trợ khác.

Ví dụ sau xuất bản trình chiếu dưới dạng CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Xuất ảnh bằng hành vi lưu cục bộ mặc định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/) cung cấp hai phương thức để cấu hình việc lưu ảnh cục bộ:

- [setBasePath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setBasePath) chỉ định thư mục cơ sở cho tài liệu Markdown và các tài nguyên của nó.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) chỉ định thư mục con cho ảnh. Giá trị mặc định là `Images`.

Ví dụ sau render nội dung hình ảnh, ghi ảnh vào `output/assets`, và tạo các tham chiếu ảnh tương đối trong tài liệu Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Hành vi này cũng đóng vai trò dự phòng khi một handler lưu ảnh tùy chỉnh trả về `False`.

## **Tùy chỉnh việc lưu ảnh và liên kết Markdown**

Sử dụng phương thức [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/) để đăng ký callback cho các tài nguyên bitmap và metafile không phải SVG được tạo ra trong quá trình xuất Markdown. Callback `MarkdownImageSavingHandler` nhận đối tượng ảnh, giá trị [ImageFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/) của nó và liên kết Markdown đã sinh ra dưới dạng một mảng `String[]` có một phần tử. Lưu hoặc tải lên ảnh với định dạng được cung cấp, và thay thế `link[0]` bằng tham chiếu cần xuất hiện trong đầu ra Markdown.

Các tài nguyên được xuất dưới dạng SVG được xử lý riêng. Đăng ký callback bằng phương thức [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler` nhận một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) và tham số mảng `String[] link` có một phần tử. SVG không có đối số `ImageFormat`; ghi hoặc tải lên dữ liệu XML của nó bằng phương thức [SvgImage.getSvgData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/#getSvgData). Tùy theo chế độ xuất và việc nhóm trực quan, một SVG trong bản thuyết trình nguồn có thể được raster hoá hoặc kết hợp với nội dung khác; tài nguyên không phải SVG kết quả sẽ được truyền cho callback lưu ảnh. Hãy đăng ký cả hai callback khi mọi tài nguyên hình ảnh xuất khẩu cần xử lý tùy chỉnh.

Giá trị trả về của handler quyết định ai sẽ xử lý ảnh:

- Trả về `True` sau khi handler đã lưu, tải lên, chuyển đổi, hoặc xử lý ảnh theo cách nào đó và đã gán một giá trị hợp lệ cho `link[0]`. Aspose.Slides sẽ ghi giá trị đó vào tài liệu Markdown và không thực hiện việc lưu cục bộ mặc định.
- Trả về `False` để cho Aspose.Slides lưu ảnh cục bộ và tạo liên kết theo các giá trị được thiết lập bởi [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setBasePath) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}

Một handler trả về `True` chịu trách nhiệm toàn bộ đối với ảnh. Nếu nó trả về `True` mà không gán một liên kết hợp lệ, không rỗng, việc xuất sẽ thất bại với `InvalidOperationException`.

{{% /alert %}}

Trong Python, đăng ký các callback này bằng `jpype.JProxy`, triển khai giao diện callback Java qua phương thức `invoke` của nó. Đối số `link` là một mảng chuỗi Java có thể thay đổi: chuyển `link[0]` sang chuỗi Python trước khi xử lý, sau đó gán URL thay thế trở lại `link[0]`.

### **Lưu ảnh vào thư mục gốc CDN và sử dụng URL bên ngoài**

Ví dụ sau coi `cdn-origin/presentations/quarterly-report` như một thư mục gốc CDN đã được gắn hoặc đồng bộ. Mỗi handler trích xuất tên tệp được tạo, lưu ảnh vào thư mục tùy chỉnh đó, và thay thế tham chiếu cục bộ đã tạo bằng URL công cộng của CDN. Mẫu này không thực hiện tải lên qua mạng: URL chỉ hợp lệ sau khi thư mục được gắn làm gốc CDN hoặc các tệp được xuất bản lên CDN. Đối với lưu trữ đối tượng, hãy thay thế việc ghi vào hệ thống tệp bằng thao tác tải lên của SDK lưu trữ và gán `link[0]` chỉ sau khi tải lên thành công.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Handler bitmap cố tình trả về `False` cho các ảnh nhỏ hơn 128 × 128 pixel, vì vậy Aspose.Slides sẽ lưu những ảnh này vào `output/fallback-images` bằng hành vi mặc định. Các tài nguyên bitmap và metafile lớn hơn, cũng như tài nguyên SVG, sẽ được xử lý bởi mã tùy chỉnh. Ví dụ, một tham chiếu cục bộ được tạo như `fallback-images/image1.png` sẽ trở thành `https://cdn.example.com/presentations/quarterly-report/image1.png`. Các handler chỉ sử dụng đường dẫn hệ điều hành khi ghi tệp; các liên kết ghi vào Markdown dùng dấu gạch chéo `/` và tên tệp được mã hoá URL. Áp dụng quy tắc tương tự khi xây dựng liên kết tương đối: dùng `/`, không phải dấu phân tách thư mục đặc thù của nền tảng.

## **Câu hỏi thường gặp**

**Một handler có thể xử lý cả ảnh raster và ảnh SVG không?**

Không. Sử dụng [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/) cho các tài nguyên bitmap và metafile được xuất và [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/) cho các tài nguyên được xuất dưới dạng SVG. Thứ nhất cung cấp một đối tượng ảnh và một giá trị [ImageFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/); thứ hai cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) mà dữ liệu SVG có thể được đọc bằng [SvgImage.getSvgData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/#getSvgData). Một SVG nguồn bị raster hoá trong quá trình xuất sẽ được xử lý bởi callback lưu ảnh thay vì callback SVG.

**Điều gì xảy ra khi một handler lưu ảnh trả về `False`?**

Aspose.Slides sẽ sử dụng hành vi lưu cục bộ mặc định. Vị trí ảnh và tham chiếu được tạo ra được điều khiển bởi các giá trị đặt bằng [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setBasePath) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Một handler có thể cung cấp URL mà không lưu ảnh cục bộ không?**

Có. Handler có thể tải ảnh lên lưu trữ đối tượng hoặc chuyển cho dịch vụ khác, gán URL thu được cho `link[0]`, và trả về `True`. Handler phải tự hoàn thành việc xử lý; việc trả về `True` sẽ ngăn việc lưu cục bộ mặc định.

**Tại sao xuất Markdown phát sinh `InvalidOperationException` từ một handler?**

Ngoại lệ này xảy ra khi handler trả về `True` nhưng không cung cấp một liên kết hợp lệ. Gán đường dẫn tương đối hoặc URL bên ngoài mà cần ghi vào Markdown trước khi trả về `True`.

**Bộ phân tách đường dẫn nào nên được dùng cho liên kết ảnh?**

Sử dụng dấu gạch chéo `/` trong các liên kết và URL Markdown. Dùng `pathlib.Path` chỉ cho các đường dẫn hệ thống tệp, sau đó xây dựng hoặc chuẩn hoá tham chiếu Markdown riêng.

**Các siêu liên kết có được giữ lại khi xuất Markdown không?**

Có. Các [siêu liên kết](/slides/vi/python-java/manage-hyperlinks/) trong văn bản được giữ lại dưới dạng liên kết Markdown tiêu chuẩn. Các [chuyển đổi slide](/slides/vi/python-java/slide-transition/) và [hoạt ảnh](/slides/vi/python-java/powerpoint-animation/) không được chuyển đổi.

**Có thể chuyển đổi nhiều bản thuyết trình sang Markdown song song không?**

Bạn có thể xử lý các tệp bản thuyết trình khác nhau đồng thời, nhưng không chia sẻ cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) giữa các luồng. Tuân thủ [hướng dẫn đa luồng](/slides/vi/python-java/multithreading/) và sử dụng một thể hiện riêng cho mỗi tệp.