---
title: "Câu hỏi thường gặp"
type: docs
weight: 340
url: /vi/python-net/faq/
keywords:
- "Câu hỏi thường gặp"
- "định dạng bài thuyết trình"
- "lỗi không đủ bộ nhớ"
- "kích thước slide"
- "trích xuất văn bản"
- "lấy văn bản"
- "kích thước đoạn văn"
- "định dạng bảng"
- "phông chữ"
- PowerPoint
- OpenDocument
- "bài thuyết trình"
- Python
- Aspose.Slides
description: "Nhận câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho Python qua .NET, bao gồm hỗ trợ PowerPoint và OpenDocument, hướng dẫn cài đặt, giấy phép, và khắc phục sự cố."
---
## **Tổng quan**

Câu hỏi thường gặp này cung cấp câu trả lời cho các câu hỏi phổ biến về Aspose.Slides. Nó bao gồm các định dạng tệp được hỗ trợ, cách xử lý ngoại lệ khi làm việc với các bài thuyết trình lớn, thay đổi kích thước slide, xem trước slide, trích xuất văn bản từ bài thuyết trình, định dạng viền bảng, đặt hình ảnh và giải quyết các vấn đề liên quan tới phông chữ khi chuyển đổi bài thuyết trình sang PDF hoặc hình ảnh.

## **Định dạng tệp được hỗ trợ**

**H: Aspose.Slides for Python via .NET hỗ trợ những định dạng tệp nào?**

**Đ**: Aspose.Slides for Python via .NET hỗ trợ các định dạng tệp được mô tả trong [Supported File Formats](/slides/vi/python-net/supported-file-formats/).

## **Ngoại lệ**

**H: Tôi gặp ngoại lệ out of memory khi tải một tệp PPT lớn có hình ảnh. Aspose.Slides có giới hạn kích thước tệp không?**

**Đ**: Không có công thức cụ thể nào để tính kích thước bài thuyết trình mà Aspose.Slides hỗ trợ. Cần có đủ không gian để chứa toàn bộ cấu trúc bài thuyết trình và hình ảnh trong bộ nhớ. Thông thường, hình ảnh trong bộ nhớ chiếm nhiều không gian hơn so với trên ổ cứng, đặc biệt khi hình ảnh có các hiệu ứng bổ sung.

Nói chung, Aspose.Slides for Python via .NET có thể xử lý dễ dàng các tệp bài thuyết trình khoảng 300 MB trên máy chủ có 4 GB RAM.

## **Làm việc với Slide**

**H: Tôi có thể thay đổi kích thước slide trong một bài thuyết trình không?**

**Đ**: Bạn có thể sử dụng thuộc tính `slide_size` được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để định nghĩa kích thước slide trong một bài thuyết trình.

**H: Có cách nào để định nghĩa các slide có kích thước khác nhau trong cùng một bài thuyết trình không?**

**Đ**: Vì kích thước slide được định nghĩa ở mức bài thuyết trình trong tài liệu Microsoft PowerPoint, nên không có cách nào thực hiện việc này.

**H: Aspose.Slides for Python via .NET có hỗ trợ xem trước một slide trước khi lưu không?**

**Đ**: Bạn có thể render các slide của bài thuyết trình ra hình ảnh và sử dụng các hình ảnh này để xem trước slide.

## **Làm việc với Văn bản**

**H: Có thể lấy toàn bộ văn bản từ một bài thuyết trình không?**

**Đ**: Aspose.Slides for Python via .NET cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/) trong không gian tên `aspose.slides.util` với nhiều phương thức để truy xuất toàn bộ văn bản từ các bài thuyết trình.

**H: Tại sao kích thước đoạn văn khác nhau trên hệ điều hành Windows và Linux?**

**Đ**: Việc tính toán kích thước đoạn văn dựa trên kích thước văn bản đại diện cho đoạn đó. Kích thước văn bản được tính dựa trên các chỉ số của phông chữ được chỉ định trong bài thuyết trình PowerPoint. Nếu phông chữ được chỉ định không có, nó sẽ được thay thế bằng phông chữ tương tự nhất, nhưng phông chữ này có các chỉ số khác với phông chữ gốc. Do đó, việc tính toán kích thước đoạn trên các hệ thống khác nhau sẽ cho ra kết quả khác nhau tùy thuộc vào bộ phông chữ đã cài đặt. Để đạt được kết quả giống nhau trên các hệ điều hành khác nhau, bạn cần cài đặt các phông chữ giống nhau trên các hệ thống hoặc tải chúng tại thời gian chạy dưới dạng [external fonts](/slides/vi/python-net/custom-font/).

## **Định dạng và Hình ảnh**

**H: Làm sao để đặt màu cho viền bảng?**

**Đ**: Bạn có thể thay đổi màu của tất cả các viền bảng hoặc chỉ viền bao quanh toàn bộ bảng. Để thay đổi tất cả các viền, vui lòng sử dụng thuộc tính `cell_format` từ lớp [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/). Đối với viền của toàn bộ bảng, bạn nên duyệt các ô và thay đổi màu của các viền ngoài.

**H: Aspose.Slides for Python via .NET dùng đơn vị đo nào để đặt hình ảnh?**

**Đ**: tọa độ và kích thước của tất cả các hình trên slide được đo bằng điểm (72 dpi).

## **Làm việc với Phông chữ**

**H: Khi chuyển đổi PPT sang PDF hoặc hình ảnh, tại sao phông chữ trong tài liệu đầu ra lại khác?**

**Đ**: Vấn đề này có thể cho thấy các phông chữ dùng trong bài thuyết trình không có trên hệ điều hành mà mã được thực thi. Bạn nên cài đặt các phông chữ trên hệ điều hành hoặc tải chúng như phông chữ bên ngoài bằng cách sử dụng lớp [FontsLoader](https://reference.aspose.com/slides/vi/python-net/aspose.slides/fontsloader/) như dưới đây:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```