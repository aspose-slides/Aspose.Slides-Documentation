---
title: Chuyển đổi bài thuyết trình PowerPoint sang Markdown trong Python
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/python-net/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint sang Markdown
- chuyển đổi OpenDocument sang Markdown
- chuyển đổi bài thuyết trình sang Markdown
- chuyển đổi slide sang Markdown
- chuyển đổi PPT sang Markdown
- chuyển đổi PPTX sang Markdown
- chuyển đổi ODP sang Markdown
- chuyển đổi PowerPoint sang MD
- chuyển đổi OpenDocument sang MD
- chuyển đổi bài thuyết trình sang MD
- chuyển đổi slide sang MD
- chuyển đổi PPT sang MD
- chuyển đổi PPTX sang MD
- chuyển đổi ODP sang MD
- PowerPoint
- OpenDocument
- bài thuyết trình
- Markdown
- Python
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument—PPT, PPTX, ODP—sang Markdown sạch bằng Aspose.Slides cho Python qua .NET, tự động hoá tài liệu và giữ định dạng."
---
## **Giới thiệu**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình PowerPoint sang Markdown, hữu ích cho quy trình tài liệu, tạo trang tĩnh, di chuyển nội dung và xuất bản văn bản có kiểm soát phiên bản. API hỗ trợ xuất trực tiếp từ các bài thuyết trình PPT và PPTX sang tệp MD và cung cấp các tùy chọn bổ sung để kiểm soát cách nội dung slide được biểu diễn trong tài liệu Markdown kết quả.

Bạn có thể xuất các bài thuyết trình dưới dạng Markdown thuần, chọn từ nhiều dạng Markdown như CommonMark và GitHub Flavored Markdown, và cấu hình cách ảnh được xử lý trong quá trình xuất. Đối với các bài thuyết trình chứa nội dung hình ảnh, Aspose.Slides cũng cho phép bạn lưu ảnh vào một thư mục riêng và tham chiếu chúng từ tệp Markdown được tạo.

{{% alert color="warning" %}}
Xuất PowerPoint sang Markdown **mặc định không có hình ảnh**. Nếu bạn muốn xuất tài liệu PowerPoint có chứa hình ảnh, cần đặt `export_type = MarkdownExportType.VISUAL` và chỉ định `base_path`, nơi các hình ảnh được tham chiếu trong tài liệu Markdown sẽ được lưu.
{{% /alert %}}

## **Chuyển đổi bài thuyết trình sang Markdown**

Ví dụ dưới đây cho thấy cách đơn giản nhất để chuyển đổi một bài thuyết trình PowerPoint sang Markdown bằng Aspose.Slides cho Python thông qua .NET với các cài đặt mặc định.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để tải bài thuyết trình.
2. Gọi `save` để xuất nó dưới dạng tệp Markdown.

Sử dụng đoạn mã Python dưới đây để thực hiện việc chuyển đổi:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Chuyển đổi bài thuyết trình sang dạng Markdown**

Aspose.Slides cho phép bạn chuyển đổi các bài thuyết trình sang các định dạng Markdown, bao gồm Markdown cơ bản, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab và 17 dạng Markdown khác.

Ví dụ Python sau cho thấy cách chuyển đổi một bài thuyết trình PowerPoint sang CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

23 dạng Markdown được hỗ trợ được liệt kê trong enumeration [Flavor](https://reference.aspose.com/slides/vi/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) của lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Chuyển đổi bài thuyết trình có chứa hình ảnh sang Markdown**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) cung cấp các thuộc tính và enumeration cho phép bạn cấu hình tệp Markdown kết quả. Ví dụ, enum [MarkdownExportType](https://reference.aspose.com/slides/vi/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) điều khiển cách xử lý hình ảnh: `SEQUENTIAL`, `TEXT_ONLY`, hoặc `VISUAL`.

### **Chuyển đổi hình ảnh theo thứ tự**

Nếu bạn muốn các hình ảnh xuất hiện riêng lẻ—một sau một—trong Markdown được tạo, hãy chọn tùy chọn `SEQUENTIAL`. Ví dụ Python dưới đây cho thấy cách chuyển đổi một bài thuyết trình có hình ảnh sang Markdown.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Chuyển đổi hình ảnh theo dạng trực quan**

Nếu bạn muốn các hình ảnh xuất hiện cùng nhau trong Markdown kết quả, hãy chọn tùy chọn `VISUAL`. Trong chế độ này, hình ảnh được lưu vào thư mục hiện tại của ứng dụng (và tài liệu Markdown sử dụng đường dẫn tương đối), hoặc bạn có thể chỉ định đường dẫn xuất tùy chỉnh và tên thư mục.

Ví dụ Python dưới đây minh họa thao tác này:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **Câu hỏi thường gặp**

**Liệu liên kết siêu văn bản có được giữ lại khi xuất sang Markdown?**

Có. Văn bản [siêu liên kết](/slides/vi/python-net/manage-hyperlinks/) được giữ lại dưới dạng liên kết Markdown tiêu chuẩn. [Chuyển đổi](/slides/vi/python-net/slide-transition/) và [hoạt ảnh](/slides/vi/python-net/powerpoint-animation/) của slide không được chuyển đổi.

**Tôi có thể tăng tốc độ chuyển đổi bằng cách chạy trên nhiều luồng không?**

Bạn có thể thực hiện song song trên nhiều tệp, nhưng [không chia sẻ](/slides/vi/python-net/multithreading/) cùng một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) giữa các luồng. Hãy sử dụng các đối tượng/tiến trình riêng biệt cho mỗi tệp để tránh xung đột.

**Điều gì xảy ra với hình ảnh — chúng được lưu ở đâu và các đường dẫn có tương đối không?**

[Hình ảnh](/slides/vi/python-net/image/) được xuất ra một thư mục riêng, và tệp Markdown tham chiếu chúng bằng các đường dẫn tương đối theo mặc định. Bạn có thể cấu hình đường dẫn xuất cơ sở và tên thư mục tài nguyên để duy trì cấu trúc kho lưu trữ dự đoán được.