---
title: Chuyển đổi bản trình chiếu PowerPoint sang Markdown trong Python
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/python-net/convert-powerpoint-to-markdown/
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
- Python qua .NET
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PPT và PPTX sang Markdown trong Python và kiểm soát vị trí lưu ảnh được xuất cũng như cách Markdown tạo ra tham chiếu tới chúng."
---
## **Tổng quan**

Aspose.Slides for Python via .NET có thể chuyển đổi các bản trình chiếu PPT và PPTX sang Markdown để sử dụng trong tài liệu, trang tĩnh, di chuyển nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn kiểu Markdown, kiểm soát cách nội dung slide được hiển thị và quyết định nơi lưu trữ hình ảnh được xuất cùng cách Markdown tạo liên kết tới chúng.

Mặc định, xuất Markdown chỉ tạo ra đầu ra dạng văn bản. Để xuất nội dung trực quan, hãy đặt thuộc tính [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/export_type/) thành giá trị `SEQUENTIAL` hoặc `VISUAL` từ enumeration [MarkdownExportType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` sẽ render các mục slide riêng lẻ và theo thứ tự, trong khi `VISUAL` giữ các mục được nhóm lại với nhau để bảo toàn mối quan hệ hình ảnh. Giá trị `TEXT_ONLY` sẽ không tạo ra tài nguyên hình ảnh.

## **Chuyển đổi Bản trình chiếu sang Markdown**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), sau đó gọi phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ipresentation/save/) với giá trị `MD` từ enumeration [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Chọn Kiểu Markdown**

Thuộc tính [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/flavor/) kiểm soát đặc tả Markdown được sử dụng cho đầu ra. Enumeration [Flavor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể được hỗ trợ khác.

Ví dụ sau xuất một bản trình chiếu dưới dạng CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Xuất ảnh bằng hành vi lưu cục bộ mặc định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/) cung cấp hai thuộc tính cho ảnh được lưu cục bộ:

- [base_path](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/base_path/) chỉ định thư mục gốc cho tài liệu Markdown và các tài nguyên của nó.
- [images_save_folder_name](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) chỉ định thư mục con chứa ảnh. Giá trị mặc định là `Images`.

Ví dụ sau render nội dung trực quan, ghi ảnh vào `output/assets`, và tạo các tham chiếu ảnh tương đối trong tài liệu Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides tạo thư mục con cho ảnh khi quá trình xuất tạo ra tài nguyên ảnh, nhưng ứng dụng phải tạo `base_path` trước khi lưu tệp Markdown.

## **Chuẩn bị Markdown và Ảnh để Xuất bản**

Aspose.Slides for Python via .NET không cung cấp các callback lưu ảnh của .NET để thay thế từng liên kết ảnh được tạo trong quá trình xuất. Thay vào đó, hãy xuất tài liệu Markdown và thư mục ảnh của nó vào một thư mục xuất bản, rồi xuất bản thư mục đó mà không thay đổi cấu trúc tương đối.

Ví dụ sau chuẩn bị `cdn-origin/presentations/quarterly-report` làm thư mục xuất bản được gắn hoặc đồng bộ. Mẫu này không thực hiện tải lên mạng: các liên kết được tạo sẽ hợp lệ sau khi thư mục được xuất bản tại vị trí trang web hoặc CDN mong muốn.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Xuất bản `presentation.md` cùng với thư mục `assets`. Tài liệu Markdown sử dụng các tham chiếu ảnh tương đối, vì vậy cả hai mục phải giữ cùng một quan hệ tại đích đến. Nếu hệ thống xuất bản yêu cầu URL ngoại vi tuyệt đối, hãy ghi lại các liên kết đã tạo trong một bước xử lý hậu kỳ riêng sau khi tất cả các tệp ảnh đã được xuất bản.

## **Câu hỏi thường gặp**

**Python callbacks có thể tùy chỉnh các tệp ảnh và liên kết riêng lẻ trong quá trình xuất Markdown không?**

Không. Aspose.Slides for Python via .NET không cung cấp các callback .NET `ImageSaving` và `SvgImageSaving`. Hãy cấu hình đầu ra cục bộ bằng [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/base_path/) và [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), sau đó xuất bản hoặc xử lý hậu kỳ các tài nguyên đã tạo.

**Ảnh được xuất lưu ở đâu?**

Vị trí ảnh được kiểm soát bởi [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/base_path/) và [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Tài liệu Markdown tham chiếu các ảnh này bằng các đường dẫn tương đối.

**Ký tự phân tách đường dẫn nào nên được sử dụng cho liên kết ảnh?**

Sử dụng dấu gạch chéo (`/`) trong các liên kết và URL của Markdown. Dùng `os.path.join` chỉ cho các đường dẫn hệ thống tệp, và chuẩn hoá bất kỳ liên kết nào được tạo trong quá trình hậu xử lý riêng biệt.

**Liên kết siêu văn bản có được giữ lại khi xuất Markdown không?**

Có. Các [liên kết siêu văn bản](/slides/vi/python-net/manage-hyperlinks/) trong văn bản được giữ lại dưới dạng liên kết Markdown chuẩn. Các [chuyển tiếp slide](/slides/vi/python-net/slide-transition/) và [hoạt ảnh](/slides/vi/python-net/powerpoint-animation/) không được chuyển đổi.

**Có thể chuyển đổi nhiều bản trình chiếu sang Markdown đồng thời không?**

Bạn có thể xử lý các tệp bản trình chiếu khác nhau song song, nhưng không chia sẻ cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) giữa các luồng. Hãy tuân thủ [hướng dẫn đa luồng](/slides/vi/python-net/multithreading/) và sử dụng một thể hiện riêng cho mỗi tệp.