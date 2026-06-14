---
title: Câu hỏi thường gặp
type: docs
weight: 340
url: /vi/java/faqs/
keywords:
- Câu hỏi thường gặp
- định dạng bản trình chiếu
- lỗi hết bộ nhớ
- kích thước slide
- trích xuất văn bản
- lấy văn bản
- kích thước đoạn
- định dạng bảng
- phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Nhận câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho Java, bao gồm hỗ trợ PowerPoint và OpenDocument, hướng dẫn cài đặt, giấy phép và khắc phục sự cố."
---
## **Overview**

FAQ này cung cấp câu trả lời cho các câu hỏi thường gặp về Aspose.Slides. Nó bao gồm các định dạng tệp được hỗ trợ, xử lý ngoại lệ khi làm việc với các bản trình chiếu lớn, thay đổi kích thước slide, xem trước slide, truy xuất văn bản từ bản trình chiếu, định dạng viền bảng, đặt hình ảnh và giải quyết các vấn đề liên quan tới phông chữ khi chuyển đổi bản trình chiếu sang PDF hoặc hình ảnh.

## **Supported File Formats**

**Q: Aspose.Slides cho Java hỗ trợ những định dạng tệp nào?**

**A**: Aspose.Slides cho Java hỗ trợ các định dạng tệp được mô tả trong [Supported File Formats](/slides/vi/java/supported-file-formats/).

## **Exceptions**

**Q: Tôi gặp ngoại lệ hết bộ nhớ khi tải một tệp PPT lớn có chứa hình ảnh. Aspose.Slides có giới hạn nào về kích thước tệp không?**

**A**: Không có công thức cụ thể nào để tính toán kích thước bản trình chiếu mà Aspose.Slides hỗ trợ. Cần có đủ không gian để chứa toàn bộ cấu trúc bản trình chiếu và các hình ảnh trong bộ nhớ. Thông thường, hình ảnh trong bộ nhớ chiếm nhiều không gian hơn so với trên ổ đĩa, đặc biệt khi hình ảnh có các hiệu ứng bổ sung.

Nói chung, Aspose.Slides cho Java có thể dễ dàng xử lý các tệp bản trình chiếu có kích thước khoảng 300 MB trên máy chủ có 4 GB RAM.

## **Working with Slides**

**Q: Tôi có thể thay đổi kích thước của các slide trong một bản trình chiếu không?**

**A**: Bạn có thể sử dụng phương thức `getSlideSize` được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) để định nghĩa kích thước của các slide trong một bản trình chiếu.

**Q: Có cách nào để định nghĩa các slide có kích thước khác nhau trong một bản trình chiếu không?**

**A**: Vì kích thước của các slide được xác định ở mức bản trình chiếu trong tài liệu Microsoft PowerPoint, nên không có cách nào thực hiện điều này.

**Q: Aspose.Slides cho Java có hỗ trợ xem trước một slide trước khi lưu không?**

**A**: Bạn có thể render các slide của bản trình chiếu thành hình ảnh và sử dụng các hình ảnh này để xem trước các slide.

## **Working with Text**

**Q: Có thể truy xuất toàn bộ văn bản từ một bản trình chiếu không?**

**A**: Aspose.Slides cho Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideutil/) với các phương thức khác nhau để truy xuất toàn bộ văn bản từ các bản trình chiếu.

**Q: Tại sao kích thước đoạn văn lại khác nhau trên hệ điều hành Windows và Linux?**

**A**: Việc tính kích thước đoạn văn dựa trên việc tính kích thước văn bản đại diện cho đoạn đó. Kích thước văn bản được tính dựa trên các chỉ số của phông chữ được chỉ định trong bản trình chiếu PowerPoint. Nếu phông chữ được chỉ định không có sẵn, nó sẽ được thay thế bằng phông chữ tương tự nhất, nhưng phông chữ này có các chỉ số khác với phông chữ gốc. Do đó, việc tính kích thước đoạn văn trên các hệ thống khác nhau sẽ cho ra kết quả khác nhau tùy thuộc vào bộ phông chữ đã cài đặt. Để đạt được cùng một kết quả trên các hệ điều hành khác nhau, bạn cần cài đặt cùng một bộ phông chữ trên các hệ thống hoặc tải chúng tại thời gian chạy như [external fonts](/slides/vi/java/custom-font/).

## **Formatting and Images**

**Q: Làm sao để đặt màu cho viền của bảng?**

**A**: Bạn có thể thay đổi màu của tất cả các viền bảng hoặc chỉ viền quanh toàn bộ bảng. Để thay đổi tất cả các viền, vui lòng sử dụng phương thức `getCellFormat` từ giao diện [ICell](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icell/). Đối với viền của toàn bộ bảng, bạn cần duyệt các ô và thay đổi màu của các viền bên ngoài.

**Q: Aspose.Slides cho Java sử dụng đơn vị đo nào để đặt hình ảnh?**

**A**: Các tọa độ và kích thước của tất cả các hình dạng trên slide được đo bằng điểm (points), tương đương 72 dpi.

## **Working with Fonts**

**Q: Khi chuyển đổi PPT sang PDF hoặc hình ảnh, tại sao phông chữ trong tài liệu đầu ra lại khác?**

**A**: Vấn đề này có thể cho thấy các phông chữ được sử dụng trong bản trình chiếu không có trên hệ điều hành mà mã được chạy. Bạn nên cài đặt các phông chữ trên hệ điều hành hoặc tải chúng như phông chữ bên ngoài bằng cách sử dụng lớp [FontsLoader](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/) như dưới đây:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```