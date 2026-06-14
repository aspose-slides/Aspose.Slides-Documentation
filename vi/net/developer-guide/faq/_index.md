---
title: Câu hỏi thường gặp
type: docs
weight: 340
url: /vi/net/faqs/
keywords:
- Câu hỏi thường gặp
- PowerPoint
- định dạng bản trình chiếu
- lỗi thiếu bộ nhớ
- kích thước slide
- trích xuất văn bản
- lấy văn bản
- kích thước đoạn văn
- định dạng bảng
- phông chữ
- .NET
- C#
- Aspose.Slides
description: "Nhận câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho .NET, bao gồm hỗ trợ PowerPoint và OpenDocument, hướng dẫn cài đặt, giấy phép, và khắc phục sự cố."
---
## **Tổng quan**

FAQ này cung cấp câu trả lời cho các câu hỏi thường gặp về Aspose.Slides. Nó bao gồm các định dạng tệp được hỗ trợ, việc xử lý ngoại lệ khi làm việc với các bản trình chiếu lớn, thay đổi kích thước slide, xem trước slide, truy xuất văn bản từ bản trình chiếu, định dạng viền bảng, đặt hình ảnh, và giải quyết các vấn đề liên quan tới phông chữ khi chuyển đổi bản trình chiếu sang PDF hoặc hình ảnh.

## **Định dạng tệp được hỗ trợ**

**Q: Định dạng tệp nào Aspose.Slides cho .NET hỗ trợ?**

**A**: Aspose.Slides cho .NET hỗ trợ các định dạng tệp được mô tả trong [Supported File Formats](/slides/vi/net/supported-file-formats/).

## **Ngoại lệ**

**Q: Tôi đang nhận được OutOfMemoryException khi tải tệp PPT lớn có hình ảnh. Có giới hạn nào trong Aspose.Slides về kích thước tệp không?**

**A**: Không có công thức cụ thể nào để tính kích thước bản trình chiếu mà Aspose.Slides hỗ trợ. Cần có đủ bộ nhớ để chứa toàn bộ cấu trúc bản trình chiếu và các hình ảnh trong bộ nhớ. Thông thường, các hình ảnh trong bộ nhớ chiếm nhiều không gian hơn so với trên đĩa cứng, đặc biệt khi hình ảnh có các hiệu ứng bổ sung.

Nhìn chung, Aspose.Slides cho .NET có thể xử lý dễ dàng các tệp bản trình chiếu khoảng 300 MB trên máy chủ có 4 GB RAM.

## **Làm việc với Slide**

**Q: Tôi có thể thay đổi kích thước của các slide trong một bản trình chiếu không?**

**A**: Bạn có thể sử dụng thuộc tính `SlideSize` được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để xác định kích thước của các slide trong một bản trình chiếu.

**Q: Có cách nào để định nghĩa các slide có kích thước khác nhau trong một bản trình chiếu không?**

**A**: Vì kích thước của các slide được định nghĩa ở cấp độ bản trình chiếu trong tài liệu Microsoft PowerPoint, nên không có cách nào để thực hiện điều này.

**Q: Aspose.Slides cho .NET có hỗ trợ xem trước một slide trước khi lưu không?**

**A**: Bạn có thể render các slide của bản trình chiếu thành hình ảnh và sử dụng các hình ảnh này để xem trước các slide.

## **Làm việc với Văn bản**

**Q: Có thể truy xuất toàn bộ văn bản từ một bản trình chiếu không?**

**A**: Aspose.Slides cho .NET cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil/) trong không gian tên `Aspose.Slides.Util` cho phép truy xuất toàn bộ văn bản từ các bản trình chiếu.

**Q: Tại sao kích thước đoạn văn khác nhau trên hệ điều hành Windows và Linux?**

**A**: Việc tính toán kích thước đoạn văn dựa trên kích thước văn bản đại diện cho đoạn văn đó. Kích thước văn bản được tính dựa trên các metrix của phông chữ được chỉ định trong bản trình chiếu PowerPoint. Nếu phông chữ được chỉ định không có, nó sẽ được thay thế bằng phông chữ tương tự nhất, nhưng phông chữ này có các metrix khác với phông chữ gốc. Do đó, việc tính toán kích thước đoạn văn trên các hệ thống khác nhau sẽ cho ra kết quả khác nhau tùy thuộc vào bộ phông chữ đã cài đặt. Để đạt được kết quả giống nhau trên các hệ điều hành khác nhau, bạn cần cài đặt cùng một bộ phông chữ trên các hệ thống hoặc tải chúng về thời gian chạy như [external fonts](/slides/vi/net/custom-font/).

## **Định dạng và Hình ảnh**

**Q: Làm thế nào để đặt màu cho viền của bảng?**

**A**: Bạn có thể thay đổi màu của tất cả các viền bảng hoặc chỉ viền quanh toàn bộ bảng. Để thay đổi tất cả các viền, vui lòng sử dụng thuộc tính `CellFormat` từ giao diện [ICell](https://reference.aspose.com/slides/vi/net/aspose.slides/icell/) . Đối với viền của toàn bộ bảng, bạn nên duyệt các ô và thay đổi màu của các viền ngoài.

**Q: Aspose.Slides cho .NET sử dụng đơn vị đo nào để đặt hình ảnh?**

**A**: Các tọa độ và kích thước của tất cả các hình dạng trên slide được đo bằng điểm (72 dpi).

## **Làm việc với Phông chữ**

**Q: Khi chuyển đổi PPT sang PDF hoặc hình ảnh, tại sao phông chữ trong tài liệu đầu ra lại khác nhau?**

**A**: Vấn đề này có thể cho thấy các phông chữ được sử dụng trong bản trình chiếu không có trên hệ điều hành nơi mã được thực thi. Bạn nên cài đặt các phông chữ trên hệ điều hành hoặc tải chúng như các phông chữ bên ngoài bằng cách sử dụng lớp [FontsLoader](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsloader/) như dưới đây:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```