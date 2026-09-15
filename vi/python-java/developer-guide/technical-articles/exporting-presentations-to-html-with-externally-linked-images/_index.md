---
title: Xuất bản trình chiếu sang HTML với hình ảnh liên kết bên ngoài
type: docs
weight: 100
url: /vi/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình chiếu
- xuất slide
- xuất PPT
- xuất PPTX
- xuất ODP
- PowerPoint sang HTML
- OpenDocument sang HTML
- bản trình chiếu sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- ODP sang HTML
- hình ảnh được liên kết
- hình ảnh được liên kết bên ngoài
- tài nguyên được liên kết
- tài nguyên bên ngoài
- Python
- Java
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint và OpenDocument sang HTML trong Python bằng Aspose.Slides, với các hình ảnh và tài nguyên khác được lưu dưới dạng tệp liên kết bên ngoài."
---
## **Tổng quan**

Mặc định, Aspose.Slides xuất một bản trình chiếu thành tệp HTML tự chứa. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này tiện lợi khi bạn cần một tệp di động duy nhất, nhưng không luôn là định dạng tốt nhất cho một trang web, một CMS, hoặc một quy trình chuyển đổi phía máy chủ.

Sử dụng tài nguyên được liên kết bên ngoài khi bạn muốn:

- giảm kích thước của tài liệu HTML;
- lưu bộ nhớ đệm hình ảnh, phông chữ, âm thanh hoặc video riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén hoặc xử lý hậu kỳ các tài nguyên được tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Convert PowerPoint Presentations to HTML](/slides/vi/python-java/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết tài nguyên của quá trình xuất.

## **Cách hoạt động của Xuất Tài nguyên Liên kết**

`ILinkEmbedController` cho phép ứng dụng của bạn quyết định, từng tài nguyên một, liệu trình xuất có nhúng dữ liệu vào HTML hay lưu bên ngoài và ghi liên kết.

Giao diện có ba phương thức:

- `ILinkEmbedController.getObjectStoringLocation` quyết định liệu một tài nguyên nên được liên kết hay nhúng.
- `ILinkEmbedController.getUrl` trả về URL sẽ được ghi vào HTML đã tạo hoặc vào tài nguyên liên kết khác.
- `ILinkEmbedController.saveExternal` ghi dữ liệu tài nguyên liên kết vào đĩa hoặc vào mục tiêu lưu trữ khác.

Các đường dẫn hệ thống tập tin và URL trình duyệt là hai mối quan tâm riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp tài nguyên vào `html-output/assets` trên đĩa, trong khi HTML chứa các URL tương đối như `assets/resource-1.svg`. Trình duyệt sẽ giải quyết các URL này dựa trên tệp chứa liên kết. Do đó, một liên kết từ `presentation.html` đến tệp SVG sử dụng `assets/resource-1.svg`, trong khi một liên kết từ tệp SVG đó đến hình ảnh được lưu trong cùng thư mục `assets` sử dụng `resource-4.jpg`.

## **Xuất HTML với Tài nguyên Liên kết**

Mẫu Python dưới đây tạo một thư mục đầu ra, lưu tệp HTML vào đó và lưu các tài nguyên liên kết trong thư mục con `assets`. Bộ điều khiển sẽ liên kết các tài nguyên hình ảnh, phông chữ, âm thanh, video và CSS phổ biến khi Aspose.Slides cung cấp hoặc có thể suy ra phần mở rộng tệp an toàn. Các tài nguyên không được nhận dạng sẽ vẫn được nhúng.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Sau khi xuất, thư mục đầu ra có cấu trúc này:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Các tệp cụ thể phụ thuộc vào nội dung bản trình chiếu và các tùy chọn xuất. Ví dụ, các hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn codec ảnh khác với codec được sử dụng trong bản trình chiếu nguồn khi điều đó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Các hình ảnh có độ trong suốt được xuất dưới dạng PNG.

## **Chọn URL cho Việc Triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.svg`.

Khi một tài nguyên liên kết tham chiếu đến một tài nguyên liên kết khác, mẫu sử dụng tham số `referrer` trong `ILinkEmbedController.getUrl` và chỉ trả về tên tệp. Ví dụ, nếu `resource-1.svg` và `resource-4.jpg` đều nằm trong thư mục `assets`, tệp SVG nên tham chiếu đến `resource-4.jpg`, không phải `assets/resource-4.jpg`.

Sử dụng một tiền tố URL khác khi các tệp được triển khai ở nơi khác:

- Sử dụng `assets/` khi thư mục tài sản nằm cạnh tệp HTML.
- Sử dụng `../assets/` khi thư mục tài sản nằm một cấp trên tệp HTML.
- Sử dụng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tệp tĩnh.

URL trả về bởi `ILinkEmbedController.getUrl` phải khớp với vị trí triển khai cuối cùng của tệp được ghi bởi `ILinkEmbedController.saveExternal`. Trong các ứng dụng máy chủ, sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ đối tượng cho mỗi công việc chuyển đổi để tránh việc ghi đè tệp từ một lần xuất khác.

## **Khi nào nên Nhúng Thay vì**

HTML nhúng Base64 vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như tệp đính kèm email, bản xem trước ngoại tuyến, hoặc tài liệu sẽ được di chuyển mà không có thư mục tài sản hỗ trợ. Tài nguyên liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trữ trong CMS, tối ưu hoá bởi một quy trình dựng, hoặc được trình duyệt lưu bộ nhớ đệm độc lập với HTML.

## **Câu hỏi thường gặp**

**Tôi có thể chỉ tách riêng hình ảnh ra ngoài và giữ các tài nguyên khác được nhúng không?**

Yes. In `ILinkEmbedController.getObjectStoringLocation`, return [LinkEmbedDecision.Link](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linkembeddecision/#Link) chỉ cho các loại nội dung bạn muốn lưu dưới dạng tệp riêng biệt, và trả về [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/vi/python-java/aspose.slides/linkembeddecision/#Embed) cho mọi thứ khác.

**Tại sao phần mở rộng của ảnh xuất ra lại khác với bản trình chiếu nguồn?**

Aspose.Slides có thể mã hóa lại các hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc tính tương thích của trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy thuộc vào kết quả hiển thị.

**Các URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối được giữ nguyên. Nếu HTML tham chiếu tới `assets/resource-1.png`, thư mục `assets` phải ở cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Các ứng dụng máy chủ có nên tái sử dụng cùng một thư mục đầu ra không?**

Không. Hãy sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ cho mỗi công việc chuyển đổi. Điều này tránh xung đột tên tệp và ngăn một lần xuất ghi đè lên tài nguyên được tạo bởi một lần xuất khác.