---
title: Xuất bản trình chiếu sang HTML với hình ảnh được liên kết bên ngoài trong Python
linktitle: Xuất bản trình chiếu sang HTML với hình ảnh được liên kết bên ngoài
type: docs
weight: 100
url: /vi/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bài thuyết trình
- xuất slide
- xuất PPT
- xuất PPTX
- xuất ODP
- PowerPoint sang HTML
- OpenDocument sang HTML
- bài thuyết trình sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- ODP sang HTML
- hình ảnh liên kết
- hình ảnh liên kết bên ngoài
- tài nguyên liên kết
- tài nguyên bên ngoài
- Python
- Aspose.Slides
description: "Xuất các bản trình chiếu PowerPoint và OpenDocument sang HTML trong Python bằng Aspose.Slides với các hình ảnh được lưu dưới dạng tệp liên kết bên ngoài."
---
## **Tổng quan**

Mặc định, Aspose.Slides xuất một bài thuyết trình thành một tệp HTML tự chứa. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này thuận tiện khi bạn cần một tệp di động duy nhất, nhưng không phải lúc nào cũng là định dạng tốt nhất cho một trang web, một CMS, hoặc một quy trình chuyển đổi phía máy chủ.

Sử dụng hình ảnh liên kết bên ngoài khi bạn muốn:

- giảm kích thước của tài liệu HTML;
- lưu trữ bộ nhớ đệm hình ảnh riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén, hoặc xử lý hậu kỳ các hình ảnh đã tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Chuyển đổi Bài thuyết trình PowerPoint sang HTML](/slides/vi/python-net/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết hình ảnh của quá trình xuất.

## **Cách hoạt động của xuất hình ảnh có liên kết**

Trong .NET và Java, [ILinkEmbedController](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/ilinkembedcontroller/) đại diện cho giao diện callback được trình xuất sử dụng để quyết định liệu một tài nguyên có nên được nhúng hay liên kết. Trong Python qua .NET, các lớp Python hiện không thể triển khai giao diện callback .NET này trực tiếp, vì vậy quy trình thực tế là:

1. Xuất bài thuyết trình sang HTML bằng [HtmlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/htmloptions/).
2. Sử dụng [SlideImageFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/slideimageformat/) cùng với [SVGOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/svgoptions/) để các slide được biểu diễn dưới dạng SVG trong HTML.
3. Di chuyển dữ liệu hình ảnh Base64 từ các URL `data:` trong HTML vào các tệp riêng.
4. Thay thế các URL `data:` gốc bằng các liên kết tương đối như `assets/resource-1.jpg`.

Đường dẫn hệ thống tệp và URL trình duyệt là hai mối quan tâm riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp hình ảnh vào `html-output/assets` trên đĩa, trong khi HTML chứa các URL tương đối như `assets/resource-1.jpg`. Trình duyệt sẽ giải quyết các URL này dựa trên tệp HTML chứa liên kết.

## **Xuất HTML với hình ảnh liên kết**

Ví dụ Python phía dưới tạo một thư mục đầu ra, lưu tệp HTML ở đó, lưu các hình ảnh đã trích xuất vào thư mục con `assets`, và ghi lại các URL hình ảnh Base64 thành các liên kết tương đối. Ví dụ này trích xuất các định dạng hình ảnh Base64 phổ biến khi Aspose.Slides cung cấp phần mở rộng tệp an toàn. Các URL dữ liệu không được nhận dạng sẽ vẫn được nhúng.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Sau khi xuất, thư mục đầu ra có thể có cấu trúc như sau:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Các tệp cụ thể phụ thuộc vào nội dung bài thuyết trình và các tùy chọn xuất. Ví dụ, hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn một codec hình ảnh khác với codec được sử dụng trong bài thuyết trình nguồn khi điều đó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Hình ảnh có độ trong suốt được xuất dưới dạng PNG.

## **Chọn URL cho triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.jpg`.

Sử dụng một tên thư mục tài sản khác hoặc ghi lại các liên kết đã tạo khi các tệp được triển khai ở nơi khác:

- Sử dụng `assets/` khi thư mục tài sản nằm cạnh tệp HTML.
- Sử dụng `../assets/` khi thư mục tài sản nằm một cấp trên tệp HTML.
- Sử dụng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tệp tĩnh.

Trong các ứng dụng máy chủ, sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ đối tượng cho mỗi công việc chuyển đổi để tránh ghi đè các tệp từ một lần xuất khác.

## **Khi nào nên nhúng thay vì liên kết**

HTML Base64 được nhúng vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như tệp đính kèm email, bản xem trước ngoại tuyến, hoặc tài liệu sẽ được di chuyển mà không có thư mục tài sản hỗ trợ. Hình ảnh liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trữ trong CMS, tối ưu hóa bằng một quy trình xây dựng, hoặc được trình duyệt lưu bộ nhớ đệm độc lập so với HTML.

## **FAQ**

**Tôi có thể chỉ tách hình ảnh ra ngoài và giữ các tài nguyên khác được nhúng không?**

Có. Mẫu chỉ trích xuất các URL dữ liệu Base64 `image/*` có kiểu nội dung được liệt kê trong `EXTENSIONS_BY_CONTENT_TYPE`. Các URL dữ liệu khác vẫn được nhúng.

**Tại sao phần mở rộng hình ảnh đã xuất lại khác với bài thuyết trình nguồn?**

Aspose.Slides có thể mã hóa lại các hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc khả năng tương thích với trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy thuộc vào kết quả hiển thị.

**Các URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối được giữ nguyên. Nếu HTML tham chiếu đến `assets/resource-1.png`, thư mục `assets` phải ở cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Các ứng dụng máy chủ có nên tái sử dụng cùng một thư mục đầu ra không?**

Không. Sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ cho mỗi công việc chuyển đổi. Điều này tránh va chạm tên tệp và ngăn một lần xuất ghi đè tài nguyên được tạo bởi một lần xuất khác.